using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Utilities to work with <see cref="PIDL"/> and raw ITEMIDLIST pointers.</summary>
	public static class PIDLUtil
	{
		/// <summary>Clones an ITEMIDLIST structure</summary>
		public static PIDL ILClone(IntPtr pidl) => new PIDL(IntILClone(pidl));

		/// <summary>Clones the first SHITEMID structure in an ITEMIDLIST structure</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure that you want to clone.</param>
		/// <returns>
		/// A pointer to an ITEMIDLIST structure that contains the first SHITEMID structure from the ITEMIDLIST structure specified by
		/// pidl. Returns NULL on failure.
		/// </returns>
		public static PIDL ILCloneFirst(IntPtr pidl)
		{
			var size = ItemIdSize(pidl);

			var bytes = new byte[size + 2];
			Marshal.Copy(pidl, bytes, 0, size);

			var newPidl = Marshal.AllocCoTaskMem(size + 2);
			Marshal.Copy(bytes, 0, newPidl, size + 2);

			return new PIDL(newPidl);
		}

		/// <summary>Combines two ITEMIDLIST structures.</summary>
		/// <param name="pidl1">A pointer to the first ITEMIDLIST structure.</param>
		/// <param name="pidl2">
		/// A pointer to the second ITEMIDLIST structure. This structure is appended to the structure pointed to by pidl1.
		/// </param>
		/// <returns>
		/// Returns an ITEMIDLIST containing the combined structures. If you set either pidl1 or pidl2 to NULL, the returned ITEMIDLIST
		/// structure is a clone of the non-NULL parameter. Returns NULL if pidl1 and pidl2 are both set to NULL.
		/// </returns>
		public static PIDL ILCombine(IntPtr pidl1, IntPtr pidl2) => new PIDL(IntILCombine(pidl1, pidl2));

		/// <summary>Returns a pointer to the last SHITEMID structure in an ITEMIDLIST structure</summary>
		/// <param name="pidl">A pointer to an ITEMIDLIST structure.</param>
		/// <returns>A pointer to the last SHITEMID structure in pidl.</returns>
		public static IntPtr ILFindLastId(IntPtr pidl)
		{
			var ptr1 = pidl;
			var ptr2 = ILGetNext(ptr1);

			while (ItemIdSize(ptr2) > 0)
			{
				ptr1 = ptr2;
				ptr2 = ILGetNext(ptr1);
			}

			return ptr1;
		}

		/// <summary>Gets the next SHITEMID structure in an ITEMIDLIST structure</summary>
		/// <param name="pidl">A pointer to a particular SHITEMID structure in a larger ITEMIDLIST structure.</param>
		/// <returns>
		/// Returns a pointer to the SHITEMID structure that follows the one specified by pidl. Returns NULL if pidl points to the last
		/// SHITEMID structure.
		/// </returns>
		public static IntPtr ILGetNext(IntPtr pidl)
		{
			var size = ItemIdSize(pidl);
			return size == 0 ? IntPtr.Zero : pidl.Offset(size);
		}

		/// <summary>Determines whether the specified ITEMIDLIST has no children.</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be evaluated.</param>
		/// <returns><c>true</c> if the specified ITEMIDLIST is empty; otherwise, <c>false</c>.</returns>
		public static bool ILIsEmpty(IntPtr pidl) => ItemIdListSize(pidl) == 0;

		/// <summary>Removes the last SHITEMID structure from an ITEMIDLIST structure</summary>
		/// <param name="pidl">
		/// A pointer to the ITEMIDLIST structure to be shortened. When the function returns, this variable points to the shortened structure.
		/// </param>
		/// <returns>Returns TRUE if successful, FALSE otherwise.</returns>
		public static bool ILRemoveLastId(IntPtr pidl)
		{
			var lastPidl = ILFindLastId(pidl);

			if (lastPidl == pidl) return false;

			var newSize = (int)lastPidl - (int)pidl + 2;
			Marshal.ReAllocCoTaskMem(pidl, newSize);
			Marshal.Copy(new byte[] { 0, 0 }, 0, pidl.Offset(newSize - 2), 2);
			return true;
		}

		/// <summary>Separates an ITEMIDLIST into the parent SHITEMID and the children SHITEMIDs</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be evaluated.</param>
		/// <param name="parent">The parent.</param>
		/// <param name="child">The children.</param>
		/// <returns>Returns TRUE if successful, FALSE otherwise.</returns>
		public static bool SplitPidl(IntPtr pidl, out IntPtr parent, out IntPtr child)
		{
			parent = IntILClone(pidl);
			child = IntILClone(ILFindLastId(pidl));

			if (ILRemoveLastId(parent)) return true;

			Marshal.FreeCoTaskMem(parent);
			Marshal.FreeCoTaskMem(child);
			return false;
		}

		/// <summary>Clones an ITEMIDLIST structure</summary>
		internal static IntPtr IntILClone(IntPtr pidl)
		{
			var size = ItemIdListSize(pidl);

			var bytes = new byte[size + 2];
			Marshal.Copy(pidl, bytes, 0, size);

			var newPidl = Marshal.AllocCoTaskMem(size + 2);
			Marshal.Copy(bytes, 0, newPidl, size + 2);

			return newPidl;
		}

		/// <summary>Combines two ITEMIDLIST structures</summary>
		internal static IntPtr IntILCombine(IntPtr pidl1, IntPtr pidl2)
		{
			var size1 = ItemIdListSize(pidl1);
			var size2 = ItemIdListSize(pidl2);

			var newPidl = Marshal.AllocCoTaskMem(size1 + size2 + 2);
			var bytes = new byte[size1 + size2 + 2];

			Marshal.Copy(pidl1, bytes, 0, size1);
			Marshal.Copy(pidl2, bytes, size1, size2);

			Marshal.Copy(bytes, 0, newPidl, bytes.Length);

			return newPidl;
		}

		/*public static void WriteBytes(IntPtr handle)
		{
			var size = Marshal.ReadByte(handle, 0) + Marshal.ReadByte(handle, 1)*256 - 2;

			for (var i = 0; i < size; i++)
			{
				Console.Out.WriteLine(Marshal.ReadByte(handle, i + 2));
			}

			Console.Out.WriteLine(Marshal.ReadByte(handle, size + 2));
			Console.Out.WriteLine(Marshal.ReadByte(handle, size + 3));
		}*/

		internal static int ItemIdListSize(IntPtr handle)
		{
			if (handle.Equals(IntPtr.Zero))
				return 0;
			var size = ItemIdSize(handle);
			var nextSize = Marshal.ReadInt16(handle, size);
			while (nextSize > 0)
			{
				size += nextSize;
				nextSize = Marshal.ReadInt16(handle, size);
			}
			return size;
		}

		internal static int ItemIdSize(IntPtr handle) => handle.Equals(IntPtr.Zero) ? 0 : Marshal.ReadInt16(handle);
	}
}