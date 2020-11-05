using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Vanara.Extensions
{
	/// <summary>Extensions to <c>Graphics</c> related classes.</summary>
	public static partial class GraphicsExtension
	{
		/// <summary>
		/// Appends a rounded rectangle path to the current figure.
		/// </summary>
		/// <param name="gp">The <see cref="GraphicsPath"/> instance.</param>
		/// <param name="rect">The bounding <see cref="Rectangle"/> for the rounded rectangle.</param>
		/// <param name="arcSize">Size of the arc for each corner.</param>
		/// <param name="corners">Specifies which corners to curve. The default is <c>All</c>.</param>
		[Obsolete("Please use matching function in Vanara.Extensions.GdiExtension.")]
		public static void AddRoundedRectangle(this GraphicsPath gp, RectangleF rect, SizeF arcSize, Corners corners = Corners.All) =>
			GdiExtension.AddRoundedRectangle(gp, rect, arcSize, corners);

		/// <summary>Builds a <see cref="TextFormatFlags"/> from a set of variables.</summary>
		/// <param name="textAlign">The <see cref="ContentAlignment"/> of the text.</param>
		/// <param name="singleLine">if set to <c>true</c> if text should be in a single line.</param>
		/// <param name="showEllipsis">if set to <c>true</c> if line is trimmed with an ellipsis.</param>
		/// <param name="useMnemonic">if set to <c>true</c> to display a mnemonic.</param>
		/// <param name="rtl">The <see cref="RightToLeft"/> value.</param>
		/// <param name="showKeyboardCues">if set to <c>true</c> show keyboard cues.</param>
		/// <returns>The resulting <see cref="TextFormatFlags"/>.</returns>
		public static TextFormatFlags BuildTextFormatFlags(ContentAlignment textAlign, bool singleLine, bool showEllipsis, bool useMnemonic, RightToLeft rtl, bool showKeyboardCues)
		{
			var tff = TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.WordBreak;
			var align = (int)textAlign;
			if ((align & 0x007) != 0) // Top
				tff |= TextFormatFlags.Top;
			else if ((align & 0x070) != 0) // Middle
				tff |= TextFormatFlags.VerticalCenter;
			else // Bottom
				tff |= TextFormatFlags.Bottom;
			if ((align & 0x111) != 0) // Left
				tff |= TextFormatFlags.Left;
			else if ((align & 0x222) != 0) // Center
				tff |= TextFormatFlags.HorizontalCenter;
			else // Right
				tff |= TextFormatFlags.Right;
			if (singleLine) tff |= TextFormatFlags.SingleLine;
			if (showEllipsis) tff |= TextFormatFlags.EndEllipsis | TextFormatFlags.WordEllipsis;
			if (rtl == RightToLeft.Yes) tff |= TextFormatFlags.RightToLeft;
			if (!useMnemonic) return tff | TextFormatFlags.NoPrefix;
			if (!showKeyboardCues) tff |= TextFormatFlags.HidePrefix;
			return tff;
		}

		/// <summary>A method used to calculate layout for Image and Text content with standard options.</summary>
		/// <param name="bounds">The bounding Rectangle within which to draw.</param>
		/// <param name="text">The text to draw.</param>
		/// <param name="font">The font used to draw text.</param>
		/// <param name="image">The image to draw (this may be null).</param>
		/// <param name="textAlignment">The vertical and horizontal alignment of the text.</param>
		/// <param name="imageAlignment">The vertical and horizontal alignment of the image.</param>
		/// <param name="textImageRelation">The placement of the image and text relative to each other.</param>
		/// <param name="wordWrap">set true if text should wrap.</param>
		/// <param name="glowSize">The size in pixels of the glow around text.</param>
		/// <param name="format">The format.</param>
		/// <param name="actualTextBounds">The actual text bounds.</param>
		/// <param name="actualImageBounds">The actual image bounds.</param>
		public static void CalcImageAndTextBounds(Rectangle bounds, string text, Font font, Image image, ContentAlignment textAlignment,
			ContentAlignment imageAlignment, TextImageRelation textImageRelation, bool wordWrap, int glowSize,
			ref TextFormatFlags format, out Rectangle actualTextBounds, out Rectangle actualImageBounds)
		{
			var horizontalRelation = (int)textImageRelation > 2;
			var imageHasPreference = textImageRelation == TextImageRelation.ImageBeforeText || textImageRelation == TextImageRelation.ImageAboveText;

			var preferredAlignmentValue = imageHasPreference ? (int)imageAlignment : (int)textAlignment;

			var contentRectangle = bounds;

			format |= TextFormatFlags.TextBoxControl | (wordWrap ? TextFormatFlags.WordBreak : TextFormatFlags.SingleLine);

			// Get ImageSize
			var imageSize = image?.Size ?? Size.Empty;

			// Get AvailableTextSize
			var availableTextSize = horizontalRelation ?
				new Size(bounds.Width - imageSize.Width, bounds.Height) :
				new Size(bounds.Width, bounds.Height - imageSize.Height);

			// Get ActualTextSize
			var actualTextSize = text?.Length > 0 ? TextRenderer.MeasureText(text, font, availableTextSize, format) : Size.Empty;

			// Get ContentRectangle based upon TextImageRelation
			if (textImageRelation != 0)
			{
				// Get ContentSize
				var contentSize = horizontalRelation ?
					new Size(imageSize.Width + actualTextSize.Width, Math.Max(imageSize.Height, availableTextSize.Height)) :
					new Size(Math.Max(imageSize.Width, availableTextSize.Width), imageSize.Height + actualTextSize.Height);

				// Get ContentLocation
				var contentLocation = bounds.Location;
				if (horizontalRelation)
				{
					if (preferredAlignmentValue % 15 == 1)
						contentLocation.X = bounds.Left;
					else if (preferredAlignmentValue % 15 == 2)
						contentLocation.X = bounds.Left + (bounds.Width / 2 - contentSize.Width / 2);
					else if (preferredAlignmentValue % 15 == 4)
						contentLocation.X = bounds.Right - contentSize.Width;
				}
				else
				{
					if (preferredAlignmentValue <= 4)
						contentLocation.Y = bounds.Top;
					else if (preferredAlignmentValue >= 256)
						contentLocation.Y = bounds.Bottom - contentSize.Height;
					else
						contentLocation.Y = bounds.Top + (bounds.Height / 2 - contentSize.Height / 2);
				}

				contentRectangle = new Rectangle(contentLocation, contentSize);
			}

			actualImageBounds = Rectangle.Empty;
			if (image != null)
			{
				// Get ActualImageBounds
				actualImageBounds = new Rectangle(bounds.Location, imageSize);
				if (horizontalRelation)
				{
					actualImageBounds.X = imageHasPreference ? contentRectangle.X : contentRectangle.Right - imageSize.Width;
					actualImageBounds.Y = (int)imageAlignment <= 4 ?
						contentRectangle.Y : (int)imageAlignment >= 256 ?
						contentRectangle.Bottom - imageSize.Height :
						contentRectangle.Y + contentRectangle.Height / 2 - imageSize.Height / 2;
				}
				else if (textImageRelation == 0)
				{
					if ((int)imageAlignment <= 4)
						actualImageBounds.Y = bounds.Top;
					else if ((int)imageAlignment >= 256)
						actualImageBounds.Y = bounds.Bottom - imageSize.Height;
					else
						actualImageBounds.Y = bounds.Top + (bounds.Height / 2 - imageSize.Height / 2);

					if ((int)imageAlignment % 15 == 1)
						actualImageBounds.X = bounds.Left;
					else if ((int)imageAlignment % 15 == 2)
						actualImageBounds.X = bounds.Left + (bounds.Width / 2 - imageSize.Width / 2);
					else if ((int)imageAlignment % 15 == 4)
						actualImageBounds.X = bounds.Right - imageSize.Width;
				}
				else
				{
					actualImageBounds.Y = imageHasPreference ? contentRectangle.Y : contentRectangle.Bottom - imageSize.Height;
					actualImageBounds.X = (int)imageAlignment % 15 == 1 ?
						contentRectangle.X : (int)imageAlignment % 15 == 2 ?
						contentRectangle.X + contentRectangle.Width / 2 - imageSize.Width / 2 :
						contentRectangle.Right - imageSize.Width;
				}
			}

			// Get ActualTextBounds
			actualTextBounds = Rectangle.Empty;
			if (!(text?.Length > 0)) return;

			actualTextBounds = new Rectangle(Point.Empty, actualTextSize);
			if (horizontalRelation)
			{
				actualTextBounds.X = imageHasPreference ? contentRectangle.Right - actualTextSize.Width : contentRectangle.X;
				actualTextBounds.Y = (int)textAlignment <= 4
					? contentRectangle.Y
					: (int)textAlignment >= 256
						? contentRectangle.Bottom - actualTextSize.Height
						: contentRectangle.Y + (contentRectangle.Height / 2) - (actualTextSize.Height / 2);
			}
			else if (textImageRelation == 0)
			{
				if ((int)textAlignment <= 4)
					actualTextBounds.Y = bounds.Top;
				else if ((int)textAlignment >= 256)
					actualTextBounds.Y = bounds.Bottom - actualTextSize.Height;
				else
					actualTextBounds.Y = bounds.Top + (bounds.Height / 2 - actualTextSize.Height / 2);

				if ((int)textAlignment % 15 == 1)
					actualTextBounds.X = bounds.Left;
				else if ((int)textAlignment % 15 == 2)
					actualTextBounds.X = bounds.Left + (bounds.Width / 2 - actualTextSize.Width / 2);
				else if ((int)textAlignment % 15 == 4)
					actualTextBounds.X = bounds.Right - actualTextSize.Width;
			}
			else
			{
				actualTextBounds.Y = imageHasPreference ? contentRectangle.Bottom - actualTextSize.Height : contentRectangle.Y;
				actualTextBounds.X = (int)textAlignment % 15 == 1
					? contentRectangle.X
					: (int)textAlignment % 15 == 2
						? contentRectangle.X + contentRectangle.Width / 2 - actualTextSize.Width / 2
						: contentRectangle.Right - actualTextSize.Width;
			}
		}

		/// <summary>A method to darken a color by a percentage of the difference between the color and Black.</summary>
		/// <param name="colorIn">The original color.</param>
		/// <param name="percent">The percentage by which to darken the original color.</param>
		/// <returns>
		/// The return color's Alpha value will be unchanged, but the RGB content will have been increased by the
		/// specified percentage. If percent is 100 then the returned Color will be Black with original Alpha.
		/// </returns>
		[Obsolete("Please use matching function in Vanara.Extensions.GdiExtension.")]
		public static Color Darken(this Color colorIn, float percent) => GdiExtension.Darken(colorIn, percent);

		/// <summary>Draws image with specified parameters.</summary>
		/// <param name="graphics">Graphics on which to draw image</param>
		/// <param name="image">Image to be drawn</param>
		/// <param name="destination">Bounding rectangle for the image</param>
		/// <param name="source">Source rectangle of the image</param>
		/// <param name="alignment">Alignment specifying how image will be aligned against the bounding rectangle</param>
		/// <param name="transparency">Transparency for the image</param>
		/// <param name="grayscale">Value indicating if the image should be gray scaled</param>
		[Obsolete("Please use matching function in Vanara.Extensions.GdiExtension.")]
		public static void DrawImage(this Graphics graphics, Image image, Rectangle destination, Rectangle source, ContentAlignment alignment = ContentAlignment.TopLeft, float transparency = 1.0f, bool grayscale = false) =>
			GdiExtension.DrawImage(graphics, image, destination, source, alignment, transparency, grayscale);

		/// <summary>A method used to draw standard Image and Text content with standard layout options.</summary>
		/// <param name="graphics">The Graphics object on which to draw.</param>
		/// <param name="bounds">The bounding Rectangle within which to draw.</param>
		/// <param name="text">The text to draw.</param>
		/// <param name="font">The font used to draw text.</param>
		/// <param name="image">The image to draw (this may be null).</param>
		/// <param name="textAlignment">The vertical and horizontal alignment of the text.</param>
		/// <param name="imageAlignment">The vertical and horizontal alignment of the image.</param>
		/// <param name="textImageRelation">The placement of the image and text relative to each other.</param>
		/// <param name="textColor">The color to draw the text.</param>
		/// <param name="wordWrap">set true if text should wrap.</param>
		/// <param name="glowSize">The size in pixels of the glow around text.</param>
		/// <param name="enabled">Set false to draw image grayed out.</param>
		/// <param name="format">The <see cref="TextFormatFlags"/> used to format the text.</param>
		public static void DrawImageAndText(this Graphics graphics, Rectangle bounds, string text, Font font, Image image,
			ContentAlignment textAlignment, ContentAlignment imageAlignment, TextImageRelation textImageRelation, Color textColor,
			bool wordWrap, int glowSize, bool enabled = true, TextFormatFlags format = TextFormatFlags.TextBoxControl)
		{
			CalcImageAndTextBounds(bounds, text, font, image, textAlignment, imageAlignment, textImageRelation, wordWrap, glowSize, ref format, out Rectangle tRect, out Rectangle iRect);

			// Draw Image
			if (image != null)
			{
				if (enabled)
					graphics.DrawImage(image, iRect);
				else
					ControlPaint.DrawImageDisabled(graphics, image, iRect.X, iRect.Y, Color.Transparent);
			}

			// Draw text
			if (text?.Length > 0)
				TextRenderer.DrawText(graphics, text, font, tRect, textColor, format);
		}

		/// <param name="alignment">The alignment of the new rectangle.</param>
		/// <param name="bounds">The initial bounding rectangle.</param>
		/// <param name="size">The size of the output rectangle.</param>
		/// <returns>
		/// A rectangle of <paramref name="size"/> fit into <paramref name="bounds"/> according to the alignment specified by <paramref name="alignment"/>.
		/// </returns>
		[Obsolete("Please use matching function in Vanara.Extensions.GdiExtension.")]
		public static Rectangle GetRectangleFromAlignment(ContentAlignment alignment, Rectangle bounds, Size size) =>
			GdiExtension.GetRectangleFromAlignment(alignment, bounds, size);

		/// <summary>Gets a transparent bitmap given two non-transparent bitmaps drawn against a white and black background respectively.</summary>
		/// <param name="whiteBmp">A non-transparent bitmap drawn against a white background.</param>
		/// <param name="blackBmp">A non-transparent bitmap drawn against a black background.</param>
		/// <returns>A 32-bit bitmap with an alpha channel values that are set based on white and black bitmap interpolation.</returns>
		/// <exception cref="ArgumentException">Bitmaps must be of the same size and their pixel format must be Format32bppArgb.</exception>
		[Obsolete("Please use matching function in Vanara.Extensions.GdiExtension.")]
		public static Bitmap GetTransparentBitmap(Bitmap whiteBmp, Bitmap blackBmp) =>
			GdiExtension.GetTransparentBitmap(whiteBmp, blackBmp);

		/// <summary>A method to lighten a color by a percentage of the difference between the color and Black.</summary>
		/// <param name="colorIn">The original color.</param>
		/// <param name="percent">The percentage by which to lighten the original color.</param>
		/// <returns>
		/// The return color's Alpha value will be unchanged, but the RGB content will have been decreased by the specified percentage. If
		/// percent is 100 then the returned Color will be White with original Alpha.
		/// </returns>
		[Obsolete("Please use matching function in Vanara.Extensions.GdiExtension.")]
		public static Color Lighten(this Color colorIn, float percent) =>
			GdiExtension.Lighten(colorIn, percent);

		/// <summary>Resize the image to the specified width and height.</summary>
		/// <param name="image">The image to resize.</param>
		/// <param name="width">The width to resize to.</param>
		/// <param name="height">The height to resize to.</param>
		/// <param name="mode">The interpolation mode to use in the resampling.</param>
		/// <returns>The resized image.</returns>
		[Obsolete("Please use matching function in Vanara.Extensions.GdiExtension.")]
		public static Bitmap Resize(this Image image, int width, int height, InterpolationMode mode = InterpolationMode.HighQualityBicubic) =>
			GdiExtension.Resize(image, width, height, mode);
	}
}