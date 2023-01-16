using System;
using System.Runtime.InteropServices;
using System.Text;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>A filter method that handles messages sent to a window.</summary>
/// <param name="hwnd">A handle to the window.</param>
/// <param name="msg">The MSG.</param>
/// <param name="wParam">Additional message information. The contents of this parameter depend on the value of the uMsg parameter.</param>
/// <param name="lParam">Additional message information. The contents of this parameter depend on the value of the uMsg parameter.</param>
/// <param name="lReturn">The return value is the result of the message processing and depends on the message sent.</param>
/// <returns>
/// <see langword="true"/> if the message is handled and <see cref="DefWindowProc(HWND, uint, IntPtr, IntPtr)"/> should not be called; <see
/// langword="false"/> otherwise.
/// </returns>
[UnmanagedFunctionPointer(CallingConvention.Winapi)]
public delegate bool BasicMessageWindowFilter(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam, out IntPtr lReturn);

/// <summary>Simple window to process messages.</summary>
/// <seealso cref="MarshalByRefObject"/>
/// <seealso cref="IDisposable"/>
/// <seealso cref="IHandle"/>
public partial class BasicMessageWindow : MarshalByRefObject, IDisposable, IHandle
{
	private readonly WeakReference weakSelfRef;
	private SafeHWND hwnd;
	private bool isDisposed;
	private ParamIndexer paramIndexer;
	private WindowClass wCls;

	/// <summary>Initializes a new instance of the <see cref="BasicMessageWindow"/> class.</summary>
	/// <param name="callback">Specifies the callback method to use to process messages.</param>
	public BasicMessageWindow(BasicMessageWindowFilter callback = null)
	{
		MessageFilter = callback;
		weakSelfRef = new WeakReference(this);
		hwnd = CreateWindow();
	}

	/// <summary>Finalizes an instance of the <see cref="BasicMessageWindow"/> class.</summary>
	~BasicMessageWindow() => Dispose(false);

	/// <summary>Occurs when the window is created and has a valid handle.</summary>
	public event Action Created;

	/// <summary>Occurs when the window has been destroyed.</summary>
	public event Action Destroyed;

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

	/// <summary>Gets the name of the windows class.</summary>
	/// <value>The name of the windows class.</value>
	public string ClassName => wCls?.ClassName;

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

	/// <summary>Gets the window handle.</summary>
	/// <value>The window handle.</value>
	public HWND Handle => hwnd ?? HWND.NULL;

	/// <summary>Gets or sets the callback method used to filter window messages.</summary>
	/// <value>The callback method.</value>
	public BasicMessageWindowFilter MessageFilter { get; set; }

	/// <summary>Gets or sets information about the window.</summary>
	/// <value>The information indexer.</value>
	public ISupportIndexer<WindowLongFlags, IntPtr> Param => paramIndexer ??= new ParamIndexer(this);

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
				return ShowWindowCommand.SW_HIDE;
			if (IsIconic(Handle))
				return ShowWindowCommand.SW_MINIMIZE;
			if (IsZoomed(Handle))
				return ShowWindowCommand.SW_MAXIMIZE;
			return ShowWindowCommand.SW_NORMAL;
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
					StringBuilder sb = new(len);
					if (GetWindowText(Handle, sb, sb.Capacity) > 0)
					{
						return sb.ToString();
					}
				}
			}
			return string.Empty;
		}
		set => Win32Error.ThrowLastErrorIfFalse(SetWindowText(Handle, value));
	}

	/// <summary>Gets or sets a value indicating whether this window is visible.</summary>
	/// <value><see langword="true"/> if visible; otherwise, <see langword="false"/>.</value>
	public bool Visible
	{
		get => IsWindowVisible(Handle);
		set => ShowState = value ? ShowWindowCommand.SW_SHOW : ShowWindowCommand.SW_HIDE;
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

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		Dispose(true);
		System.GC.SuppressFinalize(this);
	}

	/// <summary>Sets input focus to the window.</summary>
	public void Focus() => Win32Error.ThrowLastErrorIf(SetFocus(Handle), h => h.IsNull);

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
	public void Invalidate(bool erase = false, PRECT pRect = null) => Win32Error.ThrowLastErrorIfFalse(InvalidateRect(Handle, pRect, erase));

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

	/// <summary>
	/// The <c>Validate</c> function validates the client area within a rectangle by removing the rectangle from the update region of the
	/// this window.
	/// </summary>
	/// <param name="pRect">
	/// A <see cref="RECT"/> structure that contains the client coordinates of the rectangle to be removed from the update region. If this
	/// parameter is <see langword="null"/>, the entire client area is removed.
	/// </param>
	public void Validate(PRECT pRect = null) => Win32Error.ThrowLastErrorIfFalse(ValidateRect(Handle, pRect));

	/// <summary>Returns the value of the handle field.</summary>
	/// <returns>An IntPtr representing the value of the handle field.</returns>
	IntPtr IHandle.DangerousGetHandle() => (IntPtr)Handle;

	/// <summary>Method used to create the window. When overriding, the <c>hWnd</c> field must be set to the handle of the created window.</summary>
	protected virtual SafeHWND CreateWindow()
	{
		lock (this)
		{
			if (!Handle.IsNull)
			{
				throw new InvalidOperationException("Window handle already exists.");
			}

			HINSTANCE hInst = GetModuleHandle();
			wCls = new WindowClass($"{GetType().Name}+{Guid.NewGuid()}", hInst, WndProc);
			return Win32Error.ThrowLastErrorIfInvalid(CreateWindowEx(0, wCls.Atom, hWndParent: HWND.HWND_MESSAGE, hInstance: hInst));
		}
	}

	/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
	protected virtual void Dispose(bool disposing)
	{
		if (isDisposed)
			return;

		isDisposed = true;

		hwnd?.Dispose(); // Calls DestroyWindow
		hwnd = null;
		wCls?.Unregister();
	}

	private IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
	{
		if (msg == (uint)WindowMessage.WM_NCCREATE)
			return (IntPtr)1;

		try
		{
			return !weakSelfRef.IsAlive || weakSelfRef.Target is null || MessageFilter is null || !MessageFilter.Invoke(hwnd, msg, wParam, lParam, out IntPtr lRet)
				? DefWindowProc(hwnd, msg, wParam, lParam) : lRet;
		}
		finally
		{
			switch ((WindowMessage)msg)
			{
				case WindowMessage.WM_CREATE:
					Created?.Invoke();
					break;
				case WindowMessage.WM_NCDESTROY:
					Destroyed?.Invoke();
					break;
			}
		}
	}

	private class ParamIndexer : ISupportIndexer<WindowLongFlags, IntPtr>
	{
		private readonly BasicMessageWindow win;

		public ParamIndexer(BasicMessageWindow win) => this.win = win;

		public IntPtr this[WindowLongFlags flag]
		{
			get => GetWindowLongAuto(win.Handle, flag);
			set
			{
				SetLastError(0);
				Win32Error.ThrowLastErrorIf(SetWindowLong(win.Handle, flag, (int)value), i => i == 0);
			}
		}
	}
}