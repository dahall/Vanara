using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>The resolution desired.</summary>
		[PInvokeData("winuser.h")]
		public enum GMMP
		{
			/// <summary>Retrieves the points using the display resolution.</summary>
			GMMP_USE_DISPLAY_POINTS = 1,

			/// <summary>
			/// Retrieves high resolution points. Points can range from zero to 65,535 (0xFFFF) in both x- and y-coordinates. This is the
			/// resolution provided by absolute coordinate pointing devices such as drawing tablets.
			/// </summary>
			GMMP_USE_HIGH_RESOLUTION_POINTS = 2,
		}

		/// <summary>
		/// The return value specifies whether the window should be activated and whether the identifier of the mouse message should be discarded.
		/// </summary>
		[PInvokeData("winuser.h")]
		public enum MouseActivateCode : int
		{
			/// <summary>Activates the window, and does not discard the mouse message.</summary>
			MA_ACTIVATE = 1,

			/// <summary>Activates the window, and discards the mouse message.</summary>
			MA_ACTIVATEANDEAT = 2,

			/// <summary>Does not activate the window, and does not discard the mouse message.</summary>
			MA_NOACTIVATE = 3,

			/// <summary>Does not activate the window, but discards the mouse message.</summary>
			MA_NOACTIVATEANDEAT = 4
		}

		/// <summary>Controls various aspects of mouse motion and button clicking.</summary>
		[PInvokeData("winuser.h")]
		[Flags]
		public enum MOUSEEVENTF
		{
			/// <summary>
			/// The dx and dy parameters contain normalized absolute coordinates. If not set, those parameters contain relative data: the
			/// change in position since the last reported position. This flag can be set, or not set, regardless of what kind of mouse or
			/// mouse-like device, if any, is connected to the system. For further information about relative mouse motion, see the following
			/// Remarks section.
			/// </summary>
			MOUSEEVENTF_ABSOLUTE = 0x8000,

			/// <summary>The left button is down.</summary>
			MOUSEEVENTF_LEFTDOWN = 0x0002,

			/// <summary>The left button is up.</summary>
			MOUSEEVENTF_LEFTUP = 0x0004,

			/// <summary>The middle button is down.</summary>
			MOUSEEVENTF_MIDDLEDOWN = 0x0020,

			/// <summary>The middle button is up.</summary>
			MOUSEEVENTF_MIDDLEUP = 0x0040,

			/// <summary>Movement occurred.</summary>
			MOUSEEVENTF_MOVE = 0x0001,

			/// <summary>The right button is down.</summary>
			MOUSEEVENTF_RIGHTDOWN = 0x0008,

			/// <summary>The right button is up.</summary>
			MOUSEEVENTF_RIGHTUP = 0x0010,

			/// <summary>The wheel has been moved, if the mouse has a wheel. The amount of movement is specified in dwData</summary>
			MOUSEEVENTF_WHEEL = 0x0800,

			/// <summary>An X button was pressed.</summary>
			MOUSEEVENTF_XDOWN = 0x0080,

			/// <summary>An X button was released.</summary>
			MOUSEEVENTF_XUP = 0x0100,

			/// <summary>The wheel button is tilted.</summary>
			MOUSEEVENTF_HWHEEL = 0x01000,

			/// <summary>Do not coalesce mouse moves.</summary>
			MOUSEEVENTF_MOVE_NOCOALESCE = 0x2000,

			/// <summary>Map to entire virtual desktop</summary>
			MOUSEEVENTF_VIRTUALDESK = 0x4000,
		}

		/// <summary>The services requested in a <see cref="TRACKMOUSEEVENT"/> structure.</summary>
		[Flags]
		public enum TME : uint
		{
			/// <summary>
			/// The caller wants to cancel a prior tracking request. The caller should also specify the type of tracking that it wants to
			/// cancel. For example, to cancel hover tracking, the caller must pass the TME_CANCEL and TME_HOVER flags.
			/// </summary>
			TME_CANCEL = 0x80000000,

			/// <summary>
			/// The caller wants hover notification. Notification is delivered as a WM_MOUSEHOVER message.
			/// <para>If the caller requests hover tracking while hover tracking is already active, the hover timer will be reset.</para>
			/// <para>This flag is ignored if the mouse pointer is not over the specified window or area.</para>
			/// </summary>
			TME_HOVER = 0x00000001,

			/// <summary>
			/// The caller wants leave notification. Notification is delivered as a WM_MOUSELEAVE message. If the mouse is not over the
			/// specified window or area, a leave notification is generated immediately and no further tracking is performed.
			/// </summary>
			TME_LEAVE = 0x00000002		/// <term>Activates the window, and does not discard the mouse message.</term>


			/// <summary>
			/// The caller wants hover and leave notification for the nonclient areas. Notification is delivered as WM_NCMOUSEHOVER and
			/// WM_NCMOUSELEAVE messages.
			/// </summary>
			TME_NONCLIENT = 0x00000010,

			/// <summary>
			/// The function fills in the structure instead of treating it as a tracking request. The structure is filled such that had that
			/// structure been passed to TrackMouseEvent, it would generate the current tracking. The only anomaly is that the hover time-out
			/// returned is always the actual time-out and not HOVER_DEFAULT, if HOVER_DEFAULT was specified during the original
			/// TrackMouseEvent request.
			/// </summary>
			TME_QUERY = 0x40000000,
		}

		/// <summary>
		/// Retrieves the current double-click time for the mouse. A double-click is a series of two clicks of the mouse button, the second
		/// occurring within a specified time after the first. The double-click time is the maximum number of milliseconds that may occur
		/// between the first and second click of a double-click. The maximum double-click time is 5000 milliseconds.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The return value specifies the current double-click time, in milliseconds. The maximum return value is 5000 milliseconds.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdoubleclicktime UINT GetDoubleClickTime( );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		public static extern uint GetDoubleClickTime();

		/// <summary>Retrieves a history of up to 64 previous coordinates of the mouse or pen.</summary>
		/// <param name="cbSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size, in bytes, of the MOUSEMOVEPOINT structure.</para>
		/// </param>
		/// <param name="lppt">
		/// <para>Type: <c>LPMOUSEMOVEPOINT</c></para>
		/// <para>
		/// A pointer to a MOUSEMOVEPOINT structure containing valid mouse coordinates (in screen coordinates). It may also contain a time stamp.
		/// </para>
		/// <para>
		/// The <c>GetMouseMovePointsEx</c> function searches for the point in the mouse coordinates history. If the function finds the
		/// point, it returns the last nBufPoints prior to and including the supplied point.
		/// </para>
		/// <para>
		/// If your application supplies a time stamp, the <c>GetMouseMovePointsEx</c> function will use it to differentiate between two
		/// equal points that were recorded at different times.
		/// </para>
		/// <para>
		/// An application should call this function using the mouse coordinates received from the WM_MOUSEMOVE message and convert them to
		/// screen coordinates.
		/// </para>
		/// </param>
		/// <param name="lpptBuf">
		/// <para>Type: <c>LPMOUSEMOVEPOINT</c></para>
		/// <para>A pointer to a buffer that will receive the points. It should be at least cbSize* nBufPoints in size.</para>
		/// </param>
		/// <param name="nBufPoints">
		/// <para>Type: <c>int</c></para>
		/// <para>The number of points to be retrieved.</para>
		/// </param>
		/// <param name="resolution">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The resolution desired. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GMMP_USE_DISPLAY_POINTS 1</term>
		/// <term>Retrieves the points using the display resolution.</term>
		/// </item>
		/// <item>
		/// <term>GMMP_USE_HIGH_RESOLUTION_POINTS 2</term>
		/// <term>
		/// Retrieves high resolution points. Points can range from zero to 65,535 (0xFFFF) in both x- and y-coordinates. This is the
		/// resolution provided by absolute coordinate pointing devices such as drawing tablets.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// If the function succeeds, the return value is the number of points in the buffer. Otherwise, the function returns –1. For
		/// extended error information, your application can call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The system retains the last 64 mouse coordinates and their time stamps. If your application supplies a mouse coordinate to
		/// <c>GetMouseMovePointsEx</c> and the coordinate exists in the system's mouse coordinate history, the function retrieves the
		/// specified number of coordinates from the systems' history. You can also supply a time stamp, which will be used to differentiate
		/// between identical points in the history.
		/// </para>
		/// <para>
		/// The <c>GetMouseMovePointsEx</c> function will return points that eventually were dispatched not only to the calling thread but
		/// also to other threads.
		/// </para>
		/// <para><c>GetMouseMovePointsEx</c> may fail or return erroneous values in the following cases:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>If negative coordinates are passed in the MOUSEMOVEPOINT structure.</term>
		/// </item>
		/// <item>
		/// <term>If <c>GetMouseMovePointsEx</c> retrieves a coordinate with a negative value.</term>
		/// </item>
		/// </list>
		/// <para>
		/// These situations can occur if multiple monitors are present. To correct this, first call GetSystemMetrics to get the following values:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>SM_XVIRTUALSCREEN,</term>
		/// </item>
		/// <item>
		/// <term>SM_YVIRTUALSCREEN,</term>
		/// </item>
		/// <item>
		/// <term>SM_CXVIRTUALSCREEN, and</term>
		/// </item>
		/// <item>
		/// <term>SM_CYVIRTUALSCREEN.</term>
		/// </item>
		/// </list>
		/// <para>Then, for each point that is returned from <c>GetMouseMovePointsEx</c>, perform the following transform:</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmousemovepointsex int GetMouseMovePointsEx( UINT
		// cbSize, LPMOUSEMOVEPOINT lppt, LPMOUSEMOVEPOINT lpptBuf, int nBufPoints, DWORD resolution );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		public static extern int GetMouseMovePointsEx(uint cbSize, in MOUSEMOVEPOINT lppt, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] MOUSEMOVEPOINT[] lpptBuf, int nBufPoints, GMMP resolution);

		/// <summary>
		/// <para>The <c>mouse_event</c> function synthesizes mouse motion and button clicks.</para>
		/// <para><c>Note</c> This function has been superseded. Use SendInput instead.</para>
		/// </summary>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Controls various aspects of mouse motion and button clicking. This parameter can be certain combinations of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MOUSEEVENTF_ABSOLUTE 0x8000</term>
		/// <term>
		/// The dx and dy parameters contain normalized absolute coordinates. If not set, those parameters contain relative data: the change
		/// in position since the last reported position. This flag can be set, or not set, regardless of what kind of mouse or mouse-like
		/// device, if any, is connected to the system. For further information about relative mouse motion, see the following Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_LEFTDOWN 0x0002</term>
		/// <term>The left button is down.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_LEFTUP 0x0004</term>
		/// <term>The left button is up.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_MIDDLEDOWN 0x0020</term>
		/// <term>The middle button is down.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_MIDDLEUP 0x0040</term>
		/// <term>The middle button is up.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_MOVE 0x0001</term>
		/// <term>Movement occurred.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_RIGHTDOWN 0x0008</term>
		/// <term>The right button is down.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_RIGHTUP 0x0010</term>
		/// <term>The right button is up.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_WHEEL 0x0800</term>
		/// <term>The wheel has been moved, if the mouse has a wheel. The amount of movement is specified in dwData</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_XDOWN 0x0080</term>
		/// <term>An X button was pressed.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_XUP 0x0100</term>
		/// <term>An X button was released.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_WHEEL 0x0800</term>
		/// <term>The wheel button is rotated.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_HWHEEL 0x01000</term>
		/// <term>The wheel button is tilted.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The values that specify mouse button status are set to indicate changes in status, not ongoing conditions. For example, if the
		/// left mouse button is pressed and held down, <c>MOUSEEVENTF_LEFTDOWN</c> is set when the left button is first pressed, but not for
		/// subsequent motions. Similarly, <c>MOUSEEVENTF_LEFTUP</c> is set only when the button is first released.
		/// </para>
		/// <para>
		/// You cannot specify both <c>MOUSEEVENTF_WHEEL</c> and either <c>MOUSEEVENTF_XDOWN</c> or <c>MOUSEEVENTF_XUP</c> simultaneously in
		/// the dwFlags parameter, because they both require use of the dwData field.
		/// </para>
		/// </param>
		/// <param name="dx">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The mouse's absolute position along the x-axis or its amount of motion since the last mouse event was generated, depending on the
		/// setting of <c>MOUSEEVENTF_ABSOLUTE</c>. Absolute data is specified as the mouse's actual x-coordinate; relative data is specified
		/// as the number of mickeys moved. A mickey is the amount that a mouse has to move for it to report that it has moved.
		/// </para>
		/// </param>
		/// <param name="dy">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The mouse's absolute position along the y-axis or its amount of motion since the last mouse event was generated, depending on the
		/// setting of <c>MOUSEEVENTF_ABSOLUTE</c>. Absolute data is specified as the mouse's actual y-coordinate; relative data is specified
		/// as the number of mickeys moved.
		/// </para>
		/// </param>
		/// <param name="dwData">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// If dwFlags contains <c>MOUSEEVENTF_WHEEL</c>, then dwData specifies the amount of wheel movement. A positive value indicates that
		/// the wheel was rotated forward, away from the user; a negative value indicates that the wheel was rotated backward, toward the
		/// user. One wheel click is defined as <c>WHEEL_DELTA</c>, which is 120.
		/// </para>
		/// <para>
		/// If dwFlags contains <c>MOUSEEVENTF_HWHEEL</c>, then dwData specifies the amount of wheel movement. A positive value indicates
		/// that the wheel was tilted to the right; a negative value indicates that the wheel was tilted to the left.
		/// </para>
		/// <para>
		/// If dwFlags contains <c>MOUSEEVENTF_XDOWN</c> or <c>MOUSEEVENTF_XUP</c>, then dwData specifies which X buttons were pressed or
		/// released. This value may be any combination of the following flags.
		/// </para>
		/// <para>
		/// If dwFlags is not <c>MOUSEEVENTF_WHEEL</c>, <c>MOUSEEVENTF_XDOWN</c>, or <c>MOUSEEVENTF_XUP</c>, then dwData should be zero.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>XBUTTON1 0x0001</term>
		/// <term>Set if the first X button was pressed or released.</term>
		/// </item>
		/// <item>
		/// <term>XBUTTON2 0x0002</term>
		/// <term>Set if the second X button was pressed or released.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwExtraInfo">
		/// <para>Type: <c>ULONG_PTR</c></para>
		/// <para>An additional value associated with the mouse event. An application calls GetMessageExtraInfo to obtain this extra information.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// If the mouse has moved, indicated by <c>MOUSEEVENTF_MOVE</c> being set, dx and dy hold information about that motion. The
		/// information is specified as absolute or relative integer values.
		/// </para>
		/// <para>
		/// If <c>MOUSEEVENTF_ABSOLUTE</c> value is specified, dx and dy contain normalized absolute coordinates between 0 and 65,535. The
		/// event procedure maps these coordinates onto the display surface. Coordinate (0,0) maps onto the upper-left corner of the display
		/// surface, (65535,65535) maps onto the lower-right corner.
		/// </para>
		/// <para>
		/// If the <c>MOUSEEVENTF_ABSOLUTE</c> value is not specified, dx and dy specify relative motions from when the last mouse event was
		/// generated (the last reported position). Positive values mean the mouse moved right (or down); negative values mean the mouse
		/// moved left (or up).
		/// </para>
		/// <para>
		/// Relative mouse motion is subject to the settings for mouse speed and acceleration level. An end user sets these values using the
		/// Mouse application in Control Panel. An application obtains and sets these values with the SystemParametersInfo function.
		/// </para>
		/// <para>
		/// The system applies two tests to the specified relative mouse motion when applying acceleration. If the specified distance along
		/// either the x or y axis is greater than the first mouse threshold value, and the mouse acceleration level is not zero, the
		/// operating system doubles the distance. If the specified distance along either the x- or y-axis is greater than the second mouse
		/// threshold value, and the mouse acceleration level is equal to two, the operating system doubles the distance that resulted from
		/// applying the first threshold test. It is thus possible for the operating system to multiply relatively-specified mouse motion
		/// along the x- or y-axis by up to four times.
		/// </para>
		/// <para>
		/// Once acceleration has been applied, the system scales the resultant value by the desired mouse speed. Mouse speed can range from
		/// 1 (slowest) to 20 (fastest) and represents how much the pointer moves based on the distance the mouse moves. The default value is
		/// 10, which results in no additional modification to the mouse motion.
		/// </para>
		/// <para>
		/// The <c>mouse_event</c> function is used to synthesize mouse events by applications that need to do so. It is also used by
		/// applications that need to obtain more information from the mouse than its position and button state. For example, if a tablet
		/// manufacturer wants to pass pen-based information to its own applications, it can write a DLL that communicates directly to the
		/// tablet hardware, obtains the extra information, and saves it in a queue. The DLL then calls <c>mouse_event</c> with the standard
		/// button and x/y position data, along with, in the dwExtraInfo parameter, some pointer or index to the queued extra information.
		/// When the application needs the extra information, it calls the DLL with the pointer or index stored in dwExtraInfo, and the DLL
		/// returns the extra information.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-mouse_event void mouse_event( DWORD dwFlags, DWORD dx,
		// DWORD dy, DWORD dwData, ULONG_PTR dwExtraInfo );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		public static extern void mouse_event(MOUSEEVENTF dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

		/// <summary>
		/// Sets the double-click time for the mouse. A double-click is a series of two clicks of a mouse button, the second occurring within
		/// a specified time after the first. The double-click time is the maximum number of milliseconds that may occur between the first
		/// and second clicks of a double-click.
		/// </summary>
		/// <param name="Arg1">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of milliseconds that may occur between the first and second clicks of a double-click. If this parameter is set to 0,
		/// the system uses the default double-click time of 500 milliseconds. If this parameter value is greater than 5000 milliseconds, the
		/// system sets the value to 5000 milliseconds.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>The <c>SetDoubleClickTime</c> function alters the double-click time for all windows in the system.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setdoubleclicktime BOOL SetDoubleClickTime( UINT Arg1 );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetDoubleClickTime(uint Arg1);

		/// <summary>Reverses or restores the meaning of the left and right mouse buttons.</summary>
		/// <param name="fSwap">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If this parameter is <c>TRUE</c>, the left button generates right-button messages and the right button generates left-button
		/// messages. If this parameter is <c>FALSE</c>, the buttons are restored to their original meanings.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the meaning of the mouse buttons was reversed previously, before the function was called, the return value is nonzero.</para>
		/// <para>If the meaning of the mouse buttons was not reversed, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// Button swapping is provided as a convenience to people who use the mouse with their left hands. The <c>SwapMouseButton</c>
		/// function is usually called by Control Panel only. Although an application is free to call the function, the mouse is a shared
		/// resource and reversing the meaning of its buttons affects all applications.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-swapmousebutton BOOL SwapMouseButton( BOOL fSwap );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SwapMouseButton([MarshalAs(UnmanagedType.Bool)] bool fSwap);

		/// <summary>Posts messages when the mouse pointer leaves a window or hovers over a window for a specified amount of time.</summary>
		/// <param name="lpEventTrack">
		/// <para>Type: <c>LPTRACKMOUSEEVENT</c></para>
		/// <para>A pointer to a <c>TRACKMOUSEEVENT</c> structure that contains tracking information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero .</para>
		/// <para>If the function fails, return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI TrackMouseEvent( _Inout_ LPTRACKMOUSEEVENT lpEventTrack); https://msdn.microsoft.com/en-us/library/windows/desktop/ms646265(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winuser.h", MSDNShortId = "ms646265")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENT lpEventTrack);

		/// <summary>Contains information about the mouse's location in screen coordinates.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagmousemovepoint typedef struct tagMOUSEMOVEPOINT { int
		// x; int y; DWORD time; ULONG_PTR dwExtraInfo; } MOUSEMOVEPOINT, *PMOUSEMOVEPOINT, *LPMOUSEMOVEPOINT;
		[PInvokeData("winuser.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MOUSEMOVEPOINT
		{
			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>The x-coordinate of the mouse.</para>
			/// </summary>
			public int x;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>The y-coordinate of the mouse.</para>
			/// </summary>
			public int y;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The time stamp of the mouse coordinate.</para>
			/// </summary>
			public uint time;

			/// <summary>
			/// <para>Type: <c>ULONG_PTR</c></para>
			/// <para>Additional information associated with this coordinate.</para>
			/// </summary>
			public IntPtr dwExtraInfo;
		}

		/// <summary>
		/// Used by the TrackMouseEvent function to track when the mouse pointer leaves a window or hovers over a window for a specified
		/// amount of time.
		/// </summary>
		[PInvokeData("Winuser.h", MSDNShortId = "ms645604")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRACKMOUSEEVENT
		{
			/// <summary>The size of the TRACKMOUSEEVENT structure, in bytes.</summary>
			public uint cbSize;

			/// <summary>The services requested</summary>
			public TME dwFlags;

			/// <summary>A handle to the window to track.</summary>
			public HWND hwndTrack;

			/// <summary>
			/// The hover time-out (if TME_HOVER was specified in dwFlags), in milliseconds. Can be HOVER_DEFAULT, which means to use the
			/// system default hover time-out.
			/// </summary>
			public uint dwHoverTime;
		}
	}
}