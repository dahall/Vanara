using System;
using static Vanara.PInvoke.BITS;

namespace Vanara.IO
{
	/// <summary>Flags for ACL information to maintain when using SMB to download or upload a file.</summary>
	[Flags]
	public enum BackgroundCopyACLFlags
	{
		/// <summary>If set exclusively, BITS uses the default ACL information of the destination folder.</summary>
		None = BG_COPY_FILE.BG_COPY_FILE_NONE,

		/// <summary>
		/// If set, the file's owner information is maintained. Otherwise, the user who calls the <see cref="BackgroundCopyJob.Complete"/>
		/// method owns the file.
		/// </summary>
		Owner = BG_COPY_FILE.BG_COPY_FILE_OWNER,

		/// <summary>
		/// If set, the file's group information is maintained. Otherwise, BITS uses the job owner's primary group to assign the group
		/// information to the file.
		/// </summary>
		Group = BG_COPY_FILE.BG_COPY_FILE_GROUP,

		/// <summary>
		/// If set, BITS copies the explicit ACEs from the source file and inheritable ACEs from the destination folder. Otherwise, BITS
		/// copies the inheritable ACEs from the destination folder. If the destination folder does not contain inheritable ACEs, BITS uses
		/// the default DACL from the owner's account.
		/// </summary>
		Dacl = BG_COPY_FILE.BG_COPY_FILE_DACL,

		/// <summary>
		/// If set, BITS copies the explicit ACEs from the source file and inheritable ACEs from the destination folder. Otherwise, BITS
		/// copies the inheritable ACEs from the destination folder.
		/// </summary>
		Sacl = BG_COPY_FILE.BG_COPY_FILE_SACL,

		/// <summary>If set, BITS copies the owner and ACL information. This is the same as setting all the flags individually.</summary>
		All = BG_COPY_FILE.BG_COPY_FILE_ALL
	}

	/// <summary>Defines the constant values that specify the BITS cost state.</summary>
	[Flags]
	public enum BackgroundCopyCost : uint
	{
		/// <summary>Unrestricted.</summary>
		Unrestricted = BITS_COST_STATE.BITS_COST_STATE_UNRESTRICTED,

		/// <summary>Capped usage unknown.</summary>
		CappedUsageUnknown = BITS_COST_STATE.BITS_COST_STATE_CAPPED_USAGE_UNKNOWN,

		/// <summary>Below cap.</summary>
		BelowCap = BITS_COST_STATE.BITS_COST_STATE_BELOW_CAP,

		/// <summary>Near cap.</summary>
		NearCap = BITS_COST_STATE.BITS_COST_STATE_NEAR_CAP,

		/// <summary>Overcap charged.</summary>
		OvercapCharged = BITS_COST_STATE.BITS_COST_STATE_OVERCAP_CHARGED,

		/// <summary>Overcap throttled.</summary>
		OvercapThrottled = BITS_COST_STATE.BITS_COST_STATE_OVERCAP_THROTTLED,

		/// <summary>Usage-based.</summary>
		UsageBased = BITS_COST_STATE.BITS_COST_STATE_USAGE_BASED,

		/// <summary>Roaming</summary>
		Roaming = BITS_COST_STATE.BITS_COST_STATE_ROAMING,

		/// <summary>Ignore congestion.</summary>
		IgnoreCongestion = BITS_COST_STATE.BITS_COST_OPTION_IGNORE_CONGESTION,

		/// <summary>Reserved.</summary>
		Reserved = BITS_COST_STATE.BITS_COST_STATE_RESERVED,

		/// <summary>Transfer not roaming.</summary>
		TransferNotRoaming = BITS_COST_STATE.BITS_COST_STATE_TRANSFER_NOT_ROAMING,

		/// <summary>Transfer no surcharge.</summary>
		TransferNoSurcharge = BITS_COST_STATE.BITS_COST_STATE_TRANSFER_NO_SURCHARGE,

		/// <summary>Transfer standard.</summary>
		TransferStandard = BITS_COST_STATE.BITS_COST_STATE_TRANSFER_STANDARD,

		/// <summary>Transfer unrestricted.</summary>
		TransferUnrestricted = BITS_COST_STATE.BITS_COST_STATE_TRANSFER_UNRESTRICTED,

		/// <summary>Transfer always.</summary>
		TransferAlways = BITS_COST_STATE.BITS_COST_STATE_TRANSFER_ALWAYS,
	}

	/// <summary>Defines the constant values that specify the context in which the error occurred.</summary>
	public enum BackgroundCopyErrorContext
	{
		/// <summary>An error has not occurred.</summary>
		None = BG_ERROR_CONTEXT.BG_ERROR_CONTEXT_NONE,

		/// <summary>The error context is unknown.</summary>
		Unknown = BG_ERROR_CONTEXT.BG_ERROR_CONTEXT_UNKNOWN,

		/// <summary>The transfer queue manager generated the error.</summary>
		GeneralQueueManager = BG_ERROR_CONTEXT.BG_ERROR_CONTEXT_GENERAL_QUEUE_MANAGER,

		/// <summary>The error was generated while the queue manager was notifying the client of an event.</summary>
		QueueManagerNotification = BG_ERROR_CONTEXT.BG_ERROR_CONTEXT_QUEUE_MANAGER_NOTIFICATION,

		/// <summary>The error was related to the specified local file. For example, permission was denied or the volume was unavailable.</summary>
		LocalFile = BG_ERROR_CONTEXT.BG_ERROR_CONTEXT_LOCAL_FILE,

		/// <summary>The error was related to the specified remote file. For example, the URL was not accessible.</summary>
		RemoteFile = BG_ERROR_CONTEXT.BG_ERROR_CONTEXT_REMOTE_FILE,

		/// <summary>
		/// The transport layer generated the error. These errors are general transport failures (these errors are not specific to the
		/// remote file).
		/// </summary>
		GeneralTransport = BG_ERROR_CONTEXT.BG_ERROR_CONTEXT_GENERAL_TRANSPORT,

		/// <summary>The server application that BITS passed the upload file to generated an error while processing the upload file.</summary>
		RemoteApplication = BG_ERROR_CONTEXT.BG_ERROR_CONTEXT_REMOTE_APPLICATION
	}

	/// <summary>Defines the constant values that specify the authentication scheme to use when a proxy or server requests user authentication.</summary>
	public enum BackgroundCopyJobCredentialScheme
	{
		/// <summary>Basic is a scheme in which the user name and password are sent in clear-text to the server or proxy.</summary>
		Basic = BG_AUTH_SCHEME.BG_AUTH_SCHEME_BASIC,

		/// <summary>Digest is a challenge-response scheme that uses a server-specified data string for the challenge.</summary>
		Digest = BG_AUTH_SCHEME.BG_AUTH_SCHEME_DIGEST,

		/// <summary>
		/// Simple and Protected Negotiation protocol (Snego) is a challenge-response scheme that negotiates with the server or proxy to
		/// determine which scheme to use for authentication. Examples are the Kerberos protocol and NTLM.
		/// </summary>
		Negotiate = BG_AUTH_SCHEME.BG_AUTH_SCHEME_NEGOTIATE,

		/// <summary>
		/// NTLM is a challenge-response scheme that uses the credentials of the user for authentication in a Windows network environment.
		/// </summary>
		NTLM = BG_AUTH_SCHEME.BG_AUTH_SCHEME_NTLM,

		/// <summary>Passport is a centralized authentication service provided by Microsoft that offers a single logon for member sites.</summary>
		Passport = BG_AUTH_SCHEME.BG_AUTH_SCHEME_PASSPORT
	}

	/// <summary>Defines the constant values that specify whether the credentials are used for proxy or server user authentication requests.</summary>
	public enum BackgroundCopyJobCredentialTarget : uint
	{
		/// <summary>Undefined.</summary>
		Undefined = 0,

		/// <summary>Use credentials for server requests.</summary>
		Server = BG_AUTH_TARGET.BG_AUTH_TARGET_SERVER,

		/// <summary>Use credentials for proxy requests.</summary>
		Proxy = BG_AUTH_TARGET.BG_AUTH_TARGET_PROXY
	}

	/// <summary>
	/// Flags that determine if the files of the job can be cached and served to peers and if BITS can download content for the job from peers.
	/// </summary>
	[Flags]
	public enum BackgroundCopyJobEnablePeerCaching
	{
		/// <summary>
		/// The job can download content from peers.
		/// <para>
		/// The job will not download from a peer unless both the client computer and the job allow Background Intelligent Transfer Service
		/// (BITS) to download files from a peer. To enable the client computer to download files from a peer, set the EnablePeerCaching
		/// group policy or call the <see cref="PeerCacheAdministration.ConfigurationFlags"/> property and set the <see
		/// cref="PeerCaching.Enable"/> flag.
		/// </para>
		/// <para>
		/// If one of the following conditions exists, BITS will stop the download and reschedule the job to begin transferring from either a
		/// peer or the origin server, depending on the value for the job and the cache:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// This value for the cache is <see langword="true"/> and the value for the job toggles between <see langword="true"/> and <see langword="false"/>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// This value for the job property is <see langword="true"/> and the value for the cache toggles between <see langword="true"/> and
		/// <see langword="false"/>.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The download will then resume from where it left off before BITS stopped the job.</para>
		/// <para><c>BITS 4.0:</c> This flag is deprecated.</para>
		/// </summary>
		EnableClient = BG_JOB_ENABLE_PEERCACHING.BG_JOB_ENABLE_PEERCACHING_CLIENT,

		/// <summary>
		/// The files of the job can be cached and served to peers.
		/// <para>
		/// BITS will not cache the files and serve them to peers unless both the client computer and job allow BITS to cache and serve the
		/// files. To allow BITS to cache and serve the files on the client computer, set the EnablePeerCaching group policy or call the <see
		/// cref="PeerCacheAdministration.ConfigurationFlags"/> property and set the <see cref="PeerCaching.EnableServer"/> flag.
		/// </para>
		/// <para><c>BITS 4.0:</c> This flag is deprecated.</para>
		/// </summary>
		EnableServer = BG_JOB_ENABLE_PEERCACHING.BG_JOB_ENABLE_PEERCACHING_SERVER,

		/// <summary>
		/// BITS will not use Windows BranchCache for transfer jobs. This setting does not affect the use of Windows BranchCache by
		/// applications other than BITS.
		/// </summary>
		DisableBranchCache = BG_JOB_ENABLE_PEERCACHING.BG_JOB_DISABLE_BRANCH_CACHE,
	}

	/// <summary>Defines the constant values that specify the priority level of a job.</summary>
	public enum BackgroundCopyJobPriority
	{
		/// <summary>
		/// Transfers the job in the foreground. Foreground transfers compete for network bandwidth with other applications, which can
		/// impede the user's network experience. This is the highest priority level.
		/// </summary>
		Foreground = BG_JOB_PRIORITY.BG_JOB_PRIORITY_FOREGROUND,

		/// <summary>
		/// Transfers the job in the background with a high priority. Background transfers use idle network bandwidth of the client to
		/// transfer files. This is the highest background priority level.
		/// </summary>
		High = BG_JOB_PRIORITY.BG_JOB_PRIORITY_HIGH,

		/// <summary>
		/// Transfers the job in the background with a normal priority. Background transfers use idle network bandwidth of the client to
		/// transfer files. This is the default priority level.
		/// </summary>
		Normal = BG_JOB_PRIORITY.BG_JOB_PRIORITY_NORMAL,

		/// <summary>
		/// Transfers the job in the background with a low priority. Background transfers use idle network bandwidth of the client to
		/// transfer files. This is the lowest background priority level.
		/// </summary>
		Low = BG_JOB_PRIORITY.BG_JOB_PRIORITY_LOW
	}

	/// <summary>HTTP security flags that indicate which errors to ignore when connecting to the server.</summary>
	[Flags]
	public enum BackgroundCopyJobSecurity
	{
		/// <summary>Allows the server to redirect your request to another server. This is the default.</summary>
		AllowSilentRedirect = BG_HTTP_SECURITY.BG_HTTP_REDIRECT_POLICY_ALLOW_SILENT,

		/// <summary>Check the certificate revocation list (CRL) to verify that the server certificate has not been revoked.</summary>
		CheckCRL = BG_HTTP_SECURITY.BG_SSL_ENABLE_CRL_CHECK,

		/// <summary>Ignores errors caused when the certificate host name of the server does not match the host name in the request.</summary>
		IgnoreInvalidCerts = BG_HTTP_SECURITY.BG_SSL_IGNORE_CERT_CN_INVALID,

		/// <summary>Ignores errors caused by an expired certificate.</summary>
		IgnoreExpiredCerts = BG_HTTP_SECURITY.BG_SSL_IGNORE_CERT_DATE_INVALID,

		/// <summary>Ignore errors associated with an unknown certification authority (CA).</summary>
		IgnoreUnknownCA = BG_HTTP_SECURITY.BG_SSL_IGNORE_UNKNOWN_CA,

		/// <summary>Ignore errors associated with the use of a certificate.</summary>
		IgnoreWrongCertUsage = BG_HTTP_SECURITY.BG_SSL_IGNORE_CERT_WRONG_USAGE,

		/// <summary>Allows the server to redirect your request to another server. BITS updates the remote name with the final URL.</summary>
		AllowReportedRedirect = BG_HTTP_SECURITY.BG_HTTP_REDIRECT_POLICY_ALLOW_REPORT,

		/// <summary>
		/// Places the job in the fatal error state when the server redirects your request to another server. BITS updates the remote name
		/// with the redirected URL.
		/// </summary>
		DisallowRedirect = BG_HTTP_SECURITY.BG_HTTP_REDIRECT_POLICY_DISALLOW,

		/// <summary>
		/// Allows the server to redirect an HTTPS request to an HTTP URL.
		/// <para>You can combine this flag with AllowSilentRedirect and AllowReportedRedirect.</para>
		/// </summary>
		AllowHttpsToHttpRedirect = BG_HTTP_SECURITY.BG_HTTP_REDIRECT_POLICY_ALLOW_HTTPS_TO_HTTP,
	}

	/// <summary>Defines constant values for the different states of a job.</summary>
	public enum BackgroundCopyJobState
	{
		/// <summary>
		/// Specifies that the job is in the queue and waiting to run. If a user logs off while their job is transferring, the job
		/// transitions to the queued state.
		/// </summary>
		Queued = BG_JOB_STATE.BG_JOB_STATE_QUEUED,

		/// <summary>
		/// Specifies that BITS is trying to connect to the server. If the connection succeeds, the state of the job becomes Transferring;
		/// otherwise, the state becomes TransientError.
		/// </summary>
		Connecting = BG_JOB_STATE.BG_JOB_STATE_CONNECTING,

		/// <summary>Specifies that BITS is transferring data for the job.</summary>
		Transferring = BG_JOB_STATE.BG_JOB_STATE_TRANSFERRING,

		/// <summary>
		/// Specifies that the job is suspended (paused). To suspend a job, call the <see cref="BackgroundCopyJob.Suspend"/> method. BITS
		/// automatically suspends a job when it is created. The job remains suspended until you call the <see
		/// cref="BackgroundCopyJob.Resume"/>, <see cref="BackgroundCopyJob.Complete"/>, or <see cref="BackgroundCopyJob.Cancel"/> method.
		/// </summary>
		Suspended = BG_JOB_STATE.BG_JOB_STATE_SUSPENDED,

		/// <summary>
		/// Specifies that a non-recoverable error occurred (the service is unable to transfer the file). If the error, such as an
		/// access-denied error, can be corrected, call the <see cref="BackgroundCopyJob.Resume"/> method after the error is fixed. However,
		/// if the error cannot be corrected, call the <see cref="BackgroundCopyJob.Cancel"/> method to cancel the job, or call the <see
		/// cref="BackgroundCopyJob.Complete"/> method to accept the portion of a download job that transferred successfully.
		/// </summary>
		Error = BG_JOB_STATE.BG_JOB_STATE_ERROR,

		/// <summary>
		/// Specifies that a recoverable error occurred. BITS will retry jobs in the transient error state based on the retry interval you
		/// specify (see <see cref="BackgroundCopyJob.MinimumRetryDelay"/>). The state of the job changes to <see
		/// cref="BackgroundCopyJobState.Error"/> if the job fails to make progress (see <see cref="BackgroundCopyJob.NoProgressTimeout"/>).
		/// BITS does not retry the job if a network disconnect or disk lock error occurred (for example, chkdsk is running) or the
		/// MaxInternetBandwidth Group Policy is zero.
		/// </summary>
		TransientError = BG_JOB_STATE.BG_JOB_STATE_TRANSIENT_ERROR,

		/// <summary>
		/// Specifies that your job was successfully processed. You must call the <see cref="BackgroundCopyJob.Complete"/> method to
		/// acknowledge completion of the job and to make the files available to the client.
		/// </summary>
		Transferred = BG_JOB_STATE.BG_JOB_STATE_TRANSFERRED,

		/// <summary>
		/// Specifies that you called the <see cref="BackgroundCopyJob.Complete"/> method to acknowledge that your job completed successfully.
		/// </summary>
		Acknowledged = BG_JOB_STATE.BG_JOB_STATE_ACKNOWLEDGED,

		/// <summary>
		/// Specifies that you called the <see cref="BackgroundCopyJob.Cancel"/> method to cancel the job (remove the job from the transfer queue).
		/// </summary>
		Cancelled = BG_JOB_STATE.BG_JOB_STATE_CANCELLED
	}

	/// <summary>Defines constant values that specify the type of transfer job, such as download.</summary>
	public enum BackgroundCopyJobType
	{
		/// <summary>Specifies that the job downloads files to the client.</summary>
		Download = BG_JOB_TYPE.BG_JOB_TYPE_DOWNLOAD,

		/// <summary>Specifies that the job uploads a file to the server.</summary>
		Upload = BG_JOB_TYPE.BG_JOB_TYPE_UPLOAD,

		/// <summary>Specifies that the job uploads a file to the server and receives a reply file from the server application.</summary>
		UploadReply = BG_JOB_TYPE.BG_JOB_TYPE_UPLOAD_REPLY
	}
	/// <summary>Flags that determine if the computer serves content to peers and can download content from peers.</summary>
	[Flags]
	public enum PeerCaching
	{
		/// <summary>
		/// The computer can download content from peers.
		/// <para>
		/// BITS will not download files from a peer unless both the client computer and the job permit BITS to download files from a peer.
		/// To permits the job to download files from a peer, use the <see cref="BackgroundCopyJob.PeerCachingEnablment"/> property and set
		/// the <see cref="BackgroundCopyJobEnablePeerCaching.EnableClient"/> flag.
		/// </para>
		/// <para>
		/// Note that changing this value can affect all jobs on the computer. If one of the following conditions exists, BITS will stop the
		/// download and reschedule the job to begin transferring from either a peer or the origin server, depending on the value for the job
		/// and the cache:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// This value for the cache is <see langword="true"/> and the value for the job toggles between <see langword="true"/> and <see langword="false"/>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// This value for the job property is <see langword="true"/> and the value for the cache toggles between <see langword="true"/> and
		/// <see langword="false"/>.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The download will then resume from where it left off before BITS stopped the job.</para>
		/// </summary>
		EnableClient = BG_ENABLE_PEERCACHING.BG_ENABLE_PEERCACHING_CLIENT,

		/// <summary>
		/// The computer can serve content to peers.
		/// <para>
		/// BITS will not cache the files and serve them to peers unless both the client computer and job permit BITS to cache and serve
		/// files. To permit the job to cache files for a job, use the <see cref="BackgroundCopyJob.PeerCachingEnablment"/> property and set
		/// the <see cref="BackgroundCopyJobEnablePeerCaching.EnableServer"/> flag.
		/// </para>
		/// </summary>
		EnableServer = BG_ENABLE_PEERCACHING.BG_ENABLE_PEERCACHING_SERVER,
	}
}