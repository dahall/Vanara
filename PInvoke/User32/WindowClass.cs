using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>Interface identifying a class that can provide a window proceedure.</summary>
public interface IWndProcProvider
{
	/// <summary>
	/// Property fetched on WM_NCCREATE which provides a new window procedure. The window must provide a GCHandle pointer to itself in the
	/// lpParam parameter of CreateWindowEx.
	/// </summary>
	/// <value>The window procedure.</value>
	WindowProc WndProc { get; }
}

/// <summary>Encapsulates a window class.</summary>
public class WindowClass
{
	/// <summary>The instance of the <see cref="WNDCLASSEX"/> populated for the window class.</summary>
	public readonly WNDCLASSEX wc;

	/// <summary>The prior WND proc map</summary>
	protected static readonly Dictionary<HWND, IntPtr> PriorWndProcMap = [];

	private static readonly uint cbSize = (uint)Marshal.SizeOf(typeof(WNDCLASSEX));
	private static SafeHICON? appIcon;
	private static SafeHCURSOR? arrowCursor;
	private readonly WindowProc instProc;
	private WindowProc? userProc;

	/// <summary>Initializes a new instance of the <see cref="WindowClass"/> class and registers the class name.</summary>
	/// <param name="className">
	/// <para>
	/// A string that specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx,
	/// or any of the predefined control-class names.
	/// </para>
	/// <para>
	/// The maximum length for <c>lpszClassName</c> is 256. If <c>lpszClassName</c> is greater than the maximum length, the
	/// RegisterClassEx function will fail.
	/// </para>
	/// </param>
	/// <param name="hInst">A handle to the instance that contains the window procedure for the class.</param>
	/// <param name="wndProc">
	/// A pointer to the window procedure. You must use the CallWindowProc function to call the window procedure. For more information,
	/// see WindowProc.
	/// </param>
	/// <param name="styles">The class style(s). This member can be any combination of the Class Styles.</param>
	/// <param name="hIcon">
	/// A handle to the class icon. This member must be a handle to an icon resource. If this member is <c>NULL</c>, the system provides
	/// a default icon.
	/// </param>
	/// <param name="hSmIcon">
	/// A handle to a small icon that is associated with the window class. If this member is <c>NULL</c>, the system searches the icon
	/// resource specified by the <c>hIcon</c> member for an icon of the appropriate size to use as the small icon.
	/// </param>
	/// <param name="hCursor">
	/// A handle to the class cursor. This member must be a handle to a cursor resource. If this member is <c>NULL</c>, an application
	/// must explicitly set the cursor shape whenever the mouse moves into the application's window.
	/// </param>
	/// <param name="hbrBkgd">
	/// A handle to the class background brush. This member can be a handle to the brush to be used for painting the background, or it
	/// can be a color value. A color value must be one of the following standard system colors (the value 1 must be added to the chosen color).
	/// <para>
	/// The system automatically deletes class background brushes when the class is unregistered by using <see cref="UnregisterClass"/>.
	/// An application should not delete these brushes.
	/// </para>
	/// <para>
	/// When this member is <c>NULL</c>, an application must paint its own background whenever it is requested to paint in its client
	/// area. To determine whether the background must be painted, an application can either process the WM_ERASEBKGND message or test
	/// the <c>fErase</c> member of the PAINTSTRUCT structure filled by the BeginPaint function.
	/// </para>
	/// </param>
	/// <param name="menuName">
	/// A string that specifies the resource name of the class menu, as the name appears in the resource file. If you use an integer to
	/// identify the menu, use the MAKEINTRESOURCE macro. If this member is <c>NULL</c>, windows belonging to this class have no default menu.
	/// </param>
	/// <param name="extraBytes">
	/// The number of extra bytes to allocate following the window-class structure. The system initializes the bytes to zero.
	/// </param>
	/// <param name="extraWinBytes">
	/// The number of extra bytes to allocate following the window instance. The system initializes the bytes to zero. If an application
	/// uses <c>WNDCLASSEX</c> to register a dialog box created by using the <c>CLASS</c> directive in the resource file, it must set
	/// this member to <c>DLGWINDOWEXTRA</c>.
	/// </param>
	public WindowClass(string? className = null, HINSTANCE hInst = default, WindowProc? wndProc = default, WindowClassStyles styles = 0, HICON hIcon = default, HICON hSmIcon = default,
		HCURSOR hCursor = default, HBRUSH hbrBkgd = default, string? menuName = null, int extraBytes = 0, int extraWinBytes = 0) : this()
	{
		userProc = wndProc;
		className ??= $"VWC+{Guid.NewGuid():N}";
		if (className.Length > 256)
			throw new ArgumentException("The maximum length for className is 256.", nameof(className));
		wc = new WNDCLASSEX
		{
			cbSize = cbSize,
			lpfnWndProc = instProc,
			hInstance = hInst.IsNull ? Kernel32.GetModuleHandle() : hInst,
			lpszClassName = className,
			style = styles,
			hIcon = hIcon,
			hIconSm = hSmIcon,
			hCursor = hCursor,
			hbrBackground = hbrBkgd,
			lpszMenuName = menuName,
			cbClsExtra = extraBytes,
			cbWndExtra = extraWinBytes,
		};
		Win32Error.ThrowLastErrorIfFalse(!RegisterClassEx(wc).IsInvalid);
	}

	/// <summary>Initializes a new instance of the <see cref="WindowClass"/> class using a <see cref="WNDCLASSEX"/> instance.</summary>
	/// <param name="wcx">The <see cref="WNDCLASSEX"/> instance.</param>
	/// <param name="register">if set to <see langword="true"/>, <paramref name="wcx"/> is used to register the class.</param>
	public WindowClass(in WNDCLASSEX wcx, bool register = true) : this()
	{
		wc = wcx;
		if (register)
		{
			userProc = wc.lpfnWndProc;
			wc.lpfnWndProc = instProc;
			Win32Error.ThrowLastErrorIfFalse(!RegisterClassEx(wc).IsInvalid);
		}
	}

	private WindowClass() => instProc = PrimaryClassWndProc;

	/// <summary>Gets a handle to the brush representing the standard MDI window background (COLOR_APPWORKSPACE).</summary>
	/// <value>The standard MDI window background brush handle.</value>
	public static HBRUSH MdiWindowBrush => (HBRUSH)(IntPtr)(SystemColorIndex.COLOR_APPWORKSPACE + 1);

	/// <summary>
	/// Gets a handle to a null brush (GetStockObject(NULL_BRUSH)). Use this for the background of non-displayable windows or to prevent
	/// flicker on custom drawn backgrounds.
	/// </summary>
	/// <value>The null background brush handle.</value>
	public static HBRUSH NullBrush => GetStockObject(StockObjectType.NULL_BRUSH);

	/// <summary>Gets a handle to the standard application icon (IDI_APPLICATION).</summary>
	/// <value>The standard application icon handle.</value>
	public static HICON StdAppIcon => appIcon ??= LoadIcon(default, IDI_APPLICATION);

	/// <summary>Gets a handle to the standard arrow cursor (IDC_ARROW).</summary>
	/// <value>The standard arrow cursor handle.</value>
	public static HCURSOR StdArrowCursor => arrowCursor ??= LoadCursor(default, IDC_ARROW);

	/// <summary>Gets a handle to the brush representing the standard window background (COLOR_WINDOW).</summary>
	/// <value>The standard window background brush handle.</value>
	public static HBRUSH WindowBrush => (HBRUSH)(IntPtr)(SystemColorIndex.COLOR_WINDOW + 1);

	/// <summary>Gets the windows class name.</summary>
	public string ClassName => wc.lpszClassName;

	/// <summary>Gets the class style(s).</summary>
	public WindowClassStyles Styles => wc.style;

	/// <summary>Gets the <see cref="WindowProc"/> that is executed by this class.</summary>
	/// <value>The executing <see cref="WindowProc"/>.</value>
	public WindowProc WndProc
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => userProc ?? DefWindowProc;
	}

	/// <summary>Gets a <see cref="WindowClass"/> instance associated with a window handle.</summary>
	/// <param name="hWnd">The window handle to examine.</param>
	/// <returns>
	/// If the function finds a matching window and successfully copies the data, the return value is a <see cref="WindowClass"/>
	/// instance. If not, <see langword="null"/> is returned.
	/// </returns>
	public static WindowClass? GetInstanceFromWindow(HWND hWnd) => GetNamedInstance(GetClassName(hWnd), GetClassLong(hWnd, GetClassLongFlag.GCL_HMODULE));

	/// <summary>Gets a <see cref="WindowClass"/> instance by looking up the name.</summary>
	/// <param name="className">
	/// The class name. The name must be that of a preregistered class or a class registered by a previous call to the RegisterClass or
	/// RegisterClassEx function.
	/// </param>
	/// <param name="hInst">
	/// A handle to the instance of the application that created the class. To retrieve information about classes defined by the system
	/// (such as buttons or list boxes), set this parameter to NULL.
	/// </param>
	/// <returns>
	/// If the function finds a matching class and successfully copies the data, the return value is a <see cref="WindowClass"/>
	/// instance. If not, <see langword="null"/> is returned.
	/// </returns>
	public static WindowClass? GetNamedInstance(string className, HINSTANCE hInst)
	{
		if (string.IsNullOrEmpty(className))
			throw new ArgumentException($"'{nameof(className)}' cannot be null or empty.", nameof(className));

		return GetClassInfoEx(hInst, className, out var wcx) ? new(wcx, false) : null;
	}

	/// <summary>Creates a <see cref="WindowClass"/> instance that uses common settings for a displayed window.</summary>
	/// <param name="className">
	/// <para>
	/// A string that specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx,
	/// or any of the predefined control-class names.
	/// </para>
	/// <para>
	/// The maximum length for <c>lpszClassName</c> is 256. If <c>lpszClassName</c> is greater than the maximum length, the
	/// RegisterClassEx function will fail.
	/// </para>
	/// </param>
	/// <param name="hInst">A handle to the instance that contains the window procedure for the class.</param>
	/// <param name="wndProc">
	/// A pointer to the window procedure. You must use the CallWindowProc function to call the window procedure. For more information,
	/// see WindowProc.
	/// </param>
	/// <returns>
	/// A new instance of <see cref="WindowClass"/> with indicated parameters, standard app icon, arrow cursor, and window system color background.
	/// </returns>
	public static WindowClass MakeVisibleWindowClass(string? className, WindowProc? wndProc, HINSTANCE hInst = default) =>
		new(className, hInst.IsNull ? Kernel32.GetModuleHandle() : hInst, wndProc, 0, StdAppIcon, default, StdArrowCursor, WindowBrush);

	/// <summary>Unregisters this window class.</summary>
	/// <returns>
	/// <para>If the function succeeds, the return value is <see langword="true"/>.</para>
	/// <para>
	/// If the class could not be found or if a window still exists that was created with the class, the return value is <see
	/// langword="false"/>. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	public bool Unregister() => UnregisterClass(wc.lpszClassName, wc.hInstance);

	/// <summary>Restores a window's original windows proc, if subclassed by this object.</summary>
	/// <param name="hwnd">The window handle.</param>
	protected static void RestoreWindowProc(HWND hwnd)
	{
		if (!PriorWndProcMap.TryGetValue(hwnd, out var p)) return;
		SetWindowLong(hwnd, WindowLongFlags.GWL_WNDPROC, p);
		PriorWndProcMap.Remove(hwnd);
	}

	/// <summary>Subclasses the window.</summary>
	/// <param name="hwnd">The window handle.</param>
	/// <param name="wndProc">The new <see cref="WindowProc"/>.</param>
	protected static void SubclassWindow(HWND hwnd, WindowProc wndProc)
	{
		IntPtr old = SetWindowLong(hwnd, WindowLongFlags.GWL_WNDPROC, Marshal.GetFunctionPointerForDelegate(wndProc));
		PriorWndProcMap.Add(hwnd, old);
	}

	/// <summary>An class function that processes messages sent to this class instance.</summary>
	/// <param name="hwnd">A handle to the window.</param>
	/// <param name="msg">The MSG.</param>
	/// <param name="wParam">Additional message information. The contents of this parameter depend on the value of the uMsg parameter.</param>
	/// <param name="lParam">Additional message information. The contents of this parameter depend on the value of the uMsg parameter.</param>
	/// <returns>The return value is the result of the message processing and depends on the message sent.</returns>
	protected virtual IntPtr PrimaryClassWndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
	{
		WindowBase.DebugWriteMessageInfo(msg);
		try
		{
			if (msg == (uint)WindowMessage.WM_NCCREATE)
			{
				unsafe
				{
					CREATESTRUCT_UNMGD* cp = (CREATESTRUCT_UNMGD*)lParam.ToPointer();
					if (cp->lpCreateParams != IntPtr.Zero && GCHandle.FromIntPtr(cp->lpCreateParams).Target is IWndProcProvider wnd)
					{
						// Subclass the calling window with it's provided WindowProc
						SubclassWindow(hwnd, wnd.WndProc);
						return wnd.WndProc(hwnd, msg, wParam, lParam);
					}
				}
			}
			return WndProc.Invoke(hwnd, msg, wParam, lParam);
		}
		catch
		{
			return IntPtr.Zero;
		}
	}

	private static string GetClassName(HWND hwnd)
	{
		StringBuilder sb = new(257);
		Win32Error.ThrowLastErrorIf(User32.GetClassName(hwnd, sb, sb.Capacity), i => i == 0);
		return sb.ToString();
	}
}