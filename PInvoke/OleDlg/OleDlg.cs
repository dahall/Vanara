using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Ole32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke;

/// <summary>Functions, interfaces and structures from Windows OleDlg.dll.</summary>
public static partial class OleDlg
{
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

	/// <summary>On input, this field specifies the initialization and creation flags. On exit, it specifies the user's choices.</summary>
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUICONVERTA")]
	[Flags]
	public enum CF
	{
		/// <summary>Dialog box will display a Help button. This flag is set on input.</summary>
		CF_SHOWHELPBUTTON = 0x0001,

		/// <summary>
		/// Class whose CLSID is specified by clsidConvertDefault will be used as the default selection. This selection appears in the
		/// class listbox when the Convert To radio button is selected. This flag is set on input.
		/// </summary>
		CF_SETCONVERTDEFAULT = 0x0002,

		/// <summary>
		/// Class whose CLSID is specified by clsidActivateDefault will be used as the default selection. This selection appears in the
		/// class listbox when the Activate As radio button is selected. This flag is set on input.
		/// </summary>
		CF_SETACTIVATEDEFAULT = 0x0004,

		/// <summary>
		/// On input, this flag specifies that Convert To will be initially selected (default behavior). This flag is set on output if
		/// Convert To was selected when the user dismissed the dialog box.
		/// </summary>
		CF_SELECTCONVERTTO = 0x0008,

		/// <summary>
		/// On input, this flag specifies that Activate As will be initially selected. This flag is set on output if Activate As was
		/// selected when the user dismissed the dialog box.
		/// </summary>
		CF_SELECTACTIVATEAS = 0x0010,

		/// <summary>The Display As Icon button will be disabled on initialization.</summary>
		CF_DISABLEDISPLAYASICON = 0x0020,

		/// <summary>The Activate As radio button will be disabled on initialization.</summary>
		CF_DISABLEACTIVATEAS = 0x0040,

		/// <summary>The Change Icon button will be hidden in the Convert dialog box.</summary>
		CF_HIDECHANGEICON = 0x0080,

		/// <summary>The Activate As radio button will be disabled in the Convert dialog box.</summary>
		CF_CONVERTONLY = 0x0100,
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

	/// <summary>On input, <c>dwFlags</c> specifies the initialization and creation flags.</summary>
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUIEDITLINKSA")]
	[Flags]
	public enum ELF
	{
		/// <summary>Specifies that the dialog box will display a Help button.</summary>
		ELF_SHOWHELP = 0x01,

		/// <summary>Specifies that the Update Now button will be disabled on initialization.</summary>
		ELF_DISABLEUPDATENOW = 0x02,

		/// <summary>Specifies that the Open Source button will be disabled on initialization.</summary>
		ELF_DISABLEOPENSOURCE = 0x04,

		/// <summary>Specifies that the Change Source button will be disabled on initialization.</summary>
		ELF_DISABLECHANGESOURCE = 0x08,

		/// <summary>Specifies that the Cancel Link button will be disabled on initialization.</summary>
		ELF_DISABLECANCELLINK = 0x10,
	}

	/// <summary>On input, specifies the initialization and creation flags. On exit, specifies the user's choices.</summary>
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUIINSERTOBJECTA")]
	[Flags]
	public enum IOF
	{
		/// <summary>The dialog box will display a Help button.</summary>
		IOF_SHOWHELP = 0x00000001,

		/// <summary>The Create New radio button will initially be checked. This cannot be used with IOF_SELECTCREATEFROMFILE.</summary>
		IOF_SELECTCREATENEW = 0x00000002,

		/// <summary>The Create From File radio button will initially be checked. This cannot be used with IOF_SELECTCREATENEW.</summary>
		IOF_SELECTCREATEFROMFILE = 0x00000004,

		/// <summary>The Link check box will initially be checked.</summary>
		IOF_CHECKLINK = 0x00000008,

		/// <summary>
		/// The Display As Icon check box will initially be checked, the current icon will be displayed, and the Change Icon button will
		/// be enabled.
		/// </summary>
		IOF_CHECKDISPLAYASICON = 0x00000010,

		/// <summary>
		/// A new object should be created when the user selects OK to dismiss the dialog box and the Create New radio button was selected.
		/// </summary>
		IOF_CREATENEWOBJECT = 0x00000020,

		/// <summary>
		/// A new object should be created from the specified file when the user selects OK to dismiss the dialog box and the Create
		/// From File radio button was selected.
		/// </summary>
		IOF_CREATEFILEOBJECT = 0x00000040,

		/// <summary>
		/// A new linked object should be created when the user selects OK to dismiss the dialog box and the user checked the Link check box.
		/// </summary>
		IOF_CREATELINKOBJECT = 0x00000080,

		/// <summary>The Link check box will be disabled on initialization.</summary>
		IOF_DISABLELINK = 0x00000100,

		/// <summary>
		/// The dialog box should validate the classes it adds to the listbox by ensuring that the server specified in the registration
		/// database exists. This is a significant performance factor.
		/// </summary>
		IOF_VERIFYSERVERSEXIST = 0x00000200,

		/// <summary>The Display As Icon check box will be disabled on initialization.</summary>
		IOF_DISABLEDISPLAYASICON = 0x00000400,

		/// <summary>The Change Icon button will be hidden in the Insert Object dialog box.</summary>
		IOF_HIDECHANGEICON = 0x00000800,

		/// <summary>Displays the Insert Control radio button.</summary>
		IOF_SHOWINSERTCONTROL = 0x00001000,

		/// <summary>Displays the Create Control radio button.</summary>
		IOF_SELECTCREATECONTROL = 0x00002000,
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

	/// <summary>Contains in/out global flags for the property sheet.</summary>
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUIOBJECTPROPSA")]
	[Flags]
	public enum OPF
	{
		/// <summary>Object is a link object and therefore has a link property page.</summary>
		OPF_OBJECTISLINK = 0x00000001,

		/// <summary>Do not fill in default values for the object.</summary>
		OPF_NOFILLDEFAULT = 0x00000002,

		/// <summary>The dialog box will display a Help button.</summary>
		OPF_SHOWHELP = 0x00000004,

		/// <summary>The Convert button will be disabled on the general property page.</summary>
		OPF_DISABLECONVERT = 0x00000008,
	}

	/// <summary>On input, dwFlags specifies the initialization and creation flags. On exit, it specifies the user's choices.</summary>
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUIPASTESPECIALA")]
	[Flags]
	public enum PSF
	{
		/// <summary>Dialog box will display a Help button.</summary>
		PSF_SHOWHELP = 0x00000001,

		/// <summary>
		/// The Paste radio button will be selected at dialog box startup. This is the default, if PSF_SELECTPASTE or
		/// PSF_SELECTPASTELINK are not specified. Also, it specifies the state of the button on dialog termination. IN/OUT flag.
		/// </summary>
		PSF_SELECTPASTE = 0x00000002,

		/// <summary>
		/// The PasteLink radio button will be selected at dialog box startup. Also, specifies the state of the button on dialog
		/// termination. IN/OUT flag.
		/// </summary>
		PSF_SELECTPASTELINK = 0x00000004,

		/// <summary>Whether the Display As Icon radio button was checked on dialog box termination. OUT flag.</summary>
		PSF_CHECKDISPLAYASICON = 0x00000008,

		/// <summary>The Display As Icon check box will be disabled on initialization.</summary>
		PSF_DISABLEDISPLAYASICON = 0x00000010,

		/// <summary>
		/// Used to disable the change-icon button in the dialog box, which is available to users when they're pasting an OLE object by
		/// default. See STAYONCLIPBOARDCHANGE otherwise.
		/// </summary>
		PSF_HIDECHANGEICON = 0x00000020,

		/// <summary>
		/// Used to tell the dialog box to stay up if the clipboard changes while the dialog box is up. If the user switches to another
		/// application and copies or cuts something, the dialog box will, by default, perform a cancel operation, which will remove the
		/// dialog box since the options it's in the middle of presenting to the user are no longer up-to-date with respect to what's
		/// really on the clipboard.
		/// </summary>
		PSF_STAYONCLIPBOARDCHANGE = 0x00000040,

		/// <summary>
		/// Used in conjunction with STAYONCLIPBOARDCHANGE (it doesn't do anything otherwise). If the clipboard changes while the dialog
		/// box is up and STAYONCLIPBOARDCHANGE is specified, then NOREFRESHDATAOBJECT indicates that the dialog box should NOT refresh
		/// the contents of the dialog box to reflect the new contents of the clipboard. This is useful if the application is using the
		/// paste-special dialog box on an IDataObject besides the one on the clipboard, for example, as part of a right-click
		/// drag-and-drop operation.
		/// </summary>
		PSF_NOREFRESHDATAOBJECT = 0x00000080,
	}

	/// <summary>Flags specific to view page</summary>
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUIVIEWPROPSA")]
	[Flags]
	public enum VPF : uint
	{
		/// <summary>Relative to origin.</summary>
		VPF_SELECTRELATIVE = 0x00000001,

		/// <summary>Disable relative to origin.</summary>
		VPF_DISABLERELATIVE = 0x00000002,

		/// <summary>Disable scale option.</summary>
		VPF_DISABLESCALE = 0x00000004,
	}

	/// <summary>
	/// <para>
	/// Implemented by containers and used by OLE common dialog boxes. It supports these dialog boxes by providing the methods needed to
	/// manage a container's links.
	/// </para>
	/// <para>
	/// The <c>IOleUILinkContainer</c> methods enumerate the links associated with a container, and specify how they should be updated,
	/// automatically or manually. They change the source of a link and obtain information associated with a link. They also open a
	/// link's source document, update links, and break a link to the source.
	/// </para>
	/// </summary>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nn-oledlg-ioleuilinkcontainerw
	[PInvokeData("oledlg.h", MSDNShortId = "NN:oledlg.IOleUILinkContainerW")]
	[ComImport, Guid("000004ff-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleUILinkContainer
	{
		/// <summary>Enumerates the links in a container.</summary>
		/// <param name="dwLink">
		/// Container-defined unique identifier for a single link. This value is only passed to other methods on this interface, so it
		/// can be any value that uniquely identifies a link to the container. Containers frequently use the pointer to the link's
		/// container site object for this value.
		/// </param>
		/// <returns>Returns a container's link identifiers in sequence; <c>NULL</c> if it has returned the last link.</returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Call this method to enumerate the links in a container. If the value passed in dwLink is <c>NULL</c>, then the container
		/// should return the first link's identifier. If dwLink identifies the last link in the container, then the container should
		/// return <c>NULL</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-ioleuilinkcontainera-getnextlink DWORD GetNextLink( DWORD
		// dwLink );
		[PreserveSig]
		uint GetNextLink(uint dwLink);

		/// <summary>Sets a link's update options to automatic or manual.</summary>
		/// <param name="dwLink">Container-defined unique identifier for a single link. See IOleUILinkContainer::GetNextLink.</param>
		/// <param name="dwUpdateOpt">Update options, which can be automatic (OLEUPDATE_ALWAYS) or manual (OLEUPDATE_ONCALL).</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>Insufficient access permissions.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified identifier is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>Containers can implement this method for OLE links by simply calling IOleLink::SetUpdateOptions on the link object.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-ioleuilinkcontainera-setlinkupdateoptions HRESULT
		// SetLinkUpdateOptions( DWORD dwLink, DWORD dwUpdateOpt );
		[PreserveSig]
		HRESULT SetLinkUpdateOptions(uint dwLink, uint dwUpdateOpt);

		/// <summary>Determines the current update options for a link.</summary>
		/// <param name="dwLink">Container-defined unique identifier for a single link. See IOleUILinkContainer::GetNextLink.</param>
		/// <param name="lpdwUpdateOpt">A pointer to the location that the current update options will be written.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>Insufficient access permissions.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified identifier is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>Containers can implement this method for OLE links simply by calling IOleLink::SetUpdateOptions on the link object.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-ioleuilinkcontainera-getlinkupdateoptions HRESULT
		// GetLinkUpdateOptions( DWORD dwLink, DWORD *lpdwUpdateOpt );
		[PreserveSig]
		HRESULT GetLinkUpdateOptions(uint dwLink, out uint lpdwUpdateOpt);

		/// <summary>Changes the source of a link.</summary>
		/// <param name="dwLink">Container-defined unique identifier for a single link. See IOleUILinkContainer::GetNextLink.</param>
		/// <param name="lpszDisplayName">Pointer to new source string to be parsed.</param>
		/// <param name="lenFileName">
		/// Length of the leading file name portion of the lpszDisplayName string. If the link source is not stored in a file, then
		/// lenFileName should be 0. For OLE links, call IOleLink::GetSourceDisplayName.
		/// </param>
		/// <param name="pchEaten">Pointer to the number of characters successfully parsed in lpszDisplayName.</param>
		/// <param name="fValidateSource">
		/// <c>TRUE</c> if the moniker should be validated; for OLE links, MkParseDisplayName should be called. <c>FALSE</c> if the
		/// moniker should not be validated. If possible, the link should accept the unvalidated source, and mark itself as unavailable.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>Insufficient access permissions.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The supplied identifier is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Call this method from the <c>Change Source</c> dialog box, with fValidateSource initially set to <c>TRUE</c>. <c>Change
		/// Source</c> can be called directly or from the <c>Links</c> dialog box. If this call to
		/// <c>IOleUILinkContainer::SetLinkSource</c> returns an error (e.g., MkParseDisplayName failed because the source was
		/// unavailable), then you should display an <c>Invalid Link Source</c> message, and the user should be allowed to decide
		/// whether to fix the source. If the user chooses to fix the source, then the user should be returned to the <c>Change
		/// Source</c> dialog box with the invalid portion of the input string highlighted. If the user chooses not to fix the source,
		/// then <c>IOleUILinkContainer::SetLinkSource</c> should be called a second time with fValidateSource set to <c>FALSE</c>, and
		/// the user should be returned to the <c>Links</c> dialog box with the link marked <c>Unavailable</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-ioleuilinkcontainera-setlinksource HRESULT SetLinkSource(
		// DWORD dwLink, LPSTR lpszDisplayName, ULONG lenFileName, ULONG *pchEaten, BOOL fValidateSource );
		[PreserveSig]
		HRESULT SetLinkSource(uint dwLink, [MarshalAs(UnmanagedType.LPStr)] string lpszDisplayName,
			uint lenFileName, out uint pchEaten, [MarshalAs(UnmanagedType.Bool)] bool fValidateSource);

		/// <summary>Retrieves information about a link that can be displayed in the <c>Links</c> dialog box.</summary>
		/// <param name="dwLink">Container-defined unique identifier for a single link. See IOleUILinkContainer::GetNextLink.</param>
		/// <param name="lplpszDisplayName">
		/// Address of a pointer variable that receives a pointer to the full display name string for the link source. The <c>Links</c>
		/// dialog box will free this string.
		/// </param>
		/// <param name="lplenFileName">
		/// Pointer to the length of the leading file name portion of the lplpszDisplayName string. If the link source is not stored in
		/// a file, then lplenFileName should be 0. For OLE links, call IOleLink::GetSourceDisplayName.
		/// </param>
		/// <param name="lplpszFullLinkType">
		/// Address of a pointer variable that receives a pointer to the full link type string that is displayed at the bottom of the
		/// <c>Links</c> dialog box. The caller allocates this string. The <c>Links</c> dialog box will free this string. For OLE links,
		/// this should be the full User Type name. Use IOleObject::GetUserType, specifying USERCLASSTYPE_FULL for dwFormOfType.
		/// </param>
		/// <param name="lplpszShortLinkType">
		/// Address of a pointer variable that receives a pointer to the short link type string that is displayed in the listbox of the
		/// <c>Links</c> dialog box. The caller allocates this string. The <c>Links</c> dialog box will free this string. For OLE links,
		/// this should be the short user type name. Use IOleObject::GetUserType, specifying USERCLASSTYPE_SHORT for dwFormOfType.
		/// </param>
		/// <param name="lpfSourceAvailable">
		/// Pointer that returns <c>FALSE</c> if it is known that a link is unavailable since the link is to some known but unavailable
		/// document. Certain options, such as <c>Update Now</c>, are disabled (grayed in the user interface) for such cases.
		/// </param>
		/// <param name="lpfIsSelected">
		/// Pointer to a variable that tells the <c>Edit Links</c> dialog box that this link's entry should be selected in the dialog's
		/// multi-selection listbox. OleUIEditLinks calls this method at least once for each item to be placed in the links list. If
		/// none of them return <c>TRUE</c>, then none of them will be selected when the dialog box is first displayed. If all of them
		/// return <c>TRUE</c>, then all will be displayed. That is, it returns <c>TRUE</c> if this link is currently part of the
		/// selection in the underlying document, <c>FALSE</c> if not. Any links that are selected in the underlying document are
		/// selected in the dialog box; this way, the user can select a set of links and use the dialog box to update them or change
		/// their source(s) simultaneously.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>Insufficient access permissions.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified identifier is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>Call this method during dialog box initialization, after returning from the <c>Change Source</c> dialog box.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-ioleuilinkcontainera-getlinksource HRESULT GetLinkSource(
		// DWORD dwLink, LPSTR *lplpszDisplayName, ULONG *lplenFileName, LPSTR *lplpszFullLinkType, LPSTR *lplpszShortLinkType, BOOL
		// *lpfSourceAvailable, BOOL *lpfIsSelected );
		[PreserveSig]
		HRESULT GetLinkSource(uint dwLink, [MarshalAs(UnmanagedType.LPStr)] out string lplpszDisplayName, out uint lplenFileName,
			[MarshalAs(UnmanagedType.LPStr)] out string lplpszFullLinkType, [MarshalAs(UnmanagedType.LPStr)] out string lplpszShortLinkType,
			[MarshalAs(UnmanagedType.Bool)] out bool lpfSourceAvailable, [MarshalAs(UnmanagedType.Bool)] out bool lpfIsSelected);

		/// <summary>Opens the link's source.</summary>
		/// <param name="dwLink">
		/// Container-defined unique identifier for a single link. Containers can use the pointer to the link's container site for this value.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>Insufficient access permissions.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified identifier is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The <c>IOleUILinkContainer::OpenLinkSource</c> method is called when the <c>Open Source</c> button is selected from the
		/// <c>Links</c> dialog box. For OLE links, call IOleObject::DoVerb, specifying OLEIVERB_SHOW for iVerb.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-ioleuilinkcontainera-openlinksource HRESULT
		// OpenLinkSource( DWORD dwLink );
		[PreserveSig]
		HRESULT OpenLinkSource(uint dwLink);

		/// <summary>Forces selected links to connect to their source and retrieve current information.</summary>
		/// <param name="dwLink">
		/// Container-defined unique identifier for a single link. Containers can use the pointer to the link's container site for this value.
		/// </param>
		/// <param name="fErrorMessage">
		/// Determines whether the caller (implementer of IOleUILinkContainer) should show an error message upon failure to update a
		/// link. The <c>Update Links</c> dialog box sets this to <c>FALSE</c>. The <c>Object Properties</c> and <c>Links</c> dialog
		/// boxes set it to <c>TRUE</c>.
		/// </param>
		/// <param name="fReserved">This parameter is reserved and must be set to <c>FALSE</c>.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>Insufficient access permissions.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified identifier is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Call this method with fErrorMessage set to <c>TRUE</c> in cases where the user expressly presses a button to have a link
		/// updated, that is, presses the links' <c>Update Now</c> button. Call it with <c>FALSE</c> in cases where the container should
		/// never display an error message, that is, where a large set of operations are being performed and the error should be
		/// propagated back to the user later, as might occur with the <c>Update links</c> progress meter. Rather than providing one
		/// message for each failure, assuming there are failures, provide a single message for all failures at the end of the operation.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>For OLE links, call IOleObject::Update.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-ioleuilinkcontainera-updatelink HRESULT UpdateLink( DWORD
		// dwLink, BOOL fErrorMessage, BOOL fReserved );
		[PreserveSig]
		HRESULT UpdateLink(uint dwLink, [MarshalAs(UnmanagedType.Bool)] bool fErrorMessage, [MarshalAs(UnmanagedType.Bool)] bool fReserved);

		/// <summary>Disconnects the selected links.</summary>
		/// <param name="dwLink">
		/// Container-defined unique identifier for a single link. Containers can use the pointer to the link's container site for this value.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>Insufficient access permissions.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified identifier is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Call <c>IOleUILinkContainer::CancelLink</c> when the user selects the <c>Break Link</c> button from the <c>Links</c> dialog
		/// box. The link should be converted to a picture. The <c>Links</c> dialog box will not be dismissed for OLE links.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// For OLE links, OleCreateStaticFromData can be used to create a static picture object using the IDataObject interface of the
		/// link as the source.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-ioleuilinkcontainera-cancellink HRESULT CancelLink( DWORD
		// dwLink );
		[PreserveSig]
		HRESULT CancelLink(uint dwLink);
	}

	/// <summary>
	/// An extension of the IOleUILinkContainer interface. It returns the time that an object was last updated, which is link
	/// information that <c>IOleUILinkContainer</c> does not provide.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nn-oledlg-ioleuilinkinfoa
	[PInvokeData("oledlg.h", MSDNShortId = "NN:oledlg.IOleUILinkInfoA")]
	public interface IOleUILinkInfo : IOleUILinkContainer
	{
		/// <summary>Determines the last time the object was updated.</summary>
		/// <param name="dwLink">
		/// Container-defined unique identifier for a single link. Containers can use the pointer to the link's container site for this value.
		/// </param>
		/// <param name="lpLastUpdate">A pointer to a FILETIME structure that indicates the time that the object was last updated.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>Insufficient access permissions.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified identifier is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// If the time that the object was last updated is known, copy it to lpLastUpdate. If it is not known, then leave lpLastUpdate
		/// unchanged and Unknown will be displayed in the link page.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-ioleuilinkinfoa-getlastupdate HRESULT GetLastUpdate(
		// DWORD dwLink, FILETIME *lpLastUpdate );
		[PreserveSig]
		HRESULT GetLastUpdate(uint dwLink, out FILETIME lpLastUpdate);
	}

	/// <summary>
	/// Implemented by containers and used by the container's <c>Object Properties</c> dialog box and by the <c>Convert</c> dialog box.
	/// It provides information used by the <c>General</c> and <c>View</c> pages of the <c>Object Properties</c> dialog box , which
	/// display information about the object's size, location, type, and name. It also allows the object to be converted using the
	/// <c>Convert</c> dialog box. The <c>View</c> page allows the object's icon to be modified from its original form, and its display
	/// aspect to be changed (iconic versus content). Optionally, you can have your implementation of this interface allow the scale of
	/// the object to be changed.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nn-oledlg-ioleuiobjinfow
	[PInvokeData("oledlg.h", MSDNShortId = "NN:oledlg.IOleUIObjInfoW")]
	public interface IOleUIObjInfo
	{
		/// <summary>Converts the object to the type of the specified CLSID.</summary>
		/// <param name="dwObject">A unique identifier for the object.</param>
		/// <param name="clsidNew">The CLSID.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>Insufficient access permissions.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified identifier is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Your implementation of <c>IOleUIObjInfo::ConvertObject</c> needs to convert the object to the CLSID specified. The actions
		/// taken by the convert operation are similar to the actions taken after calling OleUIConvert.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-ioleuiobjinfoa-convertobject HRESULT ConvertObject( DWORD
		// dwObject, REFCLSID clsidNew );
		[PreserveSig]
		HRESULT ConvertObject(uint dwObject, in Guid clsidNew);

		/// <summary>Gets the conversion information associated with the specified object.</summary>
		/// <param name="dwObject">Unique identifier for the object.</param>
		/// <param name="lpClassID">Pointer to the location to return the object's CLSID.</param>
		/// <param name="lpwFormat">Pointer to the clipboard format of the object.</param>
		/// <param name="lpConvertDefaultClassID">Pointer to the default class, selected from the UI, to convert the object to.</param>
		/// <param name="lplpClsidExclude">
		/// Address of a pointer variable that receives a pointer to an array of CLSIDs that should be excluded from the user interface
		/// for this object. If lpcClsidExclude is zero, then lpClsidExclude is set to <c>NULL</c>.
		/// </param>
		/// <param name="lpcClsidExclude">
		/// Address of an output variable that receives the number of CLSIDs in lplpClsidExclude. This parameter may be zero.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>Insufficient access permissions.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified identifier is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// You must fill in the CLSID of the object at a minimum. lpwFormat may be left at zero if the format of the storage is unknown.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-ioleuiobjinfoa-getconvertinfo HRESULT GetConvertInfo(
		// DWORD dwObject, CLSID *lpClassID, WORD *lpwFormat, CLSID *lpConvertDefaultClassID, LPCLSID *lplpClsidExclude, UINT
		// *lpcClsidExclude );
		[PreserveSig]
		HRESULT GetConvertInfo(uint dwObject, out Guid lpClassID, out ushort lpwFormat, out Guid lpConvertDefaultClassID,
			out IntPtr lplpClsidExclude, out uint lpcClsidExclude);

		/// <summary>Gets the size, type, name, and location information for an object.</summary>
		/// <param name="dwObject">Unique identifier for the object.</param>
		/// <param name="lpdwObjSize">Pointer to the object's size, in bytes, on disk. This may be an approximate value.</param>
		/// <param name="lplpszLabel">
		/// Address of a pointer variable that receives a pointer to the object's label string. This parameter may be <c>NULL</c> to
		/// indicate that the implementation should not return the label string.
		/// </param>
		/// <param name="lplpszType">
		/// Address of a pointer variable that receives a pointer to the object's long type string. This parameter may be <c>NULL</c> to
		/// indicate that the implementation should not return the long type string.
		/// </param>
		/// <param name="lplpszShortType">
		/// Address of a pointer variable that receives a pointer to the object's short type string. This parameter may be <c>NULL</c>
		/// to indicate that the implementation should not return the short type string.
		/// </param>
		/// <param name="lplpszLocation">
		/// Address of a pointer variable that receives a pointer to the object's source location string. This parameter may be
		/// <c>NULL</c> to indicate that the implementation should not return the location string.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified identifier is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The strings and the object's size are displayed in the object properties <c>General</c> page.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Your implementation of <c>GetObjectInfo</c> should place each of the object's attributes in the out parameters provided. Set
		/// lpdwObjSize to (DWORD)-1 when the size of the object is unknown. Allocate all strings (the rest of the params) with the OLE
		/// task allocator obtained via CoGetMalloc, as is standard for all OLE interfaces with [out] string parameters, or you can
		/// simply use CoTaskMemAlloc.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-ioleuiobjinfoa-getobjectinfo HRESULT GetObjectInfo( DWORD
		// dwObject, DWORD *lpdwObjSize, LPSTR *lplpszLabel, LPSTR *lplpszType, LPSTR *lplpszShortType, LPSTR *lplpszLocation );
		[PreserveSig]
		HRESULT GetObjectInfo(uint dwObject, out uint lpdwObjSize, [MarshalAs(UnmanagedType.LPStr)] out string lplpszLabel,
			[MarshalAs(UnmanagedType.LPStr)] out string lplpszType, [MarshalAs(UnmanagedType.LPStr)] out string lplpszShortType,
			[MarshalAs(UnmanagedType.LPStr)] out string lplpszLocation);

		/// <summary>Gets the view information associated with the object.</summary>
		/// <param name="dwObject">Unique identifier for the object.</param>
		/// <param name="phMetaPict">
		/// Pointer to the object's current icon. This parameter can be <c>NULL</c>, indicating that the caller is not interested in the
		/// object's current presentation.
		/// </param>
		/// <param name="pdvAspect">
		/// Pointer to the object's current aspect. This parameter can be <c>NULL</c>, indicating that the caller is not interested in
		/// the object's current aspect, for example, DVASPECT_ICONIC or DVASPECT_CONTENT.
		/// </param>
		/// <param name="pnCurrentScale">
		/// Pointer to the object's current scale. This parameter can be <c>NULL</c>, indicating that the caller is not interested in
		/// the current scaling factor applied to the object in the container's view.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>Insufficient access permissions.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified identifier is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>You must fill in the object's current icon, aspect, and scale.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-ioleuiobjinfoa-getviewinfo HRESULT GetViewInfo( DWORD
		// dwObject, HGLOBAL *phMetaPict, DWORD *pdvAspect, int *pnCurrentScale );
		[PreserveSig]
		HRESULT GetViewInfo(uint dwObject, [In, Optional] IntPtr phMetaPict, [In, Optional] IntPtr pdvAspect, [In, Optional] IntPtr pnCurrentScale);

		/// <summary>Sets the view information associated with the object.</summary>
		/// <param name="dwObject">Unique identifier for the object.</param>
		/// <param name="hMetaPict">The new icon.</param>
		/// <param name="dvAspect">The new display aspect or view.</param>
		/// <param name="nCurrentScale">The new scale.</param>
		/// <param name="bRelativeToOrig">
		/// The new scale of the object, relative to the origin. This value is <c>TRUE</c> if the scale should be relative to the
		/// original scale of the object. If <c>FALSE</c>, nCurrentScale applies to the object's current size.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>Insufficient access permissions.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified identifier is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// You should apply the new attributes (icon, aspect, and scale) to the object. If bRelativeToOrig is set to <c>TRUE</c>,
		/// nCurrentScale (in percentage units) applies to the original size of the object before it was scaled. If bRelativeToOrig is
		/// <c>FALSE</c>, nCurrentScale applies to the object's current size.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-ioleuiobjinfoa-setviewinfo HRESULT SetViewInfo( DWORD
		// dwObject, HGLOBAL hMetaPict, DWORD dvAspect, int nCurrentScale, BOOL bRelativeToOrig );
		[PreserveSig]
		HRESULT SetViewInfo(uint dwObject, HGLOBAL hMetaPict, DVASPECT dvAspect, int nCurrentScale,
			[MarshalAs(UnmanagedType.Bool)] bool bRelativeToOrig);
	}

	/// <summary>Adds the <c>Verb</c> menu for the specified object to the specified menu.</summary>
	/// <param name="lpOleObj">
	/// Pointer to the IOleObject interface on the selected object. If this is <c>NULL</c>, then a default disabled menu item is created.
	/// </param>
	/// <param name="lpszShortType">
	/// Pointer to the short name defined in the registry (AuxName==2) for the object identified with lpOleObj. If the string is not
	/// known, then <c>NULL</c> may be passed. If <c>NULL</c> is passed, IOleObject::GetUserType is called to retrieve it. If the caller
	/// has easy access to the string, it is faster to pass it in.
	/// </param>
	/// <param name="hMenu">Handle to the menu in which to make modifications.</param>
	/// <param name="uPos">Position of the menu item.</param>
	/// <param name="uIDVerbMin">The identifier value at which to start the verbs.</param>
	/// <param name="uIDVerbMax">
	/// The maximum identifier value to be used for object verbs. If uIDVerbMax is 0, then no maximum identifier value is used.
	/// </param>
	/// <param name="bAddConvert">Indicates whether to add a <c>Convert</c> item to the bottom of the menu (preceded by a separator).</param>
	/// <param name="idConvert">The identifier value to use for the <c>Convert</c> menu item, if bAddConvert is <c>TRUE</c>.</param>
	/// <param name="lphMenu">
	/// An <c>HMENU</c> pointer to the cascading verb menu if it's created. If there is only one verb, this will be filled with <c>NULL</c>.
	/// </param>
	/// <returns>
	/// This function returns <c>TRUE</c> if lpOleObj was valid and at least one verb was added to the menu. A <c>FALSE</c> return
	/// indicates that lpOleObj was <c>NULL</c> and a disabled default menu item was created.
	/// </returns>
	/// <remarks>If the object has one verb, the verb is added directly to the given menu.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-oleuiaddverbmenua BOOL OleUIAddVerbMenuA( LPOLEOBJECT
	// lpOleObj, LPCSTR lpszShortType, HMENU hMenu, UINT uPos, UINT uIDVerbMin, UINT uIDVerbMax, BOOL bAddConvert, UINT idConvert, HMENU
	// *lphMenu );
	[DllImport(Lib_OleDlg, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("oledlg.h", MSDNShortId = "NF:oledlg.OleUIAddVerbMenuA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OleUIAddVerbMenu(IOleObject lpOleObj, [MarshalAs(UnmanagedType.LPTStr)] string lpszShortType, HMENU hMenu, uint uPos, uint uIDVerbMin, uint uIDVerbMax,
		[MarshalAs(UnmanagedType.Bool)] bool bAddConvert, uint idConvert, out HMENU lphMenu);

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
	/// Determines if there are any OLE object classes in the registry that can be used to convert or activate the specified CLSID from.
	/// </summary>
	/// <param name="rClsid">The CLSID of the class for which the information is required.</param>
	/// <param name="fIsLinkedObject"><c>TRUE</c> if the original object is a linked object; <c>FALSE</c> otherwise.</param>
	/// <param name="wFormat">Format of the original class.</param>
	/// <returns>This function returns <c>TRUE</c> if the specified class can be converted to another class; <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// <c>OleUICanConvertOrActivateAs</c> searches the registry for classes that include wFormat in their \Conversion\Readable\Main,
	/// \Conversion\ReadWriteable\Main, and \DataFormats\DefaultFile entries.
	/// </para>
	/// <para>
	/// This function is useful for determining if a <c>Convert...</c> menu item should be disabled. If the CF_DISABLEDISPLAYASICON flag
	/// is specified in the call to OleUIConvert, then the <c>Convert...</c> menu item should be enabled only if
	/// <c>OleUICanConvertOrActivateAs</c> returns <c>TRUE</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-oleuicanconvertoractivateas BOOL OleUICanConvertOrActivateAs(
	// REFCLSID rClsid, BOOL fIsLinkedObject, WORD wFormat );
	[DllImport(Lib_OleDlg, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oledlg.h", MSDNShortId = "NF:oledlg.OleUICanConvertOrActivateAs")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OleUICanConvertOrActivateAs(in Guid rClsid, [MarshalAs(UnmanagedType.Bool)] bool fIsLinkedObject, ushort wFormat);

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
	/// Invokes the standard <c>Convert</c> dialog box, allowing the user to change the type of a single specified object, or the type
	/// of all OLE objects of the specified object's class.
	/// </summary>
	/// <param name="Arg1">Pointer to an OLEUICONVERT structure that contains information used to initialize the dialog box.</param>
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
	/// <term>OLEUI_CTERR_CLASSIDINVALID</term>
	/// <term>A clsid value was invalid.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_CTERR_DVASPECTINVALID</term>
	/// <term>The dvAspect value was invalid. This member specifies the aspect of the object.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_CTERR_CBFORMATINVALID</term>
	/// <term>The wFormat value was invalid. This member specifies the data format of the object.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_CTERR_STRINGINVALID</term>
	/// <term>A string value (for example, lpszUserType or lpszDefLabel) was invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>OleUIConvert</c> populates the <c>Convert</c> dialog box's list box with object classes by traversing the registry and
	/// looking for entries in the Readable and ReadWritable keys. Every class that includes the original class' default file format in
	/// its Readable key is added to the Convert list, and every class that includes the original class' default file format in its
	/// ReadWritable key is added to the Activate As list. The Convert list is shown in the dialog box's list box when the
	/// <c>Convert</c> radio button is selected (the default selection), and the Activate As list is shown when <c>Activate As</c> is selected.
	/// </para>
	/// <para>Note that you can change the type of all objects of a given class only when CF_CONVERTONLY is not specified.</para>
	/// <para>
	/// The convert command, which invokes this function, should only be made available to the user if OleUICanConvertOrActivateAs
	/// returns S_OK.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-oleuiconverta UINT OleUIConvertA( LPOLEUICONVERTA Arg1 );
	[DllImport(Lib_OleDlg, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("oledlg.h", MSDNShortId = "NF:oledlg.OleUIConvertA")]
	public static extern uint OleUIConvert(in OLEUICONVERT Arg1);

	/// <summary>Invokes the standard <c>Links</c> dialog box, allowing the user to make modifications to a container's linked objects.</summary>
	/// <param name="Arg1">Pointer to an OLEUIEDITLINKS structure that contains information used to initialize the dialog box.</param>
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
	/// </list>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-oleuieditlinksa UINT OleUIEditLinksA( LPOLEUIEDITLINKSA Arg1 );
	[DllImport(Lib_OleDlg, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("oledlg.h", MSDNShortId = "NF:oledlg.OleUIEditLinksA")]
	public static extern uint OleUIEditLinks(in OLEUIEDITLINKS Arg1);

	/// <summary>
	/// Invokes the standard <c>Insert Object</c> dialog box, which allows the user to select an object source and class name, as well
	/// as the option of displaying the object as itself or as an icon.
	/// </summary>
	/// <param name="Arg1">Pointer to the in-out OLEUIINSERTOBJECT structure for this dialog box.</param>
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
	/// <term>OLEUI_IOERR_LPSZFILEINVALID</term>
	/// <term>
	/// The lpszFile value is invalid or user has insufficient write access permissions.This lpszFile member points to the name of the
	/// file linked to or inserted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OLEUI_IOERR_PPVOBJINVALID</term>
	/// <term>The ppvOjb value is invalid. This member points to the location where the pointer for the object is returned.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_IOERR_LPIOLECLIENTSITEINVALID</term>
	/// <term>The lpIOleClientSite value is invalid. This member points to the client site for the object.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_IOERR_LPISTORAGEINVALID</term>
	/// <term>The lpIStorage value is invalid. This member points to the storage to be used for the object.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_IOERR_SCODEHASERROR</term>
	/// <term>The sc member of lpIO has additional error information.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_IOERR_LPCLSIDEXCLUDEINVALID</term>
	/// <term>The lpClsidExclude value is invalid. This member contains the list of CLSIDs to exclude.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_IOERR_CCHFILEINVALID</term>
	/// <term>
	/// The cchFile or lpszFile value is invalid. The cchFile member specifies the size of the lpszFile buffer. The lpszFile member
	/// points to the name of the file linked to or inserted.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>OleUIInsertObject</c> allows the user to select the type of object to be inserted from a list box containing the object
	/// applications registered on the user's system. To populate that list box, <c>OleUIInsertObject</c> traverses the registry, adding
	/// every object server it finds that meets the following criteria:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The registry entry does not include the NotInsertable key.</term>
	/// </item>
	/// <item>
	/// <term>The registry entry includes an OLE 1.0 style Protocol\\StdFileEditing\\Server key.</term>
	/// </item>
	/// <item>
	/// <term>The registry entry includes the Insertable key.</term>
	/// </item>
	/// <item>
	/// <term>The object's CLSID is not included in the list of objects to exclude (the <c>lpClsidExclude</c> member of OLEUIINSERTOBJECT).</term>
	/// </item>
	/// </list>
	/// <para>
	/// By default, <c>OleUIInsertObject</c> does not validate object servers, however, if the IOF_VERIFYSERVEREXIST flag is included in
	/// the dwFlags member of the OLEUIINSERTOBJECT structure, <c>OleUIInsertObject</c> verifies that the server exists. If it does not
	/// exist, then the server's object is not added to the list of available objects. Server validation is a time-extensive operation
	/// and is a significant performance factor.
	/// </para>
	/// <para>
	/// To free an <c>HMETAFILEPICT</c> returned from the <c>Insert Object</c> or <c>Paste Special</c> dialog box, delete the attached
	/// metafile on the handle, as follows:
	/// </para>
	/// <para>
	/// <code>void FreeHmetafilepict(HMETAFILEPICT hmfp) { if (hmfp != NULL) { LPMETAFILEPICT pmfp = GlobalLock(hmfp); DeleteMetaFile(pmfp-&gt;hMF); GlobalUnlock(hmfp); GlobalFree(hmfp); } else { // Handle null pointers here. exit(0); } }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-oleuiinsertobjecta UINT OleUIInsertObjectA(
	// LPOLEUIINSERTOBJECTA Arg1 );
	[DllImport(Lib_OleDlg, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("oledlg.h", MSDNShortId = "NF:oledlg.OleUIInsertObjectA")]
	public static extern uint OleUIInsertObject(ref OLEUIINSERTOBJECT Arg1);

	/// <summary>
	/// Invokes the <c>Object Properties</c> dialog box, which displays <c>General</c>, <c>View</c>, and <c>Link</c> information about
	/// an object.
	/// </summary>
	/// <param name="Arg1">Pointer to the OLEUIOBJECTPROPS structure.</param>
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
	/// <term>OLEUI_OPERR_SUBPROPNULL</term>
	/// <term>lpGP or lpVP is NULL, or dwFlags and OPF_OBJECTISLINK and lpLP are NULL.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_OPERR_SUBPROPINVALID</term>
	/// <term>Insufficient write-access permissions for the structures pointed to by lpGP, lpVP, or lpLP.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_OPERR_PROPSHEETNULL</term>
	/// <term>The lpLP value is NULL.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_OPERR_PROPSHEETINVALID</term>
	/// <term>Insufficient write-access permissions for the structures pointed to by lpGP, lpVP, or lpLP.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_OPERR_SUPPROP</term>
	/// <term>The sub-link property pointer, lpLP, is NULL.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_OPERR_PROPSINVALID</term>
	/// <term>Insufficient write access for the sub-link property pointer, lpLP.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_OPERR_PAGESINCORRECT</term>
	/// <term>Some sub-link properties of the lpPS member are incorrect.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_OPERR_INVALIDPAGES</term>
	/// <term>Some sub-link properties of the lpPS member are incorrect.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_OPERR_NOTSUPPORTED</term>
	/// <term>A sub-link property of the lpPS member is incorrect.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_OPERR_DLGPROCNOTNULL</term>
	/// <term>A sub-link property of the lpPS member is incorrect.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_OPERR_LPARAMNOTZERO</term>
	/// <term>A sub-link property of the lpPS member is incorrect.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_GPERR_STRINGINVALID</term>
	/// <term>A string value (for example, lplpszLabel or lplpszType) is invalid.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_GPERR_CLASSIDINVALID</term>
	/// <term>The clsid value is invalid.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_GPERR_LPCLSIDEXCLUDEINVALID</term>
	/// <term>The ClsidExcluded value is invalid.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_GPERR_CBFORMATINVALID</term>
	/// <term>The wFormat value is invalid.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_VPERR_METAPICTINVALID</term>
	/// <term>The hMetaPict value is invalid.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_VPERR_DVASPECTINVALID</term>
	/// <term>The dvAspect value is invalid.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_OPERR_PROPERTYSHEET</term>
	/// <term>The lpPS value is incorrect.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_OPERR_OBJINFOINVALID</term>
	/// <term>The lpObjInfo value is NULL or the calling process doesn't have read access.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_OPERR_LINKINFOINVALID</term>
	/// <term>The lpLinkInfo value is NULL or the calling process doesn't have read access.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <c>OleUIObjectProperties</c> is passed an OLEUIOBJECTPROPS structure, which supplies the information needed to fill in the
	/// <c>General</c>, <c>View</c>, and <c>Link</c> tabs of the <c>Object Properties</c> dialog box.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-oleuiobjectpropertiesa UINT OleUIObjectPropertiesA(
	// LPOLEUIOBJECTPROPSA Arg1 );
	[DllImport(Lib_OleDlg, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("oledlg.h", MSDNShortId = "NF:oledlg.OleUIObjectPropertiesA")]
	public static extern uint OleUIObjectProperties(ref OLEUIOBJECTPROPS Arg1);

	/// <summary>
	/// Invokes the standard <c>Paste Special</c> dialog box, allowing the user to select the format of the clipboard object to be
	/// pasted or paste-linked.
	/// </summary>
	/// <param name="Arg1">A pointer to an OLEUIPASTESPECIAL structure.</param>
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
	/// <term>Unable to call LoadString to get localized resources from the library.</term>
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
	/// <term>OLEUI_IOERR_SRCDATAOBJECTINVALID</term>
	/// <term>The lpSrcDataObject member of OLEUIPASTESPECIAL is invalid.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_IOERR_ARRPASTEENTRIESINVALID</term>
	/// <term>The arrPasteEntries member of OLEUIPASTESPECIAL is invalid.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_IOERR_ARRLINKTYPESINVALID</term>
	/// <term>The arrLinkTypes member of OLEUIPASTESPECIAL is invalid.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_PSERR_CLIPBOARDCHANGED</term>
	/// <term>The clipboard contents changed while the dialog box was displayed.</term>
	/// </item>
	/// <item>
	/// <term>OLEUI_PSERR_GETCLIPBOAARDFAILED</term>
	/// <term>The lpSrcDataObj member is incorrect.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The design of the <c>Paste Special</c> dialog box assumes that if you are willing to permit a user to link to an object, you are
	/// also willing to permit the user to embed that object. For this reason, if any of the OLEUIPASTE_LINKTYPE flags associated with
	/// the OLEUIPASTEFLAG enumeration are set, then the OLEUIPASTE_PASTE flag must also be set in order for the data formats to appear
	/// in the <c>Paste Special</c> dialog box.
	/// </para>
	/// <para>
	/// The text displayed in the <c>Source</c> field of the standard <c>Paste Special</c> dialog box, which is implemented in
	/// Oledlg32.dll, is the null-terminated string whose offset in bytes is specified in the <c>dwSrcofCopy</c> member of the
	/// OBJECTDESCRIPTOR structure for the object to be pasted. If an <c>OBJECTDESCRIPTOR</c> structure is not available for this
	/// object, the dialog box displays whatever text may be associated with CF_LINKSOURCEDESCRIPTOR. If neither structure is available,
	/// the dialog box looks for CF_FILENAME. If CF_FILENAME is not found, the dialog box displays the string "Unknown Source".
	/// </para>
	/// <para>
	/// To free an <c>HMETAFILEPICT</c> returned from the <c>Insert Object</c> or <c>Paste Special</c> dialog box, delete the attached
	/// metafile on the handle, as follows.
	/// </para>
	/// <para>
	/// <code> void FreeHmetafilepict(HMETAFILEPICT hmfp) { if (hmfp != NULL) { LPMETAFILEPICT pmfp = GlobalLock(hmfp); DeleteMetaFile(pmfp-&gt;hMF); GlobalUnlock(hmfp); GlobalFree(hmfp); } else { // Handle null pointers here. exit(0); } } // FreeHmetafilepict</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-oleuipastespeciala UINT OleUIPasteSpecialA(
	// LPOLEUIPASTESPECIALA Arg1 );
	[DllImport(Lib_OleDlg, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("oledlg.h", MSDNShortId = "NF:oledlg.OleUIPasteSpecialA")]
	public static extern uint OleUIPasteSpecial(ref OLEUIPASTESPECIAL Arg1);

	/// <summary>
	/// Displays a dialog box with the specified template and returns the response (button identifier) from the user. This function is
	/// used to display OLE warning messages, for example, Class Not Registered.
	/// </summary>
	/// <param name="nTemplate">The resource number of the dialog box to be displayed. See Remarks.</param>
	/// <param name="hwndParent">The handle to the parent window of the dialog box.</param>
	/// <param name="args">
	/// Optional. The title of the dialog box followed by a list of arguments for the format string in the static control (IDC_PU_TEXT)
	/// of the dialog box. The caller must be sure to pass the correct number and types of arguments.
	/// </param>
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
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The following dialog box templates are defined in Windows Interface Guidelines--A Guide for Designing Software. The nTemplate
	/// parameter must be a currently defined resource, however, additional templates can be added to prompt.dlg.
	/// </para>
	/// <para>
	/// <code>IDD_LINKSOURCEUNAVAILABLE IDD_CANNOTUPDATELINK IDD_SERVERNOTREG IDD_CANNOTRESPONDVERB IDD_SERVERNOTFOUND</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-oleuipromptusera int OleUIPromptUserA( int nTemplate, HWND
	// hwndParent, ... );
	[DllImport(Lib_OleDlg, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("oledlg.h", MSDNShortId = "NF:oledlg.OleUIPromptUserA")]
	public static extern int OleUIPromptUser(int nTemplate, HWND hwndParent, IntPtr args);

	/// <summary>
	/// Updates all links in the link container and displays a dialog box that shows the progress of the updating process. The process
	/// is stopped if the user presses the <c>Stop</c> button or when all links are processed.
	/// </summary>
	/// <param name="lpOleUILinkCntr">Pointer to the IOleUILinkContainer interface on the link container.</param>
	/// <param name="hwndParent">Parent window of the dialog box.</param>
	/// <param name="lpszTitle">Pointer to the title of the dialog box.</param>
	/// <param name="cLinks">Total number of links.</param>
	/// <returns>Returns <c>TRUE</c> if the links were successfully updated; otherwise, <c>FALSE</c>.</returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-oleuiupdatelinksa BOOL OleUIUpdateLinksA(
	// LPOLEUILINKCONTAINERA lpOleUILinkCntr, HWND hwndParent, LPSTR lpszTitle, int cLinks );
	[DllImport(Lib_OleDlg, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("oledlg.h", MSDNShortId = "NF:oledlg.OleUIUpdateLinksA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OleUIUpdateLinks(IOleUILinkContainer lpOleUILinkCntr, HWND hwndParent, [MarshalAs(UnmanagedType.LPTStr)] string lpszTitle,
		int cLinks);

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

	/// <summary>
	/// Contains information that the OLE User Interface Library uses to initialize the <c>Convert</c> dialog box, and space for the
	/// library to return information when the dialog box is dismissed.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/ns-oledlg-oleuiconverta typedef struct tagOLEUICONVERTA { DWORD
	// cbStruct; DWORD dwFlags; HWND hWndOwner; LPCSTR lpszCaption; LPFNOLEUIHOOK lpfnHook; LPARAM lCustData; HINSTANCE hInstance;
	// LPCSTR lpszTemplate; HRSRC hResource; CLSID clsid; CLSID clsidConvertDefault; CLSID clsidActivateDefault; CLSID clsidNew; DWORD
	// dvAspect; WORD wFormat; BOOL fIsLinkedObject; HGLOBAL hMetaPict; LPSTR lpszUserType; BOOL fObjectsIconChanged; LPSTR
	// lpszDefLabel; UINT cClsidExclude; LPCLSID lpClsidExclude; } OLEUICONVERTA, *POLEUICONVERTA, *LPOLEUICONVERTA;
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUICONVERTA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OLEUICONVERT
	{
		/// <summary>The size of the structure, in bytes. This member must be filled on input.</summary>
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
		/// <term>CF_SHOWHELPBUTTON</term>
		/// <term>Dialog box will display a Help button. This flag is set on input.</term>
		/// </item>
		/// <item>
		/// <term>CF_SETCONVERTDEFAULT</term>
		/// <term>
		/// Class whose CLSID is specified by clsidConvertDefault will be used as the default selection. This selection appears in the
		/// class listbox when the Convert To radio button is selected. This flag is set on input.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_SETACTIVATEDEFAULT</term>
		/// <term>
		/// Class whose CLSID is specified by clsidActivateDefault will be used as the default selection. This selection appears in the
		/// class listbox when the Activate As radio button is selected. This flag is set on input.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_SELECTCONVERTTO</term>
		/// <term>
		/// On input, this flag specifies that Convert To will be initially selected (default behavior). This flag is set on output if
		/// Convert To was selected when the user dismissed the dialog box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_SELECTACTIVATEAS</term>
		/// <term>
		/// On input, this flag specifies that Activate As will be initially selected. This flag is set on output if Activate As was
		/// selected when the user dismissed the dialog box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_DISABLEDISPLAYASICON</term>
		/// <term>The Display As Icon button will be disabled on initialization.</term>
		/// </item>
		/// <item>
		/// <term>CF_DISABLEACTIVATEAS</term>
		/// <term>The Activate As radio button will be disabled on initialization.</term>
		/// </item>
		/// <item>
		/// <term>CF_HIDECHANGEICON</term>
		/// <term>The Change Icon button will be hidden in the Convert dialog box.</term>
		/// </item>
		/// <item>
		/// <term>CF_CONVERTONLY</term>
		/// <term>The Activate As radio button will be disabled in the Convert dialog box.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CF dwFlags;

		/// <summary>The window that owns the dialog box. This member should not be <c>NULL</c>.</summary>
		public HWND hWndOwner;

		/// <summary>Pointer to a string to be used as the title of the dialog box. If <c>NULL</c>, then the library uses <c>Convert</c>.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszCaption;

		/// <summary>
		/// Pointer to a hook function that processes messages intended for the dialog box. The hook function must return zero to pass a
		/// message that it didn't process back to the dialog box procedure in the library. The hook function must return a nonzero
		/// value to prevent the library's dialog box procedure from processing a message it has already processed.
		/// </summary>
		public LPFNOLEUIHOOK lpfnHook;

		/// <summary>
		/// Application-defined data that the library passes to the hook function pointed to by the <c>lpfnHook</c> member. The library
		/// passes a pointer to the <c>OLEUICONVERT</c> structure in the lParam parameter of the WM_INITDIALOG message; this pointer can
		/// be used to retrieve the <c>lCustData</c> member.
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

		/// <summary>The CLSID of the object to be converted or activated. This member is set on input.</summary>
		public Guid clsid;

		/// <summary>
		/// The CLSID to use as the default class when <c>Convert To</c> is selected. This member is ignored if the <c>dwFlags</c>
		/// member does not include CF_SETCONVERTDEFAULT. This member is set on input.
		/// </summary>
		public Guid clsidConvertDefault;

		/// <summary>
		/// The CLSID to use as the default class when <c>Activate As</c> is selected. This member is ignored if the <c>dwFlags</c>
		/// member does not include CF_SETACTIVATEDEFAULT. This member is set on input.
		/// </summary>
		public Guid clsidActivateDefault;

		/// <summary>The CLSID of the selected class. This member is set on output.</summary>
		public Guid clsidNew;

		/// <summary>
		/// Aspect of the object. This must be either DVASPECT_CONTENT or DVASPECT_ICON. If <c>dvAspect</c> is DVASPECT_ICON on input,
		/// then the <c>Display As Icon</c> box is checked and the object's icon is displayed. This member is set on input and output.
		/// For more information, see DVASPECT.
		/// </summary>
		public DVASPECT dvAspect;

		/// <summary>Data format of the object to be converted or activated.</summary>
		public ushort wFormat;

		/// <summary><c>TRUE</c> if the object is linked. This member is set on input.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fIsLinkedObject;

		/// <summary>The METAFILEPICT containing the iconic aspect. This member is set on input and output.</summary>
		public HGLOBAL hMetaPict;

		/// <summary>
		/// Pointer to the User Type name of the object to be converted or activated. If this value is <c>NULL</c>, then the dialog box
		/// will retrieve the User Type name from the registry. This string is freed on exit.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszUserType;

		/// <summary>
		/// <c>TRUE</c> if the object's icon changed. (that is, if OleUIChangeIcon was called and not canceled.). This member is set on output.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fObjectsIconChanged;

		/// <summary>
		/// Pointer to the default label to use for the icon. If <c>NULL</c>, the short user type name will be used. If the object is a
		/// link, the caller should pass the display name of the link source. This is freed on exit.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszDefLabel;

		/// <summary>Number of CLSIDs in lpClsidExclude.</summary>
		public uint cClsidExclude;

		/// <summary>Pointer to the list of CLSIDs to exclude from the list.</summary>
		public IntPtr lpClsidExclude;
	}

	/// <summary>
	/// Contains information that the OLE User Interface Library uses to initialize the <c>Edit Links</c> dialog box, and contains space
	/// for the library to return information when the dialog box is dismissed.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/ns-oledlg-oleuieditlinksa typedef struct tagOLEUIEDITLINKSA { DWORD
	// cbStruct; DWORD dwFlags; HWND hWndOwner; LPCSTR lpszCaption; LPFNOLEUIHOOK lpfnHook; LPARAM lCustData; HINSTANCE hInstance;
	// LPCSTR lpszTemplate; HRSRC hResource; LPOLEUILINKCONTAINERA lpOleUILinkContainer; } OLEUIEDITLINKSA, *POLEUIEDITLINKSA, *LPOLEUIEDITLINKSA;
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUIEDITLINKSA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OLEUIEDITLINKS
	{
		/// <summary>The size of the structure, in bytes. This member must be filled on input.</summary>
		public uint cbStruct;

		/// <summary>
		/// <para>
		/// On input, <c>dwFlags</c> specifies the initialization and creation flags. It may be a combination of the following flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ELF_SHOWHELP</term>
		/// <term>Specifies that the dialog box will display a Help button.</term>
		/// </item>
		/// <item>
		/// <term>ELF_DISABLEUPDATENOW</term>
		/// <term>Specifies that the Update Now button will be disabled on initialization.</term>
		/// </item>
		/// <item>
		/// <term>ELF_DISABLEOPENSOURCE</term>
		/// <term>Specifies that the Open Source button will be disabled on initialization.</term>
		/// </item>
		/// <item>
		/// <term>ELF_DISABLECHANGESOURCE</term>
		/// <term>Specifies that the Change Source button will be disabled on initialization.</term>
		/// </item>
		/// <item>
		/// <term>ELF_DISABLECANCELLINK</term>
		/// <term>Specifies that the Cancel Link button will be disabled on initialization.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ELF dwFlags;

		/// <summary>The window that owns the dialog box. This member should not be <c>NULL</c>.</summary>
		public HWND hWndOwner;

		/// <summary>Pointer to a string to be used as the title of the dialog box. If <c>NULL</c>, then the library uses <c>Links</c>.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszCaption;

		/// <summary>
		/// Pointer to a hook function that processes messages intended for the dialog box. The hook function must return zero to pass a
		/// message that it didn't process back to the dialog box procedure in the library. The hook function must return a nonzero
		/// value to prevent the library's dialog box procedure from processing a message it has already processed.
		/// </summary>
		public LPFNOLEUIHOOK lpfnHook;

		/// <summary>
		/// Application-defined data that the library passes to the hook function pointed to by the <c>lpfnHook</c> member. The library
		/// passes a pointer to the <c>OLEUIEDITLINKS</c> structure in the lParam parameter of the WM_INITDIALOG message; this pointer
		/// can be used to retrieve the <c>lCustData</c> member.
		/// </summary>
		public IntPtr lCustData;

		/// <summary>Instance that contains a dialog box template specified by the <c>lpTemplateName</c> member.</summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the resource file for the dialog box template that is to be
		/// substituted for the library's <c>Edit Links</c> dialog box template.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszTemplate;

		/// <summary>Customized template handle.</summary>
		public HRSRC hResource;

		/// <summary>
		/// Pointer to the container's implementation of the IOleUILinkContainer Interface. The <c>Edit Links</c> dialog box uses this
		/// to allow the container to manipulate its links.
		/// </summary>
		public IOleUILinkContainer lpOleUILinkContainer;
	}

	/// <summary>
	/// Initializes the <c>General</c> tab of the <c>Object Properties</c> dialog box. A reference to it is passed in as part of the
	/// OLEUIOBJECTPROPS structure to the OleUIObjectProperties function. This tab shows the type and size of an OLE embedding and
	/// allows it the user to tunnel to the <c>Convert</c> dialog box. This tab also shows the link destination if the object is a link.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/ns-oledlg-oleuignrlpropsa typedef struct tagOLEUIGNRLPROPSA { DWORD
	// cbStruct; DWORD dwFlags; DWORD dwReserved1[2]; LPFNOLEUIHOOK lpfnHook; LPARAM lCustData; DWORD dwReserved2[3]; struct
	// tagOLEUIOBJECTPROPSA *lpOP; } OLEUIGNRLPROPSA, *POLEUIGNRLPROPSA, *LPOLEUIGNRLPROPSA;
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUIGNRLPROPSA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OLEUIGNRLPROPS
	{
		/// <summary>The size of the structure, in bytes. This field must be filled on input.</summary>
		public uint cbStruct;

		/// <summary>Currently no flags associated with this member. It should be set to 0 (zero).</summary>
		public uint dwFlags;

		/// <summary>This member is reserved.</summary>
		public ulong dwReserved1;

		/// <summary>
		/// Pointer to a hook function that processes messages intended for the dialog box. The hook function must return zero to pass a
		/// message that it didn't process back to the dialog box procedure in the library. The hook function must return a nonzero
		/// value to prevent the library's dialog box procedure from processing a message it has already processed.
		/// </summary>
		public LPFNOLEUIHOOK lpfnHook;

		/// <summary>
		/// Application-defined data that the library passes to the hook function pointed to by the <c>lpfnHook</c> member during WM_INITDIALOG.
		/// </summary>
		public IntPtr lCustData;

		/// <summary>This member is reserved.</summary>
		public uint dwReserved2_1;

		/// <summary>This member is reserved.</summary>
		public uint dwReserved2_2;

		/// <summary>This member is reserved.</summary>
		public uint dwReserved2_3;

		/// <summary>Used internally.</summary>
		public IntPtr lpOP;
	}

	/// <summary>
	/// Contains information that the OLE User Interface Library uses to initialize the <c>Insert Object</c> dialog box, and space for
	/// the library to return information when the dialog box is dismissed.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/ns-oledlg-oleuiinsertobjecta typedef struct tagOLEUIINSERTOBJECTA {
	// DWORD cbStruct; DWORD dwFlags; HWND hWndOwner; LPCSTR lpszCaption; LPFNOLEUIHOOK lpfnHook; LPARAM lCustData; HINSTANCE hInstance;
	// LPCSTR lpszTemplate; HRSRC hResource; CLSID clsid; LPSTR lpszFile; UINT cchFile; UINT cClsidExclude; LPCLSID lpClsidExclude; IID
	// iid; DWORD oleRender; LPFORMATETC lpFormatEtc; LPOLECLIENTSITE lpIOleClientSite; LPSTORAGE lpIStorage; LPVOID *ppvObj; SCODE sc;
	// HGLOBAL hMetaPict; } OLEUIINSERTOBJECTA, *POLEUIINSERTOBJECTA, *LPOLEUIINSERTOBJECTA;
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUIINSERTOBJECTA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OLEUIINSERTOBJECT
	{
		/// <summary>The size of the structure, in bytes. This field must be filled on input.</summary>
		public uint cbStruct;

		/// <summary>
		/// <para>
		/// On input, specifies the initialization and creation flags. On exit, specifies the user's choices. It can be a combination of
		/// the following flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IOF_SHOWHELP</term>
		/// <term>The dialog box will display a Help button.</term>
		/// </item>
		/// <item>
		/// <term>IOF_SELECTCREATENEW</term>
		/// <term>The Create New radio button will initially be checked. This cannot be used with IOF_SELECTCREATEFROMFILE.</term>
		/// </item>
		/// <item>
		/// <term>IOF_SELECTCREATEFROMFILE</term>
		/// <term>The Create From File radio button will initially be checked. This cannot be used with IOF_SELECTCREATENEW.</term>
		/// </item>
		/// <item>
		/// <term>IOF_CHECKLINK</term>
		/// <term>The Link check box will initially be checked.</term>
		/// </item>
		/// <item>
		/// <term>IOF_CHECKDISPLAYASICON</term>
		/// <term>
		/// The Display As Icon check box will initially be checked, the current icon will be displayed, and the Change Icon button will
		/// be enabled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IOF_CREATENEWOBJECT</term>
		/// <term>
		/// A new object should be created when the user selects OK to dismiss the dialog box and the Create New radio button was selected.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IOF_CREATEFILEOBJECT</term>
		/// <term>
		/// A new object should be created from the specified file when the user selects OK to dismiss the dialog box and the Create
		/// From File radio button was selected.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IOF_CREATELINKOBJECT</term>
		/// <term>
		/// A new linked object should be created when the user selects OK to dismiss the dialog box and the user checked the Link check box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IOF_DISABLELINK</term>
		/// <term>The Link check box will be disabled on initialization.</term>
		/// </item>
		/// <item>
		/// <term>IOF_VERIFYSERVERSEXIST</term>
		/// <term>
		/// The dialog box should validate the classes it adds to the listbox by ensuring that the server specified in the registration
		/// database exists. This is a significant performance factor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IOF_DISABLEDISPLAYASICON</term>
		/// <term>The Display As Icon check box will be disabled on initialization.</term>
		/// </item>
		/// <item>
		/// <term>IOF_HIDECHANGEICON</term>
		/// <term>The Change Icon button will be hidden in the Insert Object dialog box.</term>
		/// </item>
		/// <item>
		/// <term>IOF_SHOWINSERTCONTROL</term>
		/// <term>Displays the Insert Control radio button.</term>
		/// </item>
		/// <item>
		/// <term>IOF_SELECTCREATECONTROL</term>
		/// <term>Displays the Create Control radio button.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IOF dwFlags;

		/// <summary>The window that owns the dialog box. This member should not be <c>NULL</c>.</summary>
		public HWND hWndOwner;

		/// <summary>
		/// Pointer to a string to be used as the title of the dialog box. If <c>NULL</c>, then the library uses <c>Insert Object</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszCaption;

		/// <summary>
		/// Pointer to a hook function that processes messages intended for the dialog box. The hook function must return zero to pass a
		/// message that it didn't process back to the dialog box procedure in the library. The hook function must return a nonzero
		/// value to prevent the library's dialog box procedure from processing a message it has already processed.
		/// </summary>
		public LPFNOLEUIHOOK lpfnHook;

		/// <summary>
		/// Application-defined data that the library passes to the hook function pointed to by the <c>lpfnHook</c> member. The library
		/// passes a pointer to the <c>OLEUIINSERTOBJECT</c> structure in the lParam parameter of the WM_INITDIALOG message; this
		/// pointer can be used to retrieve the <c>lCustData</c> member.
		/// </summary>
		public IntPtr lCustData;

		/// <summary>Instance that contains a dialog box template specified by the <c>lpTemplateName</c> member.</summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the resource file for the dialog box template that is to be
		/// substituted for the library's <c>Insert Object</c> dialog box template.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszTemplate;

		/// <summary>Customized template handle.</summary>
		public HRSRC hResource;

		/// <summary>CLSID for class of the object to be inserted. Filled on output.</summary>
		public Guid clsid;

		/// <summary>Pointer to the name of the file to be linked or embedded. Filled on output.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszFile;

		/// <summary>Size of <c>lpszFile</c> buffer; will not exceed MAX_PATH.</summary>
		public uint cchFile;

		/// <summary>Number of CLSIDs included in the <c>lpClsidExclude</c> list. Filled on input.</summary>
		public uint cClsidExclude;

		/// <summary>Pointer to a list of CLSIDs to exclude from listing.</summary>
		public IntPtr lpClsidExclude;

		/// <summary>
		/// Identifier of the requested interface. If OleUIInsertObject creates the object, then it will return a pointer to this
		/// interface. This parameter is ignored if <c>OleUIInsertObject</c> does not create the object.
		/// </summary>
		public Guid iid;

		/// <summary>
		/// Rendering option. If OleUIInsertObject creates the object, then it selects the rendering option when it creates the object.
		/// This parameter is ignored if <c>OleUIInsertObject</c> does not create the object.
		/// </summary>
		public uint oleRender;

		/// <summary>
		/// Desired format. If OleUIInsertObject creates the object, then it selects the format when it creates the object. This
		/// parameter is ignored if <c>OleUIInsertObject</c> does not create the object.
		/// </summary>
		public IntPtr lpFormatEtc;

		/// <summary>
		/// Pointer to the client site to be used for the object. This parameter is ignored if OleUIInsertObject does not create the object.
		/// </summary>
		public IOleClientSite lpIOleClientSite;

		/// <summary>
		/// Pointer to the storage to be used for the object. This parameter is ignored if OleUIInsertObject does not create the object.
		/// </summary>
		public IStorage lpIStorage;

		/// <summary>
		/// Address of output pointer variable that contains the interface pointer for the object being inserted. This parameter is
		/// ignored if OleUIInsertObject does not create the object.
		/// </summary>
		public IntPtr ppvObj;

		/// <summary>Result of creation calls. This parameter is ignored if OleUIInsertObject does not create the object.</summary>
		public int sc;

		/// <summary>MetafilePict structure containing the iconic aspect, if it wasn't placed in the object's cache.</summary>
		public HGLOBAL hMetaPict;
	}

	/// <summary>
	/// Contains information that is used to initialize the <c>Link</c> tab of the <c>Object Properties</c> dialog box. A reference to
	/// it is passed in as part of the OLEUIOBJECTPROPS structure to the OleUIObjectProperties function. This tab shows the location,
	/// update status, and update time for a link. It allows the user to change the source of the link, toggle its update status between
	/// automatic and manual update, open the source, force an update of the link, or break the link (convert it to a static picture).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/ns-oledlg-oleuilinkpropsa typedef struct tagOLEUILINKPROPSA { DWORD
	// cbStruct; DWORD dwFlags; DWORD dwReserved1[2]; LPFNOLEUIHOOK lpfnHook; LPARAM lCustData; DWORD dwReserved2[3]; struct
	// tagOLEUIOBJECTPROPSA *lpOP; } OLEUILINKPROPSA, *POLEUILINKPROPSA, *LPOLEUILINKPROPSA;
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUILINKPROPSA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OLEUILINKPROPS
	{
		/// <summary>The size of the structure, in bytes.</summary>
		public uint cbStruct;

		/// <summary>Contains in/out flags specific to the <c>Links</c> page.</summary>
		public uint dwFlags;

		/// <summary>This member is reserved.</summary>
		public ulong dwReserved1;

		/// <summary>Pointer to the hook callback (not used in this dialog box).</summary>
		public LPFNOLEUIHOOK lpfnHook;

		/// <summary>Custom data to pass to hook (not used in this dialog box).</summary>
		public IntPtr lCustData;

		/// <summary>This member is reserved.</summary>
		public uint dwReserved2_1;

		/// <summary>This member is reserved.</summary>
		public uint dwReserved2_2;

		/// <summary>This member is reserved.</summary>
		public uint dwReserved2_3;

		/// <summary>Used internally.</summary>
		public IntPtr lpOP;
	}

	/// <summary>
	/// Contains information that is used to initialize the standard <c>Object Properties</c> dialog box. It contains references to
	/// interfaces used to gather information about the embedding or link, references to three structures that are used to initialize
	/// the default tabs - <c>General</c> (OLEUIGNRLPROPS), <c>View</c> (OLEUIVIEWPROPS), and <c>Link</c> (OLEUILINKPROPS), if
	/// appropriate - and a standard property-sheet extensibility interface that allows the caller to add additional custom property
	/// sheets to the dialog box.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/ns-oledlg-oleuiobjectpropsa typedef struct tagOLEUIOBJECTPROPSA { DWORD
	// cbStruct; DWORD dwFlags; LPPROPSHEETHEADERA lpPS; DWORD dwObject; LPOLEUIOBJINFOA lpObjInfo; DWORD dwLink; LPOLEUILINKINFOA
	// lpLinkInfo; LPOLEUIGNRLPROPSA lpGP; LPOLEUIVIEWPROPSA lpVP; LPOLEUILINKPROPSA lpLP; } OLEUIOBJECTPROPSA, *POLEUIOBJECTPROPSA, *LPOLEUIOBJECTPROPSA;
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUIOBJECTPROPSA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OLEUIOBJECTPROPS
	{
		/// <summary>The size of the structure, in bytes.</summary>
		public uint cbStruct;

		/// <summary>
		/// <para>Contains in/out global flags for the property sheet.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OPF_OBJECTISLINK</term>
		/// <term>Object is a link object and therefore has a link property page.</term>
		/// </item>
		/// <item>
		/// <term>OPF_NOFILLDEFAULT</term>
		/// <term>Do not fill in default values for the object.</term>
		/// </item>
		/// <item>
		/// <term>OPF_SHOWHELP</term>
		/// <term>The dialog box will display a Help button.</term>
		/// </item>
		/// <item>
		/// <term>OPF_DISABLECONVERT</term>
		/// <term>The Convert button will be disabled on the general property page.</term>
		/// </item>
		/// </list>
		/// </summary>
		public OPF dwFlags;

		/// <summary>Pointer to the standard property sheet header (PROPSHEETHEADER in ComCtl32), used for extensibility.</summary>
		public IntPtr lpPS;

		/// <summary>Identifier for the object.</summary>
		public uint dwObject;

		/// <summary>Pointer to the interface to manipulate object.</summary>
		public IOleUIObjInfo lpObjInfo;

		/// <summary>
		/// Container-defined unique identifier for a single link. Containers can use the pointer to the link's container site for this value.
		/// </summary>
		public uint dwLink;

		/// <summary>Pointer to the interface to manipulate link.</summary>
		public IOleUILinkInfo lpLinkInfo;

		/// <summary>Pointer to the general page data in <see cref="OLEUIGNRLPROPS"/>.</summary>
		public IntPtr lpGP;

		/// <summary>Pointer to the view page data in <see cref="OLEUIVIEWPROPS"/>.</summary>
		public IntPtr lpVP;

		/// <summary>Pointer to the link page data in <see cref="OLEUILINKPROPS"/>.</summary>
		public IntPtr lpLP;
	}

	/// <summary>
	/// An array of entries to be specified in the OLEUIPASTESPECIAL structure for the <c>Paste Special</c> dialog box. Each entry
	/// includes a FORMATETC structure which specifies the formats that are acceptable, a string that is to represent the format in the
	/// dialog box's listbox, a string to customize the result text of the dialog box, and a set of flags from the OLEUIPASTEFLAG
	/// enumeration. The flags indicate if the entry is valid for pasting only, linking only or both pasting and linking. If the entry
	/// is valid for linking, the flags indicate which link types are acceptable by OR'ing together the appropriate OLEUIPASTE_LINKTYPEn values.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/ns-oledlg-oleuipasteentrya typedef struct tagOLEUIPASTEENTRYA {
	// FORMATETC fmtetc; LPCSTR lpstrFormatName; LPCSTR lpstrResultText; DWORD dwFlags; DWORD dwScratchSpace; } OLEUIPASTEENTRYA,
	// *POLEUIPASTEENTRYA, *LPOLEUIPASTEENTRYA;
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUIPASTEENTRYA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OLEUIPASTEENTRY
	{
		/// <summary>
		/// Format that is acceptable. The <c>Paste Special</c> dialog box checks if this format is offered by the object on the
		/// clipboard and if so, offers it for selection to the user.
		/// </summary>
		public FORMATETC fmtetc;

		/// <summary>
		/// Pointer to the string that represents the format to the user. Any %s in this string is replaced by the FullUserTypeName of
		/// the object on the clipboard and the resulting string is placed in the list box of the dialog box. Only one %s is allowed.
		/// The presence or absence of %s specifies whether the result-text is to indicate that data is being pasted or that an object
		/// that can be activated by an application is being pasted. If %s is present, the resulting text says that an object is being
		/// pasted. Otherwise, it says that data is being pasted.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpstrFormatName;

		/// <summary>
		/// Pointer to the string used to customize the resulting text of the dialog box when the user selects the format corresponding
		/// to this entry. Any %s in this string is replaced by the application name or FullUserTypeName of the object on the clipboard.
		/// Only one %s is allowed.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpstrResultText;

		/// <summary>Values from OLEUIPASTEFLAG enumeration.</summary>
		public OLEUIPASTEFLAG dwFlags;

		/// <summary>
		/// Scratch space available to routines that loop through an IEnumFORMATETC to mark if the PasteEntry format is available. This
		/// field can be left uninitialized.
		/// </summary>
		public uint dwScratchSpace;
	}

	/// <summary>
	/// Contains information that the OLE User Interface Library uses to initialize the <c>Paste Special</c> dialog box, as well as
	/// space for the library to return information when the dialog box is dismissed.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/ns-oledlg-oleuipastespeciala typedef struct tagOLEUIPASTESPECIALA {
	// DWORD cbStruct; DWORD dwFlags; HWND hWndOwner; LPCSTR lpszCaption; LPFNOLEUIHOOK lpfnHook; LPARAM lCustData; HINSTANCE hInstance;
	// LPCSTR lpszTemplate; HRSRC hResource; LPDATAOBJECT lpSrcDataObj; LPOLEUIPASTEENTRYA arrPasteEntries; int cPasteEntries; UINT
	// *arrLinkTypes; int cLinkTypes; UINT cClsidExclude; LPCLSID lpClsidExclude; int nSelectedIndex; BOOL fLink; HGLOBAL hMetaPict;
	// SIZEL sizel; } OLEUIPASTESPECIALA, *POLEUIPASTESPECIALA, *LPOLEUIPASTESPECIALA;
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUIPASTESPECIALA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OLEUIPASTESPECIAL
	{
		/// <summary>The size of the structure, in bytes. This member must be filled on input.</summary>
		public uint cbStruct;

		/// <summary>
		/// <para>
		/// On input, <c>dwFlags</c> specifies the initialization and creation flags. On exit, it specifies the user's choices. It may
		/// be a combination of the following flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PSF_SHOWHELP</term>
		/// <term>Dialog box will display a Help button.</term>
		/// </item>
		/// <item>
		/// <term>PSF_SELECTPASTE</term>
		/// <term>
		/// The Paste radio button will be selected at dialog box startup. This is the default, if PSF_SELECTPASTE or
		/// PSF_SELECTPASTELINK are not specified. Also, it specifies the state of the button on dialog termination. IN/OUT flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PSF_SELECTPASTELINK</term>
		/// <term>
		/// The PasteLink radio button will be selected at dialog box startup. Also, specifies the state of the button on dialog
		/// termination. IN/OUT flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PSF_CHECKDISPLAYASICON</term>
		/// <term>Whether the Display As Icon radio button was checked on dialog box termination. OUT flag.</term>
		/// </item>
		/// <item>
		/// <term>PSF_DISABLEDISPLAYASICON</term>
		/// <term>The Display As Icon check box will be disabled on initialization.</term>
		/// </item>
		/// <item>
		/// <term>HIDECHANGEICON</term>
		/// <term>
		/// Used to disable the change-icon button in the dialog box, which is available to users when they're pasting an OLE object by
		/// default. See STAYONCLIPBOARDCHANGE otherwise.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STAYONCLIPBOARDCHANGE</term>
		/// <term>
		/// Used to tell the dialog box to stay up if the clipboard changes while the dialog box is up. If the user switches to another
		/// application and copies or cuts something, the dialog box will, by default, perform a cancel operation, which will remove the
		/// dialog box since the options it's in the middle of presenting to the user are no longer up-to-date with respect to what's
		/// really on the clipboard.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NOREFRESHDATAOBJECT</term>
		/// <term>
		/// Used in conjunction with STAYONCLIPBOARDCHANGE (it doesn't do anything otherwise). If the clipboard changes while the dialog
		/// box is up and STAYONCLIPBOARDCHANGE is specified, then NOREFRESHDATAOBJECT indicates that the dialog box should NOT refresh
		/// the contents of the dialog box to reflect the new contents of the clipboard. This is useful if the application is using the
		/// paste-special dialog box on an IDataObject besides the one on the clipboard, for example, as part of a right-click
		/// drag-and-drop operation.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PSF dwFlags;

		/// <summary>The window that owns the dialog box. This member should not be <c>NULL</c>.</summary>
		public HWND hWndOwner;

		/// <summary>
		/// Pointer to a string to be used as the title of the dialog box. If <c>NULL</c>, then the library uses <c>Paste Special</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszCaption;

		/// <summary>
		/// Pointer to a hook function that processes messages intended for the dialog box. The hook function must return zero to pass a
		/// message that it didn't process back to the dialog box procedure in the library. The hook function must return a nonzero
		/// value to prevent the library's dialog box procedure from processing a message it has already processed.
		/// </summary>
		public LPFNOLEUIHOOK lpfnHook;

		/// <summary>
		/// Application-defined data that the library passes to the hook function pointed to by the <c>lpfnHook</c> member. The library
		/// passes a pointer to the <c>OLEUIPASTESPECIAL</c> structure in the <c>lParam</c> parameter of the WM_INITDIALOG message; this
		/// pointer can be used to retrieve the <c>lCustData</c> member.
		/// </summary>
		public IntPtr lCustData;

		/// <summary>Instance that contains a dialog box template specified by the <c>lpTemplateName</c> member.</summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the resource file for the dialog box template that is to be
		/// substituted for the library's <c>Paste Special</c> dialog box template.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszTemplate;

		/// <summary>Customized template handle.</summary>
		public HRSRC hResource;

		/// <summary>
		/// Pointer to the IDataObject interface of the data object to be pasted (from the clipboard). This member is filled on input.
		/// If <c>lpSrcDataObj</c> is <c>NULL</c> when OleUIPasteSpecial is called, then <c>OleUIPasteSpecial</c> will attempt to
		/// retrieve a pointer to an <c>IDataObject</c> from the clipboard. If <c>OleUIPasteSpecial</c> succeeds, it is the caller's
		/// responsibility to free the <c>IDataObject</c> returned in <c>lpSrcDataObj</c>.
		/// </summary>
		public IDataObject lpSrcDataObj;

		/// <summary>The <see cref="OLEUIPASTEENTRY"/> array which specifies acceptable formats. This member is filled on input.</summary>
		public IntPtr arrPasteEntries;

		/// <summary>Number of OLEUIPASTEENTRY array entries. This member is filled on input.</summary>
		public int cPasteEntries;

		/// <summary>
		/// List of link types that are acceptable. Link types are referred to using OLEUIPASTEFLAG in <c>arrPasteEntries</c>. This
		/// member is filled on input.
		/// </summary>
		public IntPtr arrLinkTypes;

		/// <summary>Number of link types. This member is filled on input.</summary>
		public int cLinkTypes;

		/// <summary>Number of CLSIDs in <c>lpClsidExclude</c>. This member is filled on input.</summary>
		public uint cClsidExclude;

		/// <summary>
		/// Pointer to an array of CLSIDs to exclude from the list of available server objects for a Paste operation. Note that this
		/// does not affect <c>Paste Link</c>. An application can prevent embedding into itself by listing its own CLSID in this list.
		/// This field is filled on input.
		/// </summary>
		public IntPtr lpClsidExclude;

		/// <summary>Index of <c>arrPasteEntries</c> that the user selected. This member is filled on output.</summary>
		public int nSelectedIndex;

		/// <summary>Whether <c>Paste</c> or <c>Paste Link</c> was selected by the user. This member is filled on output.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fLink;

		/// <summary>Handle to the Metafile containing the icon and icon title selected by the user. This member is filled on output.</summary>
		public HGLOBAL hMetaPict;

		/// <summary>
		/// The size of object as displayed in its source, if the display aspect chosen by the user matches the aspect displayed in the
		/// source. If the user chooses a different aspect, then <c>sizel.cx</c> and <c>sizel.cy</c> are both set to zero. The size of
		/// the object as it is displayed in the source is retrieved from the ObjectDescriptor if <c>fLink</c> is <c>FALSE</c> and from
		/// the LinkSrcDescriptor if <c>fLink</c> is <c>TRUE</c>. This member is filled on output.
		/// </summary>
		public SIZE sizel;
	}

	/// <summary>
	/// Contains information that is used to initialize the <c>View</c> tab of the <c>Object properties</c> dialog box. A reference to
	/// it is passed in as part of the OLEUIOBJECTPROPS structure to the OleUIObjectProperties function. This tab allows the user to
	/// toggle between "content" and "iconic" views of the object, and change its scaling within the container. It also allows the user
	/// to tunnel to the change icon dialog box when the object is being displayed iconically.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/oledlg/ns-oledlg-oleuiviewpropsa typedef struct tagOLEUIVIEWPROPSA { DWORD
	// cbStruct; DWORD dwFlags; DWORD dwReserved1[2]; LPFNOLEUIHOOK lpfnHook; LPARAM lCustData; DWORD dwReserved2[3]; struct
	// tagOLEUIOBJECTPROPSA *lpOP; int nScaleMin; int nScaleMax; } OLEUIVIEWPROPSA, *POLEUIVIEWPROPSA, *LPOLEUIVIEWPROPSA;
	[PInvokeData("oledlg.h", MSDNShortId = "NS:oledlg.tagOLEUIVIEWPROPSA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OLEUIVIEWPROPS
	{
		/// <summary>The size of the structure, in bytes.</summary>
		public uint cbStruct;

		/// <summary>
		/// <para>Flags specific to view page.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>VPF_SELECTRELATIVE</term>
		/// <term>Relative to origin.</term>
		/// </item>
		/// <item>
		/// <term>VPF_DISABLERELATIVE</term>
		/// <term>Disable relative to origin.</term>
		/// </item>
		/// <item>
		/// <term>VPF_DISABLESCALE</term>
		/// <term>Disable scale option.</term>
		/// </item>
		/// </list>
		/// </summary>
		public VPF dwFlags;

		/// <summary>This member is reserved.</summary>
		public ulong dwReserved1;

		/// <summary>Pointer to a hook callback (not used in this dialog box).</summary>
		public LPFNOLEUIHOOK lpfnHook;

		/// <summary>Custom data to pass to the hook (not used in this dialog box).</summary>
		public IntPtr lCustData;

		/// <summary>This member is reserved.</summary>
		public uint dwReserved2_1;

		/// <summary>This member is reserved.</summary>
		public uint dwReserved2_2;

		/// <summary>This member is reserved.</summary>
		public uint dwReserved2_3;

		/// <summary>Used internally.</summary>
		public IntPtr lpOP;

		/// <summary>Minimum value for the scale range.</summary>
		public int nScaleMin;

		/// <summary>Maximum value for the scale range.</summary>
		public int nScaleMax;
	}
}