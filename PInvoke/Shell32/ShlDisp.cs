using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Specifies values used by IAutoComplete2::GetOptions and IAutoComplete2::SetOptions for options surrounding autocomplete.</summary>
	[PInvokeData("shldisp.h")]
	[Flags]
	public enum AUTOCOMPLETEOPTIONS
	{
		/// <summary>Do not autocomplete.</summary>
		ACO_NONE = 0,

		/// <summary>Enable the autosuggest drop-down list.</summary>
		ACO_AUTOSUGGEST = 0x1,

		/// <summary>Enable autoappend.</summary>
		ACO_AUTOAPPEND = 0x2,

		/// <summary>Add a search item to the list of completed strings. When the user selects this item, it launches a search engine.</summary>
		ACO_SEARCH = 0x4,

		/// <summary>Do not match common prefixes, such as "www." or "http://".</summary>
		ACO_FILTERPREFIXES = 0x8,

		/// <summary>Use the TAB key to select an item from the drop-down list.</summary>
		ACO_USETAB = 0x10,

		/// <summary>Use the UP ARROW and DOWN ARROW keys to display the autosuggest drop-down list.</summary>
		ACO_UPDOWNKEYDROPSLIST = 0x20,

		/// <summary>
		/// Normal windows display text left-to-right (LTR). Windows can be mirrored to display languages such as Hebrew or Arabic that
		/// read right-to-left (RTL). Typically, control text is displayed in the same direction as the text in its parent window. If
		/// ACO_RTLREADING is set, the text reads in the opposite direction from the text in the parent window.
		/// </summary>
		ACO_RTLREADING = 0x40,

		/// <summary>
		/// Windows Vista and later. If set, the autocompleted suggestion is treated as a phrase for search purposes. The suggestion,
		/// Microsoft Office, would be treated as "Microsoft Office" (where both Microsoft AND Office must appear in the search results).
		/// </summary>
		ACO_WORD_FILTER = 0x80,

		/// <summary>
		/// Windows Vista and later. Disable prefix filtering when displaying the autosuggest dropdown. Always display all suggestions.
		/// </summary>
		ACO_NOPREFIXFILTERING = 0x100
	}

	/// <summary>The offline status of the folder.</summary>
	[PInvokeData("shldisp.h")]
	[Guid("35F1A0D0-3E9A-11D2-8499-005345000000")]
	public enum OfflineFolderStatus
	{
		/// <summary>Server is online with unsynchronized changes.</summary>
		OFS_DIRTYCACHE = 3,

		/// <summary>Offline caching is not enabled for this folder.</summary>
		OFS_INACTIVE = -1,

		/// <summary>Server is offline.</summary>
		OFS_OFFLINE = 1,

		/// <summary>Server is online.</summary>
		OFS_ONLINE = 0,

		/// <summary>Server is offline but can be reached.</summary>
		OFS_SERVERBACK = 2
	}

	/// <summary>Specifies the view options returned by the ViewOptions property.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shldisp/ne-shldisp-shellfolderviewoptions typedef enum ShellFolderViewOptions {
	// SFVVO_SHOWALLOBJECTS, SFVVO_SHOWEXTENSIONS, SFVVO_SHOWCOMPCOLOR, SFVVO_SHOWSYSFILES, SFVVO_WIN95CLASSIC,
	// SFVVO_DOUBLECLICKINWEBVIEW, SFVVO_DESKTOPHTML } ;
	[PInvokeData("shldisp.h", MSDNShortId = "7028ff38-7596-4126-aa98-c0be519243c9")]
	[Guid("742A99A0-C77E-11D0-A32C-00A0C91EEDBA")]
	[Flags]
	public enum ShellFolderViewOptions
	{
		/// <summary>The Active Desktop – View as Web Page option is enabled.</summary>
		SFVVO_DESKTOPHTML = 0x200,

		/// <summary>The Double-Click to Open an Item option is enabled.</summary>
		SFVVO_DOUBLECLICKINWEBVIEW = 0x80,

		/// <summary>The Show All Files option is enabled.</summary>
		SFVVO_SHOWALLOBJECTS = 1,

		/// <summary>The Display Compressed Files and Folders with Alternate Color option is enabled.</summary>
		SFVVO_SHOWCOMPCOLOR = 8,

		/// <summary>The Hide extensions for known file types option is disabled.</summary>
		SFVVO_SHOWEXTENSIONS = 2,

		/// <summary>The Do Not Show Hidden Files option is enabled.</summary>
		SFVVO_SHOWSYSFILES = 0x20,

		/// <summary>The Classic Style option is enabled.</summary>
		SFVVO_WIN95CLASSIC = 0x40
	}

	/// <summary>
	/// Specifies unique, system-independent values that identify special folders. These folders are frequently used by applications but
	/// which may not have the same name or location on any given system. For example, the system folder can be "C:\Windows" on one
	/// system and "C:\Winnt" on another.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The values in this enumeration are equivalent to their corresponding CSIDL or KNOWNFOLDERID values, used in C++ applications.
	/// They supersede the use of environment variables for this purpose. Note that not all <c>CSIDL</c> or <c>KNOWNFOLDERID</c> values
	/// have an equivalent value in <c>ShellSpecialFolderConstants</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> Where a constant identifies a file system folder, a commonly used path on Windows Vista systems is given as an
	/// example. However, there is no guarantee that this path will be used on any particular system, including Windows Vista systems.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shldisp/ne-shldisp-shellspecialfolderconstants typedef enum
	// ShellSpecialFolderConstants { ssfDESKTOP, ssfPROGRAMS, ssfCONTROLS, ssfPRINTERS, ssfPERSONAL, ssfFAVORITES, ssfSTARTUP, ssfRECENT,
	// ssfSENDTO, ssfBITBUCKET, ssfSTARTMENU, ssfDESKTOPDIRECTORY, ssfDRIVES, ssfNETWORK, ssfNETHOOD, ssfFONTS, ssfTEMPLATES,
	// ssfCOMMONSTARTMENU, ssfCOMMONPROGRAMS, ssfCOMMONSTARTUP, ssfCOMMONDESKTOPDIR, ssfAPPDATA, ssfPRINTHOOD, ssfLOCALAPPDATA,
	// ssfALTSTARTUP, ssfCOMMONALTSTARTUP, ssfCOMMONFAVORITES, ssfINTERNETCACHE, ssfCOOKIES, ssfHISTORY, ssfCOMMONAPPDATA, ssfWINDOWS,
	// ssfSYSTEM, ssfPROGRAMFILES, ssfMYPICTURES, ssfPROFILE, ssfSYSTEMx86, ssfPROGRAMFILESx86 } ;
	[PInvokeData("shldisp.h", MSDNShortId = "35338102-f3a9-4bcf-ad62-d395462e6d2c")]
	[Guid("CA31EA20-48D0-11CF-8350-444553540000")]
	public enum ShellSpecialFolderConstants
	{
		/// <summary>0x00 (0). Windows desktop—the virtual folder that is the root of the namespace.</summary>
		ssfDESKTOP = 0,

		/// <summary>
		/// 0x02 (2). File system directory that contains the user's program groups (which are also file system directories). A typical
		/// path is C:\Users\username\AppData\Roaming\Microsoft\Windows\Start Menu\Programs.
		/// </summary>
		ssfPROGRAMS = 2,

		/// <summary>0x03 (3). Virtual folder that contains icons for the Control Panel applications.</summary>
		ssfCONTROLS,

		/// <summary>0x04 (4). Virtual folder that contains installed printers.</summary>
		ssfPRINTERS,

		/// <summary>
		/// 0x05 (5). File system directory that serves as a common repository for a user's documents. A typical path is C:\Users\username\Documents.
		/// </summary>
		ssfPERSONAL,

		/// <summary>
		/// 0x06 (6). File system directory that serves as a common repository for the user's favorite URLs. A typical path is
		/// C:\Documents and Settings\username\Favorites.
		/// </summary>
		ssfFAVORITES,

		/// <summary>
		/// 0x07 (7). File system directory that corresponds to the user's Startup program group. The system starts these programs
		/// whenever any user first logs into their profile after a reboot. A typical path is
		/// C:\Users\username\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\StartUp.
		/// </summary>
		ssfSTARTUP,

		/// <summary>0x08 (8). File system directory that contains the user's most recently used documents. A typical path is C:\Users\username\AppData\Roaming\Microsoft\Windows\Recent.</summary>
		ssfRECENT,

		/// <summary>0x09 (9). File system directory that contains Send To menu items. A typical path is C:\Users\username\AppData\Roaming\Microsoft\Windows\SendTo.</summary>
		ssfSENDTO,

		/// <summary>0x0a (10). Virtual folder that contains the objects in the user's Recycle Bin.</summary>
		ssfBITBUCKET,

		/// <summary>
		/// 0x0b (11). File system directory that contains Start menu items. A typical path is
		/// C:\Users\username\AppData\Roaming\Microsoft\Windows\Start Menu.
		/// </summary>
		ssfSTARTMENU,

		/// <summary>
		/// 0x10 (16). File system directory used to physically store the file objects that are displayed on the desktop. It is not to be
		/// confused with the desktop folder itself, which is a virtual folder. A typical path is C:\Documents and Settings\username\Desktop.
		/// </summary>
		ssfDESKTOPDIRECTORY = 16,

		/// <summary>
		/// 0x11 (17). My Computer—the virtual folder that contains everything on the local computer: storage devices, printers, and
		/// Control Panel. This folder can also contain mapped network drives.
		/// </summary>
		ssfDRIVES,

		/// <summary>0x12 (18). Network Neighborhood—the virtual folder that represents the root of the network namespace hierarchy.</summary>
		ssfNETWORK,

		/// <summary>
		/// 0x13 (19). A file system folder that contains any link objects in the My Network Places virtual folder. It is not the same as
		/// ssfNETWORK, which represents the network namespace root. A typical path is
		/// C:\Users\username\AppData\Roaming\Microsoft\Windows\Network Shortcuts.
		/// </summary>
		ssfNETHOOD,

		/// <summary>0x14 (20). Virtual folder that contains installed fonts. A typical path is C:\Windows\Fonts.</summary>
		ssfFONTS,

		/// <summary>0x15 (21). File system directory that serves as a common repository for document templates.</summary>
		ssfTEMPLATES,

		/// <summary>
		/// 0x16 (22). File system directory that contains the programs and folders that appear on the Start menu for all users. A
		/// typical path is C:\Documents and Settings\All Users\Start Menu. Valid only for Windows NT systems.
		/// </summary>
		ssfCOMMONSTARTMENU,

		/// <summary>
		/// 0x17 (23). File system directory that contains the directories for the common program groups that appear on the Start menu
		/// for all users. A typical path is C:\Documents and Settings\All Users\Start Menu\Programs. Valid only for Windows NT systems.
		/// </summary>
		ssfCOMMONPROGRAMS,

		/// <summary>
		/// 0x18 (24). File system directory that contains the programs that appear in the Startup folder for all users. A typical path
		/// is C:\Documents and Settings\All Users\Microsoft\Windows\Start Menu\Programs\StartUp. Valid only for Windows NT systems.
		/// </summary>
		ssfCOMMONSTARTUP,

		/// <summary>
		/// 0x19 (25). File system directory that contains files and folders that appear on the desktop for all users. A typical path is
		/// C:\Documents and Settings\All Users\Desktop. Valid only for Windows NT systems.
		/// </summary>
		ssfCOMMONDESKTOPDIR,

		/// <summary>
		/// 0x1a (26). Version 4.71. File system directory that serves as a common repository for application-specific data. A typical
		/// path is C:\Documents and Settings\username\Application Data.
		/// </summary>
		ssfAPPDATA,

		/// <summary>
		/// 0x1b (27). File system directory that contains any link objects in the Printers virtual folder. A typical path is
		/// C:\Users\username\AppData\Roaming\Microsoft\Windows\Printer Shortcuts.
		/// </summary>
		ssfPRINTHOOD,

		/// <summary>
		/// 0x1c (28). Version 5.0. File system directory that serves as a data repository for local (non-roaming) applications. A
		/// typical path is C:\Users\username\AppData\Local.
		/// </summary>
		ssfLOCALAPPDATA,

		/// <summary>0x1d (29). File system directory that corresponds to the user's non-localized Startup program group.</summary>
		ssfALTSTARTUP,

		/// <summary>
		/// 0x1e (30). File system directory that corresponds to the non-localized Startup program group for all users. Valid only for
		/// Windows NT systems.
		/// </summary>
		ssfCOMMONALTSTARTUP,

		/// <summary>
		/// 0x1f (31). File system directory that serves as a common repository for the favorite URLs shared by all users. Valid only for
		/// Windows NT systems.
		/// </summary>
		ssfCOMMONFAVORITES,

		/// <summary>
		/// 0x20 (32). File system directory that serves as a common repository for temporary Internet files. A typical path is
		/// C:\Users\username\AppData\Local\Microsoft\Windows\Temporary Internet Files.
		/// </summary>
		ssfINTERNETCACHE,

		/// <summary>
		/// 0x21 (33). File system directory that serves as a common repository for Internet cookies. A typical path is C:\Documents and
		/// Settings\username\Application Data\Microsoft\Windows\Cookies.
		/// </summary>
		ssfCOOKIES,

		/// <summary>0x22 (34). File system directory that serves as a common repository for Internet history items.</summary>
		ssfHISTORY,

		/// <summary>
		/// 0x23 (35). Version 5.0. Application data for all users. A typical path is C:\Documents and Settings\All Users\Application Data.
		/// </summary>
		ssfCOMMONAPPDATA,

		/// <summary>
		/// 0x24 (36). Version 5.0. Windows directory. This corresponds to the %windir% or %SystemRoot% environment variables. A typical
		/// path is C:\Windows.
		/// </summary>
		ssfWINDOWS,

		/// <summary>0x25 (37). Version 5.0. The System folder. A typical path is C:\Windows\System32.</summary>
		ssfSYSTEM,

		/// <summary>0x26 (38). Version 5.0. Program Files folder. A typical path is C:\Program Files.</summary>
		ssfPROGRAMFILES,

		/// <summary>0x27 (39). My Pictures folder. A typical path is C:\Users\username\Pictures.</summary>
		ssfMYPICTURES,

		/// <summary>0x28 (40). Version 5.0. User's profile folder.</summary>
		ssfPROFILE,

		/// <summary>
		/// 0x29 (41). Version 5.0. System folder. A typical path is C:\Windows\System32, or C:\Windows\Syswow32 on a 64-bit computer.
		/// </summary>
		ssfSYSTEMx86,

		/// <summary>
		/// 0x30 (48). Version 6.0. Program Files folder. A typical path is C:\Program Files, or C:\Program Files (X86) on a 64-bit computer.
		/// </summary>
		ssfPROGRAMFILESx86 = 48,
	}

	/// <summary>Constraint used in search command.</summary>
	[ComImport, Guid("4A3DF050-23BD-11D2-939F-00A0C91EEDBA")]
	public interface DFConstraint
	{
		/// <summary>Get the constraint name.</summary>
		[DispId(0x60020000)]
		string Name { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>Get the constraint value.</summary>
		[DispId(0x60020001)]
		object Value { [return: MarshalAs(UnmanagedType.Struct)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }
	}

	/// <summary>Event interface for ShellFolderView.</summary>
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIDispatch), Guid("62112AA2-EBE4-11CF-A5FB-0020AFE7292D"), CoClass(typeof(ShellFolderView))]
	public interface DShellFolderViewEvents
	{
		/// <summary>The Selection in the view changed.</summary>
		[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(DISPID.DISPID_SELECTIONCHANGED)]
		void SelectionChanged();

		/// <summary>The folder has finished enumerating (flashlight is gone).</summary>
		[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(DISPID.DISPID_FILELISTENUMDONE)]
		void EnumDone();

		/// <summary>A verb was invoked on an items in the view (return false to cancel).</summary>
		[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(DISPID.DISPID_VERBINVOKED)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool VerbInvoked();

		/// <summary>the default verb (double click) was invoked on an items in the view (return false to cancel).</summary>
		[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(DISPID.DISPID_DEFAULTVERBINVOKED)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool DefaultVerbInvoked();

		/// <summary>user started to drag an item (return false to cancel).</summary>
		[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(DISPID.DISPID_BEGINDRAG)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool BeginDrag();
	}

	/// <summary>
	/// Represents a Shell folder. This object contains properties and methods that allow you to retrieve information about the folder.
	/// </summary>
	[PInvokeData("Shldisp.h")]
	[ComImport, Guid("BBCBDE60-C3FF-11CE-8350-444553540000"), DefaultMember("Title")]
	public interface Folder
	{
		/// <summary>Contains the title of the folder.</summary>
		/// <value>Returns a <see cref="string"/> value.</value>
		[DispId(0)]
		string Title { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)] get; }

		/// <summary>Contains the folder's Application object.</summary>
		/// <value>An object reference to the Application object.</value>
		/// <remarks>
		/// The Application property returns the automation object supported by the application that contains the WebBrowser control, if
		/// that object is accessible. Otherwise, this property returns the WebBrowser control's automation object.
		/// <para>
		/// Use this property with the Set and CreateObject commands or with the GetObject command to create and manipulate an instance
		/// of the Internet Explorer application.
		/// </para>
		/// <note type="note">Not all methods are implemented for all folders. For example, the ParseName method is not implemented for
		/// the Control Panel folder (CSIDL_CONTROLS). If you attempt to call an unimplemented method, a 0x800A01BD (decimal 445) error
		/// is raised.</note>
		/// </remarks>
		[DispId(0x60020001)]
		object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>This property is not implemented.</summary>
		[DispId(0x60020002)]
		object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)] get; }

		/// <summary>Contains the parent Folder object.</summary>
		/// <value>An object reference to the ParentFolder object.</value>
		/// <remarks>
		/// <note type="note">Not all methods are implemented for all folders. For example, the ParseName method is not implemented for
		/// the Control Panel folder (CSIDL_CONTROLS). If you attempt to call an unimplemented method, a 0x800A01BD (decimal 445) error
		/// is raised.</note>
		/// </remarks>
		[DispId(0x60020003)]
		Folder ParentFolder { [return: MarshalAs(UnmanagedType.Interface)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)] get; }

		/// <summary>Retrieves a FolderItems object that represents the collection of items in the folder.</summary>
		/// <returns>An object reference to the FolderItems object.</returns>
		/// <remarks>
		/// <note type="note">Not all methods are implemented for all folders. For example, the ParseName method is not implemented for
		/// the Control Panel folder (CSIDL_CONTROLS). If you attempt to call an unimplemented method, a 0x800A01BD (decimal 445) error
		/// is raised.</note>
		/// </remarks>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
		FolderItems Items();

		/// <summary>Creates and returns a FolderItem object that represents a specified item.</summary>
		/// <param name="bName">A string that specifies the name of the item.</param>
		/// <returns>An object reference to the FolderItem object.</returns>
		/// <remarks>ParseName should not be used for virtual folders such as My Documents.</remarks>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
		FolderItem ParseName([In, MarshalAs(UnmanagedType.BStr)] string bName);

		/// <summary>Creates a new folder.</summary>
		/// <param name="bName">A string that specifies the name of the new folder.</param>
		/// <param name="vOptions">This value is not currently used.</param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		void NewFolder([In, MarshalAs(UnmanagedType.BStr)] string bName, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vOptions);

		/// <summary>Moves an item or items to this folder.</summary>
		/// <param name="vItem">
		/// The item or items to move. This can be a string that represents a file name, a FolderItem object, or a FolderItems object.
		/// </param>
		/// <param name="vOptions">
		/// Options for the move operation. This value can be zero or a combination of the following values. These values are based upon
		/// flags defined for use with the fFlags member of the C++ SHFILEOPSTRUCT structure. These flags are not defined as such for
		/// Visual Basic, VBScript, or JScript, so you must define them yourself or use their numeric equivalents.
		/// </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		void MoveHere([In, MarshalAs(UnmanagedType.Struct)] object vItem, [In, Optional, MarshalAs(UnmanagedType.Struct)] FILEOP_FLAGS vOptions);

		/// <summary>Copies an item or items to a folder.</summary>
		/// <param name="vItem">
		/// The item or items to copy. This can be a string that represents a file name, a FolderItem object, or a FolderItems object.
		/// </param>
		/// <param name="vOptions">
		/// Options for the copy operation. This value can be zero or a combination of the following values. These values are based upon
		/// flags defined for use with the fFlags member of the C++ SHFILEOPSTRUCT structure. Each Shell namespace must provide its own
		/// implementation of these flags, and each namespace can choose to ignore some or even all of these flags. These flags are not
		/// defined by name for Visual Basic, VBScript, or JScript, so you must define them yourself or use their numeric equivalents.
		/// </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)]
		void CopyHere([In, MarshalAs(UnmanagedType.Struct)] object vItem, [In, Optional, MarshalAs(UnmanagedType.Struct)] FILEOP_FLAGS vOptions);

		/// <summary>Retrieves details about an item in a folder. For example, its size, type, or the time of its last modification.</summary>
		/// <param name="vItem">The item for which to retrieve the information. This must be a FolderItem object.</param>
		/// <param name="iColumn">
		/// An Integer value that specifies the information to be retrieved. The information available for an item depends on the folder
		/// in which it is displayed. This value corresponds to the zero-based column number that is displayed in a Shell view.
		/// </param>
		/// <returns>String containing the retrieved detail.</returns>
		[return: MarshalAs(UnmanagedType.BStr)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)]
		string GetDetailsOf([In, MarshalAs(UnmanagedType.Struct)] object vItem, [In] int iColumn);
	}

	/// <summary>Extends the Folder object to support offline folders.</summary>
	[PInvokeData("Shldisp.h")]
	[ComImport, Guid("F0D2D8EF-3890-11D2-BF8B-00C04FB93661"), DefaultMember("Title")]
	public interface Folder2 : Folder
	{
		/// <summary>Contains the title of the folder.</summary>
		/// <value>Returns a <see cref="string"/> value.</value>
		[DispId(0)]
		new string Title { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)] get; }

		/// <summary>Contains the folder's Application object.</summary>
		/// <value>An object reference to the Application object.</value>
		/// <remarks>
		/// The Application property returns the automation object supported by the application that contains the WebBrowser control, if
		/// that object is accessible. Otherwise, this property returns the WebBrowser control's automation object.
		/// <para>
		/// Use this property with the Set and CreateObject commands or with the GetObject command to create and manipulate an instance
		/// of the Internet Explorer application.
		/// </para>
		/// <note type="note">Not all methods are implemented for all folders. For example, the ParseName method is not implemented for
		/// the Control Panel folder (CSIDL_CONTROLS). If you attempt to call an unimplemented method, a 0x800A01BD (decimal 445) error
		/// is raised.</note>
		/// </remarks>
		[DispId(0x60020001)]
		new object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>This property is not implemented.</summary>
		[DispId(0x60020002)]
		new object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)] get; }

		/// <summary>Contains the parent Folder object.</summary>
		/// <value>An object reference to the ParentFolder object.</value>
		/// <remarks>
		/// <note type="note">Not all methods are implemented for all folders. For example, the ParseName method is not implemented for
		/// the Control Panel folder (CSIDL_CONTROLS). If you attempt to call an unimplemented method, a 0x800A01BD (decimal 445) error
		/// is raised.</note>
		/// </remarks>
		[DispId(0x60020003)]
		new Folder ParentFolder { [return: MarshalAs(UnmanagedType.Interface)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)] get; }

		/// <summary>Retrieves a FolderItems object that represents the collection of items in the folder.</summary>
		/// <returns>An object reference to the FolderItems object.</returns>
		/// <remarks>
		/// <note type="note">Not all methods are implemented for all folders. For example, the ParseName method is not implemented for
		/// the Control Panel folder (CSIDL_CONTROLS). If you attempt to call an unimplemented method, a 0x800A01BD (decimal 445) error
		/// is raised.</note>
		/// </remarks>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
		new FolderItems Items();

		/// <summary>Creates and returns a FolderItem object that represents a specified item.</summary>
		/// <param name="bName">A string that specifies the name of the item.</param>
		/// <returns>An object reference to the FolderItem object.</returns>
		/// <remarks>ParseName should not be used for virtual folders such as My Documents.</remarks>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
		new FolderItem ParseName([In, MarshalAs(UnmanagedType.BStr)] string bName);

		/// <summary>Creates a new folder.</summary>
		/// <param name="bName">A string that specifies the name of the new folder.</param>
		/// <param name="vOptions">This value is not currently used.</param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		new void NewFolder([In, MarshalAs(UnmanagedType.BStr)] string bName, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vOptions);

		/// <summary>Moves an item or items to this folder.</summary>
		/// <param name="vItem">
		/// The item or items to move. This can be a string that represents a file name, a FolderItem object, or a FolderItems object.
		/// </param>
		/// <param name="vOptions">
		/// Options for the move operation. This value can be zero or a combination of the following values. These values are based upon
		/// flags defined for use with the fFlags member of the C++ SHFILEOPSTRUCT structure. These flags are not defined as such for
		/// Visual Basic, VBScript, or JScript, so you must define them yourself or use their numeric equivalents.
		/// </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		new void MoveHere([In, MarshalAs(UnmanagedType.Struct)] object vItem, [In, Optional, MarshalAs(UnmanagedType.Struct)] FILEOP_FLAGS vOptions);

		/// <summary>Copies an item or items to a folder.</summary>
		/// <param name="vItem">
		/// The item or items to copy. This can be a string that represents a file name, a FolderItem object, or a FolderItems object.
		/// </param>
		/// <param name="vOptions">
		/// Options for the copy operation. This value can be zero or a combination of the following values. These values are based upon
		/// flags defined for use with the fFlags member of the C++ SHFILEOPSTRUCT structure. Each Shell namespace must provide its own
		/// implementation of these flags, and each namespace can choose to ignore some or even all of these flags. These flags are not
		/// defined by name for Visual Basic, VBScript, or JScript, so you must define them yourself or use their numeric equivalents.
		/// </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)]
		new void CopyHere([In, MarshalAs(UnmanagedType.Struct)] object vItem, [In, Optional, MarshalAs(UnmanagedType.Struct)] FILEOP_FLAGS vOptions);

		/// <summary>Retrieves details about an item in a folder. For example, its size, type, or the time of its last modification.</summary>
		/// <param name="vItem">The item for which to retrieve the information. This must be a FolderItem object.</param>
		/// <param name="iColumn">
		/// An Integer value that specifies the information to be retrieved. The information available for an item depends on the folder
		/// in which it is displayed. This value corresponds to the zero-based column number that is displayed in a Shell view.
		/// </param>
		/// <returns>String containing the retrieved detail.</returns>
		[return: MarshalAs(UnmanagedType.BStr)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)]
		new string GetDetailsOf([In, MarshalAs(UnmanagedType.Struct)] object vItem, [In] int iColumn);

		/// <summary>Contains the folder's FolderItem object.</summary>
		/// <value>The object that evaluates to the folder's FolderItem object.</value>
		[DispId(0x60030000)]
		FolderItem Self { [return: MarshalAs(UnmanagedType.Interface)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)] get; }

		/// <summary>Contains the offline status of the folder.</summary>
		/// <value>Returns a <see cref="OfflineFolderStatus"/> value.</value>
		[DispId(0x60030001)]
		OfflineFolderStatus OfflineStatus { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030001)] get; }

		/// <summary>Synchronizes all offline files in the folder.</summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030002)]
		void Synchronize();

		/// <summary>This property is not supported.</summary>
		/// <value><see langword="true"/> if [have to show web view barricade]; otherwise, <see langword="false"/>.</value>
		[DispId(1)]
		bool HaveToShowWebViewBarricade { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1)] get; }

		/// <summary>Called in response to the web view barricade being dismissed by the user.</summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030004)]
		void DismissedWebViewBarricade();
	}

	/// <summary>Extends the Folder object to support offline folders.</summary>
	[PInvokeData("Shldisp.h")]
	[ComImport, DefaultMember("Title"), Guid("A7AE5F64-C4D7-4D7F-9307-4D24EE54B841")]
	public interface Folder3 : Folder2
	{
		/// <summary>Contains the title of the folder.</summary>
		/// <value>Returns a <see cref="string"/> value.</value>
		[DispId(0)]
		new string Title { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)] get; }

		/// <summary>Contains the folder's Application object.</summary>
		/// <value>An object reference to the Application object.</value>
		/// <remarks>
		/// The Application property returns the automation object supported by the application that contains the WebBrowser control, if
		/// that object is accessible. Otherwise, this property returns the WebBrowser control's automation object.
		/// <para>
		/// Use this property with the Set and CreateObject commands or with the GetObject command to create and manipulate an instance
		/// of the Internet Explorer application.
		/// </para>
		/// <note type="note">Not all methods are implemented for all folders. For example, the ParseName method is not implemented for
		/// the Control Panel folder (CSIDL_CONTROLS). If you attempt to call an unimplemented method, a 0x800A01BD (decimal 445) error
		/// is raised.</note>
		/// </remarks>
		[DispId(0x60020001)]
		new object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>This property is not implemented.</summary>
		[DispId(0x60020002)]
		new object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)] get; }

		/// <summary>Contains the parent Folder object.</summary>
		/// <value>An object reference to the ParentFolder object.</value>
		/// <remarks>
		/// <note type="note">Not all methods are implemented for all folders. For example, the ParseName method is not implemented for
		/// the Control Panel folder (CSIDL_CONTROLS). If you attempt to call an unimplemented method, a 0x800A01BD (decimal 445) error
		/// is raised.</note>
		/// </remarks>
		[DispId(0x60020003)]
		new Folder ParentFolder { [return: MarshalAs(UnmanagedType.Interface)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)] get; }

		/// <summary>Retrieves a FolderItems object that represents the collection of items in the folder.</summary>
		/// <returns>An object reference to the FolderItems object.</returns>
		/// <remarks>
		/// <note type="note">Not all methods are implemented for all folders. For example, the ParseName method is not implemented for
		/// the Control Panel folder (CSIDL_CONTROLS). If you attempt to call an unimplemented method, a 0x800A01BD (decimal 445) error
		/// is raised.</note>
		/// </remarks>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
		new FolderItems Items();

		/// <summary>Creates and returns a FolderItem object that represents a specified item.</summary>
		/// <param name="bName">A string that specifies the name of the item.</param>
		/// <returns>An object reference to the FolderItem object.</returns>
		/// <remarks>ParseName should not be used for virtual folders such as My Documents.</remarks>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
		new FolderItem ParseName([In, MarshalAs(UnmanagedType.BStr)] string bName);

		/// <summary>Creates a new folder.</summary>
		/// <param name="bName">A string that specifies the name of the new folder.</param>
		/// <param name="vOptions">This value is not currently used.</param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		new void NewFolder([In, MarshalAs(UnmanagedType.BStr)] string bName, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vOptions);

		/// <summary>Moves an item or items to this folder.</summary>
		/// <param name="vItem">
		/// The item or items to move. This can be a string that represents a file name, a FolderItem object, or a FolderItems object.
		/// </param>
		/// <param name="vOptions">
		/// Options for the move operation. This value can be zero or a combination of the following values. These values are based upon
		/// flags defined for use with the fFlags member of the C++ SHFILEOPSTRUCT structure. These flags are not defined as such for
		/// Visual Basic, VBScript, or JScript, so you must define them yourself or use their numeric equivalents.
		/// </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		new void MoveHere([In, MarshalAs(UnmanagedType.Struct)] object vItem, [In, Optional, MarshalAs(UnmanagedType.Struct)] FILEOP_FLAGS vOptions);

		/// <summary>Copies an item or items to a folder.</summary>
		/// <param name="vItem">
		/// The item or items to copy. This can be a string that represents a file name, a FolderItem object, or a FolderItems object.
		/// </param>
		/// <param name="vOptions">
		/// Options for the copy operation. This value can be zero or a combination of the following values. These values are based upon
		/// flags defined for use with the fFlags member of the C++ SHFILEOPSTRUCT structure. Each Shell namespace must provide its own
		/// implementation of these flags, and each namespace can choose to ignore some or even all of these flags. These flags are not
		/// defined by name for Visual Basic, VBScript, or JScript, so you must define them yourself or use their numeric equivalents.
		/// </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)]
		new void CopyHere([In, MarshalAs(UnmanagedType.Struct)] object vItem, [In, Optional, MarshalAs(UnmanagedType.Struct)] FILEOP_FLAGS vOptions);

		/// <summary>Retrieves details about an item in a folder. For example, its size, type, or the time of its last modification.</summary>
		/// <param name="vItem">The item for which to retrieve the information. This must be a FolderItem object.</param>
		/// <param name="iColumn">
		/// An Integer value that specifies the information to be retrieved. The information available for an item depends on the folder
		/// in which it is displayed. This value corresponds to the zero-based column number that is displayed in a Shell view.
		/// </param>
		/// <returns>String containing the retrieved detail.</returns>
		[return: MarshalAs(UnmanagedType.BStr)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)]
		new string GetDetailsOf([In, MarshalAs(UnmanagedType.Struct)] object vItem, [In] int iColumn);

		/// <summary>Contains the folder's FolderItem object.</summary>
		/// <value>The object that evaluates to the folder's FolderItem object.</value>
		[DispId(0x60030000)]
		new FolderItem Self { [return: MarshalAs(UnmanagedType.Interface)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)] get; }

		/// <summary>Contains the offline status of the folder.</summary>
		/// <value>Returns a <see cref="OfflineFolderStatus"/> value.</value>
		[DispId(0x60030001)]
		new OfflineFolderStatus OfflineStatus { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030001)] get; }

		/// <summary>Synchronizes all offline files in the folder.</summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030002)]
		new void Synchronize();

		/// <summary>This property is not supported.</summary>
		/// <value><see langword="true"/> if [have to show web view barricade]; otherwise, <see langword="false"/>.</value>
		[DispId(1)]
		new bool HaveToShowWebViewBarricade { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1)] get; }

		/// <summary>Called in response to the web view barricade being dismissed by the user.</summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030004)]
		new void DismissedWebViewBarricade();

		/// <summary>Gets or sets a value indicating whether to show web view barricade.</summary>
		[DispId(2)]
		bool ShowWebViewBarricade { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(2)] get; [param: In][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(2)] set; }
	}

	/// <summary>
	/// Represents an item in a Shell folder. This object contains properties and methods that allow you to retrieve information about
	/// the item.
	/// </summary>
	[PInvokeData("Shldisp.h")]
	[ComImport, Guid("FAC32C80-CBE4-11CE-8350-444553540000"), DefaultMember("Name"), CoClass(typeof(ShellFolderItem))]
	public interface FolderItem
	{
		/// <summary>Contains the Application object of the folder item.</summary>
		/// <value>A variable of type IDispatch that receives the Application object.</value>
		/// <remarks>
		/// The Application property returns the automation object supported by the application that contains the WebBrowser control, if
		/// that object is accessible. Otherwise, this property returns the WebBrowser control's automation object.
		/// <para>
		/// Use this property with the Set and CreateObject commands or with the GetObject command to create and manipulate an instance
		/// of the Internet Explorer application.
		/// </para>
		/// </remarks>
		[DispId(0x60020000)]
		object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>Gets an object that represents the parent of the item.</summary>
		/// <value>A variable of type IDispatch that receives the parent object.</value>
		[DispId(0x60020001)]
		object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>Gets or sets the item's name.</summary>
		/// <value>A variable of type BSTR that specifies or receives the item's name.</value>
		[DispId(0)]
		string Name { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)] set; }

		/// <summary>Contains the item's full path and name.</summary>
		/// <value>A variable of type BSTR that receives the item's full path and name.</value>
		[DispId(0x60020004)]
		string Path { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)] get; }

		/// <summary>Contains the item's ShellLinkObject object, if the item is a shortcut.</summary>
		/// <value>A variable of type IDispatch that receives the ShellLinkObject object.</value>
		[DispId(0x60020005)]
		object GetLink { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)] get; }

		/// <summary>Contains the item's Folder object, if the item is a folder.</summary>
		/// <value>A variable of type IDispatch that receives the Folder object.</value>
		[DispId(0x60020006)]
		object GetFolder { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)] get; }

		/// <summary>Indicates whether the item is a shortcut.</summary>
		/// <value>A Boolean that receives <see langword="true"/> if the item is a shortcut or <see langword="false"/> if not.</value>
		[DispId(0x60020007)]
		bool IsLink { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)] get; }

		/// <summary>Indicates if the item is a folder.</summary>
		/// <value>A Boolean that receives <see langword="true"/> if the item is a folder or <see langword="false"/> if not.</value>
		[DispId(0x60020008)]
		bool IsFolder { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)] get; }

		/// <summary>Indicates if the item is part of the file system.</summary>
		/// <value>
		/// A Boolean that receives <see langword="true"/> if the item is part of the file system or <see langword="false"/> if not.
		/// </value>
		[DispId(0x60020009)]
		bool IsFileSystem { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)] get; }

		/// <summary>Indicates if the item can be hosted inside a browser or Windows Explorer frame.</summary>
		/// <value>A Boolean that receives <see langword="true"/> if the item can be browsed or <see langword="false"/> if not.</value>
		[DispId(0x6002000a)]
		bool IsBrowsable { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)] get; }

		/// <summary>
		/// For a file, sets or gets the date and time that it was last modified. For a folder, retrieves the date and time that a folder
		/// was last modified, but cannot set it.
		/// </summary>
		/// <value>Date that specifies or receives the date and time that the item was last modified.</value>
		[DispId(0x6002000b)]
		DateTime ModifyDate { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000b)] get; [param: In][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000b)] set; }

		/// <summary>Contains the item's size.</summary>
		/// <value>An Integer that receives the item's size.</value>
		[DispId(0x6002000d)]
		int Size { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000d)] get; }

		/// <summary>Contains a string representation of the item's type.</summary>
		/// <value>A variable of type BSTR that receives the item's type.</value>
		[DispId(0x6002000e)]
		string Type { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)] get; }

		/// <summary>
		/// Retrieves the item's FolderItemVerbs object. This object is the collection of verbs that can be executed on the item.
		/// </summary>
		/// <returns>An object reference to the FolderItemVerbs object.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000f)]
		FolderItemVerbs Verbs();

		/// <summary>Executes a verb on the item.</summary>
		/// <param name="vVerb">
		/// A string that specifies the verb to be executed. It must be one of the values returned by the item's FolderItemVerb.Name
		/// property. If no verb is specified, the default verb will be invoked.
		/// </param>
		/// <remarks>
		/// A verb is a string used to specify a particular action that an item supports. Invoking a verb is equivalent to selecting a
		/// command from an item's shortcut menu. Typically, invoking a verb launches a related application. For example, invoking the
		/// "open" verb on a .txt file opens the file with a text editor, usually Microsoft Notepad. See Launching Applications for
		/// further discussion of verbs.
		/// <para>
		/// The FolderItemVerbs object represents the collection of verbs associated with the item.The default verb may vary for
		/// different items, but it is typically "open".
		/// </para>
		/// </remarks>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020010)]
		void InvokeVerb([In, Optional, MarshalAs(UnmanagedType.Struct)] string? vVerb);
	}

	/// <summary>Extends the FolderItems object. It supports one additional method.</summary>
	[PInvokeData("Shldisp.h")]
	[ComImport, DefaultMember("Name"), Guid("EDC817AA-92B8-11D1-B075-00C04FC33AA5"), CoClass(typeof(ShellFolderItem))]
	public interface FolderItem2 : FolderItem
	{
		/// <summary>Contains the Application object of the folder item.</summary>
		/// <value>A variable of type IDispatch that receives the Application object.</value>
		/// <remarks>
		/// The Application property returns the automation object supported by the application that contains the WebBrowser control, if
		/// that object is accessible. Otherwise, this property returns the WebBrowser control's automation object.
		/// <para>
		/// Use this property with the Set and CreateObject commands or with the GetObject command to create and manipulate an instance
		/// of the Internet Explorer application.
		/// </para>
		/// </remarks>
		[DispId(0x60020000)]
		new object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>Gets an object that represents the parent of the item.</summary>
		/// <value>A variable of type IDispatch that receives the parent object.</value>
		[DispId(0x60020001)]
		new object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>Gets or sets the item's name.</summary>
		/// <value>A variable of type BSTR that specifies or receives the item's name.</value>
		[DispId(0)]
		new string Name { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)] set; }

		/// <summary>Contains the item's full path and name.</summary>
		/// <value>A variable of type BSTR that receives the item's full path and name.</value>
		[DispId(0x60020004)]
		new string Path { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)] get; }

		/// <summary>Contains the item's ShellLinkObject object, if the item is a shortcut.</summary>
		/// <value>A variable of type IDispatch that receives the ShellLinkObject object.</value>
		[DispId(0x60020005)]
		new object GetLink { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)] get; }

		/// <summary>Contains the item's Folder object, if the item is a folder.</summary>
		/// <value>A variable of type IDispatch that receives the Folder object.</value>
		[DispId(0x60020006)]
		new object GetFolder { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)] get; }

		/// <summary>Indicates whether the item is a shortcut.</summary>
		/// <value>A Boolean that receives <see langword="true"/> if the item is a shortcut or <see langword="false"/> if not.</value>
		[DispId(0x60020007)]
		new bool IsLink { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)] get; }

		/// <summary>Indicates if the item is a folder.</summary>
		/// <value>A Boolean that receives <see langword="true"/> if the item is a folder or <see langword="false"/> if not.</value>
		[DispId(0x60020008)]
		new bool IsFolder { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)] get; }

		/// <summary>Indicates if the item is part of the file system.</summary>
		/// <value>
		/// A Boolean that receives <see langword="true"/> if the item is part of the file system or <see langword="false"/> if not.
		/// </value>
		[DispId(0x60020009)]
		new bool IsFileSystem { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)] get; }

		/// <summary>Indicates if the item can be hosted inside a browser or Windows Explorer frame.</summary>
		/// <value>A Boolean that receives <see langword="true"/> if the item can be browsed or <see langword="false"/> if not.</value>
		[DispId(0x6002000a)]
		new bool IsBrowsable { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)] get; }

		/// <summary>
		/// For a file, sets or gets the date and time that it was last modified. For a folder, retrieves the date and time that a folder
		/// was last modified, but cannot set it.
		/// </summary>
		/// <value>Date that specifies or receives the date and time that the item was last modified.</value>
		[DispId(0x6002000b)]
		new DateTime ModifyDate { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000b)] get; [param: In][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000b)] set; }

		/// <summary>Contains the item's size.</summary>
		/// <value>An Integer that receives the item's size.</value>
		[DispId(0x6002000d)]
		new int Size { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000d)] get; }

		/// <summary>Contains a string representation of the item's type.</summary>
		/// <value>A variable of type BSTR that receives the item's type.</value>
		[DispId(0x6002000e)]
		new string Type { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)] get; }

		/// <summary>
		/// Retrieves the item's FolderItemVerbs object. This object is the collection of verbs that can be executed on the item.
		/// </summary>
		/// <returns>An object reference to the FolderItemVerbs object.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000f)]
		new FolderItemVerbs Verbs();

		/// <summary>Executes a verb on the item.</summary>
		/// <param name="vVerb">
		/// A string that specifies the verb to be executed. It must be one of the values returned by the item's FolderItemVerb.Name
		/// property. If no verb is specified, the default verb will be invoked.
		/// </param>
		/// <remarks>
		/// A verb is a string used to specify a particular action that an item supports. Invoking a verb is equivalent to selecting a
		/// command from an item's shortcut menu. Typically, invoking a verb launches a related application. For example, invoking the
		/// "open" verb on a .txt file opens the file with a text editor, usually Microsoft Notepad. See Launching Applications for
		/// further discussion of verbs.
		/// <para>
		/// The FolderItemVerbs object represents the collection of verbs associated with the item.The default verb may vary for
		/// different items, but it is typically "open".
		/// </para>
		/// </remarks>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020010)]
		new void InvokeVerb([In, Optional, MarshalAs(UnmanagedType.Struct)] string? vVerb);

		/// <summary>
		/// Executes a verb on a collection of FolderItem objects. This method is an extension of the InvokeVerb method, allowing
		/// additional control of the operation through a set of flags.
		/// </summary>
		/// <param name="vVerb">
		/// A Variant with the verb string that corresponds to the command to be executed. If no verb is specified, the default verb is executed.
		/// </param>
		/// <param name="vArgs">
		/// A Variant that consists of a string with one or more arguments to the command specified by vVerb. The format of this string
		/// depends on the particular verb.
		/// </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)]
		void InvokeVerbEx([In, Optional, MarshalAs(UnmanagedType.Struct)] string? vVerb, [In, Optional, MarshalAs(UnmanagedType.Struct)] string? vArgs);

		/// <summary>Access an extended property</summary>
		/// <param name="bstrPropName">Name of the property.</param>
		/// <returns>Property value.</returns>
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030001)]
		object ExtendedProperty([In, MarshalAs(UnmanagedType.BStr)] string bstrPropName);
	}

	/// <summary>
	/// Represents the collection of items in a Shell folder. This object contains properties and methods that allow you to retrieve
	/// information about the collection.
	/// </summary>
	[PInvokeData("Shldisp.h")]
	[ComImport, Guid("744129E0-CBE5-11CE-8350-444553540000")]
	public interface FolderItems
	{
		/// <summary>Contains the number of items in the collection.</summary>
		/// <value>An Integer that contains a value for the Count property.</value>
		[DispId(0x60020000)]
		int Count { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>Contains the Application object of the folder items collection.</summary>
		/// <value>An object reference to the Application object.</value>
		[DispId(0x60020001)]
		object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>This property is not implemented.</summary>
		[DispId(0x60020002)]
		object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)] get; }

		/// <summary>Retrieves the FolderItem object for a specified item in the collection.</summary>
		/// <param name="index">The zero-based index of the item to retrieve. This value must be less than the value of the Count property.</param>
		/// <returns>An object reference to the FolderItem object.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		FolderItem Item([In, Optional, MarshalAs(UnmanagedType.Struct)] int index);

		/// <summary>Creates and returns a new FolderItems object that is a copy of this FolderItemsss object.</summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-4)]
		object _NewEnum();
	}

	/// <summary>Extends the FolderItems object. It supports one additional method.</summary>
	/// <seealso cref="FolderItems"/>
	[PInvokeData("Shldisp.h")]
	[ComImport, Guid("C94F0AD0-F363-11D2-A327-00C04F8EEC7F")]
	public interface FolderItems2 : FolderItems
	{
		/// <summary>Contains the number of items in the collection.</summary>
		/// <value>An Integer that contains a value for the Count property.</value>
		[DispId(0x60020000)]
		new int Count { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>Contains the Application object of the folder items collection.</summary>
		/// <value>An object reference to the Application object.</value>
		[DispId(0x60020001)]
		new object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>This property is not implemented.</summary>
		[DispId(0x60020002)]
		new object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)] get; }

		/// <summary>Retrieves the FolderItem object for a specified item in the collection.</summary>
		/// <param name="index">The zero-based index of the item to retrieve. This value must be less than the value of the Count property.</param>
		/// <returns>An object reference to the FolderItem object.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		new FolderItem Item([In, Optional, MarshalAs(UnmanagedType.Struct)] int index);

		/// <summary>Creates and returns a new FolderItems object that is a copy of this FolderItemsss object.</summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-4)]
		new object _NewEnum();

		/// <summary>
		/// Executes a verb on a collection of FolderItem objects. This method is an extension of the InvokeVerb method, allowing
		/// additional control of the operation through a set of flags.
		/// </summary>
		/// <param name="vVerb">
		/// A Variant with the verb string that corresponds to the command to be executed. If no verb is specified, the default verb is executed.
		/// </param>
		/// <param name="vArgs">
		/// A Variant that consists of a string with one or more arguments to the command specified by vVerb. The format of this string
		/// depends on the particular verb.
		/// </param>
		/// <remarks>
		/// A verb is a string used to specify a particular action associated with an item or collection of items. Typically, calling a
		/// verb launches a related application. For example, calling the open verb on a .txt file normally opens the file with a text
		/// editor, usually Microsoft Notepad. For further discussion of verbs, see Launching Applications.
		/// </remarks>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)]
		void InvokeVerbEx([In, Optional, MarshalAs(UnmanagedType.Struct)] string? vVerb, [In, Optional, MarshalAs(UnmanagedType.Struct)] string? vArgs);
	}

	/// <summary>Extends the FolderItems2 object. This object supports an additional method and property.</summary>
	/// <seealso cref="FolderItems2"/>
	[PInvokeData("Shldisp.h")]
	[ComImport, Guid("EAA7C309-BBEC-49D5-821D-64D966CB667F"), DefaultMember("Verbs")]
	public interface FolderItems3 : FolderItems2
	{
		/// <summary>Contains the number of items in the collection.</summary>
		/// <value>An Integer that contains a value for the Count property.</value>
		[DispId(0x60020000)]
		new int Count { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>Contains the Application object of the folder items collection.</summary>
		/// <value>An object reference to the Application object.</value>
		[DispId(0x60020001)]
		new object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>This property is not implemented.</summary>
		[DispId(0x60020002)]
		new object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)] get; }

		/// <summary>Retrieves the FolderItem object for a specified item in the collection.</summary>
		/// <param name="index">The zero-based index of the item to retrieve. This value must be less than the value of the Count property.</param>
		/// <returns>An object reference to the FolderItem object.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		new FolderItem Item([In, Optional, MarshalAs(UnmanagedType.Struct)] int index);

		/// <summary>Creates and returns a new FolderItems object that is a copy of this FolderItemsss object.</summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-4)]
		new object _NewEnum();

		/// <summary>
		/// Executes a verb on a collection of FolderItem objects. This method is an extension of the InvokeVerb method, allowing
		/// additional control of the operation through a set of flags.
		/// </summary>
		/// <param name="vVerb">
		/// A Variant with the verb string that corresponds to the command to be executed. If no verb is specified, the default verb is executed.
		/// </param>
		/// <param name="vArgs">
		/// A Variant that consists of a string with one or more arguments to the command specified by vVerb. The format of this string
		/// depends on the particular verb.
		/// </param>
		/// <remarks>
		/// A verb is a string used to specify a particular action associated with an item or collection of items. Typically, calling a
		/// verb launches a related application. For example, calling the open verb on a .txt file normally opens the file with a text
		/// editor, usually Microsoft Notepad. For further discussion of verbs, see Launching Applications.
		/// </remarks>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)]
		new void InvokeVerbEx([In, Optional, MarshalAs(UnmanagedType.Struct)] string? vVerb, [In, Optional, MarshalAs(UnmanagedType.Struct)] string? vArgs);

		/// <summary>Sets a wildcard filter to apply to the items returned.</summary>
		/// <param name="grfFlags">This parameter can be one of the flags listed in SHCONTF.</param>
		/// <param name="bstrFileSpec">A filter string that specifies what should be listed in the FolderItems collection.</param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040000)]
		void Filter([In] SHCONTF grfFlags, [In, MarshalAs(UnmanagedType.BStr)] string bstrFileSpec);

		/// <summary>Gets the list of verbs common to all the folder items.</summary>
		/// <value>Address of a pointer to the collection of verbs. See FolderItemVerbs.</value>
		[DispId(0)]
		FolderItemVerbs Verbs { [return: MarshalAs(UnmanagedType.Interface)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)] get; }
	}

	/// <summary>
	/// Represents a single verb available to an item. This object contains properties and methods that allow you to retrieve information
	/// about the verb.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/folderitemverb
	[PInvokeData("shldisp.h", MSDNShortId = "22f52e3f-875e-4dde-8875-3228639bc7f1")]
	[ComImport, DefaultMember("Name"), Guid("08EC3E00-50B0-11CF-960C-0080C7F4EE85")]
	public interface FolderItemVerb
	{
		/// <summary>This property is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/folderitemverb-application
		[DispId(0x60020000)]
		object FolderItemVerb_Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>This property is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/folderitemverb-parent
		[DispId(0x60020001)]
		object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>
		/// <para>Contains the verb's name.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/folderitemverb-name
		[DispId(0)]
		string Name { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)] get; }

		/// <summary>Executes a verb on the <c>FolderItem</c> associated with the verb.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/folderitemverb-doit
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		void DoIt();
	}

	/// <summary>
	/// Represents the collection of verbs for an item in a Shell folder. This object contains properties and methods that allow you to
	/// retrieve information about the collection.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/folderitemverbs
	[PInvokeData("shldisp.h", MSDNShortId = "31badb4b-b89e-4294-9dd7-bda716e163b2")]
	[ComImport, Guid("1F8352C0-50B0-11CF-960C-0080C7F4EE85")]
	public interface FolderItemVerbs : IEnumerable
	{
		/// <summary>
		/// <para>Contains the number of items in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/folderitemverbs-count
		[DispId(0x60020000)]
		int Count { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>This property is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/folderitemverbs-application
		[DispId(0x60020001)]
		object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>This property is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/folderitemverbs-parent
		[DispId(0x60020002)]
		object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)] get; }

		/// <summary>Retrieves the <c>FolderItemVerb</c> object for a specified item in the collection.</summary>
		/// <param name="index">
		/// <para>Type: <c>Variant</c></para>
		/// <para>The zero-based index of the item to retrieve. This value must be less than the value of the <c>Count</c> property.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>IDispatch</c>**</c></para>
		/// <para>Object that receives the <c>FolderItemVerb</c> object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/shell/folderitemverbs-item
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		FolderItemVerb Item([In, Optional, MarshalAs(UnmanagedType.Struct)] int index);

		/// <summary>Creates and returns a new FolderItemVerbs object that is a copy of this FolderItemVerbs object.</summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-4)]
		object _NewEnum();
	}

	/// <summary>
	/// Exposed by the autocomplete object (CLSID_AutoComplete). This interface allows applications to initialize, enable, and disable
	/// the object.
	/// </summary>
	[PInvokeData("shldisp.h")]
	[ComImport, SuppressUnmanagedCodeSecurity, Guid("00bb2762-6a77-11d0-a535-00c04fd7d062"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CAutoComplete))]
	public interface IAutoComplete
	{
		/// <summary>Initializes the autocomplete object.</summary>
		/// <param name="hwndEdit">A handle to the window for the system edit control for which autocompletion will be enabled.</param>
		/// <param name="punkAcl">
		/// A pointer to the IUnknown interface of the string list object that generates candidates for the completed string. The object
		/// must expose an IEnumString interface.
		/// </param>
		/// <param name="pwszRegKeyPath">
		/// A pointer to an optional, null-terminated Unicode string that gives the registry path, including the value name, where the
		/// format string is stored as a REG_SZ value. The autocomplete object first looks for the path under HKEY_CURRENT_USER. If it
		/// fails, it tries HKEY_LOCAL_MACHINE. For a discussion of the format string, see the definition of pwszQuickComplete.
		/// </param>
		/// <param name="pwszQuickComplete">
		/// A pointer to an optional null-terminated Unicode string that specifies the format to be used if the user enters text and
		/// presses CTRL+ENTER. Set this parameter to NULL to disable quick completion. Otherwise, the autocomplete object treats
		/// pwszQuickComplete as a StringCchPrintf format string and the text in the edit box as its associated argument, to produce a
		/// new string. For example, set pwszQuickComplete to "http://www.%s.com/". When a user enters "MyURL" into the edit box and
		/// presses CTRL+ENTER, the text in the edit box is updated to "http://www.MyURL.com/".
		/// </param>
		void Init(HWND hwndEdit, IEnumString punkAcl, [MarshalAs(UnmanagedType.LPWStr)] string? pwszRegKeyPath, [MarshalAs(UnmanagedType.LPWStr)] string? pwszQuickComplete);

		/// <summary>Enables or disables autocompletion.</summary>
		/// <param name="fEnable">A value that is set to TRUE to enable autocompletion, or FALSE to disable it.</param>
		void Enable([MarshalAs(UnmanagedType.Bool)] bool fEnable);
	}

	/// <summary>
	/// Extends IAutoComplete. This interface enables clients of the autocomplete object to retrieve and set a number of options that
	/// control how autocompletion operates.
	/// </summary>
	/// <seealso cref="IAutoComplete"/>
	[PInvokeData("shldisp.h")]
	[ComImport, SuppressUnmanagedCodeSecurity, Guid("EAC04BC0-3791-11D2-BB95-0060977B464C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CAutoComplete))]
	public interface IAutoComplete2 : IAutoComplete
	{
		/// <summary>Initializes the autocomplete object.</summary>
		/// <param name="hwndEdit">A handle to the window for the system edit control for which autocompletion will be enabled.</param>
		/// <param name="punkAcl">
		/// A pointer to the IUnknown interface of the string list object that generates candidates for the completed string. The object
		/// must expose an IEnumString interface.
		/// </param>
		/// <param name="pwszRegKeyPath">
		/// A pointer to an optional, null-terminated Unicode string that gives the registry path, including the value name, where the
		/// format string is stored as a REG_SZ value. The autocomplete object first looks for the path under HKEY_CURRENT_USER. If it
		/// fails, it tries HKEY_LOCAL_MACHINE. For a discussion of the format string, see the definition of pwszQuickComplete.
		/// </param>
		/// <param name="pwszQuickComplete">
		/// A pointer to an optional null-terminated Unicode string that specifies the format to be used if the user enters text and
		/// presses CTRL+ENTER. Set this parameter to NULL to disable quick completion. Otherwise, the autocomplete object treats
		/// pwszQuickComplete as a StringCchPrintf format string and the text in the edit box as its associated argument, to produce a
		/// new string. For example, set pwszQuickComplete to "http://www.%s.com/". When a user enters "MyURL" into the edit box and
		/// presses CTRL+ENTER, the text in the edit box is updated to "http://www.MyURL.com/".
		/// </param>
		new void Init(HWND hwndEdit, IEnumString punkAcl, [MarshalAs(UnmanagedType.LPWStr)] string? pwszRegKeyPath, [MarshalAs(UnmanagedType.LPWStr)] string? pwszQuickComplete);

		/// <summary>Enables or disables autocompletion.</summary>
		/// <param name="fEnable">A value that is set to TRUE to enable autocompletion, or FALSE to disable it.</param>
		new void Enable([MarshalAs(UnmanagedType.Bool)] bool fEnable);

		/// <summary>Sets the current autocomplete options.</summary>
		/// <param name="dwFlag">One or more flags from the AUTOCOMPLETEOPTIONS enumeration that specify autocomplete options.</param>
		void SetOptions(AUTOCOMPLETEOPTIONS dwFlag);

		/// <summary>Gets the current autocomplete options.</summary>
		/// <param name="dwFlag">
		/// One or more flags from the AUTOCOMPLETEOPTIONS enumeration that indicate the options that are currently set.
		/// </param>
		void GetOptions(out AUTOCOMPLETEOPTIONS dwFlag);
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("shldisp.h")]
	[ComImport, Guid("2D91EEA1-9932-11D2-BE86-00A0C9A83DA1"), CoClass(typeof(FileSearchBand))]
	public interface IFileSearchBand
	{
		/// <summary>Undocumented.</summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1)]
		void SetFocus();

		/// <summary>Undocumented.</summary>
		/// <param name="pbstrSearchID"/>
		/// <param name="bNavToResults"/>
		/// <param name="pvarScope"/>
		/// <param name="pvarQueryFile"/>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(2)]
		void SetSearchParameters([In, MarshalAs(UnmanagedType.BStr)] in string pbstrSearchID,
			[In, MarshalAs(UnmanagedType.VariantBool)] bool bNavToResults,
			[In, Optional, MarshalAs(UnmanagedType.Struct)] in object? pvarScope,
			[In, Optional, MarshalAs(UnmanagedType.Struct)] in object? pvarQueryFile);

		/// <summary>Undocumented.</summary>
		[DispId(3)]
		string SearchID { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(3)] get; }

		/// <summary>Undocumented.</summary>
		[DispId(4)]
		object Scope { [return: MarshalAs(UnmanagedType.Struct)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(4)] get; }

		/// <summary>Undocumented.</summary>
		[DispId(5)]
		object QueryFile { [return: MarshalAs(UnmanagedType.Struct)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(5)] get; }
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("shldisp.h")]
	[ComImport, Guid("9BA05970-F6A8-11CF-A442-00A0C90A8F39"), CoClass(typeof(ShellFolderViewOC))]
	public interface IFolderViewOC
	{
		/// <summary>Undocumented.</summary>
		/// <param name="pdisp"/>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)]
		void SetFolderView([In, MarshalAs(UnmanagedType.IDispatch)] object pdisp);
	}

	/// <summary>
	/// Extends the <c>WebWizardHost</c> object by enabling server-side pages hosted in a wizard to verify that the user has been
	/// authenticated through a Microsoft account.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/newwdevents
	[PInvokeData("shldisp.h", MSDNShortId = "44f2431c-82a2-4142-bf20-55fdd0c88008")]
	[ComImport, Guid("0751C551-7568-41C9-8E5B-E22E38919236")]
	public interface INewWDEvents : IWebWizardHost
	{
		/// <summary>Navigates to the client-side page immediately preceding the page hosting the server-side HTML pages.</summary>
		/// <remarks>
		/// When the wizard displays the first server-side page and the user clicks the <c>Back</c> button, the server invokes
		/// <c>FinalBack</c> when notified of that event by the client's event handler.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-finalback
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
		new void FinalBack();

		/// <summary>
		/// Navigates to the client-side wizard page that follows the page that hosts the server-side HTML pages, or finishes the wizard
		/// if there are no further client-side pages.
		/// </summary>
		/// <remarks>
		/// When the wizard is displaying the last server-side HTML page and the user clicks the <c>Next</c> or <c>Finish</c> button, the
		/// server invokes <c>FinalNext</c> in that button's event handler.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-finalnext
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1)]
		new void FinalNext();

		/// <summary>Simulates a <c>Cancel</c> button click.</summary>
		/// <remarks>The client is responsible for responding to this method with the expected behavior by closing the wizard.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-cancel
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(2)]
		new void Cancel();

		/// <summary>This property is not implemented.</summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb774352(v=vs.85)
		[DispId(3)]
		new string Caption { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(3)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(3)] set; }

		/// <summary>Sets or retrieves a property's current value.</summary>
		/// <value>The property value.</value>
		/// <param name="bstrPropertyName">Name of the property.</param>
		[DispId(4)]
		new object this[string bstrPropertyName] { [return: MarshalAs(UnmanagedType.Struct)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(4)] get; [param: In, MarshalAs(UnmanagedType.Struct)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(4)] set; }

		/// <summary>Updates the <c>Back</c>, <c>Next</c>, and <c>Finish</c> buttons in the client's wizard frame.</summary>
		/// <param name="vfEnableBack">Enables the <c>Back</c> button.</param>
		/// <param name="vfEnableNext">Enables the <c>Next</c> button.</param>
		/// <param name="vfLastPage">Enables the <c>Finish</c> button. States that this is the last server-side page.</param>
		/// <remarks>
		/// Be sure to implement handler functions in each server-side page for OnBack() and OnNext(), corresponding to the wizard
		/// buttons <c>Back</c> and <c>Next</c>. The OnBack() and OnNext() functions respond to <c>SetWizardButtons</c>. At the
		/// appropriate time, the OnNext() function calls <c>SetWizardButtons</c> with vbLastPage= <c>true</c>, which can enable a
		/// <c>Finish</c> button. OnNext() also calls <c>FinalNext</c> when a user clicks the <c>Finish</c> button.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-setwizardbuttons
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(5)]
		new void SetWizardButtons([In] bool vfEnableBack, [In] bool vfEnableNext, [In] bool vfLastPage);

		/// <summary>
		/// Sets the title and subtitle that appear in the wizard header. In general, the client will display the header above the HTML
		/// and below the title bar.
		/// </summary>
		/// <param name="bstrHeaderTitle">String containing the title.</param>
		/// <param name="bstrHeaderSubtitle">String containing the subtitle.</param>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-setheadertext
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(6)]
		new void SetHeaderText([In, MarshalAs(UnmanagedType.BStr)] string bstrHeaderTitle, [In, MarshalAs(UnmanagedType.BStr)] string bstrHeaderSubtitle);

		/// <summary>
		/// Enables server-side pages hosted in a wizard to verify that the user has been authenticated through a Microsoft account.
		/// </summary>
		/// <param name="bstrSignInUrl">A string containing the URL of a webpage that redirects to the Microsoft account log on UI.</param>
		/// <returns>Set to <c>true</c> if authentication succeeds, <c>false</c> otherwise.</returns>
		/// <remarks>
		/// This method may be called even if a user is already logged on to a Microsoft account. In that case, the method returns
		/// <c>true</c> without displaying the Microsoft account log on UI.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/inewwdevents-passportauthenticate
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(7)]
		bool PassportAuthenticate([In, MarshalAs(UnmanagedType.BStr)] string bstrSignInUrl);
	}

	/// <summary>
	/// Represents an object in the Shell. Methods are provided to control the Shell and to execute commands within the Shell. There are
	/// also methods to obtain other Shell-related objects.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch
	[PInvokeData("shldisp.h", MSDNShortId = "9B429C03-7F80-45db-B8CD-58D19FAD2E61")]
	[ComImport, Guid("D8F015C0-C278-11CE-A49E-444553540000"), CoClass(typeof(Shell))]
	public interface IShellDispatch
	{
		/// <summary>
		/// <para>Contains an object that represents an application.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>This property is implemented and accessed through the <c>Shell.EjectPC</c> property.</para>
		/// <para>
		/// The <c>Application</c> property returns the automation object supported by the application that contains the WebBrowser
		/// control, if that object is accessible. Otherwise, this property returns the WebBrowser control's automation object.
		/// </para>
		/// <para>
		/// Use this property with the <c>Set</c> and <c>CreateObject</c> commands or with the <c>GetObject</c> command to create and
		/// manipulate an instance of the Windows Internet Explorer application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-application
		[DispId(0x60020000)]
		object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>
		/// <para>Retrieves an object that represents the parent of the current object.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>This property is implemented and accessed through the <c>Shell.Parent</c> property.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-parent
		[DispId(0x60020001)]
		object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>Creates and returns a <c>Folder</c> object for the specified folder.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The folder for which to create the <c>Folder</c> object. This can be a string that specifies the path of the folder or one of
		/// the <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in <c>ShellSpecialFolderConstants</c> are
		/// available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c><c>Folder</c>**</c></para>
		/// <para>
		/// Object reference to the <c>Folder</c> object for the specified folder. If the folder is not successfully created, this value
		/// returns <c>null</c>.
		/// </para>
		/// <para>VB</para>
		/// <para>Type: <c><c>Folder</c>**</c></para>
		/// <para>
		/// Object reference to the <c>Folder</c> object for the specified folder. If the folder is not successfully created, this value
		/// returns <c>null</c>.
		/// </para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.NameSpace</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-namespace
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
		Folder? NameSpace([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>
		/// Creates a dialog box that enables the user to select a folder and then returns the selected folder's <c>Folder</c> object.
		/// </summary>
		/// <param name="Hwnd">
		/// <para>Type: <c>Integer</c></para>
		/// <para>The handle to the parent window of the dialog box. This value can be zero.</para>
		/// </param>
		/// <param name="Title">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> value that represents the title displayed inside the <c>Browse</c> dialog box.</para>
		/// </param>
		/// <param name="Options">
		/// <para>Type: <c>Integer</c></para>
		/// <para>
		/// An <c>Integer</c> value that contains the options for the method. This can be zero or a combination of the values listed
		/// under the <c>ulFlags</c> member of the <see cref="BROWSEINFO"/> structure.
		/// </para>
		/// </param>
		/// <param name="RootFolder">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The root folder to use in the dialog box. The user cannot browse higher in the tree than this folder. If this value is not
		/// specified, the root folder used in the dialog box is the desktop. This value can be a string that specifies the path of the
		/// folder or one of the <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in
		/// <c>ShellSpecialFolderConstants</c> are available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric
		/// values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>FOLDER**</c></para>
		/// <para>An object reference to the selected folder's <c>Folder</c> object.</para>
		/// <para>VB</para>
		/// <para>Type: <c>FOLDER**</c></para>
		/// <para>An object reference to the selected folder's <c>Folder</c> object.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.BrowseForFolder</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-browseforfolder
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		Folder BrowseForFolder([In] int Hwnd, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In] BrowseInfoFlag Options, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? RootFolder);

		/// <summary>
		/// Creates and returns a <c>ShellWindows</c> object. This object represents a collection of all of the open windows that belong
		/// to the Shell.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c><c>IDispatch</c>**</c></para>
		/// <para>An object reference to the <c>ShellWindows</c> object.</para>
		/// <para>VB</para>
		/// <para>Type: <c><c>IDispatch</c>**</c></para>
		/// <para>An object reference to the <c>ShellWindows</c> object.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Windows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-windows
		[return: MarshalAs(UnmanagedType.IDispatch)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
		object Windows();

		/// <summary>Opens the specified folder.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// A string that specifies the path of the folder or one of the <c>ShellSpecialFolderConstants</c> values. Note that the
		/// constant names found in <c>ShellSpecialFolderConstants</c> are available in Visual Basic, but not in VBScript or JScript. In
		/// those cases, the numeric values must be used in their place.
		/// </para>
		/// <para>
		/// If vDir is set to one of the <c>ShellSpecialFolderConstants</c> and the special folder does not exist, this function will
		/// create the folder.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Open</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-open
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
		void Open([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>Opens a specified folder in a Windows Explorer window.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The folder to be displayed. This can be a string that specifies the path of the folder or one of the
		/// <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in <c>ShellSpecialFolderConstants</c> are
		/// available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Explore</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-explore
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		void Explore([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>
		/// Minimizes all of the windows on the desktop. This method has the same effect as right-clicking the taskbar and selecting
		/// <c>Minimize All Windows</c> on older systems or clicking the <c>Show Desktop</c> icon on the taskbar.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.MinimizeAll</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-minimizeall
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		void MinimizeAll();

		/// <summary>
		/// Restores all desktop windows to the state they were in before the last <c>MinimizeAll</c> command. This method has the same
		/// effect as right-clicking the taskbar and selecting <c>Undo Minimize All Windows</c> (on older systems) or a second clicking
		/// of the <c>Show Desktop</c> icon in the taskbar.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.UndoMinimizeAll</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-undominimizeall
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)]
		void UndoMinimizeALL();

		/// <summary>Displays the <c>Run</c> dialog to the user.</summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FileRun</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-filerun
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)]
		void FileRun();

		/// <summary>
		/// Cascades all of the windows on the desktop. This method has the same effect as right-clicking the taskbar and selecting
		/// <c>Cascade windows</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.CascadeWindows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-cascadewindows
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)]
		void CascadeWindows();

		/// <summary>
		/// Tiles all of the windows on the desktop vertically. This method has the same effect as right-clicking the taskbar and
		/// selecting <c>Show windows side by side</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TileVertically</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-tilevertically
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000b)]
		void TileVertically();

		/// <summary>
		/// Tiles all of the windows on the desktop horizontally. This method has the same effect as right-clicking the taskbar and
		/// selecting <c>Show windows stacked</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TileHorizontally</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-tilehorizontally
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000c)]
		void TileHorizontally();

		/// <summary>
		/// Displays the <c>Shut Down Windows</c> dialog box. This is the same as clicking the <c>Start</c> menu and selecting <c>Shut Down</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.ShutdownWindows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-shutdownwindows
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000d)]
		void ShutdownWindows();

		/// <summary>This method is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-suspend
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
		void Suspend();

		/// <summary>
		/// Ejects the computer from its docking station. This is the same as clicking the <c>Start</c> menu and selecting <c>Eject
		/// PC</c>, if your computer supports this command.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.EjectPC</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-ejectpc
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000f)]
		void EjectPC();

		/// <summary>
		/// Displays the <c>Date and Time</c> dialog box. This method has the same effect as right-clicking the clock in the taskbar
		/// status area and selecting <c>Adjust date/time</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.SetTime</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-settime
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020010)]
		void SetTime();

		/// <summary>
		/// Displays the <c>Taskbar and Start Menu Properties</c> dialog box. This method has the same effect as right-clicking the
		/// taskbar and selecting <c>Properties</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TrayProperties</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-trayproperties
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020011)]
		void TrayProperties();

		/// <summary>
		/// Displays the Windows Help and Support window. This method has the same effect as clicking the <c>Start</c> menu and selecting
		/// <c>Help and Support</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Help</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-help
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020012)]
		void Help();

		/// <summary>
		/// Displays the <c>Find: All Files</c> dialog box. This is the same as clicking the <c>Start</c> menu and then selecting <c>Search</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FindFiles</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-findfiles
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020013)]
		void FindFiles();

		/// <summary>
		/// Displays the <c>Search Results: Computers</c> dialog box. The dialog box shows the result of the search for a specified computer.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FindComputer</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-findcomputer
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020014)]
		void FindComputer();

		/// <summary>Refreshes the contents of the <c>Start</c> menu. Used only with systems preceding Windows XP.</summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.TrayProperties</c> method.</para>
		/// <para>
		/// The functionality that <c>RefreshMenu</c> provides is handled automatically under Windows XP or later. Do not call this
		/// method on Windows XP or later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-refreshmenu
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020015)]
		void RefreshMenu();

		/// <summary>
		/// Runs the specified Control Panel application. If the application is already open, it will activate the running instance.
		/// </summary>
		/// <param name="bstrDir">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>The Control Panel application's file name.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.ControlPanelItem</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-controlpanelitem
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020016)]
		void ControlPanelItem([In, MarshalAs(UnmanagedType.BStr)] string bstrDir);
	}

	/// <summary>Extends the <c>IShellDispatch</c> object with a variety of new functionality.</summary>
	/// <remarks>For a discussion of Windows services, see the Services documentation.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-object
	[PInvokeData("shldisp.h", MSDNShortId = "74687929-0777-479b-9853-2b0cf4b6adc9")]
	[ComImport, Guid("A4C6892C-3BA9-11D2-9DEA-00C04FB16162"), CoClass(typeof(Shell))]
	public interface IShellDispatch2 : IShellDispatch
	{
		/// <summary>
		/// <para>Contains an object that represents an application.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>This property is implemented and accessed through the <c>Shell.EjectPC</c> property.</para>
		/// <para>
		/// The <c>Application</c> property returns the automation object supported by the application that contains the WebBrowser
		/// control, if that object is accessible. Otherwise, this property returns the WebBrowser control's automation object.
		/// </para>
		/// <para>
		/// Use this property with the <c>Set</c> and <c>CreateObject</c> commands or with the <c>GetObject</c> command to create and
		/// manipulate an instance of the Windows Internet Explorer application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-application
		[DispId(0x60020000)]
		new object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>
		/// <para>Retrieves an object that represents the parent of the current object.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>This property is implemented and accessed through the <c>Shell.Parent</c> property.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-parent
		[DispId(0x60020001)]
		new object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>Creates and returns a <c>Folder</c> object for the specified folder.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The folder for which to create the <c>Folder</c> object. This can be a string that specifies the path of the folder or one of
		/// the <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in <c>ShellSpecialFolderConstants</c> are
		/// available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c><c>Folder</c>**</c></para>
		/// <para>
		/// Object reference to the <c>Folder</c> object for the specified folder. If the folder is not successfully created, this value
		/// returns <c>null</c>.
		/// </para>
		/// <para>VB</para>
		/// <para>Type: <c><c>Folder</c>**</c></para>
		/// <para>
		/// Object reference to the <c>Folder</c> object for the specified folder. If the folder is not successfully created, this value
		/// returns <c>null</c>.
		/// </para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.NameSpace</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-namespace
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
		new Folder? NameSpace([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>
		/// Creates a dialog box that enables the user to select a folder and then returns the selected folder's <c>Folder</c> object.
		/// </summary>
		/// <param name="Hwnd">
		/// <para>Type: <c>Integer</c></para>
		/// <para>The handle to the parent window of the dialog box. This value can be zero.</para>
		/// </param>
		/// <param name="Title">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> value that represents the title displayed inside the <c>Browse</c> dialog box.</para>
		/// </param>
		/// <param name="Options">
		/// <para>Type: <c>Integer</c></para>
		/// <para>
		/// An <c>Integer</c> value that contains the options for the method. This can be zero or a combination of the values listed
		/// under the <c>ulFlags</c> member of the <c>BROWSEINFO</c> structure.
		/// </para>
		/// </param>
		/// <param name="RootFolder">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The root folder to use in the dialog box. The user cannot browse higher in the tree than this folder. If this value is not
		/// specified, the root folder used in the dialog box is the desktop. This value can be a string that specifies the path of the
		/// folder or one of the <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in
		/// <c>ShellSpecialFolderConstants</c> are available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric
		/// values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>FOLDER**</c></para>
		/// <para>An object reference to the selected folder's <c>Folder</c> object.</para>
		/// <para>VB</para>
		/// <para>Type: <c>FOLDER**</c></para>
		/// <para>An object reference to the selected folder's <c>Folder</c> object.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.BrowseForFolder</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-browseforfolder
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		new Folder BrowseForFolder([In] int Hwnd, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In] BrowseInfoFlag Options, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? RootFolder);

		/// <summary>
		/// Creates and returns a <c>ShellWindows</c> object. This object represents a collection of all of the open windows that belong
		/// to the Shell.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c><c>IDispatch</c>**</c></para>
		/// <para>An object reference to the <c>ShellWindows</c> object.</para>
		/// <para>VB</para>
		/// <para>Type: <c><c>IDispatch</c>**</c></para>
		/// <para>An object reference to the <c>ShellWindows</c> object.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Windows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-windows
		[return: MarshalAs(UnmanagedType.IDispatch)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
		new object Windows();

		/// <summary>Opens the specified folder.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// A string that specifies the path of the folder or one of the <c>ShellSpecialFolderConstants</c> values. Note that the
		/// constant names found in <c>ShellSpecialFolderConstants</c> are available in Visual Basic, but not in VBScript or JScript. In
		/// those cases, the numeric values must be used in their place.
		/// </para>
		/// <para>
		/// If vDir is set to one of the <c>ShellSpecialFolderConstants</c> and the special folder does not exist, this function will
		/// create the folder.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Open</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-open
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
		new void Open([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>Opens a specified folder in a Windows Explorer window.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The folder to be displayed. This can be a string that specifies the path of the folder or one of the
		/// <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in <c>ShellSpecialFolderConstants</c> are
		/// available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Explore</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-explore
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		new void Explore([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>
		/// Minimizes all of the windows on the desktop. This method has the same effect as right-clicking the taskbar and selecting
		/// <c>Minimize All Windows</c> on older systems or clicking the <c>Show Desktop</c> icon on the taskbar.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.MinimizeAll</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-minimizeall
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		new void MinimizeAll();

		/// <summary>
		/// Restores all desktop windows to the state they were in before the last <c>MinimizeAll</c> command. This method has the same
		/// effect as right-clicking the taskbar and selecting <c>Undo Minimize All Windows</c> (on older systems) or a second clicking
		/// of the <c>Show Desktop</c> icon in the taskbar.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.UndoMinimizeAll</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-undominimizeall
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)]
		new void UndoMinimizeALL();

		/// <summary>Displays the <c>Run</c> dialog to the user.</summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FileRun</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-filerun
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)]
		new void FileRun();

		/// <summary>
		/// Cascades all of the windows on the desktop. This method has the same effect as right-clicking the taskbar and selecting
		/// <c>Cascade windows</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.CascadeWindows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-cascadewindows
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)]
		new void CascadeWindows();

		/// <summary>
		/// Tiles all of the windows on the desktop vertically. This method has the same effect as right-clicking the taskbar and
		/// selecting <c>Show windows side by side</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TileVertically</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-tilevertically
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000b)]
		new void TileVertically();

		/// <summary>
		/// Tiles all of the windows on the desktop horizontally. This method has the same effect as right-clicking the taskbar and
		/// selecting <c>Show windows stacked</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TileHorizontally</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-tilehorizontally
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000c)]
		new void TileHorizontally();

		/// <summary>
		/// Displays the <c>Shut Down Windows</c> dialog box. This is the same as clicking the <c>Start</c> menu and selecting <c>Shut Down</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.ShutdownWindows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-shutdownwindows
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000d)]
		new void ShutdownWindows();

		/// <summary>This method is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-suspend
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
		new void Suspend();

		/// <summary>
		/// Ejects the computer from its docking station. This is the same as clicking the <c>Start</c> menu and selecting <c>Eject
		/// PC</c>, if your computer supports this command.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.EjectPC</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-ejectpc
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000f)]
		new void EjectPC();

		/// <summary>
		/// Displays the <c>Date and Time</c> dialog box. This method has the same effect as right-clicking the clock in the taskbar
		/// status area and selecting <c>Adjust date/time</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.SetTime</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-settime
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020010)]
		new void SetTime();

		/// <summary>
		/// Displays the <c>Taskbar and Start Menu Properties</c> dialog box. This method has the same effect as right-clicking the
		/// taskbar and selecting <c>Properties</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TrayProperties</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-trayproperties
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020011)]
		new void TrayProperties();

		/// <summary>
		/// Displays the Windows Help and Support window. This method has the same effect as clicking the <c>Start</c> menu and selecting
		/// <c>Help and Support</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Help</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-help
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020012)]
		new void Help();

		/// <summary>
		/// Displays the <c>Find: All Files</c> dialog box. This is the same as clicking the <c>Start</c> menu and then selecting <c>Search</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FindFiles</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-findfiles
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020013)]
		new void FindFiles();

		/// <summary>
		/// Displays the <c>Search Results: Computers</c> dialog box. The dialog box shows the result of the search for a specified computer.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FindComputer</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-findcomputer
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020014)]
		new void FindComputer();

		/// <summary>Refreshes the contents of the <c>Start</c> menu. Used only with systems preceding Windows XP.</summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.TrayProperties</c> method.</para>
		/// <para>
		/// The functionality that <c>RefreshMenu</c> provides is handled automatically under Windows XP or later. Do not call this
		/// method on Windows XP or later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-refreshmenu
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020015)]
		new void RefreshMenu();

		/// <summary>
		/// Runs the specified Control Panel application. If the application is already open, it will activate the running instance.
		/// </summary>
		/// <param name="bstrDir">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>The Control Panel application's file name.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.ControlPanelItem</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-controlpanelitem
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020016)]
		new void ControlPanelItem([In, MarshalAs(UnmanagedType.BStr)] string bstrDir);

		/// <summary>Retrieves a group's restriction setting from the registry.</summary>
		/// <param name="sGroup">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the group name. This value is the name of a registry subkey under which to check for the restriction.
		/// </para>
		/// </param>
		/// <param name="sRestriction">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the restriction whose value is to be retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Integer*</c></para>
		/// <para>The value of the restriction. If the specified restriction is not found, the return value is 0.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Integer*</c></para>
		/// <para>The value of the restriction. If the specified restriction is not found, the return value is 0.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.IsRestricted</c> method.</para>
		/// <para><c>IsRestricted</c> first looks for a subkey name that matches sGroup under the following key.</para>
		/// <para>
		/// Restrictions are declared as values of the individual policy subkeys. If the restriction named in sRestriction is found in
		/// the subkey named in sGroup, <c>IsRestricted</c> returns the restriction's current value. If the restriction is not found
		/// under <c>HKEY_LOCAL_MACHINE</c>, the same subkey is checked under <c>HKEY_CURRENT_USER</c>.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-isrestricted
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)]
		int IsRestricted([In, MarshalAs(UnmanagedType.BStr)] string sGroup, [In, MarshalAs(UnmanagedType.BStr)] string sRestriction);

		/// <summary>Performs a specified operation on a specified file.</summary>
		/// <param name="sFile">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the name of the file on which <c>ShellExecute</c> will perform the action specified by vOperation.
		/// </para>
		/// </param>
		/// <param name="vArguments">
		/// <para>Type: <c>Variant</c></para>
		/// <para>A string that contains parameter values for the operation.</para>
		/// </param>
		/// <param name="vDirectory">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The fully qualified path of the directory that contains the file specified by sFile. If this parameter is not specified, the
		/// current working directory is used.
		/// </para>
		/// </param>
		/// <param name="vOperation">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The operation to be performed. This value is set to one of the verb strings that is supported by the file. For a discussion
		/// of verbs, see the Remarks section. If this parameter is not specified, the default operation is performed.
		/// </para>
		/// </param>
		/// <param name="vShow">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// A recommendation as to how the application window should be displayed initially. The application can ignore this
		/// recommendation. This parameter can be one of the following values. If this parameter is not specified, the application uses
		/// its default value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Open the application with a hidden window.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Open the application with a normal window. If the window is minimized or maximized, the system restores it to its original
		/// size and position.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>Open the application with a minimized window.</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Open the application with a maximized window.</term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>Open the application with its window at its most recent size and position. The active window remains active.</term>
		/// </item>
		/// <item>
		/// <term>5</term>
		/// <term>Open the application with its window at its current size and position.</term>
		/// </item>
		/// <item>
		/// <term>7</term>
		/// <term>Open the application with a minimized window. The active window remains active.</term>
		/// </item>
		/// <item>
		/// <term>10</term>
		/// <term>Open the application with its window in the default state specified by the application.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ShellExecute</c> method.</para>
		/// <para>
		/// This method is equivalent to launching one of the commands associated with a file's shortcut menu. Each command is
		/// represented by a verb string. The set of supported verbs varies from file to file. The most commonly supported verb is
		/// "open", which is also usually the default verb. Other verbs might be supported by only certain types of files. For further
		/// discussion of Shell verbs, see Launching Applications or Extending Shortcut Menus.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-shellexecute
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030001)]
		void ShellExecute([In, MarshalAs(UnmanagedType.BStr)] string sFile, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vArguments,
			[In, Optional, MarshalAs(UnmanagedType.Struct)] object? vDirectory, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vOperation,
			[In, Optional, MarshalAs(UnmanagedType.Struct)] object? vShow);

		/// <summary>Displays the <c>Find Printer</c> dialog box.</summary>
		/// <param name="Name">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer name.</para>
		/// </param>
		/// <param name="location">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer location.</para>
		/// </param>
		/// <param name="model">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer model.</para>
		/// </param>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.FindPrinter</c> method.</para>
		/// <para>
		/// If you assign strings to one or more of the optional parameters, they are displayed as default values in the associated edit
		/// control when the <c>Find Printer</c> dialog box is displayed. The user can either accept or override these values. If no
		/// value is assigned to a parameter, the associated edit box is empty and the user must enter a value.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-findprinter
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030002)]
		void FindPrinter([In, Optional, MarshalAs(UnmanagedType.BStr)] string? Name, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? location, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? model);

		/// <summary>Retrieves system information.</summary>
		/// <param name="sName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that specifies the system information that is being requested.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Returns the value of the requested system information. The return type depends on which system information is requested. See
		/// the Remarks section for details.
		/// </para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Returns the value of the requested system information. The return type depends on which system information is requested. See
		/// the Remarks section for details.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.GetSystemInformation</c> method.</para>
		/// <para>
		/// This method can be used to request many system information values. The following table gives the sName value that is used to
		/// request the information and the associated type of the returned value.
		/// </para>
		/// <para>sName</para>
		/// <para>Return type</para>
		/// <para>Description</para>
		/// <para>DirectoryServiceAvailable</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the directory service is available; otherwise, <c>false</c>.</para>
		/// <para>DoubleClickTime</para>
		/// <para><c>Integer</c></para>
		/// <para>The double-click time, in milliseconds.</para>
		/// <para>ProcessorLevel</para>
		/// <para><c>Integer</c></para>
		/// <para>
		/// <c>Windows Vista and later</c>. The processor level. Returns 3, 4, or 5, for x386, x486, and Pentium-level processors, respectively.
		/// </para>
		/// <para>ProcessorSpeed</para>
		/// <para><c>Integer</c></para>
		/// <para>The processor speed, in megahertz (MHz).</para>
		/// <para>ProcessorArchitecture</para>
		/// <para><c>Integer</c></para>
		/// <para>
		/// The processor architecture. For details, see the discussion of the <c>wProcessorArchitecture</c> member of the
		/// <c>SYSTEM_INFO</c> structure.
		/// </para>
		/// <para>PhysicalMemoryInstalled</para>
		/// <para><c>Integer</c></para>
		/// <para>The amount of physical memory installed, in bytes.</para>
		/// <para>The following are valid only on Windows XP.</para>
		/// <para>IsOS_Professional</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the operating system is Windows XP Professional Edition; otherwise, <c>false</c>.</para>
		/// <para>IsOS_Personal</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the operating system is Windows XP Home Edition; otherwise, <c>false</c>.</para>
		/// <para>The following is valid only on Windows XP and later.</para>
		/// <para>IsOS_DomainMember</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the computer is a member of a domain; otherwise, <c>false</c>.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-getsysteminformation
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030003)]
		object GetSystemInformation([In, MarshalAs(UnmanagedType.BStr)] string sName);

		/// <summary>Starts a named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <param name="vPersistent">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Set to <c>true</c> to have the service started automatically by the service control manager during system startup. Set to
		/// <c>false</c> to leave the service configuration unchanged.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ServiceStart</c> method.</para>
		/// <para>
		/// The method returns <c>false</c> if the service has already been started. Before calling this method, you can call
		/// <c>Shell.IsServiceRunning</c> to ascertain the status of the service.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-servicestart
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030004)]
		object ServiceStart([In, MarshalAs(UnmanagedType.BStr)] string sServiceName, [In, MarshalAs(UnmanagedType.Struct)] object vPersistent);

		/// <summary>Stops a named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <param name="vPersistent">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Set to <c>true</c> to have the service started by the service control manager when <c>ServiceStart</c> is called. To leave
		/// the service configuration unchanged, set vPersistent to <c>false</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ServiceStop</c> method.</para>
		/// <para>
		/// The method returns <c>false</c> if the service has already been stopped. Before calling this method, you can call
		/// <c>Shell.IsServiceRunning</c> to ascertain the status of the service.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-servicestop
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030005)]
		object ServiceStop([In, MarshalAs(UnmanagedType.BStr)] string sServiceName, [In, MarshalAs(UnmanagedType.Struct)] object vPersistent);

		/// <summary>Returns a value that indicates whether a particular service is running.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the service specified by sServiceName is running; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the service specified by sServiceName is running; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.IsServiceRunning</c> method.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-isservicerunning
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030006)]
		object IsServiceRunning([In, MarshalAs(UnmanagedType.BStr)] string sServiceName);

		/// <summary>Determines if the current user can start and stop the named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c>String</c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the user can start and stop the service; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the user can start and stop the service; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.CanStartStopService</c> method.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-canstartstopservice
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030007)]
		object CanStartStopService([In, MarshalAs(UnmanagedType.BStr)] string sServiceName);

		/// <summary>Displays a browser bar.</summary>
		/// <param name="sCLSID">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the string form of the CLSID of the browser bar to be displayed. The object must be registered
		/// as an Explorer Bar object with a CATID_InfoBand component category. For further information, see Creating Custom Explorer
		/// Bars, Tool Bands, and Desk Bands.
		/// </para>
		/// </param>
		/// <param name="vShow">
		/// <para>Type: <c>Variant</c></para>
		/// <para>Set to <c>true</c> to show the browser bar or <c>false</c> to hide it.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ShowBrowserBar</c> method.</para>
		/// <para>
		/// You can display one of the standard Explorer Bars by setting the sCLSID parameter to the CLSID of that Explorer Bar. The
		/// standard Explorer Bars and their CLSID strings are as follows:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Explorer Bar</term>
		/// <term>CLSID string</term>
		/// </listheader>
		/// <item>
		/// <term>Favorites</term>
		/// <term>{EFA24E61-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>Folders</term>
		/// <term>{EFA24E64-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>History</term>
		/// <term>{EFA24E62-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>Search</term>
		/// <term>{30D02401-6A81-11d0-8274-00C04FD5AE38}</term>
		/// </item>
		/// </list>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-showbrowserbar
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030008)]
		object ShowBrowserBar([In, MarshalAs(UnmanagedType.BStr)] string sCLSID, [In, MarshalAs(UnmanagedType.Struct)] object vShow);
	}

	/// <summary>
	/// Extends the <c>IShellDispatch2</c> object. <c>IShellDispatch3</c> supports one new method in addition to the properties and
	/// methods supported by <c>IShellDispatch2</c>.
	/// </summary>
	/// <remarks>For a discussion of Windows services, see the Services documentation.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch3
	[PInvokeData("shldisp.h", MSDNShortId = "89d0aa4d-844d-497d-82bb-bcc2bcf9c78b")]
	[ComImport, Guid("177160CA-BB5A-411C-841D-BD38FACDEAA0"), CoClass(typeof(Shell))]
	public interface IShellDispatch3 : IShellDispatch2
	{
		/// <summary>
		/// <para>Contains an object that represents an application.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>This property is implemented and accessed through the <c>Shell.EjectPC</c> property.</para>
		/// <para>
		/// The <c>Application</c> property returns the automation object supported by the application that contains the WebBrowser
		/// control, if that object is accessible. Otherwise, this property returns the WebBrowser control's automation object.
		/// </para>
		/// <para>
		/// Use this property with the <c>Set</c> and <c>CreateObject</c> commands or with the <c>GetObject</c> command to create and
		/// manipulate an instance of the Windows Internet Explorer application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-application
		[DispId(0x60020000)]
		new object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>
		/// <para>Retrieves an object that represents the parent of the current object.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>This property is implemented and accessed through the <c>Shell.Parent</c> property.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-parent
		[DispId(0x60020001)]
		new object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>Creates and returns a <c>Folder</c> object for the specified folder.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The folder for which to create the <c>Folder</c> object. This can be a string that specifies the path of the folder or one of
		/// the <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in <c>ShellSpecialFolderConstants</c> are
		/// available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c><c>Folder</c>**</c></para>
		/// <para>
		/// Object reference to the <c>Folder</c> object for the specified folder. If the folder is not successfully created, this value
		/// returns <c>null</c>.
		/// </para>
		/// <para>VB</para>
		/// <para>Type: <c><c>Folder</c>**</c></para>
		/// <para>
		/// Object reference to the <c>Folder</c> object for the specified folder. If the folder is not successfully created, this value
		/// returns <c>null</c>.
		/// </para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.NameSpace</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-namespace
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
		new Folder? NameSpace([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>
		/// Creates a dialog box that enables the user to select a folder and then returns the selected folder's <c>Folder</c> object.
		/// </summary>
		/// <param name="Hwnd">
		/// <para>Type: <c>Integer</c></para>
		/// <para>The handle to the parent window of the dialog box. This value can be zero.</para>
		/// </param>
		/// <param name="Title">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> value that represents the title displayed inside the <c>Browse</c> dialog box.</para>
		/// </param>
		/// <param name="Options">
		/// <para>Type: <c>Integer</c></para>
		/// <para>
		/// An <c>Integer</c> value that contains the options for the method. This can be zero or a combination of the values listed
		/// under the <c>ulFlags</c> member of the <c>BROWSEINFO</c> structure.
		/// </para>
		/// </param>
		/// <param name="RootFolder">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The root folder to use in the dialog box. The user cannot browse higher in the tree than this folder. If this value is not
		/// specified, the root folder used in the dialog box is the desktop. This value can be a string that specifies the path of the
		/// folder or one of the <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in
		/// <c>ShellSpecialFolderConstants</c> are available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric
		/// values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>FOLDER**</c></para>
		/// <para>An object reference to the selected folder's <c>Folder</c> object.</para>
		/// <para>VB</para>
		/// <para>Type: <c>FOLDER**</c></para>
		/// <para>An object reference to the selected folder's <c>Folder</c> object.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.BrowseForFolder</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-browseforfolder
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		new Folder BrowseForFolder([In] int Hwnd, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In] BrowseInfoFlag Options, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? RootFolder);

		/// <summary>
		/// Creates and returns a <c>ShellWindows</c> object. This object represents a collection of all of the open windows that belong
		/// to the Shell.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c><c>IDispatch</c>**</c></para>
		/// <para>An object reference to the <c>ShellWindows</c> object.</para>
		/// <para>VB</para>
		/// <para>Type: <c><c>IDispatch</c>**</c></para>
		/// <para>An object reference to the <c>ShellWindows</c> object.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Windows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-windows
		[return: MarshalAs(UnmanagedType.IDispatch)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
		new object Windows();

		/// <summary>Opens the specified folder.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// A string that specifies the path of the folder or one of the <c>ShellSpecialFolderConstants</c> values. Note that the
		/// constant names found in <c>ShellSpecialFolderConstants</c> are available in Visual Basic, but not in VBScript or JScript. In
		/// those cases, the numeric values must be used in their place.
		/// </para>
		/// <para>
		/// If vDir is set to one of the <c>ShellSpecialFolderConstants</c> and the special folder does not exist, this function will
		/// create the folder.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Open</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-open
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
		new void Open([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>Opens a specified folder in a Windows Explorer window.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The folder to be displayed. This can be a string that specifies the path of the folder or one of the
		/// <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in <c>ShellSpecialFolderConstants</c> are
		/// available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Explore</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-explore
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		new void Explore([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>
		/// Minimizes all of the windows on the desktop. This method has the same effect as right-clicking the taskbar and selecting
		/// <c>Minimize All Windows</c> on older systems or clicking the <c>Show Desktop</c> icon on the taskbar.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.MinimizeAll</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-minimizeall
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		new void MinimizeAll();

		/// <summary>
		/// Restores all desktop windows to the state they were in before the last <c>MinimizeAll</c> command. This method has the same
		/// effect as right-clicking the taskbar and selecting <c>Undo Minimize All Windows</c> (on older systems) or a second clicking
		/// of the <c>Show Desktop</c> icon in the taskbar.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.UndoMinimizeAll</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-undominimizeall
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)]
		new void UndoMinimizeALL();

		/// <summary>Displays the <c>Run</c> dialog to the user.</summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FileRun</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-filerun
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)]
		new void FileRun();

		/// <summary>
		/// Cascades all of the windows on the desktop. This method has the same effect as right-clicking the taskbar and selecting
		/// <c>Cascade windows</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.CascadeWindows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-cascadewindows
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)]
		new void CascadeWindows();

		/// <summary>
		/// Tiles all of the windows on the desktop vertically. This method has the same effect as right-clicking the taskbar and
		/// selecting <c>Show windows side by side</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TileVertically</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-tilevertically
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000b)]
		new void TileVertically();

		/// <summary>
		/// Tiles all of the windows on the desktop horizontally. This method has the same effect as right-clicking the taskbar and
		/// selecting <c>Show windows stacked</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TileHorizontally</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-tilehorizontally
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000c)]
		new void TileHorizontally();

		/// <summary>
		/// Displays the <c>Shut Down Windows</c> dialog box. This is the same as clicking the <c>Start</c> menu and selecting <c>Shut Down</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.ShutdownWindows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-shutdownwindows
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000d)]
		new void ShutdownWindows();

		/// <summary>This method is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-suspend
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
		new void Suspend();

		/// <summary>
		/// Ejects the computer from its docking station. This is the same as clicking the <c>Start</c> menu and selecting <c>Eject
		/// PC</c>, if your computer supports this command.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.EjectPC</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-ejectpc
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000f)]
		new void EjectPC();

		/// <summary>
		/// Displays the <c>Date and Time</c> dialog box. This method has the same effect as right-clicking the clock in the taskbar
		/// status area and selecting <c>Adjust date/time</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.SetTime</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-settime
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020010)]
		new void SetTime();

		/// <summary>
		/// Displays the <c>Taskbar and Start Menu Properties</c> dialog box. This method has the same effect as right-clicking the
		/// taskbar and selecting <c>Properties</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TrayProperties</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-trayproperties
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020011)]
		new void TrayProperties();

		/// <summary>
		/// Displays the Windows Help and Support window. This method has the same effect as clicking the <c>Start</c> menu and selecting
		/// <c>Help and Support</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Help</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-help
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020012)]
		new void Help();

		/// <summary>
		/// Displays the <c>Find: All Files</c> dialog box. This is the same as clicking the <c>Start</c> menu and then selecting <c>Search</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FindFiles</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-findfiles
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020013)]
		new void FindFiles();

		/// <summary>
		/// Displays the <c>Search Results: Computers</c> dialog box. The dialog box shows the result of the search for a specified computer.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FindComputer</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-findcomputer
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020014)]
		new void FindComputer();

		/// <summary>Refreshes the contents of the <c>Start</c> menu. Used only with systems preceding Windows XP.</summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.TrayProperties</c> method.</para>
		/// <para>
		/// The functionality that <c>RefreshMenu</c> provides is handled automatically under Windows XP or later. Do not call this
		/// method on Windows XP or later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-refreshmenu
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020015)]
		new void RefreshMenu();

		/// <summary>
		/// Runs the specified Control Panel application. If the application is already open, it will activate the running instance.
		/// </summary>
		/// <param name="bstrDir">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>The Control Panel application's file name.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.ControlPanelItem</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-controlpanelitem
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020016)]
		new void ControlPanelItem([In, MarshalAs(UnmanagedType.BStr)] string bstrDir);

		/// <summary>Retrieves a group's restriction setting from the registry.</summary>
		/// <param name="sGroup">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the group name. This value is the name of a registry subkey under which to check for the restriction.
		/// </para>
		/// </param>
		/// <param name="sRestriction">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the restriction whose value is to be retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Integer*</c></para>
		/// <para>The value of the restriction. If the specified restriction is not found, the return value is 0.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Integer*</c></para>
		/// <para>The value of the restriction. If the specified restriction is not found, the return value is 0.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.IsRestricted</c> method.</para>
		/// <para><c>IsRestricted</c> first looks for a subkey name that matches sGroup under the following key.</para>
		/// <para>
		/// Restrictions are declared as values of the individual policy subkeys. If the restriction named in sRestriction is found in
		/// the subkey named in sGroup, <c>IsRestricted</c> returns the restriction's current value. If the restriction is not found
		/// under <c>HKEY_LOCAL_MACHINE</c>, the same subkey is checked under <c>HKEY_CURRENT_USER</c>.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-isrestricted
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)]
		new int IsRestricted([In, MarshalAs(UnmanagedType.BStr)] string sGroup, [In, MarshalAs(UnmanagedType.BStr)] string sRestriction);

		/// <summary>Performs a specified operation on a specified file.</summary>
		/// <param name="sFile">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the name of the file on which <c>ShellExecute</c> will perform the action specified by vOperation.
		/// </para>
		/// </param>
		/// <param name="vArguments">
		/// <para>Type: <c>Variant</c></para>
		/// <para>A string that contains parameter values for the operation.</para>
		/// </param>
		/// <param name="vDirectory">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The fully qualified path of the directory that contains the file specified by sFile. If this parameter is not specified, the
		/// current working directory is used.
		/// </para>
		/// </param>
		/// <param name="vOperation">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The operation to be performed. This value is set to one of the verb strings that is supported by the file. For a discussion
		/// of verbs, see the Remarks section. If this parameter is not specified, the default operation is performed.
		/// </para>
		/// </param>
		/// <param name="vShow">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// A recommendation as to how the application window should be displayed initially. The application can ignore this
		/// recommendation. This parameter can be one of the following values. If this parameter is not specified, the application uses
		/// its default value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Open the application with a hidden window.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Open the application with a normal window. If the window is minimized or maximized, the system restores it to its original
		/// size and position.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>Open the application with a minimized window.</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Open the application with a maximized window.</term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>Open the application with its window at its most recent size and position. The active window remains active.</term>
		/// </item>
		/// <item>
		/// <term>5</term>
		/// <term>Open the application with its window at its current size and position.</term>
		/// </item>
		/// <item>
		/// <term>7</term>
		/// <term>Open the application with a minimized window. The active window remains active.</term>
		/// </item>
		/// <item>
		/// <term>10</term>
		/// <term>Open the application with its window in the default state specified by the application.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ShellExecute</c> method.</para>
		/// <para>
		/// This method is equivalent to launching one of the commands associated with a file's shortcut menu. Each command is
		/// represented by a verb string. The set of supported verbs varies from file to file. The most commonly supported verb is
		/// "open", which is also usually the default verb. Other verbs might be supported by only certain types of files. For further
		/// discussion of Shell verbs, see Launching Applications or Extending Shortcut Menus.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-shellexecute
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030001)]
		new void ShellExecute([In, MarshalAs(UnmanagedType.BStr)] string sFile, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vArguments,
			[In, Optional, MarshalAs(UnmanagedType.Struct)] object? vDirectory, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vOperation,
			[In, Optional, MarshalAs(UnmanagedType.Struct)] object? vShow);

		/// <summary>Displays the <c>Find Printer</c> dialog box.</summary>
		/// <param name="Name">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer name.</para>
		/// </param>
		/// <param name="location">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer location.</para>
		/// </param>
		/// <param name="model">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer model.</para>
		/// </param>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.FindPrinter</c> method.</para>
		/// <para>
		/// If you assign strings to one or more of the optional parameters, they are displayed as default values in the associated edit
		/// control when the <c>Find Printer</c> dialog box is displayed. The user can either accept or override these values. If no
		/// value is assigned to a parameter, the associated edit box is empty and the user must enter a value.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-findprinter
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030002)]
		new void FindPrinter([In, Optional, MarshalAs(UnmanagedType.BStr)] string? Name, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? location, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? model);

		/// <summary>Retrieves system information.</summary>
		/// <param name="sName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that specifies the system information that is being requested.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Returns the value of the requested system information. The return type depends on which system information is requested. See
		/// the Remarks section for details.
		/// </para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Returns the value of the requested system information. The return type depends on which system information is requested. See
		/// the Remarks section for details.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.GetSystemInformation</c> method.</para>
		/// <para>
		/// This method can be used to request many system information values. The following table gives the sName value that is used to
		/// request the information and the associated type of the returned value.
		/// </para>
		/// <para>sName</para>
		/// <para>Return type</para>
		/// <para>Description</para>
		/// <para>DirectoryServiceAvailable</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the directory service is available; otherwise, <c>false</c>.</para>
		/// <para>DoubleClickTime</para>
		/// <para><c>Integer</c></para>
		/// <para>The double-click time, in milliseconds.</para>
		/// <para>ProcessorLevel</para>
		/// <para><c>Integer</c></para>
		/// <para>
		/// <c>Windows Vista and later</c>. The processor level. Returns 3, 4, or 5, for x386, x486, and Pentium-level processors, respectively.
		/// </para>
		/// <para>ProcessorSpeed</para>
		/// <para><c>Integer</c></para>
		/// <para>The processor speed, in megahertz (MHz).</para>
		/// <para>ProcessorArchitecture</para>
		/// <para><c>Integer</c></para>
		/// <para>
		/// The processor architecture. For details, see the discussion of the <c>wProcessorArchitecture</c> member of the
		/// <c>SYSTEM_INFO</c> structure.
		/// </para>
		/// <para>PhysicalMemoryInstalled</para>
		/// <para><c>Integer</c></para>
		/// <para>The amount of physical memory installed, in bytes.</para>
		/// <para>The following are valid only on Windows XP.</para>
		/// <para>IsOS_Professional</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the operating system is Windows XP Professional Edition; otherwise, <c>false</c>.</para>
		/// <para>IsOS_Personal</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the operating system is Windows XP Home Edition; otherwise, <c>false</c>.</para>
		/// <para>The following is valid only on Windows XP and later.</para>
		/// <para>IsOS_DomainMember</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the computer is a member of a domain; otherwise, <c>false</c>.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-getsysteminformation
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030003)]
		new object GetSystemInformation([In, MarshalAs(UnmanagedType.BStr)] string sName);

		/// <summary>Starts a named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <param name="vPersistent">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Set to <c>true</c> to have the service started automatically by the service control manager during system startup. Set to
		/// <c>false</c> to leave the service configuration unchanged.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ServiceStart</c> method.</para>
		/// <para>
		/// The method returns <c>false</c> if the service has already been started. Before calling this method, you can call
		/// <c>Shell.IsServiceRunning</c> to ascertain the status of the service.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-servicestart
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030004)]
		new object ServiceStart([In, MarshalAs(UnmanagedType.BStr)] string sServiceName, [In, MarshalAs(UnmanagedType.Struct)] object vPersistent);

		/// <summary>Stops a named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <param name="vPersistent">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Set to <c>true</c> to have the service started by the service control manager when <c>ServiceStart</c> is called. To leave
		/// the service configuration unchanged, set vPersistent to <c>false</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ServiceStop</c> method.</para>
		/// <para>
		/// The method returns <c>false</c> if the service has already been stopped. Before calling this method, you can call
		/// <c>Shell.IsServiceRunning</c> to ascertain the status of the service.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-servicestop
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030005)]
		new object ServiceStop([In, MarshalAs(UnmanagedType.BStr)] string sServiceName, [In, MarshalAs(UnmanagedType.Struct)] object vPersistent);

		/// <summary>Returns a value that indicates whether a particular service is running.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the service specified by sServiceName is running; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the service specified by sServiceName is running; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.IsServiceRunning</c> method.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-isservicerunning
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030006)]
		new object IsServiceRunning([In, MarshalAs(UnmanagedType.BStr)] string sServiceName);

		/// <summary>Determines if the current user can start and stop the named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c>String</c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the user can start and stop the service; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the user can start and stop the service; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.CanStartStopService</c> method.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-canstartstopservice
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030007)]
		new object CanStartStopService([In, MarshalAs(UnmanagedType.BStr)] string sServiceName);

		/// <summary>Displays a browser bar.</summary>
		/// <param name="sCLSID">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the string form of the CLSID of the browser bar to be displayed. The object must be registered
		/// as an Explorer Bar object with a CATID_InfoBand component category. For further information, see Creating Custom Explorer
		/// Bars, Tool Bands, and Desk Bands.
		/// </para>
		/// </param>
		/// <param name="vShow">
		/// <para>Type: <c>Variant</c></para>
		/// <para>Set to <c>true</c> to show the browser bar or <c>false</c> to hide it.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ShowBrowserBar</c> method.</para>
		/// <para>
		/// You can display one of the standard Explorer Bars by setting the sCLSID parameter to the CLSID of that Explorer Bar. The
		/// standard Explorer Bars and their CLSID strings are as follows:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Explorer Bar</term>
		/// <term>CLSID string</term>
		/// </listheader>
		/// <item>
		/// <term>Favorites</term>
		/// <term>{EFA24E61-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>Folders</term>
		/// <term>{EFA24E64-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>History</term>
		/// <term>{EFA24E62-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>Search</term>
		/// <term>{30D02401-6A81-11d0-8274-00C04FD5AE38}</term>
		/// </item>
		/// </list>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-showbrowserbar
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030008)]
		new object ShowBrowserBar([In, MarshalAs(UnmanagedType.BStr)] string sCLSID, [In, MarshalAs(UnmanagedType.Struct)] object vShow);

		/// <summary>Adds a file to the most recently used (MRU) list.</summary>
		/// <param name="varFile">
		/// <para>Type: <c>Variant</c></para>
		/// <para>A <c>String</c> that contains the path of the file to add to the list of recently used documents.</para>
		/// <para><c>Windows Vista</c>: Set this parameter to <c>null</c> to clear the recent documents folder.</para>
		/// </param>
		/// <param name="bstrCategory">A <c>String</c> that contains the name of the category in which to place the file.</param>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shell-addtorecent
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040000)]
		void AddToRecent([In, MarshalAs(UnmanagedType.Struct)] object? varFile, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? bstrCategory);
	}

	/// <summary>
	/// Extends the <c>IShellDispatch3</c> object. In addition to the properties and methods supported by <c>IShellDispatch3</c>,
	/// <c>IShellDispatch4</c> supports four additional methods.
	/// </summary>
	/// <remarks>For a discussion of Windows services, see the Services documentation.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4
	[PInvokeData("shldisp.h", MSDNShortId = "4fe37e38-ee71-41f0-b620-35fdc18f9dbb")]
	[ComImport, Guid("EFD84B2D-4BCF-4298-BE25-EB542A59FBDA"), CoClass(typeof(Shell))]
	public interface IShellDispatch4 : IShellDispatch3
	{
		/// <summary>
		/// <para>Contains an object that represents an application.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>This property is implemented and accessed through the <c>Shell.EjectPC</c> property.</para>
		/// <para>
		/// The <c>Application</c> property returns the automation object supported by the application that contains the WebBrowser
		/// control, if that object is accessible. Otherwise, this property returns the WebBrowser control's automation object.
		/// </para>
		/// <para>
		/// Use this property with the <c>Set</c> and <c>CreateObject</c> commands or with the <c>GetObject</c> command to create and
		/// manipulate an instance of the Windows Internet Explorer application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-application
		[DispId(0x60020000)]
		new object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>
		/// <para>Retrieves an object that represents the parent of the current object.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>This property is implemented and accessed through the <c>Shell.Parent</c> property.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-parent
		[DispId(0x60020001)]
		new object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>Creates and returns a <c>Folder</c> object for the specified folder.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The folder for which to create the <c>Folder</c> object. This can be a string that specifies the path of the folder or one of
		/// the <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in <c>ShellSpecialFolderConstants</c> are
		/// available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c><c>Folder</c>**</c></para>
		/// <para>
		/// Object reference to the <c>Folder</c> object for the specified folder. If the folder is not successfully created, this value
		/// returns <c>null</c>.
		/// </para>
		/// <para>VB</para>
		/// <para>Type: <c><c>Folder</c>**</c></para>
		/// <para>
		/// Object reference to the <c>Folder</c> object for the specified folder. If the folder is not successfully created, this value
		/// returns <c>null</c>.
		/// </para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.NameSpace</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-namespace
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
		new Folder? NameSpace([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>
		/// Creates a dialog box that enables the user to select a folder and then returns the selected folder's <c>Folder</c> object.
		/// </summary>
		/// <param name="Hwnd">
		/// <para>Type: <c>Integer</c></para>
		/// <para>The handle to the parent window of the dialog box. This value can be zero.</para>
		/// </param>
		/// <param name="Title">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> value that represents the title displayed inside the <c>Browse</c> dialog box.</para>
		/// </param>
		/// <param name="Options">
		/// <para>Type: <c>Integer</c></para>
		/// <para>
		/// An <c>Integer</c> value that contains the options for the method. This can be zero or a combination of the values listed
		/// under the <c>ulFlags</c> member of the <c>BROWSEINFO</c> structure.
		/// </para>
		/// </param>
		/// <param name="RootFolder">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The root folder to use in the dialog box. The user cannot browse higher in the tree than this folder. If this value is not
		/// specified, the root folder used in the dialog box is the desktop. This value can be a string that specifies the path of the
		/// folder or one of the <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in
		/// <c>ShellSpecialFolderConstants</c> are available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric
		/// values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>FOLDER**</c></para>
		/// <para>An object reference to the selected folder's <c>Folder</c> object.</para>
		/// <para>VB</para>
		/// <para>Type: <c>FOLDER**</c></para>
		/// <para>An object reference to the selected folder's <c>Folder</c> object.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.BrowseForFolder</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-browseforfolder
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		new Folder BrowseForFolder([In] int Hwnd, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In] BrowseInfoFlag Options,
			[In, Optional, MarshalAs(UnmanagedType.Struct)] object? RootFolder);

		/// <summary>
		/// Creates and returns a <c>ShellWindows</c> object. This object represents a collection of all of the open windows that belong
		/// to the Shell.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c><c>IDispatch</c>**</c></para>
		/// <para>An object reference to the <c>ShellWindows</c> object.</para>
		/// <para>VB</para>
		/// <para>Type: <c><c>IDispatch</c>**</c></para>
		/// <para>An object reference to the <c>ShellWindows</c> object.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Windows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-windows
		[return: MarshalAs(UnmanagedType.IDispatch)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
		new object Windows();

		/// <summary>Opens the specified folder.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// A string that specifies the path of the folder or one of the <c>ShellSpecialFolderConstants</c> values. Note that the
		/// constant names found in <c>ShellSpecialFolderConstants</c> are available in Visual Basic, but not in VBScript or JScript. In
		/// those cases, the numeric values must be used in their place.
		/// </para>
		/// <para>
		/// If vDir is set to one of the <c>ShellSpecialFolderConstants</c> and the special folder does not exist, this function will
		/// create the folder.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Open</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-open
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
		new void Open([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>Opens a specified folder in a Windows Explorer window.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The folder to be displayed. This can be a string that specifies the path of the folder or one of the
		/// <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in <c>ShellSpecialFolderConstants</c> are
		/// available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Explore</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-explore
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		new void Explore([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>
		/// Minimizes all of the windows on the desktop. This method has the same effect as right-clicking the taskbar and selecting
		/// <c>Minimize All Windows</c> on older systems or clicking the <c>Show Desktop</c> icon on the taskbar.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.MinimizeAll</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-minimizeall
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		new void MinimizeAll();

		/// <summary>
		/// Restores all desktop windows to the state they were in before the last <c>MinimizeAll</c> command. This method has the same
		/// effect as right-clicking the taskbar and selecting <c>Undo Minimize All Windows</c> (on older systems) or a second clicking
		/// of the <c>Show Desktop</c> icon in the taskbar.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.UndoMinimizeAll</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-undominimizeall
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)]
		new void UndoMinimizeALL();

		/// <summary>Displays the <c>Run</c> dialog to the user.</summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FileRun</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-filerun
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)]
		new void FileRun();

		/// <summary>
		/// Cascades all of the windows on the desktop. This method has the same effect as right-clicking the taskbar and selecting
		/// <c>Cascade windows</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.CascadeWindows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-cascadewindows
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)]
		new void CascadeWindows();

		/// <summary>
		/// Tiles all of the windows on the desktop vertically. This method has the same effect as right-clicking the taskbar and
		/// selecting <c>Show windows side by side</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TileVertically</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-tilevertically
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000b)]
		new void TileVertically();

		/// <summary>
		/// Tiles all of the windows on the desktop horizontally. This method has the same effect as right-clicking the taskbar and
		/// selecting <c>Show windows stacked</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TileHorizontally</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-tilehorizontally
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000c)]
		new void TileHorizontally();

		/// <summary>
		/// Displays the <c>Shut Down Windows</c> dialog box. This is the same as clicking the <c>Start</c> menu and selecting <c>Shut Down</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.ShutdownWindows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-shutdownwindows
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000d)]
		new void ShutdownWindows();

		/// <summary>This method is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-suspend
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
		new void Suspend();

		/// <summary>
		/// Ejects the computer from its docking station. This is the same as clicking the <c>Start</c> menu and selecting <c>Eject
		/// PC</c>, if your computer supports this command.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.EjectPC</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-ejectpc
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000f)]
		new void EjectPC();

		/// <summary>
		/// Displays the <c>Date and Time</c> dialog box. This method has the same effect as right-clicking the clock in the taskbar
		/// status area and selecting <c>Adjust date/time</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.SetTime</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-settime
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020010)]
		new void SetTime();

		/// <summary>
		/// Displays the <c>Taskbar and Start Menu Properties</c> dialog box. This method has the same effect as right-clicking the
		/// taskbar and selecting <c>Properties</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TrayProperties</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-trayproperties
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020011)]
		new void TrayProperties();

		/// <summary>
		/// Displays the Windows Help and Support window. This method has the same effect as clicking the <c>Start</c> menu and selecting
		/// <c>Help and Support</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Help</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-help
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020012)]
		new void Help();

		/// <summary>
		/// Displays the <c>Find: All Files</c> dialog box. This is the same as clicking the <c>Start</c> menu and then selecting <c>Search</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FindFiles</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-findfiles
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020013)]
		new void FindFiles();

		/// <summary>
		/// Displays the <c>Search Results: Computers</c> dialog box. The dialog box shows the result of the search for a specified computer.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FindComputer</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-findcomputer
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020014)]
		new void FindComputer();

		/// <summary>Refreshes the contents of the <c>Start</c> menu. Used only with systems preceding Windows XP.</summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.TrayProperties</c> method.</para>
		/// <para>
		/// The functionality that <c>RefreshMenu</c> provides is handled automatically under Windows XP or later. Do not call this
		/// method on Windows XP or later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-refreshmenu
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020015)]
		new void RefreshMenu();

		/// <summary>
		/// Runs the specified Control Panel application. If the application is already open, it will activate the running instance.
		/// </summary>
		/// <param name="bstrDir">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>The Control Panel application's file name.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.ControlPanelItem</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-controlpanelitem
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020016)]
		new void ControlPanelItem([In, MarshalAs(UnmanagedType.BStr)] string bstrDir);

		/// <summary>Retrieves a group's restriction setting from the registry.</summary>
		/// <param name="sGroup">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the group name. This value is the name of a registry subkey under which to check for the restriction.
		/// </para>
		/// </param>
		/// <param name="sRestriction">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the restriction whose value is to be retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Integer*</c></para>
		/// <para>The value of the restriction. If the specified restriction is not found, the return value is 0.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Integer*</c></para>
		/// <para>The value of the restriction. If the specified restriction is not found, the return value is 0.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.IsRestricted</c> method.</para>
		/// <para><c>IsRestricted</c> first looks for a subkey name that matches sGroup under the following key.</para>
		/// <para>
		/// Restrictions are declared as values of the individual policy subkeys. If the restriction named in sRestriction is found in
		/// the subkey named in sGroup, <c>IsRestricted</c> returns the restriction's current value. If the restriction is not found
		/// under <c>HKEY_LOCAL_MACHINE</c>, the same subkey is checked under <c>HKEY_CURRENT_USER</c>.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-isrestricted
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)]
		new int IsRestricted([In, MarshalAs(UnmanagedType.BStr)] string sGroup, [In, MarshalAs(UnmanagedType.BStr)] string sRestriction);

		/// <summary>Performs a specified operation on a specified file.</summary>
		/// <param name="sFile">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the name of the file on which <c>ShellExecute</c> will perform the action specified by vOperation.
		/// </para>
		/// </param>
		/// <param name="vArguments">
		/// <para>Type: <c>Variant</c></para>
		/// <para>A string that contains parameter values for the operation.</para>
		/// </param>
		/// <param name="vDirectory">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The fully qualified path of the directory that contains the file specified by sFile. If this parameter is not specified, the
		/// current working directory is used.
		/// </para>
		/// </param>
		/// <param name="vOperation">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The operation to be performed. This value is set to one of the verb strings that is supported by the file. For a discussion
		/// of verbs, see the Remarks section. If this parameter is not specified, the default operation is performed.
		/// </para>
		/// </param>
		/// <param name="vShow">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// A recommendation as to how the application window should be displayed initially. The application can ignore this
		/// recommendation. This parameter can be one of the following values. If this parameter is not specified, the application uses
		/// its default value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Open the application with a hidden window.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Open the application with a normal window. If the window is minimized or maximized, the system restores it to its original
		/// size and position.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>Open the application with a minimized window.</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Open the application with a maximized window.</term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>Open the application with its window at its most recent size and position. The active window remains active.</term>
		/// </item>
		/// <item>
		/// <term>5</term>
		/// <term>Open the application with its window at its current size and position.</term>
		/// </item>
		/// <item>
		/// <term>7</term>
		/// <term>Open the application with a minimized window. The active window remains active.</term>
		/// </item>
		/// <item>
		/// <term>10</term>
		/// <term>Open the application with its window in the default state specified by the application.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ShellExecute</c> method.</para>
		/// <para>
		/// This method is equivalent to launching one of the commands associated with a file's shortcut menu. Each command is
		/// represented by a verb string. The set of supported verbs varies from file to file. The most commonly supported verb is
		/// "open", which is also usually the default verb. Other verbs might be supported by only certain types of files. For further
		/// discussion of Shell verbs, see Launching Applications or Extending Shortcut Menus.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-shellexecute
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030001)]
		new void ShellExecute([In, MarshalAs(UnmanagedType.BStr)] string sFile, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vArguments,
			[In, Optional, MarshalAs(UnmanagedType.Struct)] object? vDirectory, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vOperation,
			[In, Optional, MarshalAs(UnmanagedType.Struct)] object? vShow);

		/// <summary>Displays the <c>Find Printer</c> dialog box.</summary>
		/// <param name="Name">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer name.</para>
		/// </param>
		/// <param name="location">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer location.</para>
		/// </param>
		/// <param name="model">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer model.</para>
		/// </param>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.FindPrinter</c> method.</para>
		/// <para>
		/// If you assign strings to one or more of the optional parameters, they are displayed as default values in the associated edit
		/// control when the <c>Find Printer</c> dialog box is displayed. The user can either accept or override these values. If no
		/// value is assigned to a parameter, the associated edit box is empty and the user must enter a value.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-findprinter
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030002)]
		new void FindPrinter([In, Optional, MarshalAs(UnmanagedType.BStr)] string? Name, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? location, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? model);

		/// <summary>Retrieves system information.</summary>
		/// <param name="sName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that specifies the system information that is being requested.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Returns the value of the requested system information. The return type depends on which system information is requested. See
		/// the Remarks section for details.
		/// </para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Returns the value of the requested system information. The return type depends on which system information is requested. See
		/// the Remarks section for details.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.GetSystemInformation</c> method.</para>
		/// <para>
		/// This method can be used to request many system information values. The following table gives the sName value that is used to
		/// request the information and the associated type of the returned value.
		/// </para>
		/// <para>sName</para>
		/// <para>Return type</para>
		/// <para>Description</para>
		/// <para>DirectoryServiceAvailable</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the directory service is available; otherwise, <c>false</c>.</para>
		/// <para>DoubleClickTime</para>
		/// <para><c>Integer</c></para>
		/// <para>The double-click time, in milliseconds.</para>
		/// <para>ProcessorLevel</para>
		/// <para><c>Integer</c></para>
		/// <para>
		/// <c>Windows Vista and later</c>. The processor level. Returns 3, 4, or 5, for x386, x486, and Pentium-level processors, respectively.
		/// </para>
		/// <para>ProcessorSpeed</para>
		/// <para><c>Integer</c></para>
		/// <para>The processor speed, in megahertz (MHz).</para>
		/// <para>ProcessorArchitecture</para>
		/// <para><c>Integer</c></para>
		/// <para>
		/// The processor architecture. For details, see the discussion of the <c>wProcessorArchitecture</c> member of the
		/// <c>SYSTEM_INFO</c> structure.
		/// </para>
		/// <para>PhysicalMemoryInstalled</para>
		/// <para><c>Integer</c></para>
		/// <para>The amount of physical memory installed, in bytes.</para>
		/// <para>The following are valid only on Windows XP.</para>
		/// <para>IsOS_Professional</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the operating system is Windows XP Professional Edition; otherwise, <c>false</c>.</para>
		/// <para>IsOS_Personal</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the operating system is Windows XP Home Edition; otherwise, <c>false</c>.</para>
		/// <para>The following is valid only on Windows XP and later.</para>
		/// <para>IsOS_DomainMember</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the computer is a member of a domain; otherwise, <c>false</c>.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-getsysteminformation
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030003)]
		new object GetSystemInformation([In, MarshalAs(UnmanagedType.BStr)] string sName);

		/// <summary>Starts a named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <param name="vPersistent">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Set to <c>true</c> to have the service started automatically by the service control manager during system startup. Set to
		/// <c>false</c> to leave the service configuration unchanged.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ServiceStart</c> method.</para>
		/// <para>
		/// The method returns <c>false</c> if the service has already been started. Before calling this method, you can call
		/// <c>Shell.IsServiceRunning</c> to ascertain the status of the service.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-servicestart
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030004)]
		new object ServiceStart([In, MarshalAs(UnmanagedType.BStr)] string sServiceName, [In, MarshalAs(UnmanagedType.Struct)] object vPersistent);

		/// <summary>Stops a named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <param name="vPersistent">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Set to <c>true</c> to have the service started by the service control manager when <c>ServiceStart</c> is called. To leave
		/// the service configuration unchanged, set vPersistent to <c>false</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ServiceStop</c> method.</para>
		/// <para>
		/// The method returns <c>false</c> if the service has already been stopped. Before calling this method, you can call
		/// <c>Shell.IsServiceRunning</c> to ascertain the status of the service.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-servicestop
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030005)]
		new object ServiceStop([In, MarshalAs(UnmanagedType.BStr)] string sServiceName, [In, MarshalAs(UnmanagedType.Struct)] object vPersistent);

		/// <summary>Returns a value that indicates whether a particular service is running.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the service specified by sServiceName is running; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the service specified by sServiceName is running; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.IsServiceRunning</c> method.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-isservicerunning
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030006)]
		new object IsServiceRunning([In, MarshalAs(UnmanagedType.BStr)] string sServiceName);

		/// <summary>Determines if the current user can start and stop the named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c>String</c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the user can start and stop the service; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the user can start and stop the service; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.CanStartStopService</c> method.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-canstartstopservice
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030007)]
		new object CanStartStopService([In, MarshalAs(UnmanagedType.BStr)] string sServiceName);

		/// <summary>Displays a browser bar.</summary>
		/// <param name="sCLSID">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the string form of the CLSID of the browser bar to be displayed. The object must be registered
		/// as an Explorer Bar object with a CATID_InfoBand component category. For further information, see Creating Custom Explorer
		/// Bars, Tool Bands, and Desk Bands.
		/// </para>
		/// </param>
		/// <param name="vShow">
		/// <para>Type: <c>Variant</c></para>
		/// <para>Set to <c>true</c> to show the browser bar or <c>false</c> to hide it.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ShowBrowserBar</c> method.</para>
		/// <para>
		/// You can display one of the standard Explorer Bars by setting the sCLSID parameter to the CLSID of that Explorer Bar. The
		/// standard Explorer Bars and their CLSID strings are as follows:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Explorer Bar</term>
		/// <term>CLSID string</term>
		/// </listheader>
		/// <item>
		/// <term>Favorites</term>
		/// <term>{EFA24E61-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>Folders</term>
		/// <term>{EFA24E64-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>History</term>
		/// <term>{EFA24E62-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>Search</term>
		/// <term>{30D02401-6A81-11d0-8274-00C04FD5AE38}</term>
		/// </item>
		/// </list>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-showbrowserbar
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030008)]
		new object ShowBrowserBar([In, MarshalAs(UnmanagedType.BStr)] string sCLSID, [In, MarshalAs(UnmanagedType.Struct)] object vShow);

		/// <summary>Adds a file to the most recently used (MRU) list.</summary>
		/// <param name="varFile">
		/// <para>Type: <c>Variant</c></para>
		/// <para>A <c>String</c> that contains the path of the file to add to the list of recently used documents.</para>
		/// <para><c>Windows Vista</c>: Set this parameter to <c>null</c> to clear the recent documents folder.</para>
		/// </param>
		/// <param name="bstrCategory">A <c>String</c> that contains the name of the category in which to place the file.</param>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shell-addtorecent
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040000)]
		new void AddToRecent([In, MarshalAs(UnmanagedType.Struct)] object? varFile, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? bstrCategory);

		/// <summary>Displays the <c>Windows Security</c> dialog box.</summary>
		/// <remarks>
		/// This method displays the dialog box shown after pressing CTRL+ALT+DELETE or using the security option on the <c>Start</c> menu.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-windowssecurity
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60050000)]
		void WindowsSecurity();

		/// <summary>Displays or hides the desktop.</summary>
		/// <remarks>
		/// This method has the same effect as the <c>Show Desktop</c> button on the taskbar. It either hides all open windows to show
		/// the desktop or it hides the desktop by showing all open windows. The <c>ToggleDesktop</c> method does not display a user
		/// interface, it just invokes the toggle action.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-toggledesktop
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60050001)]
		void ToggleDesktop();

		/// <summary>Gets the value for a specified Windows Internet Explorer policy.</summary>
		/// <param name="bstrPolicyName">A <c>String</c> that specifies the name of the policy.</param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>The value associated with the specified policy name.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>The value associated with the specified policy name.</para>
		/// </returns>
		/// <remarks>
		/// <para>Network Administrators can control and manage the computing environment of their users by setting policies.</para>
		/// <para>
		/// The specified value name must be within the <c>HKEY_CURRENT_USER</c>\ <c>Software</c>\ <c>Microsoft</c>\ <c>Windows</c>\
		/// <c>CurrentVersion</c>\ <c>Policies</c>\ <c>Explorer</c> subkey. If the value name does not exist then the method returns <c>null</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-explorerpolicy
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60050002)]
		object? ExplorerPolicy([In, MarshalAs(UnmanagedType.BStr)] string bstrPolicyName);

		/// <summary>Retrieves a global Shell setting.</summary>
		/// <param name="lSetting">
		/// A value that specifies the current Shell setting to retrieve. Only one setting can be retrieved in each call. The following
		/// values are recognized by this method.
		/// </param>
		/// <returns>Set to <c>true</c> if the setting exists; otherwise, <c>false</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-getsetting
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60050003)]
		bool GetSetting([In] SSF lSetting);
	}

	/// <summary>
	/// Extends the <c>IShellDispatch4</c> object. In addition to the properties and methods supported by <c>IShellDispatch4</c>,
	/// <c>IShellDispatch5</c> adds a method that displays open windows in a 3D stack.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch5
	[PInvokeData("shldisp.h", MSDNShortId = "9170340a-0f11-4ec9-877d-fb7fef9888b2")]
	[ComImport, Guid("866738B9-6CF2-4DE8-8767-F794EBE74F4E"), CoClass(typeof(Shell))]
	public interface IShellDispatch5 : IShellDispatch4
	{
		/// <summary>
		/// <para>Contains an object that represents an application.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>This property is implemented and accessed through the <c>Shell.EjectPC</c> property.</para>
		/// <para>
		/// The <c>Application</c> property returns the automation object supported by the application that contains the WebBrowser
		/// control, if that object is accessible. Otherwise, this property returns the WebBrowser control's automation object.
		/// </para>
		/// <para>
		/// Use this property with the <c>Set</c> and <c>CreateObject</c> commands or with the <c>GetObject</c> command to create and
		/// manipulate an instance of the Windows Internet Explorer application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-application
		[DispId(0x60020000)]
		new object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>
		/// <para>Retrieves an object that represents the parent of the current object.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>This property is implemented and accessed through the <c>Shell.Parent</c> property.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-parent
		[DispId(0x60020001)]
		new object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>Creates and returns a <c>Folder</c> object for the specified folder.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The folder for which to create the <c>Folder</c> object. This can be a string that specifies the path of the folder or one of
		/// the <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in <c>ShellSpecialFolderConstants</c> are
		/// available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c><c>Folder</c>**</c></para>
		/// <para>
		/// Object reference to the <c>Folder</c> object for the specified folder. If the folder is not successfully created, this value
		/// returns <c>null</c>.
		/// </para>
		/// <para>VB</para>
		/// <para>Type: <c><c>Folder</c>**</c></para>
		/// <para>
		/// Object reference to the <c>Folder</c> object for the specified folder. If the folder is not successfully created, this value
		/// returns <c>null</c>.
		/// </para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.NameSpace</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-namespace
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
		new Folder? NameSpace([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>
		/// Creates a dialog box that enables the user to select a folder and then returns the selected folder's <c>Folder</c> object.
		/// </summary>
		/// <param name="Hwnd">
		/// <para>Type: <c>Integer</c></para>
		/// <para>The handle to the parent window of the dialog box. This value can be zero.</para>
		/// </param>
		/// <param name="Title">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> value that represents the title displayed inside the <c>Browse</c> dialog box.</para>
		/// </param>
		/// <param name="Options">
		/// <para>Type: <c>Integer</c></para>
		/// <para>
		/// An <c>Integer</c> value that contains the options for the method. This can be zero or a combination of the values listed
		/// under the <c>ulFlags</c> member of the <c>BROWSEINFO</c> structure.
		/// </para>
		/// </param>
		/// <param name="RootFolder">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The root folder to use in the dialog box. The user cannot browse higher in the tree than this folder. If this value is not
		/// specified, the root folder used in the dialog box is the desktop. This value can be a string that specifies the path of the
		/// folder or one of the <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in
		/// <c>ShellSpecialFolderConstants</c> are available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric
		/// values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>FOLDER**</c></para>
		/// <para>An object reference to the selected folder's <c>Folder</c> object.</para>
		/// <para>VB</para>
		/// <para>Type: <c>FOLDER**</c></para>
		/// <para>An object reference to the selected folder's <c>Folder</c> object.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.BrowseForFolder</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-browseforfolder
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		new Folder BrowseForFolder([In] int Hwnd, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In] BrowseInfoFlag Options, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? RootFolder);

		/// <summary>
		/// Creates and returns a <c>ShellWindows</c> object. This object represents a collection of all of the open windows that belong
		/// to the Shell.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c><c>IDispatch</c>**</c></para>
		/// <para>An object reference to the <c>ShellWindows</c> object.</para>
		/// <para>VB</para>
		/// <para>Type: <c><c>IDispatch</c>**</c></para>
		/// <para>An object reference to the <c>ShellWindows</c> object.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Windows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-windows
		[return: MarshalAs(UnmanagedType.IDispatch)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
		new object Windows();

		/// <summary>Opens the specified folder.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// A string that specifies the path of the folder or one of the <c>ShellSpecialFolderConstants</c> values. Note that the
		/// constant names found in <c>ShellSpecialFolderConstants</c> are available in Visual Basic, but not in VBScript or JScript. In
		/// those cases, the numeric values must be used in their place.
		/// </para>
		/// <para>
		/// If vDir is set to one of the <c>ShellSpecialFolderConstants</c> and the special folder does not exist, this function will
		/// create the folder.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Open</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-open
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
		new void Open([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>Opens a specified folder in a Windows Explorer window.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The folder to be displayed. This can be a string that specifies the path of the folder or one of the
		/// <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in <c>ShellSpecialFolderConstants</c> are
		/// available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Explore</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-explore
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		new void Explore([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>
		/// Minimizes all of the windows on the desktop. This method has the same effect as right-clicking the taskbar and selecting
		/// <c>Minimize All Windows</c> on older systems or clicking the <c>Show Desktop</c> icon on the taskbar.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.MinimizeAll</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-minimizeall
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		new void MinimizeAll();

		/// <summary>
		/// Restores all desktop windows to the state they were in before the last <c>MinimizeAll</c> command. This method has the same
		/// effect as right-clicking the taskbar and selecting <c>Undo Minimize All Windows</c> (on older systems) or a second clicking
		/// of the <c>Show Desktop</c> icon in the taskbar.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.UndoMinimizeAll</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-undominimizeall
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)]
		new void UndoMinimizeALL();

		/// <summary>Displays the <c>Run</c> dialog to the user.</summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FileRun</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-filerun
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)]
		new void FileRun();

		/// <summary>
		/// Cascades all of the windows on the desktop. This method has the same effect as right-clicking the taskbar and selecting
		/// <c>Cascade windows</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.CascadeWindows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-cascadewindows
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)]
		new void CascadeWindows();

		/// <summary>
		/// Tiles all of the windows on the desktop vertically. This method has the same effect as right-clicking the taskbar and
		/// selecting <c>Show windows side by side</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TileVertically</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-tilevertically
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000b)]
		new void TileVertically();

		/// <summary>
		/// Tiles all of the windows on the desktop horizontally. This method has the same effect as right-clicking the taskbar and
		/// selecting <c>Show windows stacked</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TileHorizontally</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-tilehorizontally
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000c)]
		new void TileHorizontally();

		/// <summary>
		/// Displays the <c>Shut Down Windows</c> dialog box. This is the same as clicking the <c>Start</c> menu and selecting <c>Shut Down</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.ShutdownWindows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-shutdownwindows
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000d)]
		new void ShutdownWindows();

		/// <summary>This method is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-suspend
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
		new void Suspend();

		/// <summary>
		/// Ejects the computer from its docking station. This is the same as clicking the <c>Start</c> menu and selecting <c>Eject
		/// PC</c>, if your computer supports this command.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.EjectPC</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-ejectpc
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000f)]
		new void EjectPC();

		/// <summary>
		/// Displays the <c>Date and Time</c> dialog box. This method has the same effect as right-clicking the clock in the taskbar
		/// status area and selecting <c>Adjust date/time</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.SetTime</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-settime
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020010)]
		new void SetTime();

		/// <summary>
		/// Displays the <c>Taskbar and Start Menu Properties</c> dialog box. This method has the same effect as right-clicking the
		/// taskbar and selecting <c>Properties</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TrayProperties</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-trayproperties
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020011)]
		new void TrayProperties();

		/// <summary>
		/// Displays the Windows Help and Support window. This method has the same effect as clicking the <c>Start</c> menu and selecting
		/// <c>Help and Support</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Help</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-help
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020012)]
		new void Help();

		/// <summary>
		/// Displays the <c>Find: All Files</c> dialog box. This is the same as clicking the <c>Start</c> menu and then selecting <c>Search</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FindFiles</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-findfiles
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020013)]
		new void FindFiles();

		/// <summary>
		/// Displays the <c>Search Results: Computers</c> dialog box. The dialog box shows the result of the search for a specified computer.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FindComputer</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-findcomputer
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020014)]
		new void FindComputer();

		/// <summary>Refreshes the contents of the <c>Start</c> menu. Used only with systems preceding Windows XP.</summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.TrayProperties</c> method.</para>
		/// <para>
		/// The functionality that <c>RefreshMenu</c> provides is handled automatically under Windows XP or later. Do not call this
		/// method on Windows XP or later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-refreshmenu
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020015)]
		new void RefreshMenu();

		/// <summary>
		/// Runs the specified Control Panel application. If the application is already open, it will activate the running instance.
		/// </summary>
		/// <param name="bstrDir">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>The Control Panel application's file name.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.ControlPanelItem</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-controlpanelitem
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020016)]
		new void ControlPanelItem([In, MarshalAs(UnmanagedType.BStr)] string bstrDir);

		/// <summary>Retrieves a group's restriction setting from the registry.</summary>
		/// <param name="sGroup">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the group name. This value is the name of a registry subkey under which to check for the restriction.
		/// </para>
		/// </param>
		/// <param name="sRestriction">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the restriction whose value is to be retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Integer*</c></para>
		/// <para>The value of the restriction. If the specified restriction is not found, the return value is 0.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Integer*</c></para>
		/// <para>The value of the restriction. If the specified restriction is not found, the return value is 0.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.IsRestricted</c> method.</para>
		/// <para><c>IsRestricted</c> first looks for a subkey name that matches sGroup under the following key.</para>
		/// <para>
		/// Restrictions are declared as values of the individual policy subkeys. If the restriction named in sRestriction is found in
		/// the subkey named in sGroup, <c>IsRestricted</c> returns the restriction's current value. If the restriction is not found
		/// under <c>HKEY_LOCAL_MACHINE</c>, the same subkey is checked under <c>HKEY_CURRENT_USER</c>.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-isrestricted
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)]
		new int IsRestricted([In, MarshalAs(UnmanagedType.BStr)] string sGroup, [In, MarshalAs(UnmanagedType.BStr)] string sRestriction);

		/// <summary>Performs a specified operation on a specified file.</summary>
		/// <param name="sFile">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the name of the file on which <c>ShellExecute</c> will perform the action specified by vOperation.
		/// </para>
		/// </param>
		/// <param name="vArguments">
		/// <para>Type: <c>Variant</c></para>
		/// <para>A string that contains parameter values for the operation.</para>
		/// </param>
		/// <param name="vDirectory">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The fully qualified path of the directory that contains the file specified by sFile. If this parameter is not specified, the
		/// current working directory is used.
		/// </para>
		/// </param>
		/// <param name="vOperation">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The operation to be performed. This value is set to one of the verb strings that is supported by the file. For a discussion
		/// of verbs, see the Remarks section. If this parameter is not specified, the default operation is performed.
		/// </para>
		/// </param>
		/// <param name="vShow">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// A recommendation as to how the application window should be displayed initially. The application can ignore this
		/// recommendation. This parameter can be one of the following values. If this parameter is not specified, the application uses
		/// its default value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Open the application with a hidden window.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Open the application with a normal window. If the window is minimized or maximized, the system restores it to its original
		/// size and position.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>Open the application with a minimized window.</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Open the application with a maximized window.</term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>Open the application with its window at its most recent size and position. The active window remains active.</term>
		/// </item>
		/// <item>
		/// <term>5</term>
		/// <term>Open the application with its window at its current size and position.</term>
		/// </item>
		/// <item>
		/// <term>7</term>
		/// <term>Open the application with a minimized window. The active window remains active.</term>
		/// </item>
		/// <item>
		/// <term>10</term>
		/// <term>Open the application with its window in the default state specified by the application.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ShellExecute</c> method.</para>
		/// <para>
		/// This method is equivalent to launching one of the commands associated with a file's shortcut menu. Each command is
		/// represented by a verb string. The set of supported verbs varies from file to file. The most commonly supported verb is
		/// "open", which is also usually the default verb. Other verbs might be supported by only certain types of files. For further
		/// discussion of Shell verbs, see Launching Applications or Extending Shortcut Menus.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-shellexecute
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030001)]
		new void ShellExecute([In, MarshalAs(UnmanagedType.BStr)] string sFile, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vArguments,
			[In, Optional, MarshalAs(UnmanagedType.Struct)] object? vDirectory, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vOperation,
			[In, Optional, MarshalAs(UnmanagedType.Struct)] object? vShow);

		/// <summary>Displays the <c>Find Printer</c> dialog box.</summary>
		/// <param name="Name">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer name.</para>
		/// </param>
		/// <param name="location">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer location.</para>
		/// </param>
		/// <param name="model">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer model.</para>
		/// </param>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.FindPrinter</c> method.</para>
		/// <para>
		/// If you assign strings to one or more of the optional parameters, they are displayed as default values in the associated edit
		/// control when the <c>Find Printer</c> dialog box is displayed. The user can either accept or override these values. If no
		/// value is assigned to a parameter, the associated edit box is empty and the user must enter a value.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-findprinter
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030002)]
		new void FindPrinter([In, Optional, MarshalAs(UnmanagedType.BStr)] string? Name, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? location, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? model);

		/// <summary>Retrieves system information.</summary>
		/// <param name="sName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that specifies the system information that is being requested.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Returns the value of the requested system information. The return type depends on which system information is requested. See
		/// the Remarks section for details.
		/// </para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Returns the value of the requested system information. The return type depends on which system information is requested. See
		/// the Remarks section for details.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.GetSystemInformation</c> method.</para>
		/// <para>
		/// This method can be used to request many system information values. The following table gives the sName value that is used to
		/// request the information and the associated type of the returned value.
		/// </para>
		/// <para>sName</para>
		/// <para>Return type</para>
		/// <para>Description</para>
		/// <para>DirectoryServiceAvailable</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the directory service is available; otherwise, <c>false</c>.</para>
		/// <para>DoubleClickTime</para>
		/// <para><c>Integer</c></para>
		/// <para>The double-click time, in milliseconds.</para>
		/// <para>ProcessorLevel</para>
		/// <para><c>Integer</c></para>
		/// <para>
		/// <c>Windows Vista and later</c>. The processor level. Returns 3, 4, or 5, for x386, x486, and Pentium-level processors, respectively.
		/// </para>
		/// <para>ProcessorSpeed</para>
		/// <para><c>Integer</c></para>
		/// <para>The processor speed, in megahertz (MHz).</para>
		/// <para>ProcessorArchitecture</para>
		/// <para><c>Integer</c></para>
		/// <para>
		/// The processor architecture. For details, see the discussion of the <c>wProcessorArchitecture</c> member of the
		/// <c>SYSTEM_INFO</c> structure.
		/// </para>
		/// <para>PhysicalMemoryInstalled</para>
		/// <para><c>Integer</c></para>
		/// <para>The amount of physical memory installed, in bytes.</para>
		/// <para>The following are valid only on Windows XP.</para>
		/// <para>IsOS_Professional</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the operating system is Windows XP Professional Edition; otherwise, <c>false</c>.</para>
		/// <para>IsOS_Personal</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the operating system is Windows XP Home Edition; otherwise, <c>false</c>.</para>
		/// <para>The following is valid only on Windows XP and later.</para>
		/// <para>IsOS_DomainMember</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the computer is a member of a domain; otherwise, <c>false</c>.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-getsysteminformation
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030003)]
		new object GetSystemInformation([In, MarshalAs(UnmanagedType.BStr)] string sName);

		/// <summary>Starts a named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <param name="vPersistent">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Set to <c>true</c> to have the service started automatically by the service control manager during system startup. Set to
		/// <c>false</c> to leave the service configuration unchanged.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ServiceStart</c> method.</para>
		/// <para>
		/// The method returns <c>false</c> if the service has already been started. Before calling this method, you can call
		/// <c>Shell.IsServiceRunning</c> to ascertain the status of the service.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-servicestart
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030004)]
		new object ServiceStart([In, MarshalAs(UnmanagedType.BStr)] string sServiceName, [In, MarshalAs(UnmanagedType.Struct)] object vPersistent);

		/// <summary>Stops a named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <param name="vPersistent">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Set to <c>true</c> to have the service started by the service control manager when <c>ServiceStart</c> is called. To leave
		/// the service configuration unchanged, set vPersistent to <c>false</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ServiceStop</c> method.</para>
		/// <para>
		/// The method returns <c>false</c> if the service has already been stopped. Before calling this method, you can call
		/// <c>Shell.IsServiceRunning</c> to ascertain the status of the service.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-servicestop
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030005)]
		new object ServiceStop([In, MarshalAs(UnmanagedType.BStr)] string sServiceName, [In, MarshalAs(UnmanagedType.Struct)] object vPersistent);

		/// <summary>Returns a value that indicates whether a particular service is running.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the service specified by sServiceName is running; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the service specified by sServiceName is running; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.IsServiceRunning</c> method.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-isservicerunning
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030006)]
		new object IsServiceRunning([In, MarshalAs(UnmanagedType.BStr)] string sServiceName);

		/// <summary>Determines if the current user can start and stop the named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c>String</c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the user can start and stop the service; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the user can start and stop the service; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.CanStartStopService</c> method.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-canstartstopservice
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030007)]
		new object CanStartStopService([In, MarshalAs(UnmanagedType.BStr)] string sServiceName);

		/// <summary>Displays a browser bar.</summary>
		/// <param name="sCLSID">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the string form of the CLSID of the browser bar to be displayed. The object must be registered
		/// as an Explorer Bar object with a CATID_InfoBand component category. For further information, see Creating Custom Explorer
		/// Bars, Tool Bands, and Desk Bands.
		/// </para>
		/// </param>
		/// <param name="vShow">
		/// <para>Type: <c>Variant</c></para>
		/// <para>Set to <c>true</c> to show the browser bar or <c>false</c> to hide it.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ShowBrowserBar</c> method.</para>
		/// <para>
		/// You can display one of the standard Explorer Bars by setting the sCLSID parameter to the CLSID of that Explorer Bar. The
		/// standard Explorer Bars and their CLSID strings are as follows:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Explorer Bar</term>
		/// <term>CLSID string</term>
		/// </listheader>
		/// <item>
		/// <term>Favorites</term>
		/// <term>{EFA24E61-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>Folders</term>
		/// <term>{EFA24E64-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>History</term>
		/// <term>{EFA24E62-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>Search</term>
		/// <term>{30D02401-6A81-11d0-8274-00C04FD5AE38}</term>
		/// </item>
		/// </list>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-showbrowserbar
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030008)]
		new object ShowBrowserBar([In, MarshalAs(UnmanagedType.BStr)] string sCLSID, [In, MarshalAs(UnmanagedType.Struct)] object vShow);

		/// <summary>Adds a file to the most recently used (MRU) list.</summary>
		/// <param name="varFile">
		/// <para>Type: <c>Variant</c></para>
		/// <para>A <c>String</c> that contains the path of the file to add to the list of recently used documents.</para>
		/// <para><c>Windows Vista</c>: Set this parameter to <c>null</c> to clear the recent documents folder.</para>
		/// </param>
		/// <param name="bstrCategory">A <c>String</c> that contains the name of the category in which to place the file.</param>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shell-addtorecent
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040000)]
		new void AddToRecent([In, MarshalAs(UnmanagedType.Struct)] object varFile, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? bstrCategory);

		/// <summary>Displays the <c>Windows Security</c> dialog box.</summary>
		/// <remarks>
		/// This method displays the dialog box shown after pressing CTRL+ALT+DELETE or using the security option on the <c>Start</c> menu.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-windowssecurity
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60050000)]
		new void WindowsSecurity();

		/// <summary>Displays or hides the desktop.</summary>
		/// <remarks>
		/// This method has the same effect as the <c>Show Desktop</c> button on the taskbar. It either hides all open windows to show
		/// the desktop or it hides the desktop by showing all open windows. The <c>ToggleDesktop</c> method does not display a user
		/// interface, it just invokes the toggle action.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-toggledesktop
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60050001)]
		new void ToggleDesktop();

		/// <summary>Gets the value for a specified Windows Internet Explorer policy.</summary>
		/// <param name="bstrPolicyName">A <c>String</c> that specifies the name of the policy.</param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>The value associated with the specified policy name.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>The value associated with the specified policy name.</para>
		/// </returns>
		/// <remarks>
		/// <para>Network Administrators can control and manage the computing environment of their users by setting policies.</para>
		/// <para>
		/// The specified value name must be within the <c>HKEY_CURRENT_USER</c>\ <c>Software</c>\ <c>Microsoft</c>\ <c>Windows</c>\
		/// <c>CurrentVersion</c>\ <c>Policies</c>\ <c>Explorer</c> subkey. If the value name does not exist then the method returns <c>null</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-explorerpolicy
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60050002)]
		new object? ExplorerPolicy([In, MarshalAs(UnmanagedType.BStr)] string bstrPolicyName);

		/// <summary>Retrieves a global Shell setting.</summary>
		/// <param name="lSetting">
		/// A value that specifies the current Shell setting to retrieve. Only one setting can be retrieved in each call. The following
		/// values are recognized by this method.
		/// </param>
		/// <returns>Set to <c>true</c> if the setting exists; otherwise, <c>false</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-getsetting
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60050003)]
		new bool GetSetting([In] SSF lSetting);

		/// <summary>Displays your open windows in a 3D stack that you can flip through.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shell-windowswitcher
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60060000)]
		void WindowSwitcher();
	}

	/// <summary>
	/// Extends the <c>IShellDispatch5</c> object. In addition to the properties and methods supported by <c>IShellDispatch5</c>,
	/// <c>IShellDispatch6</c> adds a method that displays the Apps Search pane.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch6
	[PInvokeData("shldisp.h", MSDNShortId = "540A5CFD-1520-4B61-B461-E893EFA27115")]
	[ComImport, Guid("286E6F1B-7113-4355-9562-96B7E9D64C54"), CoClass(typeof(Shell))]
	public interface IShellDispatch6 : IShellDispatch5
	{
		/// <summary>
		/// <para>Contains an object that represents an application.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>This property is implemented and accessed through the <c>Shell.EjectPC</c> property.</para>
		/// <para>
		/// The <c>Application</c> property returns the automation object supported by the application that contains the WebBrowser
		/// control, if that object is accessible. Otherwise, this property returns the WebBrowser control's automation object.
		/// </para>
		/// <para>
		/// Use this property with the <c>Set</c> and <c>CreateObject</c> commands or with the <c>GetObject</c> command to create and
		/// manipulate an instance of the Windows Internet Explorer application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-application
		[DispId(0x60020000)]
		new object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>
		/// <para>Retrieves an object that represents the parent of the current object.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>This property is implemented and accessed through the <c>Shell.Parent</c> property.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-parent
		[DispId(0x60020001)]
		new object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>Creates and returns a <c>Folder</c> object for the specified folder.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The folder for which to create the <c>Folder</c> object. This can be a string that specifies the path of the folder or one of
		/// the <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in <c>ShellSpecialFolderConstants</c> are
		/// available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c><c>Folder</c>**</c></para>
		/// <para>
		/// Object reference to the <c>Folder</c> object for the specified folder. If the folder is not successfully created, this value
		/// returns <c>null</c>.
		/// </para>
		/// <para>VB</para>
		/// <para>Type: <c><c>Folder</c>**</c></para>
		/// <para>
		/// Object reference to the <c>Folder</c> object for the specified folder. If the folder is not successfully created, this value
		/// returns <c>null</c>.
		/// </para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.NameSpace</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-namespace
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
		new Folder? NameSpace([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>
		/// Creates a dialog box that enables the user to select a folder and then returns the selected folder's <c>Folder</c> object.
		/// </summary>
		/// <param name="Hwnd">
		/// <para>Type: <c>Integer</c></para>
		/// <para>The handle to the parent window of the dialog box. This value can be zero.</para>
		/// </param>
		/// <param name="Title">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> value that represents the title displayed inside the <c>Browse</c> dialog box.</para>
		/// </param>
		/// <param name="Options">
		/// <para>Type: <c>Integer</c></para>
		/// <para>
		/// An <c>Integer</c> value that contains the options for the method. This can be zero or a combination of the values listed
		/// under the <c>ulFlags</c> member of the <c>BROWSEINFO</c> structure.
		/// </para>
		/// </param>
		/// <param name="RootFolder">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The root folder to use in the dialog box. The user cannot browse higher in the tree than this folder. If this value is not
		/// specified, the root folder used in the dialog box is the desktop. This value can be a string that specifies the path of the
		/// folder or one of the <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in
		/// <c>ShellSpecialFolderConstants</c> are available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric
		/// values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>FOLDER**</c></para>
		/// <para>An object reference to the selected folder's <c>Folder</c> object.</para>
		/// <para>VB</para>
		/// <para>Type: <c>FOLDER**</c></para>
		/// <para>An object reference to the selected folder's <c>Folder</c> object.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.BrowseForFolder</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-browseforfolder
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		new Folder BrowseForFolder([In] int Hwnd, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In] BrowseInfoFlag Options, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? RootFolder);

		/// <summary>
		/// Creates and returns a <c>ShellWindows</c> object. This object represents a collection of all of the open windows that belong
		/// to the Shell.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c><c>IDispatch</c>**</c></para>
		/// <para>An object reference to the <c>ShellWindows</c> object.</para>
		/// <para>VB</para>
		/// <para>Type: <c><c>IDispatch</c>**</c></para>
		/// <para>An object reference to the <c>ShellWindows</c> object.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Windows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-windows
		[return: MarshalAs(UnmanagedType.IDispatch)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
		new object Windows();

		/// <summary>Opens the specified folder.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// A string that specifies the path of the folder or one of the <c>ShellSpecialFolderConstants</c> values. Note that the
		/// constant names found in <c>ShellSpecialFolderConstants</c> are available in Visual Basic, but not in VBScript or JScript. In
		/// those cases, the numeric values must be used in their place.
		/// </para>
		/// <para>
		/// If vDir is set to one of the <c>ShellSpecialFolderConstants</c> and the special folder does not exist, this function will
		/// create the folder.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Open</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-open
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
		new void Open([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>Opens a specified folder in a Windows Explorer window.</summary>
		/// <param name="vDir">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The folder to be displayed. This can be a string that specifies the path of the folder or one of the
		/// <c>ShellSpecialFolderConstants</c> values. Note that the constant names found in <c>ShellSpecialFolderConstants</c> are
		/// available in Visual Basic, but not in VBScript or JScript. In those cases, the numeric values must be used in their place.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Explore</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-explore
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		new void Explore([In, MarshalAs(UnmanagedType.Struct)] object vDir);

		/// <summary>
		/// Minimizes all of the windows on the desktop. This method has the same effect as right-clicking the taskbar and selecting
		/// <c>Minimize All Windows</c> on older systems or clicking the <c>Show Desktop</c> icon on the taskbar.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.MinimizeAll</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-minimizeall
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		new void MinimizeAll();

		/// <summary>
		/// Restores all desktop windows to the state they were in before the last <c>MinimizeAll</c> command. This method has the same
		/// effect as right-clicking the taskbar and selecting <c>Undo Minimize All Windows</c> (on older systems) or a second clicking
		/// of the <c>Show Desktop</c> icon in the taskbar.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.UndoMinimizeAll</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-undominimizeall
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)]
		new void UndoMinimizeALL();

		/// <summary>Displays the <c>Run</c> dialog to the user.</summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FileRun</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-filerun
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)]
		new void FileRun();

		/// <summary>
		/// Cascades all of the windows on the desktop. This method has the same effect as right-clicking the taskbar and selecting
		/// <c>Cascade windows</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.CascadeWindows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-cascadewindows
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)]
		new void CascadeWindows();

		/// <summary>
		/// Tiles all of the windows on the desktop vertically. This method has the same effect as right-clicking the taskbar and
		/// selecting <c>Show windows side by side</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TileVertically</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-tilevertically
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000b)]
		new void TileVertically();

		/// <summary>
		/// Tiles all of the windows on the desktop horizontally. This method has the same effect as right-clicking the taskbar and
		/// selecting <c>Show windows stacked</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TileHorizontally</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-tilehorizontally
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000c)]
		new void TileHorizontally();

		/// <summary>
		/// Displays the <c>Shut Down Windows</c> dialog box. This is the same as clicking the <c>Start</c> menu and selecting <c>Shut Down</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.ShutdownWindows</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-shutdownwindows
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000d)]
		new void ShutdownWindows();

		/// <summary>This method is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-suspend
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
		new void Suspend();

		/// <summary>
		/// Ejects the computer from its docking station. This is the same as clicking the <c>Start</c> menu and selecting <c>Eject
		/// PC</c>, if your computer supports this command.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.EjectPC</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-ejectpc
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000f)]
		new void EjectPC();

		/// <summary>
		/// Displays the <c>Date and Time</c> dialog box. This method has the same effect as right-clicking the clock in the taskbar
		/// status area and selecting <c>Adjust date/time</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.SetTime</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-settime
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020010)]
		new void SetTime();

		/// <summary>
		/// Displays the <c>Taskbar and Start Menu Properties</c> dialog box. This method has the same effect as right-clicking the
		/// taskbar and selecting <c>Properties</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.TrayProperties</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-trayproperties
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020011)]
		new void TrayProperties();

		/// <summary>
		/// Displays the Windows Help and Support window. This method has the same effect as clicking the <c>Start</c> menu and selecting
		/// <c>Help and Support</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.Help</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-help
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020012)]
		new void Help();

		/// <summary>
		/// Displays the <c>Find: All Files</c> dialog box. This is the same as clicking the <c>Start</c> menu and then selecting <c>Search</c>.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FindFiles</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-findfiles
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020013)]
		new void FindFiles();

		/// <summary>
		/// Displays the <c>Search Results: Computers</c> dialog box. The dialog box shows the result of the search for a specified computer.
		/// </summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.FindComputer</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-findcomputer
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020014)]
		new void FindComputer();

		/// <summary>Refreshes the contents of the <c>Start</c> menu. Used only with systems preceding Windows XP.</summary>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.TrayProperties</c> method.</para>
		/// <para>
		/// The functionality that <c>RefreshMenu</c> provides is handled automatically under Windows XP or later. Do not call this
		/// method on Windows XP or later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-refreshmenu
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020015)]
		new void RefreshMenu();

		/// <summary>
		/// Runs the specified Control Panel application. If the application is already open, it will activate the running instance.
		/// </summary>
		/// <param name="bstrDir">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>The Control Panel application's file name.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>This method does not return a value.</para>
		/// <para>VB</para>
		/// <para>This method does not return a value.</para>
		/// </returns>
		/// <remarks>This method is implemented and accessed through the <c>Shell.ControlPanelItem</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch-controlpanelitem
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020016)]
		new void ControlPanelItem([In, MarshalAs(UnmanagedType.BStr)] string bstrDir);

		/// <summary>Retrieves a group's restriction setting from the registry.</summary>
		/// <param name="sGroup">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the group name. This value is the name of a registry subkey under which to check for the restriction.
		/// </para>
		/// </param>
		/// <param name="sRestriction">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the restriction whose value is to be retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Integer*</c></para>
		/// <para>The value of the restriction. If the specified restriction is not found, the return value is 0.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Integer*</c></para>
		/// <para>The value of the restriction. If the specified restriction is not found, the return value is 0.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.IsRestricted</c> method.</para>
		/// <para><c>IsRestricted</c> first looks for a subkey name that matches sGroup under the following key.</para>
		/// <para>
		/// Restrictions are declared as values of the individual policy subkeys. If the restriction named in sRestriction is found in
		/// the subkey named in sGroup, <c>IsRestricted</c> returns the restriction's current value. If the restriction is not found
		/// under <c>HKEY_LOCAL_MACHINE</c>, the same subkey is checked under <c>HKEY_CURRENT_USER</c>.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-isrestricted
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)]
		new int IsRestricted([In, MarshalAs(UnmanagedType.BStr)] string sGroup, [In, MarshalAs(UnmanagedType.BStr)] string sRestriction);

		/// <summary>Performs a specified operation on a specified file.</summary>
		/// <param name="sFile">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the name of the file on which <c>ShellExecute</c> will perform the action specified by vOperation.
		/// </para>
		/// </param>
		/// <param name="vArguments">
		/// <para>Type: <c>Variant</c></para>
		/// <para>A string that contains parameter values for the operation.</para>
		/// </param>
		/// <param name="vDirectory">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The fully qualified path of the directory that contains the file specified by sFile. If this parameter is not specified, the
		/// current working directory is used.
		/// </para>
		/// </param>
		/// <param name="vOperation">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// The operation to be performed. This value is set to one of the verb strings that is supported by the file. For a discussion
		/// of verbs, see the Remarks section. If this parameter is not specified, the default operation is performed.
		/// </para>
		/// </param>
		/// <param name="vShow">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// A recommendation as to how the application window should be displayed initially. The application can ignore this
		/// recommendation. This parameter can be one of the following values. If this parameter is not specified, the application uses
		/// its default value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Open the application with a hidden window.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Open the application with a normal window. If the window is minimized or maximized, the system restores it to its original
		/// size and position.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>Open the application with a minimized window.</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Open the application with a maximized window.</term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>Open the application with its window at its most recent size and position. The active window remains active.</term>
		/// </item>
		/// <item>
		/// <term>5</term>
		/// <term>Open the application with its window at its current size and position.</term>
		/// </item>
		/// <item>
		/// <term>7</term>
		/// <term>Open the application with a minimized window. The active window remains active.</term>
		/// </item>
		/// <item>
		/// <term>10</term>
		/// <term>Open the application with its window in the default state specified by the application.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ShellExecute</c> method.</para>
		/// <para>
		/// This method is equivalent to launching one of the commands associated with a file's shortcut menu. Each command is
		/// represented by a verb string. The set of supported verbs varies from file to file. The most commonly supported verb is
		/// "open", which is also usually the default verb. Other verbs might be supported by only certain types of files. For further
		/// discussion of Shell verbs, see Launching Applications or Extending Shortcut Menus.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-shellexecute
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030001)]
		new void ShellExecute([In, MarshalAs(UnmanagedType.BStr)] string sFile, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vArguments,
			[In, Optional, MarshalAs(UnmanagedType.Struct)] object? vDirectory, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vOperation,
			[In, Optional, MarshalAs(UnmanagedType.Struct)] object? vShow);

		/// <summary>Displays the <c>Find Printer</c> dialog box.</summary>
		/// <param name="Name">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer name.</para>
		/// </param>
		/// <param name="location">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer location.</para>
		/// </param>
		/// <param name="model">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the printer model.</para>
		/// </param>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.FindPrinter</c> method.</para>
		/// <para>
		/// If you assign strings to one or more of the optional parameters, they are displayed as default values in the associated edit
		/// control when the <c>Find Printer</c> dialog box is displayed. The user can either accept or override these values. If no
		/// value is assigned to a parameter, the associated edit box is empty and the user must enter a value.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-findprinter
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030002)]
		new void FindPrinter([In, Optional, MarshalAs(UnmanagedType.BStr)] string? Name, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? location, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? model);

		/// <summary>Retrieves system information.</summary>
		/// <param name="sName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that specifies the system information that is being requested.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Returns the value of the requested system information. The return type depends on which system information is requested. See
		/// the Remarks section for details.
		/// </para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Returns the value of the requested system information. The return type depends on which system information is requested. See
		/// the Remarks section for details.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.GetSystemInformation</c> method.</para>
		/// <para>
		/// This method can be used to request many system information values. The following table gives the sName value that is used to
		/// request the information and the associated type of the returned value.
		/// </para>
		/// <para>sName</para>
		/// <para>Return type</para>
		/// <para>Description</para>
		/// <para>DirectoryServiceAvailable</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the directory service is available; otherwise, <c>false</c>.</para>
		/// <para>DoubleClickTime</para>
		/// <para><c>Integer</c></para>
		/// <para>The double-click time, in milliseconds.</para>
		/// <para>ProcessorLevel</para>
		/// <para><c>Integer</c></para>
		/// <para>
		/// <c>Windows Vista and later</c>. The processor level. Returns 3, 4, or 5, for x386, x486, and Pentium-level processors, respectively.
		/// </para>
		/// <para>ProcessorSpeed</para>
		/// <para><c>Integer</c></para>
		/// <para>The processor speed, in megahertz (MHz).</para>
		/// <para>ProcessorArchitecture</para>
		/// <para><c>Integer</c></para>
		/// <para>
		/// The processor architecture. For details, see the discussion of the <c>wProcessorArchitecture</c> member of the
		/// <c>SYSTEM_INFO</c> structure.
		/// </para>
		/// <para>PhysicalMemoryInstalled</para>
		/// <para><c>Integer</c></para>
		/// <para>The amount of physical memory installed, in bytes.</para>
		/// <para>The following are valid only on Windows XP.</para>
		/// <para>IsOS_Professional</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the operating system is Windows XP Professional Edition; otherwise, <c>false</c>.</para>
		/// <para>IsOS_Personal</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the operating system is Windows XP Home Edition; otherwise, <c>false</c>.</para>
		/// <para>The following is valid only on Windows XP and later.</para>
		/// <para>IsOS_DomainMember</para>
		/// <para><c>Boolean</c></para>
		/// <para>Set to <c>true</c> if the computer is a member of a domain; otherwise, <c>false</c>.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-getsysteminformation
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030003)]
		new object GetSystemInformation([In, MarshalAs(UnmanagedType.BStr)] string sName);

		/// <summary>Starts a named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <param name="vPersistent">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Set to <c>true</c> to have the service started automatically by the service control manager during system startup. Set to
		/// <c>false</c> to leave the service configuration unchanged.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ServiceStart</c> method.</para>
		/// <para>
		/// The method returns <c>false</c> if the service has already been started. Before calling this method, you can call
		/// <c>Shell.IsServiceRunning</c> to ascertain the status of the service.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-servicestart
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030004)]
		new object ServiceStart([In, MarshalAs(UnmanagedType.BStr)] string sServiceName, [In, MarshalAs(UnmanagedType.Struct)] object vPersistent);

		/// <summary>Stops a named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <param name="vPersistent">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// Set to <c>true</c> to have the service started by the service control manager when <c>ServiceStart</c> is called. To leave
		/// the service configuration unchanged, set vPersistent to <c>false</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ServiceStop</c> method.</para>
		/// <para>
		/// The method returns <c>false</c> if the service has already been stopped. Before calling this method, you can call
		/// <c>Shell.IsServiceRunning</c> to ascertain the status of the service.
		/// </para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-servicestop
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030005)]
		new object ServiceStop([In, MarshalAs(UnmanagedType.BStr)] string sServiceName, [In, MarshalAs(UnmanagedType.Struct)] object vPersistent);

		/// <summary>Returns a value that indicates whether a particular service is running.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the service specified by sServiceName is running; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the service specified by sServiceName is running; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.IsServiceRunning</c> method.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-isservicerunning
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030006)]
		new object IsServiceRunning([In, MarshalAs(UnmanagedType.BStr)] string sServiceName);

		/// <summary>Determines if the current user can start and stop the named service.</summary>
		/// <param name="sServiceName">
		/// <para>Type: <c>String</c></para>
		/// <para>A <c>String</c> that contains the name of the service.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the user can start and stop the service; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if the user can start and stop the service; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.CanStartStopService</c> method.</para>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-canstartstopservice
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030007)]
		new object CanStartStopService([In, MarshalAs(UnmanagedType.BStr)] string sServiceName);

		/// <summary>Displays a browser bar.</summary>
		/// <param name="sCLSID">
		/// <para>Type: <c><c>BSTR</c></c></para>
		/// <para>
		/// A <c>String</c> that contains the string form of the CLSID of the browser bar to be displayed. The object must be registered
		/// as an Explorer Bar object with a CATID_InfoBand component category. For further information, see Creating Custom Explorer
		/// Bars, Tool Bands, and Desk Bands.
		/// </para>
		/// </param>
		/// <param name="vShow">
		/// <para>Type: <c>Variant</c></para>
		/// <para>Set to <c>true</c> to show the browser bar or <c>false</c> to hide it.</para>
		/// </param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>Returns <c>true</c> if successful; otherwise, <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is implemented and accessed through the <c>Shell.ShowBrowserBar</c> method.</para>
		/// <para>
		/// You can display one of the standard Explorer Bars by setting the sCLSID parameter to the CLSID of that Explorer Bar. The
		/// standard Explorer Bars and their CLSID strings are as follows:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Explorer Bar</term>
		/// <term>CLSID string</term>
		/// </listheader>
		/// <item>
		/// <term>Favorites</term>
		/// <term>{EFA24E61-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>Folders</term>
		/// <term>{EFA24E64-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>History</term>
		/// <term>{EFA24E62-B078-11d0-89E4-00C04FC9E26E}</term>
		/// </item>
		/// <item>
		/// <term>Search</term>
		/// <term>{30D02401-6A81-11d0-8274-00C04FD5AE38}</term>
		/// </item>
		/// </list>
		/// <para>This method is not currently available in Microsoft Visual Basic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-showbrowserbar
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030008)]
		new object ShowBrowserBar([In, MarshalAs(UnmanagedType.BStr)] string sCLSID, [In, MarshalAs(UnmanagedType.Struct)] object vShow);

		/// <summary>Adds a file to the most recently used (MRU) list.</summary>
		/// <param name="varFile">
		/// <para>Type: <c>Variant</c></para>
		/// <para>A <c>String</c> that contains the path of the file to add to the list of recently used documents.</para>
		/// <para><c>Windows Vista</c>: Set this parameter to <c>null</c> to clear the recent documents folder.</para>
		/// </param>
		/// <param name="bstrCategory">A <c>String</c> that contains the name of the category in which to place the file.</param>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shell-addtorecent
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040000)]
		new void AddToRecent([In, MarshalAs(UnmanagedType.Struct)] object? varFile, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? bstrCategory);

		/// <summary>Displays the <c>Windows Security</c> dialog box.</summary>
		/// <remarks>
		/// This method displays the dialog box shown after pressing CTRL+ALT+DELETE or using the security option on the <c>Start</c> menu.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-windowssecurity
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60050000)]
		new void WindowsSecurity();

		/// <summary>Displays or hides the desktop.</summary>
		/// <remarks>
		/// This method has the same effect as the <c>Show Desktop</c> button on the taskbar. It either hides all open windows to show
		/// the desktop or it hides the desktop by showing all open windows. The <c>ToggleDesktop</c> method does not display a user
		/// interface, it just invokes the toggle action.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-toggledesktop
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60050001)]
		new void ToggleDesktop();

		/// <summary>Gets the value for a specified Windows Internet Explorer policy.</summary>
		/// <param name="bstrPolicyName">A <c>String</c> that specifies the name of the policy.</param>
		/// <returns>
		/// <para>JScript</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>The value associated with the specified policy name.</para>
		/// <para>VB</para>
		/// <para>Type: <c>Variant*</c></para>
		/// <para>The value associated with the specified policy name.</para>
		/// </returns>
		/// <remarks>
		/// <para>Network Administrators can control and manage the computing environment of their users by setting policies.</para>
		/// <para>
		/// The specified value name must be within the <c>HKEY_CURRENT_USER</c>\ <c>Software</c>\ <c>Microsoft</c>\ <c>Windows</c>\
		/// <c>CurrentVersion</c>\ <c>Policies</c>\ <c>Explorer</c> subkey. If the value name does not exist then the method returns <c>null</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-explorerpolicy
		[return: MarshalAs(UnmanagedType.Struct)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60050002)]
		new object? ExplorerPolicy([In, MarshalAs(UnmanagedType.BStr)] string bstrPolicyName);

		/// <summary>Retrieves a global Shell setting.</summary>
		/// <param name="lSetting">
		/// A value that specifies the current Shell setting to retrieve. Only one setting can be retrieved in each call. The following
		/// values are recognized by this method.
		/// </param>
		/// <returns>Set to <c>true</c> if the setting exists; otherwise, <c>false</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch4-getsetting
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60050003)]
		new bool GetSetting([In] SSF lSetting);

		/// <summary>Displays your open windows in a 3D stack that you can flip through.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shell-windowswitcher
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60060000)]
		new void WindowSwitcher();

		/// <summary>Displays the Apps Search pane, which normally appears when you begin to type a search term from the Start screen.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch6-searchcommand
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60070000)]
		void SearchCommand();
	}

	/// <summary>Exposes methods that modify the view and select items in the current folder.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shldisp/nn-shldisp-ishellfolderviewdual
	[PInvokeData("shldisp.h", MSDNShortId = "48135f9d-ee80-4dec-87dc-83f407c25777")]
	[ComImport, Guid("E7A1AF80-4D96-11CF-960C-0080C7F4EE85"), CoClass(typeof(ShellFolderView))]
	public interface IShellFolderViewDual
	{
		/// <summary>
		/// <para>Contains the object's Application object.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>Application</c> property returns the automation object supported by the application that contains the WebBrowser
		/// control, if that object is accessible. Otherwise, this property returns the WebBrowser control's automation object.
		/// </para>
		/// <para>
		/// Use this property with the <c>Set</c> and <c>CreateObject</c> commands or with the <c>GetObject</c> command to create and
		/// manipulate an instance of the Windows Internet Explorer application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-application
		[DispId(0x60020000)]
		object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>This property is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-parent
		[DispId(0x60020001)]
		object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>
		/// <para>Gets a <c>Folder</c> object that represents the view.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks><c>Folder</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-folder
		[DispId(0x60020002)]
		Folder Folder { [return: MarshalAs(UnmanagedType.Interface)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)] get; }

		/// <summary>Gets a <c>FolderItems</c> object that represents all of the selected items in the view.</summary>
		/// <returns>
		/// <para>Type: <c><c>FolderItems</c>**</c></para>
		/// <para>An object reference to the <c>FolderItems</c> object.</para>
		/// </returns>
		/// <remarks>
		/// <c>SelectedItems</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-selecteditems
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		FolderItems SelectedItems();

		/// <summary>
		/// <para>Gets a <c>FolderItem</c> object that represents the item that has the input focus.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <c>FocusedItem</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-focuseditem
		[DispId(0x60020004)]
		FolderItem FocusedItem { [return: MarshalAs(UnmanagedType.Interface)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)] get; }

		/// <summary>Sets the selection state of an item in the view.</summary>
		/// <param name="vItem">
		/// <para>Type: <c>Variant*</c></para>
		/// <para>The <c>FolderItem</c> object for which the selection state will be set.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>Integer</c></para>
		/// <para>A set of flags that indicate the new selection state. This can be one or more of the following values.</para>
		/// <list type="bullet">
		/// <item>(0) Deselect the item.</item>
		/// <item>(1) Select the item.</item>
		/// <item>(3) Put the item in edit mode.</item>
		/// <item>(4) Deselect all but the specified item.</item>
		/// <item>(8) Ensure the item is displayed in the view.</item>
		/// <item>(16) Give the item the focus.</item>
		/// </list>
		/// </param>
		/// <returns>This method does not return a value.</returns>
		/// <remarks>
		/// <c>FocusedItem</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-selectitem
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
		void SelectItem([In, MarshalAs(UnmanagedType.Struct)] ref object vItem, [In] int dwFlags);

		/// <summary>Creates a shortcut menu for the specified item and returns the selected command string.</summary>
		/// <param name="vItem">
		/// <para>Type: <c>Variant</c></para>
		/// <para>The <c>FolderItem</c> object for which the shortcut menu will be created.</para>
		/// </param>
		/// <param name="vx">
		/// <para>Type: <c>Variant</c></para>
		/// <para>The horizontal position of the menu, in screen coordinates.</para>
		/// </param>
		/// <param name="vy">
		/// <para>Type: <c>Variant</c></para>
		/// <para>The vertical position of the menu, in screen coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>BSTR</c>*</c></para>
		/// <para>The <c>String</c> that receives the command string.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-popupitemmenu
		[return: MarshalAs(UnmanagedType.BStr)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		string PopupItemMenu([In, MarshalAs(UnmanagedType.Interface)] FolderItem vItem, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vx, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vy);

		/// <summary>
		/// <para>[This property is not supported in Windows XP or later.]</para>
		/// <para>Contains the scripting object for the view.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-script
		[DispId(0x60020007)]
		object Script { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)] get; }

		/// <summary>
		/// <para>Gets a set of flags that indicate the current options of the view.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <c>FocusedItem</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-viewoptions
		[DispId(0x60020008)]
		ShellFolderViewOptions ViewOptions { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)] get; }
	}

	/// <summary>Exposes methods that modify the view and select items in the current folder.</summary>
	/// <remarks>This interface also provides the methods of the IShellFolderViewDual interface, from which it inherits.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shldisp/nn-shldisp-ishellfolderviewdual2
	[PInvokeData("shldisp.h", MSDNShortId = "f53b779e-a015-4b17-b04d-e0739cba8168")]
	[ComImport, Guid("31C147B6-0ADE-4A3C-B514-DDF932EF6D17"), CoClass(typeof(ShellFolderView))]
	public interface IShellFolderViewDual2 : IShellFolderViewDual
	{
		/// <summary>
		/// <para>Contains the object's Application object.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>Application</c> property returns the automation object supported by the application that contains the WebBrowser
		/// control, if that object is accessible. Otherwise, this property returns the WebBrowser control's automation object.
		/// </para>
		/// <para>
		/// Use this property with the <c>Set</c> and <c>CreateObject</c> commands or with the <c>GetObject</c> command to create and
		/// manipulate an instance of the Windows Internet Explorer application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-application
		[DispId(0x60020000)]
		new object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>This property is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-parent
		[DispId(0x60020001)]
		new object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>
		/// <para>Gets a <c>Folder</c> object that represents the view.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks><c>Folder</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-folder
		[DispId(0x60020002)]
		new Folder Folder { [return: MarshalAs(UnmanagedType.Interface)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)] get; }

		/// <summary>Gets a <c>FolderItems</c> object that represents all of the selected items in the view.</summary>
		/// <returns>
		/// <para>Type: <c><c>FolderItems</c>**</c></para>
		/// <para>An object reference to the <c>FolderItems</c> object.</para>
		/// </returns>
		/// <remarks>
		/// <c>SelectedItems</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-selecteditems
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		new FolderItems SelectedItems();

		/// <summary>
		/// <para>Gets a <c>FolderItem</c> object that represents the item that has the input focus.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <c>FocusedItem</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-focuseditem
		[DispId(0x60020004)]
		new FolderItem FocusedItem { [return: MarshalAs(UnmanagedType.Interface)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)] get; }

		/// <summary>Sets the selection state of an item in the view.</summary>
		/// <param name="vItem">
		/// <para>Type: <c>Variant*</c></para>
		/// <para>The <c>FolderItem</c> object for which the selection state will be set.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>Integer</c></para>
		/// <para>A set of flags that indicate the new selection state. This can be one or more of the following values.</para>
		/// <list type="bullet">
		/// <item>(0) Deselect the item.</item>
		/// <item>(1) Select the item.</item>
		/// <item>(3) Put the item in edit mode.</item>
		/// <item>(4) Deselect all but the specified item.</item>
		/// <item>(8) Ensure the item is displayed in the view.</item>
		/// <item>(16) Give the item the focus.</item>
		/// </list>
		/// </param>
		/// <returns>This method does not return a value.</returns>
		/// <remarks>
		/// <c>FocusedItem</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-selectitem
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
		new void SelectItem([In, MarshalAs(UnmanagedType.Struct)] ref object vItem, [In] int dwFlags);

		/// <summary>Creates a shortcut menu for the specified item and returns the selected command string.</summary>
		/// <param name="vItem">
		/// <para>Type: <c>Variant</c></para>
		/// <para>The <c>FolderItem</c> object for which the shortcut menu will be created.</para>
		/// </param>
		/// <param name="vx">
		/// <para>Type: <c>Variant</c></para>
		/// <para>The horizontal position of the menu, in screen coordinates.</para>
		/// </param>
		/// <param name="vy">
		/// <para>Type: <c>Variant</c></para>
		/// <para>The vertical position of the menu, in screen coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>BSTR</c>*</c></para>
		/// <para>The <c>String</c> that receives the command string.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-popupitemmenu
		[return: MarshalAs(UnmanagedType.BStr)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		new string PopupItemMenu([In, MarshalAs(UnmanagedType.Interface)] FolderItem vItem, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vx, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vy);

		/// <summary>
		/// <para>[This property is not supported in Windows XP or later.]</para>
		/// <para>Contains the scripting object for the view.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-script
		[DispId(0x60020007)]
		new object Script { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)] get; }

		/// <summary>
		/// <para>Gets a set of flags that indicate the current options of the view.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <c>FocusedItem</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-viewoptions
		[DispId(0x60020008)]
		new ShellFolderViewOptions ViewOptions { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)] get; }

		/// <summary>Gets the current view mode of the current folder.</summary>
		/// <returns>
		/// <para>Type: <c>uint*</c></para>
		/// <para>An unsigned integer that represents the current view mode. For a list of possible values see FOLDERVIEWMODE.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shldisp/nf-shldisp-ishellfolderviewdual2-get_currentviewmode
		[DispId(0x60030000)]
		FOLDERVIEWMODE CurrentViewMode { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)] get; [param: In][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)] set; }

		/// <summary>Selects an item relative to the current item.</summary>
		/// <param name="iRelative">
		/// <para>Type: <c>int</c></para>
		/// <para>The offset of the item to be selected in relation to the current item.</para>
		/// </param>
		/// <remarks>
		/// The current item is defined as the item in the view with the SVSI_SELECTIONMARK state. If there is no item with
		/// SVSI_SELECTIONMARK, the method returns S_FALSE and does nothing.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shldisp/nf-shldisp-ishellfolderviewdual2-selectitemrelative
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030002)]
		void SelectItemRelative([In] int iRelative);
	}

	/// <summary>Exposes methods that modify the current folder view.</summary>
	/// <remarks>
	/// This interface also provides the methods of the IShellFolderViewDual and IShellFolderViewDual2 interfaces, from which it inherits.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shldisp/nn-shldisp-ishellfolderviewdual3
	[PInvokeData("shldisp.h", MSDNShortId = "1aa70db8-4225-49de-8b8f-ec86b1aafa22")]
	[ComImport, Guid("29EC8E6C-46D3-411F-BAAA-611A6C9CAC66"), CoClass(typeof(ShellFolderView))]
	public interface IShellFolderViewDual3 : IShellFolderViewDual2
	{
		/// <summary>
		/// <para>Contains the object's Application object.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>Application</c> property returns the automation object supported by the application that contains the WebBrowser
		/// control, if that object is accessible. Otherwise, this property returns the WebBrowser control's automation object.
		/// </para>
		/// <para>
		/// Use this property with the <c>Set</c> and <c>CreateObject</c> commands or with the <c>GetObject</c> command to create and
		/// manipulate an instance of the Windows Internet Explorer application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-application
		[DispId(0x60020000)]
		new object Application { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; }

		/// <summary>This property is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-parent
		[DispId(0x60020001)]
		new object Parent { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)] get; }

		/// <summary>
		/// <para>Gets a <c>Folder</c> object that represents the view.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks><c>Folder</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-folder
		[DispId(0x60020002)]
		new Folder Folder { [return: MarshalAs(UnmanagedType.Interface)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)] get; }

		/// <summary>Gets a <c>FolderItems</c> object that represents all of the selected items in the view.</summary>
		/// <returns>
		/// <para>Type: <c><c>FolderItems</c>**</c></para>
		/// <para>An object reference to the <c>FolderItems</c> object.</para>
		/// </returns>
		/// <remarks>
		/// <c>SelectedItems</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-selecteditems
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		new FolderItems SelectedItems();

		/// <summary>
		/// <para>Gets a <c>FolderItem</c> object that represents the item that has the input focus.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <c>FocusedItem</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-focuseditem
		[DispId(0x60020004)]
		new FolderItem FocusedItem { [return: MarshalAs(UnmanagedType.Interface)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)] get; }

		/// <summary>Sets the selection state of an item in the view.</summary>
		/// <param name="vItem">
		/// <para>Type: <c>Variant*</c></para>
		/// <para>The <c>FolderItem</c> object for which the selection state will be set.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>Integer</c></para>
		/// <para>A set of flags that indicate the new selection state. This can be one or more of the following values.</para>
		/// <list type="bullet">
		/// <item>(0) Deselect the item.</item>
		/// <item>(1) Select the item.</item>
		/// <item>(3) Put the item in edit mode.</item>
		/// <item>(4) Deselect all but the specified item.</item>
		/// <item>(8) Ensure the item is displayed in the view.</item>
		/// <item>(16) Give the item the focus.</item>
		/// </list>
		/// </param>
		/// <returns>This method does not return a value.</returns>
		/// <remarks>
		/// <c>FocusedItem</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-selectitem
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
		new void SelectItem([In, MarshalAs(UnmanagedType.Struct)] ref object vItem, [In] int dwFlags);

		/// <summary>Creates a shortcut menu for the specified item and returns the selected command string.</summary>
		/// <param name="vItem">
		/// <para>Type: <c>Variant</c></para>
		/// <para>The <c>FolderItem</c> object for which the shortcut menu will be created.</para>
		/// </param>
		/// <param name="vx">
		/// <para>Type: <c>Variant</c></para>
		/// <para>The horizontal position of the menu, in screen coordinates.</para>
		/// </param>
		/// <param name="vy">
		/// <para>Type: <c>Variant</c></para>
		/// <para>The vertical position of the menu, in screen coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>BSTR</c>*</c></para>
		/// <para>The <c>String</c> that receives the command string.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-popupitemmenu
		[return: MarshalAs(UnmanagedType.BStr)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		new string PopupItemMenu([In, MarshalAs(UnmanagedType.Interface)] FolderItem vItem, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vx, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vy);

		/// <summary>
		/// <para>[This property is not supported in Windows XP or later.]</para>
		/// <para>Contains the scripting object for the view.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-script
		[DispId(0x60020007)]
		new object Script { [return: MarshalAs(UnmanagedType.IDispatch)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)] get; }

		/// <summary>
		/// <para>Gets a set of flags that indicate the current options of the view.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <c>FocusedItem</c> can only be called on the local system. It will not work when run on a webpage over HTTP or UNC.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview-viewoptions
		[DispId(0x60020008)]
		new ShellFolderViewOptions ViewOptions { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)] get; }

		/// <summary>Gets the current view mode of the current folder.</summary>
		/// <returns>
		/// <para>Type: <c>uint*</c></para>
		/// <para>An unsigned integer that represents the current view mode. For a list of possible values see FOLDERVIEWMODE.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shldisp/nf-shldisp-ishellfolderviewdual2-get_currentviewmode
		[DispId(0x60030000)]
		new FOLDERVIEWMODE CurrentViewMode { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)] get; [param: In][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)] set; }

		/// <summary>Selects an item relative to the current item.</summary>
		/// <param name="iRelative">
		/// <para>Type: <c>int</c></para>
		/// <para>The offset of the item to be selected in relation to the current item.</para>
		/// </param>
		/// <remarks>
		/// The current item is defined as the item in the view with the SVSI_SELECTIONMARK state. If there is no item with
		/// SVSI_SELECTIONMARK, the method returns S_FALSE and does nothing.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shldisp/nf-shldisp-ishellfolderviewdual2-selectitemrelative
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030002)]
		new void SelectItemRelative([In] int iRelative);

		/// <summary>Gets or sets the column name used for grouping the folder view.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shldisp/nf-shldisp-ishellfolderviewdual3-get_groupby
		[DispId(0x60040000)]
		string GroupBy { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040000)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040000)] set; }

		/// <summary>Gets or sets the settings for the current folder.</summary>
		[DispId(0x60040002)]
		FOLDERFLAGS FolderFlags { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040002)] get; [param: In][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040002)] set; }

		/// <summary>Gets or sets the names of the columns used to sort the current folder.</summary>
		[DispId(0x60040004)]
		string SortColumns { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040004)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040004)] set; }

		/// <summary>Gets or sets the icon size setting for the current folder.</summary>
		[DispId(0x60040006)]
		int IconSize { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040006)] get; [param: In][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040006)] set; }

		/// <summary>Sets the filter on the contents of the current view.</summary>
		/// <param name="bstrFilterText">The string that names the filter view for the current folder.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shldisp/nf-shldisp-ishellfolderviewdual3-filterview
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040008)]
		void FilterView([In, MarshalAs(UnmanagedType.BStr)] string bstrFilterText);
	}

	/// <summary>
	/// Manages Shell links. This object makes much of the functionality of the <c>IShellLink</c> interface available to scripting applications.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-object
	[PInvokeData("shldisp.h", MSDNShortId = "d3c0ccf8-0f83-42f7-9d6f-1fb293da6364")]
	[ComImport, Guid("88A05C00-F000-11CE-8350-444553540000"), CoClass(typeof(ShellLinkObject))]
	public interface IShellLinkDual
	{
		/// <summary>
		/// <para>Gets or sets the path to the link object.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-path
		[DispId(0x60020000)]
		string Path { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] set; }

		/// <summary>
		/// <para>Gets or sets the description of the link.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-description
		[DispId(0x60020002)]
		string Description { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)] set; }

		/// <summary>
		/// <para>Gets or sets the working directory specified in the link.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-workingdirectory
		[DispId(0x60020004)]
		string WorkingDirectory { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)] set; }

		/// <summary>
		/// <para>Contains a link's arguments.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-arguments
		[DispId(0x60020006)]
		string Arguments { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)] set; }

		/// <summary>
		/// <para>Gets or sets the keyboard shortcut for the link.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-hotkey
		[DispId(0x60020008)]
		int Hotkey { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)] get; [param: In][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)] set; }

		/// <summary>
		/// <para>Gets or sets the initial display state (sized, minimized, or maximized) of the link's command.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-showcommand
		[DispId(0x6002000a)]
		int ShowCommand { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)] get; [param: In][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)] set; }

		/// <summary>Looks for the target of a Shell link, even if the target has been moved or renamed.</summary>
		/// <param name="fFlags">
		/// <para>Type: <c>Integer</c></para>
		/// <para>Flags that specify the action to be taken. This can be a combination of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// (1)Do not display a dialog box if the link cannot be resolved. When this flag is set, the high-order word of fFlags specifies
		/// a time-out duration, in milliseconds. The method returns if the link cannot be resolved within the time-out duration. If the
		/// high-order word is set to zero, the time-out duration defaults to 3000 milliseconds (3 seconds).
		/// </item>
		/// <item>(4)If the link has changed, update its path and list of identifiers.</item>
		/// <item>(8)Do not update the link information.</item>
		/// <item>(16)Do not execute the search heuristics.</item>
		/// <item>(32)Do not use distributed link tracking.</item>
		/// <item>
		/// (64)Disable distributed link tracking. By default, distributed link tracking tracks removable media across multiple devices
		/// based on the volume name. It also uses the UNC path to track remote file systems whose drive letter has changed. Setting this
		/// flag disables both types of tracking.
		/// </item>
		/// <item>(128)Call the Windows Installer.</item>
		/// </list>
		/// </param>
		/// <remarks>
		/// This method is essentially identical in functionality to <c>Resolve</c>. For further discussion of link resolution, see the
		/// Remarks section of that page.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-resolve
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000c)]
		void Resolve([In] int fFlags);

		/// <summary>Gets the location of the icon assigned to the link.</summary>
		/// <param name="sPath">When this method returns, it holds the fully qualified path of the file that contains the icon.</param>
		/// <returns>Returns the icon's index in the file specified by sPath.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-geticonlocation
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000d)]
		int GetIconLocation([MarshalAs(UnmanagedType.BStr)] out string sPath);

		/// <summary>Sets the location of the icon assigned to the link.</summary>
		/// <param name="sPath">The fully qualified path of the file that contains the icon.</param>
		/// <param name="iIndex">The index of the icon in the file specified by sPath.</param>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-seticonlocation
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
		void SetIconLocation([In, MarshalAs(UnmanagedType.BStr)] string sPath, [In] int iIndex);

		/// <summary>Saves all changes to the link.</summary>
		/// <param name="sFile">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// A string value that contains the fully qualified path of the file where the new link information is to be saved. If no file
		/// is specified, the current file is used.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-save
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000f)]
		void Save([In, Optional, MarshalAs(UnmanagedType.Struct)] object? sFile);
	}

	/// <summary>Extends the <c>ShellLinkObject</c> object and supports one additional property.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/ishelllinkdual2-object
	[PInvokeData("shldisp.h", MSDNShortId = "8a63552c-6bce-4583-8df8-a7f7731b35eb")]
	[ComImport, Guid("317EE249-F12E-11D2-B1E4-00C04F8EEB3E"), CoClass(typeof(ShellLinkObject))]
	public interface IShellLinkDual2 : IShellLinkDual
	{
		/// <summary>
		/// <para>Gets or sets the path to the link object.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-path
		[DispId(0x60020000)]
		new string Path { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020000)] set; }

		/// <summary>
		/// <para>Gets or sets the description of the link.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-description
		[DispId(0x60020002)]
		new string Description { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)] set; }

		/// <summary>
		/// <para>Gets or sets the working directory specified in the link.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-workingdirectory
		[DispId(0x60020004)]
		new string WorkingDirectory { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)] set; }

		/// <summary>
		/// <para>Contains a link's arguments.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-arguments
		[DispId(0x60020006)]
		new string Arguments { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)] set; }

		/// <summary>
		/// <para>Gets or sets the keyboard shortcut for the link.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-hotkey
		[DispId(0x60020008)]
		new int Hotkey { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)] get; [param: In][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)] set; }

		/// <summary>
		/// <para>Gets or sets the initial display state (sized, minimized, or maximized) of the link's command.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-showcommand
		[DispId(0x6002000a)]
		new int ShowCommand { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)] get; [param: In][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)] set; }

		/// <summary>Looks for the target of a Shell link, even if the target has been moved or renamed.</summary>
		/// <param name="fFlags">
		/// <para>Type: <c>Integer</c></para>
		/// <para>Flags that specify the action to be taken. This can be a combination of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// (1)Do not display a dialog box if the link cannot be resolved. When this flag is set, the high-order word of fFlags specifies
		/// a time-out duration, in milliseconds. The method returns if the link cannot be resolved within the time-out duration. If the
		/// high-order word is set to zero, the time-out duration defaults to 3000 milliseconds (3 seconds).
		/// </item>
		/// <item>(4)If the link has changed, update its path and list of identifiers.</item>
		/// <item>(8)Do not update the link information.</item>
		/// <item>(16)Do not execute the search heuristics.</item>
		/// <item>(32)Do not use distributed link tracking.</item>
		/// <item>
		/// (64)Disable distributed link tracking. By default, distributed link tracking tracks removable media across multiple devices
		/// based on the volume name. It also uses the UNC path to track remote file systems whose drive letter has changed. Setting this
		/// flag disables both types of tracking.
		/// </item>
		/// <item>(128)Call the Windows Installer.</item>
		/// </list>
		/// </param>
		/// <remarks>
		/// This method is essentially identical in functionality to <c>Resolve</c>. For further discussion of link resolution, see the
		/// Remarks section of that page.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-resolve
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000c)]
		new void Resolve([In] int fFlags);

		/// <summary>Gets the location of the icon assigned to the link.</summary>
		/// <param name="sPath">When this method returns, it holds the fully qualified path of the file that contains the icon.</param>
		/// <returns>Returns the icon's index in the file specified by sPath.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-geticonlocation
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000d)]
		new int GetIconLocation([MarshalAs(UnmanagedType.BStr)] out string sPath);

		/// <summary>Sets the location of the icon assigned to the link.</summary>
		/// <param name="sPath">The fully qualified path of the file that contains the icon.</param>
		/// <param name="iIndex">The index of the icon in the file specified by sPath.</param>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-seticonlocation
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
		new void SetIconLocation([In, MarshalAs(UnmanagedType.BStr)] string sPath, [In] int iIndex);

		/// <summary>Saves all changes to the link.</summary>
		/// <param name="sFile">
		/// <para>Type: <c>Variant</c></para>
		/// <para>
		/// A string value that contains the fully qualified path of the file where the new link information is to be saved. If no file
		/// is specified, the current file is used.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-save
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000f)]
		new void Save([In, Optional, MarshalAs(UnmanagedType.Struct)] object? sFile);

		/// <summary>Contains the link object's target.</summary>
		/// <value>An object expression that evaluates to the target's FolderItem object.</value>
		[DispId(0x60030000)]
		FolderItem Target { [return: MarshalAs(UnmanagedType.Interface)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030000)] get; }
	}

	/// <summary>Exposes methods that enable HTML pages which are hosted in a wizard extension to communicate with the wizard.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/webwizardhost
	[PInvokeData("shldisp.h", MSDNShortId = "7b3690dc-2007-43a0-80a3-4a68e3c8464d")]
	[ComImport, Guid("18BCC359-4990-4BFB-B951-3C83702BE5F9")]
	public interface IWebWizardHost
	{
		/// <summary>Navigates to the client-side page immediately preceding the page hosting the server-side HTML pages.</summary>
		/// <remarks>
		/// When the wizard displays the first server-side page and the user clicks the <c>Back</c> button, the server invokes
		/// <c>FinalBack</c> when notified of that event by the client's event handler.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-finalback
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
		void FinalBack();

		/// <summary>
		/// Navigates to the client-side wizard page that follows the page that hosts the server-side HTML pages, or finishes the wizard
		/// if there are no further client-side pages.
		/// </summary>
		/// <remarks>
		/// When the wizard is displaying the last server-side HTML page and the user clicks the <c>Next</c> or <c>Finish</c> button, the
		/// server invokes <c>FinalNext</c> in that button's event handler.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-finalnext
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1)]
		void FinalNext();

		/// <summary>Simulates a <c>Cancel</c> button click.</summary>
		/// <remarks>The client is responsible for responding to this method with the expected behavior by closing the wizard.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-cancel
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(2)]
		void Cancel();

		/// <summary>This property is not implemented.</summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb774352(v=vs.85)
		[DispId(3)]
		string Caption { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(3)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(3)] set; }

		/// <summary>Sets or retrieves a property's current value.</summary>
		/// <value>The property value.</value>
		/// <param name="bstrPropertyName">Name of the property.</param>
		[DispId(4)]
		object this[string bstrPropertyName] { [return: MarshalAs(UnmanagedType.Struct)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(4)] get; [param: In, MarshalAs(UnmanagedType.Struct)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(4)] set; }

		/// <summary>Updates the <c>Back</c>, <c>Next</c>, and <c>Finish</c> buttons in the client's wizard frame.</summary>
		/// <param name="vfEnableBack">Enables the <c>Back</c> button.</param>
		/// <param name="vfEnableNext">Enables the <c>Next</c> button.</param>
		/// <param name="vfLastPage">Enables the <c>Finish</c> button. States that this is the last server-side page.</param>
		/// <remarks>
		/// Be sure to implement handler functions in each server-side page for OnBack() and OnNext(), corresponding to the wizard
		/// buttons <c>Back</c> and <c>Next</c>. The OnBack() and OnNext() functions respond to <c>SetWizardButtons</c>. At the
		/// appropriate time, the OnNext() function calls <c>SetWizardButtons</c> with vbLastPage= <c>true</c>, which can enable a
		/// <c>Finish</c> button. OnNext() also calls <c>FinalNext</c> when a user clicks the <c>Finish</c> button.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-setwizardbuttons
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(5)]
		void SetWizardButtons([In] bool vfEnableBack, [In] bool vfEnableNext, [In] bool vfLastPage);

		/// <summary>
		/// Sets the title and subtitle that appear in the wizard header. In general, the client will display the header above the HTML
		/// and below the title bar.
		/// </summary>
		/// <param name="bstrHeaderTitle">String containing the title.</param>
		/// <param name="bstrHeaderSubtitle">String containing the subtitle.</param>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-setheadertext
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(6)]
		void SetHeaderText([In, MarshalAs(UnmanagedType.BStr)] string bstrHeaderTitle, [In, MarshalAs(UnmanagedType.BStr)] string bstrHeaderSubtitle);
	}

	/// <summary>Undocumented.</summary>
	/// <seealso cref="IWebWizardHost"/>
	[PInvokeData("shldisp.h")]
	[ComImport, Guid("F9C013DC-3C23-4041-8E39-CFB402F7EA59")]
	public interface IWebWizardHost2 : IWebWizardHost
	{
		/// <summary>Navigates to the client-side page immediately preceding the page hosting the server-side HTML pages.</summary>
		/// <remarks>
		/// When the wizard displays the first server-side page and the user clicks the <c>Back</c> button, the server invokes
		/// <c>FinalBack</c> when notified of that event by the client's event handler.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-finalback
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
		new void FinalBack();

		/// <summary>
		/// Navigates to the client-side wizard page that follows the page that hosts the server-side HTML pages, or finishes the wizard
		/// if there are no further client-side pages.
		/// </summary>
		/// <remarks>
		/// When the wizard is displaying the last server-side HTML page and the user clicks the <c>Next</c> or <c>Finish</c> button, the
		/// server invokes <c>FinalNext</c> in that button's event handler.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-finalnext
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1)]
		new void FinalNext();

		/// <summary>Simulates a <c>Cancel</c> button click.</summary>
		/// <remarks>The client is responsible for responding to this method with the expected behavior by closing the wizard.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-cancel
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(2)]
		new void Cancel();

		/// <summary>This property is not implemented.</summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb774352(v=vs.85)
		[DispId(3)]
		new string Caption { [return: MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(3)] get; [param: In, MarshalAs(UnmanagedType.BStr)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(3)] set; }

		/// <summary>Sets or retrieves a property's current value.</summary>
		/// <value>The property value.</value>
		/// <param name="bstrPropertyName">Name of the property.</param>
		[DispId(4)]
		new object this[string bstrPropertyName] { [return: MarshalAs(UnmanagedType.Struct)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(4)] get; [param: In, MarshalAs(UnmanagedType.Struct)][MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(4)] set; }

		/// <summary>Updates the <c>Back</c>, <c>Next</c>, and <c>Finish</c> buttons in the client's wizard frame.</summary>
		/// <param name="vfEnableBack">Enables the <c>Back</c> button.</param>
		/// <param name="vfEnableNext">Enables the <c>Next</c> button.</param>
		/// <param name="vfLastPage">Enables the <c>Finish</c> button. States that this is the last server-side page.</param>
		/// <remarks>
		/// Be sure to implement handler functions in each server-side page for OnBack() and OnNext(), corresponding to the wizard
		/// buttons <c>Back</c> and <c>Next</c>. The OnBack() and OnNext() functions respond to <c>SetWizardButtons</c>. At the
		/// appropriate time, the OnNext() function calls <c>SetWizardButtons</c> with vbLastPage= <c>true</c>, which can enable a
		/// <c>Finish</c> button. OnNext() also calls <c>FinalNext</c> when a user clicks the <c>Finish</c> button.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-setwizardbuttons
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(5)]
		new void SetWizardButtons([In] bool vfEnableBack, [In] bool vfEnableNext, [In] bool vfLastPage);

		/// <summary>
		/// Sets the title and subtitle that appear in the wizard header. In general, the client will display the header above the HTML
		/// and below the title bar.
		/// </summary>
		/// <param name="bstrHeaderTitle">String containing the title.</param>
		/// <param name="bstrHeaderSubtitle">String containing the subtitle.</param>
		// https://docs.microsoft.com/en-us/windows/win32/shell/iwebwizardhost-setheadertext
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(6)]
		new void SetHeaderText([In, MarshalAs(UnmanagedType.BStr)] string bstrHeaderTitle, [In, MarshalAs(UnmanagedType.BStr)] string bstrHeaderSubtitle);

		/// <summary>Undocumented.</summary>
		[return: MarshalAs(UnmanagedType.BStr)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(7)]
		string SignString([In, MarshalAs(UnmanagedType.BStr)] string Value);
	}

	/// <summary>An autocomplete object (CLSID_AutoComplete).</summary>
	[ComImport, SuppressUnmanagedCodeSecurity, Guid("00BB2763-6A77-11D0-A535-00C04FD7D062"), ClassInterface(ClassInterfaceType.None)]
	public class CAutoComplete { }

	/// <summary>Define the events for shell IDispatch interfaces.</summary>
	[PInvokeData("shldisp.h")]
	public static class DISPID
	{
		/// <summary>The Selected Items Changed</summary>
		public const int DISPID_SELECTIONCHANGED = 200;
		/// <summary>Done enumerating the shell folder</summary>
		public const int DISPID_FILELISTENUMDONE = 201;
		/// <summary>A verb (either from the main or context menu) was invoked in the folder view</summary>
		public const int DISPID_VERBINVOKED = 202;
		/// <summary>default verb (either from the main or context menu) was invoked in the folder view</summary>
		public const int DISPID_DEFAULTVERBINVOKED = 203;
		/// <summary>user clicked on an item</summary>
		public const int DISPID_BEGINDRAG = 204;
		/// <summary>The ListViewMode Changed</summary>
		public const int DISPID_VIEWMODECHANGED = 205;
		/// <summary>We went from 0->some or some->0 items in the view</summary>
		public const int DISPID_NOITEMSTATE_CHANGED = 206;
		/// <summary>contents of the view have changed somehow</summary>
		public const int DISPID_CONTENTSCHANGED = 207;
		/// <summary>The Focused Item Changed</summary>
		public const int DISPID_FOCUSCHANGED = 208;
		/// <summary>Checkbox state changed.</summary>
		public const int DISPID_CHECKSTATECHANGED = 209;
		/// <summary>The order of items changed</summary>
		public const int DISPID_ORDERCHANGED = 210;
		/// <summary>The enumerated items have been inserted into the view and painted</summary>
		public const int DISPID_VIEWPAINTDONE = 211;
		/// <summary>The set of visible details columns changed</summary>
		public const int DISPID_COLUMNSCHANGED = 212;
		/// <summary>The mousewheel has been moved while the CTRL key was down</summary>
		public const int DISPID_CTRLMOUSEWHEEL = 213;
		/// <summary>Done sorting the shell folder</summary>
		public const int DISPID_SORTDONE = 214;
		/// <summary>The icon size changed in the view</summary>
		public const int DISPID_ICONSIZECHANGED = 215;
		/// <summary>The state of the folder has changed</summary>
		public const int DISPID_FOLDERCHANGED = 217;
		/// <summary>Some filter changed</summary>
		public const int DISPID_FILTERINVOKED = 218;
		/// <summary>Text in WordWheel changed</summary>
		public const int DISPID_WORDWHEELEDITED = 219;
		/// <summary>One of the selected items has changed (not the same as a selection change)</summary>
		public const int DISPID_SELECTEDITEMCHANGED = 220;
		/// <summary>Explorer window is open, been painted and is ready</summary>
		public const int DISPID_EXPLORERWINDOWREADY = 221;
		/// <summary>A SHCNE_UPDATEIMAGE notification was received</summary>
		public const int DISPID_UPDATEIMAGE = 222;
		/// <summary>Used internally by specialized views like the start menu. Not fired when the data source finishes enumeration. To detect when the data source is done enumerating, use DISPID_FILELISTENUMDONE.</summary>
		public const int DISPID_INITIALENUMERATIONDONE = 223;
		/// <summary>Fired when enterprise id is changed in Common File Dialog during save as</summary>
		public const int DISPID_ENTERPRISEIDCHANGED = 224;
		/// <summary>The user hit Enter or Return</summary>
		public const int DISPID_ENTERPRESSED = 200;
		/// <summary/>
		public const int DISPID_SEARCHCOMMAND_START = 1;
		/// <summary/>
		public const int DISPID_SEARCHCOMMAND_COMPLETE = 2;
		/// <summary/>
		public const int DISPID_SEARCHCOMMAND_ABORT = 3;
		/// <summary/>
		public const int DISPID_SEARCHCOMMAND_UPDATE = 4;
		/// <summary/>
		public const int DISPID_SEARCHCOMMAND_PROGRESSTEXT = 5;
		/// <summary/>
		public const int DISPID_SEARCHCOMMAND_ERROR = 6;
		/// <summary/>
		public const int DISPID_SEARCHCOMMAND_RESTORE = 7;
		/// <summary/>
		public const int DISPID_IADCCTL_DIRTY = 0x100;
		/// <summary/>
		public const int DISPID_IADCCTL_PUBCAT = 0x101;
		/// <summary/>
		public const int DISPID_IADCCTL_SORT = 0x102;
		/// <summary/>
		public const int DISPID_IADCCTL_FORCEX86 = 0x103;
		/// <summary/>
		public const int DISPID_IADCCTL_SHOWPOSTSETUP = 0x104;
		/// <summary/>
		public const int DISPID_IADCCTL_ONDOMAIN = 0x105;
		/// <summary/>
		public const int DISPID_IADCCTL_DEFAULTCAT = 0x106;
	}

	/// <summary>Undocumented.</summary>
	[ComImport, Guid("C4EE31F3-4768-11D2-BE5C-00A0C9A83DA1"), ClassInterface(ClassInterfaceType.None)]
	public class FileSearchBand { }

	/// <summary>
	/// Represents the objects in the Shell. Methods are provided to control the Shell and to execute commands within the Shell. There
	/// are also methods to obtain other Shell-related objects.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/shell
	[PInvokeData("shldisp.h", MSDNShortId = "75fc151e-5b9e-476b-b4e5-b848917357a8")]
	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("13709620-C279-11CE-A49E-444553540000")]
	public class Shell { }

	/// <summary>
	/// Represents an object in the Shell. Methods are provided to control the Shell and to execute commands within the Shell. There are
	/// also methods to obtain other Shell-related objects.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/ishelldispatch
	[PInvokeData("shldisp.h", MSDNShortId = "9B429C03-7F80-45db-B8CD-58D19FAD2E61")]
	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("0A89A860-D7B1-11CE-8350-444553540000")]
	public class ShellDispatchInproc { }

	/// <summary>
	/// Extends the <c>FolderItem</c> object. In addition to the properties and methods supported by <c>FolderItem</c>,
	/// <c>ShellFolderItem</c> has two additional methods.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderitem-object
	[PInvokeData("shldisp.h", MSDNShortId = "0e2f4c91-f9f9-4daa-a801-9c7fea8af738")]
	[ComImport, Guid("2FE352EA-FD1F-11D2-B1F4-00C04F8EEB3E"), ClassInterface(ClassInterfaceType.None)]
	public class ShellFolderItem { }

	/// <summary>
	/// Represents the objects in a view and provides properties and methods used to obtain information about the contents of the view.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview
	[PInvokeData("shldisp.h", MSDNShortId = "3b866266-fee0-42f7-a1e0-9adb6cc2e23f")]
	[ComImport, Guid("62112AA1-EBE4-11CF-A5FB-0020AFE7292D"), ClassInterface(ClassInterfaceType.None)]
	public class ShellFolderView { }

	/// <summary>
	/// Represents the objects in a view and provides properties and methods used to obtain information about the contents of the view.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/shellfolderview
	[PInvokeData("shldisp.h", MSDNShortId = "3b866266-fee0-42f7-a1e0-9adb6cc2e23f")]
	[ComImport, Guid("9BA05971-F6A8-11CF-A442-00A0C90A8F39"), ClassInterface(ClassInterfaceType.None)]
	public class ShellFolderViewOC { }

	/// <summary>
	/// Manages Shell links. This object makes much of the functionality of the <c>IShellLink</c> interface available to scripting applications.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/shelllinkobject-object
	[PInvokeData("", MSDNShortId = "d3c0ccf8-0f83-42f7-9d6f-1fb293da6364")]
	[ComImport, Guid("11219420-1768-11D1-95BE-00609797EA4F"), ClassInterface(ClassInterfaceType.None)]
	public class ShellLinkObject { }
}