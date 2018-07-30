using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		public const string CMDSTR_NEWFOLDER = "NewFolder";
		public const string CMDSTR_OPEN = "Open";
		public const string CMDSTR_PREVIEW = "Preview";
		public const string CMDSTR_PRINT = "Print";
		public const string CMDSTR_RUNAS = "RunAs";
		public const string CMDSTR_VIEWDETAILS = "ViewDetails";
		public const string CMDSTR_VIEWLIST = "ViewList";

		/// <summary>Flag options for the IContextMenu interface.</summary>
		[PInvokeData("Shobjidl.h")]
		[Flags]
		public enum CMF : uint
		{
			/// <summary>Indicates normal operation. A shortcut menu extension, namespace extension, or drag-and-drop handler can add all menu items.</summary>
			CMF_NORMAL = 0x00000000,

			/// <summary>
			/// The user is activating the default action, typically by double-clicking. This flag provides a hint for the shortcut menu extension to add nothing
			/// if it does not modify the default item in the menu. A shortcut menu extension or drag-and-drop handler should not add any menu items if this
			/// value is specified. A namespace extension should at most add only the default item.
			/// </summary>
			CMF_DEFAULTONLY = 0x00000001,

			/// <summary>The shortcut menu is that of a shortcut file (normally, a .lnk file). Shortcut menu handlers should ignore this value.</summary>
			CMF_VERBSONLY = 0x00000002,

			/// <summary>The Windows Explorer tree window is present.</summary>
			CMF_EXPLORE = 0x00000004,

			/// <summary>This flag is set for items displayed in the Send To menu. Shortcut menu handlers should ignore this value.</summary>
			CMF_NOVERBS = 0x00000008,

			/// <summary>
			/// The calling application supports renaming of items. A shortcut menu or drag-and-drop handler should ignore this flag. A namespace extension
			/// should add a Rename item to the menu if applicable.
			/// </summary>
			CMF_CANRENAME = 0x00000010,

			/// <summary>
			/// No item in the menu has been set as the default. A drag-and-drop handler should ignore this flag. A namespace extension should not set any of the
			/// menu items as the default.
			/// </summary>
			CMF_NODEFAULT = 0x00000020,

			///<summary>0x00000100. The calling application wants extended verbs. Normal verbs are displayed when the user right-clicks an object. To display extended verbs, the user must right-click while pressing the Shift key.</summary>
			CMF_EXTENDEDVERBS = 0x00000100,

			/// <summary>
			/// This value is not available.
			/// <para>
			/// Windows Server 2003 and Windows XP: 0x00000040. A static menu is being constructed. Only the browser should use this flag; all other shortcut
			/// menu extensions should ignore it.
			/// </para>
			/// </summary>
			CMF_INCLUDESTATIC = 0x00000040,

			/// <summary>
			/// 0x00000080. The calling application is invoking a shortcut menu on an item in the view (as opposed to the background of the view).
			/// <para>Windows Server 2003 and Windows XP: This value is not available.</para>
			/// </summary>
			CMF_ITEMMENU = 0x00000080,

			/// <summary>
			/// 0x00000200. The calling application intends to invoke verbs that are disabled, such as legacy menus.
			/// <para>Windows Server 2003 and Windows XP: This value is not available.</para>
			/// </summary>
			CMF_DISABLEDVERBS = 0x00000200,

			/// <summary>
			/// 0x00000400. The verb state can be evaluated asynchronously.
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.</para>
			/// </summary>
			CMF_ASYNCVERBSTATE = 0x00000400,

			/// <summary>
			/// 0x00000800. Informs context menu handlers that do not support the invocation of a verb through a canonical verb name to bypass
			/// IContextMenu::QueryContextMenu in their implementation.
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.</para>
			/// </summary>
			CMF_OPTIMIZEFORINVOKE = 0x00000800,

			/// <summary>
			/// 0x00001000. Populate submenus synchronously.
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.</para>
			/// </summary>
			CMF_SYNCCASCADEMENU = 0x00001000,

			/// <summary>
			/// 0x00001000. When no verb is explicitly specified, do not use a default verb in its place.
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.</para>
			/// </summary>
			CMF_DONOTPICKDEFAULT = 0x00002000,

			/// <summary>
			/// 0xffff0000. This flag is a bitmask that specifies all bits that should not be used. This is to be used only as a mask. Do not pass this as a
			/// parameter value.
			/// </summary>
			CMF_RESERVED = 0xffff0000,
		}

		/// <summary>Indicate desired behavior and indicate that other fields in the structure are to be used for <see cref="CMINVOKECOMMANDINFOEX"/>.</summary>
		[PInvokeData("Shobjidl.h")]
		[Flags]
		public enum CMIC : uint
		{
			/// <summary>The hIcon member is valid. As of Windows Vista this flag is not used.</summary>
			CMIC_MASK_ICON = 0x00000010,

			/// <summary>The dwHotKey member is valid.</summary>
			CMIC_MASK_HOTKEY = 0x00000020,

			/// <summary>
			/// Windows Vista and later. The implementation of IContextMenu::InvokeCommand should be synchronous, not returning before it is complete. Since this
			/// is recommended, calling applications that specify this flag cannot guarantee that this request will be honored if they are not familiar with the
			/// implementation of the verb that they are invoking.
			/// </summary>
			CMIC_MASK_NOASYNC = 0x00000100,

			/// <summary>The system is prevented from displaying user interface elements (for example, error messages) while carrying out a command.</summary>
			CMIC_MASK_FLAG_NO_UI = 0x00000400,

			/// <summary>
			/// The shortcut menu handler should use lpVerbW, lpParametersW, lpDirectoryW, and lpTitleW members instead of their ANSI equivalents. Because some
			/// shortcut menu handlers may not support Unicode, you should also pass valid ANSI strings in the lpVerb, lpParameters, lpDirectory, and lpTitle members.
			/// </summary>
			CMIC_MASK_UNICODE = 0x00004000,

			/// <summary>
			/// If a shortcut menu handler needs to create a new process, it will normally create a new console. Setting the CMIC_MASK_NO_CONSOLE flag suppresses
			/// the creation of a new console.
			/// </summary>
			CMIC_MASK_NO_CONSOLE = 0x00008000,

			/// <summary>Wait for the DDE conversation to terminate before returning.</summary>
			CMIC_MASK_ASYNCOK = 0x00100000,

			/// <summary>Do not perform a zone check. This flag allows ShellExecuteEx to bypass zone checking put into place by IAttachmentExecute.</summary>
			CMIC_MASK_NOZONECHECKS = 0x00800000,

			/// <summary>
			/// Indicates that the implementation of IContextMenu::InvokeCommand might want to keep track of the item being invoked for features like the "Recent
			/// documents" menu.
			/// </summary>
			CMIC_MASK_FLAG_LOG_USAGE = 0x04000000,

			/// <summary>
			/// The SHIFT key is pressed. Use this instead of polling the current state of the keyboard that may have changed since the verb was invoked.
			/// </summary>
			CMIC_MASK_SHIFT_DOWN = 0x10000000,

			/// <summary>The ptInvoke member is valid.</summary>
			CMIC_MASK_PTINVOKE = 0x20000000,

			/// <summary>
			/// The CTRL key is pressed. Use this instead of polling the current state of the keyboard that may have changed since the verb was invoked.
			/// </summary>
			CMIC_MASK_CONTROL_DOWN = 0x40000000,
		}

		/// <summary>Flags specifying the information to return.</summary>
		[PInvokeData("Shobjidl.h")]
		public enum GCS : uint
		{
			/// <summary>Sets pszName to an ANSI string containing the language-independent command name for the menu item.</summary>
			GCS_VERBA = 0x00000000,
			/// <summary>Sets pszName to an ANSI string containing the help text for the command.</summary>
			GCS_HELPTEXTA = 0x00000001,
			/// <summary>Returns S_OK if the menu item exists, or S_FALSE otherwise.</summary>
			GCS_VALIDATEA = 0x00000002,
			/// <summary>Sets pszName to a Unicode string containing the language-independent command name for the menu item.</summary>
			GCS_VERBW = 0x00000004,
			/// <summary>Sets pszName to a Unicode string containing the help text for the command.</summary>
			GCS_HELPTEXTW = 0x00000005,
			/// <summary>Returns S_OK if the menu item exists, or S_FALSE otherwise.</summary>
			GCS_VALIDATEW = 0x00000006,
			/// <summary>Sets pszName to a Unicode string containing the icon string for the command.</summary>
			GCS_VERBICONW = 0x00000014,
			/// <summary>For Unicode bit testing.</summary>
			GCS_UNICODE = 0x00000004,
		}

		/// <summary>Exposes methods that either create or merge a shortcut menu associated with a Shell object.</summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb776095(v=vs.85).aspx
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776095")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214E4-0000-0000-c000-000000000046")]
		public interface IContextMenu
		{
			/// <summary>Adds commands to a shortcut menu.</summary>
			/// <param name="hmenu">A handle to the shortcut menu. The handler should specify this handle when adding menu items.</param>
			/// <param name="indexMenu">The zero-based position at which to insert the first new menu item.</param>
			/// <param name="idCmdFirst">The minimum value that the handler can specify for a menu item identifier.</param>
			/// <param name="idCmdLast">The maximum value that the handler can specify for a menu item identifier.</param>
			/// <param name="uFlags">Optional flags that specify how the shortcut menu can be changed.</param>
			/// <returns>
			/// If successful, returns an HRESULT value that has its severity value set to SEVERITY_SUCCESS and its code value set to the offset of the largest
			/// command identifier that was assigned, plus one. For example, if idCmdFirst is set to 5 and you add three items to the menu with command
			/// identifiers of 5, 7, and 8, the return value should be MAKE_HRESULT(SEVERITY_SUCCESS, 0, 8 - 5 + 1). Otherwise, it returns a COM error value.
			/// </returns>
			[PreserveSig]
			HRESULT QueryContextMenu(IntPtr hmenu, uint indexMenu, uint idCmdFirst, uint idCmdLast, CMF uFlags);

			/// <summary>Carries out the command associated with a shortcut menu item.</summary>
			/// <param name="pici">A pointer to a CMINVOKECOMMANDINFO or CMINVOKECOMMANDINFOEX structure that contains specifics about the command.</param>
			void InvokeCommand([In] ref CMINVOKECOMMANDINFOEX pici);

			/// <summary>
			/// Gets information about a shortcut menu command, including the help string and the language-independent, or canonical, name for the command.
			/// </summary>
			/// <param name="idCmd">Menu command identifier offset.</param>
			/// <param name="uType">Flags specifying the information to return.</param>
			/// <param name="pReserved">Reserved. Applications must specify NULL when calling this method and handlers must ignore this parameter when called.</param>
			/// <param name="pszName">The reference of the buffer to receive the null-terminated string being retrieved.</param>
			/// <param name="cchMax">Size of the buffer, in characters, to receive the null-terminated string.</param>
			/// <returns>If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			void GetCommandString(IntPtr idCmd, GCS uType, IntPtr pReserved, IntPtr pszName, uint cchMax);
		}

		/// <summary>
		/// Exposes methods that either create or merge a shortcut (context) menu associated with a Shell object. Extends IContextMenu by
		/// adding a method that allows client objects to handle messages associated with owner-drawn menu items.
		/// </summary>
		/// <remarks>
		/// <para>This interface also provides the methods of the IContextMenu interface, from which it inherits.</para>
		/// <para><c>Note</c><c>Windows Vista and later.</c> Prior to Windows Vista this interface was declared in Shlobj.h.</para>
		/// <para>When to Implement</para>
		/// <para>
		/// Implement IContextMenu2 if your namespace extension or shortcut menu handler needs to process one or more of the following messages.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>MENUPOPUP</term>
		/// </item>
		/// <item>
		/// <term>ITEM</term>
		/// </item>
		/// <item>
		/// <term>WM_MEASUREITEM</term>
		/// </item>
		/// </list>
		/// <para>
		/// These messages are forwarded to IContextMenu2—through the HandleMenuMsg method—only if a QueryInterface call for an IContextMenu2
		/// interface pointer is successful, indicating that the object supports this interface.
		/// </para>
		/// <para>When to Use</para>
		/// <para>Applications do not normally call this interface directly.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-icontextmenu2
		[PInvokeData("shobjidl_core.h", MSDNShortId = "4e3331ad-4adc-4ea9-8a22-6aad15f618c8")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214F4-0000-0000-c000-000000000046")]
		public interface IContextMenu2 : IContextMenu
		{
			/// <summary>Adds commands to a shortcut menu.</summary>
			/// <param name="hmenu">A handle to the shortcut menu. The handler should specify this handle when adding menu items.</param>
			/// <param name="indexMenu">The zero-based position at which to insert the first new menu item.</param>
			/// <param name="idCmdFirst">The minimum value that the handler can specify for a menu item identifier.</param>
			/// <param name="idCmdLast">The maximum value that the handler can specify for a menu item identifier.</param>
			/// <param name="uFlags">Optional flags that specify how the shortcut menu can be changed.</param>
			/// <returns>
			/// If successful, returns an HRESULT value that has its severity value set to SEVERITY_SUCCESS and its code value set to the offset of the largest
			/// command identifier that was assigned, plus one. For example, if idCmdFirst is set to 5 and you add three items to the menu with command
			/// identifiers of 5, 7, and 8, the return value should be MAKE_HRESULT(SEVERITY_SUCCESS, 0, 8 - 5 + 1). Otherwise, it returns a COM error value.
			/// </returns>
			[PreserveSig]
			new HRESULT QueryContextMenu(IntPtr hmenu, uint indexMenu, uint idCmdFirst, uint idCmdLast, CMF uFlags);

			/// <summary>Carries out the command associated with a shortcut menu item.</summary>
			/// <param name="pici">A pointer to a CMINVOKECOMMANDINFO or CMINVOKECOMMANDINFOEX structure that contains specifics about the command.</param>
			new void InvokeCommand([In] ref CMINVOKECOMMANDINFOEX pici);

			/// <summary>
			/// Gets information about a shortcut menu command, including the help string and the language-independent, or canonical, name for the command.
			/// </summary>
			/// <param name="idCmd">Menu command identifier offset.</param>
			/// <param name="uType">Flags specifying the information to return.</param>
			/// <param name="pReserved">Reserved. Applications must specify NULL when calling this method and handlers must ignore this parameter when called.</param>
			/// <param name="pszName">The reference of the buffer to receive the null-terminated string being retrieved.</param>
			/// <param name="cchMax">Size of the buffer, in characters, to receive the null-terminated string.</param>
			/// <returns>If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			new void GetCommandString(IntPtr idCmd, GCS uType, IntPtr pReserved, IntPtr pszName, uint cchMax);

			/// <summary>Enables client objects of the IContextMenu interface to handle messages associated with owner-drawn menu items.</summary>
			/// <param name="uMsg">
			/// The message to be processed. In the case of some messages, such as WM_INITMENUPOPUP, WM_DRAWITEM, WM_MENUCHAR, or WM_MEASUREITEM, the client
			/// object being called may provide owner-drawn menu items.
			/// </param>
			/// <param name="wParam">Additional message information. The value of this parameter depends on the value of the uMsg parameter.</param>
			/// <param name="lParam">Additional message information. The value of this parameter depends on the value of the uMsg parameter.</param>
			void HandleMenuMsg(uint uMsg, IntPtr wParam, IntPtr lParam);
		}

		/// <summary>
		/// <para>
		/// Exposes methods that either create or merge a shortcut menu associated with a Shell object. Allows client objects to handle
		/// messages associated with owner-drawn menu items and extends IContextMenu2 by accepting a return value from that message handling.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>This interface also provides the methods of the IContextMenu and IContextMenu2 interfaces, from which it inherits.</para>
		/// <para>When to Implement</para>
		/// <para>Implement IContextMenu3 if your shortcut menu extension needs to process the WM_MENUCHAR message.</para>
		/// <para>
		/// This message is forwarded to IContextMenu3::HandleMenuMsg2 only if a QueryInterface call for an <c>IContextMenu3</c> interface
		/// pointer is successful, which indicates that the object supports this interface.
		/// </para>
		/// <para>When to Use</para>
		/// <para>You do not call this interface directly. IContextMenu3 is used by the operating system only when it has confirmed that your application is aware of this interface.</para>
		/// <para><c>Note</c><c>Windows Vista and later.</c> Prior to Windows Vista this interface was declared in Shlobj.h.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-icontextmenu3
		[PInvokeData("shobjidl_core.h", MSDNShortId = "c08e1b98-2b8b-41f6-93c5-3a5937bd3b2c")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), GuidAttribute("bcfce0a0-ec17-11d0-8d10-00a0c90f2719")]
		public interface IContextMenu3 : IContextMenu2
		{
			/// <summary>Adds commands to a shortcut menu.</summary>
			/// <param name="hmenu">A handle to the shortcut menu. The handler should specify this handle when adding menu items.</param>
			/// <param name="indexMenu">The zero-based position at which to insert the first new menu item.</param>
			/// <param name="idCmdFirst">The minimum value that the handler can specify for a menu item identifier.</param>
			/// <param name="idCmdLast">The maximum value that the handler can specify for a menu item identifier.</param>
			/// <param name="uFlags">Optional flags that specify how the shortcut menu can be changed.</param>
			/// <returns>
			/// If successful, returns an HRESULT value that has its severity value set to SEVERITY_SUCCESS and its code value set to the offset of the largest
			/// command identifier that was assigned, plus one. For example, if idCmdFirst is set to 5 and you add three items to the menu with command
			/// identifiers of 5, 7, and 8, the return value should be MAKE_HRESULT(SEVERITY_SUCCESS, 0, 8 - 5 + 1). Otherwise, it returns a COM error value.
			/// </returns>
			[PreserveSig]
			new HRESULT QueryContextMenu(IntPtr hmenu, uint indexMenu, uint idCmdFirst, uint idCmdLast, CMF uFlags);

			/// <summary>Carries out the command associated with a shortcut menu item.</summary>
			/// <param name="pici">A pointer to a CMINVOKECOMMANDINFO or CMINVOKECOMMANDINFOEX structure that contains specifics about the command.</param>
			new void InvokeCommand([In] ref CMINVOKECOMMANDINFOEX pici);

			/// <summary>
			/// Gets information about a shortcut menu command, including the help string and the language-independent, or canonical, name for the command.
			/// </summary>
			/// <param name="idCmd">Menu command identifier offset.</param>
			/// <param name="uType">Flags specifying the information to return.</param>
			/// <param name="pReserved">Reserved. Applications must specify NULL when calling this method and handlers must ignore this parameter when called.</param>
			/// <param name="pszName">The reference of the buffer to receive the null-terminated string being retrieved.</param>
			/// <param name="cchMax">Size of the buffer, in characters, to receive the null-terminated string.</param>
			/// <returns>If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			new void GetCommandString(IntPtr idCmd, GCS uType, IntPtr pReserved, IntPtr pszName, uint cchMax);

			/// <summary>Enables client objects of the IContextMenu interface to handle messages associated with owner-drawn menu items.</summary>
			/// <param name="uMsg">
			/// The message to be processed. In the case of some messages, such as WM_INITMENUPOPUP, WM_DRAWITEM, WM_MENUCHAR, or WM_MEASUREITEM, the client
			/// object being called may provide owner-drawn menu items.
			/// </param>
			/// <param name="wParam">Additional message information. The value of this parameter depends on the value of the uMsg parameter.</param>
			/// <param name="lParam">Additional message information. The value of this parameter depends on the value of the uMsg parameter.</param>
			new void HandleMenuMsg(uint uMsg, IntPtr wParam, IntPtr lParam);

			/// <summary>Allows client objects of the IContextMenu3 interface to handle messages associated with owner-drawn menu items.</summary>
			/// <param name="uMsg">
			/// The message to be processed. In the case of some messages, such as WM_INITMENUPOPUP, WM_DRAWITEM, WM_MENUCHAR, or WM_MEASUREITEM, the client
			/// object being called may provide owner-drawn menu items.
			/// </param>
			/// <param name="wParam">Additional message information. The value of this parameter depends on the value of the uMsg parameter.</param>
			/// <param name="lParam">Additional message information. The value of this parameter depends on the value of the uMsg parameter.</param>
			/// <param name="result">The address of an LRESULT value that the owner of the menu will return from the message. This parameter can be NULL.</param>
			void HandleMenuMsg2(uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr result);
		}

		/// <summary>
		/// Exposes a method that enables the callback of a context menu. For example, to add a shield icon to a <c>menuItem</c> that
		/// requires elevation.
		/// </summary>
		/// <remarks>
		/// <para>This is the callback interface specified in the DEFCONTEXTMENU structure passed with the function SHCreateDefaultContextMenu.</para>
		/// <para>
		/// This interface enables IShellFolder implementations to manage context menu messages before, after, and during the context menu
		/// handling of these messages.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-icontextmenucb
		[PInvokeData("shobjidl_core.h", MSDNShortId = "1a4c183b-97cf-4c9a-af5a-bcea7c2755a5")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("3409E930-5A39-11d1-83FA-00A0C90DC849")]
		public interface IContextMenuCB
		{
			/// <summary>Enables the callback function for a context menu.</summary>
			/// <param name="psf">
			/// A pointer to the IShellFolder interface of the object that supports the IContextMenuCB::CallBack interface. The context menu
			/// interface is returned on a call to GetUIObjectOf.
			/// </param>
			/// <param name="hwndOwner">A handle to the owner of the context menu. This value can be NULL.</param>
			/// <param name="pdtobj">
			/// A pointer to an IDataObject that contains information about a menu selection. Implement interface IDataObject, or call
			/// SHCreateDataObject for the default implementation.
			/// </param>
			/// <param name="uMsg">
			/// A notification from the Shell's default menu implementation. For example, the default menu implementation calls
			/// DFM_MERGECONTEXTMENU to allow the implementer of IContextMenuCB::CallBack to remove, add, or disable context menu items in
			/// this callback.
			/// </param>
			/// <param name="wParam">
			/// Data specific to the notification specified in uMsg. See the individual notification page for specific requirements.
			/// </param>
			/// <param name="lParam">
			/// Data specific to the notification specified in uMsg. See the individual notification page for specific requirements.
			/// </param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			[PreserveSig]
			HRESULT CallBack(IShellFolder psf, IntPtr hwndOwner, IDataObject pdtobj, uint uMsg, IntPtr wParam, IntPtr lParam);
		}

		/*
		/// <summary>Contains information needed by IContextMenu::InvokeCommand to invoke a shortcut menu command.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct CMINVOKECOMMANDINFO
		{
			public uint cbSize;
			public CMIC fMask;
			public IntPtr hwnd;
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpVerb;
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpParameters;
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpDirectory;
			public int nShow;
			public uint dwHotKey;
			public IntPtr hIcon;
		}
		*/

		/// <summary>
		/// Contains extended information about a shortcut menu command. This structure is an extended version of CMINVOKECOMMANDINFO that
		/// allows the use of Unicode values.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Although the IContextMenu::InvokeCommand declaration specifies a CMINVOKECOMMANDINFO structure for the parameter, it can also
		/// accept a <c>CMINVOKECOMMANDINFOEX</c> structure. If you are implementing this method, you must inspect <c>cbSize</c> to determine
		/// which structure has been passed.
		/// </para>
		/// <para>
		/// By default, all 16-bit Windows-based applications run as threads in a single, shared VDM. The advantage of running separately is
		/// that a crash only terminates the single VDM; any other programs running in distinct VDMs continue to function normally. Also,
		/// 16-bit Windows-based applications that are run in separate VDMs have separate input queues. That means that if one application
		/// stops responding momentarily, applications in separate VDMs continue to receive input. The disadvantage of running separately is
		/// that it takes significantly more memory to do so.
		/// </para>
		/// <para>
		/// <c>CMINVOKECOMMANDINFOEX</c> itself is defined in Shobjidl.h, but you must also include Shellapi.h to have full access to all flags.
		/// </para>
		/// <para><c>Note</c> Prior to Windows Vista, this structure was declared in Shlobj.h.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ns-shobjidl_core-_cminvokecommandinfoex
		[PInvokeData("shobjidl_core.h", MSDNShortId = "c4c7f053-fdb1-4bba-9eb9-a514ce1d90f6")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CMINVOKECOMMANDINFOEX
		{
			/// <summary>
			/// The size of this structure, in bytes. This member should be filled in by callers of IContextMenu::InvokeCommand and tested by the implementations
			/// to know that the structure is a CMINVOKECOMMANDINFOEX structure rather than CMINVOKECOMMANDINFO.
			/// </summary>
			public uint cbSize;
			/// <summary>
			/// Zero, or one or more of the following flags are set to indicate desired behavior and indicate that other fields in the structure are to be used.
			/// </summary>
			public CMIC fMask;
			/// <summary>
			/// A handle to the window that is the owner of the shortcut menu. An extension can also use this handle as the owner of any message boxes or dialog
			/// boxes it displays. Callers must specify a legitimate HWND that can be used as the owner window for any UI that may be displayed. Failing to
			/// specify an HWND when calling from a UI thread (one with windows already created) will result in reentrancy and possible bugs in the
			/// implementation of a IContextMenu::InvokeCommand call.
			/// </summary>
			public IntPtr hwnd;
			/// <summary>
			/// The address of a null-terminated string that specifies the language-independent name of the command to carry out. This member is typically a
			/// string when a command is being activated by an application.
			/// <list type="table">
			/// <listheader>
			/// <term>Constant</term>
			/// <term>Command string</term>
			/// </listheader>
			/// <item>
			/// <description>CMDSTR_RUNAS</description>
			/// <description>"RunAs"</description>
			/// </item>
			/// <item>
			/// <description>CMDSTR_PRINT</description>
			/// <description>"Print"</description>
			/// </item>
			/// <item>
			/// <description>CMDSTR_PREVIEW</description>
			/// <description>"Preview"</description>
			/// </item>
			/// <item>
			/// <description>CMDSTR_OPEN</description>
			/// <description>"Open"</description>
			/// </item>
			/// </list>
			/// <para>This is not a fixed set; new canonical verbs can be invented by context menu handlers and applications can invoke them.</para>
			/// <para>
			/// If a canonical verb exists and a menu handler does not implement the canonical verb, it must return a failure code to enable the next handler to
			/// be able to handle this verb. Failing to do this will break functionality in the system including ShellExecute.
			/// </para>
			/// <para>
			/// Alternatively, rather than a pointer, this parameter can be MAKEINTRESOURCE(offset) where offset is the menu-identifier offset of the command to
			/// carry out. Implementations can use the IS_INTRESOURCE macro to detect that this alternative is being employed. The Shell uses this alternative
			/// when the user chooses a menu command.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpVerb;
			/// <summary>Optional parameters. This member is always NULL for menu items inserted by a Shell extension.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpParameters;
			/// <summary>An optional working directory name. This member is always NULL for menu items inserted by a Shell extension.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpDirectory;
			/// <summary>A set of SW_ values to pass to the ShowWindow function if the command displays a window or starts an application.</summary>
			public ShowWindowCommand nShow;
			/// <summary>
			/// An optional keyboard shortcut to assign to any application activated by the command. If the fMask member does not specify CMIC_MASK_HOTKEY, this
			/// member is ignored.
			/// </summary>
			public uint dwHotKey;
			/// <summary>
			/// An icon to use for any application activated by the command. If the fMask member does not specify CMIC_MASK_ICON, this member is ignored.
			/// </summary>
			public IntPtr hIcon;
			/// <summary>An ASCII title.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpTitle;
			/// <summary>A Unicode verb, for those commands that can use it.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpVerbW;
			/// <summary>A Unicode parameters, for those commands that can use it.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpParametersW;
			/// <summary>A Unicode directory, for those commands that can use it.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpDirectoryW;
			/// <summary>A Unicode title.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpTitleW;
			/// <summary>
			/// The point where the command is invoked. If the fMask member does not specify CMIC_MASK_PTINVOKE, this member is ignored. This member is not valid
			/// prior to Internet Explorer 4.0.
			/// </summary>
			public System.Drawing.Point ptInvoke;
		}
	}
}