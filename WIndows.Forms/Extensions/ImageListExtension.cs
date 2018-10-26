using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.Extensions
{
	/// <summary>Extension methods for <see cref="ImageList"/>.</summary>
	public static partial class ImageListExtension
	{
		private static Dictionary<ImageList, List<int>> imageListOverlays = new Dictionary<ImageList, List<int>>();

		/// <summary>Adds the specified image to the ImageList as an overlay, using the specified color to determine transparency.</summary>
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

		/// <summary>Draws the image indicated by the given index on the specified <see cref="Graphics"/> at the specified location.</summary>
		/// <param name="imageList">The image list.</param>
		/// <param name="g">The <see cref="Graphics"/> to draw on.</param>
		/// <param name="bounds">The bounds in which to draw the image. Set width and height to 0 to draw image at full size.</param>
		/// <param name="index">The index of the image in the ImageList to draw.</param>
		/// <param name="bgColor">
		/// The background color of the image. This parameter can be a <see cref="Color"/> value or <see cref="COLORREF.None"/> so the image is drawn
		/// transparently or <see cref="COLORREF.Default"/> so the image is drawn using the background color of the image list.
		/// </param>
		/// <param name="fgColor">
		/// The foreground color of the image. This parameter can be a <see cref="Color"/> value or <see cref="COLORREF.None"/> so the image is blended
		/// with the color of the destination device context or <see cref="COLORREF.Default"/> so the image is drawn using the system highlight color
		/// as the foreground color.
		/// </param>
		/// <param name="style">The drawing style.</param>
		/// <param name="overlayImageIndex">Optional index of an overlay image.</param>
		/// <exception cref="System.ComponentModel.Win32Exception">Unable to draw the image with defined parameters.</exception>
		public static void Draw(this ImageList imageList, Graphics g, Rectangle bounds, int index, COLORREF bgColor, COLORREF fgColor, IMAGELISTDRAWFLAGS style = IMAGELISTDRAWFLAGS.ILD_NORMAL, int overlayImageIndex = 0)
		{
			if (index < 0 || index >= imageList.Images.Count)
				throw new ArgumentOutOfRangeException(nameof(index));
			if (overlayImageIndex < 0 || overlayImageIndex > imageList.GetOverlayCount())
				throw new ArgumentOutOfRangeException(nameof(overlayImageIndex));
			using (var hg = new SafeHDC(g))
			{
				var p = new IMAGELISTDRAWPARAMS(hg, bounds, index, bgColor, style | (IMAGELISTDRAWFLAGS)INDEXTOOVERLAYMASK(overlayImageIndex)) { rgbFg = fgColor };
				imageList.GetIImageList().Draw(p);
			}
		}

		/// <summary>Gets the current background color for an image list.</summary>
		/// <param name="imageList">The image list.</param>
		/// <returns>The background color.</returns>
		public static Color GetBackgroundColor(this ImageList imageList) => imageList.GetIImageList().GetBkColor();

		/// <summary>Gets an <see cref="IImageList"/> object for the <see cref="ImageList"/> instance.</summary>
		/// <param name="imageList">The image list.</param>
		/// <returns>An <see cref="IImageList"/> object.</returns>
		public static IImageList GetIImageList(this ImageList imageList) => new SafeHIMAGELIST(imageList.Handle, false).Interface;

		/// <summary>Creates an <see cref="ImageList"/> from a handle.
		/// <note type="warning">This is a super hack involving a lot of reflection against internal structures that can change. Use with caution!</note></summary>
		/// <param name="himl">The SafeImageListHandle value.</param>
		/// <returns>An <c>ImageList</c> instance hosting the supplied handle.</returns>
		/// <exception cref="PlatformNotSupportedException" />
		public static ImageList ToImageList(this HIMAGELIST himl)
		{
			// Duplicate handle and get IImageList for it
			var dhiml = ImageList_Duplicate(himl);
			var iil = dhiml.Interface;
			// Get internal handle class
			var nilfi = typeof(ImageList).GetField("nativeImageList", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
			if (nilfi == null) throw new PlatformNotSupportedException();
			var nil = nilfi.FieldType;
			// Create a new instance with the handle param
			var nili = nil.Assembly.CreateInstance(nil.FullName, false, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, new object[] { dhiml }, null, null);
			// Create a new ImageList and initialize with settings from handle
			var il = new ImageList();
			nilfi.SetValue(il, nili);
			var depthfi = typeof(ImageList).GetField("colorDepth", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
			var szfi = typeof(ImageList).GetField("imageSize", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
			if (depthfi == null || szfi == null) throw new PlatformNotSupportedException();
			var add1 = false;
			if (iil.GetImageCount() == 0)
			{
				add1 = true;
				iil.SetImageCount(1);
			}
			var bmp = Image.FromHbitmap((IntPtr)iil.GetImageInfo(0).hbmImage);
			var depth = (ColorDepth)(((uint)bmp.PixelFormat & 0x3C00) >> 8);
			if (add1) iil.SetImageCount(0);
			depthfi.SetValue(il, depth);
			var sz = iil.GetIconSize();
			szfi.SetValue(il, sz);
			return il;
		}

		/// <summary>Creates a new image by combining two existing images.</summary>
		/// <param name="il1">The image list that contains the first image.</param>
		/// <param name="idx1">The index of the first existing image.</param>
		/// <param name="il2">The image list that contains the second image.</param>
		/// <param name="idx2">The index of the second existing image.</param>
		/// <param name="offset">The offset of the second image relative to the first image.</param>
		/// <returns>A merged image.</returns>
		public static Icon MergeImage(this ImageList il1, int idx1, ImageList il2, int idx2, Point offset = default)
		{
			var il3 = il1.GetIImageList().Merge(idx1, il2.GetIImageList(), idx2, offset.X, offset.Y, typeof(IImageList).GUID);
			return il3.GetIcon(0, IMAGELISTDRAWFLAGS.ILD_TRANSPARENT | IMAGELISTDRAWFLAGS.ILD_PRESERVEALPHA).ToIcon();
		}

		/// <summary>Gets the current background color for an image list.</summary>
		/// <param name="imageList">The image list.</param>
		/// <param name="bkColor">The background color to set.</param>
		public static void SetBackgroundColor(this ImageList imageList, Color bkColor) =>
			imageList.GetIImageList().SetBkColor(bkColor, out var _);

		/// <summary>Assigns the image at the specified index as an overlay and returns is overlay index.</summary>
		/// <param name="imageList">The image list.</param>
		/// <param name="imageIndex">Index of the image within the ImageList.</param>
		/// <returns>The 1 based index of the overlay.</returns>
		/// <exception cref="System.ArgumentOutOfRangeException">The imageIndex is not in the current list.</exception>
		/// <exception cref="System.ComponentModel.Win32Exception">The image cannot be added as an overlay.</exception>
		public static int SetImageIndexAsOverlay(this ImageList imageList, int imageIndex)
		{
			if (imageIndex < 0 || imageIndex >= imageList.Images.Count)
				throw new ArgumentOutOfRangeException(nameof(imageIndex));
			if (!imageListOverlays.TryGetValue(imageList, out var vals))
			{
				imageList.RecreateHandle += ImageList_RecreateHandle;
				imageListOverlays.Add(imageList, vals = new List<int>(15));
			}
			vals.Add(imageIndex);
			var overlayIndex = vals.Count;
			imageList.GetIImageList().SetOverlayImage(imageIndex, overlayIndex);
			return overlayIndex;
		}

		private static int GetOverlayCount(this ImageList imageList) => imageListOverlays.TryGetValue(imageList, out var vals) ? vals.Count : 0;

		private static void ImageList_RecreateHandle(object sender, EventArgs e)
		{
			if (!(sender is ImageList il) || !imageListOverlays.TryGetValue(il, out var vals)) return;
			var iil = il.GetIImageList();
			for (var i = 0; i < vals.Count; i++)
				iil.SetOverlayImage(vals[i], i + 1);
		}
	}
}