using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Extensions
{
	/// <summary>Extension methods to get attribute information from a ControlPanelItem value.</summary>
	public static class ControlPanelItemExtensions
	{
		/// <summary>Gets the canonical name for a Control Panel item.</summary>
		/// <param name="cp">The <see cref="ControlPanelItem"/> value.</param>
		/// <returns>The canonical name.</returns>
		/// <exception cref="InvalidOperationException">No information exists for the <see cref="ControlPanelItem"/> value.</exception>
		public static string CanonicalName(this ControlPanelItem cp) => GetAttr(cp)?.CanonicalName ?? throw new InvalidOperationException();

		/// <summary>Gets the GUID for a Control Panel item.</summary>
		/// <param name="cp">The <see cref="ControlPanelItem"/> value.</param>
		/// <returns>The GUID.</returns>
		/// <exception cref="InvalidOperationException">No information exists for the <see cref="ControlPanelItem"/> value.</exception>
		public static Guid Guid(this ControlPanelItem cp) => GetAttr(cp)?.Guid ?? throw new InvalidOperationException();

		/// <summary>Gets the minimum Windows client for a Control Panel item.</summary>
		/// <param name="cp">The <see cref="ControlPanelItem"/> value.</param>
		/// <returns>The minimum Windows client.</returns>
		/// <exception cref="InvalidOperationException">No information exists for the <see cref="ControlPanelItem"/> value.</exception>
		public static PInvoke.PInvokeClient MinClient(this ControlPanelItem cp) => GetAttr(cp)?.MinClient ?? throw new InvalidOperationException();

		/// <summary>Gets the module name for a Control Panel item.</summary>
		/// <param name="cp">The <see cref="ControlPanelItem"/> value.</param>
		/// <returns>The module name.</returns>
		/// <exception cref="InvalidOperationException">No information exists for the <see cref="ControlPanelItem"/> value.</exception>
		public static string ModuleName(this ControlPanelItem cp) => GetAttr(cp)?.ModuleName ?? throw new InvalidOperationException();

		/// <summary>Gets the list of valid pages for a Control Panel item.</summary>
		/// <param name="cp">The <see cref="ControlPanelItem"/> value.</param>
		/// <returns>The list of valid pages.</returns>
		/// <exception cref="InvalidOperationException">No information exists for the <see cref="ControlPanelItem"/> value.</exception>
		public static string[] ValidPages(this ControlPanelItem cp) => GetAttr(cp)?.ValidPages ?? throw new InvalidOperationException();

		private static CPAssociateAttribute GetAttr(ControlPanelItem value) => typeof(ControlPanelItem).GetField(value.ToString())?.GetCustomAttributes<CPAssociateAttribute>().FirstOrDefault();
	}
}

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>An enumeration of Control Panel items available in Windows 8.1.</summary>
		public enum ControlPanelItem
		{
			/// <summary>Action Center</summary>
			[CPAssociate("{BB64F8A7-BEE7-4E1A-AB8D-7D8273F7FDB6}", "Microsoft.ActionCenter", @"@%SystemRoot%\System32\ActionCenterCPL.dll,-1", PInvokeClient.Windows7, "MaintenanceSettings,pageProblems,pageReliabilityView,pageResponseArchive,pageSettings")]
			ActionCenter = 1,

			/// <summary>Administrative Tools</summary>
			[CPAssociate("{D20EA4E1-3957-11d2-A40B-0C5020524153}", "Microsoft.AdministrativeTools", @"@%SystemRoot%\system32\shell32.dll,-22982", PInvokeClient.WindowsVista)]
			AdministrativeTools,

			/// <summary>AutoPlay</summary>
			[CPAssociate("{9C60DE1E-E5FC-40f4-A487-460851A8D915}", "Microsoft.AutoPlay", @"@%SystemRoot%\System32\autoplay.dll,-1", PInvokeClient.WindowsVista)]
			AutoPlay,

			/// <summary>Biometric Devices</summary>
			[CPAssociate("{0142e4d0-fb7a-11dc-ba4a-000ffe7ab428}", "Microsoft.BiometricDevices", @"@%SystemRoot%\System32\biocpl.dll,-1", PInvokeClient.Windows7)]
			BiometricDevices,

			/// <summary>BitLocker Drive Encryption</summary>
			[CPAssociate("{D9EF8727-CAC2-4e60-809E-86F80A666C91}", "Microsoft.BitLockerDriveEncryption", @"@%SystemRoot%\System32\fvecpl.dll,-1", PInvokeClient.WindowsVista)]
			BitLockerDriveEncryption,

			/// <summary>Color Management</summary>
			[CPAssociate("{B2C761C6-29BC-4f19-9251-E6195265BAF1}", "Microsoft.ColorManagement", @"@%systemroot%\system32\colorcpl.exe,-6", PInvokeClient.WindowsVista)]
			ColorManagement,

			/// <summary>Credential Manager</summary>
			[CPAssociate("{1206F5F1-0569-412C-8FEC-3204630DFB70}", "Microsoft.CredentialManager", @"@%SystemRoot%\system32\Vault.dll,-1", PInvokeClient.Windows7, "?SelectedVault=CredmanVault")]
			CredentialManager,

			/// <summary>Date and Time</summary>
			[CPAssociate("{E2E7934B-DCE5-43C4-9576-7FE4F75E7480}", "Microsoft.DateAndTime", @"@%SystemRoot%\System32\timedate.cpl,-51", PInvokeClient.WindowsVista, "1")]
			DateAndTime,

			/// <summary>Default Programs</summary>
			[CPAssociate("{17cd9488-1228-4b2f-88ce-4298e93e0966}", "Microsoft.DefaultPrograms", @"@%SystemRoot%\System32\sud.dll,-1", PInvokeClient.WindowsVista, "pageDefaultProgram,pageFileAssoc")]
			DefaultPrograms,

			/// <summary>Device Manager</summary>
			[CPAssociate("{74246bfc-4c96-11d0-abef-0020af6b0b7a}", "Microsoft.DeviceManager", @"@%SystemRoot%\System32\devmgr.dll,-4", PInvokeClient.WindowsVista)]
			DeviceManager,

			/// <summary>Devices and Printers</summary>
			[CPAssociate("{A8A91A66-3A7D-4424-8D24-04E180695C7A}", "Microsoft.DevicesAndPrinters", @"@%systemroot%\system32\DeviceCenter.dll,-1000", PInvokeClient.Windows7)]
			DevicesAndPrinters,

			/// <summary>Display</summary>
			[CPAssociate("{C555438B-3C23-4769-A71F-B6D3D9B6053A}", "Microsoft.Display", @"@%SystemRoot%\System32\Display.dll,-1", PInvokeClient.Windows7, "Settings")]
			Display,

			/// <summary>Ease of Access Center</summary>
			[CPAssociate("{D555645E-D4F8-4c29-A827-D93C859C4F2A}", "Microsoft.EaseOfAccessCenter", @"@%SystemRoot%\System32\accessibilitycpl.dll,-10", PInvokeClient.WindowsVista, "pageEasierToClick,pageEasierToSee,pageEasierWithSounds,pageFilterKeysSettings,pageKeyboardEasierToUse,pageNoMouseOrKeyboard,pageNoVisual,pageQuestionsCognitive,pageQuestionsEyesight")]
			EaseOfAccessCenter,

			/// <summary>Family Safety</summary>
			[CPAssociate("{96AE8D84-A250-4520-95A5-A47A7E3C548B}", "Microsoft.ParentalControls", @"@%SystemRoot%\System32\wpccpl.dll,-100", PInvokeClient.WindowsVista, "pageUserHub")]
			ParentalControls,

			/// <summary>File History</summary>
			[CPAssociate("{F6B6E965-E9B2-444B-9286-10C9152EDBC5}", "Microsoft.FileHistory", @"@%SystemRoot%\System32\fhcpl.dll,-52", PInvokeClient.Windows8)]
			FileHistory,

			/// <summary>Folder Options</summary>
			[CPAssociate("{6DFD7C5C-2451-11d3-A299-00C04F8EF6AF}", "Microsoft.FolderOptions", @"@%SystemRoot%\system32\shell32.dll,-22985", PInvokeClient.WindowsVista)]
			FolderOptions,

			/// <summary>Fonts</summary>
			[CPAssociate("{93412589-74D4-4E4E-AD0E-E0CB621440FD}", "Microsoft.Fonts", @"@%SystemRoot%\System32\FontExt.dll,-8007", PInvokeClient.WindowsVista)]
			Fonts,

			/// <summary>HomeGroup</summary>
			[CPAssociate("{67CA7650-96E6-4FDD-BB43-A8E774F73A57}", "Microsoft.HomeGroup", @"@%SystemRoot%\System32\hgcpl.dll,-1", PInvokeClient.Windows7)]
			HomeGroup,

			/// <summary>Indexing Options</summary>
			[CPAssociate("{87D66A43-7B11-4A28-9811-C86EE395ACF7}", "Microsoft.IndexingOptions", @"@%SystemRoot%\System32\srchadmin.dll,-601", PInvokeClient.WindowsVista)]
			IndexingOptions,

			/// <summary>Infrared</summary>
			[CPAssociate("{A0275511-0E86-4ECA-97C2-ECD8F1221D08}", "Microsoft.Infrared", @"@%SystemRoot%\System32\irprops.cpl,-1", PInvokeClient.Windows7)]
			Infrared,

			/// <summary>Internet Options</summary>
			[CPAssociate("{A3DD4F92-658A-410F-84FD-6FBBBEF2FFFE}", "Microsoft.InternetOptions", @"@C:\Windows\System32\inetcpl.cpl,-4312", PInvokeClient.WindowsVista, "1,2,3,4,5,6")]
			InternetOptions,

			/// <summary>iSCSI Initiator</summary>
			[CPAssociate("{A304259D-52B8-4526-8B1A-A1D6CECC8243}", "Microsoft.iSCSIInitiator", @"@%SystemRoot%\System32\iscsicpl.dll,-5001", PInvokeClient.WindowsVista)]
			iSCSIInitiator,

			/// <summary>iSNS Server</summary>
			[CPAssociate("{0D2A3442-5181-4E3A-9BD4-83BD10AF3D76}", "Microsoft.iSNSServer", @"@%SystemRoot%\System32\isnssrv.dll,-5005", PInvokeClient.WindowsVista)]
			iSNSServer,

			/// <summary>Keyboard</summary>
			[CPAssociate("{725BE8F7-668E-4C7B-8F90-46BDB0936430}", "Microsoft.Keyboard", @"@%SystemRoot%\System32\main.cpl,-102", PInvokeClient.WindowsVista)]
			Keyboard,

			/// <summary>Language</summary>
			[CPAssociate("{BF782CC9-5A52-4A17-806C-2A894FFEEAC5}", "Microsoft.Language", @"@%SystemRoot%\System32\UserLanguagesCpl.dll,-1", PInvokeClient.Windows8)]
			Language,

			/// <summary>Location Settings</summary>
			[CPAssociate("{E9950154-C418-419e-A90A-20C5287AE24B}", "Microsoft.LocationSettings", @"@%SystemRoot%\System32\SensorsCpl.dll,-1", PInvokeClient.Windows8)]
			LocationSettings,

			/// <summary>Mouse</summary>
			[CPAssociate("{6C8EEC18-8D75-41B2-A177-8831D59D2D50}", "Microsoft.Mouse", @"@%SystemRoot%\System32\main.cpl,-100", PInvokeClient.WindowsVista, "1,2,3,4")]
			Mouse,

			/// <summary>MPIOConfiguration</summary>
			[CPAssociate("{AB3BE6AA-7561-4838-AB77-ACF8427DF426}", "Microsoft.MPIOConfiguration", @"@%SystemRoot%\System32\mpiocpl.dll,-1000", PInvokeClient.Windows7)]
			MPIOConfiguration,

			/// <summary>Network and Sharing Center</summary>
			[CPAssociate("{8E908FC9-BECC-40f6-915B-F4CA0E70D03D}", "Microsoft.NetworkAndSharingCenter", @"@%SystemRoot%\System32\netcenter.dll,-1", PInvokeClient.WindowsVista, "Advanced,ShareMedia")]
			NetworkAndSharingCenter,

			/// <summary>Notification Area Icons</summary>
			[CPAssociate("{05d7b0f4-2121-4eff-bf6b-ed3f69b894d9}", "Microsoft.NotificationAreaIcons", @"@%SystemRoot%\System32\taskbarcpl.dll,-1", PInvokeClient.Windows7)]
			NotificationAreaIcons,

			/// <summary>Pen and Touch</summary>
			[CPAssociate("{F82DF8F7-8B9F-442E-A48C-818EA735FF9B}", "Microsoft.PenAndTouch", @"@%SystemRoot%\System32\tabletpc.cpl,-10103", PInvokeClient.Windows7, "1,2")]
			PenAndTouch,

			/// <summary>Personalization</summary>
			[CPAssociate("{ED834ED6-4B5A-4bfe-8F11-A626DCB6A921}", "Microsoft.Personalization", @"@%SystemRoot%\System32\themecpl.dll,-1", PInvokeClient.WindowsVista, "pageColorization,pageWallpaper")]
			Personalization,

			/// <summary>Phone and Modem</summary>
			[CPAssociate("{40419485-C444-4567-851A-2DD7BFA1684D}", "Microsoft.PhoneAndModem", @"@%SystemRoot%\System32\telephon.cpl,-1", PInvokeClient.Windows7)]
			PhoneAndModem,

			/// <summary>Power Options</summary>
			[CPAssociate("{025A5937-A6BE-4686-A844-36FE4BEC8B6D}", "Microsoft.PowerOptions", @"@%SystemRoot%\System32\powercpl.dll,-1", PInvokeClient.WindowsVista, "pageGlobalSettings,pagePlanSettings")]
			PowerOptions,

			/// <summary>Programs and Features</summary>
			[CPAssociate("{7b81be6a-ce2b-4676-a29e-eb907a5126c5}", "Microsoft.ProgramsAndFeatures", @"@%systemroot%\system32\appwiz.cpl,-159", PInvokeClient.WindowsVista, "::{D450A8A1-9568-45C7-9C0E-B4F9FB4537BD}")]
			ProgramsAndFeatures,

			/// <summary>Recovery</summary>
			[CPAssociate("{9FE63AFD-59CF-4419-9775-ABCC3849F861}", "Microsoft.Recovery", @"@%SystemRoot%\System32\recovery.dll,-101", PInvokeClient.Windows7)]
			Recovery,

			/// <summary>Region</summary>
			[CPAssociate("{62D8ED13-C9D0-4CE8-A914-47DD628FB1B0}", "Microsoft.RegionAndLanguage", @"@%SystemRoot%\System32\intl.cpl,-1", PInvokeClient.Windows7, "1,2")]
			RegionAndLanguage,

			/// <summary>RemoteApp and Desktop Connections</summary>
			[CPAssociate("{241D7C96-F8BF-4F85-B01F-E2B043341A4B}", "Microsoft.RemoteAppAndDesktopConnections", @"@%SystemRoot%\System32\tsworkspace.dll,-15300", PInvokeClient.Windows7)]
			RemoteAppAndDesktopConnections,

			/// <summary>Sound</summary>
			[CPAssociate("{F2DDFC82-8F12-4CDD-B7DC-D4FE1425AA4D}", "Microsoft.Sound", @"@%SystemRoot%\System32\mmsys.cpl,-300", PInvokeClient.Windows7)]
			Sound,

			/// <summary>Speech Recognition</summary>
			[CPAssociate("{58E3C745-D971-4081-9034-86E34B30836A}", "Microsoft.SpeechRecognition", @"@%SystemRoot%\System32\Speech\SpeechUX\speechuxcpl.dll,-1", PInvokeClient.Windows7)]
			SpeechRecognition,

			/// <summary>Storage Spaces</summary>
			[CPAssociate("{F942C606-0914-47AB-BE56-1321B8035096}", "Microsoft.StorageSpaces", @"@C:\Windows\System32\SpaceControl.dll,-1", PInvokeClient.Windows8)]
			StorageSpaces,

			/// <summary>Sync Center</summary>
			[CPAssociate("{9C73F5E5-7AE7-4E32-A8E8-8D23B85255BF}", "Microsoft.SyncCenter", @"@%SystemRoot%\System32\SyncCenter.dll,-3000", PInvokeClient.WindowsVista)]
			SyncCenter,

			/// <summary>System</summary>
			[CPAssociate("{BB06C0E4-D293-4f75-8A90-CB05B6477EEE}", "Microsoft.System", @"@%SystemRoot%\System32\systemcpl.dll,-1", PInvokeClient.WindowsVista)]
			System,

			/// <summary>Tablet PC Settings</summary>
			[CPAssociate("{80F3F1D5-FECA-45F3-BC32-752C152E456E}", "Microsoft.TabletPCSettings", @"@%SystemRoot%\System32\tabletpc.cpl,-10100", PInvokeClient.WindowsVista)]
			TabletPCSettings,

			/// <summary>Taskbar and Navigation</summary>
			[CPAssociate("{0DF44EAA-FF21-4412-828E-260A8728E7F1}", "Microsoft.Taskbar", @"@%SystemRoot%\system32\shell32.dll,-32517", PInvokeClient.Windows8)]
			Taskbar,

			/// <summary>Troubleshooting</summary>
			[CPAssociate("{C58C4893-3BE0-4B45-ABB5-A63E4B8C8651}", "Microsoft.Troubleshooting", @"@%SystemRoot%\System32\DiagCpl.dll,-1", PInvokeClient.Windows7, "HistoryPage")]
			Troubleshooting,

			/// <summary>TSAppInstall</summary>
			[CPAssociate("{BAA884F4-3432-48b8-AA72-9BF20EEF31D5}", "Microsoft.TSAppInstall", @"@%systemroot%\system32\tsappinstall.exe,-2001", PInvokeClient.Windows7)]
			TSAppInstall,

			/// <summary>User Accounts</summary>
			[CPAssociate("{60632754-c523-4b62-b45c-4172da012619}", "Microsoft.UserAccounts", @"@%SystemRoot%\System32\usercpl.dll,-1", PInvokeClient.WindowsVista)]
			UserAccounts,

			/// <summary>Windows Anytime Upgrade</summary>
			[CPAssociate("{BE122A0E-4503-11DA-8BDE-F66BAD1E3F3A}", "Microsoft.WindowsAnytimeUpgrade", @"@$(resourceString._SYS_MOD_PATH),-1", PInvokeClient.WindowsVista)]
			WindowsAnytimeUpgrade,

			/// <summary>Windows Defender</summary>
			[CPAssociate("{D8559EB9-20C0-410E-BEDA-7ED416AECC2A}", "Microsoft.WindowsDefender", @"@%ProgramFiles%\Windows Defender\MsMpRes.dll,-104", PInvokeClient.WindowsVista)]
			WindowsDefender,

			/// <summary>Windows Firewall</summary>
			[CPAssociate("{4026492F-2F69-46B8-B9BF-5654FC07E423}", "Microsoft.WindowsFirewall", @"@C:\Windows\system32\FirewallControlPanel.dll,-12122", PInvokeClient.WindowsVista, "pageConfigureApps")]
			WindowsFirewall,

			/// <summary>Windows Mobility Center</summary>
			[CPAssociate("{5ea4f148-308c-46d7-98a9-49041b1dd468}", "Microsoft.MobilityCenter", @"@%SystemRoot%\system32\mblctr.exe,-1002", PInvokeClient.WindowsVista)]
			MobilityCenter,

			/// <summary>Windows To Go</summary>
			[CPAssociate("{8E0C279D-0BD1-43C3-9EBD-31C3DC5B8A77}", "Microsoft.PortableWorkspaceCreator", @"@%SystemRoot%\System32\pwcreator.exe,-151", PInvokeClient.Windows8)]
			PortableWorkspaceCreator,

			/// <summary>Windows Update</summary>
			[CPAssociate("{36eef7db-88ad-4e81-ad49-0e313f0c35f8}", "Microsoft.WindowsUpdate", @"@%SystemRoot%\system32\wucltux.dll,-1", PInvokeClient.WindowsVista, "pageSettings,pageUpdateHistory")]
			WindowsUpdate,

			/// <summary>Work Folders</summary>
			[CPAssociate("{ECDB0924-4208-451E-8EE0-373C0956DE16}", "Microsoft.WorkFolders", @"@C:\Windows\System32\WorkfoldersControl.dll,-1", PInvokeClient.Windows8)]
			WorkFolders,
		}

		/// <summary>The most recent view.</summary>
		public enum CPVIEW
		{
			/// <summary>Classic view.</summary>
			CPVIEW_CLASSIC = 0x0,

			/// <summary>Windows 7 and later.Equivalent to CPVIEW_CLASSIC.</summary>
			CPVIEW_ALLITEMS = CPVIEW_CLASSIC,

			/// <summary>Category view.</summary>
			CPVIEW_CATEGORY = 0x1,

			/// <summary>Windows 7 and later. Equivalent to CPVIEW_CATEGORY.</summary>
			CPVIEW_HOME = 0x1,
		}

		/// <summary>
		/// Exposes methods that retrieve the view state of the Control Panel, the path of individual Control Panel items, and that open
		/// either the Control Panel itself or an individual Control Panel item.
		/// </summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("D11AD862-66DE-4DF4-BF6C-1F5621996AF1"), CoClass(typeof(OpenControlPanel))]
		[PInvokeData("Shobjidl.h")]
		public interface IOpenControlPanel
		{
			/// <summary>Opens the specified Control Panel item, optionally to a specific page.</summary>
			/// <param name="pszName">
			/// A pointer to the item's canonical name as a Unicode string. This parameter is optional and can be NULL. If the calling
			/// application passes NULL, then the Control Panel itself opens. For a complete list of Control Panel item canonical names, see
			/// Canonical Names of Control Panel Items.
			/// </param>
			/// <param name="page">
			/// A pointer to the name of the page within the item to display. This string is appended to the end of the path for Shell folder
			/// Control Panel items or appended as a command-line parameter for Control Panel (.cpl) file items. This parameter can be NULL,
			/// in which case the first page is shown.
			/// </param>
			/// <param name="punkSite">
			/// A pointer to the site for navigating in-frame for Shell folder Control Panel items. This parameter can be NULL.
			/// </param>
			void Open([MarshalAs(UnmanagedType.LPWStr)] string pszName, [MarshalAs(UnmanagedType.LPWStr)] string page, [MarshalAs(UnmanagedType.IUnknown)] object punkSite);

			/// <summary>Gets the path of a specified Control Panel item.</summary>
			/// <param name="pszName">
			/// A pointer to the item's canonical name or its GUID. This value can be NULL. See Remarks for further details. For a complete
			/// list of Control Panel item canonical names, see Canonical Names of Control Panel Items.
			/// </param>
			/// <param name="pszPath">When this method returns, contains the path of the specified Control Panel item as a Unicode string.</param>
			/// <param name="cchPath">The size of the buffer pointed to by pszPath, in WCHARs.</param>
			void GetPath([MarshalAs(UnmanagedType.LPWStr)] string pszName, [MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder pszPath, uint cchPath);

			/// <summary>Gets the most recent Control Panel view: Classic view or Category view.</summary>
			/// <returns>The most recent view.</returns>
			CPVIEW GetCurrentView();
		}

		/// <summary>Class interface for IOpenControlPanel.</summary>
		[ComImport, Guid("06622D85-6856-4460-8DE1-A81921B41C4B"), ClassInterface(ClassInterfaceType.None)]
		public class OpenControlPanel { }

		[AttributeUsage(AttributeTargets.Field, Inherited = false)]
		internal class CPAssociateAttribute : AssociateAttribute
		{
			public CPAssociateAttribute(string guid, string canonicalName, string module, PInvokeClient minClient = PInvokeClient.WindowsVista, string validPages = null) : base(guid)
			{
				CanonicalName = canonicalName;
				ModuleName = module;
				MinClient = minClient;
				ValidPages = validPages?.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
			}

			public string CanonicalName { get; private set; }
			public PInvokeClient MinClient { get; private set; }
			public string ModuleName { get; private set; }
			public string[] ValidPages { get; private set; }
		}
	}
}