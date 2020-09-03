using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Describes match criteria. Used by methods of the IKnownFolderManager interface.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762505")]
		public enum FFFP_MODE
		{
			/// <summary>Exact match.</summary>
			FFFP_EXACTMATCH,

			/// <summary>Nearest parent match.</summary>
			FFFP_NEARESTPARENTMATCH,
		}

		/// <summary>Value that represent a category by which a folder registered with the Known Folder system can be classified.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762512")]
		public enum KF_CATEGORY
		{
			/// <summary>
			/// Virtual folders are not part of the file system, which is to say that they have no path. For example, Control Panel and
			/// Printers are virtual folders. A number of features such as folder path and redirection do not apply to this category.
			/// </summary>
			KF_CATEGORY_VIRTUAL = 1,

			/// <summary>
			/// Fixed file system folders are not managed by the Shell and are usually given a permanent path when the system is installed.
			/// For example, the Windows and Program Files folders are fixed folders. A number of features such as redirection do not apply
			/// to this category.
			/// </summary>
			KF_CATEGORY_FIXED = 2,

			/// <summary>
			/// Common folders are those file system folders used for sharing data and settings, accessible by all users of a system. For
			/// example, all users share a common Documents folder as well as their per-user Documents folder.
			/// </summary>
			KF_CATEGORY_COMMON = 3,

			/// <summary>
			/// Per-user folders are those stored under each user's profile and accessible only by that user. For example,
			/// %USERPROFILE%\Pictures. This category of folder usually supports many features including aliasing, redirection and customization.
			/// </summary>
			KF_CATEGORY_PERUSER = 4,
		}

		/// <summary>Flags that specify certain known folder behaviors. Used with the KNOWNFOLDER_DEFINITION structure.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762513")]
		[Flags]
		public enum KF_DEFINITION_FLAGS
		{
			/// <summary>
			/// Prevent a per-user known folder from being redirected to a network location. Note that if the known folder has been flagged
			/// with KFDF_LOCAL_REDIRECT_ONLY but it is a subfolder of a known folder that is redirected to a network location, this
			/// subfolder is redirected also.
			/// </summary>
			KFDF_LOCAL_REDIRECT_ONLY = 0x00000002,

			/// <summary>Can be roamed through a PC-to-PC synchronization.</summary>
			KFDF_ROAMABLE = 0x00000004,

			/// <summary>
			/// Create the folder when the user first logs on. Normally a known folder is not created until it is first called. At that
			/// time, an API such as SHCreateItemInKnownFolder or IKnownFolder::GetShellItem is called with the KF_FLAG_CREATE flag.
			/// However, some known folders need to exist immediately. An example is those known folders under %USERPROFILE%, which must
			/// exist to provide a proper view. In those cases, KFDF_PRECREATE is set and Windows Explorer calls the creation API during its
			/// user initialization.
			/// </summary>
			KFDF_PRECREATE = 0x00000008,

			/// <summary>Introduced in Windows 7. The known folder is a file rather than a folder.</summary>
			KFDF_STREAM = 0x00000010,

			/// <summary>
			/// Introduced in Windows 7. The full path of the known folder, with any environment variables fully expanded, is stored in the
			/// registry under HKEY_CURRENT_USER.
			/// </summary>
			KFDF_PUBLISHEXPANDEDPATH = 0x00000020,

			/// <summary>Introduced in Windows 8.1. Prevent showing the Locations tab in the property dialog of the known folder.</summary>
			KFDF_NO_REDIRECT_UI = 0x00000040,
		}

		/// <summary>
		/// Flags used by IKnownFolderManager::Redirect to specify details of a known folder redirection such as permissions and ownership
		/// for the redirected folder.
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
			/// Sets the user as the owner of a newly created target folder unless the user is a member of the Administrator group, in which
			/// case Administrator is set as the owner. Must be called with KF_REDIRECT_SET_OWNER_EXPLICIT.
			/// </summary>
			KF_REDIRECT_OWNER_USER = 0x00000004,

			/// <summary>
			/// Set the owner of a newly created target folder. If the user belongs to the Administrators group, Administrators is assigned
			/// as the owner. Must be called with KF_REDIRECT_OWNER_USER.
			/// </summary>
			KF_REDIRECT_SET_OWNER_EXPLICIT = 0x00000008,

			/// <summary>
			/// Do not perform a redirection, simply check whether redirection has occurred. If so, IKnownFolderManager::Redirect returns
			/// S_OK; if not, or if some actions remain to be completed, it returns S_FALSE.
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
			/// The folder can be redirected if any of the bits in the lower byte of the value are set but no DENY flag is set. DENY flags
			/// are found in the upper byte of the value.
			/// </summary>
			KF_REDIRECTION_CAPABILITIES_ALLOW_ALL = 0x000000FF,

			/// <summary>
			/// The folder can be redirected. Currently, redirection exists for only common and user folders; fixed and virtual folders
			/// cannot be redirected.
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

		/// <summary>Specify special retrieval options for known folders. These values supersede CSIDL values, which have parallel meanings.</summary>
		[Flags]
		[PInvokeData("Shlobj.h", MSDNShortId = "dd378447")]
		public enum KNOWN_FOLDER_FLAG : uint
		{
			/// <summary>No flags.</summary>
			KF_FLAG_DEFAULT = 0x00000000,

			/// <summary>
			/// Build a simple IDList (PIDL) This value can be used when you want to retrieve the file system path but do not specify this
			/// value if you are retrieving the localized display name of the folder because it might not resolve correctly.
			/// </summary>
			KF_FLAG_SIMPLE_IDLIST = 0x00000100,

			/// <summary>
			/// Gets the folder's default path independent of the current location of its parent. KF_FLAG_DEFAULT_PATH must also be set.
			/// </summary>
			KF_FLAG_NOT_PARENT_RELATIVE = 0x00000200,

			/// <summary>
			/// Gets the default path for a known folder. If this flag is not set, the function retrieves the current—and possibly
			/// redirected—path of the folder. The execution of this flag includes a verification of the folder's existence unless
			/// KF_FLAG_DONT_VERIFY is set.
			/// </summary>
			KF_FLAG_DEFAULT_PATH = 0x00000400,

			/// <summary>
			/// Initializes the folder using its Desktop.ini settings. If the folder cannot be initialized, the function returns a failure
			/// code and no path is returned. This flag should always be combined with KF_FLAG_CREATE. If the folder is located on a
			/// network, the function might take a longer time to execute.
			/// </summary>
			KF_FLAG_INIT = 0x00000800,

			/// <summary>
			/// Gets the true system path for the folder, free of any aliased placeholders such as %USERPROFILE%, returned by
			/// SHGetKnownFolderIDList and IKnownFolder::GetIDList. This flag has no effect on paths returned by SHGetKnownFolderPath and
			/// IKnownFolder::GetPath. By default, known folder retrieval functions and methods return the aliased path if an alias exists.
			/// </summary>
			KF_FLAG_NO_ALIAS = 0x00001000,

			/// <summary>
			/// Stores the full path in the registry without using environment strings. If this flag is not set, portions of the path may be
			/// represented by environment strings such as %USERPROFILE%. This flag can only be used with SHSetKnownFolderPath and IKnownFolder::SetPath.
			/// </summary>
			KF_FLAG_DONT_UNEXPAND = 0x00002000,

			/// <summary>
			/// Do not verify the folder's existence before attempting to retrieve the path or IDList. If this flag is not set, an attempt
			/// is made to verify that the folder is truly present at the path. If that verification fails due to the folder being absent or
			/// inaccessible, the function returns a failure code and no path is returned. If the folder is located on a network, the
			/// function might take a longer time to execute. Setting this flag can reduce that lag time.
			/// </summary>
			KF_FLAG_DONT_VERIFY = 0x00004000,

			/// <summary>
			/// Forces the creation of the specified folder if that folder does not already exist. The security provisions predefined for
			/// that folder are applied. If the folder does not exist and cannot be created, the function returns a failure code and no path
			/// is returned. This value can be used only with the following functions and methods: SHGetKnownFolderPath,
			/// SHGetKnownFolderIDList, IKnownFolder::GetIDList, IKnownFolder::GetPath, and IKnownFolder::GetShellItem.
			/// </summary>
			KF_FLAG_CREATE = 0x00008000,

			/// <summary>
			/// Introduced in Windows 7: When running inside an app container, or when providing an app container token, this flag prevents
			/// redirection to app container folders. Instead, it retrieves the path that would be returned where it not running inside an
			/// app container.
			/// </summary>
			KF_FLAG_NO_APPCONTAINER_REDIRECTION = 0x00010000,

			/// <summary>Introduced in Windows 7. Return only aliased PIDLs. Do not use the file system path.</summary>
			KF_FLAG_ALIAS_ONLY = 0x80000000
		}

		/// <summary>
		/// The KNOWNFOLDERID constants represent GUIDs that identify standard folders registered with the system as Known Folders. These
		/// folders are installed with Windows Vista and later operating systems, and a computer will have only folders appropriate to it
		/// installed. For descriptions of these folders, see CSIDL.
		/// </summary>
		[PInvokeData("Knownfolders.h", MSDNShortId = "dd378457")]
		public enum KNOWNFOLDERID
		{
			/// <summary>Account Pictures
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\AccountPictures</para>
			/// <para>Localized Name: Account Pictures</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_ROAMABLE, KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("008ca0b1-55b4-4c56-b8a8-4de4b299d3be")]
			FOLDERID_AccountPictures,

			/// <summary>AddNewProgramsFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   shell:::{26EE0668-A00A-44D7-9371-BEB064C98683}\0\::{15eae92e-f17a-4431-9f28-805e482dafd4}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("de61d971-5ebc-4f02-a3a9-6c82895e5c04")]
			FOLDERID_AddNewPrograms,

			/// <summary>Windows Administrative Tools
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Start Menu\Programs\Administrative Tools</para>
			/// <para>Localized Name: Windows Administrative Tools</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("724ef170-a42d-4fef-9f26-b60e846fba4f", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_ADMINTOOLS)]
			FOLDERID_AdminTools,

			/// <summary>Application Shortcuts
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Microsoft\Windows\Application Shortcuts</para>
			/// <para>Localized Name: Application Shortcuts</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("a3918781-e5f2-4890-b3d9-a7e54332328c")]
			FOLDERID_ApplicationShortcuts,

			/// <summary>AppsFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   shell:::{4234d49b-0245-4df3-b780-3893943456e1}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("1e87508d-89c2-42f0-8a7e-645a0f50ca58")]
			FOLDERID_AppsFolder,

			/// <summary>AppUpdatesFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{26EE0668-A00A-44D7-9371-BEB064C98683}\0\::{7b81be6a-ce2b-4676-a29e-eb907a5126c5}\::{d450a8a1-9568-45c7-9c0e-b4f9fb4537bd}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("a305ce99-f527-492b-8b1a-7e76fa98d6e4")]
			FOLDERID_AppUpdates,

			/// <summary>Camera Roll
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Pictures\Camera Roll</para>
			/// <para>Localized Name: Camera Roll</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("ab5fb87b-7ce2-4f83-915d-550846c9537b")]
			FOLDERID_CameraRoll,

			/// <summary>Temporary Burn Folder
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Microsoft\Windows\Burn\Burn</para>
			/// <para>Localized Name: Temporary Burn Folder</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_LOCAL_REDIRECT_ONLY</para>
			/// </summary>
			[KnownFolderDetail("9e52ab10-f80d-49df-acb8-4330f5687855", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_CDBURN_AREA)]
			FOLDERID_CDBurning,

			/// <summary>ChangeRemoveProgramsFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{26EE0668-A00A-44D7-9371-BEB064C98683}\0\::{7b81be6a-ce2b-4676-a29e-eb907a5126c5}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("df7266ac-9274-4867-8d55-3bd661de872d")]
			FOLDERID_ChangeRemovePrograms,

			/// <summary>Windows Administrative Tools
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\Administrative Tools</para>
			/// <para>Localized Name: Windows Administrative Tools</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("d0384e7d-bac3-4797-8f14-cba229b392b5", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_ADMINTOOLS)]
			FOLDERID_CommonAdminTools,

			/// <summary>OEM Links
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %ALLUSERSPROFILE%\OEM Links</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("c1bae2d0-10df-4334-bedd-7aa20b227a9d", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_OEM_LINKS)]
			FOLDERID_CommonOEMLinks,

			/// <summary>Programs
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs</para>
			/// <para>Localized Name: Programs</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("0139d44e-6afe-49f2-8690-3dafcae6ffb8", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_PROGRAMS)]
			FOLDERID_CommonPrograms,

			/// <summary>Start Menu
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu</para>
			/// <para>Localized Name: Start Menu</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("a4115719-d62e-491d-aa7c-e74b8be3b067", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_STARTMENU)]
			FOLDERID_CommonStartMenu,

			/// <summary>Startup
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\Startup</para>
			/// <para>Localized Name: Startup</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("82a5ea35-d9cd-47c5-9629-e15d2f714e6e", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_STARTUP)]
			FOLDERID_CommonStartup,

			/// <summary>Common Templates
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %ALLUSERSPROFILE%\Microsoft\Windows\Templates</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("b94237e7-57ac-4347-9151-b08c6c32d1f7", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_TEMPLATES)]
			FOLDERID_CommonTemplates,

			/// <summary>MyComputerFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{20D04FE0-3AEA-1069-A2D8-08002B30309D}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("0ac0837c-bbf8-452a-850d-79d08e667ca7", Equivalent = Environment.SpecialFolder.MyComputer /* CSIDL.CSIDL_DRIVES */)]
			FOLDERID_ComputerFolder,

			/// <summary>ConflictFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{26EE0668-A00A-44D7-9371-BEB064C98683}\0\::{9C73F5E5-7AE7-4E32-A8E8-8D23B85255BF}\::{E413D040-6788-4C22-957E-175D1C513A34},</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("4bfefb45-347d-4006-a5be-ac0cb0567192")]
			FOLDERID_ConflictFolder,

			/// <summary>ConnectionsFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{26EE0668-A00A-44D7-9371-BEB064C98683}\0\::{7007ACC7-3202-11D1-AAD2-00805FC1270E}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("6f0cd92b-2e97-45d1-88ff-b0d186b8dedd", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_CONNECTIONS)]
			FOLDERID_ConnectionsFolder,

			/// <summary>Contacts
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Contacts</para>
			/// <para>Parsing Name:   ::{59031a47-3f72-44a7-89c5-5595fe6b30ee}\{56784854-C6CB-462B-8169-88E350ACB882}</para>
			/// <para>Tooltip:        Contains Contact files.</para>
			/// <para>Localized Name: Contacts</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_ROAMABLE, KFDF_PRECREATE, KFDF_PUBLISHEXPANDEDPATH</para>
			/// </summary>
			[KnownFolderDetail("56784854-c6cb-462b-8169-88e350acb882")]
			FOLDERID_Contacts,

			/// <summary>ControlPanelFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{26EE0668-A00A-44D7-9371-BEB064C98683}\0</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("82a74aeb-aeb4-465c-a014-d097ee346d63", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_CONTROLS)]
			FOLDERID_ControlPanelFolder,

			/// <summary>Cookies
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Microsoft\Windows\INetCookies</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("2b0f765d-c0e9-4171-908e-08a611b84ff6", Equivalent = Environment.SpecialFolder.Cookies /* CSIDL.CSIDL_COOKIES */)]
			FOLDERID_Cookies,

			/// <summary>Desktop
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Desktop</para>
			/// <para>Localized Name: Desktop</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_ROAMABLE, KFDF_PRECREATE, KFDF_PUBLISHEXPANDEDPATH</para>
			/// </summary>
			[KnownFolderDetail("b4bfcc3a-db2c-424c-b029-7fe99a87c641", Equivalent = Environment.SpecialFolder.Desktop /* CSIDL.CSIDL_DESKTOP */)]
			FOLDERID_Desktop,

			/// <summary>Device Metadata Store
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %ALLUSERSPROFILE%\Microsoft\Windows\DeviceMetadataStore</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("5ce4a5e9-e4eb-479d-b89f-130c02886155")]
			FOLDERID_DeviceMetadataStore,

			/// <summary>Documents
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Documents</para>
			/// <para>Parsing Name:   shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\::{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}</para>
			/// <para>Localized Name: Documents</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_ROAMABLE, KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("fdd39ad0-238f-46af-adb4-6c85480369c7", Equivalent = Environment.SpecialFolder.MyDocuments /* CSIDL.CSIDL_MYDOCUMENTS */)]
			FOLDERID_Documents,

			/// <summary>Documents
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Libraries\Documents.library-ms</para>
			/// <para>Parsing Name:   ::{031E4825-7B94-4dc3-B131-E946B44C8DD5}\{7b0db17d-9cd2-4a93-9733-46cc89022e7c}</para>
			/// <para>Localized Name: Documents</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_PRECREATE, KFDF_STREAM</para>
			/// </summary>
			[KnownFolderDetail("7b0db17d-9cd2-4a93-9733-46cc89022e7c")]
			FOLDERID_DocumentsLibrary,

			/// <summary>Downloads
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Downloads</para>
			/// <para>Parsing Name:   shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\::{374DE290-123F-4565-9164-39C4925E467B}</para>
			/// <para>Localized Name: Downloads</para>
			/// <para>SDDL:           S:AI(RA;IOOICI;;;;WD;("IMAGELOAD",TU,0x0,0x01))</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_ROAMABLE, KFDF_PRECREATE, KFDF_PUBLISHEXPANDEDPATH</para>
			/// </summary>
			[KnownFolderDetail("374de290-123f-4565-9164-39c4925e467b")]
			FOLDERID_Downloads,

			/// <summary>Favorites
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Favorites</para>
			/// <para>Localized Name: Favorites</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_ROAMABLE, KFDF_PRECREATE, KFDF_PUBLISHEXPANDEDPATH</para>
			/// </summary>
			[KnownFolderDetail("1777f761-68ad-4d8a-87bd-30b759fa33dd", Equivalent = Environment.SpecialFolder.Favorites /* CSIDL.CSIDL_FAVORITES */)]
			FOLDERID_Favorites,

			/// <summary>Fonts
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %SystemRoot%\Fonts</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("fd228cb7-ae11-4ae3-864c-16f3910ab8fe", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_FONTS)]
			FOLDERID_Fonts,

			/// <summary>Games</summary>
			[KnownFolderDetail("{CAC52C1A-B53D-4edc-92D7-6B2E8AC19434}")]
			FOLDERID_Games,

			/// <summary>GameTasks
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Microsoft\Windows\GameExplorer</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_LOCAL_REDIRECT_ONLY</para>
			/// </summary>
			[KnownFolderDetail("054fae61-4dd8-4787-80b6-090220c4b700")]
			FOLDERID_GameTasks,

			/// <summary>History
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Microsoft\Windows\History</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_LOCAL_REDIRECT_ONLY</para>
			/// </summary>
			[KnownFolderDetail("d9dc8a3b-b784-432e-a781-5a1130a75963", Equivalent = Environment.SpecialFolder.History /* CSIDL.CSIDL_HISTORY */)]
			FOLDERID_History,

			/// <summary>HomeGroupFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{B4FB3F98-C1EA-428d-A78A-D1F5659CBA93}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("52528a6b-b9e3-4add-b60d-588c2dba842d")]
			FOLDERID_HomeGroup,

			/// <summary>HomeGroupCurrentUserFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{B4FB3F98-C1EA-428d-A78A-D1F5659CBA93}\$CurrentUser$</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("9b74b6a3-0dfd-4f11-9e78-5f7800f2e772")]
			FOLDERID_HomeGroupCurrentUser,

			/// <summary>ImplicitAppShortcuts
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Internet Explorer\Quick Launch\User Pinned\ImplicitAppShortcuts</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("bcb5256f-79f6-4cee-b725-dc34e402fd46")]
			FOLDERID_ImplicitAppShortcuts,

			/// <summary>Cache
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Microsoft\Windows\INetCache</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_LOCAL_REDIRECT_ONLY</para>
			/// </summary>
			[KnownFolderDetail("352481e8-33be-4251-ba85-6007caedcf9d", Equivalent = Environment.SpecialFolder.InternetCache /* CSIDL.CSIDL_INTERNET_CACHE */)]
			FOLDERID_InternetCache,

			/// <summary>InternetFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{871C5380-42A0-1069-A2EA-08002B30309D}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("4d9f7874-4e0c-4904-967b-40b0d20c3e4b", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_INTERNET)]
			FOLDERID_InternetFolder,

			/// <summary>Libraries
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Libraries</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_PRECREATE, KFDF_PUBLISHEXPANDEDPATH</para>
			/// </summary>
			[KnownFolderDetail("1b3ea5dc-b587-4786-b4ef-bd1dc332aeae")]
			FOLDERID_Libraries,

			/// <summary>Links
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Links</para>
			/// <para>Parsing Name:   ::{59031a47-3f72-44a7-89c5-5595fe6b30ee}\{bfb9d5e0-c6a9-404c-b2b2-ae6db6af4968}</para>
			/// <para>Localized Name: Links</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_ROAMABLE, KFDF_PRECREATE, KFDF_PUBLISHEXPANDEDPATH</para>
			/// </summary>
			[KnownFolderDetail("bfb9d5e0-c6a9-404c-b2b2-ae6db6af4968")]
			FOLDERID_Links,

			/// <summary>Local AppData
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_LOCAL_REDIRECT_ONLY, KFDF_PUBLISHEXPANDEDPATH</para>
			/// </summary>
			[KnownFolderDetail("f1b32785-6fba-4fcf-9d55-7b8e7f157091", Equivalent = Environment.SpecialFolder.LocalApplicationData /* CSIDL.CSIDL_LOCAL_APPDATA */)]
			FOLDERID_LocalAppData,

			/// <summary>LocalAppDataLow
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%Low</para>
			/// <para>SDDL:           S:(ML;OICI;NW;;;LW)</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_NOT_CONTENT_INDEXED</para>
			/// <para>Flags:          KFDF_LOCAL_REDIRECT_ONLY, KFDF_PRECREATE, KFDF_PUBLISHEXPANDEDPATH</para>
			/// </summary>
			[KnownFolderDetail("a520a1a4-1780-4ff6-bd18-167343c5af16")]
			FOLDERID_LocalAppDataLow,

			/// <summary>LocalizedResourcesDir
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %SystemRoot%\resources\0409</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("2a00375e-224c-49de-b8d1-440df7ef3ddc", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_RESOURCES_LOCALIZED)]
			FOLDERID_LocalizedResourcesDir,

			/// <summary>Music
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Music</para>
			/// <para>Parsing Name:   shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\::{1CF1260C-4DD0-4EBB-811F-33C572699FDE}</para>
			/// <para>Tooltip:        Contains music and other audio files.</para>
			/// <para>Localized Name: Music</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_ROAMABLE, KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("4bd8d571-6d19-48d3-be97-422220080e43", Equivalent = Environment.SpecialFolder.MyMusic /* CSIDL.CSIDL_MYMUSIC */)]
			FOLDERID_Music,

			/// <summary>Music
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Libraries\Music.library-ms</para>
			/// <para>Parsing Name:   ::{031E4825-7B94-4dc3-B131-E946B44C8DD5}\{2112AB0A-C86A-4ffe-A368-0DE96E47012E}</para>
			/// <para>Tooltip:        Contains music and other audio files.</para>
			/// <para>Localized Name: Music</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_PRECREATE, KFDF_STREAM</para>
			/// </summary>
			[KnownFolderDetail("2112ab0a-c86a-4ffe-a368-0de96e47012e")]
			FOLDERID_MusicLibrary,

			/// <summary>NetHood
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Network Shortcuts</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("c5abbf53-e17f-4121-8900-86626fc2c973", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_NETHOOD)]
			FOLDERID_NetHood,

			/// <summary>NetworkPlacesFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("d20beec4-5ca8-4905-ae3b-bf251ea09b53", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_NETWORK)]
			FOLDERID_NetworkFolder,

			/// <summary>3D Objects
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\3D Objects</para>
			/// <para>Localized Name: 3D Objects</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("31c0dd25-9439-4f12-bf41-7ff4eda38722")]
			FOLDERID_Objects3D,

			/// <summary>Original Images
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Microsoft\Windows Photo Gallery\Original Images</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("2c36c0aa-5812-4b87-bfd0-4cd0dfb19b39")]
			FOLDERID_OriginalImages,

			/// <summary>Slide Shows
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Pictures\Slide Shows</para>
			/// <para>Localized Name: Slide Shows</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// </summary>
			[KnownFolderDetail("69d2cf90-fc33-4fb7-9a0c-ebb0f0fcb43c")]
			FOLDERID_PhotoAlbums,

			/// <summary>Pictures
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Libraries\Pictures.library-ms</para>
			/// <para>Parsing Name:   ::{031E4825-7B94-4dc3-B131-E946B44C8DD5}\{A990AE9F-A03B-4e80-94BC-9912D7504104}</para>
			/// <para>Tooltip:        Contains digital photos, images, and graphic files.</para>
			/// <para>Localized Name: Pictures</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_PRECREATE, KFDF_STREAM</para>
			/// </summary>
			[KnownFolderDetail("a990ae9f-a03b-4e80-94bc-9912d7504104")]
			FOLDERID_PicturesLibrary,

			/// <summary>Pictures
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Pictures</para>
			/// <para>Parsing Name:   shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\::{3ADD1653-EB32-4CB0-BBD7-DFA0ABB5ACCA}</para>
			/// <para>Tooltip:        Contains digital photos, images, and graphic files.</para>
			/// <para>Localized Name: Pictures</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_ROAMABLE, KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("33e28130-4e1e-4676-835a-98395c3bc3bb", Equivalent = Environment.SpecialFolder.MyPictures /* CSIDL.CSIDL_MYPICTURES */)]
			FOLDERID_Pictures,

			/// <summary>Playlists
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Music\Playlists</para>
			/// <para>Localized Name: Playlists</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// </summary>
			[KnownFolderDetail("de92c1c7-837f-4f69-a3bb-86e631204a23")]
			FOLDERID_Playlists,

			/// <summary>PrintersFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{21EC2020-3AEA-1069-A2DD-08002B30309D}\::{2227A280-3AEA-1069-A2DE-08002B30309D}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("76fc4e2d-d6ad-4519-a663-37bd56068185", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_PRINTERS)]
			FOLDERID_PrintersFolder,

			/// <summary>PrintHood
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Printer Shortcuts</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("9274bd8d-cfd1-41c3-b35e-b13f55a758f4", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_PRINTHOOD)]
			FOLDERID_PrintHood,

			/// <summary>Profile
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %USERPROFILE%</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("5e6c858f-0e22-4760-9afe-ea3317b67173", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_PROFILE)]
			FOLDERID_Profile,

			/// <summary>Common AppData
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %ALLUSERSPROFILE%</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("62ab5d82-fdc1-4dc3-a9dd-070d1d495d97", Equivalent = Environment.SpecialFolder.CommonApplicationData /* CSIDL.CSIDL_COMMON_APPDATA */)]
			FOLDERID_ProgramData,

			/// <summary>Program Files
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %ProgramFiles% (x86)</para>
			/// <para>Localized Name: Program Files</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("905e63b6-c1bf-494e-b29c-65b732d3d21a", Equivalent = Environment.SpecialFolder.ProgramFiles /* CSIDL.CSIDL_PROGRAM_FILES */)]
			FOLDERID_ProgramFiles,

			/// <summary>Program Files</summary>
			[KnownFolderDetail("{6D809377-6AF0-444b-8957-A3773F02200E}")]
			FOLDERID_ProgramFilesX64,

			/// <summary>Program Files (x86)
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %ProgramFiles% (x86)</para>
			/// <para>Localized Name: Program Files (x86)</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("7c5a40ef-a0fb-4bfc-874a-c0f2e0b9fa8e", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_PROGRAM_FILESX86)]
			FOLDERID_ProgramFilesX86,

			/// <summary>ProgramFilesCommon
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %ProgramFiles% (x86)\Common Files</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("f7f1ed05-9f6d-47a2-aaae-29d317c6f066", Equivalent = Environment.SpecialFolder.CommonProgramFiles /* CSIDL.CSIDL_PROGRAM_FILES_COMMON */)]
			FOLDERID_ProgramFilesCommon,

			/// <summary>Common Files</summary>
			[KnownFolderDetail("{6365D5A7-0F0D-45E5-87F6-0DA56B6A4F7D}")]
			FOLDERID_ProgramFilesCommonX64,

			/// <summary>ProgramFilesCommonX86
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %ProgramFiles% (x86)\Common Files</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("de974d24-d9c6-4d3e-bf91-f4455120b917", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_PROGRAM_FILES_COMMONX86)]
			FOLDERID_ProgramFilesCommonX86,

			/// <summary>Programs
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Start Menu\Programs</para>
			/// <para>Localized Name: Programs</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("a77f5d77-2e2b-44c3-a6a2-aba601054a51", Equivalent = Environment.SpecialFolder.Programs /* CSIDL.CSIDL_PROGRAMS */)]
			FOLDERID_Programs,

			/// <summary>Public
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %PUBLIC%</para>
			/// <para>Localized Name: Public</para>
			/// <para>SDDL:           D:PAI(A;OICI;FA;;;BA)(A;OICIIO;FA;;;CO)(A;OICI;FA;;;SY)(A;OICIIO;0x1301ff;;;IU)(A;;0x1200af;;;IU)(A;OICIIO;0x1301ff;;;SU)(A;;0x1200af;;;SU)(A;OICIIO;0x1301ff;;;S-1-5-3)(A;;0x1200af;;;S-1-5-3)</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("dfdf76a2-c82a-4d63-906a-5644ac457385")]
			FOLDERID_Public,

			/// <summary>Public Desktop
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %PUBLIC%\Desktop</para>
			/// <para>Localized Name: Public Desktop</para>
			/// <para>SDDL:           D:P(A;OICI;FA;;;BA)(A;OICI;0x1200a9;;;IU)(A;OICI;FA;;;SY)</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY, FILE_ATTRIBUTE_HIDDEN</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("c4aa340d-f20f-4863-afef-f87ef2e6ba25", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_DESKTOPDIRECTORY)]
			FOLDERID_PublicDesktop,

			/// <summary>Public Documents
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %PUBLIC%\Documents</para>
			/// <para>Localized Name: Public Documents</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("ed4824af-dce4-45a8-81e2-fc7965083634", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_DOCUMENTS)]
			FOLDERID_PublicDocuments,

			/// <summary>Public Downloads
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %PUBLIC%\Downloads</para>
			/// <para>Localized Name: Public Downloads</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("3d644c9b-1fb8-4f30-9b45-f670235f79c0")]
			FOLDERID_PublicDownloads,

			/// <summary>PublicGameTasks
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %ALLUSERSPROFILE%\Microsoft\Windows\GameExplorer</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_LOCAL_REDIRECT_ONLY</para>
			/// </summary>
			[KnownFolderDetail("debf2536-e1a8-4c59-b6a2-414586476aea")]
			FOLDERID_PublicGameTasks,

			/// <summary>PublicLibraries
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %PUBLIC%\Libraries</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY, FILE_ATTRIBUTE_HIDDEN</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("48daf80b-e6cf-4f4e-b800-0e69d84ee384")]
			FOLDERID_PublicLibraries,

			/// <summary>Public Music
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %PUBLIC%\Music</para>
			/// <para>Tooltip:        Contains music and other audio files.</para>
			/// <para>Localized Name: Public Music</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("3214fab5-9757-4298-bb61-92a9deaa44ff", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_MUSIC)]
			FOLDERID_PublicMusic,

			/// <summary>Public Pictures
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %PUBLIC%\Pictures</para>
			/// <para>Tooltip:        Contains digital photos, images, and graphic files.</para>
			/// <para>Localized Name: Public Pictures</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("b6ebfb86-6907-413c-9af7-4fc2abf07cc5", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_PICTURES)]
			FOLDERID_PublicPictures,

			/// <summary>CommonRingtones
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %ALLUSERSPROFILE%\Microsoft\Windows\Ringtones</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("e555ab60-153b-4d17-9f04-a5fe99fc15ec")]
			FOLDERID_PublicRingtones,

			/// <summary>Public Account Pictures
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %PUBLIC%\AccountPictures</para>
			/// <para>Localized Name: Public Account Pictures</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY, FILE_ATTRIBUTE_HIDDEN</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("0482af6c-08f1-4c34-8c90-e17ec98b1e17")]
			FOLDERID_PublicUserTiles,

			/// <summary>Public Videos
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %PUBLIC%\Videos</para>
			/// <para>Tooltip:        Contains movies and other video files.</para>
			/// <para>Localized Name: Public Videos</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("2400183a-6185-49fb-a2d8-4a392a602ba3", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_VIDEO)]
			FOLDERID_PublicVideos,

			/// <summary>Quick Launch
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Internet Explorer\Quick Launch</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("52a4f021-7b75-48a9-9f6b-4b87a210bc8f")]
			FOLDERID_QuickLaunch,

			/// <summary>Recent Items
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Recent</para>
			/// <para>Localized Name: Recent Items</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("ae50c081-ebd2-438a-8655-8a092e34987a", Equivalent = Environment.SpecialFolder.Recent /* CSIDL.CSIDL_RECENT */)]
			FOLDERID_Recent,

			/// <summary>Recorded TV
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %PUBLIC%\Libraries\RecordedTV.library-ms</para>
			/// <para>Localized Name: Recorded TV</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_PRECREATE, KFDF_STREAM</para>
			/// </summary>
			[KnownFolderDetail("1a6fdba2-f42d-4358-a798-b74d745926c5")]
			FOLDERID_RecordedTVLibrary,

			/// <summary>RecycleBinFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{645FF040-5081-101B-9F08-00AA002F954E}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("b7534046-3ecb-4c18-be4e-64cd4cb7d6ac", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_BITBUCKET)]
			FOLDERID_RecycleBinFolder,

			/// <summary>ResourceDir
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %SystemRoot%\resources</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("8ad10c31-2adb-4296-a8f7-e4701232c972", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_RESOURCES)]
			FOLDERID_ResourceDir,

			/// <summary>Ringtones
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Microsoft\Windows\Ringtones</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("c870044b-f49e-4126-a9c3-b52a1ff411e8")]
			FOLDERID_Ringtones,

			/// <summary>AppData
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("3eb685db-65f9-4cf6-a03a-e3ef65729f3d", Equivalent = Environment.SpecialFolder.ApplicationData /* CSIDL.CSIDL_APPDATA */)]
			FOLDERID_RoamingAppData,

			/// <summary>Roamed Tile Images
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Microsoft\Windows\RoamedTileImages</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("aaa8d5a5-f1d6-4259-baa8-78e7ef60835e")]
			FOLDERID_RoamedTileImages,

			/// <summary>Roaming Tiles
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Microsoft\Windows\RoamingTiles</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_PRECREATE, KFDF_PUBLISHEXPANDEDPATH</para>
			/// </summary>
			[KnownFolderDetail("00bcfc5a-ed94-4e48-96a1-3f6217f21990")]
			FOLDERID_RoamingTiles,

			/// <summary>SampleMusic
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %PUBLIC%\Music\Sample Music</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("b250c668-f57d-4ee1-a63c-290ee7d1aa1f")]
			FOLDERID_SampleMusic,

			/// <summary>SamplePictures
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %PUBLIC%\Pictures\Sample Pictures</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("c4900540-2379-4c75-844b-64e6faf8716b")]
			FOLDERID_SamplePictures,

			/// <summary>Sample Playlists</summary>
			[KnownFolderDetail("{15CA69B3-30EE-49C1-ACE1-6B5EC372AFB5}")]
			FOLDERID_SamplePlaylists,

			/// <summary>SampleVideos
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %PUBLIC%\Videos\Sample Videos</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("859ead94-2e85-48ad-a71a-0969cb56a6cd")]
			FOLDERID_SampleVideos,

			/// <summary>Saved Games
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Saved Games</para>
			/// <para>Parsing Name:   ::{59031a47-3f72-44a7-89c5-5595fe6b30ee}\{4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4}</para>
			/// <para>Localized Name: Saved Games</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_ROAMABLE, KFDF_PRECREATE, KFDF_PUBLISHEXPANDEDPATH</para>
			/// </summary>
			[KnownFolderDetail("4c5c32ff-bb9d-43b0-b5b4-2d72e54eaaa4")]
			FOLDERID_SavedGames,

			/// <summary>Saved Pictures
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Pictures\Saved Pictures</para>
			/// <para>Localized Name: Saved Pictures</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("3b193882-d3ad-4eab-965a-69829d1fb59f")]
			FOLDERID_SavedPictures,

			/// <summary>Saved Pictures
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Libraries\SavedPictures.library-ms</para>
			/// <para>Parsing Name:   ::{031E4825-7B94-4dc3-B131-E946B44C8DD5}\{E25B5812-BE88-4bd9-94B0-29233477B6C3}</para>
			/// <para>Localized Name: Saved Pictures</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_STREAM</para>
			/// </summary>
			[KnownFolderDetail("e25b5812-be88-4bd9-94b0-29233477b6c3")]
			FOLDERID_SavedPicturesLibrary,

			/// <summary>Searches
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Searches</para>
			/// <para>Parsing Name:   ::{59031a47-3f72-44a7-89c5-5595fe6b30ee}\{7d1d3a04-debb-4115-95cf-2f29da2920da}</para>
			/// <para>Localized Name: Searches</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE, KFDF_PUBLISHEXPANDEDPATH</para>
			/// </summary>
			[KnownFolderDetail("7d1d3a04-debb-4115-95cf-2f29da2920da")]
			FOLDERID_SavedSearches,

			/// <summary>Screenshots
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Pictures\Screenshots</para>
			/// <para>Localized Name: Screenshots</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("b7bede81-df94-4682-a7d8-57a52620b86f")]
			FOLDERID_Screenshots,

			/// <summary>CSCFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   shell:::{BD7A2E7B-21CB-41b2-A086-B309680C6B7E}\*</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("ee32e446-31ca-4aba-814f-a5ebd2fd6d5e")]
			FOLDERID_SEARCH_CSC,

			/// <summary>SearchHistoryFolder
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Microsoft\Windows\ConnectedSearch\History</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("0d4c3db6-03a3-462f-a0e6-08924c41b5d4")]
			FOLDERID_SearchHistory,

			/// <summary>SearchHomeFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{9343812e-1c37-4a49-a12e-4b2d810d956b}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("190337d1-b8ca-4121-a639-6d472d16972a")]
			FOLDERID_SearchHome,

			/// <summary>MAPIFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   shell:::{89D83576-6BD1-4C86-9454-BEB04E94C819}\*</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("98ec0e18-2098-4d44-8644-66979315a281")]
			FOLDERID_SEARCH_MAPI,

			/// <summary>SearchTemplatesFolder
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Microsoft\Windows\ConnectedSearch\Templates</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("7e636bfe-dfa9-4d5e-b456-d7b39851d8a9")]
			FOLDERID_SearchTemplates,

			/// <summary>SendTo
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\SendTo</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("8983036c-27c0-404b-8f08-102d10dcfd74", Equivalent = Environment.SpecialFolder.SendTo /* CSIDL.CSIDL_SENDTO */)]
			FOLDERID_SendTo,

			/// <summary>Gadgets</summary>
			[KnownFolderDetail("{7B396E54-9EC5-4300-BE0A-2482EBAE1A26}")]
			FOLDERID_SidebarDefaultParts,

			/// <summary>Gadgets</summary>
			[KnownFolderDetail("{A75D362E-50FC-4fb7-AC2C-A8BEAA314493}")]
			FOLDERID_SidebarParts,

			/// <summary>OneDrive
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\OneDrive</para>
			/// <para>Parsing Name:   shell:::{018D5C66-4533-4307-9B53-224DE2ED1FE6}</para>
			/// <para>Localized Name: OneDrive</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_LOCAL_REDIRECT_ONLY, KFDF_NO_REDIRECT_UI</para>
			/// </summary>
			[KnownFolderDetail("a52bba46-e9e1-435f-b3d9-28daa648c0f6")]
			FOLDERID_SkyDrive,

			/// <summary>OneDriveCameraRoll
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\OneDrive\Pictures\Camera Roll</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_NO_REDIRECT_UI</para>
			/// </summary>
			[KnownFolderDetail("767e6811-49cb-4273-87c2-20f355e1085b")]
			FOLDERID_SkyDriveCameraRoll,

			/// <summary>OneDriveDocuments
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\OneDrive\Documents</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_NO_REDIRECT_UI</para>
			/// </summary>
			[KnownFolderDetail("24d89e24-2f19-4534-9dde-6a6671fbb8fe")]
			FOLDERID_SkyDriveDocuments,

			/// <summary>OneDrivePictures
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\OneDrive\Pictures</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_NO_REDIRECT_UI</para>
			/// </summary>
			[KnownFolderDetail("339719b5-8c47-4894-94c2-d8f77add44a6")]
			FOLDERID_SkyDrivePictures,

			/// <summary>Start Menu
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Start Menu</para>
			/// <para>Localized Name: Start Menu</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("625b53c3-ab48-4ec1-ba1f-a1ef4146fc19", Equivalent = Environment.SpecialFolder.StartMenu /* CSIDL.CSIDL_STARTMENU */)]
			FOLDERID_StartMenu,

			/// <summary>Startup
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Start Menu\Programs\Startup</para>
			/// <para>Localized Name: Startup</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("b97d20bb-f46a-4c97-ba10-5e3608430854", Equivalent = Environment.SpecialFolder.Startup /* CSIDL.CSIDL_STARTUP */)]
			FOLDERID_Startup,

			/// <summary>SyncCenterFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{26EE0668-A00A-44D7-9371-BEB064C98683}\0\::{9C73F5E5-7AE7-4E32-A8E8-8D23B85255BF}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("43668bf8-c14e-49b2-97c9-747784d784b7")]
			FOLDERID_SyncManagerFolder,

			/// <summary>SyncResultsFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{26EE0668-A00A-44D7-9371-BEB064C98683}\0\::{9C73F5E5-7AE7-4E32-A8E8-8D23B85255BF}\::{BC48B32F-5910-47F5-8570-5074A8A5636A},</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("289a9a43-be44-4057-a41b-587a76d7e7f9")]
			FOLDERID_SyncResultsFolder,

			/// <summary>SyncSetupFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{26EE0668-A00A-44D7-9371-BEB064C98683}\0\::{9C73F5E5-7AE7-4E32-A8E8-8D23B85255BF}\::{F1390A9A-A3F4-4E5D-9C5F-98F3BD8D935C},</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("0f214138-b1d3-4a90-bba9-27cbc0c5389a")]
			FOLDERID_SyncSetupFolder,

			/// <summary>System
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %SystemRoot%\system32</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("1ac14e77-02e7-4e5d-b744-2eb1ae5198b7", Equivalent = Environment.SpecialFolder.System /* CSIDL.CSIDL_SYSTEM */)]
			FOLDERID_System,

			/// <summary>SystemX86
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %SystemRoot%\SysWOW64</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("d65231b0-b2f1-4857-a4ce-a8e7c6ea7d27", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_SYSTEMX86)]
			FOLDERID_SystemX86,

			/// <summary>Templates
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Templates</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("a63293e8-664e-48db-a079-df759e0509f7", Equivalent = Environment.SpecialFolder.Templates /* CSIDL.CSIDL_TEMPLATES */)]
			FOLDERID_Templates,

			/// <summary>User Pinned
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Internet Explorer\Quick Launch\User Pinned</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_HIDDEN</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("9e3995ab-1f9c-4f13-b827-48b24b6c7174")]
			FOLDERID_UserPinned,

			/// <summary>Users
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %HOMEDRIVE%\Users</para>
			/// <para>Localized Name: Users</para>
			/// <para>SDDL:           D:P(A;OICI;FA;;;SY)(A;OICI;FA;;;BA)(A;OICI;GXGR;;;BU)(A;OICI;GXGR;;;WD)</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("0762d272-c50a-4bb0-a382-697dcd729b80")]
			FOLDERID_UserProfiles,

			/// <summary>UserProgramFiles
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Programs</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("5cd7aee2-2219-4a67-b85d-6c9ce15660cb")]
			FOLDERID_UserProgramFiles,

			/// <summary>UserProgramFilesCommon
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Programs\Common</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("bcbd3057-ca5c-4622-b42d-bc56db0ae516")]
			FOLDERID_UserProgramFilesCommon,

			/// <summary>UsersFilesFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{59031a47-3f72-44a7-89c5-5595fe6b30ee}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("f3ce0f7c-4901-4acc-8648-d5d44b04ef8f")]
			FOLDERID_UsersFiles,

			/// <summary>UsersLibrariesFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{031E4825-7B94-4dc3-B131-E946B44C8DD5}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("a302545d-deff-464b-abe8-61c8648d939b")]
			FOLDERID_UsersLibraries,

			/// <summary>Videos
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Videos</para>
			/// <para>Parsing Name:   shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\::{A0953C92-50DC-43BF-BE83-3742FED03C9C}</para>
			/// <para>Tooltip:        Contains movies and other video files.</para>
			/// <para>Localized Name: Videos</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_ROAMABLE, KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("18989b1d-99b5-455b-841c-ab7c74e4ddfc", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_MYVIDEO)]
			FOLDERID_Videos,

			/// <summary>Videos
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Libraries\Videos.library-ms</para>
			/// <para>Parsing Name:   ::{031E4825-7B94-4dc3-B131-E946B44C8DD5}\{491E922F-5643-4af4-A7EB-4E7A138D8174}</para>
			/// <para>Tooltip:        Contains movies and other video files.</para>
			/// <para>Localized Name: Videos</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_PRECREATE, KFDF_STREAM</para>
			/// </summary>
			[KnownFolderDetail("491e922f-5643-4af4-a7eb-4e7a138d8174")]
			FOLDERID_VideosLibrary,

			/// <summary>Windows
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %SystemRoot%</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("f38bf404-1d43-42f2-9305-67de0b28fc23", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_WINDOWS)]
			FOLDERID_Windows,

			/// <summary>Application Mods
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\AppMods</para>
			/// <para>Localized Name: Application Mods</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("7ad67899-66af-43ba-9156-6aad42e6c596")]
			FOLDERID_AllAppMods,

			/// <summary>Captures
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Videos\Captures</para>
			/// <para>Localized Name: Captures</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("edc0fe71-98d8-4f4a-b920-c8dc133cb165")]
			FOLDERID_AppCaptures,

			/// <summary>AppDataDesktop
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Desktop</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("b2c5e279-7add-439f-b28c-c41fe1bbf672")]
			FOLDERID_AppDataDesktop,

			/// <summary>AppDataDocuments
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Documents</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("7be16610-1f7f-44ac-bff0-83e15f2ffca1")]
			FOLDERID_AppDataDocuments,

			/// <summary>AppDataFavorites
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\Favorites</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("7cfbefbc-de1f-45aa-b843-a542ac536cc9")]
			FOLDERID_AppDataFavorites,

			/// <summary>AppDataProgramData
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\ProgramData</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("559d40a3-a036-40fa-af61-84cb430a4d34")]
			FOLDERID_AppDataProgramData,

			/// <summary>Camera Roll
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %APPDATA%\Microsoft\Windows\Libraries\CameraRoll.library-ms</para>
			/// <para>Parsing Name:   ::{031E4825-7B94-4dc3-B131-E946B44C8DD5}\{2B20DF75-1EDA-4039-8097-38798227D5B7}</para>
			/// <para>Localized Name: Camera Roll</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// <para>Flags:          KFDF_STREAM</para>
			/// </summary>
			[KnownFolderDetail("2b20df75-1eda-4039-8097-38798227d5b7")]
			FOLDERID_CameraRollLibrary,

			/// <summary>Start Menu
			/// <para>Category:       KF_CATEGORY_COMMON</para>
			/// <para>Path:           %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu Places</para>
			/// <para>Localized Name: Start Menu</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("a440879f-87a0-4f7d-b700-0207b966194a")]
			FOLDERID_CommonStartMenuPlaces,

			/// <summary>CredentialManager
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %APPDATA%\Microsoft\Credentials</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("915221fb-9efe-4bda-8fd7-f78dca774f87")]
			FOLDERID_CredentialManager,

			/// <summary/>
			[KnownFolderDetail("3db40b20-2a30-4dbe-917e-771dd21dd099")]
			FOLDERID_CurrentAppMods,

			/// <summary>CryptoKeys
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %APPDATA%\Microsoft\Crypto</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("b88f4daa-e7bd-49a9-b74d-02885a5dc765")]
			FOLDERID_CryptoKeys,

			/// <summary>Development Files
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %LOCALAPPDATA%\DevelopmentFiles</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("dbe8e08e-3053-4bbc-b183-2a7b2b191e59")]
			FOLDERID_DevelopmentFiles,

			/// <summary>ThisDeviceFolder
			/// <para>Category:       KF_CATEGORY_VIRTUAL</para>
			/// <para>Parsing Name:   ::{f8278c54-a712-415b-b593-b77a2be0dda9}</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("1c2ac1dc-4358-4b6c-9733-af21156576f0")]
			FOLDERID_Device,

			/// <summary>DpapiKeys
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %APPDATA%\Microsoft\Protect</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("10c07cd0-ef91-4567-b850-448b77cb37f9")]
			FOLDERID_DpapiKeys,

			/// <summary>Documents
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Documents</para>
			/// <para>Parsing Name:   shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\::{d3162b92-9365-467a-956b-92703aca08af}</para>
			/// <para>Localized Name: Documents</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("f42ee2d3-909f-4907-8871-4c22fc0bf756")]
			FOLDERID_LocalDocuments,

			/// <summary>Downloads
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Downloads</para>
			/// <para>Parsing Name:   shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\::{088e3905-0323-4b02-9826-5d99428e115f}</para>
			/// <para>Localized Name: Downloads</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("7d83ee9b-2244-4e70-b1f5-5393042af1e4")]
			FOLDERID_LocalDownloads,

			/// <summary>Music
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Music</para>
			/// <para>Parsing Name:   shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\::{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}</para>
			/// <para>Tooltip:        Contains music and other audio files.</para>
			/// <para>Localized Name: Music</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("a0c69a99-21c8-4671-8703-7934162fcf1d")]
			FOLDERID_LocalMusic,

			/// <summary>Pictures
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Pictures</para>
			/// <para>Parsing Name:   shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\::{24ad3ad4-a569-4530-98e1-ab02f9417aa8}</para>
			/// <para>Tooltip:        Contains digital photos, images, and graphic files.</para>
			/// <para>Localized Name: Pictures</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("0ddd015d-b06c-45d5-8c4c-f59713854639")]
			FOLDERID_LocalPictures,

			/// <summary>Videos
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Videos</para>
			/// <para>Parsing Name:   shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\::{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}</para>
			/// <para>Tooltip:        Contains movies and other video files.</para>
			/// <para>Localized Name: Videos</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_PRECREATE</para>
			/// </summary>
			[KnownFolderDetail("35286a68-3c57-41a1-bbb1-0eae73d76c95")]
			FOLDERID_LocalVideos,

			/// <summary>OneDrive root</summary>
			FOLDERID_OneDrive = FOLDERID_SkyDrive,

			/// <summary>Recorded Calls
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Recorded Calls</para>
			/// <para>Localized Name: Recorded Calls</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("2f8b40c2-83ed-48ee-b383-a1f157ec6f9a")]
			FOLDERID_RecordedCalls,

			/// <summary/>
			[KnownFolderDetail("12D4C69E-24AD-4923-BE19-31321C43A767")]
			FOLDERID_RetailDemo,

			/// <summary>OneDriveMusic
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\OneDrive\Music</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_NO_REDIRECT_UI</para>
			/// </summary>
			[KnownFolderDetail("c3f2459e-80d6-45dc-bfef-1f769f2be730")]
			FOLDERID_SkyDriveMusic,

			/// <summary>Common Start menu item.</summary>
			[KnownFolderDetail("F26305EF-6948-40B9-B255-81453D09C785")]
			FOLDERID_StartMenuAllPrograms,

			/// <summary>SystemCertificates
			/// <para>Category:       KF_CATEGORY_FIXED</para>
			/// <para>Path:           %APPDATA%\Microsoft\SystemCertificates</para>
			/// <para>Attributes:     SECURITY_ANONYMOUS</para>
			/// </summary>
			[KnownFolderDetail("54eed2e0-e7ca-4fdb-9148-0f4247291cfa")]
			FOLDERID_SystemCertificates,

			/// <summary>Desktop
			/// <para>Category:       KF_CATEGORY_PERUSER</para>
			/// <para>Path:           %USERPROFILE%\Desktop</para>
			/// <para>Parsing Name:   shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\::{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}</para>
			/// <para>Localized Name: Desktop</para>
			/// <para>Attributes:     FILE_ATTRIBUTE_READONLY</para>
			/// <para>Flags:          KFDF_ROAMABLE</para>
			/// </summary>
			[KnownFolderDetail("754ac886-df64-4cba-86b5-f7fbf4fbcef5")]
			FOLDERID_ThisPCDesktop,
		}

		/// <summary>
		/// Exposes methods that allow an application to retrieve information about a known folder's category, type, GUID, pointer to an
		/// item identifier list (PIDL) value, redirection capabilities, and definition. It provides a method for the retrieval of a known
		/// folder's IShellItem object. It also provides methods to get or set the path of the known folder.
		/// </summary>
		[ComImport, Guid("3AA7AF7E-9B36-420c-A8E3-F77D4674A488"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762502")]
		public interface IKnownFolder
		{
			/// <summary>Gets the ID of the selected folder.</summary>
			/// <returns>
			/// When this method returns, returns the KNOWNFOLDERID value of the known folder. Note, KNOWNFOLDERID values are GUIDs.
			/// </returns>
			Guid GetId();

			/// <summary>Retrieves the category—virtual, fixed, common, or per-user—of the selected folder.</summary>
			/// <returns>When this method returns, contains a pointer to the KF_CATEGORY of the selected folder.</returns>
			KF_CATEGORY GetCategory();

			/// <summary>
			/// Retrieves the location of a known folder in the Shell namespace in the form of a Shell item (IShellItem or derived interface).
			/// </summary>
			/// <param name="dwFlags">
			/// Flags that specify special retrieval options. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.
			/// </param>
			/// <param name="riid">A reference to the IID of the requested interface.</param>
			/// <returns>
			/// When this method returns, contains the interface pointer requested in <paramref name="riid"/>. This is typically IShellItem
			/// or IShellItem2.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetShellItem([In] KNOWN_FOLDER_FLAG dwFlags, in Guid riid);

			/// <summary>Retrieves the path of a known folder as a string.</summary>
			/// <param name="dwFlags">
			/// Flags that specify special retrieval options. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.
			/// </param>
			/// <returns>
			/// When this method returns, contains the address of a pointer to a null-terminated buffer that contains the path. The calling
			/// application is responsible for calling CoTaskMemFree to free this resource when it is no longer needed.
			/// </returns>
			SafeCoTaskMemString GetPath([In] KNOWN_FOLDER_FLAG dwFlags);

			/// <summary>Assigns a new path to a known folder.</summary>
			/// <param name="dwFlags">Either zero or the following value: KF_FLAG_DONT_UNEXPAND</param>
			/// <param name="pszPath">The PSZ path.</param>
			void SetPath([In] KNOWN_FOLDER_FLAG dwFlags, [In, MarshalAs(UnmanagedType.LPWStr)] string pszPath);

			/// <summary>Gets the location of the Shell namespace folder in the IDList (ITEMIDLIST) form.</summary>
			/// <param name="dwFlags">
			/// Flags that specify special retrieval options. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.
			/// </param>
			/// <returns>
			/// When this method returns, contains the address of an absolute PIDL. This parameter is passed uninitialized. The calling
			/// application is responsible for freeing this resource when it is no longer needed.
			/// </returns>
			[return: ComAliasName("ShellObjects.wirePIDL")]
			PIDL GetIDList([In] KNOWN_FOLDER_FLAG dwFlags);

			/// <summary>Retrieves the folder type.</summary>
			/// <returns>When this returns, contains a pointer to a FOLDERTYPEID (a GUID) that identifies the known folder type.</returns>
			Guid GetFolderType();

			/// <summary>
			/// Gets a value that states whether the known folder can have its path set to a new value or what specific restrictions or
			/// prohibitions are placed on that redirection.
			/// </summary>
			/// <returns>
			/// When this method returns, contains a pointer to a KF_REDIRECTION_CAPABILITIES value that indicates the redirection
			/// capabilities for this folder.
			/// </returns>
			KF_REDIRECTION_CAPABILITIES GetRedirectionCapabilities();

			/// <summary>
			/// Retrieves a structure that contains the defining elements of a known folder, which includes the folder's category, name,
			/// path, description, tooltip, icon, and other properties.
			/// </summary>
			/// <returns>
			/// When this method returns, contains a pointer to the KNOWNFOLDER_DEFINITION structure. When no longer needed, the calling
			/// application is responsible for calling FreeKnownFolderDefinitionFields to free this resource.
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
			CSIDL FolderIdToCsidl(in Guid rfid);

			/// <summary>
			/// <para>Gets an array of all registered known folder IDs. This can be used in enumerating all known folders.</para>
			/// </summary>
			/// <param name="ppKFId">
			/// <para>Type: <c>KNOWNFOLDERID**</c></para>
			/// <para>
			/// When this method returns, contains a pointer to an array of all KNOWNFOLDERID values registered with the system. Use
			/// CoTaskMemFree to free these resources when they are no longer needed.
			/// </para>
			/// </param>
			/// <param name="pCount">
			/// <para>Type: <c>UINT*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to the number of KNOWNFOLDERID values in the array at ppKFId. The [in]
			/// functionality of this parameter is not used.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para>The caller of this method must have User privileges.</para>
			/// <para>You can use StringFromCLSID or StringFromGUID2 to convert the retrieved KNOWNFOLDERID values to strings.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iknownfoldermanager-getfolderids HRESULT
			// GetFolderIds( KNOWNFOLDERID **ppKFId, UINT *pCount );
			[PInvokeData("shobjidl_core.h", MSDNShortId = "3ac09fc4-15c4-4346-94ad-2a4617c463d1")]
			void GetFolderIds(out SafeCoTaskMemHandle ppKFId, out uint pCount);

			/// <summary>
			/// Gets an object that represents a known folder identified by its KNOWNFOLDERID. The object allows you to query certain folder
			/// properties, get the current path of the folder, redirect the folder to another location, and get the path of the folder as
			/// an ITEMIDLIST.
			/// </summary>
			/// <param name="rfid">Reference to the KNOWNFOLDERID.</param>
			/// <returns>When this method returns, contains an interface pointer to the IKnownFolder object that represents the folder.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IKnownFolder GetFolder(in Guid rfid);

			/// <summary>
			/// Gets an object that represents a known folder identified by its canonical name. The object allows you to query certain
			/// folder properties, get the current path of the folder, redirect the folder to another location, and get the path of the
			/// folder as an ITEMIDLIST.
			/// </summary>
			/// <param name="pszCanonicalName">
			/// A pointer to the non-localized, canonical name for the known folder, stored as a null-terminated Unicode string. If this
			/// folder is a common or per-user folder, this value is also used as the value name of the "User Shell Folders" registry
			/// settings. This value is retrieved through the pszName member of the folder's KNOWNFOLDER_DEFINITION structure.
			/// </param>
			/// <returns>
			/// When this method returns, contains the address of a pointer to the IKnownFolder object that represents the known folder.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IKnownFolder GetFolderByName([In, MarshalAs(UnmanagedType.LPWStr)] string pszCanonicalName);

			/// <summary>
			/// Adds a new known folder to the registry. Used particularly by independent software vendors (ISVs) that are adding one of
			/// their own folders to the known folder system.
			/// </summary>
			/// <param name="rfid">A GUID that represents the known folder.</param>
			/// <param name="pKFD">A pointer to a valid KNOWNFOLDER_DEFINITION structure that provides the details of the new folder.</param>
			void RegisterFolder(in Guid rfid, in KNOWNFOLDER_DEFINITION pKFD);

			/// <summary>
			/// Remove a known folder from the registry, which makes it unknown to the known folder system. This method does not remove the
			/// folder itself.
			/// </summary>
			/// <param name="rfid">GUID or KNOWNFOLDERID that represents the known folder.</param>
			void UnregisterFolder(in Guid rfid);

			/// <summary>
			/// Gets an object that represents a known folder based on a file system path. The object allows you to query certain folder
			/// properties, get the current path of the folder, redirect the folder to another location, and get the path of the folder as
			/// an ITEMIDLIST.
			/// </summary>
			/// <param name="pszPath">Pointer to a null-terminated Unicode string of length MAX_PATH that contains a path to a known folder.</param>
			/// <param name="mode">
			/// One of the following values that specify the precision of the match of path and known folder: FFFP_EXACTMATCH = Retrieve
			/// only the specific known folder for the given file path; FFFP_NEARESTPARENTMATCH = If an exact match is not found for the
			/// given file path, retrieve the first known folder that matches one of its parent folders walking up the parent tree.
			/// </param>
			/// <returns>
			/// When this method returns, contains the address of a pointer to the IKnownFolder object that represents the known folder.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IKnownFolder FindFolderFromPath([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath, [In] FFFP_MODE mode);

			/// <summary>
			/// Gets an object that represents a known folder based on an IDList. The object allows you to query certain folder properties,
			/// get the current path of the folder, redirect the folder to another location, and get the path of the folder as an ITEMIDLIST.
			/// </summary>
			/// <param name="pidl">A pointer to the IDList.</param>
			/// <returns>
			/// When this method returns, contains the address of a pointer to the IKnownFolder object that represents the known folder.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IKnownFolder FindFolderFromIDList([In] PIDL pidl);

			/// <summary>Redirects folder requests for common and per-user folders.</summary>
			/// <param name="rfid">A reference to the KNOWNFOLDERID of the folder to be redirected.</param>
			/// <param name="hwnd">
			/// The handle of the parent window used to display copy engine progress UI dialogs when KF_REDIRECT_WITH_UI i passed in the
			/// flags parameter. If no progress dialog is needed, this value can be NULL.
			/// </param>
			/// <param name="flags">The KF_REDIRECT_FLAGS options for redirection.</param>
			/// <param name="pszTargetPath">
			/// A pointer to the new path for the folder. This is a null-terminated Unicode string. This value can be NULL.
			/// </param>
			/// <param name="cFolders">The number of KNOWNFOLDERID values in the array at pExclusion.</param>
			/// <param name="pExclusion">
			/// Pointer to an array of KNOWNFOLDERID values that refer to subfolders of <paramref name="rfid"/> that should be excluded from
			/// the redirection. If no subfolders are excluded, this value can be NULL.
			/// </param>
			/// <returns>
			/// When this method returns, contains the address of a pointer to a null-terminated Unicode string that contains an error
			/// message if one was generated. This value can be NULL.
			/// </returns>
			SafeCoTaskMemString Redirect(in Guid rfid, [In, Optional] HWND hwnd, [In] KF_REDIRECT_FLAGS flags,
				[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pszTargetPath, [In] uint cFolders, [In] Guid[] pExclusion);
		}

		/// <summary>Frees the allocated fields in the result from IKnownFolder::GetFolderDefinition.</summary>
		/// <param name="pKFD">
		/// <para>Type: <c>KNOWNFOLDER_DEFINITION*</c></para>
		/// <para>A pointer to a KNOWNFOLDER_DEFINITION structure that contains information about the given known folder.</para>
		/// </param>
		/// <returns>This function does not return a value.</returns>
		/// <remarks>
		/// This is an inline helper function that calls CoTaskMemFree on the fields in the structure that need to be freed. Its
		/// implementation can be seen in the header file.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-freeknownfolderdefinitionfields void
		// FreeKnownFolderDefinitionFields( KNOWNFOLDER_DEFINITION *pKFD );
		[PInvokeData("shobjidl_core.h", MSDNShortId = "0ad17dd3-e612-403a-b8c3-e93d5f259c1f")]
		public static void FreeKnownFolderDefinitionFields(in KNOWNFOLDER_DEFINITION pKFD)
		{
			foreach (var fi in pKFD.GetType().GetFields().Where(f => f.FieldType == typeof(StrPtrUni)))
				Marshal.FreeCoTaskMem((IntPtr)(StrPtrUni)fi.GetValue(pKFD));
		}

		/// <summary>Gets an array of all registered known folder IDs. This can be used in enumerating all known folders.</summary>
		/// <param name="mgr">The <see cref="IKnownFolderManager"/> instance.</param>
		/// <returns>An enumeration of all known folder Guid values registered with the system.</returns>
		/// <remarks>
		/// <para>The caller of this method must have User privileges.</para>
		/// <para>You can use StringFromCLSID or StringFromGUID2 to convert the retrieved KNOWNFOLDERID values to strings.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iknownfoldermanager-getfolderids HRESULT
		// GetFolderIds( KNOWNFOLDERID **ppKFId, UINT *pCount );
		[PInvokeData("shobjidl_core.h", MSDNShortId = "3ac09fc4-15c4-4346-94ad-2a4617c463d1")]
		public static IEnumerable<Guid> GetFolderIds(this IKnownFolderManager mgr) { mgr.GetFolderIds(out var mem, out var c); using (mem) return mem.ToArray<Guid>((int)c); }

		/// <summary>Gets an array of all registered known folder IDs. This can be used in enumerating all known folders.</summary>
		/// <param name="mgr">The <see cref="IKnownFolderManager"/> instance.</param>
		/// <returns>An enumeration of all KNOWNFOLDERID values registered with the system.</returns>
		/// <remarks>The caller of this method must have User privileges.</remarks>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "3ac09fc4-15c4-4346-94ad-2a4617c463d1")]
		public static IEnumerable<KNOWNFOLDERID> GetKnownFolderIds(this IKnownFolderManager mgr)
		{
			foreach (var id in mgr.GetFolderIds())
				if (AssociateAttribute.TryEnumLookup<KNOWNFOLDERID>(id, out var kf))
					yield return kf;
		}

		/// <summary>Extension method to simplify using the <see cref="IKnownFolder.GetShellItem"/> method.</summary>
		/// <typeparam name="T">Type of the interface to get.</typeparam>
		/// <param name="fv">An <see cref="IKnownFolder"/> instance.</param>
		/// <param name="dwFlags">
		/// Flags that specify special retrieval options. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.
		/// </param>
		/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
		public static T GetShellItem<T>(this IKnownFolder fv, [In] KNOWN_FOLDER_FLAG dwFlags = KNOWN_FOLDER_FLAG.KF_FLAG_DEFAULT) where T : class => (T)fv.GetShellItem(dwFlags, typeof(T).GUID);

		/// <summary>Defines the specifics of a known folder.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb773325")]
		public struct KNOWNFOLDER_DEFINITION
		{
			/// <summary>A single value from the KF_CATEGORY constants that classifies the folder as virtual, fixed, common, or per-user.</summary>
			public KF_CATEGORY category;

			/// <summary>
			/// A pointer to the non-localized, canonical name for the known folder, stored as a null-terminated Unicode string. If this
			/// folder is a common or per-user folder, this value is also used as the value name of the "User Shell Folders" registry
			/// settings. This name is meant to be a unique, human-readable name. Third parties are recommended to follow the format
			/// Company.Application.Name. The name given here should not be confused with the display name.
			/// </summary>
			public StrPtrUni pszName;

			/// <summary>
			/// A pointer to a short description of the known folder, stored as a null-terminated Unicode string. This description should
			/// include the folder's purpose and usage.
			/// </summary>
			public StrPtrUni pszDescription;

			/// <summary>
			/// A KNOWNFOLDERID value that names another known folder to serve as the parent folder. Applies to common and per-user folders
			/// only. This value is used in conjunction with pszRelativePath. See Remarks for more details. This value is optional if no
			/// value is provided for pszRelativePath.
			/// </summary>
			public Guid fidParent;

			/// <summary>
			/// Optional. A pointer to a path relative to the parent folder specified in fidParent. This is a null-terminated Unicode
			/// string, refers to the physical file system path, and is not localized. Applies to common and per-user folders only. See
			/// Remarks for more details.
			/// </summary>
			public StrPtrUni pszRelativePath;

			/// <summary>
			/// A pointer to the Shell namespace folder path of the folder, stored as a null-terminated Unicode string. Applies to virtual
			/// folders only. For example, Control Panel has a parsing name of ::%CLSID_MyComputer%\::%CLSID_ControlPanel%.
			/// </summary>
			public StrPtrUni pszParsingName;

			/// <summary>
			/// Optional. A pointer to the default tooltip resource used for this known folder when it is created. This is a null-terminated
			/// Unicode string in this form:
			/// <para><c>Module name, Resource ID</c></para>
			/// <para>
			/// For example, @%_SYS_MOD_PATH%,-12688 is the tooltip for Common Pictures.When the folder is created, this string is stored in
			/// that folder's copy of Desktop.ini. It can be changed later by other Shell APIs. This resource might be localized.
			/// </para>
			/// <para>This information is not required for virtual folders.</para>
			/// </summary>
			public StrPtrUni pszTooltip;

			/// <summary>
			/// Optional. A pointer to the default localized name resource used when the folder is created. This is a null-terminated
			/// Unicode string in this form:
			/// <para><c>Module name, Resource ID</c></para>
			/// <para>
			/// When the folder is created, this string is stored in that folder's copy of Desktop.ini. It can be changed later by other
			/// Shell APIs.
			/// </para>
			/// <para>This information is not required for virtual folders.</para>
			/// </summary>
			public StrPtrUni pszLocalizedName;

			/// <summary>
			/// Optional. A pointer to the default icon resource used when the folder is created. This is a null-terminated Unicode string
			/// in this form:
			/// <para><c>Module name, Resource ID</c></para>
			/// <para>
			/// When the folder is created, this string is stored in that folder's copy of Desktop.ini. It can be changed later by other
			/// Shell APIs.
			/// </para>
			/// <para>This information is not required for virtual folders.</para>
			/// </summary>
			public StrPtrUni pszIcon;

			/// <summary>
			/// Optional. A pointer to a Security Descriptor Definition Language format string. This is a null-terminated Unicode string
			/// that describes the default security descriptor that the folder receives when it is created. If this parameter is NULL, the
			/// new folder inherits the security descriptor of its parent. This is particularly useful for common folders that are accessed
			/// by all users.
			/// </summary>
			public StrPtrUni pszSecurity;

			/// <summary>
			/// Optional. Default file system attributes given to the folder when it is created. For example, the file could be hidden and
			/// read-only (FILE_ATTRIBUTE_HIDDEN and FILE_ATTRIBUTE_READONLY). For a complete list of possible values, see the
			/// dwFlagsAndAttributes parameter of the CreateFile function. Set to -1 if not needed.
			/// </summary>
			public FileFlagsAndAttributes dwAttributes;

			/// <summary>
			/// Optional. One of more values from the KF_DEFINITION_FLAGS enumeration that allow you to restrict redirection, allow PC-to-PC
			/// roaming, and control the time at which the known folder is created. Set to 0 if not needed.
			/// </summary>
			public KF_DEFINITION_FLAGS kfdFlags;

			/// <summary>
			/// One of the FOLDERTYPEID values that identifies the known folder type based on its contents (such as documents, music, or
			/// photographs). This value is a GUID.
			/// </summary>
			public Guid ftidType;

			/// <summary>Frees the allocated fields in the result from IKnownFolder::GetFolderDefinition.</summary>
			/// <remarks>
			/// This is an inline helper function that calls CoTaskMemFree on the fields in the structure that need to be freed. Its
			/// implementation can be seen in the header file.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-freeknownfolderdefinitionfields void
			// FreeKnownFolderDefinitionFields( KNOWNFOLDER_DEFINITION *pKFD );
			[PInvokeData("shobjidl_core.h", MSDNShortId = "NF:shobjidl_core.FreeKnownFolderDefinitionFields")]
			public void FreeKnownFolderDefinitionFields()
			{
				Marshal.FreeCoTaskMem((IntPtr)pszName);
				Marshal.FreeCoTaskMem((IntPtr)pszDescription);
				Marshal.FreeCoTaskMem((IntPtr)pszRelativePath);
				Marshal.FreeCoTaskMem((IntPtr)pszParsingName);
				Marshal.FreeCoTaskMem((IntPtr)pszTooltip);
				Marshal.FreeCoTaskMem((IntPtr)pszLocalizedName);
				Marshal.FreeCoTaskMem((IntPtr)pszIcon);
				Marshal.FreeCoTaskMem((IntPtr)pszSecurity);
			}
		}

		/// <summary>Class interface for IKnownFolderManager.</summary>
		[ComImport, Guid("4df0c730-df9d-4ae3-9153-aa6b82e9795a"), ClassInterface(ClassInterfaceType.None)]
		public class CKnownFolderManager { }

		/// <summary>Provides information about a <see cref="KNOWNFOLDERID"/>.</summary>
		[AttributeUsage(AttributeTargets.Field)]
		internal class KnownFolderDetailAttribute : AssociateAttribute
		{
			/// <summary>The equivalent SpecialFolder.</summary>
			public Environment.SpecialFolder Equivalent = (Environment.SpecialFolder)0XFFFF;

			/// <summary>Initializes a new instance of the <see cref="KnownFolderDetailAttribute"/> class with a GUID for the <see cref="KNOWNFOLDERID"/>.</summary>
			/// <param name="knownFolderGuid">The GUID for the <see cref="KNOWNFOLDERID"/>.</param>
			public KnownFolderDetailAttribute(string knownFolderGuid) : base(knownFolderGuid) { }
		}
	}
}