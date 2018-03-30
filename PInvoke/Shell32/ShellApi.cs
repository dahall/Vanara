using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
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

		/// <summary>The flags that specify the file information to retrieve from <see cref="Vanara.SHGetFileInfo(string,System.IO.FileAttributes,ref SHFILEINFO,int,Vanara.PInvoke.SHGFI)"/>.</summary>
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
			/// Initializes a new instance of the <see cref="Vanara.PInvoke.SHELLEXECUTEINFO"/> struct.
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
			/// <para>Although this member is declared as a single null-terminated string, it is actually a buffer that can hold multiple null-delimited file names.Each file name is terminated by a single NULL character. The last file name is terminated with a double NULL character ("\0\0") to indicate the end of the buffer.</summary></para></summary>
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