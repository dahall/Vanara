![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.SystemServices NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.SystemServices?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

Classes for system related items derived from the Vanara PInvoke libraries. Includes extensions for Process (privileges and elavation), FileInfo (compression info), Shared Network Drives and Devices, and ServiceController (SetStartType) that pull extended information through native API calls.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.SystemServices**

Classes | Enumerations | Interfaces
--- | --- | ---
AntimalwareScan Computer Device DeviceClass DeviceClassCollection DeviceClassProperties DeviceClassRegProperties DeviceCollection DeviceExtensions DeviceManager DeviceProperties DeviceRegProperties FileInfoExtension InternetProxyOptions IoCompletionPort Job JobEventArgs JobHelper JobLimits JobNotificationEventArgs JobNotifications JobSecurity JobSettings JobStatistics LocalGroup LocalGroupMembers LocalGroups NetworkConnection NetworkDeviceConnection NetworkDeviceConnectionCollection NetworkInterfaceExt NetworkListManager NetworkProfile OpenFile PathEx PoweredDevice PoweredDeviceCollection PowerEventArgs PowerManager PowerScheme PowerSchemeCollection PowerSchemeGroup PowerSchemeGroupCollection PowerSchemeSetting PowerSchemeSettingCollection ProcessExtension RegistryEventArgs RegistryEventMonitor ServiceControllerAccessRule ServiceControllerAuditRule ServiceControllerExtension ServiceControllerSecurity ShareConnection SharedDevice SharedDevices SystemShutdown UserAccount UserAccounts Wow64Redirect  | BatteryStatus EnergySaverStatus JobLimit NetworkInterfaceAccessType NetworkInterfaceAdministrativeStatus NetworkInterfaceConnectionType NetworkInterfaceDirectionType NetworkInterfaceMediaType NetworkInterfacePhysicalMedium PathCharType PowerCapabilities PowerSupplyStatus ScanResult ServiceControllerAccessRights ShareOfflineSettings                                              | IEnumerableList INamedEntity IPropertyProvider                                                         
