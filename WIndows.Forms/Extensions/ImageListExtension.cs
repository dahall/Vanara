using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.Extensions
{
	public static partial class ImageListExtension
	{
		private static Dictionary<ImageList, List<int>> imageListOverlays = new Dictionary<ImageList, List<int>>();

		/// <summary>
		/// Draws the image indicated by the given index on the specified <see cref="Graphics"/> at the specified location.
		/// </summary>
		/// <param name="imageList">The image list.</param>
		/// <param name="g">The <see cref="Graphics"/> to draw on.</param>
		/// <param name="bounds">The bounds in which to draw the image. Set width and height to 0 to draw image at full size.</param>
		/// <param name="index">The index of the image in the ImageList to draw.</param>
		/// <param name="bgColor">The background color of the image. This parameter can be a <see cref="Color"/> value or <see cref="ImageListDrawColor.None"/> 
		/// so the image is drawn transparently or <see cref="ImageListDrawColor.Default"/> so the image is drawn using the background color of the image list.</param>
		/// <param name="fgColor">The foreground color of the image. This parameter can be a <see cref="Color"/> value or <see cref="ImageListDrawColor.None"/> 
		/// so the image is blended with the color of the destination device context or <see cref="ImageListDrawColor.Default"/> so the image is drawn using the system highlight color as the foreground color.</param>
		/// <param name="style">The drawing style.</param>
		/// <param name="overlayImageIndex">Optional index of an overlay image.</param>
		/// <exception cref="System.ComponentModel.Win32Exception">Unable to draw the image with defined parameters.</exception>
		public static void Draw(this ImageList imageList, Graphics g, Rectangle bounds, int index, ImageListDrawColor bgColor, ImageListDrawColor fgColor, IMAGELISTDRAWFLAGS style = IMAGELISTDRAWFLAGS.ILD_NORMAL, int overlayImageIndex = 0)
		{
			if (index < 0 || index >= imageList.Images.Count)
				throw new ArgumentOutOfRangeException(nameof(index));
			if (overlayImageIndex < 0 || overlayImageIndex > imageList.GetOverlayCount())
				throw new ArgumentOutOfRangeException(nameof(overlayImageIndex));
			using (var hg = new SafeDCHandle(g))
			{
				var p = new IMAGELISTDRAWPARAMS(hg.DangerousGetHandle(), bounds, index, bgColor, style | (IMAGELISTDRAWFLAGS)(overlayImageIndex << 8)) { rgbFg = fgColor };
				imageList.GetIImageList().Draw(p);
			}
		}

		/// <summary>Gets an <see cref="IImageList"/> object for the <see cref="ImageList"/> instance.</summary>
		/// <param name="imageList">The image list.</param>
		/// <returns>An <see cref="IImageList"/> object.</returns>
		public static IImageList GetIImageList(this ImageList imageList) => new SafeImageListHandle(imageList.Handle, false).Interface;

		private static int GetOverlayCount(this ImageList imageList) => imageListOverlays.TryGetValue(imageList, out List<int> vals) ? vals.Count : 0;

		/// <summary>
		/// Assigns the image at the specified index as an overlay and returns is overlay index.
		/// </summary>
		/// <param name="imageList">The image list.</param>
		/// <param name="imageIndex">Index of the image within the ImageList.</param>
		/// <returns>The 1 based index of the overlay.</returns>
		/// <exception cref="System.ArgumentOutOfRangeException">The imageIndex is not in the current list.</exception>
		/// <exception cref="System.ComponentModel.Win32Exception">The image cannot be added as an overlay.</exception>
		public static int SetImageIndexAsOverlay(this ImageList imageList, int imageIndex)
		{
			if (imageIndex < 0 || imageIndex >= imageList.Images.Count)
				throw new ArgumentOutOfRangeException(nameof(imageIndex));
			if (!imageListOverlays.TryGetValue(imageList, out List<int> vals))
			{
				imageList.RecreateHandle += imageList_RecreateHandle;
				imageListOverlays.Add(imageList, vals = new List<int>(15));
			}
			vals.Add(imageIndex);
			var overlayIndex = vals.Count;
			imageList.GetIImageList().SetOverlayImage(imageIndex, overlayIndex);
			return overlayIndex;
		}

		/// <summary>
		/// Adds the specified image to the ImageList as an overlay, using the specified color to determine transparency.
		/// </summary>
		/// <param name="imageList">The image list.</param>
		/// <param name="value">A Bitmap of the image to add to the list.</param>
		/// <param name="transparentColor">The color to use as the transparent color within the Bitmap.</param>
		/// <returns>The 1 based index of the overlay.</returns>
		/// <exception cref="System.ComponentModel.Win32Exception">The image cannot be added as an overlay.</exception>
		public static int AddOverlay(this ImageList imageList, Image value, Color transparentColor)
		{
			var idx = imageList.Images.Add(value, transparentColor);
			return SetImageIndexAsOverlay(imageList, idx);
		}

		private static void imageList_RecreateHandle(object sender, EventArgs e)
		{
			if (!(sender is ImageList il) || !imageListOverlays.TryGetValue(il, out List<int> vals)) return;
			var iil = il.GetIImageList();
			for (var i = 0; i < vals.Count; i++)
				iil.SetOverlayImage(vals[i], i + 1);
		}
	}
}