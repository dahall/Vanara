using System;
using System.Drawing;
using System.Windows.Forms;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Extensions
{
	public static partial class CursorExtension
	{
		public static Size GetSize(this Cursor cursor)
		{
			var size = Size.Empty;
			var info = new ICONINFO();
			GetIconInfo(new SafeHICON(cursor.Handle, false), info);
			if (info.hbmColor != IntPtr.Zero)
			{
				using (var bm = Image.FromHbitmap(info.hbmColor))
					size = bm.Size;
			}
			else if (info.hbmMask != IntPtr.Zero)
			{
				using (var bm = Image.FromHbitmap(info.hbmMask))
					size = new Size(bm.Width, bm.Height / 2);
			}
			return size;
		}

		public static Rectangle Bounds(this Cursor cursor)
		{
			using (var bmp = new Bitmap(cursor.Size.Width, cursor.Size.Height))
			{
				using (var g = Graphics.FromImage(bmp))
				{
					g.Clear(Color.Transparent);
					cursor.Draw(g, new Rectangle(Point.Empty, bmp.Size));

					var xMin = bmp.Width;
					var xMax = -1;
					var yMin = bmp.Height;
					var yMax = -1;

					for (var x = 0; x < bmp.Width; x++)
					{
						for (var y = 0; y < bmp.Height; y++)
						{
							if (bmp.GetPixel(x, y).A > 0)
							{
								xMin = Math.Min(xMin, x);
								xMax = Math.Max(xMax, x);
								yMin = Math.Min(yMin, y);
								yMax = Math.Max(yMax, y);
							}
						}
					}
					return new Rectangle(new Point(xMin, yMin), new Size((xMax - xMin) + 1, (yMax - yMin) + 1));
				}
			}
		}
	}
}
