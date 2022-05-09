![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.SystemServices NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.SystemServices?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

Classes for system related items derived from the Vanara PInvoke libraries. Includes extensions for Process (privileges and elavation), FileInfo (compression info), Shared Network Drives and Devices, and ServiceController (SetStartType) that pull extended information through native API calls.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.SystemServices

Classes | Enumerations | Interfaces
--- | --- | ---
AntimalwareScan<br>Computer<br>Device<br>DeviceClass<br>DeviceClassCollection<br>DeviceClassProperties<br>DeviceClassRegProperties<br>DeviceCollection<br>DeviceExtensions<br>DeviceManager<br>DeviceProperties<br>DeviceRegProperties<br>FileInfoExtension<br>InternetProxyOptions<br>IoCompletionPort<br>Job<br>JobEventArgs<br>JobHelper<br>JobLimits<br>JobNotificationEventArgs<br>JobNotifications<br>JobSecurity<br>JobSettings<br>JobStatistics<br>LocalGroup<br>LocalGroupMembers<br>LocalGroups<br>NetworkConnection<br>NetworkDeviceConnection<br>NetworkDeviceConnectionCollection<br>NetworkInterfaceExt<br>NetworkListManager<br>NetworkProfile<br>OpenFile<br>PathEx<br>PoweredDevice<br>PoweredDeviceCollection<br>PowerEventArgs<br>PowerManager<br>PowerScheme<br>PowerSchemeCollection<br>PowerSchemeGroup<br>PowerSchemeGroupCollection<br>PowerSchemeSetting<br>PowerSchemeSettingCollection<br>ProcessExtension<br>RegistryEventArgs<br>RegistryEventMonitor<br>ServiceControllerAccessRule<br>ServiceControllerAuditRule<br>ServiceControllerExtension<br>ServiceControllerSecurity<br>ShareConnection<br>SharedDevice<br>SharedDevices<br>SystemShutdown<br>UserAccount<br>UserAccounts<br>Wow64Redirect<br> | BatteryStatus<br>EnergySaverStatus<br>JobLimit<br>NetworkInterfaceAccessType<br>NetworkInterfaceAdministrativeStatus<br>NetworkInterfaceConnectionType<br>NetworkInterfaceDirectionType<br>NetworkInterfaceMediaType<br>NetworkInterfacePhysicalMedium<br>PathCharType<br>PowerCapabilities<br>PowerSupplyStatus<br>ScanResult<br>ServiceControllerAccessRights<br>ShareOfflineSettings<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | IEnumerableList<br>INamedEntity<br>IPropertyProvider<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
