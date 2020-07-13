## Assembly report for Vanara.SystemServices.dll
### Enumerations
Enum | Description | Values
---- | ---- | ----
[Vanara.Diagnostics.BatteryStatus](https://github.com/dahall/Vanara/search?l=C%23&q=BatteryStatus) |  | NotPresent, Discharging, Idle, Charging
[Vanara.Diagnostics.EnergySaverStatus](https://github.com/dahall/Vanara/search?l=C%23&q=EnergySaverStatus) |  | Disabled, Off, On
[Vanara.Diagnostics.JobLimit](https://github.com/dahall/Vanara/search?l=C%23&q=JobLimit) |  | PerJobUserTime, JobMemory, JobLowMemory, IoReadBytes, IoWriteBytes, RateControlTolerance, IoRateControlTolerance, NetRateControlTolerance
[Vanara.Extensions.NetworkInterfaceAccessType](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkInterfaceAccessType) |  | Loopback, Broadcast, PointToPoint, PointToMultiPoint
[Vanara.Extensions.NetworkInterfaceAdministrativeStatus](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkInterfaceAdministrativeStatus) |  | Up, Down, Testing
[Vanara.Extensions.NetworkInterfaceConnectionType](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkInterfaceConnectionType) |  | Dedicated, Passive, Demand
[Vanara.Extensions.NetworkInterfaceDirectionType](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkInterfaceDirectionType) |  | SendReceive, SendOnly, ReceiveOnly
[Vanara.Extensions.NetworkInterfaceMediaType](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkInterfaceMediaType) |  | Ethernet802_3, TokenRing, Fddi, Wan, LocalTalk, Dix, ArcnetRaw, Arcnet878_2, Atm, Wireless, IrDA, Broadcast, CoWAN, Ieee1394, InfiniBand, Tunnel, Native802_11, Loopback, WiMAX, IP
[Vanara.Extensions.NetworkInterfacePhysicalMedium](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkInterfacePhysicalMedium) |  | Unspecified, WirelessLan, CableModem, PhoneLine, PowerLine, DSL, FibreChannel, Ieee1394, WirelessWan, Native802_11, Bluetooth, InfiniBand, WiMAX, UWB, Ethernet802_3, TokenRing, IrDA, WiredWAN, WiredCoWAN, Other
[Vanara.IO.PathEx.PathCharType](https://github.com/dahall/Vanara/search?l=C%23&q=PathCharType) |  | Invalid, LongFileName, ShortFileName, Wildcard, Separator
[Vanara.Diagnostics.PowerCapabilities](https://github.com/dahall/Vanara/search?l=C%23&q=PowerCapabilities) |  | PowerButtonPresent, SleepButtonPresent, LidPresent, SystemS1, SystemS2, SystemS3, SystemS4, SystemS5, HiberFilePresent, FullWake, VideoDimPresent, ApmPresent, UpsPresent, ThermalControl, ProcessorThrottle, FastSystemS4, Hiberboot, WakeAlarmPresent, AoAc, DiskSpinDown, AoAcConnectivitySupported, SystemBatteriesPresent, BatteriesAreShortTerm
[Vanara.Diagnostics.PowerSupplyStatus](https://github.com/dahall/Vanara/search?l=C%23&q=PowerSupplyStatus) |  | NotPresent, Inadequate, Adequate
[Vanara.Extensions.ProcessIntegrityLevel](https://github.com/dahall/Vanara/search?l=C%23&q=ProcessIntegrityLevel) |  | Untrusted, Undefined, Low, Medium, High, System
[Vanara.Security.AccessControl.ServiceControllerAccessRights](https://github.com/dahall/Vanara/search?l=C%23&q=ServiceControllerAccessRights) |  | QueryConfig, ChangeConfig, QueryStatus, EnumerateDependents, Start, Stop, Continue, Interrogate, UserDefinedControl, Delete, ReadPermissions, Write, Read, Execute, ChangePermissions, TakeOwnership, AccessSystemSecurity, FullControl
[Vanara.ShareOfflineSettings](https://github.com/dahall/Vanara/search?l=C%23&q=ShareOfflineSettings) |  | OnlySpecified, All, AllOptimized, None
### Interfaces
Interface | Description
---- | ----
[Vanara.Network.NetworkListManager.IEnumerableList<T>](https://github.com/dahall/Vanara/search?l=C%23&q=IEnumerableList<T>) | 
[Vanara.INamedEntity](https://github.com/dahall/Vanara/search?l=C%23&q=INamedEntity) | 
### Classes
Class | Description
---- | ----
[Vanara.Computer](https://github.com/dahall/Vanara/search?l=C%23&q=Computer) | 
[Vanara.Extensions.FileInfoExtension](https://github.com/dahall/Vanara/search?l=C%23&q=FileInfoExtension) | 
[Vanara.Diagnostics.IoCompletionPort](https://github.com/dahall/Vanara/search?l=C%23&q=IoCompletionPort) | 
[Vanara.Diagnostics.Job](https://github.com/dahall/Vanara/search?l=C%23&q=Job) | 
[Vanara.Diagnostics.JobEventArgs](https://github.com/dahall/Vanara/search?l=C%23&q=JobEventArgs) | 
[Vanara.Diagnostics.JobHelper](https://github.com/dahall/Vanara/search?l=C%23&q=JobHelper) | 
[Vanara.Diagnostics.JobLimits](https://github.com/dahall/Vanara/search?l=C%23&q=JobLimits) | 
[Vanara.Diagnostics.JobNotificationEventArgs](https://github.com/dahall/Vanara/search?l=C%23&q=JobNotificationEventArgs) | 
[Vanara.Diagnostics.JobNotifications](https://github.com/dahall/Vanara/search?l=C%23&q=JobNotifications) | 
[Vanara.Diagnostics.JobSecurity](https://github.com/dahall/Vanara/search?l=C%23&q=JobSecurity) | 
[Vanara.Diagnostics.JobSettings](https://github.com/dahall/Vanara/search?l=C%23&q=JobSettings) | 
[Vanara.Diagnostics.JobStatistics](https://github.com/dahall/Vanara/search?l=C%23&q=JobStatistics) | 
[Vanara.Network.NetworkConnection](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkConnection) | 
[Vanara.Extensions.NetworkInterfaceExt](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkInterfaceExt) | 
[Vanara.Network.NetworkListManager](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkListManager) | 
[Vanara.Network.NetworkProfile](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkProfile) | 
[Vanara.OpenFile](https://github.com/dahall/Vanara/search?l=C%23&q=OpenFile) | 
[Vanara.IO.PathEx](https://github.com/dahall/Vanara/search?l=C%23&q=PathEx) | 
[Vanara.Diagnostics.PoweredDevice](https://github.com/dahall/Vanara/search?l=C%23&q=PoweredDevice) | 
[Vanara.Diagnostics.PoweredDeviceCollection](https://github.com/dahall/Vanara/search?l=C%23&q=PoweredDeviceCollection) | 
[Vanara.Diagnostics.PowerManager](https://github.com/dahall/Vanara/search?l=C%23&q=PowerManager) | 
[Vanara.Diagnostics.PowerScheme](https://github.com/dahall/Vanara/search?l=C%23&q=PowerScheme) | 
[Vanara.Diagnostics.PowerSchemeCollection](https://github.com/dahall/Vanara/search?l=C%23&q=PowerSchemeCollection) | 
[Vanara.Diagnostics.PowerSchemeGroup](https://github.com/dahall/Vanara/search?l=C%23&q=PowerSchemeGroup) | 
[Vanara.Diagnostics.PowerSchemeGroupCollection](https://github.com/dahall/Vanara/search?l=C%23&q=PowerSchemeGroupCollection) | 
[Vanara.Diagnostics.PowerSchemeSetting](https://github.com/dahall/Vanara/search?l=C%23&q=PowerSchemeSetting) | 
[Vanara.Diagnostics.PowerSchemeSettingCollection](https://github.com/dahall/Vanara/search?l=C%23&q=PowerSchemeSettingCollection) | 
[Vanara.Extensions.ProcessExtension](https://github.com/dahall/Vanara/search?l=C%23&q=ProcessExtension) | 
[Vanara.Registry.RegistryEventMonitor.RegistryEventArgs](https://github.com/dahall/Vanara/search?l=C%23&q=RegistryEventArgs) | 
[Vanara.Registry.RegistryEventMonitor](https://github.com/dahall/Vanara/search?l=C%23&q=RegistryEventMonitor) | 
[Vanara.Security.AccessControl.ServiceControllerAccessRule](https://github.com/dahall/Vanara/search?l=C%23&q=ServiceControllerAccessRule) | 
[Vanara.Security.AccessControl.ServiceControllerAuditRule](https://github.com/dahall/Vanara/search?l=C%23&q=ServiceControllerAuditRule) | 
[Vanara.Extensions.ServiceControllerExtension](https://github.com/dahall/Vanara/search?l=C%23&q=ServiceControllerExtension) | 
[Vanara.Security.AccessControl.ServiceControllerSecurity](https://github.com/dahall/Vanara/search?l=C%23&q=ServiceControllerSecurity) | 
[Vanara.ShareConnection](https://github.com/dahall/Vanara/search?l=C%23&q=ShareConnection) | 
[Vanara.SharedDevice](https://github.com/dahall/Vanara/search?l=C%23&q=SharedDevice) | 
[Vanara.SharedDevices](https://github.com/dahall/Vanara/search?l=C%23&q=SharedDevices) | 
[Vanara.Diagnostics.SystemShutdown](https://github.com/dahall/Vanara/search?l=C%23&q=SystemShutdown) | 
[Vanara.IO.Wow64Redirect](https://github.com/dahall/Vanara/search?l=C%23&q=Wow64Redirect) | 
