namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>
	/// Describes per-monitor DPI scaling behavior overrides for child windows within dialogs. The values in this enumeration are
	/// bitfields and can be combined.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This enum is used with SetDialogControlDpiChangeBehavior in order to override the default per-monitor DPI scaling behavior for a
	/// child window within a dialog.
	/// </para>
	/// <para>
	/// These settings only apply to individual controls within dialogs. The dialog-wide per-monitor DPI scaling behavior of a dialog is
	/// controlled by DIALOG_DPI_CHANGE_BEHAVIORS.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ne-winuser-dialog_control_dpi_change_behaviors typedef enum
	// DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS { DCDC_DEFAULT, DCDC_DISABLE_FONT_UPDATE, DCDC_DISABLE_RELAYOUT } ;
	[PInvokeData("winuser.h", MSDNShortId = "B368D997-F409-491A-8578-004C7408A160")]
	[Flags]
	public enum DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS
	{
		/// <summary>
		/// The default behavior of the dialog manager. The dialog managed will update the font, size, and position of the child window
		/// on DPI changes.
		/// </summary>
		DCDC_DEFAULT = 0,

		/// <summary>
		/// Prevents the dialog manager from sending an updated font to the child window via WM_SETFONT in response to a DPI change.
		/// </summary>
		DCDC_DISABLE_FONT_UPDATE = 1,

		/// <summary>Prevents the dialog manager from resizing and repositioning the child window in response to a DPI change.</summary>
		DCDC_DISABLE_RELAYOUT = 2,
	}

	/// <summary>
	/// <para>
	/// In Per Monitor v2 contexts, dialogs will automatically respond to DPI changes by resizing themselves and re-computing the
	/// positions of their child windows (here referred to as re-layouting). This enum works in conjunction with
	/// SetDialogDpiChangeBehavior in order to override the default DPI scaling behavior for dialogs.
	/// </para>
	/// <para>
	/// This does not affect DPI scaling behavior for the child windows of dialogs (beyond re-layouting), which is controlled by DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ne-winuser-dialog_dpi_change_behaviors typedef enum
	// DIALOG_DPI_CHANGE_BEHAVIORS { DDC_DEFAULT, DDC_DISABLE_ALL, DDC_DISABLE_RESIZE, DDC_DISABLE_CONTROL_RELAYOUT } ;
	[PInvokeData("winuser.h", MSDNShortId = "26248777-E95F-49BE-82D6-7237FAEE0627")]
	[Flags]
	public enum DIALOG_DPI_CHANGE_BEHAVIORS
	{
		/// <summary>
		/// The default behavior of the dialog manager. In response to a DPI change, the dialog manager will re-layout each control,
		/// update the font on each control, resize the dialog, and update the dialog's own font.
		/// </summary>
		DDC_DEFAULT = 0,

		/// <summary>
		/// Prevents the dialog manager from responding to WM_GETDPISCALEDSIZE and WM_DPICHANGED, disabling all default DPI scaling behavior.
		/// </summary>
		DDC_DISABLE_ALL = 1,

		/// <summary>Prevents the dialog manager from resizing the dialog in response to a DPI change.</summary>
		DDC_DISABLE_RESIZE = 2,

		/// <summary>
		/// Prevents the dialog manager from re-layouting all of the dialogue's immediate children HWNDs in response to a DPI change.
		/// </summary>
		DDC_DISABLE_CONTROL_RELAYOUT = 4,
	}

	/// <summary>
	/// <para>Identifies the dots per inch (dpi) setting for a thread, process, or window.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// In previous versions of Windows, DPI values were only set once for an entire application. For those apps, the
	/// PROCESS_DPI_AWARENESS type determined the type of DPI awareness for the entire application. Currently, the DPI awareness is
	/// defined on an individual thread, window, or process level and is indicated by the <c>DPI_AWARENESS</c> type. While the focus
	/// shifted from a process level to a thread level, the different kinds of DPI awareness are the same: unaware, system aware, and per
	/// monitor aware. For detailed descriptions and some examples of the different DPI kinds, see <c>PROCESS_DPI_AWARENESS</c>.
	/// </para>
	/// <para>
	/// The old recommendation was to define the DPI awareness level in the application manifest using the setting dpiAware as explained
	/// in PROCESS_DPI_AWARENESS. Now that the DPI awareness is tied to threads and windows instead of an entire application, a new
	/// windows setting is added to the app manifest. This setting is dpiAwareness and will override any dpiAware setting if both of them
	/// are present in the manifest. While it is still recommended to use the manifest, you can now change the DPI awareness while the
	/// app is running by using SetThreadDpiAwarenessContext.
	/// </para>
	/// <para>
	/// It is important to note that if your application has a <c>DPI_AWARENESS_PER_MONITOR_AWARE</c> window, you are responsible for
	/// keeping track of the DPI by responding to WM_DPICHANGED messages.
	/// </para>
	/// <para>Examples</para>
	/// <para>This snippet demonstrates how to set a value of <c>DPI_AWARENESS_SYSTEM_AWARE</c> in your application manifest.</para>
	/// <para>This snippet demonstrates how to set a value of <c>DPI_AWARENESS_PER_MONITOR_AWARE</c> in your application manifest.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/windef/ne-windef-dpi_awareness typedef enum DPI_AWARENESS {
	// DPI_AWARENESS_INVALID, DPI_AWARENESS_UNAWARE, DPI_AWARENESS_SYSTEM_AWARE, DPI_AWARENESS_PER_MONITOR_AWARE } ;
	[PInvokeData("windef.h", MSDNShortId = "0E7EB331-7D72-4853-8785-03F30263C323")]
	public enum DPI_AWARENESS
	{
		/// <summary>Invalid DPI awareness. This is an invalid DPI awareness value.</summary>
		DPI_AWARENESS_INVALID = -1,

		/// <summary>
		/// DPI unaware. This process does not scale for DPI changes and is always assumed to have a scale factor of 100% (96 DPI). It
		/// will be automatically scaled by the system on any other DPI setting.
		/// </summary>
		DPI_AWARENESS_UNAWARE = 0,

		/// <summary>
		/// System DPI aware. This process does not scale for DPI changes. It will query for the DPI once and use that value for the
		/// lifetime of the process. If the DPI changes, the process will not adjust to the new DPI value. It will be automatically
		/// scaled up or down by the system when the DPI changes from the system value.
		/// </summary>
		DPI_AWARENESS_SYSTEM_AWARE = 1,

		/// <summary>
		/// Per monitor DPI aware. This process checks for the DPI when it is created and adjusts the scale factor whenever the DPI
		/// changes. These processes are not automatically scaled by the system.
		/// </summary>
		DPI_AWARENESS_PER_MONITOR_AWARE = 2,
	}

	/// <summary>
	/// Identifies the DPI hosting behavior for a window. This behavior allows windows created in the thread to host child windows with a
	/// different <c>DPI_AWARENESS_CONTEXT</c>
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>DPI_HOSTING_BEHAVIOR</c> enables a mixed content hosting behavior, which allows parent windows created in the thread to host
	/// child windows with a different DPI_AWARENESS_CONTEXT value. This property only effects new windows created within this thread
	/// while the mixed hosting behavior is active. A parent window with this hosting behavior is able to host child windows with
	/// different <c>DPI_AWARENESS_CONTEXT</c> values, regardless of whether the child windows have mixed hosting behavior enabled.
	/// </para>
	/// <para>
	/// This hosting behavior does not allow for windows with per-monitor <c>DPI_AWARENESS_CONTEXT</c> values to be hosted until windows
	/// with <c>DPI_AWARENESS_CONTEXT</c> values of system or unaware.
	/// </para>
	/// <para>
	/// To avoid unexpected outcomes, a thread's <c>DPI_HOSTING_BEHAVIOR</c> should be changed to support mixed hosting behaviors only
	/// when creating a new window which needs to support those behaviors. Once that window is created, the hosting behavior should be
	/// switched back to its default value.
	/// </para>
	/// <para>
	/// Enabling mixed hosting behavior will not automatically adjust the thread's <c>DPI_AWARENESS_CONTEXT</c> to be compatible with
	/// legacy content. The thread's awareness context must still be manually changed before new windows are created to host such content.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/windef/ne-windef-dpi_hosting_behavior typedef enum DPI_HOSTING_BEHAVIOR {
	// DPI_HOSTING_BEHAVIOR_INVALID, DPI_HOSTING_BEHAVIOR_DEFAULT, DPI_HOSTING_BEHAVIOR_MIXED } ;
	[PInvokeData("windef.h", MSDNShortId = "4BFBF485-1AD2-4460-A4EE-CB76EF62B8C4")]
	public enum DPI_HOSTING_BEHAVIOR
	{
		/// <summary>
		/// Invalid DPI hosting behavior. This usually occurs if the previous SetThreadDpiHostingBehavior call used an invalid parameter.
		/// </summary>
		DPI_HOSTING_BEHAVIOR_INVALID = -1,

		/// <summary>
		/// Default DPI hosting behavior. The associated window behaves as normal, and cannot create or re-parent child windows with a
		/// different DPI_AWARENESS_CONTEXT.
		/// </summary>
		DPI_HOSTING_BEHAVIOR_DEFAULT = 0,

		/// <summary>
		/// Mixed DPI hosting behavior. This enables the creation and re-parenting of child windows with different DPI_AWARENESS_CONTEXT.
		/// These child windows will be independently scaled by the OS.
		/// </summary>
		DPI_HOSTING_BEHAVIOR_MIXED = 1,
	}

	/// <summary>
	/// Calculates the required size of the window rectangle, based on the desired size of the client rectangle and the provided DPI.
	/// This window rectangle can then be passed to the CreateWindowEx function to create a window with a client area of the desired size.
	/// </summary>
	/// <param name="lpRect">
	/// A pointer to a <c>RECT</c> structure that contains the coordinates of the top-left and bottom-right corners of the desired client
	/// area. When the function returns, the structure contains the coordinates of the top-left and bottom-right corners of the window to
	/// accommodate the desired client area.
	/// </param>
	/// <param name="dwStyle">
	/// The Window Style of the window whose required size is to be calculated. Note that you cannot specify the <c>WS_OVERLAPPED</c> style.
	/// </param>
	/// <param name="bMenu">Indicates whether the window has a menu.</param>
	/// <param name="dwExStyle">The Extended Window Style of the window whose required size is to be calculated.</param>
	/// <param name="dpi">The DPI to use for scaling.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// This function returns the same result as AdjustWindowRectEx but scales it according to an arbitrary DPI you provide if appropriate.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-adjustwindowrectexfordpi BOOL AdjustWindowRectExForDpi(
	// LPRECT lpRect, DWORD dwStyle, BOOL bMenu, DWORD dwExStyle, UINT dpi );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "C7126165-1D64-4C04-9B8D-4F90AC2F2C67")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AdjustWindowRectExForDpi(ref RECT lpRect, WindowStyles dwStyle, [MarshalAs(UnmanagedType.Bool)] bool bMenu, WindowStylesEx dwExStyle, uint dpi);

	/// <summary>Determines whether two <c>DPI_AWARENESS_CONTEXT</c> values are identical.</summary>
	/// <param name="dpiContextA">The first value to compare.</param>
	/// <param name="dpiContextB">The second value to compare.</param>
	/// <returns>Returns <c>TRUE</c> if the values are equal, otherwise <c>FALSE</c>.</returns>
	/// <remarks>
	/// A <c>DPI_AWARENESS_CONTEXT</c> contains multiple pieces of information. For example, it includes both the current and the
	/// inherited DPI_AWARENESS values. <c>AreDpiAwarenessContextsEqual</c> ignores informational flags and determines if the values are
	/// equal. You can't use a direct bitwise comparison because of these informational flags.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-aredpiawarenesscontextsequal BOOL
	// AreDpiAwarenessContextsEqual( DPI_AWARENESS_CONTEXT dpiContextA, DPI_AWARENESS_CONTEXT dpiContextB );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "77660CAB-97ED-4DAC-A95E-A149F1A479FD")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AreDpiAwarenessContextsEqual([In, AddAsMember] DPI_AWARENESS_CONTEXT dpiContextA, DPI_AWARENESS_CONTEXT dpiContextB);

	/// <summary>
	/// In high-DPI displays, enables automatic display scaling of the non-client area portions of the specified top-level window. Must
	/// be called during the initialization of that window.
	/// </summary>
	/// <param name="hwnd">The window that should have automatic scaling enabled.</param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
	/// information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Calling this function will enable non-client scaling for an individual top-level window with DPI_AWARENESS_CONTEXT of
	/// <c>DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE</c>. If instead you are not using per-window awareness, and your entire process is
	/// running in <c>DPI_AWARENESS_PER_MONITOR_AWARE</c> mode, calling this function will enable non-client scaling in top-level windows
	/// in your process.
	/// </para>
	/// <para>
	/// If neither of those are true, or if you call this method from any other window, then it will fail and return a value of zero.
	/// </para>
	/// <para>
	/// Non-client scaling for top-level windows is not enabled by default. You must call this API to enable it for each individual
	/// top-level window for which you wish to have the non-client area scale automatically. Once you do, there is no way to disable it.
	/// Enabling non-client scaling means that all the areas drawn by the system for the window will automatically scale in response to
	/// DPI changes on the window. That includes areas like the caption bar, the scrollbars, and the menu bar. You want to call
	/// <c>EnableNonClientDpiScaling</c> when you want the operating system to be responsible for rendering these areas automatically at
	/// the correct size based on the API of the monitor.
	/// </para>
	/// <para>Calling this function enables non-client scaling for top-level windows only. Child windows are unaffected.</para>
	/// <para>
	/// This function must be called from WM_NCCREATE during the initialization of a new window. An example call might look like this:
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enablenonclientdpiscaling BOOL EnableNonClientDpiScaling(
	// HWND hwnd );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "3459B040-B73F-4581-BA29-0B2F0241801E")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnableNonClientDpiScaling([In, AddAsMember] HWND hwnd);

	/// <summary>Retrieves the DPI_AWARENESS value from a <c>DPI_AWARENESS_CONTEXT</c>.</summary>
	/// <param name="value">The <c>DPI_AWARENESS_CONTEXT</c> you want to examine.</param>
	/// <returns>The DPI_AWARENESS. If the provided value is <c>null</c> or invalid, this method will return <c>DPI_AWARENESS_INVALID</c>.</returns>
	/// <remarks>
	/// A DPI_AWARENESS_CONTEXT contains multiple pieces of information. For example, it includes both the current and the inherited
	/// DPI_AWARENESS. This method retrieves the <c>DPI_AWARENESS</c> from the structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getawarenessfromdpiawarenesscontext DPI_AWARENESS
	// GetAwarenessFromDpiAwarenessContext( DPI_AWARENESS_CONTEXT value );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "BE4DC6B9-BCD6-4E27-81F8-E3CF054CFBE9")]
	public static extern DPI_AWARENESS GetAwarenessFromDpiAwarenessContext([In, AddAsMember] DPI_AWARENESS_CONTEXT value);

	/// <summary>Retrieves and per-monitor DPI scaling behavior overrides of a child window in a dialog.</summary>
	/// <param name="hWnd">The handle for the window to examine.</param>
	/// <returns>
	/// The flags set on the given window. If passed an invalid handle, this function will return zero, and set its last error to <c>ERROR_INVALID_HANDLE</c>.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdialogcontroldpichangebehavior
	// DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS GetDialogControlDpiChangeBehavior( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "1651353F-5823-41B8-AE52-016AEBA6C4F0")]
	public static extern DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS GetDialogControlDpiChangeBehavior([In, AddAsMember] HWND hWnd);

	/// <summary>
	/// <para>Returns the flags that might have been set on a given dialog by an earlier call to SetDialogDpiChangeBehavior.</para>
	/// <para>If that function was never called on the dialog, the return value will be zero.</para>
	/// </summary>
	/// <param name="hDlg">The handle for the dialog to examine.</param>
	/// <returns>
	/// The flags set on the given dialog. If passed an invalid handle, this function will return zero, and set its last error to <c>ERROR_INVALID_HANDLE</c>.
	/// </returns>
	/// <remarks>
	/// It can be difficult to distinguish between a return value of <c>DDC_DEFAULT</c> and the error case, which is zero. To determine
	/// between the two, it is recommended that you call GetLastError() to check the error.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdialogdpichangebehavior DIALOG_DPI_CHANGE_BEHAVIORS
	// GetDialogDpiChangeBehavior( HWND hDlg );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "8ED61C77-36C8-453B-BAB1-505CE4974D63")]
	public static extern DIALOG_DPI_CHANGE_BEHAVIORS GetDialogDpiChangeBehavior([In, AddAsMember] HWND hDlg);

	/// <summary>Returns the dots per inch (dpi) value for the associated window.</summary>
	/// <param name="hwnd">The window you want to get information about.</param>
	/// <returns>
	/// The DPI for the window which depends on the DPI_AWARENESS of the window. See the Remarks for more information. An invalid hwnd
	/// value will result in a return value of 0.
	/// </returns>
	/// <remarks>
	/// <para>The following table indicates the return value of <c>GetDpiForWindow</c> based on the DPI_AWARENESS of the provided hwnd.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>DPI_AWARENESS</term>
	/// <term>Return value</term>
	/// </listheader>
	/// <item>
	/// <term>DPI_AWARENESS_UNAWARE</term>
	/// <term>96</term>
	/// </item>
	/// <item>
	/// <term>DPI_AWARENESS_SYSTEM_AWARE</term>
	/// <term>The system DPI.</term>
	/// </item>
	/// <item>
	/// <term>DPI_AWARENESS_PER_MONITOR_AWARE</term>
	/// <term>The DPI of the monitor where the window is located.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdpiforwindow UINT GetDpiForWindow( HWND hwnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "E9F7BCFA-4215-44C0-95FB-57C28325720C")]
	public static extern uint GetDpiForWindow([In, AddAsMember] HWND hwnd);

	/// <summary>
	/// Retrieves the DPI from a given DPI_AWARENESS_CONTEXT handle. This enables you to determine the DPI of a thread without needed to
	/// examine a window created within that thread.
	/// </summary>
	/// <param name="value">The <c>DPI_AWARENESS_CONTEXT</c> handle to examine.</param>
	/// <returns>The DPI value associated with the <c>DPI_AWARENESS_CONTEXT</c> handle.</returns>
	/// <remarks>
	/// DPI_AWARENESS_CONTEXT handles associated with values of <c>DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE</c> and
	/// <c>DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2</c> will return a value of 0 for their DPI. This is because the DPI of a
	/// per-monitor-aware window can change, and the actual DPI cannot be returned without the window's HWND.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdpifromdpiawarenesscontext UINT
	// GetDpiFromDpiAwarenessContext( DPI_AWARENESS_CONTEXT value );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "E47A7A12-AE11-4E66-AE49-463C9F4A6330")]
	public static extern uint GetDpiFromDpiAwarenessContext([In, AddAsMember] DPI_AWARENESS_CONTEXT value);

	/// <summary>Gets the DPI_AWARENESS_CONTEXT for the current thread.</summary>
	/// <returns>The current DPI_AWARENESS_CONTEXT for the thread.</returns>
	/// <remarks>
	/// This method will return the latest DPI_AWARENESS_CONTEXT sent to SetThreadDpiAwarenessContext. If
	/// <c>SetThreadDpiAwarenessContext</c> was never called for this thread, then the return value will equal the default
	/// <c>DPI_AWARENESS_CONTEXT</c> for the process.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getthreaddpiawarenesscontext DPI_AWARENESS_CONTEXT
	// GetThreadDpiAwarenessContext( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "DE86D551-974F-4A03-BDBE-348592CAB81F")]
	public static extern DPI_AWARENESS_CONTEXT GetThreadDpiAwarenessContext();

	/// <summary>Retrieves the DPI_HOSTING_BEHAVIOR from the current thread.</summary>
	/// <returns>The DPI_HOSTING_BEHAVIOR of the current thread.</returns>
	/// <remarks>
	/// This API returns the hosting behavior set by an earlier call of SetThreadDpiHostingBehavior, or
	/// <c>DPI_HOSTING_BEHAVIOR_DEFAULT</c> if no earlier call has been made.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getthreaddpihostingbehavior DPI_HOSTING_BEHAVIOR
	// GetThreadDpiHostingBehavior( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "B9500745-9B53-47FF-9F45-0BFF3A66FD46")]
	public static extern DPI_HOSTING_BEHAVIOR GetThreadDpiHostingBehavior();

	/// <summary>Returns the DPI_AWARENESS_CONTEXT associated with a window.</summary>
	/// <param name="hwnd">The window to query.</param>
	/// <returns>The DPI_AWARENESS_CONTEXT for the provided window. If the window is not valid, the return value is <c>NULL</c>.</returns>
	/// <remarks>
	/// <c>Important</c> The return value of <c>GetWindowDpiAwarenessContext</c> is not affected by the DPI_AWARENESS of the current
	/// thread. It only indicates the context of the window specified by the hwnd input parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindowdpiawarenesscontext DPI_AWARENESS_CONTEXT
	// GetWindowDpiAwarenessContext( HWND hwnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "BCBC6EC7-9792-43C0-BE0E-D94F00A7CAFD")]
	public static extern DPI_AWARENESS_CONTEXT GetWindowDpiAwarenessContext([In, AddAsMember] HWND hwnd);

	/// <summary>Returns the DPI_HOSTING_BEHAVIOR of the specified window.</summary>
	/// <param name="hwnd">The handle for the window to examine.</param>
	/// <returns>The DPI_HOSTING_BEHAVIOR of the specified window.</returns>
	/// <remarks>
	/// This API allows you to examine the hosting behavior of a window after it has been created. A window's hosting behavior is the
	/// hosting behavior of the thread in which the window was created, as set by a call to SetThreadDpiHostingBehavior. This is a
	/// permanent value and cannot be changed after the window is created, even if the thread's hosting behavior is changed.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindowdpihostingbehavior DPI_HOSTING_BEHAVIOR
	// GetWindowDpiHostingBehavior( HWND hwnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "BD16F545-54A1-479A-BA4B-F54834043EB2")]
	public static extern DPI_HOSTING_BEHAVIOR GetWindowDpiHostingBehavior([In, AddAsMember] HWND hwnd);

	/// <summary>Determines if a specified <c>DPI_AWARENESS_CONTEXT</c> is valid and supported by the current system.</summary>
	/// <param name="value">The context that you want to determine if it is supported.</param>
	/// <returns><c>TRUE</c> if the provided context is supported, otherwise <c>FALSE</c>.</returns>
	/// <remarks>
	/// <para>
	/// <c>IsValidDpiAwarenessContext</c> determines the validity of any provided <c>DPI_AWARENESS_CONTEXT</c>. You should make sure a
	/// context is valid before using SetThreadDpiAwarenessContext to that context.
	/// </para>
	/// <para>An input value of <c>NULL</c> is considered to be an invalid context and will result in a return value of <c>FALSE.</c></para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-isvaliddpiawarenesscontext BOOL
	// IsValidDpiAwarenessContext( DPI_AWARENESS_CONTEXT value );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "66F48B95-DEF4-4422-BF4F-5EBA3C713A80")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsValidDpiAwarenessContext([In, AddAsMember] DPI_AWARENESS_CONTEXT value);

	/// <summary>
	/// Converts a point in a window from logical coordinates into physical coordinates, regardless of the dots per inch (dpi) awareness
	/// of the caller. For more information about DPI awareness levels, see PROCESS_DPI_AWARENESS.
	/// </summary>
	/// <param name="hWnd">A handle to the window whose transform is used for the conversion.</param>
	/// <param name="lpPoint">
	/// A pointer to a POINT structure that specifies the logical coordinates to be converted. The new physical coordinates are copied
	/// into this structure if the function succeeds.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// In Windows 8, system–DPI aware applications translated between physical and logical space using PhysicalToLogicalPoint and
	/// LogicalToPhysicalPoint. In Windows 8.1, the additional virtualization of the system and inter-process communications means that
	/// for the majority of applications, you do not need these APIs. As a result, in Windows 8.1, these APIs no longer transform points.
	/// The system returns all points to an application in its own coordinate space. This behavior preserves functionality for the
	/// majority of applications, but there are some exceptions in which you must make changes to ensure that the application works as expected.
	/// </para>
	/// <para>
	/// For example, an application might need to walk the entire window tree of another process and ask the system for DPI-dependent
	/// information about the window. By default, the system will return the information based on the DPI awareness of the caller. This
	/// is ideal for most applications. However, the caller might need the information based on the DPI awareness of the application
	/// associated with the window. This might be necessary because the two applications send DPI-dependent information between each
	/// other directly. In this case, the application can use <c>LogicalToPhysicalPointForPerMonitorDPI</c> to get physical coordinates
	/// and then use PhysicalToLogicalPointForPerMonitorDPI to convert the physical coordinates into logical coordinates based on the
	/// DPI-awareness of the provided <c>HWND</c>.
	/// </para>
	/// <para>
	/// Consider two applications, one has a PROCESS_DPI_AWARENESS value of <c>PROCESS_DPI_UNAWARE</c> and the other has a value of
	/// <c>PROCESS_PER_MONITOR_AWARE</c>. The <c>PROCESS_DPI_UNAWARE</c> app creates a window on a single monitor where the scale factor
	/// is 200% (192 DPI). If both apps call GetWindowRect on this window, they will receive different values. The
	/// <c>PROCESS_DPI_UNAWARE</c> app will receive a rect based on 96 DPI coordinates, while the <c>PROCESS_PER_MONITOR_AWARE</c> app
	/// will receive coordinates matching the actual DPI of the monitor. If the <c>PROCESS_PER_MONITOR_AWARE</c> needs the rect that the
	/// system returned to the <c>PROCESS_DPI_UNAWARE</c> app, it could call <c>LogicalToPhysicalPointForPerMonitorDPI</c> for the
	/// corners of its rect and pass in the handle to the <c>PROCESS_DPI_UNAWARE</c> app's window. This will return points based on the
	/// other app's awareness that can be used to create a rect.
	/// </para>
	/// <para>
	/// <c>Tip</c> Since an application with a PROCESS_DPI_AWARENESS value of <c>PROCESS_PER_MONITOR_AWARE</c> uses the actual DPI of the
	/// monitor, physical and logical coordinates are the same for this app.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-logicaltophysicalpointforpermonitordpi BOOL
	// LogicalToPhysicalPointForPerMonitorDPI( HWND hWnd, LPPOINT lpPoint );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "C9ABDC73-1E96-42F1-B34D-3A649DDF02A6")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LogicalToPhysicalPointForPerMonitorDPI([In, AddAsMember] HWND hWnd, ref POINT lpPoint);

	/// <summary>
	/// Converts a point in a window from logical coordinates into physical coordinates, regardless of the dots per inch (dpi) awareness
	/// of the caller. For more information about DPI awareness levels, see PROCESS_DPI_AWARENESS.
	/// </summary>
	/// <param name="hWnd">A handle to the window whose transform is used for the conversion.</param>
	/// <param name="lpPoint">
	/// A pointer to a POINT structure that specifies the physical/screen coordinates to be converted. The new logical coordinates are
	/// copied into this structure if the function succeeds.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// In Windows 8, system–DPI aware applications translate between physical and logical space using PhysicalToLogicalPoint and
	/// LogicalToPhysicalPoint. In Windows 8.1, the additional virtualization of the system and inter-process communications means that
	/// for the majority of applications, you do not need these APIs. As a result, in Windows 8.1, these APIs no longer transform points.
	/// The system returns all points to an application in its own coordinate space. This behavior preserves functionality for the
	/// majority of applications, but there are some exceptions in which you must make changes to ensure that the application works as expected.
	/// </para>
	/// <para>
	/// For example, an application might need to walk the entire window tree of another process and ask the system for DPI-dependent
	/// information about the window. By default, the system will return the information based on the DPI awareness of the caller. This
	/// is ideal for most applications. However, the caller might need the information based on the DPI awareness of the application
	/// associated with the window. This might be necessary because the two applications send DPI-dependent information between each
	/// other directly. In this case, the application can use LogicalToPhysicalPointForPerMonitorDPI to get physical coordinates and then
	/// use <c>PhysicalToLogicalPointForPerMonitorDPI</c> to convert the physical coordinates into logical coordinates based on the
	/// DPI-awareness of the provided <c>HWND</c>.
	/// </para>
	/// <para>
	/// Consider two applications, one has a PROCESS_DPI_AWARENESS value of <c>PROCESS_DPI_UNAWARE</c> and the other has a value of
	/// <c>PROCESS_PER_MONITOR_AWARE</c>. The <c>PROCESS_PER_MONITOR_AWARE</c> app creates a window on a single monitor where the scale
	/// factor is 200% (192 DPI). If both apps call GetWindowRect on this window, they will receive different values. The
	/// <c>PROCESS_DPI_UNAWARE</c> app will receive a rect based on 96 DPI coordinates, while the <c>PROCESS_PER_MONITOR_AWARE</c> app
	/// will receive coordinates matching the actual DPI of the monitor. If the <c>PROCESS_DPI_UNAWARE</c> needs the rect that the system
	/// returned to the <c>PROCESS_PER_MONITOR_AWARE</c> app, it could call LogicalToPhysicalPointForPerMonitorDPI for the corners of its
	/// rect and pass in a handle to the <c>PROCESS_PER_MONITOR_AWARE</c> app's window. This will return points based on the other app's
	/// awareness that can be used to create a rect. This works because since a <c>PROCESS_PER_MONITOR_AWARE</c> uses the actual DPI of
	/// the monitor, logical and physical coordinates are identical.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-physicaltologicalpointforpermonitordpi BOOL
	// PhysicalToLogicalPointForPerMonitorDPI( HWND hWnd, LPPOINT lpPoint );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "DC744BFC-4410-4878-BEA7-382550DDF9E3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PhysicalToLogicalPointForPerMonitorDPI([In, AddAsMember] HWND hWnd, ref POINT lpPoint);

	/// <summary>Overrides the default per-monitor DPI scaling behavior of a child window in a dialog.</summary>
	/// <param name="hWnd">A handle for the window whose behavior will be modified.</param>
	/// <param name="mask">A mask specifying the subset of flags to be changed.</param>
	/// <param name="values">The desired value to be set for the specified subset of flags.</param>
	/// <returns>
	/// <para>
	/// This function returns TRUE if the operation was successful, and FALSE otherwise. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// Possible errors are <c>ERROR_INVALID_HANDLE</c> if passed an invalid HWND, and <c>ERROR_ACCESS_DENIED</c> if the windows belongs
	/// to another process.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The behaviors are specified as values from the DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS enum. This function follows the typical
	/// two-parameter approach to setting flags, where a mask specifies the subset of the flags to be changed.
	/// </para>
	/// <para>
	/// It is valid to set these behaviors on any window. It does not matter if the window is currently a child of a dialog at the point
	/// in time that SetDialogControlDpiChangeBehavior is called. The behaviors are retained and will take effect only when the window is
	/// an immediate child of a dialog that has per-monitor DPI scaling enabled.
	/// </para>
	/// <para>
	/// This API influences individual controls within dialogs. The dialog-wide per-monitor DPI scaling behavior is controlled by SetDialogDpiChangeBehavior.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setdialogcontroldpichangebehavior BOOL
	// SetDialogControlDpiChangeBehavior( HWND hWnd, DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS mask, DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS values );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "52BB557B-0D70-4189-9BD0-EB94188EA4E7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetDialogControlDpiChangeBehavior([In, AddAsMember] HWND hWnd, DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS mask, DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS values);

	/// <summary>
	/// <para>Dialogs in Per-Monitor v2 contexts are automatically DPI scaled. This method lets you customize their DPI change behavior.</para>
	/// <para>
	/// This function works in conjunction with the DIALOG_DPI_CHANGE_BEHAVIORS enum in order to override the default DPI scaling
	/// behavior for dialogs. This function is called on a specified dialog, for which the specified flags are individually saved.
	/// </para>
	/// <para>
	/// This function does not affect the DPI scaling behavior for the child windows of the dialog in question - that is done with SetDialogControlDpiChangeBehavior.
	/// </para>
	/// </summary>
	/// <param name="hDlg">A handle for the dialog whose behavior will be modified.</param>
	/// <param name="mask">A mask specifying the subset of flags to be changed.</param>
	/// <param name="values">The desired value to be set for the specified subset of flags.</param>
	/// <returns>
	/// <para>
	/// This function returns TRUE if the operation was successful, and FALSE otherwise. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// Possible errors are <c>ERROR_INVALID_HANDLE</c> if passed an invalid dialog HWND, and <c>ERROR_ACCESS_DENIED</c> if the dialog
	/// belongs to another process.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For extensibility, DIALOG_DPI_CHANGE_BEHAVIORS was modeled as a set of bit-flags representing separate behaviors. This function
	/// follows the typical two-parameter approach to setting flags, where a mask specifies the subset of the flags to be changed.
	/// </para>
	/// <para>
	/// It is not an error to call this API outside of Per Monitor v2 contexts, though the flags will have no effect on the behavior of
	/// the specified dialog until the context is changed to Per Monitor v2.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setdialogdpichangebehavior BOOL
	// SetDialogDpiChangeBehavior( HWND hDlg, DIALOG_DPI_CHANGE_BEHAVIORS mask, DIALOG_DPI_CHANGE_BEHAVIORS values );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "48A13F57-9D82-4F79-962B-FBD02FFF9B39")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetDialogDpiChangeBehavior([In, AddAsMember] HWND hDlg, DIALOG_DPI_CHANGE_BEHAVIORS mask, DIALOG_DPI_CHANGE_BEHAVIORS values);

	/// <summary>
	/// <para>
	/// It is recommended that you set the process-default DPI awareness via application manifest. See Setting the default DPI awareness
	/// for a process for more information. Setting the process-default DPI awareness via API call can lead to unexpected application behavior.
	/// </para>
	/// <para>
	/// Sets the current process to a specified dots per inch (dpi) awareness context. The DPI awareness contexts are from the
	/// DPI_AWARENESS_CONTEXT value.
	/// </para>
	/// </summary>
	/// <param name="value">A DPI_AWARENESS_CONTEXT handle to set.</param>
	/// <returns>
	/// <para>
	/// This function returns TRUE if the operation was successful, and FALSE otherwise. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// Possible errors are <c>ERROR_INVALID_PARAMETER</c> for an invalid input, and <c>ERROR_ACCESS_DENIED</c> if the default API
	/// awareness mode for the process has already been set (via a previous API call or within the application manifest).
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This API is a more advanced version of the previously existing SetProcessDpiAwareness API, allowing for the process default to be
	/// set to the finer-grained DPI_AWARENESS_CONTEXT values. Most importantly, this allows you to programmatically set <c>Per Monitor
	/// v2</c> as the process default value, which is not possible with the previous API.
	/// </para>
	/// <para>
	/// This method sets the default DPI_AWARENESS_CONTEXT for all threads within an application. Individual threads can have their DPI
	/// awareness changed from the default with the SetThreadDpiAwarenessContext method.
	/// </para>
	/// <para>
	/// <c>Important</c> In general, it is recommended to not use <c>SetProcessDpiAwarenessContext</c> to set the DPI awareness for your
	/// application. If possible, you should declare the DPI awareness for your application in the application manifest. For more
	/// information, see Setting the default DPI awareness for a process.
	/// </para>
	/// <para>
	/// You must call this API before you call any APIs that depend on the DPI awareness (including before creating any UI in your
	/// process). Once API awareness is set for an app, any future calls to this API will fail. This is true regardless of whether you
	/// set the DPI awareness in the manifest or by using this API.
	/// </para>
	/// <para>If the DPI awareness level is not set, the default value is <c>DPI_AWARENESS_CONTEXT_UNAWARE</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setprocessdpiawarenesscontext BOOL
	// SetProcessDpiAwarenessContext( DPI_AWARENESS_CONTEXT value );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "EACD1784-BEFF-46C1-8665-CBC86A65833C")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetProcessDpiAwarenessContext([In, AddAsMember] DPI_AWARENESS_CONTEXT value);

	/// <summary>Set the DPI awareness for the current thread to the provided value.</summary>
	/// <param name="dpiContext">The new DPI_AWARENESS_CONTEXT for the current thread. This context includes the DPI_AWARENESS value.</param>
	/// <returns>
	/// The old DPI_AWARENESS_CONTEXT for the thread. If the dpiContext is invalid, the thread will not be updated and the return value
	/// will be <c>NULL</c>. You can use this value to restore the old <c>DPI_AWARENESS_CONTEXT</c> after overriding it with a predefined value.
	/// </returns>
	/// <remarks>Use this API to change the DPI_AWARENESS_CONTEXT for the thread from the default value for the app.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setthreaddpiawarenesscontext DPI_AWARENESS_CONTEXT
	// SetThreadDpiAwarenessContext( DPI_AWARENESS_CONTEXT dpiContext );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "95531BDC-3D45-4BB6-8C63-0D845C66B88F")]
	public static extern DPI_AWARENESS_CONTEXT SetThreadDpiAwarenessContext([In, AddAsMember] DPI_AWARENESS_CONTEXT dpiContext);

	/// <summary>
	/// Sets the thread's DPI_HOSTING_BEHAVIOR. This behavior allows windows created in the thread to host child windows with a different <c>DPI_AWARENESS_CONTEXT</c>.
	/// </summary>
	/// <param name="value">The new DPI_HOSTING_BEHAVIOR value for the current thread.</param>
	/// <returns>
	/// The previous DPI_HOSTING_BEHAVIOR for the thread. If the hosting behavior passed in is invalid, the thread will not be updated
	/// and the return value will be <c>DPI_HOSTING_BEHAVIOR_INVALID</c>. You can use this value to restore the old
	/// <c>DPI_HOSTING_BEHAVIOR</c> after overriding it with a predefined value.
	/// </returns>
	/// <remarks>
	/// <para>
	/// DPI_HOSTING_BEHAVIOR enables a mixed content hosting behavior, which allows parent windows created in the thread to host child
	/// windows with a different DPI_AWARENESS_CONTEXT value. This property only effects new windows created within this thread while the
	/// mixed hosting behavior is active. A parent window with this hosting behavior is able to host child windows with different
	/// <c>DPI_AWARENESS_CONTEXT</c> values, regardless of whether the child windows have mixed hosting behavior enabled.
	/// </para>
	/// <para>
	/// This hosting behavior does not allow for windows with per-monitor <c>DPI_AWARENESS_CONTEXT</c> values to be hosted until windows
	/// with <c>DPI_AWARENESS_CONTEXT</c> values of system or unaware.
	/// </para>
	/// <para>
	/// To avoid unexpected outcomes, a thread's <c>DPI_HOSTING_BEHAVIOR</c> should be changed to support mixed hosting behaviors only
	/// when creating a new window which needs to support those behaviors. Once that window is created, the hosting behavior should be
	/// switched back to its default value.
	/// </para>
	/// <para>
	/// This API is used to change the thread's <c>DPI_HOSTING_BEHAVIOR</c> from its default value. This is only necessary if your app
	/// needs to host child windows from plugins and third-party components that do not support per-monitor-aware context. This is most
	/// likely to occur if you are updating complex applications to support per-monitor <c>DPI_AWARENESS_CONTEXT</c> behaviors.
	/// </para>
	/// <para>
	/// Enabling mixed hosting behavior will not automatically adjust the thread's <c>DPI_AWARENESS_CONTEXT</c> to be compatible with
	/// legacy content. The thread's awareness context must still be manually changed before new windows are created to host such content.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setthreaddpihostingbehavior DPI_HOSTING_BEHAVIOR
	// SetThreadDpiHostingBehavior( DPI_HOSTING_BEHAVIOR value );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "CF31D96A-EC84-4911-81A2-82EC90D417B9")]
	public static extern DPI_HOSTING_BEHAVIOR SetThreadDpiHostingBehavior(DPI_HOSTING_BEHAVIOR value);

	public partial struct DPI_AWARENESS_CONTEXT
	{
		/// <summary>
		/// DPI unaware. This window does not scale for DPI changes and is always assumed to have a scale factor of 100% (96 DPI). It
		/// will be automatically scaled by the system on any other DPI setting.
		/// </summary>
		public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_UNAWARE = new(new(-1));

		/// <summary>
		/// System DPI aware. This window does not scale for DPI changes. It will query for the DPI once and use that value for the
		/// lifetime of the process. If the DPI changes, the process will not adjust to the new DPI value. It will be automatically
		/// scaled up or down by the system when the DPI changes from the system value.
		/// </summary>
		public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_SYSTEM_AWARE = new(new(-2));

		/// <summary>
		/// Per monitor DPI aware. This window checks for the DPI when it is created and adjusts the scale factor whenever the DPI
		/// changes. These processes are not automatically scaled by the system.
		/// </summary>
		public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE = new(new(-3));

		/// <summary>
		/// <para>
		/// Also known as Per Monitor v2. An advancement over the original per-monitor DPI awareness mode, which enables applications to
		/// access new DPI-related scaling behaviors on a per top-level window basis.
		/// </para>
		/// <para>
		/// Per Monitor v2 was made available in the Creators Update of Windows 10, and is not available on earlier versions of the
		/// operating system.
		/// </para>
		/// <para>The additional behaviors introduced are as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Child window DPI change notifications</term>
		/// <description>In Per Monitor v2 contexts, the entire window tree is notified of any DPI changes that occur.</description>
		/// </item>
		/// <item>
		/// <term>Scaling of non-client area</term>
		/// <description>
		/// All windows will automatically have their non-client area drawn in a DPI sensitive fashion. Calls to
		/// EnableNonClientDpiScaling are unnecessary.
		/// </description>
		/// </item>
		/// <item>
		/// <term>Scaling of Win32 menus</term>
		/// <description>All NTUSER menus created in Per Monitor v2 contexts will be scaling in a per-monitor fashion.</description>
		/// </item>
		/// <item>
		/// <term>Dialog Scaling</term>
		/// <description>Win32 dialogs created in Per Monitor v2 contexts will automatically respond to DPI changes.</description>
		/// </item>
		/// <item>
		/// <term>Improved scaling of comctl32 controls</term>
		/// <description>Various comctl32 controls have improved DPI scaling behavior in Per Monitor v2 contexts.</description>
		/// </item>
		/// <item>
		/// <term>Improved theming behavior</term>
		/// <description>
		/// UxTheme handles opened in the context of a Per Monitor v2 window will operate in terms of the DPI associated with that window.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = new(new(-4));

		/// <summary>
		/// <para>
		/// DPI unaware with improved quality of GDI-based content. This mode behaves similarly to DPI_AWARENESS_CONTEXT_UNAWARE, but
		/// also enables the system to automatically improve the rendering quality of text and other GDI-based primitives when the window
		/// is displayed on a high-DPI monitor.
		/// </para>
		/// <para>For more details, see Improving the high-DPI experience in GDI-based Desktop apps.</para>
		/// <para>
		/// DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED was introduced in the October 2018 update of Windows 10 (also known as version 1809).
		/// </para>
		/// </summary>
		public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED = new(new(-5));
	}
}