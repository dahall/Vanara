using System;
using System.Runtime.InteropServices;
using System.Text;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke
{
	public static partial class User32_Gdi
	{
		/// <summary>
		/// Application-defined callback function used with the <c>CreateDialog</c> and <c>DialogBox</c> families of functions. It processes
		/// messages sent to a modal or modeless dialog box. The <c>DLGPROC</c> type defines a pointer to this callback function. DialogProc
		/// is a placeholder for the application-defined function name.
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
		/// <c>TRUE</c>. Note that you must call <c>SetWindowLong</c> immediately before returning <c>TRUE</c>; doing so earlier may result
		/// in the <c>DWL_MSGRESULT</c> value being overwritten by a nested dialog box message.
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

		/// <summary>
		/// <para>
		/// Creates a modeless dialog box from a dialog box template resource. The <c>CreateDialog</c> macro uses the CreateDialogParam function.
		/// </para>
		/// </summary>
		/// <param name="hInstance">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// A handle to the module which contains the dialog box template. If this parameter is NULL, then the current executable is used.
		/// </para>
		/// </param>
		/// <param name="lpName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The dialog box template. This parameter is either the pointer to a null-terminated character string that specifies the name of
		/// the dialog box template or an integer value that specifies the resource identifier of the dialog box template. If the parameter
		/// specifies a resource identifier, its high-order word must be zero and its low-order word must contain the identifier. You can use
		/// the MAKEINTRESOURCE macro to create this value.
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
		/// WM_INITDIALOG message (and a WM_SETFONT message if the template specifies the DS_SETFONT or <c>DS_SHELLFONT</c> style) to the
		/// dialog box procedure. The function displays the dialog box if the template specifies the <c>WS_VISIBLE</c> style. Finally,
		/// <c>CreateDialog</c> returns the window handle to the dialog box.
		/// </para>
		/// <para>
		/// After <c>CreateDialog</c> returns, the application displays the dialog box (if it is not already displayed) by using the
		/// ShowWindow function. The application destroys the dialog box by using the DestroyWindow function. To support keyboard navigation
		/// and other dialog box functionality, the message loop for the dialog box must call the IsDialogMessage function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating a Modeless Dialog Box.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createdialoga void CreateDialogA( hInstance, lpName,
		// hWndParent, lpDialogFunc );
		[PInvokeData("winuser.h", MSDNShortId = "createdialog")]
		public static void CreateDialog(HINSTANCE hInstance, string lpName, HWND hWndParent, DialogProc lpDialogFunc) => CreateDialogParam(hInstance, lpName, hWndParent, lpDialogFunc);

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
		/// A template that <c>CreateDialogIndirect</c> uses to create the dialog box. A dialog box template consists of a header that
		/// describes the dialog box, followed by one or more additional blocks of data that describe each of the controls in the dialog box.
		/// The template can use either the standard format or the extended format.
		/// </para>
		/// <para>
		/// In a standard template, the header is a DLGTEMPLATE structure followed by additional variable-length arrays. The data for each
		/// control consists of a DLGITEMTEMPLATE structure followed by additional variable-length arrays.
		/// </para>
		/// <para>
		/// In an extended dialog box template, the header uses the DLGTEMPLATEEX format and the control definitions use the
		/// DLGITEMTEMPLATEEX format.
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
		/// function also sends a WM_SETFONT message to the dialog box procedure. The function displays the dialog box if the template
		/// specifies the WS_VISIBLE style. Finally, <c>CreateDialogIndirect</c> returns the window handle to the dialog box.
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
		/// In an extended dialog box template, the DLGTEMPLATEEX header and each of the DLGITEMTEMPLATEEX control definitions must be
		/// aligned on <c>DWORD</c> boundaries. The creation data array, if any, that follows a <c>DLGITEMTEMPLATEEX</c> structure must also
		/// be aligned on a <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
		/// </para>
		/// <para>
		/// All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings. Use the
		/// MultiByteToWideChar function to generate Unicode strings from ANSI strings.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createdialogindirecta void CreateDialogIndirectA(
		// hInstance, lpTemplate, hWndParent, lpDialogFunc );
		[PInvokeData("winuser.h", MSDNShortId = "createdialogindirect")]
		public static void CreateDialogIndirect(HINSTANCE hInstance, IntPtr lpTemplate, HWND hWndParent, DialogProc lpDialogFunc) => CreateDialogIndirectParam(hInstance, lpTemplate, hWndParent, lpDialogFunc);

		/// <summary>
		/// <para>
		/// Creates a modeless dialog box from a dialog box template in memory. Before displaying the dialog box, the function passes an
		/// application-defined value to the dialog box procedure as the lParam parameter of the WM_INITDIALOG message. An application can
		/// use this value to initialize dialog box controls.
		/// </para>
		/// </summary>
		/// <param name="hInstance">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// A handle to the module which contains the dialog box template. If this parameter is NULL, then the current executable is used.
		/// </para>
		/// </param>
		/// <param name="lpTemplate">
		/// <para>Type: <c>LPCDLGTEMPLATE</c></para>
		/// <para>
		/// The template <c>CreateDialogIndirectParam</c> uses to create the dialog box. A dialog box template consists of a header that
		/// describes the dialog box, followed by one or more additional blocks of data that describe each of the controls in the dialog box.
		/// The template can use either the standard format or the extended format.
		/// </para>
		/// <para>
		/// In a standard template, the header is a DLGTEMPLATE structure followed by additional variable-length arrays. The data for each
		/// control consists of a DLGITEMTEMPLATE structure followed by additional variable-length arrays.
		/// </para>
		/// <para>
		/// In an extended dialog box template, the header uses the DLGTEMPLATEEX format and the control definitions use the
		/// DLGITEMTEMPLATEEX format.
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
		/// DS_SETFONT or DS_SHELLFONT style, the function also sends a WM_SETFONT message to the dialog box procedure. The function displays
		/// the dialog box if the template specifies the <c>WS_VISIBLE</c> style. Finally, <c>CreateDialogIndirectParam</c> returns the
		/// window handle to the dialog box.
		/// </para>
		/// <para>
		/// After <c>CreateDialogIndirectParam</c> returns, you can use the ShowWindow function to display the dialog box (if it is not
		/// already visible). To destroy the dialog box, use the DestroyWindow function. To support keyboard navigation and other dialog box
		/// functionality, the message loop for the dialog box must call the IsDialogMessage function.
		/// </para>
		/// <para>
		/// In a standard dialog box template, the DLGTEMPLATE structure and each of the DLGITEMTEMPLATE structures must be aligned on
		/// <c>DWORD</c> boundaries. The creation data array that follows a <c>DLGITEMTEMPLATE</c> structure must also be aligned on a
		/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
		/// </para>
		/// <para>
		/// In an extended dialog box template, the DLGTEMPLATEEX header and each of the DLGITEMTEMPLATEEX control definitions must be
		/// aligned on <c>DWORD</c> boundaries. The creation data array, if any, that follows a <c>DLGITEMTEMPLATEEX</c> structure must also
		/// be aligned on a <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
		/// </para>
		/// <para>All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createdialogindirectparama HWND
		// CreateDialogIndirectParamA( HINSTANCE hInstance, LPCDLGTEMPLATEA lpTemplate, HWND hWndParent, DLGPROC lpDialogFunc, LPARAM
		// dwInitParam );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "createdialogindirectparam")]
		public static extern HWND CreateDialogIndirectParam(HINSTANCE hInstance, IntPtr lpTemplate, HWND hWndParent, DialogProc lpDialogFunc, [Optional] IntPtr dwInitParam);

		/// <summary>
		/// <para>
		/// Creates a modeless dialog box from a dialog box template resource. Before displaying the dialog box, the function passes an
		/// application-defined value to the dialog box procedure as the lParam parameter of the WM_INITDIALOG message. An application can
		/// use this value to initialize dialog box controls.
		/// </para>
		/// </summary>
		/// <param name="hInstance">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// A handle to the module which contains the dialog box template. If this parameter is NULL, then the current executable is used.
		/// </para>
		/// </param>
		/// <param name="lpTemplateName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The dialog box template. This parameter is either the pointer to a null-terminated character string that specifies the name of
		/// the dialog box template or an integer value that specifies the resource identifier of the dialog box template. If the parameter
		/// specifies a resource identifier, its high-order word must be zero and low-order word must contain the identifier. You can use the
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
		/// The <c>CreateDialogParam</c> function uses the CreateWindowEx function to create the dialog box. <c>CreateDialogParam</c> then
		/// sends a WM_INITDIALOG message (and a WM_SETFONT message if the template specifies the DS_SETFONT or DS_SHELLFONT style) to the
		/// dialog box procedure. The function displays the dialog box if the template specifies the <c>WS_VISIBLE</c> style. Finally,
		/// <c>CreateDialogParam</c> returns the window handle of the dialog box.
		/// </para>
		/// <para>
		/// After <c>CreateDialogParam</c> returns, the application displays the dialog box (if it is not already displayed) using the
		/// ShowWindow function. The application destroys the dialog box by using the DestroyWindow function. To support keyboard navigation
		/// and other dialog box functionality, the message loop for the dialog box must call the IsDialogMessage function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createdialogparama HWND CreateDialogParamA( HINSTANCE
		// hInstance, LPCSTR lpTemplateName, HWND hWndParent, DLGPROC lpDialogFunc, LPARAM dwInitParam );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "createdialogparam")]
		public static extern IntPtr CreateDialogParam(HINSTANCE hInstance, string lpTemplateName, HWND hWndParent, DialogProc lpDialogFunc, [Optional] IntPtr dwInitParam);

		/// <summary>
		/// <para>
		/// Calls the default dialog box window procedure to provide default processing for any window messages that a dialog box with a
		/// private window class does not process.
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
		/// processing for the dialog box by forwarding messages to the dialog box procedure and carrying out default processing for any
		/// messages that the dialog box procedure returns as <c>FALSE</c>. Applications that create custom window procedures for their
		/// custom dialog boxes often use <c>DefDlgProc</c> instead of the DefWindowProc function to carry out default message processing.
		/// </para>
		/// <para>
		/// Applications create custom dialog box classes by filling a WNDCLASS structure with appropriate information and registering the
		/// class with the RegisterClass function. Some applications fill the structure by using the GetClassInfo function, specifying the
		/// name of the predefined dialog box. In such cases, the applications modify at least the <c>lpszClassName</c> member before
		/// registering. In all cases, the <c>cbWndExtra</c> member of <c>WNDCLASS</c> for a custom dialog box class must be set to at least <c>DLGWINDOWEXTRA</c>.
		/// </para>
		/// <para>The <c>DefDlgProc</c> function must not be called by a dialog box procedure; doing so results in recursive execution.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-defdlgprocw LRESULT LRESULT DefDlgProcW( HWND hDlg, UINT
		// Msg, WPARAM wParam, LPARAM lParam );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "defdlgproc")]
		public static extern IntPtr DefDlgProc(HWND hDlg, uint Msg, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// <para>
		/// Creates a modal dialog box from a dialog box template resource. <c>DialogBox</c> does not return control until the specified
		/// callback function terminates the modal dialog box by calling the EndDialog function.
		/// </para>
		/// <para><c>DialogBox</c> is implemented as a call to the DialogBoxParam function.</para>
		/// </summary>
		/// <param name="hInstance">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// A handle to the module which contains the dialog box template. If this parameter is NULL, then the current executable is used.
		/// </para>
		/// </param>
		/// <param name="lpTemplate">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The dialog box template. This parameter is either the pointer to a null-terminated character string that specifies the name of
		/// the dialog box template or an integer value that specifies the resource identifier of the dialog box template. If the parameter
		/// specifies a resource identifier, its high-order word must be zero and its low-order word must contain the identifier. You can use
		/// the MAKEINTRESOURCE macro to create this value.
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
		/// message (and a WM_SETFONT message if the template specifies the DS_SETFONT or DS_SHELLFONT style) to the dialog box procedure.
		/// The function displays the dialog box (regardless of whether the template specifies the <c>WS_VISIBLE</c> style), disables the
		/// owner window, and starts its own message loop to retrieve and dispatch messages for the dialog box.
		/// </para>
		/// <para>
		/// When the dialog box procedure calls the EndDialog function, <c>DialogBox</c> destroys the dialog box, ends the message loop,
		/// enables the owner window (if previously enabled), and returns the nResult parameter specified by the dialog box procedure when it
		/// called <c>EndDialog</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating a Modal Dialog Box.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-dialogboxa void DialogBoxA( hInstance, lpTemplate,
		// hWndParent, lpDialogFunc );
		[PInvokeData("winuser.h", MSDNShortId = "dialogbox")]
		public static void DialogBox(HINSTANCE hInstance, string lpTemplate, HWND hWndParent, DialogProc lpDialogFunc) => DialogBoxParam(hInstance, lpTemplate, hWndParent, lpDialogFunc);

		/// <summary>
		/// <para>
		/// Creates a modal dialog box from a dialog box template in memory. <c>DialogBoxIndirect</c> does not return control until the
		/// specified callback function terminates the modal dialog box by calling the EndDialog function.
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
		/// The template that <c>DialogBoxIndirect</c> uses to create the dialog box. A dialog box template consists of a header that
		/// describes the dialog box, followed by one or more additional blocks of data that describe each of the controls in the dialog box.
		/// The template can use either the standard format or the extended format.
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
		/// The <c>DialogBoxIndirect</c> macro uses the CreateWindowEx function to create the dialog box. <c>DialogBoxIndirect</c> then sends
		/// a WM_INITDIALOG message to the dialog box procedure. If the template specifies the DS_SETFONT or DS_SHELLFONT style, the function
		/// also sends a WM_SETFONT message to the dialog box procedure. The function displays the dialog box (regardless of whether the
		/// template specifies the <c>WS_VISIBLE</c> style), disables the owner window, and starts its own message loop to retrieve and
		/// dispatch messages for the dialog box.
		/// </para>
		/// <para>
		/// When the dialog box procedure calls the EndDialog function, <c>DialogBoxIndirect</c> destroys the dialog box, ends the message
		/// loop, enables the owner window (if previously enabled), and returns the nResult parameter specified by the dialog box procedure
		/// when it called <c>EndDialog</c>.
		/// </para>
		/// <para>
		/// In a standard dialog box template, the DLGTEMPLATE structure and each of the DLGITEMTEMPLATE structures must be aligned on
		/// <c>DWORD</c> boundaries. The creation data array that follows a <c>DLGITEMTEMPLATE</c> structure must also be aligned on a
		/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
		/// </para>
		/// <para>
		/// In an extended dialog box template, the DLGTEMPLATEEX header and each of the DLGITEMTEMPLATEEX control definitions must be
		/// aligned on <c>DWORD</c> boundaries. The creation data array, if any, that follows a <c>DLGITEMTEMPLATEEX</c> structure must also
		/// be aligned on a <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
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
		public static void DialogBoxIndirect(HINSTANCE hInstance, IntPtr lpTemplate, HWND hWndParent, DialogProc lpDialogFunc) => DialogBoxIndirectParam(hInstance, lpTemplate, hWndParent, lpDialogFunc);

		/// <summary>
		/// <para>
		/// Creates a modal dialog box from a dialog box template in memory. Before displaying the dialog box, the function passes an
		/// application-defined value to the dialog box procedure as the lParam parameter of the WM_INITDIALOG message. An application can
		/// use this value to initialize dialog box controls.
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
		/// describes the dialog box, followed by one or more additional blocks of data that describe each of the controls in the dialog box.
		/// The template can use either the standard format or the extended format.
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
		/// If the function succeeds, the return value is the nResult parameter specified in the call to the EndDialog function that was used
		/// to terminate the dialog box.
		/// </para>
		/// <para>
		/// If the function fails because the hWndParent parameter is invalid, the return value is zero. The function returns zero in this
		/// case for compatibility with previous versions of Windows. If the function fails for any other reason, the return value is –1. To
		/// get extended error information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>DialogBoxIndirectParam</c> function uses the CreateWindowEx function to create the dialog box.
		/// <c>DialogBoxIndirectParam</c> then sends a WM_INITDIALOG message to the dialog box procedure. If the template specifies the
		/// DS_SETFONT or DS_SHELLFONT style, the function also sends a WM_SETFONT message to the dialog box procedure. The function displays
		/// the dialog box (regardless of whether the template specifies the <c>WS_VISIBLE</c> style), disables the owner window, and starts
		/// its own message loop to retrieve and dispatch messages for the dialog box.
		/// </para>
		/// <para>
		/// When the dialog box procedure calls the EndDialog function, <c>DialogBoxIndirectParam</c> destroys the dialog box, ends the
		/// message loop, enables the owner window (if previously enabled), and returns the nResult parameter specified by the dialog box
		/// procedure when it called <c>EndDialog</c>.
		/// </para>
		/// <para>
		/// In a standard dialog box template, the DLGTEMPLATE structure and each of the DLGITEMTEMPLATE structures must be aligned on
		/// <c>DWORD</c> boundaries. The creation data array that follows a <c>DLGITEMTEMPLATE</c> structure must also be aligned on a
		/// <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
		/// </para>
		/// <para>
		/// In an extended dialog box template, the DLGTEMPLATEEX header and each of the DLGITEMTEMPLATEEX control definitions must be
		/// aligned on <c>DWORD</c> boundaries. The creation data array, if any, that follows a <c>DLGITEMTEMPLATEEX</c> structure must also
		/// be aligned on a <c>DWORD</c> boundary. All of the other variable-length arrays in the template must be aligned on <c>WORD</c> boundaries.
		/// </para>
		/// <para>All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-dialogboxindirectparama INT_PTR DialogBoxIndirectParamA(
		// HINSTANCE hInstance, LPCDLGTEMPLATEA hDialogTemplate, HWND hWndParent, DLGPROC lpDialogFunc, LPARAM dwInitParam );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "dialogboxindirectparam")]
		public static extern IntPtr DialogBoxIndirectParam(HINSTANCE hInstance, IntPtr hDialogTemplate, HWND hWndParent, DialogProc lpDialogFunc, [Optional] IntPtr dwInitParam);

		/// <summary>
		/// <para>
		/// Creates a modal dialog box from a dialog box template resource. Before displaying the dialog box, the function passes an
		/// application-defined value to the dialog box procedure as the lParam parameter of the WM_INITDIALOG message. An application can
		/// use this value to initialize dialog box controls.
		/// </para>
		/// </summary>
		/// <param name="hInstance">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// A handle to the module which contains the dialog box template. If this parameter is NULL, then the current executable is used.
		/// </para>
		/// </param>
		/// <param name="lpTemplateName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The dialog box template. This parameter is either the pointer to a null-terminated character string that specifies the name of
		/// the dialog box template or an integer value that specifies the resource identifier of the dialog box template. If the parameter
		/// specifies a resource identifier, its high-order word must be zero and its low-order word must contain the identifier. You can use
		/// the MAKEINTRESOURCE macro to create this value.
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
		/// If the function succeeds, the return value is the value of the nResult parameter specified in the call to the EndDialog function
		/// used to terminate the dialog box.
		/// </para>
		/// <para>
		/// If the function fails because the hWndParent parameter is invalid, the return value is zero. The function returns zero in this
		/// case for compatibility with previous versions of Windows. If the function fails for any other reason, the return value is –1. To
		/// get extended error information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>DialogBoxParam</c> function uses the CreateWindowEx function to create the dialog box. <c>DialogBoxParam</c> then sends a
		/// WM_INITDIALOG message (and a WM_SETFONT message if the template specifies the DS_SETFONT or DS_SHELLFONT style) to the dialog box
		/// procedure. The function displays the dialog box (regardless of whether the template specifies the <c>WS_VISIBLE</c> style),
		/// disables the owner window, and starts its own message loop to retrieve and dispatch messages for the dialog box.
		/// </para>
		/// <para>
		/// When the dialog box procedure calls the EndDialog function, <c>DialogBoxParam</c> destroys the dialog box, ends the message loop,
		/// enables the owner window (if previously enabled), and returns the nResult parameter specified by the dialog box procedure when it
		/// called <c>EndDialog</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-dialogboxparama INT_PTR DialogBoxParamA( HINSTANCE
		// hInstance, LPCSTR lpTemplateName, HWND hWndParent, DLGPROC lpDialogFunc, LPARAM dwInitParam );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "dialogboxparam")]
		public static extern IntPtr DialogBoxParam(HINSTANCE hInstance, string lpTemplateName, HWND hWndParent, DialogProc lpDialogFunc, [Optional] IntPtr dwInitParam);

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
		/// using the <c>EndDialog</c> function. An application calls <c>EndDialog</c> from within the dialog box procedure; the function
		/// must not be used for any other purpose.
		/// </para>
		/// <para>
		/// A dialog box procedure can call <c>EndDialog</c> at any time, even during the processing of the WM_INITDIALOG message. If your
		/// application calls the function while <c>WM_INITDIALOG</c> is being processed, the dialog box is destroyed before it is shown and
		/// before the input focus is set.
		/// </para>
		/// <para>
		/// <c>EndDialog</c> does not destroy the dialog box immediately. Instead, it sets a flag and allows the dialog box procedure to
		/// return control to the system. The system checks the flag before attempting to retrieve the next message from the application
		/// queue. If the flag is set, the system ends the message loop, destroys the dialog box, and uses the value in nResult as the return
		/// value from the function that created the dialog box.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enddialog BOOL EndDialog( HWND hDlg, INT_PTR nResult );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "enddialog")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EndDialog(HWND hDlg, IntPtr nResult);

		/// <summary>
		/// <para>
		/// Retrieves the system's dialog base units, which are the average width and height of characters in the system font. For dialog
		/// boxes that use the system font, you can use these values to convert between dialog template units, as specified in dialog box
		/// templates, and pixels. For dialog boxes that do not use the system font, the conversion from dialog template units to pixels
		/// depends on the font used by the dialog box.
		/// </para>
		/// <para>
		/// For either type of dialog box, it is easier to use the MapDialogRect function to perform the conversion. <c>MapDialogRect</c>
		/// takes the font into account and correctly converts a rectangle from dialog template units into pixels.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// The function returns the dialog base units. The low-order word of the return value contains the horizontal dialog box base unit,
		/// and the high-order word contains the vertical dialog box base unit.
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
		/// For a dialog box that does not use the system font, the base units are the average width and height, in pixels, of the characters
		/// in the dialog's font. You can use the GetTextMetrics and GetTextExtentPoint32 functions to calculate these values for a selected
		/// font. However, by using the MapDialogRect function, you can avoid errors that might result if your calculations differ from those
		/// performed by the system.
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
		public static extern long GetDialogBaseUnits();

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
		/// If the function fails, the return value is zero. An invalid value for the hwndCtl parameter, for example, will cause the function
		/// to fail. To get extended error information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>GetDlgCtrlID</c> accepts child window handles as well as handles of controls in dialog boxes. An application sets the
		/// identifier for a child window when it creates the window by assigning the identifier value to the hmenu parameter when calling
		/// the CreateWindow or CreateWindowEx function.
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
		public static extern int GetDlgCtrlID(HWND hWnd);

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
		public static extern IntPtr GetDlgItem(HWND hDlg, int nIDDlgItem);

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
		/// If the function succeeds, the variable pointed to by lpTranslated is set to <c>TRUE</c>, and the return value is the translated
		/// value of the control text.
		/// </para>
		/// <para>
		/// If the function fails, the variable pointed to by lpTranslated is set to <c>FALSE</c>, and the return value is zero. Note that,
		/// because zero is a possible translated value, a return value of zero does not by itself indicate failure.
		/// </para>
		/// <para>If lpTranslated is <c>NULL</c>, the function returns no information about success or failure.</para>
		/// <para>
		/// Note that, if the bSigned parameter is <c>TRUE</c> and there is a minus sign (–) at the beginning of the text,
		/// <c>GetDlgItemInt</c> translates the text into a signed integer value. Otherwise, the function creates an unsigned integer value.
		/// To obtain the proper value in this case, cast the return value to an <c>int</c> type.
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdlgitemint UINT GetDlgItemInt( HWND hDlg, int
		// nIDDlgItem, BOOL *lpTranslated, BOOL bSigned );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getdlgitemint")]
		public static extern uint GetDlgItemInt(HWND hDlg, int nIDDlgItem, [MarshalAs(UnmanagedType.Bool)] out bool lpTranslated, [MarshalAs(UnmanagedType.Bool)] bool bSigned);

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
		/// <para>Type: <c>LPTSTR</c></para>
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
		/// <para>
		/// If the string is as long or longer than the buffer, the buffer will contain the truncated string with a terminating null character.
		/// </para>
		/// <para>The <c>GetDlgItemText</c> function sends a WM_GETTEXT message to the control.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating a Modal Dialog Box.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdlgitemtexta UINT GetDlgItemTextA( HWND hDlg, int
		// nIDDlgItem, LPSTR lpString, int cchMax );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "getdlgitemtext")]
		public static extern uint GetDlgItemText(HWND hDlg, int nIDDlgItem, StringBuilder lpString, int cchMax);

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
		/// A handle to the control to be used as the starting point for the search. If this parameter is <c>NULL</c>, the function uses the
		/// last (or first) control in the dialog box as the starting point for the search.
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
		/// template. The first control in the group must have the WS_GROUP style; all other controls in the group must have been
		/// consecutively created and must not have the <c>WS_GROUP</c> style.
		/// </para>
		/// <para>
		/// When searching for the previous control, the function returns the first control it locates that is visible and not disabled. If
		/// the control specified by hCtl has the <c>WS_GROUP</c> style, the function temporarily reverses the search to locate the first
		/// control having the <c>WS_GROUP</c> style, then resumes the search in the original direction, returning the first control it
		/// locates that is visible and not disabled, or returning hCtl if no such control is found.
		/// </para>
		/// <para>
		/// When searching for the next control, the function returns the first control it locates that is visible, not disabled, and does
		/// not have the <c>WS_GROUP</c> style. If it encounters a control having the <c>WS_GROUP</c> style, the function reverses the
		/// search, locates the first control having the <c>WS_GROUP</c> style, and returns this control if it is visible and not disabled.
		/// Otherwise, the function resumes the search in the original direction and returns the first control it locates that is visible and
		/// not disabled, or returns hCtl if no such control is found.
		/// </para>
		/// <para>
		/// If the search for the next control in the group encounters a window with the <c>WS_EX_CONTROLPARENT</c> style, the system
		/// recursively searches the window's children.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getnextdlggroupitem HWND GetNextDlgGroupItem( HWND hDlg,
		// HWND hCtl, BOOL bPrevious );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getnextdlggroupitem")]
		public static extern IntPtr GetNextDlgGroupItem(HWND hDlg, HWND hCtl, [MarshalAs(UnmanagedType.Bool)] bool bPrevious);

		/// <summary>
		/// <para>Retrieves a handle to the first control that has the WS_TABSTOP style that precedes (or follows) the specified control.</para>
		/// </summary>
		/// <param name="hDlg">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the dialog box to be searched.</para>
		/// </param>
		/// <param name="hCtl">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the control to be used as the starting point for the search. If this parameter is <c>NULL</c>, the function fails.
		/// </para>
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
		/// The <c>GetNextDlgTabItem</c> function searches controls in the order (or reverse order) they were created in the dialog box
		/// template. The function returns the first control it locates that is visible, not disabled, and has the WS_TABSTOP style. If no
		/// such control exists, the function returns hCtl.
		/// </para>
		/// <para>
		/// If the search for the next control with the <c>WS_TABSTOP</c> style encounters a window with the <c>WS_EX_CONTROLPARENT</c>
		/// style, the system recursively searches the window's children.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getnextdlgtabitem HWND GetNextDlgTabItem( HWND hDlg, HWND
		// hCtl, BOOL bPrevious );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getnextdlgtabitem")]
		public static extern IntPtr GetNextDlgTabItem(HWND hDlg, HWND hCtl, [MarshalAs(UnmanagedType.Bool)] bool bPrevious);

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
		/// corresponding dialog box. For example, the TAB key, when pressed, selects the next control or group of controls, and the DOWN
		/// ARROW key, when pressed, selects the next control in a group.
		/// </para>
		/// <para>
		/// Because the <c>IsDialogMessage</c> function performs all necessary translating and dispatching of messages, a message processed
		/// by <c>IsDialogMessage</c> must not be passed to the TranslateMessage or DispatchMessage function.
		/// </para>
		/// <para><c>IsDialogMessage</c> sends WM_GETDLGCODE messages to the dialog box procedure to determine which keys should be processed.</para>
		/// <para>
		/// <c>IsDialogMessage</c> can send DM_GETDEFID and DM_SETDEFID messages to the window. These messages are defined in the Winuser.h
		/// header file as WM_USER and <c>WM_USER</c> + 1, so conflicts are possible with application-defined messages having the same values.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-isdialogmessagea BOOL IsDialogMessageA( HWND hDlg, LPMSG
		// lpMsg );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "isdialogmessage")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsDialogMessage(HWND hDlg, ref MSG lpMsg);

		/// <summary>
		/// <para>
		/// Converts the specified dialog box units to screen units (pixels). The function replaces the coordinates in the specified RECT
		/// structure with the converted coordinates, which allows the structure to be used to create a dialog box or position a control
		/// within a dialog box.
		/// </para>
		/// </summary>
		/// <param name="hDlg">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to a dialog box. This function accepts only handles returned by one of the dialog box creation functions; handles for
		/// other windows are not valid.
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
		/// The <c>MapDialogRect</c> function assumes that the initial coordinates in the RECT structure represent dialog box units. To
		/// convert these coordinates from dialog box units to pixels, the function retrieves the current horizontal and vertical base units
		/// for the dialog box, then applies the following formulas:
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
		public static extern bool MapDialogRect(HWND hDlg, [MarshalAs(UnmanagedType.LPStruct)] RECT lpRect);

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
		/// <para>
		/// Using <c>SendDlgItemMessage</c> is identical to retrieving a handle to the specified control and calling the SendMessage function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating a Modeless Dialog Box.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-senddlgitemmessagea LRESULT SendDlgItemMessageA( HWND
		// hDlg, int nIDDlgItem, UINT Msg, WPARAM wParam, LPARAM lParam );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "senddlgitemmessage")]
		public static extern IntPtr SendDlgItemMessage(HWND hDlg, int nIDDlgItem, uint Msg, IntPtr wParam, IntPtr lParam);

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
		/// Indicates whether the uValue parameter is signed or unsigned. If this parameter is <c>TRUE</c>, uValue is signed. If this
		/// parameter is <c>TRUE</c> and uValue is less than zero, a minus sign is placed before the first digit in the string. If this
		/// parameter is <c>FALSE</c>, uValue is unsigned.
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setdlgitemint BOOL SetDlgItemInt( HWND hDlg, int
		// nIDDlgItem, UINT uValue, BOOL bSigned );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "setdlgitemint")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetDlgItemInt(HWND hDlg, int nIDDlgItem, uint uValue, [MarshalAs(UnmanagedType.Bool)] bool bSigned);

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
		public static extern bool SetDlgItemText(HWND hDlg, int nIDDlgItem, string lpString);

		/// <summary>
		/// <para>
		/// Defines the dimensions and style of a control in a dialog box. One or more of these structures are combined with a DLGTEMPLATE
		/// structure to form a standard template for a dialog box.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// In a standard template for a dialog box, the <c>DLGITEMTEMPLATE</c> structure is always immediately followed by three
		/// variable-length arrays specifying the class, title, and creation data for the control. Each array consists of one or more 16-bit elements.
		/// </para>
		/// <para>
		/// Each <c>DLGITEMTEMPLATE</c> structure in the template must be aligned on a <c>DWORD</c> boundary. The class and title arrays must
		/// be aligned on <c>WORD</c> boundaries. The creation data array must be aligned on a <c>WORD</c> boundary.
		/// </para>
		/// <para>
		/// Immediately following each <c>DLGITEMTEMPLATE</c> structure is a class array that specifies the window class of the control. If
		/// the first element of this array is any value other than 0xFFFF, the system treats the array as a null-terminated Unicode string
		/// that specifies the name of a registered window class. If the first element is 0xFFFF, the array has one additional element that
		/// specifies the ordinal value of a predefined system class. The ordinal can be one of the following atom values.
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
		/// Following the class array is a title array that contains the initial text or resource identifier of the control. If the first
		/// element of this array is 0xFFFF, the array has one additional element that specifies an ordinal value of a resource, such as an
		/// icon, in an executable file. You can use a resource identifier for controls, such as static icon controls, that load and display
		/// an icon or other resource rather than text. If the first element is any value other than 0xFFFF, the system treats the array as a
		/// null-terminated Unicode string that specifies the initial text.
		/// </para>
		/// <para>
		/// The creation data array begins at the next <c>WORD</c> boundary after the title array. This creation data can be of any size and
		/// format. If the first word of the creation data array is nonzero, it indicates the size, in bytes, of the creation data (including
		/// the size word). The control's window procedure must be able to interpret the data. When the system creates the control, it passes
		/// a pointer to this data in the lParam parameter of the WM_CREATE message that it sends to the control.
		/// </para>
		/// <para>
		/// If you specify character strings in the class and title arrays, you must use Unicode strings. Use the MultiByteToWideChar
		/// function to generate Unicode strings from ANSI strings.
		/// </para>
		/// <para>
		/// The <c>x</c>, <c>y</c>, <c>cx</c>, and <c>cy</c> members specify values in dialog box units. You can convert these values to
		/// screen units (pixels) by using the MapDialogRect function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-dlgitemtemplate typedef struct DLGITEMTEMPLATE { DWORD
		// style; DWORD dwExtendedStyle; short x; short y; short cx; short cy; WORD id; };
		[PInvokeData("winuser.h", MSDNShortId = "dlgitemtemplate")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct DLGITEMTEMPLATE
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The style of the control. This member can be a combination of window style values (such as <c>WS_BORDER</c>) and one or more
			/// of the control style values (such as <c>BS_PUSHBUTTON</c> and <c>ES_LEFT</c>).
			/// </para>
			/// </summary>
			public uint style;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The extended styles for a window. This member is not used to create controls in dialog boxes, but applications that use
			/// dialog box templates can use it to create other types of windows. For a list of values, see Extended Window Styles.
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
		/// specifies the number of controls in the dialog box and therefore specifies the number of subsequent DLGITEMTEMPLATE structures in
		/// the template.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// In a standard template for a dialog box, the <c>DLGTEMPLATE</c> structure is always immediately followed by three variable-length
		/// arrays that specify the menu, class, and title for the dialog box. When the DS_SETFONT style is specified, these arrays are also
		/// followed by a 16-bit value specifying point size and another variable-length array specifying a typeface name. Each array
		/// consists of one or more 16-bit elements. The menu, class, title, and font arrays must be aligned on <c>WORD</c> boundaries.
		/// </para>
		/// <para>
		/// Immediately following the <c>DLGTEMPLATE</c> structure is a menu array that identifies a menu resource for the dialog box. If the
		/// first element of this array is 0x0000, the dialog box has no menu and the array has no other elements. If the first element is
		/// 0xFFFF, the array has one additional element that specifies the ordinal value of a menu resource in an executable file. If the
		/// first element has any other value, the system treats the array as a null-terminated Unicode string that specifies the name of a
		/// menu resource in an executable file.
		/// </para>
		/// <para>
		/// Following the menu array is a class array that identifies the window class of the control. If the first element of the array is
		/// 0x0000, the system uses the predefined dialog box class for the dialog box and the array has no other elements. If the first
		/// element is 0xFFFF, the array has one additional element that specifies the ordinal value of a predefined system window class. If
		/// the first element has any other value, the system treats the array as a null-terminated Unicode string that specifies the name of
		/// a registered window class.
		/// </para>
		/// <para>
		/// Following the class array is a title array that specifies a null-terminated Unicode string that contains the title of the dialog
		/// box. If the first element of this array is 0x0000, the dialog box has no title and the array has no other elements.
		/// </para>
		/// <para>
		/// The 16-bit point size value and the typeface array follow the title array, but only if the <c>style</c> member specifies the
		/// DS_SETFONT style. The point size value specifies the point size of the font to use for the text in the dialog box and its
		/// controls. The typeface array is a null-terminated Unicode string specifying the name of the typeface for the font. When these
		/// values are specified, the system creates a font having the specified size and typeface (if possible) and sends a WM_SETFONT
		/// message to the dialog box procedure and the control window procedures as it creates the dialog box and controls.
		/// </para>
		/// <para>
		/// Following the <c>DLGTEMPLATE</c> header in a standard dialog box template are one or more DLGITEMTEMPLATE structures that define
		/// the dimensions and style of the controls in the dialog box. The <c>cdit</c> member specifies the number of <c>DLGITEMTEMPLATE</c>
		/// structures in the template. These <c>DLGITEMTEMPLATE</c> structures must be aligned on <c>DWORD</c> boundaries.
		/// </para>
		/// <para>If you specify character strings in the menu, class, title, or typeface arrays, you must use Unicode strings.</para>
		/// <para>
		/// The <c>x</c>, <c>y</c>, <c>cx</c>, and <c>cy</c> members specify values in dialog box units. You can convert these values to
		/// screen units (pixels) by using the MapDialogRect function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-dlgtemplate typedef struct DLGTEMPLATE { DWORD style;
		// DWORD dwExtendedStyle; WORD cdit; short x; short y; short cx; short cy; };
		[PInvokeData("winuser.h", MSDNShortId = "dlgtemplate")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
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
			/// specifying the font to use for text in the client area and controls of the dialog box. The font data begins on the
			/// <c>WORD</c> boundary that follows the title array. The font data specifies a 16-bit point size value and a Unicode font name
			/// string. If possible, the system creates a font according to the specified values. Then the system sends a WM_SETFONT message
			/// to the dialog box and to each control to provide a handle to the font. If <c>DS_SETFONT</c> is not specified, the dialog box
			/// template does not include the font data.
			/// </para>
			/// <para>The <c>DS_SHELLFONT</c> style is not supported in the <c>DLGTEMPLATE</c> header.</para>
			/// </summary>
			public uint style;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The extended styles for a window. This member is not used to create dialog boxes, but applications that use dialog box
			/// templates can use it to create other types of windows. For a list of values, see Extended Window Styles.
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
	}
}