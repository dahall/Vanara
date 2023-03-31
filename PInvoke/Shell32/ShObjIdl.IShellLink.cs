using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Specifies option settings. Used with IShellLinkDataList::GetFlags and IShellLinkDataList::SetFlags.</summary>
	[PInvokeData("Shlobj.h", MSDNShortId = "bb762540")]
	[Flags]
	public enum SHELL_LINK_DATA_FLAGS : uint
	{
		/// <summary>Default value used when no other flag is explicitly set.</summary>
		SLDF_DEFAULT = 0x00000000,

		/// <summary>The Shell link was saved with an ID list.</summary>
		SLDF_HAS_ID_LIST = 0x00000001,

		/// <summary>
		/// The Shell link was saved with link information to enable distributed tracking. This information is used by .lnk files to
		/// locate the target if the targets's path has changed. It includes information such as volume label and serial number, although
		/// the specific stored information can change from release to release.
		/// </summary>
		SLDF_HAS_LINK_INFO = 0x00000002,

		/// <summary>The link has a name.</summary>
		SLDF_HAS_NAME = 0x00000004,

		/// <summary>The link has a relative path.</summary>
		SLDF_HAS_RELPATH = 0x00000008,

		/// <summary>The link has a working directory.</summary>
		SLDF_HAS_WORKINGDIR = 0x00000010,

		/// <summary>The link has arguments.</summary>
		SLDF_HAS_ARGS = 0x00000020,

		/// <summary>The link has an icon location.</summary>
		SLDF_HAS_ICONLOCATION = 0x00000040,

		/// <summary>Stored strings are Unicode.</summary>
		SLDF_UNICODE = 0x00000080,

		/// <summary>
		/// Prevents the storage of link tracking information. If this flag is set, it is less likely, though not impossible, that a
		/// target can be found by the link if that target is moved.
		/// </summary>
		SLDF_FORCE_NO_LINKINFO = 0x00000100,

		/// <summary>The link contains expandable environment strings such as %windir%.</summary>
		SLDF_HAS_EXP_SZ = 0x00000200,

		/// <summary>Causes a 16-bit target application to run in a separate Virtual DOS Machine (VDM)/Windows on Windows (WOW).</summary>
		SLDF_RUN_IN_SEPARATE = 0x00000400,

		/// <summary>Not supported. Note that as of Windows Vista, this value is no longer defined.</summary>
		SLDF_HAS_LOGO3ID = 0x00000800,

		/// <summary>The link is a special Windows Installer link.</summary>
		SLDF_HAS_DARWINID = 0x00001000,

		/// <summary>Causes the target application to run as a different user.</summary>
		SLDF_RUNAS_USER = 0x00002000,

		/// <summary>The icon path in the link contains an expandable environment string such as such as %windir%.</summary>
		SLDF_HAS_EXP_ICON_SZ = 0x00004000,

		/// <summary>Prevents the use of ID list alias mapping when parsing the ID list from the path.</summary>
		SLDF_NO_PIDL_ALIAS = 0x00008000,

		/// <summary>Forces the use of the UNC name (a full network resource name), rather than the local name.</summary>
		SLDF_FORCE_UNCNAME = 0x00010000,

		/// <summary>
		/// Causes the target of this link to launch with a shim layer active. A shim is an intermediate DLL that facilitates
		/// compatibility between otherwise incompatible software services. Shims are typically used to provide version compatibility.
		/// </summary>
		SLDF_RUN_WITH_SHIMLAYER = 0x00020000,

		/// <summary>Introduced in Windows Vista. Disable object ID distributed tracking information.</summary>
		SLDF_FORCE_NO_LINKTRACK = 0x00040000,

		/// <summary>Introduced in Windows Vista. Enable the caching of target metadata into the link file.</summary>
		SLDF_ENABLE_TARGET_METADATA = 0x000800000,

		/// <summary>Introduced in Windows 7. Disable shell link tracking.</summary>
		SLDF_DISABLE_LINK_PATH_TRACKING = 0x00100000,

		/// <summary>Introduced in Windows Vista. Disable known folder tracking information.</summary>
		SLDF_DISABLE_KNOWNFOLDER_RELATIVE_TRACKING = 0x00200000,

		/// <summary>Introduced in Windows 7. Disable known folder alias mapping when loading the IDList during deserialization.</summary>
		SLDF_NO_KF_ALIAS = 0x00400000,

		/// <summary>Introduced in Windows 7. Allow link to point to another shell link as long as this does not create cycles.</summary>
		SLDF_ALLOW_LINK_TO_LINK = 0x00800000,

		/// <summary>Introduced in Windows 7. Remove alias when saving the IDList.</summary>
		SLDF_UNALIAS_ON_SAVE = 0x01000000,

		/// <summary>
		/// Introduced in Windows 7. Recalculate the IDList from the path with the environmental variables at load time, rather than
		/// persisting the IDList.
		/// </summary>
		SLDF_PREFER_ENVIRONMENT_PATH = 0x02000000,

		/// <summary>
		/// Introduced in Windows 7. If the target is a UNC location on a local machine, keep the local IDList target in addition to the
		/// remote target.
		/// </summary>
		SLDF_KEEP_LOCAL_IDLIST_FOR_UNC_TARGET = 0x04000000,

		/// <summary>
		/// Introduced in Windows 8. Persist the target IDlist in its volume-ID-relative form to avoid a dependency on drive letters.
		/// </summary>
		SLDF_PERSIST_VOLUME_ID_RELATIVE = 0x08000000,
	}

	/// <summary>Defines which data block is supported.</summary>
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb774916")]
	public enum ShellDataBlockSignature : uint
	{
		/// <summary>The target name.</summary>
		EXP_SZ_LINK_SIG = 0xA0000001,

		/// <summary>Console properties</summary>
		NT_CONSOLE_PROPS_SIG = 0xA0000002,

		/// <summary>The console's code page.</summary>
		NT_FE_CONSOLE_PROPS_SIG = 0xA0000004,

		/// <summary>Special folder information.</summary>
		EXP_SPECIAL_FOLDER_SIG = 0xA0000005,

		/// <summary>The link's Windows Installer ID.</summary>
		EXP_DARWIN_ID_SIG = 0xA0000006,

		/// <summary>The icon path.</summary>
		EXP_SZ_ICON_SIG = 0xA0000007,

		/// <summary>Stores information about the Shell link state.</summary>
		EXP_PROPERTYSTORAGE_SIG = 0xA0000009,
	}

	/// <summary>Action flags.</summary>
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb774952")]
	[Flags]
	public enum SLR_FLAGS
	{
		/// <summary>No action.</summary>
		SLR_NONE = 0,

		/// <summary>
		/// Do not display a dialog box if the link cannot be resolved. When SLR_NO_UI is set, the high-order word of fFlags can be set
		/// to a time-out value that specifies the maximum amount of time to be spent resolving the link. The function returns if the
		/// link cannot be resolved within the time-out duration. If the high-order word is set to zero, the time-out duration will be
		/// set to the default value of 3,000 milliseconds (3 seconds). To specify a value, set the high word of fFlags to the desired
		/// time-out duration, in milliseconds.
		/// </summary>
		SLR_NO_UI = 0x1,

		/// <summary>Not used.</summary>
		SLR_ANY_MATCH = 0x2,

		/// <summary>
		/// If the link object has changed, update its path and list of identifiers. If SLR_UPDATE is set, you do not need to call
		/// IPersistFile::IsDirty to determine whether the link object has changed.
		/// </summary>
		SLR_UPDATE = 0x4,

		/// <summary>Do not update the link information.</summary>
		SLR_NOUPDATE = 0x8,

		/// <summary>Do not execute the search heuristics.</summary>
		SLR_NOSEARCH = 0x10,

		/// <summary>Do not use distributed link tracking.</summary>
		SLR_NOTRACK = 0x20,

		/// <summary>
		/// Disable distributed link tracking. By default, distributed link tracking tracks removable media across multiple devices based
		/// on the volume name. It also uses the UNC path to track remote file systems whose drive letter has changed. Setting
		/// SLR_NOLINKINFO disables both types of tracking.
		/// </summary>
		SLR_NOLINKINFO = 0x40,

		/// <summary>Call the Windows Installer.</summary>
		SLR_INVOKE_MSI = 0x80,

		/// <summary>Windows XP and later.</summary>
		SLR_NO_UI_WITH_MSG_PUMP = 0x101,

		/// <summary>
		/// Windows 7 and later. Offer the option to delete the shortcut when this method is unable to resolve it, even if the shortcut
		/// is not a shortcut to a file.
		/// </summary>
		SLR_OFFER_DELETE_WITHOUT_FILE = 0x200,

		/// <summary>
		/// Windows 7 and later. Report as dirty if the target is a known folder and the known folder was redirected. This only works if
		/// the original target path was a file system path or ID list and not an aliased known folder ID list.
		/// </summary>
		SLR_KNOWNFOLDER = 0x400,

		/// <summary>
		/// Windows 7 and later. Resolve the computer name in UNC targets that point to a local computer. This value is used with SLDF_KEEP_LOCAL_IDLIST_FOR_UNC_TARGET.
		/// </summary>
		SLR_MACHINE_IN_LOCAL_TARGET = 0x800,

		/// <summary>Windows 7 and later. Update the computer GUID and user SID if necessary.</summary>
		SLR_UPDATE_MACHINE_AND_SID = 0x1000,

		/// <summary></summary>
		SLR_NO_OBJECT_ID = 0x2000
	}

	/// <summary>
	/// Exposes a method that enables an application to request that a Shell folder object resolve a link for one of its items.
	/// </summary>
	/// <remarks>
	/// <para>Namespace extensions implement this object to support link resolution.</para>
	/// <para>This interface is not typically used by applications.</para>
	/// <para>
	/// With namespace extensions, shortcut objects (.lnk files) implement the essential functionality of IShellLink::Resolve by calling
	/// IResolveShellLink::ResolveShellLink. <c>IResolveShellLink</c> is exported by a link resolution object that is created on request
	/// by the Shell folder.
	/// </para>
	/// <para>To retrieve a pointer to a link resolution object's <c>IResolveShellLink</c> interface:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// For an object that is contained by a folder, call the folder's IShellFolder::GetUIObjectOf method and request an
	/// <c>IResolveShellLink</c> pointer (IID_IResolveShellLink).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// For the folder object itself, call the folder's IShellFolder::CreateViewObject method and request an <c>IResolveShellLink</c>
	/// pointer (IID_IResolveShellLink).
	/// </term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> Prior to Windows Vista this interface was declared in Shlobj.h.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iresolveshelllink
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IResolveShellLink")]
	[ComImport, Guid("5cd52983-9449-11d2-963a-00c04f79adf0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IResolveShellLink
	{
		/// <summary>Requests that a folder object resolve a Shell link.</summary>
		/// <param name="punkLink">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// Pointer to the object's IShellLink interface. This interface can then be queried to determine the contents of the link.
		/// </para>
		/// </param>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// Handle to the window that the Shell uses as the parent for a dialog box. The Shell displays the dialog box if it needs to
		/// prompt the user for more information while resolving the link.
		/// </para>
		/// </param>
		/// <param name="fFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Action flags. This parameter can be a combination of the following values.</para>
		/// <para>SLR_INVOKE_MSI</para>
		/// <para>Call the Windows Installer.</para>
		/// <para>SLR_NOLINKINFO</para>
		/// <para>
		/// Disable distributed link tracking. By default, distributed link tracking tracks removable media across multiple devices
		/// based on the volume name. It also uses the UNC path to track remote file systems whose drive letter has changed. Setting
		/// <c>SLR_NOLINKINFO</c> disables both types of tracking.
		/// </para>
		/// <para>SLR_NO_UI</para>
		/// <para>
		/// Do not display a dialog box if the link cannot be resolved. When <c>SLR_NO_UI</c> is set, the high-order word of fFlags
		/// specifies a time-out duration, in milliseconds. The function returns if the link cannot be resolved within the time-out
		/// duration. If the high-order word is set to zero, the time-out duration defaults to 3000 milliseconds (3 seconds).
		/// </para>
		/// <para>SLR_NOUPDATE</para>
		/// <para>Do not update the link information.</para>
		/// <para>SLR_NOSEARCH</para>
		/// <para>Do not execute the search heuristics.</para>
		/// <para>SLR_NOTRACK</para>
		/// <para>Do not use distributed link tracking.</para>
		/// <para>SLR_UPDATE</para>
		/// <para>
		/// If the link object has changed, update its path and list of identifiers. If <c>SLR_UPDATE</c> is set, you do not need to
		/// call IPersistFile::IsDirty to determine whether the link object has changed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>This method should attempt to find the target of a Shell link, even if the target has been moved or renamed.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iresolveshelllink-resolveshelllink
		// HRESULT ResolveShellLink( IUnknown *punkLink, HWND hwnd, DWORD fFlags );
		void ResolveShellLink([In] IShellLinkW punkLink, HWND hwnd, SLR_FLAGS fFlags);
	}

	/// <summary>
	/// Exposes methods that allow an application to attach extra data blocks to a Shell link. These methods add, copy, or remove data blocks.
	/// </summary>
	[SuppressUnmanagedCodeSecurity]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("45e2b4ae-b1c3-11d0-b92f-00a0c90312e1")]
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb774916")]
	public interface IShellLinkDataList
	{
		/// <summary>Adds a data block to a link.</summary>
		/// <param name="pDataBlock">The data block structure. For a list of supported structures, see IShellLinkDataList.</param>
		void AddDataBlock(IntPtr pDataBlock);

		/// <summary>Retrieves a copy of a link's data block.</summary>
		/// <param name="dwSig">
		/// The data block's signature. The signature value for a particular type of data block can be found in its structure reference.
		/// For a list of supported data block types and their associated structures, see IShellLinkDataList.
		/// </param>
		/// <returns>
		/// The address of a pointer to a copy of the data block structure. If IShellLinkDataList::CopyDataBlock returns a successful
		/// result, the calling application must free the memory when it is no longer needed by calling LocalFree.
		/// </returns>
		SafeLocalHandle CopyDataBlock(ShellDataBlockSignature dwSig);

		/// <summary>Removes a data block from a link.</summary>
		/// <param name="dwSig">
		/// The data block's signature. The signature value for a particular type of data block can be found in its structure reference.
		/// For a list of supported data block types and their associated structures, see IShellLinkDataList.
		/// </param>
		void RemoveDataBlock(ShellDataBlockSignature dwSig);

		/// <summary>Gets the current option settings.</summary>
		/// <returns>Pointer to one or more of the SHELL_LINK_DATA_FLAGS that indicate the current option settings.</returns>
		SHELL_LINK_DATA_FLAGS GetFlags();

		/// <summary>Sets the current option settings.</summary>
		/// <param name="dwFlags">One or more of the SHELL_LINK_DATA_FLAGS that indicate the option settings.</param>
		void SetFlags(SHELL_LINK_DATA_FLAGS dwFlags);
	}

	/// <summary>Exposes methods that create, modify, and resolve Shell links.</summary>
	[SuppressUnmanagedCodeSecurity]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214F9-0000-0000-C000-000000000046"), CoClass(typeof(CShellLinkW))]
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb774950")]
	public interface IShellLinkW
	{
		/// <summary>Gets the path and file name of the target of a Shell link object.</summary>
		/// <param name="pszFile">The address of a buffer that receives the path and file name of the target of the Shell link object.</param>
		/// <param name="cchMaxPath">
		/// The size, in characters, of the buffer pointed to by the pszFile parameter, including the terminating null character. The
		/// maximum path size that can be returned is MAX_PATH. This parameter is commonly set by calling ARRAYSIZE(pszFile). The
		/// ARRAYSIZE macro is defined in Winnt.h.
		/// </param>
		/// <param name="pfd">
		/// A pointer to a WIN32_FIND_DATA structure that receives information about the target of the Shell link object. If this
		/// parameter is NULL, then no additional information is returned.
		/// </param>
		/// <param name="fFlags">Flags that specify the type of path information to retrieve.</param>
		void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath,
			out WIN32_FIND_DATA pfd, SLGP fFlags);

		/// <summary>Gets the list of item identifiers for the target of a Shell link object.</summary>
		/// <returns>When this method returns, contains the address of a PIDL.</returns>
		PIDL GetIDList();

		/// <summary>Sets the pointer to an item identifier list (PIDL) for a Shell link object.</summary>
		/// <param name="pidl">The object's fully qualified PIDL.</param>
		void SetIDList(PIDL pidl);

		/// <summary>Gets the description string for a Shell link object.</summary>
		/// <param name="pszFile">A pointer to the buffer that receives the description string.</param>
		/// <param name="cchMaxName">The maximum number of characters to copy to the buffer pointed to by the pszName parameter.</param>
		void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxName);

		/// <summary>Sets the description for a Shell link object. The description can be any application-defined string.</summary>
		/// <param name="pszName">A pointer to a buffer containing the new description string.</param>
		void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

		/// <summary>Gets the name of the working directory for a Shell link object.</summary>
		/// <param name="pszDir">The address of a buffer that receives the name of the working directory.</param>
		/// <param name="cchMaxPath">
		/// The maximum number of characters to copy to the buffer pointed to by the pszDir parameter. The name of the working directory
		/// is truncated if it is longer than the maximum specified by this parameter.
		/// </param>
		void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);

		/// <summary>Sets the name of the working directory for a Shell link object.</summary>
		/// <param name="pszDir">The address of a buffer that contains the name of the new working directory.</param>
		void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

		/// <summary>Gets the command-line arguments associated with a Shell link object.</summary>
		/// <param name="pszArgs">A pointer to the buffer that, when this method returns successfully, receives the command-line arguments.</param>
		/// <param name="cchMaxPath">
		/// The maximum number of characters that can be copied to the buffer supplied by the pszArgs parameter. In the case of a Unicode
		/// string, there is no limitation on maximum string length. In the case of an ANSI string, the maximum length of the returned
		/// string varies depending on the version of Windows—MAX_PATH prior to Windows 2000 and INFOTIPSIZE (defined in Commctrl.h) in
		/// Windows 2000 and later.
		/// </param>
		void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);

		/// <summary>Sets the command-line arguments for a Shell link object.</summary>
		/// <param name="pszArgs">
		/// A pointer to a buffer that contains the new command-line arguments. In the case of a Unicode string, there is no limitation
		/// on maximum string length. In the case of an ANSI string, the maximum length of the returned string varies depending on the
		/// version of Windows—MAX_PATH prior to Windows 2000 and INFOTIPSIZE (defined in Commctrl.h) in Windows 2000 and later.
		/// </param>
		void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

		/// <summary>Gets the keyboard shortcut (hot key) for a Shell link object.</summary>
		/// <returns>
		/// <para>
		/// The address of the keyboard shortcut. The virtual key code is in the low-order byte, and the modifier flags are in the
		/// high-order byte. The modifier flags can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HOTKEYF_ALT</c> 0x04</term>
		/// <term>ALT key</term>
		/// </item>
		/// <item>
		/// <term><c>HOTKEYF_CONTROL</c> 0x02</term>
		/// <term>CTRL key</term>
		/// </item>
		/// <item>
		/// <term><c>HOTKEYF_EXT</c> 0x08</term>
		/// <term>Extended key</term>
		/// </item>
		/// <item>
		/// <term><c>HOTKEYF_SHIFT</c> 0x01</term>
		/// <term>SHIFT key</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-gethotkey
		// HRESULT GetHotkey( WORD *pwHotkey );
		ushort GetHotKey();

		/// <summary>Sets a keyboard shortcut (hot key) for a Shell link object.</summary>
		/// <param name="wHotKey">
		/// The new keyboard shortcut. The virtual key code is in the low-order byte, and the modifier flags are in the high-order byte.
		/// The modifier flags can be a combination of the values specified in the description of the IShellLink::GetHotkey method.
		/// </param>
		void SetHotKey(ushort wHotKey);

		/// <summary>Gets the show command for a Shell link object.</summary>
		/// <returns>
		/// A pointer to the command. The following commands are supported.
		/// <list>
		/// <item>
		/// <term>SW_SHOWNORMAL</term>
		/// <description>
		/// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and
		/// position. An application should specify this flag when displaying the window for the first time.
		/// </description>
		/// </item>
		/// <item>
		/// <term>SW_SHOWMAXIMIZED</term>
		/// <description>Activates the window and displays it as a maximized window.</description>
		/// </item>
		/// <item>
		/// <term>SW_SHOWMINIMIZED</term>
		/// <description>Activates the window and displays it as a minimized window.</description>
		/// </item>
		/// </list>
		/// </returns>
		ShowWindowCommand GetShowCmd();

		/// <summary>Sets the show command for a Shell link object. The show command sets the initial show state of the window.</summary>
		/// <param name="iShowCmd">
		/// SetShowCmd accepts one of the following ShowWindow commands.
		/// <list>
		/// <item>
		/// <term>SW_SHOWNORMAL</term>
		/// <description>
		/// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and
		/// position. An application should specify this flag when displaying the window for the first time.
		/// </description>
		/// </item>
		/// <item>
		/// <term>SW_SHOWMAXIMIZED</term>
		/// <description>Activates the window and displays it as a maximized window.</description>
		/// </item>
		/// <item>
		/// <term>SW_SHOWMINIMIZED</term>
		/// <description>Activates the window and displays it as a minimized window.</description>
		/// </item>
		/// </list>
		/// </param>
		void SetShowCmd(ShowWindowCommand iShowCmd);

		/// <summary>Gets the location (path and index) of the icon for a Shell link object.</summary>
		/// <param name="pszIconPath">The address of a buffer that receives the path of the file containing the icon.</param>
		/// <param name="cchIconPath">The maximum number of characters to copy to the buffer pointed to by the pszIconPath parameter.</param>
		/// <param name="piIcon">The address of a value that receives the index of the icon.</param>
		void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath,
			out int piIcon);

		/// <summary>Sets the location (path and index) of the icon for a Shell link object.</summary>
		/// <param name="pszIconPath">The address of a buffer to contain the path of the file containing the icon.</param>
		/// <param name="iIcon">The index of the icon.</param>
		void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);

		/// <summary>Sets the relative path to the Shell link object.</summary>
		/// <param name="pszPathRel">
		/// The address of a buffer that contains the fully-qualified path of the shortcut file, relative to which the shortcut
		/// resolution should be performed. It should be a file name, not a folder name.
		/// </param>
		/// <param name="dwReserved">Reserved. Set this parameter to zero.</param>
		void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, [Optional] uint dwReserved);

		/// <summary>Attempts to find the target of a Shell link, even if it has been moved or renamed.</summary>
		/// <param name="hwnd">
		/// A handle to the window that the Shell will use as the parent for a dialog box. The Shell displays the dialog box if it needs
		/// to prompt the user for more information while resolving a Shell link.
		/// </param>
		/// <param name="fFlags">Action flags.</param>
		void Resolve(HWND hwnd, SLR_FLAGS fFlags);

		/// <summary>Sets the path and file name for the target of a Shell link object.</summary>
		/// <param name="pszFile">The address of a buffer that contains the new path.</param>
		void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
	}

	/// <summary>Class interface for IShellLinkW.</summary>
	[ComImport, Guid("00021401-0000-0000-C000-000000000046"), ClassInterface(ClassInterfaceType.None)]
	public class CShellLinkW { }
}