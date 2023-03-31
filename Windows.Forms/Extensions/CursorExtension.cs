using System;
using System.Drawing;
using System.Windows.Forms;
using static Vanara.PInvoke.User32;

namespace Vanara.Extensions;

/// <summary>Extension methods for <see cref="Cursor"/>.</summary>
public static partial class CursorExtension
{
	/// <summary>Gets the bounds in desktop coordinates of the specified cursor.</summary>
	/// <param name="cursor">The cursor.</param>
	/// <returns></returns>
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

	/// <summary>Gets the size of the cursor.</summary>
	/// <param name="cursor">The cursor.</param>
	/// <returns>The size, in pixels.</returns>
	public static Size GetSize(this Cursor cursor)
	{
		var size = Size.Empty;
		var info = new ICONINFO();
		GetIconInfo(new SafeHICON(cursor.Handle, false), info);
		if (!info.hbmColor.IsNull)
		{
			using (var bm = Image.FromHbitmap((IntPtr)info.hbmColor))
				size = bm.Size;
		}
		else if (!info.hbmMask.IsNull)
		{
			using (var bm = Image.FromHbitmap((IntPtr)info.hbmMask))
				size = new Size(bm.Width, bm.Height / 2);
		}
		return size;
	}
}