using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
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

		/// <summary>
		/// <para>
		/// Enables objects and their containers to dispatch commands to each other. For example, an object's toolbars may contain buttons
		/// for commands such as <c>Print</c>, <c>Print Preview</c>, <c>Save</c>, <c>New</c>, and <c>Zoom</c>.
		/// </para>
		/// <para>
		/// Normal in-place activation guidelines recommend that you remove or disable such buttons because no efficient, standard mechanism
		/// has been available to dispatch them to the container. Similarly, a container has heretofore had no efficient means to send
		/// commands such as <c>Print</c>, <c>Page Setup</c>, and <c>Properties</c> to an in-place active object. Such simple command routing
		/// could have been handled through existing OLE Automation standards and the <c>IDispatch</c> interface, but the overhead with
		/// IDispatch is more than is required in the case of document objects. The <c>IOleCommandTarget</c> interface provides a simpler
		/// means to achieve the same ends.
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
			HRESULT QueryStatus(in Guid pguidCmdGroup, uint cCmds, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] OLECMD[] prgCmds, OLECMDTEXT pCmdText);

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
			HRESULT Exec(in Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, in object pvaIn, ref object pvaOut);
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

			/// <summary>The number of characters actually written into the <see cref="rgwz"/> buffer before IOleCommandTarget::QueryStatus returns.</summary>
			private uint cwActual;

			/// <summary>The number of elements in the <see cref="rgwz"/> array.</summary>
			public readonly uint cwBuf;

			private readonly IntPtr _rgwz;

#pragma warning disable IDE1006 // Naming Styles
			/// <summary>
			/// Gets or sets the command name or status text. When setting, this value must not be longer than <see cref="cwBuf"/> and the
			/// <see cref="cwActual"/> field will be updated based on the character count of the value provided.
			/// </summary>
			public string rgwz
#pragma warning restore IDE1006 // Naming Styles
			{
				get => cwBuf > 0 ? StringHelper.GetString(_rgwz, CharSet.Unicode) : null;
				set
				{
					if (value == null) value = string.Empty;
					if (value.Length + 1 > cwBuf)
						throw new ArgumentOutOfRangeException(nameof(rgwz), "Set value must be of a length that will fit into supplied buffer of length 'cwBuf'.");
					unsafe
					{
						fixed (char* p = value)
						{
							var dest = (byte*)_rgwz;
							System.Text.Encoding.Unicode.GetEncoder().Convert(p, value.Length, dest, (int)cwBuf, true, out var actual, out var offset, out var _);
							cwActual = (uint)actual;
							dest[offset] = dest[offset + 1] = 0;
						}
					}
				}
			}

			/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
			/// <returns>A <see cref="string"/> that represents this instance.</returns>
			public override string ToString() => rgwz;
		}
	}
}