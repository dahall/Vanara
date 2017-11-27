using System;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Shell32;
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	/// <summary>Extension methods for <see cref="KNOWNFOLDERID"/>.</summary>
	public static class KnownFolderIdExt
	{
		private const string RegPath =
			@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FolderDescriptions\";

		private const KNOWN_FOLDER_FLAG stdGetFlags =
			KNOWN_FOLDER_FLAG.KF_FLAG_DEFAULT_PATH | KNOWN_FOLDER_FLAG.KF_FLAG_NOT_PARENT_RELATIVE |
			KNOWN_FOLDER_FLAG.KF_FLAG_NO_ALIAS | KNOWN_FOLDER_FLAG.KF_FLAG_DONT_VERIFY;

		/// <summary>Retrieves the full path associated with a <see cref="KNOWNFOLDERID"/>.</summary>
		/// <param name="id">The known folder.</param>
		/// <returns>The path.</returns>
		public static string FullPath(this KNOWNFOLDERID id)
		{
			SafeCoTaskMemHandle path;
			SHGetKnownFolderPath(id.Guid(), stdGetFlags, SafeTokenHandle.Null, out path);
			return path.ToString(-1);
		}

		/// <summary>Gets a registry property associated with this known folder.</summary>
		/// <typeparam name="T">Return type.</typeparam>
		/// <param name="id">The known folder.</param>
		/// <param name="valueName">Name of the property (value under registry key).</param>
		/// <returns>Retrieved value or default(T) if no value exists.</returns>
		public static T GetRegistryProperty<T>(this KNOWNFOLDERID id, string valueName) => (T)
			Microsoft.Win32.Registry.GetValue(RegPath + id.Guid().ToString("B"), valueName, default(T));

		/// <summary>Retrieves the Guid associated with a <see cref="KNOWNFOLDERID"/>.</summary>
		/// <param name="id">The known folder.</param>
		/// <returns>The GUID.</returns>
		public static Guid Guid(this KNOWNFOLDERID id)
		{
			var attr = typeof(KNOWNFOLDERID).GetField(id.ToString())
				.GetCustomAttributes(typeof(KnownFolderDetailAttribute), false);
			return attr.Length > 0 ? ((KnownFolderDetailAttribute) attr[0]).guid : System.Guid.Empty;
		}

		/// <summary>Retrieves the <see cref="KNOWNFOLDERID"/> associated with the <see cref="Environment.SpecialFolder"/>.</summary>
		/// <param name="spFolder">The <see cref="Environment.SpecialFolder"/>.</param>
		/// <returns>Matching <see cref="KNOWNFOLDERID"/>.</returns>
		public static KNOWNFOLDERID KnownFolderId(this System.Environment.SpecialFolder spFolder)
		{
			if (spFolder == Environment.SpecialFolder.Personal) return KNOWNFOLDERID.FOLDERID_Documents;
			if (spFolder == Environment.SpecialFolder.DesktopDirectory) return KNOWNFOLDERID.FOLDERID_Desktop;
			foreach (KNOWNFOLDERID val in Enum.GetValues(typeof(KNOWNFOLDERID)))
				if (val.SpecialFolder() == spFolder) return val;
			throw new InvalidCastException(@"There is not a Known Folder equivalent to this SpecialFolder.");
		}

		/// <summary>Retrieves the name associated with a <see cref="KNOWNFOLDERID"/>.</summary>
		/// <param name="id">The known folder.</param>
		/// <returns>The name.</returns>
		public static string Name(this KNOWNFOLDERID id) => id.GetRegistryProperty<string>("Name");

		/// <summary>Retrieves the PIDL associated with a <see cref="KNOWNFOLDERID"/>.</summary>
		/// <param name="id">The known folder.</param>
		/// <returns>The PIDL.</returns>
		public static PIDL PIDL(this KNOWNFOLDERID id)
		{
			PIDL pidl;
			SHGetKnownFolderIDList(id.Guid(), stdGetFlags, SafeTokenHandle.Null, out pidl);
			return pidl;
		}

		/// <summary>Retrieves the <see cref="Environment.SpecialFolder"/> associated with a <see cref="KNOWNFOLDERID"/> if it exists.</summary>
		/// <param name="id">The known folder.</param>
		/// <returns>The <see cref="Environment.SpecialFolder"/> if defined, <c>null</c> otherwise.</returns>
		public static Environment.SpecialFolder? SpecialFolder(this KNOWNFOLDERID id)
		{
			var attr = typeof(KNOWNFOLDERID).GetField(id.ToString())
				.GetCustomAttributes(typeof(KnownFolderDetailAttribute), false);
			var ret = (Environment.SpecialFolder) 0XFFFF;
			if (attr.Length > 0)
				ret = ((KnownFolderDetailAttribute) attr[0]).Equivalent;
			return ret == (Environment.SpecialFolder) 0XFFFF ? (Environment.SpecialFolder?) null : ret;
		}
	}

	public static partial class Shell32
	{
		/// <summary>
		/// The KNOWNFOLDERID constants represent GUIDs that identify standard folders registered with the system as Known Folders. These folders are installed
		/// with Windows Vista and later operating systems, and a computer will have only folders appropriate to it installed. For descriptions of these folders,
		/// see CSIDL.
		/// </summary>
		[PInvokeData("Knownfolders.h", MSDNShortId = "dd378457")]
		public enum KNOWNFOLDERID
		{
			/// <summary>Account Pictures</summary>
			[KnownFolderDetail("{008ca0b1-55b4-4c56-b8a8-4de4b299d3be}")] FOLDERID_AccountPictures,

			/// <summary>Get Programs</summary>
			[KnownFolderDetail("{de61d971-5ebc-4f02-a3a9-6c82895e5c04}")] FOLDERID_AddNewPrograms,

			[KnownFolderDetail("{724EF170-A42D-4FEF-9F26-B60E846FBA4F}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_ADMINTOOLS)]
			FOLDERID_AdminTools,

			[KnownFolderDetail("{A3918781-E5F2-4890-B3D9-A7E54332328C}")] FOLDERID_ApplicationShortcuts,

			/// <summary>Applications</summary>
			[KnownFolderDetail("{1e87508d-89c2-42f0-8a7e-645a0f50ca58}")] FOLDERID_AppsFolder,

			/// <summary>Installed Updates</summary>
			[KnownFolderDetail("{a305ce99-f527-492b-8b1a-7e76fa98d6e4}")] FOLDERID_AppUpdates,

			/// <summary>Camera Roll</summary>
			[KnownFolderDetail("{AB5FB87B-7CE2-4F83-915D-550846C9537B}")] FOLDERID_CameraRoll,

			/// <summary>Temporary Burn Folder</summary>
			[KnownFolderDetail("{9E52AB10-F80D-49DF-ACB8-4330F5687855}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_CDBURN_AREA)]
			FOLDERID_CDBurning,

			/// <summary>Programs and Features</summary>
			[KnownFolderDetail("{df7266ac-9274-4867-8d55-3bd661de872d}")] FOLDERID_ChangeRemovePrograms,

			/// <summary>Administrative Tools</summary>
			[KnownFolderDetail("{D0384E7D-BAC3-4797-8F14-CBA229B392B5}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_COMMON_ADMINTOOLS)]
			FOLDERID_CommonAdminTools,

			/// <summary>OEM Links</summary>
			[KnownFolderDetail("{C1BAE2D0-10DF-4334-BEDD-7AA20B227A9D}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_COMMON_OEM_LINKS)]
			FOLDERID_CommonOEMLinks,

			/// <summary>Programs</summary>
			[KnownFolderDetail("{0139D44E-6AFE-49F2-8690-3DAFCAE6FFB8}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_COMMON_PROGRAMS)]
			FOLDERID_CommonPrograms,

			/// <summary>Start Menu</summary>
			[KnownFolderDetail("{A4115719-D62E-491D-AA7C-E74B8BE3B067}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_COMMON_STARTMENU)]
			FOLDERID_CommonStartMenu,

			/// <summary>Startup</summary>
			[KnownFolderDetail("{82A5EA35-D9CD-47C5-9629-E15D2F714E6E}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_COMMON_STARTUP)]
			FOLDERID_CommonStartup,

			/// <summary>Templates</summary>
			[KnownFolderDetail("{B94237E7-57AC-4347-9151-B08C6C32D1F7}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_COMMON_TEMPLATES)]
			FOLDERID_CommonTemplates,

			/// <summary>Computer</summary>
			[KnownFolderDetail("{0AC0837C-BBF8-452A-850D-79D08E667CA7}", Equivalent = Environment.SpecialFolder.MyComputer)]
			FOLDERID_ComputerFolder,

			/// <summary>Conflicts</summary>
			[KnownFolderDetail("{4bfefb45-347d-4006-a5be-ac0cb0567192}")] FOLDERID_ConflictFolder,

			/// <summary>Network Connections</summary>
			[KnownFolderDetail("{6F0CD92B-2E97-45D1-88FF-B0D186B8DEDD}")] FOLDERID_ConnectionsFolder,

			/// <summary>Contacts</summary>
			[KnownFolderDetail("{56784854-C6CB-462b-8169-88E350ACB882}")] FOLDERID_Contacts,

			/// <summary>Control Panel</summary>
			[KnownFolderDetail("{82A74AEB-AEB4-465C-A014-D097EE346D63}")] FOLDERID_ControlPanelFolder,

			/// <summary>Cookies</summary>
			[KnownFolderDetail("{2B0F765D-C0E9-4171-908E-08A611B84FF6}", Equivalent = Environment.SpecialFolder.Cookies)]
			FOLDERID_Cookies,

			/// <summary>Desktop</summary>
			[KnownFolderDetail("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", Equivalent = Environment.SpecialFolder.Desktop)]
			FOLDERID_Desktop,

			/// <summary>DeviceMetadataStore</summary>
			[KnownFolderDetail("{5CE4A5E9-E4EB-479D-B89F-130C02886155}")] FOLDERID_DeviceMetadataStore,

			/// <summary>Documents</summary>
			[KnownFolderDetail("{FDD39AD0-238F-46AF-ADB4-6C85480369C7}", Equivalent = Environment.SpecialFolder.MyDocuments)]
			FOLDERID_Documents,

			/// <summary>Documents</summary>
			[KnownFolderDetail("{7B0DB17D-9CD2-4A93-9733-46CC89022E7C}")] FOLDERID_DocumentsLibrary,

			/// <summary>Downloads</summary>
			[KnownFolderDetail("{374DE290-123F-4565-9164-39C4925E467B}")] FOLDERID_Downloads,

			/// <summary>Favorites</summary>
			[KnownFolderDetail("{1777F761-68AD-4D8A-87BD-30B759FA33DD}", Equivalent = Environment.SpecialFolder.Favorites)]
			FOLDERID_Favorites,

			/// <summary>Fonts</summary>
			[KnownFolderDetail("{FD228CB7-AE11-4AE3-864C-16F3910AB8FE}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_FONTS)]
			FOLDERID_Fonts,

			/// <summary>Games</summary>
			[KnownFolderDetail("{CAC52C1A-B53D-4edc-92D7-6B2E8AC19434}")] FOLDERID_Games,

			/// <summary>GameExplorer</summary>
			[KnownFolderDetail("{054FAE61-4DD8-4787-80B6-090220C4B700}")] FOLDERID_GameTasks,

			/// <summary>History</summary>
			[KnownFolderDetail("{D9DC8A3B-B784-432E-A781-5A1130A75963}", Equivalent = Environment.SpecialFolder.History)]
			FOLDERID_History,

			/// <summary>Homegroup</summary>
			[KnownFolderDetail("{52528A6B-B9E3-4ADD-B60D-588C2DBA842D}")] FOLDERID_HomeGroup,

			/// <summary>The user's username (%USERNAME%)</summary>
			[KnownFolderDetail("{9B74B6A3-0DFD-4f11-9E78-5F7800F2E772}")] FOLDERID_HomeGroupCurrentUser,

			/// <summary>ImplicitAppShortcuts</summary>
			[KnownFolderDetail("{BCB5256F-79F6-4CEE-B725-DC34E402FD46}")] FOLDERID_ImplicitAppShortcuts,

			/// <summary>Temporary Internet Files</summary>
			[KnownFolderDetail("{352481E8-33BE-4251-BA85-6007CAEDCF9D}", Equivalent = Environment.SpecialFolder.InternetCache)]
			FOLDERID_InternetCache,

			/// <summary>The Internet</summary>
			[KnownFolderDetail("{4D9F7874-4E0C-4904-967B-40B0D20C3E4B}")] FOLDERID_InternetFolder,

			/// <summary>Libraries</summary>
			[KnownFolderDetail("{1B3EA5DC-B587-4786-B4EF-BD1DC332AEAE}")] FOLDERID_Libraries,

			/// <summary>Links</summary>
			[KnownFolderDetail("{bfb9d5e0-c6a9-404c-b2b2-ae6db6af4968}")] FOLDERID_Links,

			/// <summary>Local</summary>
			[KnownFolderDetail("{F1B32785-6FBA-4FCF-9D55-7B8E7F157091}", Equivalent =
				Environment.SpecialFolder.LocalApplicationData)]
			FOLDERID_LocalAppData,

			/// <summary>LocalLow</summary>
			[KnownFolderDetail("{A520A1A4-1780-4FF6-BD18-167343C5AF16}")] FOLDERID_LocalAppDataLow,

			/// <summary>None</summary>
			[KnownFolderDetail("{2A00375E-224C-49DE-B8D1-440DF7EF3DDC}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_RESOURCES_LOCALIZED)]
			FOLDERID_LocalizedResourcesDir,

			/// <summary>Music</summary>
			[KnownFolderDetail("{4BD8D571-6D19-48D3-BE97-422220080E43}", Equivalent = Environment.SpecialFolder.MyMusic)]
			FOLDERID_Music,

			/// <summary>Music</summary>
			[KnownFolderDetail("{2112AB0A-C86A-4FFE-A368-0DE96E47012E}")] FOLDERID_MusicLibrary,

			/// <summary>Network Shortcuts</summary>
			[KnownFolderDetail("{C5ABBF53-E17F-4121-8900-86626FC2C973}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_NETHOOD)]
			FOLDERID_NetHood,

			/// <summary>Network</summary>
			[KnownFolderDetail("{D20BEEC4-5CA8-4905-AE3B-BF251EA09B53}")] FOLDERID_NetworkFolder,

			/// <summary>Original Images</summary>
			[KnownFolderDetail("{2C36C0AA-5812-4b87-BFD0-4CD0DFB19B39}")] FOLDERID_OriginalImages,

			/// <summary>Slide Shows</summary>
			[KnownFolderDetail("{69D2CF90-FC33-4FB7-9A0C-EBB0F0FCB43C}")] FOLDERID_PhotoAlbums,

			/// <summary>Pictures</summary>
			[KnownFolderDetail("{A990AE9F-A03B-4E80-94BC-9912D7504104}")] FOLDERID_PicturesLibrary,

			/// <summary>Pictures</summary>
			[KnownFolderDetail("{33E28130-4E1E-4676-835A-98395C3BC3BB}", Equivalent = Environment.SpecialFolder.MyPictures)]
			FOLDERID_Pictures,

			/// <summary>Playlists</summary>
			[KnownFolderDetail("{DE92C1C7-837F-4F69-A3BB-86E631204A23}")] FOLDERID_Playlists,

			/// <summary>Printers</summary>
			[KnownFolderDetail("{76FC4E2D-D6AD-4519-A663-37BD56068185}")] FOLDERID_PrintersFolder,

			/// <summary>Printer Shortcuts</summary>
			[KnownFolderDetail("{9274BD8D-CFD1-41C3-B35E-B13F55A758F4}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_PRINTHOOD)]
			FOLDERID_PrintHood,

			/// <summary>The user's username (%USERNAME%)</summary>
			[KnownFolderDetail("{5E6C858F-0E22-4760-9AFE-EA3317B67173}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_PROFILE)]
			FOLDERID_Profile,

			/// <summary>ProgramData</summary>
			[KnownFolderDetail("{62AB5D82-FDC1-4DC3-A9DD-070D1D495D97}", Equivalent =
				Environment.SpecialFolder.CommonApplicationData)]
			FOLDERID_ProgramData,

			/// <summary>Program Files</summary>
			[KnownFolderDetail("{905e63b6-c1bf-494e-b29c-65b732d3d21a}", Equivalent = Environment.SpecialFolder.ProgramFiles)]
			FOLDERID_ProgramFiles,

			/// <summary>Program Files</summary>
			[KnownFolderDetail("{6D809377-6AF0-444b-8957-A3773F02200E}")] FOLDERID_ProgramFilesX64,

			/// <summary>Program Files</summary>
			[KnownFolderDetail("{7C5A40EF-A0FB-4BFC-874A-C0F2E0B9FA8E}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_PROGRAM_FILESX86)]
			FOLDERID_ProgramFilesX86,

			/// <summary>Common Files</summary>
			[KnownFolderDetail("{F7F1ED05-9F6D-47A2-AAAE-29D317C6F066}", Equivalent =
				Environment.SpecialFolder.CommonProgramFiles)]
			FOLDERID_ProgramFilesCommon,

			/// <summary>Common Files</summary>
			[KnownFolderDetail("{6365D5A7-0F0D-45E5-87F6-0DA56B6A4F7D}")] FOLDERID_ProgramFilesCommonX64,

			/// <summary>Common Files</summary>
			[KnownFolderDetail("{DE974D24-D9C6-4D3E-BF91-F4455120B917}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_PROGRAM_FILES_COMMONX86)]
			FOLDERID_ProgramFilesCommonX86,

			/// <summary>Programs</summary>
			[KnownFolderDetail("{A77F5D77-2E2B-44C3-A6A2-ABA601054A51}", Equivalent = Environment.SpecialFolder.Programs)]
			FOLDERID_Programs,

			/// <summary>Public</summary>
			[KnownFolderDetail("{DFDF76A2-C82A-4D63-906A-5644AC457385}")] FOLDERID_Public,

			/// <summary>Public Desktop</summary>
			[KnownFolderDetail("{C4AA340D-F20F-4863-AFEF-F87EF2E6BA25}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_COMMON_DESKTOPDIRECTORY)]
			FOLDERID_PublicDesktop,

			/// <summary>Public Documents</summary>
			[KnownFolderDetail("{ED4824AF-DCE4-45A8-81E2-FC7965083634}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_COMMON_DOCUMENTS)]
			FOLDERID_PublicDocuments,

			/// <summary>Public Downloads</summary>
			[KnownFolderDetail("{3D644C9B-1FB8-4f30-9B45-F670235F79C0}")] FOLDERID_PublicDownloads,

			/// <summary>GameExplorer</summary>
			[KnownFolderDetail("{DEBF2536-E1A8-4c59-B6A2-414586476AEA}")] FOLDERID_PublicGameTasks,

			/// <summary>Libraries</summary>
			[KnownFolderDetail("{48DAF80B-E6CF-4F4E-B800-0E69D84EE384}")] FOLDERID_PublicLibraries,

			/// <summary>Public Music</summary>
			[KnownFolderDetail("{3214FAB5-9757-4298-BB61-92A9DEAA44FF}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_COMMON_MUSIC)]
			FOLDERID_PublicMusic,

			/// <summary>Public Pictures</summary>
			[KnownFolderDetail("{B6EBFB86-6907-413C-9AF7-4FC2ABF07CC5}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_COMMON_PICTURES)]
			FOLDERID_PublicPictures,

			/// <summary>Ringtones</summary>
			[KnownFolderDetail("{E555AB60-153B-4D17-9F04-A5FE99FC15EC}")] FOLDERID_PublicRingtones,

			/// <summary>Public Account Pictures</summary>
			[KnownFolderDetail("{0482af6c-08f1-4c34-8c90-e17ec98b1e17}")] FOLDERID_PublicUserTiles,

			/// <summary>Public Videos</summary>
			[KnownFolderDetail("{2400183A-6185-49FB-A2D8-4A392A602BA3}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_COMMON_VIDEO)]
			FOLDERID_PublicVideos,

			/// <summary>Quick Launch</summary>
			[KnownFolderDetail("{52a4f021-7b75-48a9-9f6b-4b87a210bc8f}")] FOLDERID_QuickLaunch,

			/// <summary>Recent Items</summary>
			[KnownFolderDetail("{AE50C081-EBD2-438A-8655-8A092E34987A}", Equivalent = Environment.SpecialFolder.Recent)]
			FOLDERID_Recent,

			/// <summary>Recorded TV</summary>
			[KnownFolderDetail("{1A6FDBA2-F42D-4358-A798-B74D745926C5}")] FOLDERID_RecordedTVLibrary,

			/// <summary>Recycle Bin</summary>
			[KnownFolderDetail("{B7534046-3ECB-4C18-BE4E-64CD4CB7D6AC}")] FOLDERID_RecycleBinFolder,

			/// <summary>Resources</summary>
			[KnownFolderDetail("{8AD10C31-2ADB-4296-A8F7-E4701232C972}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_RESOURCES)]
			FOLDERID_ResourceDir,

			/// <summary>Ringtones</summary>
			[KnownFolderDetail("{C870044B-F49E-4126-A9C3-B52A1FF411E8}")] FOLDERID_Ringtones,

			/// <summary>Roaming</summary>
			[KnownFolderDetail("{3EB685DB-65F9-4CF6-A03A-E3EF65729F3D}", Equivalent =
				Environment.SpecialFolder.ApplicationData)]
			FOLDERID_RoamingAppData,

			/// <summary>RoamedTileImages</summary>
			[KnownFolderDetail("{AAA8D5A5-F1D6-4259-BAA8-78E7EF60835E}")] FOLDERID_RoamedTileImages,

			/// <summary>RoamingTiles</summary>
			[KnownFolderDetail("{00BCFC5A-ED94-4e48-96A1-3F6217F21990}")] FOLDERID_RoamingTiles,

			/// <summary>Sample Music</summary>
			[KnownFolderDetail("{B250C668-F57D-4EE1-A63C-290EE7D1AA1F}")] FOLDERID_SampleMusic,

			/// <summary>Sample Pictures</summary>
			[KnownFolderDetail("{C4900540-2379-4C75-844B-64E6FAF8716B}")] FOLDERID_SamplePictures,

			/// <summary>Sample Playlists</summary>
			[KnownFolderDetail("{15CA69B3-30EE-49C1-ACE1-6B5EC372AFB5}")] FOLDERID_SamplePlaylists,

			/// <summary>Sample Videos</summary>
			[KnownFolderDetail("{859EAD94-2E85-48AD-A71A-0969CB56A6CD}")] FOLDERID_SampleVideos,

			/// <summary>Saved Games</summary>
			[KnownFolderDetail("{4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4}")] FOLDERID_SavedGames,

			/// <summary>Saved Pictures</summary>
			[KnownFolderDetail("{3B193882-D3AD-4eab-965A-69829D1FB59F}")] FOLDERID_SavedPictures,

			/// <summary>Saved Pictures Library</summary>
			[KnownFolderDetail("{E25B5812-BE88-4bd9-94B0-29233477B6C3}")] FOLDERID_SavedPicturesLibrary,

			/// <summary>Searches</summary>
			[KnownFolderDetail("{7d1d3a04-debb-4115-95cf-2f29da2920da}")] FOLDERID_SavedSearches,

			/// <summary>Screenshots</summary>
			[KnownFolderDetail("{b7bede81-df94-4682-a7d8-57a52620b86f}")] FOLDERID_Screenshots,

			/// <summary>Offline Files</summary>
			[KnownFolderDetail("{ee32e446-31ca-4aba-814f-a5ebd2fd6d5e}")] FOLDERID_SEARCH_CSC,

			/// <summary>History</summary>
			[KnownFolderDetail("{0D4C3DB6-03A3-462F-A0E6-08924C41B5D4}")] FOLDERID_SearchHistory,

			/// <summary>Search Results</summary>
			[KnownFolderDetail("{190337d1-b8ca-4121-a639-6d472d16972a}")] FOLDERID_SearchHome,

			/// <summary>Microsoft Office Outlook</summary>
			[KnownFolderDetail("{98ec0e18-2098-4d44-8644-66979315a281}")] FOLDERID_SEARCH_MAPI,

			/// <summary>Templates</summary>
			[KnownFolderDetail("{7E636BFE-DFA9-4D5E-B456-D7B39851D8A9}")] FOLDERID_SearchTemplates,

			/// <summary>SendTo</summary>
			[KnownFolderDetail("{8983036C-27C0-404B-8F08-102D10DCFD74}", Equivalent = Environment.SpecialFolder.SendTo)]
			FOLDERID_SendTo,

			/// <summary>Gadgets</summary>
			[KnownFolderDetail("{7B396E54-9EC5-4300-BE0A-2482EBAE1A26}")] FOLDERID_SidebarDefaultParts,

			/// <summary>Gadgets</summary>
			[KnownFolderDetail("{A75D362E-50FC-4fb7-AC2C-A8BEAA314493}")] FOLDERID_SidebarParts,

			/// <summary>OneDrive</summary>
			[KnownFolderDetail("{A52BBA46-E9E1-435f-B3D9-28DAA648C0F6}")] FOLDERID_SkyDrive,

			/// <summary>Camera Roll</summary>
			[KnownFolderDetail("{767E6811-49CB-4273-87C2-20F355E1085B}")] FOLDERID_SkyDriveCameraRoll,

			/// <summary>Documents</summary>
			[KnownFolderDetail("{24D89E24-2F19-4534-9DDE-6A6671FBB8FE}")] FOLDERID_SkyDriveDocuments,

			/// <summary>Pictures</summary>
			[KnownFolderDetail("{339719B5-8C47-4894-94C2-D8F77ADD44A6}")] FOLDERID_SkyDrivePictures,

			/// <summary>Start Menu</summary>
			[KnownFolderDetail("{625B53C3-AB48-4EC1-BA1F-A1EF4146FC19}", Equivalent = Environment.SpecialFolder.StartMenu)]
			FOLDERID_StartMenu,

			/// <summary>Startup</summary>
			[KnownFolderDetail("{B97D20BB-F46A-4C97-BA10-5E3608430854}", Equivalent = Environment.SpecialFolder.Startup)]
			FOLDERID_Startup,

			/// <summary>Sync Center</summary>
			[KnownFolderDetail("{43668BF8-C14E-49B2-97C9-747784D784B7}")] FOLDERID_SyncManagerFolder,

			/// <summary>Sync Results</summary>
			[KnownFolderDetail("{289a9a43-be44-4057-a41b-587a76d7e7f9}")] FOLDERID_SyncResultsFolder,

			/// <summary>Sync Setup</summary>
			[KnownFolderDetail("{0F214138-B1D3-4a90-BBA9-27CBC0C5389A}")] FOLDERID_SyncSetupFolder,

			/// <summary>System32</summary>
			[KnownFolderDetail("{1AC14E77-02E7-4E5D-B744-2EB1AE5198B7}", Equivalent = Environment.SpecialFolder.System)]
			FOLDERID_System,

			/// <summary>System32</summary>
			[KnownFolderDetail("{D65231B0-B2F1-4857-A4CE-A8E7C6EA7D27}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_SYSTEMX86)]
			FOLDERID_SystemX86,

			/// <summary>Templates</summary>
			[KnownFolderDetail("{A63293E8-664E-48DB-A079-DF759E0509F7}", Equivalent = Environment.SpecialFolder.Templates)]
			FOLDERID_Templates,

			/// <summary>User Pinned</summary>
			[KnownFolderDetail("{9E3995AB-1F9C-4F13-B827-48B24B6C7174}")] FOLDERID_UserPinned,

			/// <summary>Users</summary>
			[KnownFolderDetail("{0762D272-C50A-4BB0-A382-697DCD729B80}")] FOLDERID_UserProfiles,

			/// <summary>Programs</summary>
			[KnownFolderDetail("{5CD7AEE2-2219-4A67-B85D-6C9CE15660CB}")] FOLDERID_UserProgramFiles,

			/// <summary>Programs</summary>
			[KnownFolderDetail("{BCBD3057-CA5C-4622-B42D-BC56DB0AE516}")] FOLDERID_UserProgramFilesCommon,

			/// <summary>The user's full name (for instance, Jean Philippe Bagel) entered when the user account was created.</summary>
			[KnownFolderDetail("{f3ce0f7c-4901-4acc-8648-d5d44b04ef8f}")] FOLDERID_UsersFiles,

			/// <summary>Libraries</summary>
			[KnownFolderDetail("{A302545D-DEFF-464b-ABE8-61C8648D939B}")] FOLDERID_UsersLibraries,

			/// <summary>Videos</summary>
			[KnownFolderDetail("{18989B1D-99B5-455B-841C-AB7C74E4DDFC}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_MYVIDEO)]
			FOLDERID_Videos,

			/// <summary>Videos</summary>
			[KnownFolderDetail("{491E922F-5643-4AF4-A7EB-4E7A138D8174}")] FOLDERID_VideosLibrary,

			/// <summary>Windows</summary>
			[KnownFolderDetail("{F38BF404-1D43-42F2-9305-67DE0B28FC23}", Equivalent =
				(Environment.SpecialFolder)CSIDL.CSIDL_WINDOWS)]
			FOLDERID_Windows,
		}

		/// <summary>Provides information about a <see cref="KNOWNFOLDERID"/>.</summary>
		[AttributeUsage(AttributeTargets.Field)]
		internal class KnownFolderDetailAttribute : Attribute
		{
			public Environment.SpecialFolder Equivalent = (Environment.SpecialFolder) 0XFFFF;
			internal Guid guid;

			/// <summary>Initializes a new instance of the <see cref="KnownFolderDetailAttribute"/> class with a GUID for the <see cref="KNOWNFOLDERID"/>.</summary>
			/// <param name="knownFolderGuid">The GUID for the <see cref="KNOWNFOLDERID"/>.</param>
			public KnownFolderDetailAttribute(string knownFolderGuid)
			{
				guid = new Guid(knownFolderGuid);
			}
		}
	}
}