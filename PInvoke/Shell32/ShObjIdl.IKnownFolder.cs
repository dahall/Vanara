using System;
using System.Collections.Generic;
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
			/// Create the folder when the user first logs on. Normally a known folder is not created until it is first called. At that time,
			/// an API such as SHCreateItemInKnownFolder or IKnownFolder::GetShellItem is called with the KF_FLAG_CREATE flag. However, some
			/// known folders need to exist immediately. An example is those known folders under %USERPROFILE%, which must exist to provide a
			/// proper view. In those cases, KFDF_PRECREATE is set and Windows Explorer calls the creation API during its user initialization.
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
			/// code and no path is returned. This flag should always be combined with KF_FLAG_CREATE. If the folder is located on a network,
			/// the function might take a longer time to execute.
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
			/// Do not verify the folder's existence before attempting to retrieve the path or IDList. If this flag is not set, an attempt is
			/// made to verify that the folder is truly present at the path. If that verification fails due to the folder being absent or
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
			/// <summary>Account Pictures</summary>
			[KnownFolderDetail("{008ca0b1-55b4-4c56-b8a8-4de4b299d3be}")]
			FOLDERID_AccountPictures,

			/// <summary>Get Programs</summary>
			[KnownFolderDetail("{de61d971-5ebc-4f02-a3a9-6c82895e5c04}")]
			FOLDERID_AddNewPrograms,

			/// <summary>Admin tools</summary>
			[KnownFolderDetail("{724EF170-A42D-4FEF-9F26-B60E846FBA4F}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_ADMINTOOLS)]
			FOLDERID_AdminTools,

			/// <summary>Application shortcuts</summary>
			[KnownFolderDetail("{A3918781-E5F2-4890-B3D9-A7E54332328C}")]
			FOLDERID_ApplicationShortcuts,

			/// <summary>Applications</summary>
			[KnownFolderDetail("{1e87508d-89c2-42f0-8a7e-645a0f50ca58}")]
			FOLDERID_AppsFolder,

			/// <summary>Installed Updates</summary>
			[KnownFolderDetail("{a305ce99-f527-492b-8b1a-7e76fa98d6e4}")]
			FOLDERID_AppUpdates,

			/// <summary>Camera Roll</summary>
			[KnownFolderDetail("{AB5FB87B-7CE2-4F83-915D-550846C9537B}")]
			FOLDERID_CameraRoll,

			/// <summary>Temporary Burn Folder</summary>
			[KnownFolderDetail("{9E52AB10-F80D-49DF-ACB8-4330F5687855}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_CDBURN_AREA)]
			FOLDERID_CDBurning,

			/// <summary>Programs and Features</summary>
			[KnownFolderDetail("{df7266ac-9274-4867-8d55-3bd661de872d}")]
			FOLDERID_ChangeRemovePrograms,

			/// <summary>Administrative Tools</summary>
			[KnownFolderDetail("{D0384E7D-BAC3-4797-8F14-CBA229B392B5}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_ADMINTOOLS)]
			FOLDERID_CommonAdminTools,

			/// <summary>OEM Links</summary>
			[KnownFolderDetail("{C1BAE2D0-10DF-4334-BEDD-7AA20B227A9D}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_OEM_LINKS)]
			FOLDERID_CommonOEMLinks,

			/// <summary>Programs</summary>
			[KnownFolderDetail("{0139D44E-6AFE-49F2-8690-3DAFCAE6FFB8}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_PROGRAMS)]
			FOLDERID_CommonPrograms,

			/// <summary>Start Menu</summary>
			[KnownFolderDetail("{A4115719-D62E-491D-AA7C-E74B8BE3B067}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_STARTMENU)]
			FOLDERID_CommonStartMenu,

			/// <summary>Startup</summary>
			[KnownFolderDetail("{82A5EA35-D9CD-47C5-9629-E15D2F714E6E}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_STARTUP)]
			FOLDERID_CommonStartup,

			/// <summary>Templates</summary>
			[KnownFolderDetail("{B94237E7-57AC-4347-9151-B08C6C32D1F7}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_TEMPLATES)]
			FOLDERID_CommonTemplates,

			/// <summary>Computer</summary>
			[KnownFolderDetail("{0AC0837C-BBF8-452A-850D-79D08E667CA7}", Equivalent = Environment.SpecialFolder.MyComputer)]
			FOLDERID_ComputerFolder,

			/// <summary>Conflicts</summary>
			[KnownFolderDetail("{4bfefb45-347d-4006-a5be-ac0cb0567192}")]
			FOLDERID_ConflictFolder,

			/// <summary>Network Connections</summary>
			[KnownFolderDetail("{6F0CD92B-2E97-45D1-88FF-B0D186B8DEDD}")]
			FOLDERID_ConnectionsFolder,

			/// <summary>Contacts</summary>
			[KnownFolderDetail("{56784854-C6CB-462b-8169-88E350ACB882}")]
			FOLDERID_Contacts,

			/// <summary>Control Panel</summary>
			[KnownFolderDetail("{82A74AEB-AEB4-465C-A014-D097EE346D63}")]
			FOLDERID_ControlPanelFolder,

			/// <summary>Cookies</summary>
			[KnownFolderDetail("{2B0F765D-C0E9-4171-908E-08A611B84FF6}", Equivalent = Environment.SpecialFolder.Cookies)]
			FOLDERID_Cookies,

			/// <summary>Desktop</summary>
			[KnownFolderDetail("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", Equivalent = Environment.SpecialFolder.Desktop)]
			FOLDERID_Desktop,

			/// <summary>DeviceMetadataStore</summary>
			[KnownFolderDetail("{5CE4A5E9-E4EB-479D-B89F-130C02886155}")]
			FOLDERID_DeviceMetadataStore,

			/// <summary>Documents</summary>
			[KnownFolderDetail("{FDD39AD0-238F-46AF-ADB4-6C85480369C7}", Equivalent = Environment.SpecialFolder.MyDocuments)]
			FOLDERID_Documents,

			/// <summary>Documents</summary>
			[KnownFolderDetail("{7B0DB17D-9CD2-4A93-9733-46CC89022E7C}")]
			FOLDERID_DocumentsLibrary,

			/// <summary>Downloads</summary>
			[KnownFolderDetail("{374DE290-123F-4565-9164-39C4925E467B}")]
			FOLDERID_Downloads,

			/// <summary>Favorites</summary>
			[KnownFolderDetail("{1777F761-68AD-4D8A-87BD-30B759FA33DD}", Equivalent = Environment.SpecialFolder.Favorites)]
			FOLDERID_Favorites,

			/// <summary>Fonts</summary>
			[KnownFolderDetail("{FD228CB7-AE11-4AE3-864C-16F3910AB8FE}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_FONTS)]
			FOLDERID_Fonts,

			/// <summary>Games</summary>
			[KnownFolderDetail("{CAC52C1A-B53D-4edc-92D7-6B2E8AC19434}")]
			FOLDERID_Games,

			/// <summary>GameExplorer</summary>
			[KnownFolderDetail("{054FAE61-4DD8-4787-80B6-090220C4B700}")]
			FOLDERID_GameTasks,

			/// <summary>History</summary>
			[KnownFolderDetail("{D9DC8A3B-B784-432E-A781-5A1130A75963}", Equivalent = Environment.SpecialFolder.History)]
			FOLDERID_History,

			/// <summary>HomeGroup</summary>
			[KnownFolderDetail("{52528A6B-B9E3-4ADD-B60D-588C2DBA842D}")]
			FOLDERID_HomeGroup,

			/// <summary>The user's username (%USERNAME%)</summary>
			[KnownFolderDetail("{9B74B6A3-0DFD-4f11-9E78-5F7800F2E772}")]
			FOLDERID_HomeGroupCurrentUser,

			/// <summary>ImplicitAppShortcuts</summary>
			[KnownFolderDetail("{BCB5256F-79F6-4CEE-B725-DC34E402FD46}")]
			FOLDERID_ImplicitAppShortcuts,

			/// <summary>Temporary Internet Files</summary>
			[KnownFolderDetail("{352481E8-33BE-4251-BA85-6007CAEDCF9D}", Equivalent = Environment.SpecialFolder.InternetCache)]
			FOLDERID_InternetCache,

			/// <summary>The Internet</summary>
			[KnownFolderDetail("{4D9F7874-4E0C-4904-967B-40B0D20C3E4B}")]
			FOLDERID_InternetFolder,

			/// <summary>Libraries</summary>
			[KnownFolderDetail("{1B3EA5DC-B587-4786-B4EF-BD1DC332AEAE}")]
			FOLDERID_Libraries,

			/// <summary>Links</summary>
			[KnownFolderDetail("{bfb9d5e0-c6a9-404c-b2b2-ae6db6af4968}")]
			FOLDERID_Links,

			/// <summary>Local</summary>
			[KnownFolderDetail("{F1B32785-6FBA-4FCF-9D55-7B8E7F157091}", Equivalent = Environment.SpecialFolder.LocalApplicationData)]
			FOLDERID_LocalAppData,

			/// <summary>LocalLow</summary>
			[KnownFolderDetail("{A520A1A4-1780-4FF6-BD18-167343C5AF16}")]
			FOLDERID_LocalAppDataLow,

			/// <summary>None</summary>
			[KnownFolderDetail("{2A00375E-224C-49DE-B8D1-440DF7EF3DDC}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_RESOURCES_LOCALIZED)]
			FOLDERID_LocalizedResourcesDir,

			/// <summary>Music</summary>
			[KnownFolderDetail("{4BD8D571-6D19-48D3-BE97-422220080E43}", Equivalent = Environment.SpecialFolder.MyMusic)]
			FOLDERID_Music,

			/// <summary>Music</summary>
			[KnownFolderDetail("{2112AB0A-C86A-4FFE-A368-0DE96E47012E}")]
			FOLDERID_MusicLibrary,

			/// <summary>Network Shortcuts</summary>
			[KnownFolderDetail("{C5ABBF53-E17F-4121-8900-86626FC2C973}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_NETHOOD)]
			FOLDERID_NetHood,

			/// <summary>Network</summary>
			[KnownFolderDetail("{D20BEEC4-5CA8-4905-AE3B-BF251EA09B53}")]
			FOLDERID_NetworkFolder,

			/// <summary>Original Images</summary>
			[KnownFolderDetail("{2C36C0AA-5812-4b87-BFD0-4CD0DFB19B39}")]
			FOLDERID_OriginalImages,

			/// <summary>Slide Shows</summary>
			[KnownFolderDetail("{69D2CF90-FC33-4FB7-9A0C-EBB0F0FCB43C}")]
			FOLDERID_PhotoAlbums,

			/// <summary>Pictures</summary>
			[KnownFolderDetail("{A990AE9F-A03B-4E80-94BC-9912D7504104}")]
			FOLDERID_PicturesLibrary,

			/// <summary>Pictures</summary>
			[KnownFolderDetail("{33E28130-4E1E-4676-835A-98395C3BC3BB}", Equivalent = Environment.SpecialFolder.MyPictures)]
			FOLDERID_Pictures,

			/// <summary>Playlists</summary>
			[KnownFolderDetail("{DE92C1C7-837F-4F69-A3BB-86E631204A23}")]
			FOLDERID_Playlists,

			/// <summary>Printers</summary>
			[KnownFolderDetail("{76FC4E2D-D6AD-4519-A663-37BD56068185}")]
			FOLDERID_PrintersFolder,

			/// <summary>Printer Shortcuts</summary>
			[KnownFolderDetail("{9274BD8D-CFD1-41C3-B35E-B13F55A758F4}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_PRINTHOOD)]
			FOLDERID_PrintHood,

			/// <summary>The user's username (%USERNAME%)</summary>
			[KnownFolderDetail("{5E6C858F-0E22-4760-9AFE-EA3317B67173}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_PROFILE)]
			FOLDERID_Profile,

			/// <summary>ProgramData</summary>
			[KnownFolderDetail("{62AB5D82-FDC1-4DC3-A9DD-070D1D495D97}", Equivalent = Environment.SpecialFolder.CommonApplicationData)]
			FOLDERID_ProgramData,

			/// <summary>Program Files</summary>
			[KnownFolderDetail("{905e63b6-c1bf-494e-b29c-65b732d3d21a}", Equivalent = Environment.SpecialFolder.ProgramFiles)]
			FOLDERID_ProgramFiles,

			/// <summary>Program Files</summary>
			[KnownFolderDetail("{6D809377-6AF0-444b-8957-A3773F02200E}")]
			FOLDERID_ProgramFilesX64,

			/// <summary>Program Files</summary>
			[KnownFolderDetail("{7C5A40EF-A0FB-4BFC-874A-C0F2E0B9FA8E}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_PROGRAM_FILESX86)]
			FOLDERID_ProgramFilesX86,

			/// <summary>Common Files</summary>
			[KnownFolderDetail("{F7F1ED05-9F6D-47A2-AAAE-29D317C6F066}", Equivalent = Environment.SpecialFolder.CommonProgramFiles)]
			FOLDERID_ProgramFilesCommon,

			/// <summary>Common Files</summary>
			[KnownFolderDetail("{6365D5A7-0F0D-45E5-87F6-0DA56B6A4F7D}")]
			FOLDERID_ProgramFilesCommonX64,

			/// <summary>Common Files</summary>
			[KnownFolderDetail("{DE974D24-D9C6-4D3E-BF91-F4455120B917}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_PROGRAM_FILES_COMMONX86)]
			FOLDERID_ProgramFilesCommonX86,

			/// <summary>Programs</summary>
			[KnownFolderDetail("{A77F5D77-2E2B-44C3-A6A2-ABA601054A51}", Equivalent = Environment.SpecialFolder.Programs)]
			FOLDERID_Programs,

			/// <summary>Public</summary>
			[KnownFolderDetail("{DFDF76A2-C82A-4D63-906A-5644AC457385}")]
			FOLDERID_Public,

			/// <summary>Public Desktop</summary>
			[KnownFolderDetail("{C4AA340D-F20F-4863-AFEF-F87EF2E6BA25}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_DESKTOPDIRECTORY)]
			FOLDERID_PublicDesktop,

			/// <summary>Public Documents</summary>
			[KnownFolderDetail("{ED4824AF-DCE4-45A8-81E2-FC7965083634}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_DOCUMENTS)]
			FOLDERID_PublicDocuments,

			/// <summary>Public Downloads</summary>
			[KnownFolderDetail("{3D644C9B-1FB8-4f30-9B45-F670235F79C0}")]
			FOLDERID_PublicDownloads,

			/// <summary>GameExplorer</summary>
			[KnownFolderDetail("{DEBF2536-E1A8-4c59-B6A2-414586476AEA}")]
			FOLDERID_PublicGameTasks,

			/// <summary>Libraries</summary>
			[KnownFolderDetail("{48DAF80B-E6CF-4F4E-B800-0E69D84EE384}")]
			FOLDERID_PublicLibraries,

			/// <summary>Public Music</summary>
			[KnownFolderDetail("{3214FAB5-9757-4298-BB61-92A9DEAA44FF}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_MUSIC)]
			FOLDERID_PublicMusic,

			/// <summary>Public Pictures</summary>
			[KnownFolderDetail("{B6EBFB86-6907-413C-9AF7-4FC2ABF07CC5}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_PICTURES)]
			FOLDERID_PublicPictures,

			/// <summary>Ringtones</summary>
			[KnownFolderDetail("{E555AB60-153B-4D17-9F04-A5FE99FC15EC}")]
			FOLDERID_PublicRingtones,

			/// <summary>Public Account Pictures</summary>
			[KnownFolderDetail("{0482af6c-08f1-4c34-8c90-e17ec98b1e17}")]
			FOLDERID_PublicUserTiles,

			/// <summary>Public Videos</summary>
			[KnownFolderDetail("{2400183A-6185-49FB-A2D8-4A392A602BA3}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_COMMON_VIDEO)]
			FOLDERID_PublicVideos,

			/// <summary>Quick Launch</summary>
			[KnownFolderDetail("{52a4f021-7b75-48a9-9f6b-4b87a210bc8f}")]
			FOLDERID_QuickLaunch,

			/// <summary>Recent Items</summary>
			[KnownFolderDetail("{AE50C081-EBD2-438A-8655-8A092E34987A}", Equivalent = Environment.SpecialFolder.Recent)]
			FOLDERID_Recent,

			/// <summary>Recorded TV</summary>
			[KnownFolderDetail("{1A6FDBA2-F42D-4358-A798-B74D745926C5}")]
			FOLDERID_RecordedTVLibrary,

			/// <summary>Recycle Bin</summary>
			[KnownFolderDetail("{B7534046-3ECB-4C18-BE4E-64CD4CB7D6AC}")]
			FOLDERID_RecycleBinFolder,

			/// <summary>Resources</summary>
			[KnownFolderDetail("{8AD10C31-2ADB-4296-A8F7-E4701232C972}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_RESOURCES)]
			FOLDERID_ResourceDir,

			/// <summary>Ringtones</summary>
			[KnownFolderDetail("{C870044B-F49E-4126-A9C3-B52A1FF411E8}")]
			FOLDERID_Ringtones,

			/// <summary>Roaming</summary>
			[KnownFolderDetail("{3EB685DB-65F9-4CF6-A03A-E3EF65729F3D}", Equivalent = Environment.SpecialFolder.ApplicationData)]
			FOLDERID_RoamingAppData,

			/// <summary>RoamedTileImages</summary>
			[KnownFolderDetail("{AAA8D5A5-F1D6-4259-BAA8-78E7EF60835E}")]
			FOLDERID_RoamedTileImages,

			/// <summary>RoamingTiles</summary>
			[KnownFolderDetail("{00BCFC5A-ED94-4e48-96A1-3F6217F21990}")]
			FOLDERID_RoamingTiles,

			/// <summary>Sample Music</summary>
			[KnownFolderDetail("{B250C668-F57D-4EE1-A63C-290EE7D1AA1F}")]
			FOLDERID_SampleMusic,

			/// <summary>Sample Pictures</summary>
			[KnownFolderDetail("{C4900540-2379-4C75-844B-64E6FAF8716B}")]
			FOLDERID_SamplePictures,

			/// <summary>Sample Playlists</summary>
			[KnownFolderDetail("{15CA69B3-30EE-49C1-ACE1-6B5EC372AFB5}")]
			FOLDERID_SamplePlaylists,

			/// <summary>Sample Videos</summary>
			[KnownFolderDetail("{859EAD94-2E85-48AD-A71A-0969CB56A6CD}")]
			FOLDERID_SampleVideos,

			/// <summary>Saved Games</summary>
			[KnownFolderDetail("{4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4}")]
			FOLDERID_SavedGames,

			/// <summary>Saved Pictures</summary>
			[KnownFolderDetail("{3B193882-D3AD-4eab-965A-69829D1FB59F}")]
			FOLDERID_SavedPictures,

			/// <summary>Saved Pictures Library</summary>
			[KnownFolderDetail("{E25B5812-BE88-4bd9-94B0-29233477B6C3}")]
			FOLDERID_SavedPicturesLibrary,

			/// <summary>Searches</summary>
			[KnownFolderDetail("{7D1D3A04-DEBB-4115-95CF-2F29DA2920DA}")]
			FOLDERID_SavedSearches,

			/// <summary>Screenshots</summary>
			[KnownFolderDetail("{b7bede81-df94-4682-a7d8-57a52620b86f}")]
			FOLDERID_Screenshots,

			/// <summary>Offline Files</summary>
			[KnownFolderDetail("{ee32e446-31ca-4aba-814f-a5ebd2fd6d5e}")]
			FOLDERID_SEARCH_CSC,

			/// <summary>History</summary>
			[KnownFolderDetail("{0D4C3DB6-03A3-462F-A0E6-08924C41B5D4}")]
			FOLDERID_SearchHistory,

			/// <summary>Search Results</summary>
			[KnownFolderDetail("{190337d1-b8ca-4121-a639-6d472d16972a}")]
			FOLDERID_SearchHome,

			/// <summary>Microsoft Office Outlook</summary>
			[KnownFolderDetail("{98ec0e18-2098-4d44-8644-66979315a281}")]
			FOLDERID_SEARCH_MAPI,

			/// <summary>Templates</summary>
			[KnownFolderDetail("{7E636BFE-DFA9-4D5E-B456-D7B39851D8A9}")]
			FOLDERID_SearchTemplates,

			/// <summary>SendTo</summary>
			[KnownFolderDetail("{8983036C-27C0-404B-8F08-102D10DCFD74}", Equivalent = Environment.SpecialFolder.SendTo)]
			FOLDERID_SendTo,

			/// <summary>Gadgets</summary>
			[KnownFolderDetail("{7B396E54-9EC5-4300-BE0A-2482EBAE1A26}")]
			FOLDERID_SidebarDefaultParts,

			/// <summary>Gadgets</summary>
			[KnownFolderDetail("{A75D362E-50FC-4fb7-AC2C-A8BEAA314493}")]
			FOLDERID_SidebarParts,

			/// <summary>OneDrive</summary>
			[KnownFolderDetail("{A52BBA46-E9E1-435f-B3D9-28DAA648C0F6}")]
			FOLDERID_SkyDrive,

			/// <summary>Camera Roll</summary>
			[KnownFolderDetail("{767E6811-49CB-4273-87C2-20F355E1085B}")]
			FOLDERID_SkyDriveCameraRoll,

			/// <summary>Documents</summary>
			[KnownFolderDetail("{24D89E24-2F19-4534-9DDE-6A6671FBB8FE}")]
			FOLDERID_SkyDriveDocuments,

			/// <summary>Pictures</summary>
			[KnownFolderDetail("{339719B5-8C47-4894-94C2-D8F77ADD44A6}")]
			FOLDERID_SkyDrivePictures,

			/// <summary>Start Menu</summary>
			[KnownFolderDetail("{625B53C3-AB48-4EC1-BA1F-A1EF4146FC19}", Equivalent = Environment.SpecialFolder.StartMenu)]
			FOLDERID_StartMenu,

			/// <summary>Startup</summary>
			[KnownFolderDetail("{B97D20BB-F46A-4C97-BA10-5E3608430854}", Equivalent = Environment.SpecialFolder.Startup)]
			FOLDERID_Startup,

			/// <summary>Sync Center</summary>
			[KnownFolderDetail("{43668BF8-C14E-49B2-97C9-747784D784B7}")]
			FOLDERID_SyncManagerFolder,

			/// <summary>Sync Results</summary>
			[KnownFolderDetail("{289a9a43-be44-4057-a41b-587a76d7e7f9}")]
			FOLDERID_SyncResultsFolder,

			/// <summary>Sync Setup</summary>
			[KnownFolderDetail("{0F214138-B1D3-4a90-BBA9-27CBC0C5389A}")]
			FOLDERID_SyncSetupFolder,

			/// <summary>System32</summary>
			[KnownFolderDetail("{1AC14E77-02E7-4E5D-B744-2EB1AE5198B7}", Equivalent = Environment.SpecialFolder.System)]
			FOLDERID_System,

			/// <summary>System32</summary>
			[KnownFolderDetail("{D65231B0-B2F1-4857-A4CE-A8E7C6EA7D27}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_SYSTEMX86)]
			FOLDERID_SystemX86,

			/// <summary>Templates</summary>
			[KnownFolderDetail("{A63293E8-664E-48DB-A079-DF759E0509F7}", Equivalent = Environment.SpecialFolder.Templates)]
			FOLDERID_Templates,

			/// <summary>User Pinned</summary>
			[KnownFolderDetail("{9E3995AB-1F9C-4F13-B827-48B24B6C7174}")]
			FOLDERID_UserPinned,

			/// <summary>Users</summary>
			[KnownFolderDetail("{0762D272-C50A-4BB0-A382-697DCD729B80}")]
			FOLDERID_UserProfiles,

			/// <summary>Programs</summary>
			[KnownFolderDetail("{5CD7AEE2-2219-4A67-B85D-6C9CE15660CB}")]
			FOLDERID_UserProgramFiles,

			/// <summary>Programs</summary>
			[KnownFolderDetail("{BCBD3057-CA5C-4622-B42D-BC56DB0AE516}")]
			FOLDERID_UserProgramFilesCommon,

			/// <summary>The user's full name (for instance, Jean Philippe Bagel) entered when the user account was created.</summary>
			[KnownFolderDetail("{f3ce0f7c-4901-4acc-8648-d5d44b04ef8f}")]
			FOLDERID_UsersFiles,

			/// <summary>Libraries</summary>
			[KnownFolderDetail("{A302545D-DEFF-464b-ABE8-61C8648D939B}")]
			FOLDERID_UsersLibraries,

			/// <summary>Videos</summary>
			[KnownFolderDetail("{18989B1D-99B5-455B-841C-AB7C74E4DDFC}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_MYVIDEO)]
			FOLDERID_Videos,

			/// <summary>Videos</summary>
			[KnownFolderDetail("{491E922F-5643-4AF4-A7EB-4E7A138D8174}")]
			FOLDERID_VideosLibrary,

			/// <summary>Windows</summary>
			[KnownFolderDetail("{F38BF404-1D43-42F2-9305-67DE0B28FC23}", Equivalent = (Environment.SpecialFolder)CSIDL.CSIDL_WINDOWS)]
			FOLDERID_Windows,
		}

		/// <summary>
		/// Exposes methods that allow an application to retrieve information about a known folder's category, type, GUID, pointer to an item
		/// identifier list (PIDL) value, redirection capabilities, and definition. It provides a method for the retrieval of a known folder's
		/// IShellItem object. It also provides methods to get or set the path of the known folder.
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
			/// When this method returns, contains the interface pointer requested in <paramref name="riid"/>. This is typically IShellItem or IShellItem2.
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
			/// properties, get the current path of the folder, redirect the folder to another location, and get the path of the folder as an ITEMIDLIST.
			/// </summary>
			/// <param name="rfid">Reference to the KNOWNFOLDERID.</param>
			/// <returns>When this method returns, contains an interface pointer to the IKnownFolder object that represents the folder.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IKnownFolder GetFolder(in Guid rfid);

			/// <summary>
			/// Gets an object that represents a known folder identified by its canonical name. The object allows you to query certain folder
			/// properties, get the current path of the folder, redirect the folder to another location, and get the path of the folder as an ITEMIDLIST.
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
			/// properties, get the current path of the folder, redirect the folder to another location, and get the path of the folder as an ITEMIDLIST.
			/// </summary>
			/// <param name="pszPath">Pointer to a null-terminated Unicode string of length MAX_PATH that contains a path to a known folder.</param>
			/// <param name="mode">
			/// One of the following values that specify the precision of the match of path and known folder: FFFP_EXACTMATCH = Retrieve only
			/// the specific known folder for the given file path; FFFP_NEARESTPARENTMATCH = If an exact match is not found for the given
			/// file path, retrieve the first known folder that matches one of its parent folders walking up the parent tree.
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
			SafeCoTaskMemString Redirect(in Guid rfid, [In] HWND hwnd, [In] KF_REDIRECT_FLAGS flags,
				[In, MarshalAs(UnmanagedType.LPWStr)] string pszTargetPath, [In] uint cFolders, [In] Guid[] pExclusion);
		}

		/// <summary>Gets an array of all registered known folder IDs. This can be used in enumerating all known folders.</summary>
		/// <param name="mgr">The <see cref="IKnownFolderManager"/> instance.</param>
		/// <returns>An enumeration of all KNOWNFOLDERID values registered with the system.</returns>
		/// <remarks>
		/// <para>The caller of this method must have User privileges.</para>
		/// <para>You can use StringFromCLSID or StringFromGUID2 to convert the retrieved KNOWNFOLDERID values to strings.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iknownfoldermanager-getfolderids HRESULT
		// GetFolderIds( KNOWNFOLDERID **ppKFId, UINT *pCount );
		[PInvokeData("shobjidl_core.h", MSDNShortId = "3ac09fc4-15c4-4346-94ad-2a4617c463d1")]
		public static IEnumerable<KNOWNFOLDERID> GetFolderIds(this IKnownFolderManager mgr) { mgr.GetFolderIds(out var mem, out var c); return mem.ToEnumerable<KNOWNFOLDERID>((int)c); }

		/// <summary>Extension method to simplify using the <see cref="IKnownFolder.GetShellItem"/> method.</summary>
		/// <typeparam name="T">Type of the interface to get.</typeparam>
		/// <param name="fv">An <see cref="IKnownFolder"/> instance.</param>
		/// <param name="dwFlags">
		/// Flags that specify special retrieval options. This value can be 0; otherwise, one or more of the KNOWN_FOLDER_FLAG values.
		/// </param>
		/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
			public static T GetShellItem<T>(this IKnownFolder fv, [In] KNOWN_FOLDER_FLAG dwFlags) where T : class => (T)fv.GetShellItem(dwFlags, typeof(T).GUID);

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
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] public string pszName;

			/// <summary>
			/// A pointer to a short description of the known folder, stored as a null-terminated Unicode string. This description should
			/// include the folder's purpose and usage.
			/// </summary>
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] public string pszDescription;

			/// <summary>
			/// A KNOWNFOLDERID value that names another known folder to serve as the parent folder. Applies to common and per-user folders
			/// only. This value is used in conjunction with pszRelativePath. See Remarks for more details. This value is optional if no
			/// value is provided for pszRelativePath.
			/// </summary>
			public Guid fidParent;

			/// <summary>
			/// Optional. A pointer to a path relative to the parent folder specified in fidParent. This is a null-terminated Unicode string,
			/// refers to the physical file system path, and is not localized. Applies to common and per-user folders only. See Remarks for
			/// more details.
			/// </summary>
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] public string pszRelativePath;

			/// <summary>
			/// A pointer to the Shell namespace folder path of the folder, stored as a null-terminated Unicode string. Applies to virtual
			/// folders only. For example, Control Panel has a parsing name of ::%CLSID_MyComputer%\::%CLSID_ControlPanel%.
			/// </summary>
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] public string pszParsingName;

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
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] public string pszTooltip;

			/// <summary>
			/// Optional. A pointer to the default localized name resource used when the folder is created. This is a null-terminated Unicode
			/// string in this form:
			/// <para><c>Module name, Resource ID</c></para>
			/// <para>
			/// When the folder is created, this string is stored in that folder's copy of Desktop.ini. It can be changed later by other
			/// Shell APIs.
			/// </para>
			/// <para>This information is not required for virtual folders.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] public string pszLocalizedName;

			/// <summary>
			/// Optional. A pointer to the default icon resource used when the folder is created. This is a null-terminated Unicode string in
			/// this form:
			/// <para><c>Module name, Resource ID</c></para>
			/// <para>
			/// When the folder is created, this string is stored in that folder's copy of Desktop.ini. It can be changed later by other
			/// Shell APIs.
			/// </para>
			/// <para>This information is not required for virtual folders.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] public string pszIcon;

			/// <summary>
			/// Optional. A pointer to a Security Descriptor Definition Language format string. This is a null-terminated Unicode string that
			/// describes the default security descriptor that the folder receives when it is created. If this parameter is NULL, the new
			/// folder inherits the security descriptor of its parent. This is particularly useful for common folders that are accessed by
			/// all users.
			/// </summary>
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] public string pszSecurity;

			/// <summary>
			/// Optional. Default file system attributes given to the folder when it is created. For example, the file could be hidden and
			/// read-only (FILE_ATTRIBUTE_HIDDEN and FILE_ATTRIBUTE_READONLY). For a complete list of possible values, see the
			/// dwFlagsAndAttributes parameter of the CreateFile function. Set to -1 if not needed.
			/// </summary>
			public uint dwAttributes;

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
			public KnownFolderDetailAttribute(string knownFolderGuid) : base(knownFolderGuid)
			{
			}
		}
	}
}