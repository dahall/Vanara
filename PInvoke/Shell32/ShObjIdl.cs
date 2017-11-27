using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

// ReSharper disable FieldCanBeMadeReadOnly.Global ReSharper disable InconsistentNaming ReSharper disable MemberHidesStaticFromOuterClass ReSharper disable UnusedMethodReturnValue.Global

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Values that specify from which category the list of destinations should be retrieved.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378410")]
		public enum APPDOCLISTTYPE
		{
			/// <summary>The Recent category, which lists those items most recently accessed.</summary>
			RECENT,

			/// <summary>The Frequent category, which lists the items that have been accessed the greatest number of times.</summary>
			FREQUENT
		}

		/// <summary>Specifies list placement.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762502")]
		public enum FDAP : uint
		{
			/// <summary>The place is added to the bottom of the default list.</summary>
			FDAP_BOTTOM = 0,

			/// <summary>The place is added to the top of the default list.</summary>
			FDAP_TOP = 1
		}

		/// <summary>
		/// Specifies the values used by the IFileDialogEvents::OnShareViolation method to indicate an application's response to a sharing violation that occurs
		/// when a file is opened or saved.
		/// </summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762504")]
		public enum FDE_SHAREVIOLATION_RESPONSE
		{
			/// <summary>
			/// The application has not handled the event. The dialog displays a UI that indicates that the file is in use and a different file must be chosen.
			/// </summary>
			FDESVR_DEFAULT,

			/// <summary>The application has determined that the file should be returned from the dialog.</summary>
			FDESVR_ACCEPT,

			/// <summary>The application has determined that the file should not be returned from the dialog.</summary>
			FDESVR_REFUSE
		}

		/// <summary>Describes match criteria. Used by methods of the IKnownFolderManager interface.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762505")]
		public enum FFFP_MODE
		{
			/// <summary>Exact match.</summary>
			FFFP_EXACTMATCH,

			/// <summary>Nearest parent match.</summary>
			FFFP_NEARESTPARENTMATCH,
		}

		/// <summary>Defines the set of options available to an Open or Save dialog.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "dn457282")]
		[Flags]
		public enum FILEOPENDIALOGOPTIONS : uint
		{
			/// <summary>When saving a file, prompt before overwriting an existing file of the same name. This is a default value for the Save dialog.</summary>
			FOS_OVERWRITEPROMPT = 0x00000002,

			/// <summary>In the Save dialog, only allow the user to choose a file that has one of the file name extensions specified through IFileDialog::SetFileTypes.</summary>
			FOS_STRICTFILETYPES = 0x00000004,

			/// <summary>Don't change the current working directory.</summary>
			FOS_NOCHANGEDIR = 0x00000008,

			/// <summary>Present an Open dialog that offers a choice of folders rather than files.</summary>
			FOS_PICKFOLDERS = 0x00000020,

			/// <summary>Ensures that returned items are file system items (SFGAO_FILESYSTEM). Note that this does not apply to items returned by IFileDialog::GetCurrentSelection.</summary>
			FOS_FORCEFILESYSTEM = 0x00000040,

			/// <summary>
			/// Enables the user to choose any item in the Shell namespace, not just those with SFGAO_STREAM or SFAGO_FILESYSTEM attributes. This flag cannot be
			/// combined with FOS_FORCEFILESYSTEM.
			/// </summary>
			FOS_ALLNONSTORAGEITEMS = 0x00000080,

			/// <summary>
			/// Do not check for situations that would prevent an application from opening the selected file, such as sharing violations or access denied errors.
			/// </summary>
			FOS_NOVALIDATE = 0x00000100,

			/// <summary>
			/// Enables the user to select multiple items in the open dialog. Note that when this flag is set, the IFileOpenDialog interface must be used to
			/// retrieve those items.
			/// </summary>
			FOS_ALLOWMULTISELECT = 0x00000200,

			/// <summary>The item returned must be in an existing folder. This is a default value.</summary>
			FOS_PATHMUSTEXIST = 0x00000800,

			/// <summary>The item returned must exist. This is a default value for the Open dialog.</summary>
			FOS_FILEMUSTEXIST = 0x00001000,

			/// <summary>Prompt for creation if the item returned in the save dialog does not exist. Note that this does not actually create the item.</summary>
			FOS_CREATEPROMPT = 0x00002000,

			/// <summary>
			/// In the case of a sharing violation when an application is opening a file, call the application back through OnShareViolation for guidance. This
			/// flag is overridden by FOS_NOVALIDATE.
			/// </summary>
			FOS_SHAREAWARE = 0x00004000,

			/// <summary>Do not return read-only items. This is a default value for the Save dialog.</summary>
			FOS_NOREADONLYRETURN = 0x00008000,

			/// <summary>
			/// Do not test whether creation of the item as specified in the Save dialog will be successful. If this flag is not set, the calling application
			/// must handle errors, such as denial of access, discovered when the item is created.
			/// </summary>
			FOS_NOTESTFILECREATE = 0x00010000,

			/// <summary>Hide the list of places from which the user has recently opened or saved items. This value is not supported as of Windows 7.</summary>
			FOS_HIDEMRUPLACES = 0x00020000,

			/// <summary>
			/// Hide items shown by default in the view's navigation pane. This flag is often used in conjunction with the IFileDialog::AddPlace method, to hide
			/// standard locations and replace them with custom locations.
			/// <para>
			/// <c>Windows 7</c> and later. Hide all of the standard namespace locations (such as Favorites, Libraries, Computer, and Network) shown in the
			/// navigation pane.
			/// </para>
			/// <para>
			/// <c>Windows Vista.</c> Hide the contents of the Favorite Links tree in the navigation pane. Note that the category itself is still displayed, but
			/// shown as empty.
			/// </para>
			/// </summary>
			FOS_HIDEPINNEDPLACES = 0x00040000,

			/// <summary>
			/// Shortcuts should not be treated as their target items. This allows an application to open a .lnk file rather than what that file is a shortcut to.
			/// </summary>
			FOS_NODEREFERENCELINKS = 0x00100000,

			/// <summary>Do not add the item being opened or saved to the recent documents list (SHAddToRecentDocs).</summary>
			FOS_DONTADDTORECENT = 0x02000000,

			/// <summary>Include hidden and system items.</summary>
			FOS_FORCESHOWHIDDEN = 0x10000000,

			/// <summary>
			/// Indicates to the Save As dialog box that it should open in expanded mode. Expanded mode is the mode that is set and unset by clicking the button
			/// in the lower-left corner of the Save As dialog box that switches between Browse Folders and Hide Folders when clicked. This value is not
			/// supported as of Windows 7.
			/// </summary>
			FOS_DEFAULTNOMINIMODE = 0x20000000,

			/// <summary>Indicates to the Open dialog box that the preview pane should always be displayed.</summary>
			FOS_FORCEPREVIEWPANEON = 0x40000000,

			/// <summary>Indicates that the caller is opening a file as a stream (BHID_Stream), so there is no need to download that file.</summary>
			FOS_SUPPORTSTREAMABLEITEMS = 0x80000000
		}

		/// <summary>Value that represent a category by which a folder registered with the Known Folder system can be classified.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762512")]
		public enum KF_CATEGORY
		{
			/// <summary>
			/// Virtual folders are not part of the file system, which is to say that they have no path. For example, Control Panel and Printers are virtual
			/// folders. A number of features such as folder path and redirection do not apply to this category.
			/// </summary>
			KF_CATEGORY_VIRTUAL = 1,

			/// <summary>
			/// Fixed file system folders are not managed by the Shell and are usually given a permanent path when the system is installed. For example, the
			/// Windows and Program Files folders are fixed folders. A number of features such as redirection do not apply to this category.
			/// </summary>
			KF_CATEGORY_FIXED = 2,

			/// <summary>
			/// Common folders are those file system folders used for sharing data and settings, accessible by all users of a system. For example, all users
			/// share a common Documents folder as well as their per-user Documents folder.
			/// </summary>
			KF_CATEGORY_COMMON = 3,

			/// <summary>
			/// Per-user folders are those stored under each user's profile and accessible only by that user. For example, %USERPROFILE%\Pictures. This category
			/// of folder usually supports many features including aliasing, redirection and customization.
			/// </summary>
			KF_CATEGORY_PERUSER = 4,
		}

		/// <summary>Flags that specify certain known folder behaviors. Used with the KNOWNFOLDER_DEFINITION structure.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762513")]
		[Flags]
		public enum KF_DEFINITION_FLAGS
		{
			/// <summary>
			/// Prevent a per-user known folder from being redirected to a network location. Note that if the known folder has been flagged with
			/// KFDF_LOCAL_REDIRECT_ONLY but it is a subfolder of a known folder that is redirected to a network location, this subfolder is redirected also.
			/// </summary>
			KFDF_LOCAL_REDIRECT_ONLY = 0x00000002,

			/// <summary>Can be roamed through a PC-to-PC synchronization.</summary>
			KFDF_ROAMABLE = 0x00000004,

			/// <summary>
			/// Create the folder when the user first logs on. Normally a known folder is not created until it is first called. At that time, an API such as
			/// SHCreateItemInKnownFolder or IKnownFolder::GetShellItem is called with the KF_FLAG_CREATE flag. However, some known folders need to exist
			/// immediately. An example is those known folders under %USERPROFILE%, which must exist to provide a proper view. In those cases, KFDF_PRECREATE is
			/// set and Windows Explorer calls the creation API during its user initialization.
			/// </summary>
			KFDF_PRECREATE = 0x00000008,

			/// <summary>Introduced in Windows 7. The known folder is a file rather than a folder.</summary>
			KFDF_STREAM = 0x00000010,

			/// <summary>
			/// Introduced in Windows 7. The full path of the known folder, with any environment variables fully expanded, is stored in the registry under HKEY_CURRENT_USER.
			/// </summary>
			KFDF_PUBLISHEXPANDEDPATH = 0x00000020,

			/// <summary>Introduced in Windows 8.1. Prevent showing the Locations tab in the property dialog of the known folder.</summary>
			KFDF_NO_REDIRECT_UI = 0x00000040,
		}

		/// <summary>
		/// Flags used by IKnownFolderManager::Redirect to specify details of a known folder redirection such as permissions and ownership for the redirected folder.
		/// </summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762515")]
		[Flags]
		public enum KF_REDIRECT_FLAGS
		{
			/// <summary>Ensure that only the user has permission to access the redirected folder.</summary>
			KF_REDIRECT_USER_EXCLUSIVE = 0x00000001,

			/// <summary>Copy the DACL of the source folder to the target to maintain current access permissions.</summary>
			KF_REDIRECT_COPY_SOURCE_DACL = 0x00000002,

			/// <summary>
			/// Sets the user as the owner of a newly created target folder unless the user is a member of the Administrator group, in which case Administrator
			/// is set as the owner. Must be called with KF_REDIRECT_SET_OWNER_EXPLICIT.
			/// </summary>
			KF_REDIRECT_OWNER_USER = 0x00000004,

			/// <summary>
			/// Set the owner of a newly created target folder. If the user belongs to the Administrators group, Administrators is assigned as the owner. Must be
			/// called with KF_REDIRECT_OWNER_USER.
			/// </summary>
			KF_REDIRECT_SET_OWNER_EXPLICIT = 0x00000008,

			/// <summary>
			/// Do not perform a redirection, simply check whether redirection has occurred. If so, IKnownFolderManager::Redirect returns S_OK; if not, or if
			/// some actions remain to be completed, it returns S_FALSE.
			/// </summary>
			KF_REDIRECT_CHECK_ONLY = 0x00000010,

			/// <summary>Display UI during the redirection.</summary>
			KF_REDIRECT_WITH_UI = 0x00000020,

			/// <summary>Unpin the source folder.</summary>
			KF_REDIRECT_UNPIN = 0x00000040,

			/// <summary>Pin the target folder.</summary>
			KF_REDIRECT_PIN = 0x00000080,

			/// <summary>Copy the existing contents—both files and subfolders—of the known folder to the redirected folder.</summary>
			KF_REDIRECT_COPY_CONTENTS = 0x00000200,

			/// <summary>
			/// Delete the contents of the source folder after they have been copied to the redirected folder. This flag is valid only if
			/// KF_REDIRECT_COPY_CONTENTS is set.
			/// </summary>
			KF_REDIRECT_DEL_SOURCE_CONTENTS = 0x00000400,

			/// <summary>Reserved. Do not use.</summary>
			KF_REDIRECT_EXCLUDE_ALL_KNOWN_SUBFOLDERS = 0x00000800,
		}

		/// <summary>Flags that specify the current redirection capabilities of a known folder. Used by IKnownFolder::GetRedirectionCapabilities.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762514")]
		[Flags]
		public enum KF_REDIRECTION_CAPABILITIES
		{
			/// <summary>
			/// The folder can be redirected if any of the bits in the lower byte of the value are set but no DENY flag is set. DENY flags are found in the upper
			/// byte of the value.
			/// </summary>
			KF_REDIRECTION_CAPABILITIES_ALLOW_ALL = 0x000000FF,

			/// <summary>
			/// The folder can be redirected. Currently, redirection exists for only common and user folders; fixed and virtual folders cannot be redirected.
			/// </summary>
			KF_REDIRECTION_CAPABILITIES_REDIRECTABLE = 0x00000001,

			/// <summary>Redirection is not allowed.</summary>
			KF_REDIRECTION_CAPABILITIES_DENY_ALL = 0x000FFF00,

			/// <summary>The folder cannot be redirected because it is already redirected by group policy.</summary>
			KF_REDIRECTION_CAPABILITIES_DENY_POLICY_REDIRECTED = 0x00000100,

			/// <summary>The folder cannot be redirected because the policy prohibits redirecting this folder.</summary>
			KF_REDIRECTION_CAPABILITIES_DENY_POLICY = 0x00000200,

			/// <summary>The folder cannot be redirected because the calling application does not have sufficient permissions.</summary>
			KF_REDIRECTION_CAPABILITIES_DENY_PERMISSIONS = 0x00000400,
		}

		/// <summary>One of the following values that indicate which known category to add to the list</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378397")]
		public enum KNOWNDESTCATEGORY
		{
			/// <summary>Add the Frequent category.</summary>
			KDC_FREQUENT = 1,

			/// <summary>Add the Recent category.</summary>
			KDC_RECENT = 2
		}

		/// <summary>Attributes that can be retrieved on an item (file or folder) or set of items.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762589")]
		[Flags]
		public enum SFGAO : uint
		{
			/// <summary>The specified items can be hosted inside a web browser or Windows Explorer frame.</summary>
			SFGAO_BROWSABLE = 0x8000000,

			/// <summary>The specified items can be copied.</summary>
			SFGAO_CANCOPY = 1,

			/// <summary>The specified items can be deleted.</summary>
			SFGAO_CANDELETE = 0x20,

			/// <summary>
			/// Shortcuts can be created for the specified items. This attribute has the same value as DROPEFFECT_LINK.
			/// <para>
			/// If a namespace extension returns this attribute, a Create Shortcut entry with a default handler is added to the shortcut menu that is displayed
			/// during drag-and-drop operations. The extension can also implement its own handler for the link verb in place of the default. If the extension
			/// does so, it is responsible for creating the shortcut.
			/// </para>
			/// <para>A Create Shortcut item is also added to the Windows Explorer File menu and to normal shortcut menus.</para>
			/// <para>
			/// If the item is selected, your application's IContextMenu::InvokeCommand method is invoked with the lpVerb member of the CMINVOKECOMMANDINFO
			/// structure set to link. Your application is responsible for creating the link.
			/// </para>
			/// </summary>
			SFGAO_CANLINK = 4,

			/// <summary>Not supported.</summary>
			SFGAO_CANMONIKER = 0x400000,

			/// <summary>The specified items can be moved.</summary>
			SFGAO_CANMOVE = 2,

			/// <summary>
			/// The specified items can be renamed. Note that this value is essentially a suggestion; not all namespace clients allow items to be renamed.
			/// However, those that do must have this attribute set.
			/// </summary>
			SFGAO_CANRENAME = 0x10,

			/// <summary>
			/// This flag is a mask for the capability attributes: SFGAO_CANCOPY, SFGAO_CANMOVE, SFGAO_CANLINK, SFGAO_CANRENAME, SFGAO_CANDELETE,
			/// SFGAO_HASPROPSHEET, and SFGAO_DROPTARGET. Callers normally do not use this value.
			/// </summary>
			SFGAO_CAPABILITYMASK = 0x177,

			/// <summary>The specified items are compressed.</summary>
			SFGAO_COMPRESSED = 0x4000000,

			/// <summary>This flag is a mask for content attributes, at present only SFGAO_HASSUBFOLDER. Callers normally do not use this value.</summary>
			SFGAO_CONTENTSMASK = 0x80000000,

			/// <summary>Do not use.</summary>
			SFGAO_DISPLAYATTRMASK = 0xfc000,

			/// <summary>The specified items are drop targets.</summary>
			SFGAO_DROPTARGET = 0x100,

			/// <summary>The specified items are encrypted and might require special presentation.</summary>
			SFGAO_ENCRYPTED = 0x2000,

			/// <summary>
			/// The specified folders are either file system folders or contain at least one descendant (child, grandchild, or later) that is a file system
			/// (SFGAO_FILESYSTEM) folder.
			/// </summary>
			SFGAO_FILESYSANCESTOR = 0x10000000,

			/// <summary>
			/// The specified folders or files are part of the file system (that is, they are files, directories, or root directories). The parsed names of the
			/// items can be assumed to be valid Win32 file system paths. These paths can be either UNC or drive-letter based.
			/// </summary>
			SFGAO_FILESYSTEM = 0x40000000,

			/// <summary>
			/// The specified items are folders. Some items can be flagged with both SFGAO_STREAM and SFGAO_FOLDER, such as a compressed file with a .zip file
			/// name extension. Some applications might include this flag when testing for items that are both files and containers.
			/// </summary>
			SFGAO_FOLDER = 0x20000000,

			/// <summary>The specified items are shown as dimmed and unavailable to the user.</summary>
			SFGAO_GHOSTED = 0x8000,

			/// <summary>The specified items have property sheets.</summary>
			SFGAO_HASPROPSHEET = 0x40,

			/// <summary>Not supported.</summary>
			SFGAO_HASSTORAGE = 0x400000,

			/// <summary>
			/// The specified folders have subfolders. The SFGAO_HASSUBFOLDER attribute is only advisory and might be returned by Shell folder implementations
			/// even if they do not contain subfolders. Note, however, that the converse—failing to return SFGAO_HASSUBFOLDER—definitively states that the folder
			/// objects do not have subfolders.
			/// <para>
			/// Returning SFGAO_HASSUBFOLDER is recommended whenever a significant amount of time is required to determine whether any subfolders exist. For
			/// example, the Shell always returns SFGAO_HASSUBFOLDER when a folder is located on a network drive.
			/// </para>
			/// </summary>
			SFGAO_HASSUBFOLDER = 0x80000000,

			/// <summary>The item is hidden and should not be displayed unless the Show hidden files and folders option is enabled in Folder Settings.</summary>
			SFGAO_HIDDEN = 0x80000,

			/// <summary>
			/// Accessing the item (through IStream or other storage interfaces) is expected to be a slow operation. Applications should avoid accessing items
			/// flagged with SFGAO_ISSLOW. <note>Opening a stream for an item is generally a slow operation at all times. SFGAO_ISSLOW indicates that it is
			/// expected to be especially slow, for example in the case of slow network connections or offline (FILE_ATTRIBUTE_OFFLINE) files. However, querying
			/// SFGAO_ISSLOW is itself a slow operation. Applications should query SFGAO_ISSLOW only on a background thread. An alternate method, such as
			/// retrieving the PKEY_FileAttributes property and testing for FILE_ATTRIBUTE_OFFLINE, could be used in place of a method call that involves SFGAO_ISSLOW.</note>
			/// </summary>
			SFGAO_ISSLOW = 0x4000,

			/// <summary>The specified items are shortcuts.</summary>
			SFGAO_LINK = 0x10000,

			/// <summary>The items contain new content, as defined by the particular application.</summary>
			SFGAO_NEWCONTENT = 0x200000,

			/// <summary>
			/// The items are nonenumerated items and should be hidden. They are not returned through an enumerator such as that created by the
			/// IShellFolder::EnumObjects method.
			/// </summary>
			SFGAO_NONENUMERATED = 0x100000,

			/// <summary>
			/// Mask used by the PKEY_SFGAOFlags property to determine attributes that are considered to cause slow calculations or lack context: SFGAO_ISSLOW,
			/// SFGAO_READONLY, SFGAO_HASSUBFOLDER, and SFGAO_VALIDATE. Callers normally do not use this value.
			/// </summary>
			SFGAO_PKEYSFGAOMASK = 0x81044000,

			/// <summary>
			/// The specified items are read-only. In the case of folders, this means that new items cannot be created in those folders. This should not be
			/// confused with the behavior specified by the FILE_ATTRIBUTE_READONLY flag retrieved by IColumnProvider::GetItemData in a SHCOLUMNDATA structure.
			/// FILE_ATTRIBUTE_READONLY has no meaning for Win32 file system folders.
			/// </summary>
			SFGAO_READONLY = 0x40000,

			/// <summary>The specified items are on removable media or are themselves removable devices.</summary>
			SFGAO_REMOVABLE = 0x2000000,

			/// <summary>The specified objects are shared.</summary>
			SFGAO_SHARE = 0x20000,

			/// <summary>
			/// The specified items can be bound to an IStorage object through IShellFolder::BindToObject. For more information about namespace manipulation
			/// capabilities, see IStorage.
			/// </summary>
			SFGAO_STORAGE = 8,

			/// <summary>Children of this item are accessible through IStream or IStorage. Those children are flagged with SFGAO_STORAGE or SFGAO_STREAM.</summary>
			SFGAO_STORAGEANCESTOR = 0x800000,

			/// <summary>
			/// This flag is a mask for the storage capability attributes: SFGAO_STORAGE, SFGAO_LINK, SFGAO_READONLY, SFGAO_STREAM, SFGAO_STORAGEANCESTOR,
			/// SFGAO_FILESYSANCESTOR, SFGAO_FOLDER, and SFGAO_FILESYSTEM. Callers normally do not use this value.
			/// </summary>
			SFGAO_STORAGECAPMASK = 0x70c50008,

			/// <summary>
			/// Indicates that the item has a stream associated with it. That stream can be accessed through a call to IShellFolder::BindToObject or
			/// IShellItem::BindToHandler with IID_IStream in the riid parameter.
			/// </summary>
			SFGAO_STREAM = 0x400000,

			/// <summary>Windows 7 and later. The specified items are system items.</summary>
			SFGAO_SYSTEM = 0x00001000,

			/// <summary>
			/// When specified as input, SFGAO_VALIDATE instructs the folder to validate that the items contained in a folder or Shell item array exist. If one
			/// or more of those items do not exist, IShellFolder::GetAttributesOf and IShellItemArray::GetAttributes return a failure code. This flag is never
			/// returned as an [out] value.
			/// <para>
			/// When used with the file system folder, SFGAO_VALIDATE instructs the folder to discard cached properties retrieved by clients of
			/// IShellFolder2::GetDetailsEx that might have accumulated for the specified items.
			/// </para>
			/// </summary>
			SFGAO_VALIDATE = 0x1000000
		}

		/// <summary>Determines the types of items included in an enumeration. These values are used with the IShellFolder::EnumObjects method.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762539")]
		[Flags]
		public enum SHCONTF
		{
			/// <summary>Windows 7 and later. The calling application is checking for the existence of child items in the folder.</summary>
			SHCONTF_CHECKING_FOR_CHILDREN = 0x00010,

			/// <summary>Include items that are folders in the enumeration.</summary>
			SHCONTF_FOLDERS = 0x00020,

			/// <summary>Include items that are not folders in the enumeration.</summary>
			SHCONTF_NONFOLDERS = 0x00040,

			/// <summary>Include hidden items in the enumeration. This does not include hidden system items. (To include hidden system items, use SHCONTF_INCLUDESUPERHIDDEN.)</summary>
			SHCONTF_INCLUDEHIDDEN = 0x00080,

			/// <summary>
			/// No longer used; always assumed. IShellFolder::EnumObjects can return without validating the enumeration object. Validation can be postponed until
			/// the first call to IEnumIDList::Next. Use this flag when a user interface might be displayed prior to the first IEnumIDList::Next call. For a user
			/// interface to be presented, hwnd must be set to a valid window handle.
			/// </summary>
			SHCONTF_INIT_ON_FIRST_NEXT = 0x00100,

			/// <summary>The calling application is looking for printer objects.</summary>
			SHCONTF_NETPRINTERSRCH = 0x00200,

			/// <summary>The calling application is looking for resources that can be shared.</summary>
			SHCONTF_SHAREABLE = 0x00400,

			/// <summary>Include items with accessible storage and their ancestors, including hidden items.</summary>
			SHCONTF_STORAGE = 0x00800,

			/// <summary>Windows 7 and later. Child folders should provide a navigation enumeration.</summary>
			SHCONTF_NAVIGATION_ENUM = 0x01000,

			/// <summary>Windows Vista and later. The calling application is looking for resources that can be enumerated quickly.</summary>
			SHCONTF_FASTITEMS = 0x02000,

			/// <summary>Windows Vista and later. Enumerate items as a simple list even if the folder itself is not structured in that way.</summary>
			SHCONTF_FLATLIST = 0x04000,

			/// <summary>
			/// Windows Vista and later. The calling application is monitoring for change notifications. This means that the enumerator does not have to return
			/// all results. Items can be reported through change notifications.
			/// </summary>
			SHCONTF_ENABLE_ASYNC = 0x08000,

			/// <summary>
			/// Windows 7 and later. Include hidden system items in the enumeration. This value does not include hidden non-system items. (To include hidden
			/// non-system items, use SHCONTF_INCLUDEHIDDEN.)
			/// </summary>
			SHCONTF_INCLUDESUPERHIDDEN = 0x10000
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

		/// <summary>
		/// Defines the values used with the IShellFolder::GetDisplayNameOf and IShellFolder::SetNameOf methods to specify the type of file or folder names used
		/// by those methods.
		/// </summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762541")]
		[Flags]
		public enum SHGDNF
		{
			/// <summary>The name is displayed in an address bar combo box.</summary>
			SHGDN_FORADDRESSBAR = 0x4000,

			/// <summary>The name is used for in-place editing when the user renames the item.</summary>
			SHGDN_FOREDITING = 0x1000,

			/// <summary>
			/// The name is used for parsing. That is, it can be passed to IShellFolder::ParseDisplayName to recover the object's PIDL. The form this name takes
			/// depends on the particular object. When SHGDN_FORPARSING is used alone, the name is relative to the desktop. When combined with SHGDN_INFOLDER,
			/// the name is relative to the folder from which the request was made.
			/// </summary>
			SHGDN_FORPARSING = 0x8000,

			/// <summary>
			/// The name is relative to the folder from which the request was made. This is the name display to the user when used in the context of the folder.
			/// For example, it is used in the view and in the address bar path segment for the folder. This name should not include disambiguation
			/// information—for instance "username" instead of "username (on Machine)" for a particular user's folder. Use this flag in combinations with
			/// SHGDN_FORPARSING and SHGDN_FOREDITING.
			/// </summary>
			SHGDN_INFOLDER = 1,

			/// <summary>
			/// When not combined with another flag, return the parent-relative name that identifies the item, suitable for displaying to the user. This name
			/// often does not include extra information such as the file name extension and does not need to be unique. This name might include information that
			/// identifies the folder that contains the item. For instance, this flag could cause IShellFolder::GetDisplayNameOf to return the string "username
			/// (on Machine)" for a particular user's folder.
			/// </summary>
			SHGDN_NORMAL = 0
		}

		/// <summary>
		/// If the array contains a single item, this method provides the same results as GetAttributes. However, if the array contains multiple items, the
		/// attribute sets of all the items are combined into a single attribute set and returned in the value pointed to by psfgaoAttribs. This parameter takes
		/// one of the following values to define how that final attribute set is determined:
		/// </summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761096")]
		public enum SIATTRIBFLAGS
		{
			/// <summary>If there are multiple items in the array, use a bitwise AND to combine the attributes across items. For instance, if the array contains
			/// two items where one item can be moved (SFGAO_CANMOVE) and a second item cannot, the method returns (1 & 0) or 0 for that attribute bit.</summary>
			SIATTRIBFLAGS_AND = 1,

			/// <summary>
			/// Retrieve the attributes directly from the Shell data source. To use this value, the Shell item array must have been initialized as an
			/// IShellFolder with its contents specified as an array of child PIDLs.
			/// </summary>
			SIATTRIBFLAGS_APPCOMPAT = 3,

			/// <summary>
			/// If there are multiple items in the array, use a bitwise OR to combine the attributes across items. For instance, if the array contains two items
			/// where one item can be moved (SFGAO_CANMOVE) and a second item cannot, the method returns (1 | 0) or 1 for that attribute bit.
			/// </summary>
			SIATTRIBFLAGS_OR = 2,

			/// <summary>
			/// Windows 7 and later. Examine all items in the array to compute the attributes. Note that this can result in poor performance over large arrays
			/// and therefore it should be used only when needed. Cases in which you pass this flag should be extremely rare. See Remarks for more details.
			/// </summary>
			SIATTRIBFLAGS_ALLITEMS = 0x00004000,
		}

		/// <summary>Used to determine how to compare two Shell items. IShellItem::Compare uses this enumerated type.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762543")]
		[Flags]
		public enum SICHINTF : uint
		{
			/// <summary>Exact comparison of two instances of a Shell item.</summary>
			SICHINT_ALLFIELDS = 0x80000000,

			/// <summary>
			/// This relates to the iOrder parameter of the IShellItem::Compare interface and indicates that the comparison is based on a canonical name.
			/// </summary>
			SICHINT_CANONICAL = 0x10000000,

			/// <summary>
			/// This relates to the iOrder parameter of the IShellItem::Compare interface and indicates that the comparison is based on the display in a folder view.
			/// </summary>
			SICHINT_DISPLAY = 0,

			/// <summary>Windows 7 and later. If the Shell items are not the same, test the file system paths.</summary>
			SICHINT_TEST_FILESYSPATH_IF_NOT_EQUAL = 0x20000000
		}

		/// <summary>Requests the form of an item's display name to retrieve through IShellItem::GetDisplayName and SHGetNameFromIDList.</summary>
		/// <remarks>
		/// Different forms of an item's name can be retrieved through the item's properties, including those listed here. Note that not all properties are
		/// present on all items, so only those appropriate to the item will appear.
		/// </remarks>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762502")]
		public enum SIGDN : uint
		{
			/// <summary>Returns the editing name relative to the desktop. In UI this name is suitable for display to the user.</summary>
			SIGDN_DESKTOPABSOLUTEEDITING = 0x8004c000,

			/// <summary>Returns the parsing name relative to the desktop. This name is not suitable for use in UI.</summary>
			SIGDN_DESKTOPABSOLUTEPARSING = 0x80028000,

			/// <summary>
			/// Returns the item's file system path, if it has one. Only items that report SFGAO_FILESYSTEM have a file system path. When an item does not have a
			/// file system path, a call to IShellItem::GetDisplayName on that item will fail. In UI this name is suitable for display to the user in some cases,
			/// but note that it might not be specified for all items.
			/// </summary>
			SIGDN_FILESYSPATH = 0x80058000,

			/// <summary>Returns the display name relative to the parent folder. In UI this name is generally ideal for display to the user.</summary>
			SIGDN_NORMALDISPLAY = 0,

			/// <summary>Returns the path relative to the parent folder.</summary>
			SIGDN_PARENTRELATIVE = 0x80080001,

			/// <summary>Returns the editing name relative to the parent folder. In UI this name is suitable for display to the user.</summary>
			SIGDN_PARENTRELATIVEEDITING = 0x80031001,

			/// <summary>
			/// Returns the path relative to the parent folder in a friendly format as displayed in an address bar. This name is suitable for display to the user.
			/// </summary>
			SIGDN_PARENTRELATIVEFORADDRESSBAR = 0x8007c001,

			/// <summary>Introduced in Windows 8.</summary>
			SIGDN_PARENTRELATIVEFORUI = 0x80094001,

			/// <summary>Returns the parsing name relative to the parent folder. This name is not suitable for use in UI.</summary>
			SIGDN_PARENTRELATIVEPARSING = 0x80018001,

			/// <summary>
			/// Returns the item's URL, if it has one. Some items do not have a URL, and in those cases a call to IShellItem::GetDisplayName will fail. This name
			/// is suitable for display to the user in some cases, but note that it might not be specified for all items.
			/// </summary>
			SIGDN_URL = 0x80068000
		}

		/// <summary>Flags that specify the type of path information to retrieve. This parameter can be a combination of the following values.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb774944")]
		[Flags]
		public enum SLGP
		{
			/// <summary>Retrieves the standard short (8.3 format) file name.</summary>
			SLGP_SHORTPATH = 1,

			/// <summary>Unsupported; do not use.</summary>
			SLGP_UNCPRIORITY = 2,

			/// <summary>
			/// Retrieves the raw path name. A raw path is something that might not exist and may include environment variables that need to be expanded.
			/// </summary>
			SLGP_RAWPATH = 4,

			/// <summary>
			/// Windows Vista and later. Retrieves the path, if possible, of the shortcut's target relative to the path set by a previous call to IShellLink::SetRelativePath.
			/// </summary>
			SLGP_RELATIVEPRIORITY = 8
		}

		/// <summary>Action flags.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb774952")]
		[Flags]
		public enum SLR_FLAGS
		{
			/// <summary>No action.</summary>
			SLR_NONE = 0,

			/// <summary>
			/// Do not display a dialog box if the link cannot be resolved. When SLR_NO_UI is set, the high-order word of fFlags can be set to a time-out value
			/// that specifies the maximum amount of time to be spent resolving the link. The function returns if the link cannot be resolved within the time-out
			/// duration. If the high-order word is set to zero, the time-out duration will be set to the default value of 3,000 milliseconds (3 seconds). To
			/// specify a value, set the high word of fFlags to the desired time-out duration, in milliseconds.
			/// </summary>
			SLR_NO_UI = 0x1,

			/// <summary>Not used.</summary>
			SLR_ANY_MATCH = 0x2,

			/// <summary>
			/// If the link object has changed, update its path and list of identifiers. If SLR_UPDATE is set, you do not need to call IPersistFile::IsDirty to
			/// determine whether the link object has changed.
			/// </summary>
			SLR_UPDATE = 0x4,

			/// <summary>Do not update the link information.</summary>
			SLR_NOUPDATE = 0x8,

			/// <summary>Do not execute the search heuristics.</summary>
			SLR_NOSEARCH = 0x10,

			/// <summary>Do not use distributed link tracking.</summary>
			SLR_NOTRACK = 0x20,

			/// <summary>
			/// Disable distributed link tracking. By default, distributed link tracking tracks removable media across multiple devices based on the volume name.
			/// It also uses the UNC path to track remote file systems whose drive letter has changed. Setting SLR_NOLINKINFO disables both types of tracking.
			/// </summary>
			SLR_NOLINKINFO = 0x40,

			/// <summary>Call the Windows Installer.</summary>
			SLR_INVOKE_MSI = 0x80,

			/// <summary>Windows XP and later.</summary>
			SLR_NO_UI_WITH_MSG_PUMP = 0x101,

			/// <summary>
			/// Windows 7 and later. Offer the option to delete the shortcut when this method is unable to resolve it, even if the shortcut is not a shortcut to
			/// a file.
			/// </summary>
			SLR_OFFER_DELETE_WITHOUT_FILE = 0x200,

			/// <summary>
			/// Windows 7 and later. Report as dirty if the target is a known folder and the known folder was redirected. This only works if the original target
			/// path was a file system path or ID list and not an aliased known folder ID list.
			/// </summary>
			SLR_KNOWNFOLDER = 0x400,

			/// <summary>Windows 7 and later. Resolve the computer name in UNC targets that point to a local computer. This value is used with SLDF_KEEP_LOCAL_IDLIST_FOR_UNC_TARGET.</summary>
			SLR_MACHINE_IN_LOCAL_TARGET = 0x800,

			/// <summary>Windows 7 and later. Update the computer GUID and user SID if necessary.</summary>
			SLR_UPDATE_MACHINE_AND_SID = 0x1000,

			/// <summary></summary>
			SLR_NO_OBJECT_ID = 0x2000
		}

		/// <summary>Used by the ITaskbarList4::SetTabProperties method to specify tab properties.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd562320")]
		[Flags]
		public enum STPFLAG
		{
			/// <summary>
			/// No specific property values are specified. The default behavior is used: the tab window provides a thumbnail and peek image, either live or
			/// static as appropriate.
			/// </summary>
			STPF_NONE = 0,

			/// <summary>
			/// Always use the thumbnail provided by the main application frame window rather than a thumbnail provided by the individual tab window. Do not
			/// combine this value with STPF_USEAPPTHUMBNAILWHENACTIVE; doing so will result in an error.
			/// </summary>
			STPF_USEAPPTHUMBNAILALWAYS = 1,

			/// <summary>
			/// When the application tab is active and a live representation of its window is available, use the main application's frame window thumbnail. At
			/// other times, use the tab window thumbnail. Do not combine this value with STPF_USEAPPTHUMBNAILALWAYS; doing so will result in an error.
			/// </summary>
			STPF_USEAPPTHUMBNAILWHENACTIVE = 2,

			/// <summary>
			/// Always use the peek image provided by the main application frame window rather than a peek image provided by the individual tab window. Do not
			/// combine this value with STPF_USEAPPPEEKWHENACTIVE; doing so will result in an error.
			/// </summary>
			STPF_USEAPPPEEKALWAYS = 4,

			/// <summary>
			/// When the application tab is active and a live representation of its window is available, show the main application frame in the peek feature. At
			/// other times, use the tab window. Do not combine this value with STPF_USEAPPPEEKALWAYS; doing so will result in an error.
			/// </summary>
			STPF_USEAPPPEEKWHENACTIVE = 8,
		}

		/// <summary>
		/// Flags that control the current state of the progress button. Specify only one of the following flags; all states are mutually exclusive of all others.
		/// </summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd391697")]
		[Flags]
		public enum TBPFLAG
		{
			/// <summary>
			/// The progress indicator turns red to show that an error has occurred in one of the windows that is broadcasting progress. This is a determinate
			/// state. If the progress indicator is in the indeterminate state, it switches to a red determinate display of a generic percentage not indicative
			/// of actual progress.
			/// </summary>
			TBPF_ERROR = 4,

			/// <summary>
			/// The progress indicator does not grow in size, but cycles repeatedly along the length of the taskbar button. This indicates activity without
			/// specifying what proportion of the progress is complete. Progress is taking place, but there is no prediction as to how long the operation will take.
			/// </summary>
			TBPF_INDETERMINATE = 1,

			/// <summary>
			/// Stops displaying progress and returns the button to its normal state. Call this method with this flag to dismiss the progress bar when the
			/// operation is complete or canceled.
			/// </summary>
			TBPF_NOPROGRESS = 0,

			/// <summary>
			/// The progress indicator grows in size from left to right in proportion to the estimated amount of the operation completed. This is a determinate
			/// progress indicator; a prediction is being made as to the duration of the operation.
			/// </summary>
			TBPF_NORMAL = 2,

			/// <summary>
			/// The progress indicator turns yellow to show that progress is currently stopped in one of the windows but can be resumed by the user. No error
			/// condition exists and nothing is preventing the progress from continuing. This is a determinate state. If the progress indicator is in the
			/// indeterminate state, it switches to a yellow determinate display of a generic percentage not indicative of actual progress.
			/// </summary>
			TBPF_PAUSED = 8
		}

		/// <summary>Used by THUMBBUTTON to control specific states and behaviors of the button.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd562321")]
		[Flags]
		public enum THUMBBUTTONFLAGS : uint
		{
			/// <summary>The button is disabled. It is present, but has a visual state that indicates that it will not respond to user action.</summary>
			THBF_DISABLED = 1,

			/// <summary>When the button is clicked, the taskbar button's flyout closes immediately.</summary>
			THBF_DISMISSONCLICK = 2,

			/// <summary>The button is active and available to the user.</summary>
			THBF_ENABLED = 0,

			/// <summary>The button is not shown to the user.</summary>
			THBF_HIDDEN = 8,

			/// <summary>Do not draw a button border, use only the image.</summary>
			THBF_NOBACKGROUND = 4,

			/// <summary>
			/// The button is enabled but not interactive; no pressed button state is drawn. This value is intended for instances where the button is used in a notification.
			/// </summary>
			THBF_NONINTERACTIVE = 0x10
		}

		/// <summary>Used by the THUMBBUTTON structure to specify which members of that structure contain valid data.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd562322")]
		[Flags]
		public enum THUMBBUTTONMASK : uint
		{
			/// <summary>The iBitmap member contains valid information.</summary>
			THB_BITMAP = 1,

			/// <summary>The dwFlags member contains valid information.</summary>
			THB_FLAGS = 8,

			/// <summary>The hIcon member contains valid information.</summary>
			THB_ICON = 2,

			/// <summary>The szTip member contains valid information.</summary>
			THB_TOOLTIP = 4
		}

		/// <summary>Exposes methods that allow an application to remove one or all destinations from the Recent or Frequent categories in a Jump List.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, Guid("12337d35-94c6-48a0-bce7-6a9c69d4d600"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378413")]
		public interface IApplicationDestinations
		{
			/// <summary>
			/// Specifies a unique AppUserModelID for the application from whose taskbar button's Jump List the methods of this interface will remove
			/// destinations. This method is optional.
			/// </summary>
			/// <param name="pszAppID">Pointer to the AppUserModelID of the process whose taskbar button representation receives the Jump List.</param>
			void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

			/// <summary>Removes a single destination from the Recent and Frequent categories in a Jump List.</summary>
			/// <param name="punk">A pointer to the IShellItem or IShellLink that represents the destination to remove.</param>
			void RemoveDestination([MarshalAs(UnmanagedType.IUnknown)] object punk);

			/// <summary>Clears all destination entries from the Recent and Frequent categories in an application's Jump List.</summary>
			void RemoveAllDestinations();
		}

		/// <summary>Allows an application to retrieve the most recent and frequent documents opened in that app, as reported via SHAddToRecentDocs</summary>
		/// <securitynote>Critical: Suppresses unmanaged code security.</securitynote>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("3c594f9f-9f30-47a1-979a-c9e83d3d0a06")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762502")]
		public interface IApplicationDocumentLists
		{
			/// <summary>
			/// Set the App User Model ID for the application retrieving this list. If an AppID is not provided via this method, the system will use a
			/// heuristically determined ID. This method must be called before GetList.
			/// </summary>
			/// <param name="pszAppID">App Id.</param>
			void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

			/// <summary>Retrieve an IEnumObjects or IObjectArray for IShellItems and/or IShellLinks. Items may appear in both the frequent and recent lists.</summary>
			/// <param name="listtype">Which of the known list types to retrieve</param>
			/// <param name="cItemsDesired">The number of items desired.</param>
			/// <param name="riid">The interface Id that the return value should be queried for.</param>
			/// <returns>A COM object based on the IID passed for the riid parameter.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetList(APPDOCLISTTYPE listtype, uint cItemsDesired, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
		}

		/// <summary>Exposes methods that allow an application to provide a custom Jump List, including destinations and tasks, for display in the taskbar.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6332debf-87b5-4670-90c0-5e57b408a49e"), CoClass(typeof(CDestinationList))]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378402")]
		public interface ICustomDestinationList
		{
			/// <summary>
			/// Specifies a unique Application User Model ID (AppUserModelID) for the application whose taskbar button will hold the custom Jump List built
			/// through the methods of this interface. This method is optional.
			/// </summary>
			/// <param name="pszAppID">A pointer to the AppUserModelID of the process or application whose taskbar representation receives the Jump List.</param>
			void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

			/// <summary>Initiates a building session for a custom Jump List.</summary>
			/// <param name="pcMaxSlots">
			/// A pointer that, when this method returns, points to the current user setting for the Number of recent items to display in Jump Lists option in
			/// the Taskbar and Start Menu Properties window. The default value is 10. This is the maximum number of destinations that will be shown, and it is a
			/// total of all destinations, regardless of category. More destinations can be added, but they will not be shown in the UI.
			/// <para>A Jump List will always show at least this many slots—destinations and, if there is room, tasks.</para>
			/// <para>
			/// This number does not include separators and section headers as long as the total number of separators and headers does not exceed four.
			/// Separators and section headers beyond the first four might reduce the number of destinations displayed if space is constrained. This number does
			/// not affect the standard command entries for pinning or unpinning, closing the window, or launching a new instance. It also does not affect tasks
			/// or pinned items, the number of which that can be displayed is based on the space available to the Jump List.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// A reference to the IID of an interface to be retrieved in ppv, typically IID_IObjectArray, that will represent all items currently stored in the
			/// list of removed destinations for the application. This information is used to ensure that removed items are not part of the new Jump List.
			/// </param>
			/// <returns>
			/// When this method returns, contains the interface pointer requested in riid. This is typically an IObjectArray, which represents a collection of
			/// IShellItem and IShellLink objects that represent the removed items.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object BeginList(out uint pcMaxSlots, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Defines a custom category and the destinations that it contains, for inclusion in a custom Jump List.</summary>
			/// <param name="pszCategory">
			/// A pointer to a string that contains the display name of the custom category. This string is shown in the category's header in the Jump List. The
			/// string can directly hold the display name or it can be an indirect string representation, such as "@shell32.dll,-1324", to use a stored string.
			/// An indirect string enables the category header to be displayed in the user's selected language. <note>Each custom category must have a unique
			/// name. Duplicate category names will cause presentation issues in the Jump List.</note>
			/// </param>
			/// <param name="poa">
			/// A pointer to an IObjectArray that represents one or more IShellItem objects that represent the destinations in the category. Some destinations in
			/// the list might also be represented by IShellLink objects, although less often. <note>Any IShellLink used here must declare an argument list
			/// through SetArguments. Adding an IShellLink object with no arguments to a custom category is not supported since a user cannot pin or unpin this
			/// type of item from a Jump List, nor can they be added or removed.</note>
			/// </param>
			void AppendCategory([MarshalAs(UnmanagedType.LPWStr)] string pszCategory, IObjectArray poa);

			/// <summary>Specifies that the Frequent or Recent category should be included in a custom Jump List.</summary>
			/// <param name="category">One of the KNOWNDESTCATEGORY values that indicate which known category to add to the list.</param>
			void AppendKnownCategory(KNOWNDESTCATEGORY category);

			/// <summary>Specifies items to include in the Tasks category of a custom Jump List.</summary>
			/// <param name="poa">
			/// A pointer to an IObjectArray that represents one or more IShellLink (or, more rarely, IShellItem) objects that represent the tasks. <note>Any
			/// IShellLink used here must declare an argument list through SetArguments. Adding an IShellLink object with no arguments to a custom category is
			/// not supported. A user cannot pin or unpin this type of item from a Jump List, nor can they be added or removed.</note>
			/// </param>
			void AddUserTasks(IObjectArray poa);

			/// <summary>Declares that the Jump List initiated by a call to ICustomDestinationList::BeginList is complete and ready for display.</summary>
			void CommitList();

			/// <summary>
			/// Retrieves the current list of destinations that have been removed by the user from the existing Jump List that this custom Jump List is meant to replace.
			/// </summary>
			/// <param name="riid">A reference to the IID of the interface to retrieve through ppv, typically IID_IObjectArray.</param>
			/// <returns>
			/// When this method returns, contains the interface pointer requested in riid. This is typically an IObjectArray, which represents a collection of
			/// IShellItem or IShellLink objects that represent the items in the list of removed destinations.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetRemovedDestinations([In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Deletes a custom Jump List for a specified application.</summary>
			/// <param name="pszAppID">
			/// A pointer to the AppUserModelID of the process whose taskbar button representation displays the custom Jump List. In the beta release of Windows
			/// 7, this AppUserModelID must be explicitly provided because this method is intended to be called from an uninstaller, which runs in a separate
			/// process. Because it is in a separate process, the system cannot reliably deduce the AppUserModelID. This restriction is expected to be removed in
			/// later releases.
			/// </param>
			void DeleteList([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

			/// <summary>Discontinues a Jump List building session initiated by ICustomDestinationList::BeginList without committing any changes.</summary>
			void AbortList();
		}

		/// <summary>
		/// Exposes a standard set of methods used to enumerate the pointers to item identifier lists (PIDLs) of the items in a Shell folder. When a folder's
		/// IShellFolder::EnumObjects method is called, it creates an enumeration object and passes a pointer to the object's IEnumIDList interface back to the
		/// calling application.
		/// </summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214F2-0000-0000-C000-000000000046")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761982")]
		public interface IEnumIDList
		{
			/// <summary>
			/// Retrieves the specified number of item identifiers in the enumeration sequence and advances the current position by the number of items retrieved.
			/// </summary>
			/// <param name="celt">The number of elements in the array referenced by the rgelt parameter.</param>
			/// <param name="rgelt">
			/// The address of a pointer to an array of ITEMIDLIST pointers that receive the item identifiers. The implementation must allocate these item
			/// identifiers using CoTaskMemAlloc. The calling application is responsible for freeing the item identifiers using CoTaskMemFree.
			/// </param>
			/// <param name="pceltFetched">
			/// A pointer to a value that receives a count of the item identifiers actually returned in rgelt. The count can be smaller than the value specified
			/// in the celt parameter. This parameter can be NULL on entry only if celt = 1, because in that case the method can only retrieve one (S_OK) or zero
			/// (S_FALSE) items.
			/// </param>
			/// <returns>
			/// Returns S_OK if the method successfully retrieved the requested celt elements. This method only returns S_OK if the full count of requested items
			/// are successfully retrieved. S_FALSE indicates that more items were requested than remained in the enumeration.The value pointed to by the
			/// pceltFetched parameter specifies the actual number of items retrieved. Note that the value will be 0 if there are no more items to retrieve.
			/// </returns>
			[PreserveSig]
			HRESULT Next(uint celt, out IntPtr rgelt, out uint pceltFetched);

			/// <summary>Skips the specified number of elements in the enumeration sequence.</summary>
			/// <param name="celt">The number of item identifiers to skip.</param>
			void Skip(uint celt);

			/// <summary>Returns to the beginning of the enumeration sequence.</summary>
			void Reset();

			/// <summary>Creates a new item enumeration object with the same contents and state as the current one.</summary>
			/// <returns>
			/// The address of a pointer to the new enumeration object. The calling application must eventually free the new object by calling its Release member function.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumIDList Clone();
		}

		/// <summary>Exposes enumeration of IShellItem interfaces. This interface is typically obtained by calling the IEnumShellItems method.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("70629033-e363-4a28-a567-0db78006e6d7")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761962")]
		public interface IEnumShellItems
		{
			/// <summary>Gets an array of one or more IShellItem interfaces from the enumeration.</summary>
			/// <param name="celt">The number of elements in the array referenced by the rgelt parameter.</param>
			/// <param name="rgelt">
			/// The address of an array of pointers to IShellItem interfaces that receive the enumerated item or items. The calling application is responsible
			/// for freeing the IShellItem interfaces by calling the IUnknown::Release method.
			/// </param>
			/// <param name="pceltFetched">
			/// A pointer to a value that receives the number of IShellItem interfaces successfully retrieved. The count can be smaller than the value specified
			/// in the celt parameter. This parameter can be NULL on entry only if celt is one, because in that case the method can only retrieve one item and
			/// return S_OK, or zero items and return S_FALSE.
			/// </param>
			/// <returns>
			/// Returns S_OK if the method successfully retrieved the requested celt elements. This method only returns S_OK if the full count of requested items
			/// are successfully retrieved. S_FALSE indicates that more items were requested than remained in the enumeration. The value pointed to by the
			/// pceltFetched parameter specifies the actual number of items retrieved. Note that the value will be 0 if there are no more items to retrieve.
			/// </returns>
			[PreserveSig]
			HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] IShellItem[] rgelt, out uint pceltFetched);

			/// <summary>Skips the specified number of elements in the enumeration sequence.</summary>
			/// <param name="celt">The number of IShellItem interfaces to skip.</param>
			void Skip(uint celt);

			/// <summary>Returns to the beginning of the enumeration sequence.</summary>
			void Reset();

			/// <summary>Gets a copy of the current enumeration.</summary>
			/// <returns>The address of a pointer that receives a copy of this enumeration.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumShellItems Clone();
		}

		/// <summary></summary>
		/// <seealso cref="Vanara.PInvoke.IModalWindow"/>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("42f85136-db7e-439c-85f1-e4075d135fc8")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775966")]
		public interface IFileDialog : IModalWindow
		{
			/// <summary>Launches the modal window.</summary>
			/// <param name="parent">The handle of the owner window. This value can be NULL.</param>
			/// <returns>
			/// If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code, including the following:
			/// HRESULT_FROM_WIN32(ERROR_CANCELLED) = The user closed the window by canceling the operation.
			/// </returns>
			[PreserveSig]
			new HRESULT Show(IntPtr parent);

			/// <summary>Sets the file types that the dialog can open or save.</summary>
			/// <param name="cFileTypes">The number of elements in the array specified by rgFilterSpec.</param>
			/// <param name="rgFilterSpec">A pointer to an array of COMDLG_FILTERSPEC structures, each representing a file type.</param>
			void SetFileTypes(uint cFileTypes,
				[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] COMDLG_FILTERSPEC[] rgFilterSpec);

			/// <summary>Sets the file type that appears as selected in the dialog.</summary>
			/// <param name="iFileType">
			/// The index of the file type in the file type array passed to IFileDialog::SetFileTypes in its cFileTypes parameter. Note that this is a one-based
			/// index, not zero-based.
			/// </param>
			void SetFileTypeIndex(uint iFileType);

			/// <summary>Gets the currently selected file type.</summary>
			/// <returns>
			/// A UINT value that receives the index of the selected file type in the file type array passed to IFileDialog::SetFileTypes in its cFileTypes parameter.
			/// </returns>
			uint GetFileTypeIndex();

			/// <summary>Assigns an event handler that listens for events coming from the dialog.</summary>
			/// <param name="pfde">A pointer to an IFileDialogEvents implementation that will receive events from the dialog.</param>
			/// <returns>
			/// A DWORD value identiying this event handler. When the client is finished with the dialog, that client must call the IFileDialog::Unadvise method
			/// with this value.
			/// </returns>
			uint Advise(IFileDialogEvents pfde);

			/// <summary>Removes an event handler that was attached through the IFileDialog::Advise method.</summary>
			/// <param name="dwCookie">
			/// The DWORD value that represents the event handler. This value is obtained through the pdwCookie parameter of the IFileDialog::Advise method.
			/// </param>
			void Unadvise(uint dwCookie);

			/// <summary>Sets flags to control the behavior of the dialog.</summary>
			/// <param name="fos">One or more of the FILEOPENDIALOGOPTIONS values.</param>
			void SetOptions(FILEOPENDIALOGOPTIONS fos);

			/// <summary>Gets the current flags that are set to control dialog behavior.</summary>
			/// <returns>When this method returns successfully, points to a value made up of one or more of the FILEOPENDIALOGOPTIONS values.</returns>
			FILEOPENDIALOGOPTIONS GetOptions();

			/// <summary>Sets the folder used as a default if there is not a recently used folder value available.</summary>
			/// <param name="psi">A pointer to the interface that represents the folder.</param>
			void SetDefaultFolder(IShellItem psi);

			/// <summary>Sets a folder that is always selected when the dialog is opened, regardless of previous user action.</summary>
			/// <param name="psi">A pointer to the interface that represents the folder.</param>
			void SetFolder(IShellItem psi);

			/// <summary>
			/// Gets either the folder currently selected in the dialog, or, if the dialog is not currently displayed, the folder that is to be selected when the
			/// dialog is opened.
			/// </summary>
			/// <returns>The address of a pointer to the interface that represents the folder.</returns>
			IShellItem GetFolder();

			/// <summary>Gets the user's current selection in the dialog.</summary>
			/// <returns>
			/// The address of a pointer to the interface that represents the item currently selected in the dialog. This item can be a file or folder selected
			/// in the view window, or something that the user has entered into the dialog's edit box. The latter case may require a parsing operation
			/// (cancelable by the user) that blocks the current thread.
			/// </returns>
			IShellItem GetCurrentSelection();

			/// <summary>Sets the file name that appears in the File name edit box when that dialog box is opened.</summary>
			/// <param name="pszName">A pointer to the name of the file.</param>
			void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);

			/// <summary>Retrieves the text currently entered in the dialog's File name edit box.</summary>
			/// <returns>The address of a pointer to a buffer that, when this method returns successfully, receives the text.</returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetFileName();

			/// <summary>Sets the title of the dialog.</summary>
			/// <param name="pszTitle">A pointer to a buffer that contains the title text.</param>
			void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

			/// <summary>Sets the text of the Open or Save button.</summary>
			/// <param name="pszText">A pointer to a buffer that contains the button text.</param>
			void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);

			/// <summary>Sets the text of the label next to the file name edit box.</summary>
			/// <param name="pszLabel">A pointer to a buffer that contains the label text.</param>
			void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

			/// <summary>Gets the choice that the user made in the dialog.</summary>
			/// <returns>The address of a pointer to an IShellItem that represents the user's choice.</returns>
			IShellItem GetResult();

			/// <summary>Adds a folder to the list of places available for the user to open or save items.</summary>
			/// <param name="psi">A pointer to an IShellItem that represents the folder to be made available to the user. This can only be a folder.</param>
			/// <param name="fdap">Specifies where the folder is placed within the list.</param>
			void AddPlace(IShellItem psi, FDAP fdap);

			/// <summary>Sets the default extension to be added to file names.</summary>
			/// <param name="pszDefaultExtension">
			/// A pointer to a buffer that contains the extension text. This string should not include a leading period. For example, "jpg" is correct, while
			/// ".jpg" is not.
			/// </param>
			void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

			/// <summary>Closes the dialog.</summary>
			/// <param name="hr">The code that will be returned by Show to indicate that the dialog was closed before a selection was made.</param>
			void Close([MarshalAs(UnmanagedType.Error)] HRESULT hr);

			/// <summary>Enables a calling application to associate a GUID with a dialog's persisted state.</summary>
			/// <param name="guid">The GUID to associate with this dialog state.</param>
			void SetClientGuid([In, MarshalAs(UnmanagedType.LPStruct)] Guid guid);

			/// <summary>Instructs the dialog to clear all persisted state information.</summary>
			void ClearClientData();

			/// <summary>Sets the filter. <note>Deprecated. SetFilter is no longer available for use as of Windows 7.</note></summary>
			/// <param name="pFilter">A pointer to the IShellItemFilter that is to be set.</param>
			void SetFilter([MarshalAs(UnmanagedType.Interface)] object pFilter);
		}

		/// <summary>Exposes methods that allow notification of events within a common file dialog.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("973510DB-7D7F-452B-8975-74A85828D354")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775876")]
		public interface IFileDialogEvents
		{
			/// <summary>Called just before the dialog is about to return with a result.</summary>
			/// <param name="pfd">A pointer to the interface that represents the dialog.</param>
			/// <returns>
			/// Implementations should return S_OK to accept the current result in the dialog or S_FALSE to refuse it. In the case of S_FALSE, the dialog should
			/// remain open.
			/// </returns>
			/// <remarks>
			/// When this method is called, the IFileDialog::GetResult and GetResults methods can be called.
			/// <para>
			/// The application can use this callback method to perform additional validation before the dialog closes, or to prevent the dialog from closing. If
			/// the application prevents the dialog from closing, it should display a UI to indicate a cause. To obtain a parent HWND for the UI, obtain the
			/// IOleWindow interface through IFileDialog::QueryInterface and call IOleWindow::GetWindow.
			/// </para>
			/// <para>An application can also use this method to perform all of its work surrounding the opening or saving of files.</para>
			/// </remarks>
			[PreserveSig]
			HRESULT OnFileOk(IFileDialog pfd);

			/// <summary>Called before IFileDialogEvents::OnFolderChange. This allows the implementer to stop navigation to a particular location.</summary>
			/// <param name="pfd">A pointer to the interface that represents the dialog.</param>
			/// <param name="psiFolder">A pointer to an interface that represents the folder to which the dialog is about to navigate.</param>
			/// <returns>
			/// Returns S_OK if successful, or an error value otherwise. A return value of S_OK or E_NOTIMPL indicates that the folder change can proceed.
			/// </returns>
			/// <remarks>
			/// The calling application can call IFileDialog::SetFolder during this callback to redirect navigation to an alternate folder. The actual navigation
			/// does not occur until IFileDialogEvents::OnFolderChanging has returned.
			/// <para>
			/// If the calling application simply prevents navigation to a particular folder, UI should be displayed with an explanation of the restriction. To
			/// obtain a parent HWND for the UI, obtain the IOleWindow interface through IFileDialog and call IOleWindow::GetWindow.
			/// </para>
			/// </remarks>
			[PreserveSig]
			HRESULT OnFolderChanging(IFileDialog pfd, IShellItem psiFolder);

			/// <summary>Called when the user navigates to a new folder.</summary>
			/// <param name="pfd">A pointer to the interface that represents the dialog.</param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			[PreserveSig]
			HRESULT OnFolderChange(IFileDialog pfd);

			/// <summary>Called when the user changes the selection in the dialog's view.</summary>
			/// <param name="pfd">A pointer to the interface that represents the dialog.</param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			[PreserveSig]
			HRESULT OnSelectionChange(IFileDialog pfd);

			/// <summary>Enables an application to respond to sharing violations that arise from Open or Save operations.</summary>
			/// <param name="pfd">A pointer to the interface that represents the dialog.</param>
			/// <param name="psi">A pointer to the interface that represents the item that has the sharing violation.</param>
			/// <param name="pResponse">A pointer to a value from the FDE_SHAREVIOLATION_RESPONSE enumeration indicating the response to the sharing violation.</param>
			/// <returns>The implementer should return E_NOTIMPL if this method is not implemented; S_OK or an appropriate error code otherwise.</returns>
			/// <remarks>
			/// The FOS_SHAREAWARE flag must be set through IFileDialog::SetOptions before this method is called.
			/// <para>
			/// A sharing violation could possibly arise when the application attempts to open a file, because the file could have been locked between the time
			/// that the dialog tested it and the application opened it.
			/// </para>
			/// </remarks>
			[PreserveSig]
			HRESULT OnShareViolation(IFileDialog pfd, IShellItem psi, out FDE_SHAREVIOLATION_RESPONSE pResponse);

			/// <summary>Called when the dialog is opened to notify the application of the initial chosen filetype.</summary>
			/// <param name="pfd">A pointer to the interface that represents the dialog.</param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			/// <remarks>
			/// This method is called when the dialog is opened to notify the application of the initially chosen filetype. If the application has code in
			/// IFileDialogEvents that responds to type changes, it can respond to the type. For example, it could hide certain controls. The application
			/// controls the initial file type and could do its own checks, so this method is provided as a convenience.
			/// </remarks>
			[PreserveSig]
			HRESULT OnTypeChange(IFileDialog pfd);

			/// <summary>Called from the save dialog when the user chooses to overwrite a file.</summary>
			/// <param name="pfd">A pointer to the interface that represents the dialog.</param>
			/// <param name="psi">A pointer to the interface that represents the item that will be overwritten.</param>
			/// <param name="pResponse">
			/// A pointer to a value from the FDE_OVERWRITE_RESPONSE enumeration indicating the response to the potential overwrite action.
			/// </param>
			/// <returns>The implementer should return E_NOTIMPL if this method is not implemented; S_OK or an appropriate error code otherwise.</returns>
			/// <remarks>The FOS_OVERWRITEPROMPT flag must be set through IFileDialog::SetOptions before this method is called.</remarks>
			[PreserveSig]
			HRESULT OnOverwrite(IFileDialog pfd, IShellItem psi, out FDE_SHAREVIOLATION_RESPONSE pResponse);
		}

		/// <summary>Extends the IFileDialog interface by adding methods specific to the open dialog.</summary>
		/// <seealso cref="Vanara.PInvoke.IFileDialog"/>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("d57c7288-d4ad-4768-be02-9d969532d960")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775834")]
		public interface IFileOpenDialog : IFileDialog
		{
			/// <summary>Launches the modal window.</summary>
			/// <param name="parent">The handle of the owner window. This value can be NULL.</param>
			/// <returns>
			/// If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code, including the following:
			/// HRESULT_FROM_WIN32(ERROR_CANCELLED) = The user closed the window by canceling the operation.
			/// </returns>
			[PreserveSig]
			new HRESULT Show(IntPtr parent);

			/// <summary>Sets the file types that the dialog can open or save.</summary>
			/// <param name="cFileTypes">The number of elements in the array specified by rgFilterSpec.</param>
			/// <param name="rgFilterSpec">A pointer to an array of COMDLG_FILTERSPEC structures, each representing a file type.</param>
			new void SetFileTypes(uint cFileTypes,
				[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] COMDLG_FILTERSPEC[] rgFilterSpec);

			/// <summary>Sets the file type that appears as selected in the dialog.</summary>
			/// <param name="iFileType">
			/// The index of the file type in the file type array passed to IFileDialog::SetFileTypes in its cFileTypes parameter. Note that this is a one-based
			/// index, not zero-based.
			/// </param>
			new void SetFileTypeIndex(uint iFileType);

			/// <summary>Gets the currently selected file type.</summary>
			/// <returns>
			/// A UINT value that receives the index of the selected file type in the file type array passed to IFileDialog::SetFileTypes in its cFileTypes parameter.
			/// </returns>
			new uint GetFileTypeIndex();

			/// <summary>Assigns an event handler that listens for events coming from the dialog.</summary>
			/// <param name="pfde">A pointer to an IFileDialogEvents implementation that will receive events from the dialog.</param>
			/// <returns>
			/// A DWORD value identiying this event handler. When the client is finished with the dialog, that client must call the IFileDialog::Unadvise method
			/// with this value.
			/// </returns>
			new uint Advise(IFileDialogEvents pfde);

			/// <summary>Removes an event handler that was attached through the IFileDialog::Advise method.</summary>
			/// <param name="dwCookie">
			/// The DWORD value that represents the event handler. This value is obtained through the pdwCookie parameter of the IFileDialog::Advise method.
			/// </param>
			new void Unadvise(uint dwCookie);

			/// <summary>Sets flags to control the behavior of the dialog.</summary>
			/// <param name="fos">One or more of the FILEOPENDIALOGOPTIONS values.</param>
			new void SetOptions(FILEOPENDIALOGOPTIONS fos);

			/// <summary>Gets the current flags that are set to control dialog behavior.</summary>
			/// <returns>When this method returns successfully, points to a value made up of one or more of the FILEOPENDIALOGOPTIONS values.</returns>
			new FILEOPENDIALOGOPTIONS GetOptions();

			/// <summary>Sets the folder used as a default if there is not a recently used folder value available.</summary>
			/// <param name="psi">A pointer to the interface that represents the folder.</param>
			new void SetDefaultFolder(IShellItem psi);

			/// <summary>Sets a folder that is always selected when the dialog is opened, regardless of previous user action.</summary>
			/// <param name="psi">A pointer to the interface that represents the folder.</param>
			new void SetFolder(IShellItem psi);

			/// <summary>
			/// Gets either the folder currently selected in the dialog, or, if the dialog is not currently displayed, the folder that is to be selected when the
			/// dialog is opened.
			/// </summary>
			/// <returns>The address of a pointer to the interface that represents the folder.</returns>
			new IShellItem GetFolder();

			/// <summary>Gets the user's current selection in the dialog.</summary>
			/// <returns>
			/// The address of a pointer to the interface that represents the item currently selected in the dialog. This item can be a file or folder selected
			/// in the view window, or something that the user has entered into the dialog's edit box. The latter case may require a parsing operation
			/// (cancelable by the user) that blocks the current thread.
			/// </returns>
			new IShellItem GetCurrentSelection();

			/// <summary>Sets the file name that appears in the File name edit box when that dialog box is opened.</summary>
			/// <param name="pszName">A pointer to the name of the file.</param>
			new void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);

			/// <summary>Retrieves the text currently entered in the dialog's File name edit box.</summary>
			/// <returns>The address of a pointer to a buffer that, when this method returns successfully, receives the text.</returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetFileName();

			/// <summary>Sets the title of the dialog.</summary>
			/// <param name="pszTitle">A pointer to a buffer that contains the title text.</param>
			new void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

			/// <summary>Sets the text of the Open or Save button.</summary>
			/// <param name="pszText">A pointer to a buffer that contains the button text.</param>
			new void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);

			/// <summary>Sets the text of the label next to the file name edit box.</summary>
			/// <param name="pszLabel">A pointer to a buffer that contains the label text.</param>
			new void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

			/// <summary>Gets the choice that the user made in the dialog.</summary>
			/// <returns>The address of a pointer to an IShellItem that represents the user's choice.</returns>
			new IShellItem GetResult();

			/// <summary>Adds a folder to the list of places available for the user to open or save items.</summary>
			/// <param name="psi">A pointer to an IShellItem that represents the folder to be made available to the user. This can only be a folder.</param>
			/// <param name="fdap">Specifies where the folder is placed within the list.</param>
			new void AddPlace(IShellItem psi, FDAP fdap);

			/// <summary>Sets the default extension to be added to file names.</summary>
			/// <param name="pszDefaultExtension">
			/// A pointer to a buffer that contains the extension text. This string should not include a leading period. For example, "jpg" is correct, while
			/// ".jpg" is not.
			/// </param>
			new void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

			/// <summary>Closes the dialog.</summary>
			/// <param name="hr">The code that will be returned by Show to indicate that the dialog was closed before a selection was made.</param>
			new void Close([MarshalAs(UnmanagedType.Error)] HRESULT hr);

			/// <summary>Enables a calling application to associate a GUID with a dialog's persisted state.</summary>
			/// <param name="guid">The GUID to associate with this dialog state.</param>
			new void SetClientGuid([In, MarshalAs(UnmanagedType.LPStruct)] Guid guid);

			/// <summary>Instructs the dialog to clear all persisted state information.</summary>
			new void ClearClientData();

			/// <summary>Sets the filter. <note>Deprecated. SetFilter is no longer available for use as of Windows 7.</note></summary>
			/// <param name="pFilter">A pointer to the IShellItemFilter that is to be set.</param>
			new void SetFilter([MarshalAs(UnmanagedType.Interface)] object pFilter);

			/// <summary>Gets the user's choices in a dialog that allows multiple selection.</summary>
			/// <returns>The address of a pointer to an IShellItemArray through which the items selected in the dialog can be accessed.</returns>
			IShellItemArray GetResults();

			/// <summary>
			/// Gets the currently selected items in the dialog. These items may be items selected in the view, or text selected in the file name edit box.
			/// </summary>
			/// <returns>The address of a pointer to an IShellItemArray through which the selected items can be accessed.</returns>
			IShellItemArray GetSelectedItems();
		}

		/// <summary>
		/// Exposes methods that provide a rich notification system used by callers of IFileOperation to monitor the details of the operations they are
		/// performing through that interface.
		/// </summary>
		[ComImport, Guid("04b0f1a7-9490-44bc-96e1-4296a31252e2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775722")]
		public interface IFileOperationProgressSink
		{
			void StartOperations();

			void FinishOperations(uint hrResult);

			void PreRenameItem(uint dwFlags, IShellItem psiItem, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName);

			void PostRenameItem(uint dwFlags, IShellItem psiItem, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName,
				uint hrRename, IShellItem psiNewlyCreated);

			void PreMoveItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder,
				[MarshalAs(UnmanagedType.LPWStr)] string pszNewName);

			void PostMoveItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder,
				[MarshalAs(UnmanagedType.LPWStr)] string pszNewName, uint hrMove, IShellItem psiNewlyCreated);

			void PreCopyItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName);

			void PostCopyItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName,
				uint hrCopy, IShellItem psiNewlyCreated);

			void PreDeleteItem(uint dwFlags, IShellItem psiItem);

			void PostDeleteItem(uint dwFlags, IShellItem psiItem, uint hrDelete, IShellItem psiNewlyCreated);

			void PreNewItem(uint dwFlags, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName);

			void PostNewItem(uint dwFlags, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName,
				[MarshalAs(UnmanagedType.LPWStr)] string pszTemplateName, uint dwFileAttributes,
				uint hrNew, IShellItem psiNewItem);

			void UpdateProgress(uint iWorkTotal, uint iWorkSoFar);

			void ResetTimer();

			void PauseTimer();

			void ResumeTimer();
		}

		/// <summary>
		/// Extends the IFileDialog interface by adding methods specific to the save dialog, which include those that provide support for the collection of
		/// metadata to be persisted with the file.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.IFileDialog"/>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("84bccd23-5fde-4cdb-aea4-af64b83d78ab")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775688")]
		public interface IFileSaveDialog : IFileDialog
		{
			/// <summary>Launches the modal window.</summary>
			/// <param name="parent">The handle of the owner window. This value can be NULL.</param>
			/// <returns>
			/// If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code, including the following:
			/// HRESULT_FROM_WIN32(ERROR_CANCELLED) = The user closed the window by canceling the operation.
			/// </returns>
			[PreserveSig]
			new HRESULT Show(IntPtr parent);

			/// <summary>Sets the file types that the dialog can open or save.</summary>
			/// <param name="cFileTypes">The number of elements in the array specified by rgFilterSpec.</param>
			/// <param name="rgFilterSpec">A pointer to an array of COMDLG_FILTERSPEC structures, each representing a file type.</param>
			new void SetFileTypes(uint cFileTypes,
				[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] COMDLG_FILTERSPEC[] rgFilterSpec);

			/// <summary>Sets the file type that appears as selected in the dialog.</summary>
			/// <param name="iFileType">
			/// The index of the file type in the file type array passed to IFileDialog::SetFileTypes in its cFileTypes parameter. Note that this is a one-based
			/// index, not zero-based.
			/// </param>
			new void SetFileTypeIndex(uint iFileType);

			/// <summary>Gets the currently selected file type.</summary>
			/// <returns>
			/// A UINT value that receives the index of the selected file type in the file type array passed to IFileDialog::SetFileTypes in its cFileTypes parameter.
			/// </returns>
			new uint GetFileTypeIndex();

			/// <summary>Assigns an event handler that listens for events coming from the dialog.</summary>
			/// <param name="pfde">A pointer to an IFileDialogEvents implementation that will receive events from the dialog.</param>
			/// <returns>
			/// A DWORD value identiying this event handler. When the client is finished with the dialog, that client must call the IFileDialog::Unadvise method
			/// with this value.
			/// </returns>
			new uint Advise(IFileDialogEvents pfde);

			/// <summary>Removes an event handler that was attached through the IFileDialog::Advise method.</summary>
			/// <param name="dwCookie">
			/// The DWORD value that represents the event handler. This value is obtained through the pdwCookie parameter of the IFileDialog::Advise method.
			/// </param>
			new void Unadvise(uint dwCookie);

			/// <summary>Sets flags to control the behavior of the dialog.</summary>
			/// <param name="fos">One or more of the FILEOPENDIALOGOPTIONS values.</param>
			new void SetOptions(FILEOPENDIALOGOPTIONS fos);

			/// <summary>Gets the current flags that are set to control dialog behavior.</summary>
			/// <returns>When this method returns successfully, points to a value made up of one or more of the FILEOPENDIALOGOPTIONS values.</returns>
			new FILEOPENDIALOGOPTIONS GetOptions();

			/// <summary>Sets the folder used as a default if there is not a recently used folder value available.</summary>
			/// <param name="psi">A pointer to the interface that represents the folder.</param>
			new void SetDefaultFolder(IShellItem psi);

			/// <summary>Sets a folder that is always selected when the dialog is opened, regardless of previous user action.</summary>
			/// <param name="psi">A pointer to the interface that represents the folder.</param>
			new void SetFolder(IShellItem psi);

			/// <summary>
			/// Gets either the folder currently selected in the dialog, or, if the dialog is not currently displayed, the folder that is to be selected when the
			/// dialog is opened.
			/// </summary>
			/// <returns>The address of a pointer to the interface that represents the folder.</returns>
			new IShellItem GetFolder();

			/// <summary>Gets the user's current selection in the dialog.</summary>
			/// <returns>
			/// The address of a pointer to the interface that represents the item currently selected in the dialog. This item can be a file or folder selected
			/// in the view window, or something that the user has entered into the dialog's edit box. The latter case may require a parsing operation
			/// (cancelable by the user) that blocks the current thread.
			/// </returns>
			new IShellItem GetCurrentSelection();

			/// <summary>Sets the file name that appears in the File name edit box when that dialog box is opened.</summary>
			/// <param name="pszName">A pointer to the name of the file.</param>
			new void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);

			/// <summary>Retrieves the text currently entered in the dialog's File name edit box.</summary>
			/// <returns>The address of a pointer to a buffer that, when this method returns successfully, receives the text.</returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetFileName();

			/// <summary>Sets the title of the dialog.</summary>
			/// <param name="pszTitle">A pointer to a buffer that contains the title text.</param>
			new void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

			/// <summary>Sets the text of the Open or Save button.</summary>
			/// <param name="pszText">A pointer to a buffer that contains the button text.</param>
			new void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);

			/// <summary>Sets the text of the label next to the file name edit box.</summary>
			/// <param name="pszLabel">A pointer to a buffer that contains the label text.</param>
			new void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

			/// <summary>Gets the choice that the user made in the dialog.</summary>
			/// <returns>The address of a pointer to an IShellItem that represents the user's choice.</returns>
			new IShellItem GetResult();

			/// <summary>Adds a folder to the list of places available for the user to open or save items.</summary>
			/// <param name="psi">A pointer to an IShellItem that represents the folder to be made available to the user. This can only be a folder.</param>
			/// <param name="fdap">Specifies where the folder is placed within the list.</param>
			new void AddPlace(IShellItem psi, FDAP fdap);

			/// <summary>Sets the default extension to be added to file names.</summary>
			/// <param name="pszDefaultExtension">
			/// A pointer to a buffer that contains the extension text. This string should not include a leading period. For example, "jpg" is correct, while
			/// ".jpg" is not.
			/// </param>
			new void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

			/// <summary>Closes the dialog.</summary>
			/// <param name="hr">The code that will be returned by Show to indicate that the dialog was closed before a selection was made.</param>
			new void Close([MarshalAs(UnmanagedType.Error)] HRESULT hr);

			/// <summary>Enables a calling application to associate a GUID with a dialog's persisted state.</summary>
			/// <param name="guid">The GUID to associate with this dialog state.</param>
			new void SetClientGuid([In, MarshalAs(UnmanagedType.LPStruct)] Guid guid);

			/// <summary>Instructs the dialog to clear all persisted state information.</summary>
			new void ClearClientData();

			/// <summary>Sets the filter. <note>Deprecated. SetFilter is no longer available for use as of Windows 7.</note></summary>
			/// <param name="pFilter">A pointer to the IShellItemFilter that is to be set.</param>
			new void SetFilter([MarshalAs(UnmanagedType.Interface)] object pFilter);

			/// <summary>Sets an item to be used as the initial entry in a Save As dialog.</summary>
			/// <param name="psi">Pointer to an IShellItem that represents the item.</param>
			void SetSaveAsItem(IShellItem psi);

			/// <summary>Provides a property store that defines the default values to be used for the item being saved.</summary>
			/// <param name="pStore">Pointer to the interface that represents the property store that contains the associated metadata.</param>
			void SetProperties([In] IPropertyStore pStore);

			/// <summary>Specifies which properties will be collected in the save dialog.</summary>
			/// <param name="pList">Pointer to the interface that represents the list of properties to collect. This parameter can be NULL.</param>
			/// <param name="fAppendDefault">
			/// TRUE to show default properties for the currently selected filetype in addition to the properties specified by pList. FALSE to show only
			/// properties specified by pList.
			/// </param>
			void SetCollectedProperties(IPropertyDescriptionList pList, [In, MarshalAs(UnmanagedType.Bool)] bool fAppendDefault);

			/// <summary>Retrieves the set of property values for a saved item or an item in the process of being saved.</summary>
			/// <returns>Address of a pointer to an IPropertyStore that receives the property values.</returns>
			IPropertyStore GetProperties();

			/// <summary>Applies a set of properties to an item using the Shell's copy engine.</summary>
			/// <param name="psi">Pointer to the IShellItem that represents the file being saved. This is usually the item retrieved by GetResult.</param>
			/// <param name="pStore">
			/// Pointer to the IPropertyStore that represents the property values to be applied to the file. This can be the property store returned by IFileSaveDialog::GetProperties.
			/// </param>
			/// <param name="hwnd">The handle of the application window.</param>
			/// <param name="pSink">
			/// Pointer to an optional IFileOperationProgressSink that the calling application can use if they want to be notified of the progress of the
			/// property stamping. This value may be NULL.
			/// </param>
			void ApplyProperties(IShellItem psi, IPropertyStore pStore, [In] IntPtr hwnd, IFileOperationProgressSink pSink);
		}

		/// <summary>
		/// Exposes methods that allow an application to retrieve information about a known folder's category, type, GUID, pointer to an item identifier list
		/// (PIDL) value, redirection capabilities, and definition. It provides a method for the retrival of a known folder's IShellItem object. It also provides
		/// methods to get or set the path of the known folder.
		/// </summary>
		[ComImport, Guid("3AA7AF7E-9B36-420c-A8E3-F77D4674A488"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762502")]
		public interface IKnownFolder
		{
			/// <summary>Gets the ID of the selected folder.</summary>
			/// <returns>When this method returns, returns the KNOWNFOLDERID value of the known folder. Note, KNOWNFOLDERID values are GUIDs.</returns>
			Guid GetId();

			/// <summary>Retrieves the category—virtual, fixed, common, or per-user—of the selected folder.</summary>
			/// <returns>When this method returns, contains a pointer to the KF_CATEGORY of the selected folder.</returns>
			KF_CATEGORY GetCategory();

			/// <summary>Retrieves the location of a known folder in the Shell namespace in the form of a Shell item (IShellItem or derived interface).</summary>
			/// <param name="dwFlags">Flags that specify special retrieval options. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.</param>
			/// <param name="riid">A reference to the IID of the requested interface.</param>
			/// <returns>When this method returns, contains the interface pointer requested in riid. This is typically IShellItem or IShellItem2.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IShellItem GetShellItem([In] KNOWN_FOLDER_FLAG dwFlags, [MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Retrieves the path of a known folder as a string.</summary>
			/// <param name="dwFlags">Flags that specify special retrieval options. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.</param>
			/// <returns>
			/// When this method returns, contains the address of a pointer to a null-terminated buffer that contains the path. The calling application is
			/// responsible for calling CoTaskMemFree to free this resource when it is no longer needed.
			/// </returns>
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))]
			string GetPath([In] KNOWN_FOLDER_FLAG dwFlags);

			/// <summary>Assigns a new path to a known folder.</summary>
			/// <param name="dwFlags">Either zero or the following value: KF_FLAG_DONT_UNEXPAND</param>
			/// <param name="pszPath">The PSZ path.</param>
			void SetPath([In] KNOWN_FOLDER_FLAG dwFlags, [In, MarshalAs(UnmanagedType.LPWStr)] string pszPath);

			/// <summary>Gets the location of the Shell namespace folder in the IDList (ITEMIDLIST) form.</summary>
			/// <param name="dwFlags">Flags that specify special retrieval options. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.</param>
			/// <returns>
			/// When this method returns, contains the address of an absolute PIDL. This parameter is passed uninitialized. The calling application is
			/// responsible for freeing this resource when it is no longer needed.
			/// </returns>
			[return: ComAliasName("ShellObjects.wirePIDL")]
			PIDL GetIDList([In] KNOWN_FOLDER_FLAG dwFlags);

			/// <summary>Retrieves the folder type.</summary>
			/// <returns>When this returns, contains a pointer to a FOLDERTYPEID (a GUID) that identifies the known folder type.</returns>
			Guid GetFolderType();

			/// <summary>
			/// Gets a value that states whether the known folder can have its path set to a new value or what specific restrictions or prohibitions are placed
			/// on that redirection.
			/// </summary>
			/// <returns>
			/// When this method returns, contains a pointer to a KF_REDIRECTION_CAPABILITIES value that indicates the redirection capabilities for this folder.
			/// </returns>
			KF_REDIRECTION_CAPABILITIES GetRedirectionCapabilities();

			/// <summary>
			/// Retrieves a structure that contains the defining elements of a known folder, which includes the folder's category, name, path, description,
			/// tooltip, icon, and other properties.
			/// </summary>
			/// <returns>
			/// When this method returns, contains a pointer to the KNOWNFOLDER_DEFINITION structure. When no longer needed, the calling application is
			/// responsible for calling FreeKnownFolderDefinitionFields to free this resource.
			/// </returns>
			KNOWNFOLDER_DEFINITION GetFolderDefinition();
		}

		/// <summary>Exposes methods that create, enumerate or manage existing known folders.</summary>
		[ComImport, Guid("8BE2D872-86AA-4d47-B776-32CCA40C7018"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CKnownFolderManager))]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761744")]
		public interface IKnownFolderManager
		{
			/// <summary>Gets the KNOWNFOLDERID that is the equivalent of a legacy CSIDL value.</summary>
			/// <param name="nCsidl">The CSIDL value.</param>
			/// <returns>When this method returns, contains a pointer to the KNOWNFOLDERID. This pointer is passed uninitialized.</returns>
			Guid FolderIdFromCsidl([In] int nCsidl);

			/// <summary>Gets the legacy CSIDL value that is the equivalent of a given KNOWNFOLDERID.</summary>
			/// <param name="rfid">Reference to the KNOWNFOLDERID.</param>
			/// <returns>When this method returns, contains a pointer to the CSIDL value. This pointer is passed uninitialized.</returns>
			int FolderIdToCsidl([In, MarshalAs(UnmanagedType.LPStruct)] Guid rfid);

			/// <summary>Gets an array of all registered known folder IDs. This can be used in enumerating all known folders.</summary>
			/// <param name="ppKFId">
			/// When this method returns, contains a pointer to an array of all KNOWNFOLDERID values registered with the system. Use CoTaskMemFree to free these
			/// resources when they are no longer needed.
			/// </param>
			/// <retruns>
			/// When this method returns, contains a pointer to the number of KNOWNFOLDERID values in the array at ppKFId. The [in] functionality of this
			/// parameter is not used.
			/// </retruns>
			uint GetFolderIds(out SafeCoTaskMemHandle ppKFId);

			/// <summary>
			/// Gets an object that represents a known folder identified by its KNOWNFOLDERID. The object allows you to query certain folder properties, get the
			/// current path of the folder, redirect the folder to another location, and get the path of the folder as an ITEMIDLIST.
			/// </summary>
			/// <param name="rfid">Reference to the KNOWNFOLDERID.</param>
			/// <returns>When this method returns, contains an interface pointer to the IKnownFolder object that represents the folder.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IKnownFolder GetFolder([In, MarshalAs(UnmanagedType.LPStruct)] Guid rfid);

			/// <summary>
			/// Gets an object that represents a known folder identified by its canonical name. The object allows you to query certain folder properties, get the
			/// current path of the folder, redirect the folder to another location, and get the path of the folder as an ITEMIDLIST.
			/// </summary>
			/// <param name="pszCanonicalName">
			/// A pointer to the non-localized, canonical name for the known folder, stored as a null-terminated Unicode string. If this folder is a common or
			/// per-user folder, this value is also used as the value name of the "User Shell Folders" registry settings. This value is retrieved through the
			/// pszName member of the folder's KNOWNFOLDER_DEFINITION structure.
			/// </param>
			/// <returns>When this method returns, contains the address of a pointer to the IKnownFolder object that represents the known folder.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IKnownFolder GetFolderByName([In, MarshalAs(UnmanagedType.LPWStr)] string pszCanonicalName);

			/// <summary>
			/// Adds a new known folder to the registry. Used particularly by independent software vendors (ISVs) that are adding one of their own folders to the
			/// known folder system.
			/// </summary>
			/// <param name="rfid">A GUID that represents the known folder.</param>
			/// <param name="pKFD">A pointer to a valid KNOWNFOLDER_DEFINITION structure that provides the details of the new folder.</param>
			void RegisterFolder([In, MarshalAs(UnmanagedType.LPStruct)] Guid rfid, [In] ref KNOWNFOLDER_DEFINITION pKFD);

			/// <summary>
			/// Remove a known folder from the registry, which makes it unknown to the known folder system. This method does not remove the folder itself.
			/// </summary>
			/// <param name="rfid">GUID or KNOWNFOLDERID that represents the known folder.</param>
			void UnregisterFolder([In, MarshalAs(UnmanagedType.LPStruct)] Guid rfid);

			/// <summary>
			/// Gets an object that represents a known folder based on a file system path. The object allows you to query certain folder properties, get the
			/// current path of the folder, redirect the folder to another location, and get the path of the folder as an ITEMIDLIST.
			/// </summary>
			/// <param name="pszPath">Pointer to a null-terminated Unicode string of length MAX_PATH that contains a path to a known folder.</param>
			/// <param name="mode">
			/// One of the following values that specify the precision of the match of path and known folder: FFFP_EXACTMATCH = Retrieve only the specific known
			/// folder for the given file path; FFFP_NEARESTPARENTMATCH = If an exact match is not found for the given file path, retrieve the first known folder
			/// that matches one of its parent folders walking up the parent tree.
			/// </param>
			/// <returns>When this method returns, contains the address of a pointer to the IKnownFolder object that represents the known folder.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IKnownFolder FindFolderFromPath([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath, [In] FFFP_MODE mode);

			/// <summary>
			/// Gets an object that represents a known folder based on an IDList. The object allows you to query certain folder properties, get the current path
			/// of the folder, redirect the folder to another location, and get the path of the folder as an ITEMIDLIST.
			/// </summary>
			/// <param name="pidl">A pointer to the IDList.</param>
			/// <returns>When this method returns, contains the address of a pointer to the IKnownFolder object that represents the known folder.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IKnownFolder FindFolderFromIDList([In] PIDL pidl);

			/// <summary>Redirects folder requests for common and per-user folders.</summary>
			/// <param name="rfid">A reference to the KNOWNFOLDERID of the folder to be redirected.</param>
			/// <param name="hwnd">
			/// The handle of the parent window used to display copy engine progress UI dialogs when KF_REDIRECT_WITH_UI i passed in the flags parameter. If no
			/// progress dialog is needed, this value can be NULL.
			/// </param>
			/// <param name="flags">The KF_REDIRECT_FLAGS options for redirection.</param>
			/// <param name="pszTargetPath">A pointer to the new path for the folder. This is a null-terminated Unicode string. This value can be NULL.</param>
			/// <param name="cFolders">The number of KNOWNFOLDERID values in the array at pExclusion.</param>
			/// <param name="pExclusion">
			/// Pointer to an array of KNOWNFOLDERID values that refer to subfolders of rfid that should be excluded from the redirection. If no subfolders are
			/// excluded, this value can be NULL.
			/// </param>
			/// <returns>
			/// When this method returns, contains the address of a pointer to a null-terminated Unicode string that contains an error message if one was
			/// generated. This value can be NULL.
			/// </returns>
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))]
			string Redirect([In, MarshalAs(UnmanagedType.LPStruct)] Guid rfid, [In] IntPtr hwnd, [In] KF_REDIRECT_FLAGS flags,
				[In, MarshalAs(UnmanagedType.LPWStr)] string pszTargetPath, [In] uint cFolders, [In, MarshalAs(UnmanagedType.LPStruct)] Guid pExclusion);
		}

		/// <summary>Exposes a method that represents a modal window. This interface is used in the Windows XP Passport Wizard.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("b4db1657-70d7-485e-8e3e-6fcb5a5c1802")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761686")]
		public interface IModalWindow
		{
			/// <summary>Launches the modal window.</summary>
			/// <param name="parent">The handle of the owner window. This value can be NULL.</param>
			/// <returns>
			/// If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code, including the following:
			/// HRESULT_FROM_WIN32(ERROR_CANCELLED) = The user closed the window by cancelling the operation.
			/// </returns>
			[PreserveSig]
			HRESULT Show(IntPtr parent);
		}

		/// <summary>Exposes methods that enable clients to access items in a collection of objects that support IUnknown.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("92CA9DCD-5622-4bba-A805-5E9F541BD8C9")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378311")]
		public interface IObjectArray
		{
			/// <summary>Provides a count of the objects in the collection.</summary>
			/// <returns>The number of objects in the collection.</returns>
			uint GetCount();

			/// <summary>Provides a pointer to a specified object's interface. The object and interface are specified by index and interface ID.</summary>
			/// <param name="uiIndex">The index of the object</param>
			/// <param name="riid">Reference to the desired interface ID.</param>
			/// <returns>Receives the interface pointer requested in riid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetAt([In] uint uiIndex, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
		}

		/// <summary>Extends the IObjectArray interface by providing methods that enable clients to add and remove objects that support IUnknown in a collection.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5632b1a4-e38a-400a-928a-d4cd63230295"), CoClass(typeof(CEnumerableObjectCollection))]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378307")]
		public interface IObjectCollection
		{
			/// <summary>Provides a count of the objects in the collection.</summary>
			/// <returns>The number of objects in the collection.</returns>
			uint GetCount();

			/// <summary>Provides a pointer to a specified object's interface. The object and interface are specified by index and interface ID.</summary>
			/// <param name="uiIndex">The index of the object</param>
			/// <param name="riid">Reference to the desired interface ID.</param>
			/// <returns>Receives the interface pointer requested in riid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetAt([In] uint uiIndex, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Adds a single object to the collection.</summary>
			/// <param name="punk">Pointer to the IUnknown of the object to be added to the collection.</param>
			void AddObject([In, MarshalAs(UnmanagedType.Interface)] object punk);

			/// <summary>Adds the objects contained in an IObjectArray to the collection.</summary>
			/// <param name="poaSource">Pointer to the IObjectArray whose contents are to be added to the collection.</param>
			void AddFromArray(IObjectArray poaSource);

			/// <summary>Removes a single, specified object from the collection.</summary>
			/// <param name="uiIndex">A pointer to the index of the object within the collection.</param>
			void RemoveObjectAt(uint uiIndex);

			/// <summary>Removes all objects from the collection.</summary>
			void Clear();
		}

		/// <summary>
		/// Exposes methods that allow implementers of a custom IAssocHandler object to provide access to its explicit Application User Model ID
		/// (AppUserModelID). This information is used to determine whether a particular file type can be added to an application's Jump List.
		/// </summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("36db0196-9665-46d1-9ba7-d3709eecf9ed")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378302")]
		public interface IObjectWithAppUserModelId
		{
			/// <summary>Sets the application identifier.</summary>
			/// <param name="pszAppID">The PSZ application identifier.</param>
			void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

			/// <summary>Retrieves a file type handler's explicit Application User Model ID (AppUserModelID), if one has been declared.</summary>
			/// <returns></returns>
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))]
			string GetAppID();
		}

		/// <summary>Exposes methods that provide access to the ProgID associated with an object.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("71e806fb-8dee-46fc-bf8c-7748a8a1ae13")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378294")]
		public interface IObjectWithProgId
		{
			/// <summary>Sets the ProgID of an object.</summary>
			/// <param name="pszProgID">A pointer to a string that contains the new ProgID.</param>
			void SetProgID([MarshalAs(UnmanagedType.LPWStr)] string pszProgID);

			/// <summary>Retrieves the ProgID associated with an object.</summary>
			/// <returns>A pointer to a string that, when this method returns successfully, contains the ProgID.</returns>
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))]
			string GetProgID();
		}

		/// <summary>
		/// Exposes methods that the Shell uses to retrieve flags and info tip information for an item that resides in an IShellFolder implementation. Info tips
		/// are usually displayed inside a tooltip control.
		/// </summary>
		[ComImport, Guid("00021500-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761359")]
		public interface IQueryInfo
		{
			/// <summary>Gets the information tip.</summary>
			/// <param name="dwFlags">
			/// Flags that direct the handling of the item from which you're retrieving the info tip text. This value is commonly zero (QITIPF_DEFAULT).
			/// </param>
			/// <returns>
			/// The address of a Unicode string pointer that, when this method returns successfully, receives the tip string pointer. Applications that implement
			/// this method must allocate memory for ppwszTip by calling CoTaskMemAlloc. Calling applications must call CoTaskMemFree to free the memory when it
			/// is no longer needed.
			/// </returns>
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))]
			string GetInfoTip(QITIP dwFlags);

			/// <summary>Gets the information flags for an item. This method is not currently used.</summary>
			/// <returns>A pointer to a value that receives the flags for the item. If no flags are to be returned, this value should be set to zero.</returns>
			uint GetInfoFlags();
		}

		/// <summary>Exposed by all Shell namespace folder objects, its methods are used to manage folders.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214E6-0000-0000-C000-000000000046")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775075")]
		public interface IShellFolder
		{
			/// <summary>Translates the display name of a file object or a folder into an item identifier list.</summary>
			/// <param name="hwnd">
			/// A window handle. The client should provide a window handle if it displays a dialog or message box. Otherwise set hwnd to NULL
			/// </param>
			/// <param name="pbc">
			/// Optional. A pointer to a bind context used to pass parameters as inputs and outputs to the parsing function. These passed parameters are often
			/// specific to the data source and are documented by the data source owners. For example, the file system data source accepts the name being parsed
			/// (as a WIN32_FIND_DATA structure), using the STR_FILE_SYS_BIND_DATA bind context parameter. STR_PARSE_PREFER_FOLDER_BROWSING can be passed to
			/// indicate that URLs are parsed using the file system data source when possible. Construct a bind context object using CreateBindCtx and populate
			/// the values using IBindCtx::RegisterObjectParam. See Bind Context String Keys for a complete list of these. If no data is being passed to or
			/// received from the parsing function, this value can be NULL.
			/// </param>
			/// <param name="pszDisplayName">
			/// A null-terminated Unicode string with the display name. Because each Shell folder defines its own parsing syntax, the form this string can take
			/// may vary. The desktop folder, for instance, accepts paths such as "C:\My Docs\My File.txt". It also will accept references to items in the
			/// namespace that have a GUID associated with them using the "::{GUID}" syntax.
			/// </param>
			/// <param name="pchEaten">
			/// A pointer to a ULONG value that receives the number of characters of the display name that was parsed. If your application does not need this
			/// information, set pchEaten to NULL, and no value will be returned.
			/// </param>
			/// <param name="ppidl">
			/// When this method returns, contains a pointer to the PIDL for the object. The returned item identifier list specifies the item relative to the
			/// parsing folder. If the object associated with pszDisplayName is within the parsing folder, the returned item identifier list will contain only
			/// one SHITEMID structure. If the object is in a subfolder of the parsing folder, the returned item identifier list will contain multiple SHITEMID
			/// structures. If an error occurs, NULL is returned in this address.
			/// <para>When it is no longer needed, it is the responsibility of the caller to free this resource by calling CoTaskMemFree.</para>
			/// </param>
			/// <param name="pdwAttributes">
			/// The value used to query for file attributes. If not used, it should be set to NULL. To query for one or more attributes, initialize this
			/// parameter with the SFGAO flags that represent the attributes of interest. On return, those attributes that are true and were requested will be set.
			/// </param>
			void ParseDisplayName(IntPtr hwnd, [In, Optional] IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, out uint pchEaten, out PIDL ppidl, [In, Out] ref SFGAO pdwAttributes);

			/// <summary>
			/// Enables a client to determine the contents of a folder by creating an item identifier enumeration object and returning its IEnumIDList interface.
			/// The methods supported by that interface can then be used to enumerate the folder's contents.
			/// </summary>
			/// <param name="hwnd">
			/// If user input is required to perform the enumeration, this window handle should be used by the enumeration object as the parent window to take
			/// user input. An example would be a dialog box to ask for a password or prompt the user to insert a CD or floppy disk. If hwndOwner is set to NULL,
			/// the enumerator should not post any messages, and if user input is required, it should silently fail.
			/// </param>
			/// <param name="grfFlags">
			/// Flags indicating which items to include in the enumeration. For a list of possible values, see the SHCONTF enumerated type.
			/// </param>
			/// <returns>
			/// The address that receives a pointer to the IEnumIDList interface of the enumeration object created by this method. If an error occurs or no
			/// suitable subobjects are found, ppenumIDList is set to NULL.
			/// </returns>
			IEnumIDList EnumObjects(IntPtr hwnd, SHCONTF grfFlags);

			/// <summary>
			/// Retrieves a handler, typically the Shell folder object that implements IShellFolder for a particular item. Optional parameters that control the
			/// construction of the handler are passed in the bind context.
			/// </summary>
			/// <param name="pidl">
			/// The address of an ITEMIDLIST structure (PIDL) that identifies the subfolder. This value can refer to an item at any level below the parent folder
			/// in the namespace hierarchy. The structure contains one or more SHITEMID structures, followed by a terminating NULL.
			/// </param>
			/// <param name="pbc">
			/// A pointer to an IBindCtx interface on a bind context object that can be used to pass parameters to the construction of the handler. If this
			/// parameter is not used, set it to NULL. Because support for this parameter is optional for folder object implementations, some folders may not
			/// support the use of bind contexts.
			/// <para>
			/// Information that can be provided in the bind context includes a BIND_OPTS structure that includes a grfMode member that indicates the access mode
			/// when binding to a stream handler. Other parameters can be set and discovered using IBindCtx::RegisterObjectParam and IBindCtx::GetObjectParam.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// The identifier of the interface to return. This may be IID_IShellFolder, IID_IStream, or any other interface that identifies a particular handler.
			/// </param>
			/// <returns>
			/// When this method returns, contains the address of a pointer to the requested interface. If an error occurs, a NULL pointer is returned at this address.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object BindToObject([In] PIDL pidl, [In, Optional] IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Requests a pointer to an object's storage interface.</summary>
			/// <param name="pidl">
			/// The address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder. The structure must contain exactly one
			/// SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="pbc">
			/// The optional address of an IBindCtx interface on a bind context object to be used during this operation. If this parameter is not used, set it to
			/// NULL. Because support for pbc is optional for folder object implementations, some folders may not support the use of bind contexts.
			/// </param>
			/// <param name="riid">
			/// The IID of the requested storage interface. To retrieve an IStream, IStorage, or IPropertySetStorage interface pointer, set riid to IID_IStream,
			/// IID_IStorage, or IID_IPropertySetStorage, respectively.
			/// </param>
			/// <returns>The address that receives the interface pointer specified by riid. If an error occurs, a NULL pointer is returned in this address.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object BindToStorage([In] PIDL pidl, [In, Optional] IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Determines the relative order of two file objects or folders, given their item identifier lists.</summary>
			/// <param name="lParam">
			/// A value that specifies how the comparison should be performed.
			/// <para>
			/// The lower sixteen bits of lParam define the sorting rule. Most applications set the sorting rule to the default value of zero, indicating that
			/// the two items should be compared by name. The system does not define any other sorting rules. Some folder objects might allow calling
			/// applications to use the lower sixteen bits of lParam to specify folder-specific sorting rules. The rules and their associated lParam values are
			/// defined by the folder.
			/// </para>
			/// <para>
			/// When the system folder view object calls IShellFolder::CompareIDs, the lower sixteen bits of lParam are used to specify the column to be used for
			/// the comparison.
			/// </para>
			/// <para>The upper sixteen bits of lParam are used for flags that modify the sorting rule. The system currently defines these modifier flags.</para>
			/// <list>
			/// <item>
			/// <term>SHCIDS_ALLFIELDS</term>
			/// <description>
			/// Version 5.0. Compare all the information contained in the ITEMIDLIST structure, not just the display names. This flag is valid only for folder
			/// objects that support the IShellFolder2 interface. For instance, if the two items are files, the folder should compare their names, sizes, file
			/// times, attributes, and any other information in the structures. If this flag is set, the lower sixteen bits of lParam must be zero.
			/// </description>
			/// </item>
			/// <item>
			/// <term>SHCIDS_CANONICALONLY</term>
			/// <description>
			/// Version 5.0. When comparing by name, compare the system names but not the display names. When this flag is passed, the two items are compared by
			/// whatever criteria the Shell folder determines are most efficient, as long as it implements a consistent sort function. This flag is useful when
			/// comparing for equality or when the results of the sort are not displayed to the user. This flag cannot be combined with other flags.
			/// </description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pidl1">
			/// A pointer to the first item's ITEMIDLIST structure. It will be relative to the folder. This ITEMIDLIST structure can contain more than one
			/// element; therefore, the entire structure must be compared, not just the first element.
			/// </param>
			/// <param name="pidl2">
			/// A pointer to the second item's ITEMIDLIST structure. It will be relative to the folder. This ITEMIDLIST structure can contain more than one
			/// element; therefore, the entire structure must be compared, not just the first element.
			/// </param>
			/// <returns>
			/// If this method is successful, the CODE field of the HRESULT contains one of the following values. For information regarding the extraction of the
			/// CODE field from the returned HRESULT, see Remarks. If this method is unsuccessful, it returns a COM error code.
			/// </returns>
			[PreserveSig]
			HRESULT CompareIDs(IntPtr lParam, [In] PIDL pidl1, [In] PIDL pidl2);

			/// <summary>Requests an object that can be used to obtain information from or interact with a folder object.</summary>
			/// <param name="hwndOwner">
			/// A handle to the owner window. If you have implemented a custom folder view object, your folder view window should be created as a child of hwndOwner.
			/// </param>
			/// <param name="riid">A reference to the IID of the interface to retrieve through ppv, typically IID_IShellView.</param>
			/// <returns>
			/// When this method returns successfully, contains the interface pointer requested in riid. This is typically IShellView. See the Remarks section
			/// for more details.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object CreateViewObject(IntPtr hwndOwner, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets the attributes of one or more file or folder objects contained in the object represented by IShellFolder.</summary>
			/// <param name="cidl">The number of items from which to retrieve attributes.</param>
			/// <param name="apidl">
			/// The address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies an item relative to the parent folder. Each
			/// ITEMIDLIST structure must contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="rgfInOut">
			/// Pointer to a single ULONG value that, on entry, contains the bitwise SFGAO attributes that the calling application is requesting. On exit, this
			/// value contains the requested attributes that are common to all of the specified items.
			/// </param>
			void GetAttributesOf(uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] apidl, ref SFGAO rgfInOut);

			/// <summary>Gets an object that can be used to carry out actions on the specified file objects or folders.</summary>
			/// <param name="hwndOwner">A handle to the owner window that the client should specify if it displays a dialog box or message box.</param>
			/// <param name="cidl">The number of file objects or subfolders specified in the apidl parameter.</param>
			/// <param name="apidl">
			/// The address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies a file object or subfolder relative to the parent
			/// folder. Each item identifier list must contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="riid">
			/// A reference to the IID of the interface to retrieve through ppv. This can be any valid interface identifier that can be created for an item. The
			/// most common identifiers used by the Shell are listed in the comments at the end of this reference.
			/// </param>
			/// <param name="rgfReserved">Reserved.</param>
			/// <returns>When this method returns successfully, contains the interface pointer requested in riid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetUIObjectOf(IntPtr hwndOwner, uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] apidl, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, IntPtr rgfReserved);

			/// <summary>Retrieves the display name for the specified file object or subfolder.</summary>
			/// <param name="pidl">PIDL that uniquely identifies the file object or subfolder relative to the parent folder.</param>
			/// <param name="uFlags">Flags used to request the type of display name to return. For a list of possible values, see the SHGDNF enumerated type.</param>
			/// <returns>
			/// When this method returns, contains a pointer to a STRRET structure in which to return the display name. The type of name returned in this
			/// structure can be the requested type, but the Shell folder might return a different type.
			/// </returns>
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(STRRETMarshaler))]
			string GetDisplayNameOf([In] PIDL pidl, SHGDNF uFlags);

			/// <summary>Sets the display name of a file object or subfolder, changing the item identifier in the process.</summary>
			/// <param name="hwnd">A handle to the owner window of any dialog or message box that the client displays.</param>
			/// <param name="pidl">
			/// A pointer to an ITEMIDLIST structure that uniquely identifies the file object or subfolder relative to the parent folder. The structure must
			/// contain exactly one SHITEMID structure followed by a terminating zero.
			/// </param>
			/// <param name="pszName">A pointer to a null-terminated string that specifies the new display name.</param>
			/// <param name="uFlags">
			/// Flags that indicate the type of name specified by the pszName parameter. For a list of possible values and combinations of values, see SHGDNF.
			/// </param>
			/// <param name="ppidlOut">
			/// Optional. If specified, the address of a pointer to an ITEMIDLIST structure that receives the ITEMIDLIST of the renamed item. The caller requests
			/// this value by passing a non-null ppidlOut. Implementations of IShellFolder::SetNameOf must return a pointer to the new ITEMIDLIST in the ppidlOut parameter.
			/// </param>
			void SetNameOf(IntPtr hwnd, [In] PIDL pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszName, SHGDNF uFlags, out PIDL ppidlOut);
		}

		/// <summary>
		/// Exposes methods that retrieve information about a Shell item. IShellItem and IShellItem2 are the preferred representations of items in any new code.
		/// </summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761144")]
		public interface IShellItem
		{
			/// <summary>Binds to a handler for an item as specified by the handler ID value (BHID).</summary>
			/// <param name="pbc">
			/// A pointer to an IBindCtx interface on a bind context object. Used to pass optional parameters to the handler. The contents of the bind context
			/// are handler-specific. For example, when binding to BHID_Stream, the STGM flags in the bind context indicate the mode of access desired (read or read/write).
			/// </param>
			/// <param name="bhid">Reference to a GUID that specifies which handler will be created.</param>
			/// <param name="riid">IID of the object type to retrieve.</param>
			/// <returns>When this method returns, contains a pointer of type riid that is returned by the handler specified by rbhid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object BindToHandler(IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid bhid, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets the parent of an IShellItem object.</summary>
			/// <returns>The address of a pointer to the parent of an IShellItem interface.</returns>
			IShellItem GetParent();

			/// <summary>Gets the display name of the IShellItem object.</summary>
			/// <param name="sigdnName">One of the SIGDN values that indicates how the name should look.</param>
			/// <returns>A value that, when this function returns successfully, receives the address of a pointer to the retrieved display name.</returns>
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))]
			string GetDisplayName(SIGDN sigdnName);

			/// <summary>Gets a requested set of attributes of the IShellItem object.</summary>
			/// <param name="sfgaoMask">
			/// Specifies the attributes to retrieve. One or more of the SFGAO values. Use a bitwise OR operator to determine the attributes to retrieve.
			/// </param>
			/// <returns>
			/// A pointer to a value that, when this method returns successfully, contains the requested attributes. One or more of the SFGAO values. Only those
			/// attributes specified by sfgaoMask are returned; other attribute values are undefined.
			/// </returns>
			SFGAO GetAttributes(SFGAO sfgaoMask);

			/// <summary>Compares two IShellItem objects.</summary>
			/// <param name="psi">A pointer to an IShellItem object to compare with the existing IShellItem object.</param>
			/// <param name="hint">
			/// One of the SICHINTF values that determines how to perform the comparison. See SICHINTF for the list of possible values for this parameter.
			/// </param>
			/// <returns>
			/// This parameter receives the result of the comparison. If the two items are the same this parameter equals zero; if they are different the
			/// parameter is nonzero.
			/// </returns>
			int Compare(IShellItem psi, SICHINTF hint);
		}

		/// <summary>
		/// Extends IShellItem with methods that retrieve various property values of the item. IShellItem and IShellItem2 are the preferred representations of
		/// items in any new code.
		/// </summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("7e9fb0d3-919f-4307-ab2e-9b1860310c93")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761130")]
		public interface IShellItem2 : IShellItem
		{
			/// <summary>Binds to a handler for an item as specified by the handler ID value (BHID).</summary>
			/// <param name="pbc">
			/// A pointer to an IBindCtx interface on a bind context object. Used to pass optional parameters to the handler. The contents of the bind context
			/// are handler-specific. For example, when binding to BHID_Stream, the STGM flags in the bind context indicate the mode of access desired (read or read/write).
			/// </param>
			/// <param name="bhid">Reference to a GUID that specifies which handler will be created.</param>
			/// <param name="riid">IID of the object type to retrieve.</param>
			/// <returns>When this method returns, contains a pointer of type riid that is returned by the handler specified by rbhid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new object BindToHandler(IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid bhid, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets the parent of an IShellItem object.</summary>
			/// <returns>The address of a pointer to the parent of an IShellItem interface.</returns>
			new IShellItem GetParent();

			/// <summary>Gets the display name of the IShellItem object.</summary>
			/// <param name="sigdnName">One of the SIGDN values that indicates how the name should look.</param>
			/// <returns>A value that, when this function returns successfully, receives the address of a pointer to the retrieved display name.</returns>
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))]
			new string GetDisplayName(SIGDN sigdnName);

			/// <summary>Gets a requested set of attributes of the IShellItem object.</summary>
			/// <param name="sfgaoMask">
			/// Specifies the attributes to retrieve. One or more of the SFGAO values. Use a bitwise OR operator to determine the attributes to retrieve.
			/// </param>
			/// <returns>
			/// A pointer to a value that, when this method returns successfully, contains the requested attributes. One or more of the SFGAO values. Only those
			/// attributes specified by sfgaoMask are returned; other attribute values are undefined.
			/// </returns>
			new SFGAO GetAttributes(SFGAO sfgaoMask);

			/// <summary>Compares two IShellItem objects.</summary>
			/// <param name="psi">A pointer to an IShellItem object to compare with the existing IShellItem object.</param>
			/// <param name="hint">
			/// One of the SICHINTF values that determines how to perform the comparison. See SICHINTF for the list of possible values for this parameter.
			/// </param>
			/// <returns>
			/// This parameter receives the result of the comparison. If the two items are the same this parameter equals zero; if they are different the
			/// parameter is nonzero.
			/// </returns>
			new int Compare(IShellItem psi, SICHINTF hint);

			/// <summary>Gets a property store object for specified property store flags.</summary>
			/// <param name="flags">The GETPROPERTYSTOREFLAGS constants that modify the property store object.</param>
			/// <param name="riid">A reference to the IID of the object to be retrieved.</param>
			/// <returns>When this method returns, contains the address of an IPropertyStore interface pointer.</returns>
			IPropertyStore GetPropertyStore(GETPROPERTYSTOREFLAGS flags, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>
			/// Uses the specified ICreateObject instead of CoCreateInstance to create an instance of the property handler associated with the Shell item on
			/// which this method is called. Most calling applications do not need to call this method, and can call IShellItem2::GetPropertyStore instead.
			/// </summary>
			/// <param name="flags">The GETPROPERTYSTOREFLAGS constants that modify the property store object.</param>
			/// <param name="punkCreateObject">
			/// A pointer to a factory for low-rights creation of type ICreateObject.
			/// <para>
			/// The method CreateObject creates an instance of a COM object. The implementation of IShellItem2::GetPropertyStoreWithCreateObject uses
			/// CreateObject instead of CoCreateInstance to create the property handler, which is a Shell extension, for a given file type. The property handler
			/// provides many of the important properties in the property store that this method returns.
			/// </para>
			/// <para>
			/// This method is useful only if the ICreateObject object is created in a separate process (as a LOCALSERVER instead of an INPROCSERVER), and also
			/// if this other process has lower rights than the process calling IShellItem2::GetPropertyStoreWithCreateObject.
			/// </para>
			/// </param>
			/// <param name="riid">A reference to the IID of the object to be retrieved.</param>
			/// <returns>When this method returns, contains the address of the requested IPropertyStore interface pointer.</returns>
			// TODO: Create ICreateObject for second param
			IPropertyStore GetPropertyStoreWithCreateObject(GETPROPERTYSTOREFLAGS flags, [MarshalAs(UnmanagedType.IUnknown)] object punkCreateObject,
				[In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets property store object for specified property keys.</summary>
			/// <param name="rgKeys">
			/// A pointer to an array of PROPERTYKEY structures. Each structure contains a unique identifier for each property used in creating the property store.
			/// </param>
			/// <param name="cKeys">The number of PROPERTYKEY structures in the array pointed to by rgKeys.</param>
			/// <param name="flags">The GETPROPERTYSTOREFLAGS constants that modify the property store object.</param>
			/// <param name="riid">A reference to the IID of the object to be retrieved.</param>
			/// <returns></returns>
			IPropertyStore GetPropertyStoreForKeys([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] PROPERTYKEY[] rgKeys, uint cKeys, GETPROPERTYSTOREFLAGS flags, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets a property description list object given a reference to a property key.</summary>
			/// <param name="keyType">A reference to a PROPERTYKEY structure.</param>
			/// <param name="riid">A reference to a desired IID.</param>
			/// <returns>Contains the address of an IPropertyDescriptionList interface pointer.</returns>
			IPropertyDescriptionList GetPropertyDescriptionList([In] ref PROPERTYKEY keyType, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Ensures that any cached information in this item is updated.</summary>
			/// <param name="pbc">A pointer to an IBindCtx interface on a bind context object.</param>
			void Update(IBindCtx pbc);

			/// <summary>Gets a PROPVARIANT structure from a specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>Contains a pointer to a PROPVARIANT structure.</returns>
			PROPVARIANT GetProperty([In] ref PROPERTYKEY key);

			/// <summary>Gets the class identifier (CLSID) value of specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>A pointer to a CLSID value.</returns>
			Guid GetCLSID([In] ref PROPERTYKEY key);

			/// <summary>Gets the date and time value of a specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>A pointer to a date and time value.</returns>
			FILETIME GetFileTime([In] ref PROPERTYKEY key);

			/// <summary>Gets the Int32 value of specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>A pointer to an Int32 value.</returns>
			int GetInt32([In] ref PROPERTYKEY key);

			/// <summary>Gets the string value of a specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>A pointer to a Unicode string value.</returns>
			[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))]
			string GetString([In] ref PROPERTYKEY key);

			/// <summary>Gets the UInt32 value of specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>A pointer to an UInt32 value.</returns>
			uint GetUInt32([In] ref PROPERTYKEY key);

			/// <summary>Gets the UInt64 value of specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>A pointer to an UInt64 value.</returns>
			ulong GetUInt64([In] ref PROPERTYKEY key);

			/// <summary>Gets the boolean value of a specified property key.</summary>
			/// <param name="key">A reference to a PROPERTYKEY structure.</param>
			/// <returns>A pointer to a boolean value.</returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			bool GetBool([In] ref PROPERTYKEY key);
		}

		/// <summary>Exposes methods that create and manipulate Shell item arrays.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("B63EA76D-1F85-456F-A19C-48159EFA858B")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761106")]
		public interface IShellItemArray
		{
			/// <summary>Binds to an object by means of the specified handler.</summary> <param name="pbc">A pointer to an IBindCtx interface on a bind context
			/// object.</param> <param name="rbhid">One of the following values, defined in Shlguid.h, that determine the handler. <list>
			/// <item><term>BHID_SFUIObject</term><description>Restricts usage to GetUIObjectOf. Use this handler type only for a flat item array, where all
			/// items are in the same folder.</description></item> <item><term>BHID_DataObject</term><description>Introduced in Windows Vista: Gets an
			/// IDataObject object for use with an item or an array of items. Use this handler type only for flat data objects or item arrays created by
			/// SHCreateShellItemArrayFromDataObject.</description></item> <item><term>BHID_AssociationArray</term><description>Introduced in Windows Vista: Gets
			/// an IQueryAssociations object for use with an item or an array of items. This only retrieves the association array object for the first item in
			/// the IShellItemArray</param></description></item> </list> <param name="riid">The IID of the object type to retrieve.</param> <returns>When this
			/// methods returns, contains the object specified in riid that is returned by the handler specified by rbhid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object BindToHandler(IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid rbhid, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets a property store.</summary>
			/// <param name="flags">One of the GETPROPERTYSTOREFLAGS constants.</param>
			/// <param name="riid">The IID of the object type to retrieve.</param>
			/// <returns>When this method returns, contains interface pointer requested in riid. This is typically IPropertyStore or IPropertyStoreCapabilities.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetPropertyStore(GETPROPERTYSTOREFLAGS flags, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets a property description list for the items in the shell item array.</summary>
			/// <param name="keyType">A reference to the PROPERTYKEY structure specifying which property list to retrieve.</param>
			/// <param name="riid">The IID of the object type to retrieve.</param>
			/// <returns>When this method returns, contains the interface requested in riid. This will typically be IPropertyDescriptionList.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetPropertyDescriptionList([In] ref PROPERTYKEY keyType, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>
			/// Gets the attributes of the set of items contained in an IShellItemArray. If the array contains more than one item, the attributes retrieved by
			/// this method are not the attributes of single items, but a logical combination of all of the requested attributes of all of the items.
			/// </summary>
			/// <param name="dwAttribFlags">
			/// If the array contains a single item, this method provides the same results as GetAttributes. However, if the array contains multiple items, the
			/// attribute sets of all the items are combined into a single attribute set and returned in the value pointed to by psfgaoAttribs. This parameter
			/// takes one of the following values to define how that final attribute set is determined:
			/// </param>
			/// <param name="sfgaoMask">A mask that specifies what particular attributes are being requested. A bitwise OR of one or more of the SFGAO values.</param>
			/// <returns>A bitmap that, when this method returns successfully, contains the values of the requested attributes.</returns>
			SFGAO GetAttributes(SIATTRIBFLAGS dwAttribFlags, SFGAO sfgaoMask);

			/// <summary>Gets the number of items in the given IShellItem array.</summary>
			/// <returns>When this method returns, contains the number of items in the IShellItemArray.</returns>
			uint GetCount();

			/// <summary>Gets the item at the given index in the IShellItemArray.</summary>
			/// <param name="dwIndex">The index of the IShellItem requested in the IShellItemArray</param>
			/// <returns>When this method returns, contains the requested IShellItem pointer.</returns>
			IShellItem GetItemAt(uint dwIndex);

			/// <summary>Gets an enumerator of the items in the array.</summary>
			/// <returns>When this method returns, contains an IEnumShellItems pointer that enumerates the shell items that are in the array.</returns>
			IEnumShellItems EnumItems();
		}

		/// <summary>Exposes methods that allow an application to attach extra data blocks to a Shell link. These methods add, copy, or remove data blocks.</summary>
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
			/// The data block's signature. The signature value for a particular type of data block can be found in its structure reference. For a list of
			/// supported data block types and their associated structures, see IShellLinkDataList.
			/// </param>
			/// <returns>
			/// The address of a pointer to a copy of the data block structure. If IShellLinkDataList::CopyDataBlock returns a successful result, the calling
			/// application must free the memory when it is no longer needed by calling LocalFree.
			/// </returns>
			SafeLocalHandle CopyDataBlock(ShellDataBlockSignature dwSig);

			/// <summary>Removes a data block from a link.</summary>
			/// <param name="dwSig">
			/// The data block's signature. The signature value for a particular type of data block can be found in its structure reference. For a list of
			/// supported data block types and their associated structures, see IShellLinkDataList.
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
			/// The size, in characters, of the buffer pointed to by the pszFile parameter, including the terminating null character. The maximum path size that
			/// can be returned is MAX_PATH. This parameter is commonly set by calling ARRAYSIZE(pszFile). The ARRAYSIZE macro is defined in Winnt.h.
			/// </param>
			/// <param name="pfd">
			/// A pointer to a WIN32_FIND_DATA structure that receives information about the target of the Shell link object. If this parameter is NULL, then no
			/// additional information is returned.
			/// </param>
			/// <param name="fFlags">Flags that specify the type of path information to retrieve.</param>
			void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath,
				[In, Out] WIN32_FIND_DATA pfd, SLGP fFlags);

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
			/// The maximum number of characters to copy to the buffer pointed to by the pszDir parameter. The name of the working directory is truncated if it
			/// is longer than the maximum specified by this parameter.
			/// </param>
			void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);

			/// <summary>Sets the name of the working directory for a Shell link object.</summary>
			/// <param name="pszDir">The address of a buffer that contains the name of the new working directory.</param>
			void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

			/// <summary>Gets the command-line arguments associated with a Shell link object.</summary>
			/// <param name="pszArgs">A pointer to the buffer that, when this method returns successfully, receives the command-line arguments.</param>
			/// <param name="cchMaxPath">
			/// The maximum number of characters that can be copied to the buffer supplied by the pszArgs parameter. In the case of a Unicode string, there is no
			/// limitation on maximum string length. In the case of an ANSI string, the maximum length of the returned string varies depending on the version of
			/// Windows—MAX_PATH prior to Windows 2000 and INFOTIPSIZE (defined in Commctrl.h) in Windows 2000 and later.
			/// </param>
			void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);

			/// <summary>Sets the command-line arguments for a Shell link object.</summary>
			/// <param name="pszArgs">
			/// A pointer to a buffer that contains the new command-line arguments. In the case of a Unicode string, there is no limitation on maximum string
			/// length. In the case of an ANSI string, the maximum length of the returned string varies depending on the version of Windows—MAX_PATH prior to
			/// Windows 2000 and INFOTIPSIZE (defined in Commctrl.h) in Windows 2000 and later.
			/// </param>
			void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

			/// <summary>Gets the keyboard shortcut (hot key) for a Shell link object.</summary>
			/// <returns>
			/// The address of the keyboard shortcut. The virtual key code is in the low-order byte, and the modifier flags are in the high-order byte.
			/// </returns>
			ushort GetHotKey();

			/// <summary>Sets a keyboard shortcut (hot key) for a Shell link object.</summary>
			/// <param name="wHotKey">
			/// The new keyboard shortcut. The virtual key code is in the low-order byte, and the modifier flags are in the high-order byte. The modifier flags
			/// can be a combination of the values specified in the description of the IShellLink::GetHotkey method.
			/// </param>
			void SetHotKey(ushort wHotKey);

			/// <summary>Gets the show command for a Shell link object.</summary>
			/// <returns>
			/// A pointer to the command. The following commands are supported.
			/// <list>
			/// <item>
			/// <term>SW_SHOWNORMAL</term>
			/// <description>
			/// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An
			/// application should specify this flag when displaying the window for the first time.
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
			/// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An
			/// application should specify this flag when displaying the window for the first time.
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
			/// The address of a buffer that contains the fully-qualified path of the shortcut file, relative to which the shortcut resolution should be
			/// performed. It should be a file name, not a folder name.
			/// </param>
			/// <param name="dwReserved">Reserved. Set this parameter to zero.</param>
			void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, [Optional] uint dwReserved);

			/// <summary>Attempts to find the target of a Shell link, even if it has been moved or renamed.</summary>
			/// <param name="hwnd">
			/// A handle to the window that the Shell will use as the parent for a dialog box. The Shell displays the dialog box if it needs to prompt the user
			/// for more information while resolving a Shell link.
			/// </param>
			/// <param name="fFlags">Action flags.</param>
			void Resolve(IntPtr hwnd, SLR_FLAGS fFlags);

			/// <summary>Sets the path and file name for the target of a Shell link object.</summary>
			/// <param name="pszFile">The address of a buffer that contains the new path.</param>
			void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
		}

		/// <summary>Exposes methods that control the taskbar. It allows you to dynamically add, remove, and activate items on the taskbar.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("56FDF342-FD6D-11d0-958A-006097C9A090"), CoClass(typeof(CTaskbarList))]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb774652")]
		public interface ITaskbarList
		{
			/// <summary>Initializes the taskbar list object. This method must be called before any other ITaskbarList methods can be called.</summary>
			void HrInit();

			/// <summary>Adds an item to the taskbar.</summary>
			/// <param name="hwnd">A handle to the window to be added to the taskbar.</param>
			void AddTab(IntPtr hwnd);

			/// <summary>Deletes an item from the taskbar.</summary>
			/// <param name="hwnd">A handle to the window to be deleted from the taskbar.</param>
			void DeleteTab(IntPtr hwnd);

			/// <summary>
			/// Activates an item on the taskbar. The window is not actually activated; the window's item on the taskbar is merely displayed as active.
			/// </summary>
			/// <param name="hwnd">A handle to the window on the taskbar to be displayed as active.</param>
			void ActivateTab(IntPtr hwnd);

			/// <summary>Marks a taskbar item as active but does not visually activate it.</summary>
			/// <param name="hwnd">A handle to the window to be marked as active.</param>
			void SetActiveAlt(IntPtr hwnd);
		}

		/// <summary>Extends the ITaskbarList interface by exposing a method to mark a window as a full-screen display.</summary>
		/// <seealso cref="Vanara.PInvoke.ITaskbarList"/>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("602D4995-B13A-429b-A66E-1935E44F4317")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb774638")]
		public interface ITaskbarList2 : ITaskbarList
		{
			/// <summary>Initializes the taskbar list object. This method must be called before any other ITaskbarList methods can be called.</summary>
			new void HrInit();

			/// <summary>Adds an item to the taskbar.</summary>
			/// <param name="hwnd">A handle to the window to be added to the taskbar.</param>
			new void AddTab(IntPtr hwnd);

			/// <summary>Deletes an item from the taskbar.</summary>
			/// <param name="hwnd">A handle to the window to be deleted from the taskbar.</param>
			new void DeleteTab(IntPtr hwnd);

			/// <summary>
			/// Activates an item on the taskbar. The window is not actually activated; the window's item on the taskbar is merely displayed as active.
			/// </summary>
			/// <param name="hwnd">A handle to the window on the taskbar to be displayed as active.</param>
			new void ActivateTab(IntPtr hwnd);

			/// <summary>Marks a taskbar item as active but does not visually activate it.</summary>
			/// <param name="hwnd">A handle to the window to be marked as active.</param>
			new void SetActiveAlt(IntPtr hwnd);

			/// <summary>Marks a window as full-screen.</summary>
			/// <param name="hwnd">The handle of the window to be marked.</param>
			/// <param name="fFullscreen">A Boolean value marking the desired full-screen status of the window.</param>
			void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);
		}

		/// <summary>
		/// Extends ITaskbarList2 by exposing methods that support the unified launching and switching taskbar button functionality added in Windows 7. This
		/// functionality includes thumbnail representations and switch targets based on individual tabs in a tabbed application, thumbnail toolbars,
		/// notification and status overlays, and progress indicators.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.ITaskbarList2"/>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd391692", MinClient = PInvokeClient.Windows7)]
		public interface ITaskbarList3 : ITaskbarList2
		{
			/// <summary>Initializes the taskbar list object. This method must be called before any other ITaskbarList methods can be called.</summary>
			new void HrInit();

			/// <summary>Adds an item to the taskbar.</summary>
			/// <param name="hwnd">A handle to the window to be added to the taskbar.</param>
			new void AddTab(IntPtr hwnd);

			/// <summary>Deletes an item from the taskbar.</summary>
			/// <param name="hwnd">A handle to the window to be deleted from the taskbar.</param>
			new void DeleteTab(IntPtr hwnd);

			/// <summary>
			/// Activates an item on the taskbar. The window is not actually activated; the window's item on the taskbar is merely displayed as active.
			/// </summary>
			/// <param name="hwnd">A handle to the window on the taskbar to be displayed as active.</param>
			new void ActivateTab(IntPtr hwnd);

			/// <summary>Marks a taskbar item as active but does not visually activate it.</summary>
			/// <param name="hwnd">A handle to the window to be marked as active.</param>
			new void SetActiveAlt(IntPtr hwnd);

			/// <summary>Marks a window as full-screen.</summary>
			/// <param name="hwnd">The handle of the window to be marked.</param>
			/// <param name="fFullscreen">A Boolean value marking the desired full-screen status of the window.</param>
			new void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

			/// <summary>Displays or updates a progress bar hosted in a taskbar button to show the specific percentage completed of the full operation.</summary>
			/// <param name="hwnd">The handle of the window whose associated taskbar button is being used as a progress indicator.</param>
			/// <param name="ullCompleted">
			/// An application-defined value that indicates the proportion of the operation that has been completed at the time the method is called.
			/// </param>
			/// <param name="ullTotal">An application-defined value that specifies the value ullCompleted will have when the operation is complete.</param>
			void SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);

			/// <summary>Sets the type and state of the progress indicator displayed on a taskbar button.</summary>
			/// <param name="hwnd">
			/// The handle of the window in which the progress of an operation is being shown. This window's associated taskbar button will display the progress bar.
			/// </param>
			/// <param name="tbpFlags">
			/// Flags that control the current state of the progress button. Specify only one of the following flags; all states are mutually exclusive of all others.
			/// </param>
			void SetProgressState(IntPtr hwnd, TBPFLAG tbpFlags);

			/// <summary>Informs the taskbar that a new tab or document thumbnail has been provided for display in an application's taskbar group flyout.</summary>
			/// <param name="hwndTab">Handle of the tab or document window. This value is required and cannot be NULL.</param>
			/// <param name="hwndMDI">
			/// Handle of the application's main window. This value tells the taskbar which application's preview group to attach the new thumbnail to. This
			/// value is required and cannot be NULL.
			/// </param>
			/// <remarks>
			/// By itself, registering a tab thumbnail alone will not result in its being displayed. You must also call ITaskbarList3::SetTabOrder to instruct
			/// the group where to display it.
			/// </remarks>
			void RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);

			/// <summary>Removes a thumbnail from an application's preview group when that tab or document is closed in the application.</summary>
			/// <param name="hwndTab">
			/// The handle of the tab window whose thumbnail is being removed. This is the same value with which the thumbnail was registered as part the group
			/// through ITaskbarList3::RegisterTab. This value is required and cannot be NULL.
			/// </param>
			/// <remarks>
			/// It is the responsibility of the calling application to free hwndTab through DestroyWindow. UnregisterTab must be called before the handle is freed.
			/// </remarks>
			void UnregisterTab(IntPtr hwndTab);

			/// <summary>
			/// Inserts a new thumbnail into a tabbed-document interface (TDI) or multiple-document interface (MDI) application's group flyout or moves an
			/// existing thumbnail to a new position in the application's group.
			/// </summary>
			/// <param name="hwndTab">
			/// The handle of the tab window whose thumbnail is being placed. This value is required, must already be registered through
			/// ITaskbarList3::RegisterTab, and cannot be NULL.
			/// </param>
			/// <param name="hwndInsertBefore">
			/// The handle of the tab window whose thumbnail that hwndTab is inserted to the left of. This handle must already be registered through
			/// ITaskbarList3::RegisterTab. If this value is NULL, the new thumbnail is added to the end of the list.
			/// </param>
			/// <remarks>This method must be called for the thumbnail to be shown in the group. Call it after you have called ITaskbarList3::RegisterTab.</remarks>
			void SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);

			/// <summary>Informs the taskbar that a tab or document window has been made the active window.</summary>
			/// <param name="hwndTab">
			/// Handle of the active tab window. This handle must already be registered through ITaskbarList3::RegisterTab. This value can be NULL if no tab is active.
			/// </param>
			/// <param name="hwndMDI">
			/// Handle of the application's main window. This value tells the taskbar which group the thumbnail is a member of. This value is required and cannot
			/// be NULL.
			/// </param>
			/// <param name="dwReserved">Reserved; set to 0.</param>
			void SetTabActive(IntPtr hwndTab, IntPtr hwndMDI, uint dwReserved);

			/// <summary>Adds a thumbnail toolbar with a specified set of buttons to the thumbnail image of a window in a taskbar button flyout.</summary>
			/// <param name="hwnd">
			/// The handle of the window whose thumbnail representation will receive the toolbar. This handle must belong to the calling process.
			/// </param>
			/// <param name="cButtons">The number of buttons defined in the array pointed to by pButton. The maximum number of buttons allowed is 7.</param>
			/// <param name="pButtons">
			/// A pointer to an array of THUMBBUTTON structures. Each THUMBBUTTON defines an individual button to be added to the toolbar. Buttons cannot be
			/// added or deleted later, so this must be the full defined set. Buttons also cannot be reordered, so their order in the array, which is the order
			/// in which they are displayed left to right, will be their permanent order.
			/// </param>
			void ThumbBarAddButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

			/// <summary>
			/// Shows, enables, disables, or hides buttons in a thumbnail toolbar as required by the window's current state. A thumbnail toolbar is a toolbar
			/// embedded in a thumbnail image of a window in a taskbar button flyout.
			/// </summary>
			/// <param name="hwnd">The handle of the window whose thumbnail representation contains the toolbar.</param>
			/// <param name="cButtons">
			/// The number of buttons defined in the array pointed to by pButton. The maximum number of buttons allowed is 7. This array contains only structures
			/// that represent existing buttons that are being updated.
			/// </param>
			/// <param name="pButtons">
			/// A pointer to an array of THUMBBUTTON structures. Each THUMBBUTTON defines an individual button. If the button already exists (the iId value is
			/// already defined), then that existing button is updated with the information provided in the structure.
			/// </param>
			void ThumbBarUpdateButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

			/// <summary>
			/// Specifies an image list that contains button images for a toolbar embedded in a thumbnail image of a window in a taskbar button flyout.
			/// </summary>
			/// <param name="hwnd">
			/// The handle of the window whose thumbnail representation contains the toolbar to be updated. This handle must belong to the calling process.
			/// </param>
			/// <param name="himl">The handle of the image list that contains all button images to be used in the toolbar.</param>
			/// <remarks>
			/// Applications must provide these button images:
			/// <list type="bullet">
			/// <item>
			/// <term>The button in its default active state.</term>
			/// </item>
			/// <item>
			/// <term>Images suitable for use with high-dpi (dots per inch) displays.</term>
			/// </item>
			/// </list>
			/// <para>
			/// Images must be 32-bit and of dimensions GetSystemMetrics(SM_CXICON) x GetSystemMetrics(SM_CYICON). The toolbar itself provides visuals for a
			/// button's clicked, disabled, and hover states.
			/// </para>
			/// </remarks>
			void ThumbBarSetImageList(IntPtr hwnd, IntPtr himl);

			/// <summary>Applies an overlay to a taskbar button to indicate application status or a notification to the user.</summary>
			/// <param name="hwnd">
			/// The handle of the window whose associated taskbar button receives the overlay. This handle must belong to a calling process associated with the
			/// button's application and must be a valid HWND or the call is ignored.
			/// </param>
			/// <param name="hIcon">
			/// The handle of an icon to use as the overlay. This should be a small icon, measuring 16x16 pixels at 96 dpi. If an overlay icon is already applied
			/// to the taskbar button, that existing overlay is replaced.
			/// <para>This value can be NULL.How a NULL value is handled depends on whether the taskbar button represents a single window or a group of windows.</para>
			/// <list type="bullet">
			/// <item>
			/// <term>If the taskbar button represents a single window, the overlay icon is removed from the display.</term>
			/// </item>
			/// <item>
			/// <term>
			/// If the taskbar button represents a group of windows and a previous overlay is still available (received earlier than the current overlay, but not
			/// yet freed by a NULL value), then that previous overlay is displayed in place of the current overlay.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// It is the responsibility of the calling application to free hIcon when it is no longer needed.This can generally be done after you call
			/// SetOverlayIcon because the taskbar makes and uses its own copy of the icon.
			/// </para>
			/// </param>
			/// <param name="pszDescription">
			/// A pointer to a string that provides an alt text version of the information conveyed by the overlay, for accessibility purposes.
			/// </param>
			void SetOverlayIcon(IntPtr hwnd, IntPtr hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);

			/// <summary>
			/// Specifies or updates the text of the tooltip that is displayed when the mouse pointer rests on an individual preview thumbnail in a taskbar
			/// button flyout.
			/// </summary>
			/// <param name="hwnd">The handle to the window whose thumbnail displays the tooltip. This handle must belong to the calling process.</param>
			/// <param name="pszTip">
			/// The pointer to the text to be displayed in the tooltip. This value can be NULL, in which case the title of the window specified by hwnd is used
			/// as the tooltip.
			/// </param>
			void SetThumbnailTooltip(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszTip);

			/// <summary>Selects a portion of a window's client area to display as that window's thumbnail in the taskbar.</summary>
			/// <param name="hwnd">The handle to a window represented in the taskbar.</param>
			/// <param name="prcClip">
			/// A pointer to a RECT structure that specifies a selection within the window's client area, relative to the upper-left corner of that client area.
			/// To clear a clip that is already in place and return to the default display of the thumbnail, set this parameter to NULL.
			/// </param>
			void SetThumbnailClip(IntPtr hwnd, ref RECT prcClip);
		}

		/// <summary>Extends ITaskbarList3 by providing a method that allows the caller to control two property values for the tab thumbnail and peek feature.</summary>
		/// <seealso cref="Vanara.PInvoke.ITaskbarList3"/>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd562040")]
		public interface ITaskbarList4 : ITaskbarList3
		{
			/// <summary>Initializes the taskbar list object. This method must be called before any other ITaskbarList methods can be called.</summary>
			new void HrInit();

			/// <summary>Adds an item to the taskbar.</summary>
			/// <param name="hwnd">A handle to the window to be added to the taskbar.</param>
			new void AddTab(IntPtr hwnd);

			/// <summary>Deletes an item from the taskbar.</summary>
			/// <param name="hwnd">A handle to the window to be deleted from the taskbar.</param>
			new void DeleteTab(IntPtr hwnd);

			/// <summary>
			/// Activates an item on the taskbar. The window is not actually activated; the window's item on the taskbar is merely displayed as active.
			/// </summary>
			/// <param name="hwnd">A handle to the window on the taskbar to be displayed as active.</param>
			new void ActivateTab(IntPtr hwnd);

			/// <summary>Marks a taskbar item as active but does not visually activate it.</summary>
			/// <param name="hwnd">A handle to the window to be marked as active.</param>
			new void SetActiveAlt(IntPtr hwnd);

			/// <summary>Marks a window as full-screen.</summary>
			/// <param name="hwnd">The handle of the window to be marked.</param>
			/// <param name="fFullscreen">A Boolean value marking the desired full-screen status of the window.</param>
			new void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

			/// <summary>Displays or updates a progress bar hosted in a taskbar button to show the specific percentage completed of the full operation.</summary>
			/// <param name="hwnd">The handle of the window whose associated taskbar button is being used as a progress indicator.</param>
			/// <param name="ullCompleted">
			/// An application-defined value that indicates the proportion of the operation that has been completed at the time the method is called.
			/// </param>
			/// <param name="ullTotal">An application-defined value that specifies the value ullCompleted will have when the operation is complete.</param>
			new void SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);

			/// <summary>Sets the type and state of the progress indicator displayed on a taskbar button.</summary>
			/// <param name="hwnd">
			/// The handle of the window in which the progress of an operation is being shown. This window's associated taskbar button will display the progress bar.
			/// </param>
			/// <param name="tbpFlags">
			/// Flags that control the current state of the progress button. Specify only one of the following flags; all states are mutually exclusive of all others.
			/// </param>
			new void SetProgressState(IntPtr hwnd, TBPFLAG tbpFlags);

			/// <summary>Informs the taskbar that a new tab or document thumbnail has been provided for display in an application's taskbar group flyout.</summary>
			/// <param name="hwndTab">Handle of the tab or document window. This value is required and cannot be NULL.</param>
			/// <param name="hwndMDI">
			/// Handle of the application's main window. This value tells the taskbar which application's preview group to attach the new thumbnail to. This
			/// value is required and cannot be NULL.
			/// </param>
			/// <remarks>
			/// By itself, registering a tab thumbnail alone will not result in its being displayed. You must also call ITaskbarList3::SetTabOrder to instruct
			/// the group where to display it.
			/// </remarks>
			new void RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);

			/// <summary>Removes a thumbnail from an application's preview group when that tab or document is closed in the application.</summary>
			/// <param name="hwndTab">
			/// The handle of the tab window whose thumbnail is being removed. This is the same value with which the thumbnail was registered as part the group
			/// through ITaskbarList3::RegisterTab. This value is required and cannot be NULL.
			/// </param>
			/// <remarks>
			/// It is the responsibility of the calling application to free hwndTab through DestroyWindow. UnregisterTab must be called before the handle is freed.
			/// </remarks>
			new void UnregisterTab(IntPtr hwndTab);

			/// <summary>
			/// Inserts a new thumbnail into a tabbed-document interface (TDI) or multiple-document interface (MDI) application's group flyout or moves an
			/// existing thumbnail to a new position in the application's group.
			/// </summary>
			/// <param name="hwndTab">
			/// The handle of the tab window whose thumbnail is being placed. This value is required, must already be registered through
			/// ITaskbarList3::RegisterTab, and cannot be NULL.
			/// </param>
			/// <param name="hwndInsertBefore">
			/// The handle of the tab window whose thumbnail that hwndTab is inserted to the left of. This handle must already be registered through
			/// ITaskbarList3::RegisterTab. If this value is NULL, the new thumbnail is added to the end of the list.
			/// </param>
			/// <remarks>This method must be called for the thumbnail to be shown in the group. Call it after you have called ITaskbarList3::RegisterTab.</remarks>
			new void SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);

			/// <summary>Informs the taskbar that a tab or document window has been made the active window.</summary>
			/// <param name="hwndTab">
			/// Handle of the active tab window. This handle must already be registered through ITaskbarList3::RegisterTab. This value can be NULL if no tab is active.
			/// </param>
			/// <param name="hwndMDI">
			/// Handle of the application's main window. This value tells the taskbar which group the thumbnail is a member of. This value is required and cannot
			/// be NULL.
			/// </param>
			/// <param name="dwReserved">Reserved; set to 0.</param>
			new void SetTabActive(IntPtr hwndTab, IntPtr hwndMDI, uint dwReserved);

			/// <summary>Adds a thumbnail toolbar with a specified set of buttons to the thumbnail image of a window in a taskbar button flyout.</summary>
			/// <param name="hwnd">
			/// The handle of the window whose thumbnail representation will receive the toolbar. This handle must belong to the calling process.
			/// </param>
			/// <param name="cButtons">The number of buttons defined in the array pointed to by pButton. The maximum number of buttons allowed is 7.</param>
			/// <param name="pButtons">
			/// A pointer to an array of THUMBBUTTON structures. Each THUMBBUTTON defines an individual button to be added to the toolbar. Buttons cannot be
			/// added or deleted later, so this must be the full defined set. Buttons also cannot be reordered, so their order in the array, which is the order
			/// in which they are displayed left to right, will be their permanent order.
			/// </param>
			new void ThumbBarAddButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

			/// <summary>
			/// Shows, enables, disables, or hides buttons in a thumbnail toolbar as required by the window's current state. A thumbnail toolbar is a toolbar
			/// embedded in a thumbnail image of a window in a taskbar button flyout.
			/// </summary>
			/// <param name="hwnd">The handle of the window whose thumbnail representation contains the toolbar.</param>
			/// <param name="cButtons">
			/// The number of buttons defined in the array pointed to by pButton. The maximum number of buttons allowed is 7. This array contains only structures
			/// that represent existing buttons that are being updated.
			/// </param>
			/// <param name="pButtons">
			/// A pointer to an array of THUMBBUTTON structures. Each THUMBBUTTON defines an individual button. If the button already exists (the iId value is
			/// already defined), then that existing button is updated with the information provided in the structure.
			/// </param>
			new void ThumbBarUpdateButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

			/// <summary>
			/// Specifies an image list that contains button images for a toolbar embedded in a thumbnail image of a window in a taskbar button flyout.
			/// </summary>
			/// <param name="hwnd">
			/// The handle of the window whose thumbnail representation contains the toolbar to be updated. This handle must belong to the calling process.
			/// </param>
			/// <param name="himl">The handle of the image list that contains all button images to be used in the toolbar.</param>
			/// <remarks>
			/// Applications must provide these button images:
			/// <list type="bullet">
			/// <item>
			/// <term>The button in its default active state.</term>
			/// </item>
			/// <item>
			/// <term>Images suitable for use with high-dpi (dots per inch) displays.</term>
			/// </item>
			/// </list>
			/// <para>
			/// Images must be 32-bit and of dimensions GetSystemMetrics(SM_CXICON) x GetSystemMetrics(SM_CYICON). The toolbar itself provides visuals for a
			/// button's clicked, disabled, and hover states.
			/// </para>
			/// </remarks>
			new void ThumbBarSetImageList(IntPtr hwnd, IntPtr himl);

			/// <summary>Applies an overlay to a taskbar button to indicate application status or a notification to the user.</summary>
			/// <param name="hwnd">
			/// The handle of the window whose associated taskbar button receives the overlay. This handle must belong to a calling process associated with the
			/// button's application and must be a valid HWND or the call is ignored.
			/// </param>
			/// <param name="hIcon">
			/// The handle of an icon to use as the overlay. This should be a small icon, measuring 16x16 pixels at 96 dpi. If an overlay icon is already applied
			/// to the taskbar button, that existing overlay is replaced.
			/// <para>This value can be NULL.How a NULL value is handled depends on whether the taskbar button represents a single window or a group of windows.</para>
			/// <list type="bullet">
			/// <item>
			/// <term>If the taskbar button represents a single window, the overlay icon is removed from the display.</term>
			/// </item>
			/// <item>
			/// <term>
			/// If the taskbar button represents a group of windows and a previous overlay is still available (received earlier than the current overlay, but not
			/// yet freed by a NULL value), then that previous overlay is displayed in place of the current overlay.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// It is the responsibility of the calling application to free hIcon when it is no longer needed.This can generally be done after you call
			/// SetOverlayIcon because the taskbar makes and uses its own copy of the icon.
			/// </para>
			/// </param>
			/// <param name="pszDescription">
			/// A pointer to a string that provides an alt text version of the information conveyed by the overlay, for accessibility purposes.
			/// </param>
			new void SetOverlayIcon(IntPtr hwnd, IntPtr hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);

			/// <summary>
			/// Specifies or updates the text of the tooltip that is displayed when the mouse pointer rests on an individual preview thumbnail in a taskbar
			/// button flyout.
			/// </summary>
			/// <param name="hwnd">The handle to the window whose thumbnail displays the tooltip. This handle must belong to the calling process.</param>
			/// <param name="pszTip">
			/// The pointer to the text to be displayed in the tooltip. This value can be NULL, in which case the title of the window specified by hwnd is used
			/// as the tooltip.
			/// </param>
			new void SetThumbnailTooltip(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszTip);

			/// <summary>Selects a portion of a window's client area to display as that window's thumbnail in the taskbar.</summary>
			/// <param name="hwnd">The handle to a window represented in the taskbar.</param>
			/// <param name="prcClip">
			/// A pointer to a RECT structure that specifies a selection within the window's client area, relative to the upper-left corner of that client area.
			/// To clear a clip that is already in place and return to the default display of the thumbnail, set this parameter to NULL.
			/// </param>
			new void SetThumbnailClip(IntPtr hwnd, ref RECT prcClip);

			/// <summary>
			/// Allows a tab to specify whether the main application frame window or the tab window should be used as a thumbnail or in the peek feature under
			/// certain circumstances.
			/// </summary>
			/// <param name="hwndTab">The handle of the tab window that is to have properties set. This handle must already be registered through RegisterTab.</param>
			/// <param name="stpFlags">
			/// One or more members of the STPFLAG enumeration that specify the displayed thumbnail and peek image source of the tab thumbnail.
			/// </param>
			void SetTabProperties(IntPtr hwndTab, STPFLAG stpFlags);
		}

		/// <summary>Retrieves the User Model AppID that has been explicitly set for the current process via SetCurrentProcessExplicitAppUserModelID</summary>
		/// <param name="AppID">The application identifier.</param>
		/// <returns></returns>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378419")]
		public static extern HRESULT GetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string AppID);

		/// <summary>Clones an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be cloned.</param>
		/// <returns>Returns a pointer to a copy of the ITEMIDLIST structure pointed to by pidl.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776433")]
		public static extern PIDL ILClone(IntPtr pidl);

		/// <summary>Clones the first SHITEMID structure in an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be cloned.</param>
		/// <returns>
		/// A pointer to an ITEMIDLIST structure that contains the first SHITEMID structure from the ITEMIDLIST structure specified by pidl. Returns NULL on failure.
		/// </returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776435")]
		public static extern PIDL ILCloneFirst(IntPtr pidl);

		/// <summary>Combines two ITEMIDLIST structures.</summary>
		/// <param name="pidl1">A pointer to the first ITEMIDLIST structure.</param>
		/// <param name="pidl2">A pointer to the second ITEMIDLIST structure. This structure is appended to the structure pointed to by pidl1.</param>
		/// <returns>
		/// Returns an ITEMIDLIST containing the combined structures. If you set either pidl1 or pidl2 to NULL, the returned ITEMIDLIST structure is a clone of
		/// the non-NULL parameter. Returns NULL if pidl1 and pidl2 are both set to NULL.
		/// </returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776437")]
		public static extern PIDL ILCombine(IntPtr pidl1, IntPtr pidl2);

		/// <summary>Returns the ITEMIDLIST structure associated with a specified file path.</summary>
		/// <param name="pszPath">
		/// A pointer to a null-terminated Unicode string that contains the path. This string should be no more than MAX_PATH characters in length, including the
		/// terminating null character.
		/// </param>
		/// <returns>Returns a pointer to an ITEMIDLIST structure that corresponds to the path.</returns>
		[DllImport(Lib.Shell32, CharSet = CharSet.Auto, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378420")]
		public static extern PIDL ILCreateFromPath(string pszPath);

		/// <summary>Returns a pointer to the last SHITEMID structure in an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to an ITEMIDLIST structure.</param>
		/// <returns>A pointer to the last SHITEMID structure in pidl.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776440")]
		public static extern PIDL ILFindLastID(IntPtr pidl);

		/// <summary>Returns the size, in bytes, of an SHITEMID structure.</summary>
		/// <param name="pidl">A pointer to an SHITEMID structure.</param>
		/// <returns>The size of the SHITEMID structure specified by pidl, in bytes.</returns>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762502")]
		public static int ILGetItemSize(IntPtr pidl) => pidl.Equals(IntPtr.Zero) ? 0 : Marshal.ReadInt16(pidl);

		/// <summary>Retrieves the next SHITEMID structure in an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to a particular SHITEMID structure in a larger ITEMIDLIST structure.</param>
		/// <returns>
		/// Returns a pointer to the SHITEMID structure that follows the one specified by pidl. Returns NULL if pidl points to the last SHITEMID structure.
		/// </returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776442")]
		public static extern IntPtr ILGetNext(IntPtr pidl);

		/// <summary>Returns the size, in bytes, of an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to an ITEMIDLIST structure.</param>
		/// <returns>The size of the ITEMIDLIST structure specified by pidl, in bytes.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776443")]
		public static extern uint ILGetSize(IntPtr pidl);

		/// <summary>Verifies whether a pointer to an item identifier list (PIDL) is a child PIDL, which is a PIDL with exactly one SHITEMID.</summary>
		/// <param name="pidl">A constant, unaligned, relative PIDL that is being checked.</param>
		/// <returns>Returns TRUE if the given PIDL is a child PIDL; otherwise, FALSE.</returns>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776446")]
		public static bool ILIsChild(IntPtr pidl) => ILIsEmpty(pidl) || ILIsEmpty(ILNext(pidl));

		/// <summary>Verifies whether an ITEMIDLIST structure is empty.</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be checked.</param>
		/// <returns>TRUE if the pidl parameter is NULL or the ITEMIDLIST structure pointed to by pidl is empty; otherwise FALSE.</returns>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776447")]
		public static bool ILIsEmpty(IntPtr pidl) => ILGetItemSize(pidl) == 0;

		/// <summary>Tests whether two ITEMIDLIST structures are equal in a binary comparison.</summary>
		/// <param name="pidl1">The first ITEMIDLIST structure.</param>
		/// <param name="pidl2">The second ITEMIDLIST structure.</param>
		/// <returns>Returns TRUE if the two structures are equal, FALSE otherwise.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776448")]
		public static extern bool ILIsEqual(IntPtr pidl1, IntPtr pidl2);

		/// <summary>Tests whether an ITEMIDLIST structure is the parent of another ITEMIDLIST structure.</summary>
		/// <param name="pidl1">A pointer to an ITEMIDLIST (PIDL) structure that specifies the parent. This must be an absolute PIDL.</param>
		/// <param name="pidl2">A pointer to an ITEMIDLIST (PIDL) structure that specifies the child. This must be an absolute PIDL.</param>
		/// <param name="fImmediate">A Boolean value that is set to TRUE to test for immediate parents of pidl2, or FALSE to test for any parents of pidl2.</param>
		/// <returns>
		/// Returns TRUE if pidl1 is a parent of pidl2. If fImmediate is set to TRUE, the function only returns TRUE if pidl1 is the immediate parent of pidl2.
		/// Otherwise, the function returns FALSE.
		/// </returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776449")]
		public static extern bool ILIsParent(IntPtr pidl1, IntPtr pidl2, [MarshalAs(UnmanagedType.Bool)] bool fImmediate);

		/// <summary>Retrieves the next SHITEMID structure in an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A constant, unaligned, relative PIDL for which the next SHITEMID structure is being retrieved.</param>
		/// <returns>
		/// When this function returns, contains one of three results: If pidl is valid and not the last SHITEMID in the ITEMIDLIST, then it contains a pointer
		/// to the next ITEMIDLIST structure. If the last ITEMIDLIST structure is passed, it contains NULL, which signals the end of the PIDL. For other values
		/// of pidl, the return value is meaningless.
		/// </returns>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776454")]
		public static IntPtr ILNext(IntPtr pidl)
		{
			var size = ILGetItemSize(pidl);
			return size == 0 ? IntPtr.Zero : pidl.Offset(size);
		}

		/// <summary>Removes the last SHITEMID structure from an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be shortened. When the function returns, this variable points to the shortened structure.</param>
		/// <returns>Returns TRUE if successful, FALSE otherwise.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true, SetLastError = false)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776456")]
		public static extern bool ILRemoveLastID(IntPtr pidl);

		/// <summary>Returns the ITEMIDLIST structure associated with a specified file path.</summary>
		/// <param name="pszPath">
		/// A pointer to a null-terminated Unicode string that contains the path. This string should be no more than MAX_PATH characters in length, including the
		/// terminating null character.
		/// </param>
		/// <returns>Returns a pointer to an ITEMIDLIST structure that corresponds to the path.</returns>
		[DllImport(Lib.Shell32, EntryPoint = "ILCreateFromPath", SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378420")]
		public static extern IntPtr IntILCreateFromPath(string pszPath);

		/// <summary>
		/// Specifies a unique application-defined Application User Model ID (AppUserModelID) that identifies the current process to the taskbar. This identifier
		/// allows an application to group its associated processes and windows under a single taskbar button.
		/// </summary>
		/// <param name="AppID">Pointer to the AppUserModelID to assign to the current process.</param>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378422")]
		public static extern HRESULT SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] string AppID);

		/// <summary>
		/// Creates and initializes a Shell item object from a pointer to an item identifier list (PIDL). The resulting shell item object supports the IShellItem interface.
		/// </summary>
		/// <param name="pidl">The source PIDL.</param>
		/// <param name="riid">A reference to the IID of the requested interface.</param>
		/// <param name="ppv">When this function returns, contains the interface pointer requested in riid. This will typically be IShellItem or IShellItem2.</param>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762133")]
		public static extern void SHCreateItemFromIDList(PIDL pidl, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);

		/// <summary>
		/// <summary>Creates and initializes a Shell item object from a parsing name.</summary>
		/// <param name="pszPath">A pointer to a display name.</param>
		/// <param name="pbc">Optional. A pointer to a bind context used to pass parameters as inputs and outputs to the parsing function. These passed parameters are often specific to the data source and are documented by the data source owners. For example, the file system data source accepts the name being parsed (as a WIN32_FIND_DATA structure), using the STR_FILE_SYS_BIND_DATA bind context parameter.
		/// <para>STR_PARSE_PREFER_FOLDER_BROWSING can be passed to indicate that URLs are parsed using the file system data source when possible.Construct a bind context object using CreateBindCtx and populate the values using IBindCtx::RegisterObjectParam. See Bind Context String Keys for a complete list of these.See the Parsing With Parameters Sample for an example of the use of this parameter.</para>
		/// <para>If no data is being passed to or received from the parsing function, this value can be NULL.</para></param>
		/// <param name="riid">A reference to the IID of the interface to retrieve through ppv, typically IID_IShellItem or IID_IShellItem2.</param>
		/// <param name="ppv">When this method returns successfully, contains the interface pointer requested in riid. This is typically IShellItem or IShellItem2.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shlobjidl.h", MSDNShortId = "bb762134")]
		public static extern HRESULT SHCreateItemFromParsingName(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszPath,
			[In, Optional] IBindCtx pbc,
			[In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
			[MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object ppv);

		/// Creates and initializes a Shell item object from a relative parsing name.
		/// </summary>
		/// <param name="psiParent">A pointer to the parent Shell item.</param>
		/// <param name="pszName">A pointer to a null-terminated, Unicode string that specifies a display name that is relative to the psiParent.</param>
		/// <param name="pbc">A pointer to a bind context that controls the parsing operation. This parameter can be NULL.</param>
		/// <param name="riid">A reference to an interface ID.</param>
		/// <param name="ppv">When this function returns, contains the interface pointer requested in riid. This will usually be IShellItem or IShellItem2.</param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762135")]
		public static extern HRESULT SHCreateItemFromRelativeName([In, MarshalAs(UnmanagedType.Interface)] IShellItem psiParent, [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
			[In, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);

		/// <summary>
		/// Creates a Shell item object for a single file that exists inside a known folder.
		/// </summary>
		/// <param name="kfid">A reference to the KNOWNFOLDERID, a GUID that identifies the folder that contains the item.</param>
		/// <param name="dwKFFlags">Flags that specify special options in the object retrieval. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.</param>
		/// <param name="pszItem">A pointer to a null-terminated buffer that contains the file name of the new item as a Unicode string. This parameter can also be NULL. In this case, an IShellItem that represents the known folder itself is created.</param>
		/// <param name="riid">A reference to an interface ID.</param>
		/// <param name="ppv">When this function returns, contains the interface pointer requested in riid. This will usually be IShellItem or IShellItem2.</param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762136")]
		public static extern HRESULT SHCreateItemInKnownFolder([In, MarshalAs(UnmanagedType.LPStruct)] Guid kfid, [In] KNOWN_FOLDER_FLAG dwKFFlags,
			[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pszItem, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);

		/// <summary>
		/// Create a Shell item, given a parent folder and a child item ID.
		/// </summary>
		/// <param name="pidlParent">The IDList of the parent folder of the item being created; the IDList of psfParent. This parameter can be NULL, if psfParent is specified.</param>
		/// <param name="psfParent">A pointer to IShellFolder interface that specifies the shell data source of the child item specified by the pidl.This parameter can be NULL, if pidlParent is specified.</param>
		/// <param name="pidl">A child item ID relative to its parent folder specified by psfParent or pidlParent.</param>
		/// <param name="riid">A reference to an interface ID.</param>
		/// <param name="ppvItem">When this function returns, contains the interface pointer requested in riid. This will usually be IShellItem or IShellItem2.</param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762137")]
		public static extern HRESULT SHCreateItemWithParent([In] PIDL pidlParent, [In, MarshalAs(UnmanagedType.Interface)] IShellFolder psfParent,
			[In] PIDL pidl, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvItem);

		// [DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		// [SecurityCritical, SuppressUnmanagedCodeSecurity]
		// [PInvokeData("Shlobj.h", MSDNShortId = "bb762141")]
		// public static extern HRESULT SHCreateShellFolderView([In] ref SFV_CREATE pcsfv, [MarshalAs(UnmanagedType.Interface)] out object ppvItem);

		/// <summary>
		/// Creates a Shell item array object.
		/// </summary>
		/// <param name="pidlParent">The ID list of the parent folder of the items specified in ppidl. If psf is specified, this parameter can be NULL. If this pidlParent is not specified, it is computed from the psf parameter using IPersistFolder2.</param>
		/// <param name="psf">The Shell data source object that is the parent of the child items specified in ppidl. If pidlParent is specified, this parameter can be NULL.</param>
		/// <param name="cidl">The number of elements in the array specified by ppidl.</param>
		/// <param name="ppidl">The list of child item IDs for which the array is being created. This value can be NULL.</param>
		/// <param name="ppsiItemArray">When this function returns, contains the address of an <see cref="IShellItemArray"/> interface pointer.</param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762144")]
		public static extern HRESULT SHCreateShellItemArray([In] PIDL pidlParent, [In, MarshalAs(UnmanagedType.Interface)] IShellFolder psf,
			uint cidl, [In] PIDL ppidl,  out IShellItemArray ppsiItemArray);

		/// <summary>
		/// Creates a Shell item array object from a list of ITEMIDLIST structures.
		/// </summary>
		/// <param name="cidl">The number of elements in the array.</param>
		/// <param name="rgpidl">A list of cidl constant pointers to ITEMIDLIST structures.</param>
		/// <param name="ppsiItemArray">When this function returns, contains an IShellItemArray interface pointer.</param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762146")]
		public static extern HRESULT SHCreateShellItemArrayFromIDLists(uint cidl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] rgpidl, out IShellItemArray ppsiItemArray);

		/// <summary>
		/// Creates an array of one element from a single Shell item.
		/// </summary>
		/// <param name="psi">Pointer to IShellItem object that represents the item.</param>
		/// <param name="riid">A reference to the IID of the interface to retrieve through ppv, typically IID_IShellItemArray.</param>
		/// <param name="ppv">When this method returns, contains the interface pointer requested in riid. This is typically a pointer to an IShellItemArray.</param>
		[DllImport(Lib.Shell32, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762147")]
		public static extern HRESULT SHCreateShellItemArrayFromShellItem([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, out IShellItemArray ppv);

		/// <summary>Returns a property store for an item, given a path or parsing name.</summary>
		/// <param name="pszPath">A pointer to a null-terminated Unicode string that specifies the item path.</param>
		/// <param name="pbc">A pointer to a IBindCtx object, which provides access to a bind context. This value can be NULL.</param>
		/// <param name="flags">One or more values from the GETPROPERTYSTOREFLAGS constants. This parameter can also be NULL.</param>
		/// <param name="riid">A reference to the desired interface ID.</param>
		/// <param name="propertyStore">
		/// When this function returns, contains the interface pointer requested in riid. This is typically IPropertyStore or a related interface.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shlobjidl.h", MSDNShortId = "bb762197")]
		public static extern HRESULT SHGetPropertyStoreFromParsingName(
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszPath,
			[In] IBindCtx pbc,
			GETPROPERTYSTOREFLAGS flags,
			[MarshalAs(UnmanagedType.LPStruct)] Guid riid,
			[Out] out IPropertyStore propertyStore);

		/// <summary>Clones an ITEMIDLIST structure.</summary>
		/// <param name="pidl">A pointer to the ITEMIDLIST structure to be cloned.</param>
		/// <returns>Returns a pointer to a copy of the ITEMIDLIST structure pointed to by pidl.</returns>
		[DllImport(Lib.Shell32, EntryPoint = "ILClone", SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776433")]
		internal static extern IntPtr IntILClone(IntPtr pidl);

		/// <summary>Combines two ITEMIDLIST structures.</summary>
		/// <param name="pidl1">A pointer to the first ITEMIDLIST structure.</param>
		/// <param name="pidl2">A pointer to the second ITEMIDLIST structure. This structure is appended to the structure pointed to by pidl1.</param>
		/// <returns>
		/// Returns an ITEMIDLIST containing the combined structures. If you set either pidl1 or pidl2 to NULL, the returned ITEMIDLIST structure is a clone of
		/// the non-NULL parameter. Returns NULL if pidl1 and pidl2 are both set to NULL.
		/// </returns>
		[DllImport(Lib.Shell32, EntryPoint = "ILCombine", SetLastError = false)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb776437")]
		internal static extern IntPtr IntILCombine(IntPtr pidl1, IntPtr pidl2);

		/// <summary>Defines the specifics of a known folder.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb773325")]
		public struct KNOWNFOLDER_DEFINITION
		{
			/// <summary>A single value from the KF_CATEGORY constants that classifies the folder as virtual, fixed, common, or per-user.</summary>
			public KF_CATEGORY category;

			/// <summary>
			/// A pointer to the non-localized, canonical name for the known folder, stored as a null-terminated Unicode string. If this folder is a common or
			/// per-user folder, this value is also used as the value name of the "User Shell Folders" registry settings. This name is meant to be a unique,
			/// human-readable name. Third parties are recommended to follow the format Company.Application.Name. The name given here should not be confused with
			/// the display name.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszName;

			/// <summary>
			/// A pointer to a short description of the known folder, stored as a null-terminated Unicode string. This description should include the folder's
			/// purpose and usage.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszDescription;

			/// <summary>
			/// A KNOWNFOLDERID value that names another known folder to serve as the parent folder. Applies to common and per-user folders only. This value is
			/// used in conjunction with pszRelativePath. See Remarks for more details. This value is optional if no value is provided for pszRelativePath.
			/// </summary>
			public Guid fidParent;

			/// <summary>
			/// Optional. A pointer to a path relative to the parent folder specified in fidParent. This is a null-terminated Unicode string, refers to the
			/// physical file system path, and is not localized. Applies to common and per-user folders only. See Remarks for more details.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszRelativePath;

			/// <summary>
			/// A pointer to the Shell namespace folder path of the folder, stored as a null-terminated Unicode string. Applies to virtual folders only. For
			/// example, Control Panel has a parsing name of ::%CLSID_MyComputer%\::%CLSID_ControlPanel%.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszParsingName;

			/// <summary>
			/// Optional. A pointer to the default tooltip resource used for this known folder when it is created. This is a null-terminated Unicode string in
			/// this form:
			/// <para><c>Module name, Resource ID</c></para>
			/// <para>
			/// For example, @%_SYS_MOD_PATH%,-12688 is the tooltip for Common Pictures.When the folder is created, this string is stored in that folder's copy
			/// of Desktop.ini. It can be changed later by other Shell APIs. This resource might be localized.
			/// </para>
			/// <para>This information is not required for virtual folders.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszTooltip;

			/// <summary>
			/// Optional. A pointer to the default localized name resource used when the folder is created. This is a null-terminated Unicode string in this form:
			/// <para><c>Module name, Resource ID</c></para>
			/// <para>When the folder is created, this string is stored in that folder's copy of Desktop.ini. It can be changed later by other Shell APIs.</para>
			/// <para>This information is not required for virtual folders.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszLocalizedName;

			/// <summary>
			/// Optional. A pointer to the default icon resource used when the folder is created. This is a null-terminated Unicode string in this form:
			/// <para><c>Module name, Resource ID</c></para>
			/// <para>When the folder is created, this string is stored in that folder's copy of Desktop.ini. It can be changed later by other Shell APIs.</para>
			/// <para>This information is not required for virtual folders.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszIcon;

			/// <summary>
			/// Optional. A pointer to a Security Descriptor Definition Language format string. This is a null-terminated Unicode string that describes the
			/// default security descriptor that the folder receives when it is created. If this parameter is NULL, the new folder inherits the security
			/// descriptor of its parent. This is particularly useful for common folders that are accessed by all users.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszSecurity;

			/// <summary>
			/// Optional. Default file system attributes given to the folder when it is created. For example, the file could be hidden and read-only
			/// (FILE_ATTRIBUTE_HIDDEN and FILE_ATTRIBUTE_READONLY). For a complete list of possible values, see the dwFlagsAndAttributes parameter of the
			/// CreateFile function. Set to -1 if not needed.
			/// </summary>
			public uint dwAttributes;

			/// <summary>
			/// Optional. One of more values from the KF_DEFINITION_FLAGS enumeration that allow you to restrict redirection, allow PC-to-PC roaming, and control
			/// the time at which the known folder is created. Set to 0 if not needed.
			/// </summary>
			public KF_DEFINITION_FLAGS kfdFlags;

			/// <summary>
			/// One of the FOLDERTYPEID values that identifies the known folder type based on its contents (such as documents, music, or photographs). This value
			/// is a GUID.
			/// </summary>
			public Guid ftidType;
		}

		/// <summary>Used by methods of the ITaskbarList3 interface to define buttons used in a toolbar embedded in a window's thumbnail representation.</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Unicode)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd391559")]
		public struct THUMBBUTTON
		{
			/// <summary>The THBN clicked</summary>
			public const int THBN_CLICKED = 0x1800;

			/// <summary>
			/// A combination of THUMBBUTTONMASK values that specify which members of this structure contain valid data; other members are ignored, with the
			/// exception of iId, which is always required.
			/// </summary>
			public THUMBBUTTONMASK dwMask;

			/// <summary>The application-defined identifier of the button, unique within the toolbar.</summary>
			public uint iId;

			/// <summary>The zero-based index of the button image within the image list set through ITaskbarList3::ThumbBarSetImageList.</summary>
			public uint iBitmap;

			/// <summary>The handle of an icon to use as the button image.</summary>
			public IntPtr hIcon;

			/// <summary>A wide character array that contains the text of the button's tooltip, displayed when the mouse pointer hovers over the button.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string szTip;

			/// <summary>A combination of THUMBBUTTONFLAGS values that control specific states and behaviors of the button.</summary>
			public THUMBBUTTONFLAGS dwFlags;

			/// <summary>The default</summary>
			public static THUMBBUTTON Default = new THUMBBUTTON { dwMask = THUMBBUTTONMASK.THB_FLAGS, dwFlags = THUMBBUTTONFLAGS.THBF_HIDDEN };
		}

		/// <remarks>Methods in this class will only work on Vista and above.</remarks>
		public static class ShellUtil
		{
			public static KNOWNFOLDERID GetKnownFolderFromGuid(Guid knownFolder)
			{
				return Enum.GetValues(typeof(KNOWNFOLDERID)).Cast<KNOWNFOLDERID>().Single(k => k.Guid() == knownFolder);
			}

			public static KNOWNFOLDERID GetKnownFolderFromPath(string path)
			{
				if (Environment.OSVersion.Version.Major < 6)
					return Enum.GetValues(typeof(KNOWNFOLDERID)).Cast<KNOWNFOLDERID>().Single(k => string.Equals(k.FullPath(), path, StringComparison.InvariantCultureIgnoreCase));
				var ikfm = (IKnownFolderManager)new CKnownFolderManager();
				return GetKnownFolderFromGuid(ikfm.FindFolderFromPath(path, FFFP_MODE.FFFP_EXACTMATCH).GetId());
			}

			/// <securitynote>Critical: Resolves an opaque Guid into a path on the user's machine. Calls critical SHGetFolderPathEx</securitynote>
			[SecurityCritical]
			public static string GetPathForKnownFolder(Guid knownFolder)
			{
				if (knownFolder == default(Guid))
					return null;

				var pathBuilder = new StringBuilder(260);
				try { SHGetFolderPathEx(knownFolder, 0, null, pathBuilder, (uint)pathBuilder.Capacity); }
				catch { return null; }
				return pathBuilder.ToString();
			}

			/// <securitynote>Critical: Resolves an opaque interface into a path on the user's machine.</securitynote>
			[SecurityCritical]
			public static string GetPathFromShellItem(IShellItem item) => item.GetDisplayName(SIGDN.SIGDN_DESKTOPABSOLUTEEDITING);

			/// <securitynote>Critical: Calls SHCreateItemFromParsingName</securitynote>
			[SecurityCritical]
			public static IShellItem GetShellItemForPath(string path)
			{
				if (string.IsNullOrEmpty(path))
					return null;

				SHCreateItemFromParsingName(path, null, Marshal.GenerateGuidForType(typeof(IShellItem)), out object unk);
				return (IShellItem)unk;
			}
		}

		[ComImport, Guid("77f10cf0-3db5-4966-b520-b7c54fd35ed6"), ClassInterface(ClassInterfaceType.None)]
		public class CDestinationList { }

		[ComImport, Guid("2d3468c1-36a7-43b6-ac24-d3f02fd9607a"), ClassInterface(ClassInterfaceType.None)]
		public class CEnumerableObjectCollection { }

		[ComImport, Guid("4df0c730-df9d-4ae3-9153-aa6b82e9795a"), ClassInterface(ClassInterfaceType.None)]
		public class CKnownFolderManager { }

		[ComImport, Guid("00021401-0000-0000-C000-000000000046"), ClassInterface(ClassInterfaceType.None)]
		public class CShellLinkW { }

		[ComImport, Guid("56FDF344-FD6D-11d0-958A-006097C9A090"), ClassInterface(ClassInterfaceType.None)]
		public class CTaskbarList { }
	}
}