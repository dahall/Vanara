using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	/// <summary>A folder or container of <see cref="ShellItem"/> instances.</summary>
	public class ShellItemArray : IReadOnlyList<ShellItem>, IDisposable
	{
		private IShellItemArray array;

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

		/// <summary>Initializes a new instance of the <see cref="ShellItemArray"/> class.</summary>
		/// <param name="pidls">The IDList items to add to this array.</param>
		private ShellItemArray(IntPtr[] pidls)
		{
			SHCreateShellItemArrayFromIDLists((uint)pidls.Length, pidls, out array).ThrowIfFailed();
		}

		/// <summary>Initializes a new instance of the <see cref="ShellFolder"/> class.</summary>
		private ShellItemArray() { }

		/// <summary>Gets the number of elements contained in the <see cref="ICollection{ShellItem}"/>.</summary>
		public int Count => (int)array.GetCount();

		/// <summary>Gets the <see cref="IEnumShellItems"/> instance behind this class.</summary>
		/// <value>The <see cref="IEnumShellItems"/> instance.</value>
		public IEnumShellItems IEnumShellItems => array.EnumItems();

		/// <summary>Gets the <see cref="IShellItemArray"/> instance behind this class.</summary>
		/// <value>The <see cref="IShellItemArray"/> instance.</value>
		public IShellItemArray IShellItemArray => array;

		/// <summary>Gets the <see cref="ShellItem"/> at the specified index.</summary>
		/// <value>The <see cref="ShellItem"/>.</value>
		/// <param name="index">The index.</param>
		/// <returns>A <see cref="ShellItem"/> instance.</returns>
		public ShellItem this[int index] => ShellItem.Open(array.GetItemAt((uint)index));

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
			if (array != null)
			{
				Marshal.ReleaseComObject(array);
				array = null;
			}
		}

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="IEnumerator{ShellItem}"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<ShellItem> GetEnumerator() => GetItems().Select(ShellItem.Open).GetEnumerator();

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>Gets the items.</summary>
		protected IEnumerable<IShellItem> GetItems()
		{
			for (uint i = 0; i < array.GetCount(); i++)
				yield return array.GetItemAt(i);
		}
	}
}