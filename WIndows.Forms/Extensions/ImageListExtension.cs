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
		/// Draw color with options for <see cref="Draw"/> method.
		/// </summary>
		public struct ImageListDrawColor
		{
			private uint value;
			public ImageListDrawColor(Color color) { value = (uint)ColorTranslator.ToWin32(color); }
			private ImageListDrawColor(uint val) { value = val; }
			public static ImageListDrawColor None = new ImageListDrawColor(CLR_NONE);
			public static ImageListDrawColor Default = new ImageListDrawColor(CLR_DEFAULT);
			public static implicit operator uint (ImageListDrawColor c) => c.value;
			public static implicit operator ImageListDrawColor(Color c) => new ImageListDrawColor(c);
		}

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
				if (!ImageList_DrawEx(new HandleRef(imageList, imageList.Handle), index, hg, bounds.X, bounds.Y, bounds.Width, bounds.Height, bgColor, fgColor, style | (IMAGELISTDRAWFLAGS)(overlayImageIndex << 8)))
					throw new Win32Exception();
		}

		private static int GetOverlayCount(this ImageList imageList)
		{
			List<int> vals;
			if (!imageListOverlays.TryGetValue(imageList, out vals))
				return 0;
			return vals.Count;
		}

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
			List<int> vals;
			if (!imageListOverlays.TryGetValue(imageList, out vals))
			{
				imageList.RecreateHandle += imageList_RecreateHandle;
				imageListOverlays.Add(imageList, vals = new List<int>(15));
			}
			vals.Add(imageIndex);
			var overlayIndex = vals.Count;
			if (!ImageList_SetOverlayImage(new HandleRef(imageList, imageList.Handle), imageIndex, overlayIndex))
				throw new Win32Exception();
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
			List<int> vals;
			var il = sender as ImageList;
			if (il == null || !imageListOverlays.TryGetValue(il, out vals)) return;
			var hIl = new HandleRef(il, il.Handle);
			for (var i = 0; i < vals.Count; i++)
				ImageList_SetOverlayImage(hIl, vals[i], i + 1);
		}
	}
}