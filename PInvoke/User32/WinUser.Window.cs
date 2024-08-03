using System.Collections.Generic;

namespace Vanara.PInvoke;

public static partial class User32
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public const int CCHILDREN_SCROLLBAR = 5;
	public const int CCHILDREN_TITLEBAR = 5;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

	/// <summary>
	/// Pass this value to the x, y, nWidth and nHeight parameteres of <see cref="CreateWindow"/> and <c>CreateWindowEx</c> to
	/// select the default position for the parameter.
	/// </summary>
	public const int CW_USEDEFAULT = unchecked((int)0x80000000);

	/// <summary>
	/// An application-defined callback function used with the <c>EnumChildWindows</c> function. It receives the child window handles.
	/// The <c>WNDENUMPROC</c> type defines a pointer to this callback function. EnumChildProc is a placeholder for the
	/// application-defined function name.
	/// </summary>
	/// <param name="hwnd">A handle to a child window of the parent window specified in <c>EnumChildWindows</c>.</param>
	/// <param name="lParam">The application-defined value given in <c>EnumChildWindows</c>.</param>
	/// <returns>To continue enumeration, the callback function must return <c>TRUE</c>; to stop enumeration, it must return <c>FALSE</c>.</returns>
	// BOOL CALLBACK EnumChildProc( _In_ HWND hwnd, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/ms633493(v=vs.85).aspx
	[PInvokeData("Winuser.h", MSDNShortId = "ms633493")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool EnumWindowsProc([In] HWND hwnd, [In] IntPtr lParam);

	/// <summary>
	/// <para>
	/// An application-defined function that processes messages sent to a window. The <c>WNDPROC</c> type defines a pointer to this
	/// callback function.
	/// </para>
	/// <para>WindowProc is a placeholder for the application-defined function name.</para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window.</para>
	/// </param>
	/// <param name="uMsg">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The message.</para>
	/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
	/// </param>
	/// <param name="wParam">
	/// <para>Type: <c>WPARAM</c></para>
	/// <para>Additional message information. The contents of this parameter depend on the value of the uMsg parameter.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>Additional message information. The contents of this parameter depend on the value of the uMsg parameter.</para>
	/// </param>
	/// <returns>
	/// <para>Type:</para>
	/// <para>The return value is the result of the message processing and depends on the message sent.</para>
	/// </returns>
	// LRESULT CALLBACK WindowProc( _In_ HWND hwnd, _In_ UINT uMsg, _In_ WPARAM wParam, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/ms633573(v=vs.85).aspx
	[PInvokeData("Winuser.h", MSDNShortId = "ms633573")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate IntPtr WindowProc([In] HWND hwnd, [In] uint uMsg, [In] IntPtr wParam, [In] IntPtr lParam);

	/// <summary>
	/// <para>The user-provided entry point for a graphical Windows-based application.</para>
	/// <para><c>WinMain</c> is the conventional name used for the application entry point. For more information, see Remarks.</para>
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the current instance of the application.</para>
	/// </param>
	/// <param name="hPrevInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>
	/// A handle to the previous instance of the application. This parameter is always <c>NULL</c>. If you need to detect whether another
	/// instance already exists, create a uniquely named mutex using the <c>CreateMutex</c> function. <c>CreateMutex</c> will succeed
	/// even if the mutex already exists, but the function will return <c>ERROR_ALREADY_EXISTS</c>. This indicates that another instance
	/// of your application exists, because it created the mutex first. However, a malicious user can create this mutex before you do and
	/// prevent your application from starting. To prevent this situation, create a randomly named mutex and store the name so that it
	/// can only be obtained by an authorized user. Alternatively, you can use a file for this purpose. To limit your application to one
	/// instance per user, create a locked file in the user's profile directory.
	/// </para>
	/// </param>
	/// <param name="lpCmdLine">
	/// <para>Type: <c>LPSTR</c></para>
	/// <para>
	/// The command line for the application, excluding the program name. To retrieve the entire command line, use the
	/// <c>GetCommandLine</c> function.
	/// </para>
	/// </param>
	/// <param name="nCmdShow">
	/// <para>Type: <c>int</c></para>
	/// <para>Controls how the window is to be shown. This parameter can be one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SW_HIDE0</term>
	/// <term>Hides the window and activates another window.</term>
	/// </item>
	/// <item>
	/// <term>SW_MAXIMIZE3</term>
	/// <term>Maximizes the specified window.</term>
	/// </item>
	/// <item>
	/// <term>SW_MINIMIZE6</term>
	/// <term>Minimizes the specified window and activates the next top-level window in the Z order.</term>
	/// </item>
	/// <item>
	/// <term>SW_RESTORE9</term>
	/// <term>
	/// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and
	/// position. An application should specify this flag when restoring a minimized window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SW_SHOW5</term>
	/// <term>Activates the window and displays it in its current size and position.</term>
	/// </item>
	/// <item>
	/// <term>SW_SHOWMAXIMIZED3</term>
	/// <term>Activates the window and displays it as a maximized window.</term>
	/// </item>
	/// <item>
	/// <term>SW_SHOWMINIMIZED2</term>
	/// <term>Activates the window and displays it as a minimized window.</term>
	/// </item>
	/// <item>
	/// <term>SW_SHOWMINNOACTIVE7</term>
	/// <term>Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.</term>
	/// </item>
	/// <item>
	/// <term>SW_SHOWNA8</term>
	/// <term>Displays the window in its current size and position. This value is similar to SW_SHOW, except the window is not activated.</term>
	/// </item>
	/// <item>
	/// <term>SW_SHOWNOACTIVATE4</term>
	/// <term>
	/// Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except the window is not activated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SW_SHOWNORMAL1</term>
	/// <term>
	/// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and
	/// position. An application should specify this flag when displaying the window for the first time.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type:</para>
	/// <para>
	/// If the function succeeds, terminating when it receives a <c>WM_QUIT</c> message, it should return the exit value contained in
	/// that message's wParam parameter. If the function terminates before entering the message loop, it should return zero.
	/// </para>
	/// </returns>
	// int CALLBACK WinMain( _In_ HINSTANCE hInstance, _In_ HINSTANCE hPrevInstance, _In_ LPSTR lpCmdLine, _In_ int nCmdShow); https://msdn.microsoft.com/en-us/library/windows/desktop/ms633559(v=vs.85).aspx
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms633559")]
	public delegate int WinMain([In] HINSTANCE hInstance, [In] HINSTANCE hPrevInstance, [In][MarshalAs(UnmanagedType.LPStr)] string lpCmdLine, [In] ShowWindowCommand nCmdShow);

	/// <summary>
	/// The type of animation. Note that, by default, these flags take effect when showing a window. To take effect when hiding a window,
	/// use <c>AW_HIDE</c> and a logical OR operator with the appropriate flags.
	/// </summary>
	[Flags]
	public enum AnimateWindowFlags
	{
		/// <summary>Activates the window. Do not use this value with AW_HIDE.</summary>
		AW_ACTIVATE = 0x00020000,

		/// <summary>Uses a fade effect. This flag can be used only if hwnd is a top-level window.</summary>
		AW_BLEND = 0x00080000,

		/// <summary>
		/// Makes the window appear to collapse inward if AW_HIDE is used or expand outward if the AW_HIDE is not used. The various
		/// direction flags have no effect.
		/// </summary>
		AW_CENTER = 0x00000010,

		/// <summary>Hides the window. By default, the window is shown.</summary>
		AW_HIDE = 0x00010000,

		/// <summary>
		/// Animates the window from left to right. This flag can be used with roll or slide animation. It is ignored when used with
		/// AW_CENTER or AW_BLEND.
		/// </summary>
		AW_HOR_POSITIVE = 0x00000001,

		/// <summary>
		/// Animates the window from right to left. This flag can be used with roll or slide animation. It is ignored when used with
		/// AW_CENTER or AW_BLEND.
		/// </summary>
		AW_HOR_NEGATIVE = 0x00000002,

		/// <summary>Uses slide animation. By default, roll animation is used. This flag is ignored when used with AW_CENTER.</summary>
		AW_SLIDE = 0x00040000,

		/// <summary>
		/// Animates the window from top to bottom. This flag can be used with roll or slide animation. It is ignored when used with
		/// AW_CENTER or AW_BLEND.
		/// </summary>
		AW_VER_POSITIVE = 0x00000004,

		/// <summary>
		/// Animates the window from bottom to top. This flag can be used with roll or slide animation. It is ignored when used with
		/// AW_CENTER or AW_BLEND.
		/// </summary>
		AW_VER_NEGATIVE = 0x00000008,
	}

	/// <summary>For use with ChildWindowFromPointEx</summary>
	[PInvokeData("winuser.h", MSDNShortId = "childwindowfrompointex")]
	[Flags]
	public enum ChildWindowSkipOptions
	{
		/// <summary>Does not skip any child windows</summary>
		CWP_ALL = 0x0000,

		/// <summary>Skips invisible child windows</summary>
		CWP_SKIPINVISIBLE = 0x0001,

		/// <summary>Skips disabled child windows</summary>
		CWP_SKIPDISABLED = 0x0002,

		/// <summary>Skips transparent child windows</summary>
		CWP_SKIPTRANSPARENT = 0x0004
	}

	/// <summary>The default process layout.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "setprocessdefaultlayout")]
	public enum DefaultLayout : uint
	{
		/// <summary>Sets the default horizontal layout to be left to right.</summary>
		LAYOUT_LTR = 0,

		/// <summary>Sets the default horizontal layout to be right to left.</summary>
		LAYOUT_RTL = 1,
	}

	/// <summary>
	/// <para>Specifies the visual feedback associated with an event.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ne-winuser-tagfeedback_type typedef enum tagFEEDBACK_TYPE {
	// FEEDBACK_TOUCH_CONTACTVISUALIZATION, FEEDBACK_PEN_BARRELVISUALIZATION, FEEDBACK_PEN_TAP, FEEDBACK_PEN_DOUBLETAP,
	// FEEDBACK_PEN_PRESSANDHOLD, FEEDBACK_PEN_RIGHTTAP, FEEDBACK_TOUCH_TAP, FEEDBACK_TOUCH_DOUBLETAP, FEEDBACK_TOUCH_PRESSANDHOLD,
	// FEEDBACK_TOUCH_RIGHTTAP, FEEDBACK_GESTURE_PRESSANDTAP, FEEDBACK_MAX } FEEDBACK_TYPE;
	[PInvokeData("winuser.h", MSDNShortId = "EEA3024E-D38C-4F4D-A63C-58ECB2B87F20")]
	public enum FEEDBACK_TYPE : uint
	{
		/// <summary>Feedback for a touch contact event.</summary>
		FEEDBACK_TOUCH_CONTACTVISUALIZATION = 1,

		/// <summary>Feedback for a pen barrel-button event.</summary>
		FEEDBACK_PEN_BARRELVISUALIZATION,

		/// <summary>Feedback for a pen tap event.</summary>
		FEEDBACK_PEN_TAP,

		/// <summary>Feedback for a pen double-tap event.</summary>
		FEEDBACK_PEN_DOUBLETAP,

		/// <summary>Feedback for a pen press-and-hold event.</summary>
		FEEDBACK_PEN_PRESSANDHOLD,

		/// <summary>Feedback for a pen right-tap event.</summary>
		FEEDBACK_PEN_RIGHTTAP,

		/// <summary>Feedback for a touch tap event.</summary>
		FEEDBACK_TOUCH_TAP,

		/// <summary>Feedback for a touch double-tap event.</summary>
		FEEDBACK_TOUCH_DOUBLETAP,

		/// <summary>Feedback for a touch press-and-hold event.</summary>
		FEEDBACK_TOUCH_PRESSANDHOLD,

		/// <summary>Feedback for a touch right-tap event.</summary>
		FEEDBACK_TOUCH_RIGHTTAP,

		/// <summary>Feedback for a press-and-tap gesture.</summary>
		FEEDBACK_GESTURE_PRESSANDTAP,

		/// <summary>Do not use.</summary>
		FEEDBACK_MAX = uint.MaxValue,
	}

	/// <summary>The flash status.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "b16636bc-fa77-4eb9-9801-dc2cdf0556e5")]
	[Flags]
	public enum FLASHW
	{
		/// <summary>
		/// Flash both the window caption and taskbar button. This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
		/// </summary>
		FLASHW_ALL = 0x00000003,

		/// <summary>Flash the window caption.</summary>
		FLASHW_CAPTION = 0x00000001,

		/// <summary>Stop flashing. The system restores the window to its original state.</summary>
		FLASHW_STOP = 0,

		/// <summary>Flash continuously, until the FLASHW_STOP flag is set.</summary>
		FLASHW_TIMER = 0x00000004,

		/// <summary>Flash continuously until the window comes to the foreground.</summary>
		FLASHW_TIMERNOFG = 0x0000000C,

		/// <summary>Flash the taskbar button.</summary>
		FLASHW_TRAY = 0x00000002,
	}

	/// <summary>
	/// To retrieve any other value from the WNDCLASSEX structure using <see cref="GetClassLong(HWND, int)"/>, specify one of the
	/// following values.
	/// </summary>
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.GetClassLongW")]
	public enum GetClassLongFlag
	{
		/// <summary>Retrieves the address of the menu name string. The string identifies the menu resource associated with the class.</summary>
		GCLP_MENUNAME = -8,

		/// <summary>Retrieves a handle to the background brush associated with the class.</summary>
		GCLP_HBRBACKGROUND = -10,

		/// <summary>Retrieves a handle to the cursor associated with the class.</summary>
		GCLP_HCURSOR = -12,

		/// <summary>Retrieves a handle to the icon associated with the class.</summary>
		GCLP_HICON = -14,

		/// <summary>Retrieves a handle to the module that registered the class.</summary>
		GCLP_HMODULE = -16,

		/// <summary>
		/// Retrieves the address of the window procedure, or a handle representing the address of the window procedure. You must use the
		/// CallWindowProc function to call the window procedure.
		/// </summary>
		GCLP_WNDPROC = -24,

		/// <summary>Retrieves a handle to the small icon associated with the class.</summary>
		GCLP_HICONSM = -34,

		/// <summary>
		/// Retrieves an ATOM value that uniquely identifies the window class. This is the same atom that the RegisterClass or
		/// RegisterClassEx function returns.
		/// </summary>
		GCW_ATOM = -32,

		/// <summary>Retrieves the address of the menu name string. The string identifies the menu resource associated with the class.</summary>
		GCL_MENUNAME = -8,

		/// <summary>Retrieves a handle to the background brush associated with the class.</summary>
		GCL_HBRBACKGROUND = -10,

		/// <summary>Retrieves a handle to the cursor associated with the class.</summary>
		GCL_HCURSOR = -12,

		/// <summary>Retrieves a handle to the icon associated with the class.</summary>
		GCL_HICON = -14,

		/// <summary>Retrieves a handle to the module that registered the class.</summary>
		GCL_HMODULE = -16,

		/// <summary>
		/// Retrieves the size, in bytes, of the extra window memory associated with each window in the class. For information on how to
		/// access this memory, see GetWindowLong.
		/// </summary>
		GCL_CBWNDEXTRA = -18,

		/// <summary>Retrieves the size, in bytes, of the extra memory associated with the class.</summary>
		GCL_CBCLSEXTRA = -20,

		/// <summary>
		/// Retrieves the address of the window procedure, or a handle representing the address of the window procedure. You must use the
		/// CallWindowProc function to call the window procedure.
		/// </summary>
		GCL_WNDPROC = -24,

		/// <summary>Retrieves the window-class style bits.</summary>
		GCL_STYLE = -26,

		/// <summary>Retrieves a handle to the small icon associated with the class.</summary>
		GCL_HICONSM = -34,
	}

	/// <summary>Values used by <see cref="GetWindowLong"/> to determine which value to retrieve.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.GetClassWord")]
	public enum GCW
	{
		/// <summary>
		/// Retrieves an ATOM value that uniquely identifies the window class. This is the same atom that the RegisterClass or
		/// RegisterClassEx function returns.
		/// </summary>
		GCW_ATOM = -32,
	}

	/// <summary>The ancestor to be retrieved.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "getancestor")]
	public enum GetAncestorFlag
	{
		/// <summary>Retrieves the parent window. This does not include the owner, as it does with the GetParent function.</summary>
		GA_PARENT = 1,

		/// <summary>Retrieves the root window by walking the chain of parent windows.</summary>
		GA_ROOT = 2,

		/// <summary>Retrieves the owned root window by walking the chain of parent and owner windows returned by GetParent.</summary>
		GA_ROOTOWNER = 3
	}

	/// <summary>The relationship between the specified window and the window whose handle is to be retrieved.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "getwindow")]
	public enum GetWindowCmd
	{
		/// <summary>
		/// The retrieved handle identifies the child window at the top of the Z order, if the specified window is a parent window;
		/// otherwise, the retrieved handle is NULL. The function examines only child windows of the specified window. It does not
		/// examine descendant windows.
		/// </summary>
		GW_CHILD = 5,

		/// <summary>
		/// The retrieved handle identifies the enabled popup window owned by the specified window (the search uses the first such window
		/// found using GW_HWNDNEXT); otherwise, if there are no enabled popup windows, the retrieved handle is that of the specified window.
		/// </summary>
		GW_ENABLEDPOPUP = 6,

		/// <summary>
		/// The retrieved handle identifies the window of the same type that is highest in the Z order. If the specified window is a
		/// topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies
		/// a top-level window. If the specified window is a child window, the handle identifies a sibling window.
		/// </summary>
		GW_HWNDFIRST = 0,

		/// <summary>
		/// The retrieved handle identifies the window of the same type that is lowest in the Z order. If the specified window is a
		/// topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies
		/// a top-level window. If the specified window is a child window, the handle identifies a sibling window.
		/// </summary>
		GW_HWNDLAST = 1,

		/// <summary>
		/// The retrieved handle identifies the window below the specified window in the Z order. If the specified window is a topmost
		/// window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a
		/// top-level window. If the specified window is a child window, the handle identifies a sibling window.
		/// </summary>
		GW_HWNDNEXT = 2,

		/// <summary>
		/// The retrieved handle identifies the window above the specified window in the Z order. If the specified window is a topmost
		/// window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a
		/// top-level window. If the specified window is a child window, the handle identifies a sibling window.
		/// </summary>
		GW_HWNDPREV = 3,

		/// <summary>
		/// The retrieved handle identifies the specified window's owner window, if any. For more information, see Owned Windows.
		/// </summary>
		GW_OWNER = 4,
	}

	/// <summary>The thread state.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "guithreadinfo")]
	[Flags]
	public enum GUIThreadInfoFlags
	{
		/// <summary>The caret's blink state. This bit is set if the caret is visible.</summary>
		GUI_CARETBLINKING = 0x00000001,

		/// <summary>The thread's menu state. This bit is set if the thread is in menu mode.</summary>
		GUI_INMENUMODE = 0x00000004,

		/// <summary>The thread's move state. This bit is set if the thread is in a move or size loop.</summary>
		GUI_INMOVESIZE = 0x00000002,

		/// <summary>The thread's pop-up menu state. This bit is set if the thread has an active pop-up menu.</summary>
		GUI_POPUPMENUMODE = 0x00000010,

		/// <summary>The thread's system menu state. This bit is set if the thread is in a system menu mode.</summary>
		GUI_SYSTEMMENUMODE = 0x00000008,
	}

	/// <summary>Flags for <see cref="GetWindowFeedbackSetting"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "a40806b3-9085-42b6-9a87-95be0d1669c6")]
	[Flags]
	public enum GWFS
	{
		/// <summary>Check the parent window chain until a value is found</summary>
		GWFS_INCLUDE_ANCESTORS = 0x00000001,
	}

	/// <summary>A layering flag.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "getlayeredwindowattributes")]
	[Flags]
	public enum LayeredWindowAttributes : uint
	{
		/// <summary>Use pbAlpha to determine the opacity of the layered window.</summary>
		LWA_ALPHA = 0x02,

		/// <summary>Use pcrKey as the transparency color.</summary>
		LWA_COLORKEY = 0x01,
	}

	/// <summary>Specifies whether to enable or disable calls to SetForegroundWindow.</summary>
	[PInvokeData("winuser.h")]
	public enum LSFW
	{
		/// <summary>Disables calls to SetForegroundWindow.</summary>
		SFW_LOCK = 1,

		/// <summary>Enables calls to SetForegroundWindow.</summary>
		LSFW_UNLOCK = 2,
	}

	/// <summary>The tiling flags.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum MdiTileFlags
	{
		/// <summary>Tiles windows horizontally.</summary>
		MDITILE_VERTICAL = 0x0000,

		/// <summary>Tiles windows vertically.</summary>
		MDITILE_HORIZONTAL = 0x0001,

		/// <summary>Prevents disabled MDI child windows from being cascaded.</summary>
		MDITILE_SKIPDISABLED = 0x0002,

		/// <summary>
		/// Arranges the windows in Z order. If this value is not specified, the windows are arranged using the order specified in the
		/// lpKids array.
		/// </summary>
		MDITILE_ZORDER = 0x0004,
	}

	/// <summary>The action to be performed on <see cref="ChangeWindowMessageFilterEx"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "changewindowmessagefilterex")]
	public enum MessageFilterExAction
	{
		/// <summary>
		/// Resets the window message filter for hWnd to the default. Any message allowed globally or process-wide will get through, but
		/// any message not included in those two categories, and which comes from a lower privileged process, will be blocked.
		/// </summary>
		MSGFLT_RESET = 0,

		/// <summary>
		/// Allows the message through the filter. This enables the message to be received by hWnd, regardless of the source of the
		/// message, even it comes from a lower privileged process.
		/// </summary>
		MSGFLT_ALLOW = 1,

		/// <summary>
		/// Blocks the message to be delivered to hWnd if it comes from a lower privileged process, unless the message is allowed
		/// process-wide by using the ChangeWindowMessageFilter function or globally.
		/// </summary>
		MSGFLT_DISALLOW = 2,
	}

	/// <summary>The action to be performed on <see cref="ChangeWindowMessageFilter"/>.</summary>
	public enum MessageFilterFlag
	{
		/// <summary>Adds the message to the filter. This has the effect of allowing the message to be received.</summary>
		MSGFLT_ADD = 1,

		/// <summary>Removes the message from the filter. This has the effect of blocking the message.</summary>
		MSGFLT_REMOVE = 2,
	}

	/// <summary>Return values for <see cref="CHANGEFILTERSTRUCT.ExtStatus"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "changefilterstruct")]
	public enum MessageFilterInformation : uint
	{
		/// <summary>See the Remarks section of <see cref="CHANGEFILTERSTRUCT"/>. Applies to MSGFLT_ALLOW and MSGFLT_DISALLOW.</summary>
		MSGFLTINFO_NONE = 0,

		/// <summary>
		/// The message has already been allowed by this window's message filter, and the function thus succeeded with no change to the
		/// window's message filter. Applies to MSGFLT_ALLOW.
		/// </summary>
		MSGFLTINFO_ALREADYALLOWED_FORWND = 1,

		/// <summary>
		/// The message has already been blocked by this window's message filter, and the function thus succeeded with no change to the
		/// window's message filter. Applies to MSGFLT_DISALLOW.
		/// </summary>
		MSGFLTINFO_ALREADYDISALLOWED_FORWND = 2,

		/// <summary>The message is allowed at a scope higher than the window. Applies to MSGFLT_DISALLOW.</summary>
		MSGFLTINFO_ALLOWED_HIGHER = 3,
	}

	/// <summary>
	/// <para>
	/// This topic describes the constant values used to describe the state of objects in an application UI. The state constants are
	/// defined in oleacc.h.
	/// </para>
	/// <para>
	/// An object is associated with one or more of these state values at any time. The following object state constants are not used:
	/// STATE_SYSTEM_ALERT_HIGH, STATE_SYSTEM_ALERT_MEDIUM, STATE_SYSTEM_ALERT_LOW, and STATE_SYSTEM_FLOATING.
	/// </para>
	/// <para>
	/// Clients retrieve an object's state by calling <c>IAccessible::get_accState</c>, which returns an integer that is a combination of
	/// the following bit flags. Clients call <c>GetStateText</c> with the state value to retrieve a localized string that describes the
	/// object's state.
	/// </para>
	/// <para>
	/// When the state of an object changes, servers should call <c>NotifyWinEvent</c> with the <c>EVENT_OBJECT_STATECHANGE</c> event
	/// constant. However, objects with the STATE_SYSTEM_INVISIBLE, STATE_SYSTEM_FOCUSED, and STATE_SYSTEM_ SELECTED object state
	/// constants have their own event constants. For these objects, do not use <c>EVENT_OBJECT_STATECHANGE</c>. Instead, use the
	/// individual event constant.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/WinAuto/object-state-constants
	[PInvokeData("winuser.h", MSDNShortId = "1253d2d2-d931-4380-9ae8-f4e1fdaee817")]
	[Flags]
	public enum ObjectState : uint
	{
		/// <summary>Indicates that the object does not have another state assigned to it.</summary>
		STATE_SYSTEM_NORMAL = 0,

		/// <summary>
		/// (This object state constant is not supported.) Indicates important information to be immediately conveyed to the user. For
		/// example, when a battery reaches a critically low level, a level indicator generates a high-level alert. As a result, a blind
		/// access tool immediately announces this information to the user, and a screen magnification program scrolls the screen so that
		/// the battery indicator is in view. This state is also appropriate for any prompt or operation that must be completed before
		/// the user can continue.
		/// </summary>
		STATE_SYSTEM_ALERT_HIGH = 0x10000000,

		/// <summary>
		/// (This object state constant is not supported.) Indicates low-priority information that is not important to the user. This
		/// state is used, for example, when Word changes the appearance of the TipWizard button on its toolbar to indicate that it has a
		/// hint for the user.
		/// </summary>
		STATE_SYSTEM_ALERT_LOW = 0x04000000,

		/// <summary>
		/// (This object state constant is not supported.) Indicates important information that is not conveyed immediately to the user.
		/// For example, when a battery is starting to reach a low level, a level indicator generates a medium-level alert. A blind
		/// access tool then generates a sound to let the user know that important information is available, without actually
		/// interrupting the user's work. The user could then query the alert information when convenient.
		/// </summary>
		STATE_SYSTEM_ALERT_MEDIUM = 0x08000000,

		/// <summary>
		/// The object's appearance changes rapidly or constantly. Graphics that are animated occasionally are described as
		/// ROLE_SYSTEM_GRAPHIC with the State property set to STATE_SYSTEM_ANIMATED. This state is used to indicate that the object's
		/// location is changing.
		/// </summary>
		STATE_SYSTEM_ANIMATED = 0x00004000,

		/// <summary>The control cannot accept input at this time.</summary>
		STATE_SYSTEM_BUSY = 0x00000800,

		/// <summary>The object's check box is selected.</summary>
		STATE_SYSTEM_CHECKED = 0x00000010,

		/// <summary>The object's children that have the ROLE_SYSTEM_OUTLINEITEM role are hidden.</summary>
		STATE_SYSTEM_COLLAPSED = 0x00000400,

		/// <summary>This state represents the default button in a window.</summary>
		STATE_SYSTEM_DEFAULT = 0x00000100,

		/// <summary>The object's children that have the ROLE_SYSTEM_OUTLINEITEM role are displayed.</summary>
		STATE_SYSTEM_EXPANDED = 0x00000200,

		/// <summary>
		/// Indicates that an object extends its selection by using SELFLAG_EXTENDSELECTION in the IAccessible::accSelect method.
		/// </summary>
		STATE_SYSTEM_EXTSELECTABLE = 0x02000000,

		/// <summary>
		/// (This object state constant is not supported.) The object is not clipped to the boundary of its parent object, and it does
		/// not move automatically when the parent moves.
		/// </summary>
		STATE_SYSTEM_FLOATING = 0x00001000,

		/// <summary>The object is on the active window and is ready to receive keyboard focus.</summary>
		STATE_SYSTEM_FOCUSABLE = 0x00100000,

		/// <summary>
		/// The object has the keyboard focus. Do not confuse object focus with object selection. For more information, see Selection and
		/// Focus Properties and Methods. For objects with this object state, send the EVENT_OBJECT_SHOW or EVENT_OBJECT_HIDE WinEvents
		/// to notify client applications about state changes. Do not use EVENT_OBJECT_STATECHANGE.
		/// </summary>
		STATE_SYSTEM_FOCUSED = 0x00000004,

		/// <summary>When invoked, the object displays a pop-up menu or a window.</summary>
		STATE_SYSTEM_HASPOPUP = 0x40000000,

		/// <summary>
		/// The object is hot-tracked by the mouse, which means that the object's appearance has changed to indicate that the mouse
		/// pointer is located over it.
		/// </summary>
		STATE_SYSTEM_HOTTRACKED = 0x00000080,

		/// <summary>
		/// Indicates that the state of a three-state check box or toolbar button is not determined. The check box is neither selected
		/// nor cleared and is therefore in the third or mixed state.
		/// </summary>
		STATE_SYSTEM_INDETERMINATE = STATE_SYSTEM_MIXED,

		/// <summary>
		/// The object is programmatically hidden. For example, menu items are programmatically hidden until a user activates the menu.
		/// Because objects with this state are not available to users, client applications must not communicate information about the
		/// object to users. However, if client applications find an object with this state, they should check whether
		/// STATE_SYSTEM_OFFSCREEN is also set. If this second state is defined, clients can communicate the information about the object
		/// to users. For example, a list box can have both STATE_SYSTEM_INVISIBLE and STATE_SYSTEM_OFFSCREEN set. In this case, the
		/// client application can communicate all items in the list to users.
		/// <para>
		/// If a client application is navigating through an IAccessible tree and encounters a parent object that is invisible, Microsoft
		/// Active Accessibility will not expose information about any possible children of the parent as long as the parent is invisible.
		/// </para>
		/// </summary>
		STATE_SYSTEM_INVISIBLE = 0x00008000,

		/// <summary>Indicates that the object is formatted as a hyperlink. The object's role will usually be ROLE_SYSTEM_TEXT.</summary>
		STATE_SYSTEM_LINKED = 0x00400000,

		/// <summary>Indicates scrolling or moving text or graphics.</summary>
		STATE_SYSTEM_MARQUEED = 0x00002000,

		/// <summary>
		/// Indicates that the state of a three-state check box or toolbar button is not determined. The check box is neither selected
		/// nor cleared and is therefore in the third or mixed state.
		/// </summary>
		STATE_SYSTEM_MIXED = 0x00000020,

		/// <summary>
		/// Indicates that the object can be moved. For example, a user can click the object's title bar and drag the object to a new location.
		/// </summary>
		STATE_SYSTEM_MOVEABLE = 0x00040000,

		/// <summary>
		/// Indicates that the object accepts multiple selected items; that is, SELFLAG_ADDSELECTION for the IAccessible::accSelect
		/// method is valid.
		/// </summary>
		STATE_SYSTEM_MULTISELECTABLE = 0x01000000,

		/// <summary>
		/// The object is clipped or has scrolled out of view, but it is not programmatically hidden. If the user makes the viewport
		/// larger, more of the object will be visible on the computer screen.
		/// </summary>
		STATE_SYSTEM_OFFSCREEN = 0x00010000,

		/// <summary>The object is pressed.</summary>
		STATE_SYSTEM_PRESSED = 0x00000008,

		/// <summary>The object is a password-protected edit control.</summary>
		STATE_SYSTEM_PROTECTED = 0x20000000,

		/// <summary>The object is designated read-only.</summary>
		STATE_SYSTEM_READONLY = 0x00000040,

		/// <summary>The object accepts selection.</summary>
		STATE_SYSTEM_SELECTABLE = 0x00200000,

		/// <summary>The object is selected.</summary>
		STATE_SYSTEM_SELECTED = 0x00000002,

		/// <summary>
		/// The object or child uses text-to-speech (TTS) technology for description purposes. When an object with this state has the
		/// focus, a speech-based accessibility aid does not announce information because the object automatically announces it.
		/// </summary>
		STATE_SYSTEM_SELFVOICING = 0x00080000,

		/// <summary>The object can be resized. For example, a user could change the size of a window by dragging it by the border.</summary>
		STATE_SYSTEM_SIZEABLE = 0x00020000,

		/// <summary>The object is a hyperlink that has been visited (previously clicked) by a user.</summary>
		STATE_SYSTEM_TRAVERSED = 0x00800000,

		/// <summary>The object is unavailable.</summary>
		STATE_SYSTEM_UNAVAILABLE = 0x00000001,
	}

	/// <summary>Flags for <see cref="PrintWindow"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "00b38cd8-1cfb-408e-88da-6e61563d9d8e")]
	[Flags]
	public enum PW : uint
	{
		/// <summary>Render the entire window.</summary>
		PW_ENTIREWINDOW = 0,

		/// <summary>Only the client area of the window is copied to hdcBlt. By default, the entire window is copied.</summary>
		PW_CLIENTONLY = 1,

		/// <summary>Undocumented</summary>
		PW_RENDERFULLCONTENT = 0x00000002,
	}

	/// <summary>Window sizing and positioning flags.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "setwindowpos")]
	[Flags]
	public enum SetWindowPosFlags : uint
	{
		/// <summary>
		/// If the calling thread and the thread that owns the window are attached to different input queues, the system posts the
		/// request to the thread that owns the window. This prevents the calling thread from blocking its execution while other threads
		/// process the request.
		/// </summary>
		SWP_ASYNCWINDOWPOS = 0x4000,

		/// <summary>Prevents generation of the WM_SYNCPAINT message.</summary>
		SWP_DEFERERASE = 0x2000,

		/// <summary>Draws a frame (defined in the window's class description) around the window.</summary>
		SWP_DRAWFRAME = 0x0020,

		/// <summary>
		/// Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to the window, even if the
		/// window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE is sent only when the window's size is being changed.
		/// </summary>
		SWP_FRAMECHANGED = 0x0020,

		/// <summary>Hides the window.</summary>
		SWP_HIDEWINDOW = 0x0080,

		/// <summary>
		/// Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the topmost or
		/// non-topmost group (depending on the setting of the hWndInsertAfter parameter).
		/// </summary>
		SWP_NOACTIVATE = 0x0010,

		/// <summary>
		/// Discards the entire contents of the client area. If this flag is not specified, the valid contents of the client area are
		/// saved and copied back into the client area after the window is sized or repositioned.
		/// </summary>
		SWP_NOCOPYBITS = 0x0100,

		/// <summary>Retains the current position (ignores X and Y parameters).</summary>
		SWP_NOMOVE = 0x0002,

		/// <summary>Does not change the owner window's position in the Z order.</summary>
		SWP_NOOWNERZORDER = 0x0200,

		/// <summary>
		/// Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to the client area, the
		/// nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of the
		/// window being moved. When this flag is set, the application must explicitly invalidate or redraw any parts of the window and
		/// parent window that need redrawing.
		/// </summary>
		SWP_NOREDRAW = 0x0008,

		/// <summary>Same as the SWP_NOOWNERZORDER flag.</summary>
		SWP_NOREPOSITION = 0x0200,

		/// <summary>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</summary>
		SWP_NOSENDCHANGING = 0x0400,

		/// <summary>Retains the current size (ignores the cx and cy parameters).</summary>
		SWP_NOSIZE = 0x0001,

		/// <summary>Retains the current Z order (ignores the hWndInsertAfter parameter).</summary>
		SWP_NOZORDER = 0x0004,

		/// <summary>Displays the window.</summary>
		SWP_SHOWWINDOW = 0x0040,
	}

	/// <summary>Commands for WM_SYSCOMMAND.</summary>
	[PInvokeData("winuser.h")]
	public enum SysCommand : int
	{
		/// <summary/>
		SC_ARRANGE = 0xF110,

		/// <summary>Closes the window.</summary>
		SC_CLOSE = 0xF060,

		/// <summary>
		/// Changes the cursor to a question mark with a pointer. If the user then clicks a control in the dialog box, the control
		/// receives a WM_HELP message.
		/// </summary>
		SC_CONTEXTHELP = 0xF180,

		/// <summary>Selects the default item; the user double-clicked the window menu.</summary>
		SC_DEFAULT = 0xF160,

		/// <summary>
		/// Activates the window associated with the application-specified hot key. The lParam parameter identifies the window to activate.
		/// </summary>
		SC_HOTKEY = 0xF150,

		/// <summary>Scrolls horizontally.</summary>
		SC_HSCROLL = 0xF080,

		/// <summary>Indicates whether the screen saver is secure.</summary>
		SCF_ISSECURE = 0x00000001,

		/// <summary>Retrieves the window menu as a result of a keystroke. For more information, see the Remarks section.</summary>
		SC_KEYMENU = 0xF100,

		/// <summary>Maximizes the window.</summary>
		SC_MAXIMIZE = 0xF030,

		/// <summary>Minimizes the window.</summary>
		SC_MINIMIZE = 0xF020,

		/// <summary>
		/// Sets the state of the display. This command supports devices that have power-saving features, such as a battery-powered
		/// personal computer.
		/// <para>The lParam parameter can have the following values:</para>
		/// <list type="bullet">
		/// <item>-1 (the display is powering on)</item>
		/// <item>1 (the display is going to low power)</item>
		/// <item>2 (the display is being shut off)</item>
		/// </list>
		/// </summary>
		SC_MONITORPOWER = 0xF170,

		/// <summary>Retrieves the window menu as a result of a mouse click.</summary>
		SC_MOUSEMENU = 0xF090,

		/// <summary>Moves the window.</summary>
		SC_MOVE = 0xF010,

		/// <summary>Moves to the next window.</summary>
		SC_NEXTWINDOW = 0xF040,

		/// <summary>Moves to the previous window.</summary>
		SC_PREVWINDOW = 0xF050,

		/// <summary>Restores the window to its normal position and size.</summary>
		SC_RESTORE = 0xF120,

		/// <summary>Executes the screen saver application specified in the [boot] section of the System.ini file.</summary>
		SC_SCREENSAVE = 0xF140,

		/// <summary/>
		SC_SEPARATOR = 0xF00F,

		/// <summary>Sizes the window.</summary>
		SC_SIZE = 0xF000,

		/// <summary>Activates the Start menu.</summary>
		SC_TASKLIST = 0xF130,

		/// <summary>Scrolls vertically.</summary>
		SC_VSCROLL = 0xF070,
	}

	/// <summary>Options for functions related to popup menus and windows.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum TrackPopupMenuFlags : uint
	{
		/// <summary>The user can select menu items with only the left mouse button.</summary>
		TPM_LEFTBUTTON = 0x0000,

		/// <summary>The user can select menu items with both the left and right mouse buttons.</summary>
		TPM_RIGHTBUTTON = 0x0002,

		/// <summary>
		/// Positions the pop-up window so that its left edge is aligned with the coordinate specified by the anchorPoint-&gt;x parameter.
		/// </summary>
		TPM_LEFTALIGN = 0x0000,

		/// <summary>Centers pop-up window horizontally relative to the coordinate specified by the anchorPoint-&gt;x parameter.</summary>
		TPM_CENTERALIGN = 0x0004,

		/// <summary>
		/// Positions the pop-up window so that its right edge is aligned with the coordinate specified by the anchorPoint-&gt;x parameter.
		/// </summary>
		TPM_RIGHTALIGN = 0x0008,

		/// <summary>Positions the shortcut menu so that its top side is aligned with the coordinate specified by the y parameter.</summary>
		TPM_TOPALIGN = 0x0000,

		/// <summary>Centers the shortcut menu vertically relative to the coordinate specified by the y parameter.</summary>
		TPM_VCENTERALIGN = 0x0010,

		/// <summary>Positions the shortcut menu so that its bottom side is aligned with the coordinate specified by the y parameter.</summary>
		TPM_BOTTOMALIGN = 0x0020,

		/// <summary>
		/// If the menu cannot be shown at the specified location without overlapping the excluded rectangle, the system tries to
		/// accommodate the requested horizontal alignment before the requested vertical alignment.
		/// </summary>
		TPM_HORIZONTAL = 0x0000,

		/// <summary>
		/// If the menu cannot be shown at the specified location without overlapping the excluded rectangle, the system tries to
		/// accommodate the requested vertical alignment before the requested horizontal alignment.
		/// </summary>
		TPM_VERTICAL = 0x0040,

		/// <summary>The function does not send notification messages when the user clicks a menu item.</summary>
		TPM_NONOTIFY = 0x0080,

		/// <summary>The function returns the menu item identifier of the user's selection in the return value.</summary>
		TPM_RETURNCMD = 0x0100,

		/// <summary>Displays a menu when another menu is already displayed. This is intended to support context menus within a menu.</summary>
		TPM_RECURSE = 0x0001,

		/// <summary>Animates the menu from left to right.</summary>
		TPM_HORPOSANIMATION = 0x0400,

		/// <summary>Animates the menu from right to left.</summary>
		TPM_HORNEGANIMATION = 0x0800,

		/// <summary>Animates the menu from top to bottom.</summary>
		TPM_VERPOSANIMATION = 0x1000,

		/// <summary>Animates the menu from bottom to top.</summary>
		TPM_VERNEGANIMATION = 0x2000,

		/// <summary>Displays menu without animation.</summary>
		TPM_NOANIMATION = 0x4000,

		/// <summary>For right-to-left text layout.</summary>
		TPM_LAYOUTRTL = 0x8000,

		/// <summary>
		/// Restricts the pop-up window to within the work area. If this flag is not set, the pop-up window is restricted to the work
		/// area only if the input point is within the work area. For more information, see the rcWork and rcMonitor members of the
		/// MONITORINFO structure.
		/// </summary>
		TPM_WORKAREA = 0x10000,
	}

	/// <summary>Flags for <see cref="UpdateLayeredWindow(HWND, HDC, in POINT, in SIZE, HDC, in POINT, COLORREF, in Gdi32.BLENDFUNCTION, UpdateLayeredWindowFlags)"/></summary>
	[PInvokeData("winuser.h", MSDNShortId = "updatelayeredwindow")]
	[Flags]
	public enum UpdateLayeredWindowFlags
	{
		/// <summary>Use crKey as the transparency color.</summary>
		ULW_COLORKEY = 0x00000001,

		/// <summary>
		/// Use pblend as the blend function. If the display mode is 256 colors or less, the effect of this value is the same as the
		/// effect of ULW_OPAQUE.
		/// </summary>
		ULW_ALPHA = 0x00000002,

		/// <summary>Draw an opaque layered window.</summary>
		ULW_OPAQUE = 0x00000004,

		/// <summary>
		/// Force the UpdateLayeredWindowIndirect function to fail if the current window size does not match the size specified in the psize.
		/// </summary>
		ULW_EX_NORESIZE = 0x00000008,
	}

	/// <summary>Window class styles.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum WindowClassStyles : uint
	{
		/// <summary>
		/// Aligns the window's client area on a byte boundary (in the x direction). This style affects the width of the window and its
		/// horizontal placement on the display.
		/// </summary>
		CS_BYTEALIGNCLIENT = 0x1000,

		/// <summary>
		/// Aligns the window on a byte boundary (in the x direction). This style affects the width of the window and its horizontal
		/// placement on the display.
		/// </summary>
		CS_BYTEALIGNWINDOW = 0x2000,

		/// <summary>
		/// Allocates one device context to be shared by all windows in the class. Because window classes are process specific, it is
		/// possible for multiple threads of an application to create a window of the same class. It is also possible for the threads to
		/// attempt to use the device context simultaneously. When this happens, the system allows only one thread to successfully finish
		/// its drawing operation.
		/// </summary>
		CS_CLASSDC = 0x0040,

		/// <summary>
		/// Sends a double-click message to the window procedure when the user double-clicks the mouse while the cursor is within a
		/// window belonging to the class.
		/// </summary>
		CS_DBLCLKS = 0x0008,

		/// <summary>
		/// Enables the drop shadow effect on a window. The effect is turned on and off through SPI_SETDROPSHADOW. Typically, this is
		/// enabled for small, short-lived windows such as menus to emphasize their Z-order relationship to other windows. Windows
		/// created from a class with this style must be top-level windows; they may not be child windows.
		/// </summary>
		CS_DROPSHADOW = 0x00020000,

		/// <summary>
		/// Indicates that the window class is an application global class. For more information, see the "Application Global Classes"
		/// section of About Window Classes.
		/// </summary>
		CS_GLOBALCLASS = 0x4000,

		/// <summary>Redraws the entire window if a movement or size adjustment changes the width of the client area.</summary>
		CS_HREDRAW = 0x0002,

		/// <summary>Disables Close on the window menu.</summary>
		CS_NOCLOSE = 0x0200,

		/// <summary>Allocates a unique device context for each window in the class.</summary>
		CS_OWNDC = 0x0020,

		/// <summary>
		/// Sets the clipping rectangle of the child window to that of the parent window so that the child can draw on the parent. A
		/// window with the CS_PARENTDC style bit receives a regular device context from the system's cache of device contexts. It does
		/// not give the child the parent's device context or device context settings. Specifying CS_PARENTDC enhances an application's performance.
		/// </summary>
		CS_PARENTDC = 0x0080,

		/// <summary>
		/// Saves, as a bitmap, the portion of the screen image obscured by a window of this class. When the window is removed, the
		/// system uses the saved bitmap to restore the screen image, including other windows that were obscured. Therefore, the system
		/// does not send WM_PAINT messages to windows that were obscured if the memory used by the bitmap has not been discarded and if
		/// other screen actions have not invalidated the stored image.
		/// <para>
		/// This style is useful for small windows (for example, menus or dialog boxes) that are displayed briefly and then removed
		/// before other screen activity takes place. This style increases the time required to display the window, because the system
		/// must first allocate memory to store the bitmap.
		/// </para>
		/// </summary>
		CS_SAVEBITS = 0x0800,

		/// <summary>Redraws the entire window if a movement or size adjustment changes the height of the client area.</summary>
		CS_VREDRAW = 0x0001,

		/// <summary>Undocumented.</summary>
		CS_IME = 0x00010000,
	}

	/// <summary>The display affinity setting. This setting specifies where the window's contents are can be displayed.</summary>
	[PInvokeData("winuser.h")]
	public enum WindowDisplayAffinity : uint
	{
		/// <summary>The window's contents can be displayed anywhere.</summary>
		WDA_NONE = 0x00000000,

		/// <summary>The window's contents can only be displayed on a monitor.</summary>
		WDA_MONITOR = 0x00000001
	}

	/// <summary>Flags used by <see cref="WINDOWPLACEMENT.flags"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "windowplacement")]
	[Flags]
	public enum WindowPlacementFlags : uint
	{
		/// <summary>
		/// The coordinates of the minimized window may be specified.
		/// <para>This flag must be specified if the coordinates are set in the ptMinPosition member.</para>
		/// </summary>
		WPF_SETMINPOSITION = 0x0001,

		/// <summary>
		/// The restored window will be maximized, regardless of whether it was maximized before it was minimized. This setting is only
		/// valid the next time the window is restored. It does not change the default restoration behavior.
		/// <para>This flag is only valid when the SW_SHOWMINIMIZED value is specified for the showCmd member.</para>
		/// </summary>
		WPF_RESTORETOMAXIMIZED = 0x0002,

		/// <summary>
		/// If the calling thread and the thread that owns the window are attached to different input queues, the system posts the
		/// request to the thread that owns the window. This prevents the calling thread from blocking its execution while other threads
		/// process the request.
		/// </summary>
		WPF_ASYNCWINDOWPLACEMENT = 0x0004
	}

	/// <summary>
	/// <para>
	/// Calculates the required size of the window rectangle, based on the desired client-rectangle size. The window rectangle can then
	/// be passed to the CreateWindow function to create a window whose client area is the desired size.
	/// </para>
	/// <para>To specify an extended window style, use the AdjustWindowRectEx function.</para>
	/// </summary>
	/// <param name="lpRect">
	/// <para>Type: <c>LPRECT</c></para>
	/// <para>
	/// A pointer to a RECT structure that contains the coordinates of the top-left and bottom-right corners of the desired client area.
	/// When the function returns, the structure contains the coordinates of the top-left and bottom-right corners of the window to
	/// accommodate the desired client area.
	/// </para>
	/// </param>
	/// <param name="dwStyle">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The window style of the window whose required size is to be calculated. Note that you cannot specify the <c>WS_OVERLAPPED</c> style.
	/// </para>
	/// </param>
	/// <param name="bMenu">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Indicates whether the window has a menu.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A client rectangle is the smallest rectangle that completely encloses a client area. A window rectangle is the smallest rectangle
	/// that completely encloses the window, which includes the client area and the nonclient area.
	/// </para>
	/// <para>The <c>AdjustWindowRect</c> function does not add extra space when a menu bar wraps to two or more rows.</para>
	/// <para>
	/// The <c>AdjustWindowRect</c> function does not take the <c>WS_VSCROLL</c> or <c>WS_HSCROLL</c> styles into account. To account for
	/// the scroll bars, call the GetSystemMetrics function with <c>SM_CXVSCROLL</c> or <c>SM_CYHSCROLL</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-adjustwindowrect BOOL AdjustWindowRect( LPRECT lpRect,
	// DWORD dwStyle, BOOL bMenu );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "adjustwindowrect")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AdjustWindowRect(ref RECT lpRect, WindowStyles dwStyle, [MarshalAs(UnmanagedType.Bool)] bool bMenu);

	/// <summary>
	/// <para>
	/// Calculates the required size of the window rectangle, based on the desired size of the client rectangle. The window rectangle can
	/// then be passed to the CreateWindowEx function to create a window whose client area is the desired size.
	/// </para>
	/// </summary>
	/// <param name="lpRect">
	/// <para>Type: <c>LPRECT</c></para>
	/// <para>
	/// A pointer to a RECT structure that contains the coordinates of the top-left and bottom-right corners of the desired client area.
	/// When the function returns, the structure contains the coordinates of the top-left and bottom-right corners of the window to
	/// accommodate the desired client area.
	/// </para>
	/// </param>
	/// <param name="dwStyle">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The window style of the window whose required size is to be calculated. Note that you cannot specify the <c>WS_OVERLAPPED</c> style.
	/// </para>
	/// </param>
	/// <param name="bMenu">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Indicates whether the window has a menu.</para>
	/// </param>
	/// <param name="dwExStyle">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The extended window style of the window whose required size is to be calculated.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A client rectangle is the smallest rectangle that completely encloses a client area. A window rectangle is the smallest rectangle
	/// that completely encloses the window, which includes the client area and the nonclient area.
	/// </para>
	/// <para>The <c>AdjustWindowRectEx</c> function does not add extra space when a menu bar wraps to two or more rows.</para>
	/// <para>
	/// The <c>AdjustWindowRectEx</c> function does not take the <c>WS_VSCROLL</c> or <c>WS_HSCROLL</c> styles into account. To account
	/// for the scroll bars, call the GetSystemMetrics function with <c>SM_CXVSCROLL</c> or <c>SM_CYHSCROLL</c>.
	/// </para>
	/// <para>
	/// This API is not DPI aware, and should not be used if the calling thread is per-monitor DPI aware. For the DPI-aware version of
	/// this API, see AdjustWindowsRectExForDPI. For more information on DPI awareness, see the Windows High DPI documentation.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-adjustwindowrectex BOOL AdjustWindowRectEx( LPRECT lpRect,
	// DWORD dwStyle, BOOL bMenu, DWORD dwExStyle );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "adjustwindowrectex")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AdjustWindowRectEx(ref RECT lpRect, WindowStyles dwStyle, [MarshalAs(UnmanagedType.Bool)] bool bMenu, WindowStylesEx dwExStyle);

	/// <summary>
	/// <para>
	/// Enables the specified process to set the foreground window using the SetForegroundWindow function. The calling process must
	/// already be able to set the foreground window. For more information, see Remarks later in this topic.
	/// </para>
	/// </summary>
	/// <param name="dwProcessId">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The identifier of the process that will be enabled to set the foreground window. If this parameter is <c>ASFW_ANY</c>, all
	/// processes will be enabled to set the foreground window.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. The function will fail if the calling process cannot set the foreground window.
	/// To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The system restricts which processes can set the foreground window. A process can set the foreground window only if one of the
	/// following conditions is true:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The process is the foreground process.</term>
	/// </item>
	/// <item>
	/// <term>The process was started by the foreground process.</term>
	/// </item>
	/// <item>
	/// <term>The process received the last input event.</term>
	/// </item>
	/// <item>
	/// <term>There is no foreground process.</term>
	/// </item>
	/// <item>
	/// <term>The foreground process is being debugged.</term>
	/// </item>
	/// <item>
	/// <term>The foreground is not locked (see LockSetForegroundWindow).</term>
	/// </item>
	/// <item>
	/// <term>The foreground lock time-out has expired (see <c>SPI_GETFOREGROUNDLOCKTIMEOUT</c> in SystemParametersInfo).</term>
	/// </item>
	/// <item>
	/// <term>No menus are active.</term>
	/// </item>
	/// </list>
	/// <para>
	/// A process that can set the foreground window can enable another process to set the foreground window by calling
	/// <c>AllowSetForegroundWindow</c>. The process specified by dwProcessId loses the ability to set the foreground window the next
	/// time the user generates input, unless the input is directed at that process, or the next time a process calls
	/// <c>AllowSetForegroundWindow</c>, unless that process is specified.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-allowsetforegroundwindow BOOL AllowSetForegroundWindow(
	// DWORD dwProcessId );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "allowsetforegroundwindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AllowSetForegroundWindow(uint dwProcessId);

	/// <summary>
	/// <para>
	/// Enables you to produce special effects when showing or hiding windows. There are four types of animation: roll, slide, collapse
	/// or expand, and alpha-blended fade.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to animate. The calling thread must own this window.</para>
	/// </param>
	/// <param name="dwTime">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The time it takes to play the animation, in milliseconds. Typically, an animation takes 200 milliseconds to play.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The type of animation. This parameter can be one or more of the following values. Note that, by default, these flags take effect
	/// when showing a window. To take effect when hiding a window, use <c>AW_HIDE</c> and a logical OR operator with the appropriate flags.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>AW_ACTIVATE 0x00020000</term>
	/// <term>Activates the window. Do not use this value with AW_HIDE.</term>
	/// </item>
	/// <item>
	/// <term>AW_BLEND 0x00080000</term>
	/// <term>Uses a fade effect. This flag can be used only if hwnd is a top-level window.</term>
	/// </item>
	/// <item>
	/// <term>AW_CENTER 0x00000010</term>
	/// <term>
	/// Makes the window appear to collapse inward if AW_HIDE is used or expand outward if the AW_HIDE is not used. The various direction
	/// flags have no effect.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AW_HIDE 0x00010000</term>
	/// <term>Hides the window. By default, the window is shown.</term>
	/// </item>
	/// <item>
	/// <term>AW_HOR_POSITIVE 0x00000001</term>
	/// <term>
	/// Animates the window from left to right. This flag can be used with roll or slide animation. It is ignored when used with
	/// AW_CENTER or AW_BLEND.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AW_HOR_NEGATIVE 0x00000002</term>
	/// <term>
	/// Animates the window from right to left. This flag can be used with roll or slide animation. It is ignored when used with
	/// AW_CENTER or AW_BLEND.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AW_SLIDE 0x00040000</term>
	/// <term>Uses slide animation. By default, roll animation is used. This flag is ignored when used with AW_CENTER.</term>
	/// </item>
	/// <item>
	/// <term>AW_VER_POSITIVE 0x00000004</term>
	/// <term>
	/// Animates the window from top to bottom. This flag can be used with roll or slide animation. It is ignored when used with
	/// AW_CENTER or AW_BLEND.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AW_VER_NEGATIVE 0x00000008</term>
	/// <term>
	/// Animates the window from bottom to top. This flag can be used with roll or slide animation. It is ignored when used with
	/// AW_CENTER or AW_BLEND.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. The function will fail in the following situations:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If the window is already visible and you are trying to show the window.</term>
	/// </item>
	/// <item>
	/// <term>If the window is already hidden and you are trying to hide the window.</term>
	/// </item>
	/// <item>
	/// <term>If there is no direction specified for the slide or roll animation.</term>
	/// </item>
	/// <item>
	/// <term>When trying to animate a child window with <c>AW_BLEND</c>.</term>
	/// </item>
	/// <item>
	/// <term>If the thread does not own the window. Note that, in this case, <c>AnimateWindow</c> fails but GetLastError returns <c>ERROR_SUCCESS</c>.</term>
	/// </item>
	/// </list>
	/// <para>To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>To show or hide a window without special effects, use ShowWindow.</para>
	/// <para>
	/// When using slide or roll animation, you must specify the direction. It can be either <c>AW_HOR_POSITIVE</c>,
	/// <c>AW_HOR_NEGATIVE</c>, AW_VER_POSITIVE, or AW_VER_NEGATIVE.
	/// </para>
	/// <para>
	/// You can combine <c>AW_HOR_POSITIVE</c> or <c>AW_HOR_NEGATIVE</c> with <c>AW_VER_POSITIVE</c> or <c>AW_VER_NEGATIVE</c> to animate
	/// a window diagonally.
	/// </para>
	/// <para>
	/// The window procedures for the window and its child windows should handle any WM_PRINT or WM_PRINTCLIENT messages. Dialog boxes,
	/// controls, and common controls already handle <c>WM_PRINTCLIENT</c>. The default window procedure already handles <c>WM_PRINT</c>.
	/// </para>
	/// <para>If a child window is displayed partially clipped, when it is animated it will have holes where it is clipped.</para>
	/// <para><c>AnimateWindow</c> supports RTL windows.</para>
	/// <para>Avoid animating a window that has a drop shadow because it produces visually distracting, jerky animations.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-animatewindow BOOL AnimateWindow( HWND hWnd, DWORD dwTime,
	// DWORD dwFlags );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "animatewindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AnimateWindow(HWND hWnd, uint dwTime, uint dwFlags);

	/// <summary>
	/// <para>
	/// Indicates whether an owned, visible, top-level pop-up, or overlapped window exists on the screen. The function searches the
	/// entire screen, not just the calling application's client area.
	/// </para>
	/// <para>This function is provided only for compatibility with 16-bit versions of Windows. It is generally not useful.</para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If a pop-up window exists, the return value is nonzero, even if the pop-up window is completely covered by other windows.</para>
	/// <para>If a pop-up window does not exist, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function does not detect unowned pop-up windows or windows that do not have the <c>WS_VISIBLE</c> style bit set.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-anypopup BOOL AnyPopup( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "anypopup")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AnyPopup();

	/// <summary>
	/// <para>Arranges all the minimized (iconic) child windows of the specified parent window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the parent window.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>UINT</c></c></para>
	/// <para>If the function succeeds, the return value is the height of one row of icons.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application that maintains its own minimized child windows can use the <c>ArrangeIconicWindows</c> function to arrange icons
	/// in a parent window. This function can also arrange icons on the desktop. To retrieve the window handle to the desktop window, use
	/// the GetDesktopWindow function.
	/// </para>
	/// <para>
	/// An application sends the WM_MDIICONARRANGE message to the multiple-document interface (MDI) client window to prompt the client
	/// window to arrange its minimized MDI child windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-arrangeiconicwindows UINT ArrangeIconicWindows( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "arrangeiconicwindows")]
	public static extern uint ArrangeIconicWindows(HWND hWnd);

	/// <summary>
	/// <para>Allocates memory for a multiple-window- position structure and returns the handle to the structure.</para>
	/// </summary>
	/// <param name="nNumWindows">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The initial number of windows for which to store position information. The DeferWindowPos function increases the size of the
	/// structure, if necessary.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HDWP</c></c></para>
	/// <para>
	/// If the function succeeds, the return value identifies the multiple-window-position structure. If insufficient system resources
	/// are available to allocate the structure, the return value is <c>NULL</c>. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The multiple-window-position structure is an internal structure; an application cannot access it directly.</para>
	/// <para>
	/// DeferWindowPos fills the multiple-window-position structure with information about the target position for one or more windows
	/// about to be moved. The EndDeferWindowPos function accepts the handle to this structure and repositions the windows by using the
	/// information stored in the structure.
	/// </para>
	/// <para>
	/// If any of the windows in the multiple-window- position structure have the <c>SWP_HIDEWINDOW</c> or <c>SWP_SHOWWINDOW</c> flag
	/// set, none of the windows are repositioned.
	/// </para>
	/// <para>
	/// If the system must increase the size of the multiple-window- position structure beyond the initial size specified by the
	/// nNumWindows parameter but cannot allocate enough memory to do so, the system fails the entire window positioning sequence (
	/// <c>BeginDeferWindowPos</c>, DeferWindowPos, and EndDeferWindowPos). By specifying the maximum size needed, an application can
	/// detect and process failure early in the process.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-begindeferwindowpos HDWP BeginDeferWindowPos( int
	// nNumWindows );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "begindeferwindowpos")]
	public static extern HDWP BeginDeferWindowPos(int nNumWindows);

	/// <summary>
	/// <para>
	/// Brings the specified window to the top of the Z order. If the window is a top-level window, it is activated. If the window is a
	/// child window, the top-level parent window associated with the child window is activated.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to bring to the top of the Z order.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Use the <c>BringWindowToTop</c> function to uncover any window that is partially or completely obscured by other windows.</para>
	/// <para>
	/// Calling this function is similar to calling the SetWindowPos function to change a window's position in the Z order.
	/// <c>BringWindowToTop</c> does not make a window a top-level window.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-bringwindowtotop BOOL BringWindowToTop( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "bringwindowtotop")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BringWindowToTop(HWND hWnd);

	/// <summary>
	/// <para>
	/// Calculates an appropriate pop-up window position using the specified anchor point, pop-up window size, flags, and the optional
	/// exclude rectangle. When the specified pop-up window size is smaller than the desktop window size, use the
	/// <c>CalculatePopupWindowPosition</c> function to ensure that the pop-up window is fully visible on the desktop window, regardless
	/// of the specified anchor point.
	/// </para>
	/// </summary>
	/// <param name="anchorPoint">
	/// <para>Type: <c>const POINT*</c></para>
	/// <para>The specified anchor point.</para>
	/// </param>
	/// <param name="windowSize">
	/// <para>Type: <c>const SIZE*</c></para>
	/// <para>The specified window size.</para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Use one of the following flags to specify how the function positions the pop-up window horizontally and vertically. The flags are
	/// the same as the vertical and horizontal positioning flags of the TrackPopupMenuEx function.
	/// </para>
	/// <para>Use one of the following flags to specify how the function positions the pop-up window horizontally.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_CENTERALIGN 0x0004L</term>
	/// <term>Centers pop-up window horizontally relative to the coordinate specified by the anchorPoint-&gt;x parameter.</term>
	/// </item>
	/// <item>
	/// <term>TPM_LEFTALIGN 0x0000L</term>
	/// <term>Positions the pop-up window so that its left edge is aligned with the coordinate specified by the anchorPoint-&gt;x parameter.</term>
	/// </item>
	/// <item>
	/// <term>TPM_RIGHTALIGN 0x0008L</term>
	/// <term>Positions the pop-up window so that its right edge is aligned with the coordinate specified by the anchorPoint-&gt;x parameter.</term>
	/// </item>
	/// </list>
	/// <para>Uses one of the following flags to specify how the function positions the pop-up window vertically.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_BOTTOMALIGN 0x0020L</term>
	/// <term>
	/// Positions the pop-up window so that its bottom edge is aligned with the coordinate specified by the anchorPoint-&gt;y parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TPM_TOPALIGN 0x0000L</term>
	/// <term>Positions the pop-up window so that its top edge is aligned with the coordinate specified by the anchorPoint-&gt;y parameter.</term>
	/// </item>
	/// <item>
	/// <term>TPM_VCENTERALIGN 0x0010L</term>
	/// <term>Centers the pop-up window vertically relative to the coordinate specified by the anchorPoint-&gt;y parameter.</term>
	/// </item>
	/// </list>
	/// <para>Use one of the following flags to specify whether to accommodate horizontal or vertical alignment.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_HORIZONTAL 0x0000L</term>
	/// <term>
	/// If the pop-up window cannot be shown at the specified location without overlapping the excluded rectangle, the system tries to
	/// accommodate the requested horizontal alignment before the requested vertical alignment.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TPM_VERTICAL 0x0040L</term>
	/// <term>
	/// If the pop-up window cannot be shown at the specified location without overlapping the excluded rectangle, the system tries to
	/// accommodate the requested vertical alignment before the requested horizontal alignment.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The following flag is available starting with Windows 7.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TPM_WORKAREA 0x10000L</term>
	/// <term>
	/// Restricts the pop-up window to within the work area. If this flag is not set, the pop-up window is restricted to the work area
	/// only if the input point is within the work area. For more information, see the rcWork and rcMonitor members of the MONITORINFO structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="excludeRect">
	/// <para>Type: <c>RECT*</c></para>
	/// <para>A pointer to a structure that specifies the exclude rectangle. It can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="popupWindowPosition">
	/// <para>Type: <c>RECT*</c></para>
	/// <para>A pointer to a structure that specifies the pop-up window position.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>
	/// If the function succeeds, it returns <c>TRUE</c>; otherwise, it returns <c>FALSE</c>. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para><c>TPM_WORKAREA</c> is supported for the TrackPopupMenu and TrackPopupMenuEx functions.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-calculatepopupwindowposition BOOL
	// CalculatePopupWindowPosition( const POINT *anchorPoint, const SIZE *windowSize, UINT flags, RECT *excludeRect, RECT
	// *popupWindowPosition );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "calculatepopupwindowposition")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CalculatePopupWindowPosition(in POINT anchorPoint, in SIZE windowSize, TrackPopupMenuFlags flags, [Optional] PRECT? excludeRect, out RECT popupWindowPosition);

	/// <summary>Passes message information to the specified window procedure.</summary>
	/// <param name="lpPrevWndFunc">
	/// <para>Type: <c>WNDPROC</c></para>
	/// <para>
	/// The previous window procedure. If this value is obtained by calling the GetWindowLong function with the nIndex parameter set to
	/// <c>GWL_WNDPROC</c> or <c>DWL_DLGPROC</c>, it is actually either the address of a window or dialog box procedure, or a special
	/// internal value meaningful only to <c>CallWindowProc</c>.
	/// </para>
	/// </param>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window procedure to receive the message.</para>
	/// </param>
	/// <param name="Msg">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The message.</para>
	/// </param>
	/// <param name="wParam">
	/// <para>Type: <c>WPARAM</c></para>
	/// <para>Additional message-specific information. The contents of this parameter depend on the value of the Msg parameter.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>Additional message-specific information. The contents of this parameter depend on the value of the Msg parameter.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>LRESULT</c></c></para>
	/// <para>The return value specifies the result of the message processing and depends on the message sent.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use the <c>CallWindowProc</c> function for window subclassing. Usually, all windows with the same class share one window
	/// procedure. A subclass is a window or set of windows with the same class whose messages are intercepted and processed by another
	/// window procedure (or procedures) before being passed to the window procedure of the class.
	/// </para>
	/// <para>
	/// The SetWindowLong function creates the subclass by changing the window procedure associated with a particular window, causing the
	/// system to call the new window procedure instead of the previous one. An application must pass any messages not processed by the
	/// new window procedure to the previous window procedure by calling <c>CallWindowProc</c>. This allows the application to create a
	/// chain of window procedures.
	/// </para>
	/// <para>
	/// If <c>STRICT</c> is defined, the lpPrevWndFunc parameter has the data type <c>WNDPROC</c>. The <c>WNDPROC</c> type is declared as follows:
	/// </para>
	/// <para>
	/// If <c>STRICT</c> is not defined, the lpPrevWndFunc parameter has the data type <c>FARPROC</c>. The <c>FARPROC</c> type is
	/// declared as follows:
	/// </para>
	/// <para>
	/// In C, the <c>FARPROC</c> declaration indicates a callback function that has an unspecified parameter list. In C++, however, the
	/// empty parameter list in the declaration indicates that a function has no parameters. This subtle distinction can break careless
	/// code. Following is one way to handle this situation:
	/// </para>
	/// <para>
	/// For further information about functions declared with empty argument lists, refer to The C++ Programming Language, Second
	/// Edition, by Bjarne Stroustrup.
	/// </para>
	/// <para>
	/// The <c>CallWindowProc</c> function handles Unicode-to-ANSI conversion. You cannot take advantage of this conversion if you call
	/// the window procedure directly.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Subclassing a Window</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-callwindowproca LRESULT CallWindowProcA( WNDPROC
	// lpPrevWndFunc, HWND hWnd, UINT Msg, WPARAM wParam, LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern IntPtr CallWindowProc(WindowProc lpPrevWndFunc, HWND hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

	/// <summary>Passes message information to the specified window procedure.</summary>
	/// <param name="lpPrevWndFunc">
	/// <para>Type: <c>WNDPROC</c></para>
	/// <para>
	/// The previous window procedure. If this value is obtained by calling the GetWindowLong function with the nIndex parameter set to
	/// <c>GWL_WNDPROC</c> or <c>DWL_DLGPROC</c>, it is actually either the address of a window or dialog box procedure, or a special
	/// internal value meaningful only to <c>CallWindowProc</c>.
	/// </para>
	/// </param>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window procedure to receive the message.</para>
	/// </param>
	/// <param name="Msg">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The message.</para>
	/// </param>
	/// <param name="wParam">
	/// <para>Type: <c>WPARAM</c></para>
	/// <para>Additional message-specific information. The contents of this parameter depend on the value of the Msg parameter.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>Additional message-specific information. The contents of this parameter depend on the value of the Msg parameter.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>LRESULT</c></c></para>
	/// <para>The return value specifies the result of the message processing and depends on the message sent.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use the <c>CallWindowProc</c> function for window subclassing. Usually, all windows with the same class share one window
	/// procedure. A subclass is a window or set of windows with the same class whose messages are intercepted and processed by another
	/// window procedure (or procedures) before being passed to the window procedure of the class.
	/// </para>
	/// <para>
	/// The SetWindowLong function creates the subclass by changing the window procedure associated with a particular window, causing the
	/// system to call the new window procedure instead of the previous one. An application must pass any messages not processed by the
	/// new window procedure to the previous window procedure by calling <c>CallWindowProc</c>. This allows the application to create a
	/// chain of window procedures.
	/// </para>
	/// <para>
	/// If <c>STRICT</c> is defined, the lpPrevWndFunc parameter has the data type <c>WNDPROC</c>. The <c>WNDPROC</c> type is declared as follows:
	/// </para>
	/// <para>
	/// If <c>STRICT</c> is not defined, the lpPrevWndFunc parameter has the data type <c>FARPROC</c>. The <c>FARPROC</c> type is
	/// declared as follows:
	/// </para>
	/// <para>
	/// In C, the <c>FARPROC</c> declaration indicates a callback function that has an unspecified parameter list. In C++, however, the
	/// empty parameter list in the declaration indicates that a function has no parameters. This subtle distinction can break careless
	/// code. Following is one way to handle this situation:
	/// </para>
	/// <para>
	/// For further information about functions declared with empty argument lists, refer to The C++ Programming Language, Second
	/// Edition, by Bjarne Stroustrup.
	/// </para>
	/// <para>
	/// The <c>CallWindowProc</c> function handles Unicode-to-ANSI conversion. You cannot take advantage of this conversion if you call
	/// the window procedure directly.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Subclassing a Window</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-callwindowproca LRESULT CallWindowProcA( WNDPROC
	// lpPrevWndFunc, HWND hWnd, UINT Msg, WPARAM wParam, LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern IntPtr CallWindowProc([In] IntPtr lpPrevWndFunc, HWND hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

	/// <summary>
	/// <para>Cascades the specified child windows of the specified parent window.</para>
	/// </summary>
	/// <param name="hwndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the parent window. If this parameter is <c>NULL</c>, the desktop window is assumed.</para>
	/// </param>
	/// <param name="wHow">
	/// <para>Type: <c>UINT</c></para>
	/// <para>A cascade flag. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MDITILE_SKIPDISABLED 0x0002</term>
	/// <term>Prevents disabled MDI child windows from being cascaded.</term>
	/// </item>
	/// <item>
	/// <term>MDITILE_ZORDER 0x0004</term>
	/// <term>
	/// Arranges the windows in Z order. If this value is not specified, the windows are arranged using the order specified in the lpKids array.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpRect">
	/// <para>Type: <c>const RECT*</c></para>
	/// <para>
	/// A pointer to a structure that specifies the rectangular area, in client coordinates, within which the windows are arranged. This
	/// parameter can be <c>NULL</c>, in which case the client area of the parent window is used.
	/// </para>
	/// </param>
	/// <param name="cKids">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of elements in the array specified by the lpKids parameter. This parameter is ignored if lpKids is <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpKids">
	/// <para>Type: <c>const HWND*</c></para>
	/// <para>
	/// An array of handles to the child windows to arrange. If a specified child window is a top-level window with the style
	/// <c>WS_EX_TOPMOST</c> or <c>WS_EX_TOOLWINDOW</c>, the child window is not arranged. If this parameter is <c>NULL</c>, all child
	/// windows of the specified parent window (or of the desktop window) are arranged.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>WORD</c></c></para>
	/// <para>If the function succeeds, the return value is the number of windows arranged.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// By default, <c>CascadeWindows</c> arranges the windows in the order provided by the lpKids array, but preserves the Z-Order. If
	/// you specify the <c>MDITILE_ZORDER</c> flag, <c>CascadeWindows</c> arranges the windows in Z order.
	/// </para>
	/// <para>Calling <c>CascadeWindows</c> causes all maximized windows to be restored to their previous size.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-cascadewindows WORD CascadeWindows( HWND hwndParent, UINT
	// wHow, CONST RECT *lpRect, UINT cKids, const HWND *lpKids );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "cascadewindows")]
	public static extern ushort CascadeWindows([Optional] HWND hwndParent, uint wHow, [In, Optional] PRECT? lpRect, uint cKids, [Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] HWND[]? lpKids);

	/// <summary>
	/// <para>
	/// [Using the <c>ChangeWindowMessageFilter</c> function is not recommended, as it has process-wide scope. Instead, use the
	/// ChangeWindowMessageFilterEx function to control access to specific windows as needed. <c>ChangeWindowMessageFilter</c> may not be
	/// supported in future versions of Windows.]
	/// </para>
	/// <para>Adds or removes a message from the User Interface Privilege Isolation (UIPI) message filter.</para>
	/// </summary>
	/// <param name="message">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The message to add to or remove from the filter.</para>
	/// </param>
	/// <param name="dwFlag">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The action to be performed. One of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSGFLT_ADD 1</term>
	/// <term>Adds the message to the filter. This has the effect of allowing the message to be received.</term>
	/// </item>
	/// <item>
	/// <term>MSGFLT_REMOVE 2</term>
	/// <term>Removes the message from the filter. This has the effect of blocking the message.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> A message can be successfully removed from the filter, but that is not a guarantee that the message will be blocked.
	/// See the Remarks section for more details.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// UIPI is a security feature that prevents messages from being received from a lower integrity level sender. All such messages with
	/// a value above <c>WM_USER</c> are blocked by default. The filter, somewhat contrary to intuition, is a list of messages that are
	/// allowed through. Therefore, adding a message to the filter allows that message to be received from a lower integrity sender,
	/// while removing a message blocks that message from being received.
	/// </para>
	/// <para>
	/// Certain messages with a value less than <c>WM_USER</c> are required to pass through the filter regardless of the filter setting.
	/// You can call this function to remove one of those messages from the filter and it will return <c>TRUE</c>. However, the message
	/// will still be received by the calling process.
	/// </para>
	/// <para>
	/// Processes at or below <c>SECURITY_MANDATORY_LOW_RID</c> are not allowed to change the filter. If those processes call this
	/// function, it will fail.
	/// </para>
	/// <para>For more information on integrity levels, see Understanding and Working in Protected Mode Internet Explorer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-changewindowmessagefilter BOOL ChangeWindowMessageFilter(
	// UINT message, DWORD dwFlag );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "changewindowmessagefilter")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ChangeWindowMessageFilter(uint message, MessageFilterFlag dwFlag);

	/// <summary>
	/// <para>Modifies the User Interface Privilege Isolation (UIPI) message filter for a specified window.</para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window whose UIPI message filter is to be modified.</para>
	/// </param>
	/// <param name="message">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The message that the message filter allows through or blocks.</para>
	/// </param>
	/// <param name="action">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The action to be performed, and can take one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSGFLT_ALLOW 1</term>
	/// <term>
	/// Allows the message through the filter. This enables the message to be received by hWnd, regardless of the source of the message,
	/// even it comes from a lower privileged process.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSGFLT_DISALLOW 2</term>
	/// <term>
	/// Blocks the message to be delivered to hWnd if it comes from a lower privileged process, unless the message is allowed
	/// process-wide by using the ChangeWindowMessageFilter function or globally.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSGFLT_RESET 0</term>
	/// <term>
	/// Resets the window message filter for hWnd to the default. Any message allowed globally or process-wide will get through, but any
	/// message not included in those two categories, and which comes from a lower privileged process, will be blocked.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pChangeFilterStruct">
	/// <para>Type: <c>PCHANGEFILTERSTRUCT</c></para>
	/// <para>Optional pointer to a CHANGEFILTERSTRUCT structure.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>
	/// If the function succeeds, it returns <c>TRUE</c>; otherwise, it returns <c>FALSE</c>. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// UIPI is a security feature that prevents messages from being received from a lower-integrity-level sender. You can use this
	/// function to allow specific messages to be delivered to a window even if the message originates from a process at a lower
	/// integrity level. Unlike the ChangeWindowMessageFilter function, which controls the process message filter, the
	/// <c>ChangeWindowMessageFilterEx</c> function controls the window message filter.
	/// </para>
	/// <para>
	/// An application may use the ChangeWindowMessageFilter function to allow or block a message in a process-wide manner. If the
	/// message is allowed by either the process message filter or the window message filter, it will be delivered to the window.
	/// </para>
	/// <para>
	/// Note that processes at or below <c>SECURITY_MANDATORY_LOW_RID</c> are not allowed to change the message filter. If those
	/// processes call this function, it will fail and generate the extended error code, <c>ERROR_ACCESS_DENIED</c>.
	/// </para>
	/// <para>
	/// Certain messages whose value is smaller than <c>WM_USER</c> are required to be passed through the filter, regardless of the
	/// filter setting. There will be no effect when you attempt to use this function to allow or block such messages.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-changewindowmessagefilterex BOOL
	// ChangeWindowMessageFilterEx( HWND hwnd, UINT message, DWORD action, PCHANGEFILTERSTRUCT pChangeFilterStruct );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "changewindowmessagefilterex")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ChangeWindowMessageFilterEx(HWND hwnd, uint message, MessageFilterExAction action, ref CHANGEFILTERSTRUCT pChangeFilterStruct);

	/// <summary>
	/// <para>
	/// Determines which, if any, of the child windows belonging to a parent window contains the specified point. The search is
	/// restricted to immediate child windows. Grandchildren, and deeper descendant windows are not searched.
	/// </para>
	/// <para>To skip certain child windows, use the ChildWindowFromPointEx function.</para>
	/// </summary>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the parent window.</para>
	/// </param>
	/// <param name="Point">
	/// <para>Type: <c>POINT</c></para>
	/// <para>A structure that defines the client coordinates, relative to hWndParent, of the point to be checked.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>
	/// The return value is a handle to the child window that contains the point, even if the child window is hidden or disabled. If the
	/// point lies outside the parent window, the return value is <c>NULL</c>. If the point is within the parent window but not within
	/// any child window, the return value is a handle to the parent window.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The system maintains an internal list, containing the handles of the child windows associated with a parent window. The order of
	/// the handles in the list depends on the Z order of the child windows. If more than one child window contains the specified point,
	/// the system returns a handle to the first window in the list that contains the point.
	/// </para>
	/// <para>
	/// <c>ChildWindowFromPoint</c> treats an <c>HTTRANSPARENT</c> area of a standard control the same as other parts of the control. In
	/// contrast, RealChildWindowFromPoint treats an <c>HTTRANSPARENT</c> area differently; it returns the child window behind a
	/// transparent area of a control. For example, if the point is in a transparent area of a groupbox, <c>ChildWindowFromPoint</c>
	/// returns the groupbox while <c>RealChildWindowFromPoint</c> returns the child window behind the groupbox. However, both APIs
	/// return a static field, even though it, too, returns <c>HTTRANSPARENT</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see "Creating a Combo Box Toolbar" in Using Combo Boxes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-childwindowfrompoint HWND ChildWindowFromPoint( HWND
	// hWndParent, POINT Point );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "childwindowfrompoint")]
	public static extern HWND ChildWindowFromPoint(HWND hWndParent, POINT Point);

	/// <summary>
	/// <para>
	/// Determines which, if any, of the child windows belonging to the specified parent window contains the specified point. The
	/// function can ignore invisible, disabled, and transparent child windows. The search is restricted to immediate child windows.
	/// Grandchildren and deeper descendants are not searched.
	/// </para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the parent window.</para>
	/// </param>
	/// <param name="pt">
	/// <para>Type: <c>POINT</c></para>
	/// <para>A structure that defines the client coordinates (relative to hwndParent) of the point to be checked.</para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The child windows to be skipped. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CWP_ALL 0x0000</term>
	/// <term>Does not skip any child windows</term>
	/// </item>
	/// <item>
	/// <term>CWP_SKIPDISABLED 0x0002</term>
	/// <term>Skips disabled child windows</term>
	/// </item>
	/// <item>
	/// <term>CWP_SKIPINVISIBLE 0x0001</term>
	/// <term>Skips invisible child windows</term>
	/// </item>
	/// <item>
	/// <term>CWP_SKIPTRANSPARENT 0x0004</term>
	/// <term>Skips transparent child windows</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>
	/// The return value is a handle to the first child window that contains the point and meets the criteria specified by uFlags. If the
	/// point is within the parent window but not within any child window that meets the criteria, the return value is a handle to the
	/// parent window. If the point lies outside the parent window or if the function fails, the return value is <c>NULL</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The system maintains an internal list that contains the handles of the child windows associated with a parent window. The order
	/// of the handles in the list depends on the Z order of the child windows. If more than one child window contains the specified
	/// point, the system returns a handle to the first window in the list that contains the point and meets the criteria specified by uFlags.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-childwindowfrompointex HWND ChildWindowFromPointEx( HWND
	// hwnd, POINT pt, UINT flags );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "childwindowfrompointex")]
	public static extern HWND ChildWindowFromPointEx(HWND hwnd, POINT pt, ChildWindowSkipOptions flags);

	/// <summary>
	/// <para>Minimizes (but does not destroy) the specified window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to be minimized.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>To destroy a window, an application must use the DestroyWindow function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-closewindow BOOL CloseWindow( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "closewindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseWindow(HWND hWnd);

	/// <summary>
	/// <para>
	/// Creates an overlapped, pop-up, or child window. It specifies the window class, window title, window style, and (optionally) the
	/// initial position and size of the window. The function also specifies the window's parent or owner, if any, and the window's menu.
	/// </para>
	/// <para>To use extended window styles in addition to the styles supported by <c>CreateWindow</c>, use the CreateWindowEx function.</para>
	/// </summary>
	/// <param name="lpClassName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A <c>null</c>-terminated string or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom
	/// must be in the low-order word of lpClassName; the high-order word must be zero. If lpClassName is a string, it specifies the window
	/// class name. The class name can be any name registered with <c>RegisterClass</c> or <c>RegisterClassEx</c>, provided that the module
	/// that registers the class is also the module that creates the window. The class name can also be any of the predefined system class
	/// names. For a list of system class names, see the Remarks section.
	/// </para>
	/// </param>
	/// <param name="lpWindowName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title
	/// bar. When using <c>CreateWindow</c> to create controls, such as buttons, check boxes, and static controls, use lpWindowName to
	/// specify the text of the control. When creating a static control with the <c>SS_ICON</c> style, use lpWindowName to specify the icon
	/// name or identifier. To specify an identifier, use the syntax "#num".
	/// </para>
	/// </param>
	/// <param name="dwStyle">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The style of the window being created. This parameter can be a combination of the window style values, plus the control styles
	/// indicated in the Remarks section.
	/// </para>
	/// </param>
	/// <param name="x">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The initial horizontal position of the window. For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the
	/// window's upper-left corner, in screen coordinates. For a child window, x is the x-coordinate of the upper-left corner of the window
	/// relative to the upper-left corner of the parent window's client area. If this parameter is set to <c>CW_USEDEFAULT</c>, the system
	/// selects the default position for the window's upper-left corner and ignores the y parameter. <c>CW_USEDEFAULT</c> is valid only for
	/// overlapped windows; if it is specified for a pop-up or child window, the x and y parameters are set to zero.
	/// </para>
	/// </param>
	/// <param name="y">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The initial vertical position of the window. For an overlapped or pop-up window, the y parameter is the initial y-coordinate of the
	/// window's upper-left corner, in screen coordinates. For a child window, y is the initial y-coordinate of the upper-left corner of the
	/// child window relative to the upper-left corner of the parent window's client area. For a list box, y is the initial y-coordinate of
	/// the upper-left corner of the list box's client area relative to the upper-left corner of the parent window's client area.
	/// </para>
	/// <para>
	/// If an overlapped window is created with the <c>WS_VISIBLE</c> style bit set and the x parameter is set to <c>CW_USEDEFAULT</c>, then
	/// the y parameter determines how the window is shown. If the y parameter is <c>CW_USEDEFAULT</c>, then the window manager calls
	/// ShowWindow with the <c>SW_SHOW</c> flag after the window has been created. If the y parameter is some other value, then the window
	/// manager calls <c>ShowWindow</c> with that value as the nCmdShow parameter.
	/// </para>
	/// </param>
	/// <param name="nWidth">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The width, in device units, of the window. For overlapped windows, nWidth is either the window's width, in screen coordinates, or
	/// <c>CW_USEDEFAULT</c>. If nWidth is <c>CW_USEDEFAULT</c>, the system selects a default width and height for the window; the default
	/// width extends from the initial x-coordinate to the right edge of the screen, and the default height extends from the initial
	/// y-coordinate to the top of the icon area. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if <c>CW_USEDEFAULT</c> is
	/// specified for a pop-up or child window, nWidth and nHeight are set to zero.
	/// </para>
	/// </param>
	/// <param name="nHeight">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The height, in device units, of the window. For overlapped windows, nHeight is the window's height, in screen coordinates. If nWidth
	/// is set to <c>CW_USEDEFAULT</c>, the system ignores nHeight.
	/// </para>
	/// </param>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid
	/// window handle. This parameter is optional for pop-up windows.
	/// </para>
	/// <para>To create a message-only window, supply <c>HWND_MESSAGE</c> or a handle to an existing message-only window.</para>
	/// </param>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>
	/// A handle to a menu, or specifies a child-window identifier depending on the window style. For an overlapped or pop-up window, hMenu
	/// identifies the menu to be used with the window; it can be <c>NULL</c> if the class menu is to be used. For a child window, hMenu
	/// specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events. The
	/// application determines the child-window identifier; it must be unique for all child windows with the same parent window.
	/// </para>
	/// </param>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the instance of the module to be associated with the window.</para>
	/// </param>
	/// <param name="lpParam">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>
	/// A pointer to a value to be passed to the window through the CREATESTRUCT structure ( <c>lpCreateParams</c> member) pointed to by the
	/// lParam param of the WM_CREATE message. This message is sent to the created window by this function before it returns.
	/// </para>
	/// <para>
	/// If an application calls <c>CreateWindow</c> to create a MDI client window, lpParam should point to a CLIENTCREATESTRUCT structure. If
	/// an MDI client window calls <c>CreateWindow</c> to create an MDI child window, lpParam should point to a MDICREATESTRUCT structure.
	/// lpParam may be <c>NULL</c> if no additional data is needed.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>If the function succeeds, the return value is a handle to the new window.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// <para>This function typically fails for one of the following reasons:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>an invalid parameter value</term>
	/// </item>
	/// <item>
	/// <term>the system class was registered by a different module</term>
	/// </item>
	/// <item>
	/// <term>The <c>WH_CBT</c> hook is installed and returns a failure code</term>
	/// </item>
	/// <item>
	/// <term>if one of the controls in the dialog template is not registered, or its window window procedure fails WM_CREATE or WM_NCCREATE</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Before returning, <c>CreateWindow</c> sends a WM_CREATE message to the window procedure. For overlapped, pop-up, and child windows,
	/// <c>CreateWindow</c> sends <c>WM_CREATE</c>, WM_GETMINMAXINFO, and WM_NCCREATE messages to the window. The lParam parameter of the
	/// <c>WM_CREATE</c> message contains a pointer to a CREATESTRUCT structure. If the <c>WS_VISIBLE</c> style is specified,
	/// <c>CreateWindow</c> sends the window all the messages required to activate and show the window.
	/// </para>
	/// <para>
	/// If the created window is a child window, its default position is at the bottom of the Z-order. If the created window is a top-level
	/// window, its default position is at the top of the Z-order (but beneath all topmost windows unless the created window is itself topmost).
	/// </para>
	/// <para>For information on controlling whether the Taskbar displays a button for the created window, see Managing Taskbar Buttons.</para>
	/// <para>For information on removing a window, see the DestroyWindow function.</para>
	/// <para>
	/// The following predefined system classes can be specified in the lpClassName parameter. Note the corresponding control styles you can
	/// use in the dwStyle parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>System class</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BUTTON</term>
	/// <term>
	/// Designates a small rectangular child window that represents a button the user can click to turn it on or off. Button controls can be
	/// used alone or in groups, and they can either be labeled or appear without text. Button controls typically change appearance when the
	/// user clicks them. For more information, see Buttons For a table of the button styles you can specify in the dwStyle parameter, see
	/// Button Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>COMBOBOX</term>
	/// <term>
	/// Designates a control consisting of a list box and a selection field similar to an edit control. When using this style, an application
	/// should either display the list box at all times or enable a drop-down list box. If the list box is visible, typing characters into
	/// the selection field highlights the first list box entry that matches the characters typed. Conversely, selecting an item in the list
	/// box displays the selected text in the selection field. For more information, see Combo Boxes. For a table of the combo box styles you
	/// can specify in the dwStyle parameter, see Combo Box Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>EDIT</term>
	/// <term>
	/// Designates a rectangular child window into which the user can type text from the keyboard. The user selects the control and gives it
	/// the keyboard focus by clicking it or moving to it by pressing the TAB key. The user can type text when the edit control displays a
	/// flashing caret; use the mouse to move the cursor, select characters to be replaced, or position the cursor for inserting characters;
	/// or use the BACKSPACE key to delete characters. For more information, see Edit Controls. For a table of the edit control styles you
	/// can specify in the dwStyle parameter, see Edit Control Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LISTBOX</term>
	/// <term>
	/// Designates a list of character strings. Specify this control whenever an application must present a list of names, such as file
	/// names, from which the user can choose. The user can select a string by clicking it. A selected string is highlighted, and a
	/// notification message is passed to the parent window. For more information, see List Boxes. For a table of the list box styles you can
	/// specify in the dwStyle parameter, see List Box Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MDICLIENT</term>
	/// <term>
	/// Designates an MDI client window. This window receives messages that control the MDI application's child windows. The recommended
	/// style bits are WS_CLIPCHILDREN and WS_CHILD. Specify the WS_HSCROLL and WS_VSCROLL styles to create an MDI client window that allows
	/// the user to scroll MDI child windows into view. For more information, see Multiple Document Interface.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RichEdit</term>
	/// <term>
	/// Designates a Microsoft Rich Edit 1.0 control. This window lets the user view and edit text with character and paragraph formatting,
	/// and can include embedded Component Object Model (COM) objects. For more information, see Rich Edit Controls. For a table of the rich
	/// edit control styles you can specify in the dwStyle parameter, see Rich Edit Control Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RICHEDIT_CLASS</term>
	/// <term>
	/// Designates a Microsoft Rich Edit 2.0 control. This controls let the user view and edit text with character and paragraph formatting,
	/// and can include embedded COM objects. For more information, see Rich Edit Controls. For a table of the rich edit control styles you
	/// can specify in the dwStyle parameter, see Rich Edit Control Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SCROLLBAR</term>
	/// <term>
	/// Designates a rectangle that contains a scroll box and has direction arrows at both ends. The scroll bar sends a notification message
	/// to its parent window whenever the user clicks the control. The parent window is responsible for updating the position of the scroll
	/// box, if necessary. For more information, see Scroll Bars. For a table of the scroll bar control styles you can specify in the dwStyle
	/// parameter, see Scroll Bar Control Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATIC</term>
	/// <term>
	/// Designates a simple text field, box, or rectangle used to label, box, or separate other controls. Static controls take no input and
	/// provide no output. For more information, see Static Controls. For a table of the static control styles you can specify in the dwStyle
	/// parameter, see Static Control Styles.
	/// </term>
	/// </item>
	/// </list>
	/// <para><c>CreateWindow</c> is implemented as a call to the CreateWindowEx function, as shown below.</para>
	/// <para>
	/// <code>#define CreateWindowA(lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam)\ CreateWindowExA(0L, lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam) #define CreateWindowW(lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam)\ CreateWindowExW(0L, lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam) #ifdef UNICODE #define CreateWindow CreateWindowW #else #define CreateWindow CreateWindowA #endif</code>
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Using Window Classes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createwindowa
	// void CreateWindowA( lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.CreateWindowA")]
	public static SafeHWND CreateWindow(string lpClassName, [Optional] string? lpWindowName, [Optional] WindowStyles dwStyle,
		[Optional] int x, [Optional] int y, [Optional] int nWidth, [Optional] int nHeight, [Optional] HWND hWndParent, [Optional] HMENU hMenu,
		[Optional] HINSTANCE hInstance, [Optional] IntPtr lpParam)
		=> CreateWindowEx(0, lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam);

	/// <summary>
	/// <para>
	/// Creates an overlapped, pop-up, or child window with an extended window style; otherwise, this function is identical to the
	/// CreateWindow function. For more information about creating a window and for full descriptions of the other parameters of
	/// <c>CreateWindowEx</c>, see <c>CreateWindow</c>.
	/// </para>
	/// </summary>
	/// <param name="dwExStyle">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The extended window style of the window being created. For a list of possible values,see Extended Window Styles.</para>
	/// </param>
	/// <param name="lpClassName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A <c>null</c>-terminated string or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The
	/// atom must be in the low-order word of lpClassName; the high-order word must be zero. If lpClassName is a string, it specifies the
	/// window class name. The class name can be any name registered with <c>RegisterClass</c> or <c>RegisterClassEx</c>, provided that
	/// the module that registers the class is also the module that creates the window. The class name can also be any of the predefined
	/// system class names.
	/// </para>
	/// </param>
	/// <param name="lpWindowName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title
	/// bar. When using CreateWindow to create controls, such as buttons, check boxes, and static controls, use lpWindowName to specify
	/// the text of the control. When creating a static control with the <c>SS_ICON</c> style, use lpWindowName to specify the icon name
	/// or identifier. To specify an identifier, use the syntax "#num".
	/// </para>
	/// </param>
	/// <param name="dwStyle">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The style of the window being created. This parameter can be a combination of the window style values, plus the control styles
	/// indicated in the Remarks section.
	/// </para>
	/// </param>
	/// <param name="X">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The initial horizontal position of the window. For an overlapped or pop-up window, the x parameter is the initial x-coordinate of
	/// the window's upper-left corner, in screen coordinates. For a child window, x is the x-coordinate of the upper-left corner of the
	/// window relative to the upper-left corner of the parent window's client area. If x is set to <c>CW_USEDEFAULT</c>, the system
	/// selects the default position for the window's upper-left corner and ignores the y parameter. <c>CW_USEDEFAULT</c> is valid only
	/// for overlapped windows; if it is specified for a pop-up or child window, the x and y parameters are set to zero.
	/// </para>
	/// </param>
	/// <param name="Y">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The initial vertical position of the window. For an overlapped or pop-up window, the y parameter is the initial y-coordinate of
	/// the window's upper-left corner, in screen coordinates. For a child window, y is the initial y-coordinate of the upper-left corner
	/// of the child window relative to the upper-left corner of the parent window's client area. For a list box y is the initial
	/// y-coordinate of the upper-left corner of the list box's client area relative to the upper-left corner of the parent window's
	/// client area.
	/// </para>
	/// <para>
	/// If an overlapped window is created with the <c>WS_VISIBLE</c> style bit set and the x parameter is set to <c>CW_USEDEFAULT</c>,
	/// then the y parameter determines how the window is shown. If the y parameter is <c>CW_USEDEFAULT</c>, then the window manager
	/// calls ShowWindow with the <c>SW_SHOW</c> flag after the window has been created. If the y parameter is some other value, then the
	/// window manager calls <c>ShowWindow</c> with that value as the nCmdShow parameter.
	/// </para>
	/// </param>
	/// <param name="nWidth">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The width, in device units, of the window. For overlapped windows, nWidth is the window's width, in screen coordinates, or
	/// <c>CW_USEDEFAULT</c>. If nWidth is <c>CW_USEDEFAULT</c>, the system selects a default width and height for the window; the
	/// default width extends from the initial x-coordinates to the right edge of the screen; the default height extends from the initial
	/// y-coordinate to the top of the icon area. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if <c>CW_USEDEFAULT</c> is
	/// specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero.
	/// </para>
	/// </param>
	/// <param name="nHeight">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The height, in device units, of the window. For overlapped windows, nHeight is the window's height, in screen coordinates. If the
	/// nWidth parameter is set to <c>CW_USEDEFAULT</c>, the system ignores nHeight.
	/// </para>
	/// </param>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid
	/// window handle. This parameter is optional for pop-up windows.
	/// </para>
	/// <para>To create a message-only window, supply <c>HWND_MESSAGE</c> or a handle to an existing message-only window.</para>
	/// </param>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>
	/// A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window,
	/// hMenu identifies the menu to be used with the window; it can be <c>NULL</c> if the class menu is to be used. For a child window,
	/// hMenu specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events. The
	/// application determines the child-window identifier; it must be unique for all child windows with the same parent window.
	/// </para>
	/// </param>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the instance of the module to be associated with the window.</para>
	/// </param>
	/// <param name="lpParam">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>
	/// Pointer to a value to be passed to the window through the CREATESTRUCT structure ( <c>lpCreateParams</c> member) pointed to by
	/// the lParam param of the <c>WM_CREATE</c> message. This message is sent to the created window by this function before it returns.
	/// </para>
	/// <para>
	/// If an application calls CreateWindow to create a MDI client window, lpParam should point to a CLIENTCREATESTRUCT structure. If an
	/// MDI client window calls <c>CreateWindow</c> to create an MDI child window, lpParam should point to a MDICREATESTRUCT structure.
	/// lpParam may be <c>NULL</c> if no additional data is needed.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>If the function succeeds, the return value is a handle to the new window.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// <para>This function typically fails for one of the following reasons:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>an invalid parameter value</term>
	/// </item>
	/// <item>
	/// <term>the system class was registered by a different module</term>
	/// </item>
	/// <item>
	/// <term>The <c>WH_CBT</c> hook is installed and returns a failure code</term>
	/// </item>
	/// <item>
	/// <term>if one of the controls in the dialog template is not registered, or its window window procedure fails WM_CREATE or WM_NCCREATE</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>CreateWindowEx</c> function sends WM_NCCREATE, WM_NCCALCSIZE, and WM_CREATE messages to the window being created.</para>
	/// <para>
	/// If the created window is a child window, its default position is at the bottom of the Z-order. If the created window is a
	/// top-level window, its default position is at the top of the Z-order (but beneath all topmost windows unless the created window is
	/// itself topmost).
	/// </para>
	/// <para>For information on controlling whether the Taskbar displays a button for the created window, see Managing Taskbar Buttons.</para>
	/// <para>For information on removing a window, see the DestroyWindow function.</para>
	/// <para>
	/// The following predefined control classes can be specified in the lpClassName parameter. Note the corresponding control styles you
	/// can use in the dwStyle parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Class</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BUTTON</term>
	/// <term>
	/// Designates a small rectangular child window that represents a button the user can click to turn it on or off. Button controls can
	/// be used alone or in groups, and they can either be labeled or appear without text. Button controls typically change appearance
	/// when the user clicks them. For more information, see Buttons. For a table of the button styles you can specify in the dwStyle
	/// parameter, see Button Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>COMBOBOX</term>
	/// <term>
	/// Designates a control consisting of a list box and a selection field similar to an edit control. When using this style, an
	/// application should either display the list box at all times or enable a drop-down list box. If the list box is visible, typing
	/// characters into the selection field highlights the first list box entry that matches the characters typed. Conversely, selecting
	/// an item in the list box displays the selected text in the selection field. For more information, see Combo Boxes. For a table of
	/// the combo box styles you can specify in the dwStyle parameter, see Combo Box Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>EDIT</term>
	/// <term>
	/// Designates a rectangular child window into which the user can type text from the keyboard. The user selects the control and gives
	/// it the keyboard focus by clicking it or moving to it by pressing the TAB key. The user can type text when the edit control
	/// displays a flashing caret; use the mouse to move the cursor, select characters to be replaced, or position the cursor for
	/// inserting characters; or use the key to delete characters. For more information, see Edit Controls. For a table of the edit
	/// control styles you can specify in the dwStyle parameter, see Edit Control Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LISTBOX</term>
	/// <term>
	/// Designates a list of character strings. Specify this control whenever an application must present a list of names, such as
	/// filenames, from which the user can choose. The user can select a string by clicking it. A selected string is highlighted, and a
	/// notification message is passed to the parent window. For more information, see List Boxes. For a table of the list box styles you
	/// can specify in the dwStyle parameter, see List Box Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MDICLIENT</term>
	/// <term>
	/// Designates an MDI client window. This window receives messages that control the MDI application's child windows. The recommended
	/// style bits are WS_CLIPCHILDREN and WS_CHILD. Specify the WS_HSCROLL and WS_VSCROLL styles to create an MDI client window that
	/// allows the user to scroll MDI child windows into view. For more information, see Multiple Document Interface.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RichEdit</term>
	/// <term>
	/// Designates a Microsoft Rich Edit 1.0 control. This window lets the user view and edit text with character and paragraph
	/// formatting, and can include embedded Component Object Model (COM) objects. For more information, see Rich Edit Controls. For a
	/// table of the rich edit control styles you can specify in the dwStyle parameter, see Rich Edit Control Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RICHEDIT_CLASS</term>
	/// <term>
	/// Designates a Microsoft Rich Edit 2.0 control. This controls let the user view and edit text with character and paragraph
	/// formatting, and can include embedded COM objects. For more information, see Rich Edit Controls. For a table of the rich edit
	/// control styles you can specify in the dwStyle parameter, see Rich Edit Control Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SCROLLBAR</term>
	/// <term>
	/// Designates a rectangle that contains a scroll box and has direction arrows at both ends. The scroll bar sends a notification
	/// message to its parent window whenever the user clicks the control. The parent window is responsible for updating the position of
	/// the scroll box, if necessary. For more information, see Scroll Bars. For a table of the scroll bar control styles you can specify
	/// in the dwStyle parameter, see Scroll Bar Control Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATIC</term>
	/// <term>
	/// Designates a simple text field, box, or rectangle used to label, box, or separate other controls. Static controls take no input
	/// and provide no output. For more information, see Static Controls. For a table of the static control styles you can specify in the
	/// dwStyle parameter, see Static Control Styles.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>WS_EX_NOACTIVATE</c> value for dwExStyle prevents foreground activation by the system. To prevent queue activation when
	/// the user clicks on the window, you must process the WM_MOUSEACTIVATE message appropriately. To bring the window to the foreground
	/// or to activate it programmatically, use SetForegroundWindow or SetActiveWindow. Returning <c>FALSE</c> to WM_NCACTIVATE prevents
	/// the window from losing queue activation. However, the return value is ignored at activation time.
	/// </para>
	/// <para>
	/// With <c>WS_EX_COMPOSITED</c> set, all descendants of a window get bottom-to-top painting order using double-buffering.
	/// Bottom-to-top painting order allows a descendent window to have translucency (alpha) and transparency (color-key) effects, but
	/// only if the descendent window also has the <c>WS_EX_TRANSPARENT</c> bit set. Double-buffering allows the window and its
	/// descendents to be painted without flicker.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createwindowexa HWND CreateWindowExA( DWORD dwExStyle,
	// LPCSTR lpClassName, LPCSTR lpWindowName, DWORD dwStyle, int X, int Y, int nWidth, int nHeight, HWND hWndParent, HMENU hMenu,
	// HINSTANCE hInstance, LPVOID lpParam );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "createwindowex")]
	public static extern SafeHWND CreateWindowEx([Optional] WindowStylesEx dwExStyle, [MarshalAs(UnmanagedType.LPTStr)] string lpClassName,
		[MarshalAs(UnmanagedType.LPTStr), Optional] string? lpWindowName, [Optional] WindowStyles dwStyle, [Optional] int X,
		[Optional] int Y, [Optional] int nWidth, [Optional] int nHeight, [Optional] HWND hWndParent, [Optional] HMENU hMenu,
		[Optional] HINSTANCE hInstance, [Optional] IntPtr lpParam);

	/// <summary>
	/// <para>
	/// Creates an overlapped, pop-up, or child window with an extended window style; otherwise, this function is identical to the
	/// CreateWindow function. For more information about creating a window and for full descriptions of the other parameters of
	/// <c>CreateWindowEx</c>, see <c>CreateWindow</c>.
	/// </para>
	/// </summary>
	/// <param name="dwExStyle">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The extended window style of the window being created. For a list of possible values,see Extended Window Styles.</para>
	/// </param>
	/// <param name="lpClassName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A <c>null</c>-terminated string or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The
	/// atom must be in the low-order word of lpClassName; the high-order word must be zero. If lpClassName is a string, it specifies the
	/// window class name. The class name can be any name registered with <c>RegisterClass</c> or <c>RegisterClassEx</c>, provided that
	/// the module that registers the class is also the module that creates the window. The class name can also be any of the predefined
	/// system class names.
	/// </para>
	/// </param>
	/// <param name="lpWindowName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title
	/// bar. When using CreateWindow to create controls, such as buttons, check boxes, and static controls, use lpWindowName to specify
	/// the text of the control. When creating a static control with the <c>SS_ICON</c> style, use lpWindowName to specify the icon name
	/// or identifier. To specify an identifier, use the syntax "#num".
	/// </para>
	/// </param>
	/// <param name="dwStyle">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The style of the window being created. This parameter can be a combination of the window style values, plus the control styles
	/// indicated in the Remarks section.
	/// </para>
	/// </param>
	/// <param name="X">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The initial horizontal position of the window. For an overlapped or pop-up window, the x parameter is the initial x-coordinate of
	/// the window's upper-left corner, in screen coordinates. For a child window, x is the x-coordinate of the upper-left corner of the
	/// window relative to the upper-left corner of the parent window's client area. If x is set to <c>CW_USEDEFAULT</c>, the system
	/// selects the default position for the window's upper-left corner and ignores the y parameter. <c>CW_USEDEFAULT</c> is valid only
	/// for overlapped windows; if it is specified for a pop-up or child window, the x and y parameters are set to zero.
	/// </para>
	/// </param>
	/// <param name="Y">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The initial vertical position of the window. For an overlapped or pop-up window, the y parameter is the initial y-coordinate of
	/// the window's upper-left corner, in screen coordinates. For a child window, y is the initial y-coordinate of the upper-left corner
	/// of the child window relative to the upper-left corner of the parent window's client area. For a list box y is the initial
	/// y-coordinate of the upper-left corner of the list box's client area relative to the upper-left corner of the parent window's
	/// client area.
	/// </para>
	/// <para>
	/// If an overlapped window is created with the <c>WS_VISIBLE</c> style bit set and the x parameter is set to <c>CW_USEDEFAULT</c>,
	/// then the y parameter determines how the window is shown. If the y parameter is <c>CW_USEDEFAULT</c>, then the window manager
	/// calls ShowWindow with the <c>SW_SHOW</c> flag after the window has been created. If the y parameter is some other value, then the
	/// window manager calls <c>ShowWindow</c> with that value as the nCmdShow parameter.
	/// </para>
	/// </param>
	/// <param name="nWidth">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The width, in device units, of the window. For overlapped windows, nWidth is the window's width, in screen coordinates, or
	/// <c>CW_USEDEFAULT</c>. If nWidth is <c>CW_USEDEFAULT</c>, the system selects a default width and height for the window; the
	/// default width extends from the initial x-coordinates to the right edge of the screen; the default height extends from the initial
	/// y-coordinate to the top of the icon area. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if <c>CW_USEDEFAULT</c> is
	/// specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero.
	/// </para>
	/// </param>
	/// <param name="nHeight">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The height, in device units, of the window. For overlapped windows, nHeight is the window's height, in screen coordinates. If the
	/// nWidth parameter is set to <c>CW_USEDEFAULT</c>, the system ignores nHeight.
	/// </para>
	/// </param>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid
	/// window handle. This parameter is optional for pop-up windows.
	/// </para>
	/// <para>To create a message-only window, supply <c>HWND_MESSAGE</c> or a handle to an existing message-only window.</para>
	/// </param>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>
	/// A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window,
	/// hMenu identifies the menu to be used with the window; it can be <c>NULL</c> if the class menu is to be used. For a child window,
	/// hMenu specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events. The
	/// application determines the child-window identifier; it must be unique for all child windows with the same parent window.
	/// </para>
	/// </param>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the instance of the module to be associated with the window.</para>
	/// </param>
	/// <param name="lpParam">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>
	/// Pointer to a value to be passed to the window through the CREATESTRUCT structure ( <c>lpCreateParams</c> member) pointed to by
	/// the lParam param of the <c>WM_CREATE</c> message. This message is sent to the created window by this function before it returns.
	/// </para>
	/// <para>
	/// If an application calls CreateWindow to create a MDI client window, lpParam should point to a CLIENTCREATESTRUCT structure. If an
	/// MDI client window calls <c>CreateWindow</c> to create an MDI child window, lpParam should point to a MDICREATESTRUCT structure.
	/// lpParam may be <c>NULL</c> if no additional data is needed.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>If the function succeeds, the return value is a handle to the new window.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// <para>This function typically fails for one of the following reasons:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>an invalid parameter value</term>
	/// </item>
	/// <item>
	/// <term>the system class was registered by a different module</term>
	/// </item>
	/// <item>
	/// <term>The <c>WH_CBT</c> hook is installed and returns a failure code</term>
	/// </item>
	/// <item>
	/// <term>if one of the controls in the dialog template is not registered, or its window window procedure fails WM_CREATE or WM_NCCREATE</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>CreateWindowEx</c> function sends WM_NCCREATE, WM_NCCALCSIZE, and WM_CREATE messages to the window being created.</para>
	/// <para>
	/// If the created window is a child window, its default position is at the bottom of the Z-order. If the created window is a
	/// top-level window, its default position is at the top of the Z-order (but beneath all topmost windows unless the created window is
	/// itself topmost).
	/// </para>
	/// <para>For information on controlling whether the Taskbar displays a button for the created window, see Managing Taskbar Buttons.</para>
	/// <para>For information on removing a window, see the DestroyWindow function.</para>
	/// <para>
	/// The following predefined control classes can be specified in the lpClassName parameter. Note the corresponding control styles you
	/// can use in the dwStyle parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Class</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BUTTON</term>
	/// <term>
	/// Designates a small rectangular child window that represents a button the user can click to turn it on or off. Button controls can
	/// be used alone or in groups, and they can either be labeled or appear without text. Button controls typically change appearance
	/// when the user clicks them. For more information, see Buttons. For a table of the button styles you can specify in the dwStyle
	/// parameter, see Button Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>COMBOBOX</term>
	/// <term>
	/// Designates a control consisting of a list box and a selection field similar to an edit control. When using this style, an
	/// application should either display the list box at all times or enable a drop-down list box. If the list box is visible, typing
	/// characters into the selection field highlights the first list box entry that matches the characters typed. Conversely, selecting
	/// an item in the list box displays the selected text in the selection field. For more information, see Combo Boxes. For a table of
	/// the combo box styles you can specify in the dwStyle parameter, see Combo Box Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>EDIT</term>
	/// <term>
	/// Designates a rectangular child window into which the user can type text from the keyboard. The user selects the control and gives
	/// it the keyboard focus by clicking it or moving to it by pressing the TAB key. The user can type text when the edit control
	/// displays a flashing caret; use the mouse to move the cursor, select characters to be replaced, or position the cursor for
	/// inserting characters; or use the key to delete characters. For more information, see Edit Controls. For a table of the edit
	/// control styles you can specify in the dwStyle parameter, see Edit Control Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LISTBOX</term>
	/// <term>
	/// Designates a list of character strings. Specify this control whenever an application must present a list of names, such as
	/// filenames, from which the user can choose. The user can select a string by clicking it. A selected string is highlighted, and a
	/// notification message is passed to the parent window. For more information, see List Boxes. For a table of the list box styles you
	/// can specify in the dwStyle parameter, see List Box Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MDICLIENT</term>
	/// <term>
	/// Designates an MDI client window. This window receives messages that control the MDI application's child windows. The recommended
	/// style bits are WS_CLIPCHILDREN and WS_CHILD. Specify the WS_HSCROLL and WS_VSCROLL styles to create an MDI client window that
	/// allows the user to scroll MDI child windows into view. For more information, see Multiple Document Interface.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RichEdit</term>
	/// <term>
	/// Designates a Microsoft Rich Edit 1.0 control. This window lets the user view and edit text with character and paragraph
	/// formatting, and can include embedded Component Object Model (COM) objects. For more information, see Rich Edit Controls. For a
	/// table of the rich edit control styles you can specify in the dwStyle parameter, see Rich Edit Control Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RICHEDIT_CLASS</term>
	/// <term>
	/// Designates a Microsoft Rich Edit 2.0 control. This controls let the user view and edit text with character and paragraph
	/// formatting, and can include embedded COM objects. For more information, see Rich Edit Controls. For a table of the rich edit
	/// control styles you can specify in the dwStyle parameter, see Rich Edit Control Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SCROLLBAR</term>
	/// <term>
	/// Designates a rectangle that contains a scroll box and has direction arrows at both ends. The scroll bar sends a notification
	/// message to its parent window whenever the user clicks the control. The parent window is responsible for updating the position of
	/// the scroll box, if necessary. For more information, see Scroll Bars. For a table of the scroll bar control styles you can specify
	/// in the dwStyle parameter, see Scroll Bar Control Styles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATIC</term>
	/// <term>
	/// Designates a simple text field, box, or rectangle used to label, box, or separate other controls. Static controls take no input
	/// and provide no output. For more information, see Static Controls. For a table of the static control styles you can specify in the
	/// dwStyle parameter, see Static Control Styles.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>WS_EX_NOACTIVATE</c> value for dwExStyle prevents foreground activation by the system. To prevent queue activation when
	/// the user clicks on the window, you must process the WM_MOUSEACTIVATE message appropriately. To bring the window to the foreground
	/// or to activate it programmatically, use SetForegroundWindow or SetActiveWindow. Returning <c>FALSE</c> to WM_NCACTIVATE prevents
	/// the window from losing queue activation. However, the return value is ignored at activation time.
	/// </para>
	/// <para>
	/// With <c>WS_EX_COMPOSITED</c> set, all descendants of a window get bottom-to-top painting order using double-buffering.
	/// Bottom-to-top painting order allows a descendent window to have translucency (alpha) and transparency (color-key) effects, but
	/// only if the descendent window also has the <c>WS_EX_TRANSPARENT</c> bit set. Double-buffering allows the window and its
	/// descendents to be painted without flicker.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createwindowexa HWND CreateWindowExA( DWORD dwExStyle,
	// LPCSTR lpClassName, LPCSTR lpWindowName, DWORD dwStyle, int X, int Y, int nWidth, int nHeight, HWND hWndParent, HMENU hMenu,
	// HINSTANCE hInstance, LPVOID lpParam );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "createwindowex")]
	public static extern SafeHWND CreateWindowEx([Optional] WindowStylesEx dwExStyle, IntPtr lpClassName,
		[MarshalAs(UnmanagedType.LPTStr), Optional] string? lpWindowName, [Optional] WindowStyles dwStyle, [Optional] int X,
		[Optional] int Y, [Optional] int nWidth, [Optional] int nHeight, [Optional] HWND hWndParent, [Optional] HMENU hMenu,
		[Optional] HINSTANCE hInstance, [Optional] IntPtr lpParam);

	/// <summary>
	/// <para>
	/// Updates the specified multiple-window – position structure for the specified window. The function then returns a handle to the
	/// updated structure. The EndDeferWindowPos function uses the information in this structure to change the position and size of a
	/// number of windows simultaneously. The BeginDeferWindowPos function creates the structure.
	/// </para>
	/// </summary>
	/// <param name="hWinPosInfo">
	/// <para>Type: <c>HDWP</c></para>
	/// <para>
	/// A handle to a multiple-window – position structure that contains size and position information for one or more windows. This
	/// structure is returned by BeginDeferWindowPos or by the most recent call to <c>DeferWindowPos</c>.
	/// </para>
	/// </param>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the window for which update information is stored in the structure. All windows in a multiple-window – position
	/// structure must have the same parent.
	/// </para>
	/// </param>
	/// <param name="hWndInsertAfter">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the window that precedes the positioned window in the Z order. This parameter must be a window handle or one of the
	/// following values. This parameter is ignored if the <c>SWP_NOZORDER</c> flag is set in the uFlags parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HWND_BOTTOM ((HWND)1)</term>
	/// <term>
	/// Places the window at the bottom of the Z order. If the hWnd parameter identifies a topmost window, the window loses its topmost
	/// status and is placed at the bottom of all other windows.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HWND_NOTOPMOST ((HWND)-2)</term>
	/// <term>
	/// Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window is
	/// already a non-topmost window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HWND_TOP ((HWND)0)</term>
	/// <term>Places the window at the top of the Z order.</term>
	/// </item>
	/// <item>
	/// <term>HWND_TOPMOST ((HWND)-1)</term>
	/// <term>Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="x">
	/// <para>Type: <c>int</c></para>
	/// <para>The x-coordinate of the window's upper-left corner.</para>
	/// </param>
	/// <param name="y">
	/// <para>Type: <c>int</c></para>
	/// <para>The y-coordinate of the window's upper-left corner.</para>
	/// </param>
	/// <param name="cx">
	/// <para>Type: <c>int</c></para>
	/// <para>The window's new width, in pixels.</para>
	/// </param>
	/// <param name="cy">
	/// <para>Type: <c>int</c></para>
	/// <para>The window's new height, in pixels.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>A combination of the following values that affect the size and position of the window.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SWP_DRAWFRAME 0x0020</term>
	/// <term>Draws a frame (defined in the window's class description) around the window.</term>
	/// </item>
	/// <item>
	/// <term>SWP_FRAMECHANGED 0x0020</term>
	/// <term>
	/// Sends a WM_NCCALCSIZE message to the window, even if the window's size is not being changed. If this flag is not specified,
	/// WM_NCCALCSIZE is sent only when the window's size is being changed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SWP_HIDEWINDOW 0x0080</term>
	/// <term>Hides the window.</term>
	/// </item>
	/// <item>
	/// <term>SWP_NOACTIVATE 0x0010</term>
	/// <term>
	/// Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the topmost or
	/// non-topmost group (depending on the setting of the hWndInsertAfter parameter).
	/// </term>
	/// </item>
	/// <item>
	/// <term>SWP_NOCOPYBITS 0x0100</term>
	/// <term>
	/// Discards the entire contents of the client area. If this flag is not specified, the valid contents of the client area are saved
	/// and copied back into the client area after the window is sized or repositioned.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SWP_NOMOVE 0x0002</term>
	/// <term>Retains the current position (ignores the x and y parameters).</term>
	/// </item>
	/// <item>
	/// <term>SWP_NOOWNERZORDER 0x0200</term>
	/// <term>Does not change the owner window's position in the Z order.</term>
	/// </item>
	/// <item>
	/// <term>SWP_NOREDRAW 0x0008</term>
	/// <term>
	/// Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to the client area, the nonclient
	/// area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of the window being
	/// moved. When this flag is set, the application must explicitly invalidate or redraw any parts of the window and parent window that
	/// need redrawing.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SWP_NOREPOSITION 0x0200</term>
	/// <term>Same as the SWP_NOOWNERZORDER flag.</term>
	/// </item>
	/// <item>
	/// <term>SWP_NOSENDCHANGING 0x0400</term>
	/// <term>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</term>
	/// </item>
	/// <item>
	/// <term>SWP_NOSIZE 0x0001</term>
	/// <term>Retains the current size (ignores the cx and cy parameters).</term>
	/// </item>
	/// <item>
	/// <term>SWP_NOZORDER 0x0004</term>
	/// <term>Retains the current Z order (ignores the hWndInsertAfter parameter).</term>
	/// </item>
	/// <item>
	/// <term>SWP_SHOWWINDOW 0x0040</term>
	/// <term>Displays the window.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HDWP</c></c></para>
	/// <para>
	/// The return value identifies the updated multiple-window – position structure. The handle returned by this function may differ
	/// from the handle passed to the function. The new handle that this function returns should be passed during the next call to the
	/// <c>DeferWindowPos</c> or EndDeferWindowPos function.
	/// </para>
	/// <para>
	/// If insufficient system resources are available for the function to succeed, the return value is <c>NULL</c>. To get extended
	/// error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a call to <c>DeferWindowPos</c> fails, the application should abandon the window-positioning operation and not call EndDeferWindowPos.
	/// </para>
	/// <para>
	/// If <c>SWP_NOZORDER</c> is not specified, the system places the window identified by the hWnd parameter in the position following
	/// the window identified by the hWndInsertAfter parameter. If hWndInsertAfter is <c>NULL</c> or <c>HWND_TOP</c>, the system places
	/// the hWnd window at the top of the Z order. If hWndInsertAfter is set to <c>HWND_BOTTOM</c>, the system places the hWnd window at
	/// the bottom of the Z order.
	/// </para>
	/// <para>All coordinates for child windows are relative to the upper-left corner of the parent window's client area.</para>
	/// <para>
	/// A window can be made a topmost window either by setting hWndInsertAfter to the <c>HWND_TOPMOST</c> flag and ensuring that the
	/// <c>SWP_NOZORDER</c> flag is not set, or by setting the window's position in the Z order so that it is above any existing topmost
	/// windows. When a non-topmost window is made topmost, its owned windows are also made topmost. Its owners, however, are not changed.
	/// </para>
	/// <para>
	/// If neither the <c>SWP_NOACTIVATE</c> nor <c>SWP_NOZORDER</c> flag is specified (that is, when the application requests that a
	/// window be simultaneously activated and its position in the Z order changed), the value specified in hWndInsertAfter is used only
	/// in the following circumstances:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Neither the <c>HWND_TOPMOST</c> nor <c>HWND_NOTOPMOST</c> flag is specified in hWndInsertAfter.</term>
	/// </item>
	/// <item>
	/// <term>The window identified by hWnd is not the active window.</term>
	/// </item>
	/// </list>
	/// <para>
	/// An application cannot activate an inactive window without also bringing it to the top of the Z order. An application can change
	/// an activated window's position in the Z order without restrictions, or it can activate a window and then move it to the top of
	/// the topmost or non-topmost windows.
	/// </para>
	/// <para>
	/// A topmost window is no longer topmost if it is repositioned to the bottom ( <c>HWND_BOTTOM</c>) of the Z order or after any
	/// non-topmost window. When a topmost window is made non-topmost, its owners and its owned windows are also made non-topmost windows.
	/// </para>
	/// <para>
	/// A non-topmost window may own a topmost window, but not vice versa. Any window (for example, a dialog box) owned by a topmost
	/// window is itself made a topmost window to ensure that all owned windows stay above their owner.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-deferwindowpos HDWP DeferWindowPos( HDWP hWinPosInfo, HWND
	// hWnd, HWND hWndInsertAfter, int x, int y, int cx, int cy, UINT uFlags );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "deferwindowpos")]
	public static extern HDWP DeferWindowPos(HDWP hWinPosInfo, HWND hWnd, [Optional] HWND hWndInsertAfter, int x, int y, int cx, int cy, SetWindowPosFlags uFlags);

	/// <summary>
	/// Provides default processing for any window messages that the window procedure of a multiple-document interface (MDI) frame window
	/// does not process. All window messages that are not explicitly processed by the window procedure must be passed to the
	/// <c>DefFrameProc</c> function, not the DefWindowProc function.
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the MDI frame window.</para>
	/// </param>
	/// <param name="hWndMDIClient">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the MDI client window.</para>
	/// </param>
	/// <param name="uMsg">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The message to be processed.</para>
	/// </param>
	/// <param name="wParam">
	/// <para>Type: <c>WPARAM</c></para>
	/// <para>Additional message-specific information.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>Additional message-specific information.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>LRESULT</c></c></para>
	/// <para>
	/// The return value specifies the result of the message processing and depends on the message. If the hWndMDIClient parameter is
	/// <c>NULL</c>, the return value is the same as for the DefWindowProc function.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When an application's window procedure does not handle a message, it typically passes the message to the DefWindowProc function
	/// to process the message. MDI applications use the <c>DefFrameProc</c> and DefMDIChildProc functions instead of
	/// <c>DefWindowProc</c> to provide default message processing. All messages that an application would usually pass to
	/// <c>DefWindowProc</c> (such as nonclient messages and the WM_SETTEXT message) should be passed to <c>DefFrameProc</c> instead. The
	/// <c>DefFrameProc</c> function also handles the following messages.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Message</term>
	/// <term>Response</term>
	/// </listheader>
	/// <item>
	/// <term>WM_COMMAND</term>
	/// <term>
	/// Activates the MDI child window that the user chooses. This message is sent when the user chooses an MDI child window from the
	/// window menu of the MDI frame window. The window identifier accompanying this message identifies the MDI child window to be activated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WM_MENUCHAR</term>
	/// <term>Opens the window menu of the active MDI child window when the user presses the ALT+ – (minus) key combination.</term>
	/// </item>
	/// <item>
	/// <term>WM_SETFOCUS</term>
	/// <term>Passes the keyboard focus to the MDI client window, which in turn passes it to the active MDI child window.</term>
	/// </item>
	/// <item>
	/// <term>WM_SIZE</term>
	/// <term>
	/// Resizes the MDI client window to fit in the new frame window's client area. If the frame window procedure sizes the MDI client
	/// window to a different size, it should not pass the message to the DefWindowProc function.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-defframeproca LRESULT DefFrameProcA( HWND hWnd, HWND
	// hWndMDIClient, UINT uMsg, WPARAM wParam, LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h")]
	public static extern IntPtr DefFrameProc(HWND hWnd, [Optional] HWND hWndMDIClient, uint uMsg, IntPtr wParam, IntPtr lParam);

	/// <summary>
	/// Provides default processing for any window message that the window procedure of a multiple-document interface (MDI) child window
	/// does not process. A window message not processed by the window procedure must be passed to the <c>DefMDIChildProc</c> function,
	/// not to the DefWindowProc function.
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the MDI child window.</para>
	/// </param>
	/// <param name="uMsg">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The message to be processed.</para>
	/// </param>
	/// <param name="wParam">
	/// <para>Type: <c>WPARAM</c></para>
	/// <para>Additional message-specific information.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>Additional message-specific information.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>LRESULT</c></c></para>
	/// <para>The return value specifies the result of the message processing and depends on the message.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DefMDIChildProc</c> function assumes that the parent window of the MDI child window identified by the hWnd parameter was
	/// created with the <c>MDICLIENT</c> class.
	/// </para>
	/// <para>
	/// When an application's window procedure does not handle a message, it typically passes the message to the DefWindowProc function
	/// to process the message. MDI applications use the DefFrameProc and <c>DefMDIChildProc</c> functions instead of
	/// <c>DefWindowProc</c> to provide default message processing. All messages that an application would usually pass to
	/// <c>DefWindowProc</c> (such as nonclient messages and the WM_SETTEXT message) should be passed to <c>DefMDIChildProc</c> instead.
	/// In addition, <c>DefMDIChildProc</c> also handles the following messages.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Message</term>
	/// <term>Response</term>
	/// </listheader>
	/// <item>
	/// <term>WM_CHILDACTIVATE</term>
	/// <term>Performs activation processing when MDI child windows are sized, moved, or displayed. This message must be passed.</term>
	/// </item>
	/// <item>
	/// <term>WM_GETMINMAXINFO</term>
	/// <term>Calculates the size of a maximized MDI child window, based on the current size of the MDI client window.</term>
	/// </item>
	/// <item>
	/// <term>WM_MENUCHAR</term>
	/// <term>Passes the message to the MDI frame window.</term>
	/// </item>
	/// <item>
	/// <term>WM_MOVE</term>
	/// <term>Recalculates MDI client scroll bars if they are present.</term>
	/// </item>
	/// <item>
	/// <term>WM_SETFOCUS</term>
	/// <term>Activates the child window if it is not the active MDI child window.</term>
	/// </item>
	/// <item>
	/// <term>WM_SIZE</term>
	/// <term>
	/// Performs operations necessary for changing the size of a window, especially for maximizing or restoring an MDI child window.
	/// Failing to pass this message to the DefMDIChildProc function produces highly undesirable results.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WM_SYSCOMMAND</term>
	/// <term>Handles window menu commands: SC_NEXTWINDOW, SC_PREVWINDOW, SC_MOVE, SC_SIZE, and SC_MAXIMIZE.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-defmdichildproca LRESULT LRESULT DefMDIChildProcA( HWND
	// hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h")]
	public static extern IntPtr DefMDIChildProc(HWND hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

	/// <summary>
	/// Calls the default window procedure to provide default processing for any window messages that an application does not process.
	/// This function ensures that every message is processed. <c>DefWindowProc</c> is called with the same parameters received by the
	/// window procedure.
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window procedure that received the message.</para>
	/// </param>
	/// <param name="Msg">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The message.</para>
	/// </param>
	/// <param name="wParam">
	/// <para>Type: <c>WPARAM</c></para>
	/// <para>Additional message information. The content of this parameter depends on the value of the Msg parameter.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>Additional message information. The content of this parameter depends on the value of the Msg parameter.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>LRESULT</c></c></para>
	/// <para>The return value is the result of the message processing and depends on the message.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-defwindowproca LRESULT LRESULT DefWindowProcA( HWND hWnd,
	// UINT Msg, WPARAM wParam, LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h")]
	public static extern IntPtr DefWindowProc(HWND hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

	/// <summary>
	/// <para>[This function is not intended for general use. It may be altered or unavailable in subsequent versions of Windows.]</para>
	/// <para>Unregisters a specified Shell window that is registered to receive Shell hook messages.</para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to be unregistered. The window was registered with a call to the RegisterShellHookWindow function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para><c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function was not included in the SDK headers and libraries until Windows XP with Service Pack 1 (SP1) and Windows Server
	/// 2003. If you do not have a header file and import library for this function, you can call the function using LoadLibrary and GetProcAddress.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-deregistershellhookwindow BOOL DeregisterShellHookWindow(
	// HWND hwnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "deregistershellhookwindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeregisterShellHookWindow(HWND hwnd);

	/// <summary>
	/// <para>
	/// Destroys the specified window. The function sends WM_DESTROY and WM_NCDESTROY messages to the window to deactivate it and remove
	/// the keyboard focus from it. The function also destroys the window's menu, flushes the thread message queue, destroys timers,
	/// removes clipboard ownership, and breaks the clipboard viewer chain (if the window is at the top of the viewer chain).
	/// </para>
	/// <para>
	/// If the specified window is a parent or owner window, <c>DestroyWindow</c> automatically destroys the associated child or owned
	/// windows when it destroys the parent or owner window. The function first destroys child or owned windows, and then it destroys the
	/// parent or owner window.
	/// </para>
	/// <para><c>DestroyWindow</c> also destroys modeless dialog boxes created by the CreateDialog function.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to be destroyed.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>A thread cannot use <c>DestroyWindow</c> to destroy a window created by a different thread.</para>
	/// <para>
	/// If the window being destroyed is a child window that does not have the <c>WS_EX_NOPARENTNOTIFY</c> style, a WM_PARENTNOTIFY
	/// message is sent to the parent.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Destroying a Window.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-destroywindow BOOL DestroyWindow( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "destroywindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DestroyWindow(HWND hWnd);

	/// <summary>
	/// Disables the window ghosting feature for the calling GUI process. Window ghosting is a Windows Manager feature that lets the user
	/// minimize, move, or close the main window of an application that is not responding.
	/// </summary>
	/// <remarks>After calling <c>DisableProcessWindowsGhosting</c>, the ghosting feature is disabled for the duration of the process.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-disableprocesswindowsghosting void
	// DisableProcessWindowsGhosting( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern void DisableProcessWindowsGhosting();

	/// <summary>
	/// Captures the mouse and tracks its movement until the user releases the left button, presses the ESC key, or moves the mouse
	/// outside the drag rectangle around the specified point. The width and height of the drag rectangle are specified by the
	/// <c>SM_CXDRAG</c> and <c>SM_CYDRAG</c> values returned by the GetSystemMetrics function.
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window receiving mouse input.</para>
	/// </param>
	/// <param name="pt">
	/// <para>Type: <c>POINT</c></para>
	/// <para>
	/// Initial position of the mouse, in screen coordinates. The function determines the coordinates of the drag rectangle by using this point.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the user moved the mouse outside of the drag rectangle while holding down the left button, the return value is nonzero.</para>
	/// <para>
	/// If the user did not move the mouse outside of the drag rectangle while holding down the left button, the return value is zero.
	/// </para>
	/// </returns>
	/// <remarks>The system metrics for the drag rectangle are configurable, allowing for larger or smaller drag rectangles.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-dragdetect BOOL DragDetect( HWND hwnd, POINT pt );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DragDetect(HWND hwnd, POINT pt);

	/// <summary>
	/// Enables or disables mouse and keyboard input to the specified window or control. When input is disabled, the window does not
	/// receive input such as mouse clicks and key presses. When input is enabled, the window receives all input.
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to be enabled or disabled.</para>
	/// </param>
	/// <param name="bEnable">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// Indicates whether to enable or disable the window. If this parameter is <c>TRUE</c>, the window is enabled. If the parameter is
	/// <c>FALSE</c>, the window is disabled.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the window was previously disabled, the return value is nonzero.</para>
	/// <para>If the window was not previously disabled, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the window is being disabled, the system sends a WM_CANCELMODE message. If the enabled state of a window is changing, the
	/// system sends a WM_ENABLE message after the <c>WM_CANCELMODE</c> message. (These messages are sent before <c>EnableWindow</c>
	/// returns.) If a window is already disabled, its child windows are implicitly disabled, although they are not sent a
	/// <c>WM_ENABLE</c> message.
	/// </para>
	/// <para>
	/// A window must be enabled before it can be activated. For example, if an application is displaying a modeless dialog box and has
	/// disabled its main window, the application must enable the main window before destroying the dialog box. Otherwise, another window
	/// will receive the keyboard focus and be activated. If a child window is disabled, it is ignored when the system tries to determine
	/// which window should receive mouse messages.
	/// </para>
	/// <para>
	/// By default, a window is enabled when it is created. To create a window that is initially disabled, an application can specify the
	/// <c>WS_DISABLED</c> style in the CreateWindow or CreateWindowEx function. After a window has been created, an application can use
	/// <c>EnableWindow</c> to enable or disable the window.
	/// </para>
	/// <para>
	/// An application can use this function to enable or disable a control in a dialog box. A disabled control cannot receive the
	/// keyboard focus, nor can a user gain access to it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enablewindow BOOL EnableWindow( HWND hWnd, BOOL bEnable );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnableWindow(HWND hWnd, [MarshalAs(UnmanagedType.Bool)] bool bEnable);

	/// <summary>
	/// <para>Simultaneously updates the position and size of one or more windows in a single screen-refreshing cycle.</para>
	/// </summary>
	/// <param name="hWinPosInfo">
	/// <para>Type: <c>HDWP</c></para>
	/// <para>
	/// A handle to a multiple-window – position structure that contains size and position information for one or more windows. This
	/// internal structure is returned by the BeginDeferWindowPos function or by the most recent call to the DeferWindowPos function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>EndDeferWindowPos</c> function sends the WM_WINDOWPOSCHANGING and WM_WINDOWPOSCHANGED messages to each window identified
	/// in the internal structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enddeferwindowpos BOOL EndDeferWindowPos( HDWP hWinPosInfo );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "enddeferwindowpos")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EndDeferWindowPos(IntPtr hWinPosInfo);

	/// <summary>
	/// <para>[This function is not intended for general use. It may be altered or unavailable in subsequent versions of Windows.]</para>
	/// <para>Forcibly closes the specified window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to be closed.</para>
	/// </param>
	/// <param name="fShutDown">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Ignored. Must be <c>FALSE</c>.</para>
	/// </param>
	/// <param name="fForce">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// A <c>TRUE</c> for this parameter will force the destruction of the window if an initial attempt fails to gently close the window
	/// using WM_CLOSE. With a <c>FALSE</c> for this parameter, only the close with <c>WM_CLOSE</c> is attempted.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function was not included in the SDK headers and libraries until Windows XP with Service Pack 1 (SP1) and Windows Server
	/// 2003. If you do not have a header file and import library for this function, you can call the function using LoadLibrary and GetProcAddress.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-endtask BOOL EndTask( HWND hWnd, BOOL fShutDown, BOOL
	// fForce );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "endtask")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EndTask(HWND hWnd, [MarshalAs(UnmanagedType.Bool)] bool fShutDown, [MarshalAs(UnmanagedType.Bool)] bool fForce);

	/// <summary>
	/// Enumerates the child windows that belong to the specified parent window by passing the handle to each child window, in turn, to
	/// an application-defined callback function. <c>EnumChildWindows</c> continues until the last child window is enumerated or the
	/// callback function returns <c>FALSE</c>.
	/// </summary>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the parent window whose child windows are to be enumerated. If this parameter is <c>NULL</c>, this function is
	/// equivalent to EnumWindows.
	/// </para>
	/// </param>
	/// <param name="lpEnumFunc">
	/// <para>Type: <c>WNDENUMPROC</c></para>
	/// <para>A pointer to an application-defined callback function. For more information, see EnumChildProc.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>An application-defined value to be passed to the callback function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>The return value is not used.</para>
	/// </returns>
	/// <remarks>
	/// <para>If a child window has created child windows of its own, <c>EnumChildWindows</c> enumerates those windows as well.</para>
	/// <para>
	/// A child window that is moved or repositioned in the Z order during the enumeration process will be properly enumerated. The
	/// function does not enumerate a child window that is destroyed before being enumerated or that is created during the enumeration process.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enumchildwindows BOOL EnumChildWindows( HWND hWndParent,
	// WNDENUMPROC lpEnumFunc, LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "enumchildwindows")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumChildWindows([Optional] HWND hWndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

	/// <summary>
	/// Enumerates the child windows that belong to the specified parent window by passing the handle to each child window, in turn, to
	/// an application-defined callback function. <c>EnumChildWindows</c> continues until the last child window is enumerated or the
	/// callback function returns <c>FALSE</c>.
	/// </summary>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the parent window whose child windows are to be enumerated. If this parameter is <see cref="HWND.NULL"/>, this
	/// function is equivalent to EnumWindows.
	/// </para>
	/// </param>
	/// <returns>An ordered sequence of child window handles.</returns>
	public static IReadOnlyList<HWND> EnumChildWindows(this HWND hWndParent)
	{
		var children = new List<HWND>();
		Win32Error.ThrowLastErrorIfFalse(EnumChildWindows(hWndParent, EnumProc, default));
		return children;

		bool EnumProc(HWND hwnd, IntPtr lParam) { children.Add(hwnd); return true; }
	}

	/// <summary>
	/// <para>
	/// Enumerates all nonchild windows associated with a thread by passing the handle to each window, in turn, to an application-defined
	/// callback function. <c>EnumThreadWindows</c> continues until the last window is enumerated or the callback function returns
	/// <c>FALSE</c>. To enumerate child windows of a particular window, use the EnumChildWindows function.
	/// </para>
	/// </summary>
	/// <param name="dwThreadId">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The identifier of the thread whose windows are to be enumerated.</para>
	/// </param>
	/// <param name="lpfn">
	/// <para>Type: <c>WNDENUMPROC</c></para>
	/// <para>A pointer to an application-defined callback function. For more information, see EnumThreadWndProc.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>An application-defined value to be passed to the callback function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>
	/// If the callback function returns <c>TRUE</c> for all windows in the thread specified by dwThreadId, the return value is
	/// <c>TRUE</c>. If the callback function returns <c>FALSE</c> on any enumerated window, or if there are no windows found in the
	/// thread specified by dwThreadId, the return value is <c>FALSE</c>.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enumthreadwindows BOOL EnumThreadWindows( DWORD
	// dwThreadId, WNDENUMPROC lpfn, LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "enumthreadwindows")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumThreadWindows(uint dwThreadId, EnumWindowsProc lpfn, IntPtr lParam);

	/// <summary>
	/// <para>
	/// Enumerates all top-level windows on the screen by passing the handle to each window, in turn, to an application-defined callback
	/// function. <c>EnumWindows</c> continues until the last top-level window is enumerated or the callback function returns <c>FALSE</c>.
	/// </para>
	/// </summary>
	/// <param name="lpEnumFunc">
	/// <para>Type: <c>WNDENUMPROC</c></para>
	/// <para>A pointer to an application-defined callback function. For more information, see EnumWindowsProc.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>An application-defined value to be passed to the callback function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// If EnumWindowsProc returns zero, the return value is also zero. In this case, the callback function should call SetLastError to
	/// obtain a meaningful error code to be returned to the caller of <c>EnumWindows</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>EnumWindows</c> function does not enumerate child windows, with the exception of a few top-level windows owned by the
	/// system that have the <c>WS_CHILD</c> style.
	/// </para>
	/// <para>
	/// This function is more reliable than calling the GetWindow function in a loop. An application that calls <c>GetWindow</c> to
	/// perform this task risks being caught in an infinite loop or referencing a handle to a window that has been destroyed.
	/// </para>
	/// <para><c>Note</c> For Windows 8 and later, <c>EnumWindows</c> enumerates only top-level windows of desktop apps.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enumwindows BOOL EnumWindows( WNDENUMPROC lpEnumFunc,
	// LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "enumwindows")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

	/// <summary>
	/// <para>
	/// Retrieves a handle to the top-level window whose class name and window name match the specified strings. This function does not
	/// search child windows. This function does not perform a case-sensitive search.
	/// </para>
	/// <para>To search child windows, beginning with a specified child window, use the FindWindowEx function.</para>
	/// </summary>
	/// <param name="lpClassName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in
	/// the low-order word of lpClassName; the high-order word must be zero.
	/// </para>
	/// <para>
	/// If lpClassName points to a string, it specifies the window class name. The class name can be any name registered with
	/// RegisterClass or RegisterClassEx, or any of the predefined control-class names.
	/// </para>
	/// <para>If lpClassName is <c>NULL</c>, it finds any window whose title matches the lpWindowName parameter.</para>
	/// </param>
	/// <param name="lpWindowName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The window name (the window's title). If this parameter is <c>NULL</c>, all window names match.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>If the function succeeds, the return value is a handle to the window that has the specified class name and window name.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the lpWindowName parameter is not <c>NULL</c>, <c>FindWindow</c> calls the GetWindowText function to retrieve the window name
	/// for comparison. For a description of a potential problem that can arise, see the Remarks for <c>GetWindowText</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Retrieving the Number of Mouse Wheel Scroll Lines.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-findwindowa HWND FindWindowA( LPCSTR lpClassName, LPCSTR
	// lpWindowName );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "findwindow")]
	public static extern HWND FindWindow([Optional, MarshalAs(UnmanagedType.LPTStr)] string? lpClassName, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? lpWindowName);

	/// <summary>
	/// Retrieves a handle to a window whose class name and window name match the specified strings. The function searches child windows,
	/// beginning with the one following the specified child window. This function does not perform a case-sensitive search.
	/// </summary>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the parent window whose child windows are to be searched.</para>
	/// <para>
	/// If <c>hwndParent</c> is <c>NULL</c>, the function uses the desktop window as the parent window. The function searches among
	/// windows that are child windows of the desktop.
	/// </para>
	/// <para>If <c>hwndParent</c> is <c>HWND_MESSAGE</c>, the function searches all message-only windows.</para>
	/// </param>
	/// <param name="hWndChildAfter">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to a child window. The search begins with the next child window in the Z order. The child window must be a direct child
	/// window of <c>hwndParent</c>, not just a descendant window.
	/// </para>
	/// <para>If <c>hwndChildAfter</c> is <c>NULL</c>, the search begins with the first child window of <c>hwndParent</c>.</para>
	/// <para>
	/// Note that if both <c>hwndParent</c> and <c>hwndChildAfter</c> are <c>NULL</c>, the function searches all top-level and
	/// message-only windows.
	/// </para>
	/// </param>
	/// <param name="lpszClass">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be
	/// placed in the low-order word of <c>lpszClass</c>; the high-order word must be zero.
	/// </para>
	/// <para>
	/// If <c>lpszClass</c> is a string, it specifies the window class name. The class name can be any name registered with RegisterClass
	/// or RegisterClassEx, or any of the predefined control-class names, or it can be <c>MAKEINTATOM(0x8000)</c>. In this latter case,
	/// 0x8000 is the atom for a menu class. For more information, see the Remarks section of this topic.
	/// </para>
	/// </param>
	/// <param name="lpszWindow">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The window name (the window's title). If this parameter is <c>NULL</c>, all window names match.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>If the function succeeds, the return value is a handle to the window that has the specified class and window names.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The FindWindowEx function searches only direct child windows. It does not search other descendants.</para>
	/// <para>
	/// If the <c>lpszWindow</c> parameter is not <c>NULL</c>, <c>FindWindowEx</c> calls the GetWindowText function to retrieve the
	/// window name for comparison. For a description of a potential problem that can arise, see the Remarks section of <c>GetWindowText</c>.
	/// </para>
	/// <para>An application can call this function in the following way.</para>
	/// <para>
	/// Note that 0x8000 is the atom for a menu class. When an application calls this function, the function checks whether a context
	/// menu is being displayed that the application created.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winuser.h header defines FindWindowEx as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-findwindowexa
	// HWND FindWindowExA( [in, optional] HWND hWndParent, [in, optional] HWND hWndChildAfter, [in, optional] LPCSTR lpszClass, [in, optional] LPCSTR lpszWindow );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.FindWindowExA")]
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	public static extern HWND FindWindowEx([In, Optional] HWND hWndParent, [In, Optional] HWND hWndChildAfter, [In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? lpszClass,
		[In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? lpszWindow);

	/// <summary>
	/// Retrieves a handle to a window whose class name and window name match the specified strings. The function searches child windows,
	/// beginning with the one following the specified child window. This function does not perform a case-sensitive search.
	/// </summary>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the parent window whose child windows are to be searched.</para>
	/// <para>
	/// If <c>hwndParent</c> is <c>NULL</c>, the function uses the desktop window as the parent window. The function searches among
	/// windows that are child windows of the desktop.
	/// </para>
	/// <para>If <c>hwndParent</c> is <c>HWND_MESSAGE</c>, the function searches all message-only windows.</para>
	/// </param>
	/// <param name="hWndChildAfter">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to a child window. The search begins with the next child window in the Z order. The child window must be a direct child
	/// window of <c>hwndParent</c>, not just a descendant window.
	/// </para>
	/// <para>If <c>hwndChildAfter</c> is <c>NULL</c>, the search begins with the first child window of <c>hwndParent</c>.</para>
	/// <para>
	/// Note that if both <c>hwndParent</c> and <c>hwndChildAfter</c> are <c>NULL</c>, the function searches all top-level and
	/// message-only windows.
	/// </para>
	/// </param>
	/// <param name="lpszClass">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be
	/// placed in the low-order word of <c>lpszClass</c>; the high-order word must be zero.
	/// </para>
	/// <para>
	/// If <c>lpszClass</c> is a string, it specifies the window class name. The class name can be any name registered with RegisterClass
	/// or RegisterClassEx, or any of the predefined control-class names, or it can be <c>MAKEINTATOM(0x8000)</c>. In this latter case,
	/// 0x8000 is the atom for a menu class. For more information, see the Remarks section of this topic.
	/// </para>
	/// </param>
	/// <param name="lpszWindow">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The window name (the window's title). If this parameter is <c>NULL</c>, all window names match.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>If the function succeeds, the return value is a handle to the window that has the specified class and window names.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The FindWindowEx function searches only direct child windows. It does not search other descendants.</para>
	/// <para>
	/// If the <c>lpszWindow</c> parameter is not <c>NULL</c>, <c>FindWindowEx</c> calls the GetWindowText function to retrieve the
	/// window name for comparison. For a description of a potential problem that can arise, see the Remarks section of <c>GetWindowText</c>.
	/// </para>
	/// <para>An application can call this function in the following way.</para>
	/// <para>
	/// Note that 0x8000 is the atom for a menu class. When an application calls this function, the function checks whether a context
	/// menu is being displayed that the application created.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winuser.h header defines FindWindowEx as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-findwindowexa
	// HWND FindWindowExA( [in, optional] HWND hWndParent, [in, optional] HWND hWndChildAfter, [in, optional] LPCSTR lpszClass, [in, optional] LPCSTR lpszWindow );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.FindWindowExA")]
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	public static extern HWND FindWindowEx([In, Optional] HWND hWndParent, [In, Optional] HWND hWndChildAfter, [In, Optional] IntPtr lpszClass,
		[In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? lpszWindow);

	/// <summary>
	/// <para>Flashes the specified window one time. It does not change the active state of the window.</para>
	/// <para>To flash the window a specified number of times, use the FlashWindowEx function.</para>
	/// </summary>
	/// <param name="hWnd">A handle to the window to be flashed. The window can be either open or minimized.</param>
	/// <param name="bInvert">
	/// <para>
	/// If this parameter is <c>TRUE</c>, the window is flashed from one state to the other. If it is <c>FALSE</c>, the window is
	/// returned to its original state (either active or inactive).
	/// </para>
	/// <para>
	/// When an application is minimized and this parameter is <c>TRUE</c>, the taskbar window button flashes active/inactive. If it is
	/// <c>FALSE</c>, the taskbar window button flashes inactive, meaning that it does not change colors. It flashes, as if it were being
	/// redrawn, but it does not provide the visual invert clue to the user.
	/// </para>
	/// </param>
	/// <returns>
	/// The return value specifies the window's state before the call to the <c>FlashWindow</c> function. If the window caption was drawn
	/// as active before the call, the return value is nonzero. Otherwise, the return value is zero.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Flashing a window means changing the appearance of its caption bar as if the window were changing from inactive to active status,
	/// or vice versa. (An inactive caption bar changes to an active caption bar; an active caption bar changes to an inactive caption bar.)
	/// </para>
	/// <para>
	/// Typically, a window is flashed to inform the user that the window requires attention but that it does not currently have the
	/// keyboard focus.
	/// </para>
	/// <para>
	/// The <c>FlashWindow</c> function flashes the window only once; for repeated flashing, the application should create a system timer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-flashwindow BOOL FlashWindow( HWND hWnd, BOOL bInvert );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "c4af997d-5cb8-4d5d-ae8d-1e0cc724fe02")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlashWindow(HWND hWnd, [MarshalAs(UnmanagedType.Bool)] bool bInvert);

	/// <summary>Flashes the specified window. It does not change the active state of the window.</summary>
	/// <param name="pfwi">A pointer to a FLASHWINFO structure.</param>
	/// <returns>
	/// The return value specifies the window's state before the call to the <c>FlashWindowEx</c> function. If the window caption was
	/// drawn as active before the call, the return value is nonzero. Otherwise, the return value is zero.
	/// </returns>
	/// <remarks>
	/// Typically, you flash a window to inform the user that the window requires attention but does not currently have the keyboard
	/// focus. When a window flashes, it appears to change from inactive to active status. An inactive caption bar changes to an active
	/// caption bar; an active caption bar changes to an inactive caption bar.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-flashwindowex BOOL FlashWindowEx( PFLASHWINFO pfwi );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "474ec2d9-3ee9-4622-843e-d6ae36fedd7f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlashWindowEx(in FLASHWINFO pfwi);

	/// <summary>
	/// <para>Retrieves the window handle to the active window attached to the calling thread's message queue.</para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// The return value is the handle to the active window attached to the calling thread's message queue. Otherwise, the return value
	/// is <c>NULL</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>To get the handle to the foreground window, you can use GetForegroundWindow.</para>
	/// <para>To get the window handle to the active window in the message queue for another thread, use GetGUIThreadInfo.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getactivewindow HWND GetActiveWindow( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getactivewindow")]
	public static extern HWND GetActiveWindow();

	/// <summary>
	/// <para>Retrieves status information for the specified window if it is the application-switching (ALT+TAB) window.</para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window for which status information will be retrieved. This window must be the application-switching window.</para>
	/// </param>
	/// <param name="iItem">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The index of the icon in the application-switching window. If the pszItemText parameter is not <c>NULL</c>, the name of the item
	/// is copied to the pszItemText string. If this parameter is –1, the name of the item is not copied.
	/// </para>
	/// </param>
	/// <param name="pati">
	/// <para>Type: <c>PALTTABINFO</c></para>
	/// <para>
	/// A pointer to an ALTTABINFO structure to receive the status information. Note that you must set the <c>csSize</c> member to before
	/// calling this function.
	/// </para>
	/// </param>
	/// <param name="pszItemText">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>The name of the item. If this parameter is <c>NULL</c>, the name of the item is not copied.</para>
	/// </param>
	/// <param name="cchItemText">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size, in characters, of the pszItemText buffer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The application-switching window enables you to switch to the most recently used application window. To display the
	/// application-switching window, press ALT+TAB. To select an application from the list, continue to hold ALT down and press TAB to
	/// move through the list. Add SHIFT to reverse direction through the list.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getalttabinfoa BOOL GetAltTabInfoA( HWND hwnd, int iItem,
	// PALTTABINFO pati, LPSTR pszItemText, UINT cchItemText );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "getalttabinfo")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetAltTabInfo(HWND hwnd, int iItem, ref ALTTABINFO pati, [Optional] StringBuilder? pszItemText, uint cchItemText);

	/// <summary>
	/// <para>Retrieves the handle to the ancestor of the specified window.</para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the window whose ancestor is to be retrieved. If this parameter is the desktop window, the function returns <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="gaFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The ancestor to be retrieved. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GA_PARENT 1</term>
	/// <term>Retrieves the parent window. This does not include the owner, as it does with the GetParent function.</term>
	/// </item>
	/// <item>
	/// <term>GA_ROOT 2</term>
	/// <term>Retrieves the root window by walking the chain of parent windows.</term>
	/// </item>
	/// <item>
	/// <term>GA_ROOTOWNER 3</term>
	/// <term>Retrieves the owned root window by walking the chain of parent and owner windows returned by GetParent.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>The return value is the handle to the ancestor window.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getancestor HWND GetAncestor( HWND hwnd, UINT gaFlags );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getancestor")]
	public static extern HWND GetAncestor(HWND hwnd, GetAncestorFlag gaFlags);

	/// <summary>
	/// Retrieves a handle to the window (if any) that has captured the mouse. Only one window at a time can capture the mouse; this
	/// window receives mouse input whether or not the cursor is within its borders.
	/// </summary>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// The return value is a handle to the capture window associated with the current thread. If no window in the thread has captured
	/// the mouse, the return value is <c>NULL</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A <c>NULL</c> return value means the current thread has not captured the mouse. However, it is possible that another thread or
	/// process has captured the mouse.
	/// </para>
	/// <para>To get a handle to the capture window on another thread, use the GetGUIThreadInfo function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getcapture HWND GetCapture( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern HWND GetCapture();

	/// <summary>
	/// Retrieves the child window at the top of the Z order, if the specified window is a parent window; otherwise, the retrieved
	/// handle is NULL. The function examines only child windows of the specified window. It does not examine descendant windows.
	/// </summary>
	/// <param name="hWnd">A handle to a window.</param>
	/// <returns>
	/// If the function succeeds, the return value is a window handle. If no window exists with the specified relationship to the
	/// specified window, the return value is NULL. To get extended error information, call GetLastError.
	/// </returns>
	public static HWND GetChildWindow(this HWND hWnd) => GetWindow(hWnd, GetWindowCmd.GW_CHILD);

	/// <summary>
	/// <para>Retrieves information about a window class.</para>
	/// <para>
	/// <c>Note</c> The <c>GetClassInfo</c> function has been superseded by the GetClassInfoEx function. You can still use
	/// <c>GetClassInfo</c>, however, if you do not need information about the class small icon.
	/// </para>
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>
	/// A handle to the instance of the application that created the class. To retrieve information about classes defined by the system
	/// (such as buttons or list boxes), set this parameter to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="lpClassName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The class name. The name must be that of a preregistered class or a class registered by a previous call to the RegisterClass or
	/// RegisterClassEx function.
	/// </para>
	/// <para>
	/// Alternatively, this parameter can be an atom. If so, it must be a class atom created by a previous call to RegisterClass or
	/// RegisterClassEx. The atom must be in the low-order word of lpClassName; the high-order word must be zero.
	/// </para>
	/// </param>
	/// <param name="lpWndClass">
	/// <para>Type: <c>LPWNDCLASS</c></para>
	/// <para>A pointer to a WNDCLASS structure that receives the information about the class.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function finds a matching class and successfully copies the data, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getclassinfoa BOOL GetClassInfoA( HINSTANCE hInstance,
	// LPCSTR lpClassName, LPWNDCLASSA lpWndClass );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetClassInfo([In, Optional] HINSTANCE hInstance, [MarshalAs(UnmanagedType.LPTStr)] string lpClassName, out WNDCLASS lpWndClass);

	/// <summary>
	/// <para>
	/// Retrieves information about a window class, including a handle to the small icon associated with the window class. The
	/// GetClassInfo function does not retrieve a handle to the small icon.
	/// </para>
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>
	/// A handle to the instance of the application that created the class. To retrieve information about classes defined by the system
	/// (such as buttons or list boxes), set this parameter to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="lpszClass">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The class name. The name must be that of a preregistered class or a class registered by a previous call to the RegisterClass or
	/// RegisterClassEx function. Alternatively, this parameter can be a class atom created by a previous call to <c>RegisterClass</c> or
	/// <c>RegisterClassEx</c>. The atom must be in the low-order word of lpszClass; the high-order word must be zero.
	/// </para>
	/// </param>
	/// <param name="lpwcx">
	/// <para>Type: <c>LPWNDCLASSEX</c></para>
	/// <para>A pointer to a WNDCLASSEX structure that receives the information about the class.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function finds a matching class and successfully copies the data, the return value is nonzero.</para>
	/// <para>
	/// If the function does not find a matching class and successfully copy the data, the return value is zero. To get extended error
	/// information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Class atoms are created using the RegisterClass or RegisterClassEx function, not the GlobalAddAtom function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getclassinfoexa BOOL GetClassInfoExA( HINSTANCE hInstance,
	// LPCSTR lpszClass, LPWNDCLASSEXA lpwcx );
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static bool GetClassInfoEx([In] HINSTANCE hInstance, string lpszClass, out WNDCLASSEX lpwcx)
	{
		WNDCLASSEXB wc = new();
		var ret = GetClassInfoEx(hInstance, lpszClass, ref wc);
		lpwcx = wc;
		return ret;
	}

	/// <summary>
	/// <para>
	/// Retrieves information about a window class, including a handle to the small icon associated with the window class. The
	/// GetClassInfo function does not retrieve a handle to the small icon.
	/// </para>
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>
	/// A handle to the instance of the application that created the class. To retrieve information about classes defined by the system
	/// (such as buttons or list boxes), set this parameter to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="lpszClass">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The class name. The name must be that of a preregistered class or a class registered by a previous call to the RegisterClass or
	/// RegisterClassEx function. Alternatively, this parameter can be a class atom created by a previous call to <c>RegisterClass</c> or
	/// <c>RegisterClassEx</c>. The atom must be in the low-order word of lpszClass; the high-order word must be zero.
	/// </para>
	/// </param>
	/// <param name="lpwcx">
	/// <para>Type: <c>LPWNDCLASSEX</c></para>
	/// <para>A pointer to a WNDCLASSEX structure that receives the information about the class.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function finds a matching class and successfully copies the data, the return value is nonzero.</para>
	/// <para>
	/// If the function does not find a matching class and successfully copy the data, the return value is zero. To get extended error
	/// information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Class atoms are created using the RegisterClass or RegisterClassEx function, not the GlobalAddAtom function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getclassinfoexa BOOL GetClassInfoExA( HINSTANCE hInstance,
	// LPCSTR lpszClass, LPWNDCLASSEXA lpwcx );
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static bool GetClassInfoEx([In] HINSTANCE hInstance, IntPtr lpszClass, out WNDCLASSEX lpwcx)
	{
		WNDCLASSEXB wc = new();
		var ret = GetClassInfoEx(hInstance, lpszClass, ref wc);
		lpwcx = wc;
		return ret;
	}

	/// <summary>
	/// <para>Retrieves the specified value from the WNDCLASSEX structure associated with the specified window.</para>
	/// <para>
	/// <c>Note</c> To write code that is compatible with both 32-bit and 64-bit versions of Windows, use <c>GetClassLongPtr</c>. When
	/// compiling for 32-bit Windows, <c>GetClassLongPtr</c> is defined as a call to the GetClassLong function.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window and, indirectly, the class to which the window belongs.</para>
	/// </param>
	/// <param name="nIndex">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The value to be retrieved. To retrieve a value from the extra class memory, specify the positive, zero-based byte offset of the
	/// value to be retrieved. Valid values are in the range zero through the number of bytes of extra class memory, minus eight; for
	/// example, if you specified 24 or more bytes of extra class memory, a value of 16 would be an index to the third integer. To
	/// retrieve any other value from the WNDCLASSEX structure, specify one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GCW_ATOM -32</term>
	/// <term>
	/// Retrieves an ATOM value that uniquely identifies the window class. This is the same atom that the RegisterClassEx function returns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCL_CBCLSEXTRA -20</term>
	/// <term>Retrieves the size, in bytes, of the extra memory associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_CBWNDEXTRA -18</term>
	/// <term>
	/// Retrieves the size, in bytes, of the extra window memory associated with each window in the class. For information on how to
	/// access this memory, see GetWindowLongPtr.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCLP_HBRBACKGROUND -10</term>
	/// <term>Retrieves a handle to the background brush associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HCURSOR -12</term>
	/// <term>Retrieves a handle to the cursor associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HICON -14</term>
	/// <term>Retrieves a handle to the icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HICONSM -34</term>
	/// <term>Retrieves a handle to the small icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HMODULE -16</term>
	/// <term>Retrieves a handle to the module that registered the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_MENUNAME -8</term>
	/// <term>Retrieves the pointer to the menu name string. The string identifies the menu resource associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_STYLE -26</term>
	/// <term>Retrieves the window-class style bits.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_WNDPROC -24</term>
	/// <term>
	/// Retrieves the address of the window procedure, or a handle representing the address of the window procedure. You must use the
	/// CallWindowProc function to call the window procedure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>ULONG_PTR</c></c></para>
	/// <para>If the function succeeds, the return value is the requested value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// Reserve extra class memory by specifying a nonzero value in the <c>cbClsExtra</c> member of the WNDCLASSEX structure used with
	/// the RegisterClassEx function.
	/// </remarks>
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static IntPtr GetClassLong(HWND hWnd, int nIndex) => IntPtr.Size > 4 ? GetClassLongPtr(hWnd, nIndex) : (IntPtr)GetClassLong32(hWnd, nIndex);

	/// <summary>
	/// <para>Retrieves the specified value from the WNDCLASSEX structure associated with the specified window.</para>
	/// <para>
	/// <c>Note</c> To write code that is compatible with both 32-bit and 64-bit versions of Windows, use <c>GetClassLongPtr</c>. When
	/// compiling for 32-bit Windows, <c>GetClassLongPtr</c> is defined as a call to the GetClassLong function.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window and, indirectly, the class to which the window belongs.</para>
	/// </param>
	/// <param name="nIndex">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The value to be retrieved. To retrieve a value from the extra class memory, specify the positive, zero-based byte offset of the
	/// value to be retrieved. Valid values are in the range zero through the number of bytes of extra class memory, minus eight; for
	/// example, if you specified 24 or more bytes of extra class memory, a value of 16 would be an index to the third integer. To
	/// retrieve any other value from the WNDCLASSEX structure, specify one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GCW_ATOM -32</term>
	/// <term>
	/// Retrieves an ATOM value that uniquely identifies the window class. This is the same atom that the RegisterClassEx function returns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCL_CBCLSEXTRA -20</term>
	/// <term>Retrieves the size, in bytes, of the extra memory associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_CBWNDEXTRA -18</term>
	/// <term>
	/// Retrieves the size, in bytes, of the extra window memory associated with each window in the class. For information on how to
	/// access this memory, see GetWindowLongPtr.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCLP_HBRBACKGROUND -10</term>
	/// <term>Retrieves a handle to the background brush associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HCURSOR -12</term>
	/// <term>Retrieves a handle to the cursor associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HICON -14</term>
	/// <term>Retrieves a handle to the icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HICONSM -34</term>
	/// <term>Retrieves a handle to the small icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HMODULE -16</term>
	/// <term>Retrieves a handle to the module that registered the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_MENUNAME -8</term>
	/// <term>Retrieves the pointer to the menu name string. The string identifies the menu resource associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_STYLE -26</term>
	/// <term>Retrieves the window-class style bits.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_WNDPROC -24</term>
	/// <term>
	/// Retrieves the address of the window procedure, or a handle representing the address of the window procedure. You must use the
	/// CallWindowProc function to call the window procedure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>ULONG_PTR</c></c></para>
	/// <para>If the function succeeds, the return value is the requested value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// Reserve extra class memory by specifying a nonzero value in the <c>cbClsExtra</c> member of the WNDCLASSEX structure used with
	/// the RegisterClassEx function.
	/// </remarks>
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static IntPtr GetClassLong(HWND hWnd, GetClassLongFlag nIndex) => GetClassLong(hWnd, (int)nIndex);

	/// <summary>Retrieves the name of the class to which the specified window belongs.</summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window and, indirectly, the class to which the window belongs.</para>
	/// </param>
	/// <param name="lpClassName">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>The class name string.</para>
	/// </param>
	/// <param name="nMaxCount">
	/// <para>Type: <c>int</c></para>
	/// <para>The length</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>int</c></c></para>
	/// <para>
	/// If the function succeeds, the return value is the number of characters copied to the buffer, not including the terminating null character.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getclassname int GetClassName( HWND hWnd, LPTSTR
	// lpClassName, int nMaxCount );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern int GetClassName(HWND hWnd, StringBuilder lpClassName, int nMaxCount);

	/// <summary>
	/// <para>
	/// Retrieves the 16-bit ( <c>WORD</c>) value at the specified offset into the extra class memory for the window class to which the
	/// specified window belongs.
	/// </para>
	/// <para>
	/// <c>Note</c> This function is deprecated for any use other than <c>nIndex</c> set to <c>GCW_ATOM</c>. The function is provided
	/// only for compatibility with 16-bit versions of Windows. Applications should use the GetClassLongPtr or GetClassLongPtr function.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window and, indirectly, the class to which the window belongs.</para>
	/// </param>
	/// <param name="nIndex">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The zero-based byte offset of the value to be retrieved. Valid values are in the range zero through the number of bytes of class
	/// memory, minus two; for example, if you specified 10 or more bytes of extra class memory, a value of eight would be an index to
	/// the fifth 16-bit integer. There is an additional valid value as shown in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>GCW_ATOM</c> -32</term>
	/// <term>
	/// Retrieves an <c>ATOM</c> value that uniquely identifies the window class. This is the same atom that the RegisterClass or
	/// RegisterClassEx function returns.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>WORD</c></para>
	/// <para>If the function succeeds, the return value is the requested 16-bit value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// Reserve extra class memory by specifying a nonzero value in the <c>cbClsExtra</c> member of the WNDCLASS structure used with the
	/// RegisterClass function.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclassword
	// WORD GetClassWord( [in] HWND hWnd, [in] int nIndex );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.GetClassWord")]
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	public static extern ushort GetClassWord([In] HWND hWnd, GCW nIndex);

	/// <summary>
	/// Retrieves the coordinates of a window's client area. The client coordinates specify the upper-left and lower-right corners of the
	/// client area. Because client coordinates are relative to the upper-left corner of a window's client area, the coordinates of the
	/// upper-left corner are (0,0).
	/// </summary>
	/// <param name="hWnd">A handle to the window whose client coordinates are to be retrieved.</param>
	/// <param name="lpRect">
	/// A pointer to a RECT structure that receives the client coordinates. The left and top members are zero. The right and bottom
	/// members contain the width and height of the window.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is true. If the function fails, the return value is false. To get extended error
	/// information, call GetLastError.
	/// </returns>
	[PInvokeData("WinUser.h", MSDNShortId = "ms633503")]
	[DllImport(Lib.User32, CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[System.Security.SecurityCritical]
	public static extern bool GetClientRect(HWND hWnd, out RECT lpRect);

	/// <summary>
	/// Retrieves a handle to the desktop window. The desktop window covers the entire screen. The desktop window is the area on top of
	/// which other windows are painted.
	/// </summary>
	/// <returns>The return value is a handle to the desktop window.</returns>
	// HWND WINAPI GetDesktopWindow(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms633504(v=vs.85).aspx
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winuser.h", MSDNShortId = "ms633504")]
	public static extern HWND GetDesktopWindow();

	/// <summary>
	/// Retrieves the handle to the window that has the keyboard focus, if the window is attached to the calling thread's message queue.
	/// </summary>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// The return value is the handle to the window with the keyboard focus. If the calling thread's message queue does not have an
	/// associated window with the keyboard focus, the return value is <c>NULL</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>GetFocus</c> returns the window with the keyboard focus for the current thread's message queue. If <c>GetFocus</c> returns
	/// <c>NULL</c>, another thread's queue may be attached to a window that has the keyboard focus.
	/// </para>
	/// <para>
	/// Use the GetForegroundWindow function to retrieve the handle to the window with which the user is currently working. You can
	/// associate your thread's message queue with the windows owned by another thread by using the AttachThreadInput function.
	/// </para>
	/// <para>
	/// To get the window with the keyboard focus on the foreground queue or the queue of another thread, use the GetGUIThreadInfo function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see "Creating a Combo Box Toolbar" in Using Combo Boxes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getfocus HWND GetFocus( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern HWND GetFocus();

	/// <summary>
	/// <para>
	/// Retrieves a handle to the foreground window (the window with which the user is currently working). The system assigns a slightly
	/// higher priority to the thread that creates the foreground window than it does to other threads.
	/// </para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>
	/// The return value is a handle to the foreground window. The foreground window can be <c>NULL</c> in certain circumstances, such as
	/// when a window is losing activation.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getforegroundwindow HWND GetForegroundWindow( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getforegroundwindow")]
	public static extern HWND GetForegroundWindow();

	/// <summary>
	/// <para>Retrieves information about the active window or a specified GUI thread.</para>
	/// </summary>
	/// <param name="idThread">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The identifier for the thread for which information is to be retrieved. To retrieve this value, use the GetWindowThreadProcessId
	/// function. If this parameter is <c>NULL</c>, the function returns information for the foreground thread.
	/// </para>
	/// </param>
	/// <param name="pgui">
	/// <para>Type: <c>LPGUITHREADINFO</c></para>
	/// <para>
	/// A pointer to a GUITHREADINFO structure that receives information describing the thread. Note that you must set the <c>cbSize</c>
	/// member to before calling this function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function succeeds even if the active window is not owned by the calling process. If the specified thread does not exist or
	/// have an input queue, the function will fail.
	/// </para>
	/// <para>
	/// This function is useful for retrieving out-of-context information about a thread. The information retrieved is the same as if an
	/// application retrieved the information about itself.
	/// </para>
	/// <para>
	/// For an edit control, the returned <c>rcCaret</c> rectangle contains the caret plus information on text direction and padding.
	/// Thus, it may not give the correct position of the cursor. The Sans Serif font uses four characters for the cursor:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Cursor character</term>
	/// <term>Unicode code point</term>
	/// </listheader>
	/// <item>
	/// <term>CURSOR_LTR</term>
	/// <term>0xf00c</term>
	/// </item>
	/// <item>
	/// <term>CURSOR_RTL</term>
	/// <term>0xf00d</term>
	/// </item>
	/// <item>
	/// <term>CURSOR_THAI</term>
	/// <term>0xf00e</term>
	/// </item>
	/// <item>
	/// <term>CURSOR_USA</term>
	/// <term>0xfff (this is a marker value with no associated glyph)</term>
	/// </item>
	/// </list>
	/// <para>To get the actual insertion point in the <c>rcCaret</c> rectangle, perform the following steps.</para>
	/// <list type="number">
	/// <item>
	/// <term>Call GetKeyboardLayout to retrieve the current input language.</term>
	/// </item>
	/// <item>
	/// <term>Determine the character used for the cursor, based on the current input language.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Call CreateFont using Sans Serif for the font, the height given by <c>rcCaret</c>, and a width of . For fnWeight, call . If
	/// pvParam is greater than 1, set fnWeight to 700, otherwise set fnWeight to 400.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Select the font into a device context (DC) and use GetCharABCWidths to get the width of the appropriate cursor character.</term>
	/// </item>
	/// <item>
	/// <term>Add the width to <c>rcCaret</c>. <c>left</c> to obtain the actual insertion point.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The function may not return valid window handles in the GUITHREADINFO structure when called to retrieve information for the
	/// foreground thread, such as when a window is losing activation.
	/// </para>
	/// <para>DPI Virtualization</para>
	/// <para>
	/// The coordinates returned in the <c>rcCaret</c> rect of the GUITHREADINFO struct are logical coordinates in terms of the window
	/// associated with the caret. They are not virtualized into the mode of the calling thread.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getguithreadinfo BOOL GetGUIThreadInfo( DWORD idThread,
	// PGUITHREADINFO pgui );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getguithreadinfo")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetGUIThreadInfo(uint idThread, ref GUITHREADINFO pgui);

	/// <summary>
	/// <para>Determines which pop-up window owned by the specified window was most recently active.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the owner window.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>
	/// The return value identifies the most recently active pop-up window. The return value is the same as the hWnd parameter, if any of
	/// the following conditions are met:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The window identified by hWnd was most recently active.</term>
	/// </item>
	/// <item>
	/// <term>The window identified by hWnd does not own any pop-up windows.</term>
	/// </item>
	/// <item>
	/// <term>The window identifies by hWnd is not a top-level window, or it is owned by another window.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getlastactivepopup HWND GetLastActivePopup( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getlastactivepopup")]
	public static extern HWND GetLastActivePopup(HWND hWnd);

	/// <summary>
	/// <para>Retrieves the opacity and transparency color key of a layered window.</para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the layered window. A layered window is created by specifying <c>WS_EX_LAYERED</c> when creating the window with the
	/// CreateWindowEx function or by setting <c>WS_EX_LAYERED</c> using SetWindowLong after the window has been created.
	/// </para>
	/// </param>
	/// <param name="pcrKey">
	/// <para>Type: <c>COLORREF*</c></para>
	/// <para>
	/// A pointer to a COLORREF value that receives the transparency color key to be used when composing the layered window. All pixels
	/// painted by the window in this color will be transparent. This can be <c>NULL</c> if the argument is not needed.
	/// </para>
	/// </param>
	/// <param name="pbAlpha">
	/// <para>Type: <c>BYTE*</c></para>
	/// <para>
	/// The Alpha value used to describe the opacity of the layered window. Similar to the <c>SourceConstantAlpha</c> member of the
	/// BLENDFUNCTION structure. When the variable referred to by pbAlpha is 0, the window is completely transparent. When the variable
	/// referred to by pbAlpha is 255, the window is opaque. This can be <c>NULL</c> if the argument is not needed.
	/// </para>
	/// </param>
	/// <param name="pdwFlags">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>
	/// A layering flag. This parameter can be <c>NULL</c> if the value is not needed. The layering flag can be one or more of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LWA_ALPHA 0x00000002</term>
	/// <term>Use pbAlpha to determine the opacity of the layered window.</term>
	/// </item>
	/// <item>
	/// <term>LWA_COLORKEY 0x00000001</term>
	/// <term>Use pcrKey as the transparency color.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>GetLayeredWindowAttributes</c> can be called only if the application has previously called SetLayeredWindowAttributes on the
	/// window. The function will fail if the layered window was setup with UpdateLayeredWindow.
	/// </para>
	/// <para>For more information, see Using Layered Windows.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getlayeredwindowattributes BOOL
	// GetLayeredWindowAttributes( HWND hwnd, COLORREF *pcrKey, BYTE *pbAlpha, DWORD *pdwFlags );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getlayeredwindowattributes")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetLayeredWindowAttributes(HWND hwnd, out COLORREF pcrKey, out byte pbAlpha, out LayeredWindowAttributes pdwFlags);

	/// <summary>
	/// <para>
	/// Retrieves a handle to the next or previous window in the Z-Order. The next window is below the specified window; the previous
	/// window is above.
	/// </para>
	/// <para>
	/// If the specified window is a topmost window, the function searches for a topmost window. If the specified window is a top-level
	/// window, the function searches for a top-level window. If the specified window is a child window, the function searches for a
	/// child window.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to a window. The window handle retrieved is relative to this window, based on the value of the wCmd parameter.</para>
	/// </param>
	/// <param name="wCmd">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Indicates whether the function returns a handle to the next window or the previous window. This parameter can be either of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GW_HWNDNEXT 2</term>
	/// <term>Returns a handle to the window below the given window.</term>
	/// </item>
	/// <item>
	/// <term>GW_HWNDPREV 3</term>
	/// <term>Returns a handle to the window above the given window.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>None</para>
	/// </returns>
	/// <remarks>
	/// <para>This function is implemented as a call to the GetWindow function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getnextwindow void GetNextWindow( hWnd, wCmd );
	[PInvokeData("winuser.h", MSDNShortId = "getnextwindow")]
	public static void GetNextWindow(HWND hWnd, GetWindowCmd wCmd) => GetWindow(hWnd, wCmd);

	/// <summary>
	/// <para>Retrieves a handle to the specified window's parent or owner.</para>
	/// <para>To retrieve a handle to a specified ancestor, use the GetAncestor function.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window whose parent window handle is to be retrieved.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>
	/// If the window is a child window, the return value is a handle to the parent window. If the window is a top-level window with the
	/// <c>WS_POPUP</c> style, the return value is a handle to the owner window.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// <para>This function typically fails for one of the following reasons:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The window is a top-level window that is unowned or does not have the <c>WS_POPUP</c> style.</term>
	/// </item>
	/// <item>
	/// <term>The owner window has <c>WS_POPUP</c> style.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To obtain a window's owner window, instead of using <c>GetParent</c>, use GetWindow with the <c>GW_OWNER</c> flag. To obtain the
	/// parent window and not the owner, instead of using <c>GetParent</c>, use GetAncestor with the <c>GA_PARENT</c> flag.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Initializing a Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getparent HWND GetParent( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getparent")]
	public static extern HWND GetParent(HWND hWnd);

	/// <summary>
	/// <para>Retrieves the default layout that is used when windows are created with no parent or owner.</para>
	/// </summary>
	/// <param name="pdwDefaultLayout">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>The current default process layout. For a list of values, see SetProcessDefaultLayout.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The layout specifies how text and graphics are laid out in a window; the default is left to right. The
	/// <c>GetProcessDefaultLayout</c> function lets you know if the default layout has changed, from using SetProcessDefaultLayout.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getprocessdefaultlayout BOOL GetProcessDefaultLayout(
	// DWORD *pdwDefaultLayout );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getprocessdefaultlayout")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetProcessDefaultLayout(out DefaultLayout pdwDefaultLayout);

	/// <summary>
	/// <para>Retrieves a handle to the Shell's desktop window.</para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>The return value is the handle of the Shell's desktop window. If no Shell process is present, the return value is <c>NULL</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getshellwindow HWND GetShellWindow( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getshellwindow")]
	public static extern HWND GetShellWindow();

	/// <summary>
	/// <para>Retrieves information about the specified title bar.</para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the title bar whose information is to be retrieved.</para>
	/// </param>
	/// <param name="pti">
	/// <para>Type: <c>PTITLEBARINFO</c></para>
	/// <para>
	/// A pointer to a TITLEBARINFO structure to receive the information. Note that you must set the <c>cbSize</c> member to before
	/// calling this function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-gettitlebarinfo BOOL GetTitleBarInfo( HWND hwnd,
	// PTITLEBARINFO pti );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "gettitlebarinfo")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetTitleBarInfo(HWND hwnd, ref TITLEBARINFO pti);

	/// <summary>
	/// <para>
	/// Examines the Z order of the child windows associated with the specified parent window and retrieves a handle to the child window
	/// at the top of the Z order.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the parent window whose child windows are to be examined. If this parameter is <c>NULL</c>, the function returns a
	/// handle to the window at the top of the Z order.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>
	/// If the function succeeds, the return value is a handle to the child window at the top of the Z order. If the specified window has
	/// no child windows, the return value is <c>NULL</c>. To get extended error information, use the GetLastError function.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-gettopwindow HWND GetTopWindow( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "gettopwindow")]
	public static extern HWND GetTopWindow([Optional] HWND hWnd);

	/// <summary>
	/// <para>Retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to a window. The window handle retrieved is relative to this window, based on the value of the uCmd parameter.</para>
	/// </param>
	/// <param name="uCmd">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The relationship between the specified window and the window whose handle is to be retrieved. This parameter can be one of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GW_CHILD 5</term>
	/// <term>
	/// The retrieved handle identifies the child window at the top of the Z order, if the specified window is a parent window;
	/// otherwise, the retrieved handle is NULL. The function examines only child windows of the specified window. It does not examine
	/// descendant windows.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GW_ENABLEDPOPUP 6</term>
	/// <term>
	/// The retrieved handle identifies the enabled popup window owned by the specified window (the search uses the first such window
	/// found using GW_HWNDNEXT); otherwise, if there are no enabled popup windows, the retrieved handle is that of the specified window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GW_HWNDFIRST 0</term>
	/// <term>
	/// The retrieved handle identifies the window of the same type that is highest in the Z order. If the specified window is a topmost
	/// window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level
	/// window. If the specified window is a child window, the handle identifies a sibling window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GW_HWNDLAST 1</term>
	/// <term>
	/// The retrieved handle identifies the window of the same type that is lowest in the Z order. If the specified window is a topmost
	/// window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level
	/// window. If the specified window is a child window, the handle identifies a sibling window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GW_HWNDNEXT 2</term>
	/// <term>
	/// The retrieved handle identifies the window below the specified window in the Z order. If the specified window is a topmost
	/// window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level
	/// window. If the specified window is a child window, the handle identifies a sibling window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GW_HWNDPREV 3</term>
	/// <term>
	/// The retrieved handle identifies the window above the specified window in the Z order. If the specified window is a topmost
	/// window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level
	/// window. If the specified window is a child window, the handle identifies a sibling window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GW_OWNER 4</term>
	/// <term>The retrieved handle identifies the specified window's owner window, if any. For more information, see Owned Windows.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>
	/// If the function succeeds, the return value is a window handle. If no window exists with the specified relationship to the
	/// specified window, the return value is <c>NULL</c>. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The EnumChildWindows function is more reliable than calling <c>GetWindow</c> in a loop. An application that calls
	/// <c>GetWindow</c> to perform this task risks being caught in an infinite loop or referencing a handle to a window that has been destroyed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindow HWND GetWindow( HWND hWnd, UINT uCmd );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getwindow")]
	public static extern HWND GetWindow(HWND hWnd, GetWindowCmd uCmd);

	/// <summary>Retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.</summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to a window. The window handle retrieved is relative to this window, based on the value of the uCmd parameter.</para>
	/// </param>
	/// <param name="uCmd">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The relationship between the specified window and the window whose handle is to be retrieved. This parameter can be one of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GW_CHILD 5</term>
	/// <term>
	/// The retrieved handle identifies the child window at the top of the Z order, if the specified window is a parent window;
	/// otherwise, the retrieved handle is NULL. The function examines only child windows of the specified window. It does not examine
	/// descendant windows.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GW_ENABLEDPOPUP 6</term>
	/// <term>
	/// The retrieved handle identifies the enabled popup window owned by the specified window (the search uses the first such window
	/// found using GW_HWNDNEXT); otherwise, if there are no enabled popup windows, the retrieved handle is that of the specified window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GW_HWNDFIRST 0</term>
	/// <term>
	/// The retrieved handle identifies the window of the same type that is highest in the Z order. If the specified window is a topmost
	/// window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level
	/// window. If the specified window is a child window, the handle identifies a sibling window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GW_HWNDLAST 1</term>
	/// <term>
	/// The retrieved handle identifies the window of the same type that is lowest in the Z order. If the specified window is a topmost
	/// window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level
	/// window. If the specified window is a child window, the handle identifies a sibling window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GW_HWNDNEXT 2</term>
	/// <term>
	/// The retrieved handle identifies the window below the specified window in the Z order. If the specified window is a topmost
	/// window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level
	/// window. If the specified window is a child window, the handle identifies a sibling window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GW_HWNDPREV 3</term>
	/// <term>
	/// The retrieved handle identifies the window above the specified window in the Z order. If the specified window is a topmost
	/// window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level
	/// window. If the specified window is a child window, the handle identifies a sibling window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GW_OWNER 4</term>
	/// <term>The retrieved handle identifies the specified window's owner window, if any. For more information, see Owned Windows.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>
	/// If the function succeeds, the return value is a window handle. If no window exists with the specified relationship to the
	/// specified window, the return value is <c>NULL</c>. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// The EnumChildWindows function is more reliable than calling <c>GetWindow</c> in a loop. An application that calls
	/// <c>GetWindow</c> to perform this task risks being caught in an infinite loop or referencing a handle to a window that has been destroyed.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindow HWND GetWindow( HWND hWnd, UINT uCmd );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern HWND GetWindow(HWND hWnd, uint uCmd);

	/// <summary>Retrieves the Help context identifier, if any, associated with the specified window.</summary>
	/// <param name="Arg1">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window for which the Help context identifier is to be retrieved.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Returns the Help context identifier if the window has one, or zero otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindowcontexthelpid DWORD GetWindowContextHelpId( HWND
	// Arg1 );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "28e57c01-0327-4f64-9ef4-ca13c3c32b0c")]
	public static extern uint GetWindowContextHelpId(HWND Arg1);

	/// <summary>
	/// <para>Retrieves the current display affinity setting, from any process, for a given window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window.</para>
	/// </param>
	/// <param name="pdwAffinity">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>The display affinity setting.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>
	/// This function succeeds only when the window is layered and Desktop Windows Manager is composing the desktop. If this function
	/// succeeds, it returns <c>TRUE</c>; otherwise, it returns <c>FALSE</c>. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function currently only supports one flag, <c>WDA_MONITOR</c> (0x01). This flag enables a window's contents to be displayed
	/// only on the monitor.
	/// </para>
	/// <para>
	/// This function and SetWindowDisplayAffinity are designed to support the window content protection feature unique to Windows 7.
	/// This feature enables applications to protect their own onscreen window content from being captured or copied via a specific set
	/// of public operating system features and APIs. However, it works only when the Desktop Window Manager (DWM) is composing the desktop.
	/// </para>
	/// <para>
	/// It is important to note that unlike a security feature or an implementation of Digital Rights Management (DRM), there is no
	/// guarantee that using SetWindowDisplayAffinity and <c>GetWindowDisplayAffinity</c>, and other necessary functions such as
	/// DwmIsCompositionEnabled, will strictly protect windowed content, as in the case where someone takes a photograph of the screen.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindowdisplayaffinity BOOL GetWindowDisplayAffinity(
	// HWND hWnd, DWORD *pdwAffinity );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getwindowdisplayaffinity")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetWindowDisplayAffinity(HWND hWnd, out WindowDisplayAffinity pdwAffinity);

	/// <summary>Retrieves the feedback configuration for a window.</summary>
	/// <param name="hwnd">The window to check for feedback configuration.</param>
	/// <param name="feedback">One of the values from the FEEDBACK_TYPE enumeration.</param>
	/// <param name="dwFlags">
	/// Specify GWFS_INCLUDE_ANCESTORS to check the parent window chain until a value is found. The default is 0 and indicates that only
	/// the specified window will be checked.
	/// </param>
	/// <param name="pSize">
	/// <para>The size of memory region that the config parameter points to.</para>
	/// <para>The pSize parameter specifies the size of the configuration data for the feedback type in feedback and must be sizeof(BOOL).</para>
	/// </param>
	/// <param name="config">
	/// <para>The configuration data.</para>
	/// <para>The config parameter must point to a value of type BOOL.</para>
	/// </param>
	/// <returns>
	/// Returns TRUE if the specified feedback setting is configured on the specified window. Otherwise, it returns FALSE (and config
	/// won't be modified).
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindowfeedbacksetting BOOL GetWindowFeedbackSetting(
	// HWND hwnd, FEEDBACK_TYPE feedback, DWORD dwFlags, UINT32 *pSize, VOID *config );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "a40806b3-9085-42b6-9a87-95be0d1669c6")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetWindowFeedbackSetting(HWND hwnd, FEEDBACK_TYPE feedback, GWFS dwFlags, ref uint pSize, [MarshalAs(UnmanagedType.Bool)] out bool config);

	/// <summary>
	/// <para>Retrieves information about the specified window.</para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window whose information is to be retrieved.</para>
	/// </param>
	/// <param name="pwi">
	/// <para>Type: <c>PWINDOWINFO</c></para>
	/// <para>
	/// A pointer to a WINDOWINFO structure to receive the information. Note that you must set the <c>cbSize</c> member to before calling
	/// this function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindowinfo BOOL GetWindowInfo( HWND hwnd, PWINDOWINFO
	// pwi );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getwindowinfo")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetWindowInfo(HWND hwnd, ref WINDOWINFO pwi);

	/// <summary>
	/// <para>Retrieves the full path and file name of the module associated with the specified window handle.</para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window whose module file name is to be retrieved.</para>
	/// </param>
	/// <param name="pszFileName">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>The path and file name.</para>
	/// </param>
	/// <param name="cchFileNameMax">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The maximum number of characters that can be copied into the lpszFileName buffer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>UINT</c></c></para>
	/// <para>The return value is the total number of characters copied into the buffer.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindowmodulefilenamea UINT GetWindowModuleFileNameA(
	// HWND hwnd, LPSTR pszFileName, UINT cchFileNameMax );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "getwindowmodulefilename")]
	public static extern uint GetWindowModuleFileName(HWND hwnd, StringBuilder pszFileName, uint cchFileNameMax);

	/// <summary>
	/// <para>Retrieves the show state and the restored, minimized, and maximized positions of the specified window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window.</para>
	/// </param>
	/// <param name="lpwndpl">
	/// <para>Type: <c>WINDOWPLACEMENT*</c></para>
	/// <para>
	/// A pointer to the WINDOWPLACEMENT structure that receives the show state and position information. Before calling
	/// <c>GetWindowPlacement</c>, set the <c>length</c> member to . <c>GetWindowPlacement</c> fails if lpwndpl-&gt; length is not set correctly.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>flags</c> member of WINDOWPLACEMENT retrieved by this function is always zero. If the window identified by the hWnd
	/// parameter is maximized, the <c>showCmd</c> member is SW_SHOWMAXIMIZED. If the window is minimized, <c>showCmd</c> is
	/// SW_SHOWMINIMIZED. Otherwise, it is SW_SHOWNORMAL.
	/// </para>
	/// <para>
	/// The <c>length</c> member of WINDOWPLACEMENT must be set to sizeof( <c>WINDOWPLACEMENT</c>). If this member is not set correctly,
	/// the function returns <c>FALSE</c>. For additional remarks on the proper use of window placement coordinates, see <c>WINDOWPLACEMENT</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindowplacement BOOL GetWindowPlacement( HWND hWnd,
	// WINDOWPLACEMENT *lpwndpl );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getwindowplacement")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetWindowPlacement(HWND hWnd, ref WINDOWPLACEMENT lpwndpl);

	/// <summary>
	/// Retrieves the dimensions of the bounding rectangle of the specified window. The dimensions are given in screen coordinates that
	/// are relative to the upper-left corner of the screen.
	/// </summary>
	/// <param name="hWnd">A handle to the window.</param>
	/// <param name="lpRect">
	/// A pointer to a RECT structure that receives the screen coordinates of the upper-left and lower-right corners of the window.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is true. If the function fails, the return value is false. To get extended error
	/// information, call GetLastError.
	/// </returns>
	[PInvokeData("WinUser.h", MSDNShortId = "ms633519")]
	[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[System.Security.SecurityCritical]
	public static extern bool GetWindowRect(HWND hWnd, out RECT lpRect);

	/// <summary>
	/// <para>
	/// Copies the text of the specified window's title bar (if it has one) into a buffer. If the specified window is a control, the text
	/// of the control is copied. However, <c>GetWindowText</c> cannot retrieve the text of a control in another application.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window or control containing the text.</para>
	/// </param>
	/// <param name="lpString">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// The buffer that will receive the text. If the string is as long or longer than the buffer, the string is truncated and terminated
	/// with a null character.
	/// </para>
	/// </param>
	/// <param name="nMaxCount">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The maximum number of characters to copy to the buffer, including the null character. If the text exceeds this limit, it is truncated.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>int</c></c></para>
	/// <para>
	/// If the function succeeds, the return value is the length, in characters, of the copied string, not including the terminating null
	/// character. If the window has no title bar or text, if the title bar is empty, or if the window or control handle is invalid, the
	/// return value is zero. To get extended error information, call GetLastError.
	/// </para>
	/// <para>This function cannot retrieve the text of an edit control in another application.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the target window is owned by the current process, <c>GetWindowText</c> causes a WM_GETTEXT message to be sent to the
	/// specified window or control. If the target window is owned by another process and has a caption, <c>GetWindowText</c> retrieves
	/// the window caption text. If the window does not have a caption, the return value is a null string. This behavior is by design. It
	/// allows applications to call <c>GetWindowText</c> without becoming unresponsive if the process that owns the target window is not
	/// responding. However, if the target window is not responding and it belongs to the calling application, <c>GetWindowText</c> will
	/// cause the calling application to become unresponsive.
	/// </para>
	/// <para>To retrieve the text of a control in another process, send a WM_GETTEXT message directly instead of calling <c>GetWindowText</c>.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Sending a Message.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindowtexta int GetWindowTextA( HWND hWnd, LPSTR
	// lpString, int nMaxCount );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "getwindowtext")]
	public static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);

	/// <summary>
	/// <para>
	/// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar). If the specified
	/// window is a control, the function retrieves the length of the text within the control. However, <c>GetWindowTextLength</c> cannot
	/// retrieve the length of the text of an edit control in another application.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window or control.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>int</c></c></para>
	/// <para>
	/// If the function succeeds, the return value is the length, in characters, of the text. Under certain conditions, this value may
	/// actually be greater than the length of the text. For more information, see the following Remarks section.
	/// </para>
	/// <para>If the window has no text, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the target window is owned by the current process, <c>GetWindowTextLength</c> causes a WM_GETTEXTLENGTH message to be sent to
	/// the specified window or control.
	/// </para>
	/// <para>
	/// Under certain conditions, the <c>GetWindowTextLength</c> function may return a value that is larger than the actual length of the
	/// text. This occurs with certain mixtures of ANSI and Unicode, and is due to the system allowing for the possible existence of
	/// double-byte character set (DBCS) characters within the text. The return value, however, will always be at least as large as the
	/// actual length of the text; you can thus always use it to guide buffer allocation. This behavior can occur when an application
	/// uses both ANSI functions and common dialogs, which use Unicode. It can also occur when an application uses the ANSI version of
	/// <c>GetWindowTextLength</c> with a window whose window procedure is Unicode, or the Unicode version of <c>GetWindowTextLength</c>
	/// with a window whose window procedure is ANSI. For more information on ANSI and ANSI functions, see Conventions for Function Prototypes.
	/// </para>
	/// <para>
	/// To obtain the exact length of the text, use the WM_GETTEXT, LB_GETTEXT, or CB_GETLBTEXT messages, or the GetWindowText function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindowtextlengtha int GetWindowTextLengthA( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "getwindowtextlength")]
	public static extern int GetWindowTextLength(HWND hWnd);

	/// <summary>
	/// <para>
	/// Retrieves the identifier of the thread that created the specified window and, optionally, the identifier of the process that
	/// created the window.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window.</para>
	/// </param>
	/// <param name="lpdwProcessId">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// A pointer to a variable that receives the process identifier. If this parameter is not <c>NULL</c>,
	/// <c>GetWindowThreadProcessId</c> copies the identifier of the process to the variable; otherwise, it does not.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>DWORD</c></c></para>
	/// <para>The return value is the identifier of the thread that created the window.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindowthreadprocessid DWORD GetWindowThreadProcessId(
	// HWND hWnd, LPDWORD lpdwProcessId );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getwindowthreadprocessid")]
	public static extern uint GetWindowThreadProcessId(HWND hWnd, out uint lpdwProcessId);

	/// <summary>
	/// Enables a Dynamic Data Exchange (DDE) server application to impersonate a DDE client application's security context. This
	/// protects secure server data from unauthorized DDE clients.
	/// </summary>
	/// <param name="hWndClient">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the DDE client window to be impersonated. The client window must have established a DDE conversation with the server
	/// window identified by the hWndServer parameter.
	/// </para>
	/// </param>
	/// <param name="hWndServer">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the DDE server window. An application must create the server window before calling this function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application should call the RevertToSelf function to undo the impersonation set by the <c>ImpersonateDdeClientWindow</c> function.
	/// </para>
	/// <para>A DDEML application should use the DdeImpersonateClient function.</para>
	/// <para>Security Considerations</para>
	/// <para>
	/// Using this function incorrectly might compromise the security of your program. It is very important to check the return value of
	/// the call. If the function fails for any reason, the client is not impersonated and any subsequent client request is made in the
	/// security context of the calling process. If the calling process is running as a highly privileged account, such as LocalSystem or
	/// as a member of an administrative group, the user may be able to perform actions that would otherwise be disallowed. Therefore, if
	/// the call fails or raises an error do not continue execution of the client request.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dde/nf-dde-impersonateddeclientwindow BOOL ImpersonateDdeClientWindow( HWND
	// hWndClient, HWND hWndServer );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dde.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImpersonateDdeClientWindow(HWND hWndClient, HWND hWndServer);

	/// <summary>
	/// <para>[This function is not intended for general use. It may be altered or unavailable in subsequent versions of Windows.]</para>
	/// <para>Copies the text of the specified window's title bar (if it has one) into a buffer.</para>
	/// <para>
	/// This function is similar to the GetWindowText function. However, it obtains the window text directly from the window structure
	/// associated with the specified window's handle and then always provides the text as a Unicode string. This is unlike
	/// <c>GetWindowText</c> which obtains the text by sending the window a WM_GETTEXT message. If the specified window is a control, the
	/// text of the control is obtained.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window or control containing the text.</para>
	/// </param>
	/// <param name="pString">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>The buffer that is to receive the text.</para>
	/// <para>If the string is as long or longer than the buffer, the string is truncated and terminated with a null character.</para>
	/// </param>
	/// <param name="cchMaxCount">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The maximum number of characters to be copied to the buffer, including the null character. If the text exceeds this limit, it is truncated.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>int</c></c></para>
	/// <para>
	/// If the function succeeds, the return value is the length, in characters, of the copied string, not including the terminating null
	/// character. If the window has no title bar or text, if the title bar is empty, or if the window or control handle is invalid, the
	/// return value is zero. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function was not included in the SDK headers and libraries until Windows XP with Service Pack 1 (SP1) and Windows Server
	/// 2003. If you do not have a header file and import library for this function, you can call the function using LoadLibrary and GetProcAddress.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-internalgetwindowtext int InternalGetWindowText( HWND
	// hWnd, LPWSTR pString, int cchMaxCount );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "internalgetwindowtext")]
	public static extern int InternalGetWindowText(HWND hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pString, int cchMaxCount);

	/// <summary>
	/// <para>
	/// Determines whether a window is a child window or descendant window of a specified parent window. A child window is the direct
	/// descendant of a specified parent window if that parent window is in the chain of parent windows; the chain of parent windows
	/// leads from the original overlapped or pop-up window to the child window.
	/// </para>
	/// </summary>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the parent window.</para>
	/// </param>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to be tested.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the window is a child or descendant window of the specified parent window, the return value is nonzero.</para>
	/// <para>If the window is not a child or descendant window of the specified parent window, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-ischild BOOL IsChild( HWND hWndParent, HWND hWnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "ischild")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsChild(HWND hWndParent, HWND hWnd);

	/// <summary>
	/// <para>Determines whether the calling thread is already a GUI thread. It can also optionally convert the thread to a GUI thread.</para>
	/// </summary>
	/// <param name="bConvert">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If <c>TRUE</c> and the thread is not a GUI thread, convert the thread to a GUI thread.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>The function returns a nonzero value in the following situations:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If the calling thread is already a GUI thread.</term>
	/// </item>
	/// <item>
	/// <term>If bConvert is <c>TRUE</c> and the function successfully converts the thread to a GUI thread.</term>
	/// </item>
	/// </list>
	/// <para>Otherwise, the function returns zero.</para>
	/// <para>
	/// If bConvert is <c>TRUE</c> and the function cannot successfully convert the thread to a GUI thread, <c>IsGUIThread</c> returns <c>ERROR_NOT_ENOUGH_MEMORY</c>.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-isguithread BOOL IsGUIThread( BOOL bConvert );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "isguithread")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsGUIThread([MarshalAs(UnmanagedType.Bool)] bool bConvert);

	/// <summary>
	/// <para>[This function is not intended for general use. It may be altered or unavailable in subsequent versions of Windows.]</para>
	/// <para>
	/// Determines whether the system considers that a specified application is not responding. An application is considered to be not
	/// responding if it is not waiting for input, is not in startup processing, and has not called PeekMessage within the internal
	/// timeout period of 5 seconds.
	/// </para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to be tested.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>
	/// The return value is <c>TRUE</c> if the window stops responding; otherwise, it is <c>FALSE</c>. Ghost windows always return <c>TRUE</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The Windows timeout criteria of 5 seconds is subject to change.</para>
	/// <para>
	/// This function was not included in the SDK headers and libraries until Windows XP Service Pack 1 (SP1) and Windows Server 2003. If
	/// you do not have a header file and import library for this function, you can call the function using LoadLibrary and GetProcAddress.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-ishungappwindow BOOL IsHungAppWindow( HWND hwnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "ishungappwindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsHungAppWindow(HWND hwnd);

	/// <summary>
	/// <para>Determines whether the specified window is minimized (iconic).</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to be tested.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the window is iconic, the return value is nonzero.</para>
	/// <para>If the window is not iconic, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-isiconic BOOL IsIconic( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "isiconic")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsIconic(HWND hWnd);

	/// <summary>
	/// <para>[</para>
	/// <para>
	/// IsProcessDPIAware is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. Instead, use GetProcessDPIAwareness.
	/// </para>
	/// <para>]</para>
	/// <para>
	/// Determines whether the current process is dots per inch (dpi) aware such that it adjusts the sizes of UI elements to compensate
	/// for the dpi setting.
	/// </para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para><c>TRUE</c> if the process is dpi aware; otherwise, <c>FALSE</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-isprocessdpiaware BOOL IsProcessDPIAware( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "isprocessdpiaware")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsProcessDPIAware();

	/// <summary>
	/// <para>Determines whether the specified window handle identifies an existing window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to be tested.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the window handle identifies an existing window, the return value is nonzero.</para>
	/// <para>If the window handle does not identify an existing window, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A thread should not use <c>IsWindow</c> for a window that it did not create because the window could be destroyed after this
	/// function was called. Further, because window handles are recycled the handle could even point to a different window.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Modeless Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-iswindow BOOL IsWindow( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "iswindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsWindow(HWND hWnd);

	/// <summary>Determines whether the specified window is enabled for mouse and keyboard input.</summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to be tested.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the window is enabled, the return value is nonzero.</para>
	/// <para>If the window is not enabled, the return value is zero.</para>
	/// </returns>
	/// <remarks>A child window receives input only if it is both enabled and visible.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-iswindowenabled BOOL IsWindowEnabled( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsWindowEnabled(HWND hWnd);

	/// <summary>
	/// The <c>IsWindowRedirectedForPrint</c> function determines whether the specified window is currently redirected for printing.
	/// </summary>
	/// <param name="hWnd">The h WND.</param>
	/// <returns>
	/// If the window is currently redirected for printing, the function returns a nonzero value; otherwise, it returns zero.
	/// </returns>
	/// <remarks>
	/// <para>
	/// A window is redirected for printing when it processes a call to <c>PrintWindow</c>. In a call to <c>PrintWindow</c>, a window
	/// renders its content to an off-screen device context.
	/// </para>
	/// <para>
	/// This function has no associated import library or header file; you must call it by using the <c>LoadLibrary</c> and
	/// <c>GetProcAddress</c> functions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/printdocs/iswindowredirectedforprint BOOL WINAPI IsWindowRedirectedForPrint( _In_
	// HWND hWnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("", MSDNShortId = "49FD0D63-0F7F-48C6-81B6-25715294E7B7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsWindowRedirectedForPrint([In] HWND hWnd);

	/// <summary>
	/// <para>Determines whether the specified window is a native Unicode window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to be tested.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the window is a native Unicode window, the return value is nonzero.</para>
	/// <para>If the window is not a native Unicode window, the return value is zero. The window is a native ANSI window.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The character set of a window is determined by the use of the RegisterClass function. If the window class was registered with the
	/// ANSI version of <c>RegisterClass</c> ( <c>RegisterClassA</c>), the character set of the window is ANSI. If the window class was
	/// registered with the Unicode version of <c>RegisterClass</c> ( <c>RegisterClassW</c>), the character set of the window is Unicode.
	/// </para>
	/// <para>
	/// The system does automatic two-way translation (Unicode to ANSI) for window messages. For example, if an ANSI window message is
	/// sent to a window that uses the Unicode character set, the system translates that message into a Unicode message before calling
	/// the window procedure. The system calls <c>IsWindowUnicode</c> to determine whether to translate the message.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-iswindowunicode BOOL IsWindowUnicode( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "iswindowunicode")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsWindowUnicode(HWND hWnd);

	/// <summary>
	/// <para>Determines the visibility state of the specified window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to be tested.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>
	/// If the specified window, its parent window, its parent's parent window, and so forth, have the <c>WS_VISIBLE</c> style, the
	/// return value is nonzero. Otherwise, the return value is zero.
	/// </para>
	/// <para>
	/// Because the return value specifies whether the window has the <c>WS_VISIBLE</c> style, it may be nonzero even if the window is
	/// totally obscured by other windows.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The visibility state of a window is indicated by the <c>WS_VISIBLE</c> style bit. When <c>WS_VISIBLE</c> is set, the window is
	/// displayed and subsequent drawing into it is displayed as long as the window has the <c>WS_VISIBLE</c> style.
	/// </para>
	/// <para>
	/// Any drawing to a window with the <c>WS_VISIBLE</c> style will not be displayed if the window is obscured by other windows or is
	/// clipped by its parent window.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-iswindowvisible BOOL IsWindowVisible( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "iswindowvisible")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsWindowVisible(HWND hWnd);

	/// <summary>
	/// <para>Determines whether a window is maximized.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to be tested.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the window is zoomed, the return value is nonzero.</para>
	/// <para>If the window is not zoomed, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-iszoomed BOOL IsZoomed( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "iszoomed")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsZoomed(HWND hWnd);

	/// <summary>
	/// The foreground process can call the <c>LockSetForegroundWindow</c> function to disable calls to the SetForegroundWindow function.
	/// </summary>
	/// <param name="uLockCode">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Specifies whether to enable or disable calls to SetForegroundWindow. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LSFW_LOCK 1</term>
	/// <term>Disables calls to SetForegroundWindow.</term>
	/// </item>
	/// <item>
	/// <term>LSFW_UNLOCK 2</term>
	/// <term>Enables calls to SetForegroundWindow.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The system automatically enables calls to SetForegroundWindow if the user presses the ALT key or takes some action that causes
	/// the system itself to change the foreground window (for example, clicking a background window).
	/// </para>
	/// <para>
	/// This function is provided so applications can prevent other applications from making a foreground change that can interrupt its
	/// interaction with the user.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-locksetforegroundwindow
	// BOOL LockSetForegroundWindow( UINT uLockCode );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LockSetForegroundWindow(LSFW uLockCode);

	/// <summary>
	/// <para>Converts the logical coordinates of a point in a window to physical coordinates.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the window whose transform is used for the conversion. Top level windows are fully supported. In the case of child
	/// windows, only the area of overlap between the parent and the child window is converted.
	/// </para>
	/// </param>
	/// <param name="lpPoint">
	/// <para>Type: <c>LPPOINT</c></para>
	/// <para>
	/// A pointer to a POINT structure that specifies the logical coordinates to be converted. The new physical coordinates are copied
	/// into this structure if the function succeeds.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>None</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Windows Vista introduces the concept of physical coordinates. Desktop Window Manager (DWM) scales non-dots per inch (dpi) aware
	/// windows when the display is high dpi. The window seen on the screen corresponds to the physical coordinates. The application
	/// continues to work in logical space. Therefore, the application's view of the window is different from that which appears on the
	/// screen. For scaled windows, logical and physical coordinates are different.
	/// </para>
	/// <para>
	/// <c>LogicalToPhysicalPoint</c> is a transformation API that can be called by a process that declares itself as dpi aware. The
	/// function uses the window identified by the hWnd parameter and the logical coordinates given in the POINT structure to compute the
	/// physical coordinates.
	/// </para>
	/// <para>
	/// The <c>LogicalToPhysicalPoint</c> function replaces the logical coordinates in the POINT structure with the physical coordinates.
	/// The physical coordinates are relative to the upper-left corner of the screen. The coordinates have to be inside the client area
	/// of hWnd.
	/// </para>
	/// <para>
	/// On all platforms, <c>LogicalToPhysicalPoint</c> will fail on a window that has either 0 width or height; an application must
	/// first establish a non-0 width and height by calling, for example, MoveWindow. On some versions of Windows (including Windows 7),
	/// <c>LogicalToPhysicalPoint</c> will still fail if <c>MoveWindow</c> has been called after a call to ShowWindow with <c>SH_HIDE</c>
	/// has hidden the window.
	/// </para>
	/// <para>
	/// In Windows 8, system–DPI aware applications translate between physical and logical space using PhysicalToLogicalPoint and
	/// LogicalToPhysicalPoint. In Windows 8.1, the additional virtualization of the system and inter-process communications means that
	/// for the majority of applications, you do not need these APIs. As a result, in Windows 8.1, PhysicalToLogicalPoint and
	/// LogicalToPhysicalPoint no longer transform points. The system returns all points to an application in its own coordinate space.
	/// This behavior preserves functionality for the majority of applications, but there are some exceptions in which you must make
	/// changes to ensure that the application works as expected. In those cases, use PhysicalToLogicalPointForPerMonitorDPI and LogicalToPhysicalPointForPerMonitorDPI.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-logicaltophysicalpoint BOOL LogicalToPhysicalPoint( HWND
	// hWnd, LPPOINT lpPoint );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "logicaltophysicalpoint")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LogicalToPhysicalPoint(HWND hWnd, ref POINT lpPoint);

	/// <summary>
	/// <para>
	/// Changes the position and dimensions of the specified window. For a top-level window, the position and dimensions are relative to
	/// the upper-left corner of the screen. For a child window, they are relative to the upper-left corner of the parent window's client area.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window.</para>
	/// </param>
	/// <param name="X">
	/// <para>Type: <c>int</c></para>
	/// <para>The new position of the left side of the window.</para>
	/// </param>
	/// <param name="Y">
	/// <para>Type: <c>int</c></para>
	/// <para>The new position of the top of the window.</para>
	/// </param>
	/// <param name="nWidth">
	/// <para>Type: <c>int</c></para>
	/// <para>The new width of the window.</para>
	/// </param>
	/// <param name="nHeight">
	/// <para>Type: <c>int</c></para>
	/// <para>The new height of the window.</para>
	/// </param>
	/// <param name="bRepaint">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// Indicates whether the window is to be repainted. If this parameter is <c>TRUE</c>, the window receives a message. If the
	/// parameter is <c>FALSE</c>, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the
	/// title bar and scroll bars), and any part of the parent window uncovered as a result of moving a child window.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the bRepaint parameter is <c>TRUE</c>, the system sends the WM_PAINT message to the window procedure immediately after moving
	/// the window (that is, the <c>MoveWindow</c> function calls the UpdateWindow function). If bRepaint is <c>FALSE</c>, the
	/// application must explicitly invalidate or redraw any parts of the window and parent window that need redrawing.
	/// </para>
	/// <para>
	/// <c>MoveWindow</c> sends the WM_WINDOWPOSCHANGING, WM_WINDOWPOSCHANGED, WM_MOVE, WM_SIZE, and WM_NCCALCSIZE messages to the window.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating, Enumerating, and Sizing Child Windows.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-movewindow BOOL MoveWindow( HWND hWnd, int X, int Y, int
	// nWidth, int nHeight, BOOL bRepaint );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "movewindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool MoveWindow(HWND hWnd, int X, int Y, int nWidth, int nHeight, [MarshalAs(UnmanagedType.Bool)] bool bRepaint);

	/// <summary>
	/// Signals the system that a predefined event occurred. If any client applications have registered a hook function for the event,
	/// the system calls the client's hook function.
	/// </summary>
	/// <param name="winEvent">The win event.</param>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the window that contains the object that generated the event.</para>
	/// </param>
	/// <param name="idObject">
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// Identifies the object that generated the event. This value is either one of the predefined object identifiers or a custom object
	/// ID value.
	/// </para>
	/// </param>
	/// <param name="idChild">
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// Identifies whether the event was generated by an object or by a child element of the object. If this value is CHILDID_SELF, the
	/// event was generated by the object itself. If not CHILDID_SELF, this value is the child ID of the element that generated the event.
	/// </para>
	/// </param>
	/// <remarks>
	/// <para>
	/// Servers call this function to notify the system that an event has occurred. Microsoft Active Accessibility checks to see if any
	/// client applications have set hook procedures for the event and, if so, calls the appropriate hook procedures.
	/// </para>
	/// <para>If no hook procedures are registered for the event, the performance penalty for calling this function is minor.</para>
	/// <para>
	/// Servers call <c>NotifyWinEvent</c> to announce the event to the system after the event has occurred; they must never notify the
	/// system of an event before the event has occurred.
	/// </para>
	/// <para>
	/// When the client's hook procedure is called, it receives a number of parameters that describe the event and the object that
	/// generated the event. The hook procedure uses the AccessibleObjectFromEvent function to retrieve a pointer to the IAccessible
	/// interface of the object that generated the event.
	/// </para>
	/// <para>
	/// Servers may receive a WM_GETOBJECT message immediately after calling this function. This can happen if there are any in-context
	/// clients that call AccessibleObjectFromEvent in the event callback.
	/// </para>
	/// <para>
	/// When servers call this function, they must be ready to handle WM_GETOBJECT, return an IAccessible interface pointer, and handle
	/// any of the <c>IAccessible</c> methods.
	/// </para>
	/// <para>
	/// <c>Note to Server Developers:</c> When you call <c>NotifyWinEvent</c>, if any clients are listening for that event in-context,
	/// their event handlers, which typically send WM_GETOBJECT and call IAccessible methods, will execute before <c>NotifyWinEvent</c>
	/// returns. When you call <c>NotifyWinEvent</c>, you should be prepared to handle these calls, if they occur. If you need to do
	/// extra setup to allow for this, you should do so before you call <c>NotifyWinEvent</c>, not after.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-notifywinevent void NotifyWinEvent( DWORD event, HWND
	// hwnd, LONG idObject, LONG idChild );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "08e74d45-95b6-44c2-a2e0-5ba6ffdcd56a")]
	public static extern void NotifyWinEvent(uint winEvent, HWND hwnd, int idObject, int idChild);

	/// <summary>
	/// <para>Restores a minimized (iconic) window to its previous size and position; it then activates the window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to be restored and activated.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para><c>OpenIcon</c> sends a WM_QUERYOPEN message to the given window.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-openicon BOOL OpenIcon( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "openicon")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OpenIcon(HWND hWnd);

	/// <summary>
	/// <para>Converts the physical coordinates of a point in a window to logical coordinates.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the window whose transform is used for the conversion. Top level windows are fully supported. In the case of child
	/// windows, only the area of overlap between the parent and the child window is converted.
	/// </para>
	/// </param>
	/// <param name="lpPoint">
	/// <para>Type: <c>LPPOINT</c></para>
	/// <para>
	/// A pointer to a POINT structure that specifies the physical/screen coordinates to be converted. The new logical coordinates are
	/// copied into this structure if the function succeeds.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>None</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Windows Vista introduces the concept of physical coordinates. Desktop Window Manager (DWM) scales non-dots per inch (dpi) aware
	/// windows when the display is high dpi. The window seen on the screen corresponds to the physical coordinates. The application
	/// continues to work in logical space. Therefore, the application's view of the window is different from that which appears on the
	/// screen. For scaled windows, logical and physical coordinates are different.
	/// </para>
	/// <para>
	/// The function uses the window identified by the hWnd parameter and the physical coordinates given in the POINT structure to
	/// compute the logical coordinates. The logical coordinates are the unscaled coordinates that appear to the application in a
	/// programmatic way. In other words, the logical coordinates are the coordinates the application recognizes, which can be different
	/// from the physical coordinates. The API then replaces the physical coordinates with the logical coordinates. The new coordinates
	/// are in the world coordinates whose origin is (0, 0) on the desktop. The coordinates passed to the API have to be on the hWnd.
	/// </para>
	/// <para>The source coordinates are in device units.</para>
	/// <para>
	/// On all platforms, <c>PhysicalToLogicalPoint</c> will fail on a window that has either 0 width or height; an application must
	/// first establish a non-0 width and height by calling, for example, MoveWindow. On some versions of Windows (including Windows 7),
	/// <c>PhysicalToLogicalPoint</c> will still fail if <c>MoveWindow</c> has been called after a call to ShowWindow with <c>SH_HIDE</c>
	/// has hidden the window.
	/// </para>
	/// <para>
	/// In Windows 8, system–DPI aware applications translate between physical and logical space using PhysicalToLogicalPoint and
	/// LogicalToPhysicalPoint. In Windows 8.1, the additional virtualization of the system and inter-process communications means that
	/// for the majority of applications, you do not need these APIs. As a result, in Windows 8.1, PhysicalToLogicalPoint and
	/// LogicalToPhysicalPoint no longer transform points. The system returns all points to an application in its own coordinate space.
	/// This behavior preserves functionality for the majority of applications, but there are some exceptions in which you must make
	/// changes to ensure that the application works as expected. In those cases, use PhysicalToLogicalPointForPerMonitorDPI and LogicalToPhysicalPointForPerMonitorDPI.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-physicaltologicalpoint BOOL PhysicalToLogicalPoint( HWND
	// hWnd, LPPOINT lpPoint );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "physicaltologicalpoint")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PhysicalToLogicalPoint(HWND hWnd, ref POINT lpPoint);

	/// <summary>
	/// The <c>PrintWindow</c> function copies a visual window into the specified device context (DC), typically a printer DC.
	/// </summary>
	/// <param name="hwnd">A handle to the window that will be copied.</param>
	/// <param name="hdcBlt">A handle to the device context.</param>
	/// <param name="nFlags">
	/// <para>The drawing options. It can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PW_CLIENTONLY</term>
	/// <term>Only the client area of the window is copied to hdcBlt. By default, the entire window is copied.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns a nonzero value.</para>
	/// <para>If the function fails, it returns zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
	/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
	/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </para>
	/// <para>
	/// The application that owns the window referenced by hWnd processes the <c>PrintWindow</c> call and renders the image in the device
	/// context that is referenced by hdcBlt. The application receives a WM_PRINT message or, if the <c>PW_PRINTCLIENT</c> flag is
	/// specified, a WM_PRINTCLIENT message. For more information, see <c>WM_PRINT</c> and <c>WM_PRINTCLIENT</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-printwindow BOOL PrintWindow( HWND hwnd, HDC hdcBlt, UINT
	// nFlags );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "00b38cd8-1cfb-408e-88da-6e61563d9d8e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PrintWindow(HWND hwnd, HDC hdcBlt, PW nFlags);

	/// <summary>
	/// <para>
	/// Retrieves a handle to the child window at the specified point. The search is restricted to immediate child windows; grandchildren
	/// and deeper descendant windows are not searched.
	/// </para>
	/// </summary>
	/// <param name="hwndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window whose child is to be retrieved.</para>
	/// </param>
	/// <param name="ptParentClientCoords">
	/// <para>Type: <c>POINT</c></para>
	/// <para>A POINT structure that defines the client coordinates of the point to be checked.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>The return value is a handle to the child window that contains the specified point.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>RealChildWindowFromPoint</c> treats <c>HTTRANSPARENT</c> areas of a standard control differently from other areas of the
	/// control; it returns the child window behind a transparent part of a control. In contrast, ChildWindowFromPoint treats
	/// <c>HTTRANSPARENT</c> areas of a control the same as other areas. For example, if the point is in a transparent area of a
	/// groupbox, <c>RealChildWindowFromPoint</c> returns the child window behind a groupbox, whereas <c>ChildWindowFromPoint</c> returns
	/// the groupbox. However, both APIs return a static field, even though it, too, returns <c>HTTRANSPARENT</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-realchildwindowfrompoint HWND RealChildWindowFromPoint(
	// HWND hwndParent, POINT ptParentClientCoords );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "realchildwindowfrompoint")]
	public static extern HWND RealChildWindowFromPoint(HWND hwndParent, POINT ptParentClientCoords);

	/// <summary>
	/// <para>Retrieves a string that specifies the window type.</para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window whose type will be retrieved.</para>
	/// </param>
	/// <param name="ptszClassName">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>A pointer to a string that receives the window type.</para>
	/// </param>
	/// <param name="cchClassNameMax">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The length, in characters, of the buffer pointed to by the pszType parameter.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>UINT</c></c></para>
	/// <para>If the function succeeds, the return value is the number of characters copied to the specified buffer.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-realgetwindowclassw UINT RealGetWindowClassW( HWND hwnd,
	// LPWSTR ptszClassName, UINT cchClassNameMax );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "realgetwindowclass")]
	public static extern uint RealGetWindowClass(HWND hwnd, StringBuilder ptszClassName, uint cchClassNameMax);

	/// <summary>
	/// <para>Registers a window class for subsequent use in calls to the CreateWindow or CreateWindowEx function.</para>
	/// <para>
	/// <c>Note</c> The <c>RegisterClass</c> function has been superseded by the RegisterClassEx function. You can still use
	/// <c>RegisterClass</c>, however, if you do not need to set the class small icon.
	/// </para>
	/// </summary>
	/// <param name="lpWndClass">
	/// <para>Type: <c>const WNDCLASS*</c></para>
	/// <para>
	/// A pointer to a WNDCLASS structure. You must fill the structure with the appropriate class attributes before passing it to the function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>ATOM</c></c></para>
	/// <para>
	/// If the function succeeds, the return value is a class atom that uniquely identifies the class being registered. This atom can
	/// only be used by the CreateWindow, CreateWindowEx, GetClassInfo, GetClassInfoEx, FindWindow, FindWindowEx, and UnregisterClass
	/// functions and the <c>IActiveIMMap::FilterClientWindows</c> method.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If you register the window class by using <c>RegisterClassA</c>, the application tells the system that the windows of the created
	/// class expect messages with text or character parameters to use the ANSI character set; if you register it by using
	/// <c>RegisterClassW</c>, the application requests that the system pass text parameters of messages as Unicode. The IsWindowUnicode
	/// function enables applications to query the nature of each window. For more information on ANSI and Unicode functions, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// <para>All window classes that an application registers are unregistered when it terminates.</para>
	/// <para>
	/// No window classes registered by a DLL are unregistered when the DLL is unloaded. A DLL must explicitly unregister its classes
	/// when it is unloaded.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Associating a Window Procedure with a Window Class.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registerclassa ATOM RegisterClassA( const WNDCLASSA
	// *lpWndClass );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern Kernel32.ATOM RegisterClass(in WNDCLASS lpWndClass);

	/// <summary>Registers a window class for subsequent use in calls to the CreateWindow or CreateWindowEx function.</summary>
	/// <param name="Arg1">
	/// <para>Type: <c>const WNDCLASSEX*</c></para>
	/// <para>
	/// A pointer to a WNDCLASSEX structure. You must fill the structure with the appropriate class attributes before passing it to the function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>ATOM</c></c></para>
	/// <para>
	/// If the function succeeds, the return value is a class atom that uniquely identifies the class being registered. This atom can
	/// only be used by the CreateWindow, CreateWindowEx, GetClassInfo, GetClassInfoEx, FindWindow, FindWindowEx, and UnregisterClass
	/// functions and the <c>IActiveIMMap::FilterClientWindows</c> method.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If you register the window class by using <c>RegisterClassExA</c>, the application tells the system that the windows of the
	/// created class expect messages with text or character parameters to use the ANSI character set; if you register it by using
	/// <c>RegisterClassExW</c>, the application requests that the system pass text parameters of messages as Unicode. The
	/// IsWindowUnicode function enables applications to query the nature of each window. For more information on ANSI and Unicode
	/// functions, see Conventions for Function Prototypes.
	/// </para>
	/// <para>All window classes that an application registers are unregistered when it terminates.</para>
	/// <para>
	/// No window classes registered by a DLL are unregistered when the DLL is unloaded. A DLL must explicitly unregister its classes
	/// when it is unloaded.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Using Window Classes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registerclassexa ATOM RegisterClassExA( const WNDCLASSEXA
	// *Arg1 );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern Kernel32.ATOM RegisterClassEx(in WNDCLASSEX Arg1);

	/// <summary>
	/// <para>[This function is not intended for general use. It may be altered or unavailable in subsequent versions of Windows.]</para>
	/// <para>Registers a specified Shell window to receive certain messages for events or notifications that are useful to Shell applications.</para>
	/// <para>
	/// The event messages received are only those sent to the Shell window associated with the specified window's desktop. Many of the
	/// messages are the same as those that can be received after calling the SetWindowsHookEx function and specifying <c>WH_SHELL</c>
	/// for the hook type. The difference with <c>RegisterShellHookWindow</c> is that the messages are received through the specified
	/// window's WindowProc and not through a call back procedure.
	/// </para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window to register for Shell hook messages.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para><c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// As with normal window messages, the second parameter of the window procedure identifies the message as a
	/// <c>WM_SHELLHOOKMESSAGE</c>. However, for these Shell hook messages, the message value is not a pre-defined constant like other
	/// message IDs such as WM_COMMAND. The value must be obtained dynamically using a call to RegisterWindowMessage as shown here:
	/// </para>
	/// <para>
	/// This precludes handling these messages using a traditional switch statement which requires ID values that are known at compile
	/// time. For handling Shell hook messages, the normal practice is to code an If statement in the default section of your switch
	/// statement and then handle the message if the value of the message ID is the same as the value obtained from the
	/// RegisterWindowMessage call.
	/// </para>
	/// <para>
	/// The following table describes the wParam and lParam parameter values passed to the window procedure for the Shell hook messages.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>wParam</term>
	/// <term>lParam</term>
	/// </listheader>
	/// <item>
	/// <term>HSHELL_GETMINRECT</term>
	/// <term>A pointer to a SHELLHOOKINFO structure.</term>
	/// </item>
	/// <item>
	/// <term>HSHELL_WINDOWACTIVATED</term>
	/// <term>A handle to the activated window.</term>
	/// </item>
	/// <item>
	/// <term>HSHELL_RUDEAPPACTIVATED</term>
	/// <term>A handle to the activated window.</term>
	/// </item>
	/// <item>
	/// <term>HSHELL_WINDOWREPLACING</term>
	/// <term>A handle to the window replacing the top-level window.</term>
	/// </item>
	/// <item>
	/// <term>HSHELL_WINDOWREPLACED</term>
	/// <term>A handle to the window being replaced.</term>
	/// </item>
	/// <item>
	/// <term>HSHELL_WINDOWCREATED</term>
	/// <term>A handle to the window being created.</term>
	/// </item>
	/// <item>
	/// <term>HSHELL_WINDOWDESTROYED</term>
	/// <term>A handle to the top-level window being destroyed.</term>
	/// </item>
	/// <item>
	/// <term>HSHELL_ACTIVATESHELLWINDOW</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>HSHELL_TASKMAN</term>
	/// <term>Can be ignored.</term>
	/// </item>
	/// <item>
	/// <term>HSHELL_REDRAW</term>
	/// <term>A handle to the window that needs to be redrawn.</term>
	/// </item>
	/// <item>
	/// <term>HSHELL_FLASH</term>
	/// <term>A handle to the window that needs to be flashed.</term>
	/// </item>
	/// <item>
	/// <term>HSHELL_ENDTASK</term>
	/// <term>A handle to the window that should be forced to exit.</term>
	/// </item>
	/// <item>
	/// <term>HSHELL_APPCOMMAND</term>
	/// <term>
	/// The APPCOMMAND which has been unhandled by the application or other hooks. See WM_APPCOMMAND and use the GET_APPCOMMAND_LPARAM
	/// macro to retrieve this parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HSHELL_MONITORCHANGED</term>
	/// <term>A handle to the window that moved to a different monitor.</term>
	/// </item>
	/// </list>
	/// <para>
	/// This function was not included in the SDK headers and libraries until Windows XP with Service Pack 1 (SP1) and Windows Server
	/// 2003. If you do not have a header file and import library for this function, you can call the function using LoadLibrary and GetProcAddress.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registershellhookwindow BOOL RegisterShellHookWindow( HWND
	// hwnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "registershellhookwindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RegisterShellHookWindow(HWND hwnd);

	/// <summary>
	/// Releases the mouse capture from a window in the current thread and restores normal mouse input processing. A window that has
	/// captured the mouse receives all mouse input, regardless of the position of the cursor, except when a mouse button is clicked
	/// while the cursor hot spot is in the window of another thread.
	/// </summary>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>An application calls this function after calling the SetCapture function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Drawing Lines with the Mouse.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-releasecapture BOOL ReleaseCapture( );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReleaseCapture();

	/// <summary>Activates a window. The window must be attached to the calling thread's message queue.</summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the top-level window to be activated.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>If the function succeeds, the return value is the handle to the window that was previously active.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SetActiveWindow</c> function activates a window, but not if the application is in the background. The window will be
	/// brought into the foreground (top of Z-Order) if its application is in the foreground when the system activates the window.
	/// </para>
	/// <para>
	/// If the window identified by the hWnd parameter was created by the calling thread, the active window status of the calling thread
	/// is set to hWnd. Otherwise, the active window status of the calling thread is set to <c>NULL</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setactivewindow HWND SetActiveWindow( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern HWND SetActiveWindow(HWND hWnd);

	/// <summary>
	/// <note type="warning"><c>SetAdditionalForegroundBoostProcesses</c> is a <c>limited access feature</c>. Contact
	/// foregroundboostprocs@microsoft.com for more information.</note>
	/// <para>
	/// SetAdditionalForegroundBoostProcesses is a performance assist API to help applications with a multi-process application model
	/// where multiple processes contribute to a foreground experience, either as data or rendering. Examples include browsers (with the
	/// browser manager or frame, tabs, plugins, etc. hosted in different processes) and IDEs (which spawn processes for compilation and
	/// other tasks).
	/// </para>
	/// <para>
	/// Applications can use this API to provide a foreground priority boost to worker processes that help support the main application.
	/// Such applications can have a uniform priority boost applied to all of their constituent processes when the application's top
	/// level window is in the foreground.
	/// </para>
	/// </summary>
	/// <param name="topLevelWindow">A handle to the top level window (HWND) of the application.</param>
	/// <param name="processHandleCount">
	/// The number of process handles in <c>processHandleArray</c>. This function can be called at a single time with a maximum of 32
	/// handles. Set this parameter to <c>0</c> along with setting <c>processHandleArray</c> to <c>NULL</c> to clear a prior boost configuration.
	/// </param>
	/// <param name="processHandleArray">
	/// A group of process handles to be foreground boosted or de-boosted. Set this parameter to <c>NULL</c> along with setting
	/// <c>processHandleCount</c> to <c>0</c> to clear a prior boost configuration.
	/// </param>
	/// <returns>
	/// Returns <c>TRUE</c> if the call succeeds in boosting the application, <c>FALSE</c> otherwise.
	/// <c>SetAdditionalForegroundBoostProcesses</c> sets the last error code, so the application can call GetLastError() to obtain
	/// extended information if the call failed (for example, ERROR_INVALID_PARAMETER, ERROR_NOT_ENOUGH_MEMORY, or ERROR_ACCESS_DENIED).
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function takes a group of process handles that all get foreground boosted or de-boosted when the passed-in top level HWND
	/// moves to the foreground or background respectively. Whenever the passed-in top level HWND becomes the foreground window, a
	/// foreground boost will also be applied to the processes passed in the handle array. A similar de-boost happens when the top level
	/// HWND moves to the background.
	/// </para>
	/// <para>
	/// The top level HWND passed to this function must be owned by the calling process. The calling process should have the
	/// <c>PROCESS_SET_INFORMATION</c> access right on the process handles in the <c>processHandleArray</c> - in other words, you must
	/// have full control of every window in your process. If some external component injects a window that takes foreground, or if a
	/// dialog box appears, then you lose your boost.
	/// </para>
	/// <para>If you have two top level windows, you need to call this function for each one.</para>
	/// <para>
	/// If the passed-in top level HWND is already in the foreground when <c>SetAdditionalForegroundBoostProcesses</c> is called, all of
	/// the processes in the <c>processHandleArray</c> are immediately boosted.
	/// </para>
	/// <para>
	/// A process whose handle is in the <c>processHandleArray</c> will get a foreground boost only when the top level HWND becomes the
	/// foreground window.
	/// </para>
	/// <para>Additional foreground boost is applied only when:</para>
	/// <list type="number">
	/// <item>
	/// <term>The foreground window changes, or</term>
	/// </item>
	/// <item>
	/// <term>
	/// If this function is called while the window is in the foreground and the new list has the process handle, or the list does not
	/// include the process handle while it was previously included.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// When the process owning the top level HWND exits or terminates, the additional boosting relationship is torn down and secondary
	/// processes do not receive any additional foreground boosting.
	/// </para>
	/// <para>
	/// The primary process's top level HWND will continue to hold references to secondary processes until either the primary process's
	/// top level HWND clears its grouped boost state, or the HWND is destroyed.
	/// </para>
	/// </remarks>
	/// <example>
	/// <para>
	/// In this simple scenario, the application sets up its foreground process boost configuration when the top level window is created.
	/// When WM_CREATE is handled, the function is called with handles in the lParam and the count of handles in the wParam. These
	/// processes will get foreground or background priority boosted as m_AppWindow moves in and out of being the foreground window. If
	/// the m_AppWindow is the foreground window when the function is called, the processes will also get an immediate foreground
	/// priority boost.
	/// </para>
	/// <code language="cpp"><![CDATA[case WM_CREATE:   
	///
	///	  // 
	///	  // Configure the passed in worker processes (handles) in lParam, to get foreground priority boost when m_AppWindow moves in and 
	///	  // out of the foreground. 
	///	  //  
	///	  
	///	  HANDLE* pMyHandles = retinterpret_cast<HANDLE*>(lParam);
	///	  DWORD cHandles = reinterpret_cast<DWORD>(wParam);
	///	  
	///	  if (!SetAdditionalForegroundBoostProcesses(m_AppWindow, cHandles, pMyHandles))
	///	  {
	///	  	printf(“SetAdditionalForegroundBoostProcesses() setup failed with error code: % d\n”, GetLastError());
	///	  } 
	///	  
	///   break;]]></code>
	/// </example>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setadditionalforegroundboostprocesses
	// BOOL SetAdditionalForegroundBoostProcesses( HWND topLevelWindow, DWORD processHandleCount, HANDLE *processHandleArray );
	[PInvokeData("Winuser.h", MSDNShortId = "NF:winuser.SetAdditionalForegroundBoostProcesses", MinClient = PInvokeClient.Windows11)]
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetAdditionalForegroundBoostProcesses(HWND topLevelWindow, uint processHandleCount,
		[Optional, In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] HPROCESS[]? processHandleArray);

	/// <summary>
	/// <para>
	/// Sets the mouse capture to the specified window belonging to the current thread. <c>SetCapture</c> captures mouse input either
	/// when the mouse is over the capturing window, or when the mouse button was pressed while the mouse was over the capturing window
	/// and the button is still down. Only one window at a time can capture the mouse.
	/// </para>
	/// <para>
	/// If the mouse cursor is over a window created by another thread, the system will direct mouse input to the specified window only
	/// if a mouse button is down.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window in the current thread that is to capture the mouse.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// The return value is a handle to the window that had previously captured the mouse. If there is no such window, the return value
	/// is <c>NULL</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only the foreground window can capture the mouse. When a background window attempts to do so, the window receives messages only
	/// for mouse events that occur when the cursor hot spot is within the visible portion of the window. Also, even if the foreground
	/// window has captured the mouse, the user can still click another window, bringing it to the foreground.
	/// </para>
	/// <para>
	/// When the window no longer requires all mouse input, the thread that created the window should call the ReleaseCapture function to
	/// release the mouse.
	/// </para>
	/// <para>This function cannot be used to capture mouse input meant for another process.</para>
	/// <para>When the mouse is captured, menu hotkeys and other keyboard accelerators do not work.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Drawing Lines with the Mouse.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setcapture HWND SetCapture( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern HWND SetCapture(HWND hWnd);

	/// <summary>
	/// Replaces the specified value at the specified offset in the extra class memory or the WNDCLASSEX structure for the class to which
	/// the specified window belongs.
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window and, indirectly, the class to which the window belongs.</para>
	/// </param>
	/// <param name="nIndex">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The value to be replaced. To set a value in the extra class memory, specify the positive, zero-based byte offset of the value to
	/// be set. Valid values are in the range zero through the number of bytes of extra class memory, minus eight; for example, if you
	/// specified 24 or more bytes of extra class memory, a value of 16 would be an index to the third integer. To set a value other than
	/// the WNDCLASSEX structure, specify one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GCL_CBCLSEXTRA -20</term>
	/// <term>
	/// Sets the size, in bytes, of the extra memory associated with the class. Setting this value does not change the number of extra
	/// bytes already allocated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCL_CBWNDEXTRA -18</term>
	/// <term>
	/// Sets the size, in bytes, of the extra window memory associated with each window in the class. Setting this value does not change
	/// the number of extra bytes already allocated. For information on how to access this memory, see SetWindowLongPtr.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCLP_ HBRBACKGROUND -10</term>
	/// <term>Replaces a handle to the background brush associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HCURSOR -12</term>
	/// <term>Replaces a handle to the cursor associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HICON -14</term>
	/// <term>Replaces a handle to the icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HICONSM -34</term>
	/// <term>Retrieves a handle to the small icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HMODULE -16</term>
	/// <term>Replaces a handle to the module that registered the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_MENUNAME -8</term>
	/// <term>Replaces the pointer to the menu name string. The string identifies the menu resource associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_STYLE -26</term>
	/// <term>Replaces the window-class style bits.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_WNDPROC -24</term>
	/// <term>Replaces the pointer to the window procedure associated with the class.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwNewLong">
	/// <para>Type: <c>LONG_PTR</c></para>
	/// <para>The replacement value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>ULONG_PTR</c></c></para>
	/// <para>
	/// If the function succeeds, the return value is the previous value of the specified offset. If this was not previously set, the
	/// return value is zero.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If you use the <c>SetClassLongPtr</c> function and the <c>GCLP_WNDPROC</c> index to replace the window procedure, the window
	/// procedure must conform to the guidelines specified in the description of the WindowProc callback function.
	/// </para>
	/// <para>
	/// Calling <c>SetClassLongPtr</c> with the <c>GCLP_WNDPROC</c> index creates a subclass of the window class that affects all windows
	/// subsequently created with the class. An application can subclass a system class, but should not subclass a window class created
	/// by another process.
	/// </para>
	/// <para>
	/// Reserve extra class memory by specifying a nonzero value in the <c>cbClsExtra</c> member of the WNDCLASSEX structure used with
	/// the RegisterClassEx function.
	/// </para>
	/// <para>
	/// Use the <c>SetClassLongPtr</c> function with care. For example, it is possible to change the background color for a class by
	/// using <c>SetClassLongPtr</c>, but this change does not immediately repaint all windows belonging to the class.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setclasslongptra ULONG_PTR SetClassLongPtrA( HWND hWnd,
	// int nIndex, LONG_PTR dwNewLong );
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static IntPtr SetClassLong(HWND hWnd, int nIndex, IntPtr dwNewLong) => IntPtr.Size > 4 ? SetClassLongPtr(hWnd, nIndex, dwNewLong) : (IntPtr)SetClassLong32(hWnd, nIndex, dwNewLong.ToInt32());

	/// <summary>
	/// Replaces the specified value at the specified offset in the extra class memory or the WNDCLASSEX structure for the class to which
	/// the specified window belongs.
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window and, indirectly, the class to which the window belongs.</para>
	/// </param>
	/// <param name="nIndex">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The value to be replaced. To set a value in the extra class memory, specify the positive, zero-based byte offset of the value to
	/// be set. Valid values are in the range zero through the number of bytes of extra class memory, minus eight; for example, if you
	/// specified 24 or more bytes of extra class memory, a value of 16 would be an index to the third integer. To set a value other than
	/// the WNDCLASSEX structure, specify one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GCL_CBCLSEXTRA -20</term>
	/// <term>
	/// Sets the size, in bytes, of the extra memory associated with the class. Setting this value does not change the number of extra
	/// bytes already allocated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCL_CBWNDEXTRA -18</term>
	/// <term>
	/// Sets the size, in bytes, of the extra window memory associated with each window in the class. Setting this value does not change
	/// the number of extra bytes already allocated. For information on how to access this memory, see SetWindowLongPtr.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCLP_ HBRBACKGROUND -10</term>
	/// <term>Replaces a handle to the background brush associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HCURSOR -12</term>
	/// <term>Replaces a handle to the cursor associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HICON -14</term>
	/// <term>Replaces a handle to the icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HICONSM -34</term>
	/// <term>Retrieves a handle to the small icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HMODULE -16</term>
	/// <term>Replaces a handle to the module that registered the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_MENUNAME -8</term>
	/// <term>Replaces the pointer to the menu name string. The string identifies the menu resource associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_STYLE -26</term>
	/// <term>Replaces the window-class style bits.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_WNDPROC -24</term>
	/// <term>Replaces the pointer to the window procedure associated with the class.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwNewLong">
	/// <para>Type: <c>LONG_PTR</c></para>
	/// <para>The replacement value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>ULONG_PTR</c></c></para>
	/// <para>
	/// If the function succeeds, the return value is the previous value of the specified offset. If this was not previously set, the
	/// return value is zero.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If you use the <c>SetClassLongPtr</c> function and the <c>GCLP_WNDPROC</c> index to replace the window procedure, the window
	/// procedure must conform to the guidelines specified in the description of the WindowProc callback function.
	/// </para>
	/// <para>
	/// Calling <c>SetClassLongPtr</c> with the <c>GCLP_WNDPROC</c> index creates a subclass of the window class that affects all windows
	/// subsequently created with the class. An application can subclass a system class, but should not subclass a window class created
	/// by another process.
	/// </para>
	/// <para>
	/// Reserve extra class memory by specifying a nonzero value in the <c>cbClsExtra</c> member of the WNDCLASSEX structure used with
	/// the RegisterClassEx function.
	/// </para>
	/// <para>
	/// Use the <c>SetClassLongPtr</c> function with care. For example, it is possible to change the background color for a class by
	/// using <c>SetClassLongPtr</c>, but this change does not immediately repaint all windows belonging to the class.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setclasslongptra ULONG_PTR SetClassLongPtrA( HWND hWnd,
	// int nIndex, LONG_PTR dwNewLong );
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static IntPtr SetClassLong(HWND hWnd, GetClassLongFlag nIndex, IntPtr dwNewLong) => SetClassLong(hWnd, (int)nIndex, dwNewLong);

	/// <summary>
	/// <para>
	/// Replaces the 16-bit ( <c>WORD</c>) value at the specified offset into the extra class memory for the window class to which the
	/// specified window belongs.
	/// </para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the
	/// SetClassLong function.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window and, indirectly, the class to which the window belongs.</para>
	/// </param>
	/// <param name="nIndex">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The zero-based byte offset of the value to be replaced. Valid values are in the range zero through the number of bytes of class
	/// memory minus two; for example, if you specified 10 or more bytes of extra class memory, a value of 8 would be an index to the
	/// fifth 16-bit integer.
	/// </para>
	/// </param>
	/// <param name="wNewWord">
	/// <para>Type: <c>WORD</c></para>
	/// <para>The replacement value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>WORD</c></c></para>
	/// <para>
	/// If the function succeeds, the return value is the previous value of the specified 16-bit integer. If the value was not previously
	/// set, the return value is zero.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// Reserve extra class memory by specifying a nonzero value in the <c>cbClsExtra</c> member of the WNDCLASS structure used with the
	/// RegisterClass function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setclassword WORD SetClassWord( HWND hWnd, int nIndex,
	// WORD wNewWord );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern ushort SetClassWord(HWND hWnd, int nIndex, ushort wNewWord);

	/// <summary>Sets the keyboard focus to the specified window. The window must be attached to the calling thread's message queue.</summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that will receive the keyboard input. If this parameter is <c>NULL</c>, keystrokes are ignored.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// If the function succeeds, the return value is the handle to the window that previously had the keyboard focus. If the hWnd
	/// parameter is invalid or the window is not attached to the calling thread's message queue, the return value is <c>NULL</c>. To get
	/// extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SetFocus</c> function sends a WM_KILLFOCUS message to the window that loses the keyboard focus and a WM_SETFOCUS message
	/// to the window that receives the keyboard focus. It also activates either the window that receives the focus or the parent of the
	/// window that receives the focus.
	/// </para>
	/// <para>
	/// If a window is active but does not have the focus, any key pressed will produce the WM_SYSCHAR, WM_SYSKEYDOWN, or WM_SYSKEYUP
	/// message. If the <c>VK_MENU</c> key is also pressed, the
	/// </para>
	/// <para>
	/// By using the AttachThreadInput function, a thread can attach its input processing to another thread. This allows a thread to call
	/// <c>SetFocus</c> to set the keyboard focus to a window attached to another thread's message queue.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Initializing a Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setfocus HWND SetFocus( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern HWND SetFocus([Optional] HWND hWnd);

	/// <summary>
	/// <para>
	/// Brings the thread that created the specified window into the foreground and activates the window. Keyboard input is directed to
	/// the window, and various visual cues are changed for the user. The system assigns a slightly higher priority to the thread that
	/// created the foreground window than it does to other threads.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that should be activated and brought to the foreground.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the window was brought to the foreground, the return value is nonzero.</para>
	/// <para>If the window was not brought to the foreground, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The system restricts which processes can set the foreground window. A process can set the foreground window only if one of the
	/// following conditions is true:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The process is the foreground process.</term>
	/// </item>
	/// <item>
	/// <term>The process was started by the foreground process.</term>
	/// </item>
	/// <item>
	/// <term>The process received the last input event.</term>
	/// </item>
	/// <item>
	/// <term>There is no foreground process.</term>
	/// </item>
	/// <item>
	/// <term>The process is being debugged.</term>
	/// </item>
	/// <item>
	/// <term>The foreground process is not a Modern Application or the Start Screen.</term>
	/// </item>
	/// <item>
	/// <term>The foreground is not locked (see LockSetForegroundWindow).</term>
	/// </item>
	/// <item>
	/// <term>The foreground lock time-out has expired (see <c>SPI_GETFOREGROUNDLOCKTIMEOUT</c> in SystemParametersInfo).</term>
	/// </item>
	/// <item>
	/// <term>No menus are active.</term>
	/// </item>
	/// </list>
	/// <para>
	/// An application cannot force a window to the foreground while the user is working with another window. Instead, Windows flashes
	/// the taskbar button of the window to notify the user.
	/// </para>
	/// <para>
	/// A process that can set the foreground window can enable another process to set the foreground window by calling the
	/// AllowSetForegroundWindow function. The process specified by dwProcessId loses the ability to set the foreground window the next
	/// time the user generates input, unless the input is directed at that process, or the next time a process calls
	/// <c>AllowSetForegroundWindow</c>, unless that process is specified.
	/// </para>
	/// <para>The foreground process can disable calls to <c>SetForegroundWindow</c> by calling the LockSetForegroundWindow function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setforegroundwindow BOOL SetForegroundWindow( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "setforegroundwindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetForegroundWindow(HWND hWnd);

	/// <summary>
	/// <para>Sets the opacity and transparency color key of a layered window.</para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the layered window. A layered window is created by specifying <c>WS_EX_LAYERED</c> when creating the window with the
	/// CreateWindowEx function or by setting <c>WS_EX_LAYERED</c> via SetWindowLong after the window has been created.
	/// </para>
	/// <para>
	/// <c>Windows 8:</c> The <c>WS_EX_LAYERED</c> style is supported for top-level windows and child windows. Previous Windows versions
	/// support <c>WS_EX_LAYERED</c> only for top-level windows.
	/// </para>
	/// </param>
	/// <param name="crKey">
	/// <para>Type: <c>COLORREF</c></para>
	/// <para>
	/// A COLORREF structure that specifies the transparency color key to be used when composing the layered window. All pixels painted
	/// by the window in this color will be transparent. To generate a <c>COLORREF</c>, use the RGB macro.
	/// </para>
	/// </param>
	/// <param name="bAlpha">
	/// <para>Type: <c>BYTE</c></para>
	/// <para>
	/// Alpha value used to describe the opacity of the layered window. Similar to the <c>SourceConstantAlpha</c> member of the
	/// BLENDFUNCTION structure. When bAlpha is 0, the window is completely transparent. When bAlpha is 255, the window is opaque.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>An action to be taken. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LWA_ALPHA 0x00000002</term>
	/// <term>Use bAlpha to determine the opacity of the layered window.</term>
	/// </item>
	/// <item>
	/// <term>LWA_COLORKEY 0x00000001</term>
	/// <term>Use crKey as the transparency color.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Note that once <c>SetLayeredWindowAttributes</c> has been called for a layered window, subsequent UpdateLayeredWindow calls will
	/// fail until the layering style bit is cleared and set again.
	/// </para>
	/// <para>For more information, see Using Layered Windows.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setlayeredwindowattributes BOOL
	// SetLayeredWindowAttributes( HWND hwnd, COLORREF crKey, BYTE bAlpha, DWORD dwFlags );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "setlayeredwindowattributes")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetLayeredWindowAttributes(HWND hwnd, COLORREF crKey, byte bAlpha, LayeredWindowAttributes dwFlags);

	/// <summary>
	/// <para>Changes the parent window of the specified child window.</para>
	/// </summary>
	/// <param name="hWndChild">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the child window.</para>
	/// </param>
	/// <param name="hWndNewParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the new parent window. If this parameter is <c>NULL</c>, the desktop window becomes the new parent window. If this
	/// parameter is <c>HWND_MESSAGE</c>, the child window becomes a message-only window.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>If the function succeeds, the return value is a handle to the previous parent window.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>An application can use the <c>SetParent</c> function to set the parent window of a pop-up, overlapped, or child window.</para>
	/// <para>If the window identified by the hWndChild parameter is visible, the system performs the appropriate redrawing and repainting.</para>
	/// <para>
	/// For compatibility reasons, <c>SetParent</c> does not modify the <c>WS_CHILD</c> or <c>WS_POPUP</c> window styles of the window
	/// whose parent is being changed. Therefore, if hWndNewParent is <c>NULL</c>, you should also clear the <c>WS_CHILD</c> bit and set
	/// the <c>WS_POPUP</c> style after calling <c>SetParent</c>. Conversely, if hWndNewParent is not <c>NULL</c> and the window was
	/// previously a child of the desktop, you should clear the <c>WS_POPUP</c> style and set the <c>WS_CHILD</c> style before calling <c>SetParent</c>.
	/// </para>
	/// <para>
	/// When you change the parent of a window, you should synchronize the UISTATE of both windows. For more information, see
	/// WM_CHANGEUISTATE and WM_UPDATEUISTATE.
	/// </para>
	/// <para>
	/// Unexpected behavior or errors may occur if hWndNewParent and hWndChild are running in different DPI awareness modes. The table
	/// below outlines this behavior:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Operation</term>
	/// <term>Windows 8.1</term>
	/// <term>Windows 10 (1607 and earlier)</term>
	/// <term>Windows 10 (1703 and later)</term>
	/// </listheader>
	/// <item>
	/// <term>SetParent (In-Proc)</term>
	/// <term>N/A</term>
	/// <term>Forced reset (of current process)</term>
	/// <term>Fail (ERROR_INVALID_STATE)</term>
	/// </item>
	/// <item>
	/// <term>SetParent (Cross-Proc)</term>
	/// <term>Forced reset (of child window's process)</term>
	/// <term>Forced reset (of child window's process)</term>
	/// <term>Forced reset (of child window's process)</term>
	/// </item>
	/// </list>
	/// <para>For more information on DPI awareness, see the Windows High DPI documentation.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setparent HWND SetParent( HWND hWndChild, HWND
	// hWndNewParent );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "setparent")]
	public static extern HWND SetParent(HWND hWndChild, [Optional] HWND hWndNewParent);

	/// <summary>
	/// <para>Changes the default layout when windows are created with no parent or owner only for the currently running process.</para>
	/// </summary>
	/// <param name="dwDefaultLayout">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The default process layout. This parameter can be 0 or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LAYOUT_RTL 0x00000001</term>
	/// <term>Sets the default horizontal layout to be right to left.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The layout specifies how text and graphics are laid out; the default is left to right. The <c>SetProcessDefaultLayout</c>
	/// function changes layout to be right to left, which is the standard in Arabic and Hebrew cultures.
	/// </para>
	/// <para>
	/// After the <c>LAYOUT_RTL</c> flag is selected, flags normally specifying right or left are reversed. To avoid confusion, consider
	/// defining alternate words for standard flags, such as those in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Standard flag</term>
	/// <term>Suggested alternate name</term>
	/// </listheader>
	/// <item>
	/// <term>WS_EX_RIGHT</term>
	/// <term>WS_EX_TRAILING</term>
	/// </item>
	/// <item>
	/// <term>WS_EX_RTLREADING</term>
	/// <term>WS_EX_REVERSEREADING</term>
	/// </item>
	/// <item>
	/// <term>WS_EX_LEFTSCROLLBAR</term>
	/// <term>WS_EX_LEADSCROLLBAR</term>
	/// </item>
	/// <item>
	/// <term>ES_LEFT</term>
	/// <term>ES_LEAD</term>
	/// </item>
	/// <item>
	/// <term>ES_RIGHT</term>
	/// <term>ES_TRAIL</term>
	/// </item>
	/// <item>
	/// <term>EC_LEFTMARGIN</term>
	/// <term>EC_LEADMARGIN</term>
	/// </item>
	/// <item>
	/// <term>EC_RIGHTMARGIN</term>
	/// <term>EC_TRAILMARGIN</term>
	/// </item>
	/// </list>
	/// <para>
	/// If using this function with a mirrored window, note that the <c>SetProcessDefaultLayout</c> function does not mirror the whole
	/// process and all the device contexts (DCs) created in it. It mirrors only the mirrored window's DCs. To mirror any DC, use the
	/// SetLayout function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setprocessdefaultlayout BOOL SetProcessDefaultLayout(
	// DWORD dwDefaultLayout );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "setprocessdefaultlayout")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetProcessDefaultLayout(DefaultLayout dwDefaultLayout);

	/// <summary>
	/// <para>This function has no parameters.</para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero. Otherwise, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>For more information, see Setting the default DPI awareness for a process.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setprocessdpiaware BOOL SetProcessDPIAware( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "setprocessdpiaware")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetProcessDPIAware();

	/// <summary>Associates a Help context identifier with the specified window.</summary>
	/// <param name="arg1">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window with which to associate the Help context identifier.</para>
	/// </param>
	/// <param name="arg2">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The Help context identifier.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns nonzero if successful, or zero otherwise.</para>
	/// <para>To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// If a child window does not have a Help context identifier, it inherits the identifier of its parent window. Likewise, if an owned
	/// window does not have a Help context identifier, it inherits the identifier of its owner window. This inheritance of Help context
	/// identifiers allows an application to set just one identifier for a dialog box and all of its controls.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setwindowcontexthelpid BOOL SetWindowContextHelpId( HWND ,
	// DWORD );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "7e0963d1-5807-4db5-9abf-cdb21a03b525")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWindowContextHelpId(HWND arg1, uint arg2);

	/// <summary>
	/// <para>Stores the display affinity setting in kernel mode on the hWnd associated with the window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window.</para>
	/// </param>
	/// <param name="dwAffinity">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The display affinity setting. This setting specifies where the window's contents are can be displayed. Set this value to
	/// WDA_MONITOR to display the window's contents only on a monitor.
	/// </para>
	/// <para>Set this value to WDA_NONE to remove the monitor-only affinity.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>
	/// If the function succeeds, it returns <c>TRUE</c>; otherwise, it returns <c>FALSE</c> when, for example, the function call is made
	/// on a non top-level window. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function and GetWindowDisplayAffinity are designed to support the window content protection feature that is new to Windows
	/// 7. This feature enables applications to protect their own onscreen window content from being captured or copied through a
	/// specific set of public operating system features and APIs. However, it works only when the Desktop Window Manager(DWM) is
	/// composing the desktop.
	/// </para>
	/// <para>
	/// It is important to note that unlike a security feature or an implementation of Digital Rights Management (DRM), there is no
	/// guarantee that using <c>SetWindowDisplayAffinity</c> and GetWindowDisplayAffinity, and other necessary functions such as
	/// DwmIsCompositionEnabled, will strictly protect windowed content, for example where someone takes a photograph of the screen.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setwindowdisplayaffinity BOOL SetWindowDisplayAffinity(
	// HWND hWnd, DWORD dwAffinity );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "setwindowdisplayaffinity")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWindowDisplayAffinity(HWND hWnd, WindowDisplayAffinity dwAffinity);

	/// <summary>Sets the feedback configuration for a window.</summary>
	/// <param name="hwnd">The window to configure feedback on.</param>
	/// <param name="feedback">One of the values from the FEEDBACK_TYPE enumeration.</param>
	/// <param name="dwFlags">Reserved. Must be 0.</param>
	/// <param name="size">
	/// The size, in bytes, of the configuration data. Must be sizeof(BOOL) or 0 if the feedback setting is being reset.
	/// </param>
	/// <param name="configuration">The configuration data. Must be BOOL or NULL if the feedback setting is being reset.</param>
	/// <returns>Returns TRUE if successful; otherwise, returns FALSE.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setwindowfeedbacksetting BOOL SetWindowFeedbackSetting(
	// HWND hwnd, FEEDBACK_TYPE feedback, DWORD dwFlags, UINT32 size, const VOID *configuration );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "72bee160-7004-40be-9c91-e431b06ccaed")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWindowFeedbackSetting(HWND hwnd, FEEDBACK_TYPE feedback, [Optional] uint dwFlags, uint size, [Optional] IntPtr configuration);

	/// <summary>
	/// <para>Sets the show state and the restored, minimized, and maximized positions of the specified window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window.</para>
	/// </param>
	/// <param name="lpwndpl">
	/// <para>Type: <c>const WINDOWPLACEMENT*</c></para>
	/// <para>A pointer to a WINDOWPLACEMENT structure that specifies the new show state and window positions.</para>
	/// <para>
	/// Before calling <c>SetWindowPlacement</c>, set the <c>length</c> member of the WINDOWPLACEMENT structure to sizeof(
	/// <c>WINDOWPLACEMENT</c>). <c>SetWindowPlacement</c> fails if the <c>length</c> member is not set correctly.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the information specified in WINDOWPLACEMENT would result in a window that is completely off the screen, the system will
	/// automatically adjust the coordinates so that the window is visible, taking into account changes in screen resolution and multiple
	/// monitor configuration.
	/// </para>
	/// <para>
	/// The <c>length</c> member of WINDOWPLACEMENT must be set to . If this member is not set correctly, the function returns
	/// <c>FALSE</c>. For additional remarks on the proper use of window placement coordinates, see <c>WINDOWPLACEMENT</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setwindowplacement BOOL SetWindowPlacement( HWND hWnd,
	// CONST WINDOWPLACEMENT *lpwndpl );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "setwindowplacement")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWindowPlacement(HWND hWnd, ref WINDOWPLACEMENT lpwndpl);

	/// <summary>
	/// <para>
	/// Changes the size, position, and Z order of a child, pop-up, or top-level window. These windows are ordered according to their
	/// appearance on the screen. The topmost window receives the highest rank and is the first window in the Z order.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window.</para>
	/// </param>
	/// <param name="hWndInsertAfter">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the window to precede the positioned window in the Z order. This parameter must be a window handle or one of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HWND_BOTTOM (HWND)1</term>
	/// <term>
	/// Places the window at the bottom of the Z order. If the hWnd parameter identifies a topmost window, the window loses its topmost
	/// status and is placed at the bottom of all other windows.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HWND_NOTOPMOST (HWND)-2</term>
	/// <term>
	/// Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window is
	/// already a non-topmost window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HWND_TOP (HWND)0</term>
	/// <term>Places the window at the top of the Z order.</term>
	/// </item>
	/// <item>
	/// <term>HWND_TOPMOST (HWND)-1</term>
	/// <term>Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.</term>
	/// </item>
	/// </list>
	/// <para>For more information about how this parameter is used, see the following Remarks section.</para>
	/// </param>
	/// <param name="X">
	/// <para>Type: <c>int</c></para>
	/// <para>The new position of the left side of the window, in client coordinates.</para>
	/// </param>
	/// <param name="Y">
	/// <para>Type: <c>int</c></para>
	/// <para>The new position of the top of the window, in client coordinates.</para>
	/// </param>
	/// <param name="cx">
	/// <para>Type: <c>int</c></para>
	/// <para>The new width of the window, in pixels.</para>
	/// </param>
	/// <param name="cy">
	/// <para>Type: <c>int</c></para>
	/// <para>The new height of the window, in pixels.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The window sizing and positioning flags. This parameter can be a combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SWP_ASYNCWINDOWPOS 0x4000</term>
	/// <term>
	/// If the calling thread and the thread that owns the window are attached to different input queues, the system posts the request to
	/// the thread that owns the window. This prevents the calling thread from blocking its execution while other threads process the request.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SWP_DEFERERASE 0x2000</term>
	/// <term>Prevents generation of the WM_SYNCPAINT message.</term>
	/// </item>
	/// <item>
	/// <term>SWP_DRAWFRAME 0x0020</term>
	/// <term>Draws a frame (defined in the window's class description) around the window.</term>
	/// </item>
	/// <item>
	/// <term>SWP_FRAMECHANGED 0x0020</term>
	/// <term>
	/// Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to the window, even if the window's
	/// size is not being changed. If this flag is not specified, WM_NCCALCSIZE is sent only when the window's size is being changed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SWP_HIDEWINDOW 0x0080</term>
	/// <term>Hides the window.</term>
	/// </item>
	/// <item>
	/// <term>SWP_NOACTIVATE 0x0010</term>
	/// <term>
	/// Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the topmost or
	/// non-topmost group (depending on the setting of the hWndInsertAfter parameter).
	/// </term>
	/// </item>
	/// <item>
	/// <term>SWP_NOCOPYBITS 0x0100</term>
	/// <term>
	/// Discards the entire contents of the client area. If this flag is not specified, the valid contents of the client area are saved
	/// and copied back into the client area after the window is sized or repositioned.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SWP_NOMOVE 0x0002</term>
	/// <term>Retains the current position (ignores X and Y parameters).</term>
	/// </item>
	/// <item>
	/// <term>SWP_NOOWNERZORDER 0x0200</term>
	/// <term>Does not change the owner window's position in the Z order.</term>
	/// </item>
	/// <item>
	/// <term>SWP_NOREDRAW 0x0008</term>
	/// <term>
	/// Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to the client area, the nonclient
	/// area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of the window being
	/// moved. When this flag is set, the application must explicitly invalidate or redraw any parts of the window and parent window that
	/// need redrawing.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SWP_NOREPOSITION 0x0200</term>
	/// <term>Same as the SWP_NOOWNERZORDER flag.</term>
	/// </item>
	/// <item>
	/// <term>SWP_NOSENDCHANGING 0x0400</term>
	/// <term>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</term>
	/// </item>
	/// <item>
	/// <term>SWP_NOSIZE 0x0001</term>
	/// <term>Retains the current size (ignores the cx and cy parameters).</term>
	/// </item>
	/// <item>
	/// <term>SWP_NOZORDER 0x0004</term>
	/// <term>Retains the current Z order (ignores the hWndInsertAfter parameter).</term>
	/// </item>
	/// <item>
	/// <term>SWP_SHOWWINDOW 0x0040</term>
	/// <term>Displays the window.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// As part of the Vista re-architecture, all services were moved off the interactive desktop into Session 0. hwnd and window manager
	/// operations are only effective inside a session and cross-session attempts to manipulate the hwnd will fail. For more information,
	/// see The Windows Vista Developer Story: Application Compatibility Cookbook.
	/// </para>
	/// <para>
	/// If you have changed certain window data using SetWindowLong, you must call <c>SetWindowPos</c> for the changes to take effect.
	/// Use the following combination for uFlags: .
	/// </para>
	/// <para>
	/// A window can be made a topmost window either by setting the hWndInsertAfter parameter to <c>HWND_TOPMOST</c> and ensuring that
	/// the <c>SWP_NOZORDER</c> flag is not set, or by setting a window's position in the Z order so that it is above any existing
	/// topmost windows. When a non-topmost window is made topmost, its owned windows are also made topmost. Its owners, however, are not changed.
	/// </para>
	/// <para>
	/// If neither the <c>SWP_NOACTIVATE</c> nor <c>SWP_NOZORDER</c> flag is specified (that is, when the application requests that a
	/// window be simultaneously activated and its position in the Z order changed), the value specified in hWndInsertAfter is used only
	/// in the following circumstances.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Neither the <c>HWND_TOPMOST</c> nor <c>HWND_NOTOPMOST</c> flag is specified in hWndInsertAfter.</term>
	/// </item>
	/// <item>
	/// <term>The window identified by hWnd is not the active window.</term>
	/// </item>
	/// </list>
	/// <para>
	/// An application cannot activate an inactive window without also bringing it to the top of the Z order. Applications can change an
	/// activated window's position in the Z order without restrictions, or it can activate a window and then move it to the top of the
	/// topmost or non-topmost windows.
	/// </para>
	/// <para>
	/// If a topmost window is repositioned to the bottom ( <c>HWND_BOTTOM</c>) of the Z order or after any non-topmost window, it is no
	/// longer topmost. When a topmost window is made non-topmost, its owners and its owned windows are also made non-topmost windows.
	/// </para>
	/// <para>
	/// A non-topmost window can own a topmost window, but the reverse cannot occur. Any window (for example, a dialog box) owned by a
	/// topmost window is itself made a topmost window, to ensure that all owned windows stay above their owner.
	/// </para>
	/// <para>If an application is not in the foreground, and should be in the foreground, it must call the SetForegroundWindow function.</para>
	/// <para>
	/// To use <c>SetWindowPos</c> to bring a window to the top, the process that owns the window must have SetForegroundWindow permission.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Initializing a Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setwindowpos BOOL SetWindowPos( HWND hWnd, HWND
	// hWndInsertAfter, int X, int Y, int cx, int cy, UINT uFlags );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "setwindowpos")]
	[System.Security.SecurityCritical]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWindowPos(HWND hWnd, HWND hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

	/// <summary>
	/// <para>
	/// Changes the text of the specified window's title bar (if it has one). If the specified window is a control, the text of the
	/// control is changed. However, <c>SetWindowText</c> cannot change the text of a control in another application.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window or control whose text is to be changed.</para>
	/// </param>
	/// <param name="lpString">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The new title or control text.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the target window is owned by the current process, <c>SetWindowText</c> causes a WM_SETTEXT message to be sent to the
	/// specified window or control. If the control is a list box control created with the <c>WS_CAPTION</c> style, however,
	/// <c>SetWindowText</c> sets the text for the control, not for the list box entries.
	/// </para>
	/// <para>To set the text of a control in another process, send the WM_SETTEXT message directly instead of calling <c>SetWindowText</c>.</para>
	/// <para>
	/// The <c>SetWindowText</c> function does not expand tab characters (ASCII code 0x09). Tab characters are displayed as vertical bar
	/// (|) characters.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Sending a Message.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setwindowtexta BOOL SetWindowTextA( HWND hWnd, LPCSTR
	// lpString );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "setwindowtext")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWindowText(HWND hWnd, string lpString);

	/// <summary>
	/// <para>Shows or hides all pop-up windows owned by the specified window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that owns the pop-up windows to be shown or hidden.</para>
	/// </param>
	/// <param name="fShow">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If this parameter is <c>TRUE</c>, all hidden pop-up windows are shown. If this parameter is <c>FALSE</c>, all visible pop-up
	/// windows are hidden.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>ShowOwnedPopups</c> shows only windows hidden by a previous call to <c>ShowOwnedPopups</c>. For example, if a pop-up window is
	/// hidden by using the ShowWindow function, subsequently calling <c>ShowOwnedPopups</c> with the fShow parameter set to <c>TRUE</c>
	/// does not cause the window to be shown.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-showownedpopups BOOL ShowOwnedPopups( HWND hWnd, BOOL
	// fShow );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "showownedpopups")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ShowOwnedPopups(HWND hWnd, [MarshalAs(UnmanagedType.Bool)] bool fShow);

	/// <summary>
	/// <para>Sets the specified window's show state.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window.</para>
	/// </param>
	/// <param name="nCmdShow">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// Controls how the window is to be shown. This parameter is ignored the first time an application calls <c>ShowWindow</c>, if the
	/// program that launched the application provides a STARTUPINFO structure. Otherwise, the first time <c>ShowWindow</c> is called,
	/// the value should be the value obtained by the WinMain function in its nCmdShow parameter. In subsequent calls, this parameter can
	/// be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SW_FORCEMINIMIZE 11</term>
	/// <term>
	/// Minimizes a window, even if the thread that owns the window is not responding. This flag should only be used when minimizing
	/// windows from a different thread.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SW_HIDE 0</term>
	/// <term>Hides the window and activates another window.</term>
	/// </item>
	/// <item>
	/// <term>SW_MAXIMIZE 3</term>
	/// <term>Maximizes the specified window.</term>
	/// </item>
	/// <item>
	/// <term>SW_MINIMIZE 6</term>
	/// <term>Minimizes the specified window and activates the next top-level window in the Z order.</term>
	/// </item>
	/// <item>
	/// <term>SW_RESTORE 9</term>
	/// <term>
	/// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and
	/// position. An application should specify this flag when restoring a minimized window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SW_SHOW 5</term>
	/// <term>Activates the window and displays it in its current size and position.</term>
	/// </item>
	/// <item>
	/// <term>SW_SHOWDEFAULT 10</term>
	/// <term>
	/// Sets the show state based on the SW_ value specified in the STARTUPINFO structure passed to the CreateProcess function by the
	/// program that started the application.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SW_SHOWMAXIMIZED 3</term>
	/// <term>Activates the window and displays it as a maximized window.</term>
	/// </item>
	/// <item>
	/// <term>SW_SHOWMINIMIZED 2</term>
	/// <term>Activates the window and displays it as a minimized window.</term>
	/// </item>
	/// <item>
	/// <term>SW_SHOWMINNOACTIVE 7</term>
	/// <term>Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.</term>
	/// </item>
	/// <item>
	/// <term>SW_SHOWNA 8</term>
	/// <term>
	/// Displays the window in its current size and position. This value is similar to SW_SHOW, except that the window is not activated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SW_SHOWNOACTIVATE 4</term>
	/// <term>
	/// Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except that the window is not activated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SW_SHOWNORMAL 1</term>
	/// <term>
	/// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and
	/// position. An application should specify this flag when displaying the window for the first time.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the window was previously visible, the return value is nonzero.</para>
	/// <para>If the window was previously hidden, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>To perform certain special effects when showing or hiding a window, use AnimateWindow.</para>
	/// <para>
	/// The first time an application calls <c>ShowWindow</c>, it should use the WinMain function's nCmdShow parameter as its nCmdShow
	/// parameter. Subsequent calls to <c>ShowWindow</c> must use one of the values in the given list, instead of the one specified by
	/// the <c>WinMain</c> function's nCmdShow parameter.
	/// </para>
	/// <para>
	/// As noted in the discussion of the nCmdShow parameter, the nCmdShow value is ignored in the first call to <c>ShowWindow</c> if the
	/// program that launched the application specifies startup information in the structure. In this case, <c>ShowWindow</c> uses the
	/// information specified in the STARTUPINFO structure to show the window. On subsequent calls, the application must call
	/// <c>ShowWindow</c> with nCmdShow set to <c>SW_SHOWDEFAULT</c> to use the startup information provided by the program that launched
	/// the application. This behavior is designed for the following situations:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Applications create their main window by calling CreateWindow with the <c>WS_VISIBLE</c> flag set.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Applications create their main window by calling CreateWindow with the <c>WS_VISIBLE</c> flag cleared, and later call
	/// <c>ShowWindow</c> with the <c>SW_SHOW</c> flag set to make it visible.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Main Window.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-showwindow BOOL ShowWindow( HWND hWnd, int nCmdShow );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "showwindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ShowWindow(HWND hWnd, ShowWindowCommand nCmdShow);

	/// <summary>
	/// <para>Sets the show state of a window without waiting for the operation to complete.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window.</para>
	/// </param>
	/// <param name="nCmdShow">
	/// <para>Type: <c>int</c></para>
	/// <para>Controls how the window is to be shown. For a list of possible values, see the description of the ShowWindow function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the operation was successfully started, the return value is nonzero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function posts a show-window event to the message queue of the given window. An application can use this function to avoid
	/// becoming nonresponsive while waiting for a nonresponsive application to finish processing a show-window event.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-showwindowasync BOOL ShowWindowAsync( HWND hWnd, int
	// nCmdShow );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "showwindowasync")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ShowWindowAsync(HWND hWnd, ShowWindowCommand nCmdShow);

	/// <summary>
	/// <para>Triggers a visual signal to indicate that a sound is playing.</para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>This function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>The visual signal was or will be displayed correctly.</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>An error prevented the signal from being displayed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Set the notification behavior by calling SystemParametersInfo with the <c>SPI_SETSOUNDSENTRY</c> value.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-soundsentry BOOL SoundSentry( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "soundsentry")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SoundSentry();

	/// <summary>
	/// <para>[This function is not intended for general use. It may be altered or unavailable in subsequent versions of Windows.]</para>
	/// <para>Switches focus to the specified window and brings it to the foreground.</para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window.</para>
	/// </param>
	/// <param name="fUnknown">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// A <c>TRUE</c> for this parameter indicates that the window is being switched to using the Alt/Ctl+Tab key sequence. This
	/// parameter should be <c>FALSE</c> otherwise.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function is typically called to maintain window z-ordering.</para>
	/// <para>
	/// This function was not included in the SDK headers and libraries until Windows XP with Service Pack 1 (SP1) and Windows Server
	/// 2003. If you do not have a header file and import library for this function, you can call the function using LoadLibrary and GetProcAddress.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-switchtothiswindow void SwitchToThisWindow( HWND hwnd,
	// BOOL fUnknown );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "switchtothiswindow")]
	public static extern void SwitchToThisWindow(HWND hwnd, [MarshalAs(UnmanagedType.Bool)] bool fUnknown);

	/// <summary>
	/// <para>Tiles the specified child windows of the specified parent window.</para>
	/// </summary>
	/// <param name="hwndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the parent window. If this parameter is <c>NULL</c>, the desktop window is assumed.</para>
	/// </param>
	/// <param name="wHow">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The tiling flags. This parameter can be one of the following values—optionally combined with <c>MDITILE_SKIPDISABLED</c> to
	/// prevent disabled MDI child windows from being tiled.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MDITILE_HORIZONTAL 0x0001</term>
	/// <term>Tiles windows horizontally.</term>
	/// </item>
	/// <item>
	/// <term>MDITILE_VERTICAL 0x0000</term>
	/// <term>Tiles windows vertically.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpRect">
	/// <para>Type: <c>const RECT*</c></para>
	/// <para>
	/// A pointer to a structure that specifies the rectangular area, in client coordinates, within which the windows are arranged. If
	/// this parameter is <c>NULL</c>, the client area of the parent window is used.
	/// </para>
	/// </param>
	/// <param name="cKids">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of elements in the array specified by the lpKids parameter. This parameter is ignored if lpKids is <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpKids">
	/// <para>Type: <c>const HWND*</c></para>
	/// <para>
	/// An array of handles to the child windows to arrange. If a specified child window is a top-level window with the style
	/// <c>WS_EX_TOPMOST</c> or <c>WS_EX_TOOLWINDOW</c>, the child window is not arranged. If this parameter is <c>NULL</c>, all child
	/// windows of the specified parent window (or of the desktop window) are arranged.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>WORD</c></c></para>
	/// <para>If the function succeeds, the return value is the number of windows arranged.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Calling <c>TileWindows</c> causes all maximized windows to be restored to their previous size.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-tilewindows WORD TileWindows( HWND hwndParent, UINT wHow,
	// CONST RECT *lpRect, UINT cKids, const HWND *lpKids );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "tilewindows")]
	public static extern ushort TileWindows([Optional] HWND hwndParent, MdiTileFlags wHow, [Optional] PRECT? lpRect, uint cKids, [In, Optional] HWND[]? lpKids);

	/// <summary>
	/// Processes accelerator keystrokes for window menu commands of the multiple-document interface (MDI) child windows associated with
	/// the specified MDI client window. The function translates WM_KEYUP and WM_KEYDOWN messages to WM_SYSCOMMAND messages and sends
	/// them to the appropriate MDI child windows.
	/// </summary>
	/// <param name="hWndClient">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the MDI client window.</para>
	/// </param>
	/// <param name="lpMsg">
	/// <para>Type: <c>LPMSG</c></para>
	/// <para>
	/// A pointer to a message retrieved by using the GetMessage or PeekMessage function. The message must be an MSG structure and
	/// contain message information from the application's message queue.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the message is translated into a system command, the return value is nonzero.</para>
	/// <para>If the message is not translated into a system command, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-translatemdisysaccel BOOL TranslateMDISysAccel( HWND
	// hWndClient, LPMSG lpMsg );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TranslateMDISysAccel(HWND hWndClient, ref MSG lpMsg);

	/// <summary>Unregisters a window class, freeing the memory required for the class.</summary>
	/// <param name="lpClassName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A null-terminated string or a class atom. If lpClassName is a string, it specifies the window class name. This class name must
	/// have been registered by a previous call to the RegisterClass or RegisterClassEx function. System classes, such as dialog box
	/// controls, cannot be unregistered. If this parameter is an atom, it must be a class atom created by a previous call to the
	/// <c>RegisterClass</c> or <c>RegisterClassEx</c> function. The atom must be in the low-order word of lpClassName; the high-order
	/// word must be zero.
	/// </para>
	/// </param>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the instance of the module that created the class.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the class could not be found or if a window still exists that was created with the class, the return value is zero. To get
	/// extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Before calling this function, an application must destroy all windows created with the specified class.</para>
	/// <para>All window classes that an application registers are unregistered when it terminates.</para>
	/// <para>Class atoms are special atoms returned only by RegisterClass and RegisterClassEx.</para>
	/// <para>No window classes registered by a DLL are unregistered when the .dll is unloaded.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-unregisterclassa BOOL UnregisterClassA( LPCSTR
	// lpClassName, HINSTANCE hInstance );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UnregisterClass(string lpClassName, HINSTANCE hInstance);

	/// <summary>
	/// <para>Updates the position, size, shape, content, and translucency of a layered window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to a layered window. A layered window is created by specifying <c>WS_EX_LAYERED</c> when creating the window with the
	/// CreateWindowEx function.
	/// </para>
	/// <para>
	/// <c>Windows 8:</c> The <c>WS_EX_LAYERED</c> style is supported for top-level windows and child windows. Previous Windows versions
	/// support <c>WS_EX_LAYERED</c> only for top-level windows.
	/// </para>
	/// </param>
	/// <param name="hdcDst">
	/// <para>Type: <c>HDC</c></para>
	/// <para>
	/// A handle to a DC for the screen. This handle is obtained by specifying <c>NULL</c> when calling the function. It is used for
	/// palette color matching when the window contents are updated. If hdcDst is <c>NULL</c>, the default palette will be used.
	/// </para>
	/// <para>If hdcSrc is <c>NULL</c>, hdcDst must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pptDst">
	/// <para>Type: <c>POINT*</c></para>
	/// <para>
	/// A pointer to a structure that specifies the new screen position of the layered window. If the current position is not changing,
	/// pptDst can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="psize">
	/// <para>Type: <c>SIZE*</c></para>
	/// <para>
	/// A pointer to a structure that specifies the new size of the layered window. If the size of the window is not changing, psize can
	/// be <c>NULL</c>. If hdcSrc is <c>NULL</c>, psize must be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="hdcSrc">
	/// <para>Type: <c>HDC</c></para>
	/// <para>
	/// A handle to a DC for the surface that defines the layered window. This handle can be obtained by calling the CreateCompatibleDC
	/// function. If the shape and visual context of the window are not changing, hdcSrc can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pptSrc">
	/// <para>Type: <c>POINT*</c></para>
	/// <para>
	/// A pointer to a structure that specifies the location of the layer in the device context. If hdcSrc is <c>NULL</c>, pptSrc should
	/// be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="crKey">
	/// <para>Type: <c>COLORREF</c></para>
	/// <para>
	/// A structure that specifies the color key to be used when composing the layered window. To generate a COLORREF, use the RGB macro.
	/// </para>
	/// </param>
	/// <param name="pblend">
	/// <para>Type: <c>BLENDFUNCTION*</c></para>
	/// <para>A pointer to a structure that specifies the transparency value to be used when composing the layered window.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ULW_ALPHA 0x00000002</term>
	/// <term>
	/// Use pblend as the blend function. If the display mode is 256 colors or less, the effect of this value is the same as the effect
	/// of ULW_OPAQUE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ULW_COLORKEY 0x00000001</term>
	/// <term>Use crKey as the transparency color.</term>
	/// </item>
	/// <item>
	/// <term>ULW_OPAQUE 0x00000004</term>
	/// <term>Draw an opaque layered window.</term>
	/// </item>
	/// </list>
	/// <para>If hdcSrc is <c>NULL</c>, dwFlags should be zero.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The source DC should contain the surface that defines the visible contents of the layered window. For example, you can select a
	/// bitmap into a device context obtained by calling the CreateCompatibleDC function.
	/// </para>
	/// <para>
	/// An application should call SetLayout on the hdcSrc device context to properly set the mirroring mode. <c>SetLayout</c> will
	/// properly mirror all drawing into an <c>HDC</c> while properly preserving text glyph and (optionally) bitmap direction order. It
	/// cannot modify drawing directly into the bits of a device-independent bitmap (DIB). For more information, see Window Layout and Mirroring.
	/// </para>
	/// <para>
	/// The <c>UpdateLayeredWindow</c> function maintains the window's appearance on the screen. The windows underneath a layered window
	/// do not need to be repainted when they are uncovered due to a call to <c>UpdateLayeredWindow</c>, because the system will
	/// automatically repaint them. This permits seamless animation of the layered window.
	/// </para>
	/// <para>
	/// <c>UpdateLayeredWindow</c> always updates the entire window. To update part of a window, use the traditional WM_PAINT and set the
	/// blend value using SetLayeredWindowAttributes.
	/// </para>
	/// <para>
	/// For best drawing performance by the layered window and any underlying windows, the layered window should be as small as possible.
	/// An application should also process the message and re-create its layered windows when the display's color depth changes.
	/// </para>
	/// <para>For more information, see Layered Windows.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-updatelayeredwindow BOOL UpdateLayeredWindow( HWND hWnd,
	// HDC hdcDst, POINT *pptDst, SIZE *psize, HDC hdcSrc, POINT *pptSrc, COLORREF crKey, BLENDFUNCTION *pblend, DWORD dwFlags );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "updatelayeredwindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UpdateLayeredWindow(HWND hWnd, HDC hdcDst, in POINT pptDst, in SIZE psize, HDC hdcSrc,
		in POINT pptSrc, COLORREF crKey, in Gdi32.BLENDFUNCTION pblend, UpdateLayeredWindowFlags dwFlags);

	/// <summary>
	/// <para>Updates the position, size, shape, content, and translucency of a layered window.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to a layered window. A layered window is created by specifying <c>WS_EX_LAYERED</c> when creating the window with the
	/// CreateWindowEx function.
	/// </para>
	/// <para>
	/// <c>Windows 8:</c> The <c>WS_EX_LAYERED</c> style is supported for top-level windows and child windows. Previous Windows versions
	/// support <c>WS_EX_LAYERED</c> only for top-level windows.
	/// </para>
	/// </param>
	/// <param name="hdcDst">
	/// <para>Type: <c>HDC</c></para>
	/// <para>
	/// A handle to a DC for the screen. This handle is obtained by specifying <c>NULL</c> when calling the function. It is used for
	/// palette color matching when the window contents are updated. If hdcDst is <c>NULL</c>, the default palette will be used.
	/// </para>
	/// <para>If hdcSrc is <c>NULL</c>, hdcDst must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pptDst">
	/// <para>Type: <c>POINT*</c></para>
	/// <para>
	/// A pointer to a structure that specifies the new screen position of the layered window. If the current position is not changing,
	/// pptDst can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="psize">
	/// <para>Type: <c>SIZE*</c></para>
	/// <para>
	/// A pointer to a structure that specifies the new size of the layered window. If the size of the window is not changing, psize can
	/// be <c>NULL</c>. If hdcSrc is <c>NULL</c>, psize must be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="hdcSrc">
	/// <para>Type: <c>HDC</c></para>
	/// <para>
	/// A handle to a DC for the surface that defines the layered window. This handle can be obtained by calling the CreateCompatibleDC
	/// function. If the shape and visual context of the window are not changing, hdcSrc can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pptSrc">
	/// <para>Type: <c>POINT*</c></para>
	/// <para>
	/// A pointer to a structure that specifies the location of the layer in the device context. If hdcSrc is <c>NULL</c>, pptSrc should
	/// be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="crKey">
	/// <para>Type: <c>COLORREF</c></para>
	/// <para>
	/// A structure that specifies the color key to be used when composing the layered window. To generate a COLORREF, use the RGB macro.
	/// </para>
	/// </param>
	/// <param name="pblend">
	/// <para>Type: <c>BLENDFUNCTION*</c></para>
	/// <para>A pointer to a structure that specifies the transparency value to be used when composing the layered window.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ULW_ALPHA 0x00000002</term>
	/// <term>
	/// Use pblend as the blend function. If the display mode is 256 colors or less, the effect of this value is the same as the effect
	/// of ULW_OPAQUE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ULW_COLORKEY 0x00000001</term>
	/// <term>Use crKey as the transparency color.</term>
	/// </item>
	/// <item>
	/// <term>ULW_OPAQUE 0x00000004</term>
	/// <term>Draw an opaque layered window.</term>
	/// </item>
	/// </list>
	/// <para>If hdcSrc is <c>NULL</c>, dwFlags should be zero.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The source DC should contain the surface that defines the visible contents of the layered window. For example, you can select a
	/// bitmap into a device context obtained by calling the CreateCompatibleDC function.
	/// </para>
	/// <para>
	/// An application should call SetLayout on the hdcSrc device context to properly set the mirroring mode. <c>SetLayout</c> will
	/// properly mirror all drawing into an <c>HDC</c> while properly preserving text glyph and (optionally) bitmap direction order. It
	/// cannot modify drawing directly into the bits of a device-independent bitmap (DIB). For more information, see Window Layout and Mirroring.
	/// </para>
	/// <para>
	/// The <c>UpdateLayeredWindow</c> function maintains the window's appearance on the screen. The windows underneath a layered window
	/// do not need to be repainted when they are uncovered due to a call to <c>UpdateLayeredWindow</c>, because the system will
	/// automatically repaint them. This permits seamless animation of the layered window.
	/// </para>
	/// <para>
	/// <c>UpdateLayeredWindow</c> always updates the entire window. To update part of a window, use the traditional WM_PAINT and set the
	/// blend value using SetLayeredWindowAttributes.
	/// </para>
	/// <para>
	/// For best drawing performance by the layered window and any underlying windows, the layered window should be as small as possible.
	/// An application should also process the message and re-create its layered windows when the display's color depth changes.
	/// </para>
	/// <para>For more information, see Layered Windows.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-updatelayeredwindow BOOL UpdateLayeredWindow( HWND hWnd,
	// HDC hdcDst, POINT *pptDst, SIZE *psize, HDC hdcSrc, POINT *pptSrc, COLORREF crKey, BLENDFUNCTION *pblend, DWORD dwFlags );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "updatelayeredwindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UpdateLayeredWindow(HWND hWnd, [In, Optional] HDC hdcDst, [In, Optional] IntPtr pptDst, [In, Optional] IntPtr psize,
		[In, Optional] HDC hdcSrc, [In, Optional] IntPtr pptSrc, COLORREF crKey, in Gdi32.BLENDFUNCTION pblend, UpdateLayeredWindowFlags dwFlags);

	/// <summary>Updates the position, size, shape, content, and translucency of a layered window.</summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to a layered window. A layered window is created by specifying <c>WS_EX_LAYERED</c> when creating the window with the
	/// <c>CreateWindowEx</c> function.
	/// </para>
	/// <para>
	/// <c>Windows 8:</c> The <c>WS_EX_LAYERED</c> style is supported for top-level windows and child windows. Previous Windows versions
	/// support <c>WS_EX_LAYERED</c> only for top-level windows.
	/// </para>
	/// </param>
	/// <param name="pULWInfo">
	/// <para>Type: <c>const <c>UPDATELAYEREDWINDOWINFO</c>*</c></para>
	/// <para>A pointer to a structure that contains the information for the window.</para>
	/// </param>
	/// <returns>
	/// <para>Type:</para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI UpdateLayeredWindowIndirect( _In_ HWND hwnd, _In_ const UPDATELAYEREDWINDOWINFO *pULWInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/ms633557(v=vs.85).aspx
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winuser.h", MSDNShortId = "ms633557")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UpdateLayeredWindowIndirect([In] HWND hwnd, in UPDATELAYEREDWINDOWINFO pULWInfo);

	/// <summary>
	/// <para>Retrieves a handle to the window that contains the specified physical point.</para>
	/// </summary>
	/// <param name="Point">
	/// <para>Type: <c>POINT</c></para>
	/// <para>The physical coordinates of the point.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>A handle to the window that contains the given physical point. If no window exists at the point, this value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WindowFromPhysicalPoint</c> function does not retrieve a handle to a hidden or disabled window, even if the point is
	/// within the window.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-windowfromphysicalpoint HWND WindowFromPhysicalPoint(
	// POINT Point );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "windowfromphysicalpoint")]
	public static extern HWND WindowFromPhysicalPoint(POINT Point);

	/// <summary>
	/// <para>Retrieves a handle to the window that contains the specified point.</para>
	/// </summary>
	/// <param name="Point">
	/// <para>Type: <c>POINT</c></para>
	/// <para>The point to be checked.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>HWND</c></c></para>
	/// <para>
	/// The return value is a handle to the window that contains the point. If no window exists at the given point, the return value is
	/// <c>NULL</c>. If the point is over a static text control, the return value is a handle to the window under the static text control.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WindowFromPoint</c> function does not retrieve a handle to a hidden or disabled window, even if the point is within the
	/// window. An application should use the ChildWindowFromPoint function for a nonrestrictive search.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see "Interface from Running Object Table" in About Text Object Model.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-windowfrompoint HWND WindowFromPoint( POINT Point );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "windowfrompoint")]
	public static extern HWND WindowFromPoint(POINT Point);

	/// <summary>
	/// <para>
	/// Temporarily enables or disables an Input Method Editor (IME) and, at the same time, turns on or off the display of all windows
	/// owned by the IME.
	/// </para>
	/// <para><c>Note</c> This function is obsolete and should not be used.</para>
	/// </summary>
	/// <param name="hWnd">Must be <c>NULL</c>. Specifying a particular IME for each application is not supported.</param>
	/// <param name="fEnable"><c>TRUE</c> to enable the IME; <c>FALSE</c> to disable.</param>
	/// <returns>The previous state of the IME. <c>TRUE</c> if it was enabled before this call, otherwise, <c>FALSE</c>.</returns>
	/// <remarks>
	/// <para>The terms "enabled" and "disabled" in regard to this function are defined as follows:</para>
	/// <para>
	/// If an IME is disabled, IME_WINDOWUPDATE(FALSE) is issued to the IME, which responds by deleting the conversion and system
	/// windows. With the IME disabled, keyboard messages are not sent to the IME, but are sent directly to the application. Even if the
	/// IME is disabled, the API that uses the SendIMEMessageEx function is still valid.
	/// </para>
	/// <para>
	/// If an IME is enabled, IME_WINDOWUPDATE(TRUE) is issued to the IME, which responds by redisplaying the conversion and system
	/// windows. With the IME enabled, keyboard messages are sent to the IME.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnls32/nf-winnls32-winnlsenableime BOOL WINNLSEnableIME( IN HWND, IN BOOL );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winnls32.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WINNLSEnableIME([In, Optional] HWND hWnd, [In][MarshalAs(UnmanagedType.Bool)] bool fEnable);

	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool GetClassInfoEx([In] HINSTANCE hInstance, [MarshalAs(UnmanagedType.LPTStr)] string lpszClass, ref WNDCLASSEXB lpwcx);

	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool GetClassInfoEx([In] HINSTANCE hInstance, [In] IntPtr lpszClass, ref WNDCLASSEXB lpwcx);

	/// <summary>
	/// <para>Retrieves the specified 32-bit ( <c>DWORD</c>) value from the WNDCLASSEX structure associated with the specified window.</para>
	/// <para>
	/// <c>Note</c> If you are retrieving a pointer or a handle, this function has been superseded by the GetClassLongPtr function.
	/// (Pointers and handles are 32 bits on 32-bit Windows and 64 bits on 64-bit Windows.)
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window and, indirectly, the class to which the window belongs.</para>
	/// </param>
	/// <param name="nIndex">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The value to be retrieved. To retrieve a value from the extra class memory, specify the positive, zero-based byte offset of the
	/// value to be retrieved. Valid values are in the range zero through the number of bytes of extra class memory, minus four; for
	/// example, if you specified 12 or more bytes of extra class memory, a value of 8 would be an index to the third integer. To
	/// retrieve any other value from the WNDCLASSEX structure, specify one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GCW_ATOM -32</term>
	/// <term>
	/// Retrieves an ATOM value that uniquely identifies the window class. This is the same atom that the RegisterClassEx function returns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCL_CBCLSEXTRA -20</term>
	/// <term>Retrieves the size, in bytes, of the extra memory associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_CBWNDEXTRA -18</term>
	/// <term>
	/// Retrieves the size, in bytes, of the extra window memory associated with each window in the class. For information on how to
	/// access this memory, see GetWindowLong.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCL_HBRBACKGROUND -10</term>
	/// <term>Retrieves a handle to the background brush associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_HCURSOR -12</term>
	/// <term>Retrieves a handle to the cursor associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_HICON -14</term>
	/// <term>Retrieves a handle to the icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_HICONSM -34</term>
	/// <term>Retrieves a handle to the small icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_HMODULE -16</term>
	/// <term>Retrieves a handle to the module that registered the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_MENUNAME -8</term>
	/// <term>Retrieves the address of the menu name string. The string identifies the menu resource associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_STYLE -26</term>
	/// <term>Retrieves the window-class style bits.</term>
	/// </item>
	/// <item>
	/// <term>GCL_WNDPROC -24</term>
	/// <term>
	/// Retrieves the address of the window procedure, or a handle representing the address of the window procedure. You must use the
	/// CallWindowProc function to call the window procedure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>DWORD</c></c></para>
	/// <para>If the function succeeds, the return value is the requested value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// Reserve extra class memory by specifying a nonzero value in the <c>cbClsExtra</c> member of the WNDCLASSEX structure used with
	/// the RegisterClassEx function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getclasslonga DWORD GetClassLongA( HWND hWnd, int nIndex );
	[DllImport(Lib.User32, SetLastError = true, EntryPoint = "GetClassLong", CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	private static extern int GetClassLong32(HWND hWnd, int nIndex);

	/// <summary>
	/// <para>Retrieves the specified value from the WNDCLASSEX structure associated with the specified window.</para>
	/// <para>
	/// <c>Note</c> To write code that is compatible with both 32-bit and 64-bit versions of Windows, use <c>GetClassLongPtr</c>. When
	/// compiling for 32-bit Windows, <c>GetClassLongPtr</c> is defined as a call to the GetClassLong function.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window and, indirectly, the class to which the window belongs.</para>
	/// </param>
	/// <param name="nIndex">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The value to be retrieved. To retrieve a value from the extra class memory, specify the positive, zero-based byte offset of the
	/// value to be retrieved. Valid values are in the range zero through the number of bytes of extra class memory, minus eight; for
	/// example, if you specified 24 or more bytes of extra class memory, a value of 16 would be an index to the third integer. To
	/// retrieve any other value from the WNDCLASSEX structure, specify one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GCW_ATOM -32</term>
	/// <term>
	/// Retrieves an ATOM value that uniquely identifies the window class. This is the same atom that the RegisterClassEx function returns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCL_CBCLSEXTRA -20</term>
	/// <term>Retrieves the size, in bytes, of the extra memory associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_CBWNDEXTRA -18</term>
	/// <term>
	/// Retrieves the size, in bytes, of the extra window memory associated with each window in the class. For information on how to
	/// access this memory, see GetWindowLongPtr.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCLP_HBRBACKGROUND -10</term>
	/// <term>Retrieves a handle to the background brush associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HCURSOR -12</term>
	/// <term>Retrieves a handle to the cursor associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HICON -14</term>
	/// <term>Retrieves a handle to the icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HICONSM -34</term>
	/// <term>Retrieves a handle to the small icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HMODULE -16</term>
	/// <term>Retrieves a handle to the module that registered the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_MENUNAME -8</term>
	/// <term>Retrieves the pointer to the menu name string. The string identifies the menu resource associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_STYLE -26</term>
	/// <term>Retrieves the window-class style bits.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_WNDPROC -24</term>
	/// <term>
	/// Retrieves the address of the window procedure, or a handle representing the address of the window procedure. You must use the
	/// CallWindowProc function to call the window procedure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>ULONG_PTR</c></c></para>
	/// <para>If the function succeeds, the return value is the requested value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// Reserve extra class memory by specifying a nonzero value in the <c>cbClsExtra</c> member of the WNDCLASSEX structure used with
	/// the RegisterClassEx function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getclasslongptra ULONG_PTR GetClassLongPtrA( HWND hWnd,
	// int nIndex );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	private static extern IntPtr GetClassLongPtr(HWND hWnd, int nIndex);

	/// <summary>
	/// <para>
	/// Replaces the specified 32-bit ( <c>long</c>) value at the specified offset into the extra class memory or the WNDCLASSEX
	/// structure for the class to which the specified window belongs.
	/// </para>
	/// <para>
	/// <c>Note</c> This function has been superseded by the SetClassLongPtr function. To write code that is compatible with both 32-bit
	/// and 64-bit versions of Windows, use <c>SetClassLongPtr</c>.
	/// </para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window and, indirectly, the class to which the window belongs.</para>
	/// </param>
	/// <param name="nIndex">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The value to be replaced. To set a 32-bit value in the extra class memory, specify the positive, zero-based byte offset of the
	/// value to be set. Valid values are in the range zero through the number of bytes of extra class memory, minus four; for example,
	/// if you specified 12 or more bytes of extra class memory, a value of 8 would be an index to the third 32-bit integer. To set any
	/// other value from the WNDCLASSEX structure, specify one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GCL_CBCLSEXTRA -20</term>
	/// <term>
	/// Sets the size, in bytes, of the extra memory associated with the class. Setting this value does not change the number of extra
	/// bytes already allocated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCL_CBWNDEXTRA -18</term>
	/// <term>
	/// Sets the size, in bytes, of the extra window memory associated with each window in the class. Setting this value does not change
	/// the number of extra bytes already allocated. For information on how to access this memory, see SetWindowLong.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCL_HBRBACKGROUND -10</term>
	/// <term>Replaces a handle to the background brush associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_HCURSOR -12</term>
	/// <term>Replaces a handle to the cursor associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_HICON -14</term>
	/// <term>Replaces a handle to the icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_HICONSM -34</term>
	/// <term>Replace a handle to the small icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_HMODULE -16</term>
	/// <term>Replaces a handle to the module that registered the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_MENUNAME -8</term>
	/// <term>Replaces the address of the menu name string. The string identifies the menu resource associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_STYLE -26</term>
	/// <term>Replaces the window-class style bits.</term>
	/// </item>
	/// <item>
	/// <term>GCL_WNDPROC -24</term>
	/// <term>Replaces the address of the window procedure associated with the class.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwNewLong">
	/// <para>Type: <c>LONG</c></para>
	/// <para>The replacement value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>DWORD</c></c></para>
	/// <para>
	/// If the function succeeds, the return value is the previous value of the specified 32-bit integer. If the value was not previously
	/// set, the return value is zero.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If you use the <c>SetClassLong</c> function and the <c>GCL_WNDPROC</c> index to replace the window procedure, the window
	/// procedure must conform to the guidelines specified in the description of the WindowProc callback function.
	/// </para>
	/// <para>
	/// Calling <c>SetClassLong</c> with the <c>GCL_WNDPROC</c> index creates a subclass of the window class that affects all windows
	/// subsequently created with the class. An application can subclass a system class, but should not subclass a window class created
	/// by another process.
	/// </para>
	/// <para>
	/// Reserve extra class memory by specifying a nonzero value in the <c>cbClsExtra</c> member of the WNDCLASSEX structure used with
	/// the RegisterClassEx function.
	/// </para>
	/// <para>
	/// Use the <c>SetClassLong</c> function with care. For example, it is possible to change the background color for a class by using
	/// <c>SetClassLong</c>, but this change does not immediately repaint all windows belonging to the class.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Displaying an Icon.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setclasslonga DWORD SetClassLongA( HWND hWnd, int nIndex,
	// LONG dwNewLong );
	[DllImport(Lib.User32, SetLastError = true, EntryPoint = "SetClassLong", CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	private static extern uint SetClassLong32(HWND hWnd, int nIndex, int dwNewLong);

	/// <summary>
	/// Replaces the specified value at the specified offset in the extra class memory or the WNDCLASSEX structure for the class to which
	/// the specified window belongs.
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window and, indirectly, the class to which the window belongs.</para>
	/// </param>
	/// <param name="nIndex">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The value to be replaced. To set a value in the extra class memory, specify the positive, zero-based byte offset of the value to
	/// be set. Valid values are in the range zero through the number of bytes of extra class memory, minus eight; for example, if you
	/// specified 24 or more bytes of extra class memory, a value of 16 would be an index to the third integer. To set a value other than
	/// the WNDCLASSEX structure, specify one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GCL_CBCLSEXTRA -20</term>
	/// <term>
	/// Sets the size, in bytes, of the extra memory associated with the class. Setting this value does not change the number of extra
	/// bytes already allocated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCL_CBWNDEXTRA -18</term>
	/// <term>
	/// Sets the size, in bytes, of the extra window memory associated with each window in the class. Setting this value does not change
	/// the number of extra bytes already allocated. For information on how to access this memory, see SetWindowLongPtr.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCLP_ HBRBACKGROUND -10</term>
	/// <term>Replaces a handle to the background brush associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HCURSOR -12</term>
	/// <term>Replaces a handle to the cursor associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HICON -14</term>
	/// <term>Replaces a handle to the icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HICONSM -34</term>
	/// <term>Retrieves a handle to the small icon associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_HMODULE -16</term>
	/// <term>Replaces a handle to the module that registered the class.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_MENUNAME -8</term>
	/// <term>Replaces the pointer to the menu name string. The string identifies the menu resource associated with the class.</term>
	/// </item>
	/// <item>
	/// <term>GCL_STYLE -26</term>
	/// <term>Replaces the window-class style bits.</term>
	/// </item>
	/// <item>
	/// <term>GCLP_WNDPROC -24</term>
	/// <term>Replaces the pointer to the window procedure associated with the class.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwNewLong">
	/// <para>Type: <c>LONG_PTR</c></para>
	/// <para>The replacement value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>Type: <c>ULONG_PTR</c></c></para>
	/// <para>
	/// If the function succeeds, the return value is the previous value of the specified offset. If this was not previously set, the
	/// return value is zero.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If you use the <c>SetClassLongPtr</c> function and the <c>GCLP_WNDPROC</c> index to replace the window procedure, the window
	/// procedure must conform to the guidelines specified in the description of the WindowProc callback function.
	/// </para>
	/// <para>
	/// Calling <c>SetClassLongPtr</c> with the <c>GCLP_WNDPROC</c> index creates a subclass of the window class that affects all windows
	/// subsequently created with the class. An application can subclass a system class, but should not subclass a window class created
	/// by another process.
	/// </para>
	/// <para>
	/// Reserve extra class memory by specifying a nonzero value in the <c>cbClsExtra</c> member of the WNDCLASSEX structure used with
	/// the RegisterClassEx function.
	/// </para>
	/// <para>
	/// Use the <c>SetClassLongPtr</c> function with care. For example, it is possible to change the background color for a class by
	/// using <c>SetClassLongPtr</c>, but this change does not immediately repaint all windows belonging to the class.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setclasslongptra ULONG_PTR SetClassLongPtrA( HWND hWnd,
	// int nIndex, LONG_PTR dwNewLong );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	private static extern IntPtr SetClassLongPtr(HWND hWnd, int nIndex, IntPtr dwNewLong);

	/// <summary>
	/// <para>Contains status information for the application-switching (ALT+TAB) window.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagalttabinfo typedef struct tagALTTABINFO { DWORD cbSize;
	// int cItems; int cColumns; int cRows; int iColFocus; int iRowFocus; int cxItem; int cyItem; POINT ptStart; } ALTTABINFO,
	// *PALTTABINFO, *LPALTTABINFO;
	[PInvokeData("winuser.h", MSDNShortId = "alttabinfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ALTTABINFO
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of the structure. The caller must set this to .</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The number of items in the window.</para>
		/// </summary>
		public int cItems;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The number of columns in the window.</para>
		/// </summary>
		public int cColumns;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The number of rows in the window.</para>
		/// </summary>
		public int cRows;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The column of the item that has the focus.</para>
		/// </summary>
		public int iColFocus;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The row of the item that has the focus.</para>
		/// </summary>
		public int iRowFocus;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The width of each icon in the application-switching window.</para>
		/// </summary>
		public int cxItem;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The height of each icon in the application-switching window.</para>
		/// </summary>
		public int cyItem;

		/// <summary>
		/// <para>Type: <c>POINT</c></para>
		/// <para>The top-left corner of the first icon.</para>
		/// </summary>
		public POINT ptStart;
	}

	/// <summary>
	/// <para>Contains extended result information obtained by calling the ChangeWindowMessageFilterEx function.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Certain messages whose value is smaller than <c>WM_USER</c> are required to pass through the filter, regardless of the filter
	/// setting. There will be no effect when you attempt to use this function to allow or block such messages.
	/// </para>
	/// <para>
	/// An application may use the ChangeWindowMessageFilter function to allow or block a message in a process-wide manner. If the
	/// message is allowed by either the process message filter or the window message filter, it will be delivered to the window.
	/// </para>
	/// <para>The following table lists the possible values returned in <c>ExtStatus</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Message already allowed at higher scope</term>
	/// <term>Message already allowed by window's message filter</term>
	/// <term>Operation requested</term>
	/// <term>Indicator returned in ExtStatus on success</term>
	/// </listheader>
	/// <item>
	/// <term>No</term>
	/// <term>No</term>
	/// <term>MSGFLT_ALLOW</term>
	/// <term>MSGFLTINFO_NONE</term>
	/// </item>
	/// <item>
	/// <term>No</term>
	/// <term>No</term>
	/// <term>MSGFLT_DISALLOW</term>
	/// <term>MSGFLTINFO_ALREADYDISALLOWED_FORWND</term>
	/// </item>
	/// <item>
	/// <term>No</term>
	/// <term>No</term>
	/// <term>MSGFLT_RESET</term>
	/// <term>MSGFLTINFO_NONE</term>
	/// </item>
	/// <item>
	/// <term>No</term>
	/// <term>Yes</term>
	/// <term>MSGFLT_ALLOW</term>
	/// <term>MSGFLTINFO_ALREADYALLOWED_FORWND</term>
	/// </item>
	/// <item>
	/// <term>No</term>
	/// <term>Yes</term>
	/// <term>MSGFLT_DISALLOW</term>
	/// <term>MSGFLTINFO_NONE</term>
	/// </item>
	/// <item>
	/// <term>No</term>
	/// <term>Yes</term>
	/// <term>MSGFLT_RESET</term>
	/// <term>MSGFLTINFO_NONE</term>
	/// </item>
	/// <item>
	/// <term>Yes</term>
	/// <term>No</term>
	/// <term>MSGFLT_ALLOW</term>
	/// <term>MSGFLTINFO_NONE</term>
	/// </item>
	/// <item>
	/// <term>Yes</term>
	/// <term>No</term>
	/// <term>MSGFLT_DISALLOW</term>
	/// <term>MSGFLTINFO_ALLOWED_HIGHER</term>
	/// </item>
	/// <item>
	/// <term>Yes</term>
	/// <term>No</term>
	/// <term>MSGFLT_RESET</term>
	/// <term>MSGFLTINFO_NONE</term>
	/// </item>
	/// <item>
	/// <term>Yes</term>
	/// <term>Yes</term>
	/// <term>MSGFLT_ALLOW</term>
	/// <term>MSGFLTINFO_ALREADYALLOWED_FORWND</term>
	/// </item>
	/// <item>
	/// <term>Yes</term>
	/// <term>Yes</term>
	/// <term>MSGFLT_DISALLOW</term>
	/// <term>MSGFLTINFO_ALLOWED_HIGHER</term>
	/// </item>
	/// <item>
	/// <term>Yes</term>
	/// <term>Yes</term>
	/// <term>MSGFLT_RESET</term>
	/// <term>MSGFLTINFO_NONE</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagchangefilterstruct typedef struct tagCHANGEFILTERSTRUCT
	// { DWORD cbSize; DWORD ExtStatus; } CHANGEFILTERSTRUCT, *PCHANGEFILTERSTRUCT;
	[PInvokeData("winuser.h", MSDNShortId = "changefilterstruct")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CHANGEFILTERSTRUCT
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size of the structure, in bytes. Must be set to , otherwise the function fails with <c>ERROR_INVALID_PARAMETER</c>.</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>If the function succeeds, this field contains one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSGFLTINFO_NONE 0</term>
		/// <term>See the Remarks section. Applies to MSGFLT_ALLOW and MSGFLT_DISALLOW.</term>
		/// </item>
		/// <item>
		/// <term>MSGFLTINFO_ALLOWED_HIGHER 3</term>
		/// <term>The message is allowed at a scope higher than the window. Applies to MSGFLT_DISALLOW.</term>
		/// </item>
		/// <item>
		/// <term>MSGFLTINFO_ALREADYALLOWED_FORWND 1</term>
		/// <term>
		/// The message has already been allowed by this window's message filter, and the function thus succeeded with no change to the
		/// window's message filter. Applies to MSGFLT_ALLOW.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSGFLTINFO_ALREADYDISALLOWED_FORWND 2</term>
		/// <term>
		/// The message has already been blocked by this window's message filter, and the function thus succeeded with no change to the
		/// window's message filter. Applies to MSGFLT_DISALLOW.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public MessageFilterInformation ExtStatus;

		/// <summary>The default value for this structure with the size field set appropriately.</summary>
		public static CHANGEFILTERSTRUCT Default = new() { cbSize = (uint)Marshal.SizeOf(typeof(CHANGEFILTERSTRUCT)) };
	}

	/// <summary>
	/// Defines the initialization parameters passed to the window procedure of an application. These members are identical to the
	/// parameters of the CreateWindowEx function.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Because the <c>lpszClass</c> member can contain a pointer to a local (and thus inaccessable) atom, do not obtain the class name
	/// by using this member. Use the GetClassName function instead.
	/// </para>
	/// <para>
	/// You should access the data represented by the <c>lpCreateParams</c> member using a pointer that has been declared using the
	/// <c>UNALIGNED</c> type, because the pointer may not be <c>DWORD</c> aligned. This is demonstrated in the following example:
	/// </para>
	/// <para>
	/// <code>typedef struct tagMyData { // Define creation data here. } MYDATA; typedef struct tagMyDlgData { SHORT cbExtra; MYDATA myData; } MYDLGDATA, UNALIGNED *PMYDLGDATA; PMYDLGDATA pMyDlgdata = (PMYDLGDATA) (((LPCREATESTRUCT) lParam)-&gt;lpCreateParams);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-createstructa typedef struct tagCREATESTRUCTA { LPVOID
	// lpCreateParams; HINSTANCE hInstance; HMENU hMenu; HWND hwndParent; int cy; int cx; int y; int x; LONG style; LPCSTR lpszName;
	// LPCSTR lpszClass; DWORD dwExStyle; } CREATESTRUCTA, *LPCREATESTRUCTA;
	[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.tagCREATESTRUCTA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CREATESTRUCT
	{
		/// <summary>
		/// <para>Type: <c>LPVOID</c></para>
		/// <para>
		/// Contains additional data which may be used to create the window. If the window is being created as a result of a call to the
		/// CreateWindow or CreateWindowEx function, this member contains the value of the lpParam parameter specified in the function call.
		/// </para>
		/// <para>
		/// If the window being created is a MDI client window, this member contains a pointer to a CLIENTCREATESTRUCT structure. If the
		/// window being created is a MDI child window, this member contains a pointer to an MDICREATESTRUCT structure.
		/// </para>
		/// <para>
		/// If the window is being created from a dialog template, this member is the address of a <c>SHORT</c> value that specifies the
		/// size, in bytes, of the window creation data. The value is immediately followed by the creation data. For more information,
		/// see the following Remarks section.
		/// </para>
		/// </summary>
		public IntPtr lpCreateParams;

		/// <summary>
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>A handle to the module that owns the new window.</para>
		/// </summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// <para>Type: <c>HMENU</c></para>
		/// <para>A handle to the menu to be used by the new window.</para>
		/// </summary>
		public HMENU hMenu;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the parent window, if the window is a child window. If the window is owned, this member identifies the owner
		/// window. If the window is not a child or owned window, this member is <c>NULL</c>.
		/// </para>
		/// </summary>
		public HWND hwndParent;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The height of the new window, in pixels.</para>
		/// </summary>
		public int cy;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The width of the new window, in pixels.</para>
		/// </summary>
		public int cx;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The y-coordinate of the upper left corner of the new window. If the new window is a child window, coordinates are relative
		/// to the parent window. Otherwise, the coordinates are relative to the screen origin.
		/// </para>
		/// </summary>
		public int y;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The x-coordinate of the upper left corner of the new window. If the new window is a child window, coordinates are relative
		/// to the parent window. Otherwise, the coordinates are relative to the screen origin.
		/// </para>
		/// </summary>
		public int x;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>The style for the new window. For a list of possible values, see Window Styles.</para>
		/// </summary>
		public WindowStyles style;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The name of the new window.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszName;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string or an atom that specifies the class name of the new window.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszClass;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The extended window style for the new window. For a list of possible values, see Extended Window Styles.</para>
		/// </summary>
		public WindowStylesEx dwExStyle;
	}

	/// <summary>Contains the flash status for a window and the number of times the system should flash the window.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-flashwinfo typedef struct { UINT cbSize; HWND hwnd; DWORD
	// dwFlags; UINT uCount; DWORD dwTimeout; } FLASHWINFO, *PFLASHWINFO;
	[PInvokeData("winuser.h", MSDNShortId = "b16636bc-fa77-4eb9-9801-dc2cdf0556e5")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct FLASHWINFO
	{
		/// <summary>The size of the structure, in bytes.</summary>
		public uint cbSize;

		/// <summary>A handle to the window to be flashed. The window can be either opened or minimized.</summary>
		public HWND hwnd;

		/// <summary>
		/// <para>The flash status. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FLASHW_ALL 0x00000003</term>
		/// <term>Flash both the window caption and taskbar button. This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.</term>
		/// </item>
		/// <item>
		/// <term>FLASHW_CAPTION 0x00000001</term>
		/// <term>Flash the window caption.</term>
		/// </item>
		/// <item>
		/// <term>FLASHW_STOP 0</term>
		/// <term>Stop flashing. The system restores the window to its original state.</term>
		/// </item>
		/// <item>
		/// <term>FLASHW_TIMER 0x00000004</term>
		/// <term>Flash continuously, until the FLASHW_STOP flag is set.</term>
		/// </item>
		/// <item>
		/// <term>FLASHW_TIMERNOFG 0x0000000C</term>
		/// <term>Flash continuously until the window comes to the foreground.</term>
		/// </item>
		/// <item>
		/// <term>FLASHW_TRAY 0x00000002</term>
		/// <term>Flash the taskbar button.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FLASHW dwFlags;

		/// <summary>The number of times to flash the window.</summary>
		public uint uCount;

		/// <summary>
		/// The rate at which the window is to be flashed, in milliseconds. If <c>dwTimeout</c> is zero, the function uses the default
		/// cursor blink rate.
		/// </summary>
		public uint dwTimeout;
	}

	/// <summary>
	/// <para>Contains information about a GUI thread.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// This structure is used with the GetGUIThreadInfo function to retrieve information about the active window or a specified GUI thread.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagguithreadinfo typedef struct tagGUITHREADINFO { DWORD
	// cbSize; DWORD flags; HWND hwndActive; HWND hwndFocus; HWND hwndCapture; HWND hwndMenuOwner; HWND hwndMoveSize; HWND hwndCaret;
	// RECT rcCaret; } GUITHREADINFO, *PGUITHREADINFO, *LPGUITHREADINFO;
	[PInvokeData("winuser.h", MSDNShortId = "guithreadinfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct GUITHREADINFO
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size of this structure, in bytes. The caller must set this member to .</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The thread state. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GUI_CARETBLINKING 0x00000001</term>
		/// <term>The caret's blink state. This bit is set if the caret is visible.</term>
		/// </item>
		/// <item>
		/// <term>GUI_INMENUMODE 0x00000004</term>
		/// <term>The thread's menu state. This bit is set if the thread is in menu mode.</term>
		/// </item>
		/// <item>
		/// <term>GUI_INMOVESIZE 0x00000002</term>
		/// <term>The thread's move state. This bit is set if the thread is in a move or size loop.</term>
		/// </item>
		/// <item>
		/// <term>GUI_POPUPMENUMODE 0x00000010</term>
		/// <term>The thread's pop-up menu state. This bit is set if the thread has an active pop-up menu.</term>
		/// </item>
		/// <item>
		/// <term>GUI_SYSTEMMENUMODE 0x00000008</term>
		/// <term>The thread's system menu state. This bit is set if the thread is in a system menu mode.</term>
		/// </item>
		/// </list>
		/// </summary>
		public GUIThreadInfoFlags flags;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the active window within the thread.</para>
		/// </summary>
		public HWND hwndActive;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window that has the keyboard focus.</para>
		/// </summary>
		public HWND hwndFocus;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window that has captured the mouse.</para>
		/// </summary>
		public HWND hwndCapture;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window that owns any active menus.</para>
		/// </summary>
		public HWND hwndMenuOwner;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window in a move or size loop.</para>
		/// </summary>
		public HWND hwndMoveSize;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window that is displaying the caret.</para>
		/// </summary>
		public HWND hwndCaret;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>The caret's bounding rectangle, in client coordinates, relative to the window specified by the <c>hwndCaret</c> member.</para>
		/// </summary>
		public RECT rcCaret;
	}

	/// <summary>
	/// <para>Contains title bar information.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagtitlebarinfo typedef struct tagTITLEBARINFO { DWORD
	// cbSize; RECT rcTitleBar; DWORD rgstate[CCHILDREN_TITLEBAR + 1]; } TITLEBARINFO, *PTITLEBARINFO, *LPTITLEBARINFO;
	[PInvokeData("winuser.h", MSDNShortId = "titlebarinfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TITLEBARINFO
	{
		/// <summary>The size, in bytes, of the structure. The caller must set this member to sizeof(TITLEBARINFO).</summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>The coordinates of the title bar. These coordinates include all title-bar elements except the window menu.</para>
		/// </summary>
		public RECT rcTitleBar;

		/// <summary>
		/// <para>Type: <c>DWORD[CCHILDREN_TITLEBAR+1]</c></para>
		/// <para>
		/// An array that receives a value for each element of the title bar. The following are the title bar elements represented by the array.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Index</term>
		/// <term>Title Bar Element</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The title bar itself.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>Minimize button.</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Maximize button.</term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>Help button.</term>
		/// </item>
		/// <item>
		/// <term>5</term>
		/// <term>Close button.</term>
		/// </item>
		/// </list>
		/// <para>Each array element is a combination of one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STATE_SYSTEM_FOCUSABLE 0x00100000</term>
		/// <term>The element can accept the focus.</term>
		/// </item>
		/// <item>
		/// <term>STATE_SYSTEM_INVISIBLE 0x00008000</term>
		/// <term>The element is invisible.</term>
		/// </item>
		/// <item>
		/// <term>STATE_SYSTEM_OFFSCREEN 0x00010000</term>
		/// <term>The element has no visible representation.</term>
		/// </item>
		/// <item>
		/// <term>STATE_SYSTEM_UNAVAILABLE 0x00000001</term>
		/// <term>The element is unavailable.</term>
		/// </item>
		/// <item>
		/// <term>STATE_SYSTEM_PRESSED 0x00000008</term>
		/// <term>The element is in the pressed state.</term>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U4, SizeConst = CCHILDREN_TITLEBAR + 1)]
		public ObjectState[] rgstate;
	}

	/// <summary>
	/// <para>
	/// Used by UpdateLayeredWindowIndirect to provide position, size, shape, content, and translucency information for a layered window.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagupdatelayeredwindowinfo typedef struct
	// tagUPDATELAYEREDWINDOWINFO { DWORD cbSize; HDC hdcDst; const POINT *pptDst; const SIZE *psize; HDC hdcSrc; const POINT *pptSrc;
	// COLORREF crKey; const BLENDFUNCTION *pblend; DWORD dwFlags; const RECT *prcDirty; } UPDATELAYEREDWINDOWINFO, *PUPDATELAYEREDWINDOWINFO;
	[PInvokeData("winuser.h", MSDNShortId = "updatelayeredwindowinfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UPDATELAYEREDWINDOWINFO
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of this structure.</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>HDC</c></para>
		/// <para>
		/// A handle to a DC for the screen. This handle is obtained by specifying <c>NULL</c> in this member when calling
		/// UpdateLayeredWindowIndirect. The handle is used for palette color matching when the window contents are updated. If
		/// <c>hdcDst</c> is <c>NULL</c>, the default palette is used.
		/// </para>
		/// <para>If <c>hdcSrc</c> is <c>NULL</c>, <c>hdcDst</c> must be <c>NULL</c>.</para>
		/// </summary>
		public HDC hdcDst;

		/// <summary>
		/// <para>Type: <c>const POINT*</c></para>
		/// <para>
		/// The new screen position of the layered window. If the new position is unchanged from the current position, <c>pptDst</c> can
		/// be <c>NULL</c>.
		/// </para>
		/// </summary>
		public IntPtr pptDst;

		/// <summary>
		/// <para>Type: <c>const SIZE*</c></para>
		/// <para>
		/// The new size of the layered window. If the size of the window will not change, this parameter can be <c>NULL</c>. If
		/// <c>hdcSrc</c> is <c>NULL</c>, <c>psize</c> must be <c>NULL</c>.
		/// </para>
		/// </summary>
		public IntPtr psize;

		/// <summary>
		/// <para>Type: <c>HDC</c></para>
		/// <para>
		/// A handle to the DC for the surface that defines the layered window. This handle can be obtained by calling the
		/// CreateCompatibleDC function. If the shape and visual context of the window will not change, <c>hdcSrc</c> can be <c>NULL</c>.
		/// </para>
		/// </summary>
		public HDC hdcSrc;

		/// <summary>
		/// <para>Type: <c>const POINT*</c></para>
		/// <para>The location of the layer in the device context. If <c>hdcSrc</c> is <c>NULL</c>, <c>pptSrc</c> should be <c>NULL</c>.</para>
		/// </summary>
		public IntPtr pptSrc;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>The color key to be used when composing the layered window. To generate a COLORREF, use the RGB macro.</para>
		/// </summary>
		public COLORREF crKey;

		/// <summary>
		/// <para>Type: <c>const BLENDFUNCTION*</c></para>
		/// <para>The transparency value to be used when composing the layered window.</para>
		/// </summary>
		public IntPtr pblend;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ULW_ALPHA 0x00000002</term>
		/// <term>
		/// Use pblend as the blend function. If the display mode is 256 colors or less, the effect of this value is the same as the
		/// effect of ULW_OPAQUE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ULW_COLORKEY 0x00000001</term>
		/// <term>Use crKey as the transparency color.</term>
		/// </item>
		/// <item>
		/// <term>ULW_OPAQUE 0x00000004</term>
		/// <term>Draw an opaque layered window.</term>
		/// </item>
		/// <item>
		/// <term>ULW_EX_NORESIZE 0x00000008</term>
		/// <term>
		/// Force the UpdateLayeredWindowIndirect function to fail if the current window size does not match the size specified in the psize.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If <c>hdcSrc</c> is <c>NULL</c>, <c>dwFlags</c> should be zero.</para>
		/// </summary>
		public uint dwFlags;

		/// <summary>
		/// <para>Type: <c>const RECT*</c></para>
		/// <para>
		/// The area to be updated. This parameter can be <c>NULL</c>. If it is non-NULL, only the area in this rectangle is updated from
		/// the source DC.
		/// </para>
		/// </summary>
		public IntPtr prcDirty;
	}

	/// <summary>
	/// <para>Contains window information.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagwindowinfo typedef struct tagWINDOWINFO { DWORD cbSize;
	// RECT rcWindow; RECT rcClient; DWORD dwStyle; DWORD dwExStyle; DWORD dwWindowStatus; UINT cxWindowBorders; UINT cyWindowBorders;
	// ATOM atomWindowType; WORD wCreatorVersion; } WINDOWINFO, *PWINDOWINFO, *LPWINDOWINFO;
	[PInvokeData("winuser.h", MSDNShortId = "windowinfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINDOWINFO
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size of the structure, in bytes. The caller must set this member to .</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>The coordinates of the window.</para>
		/// </summary>
		public RECT rcWindow;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>The coordinates of the client area.</para>
		/// </summary>
		public RECT rcClient;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The window styles. For a table of window styles, see Window Styles.</para>
		/// </summary>
		public WindowStyles dwStyle;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The extended window styles. For a table of extended window styles, see Extended Window Styles.</para>
		/// </summary>
		public WindowStylesEx dwExStyle;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The window status. If this member is <c>WS_ACTIVECAPTION</c> (0x0001), the window is active. Otherwise, this member is zero.
		/// </para>
		/// </summary>
		public uint dwWindowStatus;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width of the window border, in pixels.</para>
		/// </summary>
		public uint cxWindowBorders;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The height of the window border, in pixels.</para>
		/// </summary>
		public uint cyWindowBorders;

		/// <summary>
		/// <para>Type: <c>ATOM</c></para>
		/// <para>The window class atom (see RegisterClass).</para>
		/// </summary>
		public ushort atomWindowType;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>The Windows version of the application that created the window.</para>
		/// </summary>
		public ushort wCreatorVersion;
	}

	/// <summary>
	/// <para>Contains information about the placement of a window on the screen.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// If the window is a top-level window that does not have the <c>WS_EX_TOOLWINDOW</c> window style, then the coordinates represented
	/// by the following members are in workspace coordinates: <c>ptMinPosition</c>, <c>ptMaxPosition</c>, and <c>rcNormalPosition</c>.
	/// Otherwise, these members are in screen coordinates.
	/// </para>
	/// <para>
	/// Workspace coordinates differ from screen coordinates in that they take the locations and sizes of application toolbars (including
	/// the taskbar) into account. Workspace coordinate (0,0) is the upper-left corner of the workspace area, the area of the screen not
	/// being used by application toolbars.
	/// </para>
	/// <para>
	/// The coordinates used in a <c>WINDOWPLACEMENT</c> structure should be used only by the GetWindowPlacement and SetWindowPlacement
	/// functions. Passing workspace coordinates to functions which expect screen coordinates (such as SetWindowPos) will result in the
	/// window appearing in the wrong location. For example, if the taskbar is at the top of the screen, saving window coordinates using
	/// <c>GetWindowPlacement</c> and restoring them using <c>SetWindowPos</c> causes the window to appear to "creep" up the screen.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagwindowplacement typedef struct tagWINDOWPLACEMENT {
	// UINT length; UINT flags; UINT showCmd; POINT ptMinPosition; POINT ptMaxPosition; RECT rcNormalPosition; RECT rcDevice; } WINDOWPLACEMENT;
	[PInvokeData("winuser.h", MSDNShortId = "windowplacement")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINDOWPLACEMENT
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The length of the structure, in bytes. Before calling the GetWindowPlacement or SetWindowPlacement functions, set this member
		/// to .
		/// </para>
		/// <para>GetWindowPlacement and SetWindowPlacement fail if this member is not set correctly.</para>
		/// </summary>
		public uint length;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The flags that control the position of the minimized window and the method by which the window is restored. This member can
		/// be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WPF_ASYNCWINDOWPLACEMENT 0x0004</term>
		/// <term>
		/// If the calling thread and the thread that owns the window are attached to different input queues, the system posts the
		/// request to the thread that owns the window. This prevents the calling thread from blocking its execution while other threads
		/// process the request.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WPF_RESTORETOMAXIMIZED 0x0002</term>
		/// <term>
		/// The restored window will be maximized, regardless of whether it was maximized before it was minimized. This setting is only
		/// valid the next time the window is restored. It does not change the default restoration behavior. This flag is only valid when
		/// the SW_SHOWMINIMIZED value is specified for the showCmd member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WPF_SETMINPOSITION 0x0001</term>
		/// <term>
		/// The coordinates of the minimized window may be specified. This flag must be specified if the coordinates are set in the
		/// ptMinPosition member.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public WindowPlacementFlags flags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The current show state of the window. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SW_HIDE 0</term>
		/// <term>Hides the window and activates another window.</term>
		/// </item>
		/// <item>
		/// <term>SW_MAXIMIZE 3</term>
		/// <term>Maximizes the specified window.</term>
		/// </item>
		/// <item>
		/// <term>SW_MINIMIZE 6</term>
		/// <term>Minimizes the specified window and activates the next top-level window in the z-order.</term>
		/// </item>
		/// <item>
		/// <term>SW_RESTORE 9</term>
		/// <term>
		/// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and
		/// position. An application should specify this flag when restoring a minimized window.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SW_SHOW 5</term>
		/// <term>Activates the window and displays it in its current size and position.</term>
		/// </item>
		/// <item>
		/// <term>SW_SHOWMAXIMIZED 3</term>
		/// <term>Activates the window and displays it as a maximized window.</term>
		/// </item>
		/// <item>
		/// <term>SW_SHOWMINIMIZED 2</term>
		/// <term>Activates the window and displays it as a minimized window.</term>
		/// </item>
		/// <item>
		/// <term>SW_SHOWMINNOACTIVE 7</term>
		/// <term>Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.</term>
		/// </item>
		/// <item>
		/// <term>SW_SHOWNA 8</term>
		/// <term>Displays the window in its current size and position. This value is similar to SW_SHOW, except the window is not activated.</term>
		/// </item>
		/// <item>
		/// <term>SW_SHOWNOACTIVATE 4</term>
		/// <term>
		/// Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except the window is not activated.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SW_SHOWNORMAL 1</term>
		/// <term>
		/// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and
		/// position. An application should specify this flag when displaying the window for the first time.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ShowWindowCommand showCmd;

		/// <summary>
		/// <para>Type: <c>POINT</c></para>
		/// <para>The coordinates of the window's upper-left corner when the window is minimized.</para>
		/// </summary>
		public POINT ptMinPosition;

		/// <summary>
		/// <para>Type: <c>POINT</c></para>
		/// <para>The coordinates of the window's upper-left corner when the window is maximized.</para>
		/// </summary>
		public POINT ptMaxPosition;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>The window's coordinates when the window is in the restored position.</para>
		/// </summary>
		public RECT rcNormalPosition;

#if _MAC
		/// <summary/>
		public RECT rcDevice;
#endif
	}

	/// <summary>
	/// <para>Contains the window class attributes that are registered by the RegisterClass function.</para>
	/// <para>
	/// This structure has been superseded by the WNDCLASSEX structure used with the RegisterClassEx function. You can still use
	/// <c>WNDCLASS</c> and RegisterClass if you do not need to set the small icon associated with the window class.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagwndclassa typedef struct tagWNDCLASSA { UINT style;
	// WNDPROC lpfnWndProc; int cbClsExtra; int cbWndExtra; HINSTANCE hInstance; HICON hIcon; HCURSOR hCursor; HBRUSH hbrBackground;
	// LPCSTR lpszMenuName; LPCSTR lpszClassName; } WNDCLASSA, *PWNDCLASSA, *NPWNDCLASSA, *LPWNDCLASSA;
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WNDCLASS
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The class style(s). This member can be any combination of the Class Styles.</para>
		/// </summary>
		public WindowClassStyles style;

		/// <summary>
		/// <para>Type: <c>WNDPROC</c></para>
		/// <para>
		/// A pointer to the window procedure. You must use the CallWindowProc function to call the window procedure. For more
		/// information, see WindowProc.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public WindowProc lpfnWndProc;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The number of extra bytes to allocate following the window-class structure. The system initializes the bytes to zero.</para>
		/// </summary>
		public int cbClsExtra;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The number of extra bytes to allocate following the window instance. The system initializes the bytes to zero. If an
		/// application uses <c>WNDCLASS</c> to register a dialog box created by using the <c>CLASS</c> directive in the resource file,
		/// it must set this member to <c>DLGWINDOWEXTRA</c>.
		/// </para>
		/// </summary>
		public int cbWndExtra;

		/// <summary>
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>A handle to the instance that contains the window procedure for the class.</para>
		/// </summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// <para>Type: <c>HICON</c></para>
		/// <para>
		/// A handle to the class icon. This member must be a handle to an icon resource. If this member is <c>NULL</c>, the system
		/// provides a default icon.
		/// </para>
		/// </summary>
		public HICON hIcon;

		/// <summary>
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>
		/// A handle to the class cursor. This member must be a handle to a cursor resource. If this member is <c>NULL</c>, an
		/// application must explicitly set the cursor shape whenever the mouse moves into the application's window.
		/// </para>
		/// </summary>
		public HCURSOR hCursor;

		/// <summary>
		/// <para>Type: <c>HBRUSH</c></para>
		/// <para>
		/// A handle to the class background brush. This member can be a handle to the physical brush to be used for painting the
		/// background, or it can be a color value. A color value must be one of the following standard system colors (the value 1 must
		/// be added to the chosen color found in <see cref="SystemColorIndex"/>). If a color value is given, you must convert it to one
		/// of the following <c>HBRUSH</c> types:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>COLOR_ACTIVEBORDER</term>
		/// </item>
		/// <item>
		/// <term>COLOR_ACTIVECAPTION</term>
		/// </item>
		/// <item>
		/// <term>COLOR_APPWORKSPACE</term>
		/// </item>
		/// <item>
		/// <term>COLOR_BACKGROUND</term>
		/// </item>
		/// <item>
		/// <term>COLOR_BTNFACE</term>
		/// </item>
		/// <item>
		/// <term>COLOR_BTNSHADOW</term>
		/// </item>
		/// <item>
		/// <term>COLOR_BTNTEXT</term>
		/// </item>
		/// <item>
		/// <term>COLOR_CAPTIONTEXT</term>
		/// </item>
		/// <item>
		/// <term>COLOR_GRAYTEXT</term>
		/// </item>
		/// <item>
		/// <term>COLOR_HIGHLIGHT</term>
		/// </item>
		/// <item>
		/// <term>COLOR_HIGHLIGHTTEXT</term>
		/// </item>
		/// <item>
		/// <term>COLOR_INACTIVEBORDER</term>
		/// </item>
		/// <item>
		/// <term>COLOR_INACTIVECAPTION</term>
		/// </item>
		/// <item>
		/// <term>COLOR_MENU</term>
		/// </item>
		/// <item>
		/// <term>COLOR_MENUTEXT</term>
		/// </item>
		/// <item>
		/// <term>COLOR_SCROLLBAR</term>
		/// </item>
		/// <item>
		/// <term>COLOR_WINDOW</term>
		/// </item>
		/// <item>
		/// <term>COLOR_WINDOWFRAME</term>
		/// </item>
		/// <item>
		/// <term>COLOR_WINDOWTEXT</term>
		/// </item>
		/// </list>
		/// <para>The system automatically deletes class background brushes when the class is unregistered by using</para>
		/// <para>UnregisterClass</para>
		/// <para>. An application should not delete these brushes.</para>
		/// <para>
		/// When this member is <c>NULL</c>, an application must paint its own background whenever it is requested to paint in its
		/// client area. To determine whether the background must be painted, an application can either process the WM_ERASEBKGND
		/// message or test the <c>fErase</c> member of the PAINTSTRUCT structure filled by the BeginPaint function.
		/// </para>
		/// </summary>
		public HBRUSH hbrBackground;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The resource name of the class menu, as the name appears in the resource file. If you use an integer to identify the menu,
		/// use the MAKEINTRESOURCE macro. If this member is <c>NULL</c>, windows belonging to this class have no default menu.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszMenuName;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string or is an atom. If this parameter is an atom, it must be a class atom created by a
		/// previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of
		/// <c>lpszClassName</c>; the high-order word must be zero.
		/// </para>
		/// <para>
		/// If <c>lpszClassName</c> is a string, it specifies the window class name. The class name can be any name registered with
		/// RegisterClass or RegisterClassEx, or any of the predefined control-class names.
		/// </para>
		/// <para>
		/// The maximum length for <c>lpszClassName</c> is 256. If <c>lpszClassName</c> is greater than the maximum length, the
		/// RegisterClass function will fail.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszClassName;
	}

	/// <summary>
	/// <para>Contains window class information. It is used with the RegisterClassEx and GetClassInfoEx functions.</para>
	/// <para>
	/// The <c>WNDCLASSEX</c> structure is similar to the WNDCLASS structure. There are two differences. <c>WNDCLASSEX</c> includes the
	/// <c>cbSize</c> member, which specifies the size of the structure, and the <c>hIconSm</c> member, which contains a handle to a
	/// small icon associated with the window class.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagwndclassexa typedef struct tagWNDCLASSEXA { UINT
	// cbSize; UINT style; WNDPROC lpfnWndProc; int cbClsExtra; int cbWndExtra; HINSTANCE hInstance; HICON hIcon; HCURSOR hCursor; HBRUSH
	// hbrBackground; LPCSTR lpszMenuName; LPCSTR lpszClassName; HICON hIconSm; } WNDCLASSEXA, *PWNDCLASSEXA, *NPWNDCLASSEXA, *LPWNDCLASSEXA;
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WNDCLASSEX
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The size, in bytes, of this structure. Set this member to . Be sure to set this member before calling the GetClassInfoEx function.
		/// </para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The class style(s). This member can be any combination of the Class Styles.</para>
		/// </summary>
		public WindowClassStyles style;

		/// <summary>
		/// <para>Type: <c>WNDPROC</c></para>
		/// <para>
		/// A pointer to the window procedure. You must use the CallWindowProc function to call the window procedure. For more
		/// information, see WindowProc.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public WindowProc? lpfnWndProc;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The number of extra bytes to allocate following the window-class structure. The system initializes the bytes to zero.</para>
		/// </summary>
		public int cbClsExtra;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The number of extra bytes to allocate following the window instance. The system initializes the bytes to zero. If an
		/// application uses <c>WNDCLASSEX</c> to register a dialog box created by using the <c>CLASS</c> directive in the resource file,
		/// it must set this member to <c>DLGWINDOWEXTRA</c>.
		/// </para>
		/// </summary>
		public int cbWndExtra;

		/// <summary>
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>A handle to the instance that contains the window procedure for the class.</para>
		/// </summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// <para>Type: <c>HICON</c></para>
		/// <para>
		/// A handle to the class icon. This member must be a handle to an icon resource. If this member is <c>NULL</c>, the system
		/// provides a default icon.
		/// </para>
		/// </summary>
		public HICON hIcon;

		/// <summary>
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>
		/// A handle to the class cursor. This member must be a handle to a cursor resource. If this member is <c>NULL</c>, an
		/// application must explicitly set the cursor shape whenever the mouse moves into the application's window.
		/// </para>
		/// </summary>
		public HCURSOR hCursor;

		/// <summary>
		/// <para>Type: <c>HBRUSH</c></para>
		/// <para>
		/// A handle to the class background brush. This member can be a handle to the brush to be used for painting the background, or
		/// it can be a color value. A color value must be one of the following standard system colors (the value 1 must be added to the
		/// chosen color). If a color value is given, you must convert it to one of the following <c>HBRUSH</c> types:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>COLOR_ACTIVEBORDER</term>
		/// </item>
		/// <item>
		/// <term>COLOR_ACTIVECAPTION</term>
		/// </item>
		/// <item>
		/// <term>COLOR_APPWORKSPACE</term>
		/// </item>
		/// <item>
		/// <term>COLOR_BACKGROUND</term>
		/// </item>
		/// <item>
		/// <term>COLOR_BTNFACE</term>
		/// </item>
		/// <item>
		/// <term>COLOR_BTNSHADOW</term>
		/// </item>
		/// <item>
		/// <term>COLOR_BTNTEXT</term>
		/// </item>
		/// <item>
		/// <term>COLOR_CAPTIONTEXT</term>
		/// </item>
		/// <item>
		/// <term>COLOR_GRAYTEXT</term>
		/// </item>
		/// <item>
		/// <term>COLOR_HIGHLIGHT</term>
		/// </item>
		/// <item>
		/// <term>COLOR_HIGHLIGHTTEXT</term>
		/// </item>
		/// <item>
		/// <term>COLOR_INACTIVEBORDER</term>
		/// </item>
		/// <item>
		/// <term>COLOR_INACTIVECAPTION</term>
		/// </item>
		/// <item>
		/// <term>COLOR_MENU</term>
		/// </item>
		/// <item>
		/// <term>COLOR_MENUTEXT</term>
		/// </item>
		/// <item>
		/// <term>COLOR_SCROLLBAR</term>
		/// </item>
		/// <item>
		/// <term>COLOR_WINDOW</term>
		/// </item>
		/// <item>
		/// <term>COLOR_WINDOWFRAME</term>
		/// </item>
		/// <item>
		/// <term>COLOR_WINDOWTEXT</term>
		/// </item>
		/// </list>
		/// <para>The system automatically deletes class background brushes when the class is unregistered by using</para>
		/// <para>UnregisterClass</para>
		/// <para>. An application should not delete these brushes.</para>
		/// <para>
		/// When this member is <c>NULL</c>, an application must paint its own background whenever it is requested to paint in its client
		/// area. To determine whether the background must be painted, an application can either process the WM_ERASEBKGND message or
		/// test the <c>fErase</c> member of the PAINTSTRUCT structure filled by the BeginPaint function.
		/// </para>
		/// </summary>
		public HBRUSH hbrBackground;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// Pointer to a null-terminated character string that specifies the resource name of the class menu, as the name appears in the
		/// resource file. If you use an integer to identify the menu, use the MAKEINTRESOURCE macro. If this member is <c>NULL</c>,
		/// windows belonging to this class have no default menu.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpszMenuName;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string or is an atom. If this parameter is an atom, it must be a class atom created by a
		/// previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of
		/// <c>lpszClassName</c>; the high-order word must be zero.
		/// </para>
		/// <para>
		/// If <c>lpszClassName</c> is a string, it specifies the window class name. The class name can be any name registered with
		/// RegisterClass or RegisterClassEx, or any of the predefined control-class names.
		/// </para>
		/// <para>
		/// The maximum length for <c>lpszClassName</c> is 256. If <c>lpszClassName</c> is greater than the maximum length, the
		/// RegisterClassEx function will fail.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszClassName;

		/// <summary>
		/// <para>Type: <c>HICON</c></para>
		/// <para>
		/// A handle to a small icon that is associated with the window class. If this member is <c>NULL</c>, the system searches the
		/// icon resource specified by the <c>hIcon</c> member for an icon of the appropriate size to use as the small icon.
		/// </para>
		/// </summary>
		public HICON hIconSm;
	}

	/// <summary>
	/// <para>Contains window class information. It is used with the RegisterClassEx and GetClassInfoEx functions.</para>
	/// <para>
	/// The <c>WNDCLASSEX</c> structure is similar to the WNDCLASS structure. There are two differences. <c>WNDCLASSEX</c> includes the
	/// <c>cbSize</c> member, which specifies the size of the structure, and the <c>hIconSm</c> member, which contains a handle to a
	/// small icon associated with the window class.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagwndclassexa typedef struct tagWNDCLASSEXA { UINT
	// cbSize; UINT style; WNDPROC lpfnWndProc; int cbClsExtra; int cbWndExtra; HINSTANCE hInstance; HICON hIcon; HCURSOR hCursor; HBRUSH
	// hbrBackground; LPCSTR lpszMenuName; LPCSTR lpszClassName; HICON hIconSm; } WNDCLASSEXA, *PWNDCLASSEXA, *NPWNDCLASSEXA, *LPWNDCLASSEXA;
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	private struct WNDCLASSEXB
	{
		public uint cbSize;

		public WindowClassStyles style;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		public WindowProc? lpfnWndProc;

		public int cbClsExtra;

		public int cbWndExtra;

		public HINSTANCE hInstance;

		public HICON hIcon;

		public HCURSOR hCursor;

		public HBRUSH hbrBackground;

		public StrPtrAuto lpszMenuName;

		public StrPtrAuto lpszClassName;

		public HICON hIconSm;

		public WNDCLASSEXB() => cbSize = (uint)Marshal.SizeOf(typeof(WNDCLASSEXB));

		public static implicit operator WNDCLASSEX(WNDCLASSEXB wc) => new()
		{
			cbSize = wc.cbSize,
			style = wc.style,
			lpszMenuName = wc.lpszMenuName,
			lpszClassName = ((string?)wc.lpszClassName) ?? "",
			hIconSm = wc.hIconSm,
			hCursor = wc.hCursor,
			hbrBackground = wc.hbrBackground,
			hIcon = wc.hIcon,
			hInstance = wc.hInstance,
			cbClsExtra = wc.cbClsExtra,
			cbWndExtra = wc.cbWndExtra,
			lpfnWndProc = wc.lpfnWndProc,
		};
	}

	/// <summary>
	/// Provides a <see cref="SafeHandle"/> to a window or dialog that releases a created HWND instance at disposal using DestroyWindow.
	/// </summary>
	public class SafeHWND : SafeHANDLE, IUserHandle
	{
		/// <summary>Initializes a new instance of the <see cref="HWND"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHWND(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		private SafeHWND() : base()
		{
		}

		/// <summary>Performs an implicit conversion from <see cref="SafeHWND"/> to <see cref="HWND"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HWND(SafeHWND h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle()
		{
			var hp = GetAncestor(this, GetAncestorFlag.GA_ROOT);
			if (hp != this) return true;
			return DestroyWindow(this);
		}
	}

	/*GET_APPCOMMAND_LPARAM macro
	GET_DEVICE_LPARAM macro
	GET_FLAGS_LPARAM macro
	GET_KEYSTATE_LPARAM macro
	GET_KEYSTATE_WPARAM macro
	GET_NCHITTEST_WPARAM macro
	GET_RAWINPUT_CODE_WPARAM macro
	GET_WHEEL_DELTA_WPARAM macro
	GET_XBUTTON_WPARAM macro*/
}