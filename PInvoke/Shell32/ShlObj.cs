using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Kernel32;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable UnusedMethodReturnValue.Global

namespace Vanara.PInvoke
{
	[SuppressUnmanagedCodeSecurity]
	public static partial class Shell32
	{
		// Defined in wingdi.h
		private const int LF_FACESIZE = 32;

		/// <summary>Used for options in SHOpenFolderAndSelectItems.</summary>
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762232")]
		public enum OFASI : uint
		{
			/// <summary>No options.</summary>
			OFASI_NONE = 0,

			/// <summary>
			/// Select an item and put its name in edit mode. This flag can only be used when a single item is being selected. For multiple item selections, it
			/// is ignored.
			/// </summary>
			OFASI_EDIT = 1,

			/// <summary>
			/// Select the item or items on the desktop rather than in a Windows Explorer window. Note that if the desktop is obscured behind open windows, it
			/// will not be made visible.
			/// </summary>
			OFASI_OPENDESKTOP = 2
		}

		/// <summary>Flags that direct the handling of the item from which you're retrieving the info tip text. This value is commonly zero (QITIPF_DEFAULT).</summary>
		[PInvokeData("Shlobj.h", MSDNShortId = "bb761357")]
		public enum QITIP
		{
			/// <summary>No special handling.</summary>
			QITIPF_DEFAULT = 0x00000000,

			/// <summary>Provide the name of the item in ppwszTip rather than the info tip text.</summary>
			QITIPF_USENAME = 0x00000001,

			/// <summary>If the item is a shortcut, retrieve the info tip text of the shortcut rather than its target.</summary>
			QITIPF_LINKNOTARGET = 0x00000002,

			/// <summary>If the item is a shortcut, retrieve the info tip text of the shortcut's target.</summary>
			QITIPF_LINKUSETARGET = 0x00000004,

			/// <summary>Search the entire namespace for the information. This value can result in a delayed response time.</summary>
			QITIPF_USESLOWTIP = 0x00000008, // Flag says it's OK to take a long time generating tip

			/// <summary><c>Windows Vista and later.</c> Put the info tip on a single line.</summary>
			QITIPF_SINGLELINE = 0x00000010,
		}

		/// <summary>
		/// Indicates the interpretation of the data passed by SHAddToRecentDocs in its pv parameter to identify the item whose usage statistics are being tracked.
		/// </summary>
		[PInvokeData("Shlobj.h", MSDNShortId = "dd378453")]
		public enum SHARD
		{
			/// <summary>
			/// <c>Windows 7 and later.</c> The pv parameter points to a SHARDAPPIDINFO structure that pairs an IShellItem that identifies the item with an
			/// AppUserModelID that associates it with a particular process or application.
			/// </summary>
			SHARD_APPIDINFO = 4,

			/// <summary>
			/// <c>Windows 7 and later.</c> The pv parameter points to a SHARDAPPIDINFOIDLIST structure that pairs an absolute PIDL that identifies the item with
			/// an AppUserModelID that associates it with a particular process or application.
			/// </summary>
			SHARD_APPIDINFOIDLIST = 5,

			/// <summary>
			/// <c>Windows 7 and later.</c> The pv parameter points to a SHARDAPPIDINFOLINK structure that pairs an IShellLink that identifies the item with an
			/// AppUserModelID that associates it with a particular process or application.
			/// </summary>
			SHARD_APPIDINFOLINK = 7,

			/// <summary><c>Windows 7 and later.</c> The pv parameter is an interface pointer to an IShellLink object.</summary>
			SHARD_LINK = 6,

			/// <summary>The pv parameter points to a null-terminated ANSI string with the path and file name of the object.</summary>
			SHARD_PATHA = 2,

			/// <summary>The pv parameter points to a null-terminated Unicode string with the path and file name of the object.</summary>
			SHARD_PATHW = 3,

			/// <summary>The pv parameter points to a PIDL that identifies the document's file object. PIDLs that identify non-file objects are not accepted.</summary>
			SHARD_PIDL = 1,

			/// <summary><c>Windows 7 and later.</c> The pv parameter is an interface pointer to an IShellItem object.</summary>
			SHARD_SHELLITEM = 8
		}

		/// <summary>Events used in SHChangeNotify.</summary>
		[PInvokeData("Shlobj_core.h")]
		[Flags]
		public enum SHCNE : uint
		{
			/// <summary>
			/// The name of a nonfolder item has changed. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the
			/// previous PIDL or name of the item. dwItem2 contains the new PIDL or name of the item.
			/// </summary>
			SHCNE_RENAMEITEM = 0x00000001,
			/// <summary>
			/// A nonfolder item has been created. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the item that was
			/// created. dwItem2 is not used and should be NULL.
			/// </summary>
			SHCNE_CREATE = 0x00000002,
			/// <summary>
			/// A nonfolder item has been deleted. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the item that was
			/// deleted. dwItem2 is not used and should be NULL.
			/// </summary>
			SHCNE_DELETE = 0x00000004,
			/// <summary>
			/// A folder has been created. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the folder that was
			/// created. dwItem2 is not used and should be NULL.
			/// </summary>
			SHCNE_MKDIR = 0x00000008,
			/// <summary>
			/// A folder has been removed. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the folder that was
			/// removed. dwItem2 is not used and should be NULL.
			/// </summary>
			SHCNE_RMDIR = 0x00000010,
			/// <summary>
			/// Storage media has been inserted into a drive. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the
			/// root of the drive that contains the new media. dwItem2 is not used and should be NULL.
			/// </summary>
			SHCNE_MEDIAINSERTED = 0x00000020,
			/// <summary>
			/// Storage media has been removed from a drive. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the
			/// root of the drive from which the media was removed. dwItem2 is not used and should be NULL.
			/// </summary>
			SHCNE_MEDIAREMOVED = 0x00000040,
			/// <summary>
			/// A drive has been removed. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the root of the drive that
			/// was removed. dwItem2 is not used and should be NULL.
			/// </summary>
			SHCNE_DRIVEREMOVED = 0x00000080,
			/// <summary>
			/// A drive has been added. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the root of the drive that
			/// was added. dwItem2 is not used and should be NULL.
			/// </summary>
			SHCNE_DRIVEADD = 0x00000100,
			/// <summary>
			/// A folder on the local computer is being shared via the network. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags.
			/// dwItem1 contains the folder that is being shared. dwItem2 is not used and should be NULL.
			/// </summary>
			SHCNE_NETSHARE = 0x00000200,
			/// <summary>
			/// A folder on the local computer is no longer being shared via the network. SHCNF_IDLIST or SHCNF_PATH must be specified in
			/// uFlags. dwItem1 contains the folder that is no longer being shared. dwItem2 is not used and should be NULL.
			/// </summary>
			SHCNE_NETUNSHARE = 0x00000400,
			/// <summary>
			/// The attributes of an item or folder have changed. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains
			/// the item or folder that has changed. dwItem2 is not used and should be NULL.
			/// </summary>
			SHCNE_ATTRIBUTES = 0x00000800,
			/// <summary>
			/// The contents of an existing folder have changed, but the folder still exists and has not been renamed. SHCNF_IDLIST or
			/// SHCNF_PATH must be specified in uFlags. dwItem1 contains the folder that has changed. dwItem2 is not used and should be NULL.
			/// If a folder has been created, deleted, or renamed, use SHCNE_MKDIR, SHCNE_RMDIR, or SHCNE_RENAMEFOLDER, respectively.
			/// </summary>
			SHCNE_UPDATEDIR = 0x00001000,
			/// <summary>
			/// An existing item (a folder or a nonfolder) has changed, but the item still exists and has not been renamed. SHCNF_IDLIST or
			/// SHCNF_PATH must be specified in uFlags. dwItem1 contains the item that has changed. dwItem2 is not used and should be NULL.
			/// If a nonfolder item has been created, deleted, or renamed, use SHCNE_CREATE, SHCNE_DELETE, or SHCNE_RENAMEITEM, respectively, instead.
			/// </summary>
			SHCNE_UPDATEITEM = 0x00002000,
			/// <summary>
			/// The computer has disconnected from a server. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the
			/// server from which the computer was disconnected. dwItem2 is not used and should be NULL.
			/// </summary>
			SHCNE_SERVERDISCONNECT = 0x00004000,
			/// <summary>
			/// An image in the system image list has changed. SHCNF_DWORD must be specified in uFlags. dwItem2 contains the index in the
			/// system image list that has changed. dwItem1 is not used and should be NULL.
			/// </summary>
			SHCNE_UPDATEIMAGE = 0x00008000,
			/// <summary>
			/// A drive has been added. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the root of the drive that
			/// was added. dwItem2 is not used and should be NULL.
			/// </summary>
			SHCNE_DRIVEADDGUI = 0x00010000,
			/// <summary>
			/// The name of a folder has changed. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the previous PIDL
			/// or name of the folder. dwItem2 contains the new PIDL or name of the folder.
			/// </summary>
			SHCNE_RENAMEFOLDER = 0x00020000,
			/// <summary>
			/// The amount of free space on a drive has changed. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the
			/// root of the drive on which the free space changed. dwItem2 is not used and should be NULL.
			/// </summary>
			SHCNE_FREESPACE = 0x00040000,
			/// <summary>Not currently used.</summary>
			SHCNE_EXTENDED_EVENT = 0x04000000,
			/// <summary>
			/// A file type association has changed. SHCNF_IDLIST must be specified in the uFlags parameter. dwItem1 and dwItem2 are not used
			/// and must be NULL. This event should also be sent for registered protocols.
			/// </summary>
			SHCNE_ASSOCCHANGED = 0x08000000,
			/// <summary>All disk related events.</summary>
			SHCNE_DISKEVENTS = 0x0002381F,
			/// <summary>All global events.</summary>
			SHCNE_GLOBALEVENTS = 0x0C0581E0,
			/// <summary>All events.</summary>
			SHCNE_ALLEVENTS = 0x7FFFFFFF,
			/// <summary>
			/// The presence of this flag indicates that the event was generated by an interrupt. It is stripped out before the clients of
			/// SHCNNotify_ see it.
			/// </summary>
			SHCNE_INTERRUPT = 0x80000000,
		}

		/// <summary>Flags used in SHChangeNotify.</summary>
		[PInvokeData("Shlobj_core.h")]
		[Flags]
		public enum SHCNF : uint
		{
			/// <summary>
			/// dwItem1 and dwItem2 are the addresses of ITEMIDLIST structures that represent the item(s) affected by the change. Each
			/// ITEMIDLIST must be relative to the desktop folder.
			/// </summary>
			SHCNF_IDLIST = 0x0000,
			/// <summary>
			/// dwItem1 and dwItem2 are the addresses of null-terminated strings of maximum length MAX_PATH that contain the full path names
			/// of the items affected by the change.
			/// </summary>
			SHCNF_PATHA = 0x0001,
			/// <summary>
			/// dwItem1 and dwItem2 are the addresses of null-terminated strings that represent the friendly names of the printer(s) affected
			/// by the change.
			/// </summary>
			SHCNF_PRINTERA = 0x0002,
			/// <summary>The dwItem1 and dwItem2 parameters are DWORD values.</summary>
			SHCNF_DWORD = 0x0003,
			/// <summary>
			/// dwItem1 and dwItem2 are the addresses of null-terminated strings of maximum length MAX_PATH that contain the full path names
			/// of the items affected by the change.
			/// </summary>
			SHCNF_PATHW = 0x0005,
			/// <summary>
			/// dwItem1 and dwItem2 are the addresses of null-terminated strings that represent the friendly names of the printer(s) affected
			/// by the change.
			/// </summary>
			SHCNF_PRINTERW = 0x0006,
			/// <summary>Indicates that a type is defined.</summary>
			SHCNF_TYPE = 0x00FF,
			/// <summary>
			/// The function should not return until the notification has been delivered to all affected components. As this flag modifies
			/// other data-type flags, it cannot be used by itself.
			/// </summary>
			SHCNF_FLUSH = 0x1000,
			/// <summary>
			/// The function should begin delivering notifications to all affected components but should return as soon as the notification
			/// process has begun. As this flag modifies other data-type flags, it cannot by used by itself. This flag includes SHCNF_FLUSH.
			/// </summary>
			SHCNF_FLUSHNOWAIT = 0x3000,
			/// <summary>Notify clients registered for all children.</summary>
			SHCNF_NOTIFYRECURSIVE = 0x10000
		}

		/// <summary>Receives a value that determines what type the item is in <see cref="SHDESCRIPTIONID"/>.</summary>
		[PInvokeData("Shlobj_core.h", MSDNShortId = "bb759775")]
		public enum SHDID
		{
			/// <summary>The item is a registered item on the desktop.</summary>
			SHDID_ROOT_REGITEM = 1,

			/// <summary>The item is a file.</summary>
			SHDID_FS_FILE = 2,

			/// <summary>The item is a folder.</summary>
			SHDID_FS_DIRECTORY = 3,

			/// <summary>The item is an unidentified item in the file system.</summary>
			SHDID_FS_OTHER = 4,

			/// <summary>The item is a 3.5-inch floppy drive.</summary>
			SHDID_COMPUTER_DRIVE35 = 5,

			/// <summary>The item is a 5.25-inch floppy drive.</summary>
			SHDID_COMPUTER_DRIVE525 = 6,

			/// <summary>The item is a removable disk.</summary>
			SHDID_COMPUTER_REMOVABLE = 7,

			/// <summary>The item is a fixed hard disk.</summary>
			SHDID_COMPUTER_FIXED = 8,

			/// <summary>The item is a drive that is mapped to a network share.</summary>
			SHDID_COMPUTER_NETDRIVE = 9,

			/// <summary>The item is a CD-ROM drive.</summary>
			SHDID_COMPUTER_CDROM = 10,

			/// <summary>The item is a RAM disk.</summary>
			SHDID_COMPUTER_RAMDISK = 11,

			/// <summary>The item is an unidentified system device.</summary>
			SHDID_COMPUTER_OTHER = 12,

			/// <summary>The item is a network domain.</summary>
			SHDID_NET_DOMAIN = 13,

			/// <summary>The item is a network server.</summary>
			SHDID_NET_SERVER = 14,

			/// <summary>The item is a network share.</summary>
			SHDID_NET_SHARE = 15,

			/// <summary>Not currently used.</summary>
			SHDID_NET_RESTOFNET = 16,

			/// <summary>The item is an unidentified network resource.</summary>
			SHDID_NET_OTHER = 17,

			/// <summary>Windows XP and later. Not currently used.</summary>
			SHDID_COMPUTER_IMAGING = 18,

			/// <summary>Windows XP and later. Not currently used.</summary>
			SHDID_COMPUTER_AUDIO = 19,

			/// <summary>Windows XP and later. The item is the system shared documents folder.</summary>
			SHDID_COMPUTER_SHAREDDOCS = 20,

			/// <summary>Windows Vista and later. The item is a mobile device, such as a personal digital assistant (PDA).</summary>
			SHDID_MOBILE_DEVICE = 21,
		}

		/// <summary>The format in which the data is being requested.</summary>
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762174")]
		public enum SHGetDataFormat
		{
			/// <summary>Format used for file system objects. The pv parameter is the address of a WIN32_FIND_DATA structure.</summary>
			[CorrespondingType(typeof(WIN32_FIND_DATA), CorrepsondingAction.Get)]
			SHGDFIL_FINDDATA = 1,

			/// <summary>Format used for network resources. The pv parameter is the address of a NETRESOURCE structure.</summary>
			// TODO: Define NETRESOURCE (https://msdn.microsoft.com/en-us/library/windows/desktop/aa385353(v=vs.85).aspx)
			//[CorrespondingType(typeof(NETRESOURCE), CorrepsondingAction.Get)]
			SHGDFIL_NETRESOURCE = 2,

			/// <summary>Version 4.71. Format used for network resources. The pv parameter is the address of an SHDESCRIPTIONID structure.</summary>
			[CorrespondingType(typeof(SHDESCRIPTIONID), CorrepsondingAction.Get)]
			SHGDFIL_DESCRIPTIONID = 3
		}

		/// <summary>Flags used by <see cref="SHGetFolderPath"/>.</summary>
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762181")]
		public enum SHGFP
		{
			/// <summary>Retrieve the folder's current path.</summary>
			SHGFP_TYPE_CURRENT = 0,

			/// <summary>Retrieve the folder's default path.</summary>
			SHGFP_TYPE_DEFAULT = 1
		}

		/// <summary>Used by SHGetImageList.</summary>
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762185")]
		public enum SHIL
		{
			/// <summary>
			/// The image size is normally 32x32 pixels. However, if the Use large icons option is selected from the Effects section of the Appearance tab in
			/// Display Properties, the image is 48x48 pixels.
			/// </summary>
			SHIL_LARGE = 0,

			/// <summary>These images are the Shell standard small icon size of 16x16, but the size can be customized by the user.</summary>
			SHIL_SMALL = 1,

			/// <summary>These images are the Shell standard extra-large icon size. This is typically 48x48, but the size can be customized by the user.</summary>
			SHIL_EXTRALARGE = 2,

			/// <summary>These images are the size specified by GetSystemMetrics called with SM_CXSMICON and GetSystemMetrics called with SM_CYSMICON.</summary>
			SHIL_SYSSMALL = 3,

			/// <summary>Windows Vista and later. The image is normally 256x256 pixels.</summary>
			SHIL_JUMBO = 4,
		}

		/// <summary>
		/// CSIDL (constant special item ID list) values provide a unique system-independent way to identify special folders used frequently by applications, but
		/// which may not have the same name or location on any given system. For example, the system folder may be "C:\Windows" on one system and "C:\Winnt" on
		/// another. These constants are defined in Shlobj.h.
		/// </summary>
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762494")]
		internal enum CSIDL
		{
			CSIDL_ADMINTOOLS = 0x0030,
			CSIDL_CDBURN_AREA = 0x003b,
			CSIDL_COMMON_ADMINTOOLS = 0x002f,
			CSIDL_COMMON_DESKTOPDIRECTORY = 0x0019,
			CSIDL_COMMON_DOCUMENTS = 0x002e,
			CSIDL_COMMON_MUSIC = 0x0035,
			CSIDL_COMMON_OEM_LINKS = 0x003a,
			CSIDL_COMMON_PICTURES = 0x0036,
			CSIDL_COMMON_PROGRAMS = 0X0017,
			CSIDL_COMMON_STARTMENU = 0x0016,
			CSIDL_COMMON_STARTUP = 0x0018,
			CSIDL_COMMON_TEMPLATES = 0x002d,
			CSIDL_COMMON_VIDEO = 0x0037,
			CSIDL_FLAG_CREATE = 0x8000, // force folder creation in SHGetFolderPath
			CSIDL_FLAG_DONT_VERIFY = 0x4000, // return an unverified folder path
			CSIDL_FONTS = 0x0014, // windows\fonts
			CSIDL_MYVIDEO = 0x000e, // "My Videos" folder
			CSIDL_NETHOOD = 0x0013, // %APPDATA%\Microsoft\Windows\Network Shortcuts
			CSIDL_PRINTHOOD = 0x001b, // %APPDATA%\Microsoft\Windows\Printer Shortcuts
			CSIDL_PROFILE = 0x0028, // %USERPROFILE% (%SystemDrive%\Users\%USERNAME%)
			CSIDL_PROGRAM_FILES_COMMONX86 = 0x002c, // x86 Program Files\Common on RISC
			CSIDL_PROGRAM_FILESX86 = 0x002a, // x86 C:\Program Files on RISC
			CSIDL_RESOURCES = 0x0038, // %windir%\Resources
			CSIDL_RESOURCES_LOCALIZED = 0x0039, // %windir%\resources\0409 (code page)
			CSIDL_SYSTEMX86 = 0x0029, // %windir%\system32
			CSIDL_WINDOWS = 0x0024, // GetWindowsDirectory()
		}

		/// <summary>
		/// Notifies the system that an item has been accessed, for the purposes of tracking those items used most recently and most frequently. This function
		/// can also be used to clear all usage data.
		/// </summary>
		/// <param name="uFlags">A value from the SHARD enumeration that indicates the form of the information pointed to by the pv parameter.</param>
		/// <param name="pv">
		/// A pointer to data that identifies the item that has been accessed. The item can be specified in this parameter in one of the following forms:
		/// <list type="bullet">
		/// <item><definition>A null-terminated string that contains the path and file name of the item.</definition></item>
		/// <item><definition>A PIDL that identifies the item's file object.</definition></item>
		/// <item>
		/// <definition>Windows 7 and later only. A SHARDAPPIDINFO, SHARDAPPIDINFOIDLIST, or SHARDAPPIDINFOLINK structure that identifies the item through an
		/// AppUserModelID. See Application User Model IDs (AppUserModelIDs) for more information.</definition>
		/// </item>
		/// <item><definition>Windows 7 and later only. An IShellLink object that identifies the item through a shortcut.</definition></item>
		/// </list>
		/// <para>Set this parameter to NULL to clear all usage data on all items.</para>
		/// </param>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762105")]
		public static extern void SHAddToRecentDocs(SHARD uFlags, IShellLinkW pv);

		/// <summary>
		/// Notifies the system that an item has been accessed, for the purposes of tracking those items used most recently and most frequently. This function
		/// can also be used to clear all usage data.
		/// </summary>
		/// <param name="uFlags">A value from the SHARD enumeration that indicates the form of the information pointed to by the pv parameter.</param>
		/// <param name="pv">
		/// A pointer to data that identifies the item that has been accessed. The item can be specified in this parameter in one of the following forms:
		/// <list type="bullet">
		/// <item><definition>A null-terminated string that contains the path and file name of the item.</definition></item>
		/// <item><definition>A PIDL that identifies the item's file object.</definition></item>
		/// <item>
		/// <definition>Windows 7 and later only. A SHARDAPPIDINFO, SHARDAPPIDINFOIDLIST, or SHARDAPPIDINFOLINK structure that identifies the item through an
		/// AppUserModelID. See Application User Model IDs (AppUserModelIDs) for more information.</definition>
		/// </item>
		/// <item><definition>Windows 7 and later only. An IShellLink object that identifies the item through a shortcut.</definition></item>
		/// </list>
		/// <para>Set this parameter to NULL to clear all usage data on all items.</para>
		/// </param>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762105")]
		public static extern void SHAddToRecentDocs(SHARD uFlags, [MarshalAs(UnmanagedType.LPWStr)] string pv);

		/// <summary>
		/// Notifies the system that an item has been accessed, for the purposes of tracking those items used most recently and most frequently. This function
		/// can also be used to clear all usage data.
		/// </summary>
		/// <param name="uFlags">A value from the SHARD enumeration that indicates the form of the information pointed to by the pv parameter.</param>
		/// <param name="pv">
		/// A pointer to data that identifies the item that has been accessed. The item can be specified in this parameter in one of the following forms:
		/// <list type="bullet">
		/// <item><definition>A null-terminated string that contains the path and file name of the item.</definition></item>
		/// <item><definition>A PIDL that identifies the item's file object.</definition></item>
		/// <item>
		/// <definition>Windows 7 and later only. A SHARDAPPIDINFO, SHARDAPPIDINFOIDLIST, or SHARDAPPIDINFOLINK structure that identifies the item through an
		/// AppUserModelID. See Application User Model IDs (AppUserModelIDs) for more information.</definition>
		/// </item>
		/// <item><definition>Windows 7 and later only. An IShellLink object that identifies the item through a shortcut.</definition></item>
		/// </list>
		/// <para>Set this parameter to NULL to clear all usage data on all items.</para>
		/// </param>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762105")]
		public static extern void SHAddToRecentDocs(SHARD uFlags, PIDL pv);

		/// <summary>Displays a dialog box that enables the user to select a Shell folder.</summary>
		/// <param name="lpbi">A pointer to a BROWSEINFO structure that contains information used to display the dialog box.</param>
		/// <returns>
		/// Returns a PIDL that specifies the location of the selected folder relative to the root of the namespace. If the user chooses the Cancel button in the
		/// dialog box, the return value is NULL.
		/// </returns>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762115")]
		public static extern PIDL SHBrowseForFolder(ref BROWSEINFO lpbi);

		/// <summary>
		/// Notifies the system of an event that an application has performed. An application should use this function if it performs an
		/// action that may affect the Shell.
		/// </summary>
		/// <param name="wEventId">
		/// Describes the event that has occurred. Typically, only one event is specified at a time. If more than one event is specified, the
		/// values contained in the dwItem1 and dwItem2 parameters must be the same, respectively, for all specified events.
		/// </param>
		/// <param name="uFlags">Flags that, when combined bitwise with SHCNF_TYPE, indicate the meaning of the dwItem1 and dwItem2 parameters.</param>
		/// <param name="dwItem1">Optional. First event-dependent value.</param>
		/// <param name="dwItem2">Optional. Second event-dependent value.</param>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shlobj.h")]
		public static extern void SHChangeNotify(SHCNE wEventId, SHCNF uFlags, [Optional] IntPtr dwItem1, [Optional] IntPtr dwItem2);

		/// <summary>Creates a new instance of the default Shell folder view object (DefView).</summary>
		/// <param name="pcsfv">Pointer to a SFV_CREATE structure that describes the particulars used in creating this instance of the Shell folder view object.</param>
		/// <param name="ppsv">When this function returns successfully, contains an interface pointer to the new IShellView object. On failure, this value is NULL.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto)]
		[PInvokeData("Shlobj.h")]
		public static extern HRESULT SHCreateShellFolderView(ref SFV_CREATE pcsfv, out IShellView ppsv);

		/// <summary>Provides a default handler to extract an icon from a file.</summary>
		/// <param name="pszIconFile">A pointer to a null-terminated buffer that contains the path and name of the file from which the icon is extracted.</param>
		/// <param name="iIndex">
		/// The location of the icon within the file named in pszIconFile. If this is a positive number, it refers to the zero-based position of the icon in the
		/// file. For instance, 0 refers to the 1st icon in the resource file and 2 refers to the 3rd. If this is a negative number, it refers to the icon's
		/// resource ID.
		/// </param>
		/// <param name="uFlags">A flag that controls the icon extraction.</param>
		/// <param name="phiconLarge">
		/// A pointer to an HICON that, when this function returns successfully, receives the handle of the large version of the icon specified in the LOWORD of
		/// nIconSize. This value can be NULL.
		/// </param>
		/// <param name="phiconSmall">
		/// A pointer to an HICON that, when this function returns successfully, receives the handle of the small version of the icon specified in the HIWORD of nIconSize.
		/// </param>
		/// <param name="nIconSize">
		/// A value that contains the large icon size in its LOWORD and the small icon size in its HIWORD. Size is measured in pixels. Pass 0 to specify default
		/// large and small sizes.
		/// </param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762149")]
		public static extern HRESULT SHDefExtractIcon(string pszIconFile, int iIndex, uint uFlags, ref IntPtr phiconLarge,
			ref IntPtr phiconSmall, uint nIconSize);

		/// <summary>Provides a default handler to extract an icon from a file.</summary>
		/// <param name="pszIconFile">A pointer to a null-terminated buffer that contains the path and name of the file from which the icon is extracted.</param>
		/// <param name="iIndex">
		/// The location of the icon within the file named in pszIconFile. If this is a positive number, it refers to the zero-based position of the icon in the
		/// file. For instance, 0 refers to the 1st icon in the resource file and 2 refers to the 3rd. If this is a negative number, it refers to the icon's
		/// resource ID.
		/// </param>
		/// <param name="uFlags">A flag that controls the icon extraction.</param>
		/// <param name="phiconLarge">
		/// A pointer to an HICON that, when this function returns successfully, receives the handle of the large version of the icon specified in the LOWORD of
		/// nIconSize. This value can be NULL.
		/// </param>
		/// <param name="phiconSmall">
		/// A pointer to an HICON that, when this function returns successfully, receives the handle of the small version of the icon specified in the HIWORD of nIconSize.
		/// </param>
		/// <param name="nIconSize">
		/// A value that contains the large icon size in its LOWORD and the small icon size in its HIWORD. Size is measured in pixels. Pass 0 to specify default
		/// large and small sizes.
		/// </param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762149")]
		public static extern HRESULT SHDefExtractIcon(string pszIconFile, int iIndex, uint uFlags, IntPtr phiconLarge,
			ref IntPtr phiconSmall, uint nIconSize);

		/// <summary>Retrieves extended property data from a relative identifier list.</summary>
		/// <param name="psf">
		/// The address of the parent IShellFolder interface. This must be the immediate parent of the ITEMIDLIST structure referenced by the pidl parameter.
		/// </param>
		/// <param name="pidl">A pointer to an ITEMIDLIST structure that identifies the object relative to the folder specified in psf.</param>
		/// <param name="nFormat">The format in which the data is being requested.</param>
		/// <param name="pv">
		/// A pointer to a buffer that, when this function returns successfully, receives the requested data. The format of this buffer is determined by nFormat.
		/// <para>
		/// If nFormat is SHGDFIL_NETRESOURCE, there are two possible cases. If the buffer is large enough, the net resource's string information (fields for the
		/// network name, local name, provider, and comments) will be placed into the buffer. If the buffer is not large enough, only the net resource structure
		/// will be placed into the buffer and the string information pointers will be NULL.
		/// </para>
		/// </param>
		/// <param name="cb">Size of the buffer at pv, in bytes.</param>
		/// <remarks>
		/// This function extracts only information that is present in the pointer to an item identifier list (PIDL). Since the content of a PIDL depends on the
		/// folder object that created the PIDL, there is no guarantee that all requested information will be available. In addition, the information that is
		/// returned reflects the state of the object at the time the PIDL was created. The current state of the object could be different. For example, if you
		/// set nFormat to SHGDFIL_FINDDATA, the function might assign meaningful values to only some of the members of the WIN32_FIND_DATA structure. The
		/// remaining members will be set to zero. To retrieve complete current information on a file system file or folder, use standard file system functions
		/// such as GetFileTime or FindFirstFile.
		/// <para>
		/// E_INVALIDARG is returned if the psf, pidl, pv, or cb parameter does not match the nFormat parameter, or if nFormat is not one of the specific
		/// SHGDFIL_ values shown above.
		/// </para>
		/// </remarks>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762174")]
		public static extern HRESULT SHGetDataFromIDList([In, MarshalAs(UnmanagedType.Interface)]
			IShellFolder psf, [In] PIDL pidl, SHGetDataFormat nFormat, [In, Out] IntPtr pv, int cb);

		/// <summary>Retrieves the IShellFolder interface for the desktop folder, which is the root of the Shell's namespace.</summary>
		/// <param name="ppv">
		/// When this method returns, receives an IShellFolder interface pointer for the desktop folder. The calling application is responsible for eventually
		/// freeing the interface by calling its IUnknown::Release method.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762175")]
		public static extern HRESULT SHGetDesktopFolder([MarshalAs(UnmanagedType.Interface)] out IShellFolder ppv);

		/// <summary>Deprecated. Retrieves the path of a folder as an ITEMIDLIST structure.</summary>
		/// <param name="hwndOwner">Reserved.</param>
		/// <param name="nFolder">
		/// A CSIDL value that identifies the folder to be located. The folders associated with the CSIDLs might not exist on a particular system.
		/// </param>
		/// <param name="hToken">
		/// An access token that can be used to represent a particular user. It is usually set to NULL, but it may be needed when there are multiple users for
		/// those folders that are treated as belonging to a single user. The most commonly used folder of this type is My Documents. The calling application is
		/// responsible for correct impersonation when hToken is non-NULL. It must have appropriate security privileges for the particular user, and the user's
		/// registry hive must be currently mounted.
		/// <para>
		/// Assigning the hToken parameter a value of -1 indicates the Default User. This allows clients of SHGetFolderLocation to find folder locations (such as
		/// the Desktop folder) for the Default User. The Default User user profile is duplicated when any new user account is created, and includes special
		/// folders such as My Documents and Desktop. Any items added to the Default User folder also appear in any new user account.
		/// </para>
		/// </param>
		/// <param name="dwReserved">Reserved.</param>
		/// <param name="ppidl">
		/// The address of a pointer to an item identifier list structure that specifies the folder's location relative to the root of the namespace (the
		/// desktop). The ppidl parameter is set to NULL on failure. The calling application is responsible for freeing this resource by calling CoTaskMemFree.
		/// </param>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762180")]
		public static extern HRESULT SHGetFolderLocation(IntPtr hwndOwner, int nFolder, SafeTokenHandle hToken,
			int dwReserved, out PIDL ppidl);

		/// <summary>
		/// Deprecated. Gets the path of a folder identified by a CSIDL value. <note>As of Windows Vista, this function is merely a wrapper for
		/// SHGetKnownFolderPath. The CSIDL value is translated to its associated KNOWNFOLDERID and then SHGetKnownFolderPath is called. New applications should
		/// use the known folder system rather than the older CSIDL system, which is supported only for backward compatibility.</note>
		/// </summary>
		/// <param name="hwndOwner">Reserved.</param>
		/// <param name="nFolder">
		/// A CSIDL value that identifies the folder whose path is to be retrieved. Only real folders are valid. If a virtual folder is specified, this function
		/// fails. You can force creation of a folder by combining the folder's CSIDL with CSIDL_FLAG_CREATE.
		/// </param>
		/// <param name="hToken">
		/// An access token that represents a particular user. If this parameter is NULL, which is the most common usage, the function requests the known folder
		/// for the current user.
		/// <para>
		/// Request a specific user's folder by passing the hToken of that user. This is typically done in the context of a service that has sufficient
		/// privileges to retrieve the token of a given user. That token must be opened with TOKEN_QUERY and TOKEN_IMPERSONATE rights. In some cases, you also
		/// need to include TOKEN_DUPLICATE. In addition to passing the user's hToken, the registry hive of that specific user must be mounted. See Access
		/// Control for further discussion of access control issues.
		/// </para>
		/// <para>
		/// Assigning the hToken parameter a value of -1 indicates the Default User. This allows clients of SHGetKnownFolderPath to find folder locations (such
		/// as the Desktop folder) for the Default User. The Default User user profile is duplicated when any new user account is created, and includes special
		/// folders such as Documents and Desktop. Any items added to the Default User folder also appear in any new user account. Note that access to the
		/// Default User folders requires administrator privileges.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// Flags that specify the path to be returned. This value is used in cases where the folder associated with a KNOWNFOLDERID (or CSIDL) can be moved,
		/// renamed, redirected, or roamed across languages by a user or administrator.
		/// <para>
		/// The known folder system that underlies SHGetFolderPath allows users or administrators to redirect a known folder to a location that suits their
		/// needs. This is achieved by calling IKnownFolderManager::Redirect, which sets the "current" value of the folder associated with the SHGFP_TYPE_CURRENT flag.
		/// </para>
		/// <para>
		/// The default value of the folder, which is the location of the folder if a user or administrator had not redirected it elsewhere, is retrieved by
		/// specifying the SHGFP_TYPE_DEFAULT flag. This value can be used to implement a "restore defaults" feature for a known folder.
		/// </para>
		/// <para>
		/// For example, the default value (SHGFP_TYPE_DEFAULT) for FOLDERID_Music (CSIDL_MYMUSIC) is "C:\Users\user name\Music". If the folder was redirected,
		/// the current value (SHGFP_TYPE_CURRENT) might be "D:\Music". If the folder has not been redirected, then SHGFP_TYPE_DEFAULT and SHGFP_TYPE_CURRENT
		/// retrieve the same path.
		/// </para>
		/// </param>
		/// <param name="pszPath">
		/// A pointer to a null-terminated string of length MAX_PATH which will receive the path. If an error occurs or S_FALSE is returned, this string will be
		/// empty. The returned path does not include a trailing backslash. For example, "C:\Users" is returned rather than "C:\Users\".
		/// </param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762181")]
		public static extern HRESULT SHGetFolderPath(IntPtr hwndOwner, int nFolder, [In, Optional] SafeTokenHandle hToken,
			SHGFP dwFlags, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszPath);

		/// <summary>
		/// Retrieves the full path of a known folder identified by the folder's KNOWNFOLDERID. This extends SHGetKnownFolderPath by allowing you to set the
		/// initial size of the string buffer.
		/// </summary>
		/// <param name="rfid">A reference to the KNOWNFOLDERID that identifies the folder.</param>
		/// <param name="dwFlags">Flags that specify special retrieval options. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.</param>
		/// <param name="hToken">
		/// An access token that represents a particular user. If this parameter is NULL, which is the most common usage, the function requests the known folder
		/// for the current user.
		/// <para>
		/// Request a specific user's folder by passing the hToken of that user. This is typically done in the context of a service that has sufficient
		/// privileges to retrieve the token of a given user. That token must be opened with TOKEN_QUERY and TOKEN_IMPERSONATE rights. In some cases, you also
		/// need to include TOKEN_DUPLICATE. In addition to passing the user's hToken, the registry hive of that specific user must be mounted. See Access
		/// Control for further discussion of access control issues.
		/// </para>
		/// <para>
		/// Assigning the hToken parameter a value of -1 indicates the Default User. This allows clients of SHGetKnownFolderPath to find folder locations (such
		/// as the Desktop folder) for the Default User. The Default User user profile is duplicated when any new user account is created, and includes special
		/// folders such as Documents and Desktop. Any items added to the Default User folder also appear in any new user account. Note that access to the
		/// Default User folders requires administrator privileges.
		/// </para>
		/// </param>
		/// <param name="pszPath">
		/// A null-terminated, Unicode string. This buffer must be of size cchPath. When SHGetFolderPathEx returns successfully, this parameter contains the path
		/// for the known folder.
		/// </param>
		/// <param name="cchPath">The size of the ppszPath buffer, in characters.</param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shlobj.h", MSDNShortId = "mt757093")]
		public static extern HRESULT SHGetFolderPathEx([In, MarshalAs(UnmanagedType.LPStruct)]
			Guid rfid, KNOWN_FOLDER_FLAG dwFlags, [In, Optional] SafeTokenHandle hToken,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszPath, uint cchPath);

		/// <summary>Retrieves the pointer to an item identifier list (PIDL) of an object.</summary>
		/// <param name="iUnknown">A pointer to the IUnknown of the object from which to get the PIDL.</param>
		/// <param name="ppidl">When this function returns, contains a pointer to the PIDL of the given object.</param>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762184")]
		public static extern HRESULT SHGetIDListFromObject([MarshalAs(UnmanagedType.IUnknown)] object iUnknown,
			out PIDL ppidl);

		/// <summary>Retrieves an image list.</summary>
		/// <param name="iImageList">The image type contained in the list.</param>
		/// <param name="riid">Reference to the image list interface identifier, normally IID_IImageList.</param>
		/// <param name="ppv">When this method returns, contains the interface pointer requested in riid. This is typically IImageList.</param>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762185")]
		public static extern HRESULT SHGetImageList(SHIL iImageList, [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
			out IImageList ppv);

		/// <summary>Retrieves the path of a known folder as an ITEMIDLIST structure.</summary>
		/// <param name="rfid">
		/// A reference to the KNOWNFOLDERID that identifies the folder. The folders associated with the known folder IDs might not exist on a particular system.
		/// </param>
		/// <param name="dwFlags">
		/// Flags that specify special retrieval options. This value can be 0; otherwise, it is one or more of the KNOWN_FOLDER_FLAG values.
		/// </param>
		/// <param name="hToken">
		/// An access token used to represent a particular user. This parameter is usually set to NULL, in which case the function tries to access the current
		/// user's instance of the folder. However, you may need to assign a value to hToken for those folders that can have multiple users but are treated as
		/// belonging to a single user. The most commonly used folder of this type is Documents.
		/// <para>
		/// The calling application is responsible for correct impersonation when hToken is non-null. It must have appropriate security privileges for the
		/// particular user, including TOKEN_QUERY and TOKEN_IMPERSONATE, and the user's registry hive must be currently mounted. See Access Control for further
		/// discussion of access control issues.
		/// </para>
		/// <para>
		/// Assigning the hToken parameter a value of -1 indicates the Default User. This allows clients of SHGetKnownFolderIDList to find folder locations (such
		/// as the Desktop folder) for the Default User. The Default User user profile is duplicated when any new user account is created, and includes special
		/// folders such as Documents and Desktop. Any items added to the Default User folder also appear in any new user account. Note that access to the
		/// Default User folders requires administrator privileges.
		/// </para>
		/// </param>
		/// <param name="ppidl">
		/// When this method returns, contains a pointer to the PIDL of the folder. This parameter is passed uninitialized. The caller is responsible for freeing
		/// the returned PIDL when it is no longer needed by calling ILFree.
		/// </param>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762187")]
		public static extern HRESULT SHGetKnownFolderIDList([In, MarshalAs(UnmanagedType.LPStruct)]
			Guid rfid, KNOWN_FOLDER_FLAG dwFlags, [In, Optional] SafeTokenHandle hToken, out PIDL ppidl);

		/// <summary>Retrieves an IShellItem object that represents a known folder.</summary>
		/// <param name="rfid">A reference to the KNOWNFOLDERID, a GUID that identifies the folder that contains the item.</param>
		/// <param name="dwFlags">
		/// Flags that specify special options used in the retrieval of the known folder IShellItem. This value can be KF_FLAG_DEFAULT; otherwise, one or more of
		/// the KNOWN_FOLDER_FLAG values.
		/// </param>
		/// <param name="hToken">
		/// An access token used to represent a particular user. This parameter is usually set to NULL, in which case the function tries to access the current
		/// user's instance of the folder. However, you may need to assign a value to hToken for those folders that can have multiple users but are treated as
		/// belonging to a single user. The most commonly used folder of this type is Documents.
		/// <para>
		/// The calling application is responsible for correct impersonation when hToken is non-null. It must have appropriate security privileges for the
		/// particular user, including TOKEN_QUERY and TOKEN_IMPERSONATE, and the user's registry hive must be currently mounted. See Access Control for further
		/// discussion of access control issues.
		/// </para>
		/// <para>
		/// Assigning the hToken parameter a value of -1 indicates the Default User. This allows clients of SHGetKnownFolderIDList to find folder locations (such
		/// as the Desktop folder) for the Default User. The Default User user profile is duplicated when any new user account is created, and includes special
		/// folders such as Documents and Desktop. Any items added to the Default User folder also appear in any new user account. Note that access to the
		/// Default User folders requires administrator privileges.
		/// </para>
		/// </param>
		/// <param name="riid">A reference to the IID of the interface that represents the item, usually IID_IShellItem or IID_IShellItem2.</param>
		/// <param name="ppv">When this method returns, contains the interface pointer requested in riid.</param>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shlobj.h", MSDNShortId = "dd378429")]
		public static extern HRESULT SHGetKnownFolderItem([In, MarshalAs(UnmanagedType.LPStruct)]
			Guid rfid, KNOWN_FOLDER_FLAG dwFlags, [In, Optional] SafeTokenHandle hToken,
			[In, MarshalAs(UnmanagedType.LPStruct)]
			Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);

		/// <summary>Retrieves the full path of a known folder identified by the folder's KNOWNFOLDERID.</summary>
		/// <param name="rfid">A reference to the KNOWNFOLDERID that identifies the folder.</param>
		/// <param name="dwFlags">Flags that specify special retrieval options. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.</param>
		/// <param name="hToken">
		/// An access token that represents a particular user. If this parameter is NULL, which is the most common usage, the function requests the known folder
		/// for the current user.
		/// <para>
		/// Request a specific user's folder by passing the hToken of that user. This is typically done in the context of a service that has sufficient
		/// privileges to retrieve the token of a given user. That token must be opened with TOKEN_QUERY and TOKEN_IMPERSONATE rights. In some cases, you also
		/// need to include TOKEN_DUPLICATE. In addition to passing the user's hToken, the registry hive of that specific user must be mounted. See Access
		/// Control for further discussion of access control issues.
		/// </para>
		/// <para>
		/// Assigning the hToken parameter a value of -1 indicates the Default User. This allows clients of SHGetKnownFolderPath to find folder locations (such
		/// as the Desktop folder) for the Default User. The Default User user profile is duplicated when any new user account is created, and includes special
		/// folders such as Documents and Desktop. Any items added to the Default User folder also appear in any new user account. Note that access to the
		/// Default User folders requires administrator privileges.
		/// </para>
		/// </param>
		/// <param name="pszPath">
		/// When this method returns, contains the address of a pointer to a null-terminated Unicode string that specifies the path of the known folder. The
		/// calling process is responsible for freeing this resource once it is no longer needed by calling CoTaskMemFree. The returned path does not include a
		/// trailing backslash. For example, "C:\Users" is returned rather than "C:\Users\".
		/// </param>
		/// <returns>Returns S_OK if successful, or an error value otherwise.</returns>
		/// <remarks>This function replaces SHGetFolderPath. That older function is now simply a wrapper for SHGetKnownFolderPath.</remarks>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762188")]
		public static extern HRESULT SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
			KNOWN_FOLDER_FLAG dwFlags, [In, Optional] SafeTokenHandle hToken, out SafeCoTaskMemHandle pszPath);

		/// <summary>Retrieves the full path of a known folder identified by the folder's KNOWNFOLDERID.</summary>
		/// <param name="id">A reference to the KNOWNFOLDERID that identifies the folder.</param>
		/// <param name="dwFlags">Flags that specify special retrieval options. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.</param>
		/// <param name="hToken">
		/// An access token that represents a particular user. If this parameter is NULL, which is the most common usage, the function requests the known folder
		/// for the current user.
		/// <para>
		/// Request a specific user's folder by passing the hToken of that user. This is typically done in the context of a service that has sufficient
		/// privileges to retrieve the token of a given user. That token must be opened with TOKEN_QUERY and TOKEN_IMPERSONATE rights. In some cases, you also
		/// need to include TOKEN_DUPLICATE. In addition to passing the user's hToken, the registry hive of that specific user must be mounted. See Access
		/// Control for further discussion of access control issues.
		/// </para>
		/// <para>
		/// Assigning the hToken parameter a value of -1 indicates the Default User. This allows clients of SHGetKnownFolderPath to find folder locations (such
		/// as the Desktop folder) for the Default User. The Default User user profile is duplicated when any new user account is created, and includes special
		/// folders such as Documents and Desktop. Any items added to the Default User folder also appear in any new user account. Note that access to the
		/// Default User folders requires administrator privileges.
		/// </para>
		/// </param>
		/// <returns>String that specifies the path of the known folder.</returns>
		/// <remarks>This function replaces SHGetFolderPath. That older function is now simply a wrapper for SHGetKnownFolderPath.</remarks>
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762188")]
		public static string SHGetKnownFolderPath(KNOWNFOLDERID id, KNOWN_FOLDER_FLAG dwFlags, SafeTokenHandle hToken = null)
		{
			SHGetKnownFolderPath(id.Guid(), dwFlags, hToken ?? SafeTokenHandle.Null, out SafeCoTaskMemHandle path);
			return path.ToString(-1);
		}

		/// <summary>Retrieves the display name of an item identified by its IDList.</summary>
		/// <param name="pidl">A PIDL that identifies the item.</param>
		/// <param name="sigdnName">A value from the SIGDN enumeration that specifies the type of display name to retrieve.</param>
		/// <param name="ppszName">A value that, when this function returns successfully, receives the address of a pointer to the retrieved display name.</param>
		[DllImport(Lib.Shell32, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762191")]
		public static extern HRESULT SHGetNameFromIDList(PIDL pidl, SIGDN sigdnName, out SafeCoTaskMemHandle ppszName);

		/// <summary>Converts an item identifier list to a file system path.</summary>
		/// <param name="pidl">
		/// The address of an item identifier list that specifies a file or directory location relative to the root of the namespace (the desktop).
		/// </param>
		/// <param name="pszPath">The address of a buffer to receive the file system path. This buffer must be at least MAX_PATH characters in size.</param>
		/// <returns>Returns TRUE if successful; otherwise, FALSE.</returns>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762194")]
		public static extern bool SHGetPathFromIDList(PIDL pidl, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder pszPath);

		/// <summary>Opens a Windows Explorer window with specified items in a particular folder selected.</summary>
		/// <param name="pidlFolder">A pointer to a fully qualified item ID list that specifies the folder.</param>
		/// <param name="cidl">
		/// A count of items in the selection array, apidl. If cidl is zero, then pidlFolder must point to a fully specified ITEMIDLIST describing a single item
		/// to select. This function opens the parent folder and selects that item.
		/// </param>
		/// <param name="apidl">A pointer to an array of PIDL structures, each of which is an item to select in the target folder referenced by pidlFolder.</param>
		/// <param name="dwFlags">The optional flags. Under Windows XP this parameter is ignored. In Windows Vista, the following flags are defined.</param>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762232")]
		public static extern HRESULT SHOpenFolderAndSelectItems(PIDL pidlFolder, uint cidl,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] apidl, OFASI dwFlags);

		/// <summary>
		/// Translates a Shell namespace object's display name into an item identifier list and returns the attributes of the object. This function is the
		/// preferred method to convert a string to a pointer to an item identifier list (PIDL).
		/// </summary>
		/// <param name="pszName">A pointer to a zero-terminated wide string that contains the display name to parse.</param>
		/// <param name="pbc">A bind context that controls the parsing operation. This parameter is normally set to NULL.</param>
		/// <param name="ppidl">
		/// The address of a pointer to a variable of type ITEMIDLIST that receives the item identifier list for the object. If an error occurs, then this
		/// parameter is set to NULL.
		/// </param>
		/// <param name="sfgaoIn">
		/// A ULONG value that specifies the attributes to query. To query for one or more attributes, initialize this parameter with the flags that represent
		/// the attributes of interest. For a list of available SFGAO flags, see IShellFolder::GetAttributesOf.
		/// </param>
		/// <param name="psfgaoOut">
		/// A pointer to a ULONG. On return, those attributes that are true for the object and were requested in sfgaoIn are set. An object's attribute flags can
		/// be zero or a combination of SFGAO flags. For a list of available SFGAO flags, see IShellFolder::GetAttributesOf.
		/// </param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762236")]
		public static extern HRESULT SHParseDisplayName([MarshalAs(UnmanagedType.LPWStr)] string pszName,
			[In, Optional] IntPtr pbc, out PIDL ppidl, SFGAO sfgaoIn, out SFGAO psfgaoOut);

		/// <summary>
		/// Defines the coordinates of a character cell in a console screen buffer. The origin of the coordinate system (0,0) is at the top, left cell of the buffer.
		/// </summary>
		[PInvokeData("wincon.h")]
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct COORD
		{
			/// <summary>The horizontal coordinate or column value. The units depend on the function call.</summary>
			public short X;

			/// <summary>The vertical coordinate or row value. The units depend on the function call.</summary>
			public short Y;
		}

		/// <summary>Serves as the header for some of the extra data structures used by IShellLinkDataList.</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb773249")]
		public struct DATABLOCKHEADER
		{
			/// <summary>The size of the extra data block.</summary>
			public uint cbSize;

			/// <summary>A signature that identifies the type of data block that follows the header.</summary>
			public ShellDataBlockSignature dwSignature;
		}

		/// <summary>Holds an extra data block used by IShellLinkDataList. It holds the link's Windows Installer ID.</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb773274")]
		public struct EXP_DARWIN_LINK
		{
			/// <summary>
			/// DATABLOCK_HEADER structure stating the size and signature of the EXP_DARWIN_LINK structure. The following is the only recognized signature value: EXP_DARWIN_ID_SIG
			/// </summary>
			public DATABLOCKHEADER dbh;

			/// <summary>The link's ID in the form of an ANSI string.</summary>
			[MarshalAs(UnmanagedType.LPStr, SizeConst = MAX_PATH)]
			public string szDarwinID;

			/// <summary>The link's ID in the form of an Unicode string.</summary>
			[MarshalAs(UnmanagedType.LPWStr, SizeConst = MAX_PATH)]
			public string szwDarwinID;
		}

		/// <summary>Holds an extra data block used by IShellLinkDataList. It holds special folder information.</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb773279")]
		public struct EXP_SPECIAL_FOLDER
		{
			/// <summary>The size of the EXP_SPECIAL_FOLDER structure.</summary>
			public uint cbSize;

			/// <summary>The structure's signature. It should be set to EXP_SPECIAL_FOLDER_SIG.</summary>
			public ShellDataBlockSignature dwSignature;

			/// <summary>The ID of the special folder that the link points into.</summary>
			public uint idSpecialFolder;

			/// <summary>The offset into the saved PIDL.</summary>
			public uint cbOffset;
		}

		/// <summary>Holds an extra data block used by IShellLinkDataList. It holds expandable environment strings for the icon or target.</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb773282")]
		public struct EXP_SZ_LINK
		{
			/// <summary>The size of the EXP_SZ_LINK structure.</summary>
			public uint cbSize;

			/// <summary>
			/// The structure's signature. It can have one of the following values: EXP_SZ_LINK_SIG = Contains the link's target path; EXP_SZ_ICON_SIG = Contains
			/// the links icon path.
			/// </summary>
			public ShellDataBlockSignature dwSignature;

			/// <summary>The null-terminated ANSI string with the path of the target or icon.</summary>
			[MarshalAs(UnmanagedType.LPStr, SizeConst = MAX_PATH)]
			public string szTarget;

			/// <summary>The null-terminated Unicode string with the path of the target or icon.</summary>
			[MarshalAs(UnmanagedType.LPWStr, SizeConst = MAX_PATH)]
			public string swzTarget;
		}

		/// <summary>Holds an extra data block used by IShellLinkDataList. It holds console properties.</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb773359")]
		public struct NT_CONSOLE_PROPS
		{
			/// <summary>
			/// The DATABLOCK_HEADER structure with the NT_CONSOLE_PROPS structure's size and signature. The signature for an NT_CONSOLE_PROPS structure is NT_CONSOLE_PROPS_SIG.
			/// </summary>
			public DATABLOCKHEADER dbh;

			/// <summary>Fill attribute for the console.</summary>
			public ushort wFillAttribute;

			/// <summary>Fill attribute for console pop-ups.</summary>
			public ushort wPopupFillAttribute;

			/// <summary>A COORD structure with the console's screen buffer size.</summary>
			public COORD dwScreenBufferSize;

			/// <summary>A COORD structure with the console's window size.</summary>
			public COORD dwWindowSize;

			/// <summary>A COORD structure with the console's window origin.</summary>
			public COORD dwWindowOrigin;

			/// <summary>The font.</summary>
			public uint nFont;

			/// <summary>The input buffer size.</summary>
			public uint nInputBufferSize;

			/// <summary>A COORD structure with the font size.</summary>
			public COORD dwFontSize;

			/// <summary>The font family/</summary>
			public uint uFontFamily;

			/// <summary>The font weight.</summary>
			public uint uFontWeight;

			/// <summary>A character array that contains the font's face name.</summary>
			[MarshalAs(UnmanagedType.LPWStr, SizeConst = LF_FACESIZE)]
			public string FaceName;

			/// <summary>The cursor size.</summary>
			public uint uCursorSize;

			/// <summary>A boolean value that is set to TRUE if the console is in full-screen mode, or FALSE otherwise.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool bFullScreen;

			/// <summary>A boolean value that is set to TRUE if the console is in quick-edit mode, or FALSE otherwise.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool bQuickEdit;

			/// <summary>A boolean value that is set to TRUE if the console is in insert mode, or FALSE otherwise.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool bInsertMode;

			/// <summary>A boolean value that is set to TRUE if the console is in auto-position mode, or FALSE otherwise.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool bAutoPosition;

			/// <summary>The size of the history buffer.</summary>
			public uint uHistoryBufferSize;

			/// <summary>The number of history buffers.</summary>
			public uint uNumberOfHistoryBuffers;

			/// <summary>A boolean value that is set to TRUE if old duplicate history lists should be discarded, or FALSE otherwise.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool bHistoryNoDup;

			/// <summary>An array of COLORREF values with the console's color settings.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public uint[] ColorTable;
		}

		/// <summary>Holds an extra data block used by IShellLinkDataList. It holds the console's code page.</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb773362")]
		public struct NT_FE_CONSOLE_PROPS
		{
			/// <summary>
			/// The DATABLOCK_HEADER structure with the NT_FE_CONSOLE_PROPS structure's size and signature. The signature for an NT_FE_CONSOLE_PROPS structure is NT_FE_CONSOLE_PROPS_SIG.
			/// </summary>
			public DATABLOCKHEADER dbh;

			/// <summary>The console's code page.</summary>
			public uint uCodePage;
		}

		/// <summary>This structure is used with the SHCreateShellFolderView function.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Shlobj.h")]
		public struct SFV_CREATE
		{
			/// <summary>The size of the SFV_CREATE structure, in bytes.</summary>
			public uint cbSize;
			/// <summary>The IShellFolder interface of the folder for which to create the view.</summary>
			public IShellFolder pshf;
			/// <summary>
			/// A pointer to the parent IShellView interface. This parameter may be NULL. This parameter is used only when the view created by
			/// SHCreateShellFolderView is hosted in a common dialog box.
			/// </summary>
			public IShellView psvOuter;
			/// <summary>
			/// A pointer to the IShellFolderViewCB interface that handles the view's callbacks when various events occur. This parameter may be NULL.
			/// </summary>
			public IShellFolderViewCB psfvcb;
		}

		/// <summary>Receives item data in response to a call to SHGetDataFromIDList.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb759775")]
		public struct SHDESCRIPTIONID
		{
			/// <summary>Receives a value that determines what type the item is.</summary>
			public SHDID dwDescriptionId;

			/// <summary>Receives the CLSID of the object to which the item belongs.</summary>
			public Guid clsid;
		}

		/*[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb773399")]
		public struct SFV_CREATE
		{
			public uint cbSize;
			[MarshalAs(UnmanagedType.Interface)] public IShellFolder pshf;
			[MarshalAs(UnmanagedType.Interface)] public IShellView psvOuter;
			[MarshalAs(UnmanagedType.Interface)] public IShellFolderViewCB psfbcb;
		}*/
	}
}