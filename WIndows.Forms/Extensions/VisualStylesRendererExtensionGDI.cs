using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.UxTheme;

namespace Vanara.Extensions
{
	/// <summary>
	/// Extension methods for <see cref="VisualStyleRenderer"/> for glass effects and extended method functionality. Also provides GetFont2
	/// and GetMargins2 methods that corrects base library's non-functioning methods.
	/// </summary>
	public static partial class VisualStylesRendererExtension
	{
		private static readonly Dictionary<long, Bitmap> bmpCache = new Dictionary<long, Bitmap>();

		private delegate void DrawWrapperMethod(HDC hdc);

		/// <summary>
		/// Draws the background image of the current visual style element within the specified bounding rectangle and optionally clipped to
		/// the specified clipping rectangle.
		/// </summary>
		/// <param name="rnd">The <see cref="VisualStyleRenderer"/> instance.</param>
		/// <param name="dc">The <see cref="IDeviceContext"/> used to draw the background image.</param>
		/// <param name="bounds">A <see cref="Rectangle"/> in which the background image is drawn.</param>
		/// <param name="clipRectangle">A <see cref="Rectangle"/> that defines a clipping rectangle for the drawing operation.</param>
		/// <param name="rightToLeft">If set to <c>true</c> flip the image for right to left layout.</param>
		public static void DrawBackground(this VisualStyleRenderer rnd, IDeviceContext dc, Rectangle bounds, Rectangle? clipRectangle = null, bool rightToLeft = false)
		{
			/*var h = rnd.GetHashCode();
			Bitmap bmp;
			if (!bmpCache.TryGetValue(h, out bmp))
				bmpCache.Add(h, bmp = GraphicsExtension.GetTransparentBitmap(GetBackgroundBitmap(rnd, Color.White), GetBackgroundBitmap(rnd, Color.Black)));
			if (rightToLeft)
				bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
			if (clipRectangle != null) dc.SetClip(clipRectangle.Value);
			using (var attr = new ImageAttributes())
			{
				dc.CompositingMode = CompositingMode.SourceOver;
				dc.CompositingQuality = CompositingQuality.HighQuality;
				dc.InterpolationMode = InterpolationMode.HighQualityBicubic;
				dc.PixelOffsetMode = PixelOffsetMode.HighQuality;
				attr.SetWrapMode(WrapMode.TileFlipXY);
				dc.DrawImage(bmp, bounds, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
			}*/
			rnd.DrawBackground(dc, bounds, clipRectangle ?? bounds);
		}

		/// <summary>
		/// Draws the background image of the current visual style element onto a glass background within the specified bounding rectangle
		/// and optionally clipped to the specified clipping rectangle.
		/// </summary>
		/// <param name="rnd">The <see cref="VisualStyleRenderer"/> instance.</param>
		/// <param name="dc">The <see cref="IDeviceContext"/> used to draw the background image.</param>
		/// <param name="bounds">A <see cref="Rectangle"/> in which the background image is drawn.</param>
		/// <param name="clipRectangle">A <see cref="Rectangle"/> that defines a clipping rectangle for the drawing operation.</param>
		/// <param name="rightToLeft">If set to <c>true</c> flip the image for right to left layout.</param>
		public static void DrawGlassBackground(this VisualStyleRenderer rnd, IDeviceContext dc, Rectangle bounds, Rectangle? clipRectangle = null, bool rightToLeft = false)
		{
			var ht = new SafeHTHEME(rnd.Handle, false);
			dc.DrawViaDIB(bounds, (memoryHdc, b) =>
				{
					var rBounds = new RECT(bounds);
					//var opts = new DrawThemeBackgroundOptions(clipRectangle);
					// Draw background
					var oldLayout = DCLayout.GDI_ERROR;
					if (rightToLeft)
						if ((oldLayout = SetLayout(memoryHdc, DCLayout.LAYOUT_RTL)) == DCLayout.GDI_ERROR)
							throw new NotSupportedException("Unable to change graphics layout to RTL.");
					DrawThemeBackground(ht, memoryHdc, rnd.Part, rnd.State, rBounds, clipRectangle);
					if (oldLayout != DCLayout.GDI_ERROR)
						SetLayout(memoryHdc, oldLayout);
				}
				);
		}

		/// <summary>Draws the image from the specified <paramref name="imageList"/> within the specified bounds on a glass background.</summary>
		/// <param name="rnd">The <see cref="VisualStyleRenderer"/> instance.</param>
		/// <param name="g">The <see cref="Graphics"/> used to draw the image.</param>
		/// <param name="bounds">A <see cref="Rectangle"/> in which the image is drawn.</param>
		/// <param name="imageList">An <see cref="ImageList"/> that contains the <see cref="Image"/> to draw.</param>
		/// <param name="imageIndex">The index of the <see cref="Image"/> within <paramref name="imageList"/> to draw.</param>
		public static void DrawGlassImage(this VisualStyleRenderer rnd, IDeviceContext g, Rectangle bounds, ImageList imageList, int imageIndex)
		{
			var ht = new SafeHTHEME(rnd.Handle, false);
			g.DrawViaDIB(bounds, (memoryHdc, b) =>
				DrawThemeIcon(ht, memoryHdc, rnd.Part, rnd.State, bounds, imageList.Handle, imageIndex));
		}

		/// <summary>Draws the specified image within the specified bounds on a glass background.</summary>
		/// <param name="rnd">The <see cref="VisualStyleRenderer"/> instance.</param>
		/// <param name="g">The <see cref="Graphics"/> used to draw the image.</param>
		/// <param name="bounds">A <see cref="Rectangle"/> in which the image is drawn.</param>
		/// <param name="image">An <see cref="ImageList"/> that contains the <see cref="Image"/> to draw.</param>
		/// <param name="disabled">
		/// if set to <c>true</c> draws the image in a disabled state using the <see cref="ControlPaint.DrawImageDisabled"/> method.
		/// </param>
		public static void DrawGlassImage(this VisualStyleRenderer rnd, IDeviceContext g, Rectangle bounds, Image image, bool disabled = false)
		{
			g.DrawViaDIB(bounds, (memoryHdc, b) =>
				{
					using (var mg = Graphics.FromHdc(memoryHdc.DangerousGetHandle()))
					{
						if (disabled)
							ControlPaint.DrawImageDisabled(mg, image, bounds.X, bounds.Y, Color.Transparent);
						else
							mg.DrawImage(image, bounds);
					}
				}
				);
		}

		/// <summary>
		/// Draws glowing text in the specified bounding rectangle with the option of overriding text color and applying other text formatting.
		/// </summary>
		/// <param name="rnd">The <see cref="VisualStyleRenderer"/> instance.</param>
		/// <param name="dc">The <see cref="IDeviceContext"/> used to draw the text.</param>
		/// <param name="bounds">A <see cref="Rectangle"/> in which the text is drawn.</param>
		/// <param name="text">The text to draw.</param>
		/// <param name="font">Optional font override.</param>
		/// <param name="color">Optionally, the color to draw text in overriding the default color for the theme.</param>
		/// <param name="flags">A bitwise combination of the <see cref="TextFormatFlags"/> values.</param>
		/// <param name="glowSize">The size of the glow.</param>
		public static void DrawGlowingText(this VisualStyleRenderer rnd, IDeviceContext dc, Rectangle bounds, string text, Font font, Color? color, TextFormatFlags flags = TextFormatFlags.Default, int glowSize = 10)
		{
			var ht = new SafeHTHEME(rnd.Handle, false);
			dc.DrawViaDIB(bounds, (memoryHdc, b) =>
				{
					// Create and select font
					using (new GdiObjectContext(memoryHdc, new SafeHFONT(font?.ToHfont() ?? IntPtr.Zero)))
					{
						// Draw glowing text
						var dttOpts = new DTTOPTS(null) { GlowSize = glowSize, AntiAliasedAlpha = true };
						if (color != null) dttOpts.TextColor = color.Value;
						var textBounds = new RECT(4, 0, bounds.Right - bounds.Left, bounds.Bottom - bounds.Top);
						DrawThemeTextEx(ht, memoryHdc, rnd.Part, rnd.State, text, text.Length, FromTFF(flags), ref textBounds, dttOpts);
					}
				}
				);
		}

		/// <summary>Draws text in the specified bounding rectangle with the option of applying other text formatting.</summary>
		/// <param name="rnd">The <see cref="VisualStyleRenderer"/> instance.</param>
		/// <param name="dc">The <see cref="IDeviceContext"/> used to draw the text.</param>
		/// <param name="bounds">A <see cref="Rectangle"/> in which the text is drawn.</param>
		/// <param name="text">The text to draw.</param>
		/// <param name="flags">A bitwise combination of the <see cref="TextFormatFlags"/> values.</param>
		/// <param name="options">The <see cref="DTTOPTS"/> .</param>
		public static void DrawText(this VisualStyleRenderer rnd, IDeviceContext dc, ref Rectangle bounds, string text, TextFormatFlags flags, ref DTTOPTS options)
		{
			var rc = new RECT(bounds);
			var ht = new SafeHTHEME(rnd.Handle, false);
			using (var hdc = new SafeHDC(dc))
				DrawThemeTextEx(ht, hdc, rnd.Part, rnd.State, text, text.Length, FromTFF(flags), ref rc, options);
			bounds = rc;
		}

		/// <summary>
		/// Gets the background image of the current visual style element within the specified background color. If <paramref name="states"/>
		/// is set, the resulting image will contain each of the state images side by side.
		/// </summary>
		/// <param name="rnd">The <see cref="VisualStyleRenderer"/> instance.</param>
		/// <param name="clr">The background color. This color cannot have an alpha channel.</param>
		/// <param name="states">The optional list of states to render side by side.</param>
		/// <returns>The background image.</returns>
		public static Bitmap GetBackgroundBitmap(this VisualStyleRenderer rnd, Color clr, int[] states = null)
		{
			const int wh = 200;
			if (rnd == null) throw new ArgumentNullException(nameof(rnd));
			rnd.SetParameters(rnd.Class, rnd.Part, 0);
			if (states == null || states.Length == 0) states = new[] { rnd.State };
			var i = states.Length;

			// Get image size
			Size imgSz;
			using (var sg = Graphics.FromHwnd(IntPtr.Zero))
				imgSz = rnd.GetPartSize(sg, new Rectangle(0, 0, wh, wh), ThemeSizeType.Draw);
			if (imgSz.Width == 0 || imgSz.Height == 0)
				imgSz = new Size(rnd.GetInteger(IntegerProperty.Width), rnd.GetInteger(IntegerProperty.Height));
			if (imgSz.Width == 0 || imgSz.Height == 0)
			{
				using (var sg = Graphics.FromHwnd(IntPtr.Zero))
					imgSz = MaxSize(rnd.GetPartSize(sg, new Rectangle(0, 0, wh, wh), ThemeSizeType.Minimum), imgSz);
			}

			var bounds = new Rectangle(0, 0, imgSz.Width * i, imgSz.Height);

			// Draw each background linearly down the bitmap
			using (var memoryHdc = SafeHDC.ScreenCompatibleDCHandle)
			{
				// Create a device-independent bitmap and select it into our DC
				var info = new BITMAPINFO(bounds.Width, -bounds.Height);
				using (memoryHdc.SelectObject(CreateDIBSection(HDC.NULL, ref info, DIBColorMode.DIB_RGB_COLORS, out var ppv, IntPtr.Zero, 0)))
				{
					using (var memoryGraphics = (Graphics)memoryHdc)
					{
						// Setup graphics
						memoryGraphics.CompositingMode = CompositingMode.SourceOver;
						memoryGraphics.CompositingQuality = CompositingQuality.HighQuality;
						memoryGraphics.SmoothingMode = SmoothingMode.HighQuality;
						memoryGraphics.Clear(clr);

						// Draw each background linearly down the bitmap
						var rect = new Rectangle(0, 0, imgSz.Width, imgSz.Height);
						foreach (var state in states)
						{
							rnd.SetParameters(rnd.Class, rnd.Part, state);
							rnd.DrawBackground(memoryGraphics, rect);
							rect.X += imgSz.Width;
						}
					}

					// Copy DIB to Bitmap
					var bmp = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
					using (var primaryHdc = new SafeHDC(Graphics.FromImage(bmp)))
						BitBlt(primaryHdc, bounds.Left, bounds.Top, bounds.Width, bounds.Height, memoryHdc, 0, 0, RasterOperationMode.SRCCOPY);
					return bmp;
				}
			}
		}

		/// <summary>Returns the value of the specified font property for the current visual style element.</summary>
		/// <param name="rnd">The <see cref="VisualStyleRenderer"/> instance.</param>
		/// <param name="dc">The <see cref="IDeviceContext"/> used to draw the text.</param>
		/// <param name="defaultValue">A value to return if the system has no font defined for this <see cref="VisualStyleRenderer"/> instance.</param>
		/// <returns>
		/// A <see cref="Font"/> that contains the value of the property specified by the prop parameter for the current visual style element.
		/// </returns>
		public static Font GetFont2(this VisualStyleRenderer rnd, IDeviceContext dc = null, Font defaultValue = null)
		{
			using (var hdc = new SafeHDC(dc))
			{
				return 0 != GetThemeFont(new SafeHTHEME(rnd.Handle, false), hdc, rnd.Part, rnd.State, 210, out var f)
					? defaultValue : Font.FromLogFont(f);
			}
		}

		private static DrawTextFlags FromTFF(TextFormatFlags tff) => (DrawTextFlags)(int)tff;

		private static long GetHashCode(this VisualStyleRenderer r) => (long)r.Class.GetHashCode() << 32 | ((uint)r.Part << 16 | (ushort)r.State);

		private static Size MaxSize(Size sz1, Size sz2) => new Size(Math.Max(sz1.Width, sz2.Width), Math.Max(sz1.Height, sz2.Height));
	}
}