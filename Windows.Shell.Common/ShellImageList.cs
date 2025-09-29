using Vanara.PInvoke;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Shell;

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
	private static HIMAGELIST hSystemImageList;

	/// <summary>Gets the Shell icon for the given file name or extension.</summary>
	/// <param name="fileNameOrExtension">The file name or extension .</param>
	/// <param name="iconType">
	/// Flags to specify the type of the icon to retrieve. This uses the <see cref="SHGetFileInfo(string, System.IO.FileAttributes, ref
	/// SHFILEINFO, int, SHGFI)"/> method and can only retrieve small or large icons.
	/// </param>
	/// <returns>A <see cref="SafeHICON"/> instance if found; otherwise <see langword="null"/>.</returns>
	public static SafeHICON? GetFileIcon(string fileNameOrExtension, ShellIconType iconType = ShellIconType.Large)
	{
		var shfi = new SHFILEINFO();
		var ret = SHGetFileInfo(fileNameOrExtension, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_USEFILEATTRIBUTES | SHGFI.SHGFI_ICON | (SHGFI)iconType);
		if (ret == IntPtr.Zero)
			ret = SHGetFileInfo(fileNameOrExtension, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICON | (SHGFI)iconType);
		return ret == IntPtr.Zero ? null : new SafeHICON((IntPtr)shfi.hIcon);
	}

	/// <summary>Gets the system icon for the given file name or extension.</summary>
	/// <param name="fileNameOrExtension">The file name or extension.</param>
	/// <param name="iconSize">Size of the icon.</param>
	/// <returns>A <see cref="SafeHICON"/> instance if found; otherwise <see langword="null"/>.</returns>
	public static SafeHICON? GetSystemIcon(string fileNameOrExtension, ShellImageSize iconSize = ShellImageSize.Large)
	{
		var shfi = new SHFILEINFO();
		if (hSystemImageList.IsNull)
			hSystemImageList = SHGetFileInfo(fileNameOrExtension, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_SYSICONINDEX | (iconSize == ShellImageSize.Small ? SHGFI.SHGFI_SMALLICON : 0));
		if (hSystemImageList.IsNull) return null;
		if (iconSize <= ShellImageSize.Small)
			return ImageList_GetIcon(hSystemImageList, shfi.iIcon, IMAGELISTDRAWFLAGS.ILD_TRANSPARENT);
		return GetSystemIcon(shfi.iIcon, iconSize);
	}

	/// <summary>Gets the system icon for and index and size.</summary>
	/// <param name="index">The index of the system icon to retrieve.</param>
	/// <param name="iconSize">Size of the icon.</param>
	/// <returns>An <see cref="SafeHICON"/> instance if found; otherwise <see langword="null"/>.</returns>
	public static SafeHICON GetSystemIcon(int index, ShellImageSize iconSize = ShellImageSize.Large) => GetSystemIconHandle(index, iconSize);

	/// <summary>Gets the system icon for and index and size.</summary>
	/// <param name="index">The index of the system icon to retrieve.</param>
	/// <param name="iconSize">Size of the icon.</param>
	/// <returns>An <see cref="SafeHICON"/> instance if found; otherwise <see langword="null"/>.</returns>
	public static SafeHICON GetSystemIconHandle(int index, ShellImageSize iconSize = ShellImageSize.Large)
	{
		SHGetImageList((SHIL)iconSize, out IImageList? il).ThrowIfFailed();
		return il!.GetIcon(index, IMAGELISTDRAWFLAGS.ILD_TRANSPARENT);
	}

	/// <summary>Given a pixel size, return the ShellImageSize value with the closest size.</summary>
	/// <param name="pixels">Size, in pixels, of the image list size to search for.</param>
	/// <returns>An image list size.</returns>
	public static ShellImageSize PixelsToSHIL(int pixels) => (ShellImageSize)ShellUtil.PixelsToSHIL(pixels);

	/// <summary>Given an image list size, return the related size, in pixels, of that size defined on the system.</summary>
	/// <param name="imageListSize">Size of the image list.</param>
	/// <returns>Pixel size of corresponding system value.</returns>
	public static int SHILtoPixels(ShellImageSize imageListSize) => ShellUtil.SHILToPixels((SHIL)imageListSize);
}