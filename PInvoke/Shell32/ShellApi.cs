using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;
using static Vanara.PInvoke.ShlwApi;

namespace Vanara.PInvoke
{
	/// <summary>Interfaces, functions, enumerated types and structures for Shell32.dll.</summary>
	public static partial class Shell32
	{
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
			/// <summary>Registers a new appbar and specifies the message identifier that the system should use to send notification messages to the appbar.</summary>
			ABM_NEW = 0x00000000,

			/// <summary>Unregisters an appbar, removing the bar from the system's internal list.</summary>
			ABM_REMOVE = 0x00000001,

			/// <summary>Requests a size and screen position for an appbar.</summary>
			ABM_QUERYPOS = 0x00000002,

			/// <summary>Sets the size and screen position of an appbar.</summary>
			ABM_SETPOS = 0x00000003,

			/// <summary>Retrieves the autohide and always-on-top states of the Windows taskbar.</summary>
			ABM_GETSTATE = 0x00000004,

			/// <summary>Retrieves the bounding rectangle of the Windows taskbar. Note that this applies only to the system taskbar. Other objects, particularly toolbars supplied with third-party software, also can be present. As a result, some of the screen area not covered by the Windows taskbar might not be visible to the user. To retrieve the area of the screen not covered by both the taskbar and other app bars—the working area available to your application—, use the GetMonitorInfo function.</summary>
			ABM_GETTASKBARPOS = 0x00000005,

			/// <summary>Notifies the system to activate or deactivate an appbar. The lParam member of the APPBARDATA pointed to by pData is set to TRUE to activate or FALSE to deactivate.</summary>
			ABM_ACTIVATE = 0x00000006,

			/// <summary>Retrieves the handle to the autohide appbar associated with a particular edge of the screen.</summary>
			ABM_GETAUTOHIDEBAR = 0x00000007,

			/// <summary>Registers or unregisters an autohide appbar for an edge of the screen.</summary>
			ABM_SETAUTOHIDEBAR = 0x00000008,

			/// <summary>Notifies the system when an appbar's position has changed.</summary>
			ABM_WINDOWPOSCHANGED = 0x00000009,

			/// <summary>Windows XP and later: Sets the state of the appbar's autohide and always-on-top attributes.</summary>
			ABM_SETSTATE = 0x0000000A,

			/// <summary>Windows XP and later: Retrieves the handle to the autohide appbar associated with a particular edge of a particular monitor.</summary>
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

		/// <summary>Flags that indicate the content and validity of the other structure members in <see cref="SHELLEXECUTEINFO"/>.</summary>
		[PInvokeData("Shellapi.h", MSDNShortId = "bb759784")]
		[Flags]
		public enum ShellExecuteMaskFlags : uint
		{
			/// <summary>Use default values.</summary>
			SEE_MASK_DEFAULT = 0x00000000,

			/// <summary>Use the class name given by the lpClass member. If both SEE_MASK_CLASSKEY and SEE_MASK_CLASSNAME are set, the class key is used.</summary>
			SEE_MASK_CLASSNAME = 0x00000001,

			/// <summary>Use the class key given by the hkeyClass member. If both SEE_MASK_CLASSKEY and SEE_MASK_CLASSNAME are set, the class key is used.</summary>
			SEE_MASK_CLASSKEY = 0x00000003,

			/// <summary>Use the item identifier list given by the lpIDList member. The lpIDList member must point to an ITEMIDLIST structure.</summary>
			SEE_MASK_IDLIST = 0x00000004,

			/// <summary>
			/// Use the IContextMenu interface of the selected item's shortcut menu handler. Use either lpFile to identify the item by its file system path or
			/// lpIDList to identify the item by its PIDL. This flag allows applications to use ShellExecuteEx to invoke verbs from shortcut menu extensions
			/// instead of the static verbs listed in the registry. <note>SEE_MASK_INVOKEIDLIST overrides and implies SEE_MASK_IDLIST.</note>
			/// </summary>
			SEE_MASK_INVOKEIDLIST = 0x0000000c,

			/// <summary>
			/// Use the icon given by the hIcon member. This flag cannot be combined with SEE_MASK_HMONITOR. <note>This flag is used only in Windows XP and
			/// earlier. It is ignored as of Windows Vista.</note>
			/// </summary>
			SEE_MASK_ICON = 0x00000010,

			/// <summary>Use the keyboard shortcut given by the dwHotKey member.</summary>
			SEE_MASK_HOTKEY = 0x00000020,

			/// <summary>
			/// Use to indicate that the hProcess member receives the process handle. This handle is typically used to allow an application to find out when a
			/// process created with ShellExecuteEx terminates. In some cases, such as when execution is satisfied through a DDE conversation, no handle will be
			/// returned. The calling application is responsible for closing the handle when it is no longer needed.
			/// </summary>
			SEE_MASK_NOCLOSEPROCESS = 0x00000040,

			/// <summary>
			/// Validate the share and connect to a drive letter. This enables reconnection of disconnected network drives. The lpFile member is a UNC path of a
			/// file on a network.
			/// </summary>
			SEE_MASK_CONNECTNETDRV = 0x00000080,

			/// <summary>
			/// Wait for the execute operation to complete before returning. This flag should be used by callers that are using ShellExecute forms that might
			/// result in an async activation, for example DDE, and create a process that might be run on a background thread. (Note: ShellExecuteEx runs on a
			/// background thread by default if the caller's threading model is not Apartment.) Calls to ShellExecuteEx from processes already running on
			/// background threads should always pass this flag. Also, applications that exit immediately after calling ShellExecuteEx should specify this flag.
			/// <para>
			/// If the execute operation is performed on a background thread and the caller did not specify the SEE_MASK_ASYNCOK flag, then the calling thread
			/// waits until the new process has started before returning. This typically means that either CreateProcess has been called, the DDE communication
			/// has completed, or that the custom execution delegate has notified ShellExecuteEx that it is done. If the SEE_MASK_WAITFORINPUTIDLE flag is
			/// specified, then ShellExecuteEx calls WaitForInputIdle and waits for the new process to idle before returning, with a maximum timeout of 1 minute.
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
			/// Use to inherit the parent's console for the new process instead of having it create a new console. It is the opposite of using a
			/// CREATE_NEW_CONSOLE flag with CreateProcess.
			/// </summary>
			SEE_MASK_NO_CONSOLE = 0x00008000,

			/// <summary>
			/// The execution can be performed on a background thread and the call should return immediately without waiting for the background thread to finish.
			/// Note that in certain cases ShellExecuteEx ignores this flag and waits for the process to finish before returning.
			/// </summary>
			SEE_MASK_ASYNCOK = 0x00100000,

			/// <summary>
			/// Use this flag when specifying a monitor on multi-monitor systems. The monitor is specified in the hMonitor member. This flag cannot be combined
			/// with SEE_MASK_ICON.
			/// </summary>
			SEE_MASK_HMONITOR = 0x00200000,

			/// <summary>
			/// Introduced in Windows XP. Do not perform a zone check. This flag allows ShellExecuteEx to bypass zone checking put into place by IAttachmentExecute.
			/// </summary>
			SEE_MASK_NOZONECHECKS = 0x00800000,

			/// <summary>Not used.</summary>
			SEE_MASK_NOQUERYCLASSSTORE = 0x01000000,

			/// <summary>
			/// After the new process is created, wait for the process to become idle before returning, with a one minute timeout. See WaitForInputIdle for more details.
			/// </summary>
			SEE_MASK_WAITFORINPUTIDLE = 0x02000000,

			/// <summary>
			/// Introduced in Windows XP. Keep track of the number of times this application has been launched. Applications with sufficiently high counts appear
			/// in the Start Menu's list of most frequently used programs.
			/// </summary>
			SEE_MASK_FLAG_LOG_USAGE = 0x04000000,

			/// <summary>
			/// The hInstApp member is used to specify the IUnknown of an object that implements IServiceProvider. This object will be used as a site pointer.
			/// The site pointer is used to provide services to the ShellExecute function, the handler binding process, and invoked verb handlers.
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
			/// <summary>Rename the file specified in pFrom. You cannot use this flag to rename multiple files with a single function call. Use FO_MOVE instead.</summary>
			FO_RENAME = 0x0004
		}

		/// <summary>The flags that specify the file information to retrieve from <see cref="SHGetFileInfo(string, FileAttributes, ref SHFILEINFO, int, SHGFI)"/>.</summary>
		[PInvokeData("Shellapi.h", MSDNShortId = "bb762179")]
		[Flags]
		public enum SHGFI
		{
			/// <summary>
			/// Retrieve the handle to the icon that represents the file and the index of the icon within the system image list. The handle is copied to the
			/// hIcon member of the structure specified by psfi, and the index is copied to the iIcon member.
			/// </summary>
			SHGFI_ICON = 0x000000100,

			/// <summary>
			/// Retrieve the display name for the file, which is the name as it appears in Windows Explorer. The name is copied to the szDisplayName member of
			/// the structure specified in psfi. The returned display name uses the long file name, if there is one, rather than the 8.3 form of the file name.
			/// Note that the display name can be affected by settings such as whether extensions are shown.
			/// </summary>
			SHGFI_DISPLAYNAME = 0x000000200,

			/// <summary>
			/// Retrieve the string that describes the file's type. The string is copied to the szTypeName member of the structure specified in psfi.
			/// </summary>
			SHGFI_TYPENAME = 0x000000400,

			/// <summary>
			/// Retrieve the item attributes. The attributes are copied to the dwAttributes member of the structure specified in the psfi parameter. These are
			/// the same attributes that are obtained from IShellFolder::GetAttributesOf.
			/// </summary>
			SHGFI_ATTRIBUTES = 0x000000800,

			/// <summary>
			/// Retrieve the name of the file that contains the icon representing the file specified by pszPath, as returned by the IExtractIcon::GetIconLocation
			/// method of the file's icon handler. Also retrieve the icon index within that file. The name of the file containing the icon is copied to the
			/// szDisplayName member of the structure specified by psfi. The icon's index is copied to that structure's iIcon member.
			/// </summary>
			SHGFI_ICONLOCATION = 0x000001000,

			/// <summary>
			/// Retrieve the type of the executable file if pszPath identifies an executable file. The information is packed into the return value. This flag
			/// cannot be specified with any other flags.
			/// </summary>
			SHGFI_EXETYPE = 0x000002000,

			/// <summary>
			/// Retrieve the index of a system image list icon. If successful, the index is copied to the iIcon member of psfi. The return value is a handle to
			/// the system image list. Only those images whose indices are successfully copied to iIcon are valid. Attempting to access other images in the
			/// system image list will result in undefined behavior.
			/// </summary>
			SHGFI_SYSICONINDEX = 0x000004000,

			/// <summary>Modify SHGFI_ICON, causing the function to add the link overlay to the file's icon. The SHGFI_ICON flag must also be set.</summary>
			SHGFI_LINKOVERLAY = 0x000008000,

			/// <summary>
			/// Modify SHGFI_ICON, causing the function to blend the file's icon with the system highlight color. The SHGFI_ICON flag must also be set.
			/// </summary>
			SHGFI_SELECTED = 0x000010000,

			/// <summary>
			/// Modify SHGFI_ATTRIBUTES to indicate that the dwAttributes member of the SHFILEINFO structure at psfi contains the specific attributes that are
			/// desired. These attributes are passed to IShellFolder::GetAttributesOf. If this flag is not specified, 0xFFFFFFFF is passed to
			/// IShellFolder::GetAttributesOf, requesting all attributes. This flag cannot be specified with the SHGFI_ICON flag.
			/// </summary>
			SHGFI_ATTR_SPECIFIED = 0x000020000,

			/// <summary>Modify SHGFI_ICON, causing the function to retrieve the file's large icon. The SHGFI_ICON flag must also be set.</summary>
			SHGFI_LARGEICON = 0x000000000,

			/// <summary>
			/// Modify SHGFI_ICON, causing the function to retrieve the file's small icon. Also used to modify SHGFI_SYSICONINDEX, causing the function to return
			/// the handle to the system image list that contains small icon images. The SHGFI_ICON and/or SHGFI_SYSICONINDEX flag must also be set.
			/// </summary>
			SHGFI_SMALLICON = 0x000000001,

			/// <summary>
			/// Modify SHGFI_ICON, causing the function to retrieve the file's open icon. Also used to modify SHGFI_SYSICONINDEX, causing the function to return
			/// the handle to the system image list that contains the file's small open icon. A container object displays an open icon to indicate that the
			/// container is open. The SHGFI_ICON and/or SHGFI_SYSICONINDEX flag must also be set.
			/// </summary>
			SHGFI_OPENICON = 0x000000002,

			/// <summary>
			/// Modify SHGFI_ICON, causing the function to retrieve a Shell-sized icon. If this flag is not specified the function sizes the icon according to
			/// the system metric values. The SHGFI_ICON flag must also be set.
			/// </summary>
			SHGFI_SHELLICONSIZE = 0x000000004,

			/// <summary>Indicate that pszPath is the address of an ITEMIDLIST structure rather than a path name.</summary>
			SHGFI_PIDL = 0x000000008,

			/// <summary>
			/// Indicates that the function should not attempt to access the file specified by pszPath. Rather, it should act as if the file specified by pszPath
			/// exists with the file attributes passed in dwFileAttributes. This flag cannot be combined with the SHGFI_ATTRIBUTES, SHGFI_EXETYPE, or SHGFI_PIDL flags.
			/// </summary>
			SHGFI_USEFILEATTRIBUTES = 0x000000010,

			/// <summary>Apply the appropriate overlays to the file's icon. The SHGFI_ICON flag must also be set.</summary>
			SHGFI_ADDOVERLAYS = 0x000000020,

			/// <summary>
			/// Return the index of the overlay icon. The value of the overlay index is returned in the upper eight bits of the iIcon member of the structure
			/// specified by psfi. This flag requires that the SHGFI_ICON be set as well.
			/// </summary>
			SHGFI_OVERLAYINDEX = 0x000000040
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-assoccreateforclasses
		// SHSTDAPI AssocCreateForClasses( const ASSOCIATIONELEMENT *rgClasses, ULONG cClasses, REFIID riid, void **ppv );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "43257507-dd5e-4622-8445-c132187fd1e5")]
		public static extern HRESULT AssocCreateForClasses([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ASSOCIATIONELEMENT[] rgClasses, uint cClasses, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

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
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-commandlinetoargvw
		// LPWSTR * CommandLineToArgvW( LPCWSTR lpCmdLine, int *pNumArgs );
		[DllImport(Lib.Shell32, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "9889a016-b7a5-402b-8305-6f7c199d41b3")]
		[return: MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)]
		public static extern string[] CommandLineToArgvW(string lpCmdLine, out int pNumArgs);

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
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-dragacceptfiles
		// void DragAcceptFiles( HWND hWnd, BOOL fAccept );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "1f16f6e4-7847-4bc7-adce-995876db24bd")]
		public static extern void DragAcceptFiles(HandleRef hWnd, [MarshalAs(UnmanagedType.Bool)] bool fAccept);

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
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-dragfinish
		// void DragFinish( HDROP hDrop );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "9b15e8a5-de68-4dcb-8e1a-0ee0393aa9db")]
		public static extern void DragFinish(IntPtr hDrop);

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
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-dragqueryfilea
		// UINT DragQueryFileA( HDROP hDrop, UINT iFile, LPSTR lpszFile, UINT cch );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "93fab381-9035-46c4-ba9d-efb2d0801d84")]
		public static extern uint DragQueryFile(IntPtr hDrop, uint iFile, string lpszFile, uint cch);

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
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-dragquerypoint
		// BOOL DragQueryPoint( HDROP hDrop, POINT *ppt );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "87794ab0-a075-4a1f-869f-5998bdc57a1d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DragQueryPoint(IntPtr hDrop, ref System.Drawing.Point ppt);

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
		// HICON DuplicateIcon( _Reserved_ HINSTANCE hInst, _In_ HICON hIcon);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb776411(v=vs.85).aspx
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Shellapi.h", MSDNShortId = "bb776411")]
		public static extern IntPtr DuplicateIcon(SafeLibraryHandle hInst, IntPtr hIcon);

		/// <summary>
		/// Gets a handle to an icon stored as a resource in a file or an icon stored in a file's associated executable file.
		/// </summary>
		/// <param name="hInst">A handle to the instance of the calling application.</param>
		/// <param name="lpIconPath">Pointer to a string that, on entry, specifies the full path and file name of the file that contains the icon. The function extracts the icon handle from that file, or from an executable file associated with that file.
		/// <para>When this function returns, if the icon handle was obtained from an executable file (either an executable file pointed to by lpIconPath or an associated executable file) the function stores the full path and file name of that executable in the buffer pointed to by this parameter.</para></param>
		/// <param name="lpiIcon">Pointer to a WORD value that, on entry, specifies the index of the icon whose handle is to be obtained.
		/// <para>When the function returns, if the icon handle was obtained from an executable file(either an executable file pointed to by lpIconPath or an associated executable file), this value points to the icon's index in that file.</para></param>
		/// <returns>If the function succeeds, the return value is an icon handle. If the icon is extracted from an associated executable file, the function stores the full path and file name of the executable file in the string pointed to by lpIconPath, and stores the icon's identifier in the WORD pointed to by lpiIcon.
		/// <para>If the function fails, the return value is NULL.</para></returns>
		// public static Icon ExtractAssociatedIcon( string filePath )
		// https://msdn.microsoft.com/en-us/library/system.drawing.icon.extractassociatedicon(v=vs.110).aspx
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Shellapi.h", MSDNShortId = "bb776414")]
		public static extern IntPtr ExtractAssociatedIcon(SafeLibraryHandle hInst, StringBuilder lpIconPath, ref ushort lpiIcon);

		/// <summary>
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
		/// <para>TBD</para>
		/// </param>
		/// <param name="piIconIndex">
		/// <para>TBD</para>
		/// </param>
		/// <param name="piIconId">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HICON</c></para>
		/// <para>Returns the icon's handle if successful, otherwise <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>The icon handle returned by this function must be released by calling DestroyIcon when it is no longer needed.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-extractassociatediconexa
		// HICON ExtractAssociatedIconExA( HINSTANCE hInst, LPSTR pszIconPath, WORD *piIconIndex, WORD *piIconId );
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shellapi.h", MSDNShortId = "f32260b0-917b-4406-aeee-34f71a7c7309")]
		public static extern IntPtr ExtractAssociatedIconEx(SafeLibraryHandle hInst, StringBuilder pszIconPath, ref ushort piIconIndex, ref ushort piIconId);

		/// <summary>
		/// <para>Gets a handle to an icon from the specified executable file, DLL, or icon file.</para>
		/// <para>To retrieve an array of handles to large or small icons, use the <c>ExtractIconEx</c> function.</para>
		/// </summary>
		/// <param name="hInst">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>Handle to the instance of the application that calls the function.</para>
		/// </param>
		/// <param name="lpszExeFileName">
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
		/// resource identifier is equal to the absolute value of nIconIndex. For example, you should use –3 to extract the icon whose
		/// resource identifier is 3. To extract the icon whose resource identifier is 1, use the <c>ExtractIconEx</c> function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HICON</c></para>
		/// <para>
		/// The return value is a handle to an icon. If the file specified was not an executable file, DLL, or icon file, the return is 1. If
		/// no icons were found in the file, the return value is <c>NULL</c>.
		/// </para>
		/// </returns>
		// HICON ExtractIcon( _Reserved_ HINSTANCE hInst, _In_ LPCTSTR lpszExeFileName, UINT nIconIndex);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb776416(v=vs.85).aspx
		[DllImport(Lib.Shell32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Shellapi.h", MSDNShortId = "bb776416")]
		public static extern IntPtr ExtractIcon(SafeLibraryHandle hInst, string lpszExeFileName, uint nIconIndex);

		/// <summary>
		/// The ExtractIconEx function creates an array of handles to large or small icons extracted from the specified executable file, DLL, or icon file.
		/// </summary>
		/// <param name="lpszFile">String that specifies the name of an executable file, DLL, or icon file from which icons will be extracted.</param>
		/// <param name="nIconIndex">Specifies the zero-based index of the first icon to extract. For example, if this value is zero, the function extracts the first icon in the specified file.
		/// <para>If this value is –1 and phiconLarge and phiconSmall are both NULL, the function returns the total number of icons in the specified file. If the file is an executable file or DLL, the return value is the number of RT_GROUP_ICON resources. If the file is an .ico file, the return value is 1.</para>
		/// <para>If this value is a negative number and either phiconLarge or phiconSmall is not NULL, the function begins by extracting the icon whose resource identifier is equal to the absolute value of nIconIndex. For example, use -3 to extract the icon whose resource identifier is 3.</para></param>
		/// <param name="phIconLarge">An array of icon handles that receives handles to the large icons extracted from the file. If this parameter is NULL, no large icons are extracted from the file.</param>
		/// <param name="phIconSmall">Array of icon handles that receives handles to the small icons extracted from the file. If this parameter is NULL, no small icons are extracted from the file.</param>
		/// <param name="nIcons">The number of icons to extract from the file.</param>
		/// <returns>If the nIconIndex parameter is -1, the phiconLarge parameter is NULL, and the phiconSmall parameter is NULL, then the return value is the number of icons contained in the specified file. Otherwise, the return value is the number of icons successfully extracted from the file.</returns>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto)]
		[PInvokeData("Shellapi.h", MSDNShortId = "ms648069")]
		public static extern int ExtractIconEx([MarshalAs(UnmanagedType.LPTStr)] string lpszFile, int nIconIndex,
			[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] IntPtr[] phIconLarge,
			[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] IntPtr[] phIconSmall, int nIcons);

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
		/// <para>Here, pszExecutableName is a pointer to a null-terminated string that specifies the name of the executable file, pszPath is a pointer to the null-terminated string buffer that receives the path to the executable file, and pcchOut is a pointer to a DWORD that specifies the number of characters in the pszPath buffer. When the function returns, pcchOut is set to the number of characters actually placed in the buffer. See AssocQueryString for more information.</para>
		/// <para>
		/// When <c>FindExecutable</c> returns, the parameter may contain the path to the Dynamic Data Exchange (DDE) server started if a
		/// server does not respond to a request to initiate a DDE conversation with the DDE client application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-findexecutablea
		// HINSTANCE FindExecutableA( LPCSTR lpFile, LPCSTR lpDirectory, LPSTR lpResult );
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-initnetworkaddresscontrol
		// BOOL InitNetworkAddressControl( );
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl/nf-shobjidl-shadddefaultpropertiesbyext
		// SHSTDAPI SHAddDefaultPropertiesByExt( PCWSTR pszExt, IPropertyStore *pPropStore );
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlobj_core/nf-shlobj_core-shaddfrompropsheetextarray
		// WINSHELLAPI UINT SHAddFromPropSheetExtArray( HPSXA hpsxa, LPFNADDPROPSHEETPAGE lpfnAddPage, LPARAM lParam );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shlobj_core.h", MSDNShortId = "e0570cd6-dda2-43e4-8540-58baef37bf18")]
		public static extern uint SHAddFromPropSheetExtArray(IntPtr hpsxa, AddPropSheetPageProc lpfnAddPage, IntPtr lParam);

		/// <summary>
		/// <para>
		/// [This function is available through Windows XP Service Pack 2 (SP2) and Windows Server 2003. It might be altered or unavailable
		/// in subsequent versions of Windows. Use
		/// </para>
		/// <para>CoTaskMemAlloc</para>
		/// <para>instead.]</para>
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
		// void * SHAlloc( SIZE_T cb );
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/nf-shellapi-shappbarmessage
		// UINT_PTR SHAppBarMessage( DWORD dwMessage, PAPPBARDATA pData );
		[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shellapi.h", MSDNShortId = "173d6eff-b33b-4d7d-bedd-5ebfb1e45954")]
		public static extern UIntPtr SHAppBarMessage(ABM dwMessage, ref APPBARDATA pData);

		/// <summary>
		/// Performs an operation on a specified file.
		/// </summary>
		/// <param name="lpExecInfo">A pointer to a SHELLEXECUTEINFO structure that contains and receives information about the application being executed.</param>
		/// <returns>Returns TRUE if successful; otherwise, FALSE. Call GetLastError for extended error information.</returns>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Shellapi.h", MSDNShortId = "bb762154")]
		public static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

		/// <summary>Copies, moves, renames, or deletes a file system object. This function has been replaced in Windows Vista by <see cref="IFileOperation"/>.</summary>
		/// <param name="lpFileOp">A pointer to an SHFILEOPSTRUCT structure that contains information this function needs to carry out the specified operation. This parameter must contain a valid value that is not NULL. You are responsible for validating the value. If you do not validate it, you will experience unexpected results.</param>
		/// <returns>Returns zero if successful; otherwise nonzero. Applications normally should simply check for zero or nonzero.</returns>
		[PInvokeData("Shellapi.h")]
		[DllImport("shell32.dll", CharSet = CharSet.Auto)]
		public static extern int SHFileOperation([In] ref SHFILEOPSTRUCT lpFileOp);

		/// <summary>
		/// Retrieves information about an object in the file system, such as a file, folder, directory, or drive root.
		/// </summary>
		/// <param name="pszPath">A pointer to a null-terminated string of maximum length MAX_PATH that contains the path and file name. Both absolute and relative paths are valid.
		/// <para>If the uFlags parameter includes the SHGFI_PIDL flag, this parameter must be the address of an ITEMIDLIST (PIDL) structure that contains the list of item identifiers that uniquely identifies the file within the Shell's namespace. The PIDL must be a fully qualified PIDL. Relative PIDLs are not allowed.</para>
		/// <para>If the uFlags parameter includes the SHGFI_USEFILEATTRIBUTES flag, this parameter does not have to be a valid file name. The function will proceed as if the file exists with the specified name and with the file attributes passed in the dwFileAttributes parameter. This allows you to obtain information about a file type by passing just the extension for pszPath and passing FILE_ATTRIBUTE_NORMAL in dwFileAttributes.</para>
		/// <para>This string can use either short (the 8.3 form) or long file names.</para></param>
		/// <param name="dwFileAttributes">A combination of one or more file attribute flags (FILE_ATTRIBUTE_ values as defined in Winnt.h). If uFlags does not include the SHGFI_USEFILEATTRIBUTES flag, this parameter is ignored.</param>
		/// <param name="psfi">Pointer to a SHFILEINFO structure to receive the file information.</param>
		/// <param name="cbFileInfo">The size, in bytes, of the SHFILEINFO structure pointed to by the psfi parameter.</param>
		/// <param name="uFlags">The flags that specify the file information to retrieve.</param>
		/// <returns>Returns a value whose meaning depends on the uFlags parameter.
		/// <para>If uFlags does not contain SHGFI_EXETYPE or SHGFI_SYSICONINDEX, the return value is nonzero if successful, or zero otherwise.</para>
		/// <para>If uFlags contains the SHGFI_EXETYPE flag, the return value specifies the type of the executable file. It will be one of the following values.</para></returns>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("Shellapi.h", MSDNShortId = "bb762179")]
		public static extern IntPtr SHGetFileInfo(string pszPath, FileAttributes dwFileAttributes, ref SHFILEINFO psfi,
			int cbFileInfo, SHGFI uFlags);

		/// <summary>
		/// Retrieves information about an object in the file system, such as a file, folder, directory, or drive root.
		/// </summary>
		/// <param name="itemIdList">A pointer to a null-terminated string of maximum length MAX_PATH that contains the path and file name. Both absolute and relative paths are valid.
		/// <para>If the uFlags parameter includes the SHGFI_PIDL flag, this parameter must be the address of an ITEMIDLIST (PIDL) structure that contains the list of item identifiers that uniquely identifies the file within the Shell's namespace. The PIDL must be a fully qualified PIDL. Relative PIDLs are not allowed.</para>
		/// <para>If the uFlags parameter includes the SHGFI_USEFILEATTRIBUTES flag, this parameter does not have to be a valid file name. The function will proceed as if the file exists with the specified name and with the file attributes passed in the dwFileAttributes parameter. This allows you to obtain information about a file type by passing just the extension for pszPath and passing FILE_ATTRIBUTE_NORMAL in dwFileAttributes.</para>
		/// <para>This string can use either short (the 8.3 form) or long file names.</para></param>
		/// <param name="dwFileAttributes">A combination of one or more file attribute flags (FILE_ATTRIBUTE_ values as defined in Winnt.h). If uFlags does not include the SHGFI_USEFILEATTRIBUTES flag, this parameter is ignored.</param>
		/// <param name="psfi">Pointer to a SHFILEINFO structure to receive the file information.</param>
		/// <param name="cbFileInfo">The size, in bytes, of the SHFILEINFO structure pointed to by the psfi parameter.</param>
		/// <param name="uFlags">The flags that specify the file information to retrieve.</param>
		/// <returns>Returns a value whose meaning depends on the uFlags parameter.
		/// <para>If uFlags does not contain SHGFI_EXETYPE or SHGFI_SYSICONINDEX, the return value is nonzero if successful, or zero otherwise.</para>
		/// <para>If uFlags contains the SHGFI_EXETYPE flag, the return value specifies the type of the executable file. It will be one of the following values.</para></returns>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("Shellapi.h", MSDNShortId = "bb762179")]
		public static extern IntPtr SHGetFileInfo(PIDL itemIdList, FileAttributes dwFileAttributes, ref SHFILEINFO psfi,
			int cbFileInfo, SHGFI uFlags);

		/// <summary>
		/// <para>Contains information about a system appbar message.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shellapi/ns-shellapi-_appbardata typedef struct _AppBarData { DWORD cbSize;
		// HWND hWnd; UINT uCallbackMessage; UINT uEdge; RECT rc; LPARAM lParam; } APPBARDATA, *PAPPBARDATA;
		[PInvokeData("shellapi.h", MSDNShortId = "cf86fe15-4beb-49b7-b73e-2ad61cedc3f8")]
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
			public IntPtr hWnd;
			/// <summary>
			/// <para>Type: <c>LPARAM</c></para>
			/// <para>A message-dependent value. This member is used with these messages:</para>
			/// <para>ABM_SETAUTOHIDEBAR</para>
			/// <para>ABM_SETAUTOHIDEBAREX</para>
			/// <para>ABM_SETSTATE</para>
			/// <para>See the individual message pages for details.</para>
			/// </summary>
			public IntPtr lParam;

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
			public IntPtr hkClass;
			/// <summary>A pointer to the name of a class that contains association information.</summary>
			public string pszClass;
		}
		/// <summary>
		/// Contains information used by ShellExecuteEx.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Shellapi.h", MSDNShortId = "bb759784")]
		public struct SHELLEXECUTEINFO
		{
			/// <summary>
			/// Required. The size of this structure, in bytes.
			/// </summary>
			public int cbSize;

			/// <summary>
			/// Flags that indicate the content and validity of the other structure members.
			/// </summary>
			public ShellExecuteMaskFlags fMask;

			/// <summary>
			/// Optional. A handle to the parent window, used to display any message boxes that the system might produce while executing this function. This value can be NULL.
			/// </summary>
			public IntPtr hwnd;

			/// <summary>
			/// A string, referred to as a verb, that specifies the action to be performed. The set of available verbs depends on the particular file or folder. Generally, the actions available from an object's shortcut menu are available verbs. This parameter can be NULL, in which case the default verb is used if available. If not, the "open" verb is used. If neither verb is available, the system uses the first verb listed in the registry. The following verbs are commonly used:
			/// <list>
			/// <item><term>edit</term><definition>Launches an editor and opens the document for editing.If lpFile is not a document file, the function will fail.</definition></item>
			/// <item><term>explore</term><definition>Explores the folder specified by lpFile.</definition></item>
			/// <item><term>find</term><definition>Initiates a search starting from the specified directory.</definition></item>
			/// <item><term>open</term><definition>Opens the file specified by the lpFile parameter. The file can be an executable file, a document file, or a folder.</definition></item>
			/// <item><term>print</term><definition>Prints the document file specified by lpFile.If lpFile is not a document file, the function will fail.</definition></item>
			/// <item><term>properties</term><definition>Displays the file or folder's properties.</definition></item>
			/// </list>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpVerb;

			/// <summary>
			/// The address of a null-terminated string that specifies the name of the file or object on which ShellExecuteEx will perform the action specified by the lpVerb parameter. The system registry verbs that are supported by the ShellExecuteEx function include "open" for executable files and document files and "print" for document files for which a print handler has been registered. Other applications might have added Shell verbs through the system registry, such as "play" for .avi and .wav files. To specify a Shell namespace object, pass the fully qualified parse name and set the SEE_MASK_INVOKEIDLIST flag in the fMask parameter.
			/// <note>If the SEE_MASK_INVOKEIDLIST flag is set, you can use either lpFile or lpIDList to identify the item by its file system path or its PIDL respectively. One of the two values—lpFile or lpIDList—must be set.</note>
			/// <note>If the path is not included with the name, the current directory is assumed.</note>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpFile;

			/// <summary>
			/// Optional. The address of a null-terminated string that contains the application parameters. The parameters must be separated by spaces. If the lpFile member specifies a document file, lpParameters should be NULL.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpParameters;

			/// <summary>
			/// Optional. The address of a null-terminated string that specifies the name of the working directory. If this member is NULL, the current directory is used as the working directory.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpDirectory;

			/// <summary>
			/// Required. Flags that specify how an application is to be shown when it is opened; one of the SW_ values listed for the ShellExecute function. If lpFile specifies a document file, the flag is simply passed to the associated application. It is up to the application to decide how to handle it.
			/// </summary>
			public ShowWindowCommand nShellExecuteShow;

			/// <summary>
			/// [out] If SEE_MASK_NOCLOSEPROCESS is set and the ShellExecuteEx call succeeds, it sets this member to a value greater than 32. If the function fails, it is set to an SE_ERR_XXX error value that indicates the cause of the failure. Although hInstApp is declared as an HINSTANCE for compatibility with 16-bit Windows applications, it is not a true HINSTANCE. It can be cast only to an int and compared to either 32 or the following SE_ERR_XXX error codes.
			/// </summary>
			public IntPtr hInstApp;

			/// <summary>
			/// The address of an absolute ITEMIDLIST structure (PCIDLIST_ABSOLUTE) to contain an item identifier list that uniquely identifies the file to execute. This member is ignored if the fMask member does not include SEE_MASK_IDLIST or SEE_MASK_INVOKEIDLIST.
			/// </summary>
			public IntPtr lpIDList;

			/// <summary>
			/// The address of a null-terminated string that specifies one of the following:
			/// <list type="bullet">
			/// <item><term>A ProgId. For example, "Paint.Picture".</term></item>
			/// <item><term>A URI protocol scheme. For example, "http".</term></item>
			/// <item><term>A file extension. For example, ".txt".</term></item>
			/// <item><term>A registry path under HKEY_CLASSES_ROOT that names a subkey that contains one or more Shell verbs. This key will have a subkey that conforms to the Shell verb registry schema, such as <c>shell\verb name</c>.</term></item>
			/// </list>
			/// <para>This member is ignored if fMask does not include SEE_MASK_CLASSNAME.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpClass;

			/// <summary>
			/// A handle to the registry key for the file type. The access rights for this registry key should be set to KEY_READ. This member is ignored if fMask does not include SEE_MASK_CLASSKEY.
			/// </summary>
			public IntPtr hkeyClass;

			/// <summary>
			/// A keyboard shortcut to associate with the application. The low-order word is the virtual key code, and the high-order word is a modifier flag (HOTKEYF_). For a list of modifier flags, see the description of the WM_SETHOTKEY message. This member is ignored if fMask does not include SEE_MASK_HOTKEY.
			/// </summary>
			public uint dwHotKey;

			/// <summary>
			/// A handle to the icon for the file type. This member is ignored if fMask does not include SEE_MASK_ICON. This value is used only in Windows XP and earlier. It is ignored as of Windows Vista.
			/// <para><c>OR</c></para>
			/// <para>A handle to the monitor upon which the document is to be displayed. This member is ignored if fMask does not include SEE_MASK_HMONITOR.</para>
			/// </summary>
			public IntPtr hIcon;

			/// <summary>
			/// A handle to the newly started application. This member is set on return and is always NULL unless fMask is set to SEE_MASK_NOCLOSEPROCESS. Even if fMask is set to SEE_MASK_NOCLOSEPROCESS, hProcess will be NULL if no process was launched. For example, if a document to be launched is a URL and an instance of Internet Explorer is already running, it will display the document. No new process is launched, and hProcess will be NULL.
			/// <note>ShellExecuteEx does not always return an hProcess, even if a process is launched as the result of the call. For example, an hProcess does not return when you use SEE_MASK_INVOKEIDLIST to invoke IContextMenu.</note>
			/// </summary>
			public IntPtr hProcess;

			/// <summary>
			/// Initializes a new instance of the <see cref="SHELLEXECUTEINFO"/> struct.
			/// </summary>
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
			/// A handle to the icon that represents the file. You are responsible for destroying this handle with DestroyIcon when you no longer need it.
			/// </summary>
			public IntPtr hIcon;

			/// <summary>The index of the icon image within the system image list.</summary>
			public int iIcon;

			/// <summary>
			/// An array of values that indicates the attributes of the file object. For information about these values, see the IShellFolder::GetAttributesOf method.
			/// </summary>
			public int dwAttributes;

			/// <summary>
			/// A string that contains the name of the file as it appears in the Windows Shell, or the path and file name of the file that contains the icon
			/// representing the file.
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
			public IntPtr hwnd;
			/// <summary>A value that indicates which operation to perform.</summary>
			public ShellFileOperation wFunc;
			/// <summary><note type="note">This string must be double-null terminated.</note>
			/// <para>A pointer to one or more source file names.These names should be fully qualified paths to prevent unexpected results.</para>
			/// <para>Standard MS-DOS wildcard characters, such as "*", are permitted only in the file-name position.Using a wildcard character elsewhere in the string will lead to unpredictable results.</para>
			/// <para>Although this member is declared as a single null-terminated string, it is actually a buffer that can hold multiple null-delimited file names.Each file name is terminated by a single NULL character. The last file name is terminated with a double NULL character ("\0\0") to indicate the end of the buffer.</para></summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pFrom;
			/// <summary><note type="note">This string must be double-null terminated.</note>
			/// <para>A pointer to the destination file or directory name. This parameter must be set to NULL if it is not used. Wildcard characters are not allowed. Their use will lead to unpredictable results.</para>
			/// <para>Like pFrom, the pTo member is also a double-null terminated string and is handled in much the same way. However, pTo must meet the following specifications:</para>
			/// <list type="bullet">
			/// <item><description>Wildcard characters are not supported.</description></item>
			/// <item><description>Copy and Move operations can specify destination directories that do not exist. In those cases, the system attempts to create them and normally displays a dialog box to ask the user if they want to create the new directory. To suppress this dialog box and have the directories created silently, set the FOF_NOCONFIRMMKDIR flag in fFlags.</description></item>
			/// <item><description>For Copy and Move operations, the buffer can contain multiple destination file names if the fFlags member specifies FOF_MULTIDESTFILES.</description></item>
			/// <item><description>Pack multiple names into the pTo string in the same way as for pFrom.</description></item>
			/// <item><description>Use fully qualified paths. Using relative paths is not prohibited, but can have unpredictable results.</description></item>
			/// </list></summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pTo;
			/// <summary>Flags that control the file operation.</summary>
			public FILEOP_FLAGS fFlags;
			/// <summary>When the function returns, this member contains TRUE if any file operations were aborted before they were completed; otherwise, FALSE. An operation can be manually aborted by the user through UI or it can be silently aborted by the system if the FOF_NOERRORUI or FOF_NOCONFIRMATION flags were set.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fAnyOperationsAborted;
			/// <summary>When the function returns, this member contains a handle to a name mapping object that contains the old and new names of the renamed files. This member is used only if the fFlags member includes the FOF_WANTMAPPINGHANDLE flag. See Remarks for more details.</summary>
			public IntPtr hNameMappings;
			/// <summary>A pointer to the title of a progress dialog box. This is a null-terminated string. This member is used only if fFlags includes the FOF_SIMPLEPROGRESS flag.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszProgressTitle;
		}
	}
}