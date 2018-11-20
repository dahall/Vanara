using System;
using System.Runtime.InteropServices;

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

		public enum OLECMDID
		{
			OLECMDID_OPEN = 1,
			OLECMDID_NEW = 2,
			OLECMDID_SAVE = 3,
			OLECMDID_SAVEAS = 4,
			OLECMDID_SAVECOPYAS = 5,
			OLECMDID_PRINT = 6,
			OLECMDID_PRINTPREVIEW = 7,
			OLECMDID_PAGESETUP = 8,
			OLECMDID_SPELL = 9,
			OLECMDID_PROPERTIES = 10,
			OLECMDID_CUT = 11,
			OLECMDID_COPY = 12,
			OLECMDID_PASTE = 13,
			OLECMDID_PASTESPECIAL = 14,
			OLECMDID_UNDO = 15,
			OLECMDID_REDO = 16,
			OLECMDID_SELECTALL = 17,
			OLECMDID_CLEARSELECTION = 18,
			OLECMDID_ZOOM = 19,
			OLECMDID_GETZOOMRANGE = 20,
			OLECMDID_UPDATECOMMANDS = 21,
			OLECMDID_REFRESH = 22,
			OLECMDID_STOP = 23,
			OLECMDID_HIDETOOLBARS = 24,
			OLECMDID_SETPROGRESSMAX = 25,
			OLECMDID_SETPROGRESSPOS = 26,
			OLECMDID_SETPROGRESSTEXT = 27,
			OLECMDID_SETTITLE = 28,
			OLECMDID_SETDOWNLOADSTATE = 29,
			OLECMDID_STOPDOWNLOAD = 30,
			OLECMDID_ONTOOLBARACTIVATED = 31,
			OLECMDID_FIND = 32,
			OLECMDID_DELETE = 33,
			OLECMDID_HTTPEQUIV = 34,
			OLECMDID_HTTPEQUIV_DONE = 35,
			OLECMDID_ENABLE_INTERACTION = 36,
			OLECMDID_ONUNLOAD = 37,
			OLECMDID_PROPERTYBAG2 = 38,
			OLECMDID_PREREFRESH = 39,
			OLECMDID_SHOWSCRIPTERROR = 40,
			OLECMDID_SHOWMESSAGE = 41,
			OLECMDID_SHOWFIND = 42,
			OLECMDID_SHOWPAGESETUP = 43,
			OLECMDID_SHOWPRINT = 44,
			OLECMDID_CLOSE = 45,
			OLECMDID_ALLOWUILESSSAVEAS = 46,
			OLECMDID_DONTDOWNLOADCSS = 47,
			OLECMDID_UPDATEPAGESTATUS = 48,
			OLECMDID_PRINT2 = 49,
			OLECMDID_PRINTPREVIEW2 = 50,
			OLECMDID_SETPRINTTEMPLATE = 51,
			OLECMDID_GETPRINTTEMPLATE = 52,
			OLECMDID_PAGEACTIONBLOCKED = 55,
			OLECMDID_PAGEACTIONUIQUERY = 56,
			OLECMDID_FOCUSVIEWCONTROLS = 57,
			OLECMDID_FOCUSVIEWCONTROLSQUERY = 58,
			OLECMDID_SHOWPAGEACTIONMENU = 59,
			OLECMDID_ADDTRAVELENTRY = 60,
			OLECMDID_UPDATETRAVELENTRY = 61,
			OLECMDID_UPDATEBACKFORWARDSTATE = 62,
			OLECMDID_OPTICAL_ZOOM = 63,
			OLECMDID_OPTICAL_GETZOOMRANGE = 64,
			OLECMDID_WINDOWSTATECHANGED = 65,
			OLECMDID_ACTIVEXINSTALLSCOPE = 66,
			OLECMDID_UPDATETRAVELENTRY_DATARECOVERY = 67,
			OLECMDID_SHOWTASKDLG = 68,
			OLECMDID_POPSTATEEVENT = 69,
			OLECMDID_VIEWPORT_MODE = 70,
			OLECMDID_LAYOUT_VIEWPORT_WIDTH = 71,
			OLECMDID_VISUAL_VIEWPORT_EXCLUDE_BOTTOM = 72,
			OLECMDID_USER_OPTICAL_ZOOM = 73,
			OLECMDID_PAGEAVAILABLE = 74,
			OLECMDID_GETUSERSCALABLE = 75,
			OLECMDID_UPDATE_CARET = 76,
			OLECMDID_ENABLE_VISIBILITY = 77,
			OLECMDID_MEDIA_PLAYBACK = 78,
			OLECMDID_SETFAVICON = 79,
			OLECMDID_SET_HOST_FULLSCREENMODE = 80,
			OLECMDID_EXITFULLSCREEN = 81,
			OLECMDID_SCROLLCOMPLETE = 82,
			OLECMDID_ONBEFOREUNLOAD = 83,
			OLECMDID_SHOWMESSAGE_BLOCKABLE = 84,
			OLECMDID_SHOWTASKDLG_BLOCKABLE = 85,
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
		/// IOleCommandTarget::QueryStatus. One value from this enumeration is stored the cmdtextf member of the OLECMDTEXT structure to
		/// indicate the desired information.
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
			/// method fills the cmdf member of each structure with values taken from the OLECMDF enumeration.
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
		public class OLECMDTEXT : IDisposable
		{
			/// <summary>
			/// A value from the OLECMDTEXTF enumeration describing whether the rgwz member contains a command name or status text.
			/// </summary>
			public OLECMDTEXTF cmdtextf;

			/// <summary>The number of characters actually written into the rgwz buffer before IOleCommandTarget::QueryStatus returns.</summary>
			public uint cwActual;

			/// <summary>The number of elements in the rgwz array.</summary>
			public uint cwBuf;

			private InteropServices.StrPtrUni _rgwz;

			public OLECMDTEXT(OLECMDTEXTF cmdtextf, string nameOrStatus)
			{
				this.cmdtextf = cmdtextf;
				if (nameOrStatus != null)
					rgwz = nameOrStatus;
			}

			/// <summary>The command name or status text.</summary>
			public string rgwz
			{
				get => _rgwz;
				set { if (value == null) _rgwz.Free(); else _rgwz.Assign(value, out cwActual); }
			}

			/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
			/// <returns>A <see cref="string"/> that represents this instance.</returns>
			public override string ToString() => rgwz;

			void IDisposable.Dispose() => _rgwz.Free();
		}
	}
}