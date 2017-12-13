using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Windows.Shell
{
	public static class ShellImageList
	{
		private static IntPtr largeImageListHandle;
		private static IntPtr smallImageListHandle;

		static ShellImageList()
		{
			const SHGFI baseFlags = SHGFI.SHGFI_USEFILEATTRIBUTES | SHGFI.SHGFI_SYSICONINDEX;

			var shfiSz = Marshal.SizeOf(typeof(SHFILEINFO));

			var shfiSmall = new SHFILEINFO();
			smallImageListHandle = SHGetFileInfo(".txt", FileAttributes.Normal, ref shfiSmall, shfiSz, baseFlags | SHGFI.SHGFI_SMALLICON);
			
			var shfiLarge = new SHFILEINFO();
			largeImageListHandle = SHGetFileInfo(".txt", FileAttributes.Normal, ref shfiLarge, shfiSz, baseFlags | SHGFI.SHGFI_LARGEICON);
		}

		public static Icon GetIcon(int index, bool small = true)
		{
			var hIcon = ImageList_GetIcon(small ? smallImageListHandle : largeImageListHandle, index, IMAGELISTDRAWFLAGS.ILD_NORMAL);
			if (hIcon == IntPtr.Zero) return null;
			var icon = Icon.FromHandle(hIcon);
			var ret = (Icon)icon.Clone();
			DestroyIcon(hIcon);
			return ret;
		}
	}
}
