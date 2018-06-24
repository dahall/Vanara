using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Vanara.Extensions
{
	/// <summary>Used to define which corners of <see cref="Rectangle"/> are effected by an operation.</summary>
	[Flags]
	public enum Corners
	{
		/// <summary>No corners.</summary>
		None = 0,
		/// <summary>The top left corner.</summary>
		TopLeft = 1,
		/// <summary>The top right corner.</summary>
		TopRight = 2,
		/// <summary>The bottom left corner.</summary>
		BottomLeft = 4,
		/// <summary>The bottom right corner.</summary>
		BottomRight = 8,
		/// <summary>All corners.</summary>
		All = TopLeft | TopRight | BottomLeft | BottomRight
	}

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
		public static void AddRoundedRectangle(this GraphicsPath gp, RectangleF rect, SizeF arcSize, Corners corners = Corners.All)
		{
			if (arcSize == Size.Empty)
				gp.AddRectangle(rect);
			else
			{
				var r = new RectangleF(rect.Location, arcSize);
				if ((corners & Corners.TopLeft) > 0)
					gp.AddArc(r, 180, 90);
				else
					gp.AddLine(r.Location, r.Location);
				r.X = rect.Right - arcSize.Width;
				if ((corners & Corners.TopRight) > 0)
					gp.AddArc(r, 270, 90);
				else
					gp.AddLine(r.X + r.Width, r.Y, r.X + r.Width, r.Y);
				r.Y = rect.Bottom - arcSize.Height;
				if ((corners & Corners.BottomRight) > 0)
					gp.AddArc(r, 0, 90);
				else
					gp.AddLine(r.X + r.Width, r.Y + r.Height, r.X + r.Width, r.Y + r.Height);
				r.X = rect.Left;
				if ((corners & Corners.BottomLeft) > 0)
					gp.AddArc(r, 90, 90);
				else
					gp.AddLine(r.X, r.Y + r.Height, r.X, r.Y + r.Height);
			}
			gp.CloseFigure();
		}

		/// <summary>
		/// Builds a <see cref="TextFormatFlags"/> from a set of variables.
		/// </summary>
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

		/// <summary>A method to darken a color by a percentage of the difference between the color and Black.</summary>
		/// <param name="colorIn">The original color.</param>
		/// <param name="percent">The percentage by which to darken the original color.</param>
		/// <returns>
		/// The return color's Alpha value will be unchanged, but the RGB content will have been increased by the
		/// specified percentage. If percent is 100 then the returned Color will be Black with original Alpha.
		/// </returns>
		public static Color Darken(this Color colorIn, float percent)
		{
			if (percent < 0 || percent > 1.0)
				throw new ArgumentOutOfRangeException(nameof(percent));

			int a = colorIn.A;
			var r = colorIn.R - (int)(colorIn.R * percent);
			var g = colorIn.G - (int)(colorIn.G * percent);
			var b = colorIn.B - (int)(colorIn.B * percent);

			return Color.FromArgb(a, r, g, b);
		}

		/// <summary>
		/// Draws image with specified parameters. 
		/// </summary>
		/// <param name="graphics">Graphics on which to draw image</param>
		/// <param name="image">Image to be drawn</param>
		/// <param name="destination">Bounding rectangle for the image </param>
		/// <param name="source">Source rectangle of the image</param>
		/// <param name="alignment">Alignment specifying how image will be aligned against the bounding rectangle </param>
		/// <param name="transparency">Transparency for the image </param>
		/// <param name="grayscale">Value indicating if the image should be gray scaled</param>
		public static void DrawImage(this Graphics graphics, Image image, Rectangle destination, Rectangle source, ContentAlignment alignment = ContentAlignment.TopLeft, float transparency = 1.0f, bool grayscale = false)
		{
			if (graphics == null)
				throw new ArgumentNullException(nameof(graphics));
			if (image == null)
				throw new ArgumentNullException(nameof(image));
			if (destination.IsEmpty)
				throw new ArgumentNullException(nameof(destination));
			if (source.IsEmpty)
				throw new ArgumentNullException(nameof(source));
			if (transparency < 0 || transparency > 1.0f)
				throw new ArgumentNullException(nameof(transparency));

			var imageRectangle = GetRectangleFromAlignment(alignment, destination, source.Size);

			if (!imageRectangle.IsEmpty)
			{
				var colorMatrix = new ColorMatrix();
				if (grayscale)
				{
					colorMatrix.Matrix00 = 1 / 3f;
					colorMatrix.Matrix01 = 1 / 3f;
					colorMatrix.Matrix02 = 1 / 3f;
					colorMatrix.Matrix10 = 1 / 3f;
					colorMatrix.Matrix11 = 1 / 3f;
					colorMatrix.Matrix12 = 1 / 3f;
					colorMatrix.Matrix20 = 1 / 3f;
					colorMatrix.Matrix21 = 1 / 3f;
					colorMatrix.Matrix22 = 1 / 3f;
				}
				colorMatrix.Matrix33 = transparency; //Alpha factor 

				var imageAttributes = new ImageAttributes();
				imageAttributes.SetColorMatrix(colorMatrix);
				graphics.DrawImage(image, imageRectangle, source.X, source.Y, source.Width, source.Height, GraphicsUnit.Pixel, imageAttributes);
			}
		}

		/// <summary>
		/// A method used to draw standard Image and Text content with standard layout options.
		/// </summary>
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
			Rectangle tRect, iRect;
			CalcImageAndTextBounds(bounds, text, font, image, textAlignment, imageAlignment, textImageRelation, wordWrap, glowSize, ref format, out tRect, out iRect);

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

		/// <summary>
		/// A method used to calculate layout for Image and Text content with standard options.
		/// </summary>
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
		public static void CalcImageAndTextBounds(Rectangle bounds, string text, Font font, Image image, ContentAlignment textAlignment, ContentAlignment imageAlignment, TextImageRelation textImageRelation, bool wordWrap, int glowSize, ref TextFormatFlags format, out Rectangle actualTextBounds, out Rectangle actualImageBounds)
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
						: contentRectangle.Y + (contentRectangle.Height/2) - (actualTextSize.Height/2);
			}
			else if (textImageRelation == 0)
			{
				if ((int)textAlignment <= 4)
					actualTextBounds.Y = bounds.Top;
				else if ((int)textAlignment >= 256)
					actualTextBounds.Y = bounds.Bottom - actualTextSize.Height;
				else
					actualTextBounds.Y = bounds.Top + (bounds.Height/2 - actualTextSize.Height/2);

				if ((int)textAlignment%15 == 1)
					actualTextBounds.X = bounds.Left;
				else if ((int)textAlignment%15 == 2)
					actualTextBounds.X = bounds.Left + (bounds.Width/2 - actualTextSize.Width/2);
				else if ((int)textAlignment%15 == 4)
					actualTextBounds.X = bounds.Right - actualTextSize.Width;
			}
			else
			{
				actualTextBounds.Y = imageHasPreference ? contentRectangle.Bottom - actualTextSize.Height : contentRectangle.Y;
				actualTextBounds.X = (int)textAlignment%15 == 1
					? contentRectangle.X
					: (int)textAlignment%15 == 2
						? contentRectangle.X + contentRectangle.Width/2 - actualTextSize.Width/2
						: contentRectangle.Right - actualTextSize.Width;
			}
		}

		/// <summary>
		/// Gets the destination rectangle given a source rectangle, alignment and output size.
		/// </summary>
		/// <param name="alignment">The alignment of the new rectangle.</param>
		/// <param name="bounds">The initial bounding rectangle.</param>
		/// <param name="size">The size of the output rectangle.</param>
		/// <returns>A rectangle of <paramref name="size"/> fit into <paramref name="bounds"/> according to the alignment specified by <paramref name="alignment"/>.</returns>
		public static Rectangle GetRectangleFromAlignment(ContentAlignment alignment, Rectangle bounds, Size size)
		{
			if ((alignment & (ContentAlignment.BottomLeft | ContentAlignment.MiddleLeft | ContentAlignment.TopLeft)) != 0)
				bounds.Width = Math.Min(size.Width, bounds.Width);
			else if ((alignment & (ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight)) != 0)
				bounds.X = bounds.Width - Math.Min(size.Width, bounds.Width);
			else
				bounds.X = (bounds.Width - Math.Min(size.Width, bounds.Width)) / 2;

			if ((alignment & (ContentAlignment.TopCenter | ContentAlignment.TopLeft | ContentAlignment.TopRight)) != 0)
				bounds.Height = Math.Min(size.Height, bounds.Height);
			else if ((alignment & (ContentAlignment.BottomCenter | ContentAlignment.BottomLeft | ContentAlignment.BottomRight)) != 0)
				bounds.Y = bounds.Height - Math.Min(size.Height, bounds.Height);
			else
				bounds.Y = (bounds.Height - Math.Min(size.Height, bounds.Height)) / 2;

			return bounds;
		}

		/// <summary>
		/// Gets a transparent bitmap given two non-transparent bitmaps drawn against a white and black background respectively.
		/// </summary>
		/// <param name="whiteBmp">A non-transparent bitmap drawn against a white background.</param>
		/// <param name="blackBmp">A non-transparent bitmap drawn against a black background.</param>
		/// <returns>A 32-bit bitmap with an alpha channel values that are set based on white and black bitmap interpolation.</returns>
		/// <exception cref="ArgumentException">Bitmaps must be of the same size and their pixel format must be Format32bppArgb.</exception>
		public static Bitmap GetTransparentBitmap(Bitmap whiteBmp, Bitmap blackBmp)
		{
			if (whiteBmp.Size != blackBmp.Size && whiteBmp.PixelFormat != blackBmp.PixelFormat && whiteBmp.PixelFormat != PixelFormat.Format32bppArgb)
				throw new ArgumentException("Bitmaps must be of the same size and their pixel format must be Format32bppArgb.");

			var bmp = new Bitmap(whiteBmp.Width, whiteBmp.Height, whiteBmp.PixelFormat);
			using (SmartBitmapLock oVals = new SmartBitmapLock(bmp), wVals = new SmartBitmapLock(whiteBmp), bVals = new SmartBitmapLock(blackBmp))
			{

				for (var i = 0; i < oVals.Length; i++)
				{
					Color b = bVals[i], w = wVals[i];
					if (w == Color.White && b == Color.Black)
					{
						oVals[i] = Color.FromArgb(0);
					}
					else if (w != b)
					{
						double oc, op;
						if (b == Color.Black)
						{
							oVals[i] = Color.FromArgb(Bound(255 - w.R, 0, 255), 0, 0, 0);
							continue;
						}
						if (w.R != b.R && b.R != 0)
						{
							oc = CalcOrigColor(w.R, b.R);
							op = b.R / oc;
						}
						else if (w.G != b.G && b.G != 0)
						{
							oc = CalcOrigColor(w.G, b.G);
							op = b.G / oc;
						}
						else
						{
							oc = CalcOrigColor(w.B, b.B);
							op = b.B / oc;
						}
						oVals[i] =
							Color.FromArgb(Bound((int)Math.Round(op * 255.0), 0, 255), (int)Math.Round(b.R / op), (int)Math.Round(b.G / op),
								(int)Math.Round(b.B / op));
					}
					else
						oVals[i] = bVals[i];
				}
			}
			return bmp;

			int Bound(int value, int min, int max) => Math.Max(Math.Min(value, max), min);
			double CalcOrigColor(byte w, byte b) => 255.0 * b / (255.0 - w + b);
		}

		/// <summary>A method to lighten a color by a percentage of the difference between the color and Black.</summary>
		/// <param name="colorIn">The original color.</param>
		/// <param name="percent">The percentage by which to lighten the original color.</param>
		/// <returns>
		/// The return color's Alpha value will be unchanged, but the RGB content will have been decreased by the
		/// specified percentage. If percent is 100 then the returned Color will be White with original Alpha.
		/// </returns>
		public static Color Lighten(this Color colorIn, float percent)
		{
			if (percent < 0 || percent > 1.0)
				throw new ArgumentOutOfRangeException(nameof(percent));

		    int a = colorIn.A;
			var r = colorIn.R + (int)((255f - colorIn.R) * percent);
			var g = colorIn.G + (int)((255f - colorIn.G) * percent);
			var b = colorIn.B + (int)((255f - colorIn.B) * percent);

			return Color.FromArgb(a, r, g, b);
		}
		/// <summary>
		/// Resize the image to the specified width and height.
		/// </summary>
		/// <param name="image">The image to resize.</param>
		/// <param name="width">The width to resize to.</param>
		/// <param name="height">The height to resize to.</param>
		/// <param name="mode">The interpolation mode to use in the resampling.</param>
		/// <returns>The resized image.</returns>
		public static Bitmap Resize(this Image image, int width, int height, InterpolationMode mode = InterpolationMode.HighQualityBicubic)
		{
			var destImage = new Bitmap(width, height);
			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = mode;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphics.SmoothingMode = SmoothingMode.HighQuality;

				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}
			return destImage;
		}

		/// <summary>A self-disposing LockBits class for Bitmaps.</summary>
		/// <seealso cref="System.IDisposable"/>
		public class SmartBitmapLock : IDisposable, IEnumerable<Color>
		{
			private static readonly int intSz = Marshal.SizeOf(typeof(int));
			private readonly BitmapData bd;
			private readonly Bitmap bmp;

			/// <summary>Initializes a new instance of the <see cref="SmartBitmapLock"/> class.</summary>
			/// <param name="bitmap">The bitmap to use. The bitmap must have a 32bpp pixel format.</param>
			public SmartBitmapLock(Bitmap bitmap)
			{
				if (bitmap == null) throw new ArgumentNullException(nameof(bitmap));
				if (Image.GetPixelFormatSize(bitmap.PixelFormat) != 32) throw new ArgumentException(@"Bitmap pixels must be 32bpp.", nameof(bitmap));
				bmp = bitmap;
				bd = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size), ImageLockMode.ReadWrite, bmp.PixelFormat);
			}

			/// <summary>Finalizes an instance of the <see cref="SmartBitmapLock"/> class.</summary>
			~SmartBitmapLock() { Dispose(); }

			/// <summary>Gets the number of bytes.</summary>
			public int ByteLength => Math.Abs(bd.Stride) * bmp.Height;

			/// <summary>Gets the number of values available from the indexer.</summary>
			public int Length => ByteLength / intSz;

			//private int[] Scan0 => pixels ?? (pixels = bd.Scan0.ToIEnum<int>(Length).ToArray());

			/// <summary>Gets or sets the <see cref="Color"/> at the specified row and column.</summary>
			/// <value>The <see cref="Color"/>.</value>
			/// <param name="row">The row.</param>
			/// <param name="col">The column.</param>
			/// <returns>The Color value at the specified row and column.</returns>
			public Color this[int row, int col]
			{
				get
				{
					if (row < 0 || row >= bd.Height) throw new ArgumentOutOfRangeException(nameof(row));
					if (col < 0 || col >= bd.Width) throw new ArgumentOutOfRangeException(nameof(col));
					if (bd.Stride < 0) row = bd.Height - row - 1;
					return Color.FromArgb(Marshal.ReadInt32(bd.Scan0, row * col * intSz));
				}
				set
				{
					if (row < 0 || row >= bd.Height) throw new ArgumentOutOfRangeException(nameof(row));
					if (col < 0 || col >= bd.Width) throw new ArgumentOutOfRangeException(nameof(col));
					if (bd.Stride < 0) row = bd.Height - row - 1;
					Marshal.WriteInt32(bd.Scan0, row * col * intSz, value.ToArgb());
				}
			}

			/// <summary>Gets or sets the <see cref="Color"/> at the specified index.</summary>
			/// <value>The <see cref="Color"/>.</value>
			/// <param name="index">The pixel index if laid out linearly from beginning to end.</param>
			/// <returns>The Color value at the specified index.</returns>
			public Color this[int index]
			{
				get
				{
					if (index < 0 || index >= bd.Height * bd.Width) throw new ArgumentOutOfRangeException(nameof(index));
					return Color.FromArgb(Marshal.ReadInt32(bd.Scan0, index * intSz));
				}
				set
				{
					if (index < 0 || index >= bd.Height * bd.Width) throw new ArgumentOutOfRangeException(nameof(index));
					Marshal.WriteInt32(bd.Scan0, index * intSz, value.ToArgb());
				}
			}

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			public void Dispose()
			{
				//if (lockMode != ImageLockMode.ReadOnly)
				//	Marshal.Copy(pixels, 0, bd.Scan0, Length);
				bmp.UnlockBits(bd);
				GC.SuppressFinalize(this);
			}

			/// <summary>Creates a new bitmap from the current bits.</summary>
			/// <returns>A new <see cref="Bitmap"/></returns>
			public Bitmap ToBitmap() => new Bitmap(bmp.Width, bmp.Height, bd.Stride, PixelFormat.Format32bppArgb, bd.Scan0).Clone() as Bitmap;

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString()
			{
				var sb = new StringBuilder();
				using (var tw = new StringWriter(sb))
				{
					for (var i = 0; i < Length / bmp.Width; i++)
					{
						for (var j = 0; j < bmp.Width; j++)
							tw.Write($"0x{this[i,j].ToArgb():X}\t");
						tw.WriteLine();
					}
					tw.Close();
				}
				return sb.ToString();
			}

			/// <summary>Returns an enumerator that iterates through the collection.</summary>
			/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator{Color}"/> that can be used to iterate through the collection.</returns>
			public IEnumerator<Color> GetEnumerator() => new Enumertor(this);

			/// <summary>Returns an enumerator that iterates through a collection.</summary>
			/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

			private class Enumertor : IEnumerator<Color>
			{
				private SmartBitmapLock bmpLock;
				private int idx = -1;
				internal Enumertor(SmartBitmapLock bmp) { bmpLock = bmp; }
				public void Dispose() { bmpLock = null; }
				public bool MoveNext() { return idx < bmpLock.Length - 1 && ++idx >= 0; }
				public void Reset() { idx = -1; }
				public Color Current => idx >= 0 && idx < bmpLock.Length ? bmpLock[idx] : Color.Empty;
				object IEnumerator.Current => Current;
			}
		}
	}
}