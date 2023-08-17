using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

/// <summary>Represents a <see cref="DataTable"/> that is populated asynchronously with information about shell items.</summary>
/// <seealso cref="DataTable"/>
public class ShellDataTable : DataTable
{
	private const string colId = "IDList";
	private const string extAlign = "ColAlign";
	private const string extPropKey = "PropertyKey";
	private const string extSlow = "Slow";
	private const string extState = "ColState";
	private readonly FolderItemFilter itemFilter;
	private readonly ShellFolder? parent;
	private DataColumn[]? colsToGet;
	private List<DataColumn> defCols = new();
	private IEnumerable<PIDL>? items;

	/// <summary>Initializes a new instance of the <see cref="ShellDataTable"/> class with a list of shell items.</summary>
	/// <param name="items">The items for which to collect information.</param>
	public ShellDataTable(IEnumerable<ShellItem> items) : base()
	{
		BuildColumns(ShellFolder.Desktop);
		this.items = items.Select(i => i.PIDL).ToArray();
	}

	/// <summary>Initializes a new instance of the <see cref="ShellDataTable"/> class with the items from a shell folder.</summary>
	/// <param name="folder">The folder whose items are to be retrieved.</param>
	/// <param name="filter">The filter to determine which child items of the folder are enumerated.</param>
	public ShellDataTable(ShellFolder folder, FolderItemFilter filter = FolderItemFilter.Folders | FolderItemFilter.NonFolders) : base(folder.ParsingName)
	{
		itemFilter = filter;
		BuildColumns(parent = folder);
	}

	/// <summary>Occurs when all rows have been added in a call to populate the table with their fast properties.</summary>
	public event EventHandler? AllFastRowsAdded;

	/// <summary>Occurs when all rows have been added in a call to populate the table with all (fast and slow) properties.</summary>
	public event EventHandler? TableLoaded;

	/// <summary>Gets the columns that should be on by default in Details view.</summary>
	/// <value>The default columns.</value>
	public IReadOnlyList<DataColumn> DefaultColumns => defCols;

	/// <summary>Gets a column's visual alignment.</summary>
	/// <param name="column">The column to check.</param>
	/// <returns>The suggested alignment of the column when displayed.</returns>
	public static ComCtl32.ListViewColumnFormat GetColumnAlignment(DataColumn column) => (ComCtl32.ListViewColumnFormat)column.ExtendedProperties[extAlign]!;

	/// <summary>Gets the column property key.</summary>
	/// <param name="column">The column to check.</param>
	/// <returns>The property key associated with the column.</returns>
	public static PROPERTYKEY GetColumnPropertyKey(DataColumn column) => (PROPERTYKEY)column.ExtendedProperties[extPropKey]!;

	/// <summary>Gets the state of the column.</summary>
	/// <param name="column">The column to check.</param>
	/// <returns>A value describing how the column values should be treated.</returns>
	public static SHCOLSTATE GetColumnState(DataColumn column) => (SHCOLSTATE)column.ExtendedProperties[extState]!;

	/// <summary>Gets the PIDL for the row.</summary>
	/// <param name="row">The row to check.</param>
	/// <returns>The PIDL from the row.</returns>
	public static PIDL GetPIDL(DataRow row) => row[colId] is null || row[colId] == DBNull.Value ? PIDL.Null : new PIDL((byte[])row[colId]);

	/// <summary>Determines whether the specified column takes longer to retrieve.</summary>
	/// <param name="column">The column to check.</param>
	/// <returns><see langword="true"/> if the column takes longer to retrieve; otherwise, <see langword="false"/>.</returns>
	public static bool IsColumnSlow(DataColumn column) => (bool)column.ExtendedProperties[extSlow]!;

	/// <summary>Populates the table with all the requested shell items.</summary>
	/// <param name="columns">The names of the columns to populate.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	public async Task PopulateTableAsync(IEnumerable<string> columns, CancellationToken cancellationToken)
	{
		DataColumn[] columnsToGet = columns.Where(n => n != colId).Select(n => Columns[n]).WhereNotNull().ToArray();
		await PopulateTableAsync(columnsToGet, cancellationToken);
	}

	/// <summary>Populates the table with all the requested shell items.</summary>
	/// <param name="columns">The PROPERTYKEY values of the columns to populate.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	public async Task PopulateTableAsync(IEnumerable<PROPERTYKEY> columns, CancellationToken cancellationToken)
	{
		var columnsToGet = columns.Join(Columns.Cast<DataColumn>(), k => k, c => GetColumnPropertyKey(c), (k, c) => c).ToArray();
		await PopulateTableAsync(columnsToGet, cancellationToken);
	}

	/// <summary>Populates the table with all the requested shell items.</summary>
	/// <param name="columns">The columns to populate.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	[MemberNotNull(nameof(colsToGet))]
	public async Task PopulateTableAsync(IEnumerable<DataColumn> columns, CancellationToken cancellationToken)
	{
		var columnsToGet = columns.ToArray();
		if (columnsToGet.Except(Columns.Cast<DataColumn>()).Any())
			throw new ArgumentException("Columns specified that are not in table.", nameof(columns));
		colsToGet = columnsToGet;

		if (parent is not null)
		{
			items = parent.IShellFolder.EnumObjects((SHCONTF)itemFilter);
		}

		if (items is null && parent is not null)
		{
			items = parent.IShellFolder.EnumObjects((SHCONTF)itemFilter);
		}

		if (Rows.Count > 0)
			Rows.Clear();

		var f2 = parent?.IShellFolder as IShellFolder2;
		if (items is not null)
		{
			var slowFetchItems = new List<Task>();
			var cInfo = columnsToGet.ToLookup(c => IsColumnSlow(c), c => ((PROPERTYKEY)c.ExtendedProperties[extPropKey]!, c));
			var fastCols = cInfo[false].ToList();
			var slowCols = cInfo[true].ToList();
			foreach (var i in items)
			{
				if (cancellationToken.IsCancellationRequested) break;

				// Add row with fast properties
				var row = NewRow();
				row[colId] = i.GetBytes();
				foreach (var (pk, col) in fastCols)
					row[col] = GetProp(pk, i) ?? DBNull.Value;
				Rows.Add(row);
				// If there are slow props, spawn thread to get them
				if (slowCols.Count > 0)
					slowFetchItems.Add(GetSlowProps(i, row, slowCols, cancellationToken));
			}
			AllFastRowsAdded?.Invoke(this, EventArgs.Empty);
			AcceptChanges();
			await TaskAgg.WhenAll(slowFetchItems);
		}
		TableLoaded?.Invoke(this, EventArgs.Empty);
		return;

		object? GetProp(in PROPERTYKEY pk, PIDL i)
		{
			object? o = null;
			try
			{
				if (f2 is null)
				{
					using var si = new ShellItem(i);
					o = si.Properties[pk];
				}
				else
				{
					f2.GetDetailsEx(i, pk, out o).ThrowIfFailed();
				}
			}
			catch { }

			return o switch
			{
				FILETIME ft => ft.ToDateTime(),
				_ => o
			};
		}

		async Task GetSlowProps(PIDL i, DataRow row, IEnumerable<(PROPERTYKEY pk, DataColumn col)> props, CancellationToken cancellationToken)
		{
			await TaskAgg.Run(() =>
			{
				row.BeginEdit();
				foreach (var (pk, col) in props)
				{
					if (cancellationToken.IsCancellationRequested) break;
					row[col] = GetProp(pk, i) ?? DBNull.Value;
				}
				row.AcceptChanges();
			}, cancellationToken);
		}
	}

	/// <summary>Refreshes the data table. If columns have not been previously provided, the default columns are used.</summary>
	/// <param name="cancellationToken">The cancellation token.</param>
	public async Task RefreshAsync(CancellationToken cancellationToken) =>
		await PopulateTableAsync((IEnumerable<DataColumn>?)colsToGet ?? DefaultColumns, cancellationToken);

	private void BuildColumns(ShellFolder folder)
	{
		BeginInit();
		if (folder.IShellFolder is IShellFolder2 f2)
		{
			for (uint i = 0; true; i++)
			{
				var hr = f2.GetDefaultColumnState(i, out var cState);
				if (hr == HRESULT.TYPE_E_OUTOFBOUNDS)
					break;
				if (hr.Failed || cState.IsFlagSet(SHCOLSTATE.SHCOLSTATE_HIDDEN))
					continue;
				f2.MapColumnToSCID(i, out var pk);
				PropertyDescription.TryCreate(pk, out var pd);
				f2.GetDetailsOf(PIDL.Null, i, out var cDet);
				var c = new DataColumn(pd?.ToString() ?? cDet.str.ToString(), GetPropType(pd) ?? TypeFromState(cState)) { Caption = pd?.DisplayName, AllowDBNull = true };
				SetExtProp(c, pk, cDet.fmt, cState);
				Columns.Add(c);
			}
		}
		Columns.Add(SetExtProp(new DataColumn(colId, typeof(byte[]))));
		defCols.AddRange(Columns.Cast<DataColumn>().Where(c => GetColumnState(c).IsFlagSet(SHCOLSTATE.SHCOLSTATE_ONBYDEFAULT)));
		EndInit();

		static Type? GetPropType(PropertyDescription? pd)
		{
			var t = pd?.PropertyType;
			if (Equals(t, typeof(FILETIME)))
				t = typeof(DateTime);
			return t;
		}

		static DataColumn SetExtProp(DataColumn c, in PROPERTYKEY pk = default, ComCtl32.ListViewColumnFormat fmt = ComCtl32.ListViewColumnFormat.LVCFMT_LEFT, SHCOLSTATE state = SHCOLSTATE.SHCOLSTATE_PREFER_VARCMP)
		{
			c.ExtendedProperties.Add(extPropKey, pk);
			c.ExtendedProperties.Add(extAlign, fmt);
			c.ExtendedProperties.Add(extSlow, state.IsFlagSet(SHCOLSTATE.SHCOLSTATE_SLOW));
			c.ExtendedProperties.Add(extState, state);
			return c;
		}

		static Type TypeFromState(SHCOLSTATE st) => (st & SHCOLSTATE.SHCOLSTATE_TYPEMASK) switch
		{
			SHCOLSTATE.SHCOLSTATE_TYPE_INT => typeof(int),
			SHCOLSTATE.SHCOLSTATE_TYPE_DATE => typeof(DateTime),
			_ => typeof(string),
		};
	}
}