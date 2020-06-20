using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	/// <summary>A static object that represents the system Recycle Bin.</summary>
	public static class RecycleBin
	{
		private static ShellFolder recycleBin;

		/// <summary>Gets the count of the items in the Recycle Bin. Depending on the number of items, this can take some time.</summary>
		/// <value>The number of items.</value>
		public static long Count => GetInfo().i64NumItems;

		/// <summary>Gets the total size of all items in the Recycle Bin.</summary>
		/// <value>The total size of all items in the Recycle Bin.</value>
		public static long Size => GetInfo().i64Size;

		private static ShellFolder ShellFolder => recycleBin ??= new ShellFolder(KNOWNFOLDERID.FOLDERID_RecycleBinFolder);

		/// <summary>Deletes the specified file or directory to the Recycle Bin.</summary>
		/// <param name="path">The full path of the file or directory.</param>
		/// <param name="hideUI"><see langword="true"/> to hide all user interface interactions; <see langword="false"/> to allow them.</param>
		public static void DeleteToRecycleBin(string path, bool hideUI = false) => ShellFileOperations.Delete(path, GetDeleteOpFlags(hideUI));

		/// <summary>Deletes the specified files or directories to the Recycle Bin.</summary>
		/// <param name="paths">The full paths of the file or directory.</param>
		/// <param name="hideUI"><see langword="true"/> to hide all user interface interactions; <see langword="false"/> to allow them.</param>
		public static void DeleteToRecycleBin(IEnumerable<string> paths, bool hideUI = false) => ShellFileOperations.Delete(paths.Select(p => new ShellItem(p)), GetDeleteOpFlags(hideUI));

		/// <summary>Empties the Recycle Bin.</summary>
		/// <param name="hideUI"><see langword="true"/> to hide all user interface interactions; <see langword="false"/> to allow them.</param>
		/// <param name="noConfirmation">
		/// <see langword="true"/> to indicate that no dialog box confirming the deletion of the objects will be displayed; <see
		/// langword="false"/> otherwise.
		/// </param>
		/// <param name="noSound">if set to <see langword="true"/> no sound will be played when the operation is complete.</param>
		public static void Empty(bool hideUI = true, bool noConfirmation = true, bool noSound = true)
		{
			var flags = (hideUI ? SHERB.SHERB_NOPROGRESSUI : 0) | (noConfirmation ? SHERB.SHERB_NOCONFIRMATION : 0) | (noSound ? SHERB.SHERB_NOSOUND : 0);
			SHEmptyRecycleBin(default, null, flags).ThrowIfFailed();
		}

		/// <summary>Gets the <see cref="ShellItem"/> in the Recycle Bin from the path of originally deleted file or directory.</summary>
		/// <param name="itemPath">The deleted items full original path.</param>
		/// <returns>
		/// The <see cref="ShellItem"/> matching the item specified in <paramref name="itemPath"/> or <see langword="null"/> if not found.
		/// </returns>
		public static ShellItem GetItemFromOriginalPath(string itemPath) => GetItems().FirstOrDefault(i => string.Equals(i.Name, itemPath, StringComparison.OrdinalIgnoreCase));

		/// <summary>Gets all the <see cref="ShellItem"/> references at the top level of the Recycle Bin.</summary>
		/// <returns>A sequence of <see cref="ShellItem"/> objects at the top level of the Recycle Bin.</returns>
		public static IEnumerable<ShellItem> GetItems() => ShellFolder;

		/// <summary>Restores the specified deleted item to it's original location.</summary>
		/// <param name="deletedItem">
		/// The <see cref="ShellItem"/> of the deleted item in the Recycle Bin. This cannot be a reference to an undeleted shell item.
		/// </param>
		/// <param name="hideUI"><see langword="true"/> to hide all user interface interactions; <see langword="false"/> to allow them.</param>
		public static void Restore(ShellItem deletedItem, bool hideUI = false) => Restore(new[] { deletedItem }, hideUI);

		/// <summary>Restores the specified deleted items to their original location.</summary>
		/// <param name="deletedItems">
		/// A sequence of <see cref="ShellItem"/> objects in the Recycle Bin. These cannot be a references to undeleted shell items.
		/// </param>
		/// <param name="hideUI"><see langword="true"/> to hide all user interface interactions; <see langword="false"/> to allow them.</param>
		public static void Restore(IEnumerable<ShellItem> deletedItems, bool hideUI = false)
		{
			using var sop = new ShellFileOperations { Options = GetDeleteOpFlags(hideUI) };
			HRESULT hr = HRESULT.S_OK;
			sop.PostMoveItem += OnPost;
			try
			{
				foreach (var item in deletedItems)
				{
					if (item.Parent != ShellFolder) throw new InvalidOperationException("Unable to restore a ShellItem that is not in the Recycle Bin.");
					using var sf = new ShellFolder(Path.GetDirectoryName(item.Name));
					sop.QueueMoveOperation(item, sf, Path.GetFileName(item.Name));
				}
				sop.PerformOperations();
				hr.ThrowIfFailed();
			}
			finally
			{
				sop.PostMoveItem -= OnPost;
			}

			void OnPost(object sender, ShellFileOperations.ShellFileOpEventArgs e) => hr = e.Result;
		}

		/// <summary>Restores all items in the Recycle Bin to their original location.</summary>
		/// <param name="hideUI"><see langword="true"/> to hide all user interface interactions; <see langword="false"/> to allow them.</param>
		public static void RestoreAll(bool hideUI = false) => Restore(GetItems(), hideUI);

		private static ShellFileOperations.OperationFlags GetDeleteOpFlags(bool hideUI)
		{
			var flags = ShellFileOperations.OperationFlags.NoConfirmMkDir | ShellFileOperations.OperationFlags.AllowUndo;
			if (Vanara.PInvoke.PInvokeClient.Windows8.IsPlatformSupported())
				flags |= ShellFileOperations.OperationFlags.AddUndoRecord | ShellFileOperations.OperationFlags.RecycleOnDelete;
			if (hideUI)
				flags |= ShellFileOperations.OperationFlags.Silent | ShellFileOperations.OperationFlags.NoErrorUI | ShellFileOperations.OperationFlags.NoConfirmation;
			return flags;
		}

		private static SHQUERYRBINFO GetInfo()
		{
			var qi = new SHQUERYRBINFO { cbSize = (uint)Marshal.SizeOf(typeof(SHQUERYRBINFO)) };
			SHQueryRecycleBin(null, ref qi).ThrowIfFailed();
			return qi;
		}
	}
}