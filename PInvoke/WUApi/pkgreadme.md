![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.WUApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.WUApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows Update API.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.WUApi**

Enumerations | Interfaces
--- | ---
AddServiceFlag AutoDownloadMode AutomaticUpdatesNotificationLevel AutomaticUpdatesPermissionType AutomaticUpdatesScheduledInstallationDay AutomaticUpdatesUserType AutoSelectionMode DeploymentAction DownloadPhase DownloadPriority InstallationImpact InstallationRebootBehavior OperationResultCode SearchScope ServerSelection UpdateEndpointAuthTokenType UpdateEndpointType UpdateExceptionContext UpdateLockdownOption UpdateOperation UpdateServiceOption UpdateServiceRegistrationState UpdateType WUError                                                      | IAutomaticUpdates IAutomaticUpdates2 IAutomaticUpdatesResults IAutomaticUpdatesSettings IAutomaticUpdatesSettings2 IAutomaticUpdatesSettings3 ICategory ICategoryCollection IDownloadCompletedCallback IDownloadCompletedCallbackArgs IDownloadJob IDownloadProgress IDownloadProgressChangedCallback IDownloadProgressChangedCallbackArgs IDownloadResult IImageInformation IInstallationAgent IInstallationBehavior IInstallationCompletedCallback IInstallationCompletedCallbackArgs IInstallationJob IInstallationProgress IInstallationProgressChangedCallback IInstallationProgressChangedCallbackArgs IInstallationResult IInvalidProductLicenseException ISearchCompletedCallback ISearchCompletedCallbackArgs ISearchJob ISearchResult IStringCollection ISystemInformation IUpdate IUpdate2 IUpdate3 IUpdate4 IUpdate5 IUpdateCollection IUpdateDownloadContent IUpdateDownloadContent2 IUpdateDownloadContentCollection IUpdateDownloader IUpdateDownloadResult IUpdateException IUpdateExceptionCollection IUpdateHistoryEntry IUpdateHistoryEntry2 IUpdateHistoryEntryCollection IUpdateIdentity IUpdateInstallationResult IUpdateInstaller IUpdateInstaller2 IUpdateInstaller3 IUpdateInstaller4 IUpdateLockdown IUpdateSearcher IUpdateSearcher2 IUpdateSearcher3 IUpdateService IUpdateService2 IUpdateServiceCollection IUpdateServiceManager IUpdateServiceManager2 IUpdateServiceRegistration IUpdateSession IUpdateSession2 IUpdateSession3 IWebProxy IWindowsDriverUpdate IWindowsDriverUpdate2 IWindowsDriverUpdate3 IWindowsDriverUpdate4 IWindowsDriverUpdate5 IWindowsDriverUpdateEntry IWindowsDriverUpdateEntryCollection IWindowsUpdateAgentInfo 
