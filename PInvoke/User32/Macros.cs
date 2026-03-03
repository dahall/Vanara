namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>Provides the default dialog procedure for a window, processing messages sent to the dialog box and returning the result.</summary>
	/// <remarks>
	/// This method is typically used when implementing custom dialog procedures that require default message handling. It sets <paramref
	/// name="pfRecursion"/> to <see langword="true"/> to indicate recursive invocation, which can be useful for preventing re-entrancy issues.
	/// </remarks>
	/// <param name="hwnd">A handle to the dialog box window for which the message is being processed.</param>
	/// <param name="msg">The message identifier specifying the type of message to process.</param>
	/// <param name="wParam">Additional message-specific information. The meaning varies depending on the value of <paramref name="msg"/>.</param>
	/// <param name="lParam">Additional message-specific information. The meaning varies depending on the value of <paramref name="msg"/>.</param>
	/// <param name="pfRecursion">
	/// A reference to a Boolean value that is set to <see langword="true"/> if the function is called recursively. The caller can use this
	/// to detect recursion in message processing.
	/// </param>
	/// <returns>
	/// An <see cref="IntPtr"/> value that represents the result of the message processing. The return value depends on the message handled.
	/// </returns>
	public static IntPtr DefDlgProcEx([In] HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam, ref bool pfRecursion) { pfRecursion = true; return DefDlgProc(hwnd, msg, wParam, lParam); }

	/// <summary>Retrieves a handle to the first child window of the specified parent window.</summary>
	/// <remarks>
	/// The returned handle can be used in subsequent window operations. If the specified window has no child windows, the method returns
	/// <see langword="null"/>.
	/// </remarks>
	/// <param name="hwnd">A handle to the parent window whose first child window is to be retrieved.</param>
	/// <returns>
	/// A handle to the first child window of the specified parent window, or <see langword="null"/> if the parent window has no child windows.
	/// </returns>
	public static HWND GetFirstChild([In, AddAsMember] HWND hwnd) => GetTopWindow(hwnd);

	/// <summary>Retrieves the handle to the first sibling window in the Z-order for the specified window.</summary>
	/// <remarks>
	/// Sibling windows share the same parent. This method can be used to enumerate windows at the same level in the window hierarchy. The
	/// returned handle may be <see cref="HWND.NULL"/> if the window has no siblings or if the parent is not set.
	/// </remarks>
	/// <param name="hwnd">The handle to the window whose first sibling is to be retrieved. Must be a valid window handle.</param>
	/// <returns>
	/// A handle to the first sibling window in the Z-order. Returns <see cref="HWND.NULL"/> if there are no sibling windows or if the
	/// specified window handle is invalid.
	/// </returns>
	public static HWND GetFirstSibling([In, AddAsMember] HWND hwnd) => GetWindow(hwnd, GetWindowCmd.GW_HWNDFIRST);

	/// <summary>Retrieves a handle to the last sibling window in the Z-order for the specified window.</summary>
	/// <remarks>
	/// Sibling windows are child windows that share the same parent. This method is useful for navigating window hierarchies in native
	/// Windows applications.
	/// </remarks>
	/// <param name="hwnd">A handle to the window whose last sibling is to be retrieved. This window must be a child window.</param>
	/// <returns>
	/// A handle to the last sibling window in the Z-order. Returns <see cref="HWND.NULL"/> if the specified window has no siblings or if an
	/// error occurs.
	/// </returns>
	public static HWND GetLastSibling([In, AddAsMember] HWND hwnd) => GetWindow(hwnd, GetWindowCmd.GW_HWNDLAST);

	/// <summary>Retrieves the handle of the next sibling window in the Z-order relative to the specified window.</summary>
	/// <remarks>
	/// The Z-order determines the visual stacking of windows. This method can be used to iterate through windows at the same level. The
	/// returned handle may be <see cref="HWND.NULL"/> if the specified window is the last in the Z-order or if the handle is invalid.
	/// </remarks>
	/// <param name="hwnd">The handle to a window whose next sibling window is to be retrieved. Must be a valid window handle.</param>
	/// <returns>A handle to the next sibling window in the Z-order. Returns <see cref="HWND.NULL"/> if there is no next sibling.</returns>
	public static HWND GetNextSibling([In, AddAsMember] HWND hwnd) => GetWindow(hwnd, GetWindowCmd.GW_HWNDNEXT);

	/// <summary>Retrieves the handle of the previous sibling window in the Z-order relative to the specified window.</summary>
	/// <remarks>
	/// This method is useful for navigating window relationships in the Z-order. The returned handle may be <see cref="HWND.NULL"/> if the
	/// specified window is the first in the Z-order or does not have a sibling.
	/// </remarks>
	/// <param name="hwnd">The handle to the window whose previous sibling is to be retrieved.</param>
	/// <returns>
	/// The handle to the previous sibling window. Returns <see cref="HWND.NULL"/> if there is no previous sibling or if the specified window
	/// is not valid.
	/// </returns>
	public static HWND GetPrevSibling([In, AddAsMember] HWND hwnd) => GetWindow(hwnd, GetWindowCmd.GW_HWNDPREV);

	/// <summary>Retrieves the extended window style flags for the specified window.</summary>
	/// <remarks>
	/// The extended window style flags define additional behaviors and appearance options for a window, such as transparency, tool window
	/// status, and more. Use this method to query these flags for a given window handle.
	/// </remarks>
	/// <param name="hwnd">A handle to the window whose extended style flags are to be retrieved. Must be a valid window handle.</param>
	/// <returns>A value of type WindowStylesEx representing the extended style flags of the specified window.</returns>
	public static WindowStylesEx GetWindowExStyle([In, AddAsMember] HWND hwnd) => GetWindowLong<WindowStylesEx>(hwnd, WindowLongFlags.GWL_EXSTYLE);

	/// <summary>Retrieves the handle to the font used by the specified window.</summary>
	/// <remarks>
	/// The returned font handle can be used in GDI operations that require a font. The caller is not responsible for releasing the font handle.
	/// </remarks>
	/// <param name="hwnd">The handle to the window whose font is to be retrieved. Must be a valid window handle.</param>
	/// <returns>
	/// A handle to the font currently used by the window. Returns <see langword="null"/> if the window does not have a font set.
	/// </returns>
	public static HFONT GetWindowFont([In, AddAsMember] HWND hwnd) => (HFONT)SendMessage(hwnd, WindowMessage.WM_GETFONT);

	/// <summary>Retrieves the identifier of the specified window control.</summary>
	/// <remarks>
	/// This method is typically used to obtain the control ID for child windows or controls within a dialog box. If the specified window is
	/// not a child window or does not have a control ID, the returned value will be 0.
	/// </remarks>
	/// <param name="hwnd">A handle to the window whose control identifier is to be retrieved. Must be a valid window handle.</param>
	/// <returns>The integer identifier of the window control. Returns 0 if the window does not have a control identifier.</returns>
	public static int GetWindowID([In, AddAsMember] HWND hwnd) => GetDlgCtrlID(hwnd);

	/// <summary>Retrieves the instance handle associated with the specified window.</summary>
	/// <remarks>
	/// This method is typically used when interacting with native Windows APIs that require the module instance handle. The returned handle
	/// can be used in subsequent calls to functions that require the HINSTANCE of the window's owner.
	/// </remarks>
	/// <param name="hwnd">The handle to the window for which to obtain the instance handle. Must be a valid window handle.</param>
	/// <returns>The instance handle (HINSTANCE) of the module that created the specified window.</returns>
	public static HINSTANCE GetWindowInstance([In, AddAsMember] HWND hwnd) => GetWindowLong<HINSTANCE>(hwnd, WindowLongFlags.GWLP_HINSTANCE);

	/// <summary>Retrieves the handle of the owner window for the specified window.</summary>
	/// <remarks>
	/// The owner window is typically used for modal dialogs or windows that are parented to another window. If the specified window does not
	/// have an owner, the method returns <see langword="null"/>.
	/// </remarks>
	/// <param name="hwnd">The handle to the window whose owner is to be retrieved. Must be a valid window handle.</param>
	/// <returns>A handle to the owner window if one exists; otherwise, returns <see langword="null"/>.</returns>
	public static HWND GetWindowOwner([In, AddAsMember] HWND hwnd) => GetWindow(hwnd, GetWindowCmd.GW_OWNER);

	/// <summary>Retrieves the style flags for the specified window.</summary>
	/// <remarks>
	/// The returned style flags indicate various attributes of the window, such as whether it is resizable, has a title bar, or includes
	/// system menu options. This method does not validate the window handle; passing an invalid handle may result in undefined behavior.
	/// </remarks>
	/// <param name="hwnd">A handle to the window whose style information is to be retrieved. Must be a valid window handle.</param>
	/// <returns>A value of type <see cref="WindowStyles"/> representing the style flags currently applied to the specified window.</returns>
	public static WindowStyles GetWindowStyle([In, AddAsMember] HWND hwnd) => GetWindowLong<WindowStyles>(hwnd, WindowLongFlags.GWL_STYLE);

	/// <summary>Determines whether the left mouse button is currently pressed.</summary>
	/// <remarks>
	/// This method checks the state of the left mouse button at the time of the call. It is typically used in scenarios where mouse input
	/// needs to be detected outside of standard event handling, such as polling input state in a loop.
	/// </remarks>
	/// <returns>true if the left mouse button is pressed; otherwise, false.</returns>
	public static bool IsLButtonDown() => GetKeyState((int)VK.VK_LBUTTON) < 0;

	/// <summary>Determines whether the specified window is maximized.</summary>
	/// <param name="hwnd">A handle to the window to check. Must be a valid window handle.</param>
	/// <returns>true if the window is maximized; otherwise, false.</returns>
	public static bool IsMaximized([In, AddAsMember] HWND hwnd) => IsZoomed(hwnd);

	/// <summary>Determines whether the middle mouse button is currently pressed.</summary>
	/// <returns>true if the middle mouse button is pressed; otherwise, false.</returns>
	public static bool IsMButtonDown() => GetKeyState((int)VK.VK_MBUTTON) < 0;

	/// <summary>Determines whether the specified window is minimized (iconic).</summary>
	/// <param name="hwnd">The handle to the window to check. Must be a valid window handle.</param>
	/// <returns>true if the window is minimized; otherwise, false.</returns>
	public static bool IsMinimized([In, AddAsMember] HWND hwnd) => IsIconic(hwnd);

	//public static void CheckDefDlgRecursion(ref bool fRecursion) { if (fRecursion) { fRecursion = false; return false; } }
	/// <summary>Determines whether the right mouse button is currently pressed.</summary>
	/// <remarks>
	/// This method checks the real-time state of the right mouse button. It can be used to detect user input in scenarios where mouse button
	/// state is relevant, such as custom input handling or UI interactions.
	/// </remarks>
	/// <returns>true if the right mouse button is pressed; otherwise, false.</returns>
	public static bool IsRButtonDown() => GetKeyState((int)VK.VK_RBUTTON) < 0;

	/// <summary>Determines whether the specified window is in the restored (normal) state, rather than minimized or maximized.</summary>
	/// <remarks>
	/// This method can be used to detect whether a window is in its default size and position, as opposed to being minimized or maximized.
	/// The result depends on the current window style flags.
	/// </remarks>
	/// <param name="hwnd">A handle to the window to check. Must be a valid window handle.</param>
	/// <returns>true if the window is neither minimized nor maximized; otherwise, false.</returns>
	public static bool IsRestored([In, AddAsMember] HWND hwnd) => (GetWindowStyle(hwnd) & (WindowStyles.WS_MINIMIZE | WindowStyles.WS_MAXIMIZE)) == 0L;

	/// <summary>Maps the coordinates of a rectangle from one window's coordinate space to another.</summary>
	/// <remarks>
	/// If either window handle is null, the mapping is performed relative to the screen coordinates. This method is useful for converting
	/// rectangle positions between different windows or between window and screen coordinates.
	/// </remarks>
	/// <param name="hwndFrom">A handle to the source window whose coordinate space is used as the basis for the rectangle.</param>
	/// <param name="hwndTo">A handle to the destination window whose coordinate space the rectangle will be mapped to.</param>
	/// <param name="lprc">
	/// A reference to a RECT structure that contains the rectangle to be mapped. The structure is updated to contain the mapped coordinates.
	/// </param>
	/// <returns>The number of points mapped. Returns zero if the mapping fails.</returns>
	public static int MapWindowRect([In, AddAsMember] HWND hwndFrom, HWND hwndTo, ref RECT lprc) => MapWindowPoints(hwndFrom, hwndTo, ref lprc);

	/// <summary>Sets the result value for a dialog message and returns whether the operation was successful.</summary>
	/// <remarks>
	/// For certain dialog messages, the result is returned directly without modifying window state. For other messages, the result is set
	/// using the window's message result property. Ensure that the message type supports result assignment as expected.
	/// </remarks>
	/// <param name="hwnd">A handle to the dialog window for which the message result is being set.</param>
	/// <param name="msg">The dialog message whose result is to be set. Only specific messages support direct result assignment.</param>
	/// <param name="result">
	/// The result value to assign to the dialog message. Typically indicates success or failure as defined by the message.
	/// </param>
	/// <returns>true if the result was set successfully; otherwise, false.</returns>
	public static bool SetDlgMsgResult([In, AddAsMember] HWND hwnd, WindowMessage msg, BOOL result) => (msg is WindowMessage.WM_CTLCOLORMSGBOX or WindowMessage.WM_CTLCOLOREDIT or WindowMessage.WM_CTLCOLORLISTBOX or WindowMessage.WM_CTLCOLORBTN or WindowMessage.WM_CTLCOLORDLG or WindowMessage.WM_CTLCOLORSCROLLBAR or WindowMessage.WM_CTLCOLORSTATIC or WindowMessage.WM_COMPAREITEM or WindowMessage.WM_VKEYTOITEM or WindowMessage.WM_CHARTOITEM or WindowMessage.WM_QUERYDRAGICON or WindowMessage.WM_INITDIALOG) ?
		result :
		SetWindowLong(hwnd, WindowLongFlags.DWLP_MSGRESULT, (IntPtr)result) != IntPtr.Zero;

	/// <summary>Sets the font used by a specified window and optionally redraws the window to reflect the font change.</summary>
	/// <remarks>
	/// This method sends a WM_SETFONT message to the specified window. Changing the font may affect the appearance and layout of the
	/// window's controls. If <paramref name="fRedraw"/> is <see langword="true"/>, the window is immediately redrawn to reflect the new font.
	/// </remarks>
	/// <param name="hwnd">A handle to the window whose font is to be changed.</param>
	/// <param name="hfont">A handle to the font to be set for the window.</param>
	/// <param name="fRedraw">
	/// Specifies whether the window should be redrawn after the font is set. Use <see langword="true"/> to redraw the window; otherwise,
	/// <see langword="false"/>.
	/// </param>
	/// <returns>A handle to the window that received the font change message.</returns>
	public static HWND SetWindowFont([In, AddAsMember] HWND hwnd, HFONT hfont, BOOL fRedraw) => SendMessage(hwnd, WindowMessage.WM_SETFONT, (IntPtr)hfont, (IntPtr)fRedraw);

	/// <summary>
	/// Enables or disables redrawing of the specified window. When redrawing is disabled, changes to the window will not be visually updated
	/// until redrawing is re-enabled.
	/// </summary>
	/// <remarks>
	/// Disabling redrawing can improve performance when making multiple changes to a window, as visual updates are deferred until redrawing
	/// is re-enabled. After re-enabling redrawing, it may be necessary to invalidate the window to force a repaint.
	/// </remarks>
	/// <param name="hwnd">A handle to the window whose redraw state is to be changed.</param>
	/// <param name="fRedraw">
	/// A value that specifies whether redrawing is enabled. Specify <see langword="true"/> to enable redrawing; <see langword="false"/> to
	/// disable it.
	/// </param>
	/// <returns>A handle to the window specified by <paramref name="hwnd"/>.</returns>
	public static HWND SetWindowRedraw([In, AddAsMember] HWND hwnd, BOOL fRedraw) => SendMessage(hwnd, WindowMessage.WM_SETREDRAW, (IntPtr)fRedraw);

	/// <summary>Replaces the window procedure for a dialog box with a specified callback function and returns the previous window procedure.</summary>
	/// <remarks>
	/// Subclassing a dialog box allows custom handling of window messages. The caller is responsible for ensuring that the delegate remains
	/// valid for the lifetime of the subclassed dialog. Improper use may result in application instability.
	/// </remarks>
	/// <param name="hwndDlg">A handle to the dialog box whose window procedure is to be replaced.</param>
	/// <param name="lpfn">
	/// A delegate representing the new window procedure to be set for the dialog box. Must match the signature expected by the dialog box.
	/// </param>
	/// <returns>
	/// A delegate representing the previous window procedure for the dialog box. This can be used to restore the original procedure or to
	/// call it from the new procedure.
	/// </returns>
	public static WindowProc SubclassDialog([In, AddAsMember] HWND hwndDlg, WindowProc lpfn) => Marshal.GetDelegateForFunctionPointer<WindowProc>(SetWindowLong(hwndDlg, WindowLongFlags.DWLP_DLGPROC, Marshal.GetFunctionPointerForDelegate(lpfn)));

	/// <summary>Replaces the window procedure for the specified window with a new procedure and returns the previous window procedure.</summary>
	/// <remarks>
	/// Use this method to subclass a window and intercept its messages by providing a custom window procedure. The returned delegate can be
	/// used to call the original window procedure if needed. Subclassing windows can affect message handling and application stability;
	/// ensure that the new procedure correctly processes or forwards messages as appropriate.
	/// </remarks>
	/// <param name="hwnd">A handle to the window whose procedure is to be replaced.</param>
	/// <param name="lpfn">A delegate representing the new window procedure to be set for the window.</param>
	/// <returns>A delegate representing the previous window procedure for the specified window.</returns>
	public static WindowProc SubclassWindow([In, AddAsMember] HWND hwnd, WindowProc lpfn) => Marshal.GetDelegateForFunctionPointer<WindowProc>(SetWindowLong(hwnd, WindowLongFlags.GWLP_WNDPROC, Marshal.GetFunctionPointerForDelegate(lpfn)));
}