using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Macros;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

public static partial class ComCtl32
{
	/// <summary>
	/// Display the elevated icon on the buttons specified in lParam. The elevated icon (or UAC shield icon) indicates that the elevation
	/// prompt will be used to prompt the user for approval or credentials. For more information, see Designing UAC Applications for Windows Vista.
	/// </summary>
	public const int PSWIZBF_ELEVATIONREQUIRED = 0x00000001;

	/// <summary>
	/// A page sent the PSM_REBOOTSYSTEM message to the property sheet. The computer must be restarted for the user's changes to take effect.
	/// </summary>
	public static readonly IntPtr ID_PSREBOOTSYSTEM = (IntPtr)3;

	/// <summary>
	/// A page sent the PSM_RESTARTWINDOWS message to the property sheet. Windows must be restarted for the user's changes to take effect.
	/// </summary>
	public static readonly IntPtr ID_PSRESTARTWINDOWS = (IntPtr)2;

	private const int PSN_FIRST = -200;

	/// <summary>Specifies an application-defined callback function that a property sheet extension uses to add a page to a property sheet.</summary>
	/// <param name="hpage">
	/// <para>Type: <c>HPROPSHEETPAGE</c></para>
	/// <para>Handle to a property sheet page.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c><c>LPARAM</c></c></para>
	/// <para>Application-defined 32-bit value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
	/// </returns>
	// BOOL CALLBACK AddPropSheetPageProc( HPROPSHEETPAGE hpage, LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/bb760805(v=vs.85).aspx
	[PInvokeData("Prsht.h", MSDNShortId = "bb760805")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool AddPropSheetPageProc(IntPtr hpage, IntPtr lParam);

	/// <summary>
	/// Specifies an application-defined callback function that a property sheet calls when a page is created and when it is about to be
	/// destroyed. An application can use this function to perform initialization and cleanup operations for the page.
	/// </summary>
	/// <param name="hwnd">Reserved; must be NULL.</param>
	/// <param name="uMsg">Action flag.</param>
	/// <param name="ppsp">
	/// Pointer to a PROPSHEETPAGE structure that defines the page being created or destroyed. See the Remarks section for further discussion.
	/// </param>
	/// <returns>The return value depends on the value of the uMsg parameter.</returns>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760813")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
	public delegate uint PropSheetPageProc(HWND hwnd, PropSheetPageCallbackAction uMsg, PROPSHEETPAGE ppsp);

	/// <summary>An application-defined callback function that the system calls when the property sheet is being created and initialized.</summary>
	/// <param name="hwndDlg">Handle to the property sheet dialog box.</param>
	/// <param name="uMsg">
	/// Message being received. This parameter is one of the following values.
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PSCB_BUTTONPRESSED</term>
	/// <term>
	/// Version 6.0 and later.Indicates the user pressed a button in the property sheet dialog box.To enable this, specify PSH_USECALLBACK in
	/// PROPSHEETHEADER.dwFlags and specify the name of this callback function in PROPSHEETHEADER.pfnCallback. The lParam value is one of the
	/// following. Note that only PSBTN_CANCEL is valid when you are using the Aero wizard style(PSH_AEROWIZARD).
	/// <list type="table">
	/// <listheader>
	/// <term>Button pressed</term>
	/// <term>lParam value</term>
	/// </listheader>
	/// <item>
	/// <term>OK</term>
	/// <term>PSBTN_OK</term>
	/// </item>
	/// <item>
	/// <term>Cancel</term>
	/// <term>PSBTN_CANCEL</term>
	/// </item>
	/// <item>
	/// <term>Apply</term>
	/// <term>PSBTN_APPLYNOW</term>
	/// </item>
	/// <item>
	/// <term>Close</term>
	/// <term>PSBTN_FINISH</term>
	/// </item>
	/// </list>
	/// <para>
	/// Note that Comctl32.dll versions 6 and later are not redistributable.To use these versions of Comctl32.dll, specify the particular
	/// version in a manifest. For more information on manifests, see Enabling Visual Styles.
	/// </para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>PSCB_INITIALIZED</term>
	/// <term>Indicates that the property sheet is being initialized. The lParam value is zero for this message.</term>
	/// </item>
	/// <item>
	/// <term>PSCB_PRECREATE</term>
	/// <term>
	/// Indicates that the property sheet is about to be created. The hwndDlg parameter is NULL, and the lParam parameter is the address of a
	/// dialog template in memory.This template is in the form of a DLGTEMPLATE or DLGTEMPLATEEX structure followed by one or more
	/// DLGITEMTEMPLATE structures.This message is not applicable if you are using the Aero wizard style(PSH_AEROWIZARD).
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lParam">
	/// Additional information about the message. The meaning of this value depends on the uMsg parameter.
	/// <para>If uMsg is PSCB_INITIALIZED or PSCB_BUTTONPRESSED, the value of lParam is zero.</para>
	/// <para>
	/// If uMsg is PSCB_PRECREATE, then lParam will be a pointer to either a DLGTEMPLATE or DLGTEMPLATEEX structure describing the property
	/// sheet dialog box. Test the signature of the structure to determine the type. If signature is equal to 0xFFFF then the structure is an
	/// extended dialog template, otherwise the structure is a standard dialog template.
	/// </para>
	/// </param>
	/// <returns>Returns zero.</returns>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760815")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
	public delegate int PropSheetProc(HWND hwndDlg, PropSheetCallbackMessage uMsg, IntPtr lParam);

	/// <summary>Message being received.This parameter is one of the following values.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760815")]
	public enum PropSheetCallbackMessage
	{
		/// <summary>
		/// Version 6.0 and later.Indicates the user pressed a button in the property sheet dialog box.To enable this, specify
		/// PSH_USECALLBACK in PROPSHEETHEADER.dwFlags and specify the name of this callback function in PROPSHEETHEADER.pfnCallback. The
		/// lParam value is one of the following. Note that only PSBTN_CANCEL is valid when you are using the Aero wizard style(PSH_AEROWIZARD).
		/// <list type="table">
		/// <listheader>
		/// <term>Button pressed</term>
		/// <term>lParam value</term>
		/// </listheader>
		/// <item>
		/// <term>OK</term>
		/// <term>PSBTN_OK</term>
		/// </item>
		/// <item>
		/// <term>Cancel</term>
		/// <term>PSBTN_CANCEL</term>
		/// </item>
		/// <item>
		/// <term>Apply</term>
		/// <term>PSBTN_APPLYNOW</term>
		/// </item>
		/// <item>
		/// <term>Close</term>
		/// <term>PSBTN_FINISH</term>
		/// </item>
		/// </list>
		/// </summary>
		PSCB_BUTTONPRESSED = 3,

		/// <summary>Indicates that the property sheet is being initialized. The lParam value is zero for this message.</summary>
		PSCB_INITIALIZED = 1,

		/// <summary>
		/// Indicates that the property sheet is about to be created. The hwndDlg parameter is NULL, and the lParam parameter is the address
		/// of a dialog template in memory. This template is in the form of a DLGTEMPLATE or DLGTEMPLATEEX structure followed by one or more
		/// DLGITEMTEMPLATE structures. This message is not applicable if you are using the Aero wizard style (PSH_AEROWIZARD).
		/// </summary>
		PSCB_PRECREATE = 2
	}

	/// <summary>Flags used by the <see cref="PROPSHEETPAGE.dwFlags"/> field.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774548")]
	[Flags]
	public enum PropSheetFlags : uint
	{
		/// <summary>Uses the default meaning for all structure members. This flag is not supported when using the Aero-style wizard (PSH_AEROWIZARD).</summary>
		PSP_DEFAULT = 0x0,

		/// <summary>
		/// Creates the page from the dialog box template in memory pointed to by the pResource member. The PropertySheet function assumes
		/// that the template that is in memory is not write-protected. A read-only template will cause an exception in some versions of Windows.
		/// </summary>
		PSP_DLGINDIRECT = 0x1,

		/// <summary>
		/// Enables the property sheet Help button when the page is active. This flag is not supported when using the Aero-style wizard (PSH_AEROWIZARD).
		/// </summary>
		PSP_HASHELP = 0x20,

		/// <summary>
		/// Version 5.80 and later. Causes the wizard property sheet to hide the header area when the page is selected. If a watermark has
		/// been provided, it will be painted on the left side of the page. This flag should be set for welcome and completion pages, and
		/// omitted for interior pages. This flag is not supported when using the Aero-style wizard (PSH_AEROWIZARD).
		/// </summary>
		PSP_HIDEHEADER = 0x800,

		/// <summary>
		/// Version 4.71 or later. Causes the page to be created when the property sheet is created. If this flag is not specified, the page
		/// will not be created until it is selected the first time. This flag is not supported when using the Aero-style wizard (PSH_AEROWIZARD).
		/// </summary>
		PSP_PREMATURE = 0x400,

		/// <summary>
		/// Reverses the direction in which pszTitle is displayed. Normal windows display all text, including pszTitle, left-to-right (LTR).
		/// For languages such as Hebrew or Arabic that read right-to-left (RTL), a window can be mirrored and all text will be displayed
		/// RTL. If PSP_RTLREADING is set, pszTitle will instead read RTL in a normal parent window, and LTR in a mirrored parent window.
		/// </summary>
		PSP_RTLREADING = 0x10,

		/// <summary>
		/// Calls the function specified by the pfnCallback member when creating or destroying the property sheet page defined by this structure.
		/// </summary>
		PSP_USECALLBACK = 0x80,

		/// <summary>
		/// Version 6.0 and later. Use an activation context. To use an activation context, you must set this flag and assign the activation
		/// context handle to hActCtx. See the Remarks.
		/// </summary>
		PSP_USEFUSIONCONTEXT = 0x4000,

		/// <summary>
		/// Version 5.80 or later. Displays the string pointed to by the pszHeaderSubTitle member as the subtitle of the header area of a
		/// Wizard97 page. To use this flag, you must also set the PSH_WIZARD97 flag in the dwFlags member of the associated PROPSHEETHEADER
		/// structure. The PSP_USEHEADERSUBTITLE flag is ignored if PSP_HIDEHEADER is set. In Aero-style wizards, the title appears near the
		/// top of the client area.
		/// </summary>
		PSP_USEHEADERSUBTITLE = 0x2000,

		/// <summary>
		/// Version 5.80 or later. Displays the string pointed to by the pszHeaderTitle member as the title in the header of a Wizard97
		/// interior page. You must also set the PSH_WIZARD97 flag in the dwFlags member of the associated PROPSHEETHEADER structure. The
		/// PSP_USEHEADERTITLE flag is ignored if PSP_HIDEHEADER is set. This flag is not supported when using the Aero-style wizard (PSH_AEROWIZARD).
		/// </summary>
		PSP_USEHEADERTITLE = 0x1000,

		/// <summary>
		/// Uses hIcon as the small icon on the tab for the page. This flag is not supported when using the Aero-style wizard (PSH_AEROWIZARD).
		/// </summary>
		PSP_USEHICON = 0x2,

		/// <summary>
		/// Uses pszIcon as the name of the icon resource to load and use as the small icon on the tab for the page. This flag is not
		/// supported when using the Aero-style wizard (PSH_AEROWIZARD).
		/// </summary>
		PSP_USEICONID = 0x4,

		/// <summary>
		/// Maintains the reference count specified by the pcRefParent member for the lifetime of the property sheet page created from this structure.
		/// </summary>
		PSP_USEREFPARENT = 0x40,

		/// <summary>
		/// Uses the pszTitle member as the title of the property sheet dialog box instead of the title stored in the dialog box template.
		/// This flag is not supported when using the Aero-style wizard (PSH_AEROWIZARD).
		/// </summary>
		PSP_USETITLE = 0x8,
	}

	/// <summary>Flags used by the <see cref="PROPSHEETHEADER.dwFlags"/> field.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774546")]
	[Flags]
	public enum PropSheetHeaderFlags : uint
	{
		/// <summary>
		/// Uses the default meaning for all structure members, and creates a normal property sheet. This flag has a value of zero and is not
		/// combined with other flags.
		/// </summary>
		PSH_DEFAULT = 0x00000000,

		/// <summary>
		/// Version 6.00 and Windows Vista.. Creates a wizard property sheet that uses the newer Aero style. The PSH_WIZARD flag must also be
		/// set. The single-threaded apartment (STA) model must be used.
		/// </summary>
		PSH_AEROWIZARD = 0x00004000,

		/// <summary>
		/// Permits property sheet pages to display a Help button. You must also set the PSP_HASHELP flag in the page's PROPSHEETPAGE
		/// structure when the page is created. If any of the initial property sheet pages enable a Help button, PSH_HASHELP will be set
		/// automatically. If none of the initial pages enable a Help button, you must explicitly set PSH_HASHELP if you want to have Help
		/// buttons on any pages that might be added later. This flag is not supported in conjunction with PSH_AEROWIZARD.
		/// </summary>
		PSH_HASHELP = 0x00000200,

		/// <summary>
		/// Version 5.80 and later. Indicates that a header bitmap will be used with a Wizard97 wizard. You must also set the PSH_WIZARD97
		/// flag. The header bitmap is obtained from the pszbmHeader member, unless the PSH_USEHBMHEADER flag is also set. In that case, the
		/// header bitmap is obtained from the hbmHeader member. This flag is not supported in conjunction with PSH_AEROWIZARD.
		/// </summary>
		PSH_HEADER = 0x00080000,

		/// <summary>
		/// Version 6.00 and Windows Vista..The pszbmHeader member specifies a bitmap that is displayed in the header area. Must be used in
		/// combination with PSH_AEROWIZARD.
		/// </summary>
		PSH_HEADERBITMAP = 0x08000000,

		/// <summary>
		/// Causes the PropertySheet function to create the property sheet as a modeless dialog box instead of as a modal dialog box. When
		/// this flag is set, PropertySheet returns immediately after the dialog box is created, and the return value from PropertySheet is
		/// the window handle to the property sheet dialog box. This flag is not supported in conjunction with PSH_AEROWIZARD.
		/// </summary>
		PSH_MODELESS = 0x00000400,

		/// <summary>Removes the Apply button. This flag is not supported in conjunction with PSH_AEROWIZARD.</summary>
		PSH_NOAPPLYNOW = 0x00000080,

		/// <summary>
		/// Version 5.80 and later. Removes the context-sensitive Help button ("?"), which is usually present on the caption bar of property
		/// sheets. This flag is not valid for wizards. See About Property Sheets for a discussion of how to remove the caption bar Help
		/// button for earlier versions of the common controls. This flag is not supported in conjunction with PSH_AEROWIZARD.
		/// </summary>
		PSH_NOCONTEXTHELP = 0x02000000,

		/// <summary>
		/// Version 6.00 and Windows Vista.. Specifies that no margin is inserted between the page and the frame. Must be used in combination
		/// with PSH_AEROWIZARD.
		/// </summary>
		PSH_NOMARGIN = 0x10000000,

		/// <summary>Uses the ppsp member and ignores the phpage member when creating the pages for the property sheet.</summary>
		PSH_PROPSHEETPAGE = 0x00000008,

		/// <summary>
		/// Displays a title in the title bar of the property sheet. The title takes the appropriate form for the Windows version. In more
		/// recent versions of Windows, the title is the string specified by the pszCaption followed by the string "Properties". In older
		/// versions of Windows, the title is the string "Properties for", followed by the string specified by the pszCaption member. This
		/// flag is not supported for wizards.
		/// </summary>
		PSH_PROPTITLE = 0x00000001,

		/// <summary>
		/// Allows the wizard to be resized by the user. Maximize and minimize buttons appear in the wizard's frame and the frame is sizable.
		/// To use this flag, you must also set PSH_AEROWIZARD.
		/// </summary>
		PSH_RESIZABLE = 0x04000000,

		/// <summary>
		/// Displays the title of the property sheet (pszCaption) using right-to-left (RTL) reading order for Hebrew or Arabic languages. If
		/// this flag is not specified, the title is displayed in left-to-right (LTR) reading order.
		/// </summary>
		PSH_RTLREADING = 0x00000800,

		/// <summary>
		/// Stretches the watermark in Internet Explorer 4.0-compatible Wizard97-style wizards. This flag is not supported in conjunction
		/// with PSH_AEROWIZARD. <note>This style flag is only included to provide backward compatibility for certain applications. Its use
		/// is not recommended, and it is only supported by common controls versions 4.0 and 4.01. With common controls version 5.80 and
		/// later, this flag is ignored.</note>
		/// </summary>
		PSH_STRETCHWATERMARK = 0x00040000,

		/// <summary>Calls the function specified by the pfnCallback member when initializing the property sheet defined by this structure.</summary>
		PSH_USECALLBACK = 0x00000100,

		/// <summary>
		/// Version 5.80 or later. Obtains the header bitmap from the hbmHeader member instead of the pszbmHeader member. You must also set
		/// either the PSH_AEROWIZARD flag or the PSH_WIZARD97 flag together with the PSH_HEADER flag.
		/// </summary>
		PSH_USEHBMHEADER = 0x00100000,

		/// <summary>
		/// Version 5.80 or later. Obtains the watermark bitmap from the hbmWatermark member instead of the pszbmWatermark member. You must
		/// also set PSH_WIZARD97 and PSH_WATERMARK. This flag is not supported in conjunction with PSH_AEROWIZARD.
		/// </summary>
		PSH_USEHBMWATERMARK = 0x00010000,

		/// <summary>Uses hIcon as the small icon in the title bar of the property sheet dialog box.</summary>
		PSH_USEHICON = 0x00000002,

		/// <summary>
		/// Version 5.80 or later. Uses the HPALETTE structure pointed to by the hplWatermark member instead of the default palette to draw
		/// the watermark bitmap and/or header bitmap for a Wizard97 wizard. You must also set PSH_WIZARD97, and PSH_WATERMARK or PSH_HEADER.
		/// This flag is not supported in conjunction with PSH_AEROWIZARD.
		/// </summary>
		PSH_USEHPLWATERMARK = 0x00020000,

		/// <summary>
		/// Uses pszIcon as the name of the icon resource to load and use as the small icon in the title bar of the property sheet dialog box.
		/// </summary>
		PSH_USEICONID = 0x00000004,

		/// <summary>
		/// Version 5.80 or later. Specifies that the language for the property sheet will be taken from the first page's resource. That page
		/// must be specified by resource identifier.
		/// </summary>
		PSH_USEPAGELANG = 0x00200000,

		/// <summary>Uses the pStartPage member instead of the nStartPage member when displaying the initial page of the property sheet.</summary>
		PSH_USEPSTARTPAGE = 0x00000040,

		/// <summary>
		/// Version 5.80 or later. Specifies that a watermark bitmap will be used with a Wizard97 wizard on pages that have the
		/// PSP_HIDEHEADER style. You must also set the PSH_WIZARD97 flag. The watermark bitmap is obtained from the pszbmWatermark member,
		/// unless PSH_USEHBMWATERMARK is set. In that case, the header bitmap is obtained from the hbmWatermark member. This flag is not
		/// supported in conjunction with PSH_AEROWIZARD.
		/// </summary>
		PSH_WATERMARK = 0x00008000,

		/// <summary>Creates a wizard property sheet. When using PSH_AEROWIZARD, you must also set this flag.</summary>
		PSH_WIZARD = 0x00000020,

		/// <summary>
		/// Version 5.80 or later. Creates a Wizard97-style property sheet, which supports bitmaps in the header of interior pages and on the
		/// left side of exterior pages. This flag is not supported in conjunction with PSH_AEROWIZARD.
		/// </summary>
		PSH_WIZARD97 = 0x00002000,

		/// <summary>
		/// Adds a context-sensitive Help button ("?"), which is usually absent from the caption bar of a wizard. This flag is not valid for
		/// regular property sheets. This flag is not supported in conjunction with PSH_AEROWIZARD.
		/// </summary>
		PSH_WIZARDCONTEXTHELP = 0x00001000,

		/// <summary>Always displays the Finish button on the wizard. You must also set either PSH_WIZARD, PSH_WIZARD97, or PSH_AEROWIZARD.</summary>
		PSH_WIZARDHASFINISH = 0x00000010,

		/// <summary>
		/// Version 5.80 or later. Uses the Wizard-lite style. This style is similar in appearance to PSH_WIZARD97, but it is implemented
		/// much like PSH_WIZARD. There are few restrictions on how the pages are formatted. For instance, there are no enforced borders, and
		/// the PSH_WIZARD_LITE style does not paint the watermark and header bitmaps for you the way Wizard97 does. This flag is not
		/// supported in conjunction with PSH_AEROWIZARD.
		/// </summary>
		PSH_WIZARD_LITE = 0x00400000,
	}

	/// <summary>Window messages for property sheets.</summary>
	[PInvokeData("prsht.h")]
	public enum PropSheetMessage : uint
	{
		/// <summary>
		/// <para>
		/// Shows or hides buttons in a wizard. You can send this message explicitly or by using the <c>PropSheet_ShowWizButtons</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// One or more of the following values that specify which property sheet buttons are to be shown. If a button value is included in
		/// both this parameter and lParam, it is shown.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>PSWIZB_BACK</c></description>
		/// <description>The <c>Back</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_CANCEL</c></description>
		/// <description>The <c>Cancel</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_DISABLEDFINISH</c></description>
		/// <description>The <c>Finish</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_FINISH</c></description>
		/// <description>The <c>Finish</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_NEXT</c></description>
		/// <description>The <c>Next</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_SHOW</c></description>
		/// <description>Set only this flag (defined as zero) to hide all buttons specified in <c>lParam</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_RESTORE</c></description>
		/// <description>Not implemented.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// One or more of the same values used in wParam, specifying which buttons are affected by this call. If a button value appears in
		/// this parameter but not in wParam, the button is hidden.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Wizards display either three or four buttons below each page. This message is used to specify which buttons are visible. Wizards
		/// normally display <c>Back</c>, <c>Cancel</c>, and either a <c>Next</c> or <c>Finish</c> button. The <c>Cancel</c> button is always visible.
		/// </para>
		/// <para>
		/// Typically, set <c>PSWIZB_FINISH</c> or <c>PSWIZB_DISABLEDFINISH</c> to replace the <c>Next</c> button with a <c>Finish</c>
		/// button. To display <c>Next</c> and <c>Finish</c> buttons simultaneously, set the <c>PSH_WIZARDHASFINISH</c> flag in the
		/// <c>dwFlags</c> member of the <c>PROPSHEETHEADER</c> structure when you create the wizard. Every page will then display all four
		/// buttons: <c>Back</c>, <c>Next</c>, <c>Cancel</c>, and <c>Finish</c>.
		/// </para>
		/// <para>
		/// If you use the <c>PropSheet_ShowWizButtons</c> macro to send this message, it will be posted. At any other time, you can use
		/// <c>SendMessage</c> to send <c>PSM_SHOWWIZBUTTONS</c>.
		/// </para>
		/// <para>
		/// If your notification handler uses <c>PostMessage</c> to send a <c>PSM_SHOWWIZBUTTONS</c> message, do nothing that will affect
		/// window focus until after the handler returns. For example, if you call <c>MessageBox</c> immediately after using
		/// <c>PostMessage</c> to send <c>PSM_SHOWWIZBUTTONS</c>, the message box will receive focus. Since posted messages are not delivered
		/// until they reach the head of the message queue, the <c>PSM_SHOWWIZBUTTONS</c> message will not be delivered until after the
		/// wizard has lost focus to the message box. As a result, the property sheet will not be able to properly set the focus for the buttons.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-showwizbuttons
		[MsgParams(typeof(PSWIZB), typeof(PSWIZB))]
		PSM_SHOWWIZBUTTONS = WM_USER + 138,

		/// <summary>
		/// <para>
		/// Simulates the selection of a property sheet button. You can send this message explicitly or by using the
		/// <c>PropSheet_PressButton</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Index of the button to select. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>PSBTN_APPLYNOW</c></description>
		/// <description>Selects the <c>Apply</c> button. This value is not valid when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</description>
		/// </item>
		/// <item>
		/// <description><c>PSBTN_BACK</c></description>
		/// <description>Selects the <c>Back</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSBTN_CANCEL</c></description>
		/// <description>Selects the <c>Cancel</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSBTN_FINISH</c></description>
		/// <description>Selects the <c>Finish</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSBTN_HELP</c></description>
		/// <description>Selects the <c>Help</c> button. This value is not valid when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</description>
		/// </item>
		/// <item>
		/// <description><c>PSBTN_NEXT</c></description>
		/// <description>Selects the <c>Next</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSBTN_OK</c></description>
		/// <description>Selects the <c>OK</c> button. This value is not valid when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-pressbutton
		[MsgParams(typeof(PSBTN), null)]
		PSM_PRESSBUTTON = WM_USER + 113,

		/// <summary>
		/// <para>
		/// Activates the specified page in a property sheet. You can send this message explicitly or by using the <c>PropSheet_SetCurSel</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The zero-based index of the page. An application can specify the index or the handle or both. If both are specified, lParam takes precedence.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The handle to the page to activate. An application can specify the index or the handle or both. If both are specified, lParam
		/// takes precedence.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// The window that is losing the activation receives the PSN_KILLACTIVE notification code, and the window that is gaining the
		/// activation receives the PSN_SETACTIVE notification code.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-setcursel
		[MsgParams(typeof(uint), typeof(HPROPSHEETPAGE), LResultType = typeof(BOOL))]
		PSM_SETCURSEL = WM_USER + 101,

		/// <summary>
		/// <para>
		/// Removes a page from a property sheet. You can send this message explicitly or by using the <c>PropSheet_RemovePage</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the page to be removed.</para>
		/// <para><em>lParam</em></para>
		/// <para>The HPROPSHEETPAGE handle of the page to be removed.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>An application can specify the index or the handle, or both. If both are specified, lParam takes precedence.</para>
		/// <para>Sending <c>PSM_REMOVEPAGE</c> destroys the property sheet page that is being removed.</para>
		/// <para>
		/// A number of messages and one function call occur while the property sheet is manipulating the list of pages. While this action is
		/// taking place, attempting to modify the list of pages will have unpredictable results. Accordingly, you should not use the
		/// <c>PSM_REMOVEPAGE</c> message in your implementation of PropSheetPageProc or while handling the following notifications and
		/// Windows messages.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>PSN_APPLY</description>
		/// </item>
		/// <item>
		/// <description>PSN_KILLACTIVE</description>
		/// </item>
		/// <item>
		/// <description>PSN_RESET</description>
		/// </item>
		/// <item>
		/// <description>PSN_SETACTIVE</description>
		/// </item>
		/// <item>
		/// <description><c>WM_DESTROY</c></description>
		/// </item>
		/// <item>
		/// <description><c>WM_INITDIALOG</c></description>
		/// </item>
		/// </list>
		/// <para>
		/// If you need to modify a property sheet page while you are handling one of these messages or while PropSheetPageProc is in
		/// operation, post yourself a private Windows message. Your application will not receive that message until after the property sheet
		/// manager has finished its tasks. Then you can modify the list of pages.
		/// </para>
		/// <para>The following notifications are also affected by property sheet modification.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>PSN_WIZBACK</description>
		/// </item>
		/// <item>
		/// <description>PSN_WIZNEXT</description>
		/// </item>
		/// </list>
		/// <para>
		/// You can add or remove pages in response to these notifications, provided that you return (via DWL_MSGRESULT) a nonzero value to
		/// specify the desired new page. Note, however, that if you remove a page that is located before the current page (that has a
		/// smaller index than the current page), PSN_KILLACTIVE might be sent to the wrong page.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-removepage
		[MsgParams(typeof(uint), typeof(HPROPSHEETPAGE))]
		PSM_REMOVEPAGE = WM_USER + 102,

		/// <summary>
		/// <para>
		/// Adds a new page to the end of an existing property sheet. You can send this message explicitly or by using the
		/// <c>PropSheet_AddPage</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the page to add. The page must have been created by a previous call to the <c>CreatePropertySheetPage</c> function.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The new page should be no larger than the largest page currently in the property sheet because the property sheet is not resized
		/// to fit the new page.
		/// </para>
		/// <para>
		/// A number of messages and one function call occur while the property sheet is manipulating the list of pages. While this action is
		/// taking place, attempting to modify the list of pages will have unpredictable results. Accordingly, you should not use the
		/// PSM_ADDPAGE message in your implementation of PropSheetPageProc or while handling the following notifications and Windows messages.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>PSN_APPLY</description>
		/// </item>
		/// <item>
		/// <description>PSN_KILLACTIVE</description>
		/// </item>
		/// <item>
		/// <description>PSN_RESET</description>
		/// </item>
		/// <item>
		/// <description>PSN_SETACTIVE</description>
		/// </item>
		/// <item>
		/// <description><c>WM_DESTROY</c></description>
		/// </item>
		/// <item>
		/// <description><c>WM_INITDIALOG</c></description>
		/// </item>
		/// </list>
		/// <para>
		/// If you need to modify a property sheet page while you are handling one of these messages or while PropSheetPageProc is in
		/// operation, post yourself a private Windows message. Your application will not receive that message until after the property sheet
		/// manager has finished its tasks. Then you can modify the list of pages.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-addpage
		[MsgParams(null, typeof(HPROPSHEETPAGE), LResultType = typeof(BOOL))]
		PSM_ADDPAGE = WM_USER + 103,

		/// <summary>
		/// <para>
		/// Informs a property sheet that information in a page has changed. You can send this message explicitly or by using the
		/// <c>PropSheet_Changed</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to the page that has changed.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>The property sheet will enable the <c>Apply</c> button.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-changed
		[MsgParams(typeof(HPROPSHEETPAGE), null)]
		PSM_CHANGED = WM_USER + 104,

		/// <summary>
		/// <para>Indicates that Windows needs to be restarted for the changes to take effect.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// An application should send this message only in response to the PSN_APPLY or PSN_KILLACTIVE notification code. You can send the
		/// <c>PSM_RESTARTWINDOWS</c> message explicitly or by using the <c>PropSheet_RestartWindows</c> macro.
		/// </para>
		/// <para>
		/// This message causes the <c>PropertySheet</c> function to return the ID_PSRESTARTWINDOWS value, but only if the user clicks the
		/// <c>OK</c> button to close the property sheet. It is the application's responsibility to restart Windows, which can be done by
		/// using the <c>ExitWindowsEx</c> function.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-restartwindows
		[MsgParams(null, null)]
		PSM_RESTARTWINDOWS = WM_USER + 105,

		/// <summary>
		/// <para>
		/// Indicates the system needs to be restarted for the changes to take effect. You can send the <c>PSM_REBOOTSYSTEM</c> message
		/// explicitly or by using the <c>PropSheet_RebootSystem</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>An application should send this message only in response to the PSN_APPLY or PSN_KILLACTIVE notification message.</para>
		/// <para>
		/// This message causes the <c>PropertySheet</c> function to return the ID_PSREBOOTSYSTEM value, but only if the user clicks the
		/// <c>OK</c> button to close the property sheet. It is the application's responsibility to reboot the system, which can be done by
		/// using the <c>ExitWindowsEx</c> function.
		/// </para>
		/// <para>This message supersedes all <c>PSM_RESTARTWINDOWS</c> messages that precede or follow it.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-rebootsystem
		[MsgParams(null, null)]
		PSM_REBOOTSYSTEM = WM_USER + 106,

		/// <summary>
		/// <para>
		/// Sent by an application when it has performed changes since the most recent PSN_APPLY notification that cannot be canceled. You
		/// can send this message explicitly or by using the <c>PropSheet_CancelToClose</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para><c>PSM_CANCELTOCLOSE</c> disables the <c>Cancel</c> button and changes the text of the <c>OK</c> button to "Close".</para>
		/// <para>
		/// Most property sheets wait to perform irreversible changes until a PSN_APPLY notification is received. However, in some
		/// circumstances, a property sheet may make irreversible changes outside the standard PSN_APPLY/PSN_RESET sequence. One example is a
		/// property sheet that contains an <c>Edit</c> button that is used to display a subdialog box for editing a property. When the user
		/// clicks <c>OK</c> to submit the change, the property sheet page has several options.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// It can record the changes, but wait until it receives a PSN_APPLY notification to apply them. This is the preferred approach.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// It can apply the changes immediately after exiting the subdialog box, but remember the original settings. Those settings can be
		/// used to restore the original state if a PSN_RESET notification is received.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// It can apply the changes immediately and not attempt to restore the original settings when it receives a PSN_RESET notification.
		/// This approach is not recommended, but may be necessary if the changes are too far-reaching for the other two options to be practical.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// For the third option, applications should send a <c>PSM_CANCELTOCLOSE</c> message to the property sheet. It indicates to the user
		/// that the changes made with the subdialog box cannot be reversed by clicking the <c>Cancel</c> button.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-canceltoclose
		[MsgParams(null, null)]
		PSM_CANCELTOCLOSE = WM_USER + 107,

		/// <summary>
		/// <para>
		/// Sent to a property sheet, which then forwards the message to each of its pages. You can send this message explicitly or by using
		/// the <c>PropSheet_QuerySiblings</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>First application-defined parameter.</para>
		/// <para><em>lParam</em></para>
		/// <para>Second application-defined parameter.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the nonzero value from a page in the property sheet, or zero if no page returns a nonzero value.</para>
		/// </summary>
		/// <remarks>If a page returns a nonzero value, the property sheet does not send the message to subsequent pages.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-querysiblings
		[MsgParams(typeof(IntPtr), typeof(IntPtr), LResultType = typeof(IntPtr))]
		PSM_QUERYSIBLINGS = WM_USER + 108,

		/// <summary>
		/// <para>
		/// Informs a property sheet that information in a page has reverted to the previously saved state. You can send this message
		/// explicitly or by using the <c>PropSheet_UnChanged</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to the page that has reverted to the previously saved state.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>The property sheet disables the <c>Apply</c> button if no other pages have registered changes with the property sheet.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-unchanged
		[MsgParams(typeof(HPROPSHEETPAGE), null)]
		PSM_UNCHANGED = WM_USER + 109,

		/// <summary>
		/// <para>
		/// Simulates the selection of the <c>Apply</c> button, indicating that one or more pages have changed and the changes need to be
		/// validated and recorded.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if all pages successfully applied the changes, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The property sheet sends the PSN_KILLACTIVE notification code to the current page. If the current page returns <c>FALSE</c>, the
		/// property sheet sends the PSN_APPLY notification code to all active pages. You can send the PSM_APPLY message explicitly or by
		/// using the <c>PropSheet_Apply</c> macro.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-apply
		[MsgParams(null, null, LResultType = typeof(BOOL))]
		PSM_APPLY = WM_USER + 110,

		/// <summary>
		/// <para>Sets the title of a property sheet. You can send this message explicitly or by using the <c>PropSheet_SetTitle</c> macro.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Flag that indicates whether to include the prefix "Properties for" or the suffix "Properties" (depending on the version) with the
		/// specified title string. If this value is PSH_PROPTITLE, the prefix or suffix is included.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a buffer that contains the title string. If the <c>HIWORD</c> of this parameter is <c>NULL</c>, the property sheet
		/// loads the string resource specified in the <c>LOWORD</c>.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// In an Aero Wizard, this message can be used to change the title of an interior page dynamically; for example, when handling the
		/// PSN_SETACTIVE notification.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-settitle
		[MsgParams(typeof(PropSheetHeaderFlags), typeof(ResourceId))]
		PSM_SETTITLEA = WM_USER + 111,

		/// <summary>
		/// <para>Sets the title of a property sheet. You can send this message explicitly or by using the <c>PropSheet_SetTitle</c> macro.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Flag that indicates whether to include the prefix "Properties for" or the suffix "Properties" (depending on the version) with the
		/// specified title string. If this value is PSH_PROPTITLE, the prefix or suffix is included.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a buffer that contains the title string. If the <c>HIWORD</c> of this parameter is <c>NULL</c>, the property sheet
		/// loads the string resource specified in the <c>LOWORD</c>.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// In an Aero Wizard, this message can be used to change the title of an interior page dynamically; for example, when handling the
		/// PSN_SETACTIVE notification.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-settitle
		[MsgParams(typeof(PropSheetHeaderFlags), typeof(ResourceId))]
		PSM_SETTITLEW = WM_USER + 120,

		/// <summary>
		/// <para>
		/// Enables or disables the <c>Back</c>, <c>Next</c>, and <c>Finish</c> buttons in a wizard. You can also use the
		/// <c>PropSheet_SetWizButtons</c> macro to post the message.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Set this parameter to PSWIZBF_ELEVATIONREQUIRED to display the elevated icon on the buttons specified in lParam. The elevated
		/// icon (or UAC shield icon) indicates that the elevation prompt will be used to prompt the user for approval or credentials. For
		/// more information, see Designing UAC Applications for Windows Vista.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>Displaying the UAC shield icon is only supported in AeroWizards (PSH_AEROWIZARD).</para>
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Value that specifies which property sheet buttons are enabled. You can combine one or more of the following flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>PSWIZB_BACK</c></description>
		/// <description>Enables the <c>Back</c> button. If this flag is not set, the <c>Back</c> button is displayed as disabled.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_DISABLEDFINISH</c></description>
		/// <description>Displays a disabled <c>Finish</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_FINISH</c></description>
		/// <description>Displays an enabled <c>Finish</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_NEXT</c></description>
		/// <description>Enables the <c>Next</c> button. If this flag is not set, the <c>Next</c> button is displayed as disabled.</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If your notification handler uses <c>PostMessage</c> to send a <c>PSM_SETWIZBUTTONS</c> message, do nothing that will affect
		/// window focus until after the handler returns. For example, if you call <c>MessageBox</c> immediately after using
		/// <c>PostMessage</c> to send <c>PSM_SETWIZBUTTONS</c>, the message box will receive focus. Since posted messages are not delivered
		/// until they reach the head of the message queue, the <c>PSM_SETWIZBUTTONS</c> message will not be delivered until after the wizard
		/// has lost focus to the message box. As a result, the property sheet will not be able to properly set the focus for the buttons.
		/// </para>
		/// <para>
		/// If you send the PSM_SETWIZBUTTONS message during your handling of the PSN_SETACTIVE notification, use the <c>PostMessage</c>
		/// function rather than the <c>SendMessage</c> function. Otherwise, the system will not update the buttons properly. If you use the
		/// <c>PropSheet_SetWizButtons</c> macro to send this message, it will be posted. At any other time, you can use <c>SendMessage</c>
		/// to send <c>PSM_SETWIZBUTTONS</c>.
		/// </para>
		/// <para>
		/// Wizards display either three or four buttons below each page. This message is used to specify which buttons are enabled. Wizards
		/// normally display <c>Back</c>, <c>Cancel</c>, and either a <c>Next</c> or <c>Finish</c> button. You typically enable only the
		/// <c>Next</c> button for the welcome page, <c>Next</c> and <c>Back</c> for interior pages, and <c>Back</c> and <c>Finish</c> for
		/// the completion page. The <c>Cancel</c> button is always enabled. Normally, setting PSWIZB_FINISH or PSWIZB_DISABLEDFINISH
		/// replaces the <c>Next</c> button with a <c>Finish</c> button. To display <c>Next</c> and <c>Finish</c> buttons simultaneously, set
		/// the PSH_WIZARDHASFINISH flag in the <c>dwFlags</c> member of the wizard's <c>PROPSHEETHEADER</c> structure when you create the
		/// wizard. Every page will then display all four buttons.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-setwizbuttons
		[MsgParams(typeof(int), typeof(PSWIZB))]
		PSM_SETWIZBUTTONS = WM_USER + 112,

		/// <summary>
		/// <para>
		/// Activates the given page in a property sheet based on the resource identifier of the page. You can send this message explicitly
		/// or by using the <c>PropSheet_SetCurSelByID</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Resource identifier of the page to activate.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// The window that is losing the activation receives the PSN_KILLACTIVE notification code, and the window that is gaining the
		/// activation receives the PSN_SETACTIVE notification code.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-setcurselid
		[MsgParams(null, typeof(ResourceId), LResultType = typeof(BOOL))]
		PSM_SETCURSELID = WM_USER + 114,

		/// <summary>
		/// <para>
		/// Sets the text of the <c>Finish</c> button in a wizard, shows and enables the button, and hides the <c>Next</c> and <c>Back</c>
		/// buttons. You can send this message explicitly or by using the <c>PropSheet_SetFinishText</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to the new text for the <c>Finish</c> button.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// By default, the <c>Finish</c> button does not have a keyboard accelerator. You can create a keyboard accelerator with this
		/// message by including an ampersand (&amp;) in the text string that you assign to lParam. For example, "&amp;Finish" defines F as
		/// the accelerator key.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-setfinishtext
		[MsgParams(null, typeof(string))]
		PSM_SETFINISHTEXTA = WM_USER + 115,

		/// <summary>
		/// <para>
		/// Sets the text of the <c>Finish</c> button in a wizard, shows and enables the button, and hides the <c>Next</c> and <c>Back</c>
		/// buttons. You can send this message explicitly or by using the <c>PropSheet_SetFinishText</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to the new text for the <c>Finish</c> button.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// By default, the <c>Finish</c> button does not have a keyboard accelerator. You can create a keyboard accelerator with this
		/// message by including an ampersand (&amp;) in the text string that you assign to lParam. For example, "&amp;Finish" defines F as
		/// the accelerator key.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-setfinishtext
		[MsgParams(null, typeof(string))]
		PSM_SETFINISHTEXTW = WM_USER + 121,

		/// <summary>
		/// <para>
		/// Retrieves the handle to the tab control of a property sheet. You can send this message explicitly or by using the
		/// <c>PropSheet_GetTabControl</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the tab control.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>This message is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-gettabcontrol
		[MsgParams(null, null, LResultType = typeof(HWND))]
		PSM_GETTABCONTROL = WM_USER + 116,

		/// <summary>
		/// <para>
		/// Passes a message to a property sheet dialog box and indicates whether the dialog box processed the message. You can send this
		/// message explicitly or by using the <c>PropSheet_IsDialogMessage</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>MSG</c> structure that contains the message to be checked.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if the message has been processed, or <c>FALSE</c> if the message has not been processed.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Your message loop should use the <c>PSM_ISDIALOGMESSAGE</c> message with modeless property sheets to pass messages to the
		/// property sheet dialog box. On systems that support Unicode, use the Unicode versions of the <c>GetMessage</c> and
		/// <c>PeekMessage</c> functions ( <c>GetMessageW</c> and <c>PeekMessageW</c>) to retrieve messages.
		/// </para>
		/// <para>
		/// If the return value indicates that the message was processed, it must not be passed to the <c>TranslateMessage</c> or
		/// <c>DispatchMessage</c> function.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-isdialogmessage
		[MsgParams(null, typeof(MSG), LResultType = typeof(BOOL))]
		PSM_ISDIALOGMESSAGE = WM_USER + 117,

		/// <summary>
		/// <para>
		/// Retrieves a handle to the window of the current page of a property sheet. You can send this message explicitly or by using the
		/// <c>PropSheet_GetCurrentPageHwnd</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a handle to the window of the current property sheet page.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Use the <c>PSM_GETCURRENTPAGEHWND</c> message with modeless property sheets to determine when to destroy the dialog box. When the
		/// user clicks the <c>OK</c> or <c>Cancel</c> button, <c>PSM_GETCURRENTPAGEHWND</c> returns <c>NULL</c>, and you can then use the
		/// <c>DestroyWindow</c> function to destroy the dialog box.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-getcurrentpagehwnd
		[MsgParams(null, null, LResultType = typeof(HWND))]
		PSM_GETCURRENTPAGEHWND = WM_USER + 118,

		/// <summary>
		/// <para>
		/// Inserts a new page into an existing property sheet. The page can be inserted either at a specified index or after a specified
		/// page. You can send this message explicitly or by using the <c>PropSheet_InsertPage</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Where the page is to be inserted. Set this parameter to <c>NULL</c> to make the new page the first page. To specify where the new
		/// page is to be inserted, you can either pass an index or an existing page's HPROPSHEETPAGE handle.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>index</description>
		/// <description>
		/// If the <c>wParam</c> parameter is less than MAXUSHORT (the largest unsigned short integer), the <c>wParam</c> specifies the
		/// zero-based index for the new page. For example, to make the inserted page the third page on the property sheet, set <c>wParam</c>
		/// to 2. To make it the first page, set <c>wParam</c> to 0. If <c>wParam</c> has a value greater than the number of pages and less
		/// than MAXUSHORT, the page will be appended.
		/// </description>
		/// </item>
		/// <item>
		/// <description>hpageInsertAfter</description>
		/// <description>
		/// If you set the <c>wParam</c> parameter to an existing page's HPROPSHEETPAGE handle, the new page will be inserted after it.
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the page to be inserted. The page must first be created by a call to the <c>CreatePropertySheetPage</c> function.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a nonzero value if the page was successfully inserted, or zero otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>The pages after the insertion point are shifted to the right to accommodate the new page.</para>
		/// <para>
		/// The property sheet is not resized to fit the new page. Do not make the new page larger than the property sheet's largest page.
		/// </para>
		/// <para>
		/// A number of messages and one function call occur while the property sheet is manipulating the list of pages. While this action is
		/// taking place, attempting to modify the list of pages will have unpredictable results. Accordingly, you should not use the
		/// PSM_INSERTPAGE message in your implementation of PropSheetPageProc or while handling the following notifications and Windows messages.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>PSN_APPLY</description>
		/// </item>
		/// <item>
		/// <description>PSN_KILLACTIVE</description>
		/// </item>
		/// <item>
		/// <description>PSN_RESET</description>
		/// </item>
		/// <item>
		/// <description>PSN_SETACTIVE</description>
		/// </item>
		/// <item>
		/// <description><c>WM_DESTROY</c></description>
		/// </item>
		/// <item>
		/// <description><c>WM_INITDIALOG</c></description>
		/// </item>
		/// </list>
		/// <para>
		/// If you need to modify a property sheet page while you are handling one of these messages or while PropSheetPageProc is in
		/// operation, post yourself a private Windows message. Your application will not receive that message until after the property sheet
		/// manager has finished its tasks. Then you can modify the list of pages.
		/// </para>
		/// <para>The following notifications are also affected by property sheet modification.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>PSN_WIZBACK</description>
		/// </item>
		/// <item>
		/// <description>PSN_WIZNEXT</description>
		/// </item>
		/// </list>
		/// <para>
		/// You can add or remove pages in response to these notifications, provided that you return (via DWL_MSGRESULT) a nonzero value to
		/// specify the desired new page. Note, however, that if you insert a page that is located before the current page (that has a
		/// smaller index than the current page), PSN_KILLACTIVE might be sent to the wrong page.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-insertpage
		[MsgParams(typeof(IntPtr), typeof(HPROPSHEETPAGE), LResultType = typeof(BOOL))]
		PSM_INSERTPAGE = WM_USER + 119,

		/// <summary>
		/// <para>
		/// Sets the title text for the header of a wizard's interior page. You can send this message explicitly or use the
		/// <c>PropSheet_SetHeaderTitle</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the wizard's page.</para>
		/// <para><em>lParam</em></para>
		/// <para>New header subtitle.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>If you specify the current page, it will immediately be repainted to display the new title.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-setheadertitle
		[MsgParams(typeof(uint), typeof(string))]
		PSM_SETHEADERTITLEA = WM_USER + 125,

		/// <summary>
		/// <para>
		/// Sets the title text for the header of a wizard's interior page. You can send this message explicitly or use the
		/// <c>PropSheet_SetHeaderTitle</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the wizard's page.</para>
		/// <para><em>lParam</em></para>
		/// <para>New header subtitle.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>If you specify the current page, it will immediately be repainted to display the new title.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-setheadertitle
		[MsgParams(typeof(uint), typeof(string))]
		PSM_SETHEADERTITLEW = WM_USER + 126,

		/// <summary>
		/// <para>
		/// Sets the subtitle text for the header of a wizard's interior page. You can send this message explicitly or use the
		/// <c>PropSheet_SetHeaderSubTitle</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the wizard's page.</para>
		/// <para><em>lParam</em></para>
		/// <para>New header subtitle.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>If you specify the current page, it will immediately be repainted to display the new subtitle.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-setheadersubtitle
		[MsgParams(typeof(uint), typeof(string))]
		PSM_SETHEADERSUBTITLEA = WM_USER + 127,

		/// <summary>
		/// <para>
		/// Sets the subtitle text for the header of a wizard's interior page. You can send this message explicitly or use the
		/// <c>PropSheet_SetHeaderSubTitle</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the wizard's page.</para>
		/// <para><em>lParam</em></para>
		/// <para>New header subtitle.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>If you specify the current page, it will immediately be repainted to display the new subtitle.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-setheadersubtitle
		[MsgParams(typeof(uint), typeof(string))]
		PSM_SETHEADERSUBTITLEW = WM_USER + 128,

		/// <summary>
		/// <para>
		/// Takes the window handle of the property sheet page and returns its zero-based index. You can send this message explicitly or use
		/// the <c>PropSheet_HwndToIndex</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to the page's window.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the zero-based index of the property sheet page specified by wParam if successful. Otherwise, it returns -1.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-hwndtoindex
		[MsgParams(typeof(HWND), null, LResultType = typeof(int))]
		PSM_HWNDTOINDEX = WM_USER + 129,

		/// <summary>
		/// <para>
		/// Takes the index of a property sheet page and returns its window handle. You can send this message explicitly or use the
		/// <c>PropSheet_IndexToHwnd</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the page.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the window of the property sheet page specified by wParam if successful. Otherwise, it returns zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-indextohwnd
		[MsgParams(typeof(uint), null, LResultType = typeof(HWND))]
		PSM_INDEXTOHWND = WM_USER + 130,

		/// <summary>
		/// <para>
		/// Takes the HPROPSHEETPAGE handle of the property sheet page and returns its zero-based index. You can send this message explicitly
		/// or use the <c>PropSheet_PageToIndex</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>HPROPSHEETPAGE handle to the property sheet page.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the zero-based index of the property sheet page specified by lParam if successful. Otherwise, it returns -1.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-pagetoindex
		[MsgParams(null, typeof(HPROPSHEETPAGE), LResultType = typeof(int))]
		PSM_PAGETOINDEX = WM_USER + 131,

		/// <summary>
		/// <para>
		/// Takes the index of a property sheet page and returns its HPROPSHEETPAGE handle. You can send this message explicitly or use the
		/// <c>PropSheet_IndexToPage</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the page.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the HPROPSHEETPAGE handle of the property sheet page specified by wParam if successful. Otherwise, it returns zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-indextopage
		[MsgParams(typeof(uint), null, LResultType = typeof(HPROPSHEETPAGE))]
		PSM_INDEXTOPAGE = WM_USER + 132,

		/// <summary>
		/// <para>
		/// Takes the resource ID of a property sheet page and returns its zero-based index. You can send this message explicitly or use the
		/// <c>PropSheet_IdToIndex</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Resource ID of the page.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the zero-based index of the property sheet page specified by lParam if successful. Otherwise, it returns -1.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-idtoindex
		[MsgParams(null, typeof(ResourceId), LResultType = typeof(int))]
		PSM_IDTOINDEX = WM_USER + 133,

		/// <summary>
		/// <para>
		/// Takes the index of a property sheet page and returns its resource ID. You can send this message explicitly or use the
		/// <c>PropSheet_IndexToId</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Zero-based index of the page.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the resource ID of the property sheet page specified by wParam if successful. Otherwise, it returns zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-indextoid
		[MsgParams(typeof(uint), null, LResultType = typeof(ResourceId))]
		PSM_INDEXTOID = WM_USER + 134,

		/// <summary>
		/// <para>
		/// Used by modeless property sheets to retrieve the information returned to modal property sheets by <c>PropertySheet</c>. You can
		/// send this message explicitly or use the <c>PropSheet_GetResult</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a positive value if successful, or -1 otherwise. The following return values have a special meaning.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>ID_PSREBOOTSYSTEM</c></description>
		/// <description>
		/// A page sent a <c>PSM_REBOOTSYSTEM</c> message to the property sheet. The computer must be restarted for the user's changes to
		/// take effect.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>ID_PSRESTARTWINDOWS</c></description>
		/// <description>
		/// A page sent a <c>PSM_RESTARTWINDOWS</c> message to the property sheet. Windows must be restarted for the user's changes to take effect.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>To retrieve extended error information, call <c>GetLastError</c>.</para>
		/// <para>The return value for this message is identical to what <c>PropertySheet</c> returns for a modal property sheet.</para>
		/// <para>
		/// Version 5.80. The <c>PropertySheet</c> return value carries different information for modal and modeless property sheets. In some
		/// cases, modeless property sheets may need the information they would have received from <c>PropertySheet</c> if they had been
		/// modal. In particular, they may need to know whether ID_PSREBOOTSYSTEM or ID_PSRESTARTWINDOWS would have been returned.
		/// </para>
		/// <para>
		/// For a modeless property sheet, your message loop should use <c>PSM_ISDIALOGMESSAGE</c> to pass messages to the property sheet
		/// dialog box, and <c>PSM_GETCURRENTPAGEHWND</c> to determine when to destroy the dialog box. When the user clicks the <c>OK</c> or
		/// <c>Cancel</c> button, <c>PSM_GETCURRENTPAGEHWND</c> returns <c>NULL</c>. You can then retrieve the value that a modal property
		/// sheet would have received from <c>PropertySheet</c> by sending a <c>PSM_GETRESULT</c> message.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-getresult
		[MsgParams(null, null, LResultType = typeof(int))]
		PSM_GETRESULT = WM_USER + 135,

		/// <summary>
		/// <para>
		/// Recalculates the page size of a standard or wizard property sheet after pages have been added or removed. You can send this
		/// message explicitly or use the <c>PropSheet_RecalcPageSizes</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When a property sheet is created, it is sized to fit its initial collection of pages. In order to maintain compatibility with
		/// previous versions of the common controls, property sheets and wizards do not automatically resize themselves when pages are
		/// subsequently added or removed. With common controls version 5.80, applications should send a <c>PSM_RECALCPAGESIZES</c> message
		/// after adding or removing pages with <c>PSM_ADDPAGE</c>, <c>PSM_INSERTPAGE</c>, <c>PSM_REMOVEPAGE</c>, or their equivalent macros.
		/// It ensures that the property sheet is properly sized for its current collection of pages. If this message is not sent, some
		/// property sheet pages may be truncated or too large.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-recalcpagesizes
		[MsgParams(null, null, LResultType = typeof(BOOL))]
		PSM_RECALCPAGESIZES = WM_USER + 136,

		/// <summary>
		/// <para>
		/// Sets the text of the <c>Next</c> button in a wizard. You can send this message explicitly or by using the
		/// <c>PropSheet_SetNextText</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a buffer that contains the text.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No meaningful return value.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-setnexttext
		[MsgParams(null, typeof(string))]
		PSM_SETNEXTTEXT = WM_USER + 137,

		/// <summary>
		/// <para>
		/// Enables or disables any of the standard buttons in an Aero wizard. You can send this message explicitly or use the
		/// <c>PropSheet_EnableWizButtons</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// One or more of the following values that specify which property sheet buttons are to be enabled. If a button value is included in
		/// both this parameter and lParam, it is enabled.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>PSWIZB_BACK</c></description>
		/// <description>The <c>Back</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_CANCEL</c></description>
		/// <description>The <c>Cancel</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_DISABLEDFINISH</c></description>
		/// <description>The <c>Finish</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_FINISH</c></description>
		/// <description>The <c>Finish</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_NEXT</c></description>
		/// <description>The <c>Next</c> button.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// One or more of the same values used in wParam, specifying which buttons are affected by this call. If a button value appears in
		/// this parameter but not in wParam, it indicates that the button should be disabled.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-enablewizbuttons
		[MsgParams(typeof(PSWIZB), typeof(PSWIZB))]
		PSM_ENABLEWIZBUTTONS = WM_USER + 139,

		/// <summary>
		/// <para>
		/// Sets the text on a button in an Aero wizard. You can send this message explicitly or by using the <c>PropSheet_SetButtonText</c> macro.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>One of the following values specifying the button whose text is set.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>PSWIZB_BACK</c></description>
		/// <description>The <c>Back</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_CANCEL</c></description>
		/// <description>The <c>Cancel</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_DISABLEDFINISH</c></description>
		/// <description>The <c>Finish</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_FINISH</c></description>
		/// <description>The <c>Finish</c> button.</description>
		/// </item>
		/// <item>
		/// <description><c>PSWIZB_NEXT</c></description>
		/// <description>The <c>Next</c> button.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>The text to set.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psm-setbuttontext
		[MsgParams(typeof(PSWIZB), typeof(string))]
		PSM_SETBUTTONTEXT = WM_USER + 140,
	}

	/// <summary>Notifications for property sheets.</summary>
	[PInvokeData("prsht.h")]
	public enum PropSheetNotification
	{
		/// <summary>
		/// <para>Notifies a page that it is about to be activated. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>PSHNOTIFY</c> structure that contains information about the notification code. This structure contains an
		/// <c>NMHDR</c> structure as its first member, <c>hdr</c>. The <c>hwndFrom</c> member of this <c>NMHDR</c> structure contains the
		/// handle to the property sheet. The <c>lParam</c> member of the <c>PSHNOTIFY</c> structure does not contain any information.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns zero to accept the activation, or -1 to activate the next or the previous page (depending on whether the user clicked the
		/// <c>Next</c> or <c>Back</c> button). To set the activation to a particular page, return the resource identifier of the page.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The PSN_SETACTIVE notification code is sent before the page is visible. An application can use this notification code to
		/// initialize data in the page.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The property sheet is in the process of manipulating the list of pages when the PSN_SETACTIVE notification code is sent. Do not
		/// attempt to add, remove, or insert pages while handling this notification code. Doing so will have unpredictable results.
		/// </para>
		/// </para>
		/// <para>
		/// To set the return value, the dialog box procedure for the page must use the <c>SetWindowLong</c> function with the DWL_MSGRESULT
		/// value, and the dialog box procedure must return <c>TRUE</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psn-setactive
		[MsgParams(LParamType = typeof(PSHNOTIFY), LResultType = typeof(int))]
		PSN_SETACTIVE = PSN_FIRST - 0,

		/// <summary>
		/// <para>
		/// Notifies a page that it is about to lose activation either because another page is being activated or the user has clicked the OK
		/// button. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>PSHNOTIFY</c> structure that contains information about the notification code. This structure contains an
		/// <c>NMHDR</c> structure as its first member, <c>hdr</c>. The <c>hwndFrom</c> member of this <c>NMHDR</c> structure contains the
		/// handle to the property sheet. The <c>lParam</c> member of the <c>PSHNOTIFY</c> structure does not contain any information.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> to prevent the page from losing the activation, or <c>FALSE</c> to allow it.</para>
		/// </summary>
		/// <remarks>
		/// <para>An application handles this notification code to validate the information the user has entered.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The property sheet is in the process of manipulating the list of pages when the PSN_KILLACTIVE notification code is sent. Do not
		/// attempt to add, remove, or insert pages while handling this notification code. Doing so will have unpredictable results.
		/// </para>
		/// </para>
		/// <para>
		/// To set a return value, the dialog box procedure for the page must call the <c>SetWindowLong</c> function with a DWL_MSGRESULT
		/// value set to the return value. The dialog box procedure must return <c>TRUE</c>.
		/// </para>
		/// <para>
		/// If the dialog box procedure sets DWL_MSGRESULT to <c>TRUE</c>, it should display a message box to explain the problem to the user.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psn-killactive
		[MsgParams(LParamType = typeof(PSHNOTIFY), LResultType = typeof(BOOL))]
		PSN_KILLACTIVE = PSN_FIRST - 1,

		/// <summary>
		/// <para>
		/// Sent to every page in the property sheet to indicate that the user has clicked the OK, Close, or Apply button and wants all
		/// changes to take effect. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>PSHNOTIFY</c> structure that contains information about the notification code, including the ID of the page.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Set PSNRET_NOERROR to indicate that the changes made to this page are valid and have been applied. If all pages set
		/// PSNRET_NOERROR, the property sheet can be destroyed. To indicate that the changes made to this page are invalid and to prevent
		/// the property sheet from being destroyed, set one of the following return values:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>PSNRET_INVALID. The property sheet will not be destroyed, and focus will be returned to this page.</description>
		/// </item>
		/// <item>
		/// <description>
		/// PSNRET_INVALID_NOCHANGEPAGE. The property sheet will not be destroyed, and focus will be returned to the page that had focus when
		/// the button was pressed.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// To set the return value, the dialog box procedure for the page must call the <c>SetWindowLong</c> function with the DWL_MSGRESULT
		/// value, and the dialog box procedure must return <c>TRUE</c>.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the user clicks the OK, Apply, or Close button, the property sheet sends a PSN_KILLACTIVE notification to the active page,
		/// giving it an opportunity to validate the user's changes. If the changes are valid, the property sheet sends a PSN_APPLY
		/// notification code to each page, directing it to apply the new properties to the corresponding item.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The property sheet is in the process of manipulating the list of pages when the PSN_APPLY notification code is sent. Do not
		/// attempt to add, remove, or insert pages while handling this notification. Doing so will have unpredictable results.
		/// </para>
		/// </para>
		/// <para>
		/// The <c>lParam</c> member of the <c>PSHNOTIFY</c> structure pointed to by lParam is set to <c>TRUE</c> if the user clicks the OK
		/// button. It is also set to <c>TRUE</c> if the <c>PSM_CANCELTOCLOSE</c> message has been sent and the user clicks the Close button.
		/// It is set to <c>FALSE</c> if the user clicks the Apply button.
		/// </para>
		/// <para>
		/// The <c>PSHNOTIFY</c> structure contains an <c>NMHDR</c> structure as its first member, <c>hdr</c>. The <c>hwndFrom</c> member of
		/// this <c>NMHDR</c> structure contains the handle to the property sheet.
		/// </para>
		/// <para>Do not call the <c>EndDialog</c> function when processing this notification code.</para>
		/// <para>
		/// A modal property sheet is destroyed if the user clicks the OK button and every page returns the PSNRET_NOERROR value in response
		/// to <c>PSN_APPLY</c>. If any page returns PSNRET_INVALID or PSNRET_INVALID_NOCHANGEPAGE, the Apply process is canceled
		/// immediately. Pages after the cancelling page will not receive a PSN_APPLY notification code.
		/// </para>
		/// <para>
		/// To receive this notification code, a page must set the DWL_MSGRESULT value to <c>FALSE</c> in response to the PSN_KILLACTIVE
		/// notification code.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>This notification code is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psn-apply
		[MsgParams(LParamType = typeof(PSHNOTIFY), LResultType = typeof(PSNRET))]
		PSN_APPLY = PSN_FIRST - 2,

		/// <summary>
		/// <para>
		/// Notifies a page that the property sheet is about to be destroyed. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>PSHNOTIFY</c> structure that contains information about the notification code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// All changes made since the last PSN_APPLY notification code are canceled, except in the case of <c>PSH_AEROWIZARD</c>, which does
		/// not support that notification code.
		/// </para>
		/// <para>
		/// The <c>lParam</c> member of the <c>PSHNOTIFY</c> structure pointed to by lParam will be set to <c>TRUE</c> if the user clicked
		/// the <c>X</c> button in the upper-right corner of the property sheet. It will be <c>FALSE</c> if the user clicked the
		/// <c>Cancel</c> button. The <c>PSHNOTIFY</c> structure contains an <c>NMHDR</c> structure as its first member, <c>hdr</c>. The
		/// <c>hwndFrom</c> member of this <c>NMHDR</c> structure contains the handle to the property sheet.
		/// </para>
		/// <para>An application can use this notification code as an opportunity to perform cleanup operations.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The property sheet is in the process of manipulating the list of pages when the PSN_RESET notification code is sent. Do not
		/// attempt to add, remove, or insert pages while handling this notification code. Doing so will have unpredictable results.
		/// </para>
		/// </para>
		/// <para>Do not call the <c>EndDialog</c> function when processing this notification code.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psn-reset
		[MsgParams(LParamType = typeof(PSHNOTIFY))]
		PSN_RESET = PSN_FIRST - 3,

		/// <summary>
		/// <para>
		/// Notifies a page that the user has clicked the Help button. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>PSHNOTIFY</c> structure that contains information about the notification code. This structure contains an
		/// <c>NMHDR</c> structure as its first member, <c>hdr</c>. The <c>hwndFrom</c> member of this <c>NMHDR</c> structure contains the
		/// handle to the property sheet. The <c>lParam</c> member of the <c>PSHNOTIFY</c> structure does not contain any information.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>An application should display Help information for the page.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This notification code is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psn-help
		[MsgParams(LParamType = typeof(PSHNOTIFY))]
		PSN_HELP = PSN_FIRST - 5,

		/// <summary>
		/// <para>
		/// Notifies a page that the user has clicked the <c>Back</c> button in a wizard. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>PSHNOTIFY</c> structure that contains information about the notification code. This structure contains an
		/// <c>NMHDR</c> structure as its first member, <c>hdr</c>. The <c>hwndFrom</c> member of this <c>NMHDR</c> structure contains the
		/// handle to the property sheet. The <c>lParam</c> member of the <c>PSHNOTIFY</c> structure does not contain any information.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns 0 to allow the wizard to go to the previous page. Returns -1 to prevent the wizard from changing pages. To display a
		/// particular page, return its dialog resource identifier. If the dialog was specified with the <c>PSP_DLGINDIRECT</c> flag, this
		/// notification returns the pointer to the dialog template.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To set the return value, the dialog box procedure for the page must call the <c>SetWindowLong</c> function with the
		/// <c>DWL_MSGRESULT</c> value and return <c>TRUE</c>. For example:
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The property sheet is in the process of manipulating the list of pages when the PSN_WIZBACK notification code is sent. You can
		/// add, insert, or remove pages in response to these notification codes, but special care must be taken if you insert or remove
		/// pages before the current page.
		/// </para>
		/// </para>
		/// <para>
		/// If you insert or remove pages before the current page, you must return (through <c>DWL_MSGRESULT</c>) a nonzero value to specify
		/// the desired new page. Note, however, that if you insert or remove a page that is located before the current page (that has a
		/// smaller index than the current page), PSN_KILLACTIVE might be sent to the wrong page.
		/// </para>
		/// <para>
		/// For this reason, it is recommended that wizards that add and remove pages dynamically in response to PSN_WIZNEXT and PSN_WIZBACK
		/// do so only to pages at the end of the list. If you want your wizard to remove pages accurately, keep the dynamic pages at the end
		/// of the list and jump back to permanent pages before deleting them.
		/// </para>
		/// <para>
		/// For example, suppose a wizard consists of an introductory page, a series of dynamic pages, and a completion page, and you want to
		/// delete the dynamic pages when the user reaches the completion page.
		/// </para>
		/// <list type="number">
		/// <item>
		/// <description>
		/// The wizard would begin with two pages, "Introduction" and "Completion." The user begins on the "Introduction" page.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// When the user navigates away from "Introduction," the wizard adds the dynamic pages and places the user at the first dynamic page
		/// by returning (through <c>DWL_MSGRESULT</c>) the dialog identifier of the page "Dynamic 1." In this example, there are three
		/// dynamic pages.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// After the user navigates through the dynamic pages to "Dynamic 3" and then navigates to the next page, the application should
		/// place the user at the page "Completion." Again, this is done by returning (through <c>DWL_MSGRESULT</c>) the dialog identifier of
		/// the page "Completion."
		/// </description>
		/// </item>
		/// <item>
		/// <description>The application can then remove the three dynamic pages (numbered three through five) safely.</description>
		/// </item>
		/// </list>
		/// <para>
		/// Note that this technique is necessary only if your wizard removes pages dynamically. If your wizard only adds pages dynamically,
		/// this process is not necessary.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psn-wizback
		[MsgParams(LParamType = typeof(PSHNOTIFY), LResultType = typeof(int))]
		PSN_WIZBACK = PSN_FIRST - 6,

		/// <summary>
		/// <para>
		/// Notifies a page that the user has clicked the <c>Next</c> button in a wizard. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>PSHNOTIFY</c> structure that contains information about the notification code. This structure contains an
		/// <c>NMHDR</c> structure as its first member, <c>hdr</c>. The <c>hwndFrom</c> member of this <c>NMHDR</c> structure contains the
		/// handle to the property sheet. The <c>lParam</c> member of the <c>PSHNOTIFY</c> structure does not contain any information.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Return 0 to allow the wizard to go to the next page. Return -1 to prevent the wizard from changing pages. To display a particular
		/// page, return its dialog resource identifier. If the dialog was specified with the <c>PSP_DLGINDIRECT</c> flag, this notification
		/// returns the pointer to the dialog template.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To set the return value, the dialog box procedure for the page must call the <c>SetWindowLong</c> function with the
		/// <c>DWL_MSGRESULT</c> value and return <c>TRUE</c>. For example:
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The property sheet is in the process of manipulating the list of pages when the PSN_WIZNEXT notification code is sent. You can
		/// add, insert, or remove pages in response to these notification codes, but special care must be taken if you insert or remove
		/// pages before the current page.
		/// </para>
		/// </para>
		/// <para>
		/// If you insert or remove pages before the current page, you must return (through <c>DWL_MSGRESULT</c>) a nonzero value to specify
		/// the desired new page. Note, however, that if you insert or remove a page that is located before the current page (that has a
		/// smaller index than the current page), PSN_KILLACTIVE might be sent to the wrong page.
		/// </para>
		/// <para>
		/// For this reason, it is recommended that wizards that add and remove pages dynamically in response to PSN_WIZNEXT and PSN_WIZBACK
		/// do so only to pages at the end of the list. If you want your wizard to remove pages accurately, keep the dynamic pages at the end
		/// of the list and jump back to permanent pages before deleting them.
		/// </para>
		/// <para>
		/// For example, suppose a wizard consists of an introductory page, a series of dynamic pages, and a completion page, and you want to
		/// delete the dynamic pages when the user reaches the completion page.
		/// </para>
		/// <list type="number">
		/// <item>
		/// <description>
		/// The wizard would begin with two pages, "Introduction" and "Completion." The user begins on the "Introduction" page.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// When the user navigates away from "Introduction," the wizard adds the dynamic pages and places the user at the first dynamic page
		/// by returning (through <c>DWL_MSGRESULT</c>) the dialog identifier of the page "Dynamic 1." In this example, there are three
		/// dynamic pages.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// After the user navigates through the dynamic pages to "Dynamic 3" and then navigates to the next page, the application should
		/// place the user at the page "Completion." Again, this is done by returning (through <c>DWL_MSGRESULT</c>) the dialog identifier of
		/// the page "Completion."
		/// </description>
		/// </item>
		/// <item>
		/// <description>The application can then remove the three dynamic pages (numbered three through five) safely.</description>
		/// </item>
		/// </list>
		/// <para>
		/// Note that this technique is necessary only if your wizard removes pages dynamically. If your wizard only adds pages dynamically,
		/// this process is not necessary.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psn-wiznext
		[MsgParams(LParamType = typeof(PSHNOTIFY), LResultType = typeof(int))]
		PSN_WIZNEXT = PSN_FIRST - 7,

		/// <summary>
		/// <para>
		/// Notifies a page that the user has clicked the <c>Finish</c> button in a wizard. This notification code is sent in the form of a
		/// <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>PSHNOTIFY</c> structure that contains information about the notification code. This structure contains an
		/// <c>NMHDR</c> structure as its first member, <c>hdr</c>. The <c>hwndFrom</c> member of this <c>NMHDR</c> structure contains the
		/// handle to the property sheet. The <c>lParam</c> member of the <c>PSHNOTIFY</c> structure does not contain any information.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <list type="bullet">
		/// <item>
		/// <description>Returns <c>TRUE</c> to prevent the wizard from finishing.</description>
		/// </item>
		/// <item>
		/// <description>
		/// Version 5.80. and later. Returns a window handle to prevent the wizard from finishing. The wizard will set the focus to that
		/// window. The window must be owned by the wizard page.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Returns <c>FALSE</c> to allow the wizard to finish.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To set the return value, the dialog box procedure for the page must use the <c>SetWindowLong</c> function with the DWL_MSGRESULT
		/// value, and the dialog box procedure must return <c>TRUE</c>.
		/// </para>
		/// <para>
		/// Version 5.80. If your application returns <c>TRUE</c> to prevent a wizard from finishing, it has no control over which window on
		/// the page receives focus. Applications that need to stop a wizard from finishing should normally do so by returning the handle of
		/// the window on the wizard page that is to receive focus.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psn-wizfinish
		[MsgParams(LParamType = typeof(PSHNOTIFY), LResultType = typeof(BOOL))]
		PSN_WIZFINISH = PSN_FIRST - 8,

		/// <summary>
		/// <para>
		/// Indicates that the user has canceled the property sheet. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>PSHNOTIFY</c> structure that contains information about the notification code. This structure contains an
		/// <c>NMHDR</c> structure as its first member, <c>hdr</c>. The <c>hwndFrom</c> member of this <c>NMHDR</c> structure contains the
		/// handle to the property sheet. The <c>lParam</c> member of the <c>PSHNOTIFY</c> structure does not contain any information.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> to prevent the cancel operation, or <c>FALSE</c> to allow it.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This notification code is typically sent when a user clicks the <c>Cancel</c> button. It is also sent when a user clicks the
		/// <c>X</c> button in the property sheet's upper right hand corner or presses the ESCAPE key. A property sheet page can handle this
		/// notification code to ask the user to verify the cancel operation.
		/// </para>
		/// <para>
		/// To set a return value, the dialog box procedure for the page must call the <c>SetWindowLong</c> function with DWL_MSGRESULT set
		/// to the return value. The dialog box procedure must return <c>TRUE</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psn-querycancel
		[MsgParams(LParamType = typeof(PSHNOTIFY), LResultType = typeof(BOOL))]
		PSN_QUERYCANCEL = PSN_FIRST - 9,

		/// <summary>
		/// <para>
		/// Sent by a property sheet to request a drop target object when the cursor passes over one of the tab control's buttons. This
		/// notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>NMOBJECTNOTIFY</c> structure that, on entry, contains information about the notification code. If this
		/// notification code is processed, you must insert object information into this structure.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The application processing this notification code must return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To provide an object, an application must set values in some members of the <c>NMOBJECTNOTIFY</c> structure at lParam. The
		/// <c>pObject</c> member must be set to a valid object pointer, and the <c>hResult</c> member must be set to a success flag. To
		/// comply with Component Object Model (COM) standards, always increment the object's reference count when providing an object pointer.
		/// </para>
		/// <para>
		/// If an application does not provide an object, it must set <c>pObject</c> to <c>NULL</c> and <c>hResult</c> to a failure flag.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>This notification code is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psn-getobject
		[MsgParams(LParamType = typeof(NMOBJECTNOTIFY), LResultType = typeof(int))]
		PSN_GETOBJECT = PSN_FIRST - 10,

		/// <summary>
		/// <para>
		/// Notifies a property sheet that a keyboard message has been received. It provides the page an opportunity to do private keyboard
		/// accelerator translation. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>PSHNOTIFY</c> structure that contains information about the notification code. This structure contains an
		/// <c>NMHDR</c> structure as its first member, <c>hdr</c>. The <c>hwndFrom</c> member of the <c>NMHDR</c> structure contains the
		/// handle to the property sheet. The <c>lParam</c> member of the <c>PSHNOTIFY</c> structure is a pointer to the message's
		/// <c>MSG</c>. It can be cast to an <c>LPMSG</c> type, to get access to the parameters of the message to be translated.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns PSNRET_MESSAGEHANDLED to indicate that no further processing is necessary. Returns PSNRET_NOERROR to request normal processing.
		/// </para>
		/// </summary>
		/// <remarks>
		/// To set the return value, the dialog box procedure for the page must use the <c>SetWindowLong</c> function with the DWL_MSGRESULT
		/// value. The dialog box procedure must return <c>TRUE</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psn-translateaccelerator
		[MsgParams(LParamType = typeof(PSHNOTIFY), LResultType = typeof(PSNRET))]
		PSN_TRANSLATEACCELERATOR = PSN_FIRST - 12,

		/// <summary>
		/// <para>
		/// Sent by a property sheet to provide a property sheet page an opportunity to specify which dialog box control should receive the
		/// initial focus. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>PSHNOTIFY</c> structure. Cast the <c>lParam</c> member of this structure to an <c>HWND</c> type, to retrieve the
		/// handle of the control that will be given focus by default. The structure contains an <c>NMHDR</c> structure as its first member,
		/// <c>hdr</c>. The <c>hwndFrom</c> member of this <c>NMHDR</c> structure contains the handle to the property sheet.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// To specify which control should receive focus, return the control's handle. Otherwise, return zero and focus will go to the
		/// default control. To set the return value, the dialog box procedure must call the <c>SetWindowLong</c> function with a
		/// <c>DWL_MSGRESULT</c> value and return <c>TRUE</c>.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// An application must not call the <c>SetFocus</c> function while handling this notification code. Return the handle of the control
		/// that should receive focus, and the property sheet manager will handle the focus change.
		/// </para>
		/// <para>
		/// The PSN_QUERYINITIALFOCUS notification code is not sent if the property sheet manager determines that no control on the page
		/// should receive focus.
		/// </para>
		/// <para>
		/// This code fragment implements a simple handler for PSN_QUERYINITIALFOCUS. It requests that initial focus be given to the Location
		/// control ( <c>IDC_LOCATION</c>).
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>This notification code is not supported when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/psn-queryinitialfocus
		[MsgParams(LParamType = typeof(PSHNOTIFY), LResultType = typeof(BOOL))]
		PSN_QUERYINITIALFOCUS = PSN_FIRST - 13,
	}

	/// <summary>Action flag.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb760813")]
	public enum PropSheetPageCallbackAction
	{
		/// <summary>Version 5.80 or later. A page is being created. The return value is not used.</summary>
		PSPCB_ADDREF = 0x0,

		/// <summary>A page is being destroyed. The return value is ignored.</summary>
		PSPCB_RELEASE = 0x1,

		/// <summary>A dialog box for a page is being created. Return nonzero to allow it to be created, or zero to prevent it.</summary>
		PSPCB_CREATE = 0x2,
	}

	/// <summary>Index of the button to select.</summary>
	[PInvokeData("prsht.h")]
	public enum PSBTN
	{
		/// <summary>Selects the <c>Back</c> button.</summary>
		PSBTN_BACK = 0,

		/// <summary>Selects the <c>Next</c> button.</summary>
		PSBTN_NEXT = 1,

		/// <summary>Selects the <c>Finish</c> button.</summary>
		PSBTN_FINISH = 2,

		/// <summary>Selects the <c>OK</c> button. This value is not valid when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</summary>
		PSBTN_OK = 3,

		/// <summary>Selects the <c>Apply</c> button. This value is not valid when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</summary>
		PSBTN_APPLYNOW = 4,

		/// <summary>Selects the <c>Cancel</c> button.</summary>
		PSBTN_CANCEL = 5,

		/// <summary>Selects the <c>Help</c> button. This value is not valid when using the Aero wizard style ( <c>PSH_AEROWIZARD</c>).</summary>
		PSBTN_HELP = 6,
	}

	/// <summary>Return codes for some <see cref="PropSheetNotification"/> states.</summary>
	[PInvokeData("prsht.h")]
	public enum PSNRET
	{
		/// <summary>
		/// Indicates that the changes made to this page are valid and have been applied. If all pages set PSNRET_NOERROR, the property sheet
		/// can be destroyed.
		/// </summary>
		PSNRET_NOERROR = 0,

		/// <summary>The property sheet will not be destroyed, and focus will be returned to this page.</summary>
		PSNRET_INVALID = 1,

		/// <summary>
		/// The property sheet will not be destroyed, and focus will be returned to the page that had focus when the button was pressed.
		/// </summary>
		PSNRET_INVALID_NOCHANGEPAGE = 2,

		/// <summary>Indicates that no further processing is necessary.</summary>
		PSNRET_MESSAGEHANDLED = 3,
	}

	/// <summary>Values that specify which property sheet buttons are to be shown.</summary>
	[PInvokeData("prsht.h")]
	[Flags]
	public enum PSWIZB : uint
	{
		/// <summary>The <c>Back</c> button.</summary>
		PSWIZB_BACK = 0x00000001,

		/// <summary>The <c>Next</c> button.</summary>
		PSWIZB_NEXT = 0x00000002,

		/// <summary>Set only this flag (defined as zero) to hide all buttons specified in <c>dwButton</c>.</summary>
		PSWIZB_SHOW = 0x00000001,

		/// <summary>Not implemented.</summary>
		PSWIZB_RESTORE = 0x00000002,

		/// <summary>The <c>Finish</c> button.</summary>
		PSWIZB_FINISH = 0x00000004,

		/// <summary>A disabled <c>Finish</c> button.</summary>
		PSWIZB_DISABLEDFINISH = 0x00000008,

		/// <summary>The <c>Cancel</c> button.</summary>
		PSWIZB_CANCEL = 0x00000010,
	}

	/// <summary>Creates a new page for a property sheet.</summary>
	/// <param name="lppsp">
	/// <para>Type: <c>LPCPROPSHEETPAGE</c></para>
	/// <para>Pointer to a <c>PROPSHEETPAGE</c> structure that defines a page to be included in a property sheet.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HPROPSHEETPAGE</c></para>
	/// <para>Returns the handle to the new property page if successful, or <c>NULL</c> otherwise.</para>
	/// </returns>
	// HPROPSHEETPAGE CreatePropertySheetPage( LPCPROPSHEETPAGE lppsp); https://msdn.microsoft.com/en-us/library/windows/desktop/bb760807(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("Prsht.h", MSDNShortId = "bb760807")]
	public static extern SafeHPROPSHEETPAGE CreatePropertySheetPage(PROPSHEETPAGE lppsp);

	/// <summary>
	/// Destroys a property sheet page. An application must call this function for pages that have not been passed to the
	/// <c>PropertySheet</c> function.
	/// </summary>
	/// <param name="hPSPage">
	/// <para>Type: <c>HPROPSHEETPAGE</c></para>
	/// <para>Handle to the property sheet page to delete.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para>Returns nonzero if successful, or zero otherwise.</para>
	/// </returns>
	// BOOL DestroyPropertySheetPage( HPROPSHEETPAGE hPSPage); https://msdn.microsoft.com/en-us/library/windows/desktop/bb760809(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Prsht.h", MSDNShortId = "bb760809")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DestroyPropertySheetPage(HPROPSHEETPAGE hPSPage);

	/// <summary>Creates a property sheet and adds the pages defined in the specified property sheet header structure.</summary>
	/// <param name="lppsph">
	/// <para>Type: <c>LPCPROPSHEETHEADER</c></para>
	/// <para>Pointer to a <c>PROPSHEETHEADER</c> structure that defines the frame and pages of a property sheet.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>INT_PTR</c></c></para>
	/// <para>For modal property sheets, the return value is as follows:</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>&amp;gt;=1</term>
	/// <term>Changes were saved by the user.</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>No changes were saved by the user.</term>
	/// </item>
	/// <item>
	/// <term>-1</term>
	/// <term>An error occurred.</term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>For modeless property sheets, the return value is the property sheet's window handle.</para>
	/// <para>The following return values have a special meaning.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ID_PSREBOOTSYSTEM</term>
	/// <term>
	/// A page sent the PSM_REBOOTSYSTEM message to the property sheet. The computer must be restarted for the user's changes to take effect.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ID_PSRESTARTWINDOWS</term>
	/// <term>
	/// A page sent the PSM_RESTARTWINDOWS message to the property sheet. Windows must be restarted for the user's changes to take effect.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// INT_PTR PropertySheet( LPCPROPSHEETHEADER lppsph); https://msdn.microsoft.com/en-us/library/windows/desktop/bb760811(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("Prsht.h", MSDNShortId = "bb760811")]
	[return: MarshalAs(UnmanagedType.SysInt)]
	public static extern IntPtr PropertySheet(ref PROPSHEETHEADER lppsph);

	/// <summary>Adds a new page to the end of an existing property sheet. You can use this macro or send the PSM_ADDPAGE message explicitly.</summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <param name="hpage">
	/// <para>Type: <c>HPROPSHEETPAGE</c></para>
	/// <para>Handle to the page to add. The page must have been created by a previous call to the CreatePropertySheetPage function.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// The new page should be no larger than the largest page currently in the property sheet because the property sheet is not resized to
	/// fit the new page.
	/// </para>
	/// <para>
	/// A number of messages and one function call occur while the property sheet is manipulating the list of pages. While this action is
	/// taking place, attempting to modify the list of pages will have unpredictable results. Accordingly, you should not use the
	/// <c>PropSheet_AddPage</c> macro in your implementation of PropSheetPageProc or while handling the following notifications and
	/// Microsoft Windows messages:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>PSN_APPLY</description>
	/// </item>
	/// <item>
	/// <description>PSN_KILLACTIVE</description>
	/// </item>
	/// <item>
	/// <description>PSN_RESET</description>
	/// </item>
	/// <item>
	/// <description>PSN_SETACTIVE</description>
	/// </item>
	/// <item>
	/// <description>WM_DESTROY</description>
	/// </item>
	/// <item>
	/// <description>WM_INITDIALOG</description>
	/// </item>
	/// </list>
	/// <para>
	/// If you need to modify a property sheet page while you are handling one of these messages or while PropSheetPageProc is in operation,
	/// post yourself a private Windows message. Your application will not receive that message until after the property sheet manager has
	/// finished its tasks. Then you can modify the list of pages.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_addpage void PropSheet_AddPage( hDlg, hpage );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_AddPage")]
	public static bool PropSheet_AddPage(HWND hDlg, HPROPSHEETPAGE hpage) =>
			SendMessage(hDlg, PropSheetMessage.PSM_ADDPAGE, 0, (IntPtr)hpage) != IntPtr.Zero;

	/// <summary>
	/// Simulates the selection of the <c>Apply</c> button, indicating that one or more pages have changed and the changes need to be
	/// validated and recorded. You can use this macro or send the PSM_APPLY message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// The property sheet sends the PSN_KILLACTIVE notification code to the current page. If the current page returns <c>FALSE</c>, the
	/// property sheet sends the PSN_APPLY notification code to all active pages.
	/// </para>
	/// <para><c>Note</c>  This macro is not supported when using the Aero wizard style (PSH_AEROWIZARD).</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_apply void PropSheet_Apply( hDlg );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_Apply")]
	public static bool PropSheet_Apply(HWND hDlg) =>
			SendMessage(hDlg, PropSheetMessage.PSM_APPLY) != IntPtr.Zero;

	/// <summary>
	/// Used when changes made since the most recent PSN_APPLY notification cannot be canceled. You can also send a PSM_CANCELTOCLOSE message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// PSM_CANCELTOCLOSE disables the <c>Cancel</c> button and changes the text of the <c>OK</c> button to "Close". You can use this macro
	/// or send the <c>PSM_CANCELTOCLOSE</c> message explicitly.
	/// </para>
	/// <para>
	/// Most property sheets wait to perform irreversible changes until a PSN_APPLY notification is received. However, in some circumstances,
	/// a property sheet may make irreversible changes outside the standard PSN_APPLY/PSN_RESET sequence. One example is a property sheet
	/// that contains an <c>Edit</c> button that is used to display a subdialog box for editing a property. When the user clicks <c>OK</c> to
	/// submit the change, the property sheet page has several options:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// It can record the changes but wait until it receives a PSN_APPLY notification to apply them. This is the preferred approach.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// It can apply the changes immediately after exiting the subdialog box, but remember the original settings. Those settings can be used
	/// to restore the original state if a PSN_RESET notification is received.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// It can apply the changes immediately and not attempt to restore the original settings when it receives a PSN_RESET notification. This
	/// approach is not recommended, but may be necessary if the changes are too far-reaching for the other two options to be practical.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// For the third option, applications should send a PSM_CANCELTOCLOSE message to the property sheet. It indicates to the user that the
	/// changes made with the subdialog box cannot be reversed by clicking the <c>Cancel</c> button.
	/// </para>
	/// <para><c>Note</c>  This macro is not supported when using the Aero wizard style (PSH_AEROWIZARD).</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_canceltoclose void PropSheet_CancelToClose( hDlg );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_CancelToClose")]
	public static void PropSheet_CancelToClose(HWND hDlg) =>
			PostMessage(hDlg, PropSheetMessage.PSM_CANCELTOCLOSE);

	/// <summary>
	/// Informs a property sheet that information in a page has changed. You can use this macro or send the PSM_CHANGED message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the page that has changed.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The property sheet enables the <c>Apply</c> button.</para>
	/// <para><c>Note</c>  This macro is not supported when using the Aero wizard style (PSH_AEROWIZARD).</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_changed void PropSheet_Changed( hDlg, hwnd );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_Changed")]
	public static void PropSheet_Changed(HWND hDlg, HPROPSHEETPAGE hwnd) =>
			SendMessage(hDlg, PropSheetMessage.PSM_CHANGED, (IntPtr)hwnd);

	/// <summary>Enables or disables buttons in an Aero wizard. You can use this macro or send the PSM_ENABLEWIZBUTTONS message explicitly.</summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the wizard.</para>
	/// </param>
	/// <param name="dwState">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// One or more of the following values that specify which property sheet buttons are to be enabled. If a button value is included in
	/// both this parameter and <c>dwMask</c>, it is enabled.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>PSWIZB_BACK</c></description>
	/// <description>0x0001. The <c>Back</c> button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSWIZB_NEXT</c></description>
	/// <description>0x0002. The <c>Next</c> button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSWIZB_FINISH</c></description>
	/// <description>0x0004. The <c>Finish</c> button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSWIZB_CANCEL</c></description>
	/// <description>0x0010. The <c>Cancel</c> button.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwMask">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// One or more of the same values used in <c>dwState</c>, specifying which buttons are affected by this call. If a button value appears
	/// in this parameter but not in <c>dwState</c>, the button is disabled.
	/// </para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>The following example code enables the <c>Back</c> button and disables the <c>Next</c> button.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_enablewizbuttons void PropSheet_EnableWizButtons( hDlg,
	// dwState, dwMask );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_EnableWizButtons")]
	public static void PropSheet_EnableWizButtons(HWND hDlg, PSWIZB dwState, PSWIZB dwMask) =>
			PostMessage(hDlg, PropSheetMessage.PSM_ENABLEWIZBUTTONS, (IntPtr)Convert.ToInt32(dwState), (IntPtr)Convert.ToInt32(dwMask));

	/// <summary>
	/// Retrieves a handle to the window of the current page of a property sheet. You can use this macro or send the PSM_GETCURRENTPAGEHWND
	/// message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// Use the <c>PropSheet_GetCurrentPageHwnd</c> macro with modeless property sheets to determine when to destroy the dialog box. When the
	/// user clicks the <c>OK</c> or <c>Cancel</c> button, <c>PropSheet_GetCurrentPageHwnd</c> returns <c>NULL</c>, and you can then use the
	/// DestroyWindow function to destroy the dialog box.
	/// </para>
	/// <para><c>Note</c>  This macro is not supported when using the Aero wizard style (PSH_AEROWIZARD).</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_getcurrentpagehwnd void PropSheet_GetCurrentPageHwnd(
	// hDlg );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_GetCurrentPageHwnd")]
	public static HPROPSHEETPAGE PropSheet_GetCurrentPageHwnd(HWND hDlg) =>
			(HPROPSHEETPAGE)SendMessage(hDlg, PropSheetMessage.PSM_GETCURRENTPAGEHWND);

	/// <summary>
	/// Used by modeless property sheets to retrieve the information returned to modal property sheets by PropertySheet. You can use this
	/// macro or sent the PSM_GETRESULT message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet's dialog box.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>To retrieve extended error information, call GetLastError.</para>
	/// <para>The return value is identical to what PropertySheet would have returned had this been a modal property sheet.</para>
	/// <para>
	/// Version 5.80. The PropertySheet return value carries different information for modal and modeless property sheets. In some cases,
	/// modeless property sheets may need the information they would have received from <c>PropertySheet</c> if they had been modal. In
	/// particular, they may need to know whether ID_PSREBOOTSYSTEM or ID_PSRESTARTWINDOWS would have been returned.
	/// </para>
	/// <para>
	/// For a modeless property sheet, your message loop should use PSM_ISDIALOGMESSAGE to pass messages to the property sheet dialog box,
	/// and PSM_GETCURRENTPAGEHWND to determine when to destroy the dialog box. When the user clicks the <c>OK</c> or <c>Cancel</c> button,
	/// <c>PSM_GETCURRENTPAGEHWND</c> returns <c>NULL</c>. You can then retrieve the value that a modal property sheet would have received
	/// from PropertySheet by sending a PSM_GETRESULT message.
	/// </para>
	/// <para><c>Note</c>  This macro is not supported when using the Aero wizard style (PSH_AEROWIZARD).</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_getresult void PropSheet_GetResult( hDlg );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_GetResult")]
	public static int PropSheet_GetResult(HWND hDlg) =>
			SendMessage(hDlg, PropSheetMessage.PSM_GETRESULT).ToInt32();

	/// <summary>
	/// Retrieves the handle to the tab control of a property sheet. You can use this macro or send the PSM_GETTABCONTROL message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para><c>Note</c>  This macro is not supported when using the Aero wizard style (PSH_AEROWIZARD).</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_gettabcontrol void PropSheet_GetTabControl( hDlg );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_GetTabControl")]
	public static HWND PropSheet_GetTabControl(HWND hDlg) =>
			(HWND)SendMessage(hDlg, PropSheetMessage.PSM_GETTABCONTROL);

	/// <summary>
	/// Takes a window handle of the property sheet page and returns its zero-based index. You can use this macro or send the PSM_HWNDTOINDEX
	/// message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet's window.</para>
	/// </param>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the page's window.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_hwndtoindex void PropSheet_HwndToIndex( hDlg, hwnd );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_HwndToIndex")]
	public static int PropSheet_HwndToIndex(HWND hDlg, HPROPSHEETPAGE hwnd) =>
			SendMessage(hDlg, PropSheetMessage.PSM_HWNDTOINDEX, (IntPtr)hwnd).ToInt32();

	/// <summary>
	/// Takes the resource identifier (ID) of a property sheet page and returns its zero-based index. You can use this macro or send the
	/// PSM_IDTOINDEX message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet window.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>int</c></para>
	/// <para>Resource ID of the page.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_idtoindex void PropSheet_IdToIndex( hDlg, id );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_IdToIndex")]
	public static int PropSheet_IdToIndex(HWND hDlg, int id) =>
			SendMessage(hDlg, PropSheetMessage.PSM_IDTOINDEX, default, (IntPtr)id).ToInt32();

	/// <summary>
	/// Takes the index of a property sheet page and returns its window handle. You can use this macro or send the PSM_INDEXTOHWND message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet page's window.</para>
	/// </param>
	/// <param name="i">
	/// <para>Type: <c>int</c></para>
	/// <para>Zero-based index of the page.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_indextohwnd void PropSheet_IndexToHwnd( hDlg, i );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_IndexToHwnd")]
	public static HPROPSHEETPAGE PropSheet_IndexToHwnd(HWND hDlg, int i) =>
			(HPROPSHEETPAGE)SendMessage(hDlg, PropSheetMessage.PSM_INDEXTOHWND, (IntPtr)i);

	/// <summary>
	/// Takes the index of a property sheet page and returns its resource identifier (ID). You can use this macro or send the PSM_INDEXTOID
	/// message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <param name="i">
	/// <para>Type: <c>int</c></para>
	/// <para>Zero-based index of the page.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_indextoid void PropSheet_IndexToId( hDlg, i );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_IndexToId")]
	public static int PropSheet_IndexToId(HWND hDlg, int i) =>
			SendMessage(hDlg, PropSheetMessage.PSM_INDEXTOID, (IntPtr)i).ToInt32();

	/// <summary>
	/// Takes the index of a property sheet page and returns its HPROPSHEETPAGE handle. You can use this macro or send the PSM_INDEXTOPAGE
	/// message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet window.</para>
	/// </param>
	/// <param name="i">
	/// <para>Type: <c>int</c></para>
	/// <para>Zero-based index of the page.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_indextopage void PropSheet_IndexToPage( hDlg, i );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_IndexToPage")]
	public static HPROPSHEETPAGE PropSheet_IndexToPage(HWND hDlg, int i) =>
			(HPROPSHEETPAGE)SendMessage(hDlg, PropSheetMessage.PSM_INDEXTOPAGE, (IntPtr)i);

	/// <summary>
	/// Inserts a new page into an existing property sheet. The page can be inserted either at a specified index or after a specified page.
	/// You can use this macro or send the PSM_INSERTPAGE message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// Where the page is to be inserted. Set <c>wParam</c> to <c>NULL</c> to make the new page the first page. To specify where the new page
	/// is to be inserted, you can either pass an index or an existing page's HPROPSHEETPAGE handle.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>index</c></description>
	/// <description>
	/// If <c>wParam</c> is less than MAXUSHORT (the largest unsigned short integer), it specifies the zero-based index for the new page. For
	/// example, to make the inserted page the third page on the property sheet, set <c>index</c> to 2. To make it the first page, set
	/// <c>index</c> to 0. If <c>index</c> has a value greater than the number of pages and less than MAXUSHORT, the page will be appended.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>hpageInsertAfter</c></description>
	/// <description>If you set <c>wParam</c> to an existing page's HPROPSHEETPAGE handle, the new page will be inserted after it.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hpage">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the page to be inserted. The page must first be created by a call to the CreatePropertySheetPage function.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The pages after the insertion point are shifted to the right to accommodate the new page.</para>
	/// <para>The property sheet is not resized to fit the new page. Do not make the new page larger than the property sheet's largest page.</para>
	/// <para>
	/// A number of messages and one function call occur while the property sheet is manipulating the list of pages. While this action is
	/// taking place, attempting to modify the list of pages will have unpredictable results. Accordingly, you should not use the
	/// <c>PropSheet_InsertPage</c> macro in your implementation of PropSheetPageProc or while handling the following notifications and
	/// Windows messages.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>PSN_APPLY</description>
	/// </item>
	/// <item>
	/// <description>PSN_KILLACTIVE</description>
	/// </item>
	/// <item>
	/// <description>PSN_RESET</description>
	/// </item>
	/// <item>
	/// <description>PSN_SETACTIVE</description>
	/// </item>
	/// <item>
	/// <description>WM_DESTROY</description>
	/// </item>
	/// <item>
	/// <description>WM_INITDIALOG</description>
	/// </item>
	/// </list>
	/// <para>
	/// If you need to modify a property sheet page while you are handling one of these messages or while PropSheetPageProc is in operation,
	/// post yourself a private Windows message. Your application will not receive that message until after the property sheet manager has
	/// finished its tasks. Then you can modify the list of pages.
	/// </para>
	/// <para>The following notifications are also affected by property sheet modification.</para>
	/// <list type="bullet">
	/// <item>
	/// <description>PSN_WIZBACK</description>
	/// </item>
	/// <item>
	/// <description>PSN_WIZNEXT</description>
	/// </item>
	/// </list>
	/// <para>
	/// You can add or remove pages in response to these notifications, provided that you return (via DWL_MSGRESULT) a nonzero value to
	/// specify the desired new page. Note, however, that if you insert a page that is located before the current page (that has a smaller
	/// index than the current page), PSN_KILLACTIVE might be sent to the wrong page.
	/// </para>
	/// <para><c>Note</c>  This macro is not supported when using the Aero wizard style (PSH_AEROWIZARD).</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_insertpage void PropSheet_InsertPage( hDlg, index, hpage );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_InsertPage")]
	public static bool PropSheet_InsertPage(HWND hDlg, IntPtr index, HPROPSHEETPAGE hpage) =>
			SendMessage(hDlg, PropSheetMessage.PSM_INSERTPAGE, index, (IntPtr)hpage) != IntPtr.Zero;

	/// <summary>
	/// Passes a message to a property sheet dialog box and indicates whether the dialog box processed the message. You can use this macro or
	/// send the PSM_ISDIALOGMESSAGE message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <param name="pMsg">
	/// <para>Type: <c>LPMSG</c></para>
	/// <para>Pointer to an MSG structure that contains the message to be checked.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// Your message loop should use the <c>PropSheet_IsDialogMessage</c> macro with modeless property sheets to pass messages to the
	/// property sheet dialog box. On systems that support Unicode, use the Unicode versions of the GetMessage and PeekMessage functions (
	/// <c>GetMessageW</c> and <c>PeekMessageW</c>) to retrieve messages.
	/// </para>
	/// <para>
	/// If the return value indicates that the message was processed, it must not be passed to the TranslateMessage or DispatchMessage function.
	/// </para>
	/// <para><c>Note</c>  This macro is not supported when using the Aero wizard style (PSH_AEROWIZARD).</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_isdialogmessage void PropSheet_IsDialogMessage( hDlg,
	// pMsg );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_IsDialogMessage")]
	public static bool PropSheet_IsDialogMessage(HWND hDlg, MSG pMsg) =>
			SendMessage(hDlg, PropSheetMessage.PSM_ISDIALOGMESSAGE, default, ref pMsg) != IntPtr.Zero;

	/// <summary>
	/// Takes the HPROPSHEETPAGE handle of a property sheet page and returns its zero-based index. You can use this macro or send the
	/// PSM_PAGETOINDEX message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <param name="hpage">
	/// <para>Type: <c>HPROPSHEETPAGE</c></para>
	/// <para>HPROPSHEETPAGE handle to the property sheet page.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_pagetoindex void PropSheet_PageToIndex( hDlg, hpage );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_PageToIndex")]
	public static int PropSheet_PageToIndex(HWND hDlg, HPROPSHEETPAGE hpage) =>
			SendMessage(hDlg, PropSheetMessage.PSM_PAGETOINDEX, default, (IntPtr)hpage).ToInt32();

	/// <summary>Simulates the selection of a property sheet button. You can use this macro or send the PSM_PRESSBUTTON message explicitly.</summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <param name="iButton">
	/// <para>Type: <c>int</c></para>
	/// <para>Index of the button to select. This parameter can be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>PSBTN_APPLYNOW</c></description>
	/// <description>Selects the Apply button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSBTN_BACK</c></description>
	/// <description>Selects the Back button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSBTN_CANCEL</c></description>
	/// <description>Selects the Cancel button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSBTN_FINISH</c></description>
	/// <description>Selects the Finish button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSBTN_HELP</c></description>
	/// <description>Selects the Help button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSBTN_NEXT</c></description>
	/// <description>Selects the Next button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSBTN_OK</c></description>
	/// <description>Selects the OK button.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_pressbutton void PropSheet_PressButton( hDlg, iButton );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_PressButton")]
	public static void PropSheet_PressButton(HWND hDlg, PSBTN iButton) =>
			PostMessage(hDlg, PropSheetMessage.PSM_PRESSBUTTON, (IntPtr)iButton, default);

	/// <summary>
	/// Causes a property sheet to send the PSM_QUERYSIBLINGS message to each of its pages. You can use this macro or send the
	/// <c>PSM_QUERYSIBLINGS</c> message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <param name="wParam">
	/// <para>Type: <c>WPARAM</c></para>
	/// <para>First application-defined parameter.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LPARAM</c></para>
	/// <para>Second application-defined parameter.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>If a page returns a nonzero value, the property sheet does not send the message to subsequent pages.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_querysiblings void PropSheet_QuerySiblings( hDlg, wParam,
	// lParam );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_QuerySiblings")]
	public static int PropSheet_QuerySiblings(HWND hDlg, IntPtr wParam, IntPtr lParam) =>
			SendMessage(hDlg, PropSheetMessage.PSM_QUERYSIBLINGS, wParam, lParam).ToInt32();

	/// <summary>
	/// Indicates the system needs to be restarted for the changes to take effect. You can use this macro or send the PSM_REBOOTSYSTEM
	/// message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>An application should send the PSM_REBOOTSYSTEM message only in response to the PSN_APPLY or PSN_KILLACTIVE notification code.</para>
	/// <para>
	/// This macro causes the PropertySheet function to return the ID_PSREBOOTSYSTEM value, but only if the user clicks the <c>OK</c> button
	/// to close the property sheet. It is the application's responsibility to reboot the system, which can be done by using the
	/// ExitWindowsEx function.
	/// </para>
	/// <para>This macro supersedes all <c>PropSheet_RebootSystem</c> macros that precede or follow it.</para>
	/// <para><c>Note</c>  This macro is not supported when using the Aero wizard style (PSH_AEROWIZARD).</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_rebootsystem void PropSheet_RebootSystem( hDlg );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_RebootSystem")]
	public static void PropSheet_RebootSystem(HWND hDlg) =>
			SendMessage(hDlg, PropSheetMessage.PSM_REBOOTSYSTEM);

	/// <summary>
	/// Recalculates the page size of a standard or wizard property sheet after pages have been added or removed. You can use this macro or
	/// send the PSM_RECALCPAGESIZES message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet's dialog box.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// When a property sheet is created, it is sized to fit its initial collection of pages. To maintain compatibility with previous
	/// versions of the common controls, property sheets and wizards do not automatically resize themselves when pages are subsequently added
	/// or removed. With common controls version 5.80 and later, applications should use the <c>PropSheet_RecalcPageSizes</c> macro after
	/// adding or removing pages with PropSheet_AddPage, PropSheet_InsertPage, PropSheet_RemovePage, or their equivalent messages. It ensures
	/// that the property sheet is properly sized for its current collection of pages. If this macro or the equivalent message is not used,
	/// some property sheet pages may be truncated or too large.
	/// </para>
	/// <para><c>Note</c>  This macro is not supported when using the Aero wizard style (PSH_AEROWIZARD).</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_recalcpagesizes void PropSheet_RecalcPageSizes( hDlg );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_RecalcPageSizes")]
	public static bool PropSheet_RecalcPageSizes(HWND hDlg) =>
			SendMessage(hDlg, PropSheetMessage.PSM_RECALCPAGESIZES) != IntPtr.Zero;

	/// <summary>Removes a page from a property sheet. You can use this macro or send the PSM_REMOVEPAGE message explicitly.</summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <c>int</c></para>
	/// <para>Zero-based index of the page to be removed.</para>
	/// </param>
	/// <param name="hpage">
	/// <para>Type: <c>HPROPSHEETPAGE</c></para>
	/// <para>Handle to the page to be removed.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// An application can specify the page to be removed by assigning a value to either <c>index</c> or <c>hpage</c>. If values are assigned
	/// to both <c>index</c> and <c>hpage</c>, <c>hpage</c> takes precedence.
	/// </para>
	/// <para>
	/// A number of messages and one function call occur while the property sheet is manipulating the list of pages. While this action is
	/// taking place, attempting to modify the list of pages will have unpredictable results. Accordingly, you should not use the
	/// <c>PropSheet_RemovePage</c> macro in your implementation of PropSheetPageProc or while handling the following notifications and
	/// Windows messages.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>PSN_APPLY</description>
	/// </item>
	/// <item>
	/// <description>PSN_KILLACTIVE</description>
	/// </item>
	/// <item>
	/// <description>PSN_RESET</description>
	/// </item>
	/// <item>
	/// <description>PSN_SETACTIVE</description>
	/// </item>
	/// <item>
	/// <description>WM_DESTROY</description>
	/// </item>
	/// <item>
	/// <description>WM_INITDIALOG</description>
	/// </item>
	/// </list>
	/// <para>
	/// If you need to modify a property sheet page while you are handling one of these messages or while PropSheetPageProc is in operation,
	/// post yourself a private Windows message. Your application will not receive that message until after the property sheet manager has
	/// finished its tasks. Then you can modify the list of pages.
	/// </para>
	/// <para>The following notifications are also affected by property sheet modification.</para>
	/// <list type="bullet">
	/// <item>
	/// <description>PSN_WIZBACK</description>
	/// </item>
	/// <item>
	/// <description>PSN_WIZNEXT</description>
	/// </item>
	/// </list>
	/// <para>
	/// You can add or remove pages in response to these notifications, provided that you return (via DWL_MSGRESULT) a nonzero value to
	/// specify the desired new page. Note, however, that if you remove a page that is located before the current page (that has a smaller
	/// index than the current page), PSN_KILLACTIVE might be sent to the wrong page.
	/// </para>
	/// <para><c>Note</c>  This macro is not supported when using the Aero wizard style (PSH_AEROWIZARD).</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_removepage void PropSheet_RemovePage( hDlg, index, hpage );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_RemovePage")]
	public static void PropSheet_RemovePage(HWND hDlg, int index, HPROPSHEETPAGE hpage) =>
			SendMessage(hDlg, PropSheetMessage.PSM_REMOVEPAGE, index, (IntPtr)hpage);

	/// <summary>
	/// Sends a PSM_RESTARTWINDOWS message indicating that Windows needs to be restarted for changes to take effect. You can use this macro
	/// or send the <c>PSM_RESTARTWINDOWS</c> message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// An application should send the PSM_RESTARTWINDOWS message only in response to the PSN_APPLY or PSN_KILLACTIVE notification code.
	/// </para>
	/// <para>
	/// The PSM_RESTARTWINDOWS message causes the PropertySheet function to return the ID_PSRESTARTWINDOWS value, but only if the user clicks
	/// the <c>OK</c> button to close the property sheet. It is the application's responsibility to restart Windows, which can be done by
	/// using the ExitWindowsEx function.
	/// </para>
	/// <para><c>Note</c>  This macro is not supported when using the Aero wizard style (PSH_AEROWIZARD).</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_restartwindows void PropSheet_RestartWindows( hDlg );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_RestartWindows")]
	public static void PropSheet_RestartWindows(HWND hDlg) =>
			SendMessage(hDlg, PropSheetMessage.PSM_RESTARTWINDOWS);

	/// <summary>Activates the specified page in a property sheet. You can use this macro or send the PSM_SETCURSEL message explicitly.</summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <param name="hpage">
	/// <para>Type: <c>HPROPSHEETPAGE</c></para>
	/// <para>
	/// Handle to the page to activate. An application can specify the index or the handle, or both. If both are specified, <c>hpage</c>
	/// takes precedence.
	/// </para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Zero-based index of the page. An application can specify the index or the handle, or both. If both are specified, <c>hpage</c> takes precedence.
	/// </para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// The window that is losing the activation receives the PSN_KILLACTIVE notification code, and the window that is gaining the activation
	/// receives the PSN_SETACTIVE notification code.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_setcursel void PropSheet_SetCurSel( hDlg, hpage, index );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_SetCurSel")]
	public static bool PropSheet_SetCurSel(HWND hDlg, HPROPSHEETPAGE hpage, uint index) =>
			SendMessage(hDlg, PropSheetMessage.PSM_SETCURSEL, (IntPtr)index, (IntPtr)hpage) != IntPtr.Zero;

	/// <summary>
	/// Activates the specified page in a property sheet based on the resource identifier of the page. You can use this macro or send the
	/// PSM_SETCURSELID message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>int</c></para>
	/// <para>Resource identifier of the page to activate.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// The window that is losing the activation receives the PSN_KILLACTIVE notification code, and the window that is gaining the activation
	/// receives the PSN_SETACTIVE notification code.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_setcurselbyid void PropSheet_SetCurSelByID( hDlg, id );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_SetCurSelByID")]
	public static bool PropSheet_SetCurSelByID(HWND hDlg, int id) =>
			SendMessage(hDlg, PropSheetMessage.PSM_SETCURSELID, default, (IntPtr)id) != IntPtr.Zero;

	/// <summary>
	/// Sets the text of the Finish button in a wizard, shows and enables the button, and hides the Next and Back buttons. You can use this
	/// macro or send the PSM_SETFINISHTEXT message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Window handle (HWND) of the wizard property sheet.</para>
	/// </param>
	/// <param name="lpszText">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>Pointer to the new text for the Finish button.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// By default, the Finish button does not have a keyboard accelerator. You can create a keyboard accelerator with this macro by
	/// including an ampersand (&amp;) in the text string that you assign to <c>lpszText</c>. For example, "&amp;Finish" defines F as the
	/// accelerator key.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_setfinishtext void PropSheet_SetFinishText( hDlg,
	// lpszText );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_SetFinishText")]
	public static void PropSheet_SetFinishText(HWND hDlg, string lpszText) =>
			SendMessage(hDlg, Marshal.SystemDefaultCharSize == 1 ? PropSheetMessage.PSM_SETFINISHTEXTA : PropSheetMessage.PSM_SETFINISHTEXTW, default, lpszText);

	/// <summary>
	/// Sets the subtitle text for the header of a wizard's interior page. You can use this macro or send the PSM_SETHEADERSUBTITLE message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the wizard's window.</para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <c>int</c></para>
	/// <para>Zero-based index of the page.</para>
	/// </param>
	/// <param name="lpszText">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>New header subtitle.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>If you specify the current page, it will immediately be repainted to display the new subtitle.</para>
	/// <para><c>Note</c>  This macro is not supported when using the Aero wizard style (PSH_AEROWIZARD).</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_setheadersubtitle void PropSheet_SetHeaderSubTitle( hDlg,
	// index, lpszText );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_SetHeaderSubTitle")]
	public static void PropSheet_SetHeaderSubTitle(HWND hDlg, int index, string lpszText) =>
			SendMessage(hDlg, Marshal.SystemDefaultCharSize == 1 ? PropSheetMessage.PSM_SETHEADERSUBTITLEA : PropSheetMessage.PSM_SETHEADERSUBTITLEW, (IntPtr)index, lpszText);

	/// <summary>
	/// Sets the title text for the header of a wizard's interior page. You can use this macro or send the PSM_SETHEADERTITLE message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the wizard's window.</para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <c>int</c></para>
	/// <para>Zero-based index of the page.</para>
	/// </param>
	/// <param name="lpszText">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>New header title.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>If you specify the current page, it will immediately be repainted to display the new title.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_setheadertitle void PropSheet_SetHeaderTitle( hDlg,
	// index, lpszText );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_SetHeaderTitle")]
	public static void PropSheet_SetHeaderTitle(HWND hDlg, int index, string lpszText) =>
			SendMessage(hDlg, Marshal.SystemDefaultCharSize == 1 ? PropSheetMessage.PSM_SETHEADERTITLEA : PropSheetMessage.PSM_SETHEADERTITLEW, (IntPtr)index, lpszText);

	/// <summary>Sets the text of the <c>Next</c> button in a wizard. You can use this macro or send the PSM_SETNEXTTEXT message explicitly.</summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the wizard.</para>
	/// </param>
	/// <param name="lpszText">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>Pointer to a buffer that contains the text.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_setnexttext void PropSheet_SetNextText( hDlg, lpszText );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_SetNextText")]
	public static void PropSheet_SetNextText(HWND hDlg, string lpszText) =>
			SendMessage(hDlg, PropSheetMessage.PSM_SETNEXTTEXT, default, lpszText);

	/// <summary>Sets the title of a property sheet. You can use this macro or send the PSM_SETTITLE message explicitly.</summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <param name="wStyle">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// Flag that indicates whether to include the prefix "Properties for" with the specified title string. If <c>dwStyle</c> is the
	/// PSH_PROPTITLE value, the prefix is included. Otherwise, the prefix is not used.
	/// </para>
	/// </param>
	/// <param name="lpszText">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// Pointer to a buffer that contains the title string. If the HIWORD of this parameter is <c>NULL</c>, the property sheet loads the
	/// string resource specified in the LOWORD.
	/// </para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// In an Aero Wizard, this macro can be used to change the title of an interior page dynamically; for example, when handling the
	/// PSN_SETACTIVE notification.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_settitle void PropSheet_SetTitle( hDlg, wStyle, lpszText );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_SetTitle")]
	public static void PropSheet_SetTitle(HWND hDlg, PropSheetHeaderFlags wStyle, ResourceId lpszText) =>
			SendMessage(hDlg, Marshal.SystemDefaultCharSize == 1 ? PropSheetMessage.PSM_SETTITLEA : PropSheetMessage.PSM_SETTITLEW, wStyle, (IntPtr)lpszText);

	/// <summary>
	/// Enables or disables the Back, Next, and Finish buttons in a wizard by posting a PSM_SETWIZBUTTONS message. You can use this macro or
	/// send the <c>PSM_SETWIZBUTTONS</c> message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>A value that specifies which wizard buttons are enabled. You can combine one or more of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>PSWIZB_BACK</c></description>
	/// <description>Enable the Back button. If this flag is not set, the Back button is displayed as disabled.</description>
	/// </item>
	/// <item>
	/// <description><c>PSWIZB_DISABLEDFINISH</c></description>
	/// <description>Display a disabled Finish button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSWIZB_FINISH</c></description>
	/// <description>Display an enabled Finish button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSWIZB_NEXT</c></description>
	/// <description>Enable the Next button. If this flag is not set, the Next button is displayed as disabled.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// This macro uses PostMessage to send the PSM_SETWIZBUTTONS message. If your notification handler calls <c>PropSheet_SetWizButtons</c>,
	/// do nothing that will affect window focus until after the handler returns. For example, if you call MessageBox immediately after
	/// calling <c>PropSheet_SetWizButtons</c>, the message box will receive focus. Since messages sent with <c>PostMessage</c> are not
	/// delivered until they reach the head of the message queue, the <c>PSM_SETWIZBUTTONS</c> message will not be delivered until after the
	/// wizard has lost focus to the message box. As a result, the property sheet will not be able to properly set the focus for the buttons.
	/// </para>
	/// <para>
	/// Wizards display either three or four buttons below each page. This message is used to specify which buttons are enabled. Wizards
	/// normally display Back, Cancel, and either a Next or Finish button. You typically enable only the Next button for the welcome page,
	/// Next and Back for interior pages, and Back and Finish for the completion page. The Cancel button is always enabled. Normally, setting
	/// PSWIZB_FINISH or PSWIZB_DISABLEDFINISH replaces the Next button with a Finish button. To display Next and Finish buttons
	/// simultaneously, set the PSH_WIZARDHASFINISH FLAG in the <c>dwFlags</c> member of the wizard's PROPSHEETHEADER structure when you
	/// create the wizard. Every page will then display all four buttons.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_setwizbuttons void PropSheet_SetWizButtons( hDlg, dwFlags );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_SetWizButtons")]
	public static void PropSheet_SetWizButtons(HWND hDlg, PSWIZB dwFlags) =>
			PostMessage(hDlg, PropSheetMessage.PSM_SETWIZBUTTONS, default, (IntPtr)dwFlags);

	/// <summary>Show or hide buttons in a wizard. You can use this macro or send the PSM_SHOWWIZBUTTONS message explicitly.</summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the wizard.</para>
	/// </param>
	/// <param name="dwFlag">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// One or more of the following values that specify which property sheet buttons are to be shown. If a button value is included in both
	/// this parameter and <c>dwButton</c> then it is shown.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>PSWIZB_BACK</c></description>
	/// <description>0x0001. The <c>Back</c> button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSWIZB_NEXT</c></description>
	/// <description>0x0002. The <c>Next</c> button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSWIZB_FINISH</c></description>
	/// <description>0x0004. The <c>Finish</c> button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSWIZB_CANCEL</c></description>
	/// <description>0x0010. The <c>Cancel</c> button.</description>
	/// </item>
	/// <item>
	/// <description><c>PSWIZB_SHOW</c></description>
	/// <description>Set only this flag (defined as zero) to hide all buttons specified in <c>dwButton</c>.</description>
	/// </item>
	/// <item>
	/// <description><c>PSWIZB_RESTORE</c></description>
	/// <description>Not implemented.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwButton">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// One or more of the same values used in <c>dwFlag</c>. Here, they specify which property sheet buttons are to be shown or hidden. If a
	/// button value appears in this parameter but not in <c>dwFlag</c>, it indicates that the button should be hidden.
	/// </para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>The following example code hides the <c>Back</c> button and shows the <c>Next</c> button.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_showwizbuttons void PropSheet_ShowWizButtons( hDlg,
	// dwFlag, dwButton );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_ShowWizButtons")]
	public static void PropSheet_ShowWizButtons(HWND hDlg, PSWIZB dwFlag, PSWIZB dwButton) =>
		SendMessage(hDlg, (uint)PropSheetMessage.PSM_SHOWWIZBUTTONS, (IntPtr)(int)dwFlag, (IntPtr)(int)dwButton);

	/// <summary>
	/// Informs a property sheet that information in a page has reverted to the previously saved state. You can use this macro or send the
	/// PSM_UNCHANGED message explicitly.
	/// </summary>
	/// <param name="hDlg">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the property sheet.</para>
	/// </param>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>Handle to the page that has reverted to the previously saved state.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The property sheet disables the <c>Apply Now</c> button if no other pages have registered changes with the property sheet.</para>
	/// <para><c>Note</c>  This macro is not supported when using the Aero wizard style (PSH_AEROWIZARD).</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/nf-prsht-propsheet_unchanged void PropSheet_UnChanged( hDlg, hwnd );
	[PInvokeData("prsht.h", MSDNShortId = "NF:prsht.PropSheet_UnChanged")]
	public static void PropSheet_UnChanged(HWND hDlg, HPROPSHEETPAGE hwnd) =>
			SendMessage(hDlg, PropSheetMessage.PSM_UNCHANGED, (IntPtr)hwnd, 0);

	/// <summary>Defines the frame and pages of a property sheet.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774546")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PROPSHEETHEADER
	{
		/// <summary>
		/// Size, in bytes, of this structure. The property sheet manager uses this member to determine which version of the PROPSHEETHEADER
		/// structure you are using. For more information, see the Remarks.
		/// </summary>
		public uint dwSize;

		/// <summary>Flags that indicate which options to use when creating the property sheet page.</summary>
		public PropSheetHeaderFlags dwFlags;

		/// <summary>Handle to the property sheet's owner window.</summary>
		public HWND hwndParent;

		/// <summary>
		/// Handle to the instance from which to load the icon or title string resource. If the pszIcon or pszCaption member identifies a
		/// resource to load, this member must be specified.
		/// </summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// Handle to the icon to use as the small icon in the title bar of the property sheet dialog box. If the dwFlags member does not
		/// include PSH_USEHICON, this member is ignored. This member is declared as a union with pszIcon.
		/// <para><c>OR</c></para>
		/// <para>
		/// String icon resource to use as the small icon in the title bar of the property sheet dialog box. This member can specify either
		/// the identifier of the icon resource or the address of the string that specifies the name of the icon resource. If the dwFlags
		/// member does not include PSH_USEICONID, this member is ignored. This member is declared as a union with hIcon.
		/// </para>
		/// </summary>
		public ResourceIdOrHandle<HICON> pIcon;

		/// <summary>
		/// Title of the property sheet dialog box. This member can specify either the identifier of a string resource or the address of a
		/// string that specifies the title. If the dwFlags member includes PSH_PROPTITLE, the string "Properties for" is inserted at the
		/// beginning of the title. This field is ignored for Wizard97 wizards. For Aero wizards, the string alone is used for the caption,
		/// regardless of whether the PSH_PROPTITLE flag is set.
		/// </summary>
		public ResourceId pszCaption;

		/// <summary>Number of elements in the phpage array.</summary>
		public uint nPages;

		/// <summary>
		/// Zero-based index of the initial page that appears when the property sheet dialog box is created. This member is declared as a
		/// union with pStartPage.
		/// <para><c>OR</c></para>
		/// <para>
		/// Name of the initial page that appears when the property sheet dialog box is created. This member can specify either the
		/// identifier of a string resource or the address of a string that specifies the name. This member is declared as a union with nStartPage.
		/// </para>
		/// </summary>
		public ResourceId pStartPage;

		/// <summary>
		/// Pointer to an array of PROPSHEETPAGE structures that define the pages in the property sheet. If the dwFlags member does not
		/// include PSH_PROPSHEETPAGE, this member is ignored. Note that the PROPSHEETPAGE structure is variable in size. Applications that
		/// parse the array pointed to by ppsp must take the size of each page into account. This member is declared as a union with phpage.
		/// <para><c>OR</c></para>
		/// <para>
		/// Pointer to an array of handles to the property sheet pages. Each handle must have been created by a previous call to the
		/// CreatePropertySheetPage function. If the dwFlags member includes PSH_PROPSHEETPAGE, phpage is ignored and should be set to NULL.
		/// When the PropertySheet function returns, any HPROPSHEETPAGE handles in the phpage array will have been destroyed. This member is
		/// declared as a union with ppsp.
		/// </para>
		/// </summary>
		public IntPtr phpage;

		/// <summary>
		/// Pointer to an application-defined callback function that is called when the property sheet is initialized. For more information
		/// about the callback function, see the description of the PropSheetProc function. If the dwFlags member does not include
		/// PSH_USECALLBACK, this member is ignored.
		/// </summary>
		public PropSheetProc pfnCallback;

		/// <summary>
		/// Version 5.80 or later. Handle to the watermark bitmap. If the dwFlags member does not include PSH_USEHBMWATERMARK, this member is ignored.
		/// <para><c>OR</c></para>
		/// <para>
		/// Version 5.80 or later. Bitmap resource to use as the watermark. This member can specify either the identifier of the bitmap
		/// resource or the address of the string that specifies the name of the bitmap resource. If the dwFlags member includes
		/// PSH_USEHBMWATERMARK, this member is ignored.
		/// </para>
		/// </summary>
		public ResourceIdOrHandle<HBITMAP> hbmWatermark;

		/// <summary>
		/// Version 5.80 or later. HPALETTE structure used for drawing the watermark bitmap and/or header bitmap. If the dwFlags member does
		/// not include PSH_USEHPLWATERMARK, this member is ignored.
		/// </summary>
		public HPALETTE hplWatermark;

		/// <summary>
		/// Version 5.80 or later. Handle to the header bitmap. If the dwFlags member does not include PSH_USEHBMHEADER, this member is ignored.
		/// <para><c>OR</c></para>
		/// <para>
		/// Version 5.80 or later. Bitmap resource to use as the header. This member can specify either the identifier of the bitmap resource
		/// or the address of the string that specifies the name of the bitmap resource. If the dwFlags member includes PSH_USEHBMHEADER,
		/// this member is ignored.
		/// </para>
		/// </summary>
		public ResourceIdOrHandle<HBITMAP> hbmHeader;
	}

	/// <summary>Contains information for the property sheet notification messages.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/prsht/ns-prsht-pshnotify typedef struct _PSHNOTIFY { NMHDR hdr; LPARAM lParam; }
	// PSHNOTIFY, *LPPSHNOTIFY;
	[PInvokeData("prsht.h", MSDNShortId = "NS:prsht._PSHNOTIFY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PSHNOTIFY
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>Address of an NMHDR structure that contains additional information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>
		/// Additional information about this notification. To determine what, if any, information is contained in this member, see the
		/// description of the particular notification message.
		/// </para>
		/// </summary>
		public IntPtr lParam;
	}
	
	/// <summary>Defines a page in a property sheet.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb774548")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public class PROPSHEETPAGE : IDisposable
	{
		/// <summary>Size, in bytes, of this structure.</summary>
		public uint dwSize;

		/// <summary>Flags that indicate which options to use when creating the property sheet page.</summary>
		public PropSheetFlags dwFlags;

		/// <summary>
		/// Handle to the instance from which to load an icon or string resource. If the pszIcon, pszTitle, pszHeaderTitle, or
		/// pszHeaderSubTitle member identifies a resource to load, hInstance must be specified.
		/// </summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// Dialog box template to use to create the page. This member can specify either the resource identifier of the template or the
		/// address of a string that specifies the name of the template. If the PSP_DLGINDIRECT flag in the dwFlags member is set,
		/// pszTemplate is ignored. This member is declared as a union with pResource.
		/// </summary>
		private IntPtr _pszTemplate;

		/// <summary>
		/// Handle to the icon to use as the icon in the tab of the page. If the dwFlags member does not include PSP_USEHICON, this member is
		/// ignored. This member is declared as a union with pszIcon.
		/// <para><c>OR</c></para>
		/// <para>
		/// Icon resource to use as the icon in the tab of the page. This member can specify either the identifier of the icon resource or
		/// the address of the string that specifies the name of the icon resource. To use this member, you must set the PSP_USEICONID flag
		/// in the dwFlags member. This member is declared as a union with hIcon.
		/// </para>
		/// </summary>
		private IntPtr _hIcon;

		/// <summary>
		/// Title of the property sheet dialog box. This title overrides the title specified in the dialog box template. This member can
		/// specify either the identifier of a string resource or the address of a string that specifies the title. To use this member, you
		/// must set the PSP_USETITLE flag in the dwFlags member.
		/// </summary>
		private IntPtr _pszTitle;

		/// <summary>
		/// Pointer to the dialog box procedure for the page. Because the pages are created as modeless dialog boxes, the dialog box
		/// procedure must not call the EndDialog function.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DialogProc? pfnDlgProc;

		/// <summary>
		/// When the page is created, a copy of the page's PROPSHEETPAGE structure is passed to the dialog box procedure with a WM_INITDIALOG
		/// message. The lParam member is provided to allow you to pass application-specific information to the dialog box procedure. It has
		/// no effect on the page itself. For more information, see Property Sheet Creation.
		/// </summary>
		public IntPtr lParam;

		/// <summary>
		/// Pointer to an application-defined callback function that is called when the page is created and when it is about to be destroyed.
		/// For more information about the callback function, see PropSheetPageProc. To use this member, you must set the PSP_USECALLBACK
		/// flag in the dwFlags member.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		private PropSheetPageProc? _pfnCallback;

		/// <summary>Pointer to the reference count value. To use this member, you must set the PSP_USEREFPARENT flag in the dwFlags member.</summary>
		private IntPtr _pcRefParent;

		/// <summary>
		/// Version 5.80 or later. Title of the header area. To use this member under the Wizard97-style wizard, you must also do the following:
		/// <list type="bullet">
		/// <item>
		/// <term>Set the PSP_USEHEADERTITLE flag in the dwFlags member.</term>
		/// </item>
		/// <item>
		/// <term>Set the PSH_WIZARD97 flag in the dwFlags member of the page's PROPSHEETHEADER structure.</term>
		/// </item>
		/// <item>
		/// <term>Make sure that the PSP_HIDEHEADER flag in the dwFlags member is not set.</term>
		/// </item>
		/// </list>
		/// </summary>
		private IntPtr _pszHeaderTitle;

		/// <summary>
		/// Version 5.80 or later. Subtitle of the header area. To use this member, you must do the following:
		/// <list type="bullet">
		/// <item>
		/// <term>Set the PSP_USEHEADERSUBTITLE flag in the dwFlags member.</term>
		/// </item>
		/// <item>
		/// <term>Set the PSH_WIZARD97 flag in the dwFlags member of the page's PROPSHEETHEADER structure.</term>
		/// </item>
		/// <item>
		/// <term>Make sure that the PSP_HIDEHEADER flag in the dwFlags member is not set.</term>
		/// </item>
		/// </list>
		/// <note>This member is ignored when using the Aero-style wizard (PSH_AEROWIZARD).</note>
		/// </summary>
		private IntPtr _pszHeaderSubTitle;

		/// <summary>
		/// Version 6.0 or later. An activation context handle. Set this member to the handle that is returned when you create the activation
		/// context with CreateActCtx. The system will activate this context before creating the dialog box. You do not need to use this
		/// member if you use a global manifest.
		/// </summary>
		public HACTCTX hActCtx;

		/// <summary>Initializes a new instance of the <see cref="PROPSHEETPAGE"/> class and sets the value of <see cref="dwSize"/>.</summary>
		public PROPSHEETPAGE() => dwSize = (uint)Marshal.SizeOf(this);

		/// <summary>
		/// Dialog box template to use to create the page. This member can specify either the resource identifier of the template or the
		/// address of a string that specifies the name of the template. If the PSP_DLGINDIRECT flag in the dwFlags member is set,
		/// pszTemplate is ignored.
		/// </summary>
		public SafeResourceId pszTemplate
		{
			get => dwFlags.IsFlagSet(PropSheetFlags.PSP_DLGINDIRECT) ? SafeResourceId.Null : new SafeResourceId(_pszTemplate);
			set
			{
				if (!dwFlags.IsFlagSet(PropSheetFlags.PSP_DLGINDIRECT)) FreeResource(ref _pszTemplate);
				dwFlags = dwFlags.SetFlags(PropSheetFlags.PSP_DLGINDIRECT, false);
				_pszTemplate = GetClonedHandle(value);
			}
		}

		/// <summary>
		/// A pointer to a dialog box template in memory. The PropertySheet function assumes that the template is in writeable memory; a
		/// read-only template will cause an exception on some versions of Windows. If dwFlags does not include the PSP_DLGINDIRECT value,
		/// this member is ignored.
		/// </summary>
		public IntPtr pResource
		{
			get => _pszTemplate;
			set
			{
				if (!dwFlags.IsFlagSet(PropSheetFlags.PSP_DLGINDIRECT)) FreeResource(ref _pszTemplate);
				_pszTemplate = value;
				dwFlags = dwFlags.SetFlags(PropSheetFlags.PSP_DLGINDIRECT, true);
			}
		}

		/// <summary>
		/// A handle to the icon to use as the small icon in the tab for the page. If dwFlags does not include the PSP_USEHICON value, this
		/// member is ignored.
		/// </summary>
		public HICON hIcon
		{
			get => dwFlags.IsFlagSet(PropSheetFlags.PSP_USEHICON) ? _hIcon : IntPtr.Zero;
			set
			{
				if (dwFlags.IsFlagSet(PropSheetFlags.PSP_USEICONID)) FreeResource(ref _pszTemplate);
				_hIcon = (IntPtr)value;
				dwFlags = dwFlags.SetFlags(PropSheetFlags.PSP_USEICONID, false) | PropSheetFlags.PSP_USEHICON;
			}
		}

		/// <summary>
		/// Icon resource to use as the small icon in the tab for the page. This member can specify either the identifier of the icon
		/// resource or the pointer to the string that specifies the name of the icon resource. If dwFlags does not include the PSP_USEICONID
		/// value, this member is ignored.
		/// </summary>
		public SafeResourceId pszIcon
		{
			get => dwFlags.IsFlagSet(PropSheetFlags.PSP_USEICONID) ? new SafeResourceId(_hIcon) : SafeResourceId.Null;
			set
			{
				if (dwFlags.IsFlagSet(PropSheetFlags.PSP_USEICONID)) FreeResource(ref _hIcon);
				dwFlags = dwFlags.SetFlags(PropSheetFlags.PSP_USEHICON, false) | PropSheetFlags.PSP_USEICONID;
				_hIcon = GetClonedHandle(value);
			}
		}

		/// <summary>
		/// Title of the property sheet dialog box. This title overrides the title specified in the dialog box template. This member can
		/// specify either the identifier of a string resource or the pointer to a string that specifies the title. If dwFlags does not
		/// include the PSP_USETITLE value, this member is ignored.
		/// </summary>
		public SafeResourceId pszTitle
		{
			get => dwFlags.IsFlagSet(PropSheetFlags.PSP_USETITLE) ? new SafeResourceId(_pszTitle) : SafeResourceId.Null;
			set
			{
				if (dwFlags.IsFlagSet(PropSheetFlags.PSP_USETITLE)) FreeResource(ref _pszTitle);
				dwFlags = dwFlags.SetFlags(PropSheetFlags.PSP_USETITLE, !value.IsInvalid);
				_pszTitle = GetClonedHandle(value);
			}
		}

		/// <summary>
		/// Version 5.80 or later. Title of the header area. To use this member under the Wizard97-style wizard, you must also do the following:
		/// <list type="bullet">
		/// <item>
		/// <term>Set the PSP_USEHEADERTITLE flag in the dwFlags member.</term>
		/// </item>
		/// <item>
		/// <term>Set the PSH_WIZARD97 flag in the dwFlags member of the page's PROPSHEETHEADER structure.</term>
		/// </item>
		/// <item>
		/// <term>Make sure that the PSP_HIDEHEADER flag in the dwFlags member is not set.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SafeResourceId pszHeaderTitle
		{
			get => dwFlags.IsFlagSet(PropSheetFlags.PSP_USEHEADERTITLE) ? new SafeResourceId(_pszHeaderTitle) : SafeResourceId.Null;
			set
			{
				if (dwFlags.IsFlagSet(PropSheetFlags.PSP_USEHEADERTITLE)) FreeResource(ref _pszHeaderTitle);
				dwFlags = dwFlags.SetFlags(PropSheetFlags.PSP_USEHEADERTITLE, !value.IsInvalid);
				_pszHeaderTitle = GetClonedHandle(value);
			}
		}

		/// <summary>
		/// Version 5.80 or later. Subtitle of the header area. To use this member, you must do the following:
		/// <list type="bullet">
		/// <item>
		/// <term>Set the PSP_USEHEADERSUBTITLE flag in the dwFlags member.</term>
		/// </item>
		/// <item>
		/// <term>Set the PSH_WIZARD97 flag in the dwFlags member of the page's PROPSHEETHEADER structure.</term>
		/// </item>
		/// <item>
		/// <term>Make sure that the PSP_HIDEHEADER flag in the dwFlags member is not set.</term>
		/// </item>
		/// </list>
		/// <note>This member is ignored when using the Aero-style wizard (PSH_AEROWIZARD).</note>
		/// </summary>
		public SafeResourceId pszHeaderSubTitle
		{
			get => dwFlags.IsFlagSet(PropSheetFlags.PSP_USEHEADERSUBTITLE) ? new SafeResourceId(_pszHeaderSubTitle) : SafeResourceId.Null;
			set
			{
				if (dwFlags.IsFlagSet(PropSheetFlags.PSP_USEHEADERSUBTITLE)) FreeResource(ref _pszHeaderSubTitle);
				dwFlags = dwFlags.SetFlags(PropSheetFlags.PSP_USEHEADERSUBTITLE, !value.IsInvalid);
				_pszHeaderSubTitle = GetClonedHandle(value);
			}
		}

		/// <summary>
		/// Pointer to an application-defined callback function that is called when the page is created and when it is about to be destroyed.
		/// For more information about the callback function, see PropSheetPageProc. To use this member, you must set the PSP_USECALLBACK
		/// flag in the dwFlags member.
		/// </summary>
		public PropSheetPageProc? pfnCallback
		{
			get => _pfnCallback;
			set
			{
				dwFlags = dwFlags.SetFlags(PropSheetFlags.PSP_USECALLBACK, value != null);
				_pfnCallback = value;
			}
		}

		/// <summary>Pointer to the reference count value. To use this member, you must set the PSP_USEREFPARENT flag in the dwFlags member.</summary>
		public IntPtr pcRefParent
		{
			get => _pcRefParent;
			set
			{
				dwFlags = dwFlags.SetFlags(PropSheetFlags.PSP_USEREFPARENT, value != IntPtr.Zero);
				_pcRefParent = value;
			}
		}

		/// <inheritdoc/>
		void IDisposable.Dispose()
		{
			if (!dwFlags.IsFlagSet(PropSheetFlags.PSP_DLGINDIRECT)) FreeResource(ref _pszTemplate);
			if (dwFlags.IsFlagSet(PropSheetFlags.PSP_USEICONID)) FreeResource(ref _hIcon);
			FreeResource(ref _pszTitle);
			FreeResource(ref _pszHeaderTitle);
			FreeResource(ref _pszHeaderSubTitle);
			GC.SuppressFinalize(this);
		}

		private static IntPtr GetClonedHandle(SafeResourceId rid) => rid == null ? IntPtr.Zero : (rid.IsIntResource ? rid.DangerousGetHandle() : StringHelper.AllocString(rid.ToString()));

		private static void FreeResource(ref IntPtr ptr)
		{
			if (IS_INTRESOURCE(ptr) || ptr == IntPtr.Zero) return;
			StringHelper.FreeString(ptr);
			ptr = IntPtr.Zero;
		}
	}

	/// <summary>Provides a <see cref="SafeHandle"/> to a that releases a created HPROPSHEETPAGE instance at disposal using DestroyPropertySheetPage.</summary>
	[AutoSafeHandle("DestroyPropertySheetPage(handle)", typeof(HPROPSHEETPAGE))]
	public partial class SafeHPROPSHEETPAGE : IUserHandle { }
}