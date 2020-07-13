## Assembly report for Vanara.BITS.dll
### Enumerations
Enum | Description | Values
---- | ---- | ----
[Vanara.IO.BackgroundCopyACLFlags](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyACLFlags) |  | None, Owner, Group, Dacl, Sacl, All
[Vanara.IO.BackgroundCopyCost](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyCost) |  | Unrestricted, CappedUsageUnknown, BelowCap, NearCap, OvercapCharged, OvercapThrottled, UsageBased, Roaming, Reserved, IgnoreCongestion, TransferUnrestricted, TransferStandard, TransferNoSurcharge, TransferNotRoaming, TransferAlways
[Vanara.IO.BackgroundCopyErrorContext](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyErrorContext) |  | None, Unknown, GeneralQueueManager, QueueManagerNotification, LocalFile, RemoteFile, GeneralTransport, RemoteApplication
[Vanara.IO.BackgroundCopyJobCredentialScheme](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCredentialScheme) |  | Basic, Digest, NTLM, Negotiate, Passport
[Vanara.IO.BackgroundCopyJobCredentialTarget](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCredentialTarget) |  | Undefined, Server, Proxy
[Vanara.IO.BackgroundCopyJobPriority](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobPriority) |  | Foreground, High, Normal, Low
[Vanara.IO.BackgroundCopyJobSecurity](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobSecurity) |  | AllowSilentRedirect, CheckCRL, IgnoreInvalidCerts, IgnoreExpiredCerts, IgnoreUnknownCA, IgnoreWrongCertUsage, AllowReportedRedirect, DisallowRedirect, AllowHttpsToHttpRedirect
[Vanara.IO.BackgroundCopyJobState](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobState) |  | Queued, Connecting, Transferring, Suspended, Error, TransientError, Transferred, Acknowledged, Cancelled
[Vanara.IO.BackgroundCopyJobType](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobType) |  | Download, Upload, UploadReply
### Structures
Struct | Description
---- | ----
[Vanara.IO.BackgroundCopyFileRange](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileRange) | 
[Vanara.IO.BackgroundCopyJobProgress](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobProgress) | 
[Vanara.IO.BackgroundCopyJobReplyProgress](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobReplyProgress) | 
### Classes
Class | Description
---- | ----
[Vanara.IO.BackgroundCopyException](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyException) | 
[Vanara.IO.BackgroundCopyFileCollection](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileCollection) | 
[Vanara.IO.BackgroundCopyFileInfo](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileInfo) | 
[Vanara.IO.BackgroundCopyFileRange](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileRange) | 
[Vanara.IO.BackgroundCopyFileRangesTransferredEventArgs](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileRangesTransferredEventArgs) | 
[Vanara.IO.BackgroundCopyFileTransferredEventArgs](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyFileTransferredEventArgs) | 
[Vanara.IO.BackgroundCopyJob](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJob) | 
[Vanara.IO.BackgroundCopyJobCollection](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCollection) | 
[Vanara.IO.BackgroundCopyJobCredential](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCredential) | 
[Vanara.IO.BackgroundCopyJobCredentials](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobCredentials) | 
[Vanara.IO.BackgroundCopyJobEventArgs](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyJobEventArgs) | 
[Vanara.IO.BackgroundCopyManager](https://github.com/dahall/Vanara/search?l=C%23&q=BackgroundCopyManager) | 
