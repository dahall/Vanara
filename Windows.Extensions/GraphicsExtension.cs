using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Vanara.PInvoke;

namespace Vanara.Extensions;

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
public static partial class GdiExtension
{
	/// <summary>Appends a rounded rectangle path to the current figure.</summary>
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

	/// <summary>Draws image with specified parameters.</summary>
	/// <param name="graphics">Graphics on which to draw image</param>
	/// <param name="image">Image to be drawn</param>
	/// <param name="destination">Bounding rectangle for the image</param>
	/// <param name="source">Source rectangle of the image</param>
	/// <param name="alignment">Alignment specifying how image will be aligned against the bounding rectangle</param>
	/// <param name="transparency">Transparency for the image</param>
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

	/// <summary>Gets the destination rectangle given a source rectangle, alignment and output size.</summary>
	/// <param name="alignment">The alignment of the new rectangle.</param>
	/// <param name="bounds">The initial bounding rectangle.</param>
	/// <param name="size">The size of the output rectangle.</param>
	/// <returns>
	/// A rectangle of <paramref name="size"/> fit into <paramref name="bounds"/> according to the alignment specified by <paramref name="alignment"/>.
	/// </returns>
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

	/// <summary>Gets a transparent bitmap given two non-transparent bitmaps drawn against a white and black background respectively.</summary>
	/// <param name="whiteBmp">A non-transparent bitmap drawn against a white background.</param>
	/// <param name="blackBmp">A non-transparent bitmap drawn against a black background.</param>
	/// <returns>A 32-bit bitmap with an alpha channel values that are set based on white and black bitmap interpolation.</returns>
	/// <exception cref="ArgumentException">Bitmaps must be of the same size and their pixel format must be Format32bppArgb.</exception>
	public static Bitmap GetTransparentBitmap(Bitmap whiteBmp, Bitmap blackBmp)
	{
		if (whiteBmp.Size != blackBmp.Size && whiteBmp.PixelFormat != blackBmp.PixelFormat && whiteBmp.PixelFormat != PixelFormat.Format32bppArgb)
			throw new ArgumentException("Bitmaps must be of the same size and their pixel format must be Format32bppArgb.");

		var bmp = new Bitmap(whiteBmp.Width, whiteBmp.Height, whiteBmp.PixelFormat);
		using (SmartBitmapLock oVals = new(bmp), wVals = new(whiteBmp), bVals = new(blackBmp))
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
						oVals[i] = Color.FromArgb(255 - w.R, 0, 0, 0);
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
						Color.FromArgb(RoundBound(op * 255.0), RoundBound(b.R / op), RoundBound(b.G / op), RoundBound(b.B / op));
				}
				else
					oVals[i] = bVals[i];
			}
		}
		return bmp;

		static int RoundBound(double v) => (int)Math.Round(Math.Min(255.0, Math.Max(0.0, v)));
		static double CalcOrigColor(byte w, byte b) => 255.0 * b / (255.0 - w + b);
	}

	/// <summary>Resize the image to the specified width and height.</summary>
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

			using var wrapMode = new ImageAttributes();
			wrapMode.SetWrapMode(WrapMode.TileFlipXY);
			graphics.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
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
			bd = bmp.LockBits(new Rectangle(POINT.Empty, bmp.Size), ImageLockMode.ReadWrite, bmp.PixelFormat);
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

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator{Color}"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<Color> GetEnumerator() => new Enumertor(this);

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
						tw.Write($"0x{this[i, j].ToArgb():X}\t");
					tw.WriteLine();
				}
				tw.Close();
			}
			return sb.ToString();
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private class Enumertor : IEnumerator<Color>
		{
			private SmartBitmapLock bmpLock;
			private int idx = -1;

			internal Enumertor(SmartBitmapLock bmp) => bmpLock = bmp;

			public Color Current => idx >= 0 && idx < bmpLock.Length ? bmpLock[idx] : Color.Empty;

			object IEnumerator.Current => Current;

			public void Dispose()
			{
				bmpLock = null;
			}

			public bool MoveNext()
			{
				return idx < bmpLock.Length - 1 && ++idx >= 0;
			}

			public void Reset()
			{
				idx = -1;
			}
		}
	}
}