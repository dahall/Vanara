## Assembly report for Vanara.SystemServices.dll
### Classes
Class | Description
---- | ----
FileInfoExtension | Extension methods for `FileSystemInfo` and derived classes to facilitate retrieval of extended properties.
NetworkConnection | Represents a single network connection. Wraps `INetworkConnection`.
NetworkListManager | Provides a set of methods to perform network list management functions.
NetworkProfile | Represents a wireless network profile
ProcessExtension | Extension methods for `Process` for privilegs, status, elevation and relationships.
ServiceControllerExtension | Extension methods for `ServiceController`.
SystemShutdown | Provides access to system shutdown, restart, lock and notifications.
VirtualDisk | Class that represents a virtual disk and allows for performing actions on it. This wraps most of the methods found in virtdisk.h.
VirtualDiskMetadata | Supports getting and setting metadata on a virtual disk.
### Enumerations
Enum | Description | Values
---- | ---- | ----
DeviceType | Represents the format of the virtual disk. | Unknown, Iso, Vhd, Vhdx, VhdSet
ProcessIntegrityLevel | Values which define a processes integrity level. | Untrusted, Undefined, Low, Medium, High, System
Subtype | Represents the subtype of a virtual disk. | Fixed, Dynamic, Differencing
