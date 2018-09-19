using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke
{
	public static partial class User32_Gdi
	{
		/// <summary>
		/// <para>
		/// A <c>MonitorEnumProc</c> function is an application-defined callback function that is called by the EnumDisplayMonitors function.
		/// </para>
		/// <para>A value of type <c>MONITORENUMPROC</c> is a pointer to a <c>MonitorEnumProc</c> function.</para>
		/// </summary>
		/// <param name="Arg1"/>
		/// <param name="Arg2"/>
		/// <param name="Arg3"/>
		/// <param name="Arg4"/>
		/// <returns>
		/// <para>To continue the enumeration, return <c>TRUE</c>.</para>
		/// <para>To stop the enumeration, return <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You can use the EnumDisplayMonitors function to enumerate the set of display monitors that intersect the visible region of a
		/// specified device context and, optionally, a clipping rectangle. To do this, set the hdc parameter to a non- <c>NULL</c> value,
		/// and set the lprcClip parameter as needed.
		/// </para>
		/// <para>
		/// You can also use the EnumDisplayMonitors function to enumerate one or more of the display monitors on the desktop, without
		/// supplying a device context. To do this, set the hdc parameter of <c>EnumDisplayMonitors</c> to <c>NULL</c> and set the lprcClip
		/// parameter as needed.
		/// </para>
		/// <para>
		/// In all cases, EnumDisplayMonitors calls a specified <c>MonitorEnumProc</c> function once for each display monitor in the
		/// calculated enumeration set. The <c>MonitorEnumProc</c> function always receives a handle to the display monitor.
		/// </para>
		/// <para>
		/// If the hdc parameter of EnumDisplayMonitors is non- <c>NULL</c>, the <c>MonitorEnumProc</c> function also receives a handle to a
		/// device context whose color format is appropriate for the display monitor. You can then paint into the device context in a manner
		/// that is optimal for the display monitor.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nc-winuser-monitorenumproc MONITORENUMPROC Monitorenumproc; BOOL
		// Monitorenumproc( HMONITOR Arg1, HDC Arg2, LPRECT Arg3, LPARAM Arg4 ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("winuser.h", MSDNShortId = "2d69e363-2b2c-450f-9069-488b80991217")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool MonitorEnumProc(IntPtr Arg1, IntPtr Arg2, PRECT Arg3, IntPtr Arg4);

		/// <summary>Determines the function's return value if the point is not contained within any display monitor.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "c46281bf-7e45-4628-be92-736850225a9e")]
		public enum MonitorFlags
		{
			/// <summary>Returns NULL.</summary>
			MONITOR_DEFAULTTONULL = 0x00000000,

			/// <summary>Returns a handle to the primary display monitor.</summary>
			MONITOR_DEFAULTTOPRIMARY = 0x00000001,

			/// <summary>Returns a handle to the display monitor that is nearest to the point.</summary>
			MONITOR_DEFAULTTONEAREST = 0x00000002,
		}

		/// <summary>Flags for <see cref="MONITORINFO.dwFlags"/>.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "ca8ec86f-69ba-4cf8-a867-67182a3d630d")]
		public enum MonitorInfoFlags
		{
			/// <summary>This is the primary display monitor.</summary>
			MONITORINFOF_PRIMARY = 0x00000001
		}

		/// <summary>
		/// <para>
		/// The <c>EnumDisplayMonitors</c> function enumerates display monitors (including invisible pseudo-monitors associated with the
		/// mirroring drivers) that intersect a region formed by the intersection of a specified clipping rectangle and the visible region of
		/// a device context. <c>EnumDisplayMonitors</c> calls an application-defined MonitorEnumProc callback function once for each monitor
		/// that is enumerated. Note that GetSystemMetrics (SM_CMONITORS) counts only the display monitors.
		/// </para>
		/// </summary>
		/// <param name="hdc">
		/// <para>A handle to a display device context that defines the visible region of interest.</para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the hdcMonitor parameter passed to the callback function will be <c>NULL</c>, and the visible
		/// region of interest is the virtual screen that encompasses all the displays on the desktop.
		/// </para>
		/// </param>
		/// <param name="lprcClip">
		/// <para>
		/// A pointer to a RECT structure that specifies a clipping rectangle. The region of interest is the intersection of the clipping
		/// rectangle with the visible region specified by hdc.
		/// </para>
		/// <para>
		/// If hdc is non- <c>NULL</c>, the coordinates of the clipping rectangle are relative to the origin of the hdc. If hdc is
		/// <c>NULL</c>, the coordinates are virtual-screen coordinates.
		/// </para>
		/// <para>This parameter can be <c>NULL</c> if you don't want to clip the region specified by hdc.</para>
		/// </param>
		/// <param name="lpfnEnum">
		/// <para>A pointer to a MonitorEnumProc application-defined callback function.</para>
		/// </param>
		/// <param name="dwData">
		/// <para>Application-defined data that <c>EnumDisplayMonitors</c> passes directly to the MonitorEnumProc function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>There are two reasons to call the <c>EnumDisplayMonitors</c> function:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// You want to draw optimally into a device context that spans several display monitors, and the monitors have different color formats.
		/// </term>
		/// </item>
		/// <item>
		/// <term>You want to obtain a handle and position rectangle for one or more display monitors.</term>
		/// </item>
		/// </list>
		/// <para>To determine whether all the display monitors in a system share the same color format, call GetSystemMetrics (SM_SAMEDISPLAYFORMAT).</para>
		/// <para>
		/// You do not need to use the <c>EnumDisplayMonitors</c> function when a window spans display monitors that have different color
		/// formats. You can continue to paint under the assumption that the entire screen has the color properties of the primary monitor.
		/// Your windows will look fine. <c>EnumDisplayMonitors</c> just lets you make them look better.
		/// </para>
		/// <para>
		/// Setting the hdc parameter to <c>NULL</c> lets you use the <c>EnumDisplayMonitors</c> function to obtain a handle and position
		/// rectangle for one or more display monitors. The following table shows how the four combinations of <c>NULL</c> and non-
		/// <c>NULL</c> hdc and lprcClip values affect the behavior of the <c>EnumDisplayMonitors</c> function.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>hdc</term>
		/// <term>lprcRect</term>
		/// <term>EnumDisplayMonitors behavior</term>
		/// </listheader>
		/// <item>
		/// <term>NULL</term>
		/// <term>NULL</term>
		/// <term>Enumerates all display monitors.The callback function receives a NULL HDC.</term>
		/// </item>
		/// <item>
		/// <term>NULL</term>
		/// <term>non-NULL</term>
		/// <term>
		/// Enumerates all display monitors that intersect the clipping rectangle. Use virtual screen coordinates for the clipping
		/// rectangle.The callback function receives a NULL HDC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>non-NULL</term>
		/// <term>NULL</term>
		/// <term>
		/// Enumerates all display monitors that intersect the visible region of the device context.The callback function receives a handle
		/// to a DC for the specific display monitor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>non-NULL</term>
		/// <term>non-NULL</term>
		/// <term>
		/// Enumerates all display monitors that intersect the visible region of the device context and the clipping rectangle. Use device
		/// context coordinates for the clipping rectangle.The callback function receives a handle to a DC for the specific display monitor.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>
		/// To paint in response to a WM_PAINT message, using the capabilities of each monitor, you can use code like this in a window procedure:
		/// </para>
		/// <para>To paint the top half of a window using the capabilities of each monitor, you can use code like this:</para>
		/// <para>To paint the entire virtual screen optimally for each display monitor, you can use code like this:</para>
		/// <para>To retrieve information about all of the display monitors, use code like this:</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enumdisplaymonitors BOOL EnumDisplayMonitors( HDC hdc,
		// LPCRECT lprcClip, MONITORENUMPROC lpfnEnum, LPARAM dwData );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "a7668c28-77c9-4373-ae1a-eab3cb98f866")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumDisplayMonitors(SafeDCHandle hdc, PRECT lprcClip, MonitorEnumProc lpfnEnum, IntPtr dwData);

		/// <summary>
		/// <para>The <c>GetMonitorInfo</c> function retrieves information about a display monitor.</para>
		/// </summary>
		/// <param name="hMonitor">
		/// <para>A handle to the display monitor of interest.</para>
		/// </param>
		/// <param name="lpmi">
		/// <para>A pointer to a MONITORINFO or MONITORINFOEX structure that receives information about the specified display monitor.</para>
		/// <para>
		/// You must set the <c>cbSize</c> member of the structure to sizeof(MONITORINFO) or sizeof(MONITORINFOEX) before calling the
		/// <c>GetMonitorInfo</c> function. Doing so lets the function determine the type of structure you are passing to it.
		/// </para>
		/// <para>
		/// The MONITORINFOEX structure is a superset of the MONITORINFO structure. It has one additional member: a string that contains a
		/// name for the display monitor. Most applications have no use for a display monitor name, and so can save some bytes by using a
		/// <c>MONITORINFO</c> structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmonitorinfoa BOOL GetMonitorInfoA( HMONITOR hMonitor,
		// LPMONITORINFO lpmi );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "025a89c2-4bbd-4c8b-8367-3735fb5b872a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetMonitorInfo(HMONITOR hMonitor, ref MONITORINFO lpmi);

		/// <summary>
		/// <para>The <c>MonitorFromPoint</c> function retrieves a handle to the display monitor that contains a specified point.</para>
		/// </summary>
		/// <param name="pt">
		/// <para>A POINT structure that specifies the point of interest in virtual-screen coordinates.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Determines the function's return value if the point is not contained within any display monitor.</para>
		/// <para>This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MONITOR_DEFAULTTONEAREST</term>
		/// <term>Returns a handle to the display monitor that is nearest to the point.</term>
		/// </item>
		/// <item>
		/// <term>MONITOR_DEFAULTTONULL</term>
		/// <term>Returns NULL.</term>
		/// </item>
		/// <item>
		/// <term>MONITOR_DEFAULTTOPRIMARY</term>
		/// <term>Returns a handle to the primary display monitor.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the point is contained by a display monitor, the return value is an <c>HMONITOR</c> handle to that display monitor.</para>
		/// <para>If the point is not contained by a display monitor, the return value depends on the value of dwFlags.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-monitorfrompoint HMONITOR MonitorFromPoint( POINT pt,
		// DWORD dwFlags );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "c46281bf-7e45-4628-be92-736850225a9e")]
		public static extern HMONITOR MonitorFromPoint(System.Drawing.Point pt, MonitorFlags dwFlags);

		/// <summary>
		/// <para>
		/// The <c>MonitorFromRect</c> function retrieves a handle to the display monitor that has the largest area of intersection with a
		/// specified rectangle.
		/// </para>
		/// </summary>
		/// <param name="lprc">
		/// <para>A pointer to a RECT structure that specifies the rectangle of interest in virtual-screen coordinates.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Determines the function's return value if the rectangle does not intersect any display monitor.</para>
		/// <para>This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MONITOR_DEFAULTTONEAREST</term>
		/// <term>Returns a handle to the display monitor that is nearest to the rectangle.</term>
		/// </item>
		/// <item>
		/// <term>MONITOR_DEFAULTTONULL</term>
		/// <term>Returns NULL.</term>
		/// </item>
		/// <item>
		/// <term>MONITOR_DEFAULTTOPRIMARY</term>
		/// <term>Returns a handle to the primary display monitor.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>
		/// If the rectangle intersects one or more display monitor rectangles, the return value is an <c>HMONITOR</c> handle to the display
		/// monitor that has the largest area of intersection with the rectangle.
		/// </para>
		/// <para>If the rectangle does not intersect a display monitor, the return value depends on the value of dwFlags.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-monitorfromrect HMONITOR MonitorFromRect( LPCRECT lprc,
		// DWORD dwFlags );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "81c3fffb-bbc9-4adb-bb6b-edd59f7a77b4")]
		public static extern HMONITOR MonitorFromRect([MarshalAs(UnmanagedType.LPStruct)] RECT lprc, MonitorFlags dwFlags);

		/// <summary>
		/// <para>
		/// The <c>MonitorFromWindow</c> function retrieves a handle to the display monitor that has the largest area of intersection with
		/// the bounding rectangle of a specified window.
		/// </para>
		/// </summary>
		/// <param name="hwnd">
		/// <para>A handle to the window of interest.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Determines the function's return value if the window does not intersect any display monitor.</para>
		/// <para>This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MONITOR_DEFAULTTONEAREST</term>
		/// <term>Returns a handle to the display monitor that is nearest to the window.</term>
		/// </item>
		/// <item>
		/// <term>MONITOR_DEFAULTTONULL</term>
		/// <term>Returns NULL.</term>
		/// </item>
		/// <item>
		/// <term>MONITOR_DEFAULTTOPRIMARY</term>
		/// <term>Returns a handle to the primary display monitor.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>
		/// If the window intersects one or more display monitor rectangles, the return value is an <c>HMONITOR</c> handle to the display
		/// monitor that has the largest area of intersection with the window.
		/// </para>
		/// <para>If the window does not intersect a display monitor, the return value depends on the value of dwFlags.</para>
		/// </returns>
		/// <remarks>
		/// <para>If the window is currently minimized, <c>MonitorFromWindow</c> uses the rectangle of the window before it was minimized.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-monitorfromwindow HMONITOR MonitorFromWindow( HWND hwnd,
		// DWORD dwFlags );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "fe6505c9-b481-4fec-ae9d-995943234a3a")]
		public static extern HMONITOR MonitorFromWindow(HandleRef hwnd, MonitorFlags dwFlags);

		/// <summary>
		/// <para>The <c>MONITORINFO</c> structure contains information about a display monitor.</para>
		/// <para>The GetMonitorInfo function stores information in a <c>MONITORINFO</c> structure or a MONITORINFOEX structure.</para>
		/// <para>
		/// The <c>MONITORINFO</c> structure is a subset of the MONITORINFOEX structure. The <c>MONITORINFOEX</c> structure adds a string
		/// member to contain a name for the display monitor.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagmonitorinfo typedef struct tagMONITORINFO { DWORD
		// cbSize; RECT rcMonitor; RECT rcWork; DWORD dwFlags; } MONITORINFO, *LPMONITORINFO;
		[PInvokeData("winuser.h", MSDNShortId = "ca8ec86f-69ba-4cf8-a867-67182a3d630d")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MONITORINFO
		{
			/// <summary>
			/// <para>The size of the structure, in bytes.</para>
			/// <para>
			/// Set this member to before calling the GetMonitorInfo function. Doing so lets the function determine the type of structure you
			/// are passing to it.
			/// </para>
			/// </summary>
			public uint cbSize;

			/// <summary>
			/// <para>
			/// A RECT structure that specifies the display monitor rectangle, expressed in virtual-screen coordinates. Note that if the
			/// monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
			/// </para>
			/// </summary>
			public RECT rcMonitor;

			/// <summary>
			/// <para>
			/// A RECT structure that specifies the work area rectangle of the display monitor, expressed in virtual-screen coordinates. Note
			/// that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
			/// </para>
			/// </summary>
			public RECT rcWork;

			/// <summary>
			/// <para>A set of flags that represent attributes of the display monitor.</para>
			/// <para>The following flag is defined.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MONITORINFOF_PRIMARY</term>
			/// <term>This is the primary display monitor.</term>
			/// </item>
			/// </list>
			/// </summary>
			public MonitorInfoFlags dwFlags;
		}

		/// <summary>
		/// <para>The <c>MONITORINFOEX</c> structure contains information about a display monitor.</para>
		/// <para>The GetMonitorInfo function stores information into a <c>MONITORINFOEX</c> structure or a MONITORINFO structure.</para>
		/// <para>
		/// The <c>MONITORINFOEX</c> structure is a superset of the MONITORINFO structure. The <c>MONITORINFOEX</c> structure adds a string
		/// member to contain a name for the display monitor.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagmonitorinfoexa typedef struct tagMONITORINFOEXA { CHAR
		// szDevice[CCHDEVICENAME]; base_class tagMONITORINFO; } MONITORINFOEXA, *LPMONITORINFOEXA;
		[PInvokeData("winuser.h", MSDNShortId = "f296ce29-3fc8-41c9-a201-56e222aa2219")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MONITORINFOEX
		{
			/// <summary>
			/// <para>The size of the structure, in bytes.</para>
			/// <para>
			/// Set this member to before calling the GetMonitorInfo function. Doing so lets the function determine the type of structure you
			/// are passing to it.
			/// </para>
			/// </summary>
			public uint cbSize;

			/// <summary>
			/// <para>
			/// A RECT structure that specifies the display monitor rectangle, expressed in virtual-screen coordinates. Note that if the
			/// monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
			/// </para>
			/// </summary>
			public RECT rcMonitor;

			/// <summary>
			/// <para>
			/// A RECT structure that specifies the work area rectangle of the display monitor, expressed in virtual-screen coordinates. Note
			/// that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
			/// </para>
			/// </summary>
			public RECT rcWork;

			/// <summary>
			/// <para>A set of flags that represent attributes of the display monitor.</para>
			/// <para>The following flag is defined.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MONITORINFOF_PRIMARY</term>
			/// <term>This is the primary display monitor.</term>
			/// </item>
			/// </list>
			/// </summary>
			public MonitorFlags dwFlags;

			/// <summary>
			/// <para>
			/// A string that specifies the device name of the monitor being used. Most applications have no use for a display monitor name,
			/// and so can save some bytes by using a MONITORINFO structure.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string szDevice;
		}

		/// <summary>Represents a monitor handle. No method is called on disposal.</summary>
		public class HMONITOR : SafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="HMONITOR"/> class.</summary>
			public HMONITOR() : base(IntPtr.Zero, false) { }
			/// <inheritdoc/>
			public override bool IsInvalid => handle == IntPtr.Zero;
			/// <inheritdoc/>
			protected override bool ReleaseHandle() => true;
		}
	}
}