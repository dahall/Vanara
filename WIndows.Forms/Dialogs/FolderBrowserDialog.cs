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
	public enum KnownFolders
	{
		/// <summary>Account Pictures</summary>
		AccountPictures,

		/// <summary>Get Programs</summary>
		AddNewPrograms,

		/// <summary>Administration Tools</summary>
		AdminTools,

		/// <summary>Application Shortcuts</summary>
		ApplicationShortcuts,

		/// <summary>Applications</summary>
		AppsFolder,

		/// <summary>Installed Updates</summary>
		AppUpdates,

		/// <summary>Camera Roll</summary>
		CameraRoll,

		/// <summary>Temporary Burn Folder</summary>
		CDBurning,

		/// <summary>Programs and Features</summary>
		ChangeRemovePrograms,

		/// <summary>Administrative Tools</summary>
		CommonAdminTools,

		/// <summary>OEM Links</summary>
		CommonOEMLinks,

		/// <summary>Programs</summary>
		CommonPrograms,

		/// <summary>Start Menu</summary>
		CommonStartMenu,

		/// <summary>Startup</summary>
		CommonStartup,

		/// <summary>Templates</summary>
		CommonTemplates,

		/// <summary>Computer</summary>
		ComputerFolder,

		/// <summary>Conflicts</summary>
		ConflictFolder,

		/// <summary>Network Connections</summary>
		ConnectionsFolder,

		/// <summary>Contacts</summary>
		Contacts,

		/// <summary>Control Panel</summary>
		ControlPanelFolder,

		/// <summary>Cookies</summary>
		Cookies,

		/// <summary>Desktop</summary>
		Desktop,

		/// <summary>DeviceMetadataStore</summary>
		DeviceMetadataStore,

		/// <summary>Documents</summary>
		Documents,

		/// <summary>Documents</summary>
		DocumentsLibrary,

		/// <summary>Downloads</summary>
		Downloads,

		/// <summary>Favorites</summary>
		Favorites,

		/// <summary>Fonts</summary>
		Fonts,

		/// <summary>Games</summary>
		Games,

		/// <summary>GameExplorer</summary>
		GameTasks,

		/// <summary>History</summary>
		History,

		/// <summary>Homegroup</summary>
		HomeGroup,

		/// <summary>The user's username (%USERNAME%)</summary>
		HomeGroupCurrentUser,

		/// <summary>ImplicitAppShortcuts</summary>
		ImplicitAppShortcuts,

		/// <summary>Temporary Internet Files</summary>
		InternetCache,

		/// <summary>The Internet</summary>
		InternetFolder,

		/// <summary>Libraries</summary>
		Libraries,

		/// <summary>Links</summary>
		Links,

		/// <summary>Local</summary>
		LocalAppData,

		/// <summary>LocalLow</summary>
		LocalAppDataLow,

		/// <summary>None</summary>
		LocalizedResourcesDir,

		/// <summary>Music</summary>
		Music,

		/// <summary>Music</summary>
		MusicLibrary,

		/// <summary>Network Shortcuts</summary>
		NetHood,

		/// <summary>Network</summary>
		NetworkFolder,

		/// <summary>Original Images</summary>
		OriginalImages,

		/// <summary>Slide Shows</summary>
		PhotoAlbums,

		/// <summary>Pictures</summary>
		PicturesLibrary,

		/// <summary>Pictures</summary>
		Pictures,

		/// <summary>Playlists</summary>
		Playlists,

		/// <summary>Printers</summary>
		PrintersFolder,

		/// <summary>Printer Shortcuts</summary>
		PrintHood,

		/// <summary>The user's username (%USERNAME%)</summary>
		Profile,

		/// <summary>ProgramData</summary>
		ProgramData,

		/// <summary>Program Files</summary>
		ProgramFiles,

		/// <summary>Program Files</summary>
		ProgramFilesX64,

		/// <summary>Program Files</summary>
		ProgramFilesX86,

		/// <summary>Common Files</summary>
		ProgramFilesCommon,

		/// <summary>Common Files</summary>
		ProgramFilesCommonX64,

		/// <summary>Common Files</summary>
		ProgramFilesCommonX86,

		/// <summary>Programs</summary>
		Programs,

		/// <summary>Public</summary>
		Public,

		/// <summary>Public Desktop</summary>
		PublicDesktop,

		/// <summary>Public Documents</summary>
		PublicDocuments,

		/// <summary>Public Downloads</summary>
		PublicDownloads,

		/// <summary>GameExplorer</summary>
		PublicGameTasks,

		/// <summary>Libraries</summary>
		PublicLibraries,

		/// <summary>Public Music</summary>
		PublicMusic,

		/// <summary>Public Pictures</summary>
		PublicPictures,

		/// <summary>Ringtones</summary>
		PublicRingtones,

		/// <summary>Public Account Pictures</summary>
		PublicUserTiles,

		/// <summary>Public Videos</summary>
		PublicVideos,

		/// <summary>Quick Launch</summary>
		QuickLaunch,

		/// <summary>Recent Items</summary>
		Recent,

		/// <summary>Recorded TV</summary>
		RecordedTVLibrary,

		/// <summary>Recycle Bin</summary>
		RecycleBinFolder,

		/// <summary>Resources</summary>
		ResourceDir,

		/// <summary>Ringtones</summary>
		Ringtones,

		/// <summary>Roaming</summary>
		RoamingAppData,

		/// <summary>RoamedTileImages</summary>
		RoamedTileImages,

		/// <summary>RoamingTiles</summary>
		RoamingTiles,

		/// <summary>Sample Music</summary>
		SampleMusic,

		/// <summary>Sample Pictures</summary>
		SamplePictures,

		/// <summary>Sample Playlists</summary>
		SamplePlaylists,

		/// <summary>Sample Videos</summary>
		SampleVideos,

		/// <summary>Saved Games</summary>
		SavedGames,

		/// <summary>Saved Pictures</summary>
		SavedPictures,

		/// <summary>Saved Pictures Library</summary>
		SavedPicturesLibrary,

		/// <summary>Searches</summary>
		SavedSearches,

		/// <summary>Screenshots</summary>
		Screenshots,

		/// <summary>Offline Files</summary>
		OfflineFiles,

		/// <summary>History</summary>
		SearchHistory,

		/// <summary>Search Results</summary>
		SearchHome,

		/// <summary>Microsoft Office Outlook</summary>
		MicrosoftOfficeOutlook,

		/// <summary>Templates</summary>
		SearchTemplates,

		/// <summary>SendTo</summary>
		SendTo,

		/// <summary>Gadgets</summary>
		SidebarDefaultParts,

		/// <summary>Gadgets</summary>
		SidebarParts,

		/// <summary>OneDrive</summary>
		SkyDrive,

		/// <summary>Camera Roll</summary>
		SkyDriveCameraRoll,

		/// <summary>Documents</summary>
		SkyDriveDocuments,

		/// <summary>Pictures</summary>
		SkyDrivePictures,

		/// <summary>Start Menu</summary>
		StartMenu,

		/// <summary>Startup</summary>
		Startup,

		/// <summary>Sync Center</summary>
		SyncManagerFolder,

		/// <summary>Sync Results</summary>
		SyncResultsFolder,

		/// <summary>Sync Setup</summary>
		SyncSetupFolder,

		/// <summary>System32</summary>
		System,

		/// <summary>System32</summary>
		SystemX86,

		/// <summary>Templates</summary>
		Templates,

		/// <summary>User Pinned</summary>
		UserPinned,

		/// <summary>Users</summary>
		UserProfiles,

		/// <summary>Programs</summary>
		UserProgramFiles,

		/// <summary>Programs</summary>
		UserProgramFilesCommon,

		/// <summary>The user's full name (for instance, Jean Philippe Bagel) entered when the user account was created.</summary>
		UsersFiles,

		/// <summary>Libraries</summary>
		UsersLibraries,

		/// <summary>Videos</summary>
		Videos,

		/// <summary>Videos</summary>
		VideosLibrary,

		/// <summary>Windows</summary>
		Windows,

		/// <summary>Undefined</summary>
		Undefined = 0xFFFF,
	}

	/// <summary>Class to let the user browse for a folder.</summary>
	[ToolboxBitmap(typeof(FolderBrowserDialog), "Dialog"), Description("Dialog that browses network computers.")]
	public class FolderBrowserDialog : CommonDialog
	{
		private const KnownFolders defaultComputersFolder = KnownFolders.NetworkFolder;
		private const KnownFolders defaultFolderFolder = KnownFolders.ComputerFolder;
		private const KnownFolders defaultPrintersFolder = KnownFolders.PrintersFolder;

		private static IImageList sysImgList;
		private FolderBrowserDialogOptions browseOption;
		private HandleRef href;
		private bool initialized;
		private PIDL pidl;
		private KnownFolders rootFolder;
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
		public KnownFolders RootFolder
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
				rootFolder = KnownFolders.Undefined;
			}
		}

		/// <summary>Gets or sets the item selected by the user. The initially selected item if set before the dialog box is shown.</summary>
		[DefaultValue(""), Category("Data"), Localizable(true), Description("Item selected in the dialog box.")]
		public string SelectedItem { get; set; } = "";

		/// <summary>Gets the image from the system image list associated with the selected item.</summary>
		/// <value>The selected item's image.</value>
		[DefaultValue(null), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Icon SelectedItemImage => pidl.GetIcon(true);

		/// <summary>Gets the PIDL associated with the selected item.</summary>
		/// <value>The selected item's PIDL.</value>
		[DefaultValue(0), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		// ReSharper disable once InconsistentNaming
		public PIDL SelectedItemPIDL => pidl;

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
			pidl = null;
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
			pidl = SHBrowseForFolder(ref bi);
			href = default(HandleRef);
			if (pidl.IsInvalid) return false;
			if (browseInfoFlag[BrowseInfoFlag.BIF_BROWSEFORPRINTER] || browseInfoFlag[BrowseInfoFlag.BIF_BROWSEFORCOMPUTER])
				SelectedItem = bi.DisplayName;
			else
				SelectedItem = GetNameForPidl(pidl);
			return true;
		}

		/// <summary>Enables or disables the OK button in the dialog box.</summary>
		/// <param name="hwnd">The hwnd of the dialog box.</param>
		/// <param name="isEnabled">Whether or not the OK button should be enabled.</param>
		private static void EnableOk(HandleRef hwnd, bool isEnabled) { SendMessage(hwnd, (uint)BrowseForFolderMessages.BFFM_ENABLEOK, (IntPtr)0, (IntPtr)(isEnabled ? 1 : 0)); }

		private static string GetNameForPidl(PIDL pidl)
		{
			SafeCoTaskMemHandle mStr;
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
				if (sysImgList == null)
				{
					var shfi = new SHFILEINFO();
					var ptr = SHGetFileInfo(System.IO.Path.GetPathRoot(Environment.SystemDirectory), 0, ref shfi, Marshal.SizeOf(shfi),
						SHGFI.SHGFI_SYSICONINDEX | SHGFI.SHGFI_SMALLICON);
					sysImgList = (IImageList)Marshal.GetTypedObjectForIUnknown(ptr, typeof(IImageList));
				}
				var hIcon = sysImgList.GetIcon(idx, IMAGELISTDRAWFLAGS.ILD_TRANSPARENT);
				var ico = (Icon)Icon.FromHandle(hIcon).Clone();
				DestroyIcon(hIcon);
				return ico;
			}
			catch { }

			return null;
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
		private int OnBrowseEvent(IntPtr hwnd, BrowseForFolderMessages uMsg, IntPtr lParam, IntPtr lpData)
		{
			var messsage = uMsg;
			href = new HandleRef(this, hwnd);
			switch (messsage)
			{
				case BrowseForFolderMessages.BFFM_INITIALIZED:
					// Dialog is being initialized, so set the initial parameters
					if (!string.IsNullOrEmpty(Caption))
						SetWindowText(href, Caption);

					if (!string.IsNullOrEmpty(SelectedItem))
						SendMessage(href, (uint)BrowseForFolderMessages.BFFM_SETSELECTIONW, (IntPtr)1, SelectedItem);

					if (Expanded)
						SendMessage(href, (uint)BrowseForFolderMessages.BFFM_SETEXPANDED, (IntPtr)1, rootPidl.DangerousGetHandle());

					if (!string.IsNullOrEmpty(OkText))
						SendMessage(href, (uint)BrowseForFolderMessages.BFFM_SETOKTEXT, (IntPtr)0, OkText);

					Initialized?.Invoke(this, new FolderBrowserDialogInitializedEventArgs(hwnd));
					initialized = true;
					return 0;

				case BrowseForFolderMessages.BFFM_SELCHANGED:
					try
					{
						if (!initialized || pidl?.DangerousGetHandle() == lParam) return 0;
						var tmpPidl = new PIDL(lParam, false, false);
						var str = GetNameForPidl(tmpPidl);
						if (string.IsNullOrEmpty(str))
							return 0;
						SelectedItem = str;
						pidl = tmpPidl;
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
					return RootFolder != KnownFolders.ComputerFolder;
				case FolderBrowserDialogOptions.Computers:
					return RootFolder != KnownFolders.NetworkFolder;
				case FolderBrowserDialogOptions.Printers:
					return RootFolder != KnownFolders.PrintersFolder;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}

	/// <summary>Event arguments for when the <see cref="FolderBrowserDialog"/> has been initialized.</summary>
	public class FolderBrowserDialogInitializedEventArgs : EventArgs
	{
		/// <summary>The HWND of the dialog box.</summary>
		public readonly IntPtr hwnd;

		/// <summary>Initializes a new instance of the <see cref="FolderBrowserDialogInitializedEventArgs"/> class.</summary>
		/// <param name="hwnd">The HWND of the dialog box.</param>
		public FolderBrowserDialogInitializedEventArgs(IntPtr hwnd) { this.hwnd = hwnd; }
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