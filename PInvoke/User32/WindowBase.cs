#nullable enable
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>Interface for a class that holds a window handle.</summary>
/// <seealso cref="Vanara.PInvoke.IHandle"/>
public interface IWindowHandle : IHandle
{
	/// <summary>Gets the window handle.</summary>
	/// <value>The window handle.</value>
	HWND Handle { get; }
}

/// <summary>Simple window wrapper.</summary>
/// <seealso cref="MarshalByRefObject"/>
/// <seealso cref="IDisposable"/>
/// <seealso cref="IHandle"/>
public class WindowBase : MarshalByRefObject, IDisposable, IWindowInstance, IWindowInit, IWindowHandle
{
	/// <summary>A window procedure override delegate.</summary>
	protected WindowProc? customWndProc;

	private static readonly object createWindowSyncObject = new();
	private readonly WeakReference weakThisPtr;
	private bool createdClass = false;
	private SafeHWND? hwnd;
	private bool isDisposed;
	private ParamIndexer? paramIndexer;
	private IntPtr prevWndProcPtr, defWndProc;
	private WindowClass? wCls;
	private WindowProc? wndProc, userDefWndProc;

	/// <summary>Initializes a new instance of the <see cref="WindowBase"/> class without creating the window.</summary>
	public WindowBase() => weakThisPtr = new(this);

	/// <summary>Initializes a new instance of the <see cref="WindowBase"/> class and defines a window procedure to use.</summary>
	/// <param name="wndProcOverride">The window procedure override delegate.</param>
	public WindowBase(WindowProc wndProcOverride) : this() => customWndProc = wndProcOverride;

	internal WindowBase(HWND hwnd) : this() => wCls = WindowClass.GetInstanceFromWindow(hwnd) ?? throw Win32Error.GetLastError().GetException();

	/// <summary>Finalizes an instance of the <see cref="BasicMessageWindow"/> class.</summary>
	~WindowBase() => Dispose(false);

	/// <summary>Occurs when the window is created and has a valid handle.</summary>
	public event Action? Created;

	/// <summary>Occurs when the window has been destroyed.</summary>
	public event Action? Destroyed;

	/// <summary>Gets the name of the windows class.</summary>
	/// <value>The name of the windows class.</value>
	public string? ClassName => wCls?.ClassName;

	/// <summary>Gets a <see cref="CREATESTRUCT"/> structure with all creation parameters.</summary>
	/// <value>The <see cref="CREATESTRUCT"/> structure with all creation parameters.</value>
	public CREATESTRUCT CreateParam { get; internal set; }

	/// <summary>Gets the window handle.</summary>
	/// <value>The window handle.</value>
	public HWND Handle => hwnd ?? HWND.NULL;

	/// <summary>Gets or sets information about the window.</summary>
	/// <value>The information indexer.</value>
	public ISupportIndexer<WindowLongFlags, IntPtr> Param => paramIndexer ??= new ParamIndexer(this);

	/// <summary>Creates a window and its handle with the specified creation parameters.</summary>
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
	public virtual void CreateHandle(WindowClass? wc = null, string? text = null, SIZE? size = default, POINT? position = default,
		WindowStyles style = 0, WindowStylesEx exStyle = 0, HWND parent = default, HMENU hMenu = default)
	{
		lock (this)
		{
			CheckDetached();
			lock (createWindowSyncObject)
			{
				if (hwnd is not null)
					return;

				if ((wCls = wc) is null)
				{
					wCls = WindowClass.MakeVisibleWindowClass($"{GetType().Name}+{Guid.NewGuid()}", null);
					createdClass = true;
				}
				size ??= new(CW_USEDEFAULT, CW_USEDEFAULT);
				position ??= new(CW_USEDEFAULT, CW_USEDEFAULT);
				GCHandle gcWnd = GCHandle.Alloc(this);
				try
				{
					if (text?.Length > short.MaxValue)
						text = text.Substring(0, short.MaxValue);
					hwnd = Win32Error.ThrowLastErrorIfInvalid(CreateWindowEx(exStyle, wCls.ClassName, text, style, position.Value.X,
						position.Value.Y, size.Value.Width, size.Value.Height, parent, hMenu, wCls.wc.hInstance, GCHandle.ToIntPtr(gcWnd)));
				}
				finally
				{
					gcWnd.Free();
				}
			}
		}
	}

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		Dispose(true);
		System.GC.SuppressFinalize(this);
	}

	/// <inhertdoc/>
	IntPtr IHandle.DangerousGetHandle() => hwnd?.DangerousGetHandle() ?? IntPtr.Zero;

	/// <inheritdoc/>
	IntPtr IWindowInit.InitWndProcOnNCCreate(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
	{
		lock (this)
			Attach(hwnd, true);
		return InternalWndProc(hwnd, msg, IntPtr.Zero, lParam);
	}

	/// <summary>Writes message information to the debugger.</summary>
	/// <param name="msg">The message code.</param>
	/// <param name="sourceFilePath">The source file path.</param>
	/// <param name="caller">The calling method.</param>
	[Conditional("DEBUG")]
	internal static void DebugWriteMessageInfo(uint msg, [CallerFilePath] string sourceFilePath = "", [CallerMemberName] string? caller = "")
	{
		if (Enum.IsDefined(typeof(WindowMessage), (WindowMessage)msg))
			Debug.WriteLine($"{caller}={(WindowMessage)msg} ({sourceFilePath})");
		else
			Debug.WriteLine($"{caller}={msg:x} ({sourceFilePath})");
	}

	/// <summary>Writes method information to the debugger.</summary>
	/// <param name="sourceFilePath">The source file path.</param>
	/// <param name="caller">The calling method.</param>
	[Conditional("DEBUG")]
	internal static void DebugWriteMethod([CallerFilePath] string sourceFilePath = "", [CallerMemberName] string? caller = "") =>
			Debug.WriteLine($"{caller} ({sourceFilePath})");

	/// <summary>
	/// Attaches the specified window handle to this instance and associates this instance's <see cref="WindowProc"/> handlers using GWL_WNDPROC.
	/// </summary>
	/// <param name="hwnd">The window handle.</param>
	/// <param name="own">if set to <see langword="true"/>, the window will be destroyed and handle released on disposal.</param>
	protected virtual void Attach(HWND hwnd, bool own)
	{
		CheckDisposed();
		Debug.Assert(!hwnd.IsNull, "Attempt assigning invalid handle.");
		CheckDetached();

		// Set handle
		this.hwnd = new((IntPtr)hwnd, own);

		// Set handle's WNDPROC to this class'
		userDefWndProc ??= DefWindowProc;
		defWndProc = Param[WindowLongFlags.GWLP_WNDPROC];
		wndProc = InternalWndProc;
		Param[WindowLongFlags.GWLP_WNDPROC] = Marshal.GetFunctionPointerForDelegate(wndProc);
		Debug.Assert(defWndProc != Param[WindowLongFlags.GWLP_WNDPROC], "Subclassed ourself!");

		OnHandleChanged(hwnd);
	}

	/// <summary>Invokes the default window procedure associated with this window.</summary>
	/// <param name="hwnd">A handle to the window procedure that received the message.</param>
	/// <param name="msg">The message.</param>
	/// <param name="wParam">
	/// Additional message information. The content of this parameter depends on the value of the <paramref name="msg"/> parameter.
	/// </param>
	/// <param name="lParam">
	/// Additional message information. The content of this parameter depends on the value of the <paramref name="msg"/> parameter.
	/// </param>
	/// <returns>The return value is the result of the message processing and depends on the message.</returns>
	protected virtual IntPtr DefWndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam) =>
		defWndProc == default ? DefWindowProc(hwnd, msg, wParam, lParam) : CallWindowProc(defWndProc, hwnd, msg, wParam, lParam);

	/// <summary>
	/// Detaches this instance's <see cref="WindowProc"/> handlers using GWL_WNDPROC, restoring previous assignment, and destroys the window
	/// and closes the handle if owned.
	/// </summary>
	protected virtual void Detach()
	{
		if (hwnd is null) return;

		if (!hwnd.IsInvalid && prevWndProcPtr != IntPtr.Zero)
		{
			Param[WindowLongFlags.GWLP_WNDPROC] = prevWndProcPtr;
			prevWndProcPtr = IntPtr.Zero;
		}

		hwnd.Dispose();
		hwnd = null;

		OnHandleChanged(HWND.NULL);
	}

	/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
	protected virtual void Dispose(bool disposing)
	{
		if (isDisposed)
			return;
		lock (this)
			Detach();
		if (createdClass) wCls?.Unregister();
		isDisposed = true;
	}

	/// <summary>Called when this classes <see cref="InternalWndProc"/> method becomes primary.</summary>
	protected virtual void OnHandleChanged(HWND newHandle) => DebugWriteMethod();

	/// <summary>Called when the <see cref="WindowProc"/> call throws an exception.</summary>
	/// <param name="ex">The exception.</param>
	/// <returns>
	/// <see langword="true"/> if the exception is handled and does not need to be thrown; <see langword="false"/> to throw the exception
	/// from within the <see cref="WindowProc"/> procedure.
	/// </returns>
	protected virtual bool OnWndProcException(Exception ex) => false;

	/// <summary>Invokes the default window procedure associated with this window.</summary>
	/// <param name="hwnd">A handle to the window procedure that received the message.</param>
	/// <param name="msg">The message.</param>
	/// <param name="wParam">
	/// Additional message information. The content of this parameter depends on the value of the <paramref name="msg"/> parameter.
	/// </param>
	/// <param name="lParam">
	/// Additional message information. The content of this parameter depends on the value of the <paramref name="msg"/> parameter.
	/// </param>
	/// <returns>The return value is the result of the message processing and depends on the message.</returns>
	protected virtual IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam) => DefWndProc(hwnd, msg, wParam, lParam);

	[DebuggerStepThrough]
	private void CheckDetached()
	{
		if (hwnd is not null)
			throw new InvalidOperationException("Attempt to overwrite existing window handle.");
	}

	[DebuggerStepThrough]
	private void CheckDisposed()
	{
		if (isDisposed) throw new ObjectDisposedException(nameof(WindowBase));
	}

	/// <summary>
	/// This is the real <see cref="WindowProc"/> instance for the window. It calls either <see cref="WndProc(HWND, uint, IntPtr, IntPtr)"/>
	/// or <see cref="DefWndProc(HWND, uint, IntPtr, IntPtr)"/> depending on status.
	/// <para>It is responsible for setting <see cref="CreateParam"/> and calling <see cref="Created"/> and <see cref="Destroyed"/>.</para>
	/// </summary>
	/// <param name="hwnd">A handle to the window procedure that received the message.</param>
	/// <param name="msg">The message.</param>
	/// <param name="wParam">
	/// Additional message information. The content of this parameter depends on the value of the <paramref name="msg"/> parameter.
	/// </param>
	/// <param name="lParam">
	/// Additional message information. The content of this parameter depends on the value of the <paramref name="msg"/> parameter.
	/// </param>
	/// <returns>The return value is the result of the message processing and depends on the message.</returns>
	private IntPtr InternalWndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
	{
		DebugWriteMessageInfo(msg);
		if (msg == (uint)WindowMessage.WM_NCCREATE)
		{
			CreateParam = lParam.ToStructure<CREATESTRUCT>();
			return (IntPtr)1;
		}

		try
		{
			if (weakThisPtr.IsAlive && weakThisPtr.Target != null)
				return (customWndProc ?? WndProc)(hwnd, msg, wParam, lParam);
			else
				return DefWndProc(hwnd, msg, wParam, lParam);
		}
		catch (Exception ex)
		{
			if (!OnWndProcException(ex))
				throw ex;
			return IntPtr.Zero;
		}
		finally
		{
			switch ((WindowMessage)msg)
			{
				case WindowMessage.WM_CREATE:
					Created?.Invoke();
					break;
				case WindowMessage.WM_NCDESTROY:
					PostQuitMessage(0);
					Destroyed?.Invoke();
					break;
			}
		}
	}

	private class ParamIndexer : ISupportIndexer<WindowLongFlags, IntPtr>
	{
		private readonly IWindowInstance win;

		public ParamIndexer(IWindowInstance win) => this.win = win;

		public IntPtr this[WindowLongFlags flag]
		{
			get => win.Handle != HWND.NULL ? GetWindowLongAuto(win.Handle, flag) : throw new ObjectDisposedException(nameof(IWindowInstance));
			set { if (win.Handle != HWND.NULL) SetWindowLong(win.Handle, flag, value); else throw new ObjectDisposedException(nameof(IWindowInstance)); }
		}
	}
}