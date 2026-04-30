/* DOCS:
 *
 * REFERENCES
 *
 * <seealso cref="tajbender.Vanara\Windows.Forms\Extensions\IconExtension.cs"/>
 *
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vanara.PInvoke;

namespace Vanara.WinUI.Extensions;

#region Properties
/// <summary>Used to determine the size of the icon returned by various shell methods.</summary>
public enum IconSize
{
	/// <summary>
	/// The image size is normally 32x32 pixels. However, if the Use large icons option is selected from the Effects section of the Appearance tab in
	/// Display Properties, the image is 48x48 pixels.
	/// </summary>
	Large = Shell32.SHIL.SHIL_LARGE,
	/// <summary>The image is the Shell standard small icon size of 16x16, but the size can be customized by the user.</summary>
	Small = Shell32.SHIL.SHIL_SMALL,
	/// <summary>The image is the Shell standard extra-large icon size. This is typically 48x48, but the size can be customized by the user.</summary>
	ExtraLarge = Shell32.SHIL.SHIL_EXTRALARGE,
	/// <summary>Windows Vista and later. The image is normally 256x256 pixels.</summary>
	Jumbo = Shell32.SHIL.SHIL_JUMBO
}
#endregion

#region Embedded classes
public record SoftwareBitmapSource
{
	public IconSize IconSize;

	public SoftwareBitmapSource(IconSize iconSize) => IconSize = iconSize;

	public static Task<SoftwareBitmapSource> FromIcon(Icon icon)
	{
		return IconExtension.GetWinUi3BitmapSourceFromIcon(icon);
	}
}
#endregion

/// <summary>Extension methods for <see cref="Icon"/>.
/// This class replaces "Vanara.Windows.Forms.Extensions.IconExtension" for WinUI.
/// </summary>
public static class IconExtension
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="bitmapIcon"></param>
	/// <param name="iconSize"></param>
	/// <returns></returns>
	public static async Task<SoftwareBitmapSource> GetWinUi3BitmapSourceFromIcon(Icon bitmapIcon, IconSize iconSize)
	{
		ArgumentNullException.ThrowIfNull(bitmapIcon);

		return await GetWinUi3BitmapSourceFromGdiBitmap(bitmapIcon.ToBitmap());
	}

	    /* TODO: add to https://github.com/tajbender/tajbender.Vanara/blob/master/WinUI.Extensions/ShellImageSource.cs */

    /// <summary>
    /// Taken from <see href="https://stackoverflow.com/questions/76640972/convert-system-drawing-icon-to-microsoft-ui-xaml-imagesource"/>
    /// See also <see href="https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.media.imaging.bitmapimage?view=windows-app-sdk-1.6"/>, which can deal with .ico natively.
    /// </summary>
    /// <param name="bitmapIcon"></param>
    /// <returns></returns>
    public static async Task<SoftwareBitmapSource> GetWinUi3BitmapSourceFromIcon(Icon bitmapIcon)
    {
        ArgumentNullException.ThrowIfNull(bitmapIcon);

        return await GetWinUi3BitmapSourceFromGdiBitmap(bitmapIcon.ToBitmap());
    }

    /// <summary>
    /// Taken from <see href="https://stackoverflow.com/questions/76640972/convert-system-drawing-icon-to-microsoft-ui-xaml-imagesource"/>.
    /// See also <see href="https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.controls.image.source?view=windows-app-sdk-1.5#microsoft-ui-xaml-controls-image-source"/>.
    /// See also <see href="https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.media.imaging.bitmapimage?view=windows-app-sdk-1.6"/>, which can deal with .ico natively.
    /// </summary>
    /// <param name="gdiBitmap"></param>
    /// <returns></returns>
    public static async Task<SoftwareBitmapSource?> GetWinUi3BitmapSourceFromGdiBitmap(Bitmap gdiBitmap)
    {
        ArgumentNullException.ThrowIfNull(gdiBitmap);

        // get pixels as an array of bytes
        var data = gdiBitmap.LockBits(new System.Drawing.Rectangle(0, 0, gdiBitmap.Width, gdiBitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, gdiBitmap.PixelFormat);
        var bytes = new byte[data.Stride * data.Height];
        Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
        gdiBitmap.UnlockBits(data);

        // get WinRT SoftwareBitmap
        var softwareBitmap = new Windows.Graphics.Imaging.SoftwareBitmap(
            Windows.Graphics.Imaging.BitmapPixelFormat.Bgra8,
            gdiBitmap.Width,
            gdiBitmap.Height,
            Windows.Graphics.Imaging.BitmapAlphaMode.Premultiplied);
        softwareBitmap.CopyFromBuffer(bytes.AsBuffer());

        // build WinUI3 SoftwareBitmapSource
        var source = new SoftwareBitmapSource();
        await source.SetBitmapAsync(softwareBitmap);
        return source;
    }

}

