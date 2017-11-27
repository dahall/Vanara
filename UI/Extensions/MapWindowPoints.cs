using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

namespace Vanara.Extensions
{
	public static partial class MapPointExtension
	{
		public static Point MapPointToClient(this IWin32Window ctrl, Point pt) => MapPoint(null, pt, ctrl);

		public static Point MapPoint(this IWin32Window ctrl, Point pt, IWin32Window newWin = null)
		{
			MapWindowPoints(GetHandleRef(ctrl), GetHandleRef(newWin), ref pt, 1);
			return pt;
		}

		public static Rectangle MapRectangle(this IWin32Window ctrl, Rectangle rectangle, IWin32Window newWin = null)
		{
			RECT ir = rectangle;
			MapWindowPoints(GetHandleRef(ctrl), GetHandleRef(newWin), ref ir, 2);
			return ir;
		}

		public static void MapPoints(this IWin32Window ctrl, Point[] points, IWin32Window newWin = null)
		{
			if (points == null) throw new ArgumentNullException(nameof(points));
			MapWindowPoints(GetHandleRef(ctrl), GetHandleRef(newWin), points, points.Length);
			/*Point[] pts = new Point[points.Length];
			points.CopyTo(pts, 0);
			for (int i = 0; i < pts.Length; i++)
				MapWindowPoints(GetHandleRef(ctrl), GetHandleRef(newWin), ref pts[i], 1);
			return pts;*/
		}

		private static HandleRef GetHandleRef(IWin32Window ctrl) => new HandleRef(ctrl, ctrl?.Handle ?? IntPtr.Zero);
	}
}
 