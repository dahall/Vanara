using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Vanara.PInvoke;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Shell
{
	/// <summary>Used to determine the size of the icon returned by <c>ShellImageList.GetSystemIcon</c>.</summary>
	public enum ShellImageSize
	{
		/// <summary>
		/// The image size is normally 32x32 pixels. However, if the Use large icons option is selected from the Effects section of the
		/// Appearance tab in Display Properties, the image is 48x48 pixels.
		/// </summary>
		Large = SHIL.SHIL_LARGE,

		/// <summary>The image is the Shell standard small icon size of 16x16, but the size can be customized by the user.</summary>
		Small = SHIL.SHIL_SMALL,

		/// <summary>
		/// The image is the Shell standard extra-large icon size. This is typically 48x48, but the size can be customized by the user.
		/// </summary>
		ExtraLarge = SHIL.SHIL_EXTRALARGE,

		/// <summary>
		/// These images are the size specified by GetSystemMetrics called with SM_CXSMICON and GetSystemMetrics called with SM_CYSMICON.
		/// </summary>
		SystemSmall = SHIL.SHIL_SYSSMALL,

		/// <summary>Windows Vista and later. The image is normally 256x256 pixels.</summary>
		Jumbo = SHIL.SHIL_JUMBO,
	}

	/* *****************************
	 * Developer Note: Keep these methods synchronized with identical methods in Vanara.Windows.Forms::Vanara.Extensions.IconExtension
	 * ***************************** */
	/// <summary>Represents the System Image List holding images for all shell icons.</summary>
	public static class ShellImageList
	{
		private const string REGSTR_PATH_METRICS = "Control Panel\\Desktop\\WindowMetrics";
		private static readonly Dictionary<ShellImageSize, ushort> g_rgshil;
		private static readonly int SHIL_COUNT;
		private static HIMAGELIST hSystemImageList;

		static ShellImageList()
		{
			SHIL_COUNT = Enum.GetValues(typeof(ShellImageSize)).Length;
			g_rgshil = new Dictionary<ShellImageSize, ushort>(SHIL_COUNT); // new ushort[SHIL_COUNT];
			var sysCxIco = GetSystemMetrics(SystemMetric.SM_CXICON);
			g_rgshil[ShellImageSize.Large] = (ushort)(int)Microsoft.Win32.Registry.CurrentUser.GetValue($"{REGSTR_PATH_METRICS}\\Shell Icon Size", sysCxIco);
			g_rgshil[ShellImageSize.Small] = (ushort)(int)Microsoft.Win32.Registry.CurrentUser.GetValue($"{REGSTR_PATH_METRICS}\\Shell Small Icon Size", sysCxIco / 2);
			g_rgshil[ShellImageSize.ExtraLarge] = (ushort)(3 * sysCxIco / 2);
			g_rgshil[ShellImageSize.SystemSmall] = (ushort)GetSystemMetrics(SystemMetric.SM_CXSMICON);
			g_rgshil[ShellImageSize.Jumbo] = 256;
		}

		/// <summary>Gets the Shell icon for the given file name or extension.</summary>
		/// <param name="fileNameOrExtension">The file name or extension .</param>
		/// <param name="iconType">
		/// Flags to specify the type of the icon to retrieve. This uses the <see cref="SHGetFileInfo(string, System.IO.FileAttributes, ref
		/// SHFILEINFO, int, SHGFI)"/> method and can only retrieve small or large icons.
		/// </param>
		/// <returns>An <see cref="Icon"/> instance if found; otherwise <see langword="null"/>.</returns>
		public static Icon GetFileIcon(string fileNameOrExtension, ShellIconType iconType = ShellIconType.Large)
		{
			var shfi = new SHFILEINFO();
			var ret = SHGetFileInfo(fileNameOrExtension, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_USEFILEATTRIBUTES | SHGFI.SHGFI_ICON | (SHGFI)iconType);
			if (ret == IntPtr.Zero)
				ret = SHGetFileInfo(fileNameOrExtension, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICON | (SHGFI)iconType);
			return ret == IntPtr.Zero ? null : shfi.hIcon.ToIcon();
		}

		/// <summary>Gets the system icon for the given file name or extension.</summary>
		/// <param name="fileNameOrExtension">The file name or extension.</param>
		/// <param name="iconSize">Size of the icon.</param>
		/// <returns>An <see cref="Icon"/> instance if found; otherwise <see langword="null"/>.</returns>
		public static Icon GetSystemIcon(string fileNameOrExtension, ShellImageSize iconSize = ShellImageSize.Large)
		{
			var shfi = new SHFILEINFO();
			if (hSystemImageList.IsNull)
				hSystemImageList = SHGetFileInfo(fileNameOrExtension, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_SYSICONINDEX | (iconSize == ShellImageSize.Small ? SHGFI.SHGFI_SMALLICON : 0));
			if (hSystemImageList.IsNull) return null;
			if (iconSize <= ShellImageSize.Small)
				return ImageList_GetIcon(hSystemImageList, shfi.iIcon, IMAGELISTDRAWFLAGS.ILD_TRANSPARENT).ToIcon();
			return GetSystemIcon(shfi.iIcon, iconSize);
		}

		/// <summary>Gets the system icon for and index and size.</summary>
		/// <param name="index">The index of the system icon to retrieve.</param>
		/// <param name="iconSize">Size of the icon.</param>
		/// <returns>An <see cref="Icon"/> instance if found; otherwise <see langword="null"/>.</returns>
		public static Icon GetSystemIcon(int index, ShellImageSize iconSize = ShellImageSize.Large) => GetSystemIconHandle(index, iconSize)?.ToIcon();

		/// <summary>Gets the system icon for and index and size.</summary>
		/// <param name="index">The index of the system icon to retrieve.</param>
		/// <param name="iconSize">Size of the icon.</param>
		/// <returns>An <see cref="Icon"/> instance if found; otherwise <see langword="null"/>.</returns>
		public static SafeHICON GetSystemIconHandle(int index, ShellImageSize iconSize = ShellImageSize.Large)
		{
			SHGetImageList((SHIL)iconSize, typeof(IImageList).GUID, out var il).ThrowIfFailed();
			return il.GetIcon(index, IMAGELISTDRAWFLAGS.ILD_TRANSPARENT);
		}

		/// <summary>Given a pixel size, return the ShellImageSize value with the closest size.</summary>
		/// <param name="pixels">Size, in pixels, of the image list size to search for.</param>
		/// <returns>An image list size.</returns>
		public static ShellImageSize PixelsToSHIL(int pixels) => g_rgshil.Aggregate((x, y) => Math.Abs(x.Value - pixels) < Math.Abs(y.Value - pixels) ? x : y).Key;

		/// <summary>Given an image list size, return the related size, in pixels, of that size defined on the system.</summary>
		/// <param name="imageListSize">Size of the image list.</param>
		/// <returns>Pixel size of corresponding system value.</returns>
		public static int SHILtoPixels(ShellImageSize imageListSize) => g_rgshil[imageListSize];
	}
}