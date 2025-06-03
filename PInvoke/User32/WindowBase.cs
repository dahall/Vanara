using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>Interface for a class that holds a window handle.</summary>
/// <seealso cref="IHandle"/>
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
public class WindowBase : MarshalByRefObject, IDisposable, IWindowInstance, IWndProcProvider, IWindowHandle
{
	/// <summary>A window procedure override delegate.</summary>
	protected WindowProc? customWndProc;

	private static readonly object createWindowSyncObject = new();
	private readonly WeakReference weakThisPtr;
	private bool createdClass = false;
	private GCHandle gcWnd;
	private SafeHWND? hwnd;
	private bool isDisposed;
	private ParamIndexer? paramIndexer;
	private WindowClass? wCls;

	/// <summary>Initializes a new instance of the <see cref="WindowBase"/> class without creating the window.</summary>
	public WindowBase() => weakThisPtr = new(this);

	/// <summary>Initializes a new instance of the <see cref="WindowBase"/> class and defines a window procedure to use.</summary>
	/// <param name="wndProcOverride">The window procedure override delegate.</param>
	public WindowBase(WindowProc wndProcOverride) : this() => customWndProc = wndProcOverride;

	internal WindowBase(HWND hwnd) : this() => wCls = Win32Error.ThrowLastErrorIfNull(WindowClass.GetInstanceFromWindow(this.hwnd = new(hwnd, false)));

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
	public CREATESTRUCT CreateParam { get; internal set; } = default;

	/// <summary>Gets the window handle.</summary>
	/// <value>The window handle.</value>
	public HWND Handle => hwnd ?? HWND.NULL;

	/// <inheritdoc/>
	public bool IsInvalid => hwnd?.IsInvalid ?? true;

	/// <summary>Gets or sets information about the window.</summary>
	/// <value>The information indexer.</value>
	public ISupportIndexer<WindowLongFlags, IntPtr> Param => paramIndexer ??= new ParamIndexer(this);

	/// <summary>Gets the window class registered for this window.</summary>
	/// <value>The window class.</value>
	public WindowClass? WindowClass => wCls;

	WindowProc IWndProcProvider.WndProc => WndProc;

	/// <summary>Performs an implicit conversion from <see cref="WindowBase"/> to <see cref="HWND"/>.</summary>
	/// <param name="w">The <see cref="WindowBase"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HWND(WindowBase? w) => w?.Handle ?? HWND.NULL;

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
		CreateParams cp = new(wc ?? WindowClass.MakeVisibleWindowClass($"{GetType().Name}+{Guid.NewGuid():N}", null),
			text ?? "", size, position, style, exStyle, parent, hMenu);
		CreateHandle(cp);
	}

	/// <summary>Creates a window and its handle with the specified creation parameters.</summary>
	/// <param name="cp">The parameters to use to create the window.</param>
	public virtual void CreateHandle(CreateParams cp)
	{
		lock (this)
		{
			CheckDetached();
			lock (createWindowSyncObject)
			{
				if (hwnd is not null)
					return;
				gcWnd = GCHandle.Alloc(this);
				hwnd = Win32Error.ThrowLastErrorIfInvalid(CreateWindowEx(cp.ExStyle, cp.Class.ClassName, cp.Text, cp.Style, cp.Position.X,
					cp.Position.Y, cp.Size.Width, cp.Size.Height, cp.Parent, cp.Menu, cp.Class.wc.hInstance, GCHandle.ToIntPtr(gcWnd)));
			}
		}
	}

	/// <summary>Creates and runs a window of the specified type, using the provided creation parameters and an optional message pump.</summary>
	/// <typeparam name="T">The type of the window to create. Must derive from <see cref="WindowBase"/> and have a parameterless constructor.</typeparam>
	/// <param name="cp">The parameters used to create the window. These define properties such as size, position, and style.</param>
	/// <param name="getPump">
	/// An optional delegate to get the <see cref="MessagePump"/> instance to process window messages. If not provided, a default message
	/// pump is used.
	/// </param>
	/// <returns>The exit code returned by the message pump after the window is closed.</returns>
	/// <exception cref="Win32Exception">Thrown if the window fails to be created.</exception>
	public static int Run<T>(CreateParams cp, Func<HWND, MessagePump>? getPump = null) where T : WindowBase, new()
	{
		using var win = new T();
		win.CreateHandle(cp);
		if (win.Handle.IsNull)
			throw new Win32Exception("Failed to create window.");
		MessagePump pump = getPump?.Invoke(win.Handle) ?? new MessagePump();
		return pump.Run(win);
	}

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		Dispose(true);
		System.GC.SuppressFinalize(this);
	}

	/// <inhertdoc/>
	IntPtr IHandle.DangerousGetHandle() => hwnd?.DangerousGetHandle() ?? IntPtr.Zero;

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

	/// <summary>If this object is disposed, throws <see cref="ObjectDisposedException"/>.</summary>
	[DebuggerStepThrough]
	protected virtual void CheckDisposed()
	{
		if (isDisposed) throw new ObjectDisposedException(nameof(WindowBase));
	}

	/// <summary>Invokes the default window procedure associated with this window. This should almost never be overridden.</summary>
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
		User32.DefWindowProc(hwnd, msg, wParam, lParam);

	/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
	protected virtual void Dispose(bool disposing)
	{
		if (isDisposed)
			return;
		lock (this)
		{
			hwnd?.Dispose();
			hwnd = null;
		}

		if (createdClass) wCls?.Unregister();
		gcWnd.Free();
		isDisposed = true;
	}

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
	protected virtual IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
	{
		DebugWriteMessageInfo(msg);
		if (msg == (uint)WindowMessage.WM_NCCREATE)
		{
			CreateParam = lParam.ToStructure<CREATESTRUCT>();
			return (IntPtr)1;
		}

		try
		{
			if (!isDisposed && weakThisPtr.IsAlive && weakThisPtr.Target != null && customWndProc is not null)
				return customWndProc(hwnd, msg, wParam, lParam);
			else
				return DefWndProc(hwnd, msg, wParam, lParam);
		}
		catch (Exception ex)
		{
			if (!OnWndProcException(ex))
				throw;
			return IntPtr.Zero;
		}
		finally
		{
			switch ((WindowMessage)msg)
			{
				case WindowMessage.WM_CREATE:
					this.hwnd = new(hwnd, false);
					Created?.Invoke();
					break;
				case WindowMessage.WM_NCDESTROY:
					PostQuitMessage(0);
					Destroyed?.Invoke();
					break;
			}
		}
	}

	[DebuggerStepThrough]
	private void CheckDetached()
	{
		if (hwnd is not null && !hwnd.IsNull)
			throw new InvalidOperationException("Attempt to overwrite existing window handle.");
	}

	private class ParamIndexer(IWindowInstance win) : ISupportIndexer<WindowLongFlags, IntPtr>
	{
		public IntPtr this[WindowLongFlags flag]
		{
			get => win.Handle != HWND.NULL ? GetWindowLongAuto(win.Handle, flag) : throw new ObjectDisposedException(nameof(IWindowInstance));
			set { if (win.Handle != HWND.NULL) SetWindowLong(win.Handle, flag, value); else throw new ObjectDisposedException(nameof(IWindowInstance)); }
		}
	}
}

/// <summary>
/// Represents the parameters used to create a window in a Windows-based application.
/// </summary>
/// <remarks>This class encapsulates the various attributes required to define a window, such as its size,
/// position, style,  and parent relationships. It is typically used when calling window creation functions, such as
/// <c>CreateWindowEx</c>. Each property corresponds to a specific parameter in the underlying Windows API.</remarks>
public class CreateParams(WindowClass @class, string text, SIZE? size = null, POINT? position = null, User32.WindowStyles style = 0, User32.WindowStylesEx exStyle = 0, HWND parent = default, HMENU menu = default)
{
	/// <summary>Gets or sets the window class.</summary>
	public WindowClass Class { get; set; } = @class;
	/// <summary>Gets or sets the window text.</summary>
	public string Text { get; set; } = text;
	/// <summary>Gets or sets the size of the window.</summary>
	public SIZE Size { get; set; } = size ?? new(CW_USEDEFAULT, CW_USEDEFAULT);
	/// <summary>Gets or sets the position of the window.</summary>
	public POINT Position { get; set; } = position ?? new(CW_USEDEFAULT, CW_USEDEFAULT);
	/// <summary>Gets or sets the window style.</summary>
	public WindowStyles Style { get; set; } = style;
	/// <summary>Gets or sets the extended window style.</summary>
	public WindowStylesEx ExStyle { get; set; } = exStyle;
	/// <summary>Gets or sets the parent window handle.</summary>
	public HWND Parent { get; set; } = parent;
	/// <summary>Gets or sets the menu handle.</summary>
	public HMENU Menu { get; set; } = menu;
	/// <summary>Gets or sets the accelerator table handle.</summary>
	public HACCEL Accelerator { get; set; } = default;
}