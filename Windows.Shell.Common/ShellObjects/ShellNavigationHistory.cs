using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Vanara.Collections;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

/// <summary>The navigation log is a history of the locations visited by a shell view object.</summary>
public class ShellNavigationHistory : IHistory<ShellItem>
{
	private readonly History<PIDL> pidls = new();

	/// <summary>Initializes a new instance of the <see cref="ShellNavigationHistory"/> class.</summary>
	public ShellNavigationHistory()
	{
		pidls.CollectionChanged += (s, e) => CollectionChanged?.Invoke(this, e);
		pidls.PropertyChanged += (s, e) => PropertyChanged?.Invoke(this, e);
	}

	/// <summary>Occurs when an item is added, removed, changed, moved, or the entire list is refreshed.</summary>
	public event NotifyCollectionChangedEventHandler? CollectionChanged;

	/// <summary>Occurs when a property value changes.</summary>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>Indicates the presence of items in the history that can be reached by calling <see cref="M:Vanara.Collections.IHistory`1.SeekBackward"/>.</summary>
	/// <value><see langword="true"/> if this instance can seek backward; otherwise, <see langword="false"/>.</value>
	public bool CanSeekBackward => pidls.CanSeekBackward;

	/// <summary>Indicates the presence of items in the history that can be reached by calling <see cref="M:Vanara.Collections.IHistory`1.SeekForward"/>.</summary>
	/// <value><see langword="true"/> if this instance can seek forward; otherwise, <see langword="false"/>.</value>
	public bool CanSeekForward => pidls.CanSeekForward;

	/// <summary>Gets the items in the history.</summary>
	/// <value>The number of items.</value>
	public int Count => pidls.Count;

	/// <summary>Gets the shell object in the Locations collection pointed to by CurrentLocationIndex.</summary>
	public ShellItem? Current => pidls.Current is null ? null : new(pidls.Current);

	/// <summary>
	/// Adds the specified item as the last history entry and sets the <see cref="P:Vanara.Collections.IHistory`1.Current"/> property to
	/// it's value.
	/// </summary>
	/// <param name="item">The item to add to the history.</param>
	public void Add(ShellItem item) => pidls.Add(item.PIDL, true);

	/// <summary>Clears the history of all items.</summary>
	public void Clear() => pidls.Clear();

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>A <see cref="IEnumerator{T}"/> that can be used to iterate through the collection.</returns>
	public IEnumerator<ShellItem> GetEnumerator() => pidls.WhereNotNull().Select(p => new ShellItem(p)).GetEnumerator();

	/// <summary>Gets a specified number of items starting at a location within the history.</summary>
	/// <param name="count">The maximum number of items to retrieve. The actual number of items returned may be less if not avaialable.</param>
	/// <param name="origin">The reference point within the history at which to start fetching items.</param>
	/// <returns>A read-only list of items.</returns>
	public IReadOnlyList<ShellItem> GetItems(int count, SeekOrigin origin) => new List<ShellItem>(pidls.GetItems(count, origin).Select(ShIFromPIDL).WhereNotNull());

	/// <summary>
	/// Seeks through the history a given number of items starting at a known location within the history. This updates the <see
	/// cref="P:Vanara.Collections.IHistory`1.Current"/> property.
	/// </summary>
	/// <param name="count">The number of items to move. This value can be negative to search backwards or positive to search forwards.</param>
	/// <param name="origin">The reference point within the history at which to start seeking.</param>
	/// <returns>The value at the new current pointer position.</returns>
	public ShellItem? Seek(int count, SeekOrigin origin) => ShIFromPIDL(pidls.Seek(count, origin));

	/// <summary>Seeks one position backwards.</summary>
	/// <returns>The value at the new current pointer position.</returns>
	public ShellItem? SeekBackward() => ShIFromPIDL(pidls.SeekBackward());

	/// <summary>Seeks one position forwards.</summary>
	/// <returns>The value at the new current pointer position.</returns>
	public ShellItem? SeekForward() => ShIFromPIDL(pidls.SeekForward());

	/// <summary>
	/// Adds the specified item as the last history entry and sets the <see cref="P:Vanara.Collections.IHistory`1.Current"/> property to
	/// it's value.
	/// </summary>
	/// <param name="item">The item to add to the history.</param>
	/// <param name="removeForwardItems">
	/// <see langword="true"/> indicates to remove all items forward of the current pointer; <see langword="false"/> leaves the history intact.
	/// </param>
	void IHistory<ShellItem>.Add(ShellItem? item, bool removeForwardItems) => pidls.Add(item?.PIDL, removeForwardItems);

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	internal void Add(PIDL pidl) => pidls.Add(pidl, true);

	private static ShellItem? ShIFromPIDL(PIDL? pidl) => pidl is null ? null : new ShellItem(pidl);
}