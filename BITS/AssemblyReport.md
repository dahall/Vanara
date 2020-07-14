## Assembly report for Vanara.BITS.dll
.NET classes to access Background Intelligent Transfer Service (BITS) functionality. Intelligently uses most recent library functions and gracefully fails when new features are not available on older OS versions.
### Enumerations
Enum | Description | Values
---- | ---- | ----
[Vanara.IO.BackgroundCopyACLFlags](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyACLFlags) | Flags for ACL information to maintain when using SMB to download or upload a file. | None, Owner, Group, Dacl, Sacl, All
[Vanara.IO.BackgroundCopyCost](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyCost) | Defines the constant values that specify the BITS cost state. | Unrestricted, CappedUsageUnknown, BelowCap, NearCap, OvercapCharged, OvercapThrottled, UsageBased, Roaming, Reserved, IgnoreCongestion, TransferUnrestricted, TransferStandard, TransferNoSurcharge, TransferNotRoaming, TransferAlways
[Vanara.IO.BackgroundCopyErrorContext](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyErrorContext) | Defines the constant values that specify the context in which the error occurred. | None, Unknown, GeneralQueueManager, QueueManagerNotification, LocalFile, RemoteFile, GeneralTransport, RemoteApplication
[Vanara.IO.BackgroundCopyJobCredentialScheme](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCredentialScheme) | Defines the constant values that specify the authentication scheme to use when a proxy or server requests user authentication. | Basic, Digest, NTLM, Negotiate, Passport
[Vanara.IO.BackgroundCopyJobCredentialTarget](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCredentialTarget) | Defines the constant values that specify whether the credentials are used for proxy or server user authentication requests. | Undefined, Server, Proxy
[Vanara.IO.BackgroundCopyJobPriority](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobPriority) | Defines the constant values that specify the priority level of a job. | Foreground, High, Normal, Low
[Vanara.IO.BackgroundCopyJobSecurity](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobSecurity) | HTTP security flags that indicate which errors to ignore when connecting to the server. | AllowSilentRedirect, CheckCRL, IgnoreInvalidCerts, IgnoreExpiredCerts, IgnoreUnknownCA, IgnoreWrongCertUsage, AllowReportedRedirect, DisallowRedirect, AllowHttpsToHttpRedirect
[Vanara.IO.BackgroundCopyJobState](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobState) | Defines constant values for the different states of a job. | Queued, Connecting, Transferring, Suspended, Error, TransientError, Transferred, Acknowledged, Cancelled
[Vanara.IO.BackgroundCopyJobType](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobType) | Defines constant values that specify the type of transfer job, such as download. | Download, Upload, UploadReply
### Structures
Struct | Description
---- | ----
[Vanara.IO.BackgroundCopyFileRange](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileRange) | Identifies a range of bytes to download from a file.
[Vanara.IO.BackgroundCopyJobProgress](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobProgress) | Provides job-related progress information, such as the number of bytes and files transferred. For upload jobs, the progress applies to the upload file, not the reply file.
[Vanara.IO.BackgroundCopyJobReplyProgress](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobReplyProgress) | Provides progress information related to the reply portion of an upload-reply job.
### Classes
Class | Description
---- | ----
[Vanara.IO.BackgroundCopyException](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyException) | Exceptions specific to BITS
[Vanara.IO.BackgroundCopyFileCollection](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileCollection) | Manages the set of files for a background copy job.
[Vanara.IO.BackgroundCopyFileInfo](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileInfo) | Information about a file in a background copy job.
[Vanara.IO.BackgroundCopyFileRange](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileRange) | Identifies a range of bytes to download from a file.
[Vanara.IO.BackgroundCopyFileRangesTransferredEventArgs](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileRangesTransferredEventArgs) | Used by `Vanara.IO.BackgroundCopyJob.FileRangesTransferred` events.
[Vanara.IO.BackgroundCopyFileTransferredEventArgs](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileTransferredEventArgs) | Used by `Vanara.IO.BackgroundCopyJob.FileTransferred` events.
[Vanara.IO.BackgroundCopyJob](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJob) | A job in the Background Copy Service (BITS)
[Vanara.IO.BackgroundCopyJobCollection](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCollection) | Manages the set of jobs for the background copy service (BITS).
[Vanara.IO.BackgroundCopyJobCredential](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCredential) | Represents a single BITS job credential.
[Vanara.IO.BackgroundCopyJobCredentials](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCredentials) | The list of credentials for a job.
[Vanara.IO.BackgroundCopyJobEventArgs](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobEventArgs) | Event argument for background copy job.
[Vanara.IO.BackgroundCopyManager](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyManager) | Use the BackgroundCopyManager to create transfer jobs, retrieve an enumerator object that contains the jobs in the queue, and to retrieve individual jobs from the queue.
