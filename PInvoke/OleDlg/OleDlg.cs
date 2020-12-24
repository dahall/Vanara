using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke
{
	/// <summary>Functions, interfaces and structures from Windows OleDlg.dll.</summary>
	public static partial class OleDlg
	{
		//[ComImport, Guid("EEDD23E0-8410-11CE-A1C3-08002B2B8D8F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]

		private const string Lib_OleDlg = "oledlg.dll";

		/// <summary>A hook function that processes messages intended for the dialog box.</summary>
		/// <param name="hwnd">The windows handle of the dialog.</param>
		/// <param name="msg">The message.</param>
		/// <param name="wParam"/>
		/// <param name="lParam"/>
		/// <returns>
		/// The hook function must return zero to pass a message that it didn't process back to the dialog box procedure in the library. The
		/// hook function must return a nonzero value to prevent the library's dialog box procedure from processing a message it has already processed.
		/// </returns>
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate uint LPFNOLEUIHOOK(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam);

		/// <summary>Initialization and creation flags for <see cref="OLEUIBUSY"/>.</summary>
		[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUIBUSYA")]
		[Flags]
		public enum BZ
		{
			/// <summary>This flag disables the Cancel button.</summary>
			BZ_DISABLECANCELBUTTON = 0x00000001,

			/// <summary>Input only. This flag disables the Switch To... button.</summary>
			BZ_DISABLESWITCHTOBUTTON = 0x00000002,

			/// <summary>Input only. This flag disables the Retry button.</summary>
			BZ_DISABLERETRYBUTTON = 0x00000004,

			/// <summary>
			/// Input only. This flag generates a Not Responding dialog box instead of a Busy dialog box. The text is slightly different,
			/// and the Cancel button is disabled.
			/// </summary>
			BZ_NOTRESPONDINGDIALOG = 0x00000008,
		}

		/// <summary>Initialization and creation flags for <see cref="OLEUICHANGEICON"/>.</summary>
		[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUICHANGEICONA")]
		[Flags]
		public enum CIF
		{
			/// <summary>Dialog box will display a Help button.</summary>
			CIF_SHOWHELP = 0x00000001,

			/// <summary>On input, selects the Current radio button on initialization. On exit, specifies that the user selected Current.</summary>
			CIF_SELECTCURRENT = 0x00000002,

			/// <summary>On input, selects the Default radio button on initialization. On exit, specifies that the user selected Default.</summary>
			CIF_SELECTDEFAULT = 0x00000004,

			/// <summary>
			/// On input, selects the From File radio button on initialization. On exit, specifies that the user selected From File.
			/// </summary>
			CIF_SELECTFROMFILE = 0x00000008,

			/// <summary>
			/// Input only. Extracts the icon from the executable specified in the szIconExe member, instead of retrieving it from the
			/// class. This is useful for OLE embedding or linking to non-OLE files.
			/// </summary>
			CIF_USEICONEXE = 0x00000010,
		}

		/// <summary>Initialization and creation flags for <see cref="OLEUICHANGESOURCE"/>.</summary>
		[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUICHANGESOURCEA")]
		[Flags]
		public enum CSF
		{
			/// <summary>Enables or shows the Help button.</summary>
			CSF_SHOWHELP = 0x00000001,

			/// <summary>Indicates that the link was validated.</summary>
			CSF_VALIDSOURCE = 0x00000002,

			/// <summary>
			/// Disables automatic validation of the link source when the user presses OK. If you specify this flag, you should validate the
			/// source when the dialog box returns OK.
			/// </summary>
			CSF_ONLYGETSOURCE = 0x00000004,

			/// <summary/>
			CSF_EXPLORER = 0x00000008,
		}

		/// <summary>
		/// Indicates the user options that are available to the user when pasting this format, and within which group or list of choices (
		/// <c>Paste</c>, <c>Paste Link</c>, etc.).
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/ne-oledlg-oleuipasteflag typedef enum tagOLEUIPASTEFLAG {
		// OLEUIPASTE_ENABLEICON, OLEUIPASTE_PASTEONLY, OLEUIPASTE_PASTE, OLEUIPASTE_LINKANYTYPE, OLEUIPASTE_LINKTYPE1,
		// OLEUIPASTE_LINKTYPE2, OLEUIPASTE_LINKTYPE3, OLEUIPASTE_LINKTYPE4, OLEUIPASTE_LINKTYPE5, OLEUIPASTE_LINKTYPE6,
		// OLEUIPASTE_LINKTYPE7, OLEUIPASTE_LINKTYPE8 } OLEUIPASTEFLAG;
		[PInvokeData("oledlg.h", MSDNShortId = "NE:oledlg.tagOLEUIPASTEFLAG")]
		[Flags]
		public enum OLEUIPASTEFLAG
		{
			/// <summary>
			/// If the container does not specify this flag for the entry in the OLEUIPASTEENTRY array passed as input to OleUIPasteSpecial,
			/// the DisplayAsIcon button will be unchecked and disabled when the user selects the format that corresponds to the entry.
			/// </summary>
			OLEUIPASTE_ENABLEICON = 2048,

			/// <summary>The entry in the OLEUIPASTEENTRY array is valid for pasting only.</summary>
			OLEUIPASTE_PASTEONLY = 0,

			/// <summary>
			/// The entry in the OLEUIPASTEENTRY array is valid for pasting. It may also be valid for linking if any of the following
			/// linking flags are specified. If it is valid for linking, then the following flags indicate which link types are acceptable
			/// by OR'ing together the appropriate OLEUIPASTE_LINKTYPEn values. These values correspond as follows to the array of link
			/// types passed to OleUIPasteSpecial in the arrLinkTypes member of the OLEUIPASTESPECIAL structure:The arrLinkTypes array is an
			/// array of registered clipboard formats for linking. A maximum of 8 link types is allowed.
			/// </summary>
			OLEUIPASTE_PASTE = 512,

			/// <summary>Any link type.</summary>
			OLEUIPASTE_LINKANYTYPE = 1024,

			/// <summary>Link type 1.</summary>
			OLEUIPASTE_LINKTYPE1 = 1,

			/// <summary>Link type 2.</summary>
			OLEUIPASTE_LINKTYPE2 = 2,

			/// <summary>Link type 3.</summary>
			OLEUIPASTE_LINKTYPE3 = 4,

			/// <summary>Link type 4.</summary>
			OLEUIPASTE_LINKTYPE4 = 8,

			/// <summary>Link type 5.</summary>
			OLEUIPASTE_LINKTYPE5 = 16,

			/// <summary>Link type 6.</summary>
			OLEUIPASTE_LINKTYPE6 = 32,

			/// <summary>Link type 7.</summary>
			OLEUIPASTE_LINKTYPE7 = 64,

			/// <summary>Link type 8.</summary>
			OLEUIPASTE_LINKTYPE8 = 128,
		}

		/// <summary>Invokes the standard <c>Busy</c> dialog box, allowing the user to manage concurrency.</summary>
		/// <param name="Arg1">Pointer to an OLEUIBUSY structure that contains information used to initialize the dialog box.</param>
		/// <returns>
		/// <para>This function returns the following values:</para>
		/// <para>Standard Success/Error Definitions</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLEUI_FALSE</term>
		/// <term>Unknown failure (unused).</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_SUCCESS</term>
		/// <term>No error, same as OLEUI_OK.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_OK</term>
		/// <term>The user pressed the OK button.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_CANCEL</term>
		/// <term>The user has pressed the Cancel button and that the caller should cancel the operation.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_BZ_SWITCHTOSELECTED</term>
		/// <term>
		/// The user has pressed Switch To and OleUIBusy was unable to determine how to switch to the blocking application. In this case,
		/// the caller should either take measures to attempt to resolve the conflict itself, if possible, or retry the operation. OleUIBusy
		/// will only return OLEUI_BZ_SWITCHTOSELECTED if the user has pressed the Switch To button, hTask is NULL and the BZ_NOTRESPONDING
		/// flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OLEUI_BZ_SWITCHTOSELECTED</term>
		/// <term>
		/// The user has pressed Switch To and OleUIBusy was unable to determine how to switch to the blocking application. In this case,
		/// the caller should either take measures to attempt to resolve the conflict itself, if possible, or retry the operation. OleUIBusy
		/// will only return OLEUI_BZ_SWITCHTOSELECTED if the user has pressed the Switch To button, hTask is NULL and the BZ_NOTRESPONDING
		/// flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OLEUI_BZ_SWITCHTOSELECTED</term>
		/// <term>
		/// The user has pressed Switch To and OleUIBusy was unable to determine how to switch to the blocking application. In this case,
		/// the caller should either take measures to attempt to resolve the conflict itself, if possible, or retry the operation. OleUIBusy
		/// will only return OLEUI_BZ_SWITCHTOSELECTED if the user has pressed the Switch To button, hTask is NULL and the BZ_NOTRESPONDING
		/// flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OLEUI_BZ_RETRYSELECTED</term>
		/// <term>
		/// The user has either pressed the Retry button or attempted to resolve the conflict (probably by switching to the blocking
		/// application). In this case, the caller should retry the operation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OLEUI_BZ_CALLUNBLOCKED</term>
		/// <term>The dialog box has been informed that the operation is no longer blocked.</term>
		/// </item>
		/// </list>
		/// <para>Standard Field Validation Errors</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLEUI_ERR_STANDARDMIN</term>
		/// <term>
		/// Errors common to all dialog boxes lie in the range OLEUI_ERR_STANDARDMIN to OLEUI_ERR_STANDARDMAX. This value allows the
		/// application to test for standard messages in order to display error messages to the user.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_STRUCTURENULL</term>
		/// <term>The pointer to an OLEUIXXX structure passed into the function was NULL.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_STRUCTUREINVALID</term>
		/// <term>Insufficient permissions for read or write access to an OLEUIXXX structure.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_CBSTRUCTINCORRECT</term>
		/// <term>The cbstruct value is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_HWNDOWNERINVALID</term>
		/// <term>The hWndOwner value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LPSZCAPTIONINVALID</term>
		/// <term>The lpszCaption value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LPFNHOOKINVALID</term>
		/// <term>The lpfnHook value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_HINSTANCEINVALID</term>
		/// <term>The hInstance value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LPSZTEMPLATEINVALID</term>
		/// <term>The lpszTemplate value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_HRESOURCEINVALID</term>
		/// <term>The hResource value is invalid.</term>
		/// </item>
		/// </list>
		/// <para>Initialization Errors</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLEUI_ERR_FINDTEMPLATEFAILURE</term>
		/// <term>Unable to find the dialog box template.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LOADTEMPLATEFAILURE</term>
		/// <term>Unable to load the dialog box template.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_DIALOGFAILURE</term>
		/// <term>Dialog box initialization failed.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LOCALMEMALLOC</term>
		/// <term>A call to LocalAlloc or the standard IMalloc allocator failed.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_GLOBALMEMALLOC</term>
		/// <term>A call to GlobalAlloc or the standard IMalloc allocator failed.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LOADSTRING</term>
		/// <term>Unable to call LoadString for the localized resources from the library.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_OLEMEMALLOC</term>
		/// <term>A call to the standard IMalloc allocator failed.</term>
		/// </item>
		/// </list>
		/// <para>Function Specific Errors</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLEUI_ERR_STANDARDMAX</term>
		/// <term>
		/// Errors common to all dialog boxes lie in the range OLEUI_ERR_STANDARDMIN to OLEUI_ERR_STANDARDMAX. This value allows the
		/// application to test for standard messages in order to display error messages to the user.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OLEUI_BZERR_HTASKINVALID</term>
		/// <term>The hTask specified in the hTask member of the OLEUIBUSY structure is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The standard OLE Server <c>Busy</c> dialog box notifies the user that the server application is not receiving messages. The
		/// dialog box then asks the user to cancel the operation, switch to the task that is blocked, or continue waiting.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-oleuibusya UINT OleUIBusyA( LPOLEUIBUSYA Arg1 );
		[DllImport(Lib_OleDlg, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("oledlg.h", MSDNShortId = "NF:oledlg.OleUIBusyA")]
		public static extern uint OleUIBusy(ref OLEUIBUSY Arg1);

		/// <summary>
		/// Invokes the standard <c>Change Icon</c> dialog box, which allows the user to select an icon from an icon file, executable, or DLL.
		/// </summary>
		/// <param name="Arg1">Pointer to the In/Out OLEUICHANGEICON structure for this dialog box.</param>
		/// <returns>
		/// <para>Standard Success/Error Definitions</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLEUI_FALSE</term>
		/// <term>Unknown failure (unused).</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_OK</term>
		/// <term>The user pressed the OK button.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_SUCCESS</term>
		/// <term>No error, same as OLEUI_OK.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_CANCEL</term>
		/// <term>The user pressed the Cancel button.</term>
		/// </item>
		/// </list>
		/// <para>Standard Field Validation Errors</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLEUI_ERR_STANDARDMIN</term>
		/// <term>
		/// Errors common to all dialog boxes lie in the range OLEUI_ERR_STANDARDMIN to OLEUI_ERR_STANDARDMAX. This value allows the
		/// application to test for standard messages in order to display error messages to the user.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_STRUCTURENULL</term>
		/// <term>The pointer to an OLEUIXXX structure passed into the function was NULL.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_STRUCTUREINVALID</term>
		/// <term>Insufficient permissions for read or write access to an OLEUIXXX structure.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_CBSTRUCTINCORRECT</term>
		/// <term>The cbstruct value is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_HWNDOWNERINVALID</term>
		/// <term>The hWndOwner value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LPSZCAPTIONINVALID</term>
		/// <term>The lpszCaption value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LPFNHOOKINVALID</term>
		/// <term>The lpfnHook value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_HINSTANCEINVALID</term>
		/// <term>The hInstance value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LPSZTEMPLATEINVALID</term>
		/// <term>The lpszTemplate value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_HRESOURCEINVALID</term>
		/// <term>The hResource value is invalid.</term>
		/// </item>
		/// </list>
		/// <para>Initialization Errors</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLEUI_ERR_FINDTEMPLATEFAILURE</term>
		/// <term>Unable to find the dialog box template.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LOADTEMPLATEFAILURE</term>
		/// <term>Unable to load the dialog box template.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_DIALOGFAILURE</term>
		/// <term>Dialog box initialization failed.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LOCALMEMALLOC</term>
		/// <term>A call to LocalAlloc or the standard IMalloc allocator failed.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_GLOBALMEMALLOC</term>
		/// <term>A call to GlobalAlloc or the standard IMalloc allocator failed.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LOADSTRING</term>
		/// <term>Unable to call LoadString for localized resources from the library.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_OLEMEMALLOC</term>
		/// <term>A call to the standard IMalloc allocator failed.</term>
		/// </item>
		/// </list>
		/// <para>Function Specific Errors</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLEUI_ERR_STANDARDMAX</term>
		/// <term>
		/// Errors common to all dialog boxes lie in the range OLEUI_ERR_STANDARDMIN to OLEUI_ERR_STANDARDMAX. This value allows the
		/// application to test for standard messages in order to display error messages to the user.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OLEUI_CIERR_MUSTHAVECLSID</term>
		/// <term>The clsid member was not the current CLSID.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_CIERR_MUSTHAVECURRENTMETAFILE</term>
		/// <term>The hMetaPict member was not the current metafile.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_CIERR_SZICONEXEINVALID</term>
		/// <term>The szIconExe value was invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>OLEUICHANGEICON structure.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-oleuichangeicona UINT OleUIChangeIconA( LPOLEUICHANGEICONA
		// Arg1 );
		[DllImport(Lib_OleDlg, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("oledlg.h", MSDNShortId = "NF:oledlg.OleUIChangeIconA")]
		public static extern uint OleUIChangeIcon(ref OLEUICHANGEICON Arg1);

		/// <summary>Invokes the <c>Change Source</c> dialog box, allowing the user to change the source of a link.</summary>
		/// <param name="Arg1">Pointer to the in-out OLEUICHANGESOURCE structure for this dialog box.</param>
		/// <returns>
		/// <para>Standard Success/Error Definitions</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLEUI_FALSE</term>
		/// <term>Unknown failure (unused).</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_OK</term>
		/// <term>The user pressed the OK button.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_SUCCESS</term>
		/// <term>No error, same as OLEUI_OK.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_CANCEL</term>
		/// <term>The user pressed the Cancel button.</term>
		/// </item>
		/// </list>
		/// <para>Standard Field Validation Errors</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLEUI_ERR_STANDARDMIN</term>
		/// <term>
		/// Errors common to all dialog boxes lie in the range OLEUI_ERR_STANDARDMIN to OLEUI_ERR_STANDARDMAX. This value allows the
		/// application to test for standard messages in order to display error messages to the user.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_STRUCTURENULL</term>
		/// <term>The pointer to an OLEUIXXX structure passed into the function was NULL.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_STRUCTUREINVALID</term>
		/// <term>Insufficient permissions for read or write access to an OLEUIXXX structure.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_CBSTRUCTINCORRECT</term>
		/// <term>The cbstruct value is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_HWNDOWNERINVALID</term>
		/// <term>The hWndOwner value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LPSZCAPTIONINVALID</term>
		/// <term>The lpszCaption value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LPFNHOOKINVALID</term>
		/// <term>The lpfnHook value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_HINSTANCEINVALID</term>
		/// <term>The hInstance value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LPSZTEMPLATEINVALID</term>
		/// <term>The lpszTemplate value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_HRESOURCEINVALID</term>
		/// <term>The hResource value is invalid.</term>
		/// </item>
		/// </list>
		/// <para>Initialization Errors</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLEUI_ERR_FINDTEMPLATEFAILURE</term>
		/// <term>Unable to find the dialog box template.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LOADTEMPLATEFAILURE</term>
		/// <term>Unable to load the dialog box template.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_DIALOGFAILURE</term>
		/// <term>Dialog box initialization failed.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LOCALMEMALLOC</term>
		/// <term>A call to LocalAlloc or the standard IMalloc allocator failed.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_GLOBALMEMALLOC</term>
		/// <term>A call to GlobalAlloc or the standard IMalloc allocator failed.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_LOADSTRING</term>
		/// <term>Unable to call LoadString for localized resources from the library.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_ERR_OLEMEMALLOC</term>
		/// <term>A call to the standard IMalloc allocator failed.</term>
		/// </item>
		/// </list>
		/// <para>Function Specific Errors</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLEUI_ERR_STANDARDMAX</term>
		/// <term>
		/// Errors common to all dialog boxes lie in the range OLEUI_ERR_STANDARDMIN to OLEUI_ERR_STANDARDMAX. This value allows the
		/// application to test for standard messages in order to display error messages to the user.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OLEUI_CSERR_LINKCNTRNULL</term>
		/// <term>The lpOleUILinkContainer value is NULL.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_CSERR_LINKCNTRINVALID</term>
		/// <term>The lpOleUILinkContainer value is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_CSERR_FROMNOTNULL</term>
		/// <term>The lpszFrom value is not NULL.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_CSERR_TONOTNULL</term>
		/// <term>The lpszTo value is not NULL.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_CSERR_SOURCEINVALID</term>
		/// <term>The lpszDisplayName or nFileLength value is invalid, or cannot retrieve the link source.</term>
		/// </item>
		/// <item>
		/// <term>OLEUI_CSERR_SOURCEPARSEERROR</term>
		/// <term>The nFilename value is wrong.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The link source is not changed by the <c>Change Source</c> dialog box itself. Instead, it is up to the caller to change the link
		/// source using the returned file and item strings. The <c>Edit Links</c> dialog box typically does this for the caller.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-oleuichangesourcea UINT OleUIChangeSourceA(
		// LPOLEUICHANGESOURCEA Arg1 );
		[DllImport(Lib_OleDlg, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("oledlg.h", MSDNShortId = "NF:oledlg.OleUIChangeSourceA")]
		public static extern uint OleUIChangeSource(ref OLEUICHANGESOURCE Arg1);

		/// <summary>
		/// Contains information that the OLE User Interface Library uses to initialize the <c>Busy</c> dialog box, and space for the
		/// library to return information when the dialog box is dismissed.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/ns-oledlg-oleuibusya typedef struct tagOLEUIBUSYA { DWORD cbStruct;
		// DWORD dwFlags; HWND hWndOwner; LPCSTR lpszCaption; LPFNOLEUIHOOK lpfnHook; LPARAM lCustData; HINSTANCE hInstance; LPCSTR
		// lpszTemplate; HRSRC hResource; HTASK hTask; HWND *lphWndDialog; } OLEUIBUSYA, *POLEUIBUSYA, *LPOLEUIBUSYA;
		[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUIBUSYA")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct OLEUIBUSY
		{
			/// <summary>The size of the structure, in bytes. This field must be filled on input.</summary>
			public uint cbStruct;

			/// <summary>
			/// <para>
			/// On input, specifies the initialization and creation flags. On exit, it specifies the user's choices. It may be a combination
			/// of the following flags.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>BZ_DISABLECANCELBUTTON</term>
			/// <term>This flag disables the Cancel button.</term>
			/// </item>
			/// <item>
			/// <term>BZ_DISABLESWITCHTOBUTTON</term>
			/// <term>Input only. This flag disables the Switch To... button.</term>
			/// </item>
			/// <item>
			/// <term>BZ_DISABLERETRYBUTTON</term>
			/// <term>Input only. This flag disables the Retry button.</term>
			/// </item>
			/// <item>
			/// <term>BZ_NOTRESPONDINGDIALOG</term>
			/// <term>
			/// Input only. This flag generates a Not Responding dialog box instead of a Busy dialog box. The text is slightly different,
			/// and the Cancel button is disabled.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public BZ dwFlags;

			/// <summary>The window that owns the dialog box. This member should not be <c>NULL</c>.</summary>
			public HWND hWndOwner;

			/// <summary>A pointer to a string to be used as the title of the dialog box. If <c>NULL</c>, then the library uses <c>Busy</c>.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszCaption;

			/// <summary>
			/// Pointer to a hook function that processes messages intended for the dialog box. The hook function must return zero to pass a
			/// message that it didn't process back to the dialog box procedure in the library. The hook function must return a nonzero
			/// value to prevent the library's dialog box procedure from processing a message it has already processed.
			/// </summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public LPFNOLEUIHOOK lpfnHook;

			/// <summary>
			/// Application-defined data that the library passes to the hook function pointed to by the <c>lpfnHook</c> member. The library
			/// passes a pointer to the <c>OLEUIBUSY</c> structure in the lParam parameter of the WM_INITDIALOG message; this pointer can be
			/// used to retrieve the <c>lCustData</c> member.
			/// </summary>
			public IntPtr lCustData;

			/// <summary>Instance that contains a dialog box template specified by the <c>lpTemplateName</c> member.</summary>
			public HINSTANCE hInstance;

			/// <summary>
			/// Pointer to a null-terminated string that specifies the name of the resource file for the dialog box template that is to be
			/// substituted for the library's <c>Busy</c> dialog box template.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszTemplate;

			/// <summary>Customized template handle.</summary>
			public HRSRC hResource;

			/// <summary>Input only. Handle to the task that is blocking.</summary>
			public HTASK hTask;

			/// <summary>Pointer to the dialog box's <c>HWND</c>.</summary>
			public IntPtr lphWndDialog;
		}

		/// <summary>
		/// Contains information that the OLE User Interface Library uses to initialize the <c>Change Icon</c> dialog box, and it contains
		/// space for the library to return information when the dialog box is dismissed.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/ns-oledlg-oleuichangeicona typedef struct tagOLEUICHANGEICONA { DWORD
		// cbStruct; DWORD dwFlags; HWND hWndOwner; LPCSTR lpszCaption; LPFNOLEUIHOOK lpfnHook; LPARAM lCustData; HINSTANCE hInstance;
		// LPCSTR lpszTemplate; HRSRC hResource; HGLOBAL hMetaPict; CLSID clsid; CHAR szIconExe[MAX_PATH]; int cchIconExe; }
		// OLEUICHANGEICONA, *POLEUICHANGEICONA, *LPOLEUICHANGEICONA;
		[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUICHANGEICONA")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct OLEUICHANGEICON
		{
			/// <summary>The size of the structure, in bytes. This field must be filled on input.</summary>
			public uint cbStruct;

			/// <summary>
			/// <para>
			/// On input, specifies the initialization and creation flags. On exit, it specifies the user's choices. It can be a combination
			/// of the following flags.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CIF_SHOWHELP</term>
			/// <term>Dialog box will display a Help button.</term>
			/// </item>
			/// <item>
			/// <term>CIF_SELECTCURRENT</term>
			/// <term>On input, selects the Current radio button on initialization. On exit, specifies that the user selected Current.</term>
			/// </item>
			/// <item>
			/// <term>CIF_SELECTDEFAULT</term>
			/// <term>On input, selects the Default radio button on initialization. On exit, specifies that the user selected Default.</term>
			/// </item>
			/// <item>
			/// <term>CIF_SELECTFROMFILE</term>
			/// <term>On input, selects the From File radio button on initialization. On exit, specifies that the user selected From File.</term>
			/// </item>
			/// <item>
			/// <term>CIF_USEICONEXE</term>
			/// <term>
			/// Input only. Extracts the icon from the executable specified in the szIconExe member, instead of retrieving it from the
			/// class. This is useful for OLE embedding or linking to non-OLE files.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public CIF dwFlags;

			/// <summary>The window that owns the dialog box. This member should not be <c>NULL</c>.</summary>
			public HWND hWndOwner;

			/// <summary>
			/// Pointer to a string to be used as the title of the dialog box. If <c>NULL</c>, then the library uses <c>Change Icon</c>.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszCaption;

			/// <summary>
			/// Pointer to a hook function that processes messages intended for the dialog box. The hook function must return zero to pass a
			/// message that it didn't process back to the dialog box procedure in the library. The hook function must return a nonzero
			/// value to prevent the library's dialog box procedure from processing a message it has already processed.
			/// </summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public LPFNOLEUIHOOK lpfnHook;

			/// <summary>
			/// Application-defined data that the library passes to the hook function pointed to by the <c>lpfnHook</c> member. The library
			/// passes a pointer to the <c>OLEUICHANGEICON</c> structure in the lParam parameter of the WM_INITDIALOG message; this pointer
			/// can be used to retrieve the <c>lCustData</c> member.
			/// </summary>
			public IntPtr lCustData;

			/// <summary>Instance that contains a dialog box template specified by the <c>lpTemplateName</c> member.</summary>
			public HINSTANCE hInstance;

			/// <summary>
			/// Pointer to a null-terminated string that specifies the name of the resource file for the dialog box template that is to be
			/// substituted for the library's <c>Change Icon</c> dialog box template.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszTemplate;

			/// <summary>Customized template handle.</summary>
			public HRSRC hResource;

			/// <summary>Current and final image. The source of the icon is embedded in the metafile itself.</summary>
			public HGLOBAL hMetaPict;

			/// <summary>Input only. The class to use to get the <c>Default</c> icon.</summary>
			public Guid clsid;

			/// <summary>
			/// Input only. Pointer to the executable to extract the default icon from. This member is ignored unless CIF_USEICONEXE is
			/// included in the <c>dwFlags</c> member and an attempt to retrieve the class icon from the specified CLSID fails.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string szIconExe;

			/// <summary>
			/// Input only. The number of characters in <c>szIconExe</c>. This member is ignored unless CIF_USEICONEXE is included in the
			/// <c>dwFlags</c> member.
			/// </summary>
			public int cchIconExe;
		}

		/// <summary>
		/// Contains information that is used to initialize the standard <c>Change Source</c> dialog box. It allows the user to modify the
		/// destination or source of a link. This may simply entail selecting a different file name for the link, or possibly changing the
		/// item reference within the file, for example, changing the destination range of cells within the spreadsheet that the link is to.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/ns-oledlg-oleuichangesourcea typedef struct tagOLEUICHANGESOURCEA {
		// DWORD cbStruct; DWORD dwFlags; HWND hWndOwner; LPCSTR lpszCaption; LPFNOLEUIHOOK lpfnHook; LPARAM lCustData; HINSTANCE hInstance;
		// LPCSTR lpszTemplate; HRSRC hResource; OPENFILENAMEA *lpOFN; DWORD dwReserved1[4]; LPOLEUILINKCONTAINERA lpOleUILinkContainer;
		// DWORD dwLink; LPSTR lpszDisplayName; ULONG nFileLength; LPSTR lpszFrom; LPSTR lpszTo; } OLEUICHANGESOURCEA, *POLEUICHANGESOURCEA, *LPOLEUICHANGESOURCEA;
		[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUICHANGESOURCEA")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct OLEUICHANGESOURCE
		{
			/// <summary>The size of the structure, in bytes.</summary>
			public uint cbStruct;

			/// <summary>
			/// <para>
			/// On input, this field specifies the initialization and creation flags. On exit, it specifies the user's choices. It may be a
			/// combination of the following flags.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CSF_SHOWHELP</term>
			/// <term>Enables or shows the Help button.</term>
			/// </item>
			/// <item>
			/// <term>CSF_VALIDSOURCE</term>
			/// <term>Indicates that the link was validated.</term>
			/// </item>
			/// <item>
			/// <term>CSF_ONLYGETSOURCE</term>
			/// <term>
			/// Disables automatic validation of the link source when the user presses OK. If you specify this flag, you should validate the
			/// source when the dialog box returns OK.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public CSF dwFlags;

			/// <summary>The window that owns the dialog box.</summary>
			public HWND hWndOwner;

			/// <summary>
			/// Pointer to a string to be used as the title of the dialog box. If <c>NULL</c>, then the library uses <c>Change Source</c>.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszCaption;

			/// <summary>
			/// Pointer to a hook function that processes messages intended for the dialog box. The hook function must return zero to pass a
			/// message that it didn't process back to the dialog box procedure in the library. The hook function must return a nonzero
			/// value to prevent the library's dialog box procedure from processing a message it has already processed.
			/// </summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public LPFNOLEUIHOOK lpfnHook;

			/// <summary>
			/// Application-defined data that the library passes to the hook function pointed to by the OLEUICHANGEICON structure in the
			/// lParam parameter of the WM_INITDIALOG message; this pointer can be used to retrieve the <c>lCustData</c> member.
			/// </summary>
			public IntPtr lCustData;

			/// <summary>
			/// Instance that contains a dialog box template specified by the <c>lpszTemplate</c> member. This member is ignored if the
			/// <c>lpszTemplate</c> member is <c>NULL</c> or invalid.
			/// </summary>
			public HINSTANCE hInstance;

			/// <summary>
			/// Pointer to a null-terminated string that specifies the name of the resource file for the dialog box template that is to be
			/// substituted for the library's <c>Convert</c> dialog box template.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszTemplate;

			/// <summary>
			/// Resource handle for a custom dialog box. If this member is <c>NULL</c>, then the library uses the standard <c>Convert</c>
			/// dialog box template, or if it is valid, the template named by the <c>lpszTemplate</c> member.
			/// </summary>
			public HRSRC hResource;

			/// <summary>
			/// Pointer to the <c>OPENFILENAME</c> structure, which contains information used by the operating system to initialize the
			/// system-defined <c>Open</c> or <c>Save As</c> dialog boxes.
			/// </summary>
			public IntPtr lpOFN;

			/// <summary>This member is reserved.</summary>
			public Guid dwReserved1;

			/// <summary>
			/// Pointer to the container's implementation of the <see cref="IOleUILinkContainer"/> interface, used to validate the link
			/// source. The <c>Edit Links</c> dialog box uses this to allow the container to manipulate its links.
			/// </summary>
			public IntPtr lpOleUILinkContainer;

			/// <summary>Container-defined unique link identifier used to validate link sources. Used by <c>lpOleUILinkContainer</c>.</summary>
			public uint dwLink;

			/// <summary>Pointer to the complete source display name.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszDisplayName;

			/// <summary>File moniker portion of <c>lpszDisplayName</c>.</summary>
			public uint nFileLength;

			/// <summary>Pointer to the prefix of the source that was changed from.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszFrom;

			/// <summary>Pointer to the prefix of the source to be changed to.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszTo;
		}

		/*
		OLEUICHANGESOURCEW
		OLEUICONVERTA
		OLEUICONVERTW
		OLEUIEDITLINKSA
		OLEUIEDITLINKSW
		OLEUIGNRLPROPSA
		OLEUIGNRLPROPSW
		OLEUIINSERTOBJECTA
		OLEUIINSERTOBJECTW
		OLEUILINKPROPSA
		OLEUILINKPROPSW
		OLEUIOBJECTPROPSA
		OLEUIOBJECTPROPSW
		OLEUIPASTEENTRYA
		OLEUIPASTEENTRYW
		OLEUIPASTESPECIALA
		OLEUIPASTESPECIALW
		OLEUIVIEWPROPSA
		OLEUIVIEWPROPSW

		OleUIAddVerbMenuA
		OleUIAddVerbMenuW
		OleUICanConvertOrActivateAs
		OleUIConvertA
		OleUIConvertW
		OleUIEditLinksA
		OleUIEditLinksW
		OleUIInsertObjectA
		OleUIInsertObjectW
		OleUIObjectPropertiesA
		OleUIObjectPropertiesW
		OleUIPasteSpecialA
		OleUIPasteSpecialW
		OleUIPromptUserA
		OleUIPromptUserW
		OleUIUpdateLinksA
		OleUIUpdateLinksW
		*/
	}
}