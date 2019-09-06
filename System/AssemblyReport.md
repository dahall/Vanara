## Assembly report for Vanara.SystemServices.dll
### Enumerations
Enum | Description | Values
---- | ---- | ----
[Vanara.IO.BackgroundCopyACLFlags](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyACLFlags) | Flags for ACL information to maintain when using SMB to download or upload a file. | None, Owner, Group, Dacl, Sacl, All
[Vanara.IO.BackgroundCopyCost](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyCost) | Defines the constant values that specify the BITS cost state. | Unrestricted, CappedUsageUnknown, BelowCap, NearCap, OvercapCharged, OstStateOvercapThrottled, OstStateUsageBased, Roaming, Reserved, IgnoreCongestion, TransferUnrestricted, TransferStandard, TransferNoSurcharge, TransferNotRoaming, TransferAlways
[Vanara.IO.BackgroundCopyErrorContext](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyErrorContext) | Defines the constant values that specify the context in which the error occurred. | None, Unknown, GeneralQueueManager, QueueManagerNotification, LocalFile, RemoteFile, GeneralTransport, RemoteApplication
[Vanara.IO.BackgroundCopyJobCredentialScheme](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCredentialScheme) | Defines the constant values that specify the authentication scheme to use when a proxy or server requests user authentication. | Basic, Digest, NTLM, Negotiate, Passport
[Vanara.IO.BackgroundCopyJobCredentialTarget](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCredentialTarget) | Defines the constant values that specify whether the credentials are used for proxy or server user authentication requests. | Undefined, Server, Proxy
[Vanara.IO.BackgroundCopyJobPriority](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobPriority) | Defines the constant values that specify the priority level of a job. | Foreground, High, Normal, Low
[Vanara.IO.BackgroundCopyJobSecurity](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobSecurity) | HTTP security flags that indicate which errors to ignore when connecting to the server. | AllowSilentRedirect, CheckCRL, IgnoreInvalidCerts, IgnoreExpiredCerts, IgnoreUnknownCA, IgnoreWrongCertUsage, AllowReportedRedirect, DisallowRedirect, AllowHttpsToHttpRedirect
[Vanara.IO.BackgroundCopyJobState](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobState) | Defines constant values for the different states of a job. | Queued, Connecting, Transferring, Suspended, Error, TransientError, Transferred, Acknowledged, Cancelled
[Vanara.IO.BackgroundCopyJobType](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobType) | Defines constant values that specify the type of transfer job, such as download. | Download, Upload, UploadReply
[Vanara.Diagnostics.BatteryStatus](https://github.com/dahall/Vanara/search?l=C%23&q=BatteryStatus) | Indicates the status of the battery. | NotPresent, Discharging, Idle, Charging
[Vanara.IO.VirtualDisk.DeviceType](https://github.com/dahall/Vanara/search?l=C%23&q=DeviceType) | Represents the format of the virtual disk. | Unknown, Iso, Vhd, Vhdx, VhdSet
[Vanara.Diagnostics.EnergySaverStatus](https://github.com/dahall/Vanara/search?l=C%23&q=EnergySaverStatus) | Specifies the status of battery saver. | Disabled, Off, On
[Vanara.Extensions.NetworkInterfaceAccessType](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkInterfaceAccessType) | The interface access type. | Loopback, Broadcast, PointToPoint, PointToMultiPoint
[Vanara.Extensions.NetworkInterfaceAdministrativeStatus](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkInterfaceAdministrativeStatus) | Specifies the NDIS network interface administrative status, as described in RFC 2863. | Up, Down, Testing
[Vanara.Extensions.NetworkInterfaceConnectionType](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkInterfaceConnectionType) | Specifies the NDIS network interface connection type. | Dedicated, Passive, Demand
[Vanara.Extensions.NetworkInterfaceDirectionType](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkInterfaceDirectionType) | Specifies the NDIS network interface direction type. | SendReceive, SendOnly, ReceiveOnly
[Vanara.Extensions.NetworkInterfaceMediaType](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkInterfaceMediaType) | The NDIS media type of a network interface. | Ethernet802_3, TokenRing, Fddi, Wan, LocalTalk, Dix, ArcnetRaw, Arcnet878_2, Atm, Wireless, IrDA, Broadcast, CoWAN, Ieee1394, InfiniBand, Tunnel, Native802_11, Loopback, WiMAX, IP
[Vanara.Extensions.NetworkInterfacePhysicalMedium](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkInterfacePhysicalMedium) | The NDIS physical medium type. | Unspecified, WirelessLan, CableModem, PhoneLine, PowerLine, DSL, FibreChannel, Ieee1394, WirelessWan, Native802_11, Bluetooth, InfiniBand, WiMAX, UWB, Ethernet802_3, TokenRing, IrDA, WiredWAN, WiredCoWAN, Other
[Vanara.IO.PathEx.PathCharType](https://github.com/dahall/Vanara/search?l=C%23&q=PathCharType) |  | Invalid, LongFileName, ShortFileName, Wildcard, Separator
[Vanara.Diagnostics.PowerCapabilities](https://github.com/dahall/Vanara/search?l=C%23&q=PowerCapabilities) |  | PowerButtonPresent, SleepButtonPresent, LidPresent, SystemS1, SystemS2, SystemS3, SystemS4, SystemS5, HiberFilePresent, FullWake, VideoDimPresent, ApmPresent, UpsPresent, ThermalControl, ProcessorThrottle, FastSystemS4, Hiberboot, WakeAlarmPresent, AoAc, DiskSpinDown, AoAcConnectivitySupported, SystemBatteriesPresent, BatteriesAreShortTerm
[Vanara.Diagnostics.PowerSupplyStatus](https://github.com/dahall/Vanara/search?l=C%23&q=PowerSupplyStatus) | Represents the device's power supply status. | NotPresent, Inadequate, Adequate
[Vanara.Extensions.ProcessIntegrityLevel](https://github.com/dahall/Vanara/search?l=C%23&q=ProcessIntegrityLevel) | Values which define a processes integrity level. | Untrusted, Undefined, Low, Medium, High, System
[Vanara.Security.AccessControl.ServiceControllerAccessRights](https://github.com/dahall/Vanara/search?l=C%23&q=ServiceControllerAccessRights) | Defines the access rights to use when creating access and audit rules. | QueryConfig, ChangeConfig, QueryStatus, EnumerateDependents, Start, Stop, Continue, Interrogate, UserDefinedControl, Delete, ReadPermissions, Write, Read, Execute, ChangePermissions, TakeOwnership, AccessSystemSecurity, FullControl
[Vanara.ShareOfflineSettings](https://github.com/dahall/Vanara/search?l=C%23&q=ShareOfflineSettings) | Offline settings for a shared folder. | OnlySpecified, All, AllOptimized, None
[Vanara.IO.VirtualDisk.Subtype](https://github.com/dahall/Vanara/search?l=C%23&q=Subtype) | Represents the subtype of a virtual disk. | Fixed, Dynamic, Differencing
### Structures
Struct | Description
---- | ----
[Vanara.IO.BackgroundCopyFileRange](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileRange) | Identifies a range of bytes to download from a file.
[Vanara.IO.BackgroundCopyJobProgress](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobProgress) | Provides job-related progress information, such as the number of bytes and files transferred. For upload jobs, the progress applies to the upload file, not the reply file.
[Vanara.IO.BackgroundCopyJobReplyProgress](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobReplyProgress) | Provides progress information related to the reply portion of an upload-reply job.
### Interfaces
Interface | Description
---- | ----
[Vanara.Network.NetworkListManager.IEnumerableList<T>](https://github.com/dahall/Vanara/search?l=C%23&q=IEnumerableList<T>) | An enumerable list that supports a length and indexer.
[Vanara.INamedEntity](https://github.com/dahall/Vanara/search?l=C%23&q=INamedEntity) | An object that exposes a name.
### Classes
Class | Description
---- | ----
[Vanara.IO.BackgroundCopyException](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyException) | Exceptions specific to BITS
[Vanara.IO.BackgroundCopyFileCollection](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileCollection) | Manages the set of files for a background copy job.
[Vanara.IO.BackgroundCopyFileInfo](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileInfo) | Information about a file in a background copy job.
[Vanara.IO.BackgroundCopyFileRange](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileRange) | Identifies a range of bytes to download from a file.
[Vanara.IO.BackgroundCopyFileRangesTransferredEventArgs](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileRangesTransferredEventArgs) | Used by `Vanara.IO.BackgroundCopyJob.FileRangesTransferred` events.
[Vanara.IO.BackgroundCopyFileTransferredEventArgs](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileTransferredEventArgs) | Used by `Vanara.IO.BackgroundCopyJob.FileTransferred` events.
[Vanara.IO.BackgroundCopyJob](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJob) | A job in the Backgroup Copy Service (BITS)
[Vanara.IO.BackgroundCopyJobCollection](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCollection) | Manages the set of jobs for the background copy service (BITS).
[Vanara.IO.BackgroundCopyJobCredential](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCredential) | Represents a single BITS job credential.
[Vanara.IO.BackgroundCopyJobCredentials](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCredentials) | The list of credentials for a job.
[Vanara.IO.BackgroundCopyJobEventArgs](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobEventArgs) | Event argument for background copy job.
[Vanara.IO.BackgroundCopyManager](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyManager) | Use the BackgroundCopyManager to create transfer jobs, retrieve an enumerator object that contains the jobs in the queue, and to retrieve individual jobs from the queue.
[Vanara.Computer](https://github.com/dahall/Vanara/search?l=C%23&q=Computer) | Represents a single connected (authenticated) computer.
[Vanara.Extensions.FileInfoExtension](https://github.com/dahall/Vanara/search?l=C%23&q=FileInfoExtension) | Extension methods for `System.IO.FileSystemInfo` and derived classes to facilitate retrieval of extended properties.
[Vanara.Network.NetworkConnection](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkConnection) | Represents a single network connection. Wraps `Vanara.PInvoke.NetListMgr.INetworkConnection`.
[Vanara.Extensions.NetworkInterfaceExt](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkInterfaceExt) | 
[Vanara.Network.NetworkListManager](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkListManager) | Provides a set of methods to perform network list management functions.
[Vanara.Network.NetworkProfile](https://github.com/dahall/Vanara/search?l=C%23&q=NetworkProfile) | Represents a wireless network profile
[Vanara.OpenFile](https://github.com/dahall/Vanara/search?l=C%23&q=OpenFile) | Represents an open file associated with a share.
[Vanara.IO.PathEx](https://github.com/dahall/Vanara/search?l=C%23&q=PathEx) | Performs operations on String instances that contain file or directory path information. These operations are performed in a cross-platform manner.
[Vanara.Diagnostics.PoweredDevice](https://github.com/dahall/Vanara/search?l=C%23&q=PoweredDevice) | Represents a device on the system that has power requirements.
[Vanara.Diagnostics.PoweredDeviceCollection](https://github.com/dahall/Vanara/search?l=C%23&q=PoweredDeviceCollection) | Retrieves the list, optionally filtered, of the powered devices on the system.
[Vanara.Diagnostics.PowerManager](https://github.com/dahall/Vanara/search?l=C%23&q=PowerManager) | Provides access to information about a device's battery and power supply status and configuration. This extends the capabilities Windows.System.Power.PowerManager to include more detail, schemes and devices.
[Vanara.Diagnostics.PowerScheme](https://github.com/dahall/Vanara/search?l=C%23&q=PowerScheme) | Represents a system power scheme (power plan).
[Vanara.Diagnostics.PowerSchemeCollection](https://github.com/dahall/Vanara/search?l=C%23&q=PowerSchemeCollection) | Represents a collection of all the power schemes available on the system.
[Vanara.Diagnostics.PowerSchemeGroup](https://github.com/dahall/Vanara/search?l=C%23&q=PowerSchemeGroup) | Represents a subgroup of a system power scheme (power plan).
[Vanara.Diagnostics.PowerSchemeGroupCollection](https://github.com/dahall/Vanara/search?l=C%23&q=PowerSchemeGroupCollection) | Represents a collection of all the subgroups available under a power scheme on the system.
[Vanara.Diagnostics.PowerSchemeSetting](https://github.com/dahall/Vanara/search?l=C%23&q=PowerSchemeSetting) | Represents a setting on a subgroup.
[Vanara.Diagnostics.PowerSchemeSettingCollection](https://github.com/dahall/Vanara/search?l=C%23&q=PowerSchemeSettingCollection) | Represents a collection of all settings for a subgroup and power scheme on the system.
[Vanara.Extensions.ProcessExtension](https://github.com/dahall/Vanara/search?l=C%23&q=ProcessExtension) | Extension methods for `System.Diagnostics.Process` for privilegs, status, elevation and relationships.
[Vanara.Registry.RegistryEventMonitor.RegistryEventArgs](https://github.com/dahall/Vanara/search?l=C%23&q=RegistryEventArgs) | Argument used in `Vanara.Registry.RegistryEventMonitor` events.
[Vanara.Registry.RegistryEventMonitor](https://github.com/dahall/Vanara/search?l=C%23&q=RegistryEventMonitor) | Watches the Windows Registry for any changes.
[Vanara.Security.AccessControl.ServiceControllerAccessRule](https://github.com/dahall/Vanara/search?l=C%23&q=ServiceControllerAccessRule) | Represents an abstraction of an access control entry (ACE) that defines an access rule for a service.
[Vanara.Security.AccessControl.ServiceControllerAuditRule](https://github.com/dahall/Vanara/search?l=C%23&q=ServiceControllerAuditRule) | Represents an abstraction of an access control entry (ACE) that defines an audit rule for a service.
[Vanara.Extensions.ServiceControllerExtension](https://github.com/dahall/Vanara/search?l=C%23&q=ServiceControllerExtension) | Extension methods for `System.ServiceProcess.ServiceController`.
[Vanara.Security.AccessControl.ServiceControllerSecurity](https://github.com/dahall/Vanara/search?l=C%23&q=ServiceControllerSecurity) | Represents the access control and audit security for a service.
[Vanara.ShareConnection](https://github.com/dahall/Vanara/search?l=C%23&q=ShareConnection) | Represents a connection to a shared device.
[Vanara.SharedDevice](https://github.com/dahall/Vanara/search?l=C%23&q=SharedDevice) | Represents a shared device on a computer.
[Vanara.SharedDevices](https://github.com/dahall/Vanara/search?l=C%23&q=SharedDevices) | Represents all the shared devices on a computers.
[Vanara.Diagnostics.SystemShutdown](https://github.com/dahall/Vanara/search?l=C%23&q=SystemShutdown) | Provides access to system shutdown, restart, lock and notifications.
[Vanara.IO.VirtualDisk](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualDisk) | Class that represents a virtual disk and allows for performing actions on it. This wraps most of the methods found in virtdisk.h.
[Vanara.IO.VirtualDisk.VirtualDiskMetadata](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualDiskMetadata) | Supports getting and setting metadata on a virtual disk.
[Vanara.IO.Wow64Redirect](https://github.com/dahall/Vanara/search?l=C%23&q=Wow64Redirect) | Suspends File System Redirection if found to be in effect. Effectively, this calls <c>IsWow64Process</c> to determine state and then disables redirection using <c>Wow64DisableWow64FsRedirection</c>. It then reverts redirection at disposal using <c>Wow64RevertWow64FsRedirection</c>.
