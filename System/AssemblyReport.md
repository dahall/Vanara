## Assembly report for Vanara.SystemServices.dll
### Classes
Class | Description
---- | ----
BackgroundCopyException | Exceptions specific to BITS
BackgroundCopyFileCollection | Manages the set of files for a background copy job.
BackgroundCopyFileInfo | Information about a file in a background copy job.
BackgroundCopyFileRange | Identifies a range of bytes to download from a file.
BackgroundCopyFileRangesTransferredEventArgs | Used by `FileRangesTransferred` events.
BackgroundCopyFileTransferredEventArgs | Used by `FileTransferred` events.
BackgroundCopyJob | A job in the Backgroup Copy Service (BITS)
BackgroundCopyJobCollection | Manages the set of jobs for the background copy service (BITS).
BackgroundCopyJobCredential | Represents a single BITS job credential.
BackgroundCopyJobCredentials | The list of credentials for a job.
BackgroundCopyJobEventArgs | Event argument for background copy job.
BackgroundCopyManager | Use the BackgroundCopyManager to create transfer jobs, retrieve an enumerator object that contains the jobs in the queue, and to retrieve individual jobs from the queue.
FileInfoExtension | Extension methods for `FileSystemInfo` and derived classes to facilitate retrieval of extended properties.
NetworkConnection | Represents a single network connection. Wraps `INetworkConnection`.
NetworkListManager | Provides a set of methods to perform network list management functions.
NetworkProfile | Represents a wireless network profile
PathEx | Performs operations on String instances that contain file or directory path information. These operations are performed in a cross-platform manner.
ProcessExtension | Extension methods for `Process` for privilegs, status, elevation and relationships.
RegistryEventArgs | Argument used in `RegistryEventMonitor` events.
RegistryEventMonitor | Watches the Windows Registry for any changes.
ServiceControllerExtension | Extension methods for `ServiceController`.
SystemShutdown | Provides access to system shutdown, restart, lock and notifications.
VirtualDisk | Class that represents a virtual disk and allows for performing actions on it. This wraps most of the methods found in virtdisk.h.
VirtualDiskMetadata | Supports getting and setting metadata on a virtual disk.
Wow64Redirect | Suspends File System Redirection if found to be in effect. Effectively, this calls <c>IsWow64Process</c> to determine state and then disables redirection using <c>Wow64DisableWow64FsRedirection</c>. It then reverts redirection at disposal using <c>Wow64RevertWow64FsRedirection</c>.
### Structures
Struct | Description
---- | ----
BackgroundCopyFileRange | Identifies a range of bytes to download from a file.
BackgroundCopyJobProgress | Provides job-related progress information, such as the number of bytes and files transferred. For upload jobs, the progress applies to the upload file, not the reply file.
BackgroundCopyJobReplyProgress | Provides progress information related to the reply portion of an upload-reply job.
### Enumerations
Enum | Description | Values
---- | ---- | ----
BackgroundCopyACLFlags | Flags for ACL information to maintain when using SMB to download or upload a file. | None, Owner, Group, Dacl, Sacl, All
BackgroundCopyCost | Defines the constant values that specify the BITS cost state. | Unrestricted, CappedUsageUnknown, BelowCap, NearCap, OvercapCharged, OstStateOvercapThrottled, OstStateUsageBased, Roaming, Reserved, IgnoreCongestion, TransferUnrestricted, TransferStandard, TransferNoSurcharge, TransferNotRoaming, TransferAlways
BackgroundCopyErrorContext | Defines the constant values that specify the context in which the error occurred. | None, Unknown, GeneralQueueManager, QueueManagerNotification, LocalFile, RemoteFile, GeneralTransport, RemoteApplication
BackgroundCopyJobCredentialScheme | Defines the constant values that specify the authentication scheme to use when a proxy or server requests user authentication. | Basic, Digest, NTLM, Negotiate, Passport
BackgroundCopyJobCredentialTarget | Defines the constant values that specify whether the credentials are used for proxy or server user authentication requests. | Undefined, Server, Proxy
BackgroundCopyJobPriority | Defines the constant values that specify the priority level of a job. | Foreground, High, Normal, Low
BackgroundCopyJobSecurity | HTTP security flags that indicate which errors to ignore when connecting to the server. | AllowSilentRedirect, CheckCRL, IgnoreInvalidCerts, IgnoreExpiredCerts, IgnoreUnknownCA, IgnoreWrongCertUsage, AllowReportedRedirect, DisallowRedirect, AllowHttpsToHttpRedirect
BackgroundCopyJobState | Defines constant values for the different states of a job. | Queued, Connecting, Transferring, Suspended, Error, TransientError, Transferred, Acknowledged, Cancelled
BackgroundCopyJobType | Defines constant values that specify the type of transfer job, such as download. | Download, Upload, UploadReply
DeviceType | Represents the format of the virtual disk. | Unknown, Iso, Vhd, Vhdx, VhdSet
PathCharType |  | Invalid, LongFileName, ShortFileName, Wildcard, Separator
ProcessIntegrityLevel | Values which define a processes integrity level. | Untrusted, Undefined, Low, Medium, High, System
Subtype | Represents the subtype of a virtual disk. | Fixed, Dynamic, Differencing
