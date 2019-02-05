using System.Drawing;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32_Gdi
	{
		/// <summary>
		/// Creates a new shape for the system caret and assigns ownership of the caret to the specified window. The caret shape can be a
		/// line, a block, or a bitmap.
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window that owns the caret.</para>
		/// </param>
		/// <param name="hBitmap">
		/// <para>Type: <c>HBITMAP</c></para>
		/// <para>
		/// A handle to the bitmap that defines the caret shape. If this parameter is <c>NULL</c>, the caret is solid. If this parameter is ,
		/// the caret is gray. If this parameter is a bitmap handle, the caret is the specified bitmap. The bitmap handle must have been
		/// created by the CreateBitmap, CreateDIBitmap, or LoadBitmap function.
		/// </para>
		/// <para>
		/// If hBitmap is a bitmap handle, <c>CreateCaret</c> ignores the nWidth and nHeight parameters; the bitmap defines its own width and height.
		/// </para>
		/// </param>
		/// <param name="nWidth">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The width of the caret, in logical units. If this parameter is zero, the width is set to the system-defined window border width.
		/// If hBitmap is a bitmap handle, <c>CreateCaret</c> ignores this parameter.
		/// </para>
		/// </param>
		/// <param name="nHeight">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The height of the caret, in logical units. If this parameter is zero, the height is set to the system-defined window border
		/// height. If hBitmap is a bitmap handle, <c>CreateCaret</c> ignores this parameter.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The nWidth and nHeight parameters specify the caret's width and height, in logical units; the exact width and height, in pixels,
		/// depend on the window's mapping mode.
		/// </para>
		/// <para>
		/// <c>CreateCaret</c> automatically destroys the previous caret shape, if any, regardless of the window that owns the caret. The
		/// caret is hidden until the application calls the ShowCaret function to make the caret visible.
		/// </para>
		/// <para>
		/// The system provides one caret per queue. A window should create a caret only when it has the keyboard focus or is active. The
		/// window should destroy the caret before losing the keyboard focus or becoming inactive.
		/// </para>
		/// <para>DPI Virtualization</para>
		/// <para>
		/// This API does not participate in DPI virtualization. The width and height parameters are interpreted as logical sizes in terms of
		/// the window in question. The calling thread is not taken into consideration.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createcaret BOOL CreateCaret( HWND hWnd, HBITMAP hBitmap,
		// int nWidth, int nHeight );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateCaret(HWND hWnd, HBITMAP hBitmap, int nWidth, int nHeight);

		/// <summary>Destroys the caret's current shape, frees the caret from the window, and removes the caret from the screen.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>DestroyCaret</c> destroys the caret only if a window in the current task owns the caret. If a window that is not in the
		/// current task owns the caret, <c>DestroyCaret</c> does nothing and returns <c>FALSE</c>.
		/// </para>
		/// <para>
		/// The system provides one caret per queue. A window should create a caret only when it has the keyboard focus or is active. The
		/// window should destroy the caret before losing the keyboard focus or becoming inactive.
		/// </para>
		/// <para>For an example, see Destroying a Caret</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-destroycaret BOOL DestroyCaret( );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DestroyCaret();

		/// <summary>Retrieves the time required to invert the caret's pixels. The user can set this value.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>If the function succeeds, the return value is the blink time, in milliseconds.</para>
		/// <para>A return value of <c>INFINITE</c> indicates that the caret does not blink.</para>
		/// <para>A return value is zero indicates that the function has failed. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getcaretblinktime UINT GetCaretBlinkTime( );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		public static extern uint GetCaretBlinkTime();

		/// <summary>Copies the caret's position to the specified POINT structure.</summary>
		/// <param name="lpPoint">
		/// <para>Type: <c>LPPOINT</c></para>
		/// <para>A pointer to the POINT structure that is to receive the client coordinates of the caret.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The caret position is always given in the client coordinates of the window that contains the caret.</para>
		/// <para>DPI Virtualization</para>
		/// <para>
		/// This API does not participate in DPI virtualization. The returned values are interpreted as logical sizes in terms of the window
		/// in question. The calling thread is not taken into consideration.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getcaretpos BOOL GetCaretPos( LPPOINT lpPoint );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetCaretPos(out Point lpPoint);

		/// <summary>
		/// Removes the caret from the screen. Hiding a caret does not destroy its current shape or invalidate the insertion point.
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window that owns the caret. If this parameter is <c>NULL</c>, <c>HideCaret</c> searches the current task for the
		/// window that owns the caret.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>HideCaret</c> hides the caret only if the specified window owns the caret. If the specified window does not own the caret,
		/// <c>HideCaret</c> does nothing and returns <c>FALSE</c>.
		/// </para>
		/// <para>
		/// Hiding is cumulative. If your application calls <c>HideCaret</c> five times in a row, it must also call ShowCaret five times
		/// before the caret is displayed.
		/// </para>
		/// <para>For an example, see Hiding a Caret.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-hidecaret BOOL HideCaret( HWND hWnd );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool HideCaret(HWND hWnd);

		/// <summary>
		/// Sets the caret blink time to the specified number of milliseconds. The blink time is the elapsed time, in milliseconds, required
		/// to invert the caret's pixels.
		/// </summary>
		/// <param name="uMSeconds">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The new blink time, in milliseconds.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The user can set the blink time using the Control Panel. Applications should respect the setting that the user has chosen. The
		/// <c>SetCaretBlinkTime</c> function should only be used by application that allow the user to set the blink time, such as a Control
		/// Panel applet.
		/// </para>
		/// <para>
		/// If you change the blink time, subsequently activated applications will use the modified blink time, even if you restore the
		/// previous blink time when you lose the keyboard focus or become inactive. This is due to the multithreaded environment, where
		/// deactivation of your application is not synchronized with the activation of another application. This feature allows the system
		/// to activate another application even if the current application is not responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setcaretblinktime BOOL SetCaretBlinkTime( UINT uMSeconds );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetCaretBlinkTime(uint uMSeconds);

		/// <summary>
		/// Moves the caret to the specified coordinates. If the window that owns the caret was created with the <c>CS_OWNDC</c> class style,
		/// then the specified coordinates are subject to the mapping mode of the device context associated with that window.
		/// </summary>
		/// <param name="X">
		/// <para>Type: <c>int</c></para>
		/// <para>The new x-coordinate of the caret.</para>
		/// </param>
		/// <param name="Y">
		/// <para>Type: <c>int</c></para>
		/// <para>The new y-coordinate of the caret.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>SetCaretPos</c> moves the caret whether the caret is hidden.</para>
		/// <para>
		/// The system provides one caret per queue. A window should create a caret only when it has the keyboard focus or is active. The
		/// window should destroy the caret before losing the keyboard focus or becoming inactive. A window can set the caret position only
		/// if it owns the caret.
		/// </para>
		/// <para>DPI Virtualization</para>
		/// <para>
		/// This API does not participate in DPI virtualization. The provided position is interpreted as logical coordinates in terms of the
		/// window associated with the caret. The calling thread is not taken into consideration.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating and Displaying a Caret.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setcaretpos BOOL SetCaretPos( int X, int Y );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetCaretPos(int X, int Y);

		/// <summary>
		/// Makes the caret visible on the screen at the caret's current position. When the caret becomes visible, it begins flashing automatically.
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window that owns the caret. If this parameter is <c>NULL</c>, <c>ShowCaret</c> searches the current task for the
		/// window that owns the caret.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>ShowCaret</c> shows the caret only if the specified window owns the caret, the caret has a shape, and the caret has not been
		/// hidden two or more times in a row. If one or more of these conditions is not met, <c>ShowCaret</c> does nothing and returns <c>FALSE</c>.
		/// </para>
		/// <para>
		/// Hiding is cumulative. If your application calls HideCaret five times in a row, it must also call <c>ShowCaret</c> five times
		/// before the caret reappears.
		/// </para>
		/// <para>
		/// The system provides one caret per queue. A window should create a caret only when it has the keyboard focus or is active. The
		/// window should destroy the caret before losing the keyboard focus or becoming inactive.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating and Displaying a Caret.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-showcaret BOOL ShowCaret( HWND hWnd );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowCaret(HWND hWnd);
	}
}