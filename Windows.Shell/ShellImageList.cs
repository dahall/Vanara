using System;
using System.Drawing;
using Vanara.PInvoke;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Windows.Shell
{
	/// <summary>Used to determine the size of the icon returned by <see cref="ShellImageList.GetSystemIcon"/>.</summary>
	public enum ShellImageSize
	{
		/// <summary>
		/// The image size is normally 32x32 pixels. However, if the Use large icons option is selected from the Effects section of the Appearance tab in
		/// Display Properties, the image is 48x48 pixels.
		/// </summary>
		Large = SHIL.SHIL_LARGE,
		/// <summary>The image is the Shell standard small icon size of 16x16, but the size can be customized by the user.</summary>
		Small = SHIL.SHIL_SMALL,
		/// <summary>The image is the Shell standard extra-large icon size. This is typically 48x48, but the size can be customized by the user.</summary>
		ExtraLarge = SHIL.SHIL_EXTRALARGE,
		/// <summary>Windows Vista and later. The image is normally 256x256 pixels.</summary>
		Jumbo = SHIL.SHIL_JUMBO
	}

	/* *****************************
	 * Developer Note: Keep these methods synchronized with identical methods in Vanara.Windows.Forms::Vanara.Extensions.IconExtension
	 * ***************************** */
	/// <summary>Represents the System Image List holding images for all shell icons.</summary>
	public static class ShellImageList
	{
		/// <summary>Gets the system icon for the given file name or extension.</summary>
		/// <param name="fileNameOrExtension">The file name or extension.</param>
		/// <param name="iconSize">Size of the icon.</param>
		/// <returns>An <see cref="Icon"/> instance if found; otherwise <see langword="null"/>.</returns>
		public static Icon GetSystemIcon(string fileNameOrExtension, ShellImageSize iconSize = ShellImageSize.Large)
		{
			var shfi = new SHFILEINFO();
			var hImageList = (HIMAGELIST)SHGetFileInfo(fileNameOrExtension, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_SYSICONINDEX | (iconSize == ShellImageSize.Small ? SHGFI.SHGFI_SMALLICON : 0));
			if (hImageList.IsNull) return null;
			if (iconSize <= ShellImageSize.Small)
				return ImageList_GetIcon(hImageList, shfi.iIcon, IMAGELISTDRAWFLAGS.ILD_TRANSPARENT).ToIcon();
			SHGetImageList((SHIL)iconSize, typeof(IImageList).GUID, out var il).ThrowIfFailed();
			return il.GetIcon(shfi.iIcon, IMAGELISTDRAWFLAGS.ILD_TRANSPARENT).ToIcon();
		}

		/// <summary>Gets the Shell icon for the given file name or extension.</summary>
		/// <param name="fileNameOrExtension">The file name or extension .</param>
		/// <param name="iconType">Flags to specify the type of the icon to retrieve. This uses the <see cref="SHGetFileInfo(string, System.IO.FileAttributes, ref SHFILEINFO, int, SHGFI)"/> method and can only retrieve small or large icons.</param>
		/// <returns>An <see cref="Icon"/> instance if found; otherwise <see langword="null"/>.</returns>
		public static Icon GetFileIcon(string fileNameOrExtension, ShellIconType iconType = ShellIconType.Large)
		{
			var shfi = new SHFILEINFO();
			var ret = SHGetFileInfo(fileNameOrExtension, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_USEFILEATTRIBUTES | SHGFI.SHGFI_ICON | (SHGFI)iconType);
			if (ret == IntPtr.Zero)
				ret = SHGetFileInfo(fileNameOrExtension, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICON | (SHGFI)iconType);
			return ret == IntPtr.Zero ? null : shfi.hIcon.ToIcon();
		}
	}
}
