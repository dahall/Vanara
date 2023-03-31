using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

/// <summary>A folder or container of <see cref="ShellItem"/> instances.</summary>
public class ShellItemArray : IReadOnlyList<ShellItem>, IDisposable
{
	private IShellItemArray array;

	/// <summary>Initializes a new instance of the <see cref="ShellFolder"/> class.</summary>
	public ShellItemArray() { }

	/// <summary>Initializes a new instance of the <see cref="ShellItem" /> class.</summary>
	/// <param name="shellItems">The shell items.</param>
	public ShellItemArray(IShellItemArray shellItems)
	{
		array = shellItems;
	}

	/// <summary>Initializes a new instance of the <see cref="ShellItemArray"/> class.</summary>
	/// <param name="shellItems">The shell items to add to this array.</param>
	public ShellItemArray(IEnumerable<ShellItem> shellItems) : this(shellItems.Select(i => (IntPtr)i.PIDL).ToArray())
	{
	}

	/// <summary>Initializes a new instance of the <see cref="ShellItemArray"/> class.</summary>
	/// <param name="pidls">The IDList items to add to this array.</param>
	public ShellItemArray(IEnumerable<PIDL> pidls) : this(pidls.Select(p => (IntPtr)p).ToArray())
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="ShellItemArray" /> class.
	/// </summary>
	/// <param name="parent">The Shell data source object that is the parent of the child items specified in <paramref name="pidls"/>.</param>
	/// <param name="pidls">The list of child item IDs for which the array is being created. This value can be <see langword="null"/>.</param>
	public ShellItemArray(IShellFolder parent, IEnumerable<PIDL> pidls)
	{
		var pa = pidls?.Cast<IntPtr>().ToArray();
		SHCreateShellItemArray(PIDL.Null, parent, (uint)(pa?.Length ?? 0), pa, out array).ThrowIfFailed();
	}

	/// <summary>Initializes a new instance of the <see cref="ShellItemArray"/> class.</summary>
	/// <param name="pidls">The IDList items to add to this array.</param>
	private ShellItemArray(IntPtr[] pidls)
	{
		SHCreateShellItemArrayFromIDLists((uint)pidls.Length, pidls, out array).ThrowIfFailed();
	}

	/// <summary>Gets the number of elements contained in the <see cref="ICollection{ShellItem}"/>.</summary>
	public int Count => (int)(array?.GetCount() ?? 0);

	/// <summary>Gets the <see cref="IEnumShellItems"/> instance behind this class.</summary>
	/// <value>The <see cref="IEnumShellItems"/> instance.</value>
	public IEnumShellItems IEnumShellItems => array?.EnumItems();

	/// <summary>Gets the <see cref="IShellItemArray"/> instance behind this class.</summary>
	/// <value>The <see cref="IShellItemArray"/> instance.</value>
	public IShellItemArray IShellItemArray => array;

	/// <summary>Gets the <see cref="ShellItem"/> at the specified index.</summary>
	/// <value>The <see cref="ShellItem"/>.</value>
	/// <param name="index">The index.</param>
	/// <returns>A <see cref="ShellItem"/> instance.</returns>
	public ShellItem this[int index] => array is null ? throw new ArgumentOutOfRangeException(nameof(index)) : ShellItem.Open(array.GetItemAt((uint)index));

	/// <summary>Creates a shell item array from a data object.</summary>
	/// <param name="dataObject">The data object.</param>
	/// <returns>On success, a new <see cref="ShellItemArray"/>; otherwise <see langword="null"/>.</returns>
	public static ShellItemArray FromDataObject(System.Runtime.InteropServices.ComTypes.IDataObject dataObject)
	{
		var ppv = SHCreateShellItemArrayFromDataObject(dataObject);
		return ppv is null ? null : new ShellItemArray(ppv);
	}

	/// <summary>Determines whether the <see cref="ICollection{ShellItem}"/> contains a specific value.</summary>
	/// <param name="item">The object to locate in the <see cref="ICollection{ShellItem}"/>.</param>
	/// <returns>true if <paramref name="item"/> is found in the <see cref="ICollection{ShellItem}"/>; otherwise, false.</returns>
	public bool Contains(ShellItem item) => item != null && GetItems().Any(item.Equals);

	/// <summary>
	/// Copies the elements of the <see cref="ICollection{ShellItem}"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="Array"/> index.
	/// </summary>
	/// <param name="array">
	/// The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="ICollection{ShellItem}"/>. The
	/// <see cref="Array"/> must have zero-based indexing.
	/// </param>
	/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
	public void CopyTo(ShellItem[] array, int arrayIndex)
	{
		var a = GetItems().Select(ShellItem.Open).ToArray();
		Array.Copy(a, 0, array, arrayIndex, a.Length);
	}

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public virtual void Dispose()
	{
		array = null;
	}

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>A <see cref="IEnumerator{ShellItem}"/> that can be used to iterate through the collection.</returns>
	public IEnumerator<ShellItem> GetEnumerator() => GetItems().Select(ShellItem.Open).GetEnumerator();

	/// <summary>Creates an <see cref="System.Runtime.InteropServices.ComTypes.IDataObject"/> from the contents of the array.</summary>
	/// <returns>An <see cref="System.Runtime.InteropServices.ComTypes.IDataObject"/> from the contents of the array.</returns>
	public System.Runtime.InteropServices.ComTypes.IDataObject ToDataObject()
	{
		var ctx = ShellUtil.CreateBindCtx();
		return array.BindToHandler<System.Runtime.InteropServices.ComTypes.IDataObject>(ctx, BHID.BHID_DataObject);
	}

	/// <summary>Returns an enumerator that iterates through a collection.</summary>
	/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	/// <summary>Gets the items.</summary>
	protected IEnumerable<IShellItem> GetItems()
	{
		if (array is null) yield break;
		for (uint i = 0; i < array.GetCount(); i++)
			yield return array.GetItemAt(i);
	}
}