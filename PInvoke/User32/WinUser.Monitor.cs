using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>Retrieve the current settings for the display device.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "99794fb1-7ba3-4864-bf6a-e3a514fa7917")]
	public const uint ENUM_CURRENT_SETTINGS = unchecked((uint)-1);

	/// <summary>Retrieve the settings for the display device that are currently stored in the registry.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "99794fb1-7ba3-4864-bf6a-e3a514fa7917")]
	public const uint ENUM_REGISTRY_SETTINGS = unchecked((uint)-2);

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

	/// <summary>Flags for <see cref="EnumDisplayDevices"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "df3b493c-23d2-4996-9b79-86009efe3078")]
	public enum EDD
	{
		/// <summary>
		/// Retrieve the device interface name for GUID_DEVINTERFACE_MONITOR, which is registered by the operating system on a per
		/// monitor basis. The value is placed in the DeviceID member of the DISPLAY_DEVICE structure returned in lpDisplayDevice. The
		/// resulting device interface name can be used with SetupAPI functions and serves as a link between GDI monitor devices and
		/// SetupAPI monitor devices.
		/// </summary>
		EDD_GET_DEVICE_INTERFACE_NAME = 0x00000001
	}

	/// <summary>Flags for <see cref="EnumDisplaySettingsEx"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "99794fb1-7ba3-4864-bf6a-e3a514fa7917")]
	[Flags]
	public enum EDS
	{
		/// <summary>
		/// If set, the function will return all graphics modes reported by the adapter driver, regardless of monitor capabilities.
		/// Otherwise, it will only return modes that are compatible with current monitors.
		/// </summary>
		EDS_RAWMODE = 0x00000002,

		/// <summary>
		/// If set, the function will return graphics modes in all orientations. Otherwise, it will only return modes that have the same
		/// orientation as the one currently set for the requested display.
		/// </summary>
		EDS_ROTATEDMODE = 0x00000004,
	}

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

	/// <summary>The <c>EnumDisplayDevices</c> function lets you obtain information about the display devices in the current session.</summary>
	/// <param name="lpDevice">
	/// <para>
	/// A pointer to the device name. If <c>NULL</c>, function returns information for the display adapter(s) on the machine, based on iDevNum.
	/// </para>
	/// <para>For more information, see Remarks.</para>
	/// </param>
	/// <param name="iDevNum">
	/// <para>An index value that specifies the display device of interest.</para>
	/// <para>
	/// The operating system identifies each display device in the current session with an index value. The index values are consecutive
	/// integers, starting at 0. If the current session has three display devices, for example, they are specified by the index values 0,
	/// 1, and 2.
	/// </para>
	/// </param>
	/// <param name="lpDisplayDevice">
	/// <para>A pointer to a DISPLAY_DEVICE structure that receives information about the display device specified by iDevNum.</para>
	/// <para>
	/// Before calling <c>EnumDisplayDevices</c>, you must initialize the <c>cb</c> member of DISPLAY_DEVICE to the size, in bytes, of <c>DISPLAY_DEVICE</c>.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// Set this flag to EDD_GET_DEVICE_INTERFACE_NAME (0x00000001) to retrieve the device interface name for GUID_DEVINTERFACE_MONITOR,
	/// which is registered by the operating system on a per monitor basis. The value is placed in the DeviceID member of the
	/// DISPLAY_DEVICE structure returned in lpDisplayDevice. The resulting device interface name can be used with SetupAPI functions and
	/// serves as a link between GDI monitor devices and SetupAPI monitor devices.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. The function fails if iDevNum is greater than the largest device index.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To query all display devices in the current session, call this function in a loop, starting with iDevNum set to 0, and
	/// incrementing iDevNum until the function fails. To select all display devices in the desktop, use only the display devices that
	/// have the DISPLAY_DEVICE_ATTACHED_TO_DESKTOP flag in the DISPLAY_DEVICE structure.
	/// </para>
	/// <para>
	/// To get information on the display adapter, call <c>EnumDisplayDevices</c> with lpDevice set to <c>NULL</c>. For example,
	/// DISPLAY_DEVICE. <c>DeviceString</c> contains the adapter name.
	/// </para>
	/// <para>
	/// To obtain information on a display monitor, first call <c>EnumDisplayDevices</c> with lpDevice set to <c>NULL</c>. Then call
	/// <c>EnumDisplayDevices</c> with lpDevice set to DISPLAY_DEVICE. <c>DeviceName</c> from the first call to <c>EnumDisplayDevices</c>
	/// and with iDevNum set to zero. Then <c>DISPLAY_DEVICE</c>. <c>DeviceString</c> is the monitor name.
	/// </para>
	/// <para>
	/// To query all monitor devices associated with an adapter, call <c>EnumDisplayDevices</c> in a loop with lpDevice set to the
	/// adapter name, iDevNum set to start at 0, and iDevNum set to increment until the function fails. Note that
	/// <c>DISPLAY_DEVICE.DeviceName</c> changes with each call for monitor information, so you must save the adapter name. The function
	/// fails when there are no more monitors for the adapter.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enumdisplaydevicesa BOOL EnumDisplayDevicesA( LPCSTR
	// lpDevice, DWORD iDevNum, PDISPLAY_DEVICEA lpDisplayDevice, DWORD dwFlags );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "df3b493c-23d2-4996-9b79-86009efe3078")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumDisplayDevices([Optional] string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, EDD dwFlags);

	/// <summary>
	/// The <c>EnumDisplayMonitors</c> function enumerates display monitors (including invisible pseudo-monitors associated with the
	/// mirroring drivers) that intersect a region formed by the intersection of a specified clipping rectangle and the visible region of a
	/// device context. <c>EnumDisplayMonitors</c> calls an application-defined MonitorEnumProc callback function once for each monitor that
	/// is enumerated. Note that GetSystemMetrics (SM_CMONITORS) counts only the display monitors.
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
	/// If hdc is non- <c>NULL</c>, the coordinates of the clipping rectangle are relative to the origin of the hdc. If hdc is <c>NULL</c>,
	/// the coordinates are virtual-screen coordinates.
	/// </para>
	/// <para>This parameter can be <c>NULL</c> if you don't want to clip the region specified by hdc.</para>
	/// </param>
	/// <param name="lpfnEnum">A pointer to a MonitorEnumProc application-defined callback function.</param>
	/// <param name="dwData">Application-defined data that <c>EnumDisplayMonitors</c> passes directly to the MonitorEnumProc function.</param>
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
	/// formats. You can continue to paint under the assumption that the entire screen has the color properties of the primary monitor. Your
	/// windows will look fine. <c>EnumDisplayMonitors</c> just lets you make them look better.
	/// </para>
	/// <para>
	/// Setting the hdc parameter to <c>NULL</c> lets you use the <c>EnumDisplayMonitors</c> function to obtain a handle and position
	/// rectangle for one or more display monitors. The following table shows how the four combinations of <c>NULL</c> and non- <c>NULL</c>
	/// hdc and lprcClip values affect the behavior of the <c>EnumDisplayMonitors</c> function.
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
	/// Enumerates all display monitors that intersect the clipping rectangle. Use virtual screen coordinates for the clipping rectangle.The
	/// callback function receives a NULL HDC.
	/// </term>
	/// </item>
	/// <item>
	/// <term>non-NULL</term>
	/// <term>NULL</term>
	/// <term>
	/// Enumerates all display monitors that intersect the visible region of the device context.The callback function receives a handle to a
	/// DC for the specific display monitor.
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
	public static extern bool EnumDisplayMonitors(HDC hdc, PRECT lprcClip, MonitorEnumProc lpfnEnum, IntPtr dwData);

	/// <summary>
	/// <para>
	/// The <c>EnumDisplaySettings</c> function retrieves information about one of the graphics modes for a display device. To retrieve
	/// information for all the graphics modes of a display device, make a series of calls to this function.
	/// </para>
	/// <para>
	/// <c>Note</c> Apps that you design to target Windows 8 and later can no longer query or set display modes that are less than 32 bits
	/// per pixel (bpp); these operations will fail. These apps have a compatibility manifest that targets Windows 8. Windows 8 still
	/// supports 8-bit and 16-bit color modes for desktop apps that were built without a Windows 8 manifest; Windows 8 emulates these modes
	/// but still runs in 32-bit color mode.
	/// </para>
	/// </summary>
	/// <param name="lpszDeviceName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the display device about whose graphics mode the function will obtain information.
	/// </para>
	/// <para>
	/// This parameter is either <c>NULL</c> or a DISPLAY_DEVICE. <c>DeviceName</c> returned from EnumDisplayDevices. A <c>NULL</c> value
	/// specifies the current display device on the computer on which the calling thread is running.
	/// </para>
	/// </param>
	/// <param name="iModeNum">
	/// <para>The type of information to be retrieved. This value can be a graphics mode index or one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ENUM_CURRENT_SETTINGS</term>
	/// <term>Retrieve the current settings for the display device.</term>
	/// </item>
	/// <item>
	/// <term>ENUM_REGISTRY_SETTINGS</term>
	/// <term>Retrieve the settings for the display device that are currently stored in the registry.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Graphics mode indexes start at zero. To obtain information for all of a display device's graphics modes, make a series of calls to
	/// <c>EnumDisplaySettings</c>, as follows: Set iModeNum to zero for the first call, and increment iModeNum by one for each subsequent
	/// call. Continue calling the function until the return value is zero.
	/// </para>
	/// <para>
	/// When you call <c>EnumDisplaySettings</c> with iModeNum set to zero, the operating system initializes and caches information about the
	/// display device. When you call <c>EnumDisplaySettings</c> with iModeNum set to a nonzero value, the function returns the information
	/// that was cached the last time the function was called with iModeNum set to zero.
	/// </para>
	/// </param>
	/// <param name="lpDevMode">
	/// <para>
	/// A pointer to a DEVMODE structure into which the function stores information about the specified graphics mode. Before calling
	/// <c>EnumDisplaySettings</c>, set the <c>dmSize</c> member to , and set the <c>dmDriverExtra</c> member to indicate the size, in bytes,
	/// of the additional space available to receive private driver data.
	/// </para>
	/// <para>The <c>EnumDisplaySettings</c> function sets values for the following five DEVMODE members:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>dmBitsPerPel</c></term>
	/// </item>
	/// <item>
	/// <term><c>dmPelsWidth</c></term>
	/// </item>
	/// <item>
	/// <term><c>dmPelsHeight</c></term>
	/// </item>
	/// <item>
	/// <term><c>dmDisplayFlags</c></term>
	/// </item>
	/// <item>
	/// <term><c>dmDisplayFrequency</c></term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The function fails if iModeNum is greater than the index of the display device's last graphics mode. As noted in the description of
	/// the iModeNum parameter, you can use this behavior to enumerate all of a display device's graphics modes.
	/// </para>
	/// <para>DPI Virtualization</para>
	/// <para>
	/// This API does not participate in DPI virtualization. The output given is always in terms of physical pixels, and is not related to
	/// the calling context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enumdisplaysettingsa BOOL EnumDisplaySettingsA( LPCSTR
	// lpszDeviceName, DWORD iModeNum, DEVMODEA *lpDevMode );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "af73610b-bcd8-4660-800e-84fa0cc5b4eb")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumDisplaySettings([Optional] string lpszDeviceName, uint iModeNum, ref DEVMODE lpDevMode);

	/// <summary>
	/// <para>
	/// The <c>EnumDisplaySettingsEx</c> function retrieves information about one of the graphics modes for a display device. To retrieve
	/// information for all the graphics modes for a display device, make a series of calls to this function.
	/// </para>
	/// <para>This function differs from EnumDisplaySettings in that there is a dwFlags parameter.</para>
	/// <para>
	/// <c>Note</c> Apps that you design to target Windows 8 and later can no longer query or set display modes that are less than 32 bits
	/// per pixel (bpp); these operations will fail. These apps have a compatibility manifest that targets Windows 8. Windows 8 still
	/// supports 8-bit and 16-bit color modes for desktop apps that were built without a Windows 8 manifest; Windows 8 emulates these modes
	/// but still runs in 32-bit color mode.
	/// </para>
	/// </summary>
	/// <param name="lpszDeviceName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the display device about which graphics mode the function will obtain information.
	/// </para>
	/// <para>
	/// This parameter is either <c>NULL</c> or a DISPLAY_DEVICE. <c>DeviceName</c> returned from EnumDisplayDevices. A <c>NULL</c> value
	/// specifies the current display device on the computer that the calling thread is running on.
	/// </para>
	/// </param>
	/// <param name="iModeNum">
	/// <para>Indicates the type of information to be retrieved. This value can be a graphics mode index or one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ENUM_CURRENT_SETTINGS</term>
	/// <term>Retrieve the current settings for the display device.</term>
	/// </item>
	/// <item>
	/// <term>ENUM_REGISTRY_SETTINGS</term>
	/// <term>Retrieve the settings for the display device that are currently stored in the registry.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Graphics mode indexes start at zero. To obtain information for all of a display device's graphics modes, make a series of calls to
	/// <c>EnumDisplaySettingsEx</c>, as follows: Set iModeNum to zero for the first call, and increment iModeNum by one for each subsequent
	/// call. Continue calling the function until the return value is zero.
	/// </para>
	/// <para>
	/// When you call <c>EnumDisplaySettingsEx</c> with iModeNum set to zero, the operating system initializes and caches information about
	/// the display device. When you call <c>EnumDisplaySettingsEx</c> with iModeNum set to a nonzero value, the function returns the
	/// information that was cached the last time the function was called with iModeNum set to zero.
	/// </para>
	/// </param>
	/// <param name="lpDevMode">
	/// <para>
	/// A pointer to a DEVMODE structure into which the function stores information about the specified graphics mode. Before calling
	/// <c>EnumDisplaySettingsEx</c>, set the <c>dmSize</c> member to <c>sizeof</c> (DEVMODE), and set the <c>dmDriverExtra</c> member to
	/// indicate the size, in bytes, of the additional space available to receive private driver data.
	/// </para>
	/// <para>
	/// The <c>EnumDisplaySettingsEx</c> function will populate the <c>dmFields</c> member of the <c>lpDevMode</c> and one or more other
	/// members of the DEVMODE structure. To determine which members were set by the call to <c>EnumDisplaySettingsEx</c>, inspect the
	/// dmFields bitmask. Some of the fields typically populated by this function include:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>dmBitsPerPel</c></term>
	/// </item>
	/// <item>
	/// <term><c>dmPelsWidth</c></term>
	/// </item>
	/// <item>
	/// <term><c>dmPelsHeight</c></term>
	/// </item>
	/// <item>
	/// <term><c>dmDisplayFlags</c></term>
	/// </item>
	/// <item>
	/// <term><c>dmDisplayFrequency</c></term>
	/// </item>
	/// <item>
	/// <term><c>dmPosition</c></term>
	/// </item>
	/// <item>
	/// <term><c>dmDisplayOrientation</c></term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>EDS_RAWMODE</term>
	/// <term>
	/// If set, the function will return all graphics modes reported by the adapter driver, regardless of monitor capabilities. Otherwise, it
	/// will only return modes that are compatible with current monitors.
	/// </term>
	/// </item>
	/// <item>
	/// <term>EDS_ROTATEDMODE</term>
	/// <term>
	/// If set, the function will return graphics modes in all orientations. Otherwise, it will only return modes that have the same
	/// orientation as the one currently set for the requested display.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The function fails if iModeNum is greater than the index of the display device's last graphics mode. As noted in the description of
	/// the iModeNum parameter, you can use this behavior to enumerate all of a display device's graphics modes.
	/// </para>
	/// <para>DPI Virtualization</para>
	/// <para>
	/// This API does not participate in DPI virtualization. The output given is always in terms of physical pixels, and is not related to
	/// the calling context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enumdisplaysettingsexa BOOL EnumDisplaySettingsExA( LPCSTR
	// lpszDeviceName, DWORD iModeNum, DEVMODEA *lpDevMode, DWORD dwFlags );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "99794fb1-7ba3-4864-bf6a-e3a514fa7917")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumDisplaySettingsEx([Optional] string lpszDeviceName, uint iModeNum, ref DEVMODE lpDevMode, EDS dwFlags);

	/// <summary>The <c>GetMonitorInfo</c> function retrieves information about a display monitor.</summary>
	/// <param name="hMonitor">A handle to the display monitor of interest.</param>
	/// <param name="lpmi">
	/// <para>A pointer to a MONITORINFO or MONITORINFOEX structure that receives information about the specified display monitor.</para>
	/// <para>
	/// You must set the <c>cbSize</c> member of the structure to sizeof(MONITORINFO) or sizeof(MONITORINFOEX) before calling the
	/// <c>GetMonitorInfo</c> function. Doing so lets the function determine the type of structure you are passing to it. You can do this by
	/// calling <see cref="MONITORINFO.Default"/> to get a new instance with properly set of <see cref="MONITORINFO.cbSize"/>.
	/// </para>
	/// <para>
	/// The MONITORINFOEX structure is a superset of the MONITORINFO structure. It has one additional member: a string that contains a name
	/// for the display monitor. Most applications have no use for a display monitor name, and so can save some bytes by using a
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

	/// <summary>The <c>GetMonitorInfo</c> function retrieves information about a display monitor.</summary>
	/// <param name="hMonitor">A handle to the display monitor of interest.</param>
	/// <param name="lpmi">
	/// <para>A pointer to a MONITORINFO or MONITORINFOEX structure that receives information about the specified display monitor.</para>
	/// <para>
	/// You must set the <c>cbSize</c> member of the structure to sizeof(MONITORINFO) or sizeof(MONITORINFOEX) before calling the
	/// <c>GetMonitorInfo</c> function. Doing so lets the function determine the type of structure you are passing to it. You can do this by
	/// calling <see cref="MONITORINFOEX.Default"/> to get a new instance with properly set of <see cref="MONITORINFOEX.cbSize"/>.
	/// </para>
	/// <para>
	/// The MONITORINFOEX structure is a superset of the MONITORINFO structure. It has one additional member: a string that contains a name
	/// for the display monitor. Most applications have no use for a display monitor name, and so can save some bytes by using a
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
	public static extern bool GetMonitorInfo(HMONITOR hMonitor, ref MONITORINFOEX lpmi);

	/// <summary>The <c>MonitorFromPoint</c> function retrieves a handle to the display monitor that contains a specified point.</summary>
	/// <param name="pt">A POINT structure that specifies the point of interest in virtual-screen coordinates.</param>
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
	public static extern HMONITOR MonitorFromPoint(POINT pt, MonitorFlags dwFlags);

	/// <summary>
	/// The <c>MonitorFromRect</c> function retrieves a handle to the display monitor that has the largest area of intersection with a
	/// specified rectangle.
	/// </summary>
	/// <param name="lprc">A pointer to a RECT structure that specifies the rectangle of interest in virtual-screen coordinates.</param>
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
	public static extern HMONITOR MonitorFromRect(in RECT lprc, MonitorFlags dwFlags);

	/// <summary>
	/// The <c>MonitorFromWindow</c> function retrieves a handle to the display monitor that has the largest area of intersection with the
	/// bounding rectangle of a specified window.
	/// </summary>
	/// <param name="hwnd">A handle to the window of interest.</param>
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
	/// If the window intersects one or more display monitor rectangles, the return value is an <c>HMONITOR</c> handle to the display monitor
	/// that has the largest area of intersection with the window.
	/// </para>
	/// <para>If the window does not intersect a display monitor, the return value depends on the value of dwFlags.</para>
	/// </returns>
	/// <remarks>If the window is currently minimized, <c>MonitorFromWindow</c> uses the rectangle of the window before it was minimized.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-monitorfromwindow HMONITOR MonitorFromWindow( HWND hwnd,
	// DWORD dwFlags );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "fe6505c9-b481-4fec-ae9d-995943234a3a")]
	public static extern HMONITOR MonitorFromWindow(HWND hwnd, MonitorFlags dwFlags);

	/// <summary>
	/// <para>The <c>MONITORINFO</c> structure contains information about a display monitor.</para>
	/// <para>The GetMonitorInfo function stores information in a <c>MONITORINFO</c> structure or a MONITORINFOEX structure.</para>
	/// <para>
	/// The <c>MONITORINFO</c> structure is a subset of the MONITORINFOEX structure. The <c>MONITORINFOEX</c> structure adds a string member
	/// to contain a name for the display monitor.
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
		/// A RECT structure that specifies the display monitor rectangle, expressed in virtual-screen coordinates. Note that if the
		/// monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
		/// </summary>
		public RECT rcMonitor;

		/// <summary>
		/// A RECT structure that specifies the work area rectangle of the display monitor, expressed in virtual-screen coordinates. Note
		/// that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
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

		/// <summary>Gets an instance of <see cref="MONITORINFO"/> structure with <see cref="cbSize"/> set correctly.</summary>
		/// <returns>Returns new instance of properly initialized <see cref="MONITORINFO"/> structure.</returns>
		/// <seealso cref="GetMonitorInfo(HMONITOR, ref MONITORINFO)"/>
		public static MONITORINFO Default => new() { cbSize = (uint)Marshal.SizeOf(typeof(MONITORINFO)) };
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
		/// A RECT structure that specifies the display monitor rectangle, expressed in virtual-screen coordinates. Note that if the
		/// monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
		/// </summary>
		public RECT rcMonitor;

		/// <summary>
		/// A RECT structure that specifies the work area rectangle of the display monitor, expressed in virtual-screen coordinates. Note
		/// that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
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

		/// <summary>
		/// A string that specifies the device name of the monitor being used. Most applications have no use for a display monitor name,
		/// and so can save some bytes by using a MONITORINFO structure.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string szDevice;

		/// <summary>Gets an instance of <see cref="MONITORINFOEX"/> structure with <see cref="cbSize"/> set correctly.</summary>
		/// <returns>Returns new instance of properly initialized <see cref="MONITORINFOEX"/> structure.</returns>
		/// <seealso cref="GetMonitorInfo(HMONITOR, ref MONITORINFOEX)"/>
		public static MONITORINFOEX Default => new() { cbSize = (uint)Marshal.SizeOf(typeof(MONITORINFOEX)) };
	}
}