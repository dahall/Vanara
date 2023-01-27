#nullable enable
using System;
using System.Text;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>A wrapper for a visible window.</summary>
/// <seealso cref="Vanara.PInvoke.WindowBase"/>
public class VisibleWindow : WindowBase
{
	/// <summary>Initializes an uninitialized and uncreated instance of the <see cref="VisibleWindow"/> class.</summary>
	public VisibleWindow() { }

	/// <summary>Initializes a new instance of the <see cref="VisibleWindow"/> class.</summary>
	/// <param name="wc">The window class. If <see langword="null"/>, a new window class is created that is unique to this window.</param>
	/// <param name="text">
	/// The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title
	/// bar. When using CreateWindow to create controls, such as buttons, check boxes, and static controls, use lpWindowName to specify the
	/// text of the control. When creating a static control with the <c>SS_ICON</c> style, use lpWindowName to specify the icon name or
	/// identifier. To specify an identifier, use the syntax "#num".
	/// </param>
	/// <param name="size">
	/// The width and height, in device units, of the window. For overlapped windows, nWidth is the window's width, in screen coordinates, or
	/// <c>CW_USEDEFAULT</c>. If nWidth is <c>CW_USEDEFAULT</c>, the system selects a default width and height for the window; the default
	/// width extends from the initial x-coordinates to the right edge of the screen; the default height extends from the initial
	/// y-coordinate to the top of the icon area. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if <c>CW_USEDEFAULT</c> is
	/// specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero.
	/// </param>
	/// <param name="position">
	/// <para>
	/// The initial vertical position of the window. For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the
	/// window's upper-left corner and the y parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates.
	/// For a child window, x is the x-coordinate of the upper-left corner of the window relative to the upper-left corner of the parent
	/// window's client area and y is the initial y-coordinate of the upper-left corner of the child window relative to the upper-left
	/// corner. If x is set to <c>CW_USEDEFAULT</c>, the system selects the default position for the window's upper-left corner and ignores
	/// the y parameter. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if it is specified for a pop-up or child window, the x
	/// and y parameters are set to zero.
	/// </para>
	/// <para>
	/// If an overlapped window is created with the <c>WS_VISIBLE</c> style bit set and the x parameter is set to <c>CW_USEDEFAULT</c>, then
	/// the y parameter determines how the window is shown. If the y parameter is <c>CW_USEDEFAULT</c>, then the window manager calls
	/// ShowWindow with the <c>SW_SHOW</c> flag after the window has been created. If the y parameter is some other value, then the window
	/// manager calls <c>ShowWindow</c> with that value as the nCmdShow parameter.
	/// </para>
	/// </param>
	/// <param name="style">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The style of the window being created. This parameter can be a combination of the window style values, plus the control styles
	/// indicated in the Remarks section.
	/// </para>
	/// </param>
	/// <param name="exStyle">The extended window style of the window being created. For a list of possible values,see Extended Window Styles.</param>
	/// <param name="parent">
	/// <para>
	/// A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid
	/// window handle. This parameter is optional for pop-up windows.
	/// </para>
	/// <para>To create a message-only window, supply <c>HWND_MESSAGE</c> or a handle to an existing message-only window.</para>
	/// </param>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>
	/// A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window, hMenu
	/// identifies the menu to be used with the window; it can be <c>NULL</c> if the class menu is to be used. For a child window, hMenu
	/// specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events. The
	/// application determines the child-window identifier; it must be unique for all child windows with the same parent window.
	/// </para>
	/// </param>
	public VisibleWindow(WindowClass? wc = null, string? text = null, SIZE? size = default, POINT? position = default, WindowStyles style = WindowStyles.WS_OVERLAPPEDWINDOW,
		WindowStylesEx exStyle = 0, HWND parent = default, HMENU hMenu = default) =>
		CreateHandle(wc, text, size, position, style, exStyle, parent, hMenu);

	/// <summary>Initializes a new instance of the <see cref="VisibleWindow"/> class.</summary>
	/// <param name="className">The window class name. It is created using default values if it doesn't exist.</param>
	/// <param name="hInst">
	/// A handle to the instance of the application that created the class. To retrieve information about classes defined by the system (such
	/// as buttons or list boxes), set this parameter to NULL.
	/// </param>
	/// <param name="text">
	/// The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title
	/// bar. When using CreateWindow to create controls, such as buttons, check boxes, and static controls, use lpWindowName to specify the
	/// text of the control. When creating a static control with the <c>SS_ICON</c> style, use lpWindowName to specify the icon name or
	/// identifier. To specify an identifier, use the syntax "#num".
	/// </param>
	/// <param name="size">
	/// The width and height, in device units, of the window. For overlapped windows, nWidth is the window's width, in screen coordinates, or
	/// <c>CW_USEDEFAULT</c>. If nWidth is <c>CW_USEDEFAULT</c>, the system selects a default width and height for the window; the default
	/// width extends from the initial x-coordinates to the right edge of the screen; the default height extends from the initial
	/// y-coordinate to the top of the icon area. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if <c>CW_USEDEFAULT</c> is
	/// specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero.
	/// </param>
	/// <param name="position">
	/// <para>
	/// The initial vertical position of the window. For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the
	/// window's upper-left corner and the y parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates.
	/// For a child window, x is the x-coordinate of the upper-left corner of the window relative to the upper-left corner of the parent
	/// window's client area and y is the initial y-coordinate of the upper-left corner of the child window relative to the upper-left
	/// corner. If x is set to <c>CW_USEDEFAULT</c>, the system selects the default position for the window's upper-left corner and ignores
	/// the y parameter. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if it is specified for a pop-up or child window, the x
	/// and y parameters are set to zero.
	/// </para>
	/// <para>
	/// If an overlapped window is created with the <c>WS_VISIBLE</c> style bit set and the x parameter is set to <c>CW_USEDEFAULT</c>, then
	/// the y parameter determines how the window is shown. If the y parameter is <c>CW_USEDEFAULT</c>, then the window manager calls
	/// ShowWindow with the <c>SW_SHOW</c> flag after the window has been created. If the y parameter is some other value, then the window
	/// manager calls <c>ShowWindow</c> with that value as the nCmdShow parameter.
	/// </para>
	/// </param>
	/// <param name="style">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The style of the window being created. This parameter can be a combination of the window style values, plus the control styles
	/// indicated in the Remarks section.
	/// </para>
	/// </param>
	/// <param name="exStyle">The extended window style of the window being created. For a list of possible values,see Extended Window Styles.</param>
	/// <param name="parent">
	/// <para>
	/// A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid
	/// window handle. This parameter is optional for pop-up windows.
	/// </para>
	/// <para>To create a message-only window, supply <c>HWND_MESSAGE</c> or a handle to an existing message-only window.</para>
	/// </param>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>
	/// A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window, hMenu
	/// identifies the menu to be used with the window; it can be <c>NULL</c> if the class menu is to be used. For a child window, hMenu
	/// specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events. The
	/// application determines the child-window identifier; it must be unique for all child windows with the same parent window.
	/// </para>
	/// </param>
	public VisibleWindow(string className, HINSTANCE hInst, string? text = null, SIZE? size = default, POINT? position = default,
		WindowStyles style = WindowStyles.WS_OVERLAPPEDWINDOW, WindowStylesEx exStyle = 0, HWND parent = default, HMENU hMenu = default) :
		this(WindowClass.GetNamedInstance(className, hInst), text, size, position, style, exStyle, parent, hMenu)
	{
	}

	/// <summary>Initializes a new instance of the <see cref="VisibleWindow"/> class.</summary>
	/// <param name="wndProcOverride">The window procedure override delegate.</param>
	/// <param name="text">
	/// The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title
	/// bar. When using CreateWindow to create controls, such as buttons, check boxes, and static controls, use lpWindowName to specify the
	/// text of the control. When creating a static control with the <c>SS_ICON</c> style, use lpWindowName to specify the icon name or
	/// identifier. To specify an identifier, use the syntax "#num".
	/// </param>
	/// <param name="size">
	/// The width and height, in device units, of the window. For overlapped windows, nWidth is the window's width, in screen coordinates, or
	/// <c>CW_USEDEFAULT</c>. If nWidth is <c>CW_USEDEFAULT</c>, the system selects a default width and height for the window; the default
	/// width extends from the initial x-coordinates to the right edge of the screen; the default height extends from the initial
	/// y-coordinate to the top of the icon area. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if <c>CW_USEDEFAULT</c> is
	/// specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero.
	/// </param>
	/// <param name="position">
	/// <para>
	/// The initial vertical position of the window. For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the
	/// window's upper-left corner and the y parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates.
	/// For a child window, x is the x-coordinate of the upper-left corner of the window relative to the upper-left corner of the parent
	/// window's client area and y is the initial y-coordinate of the upper-left corner of the child window relative to the upper-left
	/// corner. If x is set to <c>CW_USEDEFAULT</c>, the system selects the default position for the window's upper-left corner and ignores
	/// the y parameter. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if it is specified for a pop-up or child window, the x
	/// and y parameters are set to zero.
	/// </para>
	/// <para>
	/// If an overlapped window is created with the <c>WS_VISIBLE</c> style bit set and the x parameter is set to <c>CW_USEDEFAULT</c>, then
	/// the y parameter determines how the window is shown. If the y parameter is <c>CW_USEDEFAULT</c>, then the window manager calls
	/// ShowWindow with the <c>SW_SHOW</c> flag after the window has been created. If the y parameter is some other value, then the window
	/// manager calls <c>ShowWindow</c> with that value as the nCmdShow parameter.
	/// </para>
	/// </param>
	/// <param name="style">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The style of the window being created. This parameter can be a combination of the window style values, plus the control styles
	/// indicated in the Remarks section.
	/// </para>
	/// </param>
	/// <param name="exStyle">The extended window style of the window being created. For a list of possible values,see Extended Window Styles.</param>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>
	/// A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window, hMenu
	/// identifies the menu to be used with the window; it can be <c>NULL</c> if the class menu is to be used. For a child window, hMenu
	/// specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events. The
	/// application determines the child-window identifier; it must be unique for all child windows with the same parent window.
	/// </para>
	/// </param>
	/// <param name="parent">
	/// <para>
	/// A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid
	/// window handle. This parameter is optional for pop-up windows.
	/// </para>
	/// <para>To create a message-only window, supply <c>HWND_MESSAGE</c> or a handle to an existing message-only window.</para>
	/// </param>
	public VisibleWindow(WindowProc wndProcOverride, string? text = null, SIZE? size = default, POINT? position = default,
		WindowStyles style = WindowStyles.WS_OVERLAPPEDWINDOW, WindowStylesEx exStyle = 0, HMENU hMenu = default, HWND parent = default) :
		base(wndProcOverride) => CreateHandle(null, text, size, position, style, exStyle, parent, hMenu);

	/// <summary>
	/// Gets or sets the dimensions of the bounding rectangle of the specified window. The dimensions are given in screen coordinates that
	/// are relative to the upper-left corner of the screen.
	/// </summary>
	/// <value>A RECT structure with the screen coordinates of the upper-left and lower-right corners of the window.</value>
	public RECT Bounds
	{
		get { Win32Error.ThrowLastErrorIfFalse(GetWindowRect(Handle, out RECT r)); return r; }
		set => SetPosition(value.Location, value.Size);
	}

	/// <summary>
	/// Gets the coordinates of a window's client area. The client coordinates specify the upper-left and lower-right corners of the client
	/// area. Because client coordinates are relative to the upper-left corner of a window's client area, the coordinates of the upper-left
	/// corner are (0,0).
	/// </summary>
	/// <value>
	/// A RECT structure with the client coordinates. The left and top members are zero. The right and bottom members contain the width and
	/// height of the window.
	/// </value>
	public RECT ClientRect
	{
		get { Win32Error.ThrowLastErrorIfFalse(GetClientRect(Handle, out RECT r)); return r; }
	}

	/// <summary>Gets a value indicating whether this <see cref="BasicMessageWindow"/> is enabled.</summary>
	/// <value><see langword="true"/> if enabled; otherwise, <see langword="false"/>.</value>
	public bool Enabled => IsWindowEnabled(Handle);

	/// <summary>Gets a value indicating whether the window has input focus.</summary>
	/// <value><see langword="true"/> if focused; otherwise, <see langword="false"/>.</value>
	public bool Focused => GetFocus().Equals(Handle);

	/// <summary>
	/// Gets or sets the position of the window. The dimensions are given in screen coordinates that are relative to the upper-left corner of
	/// the screen.
	/// </summary>
	/// <value>The position of window.</value>
	public POINT Position
	{
		get
		{
			Win32Error.ThrowLastErrorIfFalse(GetWindowRect(Handle, out RECT r));
			return r.Location;
		}
		set => Win32Error.ThrowLastErrorIfFalse(SetWindowPos(Handle, default, value.X, value.Y, -1, -1, SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOZORDER));
	}

	/// <summary>Gets or sets the window's show state.</summary>
	/// <value>The show state.</value>
	public ShowWindowCommand ShowState
	{
		get
		{
			if (!Visible)
			{
				return ShowWindowCommand.SW_HIDE;
			}

			if (IsIconic(Handle))
			{
				return ShowWindowCommand.SW_MINIMIZE;
			}

			return IsZoomed(Handle) ? ShowWindowCommand.SW_MAXIMIZE : ShowWindowCommand.SW_NORMAL;
		}
		set => Win32Error.ThrowLastErrorIfFalse(ShowWindow(Handle, value));
	}

	/// <summary>Gets or sets the size of the window.</summary>
	/// <value>The size of window.</value>
	public SIZE Size
	{
		get
		{
			Win32Error.ThrowLastErrorIfFalse(GetWindowRect(Handle, out RECT r));
			return r.Size;
		}
		set => Win32Error.ThrowLastErrorIfFalse(SetWindowPos(Handle, default, -1, -1, value.cx, value.cy, SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER));
	}

	/// <summary>Gets or sets the value of the style bit for the window.</summary>
	/// <value>The styles value.</value>
	public WindowStyles Styles
	{
		get => (WindowStyles)Param[WindowLongFlags.GWL_STYLE].ToInt32();
		set => Param[WindowLongFlags.GWL_STYLE] = (IntPtr)(int)value;
	}

	/// <summary>Gets or sets the value of the extended style bit for the window.</summary>
	/// <value>The extended styles value.</value>
	public WindowStylesEx StylesEx
	{
		get => (WindowStylesEx)Param[WindowLongFlags.GWL_EXSTYLE].ToInt32();
		set => Param[WindowLongFlags.GWL_EXSTYLE] = (IntPtr)(int)value;
	}

	/// <summary>Gets or sets the text of the window's title bar (if it has one).</summary>
	/// <value>The text of the title bar.</value>
	public string Text
	{
		get
		{
			if (!Handle.IsNull)
			{
				int len = GetWindowTextLength(Handle);
				if (len > 0)
				{
					StringBuilder sb = new(len + 1);
					if (GetWindowText(Handle, sb, len) > 0)
					{
						return sb.ToString();
					}
				}
			}
			return string.Empty;
		}
		set => Win32Error.ThrowLastErrorIfFalse(SetWindowText(Handle, value));
	}

	/// <summary>Gets a value indicating whether this window is visible.</summary>
	/// <value><see langword="true"/> if visible; otherwise, <see langword="false"/>.</value>
	public bool Visible => IsWindowVisible(Handle);

	/// <summary>
	/// Creates a new instance of the <see cref="VisibleWindow"/> class using the parameters, displays the window, and executes a simple
	/// message pump.
	/// </summary>
	/// <param name="wc">The window class. If <see langword="null"/>, a new window class is created that is unique to this window.</param>
	/// <param name="text">
	/// The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title
	/// bar. When using CreateWindow to create controls, such as buttons, check boxes, and static controls, use lpWindowName to specify the
	/// text of the control. When creating a static control with the <c>SS_ICON</c> style, use lpWindowName to specify the icon name or
	/// identifier. To specify an identifier, use the syntax "#num".
	/// </param>
	/// <param name="size">
	/// The width and height, in device units, of the window. For overlapped windows, nWidth is the window's width, in screen coordinates, or
	/// <c>CW_USEDEFAULT</c>. If nWidth is <c>CW_USEDEFAULT</c>, the system selects a default width and height for the window; the default
	/// width extends from the initial x-coordinates to the right edge of the screen; the default height extends from the initial
	/// y-coordinate to the top of the icon area. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if <c>CW_USEDEFAULT</c> is
	/// specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero.
	/// </param>
	/// <param name="position">
	/// <para>
	/// The initial vertical position of the window. For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the
	/// window's upper-left corner and the y parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates.
	/// For a child window, x is the x-coordinate of the upper-left corner of the window relative to the upper-left corner of the parent
	/// window's client area and y is the initial y-coordinate of the upper-left corner of the child window relative to the upper-left
	/// corner. If x is set to <c>CW_USEDEFAULT</c>, the system selects the default position for the window's upper-left corner and ignores
	/// the y parameter. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if it is specified for a pop-up or child window, the x
	/// and y parameters are set to zero.
	/// </para>
	/// <para>
	/// If an overlapped window is created with the <c>WS_VISIBLE</c> style bit set and the x parameter is set to <c>CW_USEDEFAULT</c>, then
	/// the y parameter determines how the window is shown. If the y parameter is <c>CW_USEDEFAULT</c>, then the window manager calls
	/// ShowWindow with the <c>SW_SHOW</c> flag after the window has been created. If the y parameter is some other value, then the window
	/// manager calls <c>ShowWindow</c> with that value as the nCmdShow parameter.
	/// </para>
	/// </param>
	/// <param name="style">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The style of the window being created. This parameter can be a combination of the window style values, plus the control styles
	/// indicated in the Remarks section.
	/// </para>
	/// </param>
	/// <param name="exStyle">The extended window style of the window being created. For a list of possible values,see Extended Window Styles.</param>
	/// <param name="parent">
	/// <para>
	/// A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid
	/// window handle. This parameter is optional for pop-up windows.
	/// </para>
	/// <para>To create a message-only window, supply <c>HWND_MESSAGE</c> or a handle to an existing message-only window.</para>
	/// </param>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>
	/// A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window, hMenu
	/// identifies the menu to be used with the window; it can be <c>NULL</c> if the class menu is to be used. For a child window, hMenu
	/// specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events. The
	/// application determines the child-window identifier; it must be unique for all child windows with the same parent window.
	/// </para>
	/// </param>
	public static void Run<TWin>(WindowClass? wc = null, string? text = null, SIZE? size = default, POINT? position = default, WindowStyles style = WindowStyles.WS_OVERLAPPEDWINDOW,
		WindowStylesEx exStyle = 0, HWND parent = default, HMENU hMenu = default) where TWin : VisibleWindow, new()
	{
		using TWin win = new();
		win.CreateHandle(wc, text, size, position, style, exStyle, parent, hMenu);
		win.Show();
		new MessagePump().Run(win);
	}

	/// <summary>
	/// Creates a new instance of the <see cref="VisibleWindow"/> class using the parameters, displays the window, and executes a simple
	/// message pump.
	/// </summary>
	/// <param name="text">
	/// The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title
	/// bar. When using CreateWindow to create controls, such as buttons, check boxes, and static controls, use lpWindowName to specify the
	/// text of the control. When creating a static control with the <c>SS_ICON</c> style, use lpWindowName to specify the icon name or
	/// identifier. To specify an identifier, use the syntax "#num".
	/// </param>
	/// <param name="size">
	/// The width and height, in device units, of the window. For overlapped windows, nWidth is the window's width, in screen coordinates, or
	/// <c>CW_USEDEFAULT</c>. If nWidth is <c>CW_USEDEFAULT</c>, the system selects a default width and height for the window; the default
	/// width extends from the initial x-coordinates to the right edge of the screen; the default height extends from the initial
	/// y-coordinate to the top of the icon area. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if <c>CW_USEDEFAULT</c> is
	/// specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero.
	/// </param>
	/// <param name="position">
	/// <para>
	/// The initial vertical position of the window. For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the
	/// window's upper-left corner and the y parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates.
	/// For a child window, x is the x-coordinate of the upper-left corner of the window relative to the upper-left corner of the parent
	/// window's client area and y is the initial y-coordinate of the upper-left corner of the child window relative to the upper-left
	/// corner. If x is set to <c>CW_USEDEFAULT</c>, the system selects the default position for the window's upper-left corner and ignores
	/// the y parameter. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if it is specified for a pop-up or child window, the x
	/// and y parameters are set to zero.
	/// </para>
	/// <para>
	/// If an overlapped window is created with the <c>WS_VISIBLE</c> style bit set and the x parameter is set to <c>CW_USEDEFAULT</c>, then
	/// the y parameter determines how the window is shown. If the y parameter is <c>CW_USEDEFAULT</c>, then the window manager calls
	/// ShowWindow with the <c>SW_SHOW</c> flag after the window has been created. If the y parameter is some other value, then the window
	/// manager calls <c>ShowWindow</c> with that value as the nCmdShow parameter.
	/// </para>
	/// </param>
	/// <param name="style">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The style of the window being created. This parameter can be a combination of the window style values, plus the control styles
	/// indicated in the Remarks section.
	/// </para>
	/// </param>
	/// <param name="exStyle">The extended window style of the window being created. For a list of possible values,see Extended Window Styles.</param>
	/// <param name="parent">
	/// <para>
	/// A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid
	/// window handle. This parameter is optional for pop-up windows.
	/// </para>
	/// <para>To create a message-only window, supply <c>HWND_MESSAGE</c> or a handle to an existing message-only window.</para>
	/// </param>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>
	/// A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window, hMenu
	/// identifies the menu to be used with the window; it can be <c>NULL</c> if the class menu is to be used. For a child window, hMenu
	/// specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events. The
	/// application determines the child-window identifier; it must be unique for all child windows with the same parent window.
	/// </para>
	/// </param>
	public static void Run<TWin>(string? text = null, SIZE? size = default, POINT? position = default, WindowStyles style = WindowStyles.WS_OVERLAPPEDWINDOW,
		WindowStylesEx exStyle = 0, HWND parent = default, HMENU hMenu = default) where TWin : VisibleWindow, new()
	{
		using TWin win = new();
		win.CreateHandle(null, text, size, position, style, exStyle, parent, hMenu);
		win.Show();
		new MessagePump().Run(win);
	}

	/// <summary>
	/// Creates a new instance of the <see cref="VisibleWindow"/> class using the parameters, displays the window, and executes a simple
	/// message pump.
	/// </summary>
	/// <param name="wndProc">The window procedure delegate.</param>
	/// <param name="text">
	/// The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title
	/// bar. When using CreateWindow to create controls, such as buttons, check boxes, and static controls, use lpWindowName to specify the
	/// text of the control. When creating a static control with the <c>SS_ICON</c> style, use lpWindowName to specify the icon name or
	/// identifier. To specify an identifier, use the syntax "#num".
	/// </param>
	/// <param name="size">
	/// The width and height, in device units, of the window. For overlapped windows, nWidth is the window's width, in screen coordinates, or
	/// <c>CW_USEDEFAULT</c>. If nWidth is <c>CW_USEDEFAULT</c>, the system selects a default width and height for the window; the default
	/// width extends from the initial x-coordinates to the right edge of the screen; the default height extends from the initial
	/// y-coordinate to the top of the icon area. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if <c>CW_USEDEFAULT</c> is
	/// specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero.
	/// </param>
	/// <param name="position">
	/// <para>
	/// The initial vertical position of the window. For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the
	/// window's upper-left corner and the y parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates.
	/// For a child window, x is the x-coordinate of the upper-left corner of the window relative to the upper-left corner of the parent
	/// window's client area and y is the initial y-coordinate of the upper-left corner of the child window relative to the upper-left
	/// corner. If x is set to <c>CW_USEDEFAULT</c>, the system selects the default position for the window's upper-left corner and ignores
	/// the y parameter. <c>CW_USEDEFAULT</c> is valid only for overlapped windows; if it is specified for a pop-up or child window, the x
	/// and y parameters are set to zero.
	/// </para>
	/// <para>
	/// If an overlapped window is created with the <c>WS_VISIBLE</c> style bit set and the x parameter is set to <c>CW_USEDEFAULT</c>, then
	/// the y parameter determines how the window is shown. If the y parameter is <c>CW_USEDEFAULT</c>, then the window manager calls
	/// ShowWindow with the <c>SW_SHOW</c> flag after the window has been created. If the y parameter is some other value, then the window
	/// manager calls <c>ShowWindow</c> with that value as the nCmdShow parameter.
	/// </para>
	/// </param>
	/// <param name="style">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The style of the window being created. This parameter can be a combination of the window style values, plus the control styles
	/// indicated in the Remarks section.
	/// </para>
	/// </param>
	/// <param name="exStyle">The extended window style of the window being created. For a list of possible values,see Extended Window Styles.</param>
	/// <param name="parent">
	/// <para>
	/// A handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid
	/// window handle. This parameter is optional for pop-up windows.
	/// </para>
	/// <para>To create a message-only window, supply <c>HWND_MESSAGE</c> or a handle to an existing message-only window.</para>
	/// </param>
	/// <param name="hMenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>
	/// A handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window, hMenu
	/// identifies the menu to be used with the window; it can be <c>NULL</c> if the class menu is to be used. For a child window, hMenu
	/// specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events. The
	/// application determines the child-window identifier; it must be unique for all child windows with the same parent window.
	/// </para>
	/// </param>
	public static void Run(WindowProc wndProc, string? text = null, SIZE? size = default, POINT? position = default, WindowStyles style = WindowStyles.WS_OVERLAPPEDWINDOW,
		WindowStylesEx exStyle = 0, HWND parent = default, HMENU hMenu = default)
	{
		using VisibleWindow win = new(wndProc, text, size, position, style, exStyle, hMenu, parent);
		win.Show();
		new MessagePump().Run(win);
	}

	/// <summary>Converts a rectangle from this window's client coordinates to screen coordinates.</summary>
	/// <param name="clientRect">A <see cref="RECT"/> in client coordinates.</param>
	/// <returns>The resulting <see cref="RECT"/> in screen coordinates.</returns>
	public virtual RECT ClientToScreen(in RECT clientRect)
	{
		RECT screenRect = clientRect;
		SetLastError(0);
		Win32Error.ThrowLastErrorIf(MapWindowPoints(Handle, IntPtr.Zero, ref screenRect), i => i == 0);
		Win32Error.ThrowLastErrorIfFalse(AdjustWindowRectEx(ref screenRect, Styles, GetMenu(Handle) != IntPtr.Zero, StylesEx));
		return screenRect;
	}

	/// <summary>Sets input focus to the window.</summary>
	public void Focus() => Win32Error.ThrowLastErrorIf(SetFocus(Handle), h => h.IsNull);

	/// <summary>Hides the window (sets state to SW_HIDE).</summary>
	public void Hide() => ShowState = ShowWindowCommand.SW_HIDE;

	/// <summary>
	/// Invalidates the specified region of the windows (adds it to the window's update region, which is the area that will be repainted at
	/// the next paint operation), and causes a paint message to be sent to the window. Optionally, invalidates the child windows assigned to
	/// the window.
	/// </summary>
	/// <param name="erase"><see langword="true"/> to invalidate the window's child windows; otherwise, <see langword="false"/>.</param>
	/// <param name="pRect">
	/// A <see cref="PRECT"/> that represents the region to invalidate. This value can be <see langword="null"/>, in which case the entire
	/// client region is invalidated.
	/// </param>
	public void Invalidate(bool erase = false, PRECT? pRect = null) => Win32Error.ThrowLastErrorIfFalse(InvalidateRect(Handle, pRect, erase));

	/// <summary>Converts a rectangle from screen coordinates to this window's client coordinates.</summary>
	/// <param name="screenRect">A <see cref="RECT"/> in screen coordinates.</param>
	/// <returns>The resulting <see cref="RECT"/> in client coordinates.</returns>
	public virtual RECT ScreenToClient(in RECT screenRect)
	{
		RECT clientRect = screenRect;
		SetLastError(0);
		Win32Error.ThrowLastErrorIf(MapWindowPoints(IntPtr.Zero, Handle, ref clientRect), i => i == 0);
		RECT invRect = default;
		Win32Error.ThrowLastErrorIfFalse(AdjustWindowRectEx(ref invRect, Styles, GetMenu(Handle) != IntPtr.Zero, StylesEx));
		SubtractRect(out clientRect, clientRect, invRect);
		return clientRect;
	}

	/// <summary>
	/// Changes the size, position, and Z order of a child, pop-up, or top-level window. These windows are ordered according to their
	/// appearance on the screen. The topmost window receives the highest rank and is the first window in the Z order.
	/// </summary>
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
	/// <param name="position">The new position of the window, in client coordinates.</param>
	/// <param name="size">The new width of the window, in pixels.</param>
	/// <param name="flags">The window sizing and positioning flags. This parameter can be one of more values from <see cref="SetWindowPosFlags"/>.</param>
	/// <returns>
	/// <para>Type: <c>Type: <c>BOOL</c></c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// As part of the Vista re-architecture, all services were moved off the interactive desktop into Session 0. hwnd and window manager
	/// operations are only effective inside a session and cross-session attempts to manipulate the hwnd will fail. For more information, see
	/// The Windows Vista Developer Story: Application Compatibility Cookbook.
	/// </para>
	/// <para>
	/// If you have changed certain window data using SetWindowLong, you must call <c>SetWindowPos</c> for the changes to take effect. Use
	/// the following combination for uFlags: .
	/// </para>
	/// <para>
	/// A window can be made a topmost window either by setting the hWndInsertAfter parameter to <c>HWND_TOPMOST</c> and ensuring that the
	/// <c>SWP_NOZORDER</c> flag is not set, or by setting a window's position in the Z order so that it is above any existing topmost
	/// windows. When a non-topmost window is made topmost, its owned windows are also made topmost. Its owners, however, are not changed.
	/// </para>
	/// <para>
	/// If neither the <c>SWP_NOACTIVATE</c> nor <c>SWP_NOZORDER</c> flag is specified (that is, when the application requests that a window
	/// be simultaneously activated and its position in the Z order changed), the value specified in hWndInsertAfter is used only in the
	/// following circumstances.
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
	/// <para>To use <c>SetWindowPos</c> to bring a window to the top, the process that owns the window must have SetForegroundWindow permission.</para>
	/// </remarks>
	public void SetPosition(POINT position, SIZE size, HWND hWndInsertAfter = default, SetWindowPosFlags flags = SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOZORDER) =>
		Win32Error.ThrowLastErrorIfFalse(SetWindowPos(Handle, hWndInsertAfter, position.X, position.Y, size.cx, size.cy, flags));

	/// <summary>Shows the window (sets state to SW_SHOWNORMAL).</summary>
	public void Show() => ShowState = ShowWindowCommand.SW_SHOWNORMAL;

	/// <summary>
	/// The <c>Validate</c> function validates the client area within a rectangle by removing the rectangle from the update region of the
	/// this window.
	/// </summary>
	/// <param name="pRect">
	/// A <see cref="RECT"/> structure that contains the client coordinates of the rectangle to be removed from the update region. If this
	/// parameter is <see langword="null"/>, the entire client area is removed.
	/// </param>
	public void Validate(PRECT? pRect = null) => Win32Error.ThrowLastErrorIfFalse(ValidateRect(Handle, pRect));
}