using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>
		/// <para>Indicates the screen orientation preference for a desktop app process.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ne-winuser-orientation_preference typedef enum ORIENTATION_PREFERENCE
		// { ORIENTATION_PREFERENCE_NONE, ORIENTATION_PREFERENCE_LANDSCAPE, ORIENTATION_PREFERENCE_PORTRAIT,
		// ORIENTATION_PREFERENCE_LANDSCAPE_FLIPPED, ORIENTATION_PREFERENCE_PORTRAIT_FLIPPED } ;
		[PInvokeData("winuser.h", MSDNShortId = "7399DD9F-F993-40CC-B9C6-20673D39C069")]
		[Flags]
		public enum ORIENTATION_PREFERENCE
		{
			/// <summary>The process has no device orientation preferences. The system may choose any available setting.</summary>
			ORIENTATION_PREFERENCE_NONE = 0x00,

			/// <summary>The process represents a desktop app that can be used in landscape mode.</summary>
			ORIENTATION_PREFERENCE_LANDSCAPE = 0x01,

			/// <summary>The process represents a desktop app that can be used in portrait mode.</summary>
			ORIENTATION_PREFERENCE_PORTRAIT = 0x02,

			/// <summary>The process represents a desktop app that can be used in flipped landscape mode.</summary>
			ORIENTATION_PREFERENCE_LANDSCAPE_FLIPPED = 0x04,

			/// <summary>The process represents a desktop app that can be used in flipped portrait mode.</summary>
			ORIENTATION_PREFERENCE_PORTRAIT_FLIPPED = 0x08,
		}

		/// <summary>The <c>ClientToScreen</c> function converts the client-area coordinates of a specified point to screen coordinates.</summary>
		/// <param name="hWnd">A handle to the window whose client area is used for the conversion.</param>
		/// <param name="lpPoint">
		/// A pointer to a POINT structure that contains the client coordinates to be converted. The new screen coordinates are copied into
		/// this structure if the function succeeds.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>ClientToScreen</c> function replaces the client-area coordinates in the POINT structure with the screen coordinates. The
		/// screen coordinates are relative to the upper-left corner of the screen. Note, a screen-coordinate point that is above the
		/// window's client area has a negative y-coordinate. Similarly, a screen coordinate to the left of a client area has a negative x-coordinate.
		/// </para>
		/// <para>All coordinates are device coordinates.</para>
		/// <para>Examples</para>
		/// <para>For an example, see "Drawing Lines with the Mouse" in Using Mouse Input.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-clienttoscreen BOOL ClientToScreen( HWND hWnd, LPPOINT
		// lpPoint );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "3b1e2699-7f5f-444d-9072-f2ca7c8fa511")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ClientToScreen(HWND hWnd, ref POINT lpPoint);

		/// <summary>Retrieves the screen auto-rotation preferences for the current process.</summary>
		/// <param name="pOrientation">
		/// Pointer to a location in memory that will receive the current orientation preference setting for the calling process.
		/// </param>
		/// <returns>TRUE if the method succeeds, otherwise FALSE.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdisplayautorotationpreferences BOOL
		// GetDisplayAutoRotationPreferences( ORIENTATION_PREFERENCE *pOrientation );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "48D609CC-3E2B-4E0E-9566-FE02853DD831")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetDisplayAutoRotationPreferences(out ORIENTATION_PREFERENCE pOrientation);

		/// <summary>
		/// The MapWindowPoints function converts (maps) a set of points from a coordinate space relative to one window to a coordinate space
		/// relative to another window.
		/// </summary>
		/// <param name="hWndFrom">
		/// A handle to the window from which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are presumed to be
		/// in screen coordinates.
		/// </param>
		/// <param name="hWndTo">
		/// A handle to the window to which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are converted to
		/// screen coordinates.
		/// </param>
		/// <param name="lpPoints">
		/// A pointer to an array of POINT structures that contain the set of points to be converted. The points are in device units. This
		/// parameter can also point to a RECT structure, in which case the cPoints parameter should be set to 2.
		/// </param>
		/// <param name="cPoints">The number of POINT structures in the array pointed to by the lpPoints parameter.</param>
		/// <returns>
		/// If the function succeeds, the low-order word of the return value is the number of pixels added to the horizontal coordinate of
		/// each source point in order to compute the horizontal coordinate of each destination point. (In addition to that, if precisely one
		/// of hWndFrom and hWndTo is mirrored, then each resulting horizontal coordinate is multiplied by -1.) The high-order word is the
		/// number of pixels added to the vertical coordinate of each source point in order to compute the vertical coordinate of each
		/// destination point.
		/// <para>
		/// If the function fails, the return value is zero. Call SetLastError prior to calling this method to differentiate an error return
		/// value from a legitimate "0" return value.
		/// </para>
		/// </returns>
		[PInvokeData("WinUser.h", MSDNShortId = "")]
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		public static extern int MapWindowPoints(HWND hWndFrom, HWND hWndTo, ref RECT lpPoints, uint cPoints = 2);

		/// <summary>
		/// The MapWindowPoints function converts (maps) a set of points from a coordinate space relative to one window to a coordinate space
		/// relative to another window.
		/// </summary>
		/// <param name="hWndFrom">
		/// A handle to the window from which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are presumed to be
		/// in screen coordinates.
		/// </param>
		/// <param name="hWndTo">
		/// A handle to the window to which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are converted to
		/// screen coordinates.
		/// </param>
		/// <param name="lpPoints">
		/// A pointer to an array of POINT structures that contain the set of points to be converted. The points are in device units. This
		/// parameter can also point to a RECT structure, in which case the cPoints parameter should be set to 2.
		/// </param>
		/// <param name="cPoints">The number of POINT structures in the array pointed to by the lpPoints parameter.</param>
		/// <returns>
		/// If the function succeeds, the low-order word of the return value is the number of pixels added to the horizontal coordinate of
		/// each source point in order to compute the horizontal coordinate of each destination point. (In addition to that, if precisely one
		/// of hWndFrom and hWndTo is mirrored, then each resulting horizontal coordinate is multiplied by -1.) The high-order word is the
		/// number of pixels added to the vertical coordinate of each source point in order to compute the vertical coordinate of each
		/// destination point.
		/// <para>
		/// If the function fails, the return value is zero. Call SetLastError prior to calling this method to differentiate an error return
		/// value from a legitimate "0" return value.
		/// </para>
		/// </returns>
		[PInvokeData("WinUser.h", MSDNShortId = "")]
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		public static extern int MapWindowPoints(HWND hWndFrom, HWND hWndTo, ref POINT lpPoints, uint cPoints = 1);

		/// <summary>
		/// The MapWindowPoints function converts (maps) a set of points from a coordinate space relative to one window to a coordinate space
		/// relative to another window.
		/// </summary>
		/// <param name="hWndFrom">
		/// A handle to the window from which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are presumed to be
		/// in screen coordinates.
		/// </param>
		/// <param name="hWndTo">
		/// A handle to the window to which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are converted to
		/// screen coordinates.
		/// </param>
		/// <param name="lpPoints">
		/// A pointer to an array of POINT structures that contain the set of points to be converted. The points are in device units. This
		/// parameter can also point to a RECT structure, in which case the cPoints parameter should be set to 2.
		/// </param>
		/// <param name="cPoints">The number of POINT structures in the array pointed to by the lpPoints parameter.</param>
		/// <returns>
		/// If the function succeeds, the low-order word of the return value is the number of pixels added to the horizontal coordinate of
		/// each source point in order to compute the horizontal coordinate of each destination point. (In addition to that, if precisely one
		/// of hWndFrom and hWndTo is mirrored, then each resulting horizontal coordinate is multiplied by -1.) The high-order word is the
		/// number of pixels added to the vertical coordinate of each source point in order to compute the vertical coordinate of each
		/// destination point.
		/// <para>
		/// If the function fails, the return value is zero. Call SetLastError prior to calling this method to differentiate an error return
		/// value from a legitimate "0" return value.
		/// </para>
		/// </returns>
		[PInvokeData("WinUser.h", MSDNShortId = "")]
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		public static extern int MapWindowPoints(HWND hWndFrom, HWND hWndTo, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] POINT[] lpPoints, [MarshalAs(UnmanagedType.U4)] int cPoints);

		/// <summary>The ScreenToClient function converts the screen coordinates of a specified point on the screen to client-area coordinates.</summary>
		/// <param name="hWnd">A handle to the window whose client area will be used for the conversion.</param>
		/// <param name="lpPoint">A pointer to a POINT structure that specifies the screen coordinates to be converted.</param>
		/// <returns>
		/// If the function succeeds, the return value is true. If the function fails, the return value is false. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[System.Security.SecurityCritical]
		public static extern bool ScreenToClient(HWND hWnd, [In, Out] ref POINT lpPoint);

		/// <summary>Sets the orientation preferences of the display.</summary>
		/// <param name="orientation">The orientation.</param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If this function set the orientation preferences, the return value is nonzero.</para>
		/// <para>If the orientation preferences weren't set, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// An app can remove the orientation preferences of the display after it sets them by passing <c>ORIENTATION_PREFERENCE_NONE</c> to
		/// <c>SetDisplayAutoRotationPreferences</c>. An app can change the orientation preferences of the display by passing a different
		/// combination of <c>ORIENTATION_PREFERENCE</c>-typed values to <c>SetDisplayAutoRotationPreferences</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/dn376361(v=vs.85) BOOL WINAPI SetDisplayAutoRotationPreferences( _In_
		// ORIENTATION_PREFERENCE orientation );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winuser.h", MSDNShortId = "")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetDisplayAutoRotationPreferences([In] ORIENTATION_PREFERENCE orientation);
	}
}