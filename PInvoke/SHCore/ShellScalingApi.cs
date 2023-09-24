namespace Vanara.PInvoke;

/// <summary>Items from the SHCore.dll</summary>
public static partial class SHCore
{
	private const string Lib_SHCore = "shcore.dll";

	/// <summary>
	/// <para>Indicates whether the device is a primary or immersive type of display.</para>
	/// <para><c>Note</c> The functions that use these enumeration values are no longer supported as of Windows 8.1.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/ne-shellscalingapi-display_device_type typedef enum {
	// DEVICE_PRIMARY, DEVICE_IMMERSIVE } DISPLAY_DEVICE_TYPE;
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NE:shellscalingapi.__unnamed_enum_0")]
	public enum DISPLAY_DEVICE_TYPE
	{
		/// <summary>The device is a primary display device.</summary>
		DEVICE_PRIMARY = 0,

		/// <summary>The device is an immersive display device.</summary>
		DEVICE_IMMERSIVE,
	}

	/// <summary>Identifies the dots per inch (dpi) setting for a monitor.</summary>
	/// <remarks>All of these settings are affected by the PROCESS_DPI_AWARENESS of your application</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/ne-shellscalingapi-monitor_dpi_type typedef enum
	// MONITOR_DPI_TYPE { MDT_EFFECTIVE_DPI, MDT_ANGULAR_DPI, MDT_RAW_DPI, MDT_DEFAULT } ;
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NE:shellscalingapi.MONITOR_DPI_TYPE")]
	public enum MONITOR_DPI_TYPE
	{
		/// <summary>
		/// The effective DPI. This value should be used when determining the correct scale factor for scaling UI elements. This
		/// incorporates the scale factor set by the user for this specific display.
		/// </summary>
		MDT_EFFECTIVE_DPI = 0,

		/// <summary>
		/// The angular DPI. This DPI ensures rendering at a compliant angular resolution on the screen. This does not include the scale
		/// factor set by the user for this specific display.
		/// </summary>
		MDT_ANGULAR_DPI,

		/// <summary>
		/// The raw DPI. This value is the linear DPI of the screen as measured on the screen itself. Use this value when you want to
		/// read the pixel density and not the recommended scaling setting. This does not include the scale factor set by the user for
		/// this specific display and is not guaranteed to be a supported DPI value.
		/// </summary>
		MDT_RAW_DPI,

		/// <summary>The default DPI setting for a monitor is MDT_EFFECTIVE_DPI.</summary>
		MDT_DEFAULT = MDT_EFFECTIVE_DPI,
	}

	/// <summary>
	/// <para>
	/// Identifies dots per inch (dpi) awareness values. DPI awareness indicates how much scaling work an application performs for DPI
	/// versus how much is done by the system.
	/// </para>
	/// <para>
	/// Users have the ability to set the DPI scale factor on their displays independent of each other. Some legacy applications are not
	/// able to adjust their scaling for multiple DPI settings. In order for users to use these applications without content appearing
	/// too large or small on displays, Windows can apply DPI virtualization to an application, causing it to be automatically be scaled
	/// by the system to match the DPI of the current display. The <c>PROCESS_DPI_AWARENESS</c> value indicates what level of scaling
	/// your application handles on its own and how much is provided by Windows. Keep in mind that applications scaled by the system may
	/// appear blurry and will read virtualized data about the monitor to maintain compatibility.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para><c>Important</c>
	/// <para></para>
	/// Previous versions of Windows required you to set the DPI awareness for the entire application. Now the DPI awareness is tied to
	/// individual threads, processes, or windows. This means that the DPI awareness can change while the app is running and that
	/// multiple windows can have their own independent DPI awareness values. See DPI_AWARENESS for more information about how DPI
	/// awareness currently works. The recommendations below about setting the DPI awareness in the application manifest are still
	/// supported, but the current recommendation is to use the <c>DPI_AWARENESS_CONTEXT</c>.
	/// </para>
	/// <para>
	/// The DPI awareness for an application should be set through the application manifest so that it is determined before any actions
	/// are taken which depend on the DPI of the system. Alternatively, you can set the DPI awareness using SetProcessDpiAwareness, but
	/// if you do so, you need to make sure to set it before taking any actions dependent on the system DPI. Once you set the DPI
	/// awareness for a process, it cannot be changed.
	/// </para>
	/// <para><c>Tip</c>
	/// <para></para>
	/// If your app is <c>PROCESS_DPI_UNAWARE</c>, there is no need to set any value in the application manifest.
	/// <c>PROCESS_DPI_UNAWARE</c> is the default value for apps unless another value is specified.
	/// </para>
	/// <para>
	/// <c>PROCESS_DPI_UNAWARE</c> and <c>PROCESS_SYSTEM_DPI_AWARE</c> apps do not need to respond to WM_DPICHANGED and are not expected
	/// to handle changes in DPI. The system will automatically scale these types of apps up or down as necessary when the DPI changes.
	/// <c>PROCESS_PER_MONITOR_DPI_AWARE</c> apps are responsible for recognizing and responding to changes in DPI, signaled by
	/// <c>WM_DPICHANGED</c>. These will not be scaled by the system. If an app of this type does not resize the window and its content,
	/// it will appear to grow or shrink by the relative DPI changes as the window is moved from one display to the another with a
	/// different DPI setting.
	/// </para>
	/// <para><c>Tip</c>
	/// <para></para>
	/// In previous versions of Windows, there was no setting for <c>PROCESS_PER_MONITOR_DPI_AWARE</c>. Apps were either DPI unaware or
	/// DPI aware. Legacy applications that were classified as DPI aware before Windows 8.1 are considered to have a
	/// <c>PROCESS_DPI_AWARENESS</c> setting of <c>PROCESS_SYSTEM_DPI_AWARE</c> in current versions of Windows.
	/// </para>
	/// <para>
	/// To understand the importance and impact of the different DPI awareness values, consider a user who has three displays: A, B, and
	/// C. Display A is set to 100% scaling factor (96 DPI), display B is set to 200% scaling factor (192 DPI), and display C is set to
	/// 300% scaling factor (288 DPI). The system DPI is set to 200%.
	/// </para>
	/// <para>
	/// An application that is <c>PROCESS_DPI_UNAWARE</c> will always use a scaling factor of 100% (96 DPI). In this scenario, a
	/// <c>PROCESS_DPI_UNAWARE</c> window is created with a size of 500 by 500. On display A, it will render natively with no scaling.
	/// On displays B and C, it will be scaled up by the system automatically by a factor of 2 and 3 respectively. This is because a
	/// <c>PROCESS_DPI_UNAWARE</c> always assumes a DPI of 96, and the system accounts for that. If the app queries for window size, it
	/// will always get a value of 500 by 500 regardless of what display it is in. If this app were to ask for the DPI of any of the
	/// three monitors, it will receive 96.
	/// </para>
	/// <para>
	/// Now consider an application that is <c>PROCESS_SYSTEM_DPI_AWARE</c>. Remember that in the sample, the system DPI is 200% or 192
	/// DPI. This means that any windows created by this app will render natively on display B. It the window moves to display A, it
	/// will automatically be scaled down by a factor of 2. This is because a <c>PROCESS_SYSTEM_DPI_AWARE</c> app in this scenario
	/// assumes that the DPI will always be 192. It queries for the DPI on startup, and then never changes it. The system accommodates
	/// this by automatically scaling down when moving to display A. Likewise, if the window moves to display C, the system will
	/// automatically scale up by a factor of 1.5. If the app queries for window size, it will always get the same value, similar to
	/// <c>PROCESS_DPI_UNAWARE</c>. If it asks for the DPI of any of the three monitors, it will receive 192.
	/// </para>
	/// <para>
	/// Unlike the other awareness values, <c>PROCESS_PER_MONITOR_DPI_AWARE</c> should adapt to the display that it is on. This means
	/// that it is always rendered natively and is never scaled by the system. The responsibility is on the app to adjust the scale
	/// factor when receiving the WM_DPICHANGED message. Part of this message includes a suggested rect for the window. This suggestion
	/// is the current window scaled from the old DPI value to the new DPI value. For example, a window that is 500 by 500 on display A
	/// and moved to display B will receive a suggested window rect that is 1000 by 1000. If that same window is moved to display C, the
	/// suggested window rect attached to <c>WM_DPICHANGED</c> will be 1500 by 1500. Furthermore, when this app queries for the window
	/// size, it will always get the actual native value. Likewise, if it asks for the DPI of any of the three monitors, it will receive
	/// 96, 192, and 288 respectively.
	/// </para>
	/// <para>
	/// Because of DPI virtualization, if one application queries another with a different awareness level for DPI-dependent
	/// information, the system will automatically scale values to match the awareness level of the caller. One example of this is if
	/// you call GetWindowRect and pass in a window created by another application. Using the situation described above, assume that a
	/// <c>PROCESS_DPI_UNAWARE</c> app created a 500 by 500 window on display C. If you query for the window rect from a different
	/// application, the size of the rect will vary based upon the DPI awareness of your app.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>PROCESS_DPI_UNAWARE</term>
	/// <term>
	/// You will get a 500 by 500 rect because the system will assume a DPI of 96 and automatically scale the actual rect down by a
	/// factor of 3.
	/// </term>
	/// </listheader>
	/// <item>
	/// <term>PROCESS_SYSTEM_DPI_AWARE</term>
	/// <term>
	/// You will get a 1000 by 1000 rect because the system will assume a DPI of 192 and automatically scale the actual rect down by a
	/// factor of 3/2.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PROCESS_PER_MONITOR_DPI_AWARE</term>
	/// <term>
	/// You will get a 1500 by 1500 rect because the system will use the actual DPI of the display and not do any scaling behind the scenes.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>This snippet demonstrates how to set a value of <c>PROCESS_SYSTEM_DPI_AWARE</c> in your application manifest.</para>
	/// <para>
	/// <code>&lt;dpiAware&gt;true&lt;/dpiAware&gt;</code>
	/// </para>
	/// <para>This snippet demonstrates how to set a value of <c>PROCESS_PER_MONITOR_DPI_AWARE</c> in your application manifest.</para>
	/// <para>
	/// <code>&lt;dpiAware&gt;true/PM&lt;/dpiAware&gt;</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/ne-shellscalingapi-process_dpi_awareness typedef enum
	// PROCESS_DPI_AWARENESS { PROCESS_DPI_UNAWARE, PROCESS_SYSTEM_DPI_AWARE, PROCESS_PER_MONITOR_DPI_AWARE } ;
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NE:shellscalingapi.PROCESS_DPI_AWARENESS")]
	public enum PROCESS_DPI_AWARENESS
	{
		/// <summary>
		/// DPI unaware. This app does not scale for DPI changes and is always assumed to have a scale factor of 100% (96 DPI). It will
		/// be automatically scaled by the system on any other DPI setting.
		/// </summary>
		PROCESS_DPI_UNAWARE = 0,

		/// <summary>
		/// System DPI aware. This app does not scale for DPI changes. It will query for the DPI once and use that value for the
		/// lifetime of the app. If the DPI changes, the app will not adjust to the new DPI value. It will be automatically scaled up or
		/// down by the system when the DPI changes from the system value.
		/// </summary>
		PROCESS_SYSTEM_DPI_AWARE,

		/// <summary>
		/// Per monitor DPI aware. This app checks for the DPI when it is created and adjusts the scale factor whenever the DPI changes.
		/// These applications are not automatically scaled by the system.
		/// </summary>
		PROCESS_PER_MONITOR_DPI_AWARE,
	}

	/// <summary>Flags that are used to indicate the scaling change that occurred.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/ne-shellscalingapi-scale_change_flags typedef enum {
	// SCF_VALUE_NONE, SCF_SCALE, SCF_PHYSICAL } SCALE_CHANGE_FLAGS;
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NE:shellscalingapi.__unnamed_enum_1")]
	[Flags]
	public enum SCALE_CHANGE_FLAGS
	{
		/// <summary>No change.</summary>
		SCF_VALUE_NONE = 0x00,

		/// <summary>The scale factor has changed.</summary>
		SCF_SCALE = 0x01,

		/// <summary>
		/// The physical dpi of the device has changed. A change in the physical dpi is generally caused either by switching display
		/// devices or switching display resolutions.
		/// </summary>
		SCF_PHYSICAL = 0x02,
	}

	/// <summary>
	/// <para>
	/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
	/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
	/// </para>
	/// <para>Identifies the type of UI component that is needed in the shell.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/ne-shellscalingapi-shell_ui_component typedef enum {
	// SHELL_UI_COMPONENT_TASKBARS, SHELL_UI_COMPONENT_NOTIFICATIONAREA, SHELL_UI_COMPONENT_DESKBAND } SHELL_UI_COMPONENT;
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NE:shellscalingapi.__unnamed_enum_2")]
	public enum SHELL_UI_COMPONENT
	{
		/// <summary>This UI component is a taskbar icon.</summary>
		SHELL_UI_COMPONENT_TASKBARS = 0,

		/// <summary>This UI component is an icon in the notification area.</summary>
		SHELL_UI_COMPONENT_NOTIFICATIONAREA,

		/// <summary>This UI component is a deskband icon.</summary>
		SHELL_UI_COMPONENT_DESKBAND,
	}

	/// <summary>Queries the dots per inch (dpi) of a display.</summary>
	/// <param name="hmonitor">Handle of the monitor being queried.</param>
	/// <param name="dpiType">The type of DPI being queried. Possible values are from the MONITOR_DPI_TYPE enumeration.</param>
	/// <param name="dpiX">
	/// The value of the DPI along the X axis. This value always refers to the horizontal edge, even when the screen is rotated.
	/// </param>
	/// <param name="dpiY">
	/// The value of the DPI along the Y axis. This value always refers to the vertical edge, even when the screen is rotated.
	/// </param>
	/// <returns>
	/// <para>This function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function successfully returns the X and Y DPI values for the specified monitor.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The handle, DPI type, or pointers passed in are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This API is not DPI aware and should not be used if the calling thread is per-monitor DPI aware. For the DPI-aware version of
	/// this API, see GetDpiForWindow.
	/// </para>
	/// <para>
	/// When you call <c>GetDpiForMonitor</c>, you will receive different DPI values depending on the DPI awareness of the calling
	/// application. DPI awareness is an application-level property usually defined in the application manifest. For more information
	/// about DPI awareness values, see PROCESS_DPI_AWARENESS. The following table indicates how the results will differ based on the
	/// <c>PROCESS_DPI_AWARENESS</c> value of your application.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>PROCESS_DPI_UNAWARE</term>
	/// <term>96 because the app is unaware of any other scale factors.</term>
	/// </listheader>
	/// <item>
	/// <term>PROCESS_SYSTEM_DPI_AWARE</term>
	/// <term>A value set to the system DPI because the app assumes all applications use the system DPI.</term>
	/// </item>
	/// <item>
	/// <term>PROCESS_PER_MONITOR_DPI_AWARE</term>
	/// <term>The actual DPI value set by the user for that display.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The values of *dpiX and *dpiY are identical. You only need to record one of the values to determine the DPI and respond appropriately.
	/// </para>
	/// <para>
	/// When MONITOR_DPI_TYPE is <c>MDT_ANGULAR_DPI</c> or <c>MDT_RAW_DPI</c>, the returned DPI value does not include any changes that
	/// the user made to the DPI by using the desktop scaling override slider control in Control Panel.
	/// </para>
	/// <para>
	/// For more information about DPI settings in Control Panel, see the Writing DPI-Aware Desktop Applications in Windows 8.1 Preview
	/// white paper.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-getdpiformonitor HRESULT GetDpiForMonitor(
	// HMONITOR hmonitor, MONITOR_DPI_TYPE dpiType, UINT *dpiX, UINT *dpiY );
	[DllImport(Lib_SHCore, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NF:shellscalingapi.GetDpiForMonitor")]
	public static extern HRESULT GetDpiForMonitor(HMONITOR hmonitor, MONITOR_DPI_TYPE dpiType, out uint dpiX, out uint dpiY);

	/// <summary>Retrieves the dots per inch (dpi) occupied by a SHELL_UI_COMPONENT based on the current scale factor and PROCESS_DPI_AWARENESS.</summary>
	/// <param name="Arg1">The type of shell component.</param>
	/// <returns>The DPI required for an icon of this type.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-getdpiforshelluicomponent UINT
	// GetDpiForShellUIComponent( SHELL_UI_COMPONENT Arg1 );
	[DllImport(Lib_SHCore, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NF:shellscalingapi.GetDpiForShellUIComponent")]
	public static extern uint GetDpiForShellUIComponent(SHELL_UI_COMPONENT Arg1);

	/// <summary>Retrieves the dots per inch (dpi) awareness of the specified process.</summary>
	/// <param name="hprocess">Handle of the process that is being queried. If this parameter is NULL, the current process is queried.</param>
	/// <param name="value">The DPI awareness of the specified process. Possible values are from the PROCESS_DPI_AWARENESS enumeration.</param>
	/// <returns>
	/// <para>This function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function successfully retrieved the DPI awareness of the specified process.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The handle or pointer passed in is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The application does not have sufficient privileges.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function is identical to the following code:</para>
	/// <para>
	/// <code>GetAwarenessFromDpiAwarenessContext(GetThreadDpiAwarenessContext());</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-getprocessdpiawareness HRESULT
	// GetProcessDpiAwareness( HANDLE hprocess, PROCESS_DPI_AWARENESS *value );
	[DllImport(Lib_SHCore, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NF:shellscalingapi.GetProcessDpiAwareness")]
	public static extern HRESULT GetProcessDpiAwareness([In, Optional] HPROCESS hprocess, out PROCESS_DPI_AWARENESS value);

	/// <summary>
	/// <para>Gets the preferred scale factor for a display device.</para>
	/// <para><c>Note</c> This function is not supported as of Windows 8.1. Use GetScaleFactorForMonitor instead.</para>
	/// </summary>
	/// <param name="deviceType">
	/// <para>Type: <c>DISPLAY_DEVICE_TYPE</c></para>
	/// <para>The value that indicates the type of the display device.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DEVICE_SCALE_FACTOR</c></para>
	/// <para>A value that indicates the scale factor that should be used with the specified DISPLAY_DEVICE_TYPE.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>SCALE_100_PERCENT 100</term>
	/// <term>Use a scale factor of 1x.</term>
	/// </item>
	/// <item>
	/// <term>SCALE_140_PERCENT 140</term>
	/// <term>Use a scale factor of 1.4x.</term>
	/// </item>
	/// <item>
	/// <term>SCALE_180_PERCENT 180</term>
	/// <term>Use a scale factor of 1.8x.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The default DEVICE_SCALE_FACTOR is SCALE_100_PERCENT.</para>
	/// <para>Use the scale factor that is returned to scale point values for fonts and pixel values.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-getscalefactorfordevice DEVICE_SCALE_FACTOR
	// GetScaleFactorForDevice( DISPLAY_DEVICE_TYPE deviceType );
	[DllImport(Lib_SHCore, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NF:shellscalingapi.GetScaleFactorForDevice")]
	public static extern DEVICE_SCALE_FACTOR GetScaleFactorForDevice(DISPLAY_DEVICE_TYPE deviceType);

	/// <summary>Gets the scale factor of a specific monitor. This function replaces GetScaleFactorForDevice.</summary>
	/// <param name="hMon">The monitor's handle.</param>
	/// <param name="pScale">
	/// <para>
	/// When this function returns successfully, this value points to one of the DEVICE_SCALE_FACTOR values that specify the scale
	/// factor of the specified monitor.
	/// </para>
	/// <para>
	/// If the function call fails, this value points to a valid scale factor so that apps can opt to continue on with incorrectly sized resources.
	/// </para>
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// Your code needs to handle the WM_WINDOWPOSCHANGED message in addition to the scale change event registered through
	/// RegisterScaleChangeEvent, because the app window can be moved between monitors. In response to the <c>WM_WINDOWPOSCHANGED</c>
	/// message, call MonitorFromWindow, followed by <c>GetScaleFactorForMonitor</c> to get the scale factor of the monitor which the
	/// app window is on. Your code can then react to any dots per inch (dpi) change by reloading assets and changing layout.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-getscalefactorformonitor HRESULT
	// GetScaleFactorForMonitor( HMONITOR hMon, DEVICE_SCALE_FACTOR *pScale );
	[DllImport(Lib_SHCore, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NF:shellscalingapi.GetScaleFactorForMonitor")]
	public static extern HRESULT GetScaleFactorForMonitor(HMONITOR hMon, out DEVICE_SCALE_FACTOR pScale);

	/// <summary>Registers for an event that is triggered when the scale has possibly changed. This function replaces RegisterScaleChangeNotifications.</summary>
	/// <param name="hEvent">Handle of the event to register for scale change notifications.</param>
	/// <param name="pdwCookie">
	/// When this function returns successfully, this value receives the address of a pointer to a cookie that can be used later to
	/// unregister for the scale change notifications through UnregisterScaleChangeEvent.
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// The event is raised whenever something that can affect scale changes, but just because the scale can be affected doesn't mean
	/// that it has been. Callers can cache the scale factor to verify that the monitor's scale actually has changed. The event handle
	/// will be duplicated, so callers can close their handle at any time.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-registerscalechangeevent HRESULT
	// RegisterScaleChangeEvent( HANDLE hEvent, DWORD_PTR *pdwCookie );
	[DllImport(Lib_SHCore, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NF:shellscalingapi.RegisterScaleChangeEvent")]
	public static extern HRESULT RegisterScaleChangeEvent(HEVENT hEvent, out IntPtr pdwCookie);

	/// <summary>
	/// <para>Registers a window to receive callbacks when scaling information changes.</para>
	/// <para><c>Note</c> This function is not supported as of Windows 8.1. Use RegisterScaleChangeEvent instead.</para>
	/// </summary>
	/// <param name="displayDevice">
	/// <para>Type: <c>DISPLAY_DEVICE_TYPE</c></para>
	/// <para>The enum value that indicates which display device to receive notifications about.</para>
	/// </param>
	/// <param name="hwndNotify">
	/// <para>Type: <c>HWND</c></para>
	/// <para>The handle of the window that will receive the notifications.</para>
	/// </param>
	/// <param name="uMsgNotify">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// An application-defined message that is passed to the window specified by hwndNotify when scaling information changes. Typically,
	/// this should be set to WM_APP+x, where x is an integer value.
	/// </para>
	/// </param>
	/// <param name="pdwCookie">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>
	/// Pointer to a value that, when this function returns successfully, receives a registration token. This token is used to revoke
	/// notifications by calling RevokeScaleChangeNotifications.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>STDAPI</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// This message specified by uMsgNotify is posted to the registered window through PostMessage. The wParam of the message can
	/// contain a combination of SCALE_CHANGE_FLAGS that describe the change that occurred.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-registerscalechangenotifications HRESULT
	// RegisterScaleChangeNotifications( DISPLAY_DEVICE_TYPE displayDevice, HWND hwndNotify, UINT uMsgNotify, DWORD *pdwCookie );
	[DllImport(Lib_SHCore, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NF:shellscalingapi.RegisterScaleChangeNotifications")]
	public static extern HRESULT RegisterScaleChangeNotifications(DISPLAY_DEVICE_TYPE displayDevice, HWND hwndNotify, uint uMsgNotify, out uint pdwCookie);

	/// <summary>
	/// <para>Revokes the registration of a window, preventing it from receiving callbacks when scaling information changes.</para>
	/// <para><c>Note</c> This function is not supported as of Windows 8.1. Use UnregisterScaleChangeEvent instead.</para>
	/// </summary>
	/// <param name="displayDevice">
	/// <para>Type: <c>DISPLAY_DEVICE_TYPE</c></para>
	/// <para>The enum value that indicates which display device to receive notifications about.</para>
	/// </param>
	/// <param name="dwCookie">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The registration token returned by a previous call to RegisterScaleChangeNotifications.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>STDAPI</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-revokescalechangenotifications HRESULT
	// RevokeScaleChangeNotifications( DISPLAY_DEVICE_TYPE displayDevice, DWORD dwCookie );
	[DllImport(Lib_SHCore, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NF:shellscalingapi.RevokeScaleChangeNotifications")]
	public static extern HRESULT RevokeScaleChangeNotifications(DISPLAY_DEVICE_TYPE displayDevice, uint dwCookie);

	/// <summary>
	/// <para>
	/// It is recommended that you set the process-default DPI awareness via application manifest. See Setting the default DPI awareness
	/// for a process for more information. Setting the process-default DPI awareness via API call can lead to unexpected application behavior.
	/// </para>
	/// <para>
	/// Sets the process-default DPI awareness level. This is equivalent to calling SetProcessDpiAwarenessContext with the corresponding
	/// DPI_AWARENESS_CONTEXT value.
	/// </para>
	/// </summary>
	/// <param name="value">The DPI awareness value to set. Possible values are from the PROCESS_DPI_AWARENESSenumeration.</param>
	/// <returns>
	/// <para>This function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The DPI awareness for the app was set successfully.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The value passed in is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The DPI awareness is already set, either by calling this API previously or through the application (.exe) manifest.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// It is recommended that you set the process-default DPI awareness via application manifest. See Setting the default DPI awareness
	/// for a process for more information. Setting the process-default DPI awareness via API call can lead to unexpected application behavior.
	/// </para>
	/// <para>
	/// Previous versions of Windows only had one DPI awareness value for the entire application. For those applications, the
	/// recommendation was to set the DPI awareness value in the manifest as described in PROCESS_DPI_AWARENESS. Under that
	/// recommendation, you were not supposed to use <c>SetProcessDpiAwareness</c> to update the DPI awareness. In fact, future calls to
	/// this API would fail after the DPI awareness was set once. Now that DPI awareness is tied to a thread rather than an application,
	/// you can use this method to update the DPI awareness. However, consider using SetThreadDpiAwarenessContext instead.
	/// </para>
	/// <para><c>Important</c>
	/// <para></para>
	/// For older applications, it is strongly recommended to not use <c>SetProcessDpiAwareness</c> to set the DPI awareness for your
	/// application. Instead, you should declare the DPI awareness for your application in the application manifest. See
	/// PROCESS_DPI_AWARENESS for more information about the DPI awareness values and how to set them in the manifest.
	/// </para>
	/// <para>
	/// You must call this API before you call any APIs that depend on the dpi awareness. This is part of the reason why it is
	/// recommended to use the application manifest rather than the <c>SetProcessDpiAwareness</c> API. Once API awareness is set for an
	/// app, any future calls to this API will fail. This is true regardless of whether you set the DPI awareness in the manifest or by
	/// using this API.
	/// </para>
	/// <para>If the DPI awareness level is not set, the default value is <c>PROCESS_DPI_UNAWARE</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-setprocessdpiawareness HRESULT
	// SetProcessDpiAwareness( PROCESS_DPI_AWARENESS value );
	[DllImport(Lib_SHCore, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NF:shellscalingapi.SetProcessDpiAwareness")]
	public static extern HRESULT SetProcessDpiAwareness(PROCESS_DPI_AWARENESS value);

	/// <summary>Unregisters for the scale change event registered through RegisterScaleChangeEvent. This function replaces RevokeScaleChangeNotifications.</summary>
	/// <param name="dwCookie">A pointer to the cookie retrieved in the call to RegisterScaleChangeEvent.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-unregisterscalechangeevent HRESULT
	// UnregisterScaleChangeEvent( DWORD_PTR dwCookie );
	[DllImport(Lib_SHCore, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shellscalingapi.h", MSDNShortId = "NF:shellscalingapi.UnregisterScaleChangeEvent")]
	public static extern HRESULT UnregisterScaleChangeEvent(IntPtr dwCookie);
}