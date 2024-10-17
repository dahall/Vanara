/*
 *
 *
 * Reference GitHub URL "tajbender.Vanara\Windows.Forms\Extensions\IconExtension.cs"
 *
 *
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanara.PInvoke;

namespace Vanara.WinUI.Extensions;

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

/// <summary>Extension methods for <see cref="Icon"/>.
/// This class replaces "Vanara.Windows.Forms.Extensions.IconExtension" for WinUI.
/// </summary>
public static class IconExtension
{
	//public static async Task<SoftwareBitmapSource> GetWinUi3BitmapSourceFromIcon(Icon bitmapIcon)
	//{
	//	ArgumentNullException.ThrowIfNull(bitmapIcon);

	//	return await GetWinUi3BitmapSourceFromGdiBitmap(bitmapIcon.ToBitmap());
	//}
}
