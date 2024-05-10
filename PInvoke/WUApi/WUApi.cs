global using System.Collections;
global using System.Reflection;
global using System.Runtime.CompilerServices;
using System.Net;

namespace Vanara.PInvoke;

/// <summary>PInvoke API (methods, structures and constants) imported from Windows Update API.</summary>
public static partial class WUApi
{
	private const string Lib_WUApi = "wuapi.dll";

	/// <summary>Defines the possible ways in which the IUpdateServiceManager2 interface can process service registration requests.</summary>
	/// <remarks>
	/// For info about how IUpdateServiceManager2::AddService2 behaves when you specify different combinations of <c>AddServiceFlag</c>
	/// values in the <c>flags</c> parameter, see the Remarks section of <c>IUpdateServiceManager2::AddService2</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-addserviceflag typedef enum tagAddServiceFlag {
	// asfAllowPendingRegistration = 0x1, asfAllowOnlineRegistration = 0x2, asfRegisterServiceWithAU = 0x4 } AddServiceFlag;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagAddServiceFlag")]
	[Flags]
	public enum AddServiceFlag
	{
		/// <summary>
		/// <para>Value: 0x1</para>
		/// <para>Allows the update agent to process the service registration at a later time, when it next performs an online scan for updates.</para>
		/// </summary>
		asfAllowPendingRegistration = 1,

		/// <summary>
		/// <para>Value: 0x2</para>
		/// <para>Allows the update agent to process the service registration immediately if network connectivity is available.</para>
		/// </summary>
		asfAllowOnlineRegistration = 2,

		/// <summary>
		/// <para>Value: 0x4</para>
		/// <para>Registers the service with Automatic Updates when the service is added.</para>
		/// </summary>
		asfRegisterServiceWithAU = 4,
	}

	/// <summary>
	/// Defines the types of logic that is used to determine whether Automatic Updates will automatically download an update once it is
	/// determined to be applicable for the computer.
	/// </summary>
	/// <remarks>
	/// If Automatic Updates is disabled, or if Automatic Updates is enabled but set to “Check for updates but let me choose whether to
	/// download or install them,” updates will never be automatically downloaded, regardless of the value of an update’s
	/// IUpdate5::AutoDownload property. In earlier versions of the WUA in which IUpdate5 is not available, all updates are processed by
	/// using the standard logic.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-autodownloadmode typedef enum tagAutoDownloadMode {
	// adLetWindowsUpdateDecide = 0, adNeverAutoDownload = 1, adAlwaysAutoDownload = 2 } AutoDownloadMode;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagAutoDownloadMode")]
	public enum AutoDownloadMode
	{
		/// <summary>
		/// <para>Value: 0</para>
		/// <para>
		/// Use the standard logic. The update will be automatically downloaded if it is important, or if it is recommended and Windows
		/// Update has been configured to treat recommended updates as important. Otherwise, the update will not be automatically downloaded.
		/// </para>
		/// </summary>
		adLetWindowsUpdateDecide,

		/// <summary>
		/// <para>Value: 1</para>
		/// <para>
		/// The update will not be automatically downloaded; it will be downloaded only when the user attempts to install the update, or when
		/// a Windows Update Agent (WUA) API caller requests that the update be downloaded by using the
		/// </para>
		/// <para>IUpdateDownloader::Download</para>
		/// <para>or</para>
		/// <para>IUpdateDownloader::BeginDownload</para>
		/// <para>methods.</para>
		/// </summary>
		adNeverAutoDownload,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>The update will always be automatically downloaded.</para>
		/// </summary>
		adAlwaysAutoDownload,
	}

	/// <summary>Defines the possible ways in which elevated users are notified about Automatic Updates events.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-automaticupdatesnotificationlevel typedef enum
	// tagAutomaticUpdatesNotificationLevel { aunlNotConfigured = 0, aunlDisabled = 1, aunlNotifyBeforeDownload = 2,
	// aunlNotifyBeforeInstallation = 3, aunlScheduledInstallation = 4 } AutomaticUpdatesNotificationLevel;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagAutomaticUpdatesNotificationLevel")]
	public enum AutomaticUpdatesNotificationLevel
	{
		/// <summary>
		/// <para>Value: 0</para>
		/// <para>
		/// Automatic Updates is not configured by the user or by a Group Policy administrator. Users are periodically prompted to configure
		/// Automatic Updates.
		/// </para>
		/// </summary>
		aunlNotConfigured,

		/// <summary>
		/// <para>Value: 1</para>
		/// <para>Automatic Updates is disabled. Users are not notified of important updates for the computer.</para>
		/// </summary>
		aunlDisabled,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>Automatic Updates prompts users to approve updates before it downloads or installs the updates.</para>
		/// </summary>
		aunlNotifyBeforeDownload,

		/// <summary>
		/// <para>Value: 3</para>
		/// <para>Automatic Updates automatically downloads updates, but prompts users to approve the updates before installation.</para>
		/// </summary>
		aunlNotifyBeforeInstallation,

		/// <summary>
		/// <para>Value: 4</para>
		/// <para>
		/// Automatic Updates automatically installs updates according to the schedule that is specified by the user or by the
		/// IAutomaticUpdatesSettings.ScheduledInstallationDay and IAutomaticUPdatesSettings.ScheduledInstallationTime properties. This
		/// setting is the recommended setting.
		/// </para>
		/// </summary>
		aunlScheduledInstallation,
	}

	/// <summary>
	/// Defines the possible ways to set the NotificationLevel property of the IAutomaticUpdatesSettings interface or the
	/// IncludeRecommendedUpdates property of the IAutomaticUpdatesSettings2 interface.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Featured update notifications are only supported on Windows Vista and above. On Windows XP systems running versions of the Windows
	/// Update Agent (WUA) that support IAutomaticUpdatesSettings3, the IAutomaticUpdatesSettings3::FeaturedUpdatesEnabled value will always
	/// be VARIANT_FALSE, and attempting to alter its value will result in an error.
	/// </para>
	/// <para>
	/// Featured update notifications are only supported when Automatic Updates is turned on. If Automatic Updates is set to “Never check for
	/// updates (not recommended),” then the IAutomaticUpdatesSettings3::FeaturedUpdatesEnabled value will always be VARIANT_FALSE, and
	/// attempting to alter its value will result in an error.
	/// </para>
	/// <para>
	/// Featured update notifications are only supported on certain update services. Currently, the only supported update service is
	/// Microsoft Update. If Automatic Updates is currently configured to receive updates from another service (from Windows Update, or from
	/// a WSUS server), then the IAutomaticUpdatesSettings3::FeaturedUpdatesEnabled value will always be VARIANT_FALSE, and attempting to
	/// alter its value will result in an error.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-automaticupdatespermissiontype typedef enum
	// tagAutomaticUpdatesPermissionType { auptSetNotificationLevel = 1, auptDisableAutomaticUpdates = 2, auptSetIncludeRecommendedUpdates =
	// 3, auptSetFeaturedUpdatesEnabled = 4, auptSetNonAdministratorsElevated = 5 } AutomaticUpdatesPermissionType;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagAutomaticUpdatesPermissionType")]
	public enum AutomaticUpdatesPermissionType
	{
		/// <summary>
		/// <para>Value: 1</para>
		/// <para>The ability to set the IAutomaticUpdatesSettings::NotificationLevel property.</para>
		/// </summary>
		auptSetNotificationLevel = 1,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>The ability to set the IAutomaticUpdatesSettings::NotificationLevel property to aunlDisabled.</para>
		/// </summary>
		auptDisableAutomaticUpdates,

		/// <summary>
		/// <para>Value: 3</para>
		/// <para>The ability to set the IAutomaticUpdatesSettings2::IncludedRecommendedUpdates property.</para>
		/// </summary>
		auptSetIncludeRecommendedUpdates,

		/// <summary>
		/// <para>Value: 4</para>
		/// <para>The ability to set the IAutomaticUpdatesSettings3::FeaturedUpdatesEnabled property.</para>
		/// </summary>
		auptSetFeaturedUpdatesEnabled,

		/// <summary>
		/// <para>Value: 5</para>
		/// <para>The ability to set the IAutomaticUpdatesSettings3::NonAdministratorsElevated property.</para>
		/// </summary>
		auptSetNonAdministratorsElevated,
	}

	/// <summary>Defines the days of the week when Automatic Updates installs or uninstalls updates.</summary>
	/// <remarks>
	/// Updates are installed on the scheduled day. The updates depend on the settings of the NotificationLevel and ScheduledInstallationTime
	/// properties of the IAutomaticUpdatesSettings interface.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-automaticupdatesscheduledinstallationday typedef enum
	// tagAutomaticUpdatesScheduledInstallationDay { ausidEveryDay = 0, ausidEverySunday = 1, ausidEveryMonday = 2, ausidEveryTuesday = 3,
	// ausidEveryWednesday = 4, ausidEveryThursday = 5, ausidEveryFriday = 6, ausidEverySaturday = 7 } AutomaticUpdatesScheduledInstallationDay;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagAutomaticUpdatesScheduledInstallationDay")]
	public enum AutomaticUpdatesScheduledInstallationDay
	{
		/// <summary>
		/// <para>Value: 0</para>
		/// <para>Every day.</para>
		/// </summary>
		ausidEveryDay,

		/// <summary>
		/// <para>Value: 1</para>
		/// <para>Every Sunday.</para>
		/// </summary>
		ausidEverySunday,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>Every Monday.</para>
		/// </summary>
		ausidEveryMonday,

		/// <summary>
		/// <para>Value: 3</para>
		/// <para>Every Tuesday.</para>
		/// </summary>
		ausidEveryTuesday,

		/// <summary>
		/// <para>Value: 4</para>
		/// <para>Every Wednesday.</para>
		/// </summary>
		ausidEveryWednesday,

		/// <summary>
		/// <para>Value: 5</para>
		/// <para>Every Thursday.</para>
		/// </summary>
		ausidEveryThursday,

		/// <summary>
		/// <para>Value: 6</para>
		/// <para>Every Friday.</para>
		/// </summary>
		ausidEveryFriday,

		/// <summary>
		/// <para>Value: 7</para>
		/// <para>Every Saturday.</para>
		/// </summary>
		ausidEverySaturday,
	}

	/// <summary>Defines the type of user.</summary>
	/// <remarks>The AutomaticUpdatesUserType is used in conjunction with the IAutomaticUpdatesSettings2::CheckPermission method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-automaticupdatesusertype typedef enum tagAutomaticUpdatesUserType {
	// auutCurrentUser = 1, auutLocalAdministrator = 2 } AutomaticUpdatesUserType;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagAutomaticUpdatesUserType")]
	public enum AutomaticUpdatesUserType
	{
		/// <summary>
		/// <para>Value: 1</para>
		/// <para>The context of the current user.</para>
		/// </summary>
		auutCurrentUser = 1,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>Any administrator on the local computer.</para>
		/// </summary>
		auutLocalAdministrator,
	}

	/// <summary>
	/// Defines the types of logic that is used to determine whether a particular update will be automatically selected when the user views
	/// available updates in the Windows Update user interface.
	/// </summary>
	/// <remarks>
	/// In versions of the Windows Update Agent (WUA) in which IUpdate5 is not available, all updates are processed by using the standard logic.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-autoselectionmode typedef enum tagAutoSelectionMode {
	// asLetWindowsUpdateDecide = 0, asAutoSelectIfDownloaded = 1, asNeverAutoSelect = 2, asAlwaysAutoSelect = 3 } AutoSelectionMode;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagAutoSelectionMode")]
	public enum AutoSelectionMode
	{
		/// <summary>
		/// <para>Value: 0</para>
		/// <para>
		/// Use the standard logic. The update will be automatically selected if it is important, or if it is recommended and Windows Update
		/// has been configured to treat recommended updates as important. Otherwise, the update will not be automatically selected.
		/// </para>
		/// </summary>
		asLetWindowsUpdateDecide,

		/// <summary>
		/// <para>Value: 1</para>
		/// <para>The update will be automatically selected only if it has been completely downloaded.</para>
		/// </summary>
		asAutoSelectIfDownloaded,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>The update will never be automatically selected.</para>
		/// </summary>
		asNeverAutoSelect,

		/// <summary>
		/// <para>Value: 3</para>
		/// <para>The update will always be automatically selected.</para>
		/// </summary>
		asAlwaysAutoSelect,
	}

	/// <summary>Defines the action for which an update is explicitly deployed.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-deploymentaction typedef enum tagDeploymentAction { daNone = 0,
	// daInstallation = 1, daUninstallation = 2, daDetection = 3, daOptionalInstallation = 4 } DeploymentAction;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagDeploymentAction")]
	public enum DeploymentAction
	{
		/// <summary>
		/// <para>Value: 0</para>
		/// <para>No explicit deployment action is specified on the update. The update inherits the value from its bundled updates.</para>
		/// </summary>
		daNone,

		/// <summary>
		/// <para>Value: 1</para>
		/// <para>The update should be installed on the computer and/or for the specified user.</para>
		/// </summary>
		daInstallation,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>The update should be uninstalled from the computer and/or for the specified user.</para>
		/// </summary>
		daUninstallation,

		/// <summary>
		/// <para>Value: 3</para>
		/// <para>The update is deployed only to determine the applicability of the update. The update will not be installed.</para>
		/// </summary>
		daDetection,

		/// <summary>
		/// <para>Value: 4</para>
		/// <para>The update may be installed on the computer and/or for the specified user.</para>
		/// </summary>
		daOptionalInstallation,
	}

	/// <summary>
	/// Defines the progress of the download of the current update that is returned by the CurrentUpdateDownloadPhase property of the
	/// IDownloadProgress interface.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-downloadphase typedef enum tagDownloadPhase { dphInitializing = 1,
	// dphDownloading = 2, dphVerifying = 3 } DownloadPhase;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagDownloadPhase")]
	public enum DownloadPhase
	{
		/// <summary>
		/// <para>Value: 1</para>
		/// <para>Initializing the download of the current update.</para>
		/// </summary>
		dphInitializing = 1,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>Downloading the current update.</para>
		/// </summary>
		dphDownloading,

		/// <summary>
		/// <para>Value: 3</para>
		/// <para>Verifying the download of the current update.</para>
		/// </summary>
		dphVerifying,
	}

	/// <summary>Defines the possible priorities for a download operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-downloadpriority typedef enum tagDownloadPriority { dpLow = 1,
	// dpNormal = 2, dpHigh = 3, dpExtraHigh = 4 } DownloadPriority;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagDownloadPriority")]
	public enum DownloadPriority
	{
		/// <summary>
		/// <para>Value: 1</para>
		/// <para>Updates are downloaded as low priority.</para>
		/// </summary>
		dpLow = 1,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>Updates are downloaded as normal priority.</para>
		/// </summary>
		dpNormal,

		/// <summary>
		/// <para>Value: 3</para>
		/// <para>Updates are downloaded as high priority.</para>
		/// </summary>
		dpHigh,

		/// <summary>
		/// <para>Value: 4</para>
		/// </summary>
		dpExtraHigh,
	}

	/// <summary>Defines the possible levels of impact that can be caused by installing or uninstalling an update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-installationimpact typedef enum tagInstallationImpact { iiNormal =
	// 0, iiMinor = 1, iiRequiresExclusiveHandling = 2 } InstallationImpact;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagInstallationImpact")]
	public enum InstallationImpact
	{
		/// <summary>
		/// <para>Value: 0</para>
		/// <para>
		/// Installing or uninstalling an update results in a level of impact on the target computer that is typical of most updates.
		/// Therefore, the update does not qualify for any of the special impact ratings that are defined in this topic.
		/// </para>
		/// </summary>
		iiNormal,

		/// <summary>
		/// <para>Value: 1</para>
		/// <para>Installing or uninstalling an update results in an insignificant impact on the target computer.</para>
		/// <para>
		/// The update must meet strict requirements to qualify for this rating. The requirements include, but are not limited to, the
		/// following requirements:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>It must not perform or require a system restart.</description>
		/// </item>
		/// <item>
		/// <description>It must not display a user interface.</description>
		/// </item>
		/// <item>
		/// <description>
		/// The installation or uninstallation must succeed even if it affects an application or service that is currently being used.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Updates that qualify for this rating may be eligible for special handling in Windows Update Agent (WUA). For example, they may be
		/// eligible for accelerated distribution.
		/// </para>
		/// </summary>
		iiMinor,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>
		/// This update cannot be installed in the same IUpdateInstaller::Install or IUpdateInstaller::BeginInstall call as any other update.
		/// If you make an IUpdateInstaller::Install or IUpdateInstaller::BeginInstall call that includes an exclusive update along with one
		/// or more other updates, the call will return WU_E_EXCLUSIVE_INSTALL_CONFLICT and no updates will be installed.
		/// </para>
		/// </summary>
		iiRequiresExclusiveHandling,
	}

	/// <summary>
	/// The <c>InstallationRebootBehavior</c> enumeration defines the possible restart behaviors for an update. The
	/// <c>InstallationRebootBehavior</c> enumeration applies to the installation and uninstallation of updates.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-installationrebootbehavior typedef enum
	// tagInstallationRebootBehavior { irbNeverReboots = 0, irbAlwaysRequiresReboot = 1, irbCanRequestReboot = 2 } InstallationRebootBehavior;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagInstallationRebootBehavior")]
	public enum InstallationRebootBehavior
	{
		/// <summary>
		/// <para>Value: 0</para>
		/// <para>The update never requires a system restart during or after an installation or an uninstallation.</para>
		/// </summary>
		irbNeverReboots,

		/// <summary>
		/// <para>Value: 1</para>
		/// <para>The update always requires a system restart after a successful installation or uninstallation.</para>
		/// </summary>
		irbAlwaysRequiresReboot,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>The update can request a system restart after a successful installation or uninstallation.</para>
		/// </summary>
		irbCanRequestReboot,
	}

	/// <summary>Defines the possible results of a download, install, uninstall, or verification operation on an update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-operationresultcode typedef enum tagOperationResultCode {
	// orcNotStarted = 0, orcInProgress = 1, orcSucceeded = 2, orcSucceededWithErrors = 3, orcFailed = 4, orcAborted = 5 } OperationResultCode;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagOperationResultCode")]
	public enum OperationResultCode
	{
		/// <summary>
		/// <para>Value: 0</para>
		/// <para>The operation is not started.</para>
		/// </summary>
		orcNotStarted,

		/// <summary>
		/// <para>Value: 1</para>
		/// <para>The operation is in progress.</para>
		/// </summary>
		orcInProgress,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>The operation was completed successfully.</para>
		/// </summary>
		orcSucceeded,

		/// <summary>
		/// <para>Value: 3</para>
		/// <para>The operation is complete, but one or more errors occurred during the operation. The results might be incomplete.</para>
		/// </summary>
		orcSucceededWithErrors,

		/// <summary>
		/// <para>Value: 4</para>
		/// <para>The operation failed to complete.</para>
		/// </summary>
		orcFailed,

		/// <summary>
		/// <para>Value: 5</para>
		/// <para>The operation is canceled.</para>
		/// </summary>
		orcAborted,
	}

	/// <summary>Defines the variety of updates that should be returned by the search: per-machine updates, per-user updates, or both.</summary>
	/// <remarks>
	/// In versions of the Windows Update Agent that do not support per-user updates (versions that do not support the IUpdateSearcher3
	/// interface), searches will always return only per-machine updates.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-searchscope typedef enum tagSearchScope { searchScopeDefault = 0,
	// searchScopeMachineOnly = 1, searchScopeCurrentUserOnly = 2, searchScopeMachineAndCurrentUser = 3, searchScopeMachineAndAllUsers
	// = 4, searchScopeAllUsers = 5 } SearchScope;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagSearchScope")]
	public enum SearchScope
	{
		/// <summary>
		/// <para>Value: 0</para>
		/// <para>
		/// Search by using the default scope (the scope that Automatic Updates would use when searching for updates). This is currently
		/// equivalent to search ScopeMachineOnly.
		/// </para>
		/// </summary>
		searchScopeDefault,

		/// <summary>
		/// <para>Value: 1</para>
		/// <para>Search only for per-machine updates; exclude all per-user updates.</para>
		/// </summary>
		searchScopeMachineOnly,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>
		/// Search only for per-user updates applicable to the calling user – the user who owns the process which is making the Windows
		/// Update Agent (WUA) API call.
		/// </para>
		/// </summary>
		searchScopeCurrentUserOnly,

		/// <summary>
		/// <para>Value: 3</para>
		/// <para>[Not currently supported.] Search for per-machine updates and for per-user updates applicable to the current user.</para>
		/// </summary>
		searchScopeMachineAndCurrentUser,

		/// <summary>
		/// <para>Value: 4</para>
		/// <para>
		/// [Not currently supported.] Search for per-machine updates and for per-user updates applicable to any known user accounts on the computer.
		/// </para>
		/// </summary>
		searchScopeMachineAndAllUsers,

		/// <summary>
		/// <para>Value: 5</para>
		/// <para>[Not currently supported.] Search only for per-user updates applicable to any known user accounts on the computer.</para>
		/// </summary>
		searchScopeAllUsers,
	}

	/// <summary>Defines the update services that Windows Update can operate against.</summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/aa387280(v%3dvs.85) typedef enum { ssDefault = 0, ssManagedServer
	// = 1, ssWindowsUpdate = 2, ssOthers = 3 } ServerSelection;
	[PInvokeData("Wuapi.h")]
	public enum ServerSelection
	{
		/// <summary>
		/// <para>Used only by <c>IUpdateSearcher</c>. Indicates that the search call should search the default server.</para>
		/// <para>
		/// The default server used by the Windows Update Agent (WUA) is the same as <c>ssMangagedServer</c> if the computer is set up to
		/// have a managed server. If the computer is not been set up to have a managed server, WUA uses the first update service for which
		/// the <c>IsRegisteredWithAU</c> property of <c>IUpdateService</c> is VARIANT_TRUE and the <c>IsManaged</c> property of
		/// <c>IUpdateService</c> is VARIANT_FALSE
		/// </para>
		/// </summary>
		ssDefault,

		/// <summary>
		/// Indicates the managed server, in an environment that uses Windows Server Update Services or a similar corporate update server to
		/// manage the computer.
		/// </summary>
		ssManagedServer,

		/// <summary>Indicates the Windows Update service.</summary>
		ssWindowsUpdate,

		/// <summary>
		/// Indicates some update service other than those listed previously. If the <c>ServerSelection</c> property of a Windows Update
		/// Agent API object is set to <c>ssOthers</c>, then the <c>ServiceID</c> property of the object contains the ID of the service.
		/// </summary>
		ssOthers,
	}

	/// <summary>Defines the type of tokens that can be used for authenticating with an endpoint.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/wua_sdk/updateendpointauthtokentype typedef enum tagUpdateEndpointAuthTokenType {
	// ueattInvalidTokenType = 0x0, ueattSAML11Token = 0X1 } UpdateEndpointAuthTokenType;
	[PInvokeData("UpdateEndpointAuth.h")]
	[Flags]
	public enum UpdateEndpointAuthTokenType : uint
	{
		/// <summary>No authentication token is needed.</summary>
		ueattInvalidTokenType = 0x0,

		/// <summary>The authentication token for the endpoint is a WS-Security SAML (Security Assertion Markup Language) 1.1 token.</summary>
		ueattSAML11Token = 0x1,
	}

	/// <summary>Defines the type of endpoints that can be used to connect to a service.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/wua_sdk/updateendpointtype typedef enum tagEndpointType { uetClientServer = 0,
	// uetReporting = ( uetClientServer + 1 ), uetWuaSelfUpdate = ( uetReporting + 1 ), uetRegulation = ( uetWuaSelfUpdate + 1 ),
	// uetSimpleTargeting = ( uetRegulation + 1 ), uetSecuredClientServer = ( uetSimpleTargeting + 1 ), uetSecondaryServiceAuth = (
	// uetSecuredClientServer + 1 ) } UpdateEndpointType;
	[PInvokeData("UpdateEndpointAuth.h")]
	public enum UpdateEndpointType
	{
		/// <summary>
		/// <para>
		/// A client-server endpoint that is used to connect to the update service, such as Windows Update, Microsoft Update, and WSUS server
		/// in a corporate environment, to find information on updates that may be applicable to the computer.
		/// </para>
		/// <para>
		/// The update service returns information on updates that have been published, revised, or withdrawn since the last time that client
		/// performed a sync with the server.
		/// </para>
		/// </summary>
		uetClientServer,

		/// <summary>
		/// <para>
		/// A reporting endpoint that is used when the client reports the results of scans, downloads, and installs back to the update service.
		/// </para>
		/// <para>In the case of public services (Windows Update and Microsoft Update), this is done for quality monitoring purposes.</para>
		/// <para>
		/// In the case of private services, such as a corporate WSUS server, this type of endpoint also allows the server to collect
		/// inventory and other information about the client computers under management.
		/// </para>
		/// </summary>
		uetReporting,

		/// <summary>
		/// <para>
		/// A self-update endpoint that is used when the client computer contacts an update service to see whether there is a new version of
		/// the Windows Update Agent client software.
		/// </para>
		/// <para>
		/// The Self-update endpoint uses a different protocol then the Client-Server endpoint so that self-updates can be distributed even
		/// if there is an error condition that might be preventing the normal client-server sync from working on a particular client computer.
		/// </para>
		/// </summary>
		uetWuaSelfUpdate,

		/// <summary>
		/// <para>
		/// A regulation endpoint that is used when the client computer contacts the regulation service to act on a particular update that is
		/// applicable to the target computer.
		/// </para>
		/// <para>
		/// The regulation service can indicate whether the update is “regulated” (also known as “throttled”) – in other words, the
		/// regulation service can tell the client computer that it should not act on a particular update, even though that update appears to
		/// be applicable.
		/// </para>
		/// </summary>
		uetRegulation,

		/// <summary>
		/// <para>
		/// A simple-targeting endpoint that is used only with private services (WSUS servers in corporate environments). In a corporate
		/// environment, client computers can be assigned to particular target groups, and updates can be approved for installation on
		/// computers in some groups but not others.
		/// </para>
		/// <para>
		/// For example, the WSUS administrator may create a “Testing” group for computers that are used to test new updates, and the
		/// administrator may approve newly-released updates for installation on computers in the Testing group without approving them for
		/// installation on other computers in the organization. The simple targeting exchange is used to allow a client computer to register
		/// itself with the WSUS server, and to allow the server to tell the client computer what group it is in.
		/// </para>
		/// </summary>
		uetSimpleTargeting,

		/// <summary>
		/// A secured-client-server endpoint that allows a client to obtain info on apps that need licensing so they can be used on a client
		/// computer. This licensing framework is currently only used by Windows 8 to deploy apps and updates that are obtained through the
		/// Windows Store. The secured-client-server endpoint is currently not used by Windows Update, Microsoft Update, or WSUS.
		/// </summary>
		uetSecuredClientServer,

		/// <summary>
		/// The secondary-service-authentication endpoint is used by a client to provide authentication before it obtains info on apps that
		/// need licensing so they can be used on a client computer. This licensing framework is currently only utilized by Windows 8 to
		/// deploy apps and updates that are obtained through the Windows Store. The secondary-service-authentication endpoint is currently
		/// not used by Windows Update, Microsoft Update, or WSUS.
		/// </summary>
		uetSecondaryServiceAuth,
	}

	/// <summary>Defines the context in which an IUpdateException object can be provided.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-updateexceptioncontext typedef enum tagUpdateExceptionContext {
	// uecGeneral = 1, uecWindowsDriver = 2, uecWindowsInstaller = 3, uecSearchIncomplete = 4 } UpdateExceptionContext;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagUpdateExceptionContext")]
	public enum UpdateExceptionContext
	{
		/// <summary>
		/// <para>Value: 1</para>
		/// <para>The IUpdateException is not tied to any context.</para>
		/// </summary>
		uecGeneral = 1,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>The IUpdateException is related to one or more Windows drivers.</para>
		/// </summary>
		uecWindowsDriver,

		/// <summary>
		/// <para>Value: 3</para>
		/// <para>The IUpdateException is related to Windows Installer.</para>
		/// </summary>
		uecWindowsInstaller,

		/// <summary>
		/// <para>Value: 4</para>
		/// </summary>
		uecSearchIncomplete,
	}

	/// <summary>Defines the functionality that the Windows Update Agent (WUA) object can access from Windows Update.</summary>
	/// <remarks>
	/// <para>
	/// In the following table, the first column lists the interfaces that implement the IUpdateLockdown interface. The second column lists
	/// the methods and properties that are restricted by the WUA interfaces when a value is specified for <c>uloForWebsiteAccess</c>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>WUA object</description>
	/// <description>Restricted methods and properties</description>
	/// </listheader>
	/// <item>
	/// <description>IAutomaticUpdates</description>
	/// <description>Pause Resume</description>
	/// </item>
	/// <item>
	/// <description>IAutomaticUpdatesSettings</description>
	/// <description>Save</description>
	/// </item>
	/// <item>
	/// <description>IUpdate</description>
	/// <description>AcceptEula CopyFromCache CopyToCache</description>
	/// </item>
	/// <item>
	/// <description>IUpdateDownloader</description>
	/// <description>Download BeginDownload EndDownload IsForced (cannot set)</description>
	/// </item>
	/// <item>
	/// <description>IUpdateInstaller</description>
	/// <description>BeginInstall BeginUninstall EndInstall EndUninstall Install IsForced (cannot set) Uninstall</description>
	/// </item>
	/// <item>
	/// <description>IUpdateServiceManager</description>
	/// <description>AddScanPackageService RemoveService SetOption</description>
	/// </item>
	/// <item>
	/// <description>IWebProxy</description>
	/// <description>
	/// Address (cannot set) AutoDetect (cannot set) BypassList (cannot set) BypassProxyOnLocal (cannot set) SetPassword UserName (cannot set)
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-updatelockdownoption typedef enum tagUpdateLockdownOption {
	// uloForWebsiteAccess = 0x1 } UpdateLockdownOption;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagUpdateLockdownOption")]
	public enum UpdateLockdownOption
	{
		/// <summary>
		/// <para>Value: 0x1</para>
		/// <para>If access is from Windows Update, restrict access to the WUA interfaces that implement the IUpdateLockdown interface.</para>
		/// </summary>
		uloForWebsiteAccess = 1,
	}

	/// <summary>Defines operations that can be attempted on an update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-updateoperation typedef enum tagUpdateOperation { uoInstallation =
	// 1, uoUninstallation = 2 } UpdateOperation;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagUpdateOperation")]
	public enum UpdateOperation
	{
		/// <summary>
		/// <para>Value: 1</para>
		/// <para>Under the security context of the caller, install the update on the target computer.</para>
		/// </summary>
		uoInstallation = 1,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>Under the security context of the caller, uninstall the updates from the target computer.</para>
		/// </summary>
		uoUninstallation,
	}

	/// <summary>Defines the options that affect how the service registration for a scan package service is removed.</summary>
	/// <remarks>
	/// <para>
	/// If you do not specify <c>usoNonVolatileService</c>, the service registration is automatically removed when you release the
	/// IUpdateService interface.
	/// </para>
	/// <para>
	/// The <c>UpdateServiceOption</c> enumeration may require that you update Windows Update Agent (WUA). For more information, see Updating
	/// Windows Update Agent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-updateserviceoption typedef enum tagUpdateServiceOption {
	// usoNonVolatileService = 0x1 } UpdateServiceOption;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagUpdateServiceOption")]
	public enum UpdateServiceOption
	{
		/// <summary>
		/// <para>Value: 0x1</para>
		/// <para>
		/// Indicates that you must call the IUpdateServiceManager::RemoveService method to remove the service registration. Failure to call
		/// the RemoveService method before releasing the IUpdateService interface causes a resource leak.
		/// </para>
		/// </summary>
		usoNonVolatileService = 1,
	}

	/// <summary>Defines the possible states for an update service.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-updateserviceregistrationstate typedef enum
	// tagUpdateServiceRegistrationState { usrsNotRegistered = 1, usrsRegistrationPending = 2, usrsRegistered = 3 } UpdateServiceRegistrationState;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagUpdateServiceRegistrationState")]
	public enum UpdateServiceRegistrationState
	{
		/// <summary>
		/// <para>Value: 1</para>
		/// <para>The service is not registered.</para>
		/// </summary>
		usrsNotRegistered = 1,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>The service is pending registration. Registration will be attempted the next time the update agent contacts an update service.</para>
		/// </summary>
		usrsRegistrationPending,

		/// <summary>
		/// <para>Value: 3</para>
		/// <para>The service is registered.</para>
		/// </summary>
		usrsRegistered,
	}

	/// <summary>Defines the types of update, such as a driver or software update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/ne-wuapi-updatetype typedef enum tagUpdateType { utSoftware = 1, utDriver =
	// 2 } UpdateType;
	[PInvokeData("wuapi.h", MSDNShortId = "NE:wuapi.tagUpdateType")]
	public enum UpdateType
	{
		/// <summary>
		/// <para>Value: 1</para>
		/// <para>Indicates that the update is a software update.</para>
		/// </summary>
		utSoftware = 1,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>Indicates that the update is a driver update.</para>
		/// </summary>
		utDriver,
	}

	/// <summary>Contains the functionality of Automatic Updates.</summary>
	/// <remarks>
	/// You can create an instance of this interface by using the AutomaticUpdates coclass. Use the Microsoft.Update.AutoUpdate program
	/// identifier to create the object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iautomaticupdates
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IAutomaticUpdates")]
	[ComImport, Guid("673425BF-C082-4C7C-BDFD-569464B8E0CE"), CoClass(typeof(AutomaticUpdates))]
	public interface IAutomaticUpdates
	{
		/// <summary>
		/// Begins the Automatic Updates detection task if Automatic Updates is enabled. If any updates are detected, the installation
		/// behavior is determined by the NotificationLevel property of the IAutomaticUpdatesSettings interface.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdates-detectnow HRESULT DetectNow();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
		void DetectNow();

		/// <summary>Pauses automatic updates.</summary>
		/// <remarks>
		/// <para>This method requires administrator permissions.</para>
		/// <para>
		/// Automatic Updates can be paused for only eight hours. This limit varies in different binary versions. Callers should call the
		/// Resume method after calling <c>Pause</c> as soon as they no longer need to pause automatic updating.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdates-pause HRESULT Pause();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
		void Pause();

		/// <summary>Restarts automatic updating if automatic updating is paused.</summary>
		/// <remarks>
		/// <para>This method requires administrator permissions.</para>
		/// <para>Callers should call <c>Resume</c> after calling the Pause method as soon as they no longer need to pause automatic updating.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdates-resume HRESULT Resume();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
		void Resume();

		/// <summary>Displays a dialog box that contains settings for Automatic Updates.</summary>
		/// <remarks>
		/// <para>
		/// A call to <c>ShowSettingsDialog</c> fails if the calling user is not logged on or does not have a desktop. A caller can also
		/// programmatically modify Automatic Updates settings by using the Settings property.
		/// </para>
		/// <para>
		/// The settings in the dialog box are read-only if the caller has insufficient security permissions or if the settings are enforced
		/// by a domain administrator who is using Group Policy settings.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdates-showsettingsdialog HRESULT ShowSettingsDialog();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
		void ShowSettingsDialog();

		/// <summary>
		/// <para>Gets the configuration settings for Automatic Updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>The returned interface can be used to change the current settings and to read the current settings.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdates-get_settings HRESULT get_Settings(
		// IAutomaticUpdatesSettings **retval );
		[DispId(1610743813)]
		IAutomaticUpdatesSettings Settings
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether all the components that Automatic Updates requires are available.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value><see langword="true"/> if all the components that Automatic Updates requires are available; otherwise, <see langword="false"/>.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdates-get_serviceenabled HRESULT
		// get_ServiceEnabled( VARIANT_BOOL *retval );
		[DispId(1610743814)]
		bool ServiceEnabled
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
			get;
		}

		/// <summary>Enables all the components that Automatic Updates requires.</summary>
		/// <remarks>
		/// <para>This method requires administrator permissions.</para>
		/// <para>This method returns <c>WU_E_AU_NOSERVICE</c> if Automatic Updates is disabled, initializing, uninitializing, or not configured.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdates-enableservice HRESULT EnableService();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
		void EnableService();
	}

	/// <summary>Contains the functionality of Automatic Updates.</summary>
	/// <remarks>
	/// You can create a new instance of this interface by using the AutomaticUpdates coclass. Use the Microsoft.Update.AutoUpdate program
	/// identifier to create the object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iautomaticupdates2
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IAutomaticUpdates2")]
	[ComImport, Guid("4A2F5C31-CFD9-410E-B7FB-29A653973A0F"), CoClass(typeof(AutomaticUpdates))]
	public interface IAutomaticUpdates2 : IAutomaticUpdates
	{
		/// <summary>
		/// Begins the Automatic Updates detection task if Automatic Updates is enabled. If any updates are detected, the installation
		/// behavior is determined by the NotificationLevel property of the IAutomaticUpdatesSettings interface.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdates-detectnow HRESULT DetectNow();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
		new void DetectNow();

		/// <summary>Pauses automatic updates.</summary>
		/// <remarks>
		/// <para>This method requires administrator permissions.</para>
		/// <para>
		/// Automatic Updates can be paused for only eight hours. This limit varies in different binary versions. Callers should call the
		/// Resume method after calling <c>Pause</c> as soon as they no longer need to pause automatic updating.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdates-pause HRESULT Pause();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
		new void Pause();

		/// <summary>Restarts automatic updating if automatic updating is paused.</summary>
		/// <remarks>
		/// <para>This method requires administrator permissions.</para>
		/// <para>Callers should call <c>Resume</c> after calling the Pause method as soon as they no longer need to pause automatic updating.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdates-resume HRESULT Resume();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
		new void Resume();

		/// <summary>Displays a dialog box that contains settings for Automatic Updates.</summary>
		/// <remarks>
		/// <para>
		/// A call to <c>ShowSettingsDialog</c> fails if the calling user is not logged on or does not have a desktop. A caller can also
		/// programmatically modify Automatic Updates settings by using the Settings property.
		/// </para>
		/// <para>
		/// The settings in the dialog box are read-only if the caller has insufficient security permissions or if the settings are enforced
		/// by a domain administrator who is using Group Policy settings.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdates-showsettingsdialog HRESULT ShowSettingsDialog();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
		new void ShowSettingsDialog();

		/// <summary>
		/// <para>Gets the configuration settings for Automatic Updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>The returned interface can be used to change the current settings and to read the current settings.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdates-get_settings HRESULT get_Settings(
		// IAutomaticUpdatesSettings **retval );
		[DispId(1610743813)]
		new IAutomaticUpdatesSettings Settings
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether all the components that Automatic Updates requires are available.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value><see langword="true"/> if all the components that Automatic Updates requires are available; otherwise, <see langword="false"/>.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdates-get_serviceenabled HRESULT
		// get_ServiceEnabled( VARIANT_BOOL *retval );
		[DispId(1610743814)]
		new bool ServiceEnabled
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
			get;
		}

		/// <summary>Enables all the components that Automatic Updates requires.</summary>
		/// <remarks>
		/// <para>This method requires administrator permissions.</para>
		/// <para>This method returns <c>WU_E_AU_NOSERVICE</c> if Automatic Updates is disabled, initializing, uninitializing, or not configured.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdates-enableservice HRESULT EnableService();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
		new void EnableService();

		/// <summary>Returns a pointer to an <c>IAutomaticUpdatesResults</c> interface.</summary>
		/// <returns>A pointer to an <c>IAutomaticUpdatesResults</c> interface.</returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/bb513699(v=vs.85) HRESULT Results( [out]
		// IAutomaticUpdatesResults **retval );
		[DispId(1610809345)]
		IAutomaticUpdatesResults Results
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	/// <summary>Contains the read-only properties that describe Automatic Updates.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iautomaticupdatesresults
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IAutomaticUpdatesResults")]
	[ComImport, Guid("E7A4D634-7942-4DD9-A111-82228BA33901")]
	public interface IAutomaticUpdatesResults
	{
		/// <summary>Gets the last time and Coordinated Universal Time (UTC) date when AutomaticUpdates successfully searched for updates.</summary>
		/// <value>
		/// If the date-time for the last successful update search is not known, the <c>vt</c> field (see [MS-OAUT] section 2.2.29.1), MUST
		/// be set to VT_EMPTY as specified in [MS-OAUT] section 2.2.7. Otherwise, the <c>vt</c> member MUST be set to VT_DATE (see [MS-OAUT]
		/// section 2.2.7, and the date-time of the last successful update search MUST be stored in the <c>date</c> field.
		/// </value>
		// https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-uamg/edb37e74-f222-4983-b1fc-4d9694386619
		[DispId(1610743809)]
		object LastSearchSuccessDate
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// Gets the last time and Coordinated Universal Time (UTC) date when Automatic Updates successfully installed any updates, even if
		/// some failures occurred.
		/// </summary>
		/// <value>The last installation success date.</value>
		/// <remarks>
		/// Calls to LastInstallationSuccessDate by public users do not update this property. Only the AutomaticUpdates object will update
		/// this property.
		/// </remarks>
		[DispId(1610743810)]
		object LastInstallationSuccessDate
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	/// <summary>Contains the settings that are available in Automatic Updates.</summary>
	/// <remarks>
	/// <para>
	/// <c>Note</c>  Starting with Windows 8 and Windows Server 2012, ScheduledInstallationDay and ScheduledInstallationTime are not
	/// supported and will return unreliable values. If you try to modify these properties, the operation will appear to succeed but will
	/// have no effect.
	/// </para>
	/// <para>
	/// <c>Note</c>  On Windows RT, you can no longer use the IAutomaticUpdatesSettings::Save method to configure Windows Update settings
	/// programmatically. The configuration operation fails if you use <c>Save</c> to set any value other than 4 (aunlScheduledInstallation).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iautomaticupdatessettings
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IAutomaticUpdatesSettings")]
	[ComImport, Guid("2EE48F22-AF3C-405F-8970-F71BE12EE9A2")]
	public interface IAutomaticUpdatesSettings
	{
		/// <summary>
		/// <para>Gets and sets how users are notified about Automatic Update events.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_notificationlevel HRESULT
		// get_NotificationLevel( AutomaticUpdatesNotificationLevel *retval );
		[DispId(1610743809), ComAliasName("WUApiLib.AutomaticUpdatesNotificationLevel")]
		AutomaticUpdatesNotificationLevel NotificationLevel
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: ComAliasName("WUApiLib.AutomaticUpdatesNotificationLevel")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[param: In, ComAliasName("WUApiLib.AutomaticUpdatesNotificationLevel")]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the Automatic Update settings are read-only.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para><c>ReadOnly</c> is <c>VARIANT_TRUE</c> if either of the following conditions is true:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The caller has insufficient security permissions to modify the Automatic Updates settings.</description>
		/// </item>
		/// <item>
		/// <description>The current settings are enforced by Group Policy.</description>
		/// </item>
		/// </list>
		/// <para>
		/// The caller can modify the settings in the IAutomaticUpdatesSettings interface only if <c>ReadOnly</c> is <c>VARIANT_FALSE</c>.
		/// The value of <c>ReadOnly</c> may change after calling Refresh.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_readonly HRESULT get_ReadOnly(
		// VARIANT_BOOL *retval );
		[DispId(1610743810)]
		bool ReadOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether Group Policy requires the Automatic Updates service.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_required HRESULT get_Required(
		// VARIANT_BOOL *retval );
		[DispId(1610743811)]
		bool Required
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
		}

		/// <summary>
		/// <para>Gets and sets the days of the week on which Automatic Updates installs or uninstalls updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>The value of this property is ignored if the value of the NotificationLevel property is not <c>aunlScheduledInstallation</c>.</para>
		/// <para>
		/// <c>Note</c>  Starting with Windows 8 and Windows Server 2012, <c>ScheduledInstallationDay</c> is not supported and will return
		/// unreliable values. If you try to modify <c>ScheduledInstallationDay</c>, the operation will appear to succeed but will have no effect.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_scheduledinstallationday HRESULT
		// get_ScheduledInstallationDay( AutomaticUpdatesScheduledInstallationDay *retval );
		[DispId(1610743812), ComAliasName("WUApiLib.AutomaticUpdatesScheduledInstallationDay")]
		AutomaticUpdatesScheduledInstallationDay ScheduledInstallationDay
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[return: ComAliasName("WUApiLib.AutomaticUpdatesScheduledInstallationDay")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[param: In, ComAliasName("WUApiLib.AutomaticUpdatesScheduledInstallationDay")]
			set;
		}

		/// <summary>
		/// <para>Gets and sets the time at which Automatic Updates installs or uninstalls updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>The time is set by using the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Time</description>
		/// </listheader>
		/// <item>
		/// <description>0</description>
		/// <description>00:00</description>
		/// </item>
		/// <item>
		/// <description>1</description>
		/// <description>01:00</description>
		/// </item>
		/// <item>
		/// <description>2</description>
		/// <description>02:00</description>
		/// </item>
		/// <item>
		/// <description>3</description>
		/// <description>03:00</description>
		/// </item>
		/// <item>
		/// <description>4</description>
		/// <description>04:00</description>
		/// </item>
		/// <item>
		/// <description>5</description>
		/// <description>05:00</description>
		/// </item>
		/// <item>
		/// <description>6</description>
		/// <description>06:00</description>
		/// </item>
		/// <item>
		/// <description>7</description>
		/// <description>07:00</description>
		/// </item>
		/// <item>
		/// <description>8</description>
		/// <description>08:00</description>
		/// </item>
		/// <item>
		/// <description>9</description>
		/// <description>09:00</description>
		/// </item>
		/// <item>
		/// <description>10</description>
		/// <description>10:00</description>
		/// </item>
		/// <item>
		/// <description>11</description>
		/// <description>11:00</description>
		/// </item>
		/// <item>
		/// <description>12</description>
		/// <description>12:00</description>
		/// </item>
		/// <item>
		/// <description>13</description>
		/// <description>13:00</description>
		/// </item>
		/// <item>
		/// <description>14</description>
		/// <description>14:00</description>
		/// </item>
		/// <item>
		/// <description>15</description>
		/// <description>15:00</description>
		/// </item>
		/// <item>
		/// <description>16</description>
		/// <description>16:00</description>
		/// </item>
		/// <item>
		/// <description>17</description>
		/// <description>17:00</description>
		/// </item>
		/// <item>
		/// <description>18</description>
		/// <description>18:00</description>
		/// </item>
		/// <item>
		/// <description>19</description>
		/// <description>19:00</description>
		/// </item>
		/// <item>
		/// <description>20</description>
		/// <description>20:00</description>
		/// </item>
		/// <item>
		/// <description>21</description>
		/// <description>21:00</description>
		/// </item>
		/// <item>
		/// <description>22</description>
		/// <description>22:00</description>
		/// </item>
		/// <item>
		/// <description>23</description>
		/// <description>23:00</description>
		/// </item>
		/// </list>
		/// <para>The value of this property is ignored if the value of the NotificationLevel property is not <c>aunlScheduledInstallation</c>.</para>
		/// <para>
		/// <c>Note</c>  Starting with Windows 8 and Windows Server 2012, <c>ScheduledInstallationTime</c> is not supported and will return
		/// unreliable values. If you try to modify <c>ScheduledInstallationTime</c>, the operation will appear to succeed but will have no effect.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_scheduledinstallationtime HRESULT
		// get_ScheduledInstallationTime( LONG *retval );
		[DispId(1610743813)]
		int ScheduledInstallationTime
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			[param: In]
			set;
		}

		/// <summary>Retrieves the latest Automatic Updates settings.</summary>
		/// <remarks>
		/// <para>Calling <c>Refresh</c> resets any setting changes that have not been saved by using the Save method.</para>
		/// <para>
		/// <c>Note</c>  On Windows RT, you can no longer use the IAutomaticUpdatesSettings::Save method to configure Windows Update settings
		/// programmatically. The configuration operation fails if you use <c>Save</c> to set any value other than 4 (aunlScheduledInstallation).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-refresh HRESULT Refresh();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
		void Refresh();

		/// <summary>Applies the current Automatic Updates settings.</summary>
		/// <remarks>
		/// <para>Saving settings with a NotificationLevel value other than Disabled starts the Automatic Updates service.</para>
		/// <para>
		/// <c>Note</c>  On Windows RT, you can no longer use the <c>Save</c> method to configure Windows Update settings programmatically.
		/// The configuration operation fails if you use <c>Save</c> to set any value other than 4 (aunlScheduledInstallation).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-save HRESULT Save();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
		void Save();
	}

	/// <summary>Contains the settings that are available in Automatic Updates.</summary>
	/// <remarks>
	/// The <c>IAutomaticUpdatesSettings2</c> interface may require you to update the Windows Update Agent (WUA). For more information, see
	/// Updating Windows Update Agent.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iautomaticupdatessettings2
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IAutomaticUpdatesSettings2")]
	[ComImport, Guid("6ABC136A-C3CA-4384-8171-CB2B1E59B8DC")]
	public interface IAutomaticUpdatesSettings2 : IAutomaticUpdatesSettings
	{
		/// <summary>
		/// <para>Gets and sets how users are notified about Automatic Update events.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_notificationlevel HRESULT
		// get_NotificationLevel( AutomaticUpdatesNotificationLevel *retval );
		[DispId(1610743809), ComAliasName("WUApiLib.AutomaticUpdatesNotificationLevel")]
		new AutomaticUpdatesNotificationLevel NotificationLevel
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: ComAliasName("WUApiLib.AutomaticUpdatesNotificationLevel")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[param: In, ComAliasName("WUApiLib.AutomaticUpdatesNotificationLevel")]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the Automatic Update settings are read-only.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para><c>ReadOnly</c> is <c>VARIANT_TRUE</c> if either of the following conditions is true:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The caller has insufficient security permissions to modify the Automatic Updates settings.</description>
		/// </item>
		/// <item>
		/// <description>The current settings are enforced by Group Policy.</description>
		/// </item>
		/// </list>
		/// <para>
		/// The caller can modify the settings in the IAutomaticUpdatesSettings interface only if <c>ReadOnly</c> is <c>VARIANT_FALSE</c>.
		/// The value of <c>ReadOnly</c> may change after calling Refresh.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_readonly HRESULT get_ReadOnly(
		// VARIANT_BOOL *retval );
		[DispId(1610743810)]
		new bool ReadOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether Group Policy requires the Automatic Updates service.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_required HRESULT get_Required(
		// VARIANT_BOOL *retval );
		[DispId(1610743811)]
		new bool Required
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
		}

		/// <summary>
		/// <para>Gets and sets the days of the week on which Automatic Updates installs or uninstalls updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>The value of this property is ignored if the value of the NotificationLevel property is not <c>aunlScheduledInstallation</c>.</para>
		/// <para>
		/// <c>Note</c>  Starting with Windows 8 and Windows Server 2012, <c>ScheduledInstallationDay</c> is not supported and will return
		/// unreliable values. If you try to modify <c>ScheduledInstallationDay</c>, the operation will appear to succeed but will have no effect.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_scheduledinstallationday HRESULT
		// get_ScheduledInstallationDay( AutomaticUpdatesScheduledInstallationDay *retval );
		[DispId(1610743812), ComAliasName("WUApiLib.AutomaticUpdatesScheduledInstallationDay")]
		new AutomaticUpdatesScheduledInstallationDay ScheduledInstallationDay
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[return: ComAliasName("WUApiLib.AutomaticUpdatesScheduledInstallationDay")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[param: In, ComAliasName("WUApiLib.AutomaticUpdatesScheduledInstallationDay")]
			set;
		}

		/// <summary>
		/// <para>Gets and sets the time at which Automatic Updates installs or uninstalls updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>The time is set by using the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Time</description>
		/// </listheader>
		/// <item>
		/// <description>0</description>
		/// <description>00:00</description>
		/// </item>
		/// <item>
		/// <description>1</description>
		/// <description>01:00</description>
		/// </item>
		/// <item>
		/// <description>2</description>
		/// <description>02:00</description>
		/// </item>
		/// <item>
		/// <description>3</description>
		/// <description>03:00</description>
		/// </item>
		/// <item>
		/// <description>4</description>
		/// <description>04:00</description>
		/// </item>
		/// <item>
		/// <description>5</description>
		/// <description>05:00</description>
		/// </item>
		/// <item>
		/// <description>6</description>
		/// <description>06:00</description>
		/// </item>
		/// <item>
		/// <description>7</description>
		/// <description>07:00</description>
		/// </item>
		/// <item>
		/// <description>8</description>
		/// <description>08:00</description>
		/// </item>
		/// <item>
		/// <description>9</description>
		/// <description>09:00</description>
		/// </item>
		/// <item>
		/// <description>10</description>
		/// <description>10:00</description>
		/// </item>
		/// <item>
		/// <description>11</description>
		/// <description>11:00</description>
		/// </item>
		/// <item>
		/// <description>12</description>
		/// <description>12:00</description>
		/// </item>
		/// <item>
		/// <description>13</description>
		/// <description>13:00</description>
		/// </item>
		/// <item>
		/// <description>14</description>
		/// <description>14:00</description>
		/// </item>
		/// <item>
		/// <description>15</description>
		/// <description>15:00</description>
		/// </item>
		/// <item>
		/// <description>16</description>
		/// <description>16:00</description>
		/// </item>
		/// <item>
		/// <description>17</description>
		/// <description>17:00</description>
		/// </item>
		/// <item>
		/// <description>18</description>
		/// <description>18:00</description>
		/// </item>
		/// <item>
		/// <description>19</description>
		/// <description>19:00</description>
		/// </item>
		/// <item>
		/// <description>20</description>
		/// <description>20:00</description>
		/// </item>
		/// <item>
		/// <description>21</description>
		/// <description>21:00</description>
		/// </item>
		/// <item>
		/// <description>22</description>
		/// <description>22:00</description>
		/// </item>
		/// <item>
		/// <description>23</description>
		/// <description>23:00</description>
		/// </item>
		/// </list>
		/// <para>The value of this property is ignored if the value of the NotificationLevel property is not <c>aunlScheduledInstallation</c>.</para>
		/// <para>
		/// <c>Note</c>  Starting with Windows 8 and Windows Server 2012, <c>ScheduledInstallationTime</c> is not supported and will return
		/// unreliable values. If you try to modify <c>ScheduledInstallationTime</c>, the operation will appear to succeed but will have no effect.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_scheduledinstallationtime HRESULT
		// get_ScheduledInstallationTime( LONG *retval );
		[DispId(1610743813)]
		new int ScheduledInstallationTime
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			[param: In]
			set;
		}

		/// <summary>Retrieves the latest Automatic Updates settings.</summary>
		/// <remarks>
		/// <para>Calling <c>Refresh</c> resets any setting changes that have not been saved by using the Save method.</para>
		/// <para>
		/// <c>Note</c>  On Windows RT, you can no longer use the IAutomaticUpdatesSettings::Save method to configure Windows Update settings
		/// programmatically. The configuration operation fails if you use <c>Save</c> to set any value other than 4 (aunlScheduledInstallation).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-refresh HRESULT Refresh();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
		new void Refresh();

		/// <summary>Applies the current Automatic Updates settings.</summary>
		/// <remarks>
		/// <para>Saving settings with a NotificationLevel value other than Disabled starts the Automatic Updates service.</para>
		/// <para>
		/// <c>Note</c>  On Windows RT, you can no longer use the <c>Save</c> method to configure Windows Update settings programmatically.
		/// The configuration operation fails if you use <c>Save</c> to set any value other than 4 (aunlScheduledInstallation).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-save HRESULT Save();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
		new void Save();

		/// <summary>
		/// <para>
		/// Gets and sets a Boolean value that indicates whether to include optional or recommended updates when a search for updates and
		/// installation of updates is performed.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>Only administrators can set this property.</para>
		/// <para>
		/// The caller can modify the settings in the IAutomaticUpdatesSettings2 interface only if the ReadOnly property is
		/// <c>VARIANT_TRUE</c>. The <c>ReadOnly</c> property may change after the Refresh method is called.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings2-get_includerecommendedupdates
		// HRESULT get_IncludeRecommendedUpdates( VARIANT_BOOL *retval );
		[DispId(1610809345)]
		bool IncludeRecommendedUpdates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[param: In]
			set;
		}

		/// <summary>Determines whether a specific user or type of user has permission to perform a selected action.</summary>
		/// <param name="userType">An enumeration that indicates the type of user to verify permissions.</param>
		/// <param name="permissionType">An enumeration that indicates the user's permission level.</param>
		/// <returns>True if the user has the specified permission type; otherwise, false.</returns>
		/// <remarks>
		/// This method can be used to determine whether User Access Control (UAC) must be used to perform an action in the agent, which may
		/// obviate the need for prompting if the user type does not have permission to perform the action. For example, unless the agent has
		/// elevated permission, the ReadOnly property of the IAutomaticUpdatesSettings interface will always be <c>VARIANT_TRUE</c>.
		/// However, even after a user has been elevated, the NotificationLevel (for example) may still be read-only due to Group Policy
		/// settings. The <c>CheckPermission</c> method can determine this before elevation is done to prevent prompting in cases where the
		/// setting cannot be changed.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings2-checkpermission HRESULT
		// CheckPermission( [in] AutomaticUpdatesUserType userType, [in] AutomaticUpdatesPermissionType permissionType, VARIANT_BOOL
		// *userHasPermission );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809346)]
		bool CheckPermission([In][ComAliasName("WUApiLib.AutomaticUpdatesUserType")] AutomaticUpdatesUserType userType, [In][ComAliasName("WUApiLib.AutomaticUpdatesPermissionType")] AutomaticUpdatesPermissionType permissionType);
	}

	/// <summary>Contains the settings that are available in Automatic Updates.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iautomaticupdatessettings3
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IAutomaticUpdatesSettings3")]
	[ComImport, Guid("B587F5C3-F57E-485F-BBF5-0D181C5CD0DC")]
	public interface IAutomaticUpdatesSettings3 : IAutomaticUpdatesSettings2
	{
		/// <summary>
		/// <para>Gets and sets how users are notified about Automatic Update events.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_notificationlevel HRESULT
		// get_NotificationLevel( AutomaticUpdatesNotificationLevel *retval );
		[DispId(1610743809), ComAliasName("WUApiLib.AutomaticUpdatesNotificationLevel")]
		new AutomaticUpdatesNotificationLevel NotificationLevel
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: ComAliasName("WUApiLib.AutomaticUpdatesNotificationLevel")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[param: In, ComAliasName("WUApiLib.AutomaticUpdatesNotificationLevel")]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the Automatic Update settings are read-only.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para><c>ReadOnly</c> is <c>VARIANT_TRUE</c> if either of the following conditions is true:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The caller has insufficient security permissions to modify the Automatic Updates settings.</description>
		/// </item>
		/// <item>
		/// <description>The current settings are enforced by Group Policy.</description>
		/// </item>
		/// </list>
		/// <para>
		/// The caller can modify the settings in the IAutomaticUpdatesSettings interface only if <c>ReadOnly</c> is <c>VARIANT_FALSE</c>.
		/// The value of <c>ReadOnly</c> may change after calling Refresh.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_readonly HRESULT get_ReadOnly(
		// VARIANT_BOOL *retval );
		[DispId(1610743810)]
		new bool ReadOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether Group Policy requires the Automatic Updates service.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_required HRESULT get_Required(
		// VARIANT_BOOL *retval );
		[DispId(1610743811)]
		new bool Required
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
		}

		/// <summary>
		/// <para>Gets and sets the days of the week on which Automatic Updates installs or uninstalls updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>The value of this property is ignored if the value of the NotificationLevel property is not <c>aunlScheduledInstallation</c>.</para>
		/// <para>
		/// <c>Note</c>  Starting with Windows 8 and Windows Server 2012, <c>ScheduledInstallationDay</c> is not supported and will return
		/// unreliable values. If you try to modify <c>ScheduledInstallationDay</c>, the operation will appear to succeed but will have no effect.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_scheduledinstallationday HRESULT
		// get_ScheduledInstallationDay( AutomaticUpdatesScheduledInstallationDay *retval );
		[DispId(1610743812), ComAliasName("WUApiLib.AutomaticUpdatesScheduledInstallationDay")]
		new AutomaticUpdatesScheduledInstallationDay ScheduledInstallationDay
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[return: ComAliasName("WUApiLib.AutomaticUpdatesScheduledInstallationDay")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[param: In, ComAliasName("WUApiLib.AutomaticUpdatesScheduledInstallationDay")]
			set;
		}

		/// <summary>
		/// <para>Gets and sets the time at which Automatic Updates installs or uninstalls updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>The time is set by using the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Time</description>
		/// </listheader>
		/// <item>
		/// <description>0</description>
		/// <description>00:00</description>
		/// </item>
		/// <item>
		/// <description>1</description>
		/// <description>01:00</description>
		/// </item>
		/// <item>
		/// <description>2</description>
		/// <description>02:00</description>
		/// </item>
		/// <item>
		/// <description>3</description>
		/// <description>03:00</description>
		/// </item>
		/// <item>
		/// <description>4</description>
		/// <description>04:00</description>
		/// </item>
		/// <item>
		/// <description>5</description>
		/// <description>05:00</description>
		/// </item>
		/// <item>
		/// <description>6</description>
		/// <description>06:00</description>
		/// </item>
		/// <item>
		/// <description>7</description>
		/// <description>07:00</description>
		/// </item>
		/// <item>
		/// <description>8</description>
		/// <description>08:00</description>
		/// </item>
		/// <item>
		/// <description>9</description>
		/// <description>09:00</description>
		/// </item>
		/// <item>
		/// <description>10</description>
		/// <description>10:00</description>
		/// </item>
		/// <item>
		/// <description>11</description>
		/// <description>11:00</description>
		/// </item>
		/// <item>
		/// <description>12</description>
		/// <description>12:00</description>
		/// </item>
		/// <item>
		/// <description>13</description>
		/// <description>13:00</description>
		/// </item>
		/// <item>
		/// <description>14</description>
		/// <description>14:00</description>
		/// </item>
		/// <item>
		/// <description>15</description>
		/// <description>15:00</description>
		/// </item>
		/// <item>
		/// <description>16</description>
		/// <description>16:00</description>
		/// </item>
		/// <item>
		/// <description>17</description>
		/// <description>17:00</description>
		/// </item>
		/// <item>
		/// <description>18</description>
		/// <description>18:00</description>
		/// </item>
		/// <item>
		/// <description>19</description>
		/// <description>19:00</description>
		/// </item>
		/// <item>
		/// <description>20</description>
		/// <description>20:00</description>
		/// </item>
		/// <item>
		/// <description>21</description>
		/// <description>21:00</description>
		/// </item>
		/// <item>
		/// <description>22</description>
		/// <description>22:00</description>
		/// </item>
		/// <item>
		/// <description>23</description>
		/// <description>23:00</description>
		/// </item>
		/// </list>
		/// <para>The value of this property is ignored if the value of the NotificationLevel property is not <c>aunlScheduledInstallation</c>.</para>
		/// <para>
		/// <c>Note</c>  Starting with Windows 8 and Windows Server 2012, <c>ScheduledInstallationTime</c> is not supported and will return
		/// unreliable values. If you try to modify <c>ScheduledInstallationTime</c>, the operation will appear to succeed but will have no effect.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-get_scheduledinstallationtime HRESULT
		// get_ScheduledInstallationTime( LONG *retval );
		[DispId(1610743813)]
		new int ScheduledInstallationTime
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			[param: In]
			set;
		}

		/// <summary>Retrieves the latest Automatic Updates settings.</summary>
		/// <remarks>
		/// <para>Calling <c>Refresh</c> resets any setting changes that have not been saved by using the Save method.</para>
		/// <para>
		/// <c>Note</c>  On Windows RT, you can no longer use the IAutomaticUpdatesSettings::Save method to configure Windows Update settings
		/// programmatically. The configuration operation fails if you use <c>Save</c> to set any value other than 4 (aunlScheduledInstallation).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-refresh HRESULT Refresh();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
		new void Refresh();

		/// <summary>Applies the current Automatic Updates settings.</summary>
		/// <remarks>
		/// <para>Saving settings with a NotificationLevel value other than Disabled starts the Automatic Updates service.</para>
		/// <para>
		/// <c>Note</c>  On Windows RT, you can no longer use the <c>Save</c> method to configure Windows Update settings programmatically.
		/// The configuration operation fails if you use <c>Save</c> to set any value other than 4 (aunlScheduledInstallation).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings-save HRESULT Save();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
		new void Save();

		/// <summary>
		/// <para>
		/// Gets and sets a Boolean value that indicates whether to include optional or recommended updates when a search for updates and
		/// installation of updates is performed.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>Only administrators can set this property.</para>
		/// <para>
		/// The caller can modify the settings in the IAutomaticUpdatesSettings2 interface only if the ReadOnly property is
		/// <c>VARIANT_TRUE</c>. The <c>ReadOnly</c> property may change after the Refresh method is called.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings2-get_includerecommendedupdates
		// HRESULT get_IncludeRecommendedUpdates( VARIANT_BOOL *retval );
		[DispId(1610809345)]
		new bool IncludeRecommendedUpdates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[param: In]
			set;
		}

		/// <summary>Determines whether a specific user or type of user has permission to perform a selected action.</summary>
		/// <param name="userType">An enumeration that indicates the type of user to verify permissions.</param>
		/// <param name="permissionType">An enumeration that indicates the user's permission level.</param>
		/// <returns>True if the user has the specified permission type; otherwise, false.</returns>
		/// <remarks>
		/// This method can be used to determine whether User Access Control (UAC) must be used to perform an action in the agent, which may
		/// obviate the need for prompting if the user type does not have permission to perform the action. For example, unless the agent has
		/// elevated permission, the ReadOnly property of the IAutomaticUpdatesSettings interface will always be <c>VARIANT_TRUE</c>.
		/// However, even after a user has been elevated, the NotificationLevel (for example) may still be read-only due to Group Policy
		/// settings. The <c>CheckPermission</c> method can determine this before elevation is done to prevent prompting in cases where the
		/// setting cannot be changed.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings2-checkpermission HRESULT
		// CheckPermission( [in] AutomaticUpdatesUserType userType, [in] AutomaticUpdatesPermissionType permissionType, VARIANT_BOOL
		// *userHasPermission );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809346)]
		new bool CheckPermission([In][ComAliasName("WUApiLib.AutomaticUpdatesUserType")] AutomaticUpdatesUserType userType, [In][ComAliasName("WUApiLib.AutomaticUpdatesPermissionType")] AutomaticUpdatesPermissionType permissionType);

		/// <summary>
		/// <para>
		/// Gets and sets a Boolean value that indicates whether non-administrators can perform some update-related actions without
		/// administrator approval.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The NonAdministratorsElevated property controls whether non-administrative users are allowed to perform some additional actions
		/// without elevation. It is equivalent to the “Allow all users to install updates on this computer” check box in the Windows Update
		/// settings dialog.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings3-put_nonadministratorselevated
		// HRESULT put_NonAdministratorsElevated( VARIANT_BOOL value );
		[DispId(1610874881)]
		bool NonAdministratorsElevated
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874881)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874881)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Not supported.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iautomaticupdatessettings3-get_featuredupdatesenabled HRESULT
		// get_FeaturedUpdatesEnabled( VARIANT_BOOL *retval );
		[DispId(1610874882)]
		bool FeaturedUpdatesEnabled
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874882)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874882)]
			[param: In]
			set;
		}
	}

	/// <summary>Represents the category to which an update belongs.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-icategory
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.ICategory")]
	[ComImport, Guid("81DDC1B8-9D35-47A6-B471-5B80F519223B"), DefaultMember("Name")]
	public interface ICategory
	{
		/// <summary>
		/// <para>Gets the localized name of the category.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A Categories property exists for the IUpdate interface. And, a Categories property exists for the IUpdateHistoryEntry2 interface.
		/// Therefore, the information that is used by the localized properties of the ICategory interface depends on the Windows Update
		/// Agent (WUA) object that owns the <c>ICategory</c> interface.
		/// </para>
		/// <para>
		/// If the ICategory interface is returned from the Categories property of IUpdate, the <c>ICategory</c> interface follows the
		/// localization rules of the <c>IUpdate</c> interface. In this case, if the IUpdateSearcher interface is created by using the
		/// IUpdateSession::CreateUpdateSearcher method, the information that this property returns is for the language that is specified by
		/// the UserLocale property of the IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of the IUpdateSession2 interface, or if the IUpdateSearcher
		/// interface is not created by using the IUpdateSession::CreateUpdateSearcher method, the information that this property returns is
		/// for the default user interface (UI) language of the user. If the default UI language of the user is unavailable, WUA uses the
		/// default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// <para>
		/// If the ICategory interface is returned from the Categories property of the IUpdateHistoryEntry2 interface, the <c>ICategory</c>
		/// interface follows the localization rules of the <c>IUpdateHistoryEntry2</c> interface. The information that this property returns
		/// is for the default UI language of the user. If the default UI language of the user is unavailable, WUA uses the default UI
		/// language of the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the
		/// update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-icategory-get_name HRESULT get_Name( BSTR *retval );
		[DispId(0)]
		string Name
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the identifier of the category.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-icategory-get_categoryid HRESULT get_CategoryID( BSTR *retval );
		[DispId(1610743809)]
		string CategoryID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface collection that contains the child categories of this category.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-icategory-get_children HRESULT get_Children(
		// ICategoryCollection **retval );
		[DispId(1610743810)]
		ICategoryCollection Children
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the description of the category.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A Categories property exists for the IUpdate interface. And, a Categories property exists for the IUpdateHistoryEntry2 interface.
		/// Therefore, the information that is used by the localized properties of the ICategory interface depends on the Windows Update
		/// Agent (WUA) object that owns the <c>ICategory</c> interface.
		/// </para>
		/// <para>
		/// If the ICategory interface is returned from the Categories property of IUpdate, the <c>ICategory</c> interface follows the
		/// localization rules of the <c>IUpdate</c> interface. In this case, if the IUpdateSearcher interface is created by using the
		/// IUpdateSession::CreateUpdateSearcher method, the information that this property returns is for the language that is specified by
		/// the UserLocale property of the IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of the IUpdateSession2 interface, or if the IUpdateSearcher
		/// interface is not created by using the IUpdateSession::CreateUpdateSearcher method, the information that this property returns is
		/// for the default user interface (UI) language of the user. If the default UI language of the user is unavailable, WUA uses the
		/// default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// <para>
		/// If the ICategory interface is returned from the Categories property of the IUpdateHistoryEntry2 interface, the <c>ICategory</c>
		/// interface follows the localization rules of the <c>IUpdateHistoryEntry2</c> interface. The information that this property returns
		/// is for the default UI language of the user. If the default UI language of the user is unavailable, WUA uses the default UI
		/// language of the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the
		/// update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-icategory-get_description HRESULT get_Description( BSTR *retval );
		[DispId(1610743811)]
		string Description
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains information about the image that is associated with the category.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A Categories property exists for the IUpdate interface. And, a Categories property exists for the IUpdateHistoryEntry2 interface.
		/// Therefore, the information that is used by the localized properties of the ICategory interface depends on the Windows Update
		/// Agent (WUA) object that owns the <c>ICategory</c> interface.
		/// </para>
		/// <para>
		/// If the ICategory interface is returned from the Categories property of IUpdate, the <c>ICategory</c> interface follows the
		/// localization rules of the <c>IUpdate</c> interface. In this case, if the IUpdateSearcher interface is created by using the
		/// IUpdateSession::CreateUpdateSearcher method, the information that this property returns is for the language that is specified by
		/// the UserLocale property of the IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of the IUpdateSession2 interface, or if the IUpdateSearcher
		/// interface is not created by using the IUpdateSession::CreateUpdateSearcher method, the information that this property returns is
		/// for the default user interface (UI) language of the user. If the default UI language of the user is unavailable, WUA uses the
		/// default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// <para>
		/// If the ICategory interface is returned from the Categories property of the IUpdateHistoryEntry2 interface, the <c>ICategory</c>
		/// interface follows the localization rules of the <c>IUpdateHistoryEntry2</c> interface. The information that this property returns
		/// is for the default UI language of the user. If the default UI language of the user is unavailable, WUA uses the default UI
		/// language of the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the
		/// update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-icategory-get_image HRESULT get_Image( IImageInformation
		// **retval );
		[DispId(1610743812)]
		IImageInformation Image
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the recommended display order of this category among its sibling categories.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-icategory-get_order HRESULT get_Order( LONG *retval );
		[DispId(1610743813)]
		int Order
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that describes the parent category of this category.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-icategory-get_parent HRESULT get_Parent( ICategory **retval );
		[DispId(1610743814)]
		ICategory Parent
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the type of the category.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>The following list identifies the possible category types:</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-icategory-get_type HRESULT get_Type( BSTR *retval );
		[DispId(1610743815)]
		string Type
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains a collection of updates that immediately belong to the category.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>The returned updates are applicable to the computer. They may or may not be installed on that computer.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-icategory-get_updates HRESULT get_Updates( IUpdateCollection
		// **retval );
		[DispId(1610743816)]
		IUpdateCollection Updates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	/// <summary>The <c>ICategoryCollection</c> interface represents an ordered read-only list of ICategory interfaces.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-icategorycollection
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.ICategoryCollection")]
	[ComImport, Guid("3A56BFB8-576C-43F7-9335-FE4838FD7E37")]
	public interface ICategoryCollection : IEnumerable
	{
		/// <summary>
		/// <para>Gets an ICategory interface from the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="index">The item index.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-icategorycollection-get_item HRESULT get_Item( LONG index,
		// ICategory **retval );
		[DispId(0)]
		ICategory this[[In] int index]
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an IEnumVARIANT interface that can be used to enumerate the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-icategorycollection-get__newenum HRESULT get__NewEnum( IUnknown
		// **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();

		/// <summary>
		/// <para>Gets the number of elements in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-icategorycollection-get_count HRESULT get_Count( LONG *retval );
		[DispId(1610743809)]
		int Count
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}
	}

	/// <summary>
	/// Provides the callback that is used when an asynchronous download is completed. This interface is implemented by programmers who call
	/// the IUpdateDownloader::BeginDownload method.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-idownloadcompletedcallback
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IDownloadCompletedCallback")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("77254866-9F5B-4C8E-B9E2-C77A8530D64B")]
	public interface IDownloadCompletedCallback
	{
		/// <summary>Notifies the caller that the download is complete.</summary>
		/// <param name="downloadJob">An IDownloadJob interface that contains download information.</param>
		/// <param name="callbackArgs">This parameter is reserved for future use and can be ignored.</param>
		/// <returns>Returns <c>S_OK</c> if successful. Otherwise, returns a COM or Windows error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadcompletedcallback-invoke
		// HRESULT Invoke( [in] IDownloadJob *downloadJob, [in] IDownloadCompletedCallbackArgs *callbackArgs );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT Invoke([In][MarshalAs(UnmanagedType.Interface)] IDownloadJob downloadJob, [In][MarshalAs(UnmanagedType.Interface)] IDownloadCompletedCallbackArgs callbackArgs);
	}

	/// <summary>
	/// Contains information about the completion of a download. This interface acts as a parameter to the IDownloadCompletedCallback
	/// delegate. The download and installation of the update is asynchronous.
	/// </summary>
	/// <remarks>The <c>IDownloadCompletedCallbackArgs</c> interface is reserved for future use. It has no properties or methods.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-idownloadcompletedcallbackargs
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IDownloadCompletedCallbackArgs")]
	[ComImport, Guid("FA565B23-498C-47A0-979D-E7D5B1813360")]
	public interface IDownloadCompletedCallbackArgs
	{
	}

	/// <summary>
	/// Contains properties and methods that are available to a download operation. This interface is returned by the
	/// IUpdateDownloader.BeginDownload method.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-idownloadjob
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IDownloadJob")]
	[ComImport, Guid("C574DE85-7358-43F6-AAE8-8697E62D8BA7")]
	public interface IDownloadJob
	{
		/// <summary>
		/// <para>Gets the caller-specific state object that is passed to the IUpdateDownloader.BeginDownload method.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This state object can be used by the caller to identify a particular download. Or, this state object can be used by the caller to
		/// pass information from the caller to the implementation of the IDownloadProgressChangedCallback or IDownloadCompletedCallback interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadjob-get_asyncstate HRESULT get_AsyncState( VARIANT
		// *retval );
		[DispId(1610743809)]
		object AsyncState
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>Gets the setting that indicates whether the call to IUpdateDownloader.BeginDownload was processed completely.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadjob-get_iscompleted HRESULT get_IsCompleted(
		// VARIANT_BOOL *retval );
		[DispId(1610743810)]
		bool IsCompleted
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains a read-only collection of the updates that are specified in a download.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadjob-get_updates HRESULT get_Updates( IUpdateCollection
		// **retval );
		[DispId(1610743811)]
		IUpdateCollection Updates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>Waits for an asynchronous operation to be completed and releases all callbacks.</summary>
		/// <remarks>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadjob-cleanup HRESULT CleanUp();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
		void CleanUp();

		/// <summary>Returns an IDownloadProgress interface that describes the current progress of a download.</summary>
		/// <returns>An IDownloadProgress interface that describes the current progress of a download.</returns>
		/// <remarks>
		/// You must make repeated calls to <c>GetProgress</c> to track the progress of a download. You must do this because the
		/// IDownloadProgress interface is not automatically updated during a download.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadjob-getprogress HRESULT GetProgress( [out]
		// IDownloadProgress **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IDownloadProgress GetProgress();

		/// <summary>Makes a request to end an asynchronous download.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadjob-requestabort HRESULT RequestAbort();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
		void RequestAbort();
	}

	/// <summary>Represents the progress of an asynchronous download operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-idownloadprogress
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IDownloadProgress")]
	[ComImport, Guid("D31A5BAC-F719-4178-9DBB-5E2CB47FD18A")]
	public interface IDownloadProgress
	{
		/// <summary>
		/// <para>
		/// Gets a string that specifies how much data has been transferred for the content file or files of the update that is being
		/// downloaded, in bytes.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadprogress-get_currentupdatebytesdownloaded HRESULT
		// get_CurrentUpdateBytesDownloaded( DECIMAL *retval );
		[DispId(1610743809)]
		decimal CurrentUpdateBytesDownloaded
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a string that estimates how much data should be transferred for the content file or files of the update that is being
		/// downloaded, in bytes.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadprogress-get_currentupdatebytestodownload HRESULT
		// get_CurrentUpdateBytesToDownload( DECIMAL *retval );
		[DispId(1610743810)]
		decimal CurrentUpdateBytesToDownload
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a zero-based index value that specifies the update that is currently being downloaded when multiple updates have been selected.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadprogress-get_currentupdateindex HRESULT
		// get_CurrentUpdateIndex( LONG *retval );
		[DispId(1610743811)]
		int CurrentUpdateIndex
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
		}

		/// <summary>
		/// <para>Gets an estimate of the percentage of all the updates that have been downloaded.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadprogress-get_percentcomplete HRESULT
		// get_PercentComplete( LONG *retval );
		[DispId(1610743812)]
		int PercentComplete
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			get;
		}

		/// <summary>
		/// <para>Gets a string that specifies the total amount of data that has been downloaded, in bytes.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadprogress-get_totalbytesdownloaded HRESULT
		// get_TotalBytesDownloaded( DECIMAL *retval );
		[DispId(1610743813)]
		decimal TotalBytesDownloaded
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			get;
		}

		/// <summary>
		/// <para>Gets a string that represents the estimate of the total amount of data that will be downloaded, in bytes.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadprogress-get_totalbytestodownload HRESULT
		// get_TotalBytesToDownload( DECIMAL *retval );
		[DispId(1610743814)]
		decimal TotalBytesToDownload
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
			get;
		}

		/// <summary>Returns the result of the download of a specified update.</summary>
		/// <param name="updateIndex">A zero-based index value that specifies an update.</param>
		/// <returns>An IUpdateDownloadResult interface that contains information about the specified update.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadprogress-getupdateresult HRESULT GetUpdateResult( [in]
		// LONG updateIndex, [out] IUpdateDownloadResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateDownloadResult GetUpdateResult([In] int updateIndex);

		/// <summary>
		/// <para>Gets a DownloadPhase enumeration value that specifies the phase of the download that is currently in progress.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadprogress-get_currentupdatedownloadphase HRESULT
		// get_CurrentUpdateDownloadPhase( DownloadPhase *retval );
		[DispId(1610743816), ComAliasName("WUApiLib.DownloadPhase")]
		DownloadPhase CurrentUpdateDownloadPhase
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
			[return: ComAliasName("WUApiLib.DownloadPhase")]
			get;
		}

		/// <summary>
		/// <para>Gets an estimate of the percentage of the current update that has been downloaded.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadprogress-get_currentupdatepercentcomplete HRESULT
		// get_CurrentUpdatePercentComplete( LONG *retval );
		[DispId(1610743817)]
		int CurrentUpdatePercentComplete
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743817)]
			get;
		}
	}

	/// <summary>
	/// Handles the notification that indicates a change in the progress of an asynchronous download operation. This interface is implemented
	/// by programmers who call the IUpdateDownloader.BeginDownload method.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-idownloadprogresschangedcallback
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IDownloadProgressChangedCallback")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("8C3F1CDD-6173-4591-AEBD-A56A53CA77C1")]
	public interface IDownloadProgressChangedCallback
	{
		/// <summary>
		/// Handles the notification of a change in the progress of an asynchronous download that was initiated by calling the
		/// IUpdateDownloader.BeginDownload method.
		/// </summary>
		/// <param name="downloadJob">An IDownloadJob interface that contains download information.</param>
		/// <param name="callbackArgs">An IDownloadProgressChangedCallbackArgs interface that contains download progress data.</param>
		/// <returns>Returns <c>S_OK</c> if successful. Otherwise, returns a COM or Windows error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadprogresschangedcallback-invoke
		// HRESULT Invoke( [in] IDownloadJob *downloadJob, [in] IDownloadProgressChangedCallbackArgs *callbackArgs );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT Invoke([In][MarshalAs(UnmanagedType.Interface)] IDownloadJob downloadJob, [In][MarshalAs(UnmanagedType.Interface)] IDownloadProgressChangedCallbackArgs callbackArgs);
	}

	/// <summary>Contains information about the change in the progress of an asynchronous download operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-idownloadprogresschangedcallbackargs
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IDownloadProgressChangedCallbackArgs")]
	[ComImport, Guid("324FF2C6-4981-4B04-9412-57481745AB24")]
	public interface IDownloadProgressChangedCallbackArgs
	{
		/// <summary>
		/// <para>Gets an interface that contains the progress of the asynchronous download at the time that the callback was made.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadprogresschangedcallbackargs-get_progress HRESULT
		// get_Progress( IDownloadProgress **retval );
		[DispId(1610743809)]
		IDownloadProgress Progress
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	/// <summary>The <c>IDownloadResult</c> interface represents the result of a download operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-idownloadresult
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IDownloadResult")]
	[ComImport, Guid("DAA4FDD0-4727-4DBE-A1E7-745DCA317144")]
	public interface IDownloadResult
	{
		/// <summary>
		/// <para>Gets the exception code number if an exception code number is raised during the download.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadresult-get_hresult HRESULT get_HResult( LONG *retval );
		[DispId(1610743809)]
		HRESULT HResult
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>Gets an OperationResultCode enumeration that specifies the result of the download.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadresult-get_resultcode HRESULT get_ResultCode(
		// OperationResultCode *retval );
		[ComAliasName("WUApiLib.OperationResultCode"), DispId(1610743810)]
		OperationResultCode ResultCode
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: ComAliasName("WUApiLib.OperationResultCode")]
			get;
		}

		/// <summary>Returns an IUpdateDownloadResult interface that contains the download information for a specified update.</summary>
		/// <param name="updateIndex">The index of the update.</param>
		/// <returns>An IUpdateDownloadResult interface that contains the results for the specified update.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-idownloadresult-getupdateresult HRESULT GetUpdateResult( [in]
		// LONG updateIndex, [out] IUpdateDownloadResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateDownloadResult GetUpdateResult([In] int updateIndex);
	}

	/// <summary>Contains information about a localized image that is associated with an update or a category.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iimageinformation
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IImageInformation")]
	[ComImport, Guid("7C907864-346C-4AEB-8F3F-57DA289F969F")]
	public interface IImageInformation
	{
		/// <summary>
		/// <para>Gets the alternate text for the image.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iimageinformation-get_alttext HRESULT get_AltText( BSTR *retval );
		[DispId(1610743809)]
		string AltText
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the height of the image, in pixels.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iimageinformation-get_height HRESULT get_Height( LONG *retval );
		[DispId(1610743810)]
		int Height
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>Gets the source location of the image.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iimageinformation-get_source HRESULT get_Source( BSTR *retval );
		[DispId(1610743811)]
		string Source
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the width of the image, in pixels.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iimageinformation-get_width HRESULT get_Width( LONG *retval );
		[DispId(1610743812)]
		int Width
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			get;
		}
	}

	/// <summary>Records the result for an update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iinstallationagent
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IInstallationAgent")]
	[ComImport, Guid("925CBC18-A2EA-4648-BF1C-EC8BADCFE20A"), CoClass(typeof(InstallationAgent))]
	public interface IInstallationAgent
	{
		/// <summary>Records the result for an update. The result is specified by an IStringCollection object.</summary>
		/// <param name="installationResultCookie">A string value that identifies the result cookie.</param>
		/// <param name="hresult">The identifier of the result.</param>
		/// <param name="extendedReportingData">
		/// An IStringCollection interface that represents a collection of strings that contain the result for an update.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationagent-recordinstallationresult HRESULT
		// RecordInstallationResult( [in] BSTR installationResultCookie, [in] LONG hresult, [in] IStringCollection *extendedReportingData );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
		void RecordInstallationResult([In][MarshalAs(UnmanagedType.BStr)] string installationResultCookie, [In] HRESULT hresult, [In][MarshalAs(UnmanagedType.Interface)] IStringCollection extendedReportingData);
	}

	/// <summary>Represents the installation and uninstallation options of an update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iinstallationbehavior
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IInstallationBehavior")]
	[ComImport, Guid("D9A59339-E245-4DBD-9686-4D5763E39624")]
	public interface IInstallationBehavior
	{
		/// <summary>
		/// <para>Gets a Boolean value thast indicates whether the installation or uninstallation of an update can prompt for user input.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationbehavior-get_canrequestuserinput HRESULT
		// get_CanRequestUserInput( VARIANT_BOOL *retval );
		[DispId(1610743809)]
		bool CanRequestUserInput
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets an InstallationImpact enumeration that indicates how the installation or uninstallation of the update affects the computer.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationbehavior-get_impact HRESULT get_Impact(
		// InstallationImpact *retval );
		[ComAliasName("WUApiLib.InstallationImpact"), DispId(1610743810)]
		InstallationImpact Impact
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: ComAliasName("WUApiLib.InstallationImpact")]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets an InstallationRebootBehavior enumeration that specifies the restart behavior that occurs when you install or uninstall the update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationbehavior-get_rebootbehavior HRESULT
		// get_RebootBehavior( InstallationRebootBehavior *retval );
		[DispId(1610743811), ComAliasName("WUApiLib.InstallationRebootBehavior")]
		InstallationRebootBehavior RebootBehavior
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: ComAliasName("WUApiLib.InstallationRebootBehavior")]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the installation or uninstallation of an update requires network connectivity.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationbehavior-get_requiresnetworkconnectivity HRESULT
		// get_RequiresNetworkConnectivity( VARIANT_BOOL *retval );
		[DispId(1610743812)]
		bool RequiresNetworkConnectivity
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			get;
		}
	}

	/// <summary>
	/// Handles the notification that indicates that an asynchronous installation or uninstallation is complete. This interface is
	/// implemented by programmers who call the IUpdateInstaller.BeginInstall or IUpdateInstaller.BeginUninstall methods.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iinstallationcompletedcallback
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IInstallationCompletedCallback")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("45F4F6F3-D602-4F98-9A8A-3EFA152AD2D3")]
	public interface IInstallationCompletedCallback
	{
		/// <summary>
		/// Handles the notification of the completion of an asynchronous installation or uninstallation that is initiated by a call to
		/// IUpdateInstaller.BeginInstall or IUpdateInstaller.BeginUninstall.
		/// </summary>
		/// <param name="installationJob">An IInstallationJob interface that contains the installation information.</param>
		/// <param name="callbackArgs">This parameter is reserved for future use and can be ignored.</param>
		/// <returns>Returns <c>S_OK</c> if successful. Otherwise, returns a COM or Windows error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationcompletedcallback-invoke HRESULT Invoke( [in]
		// IInstallationJob *installationJob, [in] IInstallationCompletedCallbackArgs *callbackArgs );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT Invoke([In][MarshalAs(UnmanagedType.Interface)] IInstallationJob installationJob, [In][MarshalAs(UnmanagedType.Interface)] IInstallationCompletedCallbackArgs? callbackArgs);
	}

	/// <summary>
	/// Contains information about the completion of an installation and acts as a parameter to the IInstallationCompletedCallback delegate.
	/// The download and installation of the update is asynchronous.
	/// </summary>
	/// <remarks>The <c>IInstallationCompletedCallbackArgs</c> interface is reserved for future use. It has no properties or methods.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iinstallationcompletedcallbackargs
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IInstallationCompletedCallbackArgs")]
	[ComImport, Guid("250E2106-8EFB-4705-9653-EF13C581B6A1")]
	public interface IInstallationCompletedCallbackArgs
	{
	}

	/// <summary>
	/// The <c>IInstallationJob</c> interface contains properties and methods that are available to an installation or uninstallation operation.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iinstallationjob
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IInstallationJob")]
	[ComImport, Guid("5C209F0B-BAD5-432A-9556-4699BED2638A")]
	public interface IInstallationJob
	{
		/// <summary>
		/// <para>
		/// Gets the caller-specific state object that is passed to the IUpdateInstaller.BeginInstall method or to the
		/// IUpdateInstaller.BeginUninstall method.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This state object can be used by the caller to identify a particular download or to pass information from the caller to the
		/// implementation of the IInstallationProgressChangedCallback interface or the IInstallationCompletedCallback interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationjob-get_asyncstate HRESULT get_AsyncState( VARIANT
		// *retval );
		[DispId(1610743809)]
		object AsyncState
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a value that indicates whether a call to the IUpdateInstaller.BeginInstall or IUpdateInstaller.BeginUninstall method is
		/// completely processed.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationjob-get_iscompleted HRESULT get_IsCompleted(
		// VARIANT_BOOL *retval );
		[DispId(1610743810)]
		bool IsCompleted
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains a read-only collection of the updates that are specified in the installation or uninstallation.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationjob-get_updates HRESULT get_Updates(
		// IUpdateCollection **retval );
		[DispId(1610743811)]
		IUpdateCollection Updates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>Waits for an asynchronous operation to be completed and then releases all the callbacks.</summary>
		/// <remarks>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationjob-cleanup HRESULT CleanUp();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
		void CleanUp();

		/// <summary>Returns an IInstallationProgress interface that describes the current progress of an installation or uninstallation.</summary>
		/// <returns>An IInstallationProgress interface that describes the current progress of an installation or uninstallation.</returns>
		/// <remarks>
		/// You must make repeated calls to the <c>GetProgress</c> method to track the progress of a download. You must do this because the
		/// IUpdateInstallationResult interface is not automatically updated during a download.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationjob-getprogress HRESULT GetProgress( [out]
		// IInstallationProgress **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IInstallationProgress GetProgress();

		/// <summary>Makes a request to cancel the installation or uninstallation.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationjob-requestabort HRESULT RequestAbort();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
		void RequestAbort();
	}

	/// <summary>Represents the progress of an asynchronous installation or uninstallation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iinstallationprogress
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IInstallationProgress")]
	[ComImport, Guid("345C8244-43A3-4E32-A368-65F073B76F36")]
	public interface IInstallationProgress
	{
		/// <summary>
		/// <para>
		/// Gets a zero-based index value. This value specifies the update that is currently being installed or uninstalled when multiple
		/// updates have been selected.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationprogress-get_currentupdateindex HRESULT
		// get_CurrentUpdateIndex( LONG *retval );
		[DispId(1610743809)]
		int CurrentUpdateIndex
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>Gets how far the installation or uninstallation process for the current update has progressed, as a percentage.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationprogress-get_currentupdatepercentcomplete HRESULT
		// get_CurrentUpdatePercentComplete( LONG *retval );
		[DispId(1610743810)]
		int CurrentUpdatePercentComplete
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>Gets how far the overall installation or uninstallation process has progressed, as a percentage.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationprogress-get_percentcomplete HRESULT
		// get_PercentComplete( LONG *retval );
		[DispId(1610743811)]
		int PercentComplete
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
		}

		/// <summary>Returns the result of the installation or uninstallation of a specified update.</summary>
		/// <param name="updateIndex">A zero-based index value that specifies an update.</param>
		/// <returns>An IUpdateInstallationResult interface that contains information about a specified update.</returns>
		/// <remarks>
		/// You must make repeated calls to the <c>GetUpdateResult</c> method to track the progress of a download. You must do this because
		/// the IUpdateInstallationResult interface is not automatically updated during a download.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationprogress-getupdateresult HRESULT GetUpdateResult(
		// [in] LONG updateIndex, [out] IUpdateInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateInstallationResult GetUpdateResult([In] int updateIndex);
	}

	/// <summary>
	/// Defines the Invoke method that handles the notification about the on-going progress of an asynchronous installation or
	/// uninstallation. This interface is implemented by programmers who call the IUpdateInstaller.BeginInstall method or the
	/// IUpdateInstaller.BeginUninstall method.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iinstallationprogresschangedcallback
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IInstallationProgressChangedCallback")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("E01402D5-F8DA-43BA-A012-38894BD048F1")]
	public interface IInstallationProgressChangedCallback
	{
		/// <summary>
		/// Handles the notification of the change in the progress of an asynchronous installation or uninstallation that was initiated by a
		/// call to the IUpdateInstaller.BeginInstall method or the IUpdateInstaller.BeginUninstall method.
		/// </summary>
		/// <param name="installationJob">An IInstallationJob interface that contains the installation information.</param>
		/// <param name="callbackArgs">An IInstallationProgressChangedCallbackArgs interface that contains the installation progress data.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationprogresschangedcallback-invoke HRESULT Invoke(
		// [in] IInstallationJob *installationJob, [in] IInstallationProgressChangedCallbackArgs *callbackArgs );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT Invoke([In][MarshalAs(UnmanagedType.Interface)] IInstallationJob installationJob, [In][MarshalAs(UnmanagedType.Interface)] IInstallationProgressChangedCallbackArgs callbackArgs);
	}

	/// <summary>
	/// Contains information about the change in the progress of an asynchronous installation or uninstallation at the time the callback was made.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iinstallationprogresschangedcallbackargs
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IInstallationProgressChangedCallbackArgs")]
	[ComImport, Guid("E4F14E1E-689D-4218-A0B9-BC189C484A01")]
	public interface IInstallationProgressChangedCallbackArgs
	{
		/// <summary>
		/// <para>
		/// Gets an interface that contains the progress of the asynchronous installation or uninstallation at the time the callback was made.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationprogresschangedcallbackargs-get_progress HRESULT
		// get_Progress( IInstallationProgress **retval );
		[DispId(1610743809)]
		IInstallationProgress Progress
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	/// <summary>Represents the result of an installation or uninstallation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iinstallationresult
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IInstallationResult")]
	[ComImport, Guid("A43C56D6-7451-48D4-AF96-B6CD2D0D9B7A")]
	public interface IInstallationResult
	{
		/// <summary>
		/// <para>Gets the <c>HRESULT</c> of the exception, if any, that is raised during the installation.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationresult-get_hresult HRESULT get_HResult( LONG
		// *retval );
		[DispId(1610743809)]
		HRESULT HResult
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether you must restart the computer to complete the installation or uninstallation of an update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationresult-get_rebootrequired HRESULT
		// get_RebootRequired( VARIANT_BOOL *retval );
		[DispId(1610743810)]
		bool RebootRequired
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>Gets an OperationResultCode value that specifies the result of an operation on an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationresult-get_resultcode HRESULT get_ResultCode(
		// OperationResultCode *retval );
		[DispId(1610743811), ComAliasName("WUApiLib.OperationResultCode")]
		OperationResultCode ResultCode
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: ComAliasName("WUApiLib.OperationResultCode")]
			get;
		}

		/// <summary>Returns an IUpdateInstallationResult interface that contains the installation results for a specified update.</summary>
		/// <param name="updateIndex">The index of an update.</param>
		/// <returns>An interface that contains results for a specified update.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iinstallationresult-getupdateresult HRESULT GetUpdateResult(
		// [in] LONG updateIndex, [out] IUpdateInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateInstallationResult GetUpdateResult([In] int updateIndex);
	}

	/// <summary>Encapsulates the exception that is thrown when an invalid license is detected for a product.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iinvalidproductlicenseexception
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IInvalidProductLicenseException")]
	[ComImport, DefaultMember("Message"), Guid("A37D00F5-7BB0-4953-B414-F9E98326F2E8")]
	public interface IInvalidProductLicenseException : IUpdateException
	{
		/// <summary>
		/// <para>Gets a message that describes the search results.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateexception-get_message HRESULT get_Message( BSTR *retval );
		[DispId(0)]
		new string? Message
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the Windows-based <c>HRESULT</c> code for the search results.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateexception-get_hresult HRESULT get_HResult( LONG *retval );
		[DispId(1610743809)]
		new HRESULT HResult
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>Gets the context of search results.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateexception-get_context HRESULT get_Context(
		// UpdateExceptionContext *retval );
		[DispId(1610743810), ComAliasName("WUApiLib.UpdateExceptionContext")]
		new UpdateExceptionContext Context
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: ComAliasName("WUApiLib.UpdateExceptionContext")]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant name of the product.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://github.com/MicrosoftDocs/sdk-api/blob/docs/sdk-api-src/content/wuapi/nf-wuapi-iinvalidproductlicenseexception-get_product.md
		[DispId(1610809345)]
		string Product
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	/// <summary>
	/// Contains a method that handles the notification about the completion of an asynchronous search operation. This interface is
	/// implemented by programmers who call the IUpdateSearcher.BeginSearch method.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-isearchcompletedcallback
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.ISearchCompletedCallback")]
	[ComImport, Guid("88AEE058-D4B0-4725-A2F1-814A67AE964C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISearchCompletedCallback
	{
		/// <summary>
		/// Handles the notification of the completion of an asynchronous search that is initiated by calling the IUpdateSearcher.BeginSearch method.
		/// </summary>
		/// <param name="searchJob">An ISearchJob interface that contains search information.</param>
		/// <param name="callbackArgs">
		/// This parameter is reserved for future use and can be ignored. An ISearchCompletedCallbackArgs interface that contains information
		/// on the completion of an asynchronous search.
		/// </param>
		/// <returns>Returns <c>S_OK</c> if successful. Otherwise, returns a COM or Windows error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-isearchcompletedcallback-invoke HRESULT Invoke( [in] ISearchJob
		// *searchJob, [in] ISearchCompletedCallbackArgs *callbackArgs );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT Invoke([In][MarshalAs(UnmanagedType.Interface)] ISearchJob searchJob, [In][MarshalAs(UnmanagedType.Interface)] ISearchCompletedCallbackArgs callbackArgs);
	}

	/// <summary>
	/// Contains information about the completion of an asynchronous search. It also acts as a parameter to the SearchCompletedCallback delegate.
	/// </summary>
	/// <remarks>The <c>ISearchCompletedCallbackArgs</c> interface is reserved for future use and has no properties or methods.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-isearchcompletedcallbackargs
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.ISearchCompletedCallbackArgs")]
	[ComImport, Guid("A700A634-2850-4C47-938A-9E4B6E5AF9A6")]
	public interface ISearchCompletedCallbackArgs
	{
	}

	/// <summary>Contains properties and methods that are available to a search operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-isearchjob
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.ISearchJob")]
	[ComImport, Guid("7366EA16-7A1A-4EA2-B042-973D3E9CD99B")]
	public interface ISearchJob
	{
		/// <summary>
		/// <para>Gets the caller-specific state object that is passed to the IUpdateSearch.BeginSearch method.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-isearchjob-get_asyncstate HRESULT get_AsyncState( VARIANT
		// *retval );
		[DispId(1610743809)]
		object AsyncState
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the call to the IUpdateSearch.BeginSearch method is completely processed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-isearchjob-get_iscompleted HRESULT get_IsCompleted(
		// VARIANT_BOOL *retval );
		[DispId(1610743810)]
		bool IsCompleted
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>Waits for an asynchronous operation to complete and then releases all the callbacks.</summary>
		/// <remarks>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-isearchjob-cleanup HRESULT CleanUp();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
		void CleanUp();

		/// <summary>Makes a request to cancel the asynchronous search.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-isearchjob-requestabort HRESULT RequestAbort();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
		void RequestAbort();
	}

	/// <summary>Represents the result of a search.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-isearchresult
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.ISearchResult")]
	[ComImport, Guid("D40CFF62-E08C-4498-941A-01E25F0FD33C")]
	public interface ISearchResult
	{
		/// <summary>
		/// <para>Gets an OperationResultCode enumeration that specifies the result of a search.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-isearchresult-get_resultcode HRESULT get_ResultCode(
		// OperationResultCode *retval );
		[ComAliasName("WUApiLib.OperationResultCode"), DispId(1610743809)]
		OperationResultCode ResultCode
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: ComAliasName("WUApiLib.OperationResultCode")]
			get;
		}

		/// <summary>
		/// <para>Gets an interface collection of the root categories that are currently available on the computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-isearchresult-get_rootcategories HRESULT get_RootCategories(
		// ICategoryCollection **retval );
		[DispId(1610743810)]
		ICategoryCollection RootCategories
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface collection of the updates that result from a search.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-isearchresult-get_updates HRESULT get_Updates(
		// IUpdateCollection **retval );
		[DispId(1610743811)]
		IUpdateCollection Updates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of the warnings that result from a search.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-isearchresult-get_warnings HRESULT get_Warnings(
		// IUpdateExceptionCollection **retval );
		[DispId(1610743812)]
		IUpdateExceptionCollection Warnings
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	/// <summary>Represents an ordered list of strings.</summary>
	/// <remarks>
	/// This interface can be instantiated by using the StringCollection coclass. Use the Microsoft.Update.StringColl program identifier to
	/// create the object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-istringcollection
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IStringCollection")]
	[ComImport, Guid("EFF90582-2DDC-480F-A06D-60F3FBC362C3"), CoClass(typeof(StringCollection))]
	public interface IStringCollection : IEnumerable
	{
		/// <summary>
		/// <para>Gets or sets a string in the collection.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <param name="index"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-istringcollection-get_item HRESULT get_Item( LONG index, BSTR
		// *retval );
		[DispId(0)]
		string this[[In] int index]
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>Gets an IEnumVARIANT interface that can be used to enumerate the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-istringcollection-get__newenum HRESULT get__NewEnum( IUnknown
		// **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();

		/// <summary>
		/// <para>Gets the number of elements in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-istringcollection-get_count HRESULT get_Count( LONG *retval );
		[DispId(1610743809)]
		int Count
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the collection is read-only.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-istringcollection-get_readonly HRESULT get_ReadOnly(
		// VARIANT_BOOL *retval );
		[DispId(1610743810)]
		bool ReadOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>Adds an item to the collection.</summary>
		/// <param name="value">A string to be added to the collection.</param>
		/// <returns>The index of the added interface in the collection.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-istringcollection-add HRESULT Add( [in] BSTR value, [out] LONG
		// *retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
		int Add([In][MarshalAs(UnmanagedType.BStr)] string value);

		/// <summary>Removes all the elements from the collection.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-istringcollection-clear HRESULT Clear();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
		void Clear();

		/// <summary>Creates a deep read/write copy of the collection.</summary>
		/// <returns>A deep read/write copy of the collection.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-istringcollection-copy HRESULT Copy( [out] IStringCollection
		// **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IStringCollection Copy();

		/// <summary>Inserts an item into the collection at the specified position.</summary>
		/// <param name="index">The position at which a new string is inserted.</param>
		/// <param name="value">The string to be inserted.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-istringcollection-insert HRESULT Insert( [in] LONG index, [in]
		// BSTR value );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
		void Insert([In] int index, [In][MarshalAs(UnmanagedType.BStr)] string value);

		/// <summary>Removes the item at the specified index from the collection.</summary>
		/// <param name="index">The index of the string to be removed.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-istringcollection-removeat HRESULT RemoveAt( [in] LONG index );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
		void RemoveAt([In] int index);
	}

	/// <summary>Contains information about the specified computer. This information is relevant to the Windows Update Agent (WUA).</summary>
	/// <remarks>
	/// You can create an instance of this interface by using the SystemInformation coclass. Use the Microsoft.Update.SystemInfo program
	/// identifier to create the object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-isysteminformation
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.ISystemInformation")]
	[ComImport, Guid("ADE87BF7-7B56-4275-8FAB-B9B0E591844B"), CoClass(typeof(SystemInformation))]
	public interface ISystemInformation
	{
		/// <summary>
		/// <para>Gets a hyperlink to technical support information for OEM hardware.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-isysteminformation-get_oemhardwaresupportlink HRESULT
		// get_OemHardwareSupportLink( BSTR *retval );
		[DispId(1610743809)]
		string OemHardwareSupportLink
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether a system restart is required to complete the installation or uninstallation of one or
		/// more updates.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-isysteminformation-get_rebootrequired HRESULT
		// get_RebootRequired( VARIANT_BOOL *retval );
		[DispId(1610743810)]
		bool RebootRequired
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}
	}
}