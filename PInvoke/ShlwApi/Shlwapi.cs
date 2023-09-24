using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

/// <summary>Exposes interfaces, functions and structures defined in shlwapi.dll.</summary>
public static partial class ShlwApi
{
	/// <summary>
	/// <para>Used by IQueryAssociations::GetData to define the type of data that is to be returned.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/ne-shlwapi-assocdata
	[PInvokeData("shlwapi.h", MSDNShortId = "0ae5c8db-81fd-4d00-8e54-0c474f1bfd06")]
	public enum ASSOCDATA
	{
		/// <summary>The component descriptor to pass to the Windows Installer API.</summary>
		ASSOCDATA_MSIDESCRIPTOR = 1,

		/// <summary>Attempts to activate a window are restricted. There is no data associated with this value.</summary>
		ASSOCDATA_NOACTIVATEHANDLER,

		/// <summary/>
		ASSOCDATA_UNUSED1,

		/// <summary>Defaults to user specified association.</summary>
		ASSOCDATA_HASPERUSERASSOC,

		/// <summary>
		/// Internet Explorer version 6 or later. Gets the data stored in the EditFlags value of a file association PROGID registry key.
		/// This value consists of one or more FILETYPEATTRIBUTEFLAGS. Compare against those values to determine which attributes have
		/// been set.
		/// </summary>
		ASSOCDATA_EDITFLAGS,

		/// <summary>
		/// Internet Explorer version 6 or later. Uses the parameter from the IQueryAssociations::GetData method as the value name.
		/// </summary>
		ASSOCDATA_VALUE,

		/// <summary/>
		ASSOCDATA_MAX,
	}

	/// <summary>
	/// <para>Used by IQueryAssociations::GetEnum to define the type of enum that is to be returned.</para>
	/// </summary>
	public enum ASSOCENUM
	{
		/// <summary>Nothing.</summary>
		ASSOCENUM_NONE
	}

	/// <summary>Format flags for SHFormatDateTime.</summary>
	[PInvokeData("shlwapi.h", MSDNShortId = "2208ed29-6029-4051-bdcc-885c42fe5c1b")]
	[Flags]
	public enum FDTF
	{
		/// <summary>
		/// Formats the time of day as specified by the Regional and Language Options application in Control Panel, but without seconds.
		/// This flag cannot be combined with FDTF_LONGTIME.
		/// <para>The short time was successfully formatted.</para>
		/// </summary>
		FDTF_SHORTTIME = 0x00000001,

		/// <summary>
		/// Formats the date as specified by the short date format in the Regional and Language Options application in Control Panel.
		/// This flag cannot be combined with FDTF_LONGDATE.
		/// <para>The short date was successfully formatted.</para>
		/// </summary>
		FDTF_SHORTDATE = 0x00000002,

		/// <summary>Equivalent to FDTF_SHORTDATE | FDTF_SHORTTIME.</summary>
		FDTF_DEFAULT = FDTF_SHORTDATE | FDTF_SHORTTIME,

		/// <summary>
		/// Formats the date as specified by the long date format in the Regional and Language Options application in Control Panel. This
		/// flag cannot be combined with FDTF_SHORTDATE.
		/// <para>The long date was successfully formatted.</para>
		/// </summary>
		FDTF_LONGDATE = 0x00000004,

		/// <summary>
		/// Formats the time of day as specified by the Regional and Language Options application in Control Panel, including seconds.
		/// This flag cannot be combined with FDTF_SHORTTIME.
		/// <para>The long time was successfully formatted.</para>
		/// </summary>
		FDTF_LONGTIME = 0x00000008,

		/// <summary>
		/// If the FDTF_LONGDATE flag is set and the date in the FILETIME structure is the same date that SHFormatDateTime is called,
		/// then the day of the week (if present) is changed to "Today". If the date in the structure is the previous day, then the day
		/// of the week (if present) is changed to "Yesterday".
		/// <para>Relative notation was used for the date.</para>
		/// </summary>
		FDTF_RELATIVE = 0x00000010,

		/// <summary>Adds marks for left-to-right reading layout. This flag cannot be combined with FDTF_RTLDATE.</summary>
		FDTF_LTRDATE = 0x00000100,

		/// <summary>Adds marks for right-to-left reading layout. This flag cannot be combined with FDTF_LTRDATE.</summary>
		FDTF_RTLDATE = 0x00000200,

		/// <summary>
		/// No reading order marks are inserted. Normally, in the absence of the FDTF_LTRDATE or FDTF_RTLDATE flag, SHFormatDateTime
		/// determines the reading order from the user's default locale, inserts reading order marks, and updates the pdwFlags output
		/// value appropriately. This flag prevents that process from occurring. It is used most commonly by legacy callers of
		/// SHFormatDateTime. This flag cannot be combined with FDTF_RTLDATE or FDTF_LTRDATE.
		/// <para>Windows Server 2003 and Windows XP: This value is not available.</para>
		/// </summary>
		FDTF_NOAUTOREADINGORDER = 0x00000400,
	}

	/// <summary>
	/// <para>
	/// Indicates <c>FILETYPEATTRIBUTEFLAGS</c> constants that are used in the EditFlags value of a file association PROGID registry key.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// These flags represent possible attributes stored in the EditFlags value of a ProgID registration. The EditFlags data is a single REG_DWORD.
	/// </para>
	/// <para>
	/// The following example shows the <c><c>FTA_NoRemove</c></c> (0x00000010) and <c><c>FTA_NoNewVerb</c></c> (0x00000020) attributes
	/// assigned to the .myp file type.
	/// </para>
	/// <para><c>.myp</c> (Default) = MyProgram.1 <c>MyProgram.1</c> (Default) = MyProgram Application <c>EditFlags</c> = 0x00000030</para>
	/// <para>
	/// APIs such as IQueryAssociations::GetData can retrieve that EditFlags data. Compare the numerical equivalents of these
	/// <c>FILETYPEATTRIBUTEFLAGS</c> flags against that retrived value to determine which flags are set.
	/// </para>
	/// <para>The following example demonstrates the use of IQueryAssociations::GetData to determine if those values are set.</para>
	/// <para>
	/// To set an EditFlags attribute, you can use the RegSetValueEx or SHSetValue functions. First use IQueryAssociations::GetData to
	/// retrieve the current set of attributes as shown in the example above, add the desired <c>FILETYPEATTRIBUTEFLAGS</c> to that
	/// value, then write that value back to the registry using one of the two set functions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/ne-shlwapi-filetypeattributeflags typedef enum FILETYPEATTRIBUTEFLAGS
	// { FTA_None , FTA_Exclude , FTA_Show , FTA_HasExtension , FTA_NoEdit , FTA_NoRemove , FTA_NoNewVerb , FTA_NoEditVerb ,
	// FTA_NoRemoveVerb , FTA_NoEditDesc , FTA_NoEditIcon , FTA_NoEditDflt , FTA_NoEditVerbCmd , FTA_NoEditVerbExe , FTA_NoDDE ,
	// FTA_NoEditMIME , FTA_OpenIsSafe , FTA_AlwaysUnsafe , FTA_NoRecentDocs , FTA_SafeForElevation , FTA_AlwaysUseDirectInvoke } ;
	[PInvokeData("shlwapi.h", MSDNShortId = "63b58659-9c4c-4b39-98d1-743724523dcd")]
	public enum FILETYPEATTRIBUTEFLAGS : uint
	{
		/// <summary>No FILETYPEATTRIBUTEFLAGS options set.</summary>
		FTA_None = 0x00000000,

		/// <summary>Excludes the file type.</summary>
		FTA_Exclude = 0x00000001,

		/// <summary>Shows file types, such as folders, that are not associated with a file name extension.</summary>
		FTA_Show = 0x00000002,

		/// <summary>Indicates that the file type has a file name extension.</summary>
		FTA_HasExtension = 0x00000004,

		/// <summary>
		/// Prohibits editing of the registry entries associated with this file type, the addition of new entries, and the deletion or
		/// modification of existing entries.
		/// </summary>
		FTA_NoEdit = 0x00000008,

		/// <summary>Prohibits deletion of the registry entries associated with this file type.</summary>
		FTA_NoRemove = 0x00000010,

		/// <summary>Prohibits the addition of new verbs to the file type.</summary>
		FTA_NoNewVerb = 0x00000020,

		/// <summary>Prohibits the modification or deletion of canonical verbs such as open and print.</summary>
		FTA_NoEditVerb = 0x00000040,

		/// <summary>Prohibits the deletion of canonical verbs such as open and print.</summary>
		FTA_NoRemoveVerb = 0x00000080,

		/// <summary>Prohibits the modification or deletion of the description of the file type.</summary>
		FTA_NoEditDesc = 0x00000100,

		/// <summary>Prohibits the modification or deletion of the icon assigned to the file type.</summary>
		FTA_NoEditIcon = 0x00000200,

		/// <summary>Prohibits the modification of the default verb.</summary>
		FTA_NoEditDflt = 0x00000400,

		/// <summary>Prohibits the modification of the commands associated with verbs.</summary>
		FTA_NoEditVerbCmd = 0x00000800,

		/// <summary>Prohibits the modification or deletion of verbs.</summary>
		FTA_NoEditVerbExe = 0x00001000,

		/// <summary>Prohibits the modification or deletion of the entries related to DDE.</summary>
		FTA_NoDDE = 0x00002000,

		/// <summary>Prohibits the modification or deletion of the content type and default extension entries.</summary>
		FTA_NoEditMIME = 0x00008000,

		/// <summary>
		/// Indicates that the file type's open verb can be safely invoked for downloaded files. This flag applies only to safe file
		/// types, as identified by AssocIsDangerous. To improve the user experience and reduce unnecessary user prompts when downloading
		/// and activating items, file type owners should specify this flag and applications that download and activate files should
		/// respect this flag.
		/// </summary>
		FTA_OpenIsSafe = 0x00010000,

		/// <summary>
		/// Prevents the Never ask me check box from being enabled. Use of this flag means FTA_OpenIsSafe is not respected and
		/// AssocIsDangerous always returns TRUE. If your file type can execute code, you should always use this flag or ensure that the
		/// file type handlers mitigate risks, for example, by producing warning prompts before running the code. The user can override
		/// this attribute through the File Type dialog box.
		/// </summary>
		FTA_AlwaysUnsafe = 0x00020000,

		/// <summary>
		/// Prohibits the addition of members of this file type to the Recent Documents folder. Additionally, in Windows 7 and later,
		/// prohibits the addition of members of this file type to the automatic Recent or Frequent category of an application's Jump
		/// List. This flag does not restrict members of this file type from being added to a custom Jump List. It also places no
		/// restriction on the file type being added to the automatic Jump Lists of other applications in the case that other
		/// applications use this file type.
		/// </summary>
		FTA_NoRecentDocs = 0x00100000,

		/// <summary>
		/// Introduced in Windows 8. Marks the file as safe to be passed from a low trust application to a full trust application. Files
		/// that originate from the Internet or an app container are examples where the file is considered untrusted. Untrusted files
		/// that contain code are especially dangerous, and appropriate security mitigations must be applied if the file is to be opened
		/// by a full trust application. File type owners for file formats that have the ability to execute code should specify this flag
		/// only if their program mitigates elevation-of-privilege threats that are associated with running code at a higher integrity
		/// level. Mitigations include prompting the user before code is executed or executing the code with reduced privileges. By
		/// specifying this flag for an entire file type, an app running within an app container can pass files of this type to a program
		/// running at full trust. Some file types are recognized as inherently dangerous due to their ability to execute code and will
		/// be blocked if you don't specify this value.
		/// </summary>
		FTA_SafeForElevation = 0x00200000,

		/// <summary>
		/// Introduced in Windows 8. Ensures that the verbs for the file type are invoked with a URI instead of a downloaded version of
		/// the file. Use this flag only if you've registered the file type's verb to support DirectInvoke through the SupportedProtocols
		/// or UseUrl registration.
		/// </summary>
		FTA_AlwaysUseDirectInvoke = 0x00400000,
	}

	/// <summary>Return values for <see cref="PathGetCharType"/></summary>
	[PInvokeData("shlwapi.h", MSDNShortId = "838a255f-413e-424c-819e-47265224208d")]
	[Flags]
	public enum GCT : uint
	{
		/// <summary>The character is not valid in a path.</summary>
		GCT_INVALID = 0x0000,

		/// <summary>The character is valid in a long file name.</summary>
		GCT_LFNCHAR = 0x0001,

		/// <summary>The character is valid in a short (8.3) file name.</summary>
		GCT_SHORTCHAR = 0x0002,

		/// <summary>The character is a wildcard character.</summary>
		GCT_WILD = 0x0004,

		/// <summary>The character is a path separator.</summary>
		GCT_SEPARATOR = 0x0008,
	}

	/// <summary>Options for <see cref="IsOS"/>.</summary>
	[PInvokeData("shlwapi.h", MSDNShortId = "827a76bc-3581-4f1c-8095-8e2fd30dfdbc")]
	public enum OS
	{
		/// <summary>
		/// The program is running on one of the following versions of Windows:
		/// <list type="bullet">
		/// <item>
		/// <term>Windows 95</term>
		/// </item>
		/// <item>
		/// <term>Windows 98</term>
		/// </item>
		/// <item>
		/// <term>Windows Me</term>
		/// </item>
		/// </list>
		/// <para>
		/// Equivalent to VER_PLATFORM_WIN32_WINDOWS. Note that none of those systems are supported at this time. OS_WINDOWS returns
		/// FALSE on all supported systems.
		/// </para>
		/// </summary>
		OS_WINDOWS = 0,

		/// <summary>Always returns TRUE.</summary>
		OS_NT = 1,

		/// <summary>Always returns FALSE.</summary>
		OS_WIN95ORGREATER = 2,

		/// <summary>Always returns FALSE.</summary>
		OS_NT4ORGREATER = 3,

		/// <summary>Always returns FALSE.</summary>
		OS_WIN98ORGREATER = 5,

		/// <summary>Always returns FALSE.</summary>
		OS_WIN98_GOLD = 6,

		/// <summary>The program is running on Windows 2000 or one of its successors.</summary>
		OS_WIN2000ORGREATER = 7,

		/// <summary>Do not use; use OS_PROFESSIONAL.</summary>
		OS_WIN2000PRO = 8,

		/// <summary>Do not use; use OS_SERVER.</summary>
		OS_WIN2000SERVER = 9,

		/// <summary>Do not use; use OS_ADVSERVER.</summary>
		OS_WIN2000ADVSERVER = 10,

		/// <summary>Do not use; use OS_DATACENTER.</summary>
		OS_WIN2000DATACENTER = 11,

		/// <summary>
		/// The program is running on Windows 2000 Terminal Server in either Remote Administration mode or Application Server mode, or
		/// Windows Server 2003 (or one of its successors) in Terminal Server mode or Remote Desktop for Administration mode. Consider
		/// using a more specific value such as OS_TERMINALSERVER, OS_TERMINALREMOTEADMIN, or OS_PERSONALTERMINALSERVER.
		/// </summary>
		OS_WIN2000TERMINAL = 12,

		/// <summary>The program is running on Windows Embedded, any version. Equivalent to VER_SUITE_EMBEDDEDNT.</summary>
		OS_EMBEDDED = 13,

		/// <summary>The program is running as a Terminal Server client. Equivalent to GetSystemMetrics(SM_REMOTESESSION).</summary>
		OS_TERMINALCLIENT = 14,

		/// <summary>
		/// The program is running on Windows 2000 Terminal Server in the Remote Administration mode or Windows Server 2003 (or
		/// one of its successors) in the Remote Desktop for Administration mode (these are the default installation modes). This is
		/// equivalent to VER_SUITE_TERMINAL &amp;&amp; VER_SUITE_SINGLEUSERTS.
		/// </summary>
		OS_TERMINALREMOTEADMIN = 15,

		/// <summary>Always returns FALSE.</summary>
		OS_WIN95_GOLD = 16,

		/// <summary>Always returns FALSE.</summary>
		OS_MEORGREATER = 17,

		/// <summary>Always returns FALSE.</summary>
		OS_XPORGREATER = 18,

		/// <summary>Always returns FALSE.</summary>
		OS_HOME = 19,

		/// <summary>The program is running on Windows NT Workstation or Windows 2000 (or one of its successors) Professional. Equivalent
		/// to VER_PLATFORM_WIN32_NT  &amp;&amp; VER_NT_WORKSTATION.</summary>
		OS_PROFESSIONAL = 20,

		/// <summary>The program is running on Windows Datacenter Server or Windows Server Datacenter Edition, any version. Equivalent to
		/// (VER_NT_SERVER || VER_NT_DOMAIN_CONTROLLER)  &amp;&amp; VER_SUITE_DATACENTER.</summary>
		OS_DATACENTER = 21,

		/// <summary>The program is running on Windows Advanced Server or Windows Server Enterprise Edition, any version. Equivalent to
		/// (VER_NT_SERVER || VER_NT_DOMAIN_CONTROLLER)  &amp;&amp; VER_SUITE_ENTERPRISE  &amp;&amp; !VER_SUITE_DATACENTER.</summary>
		OS_ADVSERVER = 22,

		/// <summary>
		/// The program is running on Windows Server (Standard) or Windows Server Standard Edition, any version. This value will not
		/// return true for VER_SUITE_DATACENTER, VER_SUITE_ENTERPRISE, VER_SUITE_SMALLBUSINESS, or VER_SUITE_SMALLBUSINESS_RESTRICTED.
		/// </summary>
		OS_SERVER = 23,

		/// <summary>The program is running on Windows 2000 Terminal Server in Application Server mode, or on Windows Server 2003 (or one
		/// of its successors) in Terminal Server mode. This is equivalent to VER_SUITE_TERMINAL &amp;&amp; VER_SUITE_SINGLEUSERTS.</summary>
		OS_TERMINALSERVER = 24,

		/// <summary>The program is running on Windows XP (or one of its successors), Home Edition or Professional. This is equivalent to
		/// VER_SUITE_SINGLEUSERTS  &amp;&amp; !VER_SUITE_TERMINAL.</summary>
		OS_PERSONALTERMINALSERVER = 25,

		/// <summary>Fast user switching is enabled.</summary>
		OS_FASTUSERSWITCHING = 26,

		/// <summary>Always returns FALSE.</summary>
		OS_WELCOMELOGONUI = 27,

		/// <summary>The computer is joined to a domain.</summary>
		OS_DOMAINMEMBER = 28,

		/// <summary>The program is running on any Windows Server product. Equivalent to VER_NT_SERVER || VER_NT_DOMAIN_CONTROLLER.</summary>
		OS_ANYSERVER = 29,

		/// <summary>The program is a 32-bit program running on 64-bit Windows.</summary>
		OS_WOW6432 = 30,

		/// <summary>Always returns FALSE.</summary>
		OS_WEBSERVER = 31,

		/// <summary>
		/// The program is running on Microsoft Small Business Server with restrictive client license in force. Equivalent to VER_SUITE_SMALLBUSINESS_RESTRICTED.
		/// </summary>
		OS_SMALLBUSINESSSERVER = 32,

		/// <summary>The program is running on Windows XP Tablet PC Edition, or one of its successors.</summary>
		OS_TABLETPC = 33,

		/// <summary>
		/// The user should be presented with administrator UI. It is possible to have server administrative UI on a non-server machine.
		/// This value informs the application that an administrator's profile has roamed to a non-server, and UI should be appropriate
		/// to an administrator. Otherwise, the user is shown a mix of administrator and nonadministrator settings.
		/// </summary>
		OS_SERVERADMINUI = 34,

		/// <summary>The program is running on Windows XP Media Center Edition, or one of its successors. Equivalent to GetSystemMetrics(SM_MEDIACENTER).</summary>
		OS_MEDIACENTER = 35,

		/// <summary>The program is running on Windows Appliance Server.</summary>
		OS_APPLIANCE = 36,
	}

	/// <summary>The flags to control the operation of SHAutoComplete.</summary>
	[PInvokeData("shlwapi.h", MSDNShortId = "b47efa8d-2118-4805-bb04-97bd143228dc")]
	[Flags]
	public enum SHACF : uint
	{
		/// <summary>
		/// Ignore the registry default and force the AutoAppend feature off. This flag must be used in combination with one or more of
		/// the SHACF_FILESYS* or SHACF_URL* flags.
		/// </summary>
		SHACF_AUTOAPPEND_FORCE_OFF = 0x80000000,

		/// <summary>
		/// Ignore the registry value and force the AutoAppend feature on. The completed string will be displayed in the edit box with
		/// the added characters highlighted. This flag must be used in combination with one or more of the SHACF_FILESYS* or SHACF_URL* flags.
		/// </summary>
		SHACF_AUTOAPPEND_FORCE_ON = 0x40000000,

		/// <summary>
		/// Ignore the registry default and force the AutoSuggest feature off. This flag must be used in combination with one or more of
		/// the SHACF_FILESYS* or SHACF_URL* flags.
		/// </summary>
		SHACF_AUTOSUGGEST_FORCE_OFF = 0x20000000,

		/// <summary>
		/// Ignore the registry value and force the AutoSuggest feature on. A selection of possible completed strings will be displayed
		/// as a drop-down list, below the edit box. This flag must be used in combination with one or more of the SHACF_FILESYS* or
		/// SHACF_URL* flags.
		/// </summary>
		SHACF_AUTOSUGGEST_FORCE_ON = 0x10000000,

		/// <summary>
		/// The default setting, equivalent to SHACF_FILESYSTEM | SHACF_URLALL. SHACF_DEFAULT cannot be combined with any other flags.
		/// </summary>
		SHACF_DEFAULT = 0x00000000,

		/// <summary>Include the file system only.</summary>
		SHACF_FILESYS_ONLY = 0x00000010,

		/// <summary>Include the file system and directories, UNC servers, and UNC server shares.</summary>
		SHACF_FILESYS_DIRS = 0x00000020,

		/// <summary>Include the file system and the rest of the Shell (Desktop, Computer, and Control Panel, for example).</summary>
		SHACF_FILESYSTEM = 0x00000001,

		/// <summary>Include the URLs in the users History and Recently Used lists. Equivalent to SHACF_URLHISTORY | SHACF_URLMRU.</summary>
		SHACF_URLALL = (SHACF_URLHISTORY | SHACF_URLMRU),

		/// <summary>Include the URLs in the user's History list.</summary>
		SHACF_URLHISTORY = 0x00000002,

		/// <summary>Include the URLs in the user's Recently Used list.</summary>
		SHACF_URLMRU = 0x00000004,

		/// <summary>
		/// Allow the user to select from the autosuggest list by pressing the TAB key. If this flag is not set, pressing the TAB key
		/// will shift focus to the next control and close the autosuggest list. If SHACF_USETAB is set, pressing the TAB key will select
		/// the first item in the list. Pressing TAB again will select the next item in the list, and so on. When the user reaches the
		/// end of the list, the next TAB key press will cycle the focus back to the edit control. This flag must be used in combination
		/// with one or more of the SHACF_FILESYS* or SHACF_URL* flags listed on this page.
		/// </summary>
		SHACF_USETAB = 0x00000008,

		/// <summary>Also include the virtual namespace</summary>
		SHACF_VIRTUAL_NAMESPACE = 0x00000040
	}

	/// <summary>
	/// <para>
	/// Flags that control the calling function's behavior. Used by <c>SHCreateThread</c> and <c>SHCreateThreadWithHandle</c>. In those
	/// functions, these values are defined as being of type SHCT_FLAGS.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CTF_INSIST0x00000001</term>
	/// <term>
	/// 0x00000001. If the attempt to create the thread with CreateThread fails, setting this flag will cause the function pointed to by
	/// pfnThreadProc to be called synchronously from the calling thread. This flag can be used only if pfnCallback is NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CTF_THREAD_REF0x00000002</term>
	/// <term>
	/// 0x00000002. Hold a reference to the creating thread for the duration of the call to the function pointed to by pfnThreadProc.
	/// This reference must have been set with SHSetThreadRef.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CTF_PROCESS_REF0x00000004</term>
	/// <term>
	/// 0x00000004. Hold a reference to the Windows Explorer process for the duration of the call to the function pointed to by
	/// pfnThreadProc. This flag is useful for Shell extension handlers, which might need to keep the Windows Explorer process from
	/// closing prematurely. This action is useful during tasks such as working on a background thread or copying files. For more
	/// information, see SHGetInstanceExplorer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CTF_COINIT_STA0x00000008</term>
	/// <term>
	/// 0x00000008. Initialize COM as a Single Threaded Apartment (STA) for the created thread before calling either the optional
	/// function pointed to by pfnCallback or the function pointed to by pfnThreadProc. This flag is useful when COM needs to be
	/// initialized for a thread. COM will automatically be uninitialized as well.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CTF_COINIT0x00000008</term>
	/// <term>Equivalent to CTF_COINIT_STA.</term>
	/// </item>
	/// <item>
	/// <term>CTF_FREELIBANDEXIT0x00000010</term>
	/// <term>
	/// 0x00000010. Internet Explorer 6 or later.LoadLibrary will be called on the DLL that contains the pfnThreadProc function to
	/// prevent it from being unloaded. After pfnThreadProc returns, the DLL will be freed with FreeLibrary, thereby decrementing the DLL
	/// reference count. Pass this flag to prevent the DLL from being unloaded prematurely; for example, by CoFreeUnusedLibraries. Note
	/// that if this flag is passed, the pfnThreadProc function must reside in a DLL. This flag is implicit in Windows Vista and later.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CTF_REF_COUNTED0x00000020</term>
	/// <term>
	/// 0x00000020. Internet Explorer 6 or later. A thread reference will automatically be created for the created thread and set with
	/// SHSetThreadRef. After the pfnThreadProc returns, the thread reference is released and messages are sent until the reference count
	/// on the thread reference drops to zero, that is, until threads that are dependent on the created thread have released their references.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CTF_WAIT_ALLOWCOM0x00000040</term>
	/// <term>
	/// 0x00000040. Internet Explorer 6 or later. The calling thread waits and pumps COM and SendMessage messages. If the synchronous
	/// procedure attempts to send a Windows message with SendMessage to a window hosted on the calling thread, the message will arrive
	/// successfully. If the synchronous procedure attempts to use COM to communicate with an STA object hosted on the calling thread,
	/// the function call will successfully reach the intended object. The calling thread is open to re-entrance fragility. While the
	/// calling thread can handle the synchronous procedure's use of SendMessage and COM, if other threads are using SendMessage or COM
	/// to communicate to objects hosted on the calling thread, then these might be unexpected messages or function calls which are
	/// processed while the synchronous procedure is completing.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CTF_UNUSED0x00000080</term>
	/// <term>0x00000080. Internet Explorer 7 or later. Not used.</term>
	/// </item>
	/// <item>
	/// <term>CTF_INHERITWOW640x00000100</term>
	/// <term>
	/// 0x00000100. Internet Explorer 7 or later. The new thread inherits the Windows-on-Windows 64-bit (WOW64) disable state for the
	/// file system redirector.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CTF_WAIT_NO_REENTRANCY0x00000200</term>
	/// <term>
	/// 0x00000200. Windows Vista or later. The calling thread blocks all other processes while waiting for the synchronous procedure to
	/// run on the new thread. If the synchronous procedure attempts to send a Windows message with SendMessage to a window hosted on the
	/// calling thread, this causes the synchronous procedure to deadlock. If the synchronous procedure attempts to use COM to talk to an
	/// STA object hosted on the calling thread, this also causes the synchronous procedure to deadlock. The calling thread is protected
	/// from all re-entrance concerns by specifying this flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CTF_KEYBOARD_LOCALE0x00000400</term>
	/// <term>0x00000400. Windows 7 or later. Use the keyboard locale from the original thread in the new thread that it spawns.</term>
	/// </item>
	/// <item>
	/// <term>CTF_OLEINITIALIZE0x00000800</term>
	/// <term>0x00000800. Windows 7 or later. Initialize COM with the single-threaded apartment (STA) model for the created thread.</term>
	/// </item>
	/// <item>
	/// <term>CTF_COINIT_MTA0x00001000</term>
	/// <term>0x00001000. Windows 7 and later. Initialize COM with the multithreaded apartment (MTA) model for the created thread.</term>
	/// </item>
	/// <item>
	/// <term>CTF_NOADDREFLIB0x00002000</term>
	/// <term>
	/// 0x00002000. Windows 7 or later. This flag is essentially the opposite of CTF_FREELIBANDEXIT. This avoids
	/// LoadLibrary/FreeLibraryAndExitThread calls that can result in contention for the loader lock. Use CTF_NOADDREFLIB only when the
	/// new thread has means to ensure that the code of the original thread procedure will remain loaded. This value should not be used
	/// in the context of COM objects, because COM objects must ensure that the DLL stays loaded (normally, COM unloads the DLLs).
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </summary>
	/// <returns></returns>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/bb762495(v=vs.85).aspx
	[PInvokeData("Shlwapi.h", MSDNShortId = "bb762495")]
	[Flags]
	public enum SHCT_FLAGS
	{
		/// <summary>
		/// If the attempt to create the thread with CreateThread fails, setting this flag will cause the function pointed to by
		/// pfnThreadProc to be called synchronously from the calling thread. This flag can be used only if pfnCallback is NULL.
		/// </summary>
		CTF_INSIST = 0x00000001,

		/// <summary>
		/// Hold a reference to the creating thread for the duration of the call to the function pointed to by pfnThreadProc. This
		/// reference must have been set with SHSetThreadRef.
		/// </summary>
		CTF_THREAD_REF = 0x00000002,

		/// <summary>
		/// Hold a reference to the Windows Explorer process for the duration of the call to the function pointed to by pfnThreadProc.
		/// This flag is useful for Shell extension handlers, which might need to keep the Windows Explorer process from closing
		/// prematurely. This action is useful during tasks such as working on a background thread or copying files. For more
		/// information, see SHGetInstanceExplorer.
		/// </summary>
		CTF_PROCESS_REF = 0x00000004,

		/// <summary>
		/// Initialize COM as a Single Threaded Apartment (STA) for the created thread before calling either the optional function
		/// pointed to by pfnCallback or the function pointed to by pfnThreadProc. This flag is useful when COM needs to be initialized
		/// for a thread. COM will automatically be uninitialized as well.
		/// </summary>
		CTF_COINIT_STA = 0x00000008,

		/// <summary>Equivalent to CTF_COINIT_STA.</summary>
		CTF_COINIT = 0x00000008,

		/// <summary>
		/// Internet Explorer 6 or later. LoadLibrary will be called on the DLL that contains the pfnThreadProc function to prevent it
		/// from being unloaded. After pfnThreadProc returns, the DLL will be freed with FreeLibrary, thereby decrementing the DLL
		/// reference count. Pass this flag to prevent the DLL from being unloaded prematurely; for example, by CoFreeUnusedLibraries.
		/// Note that if this flag is passed, the pfnThreadProc function must reside in a DLL. This flag is implicit in Windows Vista and later.
		/// </summary>
		CTF_FREELIBANDEXIT = 0x00000010,

		/// <summary>
		/// Internet Explorer 6 or later. A thread reference will automatically be created for the created thread and set with
		/// SHSetThreadRef. After the pfnThreadProc returns, the thread reference is released and messages are sent until the reference
		/// count on the thread reference drops to zero, that is, until threads that are dependent on the created thread have released
		/// their references.
		/// </summary>
		CTF_REF_COUNTED = 0x00000020,

		/// <summary>
		/// Internet Explorer 6 or later. The calling thread waits and pumps COM and SendMessage messages. If the synchronous procedure
		/// attempts to send a Windows message with SendMessage to a window hosted on the calling thread, the message will arrive
		/// successfully. If the synchronous procedure attempts to use COM to communicate with an STA object hosted on the calling
		/// thread, the function call will successfully reach the intended object. The calling thread is open to re-entrance fragility.
		/// While the calling thread can handle the synchronous procedure's use of SendMessage and COM, if other threads are using
		/// SendMessage or COM to communicate to objects hosted on the calling thread, then these might be unexpected messages or
		/// function calls which are processed while the synchronous procedure is completing.
		/// </summary>
		CTF_WAIT_ALLOWCOM = 0x00000040,

		/// <summary>Internet Explorer 7 or later. Not used.</summary>
		CTF_UNUSED = 0x00000080,

		/// <summary>
		/// Internet Explorer 7 or later. The new thread inherits the Windows-on-Windows 64-bit (WOW64) disable state for the file system redirector.
		/// </summary>
		CTF_INHERITWOW64 = 0x00000100,

		/// <summary>
		/// Windows Vista or later. The calling thread blocks all other processes while waiting for the synchronous procedure to run on
		/// the new thread. If the synchronous procedure attempts to send a Windows message with SendMessage to a window hosted on the
		/// calling thread, this causes the synchronous procedure to deadlock. If the synchronous procedure attempts to use COM to talk
		/// to an STA object hosted on the calling thread, this also causes the synchronous procedure to deadlock. The calling thread is
		/// protected from all re-entrance concerns by specifying this flag.
		/// </summary>
		CTF_WAIT_NO_REENTRANCY = 0x00000200,

		/// <summary>Windows 7 or later. Use the keyboard locale from the original thread in the new thread that it spawns.</summary>
		CTF_KEYBOARD_LOCALE = 0x00000400,

		/// <summary>Windows 7 or later. Initialize COM with the single-threaded apartment (STA) model for the created thread.</summary>
		CTF_OLEINITIALIZE = 0x00000800,

		/// <summary>Windows 7 and later. Initialize COM with the multithreaded apartment (MTA) model for the created thread.</summary>
		CTF_COINIT_MTA = 0x00001000,

		/// <summary>
		/// Windows 7 or later. This flag is essentially the opposite of CTF_FREELIBANDEXIT. This avoids LoadLibrary/
		/// FreeLibraryAndExitThread calls that can result in contention for the loader lock. Use CTF_NOADDREFLIB only when the new
		/// thread has means to ensure that the code of the original thread procedure will remain loaded. This value should not be used
		/// in the context of COM objects, because COM objects must ensure that the DLL stays loaded (normally, COM unloads the DLLs).
		/// </summary>
		CTF_NOADDREFLIB = 0x00002000,
	}

	/// <summary>Value that indicates the type of Shell32.dll that the platform contains.</summary>
	[PInvokeData("shlwapi.h", MSDNShortId = "14af733b-81b4-40a2-b93b-6f387b181f12")]
	public enum SHELLPLATFORM
	{
		/// <summary>The function was unable to determine the Shell32.dll version.</summary>
		PLATFORM_UNKNOWN = 0,

		/// <summary>Obsolete: Use PLATFORM_BROWSERONLY.</summary>
		PLATFORM_IE3 = 1,

		/// <summary>The Shell32.dll version is browser-only, with no new shell.</summary>
		PLATFORM_BROWSERONLY = 1,

		/// <summary>The platform contains an integrated shell.</summary>
		PLATFORM_INTEGRATED = 2,
	}

	/// <summary>Flags used by <see cref="SHGetViewStatePropertyBag"/>.</summary>
	[PInvokeData("shlwapi.h", MSDNShortId = "6852867a-30a5-4d4e-b790-3746104e3ed8")]
	[Flags]
	public enum SHGVSPB : uint
	{
		/// <summary>Returns the per-user properties for the specified pidl.</summary>
		SHGVSPB_PERUSER = 0x00000001,

		/// <summary>
		/// Returns the All User properties for the specified pidl.
		/// <para>One value from the following set of flags is required.</para>
		/// </summary>
		SHGVSPB_ALLUSERS = 0x00000002,

		/// <summary>Returns the property bag for the folder specified by the pidl parameter.</summary>
		SHGVSPB_PERFOLDER = 0x00000004,

		/// <summary>Returns the property bag that applies to all folders.</summary>
		SHGVSPB_ALLFOLDERS = 0x00000008,

		/// <summary>
		/// Returns the property bag used to provide defaults for subfolders that do not have their property bag.
		/// <para>The following flags are optional.</para>
		/// </summary>
		SHGVSPB_INHERIT = 0x00000010,

		/// <summary>Allows the property bag to roam. See Roaming User Profiles. This flag cannot be combined with SHGVSPB_ALLFOLDERS.</summary>
		SHGVSPB_ROAM = 0x00000020,

		/// <summary>
		/// Suppresses the search for a suitable default when the property bag cannot be found for the specified folder. By default, if
		/// SHGVSPB_INHERIT is not specified and a property bag cannot be found for the specified folder, the system searches for
		/// identically named property bags in other locations that may be able to provide default values. For example, the system
		/// searches in the ancestors of the folder to see if any of them provide a SHGVSPB_INHERIT property bag. Other places the system
		/// searches are in the user defaults and the global defaults.
		/// <para>The following set of flags consists of values that combine some flags listed above, and are used for brevity and convenience.</para>
		/// </summary>
		SHGVSPB_NOAUTODEFAULTS = 0x80000000,

		/// <summary>Combines SHGVSPB_PERUSER and SHGVSPB_PERFOLDER.</summary>
		SHGVSPB_FOLDER = (SHGVSPB_PERUSER | SHGVSPB_PERFOLDER),

		/// <summary>Combines SHGVSPB_PERUSER, SHGVSPB_PERFOLDER, and SHGVSPB_NOAUTODEFAULTS.</summary>
		SHGVSPB_FOLDERNODEFAULTS = (SHGVSPB_PERUSER | SHGVSPB_PERFOLDER | SHGVSPB_NOAUTODEFAULTS),

		/// <summary>Combines SHGVSPB_PERUSER and SHGVSPB_ALLFOLDERS.</summary>
		SHGVSPB_USERDEFAULTS = (SHGVSPB_PERUSER | SHGVSPB_ALLFOLDERS),

		/// <summary>
		/// Combines SHGVSPB_ALLUSERS and SHGVSPB_ALLFOLDERS.
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This flag is named SHGVSPB_GLOBALDEAFAULTS.</para>
		/// </summary>
		SHGVSPB_GLOBALDEFAULTS = (SHGVSPB_ALLUSERS | SHGVSPB_ALLFOLDERS),
	}

	/// <summary>
	/// <para>Provides a set of values that indicate from which base key an item will be deleted.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/ne-shlwapi-shregdel_flags typedef enum SHREGDEL_FLAGS {
	// SHREGDEL_DEFAULT , SHREGDEL_HKCU , SHREGDEL_HKLM , SHREGDEL_BOTH } ;
	[PInvokeData("shlwapi.h", MSDNShortId = "90a8bf22-f62b-4027-8219-7a5ead6577da")]
	[Flags]
	public enum SHREGDEL_FLAGS
	{
		/// <summary>Deletes from HKEY_CURRENT_USER. If the specified item is not found under HKEY_CURRENT_USER, deletes from HKEY_LOCAL_MACHINE.</summary>
		SHREGDEL_DEFAULT = 0x00000000,

		/// <summary>Enumerates from HKEY_CURRENT_USER only.</summary>
		SHREGDEL_HKCU = 0x00000001,

		/// <summary>Enumerates under HKEY_LOCAL_MACHINE only.</summary>
		SHREGDEL_HKLM = 0x00000010,

		/// <summary>Deletes from both HKEY_CURRENT_USER and HKEY_LOCAL_MACHINE.</summary>
		SHREGDEL_BOTH = 0x00000011,
	}

	/// <summary>
	/// <para>Provides a set of values that indicate the base key that will be used for an enumeration.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/ne-shlwapi-shregenum_flags typedef enum SHREGENUM_FLAGS {
	// SHREGENUM_DEFAULT , SHREGENUM_HKCU , SHREGENUM_HKLM , SHREGENUM_BOTH } ;
	[PInvokeData("shlwapi.h", MSDNShortId = "4216a983-9d53-44b1-8273-e5a90ac4b3ef")]
	public enum SHREGENUM_FLAGS
	{
		/// <summary>
		/// Enumerates under HKEY_CURRENT_USER, or, if the specified item is not found in HKEY_CURRENT_USER, enumerates under HKEY_LOCAL_MACHINE.
		/// </summary>
		SHREGENUM_DEFAULT = 0x00000000,

		/// <summary>Enumerates under HKEY_CURRENT_USER only.</summary>
		SHREGENUM_HKCU = 0x00000001,

		/// <summary>Enumerates under HKEY_LOCAL_MACHINE only.</summary>
		SHREGENUM_HKLM = 0x00000010,

		/// <summary>Not used.</summary>
		SHREGENUM_BOTH = 0x00000011,
	}

	/// <summary>Flags used by <see cref="SHRegCreateUSKey"/>.</summary>
	[PInvokeData("shlwapi.h", MSDNShortId = "10e3e31e-bff6-4260-95fa-2d750de16ab3")]
	[Flags]
	public enum SHREGSET
	{
		/// <summary>
		/// Create/open the key under both <c>HKEY_CURRENT_USER</c> (forced) and <c>HKEY_LOCAL_MACHINE</c> (only if empty). This flag is
		/// the equivalent of ( <c>SHREGSET_FORCE_HKCU</c> | <c>SHREGSET_HKLM</c>).
		/// </summary>
		SHREGSET_DEFAULT = (SHREGSET_FORCE_HKCU | SHREGSET_HKLM),

		/// <summary>Create/open the key under <c>HKEY_CURRENT_USER</c>. Only creates a key if it is empty.</summary>
		SHREGSET_HKCU = 0x00000001,

		/// <summary>Create/open the key under <c>HKEY_CURRENT_USER</c>. Creates a key even if it is not empty.</summary>
		SHREGSET_FORCE_HKCU = 0x00000002,

		/// <summary>Create/open the key under <c>HKEY_LOCAL_MACHINE</c>. Only creates a key if it is empty.</summary>
		SHREGSET_HKLM = 0x00000004,

		/// <summary>Create/open the key under <c>HKEY_LOCAL_MACHINE</c>. Creates a key even if it is not empty.</summary>
		SHREGSET_FORCE_HKLM = 0x00000008,
	}

	/// <summary>Flags that restrict the data to be set or returned.</summary>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/bb762547(v=vs.85).aspx
	[PInvokeData("Shlwapi.h", MSDNShortId = "bb762547")]
	[Flags]
	public enum SRRF : uint
	{
		/// <summary>Type REG_NONE.</summary>
		SRRF_RT_REG_NONE = 0x00000001,

		/// <summary>Type REG_SZ. REG_EXPAND_SZ types are automatically converted to REG_SZ unless the SRRF_NOEXPAND flag is specified.</summary>
		SRRF_RT_REG_SZ = 0x00000002,

		/// <summary>
		/// Type REG_EXPAND_SZ. If retrieving a value, you must also get the SRRF_NOEXPAND flag, or SHRegGetValue fails with ERROR_INVALID_PARAMETER.
		/// </summary>
		SRRF_RT_REG_EXPAND_SZ = 0x00000004,

		/// <summary>Type REG_BINARY.</summary>
		SRRF_RT_REG_BINARY = 0x00000008,

		/// <summary>Type REG_DWORD.</summary>
		SRRF_RT_REG_DWORD = 0x00000010,

		/// <summary>Type REG_MULTI_SZ.</summary>
		SRRF_RT_REG_MULTI_SZ = 0x00000020,

		/// <summary>Type REG_QWORD.</summary>
		SRRF_RT_REG_QWORD = 0x00000040,

		/// <summary>
		/// REG_DWORD and 32-bit REG_BINARY types. This is equivalent to SRRF_RT_REG_BINARY | SRRF_RT_REG_DWORD. If retrieving a value,
		/// if the value's binary data is larger than 32 bits, it is not returned.
		/// </summary>
		SRRF_RT_DWORD = 0x00000018,

		/// <summary>
		/// REG_QWORD and 64-bit REG_BINARY types. This is equivalent to SRRF_RT_REG_BINARY | SRRF_RT_REG_QWORD. If retrieving a value,
		/// if the value's binary data is larger than 64 bits, it is not returned.
		/// </summary>
		SRRF_RT_QWORD = 0x00000048,

		/// <summary>All types. Set this flag if no other SRRF_RT value is set.</summary>
		SRRF_RT_ANY = 0x0000FFFF,

		/// <summary>No mode restriction. This is the default value.</summary>
		SRRF_RM_ANY = 0x00000000,

		/// <summary>Restrict system startup mode to "normal boot".</summary>
		SRRF_RM_NORMAL = 0x00010000,

		/// <summary>Restrict system startup mode to "safe mode".</summary>
		SRRF_RM_SAFE = 0x00020000,

		/// <summary>Restrict system startup mode to "safe mode with networking".</summary>
		SRRF_RM_SAFENETWORK = 0x00040000,

		/// <summary>Do not automatically expand REG_EXPAND_SZ environment strings.</summary>
		SRRF_NOEXPAND = 0x10000000,

		/// <summary>If retrieving a value, if pvData is not NULL, set the contents of the pvData buffer to all zeros on failure.</summary>
		SRRF_ZEROONFAILURE = 0x20000000,

		/// <summary>When retrieving a value, if the requested key is virtualized, fail with ERROR_FILE_NOT_FOUND.</summary>
		SRRF_NOVIRT = 0x40000000,
	}

	/// <summary>
	/// <para>Performs a comparison between two characters. The comparison is not case-sensitive.</para>
	/// </summary>
	/// <param name="w1">
	/// <para>Type: <c>TCHAR</c></para>
	/// <para>The first character to be compared.</para>
	/// </param>
	/// <param name="w2">
	/// <para>Type: <c>TCHAR</c></para>
	/// <para>The second character to be compared.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns zero if the two characters are the same, or nonzero otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-chrcmpia BOOL ChrCmpIA( WORD w1, WORD w2 );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "ae2f3cbf-c65b-41a4-8d59-39d6fadf40ca")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ChrCmpI(ushort w1, ushort w2);

	/// <summary>
	/// <para>Changes the luminance of a RGB value. Hue and saturation are not affected.</para>
	/// </summary>
	/// <param name="clrRGB">
	/// <para>Type: <c>COLORREF</c></para>
	/// <para>The initial RGB value.</para>
	/// </param>
	/// <param name="n">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The luminance in units of 0.1 percent of the total range. For example, a value of n = 50 corresponds to 5 percent of the maximum luminance.
	/// </para>
	/// </param>
	/// <param name="fScale">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If fScale is set to <c>TRUE</c>, n specifies how much to increment or decrement the current luminance. If fScale is set to
	/// <c>FALSE</c>, n specifies the absolute luminance.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>COLORREF</c></para>
	/// <para>Returns the modified RGB value.</para>
	/// </returns>
	/// <remarks>
	/// <para>If fScale is set to <c>TRUE</c>, n can range from -1000 to +1000.</para>
	/// <para>
	/// If fScale is set to <c>FALSE</c>, n can range from 0 to 1000. Available luminance values range from 0 to a maximum. If the
	/// requested value is negative or exceeds the maximum, the luminance will be set to either zero or the maximum value, respectively.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-coloradjustluma COLORREF ColorAdjustLuma( COLORREF clrRGB,
	// int n, BOOL fScale );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "d113ad59-cde4-4f11-b7f1-53b3fb69ec10")]
	public static extern COLORREF ColorAdjustLuma(COLORREF clrRGB, int n, [MarshalAs(UnmanagedType.Bool)] bool fScale);

	/// <summary>
	/// <para>Converts colors from hue-luminance-saturation (HLS) to RGB format.</para>
	/// </summary>
	/// <param name="wHue">
	/// <para>Type: <c>WORD</c></para>
	/// <para>The original HLS hue value.</para>
	/// </param>
	/// <param name="wLuminance">
	/// <para>Type: <c>WORD</c></para>
	/// <para>The original HLS luminance value.</para>
	/// </param>
	/// <param name="wSaturation">
	/// <para>Type: <c>WORD</c></para>
	/// <para>The original HLS saturation value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>COLORREF</c></para>
	/// <para>Returns the RGB value.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-colorhlstorgb COLORREF ColorHLSToRGB( WORD wHue, WORD
	// wLuminance, WORD wSaturation );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "1bf0b337-01de-4ce3-851f-d845866fb46f")]
	public static extern COLORREF ColorHLSToRGB(ushort wHue, ushort wLuminance, ushort wSaturation);

	/// <summary>
	/// <para>Converts colors from RGB to hue-luminance-saturation (HLS) format.</para>
	/// </summary>
	/// <param name="clrRGB">
	/// <para>Type: <c>COLORREF</c></para>
	/// <para>The original RGB color.</para>
	/// </param>
	/// <param name="pwHue">
	/// <para>Type: <c>WORD*</c></para>
	/// <para>A pointer to a value that, when this method returns successfully, receives the HLS hue value.</para>
	/// </param>
	/// <param name="pwLuminance">
	/// <para>Type: <c>WORD*</c></para>
	/// <para>A pointer to a value that, when this method returns successfully, receives the HLS luminance value.</para>
	/// </param>
	/// <param name="pwSaturation">
	/// <para>Type: <c>WORD*</c></para>
	/// <para>A pointer to a value that, when this method returns successfully, receives the HLS saturation value.</para>
	/// </param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-colorrgbtohls void ColorRGBToHLS( COLORREF clrRGB, WORD
	// *pwHue, WORD *pwLuminance, WORD *pwSaturation );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "ed000f53-cc7e-4693-994c-a5dd7c789f1f")]
	public static extern void ColorRGBToHLS(COLORREF clrRGB, out ushort pwHue, out ushort pwLuminance, out ushort pwSaturation);

	/// <summary>
	/// <para>
	/// [This function is available through Windows XP and Windows Server 2003. It might be altered or unavailable in subsequent versions
	/// of Windows.]
	/// </para>
	/// <para>Establishes or terminates a connection between a client's sink and a connection point container.</para>
	/// </summary>
	/// <param name="punk">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>
	/// A pointer to the IUnknown interface of the object to be connected to the connection point container. If you set fConnect to
	/// <c>FALSE</c> to indicate that you are disconnecting the object, this parameter is ignored and can be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="riidEvent">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>The IID of the interface on the connection point container whose connection point object is being requested.</para>
	/// </param>
	/// <param name="fConnect">
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if a connection is being established; <c>FALSE</c> if a connection is being broken.</para>
	/// </param>
	/// <param name="punkTarget">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>A pointer to the connection point container's IUnknown interface.</para>
	/// </param>
	/// <param name="pdwCookie">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>
	/// A connection token. If you set fConnect to <c>TRUE</c> to make a new connection, this parameter receives a token that uniquely
	/// identifies the connection. If you set fConnect to <c>FALSE</c> to break a connection, this parameter must point to the token that
	/// you received when you called <c>ConnectToConnectionPoint</c> to establish the connection.
	/// </para>
	/// </param>
	/// <param name="ppcpOut">
	/// <para>Type: <c>IConnectionPoint**</c></para>
	/// <para>
	/// A pointer to the connection point container's IConnectionPoint interface, if the operation was successful. The calling
	/// application must release this pointer when it is no longer needed. If the request is unsuccessful, the pointer receives
	/// <c>NULL</c>. This parameter is optional and can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-connecttoconnectionpoint LWSTDAPI
	// ConnectToConnectionPoint( IUnknown *punk, REFIID riidEvent, BOOL fConnect, IUnknown *punkTarget, DWORD *pdwCookie,
	// IConnectionPoint **ppcpOut );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "f0c6051e-cced-4f38-a35d-d4c184d39084")]
	public static extern HRESULT ConnectToConnectionPoint([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? punk, in Guid riidEvent,
		[MarshalAs(UnmanagedType.Bool)] bool fConnect, [In, MarshalAs(UnmanagedType.IUnknown)] object punkTarget, ref uint pdwCookie,
		[MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out IConnectionPoint? ppcpOut);

	/// <summary>
	/// <para>
	/// [This function is available through Windows XP and Windows Server 2003. It might be altered or unavailable in subsequent versions
	/// of Windows.]
	/// </para>
	/// <para>Establishes or terminates a connection between a client's sink and a connection point container.</para>
	/// </summary>
	/// <param name="punk">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>
	/// A pointer to the IUnknown interface of the object to be connected to the connection point container. If you set fConnect to
	/// <c>FALSE</c> to indicate that you are disconnecting the object, this parameter is ignored and can be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="riidEvent">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>The IID of the interface on the connection point container whose connection point object is being requested.</para>
	/// </param>
	/// <param name="fConnect">
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if a connection is being established; <c>FALSE</c> if a connection is being broken.</para>
	/// </param>
	/// <param name="punkTarget">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>A pointer to the connection point container's IUnknown interface.</para>
	/// </param>
	/// <param name="pdwCookie">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>
	/// A connection token. If you set fConnect to <c>TRUE</c> to make a new connection, this parameter receives a token that uniquely
	/// identifies the connection. If you set fConnect to <c>FALSE</c> to break a connection, this parameter must point to the token that
	/// you received when you called <c>ConnectToConnectionPoint</c> to establish the connection.
	/// </para>
	/// </param>
	/// <param name="ppcpOut">
	/// <para>Type: <c>IConnectionPoint**</c></para>
	/// <para>
	/// A pointer to the connection point container's IConnectionPoint interface, if the operation was successful. The calling
	/// application must release this pointer when it is no longer needed. If the request is unsuccessful, the pointer receives
	/// <c>NULL</c>. This parameter is optional and can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-connecttoconnectionpoint LWSTDAPI
	// ConnectToConnectionPoint( IUnknown *punk, REFIID riidEvent, BOOL fConnect, IUnknown *punkTarget, DWORD *pdwCookie,
	// IConnectionPoint **ppcpOut );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "f0c6051e-cced-4f38-a35d-d4c184d39084")]
	public static extern HRESULT ConnectToConnectionPoint([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? punk, in Guid riidEvent,
		[MarshalAs(UnmanagedType.Bool)] bool fConnect, [In, MarshalAs(UnmanagedType.IUnknown)] object punkTarget, ref uint pdwCookie, IntPtr ppcpOut = default);

	/// <summary>
	/// <para>Retrieves a string used with websites when specifying language preferences.</para>
	/// </summary>
	/// <param name="pszLanguages">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// A pointer to a string that, when this function returns successfully, receives the language preferences information. We recommend
	/// that this buffer be of size 2048 characters to ensure sufficient space to return the full string. You can also call this function
	/// with this parameter set to NULL to retrieve the size of the string that will be returned.
	/// </para>
	/// </param>
	/// <param name="pcchLanguages">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>A pointer to the size, in characters, of the string at pszLanguages.</para>
	/// <para>On entry, this value is the size of pszLanguages, including the terminating null character.</para>
	/// <para>On exit, it is the actual size of pszLanguages, not including the terminating null character.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For those versions of Windows that do not include <c>GetAcceptLanguages</c> in Shlwapi.h, this function's individual ANSI or
	/// Unicode version must be called directly from Shlwapi.dll. <c>GetAcceptLanguagesA</c> is ordinal 14 and <c>GetAcceptLanguagesW</c>
	/// is ordinal 15.
	/// </para>
	/// <para>
	/// Some websites offer content in multiple languages. You can specify your language preferences in the Internet Options item in
	/// Control Panel. <c>GetAcceptLanguages</c> retrieves a string that represents those preferences. That string is sent in an
	/// additional language header when negotiating HTTP connections.
	/// </para>
	/// <para>
	/// <c>Note</c> If your app or service passes language tags from this function to any National Language Support functions, or to
	/// Microsoft .NET, it must first convert the tags through the ResolveLocaleName function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-getacceptlanguagesa LWSTDAPI GetAcceptLanguagesA( LPSTR
	// pszLanguages, DWORD *pcchLanguages );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "a680a7fd-f980-485d-b52a-eb4d482ebc17")]
	public static extern HRESULT GetAcceptLanguages(StringBuilder? pszLanguages, ref uint pcchLanguages);

	/// <summary>
	/// <para>
	/// [ <c>GetMenuPosFromID</c> is available for use in the operating systems specified in the Requirements section. It may be altered
	/// or unavailable in subsequent versions.]
	/// </para>
	/// <para>Determines the position of an item in a menu. Used in the case where the item's ID is known.</para>
	/// </summary>
	/// <param name="hmenu">
	/// <para>Type: <c>HMENU</c></para>
	/// <para>The handle of the menu.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT</c></para>
	/// <para>An application-defined 16-bit value that identifies the menu item.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>The item's zero-based position in the menu.</para>
	/// </returns>
	/// <remarks>
	/// <para>Beginning with Windows Vista, this function is declared in Shlwapi.h.</para>
	/// <para><c>Windows XP:</c> This function is declared in Shlwapi.dll.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-getmenuposfromid int GetMenuPosFromID( HMENU hmenu, UINT
	// id );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "25fb51bc-9b36-4afb-bb07-7bc455c7fbc4")]
	public static extern int GetMenuPosFromID(HMENU hmenu, uint id);

	/// <summary>
	/// <para>Hashes an array of data.</para>
	/// </summary>
	/// <param name="pbData">
	/// <para>Type: <c>BYTE*</c></para>
	/// <para>A pointer to the data array.</para>
	/// </param>
	/// <param name="cbData">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The number of elements in the array at pbData.</para>
	/// </param>
	/// <param name="pbHash">
	/// <para>Type: <c>BYTE*</c></para>
	/// <para>A pointer to a value that, when this function returns successfully, receives the hashed array.</para>
	/// </param>
	/// <param name="cbHash">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The number of elements in pbHash. It should be no larger than 256.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-hashdata LWSTDAPI HashData( BYTE *pbData, DWORD cbData,
	// BYTE *pbHash, DWORD cbHash );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "7b42b3ae-c021-49be-b5a7-d3bc0a5d346a")]
	public static extern HRESULT HashData(IntPtr pbData, uint cbData, IntPtr pbHash, uint cbHash);

	/// <summary>
	/// <para>Determines whether a character represents a space.</para>
	/// </summary>
	/// <param name="wch">
	/// <para>Type: <c>TCHAR</c></para>
	/// <para>A single character.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns <c>TRUE</c> if the character is a space; otherwise, <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For those versions of Windows that do not include <c>IsCharSpace</c> in Shlwapi.h, <c>IsCharSpaceW</c> must be called directly
	/// from Shlwapi.dll (ordinal 29), using a WCHAR in the wch parameter. <c>IsCharSpaceA</c> is not available in versions of Windows
	/// that do not include <c>IsCharSpace</c> in Shlwapi.h.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-ischarspacew BOOL IsCharSpaceW( WCHAR wch );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "40ccde4d-38e8-4c03-a826-b6c060037ae5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsCharSpace(char wch);

	/// <summary>
	/// <para>Determines whether Windows Internet Explorer is in the Enhanced Security Configuration.</para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns <c>TRUE</c> if Internet Explorer is in the Enhanced Security Configuration, and <c>FALSE</c> otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-isinternetescenabled BOOL IsInternetESCEnabled( );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "2f803b69-9734-484c-9392-a48e116cf506")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsInternetESCEnabled();

	/// <summary>
	/// <para>Checks for specified operating systems and operating system features.</para>
	/// </summary>
	/// <param name="dwOS">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// A value that specifies which operating system or operating system feature to check for. One of the following values (you cannot
	/// combine values).
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Name</term>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>OS_WINDOWS</term>
	/// <term>0</term>
	/// <term>
	/// The program is running on one of the following versions of Windows: Equivalent to VER_PLATFORM_WIN32_WINDOWS. Note that none of
	/// those systems are supported at this time. OS_WINDOWS returns FALSE on all supported systems.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OS_NT</term>
	/// <term>1</term>
	/// <term>Always returns TRUE.</term>
	/// </item>
	/// <item>
	/// <term>OS_WIN95ORGREATER</term>
	/// <term>2</term>
	/// <term>Always returns FALSE.</term>
	/// </item>
	/// <item>
	/// <term>OS_NT4ORGREATER</term>
	/// <term>3</term>
	/// <term>Always returns FALSE.</term>
	/// </item>
	/// <item>
	/// <term>OS_WIN98ORGREATER</term>
	/// <term>5</term>
	/// <term>Always returns FALSE.</term>
	/// </item>
	/// <item>
	/// <term>OS_WIN98_GOLD</term>
	/// <term>6</term>
	/// <term>Always returns FALSE.</term>
	/// </item>
	/// <item>
	/// <term>OS_WIN2000ORGREATER</term>
	/// <term>7</term>
	/// <term>The program is running on Windows 2000 or one of its successors.</term>
	/// </item>
	/// <item>
	/// <term>OS_WIN2000PRO</term>
	/// <term>8</term>
	/// <term>Do not use; use OS_PROFESSIONAL.</term>
	/// </item>
	/// <item>
	/// <term>OS_WIN2000SERVER</term>
	/// <term>9</term>
	/// <term>Do not use; use OS_SERVER.</term>
	/// </item>
	/// <item>
	/// <term>OS_WIN2000ADVSERVER</term>
	/// <term>10</term>
	/// <term>Do not use; use OS_ADVSERVER.</term>
	/// </item>
	/// <item>
	/// <term>OS_WIN2000DATACENTER</term>
	/// <term>11</term>
	/// <term>Do not use; use OS_DATACENTER.</term>
	/// </item>
	/// <item>
	/// <term>OS_WIN2000TERMINAL</term>
	/// <term>12</term>
	/// <term>
	/// The program is running on Windows 2000 Terminal Server in either Remote Administration mode or Application Server mode, or
	/// Windows Server 2003 (or one of its successors) in Terminal Server mode or Remote Desktop for Administration mode. Consider using
	/// a more specific value such as OS_TERMINALSERVER, OS_TERMINALREMOTEADMIN, or OS_PERSONALTERMINALSERVER.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OS_EMBEDDED</term>
	/// <term>13</term>
	/// <term>The program is running on Windows Embedded, any version. Equivalent to VER_SUITE_EMBEDDEDNT.</term>
	/// </item>
	/// <item>
	/// <term>OS_TERMINALCLIENT</term>
	/// <term>14</term>
	/// <term>The program is running as a Terminal Server client. Equivalent to GetSystemMetrics(SM_REMOTESESSION).</term>
	/// </item>
	/// <item>
	/// <term>OS_TERMINALREMOTEADMIN</term>
	/// <term>15</term>
	/// <term>
	/// The program is running on Windows 2000 Terminal Server in the Remote Administration mode or Windows Server 2003 (or one of its
	/// successors) in the Remote Desktop for Administration mode (these are the default installation modes). This is equivalent to
	/// VER_SUITE_TERMINAL &amp;&amp; VER_SUITE_SINGLEUSERTS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OS_WIN95_GOLD</term>
	/// <term>16</term>
	/// <term>Always returns FALSE.</term>
	/// </item>
	/// <item>
	/// <term>OS_MEORGREATER</term>
	/// <term>17</term>
	/// <term>Always returns FALSE.</term>
	/// </item>
	/// <item>
	/// <term>OS_XPORGREATER</term>
	/// <term>18</term>
	/// <term>Always returns FALSE.</term>
	/// </item>
	/// <item>
	/// <term>OS_HOME</term>
	/// <term>19</term>
	/// <term>Always returns FALSE.</term>
	/// </item>
	/// <item>
	/// <term>OS_PROFESSIONAL</term>
	/// <term>20</term>
	/// <term>
	/// The program is running on Windows NT Workstation or Windows 2000 (or one of its successors) Professional. Equivalent to
	/// VER_PLATFORM_WIN32_NT &amp;&amp; VER_NT_WORKSTATION.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OS_DATACENTER</term>
	/// <term>21</term>
	/// <term>
	/// The program is running on Windows Datacenter Server or Windows Server Datacenter Edition, any version. Equivalent to
	/// (VER_NT_SERVER || VER_NT_DOMAIN_CONTROLLER) &amp;&amp; VER_SUITE_DATACENTER.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OS_ADVSERVER</term>
	/// <term>22</term>
	/// <term>
	/// The program is running on Windows Advanced Server or Windows Server Enterprise Edition, any version. Equivalent to (VER_NT_SERVER
	/// || VER_NT_DOMAIN_CONTROLLER) &amp;&amp; VER_SUITE_ENTERPRISE &amp;&amp; !VER_SUITE_DATACENTER.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OS_SERVER</term>
	/// <term>23</term>
	/// <term>
	/// The program is running on Windows Server (Standard) or Windows Server Standard Edition, any version. This value will not return
	/// true for VER_SUITE_DATACENTER, VER_SUITE_ENTERPRISE, VER_SUITE_SMALLBUSINESS, or VER_SUITE_SMALLBUSINESS_RESTRICTED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OS_TERMINALSERVER</term>
	/// <term>24</term>
	/// <term>
	/// The program is running on Windows 2000 Terminal Server in Application Server mode, or on Windows Server 2003 (or one of its
	/// successors) in Terminal Server mode. This is equivalent to VER_SUITE_TERMINAL &amp;&amp; VER_SUITE_SINGLEUSERTS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OS_PERSONALTERMINALSERVER</term>
	/// <term>25</term>
	/// <term>
	/// The program is running on Windows XP (or one of its successors), Home Edition or Professional. This is equivalent to
	/// VER_SUITE_SINGLEUSERTS &amp;&amp; !VER_SUITE_TERMINAL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OS_FASTUSERSWITCHING</term>
	/// <term>26</term>
	/// <term>Fast user switching is enabled.</term>
	/// </item>
	/// <item>
	/// <term>OS_WELCOMELOGONUI</term>
	/// <term>27</term>
	/// <term>Always returns FALSE.</term>
	/// </item>
	/// <item>
	/// <term>OS_DOMAINMEMBER</term>
	/// <term>28</term>
	/// <term>The computer is joined to a domain.</term>
	/// </item>
	/// <item>
	/// <term>OS_ANYSERVER</term>
	/// <term>29</term>
	/// <term>The program is running on any Windows Server product. Equivalent to VER_NT_SERVER || VER_NT_DOMAIN_CONTROLLER.</term>
	/// </item>
	/// <item>
	/// <term>OS_WOW6432</term>
	/// <term>30</term>
	/// <term>The program is a 32-bit program running on 64-bit Windows.</term>
	/// </item>
	/// <item>
	/// <term>OS_WEBSERVER</term>
	/// <term>31</term>
	/// <term>Always returns FALSE.</term>
	/// </item>
	/// <item>
	/// <term>OS_SMALLBUSINESSSERVER</term>
	/// <term>32</term>
	/// <term>The program is running on Microsoft Small Business Server with restrictive client license in force. Equivalent to VER_SUITE_SMALLBUSINESS_RESTRICTED.</term>
	/// </item>
	/// <item>
	/// <term>OS_TABLETPC</term>
	/// <term>33</term>
	/// <term>The program is running on Windows XP Tablet PC Edition, or one of its successors.</term>
	/// </item>
	/// <item>
	/// <term>OS_SERVERADMINUI</term>
	/// <term>34</term>
	/// <term>
	/// The user should be presented with administrator UI. It is possible to have server administrative UI on a non-server machine. This
	/// value informs the application that an administrator's profile has roamed to a non-server, and UI should be appropriate to an
	/// administrator. Otherwise, the user is shown a mix of administrator and nonadministrator settings.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OS_MEDIACENTER</term>
	/// <term>35</term>
	/// <term>The program is running on Windows XP Media Center Edition, or one of its successors. Equivalent to GetSystemMetrics(SM_MEDIACENTER).</term>
	/// </item>
	/// <item>
	/// <term>OS_APPLIANCE</term>
	/// <term>36</term>
	/// <term>The program is running on Windows Appliance Server.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns a nonzero value if the specified operating system or operating system feature is detected, otherwise <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Values are not provided for Windows Vista and Windows 7. To determine whether either of those operating systems are present, use VerifyVersionInfo.
	/// </para>
	/// <para>
	/// In Windows versions earlier than Windows Vista, <c>IsOS</c> was not exported by name or declared in a public header file. To use
	/// it in those cases, you must use GetProcAddress and request ordinal 437 from Shlwapi.dll to obtain a function pointer. Under
	/// Windows Vista, <c>IsOS</c> is included in Shlwapi.h and this is not necessary.
	/// </para>
	/// <para>
	/// When referring to server products, "Windows Server" refers only to the Standard Edition server. If all server products are
	/// covered by a particular flag, it is called out explicitly in the table.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-isos BOOL IsOS( DWORD dwOS );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "827a76bc-3581-4f1c-8095-8e2fd30dfdbc")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsOS(OS dwOS);

	/// <summary>
	/// <para>Copies a stream to another stream.</para>
	/// </summary>
	/// <param name="pstmFrom">
	/// <para>Type: <c>IStream*</c></para>
	/// <para>A pointer to the source stream.</para>
	/// </param>
	/// <param name="pstmTo">
	/// <para>Type: <c>IStream*</c></para>
	/// <para>A pointer to the destination stream.</para>
	/// </param>
	/// <param name="cb">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The number of bytes to copy from the source stream.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-istream_copy LWSTDAPI IStream_Copy( IStream *pstmFrom,
	// IStream *pstmTo, DWORD cb );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "7d6a1080-dad4-4821-8f2a-bd1e01ca10cf")]
	public static extern HRESULT IStream_Copy(IStream pstmFrom, IStream pstmTo, uint cb);

	/// <summary>
	/// Reads bytes from a specified stream and returns a value that indicates whether all bytes were successfully read.
	/// </summary>
	/// <param name="pstm"><para>Type: <c>IStream*</c></para>
	/// <para>A pointer to the IStream interface of the stream from which to read.</para></param>
	/// <param name="pv"><para>Type: <c>VOID*</c></para>
	/// <para>A pointer to a buffer to receive the stream data from pstm. This buffer must be at least cb bytes in size.</para></param>
	/// <param name="cb"><para>Type: <c>ULONG</c></para>
	/// <para>The number of bytes of data that the function should attempt to read from the input stream.</para></param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// Returns <c>S_OK</c> if the function successfully reads the specified number of bytes from the stream, or a COM failure code
	/// otherwise. In particular, if the read attempt was successful but fewer than cb bytes were read, the function returns <c>E_FAIL</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// This function calls the ISequentialStream::Read method to read data from the specified stream into the buffer. If the function
	/// fails for any reason, the contents of the output buffer and the position of the read pointer in the input stream are undefined.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-istream_read
	// LWSTDAPI IStream_Read(IStream *pstm, void *pv, ULONG cb );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "07a3a500-babb-458b-ba98-9344c63ea014")]
	public static extern HRESULT IStream_Read(IStream pstm, IntPtr pv, uint cb);

	/// <summary>
	/// Reads bytes from a specified stream and returns a value that indicates whether all bytes were successfully read.
	/// </summary>
	/// <param name="pstm"><para>Type: <c>IStream*</c></para>
	/// <para>A pointer to the IStream interface of the stream from which to read.</para></param>
	/// <param name="pv"><para>Type: <c>VOID*</c></para>
	/// <para>A pointer to a buffer to receive the stream data from pstm. This buffer must be at least cb bytes in size.</para></param>
	/// <param name="cb"><para>Type: <c>ULONG</c></para>
	/// <para>The number of bytes of data that the function should attempt to read from the input stream.</para></param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// Returns <c>S_OK</c> if the function successfully reads the specified number of bytes from the stream, or a COM failure code
	/// otherwise. In particular, if the read attempt was successful but fewer than cb bytes were read, the function returns <c>E_FAIL</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// This function calls the ISequentialStream::Read method to read data from the specified stream into the buffer. If the function
	/// fails for any reason, the contents of the output buffer and the position of the read pointer in the input stream are undefined.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-istream_read
	// LWSTDAPI IStream_Read(IStream *pstm, void *pv, ULONG cb );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "07a3a500-babb-458b-ba98-9344c63ea014")]
	public static extern HRESULT IStream_Read(IStream pstm, SafeAllocatedMemoryHandle pv, uint cb);

	/// <summary>
	/// <para>Reads a pointer to an item identifier list (PIDL) from an IStream object into a PIDLIST_RELATIVE object.</para>
	/// </summary>
	/// <param name="pstm">
	/// <para>Type: <c>IStream*</c></para>
	/// <para>A pointer to the IStream from which the PIDL is read.</para>
	/// </param>
	/// <param name="ppidlOut">
	/// <para>Type: <c>PIDLIST_RELATIVE*</c></para>
	/// <para>A pointer to the resulting PIDL.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-istream_readpidl LWSTDAPI IStream_ReadPidl( IStream *pstm,
	// PIDLIST_RELATIVE *ppidlOut );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "63b1f842-139b-4558-8105-4986ce592b56")]
	public static extern HRESULT IStream_ReadPidl([In] IStream pstm, out IntPtr ppidlOut);

	/// <summary>Reads from a stream and writes into a string.</summary>
	/// <param name="pstm">
	/// <para>Type: <c>IStream*</c></para>
	/// <para>A pointer to the stream from which to read.</para>
	/// </param>
	/// <param name="ppsz">
	/// <para>Type: <c>PWSTR*</c></para>
	/// <para>A pointer to the null-terminated, Unicode string into which the stream is written.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-istream_readstr LWSTDAPI IStream_ReadStr( IStream *pstm,
	// PWSTR *ppsz );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "e3f140c4-4033-4c82-af2c-4a7744461920")]
	public static extern HRESULT IStream_ReadStr([In] IStream pstm, out StrPtrUni ppsz);

	/// <summary>Moves the seek position in a specified stream to the beginning of the stream.</summary>
	/// <param name="pstm">
	/// <para>Type: <c>IStream*</c></para>
	/// <para>A pointer to the IStream interface of the stream whose position is to be reset.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// Returns <c>S_OK</c> on success or a COM failure code otherwise. See IStream::Seek for further discussion of possible error codes.
	/// </para>
	/// </returns>
	/// <remarks>This function calls IStream::Seek to move the stream's seek position to the beginning of the stream.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-istream_reset LWSTDAPI IStream_Reset( IStream *pstm );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "1e7a881d-decb-4018-b2e8-e0cba454236d")]
	public static extern HRESULT IStream_Reset([In] IStream pstm);

	/// <summary>
	/// <para>Retrieves the size, in bytes, of a specified stream.</para>
	/// </summary>
	/// <param name="pstm">
	/// <para>Type: <c>IStream*</c></para>
	/// <para>A pointer to the IStream interface of the stream whose size is to be determined.</para>
	/// </param>
	/// <param name="pui">
	/// <para>Type: <c>ULARGE_INTEGER*</c></para>
	/// <para>A pointer to a ULARGE_INTEGER structure to receive the size of the stream.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// Returns <c>S_OK</c> on success or a COM failure code otherwise. See IStream::Stat for further discussion of possible error codes.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function gets the size of the stream by calling the specified stream object's IStream::Stat method. It then copies the value
	/// of the <c>cbSize</c> member of the STATSTG structure returned by <c>IStream::Stat</c> to the ULARGE_INTEGER structure pointed to
	/// by pui. If the function fails, the contents of the <c>ULARGE_INTEGER</c> structure are undefined.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-istream_size LWSTDAPI IStream_Size( IStream *pstm,
	// ULARGE_INTEGER *pui );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "93c7c24d-6431-4859-b0b8-b36392bc5108")]
	public static extern HRESULT IStream_Size(IStream pstm, out ulong pui);

	/// <summary>
	/// <para>Writes data of unknown format from a buffer to a specified stream.</para>
	/// </summary>
	/// <param name="pstm">
	/// <para>Type: <c>IStream*</c></para>
	/// <para>An IStream pointer that specifies the target stream.</para>
	/// </param>
	/// <param name="pv">
	/// <para>Type: <c>const void*</c></para>
	/// <para>Pointer to a buffer that holds the data to send to the target stream. This buffer must be at least cb bytes in size.</para>
	/// </param>
	/// <param name="cb">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>The number of bytes of data to write to the target stream.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// Returns S_OK if the function successfully wrote the specified number of bytes to the stream, or an error value otherwise. In
	/// particular, if less than cb bytes was written to the target stream, even if some data was successfully written, the function
	/// returns E_FAIL.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-istream_write LWSTDAPI IStream_Write( IStream *pstm, const
	// void *pv, ULONG cb );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "fdcfdaf8-7fcb-433e-b3d4-98ca143fbe6b")]
	public static extern HRESULT IStream_Write(IStream pstm, IntPtr pv, uint cb);

	/// <summary>
	/// <para>Writes data of unknown format from a buffer to a specified stream.</para>
	/// </summary>
	/// <param name="pstm">
	/// <para>Type: <c>IStream*</c></para>
	/// <para>An IStream pointer that specifies the target stream.</para>
	/// </param>
	/// <param name="pv">
	/// <para>Type: <c>const void*</c></para>
	/// <para>Pointer to a buffer that holds the data to send to the target stream. This buffer must be at least cb bytes in size.</para>
	/// </param>
	/// <param name="cb">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>The number of bytes of data to write to the target stream.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// Returns S_OK if the function successfully wrote the specified number of bytes to the stream, or an error value otherwise. In
	/// particular, if less than cb bytes was written to the target stream, even if some data was successfully written, the function
	/// returns E_FAIL.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-istream_write LWSTDAPI IStream_Write( IStream *pstm, const
	// void *pv, ULONG cb );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "fdcfdaf8-7fcb-433e-b3d4-98ca143fbe6b")]
	public static extern HRESULT IStream_Write(IStream pstm, SafeAllocatedMemoryHandle pv, uint cb);

	/// <summary>
	/// <para>Writes a pointer to an item identifier list (PIDL) from a PCUIDLIST_RELATIVE object into an IStream object.</para>
	/// </summary>
	/// <param name="pstm">
	/// <para>Type: <c>IStream*</c></para>
	/// <para>A pointer to the IStream object in which to write.</para>
	/// </param>
	/// <param name="pidlWrite">
	/// <para>Type: <c>PCUIDLIST_RELATIVE</c></para>
	/// <para>The source PIDL.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-istream_writepidl LWSTDAPI IStream_WritePidl( IStream
	// *pstm, PCUIDLIST_RELATIVE pidlWrite );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "29b6a42b-08bd-4b5f-92ad-a6456e7a6f98")]
	public static extern HRESULT IStream_WritePidl(IStream pstm, IntPtr pidlWrite);

	/// <summary>
	/// <para>Reads from a string and writes into a stream.</para>
	/// </summary>
	/// <param name="pstm">
	/// <para>Type: <c>IStream*</c></para>
	/// <para>A pointer to the stream in which to write.</para>
	/// </param>
	/// <param name="psz">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>A pointer to a null-terminated, Unicode string from which to read.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-istream_writestr LWSTDAPI IStream_WriteStr( IStream *pstm,
	// PCWSTR psz );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "13292ccd-fc0c-4230-a935-4d5aed8cec97")]
	public static extern HRESULT IStream_WriteStr(IStream pstm, [MarshalAs(UnmanagedType.LPWStr)] string psz);

	/// <summary>
	/// <para>Releases a Component Object Model (COM) pointer and sets it to <c>NULL</c>.</para>
	/// </summary>
	/// <param name="ppunk">
	/// <para>Type: <c>void**</c></para>
	/// <para>The address of a pointer to a COM interface.</para>
	/// </param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If ppunk points to a <c>NULL</c> pointer, no operation is performed. Otherwise, ppunk is assumed to be the address of a COM
	/// interface pointer, derived from IUnknown. The function calls the interface's IUnknown::Release method then sets the interface
	/// pointer to <c>NULL</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example uses <c>IUnknown_AtomicRelease</c> to release the stream, if it exists. If not, it does nothing.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-iunknown_atomicrelease void IUnknown_AtomicRelease( void
	// **ppunk );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "6bb3f9cf-bf28-4f94-8557-56c1952384ec")]
	public static extern void IUnknown_AtomicRelease([MarshalAs(UnmanagedType.IUnknown)] out object? ppunk);

	/// <summary>Calls the specified object's IObjectWithSite::GetSite method.</summary>
	/// <param name="punk">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>A pointer to the COM object whose IObjectWithSite::GetSite method is to be called.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>The IID of the interface pointer that should be returned in ppvSite.</para>
	/// </param>
	/// <param name="ppv">TBD</param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns <c>S_OK</c> if the site was successfully retrieved or a COM error code otherwise.</para>
	/// </returns>
	/// <remarks>
	/// This function calls the specified object's QueryInterface method to obtain the IObjectWithSite interface. If successful, the function
	/// calls the interface's IObjectWithSite::GetSite method to obtain the site.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-iunknown_getsite LWSTDAPI IUnknown_GetSite( IUnknown
	// *punk, REFIID riid, void **ppv );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "95e83078-ab74-40d6-8e31-653e578770f2")]
	public static extern HRESULT IUnknown_GetSite([MarshalAs(UnmanagedType.IUnknown)] object punk, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppv);

	/// <summary>
	/// <para>
	/// Attempts to retrieve a window handle from a Component Object Model (COM) object by querying for various interfaces that have a
	/// <c>GetWindow</c> method.
	/// </para>
	/// </summary>
	/// <param name="punk">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>A pointer to the COM object from which this function will attempt to obtain a window handle.</para>
	/// </param>
	/// <param name="phwnd">
	/// <para>Type: <c>HWND*</c></para>
	/// <para>
	/// A pointer to a HWND that, when this function returns successfully, receives the window handle. If a window handle was not
	/// obtained, this parameter is set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// Returns S_OK if a window handle was successfully returned, or a COM error code otherwise. If no suitable interface was found, the
	/// function returns E_NOINTERFACE. Otherwise, the function returns the <c>HRESULT</c> returned by the corresponding interface's
	/// <c>GetWindow</c> method.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function attempts to retrieve the window handle by calling IOleWindow::GetWindow, IInternetSecurityMgrSite::GetWindow, and
	/// IShellView::GetWindow. It is possible that future versions of <c>IUnknown_GetWindow</c> may attempt additional interfaces.
	/// </para>
	/// <para>
	/// <c>Note</c> The query for IShellView is theoretically unnecessary because <c>IShellView</c> derives from IOleWindow. The function
	/// explicitly queries for this interface because some objects implement QueryInterface incorrectly and fail to respond to a query
	/// for the base interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-iunknown_getwindow LWSTDAPI IUnknown_GetWindow( IUnknown
	// *punk, HWND *phwnd );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "f8a6f61f-bea3-4049-89fb-c33ef00b327f")]
	public static extern HRESULT IUnknown_GetWindow([MarshalAs(UnmanagedType.IUnknown)] object punk, out HWND phwnd);

	/// <summary>
	/// <para>Retrieves an interface for a service from a specified object.</para>
	/// </summary>
	/// <param name="punk">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>A pointer to the IUnknown instance of the COM object that supports the service.</para>
	/// </param>
	/// <param name="guidService">
	/// <para>Type: <c>REFGUID</c></para>
	/// <para>The service's unique identifier (SID).</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>The IID of the desired service interface.</para>
	/// </param>
	/// <param name="ppvOut">
	/// <para>Type: <c>void**</c></para>
	/// <para>
	/// When this method returns, contains the interface pointer requested riid. If successful, the calling application is responsible
	/// for calling IUnknown::Release using this value when the service is no longer needed. In the case of failure, this value is <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// Returns <c>S_OK</c> if successful. Returns <c>E_FAIL</c> if the object does not support IServiceProvider. Otherwise, the function
	/// returns the <c>HRESULT</c> returned by the object's QueryService method.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the object passed in the punk parameter supports the IServiceProvider interface, then its QueryService method is invoked,
	/// passing the guidService, riid, and ppvOut parameters and propagating the return value. Otherwise, the function returns E_FAIL.
	/// </para>
	/// <para>
	/// For those versions of Windows that do not include <c>IUnknown_QueryService</c> in Shlwapi.h, this function must be called
	/// directly from Shlwapi.dll using ordinal 176.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-iunknown_queryservice LWSTDAPI IUnknown_QueryService(
	// IUnknown *punk, REFGUID guidService, REFIID riid, void **ppvOut );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "3e3f3ed0-ad36-40ef-b30c-8c85ff159f21")]
	public static extern HRESULT IUnknown_QueryService([MarshalAs(UnmanagedType.IUnknown)] object punk, in Guid guidService, in Guid riid,
		[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppvOut);

	/// <summary>Retrieves an interface for a service from a specified object.</summary>
	/// <typeparam name="TOut">The type of the desired service interface.</typeparam>
	/// <param name="punk"><para>Type: <c>IUnknown*</c></para>
	/// <para>A pointer to the IUnknown instance of the COM object that supports the service.</para></param>
	/// <param name="guidService"><para>Type: <c>REFGUID</c></para>
	/// <para>The service's unique identifier (SID).</para></param>
	/// <param name="riid"><para>Type: <c>Guid?</c></para>
	/// <para>The IID of the desired service interface. If <see langword="null" />, the Guid of the <typeparamref name="TOut" /> type is used.</para></param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// When this method returns, contains the interface pointer requested riid. If successful, the calling application is responsible
	/// for calling IUnknown::Release using this value when the service is no longer needed. In the case of failure, this value is <c>NULL</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the object passed in the punk parameter supports the IServiceProvider interface, then its QueryService method is invoked,
	/// passing the guidService, riid, and ppvOut parameters and propagating the return value. Otherwise, the function returns E_FAIL.
	/// </para>
	/// <para>
	/// For those versions of Windows that do not include <c>IUnknown_QueryService</c> in Shlwapi.h, this function must be called
	/// directly from Shlwapi.dll using ordinal 176.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-iunknown_queryservice LWSTDAPI IUnknown_QueryService(
	// IUnknown *punk, REFGUID guidService, REFIID riid, void **ppvOut );
	[PInvokeData("shlwapi.h", MSDNShortId = "3e3f3ed0-ad36-40ef-b30c-8c85ff159f21")]
	[return: MarshalAs(UnmanagedType.Interface)]
	public static TOut? IUnknown_QueryService<TOut>([MarshalAs(UnmanagedType.IUnknown)] object punk, in Guid guidService, in Guid? riid = null) where TOut : class
	{
		var iid = riid ?? typeof(TOut).GUID;
		IUnknown_QueryService(punk, guidService, iid, out object? ppvOut).ThrowIfFailed();
		return (TOut?)ppvOut;
	}

	/// <summary>
	/// <para>Changes the value of a Component Object Model (COM) interface pointer and releases the previous interface.</para>
	/// </summary>
	/// <param name="ppunk">
	/// <para>Type: <c>IUnknown**</c></para>
	/// <para>
	/// The address of a COM interface pointer to receive the pointer assigned to punk. If the previous value of the pointer is non-
	/// <c>NULL</c>, the function releases that interface by calling its IUnkown::Release method.
	/// </para>
	/// </param>
	/// <param name="punk">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>
	/// The interface pointer to be copied to ppunk. If the value is non- <c>NULL</c>, the function increments the interface's reference count.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function mimics the behavior of a smart pointer. Conceptually, the function does the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Releases the original interface, if ppunk is non- <c>NULL</c></term>
	/// </item>
	/// <item>
	/// <term>Assigns punk to ppunk</term>
	/// </item>
	/// <item>
	/// <term>Calls IUnknown::AddRef on the interface pointed to by punk, if punk is non- <c>NULL</c>.</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-iunknown_set void IUnknown_Set( IUnknown **ppunk, IUnknown
	// *punk );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "b3c4bee2-12cb-483e-9a46-f09d63ae9a2e")]
	public static extern void IUnknown_Set([MarshalAs(UnmanagedType.IUnknown)] ref object? ppunk, [In, MarshalAs(UnmanagedType.IUnknown)] object? punk);

	/// <summary>
	/// <para>Sets the specified object's site by calling its IObjectWithSite::SetSite method.</para>
	/// </summary>
	/// <param name="punk">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>A pointer to the IUnknown interface of the object whose site is to be changed.</para>
	/// </param>
	/// <param name="punkSite">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>A pointer to the IUnknown interface of the new site.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns S_OK if the site was successfully set, or a COM error code otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function calls the specified object's IUnknown::QueryInterface method to obtain a pointer to the object's IObjectWithSite
	/// interface. If successful, the function calls IObjectWithSite::SetSite to set or change the site.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-iunknown_setsite LWSTDAPI IUnknown_SetSite( IUnknown
	// *punk, IUnknown *punkSite );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "66175435-f85b-4e26-b148-f4edb74cb41d")]
	public static extern HRESULT IUnknown_SetSite([In, MarshalAs(UnmanagedType.IUnknown)] object punk, [In, MarshalAs(UnmanagedType.IUnknown)] object punkSite);

	/// <summary>
	/// <para>[This function is not available for use as of Windows 7.]</para>
	/// <para>Maps an appropriate resource DLL into the address space of the calling function, based on the user's default UI language.</para>
	/// </summary>
	/// <param name="lpszLibFileName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A <c>null</c>-terminated string with the file name of the resource DLL to be loaded. Do not include any path information.
	/// <c>MLLoadLibrary</c> derives that information as described in the Remarks below.
	/// </para>
	/// </param>
	/// <param name="hModule">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// A handle to an already-loaded DLL that represents the code library for which the multilingual resource library is being requested.
	/// </para>
	/// </param>
	/// <param name="dwCrossCodePage">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Reserved. This parameter must be set to zero.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HINSTANCE</c></para>
	/// <para>Returns the module's handle if successful, or <c>NULL</c> otherwise.</para>
	/// </returns>
	// HINSTANCE MLLoadLibrary( _In_ LPCTSTR lpszLibFileName, _In_ HMODULE hModule, _In_ DWORD dwCrossCodePage); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773822(v=vs.85).aspx
	[DllImport(Lib.Shlwapi, CharSet = CharSet.Auto)]
	[PInvokeData("Shlwapi.h", MSDNShortId = "bb773822")]
	[Obsolete]
	public static extern HINSTANCE MLLoadLibrary(string lpszLibFileName, HINSTANCE hModule, uint dwCrossCodePage = 0);

	/// <summary>
	/// <para>A table-driven implementation of the IUnknown::QueryInterface method.</para>
	/// </summary>
	/// <param name="that">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to the base of a COM object.</para>
	/// </param>
	/// <param name="pqit">
	/// <para>Type: <c>LPCQITAB</c></para>
	/// <para>
	/// An array of QITAB structures. The last structure in the array must have its <c>piid</c> member set to <c>NULL</c> and its
	/// <c>dwOffset</c> member set to 0.
	/// </para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>A reference to the IID of the interface to retrieve through ppv.</para>
	/// </param>
	/// <param name="ppv">
	/// <para>Type: <c>void**</c></para>
	/// <para>When this method returns successfully, contains the interface pointer requested in riid.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// Returns S_OK if the requested interface was found in the table or if the requested interface was IUnknown. Returns E_NOINTERFACE
	/// if the requested interface was not found.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> Prior to Windows Vista, <c>QISearch</c> was not exported by name or declared in a public header file. To use it in
	/// those cases, you must use GetProcAddress and request ordinal 219 from Shlwapi.dll to obtain a function pointer. Under Windows
	/// Vista, <c>QISearch</c> is included in Shlwapi.h and this is not necessary.
	/// </para>
	/// <para>
	/// If the requested interface is IUnknown, then <c>QISearch</c> uses the first entry of the specified array of QITAB structures.
	/// Otherwise, <c>QISearch</c> searches the table until it either finds a matching IID or reaches the end of the table. If a matching
	/// IID is found, the function advances the associated interface pointer by the number of bytes specified by the <c>dwOffset</c>
	/// member of the interface's <c>QITAB</c> structure and reinterpreted as a COM pointer. That pointer is assigned to the
	/// <c>QISearch</c> function's ppv parameter. The method also calls IUnknown::AddRef to increment the interface's reference count.
	/// </para>
	/// <para>
	/// If <c>QISearch</c> reaches the end of the table without finding the interface, it returns E_NOINTERFACE and sets ppv to <c>NULL</c>.
	/// </para>
	/// <para>
	/// It is important to include all applicable interfaces in the table. For example, if the object implements a derived interface, you
	/// should also include the base interface in the table.
	/// </para>
	/// <para>
	/// We recommend that you use the IID_PPV_ARGS macro, defined in Objbase.h, to package the riid and ppv parameters. This macro
	/// provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a coding
	/// error in riid that could lead to unexpected results.
	/// </para>
	/// <para>
	/// <c>Note</c> Active Template Library (ATL) provides a significantly better version of a table-driven implementation of QueryInterface.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example illustrates how to use <c>QISearch</c> to implement QueryInterface. It uses the offsetofclass macro from
	/// ATL to compute the offset from the base of the CSample object to a specified interface.
	/// </para>
	/// <para>
	/// This object supports two interfaces aside from IUnknown, so there are two non- <c>NULL</c> entries in the QITAB table. The entry
	/// for each interface specifies a pointer to the associated IID (IID_IPersist or IID_IPersistFolder) and the offset of the interface
	/// pointer relative to the class's base pointer. The sample uses the <c>offsetofclass</c> macro from ATL to determine that offset.
	/// </para>
	/// <para>
	/// <c>Note</c> Forgetting to include all base classes, including indirect ones, is a common error. Notice that there is an entry for
	/// the IPersist interface. This interface is an indirect base class for CSample, inherited through IPersistFolder.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-qisearch HRESULT QISearch( void *that, LPCQITAB pqit,
	// REFIID riid, void **ppv );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "8429778b-bc9c-43f6-8d75-0fb78e36e790")]
	public static extern HRESULT QISearch(IntPtr that, QITAB[] pqit, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppv);

	/// <summary>
	/// <para>
	/// [ <c>SHAllocShared</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Allocates a handle in a specified process to a copy of a specified memory block in the calling process.</para>
	/// </summary>
	/// <param name="pvData">
	/// <para>Type: <c>const void*</c></para>
	/// <para>
	/// A pointer to the memory block in the calling process that is to be copied. You can set this parameter to <c>NULL</c> if you want
	/// to share a block of memory without copying any data to it.
	/// </para>
	/// </param>
	/// <param name="dwSize">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The size, in bytes, of the memory block pointed to by pvData.</para>
	/// </param>
	/// <param name="dwProcessId">
	/// <para>TBD</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Returns a handle to the shared memory for the process specified by dwDestinationProcessId. Returns <c>NULL</c> if unsuccessful.</para>
	/// </returns>
	/// <remarks>
	/// <para>Use SHFreeShared to free the handle when you are finished.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shallocshared HANDLE SHAllocShared( const void *pvData,
	// DWORD dwSize, DWORD dwProcessId );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "0388b6a0-24d9-48eb-bef2-3a1658d8bb3c")]
	public static extern IntPtr SHAllocShared([Optional] IntPtr pvData, uint dwSize, uint dwProcessId);

	/// <summary>
	/// <para>
	/// [This function is available through Windows XP and Windows Server 2003. It might be altered or unavailable in subsequent versions
	/// of Windows.]
	/// </para>
	/// <para>Copies an ANSI string.</para>
	/// </summary>
	/// <param name="pszSrc">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>A pointer to a null-terminated ANSI string to be converted to Unicode.</para>
	/// </param>
	/// <param name="pszDst">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>
	/// A pointer to a buffer that, when this function returns successfully, receives the characters copied from pszSrc. The buffer must
	/// be large enough to contain the number of characters specified by the cchBuf parameter, including a room for a terminating null character.
	/// </para>
	/// </param>
	/// <param name="cchBuf">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The number of characters that can be contained by the buffer pointed to by pszDst. This parameter must be greater than zero.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>Returns the number of characters written to pszDst, including the terminating null character. Returns 0 if unsuccessful.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Security Warning:</c> Using this function incorrectly can compromise the security of your application. For example, if pszDst
	/// buffer is not large enough to contain the number of characters specified by cchBuf, a buffer overrun can occur. Buffer overruns
	/// can cause a denial of service attack against an application if an access violation occurs. In the worst case, a buffer overrun
	/// might allow an attacker to inject executable code into your process, especially if pszDst is a stack-based buffer. Note that the
	/// output string is silently truncated if the buffer is not large enough. This can result in canonicalization or other security vulnerabilities.
	/// </para>
	/// <para>
	/// If the pszDst buffer is not large enough to contain the entire converted output string, the string is truncated to fit the
	/// buffer. There is no way to detect that the return string has been truncated. The string will always be null-terminated, even if
	/// it has been truncated. This function takes care to not truncate between the lead and trail bytes of a DBCS character pair. In
	/// that case, only cchBuf-1 characters are returned.
	/// </para>
	/// <para>If the pszSrc and pszDst buffers overlap, the function's behavior is undefined.</para>
	/// <para>
	/// <c>Note</c> Do not assume that the function has not changed any of the characters in the output buffer that follow the string's
	/// terminating null character. The contents of the output buffer following the string's terminating null character are undefined, up
	/// to and including the last character in the buffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shansitoansi int SHAnsiToAnsi( PCSTR pszSrc, PSTR pszDst,
	// int cchBuf );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("shlwapi.h", MSDNShortId = "e57142ca-3098-4118-aac0-89724f711872")]
	public static extern int SHAnsiToAnsi(string pszSrc, StringBuilder pszDst, int cchBuf);

	/// <summary>
	/// <para>
	/// [This function is available through Windows XP and Windows Server 2003. It might be altered or unavailable in subsequent versions
	/// of Windows.]
	/// </para>
	/// <para>Converts a string from the ANSI code page to the Unicode code page.</para>
	/// </summary>
	/// <param name="pszSrc">
	/// <para>Type: <c>PCSTR</c></para>
	/// <para>A pointer to a null-terminated ANSI string to be converted to Unicode.</para>
	/// </param>
	/// <param name="pwszDst">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>
	/// A pointer to a buffer that, when this function returns successfully, receives the string specified by pszSrc, after the ANSI
	/// characters have been converted to Unicode (WCHAR). The buffer must be large enough to contain the number of Unicode characters
	/// specified by the cwchBuf parameter, including a terminating null character.
	/// </para>
	/// </param>
	/// <param name="cwchBuf">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The number of Unicode characters that can be contained by the buffer pointed to by pwszDst. This parameter must be greater than zero.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>Returns the number of Unicode characters written to pwszDst, including the terminating null character. Returns 0 if unsuccessful.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Security Warning:</c> Using this function incorrectly can compromise the security of your application. For example, if pwszDst
	/// buffer is not large enough to contain the number of characters specified by cwchBuf, a buffer overrun can occur. Buffer overruns
	/// can cause a denial of service attack against an application if an access violation occurs. In the worst case, a buffer overrun
	/// might allow an attacker to inject executable code into your process, especially if pwszDst is a stack-based buffer. When copying
	/// an entire string, note that sizeof returns the number of bytes, which is not the correct value to use for the cwchBuf parameter.
	/// Instead, use sizeof(pwszDst)/sizeof(WCHAR). Note that this technique assumes that pwszDst is an array, not a pointer.
	/// </para>
	/// <para>
	/// If the pwszDst buffer is not large enough to contain the entire converted output string, the string is truncated to fit the
	/// buffer. There is no way to detect that the return string has been truncated. The string is always null-terminated, even if it has
	/// been truncated. This ensures that no more than cwchBuf characters are copied to pwszDst. No attempt is made to avoid truncating
	/// the string in the middle of a Unicode surrogate pair.
	/// </para>
	/// <para>If the pszSrc and pwszDst buffers overlap, the function's behavior is undefined.</para>
	/// <para>
	/// <c>Note</c> Do not assume that the function has not changed any of the characters in the output buffer that follow the string's
	/// terminating null character. The contents of the output buffer following the string's terminating null character are undefined, up
	/// to and including the last character in the buffer.
	/// </para>
	/// <para><c>SHAnsiToTChar</c> is defined to be the same as <c>SHAnsiToUnicode</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shansitounicode int SHAnsiToUnicode( PCSTR pszSrc, PWSTR
	// pwszDst, int cwchBuf );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "9578f26e-56ea-4f3b-b024-b2e285d0c4d2")]
	public static extern int SHAnsiToUnicode([MarshalAs(UnmanagedType.LPStr)] string pszSrc, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszDst, int cwchBuf);

	/// <summary>
	/// <para>Instructs system edit controls to use AutoComplete to help complete URLs or file system paths.</para>
	/// </summary>
	/// <param name="hwndEdit">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// The window handle of a system edit control. Typically, this parameter is the handle of an edit control or the edit control
	/// embedded in a ComboBoxEx control.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The flags to control the operation of <c>SHAutoComplete</c>. The first four flags are used to override the Internet Explorer
	/// registry settings. The user can change these settings manually by launching the <c>Internet Options</c> property sheet from the
	/// <c>Tools</c> menu and clicking the <c>Advanced</c> tab.
	/// </para>
	/// <para>SHACF_AUTOAPPEND_FORCE_OFF (0x80000000)</para>
	/// <para>
	/// Ignore the registry default and force the AutoAppend feature off. This flag must be used in combination with one or more of the
	/// SHACF_FILESYS* or SHACF_URL* flags.
	/// </para>
	/// <para>SHACF_AUTOAPPEND_FORCE_ON (0x40000000)</para>
	/// <para>
	/// Ignore the registry value and force the AutoAppend feature on. The completed string will be displayed in the edit box with the
	/// added characters highlighted. This flag must be used in combination with one or more of the SHACF_FILESYS* or SHACF_URL* flags.
	/// </para>
	/// <para>SHACF_AUTOSUGGEST_FORCE_OFF (0x20000000)</para>
	/// <para>
	/// Ignore the registry default and force the AutoSuggest feature off. This flag must be used in combination with one or more of the
	/// SHACF_FILESYS* or SHACF_URL* flags.
	/// </para>
	/// <para>SHACF_AUTOSUGGEST_FORCE_ON (0x10000000)</para>
	/// <para>
	/// Ignore the registry value and force the AutoSuggest feature on. A selection of possible completed strings will be displayed as a
	/// drop-down list, below the edit box. This flag must be used in combination with one or more of the SHACF_FILESYS* or SHACF_URL* flags.
	/// </para>
	/// <para>SHACF_DEFAULT (0x00000000)</para>
	/// <para>
	/// The default setting, equivalent to <c>SHACF_FILESYSTEM</c> | <c>SHACF_URLALL</c>. <c>SHACF_DEFAULT</c> cannot be combined with
	/// any other flags.
	/// </para>
	/// <para>SHACF_FILESYS_ONLY (0x00000010)</para>
	/// <para>Include the file system only.</para>
	/// <para>SHACF_FILESYS_DIRS (0x00000020)</para>
	/// <para>Include the file system and directories, UNC servers, and UNC server shares.</para>
	/// <para>SHACF_FILESYSTEM (0x00000001)</para>
	/// <para>Include the file system and the rest of the Shell (Desktop, Computer, and Control Panel, for example).</para>
	/// <para>SHACF_URLALL (SHACF_URLHISTORY | SHACF_URLMRU)</para>
	/// <para>Include the URLs in the users <c>History</c> and <c>Recently Used</c> lists. Equivalent to <c>SHACF_URLHISTORY</c> | <c>SHACF_URLMRU</c>.</para>
	/// <para>SHACF_URLHISTORY (0x00000002)</para>
	/// <para>Include the URLs in the user's <c>History</c> list.</para>
	/// <para>SHACF_URLMRU (0x00000004)</para>
	/// <para>Include the URLs in the user's <c>Recently Used</c> list.</para>
	/// <para>SHACF_USETAB (0x00000008)</para>
	/// <para>
	/// Allow the user to select from the autosuggest list by pressing the TAB key. If this flag is not set, pressing the TAB key will
	/// shift focus to the next control and close the autosuggest list. If <c>SHACF_USETAB</c> is set, pressing the TAB key will select
	/// the first item in the list. Pressing TAB again will select the next item in the list, and so on. When the user reaches the end of
	/// the list, the next TAB key press will cycle the focus back to the edit control. This flag must be used in combination with one or
	/// more of the SHACF_FILESYS* or SHACF_URL* flags listed on this page.
	/// </para>
	/// <para>SHACF_VIRTUAL_NAMESPACE (0x00000040)</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SHAutoComplete</c> works on any system edit control, including the edit control and controls that contain edit controls such
	/// as ComboBoxEx controls. To retrieve a handle to an edit control embedded in a ComboBoxEx control, send the ComboBoxEx control a
	/// CBEM_GETEDITCONTROL message.
	/// </para>
	/// <para>
	/// An application must have invoked either CoInitialize or OleInitialize prior to calling this function. CoUninitialize or
	/// OleUninitialize cannot be called until the edit box has finished processing the WM_DESTROY message for hwndEdit.
	/// </para>
	/// <para>The maximum number of items that can be displayed in an autosuggest drop-down list box is 1000.</para>
	/// <para>
	/// On versions of Windows prior to Windows Vista and server versions prior to Windows Server 2008, <c>SHAutoComplete</c> should not
	/// be called more than once with the same <c>HWND</c>. Doing so results in a memory leak. It prevents the original resources from
	/// being released, including the previous instance of the AutoComplete object, enumerator objects that the previous AutoComplete
	/// object has referenced, and Windows Graphics Device Interface (GDI) resources. Rather than call <c>SHAutoComplete</c> again with a
	/// different set of flags to change the AutoComplete list, call CoCreateInstance with CLSID_AutoComplete to obtain the AutoComplete
	/// object. Then pass the <c>HWND</c> to the object to initialize it and provide your own custom enumerator. You can use
	/// CLSID_ACLMulti if you want AutoComplete to use multiple lists.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shautocomplete LWSTDAPI SHAutoComplete( HWND hwndEdit,
	// DWORD dwFlags );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "b47efa8d-2118-4805-bb04-97bd143228dc")]
	public static extern HRESULT SHAutoComplete(HWND hwndEdit, SHACF dwFlags);

	/// <summary>
	/// <para>
	/// Recursively copies the subkeys and values of the source subkey to the destination key. <c>SHCopyKey</c> does not copy the
	/// security attributes of the keys.
	/// </para>
	/// </summary>
	/// <param name="hkeySrc">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to the source key (for example, <c>HKEY_CURRENT_USER</c>).</para>
	/// </param>
	/// <param name="pszSrcSubKey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The subkey whose subkeys and values are to be copied.</para>
	/// </param>
	/// <param name="hkeyDest">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>The destination key.</para>
	/// </param>
	/// <param name="fReserved">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Reserved. Must be 0.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or one of the nonzero error codes defined in Winerror.h otherwise. Use FormatMessage with
	/// the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Important</c> This function does not duplicate the security attributes of the keys and values that it copies. Rather, all
	/// security attributes in the destination key are the default attributes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shcopykeya LSTATUS SHCopyKeyA( HKEY hkeySrc, LPCSTR
	// pszSrcSubKey, HKEY hkeyDest, DWORD fReserved );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "52521ef4-fe59-4766-8828-acb557b0e968")]
	public static extern Win32Error SHCopyKey(HKEY hkeySrc, string pszSrcSubKey, HKEY hkeyDest, uint fReserved = 0);

	/// <summary>
	/// <para>Creates a memory stream using a similar process to CreateStreamOnHGlobal.</para>
	/// </summary>
	/// <param name="pInit">
	/// <para>Type: <c>const BYTE*</c></para>
	/// <para>
	/// A pointer to a buffer of size cbInit. The contents of this buffer are used to set the initial contents of the memory stream. If
	/// this parameter is <c>NULL</c>, the returned memory stream does not have any initial content.
	/// </para>
	/// </param>
	/// <param name="cbInit">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of bytes in the buffer pointed to by pInit. If pInit is set to <c>NULL</c>, cbInit must be zero.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>IStream*</c></para>
	/// <para>On success, returns a pointer to the created memory stream. Returns <c>NULL</c> if the stream object could not be allocated.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Prior to Windows Vista, this function was not included in the public Shlwapi.h file, nor was it exported by name from
	/// Shlwapi.dll. To use it on earlier systems, you must call it directly from the Shlwapi.dll file as ordinal 12.
	/// </para>
	/// <para>
	/// This function creates a memory stream. This is an implementation of the IStream interface that stores its contents in memory.
	/// <c>SHCreateMemStream</c> differs from CreateStreamOnHGlobal in the following ways.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Thread safety. The stream created by <c>SHCreateMemStream</c> is thread-safe as of Windows 8. On earlier systems, the stream is
	/// not thread-safe. The stream created by CreateStreamOnHGlobal is thread-safe.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Initial contents. <c>SHCreateMemStream</c> accepts the initial contents in the form of a buffer. CreateStreamOnHGlobal accepts
	/// the initial contents in the form of an HGLOBAL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Access to contents. <c>SHCreateMemStream</c> does not allow direct access to the stream contents. CreateStreamOnHGlobal permits
	/// access through GetHGlobalFromStream.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Failure information. If <c>SHCreateMemStream</c> returns <c>NULL</c>, it was unable to allocate the neccessary memory. Callers
	/// should assume the cause is E_OUTOFMEMORY.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Support for IStream::Clone. Prior to Windows 8, the stream created by <c>SHCreateMemStream</c> does not support
	/// <c>IStream::Clone</c>. The stream created by CreateStreamOnHGlobal does. As of Windows 8, the stream created by
	/// <c>SHCreateMemStream</c> does support <c>IStream::Clone</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The stream returned by <c>SHCreateMemStream</c> returns S_FALSE from IStream::Read if you attempt to read past the end of the
	/// buffer. The stream returned by CreateStreamOnHGlobal returns S_OK and sets *pcbRead to 0 if you attempt to read past the end of
	/// the buffer.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shcreatememstream IStream * SHCreateMemStream( const BYTE
	// *pInit, UINT cbInit );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "f3ae8241-f3a6-4007-a10f-ff05960c5de8")]
	public static extern IStream? SHCreateMemStream([Optional] IntPtr pInit, [Optional] uint cbInit);

	/// <summary>
	/// <para>Creates a halftone palette for the specified device context.</para>
	/// </summary>
	/// <param name="hdc">
	/// <para>Type: <c>HDC</c></para>
	/// <para>The device context.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HPALETTE</c></para>
	/// <para>Returns the palette if successful; otherwise 0.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function behaves the same as CreateHalftonePalette. The palette that is returned depends on the device context in the
	/// following way:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>If hdc is set to <c>NULL</c>, a full palette is returned.</term>
	/// </item>
	/// <item>
	/// <term>If the device context is indexed, a full palette is returned.</term>
	/// </item>
	/// <item>
	/// <term>If the device context is not indexed, a default palette (VGA colors) is returned.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shcreateshellpalette HPALETTE SHCreateShellPalette( HDC
	// hdc );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "49afb04a-34e3-4696-a046-bc9308ae7adf")]
	public static extern HPALETTE SHCreateShellPalette([Optional] HDC hdc);

	/// <summary>
	/// <para>
	/// [ <c>SHCreateStreamOnFile</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions. Instead, use SHCreateStreamOnFileEx.]
	/// </para>
	/// <para>Opens or creates a file and retrieves a stream to read or write to that file.</para>
	/// </summary>
	/// <param name="pszFile">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to a null-terminated string that specifies the file name.</para>
	/// </param>
	/// <param name="grfMode">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// One or more STGM values that are used to specify the file access mode and how the object that exposes the stream is created and deleted.
	/// </para>
	/// </param>
	/// <param name="ppstm">
	/// <para>Type: <c>IStream**</c></para>
	/// <para>Receives an IStream interface pointer for the stream associated with the file.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// SHCreateStreamOnFileEx fully supports all STGM modes and allows the caller to specify file attributes if creating a new file.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shcreatestreamonfilea LWSTDAPI SHCreateStreamOnFileA(
	// LPCSTR pszFile, DWORD grfMode, IStream **ppstm );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "9b1fd6c4-d7b0-40b9-bc9f-ea062a1079c1")]
	public static extern HRESULT SHCreateStreamOnFile(string pszFile, STGM grfMode, out IStream ppstm);

	/// <summary>
	/// <para>Opens or creates a file and retrieves a stream to read or write to that file.</para>
	/// </summary>
	/// <param name="pszFile">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>A pointer to a null-terminated string that specifies the file name.</para>
	/// </param>
	/// <param name="grfMode">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// One or more STGM values that are used to specify the file access mode and how the object that exposes the stream is created and deleted.
	/// </para>
	/// </param>
	/// <param name="dwAttributes">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// One or more flag values that specify file attributes in the case that a new file is created. For a complete list of possible
	/// values, see the dwFlagsAndAttributes parameter of the CreateFile function.
	/// </para>
	/// </param>
	/// <param name="fCreate">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// A <c>BOOL</c> value that helps specify, in conjunction with grfMode, how existing files should be treated when creating the
	/// stream. See Remarks for details.
	/// </para>
	/// </param>
	/// <param name="pstmTemplate">
	/// <para>Type: <c>IStream*</c></para>
	/// <para>Reserved.</para>
	/// </param>
	/// <param name="ppstm">
	/// <para>Type: <c>IStream**</c></para>
	/// <para>Receives an IStream interface pointer for the stream associated with the file.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SHCreateStreamOnFileEx</c> function extends the semantics of the STGM flags and produces the same effect as calling the
	/// CreateFile function.
	/// </para>
	/// <para>The grfMode and fCreate parameters work together to specify how the function should behave with respect to existing files.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>grfMode</term>
	/// <term>fCreate</term>
	/// <term>File exists?</term>
	/// <term>Behavior</term>
	/// </listheader>
	/// <item>
	/// <term>STGM_CREATE</term>
	/// <term>Ignored</term>
	/// <term>Yes</term>
	/// <term>The file is recreated.</term>
	/// </item>
	/// <item>
	/// <term>STGM_CREATE</term>
	/// <term>Ignored</term>
	/// <term>No</term>
	/// <term>The file is created.</term>
	/// </item>
	/// <item>
	/// <term>STGM_FAILIFTHERE</term>
	/// <term>FALSE</term>
	/// <term>Yes</term>
	/// <term>The file is opened.</term>
	/// </item>
	/// <item>
	/// <term>STGM_FAILIFTHERE</term>
	/// <term>FALSE</term>
	/// <term>No</term>
	/// <term>The call fails.</term>
	/// </item>
	/// <item>
	/// <term>STGM_FAILIFTHERE</term>
	/// <term>TRUE</term>
	/// <term>Yes</term>
	/// <term>The call fails.</term>
	/// </item>
	/// <item>
	/// <term>STGM_FAILIFTHERE</term>
	/// <term>TRUE</term>
	/// <term>No</term>
	/// <term>The file is created.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shcreatestreamonfileex LWSTDAPI SHCreateStreamOnFileEx(
	// LPCWSTR pszFile, DWORD grfMode, DWORD dwAttributes, BOOL fCreate, IStream *pstmTemplate, IStream **ppstm );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "f948f7dd-987d-4c2d-b650-62081133c3f4")]
	public static extern HRESULT SHCreateStreamOnFileEx(string pszFile, STGM grfMode, FileFlagsAndAttributes dwAttributes,
		[MarshalAs(UnmanagedType.Bool)] bool fCreate, [Optional] IStream? pstmTemplate, out IStream ppstm);

	/// <summary>
	/// <para>Creates a thread.</para>
	/// </summary>
	/// <param name="pfnThreadProc">
	/// <para>Type: <c>LPTHREAD_START_ROUTINE</c></para>
	/// <para>
	/// A pointer to an application-defined function of the LPTHREAD_START_ROUTINE type. If a new thread was successfully created, this
	/// application-defined function is called in the context of that thread. <c>SHCreateThread</c> does not wait for the function
	/// pointed to by this parameter to complete before returning to its caller. The application-defined function's return value is the
	/// exit code of the thread.
	/// </para>
	/// </param>
	/// <param name="pData">
	/// <para>Type: <c>void*</c></para>
	/// <para>
	/// A pointer to an optional application-defined data structure that contains initialization data. It is passed to the function
	/// pointed to by pfnThreadProc and, optionally, pfnCallback. This value can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="flags">
	/// <para>TBD</para>
	/// </param>
	/// <param name="pfnCallback">
	/// <para>Type: <c>LPTHREAD_START_ROUTINE</c></para>
	/// <para>
	/// A pointer to an optional application-defined function of the LPTHREAD_START_ROUTINE type. This function is called in the context
	/// of the created thread before the function pointed to by pfnThreadProc is called. It will also receive pData as its argument.
	/// <c>SHCreateThread</c> will wait for the function pointed to by pfnCallback to return before returning to its caller. The return
	/// value of the function pointed to by pfnCallback is ignored.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// Returns <c>TRUE</c> if the thread is successfully created, or <c>FALSE</c> otherwise. On failure, use GetLastError to retrieve
	/// the specific error value as shown here.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The function pointed to by pfnThreadProc and pfnCallback must take the following form.</para>
	/// <para>
	/// The function name is arbitrary. The pData parameter points to an application-defined data structure with initialization information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shcreatethread BOOL SHCreateThread( LPTHREAD_START_ROUTINE
	// pfnThreadProc, void *pData, SHCT_FLAGS flags, LPTHREAD_START_ROUTINE pfnCallback );
	[DllImport(Lib.Shlwapi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "2140e396-29cd-4665-b684-337170570b73")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SHCreateThread(ThreadProc pfnThreadProc, [Optional] IntPtr pData, SHCT_FLAGS flags, [Optional] ThreadProc? pfnCallback);

	/// <summary>
	/// <para>Creates a per-thread reference to a Component Object Model (COM) object.</para>
	/// </summary>
	/// <param name="pcRef">
	/// <para>Type: <c>LONG*</c></para>
	/// <para>
	/// A pointer to a value, usually a local variable in the thread's ThreadProc, that is used by the interface in ppunk as a reference counter.
	/// </para>
	/// </param>
	/// <param name="ppunk">
	/// <para>Type: <c>IUnknown**</c></para>
	/// <para>
	/// The address of a pointer to an IUnknown interface. If successful, this parameter holds the thread's <c>IUnknown</c> pointer on
	/// return. Your application is responsible for freeing the pointer when it is finished.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>See Managing Thread References for more details on using the Shlwapi thread APIs.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shcreatethreadref LWSTDAPI SHCreateThreadRef( LONG *pcRef,
	// IUnknown **ppunk );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "6abca2df-832c-410b-93c7-5131e481e595")]
	public static extern HRESULT SHCreateThreadRef(ref int pcRef, [MarshalAs(UnmanagedType.IUnknown)] out object ppunk);

	/// <summary>
	/// <para>Creates a new thread and retrieves its handle.</para>
	/// </summary>
	/// <param name="pfnThreadProc">
	/// <para>Type: <c>LPTHREAD_START_ROUTINE</c></para>
	/// <para>
	/// A pointer to an application-defined function of type LPTHREAD_START_ROUTINE. If a new thread was successfully created, this
	/// application-defined function is called in the context of that thread. <c>SHCreateThreadWithHandle</c> does not wait for the
	/// function pointed to by pfnThreadProc to complete before returning to its caller. The return value for the function specified by
	/// pfnThreadProc is the exit code of the thread.
	/// </para>
	/// </param>
	/// <param name="pData">
	/// <para>Type: <c>void*</c></para>
	/// <para>
	/// A pointer to an optional application-defined data structure that contains initialization data. It is passed to the function
	/// pointed to by pfnThreadProc and, optionally, the function pointed to by pfnCallback.
	/// </para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>SHCT_FLAGS</c></para>
	/// <para>Flags that control the behavior of the function; one or more of the CTF constants.</para>
	/// </param>
	/// <param name="pfnCallback">
	/// <para>Type: <c>LPTHREAD_START_ROUTINE</c></para>
	/// <para>
	/// A pointer to an optional application-defined function of type LPTHREAD_START_ROUTINE. This function is called in the context of
	/// the created thread before the function pointed to by pfnThreadProc is called. It will also receive pData as its argument.
	/// <c>SHCreateThreadWithHandle</c> waits for the function pointed to by pfnCallback to complete before returning to its caller. The
	/// return value for the function specified by pfnCallback is ignored.
	/// </para>
	/// </param>
	/// <param name="pHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>
	/// A pointer to the <c>HANDLE</c> of the created thread. When it is no longer needed, this handle should be closed by calling the
	/// CloseHandle function. This value can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if the thread is successfully created; otherwise, <c>FALSE</c></para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Prior to Windows 7, this function did not have an associated header or library file. To use this function under those earlier
	/// operating systems, call LoadLibrary with the DLL name (Shlwapi.dll) to obtain a module handle. Then call GetProcAddress with that
	/// module handle and a function ordinal of 615 to get the address of this function.
	/// </para>
	/// <para>The function pointed to by pfnThreadProc and pfnCallback must take the following form.</para>
	/// <para>
	/// The function name is arbitrary. The pData parameter points to an application-defined data structure with initialization information.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example provides a function pointer prototype typedef for calling <c>SHCreateThreadWithHandle</c> by ordinal
	/// and shows how to accomplish such a call.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shcreatethreadwithhandle BOOL SHCreateThreadWithHandle(
	// LPTHREAD_START_ROUTINE pfnThreadProc, void *pData, SHCT_FLAGS flags, LPTHREAD_START_ROUTINE pfnCallback, HANDLE *pHandle );
	[DllImport(Lib.Shlwapi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "22a3a97a-857f-46b8-a2e0-8f3a14f40322")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SHCreateThreadWithHandle(ThreadProc pfnThreadProc, [Optional] IntPtr pData, SHCT_FLAGS flags, [Optional] ThreadProc? pfnCallback, out SafeHFILE pHandle);

	/// <summary>Deletes an empty key.</summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to an open registry key, or one of the following predefined keys:</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="pszSubKey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The address of a null-terminated string specifying the name of the key to delete.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns <c>ERROR_SUCCESS</c> if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para><c>SHDeleteEmptyKey</c> does not delete a key if it contains any subkeys or values. Use SHDeleteKey instead.</para>
	/// <para>Alternatively, use the RegDeleteKey or RegDeleteTree function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shdeleteemptykeya LSTATUS SHDeleteEmptyKeyA( HKEY hkey,
	// LPCSTR pszSubKey );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "6a560bc3-f65e-4b7d-9fbc-b4f2971ce2a9")]
	public static extern Win32Error SHDeleteEmptyKey(HKEY hkey, string pszSubKey);

	/// <summary>Deletes a subkey and all its descendants. This function removes the key and all the key's values from the registry.</summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to an open registry key, or one of the following predefined keys:</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="pszSubKey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The address of a null-terminated string specifying the name of the key to delete.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns <c>ERROR_SUCCESS</c> if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>Alternatively, use the RegDeleteKey or RegDeleteTree function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shdeletekeya LSTATUS SHDeleteKeyA( HKEY hkey, LPCSTR
	// pszSubKey );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "3c46db08-52d8-48fa-bda5-3c087908a1d3")]
	public static extern Win32Error SHDeleteKey(HKEY hkey, string pszSubKey);

	/// <summary>Deletes a named value from the specified registry key.</summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to the currently open key, or any of the following predefined values.</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="pszSubKey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The address of a null-terminated string specifying the name of the subkey for which to change the value.</para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The address of the value to be deleted.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shdeletevaluea LSTATUS SHDeleteValueA( HKEY hkey, LPCSTR
	// pszSubKey, LPCSTR pszValue );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "54f3459b-486c-4907-84b1-39b1f8abb12d")]
	public static extern Win32Error SHDeleteValue(HKEY hkey, string pszSubKey, string pszValue);

	/// <summary>
	/// <para>Enumerates the subkeys of the specified open registry key.</para>
	/// </summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to the currently open key, or any of the following predefined values.</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="dwIndex">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The index of the subkey to retrieve. This parameter should be zero for the first call and incremented for subsequent calls.</para>
	/// </param>
	/// <param name="pszName">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>The address of a character buffer that receives the enumerated key name.</para>
	/// </param>
	/// <param name="pcchName">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// The address of a <c>DWORD</c> that, on entry, contains the size of the buffer at pszName, in characters. On exit, this contains
	/// the number of characters that were copied to pszName.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a textual description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shenumkeyexa LSTATUS SHEnumKeyExA( HKEY hkey, DWORD
	// dwIndex, LPSTR pszName, LPDWORD pcchName );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "51bf9cf7-87bc-407c-b2ee-18db3cdfe1dc")]
	public static extern Win32Error SHEnumKeyEx(HKEY hkey, uint dwIndex, StringBuilder pszName, ref uint pcchName);

	/// <summary>
	/// <para>Enumerates the values of the specified open registry key.</para>
	/// </summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to the currently open key, or any of the following predefined values.</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="dwIndex">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The index of the value to retrieve. This parameter should be zero for the first call and incremented for subsequent calls.</para>
	/// </param>
	/// <param name="pszValueName">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>The address of a character buffer that receives the enumerated value name. The size of this buffer is specified in pcchValueName.</para>
	/// </param>
	/// <param name="pcchValueName">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// The address of a <c>DWORD</c> that, on entry, contains the size of the buffer at pszValueName, in characters. On exit, this
	/// contains the number of characters that were copied to pszValueName.
	/// </para>
	/// </param>
	/// <param name="pdwType">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// The address of a <c>DWORD</c> that receives the data type of the value. These are the same values as those described under the
	/// lpType parameter of RegEnumValue.
	/// </para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>
	/// The address of a buffer that receives the data for the value entry. The size of this buffer is specified in pcbData. This
	/// parameter can be <c>NULL</c> if the data is not required.
	/// </para>
	/// </param>
	/// <param name="pcbData">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// The address of a <c>DWORD</c> that, on entry, contains the size of the buffer at pvData, in bytes. On exit, this contains the
	/// number of bytes that were copied to pvData.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a textual description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shenumvaluea LSTATUS SHEnumValueA( HKEY hkey, DWORD
	// dwIndex, PSTR pszValueName, LPDWORD pcchValueName, LPDWORD pdwType, void *pvData, LPDWORD pcbData );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "bb0eaa07-5112-4ce3-8796-5439bd863226")]
	public static extern Win32Error SHEnumValue(HKEY hkey, uint dwIndex, StringBuilder pszValueName, ref uint pcchValueName,
		out REG_VALUE_TYPE pdwType, [Optional] IntPtr pvData, ref uint pcbData);

	/// <summary>
	/// <para>Enumerates the values of the specified open registry key.</para>
	/// </summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to the currently open key, or any of the following predefined values.</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="dwIndex">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The index of the value to retrieve. This parameter should be zero for the first call and incremented for subsequent calls.</para>
	/// </param>
	/// <param name="pszValueName">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>The address of a character buffer that receives the enumerated value name. The size of this buffer is specified in pcchValueName.</para>
	/// </param>
	/// <param name="pcchValueName">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// The address of a <c>DWORD</c> that, on entry, contains the size of the buffer at pszValueName, in characters. On exit, this
	/// contains the number of characters that were copied to pszValueName.
	/// </para>
	/// </param>
	/// <param name="pdwType">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// The address of a <c>DWORD</c> that receives the data type of the value. These are the same values as those described under the
	/// lpType parameter of RegEnumValue.
	/// </para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>
	/// The address of a buffer that receives the data for the value entry. The size of this buffer is specified in pcbData. This
	/// parameter can be <c>NULL</c> if the data is not required.
	/// </para>
	/// </param>
	/// <param name="pcbData">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// The address of a <c>DWORD</c> that, on entry, contains the size of the buffer at pvData, in bytes. On exit, this contains the
	/// number of bytes that were copied to pvData.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a textual description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shenumvaluea LSTATUS SHEnumValueA( HKEY hkey, DWORD
	// dwIndex, PSTR pszValueName, LPDWORD pcchValueName, LPDWORD pdwType, void *pvData, LPDWORD pcbData );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "bb0eaa07-5112-4ce3-8796-5439bd863226")]
	public static extern Win32Error SHEnumValue(HKEY hkey, uint dwIndex, StringBuilder pszValueName, ref uint pcchValueName,
		out REG_VALUE_TYPE pdwType, SafeAllocatedMemoryHandle pvData, ref uint pcbData);

	/// <summary>
	/// <para>
	/// [ <c>SHFormatDateTime</c> is available for use in the operating systems specified in the Requirements section. It may be altered
	/// or unavailable in subsequent versions.]
	/// </para>
	/// <para>Produces a string representation of a time specified as a FILETIME structure.</para>
	/// </summary>
	/// <param name="pft">
	/// <para>Type: <c>const FILETIME UNALIGNED*</c></para>
	/// <para>A pointer to the FILETIME structure whose time is to be converted to a string.</para>
	/// </param>
	/// <param name="pdwFlags">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>A pointer to a <c>DWORD</c> value that contains bitwise flags that specify the date and time format.</para>
	/// <para>
	/// When you call the function, you can combine zero or more of the following flags, with exceptions as noted. You can also set this
	/// parameter to <c>NULL</c>, in which case the function assumes that the FDTF_DEFAULT flag is set.
	/// </para>
	/// <para>FDTF_SHORTTIME (0x00000001)</para>
	/// <para>
	/// 0x00000001. Formats the time of day as specified by the <c>Regional and Language Options</c> application in Control Panel, but
	/// without seconds. This flag cannot be combined with FDTF_LONGTIME.
	/// </para>
	/// <para>The short time was successfully formatted.</para>
	/// <para>FDTF_SHORTDATE (0x00000002)</para>
	/// <para>
	/// 0x00000002. Formats the date as specified by the short date format in the <c>Regional and Language Options</c> application in
	/// Control Panel. This flag cannot be combined with FDTF_LONGDATE.
	/// </para>
	/// <para>The short date was successfully formatted.</para>
	/// <para>FDTF_DEFAULT</para>
	/// <para>Equivalent to FDTF_SHORTDATE | FDTF_SHORTTIME.</para>
	/// <para>FDTF_LONGDATE (0x00000004)</para>
	/// <para>
	/// 0x00000004. Formats the date as specified by the long date format in the <c>Regional and Language Options</c> application in
	/// Control Panel. This flag cannot be combined with FDTF_SHORTDATE.
	/// </para>
	/// <para>The long date was successfully formatted.</para>
	/// <para>FDTF_LONGTIME (0x00000008)</para>
	/// <para>
	/// 0x00000008. Formats the time of day as specified by the <c>Regional and Language Options</c> application in Control Panel,
	/// including seconds. This flag cannot be combined with FDTF_SHORTTIME.
	/// </para>
	/// <para>The long time was successfully formatted.</para>
	/// <para>FDTF_RELATIVE (0x00000010)</para>
	/// <para>
	/// 0x00000010. If the FDTF_LONGDATE flag is set and the date in the FILETIME structure is the same date that <c>SHFormatDateTime</c>
	/// is called, then the day of the week (if present) is changed to "Today". If the date in the structure is the previous day, then
	/// the day of the week (if present) is changed to "Yesterday".
	/// </para>
	/// <para>Relative notation was used for the date.</para>
	/// <para>FDTF_LTRDATE (0x00000100)</para>
	/// <para>0x00000100. Adds marks for left-to-right reading layout. This flag cannot be combined with FDTF_RTLDATE.</para>
	/// <para>FDTF_RTLDATE (0x00000200)</para>
	/// <para>0x00000200. Adds marks for right-to-left reading layout. This flag cannot be combined with FDTF_LTRDATE.</para>
	/// <para>FDTF_NOAUTOREADINGORDER (0x00000400)</para>
	/// <para>
	/// 0x00000400. No reading order marks are inserted. Normally, in the absence of the FDTF_LTRDATE or FDTF_RTLDATE flag,
	/// <c>SHFormatDateTime</c> determines the reading order from the user's default locale, inserts reading order marks, and updates the
	/// pdwFlags output value appropriately. This flag prevents that process from occurring. It is used most commonly by legacy callers
	/// of <c>SHFormatDateTime</c>. This flag cannot be combined with FDTF_RTLDATE or FDTF_LTRDATE.
	/// </para>
	/// <para><c>Windows Server 2003 and Windows XP:</c> This value is not available.</para>
	/// <para>
	/// When the function returns, the <c>DWORD</c> value pointed to by this parameter can contain zero or more of the following flags.
	/// </para>
	/// <para>FDTF_SHORTTIME (0x00000001)</para>
	/// <para>
	/// 0x00000001. Formats the time of day as specified by the <c>Regional and Language Options</c> application in Control Panel, but
	/// without seconds. This flag cannot be combined with FDTF_LONGTIME.
	/// </para>
	/// <para>The short time was successfully formatted.</para>
	/// <para>FDTF_SHORTDATE (0x00000002)</para>
	/// <para>
	/// 0x00000002. Formats the date as specified by the short date format in the <c>Regional and Language Options</c> application in
	/// Control Panel. This flag cannot be combined with FDTF_LONGDATE.
	/// </para>
	/// <para>The short date was successfully formatted.</para>
	/// <para>FDTF_LONGDATE (0x00000004)</para>
	/// <para>
	/// 0x00000004. Formats the date as specified by the long date format in the <c>Regional and Language Options</c> application in
	/// Control Panel. This flag cannot be combined with FDTF_SHORTDATE.
	/// </para>
	/// <para>The long date was successfully formatted.</para>
	/// <para>FDTF_LONGTIME (0x00000008)</para>
	/// <para>
	/// 0x00000008. Formats the time of day as specified by the <c>Regional and Language Options</c> application in Control Panel,
	/// including seconds. This flag cannot be combined with FDTF_SHORTTIME.
	/// </para>
	/// <para>The long time was successfully formatted.</para>
	/// <para>FDTF_RELATIVE (0x00000010)</para>
	/// <para>
	/// 0x00000010. If the FDTF_LONGDATE flag is set and the date in the FILETIME structure is the same date that <c>SHFormatDateTime</c>
	/// is called, then the day of the week (if present) is changed to "Today". If the date in the structure is the previous day, then
	/// the day of the week (if present) is changed to "Yesterday".
	/// </para>
	/// <para>Relative notation was used for the date.</para>
	/// </param>
	/// <param name="pszBuf">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// A pointer to a buffer that receives the formatted date and time. The buffer must be large enough to contain the number of TCHAR
	/// characters specified by the cchBuf parameter, including a terminating null character.
	/// </para>
	/// </param>
	/// <param name="cchBuf">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of TCHARs that can be contained by the buffer pointed to by pszBuf.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// Returns the number of TCHARs written to the buffer, including the terminating null character. On failure, this value is 0.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shformatdatetimew int SHFormatDateTimeW( const FILETIME
	// *pft, DWORD *pdwFlags, LPWSTR pszBuf, UINT cchBuf );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "2208ed29-6029-4051-bdcc-885c42fe5c1b")]
	public static extern int SHFormatDateTime(in FILETIME pft, ref FDTF pdwFlags, StringBuilder pszBuf, uint cchBuf);

	/// <summary>
	/// <para>
	/// [ <c>SHFreeShared</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Frees shared memory, regardless of which process allocated it.</para>
	/// </summary>
	/// <param name="hData">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A handle to the mapped memory.</para>
	/// </param>
	/// <param name="dwProcessId">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The process ID of the process from which the memory was allocated.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns <c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shfreeshared BOOL SHFreeShared( HANDLE hData, DWORD
	// dwProcessId );
	[DllImport(Lib.Shlwapi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "5a86ae5d-8caa-4126-a22e-bc3cc7df2381")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SHFreeShared(IntPtr hData, uint dwProcessId);

	/// <summary>
	/// <para>
	/// [This function is available through Windows XP and Windows Server 2003. It might be altered or unavailable in subsequent versions
	/// of Windows.]
	/// </para>
	/// <para>Retrieves the inverse color table mapping for the halftone palette.</para>
	/// </summary>
	/// <param name="pbMap">
	/// <para>Type: <c>BYTE*</c></para>
	/// <para>
	/// A pointer to an array of <c>BYTE</c><c>s</c> that receives the inverse color table mapping, or a pointer to an <c>LPBYTE</c>
	/// which receives a pointer to a cached copy of the inverse color table mapping, depending on the value of the cbMap parameter.
	/// </para>
	/// </param>
	/// <param name="cbMap">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>The size of the buffer pointed to by pbMap, which also defines its contents. Two values are recognized.</para>
	/// <para>(sizeof(BYTE*))</para>
	/// <para>The buffer pointed to by pbMap receives a pointer to a cached copy of the inverse color map table.</para>
	/// <para>(32768)</para>
	/// <para>
	/// The buffer pointed to by pbMap receives a copy of the inverse color map table. The buffer must be exactly 32,768 bytes in size.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The inverse color mapping table is a table of 32,768 bytes. It contains the indexes of colors in the halftone palette. Each index
	/// is stored at a position in the buffer that corresponds to a particular RGB value expressed in 555 format. These pairings allow
	/// you to find a color in the halftone palette which is a close approximation of the original color.
	/// </para>
	/// <para>
	/// For example, the method for determining a color in the halftone palette that is a close approximation for the color #306040 is as follows:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Decompose the color into its red, green, and blue components. In this case, the red component is 0x30, the green component is
	/// 0x60 and the blue component is 0x40.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Reassemble the color into 555 format. The formula for reducing a 24-bit RGB color into 555 format is shown here. In this example,
	/// the value in 555 format is ((0x30 / 8) &lt;&lt; 10) + ((0x60 / 8) &lt;&lt; 5) + (0x40 / 8) = 6536.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The index value stored in position 6536 in the inverse color map table is the index of the color in the halftone palette that is
	/// a reasonable approximation to the color #306040.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shgetinversecmap LWSTDAPI SHGetInverseCMAP( BYTE *pbMap,
	// ULONG cbMap );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "46d5ccd2-3c5d-431b-b27b-6a7a95043e0a")]
	public static extern HRESULT SHGetInverseCMAP(IntPtr pbMap, uint cbMap);

	/// <summary>
	/// <para>Retrieves the per-thread object reference set by SHSetThreadRef.</para>
	/// </summary>
	/// <param name="ppunk">
	/// <para>Type: <c>IUnknown**</c></para>
	/// <para>
	/// The address of a pointer that, when this function returns successfully, points to the object whose reference is stored. Your
	/// application is responsible for freeing this resource when it is no longer needed.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns S_OK if the object reference exists, or <c>E_NOINTERFACE</c> otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shgetthreadref LWSTDAPI SHGetThreadRef( IUnknown **ppunk );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "307b284b-f493-4d24-a7be-17c150d62b34")]
	public static extern HRESULT SHGetThreadRef([MarshalAs(UnmanagedType.IUnknown)] out object ppunk);

	/// <summary>
	/// <para>Retrieves a registry value.</para>
	/// </summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to the currently open key, or any of the following predefined values.</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="pszSubKey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The address of a null-terminated string that specifies the name of the subkey from which to retrieve the value.</para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The address of the value.</para>
	/// </param>
	/// <param name="pdwType">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>The type of value. For more information, see Registry Data Types.</para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>The address of the destination data buffer.</para>
	/// </param>
	/// <param name="pcbData">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>The size of the destination data buffer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If your application must set/retrieve a series of values in the same key, it is better to open the key once and set/retrieve the
	/// values with the regular Microsoft Win32 registry functions rather than use this function repeatedly.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shgetvaluea LSTATUS SHGetValueA( HKEY hkey, LPCSTR
	// pszSubKey, LPCSTR pszValue, DWORD *pdwType, void *pvData, DWORD *pcbData );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "8cca6bfe-d365-4d10-bc8d-f3bebefaad02")]
	public static extern Win32Error SHGetValue(HKEY hkey, string pszSubKey, string pszValue, out REG_VALUE_TYPE pdwType, IntPtr pvData, ref uint pcbData);

	/// <summary>
	/// <para>Retrieves a registry value.</para>
	/// </summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to the currently open key, or any of the following predefined values.</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="pszSubKey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The address of a null-terminated string that specifies the name of the subkey from which to retrieve the value.</para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The address of the value.</para>
	/// </param>
	/// <param name="pdwType">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>The type of value. For more information, see Registry Data Types.</para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>The address of the destination data buffer.</para>
	/// </param>
	/// <param name="pcbData">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>The size of the destination data buffer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If your application must set/retrieve a series of values in the same key, it is better to open the key once and set/retrieve the
	/// values with the regular Microsoft Win32 registry functions rather than use this function repeatedly.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shgetvaluea LSTATUS SHGetValueA( HKEY hkey, LPCSTR
	// pszSubKey, LPCSTR pszValue, DWORD *pdwType, void *pvData, DWORD *pcbData );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "8cca6bfe-d365-4d10-bc8d-f3bebefaad02")]
	public static extern Win32Error SHGetValue(HKEY hkey, string pszSubKey, string pszValue, out REG_VALUE_TYPE pdwType, SafeAllocatedMemoryHandle pvData, ref uint pcbData);

	/// <summary>
	/// <para>
	/// [ <c>SHGetViewStatePropertyBag</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// Retrieves a property bag in which the view state information for a folder can be stored and subsequently retrieved. The user's
	/// settings are kept for the next time the user visits the folder.
	/// </para>
	/// </summary>
	/// <param name="pidl">
	/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
	/// <para>
	/// A PIDL of the folder for which you are requesting properties. This parameter must be <c>NULL</c> if the SHGVSPB_ALLFOLDERS flag
	/// is passed.
	/// </para>
	/// </param>
	/// <param name="pszBagName">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>A pointer to a string that contains the name of the requested property bag.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>A value that specifies a combination of the following flags.</para>
	/// <para>One value from the following set of flags is required.</para>
	/// <para>SHGVSPB_PERUSER</para>
	/// <para>Returns the per-user properties for the specified pidl.</para>
	/// <para>SHGVSPB_ALLUSERS</para>
	/// <para>Returns the All User properties for the specified pidl.</para>
	/// <para>One value from the following set of flags is required.</para>
	/// <para>SHGVSPB_PERFOLDER</para>
	/// <para>Returns the property bag for the folder specified by the pidl parameter.</para>
	/// <para>SHGVSPB_ALLFOLDERS</para>
	/// <para>Returns the property bag that applies to all folders.</para>
	/// <para>SHGVSPB_INHERIT</para>
	/// <para>Returns the property bag used to provide defaults for subfolders that do not have their property bag.</para>
	/// <para>The following flags are optional.</para>
	/// <para>SHGVSPB_ROAM</para>
	/// <para>Allows the property bag to roam. See Roaming User Profiles. This flag cannot be combined with SHGVSPB_ALLFOLDERS.</para>
	/// <para>SHGVSPB_NOAUTODEFAULTS</para>
	/// <para>
	/// Suppresses the search for a suitable default when the property bag cannot be found for the specified folder. By default, if
	/// SHGVSPB_INHERIT is not specified and a property bag cannot be found for the specified folder, the system searches for identically
	/// named property bags in other locations that may be able to provide default values. For example, the system searches in the
	/// ancestors of the folder to see if any of them provide a SHGVSPB_INHERIT property bag. Other places the system searches are in the
	/// user defaults and the global defaults.
	/// </para>
	/// <para>The following set of flags consists of values that combine some flags listed above, and are used for brevity and convenience.</para>
	/// <para>SHGVSPB_FOLDER</para>
	/// <para>Combines SHGVSPB_PERUSER and SHGVSPB_PERFOLDER.</para>
	/// <para>SHGVSPB_FOLDERNODEFAULTS</para>
	/// <para>Combines SHGVSPB_PERUSER, SHGVSPB_PERFOLDER, and SHGVSPB_NOAUTODEFAULTS.</para>
	/// <para>SHGVSPB_USERDEFAULTS</para>
	/// <para>Combines SHGVSPB_PERUSER and SHGVSPB_ALLFOLDERS.</para>
	/// <para>SHGVSPB_GLOBALDEFAULTS</para>
	/// <para>Combines SHGVSPB_ALLUSERS and SHGVSPB_ALLFOLDERS.</para>
	/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This flag is named SHGVSPB_GLOBALDEAFAULTS.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>A reference to the IID of the interface to retrieve through ppv.</para>
	/// </param>
	/// <param name="ppv">
	/// <para>Type: <c>void**</c></para>
	/// <para>When this method returns successfully, contains the interface pointer requested in riid.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Critical information should not be stored in the view state property bag because the system keeps only a limited number of view
	/// states. If a folder is not visited for a long time, its view state is eventually deleted.
	/// </para>
	/// <para>
	/// We recommend that you use the IID_PPV_ARGS macro, defined in Objbase.h, to package the riid and ppv parameters. This macro
	/// provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a coding
	/// error in riid that could lead to unexpected results.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shgetviewstatepropertybag LWSTDAPI
	// SHGetViewStatePropertyBag( PCIDLIST_ABSOLUTE pidl, PCWSTR pszBagName, DWORD dwFlags, REFIID riid, void **ppv );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "6852867a-30a5-4d4e-b790-3746104e3ed8")]
	public static extern HRESULT SHGetViewStatePropertyBag([Optional] IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszBagName,
		SHGVSPB dwFlags, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object ppv);

	/// <summary>
	/// <para>
	/// [This function is available through Windows XP and Windows Server 2003. It might be altered or unavailable in subsequent versions
	/// of Windows.]
	/// </para>
	/// <para>Compares whether a window is equal to, a child of, or a descendant of, a second window.</para>
	/// </summary>
	/// <param name="hwndParent">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to the first window.</para>
	/// </param>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>A handle to a window to be tested against hwndParent.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// Returns <c>S_OK</c> if the window specified by hwnd is equal to, a child of, or a descendent of the window specified by
	/// hwndParent. Returns <c>S_FALSE</c> if the window specified by hwnd is not equal to, not a child of, and not a descendent of the
	/// window specified by hwndParent. The return value is undefined if either window handle is invalid.
	/// </para>
	/// </returns>
	// HRESULT SHIsChildOrSelf( _In_ HWND hwndParent, _In_ HWND hwnd); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773834(v=vs.85).aspx
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Shlwapi.h", MSDNShortId = "bb773834")]
	public static extern HRESULT SHIsChildOrSelf([In] HWND hwndParent, [In] HWND hwnd);

	/// <summary>
	/// <para>Not supported.</para>
	/// </summary>
	/// <param name="dwType">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The type of machine being examined. The following is the only recognized value.</para>
	/// <para>ILMM_IE4</para>
	/// <para>
	/// An older (circa 1997), low-end machine. Since system resources in general were lower on these older machines, the low-memory
	/// threshold is accordingly lower.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if the machine is considered low on resources, <c>FALSE</c> otherwise.</para>
	/// <para><c>Note</c> Always returns <c>FALSE</c> under Windows XP.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shislowmemorymachine BOOL SHIsLowMemoryMachine( DWORD
	// dwType );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "3a91156d-eef9-4d3c-9cb8-fd50bfa94354")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SHIsLowMemoryMachine(uint dwType = 0);

	/// <summary>
	/// Extracts a specified text resource when given that resource in the form of an indirect string (a string that begins with the '@' symbol).
	/// </summary>
	/// <param name="pszSource">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>
	/// A pointer to a buffer that contains the indirect string from which the resource will be retrieved. This string should begin with
	/// the '@' symbol and use one of the forms discussed in the Remarks section. This function will successfully accept a string that
	/// does not begin with an '@' symbol, but the string will be simply passed unchanged to pszOutBuf.
	/// </para>
	/// </param>
	/// <param name="pszOutBuf">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>
	/// A pointer to a buffer that, when this function returns successfully, receives the text resource. Both pszOutBuf and pszSource
	/// can point to the same buffer, in which case the original string will be overwritten.
	/// </para>
	/// </param>
	/// <param name="cchOutBuf">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of the buffer pointed to by pszOutBuf, in characters.</para>
	/// </param>
	/// <param name="ppvReserved">
	/// <para>Type: <c>void**</c></para>
	/// <para>Not used; set to <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>An indirect string can be provided in several forms, each of which has its own interpretation:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// <c>File name and resource ID</c> The string is extracted from the file named, using the resource value as a locator. If the
	/// resource value is zero or greater, the number becomes the index of the string in the binary file. If the number is negative, it
	/// becomes a resource ID. The retrieved string is copied to the output buffer and the function returns S_OK.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <c>File name and resource ID with a version modifier</c> This form can be used when a resource is changed but still uses the
	/// same index or ID as the old resource. Without a version modifier, the Multilingual User Interface (MUI) cache will not recognize
	/// that the resource has changed and will not refresh. By appending the version modifier, the value is seen as a new resource and
	/// is added to the cache. Note that it is recommended that you use a new ID or index for a new resource, and use a version modifier
	/// only when that is not possible.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <c>PRI file path and resource ID</c> The Package Resource Index (PRI) is a binary format introduced in Windows 8 that contains
	/// indexed resources or references to resources. The .pri file is bundled as part of an app's package. For more information on .pri
	/// files, see Creating and retrieving resources in Windows Store apps.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <c>Package name and resource ID</c> The string is extracted from the Resources.pri file stored in the app's root directory of
	/// the package identified by PackageFullName, using the resource as a locator. The retrieved string is copied to the output buffer
	/// and the function returns S_OK. The string is extracted based on the app's environment or ResourceContext. An example of this
	/// type of indirect string is shown here. In this example, the reference name is fully-qualified, but it contains no namespace (for
	/// example, "resources"). The deployment stack expands the name to look for it in all namespaces.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the string is not an indirect string, then the string is directly copied without change to pszOutBuf and the function returns S_OK.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shloadindirectstring LWSTDAPI SHLoadIndirectString( PCWSTR
	// pszSource, PWSTR pszOutBuf, UINT cchOutBuf, void **ppvReserved );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "f0265cd8-deb8-4bca-b379-39aff49c7df1")]
	public static extern HRESULT SHLoadIndirectString([MarshalAs(UnmanagedType.LPWStr)] string pszSource, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszOutBuf, uint cchOutBuf, IntPtr ppvReserved = default);

	/// <summary>
	/// Extracts a specified text resource when given that resource in the form of an indirect string (a string that begins with the '@' symbol).
	/// </summary>
	/// <param name="pszSource">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>
	/// A pointer to a buffer that contains the indirect string from which the resource will be retrieved. This string should begin with
	/// the '@' symbol and use one of the forms discussed in the Remarks section. This function will successfully accept a string that
	/// does not begin with an '@' symbol, but the string will be simply passed unchanged to pszOutBuf.
	/// </para>
	/// </param>
	/// <param name="pszOutBuf">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>
	/// A pointer to a buffer that, when this function returns successfully, receives the text resource. Both pszOutBuf and pszSource
	/// can point to the same buffer, in which case the original string will be overwritten.
	/// </para>
	/// </param>
	/// <param name="cchOutBuf">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of the buffer pointed to by pszOutBuf, in characters.</para>
	/// </param>
	/// <param name="ppvReserved">
	/// <para>Type: <c>void**</c></para>
	/// <para>Not used; set to <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>An indirect string can be provided in several forms, each of which has its own interpretation:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// <c>File name and resource ID</c> The string is extracted from the file named, using the resource value as a locator. If the
	/// resource value is zero or greater, the number becomes the index of the string in the binary file. If the number is negative, it
	/// becomes a resource ID. The retrieved string is copied to the output buffer and the function returns S_OK.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <c>File name and resource ID with a version modifier</c> This form can be used when a resource is changed but still uses the
	/// same index or ID as the old resource. Without a version modifier, the Multilingual User Interface (MUI) cache will not recognize
	/// that the resource has changed and will not refresh. By appending the version modifier, the value is seen as a new resource and
	/// is added to the cache. Note that it is recommended that you use a new ID or index for a new resource, and use a version modifier
	/// only when that is not possible.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <c>PRI file path and resource ID</c> The Package Resource Index (PRI) is a binary format introduced in Windows 8 that contains
	/// indexed resources or references to resources. The .pri file is bundled as part of an app's package. For more information on .pri
	/// files, see Creating and retrieving resources in Windows Store apps.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <c>Package name and resource ID</c> The string is extracted from the Resources.pri file stored in the app's root directory of
	/// the package identified by PackageFullName, using the resource as a locator. The retrieved string is copied to the output buffer
	/// and the function returns S_OK. The string is extracted based on the app's environment or ResourceContext. An example of this
	/// type of indirect string is shown here. In this example, the reference name is fully-qualified, but it contains no namespace (for
	/// example, "resources"). The deployment stack expands the name to look for it in all namespaces.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the string is not an indirect string, then the string is directly copied without change to pszOutBuf and the function returns S_OK.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shlwapi/nf-shlwapi-shloadindirectstring LWSTDAPI SHLoadIndirectString( PCWSTR
	// pszSource, PWSTR pszOutBuf, UINT cchOutBuf, void **ppvReserved );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "NF:shlwapi.SHLoadIndirectString")]
	public static extern HRESULT SHLoadIndirectString([MarshalAs(UnmanagedType.LPWStr)] string pszSource, IntPtr pszOutBuf, uint cchOutBuf, IntPtr ppvReserved = default);

	/// <summary>
	/// <para>
	/// [ <c>SHLockShared</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Maps a block of memory from a specified process into the calling process.</para>
	/// </summary>
	/// <param name="hData">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A handle to the memory you want to map into the calling process.</para>
	/// </param>
	/// <param name="dwProcessId">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The process ID of the process from which you want to map the block of memory.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a void pointer to the shared memory. Returns <c>NULL</c> if unsuccessful.</para>
	/// </returns>
	/// <remarks>
	/// <para>Call SHUnlockShared to unlock the memory that this function maps. Call SHFreeShared to release the memory.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shlockshared void * SHLockShared( HANDLE hData, DWORD
	// dwProcessId );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "5b948044-6cec-4649-a266-21959154f999")]
	public static extern IntPtr SHLockShared(IntPtr hData, uint dwProcessId);

	/// <summary>
	/// <para>
	/// [ <c>SHMessageBoxCheck</c> is available for use in the operating systems specified in the Requirements section. It may be altered
	/// or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// Displays a message box that gives the user the option of suppressing further occurrences. If the user has already opted to
	/// suppress the message box, the function does not display a dialog box and instead simply returns the default value.
	/// </para>
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>The window handle to the message box's owner. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pszText">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to a null-terminated string that contains the message to be displayed.</para>
	/// </param>
	/// <param name="pszCaption">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A pointer to a null-terminated string that contains the title of the message box. If this parameter is set to <c>NULL</c>, the
	/// title is set to <c>Error!</c>.
	/// </para>
	/// </param>
	/// <param name="uType">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The flags that specify the contents and behavior of the message box. This function supports only a subset of the flags supported
	/// by MessageBox. If you use any flags that are not listed below, the function's behavior is undefined.
	/// </para>
	/// <para>You must specify the buttons to be displayed by setting one and only one of the following flags.</para>
	/// <para>MB_OKCANCEL</para>
	/// <para>Display a message box with <c>OK</c> and <c>Cancel</c> buttons.</para>
	/// <para>MB_YESNO</para>
	/// <para>Display a message box with <c>Yes</c> and <c>No</c> buttons.</para>
	/// <para>MB_OK</para>
	/// <para>Display a message box with an <c>OK</c> button.</para>
	/// <para>You can display an optional icon by setting one and only one of the following flags.</para>
	/// <para>MB_ICONHAND</para>
	/// <para>Display a stop-sign icon.</para>
	/// <para>MB_ICONQUESTION</para>
	/// <para>Display a question-mark icon.</para>
	/// <para>MB_ICONEXCLAMATION</para>
	/// <para>Display an exclamation-point icon.</para>
	/// <para>MB_ICONINFORMATION</para>
	/// <para>Display an icon with a lowercase "i" in a circle.</para>
	/// </param>
	/// <param name="iDefault">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The value that the function returns when the user has opted not to have the message box displayed again. If the user has not
	/// opted to suppress the message box, the message box is displayed and the function ignores iDefault.
	/// </para>
	/// </param>
	/// <param name="pszRegVal">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A pointer to a null-terminated string that contains a unique string value to associate with this message. To avoid collisions
	/// with values used by Microsoft, this string should include a GUID. This string must not exceed REGSTR_MAX_VALUE_LENGTH characters
	/// in length, including the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>If the user has already chosen to suppress the message box, the function immediately returns the value assigned to iDefault.</para>
	/// <para>
	/// If the user clicks the <c>OK</c>, <c>Cancel</c>, <c>Yes</c>, or <c>No</c> button, the function returns IDOK, IDCANCEL, IDYES, or
	/// IDNO, respectively.
	/// </para>
	/// <para>
	/// If the user closes the message box by clicking the <c>X</c> button in the caption, the function returns IDCANCEL. This value is
	/// returned in this case even if the MB_OKCANCEL flag has not been set.
	/// </para>
	/// <para>
	/// If an error occurs, the return value is normally –1. However, under certain low-memory conditions, the function might return iDefault.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Security Warning:</c> Do not take any dangerous actions if the function returns either –1 or iDefault. If an error occurs when
	/// attempting to display the message box, <c>SHMessageBoxCheck</c> returns –1 or, in some cases, iDefault. Such errors can be caused
	/// by insufficient memory or resources. If you get one of these return values, you should be aware that the user did not necessarily
	/// see the dialog box and consequently did not positively agree to any action.
	/// </para>
	/// <para>
	/// Do not confuse "Do not show this dialog box" with "Remember this answer". <c>SHMessageBoxCheck</c> does not provide "Remember
	/// this answer" functionality. If the user chooses to suppress the message box again, the function does not preserve which button
	/// they clicked. Instead, subsequent invocations of <c>SHMessageBoxCheck</c> simply return the value specified by iDefault. Consider
	/// the following example.
	/// </para>
	/// <para>
	/// If the user selects <c>In the future, do not show me this</c> dialog box and clicks the <c>Yes</c> button,
	/// <c>SHMessageBoxCheck</c> returns IDYES. However, the next time this code is executed, <c>SHMessageBoxCheck</c> does not return
	/// IDYES, even though the user selected <c>Yes</c> originally. Instead, it returns IDNO, because that is the value specified by iDefault.
	/// </para>
	/// <para>
	/// The default button displayed by the message box should agree with your iDefault value. The lack of support for the MB_DEFBUTTON2
	/// flag means that iDefault should be set to IDOK if you have specified the MB_OK or MB_OKCANCEL flag. The iDefault value should be
	/// set to IDYES if you have set the MB_YESNO flag.
	/// </para>
	/// <para><c>SHMessageBoxCheck</c> records the message boxes that the user has chosen to suppress under the following registry key.</para>
	/// <para><c>Software</c><c>Microsoft</c><c>Windows</c><c>CurrentVersion</c><c>Explorer</c><c>LowRegistry</c><c>DontShowMeThisDialogAgain</c></para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shmessageboxchecka int SHMessageBoxCheckA( HWND hwnd,
	// LPCSTR pszText, LPCSTR pszCaption, UINT uType, int iDefault, LPCSTR pszRegVal );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "7e62cde0-2b9f-44d3-afb8-5df71f98453a")]
	public static extern int SHMessageBoxCheck([Optional] HWND hwnd, string pszText, [Optional] string? pszCaption, uint uType, int iDefault, string pszRegVal);

	/// <summary>
	/// Opens a registry value and supplies a stream that can be used to read from or write to the value. This function supersedes SHOpenRegStream.
	/// </summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>Required. The subtree, such as HKEY_LOCAL_MACHINE, that contains the value.</para>
	/// </param>
	/// <param name="pszSubkey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>Optional. Pointer to a null-terminated string that specifies the subkey that contains the value. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>Pointer to a null-terminated string that specifies the value to be accessed. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="grfMode">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The type of access for the stream. This can be one of the following values:</para>
	/// <para>STGM_READ</para>
	/// <para>Open the stream for reading.</para>
	/// <para>STGM_WRITE</para>
	/// <para>Open the stream for writing.</para>
	/// <para>STGM_READWRITE</para>
	/// <para>Open the stream for reading and writing.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>IStream*</c></para>
	/// <para>
	/// Returns an IStream interface pointer if successful; otherwise, <c>NULL</c>. A <c>NULL</c> value can be caused by several situations,
	/// including an invalid <c>hkey</c> or <c>pszSubkey</c>, a subkey named by <c>pszSubkey</c> that does not exist, a caller without
	/// sufficient permissions to access the subkey, or an inability to open the stream.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The calling application is responsible for calling the Release method of the returned object when that IStream object is no longer needed.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The shlwapi.h header defines SHOpenRegStream2 as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/shlwapi/nf-shlwapi-shopenregstream2w
	// IStream * SHOpenRegStream2W( [in] HKEY hkey, [in, optional] LPCWSTR pszSubkey, [in, optional] LPCWSTR pszValue, [in] DWORD grfMode );
	[PInvokeData("shlwapi.h", MSDNShortId = "NF:shlwapi.SHOpenRegStream2W")]
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	public static extern IStream? SHOpenRegStream2(HKEY hkey, string? pszSubkey, string? pszValue, STGM grfMode);

	/// <summary>
	/// <para>Retrieves information about a specified registry key.</para>
	/// </summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to the currently open key, or any of the following predefined values.</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="pcSubKeys">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>The address of a <c>DWORD</c> that receives the number of subkeys under the specified key.</para>
	/// </param>
	/// <param name="pcchMaxSubKeyLen">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>The address of a <c>DWORD</c> that receives the number of characters in the name of the subkey with the largest name.</para>
	/// </param>
	/// <param name="pcValues">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>The address of a <c>DWORD</c> that receives the number of values under the specified key.</para>
	/// </param>
	/// <param name="pcchMaxValueNameLen">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>The address of a <c>DWORD</c> that receives the number of characters in the name of the value with the largest name.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a textual description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shqueryinfokeya LSTATUS SHQueryInfoKeyA( HKEY hkey,
	// LPDWORD pcSubKeys, LPDWORD pcchMaxSubKeyLen, LPDWORD pcValues, LPDWORD pcchMaxValueNameLen );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "dea535e7-5e61-4587-aa22-b1d62b76943a")]
	public static extern Win32Error SHQueryInfoKey(HKEY hkey, out uint pcSubKeys, out uint pcchMaxSubKeyLen, out uint pcValues, out uint pcchMaxValueNameLen);

	/// <summary>
	/// <para>Opens a registry key and queries it for a specific value.</para>
	/// </summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to the currently open key, or any of the following predefined values.</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The address of the <c>null</c>-terminated string that contains the name of the value to be queried.</para>
	/// </param>
	/// <param name="pdwReserved">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>Reserved. Must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pdwType">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>The address of the variable that receives the key's value type. For more information, see Registry Data Types.</para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>The address of the buffer that receives the value's data. This parameter can be <c>NULL</c> if the data is not required.</para>
	/// </param>
	/// <param name="pcbData">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// The address of the variable that specifies the size, in bytes, of the buffer pointed to by the pvData parameter. When the
	/// function returns, this variable contains the size of the data copied to pvData.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shqueryvalueexa LSTATUS SHQueryValueExA( HKEY hkey, LPCSTR
	// pszValue, DWORD *pdwReserved, DWORD *pdwType, void *pvData, DWORD *pcbData );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "9969acae-5965-40fe-bde9-6de9ddf26bb8")]
	public static extern Win32Error SHQueryValueEx(HKEY hkey, string pszValue, [Optional] IntPtr pdwReserved, out REG_VALUE_TYPE pdwType, [Optional] IntPtr pvData, ref uint pcbData);

	/// <summary>
	/// <para>Closes a handle to a user-specific registry subkey in a user-specific subtree (HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE).</para>
	/// </summary>
	/// <param name="hUSKey">
	/// <para>Type: <c>HUSKEY</c></para>
	/// <para>
	/// A handle to a currently open registry subkey. The subkey must have been opened with the KEY_SET_VALUE access right. For more
	/// information, see Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle can be obtained through the SHRegOpenUSKey function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. Use FormatMessage with the
	/// FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shregcloseuskey LSTATUS SHRegCloseUSKey( HUSKEY hUSKey );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "1e9900d6-8411-4e6b-a9c0-006f378a2625")]
	public static extern Win32Error SHRegCloseUSKey(HUSKEY hUSKey);

	/// <summary>
	/// <para>Creates or opens a registry subkey in a user-specific subtree (HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE).</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A pointer to a null-terminated string that contains the subkey to be created or opened. If a value with this name is already
	/// present in the subkey, it will be opened.
	/// </para>
	/// </param>
	/// <param name="samDesired">
	/// <para>Type: <c>REGSAM</c></para>
	/// <para>The desired security access. For more information on security access, see REGSAM.</para>
	/// </param>
	/// <param name="hRelativeUSKey">
	/// <para>Type: <c>HUSKEY</c></para>
	/// <para>
	/// The key to be used as a base for relative paths. If pszPath is a relative path, the key it specifies will be relative to
	/// hRelativeUSKey. If pszPath is an absolute path, set hRelativeUSKey to <c>NULL</c>. The key will then be created under
	/// <c>HKEY_LOCAL_MACHINE</c> or <c>HKEY_CURRENT_USER</c>, depending the value of dwFlags.
	/// </para>
	/// </param>
	/// <param name="phNewUSKey">
	/// <para>Type: <c>PHUSKEY</c></para>
	/// <para>A pointer to an <c>HUSKEY</c> that will receive the handle to the new key.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The base key under which the key should be opened. This can be one or more of the following values.</para>
	/// <para>SHREGSET_HKCU</para>
	/// <para>Create/open the key under <c>HKEY_CURRENT_USER</c>. Only creates a key if it is empty.</para>
	/// <para>SHREGSET_FORCE_HKCU</para>
	/// <para>Create/open the key under <c>HKEY_CURRENT_USER</c>. Creates a key even if it is not empty.</para>
	/// <para>SHREGSET_HKLM</para>
	/// <para>Create/open the key under <c>HKEY_LOCAL_MACHINE</c>. Only creates a key if it is empty.</para>
	/// <para>SHREGSET_FORCE_HKLM</para>
	/// <para>Create/open the key under <c>HKEY_LOCAL_MACHINE</c>. Creates a key even if it is not empty.</para>
	/// <para>SHREGSET_DEFAULT</para>
	/// <para>
	/// Create/open the key under both <c>HKEY_CURRENT_USER</c> (forced) and <c>HKEY_LOCAL_MACHINE</c> (only if empty). This flag is the
	/// equivalent of ( <c>SHREGSET_FORCE_HKCU</c> | <c>SHREGSET_HKLM</c>).
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If you want to write values to the new key, use SHRegWriteUSValue to write each value, passing the <c>HUSKEY</c> handle that is
	/// returned through phNewUSKey. When you have finished, close the user-specific registry key with SHRegCloseUSKey.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shregcreateuskeya LSTATUS SHRegCreateUSKeyA( LPCSTR
	// pszPath, REGSAM samDesired, HUSKEY hRelativeUSKey, PHUSKEY phNewUSKey, DWORD dwFlags );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "10e3e31e-bff6-4260-95fa-2d750de16ab3")]
	public static extern Win32Error SHRegCreateUSKey([Optional] string? pszPath, uint samDesired, [Optional] HUSKEY hRelativeUSKey, out SafeHUSKEY phNewUSKey, SHREGSET dwFlags);

	/// <summary>
	/// <para>Deletes an empty registry subkey in a user-specific subtree (HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE).</para>
	/// </summary>
	/// <param name="hUSKey">
	/// <para>Type: <c>HUSKEY</c></para>
	/// <para>
	/// A handle to a currently open registry subkey. The subkey must have been opened with the KEY_SET_VALUE access right. For more
	/// information, see Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle can be obtained through the SHRegOpenUSKey function.</para>
	/// </param>
	/// <param name="pszSubKey">
	/// <para>TBD</para>
	/// </param>
	/// <param name="delRegFlags">
	/// <para>Type: <c>SHREGDEL_FLAGS</c></para>
	/// <para>One of the SHREGDEL_FLAGS that specifies from which base key the subkey will be deleted.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shregdeleteemptyuskeya LSTATUS SHRegDeleteEmptyUSKeyA(
	// HUSKEY hUSKey, LPCSTR pszSubKey, SHREGDEL_FLAGS delRegFlags );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "adb09a2b-674c-472d-9f16-8e150476f1f5")]
	public static extern Win32Error SHRegDeleteEmptyUSKey(HUSKEY hUSKey, string pszSubKey, SHREGDEL_FLAGS delRegFlags);

	/// <summary>
	/// <para>Deletes a registry subkey value in a user-specific subtree (HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE).</para>
	/// </summary>
	/// <param name="hUSKey">
	/// <para>Type: <c>HUSKEY</c></para>
	/// <para>
	/// A handle to a currently open registry subkey. The subkey must have been opened with the KEY_SET_VALUE access right. For more
	/// information, see Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle can be obtained through the SHRegOpenUSKey function.</para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to the null-terminated string that names the value to remove.</para>
	/// </param>
	/// <param name="delRegFlags">
	/// <para>Type: <c>SHREGDEL_FLAGS</c></para>
	/// <para>One of the SHREGDEL_FLAGS that specifies from which base key the value will be deleted.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shregdeleteusvaluea LSTATUS SHRegDeleteUSValueA( HUSKEY
	// hUSKey, LPCSTR pszValue, SHREGDEL_FLAGS delRegFlags );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "f70407af-d8ee-4333-be32-01887d4add4c")]
	public static extern Win32Error SHRegDeleteUSValue(HUSKEY hUSKey, string pszValue, SHREGDEL_FLAGS delRegFlags);

	/// <summary>
	/// <para>Duplicates a registry key's HKEY handle.</para>
	/// </summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>The HKEY handle to be duplicated.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HKEY</c></para>
	/// <para>Returns a duplicate of the handle specified in hkey.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shregduplicatehkey HKEY SHRegDuplicateHKey( HKEY hkey );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "73182aa9-0c4d-4723-ba3c-8bab6b51181b")]
	public static extern SafeRegistryHandle SHRegDuplicateHKey(HKEY hkey);

	/// <summary>
	/// <para>Enumerates the subkeys of a registry subkey in a user-specific subtree (HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE).</para>
	/// </summary>
	/// <param name="hUSKey">
	/// <para>Type: <c>HUSKEY</c></para>
	/// <para>
	/// A handle to a currently open registry subkey. The subkey must have been opened with the KEY_SET_VALUE access right. For more
	/// information, see Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle can be obtained through the SHRegOpenUSKey function.</para>
	/// </param>
	/// <param name="dwIndex">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The index of the subkey to retrieve. This parameter should be zero for the first call and incremented for subsequent calls.</para>
	/// </param>
	/// <param name="pszName">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>A pointer to a character buffer that receives the enumerated key name.</para>
	/// </param>
	/// <param name="pcchName">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// A pointer to a DWORD that, on entry, contains the size of the buffer at pszName, in characters. On exit, this contains the number
	/// of characters that were copied to pszName.
	/// </para>
	/// </param>
	/// <param name="enumRegFlags">
	/// <para>Type: <c>SHREGENUM_FLAGS</c></para>
	/// <para>A SHREGENUM_FLAGS that specifies the base key in which the enumeration should take place.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a textual description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shregenumuskeya LSTATUS SHRegEnumUSKeyA( HUSKEY hUSKey,
	// DWORD dwIndex, LPSTR pszName, LPDWORD pcchName, SHREGENUM_FLAGS enumRegFlags );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "9418ad45-f451-4976-afd7-fa1e0088038d")]
	public static extern Win32Error SHRegEnumUSKey(HUSKEY hUSKey, uint dwIndex, StringBuilder pszName, ref uint pcchName, SHREGENUM_FLAGS enumRegFlags);

	/// <summary>Enumerates the values of the specified registry subkey in a user-specific subtree (HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE).</summary>
	/// <param name="hUSKey">
	/// <para>Type: <c>HUSKEY</c></para>
	/// <para>
	/// A handle to a currently open registry subkey. The subkey must have been opened with the KEY_SET_VALUE access right. For more
	/// information, see Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle can be obtained through the <c>SHRegOpenUSKey</c> function.</para>
	/// </param>
	/// <param name="dwIndex">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The index of the value to retrieve. This parameter should be zero for the first call and incremented for subsequent calls.</para>
	/// </param>
	/// <param name="pszValueName">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>A pointer to a character buffer that receives the enumerated value name. The size of this buffer is specified in pcchValueNameLen.</para>
	/// </param>
	/// <param name="pcchValueNameLen">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// A pointer to a <c>DWORD</c> that, on entry, contains the size of the buffer at pszValueName, in characters. On exit, this
	/// contains the number of characters that were copied to pszValueName.
	/// </para>
	/// </param>
	/// <param name="pdwType">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// A pointer to a <c>DWORD</c> that receives the data type of the value. These are the same values as those described under the
	/// lpType parameter of <c>RegEnumValue</c>.
	/// </para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>void*</c></para>
	/// <para>
	/// A pointer to a buffer that receives the data for the value entry. The size of this buffer is specified in pcbData. This parameter
	/// can be <c>NULL</c> if the data is not required.
	/// </para>
	/// </param>
	/// <param name="pcbData">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// A pointer to a <c>DWORD</c> that, on entry, contains the size of the buffer at pvData. On exit, this contains the number of bytes
	/// that were copied to pvData.
	/// </para>
	/// </param>
	/// <param name="enumRegFlags">
	/// <para>Type: <c><c>SHREGENUM_FLAGS</c></c></para>
	/// <para>One of the <c>SHREGENUM_FLAGS</c> that specifies the base key in which the enumeration should take place.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns <c>ERROR_SUCCESS</c> if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the
	/// <c>FormatMessage</c> function with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to retrieve a textual description of the error.
	/// </para>
	/// </returns>
	// https://msdn.microsoft.com/en-us/windows/desktop/bb773520
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("Shlwapi.h", MSDNShortId = "bb773520")]
	public static extern Win32Error SHRegEnumUSValue(HUSKEY hUSKey, uint dwIndex, StringBuilder pszValueName, ref uint pcchValueNameLen,
		out REG_VALUE_TYPE pdwType, [Optional] IntPtr pvData, ref uint pcbData, SHREGENUM_FLAGS enumRegFlags);

	/// <summary>
	/// <para>Retrieves a Boolean value from a registry subkey in a user-specific subtree (HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE).</para>
	/// </summary>
	/// <param name="pszSubKey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A pointer to a null-terminated string with the name of the subkey relative to <c>HKEY_LOCAL_MACHINE</c> and
	/// <c>HKEY_CURRENT_USER</c>. For example, "Software\MyCompany\MyProduct".
	/// </para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to a null-terminated string that specifies the name of the value. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="fIgnoreHKCU">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// A variable that specifies which key to look under. When set to <c>TRUE</c>, SHRegGetUSValue ignores <c>HKEY_CURRENT_USER</c> and
	/// returns a value from <c>HKEY_LOCAL_MACHINE</c>.
	/// </para>
	/// </param>
	/// <param name="fDefault">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>A value that is returned if there is no registry value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns either the value from the registry, or fDefault if none is found.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shreggetboolusvaluea BOOL SHRegGetBoolUSValueA( LPCSTR
	// pszSubKey, LPCSTR pszValue, BOOL fIgnoreHKCU, BOOL fDefault );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "afd95ce4-0ced-48ce-814f-1d02d7913be5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SHRegGetBoolUSValue(string pszSubKey, [Optional] string? pszValue, [MarshalAs(UnmanagedType.Bool)] bool fIgnoreHKCU, [MarshalAs(UnmanagedType.Bool)] bool fDefault);

	/// <summary>
	/// <para>[This function is no longer supported.]</para>
	/// <para>
	/// Evaluates a registry key value and returns a boolean value that reflects whether the value exists and the expected state matches
	/// the actual state. This function will first check HKEY_CURRENT_USER for the requested information in the specified subkey. If the
	/// information does not exist under the HKEY_CURRENT_USER subtree it will check the HKEY_LOCAL_MACHINE subtree for the same information.
	/// </para>
	/// </summary>
	/// <param name="pszKey">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>A pointer to a null-terminated Unicode string that specifies the path to the key to be checked.</para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>A pointer to a null-terminated Unicode string that specifies the value to be evaluated.</para>
	/// </param>
	/// <param name="fDefault">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>The expected state of the evaluation, as defined by the calling function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if the evaluation matches the fDefault value; otherwise, <c>FALSE</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shreggetboolvaluefromhkcuhklm BOOL
	// SHRegGetBoolValueFromHKCUHKLM( PCWSTR pszKey, PCWSTR pszValue, BOOL fDefault );
	[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "05239aef-a6cf-426f-919e-08b70baee3f8")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SHRegGetBoolValueFromHKCUHKLM(string pszKey, string pszValue, [MarshalAs(UnmanagedType.Bool)] bool fDefault);

	/// <summary>
	/// <para>Reads a numeric string value from the registry and converts it to an integer.</para>
	/// </summary>
	/// <param name="hk">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to the registry key that specifies the value to be read.</para>
	/// </param>
	/// <param name="pwzKey">
	/// <para>TBD</para>
	/// </param>
	/// <param name="iDefault">
	/// <para>TBD</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>Returns the converted string as an <c>int</c>, or the default value specified by nDefault.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Prior to Windows 2000 Service Pack 3 (SP3), Windows Server 2003 Service Pack 1 (SP1), and Windows XP, <c>SHRegGetIntW</c> was not
	/// exported by name. On those systems you must load it directly from Shlwapi.dll as ordinal 280.
	/// </para>
	/// <para>This function is only available in a Unicode version. ANSI is not supported.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shreggetintw int SHRegGetIntW( HKEY hk, PCWSTR pwzKey, int
	// iDefault );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "027e3470-46be-4d37-b815-e1fd550d0c60")]
	public static extern int SHRegGetIntW(IntPtr hk, [MarshalAs(UnmanagedType.LPWStr)] string pwzKey, int iDefault);

	/// <summary>
	/// <para>Retrieves a file path from the registry, expanding environment variables as needed.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>TBD</para>
	/// </param>
	/// <param name="pcszSubKey">
	/// <para>TBD</para>
	/// </param>
	/// <param name="pcszValue">
	/// <para>TBD</para>
	/// </param>
	/// <param name="pszPath">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// A buffer to hold the expanded path. You should set the size of this buffer to <c>MAX_PATH</c> to ensure that it is large enough
	/// to hold the returned string.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Reserved.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>Returns <c>ERROR_SUCCESS</c> if successful, or a Windows error code otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The data type of the specified registry value must be either <c>REG_EXPAND_SZ</c> or <c>REG_SZ</c>. If it has the
	/// <c>REG_EXPAND_SZ</c> type, any environment variables in the registry string will be expanded with ExpandEnvironmentStrings. If it
	/// has the <c>REG_SZ</c> data type, environment variables will not be expanded and the string pointed to by pszPath will be
	/// identical to the string in the registry.
	/// </para>
	/// <para>The following environment strings will be replaced by their equivalent path.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Environment string</term>
	/// <term>Folder</term>
	/// </listheader>
	/// <item>
	/// <term>%USERPROFILE%</term>
	/// <term>The current user's profile folder</term>
	/// </item>
	/// <item>
	/// <term>%ALLUSERSPROFILE%</term>
	/// <term>The All Users profile folder</term>
	/// </item>
	/// <item>
	/// <term>%ProgramFiles%</term>
	/// <term>The Program Files folder</term>
	/// </item>
	/// <item>
	/// <term>%SystemRoot%</term>
	/// <term>The system root folder</term>
	/// </item>
	/// <item>
	/// <term>%SystemDrive%</term>
	/// <term>The system drive letter</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> %USERPROFILE% is relative to the user making the call. This function does not work if the user is being impersonated
	/// from a service.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shreggetpatha LSTATUS SHRegGetPathA( HKEY hKey, LPCSTR
	// pcszSubKey, LPCSTR pcszValue, LPSTR pszPath, DWORD dwFlags );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "2874b868-33f9-4f20-9e0b-136125cf268c")]
	public static extern Win32Error SHRegGetPath(HKEY hKey, string pcszSubKey, string pcszValue, StringBuilder pszPath, uint dwFlags = 0);

	/// <summary>
	/// <para>Retrieves a value from a registry subkey in a user-specific subtree (HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE).</para>
	/// </summary>
	/// <param name="pszSubKey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A pointer to a null-terminated string with the name of the subkey relative to <c>HKEY_LOCAL_MACHINE</c> and
	/// <c>HKEY_CURRENT_USER</c>. For example: "Software\MyCompany\MyProduct".
	/// </para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to a null-terminated string with the name of the value. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pdwType">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>
	/// A pointer to a <c>DWORD</c> that receives the type of data stored in the retrieved value. When using default values, the input
	/// pdwType is the type of the default value. For possible values, see Registry Data Types. If type information is not required, this
	/// parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to a buffer that receives the value's data.</para>
	/// </param>
	/// <param name="pcbData">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>
	/// A pointer to a variable that specifies the size, in bytes, of the buffer pointed to by pvData. When <c>SHRegGetUSValue</c>
	/// returns, pcbData contains the size of the data copied to pvData.
	/// </para>
	/// </param>
	/// <param name="fIgnoreHKCU">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// A variable that specifies which key to look under. When set to <c>TRUE</c>, <c>SHRegGetUSValue</c> ignores
	/// <c>HKEY_CURRENT_USER</c> and returns the value from the key under <c>HKEY_LOCAL_MACHINE</c>.
	/// </para>
	/// </param>
	/// <param name="pvDefaultData">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to a buffer that receives the value's default data.</para>
	/// </param>
	/// <param name="dwDefaultDataSize">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The length, in bytes, of the buffer pointed to by pvDefaultData.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When fIgnoreHKCU is set to <c>TRUE</c>, <c>SHRegGetUSValue</c> returns the value from the key under <c>HKEY_LOCAL_MACHINE</c>.
	/// When set to <c>FALSE</c>, <c>SHRegGetUSValue</c> first tries to return the value from the key under <c>HKEY_CURRENT_USER</c>.
	/// However, if the key is not found under <c>HKEY_CURRENT_USER</c>, the value is returned from the key under
	/// <c>HKEY_LOCAL_MACHINE</c>. If neither key is present, or if an error occurred and dwDefaultDataSize is nonzero, then the default
	/// data is copied to pvData and ERROR_SUCCESS returns. ERROR_SUCCESS returns for both default and non-default data, and there is no
	/// way of distinguishing which value copies to pvData. To prevent the use of default data, set pvDefaultData to <c>NULL</c> and
	/// dwDefaultDataSize to zero.
	/// </para>
	/// <para>
	/// This function opens the key each time it is used. If your code involves getting a series of values from the same key, it is more
	/// efficient to open the key once with SHRegOpenUSKey and then use SHRegQueryUSValue to retrieve the data.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shreggetusvaluea LSTATUS SHRegGetUSValueA( LPCSTR
	// pszSubKey, LPCSTR pszValue, DWORD *pdwType, void *pvData, DWORD *pcbData, BOOL fIgnoreHKCU, void *pvDefaultData, DWORD
	// dwDefaultDataSize );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "4d3b3bbe-dc2e-40c9-8ff1-0f9d2e323743")]
	public static extern Win32Error SHRegGetUSValue(string pszSubKey, [Optional] string? pszValue, ref REG_VALUE_TYPE pdwType, [Optional] IntPtr pvData,
		ref uint pcbData, [MarshalAs(UnmanagedType.Bool)] bool fIgnoreHKCU, [Optional] IntPtr pvDefaultData, uint dwDefaultDataSize);

	/// <summary>
	/// <para>Retrieves a value from a registry subkey in a user-specific subtree (HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE).</para>
	/// </summary>
	/// <param name="pszSubKey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A pointer to a null-terminated string with the name of the subkey relative to <c>HKEY_LOCAL_MACHINE</c> and
	/// <c>HKEY_CURRENT_USER</c>. For example: "Software\MyCompany\MyProduct".
	/// </para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to a null-terminated string with the name of the value. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pdwType">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>
	/// A pointer to a <c>DWORD</c> that receives the type of data stored in the retrieved value. When using default values, the input
	/// pdwType is the type of the default value. For possible values, see Registry Data Types. If type information is not required, this
	/// parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to a buffer that receives the value's data.</para>
	/// </param>
	/// <param name="pcbData">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>
	/// A pointer to a variable that specifies the size, in bytes, of the buffer pointed to by pvData. When <c>SHRegGetUSValue</c>
	/// returns, pcbData contains the size of the data copied to pvData.
	/// </para>
	/// </param>
	/// <param name="fIgnoreHKCU">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// A variable that specifies which key to look under. When set to <c>TRUE</c>, <c>SHRegGetUSValue</c> ignores
	/// <c>HKEY_CURRENT_USER</c> and returns the value from the key under <c>HKEY_LOCAL_MACHINE</c>.
	/// </para>
	/// </param>
	/// <param name="pvDefaultData">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to a buffer that receives the value's default data.</para>
	/// </param>
	/// <param name="dwDefaultDataSize">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The length, in bytes, of the buffer pointed to by pvDefaultData.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When fIgnoreHKCU is set to <c>TRUE</c>, <c>SHRegGetUSValue</c> returns the value from the key under <c>HKEY_LOCAL_MACHINE</c>.
	/// When set to <c>FALSE</c>, <c>SHRegGetUSValue</c> first tries to return the value from the key under <c>HKEY_CURRENT_USER</c>.
	/// However, if the key is not found under <c>HKEY_CURRENT_USER</c>, the value is returned from the key under
	/// <c>HKEY_LOCAL_MACHINE</c>. If neither key is present, or if an error occurred and dwDefaultDataSize is nonzero, then the default
	/// data is copied to pvData and ERROR_SUCCESS returns. ERROR_SUCCESS returns for both default and non-default data, and there is no
	/// way of distinguishing which value copies to pvData. To prevent the use of default data, set pvDefaultData to <c>NULL</c> and
	/// dwDefaultDataSize to zero.
	/// </para>
	/// <para>
	/// This function opens the key each time it is used. If your code involves getting a series of values from the same key, it is more
	/// efficient to open the key once with SHRegOpenUSKey and then use SHRegQueryUSValue to retrieve the data.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shreggetusvaluea LSTATUS SHRegGetUSValueA( LPCSTR
	// pszSubKey, LPCSTR pszValue, DWORD *pdwType, void *pvData, DWORD *pcbData, BOOL fIgnoreHKCU, void *pvDefaultData, DWORD
	// dwDefaultDataSize );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "4d3b3bbe-dc2e-40c9-8ff1-0f9d2e323743")]
	public static extern Win32Error SHRegGetUSValue(string pszSubKey, [Optional] string? pszValue, ref REG_VALUE_TYPE pdwType, SafeAllocatedMemoryHandle pvData,
		ref uint pcbData, [MarshalAs(UnmanagedType.Bool)] bool fIgnoreHKCU, SafeAllocatedMemoryHandle pvDefaultData, uint dwDefaultDataSize);

	/// <summary>
	/// <para>
	/// [ <c>SHRegGetValue</c> may be altered or unavailable in subsequent versions of the operating system or product. Use RegGetValue
	/// in its place.]
	/// </para>
	/// <para>Retrieves a registry value.</para>
	/// </summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to the currently open key, or any of the following predefined values.</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="pszSubKey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A pointer to a <c>null</c>-terminated string that specifies the relative path from hkey to the subkey to retrieve the value from.
	/// This parameter can be <c>NULL</c> or an empty string, in which case the data is retrieved from the hkey location.
	/// </para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A pointer to a <c>null</c>-terminated string that contains the name of the value. This parameter can be <c>NULL</c> or an empty
	/// string, in which case the data is retrieved from the Default value.
	/// </para>
	/// </param>
	/// <param name="srrfFlags">
	/// <para>Type: <c>SRRF</c></para>
	/// <para>
	/// One or more of the SRRF flags that restricts the data to be retrieved. At least one type restriction (SRRF_RT) value must be specified.
	/// </para>
	/// </param>
	/// <param name="pdwType">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// A pointer to a <c>DWORD</c> that receives the type of data stored in the retrieved value. When using default values, the input
	/// pdwType is the type of the default value. For possible values, see Registry Data Types. If the SRRF_NOEXPAND flag is not set,
	/// REG_EXPAND_SZ types are automatically expanded and returned as REG_SZ. If type information is not required, this parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>
	/// A pointer to a buffer that receives the value's data. This parameter can be <c>NULL</c> if the data is not needed. For example,
	/// if you were testing only for a value's existence, the specific value data would be superfluous.
	/// </para>
	/// </param>
	/// <param name="pcbData">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// A pointer to a <c>DWORD</c> that, on entry, contains the size of the destination data buffer pvData, in bytes. This value can be
	/// <c>NULL</c> only if pvData is <c>NULL</c>. On exit, pcbData points to one of these values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>pvData</term>
	/// <term>Return Value</term>
	/// <term>pcbData</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>ERROR_SUCCESS</term>
	/// <term>
	/// Size in bytes sufficient to hold the registry data. Note that this is not guaranteed to be the precise size, but only a
	/// sufficient size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Non-NULL</term>
	/// <term>ERROR_SUCCESS</term>
	/// <term>Exact number of bytes written to pvData.</term>
	/// </item>
	/// <item>
	/// <term>Non-NULL</term>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// Size in bytes needed to hold the entire data. Note that this is not guaranteed to be the precise size, but only a sufficient size.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns <c>ERROR_SUCCESS</c> if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the
	/// FormatMessage function with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SHRegGetValue</c> provides data type checking, boot mode checking, auto-expansion of REG_EXPAND_SZ data, and guaranteed
	/// <c>null</c>-termination of REG_SZ, REG_EXPAND_SZ, and REG_MULTI_SZ data.
	/// </para>
	/// <para>
	/// The key identified by hkey must have been opened with KEY_QUERY_VALUE security access. If pszSubKey is not <c>NULL</c> or an
	/// empty string, that key also must be able to be opened with <c>KEY_QUERY_VALUE</c> security access in the current calling context.
	/// </para>
	/// <para>
	/// If the data's type is REG_SZ, REG_EXPAND_SZ or REG_MULTI_SZ, then any returned data includes or takes into account the string's
	/// <c>null</c>-termination. For example, if pvData is not <c>NULL</c>, the data returned in that buffer is <c>null</c>-terminated.
	/// If pcbData is not <c>NULL</c>, the buffer size that it points to includes the bytes required to hold the terminating <c>null</c> character.
	/// </para>
	/// <para>
	/// Unless the SRRF_NOEXPAND flag is set, string data of type REG_EXPAND_SZ is automatically expanded before being returned. The
	/// expanded string's type is reported in pdwType as REG_SZ, the pcbData parameter points to the number of bytes written for the
	/// expanded string, and the buffer pointed to by pvData holds the expanded version of the string.
	/// </para>
	/// <para>Performance Notes</para>
	/// <para>
	/// If pszSubKey is not <c>NULL</c> or an empty string, that key is opened and closed by this function each time it is accessed. If
	/// your application must retrieve a series of values from the same subkey, you will see better performance by opening the key using
	/// RegOpenKeyEx before calling <c>SHRegGetValue</c>. Use the key returned in the phkResult parameter of <c>RegOpenKeyEx</c> as the
	/// hkey parameter in this function, with pszSubKey set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// The potential for an additional call to the registry to read or re-read the data exists when the data type is REG_EXPAND_SZ and
	/// the SRRF_NOEXPAND flag has not been set. The following conditions result in that additional call.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// pvData is <c>NULL</c>, pcbData is not <c>NULL</c>. Though the data is not retrieved, the registry must be read to get the string
	/// and that string expanded to determine the required size of the data buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// pvData is not <c>NULL</c>, but is too small to hold the data. The data is re-read to get the full string, the string is expanded,
	/// and the total required size is determined.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shreggetvaluea LSTATUS SHRegGetValueA( HKEY hkey, LPCSTR
	// pszSubKey, LPCSTR pszValue, SRRF srrfFlags, DWORD *pdwType, void *pvData, DWORD *pcbData );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "5650eb4c-40fd-47d7-af76-2688d62d9bca")]
	public static extern Win32Error SHRegGetValue(HKEY hkey, [Optional] string? pszSubKey, [Optional] string? pszValue, SRRF srrfFlags,
		ref REG_VALUE_TYPE pdwType, IntPtr pvData, ref uint pcbData);

	/// <summary>
	/// <para>
	/// [ <c>SHRegGetValue</c> may be altered or unavailable in subsequent versions of the operating system or product. Use RegGetValue
	/// in its place.]
	/// </para>
	/// <para>Retrieves a registry value.</para>
	/// </summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to the currently open key, or any of the following predefined values.</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="pszSubKey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A pointer to a <c>null</c>-terminated string that specifies the relative path from hkey to the subkey to retrieve the value from.
	/// This parameter can be <c>NULL</c> or an empty string, in which case the data is retrieved from the hkey location.
	/// </para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A pointer to a <c>null</c>-terminated string that contains the name of the value. This parameter can be <c>NULL</c> or an empty
	/// string, in which case the data is retrieved from the Default value.
	/// </para>
	/// </param>
	/// <param name="srrfFlags">
	/// <para>Type: <c>SRRF</c></para>
	/// <para>
	/// One or more of the SRRF flags that restricts the data to be retrieved. At least one type restriction (SRRF_RT) value must be specified.
	/// </para>
	/// </param>
	/// <param name="pdwType">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// A pointer to a <c>DWORD</c> that receives the type of data stored in the retrieved value. When using default values, the input
	/// pdwType is the type of the default value. For possible values, see Registry Data Types. If the SRRF_NOEXPAND flag is not set,
	/// REG_EXPAND_SZ types are automatically expanded and returned as REG_SZ. If type information is not required, this parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>
	/// A pointer to a buffer that receives the value's data. This parameter can be <c>NULL</c> if the data is not needed. For example,
	/// if you were testing only for a value's existence, the specific value data would be superfluous.
	/// </para>
	/// </param>
	/// <param name="pcbData">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// A pointer to a <c>DWORD</c> that, on entry, contains the size of the destination data buffer pvData, in bytes. This value can be
	/// <c>NULL</c> only if pvData is <c>NULL</c>. On exit, pcbData points to one of these values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>pvData</term>
	/// <term>Return Value</term>
	/// <term>pcbData</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>ERROR_SUCCESS</term>
	/// <term>
	/// Size in bytes sufficient to hold the registry data. Note that this is not guaranteed to be the precise size, but only a
	/// sufficient size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Non-NULL</term>
	/// <term>ERROR_SUCCESS</term>
	/// <term>Exact number of bytes written to pvData.</term>
	/// </item>
	/// <item>
	/// <term>Non-NULL</term>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// Size in bytes needed to hold the entire data. Note that this is not guaranteed to be the precise size, but only a sufficient size.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns <c>ERROR_SUCCESS</c> if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the
	/// FormatMessage function with the <c>FORMAT_MESSAGE_FROM_SYSTEM</c> flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SHRegGetValue</c> provides data type checking, boot mode checking, auto-expansion of REG_EXPAND_SZ data, and guaranteed
	/// <c>null</c>-termination of REG_SZ, REG_EXPAND_SZ, and REG_MULTI_SZ data.
	/// </para>
	/// <para>
	/// The key identified by hkey must have been opened with KEY_QUERY_VALUE security access. If pszSubKey is not <c>NULL</c> or an
	/// empty string, that key also must be able to be opened with <c>KEY_QUERY_VALUE</c> security access in the current calling context.
	/// </para>
	/// <para>
	/// If the data's type is REG_SZ, REG_EXPAND_SZ or REG_MULTI_SZ, then any returned data includes or takes into account the string's
	/// <c>null</c>-termination. For example, if pvData is not <c>NULL</c>, the data returned in that buffer is <c>null</c>-terminated.
	/// If pcbData is not <c>NULL</c>, the buffer size that it points to includes the bytes required to hold the terminating <c>null</c> character.
	/// </para>
	/// <para>
	/// Unless the SRRF_NOEXPAND flag is set, string data of type REG_EXPAND_SZ is automatically expanded before being returned. The
	/// expanded string's type is reported in pdwType as REG_SZ, the pcbData parameter points to the number of bytes written for the
	/// expanded string, and the buffer pointed to by pvData holds the expanded version of the string.
	/// </para>
	/// <para>Performance Notes</para>
	/// <para>
	/// If pszSubKey is not <c>NULL</c> or an empty string, that key is opened and closed by this function each time it is accessed. If
	/// your application must retrieve a series of values from the same subkey, you will see better performance by opening the key using
	/// RegOpenKeyEx before calling <c>SHRegGetValue</c>. Use the key returned in the phkResult parameter of <c>RegOpenKeyEx</c> as the
	/// hkey parameter in this function, with pszSubKey set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// The potential for an additional call to the registry to read or re-read the data exists when the data type is REG_EXPAND_SZ and
	/// the SRRF_NOEXPAND flag has not been set. The following conditions result in that additional call.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// pvData is <c>NULL</c>, pcbData is not <c>NULL</c>. Though the data is not retrieved, the registry must be read to get the string
	/// and that string expanded to determine the required size of the data buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// pvData is not <c>NULL</c>, but is too small to hold the data. The data is re-read to get the full string, the string is expanded,
	/// and the total required size is determined.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shreggetvaluea LSTATUS SHRegGetValueA( HKEY hkey, LPCSTR
	// pszSubKey, LPCSTR pszValue, SRRF srrfFlags, DWORD *pdwType, void *pvData, DWORD *pcbData );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "5650eb4c-40fd-47d7-af76-2688d62d9bca")]
	public static extern Win32Error SHRegGetValue(HKEY hkey, [Optional] string? pszSubKey, [Optional] string? pszValue, SRRF srrfFlags,
		ref REG_VALUE_TYPE pdwType, SafeAllocatedMemoryHandle pvData, ref uint pcbData);

	/// <summary>
	/// <para>[This function is no longer supported.]</para>
	/// <para>
	/// Obtains specified information from the registry. This function will check HKEY_CURRENT_USER for the requested information in the
	/// specified subkey. If the information does not exist under the HKEY_CURRENT_USER subtree, the function checks the
	/// HKEY_LOCAL_MACHINE subtree for the same information.
	/// </para>
	/// </summary>
	/// <param name="pwszKey">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>A pointer to a <c>null</c>-terminated Unicode string that specifies the path to the registry key.</para>
	/// </param>
	/// <param name="pwszValue">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>
	/// A pointer to a <c>null</c>-terminated Unicode string that specifies the key value. This value can be <c>NULL</c>, in which case
	/// data is retrieved from the Default value.
	/// </para>
	/// </param>
	/// <param name="srrfFlags">
	/// <para>Type: <c>SRRF</c></para>
	/// <para>
	/// The SRRF flag constants. If more than one flag is used they can be combined using a bitwise OR. These flags are used to restrict
	/// the type of data returned. This value cannot be 0.
	/// </para>
	/// </param>
	/// <param name="pdwType">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>
	/// When this function returns, contains a pointer to a <c>DWORD</c> which receives a code that indicates the type of data stored in
	/// the specified value. This can be set to <c>NULL</c> if no type information is wanted. If this value is not <c>NULL</c>, and the
	/// SRRF_NOEXPAND flag has not been set, data types of REG_EXPAND_SZ will be returned as REG_SZ since they are automatically expanded
	/// in this method.
	/// </para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>
	/// A pointer to a buffer that contains the value's data. This parameter can be <c>NULL</c> if the data is not needed. This value
	/// must contain the size of the pvData buffer on entry. If pvData is <c>NULL</c> (or if pvData is not <c>NULL</c>, but too small of
	/// a buffer to hold the registry data), then on exit it will contain the size required to hold the registry data.
	/// </para>
	/// </param>
	/// <param name="pcbData">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>When this function returns, contains a pointer to the size of the data, in bytes.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If successful, this function returns ERROR_SUCCESS and all out parameters requested. Returns ERROR_MORE_DATA if the function
	/// fails due to insufficient space in a provided non- <c>NULL</c> pvData. In this case only pdwType and pcbData may contain valid
	/// data, pvData will be undefined. Otherwise, returns a nonzero error code defined in Winerror.h . You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shreggetvaluefromhkcuhklm LSTATUS
	// SHRegGetValueFromHKCUHKLM( PCWSTR pwszKey, PCWSTR pwszValue, SRRF srrfFlags, DWORD *pdwType, void *pvData, DWORD *pcbData );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "5c4b13f4-0dd8-476e-9e89-ace23d541389")]
	public static extern Win32Error SHRegGetValueFromHKCUHKLM(string pwszKey, [Optional] string? pwszValue, SRRF srrfFlags, ref REG_VALUE_TYPE pdwType, [Optional] IntPtr pvData, ref uint pcbData);

	/// <summary>
	/// <para>[This function is no longer supported.]</para>
	/// <para>
	/// Obtains specified information from the registry. This function will check HKEY_CURRENT_USER for the requested information in the
	/// specified subkey. If the information does not exist under the HKEY_CURRENT_USER subtree, the function checks the
	/// HKEY_LOCAL_MACHINE subtree for the same information.
	/// </para>
	/// </summary>
	/// <param name="pwszKey">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>A pointer to a <c>null</c>-terminated Unicode string that specifies the path to the registry key.</para>
	/// </param>
	/// <param name="pwszValue">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>
	/// A pointer to a <c>null</c>-terminated Unicode string that specifies the key value. This value can be <c>NULL</c>, in which case
	/// data is retrieved from the Default value.
	/// </para>
	/// </param>
	/// <param name="srrfFlags">
	/// <para>Type: <c>SRRF</c></para>
	/// <para>
	/// The SRRF flag constants. If more than one flag is used they can be combined using a bitwise OR. These flags are used to restrict
	/// the type of data returned. This value cannot be 0.
	/// </para>
	/// </param>
	/// <param name="pdwType">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>
	/// When this function returns, contains a pointer to a <c>DWORD</c> which receives a code that indicates the type of data stored in
	/// the specified value. This can be set to <c>NULL</c> if no type information is wanted. If this value is not <c>NULL</c>, and the
	/// SRRF_NOEXPAND flag has not been set, data types of REG_EXPAND_SZ will be returned as REG_SZ since they are automatically expanded
	/// in this method.
	/// </para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>
	/// A pointer to a buffer that contains the value's data. This parameter can be <c>NULL</c> if the data is not needed. This value
	/// must contain the size of the pvData buffer on entry. If pvData is <c>NULL</c> (or if pvData is not <c>NULL</c>, but too small of
	/// a buffer to hold the registry data), then on exit it will contain the size required to hold the registry data.
	/// </para>
	/// </param>
	/// <param name="pcbData">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>When this function returns, contains a pointer to the size of the data, in bytes.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If successful, this function returns ERROR_SUCCESS and all out parameters requested. Returns ERROR_MORE_DATA if the function
	/// fails due to insufficient space in a provided non- <c>NULL</c> pvData. In this case only pdwType and pcbData may contain valid
	/// data, pvData will be undefined. Otherwise, returns a nonzero error code defined in Winerror.h . You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shreggetvaluefromhkcuhklm LSTATUS
	// SHRegGetValueFromHKCUHKLM( PCWSTR pwszKey, PCWSTR pwszValue, SRRF srrfFlags, DWORD *pdwType, void *pvData, DWORD *pcbData );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "5c4b13f4-0dd8-476e-9e89-ace23d541389")]
	public static extern Win32Error SHRegGetValueFromHKCUHKLM(string pwszKey, [Optional] string? pwszValue, SRRF srrfFlags, ref REG_VALUE_TYPE pdwType, SafeAllocatedMemoryHandle pvData, ref uint pcbData);

	/// <summary>
	/// <para>Opens a registry subkey in a user-specific subtree (HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE).</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>TBD</para>
	/// </param>
	/// <param name="samDesired">
	/// <para>Type: <c>REGSAM</c></para>
	/// <para>The desired security access. For more information on security access, see REGSAM.</para>
	/// </param>
	/// <param name="hRelativeUSKey">
	/// <para>Type: <c>HUSKEY</c></para>
	/// <para>
	/// The key to be used as a base for relative paths. If pszPath is a relative path, the key it specifies will be relative to
	/// hRelativeUSKey. If pszPath is an absolute path, set hRelativeUSKey to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="phNewUSKey">
	/// <para>Type: <c>PHUSKEY</c></para>
	/// <para>A pointer to the handle of the opened key.</para>
	/// </param>
	/// <param name="fIgnoreHKCU">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// The variable that specifies which key to look under. When set to <c>TRUE</c>, <c>SHRegOpenUSKey</c> ignores
	/// <c>HKEY_CURRENT_USER</c> and returns a value from <c>HKEY_LOCAL_MACHINE</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shregopenuskeya LSTATUS SHRegOpenUSKeyA( LPCSTR pszPath,
	// REGSAM samDesired, HUSKEY hRelativeUSKey, PHUSKEY phNewUSKey, BOOL fIgnoreHKCU );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "756430a9-a495-412e-95c3-a93222bc467a")]
	public static extern Win32Error SHRegOpenUSKey(string pszPath, uint samDesired, [Optional] HUSKEY hRelativeUSKey, out SafeHUSKEY phNewUSKey, [MarshalAs(UnmanagedType.Bool)] bool fIgnoreHKCU);

	/// <summary>
	/// <para>Retrieves information about a specified registry subkey in a user-specific subtree (HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE).</para>
	/// </summary>
	/// <param name="hUSKey">
	/// <para>Type: <c>HUSKEY</c></para>
	/// <para>
	/// A handle to a currently open registry subkey. The subkey must have been opened with the KEY_SET_VALUE access right. For more
	/// information, see Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle can be obtained through the SHRegOpenUSKey function.</para>
	/// </param>
	/// <param name="pcSubKeys">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>A pointer to a <c>DWORD</c> that receives the number of subkeys under the specified key.</para>
	/// </param>
	/// <param name="pcchMaxSubKeyLen">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>A pointer to a <c>DWORD</c> that receives the number of characters in the largest subkey name.</para>
	/// </param>
	/// <param name="pcValues">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>A pointer to a <c>DWORD</c> that receives the number of values under the specified key.</para>
	/// </param>
	/// <param name="pcchMaxValueNameLen">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>A pointer to a <c>DWORD</c> that receives the number of characters in the largest value name.</para>
	/// </param>
	/// <param name="enumRegFlags">
	/// <para>Type: <c>SHREGENUM_FLAGS</c></para>
	/// <para>One of the SHREGENUM_FLAGS that specifies the base key in which the query should take place.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a textual description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shregqueryinfouskeya LSTATUS SHRegQueryInfoUSKeyA( HUSKEY
	// hUSKey, LPDWORD pcSubKeys, LPDWORD pcchMaxSubKeyLen, LPDWORD pcValues, LPDWORD pcchMaxValueNameLen, SHREGENUM_FLAGS enumRegFlags );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "e47b4fad-50c7-43d7-82f2-6a835ac543f0")]
	public static extern Win32Error SHRegQueryInfoUSKey(HUSKEY hUSKey, out uint pcSubKeys, out uint pcchMaxSubKeyLen, out uint pcValues, out uint pcchMaxValueNameLen, SHREGENUM_FLAGS enumRegFlags);

	/// <summary>
	/// <para>
	/// Retrieves the type and data for a specified name associated with an open registry subkey in a user-specific subtree
	/// (HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE).
	/// </para>
	/// </summary>
	/// <param name="hUSKey">
	/// <para>Type: <c>HUSKEY</c></para>
	/// <para>
	/// A handle to a currently open registry subkey, or one of the following predefined values. The subkey must have been opened with
	/// the KEY_SET_VALUE access right. For more information, see Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle can be obtained through the SHRegOpenUSKey function.</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to the <c>null</c>-terminated string that contains the name of the value to be queried.</para>
	/// </param>
	/// <param name="pdwType">
	/// <para>Type: <c>LPDWORD*</c></para>
	/// <para>
	/// A pointer to the variable that sets or receives the key's value type. For more information, see Registry Data Types. This
	/// parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>LPVOID*</c></para>
	/// <para>A pointer to the buffer that receives the value's data. This parameter can be <c>NULL</c> if the data is not required.</para>
	/// </param>
	/// <param name="pcbData">
	/// <para>Type: <c>LPDWORD*</c></para>
	/// <para>
	/// A pointer to the variable that specifies the size, in bytes, of the buffer pointed to by the pvData parameter. When the function
	/// returns, this variable contains the size of the data copied to pvData.
	/// </para>
	/// </param>
	/// <param name="fIgnoreHKCU">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// The variable that specifies which key to look under. When set to <c>TRUE</c>, <c>SHRegQueryUSValue</c> ignores
	/// <c>HKEY_CURRENT_USER</c> and returns the value from the key under <c>HKEY_LOCAL_MACHINE</c>.
	/// </para>
	/// </param>
	/// <param name="pvDefaultData">
	/// <para>Type: <c>LPVOID*</c></para>
	/// <para>A pointer to the default data.</para>
	/// </param>
	/// <param name="dwDefaultDataSize">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The length, in bytes, of the default data.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When fIgnoreHKCU is set to <c>TRUE</c>, <c>SHRegQueryUSValue</c> returns the value from the key under <c>HKEY_LOCAL_MACHINE</c>.
	/// When set to <c>FALSE</c>, <c>SHRegQueryUSValue</c> first tries to return the value from the key under <c>HKEY_CURRENT_USER</c>.
	/// However, if the key is not found under <c>HKEY_CURRENT_USER</c>, the value returns from the key under <c>HKEY_LOCAL_MACHINE</c>.
	/// If neither key is present, or if an error occurs and dwDefaultDataSize is nonzero, then the default data is copied to pvData and
	/// ERROR_SUCCESS returns. ERROR_SUCCESS returns for both default and non-default data, and there is no way of distinguishing which
	/// value copies to pvData. To prevent the use of default data, set pvDefaultData to <c>NULL</c> and dwDefaultDataSize to zero.
	/// </para>
	/// <para>
	/// If you only need to read a single value, SHRegGetUSValue will both open the key and return the value. To use
	/// <c>SHRegQueryUSValue</c>, you must first open the key with SHRegOpenUSKey. However, once the key is opened, you can use
	/// <c>SHRegQueryUSValue</c> as many times as necessary. If you need to retrieve more than one value from the same key, using
	/// multiple calls to <c>SHRegQueryUSValue</c> is usually more efficient than <c>SHRegGetUSValue</c>, as the key is only opened once.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shregqueryusvaluea LSTATUS SHRegQueryUSValueA( HUSKEY
	// hUSKey, LPCSTR pszValue, DWORD *pdwType, void *pvData, DWORD *pcbData, BOOL fIgnoreHKCU, void *pvDefaultData, DWORD
	// dwDefaultDataSize );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "302a51b5-9cf9-46e5-908c-df0d3c31c91c")]
	public static extern Win32Error SHRegQueryUSValue(HUSKEY hUSKey, string pszValue, ref REG_VALUE_TYPE pdwType, [Optional] IntPtr pvData,
		ref uint pcbData, [MarshalAs(UnmanagedType.Bool)] bool fIgnoreHKCU, [Optional] IntPtr pvDefaultData, [Optional] uint dwDefaultDataSize);

	/// <summary>
	/// <para>Takes a file path, replaces folder names with environment strings, and places the resulting string in the registry.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to a key that is currently open, or a registry root key.</para>
	/// </param>
	/// <param name="pcszSubKey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// A pointer to a null-terminated string containing the name of an existing subkey. If the subkey does not exist,
	/// <c>SHRegSetPath</c> will fail.
	/// </para>
	/// </param>
	/// <param name="pcszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to a null-terminated string with the name of the value to hold the path string.</para>
	/// </param>
	/// <param name="pcszPath">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to a null-terminated string with a fully qualified file path.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Reserved.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>Returns ERROR_SUCCESS if successful, or a Windows error code otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For Windows 2000, <c>SHRegSetPath</c> uses PathUnExpandEnvStrings to convert folder names to their corresponding environment
	/// string. If any environment variables were substituted, the registry value will be set with the <c>REG_EXPAND_SZ</c> data type.
	/// Otherwise, it will be set with the <c>REG_SZ</c> data type.
	/// </para>
	/// <para>The following folder paths will be replaced by their equivalent environment string.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Folder</term>
	/// <term>Environment string</term>
	/// </listheader>
	/// <item>
	/// <term>The current user's profile folder</term>
	/// <term>%USERPROFILE%</term>
	/// </item>
	/// <item>
	/// <term>The All Users profile folder</term>
	/// <term>%ALLUSERSPROFILE%</term>
	/// </item>
	/// <item>
	/// <term>The Program Files folder</term>
	/// <term>%ProgramFiles%</term>
	/// </item>
	/// <item>
	/// <term>The system root folder</term>
	/// <term>%SystemRoot%</term>
	/// </item>
	/// <item>
	/// <term>The system drive letter</term>
	/// <term>%SystemDrive%</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> %USERPROFILE% is relative to the user making the call. This function does not work if the user is being impersonated
	/// from a service.
	/// </para>
	/// <para>
	/// The environment variables listed in the above table might not all be set on any particular system. If an environment variable is
	/// not set, it will not be unexpanded. In particular, none of these variables are set for the default environment of Windows 95 or
	/// Windows 98. The %ProgramFiles% variable is new for Windows 2000, and will typically not be set on Microsoft Windows NT 4.0 systems.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shregsetpatha LSTATUS SHRegSetPathA( HKEY hKey, LPCSTR
	// pcszSubKey, LPCSTR pcszValue, LPCSTR pcszPath, DWORD dwFlags );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "3ee6ec69-5d16-4bdd-a591-651af05bf944")]
	public static extern Win32Error SHRegSetPath(HKEY hKey, string pcszSubKey, string pcszValue, string pcszPath, uint dwFlags = 0);

	/// <summary>
	/// <para>Sets a registry subkey value in a user-specific subtree (HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE).</para>
	/// </summary>
	/// <param name="pszSubKey">
	/// <para>TBD</para>
	/// </param>
	/// <param name="pszValue">
	/// <para>TBD</para>
	/// </param>
	/// <param name="dwType">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Type of data to be stored. This parameter must be the <c>REG_SZ</c> type. For more information, see Registry Data Types.</para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>LPVOID*</c></para>
	/// <para>Apointer to a null-terminated string that contains the value to be set for the specified key.</para>
	/// </param>
	/// <param name="cbData">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Length, in bytes, of the string pointed to by the pvData parameter, not including the terminating null character.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Flags indicating where the data should be written.</para>
	/// <para>SHREGSET_HKCU</para>
	/// <para>Write to <c>HKEY_CURRENT_USER</c> if empty.</para>
	/// <para>SHREGSET_FORCE_HKCU</para>
	/// <para>Write to <c>HKEY_CURRENT_USER</c>.</para>
	/// <para>SHREGSET_HKLM</para>
	/// <para>Write to <c>HKEY_LOCAL_MACHINE</c> if empty.</para>
	/// <para>SHREGSET_FORCE_HKLM</para>
	/// <para>Write to <c>HKEY_LOCAL_MACHINE</c>.</para>
	/// <para>SHREGSET_DEFAULT</para>
	/// <para>Equivalent to ( <c>SHREGSET_FORCE_HKCU</c> | <c>SHREGSET_HKLM</c>).</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful, or a nonzero error code defined in Winerror.h otherwise. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function opens the key each time it is used. If your code involves setting a series of values in the same key, it is more
	/// efficient to open the key once with SHRegOpenUSKey and then use SHRegWriteUSValue to write the data.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shregsetusvaluea LSTATUS SHRegSetUSValueA( LPCSTR
	// pszSubKey, LPCSTR pszValue, DWORD dwType, const void *pvData, DWORD cbData, DWORD dwFlags );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "96559f8c-8527-4924-928e-f27049069407")]
	public static extern Win32Error SHRegSetUSValue(string pszSubKey, string pszValue, REG_VALUE_TYPE dwType, IntPtr pvData, uint cbData, SHREGSET dwFlags);

	/// <summary>
	/// <para>Writes a value to a registry subkey in a user-specific subtree (HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE).</para>
	/// </summary>
	/// <param name="hUSKey">
	/// <para>Type: <c>HUSKEY</c></para>
	/// <para>
	/// A handle to a currently open registry subkey. The subkey must have been opened with the KEY_SET_VALUE access right. For more
	/// information, see Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle can be obtained through the SHRegOpenUSKey function.</para>
	/// </param>
	/// <param name="pszValue">
	/// <para>TBD</para>
	/// </param>
	/// <param name="dwType">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The type of the data to be stored in the value specified by pszValue. One of the following registry value types defined in
	/// Winnt.h and Wdm.h.
	/// </para>
	/// <para>REG_NONE (0x00000000)</para>
	/// <para>REG_SZ (0x00000001)</para>
	/// <para>REG_EXPAND_SZ (0x00000002)</para>
	/// <para>REG_BINARY (0x00000003)</para>
	/// <para>REG_DWORD (0x00000004)</para>
	/// <para>REG_DWORD_LITTLE_ENDIAN (0x00000004)</para>
	/// <para>REG_DWORD_BIG_ENDIAN (0x00000005)</para>
	/// <para>REG_LINK (0x00000006)</para>
	/// <para>REG_MULTI_SZ (0x00000007)</para>
	/// <para>REG_RESOURCE_LIST (0x00000008)</para>
	/// <para>REG_FULL_RESOURCE_DESCRIPTOR (0x00000009)</para>
	/// <para>REG_RESOURCE_REQUIREMENTS_LIST (0x0000000A)</para>
	/// <para>REG_QWORD (0x0000000B)</para>
	/// <para>REG_QWORD_LITTLE_ENDIAN (0x0000000B)</para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>const void*</c></para>
	/// <para>
	/// A pointer to the data to be set for the value specified by pszValue. For string-based types, such as REG_SZ, the string must be
	/// null-terminated. With the REG_MULTI_SZ data type, the string must be terminated with two null characters. A backslash in a path
	/// must be preceded by another backslash as an escape character. For example, specify "C:\mydir\myfile" to store the string "C:\mydir\myfile".
	/// </para>
	/// </param>
	/// <param name="cbData">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The size, in bytes, of the data pointed to by the pvData parameter. If the data is of type REG_SZ, REG_EXPAND_SZ, or
	/// REG_MULTI_SZ, cbData must include the size of the terminating null character or characters.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Flags that indicate the subtree to which the data should be written. One or more of the following values:</para>
	/// <para>SHREGSET_HKCU (0x00000001)</para>
	/// <para>
	/// Write to <c>HKEY_CURRENT_USER</c> only if a value of the name specified in pszValue does not currently exist under the specified subkey.
	/// </para>
	/// <para>SHREGSET_FORCE_HKCU (0x00000002)</para>
	/// <para>Write to <c>HKEY_CURRENT_USER</c>. If a value of the name specified in pszValue already exists, it will be overwritten.</para>
	/// <para>SHREGSET_HKLM (0x00000004)</para>
	/// <para>
	/// Write to <c>HKEY_LOCAL_MACHINE</c> only if a value of the name specified in pszValue does not currently exist under the specified subkey..
	/// </para>
	/// <para>SHREGSET_FORCE_HKLM (0x00000008)</para>
	/// <para>Write to <c>HKEY_LOCAL_MACHINE</c>. If a value of the name specified in pszValue already exists, it will be overwritten.</para>
	/// <para>SHREGSET_DEFAULT (0x00000006)</para>
	/// <para>Equivalent to ( <c>SHREGSET_FORCE_HKCU</c> | <c>SHREGSET_HKLM</c>).</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful; otherwise, a nonzero error code defined in Winerror.h. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use <c>SHRegWriteUSValue</c>, you must first open the key with SHRegOpenUSKey. Once the key is opened, you can use
	/// <c>SHRegWriteUSValue</c> as many times as necessary.
	/// </para>
	/// <para>If you only need to write a single value, you should use SHRegSetUSValue, which both opens the key and writes the value.</para>
	/// <para>
	/// If you need to write more than one value on the same key, multiple calls to <c>SHRegWriteUSValue</c> are usually more efficient
	/// than SHRegSetUSValue, because the key is only opened once.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shregwriteusvaluea LSTATUS SHRegWriteUSValueA( HUSKEY
	// hUSKey, LPCSTR pszValue, DWORD dwType, const void *pvData, DWORD cbData, DWORD dwFlags );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "f94569c6-415b-4263-bab4-8a5baca47901")]
	public static extern Win32Error SHRegWriteUSValue(HUSKEY hUSKey, string? pszValue, REG_VALUE_TYPE dwType, IntPtr pvData, uint cbData, SHREGSET dwFlags);

	/// <summary>
	/// <para>Releases a thread reference before the thread procedure returns.</para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shreleasethreadref LWSTDAPI SHReleaseThreadRef( );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "7f3fd09b-baad-4019-a060-c68727aee61f")]
	public static extern HRESULT SHReleaseThreadRef();

	/// <summary>
	/// <para>
	/// [This function is available through Windows XP and Windows Server 2003. It might be altered or unavailable in subsequent versions
	/// of Windows.]
	/// </para>
	/// <para>Sends a message to all top-level windows in the system.</para>
	/// </summary>
	/// <param name="uMsg">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The message to send.</para>
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
	/// <para>The return value is not meaningful.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SHSendMessageBroadcast</c> is equivalent to SendMessage with <c>HWND_BROADCAST</c>. To avoid causing the Shell to become
	/// unresponsive in the case where there could be a window in the system that is not responding to messages, use <c>SHSendMessageBroadcast</c>.
	/// </para>
	/// <para>
	/// <c>SHSendMessageBroadcast</c> is not exported by name. <c>SHSendMessageBroadcastA</c> is exported from Shlwapi.dll as ordinal
	/// 432. <c>SHSendMessageBroadcastW</c> is exported from Shlwapi.dll as ordinal 433.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shsendmessagebroadcasta LRESULT SHSendMessageBroadcastA(
	// UINT uMsg, WPARAM wParam, LPARAM lParam );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "98671f0f-2386-486f-ac96-14dd44c776c6")]
	public static extern IntPtr SHSendMessageBroadcast(uint uMsg, IntPtr wParam, IntPtr lParam);

	/// <summary>
	/// <para>
	/// Stores a per-thread reference to a Component Object Model (COM) object. This allows the caller to control the thread's lifetime
	/// so that it can ensure that Windows won't shut down the thread before the caller is ready.
	/// </para>
	/// </summary>
	/// <param name="punk">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>A pointer to the IUnknown of the object for which you want to store a reference. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>Use SHGetThreadRef to retrieve the IUnknown pointer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shsetthreadref LWSTDAPI SHSetThreadRef( IUnknown *punk );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "1d0d70ca-a0e6-4620-9a01-8d4986990b9c")]
	public static extern HRESULT SHSetThreadRef([MarshalAs(UnmanagedType.IUnknown)] object? punk);

	/// <summary>
	/// <para>Sets the value of a registry key.</para>
	/// </summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to the currently open key, or any of the following predefined values.</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="pszSubKey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The address of a null-terminated string that specifies the name of the subkey with which a value is associated. This can be
	/// <c>NULL</c> or a pointer to an empty string. In this case, the value is added to the key identified by the hkey parameter.
	/// </para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The address of a null-terminated string that specifies the value. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="dwType">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Type of data to be stored. This parameter must be the <c>REG_SZ</c> type. For more information, see Registry Data Types.</para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>Pointer to a buffer that contains the data to set for the specified value. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="cbData">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// Length, in bytes, of the buffer pointed to by the pvData parameter. If the data is a null-terminated string, this length includes
	/// the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful; otherwise, a nonzero error code defined in Winerror.h. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shsetvaluea LSTATUS SHSetValueA( HKEY hkey, LPCSTR
	// pszSubKey, LPCSTR pszValue, DWORD dwType, LPCVOID pvData, DWORD cbData );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "6cd5b7fd-8fb9-4c24-9670-20c23ca709bf")]
	public static extern Win32Error SHSetValue(HKEY hkey, [Optional] string? pszSubKey, [Optional] string? pszValue, REG_VALUE_TYPE dwType, [Optional] IntPtr pvData, [Optional] uint cbData);

	/// <summary>
	/// <para>Sets the value of a registry key.</para>
	/// </summary>
	/// <param name="hkey">
	/// <para>Type: <c>HKEY</c></para>
	/// <para>A handle to the currently open key, or any of the following predefined values.</para>
	/// <para>HKEY_CLASSES_ROOT</para>
	/// <para>HKEY_CURRENT_CONFIG</para>
	/// <para>HKEY_CURRENT_USER</para>
	/// <para>HKEY_LOCAL_MACHINE</para>
	/// <para>HKEY_PERFORMANCE_DATA</para>
	/// <para>HKEY_USERS</para>
	/// </param>
	/// <param name="pszSubKey">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The address of a null-terminated string that specifies the name of the subkey with which a value is associated. This can be
	/// <c>NULL</c> or a pointer to an empty string. In this case, the value is added to the key identified by the hkey parameter.
	/// </para>
	/// </param>
	/// <param name="pszValue">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The address of a null-terminated string that specifies the value. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="dwType">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Type of data to be stored. This parameter must be the <c>REG_SZ</c> type. For more information, see Registry Data Types.</para>
	/// </param>
	/// <param name="pvData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>Pointer to a buffer that contains the data to set for the specified value. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="cbData">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// Length, in bytes, of the buffer pointed to by the pvData parameter. If the data is a null-terminated string, this length includes
	/// the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LSTATUS</c></para>
	/// <para>
	/// Returns ERROR_SUCCESS if successful; otherwise, a nonzero error code defined in Winerror.h. You can use the FormatMessage
	/// function with the FORMAT_MESSAGE_FROM_SYSTEM flag to retrieve a generic description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shsetvaluea LSTATUS SHSetValueA( HKEY hkey, LPCSTR
	// pszSubKey, LPCSTR pszValue, DWORD dwType, LPCVOID pvData, DWORD cbData );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "6cd5b7fd-8fb9-4c24-9670-20c23ca709bf")]
	public static extern Win32Error SHSetValue(HKEY hkey, [Optional] string? pszSubKey, [Optional] string? pszValue, REG_VALUE_TYPE dwType, SafeAllocatedMemoryHandle pvData, uint cbData);

	/// <summary>
	/// <para>Checks a bind context to see if it is safe to bind to a particular component object.</para>
	/// </summary>
	/// <param name="pbc">
	/// <para>Type: <c>IBindCtx*</c></para>
	/// <para>A pointer to an IBindCtx interface that specifies the bind context you want to check. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pclsid">
	/// <para>Type: <c>const CLSID*</c></para>
	/// <para>
	/// A pointer to a variable that specifies the <c>CLSID</c> of the object being tested to see if it must be skipped. Typically, this
	/// is the CLSID of the object that IShellFolder::BindToObject is about to create.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns <c>TRUE</c> if the object specified by pclsid must be skipped, or <c>FALSE</c> otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function can be used to avoid infinite cycles in namespace binding. For example, a folder shortcut that refers to a folder
	/// above it in the namespace tree can produce an infinitely recursive loop.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shskipjunction BOOL SHSkipJunction( IBindCtx *pbc, const
	// CLSID *pclsid );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "73af64a4-57eb-43db-91bb-75fe7134ad28")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SHSkipJunction(IBindCtx pbc, in Guid pclsid);

	/// <summary>
	/// <para>Makes a copy of a string in newly allocated memory.</para>
	/// </summary>
	/// <param name="psz">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to the null-terminated string to be copied.</para>
	/// </param>
	/// <param name="ppwsz">
	/// <para>Type: <c>LPTSTR*</c></para>
	/// <para>
	/// A pointer to an allocated Unicode string that contains the result. <c>SHStrDup</c> allocates memory for this string with
	/// CoTaskMemAlloc. You should free the string with CoTaskMemFree when it is no longer needed.
	/// </para>
	/// <para>In the case of failure, this value is NULL.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns S_OK if successful, or a COM error value otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function will take either Unicode or ANSI strings as input, but the copied string is always Unicode.</para>
	/// <para>
	/// This function uses CoTaskMemAlloc to allocate memory for the copied string. You must free this memory with CoTaskMemFree when it
	/// is no longer needed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shstrdupa LWSTDAPI SHStrDupA( LPCSTR psz, LPWSTR *ppwsz );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "6f014fb4-7637-48a8-9bec-d3278c46a6d8")]
	public static extern HRESULT SHStrDup(string psz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler), MarshalCookie = "Auto")] out string? ppwsz);

	/// <summary>
	/// <para>
	/// [This function is available through Windows XP and Windows Server 2003. It might be altered or unavailable in subsequent versions
	/// of Windows.]
	/// </para>
	/// <para>Removes the mnemonic marker from a string.</para>
	/// </summary>
	/// <param name="pszMenu">
	/// <para>Type: <c>LPTSTR*</c></para>
	/// <para>A pointer to the null-terminated string that contains the mnemonic marker.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>TCHAR</c></para>
	/// <para>Returns the mnemonic character, if one was found. Otherwise, returns 0.</para>
	/// </returns>
	/// <remarks>
	/// <para>The term "mnemonic" is misspelled in the function name.</para>
	/// <para>The function supports the following mnemonic formats.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Input String</term>
	/// <term>Output String</term>
	/// <term>Mnemonic Character</term>
	/// <term>Remarks</term>
	/// </listheader>
	/// <item>
	/// <term>"Str&amp;ing"</term>
	/// <term>"String"</term>
	/// <term>'i'</term>
	/// <term>None.</term>
	/// </item>
	/// <item>
	/// <term>"String (&amp;S)"</term>
	/// <term>"String"</term>
	/// <term>'S'</term>
	/// <term>Supported only by the Unicode version of this function. Requires Windows XP or later.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shstripmneumonica CHAR SHStripMneumonicA( LPSTR pszMenu );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "25479814-825a-4af2-8751-b35cf39bbb80")]
	public static extern char SHStripMneumonic(StringBuilder pszMenu);

	/// <summary>
	/// <para>
	/// [This function is available through Windows XP and Windows Server 2003. It might be altered or unavailable in subsequent versions
	/// of Windows.]
	/// </para>
	/// <para>Converts a string from the Unicode code page to the ANSI code page.</para>
	/// </summary>
	/// <param name="pwszSrc">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>A pointer to the null-terminated Unicode string to be converted to ANSI.</para>
	/// </param>
	/// <param name="pszDst">
	/// <para>Type: <c>PSTR</c></para>
	/// <para>
	/// A pointer to a buffer that, when this function returns successfully, receives the converted characters. The buffer must be large
	/// enough to contain the number of <c>CHAR</c> characters specified by the cchBuf parameter, including room for a terminating null character.
	/// </para>
	/// </param>
	/// <param name="cchBuf">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The number of <c>CHAR</c> values that can be contained by the buffer pointed to by pszDst. The value assigned to parameter must
	/// be greater than zero.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// Returns the number of <c>CHAR</c> values written to the output buffer, including the terminating null character. Returns 0 if unsuccessful.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Security Warning:</c> Using this function incorrectly can compromise the security of your application. For example, if pszDst
	/// buffer is not large enough to contain the number of characters specified by cchBuf, a buffer overrun can occur. Buffer overruns
	/// can cause a denial of service attack against an application if an access violation occurs. In the worst case, a buffer overrun
	/// might allow an attacker to inject executable code into your process, especially if pszDst is a stack-based buffer. In addition,
	/// the output string is silently truncated if it is too large for the buffer. This can cause canonicalization or other security vulnerabilities.
	/// </para>
	/// <para>
	/// If the pszDst buffer is not large enough to contain the entire converted output string, the string is truncated to fit the
	/// buffer. There is no way to detect that the return string has been truncated. The string will always be null-terminated, even if
	/// it has been truncated. This function takes care to not truncate between the lead and trail bytes of a DBCS character pair. In
	/// that case, only cchBuf-1 characters are returned.
	/// </para>
	/// <para>If the pwszSrc and pszDst buffers overlap, the function's behavior is undefined.</para>
	/// <para>
	/// <c>Note</c> Do not assume that the function has not changed any of the characters in the output buffer that follow the string's
	/// terminating null character. The contents of the output buffer following the string's terminating null character are undefined, up
	/// to and including the last character in the buffer.
	/// </para>
	/// <para><c>SHTCharToAnsi</c> is defined to be the same as <c>SHUnicodeToAnsi</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shunicodetoansi int SHUnicodeToAnsi( PCWSTR pwszSrc, PSTR
	// pszDst, int cchBuf );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "f0db3976-9956-418f-8432-7755b140050f")]
	public static extern int SHUnicodeToAnsi([MarshalAs(UnmanagedType.LPWStr)] string pwszSrc, [MarshalAs(UnmanagedType.LPStr)] StringBuilder pszDst, int cchBuf);

	/// <summary>
	/// <para>
	/// [This function is available through Windows XP and Windows Server 2003. It might be altered or unavailable in subsequent versions
	/// of Windows.]
	/// </para>
	/// <para>Copies a Unicode string.</para>
	/// </summary>
	/// <param name="pwzSrc">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>A pointer to a null-terminated Unicode string to be copied to the output buffer.</para>
	/// </param>
	/// <param name="pwzDst">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>
	/// A pointer to an output buffer to receive the copied characters. The buffer must be large enough to contain the number of
	/// <c>WCHAR</c> characters specified by cwchBuf, including room for a terminating null character.
	/// </para>
	/// </param>
	/// <param name="cwchBuf">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The number of <c>WCHAR</c> characters that can be contained by the buffer pointed to by pwzDst parameter. This parameter must be
	/// greater than zero.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// Returns the number of <c>WCHAR</c> characters written to the output buffer, including the terminating null character. Returns 0
	/// if unsuccessful.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Security Warning:</c> Using this function incorrectly can compromise the security of your application. For example, if pwzDst
	/// buffer is not large enough to contain the number of characters specified by cwchBuf, a buffer overrun can occur. Buffer overruns
	/// can cause a denial of service attack against an application if an access violation occurs. In the worst case, a buffer overrun
	/// might allow an attacker to inject executable code into your process, especially if pwzDst is a stack-based buffer. When copying
	/// an entire string, note that sizeof returns the number of bytes, which is not the correct value to use for the cwchBuf parameter.
	/// Instead, use sizeof(pwzDst)/sizeof(WCHAR). Note that this technique assumes that pwzDst is an array, not a pointer. Note also
	/// that the function silently truncates the output string if the buffer is not large enough. This can result in canonicalization or
	/// other security vulnerabilities.
	/// </para>
	/// <para>
	/// If the pwzDst buffer is not large enough to contain the entire converted output string, the string is truncated to fit the
	/// buffer. There is no way to detect that the return string has been truncated. The string will always be null-terminated, even if
	/// it has been truncated. This ensures that no more than cwchBuf characters are copied to pwzDst. No attempt is made to avoid
	/// truncating the string in the middle of a Unicode surrogate pair.
	/// </para>
	/// <para>If the pwzSrc and pwzDst buffers overlap, the function's behavior is undefined.</para>
	/// <para>
	/// <c>Note</c> Do not assume that the function has not changed any of the characters in the output buffer that follow the string's
	/// terminating null character. The contents of the output buffer following the string's terminating null character are undefined, up
	/// to and including the last character in the buffer.
	/// </para>
	/// <para><c>SHTCharToUnicode</c> is defined to be the same as <c>SHUnicodeToUnicode</c>.</para>
	/// <para><c>SHUnicodeToTChar</c> is defined to be the same as <c>SHUnicodeToUnicode</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shunicodetounicode int SHUnicodeToUnicode( PCWSTR pwzSrc,
	// PWSTR pwzDst, int cwchBuf );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "1a208c2d-e627-4aac-9a28-b579c734a2a8")]
	public static extern int SHUnicodeToUnicode(string pwzSrc, StringBuilder pwzDst, int cwchBuf);

	/// <summary>
	/// <para>
	/// [ <c>SHUnlockShared</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Unlocks memory locked by SHLockShared.</para>
	/// </summary>
	/// <param name="pvData">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to the shared memory block returned by SHLockShared.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If the function succeeds, the return value is <c>TRUE</c> and all modified pages within the specified range are written to the
	/// disk with low priority. If the function fails, the return value is <c>FALSE</c>. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Call SHFreeShared to free the memory block.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-shunlockshared BOOL SHUnlockShared( void *pvData );
	[DllImport(Lib.Shlwapi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "8ecbf62b-fd0d-4a8d-bd55-42c0c3f64390")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SHUnlockShared(IntPtr pvData);

	/// <summary>
	/// <para>
	/// [ <c>WhichPlatform</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Retrieves a value that indicates the type of Shell32.dll that the platform contains.</para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PLATFORM_UNKNOWN</term>
	/// <term>The function was unable to determine the Shell32.dll version.</term>
	/// </item>
	/// <item>
	/// <term>PLATFORM_IE3</term>
	/// <term>Obsolete: Use PLATFORM_BROWSERONLY.</term>
	/// </item>
	/// <item>
	/// <term>PLATFORM_BROWSERONLY</term>
	/// <term>The Shell32.dll version is browser-only, with no new shell.</term>
	/// </item>
	/// <item>
	/// <term>PLATFORM_INTEGRATED</term>
	/// <term>The platform contains an integrated shell.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function always returns PLATFORM_INTEGRATED because Windows XP comes with an integrated shell.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-whichplatform UINT WhichPlatform( );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "14af733b-81b4-40a2-b93b-6f387b181f12")]
	public static extern SHELLPLATFORM WhichPlatform();

	/// <summary>Provides a handle to a user specific registry key.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HUSKEY : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HUSKEY"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HUSKEY(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HUSKEY"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HUSKEY NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public readonly bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HUSKEY"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HUSKEY h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HUSKEY"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HUSKEY(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HUSKEY h1, HUSKEY h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HUSKEY h1, HUSKEY h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override readonly bool Equals(object? obj) => obj is HUSKEY h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public readonly IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>
	/// <para>Used by the QISearch function to describe a single interface.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>Note</c> Prior to Windows Vista, <c>QITAB</c> was not declared in a public header file. To use it in those cases, you must use
	/// define it yourself as it is given here. Under Windows Vista, <c>QITAB</c> is included in Shlwapi.h and this is not necessary.
	/// </para>
	/// <para>
	/// To mark the end of a <c>QITAB</c> table, set the <c>piid</c> member to <c>NULL</c> and the <c>dwOffset</c> member to 0. See the
	/// QISearch function for an example of how to use this structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/ns-shlwapi-qitab typedef struct QITAB { const IID *piid; DWORD
	// dwOffset; } *LPQITAB;
	[PInvokeData("shlwapi.h", MSDNShortId = "3a055773-6e53-45e1-8936-011a8b2b8b16")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct QITAB
	{
		/// <summary>
		/// <para>Type: <c>const IID*</c></para>
		/// <para>A pointer to the IID of the interface represented by this structure.</para>
		/// </summary>
		public IntPtr piid;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The offset, in bytes, from the base of the object to the start of the interface.</para>
		/// </summary>
		public uint dwOffset;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HUSKEY"/> that is disposed using <see cref="SHRegCloseUSKey"/>.</summary>
	public class SafeHUSKEY : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHUSKEY"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHUSKEY(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHUSKEY"/> class.</summary>
		private SafeHUSKEY() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHUSKEY"/> to <see cref="HUSKEY"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HUSKEY(SafeHUSKEY h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => SHRegCloseUSKey(this).Succeeded;
	}
}