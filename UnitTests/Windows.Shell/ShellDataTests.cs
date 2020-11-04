using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Vanara.Extensions;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture]
	public class ShellDataTests
	{
		[Test]
		public void FromFolderTest()
		{
			// Create empty table
			var timer = Stopwatch.StartNew();
			var shData = new ShellDataTable(new ShellFolder(KNOWNFOLDERID.FOLDERID_Documents));
			TestContext.WriteLine($"{timer.ElapsedMilliseconds}\t** Init complete **");

			// Get list of default and slow columns to fetch
			var cols = new List<DataColumn>();
			cols.AddRange(shData.Columns.Cast<DataColumn>().Where(c => ((SHCOLSTATE)c.ExtendedProperties["ColState"]).IsFlagSet(SHCOLSTATE.SHCOLSTATE_ONBYDEFAULT)));
			cols.AddRange(shData.Columns.Cast<DataColumn>().Where(c => (bool)c.ExtendedProperties["Slow"] && c.ColumnName.StartsWith("System.Document.")));
			TestContext.WriteLine(string.Join("\t", cols));

			// Populate table
			shData.RowChanged += ShData_RowChanged;
			shData.AllFastRowsAdded += (s, e) => TestContext.WriteLine($"{timer.ElapsedMilliseconds}\t** Fast items complete **");
			shData.TableLoaded += (s, e) => TestContext.WriteLine($"{timer.ElapsedMilliseconds}\t** All done **");
			var ct = new CancellationTokenSource();
			shData.PopulateTableAsync(cols, ShellItemQueryOptions.ShowHidden, ct.Token).Wait(TimeSpan.FromSeconds(30));

			timer.Stop();

			void ShData_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
			{
				if (e.Action == DataRowAction.Add)
					TestContext.WriteLine($"{timer.ElapsedMilliseconds,5}\t+\t" + GetItems());
				else if (e.Action == DataRowAction.Commit)
					TestContext.WriteLine($"{timer.ElapsedMilliseconds,5}\t*\t" + GetItems());

				string GetItems() => string.Join("\t", cols.Select(c => GetColVal(e.Row[c])));
			}
		}

		[Test]
		public void FromItemsTest()
		{
			// Create empty table
			var timer = Stopwatch.StartNew();
			var items = new[] { ShellItem.Open(TestCaseSources.SmallFile), ShellItem.Open(TestCaseSources.TempDir), ShellItem.Open(TestCaseSources.BmpFile), ShellItem.Open(TestCaseSources.DummyFile), ShellItem.Open(TestCaseSources.LargeFile) };
			var shData = new ShellDataTable(items);
			TestContext.WriteLine($"{timer.ElapsedMilliseconds}\t** Init complete **");

			// Get list of default and slow columns to fetch
			var cols = shData.Columns.Cast<DataColumn>().Take(20).ToList();
			TestContext.WriteLine("\t\t" + string.Join("\t", cols));

			// Populate table
			shData.RowChanged += ShData_RowChanged;
			shData.AllFastRowsAdded += (s, e) => TestContext.WriteLine($"{timer.ElapsedMilliseconds}\t** Fast items complete **");
			shData.TableLoaded += (s, e) => TestContext.WriteLine($"{timer.ElapsedMilliseconds}\t** All done **");
			var ct = new CancellationTokenSource();
			shData.PopulateTableAsync(cols, ShellItemQueryOptions.ShowHidden, ct.Token).Wait(TimeSpan.FromSeconds(30));

			timer.Stop();

			void ShData_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
			{
				if (e.Action == DataRowAction.Add)
					TestContext.WriteLine($"{timer.ElapsedMilliseconds,5}\t+\t" + GetItems());
				else if (e.Action == DataRowAction.Commit)
					TestContext.WriteLine($"{timer.ElapsedMilliseconds,5}\t*\t" + GetItems());

				string GetItems() => string.Join("\t", cols.Select(c => GetColVal(e.Row[c])));
			}
		}

		private static string GetColVal(object o) => o switch
		{
			null => string.Empty,
			DBNull _ => string.Empty,
			string[] a => string.Join(",", a),
			_ => o.ToString()
		};
	}
}