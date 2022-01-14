using System;
using System.Drawing;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

namespace Vanara.Extensions
{
	/// <summary>Extension methods for windows to process points in the coordinate space.</summary>
	public static partial class MapPointExtension
	{
		/// <summary>
		/// The MapPoint method converts (maps) a point from a coordinate space relative to one window to a coordinate space relative to
		/// another window.
		/// </summary>
		/// <param name="ctrl">The control.</param>
		/// <param name="pt">The pt.</param>
		/// <param name="newWin">The new win.</param>
		/// <returns></returns>
		public static POINT MapPoint(this IWin32Window ctrl, POINT pt, IWin32Window newWin = null)
		{
			MapWindowPoints(GetHandle(ctrl), GetHandle(newWin), ref pt, 1);
			return pt;
		}

		/// <summary>
		/// The MapPoint method converts (maps) a set of points from a coordinate space relative to one window to a coordinate space
		/// relative to another window.
		/// </summary>
		/// <param name="ctrl">The control.</param>
		/// <param name="points">The points.</param>
		/// <param name="newWin">The new win.</param>
		/// <exception cref="System.ArgumentNullException">points</exception>
		public static void MapPoints(this IWin32Window ctrl, POINT[] points, IWin32Window newWin = null)
		{
			if (points == null) throw new ArgumentNullException(nameof(points));
			MapWindowPoints(GetHandle(ctrl), GetHandle(newWin), points, points.Length);
			/*POINT[] pts = new POINT[points.Length];
			points.CopyTo(pts, 0);
			for (int i = 0; i < pts.Length; i++)
				MapWindowPoints(GetHandleRef(ctrl), GetHandleRef(newWin), ref pts[i], 1);
			return pts;*/
		}

		/// <summary>The MapPoint method converts (maps) a point from a coordinate space relative to one window to the desktop.</summary>
		/// <param name="ctrl">The control.</param>
		/// <param name="pt">The pt.</param>
		/// <returns></returns>
		public static POINT MapPointToClient(this IWin32Window ctrl, POINT pt) => MapPoint(null, pt, ctrl);

		/// <summary>
		/// The MapPoint method converts (maps) a rectangle from a coordinate space relative to one window to a coordinate space relative to
		/// another window.
		/// </summary>
		/// <param name="ctrl">The control.</param>
		/// <param name="rectangle">The rectangle.</param>
		/// <param name="newWin">The new win.</param>
		/// <returns></returns>
		public static Rectangle MapRectangle(this IWin32Window ctrl, Rectangle rectangle, IWin32Window newWin = null)
		{
			RECT ir = rectangle;
			MapWindowPoints(GetHandle(ctrl), GetHandle(newWin), ref ir, 2);
			return ir;
		}

		private static HWND GetHandle(IWin32Window ctrl) => new HWND(ctrl?.Handle ?? IntPtr.Zero);
	}
}