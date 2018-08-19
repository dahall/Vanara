using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Macros;
using static Vanara.PInvoke.User32_Gdi;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
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
		// BOOL CALLBACK AddPropSheetPageProc( HPROPSHEETPAGE hpage, LPARAM lParam);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb760805(v=vs.85).aspx
		[PInvokeData("Prsht.h", MSDNShortId = "bb760805")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool AddPropSheetPageProc(IntPtr hpage, IntPtr lParam);

		/// <summary>
		/// Specifies an application-defined callback function that a property sheet calls when a page is created and when it is about to be destroyed. An application can use this function to perform initialization and cleanup operations for the page.
		/// </summary>
		/// <param name="hwnd">Reserved; must be NULL.</param>
		/// <param name="uMsg">Action flag.</param>
		/// <param name="ppsp">Pointer to a PROPSHEETPAGE structure that defines the page being created or destroyed. See the Remarks section for further discussion.</param>
		/// <returns>The return value depends on the value of the uMsg parameter.</returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760813")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
		public delegate uint PropSheetPageProc(IntPtr hwnd, PropSheetPageCallbackAction uMsg, PROPSHEETPAGE ppsp);

		/// <summary>
		/// An application-defined callback function that the system calls when the property sheet is being created and initialized.
		/// </summary>
		/// <param name="hwndDlg">Handle to the property sheet dialog box.</param>
		/// <param name="uMsg">
		/// Message being received.This parameter is one of the following values.
		/// <list type="table">
		/// <listheader><term>Value</term><term>Meaning</term></listheader>
		/// <item><term>PSCB_BUTTONPRESSED</term><term>Version 6.0 and later.Indicates the user pressed a button in the property sheet dialog box.To enable this, specify PSH_USECALLBACK in PROPSHEETHEADER.dwFlags and specify the name of this callback function in PROPSHEETHEADER.pfnCallback. The lParam value is one of the following. Note that only PSBTN_CANCEL is valid when you are using the Aero wizard style(PSH_AEROWIZARD).
		/// <list type="table">
		/// <listheader><term>Button pressed</term><term>lParam value</term></listheader>
		/// <item><term>OK</term><term>PSBTN_OK</term></item>
		/// <item><term>Cancel</term><term>PSBTN_CANCEL</term></item>
		/// <item><term>Apply</term><term>PSBTN_APPLYNOW</term></item>
		/// <item><term>Close</term><term>PSBTN_FINISH</term></item>
		/// </list>
		/// <para>Note that Comctl32.dll versions 6 and later are not redistributable.To use these versions of Comctl32.dll, specify the particular version in a manifest. For more information on manifests, see Enabling Visual Styles.</para>
		/// </term></item>
		/// <item><term>PSCB_INITIALIZED</term><term>Indicates that the property sheet is being initialized. The lParam value is zero for this message.</term></item>
		/// <item><term>PSCB_PRECREATE</term><term>Indicates that the property sheet is about to be created. The hwndDlg parameter is NULL, and the lParam parameter is the address of a dialog template in memory.This template is in the form of a DLGTEMPLATE or DLGTEMPLATEEX structure followed by one or more DLGITEMTEMPLATE structures.This message is not applicable if you are using the Aero wizard style(PSH_AEROWIZARD).</term></item>
		/// </list>
		/// </param>
		/// <param name="lParam">Additional information about the message. The meaning of this value depends on the uMsg parameter.
		/// <para>If uMsg is PSCB_INITIALIZED or PSCB_BUTTONPRESSED, the value of lParam is zero.</para>
		/// <para>If uMsg is PSCB_PRECREATE, then lParam will be a pointer to either a DLGTEMPLATE or DLGTEMPLATEEX structure describing the property sheet dialog box. Test the signature of the structure to determine the type. If signature is equal to 0xFFFF then the structure is an extended dialog template, otherwise the structure is a standard dialog template.</para></param>
		/// <returns>Returns zero.</returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760815")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
		public delegate int PropSheetProc(IntPtr hwndDlg, PropSheetCallbackMessage uMsg, IntPtr lParam);

		[PInvokeData("Commctrl.h", MSDNShortId = "bb760815")]
		public enum PropSheetCallbackMessage
		{
			/// <summary>Version 6.0 and later.Indicates the user pressed a button in the property sheet dialog box.To enable this, specify PSH_USECALLBACK in PROPSHEETHEADER.dwFlags and specify the name of this callback function in PROPSHEETHEADER.pfnCallback. The lParam value is one of the following. Note that only PSBTN_CANCEL is valid when you are using the Aero wizard style(PSH_AEROWIZARD).
			/// <list type="table">
			/// <listheader><term>Button pressed</term><term>lParam value</term></listheader>
			/// <item><term>OK</term><term>PSBTN_OK</term></item>
			/// <item><term>Cancel</term><term>PSBTN_CANCEL</term></item>
			/// <item><term>Apply</term><term>PSBTN_APPLYNOW</term></item>
			/// <item><term>Close</term><term>PSBTN_FINISH</term></item>
			/// </list>
			/// </summary>
			PSCB_BUTTONPRESSED = 3,
			/// <summary>
			/// Indicates that the property sheet is being initialized. The lParam value is zero for this message.
			/// </summary>
			PSCB_INITIALIZED = 1,
			/// <summary>
			/// Indicates that the property sheet is about to be created. The hwndDlg parameter is NULL, and the lParam parameter is the address of a dialog template in memory. This template is in the form of a DLGTEMPLATE or DLGTEMPLATEEX structure followed by one or more DLGITEMTEMPLATE structures. This message is not applicable if you are using the Aero wizard style (PSH_AEROWIZARD).
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
			/// <summary>Creates the page from the dialog box template in memory pointed to by the pResource member. The PropertySheet function assumes that the template that is in memory is not write-protected. A read-only template will cause an exception in some versions of Windows.</summary>
			PSP_DLGINDIRECT = 0x1,
			/// <summary>Enables the property sheet Help button when the page is active. This flag is not supported when using the Aero-style wizard (PSH_AEROWIZARD).</summary>
			PSP_HASHELP = 0x20,
			/// <summary>Version 5.80 and later. Causes the wizard property sheet to hide the header area when the page is selected. If a watermark has been provided, it will be painted on the left side of the page. This flag should be set for welcome and completion pages, and omitted for interior pages. This flag is not supported when using the Aero-style wizard (PSH_AEROWIZARD).</summary>
			PSP_HIDEHEADER = 0x800,
			/// <summary>Version 4.71 or later. Causes the page to be created when the property sheet is created. If this flag is not specified, the page will not be created until it is selected the first time. This flag is not supported when using the Aero-style wizard (PSH_AEROWIZARD).</summary>
			PSP_PREMATURE = 0x400,
			/// <summary>Reverses the direction in which pszTitle is displayed. Normal windows display all text, including pszTitle, left-to-right (LTR). For languages such as Hebrew or Arabic that read right-to-left (RTL), a window can be mirrored and all text will be displayed RTL. If PSP_RTLREADING is set, pszTitle will instead read RTL in a normal parent window, and LTR in a mirrored parent window.</summary>
			PSP_RTLREADING = 0x10,
			/// <summary>Calls the function specified by the pfnCallback member when creating or destroying the property sheet page defined by this structure.</summary>
			PSP_USECALLBACK = 0x80,
			/// <summary>Version 6.0 and later. Use an activation context. To use an activation context, you must set this flag and assign the activation context handle to hActCtx. See the Remarks.</summary>
			PSP_USEFUSIONCONTEXT = 0x4000,
			/// <summary>Version 5.80 or later. Displays the string pointed to by the pszHeaderSubTitle member as the subtitle of the header area of a Wizard97 page. To use this flag, you must also set the PSH_WIZARD97 flag in the dwFlags member of the associated PROPSHEETHEADER structure. The PSP_USEHEADERSUBTITLE flag is ignored if PSP_HIDEHEADER is set. In Aero-style wizards, the title appears near the top of the client area.</summary>
			PSP_USEHEADERSUBTITLE = 0x2000,
			/// <summary>Version 5.80 or later. Displays the string pointed to by the pszHeaderTitle member as the title in the header of a Wizard97 interior page. You must also set the PSH_WIZARD97 flag in the dwFlags member of the associated PROPSHEETHEADER structure. The PSP_USEHEADERTITLE flag is ignored if PSP_HIDEHEADER is set. This flag is not supported when using the Aero-style wizard (PSH_AEROWIZARD).</summary>
			PSP_USEHEADERTITLE = 0x1000,
			/// <summary>Uses hIcon as the small icon on the tab for the page. This flag is not supported when using the Aero-style wizard (PSH_AEROWIZARD).</summary>
			PSP_USEHICON = 0x2,
			/// <summary>Uses pszIcon as the name of the icon resource to load and use as the small icon on the tab for the page. This flag is not supported when using the Aero-style wizard (PSH_AEROWIZARD).</summary>
			PSP_USEICONID = 0x4,
			/// <summary>Maintains the reference count specified by the pcRefParent member for the lifetime of the property sheet page created from this structure.</summary>
			PSP_USEREFPARENT = 0x40,
			/// <summary>Uses the pszTitle member as the title of the property sheet dialog box instead of the title stored in the dialog box template. This flag is not supported when using the Aero-style wizard (PSH_AEROWIZARD).</summary>
			PSP_USETITLE = 0x8,
		}

		/// <summary>Flags used by the <see cref="PROPSHEETHEADER.dwFlags"/> field.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb774546")]
		[Flags]
		public enum PropSheetHeaderFlags : uint
		{
			/// <summary>Uses the default meaning for all structure members, and creates a normal property sheet. This flag has a value of zero and is not combined with other flags.</summary>
			PSH_DEFAULT = 0x00000000,
			/// <summary>Version 6.00 and Windows Vista.. Creates a wizard property sheet that uses the newer Aero style. The PSH_WIZARD flag must also be set. The single-threaded apartment (STA) model must be used.</summary>
			PSH_AEROWIZARD = 0x00004000,
			/// <summary>Permits property sheet pages to display a Help button. You must also set the PSP_HASHELP flag in the page's PROPSHEETPAGE structure when the page is created. If any of the initial property sheet pages enable a Help button, PSH_HASHELP will be set automatically. If none of the initial pages enable a Help button, you must explicitly set PSH_HASHELP if you want to have Help buttons on any pages that might be added later. This flag is not supported in conjunction with PSH_AEROWIZARD.</summary>
			PSH_HASHELP = 0x00000200,
			/// <summary>Version 5.80 and later. Indicates that a header bitmap will be used with a Wizard97 wizard. You must also set the PSH_WIZARD97 flag. The header bitmap is obtained from the pszbmHeader member, unless the PSH_USEHBMHEADER flag is also set. In that case, the header bitmap is obtained from the hbmHeader member. This flag is not supported in conjunction with PSH_AEROWIZARD.</summary>
			PSH_HEADER = 0x00080000,
			/// <summary>Version 6.00 and Windows Vista..The pszbmHeader member specifies a bitmap that is displayed in the header area. Must be used in combination with PSH_AEROWIZARD.</summary>
			PSH_HEADERBITMAP = 0x08000000,
			/// <summary>Causes the PropertySheet function to create the property sheet as a modeless dialog box instead of as a modal dialog box. When this flag is set, PropertySheet returns immediately after the dialog box is created, and the return value from PropertySheet is the window handle to the property sheet dialog box. This flag is not supported in conjunction with PSH_AEROWIZARD.</summary>
			PSH_MODELESS = 0x00000400,
			/// <summary>Removes the Apply button. This flag is not supported in conjunction with PSH_AEROWIZARD.</summary>
			PSH_NOAPPLYNOW = 0x00000080,
			/// <summary>Version 5.80 and later. Removes the context-sensitive Help button ("?"), which is usually present on the caption bar of property sheets. This flag is not valid for wizards. See About Property Sheets for a discussion of how to remove the caption bar Help button for earlier versions of the common controls. This flag is not supported in conjunction with PSH_AEROWIZARD.</summary>
			PSH_NOCONTEXTHELP = 0x02000000,
			/// <summary>Version 6.00 and Windows Vista.. Specifies that no margin is inserted between the page and the frame. Must be used in combination with PSH_AEROWIZARD.</summary>
			PSH_NOMARGIN = 0x10000000,
			/// <summary>Uses the ppsp member and ignores the phpage member when creating the pages for the property sheet.</summary>
			PSH_PROPSHEETPAGE = 0x00000008,
			/// <summary>Displays a title in the title bar of the property sheet. The title takes the appropriate form for the Windows version. In more recent versions of Windows, the title is the string specified by the pszCaption followed by the string "Properties". In older versions of Windows, the title is the string "Properties for", followed by the string specified by the pszCaption member. This flag is not supported for wizards.</summary>
			PSH_PROPTITLE = 0x00000001,
			/// <summary>Allows the wizard to be resized by the user. Maximize and minimize buttons appear in the wizard's frame and the frame is sizable. To use this flag, you must also set PSH_AEROWIZARD.</summary>
			PSH_RESIZABLE = 0x04000000,
			/// <summary>Displays the title of the property sheet (pszCaption) using right-to-left (RTL) reading order for Hebrew or Arabic languages. If this flag is not specified, the title is displayed in left-to-right (LTR) reading order.</summary>
			PSH_RTLREADING = 0x00000800,
			/// <summary>Stretches the watermark in Internet Explorer 4.0-compatible Wizard97-style wizards. This flag is not supported in conjunction with PSH_AEROWIZARD. <note>This style flag is only included to provide backward compatibility for certain applications. Its use is not recommended, and it is only supported by common controls versions 4.0 and 4.01. With common controls version 5.80 and later, this flag is ignored.</note></summary>
			PSH_STRETCHWATERMARK = 0x00040000,
			/// <summary>Calls the function specified by the pfnCallback member when initializing the property sheet defined by this structure.</summary>
			PSH_USECALLBACK = 0x00000100,
			/// <summary>Version 5.80 or later. Obtains the header bitmap from the hbmHeader member instead of the pszbmHeader member. You must also set either the PSH_AEROWIZARD flag or the PSH_WIZARD97 flag together with the PSH_HEADER flag.</summary>
			PSH_USEHBMHEADER = 0x00100000,
			/// <summary>Version 5.80 or later. Obtains the watermark bitmap from the hbmWatermark member instead of the pszbmWatermark member. You must also set PSH_WIZARD97 and PSH_WATERMARK. This flag is not supported in conjunction with PSH_AEROWIZARD.</summary>
			PSH_USEHBMWATERMARK = 0x00010000,
			/// <summary>Uses hIcon as the small icon in the title bar of the property sheet dialog box.</summary>
			PSH_USEHICON = 0x00000002,
			/// <summary>Version 5.80 or later. Uses the HPALETTE structure pointed to by the hplWatermark member instead of the default palette to draw the watermark bitmap and/or header bitmap for a Wizard97 wizard. You must also set PSH_WIZARD97, and PSH_WATERMARK or PSH_HEADER. This flag is not supported in conjunction with PSH_AEROWIZARD.</summary>
			PSH_USEHPLWATERMARK = 0x00020000,
			/// <summary>Uses pszIcon as the name of the icon resource to load and use as the small icon in the title bar of the property sheet dialog box.</summary>
			PSH_USEICONID = 0x00000004,
			/// <summary>Version 5.80 or later. Specifies that the language for the property sheet will be taken from the first page's resource. That page must be specified by resource identifier.</summary>
			PSH_USEPAGELANG = 0x00200000,
			/// <summary>Uses the pStartPage member instead of the nStartPage member when displaying the initial page of the property sheet.</summary>
			PSH_USEPSTARTPAGE = 0x00000040,
			/// <summary>Version 5.80 or later. Specifies that a watermark bitmap will be used with a Wizard97 wizard on pages that have the PSP_HIDEHEADER style. You must also set the PSH_WIZARD97 flag. The watermark bitmap is obtained from the pszbmWatermark member, unless PSH_USEHBMWATERMARK is set. In that case, the header bitmap is obtained from the hbmWatermark member. This flag is not supported in conjunction with PSH_AEROWIZARD.</summary>
			PSH_WATERMARK = 0x00008000,
			/// <summary>Creates a wizard property sheet. When using PSH_AEROWIZARD, you must also set this flag.</summary>
			PSH_WIZARD = 0x00000020,
			/// <summary>Version 5.80 or later. Creates a Wizard97-style property sheet, which supports bitmaps in the header of interior pages and on the left side of exterior pages. This flag is not supported in conjunction with PSH_AEROWIZARD.</summary>
			PSH_WIZARD97 = 0x00002000,
			/// <summary>Adds a context-sensitive Help button ("?"), which is usually absent from the caption bar of a wizard. This flag is not valid for regular property sheets. This flag is not supported in conjunction with PSH_AEROWIZARD.</summary>
			PSH_WIZARDCONTEXTHELP = 0x00001000,
			/// <summary>Always displays the Finish button on the wizard. You must also set either PSH_WIZARD, PSH_WIZARD97, or PSH_AEROWIZARD.</summary>
			PSH_WIZARDHASFINISH = 0x00000010,
			/// <summary>Version 5.80 or later. Uses the Wizard-lite style. This style is similar in appearance to PSH_WIZARD97, but it is implemented much like PSH_WIZARD. There are few restrictions on how the pages are formatted. For instance, there are no enforced borders, and the PSH_WIZARD_LITE style does not paint the watermark and header bitmaps for you the way Wizard97 does. This flag is not supported in conjunction with PSH_AEROWIZARD.</summary>
			PSH_WIZARD_LITE = 0x00400000,
		}

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

		/// <summary>Creates a new page for a property sheet.</summary>
		/// <param name="lppsp">
		/// <para>Type: <c>LPCPROPSHEETPAGE</c></para>
		/// <para>Pointer to a <c>PROPSHEETPAGE</c> structure that defines a page to be included in a property sheet.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HPROPSHEETPAGE</c></para>
		/// <para>Returns the handle to the new property page if successful, or <c>NULL</c> otherwise.</para>
		/// </returns>
		// HPROPSHEETPAGE CreatePropertySheetPage( LPCPROPSHEETPAGE lppsp);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb760807(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Prsht.h", MSDNShortId = "bb760807")]
		public static extern SafePropertySheetPagehandle CreatePropertySheetPage(PROPSHEETPAGE lppsp);

		/// <summary>Destroys a property sheet page. An application must call this function for pages that have not been passed to the <c>PropertySheet</c> function.</summary><param name="hPSPage"><para>Type: <c>HPROPSHEETPAGE</c></para><para>Handle to the property sheet page to delete.</para></param><returns><para>Type: <c><c>BOOL</c></c></para><para>Returns nonzero if successful, or zero otherwise.</para></returns>
		// BOOL DestroyPropertySheetPage( HPROPSHEETPAGE hPSPage);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb760809(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Prsht.h", MSDNShortId = "bb760809")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DestroyPropertySheetPage(IntPtr hPSPage);

		/// <summary>Creates a property sheet and adds the pages defined in the specified property sheet header structure.</summary><param name="lppsph"><para>Type: <c>LPCPROPSHEETHEADER</c></para><para>Pointer to a <c>PROPSHEETHEADER</c> structure that defines the frame and pages of a property sheet.</para></param><returns><para>Type: <c><c>INT_PTR</c></c></para><para>For modal property sheets, the return value is as follows:</para><para><list type="table"><listheader><term>&amp;gt;=1</term><term>Changes were saved by the user.</term></listheader><item><term>0</term><term>No changes were saved by the user.</term></item><item><term>-1</term><term>An error occurred.</term></item></list></para><para>For modeless property sheets, the return value is the property sheet&#39;s window handle.</para><para>The following return values have a special meaning.</para><para><list type="table"><listheader><term>Return code</term><term>Description</term></listheader><item><term>ID_PSREBOOTSYSTEM</term><term>A page sent the PSM_REBOOTSYSTEM message to the property sheet. The computer must be restarted for the user&amp;#39;s changes to take effect.</term></item><item><term>ID_PSRESTARTWINDOWS</term><term>A page sent the PSM_RESTARTWINDOWS message to the property sheet. Windows must be restarted for the user&amp;#39;s changes to take effect.</term></item></list></para></returns>
		// INT_PTR PropertySheet( LPCPROPSHEETHEADER lppsph);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb760811(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Prsht.h", MSDNShortId = "bb760811")]
		[return: MarshalAs(UnmanagedType.SysInt)]
		public static extern int PropertySheet(ref PROPSHEETHEADER psh);

		// TODO: Convert resource id fields to managed properties.
		/// <summary>Defines the frame and pages of a property sheet.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb774546")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROPSHEETHEADER
		{
			/// <summary>
			/// Size, in bytes, of this structure. The property sheet manager uses this member to determine which version of the PROPSHEETHEADER structure you
			/// are using. For more information, see the Remarks.
			/// </summary>
			public uint dwSize;
			/// <summary>Flags that indicate which options to use when creating the property sheet page.</summary>
			public PropSheetHeaderFlags dwFlags;
			/// <summary>Handle to the property sheet's owner window.</summary>
			public IntPtr hwndParent;
			/// <summary>
			/// Handle to the instance from which to load the icon or title string resource. If the pszIcon or pszCaption member identifies a resource to load,
			/// this member must be specified.
			/// </summary>
			public IntPtr hInstance;
			/// <summary>
			/// Handle to the icon to use as the small icon in the title bar of the property sheet dialog box. If the dwFlags member does not include
			/// PSH_USEHICON, this member is ignored. This member is declared as a union with pszIcon.
			/// <para><c>OR</c></para>
			/// <para>
			/// String icon resource to use as the small icon in the title bar of the property sheet dialog box. This member can specify either the identifier of
			/// the icon resource or the address of the string that specifies the name of the icon resource. If the dwFlags member does not include
			/// PSH_USEICONID, this member is ignored. This member is declared as a union with hIcon.
			/// </para>
			/// </summary>
			public IntPtr pIcon;
			/// <summary>
			/// Title of the property sheet dialog box. This member can specify either the identifier of a string resource or the address of a string that
			/// specifies the title. If the dwFlags member includes PSH_PROPTITLE, the string "Properties for" is inserted at the beginning of the title. This
			/// field is ignored for Wizard97 wizards. For Aero wizards, the string alone is used for the caption, regardless of whether the PSH_PROPTITLE flag
			/// is set.
			/// </summary>
			public IntPtr pszCaption;
			/// <summary>Number of elements in the phpage array.</summary>
			public uint nPages;
			/// <summary>
			/// Zero-based index of the initial page that appears when the property sheet dialog box is created. This member is declared as a union with pStartPage.
			/// <para><c>OR</c></para>
			/// <para>
			/// Name of the initial page that appears when the property sheet dialog box is created. This member can specify either the identifier of a string
			/// resource or the address of a string that specifies the name. This member is declared as a union with nStartPage.
			/// </para>
			/// </summary>
			public IntPtr pStartPage;
			/// <summary>
			/// Pointer to an array of PROPSHEETPAGE structures that define the pages in the property sheet. If the dwFlags member does not include
			/// PSH_PROPSHEETPAGE, this member is ignored. Note that the PROPSHEETPAGE structure is variable in size. Applications that parse the array pointed
			/// to by ppsp must take the size of each page into account. This member is declared as a union with phpage.
			/// <para><c>OR</c></para>
			/// <para>
			/// Pointer to an array of handles to the property sheet pages. Each handle must have been created by a previous call to the CreatePropertySheetPage
			/// function. If the dwFlags member includes PSH_PROPSHEETPAGE, phpage is ignored and should be set to NULL. When the PropertySheet function returns,
			/// any HPROPSHEETPAGE handles in the phpage array will have been destroyed. This member is declared as a union with ppsp.
			/// </para>
			/// </summary>
			public IntPtr phpage;
			/// <summary>
			/// Pointer to an application-defined callback function that is called when the property sheet is initialized. For more information about the
			/// callback function, see the description of the PropSheetProc function. If the dwFlags member does not include PSH_USECALLBACK, this member is ignored.
			/// </summary>
			public PropSheetProc pfnCallback;
			/// <summary>
			/// Version 5.80 or later. Handle to the watermark bitmap. If the dwFlags member does not include PSH_USEHBMWATERMARK, this member is ignored.
			/// <para><c>OR</c></para>
			/// <para>
			/// Version 5.80 or later. Bitmap resource to use as the watermark. This member can specify either the identifier of the bitmap resource or the
			/// address of the string that specifies the name of the bitmap resource. If the dwFlags member includes PSH_USEHBMWATERMARK, this member is ignored.
			/// </para>
			/// </summary>
			public IntPtr hbmWatermark;
			/// <summary>
			/// Version 5.80 or later. HPALETTE structure used for drawing the watermark bitmap and/or header bitmap. If the dwFlags member does not include
			/// PSH_USEHPLWATERMARK, this member is ignored.
			/// </summary>
			public IntPtr hplWatermark;
			/// <summary>
			/// Version 5.80 or later. Handle to the header bitmap. If the dwFlags member does not include PSH_USEHBMHEADER, this member is ignored.
			/// <para><c>OR</c></para>
			/// <para>
			/// Version 5.80 or later. Bitmap resource to use as the header. This member can specify either the identifier of the bitmap resource or the address
			/// of the string that specifies the name of the bitmap resource. If the dwFlags member includes PSH_USEHBMHEADER, this member is ignored.
			/// </para>
			/// </summary>
			public IntPtr hbmHeader;
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
			/// Handle to the instance from which to load an icon or string resource. If the pszIcon, pszTitle, pszHeaderTitle, or pszHeaderSubTitle member
			/// identifies a resource to load, hInstance must be specified.
			/// </summary>
			public IntPtr hInstance;
			/// <summary>
			/// Dialog box template to use to create the page. This member can specify either the resource identifier of the template or the address of a string
			/// that specifies the name of the template. If the PSP_DLGINDIRECT flag in the dwFlags member is set, pszTemplate is ignored. This member is
			/// declared as a union with pResource.
			/// </summary>
			private IntPtr _pszTemplate;
			/// <summary>
			/// Handle to the icon to use as the icon in the tab of the page. If the dwFlags member does not include PSP_USEHICON, this member is ignored. This
			/// member is declared as a union with pszIcon.
			/// <para><c>OR</c></para>
			/// <para>
			/// Icon resource to use as the icon in the tab of the page. This member can specify either the identifier of the icon resource or the address of the
			/// string that specifies the name of the icon resource. To use this member, you must set the PSP_USEICONID flag in the dwFlags member. This member
			/// is declared as a union with hIcon.
			/// </para>
			/// </summary>
			private IntPtr _hIcon;
			/// <summary>
			/// Title of the property sheet dialog box. This title overrides the title specified in the dialog box template. This member can specify either the
			/// identifier of a string resource or the address of a string that specifies the title. To use this member, you must set the PSP_USETITLE flag in
			/// the dwFlags member.
			/// </summary>
			private IntPtr _pszTitle;
			/// <summary>
			/// Pointer to the dialog box procedure for the page. Because the pages are created as modeless dialog boxes, the dialog box procedure must not call
			/// the EndDialog function.
			/// </summary>
			public DialogProc pfnDlgProc;
			/// <summary>
			/// When the page is created, a copy of the page's PROPSHEETPAGE structure is passed to the dialog box procedure with a WM_INITDIALOG message. The
			/// lParam member is provided to allow you to pass application-specific information to the dialog box procedure. It has no effect on the page itself.
			/// For more information, see Property Sheet Creation.
			/// </summary>
			public IntPtr lParam;
			/// <summary>
			/// Pointer to an application-defined callback function that is called when the page is created and when it is about to be destroyed. For more
			/// information about the callback function, see PropSheetPageProc. To use this member, you must set the PSP_USECALLBACK flag in the dwFlags member.
			/// </summary>
			private PropSheetPageProc _pfnCallback;
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
			/// Version 6.0 or later. An activation context handle. Set this member to the handle that is returned when you create the activation context with
			/// CreateActCtx. The system will activate this context before creating the dialog box. You do not need to use this member if you use a global manifest.
			/// </summary>
			public IntPtr hActCtx;

			/// <summary>Initializes a new instance of the <see cref="PROPSHEETPAGE"/> class and sets the value of <see cref="dwSize"/>.</summary>
			public PROPSHEETPAGE()
			{
				dwSize = (uint)Marshal.SizeOf(this);
			}

			/// <summary>
			/// Dialog box template to use to create the page. This member can specify either the resource identifier of the template or the address of a string
			/// that specifies the name of the template. If the PSP_DLGINDIRECT flag in the dwFlags member is set, pszTemplate is ignored.
			/// </summary>
			public SafeResourceId pszTemplate
			{
				get => dwFlags.IsFlagSet(PropSheetFlags.PSP_DLGINDIRECT) ? SafeResourceId.Null : new SafeResourceId(_pszTemplate);
				set
				{
					if (!dwFlags.IsFlagSet(PropSheetFlags.PSP_DLGINDIRECT)) FreeResource(ref _pszTemplate);
					dwFlags = dwFlags.SetFlags(PropSheetFlags.PSP_DLGINDIRECT, false);
					_pszTemplate = value.GetClonedHandle();
				}
			}

			/// <summary>
			/// A pointer to a dialog box template in memory. The PropertySheet function assumes that the template is in writeable memory; a
			/// read-only template will cause an exception on some versions of Windows. If dwFlags does not include the PSP_DLGINDIRECT
			/// value, this member is ignored.
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
			/// A handle to the icon to use as the small icon in the tab for the page. If dwFlags does not include the PSP_USEHICON value, this member is ignored.
			/// </summary>
			public IntPtr hIcon
			{
				get => dwFlags.IsFlagSet(PropSheetFlags.PSP_USEHICON) ? _hIcon : IntPtr.Zero;
				set
				{
					if (dwFlags.IsFlagSet(PropSheetFlags.PSP_USEICONID)) FreeResource(ref _pszTemplate);
					_hIcon = value;
					dwFlags = dwFlags.SetFlags(PropSheetFlags.PSP_USEICONID, false) | PropSheetFlags.PSP_USEHICON;
				}
			}

			/// <summary>
			/// Icon resource to use as the small icon in the tab for the page. This member can specify either the identifier of the icon
			/// resource or the pointer to the string that specifies the name of the icon resource. If dwFlags does not include the
			/// PSP_USEICONID value, this member is ignored.
			/// </summary>
			public SafeResourceId pszIcon
			{
				get => dwFlags.IsFlagSet(PropSheetFlags.PSP_USEICONID) ? new SafeResourceId(_hIcon) : SafeResourceId.Null;
				set
				{
					if (dwFlags.IsFlagSet(PropSheetFlags.PSP_USEICONID)) FreeResource(ref _hIcon);
					dwFlags = dwFlags.SetFlags(PropSheetFlags.PSP_USEHICON, false) | PropSheetFlags.PSP_USEICONID;
					_hIcon = value.GetClonedHandle();
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
					_pszTitle = value.GetClonedHandle();
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
					_pszHeaderTitle = value.GetClonedHandle();
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
					_pszHeaderSubTitle = value.GetClonedHandle();
				}
			}

			/// <summary>
			/// Pointer to an application-defined callback function that is called when the page is created and when it is about to be destroyed. For more
			/// information about the callback function, see PropSheetPageProc. To use this member, you must set the PSP_USECALLBACK flag in the dwFlags member.
			/// </summary>
			public PropSheetPageProc pfnCallback
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
			}

			private static void FreeResource(ref IntPtr ptr)
			{
				if (IS_INTRESOURCE(ptr) || ptr == IntPtr.Zero) return;
				StringHelper.FreeString(ptr);
				ptr = IntPtr.Zero;
			}
		}

		/// <summary>Safe handle for property sheet pages.</summary>
		/// <seealso cref="GenericSafeHandle"/>
		public class SafePropertySheetPagehandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafePropertySheetPagehandle"/> class.</summary>
			public SafePropertySheetPagehandle() : this(IntPtr.Zero) { }
			/// <summary>Initializes a new instance of the <see cref="SafePropertySheetPagehandle"/> class.</summary>
			/// <param name="handle">The handle.</param>
			/// <param name="owns">if set to <c>true</c> calls DestroyPropertySheetPage on disposal.</param>
			public SafePropertySheetPagehandle(IntPtr handle, bool owns = true) : base(handle, DestroyPropertySheetPage, owns) { }
		}
	}
}