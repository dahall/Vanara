## Assembly report for Vanara.SystemServices.dll
### Enumerations
Enum | Header | Description | Values
---- | ---- | ---- | ----
Vanara.IO.BackgroundCopyACLFlags | | Flags for ACL information to maintain when using SMB to download or upload a file. | None, Owner, Group, Dacl, Sacl, All
Vanara.IO.BackgroundCopyCost | | Defines the constant values that specify the BITS cost state. | Unrestricted, CappedUsageUnknown, BelowCap, NearCap, OvercapCharged, OstStateOvercapThrottled, OstStateUsageBased, Roaming, Reserved, IgnoreCongestion, TransferUnrestricted, TransferStandard, TransferNoSurcharge, TransferNotRoaming, TransferAlways
Vanara.IO.BackgroundCopyErrorContext | | Defines the constant values that specify the context in which the error occurred. | None, Unknown, GeneralQueueManager, QueueManagerNotification, LocalFile, RemoteFile, GeneralTransport, RemoteApplication
Vanara.IO.BackgroundCopyJobCredentialScheme | | Defines the constant values that specify the authentication scheme to use when a proxy or server requests user authentication. | Basic, Digest, NTLM, Negotiate, Passport
Vanara.IO.BackgroundCopyJobCredentialTarget | | Defines the constant values that specify whether the credentials are used for proxy or server user authentication requests. | Undefined, Server, Proxy
Vanara.IO.BackgroundCopyJobPriority | | Defines the constant values that specify the priority level of a job. | Foreground, High, Normal, Low
Vanara.IO.BackgroundCopyJobSecurity | | HTTP security flags that indicate which errors to ignore when connecting to the server. | AllowSilentRedirect, CheckCRL, IgnoreInvalidCerts, IgnoreExpiredCerts, IgnoreUnknownCA, IgnoreWrongCertUsage, AllowReportedRedirect, DisallowRedirect, AllowHttpsToHttpRedirect
Vanara.IO.BackgroundCopyJobState | | Defines constant values for the different states of a job. | Queued, Connecting, Transferring, Suspended, Error, TransientError, Transferred, Acknowledged, Cancelled
Vanara.IO.BackgroundCopyJobType | | Defines constant values that specify the type of transfer job, such as download. | Download, Upload, UploadReply
Vanara.Diagnostics.BatteryStatus | | Indicates the status of the battery. | NotPresent, Discharging, Idle, Charging
Vanara.IO.VirtualDisk.DeviceType | | Represents the format of the virtual disk. | Unknown, Iso, Vhd, Vhdx, VhdSet
Vanara.Diagnostics.EnergySaverStatus | | Specifies the status of battery saver. | Disabled, Off, On
Vanara.Extensions.NetworkInterfaceAccessType | | The interface access type. | Loopback, Broadcast, PointToPoint, PointToMultiPoint
Vanara.Extensions.NetworkInterfaceAdministrativeStatus | | Specifies the NDIS network interface administrative status, as described in RFC 2863. | Up, Down, Testing
Vanara.Extensions.NetworkInterfaceConnectionType | | Specifies the NDIS network interface connection type. | Dedicated, Passive, Demand
Vanara.Extensions.NetworkInterfaceDirectionType | | Specifies the NDIS network interface direction type. | SendReceive, SendOnly, ReceiveOnly
Vanara.Extensions.NetworkInterfaceMediaType | | The NDIS media type of a network interface. | Ethernet802_3, TokenRing, Fddi, Wan, LocalTalk, Dix, ArcnetRaw, Arcnet878_2, Atm, Wireless, IrDA, Broadcast, CoWAN, Ieee1394, InfiniBand, Tunnel, Native802_11, Loopback, WiMAX, IP
Vanara.Extensions.NetworkInterfacePhysicalMedium | | The NDIS physical medium type. | Unspecified, WirelessLan, CableModem, PhoneLine, PowerLine, DSL, FibreChannel, Ieee1394, WirelessWan, Native802_11, Bluetooth, InfiniBand, WiMAX, UWB, Ethernet802_3, TokenRing, IrDA, WiredWAN, WiredCoWAN, Other
Vanara.IO.PathEx.PathCharType | |  | Invalid, LongFileName, ShortFileName, Wildcard, Separator
Vanara.Diagnostics.PowerCapabilities | |  | PowerButtonPresent, SleepButtonPresent, LidPresent, SystemS1, SystemS2, SystemS3, SystemS4, SystemS5, HiberFilePresent, FullWake, VideoDimPresent, ApmPresent, UpsPresent, ThermalControl, ProcessorThrottle, FastSystemS4, Hiberboot, WakeAlarmPresent, AoAc, DiskSpinDown, AoAcConnectivitySupported, SystemBatteriesPresent, BatteriesAreShortTerm
Vanara.Diagnostics.PowerSupplyStatus | | Represents the device's power supply status. | NotPresent, Inadequate, Adequate
Vanara.Extensions.ProcessIntegrityLevel | | Values which define a processes integrity level. | Untrusted, Undefined, Low, Medium, High, System
Vanara.Security.AccessControl.ServiceControllerAccessRights | | Defines the access rights to use when creating access and audit rules. | QueryConfig, ChangeConfig, QueryStatus, EnumerateDependents, Start, Stop, Continue, Interrogate, UserDefinedControl, Delete, ReadPermissions, Write, Read, Execute, ChangePermissions, TakeOwnership, AccessSystemSecurity, FullControl
Vanara.ShareOfflineSettings | | Offline settings for a shared folder. | OnlySpecified, All, AllOptimized, None
Vanara.IO.VirtualDisk.Subtype | | Represents the subtype of a virtual disk. | Fixed, Dynamic, Differencing
### Structures
Struct | Header | Description
---- | ---- | ----
Vanara.IO.BackgroundCopyFileRange | | Identifies a range of bytes to download from a file.
Vanara.IO.BackgroundCopyJobProgress | | Provides job-related progress information, such as the number of bytes and files transferred. For upload jobs, the progress applies to the upload file, not the reply file.
Vanara.IO.BackgroundCopyJobReplyProgress | | Provides progress information related to the reply portion of an upload-reply job.
### Interfaces
Interface | Header | Description
---- | ---- | ----
Vanara.Network.NetworkListManager.IEnumerableList<T> | | An enumerable list that supports a length and indexer.
Vanara.INamedEntity | | An object that exposes a name.
### Classes
Class | Header | Description
---- | ---- | ----
Vanara.IO.BackgroundCopyException | | Exceptions specific to BITS
Vanara.IO.BackgroundCopyFileCollection | | Manages the set of files for a background copy job.
Vanara.IO.BackgroundCopyFileInfo | | Information about a file in a background copy job.
Vanara.IO.BackgroundCopyFileRange | | Identifies a range of bytes to download from a file.
Vanara.IO.BackgroundCopyFileRangesTransferredEventArgs | | Used by `Vanara.IO.BackgroundCopyJob.FileRangesTransferred` events.
Vanara.IO.BackgroundCopyFileTransferredEventArgs | | Used by `Vanara.IO.BackgroundCopyJob.FileTransferred` events.
Vanara.IO.BackgroundCopyJob | | A job in the Backgroup Copy Service (BITS)
Vanara.IO.BackgroundCopyJobCollection | | Manages the set of jobs for the background copy service (BITS).
Vanara.IO.BackgroundCopyJobCredential | | Represents a single BITS job credential.
Vanara.IO.BackgroundCopyJobCredentials | | The list of credentials for a job.
Vanara.IO.BackgroundCopyJobEventArgs | | Event argument for background copy job.
Vanara.IO.BackgroundCopyManager | | Use the BackgroundCopyManager to create transfer jobs, retrieve an enumerator object that contains the jobs in the queue, and to retrieve individual jobs from the queue.
Vanara.Computer | | Represents a single connected (authenticated) computer.
Vanara.Extensions.FileInfoExtension | | Extension methods for `System.IO.FileSystemInfo` and derived classes to facilitate retrieval of extended properties.
Vanara.Network.NetworkConnection | | Represents a single network connection. Wraps `Vanara.PInvoke.NetListMgr.INetworkConnection`.
Vanara.Extensions.NetworkInterfaceExt | | 
Vanara.Network.NetworkListManager | | Provides a set of methods to perform network list management functions.
Vanara.Network.NetworkProfile | | Represents a wireless network profile
Vanara.OpenFile | | Represents an open file associated with a share.
Vanara.IO.PathEx | | Performs operations on String instances that contain file or directory path information. These operations are performed in a cross-platform manner.
Vanara.Diagnostics.PoweredDevice | | Represents a device on the system that has power requirements.
Vanara.Diagnostics.PoweredDeviceCollection | | Retrieves the list, optionally filtered, of the powered devices on the system.
Vanara.Diagnostics.PowerManager | | Provides access to information about a device's battery and power supply status and configuration. This extends the capabilities Windows.System.Power.PowerManager to include more detail, schemes and devices.
Vanara.Diagnostics.PowerScheme | | Represents a system power scheme (power plan).
Vanara.Diagnostics.PowerSchemeCollection | | Represents a collection of all the power schemes available on the system.
Vanara.Diagnostics.PowerSchemeGroup | | Represents a subgroup of a system power scheme (power plan).
Vanara.Diagnostics.PowerSchemeGroupCollection | | Represents a collection of all the subgroups available under a power scheme on the system.
Vanara.Diagnostics.PowerSchemeSetting | | Represents a setting on a subgroup.
Vanara.Diagnostics.PowerSchemeSettingCollection | | Represents a collection of all settings for a subgroup and power scheme on the system.
Vanara.Extensions.ProcessExtension | | Extension methods for `System.Diagnostics.Process` for privilegs, status, elevation and relationships.
Vanara.Registry.RegistryEventMonitor.RegistryEventArgs | | Argument used in `Vanara.Registry.RegistryEventMonitor` events.
Vanara.Registry.RegistryEventMonitor | | Watches the Windows Registry for any changes.
Vanara.Security.AccessControl.ServiceControllerAccessRule | | Represents an abstraction of an access control entry (ACE) that defines an access rule for a service.
Vanara.Security.AccessControl.ServiceControllerAuditRule | | Represents an abstraction of an access control entry (ACE) that defines an audit rule for a service.
Vanara.Extensions.ServiceControllerExtension | | Extension methods for `System.ServiceProcess.ServiceController`.
Vanara.Security.AccessControl.ServiceControllerSecurity | | Represents the access control and audit security for a service.
Vanara.ShareConnection | | Represents a connection to a shared device.
Vanara.SharedDevice | | Represents a shared device on a computer.
Vanara.SharedDevices | | Represents all the shared devices on a computers.
Vanara.Diagnostics.SystemShutdown | | Provides access to system shutdown, restart, lock and notifications.
Vanara.IO.VirtualDisk | | Class that represents a virtual disk and allows for performing actions on it. This wraps most of the methods found in virtdisk.h.
Vanara.IO.VirtualDisk.VirtualDiskMetadata | | Supports getting and setting metadata on a virtual disk.
Vanara.IO.Wow64Redirect | | Suspends File System Redirection if found to be in effect. Effectively, this calls <c>IsWow64Process</c> to determine state and then disables redirection using <c>Wow64DisableWow64FsRedirection</c>. It then reverts redirection at disposal using <c>Wow64RevertWow64FsRedirection</c>.
