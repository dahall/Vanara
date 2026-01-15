namespace Vanara.PInvoke;

/// <summary>Items from the ComDlg32.dll</summary>
public static partial class ComDlg32
{
	private const string Lib_ComDlg32 = "comdlg32.dll";

	/// <summary>
	/// A Color dialog box sends the COLOROKSTRING registered message to your hook procedure, CCHookProc, when the user selects a color
	/// and clicks the OK button. The hook procedure can accept the color and allow the dialog box to close, or reject the color and
	/// force the dialog box to remain open.
	/// </summary>
	public const string COLOROKSTRING = "commdlg_ColorOK";

	/// <summary>
	/// An Open or Save As dialog box sends the FILEOKSTRING registered message to your hook procedure, OFNHookProc, when the user
	/// specifies a file name and clicks the OK button. The hook procedure can accept the file name and allow the dialog box to close,
	/// or reject the file name and force the dialog box to remain open.
	/// </summary>
	public const string FILEOKSTRING  = "commdlg_FileNameOK";

	/// <summary>
	/// A Find or Replace dialog box sends the FINDMSGSTRING registered message to the window procedure of its owner window when the
	/// user clicks the Find Next, Replace, or Replace All button, or closes the dialog box.
	/// </summary>
	public const string FINDMSGSTRING = "commdlg_FindReplace";

	/// <summary>
	/// A common dialog box sends the HELPMSGSTRING registered message to the window procedure of its owner window when the user clicks
	/// the Help button.
	/// </summary>
	public const string HELPMSGSTRING = "commdlg_help";

	/// <summary>
	/// An Open or Save As dialog box sends the LBSELCHSTRING registered message to your hook procedure when the selection changes in
	/// any of the list boxes or combo boxes of the dialog box.
	/// </summary>
	public const string LBSELCHSTRING = "commdlg_LBSelChangedNotify";

	/// <summary>
	/// The hook procedure of a Color dialog box, CCHookProc, can send the SETRGBSTRING registered message to the dialog box to set the
	/// current color selection.
	/// </summary>
	public const string SETRGBSTRING  = "commdlg_SetRGBColor";

	/// <summary>
	/// An Open or Save As dialog box sends the SHAREVISTRING registered message to your hook procedure, OFNHookProc, if a sharing
	/// violation occurs for the selected file when the user clicks the OK button.
	/// </summary>
	public const string SHAREVISTRING = "commdlg_ShareViolation";

	/// <summary>
	/// <para>
	/// Receives messages or notifications intended for the default dialog box procedure of the <c>Color</c> dialog box. This is an
	/// application-defined or library-defined callback function that is used with the ChooseColor function.
	/// </para>
	/// <para>
	/// The <c>LPCCHOOKPROC</c> type defines a pointer to this callback function. CCHookProc is a placeholder for the
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="Arg1">A handle to the <c>Color</c> dialog box for which the message is intended.</param>
	/// <param name="Arg2">The identifier of the message being received.</param>
	/// <param name="Arg3">Additional information about the message. The exact meaning depends on the value of the Arg2 parameter.</param>
	/// <param name="Arg4">
	/// Additional information about the message. The exact meaning depends on the value of the Arg2 parameter. If the Arg2 parameter
	/// indicates the WM_INITDIALOG message, then Arg4 is a pointer to a CHOOSECOLOR structure containing the values specified when the
	/// dialog was created.
	/// </param>
	/// <returns>
	/// <para>If the hook procedure returns zero, the default dialog box procedure processes the message.</para>
	/// <para>If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When you use the ChooseColor function to create a <c>Color</c> dialog box, you can provide a CCHookProc hook procedure to
	/// process messages or notifications intended for the dialog box procedure. To enable the hook procedure, use the CHOOSECOLOR
	/// structure that you passed to the dialog creation function. Specify the address of the hook procedure in the <c>lpfnHook</c>
	/// member and specify the <c>CC_ENABLEHOOK</c> flag in the <c>Flags</c> member.
	/// </para>
	/// <para>
	/// The default dialog box procedure processes the WM_INITDIALOG message before passing it to the hook procedure. For all other
	/// messages, the hook procedure receives the message first. Then, the return value of the hook procedure determines whether the
	/// default dialog procedure processes the message or ignores it.
	/// </para>
	/// <para>
	/// If the hook procedure processes the WM_CTLCOLORDLG message, it must return a valid brush handle to painting the background of
	/// the dialog box. In general, if the hook procedure processes any <c>WM_CTLCOLOR*</c> message, it must return a valid brush handle
	/// to painting the background of the specified control.
	/// </para>
	/// <para>
	/// Do not call the EndDialog function from the hook procedure. Instead, the hook procedure can call the PostMessage function to
	/// post a WM_COMMAND message with the <c>IDABORT</c> value to the dialog box procedure. Posting <c>IDABORT</c> closes the dialog
	/// box and causes the dialog box function to return <c>FALSE</c>. If you need to know why the hook procedure closed the dialog box,
	/// you must provide your own communication mechanism between the hook procedure and your application.
	/// </para>
	/// <para>
	/// You can subclass the standard controls of a common dialog box. However, the dialog box procedure may also subclass the controls.
	/// Because of this, you should subclass controls when your hook procedure processes the WM_INITDIALOG message. This ensures that
	/// your subclass procedure receives the control-specific messages before the subclass procedure set by the dialog box procedure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpcchookproc LPCCHOOKPROC Lpcchookproc; UINT_PTR
	// Lpcchookproc( HWND Arg1, UINT Arg2, WPARAM Arg3, LPARAM Arg4 ) {...}
	[PInvokeData("commdlg.h", MSDNShortId = "NC:commdlg.LPCCHOOKPROC")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate IntPtr LPCCHOOKPROC(HWND Arg1, uint Arg2, IntPtr Arg3, IntPtr Arg4);

	/// <summary>
	/// <para>
	/// Receives messages or notifications intended for the default dialog box procedure of the <c>Font</c> dialog box. This is an
	/// application-defined or library-defined callback procedure that is used with the ChooseFont function.
	/// </para>
	/// <para>
	/// The <c>LPCFHOOKPROC</c> type defines a pointer to this callback function. CFHookProc is a placeholder for the
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="Arg1">A handle to the <c>Font</c> dialog box for which the message is intended.</param>
	/// <param name="Arg2">The identifier of the message being received.</param>
	/// <param name="Arg3">Additional information about the message. The exact meaning depends on the value of the Arg2 parameter.</param>
	/// <param name="Arg4">
	/// Additional information about the message. The exact meaning depends on the value of the Arg2 parameter. If the Arg2 parameter
	/// indicates the WM_INITDIALOG message, Arg4 is a pointer to a CHOOSEFONT structure containing the values specified when the dialog
	/// box was created.
	/// </param>
	/// <returns>
	/// <para>If the hook procedure returns zero, the default dialog box procedure processes the message.</para>
	/// <para>If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When you use the ChooseFont function to create a <c>Font</c> dialog box, you can provide a CFHookProc hook procedure to process
	/// messages or notifications intended for the dialog box procedure. To enable the hook procedure, use the <c>CHOOSEFONT</c>
	/// structure that you passed to the dialog creation function. Specify the address of the hook procedure in the <c>lpfnHook</c>
	/// member and specify the <c>CF_ENABLEHOOK</c> flag in the <c>Flags</c> member.
	/// </para>
	/// <para>
	/// The default dialog box procedure processes the WM_INITDIALOG message before passing it to the hook procedure. For all other
	/// messages, the hook procedure receives the message first. The return value of the hook procedure determines whether the default
	/// dialog box procedure processes the message or ignores it.
	/// </para>
	/// <para>
	/// If the hook procedure processes the WM_CTLCOLORDLG message, it must return a valid brush handle to paint the background of the
	/// dialog box. In general, if the hook procedure processes any <c>WM_CTLCOLOR*</c> message, it must return a valid brush handle to
	/// paint the background of the specified control.
	/// </para>
	/// <para>
	/// Do not call the EndDialog function from the hook procedure. Instead, the hook procedure can call the PostMessage function to
	/// post a WM_COMMAND message with the <c>IDABORT</c> value to the dialog box procedure. Posting <c>IDABORT</c> closes the dialog
	/// box and causes the dialog box function to return <c>FALSE</c>. If you need to know why the hook procedure closed the dialog box,
	/// you must provide your own communication mechanism between the hook procedure and your application.
	/// </para>
	/// <para>
	/// You can subclass the standard controls of a common dialog box. However, the dialog box procedure may also subclass the controls.
	/// Because of this, you should subclass controls when your hook procedure processes the WM_INITDIALOG message. This ensures that
	/// your subclass procedure receives the control-specific messages before the subclass procedure set by the dialog box procedure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpcfhookproc LPCFHOOKPROC Lpcfhookproc; UINT_PTR
	// Lpcfhookproc( HWND Arg1, UINT Arg2, WPARAM Arg3, LPARAM Arg4 ) {...}
	[PInvokeData("commdlg.h", MSDNShortId = "NC:commdlg.LPCFHOOKPROC")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate IntPtr LPCFHOOKPROC(HWND Arg1, uint Arg2, IntPtr Arg3, IntPtr Arg4);

	/// <summary>
	/// <para>
	/// Receives messages or notifications intended for the default dialog box procedure of the <c>Find</c> or <c>Replace</c> dialog
	/// box. The FRHookProc hook procedure is an application-defined or library-defined callback function that is used with the FindText
	/// or ReplaceText function.
	/// </para>
	/// <para>
	/// The <c>LPFRHOOKPROC</c> type defines a pointer to this callback function. FRHookProc is a placeholder for the
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="Arg1">A handle to the <c>Find</c> or <c>Replace</c> dialog box for which the message is intended.</param>
	/// <param name="Arg2">The identifier of the message being received.</param>
	/// <param name="Arg3">Additional information about the message. The exact meaning depends on the value of the Arg2 parameter.</param>
	/// <param name="Arg4">
	/// <para>Additional information about the message. The exact meaning depends on the value of the Arg2 parameter.</para>
	/// <para>
	/// If the Arg2 parameter indicates the WM_INITDIALOG message, Arg4 is a pointer to a FINDREPLACE structure containing the values
	/// specified when the dialog box was created.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the hook procedure returns zero, the default dialog box procedure processes the message.</para>
	/// <para>If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When you use the FindText or ReplaceText functions to create a <c>Find</c> or <c>Replace</c> dialog box, you can provide an
	/// FRHookProc hook procedure to process messages or notifications intended for the dialog box procedure. To enable the hook
	/// procedure, use the FINDREPLACE structure that you passed to the dialog creation function. Specify the address of the hook
	/// procedure in the <c>lpfnHook</c> member and specify the <c>FR_ENABLEHOOK</c> flag in the <c>Flags</c> member.
	/// </para>
	/// <para>
	/// The default dialog box procedure processes the WM_INITDIALOG message before passing it to the hook procedure. For all other
	/// messages, the hook procedure receives the message first. Then, the return value of the hook procedure determines whether the
	/// default dialog procedure processes the message or ignores it.
	/// </para>
	/// <para>
	/// If the hook procedure processes the WM_CTLCOLORDLG message, it must return a valid brush handle for painting the background of
	/// the dialog box. In general, if the hook procedure processes any <c>WM_CTLCOLOR*</c> message, it must return a valid brush handle
	/// for painting the background of the specified control.
	/// </para>
	/// <para>
	/// Do not call the EndDialog function from the hook procedure. Instead, the hook procedure can call the PostMessage function to
	/// post a WM_COMMAND message with the <c>IDABORT</c> value to the dialog box procedure. Posting <c>IDABORT</c> closes the dialog
	/// box and causes the dialog box function to return <c>FALSE</c>. If you need to know why the hook procedure closed the dialog box,
	/// you must provide your own communication mechanism between the hook procedure and your application.
	/// </para>
	/// <para>
	/// You can subclass the standard controls of a common dialog box. However, the dialog box procedure may also subclass the controls.
	/// Because of this, you should subclass controls when your hook procedure processes the WM_INITDIALOG message. This ensures that
	/// your subclass procedure receives the control-specific messages before the subclass procedure set by the dialog box procedure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpfrhookproc LPFRHOOKPROC Lpfrhookproc; UINT_PTR
	// Lpfrhookproc( HWND Arg1, UINT Arg2, WPARAM Arg3, LPARAM Arg4 ) {...}
	[PInvokeData("commdlg.h", MSDNShortId = "NC:commdlg.LPFRHOOKPROC")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate IntPtr LPFRHOOKPROC(HWND Arg1, uint Arg2, IntPtr Arg3, IntPtr Arg4);

	/// <summary>
	/// <para>
	/// [Starting with Windows Vista, the <c>Open</c> and <c>Save As</c> common dialog boxes have been superseded by the Common Item
	/// Dialog. We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.]
	/// </para>
	/// <para>
	/// Receives notification messages sent from the dialog box. The function also receives messages for any additional controls that
	/// you defined by specifying a child dialog template. The OFNHookProc hook procedure is an application-defined or library-defined
	/// callback function that is used with the Explorer-style <c>Open</c> and <c>Save As</c> dialog boxes.
	/// </para>
	/// <para>
	/// The <c>LPOFNHOOKPROC</c> type defines a pointer to this callback function. OFNHookProc is a placeholder for the
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="Arg1">
	/// A handle to the child dialog box of the <c>Open</c> or <c>Save As</c> dialog box. Use the GetParent function to get the handle
	/// to the <c>Open</c> or <c>Save As</c> dialog box.
	/// </param>
	/// <param name="Arg2">The identifier of the message being received.</param>
	/// <param name="Arg3">Additional information about the message. The exact meaning depends on the value of the Arg2 parameter.</param>
	/// <param name="Arg4">
	/// Additional information about the message. The exact meaning depends on the value of the Arg2 parameter. If the Arg2 parameter
	/// indicates the WM_INITDIALOG message, Arg4 is a pointer to an OPENFILENAME structure containing the values specified when the
	/// dialog box was created.
	/// </param>
	/// <returns>
	/// <para>If the hook procedure returns zero, the default dialog box procedure processes the message.</para>
	/// <para>If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.</para>
	/// <para>
	/// For the CDN_SHAREVIOLATION and CDN_FILEOK notification messages, the hook procedure should return a nonzero value to indicate
	/// that it has used the SetWindowLong function to set a nonzero <c>DWL_MSGRESULT</c> value.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If you do not specify the <c>OFN_EXPLORER</c> flag when you create an <c>Open</c> or <c>Save As</c> dialog box, and you want a
	/// hook procedure, you must use an old-style OFNHookProcOldStyle hook procedure. In this case, the dialog box will have the
	/// old-style user interface.
	/// </para>
	/// <para>
	/// When you use the GetOpenFileName or GetSaveFileName functions to create an Explorer-style <c>Open</c> or <c>Save As</c> dialog
	/// box, you can provide an OFNHookProc hook procedure. To enable the hook procedure, use the OPENFILENAME structure that you passed
	/// to the dialog creation function. Specify the pointer to the hook procedure in the <c>lpfnHook</c> member and specify the
	/// <c>OFN_ENABLEHOOK</c> flag in the <c>Flags</c> member.
	/// </para>
	/// <para>
	/// If you provide a hook procedure for an Explorer-style common dialog box, the system creates a dialog box that is a child of the
	/// default dialog box. The hook procedure acts as the dialog procedure for the child dialog. This child dialog is based on the
	/// template you specified in the OPENFILENAME structure, or it is a default child dialog if no template is specified. The child
	/// dialog is created when the default dialog procedure is processing its WM_INITDIALOG message. After the child dialog processes
	/// its own <c>WM_INITDIALOG</c> message, the default dialog procedure moves the standard controls, if necessary, to make room for
	/// any additional controls of the child dialog. The system then sends the CDN_INITDONE notification message to the hook procedure.
	/// </para>
	/// <para>
	/// The hook procedure does not receive messages intended for the standard controls of the default dialog box. You can subclass the
	/// standard controls, but this is discouraged because it may make your application incompatible with later versions. However, the
	/// Explorer-style common dialog boxes provide a set of messages that the hook procedure can use to monitor and control the dialog.
	/// These include a set of notification messages sent from the dialog, as well as messages that you can send to retrieve information
	/// from the dialog. For a complete list of these messages, see Explorer-Style Hook Procedures.
	/// </para>
	/// <para>
	/// If the hook procedure processes the WM_CTLCOLORDLG message, it must return a valid brush handle to painting the background of
	/// the dialog box. In general, if it processes any <c>WM_CTLCOLOR*</c> message, it must return a valid brush handle to painting the
	/// background of the specified control.
	/// </para>
	/// <para>
	/// Do not call the EndDialog function from the hook procedure. Instead, the hook procedure can call the PostMessage function to
	/// post a WM_COMMAND message with the <c>IDCANCEL</c> value to the dialog box procedure. Posting <c>IDCANCEL</c> closes the dialog
	/// box and causes the dialog box function to return <c>FALSE</c>. If you need to know why the hook procedure closed the dialog box,
	/// you must provide your own communication mechanism between the hook procedure and your application.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpofnhookproc LPOFNHOOKPROC Lpofnhookproc; UINT_PTR
	// Lpofnhookproc( HWND Arg1, UINT Arg2, WPARAM Arg3, LPARAM Arg4 ) {...}
	[PInvokeData("commdlg.h", MSDNShortId = "NC:commdlg.LPOFNHOOKPROC")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate IntPtr LPOFNHOOKPROC(HWND Arg1, uint Arg2, IntPtr Arg3, IntPtr Arg4);

	/// <summary>
	/// <para>
	/// Receives messages that allow you to customize drawing of the sample page in the <c>Page Setup</c> dialog box. The PagePaintHook
	/// hook procedure is an application-defined or library-defined callback function used with the PageSetupDlg function.
	/// </para>
	/// <para>
	/// The <c>LPPAGEPAINTHOOK</c> type defines a pointer to this callback function. PagePaintHook is a placeholder for the
	/// application-defined or library-defined function name.
	/// </para>
	/// </summary>
	/// <param name="Arg1">A handle to the <c>Page Setup</c> dialog box.</param>
	/// <param name="Arg2">The identifier of the message being received.</param>
	/// <param name="Arg3">Additional information about the message. The exact meaning depends on the value of the Arg2 parameter.</param>
	/// <param name="Arg4">Additional information about the message. The exact meaning depends on the value of the Arg2 parameter.</param>
	/// <returns>
	/// <para>
	/// If the hook procedure returns <c>TRUE</c> for any of the first three messages of a drawing sequence (WM_PSD_PAGESETUPDLG,
	/// WM_PSD_FULLPAGERECT, or WM_PSD_MINMARGINRECT), the dialog box sends no more messages and does not draw in the sample page until
	/// the next time the system needs to redraw the sample page. If the hook procedure returns <c>FALSE</c> for all three messages, the
	/// dialog box sends the remaining messages of the drawing sequence.
	/// </para>
	/// <para>
	/// If the hook procedure returns <c>TRUE</c> for any of the remaining messages in a drawing sequence, the dialog box does not draw
	/// the corresponding portion of the sample page. If the hook procedure returns <c>FALSE</c> for any of these messages, the dialog
	/// box draws that portion of the sample page.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>Page Setup</c> dialog box includes an image of a sample page that shows how the user's selections affect the appearance
	/// of the printed output. The image consists of a rectangle that represents the selected paper or envelope type, with a dotted-line
	/// rectangle representing the current margins, and partial (Greek text) characters to show how text looks on the printed page. When
	/// you use the PageSetupDlg function to create a <c>Page Setup</c> dialog box, you can provide a PagePaintHook hook procedure to
	/// customize the appearance of the sample page.
	/// </para>
	/// <para>
	/// To enable the hook procedure, use the PAGESETUPDLG structure that you passed to the creation function. Specify the pointer to
	/// the hook procedure in the <c>lpfnPagePaintHook</c> member and specify the <c>PSD_ENABLEPAGEPAINTHOOK</c> flag in the
	/// <c>Flags</c> member.
	/// </para>
	/// <para>
	/// Whenever the dialog box is about to draw the contents of the sample page, the hook procedure receives the following messages in
	/// the order in which they are listed.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Message</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WM_PSD_PAGESETUPDLG</term>
	/// <term>
	/// The dialog box is about to draw the sample page. The hook procedure can use this message to prepare to draw the contents of the
	/// sample page.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WM_PSD_FULLPAGERECT</term>
	/// <term>The dialog box is about to draw the sample page. This message specifies the bounding rectangle of the sample page.</term>
	/// </item>
	/// <item>
	/// <term>WM_PSD_MINMARGINRECT</term>
	/// <term>The dialog box is about to draw the sample page. This message specifies the margin rectangle.</term>
	/// </item>
	/// <item>
	/// <term>WM_PSD_MARGINRECT</term>
	/// <term>The dialog box is about to draw the margin rectangle.</term>
	/// </item>
	/// <item>
	/// <term>WM_PSD_GREEKTEXTRECT</term>
	/// <term>The dialog box is about to draw the Greek text inside the margin rectangle.</term>
	/// </item>
	/// <item>
	/// <term>WM_PSD_ENVSTAMPRECT</term>
	/// <term>
	/// The dialog box is about to draw in the envelope-stamp rectangle of an envelope sample page. This message is sent for envelopes only.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WM_PSD_YAFULLPAGERECT</term>
	/// <term>
	/// The dialog box is about to draw the return address portion of an envelope sample page. This message is sent for envelopes and
	/// other paper sizes.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lppagepainthook LPPAGEPAINTHOOK Lppagepainthook; UINT_PTR
	// Lppagepainthook( HWND Arg1, UINT Arg2, WPARAM Arg3, LPARAM Arg4 ) {...}
	[PInvokeData("commdlg.h", MSDNShortId = "NC:commdlg.LPPAGEPAINTHOOK")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate IntPtr LPPAGEPAINTHOOK(HWND Arg1, uint Arg2, IntPtr Arg3, IntPtr Arg4);

	/// <summary>
	/// <para>
	/// Receives messages or notifications intended for the default dialog box procedure of the <c>Page Setup</c> dialog box. The
	/// PageSetupHook hook procedure is an application-defined or library-defined callback function used with the PageSetupDlg function.
	/// </para>
	/// <para>
	/// The <c>LPPAGESETUPHOOK</c> type defines a pointer to this callback function. PageSetupHook is a placeholder for the
	/// application-defined or library-defined function name.
	/// </para>
	/// </summary>
	/// <param name="Arg1">A handle to the <c>Page Setup</c> dialog box for which the message is intended.</param>
	/// <param name="Arg2">The identifier of the message being received.</param>
	/// <param name="Arg3">Additional information about the message. The exact meaning depends on the value of the Arg2 parameter.</param>
	/// <param name="Arg4">
	/// <para>Additional information about the message. The exact meaning depends on the value of the Arg2 parameter.</para>
	/// <para>
	/// If the Arg2 parameter indicates the WM_INITDIALOG message, Arg4 is a pointer to a PAGESETUPDLG structure containing the values
	/// specified when the dialog box was created.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the hook procedure returns zero, the default dialog box procedure processes the message.</para>
	/// <para>If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When you use the PageSetupDlg function to create a <c>Page Setup</c> dialog box, you can provide a PageSetupHook hook procedure
	/// to process messages or notifications intended for the dialog box procedure. To enable the hook procedure, use the PAGESETUPDLG
	/// structure that you passed to the dialog creation function. Specify the pointer to the hook procedure in the
	/// <c>lpfnPageSetupHook</c> member and specify the <c>PSD_ENABLEPAGESETUPHOOK</c> flag in the <c>Flags</c> member.
	/// </para>
	/// <para>
	/// The default dialog box procedure processes the WM_INITDIALOG message before passing it to the hook procedure. For all other
	/// messages, the hook procedure receives the message first. Then, the return value of the hook procedure determines whether the
	/// default dialog procedure processes the message or ignores it.
	/// </para>
	/// <para>
	/// If the hook procedure processes the WM_CTLCOLORDLG message, it must return a valid brush handle to painting the background of
	/// the dialog box. In general, if the hook procedure processes any <c>WM_CTLCOLOR*</c> message, it must return a valid brush handle
	/// to painting the background of the specified control.
	/// </para>
	/// <para>
	/// Do not call the EndDialog function from the hook procedure. Instead, the hook procedure can call the PostMessage function to
	/// post a WM_COMMAND message with the <c>IDABORT</c> value to the dialog box procedure. Posting <c>IDABORT</c> closes the dialog
	/// box and causes the dialog box function to return <c>FALSE</c>. If you need to know why the hook procedure closed the dialog box,
	/// you must provide your own communication mechanism between the hook procedure and your application.
	/// </para>
	/// <para>
	/// You can subclass the standard controls of a common dialog box. However, the dialog box procedure may also subclass the controls.
	/// Because of this, you should subclass controls when your hook procedure processes the WM_INITDIALOG message. This ensures that
	/// your subclass procedure receives the control-specific messages before the subclass procedure set by the dialog box procedure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lppagesetuphook LPPAGESETUPHOOK Lppagesetuphook; UINT_PTR
	// Lppagesetuphook( HWND Arg1, UINT Arg2, WPARAM Arg3, LPARAM Arg4 ) {...}
	[PInvokeData("commdlg.h", MSDNShortId = "NC:commdlg.LPPAGESETUPHOOK")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate IntPtr LPPAGESETUPHOOK(HWND Arg1, uint Arg2, IntPtr Arg3, IntPtr Arg4);

	/// <summary>
	/// <para>
	/// Receives messages or notifications intended for the default dialog box procedure of the <c>Print</c> dialog box. This is an
	/// application-defined or library-defined callback function that is used with the PrintDlg function.
	/// </para>
	/// <para>
	/// The <c>LPPRINTHOOKPROC</c> type defines a pointer to this callback function. PrintHookProc is a placeholder for the
	/// application-defined or library-defined function name.
	/// </para>
	/// </summary>
	/// <param name="Arg1">A handle to the <c>Print</c> dialog box for which the message is intended.</param>
	/// <param name="Arg2">The identifier of the message being received.</param>
	/// <param name="Arg3">Additional information about the message. The exact meaning depends on the value of the Arg2 parameter.</param>
	/// <param name="Arg4">
	/// <para>Additional information about the message. The exact meaning depends on the value of the Arg2 parameter.</para>
	/// <para>
	/// If the Arg2 parameter indicates the WM_INITDIALOG message, Arg4 is a pointer to a PRINTDLG structure containing the values
	/// specified when the dialog box was created.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the hook procedure returns zero, the default dialog box procedure processes the message.</para>
	/// <para>If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When you use the PrintDlg function to create a <c>Print</c> dialog box, you can provide a PrintHookProc hook procedure to
	/// process messages or notifications intended for the dialog box procedure. To enable the hook procedure, use the PRINTDLG
	/// structure that you passed to the dialog creation function. Specify the address of the hook procedure in the <c>lpfnPrintHook</c>
	/// member and specify the <c>PD_ENABLEPRINTHOOK</c> flag in the <c>Flags</c> member.
	/// </para>
	/// <para>
	/// The default dialog box procedure processes the WM_INITDIALOG message before passing it to the hook procedure. For all other
	/// messages, the hook procedure receives the message first. Then, the return value of the hook procedure determines whether the
	/// default dialog procedure processes the message or ignores it.
	/// </para>
	/// <para>
	/// If the hook procedure processes the WM_CTLCOLORDLG message, it must return a valid brush handle to painting the background of
	/// the dialog box. In general, if the hook procedure processes any <c>WM_CTLCOLOR*</c> message, it must return a valid brush handle
	/// to painting the background of the specified control.
	/// </para>
	/// <para>
	/// Do not call the EndDialog function from the hook procedure. Instead, the hook procedure can call the PostMessage function to
	/// post a WM_COMMAND message with the <c>IDABORT</c> value to the dialog box procedure. Posting <c>IDABORT</c> closes the dialog
	/// box and causes the dialog box function to return <c>FALSE</c>. If you need to know why the hook procedure closed the dialog box,
	/// you must provide your own communication mechanism between the hook procedure and your application.
	/// </para>
	/// <para>
	/// You can subclass the standard controls of a common dialog box. However, the dialog box procedure may also subclass the controls.
	/// Because of this, you should subclass controls when your hook procedure processes the WM_INITDIALOG message. This ensures that
	/// your subclass procedure receives the control-specific messages before the subclass procedure set by the dialog box procedure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpprinthookproc LPPRINTHOOKPROC Lpprinthookproc; UINT_PTR
	// Lpprinthookproc( HWND Arg1, UINT Arg2, WPARAM Arg3, LPARAM Arg4 ) {...}
	[PInvokeData("commdlg.h", MSDNShortId = "NC:commdlg.LPPRINTHOOKPROC")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate IntPtr LPPRINTHOOKPROC(HWND Arg1, uint Arg2, IntPtr Arg3, IntPtr Arg4);

	/// <summary>
	/// <para>
	/// An application-defined or library-defined callback function used with the PrintDlg function. The hook procedure receives
	/// messages or notifications intended for the default dialog box procedure of the <c>Print Setup</c> dialog box.
	/// </para>
	/// <para>
	/// The <c>LPSETUPHOOKPROC</c> type defines a pointer to this callback function. SetupHookProc is a placeholder for the
	/// application-defined or library-defined function name.
	/// </para>
	/// </summary>
	/// <param name="Arg1">A handle to the <c>Print Setup</c> dialog box for which the message is intended.</param>
	/// <param name="Arg2">The identifier of the message being received.</param>
	/// <param name="Arg3">Additional information about the message. The exact meaning depends on the value of the Arg2 parameter.</param>
	/// <param name="Arg4">Additional information about the message. The exact meaning depends on the value of the Arg2 parameter.</param>
	/// <returns>
	/// <para>If the hook procedure returns zero, the default dialog box procedure processes the message.</para>
	/// <para>If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>Print Setup</c> dialog box has been superseded by the <c>Page Setup</c> dialog box, which should be used by new
	/// applications. However, for compatibility, the PrintDlg function continues to support display of the <c>Print Setup</c> dialog
	/// box. You can provide a SetupHookProc hook procedure for the <c>Print Setup</c> dialog box to process messages or notifications
	/// intended for the dialog box procedure.
	/// </para>
	/// <para>
	/// To enable the hook procedure, use the PRINTDLG structure that you passed to the dialog creation function. Specify the address of
	/// the hook procedure in the <c>lpfnSetupHook</c> member and specify the <c>PD_ENABLESETUPHOOK</c> flag in the <c>Flags</c> member.
	/// </para>
	/// <para>
	/// The default dialog box procedure processes the WM_INITDIALOG message before passing it to the hook procedure. For all other
	/// messages, the hook procedure receives the message first. Then, the return value of the hook procedure determines whether the
	/// default dialog procedure processes the message or ignores it.
	/// </para>
	/// <para>
	/// If the hook procedure processes the WM_CTLCOLORDLG message, it must return a valid brush handle to painting the background of
	/// the dialog box. In general, if the hook procedure processes any <c>WM_CTLCOLOR*</c> message, it must return a valid brush handle
	/// to painting the background of the specified control.
	/// </para>
	/// <para>
	/// Do not call the EndDialog function from the hook procedure. Instead, the hook procedure can call the PostMessage function to
	/// post a WM_COMMAND message with the <c>IDABORT</c> value to the dialog box procedure. Posting <c>IDABORT</c> closes the dialog
	/// box and causes the dialog box function to return <c>FALSE</c>. If you need to know why the hook procedure closed the dialog box,
	/// you must provide your own communication mechanism between the hook procedure and your application.
	/// </para>
	/// <para>
	/// You can subclass the standard controls of a common dialog box. However, the dialog box procedure may also subclass the controls.
	/// Because of this, you should subclass controls when your hook procedure processes the WM_INITDIALOG message. This ensures that
	/// your subclass procedure receives the control-specific messages before the subclass procedure set by the dialog box procedure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpsetuphookproc LPSETUPHOOKPROC Lpsetuphookproc; UINT_PTR
	// Lpsetuphookproc( HWND Arg1, UINT Arg2, WPARAM Arg3, LPARAM Arg4 ) {...}
	[PInvokeData("commdlg.h", MSDNShortId = "NC:commdlg.LPSETUPHOOKPROC")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate IntPtr LPSETUPHOOKPROC(HWND Arg1, uint Arg2, IntPtr Arg3, IntPtr Arg4);

	/// <summary>
	/// Provides methods that enable an application to receive notifications and messages from the PrintDlgEx function while the Print
	/// Property Sheet is displayed.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nn-commdlg-iprintdialogcallback
	[PInvokeData("commdlg.h", MSDNShortId = "NN:commdlg.IPrintDialogCallback")]
	[ComImport, Guid("5852A2C3-6530-11D1-B6A3-0000F8757BF9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPrintDialogCallback
	{
		/// <summary>
		/// Called by PrintDlgEx when the system has finished initializing the <c>General</c> page of the Print Property Sheet.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return <c>S_OK</c> to prevent the PrintDlgEx function from performing its default actions.</para>
		/// <para>
		/// Return <c>S_FALSE</c> to allow PrintDlgEx to perform its default actions. Currently, <c>PrintDlgEx</c> does not perform any
		/// default processing after the <c>InitDone</c> call.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If your callback object implements the IObjectWithSite interface, the PrintDlgEx function calls the IObjectWithSite::SetSite
		/// method to pass an IPrintDialogServices pointer to the callback object. The <c>PrintDlgEx</c> function calls the
		/// <c>IObjectWithSite::SetSite</c> method before calling the <c>InitDone</c> method. This enables your <c>InitDone</c>
		/// implementation to use the <c>IPrintDialogServices</c> methods to retrieve information about the currently selected printer.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-iprintdialogcallback-initdone HRESULT InitDone();
		[PreserveSig]
		HRESULT InitDone();

		/// <summary>
		/// Called by PrintDlgEx when the user selects a different printer from the list of installed printers on the <c>General</c>
		/// page of the Print Property Sheet.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return <c>S_OK</c> to prevent the PrintDlgEx function from performing its default actions.</para>
		/// <para>
		/// Return <c>S_FALSE</c> to allow PrintDlgEx to perform its default actions, which include adjustments to the <c>Copies</c>,
		/// <c>Collate</c>, and <c>Print Range</c> items.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-iprintdialogcallback-selectionchange HRESULT SelectionChange();
		[PreserveSig]
		HRESULT SelectionChange();

		/// <summary>
		/// Called by PrintDlgEx to give your application an opportunity to handle messages sent to the child dialog box in the lower
		/// portion of the <c>General</c> page of the Print Property Sheet. The child dialog box contains controls similar to those of
		/// the <c>Print</c> dialog box.
		/// </summary>
		/// <param name="hDlg">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the child dialog box in the lower portion of the <c>General</c> page.</para>
		/// </param>
		/// <param name="uMsg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The identifier of the message being received.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>Additional information about the message. The exact meaning depends on the value of the uMsg parameter.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>Additional information about the message. The exact meaning depends on the value of the uMsg parameter.</para>
		/// <para>
		/// If the uMsg parameter indicates the WM_INITDIALOG message, lParam is a pointer to a PRINTDLGEX structure containing the
		/// values specified when the property sheet was created.
		/// </para>
		/// </param>
		/// <param name="pResult">
		/// <para>Type: <c>LRESULT*</c></para>
		/// <para>
		/// Indicates the result to be returned by the dialog box procedure for the message. The value pointed to should be <c>TRUE</c>
		/// if you process the message, otherwise it should be <c>FALSE</c> or whatever is an appropriate value according to the message type.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Return <c>S_OK</c> if your <c>IPrintDialogCallback::HandleMessage</c> implementation handled the message. In this case, the
		/// PrintDlgEx function does not perform any default message handling.
		/// </para>
		/// <para>Return <c>S_FALSE</c> if you want PrintDlgEx to perform its default message handling.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For notification messages passed by the WM_NOTIFY message, you must use the SetWindowLong function with the
		/// <c>DWL_MSGRESULT</c> value to set a return value. When you call <c>SetWindowLong</c>, use GetParent(hDlg) to set the
		/// <c>DWL_MSGRESULT</c> value of the <c>General</c> page, which is the parent of the child window.
		/// </para>
		/// <para>
		/// The default dialog box procedure for the child window in the lower portion of the <c>General</c> page processes the
		/// WM_INITDIALOG message before passing it to the <c>HandleMessage</c> method. For all other messages sent to the child window,
		/// <c>HandleMessage</c> receives the message first. Then the <c>HandleMessage</c> return value determines whether the default
		/// dialog procedure processes the message or ignores it.
		/// </para>
		/// <para>
		/// If <c>HandleMessage</c> processes the WM_CTLCOLORDLG message, it must return a valid brush handle to painting the background
		/// of the dialog box. In general, if <c>HandleMessage</c> processes any <c>WM_CTLCOLOR*</c> message, it must return a valid
		/// brush handle to painting the background of the specified control.
		/// </para>
		/// <para>
		/// Do not call the EndDialog function from the <c>HandleMessage</c> method. Instead, <c>HandleMessage</c> can call the
		/// PostMessage function to post a WM_COMMAND message with the IDABORT value to the dialog box procedure. Posting <c>IDABORT</c>
		/// closes the Print Property Sheet and causes PrintDlgEx to return <c>PD_RESULT_CANCEL</c> in the <c>dwResultAction</c> member
		/// of the PRINTDLGEX structure. If you need to know why <c>HandleMessage</c> closed the dialog box, you must provide your own
		/// communication mechanism between the <c>HandleMessage</c> method and your application.
		/// </para>
		/// <para>
		/// You can subclass the standard controls of the child dialog box in the lower portion of the <c>General</c> page. These
		/// standard controls are similar to those found in the <c>Print</c> dialog box. However, the default dialog box procedure may
		/// also subclass the controls. Because of this, you should subclass controls when <c>HandleMessage</c> processes the
		/// WM_INITDIALOG message. This ensures that your subclass procedure receives control-specific messages before the subclass
		/// procedure set by the dialog box procedure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-iprintdialogcallback-handlemessage HRESULT
		// HandleMessage( HWND hDlg, UINT uMsg, WPARAM wParam, LPARAM lParam, LRESULT *pResult );
		[PreserveSig]
		HRESULT HandleMessage(HWND hDlg, uint uMsg, IntPtr wParam, IntPtr lParam, out IntPtr pResult);
	}

	/// <summary>
	/// Provides methods that enable an application using the PrintDlgEx function to retrieve information about the currently selected printer.
	/// </summary>
	/// <remarks>This printer is indicated on the list of installed printers on the <c>General</c> page of the Print Property Sheet.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nn-commdlg-iprintdialogservices
	[PInvokeData("commdlg.h", MSDNShortId = "NN:commdlg.IPrintDialogServices")]
	[ComImport, Guid("509AAEDA-5639-11D1-B6A1-0000F8757BF9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPrintDialogServices
	{
		/// <summary>Fills a DEVMODE structure with information about the currently selected printer for use with PrintDlgEx.</summary>
		/// <param name="pDevMode">
		/// <para>Type: <c>LPDEVMODE</c></para>
		/// <para>A pointer to a buffer that receives a DEVMODE structure containing information about the currently selected printer.</para>
		/// </param>
		/// <param name="pcbSize">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// On input, the variable specifies the size, in bytes, of the buffer pointed to by the lpDevMode parameter. On output, the
		/// variable contains the number of bytes written to lpDevMode.
		/// </para>
		/// <para>
		/// If the size is zero on input, the function returns the required buffer size (in bytes) in pcbSize and does not use the
		/// lpDevMode buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// If the method is successful, the return value is <c>S_OK</c>. If no printer is currently selected, the return value is
		/// <c>S_OK</c>, the value returned in pcbSize is zero, and the lpDevMode buffer is unchanged.
		/// </para>
		/// <para>If an error occurs, the return value is a COM error code. For more information, see Error Handling.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-iprintdialogservices-getcurrentdevmode HRESULT
		// GetCurrentDevMode( LPDEVMODE pDevMode, UINT *pcbSize );
		[PreserveSig]
		HRESULT GetCurrentDevMode(ref DEVMODE pDevMode, ref uint pcbSize);

		/// <summary>Retrieves the name of the currently selected printer, for use with PrintDlgEx.</summary>
		/// <param name="pPrinterName">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>The name of the currently selected printer.</para>
		/// </param>
		/// <param name="pcchSize">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// On input, the variable specifies the size, in characters, of the buffer pointed to by the lpPrinterName parameter. On
		/// output, the variable contains the number of bytes (ANSI) or characters (Unicode), including the terminating null character,
		/// written to the buffer.
		/// </para>
		/// <para>
		/// If the size is zero on input, the function returns the required buffer size (in bytes or characters) in pcchSize and does
		/// not use the lpPrinterName buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// If the method is successful, the return value is <c>S_OK</c>. If no printer is currently selected, the return value is
		/// <c>S_OK</c>, the value returned in pcchSize is zero, and the lpPrinterName buffer is unchanged.
		/// </para>
		/// <para>If an error occurs, the return value is a COM error code. For more information, see Error Handling.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-iprintdialogservices-getcurrentprintername HRESULT
		// GetCurrentPrinterName( PWSTR pPrinterName, UINT *pcchSize );
		[PreserveSig]
		HRESULT GetCurrentPrinterName([MarshalAs(UnmanagedType.LPWStr), SizeDef(nameof(pcchSize), SizingMethod.Query)] StringBuilder? pPrinterName, ref uint pcchSize);

		/// <summary>Retrieves the name of the current port for use with PrintDlgEx.</summary>
		/// <param name="pPortName">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>The name of the current port.</para>
		/// </param>
		/// <param name="pcchSize">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// On input, the variable specifies the size, in characters, of the buffer pointed to by the lpPortName parameter. On output,
		/// the variable contains the number of bytes (ANSI) or characters (Unicode), including the terminating null character, written
		/// to the buffer.
		/// </para>
		/// <para>
		/// If the size is zero on input, the function returns the required buffer size (in bytes or characters) in pcchSize and does
		/// not use the lpPortName buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// If the method is successful, the return value is <c>S_OK</c>. If there is no current port, the return value is <c>S_OK</c>,
		/// the value returned in pcchSize is zero, and the lpPortName buffer is unchanged.
		/// </para>
		/// <para>If an error occurs, the return value is a COM error code. For more information, see Error Handling.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-iprintdialogservices-getcurrentportname HRESULT
		// GetCurrentPortName( PWSTR pPortName, UINT *pcchSize );
		[PreserveSig]
		HRESULT GetCurrentPortName([MarshalAs(UnmanagedType.LPWStr), SizeDef(nameof(pcchSize), SizingMethod.Query)] StringBuilder pPortName, ref uint pcchSize);
	}

	/// <summary>Creates a <c>Color</c> dialog box that enables the user to select a color.</summary>
	/// <param name="lpcc">
	/// <para>[in, out] Type: <c>LPCHOOSECOLOR</c></para>
	/// <para>
	/// A pointer to a <c>CHOOSECOLOR</c> structure that contains information used to initialize the dialog box. When <c>ChooseColor</c>
	/// returns, this structure contains information about the user's color selection.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If the user clicks the <c>OK</c> button of the dialog box, the return value is nonzero. The <c>rgbResult</c> member of the
	/// <c>CHOOSECOLOR</c> structure contains the RGB color value of the color selected by the user.
	/// </para>
	/// <para>
	/// If the user cancels or closes the <c>Color</c> dialog box or an error occurs, the return value is zero. To get extended error
	/// information, call the <c>CommDlgExtendedError</c> function, which can return one of the following values:
	/// </para>
	/// <para><c>CDERR_DIALOGFAILURE</c></para>
	/// <para><c>CDERR_FINDRESFAILURE</c></para>
	/// <para><c>CDERR_MEMLOCKFAILURE</c></para>
	/// <para><c>CDERR_INITIALIZATION</c></para>
	/// <para><c>CDERR_NOHINSTANCE</c></para>
	/// <para><c>CDERR_NOHOOK</c></para>
	/// <para><c>CDERR_LOADRESFAILURE</c></para>
	/// <para><c>CDERR_NOTEMPLATE</c></para>
	/// <para><c>CDERR_LOADSTRFAILURE</c></para>
	/// <para><c>CDERR_STRUCTSIZE</c></para>
	/// <para><c>CDERR_MEMALLOCFAILURE</c></para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>Color</c> dialog box does not support palettes. The color choices offered by the dialog box are limited to the system
	/// colors and dithered versions of those colors.
	/// </para>
	/// <para>
	/// You can provide a <c>CCHookProc</c> hook procedure for a <c>Color</c> dialog box. The hook procedure can process messages sent
	/// to the dialog box. To enable a hook procedure, set the <c>CC_ENABLEHOOK</c> flag in the <c>Flags</c> member of the
	/// <c>CHOOSECOLOR</c> structure and specify the address of the hook procedure in the <c>lpfnHook</c> member.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms646912(v=vs.85)
	// BOOL WINAPI ChooseColor( _Inout_ LPCHOOSECOLOR lpcc );
	[DllImport(Lib_ComDlg32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("Commdlg.h")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ChooseColor(ref CHOOSECOLOR lpcc);

	/// <summary>
	/// Creates a <c>Font</c> dialog box that enables the user to choose attributes for a logical font. These attributes include a font
	/// family and associated font style, a point size, effects (underline, strikeout, and text color), and a script (or character set).
	/// </summary>
	/// <param name="lpcf">
	/// <para>[in, out] Type: <c>LPCHOOSEFONT</c></para>
	/// <para>
	/// A pointer to a <c>CHOOSEFONT</c> structure that contains information used to initialize the dialog box. When <c>ChooseFont</c>
	/// returns, this structure contains information about the user's font selection.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If the user clicks the <c>OK</c> button of the dialog box, the return value is <c>TRUE</c>. The members of the <c>CHOOSEFONT</c>
	/// structure indicate the user's selections.
	/// </para>
	/// <para>
	/// If the user cancels or closes the <c>Font</c> dialog box or an error occurs, the return value is <c>FALSE</c>. To get extended
	/// error information, call the <c>CommDlgExtendedError</c> function, which can return one of the following values.
	/// </para>
	/// <para><c>CDERR_DIALOGFAILURE</c></para>
	/// <para><c>CDERR_FINDRESFAILURE</c></para>
	/// <para><c>CDERR_NOHINSTANCE</c></para>
	/// <para><c>CDERR_INITIALIZATION</c></para>
	/// <para><c>CDERR_NOHOOK</c></para>
	/// <para><c>CDERR_LOCKRESFAILURE</c></para>
	/// <para><c>CDERR_NOTEMPLATE</c></para>
	/// <para><c>CDERR_LOADRESFAILURE</c></para>
	/// <para><c>CDERR_STRUCTSIZE</c></para>
	/// <para><c>CDERR_LOADSTRFAILURE</c></para>
	/// <para><c>CFERR_MAXLESSTHANMIN</c></para>
	/// <para><c>CDERR_MEMALLOCFAILURE</c></para>
	/// <para><c>CFERR_NOFONTS</c></para>
	/// <para><c>CDERR_MEMLOCKFAILURE</c></para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You can provide a <c>CFHookProc</c> hook procedure for a <c>Font</c> dialog box. The hook procedure can process messages sent to
	/// the dialog box. To enable a hook procedure, set the <c>CF_ENABLEHOOK</c> flag in the <c>Flags</c> member of the
	/// <c>CHOOSEFONT</c> structure and specify the address of the hook procedure in the <c>lpfnHook</c> member.
	/// </para>
	/// <para>
	/// The hook procedure can send the <c>WM_CHOOSEFONT_GETLOGFONT</c>, <c>WM_CHOOSEFONT_SETFLAGS</c>, and
	/// <c>WM_CHOOSEFONT_SETLOGFONT</c> messages to the dialog box to get and set the current values and flags of the dialog box.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms646914(v=vs.85)
	// BOOL WINAPI ChooseFont( _Inout_ LPCHOOSEFONT lpcf );
	[DllImport(Lib_ComDlg32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("Commdlg.h")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ChooseFont(ref CHOOSEFONT lpcf);

	/// <summary>
	/// Returns a common dialog box error code. This code indicates the most recent error to occur during the execution of one of the
	/// common dialog box functions.
	/// </summary>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// If the most recent call to a common dialog box function succeeded, the return value is undefined. If the common dialog box
	/// function returned <c>FALSE</c> because the user closed or canceled the dialog box, the return value is zero. Otherwise, the
	/// return value is a nonzero error code.
	/// </para>
	/// <para>
	/// The <c>CommDlgExtendedError</c> function can return general error codes for any of the common dialog box functions. In addition,
	/// there are error codes that are returned only for a specific common dialog box. All of these error codes are defined in Cderr.h.
	/// The following general error codes can be returned for any of the common dialog box functions.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CDERR_DIALOGFAILURE 0xFFFF</term>
	/// <term>
	/// The dialog box could not be created. The common dialog box function's call to the DialogBox function failed. For example, this
	/// error occurs if the common dialog box call specifies an invalid window handle.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CDERR_FINDRESFAILURE 0x0006</term>
	/// <term>The common dialog box function failed to find a specified resource.</term>
	/// </item>
	/// <item>
	/// <term>CDERR_INITIALIZATION 0x0002</term>
	/// <term>The common dialog box function failed during initialization. This error often occurs when sufficient memory is not available.</term>
	/// </item>
	/// <item>
	/// <term>CDERR_LOADRESFAILURE 0x0007</term>
	/// <term>The common dialog box function failed to load a specified resource.</term>
	/// </item>
	/// <item>
	/// <term>CDERR_LOADSTRFAILURE 0x0005</term>
	/// <term>The common dialog box function failed to load a specified string.</term>
	/// </item>
	/// <item>
	/// <term>CDERR_LOCKRESFAILURE 0x0008</term>
	/// <term>The common dialog box function failed to lock a specified resource.</term>
	/// </item>
	/// <item>
	/// <term>CDERR_MEMALLOCFAILURE 0x0009</term>
	/// <term>The common dialog box function was unable to allocate memory for internal structures.</term>
	/// </item>
	/// <item>
	/// <term>CDERR_MEMLOCKFAILURE 0x000A</term>
	/// <term>The common dialog box function was unable to lock the memory associated with a handle.</term>
	/// </item>
	/// <item>
	/// <term>CDERR_NOHINSTANCE 0x0004</term>
	/// <term>
	/// The ENABLETEMPLATE flag was set in the Flags member of the initialization structure for the corresponding common dialog box, but
	/// you failed to provide a corresponding instance handle.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CDERR_NOHOOK 0x000B</term>
	/// <term>
	/// The ENABLEHOOK flag was set in the Flags member of the initialization structure for the corresponding common dialog box, but you
	/// failed to provide a pointer to a corresponding hook procedure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CDERR_NOTEMPLATE 0x0003</term>
	/// <term>
	/// The ENABLETEMPLATE flag was set in the Flags member of the initialization structure for the corresponding common dialog box, but
	/// you failed to provide a corresponding template.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CDERR_REGISTERMSGFAIL 0x000C</term>
	/// <term>The RegisterWindowMessage function returned an error code when it was called by the common dialog box function.</term>
	/// </item>
	/// <item>
	/// <term>CDERR_STRUCTSIZE 0x0001</term>
	/// <term>The lStructSize member of the initialization structure for the corresponding common dialog box is invalid.</term>
	/// </item>
	/// </list>
	/// <para>The following error codes can be returned for the PrintDlg function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDERR_CREATEICFAILURE 0x100A</term>
	/// <term>The PrintDlg function failed when it attempted to create an information context.</term>
	/// </item>
	/// <item>
	/// <term>PDERR_DEFAULTDIFFERENT 0x100C</term>
	/// <term>
	/// You called the PrintDlg function with the DN_DEFAULTPRN flag specified in the wDefault member of the DEVNAMES structure, but the
	/// printer described by the other structure members did not match the current default printer. This error occurs when you store the
	/// DEVNAMES structure, and the user changes the default printer by using the Control Panel. To use the printer described by the
	/// DEVNAMES structure, clear the DN_DEFAULTPRN flag and call PrintDlg again. To use the default printer, replace the DEVNAMES
	/// structure (and the structure, if one exists) with NULL; and call PrintDlg again.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDERR_DNDMMISMATCH 0x1009</term>
	/// <term>The data in the DEVMODE and DEVNAMES structures describes two different printers.</term>
	/// </item>
	/// <item>
	/// <term>PDERR_GETDEVMODEFAIL 0x1005</term>
	/// <term>The printer driver failed to initialize a DEVMODE structure.</term>
	/// </item>
	/// <item>
	/// <term>PDERR_INITFAILURE 0x1006</term>
	/// <term>
	/// The PrintDlg function failed during initialization, and there is no more specific extended error code to describe the failure.
	/// This is the generic default error code for the function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDERR_LOADDRVFAILURE 0x1004</term>
	/// <term>The PrintDlg function failed to load the device driver for the specified printer.</term>
	/// </item>
	/// <item>
	/// <term>PDERR_NODEFAULTPRN 0x1008</term>
	/// <term>A default printer does not exist.</term>
	/// </item>
	/// <item>
	/// <term>PDERR_NODEVICES 0x1007</term>
	/// <term>No printer drivers were found.</term>
	/// </item>
	/// <item>
	/// <term>PDERR_PARSEFAILURE 0x1002</term>
	/// <term>The PrintDlg function failed to parse the strings in the [devices] section of the WIN.INI file.</term>
	/// </item>
	/// <item>
	/// <term>PDERR_PRINTERNOTFOUND 0x100B</term>
	/// <term>The [devices] section of the WIN.INI file did not contain an entry for the requested printer.</term>
	/// </item>
	/// <item>
	/// <term>PDERR_RETDEFFAILURE 0x1003</term>
	/// <term>
	/// The PD_RETURNDEFAULT flag was specified in the Flags member of the PRINTDLG structure, but the hDevMode or hDevNames member was
	/// not NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDERR_SETUPFAILURE 0x1001</term>
	/// <term>The PrintDlg function failed to load the required resources.</term>
	/// </item>
	/// </list>
	/// <para>The following error codes can be returned for the ChooseFont function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CFERR_MAXLESSTHANMIN CFERR_MAXLESSTHANMIN</term>
	/// <term>
	/// The size specified in the nSizeMax member of the CHOOSEFONT structure is less than the size specified in the nSizeMin member.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CFERR_NOFONTS 0x2001</term>
	/// <term>No fonts exist.</term>
	/// </item>
	/// </list>
	/// <para>The following error codes can be returned for the GetOpenFileName and GetSaveFileName functions.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>FNERR_BUFFERTOOSMALL 0x3003</term>
	/// <term>
	/// The buffer pointed to by the lpstrFile member of the OPENFILENAME structure is too small for the file name specified by the
	/// user. The first two bytes of the lpstrFile buffer contain an integer value specifying the size required to receive the full
	/// name, in characters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FNERR_INVALIDFILENAME 0x3002</term>
	/// <term>A file name is invalid.</term>
	/// </item>
	/// <item>
	/// <term>FNERR_SUBCLASSFAILURE 0x3001</term>
	/// <term>An attempt to subclass a list box failed because sufficient memory was not available.</term>
	/// </item>
	/// </list>
	/// <para>The following error code can be returned for the FindText and ReplaceText functions.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>FRERR_BUFFERLENGTHZERO 0x4001</term>
	/// <term>A member of the FINDREPLACE structure points to an invalid buffer.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-commdlgextendederror DWORD CommDlgExtendedError();
	[DllImport(Lib_ComDlg32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("commdlg.h", MSDNShortId = "NF:commdlg.CommDlgExtendedError")]
	public static extern ERR CommDlgExtendedError();

	/// <summary>
	/// Creates a system-defined modeless <c>Find</c> dialog box that lets the user specify a string to search for and options to use
	/// when searching for text in a document.
	/// </summary>
	/// <param name="Arg1">
	/// <para>Type: <c>LPFINDREPLACE</c></para>
	/// <para>
	/// A pointer to a FINDREPLACE structure that contains information used to initialize the dialog box. The dialog box uses this
	/// structure to send information about the user's input to your application. For more information, see the following Remarks section.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// If the function succeeds, the return value is the window handle to the dialog box. You can use the window handle to communicate
	/// with or to close the dialog box.
	/// </para>
	/// <para>
	/// If the function fails, the return value is <c>NULL</c>. To get extended error information, call the CommDlgExtendedError
	/// function. <c>CommDlgExtendedError</c> may return one of the following error codes:
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>FindText</c> function does not perform a search operation. Instead, the dialog box sends FINDMSGSTRING registered
	/// messages to the window procedure of the owner window of the dialog box. When you create the dialog box, the <c>hwndOwner</c>
	/// member of the FINDREPLACE structure is a handle to the owner window.
	/// </para>
	/// <para>
	/// Before calling <c>FindText</c>, you must call the RegisterWindowMessage function to get the identifier for the FINDMSGSTRING
	/// message. The dialog box procedure uses this identifier to send messages when the user clicks the <c>Find Next</c> button, or
	/// when the dialog box is closing. The lParam parameter of the <c>FINDMSGSTRING</c> message contains a pointer to a FINDREPLACE
	/// structure. The <c>Flags</c> member of this structure indicates the event that caused the message. Other members of the structure
	/// indicate the user's input.
	/// </para>
	/// <para>
	/// If you create a <c>Find</c> dialog box, you must also use the IsDialogMessage function in the main message loop of your
	/// application to ensure that the dialog box correctly processes keyboard input, such as the TAB and ESC keys.
	/// <c>IsDialogMessage</c> returns a value that indicates whether the <c>Find</c> dialog box processed the message.
	/// </para>
	/// <para>
	/// You can provide an FRHookProc hook procedure for a <c>Find</c> dialog box. The hook procedure can process messages sent to the
	/// dialog box. To enable a hook procedure, set the <c>FR_ENABLEHOOK</c> flag in the <c>Flags</c> member of the FINDREPLACE
	/// structure and specify the address of the hook procedure in the <c>lpfnHook</c> member.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Finding Text.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-findtexta HWND FindTextA( LPFINDREPLACEA Arg1 );
	[DllImport(Lib_ComDlg32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("commdlg.h", MSDNShortId = "NF:commdlg.FindTextA")]
	public static extern HWND FindText(ref FINDREPLACE Arg1);

	/// <summary>Retrieves the name of the specified file.</summary>
	/// <param name="lpszPath">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The name and location of a file.</para>
	/// </param>
	/// <param name="lpszTitle">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>The buffer that receives the name of the file.</para>
	/// </param>
	/// <param name="cchSize">
	/// <para>Type: <c>WORD</c></para>
	/// <para>The length, in characters, of the buffer pointed to by the lpszTitle parameter.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>short</c></para>
	/// <para>If the function succeeds, the return value is zero.</para>
	/// <para>If the file name is invalid, the return value is unknown. If there is an error, the return value is a negative number.</para>
	/// <para>
	/// If the buffer pointed to by the lpszTitle parameter is too small, the return value is a positive integer that specifies the
	/// required buffer size, in characters. The required buffer size includes the terminating null character.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para><c>GetFileTitle</c> should only be called with legal file names; using an illegal file name has an undefined result.</para>
	/// <para>
	/// To get the buffer size needed for the name of a file, call the function with lpszTitle set to <c>NULL</c> and cchSize set to
	/// zero. The function returns the required size.
	/// </para>
	/// <para>
	/// <c>GetFileTitle</c> returns the string that the system would use to display the file name to the user. The display name includes
	/// an extension only if that is the user's preference for displaying file names. This means that the returned string may not
	/// accurately identify the file if it is used in calls to file system functions.
	/// </para>
	/// <para>
	/// If the lpszTitle buffer is too small, <c>GetFileTitle</c> returns the size required to hold the display name. However, there is
	/// no guaranteed relationship between the required size and the characters originally specified in the lpszFile buffer. For
	/// example, do not call <c>GetFileTitle</c> with lpszTitle set to <c>NULL</c> and cchSize set to zero, and then try to use the
	/// return value as an index into the lpszFile string. You can usually achieve similar results (and superior performance) with C
	/// run-time library functions such as <c>strrchr</c>, <c>wcsrchr</c>, and <c>_mbsrchr</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-getfiletitlea short GetFileTitleA( LPCSTR , PSTR Buf, WORD
	// cchSize );
	[DllImport(Lib_ComDlg32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("commdlg.h", MSDNShortId = "NF:commdlg.GetFileTitleA")]
	public static extern short GetFileTitle([MarshalAs(UnmanagedType.LPTStr)] string lpszPath,
		[MarshalAs(UnmanagedType.LPTStr), SizeDef(nameof(cchSize), SizingMethod.QueryResultInReturn)] StringBuilder? lpszTitle, short cchSize);

	/// <summary>
	/// <para>
	/// [Starting with Windows Vista, the <c>Open</c> and <c>Save As</c> common dialog boxes have been superseded by the Common Item
	/// Dialog. We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.]
	/// </para>
	/// <para>
	/// Creates an <c>Open</c> dialog box that lets the user specify the drive, directory, and the name of a file or set of files to be opened.
	/// </para>
	/// </summary>
	/// <param name="Arg1">
	/// <para>Type: <c>LPOPENFILENAME</c></para>
	/// <para>
	/// A pointer to an OPENFILENAME structure that contains information used to initialize the dialog box. When <c>GetOpenFileName</c>
	/// returns, this structure contains information about the user's file selection.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If the user specifies a file name and clicks the <c>OK</c> button, the return value is nonzero. The buffer pointed to by the
	/// <c>lpstrFile</c> member of the OPENFILENAME structure contains the full path and file name specified by the user.
	/// </para>
	/// <para>
	/// If the user cancels or closes the <c>Open</c> dialog box or an error occurs, the return value is zero. To get extended error
	/// information, call the CommDlgExtendedError function, which can return one of the following values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The Explorer-style <c>Open</c> dialog box provides user-interface features that are similar to the Windows Explorer. You can
	/// provide an OFNHookProc hook procedure for an Explorer-style <c>Open</c> dialog box. To enable the hook procedure, set the
	/// <c>OFN_EXPLORER</c> and <c>OFN_ENABLEHOOK</c> flags in the <c>Flags</c> member of the OPENFILENAME structure and specify the
	/// address of the hook procedure in the <c>lpfnHook</c> member.
	/// </para>
	/// <para>
	/// Windows continues to support the old-style <c>Open</c> dialog box for applications that want to maintain a user-interface
	/// consistent with the old-style user-interface. To display the old-style <c>Open</c> dialog box, enable an OFNHookProcOldStyle
	/// hook procedure and ensure that the <c>OFN_EXPLORER</c> flag is not set.
	/// </para>
	/// <para>To display a dialog box that allows the user to select a directory instead of a file, call the SHBrowseForFolder function.</para>
	/// <para>Note, when selecting multiple files, the total character limit for the file names depends on the version of the function.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>ANSI: 32k limit</term>
	/// </item>
	/// <item>
	/// <term>Unicode: no restriction</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example, see Opening a File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-getopenfilenamea BOOL GetOpenFileNameA( LPOPENFILENAMEA
	// Arg1 );
	[DllImport(Lib_ComDlg32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("commdlg.h", MSDNShortId = "NF:commdlg.GetOpenFileNameA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetOpenFileName(ref OPENFILENAME Arg1);

	/// <summary>
	/// <para>
	/// [Starting with Windows Vista, the <c>Open</c> and <c>Save As</c> common dialog boxes have been superseded by the Common Item
	/// Dialog. We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.]
	/// </para>
	/// <para>Creates a <c>Save</c> dialog box that lets the user specify the drive, directory, and name of a file to save.</para>
	/// </summary>
	/// <param name="Arg1">
	/// <para>Type: <c>LPOPENFILENAME</c></para>
	/// <para>
	/// A pointer to an OPENFILENAME structure that contains information used to initialize the dialog box. When <c>GetSaveFileName</c>
	/// returns, this structure contains information about the user's file selection.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If the user specifies a file name and clicks the <c>OK</c> button and the function is successful, the return value is nonzero.
	/// The buffer pointed to by the <c>lpstrFile</c> member of the OPENFILENAME structure contains the full path and file name
	/// specified by the user.
	/// </para>
	/// <para>
	/// If the user cancels or closes the <c>Save</c> dialog box or an error such as the file name buffer being too small occurs, the
	/// return value is zero. To get extended error information, call the CommDlgExtendedError function, which can return one of the
	/// following values:
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The Explorer-style <c>Save</c> dialog box that provides user-interface features that are similar to the Windows Explorer. You
	/// can provide an OFNHookProc hook procedure for an Explorer-style <c>Save</c> dialog box. To enable the hook procedure, set the
	/// <c>OFN_EXPLORER</c> and <c>OFN_ENABLEHOOK</c> flags in the <c>Flags</c> member of the OPENFILENAME structure and specify the
	/// address of the hook procedure in the <c>lpfnHook</c> member.
	/// </para>
	/// <para>
	/// Windows continues to support old-style <c>Save</c> dialog boxes for applications that want to maintain a user-interface
	/// consistent with the old-style user-interface. To display the old-style <c>Save</c> dialog box, enable an OFNHookProcOldStyle
	/// hook procedure and ensure that the <c>OFN_EXPLORER</c> flag is not set.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating an Enhanced Metafile.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-getsavefilenamea BOOL GetSaveFileNameA( LPOPENFILENAMEA
	// Arg1 );
	[DllImport(Lib_ComDlg32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("commdlg.h", MSDNShortId = "NF:commdlg.GetSaveFileNameA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetSaveFileName(ref OPENFILENAME Arg1);

	/// <summary>
	/// Creates a <c>Page Setup</c> dialog box that enables the user to specify the attributes of a printed page. These attributes
	/// include the paper size and source, the page orientation (portrait or landscape), and the width of the page margins.
	/// </summary>
	/// <param name="lppsd">
	/// <para>[in, out] Type: <c>LPPAGESETUPDLG</c></para>
	/// <para>
	/// A pointer to a <c>PAGESETUPDLG</c> structure that contains information used to initialize the dialog box. The structure receives
	/// information about the user's selections when the function returns.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If the user clicks the <c>OK</c> button, the return value is nonzero. The members of the <c>PAGESETUPDLG</c> structure pointed
	/// to by the lppsd parameter indicate the user's selections.
	/// </para>
	/// <para>
	/// If the user cancels or closes the <c>Page Setup</c> dialog box or an error occurs, the return value is zero. To get extended
	/// error information, use the <c>CommDlgExtendedError</c> function
	/// </para>
	/// <para>
	/// Note that the values of <c>hDevMode</c> and <c>hDevNames</c> in <c>PAGESETUPDLG</c> may change when they are passed into
	/// <c>PageSetupDlg</c>. This is because these members are filled on both input and output.
	/// </para>
	/// </returns>
	/// <remarks>
	/// Starting with Windows Vista, the <c>PageSetupDlg</c> does not contain the <c>Printer</c> button. To switch printer selection,
	/// use <c>PrintDlg</c> or <c>PrintDlgEx</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms646937(v=vs.85) BOOL WINAPI PageSetupDlg( _Inout_
	// LPPAGESETUPDLG lppsd );
	[DllImport(Lib_ComDlg32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("Commdlg.h")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PageSetupDlg(ref PAGESETUPDLG lppsd);

	/// <summary>
	/// <para>
	/// [ <c>PrintDlg</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. Instead, use <c>PrintDlgEx</c> or <c>PageSetupDlg</c>.]
	/// </para>
	/// <para>
	/// Displays a Print Dialog Box or a <c>Print Setup</c> dialog box. The <c>Print</c> dialog box enables the user to specify the
	/// properties of a particular print job.
	/// </para>
	/// </summary>
	/// <param name="lppd">
	/// <para>[in, out] Type: <c>LPPRINTDLG</c></para>
	/// <para>
	/// A pointer to a <c>PRINTDLG</c> structure that contains information used to initialize the dialog box. When <c>PrintDlg</c>
	/// returns, this structure contains information about the user's selections.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If the user clicks the <c>OK</c> button, the return value is nonzero. The members of the <c>PRINTDLG</c> structure pointed to by
	/// the lppd parameter indicate the user's selections.
	/// </para>
	/// <para>
	/// If the user canceled or closed the <c>Print</c> or <c>Printer Setup</c> dialog box or an error occurred, the return value is
	/// zero. To get extended error information, use the <c>CommDlgExtendedError</c> function. If the user canceled or closed the dialog
	/// box, <c>CommDlgExtendedError</c> returns zero; otherwise, it returns one of the following values.
	/// </para>
	/// <para><c>CDERR_FINDRESFAILURE</c></para>
	/// <para><c>CDERR_INITIALIZATION</c></para>
	/// <para><c>CDERR_LOADRESFAILURE</c></para>
	/// <para><c>CDERR_LOADSTRFAILURE</c></para>
	/// <para><c>CDERR_LOCKRESFAILURE</c></para>
	/// <para><c>CDERR_MEMALLOCFAILURE</c></para>
	/// <para><c>CDERR_MEMLOCKFAILURE</c></para>
	/// <para><c>CDERR_NOHINSTANCE</c></para>
	/// <para><c>CDERR_NOHOOK</c></para>
	/// <para><c>CDERR_NOTEMPLATE</c></para>
	/// <para><c>CDERR_STRUCTSIZE</c></para>
	/// <para><c>PDERR_CREATEICFAILURE</c></para>
	/// <para><c>PDERR_DEFAULTDIFFERENT</c></para>
	/// <para><c>PDERR_DNDMMISMATCH</c></para>
	/// <para><c>PDERR_GETDEVMODEFAIL</c></para>
	/// <para><c>PDERR_INITFAILURE</c></para>
	/// <para><c>PDERR_LOADDRVFAILURE</c></para>
	/// <para><c>PDERR_NODEFAULTPRN</c></para>
	/// <para><c>PDERR_NODEVICES</c></para>
	/// <para><c>PDERR_PARSEFAILURE</c></para>
	/// <para><c>PDERR_PRINTERNOTFOUND</c></para>
	/// <para><c>PDERR_RETDEFFAILURE</c></para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the hook procedure (pointed to by the <c>lpfnPrintHook</c> or <c>lpfnSetupHook</c> member of the <c>PRINTDLG</c> structure)
	/// processes the <c>WM_CTLCOLORDLG</c> message, the hook procedure must return a handle to the brush that should be used to paint
	/// the control background.
	/// </para>
	/// <para>
	/// Note that the values of <c>hDevMode</c> and <c>hDevNames</c> in <c>PRINTDLG</c> may change when they are passed into
	/// <c>PrintDlg</c>. This is because these members are filled on both input and output.
	/// </para>
	/// <para>To switch printer selection, use <c>PrintDlg</c> or <c>PrintDlgEx</c>.</para>
	/// <para><c>Windows Server 2003, Windows XP, and Windows 2000:</c> To switch printer selection, use the <c>Printer</c> button</para>
	/// <para>
	/// <c>Known issue:</c> If <c>PD_RETURNDC</c> is set but <c>PD_USEDEVMODECOPIESANDCOLLATE</c> flag is not set, the <c>PrintDlgEx</c>
	/// and <c>PrintDlg</c> functions return incorrect number of copies. To get the correct number of copies, ensure that the calling
	/// application always uses <c>PD_USEDEVMODECOPIESANDCOLLATE</c> with <c>PD_RETURNDC</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms646940(v=vs.85) BOOL WINAPI PrintDlg( _Inout_
	// LPPRINTDLG lppd );
	[DllImport(Lib_ComDlg32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("Commdlg.h")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PrintDlg(ref PRINTDLG lppd);

	/// <summary>
	/// Displays a <c>Print</c> property sheet that enables the user to specify the properties of a particular print job. A <c>Print</c>
	/// property sheet has a <c>General</c> page that contains controls similar to the <c>Print</c> dialog box. The property sheet can
	/// also have additional application-specific and driver-specific property pages as well as the <c>General</c> page.
	/// </summary>
	/// <param name="lppd">
	/// <para>[in, out] Type: <c>LPPRINTDLGEX</c></para>
	/// <para>
	/// A pointer to a <c>PRINTDLGEX</c> structure that contains information used to initialize the property sheet. When
	/// <c>PrintDlgEx</c> returns, this structure contains information about the user's selections.
	/// </para>
	/// <para>This structure must be declared dynamically using a memory allocation function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// If the function succeeds, the return value is <c>S_OK</c> and the <c>dwResultAction</c> member of the <c>PRINTDLGEX</c>
	/// structure contains one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PD_RESULT_APPLY 2</term>
	/// <term>
	/// The user clicked the Apply button and later clicked the Cancel button. This indicates that the user wants to apply the changes
	/// made in the property sheet, but does not yet want to print. The PRINTDLGEX structure contains the information specified by the
	/// user at the time the Apply button was clicked.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PD_RESULT_CANCEL 0</term>
	/// <term>The user clicked the Cancel button. The information in the PRINTDLGEX structure is unchanged.</term>
	/// </item>
	/// <item>
	/// <term>PD_RESULT_PRINT 1</term>
	/// <term>The user clicked the Print button. The PRINTDLGEX structure contains the information specified by the user.</term>
	/// </item>
	/// </list>
	/// <para>If the function fails, the return value may be one of the following COM error codes. For more information, see Error Handling.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments are invalid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>Invalid pointer.</term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>Invalid handle.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>Unspecified error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The values of <c>hDevMode</c> and <c>hDevNames</c> in <c>PRINTDLGEX</c> may change when they are passed into <c>PrintDlgEx</c>.
	/// This is because these members are filled on both input and output. Be sure to free the memory allocated for these members
	/// </para>
	/// <para>
	/// If <c>PD_RETURNDC</c> is set but <c>PD_USEDEVMODECOPIESANDCOLLATE</c> flag is not set, the <c>PrintDlg</c> and <c>PrintDlgEx</c>
	/// functions return incorrect number of copies. To get the correct number of copies, ensure that the calling application always
	/// uses <c>PD_USEDEVMODECOPIESANDCOLLATE</c> with <c>PD_RETURNDC</c>.
	/// </para>
	/// <para>For more information, see Print Property Sheet.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms646942(v=vs.85) HRESULT WINAPI PrintDlgEx( _Inout_
	// LPPRINTDLGEX lppd );
	[DllImport(Lib_ComDlg32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("Commdlg.h")]
	public static extern HRESULT PrintDlgEx(ref PRINTDLGEX lppd);

	/// <summary>
	/// Creates a system-defined modeless dialog box that lets the user specify a string to search for and a replacement string, as well
	/// as options to control the find and replace operations.
	/// </summary>
	/// <param name="Arg1">
	/// <para>Type: <c>LPFINDREPLACE</c></para>
	/// <para>
	/// A pointer to a FINDREPLACE structure that contains information used to initialize the dialog box. The dialog box uses this
	/// structure to send information about the user's input to your application. For more information, see the following Remarks section.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// If the function succeeds, the return value is the window handle to the dialog box. You can use the window handle to communicate
	/// with the dialog box or close it.
	/// </para>
	/// <para>
	/// If the function fails, the return value is <c>NULL</c>. To get extended error information, call the CommDlgExtendedError
	/// function, which can return one of the following error codes:
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ReplaceText</c> function does not perform a text replacement operation. Instead, the dialog box sends FINDMSGSTRING
	/// registered messages to the window procedure of the owner window of the dialog box. When you create the dialog box, the
	/// <c>hwndOwner</c> member of the FINDREPLACE structure is a handle to the owner window.
	/// </para>
	/// <para>
	/// Before calling <c>ReplaceText</c>, you must call the RegisterWindowMessage function to get the identifier for the FINDMSGSTRING
	/// message. The dialog box procedure uses this identifier to send messages when the user clicks the <c>Find Next</c>,
	/// <c>Replace</c>, or <c>Replace All</c> buttons, or when the dialog box is closing. The lParam parameter of a <c>FINDMSGSTRING</c>
	/// message contains a pointer to the FINDREPLACE structure. The <c>Flags</c> member of this structure indicates the event that
	/// caused the message. Other members of the structure indicate the user's input.
	/// </para>
	/// <para>
	/// If you create a <c>Replace</c> dialog box, you must also use the IsDialogMessage function in the main message loop of your
	/// application to ensure that the dialog box correctly processes keyboard input, such as the TAB and ESC keys. The
	/// <c>IsDialogMessage</c> function returns a value that indicates whether the Replace dialog box processed the message.
	/// </para>
	/// <para>
	/// You can provide an FRHookProc hook procedure for a <c>Replace</c> dialog box. The hook procedure can process messages sent to
	/// the dialog box. To enable a hook procedure, set the <c>FR_ENABLEHOOK</c> flag in the <c>Flags</c> member of the FINDREPLACE
	/// structure and specify the address of the hook procedure in the <c>lpfnHook</c> member.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-replacetexta HWND ReplaceTextA( LPFINDREPLACEA Arg1 );
	[DllImport(Lib_ComDlg32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("commdlg.h", MSDNShortId = "NF:commdlg.ReplaceTextA")]
	public static extern HWND ReplaceText(ref FINDREPLACE Arg1);
}