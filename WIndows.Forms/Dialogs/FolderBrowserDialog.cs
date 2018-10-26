using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.Resources;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Windows.Forms
{
	/// <summary>
	/// </summary>
	public enum FolderBrowserDialogOptions
	{
		/// <summary></summary>
		Folders,
		/// <summary></summary>
		FoldersAndFiles,
		/// <summary></summary>
		Computers,
		/// <summary></summary>
		Printers
	}

	/// <summary>
	/// Standard folders registered with the system as Known Folders. A computer will have only folders appropriate to it installed.
	/// </summary>
	public enum KnownFolder
	{
		/// <summary>Account Pictures</summary>
		AccountPictures = KNOWNFOLDERID.FOLDERID_AccountPictures,

		/// <summary>Get Programs</summary>
		AddNewPrograms = KNOWNFOLDERID.FOLDERID_AddNewPrograms,

		/// <summary>Admin tools</summary>
		AdminTools = KNOWNFOLDERID.FOLDERID_AdminTools,

		/// <summary>Application shortcuts</summary>
		ApplicationShortcuts = KNOWNFOLDERID.FOLDERID_ApplicationShortcuts,

		/// <summary>Applications</summary>
		AppsFolder = KNOWNFOLDERID.FOLDERID_AppsFolder,

		/// <summary>Installed Updates</summary>
		AppUpdates = KNOWNFOLDERID.FOLDERID_AppUpdates,

		/// <summary>Camera Roll</summary>
		CameraRoll = KNOWNFOLDERID.FOLDERID_CameraRoll,

		/// <summary>Temporary Burn Folder</summary>
		CDBurning = KNOWNFOLDERID.FOLDERID_CDBurning,

		/// <summary>Programs and Features</summary>
		ChangeRemovePrograms = KNOWNFOLDERID.FOLDERID_ChangeRemovePrograms,

		/// <summary>Administrative Tools</summary>
		CommonAdminTools = KNOWNFOLDERID.FOLDERID_CommonAdminTools,

		/// <summary>OEM Links</summary>
		CommonOEMLinks = KNOWNFOLDERID.FOLDERID_CommonOEMLinks,

		/// <summary>Programs</summary>
		CommonPrograms = KNOWNFOLDERID.FOLDERID_CommonPrograms,

		/// <summary>Start Menu</summary>
		CommonStartMenu = KNOWNFOLDERID.FOLDERID_CommonStartMenu,

		/// <summary>Startup</summary>
		CommonStartup = KNOWNFOLDERID.FOLDERID_CommonStartup,

		/// <summary>Templates</summary>
		CommonTemplates = KNOWNFOLDERID.FOLDERID_CommonTemplates,

		/// <summary>Computer</summary>
		ComputerFolder = KNOWNFOLDERID.FOLDERID_ComputerFolder,

		/// <summary>Conflicts</summary>
		ConflictFolder = KNOWNFOLDERID.FOLDERID_ConflictFolder,

		/// <summary>Network Connections</summary>
		ConnectionsFolder = KNOWNFOLDERID.FOLDERID_ConnectionsFolder,

		/// <summary>Contacts</summary>
		Contacts = KNOWNFOLDERID.FOLDERID_Contacts,

		/// <summary>Control Panel</summary>
		ControlPanelFolder = KNOWNFOLDERID.FOLDERID_ControlPanelFolder,

		/// <summary>Cookies</summary>
		Cookies = KNOWNFOLDERID.FOLDERID_Cookies,

		/// <summary>Desktop</summary>
		Desktop = KNOWNFOLDERID.FOLDERID_Desktop,

		/// <summary>DeviceMetadataStore</summary>
		DeviceMetadataStore = KNOWNFOLDERID.FOLDERID_DeviceMetadataStore,

		/// <summary>Documents</summary>
		Documents = KNOWNFOLDERID.FOLDERID_Documents,

		/// <summary>Documents</summary>
		DocumentsLibrary = KNOWNFOLDERID.FOLDERID_DocumentsLibrary,

		/// <summary>Downloads</summary>
		Downloads = KNOWNFOLDERID.FOLDERID_Downloads,

		/// <summary>Favorites</summary>
		Favorites = KNOWNFOLDERID.FOLDERID_Favorites,

		/// <summary>Fonts</summary>
		Fonts = KNOWNFOLDERID.FOLDERID_Fonts,

		/// <summary>Games</summary>
		Games = KNOWNFOLDERID.FOLDERID_Games,

		/// <summary>GameExplorer</summary>
		GameTasks = KNOWNFOLDERID.FOLDERID_GameTasks,

		/// <summary>History</summary>
		History = KNOWNFOLDERID.FOLDERID_History,

		/// <summary>Homegroup</summary>
		HomeGroup = KNOWNFOLDERID.FOLDERID_HomeGroup,

		/// <summary>The user's username (%USERNAME%)</summary>
		HomeGroupCurrentUser = KNOWNFOLDERID.FOLDERID_HomeGroupCurrentUser,

		/// <summary>ImplicitAppShortcuts</summary>
		ImplicitAppShortcuts = KNOWNFOLDERID.FOLDERID_ImplicitAppShortcuts,

		/// <summary>Temporary Internet Files</summary>
		InternetCache = KNOWNFOLDERID.FOLDERID_InternetCache,

		/// <summary>The Internet</summary>
		InternetFolder = KNOWNFOLDERID.FOLDERID_InternetFolder,

		/// <summary>Libraries</summary>
		Libraries = KNOWNFOLDERID.FOLDERID_Libraries,

		/// <summary>Links</summary>
		Links = KNOWNFOLDERID.FOLDERID_Links,

		/// <summary>Local</summary>
		LocalAppData = KNOWNFOLDERID.FOLDERID_LocalAppData,

		/// <summary>LocalLow</summary>
		LocalAppDataLow = KNOWNFOLDERID.FOLDERID_LocalAppDataLow,

		/// <summary>None</summary>
		LocalizedResourcesDir = KNOWNFOLDERID.FOLDERID_LocalizedResourcesDir,

		/// <summary>Music</summary>
		Music = KNOWNFOLDERID.FOLDERID_Music,

		/// <summary>Music</summary>
		MusicLibrary = KNOWNFOLDERID.FOLDERID_MusicLibrary,

		/// <summary>Network Shortcuts</summary>
		NetHood = KNOWNFOLDERID.FOLDERID_NetHood,

		/// <summary>Network</summary>
		NetworkFolder = KNOWNFOLDERID.FOLDERID_NetworkFolder,

		/// <summary>Original Images</summary>
		OriginalImages = KNOWNFOLDERID.FOLDERID_OriginalImages,

		/// <summary>Slide Shows</summary>
		PhotoAlbums = KNOWNFOLDERID.FOLDERID_PhotoAlbums,

		/// <summary>Pictures</summary>
		PicturesLibrary = KNOWNFOLDERID.FOLDERID_PicturesLibrary,

		/// <summary>Pictures</summary>
		Pictures = KNOWNFOLDERID.FOLDERID_Pictures,

		/// <summary>Playlists</summary>
		Playlists = KNOWNFOLDERID.FOLDERID_Playlists,

		/// <summary>Printers</summary>
		PrintersFolder = KNOWNFOLDERID.FOLDERID_PrintersFolder,

		/// <summary>Printer Shortcuts</summary>
		PrintHood = KNOWNFOLDERID.FOLDERID_PrintHood,

		/// <summary>The user's username (%USERNAME%)</summary>
		Profile = KNOWNFOLDERID.FOLDERID_Profile,

		/// <summary>ProgramData</summary>
		ProgramData = KNOWNFOLDERID.FOLDERID_ProgramData,

		/// <summary>Program Files</summary>
		ProgramFiles = KNOWNFOLDERID.FOLDERID_ProgramFiles,

		/// <summary>Program Files</summary>
		ProgramFilesX64 = KNOWNFOLDERID.FOLDERID_ProgramFilesX64,

		/// <summary>Program Files</summary>
		ProgramFilesX86 = KNOWNFOLDERID.FOLDERID_ProgramFilesX86,

		/// <summary>Common Files</summary>
		ProgramFilesCommon = KNOWNFOLDERID.FOLDERID_ProgramFilesCommon,

		/// <summary>Common Files</summary>
		ProgramFilesCommonX64 = KNOWNFOLDERID.FOLDERID_ProgramFilesCommonX64,

		/// <summary>Common Files</summary>
		ProgramFilesCommonX86 = KNOWNFOLDERID.FOLDERID_ProgramFilesCommonX86,

		/// <summary>Programs</summary>
		Programs = KNOWNFOLDERID.FOLDERID_Programs,

		/// <summary>Public</summary>
		Public = KNOWNFOLDERID.FOLDERID_Public,

		/// <summary>Public Desktop</summary>
		PublicDesktop = KNOWNFOLDERID.FOLDERID_PublicDesktop,

		/// <summary>Public Documents</summary>
		PublicDocuments = KNOWNFOLDERID.FOLDERID_PublicDocuments,

		/// <summary>Public Downloads</summary>
		PublicDownloads = KNOWNFOLDERID.FOLDERID_PublicDownloads,

		/// <summary>GameExplorer</summary>
		PublicGameTasks = KNOWNFOLDERID.FOLDERID_PublicGameTasks,

		/// <summary>Libraries</summary>
		PublicLibraries = KNOWNFOLDERID.FOLDERID_PublicLibraries,

		/// <summary>Public Music</summary>
		PublicMusic = KNOWNFOLDERID.FOLDERID_PublicMusic,

		/// <summary>Public Pictures</summary>
		PublicPictures = KNOWNFOLDERID.FOLDERID_PublicPictures,

		/// <summary>Ringtones</summary>
		PublicRingtones = KNOWNFOLDERID.FOLDERID_PublicRingtones,

		/// <summary>Public Account Pictures</summary>
		PublicUserTiles = KNOWNFOLDERID.FOLDERID_PublicUserTiles,

		/// <summary>Public Videos</summary>
		PublicVideos = KNOWNFOLDERID.FOLDERID_PublicVideos,

		/// <summary>Quick Launch</summary>
		QuickLaunch = KNOWNFOLDERID.FOLDERID_QuickLaunch,

		/// <summary>Recent Items</summary>
		Recent = KNOWNFOLDERID.FOLDERID_Recent,

		/// <summary>Recorded TV</summary>
		RecordedTVLibrary = KNOWNFOLDERID.FOLDERID_RecordedTVLibrary,

		/// <summary>Recycle Bin</summary>
		RecycleBinFolder = KNOWNFOLDERID.FOLDERID_RecycleBinFolder,

		/// <summary>Resources</summary>
		ResourceDir = KNOWNFOLDERID.FOLDERID_ResourceDir,

		/// <summary>Ringtones</summary>
		Ringtones = KNOWNFOLDERID.FOLDERID_Ringtones,

		/// <summary>Roaming</summary>
		RoamingAppData = KNOWNFOLDERID.FOLDERID_RoamingAppData,

		/// <summary>RoamedTileImages</summary>
		RoamedTileImages = KNOWNFOLDERID.FOLDERID_RoamedTileImages,

		/// <summary>RoamingTiles</summary>
		RoamingTiles = KNOWNFOLDERID.FOLDERID_RoamingTiles,

		/// <summary>Sample Music</summary>
		SampleMusic = KNOWNFOLDERID.FOLDERID_SampleMusic,

		/// <summary>Sample Pictures</summary>
		SamplePictures = KNOWNFOLDERID.FOLDERID_SamplePictures,

		/// <summary>Sample Playlists</summary>
		SamplePlaylists = KNOWNFOLDERID.FOLDERID_SamplePlaylists,

		/// <summary>Sample Videos</summary>
		SampleVideos = KNOWNFOLDERID.FOLDERID_SampleVideos,

		/// <summary>Saved Games</summary>
		SavedGames = KNOWNFOLDERID.FOLDERID_SavedGames,

		/// <summary>Saved Pictures</summary>
		SavedPictures = KNOWNFOLDERID.FOLDERID_SavedPictures,

		/// <summary>Saved Pictures Library</summary>
		SavedPicturesLibrary = KNOWNFOLDERID.FOLDERID_SavedPicturesLibrary,

		/// <summary>Searches</summary>
		SavedSearches = KNOWNFOLDERID.FOLDERID_SavedSearches,

		/// <summary>Screenshots</summary>
		Screenshots = KNOWNFOLDERID.FOLDERID_Screenshots,

		/// <summary>Offline Files</summary>
		SEARCH_CSC = KNOWNFOLDERID.FOLDERID_SEARCH_CSC,

		/// <summary>History</summary>
		SearchHistory = KNOWNFOLDERID.FOLDERID_SearchHistory,

		/// <summary>Search Results</summary>
		SearchHome = KNOWNFOLDERID.FOLDERID_SearchHome,

		/// <summary>Microsoft Office Outlook</summary>
		SEARCH_MAPI = KNOWNFOLDERID.FOLDERID_SEARCH_MAPI,

		/// <summary>Templates</summary>
		SearchTemplates = KNOWNFOLDERID.FOLDERID_SearchTemplates,

		/// <summary>SendTo</summary>
		SendTo = KNOWNFOLDERID.FOLDERID_SendTo,

		/// <summary>Gadgets</summary>
		SidebarDefaultParts = KNOWNFOLDERID.FOLDERID_SidebarDefaultParts,

		/// <summary>Gadgets</summary>
		SidebarParts = KNOWNFOLDERID.FOLDERID_SidebarParts,

		/// <summary>OneDrive</summary>
		SkyDrive = KNOWNFOLDERID.FOLDERID_SkyDrive,

		/// <summary>Camera Roll</summary>
		SkyDriveCameraRoll = KNOWNFOLDERID.FOLDERID_SkyDriveCameraRoll,

		/// <summary>Documents</summary>
		SkyDriveDocuments = KNOWNFOLDERID.FOLDERID_SkyDriveDocuments,

		/// <summary>Pictures</summary>
		SkyDrivePictures = KNOWNFOLDERID.FOLDERID_SkyDrivePictures,

		/// <summary>Start Menu</summary>
		StartMenu = KNOWNFOLDERID.FOLDERID_StartMenu,

		/// <summary>Startup</summary>
		Startup = KNOWNFOLDERID.FOLDERID_Startup,

		/// <summary>Sync Center</summary>
		SyncManagerFolder = KNOWNFOLDERID.FOLDERID_SyncManagerFolder,

		/// <summary>Sync Results</summary>
		SyncResultsFolder = KNOWNFOLDERID.FOLDERID_SyncResultsFolder,

		/// <summary>Sync Setup</summary>
		SyncSetupFolder = KNOWNFOLDERID.FOLDERID_SyncSetupFolder,

		/// <summary>System32</summary>
		System = KNOWNFOLDERID.FOLDERID_System,

		/// <summary>System32</summary>
		SystemX86 = KNOWNFOLDERID.FOLDERID_SystemX86,

		/// <summary>Templates</summary>
		Templates = KNOWNFOLDERID.FOLDERID_Templates,

		/// <summary>User Pinned</summary>
		UserPinned = KNOWNFOLDERID.FOLDERID_UserPinned,

		/// <summary>Users</summary>
		UserProfiles = KNOWNFOLDERID.FOLDERID_UserProfiles,

		/// <summary>Programs</summary>
		UserProgramFiles = KNOWNFOLDERID.FOLDERID_UserProgramFiles,

		/// <summary>Programs</summary>
		UserProgramFilesCommon = KNOWNFOLDERID.FOLDERID_UserProgramFilesCommon,

		/// <summary>The user's full name (for instance, Jean Philippe Bagel) entered when the user account was created.</summary>
		UsersFiles = KNOWNFOLDERID.FOLDERID_UsersFiles,

		/// <summary>Libraries</summary>
		UsersLibraries = KNOWNFOLDERID.FOLDERID_UsersLibraries,

		/// <summary>Videos</summary>
		Videos = KNOWNFOLDERID.FOLDERID_Videos,

		/// <summary>Videos</summary>
		VideosLibrary = KNOWNFOLDERID.FOLDERID_VideosLibrary,

		/// <summary>Windows</summary>
		Windows = KNOWNFOLDERID.FOLDERID_Windows,

		/// <summary>Undefined</summary>
		Undefined = 0xFFFF,
	}

	/// <summary>Class to let the user browse for a folder.</summary>
	[ToolboxBitmap(typeof(FolderBrowserDialog), "Dialog"), Description("Dialog that browses network computers.")]
	public class FolderBrowserDialog : CommonDialog
	{
		private const KnownFolder defaultComputersFolder = KnownFolder.NetworkFolder;
		private const KnownFolder defaultFolderFolder = KnownFolder.ComputerFolder;
		private const KnownFolder defaultPrintersFolder = KnownFolder.PrintersFolder;

		private FolderBrowserDialogOptions browseOption;
		private bool initialized;
		private KnownFolder rootFolder;
		private PIDL rootPidl;

		/// <summary>Initializes a new instance of the <see cref="FolderBrowserDialog"/> class.</summary>
		public FolderBrowserDialog()
		{
			Reset();
			RootFolder = defaultFolderFolder;
		}

		/// <summary>Occurs when dialog box has been initialized and primary values have been set.</summary>
		public event EventHandler<FolderBrowserDialogInitializedEventArgs> Initialized;

		/// <summary>Event that is raised when the user selects an invalid folder.</summary>
		public event EventHandler<InvalidFolderEventArgs> InvalidFolderSelected;

		/// <summary>Occurs when <see cref="SelectedItem"/> property has changed.</summary>
		public event PropertyChangedEventHandler SelectedItemChanged;

		/// <summary>Gets or sets the types of items to browse.</summary>
		[DefaultValue(typeof(FolderBrowserDialogOptions), "Folders"), Localizable(false), Category("Behavior"),
		 Description("The types of items to browse")]
		public FolderBrowserDialogOptions BrowseOption
		{
			get => browseOption; set
			{
				if (browseOption != value)
				{
					browseOption = value;
					switch (browseOption)
					{
						case FolderBrowserDialogOptions.Folders:
						case FolderBrowserDialogOptions.FoldersAndFiles:
							if (RootFolder == defaultComputersFolder || RootFolder == defaultPrintersFolder)
								RootFolder = defaultFolderFolder;
							break;
						case FolderBrowserDialogOptions.Computers:
							RootFolder = defaultComputersFolder;
							break;
						case FolderBrowserDialogOptions.Printers:
							RootFolder = defaultPrintersFolder;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
			}
		}

		/// <summary>Gets or sets the caption of the dialog box.</summary>
		[DefaultValue(""), Category("Appearance"), Localizable(true), Description("Caption of the dialog box.")]
		public string Caption { get; set; } = "";

		/// <summary>Gets or sets the description shown to the user.</summary>
		[DefaultValue(""), Category("Appearance"), Localizable(true), Description("Description shown to the user.")]
		public string Description { get; set; } = "";

		/// <summary>Gets or sets whether to automatically expand the tree when shown.</summary>
		[DefaultValue(true), Localizable(false), Category("Behavior"), Description("Whether to automatically expand the tree when shown.")]
		public bool Expanded { get; set; } = true;

		/// <summary>Gets or sets whether to hide network folders below the domain level in the tree.</summary>
		[DefaultValue(false), Localizable(false), Category("Behavior"), Description("Whether to hide network folders below the domain.")]
		public bool HideDomainFolders { get; set; }

		/// <summary>Gets or sets whether to return only file system folders.</summary>
		[DefaultValue(false), Localizable(false), Category("Behavior"), Description("Whether to return only file system folders.")]
		public bool LocalFileSystemOnly { get; set; }

		/// <summary>Gets or sets the text on the OK button.</summary>
		[DefaultValue(""), Category("Appearance"), Localizable(true), Description("Text on the OK button.")]
		public string OkText { get; set; } = "";

		/// <summary>Gets or sets the root folder.</summary>
		[Localizable(false), Category("Data"), Description("Root folder of tree."), DefaultValue(defaultFolderFolder)]
		public KnownFolder RootFolder
		{
			get => rootFolder; set
			{
				rootFolder = value;
				try { rootPidl = ((KNOWNFOLDERID)RootFolder).PIDL(); }
				catch
				{
					System.Diagnostics.Debug.WriteLine($"The known folder '{RootFolder}' is not supported for this OS or application configuration.");
					ResetRootFolder();
				}
			}
		}

		/// <summary>Gets or sets the PIDL associated with the root folder. This can be used to specify a non-known folder as the root.</summary>
		/// <value>The root folder's PIDL.</value>
		[DefaultValue(0), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		// ReSharper disable once InconsistentNaming
		public PIDL RootFolderPIDL
		{
			get => rootPidl; set
			{
				rootPidl = value;
				rootFolder = KnownFolder.Undefined;
			}
		}

		/// <summary>Gets the path or name of the folder selected by the user.</summary>
		[DefaultValue(""), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string SelectedItem { get; private set; } = "";

		/// <summary>Gets the image from the system image list associated with the selected item.</summary>
		/// <value>The selected item's image.</value>
		[DefaultValue(null), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Icon SelectedItemImage => SelectedItemPIDL.GetIcon(IconSize.Small);

		/// <summary>Gets the PIDL associated with the selected item.</summary>
		/// <value>The selected item's PIDL.</value>
		[DefaultValue(0), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		// ReSharper disable once InconsistentNaming
		public PIDL SelectedItemPIDL { get; private set; }

		/// <summary>Gets or sets whether or not to show file junctions, such as a library or compressed file. This only is available in Windows 7 and later.</summary>
		[DefaultValue(false), Localizable(false), Category("Behavior"), Description("Whether or not to show file junctions.")]
		public bool ShowFileJunctions { get; set; }

		/// <summary>Gets or sets whether or not to show an edit box for the folder path.</summary>
		[DefaultValue(false), Localizable(false), Category("Behavior"), Description("Whether or not to show an edit box for the folder.")]
		public bool ShowFolderPathEditBox { get; set; }

		/// <summary>Gets or sets whether or not to show the new folder button.</summary>
		[DefaultValue(false), Localizable(false), Category("Behavior"), Description("Whether or not to show the new folder button.")]
		public bool ShowNewFolderButton { get; set; }

		/// <summary>When overridden in a derived class, resets the properties of a common dialog box to their default values.</summary>
		public override void Reset()
		{
			BrowseOption = FolderBrowserDialogOptions.Folders;
			Caption = Description = OkText = SelectedItem = string.Empty;
			Expanded = true;
			RootFolder = defaultFolderFolder;
			HideDomainFolders = ShowFileJunctions = LocalFileSystemOnly = ShowFolderPathEditBox = ShowNewFolderButton = initialized = false;
			SelectedItemPIDL = null;
		}

		/// <summary>Shows the dialog box to let the user browse for and select a folder.</summary>
		/// <param name="parentWindowHandle">The HWND of the parent window.</param>
		/// <returns>The selected folder or <c>null</c> if no folder was selected by the user.</returns>
		protected override bool RunDialog(IntPtr parentWindowHandle)
		{
			// Setup BROWSEINFO.dwFlag value
			EnumFlagIndexer<BrowseInfoFlag> browseInfoFlag = BrowseInfoFlag.BIF_SHAREABLE;
			browseInfoFlag[BrowseInfoFlag.BIF_NEWDIALOGSTYLE] = Application.OleRequired() == ApartmentState.STA;
			browseInfoFlag[BrowseInfoFlag.BIF_DONTGOBELOWDOMAIN] = HideDomainFolders;
			browseInfoFlag[BrowseInfoFlag.BIF_BROWSEFILEJUNCTIONS] = ShowFileJunctions;
			browseInfoFlag[BrowseInfoFlag.BIF_RETURNONLYFSDIRS] = LocalFileSystemOnly;
			browseInfoFlag[BrowseInfoFlag.BIF_NONEWFOLDERBUTTON] = !ShowNewFolderButton;
			browseInfoFlag[BrowseInfoFlag.BIF_EDITBOX | BrowseInfoFlag.BIF_VALIDATE] = ShowFolderPathEditBox;
			switch (BrowseOption)
			{
				case FolderBrowserDialogOptions.Folders:
					break;
				case FolderBrowserDialogOptions.FoldersAndFiles:
					browseInfoFlag |= BrowseInfoFlag.BIF_BROWSEINCLUDEFILES;
					break;
				case FolderBrowserDialogOptions.Computers:
					browseInfoFlag |= BrowseInfoFlag.BIF_BROWSEFORCOMPUTER;
					RootFolder = defaultComputersFolder;
					break;
				case FolderBrowserDialogOptions.Printers:
					browseInfoFlag |= BrowseInfoFlag.BIF_BROWSEFORPRINTER;
					RootFolder = defaultPrintersFolder;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			// Setup the BROWSEINFO structure
			var dn = new SafeCoTaskMemString(MAX_PATH);
			var bi = new BROWSEINFO(parentWindowHandle, rootPidl.DangerousGetHandle(), Description, browseInfoFlag, OnBrowseEvent, dn);

			// Show the dialog
			SelectedItemPIDL = SHBrowseForFolder(ref bi);
			if (SelectedItemPIDL.IsInvalid) return false;
			if (browseInfoFlag[BrowseInfoFlag.BIF_BROWSEFORPRINTER] || browseInfoFlag[BrowseInfoFlag.BIF_BROWSEFORCOMPUTER])
				SelectedItem = bi.DisplayName;
			else
				SelectedItem = GetNameForPidl(SelectedItemPIDL);
			return true;
		}

		/// <summary>Enables or disables the OK button in the dialog box.</summary>
		/// <param name="hwnd">The hwnd of the dialog box.</param>
		/// <param name="isEnabled">Whether or not the OK button should be enabled.</param>
		private static void EnableOk(HWND hwnd, bool isEnabled) => SendMessage(hwnd, (uint)BrowseForFolderMessages.BFFM_ENABLEOK, (IntPtr)0, (IntPtr)(isEnabled ? 1 : 0));

		private static string GetNameForPidl(PIDL pidl)
		{
			SafeCoTaskMemHandle mStr;
			try { SHGetNameFromIDList(pidl, SIGDN.SIGDN_FILESYSPATH, out mStr); return mStr.ToString(-1); } catch { }
			try { SHGetNameFromIDList(pidl, SIGDN.SIGDN_DESKTOPABSOLUTEEDITING, out mStr); return mStr.ToString(-1); } catch { }
			try { SHGetNameFromIDList(pidl, SIGDN.SIGDN_NORMALDISPLAY, out mStr); return mStr.ToString(-1); } catch { }
			return string.Empty;
		}

		private static Icon GetSystemImageListIcon(int idx)
		{
			// Test first for overridden icon images
			var regVal = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", idx.ToString(), null);
			if (regVal != null)
				return ResourceFile.GetResourceIcon(regVal.ToString());

			// Get the image from the system image list
			try
			{
				return IconExtension.GetSystemIcon(System.IO.Path.GetPathRoot(Environment.SystemDirectory), IconSize.Small);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>Callback for Windows.</summary>
		/// <param name="hwnd">Window handle of the browse dialog box.</param>
		/// <param name="uMsg">Dialog box event that generated the statusMessage.</param>
		/// <param name="lParam">Value whose meaning depends on the event specified in uMsg.</param>
		/// <param name="lpData">Application-defined value that was specified in the lParam member of the BROWSEINFO structure used in the call to SHBrowseForFolder.</param>
		/// <returns>
		/// Returns 0 except in the case of BFFM_VALIDATEFAILED. For that flag, returns 0 to dismiss the dialog or nonzero to keep the dialog displayed.
		/// </returns>
		//[CLSCompliant(false)]
		private int OnBrowseEvent(HWND hwnd, BrowseForFolderMessages uMsg, IntPtr lParam, IntPtr lpData)
		{
			var messsage = uMsg;
			switch (messsage)
			{
				case BrowseForFolderMessages.BFFM_INITIALIZED:
					// Dialog is being initialized, so set the initial parameters
					if (!string.IsNullOrEmpty(Caption))
						SetWindowText(hwnd, Caption);

					if (!string.IsNullOrEmpty(SelectedItem))
						SendMessage(hwnd, (uint)BrowseForFolderMessages.BFFM_SETSELECTIONW, (IntPtr)1, SelectedItem);

					if (Expanded)
						SendMessage(hwnd, (uint)BrowseForFolderMessages.BFFM_SETEXPANDED, (IntPtr)1, rootPidl.DangerousGetHandle());

					if (!string.IsNullOrEmpty(OkText))
						SendMessage(hwnd, (uint)BrowseForFolderMessages.BFFM_SETOKTEXT, (IntPtr)0, OkText);

					Initialized?.Invoke(this, new FolderBrowserDialogInitializedEventArgs(hwnd));
					initialized = true;
					return 0;

				case BrowseForFolderMessages.BFFM_SELCHANGED:
					try
					{
						if (!initialized || SelectedItemPIDL?.DangerousGetHandle() == lParam) return 0;
						var tmpPidl = new PIDL(lParam, false, false);
						var str = GetNameForPidl(tmpPidl);
						if (string.IsNullOrEmpty(str))
							return 0;
						SelectedItem = str;
						SelectedItemPIDL = tmpPidl;
					}
					catch
					{
						return 0;
					}

					SelectedItemChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
					return 0;

				case BrowseForFolderMessages.BFFM_VALIDATEFAILEDA:
				case BrowseForFolderMessages.BFFM_VALIDATEFAILEDW:
					if (InvalidFolderSelected != null)
					{
						var folderName = messsage == BrowseForFolderMessages.BFFM_VALIDATEFAILEDA ? Marshal.PtrToStringAnsi(lParam) : Marshal.PtrToStringUni(lParam);
						var e = new InvalidFolderEventArgs(folderName, true);
						InvalidFolderSelected?.Invoke(this, e);
						return e.DismissDialog ? 0 : 1;
					}
					return 0;

				default:
					return 0;
			}
		}

		private void ResetRootFolder()
		{
			switch (BrowseOption)
			{
				case FolderBrowserDialogOptions.Folders:
				case FolderBrowserDialogOptions.FoldersAndFiles:
					RootFolder = defaultFolderFolder;
					break;
				case FolderBrowserDialogOptions.Computers:
					RootFolder = defaultComputersFolder;
					break;
				case FolderBrowserDialogOptions.Printers:
					RootFolder = defaultPrintersFolder;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private bool ShouldSerializeRootFolder()
		{
			switch (BrowseOption)
			{
				case FolderBrowserDialogOptions.Folders:
				case FolderBrowserDialogOptions.FoldersAndFiles:
					return RootFolder != KnownFolder.ComputerFolder;
				case FolderBrowserDialogOptions.Computers:
					return RootFolder != KnownFolder.NetworkFolder;
				case FolderBrowserDialogOptions.Printers:
					return RootFolder != KnownFolder.PrintersFolder;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}

	/// <summary>Event arguments for when the <see cref="FolderBrowserDialog"/> has been initialized.</summary>
	public class FolderBrowserDialogInitializedEventArgs : EventArgs
	{
		/// <summary>The HWND of the dialog box.</summary>
		public readonly HWND hwnd;

		/// <summary>Initializes a new instance of the <see cref="FolderBrowserDialogInitializedEventArgs"/> class.</summary>
		/// <param name="hwnd">The HWND of the dialog box.</param>
		public FolderBrowserDialogInitializedEventArgs(HWND hwnd) { this.hwnd = hwnd; }
	}

	/// <summary>Event arguments for when an invalid folder is selected.</summary>
	public class InvalidFolderEventArgs : EventArgs
	{
		/// <summary>Constructs an instance.</summary>
		/// <param name="folderName">The name of the invalid folder.</param>
		/// <param name="dismissDialog">Whether or not to dismiss the dialog.</param>
		public InvalidFolderEventArgs(string folderName, bool dismissDialog)
		{
			FolderName = folderName;
			DismissDialog = dismissDialog;
		}

		/// <summary>Gets or sets whether or not to dismiss the dialog box.</summary>
		public bool DismissDialog { get; set; }

		/// <summary>Gets the name of the invalid folder.</summary>
		public string FolderName { get; }
	}
}