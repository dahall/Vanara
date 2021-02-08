using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke
{
	/// <summary>Encapsulates a window class.</summary>
	public class WindowClass
	{
		/// <summary>The instance of the <see cref="WNDCLASSEX"/> populated for the window class.</summary>
		public readonly WNDCLASSEX wc;

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
		public WindowClass(string className, HINSTANCE hInst, WindowProc wndProc, WindowClassStyles styles = 0, HICON hIcon = default, HICON hSmIcon = default,
			HCURSOR hCursor = default, HBRUSH hbrBkgd = default, string menuName = null, int extraBytes = 0, int extraWinBytes = 0)
		{
			// TODO: Find way to hold on to wndProc ref
			wc = new WNDCLASSEX
			{
				cbSize = (uint)Marshal.SizeOf(typeof(WNDCLASSEX)),
				lpfnWndProc = wndProc,
				hInstance = hInst,
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
			Atom = Win32Error.ThrowLastErrorIfNull(Macros.MAKEINTATOM(RegisterClassEx(wc)));
		}

		private WindowClass(in WNDCLASSEX wcx) => wc = wcx;

		/// <summary>Gets the class atom that uniquely identifies the registered class.</summary>
		public IntPtr Atom { get; private set; }

		/// <summary>Gets the windows class name.</summary>
		public string ClassName => wc.lpszClassName;

		/// <summary>Gets the class style(s).</summary>
		public WindowClassStyles Styles => wc.style;

		/// <summary>Gets a <see cref="WindowClass"/> instance associated with a window handle.</summary>
		/// <param name="hWnd">The window handle to examine.</param>
		/// <returns>
		/// If the function finds a matching window and successfully copies the data, the return value is a <see cref="WindowClass"/>
		/// instance. If not, <see langword="null"/> is returned.
		/// </returns>
		public static WindowClass GetInstanceFromWindow(HWND hWnd)
		{
			var atom = GetClassWord(hWnd, -32 /*GCW_ATOM*/);
			var hInst = GetClassLong(hWnd, -16 /*GCL_HMODULE*/);
			var wcx = new WNDCLASSEX { cbSize = (uint)Marshal.SizeOf(typeof(WNDCLASSEX)) };
			return GetClassInfoEx(hInst, Macros.MAKEINTATOM(atom), ref wcx) ? new WindowClass(wcx) : null;
		}

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
		public static WindowClass GetNamedInstance(string className, HINSTANCE hInst = default)
		{
			var wcx = new WNDCLASSEX { cbSize = (uint)Marshal.SizeOf(typeof(WNDCLASSEX)) };
			return GetClassInfoEx(hInst, className, ref wcx) ? new WindowClass(wcx) : null;
		}

		/// <summary>Unregisters this window class.</summary>
		/// <returns>
		/// <para>If the function succeeds, the return value is <see langword="true"/>.</para>
		/// <para>
		/// If the class could not be found or if a window still exists that was created with the class, the return value is <see
		/// langword="false"/>. To get extended error information, call GetLastError.
		/// </para>
		/// </returns>
		public bool Unregister() => UnregisterClass(wc.lpszClassName, wc.hInstance);
	}
}