using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.PropSys;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke
{
	/// <summary>Interfaces, functions, enumerated types and structures for Shell32.dll.</summary>
	public static partial class Shell32
	{
		/// <summary/>
		public const int NINF_KEY = 0x1;
		
		/// <summary>Values used in APPBARDATA.</summary>
		[PInvokeData("shellapi.h", MSDNShortId = "cf86fe15-4beb-49b7-b73e-2ad61cedc3f8")]
		public enum ABE
		{
			/// <summary>Left edge.</summary>
			ABE_LEFT = 0,

			/// <summary>Top edge.</summary>
			ABE_TOP = 1,

			/// <summary>Right edge.</summary>
			ABE_RIGHT = 2,

			/// <summary>Bottom edge.</summary>
			ABE_BOTTOM = 3,
		}

		/// <summary>Values used by SHAppBarMessage.</summary>
		[PInvokeData("shellapi.h", MSDNShortId = "173d6eff-b33b-4d7d-bedd-5ebfb1e45954")]
		public enum ABM
		{
			/// <summary>
			/// Registers a new appbar and specifies the message identifier that the system should use to send notification messages to the appbar.
			/// </summary>
			ABM_NEW = 0x00000000,

			/// <summary>Unregisters an appbar, removing the bar from the system's internal list.</summary>
			ABM_REMOVE = 0x00000001,

			/// <summary>Requests a size and screen position for an appbar.</summary>
			ABM_QUERYPOS = 0x00000002,

			/// <summary>Sets the size and screen position of an appbar.</summary>
			ABM_SETPOS = 0x00000003,

			/// <summary>Retrieves the autohide and always-on-top states of the Windows taskbar.</summary>
			ABM_GETSTATE = 0x00000004,

			/// <summary>
			/// Retrieves the bounding rectangle of the Windows taskbar. Note that this applies only to the system taskbar. Other objects,
			/// particularly toolbars supplied with third-party software, also can be present. As a result, some of the screen area not
			/// covered by the Windows taskbar might not be visible to the user. To retrieve the area of the screen not covered by both the
			/// taskbar and other app bars—the working area available to your application—, use the GetMonitorInfo function.
			/// </summary>
			ABM_GETTASKBARPOS = 0x00000005,

			/// <summary>
			/// Notifies the system to activate or deactivate an appbar. The lParam member of the APPBARDATA pointed to by pData is set to
			/// TRUE to activate or FALSE to deactivate.
			/// </summary>
			ABM_ACTIVATE = 0x00000006,

			/// <summary>Retrieves the handle to the autohide appbar associated with a particular edge of the screen.</summary>
			ABM_GETAUTOHIDEBAR = 0x00000007,

			/// <summary>Registers or unregisters an autohide appbar for an edge of the screen.</summary>
			ABM_SETAUTOHIDEBAR = 0x00000008,

			/// <summary>Notifies the system when an appbar's position has changed.</summary>
			ABM_WINDOWPOSCHANGED = 0x00000009,

			/// <summary>Windows XP and later: Sets the state of the appbar's autohide and always-on-top attributes.</summary>
			ABM_SETSTATE = 0x0000000A,

			/// <summary>
			/// Windows XP and later: Retrieves the handle to the autohide appbar associated with a particular edge of a particular monitor.
			/// </summary>
			ABM_GETAUTOHIDEBAREX = 0x0000000B,

			/// <summary>Windows XP and later: Registers or unregisters an autohide appbar for an edge of a particular monitor.</summary>
			ABM_SETAUTOHIDEBAREX = 0x0000000C,
		}

		/// <summary>Where to obtain association data and the form the data is stored in.</summary>
		[PInvokeData("shellapi.h", MSDNShortId = "1d1a963f-7ebb-4ba6-9a97-795c8ef11ae4")]
		public enum ASSOCCLASS
		{
			/// <summary>The hkClass member names a key found as <b>HKEY_CLASSES_ROOT</b>\ <b>SystemFileAssociations</b>\ <i>hkClass</i>.</summary>
			ASSOCCLASS_SHELL_KEY = 0,

			/// <summary>The hkClass member provides the full registry path of a ProgID.</summary>
			ASSOCCLASS_PROGID_KEY,

			/// <summary>The pszClass member names a ProgID found as <b>HKEY_CLASSES_ROOT</b>\ <i>pszClass</i>.</summary>
			ASSOCCLASS_PROGID_STR,

			/// <summary>The hkClass member provides the full registry path of a CLSID.</summary>
			ASSOCCLASS_CLSID_KEY,

			/// <summary>The hkClass member names a CLSID found as <b>HKEY_CLASSES_ROOT</b>\ <b>CLSID</b>\ <i>pszClass</i>.</summary>
			ASSOCCLASS_CLSID_STR,

			/// <summary>The hkClass member provides the full registry path of an application identifier (APPID).</summary>
			ASSOCCLASS_APP_KEY,

			/// <summary>
			/// The APPID storing the application information is found at <b>HKEY_CLASSES_ROOT</b>\ <b>Applications</b>\ <i>FileName</i>
			/// where <i>FileName</i> is obtained by sending <b>pszClass</b> to PathFindFileName.
			/// </summary>
			ASSOCCLASS_APP_STR,

			/// <summary>The pszClass member names a key found as <b>HKEY_CLASSES_ROOT</b>\ <b>SystemFileAssociations</b>\ <i>pszClass</i>.</summary>
			ASSOCCLASS_SYSTEM_STR,

			/// <summary>
			/// Use the association information for folders stored under <b>HKEY_CLASSES_ROOT</b>\ <b>Folder</b>. When this flag is set,
			/// <b>hkClass</b> and <b>pszClass</b> are ignored.
			/// </summary>
			ASSOCCLASS_FOLDER,

			/// <summary>
			/// Use the association information stored under the <b>HKEY_CLASSES_ROOT</b>\ <b>*</b> subkey. When this flag is set,
			/// <b>hkClass</b> and <b>pszClass</b> are ignored.
			/// </summary>
			ASSOCCLASS_STAR,

			/// <summary>
			/// Introduced in Windows 8. Do not use the user defaults to apply the mapping of the class specified by the pszClass member.
			/// </summary>
			ASSOCCLASS_FIXED_PROGID_STR,

			/// <summary>
			/// Introduced in Windows 8. Use the user defaults to apply the mapping of the class specified by the pszClass member; the class
			/// is a protocol.
			/// </summary>
			ASSOCCLASS_PROTOCOL_STR,
		}

		/// <summary>Flags for NOTIFYICONDATA.</summary>
		[PInvokeData("shellapi.h", MSDNShortId = "fdcc42c1-b3e5-4b04-8d79-7b6c29699d53")]
		[Flags]
		public enum NIF
		{
			/// <summary>The uCallbackMessage member is valid.</summary>
			NIF_MESSAGE = 0x00000001,

			/// <summary>The hIcon member is valid.</summary>
			NIF_ICON = 0x00000002,

			/// <summary>The szTip member is valid.</summary>
			NIF_TIP = 0x00000004,

			/// <summary>The dwState and dwStateMask members are valid.</summary>
			NIF_STATE = 0x00000008,

			/// <summary>
			/// Display a balloon notification. The szInfo, szInfoTitle, dwInfoFlags, and uTimeout members are valid. Note that uTimeout is
			/// valid only in Windows 2000 and Windows XP.
			/// <list type="bullet">
			/// <item>
			/// <description>To display the balloon notification, specify NIF_INFO and provide text in szInfo.</description>
			/// </item>
			/// <item>
			/// <description>To remove a balloon notification, specify NIF_INFO and provide an empty string through szInfo.</description>
			/// </item>
			/// <item>
			/// <description>To add a notification area icon without displaying a notification, do not set the NIF_INFO flag.</description>
			/// </item>
			/// </list>
			/// </summary>
			NIF_INFO = 0x00000010,

			/// <summary>Windows 7 and later: The guidItem is valid.</summary>
			NIF_GUID = 0x00000020,

			/// <summary>
			/// Windows Vista and later. If the balloon notification cannot be displayed immediately, discard it. Use this flag for
			/// notifications that represent real-time information which would be meaningless or misleading if displayed at a later time. For
			/// example, a message that states "Your telephone is ringing." NIF_REALTIME is meaningful only when combined with the NIF_INFO flag.
			/// </summary>
			NIF_REALTIME = 0x00000040,

			/// <summary>
			/// Windows Vista and later. Use the standard tooltip. Normally, when uVersion is set to NOTIFYICON_VERSION_4, the standard
			/// tooltip is suppressed and can be replaced by the application-drawn, pop-up UI. If the application wants to show the standard
			/// tooltip with NOTIFYICON_VERSION_4, it can specify NIF_SHOWTIP to indicate the standard tooltip should still be shown.
			/// </summary>
			NIF_SHOWTIP = 0x00000080,
		}

		/// <summary>Info flags for NOTIFYICONDATA.</summary>
		[PInvokeData("shellapi.h", MSDNShortId = "fdcc42c1-b3e5-4b04-8d79-7b6c29699d53")]
		[Flags]
		public enum NIIF
		{
			/// <summary>No icon.</summary>
			NIIF_NONE = 0x00000000,

			/// <summary>An information icon.</summary>
			NIIF_INFO = 0x00000001,

			/// <summary>A warning icon.</summary>
			NIIF_WARNING = 0x00000002,

			/// <summary>An error icon.</summary>
			NIIF_ERROR = 0x00000003,

			/// <summary>
			/// Windows XP SP2 and later.
			/// <list type="bullet">
			/// <item>
			/// <description>Windows XP: Use the icon identified in hIcon as the notification balloon's title icon.</description>
			/// </item>
			/// <item>
			/// <description>
			/// Windows Vista and later: Use the icon identified in hBalloonIcon as the notification balloon's title icon.
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			NIIF_USER = 0x00000004,

			/// <summary>Windows XP and later. Reserved.</summary>
			NIIF_ICON_MASK = 0x0000000F,

			/// <summary>Windows XP and later. Do not play the associated sound. Applies only to notifications.</summary>
			NIIF_NOSOUND = 0x00000010,

			/// <summary>
			/// Windows Vista and later. The large version of the icon should be used as the notification icon. This corresponds to the icon
			/// with dimensions SM_CXICON x SM_CYICON. If this flag is not set, the icon with dimensions XM_CXSMICON x SM_CYSMICON is used.
			/// <list type="bullet">
			/// <item>
			/// <description>This flag can be used with all stock icons.</description>
			/// </item>
			/// <item>
			/// <description>
			/// Applications that use older customized icons (NIIF_USER with hIcon) must provide a new SM_CXICON x SM_CYICON version in the
			/// tray icon(hIcon). These icons are scaled down when they are displayed in the System Tray or System Control Area(SCA).
			/// </description>
			/// </item>
			/// <item>
			/// <description>
			/// New customized icons(NIIF_USER with hBalloonIcon) must supply an SM_CXICON x SM_CYICON version in the supplied icon(hBalloonIcon).
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			NIIF_LARGE_ICON = 0x00000020,

			/// <summary>
			/// Windows 7 and later. Do not display the balloon notification if the current user is in "quiet time", which is the first hour
			/// after a new user logs into his or her account for the first time. During this time, most notifications should not be sent or
			/// shown. This lets a user become accustomed to a new computer system without those distractions. Quiet time also occurs for
			/// each user after an operating system upgrade or clean installation. A notification sent with this flag during quiet time is
			/// not queued; it is simply dismissed unshown. The application can resend the notification later if it is still valid at that time.
			/// <para>
			/// Because an application cannot predict when it might encounter quiet time, we recommended that this flag always be set on all
			/// appropriate notifications by any application that means to honor quiet time.&gt;
			/// </para>
			/// <para>
			/// During quiet time, certain notifications should still be sent because they are expected by the user as feedback in response
			/// to a user action, for instance when he or she plugs in a USB device or prints a document.
			/// </para>
			/// <para>If the current user is not in quiet time, this flag has no effect.</para>
			/// </summary>
			NIIF_RESPECT_QUIET_TIME = 0x00000080
		}

		/// <summary>A value that specifies the action to be taken by <c>Shell_NotifyIcon</c>.</summary>
		public enum NIM
		{
			/// <summary>
			/// Adds an icon to the status area. The icon is given an identifier in the NOTIFYICONDATA structure pointed to by lpdata—either
			/// through its uID or guidItem member. This identifier is used in subsequent calls to Shell_NotifyIcon to perform later actions
			/// on the icon.
			/// </summary>
			NIM_ADD = 0x00000000,

			/// <summary>
			/// Modifies an icon in the status area. NOTIFYICONDATA structure pointed to by lpdata uses the ID originally assigned to the
			/// icon when it was added to the notification area (NIM_ADD) to identify the icon to be modified.
			/// </summary>
			NIM_MODIFY = 0x00000001,

			/// <summary>
			/// Deletes an icon from the status area. NOTIFYICONDATA structure pointed to by lpdata uses the ID originally assigned to the
			/// icon when it was added to the notification area (NIM_ADD) to identify the icon to be deleted.
			/// </summary>
			NIM_DELETE = 0x00000002,

			/// <summary>
			/// Shell32.dll version 5.0 and later only. Returns focus to the taskbar notification area. Notification area icons should use
			/// this message when they have completed their UI operation. For example, if the icon displays a shortcut menu, but the user
			/// presses ESC to cancel it, use NIM_SETFOCUS to return focus to the notification area.
			/// </summary>
			NIM_SETFOCUS = 0x00000003,

			/// <summary>
			/// Shell32.dll version 5.0 and later only. Instructs the notification area to behave according to the version number specified
			/// in the uVersion member of the structure pointed to by lpdata. The version number specifies which members are recognized.
			/// <para>
			/// NIM_SETVERSION must be called every time a notification area icon is added (NIM_ADD)&gt;. It does not need to be called with
			/// NIM_MOFIDY. The version setting is not persisted once a user logs off.
			/// </para>
			/// </summary>
			NIM_SETVERSION = 0x00000004,
		}

		/// <summary>Shell notification messages delivered as a result of calling <see cref="Shell_NotifyIcon"/>.</summary>
		[PInvokeData("shellapi.h")]
		public enum NIN : uint
		{
			/// <summary>Sent when a user selects a notify icon with the mouse and activates it with the ENTER key</summary>
			NIN_SELECT = WM_USER + 0,

			/// <summary>
			/// Sent when a user selects a notify icon with the keyboard and activates it with the SPACEBAR or ENTER key, the version 5.0
			/// Shell sends the associated application an NIN_KEYSELECT notification. Earlier versions send WM_RBUTTONDOWN and WM_RBUTTONUP messages.
			/// </summary>
			NIN_KEYSELECT = NIN_SELECT | NINF_KEY,

			/// <summary>Sent when the balloon is shown (balloons are queued).</summary>
			NIN_BALLOONSHOW = WM_USER + 2,

			/// <summary>
			/// Sent when the balloon disappears. For example, when the icon is deleted. This message is not sent if the balloon is
			/// dismissed because of a timeout or if the user clicks the mouse.
			/// <para>
			/// As of Windows 7, NIN_BALLOONHIDE is also sent when a notification with the NIIF_RESPECT_QUIET_TIME flag set attempts to
			/// display during quiet time (a user's first hour on a new computer). In that case, the balloon is never displayed at all.
			/// </para>
			/// </summary>
			NIN_BALLOONHIDE = WM_USER + 3,

			/// <summary>Sent when the balloon is dismissed because of a timeout.</summary>
			NIN_BALLOONTIMEOUT = WM_USER + 4,

			/// <summary>Sent when the balloon is dismissed because the user clicked the mouse.</summary>
			NIN_BALLOONUSERCLICK = WM_USER + 5,

			/// <summary>
			/// Sent when the user hovers the cursor over an icon to indicate that the richer pop-up UI should be used in place of a
			/// standard textual tooltip.
			/// </summary>
			NIN_POPUPOPEN = WM_USER + 6,

			/// <summary>Sent when a cursor no longer hovers over an icon to indicate that the rich pop-up UI should be closed.</summary>
			NIN_POPUPCLOSE = WM_USER + 7,
		}

		/// <summary>State flags for NOTIFYICONDATA.</summary>
		[PInvokeData("shellapi.h", MSDNShortId = "fdcc42c1-b3e5-4b04-8d79-7b6c29699d53")]
		[Flags]
		public enum NIS
		{
			/// <summary>The icon is hidden.</summary>
			NIS_HIDDEN = 0x00000001,

			/// <summary>The icon resource is shared between multiple icons.</summary>
			NIS_SHAREDICON = 0x00000002
		}

		/// <summary>Flags for SHIsFileAvailableOffline.</summary>
		[PInvokeData("shellapi.h", MSDNShortId = "9acf212d-9309-42b0-ba96-faa0ecf0b865")]
		[Flags]
		public enum OFFLINE_STATUS
		{
			/// <summary>If the file is open, it is open in the cache.</summary>
			OFFLINE_STATUS_LOCAL = 0x0001,

			/// <summary>If the file is open, it is open on the server.</summary>
			OFFLINE_STATUS_REMOTE = 0x0002,

			/// <summary>The local copy is currently incomplete. The file cannot be opened in offline mode until it has been synchronized.</summary>
			OFFLINE_STATUS_INCOMPLETE = 0x0004,
		}

		/// <summary>Flags for SHInvokePrinterCommand.</summary>
		[PInvokeData("shellapi.h", MSDNShortId = "32a5802f-cef7-4dbd-affd-82285fe97a8c")]
		public enum PRINTACTION
		{
			/// <summary>0x0. Open the printer specified by . The parameter is ignored.</summary>
			PRINTACTION_OPEN = 0,

			/// <summary>
			/// 0x1. Display the property pages for the printer specified by . The parameter can be <c>NULL</c> or can name a specific
			/// property sheet to display, either by name or number. If the high <c>WORD</c> of is nonzero, it is assumed that this parameter
			/// is a pointer to a buffer that contains the name of the sheet to open. Otherwise, is seen as the zero-based index of the
			/// property sheet to open.
			/// </summary>
			PRINTACTION_PROPERTIES = 1,

			/// <summary>0x2. Install the network printer specified by . The parameter is ignored.</summary>
			PRINTACTION_NETINSTALL = 2,

			/// <summary>
			/// 0x3. Create a shortcut to the network printer specified by . The parameter specifies the drive and path of the folder in
			/// which to create the shortcut. The network printer must already have been installed on the local computer.
			/// </summary>
			PRINTACTION_NETINSTALLLINK = 3,

			/// <summary>0x4. Print a test page on the printer specified by . The parameter is ignored.</summary>
			PRINTACTION_TESTPAGE = 4,

			/// <summary>0x5. Open the network printer specified by . The parameter is ignored.</summary>
			PRINTACTION_OPENNETPRN = 5,

			/// <summary>0x6. Display the default document properties for the printer specified by . The parameter is ignored.</summary>
			PRINTACTION_DOCUMENTDEFAULTS = 6,

			/// <summary>0x7. Display the properties for the printer server specified by . The parameter is ignored.</summary>
			PRINTACTION_SERVERPROPERTIES = 7,
		}

		/// <summary>
		/// <para>
		/// Specifies the state of the machine for the current user in relation to the propriety of sending a notification. Used by SHQueryUserNotificationState.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/ne-shellapi-query_user_notification_state typedef enum
		// QUERY_USER_NOTIFICATION_STATE { QUNS_NOT_PRESENT , QUNS_BUSY , QUNS_RUNNING_D3D_FULL_SCREEN , QUNS_PRESENTATION_MODE ,
		// QUNS_ACCEPTS_NOTIFICATIONS , QUNS_QUIET_TIME , QUNS_APP } ;
		[PInvokeData("shellapi.h", MSDNShortId = "b26439dd-6695-45d8-8c7f-5bbd5eaf5b54")]
		public enum QUERY_USER_NOTIFICATION_STATE
		{
			/// <summary>A screen saver is displayed, the machine is locked, or a nonactive Fast User Switching session is in progress.</summary>
			QUNS_NOT_PRESENT = 1,

			/// <summary>
			/// A full-screen application is running or Presentation Settings are applied. Presentation Settings allow a user to put their
			/// machine into a state fit for an uninterrupted presentation, such as a set of PowerPoint slides, with a single click.
			/// </summary>
			QUNS_BUSY,

			/// <summary>A full-screen (exclusive mode) Direct3D application is running.</summary>
			QUNS_RUNNING_D3D_FULL_SCREEN,

			/// <summary>The user has activated Windows presentation settings to block notifications and pop-up messages.</summary>
			QUNS_PRESENTATION_MODE,

			/// <summary>None of the other states are found, notifications can be freely sent.</summary>
			QUNS_ACCEPTS_NOTIFICATIONS,

			/// <summary>
			/// Introduced in Windows 7. The current user is in "quiet time", which is the first hour after a new user logs into his or her
			/// account for the first time. During this time, most notifications should not be sent or shown. This lets a user become
			/// accustomed to a new computer system without those distractions. Quiet time also occurs for each user after an operating
			/// system upgrade or clean installation. Applications should set the NIIF_RESPECT_QUIET_TIME flag in their notifications or
			/// balloon tooltip, which prevents those items from being displayed while the current user is in the quiet-time state. Note that
			/// during quiet time, if the user is in one of the other blocked modes (QUNS_NOT_PRESENT, QUNS_BUSY, QUNS_PRESENTATION_MODE, or
			/// QUNS_RUNNING_D3D_FULL_SCREEN) SHQueryUserNotificationState returns only that value, and does not report QUNS_QUIET_TIME.
			/// </summary>
			QUNS_QUIET_TIME,

			/// <summary>Introduced in Windows 8. A Windows Store app is running.</summary>
			QUNS_APP,
		}

		/// <summary>Flags that indicate the content and validity of the other structure members in <see cref="SHELLEXECUTEINFO"/>.</summary>
		[PInvokeData("Shellapi.h", MSDNShortId = "bb759784")]
		[Flags]
		public enum ShellExecuteMaskFlags : uint
		{
			/// <summary>Use default values.</summary>
			SEE_MASK_DEFAULT = 0x00000000,

			/// <summary>
			/// Use the class name given by the lpClass member. If both SEE_MASK_CLASSKEY and SEE_MASK_CLASSNAME are set, the class key is used.
			/// </summary>
			SEE_MASK_CLASSNAME = 0x00000001,

			/// <summary>
			/// Use the class key given by the hkeyClass member. If both SEE_MASK_CLASSKEY and SEE_MASK_CLASSNAME are set, the class key is used.
			/// </summary>
			SEE_MASK_CLASSKEY = 0x00000003,

			/// <summary>Use the item identifier list given by the lpIDList member. The lpIDList member must point to an ITEMIDLIST structure.</summary>
			SEE_MASK_IDLIST = 0x00000004,

			/// <summary>
			/// Use the IContextMenu interface of the selected item's shortcut menu handler. Use either lpFile to identify the item by its
			/// file system path or lpIDList to identify the item by its PIDL. This flag allows applications to use ShellExecuteEx to invoke
			/// verbs from shortcut menu extensions instead of the static verbs listed in the registry. <note>SEE_MASK_INVOKEIDLIST overrides
			/// and implies SEE_MASK_IDLIST.</note>
			/// </summary>
			SEE_MASK_INVOKEIDLIST = 0x0000000c,

			/// <summary>
			/// Use the icon given by the hIcon member. This flag cannot be combined with SEE_MASK_HMONITOR. <note>This flag is used only in
			/// Windows XP and earlier. It is ignored as of Windows Vista.</note>
			/// </summary>
			SEE_MASK_ICON = 0x00000010,

			/// <summary>Use the keyboard shortcut given by the dwHotKey member.</summary>
			SEE_MASK_HOTKEY = 0x00000020,

			/// <summary>
			/// Use to indicate that the hProcess member receives the process handle. This handle is typically used to allow an application
			/// to find out when a process created with ShellExecuteEx terminates. In some cases, such as when execution is satisfied through
			/// a DDE conversation, no handle will be returned. The calling application is responsible for closing the handle when it is no
			/// longer needed.
			/// </summary>
			SEE_MASK_NOCLOSEPROCESS = 0x00000040,

			/// <summary>
			/// Validate the share and connect to a drive letter. This enables reconnection of disconnected network drives. The lpFile member
			/// is a UNC path of a file on a network.
			/// </summary>
			SEE_MASK_CONNECTNETDRV = 0x00000080,

			/// <summary>
			/// Wait for the execute operation to complete before returning. This flag should be used by callers that are using ShellExecute
			/// forms that might result in an async activation, for example DDE, and create a process that might be run on a background
			/// thread. (Note: ShellExecuteEx runs on a background thread by default if the caller's threading model is not Apartment.) Calls
			/// to ShellExecuteEx from processes already running on background threads should always pass this flag. Also, applications that
			/// exit immediately after calling ShellExecuteEx should specify this flag.
			/// <para>
			/// If the execute operation is performed on a background thread and the caller did not specify the SEE_MASK_ASYNCOK flag, then
			/// the calling thread waits until the new process has started before returning. This typically means that either CreateProcess
			/// has been called, the DDE communication has completed, or that the custom execution delegate has notified ShellExecuteEx that
			/// it is done. If the SEE_MASK_WAITFORINPUTIDLE flag is specified, then ShellExecuteEx calls WaitForInputIdle and waits for the
			/// new process to idle before returning, with a maximum timeout of 1 minute.
			/// </para>
			/// <para>For further discussion on when this flag is necessary, see the Remarks section.</para>
			/// </summary>
			SEE_MASK_NOASYNC = 0x00000100,

			/// <summary>Do not use; use SEE_MASK_NOASYNC instead.</summary>
			SEE_MASK_FLAG_DDEWAIT = SEE_MASK_NOASYNC,

			/// <summary>Expand any environment variables specified in the string given by the lpDirectory or lpFile member.</summary>
			SEE_MASK_DOENVSUBST = 0x00000200,

			/// <summary>Do not display an error message box if an error occurs.</summary>
			SEE_MASK_FLAG_NO_UI = 0x00000400,

			/// <summary>Use this flag to indicate a Unicode application.</summary>
			SEE_MASK_UNICODE = 0x00004000,

			/// <summary>
			/// Use to inherit the parent's console for the new process instead of having it create a new console. It is the opposite of
			/// using a CREATE_NEW_CONSOLE flag with CreateProcess.
			/// </summary>
			SEE_MASK_NO_CONSOLE = 0x00008000,

			/// <summary>
			/// The execution can be performed on a background thread and the call should return immediately without waiting for the
			/// background thread to finish. Note that in certain cases ShellExecuteEx ignores this flag and waits for the process to finish
			/// before returning.
			/// </summary>
			SEE_MASK_ASYNCOK = 0x00100000,

			/// <summary>
			/// Use this flag when specifying a monitor on multi-monitor systems. The monitor is specified in the hMonitor member. This flag
			/// cannot be combined with SEE_MASK_ICON.
			/// </summary>
			SEE_MASK_HMONITOR = 0x00200000,

			/// <summary>
			/// Introduced in Windows XP. Do not perform a zone check. This flag allows ShellExecuteEx to bypass zone checking put into place
			/// by IAttachmentExecute.
			/// </summary>
			SEE_MASK_NOZONECHECKS = 0x00800000,

			/// <summary>Not used.</summary>
			SEE_MASK_NOQUERYCLASSSTORE = 0x01000000,

			/// <summary>
			/// After the new process is created, wait for the process to become idle before returning, with a one minute timeout. See
			/// WaitForInputIdle for more details.
			/// </summary>
			SEE_MASK_WAITFORINPUTIDLE = 0x02000000,

			/// <summary>
			/// Introduced in Windows XP. Keep track of the number of times this application has been launched. Applications with
			/// sufficiently high counts appear in the Start Menu's list of most frequently used programs.
			/// </summary>
			SEE_MASK_FLAG_LOG_USAGE = 0x04000000,

			/// <summary>
			/// The hInstApp member is used to specify the IUnknown of an object that implements IServiceProvider. This object will be used
			/// as a site pointer. The site pointer is used to provide services to the ShellExecute function, the handler binding process,
			/// and invoked verb handlers.
			/// </summary>
			SEE_MASK_FLAG_HINST_IS_SITE = 0x08000000
		}

		/// <summary>A value that indicates which operation to perform.</summary>
		[PInvokeData("Shellapi.h")]
		public enum ShellFileOperation
		{
			/// <summary>Move the files specified in pFrom to the location specified in pTo.</summary>
			FO_MOVE = 0x0001,

			/// <summary>Copy the files specified in the pFrom member to the location specified in the pTo member.</summary>
			FO_COPY = 0x0002,

			/// <summary>Delete the files specified in pFrom.</summary>
			FO_DELETE = 0x0003,

			/// <summary>
			/// Rename the file specified in pFrom. You cannot use this flag to rename multiple files with a single function call. Use
			/// FO_MOVE instead.
			/// </summary>
			FO_RENAME = 0x0004
		}

		/// <summary>FLags used by SHEmptyRecycleBin.</summary>
		[PInvokeData("shellapi.h", MSDNShortId = "c3995be7-bc8b-4e1f-8ef6-fdf4c0a75720")]
		[Flags]
		public enum SHERB
		{
			/// <summary>No dialog box confirming the deletion of the objects will be displayed.</summary>
			SHERB_NOCONFIRMATION = 0x00000001,

			/// <summary>No dialog box indicating the progress will be displayed.</summary>
			SHERB_NOPROGRESSUI = 0x00000002,

			/// <summary>No sound will be played when the operation is complete.</summary>
			SHERB_NOSOUND = 0x00000004
		}

		/// <summary>
		/// The flags that specify the file information to retrieve from <see cref="SHGetFileInfo(string, FileAttributes, ref SHFILEINFO,
		/// int, SHGFI)"/>.
		/// </summary>
		[PInvokeData("Shellapi.h", MSDNShortId = "bb762179")]
		[Flags]
		public enum SHGFI
		{
			/// <summary>
			/// Retrieve the handle to the icon that represents the file and the index of the icon within the system image list. The handle
			/// is copied to the hIcon member of the structure specified by psfi, and the index is copied to the iIcon member.
			/// </summary>
			SHGFI_ICON = 0x000000100,

			/// <summary>
			/// Retrieve the display name for the file, which is the name as it appears in Windows Explorer. The name is copied to the
			/// szDisplayName member of the structure specified in psfi. The returned display name uses the long file name, if there is one,
			/// rather than the 8.3 form of the file name. Note that the display name can be affected by settings such as whether extensions
			/// are shown.
			/// </summary>
			SHGFI_DISPLAYNAME = 0x000000200,

			/// <summary>
			/// Retrieve the string that describes the file's type. The string is copied to the szTypeName member of the structure specified
			/// in psfi.
			/// </summary>
			SHGFI_TYPENAME = 0x000000400,

			/// <summary>
			/// Retrieve the item attributes. The attributes are copied to the dwAttributes member of the structure specified in the psfi
			/// parameter. These are the same attributes that are obtained from IShellFolder::GetAttributesOf.
			/// </summary>
			SHGFI_ATTRIBUTES = 0x000000800,

			/// <summary>
			/// Retrieve the name of the file that contains the icon representing the file specified by pszPath, as returned by the
			/// IExtractIcon::GetIconLocation method of the file's icon handler. Also retrieve the icon index within that file. The name of
			/// the file containing the icon is copied to the szDisplayName member of the structure specified by psfi. The icon's index is
			/// copied to that structure's iIcon member.
			/// </summary>
			SHGFI_ICONLOCATION = 0x000001000,

			/// <summary>
			/// Retrieve the type of the executable file if pszPath identifies an executable file. The information is packed into the return
			/// value. This flag cannot be specified with any other flags.
			/// </summary>
			SHGFI_EXETYPE = 0x000002000,

			/// <summary>
			/// Retrieve the index of a system image list icon. If successful, the index is copied to the iIcon member of psfi. The return
			/// value is a handle to the system image list. Only those images whose indices are successfully copied to iIcon are valid.
			/// Attempting to access other images in the system image list will result in undefined behavior.
			/// </summary>
			SHGFI_SYSICONINDEX = 0x000004000,

			/// <summary>
			/// Modify SHGFI_ICON, causing the function to add the link overlay to the file's icon. The SHGFI_ICON flag must also be set.
			/// </summary>
			SHGFI_LINKOVERLAY = 0x000008000,

			/// <summary>
			/// Modify SHGFI_ICON, causing the function to blend the file's icon with the system highlight color. The SHGFI_ICON flag must
			/// also be set.
			/// </summary>
			SHGFI_SELECTED = 0x000010000,

			/// <summary>
			/// Modify SHGFI_ATTRIBUTES to indicate that the dwAttributes member of the SHFILEINFO structure at psfi contains the specific
			/// attributes that are desired. These attributes are passed to IShellFolder::GetAttributesOf. If this flag is not specified,
			/// 0xFFFFFFFF is passed to IShellFolder::GetAttributesOf, requesting all attributes. This flag cannot be specified with the
			/// SHGFI_ICON flag.
			/// </summary>
			SHGFI_ATTR_SPECIFIED = 0x000020000,

			/// <summary>
			/// Modify SHGFI_ICON, causing the function to retrieve the file's large icon. The SHGFI_ICON flag must also be set.
			/// </summary>
			SHGFI_LARGEICON = 0x000000000,

			/// <summary>
			/// Modify SHGFI_ICON, causing the function to retrieve the file's small icon. Also used to modify SHGFI_SYSICONINDEX, causing
			/// the function to return the handle to the system image list that contains small icon images. The SHGFI_ICON and/or
			/// SHGFI_SYSICONINDEX flag must also be set.
			/// </summary>
			SHGFI_SMALLICON = 0x000000001,

			/// <summary>
			/// Modify SHGFI_ICON, causing the function to retrieve the file's open icon. Also used to modify SHGFI_SYSICONINDEX, causing the
			/// function to return the handle to the system image list that contains the file's small open icon. A container object displays
			/// an open icon to indicate that the container is open. The SHGFI_ICON and/or SHGFI_SYSICONINDEX flag must also be set.
			/// </summary>
			SHGFI_OPENICON = 0x000000002,

			/// <summary>
			/// Modify SHGFI_ICON, causing the function to retrieve a Shell-sized icon. If this flag is not specified the function sizes the
			/// icon according to the system metric values. The SHGFI_ICON flag must also be set.
			/// </summary>
			SHGFI_SHELLICONSIZE = 0x000000004,

			/// <summary>Indicate that pszPath is the address of an ITEMIDLIST structure rather than a path name.</summary>
			SHGFI_PIDL = 0x000000008,

			/// <summary>
			/// Indicates that the function should not attempt to access the file specified by pszPath. Rather, it should act as if the file
			/// specified by pszPath exists with the file attributes passed in dwFileAttributes. This flag cannot be combined with the
			/// SHGFI_ATTRIBUTES, SHGFI_EXETYPE, or SHGFI_PIDL flags.
			/// </summary>
			SHGFI_USEFILEATTRIBUTES = 0x000000010,

			/// <summary>Apply the appropriate overlays to the file's icon. The SHGFI_ICON flag must also be set.</summary>
			SHGFI_ADDOVERLAYS = 0x000000020,

			/// <summary>
			/// Return the index of the overlay icon. The value of the overlay index is returned in the upper eight bits of the iIcon member
			/// of the structure specified by psfi. This flag requires that the SHGFI_ICON be set as well.
			/// </summary>
			SHGFI_OVERLAYINDEX = 0x000000040
		}

		/// <summary>Flags for SHGetNewLinkInfo.</summary>
		[PInvokeData("shellapi.h", MSDNShortId = "ca658d5c-af7b-400c-8f4d-7d4b07bf7f2b")]
		[Flags]
		public enum SHGNLI
		{
			/// <summary>
			/// 0x000000001. The target pointed to by is a PIDL that represents the target. If this flag is not included, is regarded as the
			/// address of a string that contains the path and file name of the target.
			/// </summary>
			SHGNLI_PIDL = 0x000000001,

			/// <summary>
			/// 0x000000002. Skip the normal checks that ensure that the shortcut name is unique within the destination folder. If this flag
			/// is not included, the function creates the shortcut name and then determines whether the name is unique in the destination
			/// folder. If a file with the same name already exists in the destination folder, the shortcut name will be modified. This
			/// process is repeated until a unique name is found.
			/// </summary>
			SHGNLI_NOUNIQUE = 0x000000002,

			/// <summary>0x000000004. The created name will be preceded by the string "Shortcut to ".</summary>
			SHGNLI_PREFIXNAME = 0x000000004,

			/// <summary>
			/// 0x000000008. Version 5.0 Do not add the .lnk file name extension. You must set the <c>_WIN32_IE</c> macro to 5.01 or greater
			/// to use this flag. For more information about versioning, see Shell and Common Controls Versions.
			/// </summary>
			SHGNLI_NOLNK = 0x000000008,

			/// <summary>
			/// 0x000000010. <c>Windows Vista and later</c>. Use the non-localized parsing name of the target pointed to by as the name of
			/// the shortcut file. If this flag is not set, the localized name is used.
			/// </summary>
			SHGNLI_NOLOCNAME = 0x000000010,

			/// <summary>
			/// 0x000000020. <c>Windows 7 and later</c>. Append a .url file name extension (rather than .lnk) to the name pointed to by . If
			/// this flag is not set, the shortcut name uses a .lnk extension unless SHGNLI_NOLNK is set.
			/// </summary>
			SHGNLI_USEURLEXT = 0x000000020,
		}

		/// <summary>Flags for SHGetStockIconInfo.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shgetstockiconinfo
		[PInvokeData("shellapi.h", MSDNShortId = "c08b1a53-e67c-4ed0-a9c6-d000c448e182")]
		public enum SHGSI : uint
		{
			/// <summary>
			/// The <c>szPath</c> and <c>iIcon</c> members of the SHSTOCKICONINFO structure receive the path and icon index of the requested
			/// icon, in a format suitable for passing to the ExtractIcon function. The numerical value of this flag is zero, so you always
			/// get the icon location regardless of other flags.
			/// </summary>
			SHGSI_ICONLOCATION = 0,

			/// <summary>The <c>hIcon</c> member of the SHSTOCKICONINFO structure receives a handle to the specified icon.</summary>
			SHGSI_ICON = SHGFI.SHGFI_ICON,

			/// <summary>
			/// The <c>iSysImageImage</c> member of the SHSTOCKICONINFO structure receives the index of the specified icon in the system imagelist.
			/// </summary>
			SHGSI_SYSICONINDEX = SHGFI.SHGFI_SYSICONINDEX,

			/// <summary>Modifies the SHGSI_ICON value by causing the function to add the link overlay to the file's icon.</summary>
			SHGSI_LINKOVERLAY = SHGFI.SHGFI_LINKOVERLAY,

			/// <summary>Modifies the SHGSI_ICON value by causing the function to blend the icon with the system highlight color.</summary>
			SHGSI_SELECTED = SHGFI.SHGFI_SELECTED,

			/// <summary>
			/// Modifies the SHGSI_ICON value by causing the function to retrieve the large version of the icon, as specified by the
			/// SM_CXICON and SM_CYICON system metrics.
			/// </summary>
			SHGSI_LARGEICON = SHGFI.SHGFI_LARGEICON,

			/// <summary>
			/// Modifies the SHGSI_ICON value by causing the function to retrieve the small version of the icon, as specified by the
			/// SM_CXSMICON and SM_CYSMICON system metrics.
			/// </summary>
			SHGSI_SMALLICON = SHGFI.SHGFI_SMALLICON,

			/// <summary>
			/// Modifies the SHGSI_LARGEICON or SHGSI_SMALLICON values by causing the function to retrieve the Shell-sized icons rather than
			/// the sizes specified by the system metrics.
			/// </summary>
			SHGSI_SHELLICONSIZE = SHGFI.SHGFI_SHELLICONSIZE,
		}

		/// <summary>
		/// <para>Used by SHGetStockIconInfo to identify which stock system icon to retrieve.</para>
		/// </summary>
		/// <remarks>
		/// <para>SIID_INVALID, with a value of -1, indicates an invalid <c>SHSTOCKICONID</c> value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/ne-shellapi-shstockiconid typedef enum SHSTOCKICONID {
		// SIID_DOCNOASSOC , SIID_DOCASSOC , SIID_APPLICATION , SIID_FOLDER , SIID_FOLDEROPEN , SIID_DRIVE525 , SIID_DRIVE35 ,
		// SIID_DRIVEREMOVE , SIID_DRIVEFIXED , SIID_DRIVENET , SIID_DRIVENETDISABLED , SIID_DRIVECD , SIID_DRIVERAM , SIID_WORLD ,
		// SIID_SERVER , SIID_PRINTER , SIID_MYNETWORK , SIID_FIND , SIID_HELP , SIID_SHARE , SIID_LINK , SIID_SLOWFILE , SIID_RECYCLER ,
		// SIID_RECYCLERFULL , SIID_MEDIACDAUDIO , SIID_LOCK , SIID_AUTOLIST , SIID_PRINTERNET , SIID_SERVERSHARE , SIID_PRINTERFAX ,
		// SIID_PRINTERFAXNET , SIID_PRINTERFILE , SIID_STACK , SIID_MEDIASVCD , SIID_STUFFEDFOLDER , SIID_DRIVEUNKNOWN , SIID_DRIVEDVD ,
		// SIID_MEDIADVD , SIID_MEDIADVDRAM , SIID_MEDIADVDRW , SIID_MEDIADVDR , SIID_MEDIADVDROM , SIID_MEDIACDAUDIOPLUS , SIID_MEDIACDRW ,
		// SIID_MEDIACDR , SIID_MEDIACDBURN , SIID_MEDIABLANKCD , SIID_MEDIACDROM , SIID_AUDIOFILES , SIID_IMAGEFILES , SIID_VIDEOFILES ,
		// SIID_MIXEDFILES , SIID_FOLDERBACK , SIID_FOLDERFRONT , SIID_SHIELD , SIID_WARNING , SIID_INFO , SIID_ERROR , SIID_KEY ,
		// SIID_SOFTWARE , SIID_RENAME , SIID_DELETE , SIID_MEDIAAUDIODVD , SIID_MEDIAMOVIEDVD , SIID_MEDIAENHANCEDCD , SIID_MEDIAENHANCEDDVD
		// , SIID_MEDIAHDDVD , SIID_MEDIABLURAY , SIID_MEDIAVCD , SIID_MEDIADVDPLUSR , SIID_MEDIADVDPLUSRW , SIID_DESKTOPPC , SIID_MOBILEPC ,
		// SIID_USERS , SIID_MEDIASMARTMEDIA , SIID_MEDIACOMPACTFLASH , SIID_DEVICECELLPHONE , SIID_DEVICECAMERA , SIID_DEVICEVIDEOCAMERA ,
		// SIID_DEVICEAUDIOPLAYER , SIID_NETWORKCONNECT , SIID_INTERNET , SIID_ZIPFILE , SIID_SETTINGS , SIID_DRIVEHDDVD , SIID_DRIVEBD ,
		// SIID_MEDIAHDDVDROM , SIID_MEDIAHDDVDR , SIID_MEDIAHDDVDRAM , SIID_MEDIABDROM , SIID_MEDIABDR , SIID_MEDIABDRE ,
		// SIID_CLUSTEREDDRIVE , SIID_MAX_ICONS } ;
		[PInvokeData("shellapi.h", MSDNShortId = "37da5555-3626-465e-b834-3a28b75495c4")]
		public enum SHSTOCKICONID
		{
			/// <summary>Document of a type with no associated application.</summary>
			SIID_DOCNOASSOC = 0,

			/// <summary>Document of a type with an associated application.</summary>
			SIID_DOCASSOC = 1,

			/// <summary>Generic application with no custom icon.</summary>
			SIID_APPLICATION = 2,

			/// <summary>Folder (generic, unspecified state).</summary>
			SIID_FOLDER = 3,

			/// <summary>Folder (open).</summary>
			SIID_FOLDEROPEN = 4,

			/// <summary>5.25-inch disk drive.</summary>
			SIID_DRIVE525 = 5,

			/// <summary>3.5-inch disk drive.</summary>
			SIID_DRIVE35 = 6,

			/// <summary>Removable drive.</summary>
			SIID_DRIVEREMOVE = 7,

			/// <summary>Fixed drive (hard disk).</summary>
			SIID_DRIVEFIXED = 8,

			/// <summary>Network drive (connected).</summary>
			SIID_DRIVENET = 9,

			/// <summary>Network drive (disconnected).</summary>
			SIID_DRIVENETDISABLED = 10,

			/// <summary>CD drive.</summary>
			SIID_DRIVECD = 11,

			/// <summary>RAM disk drive.</summary>
			SIID_DRIVERAM = 12,

			/// <summary>The entire network.</summary>
			SIID_WORLD = 13,

			/// <summary>A computer on the network.</summary>
			SIID_SERVER = 15,

			/// <summary>A local printer or print destination.</summary>
			SIID_PRINTER = 16,

			/// <summary>The Network virtual folder (FOLDERID_NetworkFolder/CSIDL_NETWORK).</summary>
			SIID_MYNETWORK = 17,

			/// <summary>The Search feature.</summary>
			SIID_FIND = 22,

			/// <summary>The Help and Support feature.</summary>
			SIID_HELP = 23,

			/// <summary>Overlay for a shared item.</summary>
			SIID_SHARE = 28,

			/// <summary>Overlay for a shortcut.</summary>
			SIID_LINK = 29,

			/// <summary>Overlay for items that are expected to be slow to access.</summary>
			SIID_SLOWFILE = 30,

			/// <summary>The Recycle Bin (empty).</summary>
			SIID_RECYCLER = 31,

			/// <summary>The Recycle Bin (not empty).</summary>
			SIID_RECYCLERFULL = 32,

			/// <summary>Audio CD media.</summary>
			SIID_MEDIACDAUDIO = 40,

			/// <summary>Security lock.</summary>
			SIID_LOCK = 47,

			/// <summary>A virtual folder that contains the results of a search.</summary>
			SIID_AUTOLIST = 49,

			/// <summary>A network printer.</summary>
			SIID_PRINTERNET = 50,

			/// <summary>A server shared on a network.</summary>
			SIID_SERVERSHARE = 51,

			/// <summary>A local fax printer.</summary>
			SIID_PRINTERFAX = 52,

			/// <summary>A network fax printer.</summary>
			SIID_PRINTERFAXNET = 53,

			/// <summary>A file that receives the output of a Print to file operation.</summary>
			SIID_PRINTERFILE = 54,

			/// <summary>A category that results from a Stack by command to organize the contents of a folder.</summary>
			SIID_STACK = 55,

			/// <summary>Super Video CD (SVCD) media.</summary>
			SIID_MEDIASVCD = 56,

			/// <summary>A folder that contains only subfolders as child items.</summary>
			SIID_STUFFEDFOLDER = 57,

			/// <summary>Unknown drive type.</summary>
			SIID_DRIVEUNKNOWN = 58,

			/// <summary>DVD drive.</summary>
			SIID_DRIVEDVD = 59,

			/// <summary>DVD media.</summary>
			SIID_MEDIADVD = 60,

			/// <summary>DVD-RAM media.</summary>
			SIID_MEDIADVDRAM = 61,

			/// <summary>DVD-RW media.</summary>
			SIID_MEDIADVDRW = 62,

			/// <summary>DVD-R media.</summary>
			SIID_MEDIADVDR = 63,

			/// <summary>DVD-ROM media.</summary>
			SIID_MEDIADVDROM = 64,

			/// <summary>CD+ (enhanced audio CD) media.</summary>
			SIID_MEDIACDAUDIOPLUS = 65,

			/// <summary>CD-RW media.</summary>
			SIID_MEDIACDRW = 66,

			/// <summary>CD-R media.</summary>
			SIID_MEDIACDR = 67,

			/// <summary>A writeable CD in the process of being burned.</summary>
			SIID_MEDIACDBURN = 68,

			/// <summary>Blank writable CD media.</summary>
			SIID_MEDIABLANKCD = 69,

			/// <summary>CD-ROM media.</summary>
			SIID_MEDIACDROM = 70,

			/// <summary>An audio file.</summary>
			SIID_AUDIOFILES = 71,

			/// <summary>An image file.</summary>
			SIID_IMAGEFILES = 72,

			/// <summary>A video file.</summary>
			SIID_VIDEOFILES = 73,

			/// <summary>A mixed file.</summary>
			SIID_MIXEDFILES = 74,

			/// <summary>Folder back.</summary>
			SIID_FOLDERBACK = 75,

			/// <summary>Folder front.</summary>
			SIID_FOLDERFRONT = 76,

			/// <summary>Security shield. Use for UAC prompts only.</summary>
			SIID_SHIELD = 77,

			/// <summary>Warning.</summary>
			SIID_WARNING = 78,

			/// <summary>Informational.</summary>
			SIID_INFO = 79,

			/// <summary>Error.</summary>
			SIID_ERROR = 80,

			/// <summary>Key.</summary>
			SIID_KEY = 81,

			/// <summary>Software.</summary>
			SIID_SOFTWARE = 82,

			/// <summary>A UI item, such as a button, that issues a rename command.</summary>
			SIID_RENAME = 83,

			/// <summary>A UI item, such as a button, that issues a delete command.</summary>
			SIID_DELETE = 84,

			/// <summary>Audio DVD media.</summary>
			SIID_MEDIAAUDIODVD = 85,

			/// <summary>Movie DVD media.</summary>
			SIID_MEDIAMOVIEDVD = 86,

			/// <summary>Enhanced CD media.</summary>
			SIID_MEDIAENHANCEDCD = 87,

			/// <summary>Enhanced DVD media.</summary>
			SIID_MEDIAENHANCEDDVD = 88,

			/// <summary>High definition DVD media in the HD DVD format.</summary>
			SIID_MEDIAHDDVD = 89,

			/// <summary>High definition DVD media in the Blu-ray Disc™ format.</summary>
			SIID_MEDIABLURAY = 90,

			/// <summary>Video CD (VCD) media.</summary>
			SIID_MEDIAVCD = 91,

			/// <summary>DVD+R media.</summary>
			SIID_MEDIADVDPLUSR = 92,

			/// <summary>DVD+RW media.</summary>
			SIID_MEDIADVDPLUSRW = 93,

			/// <summary>A desktop computer.</summary>
			SIID_DESKTOPPC = 94,

			/// <summary>A mobile computer (laptop).</summary>
			SIID_MOBILEPC = 95,

			/// <summary>The User Accounts Control Panel item.</summary>
			SIID_USERS = 96,

			/// <summary>Smart media.</summary>
			SIID_MEDIASMARTMEDIA = 97,

			/// <summary>CompactFlash media.</summary>
			SIID_MEDIACOMPACTFLASH = 98,

			/// <summary>A cell phone.</summary>
			SIID_DEVICECELLPHONE = 99,

			/// <summary>A digital camera.</summary>
			SIID_DEVICECAMERA = 100,

			/// <summary>A digital video camera.</summary>
			SIID_DEVICEVIDEOCAMERA = 101,

			/// <summary>An audio player.</summary>
			SIID_DEVICEAUDIOPLAYER = 102,

			/// <summary>Connect to network.</summary>
			SIID_NETWORKCONNECT = 103,

			/// <summary>The Network and Internet Control Panel item.</summary>
			SIID_INTERNET = 104,

			/// <summary>A compressed file with a .zip file name extension.</summary>
			SIID_ZIPFILE = 105,

			/// <summary>The Additional Options Control Panel item.</summary>
			SIID_SETTINGS = 106,

			/// <summary>
			/// Windows Vista with Service Pack 1 (SP1) and later. High definition DVD drive (any type - HD DVD-ROM, HD DVD-R, HD-DVD-RAM)
			/// that uses the HD DVD format.
			/// </summary>
			SIID_DRIVEHDDVD = 132,

			/// <summary>
			/// Windows Vista with SP1 and later. High definition DVD drive (any type - BD-ROM, BD-R, BD-RE) that uses the Blu-ray Disc format.
			/// </summary>
			SIID_DRIVEBD = 133,

			/// <summary>Windows Vista with SP1 and later. High definition DVD-ROM media in the HD DVD-ROM format.</summary>
			SIID_MEDIAHDDVDROM = 134,

			/// <summary>Windows Vista with SP1 and later. High definition DVD-R media in the HD DVD-R format.</summary>
			SIID_MEDIAHDDVDR = 135,

			/// <summary>Windows Vista with SP1 and later. High definition DVD-RAM media in the HD DVD-RAM format.</summary>
			SIID_MEDIAHDDVDRAM = 136,

			/// <summary>Windows Vista with SP1 and later. High definition DVD-ROM media in the Blu-ray Disc BD-ROM format.</summary>
			SIID_MEDIABDROM = 137,

			/// <summary>Windows Vista with SP1 and later. High definition write-once media in the Blu-ray Disc BD-R format.</summary>
			SIID_MEDIABDR = 138,

			/// <summary>Windows Vista with SP1 and later. High definition read/write media in the Blu-ray Disc BD-RE format.</summary>
			SIID_MEDIABDRE = 139,

			/// <summary>Windows Vista with SP1 and later. A cluster disk array.</summary>
			SIID_CLUSTEREDDRIVE = 140,

			/// <summary>The highest valid value in the enumeration. Values over 160 are Windows 7-only icons.</summary>
			SIID_MAX_ICONS = 181,
		}

		/// <summary>
		/// <para>Retrieves an object that implements an IQueryAssociations interface.</para>
		/// </summary>
		/// <param name="rgClasses">
		/// <para>Type: <c>const ASSOCIATIONELEMENT*</c></para>
		/// <para>A pointer to an array of ASSOCIATIONELEMENT structures.</para>
		/// </param>
		/// <param name="cClasses">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of elements in the array pointed to by .</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>Reference to the desired IID, normally IID_IQueryAssociations.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns, contains the interface pointer requested in . This is normally IQueryAssociations.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>For systems earlier than Windows Vista, use the AssocCreate function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-assoccreateforclasses SHSTDAPI AssocCreateForClasses(
		// const ASSOCIATIONELEMENT *rgClasses, ULONG cClasses, REFIID riid, void **ppv );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "43257507-dd5e-4622-8445-c132187fd1e5")]
		public static extern HRESULT AssocCreateForClasses([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ASSOCIATIONELEMENT[] rgClasses,
			uint cClasses, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		/// <summary>Retrieves an object that implements an IQueryAssociations interface.</summary>
		/// <typeparam name="TIntf">Reference to the desired IID type, normally IQueryAssociations.</typeparam>
		/// <param name="rgClasses"><para>Type: <c>const ASSOCIATIONELEMENT*</c></para>
		/// <para>A pointer to an array of ASSOCIATIONELEMENT structures.</para></param>
		/// <returns>
		/// When this method returns, contains the interface pointer requested in . This is normally IQueryAssociations.
		/// </returns>
		/// <remarks>For systems earlier than Windows Vista, use the AssocCreate function.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-assoccreateforclasses SHSTDAPI AssocCreateForClasses(
		// const ASSOCIATIONELEMENT *rgClasses, ULONG cClasses, REFIID riid, void **ppv );
		[PInvokeData("shellapi.h", MSDNShortId = "43257507-dd5e-4622-8445-c132187fd1e5")]
		public static TIntf AssocCreateForClasses<TIntf>(ASSOCIATIONELEMENT[] rgClasses) where TIntf : class =>
			IidGetObj<TIntf>((in Guid g, out object o) => AssocCreateForClasses(rgClasses, (uint)(rgClasses?.Length ?? 0), g, out o));

		/// <summary>
		/// <para>
		/// Parses a Unicode command line string and returns an array of pointers to the command line arguments, along with a count of such
		/// arguments, in a way that is similar to the standard C run-time and values.
		/// </para>
		/// </summary>
		/// <param name="lpCmdLine">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>
		/// Pointer to a <c>null</c>-terminated Unicode string that contains the full command line. If this parameter is an empty string the
		/// function returns the path to the current executable file.
		/// </para>
		/// </param>
		/// <param name="pNumArgs">
		/// <para>Type: <c>int*</c></para>
		/// <para>Pointer to an <c>int</c> that receives the number of array elements returned, similar to .</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>A pointer to an array of <c>LPWSTR</c> values, similar to .</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The address returned by <c>CommandLineToArgvW</c> is the address of the first element in an array of <c>LPWSTR</c> values; the
		/// number of pointers in this array is indicated by . Each pointer to a <c>null</c>-terminated Unicode string represents an
		/// individual argument found on the command line.
		/// </para>
		/// <para>
		/// <c>CommandLineToArgvW</c> allocates a block of contiguous memory for pointers to the argument strings, and for the argument
		/// strings themselves; the calling application must free the memory used by the argument list when it is no longer needed. To free
		/// the memory, use a single call to the LocalFree function.
		/// </para>
		/// <para>For more information about the and argument convention, see Argument Definitions and Parsing C++ Command-Line Arguments.</para>
		/// <para>The GetCommandLineW function can be used to get a command line string that is suitable for use as the parameter.</para>
		/// <para>
		/// This function accepts command lines that contain a program name; the program name can be enclosed in quotation marks or not.
		/// </para>
		/// <para>
		/// <c>CommandLineToArgvW</c> has a special interpretation of backslash characters when they are followed by a quotation mark
		/// character ("). This interpretation assumes that any preceding argument is a valid file system path, or else it may behave unpredictably.
		/// </para>
		/// <para>
		/// This special interpretation controls the "in quotes" mode tracked by the parser. When this mode is off, whitespace terminates the
		/// current argument. When on, whitespace is added to the argument like all other characters.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// 2 backslashes followed by a quotation mark produce backslashes followed by begin/end quote. This does not become part of the
		/// parsed argument, but toggles the "in quotes" mode.
		/// </item>
		/// <item>
		/// (2) + 1 backslashes followed by a quotation mark again produce backslashes followed by a quotation mark literal ("). This does
		/// not toggle the "in quotes" mode.
		/// </item>
		/// <item>backslashes not followed by a quotation mark simply produce backslashes.</item>
		/// </list>
		/// <para>
		/// <c>Important</c><c>CommandLineToArgvW</c> treats whitespace outside of quotation marks as argument delimiters. However, if starts
		/// with any amount of whitespace, <c>CommandLineToArgvW</c> will consider the first argument to be an empty string. Excess
		/// whitespace at the end of is ignored.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-commandlinetoargvw LPWSTR * CommandLineToArgvW( LPCWSTR
		// lpCmdLine, int *pNumArgs );
		[DllImport(Lib.Shell32, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "9889a016-b7a5-402b-8305-6f7c199d41b3")]
		public static extern SafeLocalHandle CommandLineToArgvW(string lpCmdLine, out int pNumArgs);

		/// <summary>Parses a Unicode command line string and returns an array of pointers to the command line arguments, along with a count of such arguments, in a way that is similar to the standard C run-time argv and argc values.</summary>
		/// <param name="lpCmdLine">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>Pointer to a <c>null</c>-terminated Unicode string that contains the full command line. If this parameter is an empty string the function returns the path to the current executable file.</para>
		/// </param>
		/// <returns>
		/// <para>An array of <c>LPWSTR</c> values, similar to argv.</para>
		/// <para>If the function fails, the return value is an empty array. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>For more information about the argv and argc argument convention, see Argument Definitions and Parsing C++ Command-Line Arguments.</para>
		/// <para>The GetCommandLineW function can be used to get a command line string that is suitable for use as the lpCmdLine parameter.</para>
		/// <para>This function accepts command lines that contain a program name; the program name can be enclosed in quotation marks or not.</para>
		/// <para><c>CommandLineToArgvW</c> has a special interpretation of backslash characters when they are followed by a quotation mark character ("). This interpretation assumes that any preceding argument is a valid file system path, or else it may behave unpredictably.</para>
		/// <para>This special interpretation controls the "in quotes" mode tracked by the parser. When this mode is off, whitespace terminates the current argument. When on, whitespace is added to the argument like all other characters.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>2n backslashes followed by a quotation mark produce n backslashes followed by begin/end quote. This does not become part of the parsed argument, but toggles the "in quotes" mode.</term>
		/// </item>
		/// <item>
		/// <term>(2n) + 1 backslashes followed by a quotation mark again produce n backslashes followed by a quotation mark literal ("). This does not toggle the "in quotes" mode.</term>
		/// </item>
		/// <item>
		/// <term>n backslashes not followed by a quotation mark simply produce n backslashes.</term>
		/// </item>
		/// </list>
		/// <para><c>Important</c> <c>CommandLineToArgvW</c> treats whitespace outside of quotation marks as argument delimiters. However, if lpCmdLine starts with any amount of whitespace, <c>CommandLineToArgvW</c> will consider the first argument to be an empty string. Excess whitespace at the end of lpCmdLine is ignored.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-commandlinetoargvw
		// LPWSTR * CommandLineToArgvW( LPCWSTR lpCmdLine, int *pNumArgs );
		[PInvokeData("shellapi.h", MSDNShortId = "9889a016-b7a5-402b-8305-6f7c199d41b3")]
		public static string[] CommandLineToArgvW(string lpCmdLine = "") =>
			CommandLineToArgvW(lpCmdLine, out var pNumArgs).ToStringEnum(pNumArgs, CharSet.Unicode).ToArray();

		/// <summary>
		/// <para>Registers whether a window accepts dropped files.</para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The identifier of the window that is registering whether it will accept dropped files.</para>
		/// </param>
		/// <param name="fAccept">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A value that indicates if the window identified by the parameter accepts dropped files. This value is <c>TRUE</c> to accept
		/// dropped files or <c>FALSE</c> to discontinue accepting dropped files.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>No return value.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application that calls <c>DragAcceptFiles</c> with the parameter set to <c>TRUE</c> has identified itself as able to process
		/// the WM_DROPFILES message from File Manager.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-dragacceptfiles void DragAcceptFiles( HWND hWnd, BOOL
		// fAccept );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "1f16f6e4-7847-4bc7-adce-995876db24bd")]
		public static extern void DragAcceptFiles(HWND hWnd, [MarshalAs(UnmanagedType.Bool)] bool fAccept);

		/// <summary>
		/// <para>Releases memory that the system allocated for use in transferring file names to the application.</para>
		/// </summary>
		/// <param name="hDrop">
		/// <para>Type: <c>HDROP</c></para>
		/// <para>
		/// Identifier of the structure that describes dropped files. This handle is retrieved from the parameter of the WM_DROPFILES message.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>No return value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-dragfinish void DragFinish( HDROP hDrop );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "9b15e8a5-de68-4dcb-8e1a-0ee0393aa9db")]
		public static extern void DragFinish(HDROP hDrop);

		/// <summary>
		/// <para>Retrieves the names of dropped files that result from a successful drag-and-drop operation.</para>
		/// </summary>
		/// <param name="hDrop">
		/// <para>Type: <c>HDROP</c></para>
		/// <para>Identifier of the structure that contains the file names of the dropped files.</para>
		/// </param>
		/// <param name="iFile">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index of the file to query. If the value of this parameter is 0xFFFFFFFF, <c>DragQueryFile</c> returns a count of the files
		/// dropped. If the value of this parameter is between zero and the total number of files dropped, <c>DragQueryFile</c> copies the
		/// file name with the corresponding value to the buffer pointed to by the parameter.
		/// </para>
		/// </param>
		/// <param name="lpszFile">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// The address of a buffer that receives the file name of a dropped file when the function returns. This file name is a
		/// null-terminated string. If this parameter is <c>NULL</c>, <c>DragQueryFile</c> returns the required size, in characters, of this buffer.
		/// </para>
		/// </param>
		/// <param name="cch">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size, in characters, of the buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>A nonzero value indicates a successful call.</para>
		/// <para>
		/// When the function copies a file name to the buffer, the return value is a count of the characters copied, not including the
		/// terminating null character.
		/// </para>
		/// <para>
		/// If the index value is 0xFFFFFFFF, the return value is a count of the dropped files. Note that the index variable itself returns
		/// unchanged, and therefore remains 0xFFFFFFFF.
		/// </para>
		/// <para>
		/// If the index value is between zero and the total number of dropped files, and the buffer address is <c>NULL</c>, the return value
		/// is the required size, in characters, of the buffer, the terminating null character.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-dragqueryfilea UINT DragQueryFileA( HDROP hDrop, UINT
		// iFile, LPSTR lpszFile, UINT cch );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "93fab381-9035-46c4-ba9d-efb2d0801d84")]
		public static extern uint DragQueryFile(HDROP hDrop, uint iFile, [Optional] string lpszFile, uint cch);

		/// <summary>
		/// <para>Retrieves the position of the mouse pointer at the time a file was dropped during a drag-and-drop operation.</para>
		/// </summary>
		/// <param name="hDrop">
		/// <para>Type: <c>HDROP</c></para>
		/// <para>Handle of the drop structure that describes the dropped file.</para>
		/// </param>
		/// <param name="ppt">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the drop occurred in the client area of the window; otherwise <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>The window for which coordinates are returned is the window that received the WM_DROPFILES message.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-dragquerypoint BOOL DragQueryPoint( HDROP hDrop, POINT
		// *ppt );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "87794ab0-a075-4a1f-869f-5998bdc57a1d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DragQueryPoint(HDROP hDrop, ref POINT ppt);

		/// <summary>Creates a duplicate of a specified icon.</summary>
		/// <param name="hInst">Type: <c>HINSTANCE</c></param>
		/// <param name="hIcon">
		/// <para>Type: <c>HICON</c></para>
		/// <para>Handle to the icon to be duplicated.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HICON</c></para>
		/// <para>If successful, the function returns the handle to the new icon that was created; otherwise, <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// When it is no longer needed, the caller is responsible for freeing the icon handle returned by <c>DuplicateIcon</c> by calling
		/// the DestroyIcon function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-duplicateicon HICON DuplicateIcon( [in] HINSTANCE hInst,
		// [in] HICON hIcon );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "NF:shellapi.DuplicateIcon")]
		public static extern SafeHICON DuplicateIcon([Optional] HINSTANCE hInst, HICON hIcon);

		/// <summary>Gets a handle to an icon stored as a resource in a file or an icon stored in a file's associated executable file.</summary>
		/// <param name="hInst">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>A handle to the instance of the calling application.</para>
		/// </param>
		/// <param name="pszIconPath">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// Pointer to a string that, on entry, specifies the full path and file name of the file that contains the icon. The function
		/// extracts the icon handle from that file, or from an executable file associated with that file.
		/// </para>
		/// <para>
		/// When this function returns, if the icon handle was obtained from an executable file (either an executable file pointed to by
		/// <c>lpIconPath</c> or an associated executable file) the function stores the full path and file name of that executable in the
		/// buffer pointed to by this parameter.
		/// </para>
		/// </param>
		/// <param name="piIcon">
		/// <para>Type: <c>LPWORD</c></para>
		/// <para>Pointer to a <c>WORD</c> value that, on entry, specifies the index of the icon whose handle is to be obtained.</para>
		/// <para>
		/// When the function returns, if the icon handle was obtained from an executable file (either an executable file pointed to by
		/// <c>lpIconPath</c> or an associated executable file), this value points to the icon's index in that file.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HICON</c></para>
		/// <para>
		/// If the function succeeds, the return value is an icon handle. If the icon is extracted from an associated executable file, the
		/// function stores the full path and file name of the executable file in the string pointed to by <c>lpIconPath</c>, and stores the
		/// icon's identifier in the <c>WORD</c> pointed to by <c>lpiIcon</c>.
		/// </para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When it is no longer needed, the caller is responsible for freeing the icon handle returned by <c>ExtractAssociatedIcon</c> by
		/// calling the DestroyIcon function.
		/// </para>
		/// <para>
		/// The <c>ExtractAssociatedIcon</c> function first looks for the indexed icon in the file specified by <c>lpIconPath</c>. If the
		/// function cannot obtain the icon handle from that file, and the file has an associated executable file, it looks in that
		/// executable file for an icon. Associations with executable files are based on file name extensions and are stored in the per-user
		/// part of the registry.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The shellapi.h header defines ExtractAssociatedIcon as an alias which automatically selects the ANSI or Unicode version of this
		/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
		/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
		/// for Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-extractassociatedicona HICON ExtractAssociatedIconA( [in]
		// HINSTANCE hInst, [in, out] LPSTR pszIconPath, [in, out] WORD *piIcon );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "NF:shellapi.ExtractAssociatedIconA")]
		public static extern SafeHICON ExtractAssociatedIcon(HINSTANCE hInst, StringBuilder pszIconPath, ref ushort piIcon);

		/// <summary>
		/// <para>
		/// [ <c>ExtractAssociatedIconEx</c> is available for use in the operating systems specified in the Requirements section. It may be
		/// altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// Gets a handle to an icon stored as a resource in a file or an icon stored in a file's associated executable file. It extends the
		/// ExtractAssociatedIcon function by retrieving the icon's ID when that icon is extracted from an executable file.
		/// </para>
		/// </summary>
		/// <param name="hInst">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>The handle of the module from which to extract the icon.</para>
		/// </param>
		/// <param name="pszIconPath">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// Pointer to a string that, on entry, specifies the full path and file name of the file that contains the icon. The function
		/// extracts the icon handle from that file, or from an executable file associated with that file.
		/// </para>
		/// <para>
		/// When this function returns, if the icon handle was obtained from an executable file (either an executable file directly pointed
		/// to by this parameter or an associated executable file) the function stores the full path and file name of that executable in the
		/// buffer pointed to by this parameter.
		/// </para>
		/// </param>
		/// <param name="piIconIndex">
		/// <para>Type: <c>LPWORD</c></para>
		/// <para>Pointer to a <c>WORD</c> value that, on entry, specifies the index of the icon whose handle is to be obtained.</para>
		/// <para>
		/// When the function returns, if the icon handle was obtained from an executable file (either an executable file pointed to by
		/// <c>lpIconPath</c> or an associated executable file), this value points to the icon's index in that file.
		/// </para>
		/// </param>
		/// <param name="piIconId">
		/// <para>Type: <c>LPWORD</c></para>
		/// <para>Pointer to a <c>WORD</c> value that, on entry, specifies the ID of the icon whose handle is to be obtained.</para>
		/// <para>
		/// When the function returns, if the icon handle was obtained from an executable file (either an executable file pointed to by
		/// <c>lpIconPath</c> or an associated executable file), this value points to the icon's ID within that file.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HICON</c></para>
		/// <para>Returns the icon's handle if successful, otherwise <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>The icon handle returned by this function must be released by calling DestroyIcon when it is no longer needed.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The shellapi.h header defines ExtractAssociatedIconEx as an alias which automatically selects the ANSI or Unicode version of this
		/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
		/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
		/// for Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-extractassociatediconexa HICON ExtractAssociatedIconExA(
		// [in] HINSTANCE hInst, [in, out] LPSTR pszIconPath, [in, out] WORD *piIconIndex, [in, out] WORD *piIconId );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "NF:shellapi.ExtractAssociatedIconExA")]
		public static extern SafeHICON ExtractAssociatedIconEx(HINSTANCE hInst, StringBuilder pszIconPath, ref ushort piIconIndex, ref ushort piIconId);

		/// <summary>
		/// <para>Gets a handle to an icon from the specified executable file, DLL, or icon file.</para>
		/// <para>To retrieve an array of handles to large or small icons, use the ExtractIconEx function.</para>
		/// </summary>
		/// <param name="hInst">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>Handle to the instance of the application that calls the function.</para>
		/// </param>
		/// <param name="pszExeFileName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>Pointer to a null-terminated string that specifies the name of an executable file, DLL, or icon file.</para>
		/// </param>
		/// <param name="nIconIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Specifies the zero-based index of the icon to retrieve. For example, if this value is 0, the function returns a handle to the
		/// first icon in the specified file.
		/// </para>
		/// <para>
		/// If this value is -1, the function returns the total number of icons in the specified file. If the file is an executable file or
		/// DLL, the return value is the number of RT_GROUP_ICON resources. If the file is an .ICO file, the return value is 1.
		/// </para>
		/// <para>
		/// If this value is a negative number not equal to –1, the function returns a handle to the icon in the specified file whose
		/// resource identifier is equal to the absolute value of <c>nIconIndex</c>. For example, you should use –3 to extract the icon whose
		/// resource identifier is 3. To extract the icon whose resource identifier is 1, use the ExtractIconEx function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HICON</c></para>
		/// <para>
		/// The return value is a handle to an icon. If the file specified was not an executable file, DLL, or icon file, the return is 1. If
		/// no icons were found in the file, the return value is <c>NULL</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When it is no longer needed, you must destroy the icon handle returned by <c>ExtractIcon</c> by calling the DestroyIcon function.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The shellapi.h header defines ExtractIcon as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-extracticona HICON ExtractIconA( [in] HINSTANCE hInst,
		// [in] LPCSTR pszExeFileName, UINT nIconIndex );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "NF:shellapi.ExtractIconA")]
		public static extern SafeHICON ExtractIcon(HINSTANCE hInst, string pszExeFileName, int nIconIndex);

		/// <summary>
		/// The <c>ExtractIconEx</c> function creates an array of handles to large or small icons extracted from the specified executable
		/// file, DLL, or icon file.
		/// </summary>
		/// <param name="lpszFile">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// Pointer to a null-terminated string that specifies the name of an executable file, DLL, or icon file from which icons will be extracted.
		/// </para>
		/// </param>
		/// <param name="nIconIndex">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Specifies the zero-based index of the first icon to extract. For example, if this value is zero, the function extracts the first
		/// icon in the specified file.
		/// </para>
		/// <para>
		/// If this value is –1 and <c>phiconLarge</c> and <c>phiconSmall</c> are both <c>NULL</c>, the function returns the total number of
		/// icons in the specified file. If the file is an executable file or DLL, the return value is the number of RT_GROUP_ICON resources.
		/// If the file is an .ico file, the return value is 1.
		/// </para>
		/// <para>
		/// If this value is a negative number and either <c>phiconLarge</c> or <c>phiconSmall</c> is not <c>NULL</c>, the function begins by
		/// extracting the icon whose resource identifier is equal to the absolute value of <c>nIconIndex</c>. For example, use -3 to extract
		/// the icon whose resource identifier is 3.
		/// </para>
		/// </param>
		/// <param name="phiconLarge">
		/// <para>Type: <c>HICON*</c></para>
		/// <para>
		/// Pointer to an array of icon handles that receives handles to the large icons extracted from the file. If this parameter is
		/// <c>NULL</c>, no large icons are extracted from the file.
		/// </para>
		/// </param>
		/// <param name="phiconSmall">
		/// <para>Type: <c>HICON*</c></para>
		/// <para>
		/// Pointer to an array of icon handles that receives handles to the small icons extracted from the file. If this parameter is
		/// <c>NULL</c>, no small icons are extracted from the file.
		/// </para>
		/// </param>
		/// <param name="nIcons">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of icons to extract from the file.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// If the nIconIndex parameter is -1 and both the phiconLarge and phiconSmall parameters are <c>NULL</c>, then the return value is
		/// the number of icons contained in the specified file.
		/// </para>
		/// <para>
		/// If the nIconIndex parameter is any value other than -1 and either phiconLarge or phiconSmall is not <c>NULL</c>, the return value
		/// is the number of icons successfully extracted from the file.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// If the function encounters an error, it returns <c>UINT_MAX</c>. In this case, you can call GetLastError to retrieve the error
		/// code. For example, this function returns <c>UINT_MAX</c> if the file specified by lpszFile cannot be found while the nIconIndex
		/// parameter is any value other than -1 and either phiconLarge or phiconSmall is not <c>NULL</c>. In this case, <c>GetLastError</c>
		/// returns <c>ERROR_FILE_NOT_FOUND</c> (2).
		/// </para>
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When they are no longer needed, you must destroy all icons extracted by <c>ExtractIconEx</c> by calling the DestroyIcon function.
		/// </para>
		/// <para>
		/// To retrieve the dimensions of the large and small icons, use this function with the SM_CXICON, SM_CYICON, SM_CXSMICON, and
		/// SM_CYSMICON flags.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The shellapi.h header defines ExtractIconEx as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-extracticonexa UINT ExtractIconExA( [in] LPCSTR lpszFile,
		// [in] int nIconIndex, [out] HICON *phiconLarge, [out] HICON *phiconSmall, UINT nIcons );
		[DllImport(Lib.Shell32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "NF:shellapi.ExtractIconExA")]
		public static extern uint ExtractIconEx(string lpszFile, int nIconIndex,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] HICON[] phiconLarge,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] HICON[] phiconSmall, uint nIcons);

		/// <summary>The <c>ExtractIconEx</c> function creates an array of handles to large or small icons extracted from the specified executable file, DLL, or icon file.</summary>
		/// <param name="lpszFile">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>Pointer to a null-terminated string that specifies the name of an executable file, DLL, or icon file from which icons will be extracted.</para>
		/// </param>
		/// <param name="nIconIndex">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the zero-based index of the first icon to extract. For example, if this value is zero, the function extracts the first icon in the specified file.</para>
		/// <para>If this value is –1 and phiconLarge and phiconSmall are both <c>NULL</c>, the function returns the total number of icons in the specified file. If the file is an executable file or DLL, the return value is the number of RT_GROUP_ICON resources. If the file is an .ico file, the return value is 1.</para>
		/// <para>If this value is a negative number and either phiconLarge or phiconSmall is not <c>NULL</c>, the function begins by extracting the icon whose resource identifier is equal to the absolute value of nIconIndex. For example, use -3 to extract the icon whose resource identifier is 3.</para>
		/// </param>
		/// <param name="nIcons">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of icons to extract from the file.</para>
		/// </param>
		/// <param name="phiconLarge">
		/// <para>Type: <c>SafeHICON[]</c></para>
		/// <para>An array of icon handles that receives handles to the large icons extracted from the file. If this parameter is <c>NULL</c>, no large icons were extracted from the file.</para>
		/// </param>
		/// <param name="phiconSmall">
		/// <para>Type: <c>SafeHICON[]</c></para>
		/// <para>An array of icon handles that receives handles to the small icons extracted from the file. If this parameter is <c>NULL</c>, no small icons were extracted from the file.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>If the nIconIndex parameter is -1, the phiconLarge parameter is <c>NULL</c>, and the phiconSmall parameter is <c>NULL</c>, then the return value is the number of icons contained in the specified file. Otherwise, the return value is the number of icons successfully extracted from the file.</para>
		/// </returns>
		/// <remarks>
		/// <para>To retrieve the dimensions of the large and small icons, use this function with the SM_CXICON, SM_CYICON, SM_CXSMICON, and SM_CYSMICON flags.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-extracticonexa
		// UINT ExtractIconExA( LPCSTR lpszFile, int nIconIndex, HICON *phiconLarge, HICON *phiconSmall, UINT nIcons );
		[PInvokeData("shellapi.h", MSDNShortId = "1c4d760a-79b5-4646-9cf2-6cd32c5d05ee")]
		public static uint ExtractIconEx(string lpszFile, int nIconIndex, uint nIcons, out SafeHICON[] phiconLarge, out SafeHICON[] phiconSmall)
		{
			HICON[] sm = nIcons > 0 ? new HICON[nIcons] : null, lg = nIcons > 0 ? new HICON[nIcons] : null;
			var ret = ExtractIconEx(lpszFile, nIconIndex, lg, sm, nIcons);
			var conv = nIconIndex != -1 && ret > 0;
			phiconLarge = conv ? Array.ConvertAll(lg, h => new SafeHICON((IntPtr)h)) : null;
			phiconSmall = conv ? Array.ConvertAll(sm, h => new SafeHICON((IntPtr)h)) : null;
			return ret;
		}

		/// <summary>Initializes or reinitializes the system image list.</summary>
		/// <param name="fRestoreCache">
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> to restore the system image cache from disk; <c>FALSE</c> otherwise.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the cache was successfully refreshed, <c>FALSE</c> if the initialization failed.</para>
		/// </returns>
		/// <remarks>
		/// <para>If you are using system image lists in your own process, you must call <c>FileIconInit</c> at the following times:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>On launch.</term>
		/// </item>
		/// <item>
		/// <term>In response to a <c>WM_SETTINGCHANGE</c> message when the <c>SPI_SETNONCLIENTMETRICS</c> flag is set.</term>
		/// </item>
		/// </list>
		/// <para><c>FileIconInit</c> is not included in a header file. You must call it directly from Shell32.dll, using ordinal 660.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/fileiconinit
		// BOOL FileIconInit( _In_ BOOL fRestoreCache );
		[DllImport(Lib.Shell32, SetLastError = false, EntryPoint = "#660")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FileIconInit([MarshalAs(UnmanagedType.Bool)] bool fRestoreCache);

		/// <summary>
		/// <para>Retrieves the name of and handle to the executable (.exe) file associated with a specific document file.</para>
		/// </summary>
		/// <param name="lpFile">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The address of a <c>null</c>-terminated string that specifies a file name. This file should be a document.</para>
		/// </param>
		/// <param name="lpDirectory">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The address of a <c>null</c>-terminated string that specifies the default directory. This value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="lpResult">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// The address of a buffer that receives the file name of the associated executable file. This file name is a <c>null</c>-terminated
		/// string that specifies the executable file started when an "open" by association is run on the file specified in the parameter.
		/// Put simply, this is the application that is launched when the document file is directly double-clicked or when <c>Open</c> is
		/// chosen from the file's shortcut menu. This parameter must contain a valid non- <c>null</c> value and is assumed to be of length
		/// MAX_PATH. Responsibility for validating the value is left to the programmer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>Returns a value greater than 32 if successful, or a value less than or equal to 32 representing an error.</para>
		/// <para>The following table lists possible error values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SE_ERR_FNF 2</term>
		/// <term>The specified file was not found.</term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_PNF 3</term>
		/// <term>The specified path is invalid.</term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_ACCESSDENIED 5</term>
		/// <term>The specified file cannot be accessed.</term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_OOM 8</term>
		/// <term>The system is out of memory or resources.</term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_NOASSOC 31</term>
		/// <term>There is no association for the specified file type with an executable file.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Use <c>FindExecutable</c> for documents. If you want to retrieve the path of an executable file, use the following:</para>
		/// <para>
		/// Here, pszExecutableName is a pointer to a null-terminated string that specifies the name of the executable file, pszPath is a
		/// pointer to the null-terminated string buffer that receives the path to the executable file, and pcchOut is a pointer to a DWORD
		/// that specifies the number of characters in the pszPath buffer. When the function returns, pcchOut is set to the number of
		/// characters actually placed in the buffer. See AssocQueryString for more information.
		/// </para>
		/// <para>
		/// When <c>FindExecutable</c> returns, the parameter may contain the path to the Dynamic Data Exchange (DDE) server started if a
		/// server does not respond to a request to initiate a DDE conversation with the DDE client application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-findexecutablea HINSTANCE FindExecutableA( LPCSTR
		// lpFile, LPCSTR lpDirectory, LPSTR lpResult );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "969edbd9-164e-457f-ab0a-dc4d069bf16b")]
		public static extern IntPtr FindExecutable(string lpFile, string lpDirectory, StringBuilder lpResult);

		/// <summary>
		/// <para>Initializes the network address control window class.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the initialization succeeded; or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The network address control looks like an edit control and offers the additional functionality of network address verification.
		/// The control uses a balloon tip to display error messages.
		/// </para>
		/// <para>This function initializes class WC_NETADDRESS. If this function returns <c>TRUE</c>, the control can be created.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-initnetworkaddresscontrol BOOL
		// InitNetworkAddressControl( );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "52b475e3-7335-4c34-80d7-ccd81af0e0ec")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InitNetworkAddressControl();

		/// <summary>
		/// <para>Adds default properties to the property store as registered for the specified file extension.</para>
		/// </summary>
		/// <param name="pszExt">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>A pointer to a null-terminated, Unicode string that specifies the extension.</para>
		/// </param>
		/// <param name="pPropStore">
		/// <para>Type: <c>IPropertyStore*</c></para>
		/// <para>A pointer to the IPropertyStore interface that defines the default properties to add.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The list of properties used to set a default value comes from the registry value of the ProgID for the file association of the
		/// specified file extension. The list is prefixed by "" and contains the canonical names of the properties to set the default value,
		/// such as: "". The possible properties for this list are <c>System.Author</c>, <c>System.Document.DateCreated</c>, and
		/// <c>System.Photo.DateTaken</c>. If the value does not exist on the ProgID, this function uses the default found on the value of <c>HKEY_CLASSES_ROOT*</c>.
		/// </para>
		/// <para>
		/// <c>System.Author</c> has the value of the user that performed the action. <c>System.Document.DateCreated</c> and
		/// <c>System.Photo.DateTaken</c> use the current date. These three properties are the only ones for which the system provides
		/// special defaults.
		/// </para>
		/// <para>Note that there are several types of properties:</para>
		/// <list type="number">
		/// <item>Properties that derive from the file system (such as, size and date created)</item>
		/// <item>Properties that derive from the file (such as, dimensions and number of pages)</item>
		/// <item>Properties that are placed in the file (such as, author and tags)</item>
		/// </list>
		/// <para>
		/// When creating a new file, types one and two are provided just by creating the file. But properties of type three must be set
		/// explicitly by a program. The system provides
		/// </para>
		/// <para>SHAddDefaultPropertiesByExt</para>
		/// <para>
		/// to provide values for up to three specific properties of type three. Sometimes Windows Explorer uses this API when saving a file
		/// for the first time, or when creating a new file after the menu choice
		/// </para>
		/// <para>New</para>
		/// <para>is selected from a shortcut menu.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl/nf-shobjidl-shadddefaultpropertiesbyext SHSTDAPI
		// SHAddDefaultPropertiesByExt( PCWSTR pszExt, IPropertyStore *pPropStore );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shobjidl.h", MSDNShortId = "ba0fec36-3983-4064-9202-6158af565d9b")]
		public static extern HRESULT SHAddDefaultPropertiesByExt([MarshalAs(UnmanagedType.LPWStr)] string pszExt, IPropertyStore pPropStore);

		/// <summary>
		/// <para>
		/// [This function is available through Windows XP Service Pack 2 (SP2) and Windows Server 2003. It might be altered or unavailable
		/// in subsequent versions of Windows.]
		/// </para>
		/// <para>Adds pages to a property sheet extension array created by SHCreatePropSheetExtArray.</para>
		/// </summary>
		/// <param name="hpsxa">
		/// <para>Type: <c>HPSXA</c></para>
		/// <para>The array of property sheet handlers returned by SHCreatePropSheetExtArray.</para>
		/// </param>
		/// <param name="lpfnAddPage">
		/// <para>Type: <c>LPFNADDPROPSHEETPAGE</c></para>
		/// <para>
		/// A pointer to an AddPropSheetPageProc callback function. It is called once for each property sheet handler. The callback function
		/// then returns the information needed to add a page to the handler's property sheet.
		/// </para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>A pointer to application-defined data. This data is passed to the callback function specified by .</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Returns the number of pages actually added.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function should be called only once for the property sheet extension array named in .</para>
		/// <para>This function calls each extension's IShellPropSheetExt::AddPages method. See that page for further details.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlobj_core/nf-shlobj_core-shaddfrompropsheetextarray WINSHELLAPI UINT
		// SHAddFromPropSheetExtArray( HPSXA hpsxa, LPFNADDPROPSHEETPAGE lpfnAddPage, LPARAM lParam );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shlobj_core.h", MSDNShortId = "e0570cd6-dda2-43e4-8540-58baef37bf18")]
		public static extern uint SHAddFromPropSheetExtArray(IntPtr hpsxa, AddPropSheetPageProc lpfnAddPage, [Optional] IntPtr lParam);

		/// <summary>
		/// <para>
		/// [This function is available through Windows XP Service Pack 2 (SP2) and Windows Server 2003. It might be altered or unavailable
		/// in subsequent versions of Windows. Use CoTaskMemAlloc instead.]
		/// </para>
		/// <para>Allocates memory from the Shell's heap.</para>
		/// </summary>
		/// <param name="cb">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>The number of bytes of memory to allocate.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LPVOID</c></para>
		/// <para>A pointer to the allocated memory.</para>
		/// </returns>
		/// <remarks>
		/// <para>You can free this memory by calling SHFree.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlobj_core/nf-shlobj_core-shalloc
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shlobj_core.h", MSDNShortId = "621e4335-1484-4111-9cfe-7ae5c6d5c609")]
		public static extern IntPtr SHAlloc(SizeT cb);

		/// <summary>
		/// <para>Sends an appbar message to the system.</para>
		/// </summary>
		/// <param name="dwMessage">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Appbar message value to send. This parameter can be one of the following values.</para>
		/// <para>ABM_NEW (0x00000000)</para>
		/// <para>
		/// Registers a new appbar and specifies the message identifier that the system should use to send notification messages to the appbar.
		/// </para>
		/// <para>ABM_REMOVE (0x00000001)</para>
		/// <para>Unregisters an appbar, removing the bar from the system's internal list.</para>
		/// <para>ABM_QUERYPOS (0x00000002)</para>
		/// <para>Requests a size and screen position for an appbar.</para>
		/// <para>ABM_SETPOS (0x00000003)</para>
		/// <para>Sets the size and screen position of an appbar.</para>
		/// <para>ABM_GETSTATE (0x00000004)</para>
		/// <para>Retrieves the autohide and always-on-top states of the Windows taskbar.</para>
		/// <para>ABM_GETTASKBARPOS (0x00000005)</para>
		/// <para>
		/// Retrieves the bounding rectangle of the Windows taskbar. Note that this applies only to the system taskbar. Other objects,
		/// particularly toolbars supplied with third-party software, also can be present. As a result, some of the screen area not covered
		/// by the Windows taskbar might not be visible to the user. To retrieve the area of the screen not covered by both the taskbar and
		/// other app bars—the working area available to your application—, use the GetMonitorInfo function.
		/// </para>
		/// <para>ABM_ACTIVATE (0x00000006)</para>
		/// <para>
		/// Notifies the system to activate or deactivate an appbar. The <c>lParam</c> member of the APPBARDATA pointed to by is set to
		/// <c>TRUE</c> to activate or <c>FALSE</c> to deactivate.
		/// </para>
		/// <para>ABM_GETAUTOHIDEBAR (0x00000007)</para>
		/// <para>Retrieves the handle to the autohide appbar associated with a particular edge of the screen.</para>
		/// <para>ABM_SETAUTOHIDEBAR (0x00000008)</para>
		/// <para>Registers or unregisters an autohide appbar for an edge of the screen.</para>
		/// <para>ABM_WINDOWPOSCHANGED (0x00000009)</para>
		/// <para>Notifies the system when an appbar's position has changed.</para>
		/// <para>ABM_SETSTATE (0x0000000A)</para>
		/// <para><c>Windows XP and later:</c> Sets the state of the appbar's autohide and always-on-top attributes.</para>
		/// <para>ABM_GETAUTOHIDEBAREX (0x0000000B)</para>
		/// <para>
		/// <c>Windows XP and later:</c> Retrieves the handle to the autohide appbar associated with a particular edge of a particular monitor.
		/// </para>
		/// <para>ABM_SETAUTOHIDEBAREX (0x0000000C)</para>
		/// <para><c>Windows XP and later:</c> Registers or unregisters an autohide appbar for an edge of a particular monitor.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>PAPPBARDATA</c></para>
		/// <para>
		/// A pointer to an APPBARDATA structure. The content of the structure on entry and on exit depends on the value set in the
		/// parameter. See the individual message pages for specifics.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT_PTR</c></para>
		/// <para>
		/// This function returns a message-dependent value. For more information, see the Windows SDK documentation for the specific appbar
		/// message sent. Links to those documents are given in the See Also section.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shappbarmessage UINT_PTR SHAppBarMessage( DWORD
		// dwMessage, PAPPBARDATA pData );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "173d6eff-b33b-4d7d-bedd-5ebfb1e45954")]
		public static extern UIntPtr SHAppBarMessage(ABM dwMessage, ref APPBARDATA pData);

		/// <summary>
		/// <para>Sends a message to the taskbar's status area.</para>
		/// </summary>
		/// <param name="dwMessage">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A value that specifies the action to be taken by this function. It can have one of the following values:</para>
		/// <para>NIM_ADD (0x00000000)</para>
		/// <para>
		/// 0x00000000. Adds an icon to the status area. The icon is given an identifier in the NOTIFYICONDATA structure pointed to by
		/// lpdata—either through its <c>uID</c> or <c>guidItem</c> member. This identifier is used in subsequent calls to
		/// <c>Shell_NotifyIcon</c> to perform later actions on the icon.
		/// </para>
		/// <para>NIM_MODIFY (0x00000001)</para>
		/// <para>
		/// 0x00000001. Modifies an icon in the status area. NOTIFYICONDATA structure pointed to by lpdata uses the ID originally assigned to
		/// the icon when it was added to the notification area (NIM_ADD) to identify the icon to be modified.
		/// </para>
		/// <para>NIM_DELETE (0x00000002)</para>
		/// <para>
		/// 0x00000002. Deletes an icon from the status area. NOTIFYICONDATA structure pointed to by lpdata uses the ID originally assigned
		/// to the icon when it was added to the notification area (NIM_ADD) to identify the icon to be deleted.
		/// </para>
		/// <para>NIM_SETFOCUS (0x00000003)</para>
		/// <para>
		/// 0x00000003. Shell32.dll version 5.0 and later only. Returns focus to the taskbar notification area. Notification area icons
		/// should use this message when they have completed their UI operation. For example, if the icon displays a shortcut menu, but the
		/// user presses ESC to cancel it, use <c>NIM_SETFOCUS</c> to return focus to the notification area.
		/// </para>
		/// <para>NIM_SETVERSION (0x00000004)</para>
		/// <para>
		/// 0x00000004. Shell32.dll version 5.0 and later only. Instructs the notification area to behave according to the version number
		/// specified in the <c>uVersion</c> member of the structure pointed to by lpdata. The version number specifies which members are recognized.
		/// </para>
		/// <para>
		/// NIM_SETVERSION must be called every time a notification area icon is added (NIM_ADD)&gt;. It does not need to be called with
		/// NIM_MOFIDY. The version setting is not persisted once a user logs off.
		/// </para>
		/// <para>For details, see the Remarks section.</para>
		/// </param>
		/// <param name="lpData">
		/// <para>Type: <c>PNOTIFYICONDATA</c></para>
		/// <para>
		/// A pointer to a NOTIFYICONDATA structure. The content of the structure depends on the value of dwMessage. It can define an icon to
		/// add to the notification area, cause that icon to display a notification, or identify an icon to modify or delete.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. If dwMessage is set to NIM_SETVERSION, the function returns
		/// <c>TRUE</c> if the version was successfully changed, or <c>FALSE</c> if the requested version is not supported.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// As of Windows 2000 (Shell32.dll version 5.0), if you set the <c>uVersion</c> member of the NOTIFYICONDATA structure pointed to by
		/// lpdata to NOTIFYICON_VERSION_4 or higher, <c>Shell_NotifyIcon</c> mouse and keyboard events are handled differently than in
		/// earlier versions of Windows. The differences include the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If a user selects a notify icon's shortcut menu with the keyboard, the Shell now sends the associated application a
		/// WM_CONTEXTMENU message. Earlier versions send WM_RBUTTONDOWN and WM_RBUTTONUP messages.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If a user selects a notify icon with the keyboard and activates it with the SPACEBAR or ENTER key, the version 5.0 Shell sends
		/// the associated application an NIN_KEYSELECT notification. Earlier versions send WM_RBUTTONDOWN and WM_RBUTTONUP messages.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If a user selects a notify icon with the mouse and activates it with the ENTER key, the Shell now sends the associated
		/// application an NIN_SELECT notification. Earlier versions send WM_RBUTTONDOWN and WM_RBUTTONUP messages.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// As of Windows XP (Shell32.dll version 6.0), if a user passes the mouse pointer over an icon with which a balloon notification is
		/// associated, the Shell sends the following messages:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>NIN_BALLOONSHOW. Sent when the balloon is shown (balloons are queued).</term>
		/// </item>
		/// <item>
		/// <term>
		/// NIN_BALLOONHIDE. Sent when the balloon disappears. For example, when the icon is deleted. This message is not sent if the balloon
		/// is dismissed because of a timeout or if the user clicks the mouse.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NIN_BALLOONTIMEOUT. Sent when the balloon is dismissed because of a timeout.</term>
		/// </item>
		/// <item>
		/// <term>NIN_BALLOONUSERCLICK. Sent when the balloon is dismissed because the user clicked the mouse.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In addition to those messages, as of Windows Vista (Shell32.dll version 6.0.6), if a user passes the mouse pointer over an icon
		/// with which a balloon notification is associated, the Windows Vista Shell also adds the following messages:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// NIN_POPUPOPEN. Sent when the user hovers the cursor over an icon to indicate that the richer pop-up UI should be used in place of
		/// a standard textual tooltip.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NIN_POPUPCLOSE. Sent when a cursor no longer hovers over an icon to indicate that the rich pop-up UI should be closed.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Regardless of the operating system version, you can select which way the Shell should behave by calling <c>Shell_NotifyIcon</c>
		/// with dwMessage set to <c>NIM_SETVERSION</c>. Set the <c>uVersion</c> member of the NOTIFYICONDATA structure pointed to by lpdata
		/// to indicate whether you want Windows 2000, Windows Vista, or pre-version 5.0 (Windows 95) behavior.
		/// </para>
		/// <para>
		/// <c>Note</c> The messages discussed above are not conventional Windows messages. They are sent as the lParam value of the
		/// application-defined message that is specified in the <c>uCallbackMessage</c> member of the NOTIFYICONDATA structure pointed to by
		/// lpdata, when <c>Shell_NotifyIcon</c> is called with the <c>NIM_ADD</c> flag set in dwMessage.
		/// </para>
		/// <para>
		/// As of Windows XP Service Pack 2 (SP2), a custom icon can be displayed in the notification balloon. This allows the calling
		/// process to customize the notification beyond the previously available options of info, warning, and error, and distinguish it
		/// from other types of notification for the user.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shell_notifyicona BOOL Shell_NotifyIconA( DWORD
		// dwMessage, PNOTIFYICONDATAA lpData );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "a316bc29-5f19-4a04-a32b-f4caeea0c029")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Shell_NotifyIcon(NIM dwMessage, in NOTIFYICONDATA lpData);

		/// <summary>
		/// <para>Gets the screen coordinates of the bounding rectangle of a notification icon.</para>
		/// </summary>
		/// <param name="identifier">
		/// <para>Type: <c>const NOTIFYICONIDENTIFIER*</c></para>
		/// <para>Pointer to a NOTIFYICONIDENTIFIER structure that identifies the icon.</para>
		/// </param>
		/// <param name="iconLocation">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>Pointer to a RECT structure that, when this function returns successfully, receives the coordinates of the icon.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shell_notifyicongetrect SHSTDAPI
		// Shell_NotifyIconGetRect( const NOTIFYICONIDENTIFIER *identifier, RECT *iconLocation );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "81ad13be-a908-4079-b47c-6f983919700b")]
		public static extern HRESULT Shell_NotifyIconGetRect(in NOTIFYICONIDENTIFIER identifier, out RECT iconLocation);

		/// <summary>
		/// <para>Displays a <c>ShellAbout</c> dialog box.</para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A window handle to a parent window. This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="szApp">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string that contains text to be displayed in the title bar of the <c>ShellAbout</c> dialog box and
		/// on the first line of the dialog box after the text "Microsoft". If the text contains a separator (#) that divides it into two
		/// parts, the function displays the first part in the title bar and the second part on the first line after the text "Microsoft".
		/// </para>
		/// <para>
		/// <c>Windows 2000, Windows XP, Windows Server 2003</c>: If the string pointed to by this parameter contains a separator (#), then
		/// the string must be writeable.
		/// </para>
		/// <para><c>Windows Vista, Windows Server 2008</c>: This string cannot exceed 200 characters in length.</para>
		/// </param>
		/// <param name="szOtherStuff">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string that contains text to be displayed in the dialog box after the version and copyright
		/// information. This parameter can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="hIcon">
		/// <para>Type: <c>HICON</c></para>
		/// <para>
		/// The handle of an icon that the function displays in the dialog box. This parameter can be <c>NULL</c>, in which case the function
		/// displays the Windows icon.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>Note that the <c>ShellAbout</c> function dialog box uses text and a default icon that are specific to Windows.</para>
		/// <para>
		/// To see an example of a <c>ShellAbout</c> dialog box, choose <c>About Windows</c> from the <c>Help</c> menu drop-down list in
		/// Windows Explorer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shellabouta INT ShellAboutA( HWND hWnd, LPCSTR szApp,
		// LPCSTR szOtherStuff, HICON hIcon );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "0919e356-84e8-475e-8628-23097b19c50d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShellAbout([Optional] HWND hWnd, string szApp, [Optional] string szOtherStuff, [Optional] HICON hIcon);

		/// <summary>
		/// <para>Performs an operation on a specified file.</para>
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the parent window used for displaying a UI or error messages. This value can be <c>NULL</c> if the operation is not
		/// associated with a window.
		/// </para>
		/// </param>
		/// <param name="lpOperation">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a <c>null</c>-terminated string, referred to in this case as a , that specifies the action to be performed. The set
		/// of available verbs depends on the particular file or folder. Generally, the actions available from an object's shortcut menu are
		/// available verbs. The following verbs are commonly used:
		/// </para>
		/// <para>edit</para>
		/// <para>Launches an editor and opens the document for editing. If is not a document file, the function will fail.</para>
		/// <para>explore</para>
		/// <para>Explores a folder specified by .</para>
		/// <para>find</para>
		/// <para>Initiates a search beginning in the directory specified by .</para>
		/// <para>open</para>
		/// <para>Opens the item specified by the parameter. The item can be a file or folder.</para>
		/// <para>print</para>
		/// <para>Prints the file specified by . If is not a document file, the function fails.</para>
		/// <para>NULL</para>
		/// <para>
		/// The default verb is used, if available. If not, the "open" verb is used. If neither verb is available, the system uses the first
		/// verb listed in the registry.
		/// </para>
		/// </param>
		/// <param name="lpFile">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a <c>null</c>-terminated string that specifies the file or object on which to execute the specified verb. To specify
		/// a Shell namespace object, pass the fully qualified parse name. Note that not all verbs are supported on all objects. For example,
		/// not all document types support the "print" verb. If a relative path is used for the parameter do not use a relative path for .
		/// </para>
		/// </param>
		/// <param name="lpParameters">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// If specifies an executable file, this parameter is a pointer to a <c>null</c>-terminated string that specifies the parameters to
		/// be passed to the application. The format of this string is determined by the verb that is to be invoked. If specifies a document
		/// file, should be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="lpDirectory">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a <c>null</c>-terminated string that specifies the default (working) directory for the action. If this value is
		/// <c>NULL</c>, the current working directory is used. If a relative path is provided at , do not use a relative path for .
		/// </para>
		/// </param>
		/// <param name="nShowCmd">
		/// <para>Type: <c>INT</c></para>
		/// <para>
		/// The flags that specify how an application is to be displayed when it is opened. If specifies a document file, the flag is simply
		/// passed to the associated application. It is up to the application to decide how to handle it. These values are defined in Winuser.h.
		/// </para>
		/// <para>SW_HIDE (0)</para>
		/// <para>Hides the window and activates another window.</para>
		/// <para>SW_MAXIMIZE (3)</para>
		/// <para>Maximizes the specified window.</para>
		/// <para>SW_MINIMIZE (6)</para>
		/// <para>Minimizes the specified window and activates the next top-level window in the z-order.</para>
		/// <para>SW_RESTORE (9)</para>
		/// <para>
		/// Activates and displays the window. If the window is minimized or maximized, Windows restores it to its original size and
		/// position. An application should specify this flag when restoring a minimized window.
		/// </para>
		/// <para>SW_SHOW (5)</para>
		/// <para>Activates the window and displays it in its current size and position.</para>
		/// <para>SW_SHOWDEFAULT (10)</para>
		/// <para>
		/// Sets the show state based on the SW_ flag specified in the STARTUPINFO structure passed to the CreateProcess function by the
		/// program that started the application. An application should call ShowWindow with this flag to set the initial show state of its
		/// main window.
		/// </para>
		/// <para>SW_SHOWMAXIMIZED (3)</para>
		/// <para>Activates the window and displays it as a maximized window.</para>
		/// <para>SW_SHOWMINIMIZED (2)</para>
		/// <para>Activates the window and displays it as a minimized window.</para>
		/// <para>SW_SHOWMINNOACTIVE (7)</para>
		/// <para>Displays the window as a minimized window. The active window remains active.</para>
		/// <para>SW_SHOWNA (8)</para>
		/// <para>Displays the window in its current state. The active window remains active.</para>
		/// <para>SW_SHOWNOACTIVATE (4)</para>
		/// <para>Displays a window in its most recent size and position. The active window remains active.</para>
		/// <para>SW_SHOWNORMAL (1)</para>
		/// <para>
		/// Activates and displays a window. If the window is minimized or maximized, Windows restores it to its original size and position.
		/// An application should specify this flag when displaying the window for the first time.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// If the function succeeds, it returns a value greater than 32. If the function fails, it returns an error value that indicates the
		/// cause of the failure. The return value is cast as an HINSTANCE for backward compatibility with 16-bit Windows applications. It is
		/// not a true HINSTANCE, however. It can be cast only to an <c>int</c> and compared to either 32 or the following error codes below.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The operating system is out of memory or resources.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>The specified file was not found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATH_NOT_FOUND</term>
		/// <term>The specified path was not found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_FORMAT</term>
		/// <term>The .exe file is invalid (non-Win32 .exe or error in .exe image).</term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_ACCESSDENIED</term>
		/// <term>The operating system denied access to the specified file.</term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_ASSOCINCOMPLETE</term>
		/// <term>The file name association is incomplete or invalid.</term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_DDEBUSY</term>
		/// <term>The DDE transaction could not be completed because other DDE transactions were being processed.</term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_DDEFAIL</term>
		/// <term>The DDE transaction failed.</term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_DDETIMEOUT</term>
		/// <term>The DDE transaction could not be completed because the request timed out.</term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_DLLNOTFOUND</term>
		/// <term>The specified DLL was not found.</term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_FNF</term>
		/// <term>The specified file was not found.</term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_NOASSOC</term>
		/// <term>
		/// There is no application associated with the given file name extension. This error will also be returned if you attempt to print a
		/// file that is not printable.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_OOM</term>
		/// <term>There was not enough memory to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_PNF</term>
		/// <term>The specified path was not found.</term>
		/// </item>
		/// <item>
		/// <term>SE_ERR_SHARE</term>
		/// <term>A sharing violation occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Because <c>ShellExecute</c> can delegate execution to Shell extensions (data sources, context menu handlers, verb
		/// implementations) that are activated using Component Object Model (COM), COM should be initialized before <c>ShellExecute</c> is
		/// called. Some Shell extensions require the COM single-threaded apartment (STA) type. In that case, COM should be initialized as
		/// shown here:
		/// </para>
		/// <para>This method allows you to execute any commands in a folder's shortcut menu or stored in the registry.</para>
		/// <para>To open a folder, use either of the following calls:</para>
		/// <para>or</para>
		/// <para>To explore a folder, use the following call:</para>
		/// <para>To launch the Shell's Find utility for a directory, use the following call.</para>
		/// <para>If</para>
		/// <para>lpOperation</para>
		/// <para>is</para>
		/// <para>NULL</para>
		/// <para>, the function opens the file specified by</para>
		/// <para>lpFile</para>
		/// <para>. If</para>
		/// <para>lpOperation</para>
		/// <para>is "open" or "explore", the function attempts to open or explore the folder.</para>
		/// <para>To obtain information about the application that is launched as a result of calling <c>ShellExecute</c>, use ShellExecuteEx.</para>
		/// <para>
		/// <c>Note</c> The <c>Launch folder windows in a separate process</c> setting in Folder Options affects <c>ShellExecute</c>. If that
		/// option is disabled (the default setting), <c>ShellExecute</c> uses an open Explorer window rather than launch a new one. If no
		/// Explorer window is open, <c>ShellExecute</c> launches a new one.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shellexecutea HINSTANCE ShellExecuteA( HWND hwnd, LPCSTR
		// lpOperation, LPCSTR lpFile, LPCSTR lpParameters, LPCSTR lpDirectory, INT nShowCmd );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "8b1f3978-a0ee-4684-8a37-98e270b63897")]
		public static extern IntPtr ShellExecute([Optional] HWND hwnd, [Optional] string lpOperation, string lpFile, [Optional] string lpParameters,
			[Optional] string lpDirectory, ShowWindowCommand nShowCmd);

		/// <summary>Performs an operation on a specified file.</summary>
		/// <param name="lpExecInfo">
		/// A pointer to a SHELLEXECUTEINFO structure that contains and receives information about the application being executed.
		/// </param>
		/// <returns>Returns TRUE if successful; otherwise, FALSE. Call GetLastError for extended error information.</returns>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Shellapi.h", MSDNShortId = "bb762154")]
		public static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

		/// <summary>
		/// <para>Empties the Recycle Bin on the specified drive.</para>
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the parent window of any dialog boxes that might be displayed during the operation. This parameter can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pszRootPath">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The address of a null-terminated string of maximum length MAX_PATH that contains the path of the root drive on which the Recycle
		/// Bin is located. This parameter can contain the address of a string formatted with the drive, folder, and subfolder names, for
		/// example c:\windows\system. It can also contain an empty string or <c>NULL</c>. If this value is an empty string or <c>NULL</c>,
		/// all Recycle Bins on all drives will be emptied.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>One or more of the following values.</para>
		/// <para>SHERB_NOCONFIRMATION</para>
		/// <para>No dialog box confirming the deletion of the objects will be displayed.</para>
		/// <para>SHERB_NOPROGRESSUI</para>
		/// <para>No dialog box indicating the progress will be displayed.</para>
		/// <para>SHERB_NOSOUND</para>
		/// <para>No sound will be played when the operation is complete.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shemptyrecyclebina SHSTDAPI SHEmptyRecycleBinA( HWND
		// hwnd, LPCSTR pszRootPath, DWORD dwFlags );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "c3995be7-bc8b-4e1f-8ef6-fdf4c0a75720")]
		public static extern HRESULT SHEmptyRecycleBin([Optional] HWND hwnd, [Optional] string pszRootPath, SHERB dwFlags);

		/// <summary>
		/// <para>Enumerates the user accounts that have unread email.</para>
		/// </summary>
		/// <param name="hKeyUser">
		/// <para>Type: <c>HKEY</c></para>
		/// <para>A valid HKEY for a given user.</para>
		/// </param>
		/// <param name="dwIndex">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The index of the user account.</para>
		/// </param>
		/// <param name="pszMailAddress">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>A pointer to a Unicode string that specifies the email address of an account belonging to the specified user.</para>
		/// </param>
		/// <param name="cchMailAddress">
		/// <para>Type: <c>int</c></para>
		/// <para>The number of characters in the email address.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The parameter is the HKEY for the root of the user's information, for example <c>HKEY_CURRENT_USER</c>, or any key enumerated
		/// under <c>HKEY_USERS</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shenumerateunreadmailaccountsw HRESULT
		// SHEnumerateUnreadMailAccountsW( HKEY hKeyUser, DWORD dwIndex, LPWSTR pszMailAddress, int cchMailAddress );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "67ec8355-f902-4b71-972f-94e403701f96")]
		public static extern HRESULT SHEnumerateUnreadMailAccounts(HKEY hKeyUser, uint dwIndex, StringBuilder pszMailAddress, int cchMailAddress);

		/// <summary>
		/// <para>Enforces strict validation of parameters used in a call to CreateProcess or ShellExecute.</para>
		/// </summary>
		/// <param name="pszCmdTemplate">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>
		/// A command line, which may or may not include parameters. If the parameters are substitution parameters, then
		/// <c>SHEvaluateSystemCommandTemplate</c> should be called before parameters have been replaced.
		/// </para>
		/// </param>
		/// <param name="ppszApplication">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// A pointer to the verified path to the application. This value should be passed as the parameter in a call to CreateProcess or as
		/// the parameter in a call to ShellExecute. This resource is allocated using CoTaskMemAlloc, and it is the responsibility of the
		/// caller to free the resource when it is no longer needed by calling CoTaskMemFree.
		/// </para>
		/// </param>
		/// <param name="ppszCommandLine">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// A pointer to a command-line string template to be used in a call to CreateProcess. Command-line parameters should be specified
		/// based on this template, and then passed as the parameter to <c>CreateProcess</c>. It is guaranteed to be of a form that
		/// PathGetArgs can always read correctly. This resource is allocated using CoTaskMemAlloc, and it is the responsibility of the
		/// caller to free the resource when it is no longer needed by calling CoTaskMemFree.
		/// </para>
		/// <para>This parameter can be <c>NULL</c> if this function is not being used in association with a call to CreateProcess.</para>
		/// </param>
		/// <param name="ppszParameters">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// A pointer to a command-line string template to be used in a call to ShellExecute. Command-line parameters should be specified
		/// based on this template, and then passed as the parameter to <c>ShellExecute</c>. This parameter is identical to calling
		/// PathGetArgs. This resource is allocated using CoTaskMemAlloc, and it is the responsibility of the caller to free the resource
		/// when it is no longer needed by calling CoTaskMemFree.
		/// </para>
		/// <para>This parameter can be <c>NULL</c> if this function is not being used in association with a call to CreateProcess.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is used when a calling process needs the deterministic behavior from a command template, regardless of execution
		/// context. It ignores the current process state, such as the , GetCurrentDirectory, and parent process directory.
		/// </para>
		/// <para>This function is used when the command is hard-coded.</para>
		/// <para>
		/// This function is used by ShellExecute when handling file associations from HKEY_CLASSES_ROOT. The purpose of this function is to
		/// reduce CreateProcess command-line exploits. It is not designed for processing user input and if used for that purpose can
		/// generate unexpected failures.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shevaluatesystemcommandtemplate SHSTDAPI
		// SHEvaluateSystemCommandTemplate( PCWSTR pszCmdTemplate, PWSTR *ppszApplication, PWSTR *ppszCommandLine, PWSTR *ppszParameters );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("shellapi.h", MSDNShortId = "554b941d-7d03-47ae-a23a-2c47c5ca1044")]
		public static extern HRESULT SHEvaluateSystemCommandTemplate(string pszCmdTemplate,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszApplication,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszCommandLine,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszParameters);

		/// <summary>
		/// Copies, moves, renames, or deletes a file system object. This function has been replaced in Windows Vista by <see cref="IFileOperation"/>.
		/// </summary>
		/// <param name="lpFileOp">
		/// A pointer to an SHFILEOPSTRUCT structure that contains information this function needs to carry out the specified operation. This
		/// parameter must contain a valid value that is not NULL. You are responsible for validating the value. If you do not validate it,
		/// you will experience unexpected results.
		/// </param>
		/// <returns>Returns zero if successful; otherwise nonzero. Applications normally should simply check for zero or nonzero.</returns>
		[PInvokeData("Shellapi.h")]
		[DllImport("shell32.dll", CharSet = CharSet.Auto)]
		public static extern int SHFileOperation(ref SHFILEOPSTRUCT lpFileOp);

		/// <summary>
		/// <para>Frees a file name mapping object that was retrieved by the SHFileOperation function.</para>
		/// </summary>
		/// <param name="hNameMappings">
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A handle to the file name mapping object to be freed.</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shfreenamemappings void SHFreeNameMappings( HANDLE
		// hNameMappings );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "4552b2e0-9257-48f8-84cc-003217f1696f")]
		public static extern void SHFreeNameMappings(IntPtr hNameMappings);

		/// <summary>Retrieves disk space information for a disk volume.</summary>
		/// <param name="pszVolume">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A null-terminated string that specifies the volume for which size information is retrieved. This can be a drive letter, UNC name,
		/// or the path of a folder. You cannot use <c>NULL</c> to represent the current drive.
		/// </para>
		/// <para>
		/// When using Shell32.dll versions previous to version 5.0, this must be an ANSI string. Unicode is not supported in those versions.
		/// </para>
		/// </param>
		/// <param name="pqwFreeCaller">
		/// <para>Type: <c><c>ULARGE_INTEGER</c>*</c></para>
		/// <para>
		/// The address of a <c>ULARGE_INTEGER</c> value that receives the number of bytes on the volume available to the calling
		/// application. If the operating system implements per-user quotas, this value may be less than the total number of free bytes on
		/// the volume.
		/// </para>
		/// </param>
		/// <param name="pqwTot">
		/// <para>Type: <c><c>ULARGE_INTEGER</c>*</c></para>
		/// <para>The address of a <c>ULARGE_INTEGER</c> value that receives the total size of the volume, in bytes.</para>
		/// </param>
		/// <param name="pqwFree">
		/// <para>Type: <c><c>ULARGE_INTEGER</c>*</c></para>
		/// <para>The address of a <c>ULARGE_INTEGER</c> value that receives the number of bytes of free space on the volume.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, <c>FALSE</c> otherwise.</para>
		/// </returns>
		// BOOL SHGetDiskFreeSpace( LPCTSTR pszVolume, ULARGE_INTEGER *pqwFreeCaller, ULARGE_INTEGER *pqwTot, ULARGE_INTEGER *pqwFree); https://msdn.microsoft.com/en-us/library/windows/desktop/bb762176(v=vs.85).aspx
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Shellapi.h", MSDNShortId = "bb762176")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SHGetDiskFreeSpace(string pszVolume, out ulong pqwFreeCaller, out ulong pqwTot, out ulong pqwFree);

		/// <summary>
		/// <para>Retrieves disk space information for a disk volume.</para>
		/// </summary>
		/// <param name="pszDirectoryName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A null-terminated string that specifies the volume for which size information is retrieved. This can be a drive letter, UNC name,
		/// or the path of a folder. You cannot use <c>NULL</c> to represent the current drive.
		/// </para>
		/// </param>
		/// <param name="pulFreeBytesAvailableToCaller">
		/// <para>Type: <c>ULARGE_INTEGER*</c></para>
		/// <para>
		/// Pointer to a value that receives the number of bytes on the volume available to the calling application. If the operating system
		/// implements per-user quotas, this value may be less than the total number of free bytes on the volume.
		/// </para>
		/// </param>
		/// <param name="pulTotalNumberOfBytes">
		/// <para>Type: <c>ULARGE_INTEGER*</c></para>
		/// <para>Pointer to a value that receives the total size of the volume, in bytes.</para>
		/// </param>
		/// <param name="pulTotalNumberOfFreeBytes">
		/// <para>Type: <c>ULARGE_INTEGER*</c></para>
		/// <para>Pointer to a value that receives the number of bytes of free space on the volume.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The similarly named function SHGetDiskFreeSpace is merely an alias for <c>SHGetDiskFreeSpaceEx</c>. When you call
		/// <c>SHGetDiskFreeSpace</c> you actually call this function.
		/// </para>
		/// <para>
		/// This function calls the GetDiskFreeSpaceEx function if it is available on the operating system. If <c>GetDiskFreeSpaceEx</c> is
		/// not available, it is emulated by calling the GetDiskFreeSpace function and manipulating the return values. For additional
		/// information, see the documentation for <c>GetDiskFreeSpaceEx</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shgetdiskfreespaceexa BOOL SHGetDiskFreeSpaceExA( LPCSTR
		// pszDirectoryName, ULARGE_INTEGER *pulFreeBytesAvailableToCaller, ULARGE_INTEGER *pulTotalNumberOfBytes, ULARGE_INTEGER
		// *pulTotalNumberOfFreeBytes );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "f8adbfa8-124a-4934-b5dc-16e261c15a8b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SHGetDiskFreeSpaceEx(string pszDirectoryName, out ulong pulFreeBytesAvailableToCaller, out ulong pulTotalNumberOfBytes, out ulong pulTotalNumberOfFreeBytes);

		/// <summary>
		/// <para>Returns the type of media that is in the given drive.</para>
		/// </summary>
		/// <param name="pszDrive">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>The drive in which to check the media type.</para>
		/// </param>
		/// <param name="pdwMediaContent">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A pointer to the type of media in the given drive. A combination of ARCONTENT flags.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shgetdrivemedia HRESULT SHGetDriveMedia( PCWSTR
		// pszDrive, DWORD *pdwMediaContent );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "9b1208cd-3c13-456a-8a7f-0f149cb86d38")]
		public static extern HRESULT SHGetDriveMedia([MarshalAs(UnmanagedType.LPWStr)] string pszDrive, out ARCONTENT pdwMediaContent);

		/// <summary>Retrieves information about an object in the file system, such as a file, folder, directory, or drive root.</summary>
		/// <param name="pszPath">
		/// A pointer to a null-terminated string of maximum length MAX_PATH that contains the path and file name. Both absolute and relative
		/// paths are valid.
		/// <para>
		/// If the uFlags parameter includes the SHGFI_PIDL flag, this parameter must be the address of an ITEMIDLIST (PIDL) structure that
		/// contains the list of item identifiers that uniquely identifies the file within the Shell's namespace. The PIDL must be a fully
		/// qualified PIDL. Relative PIDLs are not allowed.
		/// </para>
		/// <para>
		/// If the uFlags parameter includes the SHGFI_USEFILEATTRIBUTES flag, this parameter does not have to be a valid file name. The
		/// function will proceed as if the file exists with the specified name and with the file attributes passed in the dwFileAttributes
		/// parameter. This allows you to obtain information about a file type by passing just the extension for pszPath and passing
		/// FILE_ATTRIBUTE_NORMAL in dwFileAttributes.
		/// </para>
		/// <para>This string can use either short (the 8.3 form) or long file names.</para>
		/// </param>
		/// <param name="dwFileAttributes">
		/// A combination of one or more file attribute flags (FILE_ATTRIBUTE_ values as defined in Winnt.h). If uFlags does not include the
		/// SHGFI_USEFILEATTRIBUTES flag, this parameter is ignored.
		/// </param>
		/// <param name="psfi">Pointer to a SHFILEINFO structure to receive the file information.</param>
		/// <param name="cbFileInfo">The size, in bytes, of the SHFILEINFO structure pointed to by the psfi parameter.</param>
		/// <param name="uFlags">The flags that specify the file information to retrieve.</param>
		/// <returns>
		/// Returns a value whose meaning depends on the uFlags parameter.
		/// <para>If uFlags does not contain SHGFI_EXETYPE or SHGFI_SYSICONINDEX, the return value is nonzero if successful, or zero otherwise.</para>
		/// <para>
		/// If uFlags contains the SHGFI_EXETYPE flag, the return value specifies the type of the executable file. It will be one of the
		/// following values.
		/// </para>
		/// </returns>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("Shellapi.h", MSDNShortId = "bb762179")]
		public static extern IntPtr SHGetFileInfo(string pszPath, FileAttributes dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, SHGFI uFlags);

		/// <summary>Retrieves information about an object in the file system, such as a file, folder, directory, or drive root.</summary>
		/// <param name="itemIdList">
		/// A pointer to a null-terminated string of maximum length MAX_PATH that contains the path and file name. Both absolute and relative
		/// paths are valid.
		/// <para>
		/// If the uFlags parameter includes the SHGFI_PIDL flag, this parameter must be the address of an ITEMIDLIST (PIDL) structure that
		/// contains the list of item identifiers that uniquely identifies the file within the Shell's namespace. The PIDL must be a fully
		/// qualified PIDL. Relative PIDLs are not allowed.
		/// </para>
		/// <para>
		/// If the uFlags parameter includes the SHGFI_USEFILEATTRIBUTES flag, this parameter does not have to be a valid file name. The
		/// function will proceed as if the file exists with the specified name and with the file attributes passed in the dwFileAttributes
		/// parameter. This allows you to obtain information about a file type by passing just the extension for pszPath and passing
		/// FILE_ATTRIBUTE_NORMAL in dwFileAttributes.
		/// </para>
		/// <para>This string can use either short (the 8.3 form) or long file names.</para>
		/// </param>
		/// <param name="dwFileAttributes">
		/// A combination of one or more file attribute flags (FILE_ATTRIBUTE_ values as defined in Winnt.h). If uFlags does not include the
		/// SHGFI_USEFILEATTRIBUTES flag, this parameter is ignored.
		/// </param>
		/// <param name="psfi">Pointer to a SHFILEINFO structure to receive the file information.</param>
		/// <param name="cbFileInfo">The size, in bytes, of the SHFILEINFO structure pointed to by the psfi parameter.</param>
		/// <param name="uFlags">The flags that specify the file information to retrieve.</param>
		/// <returns>
		/// Returns a value whose meaning depends on the uFlags parameter.
		/// <para>If uFlags does not contain SHGFI_EXETYPE or SHGFI_SYSICONINDEX, the return value is nonzero if successful, or zero otherwise.</para>
		/// <para>
		/// If uFlags contains the SHGFI_EXETYPE flag, the return value specifies the type of the executable file. It will be one of the
		/// following values.
		/// </para>
		/// </returns>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("Shellapi.h", MSDNShortId = "bb762179")]
		public static extern IntPtr SHGetFileInfo(PIDL itemIdList, FileAttributes dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, SHGFI uFlags);

		/// <summary>
		/// <para>Retrieves the localized name of a file in a Shell folder.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>A pointer to a string that specifies the fully qualified path of the file.</para>
		/// </param>
		/// <param name="pszResModule">
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>When this function returns, contains a pointer to a string resource that specifies the localized version of the file name.</para>
		/// </param>
		/// <param name="cch">
		/// <para>Type: <c>UINT</c></para>
		/// <para>When this function returns, contains the size of the string, in <c>WCHARs</c>, at pszResModule.</para>
		/// </param>
		/// <param name="pidsRes">
		/// <para>Type: <c>int*</c></para>
		/// <para>When this function returns, contains a pointer to the ID of the localized file name in the resource file.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shgetlocalizedname SHSTDAPI SHGetLocalizedName( PCWSTR
		// pszPath, PWSTR pszResModule, UINT cch, int *pidsRes );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "2929b77f-4467-44a8-9885-96f0c3e35584")]
		public static extern HRESULT SHGetLocalizedName([MarshalAs(UnmanagedType.LPWStr)] string pszPath, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszResModule, uint cch, out int pidsRes);

		/// <summary>
		/// <para>
		/// Creates a name for a new shortcut based on the shortcut's proposed target. This function does not create the shortcut, just the name.
		/// </para>
		/// </summary>
		/// <param name="pszLinkTo">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to the path and file name of the shortcut's target. If does not contain the <c>SHGNLI_PIDL</c> value, this parameter is
		/// the address of a null-terminated string that contains the target. If contains the <c>SHGNLI_PIDL</c> value, this parameter is a
		/// PIDL that represents the target.
		/// </para>
		/// </param>
		/// <param name="pszDir">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string that contains the path of the folder in which the shortcut would be created.</para>
		/// </param>
		/// <param name="pszName">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a string that receives the null-terminated path and file name for the shortcut. This buffer is assumed to be at
		/// least MAX_PATH characters in size.
		/// </para>
		/// </param>
		/// <param name="pfMustCopy">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// The address of a <c>BOOL</c> value that receives a flag indicating whether the shortcut would be copied. When a shortcut to
		/// another shortcut is created, the Shell simply copies the target shortcut and modifies that copied shortcut appropriately. This
		/// parameter receives a nonzero value if the target specified in specifies a shortcut that will cause the target shortcut to be
		/// copied. This parameter receives zero if the target does not specify a shortcut that would be copied.
		/// </para>
		/// </param>
		/// <param name="uFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The options for the function. This can be zero or a combination of the following values.</para>
		/// <para>SHGNLI_PIDL (0x000000001)</para>
		/// <para>
		/// 0x000000001. The target pointed to by is a PIDL that represents the target. If this flag is not included, is regarded as the
		/// address of a string that contains the path and file name of the target.
		/// </para>
		/// <para>SHGNLI_NOUNIQUE (0x000000002)</para>
		/// <para>
		/// 0x000000002. Skip the normal checks that ensure that the shortcut name is unique within the destination folder. If this flag is
		/// not included, the function creates the shortcut name and then determines whether the name is unique in the destination folder. If
		/// a file with the same name already exists in the destination folder, the shortcut name will be modified. This process is repeated
		/// until a unique name is found.
		/// </para>
		/// <para>SHGNLI_PREFIXNAME (0x000000004)</para>
		/// <para>0x000000004. The created name will be preceded by the string "Shortcut to ".</para>
		/// <para>SHGNLI_NOLNK (0x000000008)</para>
		/// <para>
		/// 0x000000008. Version 5.0 Do not add the .lnk file name extension. You must set the <c>_WIN32_IE</c> macro to 5.01 or greater to
		/// use this flag. For more information about versioning, see Shell and Common Controls Versions.
		/// </para>
		/// <para>SHGNLI_NOLOCNAME (0x000000010)</para>
		/// <para>
		/// 0x000000010. <c>Windows Vista and later</c>. Use the non-localized parsing name of the target pointed to by as the name of the
		/// shortcut file. If this flag is not set, the localized name is used.
		/// </para>
		/// <para>SHGNLI_USEURLEXT (0x000000020)</para>
		/// <para>
		/// 0x000000020. <c>Windows 7 and later</c>. Append a .url file name extension (rather than .lnk) to the name pointed to by . If this
		/// flag is not set, the shortcut name uses a .lnk extension unless SHGNLI_NOLNK is set.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>SHGetNewLinkInfo</c> determines whether the destination file system supports long file names. If it does, a long file name is
		/// used for the shortcut name. If the destination file system does not support long file names, the shortcut name is returned in an
		/// 8.3 format.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shgetnewlinkinfoa BOOL SHGetNewLinkInfoA( LPCSTR
		// pszLinkTo, LPCSTR pszDir, LPSTR pszName, BOOL *pfMustCopy, UINT uFlags );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "ca658d5c-af7b-400c-8f4d-7d4b07bf7f2b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SHGetNewLinkInfo(string pszLinkTo, string pszDir, StringBuilder pszName, [MarshalAs(UnmanagedType.Bool)] out bool pfMustCopy, SHGNLI uFlags);

		/// <summary>
		/// <para>
		/// Retrieves an object that represents a specific window's collection of properties, which allows those properties to be queried or set.
		/// </para>
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window whose properties are being retrieved.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>A reference to the IID of the property store object to retrieve through . This is typically IID_IPropertyStore.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this function returns, contains the interface pointer requested in . This is typically IPropertyStore.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can use this function to obtain access to a window's property store so that it can set an explicit Application
		/// User Model ID (AppUserModelID) in the System.AppUserModel.ID property.
		/// </para>
		/// <para>
		/// A window's properties must be removed before the window is closed. If this is not done, the resources used by those properties
		/// are not returned to the system. A property is removed by setting it to the PROPVARIANT type VT_EMPTY.
		/// </para>
		/// <para>
		/// When a call is made to IPropertyStore::SetValue on the object retrieved through , the properties and values are immediately
		/// stored on the window. Therefore, no call to IPropertyStore::Commit is needed. No error occurs if it is called, but it has no effect.
		/// </para>
		/// <para>
		/// An application sets AppUserModelIDs on individual windows to control the application's taskbar grouping and Jump List contents.
		/// For instance, a suite application might want to provide a different taskbar button for each of its subfeatures, with the windows
		/// relating to that subfeature grouped under that button. Without window-level AppUserModelIDs, those windows would all be grouped
		/// together under the main process.
		/// </para>
		/// <para>
		/// Applications should also use this property store to set these relaunch properties so that the system can return the application
		/// to that state.
		/// </para>
		/// <list type="bullet">
		/// <item>System.AppUserModel.RelaunchCommand</item>
		/// <item>System.AppUserModel.RelaunchDisplayNameResource</item>
		/// <item>System.AppUserModel.RelaunchIconResource</item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shgetpropertystoreforwindow SHSTDAPI
		// SHGetPropertyStoreForWindow( HWND hwnd, REFIID riid, void **ppv );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "772aa2c8-6dd1-480c-a008-58f30902cb80")]
		public static extern HRESULT SHGetPropertyStoreForWindow(HWND hwnd, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		/// <summary>
		/// Retrieves an object that represents a specific window's collection of properties, which allows those properties to be queried or set.
		/// </summary>
		/// <typeparam name="TIntf">The type of the property store object to retrieve. This is typically IPropertyStore.</typeparam>
		/// <param name="hwnd"><para>Type: <c>HWND</c></para>
		/// <para>A handle to the window whose properties are being retrieved.</para></param>
		/// <returns>
		/// When this function returns, contains the interface pointer requested in . This is typically IPropertyStore.
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can use this function to obtain access to a window's property store so that it can set an explicit Application
		/// User Model ID (AppUserModelID) in the System.AppUserModel.ID property.
		/// </para>
		/// <para>
		/// A window's properties must be removed before the window is closed. If this is not done, the resources used by those properties
		/// are not returned to the system. A property is removed by setting it to the PROPVARIANT type VT_EMPTY.
		/// </para>
		/// <para>
		/// When a call is made to IPropertyStore::SetValue on the object retrieved through , the properties and values are immediately
		/// stored on the window. Therefore, no call to IPropertyStore::Commit is needed. No error occurs if it is called, but it has no effect.
		/// </para>
		/// <para>
		/// An application sets AppUserModelIDs on individual windows to control the application's taskbar grouping and Jump List contents.
		/// For instance, a suite application might want to provide a different taskbar button for each of its subfeatures, with the windows
		/// relating to that subfeature grouped under that button. Without window-level AppUserModelIDs, those windows would all be grouped
		/// together under the main process.
		/// </para>
		/// <para>
		/// Applications should also use this property store to set these relaunch properties so that the system can return the application
		/// to that state.
		/// </para>
		/// <list type="bullet">
		///   <item>System.AppUserModel.RelaunchCommand</item>
		///   <item>System.AppUserModel.RelaunchDisplayNameResource</item>
		///   <item>System.AppUserModel.RelaunchIconResource</item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shgetpropertystoreforwindow SHSTDAPI
		// SHGetPropertyStoreForWindow( HWND hwnd, REFIID riid, void **ppv );
		[PInvokeData("shellapi.h", MSDNShortId = "772aa2c8-6dd1-480c-a008-58f30902cb80")]
		public static TIntf SHGetPropertyStoreForWindow<TIntf>(HWND hwnd) where TIntf : class =>
			IidGetObj<TIntf>((in Guid g, out object o) => SHGetPropertyStoreForWindow(hwnd, g, out o));

		/// <summary>
		/// <para>Retrieves information about system-defined Shell icons.</para>
		/// </summary>
		/// <param name="siid">
		/// <para>Type: <c>SHSTOCKICONID</c></para>
		/// <para>One of the values from the SHSTOCKICONID enumeration that specifies which icon should be retrieved.</para>
		/// </param>
		/// <param name="uFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A combination of zero or more of the following flags that specify which information is requested.</para>
		/// <para>SHGSI_ICONLOCATION</para>
		/// <para>
		/// The <c>szPath</c> and <c>iIcon</c> members of the SHSTOCKICONINFO structure receive the path and icon index of the requested
		/// icon, in a format suitable for passing to the ExtractIcon function. The numerical value of this flag is zero, so you always get
		/// the icon location regardless of other flags.
		/// </para>
		/// <para>SHGSI_ICON</para>
		/// <para>The <c>hIcon</c> member of the SHSTOCKICONINFO structure receives a handle to the specified icon.</para>
		/// <para>SHGSI_SYSICONINDEX</para>
		/// <para>
		/// The <c>iSysImageImage</c> member of the SHSTOCKICONINFO structure receives the index of the specified icon in the system imagelist.
		/// </para>
		/// <para>SHGSI_LINKOVERLAY</para>
		/// <para>Modifies the SHGSI_ICON value by causing the function to add the link overlay to the file's icon.</para>
		/// <para>SHGSI_SELECTED</para>
		/// <para>Modifies the SHGSI_ICON value by causing the function to blend the icon with the system highlight color.</para>
		/// <para>SHGSI_LARGEICON</para>
		/// <para>
		/// Modifies the SHGSI_ICON value by causing the function to retrieve the large version of the icon, as specified by the SM_CXICON
		/// and SM_CYICON system metrics.
		/// </para>
		/// <para>SHGSI_SMALLICON</para>
		/// <para>
		/// Modifies the SHGSI_ICON value by causing the function to retrieve the small version of the icon, as specified by the SM_CXSMICON
		/// and SM_CYSMICON system metrics.
		/// </para>
		/// <para>SHGSI_SHELLICONSIZE</para>
		/// <para>
		/// Modifies the SHGSI_LARGEICON or SHGSI_SMALLICON values by causing the function to retrieve the Shell-sized icons rather than the
		/// sizes specified by the system metrics.
		/// </para>
		/// </param>
		/// <param name="psii">
		/// <para>Type: <c>SHSTOCKICONINFO*</c></para>
		/// <para>
		/// A pointer to a SHSTOCKICONINFO structure. When this function is called, the <c>cbSize</c> member of this structure needs to be
		/// set to the size of the <c>SHSTOCKICONINFO</c> structure. When this function returns, contains a pointer to a
		/// <c>SHSTOCKICONINFO</c> structure that contains the requested information.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If this function returns an icon handle in the <c>hIcon</c> member of the SHSTOCKICONINFO structure pointed to by , you are
		/// responsible for freeing the icon with DestroyIcon when you no longer need it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shgetstockiconinfo SHSTDAPI SHGetStockIconInfo(
		// SHSTOCKICONID siid, UINT uFlags, SHSTOCKICONINFO *psii );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "c08b1a53-e67c-4ed0-a9c6-d000c448e182")]
		public static extern HRESULT SHGetStockIconInfo(SHSTOCKICONID siid, SHGSI uFlags, ref SHSTOCKICONINFO psii);

		/// <summary>
		/// <para>Retrieves a specified user's unread message count for any or all email accounts.</para>
		/// </summary>
		/// <param name="hKeyUser">
		/// <para>Type: <c>HKEY</c></para>
		/// <para>
		/// A valid HKEY for a given user. This parameter should be <c>NULL</c> if the function is called in a user's environment, in which
		/// case <c>HKEY_CURRENT_USER</c> is used. This parameter should be <c>NULL</c> if the function is called from the SYSTEM context, in
		/// which case <c>HKEY_USERS</c>&lt;i&gt;{SID} is used.
		/// </para>
		/// </param>
		/// <param name="pszMailAddress">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a string in Unicode that specifies the email address of an account belonging to the specified user. When this
		/// parameter is <c>NULL</c>, returns the total count of unread messages for all accounts owned by the designated user.
		/// </para>
		/// </param>
		/// <param name="pdwCount">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>Pointer to a DWORD value which receives the unread message count.</para>
		/// </param>
		/// <param name="pFileTime">
		/// <para>Type: <c>FILETIME*</c></para>
		/// <para>
		/// A pointer to a FILETIME structure. The use of this parameter is determined by whether is <c>NULL</c>. If is <c>NULL</c>, then
		/// this parameter is treated as an [in] parameter, which specifies a filter, so that only unread mail newer than the specified time
		/// appears. If is not <c>NULL</c>, then this parameter is treated as an [out] parameter, which points to a <c>FILETIME</c> structure
		/// into which the function places the <c>timestamp</c> of the last SHSetUnreadMailCount call for the specified user and email account.
		/// </para>
		/// </param>
		/// <param name="pszShellExecuteCommand">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a string that returns the ShellExecute command statement passed into the last SHSetUnreadMailCount call for the
		/// specified user and email account. This command string starts the email application that owns the account referenced by . If the
		/// ShellExecute command is not required, this parameter can be <c>NULL</c>. If is <c>NULL</c>, this parameter is ignored and must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="cchShellExecuteCommand">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The maximum size, in characters, of the ShellExecute command buffer pointed to by . This parameter must be zero for total counts
		/// when is <c>NULL</c>. It can also be <c>NULL</c> whenever the ShellExecute command string is not required.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shgetunreadmailcountw HRESULT SHGetUnreadMailCountW(
		// HKEY hKeyUser, LPCWSTR pszMailAddress, DWORD *pdwCount, FILETIME *pFileTime, LPWSTR pszShellExecuteCommand, int
		// cchShellExecuteCommand );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("shellapi.h", MSDNShortId = "d2a57fa0-13fe-4e12-89cc-8a6dbdb44f08")]
		public static extern HRESULT SHGetUnreadMailCountW(HKEY hKeyUser, string pszMailAddress, out uint pdwCount, ref System.Runtime.InteropServices.ComTypes.FILETIME pFileTime, StringBuilder pszShellExecuteCommand, int cchShellExecuteCommand);

		/// <summary>
		/// <para>Executes a command on a printer object.</para>
		/// <para>
		/// <c>Note</c> This function has been deprecated as of Windows Vista. It is recommended that, in its place, you invoke verbs on
		/// printers through IContextMenu or ShellExecute.
		/// </para>
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the parent window of any windows or dialog boxes that are created during the operation.</para>
		/// </param>
		/// <param name="uAction">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The type of printer operation to perform. One of the following values:</para>
		/// <para>PRINTACTION_OPEN (0)</para>
		/// <para>0x0. Open the printer specified by <c>lpBuf1</c>. The <c>lpBuf2</c> parameter is ignored.</para>
		/// <para>PRINTACTION_PROPERTIES (1)</para>
		/// <para>
		/// 0x1. Display the property pages for the printer specified by <c>lpBuf1</c>. The <c>lpBuf2</c> parameter can be <c>NULL</c> or can
		/// name a specific property sheet to display, either by name or number. If the high <c>WORD</c> of <c>lpBuf2</c> is nonzero, it is
		/// assumed that this parameter is a pointer to a buffer that contains the name of the sheet to open. Otherwise, <c>lpBuf2</c> is
		/// seen as the zero-based index of the property sheet to open.
		/// </para>
		/// <para>PRINTACTION_NETINSTALL (2)</para>
		/// <para>0x2. Install the network printer specified by <c>lpBuf1</c>. The <c>lpBuf2</c> parameter is ignored.</para>
		/// <para>PRINTACTION_NETINSTALLLINK (3)</para>
		/// <para>
		/// 0x3. Create a shortcut to the network printer specified by <c>lpBuf1</c>. The <c>lpBuf2</c> parameter specifies the drive and
		/// path of the folder in which to create the shortcut. The network printer must already have been installed on the local computer.
		/// </para>
		/// <para>PRINTACTION_TESTPAGE (4)</para>
		/// <para>0x4. Print a test page on the printer specified by <c>lpBuf1</c>. The <c>lpBuf2</c> parameter is ignored.</para>
		/// <para>PRINTACTION_OPENNETPRN (5)</para>
		/// <para>0x5. Open the network printer specified by <c>lpBuf1</c>. The <c>lpBuf2</c> parameter is ignored.</para>
		/// <para>PRINTACTION_DOCUMENTDEFAULTS (6)</para>
		/// <para>
		/// 0x6. Display the default document properties for the printer specified by <c>lpBuf1</c>. The <c>lpBuf2</c> parameter is ignored.
		/// </para>
		/// <para>PRINTACTION_SERVERPROPERTIES (7)</para>
		/// <para>0x7. Display the properties for the printer server specified by <c>lpBuf1</c>. The <c>lpBuf2</c> parameter is ignored.</para>
		/// </param>
		/// <param name="lpBuf1">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// Pointer to a null-terminated string that contains additional information for the printer command. The information contained in
		/// this parameter depends upon the value of <c>uAction</c>.
		/// </para>
		/// </param>
		/// <param name="lpBuf2">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// Pointer to a null-terminated string that contains additional information for the printer command. The information contained in
		/// this parameter depends upon the value of <c>uAction</c>.
		/// </para>
		/// </param>
		/// <param name="fModal">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// <c>TRUE</c> to specify that <c>SHInvokePrinterCommand</c> should not return until the command is completed; <c>FALSE</c> if the
		/// function should return as soon as the command is initialized.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When a printer name is specified by <c>lpBuf1</c>, the name can either be the name of a local printer or the server and share
		/// name of a network printer. When specifying a network printer name, the name must be specified in this format:
		/// </para>
		/// <para>
		/// <code>"\\&lt;server&gt;&lt;shared printer name&gt;"</code>
		/// </para>
		/// <para>
		/// This function is implemented in Shell versions 4.71 and later. In order to maintain backward compatibility with previous Shell
		/// versions, this function should not be used explicitly. Instead, the LoadLibrary and GetProcAddress functions should be used to
		/// obtain the function address.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The shellapi.h header defines SHInvokePrinterCommand as an alias which automatically selects the ANSI or Unicode version of this
		/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
		/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
		/// for Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-shinvokeprintercommanda BOOL SHInvokePrinterCommandA( [in,
		// optional] HWND hwnd, UINT uAction, [in] LPCSTR lpBuf1, [in, optional] LPCSTR lpBuf2, BOOL fModal );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "NF:shellapi.SHInvokePrinterCommandA")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SHInvokePrinterCommand(HWND hwnd, PRINTACTION uAction, string lpBuf1, [Optional] string lpBuf2, [MarshalAs(UnmanagedType.Bool)] bool fModal);

		/// <summary>
		/// <para>
		/// Determines whether a file or folder is available for offline use. This function also determines whether the file would be opened
		/// from the network, from the local Offline Files cache, or from both locations.
		/// </para>
		/// </summary>
		/// <param name="pwszPath">
		/// <para>TBD</para>
		/// </param>
		/// <param name="pdwStatus">
		/// <para>Type: <c>LPDWORD</c></para>
		/// <para>A pointer to a variable of type <c>DWORD</c> that receives one or more of the following flags if the function succeeds.</para>
		/// <para>OFFLINE_STATUS_LOCAL (0x01)</para>
		/// <para>If the file is open, it is open in the cache.</para>
		/// <para>OFFLINE_STATUS_REMOTE (0x02)</para>
		/// <para>If the file is open, it is open on the server.</para>
		/// <para>OFFLINE_STATUS_INCOMPLETE (0x04)</para>
		/// <para>The local copy is currently incomplete. The file cannot be opened in offline mode until it has been synchronized.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The file or directory is cached. It is available offline unless OFFLINE_STATUS_INCOMPLETE is set.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The path is invalid or not a network path. The file or directory is not cached.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The file or directory is not cached.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>If is a directory, <c>SHIsFileAvailableOffline</c> will not return the <c>OFFLINE_STATUS_INCOMPLETE</c> flag.</para>
		/// <para>
		/// If <c>SHIsFileAvailableOffline</c> returns both <c>OFFLINE_STATUS_LOCAL</c> and <c>OFFLINE_STATUS_REMOTE</c>, the file or
		/// directory is open in both places. This is common when the server is online.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shisfileavailableoffline SHSTDAPI
		// SHIsFileAvailableOffline( PCWSTR pwszPath, DWORD *pdwStatus );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "9acf212d-9309-42b0-ba96-faa0ecf0b865")]
		public static extern HRESULT SHIsFileAvailableOffline([MarshalAs(UnmanagedType.LPWStr)] string pwszPath, out OFFLINE_STATUS pdwStatus);

		/// <summary>
		/// <para>
		/// Signals the Shell that during the next operation requiring overlay information, it should load icon overlay identifiers that
		/// either failed creation or were not present for creation at startup. Identifiers that have already been loaded are not affected.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Always returns S_OK.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A call to <c>SHLoadNonloadedIconOverlayIdentifiers</c> does not result in the immediate loading of a Shell extension, nor does it
		/// cause an icon overlay handler to be loaded. A call to <c>SHLoadNonloadedIconOverlayIdentifiers</c> results in a situation such
		/// that the next code to ask for icon overlay information triggers a comparison of icon overlays in the registry to those that are
		/// already loaded. If an icon overlay is newly registered and the system has not already reached its upper limit of fifteen icon
		/// overlays, the new overlay is loaded. <c>SHLoadNonloadedIconOverlayIdentifiers</c> alone does not load a new icon overlay; you
		/// also need to trigger an action that uses the overlay, such as a refresh of a Windows Explorer view.
		/// </para>
		/// <para>For more information, see How to Implement Icon Overlay Handlers.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shloadnonloadediconoverlayidentifiers SHSTDAPI
		// SHLoadNonloadedIconOverlayIdentifiers( );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "d2c4f37e-6e9d-4536-90ea-d69461c4105a")]
		public static extern HRESULT SHLoadNonloadedIconOverlayIdentifiers();

		/// <summary>
		/// <para>Retrieves the size of the Recycle Bin and the number of items in it, for a specified drive.</para>
		/// </summary>
		/// <param name="pszRootPath">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The address of a <c>null</c>-terminated string of maximum length MAX_PATH to contain the path of the root drive on which the
		/// Recycle Bin is located. This parameter can contain the address of a string formatted with the drive, folder, and subfolder names (C:\Windows\System...).
		/// </para>
		/// </param>
		/// <param name="pSHQueryRBInfo">
		/// <para>Type: <c>LPSHQUERYRBINFO</c></para>
		/// <para>
		/// The address of a SHQUERYRBINFO structure that receives the Recycle Bin information. The <c>cbSize</c> member of the structure
		/// must be set to the size of the structure before calling this API.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// With Windows 2000, if <c>NULL</c> is passed in the parameter, the function fails and returns an E_INVALIDARG error code. In
		/// earlier versions of the operating system, you can pass an empty string or <c>NULL</c>. If contains an empty string or
		/// <c>NULL</c>, information is retrieved for all Recycle Bins on all drives.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shqueryrecyclebina SHSTDAPI SHQueryRecycleBinA( LPCSTR
		// pszRootPath, LPSHQUERYRBINFO pSHQueryRBInfo );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "a9a80486-2c99-4916-af25-10b00573456b")]
		public static extern HRESULT SHQueryRecycleBin(string pszRootPath, ref SHQUERYRBINFO pSHQueryRBInfo);

		/// <summary>
		/// <para>Checks the state of the computer for the current user to determine whether sending a notification is appropriate.</para>
		/// </summary>
		/// <param name="pquns">
		/// <para>Type: <c>QUERY_USER_NOTIFICATION_STATE*</c></para>
		/// <para>When this function returns, contains a pointer to one of the values of the QUERY_USER_NOTIFICATION_STATE enumeration.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Applications should call <c>SHQueryUserNotificationState</c> and test the return value before displaying any notification UI that
		/// is similar to the balloon notifications generated by Shell_NotifyIcon. Notifications should only be displayed if this API returns
		/// QNS_ACCEPTS_NOTIFICATIONS. This informs the application whether the user is running processes that should not be interrupted.
		/// Top-level windows receive a WM_SETTINGCHANGE message when the user turns presentation settings on or off, and also when the
		/// user's session is locked or unlocked. Note that there are no notifications sent when the user starts or stops a full-screen application.
		/// </para>
		/// <para>If this function returns QUNS_QUIET_TIME, notifications should be displayed only if critical.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shqueryusernotificationstate SHSTDAPI
		// SHQueryUserNotificationState( QUERY_USER_NOTIFICATION_STATE *pquns );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "da6b3915-f4fe-4bab-9bae-9bff0b97b5a0")]
		public static extern HRESULT SHQueryUserNotificationState(out QUERY_USER_NOTIFICATION_STATE pquns);

		/// <summary>
		/// <para>Removes the localized name of a file in a Shell folder.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>A pointer to a null-terminated, Unicode string that specifies the fully qualified path of the target file.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When a display name string is set by SHSetLocalizedName, Windows Explorer uses that string for display instead of the file name.
		/// The path to the file is unchanged.
		/// </para>
		/// <para>
		/// Applications can use the IShellFolder::GetDisplayNameOf method to get the display (localized) name through with the
		/// SIGDN_NORMALDISPLAY flag and the parsing (non-localized) name with SIGDN_DESKTOPABSOLUTEPARSING.
		/// </para>
		/// <para>Calling <c>SHRemoveLocalizedName</c> makes the display name identical to the parsing name.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shremovelocalizedname SHSTDAPI SHRemoveLocalizedName(
		// PCWSTR pszPath );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "ed30546f-3531-42df-9018-1a24a79a0b79")]
		public static extern HRESULT SHRemoveLocalizedName([MarshalAs(UnmanagedType.LPWStr)] string pszPath);

		/// <summary>
		/// <para>Sets the localized name of a file in a Shell folder.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>A pointer to a string that specifies the fully qualified path of the target file.</para>
		/// </param>
		/// <param name="pszResModule">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>A pointer to a string resource that specifies the localized version of the file name.</para>
		/// </param>
		/// <param name="idsRes">
		/// <para>Type: <c>int</c></para>
		/// <para>An integer ID that specifies the localized file name in the string resource.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>When this string is set, Explorer displays this string instead of the file name. The path to the file is unchanged.</para>
		/// <para>
		/// Applications can get the display (localized) name with IShellFolder::GetDisplayNameOf with the SIGDN_NORMALDISPLAY flag and the
		/// parsing (non-localized) name with IShellItem::GetDisplayName using the SIGDN_DESKTOPABSOLUTEPARSING flag.
		/// </para>
		/// <para>Calling SHRemoveLocalizedName makes the display name identical to the parsing name.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shsetlocalizedname SHSTDAPI SHSetLocalizedName( PCWSTR
		// pszPath, PCWSTR pszResModule, int idsRes );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("shellapi.h", MSDNShortId = "35b83fc8-3dad-4f08-a3fe-ce047b2ca3a2")]
		public static extern HRESULT SHSetLocalizedName(string pszPath, string pszResModule, int idsRes);

		/// <summary>
		/// <para>Stores the current user's unread message count for a specified email account in the registry.</para>
		/// </summary>
		/// <param name="pszMailAddress">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a string in Unicode that contains the current user's full email address.</para>
		/// </param>
		/// <param name="dwCount">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of unread messages.</para>
		/// </param>
		/// <param name="pszShellExecuteCommand">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a string in Unicode that contains the full text of a command that can be passed to ShellExecute. This command should
		/// start the email application that owns the account referenced by .
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para><c>HRESULT</c>, which includes the following possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The call completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory available.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>Invalid string argument in either the or parameters.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>When this function updates the registry, the new registry entry is automatically stamped with the current time and date.</para>
		/// <para>
		/// If this function is called by different independent software vendors (ISVs) that specify the same email name, only the last call
		/// is saved. That is, calls to this function overwrite any previously saved value for the same email address, even if the calls are
		/// made by different ISVs.
		/// </para>
		/// <para>
		/// It is recommended that the count of unread messages be set only for the main Inbox of the users account. Mail in sub-folders such
		/// as Drafts or Deleted Items should be ignored.
		/// </para>
		/// <para>
		/// It is important that email clients do not set the number of unread messages to 0 when the application exits, because this causes
		/// the number of unread messages to be erroneously reported as 0.
		/// </para>
		/// <para>Because this function uses HKEY_CURRENT_USER, it should not be called by a system process impersonating a user.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shsetunreadmailcountw HRESULT SHSetUnreadMailCountW(
		// LPCWSTR pszMailAddress, DWORD dwCount, LPCWSTR pszShellExecuteCommand );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("shellapi.h", MSDNShortId = "4a0e1ade-8df1-41b5-b6ea-dad427b50f5a")]
		public static extern HRESULT SHSetUnreadMailCountW(string pszMailAddress, uint dwCount, string pszShellExecuteCommand);

		/// <summary>
		/// <para>Uses CheckTokenMembership to test whether the given token is a member of the local group with the specified RID.</para>
		/// </summary>
		/// <param name="hToken">
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A handle to the token. This value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ulRID">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The RID of the local group for which membership is tested.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> on success, <c>FALSE</c> on failure.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function wraps CheckTokenMembership and only checks local groups.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shtesttokenmembership BOOL SHTestTokenMembership( HANDLE
		// hToken, ULONG ulRID );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "ac2d591a-f431-4da7-aa9f-0476634ec9cf")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SHTestTokenMembership([Optional] HTOKEN hToken, uint ulRID);

		/// <summary>
		/// UNDOCUMENTED: Use at your own risk.
		/// <para>Updates the icon status for the Recycle Bin.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		public static extern HRESULT SHUpdateRecycleBinIcon();

		/// <summary>
		/// <para>Contains information about a system appbar message.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/ns-shellapi-_appbardata typedef struct _AppBarData { DWORD cbSize;
		// HWND hWnd; UINT uCallbackMessage; UINT uEdge; RECT rc; LPARAM lParam; } APPBARDATA, *PAPPBARDATA;
		[PInvokeData("shellapi.h", MSDNShortId = "cf86fe15-4beb-49b7-b73e-2ad61cedc3f8")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct APPBARDATA
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The size of the structure, in bytes.</para>
			/// </summary>
			public uint cbSize;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>
			/// The handle to the appbar window. Not all messages use this member. See the individual message page to see if you need to
			/// provide an <c>hWind</c> value.
			/// </para>
			/// </summary>
			public HWND hWnd;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>
			/// An application-defined message identifier. The application uses the specified identifier for notification messages that it
			/// sends to the appbar identified by the <c>hWnd</c> member. This member is used when sending the ABM_NEW message.
			/// </para>
			/// </summary>
			public uint uCallbackMessage;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>A value that specifies an edge of the screen. This member is used when sending one of these messages:</para>
			/// <para>ABM_GETAUTOHIDEBAR</para>
			/// <para>ABM_SETAUTOHIDEBAR</para>
			/// <para>ABM_GETAUTOHIDEBAREX</para>
			/// <para>ABM_SETAUTOHIDEBAREX</para>
			/// <para>ABM_QUERYPOS</para>
			/// <para>ABM_SETPOS</para>
			/// <para>This member can be one of the following values.</para>
			/// <para>ABE_BOTTOM</para>
			/// <para>Bottom edge.</para>
			/// <para>ABE_LEFT</para>
			/// <para>Left edge.</para>
			/// <para>ABE_RIGHT</para>
			/// <para>Right edge.</para>
			/// <para>ABE_TOP</para>
			/// <para>Top edge.</para>
			/// </summary>
			public ABE uEdge;

			/// <summary>
			/// <para>Type: <c>RECT</c></para>
			/// <para>A RECT structure whose use varies depending on the message:</para>
			/// <list type="bullet">
			/// <item>
			/// ABM_GETTASKBARPOS, ABM_QUERYPOS, ABM_SETPOS: The bounding rectangle, in screen coordinates, of an appbar or the Windows taskbar.
			/// </item>
			/// <item>
			/// ABM_GETAUTOHIDEBAREX, ABM_SETAUTOHIDEBAREX: The monitor on which the operation is being performed. This information can be
			/// retrieved through the GetMonitorInfo function.
			/// </item>
			/// </list>
			/// </summary>
			public RECT rc;

			/// <summary>
			/// <para>Type: <c>LPARAM</c></para>
			/// <para>A message-dependent value. This member is used with these messages:</para>
			/// <para>ABM_SETAUTOHIDEBAR</para>
			/// <para>ABM_SETAUTOHIDEBAREX</para>
			/// <para>ABM_SETSTATE</para>
			/// <para>See the individual message pages for details.</para>
			/// </summary>
			public IntPtr lParam;
		}

		/// <summary>Defines information used by AssocCreateForClasses to retrieve an IQueryAssociations interface for a given file association.</summary>
		[PInvokeData("shellapi.h", MSDNShortId = "1d1a963f-7ebb-4ba6-9a97-795c8ef11ae4")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct ASSOCIATIONELEMENT
		{
			/// <summary>
			/// Where to obtain association data and the form the data is stored in. One of the following values from the ASSOCCLASS enumeration.
			/// </summary>
			public ASSOCCLASS ac;

			/// <summary>A registry key that specifies a class that contains association information.</summary>
			public HKEY hkClass;

			/// <summary>A pointer to the name of a class that contains association information.</summary>
			public string pszClass;
		}

		/// <summary>
		/// <para>Contains information that the system needs to display notifications in the notification area. Used by Shell_NotifyIcon.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// See Notifications in the Windows User Experience Interaction Guidelines for more information on notification UI and content best practices.
		/// </para>
		/// <para>
		/// If you set the <c>NIF_INFO</c> flag in the <c>uFlags</c> member, the balloon-style notification is used. For more discussion of
		/// these notifications, see Balloon tooltips.
		/// </para>
		/// <para>
		/// No more than one balloon notification at a time can be displayed for the taskbar. If an application attempts to display a
		/// notification when one is already being displayed, the new notification is queued and displayed when the older notification goes
		/// away. In versions of Windows before Windows Vista, the new notification would not appear until the existing notification has been
		/// visible for at least the system minimum timeout length, regardless of the original notification's <c>uTimeout</c> value. If the
		/// user does not appear to be using the computer, the system does not count this time toward the timeout.
		/// </para>
		/// <para>
		/// Several members of this structure are only supported for Windows 2000 and later. To enable these members, include one of the
		/// following lines in your header:
		/// </para>
		/// <para>
		/// Note that you must initialize the structure with its size. If you use the size of the currently defined structure, the
		/// application might not run with earlier versions of Shell32.dll, which expect a smaller structure. You can run your application
		/// against earlier versions of Shell32.dll by defining the appropriate version number (see
		/// </para>
		/// <para>Shell and Common Controls Versions</para>
		/// <para>). However, this might cause problems if your application also needs to run on more recent systems.</para>
		/// <para>
		/// You can maintain application compatibility with all Shell32.dll versions while still using the current header files by setting
		/// the size of the <c>NOTIFYICONDATA</c> structure appropriately. Before you initialize the structure, use DllGetVersion to
		/// determine which Shell32.dll version is installed on the system and initialize <c>cbSize</c> with one of these values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Shell32.dll Version</term>
		/// <term>cbSize</term>
		/// </listheader>
		/// <item>
		/// <term>6.0.6 or higher (Windows Vista and later)</term>
		/// <term>sizeof(NOTIFYICONDATA)</term>
		/// </item>
		/// <item>
		/// <term>6.0 (Windows XP)</term>
		/// <term>NOTIFYICONDATA_V3_SIZE</term>
		/// </item>
		/// <item>
		/// <term>5.0 (Windows 2000)</term>
		/// <term>NOTIFYICONDATA_V2_SIZE</term>
		/// </item>
		/// <item>
		/// <term>Versions lower than 5.0</term>
		/// <term>NOTIFYICONDATA_V1_SIZE</term>
		/// </item>
		/// </list>
		/// <para>
		/// Using this value for <c>cbSize</c> allows your application to use <c>NOTIFYICONDATA</c> in a method compatible with earlier
		/// Shell32.dll versions.
		/// </para>
		/// <para>
		/// The following code example shows version checking that can enable an application that uses the <c>guidItem</c> member to run on
		/// both Windows Vista and Windows 7. It provides a Boolean function that returns <c>TRUE</c> if the operating system is Windows 7.
		/// Unless this member returns <c>TRUE</c>, the <c>guidItem</c> member must be set to 0.
		/// </para>
		/// <para>
		/// <c>Note</c> This code is specific to the Windows 7 version number. It is expected that future versions of Windows and Windows
		/// Server will support the <c>guidItem</c> member, and at that time this code must be updated to identify later version numbers as
		/// valid as well.
		/// </para>
		/// <para>The following code example shows the use of</para>
		/// <para>LoadIconMetric</para>
		/// <para>to load an icon for use with high DPI.</para>
		/// <para>Troubleshooting</para>
		/// <para>If you are using the</para>
		/// <para>guidItem</para>
		/// <para>member to identify the icon, and that icon is not seen or some calls to</para>
		/// <para>Shell_NotifyIcon</para>
		/// <para>fail, one of the following cases is the likely cause:</para>
		/// <list type="number">
		/// <item>
		/// The NIF_GUID flag was not set in every call to Shell_NotifyIcon. Once you identify the notification icon with a GUID in one call
		/// to <c>Shell_NotifyIcon</c>, you must use that same GUID to identify the icon in any subsequent <c>Shell_NotifyIcon</c> calls that
		/// deal with that same icon.
		/// </item>
		/// <item>
		/// The binary file that contains the icon was moved. The path of the binary file is included in the registration of the icon's GUID
		/// and cannot be changed. Settings associated with the icon are preserved through an upgrade only if the file path and GUID are
		/// unchanged. If the path must be changed, the application should remove any GUID information that was added when the existing icon
		/// was registered. Once that information is removed, you can move the binary file to a new location and reregister it with a new
		/// GUID. Any settings associated with the original GUID registration will be lost.
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/ns-shellapi-_notifyicondataa typedef struct _NOTIFYICONDATAA { DWORD
		// cbSize; HWND hWnd; UINT uID; UINT uFlags; UINT uCallbackMessage; HICON hIcon; CHAR szTip[64]; CHAR szTip[128]; DWORD dwState;
		// DWORD dwStateMask; CHAR szInfo[256]; union { UINT uTimeout; UINT uVersion; } DUMMYUNIONNAME; CHAR szInfoTitle[64]; DWORD
		// dwInfoFlags; GUID guidItem; HICON hBalloonIcon; } NOTIFYICONDATAA, *PNOTIFYICONDATAA;
		[PInvokeData("shellapi.h", MSDNShortId = "fdcc42c1-b3e5-4b04-8d79-7b6c29699d53")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NOTIFYICONDATA
		{
			/// <summary>Size of this structure, in bytes.</summary>
			public uint cbSize;

			/// <summary>
			/// Handle to the window that receives notification messages associated with an icon in the taskbar status area. The Shell uses
			/// hWnd and uID to identify which icon to operate on when Shell_NotifyIcon is invoked.
			/// </summary>
			public HWND hwnd;

			/// <summary>
			/// Application-defined identifier of the taskbar icon. The Shell uses hWnd and uID to identify which icon to operate on when
			/// Shell_NotifyIcon is invoked. You can have multiple icons associated with a single hWnd by assigning each a different uID.
			/// </summary>
			public uint uID;

			/// <summary>
			/// Flags that indicate which of the other members contain valid data. This member can be a combination of the NIF_XXX constants.
			/// </summary>
			public NIF uFlags;

			/// <summary>
			/// Application-defined message identifier. The system uses this identifier to send notifications to the window identified in hWnd.
			/// </summary>
			public uint uCallbackMessage;

			/// <summary>Handle to the icon to be added, modified, or deleted.</summary>
			public HICON hIcon;

			/// <summary>
			/// String with the text for a standard ToolTip. It can have a maximum of 64 characters including the terminating NULL. For
			/// Version 5.0 and later, szTip can have a maximum of 128 characters, including the terminating NULL.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string szTip;

			/// <summary>State of the icon.</summary>
			public NIS dwState;

			/// <summary>
			/// A value that specifies which bits of the state member are retrieved or modified. For example, setting this member to
			/// NIS_HIDDEN causes only the item's hidden state to be retrieved.
			/// </summary>
			public NIS dwStateMask;

			/// <summary>
			/// String with the text for a balloon ToolTip. It can have a maximum of 255 characters. To remove the ToolTip, set the NIF_INFO
			/// flag in uFlags and set szInfo to an empty string.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string szInfo;

			/// <summary>
			/// NOTE: This field is also used for the Timeout value. Specifies whether the Shell notify icon interface should use Windows 95
			/// or Windows 2000 behavior. For more information on the differences in these two behaviors, see Shell_NotifyIcon. This member
			/// is only employed when using Shell_NotifyIcon to send an NIM_VERSION message.
			/// </summary>
			public int uTimeoutOrVersion;

			/// <summary>
			/// String containing a title for a balloon ToolTip. This title appears in boldface above the text. It can have a maximum of 63 characters.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
			public string szInfoTitle;

			/// <summary>
			/// Adds an icon to a balloon ToolTip. It is placed to the left of the title. If the szTitleInfo member is zero-length, the icon
			/// is not shown.
			/// </summary>
			public NIIF dwInfoFlags;

			/// <summary>
			/// <para>
			/// Windows 7 and later: A registered GUID that identifies the icon.This value overrides uID and is the recommended method of
			/// identifying the icon.The NIF_GUID flag must be set in the uFlags member.
			/// </para>
			/// <para>Windows XP and Windows Vista: Reserved; must be set to 0.</para>
			/// <para>
			/// If your application is intended to run on both Windows Vista and Windows 7, it is imperative that you check the version of
			/// Windows and only specify a nonzero guidItem if on Windows 7 or later.
			/// </para>
			/// <para>
			/// If you identify the notification icon with a GUID in one call to Shell_NotifyIcon, you must use that same GUID to identify
			/// the icon in any subsequent Shell_NotifyIcon calls that deal with that same icon.
			/// </para>
			/// <para>To generate a GUID for use in this member, use a GUID-generating tool such as Guidgen.exe.</para>
			/// </summary>
			public Guid guidItem;

			/// <summary>
			/// Windows Vista and later. The handle of a customized notification icon provided by the application that should be used
			/// independently of the notification area icon. If this member is non-NULL and the NIIF_USER flag is set in the dwInfoFlags
			/// member, this icon is used as the notification icon. If this member is NULL, the legacy behavior is carried out.
			/// </summary>
			public HICON hBalloonIcon;
		}

		/// <summary>
		/// <para>Contains information used by Shell_NotifyIconGetRect to identify the icon for which to retrieve the bounding rectangle.</para>
		/// </summary>
		/// <remarks>
		/// <para>The icon can be identified to Shell_NotifyIconGetRect through this structure in two ways:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>guidItem alone (recommended)</description>
		/// </item>
		/// <item>
		/// <description>hWnd plus uID</description>
		/// </item>
		/// </list>
		/// <para>If guidItem is not GUID_NULL, hWnd and uID are ignored.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/ns-shellapi-_notifyiconidentifier typedef struct
		// _NOTIFYICONIDENTIFIER { DWORD cbSize; HWND hWnd; UINT uID; GUID guidItem; } NOTIFYICONIDENTIFIER, *PNOTIFYICONIDENTIFIER;
		[PInvokeData("shellapi.h", MSDNShortId = "2fe4ffba-6fe5-4d34-9cb1-f266e4594b8e")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NOTIFYICONIDENTIFIER
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The size of this structure, in bytes.</para>
			/// </summary>
			public uint cbSize;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>
			/// A handle to the parent window used by the notification's callback function. For more information, see the <see
			/// cref="NOTIFYICONDATA.hwnd"/> member of the NOTIFYICONDATA structure.
			/// </para>
			/// </summary>
			public HWND hWnd;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>
			/// The application-defined identifier of the notification icon. Multiple icons can be associated with a single <c>hWnd</c>,
			/// each with their own <c>uID</c>.
			/// </para>
			/// </summary>
			public uint uID;

			/// <summary>
			/// <para>Type: <c>GUID</c></para>
			/// <para>A registered GUID that identifies the icon. Use <c>GUID_NULL</c> if the icon is not identified by a GUID.</para>
			/// </summary>
			public Guid guidItem;

			/// <summary>Initializes a new instance of the <see cref="NOTIFYICONIDENTIFIER"/> struct.</summary>
			/// <param name="hWnd">A handle to the parent window used by the notification's callback function.</param>
			/// <param name="uID">The application-defined identifier of the notification icon.</param>
			public NOTIFYICONIDENTIFIER(HWND hWnd, uint uID)
			{
				cbSize = (uint)Marshal.SizeOf(typeof(NOTIFYICONIDENTIFIER));
				this.hWnd = hWnd;
				this.uID = uID;
				guidItem = default;
			}

			/// <summary>Initializes a new instance of the <see cref="NOTIFYICONIDENTIFIER"/> struct.</summary>
			/// <param name="guidItem">A registered GUID that identifies the icon.</param>
			public NOTIFYICONIDENTIFIER(Guid guidItem)
			{
				cbSize = (uint)Marshal.SizeOf(typeof(NOTIFYICONIDENTIFIER));
				this.hWnd = default;
				this.uID = default;
				this.guidItem = guidItem;
			}
		}

		/// <summary>Contains information used by ShellExecuteEx.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Shellapi.h", MSDNShortId = "bb759784")]
		public struct SHELLEXECUTEINFO
		{
			/// <summary>Required. The size of this structure, in bytes.</summary>
			public int cbSize;

			/// <summary>Flags that indicate the content and validity of the other structure members.</summary>
			public ShellExecuteMaskFlags fMask;

			/// <summary>
			/// Optional. A handle to the parent window, used to display any message boxes that the system might produce while executing this
			/// function. This value can be NULL.
			/// </summary>
			public HWND hwnd;

			/// <summary>
			/// A string, referred to as a verb, that specifies the action to be performed. The set of available verbs depends on the
			/// particular file or folder. Generally, the actions available from an object's shortcut menu are available verbs. This
			/// parameter can be NULL, in which case the default verb is used if available. If not, the "open" verb is used. If neither verb
			/// is available, the system uses the first verb listed in the registry. The following verbs are commonly used:
			/// <list>
			/// <item>
			/// <term>edit</term>
			/// <definition>Launches an editor and opens the document for editing.If lpFile is not a document file, the function will fail.</definition>
			/// </item>
			/// <item>
			/// <term>explore</term>
			/// <definition>Explores the folder specified by lpFile.</definition>
			/// </item>
			/// <item>
			/// <term>find</term>
			/// <definition>Initiates a search starting from the specified directory.</definition>
			/// </item>
			/// <item>
			/// <term>open</term>
			/// <definition>Opens the file specified by the lpFile parameter. The file can be an executable file, a document file, or a folder.</definition>
			/// </item>
			/// <item>
			/// <term>print</term>
			/// <definition>Prints the document file specified by lpFile.If lpFile is not a document file, the function will fail.</definition>
			/// </item>
			/// <item>
			/// <term>properties</term>
			/// <definition>Displays the file or folder's properties.</definition>
			/// </item>
			/// </list>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpVerb;

			/// <summary>
			/// The address of a null-terminated string that specifies the name of the file or object on which ShellExecuteEx will perform
			/// the action specified by the lpVerb parameter. The system registry verbs that are supported by the ShellExecuteEx function
			/// include "open" for executable files and document files and "print" for document files for which a print handler has been
			/// registered. Other applications might have added Shell verbs through the system registry, such as "play" for .avi and .wav
			/// files. To specify a Shell namespace object, pass the fully qualified parse name and set the SEE_MASK_INVOKEIDLIST flag in the
			/// fMask parameter. <note>If the SEE_MASK_INVOKEIDLIST flag is set, you can use either lpFile or lpIDList to identify the item
			/// by its file system path or its PIDL respectively. One of the two values—lpFile or lpIDList—must be set.</note><note>If the
			/// path is not included with the name, the current directory is assumed.</note>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpFile;

			/// <summary>
			/// Optional. The address of a null-terminated string that contains the application parameters. The parameters must be separated
			/// by spaces. If the lpFile member specifies a document file, lpParameters should be NULL.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpParameters;

			/// <summary>
			/// Optional. The address of a null-terminated string that specifies the name of the working directory. If this member is NULL,
			/// the current directory is used as the working directory.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpDirectory;

			/// <summary>
			/// Required. Flags that specify how an application is to be shown when it is opened; one of the SW_ values listed for the
			/// ShellExecute function. If lpFile specifies a document file, the flag is simply passed to the associated application. It is up
			/// to the application to decide how to handle it.
			/// </summary>
			public ShowWindowCommand nShellExecuteShow;

			/// <summary>
			/// [out] If SEE_MASK_NOCLOSEPROCESS is set and the ShellExecuteEx call succeeds, it sets this member to a value greater than 32.
			/// If the function fails, it is set to an SE_ERR_XXX error value that indicates the cause of the failure. Although hInstApp is
			/// declared as an HINSTANCE for compatibility with 16-bit Windows applications, it is not a true HINSTANCE. It can be cast only
			/// to an int and compared to either 32 or the following SE_ERR_XXX error codes.
			/// </summary>
			public HINSTANCE hInstApp;

			/// <summary>
			/// The address of an absolute ITEMIDLIST structure (PCIDLIST_ABSOLUTE) to contain an item identifier list that uniquely
			/// identifies the file to execute. This member is ignored if the fMask member does not include SEE_MASK_IDLIST or SEE_MASK_INVOKEIDLIST.
			/// </summary>
			public IntPtr lpIDList;

			/// <summary>
			/// The address of a null-terminated string that specifies one of the following:
			/// <list type="bullet">
			/// <item>
			/// <term>A ProgId. For example, "Paint.Picture".</term>
			/// </item>
			/// <item>
			/// <term>A URI protocol scheme. For example, "http".</term>
			/// </item>
			/// <item>
			/// <term>A file extension. For example, ".txt".</term>
			/// </item>
			/// <item>
			/// <term>
			/// A registry path under HKEY_CLASSES_ROOT that names a subkey that contains one or more Shell verbs. This key will have a
			/// subkey that conforms to the Shell verb registry schema, such as <c>shell\verb name</c>.
			/// </term>
			/// </item>
			/// </list>
			/// <para>This member is ignored if fMask does not include SEE_MASK_CLASSNAME.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpClass;

			/// <summary>
			/// A handle to the registry key for the file type. The access rights for this registry key should be set to KEY_READ. This
			/// member is ignored if fMask does not include SEE_MASK_CLASSKEY.
			/// </summary>
			public HKEY hkeyClass;

			/// <summary>
			/// A keyboard shortcut to associate with the application. The low-order word is the virtual key code, and the high-order word is
			/// a modifier flag (HOTKEYF_). For a list of modifier flags, see the description of the WM_SETHOTKEY message. This member is
			/// ignored if fMask does not include SEE_MASK_HOTKEY.
			/// </summary>
			public uint dwHotKey;

			/// <summary>
			/// A handle to the icon for the file type. This member is ignored if fMask does not include SEE_MASK_ICON. This value is used
			/// only in Windows XP and earlier. It is ignored as of Windows Vista.
			/// <para><c>OR</c></para>
			/// <para>
			/// A handle to the monitor upon which the document is to be displayed. This member is ignored if fMask does not include SEE_MASK_HMONITOR.
			/// </para>
			/// </summary>
			public HICON hIcon;

			/// <summary>
			/// A handle to the newly started application. This member is set on return and is always NULL unless fMask is set to
			/// SEE_MASK_NOCLOSEPROCESS. Even if fMask is set to SEE_MASK_NOCLOSEPROCESS, hProcess will be NULL if no process was launched.
			/// For example, if a document to be launched is a URL and an instance of Internet Explorer is already running, it will display
			/// the document. No new process is launched, and hProcess will be NULL. <note>ShellExecuteEx does not always return an hProcess,
			/// even if a process is launched as the result of the call. For example, an hProcess does not return when you use
			/// SEE_MASK_INVOKEIDLIST to invoke IContextMenu.</note>
			/// </summary>
			public HPROCESS hProcess;

			/// <summary>Initializes a new instance of the <see cref="SHELLEXECUTEINFO"/> struct.</summary>
			/// <param name="fileName">Name of the file.</param>
			/// <param name="parameters">The parameters.</param>
			public SHELLEXECUTEINFO(string fileName, string parameters = null) : this()
			{
				cbSize = Marshal.SizeOf(this);
				lpFile = fileName;
				lpParameters = parameters;
				nShellExecuteShow = ShowWindowCommand.SW_NORMAL;
			}
		}

		/// <summary>Contains information about a file object.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[PInvokeData("Shellapi.h", MSDNShortId = "bb759792")]
		public struct SHFILEINFO
		{
			/// <summary>
			/// A handle to the icon that represents the file. You are responsible for destroying this handle with DestroyIcon when you no
			/// longer need it.
			/// </summary>
			public HICON hIcon;

			/// <summary>The index of the icon image within the system image list.</summary>
			public int iIcon;

			/// <summary>
			/// An array of values that indicates the attributes of the file object. For information about these values, see the
			/// IShellFolder::GetAttributesOf method.
			/// </summary>
			public int dwAttributes;

			/// <summary>
			/// A string that contains the name of the file as it appears in the Windows Shell, or the path and file name of the file that
			/// contains the icon representing the file.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string szDisplayName;

			/// <summary>A string that describes the type of file.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)] public string szTypeName;

			/// <summary>Gets the size of this structure.</summary>
			/// <value>The structure size in bytes.</value>
			public static int Size => Marshal.SizeOf(typeof(SHFILEINFO));
		}

		/// <summary>Contains information that the SHFileOperation function uses to perform file operations.</summary>
		[PInvokeData("Shellapi.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SHFILEOPSTRUCT
		{
			/// <summary>A window handle to the dialog box to display information about the status of the file operation.</summary>
			public HWND hwnd;

			/// <summary>A value that indicates which operation to perform.</summary>
			public ShellFileOperation wFunc;

			/// <summary>
			/// <note type="note">This string must be double-null terminated.</note>
			/// <para>A pointer to one or more source file names.These names should be fully qualified paths to prevent unexpected results.</para>
			/// <para>
			/// Standard MS-DOS wildcard characters, such as "*", are permitted only in the file-name position.Using a wildcard character
			/// elsewhere in the string will lead to unpredictable results.
			/// </para>
			/// <para>
			/// Although this member is declared as a single null-terminated string, it is actually a buffer that can hold multiple
			/// null-delimited file names.Each file name is terminated by a single NULL character. The last file name is terminated with a
			/// double NULL character ("\0\0") to indicate the end of the buffer.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pFrom;

			/// <summary>
			/// <note type="note">This string must be double-null terminated.</note>
			/// <para>
			/// A pointer to the destination file or directory name. This parameter must be set to NULL if it is not used. Wildcard
			/// characters are not allowed. Their use will lead to unpredictable results.
			/// </para>
			/// <para>
			/// Like pFrom, the pTo member is also a double-null terminated string and is handled in much the same way. However, pTo must
			/// meet the following specifications:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <description>Wildcard characters are not supported.</description>
			/// </item>
			/// <item>
			/// <description>
			/// Copy and Move operations can specify destination directories that do not exist. In those cases, the system attempts to create
			/// them and normally displays a dialog box to ask the user if they want to create the new directory. To suppress this dialog box
			/// and have the directories created silently, set the FOF_NOCONFIRMMKDIR flag in fFlags.
			/// </description>
			/// </item>
			/// <item>
			/// <description>
			/// For Copy and Move operations, the buffer can contain multiple destination file names if the fFlags member specifies FOF_MULTIDESTFILES.
			/// </description>
			/// </item>
			/// <item>
			/// <description>Pack multiple names into the pTo string in the same way as for pFrom.</description>
			/// </item>
			/// <item>
			/// <description>Use fully qualified paths. Using relative paths is not prohibited, but can have unpredictable results.</description>
			/// </item>
			/// </list>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pTo;

			/// <summary>Flags that control the file operation.</summary>
			public FILEOP_FLAGS fFlags;

			/// <summary>
			/// When the function returns, this member contains TRUE if any file operations were aborted before they were completed;
			/// otherwise, FALSE. An operation can be manually aborted by the user through UI or it can be silently aborted by the system if
			/// the FOF_NOERRORUI or FOF_NOCONFIRMATION flags were set.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fAnyOperationsAborted;

			/// <summary>
			/// When the function returns, this member contains a handle to a name mapping object that contains the old and new names of the
			/// renamed files. This member is used only if the fFlags member includes the FOF_WANTMAPPINGHANDLE flag. See Remarks for more details.
			/// </summary>
			public IntPtr hNameMappings;

			/// <summary>
			/// A pointer to the title of a progress dialog box. This is a null-terminated string. This member is used only if fFlags
			/// includes the FOF_SIMPLEPROGRESS flag.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszProgressTitle;
		}

		/// <summary>
		/// <para>Contains the size and item count information retrieved by the SHQueryRecycleBin function.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/ns-shellapi-_shqueryrbinfo typedef struct _SHQUERYRBINFO { DWORD
		// cbSize; __int64 i64Size; __int64 i64NumItems; DWORDLONG i64Size; DWORDLONG i64NumItems; } SHQUERYRBINFO, *LPSHQUERYRBINFO;
		[PInvokeData("shellapi.h", MSDNShortId = "7e9bc7e9-5712-45e7-a424-0afb62f26450")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct SHQUERYRBINFO
		{
			/// <summary>The size of the structure, in bytes. This member must be filled in prior to calling the function.</summary>
			public uint cbSize;

			/// <summary>The total size, in bytes, of all the items currently in the Recycle Bin.</summary>
			public long i64Size;

			/// <summary>The total number of items currently in the Recycle Bin.</summary>
			public long i64NumItems;
		}

		/// <summary>
		/// <para>Receives information used to retrieve a stock Shell icon. This structure is used in a call SHGetStockIconInfo.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/ns-shellapi-_shstockiconinfo typedef struct _SHSTOCKICONINFO { DWORD
		// cbSize; HICON hIcon; int iSysImageIndex; int iIcon; WCHAR szPath[MAX_PATH]; } SHSTOCKICONINFO;
		[PInvokeData("shellapi.h", MSDNShortId = "4d32826a-bb40-4805-9826-801c142b8d28")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SHSTOCKICONINFO
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The size of this structure, in bytes.</para>
			/// </summary>
			public uint cbSize;

			/// <summary>
			/// <para>Type: <c>HICON</c></para>
			/// <para>When SHGetStockIconInfo is called with the SHGSI_ICON flag, this member receives a handle to the icon.</para>
			/// </summary>
			public HICON hIcon;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// When SHGetStockIconInfo is called with the SHGSI_SYSICONINDEX flag, this member receives the index of the image in the system
			/// icon cache.
			/// </para>
			/// </summary>
			public int iSysImageIndex;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// When SHGetStockIconInfo is called with the SHGSI_ICONLOCATION flag, this member receives the index of the icon in the
			/// resource whose path is received in <c>szPath</c>.
			/// </para>
			/// </summary>
			public int iIcon;

			/// <summary>
			/// <para>Type: <c>WCHAR[MAX_PATH]</c></para>
			/// <para>
			/// When SHGetStockIconInfo is called with the SHGSI_ICONLOCATION flag, this member receives the path of the resource that
			/// contains the icon. The index of the icon within the resource is received in <c>iIcon</c>.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string szPath;

			/// <summary>The default empty instance of SHSTOCKICONINFO with cbSize set appropriately.</summary>
			public static readonly SHSTOCKICONINFO Default = new() { cbSize = (uint)Marshal.SizeOf(typeof(SHSTOCKICONINFO)) };
		}
	}
}