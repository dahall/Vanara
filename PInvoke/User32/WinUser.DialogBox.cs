using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>
	/// Application-defined callback function used with the <c>CreateDialog</c> and <c>DialogBox</c> families of functions. It processes
	/// messages sent to a modal or modeless dialog box. The <c>DLGPROC</c> type defines a pointer to this callback function. DialogProc is a
	/// placeholder for the application-defined function name.
	/// </summary>
	/// <param name="hwndDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box.</para>
	/// </param>
	/// <param name="uMsg">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The message.</para>
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
	/// <para>Type: <c>INT_PTR</c></para>
	/// <para>
	/// Typically, the dialog box procedure should return <c>TRUE</c> if it processed the message, and <c>FALSE</c> if it did not. If the
	/// dialog box procedure returns <c>FALSE</c>, the dialog manager performs the default dialog operation in response to the message.
	/// </para>
	/// <para>
	/// If the dialog box procedure processes a message that requires a specific return value, the dialog box procedure should set the
	/// desired return value by calling <c>SetWindowLong</c>(hwndDlg, <c>DWL_MSGRESULT</c>, lResult) immediately before returning
	/// <c>TRUE</c>. Note that you must call <c>SetWindowLong</c> immediately before returning <c>TRUE</c>; doing so earlier may result in
	/// the <c>DWL_MSGRESULT</c> value being overwritten by a nested dialog box message.
	/// </para>
	/// <para>
	/// The following messages are exceptions to the general rules stated above. Consult the documentation for the specific message for
	/// details on the semantics of the return value.
	/// </para>
	/// </returns>
	// INT_PTR CALLBACK DialogProc( _In_ HWND hwndDlg, _In_ UINT uMsg, _In_ WPARAM wParam, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/ms645469(v=vs.85).aspx
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("Winuser.h", MSDNShortId = "ms645469")]
	public delegate IntPtr DialogProc([In] HWND hwndDlg, [In] uint uMsg, [In] IntPtr wParam, [In] IntPtr lParam);

	/// <summary>Flags used by DlgDirList functions.</summary>
	[PInvokeData("Winuser.h")]
	[Flags]
	public enum DDL : uint
	{
		/// <summary>Includes read/write files with no additional attributes. This is the default setting.</summary>
		DDL_READWRITE = 0x0000,

		/// <summary>Includes read-only files.</summary>
		DDL_READONLY = 0x0001,

		/// <summary>Includes hidden files.</summary>
		DDL_HIDDEN = 0x0002,

		/// <summary>Includes system files.</summary>
		DDL_SYSTEM = 0x0004,

		/// <summary>Includes subdirectories, which are enclosed in square brackets ([ ]).</summary>
		DDL_DIRECTORY = 0x0010,

		/// <summary>Includes archived files.</summary>
		DDL_ARCHIVE = 0x0020,

		/// <summary>
		/// If this flag is set, DlgDirListComboBox uses the PostMessage function to send messages to the combo box. If this flag is not set,
		/// DlgDirListComboBox uses the SendMessage function.
		/// </summary>
		DDL_POSTMSGS = 0x2000,

		/// <summary>All mapped drives are added to the list. Drives are listed in the form [-x-], where x is the drive letter.</summary>
		DDL_DRIVES = 0x4000,

		/// <summary>
		/// Includes only files with the specified attributes. By default, read/write files are listed even if DDL_READWRITE is not specified.
		/// </summary>
		DDL_EXCLUSIVE = 0x8000,
	}

	/// <summary>
	/// The following table lists the dialog box styles that you can specify when you create a dialog box. You can use these styles in calls
	/// to the CreateWindow and CreateWindowEx functions, in the style member of the DLGTEMPLATE and DLGTEMPLATEEX structures, and in the
	/// statement of a dialog box definition in a resource file.
	/// </summary>
	[Flags]
	public enum DialogBoxStyles : uint
	{
		/// <summary>
		/// Indicates that the coordinates of the dialog box are screen coordinates. If this style is not specified, the coordinates are
		/// client coordinates.
		/// </summary>
		DS_ABSALIGN = 0x01,

		/// <summary>
		/// This style is obsolete and is included for compatibility with 16-bit versions of Windows. If you specify this style, the system
		/// creates the dialog box with the WS_EX_TOPMOST style. This style does not prevent the user from accessing other windows on the
		/// desktop. Do not combine this style with the DS_CONTROL style.
		/// </summary>
		DS_SYSMODAL = 0x02,

		/// <summary>
		/// Applies to 16-bit applications only. This style directs edit controls in the dialog box to allocate memory from the application's
		/// data segment. Otherwise, edit controls allocate storage from a global memory object.
		/// </summary>
		DS_LOCALEDIT = 0x20,

		/// <summary>
		/// Indicates that the header of the dialog box template (either standard or extended) contains additional data specifying the font
		/// to use for text in the client area and controls of the dialog box. If possible, the system selects a font according to the
		/// specified font data. The system passes a handle to the font to the dialog box and to each control by sending them the WM_SETFONT
		/// message. For descriptions of the format of this font data, see DLGTEMPLATE and DLGTEMPLATEEX. If neither DS_SETFONT nor
		/// DS_SHELLFONT is specified, the dialog box template does not include the font data.
		/// </summary>
		DS_SETFONT = 0x40,

		/// <summary>
		/// Creates a dialog box with a modal dialog-box frame that can be combined with a title bar and window menu by specifying the
		/// WS_CAPTION and WS_SYSMENU styles.
		/// </summary>
		DS_MODALFRAME = 0x80,

		/// <summary>
		/// Suppresses WM_ENTERIDLE messages that the system would otherwise send to the owner of the dialog box while the dialog box is displayed.
		/// </summary>
		DS_NOIDLEMSG = 0x100,

		/// <summary>
		/// Causes the system to use the SetForegroundWindow function to bring the dialog box to the foreground. This style is useful for
		/// modal dialog boxes that require immediate attention from the user regardless of whether the owner window is the foreground
		/// window. The system restricts which processes can set the foreground window. For more information, see Foreground and Background Windows.
		/// </summary>
		DS_SETFOREGROUND = 0x200,

		/// <summary>Obsolete. The system automatically applies the three-dimensional look to dialog boxes created by applications.</summary>
		DS_3DLOOK = 0x0004,

		/// <summary>
		/// Causes the dialog box to use the SYSTEM_FIXED_FONT instead of the default SYSTEM_FONT. This is a monospace font compatible with
		/// the System font in 16-bit versions of Windows earlier than 3.0.
		/// </summary>
		DS_FIXEDSYS = 0x0008,

		/// <summary>
		/// Creates the dialog box even if errors occur for example, if a child window cannot be created or if the system cannot create a
		/// special data segment for an edit control.
		/// </summary>
		DS_NOFAILCREATE = 0x0010,

		/// <summary>
		/// Creates a dialog box that works well as a child window of another dialog box, much like a page in a property sheet. This style
		/// allows the user to tab among the control windows of a child dialog box, use its accelerator keys, and so on.
		/// </summary>
		DS_CONTROL = 0x0400,

		/// <summary>
		/// Centers the dialog box in the working area of the monitor that contains the owner window. If no owner window is specified, the
		/// dialog box is centered in the working area of a monitor determined by the system. The working area is the area not obscured by
		/// the taskbar or any appbars.
		/// </summary>
		DS_CENTER = 0x0800,

		/// <summary>Centers the dialog box on the mouse cursor.</summary>
		DS_CENTERMOUSE = 0x1000,

		/// <summary>
		/// Includes a question mark in the title bar of the dialog box. When the user clicks the question mark, the cursor changes to a
		/// question mark with a pointer. If the user then clicks a control in the dialog box, the control receives a WM_HELP message. The
		/// control should pass the message to the dialog box procedure, which should call the function using the HELP_WM_HELP command. The
		/// help application displays a pop-up window that typically contains help for the control. Note that DS_CONTEXTHELP is only a
		/// placeholder. When the dialog box is created, the system checks for DS_CONTEXTHELP and, if it is there, adds WS_EX_CONTEXTHELP to
		/// the extended style of the dialog box. WS_EX_CONTEXTHELP cannot be used with the WS_MAXIMIZEBOX or WS_MINIMIZEBOX styles.
		/// </summary>
		DS_CONTEXTHELP = 0x2000,

		/// <summary>
		/// Indicates that the dialog box should use the system font. The typeface member of the extended dialog box template must be set to
		/// MS Shell Dlg. Otherwise, this style has no effect. It is also recommended that you use the DIALOGEX Resource, rather than the
		/// DIALOG Resource. For more information, see Dialog Box Fonts. The system selects a font using the font data specified in the
		/// pointsize, weight, and italic members. The system passes a handle to the font to the dialog box and to each control by sending
		/// them the WM_SETFONT message. For descriptions of the format of this font data, see DLGTEMPLATEEX. If neither DS_SHELLFONT nor
		/// DS_SETFONT is specified, the extended dialog box template does not include the font data.
		/// </summary>
		DS_SHELLFONT = DS_SETFONT | DS_FIXEDSYS,

		/// <summary/>
		DS_USEPIXELS = 0x8000,
	}

	/// <summary>The return value for WM_GETDLGCODE, indicating which type of input the application processes.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum DLGC : int
	{
		/// <summary>Direction keys.</summary>
		DLGC_WANTARROWS = 0x0001,

		/// <summary>TAB key.</summary>
		DLGC_WANTTAB = 0x0002,

		/// <summary>All keyboard input.</summary>
		DLGC_WANTALLKEYS = 0x0004,

		/// <summary>All keyboard input (the application passes this message in the MSG structure to the control).</summary>
		DLGC_WANTMESSAGE = 0x0004,

		/// <summary>EM_SETSEL messages.</summary>
		DLGC_HASSETSEL = 0x0008,

		/// <summary>Default push button.</summary>
		DLGC_DEFPUSHBUTTON = 0x0010,

		/// <summary>Non-default push button.</summary>
		DLGC_UNDEFPUSHBUTTON = 0x0020,

		/// <summary>Radio button.</summary>
		DLGC_RADIOBUTTON = 0x0040,

		/// <summary>WM_CHAR messages.</summary>
		DLGC_WANTCHARS = 0x0080,

		/// <summary>Static control.</summary>
		DLGC_STATIC = 0x0100,

		/// <summary>Button.</summary>
		DLGC_BUTTON = 0x2000,
	}

	/// <summary>
	/// <para>
	/// Creates a modeless dialog box from a dialog box template resource. The <c>CreateDialog</c> macro uses the CreateDialogParam function.
	/// </para>
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the module which contains the dialog box template. If this parameter is NULL, then the current executable is used.</para>
	/// </param>
	/// <param name="lpName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The dialog box template. This parameter is either the pointer to a null-terminated character string that specifies the name of the
	/// dialog box template or an integer value that specifies the resource identifier of the dialog box template. If the parameter specifies
	/// a resource identifier, its high-order word must be zero and its low-order word must contain the identifier. You can use the
	/// MAKEINTRESOURCE macro to create this value.
	/// </para>
	/// </param>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that owns the dialog box.</para>
	/// </param>
	/// <param name="lpDialogFunc">
	/// <para>Type: <c>DLGPROC</c></para>
	/// <para>A pointer to the dialog box procedure. For more information about the dialog box procedure, see DialogProc.</para>
	/// </param>
	/// <returns>
	/// <para>None</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CreateDialog</c> function uses the CreateWindowEx function to create the dialog box. <c>CreateDialog</c> then sends a
	/// WM_INITDIALOG message (and a WM_SETFONT message if the template specifies the DS_SETFONT or <c>DS_SHELLFONT</c> style) to the dialog
	/// box procedure. The function displays the dialog box if the template specifies the <c>WS_VISIBLE</c> style. Finally,
	/// <c>CreateDialog</c> returns the window handle to the dialog box.
	/// </para>
	/// <para>
	/// After <c>CreateDialog</c> returns, the application displays the dialog box (if it is not already displayed) by using the ShowWindow
	/// function. The application destroys the dialog box by using the DestroyWindow function. To support keyboard navigation and other
	/// dialog box functionality, the message loop for the dialog box must call the IsDialogMessage function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Modeless Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createdialoga void CreateDialogA( hInstance, lpName,
	// hWndParent, lpDialogFunc );
	[PInvokeData("winuser.h", MSDNShortId = "createdialog")]
	[return: AddAsCtor]
	public static SafeHWND CreateDialog([In, Optional, AddAsMember] HINSTANCE hInstance, SafeResourceId lpName, HWND hWndParent, DialogProc lpDialogFunc) => CreateDialogParam(hInstance, lpName, hWndParent, lpDialogFunc);

	/// <summary>
	/// <para>
	/// Creates a modeless dialog box from a dialog box template in memory. The <c>CreateDialogIndirect</c> macro uses the
	/// CreateDialogIndirectParam function.
	/// </para>
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the module that creates the dialog box.</para>
	/// </param>
	/// <param name="lpTemplate">
	/// <para>Type: <c>LPCDLGTEMPLATE</c></para>
	/// <para>
	/// A template that <c>CreateDialogIndirect</c> uses to create the dialog box. A dialog box template consists of a header that describes
	/// the dialog box, followed by one or more additional blocks of data that describe each of the controls in the dialog box. The template
	/// can use either the standard format or the extended format.
	/// </para>
	/// <para>
	/// In a standard template, the header is a DLGTEMPLATE structure followed by additional variable-length arrays. The data for each
	/// control consists of a DLGITEMTEMPLATE structure followed by additional variable-length arrays.
	/// </para>
	/// <para>
	/// In an extended dialog box template, the header uses the DLGTEMPLATEEX format and the control definitions use the DLGITEMTEMPLATEEX format.
	/// </para>
	/// <para>After <c>CreateDialogIndirect</c> returns, you can free the template, which is only used to get the dialog box started.</para>
	/// </param>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that owns the dialog box.</para>
	/// </param>
	/// <param name="lpDialogFunc">
	/// <para>Type: <c>DLGPROC</c></para>
	/// <para>A pointer to the dialog box procedure. For more information about the dialog box procedure, see DialogProc.</para>
	/// </param>
	/// <returns>
	/// <para>None</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CreateDialogIndirect</c> macro uses the CreateWindowEx function to create the dialog box. <c>CreateDialogIndirect</c> then
	/// sends a WM_INITDIALOG message to the dialog box procedure. If the template specifies the DS_SETFONT or DS_SHELLFONT style, the
	/// function also sends a WM_SETFONT message to the dialog box procedure. The function displays the dialog box if the template specifies
	/// the WS_VISIBLE style. Finally, <c>CreateDialogIndirect</c> returns the window handle to the dialog box.
	/// </para>
	/// <para>
	/// After <c>CreateDialogIndirect</c> returns, you can use the ShowWindow function to display the dialog box (if it is not already
	/// visible). To destroy the dialog box, use the DestroyWindow function. To support keyboard navigation and other dialog box
	/// functionality, the message loop for the dialog box must call the IsDialogMessage function.
	/// </para>
	/// <para>
	/// In a standard dialog box template, the DLGTEMPLATE structure and each of the DLGITEMTEMPLATE structures must be aligned on
	/// <c>DWORD</c> boundaries. The creation data array that follows a <c>DLGITEMTEMPLATE</c> structure must also be aligned on a
	/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
	/// </para>
	/// <para>
	/// In an extended dialog box template, the DLGTEMPLATEEX header and each of the DLGITEMTEMPLATEEX control definitions must be aligned on
	/// <c>DWORD</c> boundaries. The creation data array, if any, that follows a <c>DLGITEMTEMPLATEEX</c> structure must also be aligned on a
	/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
	/// </para>
	/// <para>
	/// All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings. Use the
	/// MultiByteToWideChar function to generate Unicode strings from ANSI strings.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createdialogindirecta void CreateDialogIndirectA( hInstance,
	// lpTemplate, hWndParent, lpDialogFunc );
	[PInvokeData("winuser.h", MSDNShortId = "createdialogindirect")]
	[return: AddAsCtor]
	public static SafeHWND CreateDialogIndirect([In, Optional] HINSTANCE hInstance, StructPointer<DLGTEMPLATE> lpTemplate, HWND hWndParent, DialogProc lpDialogFunc) => CreateDialogIndirectParam(hInstance, lpTemplate, hWndParent, lpDialogFunc);

	/// <summary>
	/// <para>
	/// Creates a modeless dialog box from a dialog box template in memory. Before displaying the dialog box, the function passes an
	/// application-defined value to the dialog box procedure as the lParam parameter of the WM_INITDIALOG message. An application can use
	/// this value to initialize dialog box controls.
	/// </para>
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the module which contains the dialog box template. If this parameter is NULL, then the current executable is used.</para>
	/// </param>
	/// <param name="lpTemplate">
	/// <para>Type: <c>LPCDLGTEMPLATE</c></para>
	/// <para>
	/// The template <c>CreateDialogIndirectParam</c> uses to create the dialog box. A dialog box template consists of a header that
	/// describes the dialog box, followed by one or more additional blocks of data that describe each of the controls in the dialog box. The
	/// template can use either the standard format or the extended format.
	/// </para>
	/// <para>
	/// In a standard template, the header is a DLGTEMPLATE structure followed by additional variable-length arrays. The data for each
	/// control consists of a DLGITEMTEMPLATE structure followed by additional variable-length arrays.
	/// </para>
	/// <para>
	/// In an extended dialog box template, the header uses the DLGTEMPLATEEX format and the control definitions use the DLGITEMTEMPLATEEX format.
	/// </para>
	/// <para>After <c>CreateDialogIndirectParam</c> returns, you can free the template, which is only used to get the dialog box started.</para>
	/// </param>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that owns the dialog box.</para>
	/// </param>
	/// <param name="lpDialogFunc">
	/// <para>Type: <c>DLGPROC</c></para>
	/// <para>A pointer to the dialog box procedure. For more information about the dialog box procedure, see DialogProc.</para>
	/// </param>
	/// <param name="dwInitParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>The value to pass to the dialog box in the lParam parameter of the WM_INITDIALOG message.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>If the function succeeds, the return value is the window handle to the dialog box.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CreateDialogIndirectParam</c> function uses the CreateWindowEx function to create the dialog box.
	/// <c>CreateDialogIndirectParam</c> then sends a WM_INITDIALOG message to the dialog box procedure. If the template specifies the
	/// DS_SETFONT or DS_SHELLFONT style, the function also sends a WM_SETFONT message to the dialog box procedure. The function displays the
	/// dialog box if the template specifies the <c>WS_VISIBLE</c> style. Finally, <c>CreateDialogIndirectParam</c> returns the window handle
	/// to the dialog box.
	/// </para>
	/// <para>
	/// After <c>CreateDialogIndirectParam</c> returns, you can use the ShowWindow function to display the dialog box (if it is not already
	/// visible). To destroy the dialog box, use the DestroyWindow function. To support keyboard navigation and other dialog box
	/// functionality, the message loop for the dialog box must call the IsDialogMessage function.
	/// </para>
	/// <para>
	/// In a standard dialog box template, the DLGTEMPLATE structure and each of the DLGITEMTEMPLATE structures must be aligned on
	/// <c>DWORD</c> boundaries. The creation data array that follows a <c>DLGITEMTEMPLATE</c> structure must also be aligned on a
	/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
	/// </para>
	/// <para>
	/// In an extended dialog box template, the DLGTEMPLATEEX header and each of the DLGITEMTEMPLATEEX control definitions must be aligned on
	/// <c>DWORD</c> boundaries. The creation data array, if any, that follows a <c>DLGITEMTEMPLATEEX</c> structure must also be aligned on a
	/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
	/// </para>
	/// <para>All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createdialogindirectparama HWND CreateDialogIndirectParamA(
	// HINSTANCE hInstance, LPCDLGTEMPLATEA lpTemplate, HWND hWndParent, DLGPROC lpDialogFunc, LPARAM dwInitParam );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "createdialogindirectparam")]
	public static extern SafeHWND CreateDialogIndirectParam([Optional] HINSTANCE hInstance, StructPointer<DLGTEMPLATE> lpTemplate, HWND hWndParent, DialogProc lpDialogFunc, [Optional] IntPtr dwInitParam);

	/// <summary>
	/// <para>
	/// Creates a modeless dialog box from a dialog box template resource. Before displaying the dialog box, the function passes an
	/// application-defined value to the dialog box procedure as the lParam parameter of the WM_INITDIALOG message. An application can use
	/// this value to initialize dialog box controls.
	/// </para>
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the module which contains the dialog box template. If this parameter is NULL, then the current executable is used.</para>
	/// </param>
	/// <param name="lpTemplateName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The dialog box template. This parameter is either the pointer to a null-terminated character string that specifies the name of the
	/// dialog box template or an integer value that specifies the resource identifier of the dialog box template. If the parameter specifies
	/// a resource identifier, its high-order word must be zero and low-order word must contain the identifier. You can use the
	/// MAKEINTRESOURCE macro to create this value.
	/// </para>
	/// </param>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that owns the dialog box.</para>
	/// </param>
	/// <param name="lpDialogFunc">
	/// <para>Type: <c>DLGPROC</c></para>
	/// <para>A pointer to the dialog box procedure. For more information about the dialog box procedure, see DialogProc.</para>
	/// </param>
	/// <param name="dwInitParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>The value to be passed to the dialog box procedure in the lParam parameter in the WM_INITDIALOG message.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>If the function succeeds, the return value is the window handle to the dialog box.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CreateDialogParam</c> function uses the CreateWindowEx function to create the dialog box. <c>CreateDialogParam</c> then sends
	/// a WM_INITDIALOG message (and a WM_SETFONT message if the template specifies the DS_SETFONT or DS_SHELLFONT style) to the dialog box
	/// procedure. The function displays the dialog box if the template specifies the <c>WS_VISIBLE</c> style. Finally,
	/// <c>CreateDialogParam</c> returns the window handle of the dialog box.
	/// </para>
	/// <para>
	/// After <c>CreateDialogParam</c> returns, the application displays the dialog box (if it is not already displayed) using the ShowWindow
	/// function. The application destroys the dialog box by using the DestroyWindow function. To support keyboard navigation and other
	/// dialog box functionality, the message loop for the dialog box must call the IsDialogMessage function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createdialogparama HWND CreateDialogParamA( HINSTANCE
	// hInstance, LPCSTR lpTemplateName, HWND hWndParent, DLGPROC lpDialogFunc, LPARAM dwInitParam );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "createdialogparam")]
	public static extern SafeHWND CreateDialogParam([Optional] HINSTANCE hInstance, SafeResourceId lpTemplateName, HWND hWndParent, DialogProc lpDialogFunc, [Optional] IntPtr dwInitParam);

	/// <summary>
	/// <para>
	/// Calls the default dialog box window procedure to provide default processing for any window messages that a dialog box with a private
	/// window class does not process.
	/// </para>
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box.</para>
	/// </param>
	/// <param name="Msg">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The message.</para>
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
	/// <para>Type: <c>LRESULT</c></para>
	/// <para>The return value specifies the result of the message processing and depends on the message sent.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DefDlgProc</c> function is the window procedure for the predefined class of dialog box. This procedure provides internal
	/// processing for the dialog box by forwarding messages to the dialog box procedure and carrying out default processing for any messages
	/// that the dialog box procedure returns as <c>FALSE</c>. Applications that create custom window procedures for their custom dialog
	/// boxes often use <c>DefDlgProc</c> instead of the DefWindowProc function to carry out default message processing.
	/// </para>
	/// <para>
	/// Applications create custom dialog box classes by filling a WNDCLASS structure with appropriate information and registering the class
	/// with the RegisterClass function. Some applications fill the structure by using the GetClassInfo function, specifying the name of the
	/// predefined dialog box. In such cases, the applications modify at least the <c>lpszClassName</c> member before registering. In all
	/// cases, the <c>cbWndExtra</c> member of <c>WNDCLASS</c> for a custom dialog box class must be set to at least <c>DLGWINDOWEXTRA</c>.
	/// </para>
	/// <para>The <c>DefDlgProc</c> function must not be called by a dialog box procedure; doing so results in recursive execution.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-defdlgprocw LRESULT LRESULT DefDlgProcW( HWND hDlg, UINT Msg,
	// WPARAM wParam, LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "defdlgproc")]
	public static extern IntPtr DefDlgProc(HWND hDlg, uint Msg, IntPtr wParam, IntPtr lParam);

	/// <summary>
	/// <para>
	/// Creates a modal dialog box from a dialog box template resource. <c>DialogBox</c> does not return control until the specified callback
	/// function terminates the modal dialog box by calling the EndDialog function.
	/// </para>
	/// <para><c>DialogBox</c> is implemented as a call to the DialogBoxParam function.</para>
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the module which contains the dialog box template. If this parameter is NULL, then the current executable is used.</para>
	/// </param>
	/// <param name="lpTemplate">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The dialog box template. This parameter is either the pointer to a null-terminated character string that specifies the name of the
	/// dialog box template or an integer value that specifies the resource identifier of the dialog box template. If the parameter specifies
	/// a resource identifier, its high-order word must be zero and its low-order word must contain the identifier. You can use the
	/// MAKEINTRESOURCE macro to create this value.
	/// </para>
	/// </param>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that owns the dialog box.</para>
	/// </param>
	/// <param name="lpDialogFunc">
	/// <para>Type: <c>DLGPROC</c></para>
	/// <para>A pointer to the dialog box procedure. For more information about the dialog box procedure, see DialogProc.</para>
	/// </param>
	/// <returns>
	/// <para>None</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DialogBox</c> macro uses the CreateWindowEx function to create the dialog box. <c>DialogBox</c> then sends a WM_INITDIALOG
	/// message (and a WM_SETFONT message if the template specifies the DS_SETFONT or DS_SHELLFONT style) to the dialog box procedure. The
	/// function displays the dialog box (regardless of whether the template specifies the <c>WS_VISIBLE</c> style), disables the owner
	/// window, and starts its own message loop to retrieve and dispatch messages for the dialog box.
	/// </para>
	/// <para>
	/// When the dialog box procedure calls the EndDialog function, <c>DialogBox</c> destroys the dialog box, ends the message loop, enables
	/// the owner window (if previously enabled), and returns the nResult parameter specified by the dialog box procedure when it called <c>EndDialog</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Modal Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-dialogboxa void DialogBoxA( hInstance, lpTemplate, hWndParent,
	// lpDialogFunc );
	[PInvokeData("winuser.h", MSDNShortId = "dialogbox")]
	public static IntPtr DialogBox([In, Optional] HINSTANCE hInstance, SafeResourceId lpTemplate, [In, Optional] HWND hWndParent, [In, Optional] DialogProc? lpDialogFunc) =>
		DialogBoxParam(hInstance, lpTemplate, hWndParent, lpDialogFunc);

	/// <summary>
	/// <para>
	/// Creates a modal dialog box from a dialog box template in memory. <c>DialogBoxIndirect</c> does not return control until the specified
	/// callback function terminates the modal dialog box by calling the EndDialog function.
	/// </para>
	/// <para><c>DialogBoxIndirect</c> is implemented as a call to the DialogBoxIndirectParam function.</para>
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the module that creates the dialog box.</para>
	/// </param>
	/// <param name="lpTemplate">
	/// <para>Type: <c>LPCDLGTEMPLATE</c></para>
	/// <para>
	/// The template that <c>DialogBoxIndirect</c> uses to create the dialog box. A dialog box template consists of a header that describes
	/// the dialog box, followed by one or more additional blocks of data that describe each of the controls in the dialog box. The template
	/// can use either the standard format or the extended format.
	/// </para>
	/// <para>
	/// In a standard template for a dialog box, the header is a DLGTEMPLATE structure followed by additional variable-length arrays. The
	/// data for each control consists of a DLGITEMTEMPLATE structure followed by additional variable-length arrays.
	/// </para>
	/// <para>
	/// In an extended template for a dialog box, the header uses the DLGTEMPLATEEX format and the control definitions use the
	/// DLGITEMTEMPLATEEX format.
	/// </para>
	/// </param>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that owns the dialog box.</para>
	/// </param>
	/// <param name="lpDialogFunc">
	/// <para>Type: <c>DLGPROC</c></para>
	/// <para>A pointer to the dialog box procedure. For more information about the dialog box procedure, see DialogProc.</para>
	/// </param>
	/// <returns>
	/// <para>None</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DialogBoxIndirect</c> macro uses the CreateWindowEx function to create the dialog box. <c>DialogBoxIndirect</c> then sends a
	/// WM_INITDIALOG message to the dialog box procedure. If the template specifies the DS_SETFONT or DS_SHELLFONT style, the function also
	/// sends a WM_SETFONT message to the dialog box procedure. The function displays the dialog box (regardless of whether the template
	/// specifies the <c>WS_VISIBLE</c> style), disables the owner window, and starts its own message loop to retrieve and dispatch messages
	/// for the dialog box.
	/// </para>
	/// <para>
	/// When the dialog box procedure calls the EndDialog function, <c>DialogBoxIndirect</c> destroys the dialog box, ends the message loop,
	/// enables the owner window (if previously enabled), and returns the nResult parameter specified by the dialog box procedure when it
	/// called <c>EndDialog</c>.
	/// </para>
	/// <para>
	/// In a standard dialog box template, the DLGTEMPLATE structure and each of the DLGITEMTEMPLATE structures must be aligned on
	/// <c>DWORD</c> boundaries. The creation data array that follows a <c>DLGITEMTEMPLATE</c> structure must also be aligned on a
	/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
	/// </para>
	/// <para>
	/// In an extended dialog box template, the DLGTEMPLATEEX header and each of the DLGITEMTEMPLATEEX control definitions must be aligned on
	/// <c>DWORD</c> boundaries. The creation data array, if any, that follows a <c>DLGITEMTEMPLATEEX</c> structure must also be aligned on a
	/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
	/// </para>
	/// <para>
	/// All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings. Use the
	/// MultiByteToWideChar function to generate Unicode strings from ANSI strings.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Template in Memory.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-dialogboxindirecta void DialogBoxIndirectA( hInstance,
	// lpTemplate, hWndParent, lpDialogFunc );
	[PInvokeData("winuser.h", MSDNShortId = "dialogboxindirect")]
	public static IntPtr DialogBoxIndirect([In, Optional] HINSTANCE hInstance, StructPointer<DLGTEMPLATE> lpTemplate, [In, Optional] HWND hWndParent, [In, Optional] DialogProc? lpDialogFunc) =>
		DialogBoxIndirectParam(hInstance, lpTemplate, hWndParent, lpDialogFunc);

	/// <summary>
	/// <para>
	/// Creates a modal dialog box from a dialog box template in memory. Before displaying the dialog box, the function passes an
	/// application-defined value to the dialog box procedure as the lParam parameter of the WM_INITDIALOG message. An application can use
	/// this value to initialize dialog box controls.
	/// </para>
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the module that creates the dialog box.</para>
	/// </param>
	/// <param name="hDialogTemplate">
	/// <para>Type: <c>LPCDLGTEMPLATE</c></para>
	/// <para>
	/// The template that <c>DialogBoxIndirectParam</c> uses to create the dialog box. A dialog box template consists of a header that
	/// describes the dialog box, followed by one or more additional blocks of data that describe each of the controls in the dialog box. The
	/// template can use either the standard format or the extended format.
	/// </para>
	/// <para>
	/// In a standard template for a dialog box, the header is a DLGTEMPLATE structure followed by additional variable-length arrays. The
	/// data for each control consists of a DLGITEMTEMPLATE structure followed by additional variable-length arrays.
	/// </para>
	/// <para>
	/// In an extended template for a dialog box, the header uses the DLGTEMPLATEEX format and the control definitions use the
	/// DLGITEMTEMPLATEEX format.
	/// </para>
	/// </param>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that owns the dialog box.</para>
	/// </param>
	/// <param name="lpDialogFunc">
	/// <para>Type: <c>DLGPROC</c></para>
	/// <para>A pointer to the dialog box procedure. For more information about the dialog box procedure, see DialogProc.</para>
	/// </param>
	/// <param name="dwInitParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>The value to pass to the dialog box in the lParam parameter of the WM_INITDIALOG message.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>INT_PTR</c></para>
	/// <para>
	/// If the function succeeds, the return value is the nResult parameter specified in the call to the EndDialog function that was used to
	/// terminate the dialog box.
	/// </para>
	/// <para>
	/// If the function fails because the hWndParent parameter is invalid, the return value is zero. The function returns zero in this case
	/// for compatibility with previous versions of Windows. If the function fails for any other reason, the return value is –1. To get
	/// extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DialogBoxIndirectParam</c> function uses the CreateWindowEx function to create the dialog box. <c>DialogBoxIndirectParam</c>
	/// then sends a WM_INITDIALOG message to the dialog box procedure. If the template specifies the DS_SETFONT or DS_SHELLFONT style, the
	/// function also sends a WM_SETFONT message to the dialog box procedure. The function displays the dialog box (regardless of whether the
	/// template specifies the <c>WS_VISIBLE</c> style), disables the owner window, and starts its own message loop to retrieve and dispatch
	/// messages for the dialog box.
	/// </para>
	/// <para>
	/// When the dialog box procedure calls the EndDialog function, <c>DialogBoxIndirectParam</c> destroys the dialog box, ends the message
	/// loop, enables the owner window (if previously enabled), and returns the nResult parameter specified by the dialog box procedure when
	/// it called <c>EndDialog</c>.
	/// </para>
	/// <para>
	/// In a standard dialog box template, the DLGTEMPLATE structure and each of the DLGITEMTEMPLATE structures must be aligned on
	/// <c>DWORD</c> boundaries. The creation data array that follows a <c>DLGITEMTEMPLATE</c> structure must also be aligned on a
	/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
	/// </para>
	/// <para>
	/// In an extended dialog box template, the DLGTEMPLATEEX header and each of the DLGITEMTEMPLATEEX control definitions must be aligned on
	/// <c>DWORD</c> boundaries. The creation data array, if any, that follows a <c>DLGITEMTEMPLATEEX</c> structure must also be aligned on a
	/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
	/// </para>
	/// <para>All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-dialogboxindirectparama INT_PTR DialogBoxIndirectParamA(
	// HINSTANCE hInstance, LPCDLGTEMPLATEA hDialogTemplate, HWND hWndParent, DLGPROC lpDialogFunc, LPARAM dwInitParam );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "dialogboxindirectparam")]
	public static extern IntPtr DialogBoxIndirectParam([In, Optional] HINSTANCE hInstance, StructPointer<DLGTEMPLATE> hDialogTemplate, [In, Optional] HWND hWndParent,
		[In, Optional] DialogProc? lpDialogFunc, [In, Optional] IntPtr dwInitParam);

	/// <summary>
	/// Creates a modal dialog box from a dialog box template in memory. Before displaying the dialog box, the function passes an
	/// application-defined value to the dialog box procedure as the <c>lParam</c> parameter of the WM_INITDIALOG message. An application can
	/// use this value to initialize dialog box controls.
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the module that creates the dialog box.</para>
	/// </param>
	/// <param name="hDialogTemplate">
	/// <para>Type: <c>LPCDLGTEMPLATE</c></para>
	/// <para>
	/// The template that <c>DialogBoxIndirectParam</c> uses to create the dialog box. A dialog box template consists of a header that
	/// describes the dialog box, followed by one or more additional blocks of data that describe each of the controls in the dialog box. The
	/// template can use either the standard format or the extended format.
	/// </para>
	/// <para>
	/// In a standard template for a dialog box, the header is a DLGTEMPLATE structure followed by additional variable-length arrays. The
	/// data for each control consists of a DLGITEMTEMPLATE structure followed by additional variable-length arrays.
	/// </para>
	/// <para>
	/// In an extended template for a dialog box, the header uses the DLGTEMPLATEEX format and the control definitions use the
	/// DLGITEMTEMPLATEEX format.
	/// </para>
	/// </param>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that owns the dialog box.</para>
	/// </param>
	/// <param name="lpDialogFunc">
	/// <para>Type: <c>DLGPROC</c></para>
	/// <para>A pointer to the dialog box procedure. For more information about the dialog box procedure, see DialogProc.</para>
	/// </param>
	/// <param name="dwInitParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>The value to pass to the dialog box in the <c>lParam</c> parameter of the WM_INITDIALOG message.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>INT_PTR</c></para>
	/// <para>
	/// If the function succeeds, the return value is the <c>nResult</c> parameter specified in the call to the EndDialog function that was
	/// used to terminate the dialog box.
	/// </para>
	/// <para>
	/// If the function fails because the <c>hWndParent</c> parameter is invalid, the return value is zero. The function returns zero in this
	/// case for compatibility with previous versions of Windows. If the function fails for any other reason, the return value is –1. To get
	/// extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DialogBoxIndirectParam</c> function uses the CreateWindowEx function to create the dialog box. <c>DialogBoxIndirectParam</c>
	/// then sends a WM_INITDIALOG message to the dialog box procedure. If the template specifies the DS_SETFONT or DS_SHELLFONT style, the
	/// function also sends a WM_SETFONT message to the dialog box procedure. The function displays the dialog box (regardless of whether the
	/// template specifies the <c>WS_VISIBLE</c> style), disables the owner window, and starts its own message loop to retrieve and dispatch
	/// messages for the dialog box.
	/// </para>
	/// <para>
	/// When the dialog box procedure calls the EndDialog function, <c>DialogBoxIndirectParam</c> destroys the dialog box, ends the message
	/// loop, enables the owner window (if previously enabled), and returns the <c>nResult</c> parameter specified by the dialog box
	/// procedure when it called <c>EndDialog</c>.
	/// </para>
	/// <para>
	/// In a standard dialog box template, the DLGTEMPLATE structure and each of the DLGITEMTEMPLATE structures must be aligned on
	/// <c>DWORD</c> boundaries. The creation data array that follows a <c>DLGITEMTEMPLATE</c> structure must also be aligned on a
	/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
	/// </para>
	/// <para>
	/// In an extended dialog box template, the DLGTEMPLATEEX header and each of the DLGITEMTEMPLATEEX control definitions must be aligned on
	/// <c>DWORD</c> boundaries. The creation data array, if any, that follows a <c>DLGITEMTEMPLATEEX</c> structure must also be aligned on a
	/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
	/// </para>
	/// <para>All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winuser.h header defines DialogBoxIndirectParam as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dialogboxindirectparama INT_PTR DialogBoxIndirectParamA( [in,
	// optional] HINSTANCE hInstance, [in] LPCDLGTEMPLATEA hDialogTemplate, [in, optional] HWND hWndParent, [in, optional] DLGPROC
	// lpDialogFunc, [in] LPARAM dwInitParam );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.DialogBoxIndirectParamA")]
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	public static extern IntPtr DialogBoxIndirectParam([In, Optional] HINSTANCE hInstance,
		[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(VanaraCustomMarshaler<DLGTEMPLATE_MGD>))] DLGTEMPLATE_MGD hDialogTemplate,
		[In, Optional] HWND hWndParent, [In, Optional] DialogProc? lpDialogFunc, [In, Optional] IntPtr dwInitParam);

	/// <summary>
	/// Creates a modal dialog box from a dialog box template in memory. Before displaying the dialog box, the function passes an
	/// application-defined value to the dialog box procedure as the <c>lParam</c> parameter of the WM_INITDIALOG message. An application can
	/// use this value to initialize dialog box controls.
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the module that creates the dialog box.</para>
	/// </param>
	/// <param name="hDialogTemplate">
	/// <para>Type: <c>LPCDLGTEMPLATE</c></para>
	/// <para>
	/// The template that <c>DialogBoxIndirectParam</c> uses to create the dialog box. A dialog box template consists of a header that
	/// describes the dialog box, followed by one or more additional blocks of data that describe each of the controls in the dialog box. The
	/// template can use either the standard format or the extended format.
	/// </para>
	/// <para>
	/// In a standard template for a dialog box, the header is a DLGTEMPLATE structure followed by additional variable-length arrays. The
	/// data for each control consists of a DLGITEMTEMPLATE structure followed by additional variable-length arrays.
	/// </para>
	/// <para>
	/// In an extended template for a dialog box, the header uses the DLGTEMPLATEEX format and the control definitions use the
	/// DLGITEMTEMPLATEEX format.
	/// </para>
	/// </param>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that owns the dialog box.</para>
	/// </param>
	/// <param name="lpDialogFunc">
	/// <para>Type: <c>DLGPROC</c></para>
	/// <para>A pointer to the dialog box procedure. For more information about the dialog box procedure, see DialogProc.</para>
	/// </param>
	/// <param name="dwInitParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>The value to pass to the dialog box in the <c>lParam</c> parameter of the WM_INITDIALOG message.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>INT_PTR</c></para>
	/// <para>
	/// If the function succeeds, the return value is the <c>nResult</c> parameter specified in the call to the EndDialog function that was
	/// used to terminate the dialog box.
	/// </para>
	/// <para>
	/// If the function fails because the <c>hWndParent</c> parameter is invalid, the return value is zero. The function returns zero in this
	/// case for compatibility with previous versions of Windows. If the function fails for any other reason, the return value is –1. To get
	/// extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DialogBoxIndirectParam</c> function uses the CreateWindowEx function to create the dialog box. <c>DialogBoxIndirectParam</c>
	/// then sends a WM_INITDIALOG message to the dialog box procedure. If the template specifies the DS_SETFONT or DS_SHELLFONT style, the
	/// function also sends a WM_SETFONT message to the dialog box procedure. The function displays the dialog box (regardless of whether the
	/// template specifies the <c>WS_VISIBLE</c> style), disables the owner window, and starts its own message loop to retrieve and dispatch
	/// messages for the dialog box.
	/// </para>
	/// <para>
	/// When the dialog box procedure calls the EndDialog function, <c>DialogBoxIndirectParam</c> destroys the dialog box, ends the message
	/// loop, enables the owner window (if previously enabled), and returns the <c>nResult</c> parameter specified by the dialog box
	/// procedure when it called <c>EndDialog</c>.
	/// </para>
	/// <para>
	/// In a standard dialog box template, the DLGTEMPLATE structure and each of the DLGITEMTEMPLATE structures must be aligned on
	/// <c>DWORD</c> boundaries. The creation data array that follows a <c>DLGITEMTEMPLATE</c> structure must also be aligned on a
	/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
	/// </para>
	/// <para>
	/// In an extended dialog box template, the DLGTEMPLATEEX header and each of the DLGITEMTEMPLATEEX control definitions must be aligned on
	/// <c>DWORD</c> boundaries. The creation data array, if any, that follows a <c>DLGITEMTEMPLATEEX</c> structure must also be aligned on a
	/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
	/// </para>
	/// <para>All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winuser.h header defines DialogBoxIndirectParam as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dialogboxindirectparama INT_PTR DialogBoxIndirectParamA( [in,
	// optional] HINSTANCE hInstance, [in] LPCDLGTEMPLATEA hDialogTemplate, [in, optional] HWND hWndParent, [in, optional] DLGPROC
	// lpDialogFunc, [in] LPARAM dwInitParam );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.DialogBoxIndirectParamA")]
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	public static extern IntPtr DialogBoxIndirectParam([In, Optional] HINSTANCE hInstance,
		[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(VanaraCustomMarshaler<DLGTEMPLATEEX_MGD>))] DLGTEMPLATEEX_MGD hDialogTemplate,
		[In, Optional] HWND hWndParent, [In, Optional] DialogProc? lpDialogFunc, [In, Optional] IntPtr dwInitParam);

	/// <summary>
	/// <para>
	/// Creates a modal dialog box from a dialog box template resource. Before displaying the dialog box, the function passes an
	/// application-defined value to the dialog box procedure as the lParam parameter of the WM_INITDIALOG message. An application can use
	/// this value to initialize dialog box controls.
	/// </para>
	/// </summary>
	/// <param name="hInstance">
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>A handle to the module which contains the dialog box template. If this parameter is NULL, then the current executable is used.</para>
	/// </param>
	/// <param name="lpTemplateName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The dialog box template. This parameter is either the pointer to a null-terminated character string that specifies the name of the
	/// dialog box template or an integer value that specifies the resource identifier of the dialog box template. If the parameter specifies
	/// a resource identifier, its high-order word must be zero and its low-order word must contain the identifier. You can use the
	/// MAKEINTRESOURCE macro to create this value.
	/// </para>
	/// </param>
	/// <param name="hWndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the window that owns the dialog box.</para>
	/// </param>
	/// <param name="lpDialogFunc">
	/// <para>Type: <c>DLGPROC</c></para>
	/// <para>A pointer to the dialog box procedure. For more information about the dialog box procedure, see DialogProc.</para>
	/// </param>
	/// <param name="dwInitParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>The value to pass to the dialog box in the lParam parameter of the WM_INITDIALOG message.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>INT_PTR</c></para>
	/// <para>
	/// If the function succeeds, the return value is the value of the nResult parameter specified in the call to the EndDialog function used
	/// to terminate the dialog box.
	/// </para>
	/// <para>
	/// If the function fails because the hWndParent parameter is invalid, the return value is zero. The function returns zero in this case
	/// for compatibility with previous versions of Windows. If the function fails for any other reason, the return value is –1. To get
	/// extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DialogBoxParam</c> function uses the CreateWindowEx function to create the dialog box. <c>DialogBoxParam</c> then sends a
	/// WM_INITDIALOG message (and a WM_SETFONT message if the template specifies the DS_SETFONT or DS_SHELLFONT style) to the dialog box
	/// procedure. The function displays the dialog box (regardless of whether the template specifies the <c>WS_VISIBLE</c> style), disables
	/// the owner window, and starts its own message loop to retrieve and dispatch messages for the dialog box.
	/// </para>
	/// <para>
	/// When the dialog box procedure calls the EndDialog function, <c>DialogBoxParam</c> destroys the dialog box, ends the message loop,
	/// enables the owner window (if previously enabled), and returns the nResult parameter specified by the dialog box procedure when it
	/// called <c>EndDialog</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-dialogboxparama INT_PTR DialogBoxParamA( HINSTANCE hInstance,
	// LPCSTR lpTemplateName, HWND hWndParent, DLGPROC lpDialogFunc, LPARAM dwInitParam );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "dialogboxparam")]
	public static extern IntPtr DialogBoxParam([In, Optional] HINSTANCE hInstance, SafeResourceId lpTemplateName, [In, Optional] HWND hWndParent, [In, Optional] DialogProc? lpDialogFunc, [Optional] IntPtr dwInitParam);

	/// <summary>
	/// Replaces the contents of a list box with the names of the subdirectories and files in a specified directory. You can filter the list
	/// of names by specifying a set of file attributes. The list can optionally include mapped drives.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the list box.</para>
	/// </param>
	/// <param name="lpPathSpec">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>
	/// A pointer to a buffer containing a null-terminated string that specifies an absolute path, relative path, or filename. An absolute
	/// path can begin with a drive letter (for example, d:) or a UNC name (for example, \&lt;i&gt;machinename\ <c>sharename</c>).
	/// </para>
	/// <para>
	/// The function splits the string into a directory and a filename. The function searches the directory for names that match the
	/// filename. If the string does not specify a directory, the function searches the current directory.
	/// </para>
	/// <para>
	/// If the string includes a filename, the filename must contain at least one wildcard character (? or *). If the string does not include
	/// a filename, the function behaves as if you had specified the asterisk wildcard character (*) as the filename. All names in the
	/// specified directory that match the filename and have the attributes specified by the <c>uFileType</c> parameter are added to the list box.
	/// </para>
	/// </param>
	/// <param name="nIDListBox">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The identifier of a list box in the <c>hDlg</c> dialog box. If this parameter is zero, <c>DlgDirList</c> does not try to fill a list box.
	/// </para>
	/// </param>
	/// <param name="nIDStaticPath">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The identifier of a static control in the <c>hDlg</c> dialog box. <c>DlgDirList</c> sets the text of this control to display the
	/// current drive and directory. This parameter can be zero if you do not want to display the current drive and directory.
	/// </para>
	/// </param>
	/// <param name="uFileType">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Specifies the attributes of the files or directories to be added to the list box. This parameter can be one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>DDL_ARCHIVE</c></description>
	/// <description>Includes archived files.</description>
	/// </item>
	/// <item>
	/// <description><c>DDL_DIRECTORY</c></description>
	/// <description>Includes subdirectories. Subdirectory names are enclosed in square brackets ([ ]).</description>
	/// </item>
	/// <item>
	/// <description><c>DDL_DRIVES</c></description>
	/// <description>
	/// All mapped drives are added to the list. Drives are listed in the form [- <c>x</c>-], where <c>x</c> is the drive letter.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>DDL_EXCLUSIVE</c></description>
	/// <description>
	/// Includes only files with the specified attributes. By default, read/write files are listed even if DDL_READWRITE is not specified.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>DDL_HIDDEN</c></description>
	/// <description>Includes hidden files.</description>
	/// </item>
	/// <item>
	/// <description><c>DDL_READONLY</c></description>
	/// <description>Includes read-only files.</description>
	/// </item>
	/// <item>
	/// <description><c>DDL_READWRITE</c></description>
	/// <description>Includes read/write files with no additional attributes. This is the default setting.</description>
	/// </item>
	/// <item>
	/// <description><c>DDL_SYSTEM</c></description>
	/// <description>Includes system files.</description>
	/// </item>
	/// <item>
	/// <description><c>DDL_POSTMSGS</c></description>
	/// <description>
	/// If set, <c>DlgDirList</c> uses the PostMessage function to send messages to the list box. If not set, <c>DlgDirList</c> uses the
	/// SendMessage function.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. For example, if the string specified by <c>lpPathSpec</c> is not a valid path, the
	/// function fails. To get extended error information, call .
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If <c>lpPathSpec</c> specifies a directory, DlgDirListComboBox changes the current directory to the specified directory before
	/// filling the list box. The text of the static control identified by the <c>nIDStaticPath</c> parameter is set to the name of the new
	/// current directory.
	/// </para>
	/// <para><c>DlgDirList</c> sends the LB_RESETCONTENT and LB_DIR messages to the list box.</para>
	/// <para>
	/// If <c>uFileType</c> includes the DDL_DIRECTORY flag and <c>lpPathSpec</c> specifies a first-level directory, such as C:\TEMP, the
	/// list box will always include a ".." entry for the root directory. This is true even if the root directory has hidden or system
	/// attributes and the DDL_HIDDEN and DDL_SYSTEM flags are not specified. The root directory of an NTFS volume has hidden and system attributes.
	/// </para>
	/// <para>The directory listing displays long filenames, if any.</para>
	/// <para>Examples</para>
	/// <para>
	/// For examples, see the following topics: Creating a Directory Listing in a Single-selection List Box and Creating a Multiple-selection
	/// List Box.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winuser.h header defines DlgDirList as an alias which automatically selects the ANSI or Unicode version of this function based on
	/// the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not encoding-neutral
	/// can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dlgdirlista int DlgDirListA( [in] HWND hDlg, [in, out] PSTR
	// lpPathSpec, [in] int nIDListBox, [in] int nIDStaticPath, [in] UINT uFileType );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.DlgDirListA")]
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DlgDirList([In, AddAsMember] HWND hDlg, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpPathSpec, int nIDListBox, int nIDStaticPath, DDL uFileType);

	/// <summary>
	/// Replaces the contents of a combo box with the names of the subdirectories and files in a specified directory. You can filter the list
	/// of names by specifying a set of file attributes. The list of names can include mapped drive letters.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the combo box.</para>
	/// </param>
	/// <param name="lpPathSpec">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>
	/// A pointer to a buffer containing a null-terminated string that specifies an absolute path, relative path, or file name. An absolute
	/// path can begin with a drive letter (for example, d:) or a UNC name (for example, \\ <c>machinename</c>\ <c>sharename</c>).
	/// </para>
	/// <para>
	/// The function splits the string into a directory and a file name. The function searches the directory for names that match the file
	/// name. If the string does not specify a directory, the function searches the current directory.
	/// </para>
	/// <para>
	/// If the string includes a file name, the file name must contain at least one wildcard character (? or ). If the string does not
	/// include a file name, the function behaves as if you had specified the asterisk wildcard character () as the file name. All names in
	/// the specified directory that match the file name and have the attributes specified by the <c>uFiletype</c> parameter are added to the
	/// list displayed in the combo box.
	/// </para>
	/// </param>
	/// <param name="nIDComboBox">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The identifier of a combo box in the <c>hDlg</c> dialog box. If this parameter is zero, <c>DlgDirListComboBox</c> does not try to
	/// fill a combo box.
	/// </para>
	/// </param>
	/// <param name="nIDStaticPath">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The identifier of a static control in the <c>hDlg</c> dialog box. <c>DlgDirListComboBox</c> sets the text of this control to display
	/// the current drive and directory. This parameter can be zero if you do not want to display the current drive and directory.
	/// </para>
	/// </param>
	/// <param name="uFiletype">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// A set of bit flags that specifies the attributes of the files or directories to be added to the combo box. This parameter can be a
	/// combination of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>DDL_ARCHIVE</c></description>
	/// <description>Includes archived files.</description>
	/// </item>
	/// <item>
	/// <description><c>DDL_DIRECTORY</c></description>
	/// <description>Includes subdirectories, which are enclosed in square brackets ([ ]).</description>
	/// </item>
	/// <item>
	/// <description><c>DDL_DRIVES</c></description>
	/// <description>
	/// All mapped drives are added to the list. Drives are listed in the form [- <c>x</c>-], where <c>x</c> is the drive letter.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>DDL_EXCLUSIVE</c></description>
	/// <description>
	/// Includes only files with the specified attributes. By default, read/write files are listed even if DDL_READWRITE is not specified.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>DDL_HIDDEN</c></description>
	/// <description>Includes hidden files.</description>
	/// </item>
	/// <item>
	/// <description><c>DDL_READONLY</c></description>
	/// <description>Includes read-only files.</description>
	/// </item>
	/// <item>
	/// <description><c>DDL_READWRITE</c></description>
	/// <description>Includes read/write files with no additional attributes. This is the default setting.</description>
	/// </item>
	/// <item>
	/// <description><c>DDL_SYSTEM</c></description>
	/// <description>Includes system files.</description>
	/// </item>
	/// <item>
	/// <description><c>DDL_POSTMSGS</c></description>
	/// <description>
	/// If this flag is set, <c>DlgDirListComboBox</c> uses the PostMessage function to send messages to the combo box. If this flag is not
	/// set, <c>DlgDirListComboBox</c> uses the SendMessage function.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. For example, if the string specified by <c>lpPathSpec</c> is not a valid path, the
	/// function fails. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If <c>lpPathSpec</c> specifies a directory, <c>DlgDirListComboBox</c> changes the current directory to the specified directory before
	/// filling the combo box. The text of the static control identified by the <c>nIDStaticPath</c> parameter is set to the name of the new
	/// current directory.
	/// </para>
	/// <para><c>DlgDirListComboBox</c> sends the CB_RESETCONTENT and CB_DIR messages to the combo box.</para>
	/// <para>
	/// Microsoft WindowsÂ NTÂ 4.0 and later: If <c>uFiletype</c> includes the DDL_DIRECTORY flag and <c>lpPathSpec</c> specifies a
	/// first-level directory, such as C:\TEMP, the combo box will always include a ".." entry for the root directory. This is true even if
	/// the root directory has hidden or system attributes and the DDL_HIDDEN and DDL_SYSTEM flags are not specified. The root directory of
	/// an NTFS volume has hidden and system attributes.
	/// </para>
	/// <para>
	/// <c>Security Warning:Â Â</c> Using this function incorrectly might compromise the security of your program. Incorrect use of this
	/// function includes having <c>lpPathSpec</c> indicate a non-writable buffer, or a buffer without a null-termination. You should review
	/// the Security Considerations: Microsoft Windows Controls before continuing.
	/// </para>
	/// <para>Microsoft WindowsÂ NTÂ 4.0 and later: The list displays long file names, if any.</para>
	/// <para>
	/// WindowsÂ 95 or later: The list displays short file names (the 8.3 form). You can use the SHGetFileInfo or GetFullPathName functions
	/// to get the corresponding long file name.
	/// </para>
	/// <para>
	/// WindowsÂ 95 or later: <c>DlgDirListComboBoxW</c> is supported by the Microsoft Layer for Unicode. To use this, you must add certain
	/// files to your application, as outlined in Microsoft Layer for Unicode on Windows Me/98/95 Systems.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winuser.h header defines DlgDirListComboBox as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dlgdirlistcomboboxa int DlgDirListComboBoxA( [in] HWND hDlg,
	// [in, out] PSTR lpPathSpec, [in] int nIDComboBox, [in] int nIDStaticPath, [in] UINT uFiletype );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.DlgDirListComboBoxA")]
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	public static extern int DlgDirListComboBox([In, AddAsMember] HWND hDlg, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpPathSpec, int nIDComboBox, int nIDStaticPath, DDL uFiletype);

	/// <summary>
	/// Retrieves the current selection from a combo box filled by using the DlgDirListComboBox function. The selection is interpreted as a
	/// drive letter, a file, or a directory name.
	/// </summary>
	/// <param name="hwndDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the combo box.</para>
	/// </param>
	/// <param name="lpString">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>A pointer to the buffer that receives the selected path.</para>
	/// </param>
	/// <param name="cchOut">
	/// <para>Type: <c>int</c></para>
	/// <para>The length, in characters, of the buffer pointed to by the lpString parameter.</para>
	/// </param>
	/// <param name="idComboBox">
	/// <para>Type: <c>int</c></para>
	/// <para>The integer identifier of the combo box control in the dialog box.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the current selection is a directory name, the return value is nonzero.</para>
	/// <para>If the current selection is not a directory name, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the current selection specifies a directory name or drive letter, the <c>DlgDirSelectComboBoxEx</c> function removes the enclosing
	/// square brackets (and hyphens for drive letters) so the name or letter is ready to be inserted into a new path or file name. If there
	/// is no selection, the contents of the buffer pointed to by lpString do not change.
	/// </para>
	/// <para>The <c>DlgDirSelectComboBoxEx</c> function does not allow more than one file name to be returned from a combo box.</para>
	/// <para>If the string is as long or longer than the buffer, the buffer contains the truncated string with a terminating null character.</para>
	/// <para><c>DlgDirSelectComboBoxEx</c> sends CB_GETCURSEL and CB_GETLBTEXT messages to the combo box.</para>
	/// <para>You can use this function with all three types of combo boxes (CBS_SIMPLE, CBS_DROPDOWN, and CBS_DROPDOWNLIST).</para>
	/// <para>
	/// <c>Security Warning:</c> Improper use of this function can cause problems for your application. For instance, the nCount parameter
	/// should be set properly for both ANSI and Unicode versions. Failure to do so could lead to a buffer overflow. You should review
	/// Security Considerations: Microsoft Windows Controls before continuing.
	/// </para>
	/// <para>
	/// <c>Windows 95 or later</c>: <c>DlgDirSelectComboBoxExW</c> is supported by the Microsoft Layer for Unicode (MSLU). To use this, you
	/// must add certain files to your application, as outlined in Microsoft Layer for Unicode on Windows Me/98/95 Systems.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-dlgdirselectcomboboxexa BOOL DlgDirSelectComboBoxExA( HWND
	// hwndDlg, PSTR lpString, int cchOut, int idComboBox );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DlgDirSelectComboBoxEx([In, AddAsMember] HWND hwndDlg, [Out, MarshalAs(UnmanagedType.LPTStr), SizeDef(nameof(cchOut))] StringBuilder lpString, int cchOut, int idComboBox);

	/// <summary>
	/// Retrieves the current selection from a single-selection list box. It assumes that the list box has been filled by the DlgDirList
	/// function and that the selection is a drive letter, filename, or directory name.
	/// </summary>
	/// <param name="hwndDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the list box.</para>
	/// </param>
	/// <param name="lpString">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>A pointer to a buffer that receives the selected path.</para>
	/// </param>
	/// <param name="chCount">
	/// <para>Type: <c>int</c></para>
	/// <para>The length, in <c>TCHARs</c>, of the buffer pointed to by <c>lpString</c>.</para>
	/// </param>
	/// <param name="idListBox">
	/// <para>Type: <c>int</c></para>
	/// <para>The identifier of a list box in the dialog box.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the current selection is a directory name, the return value is nonzero.</para>
	/// <para>If the current selection is not a directory name, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DlgDirSelectEx</c> function copies the selection to the buffer pointed to by the <c>lpString</c> parameter. If the current
	/// selection is a directory name or drive letter, <c>DlgDirSelectEx</c> removes the enclosing square brackets (and hyphens, for drive
	/// letters), so that the name or letter is ready to be inserted into a new path. If there is no selection, <c>lpString</c> does not
	/// change. If the string is as long or longer than the buffer, the buffer will contain the truncated string with a terminating null character.
	/// </para>
	/// <para>
	/// <c>DlgDirSelectEx</c> sends LB_GETCURSEL and LB_GETTEXT messages to the list box. The function does not allow more than one filename
	/// to be returned from a list box. The list box must not be a multiple-selection list box. If it is, this function does not return a
	/// zero value and <c>lpString</c> remains unchanged.
	/// </para>
	/// <para>
	/// <c>WindowsÂ 95 or later</c>: <c>DlgDirSelectExW</c> is supported by the Microsoft Layer for Unicode. To use this, you must add
	/// certain files to your application, as outlined in Microsoft Layer for Unicode on Windows Me/98/95 Systems.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Directory Listing in a Single-selection List Box.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winuser.h header defines DlgDirSelectEx as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dlgdirselectexw BOOL DlgDirSelectExW( [in] HWND hwndDlg, [out]
	// PWSTR lpString, [in] int chCount, [in] int idListBox );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.DlgDirSelectExW")]
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DlgDirSelectEx([In, AddAsMember] HWND hwndDlg, [Out, MarshalAs(UnmanagedType.LPTStr), SizeDef(nameof(chCount))] StringBuilder lpString, int chCount, int idListBox);

	/// <summary>
	/// <para>Destroys a modal dialog box, causing the system to end any processing for the dialog box.</para>
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box to be destroyed.</para>
	/// </param>
	/// <param name="nResult">
	/// <para>Type: <c>INT_PTR</c></para>
	/// <para>The value to be returned to the application from the function that created the dialog box.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Dialog boxes created by the DialogBox, DialogBoxParam, DialogBoxIndirect, and DialogBoxIndirectParam functions must be destroyed
	/// using the <c>EndDialog</c> function. An application calls <c>EndDialog</c> from within the dialog box procedure; the function must
	/// not be used for any other purpose.
	/// </para>
	/// <para>
	/// A dialog box procedure can call <c>EndDialog</c> at any time, even during the processing of the WM_INITDIALOG message. If your
	/// application calls the function while <c>WM_INITDIALOG</c> is being processed, the dialog box is destroyed before it is shown and
	/// before the input focus is set.
	/// </para>
	/// <para>
	/// <c>EndDialog</c> does not destroy the dialog box immediately. Instead, it sets a flag and allows the dialog box procedure to return
	/// control to the system. The system checks the flag before attempting to retrieve the next message from the application queue. If the
	/// flag is set, the system ends the message loop, destroys the dialog box, and uses the value in nResult as the return value from the
	/// function that created the dialog box.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enddialog BOOL EndDialog( HWND hDlg, INT_PTR nResult );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "enddialog")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EndDialog([In, AddAsMember] HWND hDlg, IntPtr nResult);

	/// <summary>
	/// <para>
	/// Retrieves the system's dialog base units, which are the average width and height of characters in the system font. For dialog boxes
	/// that use the system font, you can use these values to convert between dialog template units, as specified in dialog box templates,
	/// and pixels. For dialog boxes that do not use the system font, the conversion from dialog template units to pixels depends on the font
	/// used by the dialog box.
	/// </para>
	/// <para>
	/// For either type of dialog box, it is easier to use the MapDialogRect function to perform the conversion. <c>MapDialogRect</c> takes
	/// the font into account and correctly converts a rectangle from dialog template units into pixels.
	/// </para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// The function returns the dialog base units. The low-order word of the return value contains the horizontal dialog box base unit, and
	/// the high-order word contains the vertical dialog box base unit.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The horizontal base unit returned by <c>GetDialogBaseUnits</c> is equal to the average width, in pixels, of the characters in the
	/// system font; the vertical base unit is equal to the height, in pixels, of the font.
	/// </para>
	/// <para>
	/// The system font is used only if the dialog box template fails to specify a font. Most dialog box templates specify a font; as a
	/// result, this function is not useful for most dialog boxes.
	/// </para>
	/// <para>
	/// For a dialog box that does not use the system font, the base units are the average width and height, in pixels, of the characters in
	/// the dialog's font. You can use the GetTextMetrics and GetTextExtentPoint32 functions to calculate these values for a selected font.
	/// However, by using the MapDialogRect function, you can avoid errors that might result if your calculations differ from those performed
	/// by the system.
	/// </para>
	/// <para>
	/// Each horizontal base unit is equal to 4 horizontal dialog template units; each vertical base unit is equal to 8 vertical dialog
	/// template units. Therefore, to convert dialog template units to pixels, use the following formulas:
	/// </para>
	/// <para>Similarly, to convert from pixels to dialog template units, use the following formulas:</para>
	/// <para>Examples</para>
	/// <para>For an example, see "Creating a Combo Box Toolbar" in Using Combo Boxes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdialogbaseunits long GetDialogBaseUnits( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getdialogbaseunits")]
	public static extern int GetDialogBaseUnits();

	/// <summary>
	/// <para>Retrieves the identifier of the specified control.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the control.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>If the function succeeds, the return value is the identifier of the control.</para>
	/// <para>
	/// If the function fails, the return value is zero. An invalid value for the hwndCtl parameter, for example, will cause the function to
	/// fail. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>GetDlgCtrlID</c> accepts child window handles as well as handles of controls in dialog boxes. An application sets the identifier
	/// for a child window when it creates the window by assigning the identifier value to the hmenu parameter when calling the CreateWindow
	/// or CreateWindowEx function.
	/// </para>
	/// <para>
	/// Although <c>GetDlgCtrlID</c> may return a value if hwndCtl is a handle to a top-level window, top-level windows cannot have
	/// identifiers and such a return value is never valid.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Initializing a Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdlgctrlid int GetDlgCtrlID( HWND hWnd );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getdlgctrlid")]
	public static extern int GetDlgCtrlID([In, AddAsMember] HWND hWnd);

	/// <summary>
	/// <para>Retrieves a handle to a control in the specified dialog box.</para>
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the control.</para>
	/// </param>
	/// <param name="nIDDlgItem">
	/// <para>Type: <c>int</c></para>
	/// <para>The identifier of the control to be retrieved.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>If the function succeeds, the return value is the window handle of the specified control.</para>
	/// <para>
	/// If the function fails, the return value is <c>NULL</c>, indicating an invalid dialog box handle or a nonexistent control. To get
	/// extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You can use the <c>GetDlgItem</c> function with any parent-child window pair, not just with dialog boxes. As long as the hDlg
	/// parameter specifies a parent window and the child window has a unique identifier (as specified by the hMenu parameter in the
	/// CreateWindow or CreateWindowEx function that created the child window), <c>GetDlgItem</c> returns a valid handle to the child window.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Initializing a Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdlgitem HWND GetDlgItem( HWND hDlg, int nIDDlgItem );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getdlgitem")]
	public static extern HWND GetDlgItem([In, AddAsMember] HWND hDlg, int nIDDlgItem);

	/// <summary>
	/// <para>Translates the text of a specified control in a dialog box into an integer value.</para>
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the control of interest.</para>
	/// </param>
	/// <param name="nIDDlgItem">
	/// <para>Type: <c>int</c></para>
	/// <para>The identifier of the control whose text is to be translated.</para>
	/// </param>
	/// <param name="lpTranslated">
	/// <para>Type: <c>BOOL*</c></para>
	/// <para>Indicates success or failure ( <c>TRUE</c> indicates success, <c>FALSE</c> indicates failure).</para>
	/// <para>If this parameter is <c>NULL</c>, the function returns no information about success or failure.</para>
	/// </param>
	/// <param name="bSigned">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// Indicates whether the function should examine the text for a minus sign at the beginning and return a signed integer value if it
	/// finds one ( <c>TRUE</c> specifies this should be done, <c>FALSE</c> that it should not).
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// If the function succeeds, the variable pointed to by lpTranslated is set to <c>TRUE</c>, and the return value is the translated value
	/// of the control text.
	/// </para>
	/// <para>
	/// If the function fails, the variable pointed to by lpTranslated is set to <c>FALSE</c>, and the return value is zero. Note that,
	/// because zero is a possible translated value, a return value of zero does not by itself indicate failure.
	/// </para>
	/// <para>If lpTranslated is <c>NULL</c>, the function returns no information about success or failure.</para>
	/// <para>
	/// Note that, if the bSigned parameter is <c>TRUE</c> and there is a minus sign (–) at the beginning of the text, <c>GetDlgItemInt</c>
	/// translates the text into a signed integer value. Otherwise, the function creates an unsigned integer value. To obtain the proper
	/// value in this case, cast the return value to an <c>int</c> type.
	/// </para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GetDlgItemInt</c> function retrieves the text of the specified control by sending the control a WM_GETTEXT message. The
	/// function translates the retrieved text by stripping any extra spaces at the beginning of the text and then converting the decimal
	/// digits. The function stops translating when it reaches the end of the text or encounters a nonnumeric character.
	/// </para>
	/// <para>
	/// The <c>GetDlgItemInt</c> function returns zero if the translated value is greater than <c>INT_MAX</c> (for signed numbers) or
	/// <c>UINT_MAX</c> (for unsigned numbers).
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Modeless Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdlgitemint UINT GetDlgItemInt( HWND hDlg, int nIDDlgItem,
	// BOOL *lpTranslated, BOOL bSigned );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getdlgitemint")]
	public static extern uint GetDlgItemInt([In, AddAsMember] HWND hDlg, int nIDDlgItem, [MarshalAs(UnmanagedType.Bool)] out bool lpTranslated, [MarshalAs(UnmanagedType.Bool)] bool bSigned);

	/// <summary>
	/// <para>Retrieves the title or text associated with a control in a dialog box.</para>
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the control.</para>
	/// </param>
	/// <param name="nIDDlgItem">
	/// <para>Type: <c>int</c></para>
	/// <para>The identifier of the control whose title or text is to be retrieved.</para>
	/// </param>
	/// <param name="lpString">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>The buffer to receive the title or text.</para>
	/// </param>
	/// <param name="cchMax">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The maximum length, in characters, of the string to be copied to the buffer pointed to by lpString. If the length of the string,
	/// including the null character, exceeds the limit, the string is truncated.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// If the function succeeds, the return value specifies the number of characters copied to the buffer, not including the terminating
	/// null character.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>If the string is as long or longer than the buffer, the buffer will contain the truncated string with a terminating null character.</para>
	/// <para>The <c>GetDlgItemText</c> function sends a WM_GETTEXT message to the control.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Modal Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdlgitemtexta UINT GetDlgItemTextA( HWND hDlg, int
	// nIDDlgItem, PSTR lpString, int cchMax );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "getdlgitemtext")]
	public static extern uint GetDlgItemText([In, AddAsMember] HWND hDlg, int nIDDlgItem, [Out, MarshalAs(UnmanagedType.LPTStr), SizeDef(nameof(cchMax), SizingMethod.QueryResultInReturn)] StringBuilder? lpString, uint cchMax);

	/// <summary>
	/// <para>
	/// Retrieves a handle to the first control in a group of controls that precedes (or follows) the specified control in a dialog box.
	/// </para>
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box to be searched.</para>
	/// </param>
	/// <param name="hCtl">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the control to be used as the starting point for the search. If this parameter is <c>NULL</c>, the function uses the last
	/// (or first) control in the dialog box as the starting point for the search.
	/// </para>
	/// </param>
	/// <param name="bPrevious">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// Indicates how the function is to search the group of controls in the dialog box. If this parameter is <c>TRUE</c>, the function
	/// searches for the previous control in the group. If it is <c>FALSE</c>, the function searches for the next control in the group.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>If the function succeeds, the return value is a handle to the previous (or next) control in the group of controls.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GetNextDlgGroupItem</c> function searches controls in the order (or reverse order) they were created in the dialog box
	/// template. The first control in the group must have the WS_GROUP style; all other controls in the group must have been consecutively
	/// created and must not have the <c>WS_GROUP</c> style.
	/// </para>
	/// <para>
	/// When searching for the previous control, the function returns the first control it locates that is visible and not disabled. If the
	/// control specified by hCtl has the <c>WS_GROUP</c> style, the function temporarily reverses the search to locate the first control
	/// having the <c>WS_GROUP</c> style, then resumes the search in the original direction, returning the first control it locates that is
	/// visible and not disabled, or returning hCtl if no such control is found.
	/// </para>
	/// <para>
	/// When searching for the next control, the function returns the first control it locates that is visible, not disabled, and does not
	/// have the <c>WS_GROUP</c> style. If it encounters a control having the <c>WS_GROUP</c> style, the function reverses the search,
	/// locates the first control having the <c>WS_GROUP</c> style, and returns this control if it is visible and not disabled. Otherwise,
	/// the function resumes the search in the original direction and returns the first control it locates that is visible and not disabled,
	/// or returns hCtl if no such control is found.
	/// </para>
	/// <para>
	/// If the search for the next control in the group encounters a window with the <c>WS_EX_CONTROLPARENT</c> style, the system recursively
	/// searches the window's children.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getnextdlggroupitem HWND GetNextDlgGroupItem( HWND hDlg, HWND
	// hCtl, BOOL bPrevious );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getnextdlggroupitem")]
	public static extern HWND GetNextDlgGroupItem([In, AddAsMember] HWND hDlg, [Optional] HWND hCtl, [MarshalAs(UnmanagedType.Bool)] bool bPrevious);

	/// <summary>
	/// <para>Retrieves a handle to the first control that has the WS_TABSTOP style that precedes (or follows) the specified control.</para>
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box to be searched.</para>
	/// </param>
	/// <param name="hCtl">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the control to be used as the starting point for the search. If this parameter is <c>NULL</c>, the function fails.</para>
	/// </param>
	/// <param name="bPrevious">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// Indicates how the function is to search the dialog box. If this parameter is <c>TRUE</c>, the function searches for the previous
	/// control in the dialog box. If this parameter is <c>FALSE</c>, the function searches for the next control in the dialog box.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// If the function succeeds, the return value is the window handle of the previous (or next) control that has the WS_TABSTOP style set.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GetNextDlgTabItem</c> function searches controls in the order (or reverse order) they were created in the dialog box template.
	/// The function returns the first control it locates that is visible, not disabled, and has the WS_TABSTOP style. If no such control
	/// exists, the function returns hCtl.
	/// </para>
	/// <para>
	/// If the search for the next control with the <c>WS_TABSTOP</c> style encounters a window with the <c>WS_EX_CONTROLPARENT</c> style,
	/// the system recursively searches the window's children.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getnextdlgtabitem HWND GetNextDlgTabItem( HWND hDlg, HWND
	// hCtl, BOOL bPrevious );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "getnextdlgtabitem")]
	public static extern HWND GetNextDlgTabItem([In, AddAsMember] HWND hDlg, [Optional] HWND hCtl, [MarshalAs(UnmanagedType.Bool)] bool bPrevious);

	/// <summary>
	/// <para>Determines whether a message is intended for the specified dialog box and, if it is, processes the message.</para>
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box.</para>
	/// </param>
	/// <param name="lpMsg">
	/// <para>Type: <c>LPMSG</c></para>
	/// <para>A pointer to an MSG structure that contains the message to be checked.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the message has been processed, the return value is nonzero.</para>
	/// <para>If the message has not been processed, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Although the <c>IsDialogMessage</c> function is intended for modeless dialog boxes, you can use it with any window that contains
	/// controls, enabling the windows to provide the same keyboard selection as is used in a dialog box.
	/// </para>
	/// <para>
	/// When <c>IsDialogMessage</c> processes a message, it checks for keyboard messages and converts them into selections for the
	/// corresponding dialog box. For example, the TAB key, when pressed, selects the next control or group of controls, and the DOWN ARROW
	/// key, when pressed, selects the next control in a group.
	/// </para>
	/// <para>
	/// Because the <c>IsDialogMessage</c> function performs all necessary translating and dispatching of messages, a message processed by
	/// <c>IsDialogMessage</c> must not be passed to the TranslateMessage or DispatchMessage function.
	/// </para>
	/// <para><c>IsDialogMessage</c> sends WM_GETDLGCODE messages to the dialog box procedure to determine which keys should be processed.</para>
	/// <para>
	/// <c>IsDialogMessage</c> can send DM_GETDEFID and DM_SETDEFID messages to the window. These messages are defined in the Winuser.h
	/// header file as WM_USER and <c>WM_USER</c> + 1, so conflicts are possible with application-defined messages having the same values.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-isdialogmessagea BOOL IsDialogMessageA( HWND hDlg, LPMSG lpMsg );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "isdialogmessage")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsDialogMessage([In, AddAsMember] HWND hDlg, in MSG lpMsg);

	/// <summary>
	/// <para>
	/// Converts the specified dialog box units to screen units (pixels). The function replaces the coordinates in the specified RECT
	/// structure with the converted coordinates, which allows the structure to be used to create a dialog box or position a control within a
	/// dialog box.
	/// </para>
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to a dialog box. This function accepts only handles returned by one of the dialog box creation functions; handles for other
	/// windows are not valid.
	/// </para>
	/// </param>
	/// <param name="lpRect">
	/// <para>Type: <c>LPRECT</c></para>
	/// <para>A pointer to a RECT structure that contains the dialog box coordinates to be converted.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>MapDialogRect</c> function assumes that the initial coordinates in the RECT structure represent dialog box units. To convert
	/// these coordinates from dialog box units to pixels, the function retrieves the current horizontal and vertical base units for the
	/// dialog box, then applies the following formulas:
	/// </para>
	/// <para>
	/// If the dialog box template has the DS_SETFONT or <c>DS_SHELLFONT</c> style, the base units are the average width and height, in
	/// pixels, of the characters in the font specified by the template.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-mapdialogrect BOOL MapDialogRect( HWND hDlg, LPRECT lpRect );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "mapdialogrect")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool MapDialogRect([In, AddAsMember] HWND hDlg, ref RECT lpRect);

	/// <summary>
	/// <para>Sends a message to the specified control in a dialog box.</para>
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the control.</para>
	/// </param>
	/// <param name="nIDDlgItem">
	/// <para>Type: <c>int</c></para>
	/// <para>The identifier of the control that receives the message.</para>
	/// </param>
	/// <param name="Msg">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The message to be sent.</para>
	/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
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
	/// <para>Type: <c>LRESULT</c></para>
	/// <para>The return value specifies the result of the message processing and depends on the message sent.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>SendDlgItemMessage</c> function does not return until the message has been processed.</para>
	/// <para>Using <c>SendDlgItemMessage</c> is identical to retrieving a handle to the specified control and calling the SendMessage function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Modeless Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-senddlgitemmessagea LRESULT SendDlgItemMessageA( HWND hDlg,
	// int nIDDlgItem, UINT Msg, WPARAM wParam, LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "senddlgitemmessage")]
	public static extern IntPtr SendDlgItemMessage([In, AddAsMember] HWND hDlg, int nIDDlgItem, uint Msg, [In, Optional] IntPtr wParam, [In, Out, Optional] IntPtr lParam);

	/// <summary>
	/// <para>Sends a message to the specified control in a dialog box.</para>
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the control.</para>
	/// </param>
	/// <param name="nIDDlgItem">
	/// <para>Type: <c>int</c></para>
	/// <para>The identifier of the control that receives the message.</para>
	/// </param>
	/// <param name="Msg">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The message to be sent.</para>
	/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
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
	/// <para>Type: <c>LRESULT</c></para>
	/// <para>The return value specifies the result of the message processing and depends on the message sent.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>SendDlgItemMessage</c> function does not return until the message has been processed.</para>
	/// <para>Using <c>SendDlgItemMessage</c> is identical to retrieving a handle to the specified control and calling the SendMessage function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Modeless Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-senddlgitemmessagea LRESULT SendDlgItemMessageA( HWND hDlg,
	// int nIDDlgItem, UINT Msg, WPARAM wParam, LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "senddlgitemmessage")]
	public static extern IntPtr SendDlgItemMessage([In, AddAsMember] HWND hDlg, int nIDDlgItem, uint Msg, [In, Optional] IntPtr wParam, string? lParam);

	/// <summary>
	/// <para>Sends a message to the specified control in a dialog box.</para>
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the control.</para>
	/// </param>
	/// <param name="nIDDlgItem">
	/// <para>Type: <c>int</c></para>
	/// <para>The identifier of the control that receives the message.</para>
	/// </param>
	/// <param name="Msg">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The message to be sent.</para>
	/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
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
	/// <para>Type: <c>LRESULT</c></para>
	/// <para>The return value specifies the result of the message processing and depends on the message sent.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>SendDlgItemMessage</c> function does not return until the message has been processed.</para>
	/// <para>Using <c>SendDlgItemMessage</c> is identical to retrieving a handle to the specified control and calling the SendMessage function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Modeless Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-senddlgitemmessagea LRESULT SendDlgItemMessageA( HWND hDlg,
	// int nIDDlgItem, UINT Msg, WPARAM wParam, LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "senddlgitemmessage")]
	public static extern IntPtr SendDlgItemMessage([In, AddAsMember] HWND hDlg, int nIDDlgItem, uint Msg, [In, Optional] IntPtr wParam, [In, Out] StringBuilder lParam);

	/// <summary>Sends a message to the specified control in a dialog box.</summary>
	/// <typeparam name="TMsg">The type of the MSG.</typeparam>
	/// <typeparam name="TWP">The type of the WPARAM.</typeparam>
	/// <param name="hDlg"><para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the control.</para></param>
	/// <param name="nIDDlgItem"><para>Type: <c>int</c></para>
	/// <para>The identifier of the control that receives the message.</para></param>
	/// <param name="Msg"><para>Type: <c>UINT</c></para>
	/// <para>The message to be sent.</para>
	/// <para>For lists of the system-provided messages, see System-Defined Messages.</para></param>
	/// <param name="wParam"><para>Type: <c>WPARAM</c></para>
	/// <para>Additional message-specific information.</para></param>
	/// <param name="lParam"><para>Type: <c>LPARAM</c></para>
	/// <para>Additional message-specific information.</para></param>
	/// <returns>
	/// <para>Type: <c>LRESULT</c></para>
	/// <para>The return value specifies the result of the message processing and depends on the message sent.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>SendDlgItemMessage</c> function does not return until the message has been processed.</para>
	/// <para>Using <c>SendDlgItemMessage</c> is identical to retrieving a handle to the specified control and calling the SendMessage function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Modeless Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-senddlgitemmessagea LRESULT SendDlgItemMessageA( HWND hDlg,
	// int nIDDlgItem, UINT Msg, WPARAM wParam, LPARAM lParam );
	[PInvokeData("winuser.h", MSDNShortId = "senddlgitemmessage")]
	public static IntPtr SendDlgItemMessage<TMsg, TWP>([In, AddAsMember] HWND hDlg, int nIDDlgItem, TMsg Msg, TWP wParam, [In, Out, Optional] IntPtr lParam)
		where TMsg : struct, IConvertible where TWP : struct, IConvertible
		=> SendDlgItemMessage(hDlg, nIDDlgItem, Convert.ToUInt32(Msg), (IntPtr)Convert.ToInt64(wParam), lParam);

	/// <summary>Sends a message to the specified control in a dialog box.</summary>
	/// <typeparam name="TMsg">The type of the MSG.</typeparam>
	/// <typeparam name="TWP">The type of the WPARAM.</typeparam>
	/// <param name="hDlg"><para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the control.</para></param>
	/// <param name="nIDDlgItem"><para>Type: <c>int</c></para>
	/// <para>The identifier of the control that receives the message.</para></param>
	/// <param name="Msg"><para>Type: <c>UINT</c></para>
	/// <para>The message to be sent.</para>
	/// <para>For lists of the system-provided messages, see System-Defined Messages.</para></param>
	/// <param name="wParam"><para>Type: <c>WPARAM</c></para>
	/// <para>Additional message-specific information.</para></param>
	/// <param name="lParam"><para>Type: <c>LPARAM</c></para>
	/// <para>Additional message-specific information.</para></param>
	/// <returns>
	/// <para>Type: <c>LRESULT</c></para>
	/// <para>The return value specifies the result of the message processing and depends on the message sent.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>SendDlgItemMessage</c> function does not return until the message has been processed.</para>
	/// <para>Using <c>SendDlgItemMessage</c> is identical to retrieving a handle to the specified control and calling the SendMessage function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Modeless Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-senddlgitemmessagea LRESULT SendDlgItemMessageA( HWND hDlg,
	// int nIDDlgItem, UINT Msg, WPARAM wParam, LPARAM lParam );
	[PInvokeData("winuser.h", MSDNShortId = "senddlgitemmessage")]
	public static IntPtr SendDlgItemMessage<TMsg, TWP>([In, AddAsMember] HWND hDlg, int nIDDlgItem, TMsg Msg, in TWP wParam, [In, Out, Optional] IntPtr lParam)
		where TMsg : struct, IConvertible where TWP : struct
	{
		using var wmem = SafeCoTaskMemHandle.CreateFromStructure(wParam);
		return SendDlgItemMessage(hDlg, nIDDlgItem, Convert.ToUInt32(Msg), wmem, lParam);
	}

	/// <summary>Sends a message to the specified control in a dialog box.</summary>
	/// <typeparam name="TMsg">The type of the MSG.</typeparam>
	/// <typeparam name="TWP">The type of the WPARAM.</typeparam>
	/// <param name="hDlg"><para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the control.</para></param>
	/// <param name="nIDDlgItem"><para>Type: <c>int</c></para>
	/// <para>The identifier of the control that receives the message.</para></param>
	/// <param name="Msg"><para>Type: <c>UINT</c></para>
	/// <para>The message to be sent.</para>
	/// <para>For lists of the system-provided messages, see System-Defined Messages.</para></param>
	/// <param name="wParam"><para>Type: <c>WPARAM</c></para>
	/// <para>Additional message-specific information.</para></param>
	/// <param name="lParam"><para>Type: <c>LPARAM</c></para>
	/// <para>Additional message-specific information.</para></param>
	/// <returns>
	/// <para>Type: <c>LRESULT</c></para>
	/// <para>The return value specifies the result of the message processing and depends on the message sent.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>SendDlgItemMessage</c> function does not return until the message has been processed.</para>
	/// <para>Using <c>SendDlgItemMessage</c> is identical to retrieving a handle to the specified control and calling the SendMessage function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Modeless Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-senddlgitemmessagea LRESULT SendDlgItemMessageA( HWND hDlg,
	// int nIDDlgItem, UINT Msg, WPARAM wParam, LPARAM lParam );
	[PInvokeData("winuser.h", MSDNShortId = "senddlgitemmessage")]
	public static IntPtr SendDlgItemMessage<TMsg, TWP>([In, AddAsMember] HWND hDlg, int nIDDlgItem, TMsg Msg, TWP wParam, string? lParam)
		where TMsg : struct, IConvertible where TWP : struct, IConvertible
		=> SendDlgItemMessage(hDlg, nIDDlgItem, Convert.ToUInt32(Msg), (IntPtr)Convert.ToInt64(wParam), lParam);

	/// <summary>Sends a message to the specified control in a dialog box.</summary>
	/// <typeparam name="TMsg">The type of the MSG.</typeparam>
	/// <typeparam name="TWP">The type of the WPARAM.</typeparam>
	/// <param name="hDlg"><para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the control.</para></param>
	/// <param name="nIDDlgItem"><para>Type: <c>int</c></para>
	/// <para>The identifier of the control that receives the message.</para></param>
	/// <param name="Msg"><para>Type: <c>UINT</c></para>
	/// <para>The message to be sent.</para>
	/// <para>For lists of the system-provided messages, see System-Defined Messages.</para></param>
	/// <param name="wParam"><para>Type: <c>WPARAM</c></para>
	/// <para>Additional message-specific information.</para></param>
	/// <param name="lParam"><para>Type: <c>LPARAM</c></para>
	/// <para>Additional message-specific information.</para></param>
	/// <returns>
	/// <para>Type: <c>LRESULT</c></para>
	/// <para>The return value specifies the result of the message processing and depends on the message sent.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>SendDlgItemMessage</c> function does not return until the message has been processed.</para>
	/// <para>Using <c>SendDlgItemMessage</c> is identical to retrieving a handle to the specified control and calling the SendMessage function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Modeless Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-senddlgitemmessagea LRESULT SendDlgItemMessageA( HWND hDlg,
	// int nIDDlgItem, UINT Msg, WPARAM wParam, LPARAM lParam );
	[PInvokeData("winuser.h", MSDNShortId = "senddlgitemmessage")]
	public static IntPtr SendDlgItemMessage<TMsg, TWP>([In, AddAsMember] HWND hDlg, int nIDDlgItem, TMsg Msg, in TWP wParam, string? lParam)
		where TMsg : struct, IConvertible where TWP : struct
	{
		using var wmem = SafeCoTaskMemHandle.CreateFromStructure(wParam);
		return SendDlgItemMessage(hDlg, nIDDlgItem, Convert.ToUInt32(Msg), wmem, lParam);
	}

	/// <summary>Sends a message to the specified control in a dialog box.</summary>
	/// <typeparam name="TMsg">The type of the MSG.</typeparam>
	/// <typeparam name="TWP">The type of the WPARAM.</typeparam>
	/// <param name="hDlg"><para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the control.</para></param>
	/// <param name="nIDDlgItem"><para>Type: <c>int</c></para>
	/// <para>The identifier of the control that receives the message.</para></param>
	/// <param name="Msg"><para>Type: <c>UINT</c></para>
	/// <para>The message to be sent.</para>
	/// <para>For lists of the system-provided messages, see System-Defined Messages.</para></param>
	/// <param name="wParam"><para>Type: <c>WPARAM</c></para>
	/// <para>Additional message-specific information.</para></param>
	/// <param name="lParam"><para>Type: <c>LPARAM</c></para>
	/// <para>Additional message-specific information.</para></param>
	/// <returns>
	/// <para>Type: <c>LRESULT</c></para>
	/// <para>The return value specifies the result of the message processing and depends on the message sent.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>SendDlgItemMessage</c> function does not return until the message has been processed.</para>
	/// <para>Using <c>SendDlgItemMessage</c> is identical to retrieving a handle to the specified control and calling the SendMessage function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Modeless Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-senddlgitemmessagea LRESULT SendDlgItemMessageA( HWND hDlg,
	// int nIDDlgItem, UINT Msg, WPARAM wParam, LPARAM lParam );
	[PInvokeData("winuser.h", MSDNShortId = "senddlgitemmessage")]
	public static IntPtr SendDlgItemMessage<TMsg, TWP>([In, AddAsMember] HWND hDlg, int nIDDlgItem, TMsg Msg, TWP wParam, [In, Out] StringBuilder lParam)
		where TMsg : struct, IConvertible where TWP : struct, IConvertible
		=> SendDlgItemMessage(hDlg, nIDDlgItem, Convert.ToUInt32(Msg), (IntPtr)Convert.ToInt64(wParam), lParam);

	/// <summary>Sends a message to the specified control in a dialog box.</summary>
	/// <typeparam name="TMsg">The type of the MSG.</typeparam>
	/// <typeparam name="TWP">The type of the WPARAM.</typeparam>
	/// <param name="hDlg"><para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the control.</para></param>
	/// <param name="nIDDlgItem"><para>Type: <c>int</c></para>
	/// <para>The identifier of the control that receives the message.</para></param>
	/// <param name="Msg"><para>Type: <c>UINT</c></para>
	/// <para>The message to be sent.</para>
	/// <para>For lists of the system-provided messages, see System-Defined Messages.</para></param>
	/// <param name="wParam"><para>Type: <c>WPARAM</c></para>
	/// <para>Additional message-specific information.</para></param>
	/// <param name="lParam"><para>Type: <c>LPARAM</c></para>
	/// <para>Additional message-specific information.</para></param>
	/// <returns>
	/// <para>Type: <c>LRESULT</c></para>
	/// <para>The return value specifies the result of the message processing and depends on the message sent.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>SendDlgItemMessage</c> function does not return until the message has been processed.</para>
	/// <para>Using <c>SendDlgItemMessage</c> is identical to retrieving a handle to the specified control and calling the SendMessage function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Modeless Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-senddlgitemmessagea LRESULT SendDlgItemMessageA( HWND hDlg,
	// int nIDDlgItem, UINT Msg, WPARAM wParam, LPARAM lParam );
	[PInvokeData("winuser.h", MSDNShortId = "senddlgitemmessage")]
	public static IntPtr SendDlgItemMessage<TMsg, TWP>([In, AddAsMember] HWND hDlg, int nIDDlgItem, TMsg Msg, in TWP wParam, [In, Out] StringBuilder lParam)
		where TMsg : struct, IConvertible where TWP : struct
	{
		using var wmem = SafeCoTaskMemHandle.CreateFromStructure(wParam);
		return SendDlgItemMessage(hDlg, nIDDlgItem, Convert.ToUInt32(Msg), wmem, lParam);
	}

	/// <summary>
	/// <para>Sets the text of a control in a dialog box to the string representation of a specified integer value.</para>
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the control.</para>
	/// </param>
	/// <param name="nIDDlgItem">
	/// <para>Type: <c>int</c></para>
	/// <para>The control to be changed.</para>
	/// </param>
	/// <param name="uValue">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The integer value used to generate the item text.</para>
	/// </param>
	/// <param name="bSigned">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// Indicates whether the uValue parameter is signed or unsigned. If this parameter is <c>TRUE</c>, uValue is signed. If this parameter
	/// is <c>TRUE</c> and uValue is less than zero, a minus sign is placed before the first digit in the string. If this parameter is
	/// <c>FALSE</c>, uValue is unsigned.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>To set the new text, this function sends a WM_SETTEXT message to the specified control.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setdlgitemint BOOL SetDlgItemInt( HWND hDlg, int nIDDlgItem,
	// UINT uValue, BOOL bSigned );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "setdlgitemint")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetDlgItemInt([In, AddAsMember] HWND hDlg, int nIDDlgItem, uint uValue, [MarshalAs(UnmanagedType.Bool)] bool bSigned);

	/// <summary>
	/// <para>Sets the title or text of a control in a dialog box.</para>
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the dialog box that contains the control.</para>
	/// </param>
	/// <param name="nIDDlgItem">
	/// <para>Type: <c>int</c></para>
	/// <para>The control with a title or text to be set.</para>
	/// </param>
	/// <param name="lpString">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The text to be copied to the control.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>SetDlgItemText</c> function sends a WM_SETTEXT message to the specified control.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Using List Boxes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setdlgitemtexta BOOL SetDlgItemTextA( HWND hDlg, int
	// nIDDlgItem, LPCSTR lpString );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "setdlgitemtext")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetDlgItemText([In, AddAsMember] HWND hDlg, int nIDDlgItem, string lpString);

	/// <summary>
	/// <para>
	/// Defines the dimensions and style of a control in a dialog box. One or more of these structures are combined with a DLGTEMPLATE
	/// structure to form a standard template for a dialog box.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// In a standard template for a dialog box, the <c>DLGITEMTEMPLATE</c> structure is always immediately followed by three variable-length
	/// arrays specifying the class, title, and creation data for the control. Each array consists of one or more 16-bit elements.
	/// </para>
	/// <para>
	/// Each <c>DLGITEMTEMPLATE</c> structure in the template must be aligned on a <c>DWORD</c> boundary. The class and title arrays must be
	/// aligned on <c>WORD</c> boundaries. The creation data array must be aligned on a <c>WORD</c> boundary.
	/// </para>
	/// <para>
	/// Immediately following each <c>DLGITEMTEMPLATE</c> structure is a class array that specifies the window class of the control. If the
	/// first element of this array is any value other than 0xFFFF, the system treats the array as a null-terminated Unicode string that
	/// specifies the name of a registered window class. If the first element is 0xFFFF, the array has one additional element that specifies
	/// the ordinal value of a predefined system class. The ordinal can be one of the following atom values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0x0080</term>
	/// <term>Button</term>
	/// </item>
	/// <item>
	/// <term>0x0081</term>
	/// <term>Edit</term>
	/// </item>
	/// <item>
	/// <term>0x0082</term>
	/// <term>Static</term>
	/// </item>
	/// <item>
	/// <term>0x0083</term>
	/// <term>List box</term>
	/// </item>
	/// <item>
	/// <term>0x0084</term>
	/// <term>Scroll bar</term>
	/// </item>
	/// <item>
	/// <term>0x0085</term>
	/// <term>Combo box</term>
	/// </item>
	/// </list>
	/// <para>
	/// Following the class array is a title array that contains the initial text or resource identifier of the control. If the first element
	/// of this array is 0xFFFF, the array has one additional element that specifies an ordinal value of a resource, such as an icon, in an
	/// executable file. You can use a resource identifier for controls, such as static icon controls, that load and display an icon or other
	/// resource rather than text. If the first element is any value other than 0xFFFF, the system treats the array as a null-terminated
	/// Unicode string that specifies the initial text.
	/// </para>
	/// <para>
	/// The creation data array begins at the next <c>WORD</c> boundary after the title array. This creation data can be of any size and
	/// format. If the first word of the creation data array is nonzero, it indicates the size, in bytes, of the creation data (including the
	/// size word). The control's window procedure must be able to interpret the data. When the system creates the control, it passes a
	/// pointer to this data in the lParam parameter of the WM_CREATE message that it sends to the control.
	/// </para>
	/// <para>
	/// If you specify character strings in the class and title arrays, you must use Unicode strings. Use the MultiByteToWideChar function to
	/// generate Unicode strings from ANSI strings.
	/// </para>
	/// <para>
	/// The <c>x</c>, <c>y</c>, <c>cx</c>, and <c>cy</c> members specify values in dialog box units. You can convert these values to screen
	/// units (pixels) by using the MapDialogRect function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-dlgitemtemplate typedef struct DLGITEMTEMPLATE { DWORD style;
	// DWORD dwExtendedStyle; short x; short y; short cx; short cy; WORD id; };
	[PInvokeData("winuser.h", MSDNShortId = "dlgitemtemplate")]
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	public struct DLGITEMTEMPLATE
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The style of the control. This member can be a combination of window style values (such as <c>WS_BORDER</c>) and one or more of
		/// the control style values (such as <c>BS_PUSHBUTTON</c> and <c>ES_LEFT</c>).
		/// </para>
		/// </summary>
		public uint style;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The extended styles for a window. This member is not used to create controls in dialog boxes, but applications that use dialog
		/// box templates can use it to create other types of windows. For a list of values, see Extended Window Styles.
		/// </para>
		/// </summary>
		public uint dwExtendedStyle;

		/// <summary>
		/// <para>Type: <c>short</c></para>
		/// <para>
		/// The x-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
		/// upper-left corner of the dialog box's client area.
		/// </para>
		/// </summary>
		public short x;

		/// <summary>
		/// <para>Type: <c>short</c></para>
		/// <para>
		/// The y-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
		/// upper-left corner of the dialog box's client area.
		/// </para>
		/// </summary>
		public short y;

		/// <summary>
		/// <para>Type: <c>short</c></para>
		/// <para>The width, in dialog box units, of the control.</para>
		/// </summary>
		public short cx;

		/// <summary>
		/// <para>Type: <c>short</c></para>
		/// <para>The height, in dialog box units, of the control.</para>
		/// </summary>
		public short cy;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>The control identifier.</para>
		/// </summary>
		public ushort id;
	}

	/// <summary>
	/// <para>
	/// Defines the dimensions and style of a dialog box. This structure, always the first in a standard template for a dialog box, also
	/// specifies the number of controls in the dialog box and therefore specifies the number of subsequent DLGITEMTEMPLATE structures in the template.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// In a standard template for a dialog box, the <c>DLGTEMPLATE</c> structure is always immediately followed by three variable-length
	/// arrays that specify the menu, class, and title for the dialog box. When the DS_SETFONT style is specified, these arrays are also
	/// followed by a 16-bit value specifying point size and another variable-length array specifying a typeface name. Each array consists of
	/// one or more 16-bit elements. The menu, class, title, and font arrays must be aligned on <c>WORD</c> boundaries.
	/// </para>
	/// <para>
	/// Immediately following the <c>DLGTEMPLATE</c> structure is a menu array that identifies a menu resource for the dialog box. If the
	/// first element of this array is 0x0000, the dialog box has no menu and the array has no other elements. If the first element is
	/// 0xFFFF, the array has one additional element that specifies the ordinal value of a menu resource in an executable file. If the first
	/// element has any other value, the system treats the array as a null-terminated Unicode string that specifies the name of a menu
	/// resource in an executable file.
	/// </para>
	/// <para>
	/// Following the menu array is a class array that identifies the window class of the control. If the first element of the array is
	/// 0x0000, the system uses the predefined dialog box class for the dialog box and the array has no other elements. If the first element
	/// is 0xFFFF, the array has one additional element that specifies the ordinal value of a predefined system window class. If the first
	/// element has any other value, the system treats the array as a null-terminated Unicode string that specifies the name of a registered
	/// window class.
	/// </para>
	/// <para>
	/// Following the class array is a title array that specifies a null-terminated Unicode string that contains the title of the dialog box.
	/// If the first element of this array is 0x0000, the dialog box has no title and the array has no other elements.
	/// </para>
	/// <para>
	/// The 16-bit point size value and the typeface array follow the title array, but only if the <c>style</c> member specifies the
	/// DS_SETFONT style. The point size value specifies the point size of the font to use for the text in the dialog box and its controls.
	/// The typeface array is a null-terminated Unicode string specifying the name of the typeface for the font. When these values are
	/// specified, the system creates a font having the specified size and typeface (if possible) and sends a WM_SETFONT message to the
	/// dialog box procedure and the control window procedures as it creates the dialog box and controls.
	/// </para>
	/// <para>
	/// Following the <c>DLGTEMPLATE</c> header in a standard dialog box template are one or more DLGITEMTEMPLATE structures that define the
	/// dimensions and style of the controls in the dialog box. The <c>cdit</c> member specifies the number of <c>DLGITEMTEMPLATE</c>
	/// structures in the template. These <c>DLGITEMTEMPLATE</c> structures must be aligned on <c>DWORD</c> boundaries.
	/// </para>
	/// <para>If you specify character strings in the menu, class, title, or typeface arrays, you must use Unicode strings.</para>
	/// <para>
	/// The <c>x</c>, <c>y</c>, <c>cx</c>, and <c>cy</c> members specify values in dialog box units. You can convert these values to screen
	/// units (pixels) by using the MapDialogRect function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-dlgtemplate typedef struct DLGTEMPLATE { DWORD style; DWORD
	// dwExtendedStyle; WORD cdit; short x; short y; short cx; short cy; };
	[PInvokeData("winuser.h", MSDNShortId = "dlgtemplate")]
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	public struct DLGTEMPLATE
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The style of the dialog box. This member can be a combination of window style values (such as <c>WS_CAPTION</c> and
		/// <c>WS_SYSMENU</c>) and dialog box style values (such as <c>DS_CENTER</c>).
		/// </para>
		/// <para>
		/// If the style member includes the <c>DS_SETFONT</c> style, the header of the dialog box template contains additional data
		/// specifying the font to use for text in the client area and controls of the dialog box. The font data begins on the <c>WORD</c>
		/// boundary that follows the title array. The font data specifies a 16-bit point size value and a Unicode font name string. If
		/// possible, the system creates a font according to the specified values. Then the system sends a WM_SETFONT message to the dialog
		/// box and to each control to provide a handle to the font. If <c>DS_SETFONT</c> is not specified, the dialog box template does not
		/// include the font data.
		/// </para>
		/// <para>The <c>DS_SHELLFONT</c> style is not supported in the <c>DLGTEMPLATE</c> header.</para>
		/// </summary>
		public uint style;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The extended styles for a window. This member is not used to create dialog boxes, but applications that use dialog box templates
		/// can use it to create other types of windows. For a list of values, see Extended Window Styles.
		/// </para>
		/// </summary>
		public uint dwExtendedStyle;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>The number of items in the dialog box.</para>
		/// </summary>
		public ushort cdit;

		/// <summary>
		/// <para>Type: <c>short</c></para>
		/// <para>The x-coordinate, in dialog box units, of the upper-left corner of the dialog box.</para>
		/// </summary>
		public short x;

		/// <summary>
		/// <para>Type: <c>short</c></para>
		/// <para>The y-coordinate, in dialog box units, of the upper-left corner of the dialog box.</para>
		/// </summary>
		public short y;

		/// <summary>
		/// <para>Type: <c>short</c></para>
		/// <para>The width, in dialog box units, of the dialog box.</para>
		/// </summary>
		public short cx;

		/// <summary>
		/// <para>Type: <c>short</c></para>
		/// <para>The height, in dialog box units, of the dialog box.</para>
		/// </summary>
		public short cy;
	}

	/// <summary>
	/// Defines the dimensions and style of a dialog box. This structure, always the first in a standard template for a dialog box, also
	/// specifies the controls in the dialog box.
	/// </summary>
	/// <remarks>
	/// The <c>x</c>, <c>y</c>, <c>cx</c>, and <c>cy</c> members specify values in dialog box units. You can convert these values to screen
	/// units (pixels) by using the MapDialogRect function.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-dlgtemplate typedef struct { DWORD style; DWORD
	// dwExtendedStyle; WORD cdit; short x; short y; short cx; short cy; } DLGTEMPLATE;
	[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.DLGTEMPLATE")]
	public class DLGTEMPLATE_MGD : IVanaraMarshaler
	{
		/// <summary>One or more items that define the dimensions and style of the controls in the dialog box.</summary>
		public List<DlgItemTemplate> controls = [];

		/// <summary>The width, in dialog box units, of the dialog box.</summary>
		public short cx;

		/// <summary>The height, in dialog box units, of the dialog box.</summary>
		public short cy;

		/// <summary>
		/// <para>
		/// The extended styles for a window. This member is not used to create dialog boxes, but applications that use dialog box templates
		/// can use it to create other types of windows. For a list of values, see Extended Window Styles.
		/// </para>
		/// </summary>
		public WindowStylesEx dwExtendedStyle;

		/// <summary>The point size of the font to use for the text in the dialog box and its controls.</summary>
		public ushort? pointSz;

		/// <summary>Specifies the name of the typeface for the font.</summary>
		public string? typeface;

		/// <summary>
		/// Identifies a menu resource for the dialog box. If <see langword="null"/>, the dialog box has no menu. If the <see
		/// cref="DlgTemplateId.id"/> field is set, it specifies the ordinal value of a menu resource. If the <see cref="DlgTemplateId.name"/> is set, it
		/// specifies the name of a menu resource.
		/// </summary>
		public DlgTemplateId? menu;

		/// <summary>
		/// <para>
		/// The style of the dialog box. This member can be a combination of window style values (such as <c>WS_CAPTION</c> and
		/// <c>WS_SYSMENU</c>) and dialog box style values (such as <c>DS_CENTER</c>).
		/// </para>
		/// <para>
		/// If the style member includes the <c>DS_SETFONT</c> style, the header of the dialog box template contains additional data
		/// specifying the font to use for text in the client area and controls of the dialog box. The font data begins on the <c>WORD</c>
		/// boundary that follows the title array. The font data specifies a 16-bit point size value and a Unicode font name string. If
		/// possible, the system creates a font according to the specified values. Then the system sends a WM_SETFONT message to the dialog
		/// box and to each control to provide a handle to the font. If <c>DS_SETFONT</c> is not specified, the dialog box template does not
		/// include the font data.
		/// </para>
		/// <para>The <c>DS_SHELLFONT</c> style is not supported in the <c>DLGTEMPLATE</c> header.</para>
		/// </summary>
		public WindowStyles style;

		/// <summary>Specifies a string that contains the title of the dialog box. If <see langword="null"/>, the dialog box has no title.</summary>
		public string? title;

		/// <summary>
		/// Identifies the window class of the dialog box. If <see langword="null"/>, the system uses the predefined dialog box class for the
		/// dialog box. If the <see cref="DlgTemplateId.id"/> field is set, it specifies the ordinal value of a predefined system window class. If
		/// the <see cref="DlgTemplateId.name"/> is set, it specifies the name of a registered window class.
		/// </summary>
		public DlgTemplateId? wclass;

		/// <summary>The x-coordinate, in dialog box units, of the upper-left corner of the dialog box.</summary>
		public short x;

		/// <summary>The y-coordinate, in dialog box units, of the upper-left corner of the dialog box.</summary>
		public short y;

		/// <summary>Makes a button template.</summary>
		/// <param name="text">Contains the initial text of the control.</param>
		/// <param name="id">The control identifier.</param>
		/// <param name="x">
		/// The x-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
		/// upper-left corner of the dialog box's client area.
		/// </param>
		/// <param name="y">
		/// The y-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
		/// upper-left corner of the dialog box's client area.
		/// </param>
		/// <param name="cx">The width, in dialog box units, of the control.</param>
		/// <param name="cy">The height, in dialog box units, of the control.</param>
		/// <param name="style">
		/// The style of the control. This member can be a combination of window style values (such as <c>WS_BORDER</c>) and one or more of
		/// the control style values (such as <c>BS_PUSHBUTTON</c> and <c>ES_LEFT</c>).
		/// </param>
		/// <param name="exstyle">
		/// The extended styles for a window. This member is not used to create controls in dialog boxes, but applications that use dialog
		/// box templates can use it to create other types of windows. For a list of values, see Extended Window Styles.
		/// </param>
		/// <returns>A dialog control item template.</returns>
		public static DlgItemTemplate MakeButton(string text, ushort id, short x, short y, short cx = 50, short cy = 14, WindowStyles style = WindowStyles.WS_CHILD | WindowStyles.WS_VISIBLE | WindowStyles.WS_TABSTOP | (WindowStyles)ButtonStyle.BS_PUSHBUTTON, WindowStylesEx exstyle = 0) =>
			MakeControl(0x0080, text, id, x, y, cx, cy, style, exstyle);

		/// <summary>Makes a standard control template.</summary>
		/// <param name="classId">
		/// <para>The ordinal value of a predefined system class. The ordinal can be one of the following atom values:</para>
		/// <list type="table">
		/// <item>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </item>
		/// <item>
		/// <description>0x0080</description>
		/// <description>Button</description>
		/// </item>
		/// <item>
		/// <description>0x0081</description>
		/// <description>Edit</description>
		/// </item>
		/// <item>
		/// <description>0x0082</description>
		/// <description>Static</description>
		/// </item>
		/// <item>
		/// <description>0x0083</description>
		/// <description>List box</description>
		/// </item>
		/// <item>
		/// <description>0x0084</description>
		/// <description>Scroll bar</description>
		/// </item>
		/// <item>
		/// <description>0x0085</description>
		/// <description>Combo box</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="text">Contains the initial text of the control.</param>
		/// <param name="id">The control identifier.</param>
		/// <param name="x">
		/// The x-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
		/// upper-left corner of the dialog box's client area.
		/// </param>
		/// <param name="y">
		/// The y-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
		/// upper-left corner of the dialog box's client area.
		/// </param>
		/// <param name="cx">The width, in dialog box units, of the control.</param>
		/// <param name="cy">The height, in dialog box units, of the control.</param>
		/// <param name="style">
		/// The style of the control. This member can be a combination of window style values (such as <c>WS_BORDER</c>) and one or more of
		/// the control style values (such as <c>BS_PUSHBUTTON</c> and <c>ES_LEFT</c>).
		/// </param>
		/// <param name="exstyle">
		/// The extended styles for a window. This member is not used to create controls in dialog boxes, but applications that use dialog
		/// box templates can use it to create other types of windows. For a list of values, see Extended Window Styles.
		/// </param>
		/// <returns>A dialog control item template.</returns>
		public static DlgItemTemplate MakeControl(ushort classId, string text, ushort id, short x, short y, short cx, short cy, WindowStyles style, WindowStylesEx exstyle) => new()
		{
			x = x,
			y = y,
			cx = cx,
			cy = cy,
			id = id,
			style = style,
			dwExtendedStyle = exstyle,
			wclass = new() { id = classId },
			title = new() { name = text },
		};

		/// <summary>Makes a static control (label) template.</summary>
		/// <param name="text">Contains the initial text of the control.</param>
		/// <param name="id">The control identifier.</param>
		/// <param name="x">
		/// The x-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
		/// upper-left corner of the dialog box's client area.
		/// </param>
		/// <param name="y">
		/// The y-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
		/// upper-left corner of the dialog box's client area.
		/// </param>
		/// <param name="cx">The width, in dialog box units, of the control.</param>
		/// <param name="cy">The height, in dialog box units, of the control.</param>
		/// <param name="style">
		/// The style of the control. This member can be a combination of window style values (such as <c>WS_BORDER</c>) and one or more of
		/// the control style values (such as <c>BS_PUSHBUTTON</c> and <c>ES_LEFT</c>).
		/// </param>
		/// <param name="exstyle">
		/// The extended styles for a window. This member is not used to create controls in dialog boxes, but applications that use dialog
		/// box templates can use it to create other types of windows. For a list of values, see Extended Window Styles.
		/// </param>
		/// <returns>A dialog control item template.</returns>
		public static DlgItemTemplate MakeStatic(string text, ushort id, short x, short y, short cx = 50, short cy = 14, WindowStyles style = WindowStyles.WS_CHILD | WindowStyles.WS_VISIBLE | (WindowStyles)StaticStyle.SS_LEFT, WindowStylesEx exstyle = 0) =>
			MakeControl(0x0082, text, id, x, y, cx, cy, style, exstyle);

		SIZE_T IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf<DLGTEMPLATE>() + sizeof(ushort) * 3;

		SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject)
		{
			if (managedObject is not DLGTEMPLATE_MGD dt)
				throw new ArgumentException("Invalid type", nameof(managedObject));
			SafeHGlobalHandle h = new(256);
			NativeMemoryStream buffer = new(h);
			DLGTEMPLATE dlg = new()
			{
				cdit = (ushort)dt.controls.Count,
				style = (uint)dt.style,
				dwExtendedStyle = (uint)dt.dwExtendedStyle,
				x = dt.x,
				y = dt.y,
				cx = dt.cx,
				cy = dt.cy
			};
			buffer.Write(dlg);
			WriteId(dt.menu);
			WriteId(dt.wclass);
			WriteString(dt.title);
			// write font
			if (((uint)dt.style & (uint)DialogBoxStyles.DS_SETFONT) != 0)
			{
				buffer.Write(dt.pointSz.GetValueOrDefault());
				WriteString(dt.typeface);
			}
			foreach (var c in dt.controls)
				WriteControl(c);
			buffer.Flush();
			System.Diagnostics.Debug.Write(h.DangerousGetHandle().ToHexDumpString(h.Size));
			return h;

			void WriteControl(DlgItemTemplate item)
			{
				buffer.Position = Macros.ALIGN_TO_MULTIPLE(buffer.Position, 4);
				DLGITEMTEMPLATE dit = new()
				{
					style = (uint)item.style,
					dwExtendedStyle = (uint)item.dwExtendedStyle,
					x = item.x,
					y = item.y,
					cx = item.cx,
					cy = item.cy,
					id = item.id,
				};
				buffer.Write(dit);
				WriteId(item.wclass);
				WriteId(item.title);
				buffer.Write((ushort)(item.creationData?.Length ?? 0));
				if (item.creationData is not null)
					buffer.Write(item.creationData);
			}
			void WriteId(DlgTemplateId? tid)
			{
				if (tid is null)
					buffer.Write((ushort)0);
				else
				{
					if (tid.id.HasValue)
					{
						buffer.Write((ushort)0xFFFF);
						buffer.Write(tid.id.Value);
					}
					else if (tid.name is not null)
						buffer.Write(tid.name + '\0', CharSet.Unicode);
					else
						throw new InvalidOperationException();
				}
			}
			void WriteString(string? s)
			{
				if (s is null)
					buffer.Write((ushort)0);
				else
					buffer.Write(s + '\0', CharSet.Unicode);
			}
		}

		object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SIZE_T allocatedBytes)
		{
			if (pNativeData == IntPtr.Zero)
				return null;
			if (allocatedBytes < ((IVanaraMarshaler)this).GetNativeSize())
				throw new ArgumentException("Invalid data", nameof(pNativeData));
			NativeMemoryStream buffer = new(pNativeData, allocatedBytes);
			DLGTEMPLATE_MGD dt = new()
			{
				style = buffer.Read<WindowStyles>(),
				dwExtendedStyle = buffer.Read<WindowStylesEx>()
			};
			var cc = buffer.Read<ushort>();
			dt.x = buffer.Read<short>();
			dt.y = buffer.Read<short>();
			dt.cx = buffer.Read<short>();
			dt.cy = buffer.Read<short>();
			dt.menu = ReadId();
			dt.wclass = ReadId();
			dt.title = ReadString();
			if (((uint)dt.style & (uint)DialogBoxStyles.DS_SETFONT) != 0)
			{
				dt.pointSz = buffer.Read<ushort>();
				dt.typeface = ReadString();
			}
			for (int i = 0; i < cc; i++)
				dt.controls.Add(ReadControl());
			return dt;

			DlgItemTemplate ReadControl()
			{
				buffer.Position = Macros.ALIGN_TO_MULTIPLE(buffer.Position, 4);
				DlgItemTemplate item = new()
				{
					style = buffer.Read<WindowStyles>(),
					dwExtendedStyle = buffer.Read<WindowStylesEx>(),
					x = buffer.Read<short>(),
					y = buffer.Read<short>(),
					cx = buffer.Read<short>(),
					cy = buffer.Read<short>(),
					id = buffer.Read<ushort>(),
					wclass = ReadId() ?? new(),
					title = ReadId() ?? new()
				};
				var c = buffer.Read<ushort>();
				if (c > 0)
					item.creationData = [.. buffer.ReadArray<byte>(c, false)];
				return item;
			}
			DlgTemplateId? ReadId()
			{
				var flag = Peek<ushort>();
				if (flag == 0)
				{
					buffer.Read<ushort>();
					return null;
				}
				if (flag == 0xFFFF)
				{
					buffer.Read<ushort>();
					return new() { id = buffer.Read<ushort>() };
				}
				var name = buffer.Read<string>(CharSet.Unicode);
				if (buffer.Read<ushort>() != 0) throw new InvalidOperationException();
				return new() { name = name };
			}
			string? ReadString()
			{
				// Peek at first word
				var l = Peek<ushort>();
				if (l == 0) return null;
				var s = buffer.Read<string>(CharSet.Unicode);
				if (buffer.Read<ushort>() != 0) throw new InvalidOperationException();
				return s;
			}
			T Peek<T>() where T : struct => buffer.Pointer.Offset(buffer.Position).ToStructure<T>();
		}

		/// <summary>Identifies details about a font used by the dialog.</summary>
		public class FontDetail
		{
		}

		/// <summary>
		/// Defines the dimensions and style of a control in a dialog box. One or more of these instances are added to form a standard
		/// template for a dialog box.
		/// </summary>
		public class DlgItemTemplate
		{
			/// <summary>
			/// This creation data can be of any size and format or <see langword="null"/>. The control's window procedure must be able to
			/// interpret the data. When the system creates the control, it passes a pointer to this data in the lParam parameter of the
			/// WM_CREATE message that it sends to the control.
			/// </summary>
			public byte[]? creationData;

			/// <summary>The width, in dialog box units, of the control.</summary>
			public short cx;

			/// <summary>The height, in dialog box units, of the control.</summary>
			public short cy;

			/// <summary>
			/// The extended styles for a window. This member is not used to create controls in dialog boxes, but applications that use
			/// dialog box templates can use it to create other types of windows. For a list of values, see Extended Window Styles.
			/// </summary>
			public WindowStylesEx dwExtendedStyle;

			/// <summary>The control identifier.</summary>
			public ushort id;

			/// <summary>
			/// The style of the control. This member can be a combination of window style values (such as <c>WS_BORDER</c>) and one or more
			/// of the control style values (such as <c>BS_PUSHBUTTON</c> and <c>ES_LEFT</c>).
			/// </summary>
			public WindowStyles style;

			/// <summary>Contains the initial text or resource identifier of the control.</summary>
			public DlgTemplateId title = new();

			/// <summary>
			/// Identifies the window class of the control. If the <see cref="DlgTemplateId.id"/> field is set, it specifies the ordinal value of a
			/// predefined system class. If the <see cref="DlgTemplateId.name"/> is set, it specifies the name of a registered window class.
			/// <para>The ordinal can be one of the following atom values:</para>
			/// <list type="table">
			/// <item>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </item>
			/// <item>
			/// <description>0x0080</description>
			/// <description>Button</description>
			/// </item>
			/// <item>
			/// <description>0x0081</description>
			/// <description>Edit</description>
			/// </item>
			/// <item>
			/// <description>0x0082</description>
			/// <description>Static</description>
			/// </item>
			/// <item>
			/// <description>0x0083</description>
			/// <description>List box</description>
			/// </item>
			/// <item>
			/// <description>0x0084</description>
			/// <description>Scroll bar</description>
			/// </item>
			/// <item>
			/// <description>0x0085</description>
			/// <description>Combo box</description>
			/// </item>
			/// </list>
			/// </summary>
			public DlgTemplateId wclass = new();

			/// <summary>
			/// The x-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
			/// upper-left corner of the dialog box's client area.
			/// </summary>
			public short x;

			/// <summary>
			/// The y-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
			/// upper-left corner of the dialog box's client area.
			/// </summary>
			public short y;
		}
	}

	/// <summary>
	/// Identifies a dialog detail that can either hold an ordinal of a resource as the <see cref="id"/> or a string that specifies a
	/// resource name.
	/// </summary>
	public class DlgTemplateId
	{
		/// <summary>An ordinal of another resource.</summary>
		public ushort? id;

		/// <summary>The name of a resource or the text for the detail.</summary>
		public string? name;
	}

	/// <summary>
	/// <para>
	/// An extended dialog box template begins with a <c>DLGTEMPLATEEX</c> header that describes the dialog box and specifies the number of
	/// controls in the dialog box. For each control in a dialog box, an extended dialog box template has a block of data that uses the
	/// <c>DLGITEMTEMPLATEEX</c> format to describe the control.
	/// </para>
	/// <para>
	/// The <c>DLGTEMPLATEEX</c> structure is not defined in any standard header file. The structure definition is provided here to explain
	/// the format of an extended template for a dialog box.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// You can use an extended dialog box template instead of a standard dialog box template in the <c>CreateDialogIndirectParam</c>,
	/// <c>DialogBoxIndirectParam</c>, <c>CreateDialogIndirect</c>, and <c>DialogBoxIndirect</c> functions.
	/// </para>
	/// <para>
	/// Following the <c>DLGTEMPLATEEX</c> header in an extended dialog box template is one or more <c>DLGITEMTEMPLATEEX</c> structures that
	/// describe the controls of the dialog box. The <c>cDlgItems</c> member of the <c>DLGITEMTEMPLATEEX</c> structure specifies the number
	/// of <c>DLGITEMTEMPLATEEX</c> structures that follow in the template.
	/// </para>
	/// <para>
	/// Each <c>DLGITEMTEMPLATEEX</c> structure in the template must be aligned on a <c>DWORD</c> boundary. If the <c>style</c> member
	/// specifies the <c>DS_SETFONT</c> or <c>DS_SHELLFONT</c> style, the first <c>DLGITEMTEMPLATEEX</c> structure begins on the first
	/// <c>DWORD</c> boundary after the <c>typeface</c> string. If these styles are not specified, the first structure begins on the first
	/// <c>DWORD</c> boundary after the <c>title</c> string.
	/// </para>
	/// <para>The <c>menu</c>, <c>windowClass</c>, <c>title</c>, and <c>typeface</c> arrays must be aligned on <c>WORD</c> boundaries.</para>
	/// <para>
	/// If you specify character strings in the <c>menu</c>, <c>windowClass</c>, <c>title</c>, and <c>typeface</c> arrays, you must use
	/// Unicode strings. Use the <c>MultiByteToWideChar</c> function to generate these Unicode strings from ANSI strings.
	/// </para>
	/// <para>
	/// The <c>x</c>, <c>y</c>, <c>cx</c>, and <c>cy</c> members specify values in dialog box units. You can convert these values to screen
	/// units (pixels) by using the <c>MapDialogRect</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/dlgbox/dlgtemplateex typedef struct { WORD dlgVer; WORD signature; DWORD helpID;
	// DWORD exStyle; DWORD style; WORD cDlgItems; short x; short y; short cx; short cy; sz_Or_Ord menu; sz_Or_Ord windowClass; WCHAR
	// title[titleLen]; WORD pointsize; WORD weight; BYTE italic; BYTE charset; WCHAR typeface[stringLen]; } DLGTEMPLATEEX;
	[PInvokeData("", MSDNShortId = "9f016cc6-56e2-45d3-8773-1b405fc10d29")]
	public class DLGTEMPLATEEX_MGD : IVanaraMarshaler
	{
		/// <summary>The version number of the extended dialog box template. This member must be set to 1.</summary>
		public ushort dlgVer => 1;

		/// <summary>
		/// Indicates whether a template is an extended dialog box template. If signature is 0xFFFF, this is an extended dialog box template.
		/// In this case, the dlgVer member specifies the template version number. If signature is any value other than 0xFFFF, this is a
		/// standard dialog box template that uses the DLGTEMPLATE and DLGITEMTEMPLATE structures.
		/// </summary>
		public ushort signature = 0xFFFF;

		/// <summary>
		/// The help context identifier for the dialog box window. When the system sends a WM_HELP message, it passes this value in the
		/// wContextId member of the HELPINFO structure.
		/// </summary>
		public uint helpID;

		/// <summary>
		/// The extended windows styles. This member is not used when creating dialog boxes, but applications that use dialog box templates
		/// can use it to create other types of windows. For a list of values, see Extended Window Styles.
		/// </summary>
		public WindowStylesEx exStyle;

		/// <summary>
		/// The style of the dialog box. This member can be a combination of window style values and dialog box style values.
		/// <para>
		/// If style includes the DS_SETFONT or DS_SHELLFONT dialog box style, the DLGTEMPLATEEX header of the extended dialog box template
		/// contains four additional members(pointsize, weight, italic, and typeface) that describe the font to use for the text in the
		/// client area and controls of the dialog box.If possible, the system creates a font according to the values specified in these
		/// members.Then the system sends a WM_SETFONT message to the dialog box and to each control to provide a handle to the font.
		/// </para>
		/// <para>For more information, see Dialog Box Fonts.</para>
		/// </summary>
		public WindowStyles style;

		/// <summary>The x-coordinate, in dialog box units, of the upper-left corner of the dialog box.</summary>
		public short x;

		/// <summary>The y-coordinate, in dialog box units, of the upper-left corner of the dialog box.</summary>
		public short y;

		/// <summary>The width, in dialog box units, of the dialog box.</summary>
		public short cx;

		/// <summary>The height, in dialog box units, of the dialog box.</summary>
		public short cy;

		/// <summary>
		/// A variable-length array of 16-bit elements that identifies a menu resource for the dialog box. If the first element of this array
		/// is 0x0000, the dialog box has no menu and the array has no other elements. If the first element is 0xFFFF, the array has one
		/// additional element that specifies the ordinal value of a menu resource in an executable file. If the first element has any other
		/// value, the system treats the array as a null-terminated Unicode string that specifies the name of a menu resource in an
		/// executable file.
		/// </summary>
		public DlgTemplateId? menu;

		/// <summary>
		/// A variable-length array of 16-bit elements that identifies the window class of the dialog box. If the first element of the array
		/// is 0x0000, the system uses the predefined dialog box class for the dialog box and the array has no other elements. If the first
		/// element is 0xFFFF, the array has one additional element that specifies the ordinal value of a predefined system window class. If
		/// the first element has any other value, the system treats the array as a null-terminated Unicode string that specifies the name of
		/// a registered window class.
		/// </summary>
		public DlgTemplateId? windowClass;

		/// <summary>
		/// The title of the dialog box. If the first element of this array is 0x0000, the dialog box has no title and the array has no other elements.
		/// </summary>
		public string? title;

		/// <summary>
		/// The point size of the font to use for the text in the dialog box and its controls.
		/// <para>This member is present only if the style member specifies DS_SETFONT or DS_SHELLFONT.</para>
		/// </summary>
		public ushort pointsize;

		/// <summary>
		/// The weight of the font. Note that, although this can be any of the values listed for the lfWeight member of the <see cref="LOGFONT"/>
		/// structure, any value that is used will be automatically changed to FW_NORMAL.
		/// <para>This member is present only if the style member specifies DS_SETFONT or DS_SHELLFONT.</para>
		/// </summary>
		public ushort weight = 400;

		/// <summary>
		/// Indicates whether the font is italic. If this value is TRUE, the font is italic.
		/// <para>This member is present only if the style member specifies DS_SETFONT or DS_SHELLFONT.</para>
		/// </summary>
		public BOOLEAN italic;

		/// <summary>
		/// The character set to be used. For more information, see the lfcharset member of <see cref="LOGFONT"/>.
		/// <para>This member is present only if the style member specifies DS_SETFONT or DS_SHELLFONT.</para>
		/// </summary>
		public CharacterSet charset = CharacterSet.DEFAULT_CHARSET;

		/// <summary>
		/// The name of the typeface for the font.
		/// <para>This member is present only if the style member specifies DS_SETFONT or DS_SHELLFONT.</para>
		/// </summary>
		public string? typeface;

		/// <summary>One or more items that define the dimensions and style of the controls in the dialog box.</summary>
		public List<DlgItemTemplateEx> controls = [];

		/// <summary>Makes a button template.</summary>
		/// <param name="text">Contains the initial text of the control.</param>
		/// <param name="id">The control identifier.</param>
		/// <param name="x">
		/// The x-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
		/// upper-left corner of the dialog box's client area.
		/// </param>
		/// <param name="y">
		/// The y-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
		/// upper-left corner of the dialog box's client area.
		/// </param>
		/// <param name="cx">The width, in dialog box units, of the control.</param>
		/// <param name="cy">The height, in dialog box units, of the control.</param>
		/// <param name="style">
		/// The style of the control. This member can be a combination of window style values (such as <c>WS_BORDER</c>) and one or more of
		/// the control style values (such as <c>BS_PUSHBUTTON</c> and <c>ES_LEFT</c>).
		/// </param>
		/// <param name="exstyle">
		/// The extended styles for a window. This member is not used to create controls in dialog boxes, but applications that use dialog
		/// box templates can use it to create other types of windows. For a list of values, see Extended Window Styles.
		/// </param>
		/// <param name="helpID">
		/// The help context identifier for the control. When the system sends a WM_HELP message, it passes the helpID value in the
		/// dwContextId member of the HELPINFO structure.
		/// </param>
		/// <returns>A dialog control item template.</returns>
		public static DlgItemTemplateEx MakeButton(string text, ushort id, short x, short y, short cx = 50, short cy = 14,
			WindowStyles style = WindowStyles.WS_CHILD | WindowStyles.WS_VISIBLE | WindowStyles.WS_TABSTOP | (WindowStyles)ButtonStyle.BS_PUSHBUTTON,
			WindowStylesEx exstyle = 0, uint helpID = 0) =>
			MakeControl(0x0080, text, id, x, y, cx, cy, style, exstyle, helpID);

		/// <summary>Makes a standard control template.</summary>
		/// <param name="classId">
		/// <para>The ordinal value of a predefined system class. The ordinal can be one of the following atom values:</para>
		/// <list type="table">
		/// <item>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </item>
		/// <item>
		/// <description>0x0080</description>
		/// <description>Button</description>
		/// </item>
		/// <item>
		/// <description>0x0081</description>
		/// <description>Edit</description>
		/// </item>
		/// <item>
		/// <description>0x0082</description>
		/// <description>Static</description>
		/// </item>
		/// <item>
		/// <description>0x0083</description>
		/// <description>List box</description>
		/// </item>
		/// <item>
		/// <description>0x0084</description>
		/// <description>Scroll bar</description>
		/// </item>
		/// <item>
		/// <description>0x0085</description>
		/// <description>Combo box</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="text">Contains the initial text of the control.</param>
		/// <param name="id">The control identifier.</param>
		/// <param name="x">
		/// The x-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
		/// upper-left corner of the dialog box's client area.
		/// </param>
		/// <param name="y">
		/// The y-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
		/// upper-left corner of the dialog box's client area.
		/// </param>
		/// <param name="cx">The width, in dialog box units, of the control.</param>
		/// <param name="cy">The height, in dialog box units, of the control.</param>
		/// <param name="style">
		/// The style of the control. This member can be a combination of window style values (such as <c>WS_BORDER</c>) and one or more of
		/// the control style values (such as <c>BS_PUSHBUTTON</c> and <c>ES_LEFT</c>).
		/// </param>
		/// <param name="exstyle">
		/// The extended styles for a window. This member is not used to create controls in dialog boxes, but applications that use dialog
		/// box templates can use it to create other types of windows. For a list of values, see Extended Window Styles.
		/// </param>
		/// <param name="helpID">
		/// The help context identifier for the control. When the system sends a WM_HELP message, it passes the helpID value in the
		/// dwContextId member of the HELPINFO structure.
		/// </param>
		/// <returns>A dialog control item template.</returns>
		public static DlgItemTemplateEx MakeControl(ushort classId, string text, ushort id, short x, short y, short cx, short cy, WindowStyles style,
			WindowStylesEx exstyle, uint helpID) => new()
		{
			x = x,
			y = y,
			cx = cx,
			cy = cy,
			id = id,
			style = style,
			exStyle = exstyle,
			windowClass = new() { id = classId },
			title = new() { name = text },
			helpID = helpID,
		};

		/// <summary>Makes a static control (label) template.</summary>
		/// <param name="text">Contains the initial text of the control.</param>
		/// <param name="id">The control identifier.</param>
		/// <param name="x">
		/// The x-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
		/// upper-left corner of the dialog box's client area.
		/// </param>
		/// <param name="y">
		/// The y-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
		/// upper-left corner of the dialog box's client area.
		/// </param>
		/// <param name="cx">The width, in dialog box units, of the control.</param>
		/// <param name="cy">The height, in dialog box units, of the control.</param>
		/// <param name="style">
		/// The style of the control. This member can be a combination of window style values (such as <c>WS_BORDER</c>) and one or more of
		/// the control style values (such as <c>BS_PUSHBUTTON</c> and <c>ES_LEFT</c>).
		/// </param>
		/// <param name="exstyle">
		/// The extended styles for a window. This member is not used to create controls in dialog boxes, but applications that use dialog
		/// box templates can use it to create other types of windows. For a list of values, see Extended Window Styles.
		/// </param>
		/// <param name="helpID">
		/// The help context identifier for the control. When the system sends a WM_HELP message, it passes the helpID value in the
		/// dwContextId member of the HELPINFO structure.
		/// </param>
		/// <returns>A dialog control item template.</returns>
		public static DlgItemTemplateEx MakeStatic(string text, ushort id, short x, short y, short cx = 50, short cy = 14,
			WindowStyles style = WindowStyles.WS_CHILD | WindowStyles.WS_VISIBLE | (WindowStyles)StaticStyle.SS_LEFT,
			WindowStylesEx exstyle = 0, uint helpID = 0) =>
			MakeControl(0x0082, text, id, x, y, cx, cy, style, exstyle, helpID);

		SIZE_T IVanaraMarshaler.GetNativeSize() => 40;
		SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject)
		{
			if (managedObject is not DLGTEMPLATEEX_MGD dt)
				throw new ArgumentException("Invalid type", nameof(managedObject));
			SafeHGlobalHandle h = new(256);
			NativeMemoryStream buffer = new(h);
			buffer.Write(dt.dlgVer);
			buffer.Write(dt.signature);
			buffer.Write(dt.helpID);
			buffer.Write(dt.exStyle);
			buffer.Write(dt.style);
			buffer.Write((ushort)dt.controls.Count);
			buffer.Write(dt.x);
			buffer.Write(dt.y);
			buffer.Write(dt.cx);
			buffer.Write(dt.cy);
			WriteId(dt.menu);
			WriteId(dt.windowClass);
			WriteString(dt.title);
			buffer.Write(dt.pointsize);
			buffer.Write(dt.weight);
			buffer.Write(dt.italic);
			buffer.Write(dt.charset);
			WriteString(dt.typeface);
			foreach (var c in dt.controls)
				WriteControl(c);
			buffer.Flush();
			System.Diagnostics.Debug.Write(h.DangerousGetHandle().ToHexDumpString(h.Size));
			return h;

			void WriteControl(DlgItemTemplateEx item)
			{
				buffer.Position = Macros.ALIGN_TO_MULTIPLE(buffer.Position, 4);
				buffer.Write(item.helpID);
				buffer.Write(item.exStyle);
				buffer.Write(item.style);
				buffer.Write(item.x);
				buffer.Write(item.y);
				buffer.Write(item.cx);
				buffer.Write(item.cy);
				buffer.Write(item.id);
				WriteId(item.windowClass);
				WriteId(item.title);
				buffer.Write((ushort)(item.creationData?.Length ?? 0));
				if (item.creationData is not null)
					buffer.Write(item.creationData);
			}
			void WriteId(DlgTemplateId? tid)
			{
				if (tid is null)
					buffer.Write((ushort)0);
				else
				{
					if (tid.id.HasValue)
					{
						buffer.Write((ushort)0xFFFF);
						buffer.Write(tid.id.Value);
					}
					else if (tid.name is not null)
						buffer.Write(tid.name, CharSet.Unicode);
					else
						throw new InvalidOperationException();
				}
			}
			void WriteString(string? s)
			{
				if (s is null)
					buffer.Write((ushort)0);
				else
					buffer.Write(s, CharSet.Unicode);
			}
		}
		object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SIZE_T allocatedBytes)
		{
			if (pNativeData == IntPtr.Zero)
				return null;
			if (allocatedBytes < ((IVanaraMarshaler)this).GetNativeSize())
				throw new ArgumentException("Invalid data", nameof(pNativeData));
			NativeMemoryStream buffer = new(pNativeData, allocatedBytes);
			DLGTEMPLATEEX_MGD dt = new();
			buffer.Read<ushort>(); // dlgVer
			dt.signature = buffer.Read<ushort>();
			dt.helpID = buffer.Read<uint>();
			dt.exStyle = buffer.Read<WindowStylesEx>();
			dt.style = buffer.Read<WindowStyles>();
			var cc = buffer.Read<ushort>();
			dt.x = buffer.Read<short>();
			dt.y = buffer.Read<short>();
			dt.cx = buffer.Read<short>();
			dt.cy = buffer.Read<short>();
			dt.menu = ReadId();
			dt.windowClass = ReadId();
			dt.title = ReadString();
			dt.pointsize = buffer.Read<ushort>();
			dt.weight = buffer.Read<ushort>();
			dt.italic = buffer.Read<BOOLEAN>();
			dt.charset = buffer.Read<CharacterSet>();
			dt.typeface = ReadString();
			for (int i = 0; i < cc; i++)
				dt.controls.Add(ReadControl());
			return dt;

			DlgItemTemplateEx ReadControl()
			{
				buffer.Position = Macros.ALIGN_TO_MULTIPLE(buffer.Position, 4);
				DlgItemTemplateEx item = new()
				{
					helpID = buffer.Read<uint>(),
					exStyle = buffer.Read<WindowStylesEx>(),
					style = buffer.Read<WindowStyles>(),
					x = buffer.Read<short>(),
					y = buffer.Read<short>(),
					cx = buffer.Read<short>(),
					cy = buffer.Read<short>(),
					id = buffer.Read<uint>(),
					windowClass = ReadId()!,
					title = ReadId()!
				};
				var c = buffer.Read<ushort>();
				if (c > 0)
					item.creationData = [.. buffer.ReadArray<byte>(c, false)];
				return item;
			}
			DlgTemplateId? ReadId()
			{
				var flag = Peek<ushort>();
				if (flag == 0)
				{
					buffer.Read<ushort>();
					return null;
				}
				if (flag == 0xFFFF)
				{
					buffer.Read<ushort>();
					return new() { id = buffer.Read<ushort>() };
				}
				return new() { name = buffer.Read<string>(CharSet.Unicode) };
			}
			string? ReadString()
			{
				var l = Peek<ushort>();
				if (l == 0) return null;
				return buffer.Read<string>(CharSet.Unicode);
			}
			T Peek<T>() where T : struct => buffer.Pointer.Offset(buffer.Position).ToStructure<T>();
		}
		/// <summary>
		/// Defines the dimensions and style of a control in a dialog box. One or more of these items are added to <see
		/// cref="DLGTEMPLATEEX_MGD.controls"/> to form a standard template for a dialog box.
		/// </summary>
		public class DlgItemTemplateEx
		{
			/// <summary>
			/// The help context identifier for the control. When the system sends a WM_HELP message, it passes the helpID value in the
			/// dwContextId member of the HELPINFO structure.
			/// </summary>
			public uint helpID;

			/// <summary>
			/// The extended styles for a window. This member is not used to create controls in dialog boxes, but applications that use
			/// dialog box templates can use it to create other types of windows. For a list of values, see Extended Window Styles.
			/// </summary>
			public WindowStylesEx exStyle;

			/// <summary>
			/// The style of the control. This member can be a combination of window style values (such as WS_BORDER) and one or more of the
			/// control style values (such as BS_PUSHBUTTON and ES_LEFT).
			/// </summary>
			public WindowStyles style;

			/// <summary>
			/// The x-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
			/// upper-left corner of the dialog box's client area.
			/// </summary>
			public short x;

			/// <summary>
			/// The y-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative to the
			/// upper-left corner of the dialog box's client area.
			/// </summary>
			public short y;

			/// <summary>The width, in dialog box units, of the control.</summary>
			public short cx;

			/// <summary>The height, in dialog box units, of the control.</summary>
			public short cy;

			/// <summary>The control identifier.</summary>
			public uint id;

			/// <summary>
			/// Identifies the window class of the control. If the <see cref="DlgTemplateId.id"/> field is set, it specifies the ordinal
			/// value of a predefined system class. If the <see cref="DlgTemplateId.name"/> is set, it specifies the name of a registered
			/// window class.
			/// <para>The ordinal can be one of the following atom values:</para>
			/// <list type="table">
			/// <item>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </item>
			/// <item>
			/// <description>0x0080</description>
			/// <description>Button</description>
			/// </item>
			/// <item>
			/// <description>0x0081</description>
			/// <description>Edit</description>
			/// </item>
			/// <item>
			/// <description>0x0082</description>
			/// <description>Static</description>
			/// </item>
			/// <item>
			/// <description>0x0083</description>
			/// <description>List box</description>
			/// </item>
			/// <item>
			/// <description>0x0084</description>
			/// <description>Scroll bar</description>
			/// </item>
			/// <item>
			/// <description>0x0085</description>
			/// <description>Combo box</description>
			/// </item>
			/// </list>
			/// </summary>
			public DlgTemplateId windowClass = new();

			/// <summary>The initial text or resource identifier of the control.</summary>
			public DlgTemplateId title = new();

			/// <summary>
			/// This creation data can be of any size and format or <see langword="null"/>. The control's window procedure must be able to
			/// interpret the data. When the system creates the control, it passes a pointer to this data in the lParam parameter of the
			/// WM_CREATE message that it sends to the control.
			/// </summary>
			public byte[]? creationData;
		}
	}
}