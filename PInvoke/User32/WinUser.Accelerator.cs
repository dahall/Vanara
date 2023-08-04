namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>Flags used by <see cref="ACCEL.fVirt"/>.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum FVIRT : byte
	{
		/// <summary>
		/// The key member specifies a virtual-key code. If this flag is not specified, key is assumed to specify a character code.
		/// </summary>
		FVIRTKEY = 0x01,

		/// <summary>
		/// No top-level menu item is highlighted when the accelerator is used. If this flag is not specified, a top-level menu item will
		/// be highlighted, if possible, when the accelerator is used. This attribute is obsolete and retained only for backward
		/// compatibility with resource files designed for 16-bit Windows.
		/// </summary>
		FNOINVERT = 0x02,

		/// <summary>The SHIFT key must be held down when the accelerator key is pressed.</summary>
		FSHIFT = 0x04,

		/// <summary>The CTRL key must be held down when the accelerator key is pressed.</summary>
		FCONTROL = 0x08,

		/// <summary>The ALT key must be held down when the accelerator key is pressed.</summary>
		FALT = 0x10,
	}

	/// <summary>
	/// Copies the specified accelerator table. This function is used to obtain the accelerator-table data that corresponds to an
	/// accelerator-table handle, or to determine the size of the accelerator-table data.
	/// </summary>
	/// <param name="hAccelSrc">
	/// <para>Type: <c>HACCEL</c></para>
	/// <para>A handle to the accelerator table to copy.</para>
	/// </param>
	/// <param name="lpAccelDst">
	/// <para>Type: <c>LPACCEL</c></para>
	/// <para>An array of ACCEL structures that receives the accelerator-table information.</para>
	/// </param>
	/// <param name="cAccelEntries">
	/// <para>Type: <c>int</c></para>
	/// <para>The number of ACCEL structures to copy to the buffer pointed to by the lpAccelDst parameter.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// If lpAccelDst is <c>NULL</c>, the return value specifies the number of accelerator-table entries in the original table.
	/// Otherwise, it specifies the number of accelerator-table entries that were copied.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-copyacceleratortablea int CopyAcceleratorTableA( HACCEL
	// hAccelSrc, LPACCEL lpAccelDst, int cAccelEntries );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h")]
	public static extern int CopyAcceleratorTable(HACCEL hAccelSrc, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ACCEL[] lpAccelDst, int cAccelEntries);

	/// <summary>Creates an accelerator table.</summary>
	/// <param name="paccel">
	/// <para>Type: <c>LPACCEL</c></para>
	/// <para>An array of ACCEL structures that describes the accelerator table.</para>
	/// </param>
	/// <param name="cAccel">
	/// <para>Type: <c>int</c></para>
	/// <para>The number of ACCEL structures in the array. This must be within the range 1 to 32767 or the function will fail.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HACCEL</c></para>
	/// <para>
	/// If the function succeeds, the return value is the handle to the created accelerator table; otherwise, it is <c>NULL</c>. To get
	/// extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Before an application closes, it can use the DestroyAcceleratorTable function to destroy any accelerator tables that it created
	/// by using the <c>CreateAcceleratorTable</c> function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating User Editable Accelerators.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createacceleratortablea HACCEL CreateAcceleratorTableA(
	// LPACCEL paccel, int cAccel );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h")]
	public static extern SafeHACCEL CreateAcceleratorTable([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ACCEL[] paccel, int cAccel);

	/// <summary>Destroys an accelerator table.</summary>
	/// <param name="hAccel">
	/// <para>Type: <c>HACCEL</c></para>
	/// <para>
	/// A handle to the accelerator table to be destroyed. This handle must have been created by a call to the CreateAcceleratorTable or
	/// LoadAccelerators function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If the function succeeds, the return value is nonzero. However, if the table has been loaded more than one call to
	/// LoadAccelerators, the function will return a nonzero value only when <c>DestroyAcceleratorTable</c> has been called an equal
	/// number of times.
	/// </para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-destroyacceleratortable BOOL DestroyAcceleratorTable(
	// HACCEL hAccel );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DestroyAcceleratorTable(HACCEL hAccel);

	/// <summary>Loads the specified accelerator table.</summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the module whose executable file contains the accelerator table to be loaded.</para>
	/// </param>
	/// <param name="lpTableName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The name of the accelerator table to be loaded. Alternatively, this parameter can specify the resource identifier of an
	/// accelerator-table resource in the low-order word and zero in the high-order word. To create this value, use the MAKEINTRESOURCE macro.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HACCEL</c></para>
	/// <para>If the function succeeds, the return value is a handle to the loaded accelerator table.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>If the accelerator table has not yet been loaded, the function loads it from the specified executable file.</para>
	/// <para>Accelerator tables loaded from resources are freed automatically when the application terminates.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating Accelerators for Font Attributes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-loadacceleratorsa HACCEL LoadAcceleratorsA( HINSTANCE
	// hInstance, LPCSTR lpTableName );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h")]
	public static extern HACCEL LoadAccelerators(HINSTANCE hInstance, SafeResourceId lpTableName);

	/// <summary>
	/// Processes accelerator keys for menu commands. The function translates a WM_KEYDOWN or WM_SYSKEYDOWN message to a WM_COMMAND or
	/// WM_SYSCOMMAND message (if there is an entry for the key in the specified accelerator table) and then sends the <c>WM_COMMAND</c>
	/// or <c>WM_SYSCOMMAND</c> message directly to the specified window procedure. <c>TranslateAccelerator</c> does not return until the
	/// window procedure has processed the message.
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window whose messages are to be translated.</para>
	/// </param>
	/// <param name="hAccTable">
	/// <para>Type: <c>HACCEL</c></para>
	/// <para>
	/// A handle to the accelerator table. The accelerator table must have been loaded by a call to the LoadAccelerators function or
	/// created by a call to the CreateAcceleratorTable function.
	/// </para>
	/// </param>
	/// <param name="lpMsg">
	/// <para>Type: <c>LPMSG</c></para>
	/// <para>
	/// A pointer to an MSG structure that contains message information retrieved from the calling thread's message queue using the
	/// GetMessage or PeekMessage function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To differentiate the message that this function sends from messages sent by menus or controls, the high-order word of the wParam
	/// parameter of the WM_COMMAND or WM_SYSCOMMAND message contains the value 1.
	/// </para>
	/// <para>
	/// Accelerator key combinations used to select items from the <c>window</c> menu are translated into WM_SYSCOMMAND messages; all
	/// other accelerator key combinations are translated into WM_COMMAND messages.
	/// </para>
	/// <para>
	/// When <c>TranslateAccelerator</c> returns a nonzero value and the message is translated, the application should not use the
	/// TranslateMessage function to process the message again.
	/// </para>
	/// <para>An accelerator need not correspond to a menu command.</para>
	/// <para>
	/// If the accelerator command corresponds to a menu item, the application is sent WM_INITMENU and WM_INITMENUPOPUP messages, as if
	/// the user were trying to display the menu. However, these messages are not sent if any of the following conditions exist:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The window is disabled.</term>
	/// </item>
	/// <item>
	/// <term>The accelerator key combination does not correspond to an item on the <c>window</c> menu and the window is minimized.</term>
	/// </item>
	/// <item>
	/// <term>A mouse capture is in effect. For information about mouse capture, see the SetCapture function.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the specified window is the active window and no window has the keyboard focus (which is generally the case if the window is
	/// minimized), <c>TranslateAccelerator</c> translates WM_SYSKEYUP and WM_SYSKEYDOWN messages instead of WM_KEYUP and WM_KEYDOWN messages.
	/// </para>
	/// <para>
	/// If an accelerator keystroke occurs that corresponds to a menu item when the window that owns the menu is minimized,
	/// <c>TranslateAccelerator</c> does not send a WM_COMMAND message. However, if an accelerator keystroke occurs that does not match
	/// any of the items in the window's menu or in the <c>window</c> menu, the function sends a <c>WM_COMMAND</c> message, even if the
	/// window is minimized.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating Accelerators for Font Attributes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-translateacceleratora int TranslateAcceleratorA( HWND
	// hWnd, HACCEL hAccTable, LPMSG lpMsg );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h")]
	public static extern int TranslateAccelerator(HWND hWnd, HACCEL hAccTable, in MSG lpMsg);

	/// <summary>
	/// <para>Defines an accelerator key used in an accelerator table.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagaccel typedef struct tagACCEL { #if ... BYTE fVirt;
	// WORD key; #if ... WORD cmd; #else WORD fVirt; #endif #else DWORD cmd; #endif } ACCEL, *LPACCEL;
	[PInvokeData("winuser.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ACCEL
	{
		/// <summary>The accelerator behavior. This member can be one or more of the following values.</summary>
		public FVIRT fVirt;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>The accelerator key. This member can be either a virtual-key code or a character code.</para>
		/// </summary>
		public ushort key;

		/// <summary>
		/// The accelerator identifier. This value is placed in the low-order word of the wParam parameter of the WM_COMMAND or
		/// WM_SYSCOMMAND message when the accelerator is pressed.
		/// </summary>
		public ushort cmd;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HACCEL"/> that is disposed using <see cref="DestroyAcceleratorTable"/>.</summary>
	public class SafeHACCEL : SafeHANDLE, IUserHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHACCEL"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHACCEL(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHACCEL"/> class.</summary>
		private SafeHACCEL() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHACCEL"/> to <see cref="HACCEL"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HACCEL(SafeHACCEL h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => DestroyAcceleratorTable(this);
	}
}