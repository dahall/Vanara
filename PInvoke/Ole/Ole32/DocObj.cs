using System.Runtime.InteropServices.ComTypes;
using Vanara.Collections;

namespace Vanara.PInvoke;

public static partial class Ole32
{
	/// <summary>The highest allowed value for an OLE error code.</summary>
	public const uint OLE_E_LAST = 0x800400FF;

	/// <summary>The lowest allowed value for an OLE command error code.</summary>
	public const uint OLECMDERR_E_FIRST = OLE_E_LAST + 1;

	/// <summary>Command parameter is not recognized as a valid command</summary>
	public const uint OLECMDERR_E_NOTSUPPORTED = OLECMDERR_E_FIRST;

	/// <summary>The command identified by nCmdID is currently disabled and cannot be executed.</summary>
	public const uint OLECMDERR_E_DISABLED = OLECMDERR_E_FIRST + 1;

	/// <summary>The caller has asked for help on the command identified by nCmdID, but no help is available.</summary>
	public const uint OLECMDERR_E_NOHELP = OLECMDERR_E_FIRST + 2;

	/// <summary>The user canceled the execution of the command.</summary>
	public const uint OLECMDERR_E_CANCELED = OLECMDERR_E_FIRST + 3;

	/// <summary>Command group parameter is non-NULL but does not specify a recognized command group</summary>
	public const uint OLECMDERR_E_UNKNOWNGROUP = OLECMDERR_E_FIRST + 4;

	/// <summary>Indicates that all the remaining pages should be printed.</summary>
	public const ushort PAGESET_TOLASTPAGE = unchecked((ushort)-1);

	/// <summary>Provides miscellaneous property information about a document object.</summary>
	/// <remarks>
	/// <para>
	/// Objects that have a limited user interface for activation purposes should set DOCMISC_CANTOPENEDIT. Those that support
	/// IPersistStorage only as a persistence mechanism should specify DOCMISC_NOFILESUPPORT. Otherwise, an object must also implement IPersistFile.
	/// </para>
	/// <para>A combination of values from <c>DOCMISC</c> is returned at the location specified by the pdwStatus parameter in IOleDocument::GetDocMiscStatus.</para>
	/// <para>If an object requires none of these flags, it must write a zero to the pdwStatus parameter.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/docobj/ne-docobj-docmisc typedef enum __MIDL_IOleDocument_0001 {
	// DOCMISC_CANCREATEMULTIPLEVIEWS, DOCMISC_SUPPORTCOMPLEXRECTANGLES, DOCMISC_CANTOPENEDIT, DOCMISC_NOFILESUPPORT } DOCMISC;
	[PInvokeData("docobj.h", MSDNShortId = "NE:docobj.__MIDL_IOleDocument_0001")]
	[Flags]
	public enum DOCMISC
	{
		/// <summary>Object supports multiple views.</summary>
		DOCMISC_CANCREATEMULTIPLEVIEWS = 1,

		/// <summary>Object supports complex rectangles and therefore implements IOleDocumentView::SetRectComplex.</summary>
		DOCMISC_SUPPORTCOMPLEXRECTANGLES = 2,

		/// <summary>Object supports activation in a separate window and therefore implements IOleDocumentView::Open.</summary>
		DOCMISC_CANTOPENEDIT = 4,

		/// <summary>Object does not support file read/write.</summary>
		DOCMISC_NOFILESUPPORT = 8,
	}

	/// <summary/>
	[PInvokeData("docobj.h")]
	[Flags]
	public enum IGNOREMIME
	{
		/// <summary/>
		IGNOREMIME_PROMPT = 0x00000001,

		/// <summary/>
		IGNOREMIME_TEXT = 0x00000002,
	}

	/// <summary/>
	[PInvokeData("docobj.h")]
	public enum MEDIAPLAYBACK_STATE
	{
		/// <summary/>
		MEDIAPLAYBACK_RESUME = 0,

		/// <summary/>
		MEDIAPLAYBACK_PAUSE = 1,

		/// <summary/>
		MEDIAPLAYBACK_PAUSE_AND_SUSPEND = 2,

		/// <summary/>
		MEDIAPLAYBACK_RESUME_FROM_SUSPEND = 3,
	}

	/// <summary>Specifies command execution options.</summary>
	[PInvokeData("docobj.h")]
	public enum OLECMDEXECOPT
	{
		/// <summary>Prompt the user for input or not, whichever is the default behavior.</summary>
		OLECMDEXECOPT_DODEFAULT = 0,

		/// <summary>Execute the command after obtaining user input.</summary>
		OLECMDEXECOPT_PROMPTUSER = 1,

		/// <summary>
		/// Execute the command without prompting the user. For example, clicking the Print toolbar button causes a document to be
		/// immediately printed without user input.
		/// </summary>
		OLECMDEXECOPT_DONTPROMPTUSER = 2,

		/// <summary>Show help for the corresponding command, but do not execute.</summary>
		OLECMDEXECOPT_SHOWHELP = 3
	}

	/// <summary>Specifies the type of support provided by an object for the command specified in an OLECMD structure.</summary>
	[PInvokeData("docobj.h")]
	[Flags]
	public enum OLECMDF
	{
		/// <summary>The command is supported by this object.</summary>
		OLECMDF_SUPPORTED = 0x00000001,

		/// <summary>The command is available and enabled.</summary>
		OLECMDF_ENABLED = 0x00000002,

		/// <summary>The command is an on-off toggle and is currently on.</summary>
		OLECMDF_LATCHED = 0x00000004,

		/// <summary>Reserved for future use.</summary>
		OLECMDF_NINCHED = 0x00000008,

		/// <summary>The command is hidden.</summary>
		OLECMDF_INVISIBLE = 0x00000010,

		/// <summary>The command is hidden on the context menu.</summary>
		OLECMDF_DEFHIDEONCTXTMENU = 0x00000020,
	}

	/// <summary>
	/// Specifies which standard command is to be executed. A single value from this enumeration is passed in the nCmdID argument of IOleCommandTarget::Exec.
	/// </summary>
	/// <remarks>
	/// <para>
	/// In OLE Compound Documents technology, an object that is being edited in-place disables the <c>Zoom</c> control on its toolbar
	/// and the <c>Zoom</c> command on its <c>View</c> menu, because, the <c>Zoom</c> command applies logically to the container
	/// document, not to the object. The OLECMDID_ZOOM and OLECMDID_GETZOOMRANGE commands notify the container's frame object of the
	/// zoom range it should use to display a document object in its user interface. The container frame is the client-side object that
	/// implements IOleInPlaceFrame and, optionally, IOleCommandTarget.
	/// </para>
	/// <para>
	/// The OLECMDID_ZOOM command takes one <c>LONG</c> argument as input and writes one <c>LONG</c> argument on output. This command is
	/// used for three purposes:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// To query the current zoom value. The caller of IOleCommandTarget::Exec passes OLECMDEXECOPT_DONTPROMPTUSER as the execute option
	/// in nCmdExecOpt and <c>NULL</c> for pvIn. The object returns the current zoom value in pvaOut. When the object goes UI active, it
	/// retrieves the current zoom value from the container's frame object using this same mechanism and updates its zoom control with
	/// the returned value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To display the <c>Zoom</c> dialog box. The caller of IOleCommandTarget::Exec passes OLECMDEXECOPT_PROMPTUSER in nCmdExecOpt. The
	/// caller can optionally pass the initial value for the dialog box through pvaIn; otherwise pvaIn must be <c>NULL</c>. If the user
	/// clicks <c>Cancel</c>, the object returns OLECMDERR_E_CANCELED. If the user clicks <c>OK</c>, the object passes the user-selected
	/// value in pvaOut. When user chooses the <c>Zoom</c> command from the <c>View</c> menu, the object calls the container's frame
	/// object in the same manner. The container then zooms the document to the user selected value, and the object updates its
	/// <c>Zoom</c> control with that value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To set a <c>Zoom</c> value. The caller of IOleCommandTarget::Exec passes OLECMDEXECOPT_DONTPROMPTUSER in nCmdExecOpt and passes
	/// the zoom value to apply through pvaIn. The object validates and normalizes the new value and returns the validated value in
	/// pvaOut. When the user selects a new zoom value (using the <c>Zoom</c> control on the toolbar, for instance), the object calls
	/// the container's frame object in this manner. The container zooms the document to 100 percent, and the object updates the
	/// <c>Zoom</c> control with that value.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The OLECMDID_GETZOOMRANGE command is used to determine the range of valid zoom values from an object that implements
	/// IOleCommandTarget. The caller passes MSOCMDEXECOPT_DONTPROMPTUSER in nCmdExecOpt and <c>NULL</c> for pvaIn. The object returns
	/// its zoom range in pvaOut where the HIWORD contains the maximum zoom value and the LOWORD contains the minimum zoom value.
	/// Typically this command is used when the user drops down the <c>Zoom</c> control on the toolbar of the UI-active object. The
	/// applications and objects that support this command are required to support all the integral zoom values that are within the
	/// (min,max) pair they return.
	/// </para>
	/// <para>
	/// The OLECMDID_ACTIVEXINSTALLSCOPE command notifies Trident to use the indicated Install Scope to install the ActiveX Control
	/// specified by the indicated class ID. The Install Scope is passed in a VT_ARRAY in pvaIn of the IOleCommandTarget::Exec method
	/// whose elements are as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Data</term>
	/// <term>VARIANT Type</term>
	/// <term>Index</term>
	/// </listheader>
	/// <item>
	/// <term>Class ID</term>
	/// <term>VT_BSTR</term>
	/// <term>0</term>
	/// </item>
	/// <item>
	/// <term>Install Scope</term>
	/// <term>VT_UI4</term>
	/// <term>1</term>
	/// </item>
	/// </list>
	/// <para>The Install Scope must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALL_SCOPE_USERS</term>
	/// <term>The ActiveX control should register to HKCU and for the instant user only.</term>
	/// </item>
	/// <item>
	/// <term>INSTALL_SCOPE_MACHINE</term>
	/// <term>The ActiveX control should register to HKLM and across the computer</term>
	/// </item>
	/// </list>
	/// <para>The following is an example use of the OLECMDID_ACTIVEXINSTALLSCOPE command.</para>
	/// <para>
	/// <code>IOleCommandTarget::Exec( NULL, // Pointer to command group OLECMDARGINDEX_ACTIVEXINSTALL_INSTALLSCOPE, // ID of command to execute NULL, // Options &amp;varArgs, // pvain pointer to input arguments NULL) // pointer to command output</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/docobj/ne-docobj-olecmdid
	[PInvokeData("docobj.h", MSDNShortId = "NE:docobj.OLECMDID")]
	public enum OLECMDID
	{
		/// <summary>File menu, Open command</summary>
		OLECMDID_OPEN = 1,

		/// <summary>File menu, New command</summary>
		OLECMDID_NEW,

		/// <summary>File menu, Save command</summary>
		OLECMDID_SAVE,

		/// <summary>File menu, Save As command</summary>
		OLECMDID_SAVEAS,

		/// <summary>File menu, Save Copy As command</summary>
		OLECMDID_SAVECOPYAS,

		/// <summary>File menu, Print command</summary>
		OLECMDID_PRINT,

		/// <summary>File menu, Print Preview command</summary>
		OLECMDID_PRINTPREVIEW,

		/// <summary>File menu, Page Setup command</summary>
		OLECMDID_PAGESETUP,

		/// <summary>Tools menu, Spelling command</summary>
		OLECMDID_SPELL,

		/// <summary>File menu, Properties command</summary>
		OLECMDID_PROPERTIES,

		/// <summary>Edit menu, Cut command</summary>
		OLECMDID_CUT,

		/// <summary>Edit menu, Copy command</summary>
		OLECMDID_COPY,

		/// <summary>Edit menu, Paste command</summary>
		OLECMDID_PASTE,

		/// <summary>Edit menu, Paste Special command</summary>
		OLECMDID_PASTESPECIAL,

		/// <summary>Edit menu, Undo command</summary>
		OLECMDID_UNDO,

		/// <summary>Edit menu, Redo command</summary>
		OLECMDID_REDO,

		/// <summary>Edit menu, Select All command</summary>
		OLECMDID_SELECTALL,

		/// <summary>Edit menu, Clear command</summary>
		OLECMDID_CLEARSELECTION,

		/// <summary>View menu, Zoom command (see below for details.)</summary>
		OLECMDID_ZOOM,

		/// <summary>Retrieves zoom range applicable to View Zoom (see below for details.)</summary>
		OLECMDID_GETZOOMRANGE,

		/// <summary>
		/// Informs the receiver, usually a frame, of state changes. The receiver can then query the status of the commands whenever convenient.
		/// </summary>
		OLECMDID_UPDATECOMMANDS,

		/// <summary>Asks the receiver to refresh its display. Implemented by the document/object.</summary>
		OLECMDID_REFRESH,

		/// <summary>Stops all current processing. Implemented by the document/object.</summary>
		OLECMDID_STOP,

		/// <summary>View menu, Toolbars command. Implemented by the document/object to hide its toolbars.</summary>
		OLECMDID_HIDETOOLBARS,

		/// <summary>
		/// Sets the maximum value of a progress indicator if one is owned by the receiving object, usually a frame. The minimum value
		/// is always zero.
		/// </summary>
		OLECMDID_SETPROGRESSMAX,

		/// <summary>Sets the current value of a progress indicator if one is owned by the receiving object, usually a frame.</summary>
		OLECMDID_SETPROGRESSPOS,

		/// <summary>
		/// Sets the text contained in a progress indicator if one is owned by the receiving object, usually a frame. If the receiver
		/// currently has no progress indicator, this text should be displayed in the status bar (if one exists) as with IOleInPlaceFrame::SetStatusText.
		/// </summary>
		OLECMDID_SETPROGRESSTEXT,

		/// <summary>Sets the title bar text of the receiving object, usually a frame.</summary>
		OLECMDID_SETTITLE,

		/// <summary>
		/// Called by the object when downloading state changes. Takes a VT_BOOL parameter, which is TRUE if the object is downloading
		/// data and FALSE if it not. Primarily implemented by the frame.
		/// </summary>
		OLECMDID_SETDOWNLOADSTATE,

		/// <summary>
		/// Stops the download when executed. Typically, this command is propagated to all contained objects. When queried, sets
		/// MSOCMDF_ENABLED. Implemented by the document/object.
		/// </summary>
		OLECMDID_STOPDOWNLOAD,

		/// <summary/>
		OLECMDID_ONTOOLBARACTIVATED,

		/// <summary>Edit menu, Find command</summary>
		OLECMDID_FIND,

		/// <summary>Edit menu, Delete command</summary>
		OLECMDID_DELETE,

		/// <summary>
		/// Issued in response to HTTP-EQUIV metatag and results in a call to the deprecated OnHttpEquiv method with the fDone parameter
		/// set to false. This command takes a VT_BSTR parameter which is passed to OnHttpEquiv.
		/// </summary>
		OLECMDID_HTTPEQUIV,

		/// <summary>
		/// Issued in response to HTTP-EQUIV metatag and results in a call to the deprecated OnHttpEquiv method with the fDone parameter
		/// set to true. This command takes a VT_BSTR parameter which is passed to OnHttpEquiv.
		/// </summary>
		OLECMDID_HTTPEQUIV_DONE,

		/// <summary>
		/// Pauses or resumes receiver interaction. This command takes a VT_BOOL parameter that pauses interaction when set to FALSE and
		/// resumes interaction when set to TRUE.
		/// </summary>
		OLECMDID_ENABLE_INTERACTION,

		/// <summary>
		/// Notifies the receiver of an intent to close the window imminently. This command takes a VT_BOOL output parameter that
		/// returns TRUE if the receiver can close and FALSE if it can't.
		/// </summary>
		OLECMDID_ONUNLOAD,

		/// <summary>This command has no effect.</summary>
		OLECMDID_PROPERTYBAG2,

		/// <summary>Notifies the receiver that a refresh is about to start.</summary>
		OLECMDID_PREREFRESH,

		/// <summary>Tells the receiver to display the script error message.</summary>
		OLECMDID_SHOWSCRIPTERROR,

		/// <summary>This command takes an IHTMLEventObj input parameter that contains a message that the receiver shows.</summary>
		OLECMDID_SHOWMESSAGE,

		/// <summary>Tells the receiver to show the Find dialog box. It takes a VT_DISPATCH input param.</summary>
		OLECMDID_SHOWFIND,

		/// <summary>Tells the receiver to show the Page Setup dialog box. It takes an IHTMLEventObj2 input parameter.</summary>
		OLECMDID_SHOWPAGESETUP,

		/// <summary>Tells the receiver to show the Print dialog box. It takes an IHTMLEventObj2 input parameter.</summary>
		OLECMDID_SHOWPRINT,

		/// <summary>The exit command for the File menu.</summary>
		OLECMDID_CLOSE,

		/// <summary>Supports the QueryStatus method.</summary>
		OLECMDID_ALLOWUILESSSAVEAS,

		/// <summary>Notifies the receiver that CSS files should not be downloaded when in DesignMode.</summary>
		OLECMDID_DONTDOWNLOADCSS,

		/// <summary>This command has no effect.</summary>
		OLECMDID_UPDATEPAGESTATUS,

		/// <summary>File menu, updated Print command</summary>
		OLECMDID_PRINT2,

		/// <summary>File menu, updated Print Preview command</summary>
		OLECMDID_PRINTPREVIEW2,

		/// <summary>Sets an explicit Print Template value of TRUE or FALSE, based on a VT_BOOL input parameter.</summary>
		OLECMDID_SETPRINTTEMPLATE,

		/// <summary>Gets a VT_BOOL output parameter indicating whether the Print Template value is TRUE or FALSE.</summary>
		OLECMDID_GETPRINTTEMPLATE,

		/// <summary>
		/// Indicates that a page action has been blocked. PAGEACTIONBLOCKED is designed for use with applications that host the
		/// Internet Explorer WebBrowser control to implement their own UI.
		/// </summary>
		OLECMDID_PAGEACTIONBLOCKED = 55,

		/// <summary>Specifies which actions are displayed in the Internet Explorer notification band.</summary>
		OLECMDID_PAGEACTIONUIQUERY,

		/// <summary>
		/// Causes the Internet Explorer WebBrowser control to focus its default notification band. Hosts can send this command at any
		/// time. The return value is S_OK if the band is present and is in focus, or S_FALSE otherwise.
		/// </summary>
		OLECMDID_FOCUSVIEWCONTROLS,

		/// <summary>
		/// This notification event is provided for applications that display Internet Explorers default notification band
		/// implementation. By default, when the user presses the ALT-N key combination, Internet Explorer treats it as a request to
		/// focus the notification band.
		/// </summary>
		OLECMDID_FOCUSVIEWCONTROLSQUERY,

		/// <summary>Causes the Internet Explorer WebBrowser control to show the Information Bar menu.</summary>
		OLECMDID_SHOWPAGEACTIONMENU,

		/// <summary>
		/// Causes the Internet Explorer WebBrowser control to create an entry at the current Travel Log offset. The Docobject should
		/// implement ITravelLogClient and IPersist interfaces, which are used by the Travel Log as it processes this command with calls
		/// to GetWindowData and GetPersistID, respectively.
		/// </summary>
		OLECMDID_ADDTRAVELENTRY,

		/// <summary>
		/// Called when LoadHistory is processed to update the previous Docobject state. For synchronous handling, this command can be
		/// called before returning from the LoadHistory call. For asynchronous handling, it can be called later.
		/// </summary>
		OLECMDID_UPDATETRAVELENTRY,

		/// <summary>Updates the state of the browser's Back and Forward buttons.</summary>
		OLECMDID_UPDATEBACKFORWARDSTATE,

		/// <summary>
		/// Windows Internet Explorer 7 and later. Sets the zoom factor of the browser. Takes a VT_I4 parameter in the range of 10 to
		/// 1000 (percent).
		/// </summary>
		OLECMDID_OPTICAL_ZOOM,

		/// <summary>
		/// Windows Internet Explorer 7 and later. Retrieves the minimum and maximum browser zoom factor limits. Returns a VT_I4
		/// parameter; the LOWORD is the minimum zoom factor, the HIWORD is the maximum.
		/// </summary>
		OLECMDID_OPTICAL_GETZOOMRANGE,

		/// <summary>
		/// Windows Internet Explorer 7 and later. Notifies the Internet Explorer WebBrowser control of changes in window states, such
		/// as losing focus, or becoming hidden or minimized. The host indicates what has changed by setting OLECMDID_WINDOWSTATE_FLAG
		/// option flags in nCmdExecOpt.
		/// </summary>
		OLECMDID_WINDOWSTATECHANGED,

		/// <summary>
		/// Windows Internet Explorer 8 with Windows Vista. Has no effect with Windows Internet Explorer 8 with Windows XP. Notifies
		/// Trident to use the indicated Install Scope to install the ActiveX Control specified by the indicated Class ID. For more
		/// information, see the Remarks section.
		/// </summary>
		OLECMDID_ACTIVEXINSTALLSCOPE,

		/// <summary>
		/// Internet Explorer 8. Unlike OLECMDID_UPDATETRAVELENTRY, this updates a Travel Log entry that is not initialized from a
		/// previous Docobject state. While this command is not called from IPersistHistory::LoadHistory, it can be called separately to
		/// save browser state that can be used later to recover from a crash.
		/// </summary>
		OLECMDID_UPDATETRAVELENTRY_DATARECOVERY,

		/// <summary/>
		OLECMDID_SHOWTASKDLG,

		/// <summary/>
		OLECMDID_POPSTATEEVENT,

		/// <summary/>
		OLECMDID_VIEWPORT_MODE,

		/// <summary/>
		OLECMDID_LAYOUT_VIEWPORT_WIDTH,

		/// <summary/>
		OLECMDID_VISUAL_VIEWPORT_EXCLUDE_BOTTOM,

		/// <summary/>
		OLECMDID_USER_OPTICAL_ZOOM,

		/// <summary/>
		OLECMDID_PAGEAVAILABLE,

		/// <summary/>
		OLECMDID_GETUSERSCALABLE,

		/// <summary/>
		OLECMDID_UPDATE_CARET,

		/// <summary/>
		OLECMDID_ENABLE_VISIBILITY,

		/// <summary/>
		OLECMDID_MEDIA_PLAYBACK,

		/// <summary/>
		OLECMDID_SETFAVICON,

		/// <summary/>
		OLECMDID_SET_HOST_FULLSCREENMODE,

		/// <summary/>
		OLECMDID_EXITFULLSCREEN,

		/// <summary/>
		OLECMDID_SCROLLCOMPLETE,

		/// <summary/>
		OLECMDID_ONBEFOREUNLOAD,

		/// <summary/>
		OLECMDID_SHOWMESSAGE_BLOCKABLE,

		/// <summary/>
		OLECMDID_SHOWTASKDLG_BLOCKABLE,
	}

	/// <summary>Specifies the window state.</summary>
	[PInvokeData("docobj.h")]
	[Flags]
	public enum OLECMDID_WINDOWSTATE_FLAG
	{
		/// <summary>The window is visible.</summary>
		OLECMDIDF_WINDOWSTATE_USERVISIBLE = 0x01,

		/// <summary>The window has focus.</summary>
		OLECMDIDF_WINDOWSTATE_ENABLED = 0x02,

		/// <summary>The window is visible and valid.</summary>
		OLECMDIDF_WINDOWSTATE_USERVISIBLE_VALID = 0x00010000,

		/// <summary>The window has focus and is valid.</summary>
		OLECMDIDF_WINDOWSTATE_ENABLED_VALID = 0x00020000
	}

	/// <summary>
	/// Specifies the type of information that an object should store in the OLECMDTEXT structure passed in
	/// IOleCommandTarget::QueryStatus. One value from this enumeration is stored in <see cref="OLECMDTEXT.cmdtextf"/> to indicate the
	/// desired information.
	/// </summary>
	[PInvokeData("docobj.h")]
	public enum OLECMDTEXTF
	{
		/// <summary>No extra information is requested.</summary>
		OLECMDTEXTF_NONE = 0,

		/// <summary>The object should provide the localized name of the command.</summary>
		OLECMDTEXTF_NAME = 1,

		/// <summary>The object should provide a localized status string for the command.</summary>
		OLECMDTEXTF_STATUS = 2,
	}

	/// <summary/>
	[PInvokeData("docobj.h")]
	[Flags]
	public enum PRINTFLAG
	{
		/// <summary/>
		PRINTFLAG_MAYBOTHERUSER = 1,

		/// <summary/>
		PRINTFLAG_PROMPTUSER = 2,

		/// <summary/>
		PRINTFLAG_USERMAYCHANGEPRINTER = 4,

		/// <summary/>
		PRINTFLAG_RECOMPOSETODEVICE = 8,

		/// <summary/>
		PRINTFLAG_DONTACTUALLYPRINT = 16,

		/// <summary/>
		PRINTFLAG_FORCEPROPERTIES = 32,

		/// <summary/>
		PRINTFLAG_PRINTTOFILE = 64
	}

	/// <summary/>
	[PInvokeData("docobj.h")]
	[Flags]
	public enum WPCSETTING
	{
		/// <summary/>
		WPCSETTING_LOGGING_ENABLED = 0x00000001,

		/// <summary/>
		WPCSETTING_FILEDOWNLOAD_BLOCKED = 0x00000002,
	}

	/// <summary>
	/// <para>Provides a generic callback mechanism for interruptible processes that should periodically ask an object whether to continue.</para>
	/// <para>
	/// The FContinue method is a generic continuation request. FContinuePrinting carries extra information pertaining to a printing
	/// process and is used in the context of IPrint.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nn-docobj-icontinuecallback
	[PInvokeData("docobj.h", MSDNShortId = "NN:docobj.IContinueCallback")]
	[ComImport, Guid("b722bcca-4e68-101b-a2bc-00aa00404770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IContinueCallback
	{
		/// <summary>Indicates whether a generic operation should continue.</summary>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Continue the operation.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Cancel the operation as soon as possible.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-icontinuecallback-fcontinue HRESULT FContinue();
		[PreserveSig]
		HRESULT FContinue();

		/// <summary>Indicates whether a lengthy printing operation should continue.</summary>
		/// <param name="nCntPrinted">The total number of pages that have been printed at the time the object receives a call to <c>FContinuePrinting</c>.</param>
		/// <param name="nCurPage">The page number of the page being printed at the time the object receives a call to <c>FContinuePrinting</c>.</param>
		/// <param name="pwszPrintStatus">
		/// A pointer to the message about the current status of the print job. The object being printed may or may not display this
		/// message to the user. This parameter can be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return value E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Continue the printing operation.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Cancel the printing operation as soon as possible.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Implementations of IPrint::Print call this method at periodic intervals during the printing process. The IPrint
		/// implementation should call back at least after printing each page, so that its client can, if necessary, display useful
		/// visual feedback to the user. <c>IPrint::Print</c> can call back multiple times with the same nCntPrinted and nCurPage
		/// values, which is sometimes useful when a page being printed is complex and it is appropriate to give a user an opportunity
		/// to cancel in mid-page.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-icontinuecallback-fcontinueprinting HRESULT
		// FContinuePrinting( LONG nCntPrinted, LONG nCurPage, wchar_t *pwszPrintStatus );
		[PreserveSig]
		HRESULT FContinuePrinting(int nCntPrinted, int nCurPage, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszPrintStatus);
	}

	/// <summary>Enumerates the views supported by a document object.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nn-docobj-ienumoledocumentviews
	[PInvokeData("docobj.h", MSDNShortId = "NN:docobj.IEnumOleDocumentViews")]
	[ComImport, Guid("b722bcc8-4e68-101b-a2bc-00aa00404770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumOleDocumentViews : ICOMEnum<IOleDocumentView>
	{
		/// <summary>Retrieves the specified number of items in the enumeration sequence.</summary>
		/// <param name="cViews">
		/// <para>
		/// The number of items to be retrieved. If there are fewer than the requested number of items left in the sequence, this method
		/// retrieves the remaining elements.
		/// </para>
		/// <para>If pcFetched is <c>NULL</c>, this parameter must be 1.</para>
		/// </param>
		/// <param name="rgpView">
		/// <para>An array of enumerated items.</para>
		/// <para>
		/// The enumerator is responsible for calling AddRef, and the caller is responsible for calling Release through each pointer
		/// enumerated. If cViews is greater than 1, the caller must also pass a non- <c>NULL</c> pointer passed to pcFetched to know
		/// how many pointers to release.
		/// </para>
		/// </param>
		/// <param name="pcFetched">
		/// The number of items that were retrieved. This parameter is always less than or equal to the number of items requested. This
		/// parameter can be <c>NULL</c>, in which case the cViews parameter must be 1.
		/// </param>
		/// <returns>If the method retrieves the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
		/// <remarks>
		/// E_NOTIMPL is not allowed as a return value. If an error value is returned, no entries in the rgpView array are valid and no
		/// calls to Release are required.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ienumoledocumentviews-next HRESULT Next( ULONG cViews,
		// IOleDocumentView **rgpView, ULONG *pcFetched );
		[PreserveSig]
		HRESULT Next(uint cViews, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IOleDocumentView rgpView, out uint pcFetched);

		/// <summary>Skips over the specified number of items in the enumeration sequence.</summary>
		/// <param name="cViews">The number of items to be skipped.</param>
		/// <returns>If the method skips the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ienumoledocumentviews-skip HRESULT Skip( ULONG cViews );
		[PreserveSig]
		HRESULT Skip(uint cViews);

		/// <summary>Resets the enumeration sequence to the beginning.</summary>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// There is no guarantee that the same set of objects will be enumerated after the reset operation has completed. A static
		/// collection is reset to the beginning, but it can be too expensive for some collections, such as files in a directory, to
		/// guarantee this condition.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ienumoledocumentviews-reset HRESULT Reset();
		[PreserveSig]
		HRESULT Reset();

		/// <summary>
		/// <para>Creates a new enumerator that contains the same enumeration state as the current one.</para>
		/// <para>
		/// This method makes it possible to record a particular point in the enumeration sequence and then return to that point at a
		/// later time. The caller must release this new enumerator separately from the first enumerator.
		/// </para>
		/// </summary>
		/// <param name="ppEnum">
		/// A pointer to the IEnumOleDocumentViews interface pointer on the newly created enumerator. The caller must release this
		/// enumerator separately from the one from which it was cloned.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified enumerator is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ienumoledocumentviews-clone HRESULT Clone(
		// IEnumOleDocumentViews **ppEnum );
		[PreserveSig]
		HRESULT Clone(out IEnumOleDocumentViews ppEnum);
	}

	/// <summary>
	/// <para>
	/// Enables objects and their containers to dispatch commands to each other. For example, an object's toolbars may contain buttons
	/// for commands such as <c>Print</c>, <c>Print Preview</c>, <c>Save</c>, <c>New</c>, and <c>Zoom</c>.
	/// </para>
	/// <para>
	/// Normal in-place activation guidelines recommend that you remove or disable such buttons because no efficient, standard mechanism
	/// has been available to dispatch them to the container. Similarly, a container has heretofore had no efficient means to send
	/// commands such as <c>Print</c>, <c>Page Setup</c>, and <c>Properties</c> to an in-place active object. Such simple command
	/// routing could have been handled through existing OLE Automation standards and the <c>IDispatch</c> interface, but the overhead
	/// with IDispatch is more than is required in the case of document objects. The <c>IOleCommandTarget</c> interface provides a
	/// simpler means to achieve the same ends.
	/// </para>
	/// <para>
	/// Available commands are defined by integer identifiers in a group. The group itself is identified with a GUID. The interface
	/// allows a caller both to query for support of one or more commands within a group and to issue a supported command to the object.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/docobj/nn-docobj-iolecommandtarget
	[PInvokeData("docobj.h", MSDNShortId = "5c8b455e-7740-4f71-aef6-27390a11a1a3")]
	[ComImport, Guid("B722BCCB-4E68-101B-A2BC-00AA00404770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleCommandTarget
	{
		/// <summary>Queries the object for the status of one or more commands generated by user interface events.</summary>
		/// <param name="pguidCmdGroup">
		/// The unique identifier of the command group; can be NULL to specify the standard group. All the commands that are passed in
		/// the prgCmds array must belong to the group specified by pguidCmdGroup.
		/// </param>
		/// <param name="cCmds">The number of commands in the prgCmds array.</param>
		/// <param name="prgCmds">
		/// A caller-allocated array of OLECMD structures that indicate the commands for which the caller needs status information. This
		/// method fills the <see cref="OLECMD.cmdf"/> member of each structure with values taken from the OLECMDF enumeration.
		/// </param>
		/// <param name="pCmdText">
		/// A pointer to an OLECMDTEXT structure in which to return name and/or status information of a single command. This parameter
		/// can be NULL to indicate that the caller does not need this information.
		/// </param>
		/// <returns>This method returns S_OK on success.</returns>
		[PreserveSig]
		HRESULT QueryStatus([In, Optional] GuidPtr pguidCmdGroup, uint cCmds, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] OLECMD[] prgCmds, [In, Out, Optional] IntPtr /* OLECMDTEXT* */ pCmdText);

		/// <summary>Executes the specified command or displays help for the command.</summary>
		/// <param name="pguidCmdGroup">The unique identifier of the command group; can be NULL to specify the standard group.</param>
		/// <param name="nCmdID">The command to be executed. This command must belong to the group specified with pguidCmdGroup.</param>
		/// <param name="nCmdexecopt">
		/// Specifies how the object should execute the command. Possible values are taken from the OLECMDEXECOPT and
		/// OLECMDID_WINDOWSTATE_FLAG enumerations.
		/// </param>
		/// <param name="pvaIn">A pointer to a VARIANTARG structure containing input arguments. This parameter can be NULL.</param>
		/// <param name="pvaOut">Pointer to a VARIANTARG structure to receive command output. This parameter can be NULL.</param>
		/// <returns>This method returns S_OK on success.</returns>
		[PreserveSig]
		HRESULT Exec([In, Optional] GuidPtr pguidCmdGroup, uint nCmdID, uint nCmdexecopt, [In, Optional] object? pvaIn, [In, Out, Optional] object? pvaOut);
	}

	/// <summary>
	/// Enables a document object to communicate to containers its ability to create views of its data. This interface also enables a
	/// document object to enumerate its views and to provide containers with miscellaneous information about itself, such as whether it
	/// supports multiple views or complex rectangles.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nn-docobj-ioledocument
	[PInvokeData("docobj.h", MSDNShortId = "NN:docobj.IOleDocument")]
	[ComImport, Guid("b722bcc5-4e68-101b-a2bc-00aa00404770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleDocument
	{
		/// <summary>
		/// Creates a document view object in the caller's process and obtains a pointer to that object's IOleDocumentView interface.
		/// </summary>
		/// <param name="pIPSite">
		/// A pointer to the IOleInPlaceSite interface that represents the view site object to be associated with the new document view
		/// object. This parameter can be <c>NULL</c>, for example, when the view is contained in a new, uninitialized document object,
		/// in which case the caller must initialize the view with a subsequent call to IOleDocumentView::SetInPlaceSite.
		/// </param>
		/// <param name="pstm">
		/// A pointer to a stream containing data from which the new document view object should initialize itself. If <c>NULL</c>, the
		/// document object initializes the new document view object with a default state.
		/// </param>
		/// <param name="dwReserved">This parameter is reserved and must be zero.</param>
		/// <param name="ppView">
		/// A pointer to an IOleDocumentView pointer variable that receives the interface pointer to the new document view object. When
		/// successful, the caller is responsible for calling IUnknown::Release on the ppview pointer when the view object is no longer needed.
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
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory available for the operation.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in ppView is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A document object container's document site calls <c>CreateView</c> to instruct a document object to create a new view of
		/// itself in the container's process, either from default data or using the contents of an existing stream.
		/// </para>
		/// <para>
		/// Calling <c>CreateView</c> does not cause the new view to display itself. To do so requires a call to either
		/// IOleDocumentView::Show or IOleDocumentView::UIActivate.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocument-createview HRESULT CreateView(
		// IOleInPlaceSite *pIPSite, IStream *pstm, DWORD dwReserved, IOleDocumentView **ppView );
		[PreserveSig]
		HRESULT CreateView([In, Optional] IOleInPlaceSite? pIPSite, [In, Optional] IStream? pstm, [In, Optional] uint dwReserved, out IOleDocumentView ppView);

		/// <summary>Retrieves status information about the document object.</summary>
		/// <param name="pdwStatus">
		/// A pointer to the information on supported behaviors. Possible values are taken from the DOCMISC enumeration.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pdwStatus is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method provides a way for containers to ascertain whether a document object supports multiple views, complex
		/// rectangles, opening in a pop-up window, or file read/write.
		/// </para>
		/// <para>Values from this enumerator are also stored in the registry as the value of the DocObject key.</para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// By calling this method prior to activating a document object, containers can take whatever steps are necessary to support or
		/// otherwise accommodate the specified behaviors.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// This method must be completely implemented in any document object, even if the dereferenced value of pdwStatus is zero.
		/// E_NOTIMPL is not an acceptable return value. Normally, the returned DOCMISC value should be hard-coded for performance.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocument-getdocmiscstatus HRESULT GetDocMiscStatus(
		// DWORD *pdwStatus );
		[PreserveSig]
		HRESULT GetDocMiscStatus(out DOCMISC pdwStatus);

		/// <summary>
		/// Creates an object that enumerates the views supported by a document object, or if only one view is supported, returns a
		/// pointer to that view.
		/// </summary>
		/// <param name="ppEnum">
		/// A pointer to an IEnumOleDocumentViews pointer variable that receives the interface pointer to the enumerator object.
		/// </param>
		/// <param name="ppView">
		/// A pointer to an IOleDocumentView pointer variable that receives the interface pointer to a single view object.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the object supports multiple views, then ppEnum contains a pointer to the enumerator object, and
		/// ppView is <c>NULL</c>. Otherwise, ppEnum is <c>NULL</c>, and ppView contains an interface pointer on the single view.
		/// </para>
		/// <para>Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory available for the operation.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in ppEnum or ppView is invalid. The caller must pass valid pointers for both arguments.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If a document object supports multiple views of its data, it must also implement IEnumOleDocumentViews and pass that
		/// interface's pointer in the out parameter ppEnum. Using this pointer, the container can enumerate the views supported by the
		/// document object.
		/// </para>
		/// <para>
		/// If the document object supports only a single view, <c>IOleDocument::EnumViews</c> passes that view's IOleDocumentView
		/// pointer in the out parameter ppView.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocument-enumviews HRESULT EnumViews(
		// IEnumOleDocumentViews **ppEnum, IOleDocumentView **ppView );
		[PreserveSig]
		HRESULT EnumViews(out IEnumOleDocumentViews ppEnum, out IOleDocumentView ppView);
	}

	/// <summary>
	/// <para>
	/// Enables a document that has been implemented as a document object to bypass the normal activation sequence for in-place-active
	/// objects and to directly instruct its client site to activate it as a document object. A client site with this ability is called
	/// a document site.
	/// </para>
	/// <para>
	/// For each document object to be hosted, a container must provide a corresponding document site, which is an OLE Documents client
	/// site that, in addition to implementing IOleClientSite and IAdviseSink, also implements <c>IOleDocumentSite</c>. Each document
	/// site implements a separate document view site object for each view of a document to be activated. The document view site
	/// implements IOleInPlaceSite and, optionally, IContinueCallback.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nn-docobj-ioledocumentsite
	[PInvokeData("docobj.h", MSDNShortId = "NN:docobj.IOleDocumentSite")]
	[ComImport, Guid("b722bcc7-4e68-101b-a2bc-00aa00404770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleDocumentSite
	{
		/// <summary>
		/// Asks a document site to activate the document making the call as a document object rather than an in-place-active object
		/// and, optionally, specifies which view of the object document to activate.
		/// </summary>
		/// <param name="pViewToActivate">
		/// A pointer to an IOleDocumentView interface pointer that represents the document view to be used in activating the document
		/// object. This parameter can be <c>NULL</c>, in which case the container should call IOleDocument::CreateView to obtain a
		/// document view pointer.
		/// </param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// <para>
		/// When a container calls IOleObject::DoVerb to activate a document, a document object bypasses the usual in-place activation
		/// sequence by calling <c>IOleDocumentSite::ActivateMe</c>.
		/// </para>
		/// <para>
		/// When calling IOleObject::DoVerb on a document object, the most appropriate activation verb is usually OLEIVERB_SHOW. Other
		/// allowable verbs include OLEIVERB_PRIMARY and OLEIVERB_UIACTIVATE. OLEIVERB_OPEN is discouraged because it means opening an
		/// embedded object in a separate window, which is contrary to the intent of document object activation.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Only document objects should call this method. A normal in-place active document should respond to a container's call to
		/// IOleObject::DoVerb by calling IOleInPlaceSite.
		/// </para>
		/// <para>
		/// A document object should initiate its activation by calling <c>IOleDocumentSite::ActivateMe</c>. If the container does not
		/// implement IOleDocumentSite, then the document should default to the normal in-place activation sequence.
		/// </para>
		/// <para>
		/// A document object that supports more than one view of its data can specify which view to activate by passing a pointer to
		/// that view's IOleDocumentView interface in pViewToActivate.
		/// </para>
		/// <para>However the IOleDocumentView pointer is obtained, the container should release the pointer when it is no longer needed.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// This function must be completely implemented in a document object container; E_NOTIMPL is not an acceptable return value.
		/// </para>
		/// <para>
		/// If a document object passes an IOleDocumentView pointer in pViewToActivate, the container's implementation of
		/// <c>IOleDocumentSite::ActivateMe</c> should call IOleDocumentView::SetInPlaceSite and pass a pointer to its IOleInPlaceSite
		/// interface back to the view object. If the container is holding onto the <c>IOleDocumentView</c> pointer, which will normally
		/// be the case, it should follow the call to <c>IOleDocumentView::SetInPlaceSite</c> with a call to IUnknown::AddRef.
		/// </para>
		/// <para>
		/// If pViewToActivate is <c>NULL</c>, the container can obtain a pointer to a document view by querying the document for
		/// IOleDocument, then calling IOleDocument::CreateView and passing its IOleInPlaceSite pointer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocumentsite-activateme HRESULT ActivateMe(
		// IOleDocumentView *pViewToActivate );
		[PreserveSig]
		HRESULT ActivateMe([In] IOleDocumentView? pViewToActivate);
	}

	/// <summary>
	/// <para>The <c>IOleDocumentView</c> interface enables a container to communicate with each view supported by a document object.</para>
	/// <para>
	/// A document object that supports multiple views of its data represents each view as a separate object. Each document view object
	/// implements <c>IOleDocumentView</c>, along with IOleInPlaceObject, IOleInPlaceActiveObject, and optional interfaces such as
	/// IPrint and IOleCommandTarget. A document object that supports only a single view does not require that view to be implemented as
	/// a separate object. Instead, both document and view can be implemented as a single class.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nn-docobj-ioledocumentview
	[PInvokeData("docobj.h", MSDNShortId = "NN:docobj.IOleDocumentView")]
	[ComImport, Guid("b722bcc6-4e68-101b-a2bc-00aa00404770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleDocumentView
	{
		/// <summary>Associates a container's document view site with a document's view object.</summary>
		/// <param name="pIPSite">
		/// A pointer to the document view site's IOleInPlaceSite interface. This parameter can be <c>NULL</c>, in which case the
		/// document view object loses all asociation with the container.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns S_OK if a document view site was successfully associated (or disassociated if pIPSite is <c>NULL</c>)
		/// with a document view object. Other possible return values include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// As part of activating a document object, a container must pass the object a pointer to the container's implementation of
		/// IOleInPlaceSite. This pointer designates the document view site that is to be associated with the view on which this method
		/// is called.
		/// </para>
		/// <para>
		/// A container normally passes this pointer in response to a document's request to be activated. A document makes such a
		/// request by calling IOleDocumentSite::ActivateMe and passing the container a pointer to the view to be activated. The
		/// container, in turn, uses this pointer to call <c>IOleDocumentView::SetInPlaceSite</c>.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// If the container is requesting creation and activation of a new instance of a document object, rather than merely the
		/// activation of a loaded instance of a document object, the view site is passed in the pIPSite argument of
		/// IOleDocument::CreateView. Therefore, an explicit call to <c>IOleDocumentView::SetInPlaceSite</c> is unnecessary.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// If this method is called on a view that is already associated with a view site, the view must do some housekeeping in
		/// preparation for activating itself in the new site. First, the view must deactivate itself in the current site and release
		/// its pointer to that site. Next, if the new IOleInPlaceSite pointer is not <c>NULL</c>, the view should both save the pointer
		/// and call IUnknown::AddRef on it. The view should then wait for the container to tell it when to activate itself in the new
		/// view site.
		/// </para>
		/// <para>A document view must implement this method completely; E_NOTIMPL is not an acceptable return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocumentview-setinplacesite HRESULT SetInPlaceSite(
		// IOleInPlaceSite *pIPSite );
		[PreserveSig]
		HRESULT SetInPlaceSite([In, Optional] IOleInPlaceSite? pIPSite);

		/// <summary>Retrieves the view site associated with this view object.</summary>
		/// <param name="ppIPSite">
		/// A pointer to an IOleInPlaceSite pointer variable that receives the interface pointer to the document's view site.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible values include:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <c>IOleDocumentView::GetInPlaceSite</c> obtains the most recent IOleInPlaceSite pointer passed by
		/// IOleDocumentView::SetInPlaceSite, or <c>NULL</c> if <c>IOleDocumentView::SetInPlaceSite</c> has not yet been called. If this
		/// pointer is not <c>NULL</c>, this method will call IUnknown::AddRef on the pointer. The caller is responsible for releasing
		/// it. A document view must implement this method completely; E_NOTIMPL is not an acceptable return value.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocumentview-getinplacesite HRESULT GetInPlaceSite(
		// IOleInPlaceSite **ppIPSite );
		[PreserveSig]
		HRESULT GetInPlaceSite(out IOleInPlaceSite ppIPSite);

		/// <summary>Obtains the IUnknown interface pointer on the document object that owns this view.</summary>
		/// <param name="ppunk">
		/// A pointer to an IUnknown interface pointer that receives a pointer to the document object that owns this view.
		/// </param>
		/// <returns>This method returns S_OK on success. S_OK is the only valid return value for this method.</returns>
		/// <remarks>
		/// <para>
		/// The caller is responsible for incrementing the reference count on the interface pointer obtained by this method. The caller
		/// must call IUnknown::Release on this pointer when it is no longer needed.
		/// </para>
		/// <para>
		/// Because a view object must always be contained or aggregated in a document object, this method will always succeed. Before
		/// returning, this method should call IUnknown::AddRef on the pointer stored in ppunk.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocumentview-getdocument HRESULT GetDocument(
		// IUnknown **ppunk );
		[PreserveSig]
		HRESULT GetDocument([Out, MarshalAs(UnmanagedType.IUnknown)] out object ppunk);

		/// <summary>
		/// Sets the rectangular coordinates of the viewport in which the view is to be activated or resets the coordinates of the
		/// viewport in which a view is currently activated.
		/// </summary>
		/// <param name="prcView">A pointer to a RECT structure containing the coordinates of the viewport.</param>
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
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For a single document interface (SDI) application, the viewport is the client area of the frame window minus the space
		/// allocated for toolbars, status bar, and such. For a multiple document interface (MDI) window, the viewport is the client
		/// area of the MDI document window minus any other frame-level user-interface elements.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Calling <c>IOleDocumentView::SetRect</c> or IOleDocumentView::SetRectComplex is part of the normal activation sequece for
		/// document objects, usually following a call to IOleDocumentView::UIActivate and preceding a call to IOleDocumentView::Show.
		/// </para>
		/// <para>
		/// Whenever the window used to display a document object is resized, the container should call <c>IOleDocumentView::SetRect</c>
		/// (or IOleDocumentView::SetRectComplex) to tell the document view object to resize itself to the new window dimensions.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The coordinates of the viewport are within the coordinates of the view window, which is obtained through
		/// IOleWindow::GetWindow. The view must resize itself to fit the new coordinates passed in prcView.
		/// </para>
		/// <para>
		/// This method is defined with the [input_sync] attribute, which means that the view object cannot yield or make another, non
		/// input_sync RPC call while executing this method.
		/// </para>
		/// <para>A document view must implement this method completely; E_NOTIMPL is not an acceptable return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocumentview-setrect HRESULT SetRect( LPRECT prcView );
		[PreserveSig]
		HRESULT SetRect(in RECT prcView);

		/// <summary>Retrieves the rectangular coordinates of the viewport in which the view is or will be activated.</summary>
		/// <param name="prcView">A pointer to a RECT structure to contain the coordinates of the current viewport set with IOleDocumentView::SetRect.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>
		/// This view has not yet seen a call to IOleDocumentView::SetRect or IOleDocumentView::SetRectComplex and therefore has no
		/// rectangle to return.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For a single document interface (SDI) application, the viewport is the client area of the frame window minus the space
		/// allocated for toolbars, status bar, and such. For a multiple document interface (MDI) window, the viewport is the client
		/// area of the MDI document window minus any other frame-level user-interface elements.
		/// </para>
		/// <para>
		/// The viewport coordinates obtained by this method are those set in the most recent call to either IOleDocumentView::SetRect
		/// or IOleDocumentView::SetRectComplex.
		/// </para>
		/// <para>A document view must implement this method completely; E_NOTIMPL is not an acceptable return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocumentview-getrect HRESULT GetRect( LPRECT prcView );
		[PreserveSig]
		HRESULT GetRect(out RECT prcView);

		/// <summary>Sets the rectangular coordinates of the viewport, scroll bars, and size box.</summary>
		/// <param name="prcView">A pointer to a RECT structure containing the coordinates of the viewport.</param>
		/// <param name="prcHScroll">A pointer to a RECT structure containing the coordinates of the horizontal scroll bar.</param>
		/// <param name="prcVScroll">A pointer to a RECT structure containing the coordinates of the vertical scroll bar.</param>
		/// <param name="prcSizeBox">A pointer to a RECT structure containing the coordinates of the size box.</param>
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
		/// <term>E_NOTIMPL</term>
		/// <term>The document object that owns this view does not support complex rectangles.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// View frames that support a workbook metaphor, in which a single document comprises multiple sheets or pages, typically call
		/// this method to set the coordinates to be used in common by all the sheets or pages.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Calling <c>IOleDocumentView::SetRectComplex</c> is part of the normal activation sequence for document objects that support
		/// complex rectangles, usually following a call to IOleDocumentView::UIActivate and preceding a call to IOleDocumentView::Show.
		/// </para>
		/// <para>
		/// Whenever the window used to display a document object is resized, the container should call
		/// <c>IOleDocumentView::SetRectComplex</c> or IOleDocumentView::SetRect to tell the view object to resize itself to the new
		/// window dimensions.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Document objects that support complex rectangles mark themselves with DOCMISC_SUPPORTCOMPLEXRECTANGLES, as described in
		/// <c>DOCMISC</c> and IOleDocument::GetDocMiscStatus. Document objects that do not support this method can return E_NOTIMPL.
		/// </para>
		/// <para>
		/// Upon receiving a call to this method, a view should resize itself to fit the coordinates specified in prcView and fit its
		/// scrollbars and size box to the areas described in prcHScroll, prcVScroll, and prcSizeBox.
		/// </para>
		/// <para>
		/// This method is defined with the [input_sync] attribute, which means that the implementing object cannot yield or make
		/// another, non input_sync RPC call while executing this method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocumentview-setrectcomplex HRESULT SetRectComplex(
		// LPRECT prcView, LPRECT prcHScroll, LPRECT prcVScroll, LPRECT prcSizeBox );
		[PreserveSig]
		HRESULT SetRectComplex([In, Optional] PRECT? prcView, [In, Optional] PRECT? prcHScroll, [In, Optional] PRECT? prcVScroll, [In, Optional] PRECT? prcSizeBox);

		/// <summary>Activates or deactivates a view.</summary>
		/// <param name="fShow">If <c>TRUE</c>, the view is to show itself. If <c>FALSE</c>, the view is to hide itself.</param>
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
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory available for operation.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Calling <c>Show</c> is the last step in the activation sequence, because before showing itself a document object must know
		/// exactly what space it occupies and have all its tools available.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A call to this method for the purpose of activating a view should follow calls to IOleDocumentView::SetInPlaceSite,
		/// IOleDocumentView::UIActivate, and IOleDocumentView::SetRect (or IOleDocumentView::SetRectComplex).
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>Implementations of this method should embody the following pseudocode.</para>
		/// <para>
		/// <code>if (fShow) { In-place activate the view but do not UI activate it. Show the view window. } else { Call IOleDocumentView::UIActivate(FALSE) on this view Hide the view window }</code>
		/// </para>
		/// <para>All views of a document object must at least support in-place activation; E_NOTIMPL is not an acceptable value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocumentview-show HRESULT Show( BOOL fShow );
		[PreserveSig]
		HRESULT Show([MarshalAs(UnmanagedType.Bool)] bool fShow);

		/// <summary>Activates or deactivates a document view's user interface elements, such as menus, toolbars, and accelerators.</summary>
		/// <param name="fUIActivate">
		/// If <c>TRUE</c>, the view is to activate its user interface. If <c>FALSE</c>, the view is to deactivate its user interface.
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
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory available for operation.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Calling this method before calling IOleDocumentView::SetInPlaceSite returns E_UNEXPECTED, because the view must be
		/// associated with a view site before it can activate itself.
		/// </para>
		/// <para>
		/// When <c>IOleDocumentView::UIActivate</c> is called as part of the activation sequence, the call should precede a call to
		/// IOleDocumentView::SetRect or IOleDocumentView::SetRectComplex, because otherwise the view dimensions would not account for
		/// toolbar space.
		/// </para>
		/// <para>
		/// To deactivate a view, the container should call IOleDocumentView::Show with <c>FALSE</c>, followed by
		/// <c>IOleDocumentView::UIActivate</c> with <c>FALSE</c>.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>Implementations of this method should embody the following pseudocode.</para>
		/// <para>
		/// <code>if (fActivate) { UI activate the view (do menu merging, show frame level tools, process accelerators) Take focus, and bring the view window forward. } else call IOleInPlaceObject::UIDeactivate on this view</code>
		/// </para>
		/// <para>In addition, the view can and should participate in extended <c>Help</c> menu merging.</para>
		/// <para>All views of a document object must support in-place activation. E_NOTIMPL is not an acceptable return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocumentview-uiactivate HRESULT UIActivate( BOOL
		// fUIActivate );
		[PreserveSig]
		HRESULT UIActivate([MarshalAs(UnmanagedType.Bool)] bool fUIActivate);

		/// <summary>
		/// Displays a document view in a separate pop-up window. The semantics are equivalent to IOleObject::DoVerb with OLEIVERB_OPEN.
		/// </summary>
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
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory available for the operation.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The document object that owns this view does not support separate window activation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A user viewing a document object in a container application such as a browser or "binder" may want to see two or more views
		/// or documents at once. Because the browser displays only one view at a time, the container needs a way to ask the other views
		/// or documents to display themselves, as required, in separate windows. The <c>IOleDocumentView::Open</c> method provides that way.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A successful call to <c>IOleDocumentView::Open</c> should be followed by a call to IOleDocumentView::Show to hide the window
		/// or to show the window and bring it to the foreground. While the view is active in its separate window, a container can show
		/// or hide the window as many times as it may require.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// A document object indicates that it does not support activation in a separate window by setting the DOCMISC_CANTOPENEDIT
		/// status flag and returning E_NOTIMPL to containers that call this method.
		/// </para>
		/// <para>
		/// Implementation consists mainly of the view object calling its own IOleInPlaceObject::InPlaceDeactivate method, which leaves
		/// the document object in a running state but without in-place activation. The document object's user interface is not visible
		/// until the container calls IOleDocumentView::Show (see Notes to Callers above).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocumentview-open HRESULT Open();
		[PreserveSig]
		HRESULT Open();

		/// <summary>Instructs a document view to close itself and release its IOleInPlaceSite pointer.</summary>
		/// <param name="dwReserved">This parameter is reserved and cannot be <c>NULL</c>.</param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// <para>
		/// When a separate window is no longer needed, the container calls <c>IOleDocumentView::CloseView</c>, whereupon the view
		/// releases its site pointer to the separate window and destroys the window. Unlike the normal in-place deactivation sequence
		/// for active documents, a document view continues to hold the IOleInPlaceSite pointer. This pointer is released only when the
		/// view's container calls SetInPlaceSite, with pIPSite set to <c>NULL</c>, or calls <c>IOleDocumentView::CloseView</c>.
		/// </para>
		/// <para>
		/// When a user closes a view's separate window, the view should not shut itself down. Instead, it should call
		/// IOleInPlaceSite::OnInPlaceActivate. The view site then decides whether to call IOleDocumentView::UIActivate with
		/// <c>FALSE</c> immediately or later. In this way, a document view displayed in a separate window remains available for
		/// activation in the container's own window.
		/// </para>
		/// <para>
		/// The container must call this method before it deletes the view, that is, releases its last reference to the view. In
		/// general, implementation of this method will call IOleDocumentView::Show with <c>FALSE</c> to hide the view if it is not
		/// already hidden, then call SetInPlaceSite with <c>NULL</c> to deactivate itself and release the view site pointer.
		/// </para>
		/// <para>
		/// Because <c>IOleDocumentView::CloseView</c> is called when a container is going to completely shut down a view, this method
		/// must be implemented and has no reason to fail.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocumentview-closeview HRESULT CloseView( DWORD
		// dwReserved );
		[PreserveSig]
		HRESULT CloseView([In, Optional] uint dwReserved);

		/// <summary>Saves the view state into the specified stream.</summary>
		/// <param name="pstm">A pointer to the stream in which the view is to save its state data.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value in pstm is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>
		/// This view has no meaningful state to save. This error should be rare because most views have at least some state information
		/// worth saving.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The view's state includes properties such as the view type, zoom factor, and location of insertion point. The container
		/// typically calls this function before deactivating the view. The stream can then later be used to reinitialize a view of the
		/// same document to this saved state through IOleDocumentView::ApplyViewState.
		/// </para>
		/// <para>
		/// According to the rules governing IPersistStream, a view must write its CLSID as the first element in the stream. Any
		/// cross-platform file format compatibility issues that apply to the document's storage representation also apply to this context.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocumentview-saveviewstate HRESULT SaveViewState(
		// LPSTREAM pstm );
		[PreserveSig]
		HRESULT SaveViewState(IStream pstm);

		/// <summary>Initializes a view with view state previously saved in call to IOleDocumentView::SaveViewState.</summary>
		/// <param name="pstm">A pointer to a stream containing data from which the view should initialize itself.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value in pstm is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>
		/// This view has no meaningful state to load. This error should be rare because most views will have at least some state
		/// information worth loading.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Typically, this function is called after an existing view has been created in the container but before that view has been
		/// displayed. It is the responsibility of the view to validate the data in the view stream; the container does not attempt to
		/// interpret the view's state data.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocumentview-applyviewstate HRESULT ApplyViewState(
		// LPSTREAM pstm );
		[PreserveSig]
		HRESULT ApplyViewState(IStream pstm);

		/// <summary>Creates a duplicate view object with an internal state identical to that of the current view.</summary>
		/// <param name="pIPSiteNew">
		/// A pointer to a IOleInPlaceSite interface that represents the view site in which the new view object will be activated. On
		/// receiving this pointer, the view being cloned should pass it to the new view's IOleDocumentView::SetInPlaceSite method. This
		/// pointer can be <c>NULL</c>, in which case the caller is responsible for calling <c>IOleDocumentView::SetInPlaceSite</c> on
		/// the new view directly.
		/// </param>
		/// <param name="ppViewNew">
		/// A pointer to an IOleDocumentView pointer variable that receives the interface pointer to the new view object. The caller is
		/// responsible for releasing ppViewNew when it is no longer needed.
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
		/// <term>E_POINTER</term>
		/// <term>The value in ppViewNew is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The view object does not implement this interface.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method is useful for creating a new view with a different viewport and view site but with the same view context as the
		/// view being cloned. Typically, containers hosting an MDI application will call this method to provide "Window/New window" capability.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-ioledocumentview-clone HRESULT Clone( IOleInPlaceSite
		// *pIPSiteNew, IOleDocumentView **ppViewNew );
		[PreserveSig]
		HRESULT Clone(IOleInPlaceSite? pIPSiteNew, out IOleDocumentView ppViewNew);
	}

	/// <summary>Enables compound documents in general and active documents in particular to support programmatic printing.</summary>
	/// <remarks>
	/// <para>
	/// After a document is loaded, containers and other clients can call IPrint::Print to instruct a document to print itself,
	/// specifying printing control flags, the target device, the particular pages to print, and other options. The client can control
	/// the continuation of printing by calling the IContinueCallback interface.
	/// </para>
	/// <para>An object that implements <c>IPrint</c> registers itself with the <c>Printable</c> key stored under its CLSID as follows:</para>
	/// <para><c>HKEY_CLASSES_ROOT\CLSID{...}\Printable</c></para>
	/// <para>
	/// Callers determine whether a particular object class supports programmatic printing of its persistent state by looking in the
	/// registry for this key.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nn-docobj-iprint
	[PInvokeData("docobj.h", MSDNShortId = "NN:docobj.IPrint")]
	[ComImport, Guid("b722bcc9-4e68-101b-a2bc-00aa00404770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPrint
	{
		/// <summary>Sets the page number of the first page of a document.</summary>
		/// <param name="nFirstPage">The page number of the first page.</param>
		/// <returns>This method can return the standard return values E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		/// <remarks>
		/// <para>
		/// Setting the first page to a negative number is valid. This may be useful in printing a portion of the document with page
		/// numbers that specify an offset from the usual pagination.
		/// </para>
		/// <para>
		/// Not all implementations permit the initial page number to be set, as some implementations simply lack the information as to
		/// how the page number should be presented in the final output.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-iprint-setinitialpagenum HRESULT SetInitialPageNum( LONG
		// nFirstPage );
		[PreserveSig]
		HRESULT SetInitialPageNum(int nFirstPage);

		/// <summary>Retrieves the number of a document's first page and the total number of pages.</summary>
		/// <param name="pnFirstPage">
		/// A pointer to a variable that receives the page number of the first page. This parameter can be <c>NULL</c>, indicating that
		/// the caller is not interested in this number. If IPrint::SetInitialPageNum has been called, this parameter should contain the
		/// same value passed to that method. Otherwise, the value is the document's internal first page number.
		/// </param>
		/// <param name="pcPages">
		/// A pointer to a variable that receives the total number of pages in this document. This parameter can be <c>NULL</c>,
		/// indicating that the caller is not interested in this number.
		/// </param>
		/// <returns>This method can return the standard return values E_UNEXPECTED and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-iprint-getpageinfo HRESULT GetPageInfo( LONG
		// *pnFirstPage, LONG *pcPages );
		[PreserveSig]
		HRESULT GetPageInfo(out int pnFirstPage, out int pcPages);

		/// <summary>Prints an object on the specified printer, using the specified job requirements.</summary>
		/// <param name="grfFlags">
		/// <para>A bitfield specifying print options from the <c>PRINTFLAG</c> enumeration.</para>
		/// <para>PRINTFLAG_MAYBOTHERUSER (1)</para>
		/// <para>PRINTFLAG_PROMPTUSER (2)</para>
		/// <para>PRINTFLAG_USERMAYCHANGEPRINTER (4)</para>
		/// <para>PRINTFLAG_RECOMPOSETODEVICE (8)</para>
		/// <para>PRINTFLAG_DONTACTUALLYPRINT (16)</para>
		/// <para>PRINTFLAG_FORCEPROPERTIES (32)</para>
		/// <para>PRINTFLAG_PRINTTOFILE (64)</para>
		/// </param>
		/// <param name="pptd">A pointer to a DVTARGETDEVICE structure that describes the target print device.</param>
		/// <param name="ppPageSet">
		/// A pointer to a PAGESET pointer variable that receives a pointer to the structure that indicates which pages are to be printed.
		/// </param>
		/// <param name="pstgmOptions">
		/// A pointer to object-specific printing options in a serialized OLE property set. This parameter can be <c>NULL</c> on input
		/// or return.
		/// </param>
		/// <param name="pcallback">
		/// A pointer to the IContinueCallback interface on the view site, which is to be periodically polled at human-response speeds
		/// to determine whether printing should be abandoned. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="nFirstPage">
		/// The page number of the first page to be printed. This value overrides any value previously passed to IPrint::SetInitialPageNum.
		/// </param>
		/// <param name="pcPagesPrinted">A pointer to a variable that receives the actual number of pages that were successfully printed.</param>
		/// <param name="pnLastPage">A pointer to a variable that receives the page number of the last page that was printed.</param>
		/// <returns>
		/// <para>This method can return the standard return value E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>PRINT_E_CANCELED</term>
		/// <term>
		/// The print process was canceled before completion. *pcPagesPrinted indicates the number of pages that were in fact
		/// successfully printed before this error occurred.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PRINT_E_NOSUCHPAGE</term>
		/// <term>A page specified in **ppPageSet or nFirstPage does not exist.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The printer on which the object is to be printed is indicated by the DVTARGETDEVICE structure pointed to by pptd. The
		/// DEVMODE structure in the target device indicates whole-job printer-specific options, such as number of copies, paper size,
		/// and print quality. The <c>DEVMODE</c> structure may also contain orientation information in the <c>dmOrientation</c> member
		/// (this is indicated in the <c>dmFields</c> member). If present, then this paper orientation should be used; if absent, then
		/// natural orientation as determined by the object content is to be used.
		/// </para>
		/// <para>
		/// Due to the possibility of user input, the parameters pptd and ppPageSet are both [in,out] structures. In the absence of user
		/// interaction (that is, if the PRINTFLAG_PROMPTUSER flag is not set), both the target device and the page set will necessarily
		/// be the same for input and output. However, if the user is prompted for print options, then the object returns target device
		/// and page-set information appropriate to what the user has actually chosen.
		/// </para>
		/// <para>
		/// The pstgmOptions parameter is also [in,out]. On exit, the object should write to *pstgmOptions any object-specific
		/// information that it would need to reproduce this exact print job. Examples might include whether the user selected "sheet,
		/// notes, or both" in a spreadsheet application. The data passed is in the format of a serialized property set. The data is
		/// normally useful only when passed back in a subsequent call to the same object. Because a subsequent call may specify
		/// different user interaction flags, target device, or other settings, the caller can cause the document to be printed multiple
		/// times in the same way in slightly different printing contexts.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/docobj/nf-docobj-iprint-print HRESULT Print( DWORD grfFlags,
		// DVTARGETDEVICE **pptd, PAGESET **ppPageSet, STGMEDIUM *pstgmOptions, IContinueCallback *pcallback, LONG nFirstPage, LONG
		// *pcPagesPrinted, LONG *pnLastPage );
		[PreserveSig]
		HRESULT Print(PRINTFLAG grfFlags, [In, Out] IntPtr /*DVTARGETDEVICE** */ pptd, [In, Out] IntPtr /*PAGESET***/ ppPageSet,
			[In, Out, Optional] IntPtr /*STGMEDIUM**/ pstgmOptions, [In] IContinueCallback? pcallback, int nFirstPage,
			out int pcPagesPrinted, out int pnLastPage);
	}

	/// <summary>Enables embedded documents to correctly merge menus with Windows Internet Explorer 7 in Protected Mode.</summary>
	/// <remarks>
	/// <para>
	/// Typically, a menu merge requires an Active document (DocObject) to create and own the menu object. When the DocObject server is
	/// hosted from an out-of-proc, medium integrity level process in Protected Mode, a standard menu merge causes the menu to be
	/// nonfunctional. Internet Explorer 7 in Protected Mode is a low integrity level process and the out-of-proc DocObject server is a
	/// medium integrity level process, so the User Interface Privilege Isolation (UIPI) mechanism of Windows Vista prevents Internet
	/// Explorer 7 from accessing or expanding the menus.
	/// </para>
	/// <para>
	/// The <c>IProtectedModeMenuServices</c> interface is implemented by the DocObject host (Internet Explorer 7) and can be queried by using
	/// <code>IID_IProtectedModeMenuServices</code>
	/// from the <c>IOleInPlaceFrame</c> interface used by DocObject servers for menu merging.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa767957(v=vs.85)
	[PInvokeData("Docobj.h")]
	[ComImport, Guid("73c105ee-9dff-4a07-b83c-7eff290c266e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IProtectedModeMenuServices
	{
		/// <summary>Creates an empty low integrity menu.</summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa767956(v=vs.85)
		// HRESULT CreateMenu( [out] HMENU *phMenu );
		[PreserveSig]
		HRESULT CreateMenu(out HMENU phMenu);

		/// <summary>Creates a low integrity menu from a named resource.</summary>
		/// <param name="pszModuleName">
		/// [in] A pointer to a null-terminated string that specifies the name of language-neutral resource DLL or executable. The name
		/// of the folder that contains the language-specific resource files is interpreted by using language name format. See
		/// <c>LoadMUILibrary</c> for more information.
		/// </param>
		/// <param name="pszMenuName">[in] A pointer to a null-terminated string that specifies the named menu resource.</param>
		/// <param name="phMenu">[out] A variable that receives a handle to the low integrity menu.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa767958(v=vs.85)
		// HRESULT LoadMenu( [in] LPCWSTR pszModuleName, [in] LPCWSTR pszMenuName, [out] HMENU *phMenu );
		[PreserveSig]
		HRESULT LoadMenu([MarshalAs(UnmanagedType.LPWStr)] string pszModuleName, [MarshalAs(UnmanagedType.LPWStr)] string pszMenuName, out HMENU phMenu);

		/// <summary>Creates a low integrity menu from a resource ID.</summary>
		/// <param name="pszModuleName">
		/// [in] A pointer to a null-terminated string that specifies the name of language-neutral resource DLL or executable. The name
		/// of the folder that contains the language-specific resource files is interpreted by using language name format. See
		/// <c>LoadMUILibrary</c> for more information.
		/// </param>
		/// <param name="wResourceID">[in] An unsigned integer that specifies the menu resource by ID.</param>
		/// <param name="phMenu">[out] A variable that receives a handle to the low integrity menu.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa767959(v=vs.85)
		// HRESULT LoadMenuID( [in] LPCWSTR pszModuleName, [in] WORD wResourceID, [out] HMENU *phMenu );
		[PreserveSig]
		HRESULT LoadMenuID([MarshalAs(UnmanagedType.LPWStr)] string pszModuleName, ushort wResourceID, out HMENU phMenu);
	}

	/// <summary>Provides a method that queries for permission to grab the focus.</summary>
	/// <remarks>
	/// <para><c>IProtectFocus</c> was introduced in Windows Internet Explorer 7.</para>
	/// <para>Hosts of MSHTML and the Web Browser control should respond to a <c>IServiceProvider::QueryService</c> for
	/// <code>SID_SProtectFocus</code>
	/// .
	/// </para>
	/// <para>
	/// Implement this interface to prevent web pages hosted in MSHTML or the Web Browser control from stealing focus from other parts
	/// of the user interface, for example when a user is entering data into an edit field in the host application.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa770059(v=vs.85)
	[PInvokeData("Docobj.h")]
	[ComImport, Guid("d81f90a3-8156-44f7-ad28-5abb87003274"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IProtectFocus
	{
		/// <summary>Queries for permission to grab the focus when loading the page or when a script attempts to focus an element.</summary>
		/// <param name="pfAllow">
		/// <para>[out] Type: <c>BOOL</c></para>
		/// <para>Indicates whether permission was obtained to grab focus.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks><c>IProtectFocus::AllowFocusChange</c> was introduced in Windows Internet Explorer 7.</remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa770058(v=vs.85)
		// HRESULT retVal = object.AllowFocusChange(pfAllow);
		[PreserveSig]
		HRESULT AllowFocusChange([MarshalAs(UnmanagedType.Bool)] out bool pfAllow);
	}

	/// <summary>Provides a method that notifies hosts of changes in the zoom state.</summary>
	/// <remarks>
	/// <para><c>IZoomEvents</c> was introduced in Windows Internet Explorer 7.</para>
	/// <para>
	/// To be notified of changes in the zoom level of a Web page, hosts of MSHTML should implement this interface on the same object
	/// that implements IOleClientSite. The WebBrowser control does not delegate IZoomEvents to its host.
	/// </para>
	/// <para>
	/// <c>Note</c> The optical zoom keyboard shortcuts (CTRL+mouse wheel forward/back, CTRL+PLUS SIGN, and CTRL+MINUS SIGN) are not
	/// enabled by default when hosting the WebBrowser control. To enable this behavior, call <c>IWebBrowser2::ExecWB</c> with
	/// OLECMDID_OPTICAL_ZOOM, passing
	/// <code>100</code>
	/// in pvaIn. Once set, the keyboard shortcuts remain available as long as the host navigates to HTML content because the same
	/// instance of MSHTML is used. However, if the host navigates to Active documents, such as XML or Portable Document Format (PDF)
	/// files, optical zoom is disabled and will need to be enabled again.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa770056(v=vs.85)
	[PInvokeData("Docobj.h")]
	[ComImport, Guid("41B68150-904C-4e17-A0BA-A438182E359D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IZoomEvents
	{
		/// <summary>Notifies hosts of changes in the zoom state.</summary>
		/// <param name="ulZoomPercent">The ul zoom percent.</param>
		/// <returns></returns>
		// https://docs.microsoft.com/en-us/previous-versions/aa770057(v=vs.85)
		[PreserveSig]
		HRESULT OnZoomPercentChanged(uint ulZoomPercent);
	}

	/// <summary>Associates command flags from the OLECMDF enumeration with a command identifier through a call to IOleCommandTarget::QueryStatus.</summary>
	[PInvokeData("docobj.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct OLECMD
	{
		/// <summary>A command identifier; taken from the OLECMDID enumeration.</summary>
		public OLECMDID cmdID;

		/// <summary>Flags associated with cmdID; taken from the OLECMDF enumeration.</summary>
		public OLECMDF cmdf;
	}

	/// <summary>Specifies a text name or status string for a single command identifier.</summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct OLECMDTEXT
	{
		/// <summary>
		/// A value from the OLECMDTEXTF enumeration describing whether the <see cref="rgwz"/> member contains a command name or status text.
		/// </summary>
		public OLECMDTEXTF cmdtextf;

		/// <summary>
		/// The number of characters actually written into the <see cref="rgwz"/> buffer before IOleCommandTarget::QueryStatus returns.
		/// </summary>
		private uint cwActual;

		/// <summary>The number of elements in the <see cref="rgwz"/> array.</summary>
		public readonly uint cwBuf;

		private readonly PWSTR _rgwz;

#pragma warning disable IDE1006 // Naming Styles

		/// <summary>
		/// Gets or sets the command name or status text. When setting, this value must not be longer than <see cref="cwBuf"/> and the
		/// <see cref="cwActual"/> field will be updated based on the character count of the value provided.
		/// </summary>
		public string? rgwz
#pragma warning restore IDE1006 // Naming Styles
		{
			get => cwBuf > 0 ? _rgwz.ToString() : null;
			set
			{
				value ??= string.Empty;
				if (value.Length + 1 > cwBuf)
					throw new ArgumentOutOfRangeException(nameof(rgwz), "Set value must be of a length that will fit into supplied buffer of length 'cwBuf'.");
				unsafe
				{
					fixed (char* p = value)
					{
						var dest = (byte*)(IntPtr)_rgwz;
						Encoding.Unicode.GetEncoder().Convert(p, value.Length, dest, (int)cwBuf, true, out var actual, out var offset, out var _);
						cwActual = (uint)actual;
						dest[offset] = dest[offset + 1] = 0;
					}
				}
			}
		}

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => rgwz ?? string.Empty;
	}

	/// <summary>Specifies a range of pages.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/docobj/ns-docobj-pagerange typedef struct tagPAGERANGE { LONG nFromPage; LONG
	// nToPage; } PAGERANGE;
	[PInvokeData("docobj.h", MSDNShortId = "NS:docobj.tagPAGERANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PAGERANGE
	{
		/// <summary>
		/// The first page of the range. This member can have any page number as a value. If this value is greater than the value
		/// specified in <c>nToPage</c>, the document will be printed in reverse page order.
		/// </summary>
		public int nFromPage;

		/// <summary>
		/// The last page of the range. A special value, <c>PAGESET_TOLASTPAGE</c>, indicates that all the remaining pages should be
		/// printed. This member can have any page number as a value. If this value is less than the value specified in
		/// <c>nFromPage</c>, the document will be printed in reverse page order.
		/// </summary>
		public int nToPage;
	}

	/// <summary>
	/// Identifies one or more page-ranges to be printed and, optionally, identifies only the even or odd pages as part of a pageset.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/docobj/ns-docobj-pageset typedef struct tagPAGESET { ULONG cbStruct; BOOL
	// fOddPages; BOOL fEvenPages; ULONG cPageRange; PAGERANGE rgPages[1]; } PAGESET;
	[PInvokeData("docobj.h", MSDNShortId = "NS:docobj.tagPAGESET")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<PAGESET>), nameof(cPageRange))]
	[StructLayout(LayoutKind.Sequential)]
	public struct PAGESET
	{
		/// <summary>The number of bytes in this instance of the <c>PAGESET</c> structure. This member must be a multiple of 4.</summary>
		public uint cbStruct;

		/// <summary>If <c>TRUE</c>, only the odd-numbered pages in the page-set indicated by <c>rgPages</c> are to be printed.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fOddPages;

		/// <summary>If <c>TRUE</c>, only the even-numbered pages in the page-set indicated by <c>rgPages</c> are to be printed.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fEvenPages;

		/// <summary>The number of page-range pairs specified in <c>rgPages</c>.</summary>
		public uint cPageRange;

		/// <summary>
		/// Pointer to an array of PAGERANGE structures specifying the pages to be printed. One or more page ranges can be specified, so
		/// long as the number of page ranges is the value of <c>cPageRange</c>. The page ranges must be sorted in ascending order and
		/// must be non-overlapping.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public PAGERANGE[] rgPages;
	}
}