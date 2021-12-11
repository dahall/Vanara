using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>
	/// Background Intelligent Transfer Service (BITS) transfers files (downloads or uploads) between a client and server and provides
	/// progress information related to the transfers. You can also download files from a peer.
	/// </summary>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/bb968799(v=vs.85).aspx
	public static class BITS
	{
		/// <summary>
		/// The <c>BG_AUTH_SCHEME</c> enumeration defines the constant values that specify the authentication scheme to use when a proxy or
		/// server requests user authentication.
		/// </summary>
		// typedef enum { BG_AUTH_SCHEME_BASIC = 1, BG_AUTH_SCHEME_DIGEST, BG_AUTH_SCHEME_NTLM, BG_AUTH_SCHEME_NEGOTIATE,
		// BG_AUTH_SCHEME_PASSPORT} BG_AUTH_SCHEME; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362789(v=vs.85).aspx
		[PInvokeData("Bits1_5.h", MSDNShortId = "aa362789")]
		public enum BG_AUTH_SCHEME
		{
			/// <summary>Basic is a scheme in which the user name and password are sent in clear-text to the server or proxy.</summary>
			BG_AUTH_SCHEME_BASIC = 1,

			/// <summary>Digest is a challenge-response scheme that uses a server-specified data string for the challenge.</summary>
			BG_AUTH_SCHEME_DIGEST = 2,

			/// <summary>
			/// Simple and Protected Negotiation protocol (Snego) is a challenge-response scheme that negotiates with the server or proxy to
			/// determine which scheme to use for authentication. Examples are the Kerberos protocol and NTLM.
			/// </summary>
			BG_AUTH_SCHEME_NEGOTIATE = 4,

			/// <summary>
			/// NTLM is a challenge-response scheme that uses the credentials of the user for authentication in a Windows network environment.
			/// </summary>
			BG_AUTH_SCHEME_NTLM = 3,

			/// <summary>
			/// Passport is a centralized authentication service provided by Microsoft that offers a single logon for member sites.
			/// </summary>
			BG_AUTH_SCHEME_PASSPORT = 5
		}

		/// <summary>
		/// The <c>BG_AUTH_TARGET</c> enumeration defines the constant values that specify whether the credentials are used for proxy or
		/// server user authentication requests.
		/// </summary>
		// typedef enum { BG_AUTH_TARGET_SERVER = 1, BG_AUTH_TARGET_PROXY} BG_AUTH_TARGET; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362791(v=vs.85).aspx
		[PInvokeData("Bits1_5.h", MSDNShortId = "aa362791")]
		public enum BG_AUTH_TARGET : uint
		{
			/// <summary>Use credentials for proxy requests.</summary>
			BG_AUTH_TARGET_PROXY = 2,

			/// <summary>Use credentials for server requests.</summary>
			BG_AUTH_TARGET_SERVER = 1
		}

		/// <summary>The <c>BG_CERT_STORE_LOCATION</c> enumeration defines the location of the certificate store.</summary>
		// typedef enum { BG_CERT_STORE_LOCATION_CURRENT_USER, BG_CERT_STORE_LOCATION_LOCAL_MACHINE, BG_CERT_STORE_LOCATION_CURRENT_SERVICE,
		// BG_CERT_STORE_LOCATION_SERVICES, BG_CERT_STORE_LOCATION_USERS, BG_CERT_STORE_LOCATION_CURRENT_USER_GROUP_POLICY,
		// BG_CERT_STORE_LOCATION_LOCAL_MACHINE_GROUP_POLICY, BG_CERT_STORE_LOCATION_LOCAL_MACHINE_ENTERPRISE} BG_CERT_STORE_LOCATION; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362796(v=vs.85).aspx
		[PInvokeData("Bits2_5.h", MSDNShortId = "aa362796")]
		public enum BG_CERT_STORE_LOCATION
		{
			/// <summary>Use the current user's certificate store.</summary>
			BG_CERT_STORE_LOCATION_CURRENT_USER,

			/// <summary>Use the local computer's certificate store.</summary>
			BG_CERT_STORE_LOCATION_LOCAL_MACHINE,

			/// <summary>Use the current service's certificate store.</summary>
			BG_CERT_STORE_LOCATION_CURRENT_SERVICE,

			/// <summary>Use a specific service's certificate store.</summary>
			BG_CERT_STORE_LOCATION_SERVICES,

			/// <summary>Use a specific user's certificate store.</summary>
			BG_CERT_STORE_LOCATION_USERS,

			/// <summary>
			/// Use the current user's group policy certificate store. In a network setting, stores in this location are downloaded to the
			/// client computer from the Group Policy Template (GPT) during computer startup or user logon.
			/// </summary>
			BG_CERT_STORE_LOCATION_CURRENT_USER_GROUP_POLICY,

			/// <summary>
			/// Use the local computer's certificate store. In a network setting, stores in this location are downloaded to the client
			/// computer from the Group Policy Template (GPT) during computer startup or user logon.
			/// </summary>
			BG_CERT_STORE_LOCATION_LOCAL_MACHINE_GROUP_POLICY,

			/// <summary>
			/// Use the enterprise certificate store. The enterprise store is shared across domains in the enterprise and downloaded from the
			/// global enterprise directory.
			/// </summary>
			BG_CERT_STORE_LOCATION_LOCAL_MACHINE_ENTERPRISE,
		}

		/// <summary>Flags that identify the owner and ACL information to maintain when transferring a file using SMB.</summary>
		[Flags]
		public enum BG_COPY_FILE
		{
			/// <summary>No flags are set.</summary>
			BG_COPY_FILE_NONE = 0x00,

			/// <summary>If set, the file's owner information is maintained. Otherwise, the job's owner becomes the owner of the file.</summary>
			BG_COPY_FILE_OWNER = 0x01,

			/// <summary>
			/// If set, the file's group information is maintained. Otherwise, BITS uses the job owner's primary group to assign the group
			/// information to the file.
			/// </summary>
			BG_COPY_FILE_GROUP = 0x02,

			/// <summary>
			/// If set, BITS copies the explicit ACEs from the source file and inheritable ACEs from the destination parent folder.
			/// Otherwise, BITS copies the inheritable ACEs from the destination parent folder. If the parent folder does not contain
			/// inheritable ACEs, BITS uses the default DACL from the account.
			/// </summary>
			BG_COPY_FILE_DACL = 0x04,

			/// <summary>
			/// If set, BITS copies the explicit ACEs from the source file and inheritable ACEs from the destination parent folder.
			/// Otherwise, BITS copies the inheritable ACEs from the destination parent folder.
			/// </summary>
			BG_COPY_FILE_SACL = 0x08,

			/// <summary>If set, BITS copies the owner and ACL information. This is the same as setting all the flags individually.</summary>
			BG_COPY_FILE_ALL = 0x0F,
		}

		/// <summary>Flags that determine if the computer serves content to peers and can download content from peers.</summary>
		public enum BG_ENABLE_PEERCACHING
		{
			/// <summary>
			/// The computer can download content from peers.
			/// <para>
			/// BITS will not download files from a peer unless both the client computer and the job permit BITS to download files from a
			/// peer. To permits the job to download files from a peer, call the IBackgroundCopyJob4::SetPeerCachingFlags method and set the
			/// BG_JOB_ENABLE_PEERCACHING_CLIENT flag.
			/// </para>
			/// <para>
			/// Note that changing this value can affect all jobs on the computer. If one of the following conditions exists, BITS will stop
			/// the download and reschedule the job to begin transferring from either a peer or the origin server, depending on the value for
			/// the job and the cache:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>This value for the cache is TRUE and the value for the job toggles between TRUE and FALSE.</term>
			/// </item>
			/// <item>
			/// <term>This value for the job property is TRUE and the value for the cache toggles between TRUE and FALSE.</term>
			/// </item>
			/// </list>
			/// <para>The download will then resume from where it left off before BITS stopped the job.</para>
			/// </summary>
			BG_ENABLE_PEERCACHING_CLIENT = 0x0001,

			/// <summary>
			/// The computer can serve content to peers.
			/// <para>
			/// BITS will not cache the files and serve them to peers unless both the client computer and job permit BITS to cache and serve
			/// files. To permit the job to cache files for a job, call the IBackgroundCopyJob4::SetPeerCachingFlags method and set the
			/// BG_JOB_ENABLE_PEERCACHING_SERVER flag.
			/// </para>
			/// </summary>
			BG_ENABLE_PEERCACHING_SERVER = 0x0002,
		}

		/// <summary>
		/// The <c>BG_ERROR_CONTEXT</c> enumeration defines the constant values that specify the context in which the error occurred.
		/// </summary>
		// typedef enum { BG_ERROR_CONTEXT_NONE = 0, BG_ERROR_CONTEXT_UNKNOWN = 1, BG_ERROR_CONTEXT_GENERAL_QUEUE_MANAGER = 2,
		// BG_ERROR_CONTEXT_QUEUE_MANAGER_NOTIFICATION = 3, BG_ERROR_CONTEXT_LOCAL_FILE = 4, BG_ERROR_CONTEXT_REMOTE_FILE = 5, BG_ERROR_CONTEXT_GENERAL_TRANSPORT
		// = 6, BG_ERROR_CONTEXT_REMOTE_APPLICATION = 7} BG_ERROR_CONTEXT; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362798(v=vs.85).aspx
		[PInvokeData("Bits.h", MSDNShortId = "aa362798")]
		public enum BG_ERROR_CONTEXT
		{
			/// <summary>An error has not occurred.</summary>
			BG_ERROR_CONTEXT_NONE,

			/// <summary>The error context is unknown.</summary>
			BG_ERROR_CONTEXT_UNKNOWN,

			/// <summary>The transfer queue manager generated the error.</summary>
			BG_ERROR_CONTEXT_GENERAL_QUEUE_MANAGER,

			/// <summary>The error was generated while the queue manager was notifying the client of an event.</summary>
			BG_ERROR_CONTEXT_QUEUE_MANAGER_NOTIFICATION,

			/// <summary>The error was related to the specified local file. For example, permission was denied or the volume was unavailable.</summary>
			BG_ERROR_CONTEXT_LOCAL_FILE,

			/// <summary>The error was related to the specified remote file. For example, the URL was not accessible.</summary>
			BG_ERROR_CONTEXT_REMOTE_FILE,

			/// <summary>
			/// The transport layer generated the error. These errors are general transport failures (these errors are not specific to the
			/// remote file).
			/// </summary>
			BG_ERROR_CONTEXT_GENERAL_TRANSPORT,

			/// <summary>
			/// <para>The server application that BITS passed the upload file to generated an error while processing the upload file.</para>
			/// <para><c>BITS 1.2 and earlier:</c> Not supported.</para>
			/// </summary>
			BG_ERROR_CONTEXT_REMOTE_APPLICATION
		}

		/// <summary>HTTP security flags that indicate which errors to ignore when connecting to the server.</summary>
		[Flags]
		public enum BG_HTTP_SECURITY
		{
			/// <summary>Allows the server to redirect your request to another server. This is the default.</summary>
			BG_HTTP_REDIRECT_POLICY_ALLOW_SILENT = 0x0000,

			/// <summary>Check the certificate revocation list (CRL) to verify that the server certificate has not been revoked.</summary>
			BG_SSL_ENABLE_CRL_CHECK = 0x0001,

			/// <summary>Ignores errors caused when the certificate host name of the server does not match the host name in the request.</summary>
			BG_SSL_IGNORE_CERT_CN_INVALID = 0x0002,

			/// <summary>Ignores errors caused by an expired certificate.</summary>
			BG_SSL_IGNORE_CERT_DATE_INVALID = 0x0004,

			/// <summary>Ignore errors associated with an unknown certification authority (CA).</summary>
			BG_SSL_IGNORE_UNKNOWN_CA = 0x0008,

			/// <summary>Ignore errors associated with the use of a certificate.</summary>
			BG_SSL_IGNORE_CERT_WRONG_USAGE = 0x0010,

			/// <summary>Allows the server to redirect your request to another server. BITS updates the remote name with the final URL.</summary>
			BG_HTTP_REDIRECT_POLICY_ALLOW_REPORT = 0x0100,

			/// <summary>
			/// Places the job in the fatal error state when the server redirects your request to another server. BITS updates the remote
			/// name with the redirected URL.
			/// </summary>
			BG_HTTP_REDIRECT_POLICY_DISALLOW = 0x0200,

			/// <summary>
			/// Bitmask that you can use with the security flag value to determine which redirect policy is in effect. It does not include
			/// the flag ALLOW_HTTPS_TO_HTTP.
			/// </summary>
			BG_HTTP_REDIRECT_POLICY_MASK = 0x0700,

			/// <summary>
			/// Allows the server to redirect an HTTPS request to an HTTP URL.
			/// <para>You can combine this flag with BG_HTTP_REDIRECT_POLICY_ALLOW_SILENT and BG_HTTP_REDIRECT_POLICY_ALLOW_REPORT.</para>
			/// </summary>
			BG_HTTP_REDIRECT_POLICY_ALLOW_HTTPS_TO_HTTP = 0x0800,
		}

		/// <summary>
		/// Flags that determine if the files of the job can be cached and served to peers and if BITS can download content for the job from peers.
		/// </summary>
		public enum BG_JOB_ENABLE_PEERCACHING
		{
			/// <summary>
			/// The job can download content from peers.
			/// <para>
			/// The job will not download from a peer unless both the client computer and the job allow Background Intelligent Transfer
			/// Service (BITS) to download files from a peer. To enable the client computer to download files from a peer, set the
			/// EnablePeerCaching group policy or call the IBitsPeerCacheAdministration::SetConfigurationFlags method and set the
			/// BG_ENABLE_PEERCACHING_CLIENT flag.
			/// </para>
			/// <para>
			/// If one of the following conditions exists, BITS will stop the download and reschedule the job to begin transferring from
			/// either a peer or the origin server, depending on the value for the job and the cache:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>This value for the cache is TRUE and the value for the job toggles between TRUE and FALSE.</term>
			/// </item>
			/// <item>
			/// <term>This value for the job property is TRUE and the value for the cache toggles between TRUE and FALSE.</term>
			/// </item>
			/// </list>
			/// <para>The download will then resume from where it left off before BITS stopped the job.</para>
			/// <para><c>BITS 4.0:</c> This flag is deprecated.</para>
			/// </summary>
			BG_JOB_ENABLE_PEERCACHING_CLIENT = 0x0001,

			/// <summary>
			/// The files of the job can be cached and served to peers.
			/// <para>
			/// BITS will not cache the files and serve them to peers unless both the client computer and job allow BITS to cache and serve
			/// the files. To allow BITS to cache and serve the files on the client computer, set the EnablePeerCaching group policy or call
			/// the IBitsPeerCacheAdministration::SetConfigurationFlags method and set the BG_ENABLE_PEERCACHING_SERVER flag.
			/// </para>
			/// <para><c>BITS 4.0:</c> This flag is deprecated.</para>
			/// </summary>
			BG_JOB_ENABLE_PEERCACHING_SERVER = 0x0002,

			/// <summary>
			/// BITS will not use Windows BranchCache for transfer jobs. This setting does not affect the use of Windows BranchCache by
			/// applications other than BITS.
			/// </summary>
			BG_JOB_DISABLE_BRANCH_CACHE = 0x0004,
		}

		/// <summary>Specifies whose jobs to include in the enumeration.</summary>
		public enum BG_JOB_ENUM
		{
			/// <summary>The user receives all jobs that they own in the transfer queue.</summary>
			BG_JOB_ENUM_USER = 0,

			/// <summary>
			/// Includes all jobs in the transfer queue—those owned by the user and those owned by others. The user must be an administrator
			/// to use this flag.
			/// </summary>
			BG_JOB_ENUM_ALL_USERS = 1
		}

		/// <summary>The <c>BG_JOB_PRIORITY</c> enumeration defines the constant values that specify the priority level of a job.</summary>
		// typedef enum { BG_JOB_PRIORITY_FOREGROUND, BG_JOB_PRIORITY_HIGH, BG_JOB_PRIORITY_NORMAL, BG_JOB_PRIORITY_LOW} BG_JOB_PRIORITY; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362805(v=vs.85).aspx
		[PInvokeData("Bits.h", MSDNShortId = "aa362805")]
		public enum BG_JOB_PRIORITY
		{
			/// <summary>
			/// Transfers the job in the foreground. Foreground transfers compete for network bandwidth with other applications, which can
			/// impede the user's network experience. This is the highest priority level.
			/// </summary>
			BG_JOB_PRIORITY_FOREGROUND,

			/// <summary>
			/// Transfers the job in the background with a high priority. Background transfers use idle network bandwidth of the client to
			/// transfer files. This is the highest background priority level.
			/// </summary>
			BG_JOB_PRIORITY_HIGH,

			/// <summary>
			/// Transfers the job in the background with a normal priority. Background transfers use idle network bandwidth of the client to
			/// transfer files. This is the default priority level.
			/// </summary>
			BG_JOB_PRIORITY_NORMAL,

			/// <summary>
			/// Transfers the job in the background with a low priority. Background transfers use idle network bandwidth of the client to
			/// transfer files. This is the lowest background priority level.
			/// </summary>
			BG_JOB_PRIORITY_LOW
		}

		/// <summary>
		/// The <c>BG_JOB_PROXY_USAGE</c> enumeration defines constant values that specify which proxy to use for file transfers. You can
		/// define different proxy settings for each job.
		/// </summary>
		// typedef enum { BG_JOB_PROXY_USAGE_PRECONFIG, BG_JOB_PROXY_USAGE_NO_PROXY, BG_JOB_PROXY_USAGE_OVERRIDE,
		// BG_JOB_PROXY_USAGE_AUTODETECT} BG_JOB_PROXY_USAGE; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362807(v=vs.85).aspx
		[PInvokeData("Bits.h", MSDNShortId = "aa362807")]
		public enum BG_JOB_PROXY_USAGE
		{
			/// <summary>
			/// Use the proxy and proxy bypass list settings defined by each user to transfer files. Settings are user-defined from Control
			/// Panel, Internet Options, Connections, Local Area Network (LAN) settings (or Dial-up settings, depending on the network connection).
			/// </summary>
			BG_JOB_PROXY_USAGE_PRECONFIG,

			/// <summary>Do not use a proxy to transfer files. Use this option when you transfer files within a LAN.</summary>
			BG_JOB_PROXY_USAGE_NO_PROXY,

			/// <summary>
			/// Use the application's proxy and proxy bypass list to transfer files. Use this option when you cannot trust that the system
			/// settings are correct. Also use this option when you want to transfer files using a special account, such as LocalSystem, to
			/// which the system settings do not apply.
			/// </summary>
			BG_JOB_PROXY_USAGE_OVERRIDE,

			/// <summary>
			/// <para>Automatically detect proxy settings. BITS detects proxy settings for each file in the job.</para>
			/// <para><c>BITS 1.5 and earlier:</c><c>BG_JOB_PROXY_USAGE_AUTODETECT</c> is not available.</para>
			/// </summary>
			BG_JOB_PROXY_USAGE_AUTODETECT,
		}

		/// <summary>The <c>BG_JOB_STATE</c> enumeration defines constant values for the different states of a job.</summary>
		// typedef enum { BG_JOB_STATE_QUEUED, BG_JOB_STATE_CONNECTING, BG_JOB_STATE_TRANSFERRING, BG_JOB_STATE_SUSPENDED,
		// BG_JOB_STATE_ERROR, BG_JOB_STATE_TRANSIENT_ERROR, BG_JOB_STATE_TRANSFERRED, BG_JOB_STATE_ACKNOWLEDGED, BG_JOB_STATE_CANCELLED}
		// BG_JOB_STATE; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362809(v=vs.85).aspx
		[PInvokeData("Bits.h", MSDNShortId = "aa362809")]
		public enum BG_JOB_STATE
		{
			/// <summary>
			/// Specifies that the job is in the queue and waiting to run. If a user logs off while their job is transferring, the job
			/// transitions to the queued state.
			/// </summary>
			BG_JOB_STATE_QUEUED,

			/// <summary>
			/// Specifies that BITS is trying to connect to the server. If the connection succeeds, the state of the job becomes
			/// <c>BG_JOB_STATE_TRANSFERRING</c>; otherwise, the state becomes <c>BG_JOB_STATE_TRANSIENT_ERROR</c>.
			/// </summary>
			BG_JOB_STATE_CONNECTING,

			/// <summary>Specifies that BITS is transferring data for the job.</summary>
			BG_JOB_STATE_TRANSFERRING,

			/// <summary>
			/// Specifies that the job is suspended (paused). To suspend a job, call the <c>IBackgroundCopyJob::Suspend</c> method. BITS
			/// automatically suspends a job when it is created. The job remains suspended until you call the
			/// <c>IBackgroundCopyJob::Resume</c>, <c>IBackgroundCopyJob::Complete</c>, or <c>IBackgroundCopyJob::Cancel</c> method.
			/// </summary>
			BG_JOB_STATE_SUSPENDED,

			/// <summary>
			/// Specifies that a nonrecoverable error occurred (the service is unable to transfer the file). If the error, such as an
			/// access-denied error, can be corrected, call the <c>IBackgroundCopyJob::Resume</c> method after the error is fixed. However,
			/// if the error cannot be corrected, call the <c>IBackgroundCopyJob::Cancel</c> method to cancel the job, or call the
			/// <c>IBackgroundCopyJob::Complete</c> method to accept the portion of a download job that transferred successfully.
			/// </summary>
			BG_JOB_STATE_ERROR,

			/// <summary>
			/// <para>
			/// Specifies that a recoverable error occurred. BITS will retry jobs in the transient error state based on the retry interval
			/// you specify (see <c>IBackgroundCopyJob::SetMinimumRetryDelay</c>). The state of the job changes to <c>BG_JOB_STATE_ERROR</c>
			/// if the job fails to make progress (see <c>IBackgroundCopyJob::SetNoProgressTimeout</c>).
			/// </para>
			/// <para>
			/// BITS does not retry the job if a network disconnect or disk lock error occurred (for example, chkdsk is running) or the
			/// MaxInternetBandwidth Group Policy is zero.
			/// </para>
			/// </summary>
			BG_JOB_STATE_TRANSIENT_ERROR,

			/// <summary>
			/// Specifies that your job was successfully processed. You must call the <c>IBackgroundCopyJob::Complete</c> method to
			/// acknowledge completion of the job and to make the files available to the client.
			/// </summary>
			BG_JOB_STATE_TRANSFERRED,

			/// <summary>
			/// Specifies that you called the <c>IBackgroundCopyJob::Complete</c> method to acknowledge that your job completed successfully.
			/// </summary>
			BG_JOB_STATE_ACKNOWLEDGED,

			/// <summary>
			/// Specifies that you called the <c>IBackgroundCopyJob::Cancel</c> method to cancel the job (remove the job from the transfer queue).
			/// </summary>
			BG_JOB_STATE_CANCELLED
		}

		/// <summary>The <c>BG_JOB_TYPE</c> enumeration defines constant values that specify the type of transfer job, such as download.</summary>
		// typedef enum { BG_JOB_TYPE_DOWNLOAD, BG_JOB_TYPE_UPLOAD, BG_JOB_TYPE_UPLOAD_REPLY} BG_JOB_TYPE; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362811(v=vs.85).aspx
		[PInvokeData("Bits.h", MSDNShortId = "aa362811")]
		public enum BG_JOB_TYPE
		{
			/// <summary>Specifies that the job downloads files to the client.</summary>
			BG_JOB_TYPE_DOWNLOAD,

			/// <summary>
			/// <para>Specifies that the job uploads a file to the server.</para>
			/// <para><c>BITS 1.2 and earlier:</c> Not supported.</para>
			/// </summary>
			BG_JOB_TYPE_UPLOAD,

			/// <summary>
			/// <para>Specifies that the job uploads a file to the server and receives a reply file from the server application.</para>
			/// <para><c>BITS 1.2 and earlier:</c> Not supported.</para>
			/// </summary>
			BG_JOB_TYPE_UPLOAD_REPLY
		}

		/// <summary>Identifies the events that your application receives.</summary>
		[Flags]
		public enum BG_NOTIFY
		{
			/// <summary>All of the files in the job have been transferred.</summary>
			BG_NOTIFY_JOB_TRANSFERRED = 0x0001,

			/// <summary>An error has occurred.</summary>
			BG_NOTIFY_JOB_ERROR = 0x0002,

			/// <summary>Event notification is disabled. If set, BITS ignores the other flags.</summary>
			BG_NOTIFY_DISABLE = 0x0004,

			/// <summary>
			/// The job has been modified. For example, a property value changed, the state of the job changed, or progress is made
			/// transferring the files. This flag is ignored in command-line callbacks if command line notification is specified.
			/// </summary>
			BG_NOTIFY_JOB_MODIFICATION = 0x0008,

			/// <summary>
			/// A file in the job has been transferred. This flag is ignored in command-line callbacks if command line notification is specified.
			/// </summary>
			BG_NOTIFY_FILE_TRANSFERRED = 0x0010,

			/// <summary>
			/// A range of bytes in the file has been transferred. This flag is ignored in command-line callbacks if command line
			/// notification is specified. The flag can be specified for any job, but you will only get notifications for jobs that meet the
			/// requirements for a BITS_JOB_PROPERTY_ON_DEMAND_MODE job.
			/// </summary>
			BG_NOTIFY_FILE_RANGES_TRANSFERRED = 0x0020,
		}

		/// <summary>Specifies the usage flag.</summary>
		public enum BG_TOKEN
		{
			/// <summary>
			/// If this flag is specified, the helper token is used
			/// <list type="bullet">
			/// <item>
			/// <term>To open the local file of an upload job</term>
			/// </item>
			/// <item>
			/// <term>To create or rename the temporary file of a download job</term>
			/// </item>
			/// <item>
			/// <term>To create or rename the reply file of an upload-reply job</term>
			/// </item>
			/// </list>
			/// </summary>
			BG_TOKEN_LOCAL_FILE = 0x0001,

			/// <summary>
			/// If this flag is specified, the helper token is used
			/// <list type="bullet">
			/// <item>
			/// <term>To open the remote file of a Server Message Block (SMB) upload or download job</term>
			/// </item>
			/// <item>
			/// <term>In response to an HTTP server or proxy challenge for implicit NTLM or Kerberos credentials</term>
			/// </item>
			/// <item>
			/// <term>
			/// An application is required to call IBackgroundCopyJob2::SetCredentials (..., NULL, NULL) to allow the credentials to be sent
			/// over HTTP.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// An application is required to call IBackgroundCopyJob2::SetCredentials (..., NULL, NULL) to allow the credentials to be sent
			/// over HTTP.
			/// </para>
			/// </summary>
			BG_TOKEN_NETWORK = 0x0002,
		}

		/// <summary>The BITS_COST_STATE enumeration defines the constant values that specify the BITS cost state.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/Bits/bits-cost-state
		[PInvokeData("Bits5_0.h", MSDNShortId = "A8C36D4E-98B3-45C4-9ECD-9B5280133176")]
		[Flags]
		public enum BITS_COST_STATE : uint
		{
			/// <summary>Unrestricted.</summary>
			BITS_COST_STATE_UNRESTRICTED = 0x1,

			/// <summary>Capped usage unknown.</summary>
			BITS_COST_STATE_CAPPED_USAGE_UNKNOWN = 0x2,

			/// <summary>Below cap.</summary>
			BITS_COST_STATE_BELOW_CAP = 0x4,

			/// <summary>Near cap.</summary>
			BITS_COST_STATE_NEAR_CAP = 0x8,

			/// <summary>Overcap charged.</summary>
			BITS_COST_STATE_OVERCAP_CHARGED = 0x10,

			/// <summary>Overcap throttled.</summary>
			BITS_COST_STATE_OVERCAP_THROTTLED = 0x20,

			/// <summary>Usage-based.</summary>
			BITS_COST_STATE_USAGE_BASED = 0x40,

			/// <summary>Roaming</summary>
			BITS_COST_STATE_ROAMING = 0x80,

			/// <summary>Ignore congestion.</summary>
			BITS_COST_OPTION_IGNORE_CONGESTION = 0x80000000,

			/// <summary>Reserved.</summary>
			BITS_COST_STATE_RESERVED = 0x40000000,

			/// <summary>Transfer not roaming.</summary>
			BITS_COST_STATE_TRANSFER_NOT_ROAMING = (BITS_COST_OPTION_IGNORE_CONGESTION | BITS_COST_STATE_USAGE_BASED | BITS_COST_STATE_OVERCAP_THROTTLED | BITS_COST_STATE_OVERCAP_CHARGED | BITS_COST_STATE_NEAR_CAP | BITS_COST_STATE_BELOW_CAP | BITS_COST_STATE_CAPPED_USAGE_UNKNOWN | BITS_COST_STATE_UNRESTRICTED),

			/// <summary>Transfer no surcharge.</summary>
			BITS_COST_STATE_TRANSFER_NO_SURCHARGE = (BITS_COST_OPTION_IGNORE_CONGESTION | BITS_COST_STATE_USAGE_BASED | BITS_COST_STATE_OVERCAP_THROTTLED | BITS_COST_STATE_NEAR_CAP | BITS_COST_STATE_BELOW_CAP | BITS_COST_STATE_CAPPED_USAGE_UNKNOWN | BITS_COST_STATE_UNRESTRICTED),

			/// <summary>Transfer standard.</summary>
			BITS_COST_STATE_TRANSFER_STANDARD = (BITS_COST_OPTION_IGNORE_CONGESTION | BITS_COST_STATE_USAGE_BASED | BITS_COST_STATE_OVERCAP_THROTTLED | BITS_COST_STATE_BELOW_CAP | BITS_COST_STATE_CAPPED_USAGE_UNKNOWN | BITS_COST_STATE_UNRESTRICTED),

			/// <summary>Transfer unrestricted.</summary>
			BITS_COST_STATE_TRANSFER_UNRESTRICTED = (BITS_COST_OPTION_IGNORE_CONGESTION | BITS_COST_STATE_OVERCAP_THROTTLED | BITS_COST_STATE_UNRESTRICTED),

			/// <summary>Transfer always.</summary>
			BITS_COST_STATE_TRANSFER_ALWAYS = (BITS_COST_OPTION_IGNORE_CONGESTION | BITS_COST_STATE_ROAMING | BITS_COST_STATE_USAGE_BASED | BITS_COST_STATE_OVERCAP_THROTTLED | BITS_COST_STATE_OVERCAP_CHARGED | BITS_COST_STATE_NEAR_CAP | BITS_COST_STATE_BELOW_CAP | BITS_COST_STATE_CAPPED_USAGE_UNKNOWN | BITS_COST_STATE_UNRESTRICTED),
		}

		/// <summary>Enumerates values that define ID values corresponding to BackgroundCopyFile properties.</summary>
		// typedef enum _BITS_FILE_PROPERTY_ID { BITS_FILE_PROPERTY_ID_HTTP_RESPONSE_HEADERS = 1} BITS_FILE_PROPERTY_ID; https://msdn.microsoft.com/en-us/library/windows/desktop/hh446782(v=vs.85).aspx
		[PInvokeData("Bits5_0.h", MSDNShortId = "hh446782")]
		public enum BITS_FILE_PROPERTY_ID
		{
			/// <summary>The full set of HTTP response headers from the server's last HTTP response packet.</summary>
			BITS_FILE_PROPERTY_ID_HTTP_RESPONSE_HEADERS = 1
		}

		/// <summary>
		/// The <c>BITS_JOB_PROPERTY_ID</c> enumeration specifies the ID of the property for the BITS job. This enumeration is used in the
		/// <c>BITS_JOB_PROPERTY_VALUE</c> union to determine the type of value contained in the union.
		/// </summary>
		// typedef enum { BITS_JOB_PROPERTY_ID_COST_FLAGS = 1, BITS_JOB_PROPERTY_NOTIFICATION_CLSID = 2, BITS_JOB_PROPERTY_DYNAMIC_CONTENT =
		// 3, BITS_JOB_PROPERTY_HIGH_PERFORMANCE = 4, BITS_JOB_PROPERTY_MAX_DOWNLOAD_SIZE = 5, BITS_JOB_PROPERTY_USE_STORED_CREDENTIALS = 7,
		// BITS_JOB_PROPERTY_MINIMUM_NOTIFICATION_INTERVAL_MS = 9, BITS_JOB_PROPERTY_ON_DEMAND_MODE = 10} BITS_JOB_PROPERTY_ID; https://msdn.microsoft.com/en-us/library/windows/desktop/hh446783(v=vs.85).aspx
		[PInvokeData("Bits5_0.h", MSDNShortId = "hh446783")]
		public enum BITS_JOB_PROPERTY_ID
		{
			/// <summary>
			/// <para>
			/// The ID that is used to control transfer behavior over cellular and/or similar networks. This property may be changed while a
			/// transfer is ongoing – the new cost flags will take effect immediately.
			/// </para>
			/// <para>This property uses the <c>BITS_JOB_PROPERTY_VALUE</c>’s <c>Dword</c> field.</para>
			/// </summary>
			BITS_JOB_PROPERTY_ID_COST_FLAGS = 1,

			/// <summary>
			/// <para>
			/// The ID that is used to register a COM callback by CLSID to receive notifications about the progress and completion of a BITS
			/// job. The CLSID must refer to a class associated with a registered out-of-process COM server. It may also be set to
			/// <c>GUID_NULL</c> to clear a previously set notification CLSID.
			/// </para>
			/// <para>This property uses the <c>BITS_JOB_PROPERTY_VALUE</c>’s <c>CLsID</c> field.</para>
			/// </summary>
			BITS_JOB_PROPERTY_NOTIFICATION_CLSID = 2,

			/// <summary>
			/// <para>
			/// The ID for marking a BITS job as being willing to download content which does not support the normal HTTP requirements for
			/// BITS downloads: HEAD requests, the Content-Length header, and the Content-Range header. Downloading this type of content is
			/// opt-in, because BITS cannot pause and resume downloads jobs without that support. If a job with this property enabled is
			/// interrupted for any reason, such as a temporary loss of network connectivity or the system rebooting, BITS will restart the
			/// download from the beginning instead of resuming where it left off. BITS also cannot throttle bandwidth usage for dynamic
			/// downloads; BITS will not perform unthrottled transfers for any job that does not have <c>BG_JOB_PRIORITY_FOREGROUND</c>
			/// assigned, so you should typically set that priority every time you use set a job as allowing dynamic content.
			/// </para>
			/// <para>
			/// This property uses the <c>BITS_JOB_PROPERTY_VALUE</c>’s <c>Enable</c> field. This property is only supported for
			/// <c>BG_JOB_TYPE_DOWNLOAD</c> jobs. It is not supported for downloads that use <c>FILE_RANGES</c>. This property may only be
			/// set prior to the first time <c>Resume</c> is called on a job.
			/// </para>
			/// </summary>
			BITS_JOB_PROPERTY_DYNAMIC_CONTENT = 3,

			/// <summary>
			/// <para>
			/// The ID for marking a BITS job as not requiring strong reliability guarantees. Enabling this property will cause BITS to avoid
			/// persisting information about normal job progress, which BITS normally does periodically. In the event of an unexpected
			/// shutdown, such as a power loss, during a transfer, this will cause BITS to lose progress and restart the job from the
			/// beginning instead of resuming from where it left off as usual. However, it will also reduce the number of disk writes BITS
			/// makes over the course of a job’s lifetime, which can improve performance for smaller jobs.
			/// </para>
			/// <para>
			/// This property also causes BITS to download directly into the destination file, instead of downloading to a temporary file and
			/// moving the temporary file to the final destination once the transfer is complete. This means that BITS will not clean up any
			/// partially downloaded content if a job is cancelled or encounters a fatal error condition; the BITS caller is responsible for
			/// cleaning up the destination file, if it gets created. However, it will also slightly reduce disk overhead.
			/// </para>
			/// <para>
			/// This property is only recommended for scenarios which involve high numbers of small jobs (under 1MB) and which do not require
			/// reliability to power loss or other unexpected shutdown events. The performance savings are not generally significant for
			/// small numbers of jobs or for larger jobs.
			/// </para>
			/// <para>
			/// This property uses the <c>BITS_JOB_PROPERTY_VALUE</c>’s <c>Enable</c> field. This property is only supported for
			/// <c>BG_JOB_TYPE_DOWNLOAD</c> jobs. This property may only be set prior to adding any files to a job.
			/// </para>
			/// </summary>
			BITS_JOB_PROPERTY_HIGH_PERFORMANCE = 4,

			/// <summary>
			/// <para>
			/// The ID for marking the maximum number of bytes a BITS job will be allowed to download in total. This property is intended for
			/// use with <c>BITS_JOB_PROPERTY_DYNAMIC_CONTENT</c>, where you may not be able to determine the size of the file to be
			/// downloaded ahead of time but would like to cap the total possible download size.
			/// </para>
			/// <para>
			/// This property uses the <c>BITS_JOB_PROPERTY_VALUE</c>’s <c>Enable</c> field. This property is only supported for
			/// <c>BG_JOB_TYPE_DOWNLOAD</c> jobs. This property may only be set prior to the first time <c>Resume</c> is called on a job.
			/// </para>
			/// </summary>
			BITS_JOB_PROPERTY_MAX_DOWNLOAD_SIZE = 5,

			/// <summary>
			/// <para>
			/// The ID for marking a BITS job as being willing to include default credentials in requests to proxy servers. Enabling this
			/// property is equivalent to setting a WinHTTP security level of <c>WINHTTP_AUTOLOGON_SECURITY_LEVEL_MEDIUM</c> on the requests
			/// that BITS makes on the user’s behalf. The user BITS retrieves stored credentials from the is the same as the one it makes
			/// network requests on behalf of: BITS will normally use the job owner’s credentials, unless you have explicitly provided a
			/// network helper token, in which case BITS will use the network helper token’s credentials.
			/// </para>
			/// <para>
			/// This property uses the <c>BITS_JOB_PROPERTY_VALUE</c>’s <c>Target</c> field. However, only the <c>BG_AUTH_TARGET_PROXY</c>
			/// target is supported.
			/// </para>
			/// </summary>
			BITS_JOB_PROPERTY_USE_STORED_CREDENTIALS = 7,

			/// <summary>
			/// <para>
			/// The ID that is used to control the timing of BITS JobNotification and <c>FileRangesTransferred</c> notifications. Enabling
			/// this property lets a user be notified at a different rate. This property may be changed while a transfer is ongoing; however,
			/// the new rate may not be applied immediately. The default value is 500 milliseconds.
			/// </para>
			/// <para>This property uses the <c>BITS_JOB_PROPERTY_VALUE</c>’s <c>Dword</c> field.</para>
			/// </summary>
			BITS_JOB_PROPERTY_MINIMUM_NOTIFICATION_INTERVAL_MS = 9,

			/// <summary>
			/// <para>
			/// The ID that is used to control whether a job is in On Demand mode. On Demand jobs allow the app to request particular ranges
			/// for a file download instead of downloading from the start to the end. The default value is <c>FALSE</c>; the job is not
			/// on-demand. Ranges are requested using the <c>IBackgroundCopyFile6::RequestFileRanges</c> method.
			/// </para>
			/// <para>This property uses the <c>BITS_JOB_PROPERTY_VALUE</c>’s <c>Enable</c> field.</para>
			/// <para>
			/// The requirements for a <c>BITS_JOB_PROPERTY_ON_DEMAND_MODE</c> job is that the transfer must be a <c>BG_JOB_TYPE_DOWNLOAD</c>
			/// job. The job must not be <c>DYNAMIC</c> and the server must be an HTTP or HTTPS server and the server requirements for range
			/// support must all be met.
			/// </para>
			/// </summary>
			BITS_JOB_PROPERTY_ON_DEMAND_MODE = 10,
		}

		/// <summary>
		/// Implement the IBackgroundCopyCallback interface to receive notification that a job is complete, has been modified, or is in
		/// error. Clients use this interface instead of polling for the status of the job.
		/// </summary>
		[PInvokeData("Bits.h", MSDNShortId = "aa362867")]
		[ComImport, Guid("97EA99C7-0186-4AD4-8DF9-C5B4E0ED6B22"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IBackgroundCopyCallback
		{
			/// <summary>
			/// BITS calls your implementation of the JobTransferred method when all of the files in the job have been successfully
			/// transferred. For BG_JOB_TYPE_UPLOAD_REPLY jobs, BITS calls the JobTransferred method after the upload file has been
			/// transferred to the server and the reply has been transferred to the client.
			/// </summary>
			/// <param name="pJob">
			/// Contains job-related information, such as the time the job completed, the number of bytes transferred, and the number of
			/// files transferred. Do not release pJob; BITS releases the interface when the method returns.
			/// </param>
			void JobTransferred([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob pJob);

			/// <summary>BITS calls your implementation of the JobError method when the state of the job changes to BG_JOB_STATE_ERROR.</summary>
			/// <param name="pJob">
			/// Contains job-related information, such as the number of bytes and files transferred before the error occurred. It also
			/// contains the methods to resume and cancel the job. Do not release pJob; BITS releases the interface when the JobError method returns.
			/// </param>
			/// <param name="pError">
			/// Contains error information, such as the file being processed at the time the fatal error occurred and a description of the
			/// error. Do not release pError; BITS releases the interface when the JobError method returns.
			/// </param>
			void JobError([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob pJob, [In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyError pError);

			/// <summary>
			/// BITS calls your implementation of the JobModification method when the job has been modified. The service generates this event
			/// when bytes are transferred, files have been added to the job, properties have been modified, or the state of the job has changed.
			/// </summary>
			/// <param name="pJob">
			/// Contains the methods for accessing property, progress, and state information of the job. Do not release pJob; BITS releases
			/// the interface when the JobModification method returns.
			/// </param>
			/// <param name="dwReserved">Reserved for future use.</param>
			void JobModification([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob pJob, [In, Optional] uint dwReserved);
		}

		/// <summary>Clients implement the IBackgroundCopyCallback2 interface to receive notification that a file has completed downloading.</summary>
		/// <seealso cref="Vanara.PInvoke.BITS.IBackgroundCopyCallback"/>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa362870(v=vs.85).aspx
		[PInvokeData("Bits.h", MSDNShortId = "aa362870")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("659CDEAC-489E-11D9-A9CD-000D56965251")]
		public interface IBackgroundCopyCallback2 : IBackgroundCopyCallback
		{
			/// <summary>
			/// BITS calls your implementation of the JobTransferred method when all of the files in the job have been successfully
			/// transferred. For BG_JOB_TYPE_UPLOAD_REPLY jobs, BITS calls the JobTransferred method after the upload file has been
			/// transferred to the server and the reply has been transferred to the client.
			/// </summary>
			/// <param name="pJob">
			/// Contains job-related information, such as the time the job completed, the number of bytes transferred, and the number of
			/// files transferred. Do not release pJob; BITS releases the interface when the method returns.
			/// </param>
			new void JobTransferred([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob pJob);

			/// <summary>BITS calls your implementation of the JobError method when the state of the job changes to BG_JOB_STATE_ERROR.</summary>
			/// <param name="pJob">
			/// Contains job-related information, such as the number of bytes and files transferred before the error occurred. It also
			/// contains the methods to resume and cancel the job. Do not release pJob; BITS releases the interface when the JobError method returns.
			/// </param>
			/// <param name="pError">
			/// Contains error information, such as the file being processed at the time the fatal error occurred and a description of the
			/// error. Do not release pError; BITS releases the interface when the JobError method returns.
			/// </param>
			new void JobError([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob pJob, [In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyError pError);

			/// <summary>
			/// BITS calls your implementation of the JobModification method when the job has been modified. The service generates this event
			/// when bytes are transferred, files have been added to the job, properties have been modified, or the state of the job has changed.
			/// </summary>
			/// <param name="pJob">
			/// Contains the methods for accessing property, progress, and state information of the job. Do not release pJob; BITS releases
			/// the interface when the JobModification method returns.
			/// </param>
			/// <param name="dwReserved">Reserved for future use.</param>
			new void JobModification([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob pJob, [In, Optional] uint dwReserved);

			/// <summary>
			/// BITS calls your implementation of the FileTransferred method when BITS successfully finishes transferring a file.
			/// </summary>
			/// <param name="pJob">
			/// Contains job-related information. Do not release pJob; BITS releases the interface when this method returns.
			/// </param>
			/// <param name="pFile">
			/// Contains file-related information. Do not release pFile; BITS releases the interface when this method returns.
			/// </param>
			void FileTransferred([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob pJob, [In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyFile pFile);
		}

		/// <summary>
		/// Clients implement the IBackgroundCopyCallback3 interface to receive notification that ranges of a file have completed downloading.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.BITS.IBackgroundCopyCallback2"/>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/mt492760(v=vs.85).aspx
		[PInvokeData("Bits.h", MSDNShortId = "mt492760")]
		[ComImport, Guid("98C97BD2-E32B-4AD8-A528-95FD8B16BD42"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IBackgroundCopyCallback3 : IBackgroundCopyCallback2
		{
			/// <summary>
			/// BITS calls your implementation of the JobTransferred method when all of the files in the job have been successfully
			/// transferred. For BG_JOB_TYPE_UPLOAD_REPLY jobs, BITS calls the JobTransferred method after the upload file has been
			/// transferred to the server and the reply has been transferred to the client.
			/// </summary>
			/// <param name="pJob">
			/// Contains job-related information, such as the time the job completed, the number of bytes transferred, and the number of
			/// files transferred. Do not release pJob; BITS releases the interface when the method returns.
			/// </param>
			new void JobTransferred([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob pJob);

			/// <summary>BITS calls your implementation of the JobError method when the state of the job changes to BG_JOB_STATE_ERROR.</summary>
			/// <param name="pJob">
			/// Contains job-related information, such as the number of bytes and files transferred before the error occurred. It also
			/// contains the methods to resume and cancel the job. Do not release pJob; BITS releases the interface when the JobError method returns.
			/// </param>
			/// <param name="pError">
			/// Contains error information, such as the file being processed at the time the fatal error occurred and a description of the
			/// error. Do not release pError; BITS releases the interface when the JobError method returns.
			/// </param>
			new void JobError([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob pJob, [In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyError pError);

			/// <summary>
			/// BITS calls your implementation of the JobModification method when the job has been modified. The service generates this event
			/// when bytes are transferred, files have been added to the job, properties have been modified, or the state of the job has changed.
			/// </summary>
			/// <param name="pJob">
			/// Contains the methods for accessing property, progress, and state information of the job. Do not release pJob; BITS releases
			/// the interface when the JobModification method returns.
			/// </param>
			/// <param name="dwReserved">Reserved for future use.</param>
			new void JobModification([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob pJob, [In, Optional] uint dwReserved);

			/// <summary>
			/// BITS calls your implementation of the FileTransferred method when BITS successfully finishes transferring a file.
			/// </summary>
			/// <param name="pJob">
			/// Contains job-related information. Do not release pJob; BITS releases the interface when this method returns.
			/// </param>
			/// <param name="pFile">
			/// Contains file-related information. Do not release pFile; BITS releases the interface when this method returns.
			/// </param>
			new void FileTransferred([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob pJob, [In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyFile pFile);

			/// <summary>
			/// BITS calls your implementation of the FileRangesTransferred method when one or more file ranges have been downloaded. File
			/// ranges are added to the job using the IBackgroundCopyFile6::RequestFileRanges method.
			/// </summary>
			/// <param name="job">
			/// An IBackgroundCopyJob object that contains the methods for accessing property, progress, and state information of the job. Do
			/// not release pJob; BITS releases the interface when the method returns.
			/// </param>
			/// <param name="file">
			/// An IBackgroundCopyFile object that contains information about the file whose ranges have changed. Do not release pFile; BITS
			/// releases the interface when the method returns.
			/// </param>
			/// <param name="rangeCount">The count of entries in the ranges array.</param>
			/// <param name="ranges">
			/// An array of the files ranges that have transferred since the last call to FileRangesTransferred or the last call to the
			/// IBackgroundCopyFile6::RequestFileRanges method. Do not free ranges; BITS frees the ranges memory when the
			/// FileRangesTransferred method returns.
			/// </param>
			void FileRangesTransferred([In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyJob job, [In, MarshalAs(UnmanagedType.Interface)] IBackgroundCopyFile file, [In] uint rangeCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] BG_FILE_RANGE[] ranges);
		}

		/// <summary>
		/// Use the IBackgroundCopyError interface to determine the cause of an error and if the transfer process can proceed.
		/// <para>
		/// BITS creates an error object only when the state of the job is BG_JOB_STATE_ERROR or BG_JOB_STATE_TRANSIENT_ERROR.BITS does not
		/// create an error object when an IBackgroundCopyXXXX interface method fails.The error object is available until BITS begins
		/// transferring data(the state of the job changes to BG_JOB_STATE_TRANSFERRING) for the job or until your application exits.
		/// </para>
		/// <para>To get an IBackgroundCopyError object, call the IBackgroundCopyJob::GetError method.</para>
		/// </summary>
		[PInvokeData("Bits.h", MSDNShortId = "aa362875")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("19C613A0-FCB8-4F28-81AE-897C3D078F81")]
		public interface IBackgroundCopyError
		{
			/// <summary>Retrieves the error code and identify the context in which the error occurred.</summary>
			/// <param name="pContext">Context in which the error occurred. For a list of context values, see the BG_ERROR_CONTEXT enumeration.</param>
			/// <param name="pCode">Error code of the error that occurred.</param>
			void GetError(out BG_ERROR_CONTEXT pContext, out HRESULT pCode);

			/// <summary>Retrieves an interface pointer to the file object associated with the error.</summary>
			/// <returns>
			/// An IBackgroundCopyFile interface pointer whose methods you use to determine the local and remote file names associated with
			/// the error. The ppFile parameter is set to NULL if the error is not associated with the local or remote file. When done,
			/// release ppFile.
			/// </returns>
			IBackgroundCopyFile GetFile();

			/// <summary>Retrieves the error text associated with the error.</summary>
			/// <param name="LanguageId">
			/// Identifies the locale to use to generate the description. To create the language identifier, use the MAKELANGID macro. For
			/// example, to specify U.S. English, use the following code sample.
			/// <para>MAKELANGID(LANG_ENGLISH, SUBLANG_ENGLISH_US)</para>
			/// <para>To retrieve the system's default user language identifier, use the following calls.</para>
			/// <para>LANGIDFROMLCID(GetThreadLocale())</para>
			/// </param>
			/// <returns>
			/// Null-terminated string that contains the error text associated with the error. Call the CoTaskMemFree function to free
			/// ppErrorDescription when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetErrorDescription([In] uint LanguageId);

			/// <summary>Retrieves the description of the context in which the error occurred.</summary>
			/// <param name="LanguageId">
			/// Identifies the locale to use to generate the description. To create the language identifier, use the MAKELANGID macro. For
			/// example, to specify U.S. English, use the following code sample.
			/// <para>MAKELANGID(LANG_ENGLISH, SUBLANG_ENGLISH_US)</para>
			/// <para>To retrieve the system's default user language identifier, use the following calls.</para>
			/// <para>LANGIDFROMLCID(GetThreadLocale())</para>
			/// </param>
			/// <returns>
			/// Null-terminated string that contains the description of the context in which the error occurred. Call the CoTaskMemFree
			/// function to free ppContextDescription when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetErrorContextDescription([In] uint LanguageId);

			/// <summary>
			/// Retrieves the protocol used to transfer the file. The remote file name identifies the protocol to use to transfer the file.
			/// </summary>
			/// <returns>
			/// Null-terminated string that contains the protocol used to transfer the file. The string contains "http" for the HTTP protocol
			/// and "file" for the SMB protocol. The ppProtocol parameter is set to NULL if the error is not related to the transfer
			/// protocol. Call the CoTaskMemFree function to free ppProtocol when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetProtocol();
		}

		/// <summary>
		/// IBackgroundCopyFile contains information about a file that is part of a job. For example, you can use IBackgroundCopyFile methods
		/// to retrieve the local and remote names of the file and transfer progress information.
		/// <para>
		/// To get an IBackgroundCopyFile interface pointer, call the IBackgroundCopyError::GetFile method or the
		/// IEnumBackgroundCopyFiles::Next method.
		/// </para>
		/// </summary>
		[PInvokeData("Bits.h", MSDNShortId = "aa362881")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("01B7BD23-FB88-4A77-8490-5891D3E4653A")]
		public interface IBackgroundCopyFile
		{
			/// <summary>Retrieves the remote name of the file.</summary>
			/// <returns>
			/// Null-terminated string that contains the remote name of the file to transfer. The name is fully qualified. Call the
			/// CoTaskMemFree function to free ppName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetRemoteName();

			/// <summary>Retrieves the local name of the file.</summary>
			/// <returns>
			/// Null-terminated string that contains the name of the file on the client. The name is fully qualified. Call the CoTaskMemFree
			/// function to free ppName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetLocalName();

			/// <summary>Retrieves information on the progress of the file transfer.</summary>
			/// <returns>
			/// Structure whose members indicate the progress of the file transfer. For details on the type of progress information
			/// available, see the BG_FILE_PROGRESS structure.
			/// </returns>
			BG_FILE_PROGRESS GetProgress();
		}

		/// <summary>
		/// Use the IBackgroundCopyFile2 interface to specify a new remote name for the file and retrieve the list of ranges to download.
		/// <para>The IBackgroundCopyFile2 interface inherits from the IBackgroundCopyFile interface.</para>
		/// <para>
		/// To get an IBackgroundCopyFile2 interface pointer, call the IBackgroundCopyFile::QueryInterface method using
		/// __uuidof(IBackgroundCopyFile2) for the interface identifier. Use the IBackgroundCopyFile2 interface pointer to call both the
		/// IBackgroundCopyFile and IBackgroundCopyFile2 methods.
		/// </para>
		/// </summary>
		[PInvokeData("Bits.h", MSDNShortId = "aa362944")]
		[ComImport, Guid("83E81B93-0873-474D-8A8C-F2018B1A939C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComConversionLoss]
		public interface IBackgroundCopyFile2 : IBackgroundCopyFile
		{
			/// <summary>Retrieves the remote name of the file.</summary>
			/// <returns>
			/// Null-terminated string that contains the remote name of the file to transfer. The name is fully qualified. Call the
			/// CoTaskMemFree function to free ppName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetRemoteName();

			/// <summary>Retrieves the local name of the file.</summary>
			/// <returns>
			/// Null-terminated string that contains the name of the file on the client. The name is fully qualified. Call the CoTaskMemFree
			/// function to free ppName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetLocalName();

			/// <summary>Retrieves information on the progress of the file transfer.</summary>
			/// <returns>
			/// Structure whose members indicate the progress of the file transfer. For details on the type of progress information
			/// available, see the BG_FILE_PROGRESS structure.
			/// </returns>
			new BG_FILE_PROGRESS GetProgress();

			/// <summary>Retrieves the ranges that you want to download from the remote file.</summary>
			/// <param name="rangeCount">Number of elements in Ranges.</param>
			/// <param name="ranges">
			/// Array of BG_FILE_RANGE structures that specify the ranges to download. When done, call the CoTaskMemFree function to free Ranges.
			/// </param>
			void GetFileRanges(out uint rangeCount, out SafeCoTaskMemHandle ranges);

			/// <summary>Changes the remote name to a new URL in a download job.</summary>
			/// <param name="RemoteName">
			/// Null-terminated string that contains the name of the file on the server. For information on specifying the remote name, see
			/// the RemoteName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			void SetRemoteName([MarshalAs(UnmanagedType.LPWStr)] string RemoteName);
		}

		/// <summary>
		/// Use this interface to retrieve the name of the temporary file that contains the downloaded content and to validate the file so
		/// that peers can request its content.
		/// <para>
		/// To get an IBackgroundCopyFile3 interface pointer, call the IBackgroundCopyFile::QueryInterface method using
		/// __uuidof(IBackgroundCopyFile3) for the interface identifier.
		/// </para>
		/// </summary>
		[PInvokeData("Bits.h", MSDNShortId = "aa362952")]
		[ComImport, Guid("659CDEAA-489E-11D9-A9CD-000D56965251"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IBackgroundCopyFile3 : IBackgroundCopyFile2
		{
			/// <summary>Retrieves the remote name of the file.</summary>
			/// <returns>
			/// Null-terminated string that contains the remote name of the file to transfer. The name is fully qualified. Call the
			/// CoTaskMemFree function to free ppName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetRemoteName();

			/// <summary>Retrieves the local name of the file.</summary>
			/// <returns>
			/// Null-terminated string that contains the name of the file on the client. The name is fully qualified. Call the CoTaskMemFree
			/// function to free ppName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetLocalName();

			/// <summary>Retrieves information on the progress of the file transfer.</summary>
			/// <returns>
			/// Structure whose members indicate the progress of the file transfer. For details on the type of progress information
			/// available, see the BG_FILE_PROGRESS structure.
			/// </returns>
			new BG_FILE_PROGRESS GetProgress();

			/// <summary>Retrieves the ranges that you want to download from the remote file.</summary>
			/// <param name="rangeCount">Number of elements in Ranges.</param>
			/// <param name="ranges">
			/// Array of BG_FILE_RANGE structures that specify the ranges to download. When done, call the CoTaskMemFree function to free Ranges.
			/// </param>
			new void GetFileRanges(out uint rangeCount, out SafeCoTaskMemHandle ranges);

			/// <summary>Changes the remote name to a new URL in a download job.</summary>
			/// <param name="RemoteName">
			/// Null-terminated string that contains the name of the file on the server. For information on specifying the remote name, see
			/// the RemoteName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			new void SetRemoteName([MarshalAs(UnmanagedType.LPWStr)] string RemoteName);

			/// <summary>Gets the full path of the temporary file that contains the content of the download.</summary>
			/// <returns>
			/// Null-terminated string that contains the full path of the temporary file. Call the CoTaskMemFree function to free ppFileName
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetTemporaryName();

			/// <summary>Sets the validation state of this file.</summary>
			/// <param name="state">Set to TRUE if the file content is valid, otherwise, FALSE.</param>
			void SetValidationState([MarshalAs(UnmanagedType.Bool)] bool state);

			/// <summary>Gets the current validation state of this file.</summary>
			/// <returns>TRUE if the contents of the file is valid, otherwise, FALSE.</returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			bool GetValidationState();

			/// <summary>Gets a value that determines if any part of the file was downloaded from a peer.</summary>
			/// <returns>Is TRUE if any part of the file was downloaded from a peer; otherwise, FALSE.</returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			bool IsDownloadedFromPeer();
		}

		/// <summary>
		/// Use this interface to retrieve download statistics for peers and origin servers.
		/// <para>
		/// To get an IBackgroundCopyFile4 interface pointer, call the IBackgroundCopyFile::QueryInterface method using
		/// __uuidof(IBackgroundCopyFile4) for the interface identifier.
		/// </para>
		/// </summary>
		[PInvokeData("Bits.h", MSDNShortId = "dd904468")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("EF7E0655-7888-4960-B0E5-730846E03492")]
		public interface IBackgroundCopyFile4 : IBackgroundCopyFile3
		{
			/// <summary>Retrieves the remote name of the file.</summary>
			/// <returns>
			/// Null-terminated string that contains the remote name of the file to transfer. The name is fully qualified. Call the
			/// CoTaskMemFree function to free ppName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetRemoteName();

			/// <summary>Retrieves the local name of the file.</summary>
			/// <returns>
			/// Null-terminated string that contains the name of the file on the client. The name is fully qualified. Call the CoTaskMemFree
			/// function to free ppName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetLocalName();

			/// <summary>Retrieves information on the progress of the file transfer.</summary>
			/// <returns>
			/// Structure whose members indicate the progress of the file transfer. For details on the type of progress information
			/// available, see the BG_FILE_PROGRESS structure.
			/// </returns>
			new BG_FILE_PROGRESS GetProgress();

			/// <summary>Retrieves the ranges that you want to download from the remote file.</summary>
			/// <param name="rangeCount">Number of elements in Ranges.</param>
			/// <param name="ranges">
			/// Array of BG_FILE_RANGE structures that specify the ranges to download. When done, call the CoTaskMemFree function to free Ranges.
			/// </param>
			new void GetFileRanges(out uint rangeCount, out SafeCoTaskMemHandle ranges);

			/// <summary>Changes the remote name to a new URL in a download job.</summary>
			/// <param name="RemoteName">
			/// Null-terminated string that contains the name of the file on the server. For information on specifying the remote name, see
			/// the RemoteName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			new void SetRemoteName([MarshalAs(UnmanagedType.LPWStr)] string RemoteName);

			/// <summary>Gets the full path of the temporary file that contains the content of the download.</summary>
			/// <returns>
			/// Null-terminated string that contains the full path of the temporary file. Call the CoTaskMemFree function to free ppFileName
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetTemporaryName();

			/// <summary>Sets the validation state of this file.</summary>
			/// <param name="state">Set to TRUE if the file content is valid, otherwise, FALSE.</param>
			new void SetValidationState([MarshalAs(UnmanagedType.Bool)] bool state);

			/// <summary>Gets the current validation state of this file.</summary>
			/// <returns>TRUE if the contents of the file is valid, otherwise, FALSE.</returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool GetValidationState();

			/// <summary>Gets a value that determines if any part of the file was downloaded from a peer.</summary>
			/// <returns>Is TRUE if any part of the file was downloaded from a peer; otherwise, FALSE.</returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool IsDownloadedFromPeer();

			/// <summary>Specifies statistics about the amount of data downloaded from peers and origin servers.</summary>
			/// <param name="pFromOrigin">Specifies the amount of file data downloaded from the originating server.</param>
			/// <param name="pFromPeers">Specifies the amount of file data downloaded from a peer-to-peer source.</param>
			void GetPeerDownloadStats(out ulong pFromOrigin, out ulong pFromPeers);
		}

		/// <summary>
		/// Use this interface to get or set generic properties of BITS file transfers.
		/// <para>
		/// To get an IBackgroundCopyFile5 interface pointer, call the IBackgroundCopyFile::QueryInterface method using
		/// __uuidof(IBackgroundCopyFile5) for the interface identifier.
		/// </para>
		/// </summary>
		[PInvokeData("Bits.h", MSDNShortId = "aa362952")]
		[ComImport, Guid("85C1657F-DAFC-40E8-8834-DF18EA25717E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IBackgroundCopyFile5 : IBackgroundCopyFile4
		{
			/// <summary>Retrieves the remote name of the file.</summary>
			/// <returns>
			/// Null-terminated string that contains the remote name of the file to transfer. The name is fully qualified. Call the
			/// CoTaskMemFree function to free ppName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetRemoteName();

			/// <summary>Retrieves the local name of the file.</summary>
			/// <returns>
			/// Null-terminated string that contains the name of the file on the client. The name is fully qualified. Call the CoTaskMemFree
			/// function to free ppName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetLocalName();

			/// <summary>Retrieves information on the progress of the file transfer.</summary>
			/// <returns>
			/// Structure whose members indicate the progress of the file transfer. For details on the type of progress information
			/// available, see the BG_FILE_PROGRESS structure.
			/// </returns>
			new BG_FILE_PROGRESS GetProgress();

			/// <summary>Retrieves the ranges that you want to download from the remote file.</summary>
			/// <param name="rangeCount">Number of elements in Ranges.</param>
			/// <param name="ranges">
			/// Array of BG_FILE_RANGE structures that specify the ranges to download. When done, call the CoTaskMemFree function to free Ranges.
			/// </param>
			new void GetFileRanges(out uint rangeCount, out SafeCoTaskMemHandle ranges);

			/// <summary>Changes the remote name to a new URL in a download job.</summary>
			/// <param name="RemoteName">
			/// Null-terminated string that contains the name of the file on the server. For information on specifying the remote name, see
			/// the RemoteName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			new void SetRemoteName([MarshalAs(UnmanagedType.LPWStr)] string RemoteName);

			/// <summary>Gets the full path of the temporary file that contains the content of the download.</summary>
			/// <returns>
			/// Null-terminated string that contains the full path of the temporary file. Call the CoTaskMemFree function to free ppFileName
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetTemporaryName();

			/// <summary>Sets the validation state of this file.</summary>
			/// <param name="state">Set to TRUE if the file content is valid, otherwise, FALSE.</param>
			new void SetValidationState([MarshalAs(UnmanagedType.Bool)] bool state);

			/// <summary>Gets the current validation state of this file.</summary>
			/// <returns>TRUE if the contents of the file is valid, otherwise, FALSE.</returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool GetValidationState();

			/// <summary>Gets a value that determines if any part of the file was downloaded from a peer.</summary>
			/// <returns>Is TRUE if any part of the file was downloaded from a peer; otherwise, FALSE.</returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool IsDownloadedFromPeer();

			/// <summary>Specifies statistics about the amount of data downloaded from peers and origin servers.</summary>
			/// <param name="pFromOrigin">Specifies the amount of file data downloaded from the originating server.</param>
			/// <param name="pFromPeers">Specifies the amount of file data downloaded from a peer-to-peer source.</param>
			new void GetPeerDownloadStats(out ulong pFromOrigin, out ulong pFromPeers);

			/// <summary>Sets a generic property of a BITS file transfer.</summary>
			/// <param name="PropertyId">Specifies the property to be set.</param>
			/// <param name="PropertyValue">
			/// A pointer to a union that specifies the value to be set. The union member appropriate for the property ID is used.
			/// </param>
			void SetProperty(BITS_FILE_PROPERTY_ID PropertyId, in BITS_FILE_PROPERTY_VALUE PropertyValue);

			/// <summary>Gets a generic property of a BITS file transfer.</summary>
			/// <param name="PropertyId">Specifies the file property whose value is to be retrieved.</param>
			/// <returns>
			/// The property value, returned as a pointer to a BITS_FILE_PROPERTY_VALUE union. Use the union field appropriate for the
			/// property ID value passed in.
			/// </returns>
			BITS_FILE_PROPERTY_VALUE GetProperty(BITS_FILE_PROPERTY_ID PropertyId);
		}

		/// <summary>Use this interface to request file ranges for On Demand download jobs.</summary>
		[PInvokeData("Bits.h", MSDNShortId = "mt492763")]
		[ComImport, ComConversionLoss, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("CF6784F7-D677-49FD-9368-CB47AEE9D1AD")]
		public interface IBackgroundCopyFile6 : IBackgroundCopyFile5
		{
			/// <summary>Retrieves the remote name of the file.</summary>
			/// <returns>
			/// Null-terminated string that contains the remote name of the file to transfer. The name is fully qualified. Call the
			/// CoTaskMemFree function to free ppName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetRemoteName();

			/// <summary>Retrieves the local name of the file.</summary>
			/// <returns>
			/// Null-terminated string that contains the name of the file on the client. The name is fully qualified. Call the CoTaskMemFree
			/// function to free ppName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetLocalName();

			/// <summary>Retrieves information on the progress of the file transfer.</summary>
			/// <returns>
			/// Structure whose members indicate the progress of the file transfer. For details on the type of progress information
			/// available, see the BG_FILE_PROGRESS structure.
			/// </returns>
			new BG_FILE_PROGRESS GetProgress();

			/// <summary>Retrieves the ranges that you want to download from the remote file.</summary>
			/// <param name="rangeCount">Number of elements in Ranges.</param>
			/// <param name="ranges">
			/// Array of BG_FILE_RANGE structures that specify the ranges to download. When done, call the CoTaskMemFree function to free Ranges.
			/// </param>
			new void GetFileRanges(out uint rangeCount, out SafeCoTaskMemHandle ranges);

			/// <summary>Changes the remote name to a new URL in a download job.</summary>
			/// <param name="RemoteName">
			/// Null-terminated string that contains the name of the file on the server. For information on specifying the remote name, see
			/// the RemoteName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			new void SetRemoteName([MarshalAs(UnmanagedType.LPWStr)] string RemoteName);

			/// <summary>Gets the full path of the temporary file that contains the content of the download.</summary>
			/// <returns>
			/// Null-terminated string that contains the full path of the temporary file. Call the CoTaskMemFree function to free ppFileName
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetTemporaryName();

			/// <summary>Sets the validation state of this file.</summary>
			/// <param name="state">Set to TRUE if the file content is valid, otherwise, FALSE.</param>
			new void SetValidationState([MarshalAs(UnmanagedType.Bool)] bool state);

			/// <summary>Gets the current validation state of this file.</summary>
			/// <returns>TRUE if the contents of the file is valid, otherwise, FALSE.</returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool GetValidationState();

			/// <summary>Gets a value that determines if any part of the file was downloaded from a peer.</summary>
			/// <returns>Is TRUE if any part of the file was downloaded from a peer; otherwise, FALSE.</returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool IsDownloadedFromPeer();

			/// <summary>Specifies statistics about the amount of data downloaded from peers and origin servers.</summary>
			/// <param name="pFromOrigin">Specifies the amount of file data downloaded from the originating server.</param>
			/// <param name="pFromPeers">Specifies the amount of file data downloaded from a peer-to-peer source.</param>
			new void GetPeerDownloadStats(out ulong pFromOrigin, out ulong pFromPeers);

			/// <summary>Sets a generic property of a BITS file transfer.</summary>
			/// <param name="PropertyId">Specifies the property to be set.</param>
			/// <param name="PropertyValue">
			/// A pointer to a union that specifies the value to be set. The union member appropriate for the property ID is used.
			/// </param>
			new void SetProperty(BITS_FILE_PROPERTY_ID PropertyId, in BITS_FILE_PROPERTY_VALUE PropertyValue);

			/// <summary>Gets a generic property of a BITS file transfer.</summary>
			/// <param name="PropertyId">Specifies the file property whose value is to be retrieved.</param>
			/// <returns>
			/// The property value, returned as a pointer to a BITS_FILE_PROPERTY_VALUE union. Use the union field appropriate for the
			/// property ID value passed in.
			/// </returns>
			new BITS_FILE_PROPERTY_VALUE GetProperty(BITS_FILE_PROPERTY_ID PropertyId);

			/// <summary>Specifies a position to prioritize downloading missing data from.</summary>
			/// <param name="offset">Specifies the new position to prioritize downloading missing data from.</param>
			void UpdateDownloadPosition([In] ulong offset);

			/// <summary>Adds a new set of file ranges to be prioritized for download.</summary>
			/// <param name="rangeCount">Specifies the size of the Ranges array.</param>
			/// <param name="ranges">
			/// An array of file ranges to be downloaded. Requested ranges are allowed to overlap previously downloaded (or pending) ranges.
			/// Ranges are automatically split into non-overlapping ranges.
			/// </param>
			void RequestFileRanges([In] uint rangeCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] BG_FILE_RANGE[] ranges);

			/// <summary>Returns the set of file ranges that have been downloaded.</summary>
			/// <param name="rangeCount">The number of elements in Ranges.</param>
			/// <param name="ranges">
			/// Array of BG_FILE_RANGE structures that describes the ranges that have been downloaded. Ranges will be merged together as much
			/// as possible. The ranges are ordered by offset. When done, call the CoTaskMemFree function to free Ranges.
			/// </param>
			void GetFilledFileRanges(out uint rangeCount, out SafeCoTaskMemHandle ranges);
		}

		/// <summary>
		/// Use the IBackgroundCopyJob interface to add files to the job, set the priority level of the job, determine the state of the job,
		/// and to start and stop the job.
		/// <para>
		/// To create a job, call the IBackgroundCopyManager::CreateJob method.To get an IBackgroundCopyJob interface pointer to an existing
		/// job, call the IBackgroundCopyManager::GetJob method.
		/// </para>
		/// </summary>
		[PInvokeData("Bits.h", MSDNShortId = "aa362973")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("37668D37-507E-4160-9316-26306D150B12")]
		public interface IBackgroundCopyJob
		{
			/// <summary>Adds multiple files to a job.</summary>
			/// <param name="cFileCount">Number of elements in paFileSet.</param>
			/// <param name="pFileSet">
			/// Array of BG_FILE_INFO structures that identify the local and remote file names of the files to transfer.
			/// <para>
			/// Upload jobs are restricted to a single file.If the array contains more than one element, or the job already contains a file,
			/// the method returns BG_E_TOO_MANY_FILES.
			/// </para>
			/// </param>
			void AddFileSet([In] uint cFileCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] BG_FILE_INFO[] pFileSet);

			/// <summary>Adds a single file to the job.</summary>
			/// <param name="RemoteUrl">
			/// Null-terminated string that contains the name of the file on the server. For information on specifying the remote name, see
			/// the <c>RemoteName</c> member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			/// <param name="LocalName">
			/// Null-terminated string that contains the name of the file on the client. For information on specifying the local name, see
			/// the <c>LocalName</c> member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			/// <remarks>
			/// <para>
			/// To add more than one file at a time to a job, call the IBackgroundCopyJob::AddFileSet method. It is more efficient to call
			/// the <c>AddFileSet</c> method when adding multiple files to a job than to call the <c>AddFile</c> method in a loop. For more
			/// information, see Adding Files to a Job.
			/// </para>
			/// <para>
			/// To add a file to a job from which BITS downloads ranges of data from the file, call the
			/// IBackgroundCopyJob3::AddFileWithRanges method.
			/// </para>
			/// <para>Upload jobs can only contain one file. If you add a second file, the method returns BG_E_TOO_MANY_FILES.</para>
			/// <para>
			/// For downloads, BITS guarantees that the version of a file (based on file size and date, not content) that it transfers will
			/// be consistent; however, it does not guarantee that a set of files will be consistent. For example, if BITS is in the middle
			/// of downloading the second of two files in the job at the time that the files are updated on the server, BITS restarts the
			/// download of the second file; however, the first file is not downloaded again.
			/// </para>
			/// <para>
			/// Note that if you own the file being downloaded from the server, you should create a new URL for each new version of the file.
			/// If you use the same URL for new versions of the file, some proxy servers may serve stale data from their cache because they
			/// do not verify with the original server if the file is stale.
			/// </para>
			/// <para>
			/// For uploads, BITS generates an error if the local file changes while the file is transferring. The error code is
			/// BG_E_FILE_CHANGED and the context is BG_ERROR_CONTEXT_LOCAL_FILE.
			/// </para>
			/// <para>
			/// BITS transfers the files within a job sequentially. If an error occurs while transferring a file, the job moves to an error
			/// state and no more files within the job are processed until the error is resolved.
			/// </para>
			/// <para>
			/// By default, a user can add up to 200 files to a job. This limit does not apply to administrators or service accounts. To
			/// change the default, set the <c>MaxFilesPerJob</c> group policies.
			/// </para>
			/// <para><c>Prior to Windows Vista:</c> There is no limit on the number of files that a user can add to a job.</para>
			/// <para>For scalability concerns, see Best Practices When Using BITS.</para>
			/// <para>Examples</para>
			/// <para>For an example that adds a single file to a job, see Adding Files to a Job.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/bits/nf-bits-ibackgroundcopyjob-addfile
			void AddFile([In, MarshalAs(UnmanagedType.LPWStr)] string RemoteUrl, [In, MarshalAs(UnmanagedType.LPWStr)] string LocalName);

			/// <summary>Retrieves an IEnumBackgroundCopyFiles interface pointer that you use to enumerate the files in a job.</summary>
			/// <returns>
			/// IEnumBackgroundCopyFiles interface pointer that you use to enumerate the files in the job. Release ppEnumFiles when done.
			/// </returns>
			IEnumBackgroundCopyFiles EnumFiles();

			/// <summary>
			/// Suspends a job. New jobs, jobs that are in error, and jobs that have finished transferring files are automatically suspended.
			/// </summary>
			void Suspend();

			/// <summary>Activates a new job or restarts a job that has been suspended.</summary>
			void Resume();

			/// <summary>
			/// Deletes the job from the transfer queue and removes related temporary files from the client (downloads) and server (uploads).
			/// </summary>
			void Cancel();

			/// <summary>Ends the job and saves the transferred files on the client.</summary>
			void Complete();

			/// <summary>Retrieves the identifier used to identify the job in the queue.</summary>
			/// <returns>GUID that identifies the job within the BITS queue.</returns>
			Guid GetId();

			/// <summary>Retrieves the type of transfer being performed, such as a file download or upload.</summary>
			/// <returns>Type of transfer being performed. For a list of transfer types, see the BG_JOB_TYPE enumeration.</returns>
			BG_JOB_TYPE GetType();

			/// <summary>Retrieves job-related progress information, such as the number of bytes and files transferred.</summary>
			/// <returns>
			/// Contains data that you can use to calculate the percentage of the job that is complete. For more information, see BG_JOB_PROGRESS.
			/// </returns>
			BG_JOB_PROGRESS GetProgress();

			/// <summary>Retrieves job-related time stamps, such as the time that the job was created or last modified.</summary>
			/// <returns>Contains job-related time stamps. For available time stamps, see the BG_JOB_TIMES structure.</returns>
			BG_JOB_TIMES GetTimes();

			/// <summary>Retrieves the state of the job.</summary>
			/// <returns>
			/// The state of the job. For example, the state reflects whether the job is in error, transferring data, or suspended. For a
			/// list of job states, see the BG_JOB_STATE enumeration.
			/// </returns>
			BG_JOB_STATE GetState();

			/// <summary>
			/// Retrieves the error interface after an error occurs.
			/// <para>
			/// BITS generates an error object when the state of the job is BG_JOB_STATE_ERROR or BG_JOB_STATE_TRANSIENT_ERROR.The service
			/// does not create an error object when a call to an IBackgroundCopyXXXX interface method fails.The error object is available
			/// until BITS begins transferring data(the state of the job changes to BG_JOB_STATE_TRANSFERRING) for the job or until your
			/// application exits.
			/// </para>
			/// </summary>
			/// <returns>
			/// Error interface that provides the error code, a description of the error, and the context in which the error occurred. This
			/// parameter also identifies the file being transferred at the time the error occurred. Release ppError when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IBackgroundCopyError GetError();

			/// <summary>Retrieves the identity of the job's owner.</summary>
			/// <returns>
			/// Null-terminated string that contains the string version of the SID that identifies the job's owner. Call the CoTaskMemFree
			/// function to free ppOwner when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetOwner();

			/// <summary>Specifies a display name for the job. Typically, you use the display name to identify the job in a user interface.</summary>
			/// <param name="pDisplayName">
			/// Null-terminated string that identifies the job. Must not be NULL. The length of the string is limited to 256 characters, not
			/// including the null terminator.
			/// </param>
			void SetDisplayName([In, MarshalAs(UnmanagedType.LPWStr)] string pDisplayName);

			/// <summary>Retrieves the display name for the job. Typically, you use the display name to identify the job in a user interface.</summary>
			/// <returns>
			/// Null-terminated string that contains the display name that identifies the job. More than one job can have the same display
			/// name. Call the CoTaskMemFree function to free ppDisplayName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetDisplayName();

			/// <summary>Provides a description of the job.</summary>
			/// <param name="pDescription">
			/// Null-terminated string that provides additional information about the job. The length of the string is limited to 1,024
			/// characters, not including the null terminator.
			/// </param>
			void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string pDescription);

			/// <summary>Retrieves the description of the job.</summary>
			/// <returns>
			/// Null-terminated string that contains a short description of the job. Call the CoTaskMemFree function to free ppDescription
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetDescription();

			/// <summary>
			/// Specifies the priority level of your job. The priority level determines when your job is processed relative to other jobs in
			/// the transfer queue.
			/// </summary>
			/// <param name="Priority">
			/// Specifies the priority level of your job relative to other jobs in the transfer queue. The default is BG_JOB_PRIORITY_NORMAL.
			/// For a list of priority levels, see the BG_JOB_PRIORITY enumeration.
			/// </param>
			void SetPriority(BG_JOB_PRIORITY Priority);

			/// <summary>
			/// Retrieves the priority level for the job. The priority level determines when the job is processed relative to other jobs in
			/// the transfer queue.
			/// </summary>
			/// <returns>Priority of the job relative to other jobs in the transfer queue.</returns>
			BG_JOB_PRIORITY GetPriority();

			/// <summary>Specifies the type of event notification you want to receive, such as job transferred events.</summary>
			/// <param name="NotifyFlags">Set one or more of the following flags to identify the events that you want to receive.</param>
			void SetNotifyFlags([In] BG_NOTIFY NotifyFlags);

			/// <summary>Retrieves the event notification flags for the job.</summary>
			/// <returns>Identifies the events that your application receives.</returns>
			BG_NOTIFY GetNotifyFlags();

			/// <summary>
			/// Identifies your implementation of the IBackgroundCopyCallback interface to BITS. Use the IBackgroundCopyCallback interface to
			/// receive notification of job-related events.
			/// </summary>
			/// <param name="pNotifyInterface">
			/// An IBackgroundCopyCallback interface pointer. To remove the current callback interface pointer, set this parameter to NULL.
			/// </param>
			void SetNotifyInterface(IBackgroundCopyCallback pNotifyInterface);

			/// <summary>Retrieves the interface pointer to your implementation of the IBackgroundCopyCallback interface.</summary>
			/// <returns>Interface pointer to your implementation of the IBackgroundCopyCallback interface. When done, release ppNotifyInterface.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetNotifyInterface();

			/// <summary>
			/// Sets the minimum length of time that BITS waits after encountering a transient error condition before trying to transfer the file.
			/// </summary>
			/// <param name="RetryDelay">
			/// Minimum length of time, in seconds, that BITS waits after encountering a transient error before trying to transfer the file.
			/// The default retry delay is 600 seconds (10 minutes). The minimum retry delay that you can specify is 5 seconds. If you
			/// specify a value less than 5 seconds, BITS changes the value to 5 seconds. If the value exceeds the no-progress-timeout value
			/// retrieved from the GetNoProgressTimeout method, BITS will not retry the transfer and moves the job to the BG_JOB_STATE_ERROR state.
			/// </param>
			void SetMinimumRetryDelay([In] uint RetryDelay);

			/// <summary>
			/// Retrieves the minimum length of time that the service waits after encountering a transient error condition before trying to
			/// transfer the file.
			/// </summary>
			/// <returns>
			/// Length of time, in seconds, that the service waits after encountering a transient error before trying to transfer the file.
			/// </returns>
			uint GetMinimumRetryDelay();

			/// <summary>
			/// Sets the length of time that BITS tries to transfer the file after a transient error condition occurs. If there is progress,
			/// the timer is reset.
			/// </summary>
			/// <param name="RetryPeriod">
			/// Length of time, in seconds, that BITS tries to transfer the file after the first transient error occurs. The default retry
			/// period is 1,209,600 seconds (14 days). Set the retry period to 0 to prevent retries and to force the job into the
			/// BG_JOB_STATE_ERROR state for all errors. If the retry period value exceeds the JobInactivityTimeout Group Policy value
			/// (90-day default), BITS cancels the job after the policy value is exceeded.
			/// </param>
			void SetNoProgressTimeout([In] uint RetryPeriod);

			/// <summary>
			/// Retrieves the length of time that the service tries to transfer the file after a transient error condition occurs. If there
			/// is progress, the timer is reset.
			/// </summary>
			/// <returns>Length of time, in seconds, that the service tries to transfer the file after a transient error occurs.</returns>
			uint GetNoProgressTimeout();

			/// <summary>Retrieves the number of times BITS tried to transfer the job and an error occurred.</summary>
			/// <returns>
			/// Number of errors that occurred while BITS tried to transfer the job. The count increases when the job moves from the
			/// BG_JOB_STATE_TRANSFERRING state to the BG_JOB_STATE_TRANSIENT_ERROR or BG_JOB_STATE_ERROR state.
			/// </returns>
			uint GetErrorCount();

			/// <summary>Specifies which proxy to use to transfer files.</summary>
			/// <param name="ProxyUsage">
			/// Specifies whether to use the user's proxy settings, not to use a proxy, or to use application-specified proxy settings. The
			/// default is to use the user's proxy settings, BG_JOB_PROXY_USAGE_PRECONFIG. For a list of proxy options, see the
			/// BG_JOB_PROXY_USAGE enumeration.
			/// </param>
			/// <param name="ProxyList">
			/// Null-terminated string that contains the proxies to use to transfer files. The list is space-delimited. For details on
			/// specifying a proxy, see Remarks.
			/// <para>
			/// This parameter must be NULL if the value of ProxyUsage is BG_JOB_PROXY_USAGE_PRECONFIG, BG_JOB_PROXY_USAGE_NO_PROXY, or BG_JOB_PROXY_USAGE_AUTODETECT.
			/// </para>
			/// <para>The length of the proxy list is limited to 4,000 characters, not including the null terminator.</para>
			/// </param>
			/// <param name="ProxyBypassList">
			/// Null-terminated string that contains an optional list of host names, IP addresses, or both, that can bypass the proxy. The
			/// list is space-delimited. For details on specifying a bypass proxy, see Remarks.
			/// <para>
			/// This parameter must be NULL if the value of ProxyUsage is BG_JOB_PROXY_USAGE_PRECONFIG, BG_JOB_PROXY_USAGE_NO_PROXY, or BG_JOB_PROXY_USAGE_AUTODETECT.
			/// </para>
			/// <para>The length of the proxy list is limited to 4,000 characters, not including the null terminator.</para>
			/// </param>
			void SetProxySettings([In] BG_JOB_PROXY_USAGE ProxyUsage, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyList, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyBypassList);

			/// <summary>Retrieves the proxy information that the job uses to transfer the files.</summary>
			/// <param name="pProxyUsage">
			/// Specifies the proxy settings the job uses to transfer the files. For a list of proxy options, see the BG_JOB_PROXY_USAGE enumeration.
			/// </param>
			/// <param name="pProxyList">
			/// Null-terminated string that contains one or more proxies to use to transfer files. The list is space-delimited. For details
			/// on the format of the string, see the Listing Proxy Servers section of Enabling Internet Functionality. Call the CoTaskMemFree
			/// function to free ppProxyList when done.
			/// </param>
			/// <param name="pProxyBypassList">
			/// Null-terminated string that contains an optional list of host names or IP addresses, or both, that were not routed through
			/// the proxy. The list is space-delimited. For details on the format of the string, see the Listing the Proxy Bypass section of
			/// Enabling Internet Functionality. Call the CoTaskMemFree function to free ppProxyBypassList when done.
			/// </param>
			void GetProxySettings(out BG_JOB_PROXY_USAGE pProxyUsage, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pProxyList, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pProxyBypassList);

			/// <summary>Changes ownership of the job to the current user.</summary>
			void TakeOwnership();
		}

		/// <summary>
		/// <para>
		/// Use the <c>IBackgroundCopyJob2</c> interface to retrieve reply data from an upload-reply job, determine the progress of the reply
		/// data transfer to the client, request command line execution, and provide credentials for proxy and remote server authentication requests.
		/// </para>
		/// <para>The <c>IBackgroundCopyJob2</c> interface inherits from the <c>IBackgroundCopyJob</c> interface.</para>
		/// <para>
		/// To get an <c>IBackgroundCopyJob2</c> interface pointer, call the <c>IBackgroundCopyJob::QueryInterface</c> method using for the
		/// interface identifier. Use the <c>IBackgroundCopyJob2</c> interface pointer to call both the <c>IBackgroundCopyJob</c> and
		/// <c>IBackgroundCopyJob2</c> methods.
		/// </para>
		/// </summary>
		/// <returns></returns>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa362981(v=vs.85).aspx
		[PInvokeData("Bits1_5.h", MSDNShortId = "aa362981")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComConversionLoss, Guid("54B50739-686F-45EB-9DFF-D6A9A0FAA9AF")]
		public interface IBackgroundCopyJob2 : IBackgroundCopyJob
		{
			/// <summary>Adds multiple files to a job.</summary>
			/// <param name="cFileCount">Number of elements in paFileSet.</param>
			/// <param name="pFileSet">
			/// Array of BG_FILE_INFO structures that identify the local and remote file names of the files to transfer.
			/// <para>
			/// Upload jobs are restricted to a single file.If the array contains more than one element, or the job already contains a file,
			/// the method returns BG_E_TOO_MANY_FILES.
			/// </para>
			/// </param>
			new void AddFileSet([In] uint cFileCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] BG_FILE_INFO[] pFileSet);

			/// <summary>Adds a single file to the job.</summary>
			/// <param name="RemoteUrl">
			/// Null-terminated string that contains the name of the file on the server. For information on specifying the remote name, see
			/// the RemoteName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			/// <param name="LocalName">
			/// Null-terminated string that contains the name of the file on the client. For information on specifying the local name, see
			/// the LocalName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			new void AddFile([In, MarshalAs(UnmanagedType.LPWStr)] string RemoteUrl, [In, MarshalAs(UnmanagedType.LPWStr)] string LocalName);

			/// <summary>Retrieves an IEnumBackgroundCopyFiles interface pointer that you use to enumerate the files in a job.</summary>
			/// <returns>
			/// IEnumBackgroundCopyFiles interface pointer that you use to enumerate the files in the job. Release ppEnumFiles when done.
			/// </returns>
			new IEnumBackgroundCopyFiles EnumFiles();

			/// <summary>
			/// Suspends a job. New jobs, jobs that are in error, and jobs that have finished transferring files are automatically suspended.
			/// </summary>
			new void Suspend();

			/// <summary>Activates a new job or restarts a job that has been suspended.</summary>
			new void Resume();

			/// <summary>
			/// Deletes the job from the transfer queue and removes related temporary files from the client (downloads) and server (uploads).
			/// </summary>
			new void Cancel();

			/// <summary>Ends the job and saves the transferred files on the client.</summary>
			new void Complete();

			/// <summary>Retrieves the identifier used to identify the job in the queue.</summary>
			/// <returns>GUID that identifies the job within the BITS queue.</returns>
			new Guid GetId();

			/// <summary>Retrieves the type of transfer being performed, such as a file download or upload.</summary>
			/// <returns>Type of transfer being performed. For a list of transfer types, see the BG_JOB_TYPE enumeration.</returns>
			new BG_JOB_TYPE GetType();

			/// <summary>Retrieves job-related progress information, such as the number of bytes and files transferred.</summary>
			/// <returns>
			/// Contains data that you can use to calculate the percentage of the job that is complete. For more information, see BG_JOB_PROGRESS.
			/// </returns>
			new BG_JOB_PROGRESS GetProgress();

			/// <summary>Retrieves job-related time stamps, such as the time that the job was created or last modified.</summary>
			/// <returns>Contains job-related time stamps. For available time stamps, see the BG_JOB_TIMES structure.</returns>
			new BG_JOB_TIMES GetTimes();

			/// <summary>Retrieves the state of the job.</summary>
			/// <returns>
			/// The state of the job. For example, the state reflects whether the job is in error, transferring data, or suspended. For a
			/// list of job states, see the BG_JOB_STATE enumeration.
			/// </returns>
			new BG_JOB_STATE GetState();

			/// <summary>
			/// Retrieves the error interface after an error occurs.
			/// <para>
			/// BITS generates an error object when the state of the job is BG_JOB_STATE_ERROR or BG_JOB_STATE_TRANSIENT_ERROR.The service
			/// does not create an error object when a call to an IBackgroundCopyXXXX interface method fails.The error object is available
			/// until BITS begins transferring data(the state of the job changes to BG_JOB_STATE_TRANSFERRING) for the job or until your
			/// application exits.
			/// </para>
			/// </summary>
			/// <returns>
			/// Error interface that provides the error code, a description of the error, and the context in which the error occurred. This
			/// parameter also identifies the file being transferred at the time the error occurred. Release ppError when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new IBackgroundCopyError GetError();

			/// <summary>Retrieves the identity of the job's owner.</summary>
			/// <returns>
			/// Null-terminated string that contains the string version of the SID that identifies the job's owner. Call the CoTaskMemFree
			/// function to free ppOwner when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetOwner();

			/// <summary>Specifies a display name for the job. Typically, you use the display name to identify the job in a user interface.</summary>
			/// <param name="pDisplayName">
			/// Null-terminated string that identifies the job. Must not be NULL. The length of the string is limited to 256 characters, not
			/// including the null terminator.
			/// </param>
			new void SetDisplayName([In, MarshalAs(UnmanagedType.LPWStr)] string pDisplayName);

			/// <summary>Retrieves the display name for the job. Typically, you use the display name to identify the job in a user interface.</summary>
			/// <returns>
			/// Null-terminated string that contains the display name that identifies the job. More than one job can have the same display
			/// name. Call the CoTaskMemFree function to free ppDisplayName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetDisplayName();

			/// <summary>Provides a description of the job.</summary>
			/// <param name="pDescription">
			/// Null-terminated string that provides additional information about the job. The length of the string is limited to 1,024
			/// characters, not including the null terminator.
			/// </param>
			new void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string pDescription);

			/// <summary>Retrieves the description of the job.</summary>
			/// <returns>
			/// Null-terminated string that contains a short description of the job. Call the CoTaskMemFree function to free ppDescription
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetDescription();

			/// <summary>
			/// Specifies the priority level of your job. The priority level determines when your job is processed relative to other jobs in
			/// the transfer queue.
			/// </summary>
			/// <param name="Priority">
			/// Specifies the priority level of your job relative to other jobs in the transfer queue. The default is BG_JOB_PRIORITY_NORMAL.
			/// For a list of priority levels, see the BG_JOB_PRIORITY enumeration.
			/// </param>
			new void SetPriority(BG_JOB_PRIORITY Priority);

			/// <summary>
			/// Retrieves the priority level for the job. The priority level determines when the job is processed relative to other jobs in
			/// the transfer queue.
			/// </summary>
			/// <returns>Priority of the job relative to other jobs in the transfer queue.</returns>
			new BG_JOB_PRIORITY GetPriority();

			/// <summary>Specifies the type of event notification you want to receive, such as job transferred events.</summary>
			/// <param name="NotifyFlags">Set one or more of the following flags to identify the events that you want to receive.</param>
			new void SetNotifyFlags([In] BG_NOTIFY NotifyFlags);

			/// <summary>Retrieves the event notification flags for the job.</summary>
			/// <returns>Identifies the events that your application receives.</returns>
			new BG_NOTIFY GetNotifyFlags();

			/// <summary>
			/// Identifies your implementation of the IBackgroundCopyCallback interface to BITS. Use the IBackgroundCopyCallback interface to
			/// receive notification of job-related events.
			/// </summary>
			/// <param name="pNotifyInterface">
			/// An IBackgroundCopyCallback interface pointer. To remove the current callback interface pointer, set this parameter to NULL.
			/// </param>
			new void SetNotifyInterface(IBackgroundCopyCallback pNotifyInterface);

			/// <summary>Retrieves the interface pointer to your implementation of the IBackgroundCopyCallback interface.</summary>
			/// <returns>Interface pointer to your implementation of the IBackgroundCopyCallback interface. When done, release ppNotifyInterface.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetNotifyInterface();

			/// <summary>
			/// Sets the minimum length of time that BITS waits after encountering a transient error condition before trying to transfer the file.
			/// </summary>
			/// <param name="RetryDelay">
			/// Minimum length of time, in seconds, that BITS waits after encountering a transient error before trying to transfer the file.
			/// The default retry delay is 600 seconds (10 minutes). The minimum retry delay that you can specify is 5 seconds. If you
			/// specify a value less than 5 seconds, BITS changes the value to 5 seconds. If the value exceeds the no-progress-timeout value
			/// retrieved from the GetNoProgressTimeout method, BITS will not retry the transfer and moves the job to the BG_JOB_STATE_ERROR state.
			/// </param>
			new void SetMinimumRetryDelay([In] uint RetryDelay);

			/// <summary>
			/// Retrieves the minimum length of time that the service waits after encountering a transient error condition before trying to
			/// transfer the file.
			/// </summary>
			/// <returns>
			/// Length of time, in seconds, that the service waits after encountering a transient error before trying to transfer the file.
			/// </returns>
			new uint GetMinimumRetryDelay();

			/// <summary>
			/// Sets the length of time that BITS tries to transfer the file after a transient error condition occurs. If there is progress,
			/// the timer is reset.
			/// </summary>
			/// <param name="RetryPeriod">
			/// Length of time, in seconds, that BITS tries to transfer the file after the first transient error occurs. The default retry
			/// period is 1,209,600 seconds (14 days). Set the retry period to 0 to prevent retries and to force the job into the
			/// BG_JOB_STATE_ERROR state for all errors. If the retry period value exceeds the JobInactivityTimeout Group Policy value
			/// (90-day default), BITS cancels the job after the policy value is exceeded.
			/// </param>
			new void SetNoProgressTimeout([In] uint RetryPeriod);

			/// <summary>
			/// Retrieves the length of time that the service tries to transfer the file after a transient error condition occurs. If there
			/// is progress, the timer is reset.
			/// </summary>
			/// <returns>Length of time, in seconds, that the service tries to transfer the file after a transient error occurs.</returns>
			new uint GetNoProgressTimeout();

			/// <summary>Retrieves the number of times BITS tried to transfer the job and an error occurred.</summary>
			/// <returns>
			/// Number of errors that occurred while BITS tried to transfer the job. The count increases when the job moves from the
			/// BG_JOB_STATE_TRANSFERRING state to the BG_JOB_STATE_TRANSIENT_ERROR or BG_JOB_STATE_ERROR state.
			/// </returns>
			new uint GetErrorCount();

			/// <summary>Specifies which proxy to use to transfer files.</summary>
			/// <param name="ProxyUsage">
			/// Specifies whether to use the user's proxy settings, not to use a proxy, or to use application-specified proxy settings. The
			/// default is to use the user's proxy settings, BG_JOB_PROXY_USAGE_PRECONFIG. For a list of proxy options, see the
			/// BG_JOB_PROXY_USAGE enumeration.
			/// </param>
			/// <param name="ProxyList">
			/// Null-terminated string that contains the proxies to use to transfer files. The list is space-delimited. For details on
			/// specifying a proxy, see Remarks.
			/// <para>
			/// This parameter must be NULL if the value of ProxyUsage is BG_JOB_PROXY_USAGE_PRECONFIG, BG_JOB_PROXY_USAGE_NO_PROXY, or BG_JOB_PROXY_USAGE_AUTODETECT.
			/// </para>
			/// <para>The length of the proxy list is limited to 4,000 characters, not including the null terminator.</para>
			/// </param>
			/// <param name="ProxyBypassList">
			/// Null-terminated string that contains an optional list of host names, IP addresses, or both, that can bypass the proxy. The
			/// list is space-delimited. For details on specifying a bypass proxy, see Remarks.
			/// <para>
			/// This parameter must be NULL if the value of ProxyUsage is BG_JOB_PROXY_USAGE_PRECONFIG, BG_JOB_PROXY_USAGE_NO_PROXY, or BG_JOB_PROXY_USAGE_AUTODETECT.
			/// </para>
			/// <para>The length of the proxy list is limited to 4,000 characters, not including the null terminator.</para>
			/// </param>
			new void SetProxySettings([In] BG_JOB_PROXY_USAGE ProxyUsage, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyList, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyBypassList);

			/// <summary>Retrieves the proxy information that the job uses to transfer the files.</summary>
			/// <param name="pProxyUsage">
			/// Specifies the proxy settings the job uses to transfer the files. For a list of proxy options, see the BG_JOB_PROXY_USAGE enumeration.
			/// </param>
			/// <param name="pProxyList">
			/// Null-terminated string that contains one or more proxies to use to transfer files. The list is space-delimited. For details
			/// on the format of the string, see the Listing Proxy Servers section of Enabling Internet Functionality. Call the CoTaskMemFree
			/// function to free ppProxyList when done.
			/// </param>
			/// <param name="pProxyBypassList">
			/// Null-terminated string that contains an optional list of host names or IP addresses, or both, that were not routed through
			/// the proxy. The list is space-delimited. For details on the format of the string, see the Listing the Proxy Bypass section of
			/// Enabling Internet Functionality. Call the CoTaskMemFree function to free ppProxyBypassList when done.
			/// </param>
			new void GetProxySettings(out BG_JOB_PROXY_USAGE pProxyUsage, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pProxyList, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pProxyBypassList);

			/// <summary>Changes ownership of the job to the current user.</summary>
			new void TakeOwnership();

			/// <summary>
			/// Specifies a program to execute if the job enters the BG_JOB_STATE_ERROR or BG_JOB_STATE_TRANSFERRED state. BITS executes the
			/// program in the context of the user who called this method.
			/// </summary>
			/// <param name="Program">
			/// Null-terminated string that contains the program to execute. The pProgram parameter is limited to MAX_PATH characters, not
			/// including the null terminator. You should specify a full path to the program; the method will not use the search path to
			/// locate the program.
			/// <para>
			/// To remove command line notification, set pProgram and pParameters to NULL. The method fails if pProgram is NULL and
			/// pParameters is non-NULL.
			/// </para>
			/// </param>
			/// <param name="Parameters">
			/// Null-terminated string that contains the parameters of the program in pProgram. The first parameter must be the program in
			/// pProgram (use quotes if the path uses long file names). The pParameters parameter is limited to 4,000 characters, not
			/// including the null terminator. This parameter can be NULL.
			/// </param>
			void SetNotifyCmdLine([In, MarshalAs(UnmanagedType.LPWStr)] string Program, [In, MarshalAs(UnmanagedType.LPWStr)] string Parameters);

			/// <summary>Retrieves the program to execute when the job enters the error or transferred state.</summary>
			/// <param name="pProgram">
			/// Null-terminated string that contains the program to execute when the job enters the error or transferred state. Call the
			/// CoTaskMemFree function to free pProgram when done.
			/// </param>
			/// <param name="pParameters">
			/// Null-terminated string that contains the arguments of the program in pProgram. Call the CoTaskMemFree function to free
			/// pParameters when done.
			/// </param>
			void GetNotifyCmdLine([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pProgram, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pParameters);

			/// <summary>Retrieves progress information related to the transfer of the reply data from an upload-reply job.</summary>
			/// <returns>
			/// Contains information that you use to calculate the percentage of the reply file transfer that is complete. For more
			/// information, see BG_JOB_REPLY_PROGRESS.
			/// </returns>
			BG_JOB_REPLY_PROGRESS GetReplyProgress();

			/// <summary>
			/// Retrieves an in-memory copy of the reply data from the server application. Call this method only if the job's type is
			/// BG_JOB_TYPE_UPLOAD_REPLY and its state is BG_JOB_STATE_TRANSFERRED.
			/// </summary>
			/// <param name="ppBuffer">
			/// Buffer to contain the reply data. The method sets ppBuffer to NULL if the server application did not return a reply. Call the
			/// CoTaskMemFree function to free ppBuffer when done.
			/// </param>
			/// <param name="pLength">Size, in bytes, of the reply data in ppBuffer.</param>
			void GetReplyData(out SafeCoTaskMemHandle ppBuffer, out ulong pLength);

			/// <summary>
			/// Specifies the name of the file to contain the reply data from the server application. Call this method only if the job's type
			/// is BG_JOB_TYPE_UPLOAD_REPLY.
			/// </summary>
			/// <param name="ReplyFileName">
			/// Null-terminated string that contains the full path to the reply file. BITS generates the file name if ReplyFileNamePathSpec
			/// is NULL or an empty string. You cannot use wildcards in the path or file name, and directories in the path must exist. The
			/// path is limited to MAX_PATH, not including the null terminator. The user must have permissions to write to the directory.
			/// BITS does not support NTFS streams. Instead of using network drives, which are session specific, use UNC paths (for example,
			/// \\server\share\path\file). Do not include the \\? prefix in the path.
			/// </param>
			void SetReplyFileName([In, MarshalAs(UnmanagedType.LPWStr)] string ReplyFileName);

			/// <summary>
			/// Retrieves the name of the file that contains the reply data from the server application. Call this method only if the job
			/// type is BG_JOB_TYPE_UPLOAD_REPLY.
			/// </summary>
			/// <returns>
			/// Null-terminated string that contains the full path to the reply file. Call the CoTaskMemFree function to free pReplyFileName
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetReplyFileName();

			/// <summary>Specifies the credentials to use for a proxy or remote server user authentication request.</summary>
			/// <param name="Credentials">
			/// Identifies the target (proxy or server), authentication scheme, and the user's credentials to use for user authentication.
			/// For details, see the BG_AUTH_CREDENTIALS structure.
			/// </param>
			void SetCredentials(ref BG_AUTH_CREDENTIALS Credentials);

			/// <summary>
			/// Removes credentials from use. The credentials must match an existing target and scheme pair that you specified using the
			/// IBackgroundCopyJob2::SetCredentials method. There is no method to retrieve the credentials you have set.
			/// </summary>
			/// <param name="Target">Identifies whether to use the credentials for proxy or server authentication.</param>
			/// <param name="Scheme">
			/// Identifies the authentication scheme to use (basic or one of several challenge-response schemes). For details, see the
			/// BG_AUTH_SCHEME enumeration.
			/// </param>
			void RemoveCredentials(BG_AUTH_TARGET Target, BG_AUTH_SCHEME Scheme);
		}

		/// <summary>
		/// <para>Use the <c>IBackgroundCopyJob3</c> interface to download ranges of a file and change the prefix of a remote file name.</para>
		/// <para>The <c>IBackgroundCopyJob3</c> interface inherits from the <c>IBackgroundCopyJob2</c> interface.</para>
		/// <para>
		/// To get an <c>IBackgroundCopyJob3</c> interface pointer, call the <c>IBackgroundCopyJob::QueryInterface</c> method using for the
		/// interface identifier.
		/// </para>
		/// <para>
		/// Use the <c>IBackgroundCopyJob3</c> interface pointer to call the methods of the <c>IBackgroundCopyJob</c>,
		/// <c>IBackgroundCopyJob2</c>, and <c>IBackgroundCopyJob3</c> interfaces.
		/// </para>
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa362990(v=vs.85).aspx
		[PInvokeData("Bits2_0.h", MSDNShortId = "aa362990", MinClient = PInvokeClient.WindowsXP_SP2)]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("443C8934-90FF-48ED-BCDE-26F5C7450042")]
		public interface IBackgroundCopyJob3 : IBackgroundCopyJob2
		{
			/// <summary>Adds multiple files to a job.</summary>
			/// <param name="cFileCount">Number of elements in paFileSet.</param>
			/// <param name="pFileSet">
			/// Array of BG_FILE_INFO structures that identify the local and remote file names of the files to transfer.
			/// <para>
			/// Upload jobs are restricted to a single file.If the array contains more than one element, or the job already contains a file,
			/// the method returns BG_E_TOO_MANY_FILES.
			/// </para>
			/// </param>
			new void AddFileSet([In] uint cFileCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] BG_FILE_INFO[] pFileSet);

			/// <summary>Adds a single file to the job.</summary>
			/// <param name="RemoteUrl">
			/// Null-terminated string that contains the name of the file on the server. For information on specifying the remote name, see
			/// the RemoteName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			/// <param name="LocalName">
			/// Null-terminated string that contains the name of the file on the client. For information on specifying the local name, see
			/// the LocalName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			new void AddFile([In, MarshalAs(UnmanagedType.LPWStr)] string RemoteUrl, [In, MarshalAs(UnmanagedType.LPWStr)] string LocalName);

			/// <summary>Retrieves an IEnumBackgroundCopyFiles interface pointer that you use to enumerate the files in a job.</summary>
			/// <returns>
			/// IEnumBackgroundCopyFiles interface pointer that you use to enumerate the files in the job. Release ppEnumFiles when done.
			/// </returns>
			new IEnumBackgroundCopyFiles EnumFiles();

			/// <summary>
			/// Suspends a job. New jobs, jobs that are in error, and jobs that have finished transferring files are automatically suspended.
			/// </summary>
			new void Suspend();

			/// <summary>Activates a new job or restarts a job that has been suspended.</summary>
			new void Resume();

			/// <summary>
			/// Deletes the job from the transfer queue and removes related temporary files from the client (downloads) and server (uploads).
			/// </summary>
			new void Cancel();

			/// <summary>Ends the job and saves the transferred files on the client.</summary>
			new void Complete();

			/// <summary>Retrieves the identifier used to identify the job in the queue.</summary>
			/// <returns>GUID that identifies the job within the BITS queue.</returns>
			new Guid GetId();

			/// <summary>Retrieves the type of transfer being performed, such as a file download or upload.</summary>
			/// <returns>Type of transfer being performed. For a list of transfer types, see the BG_JOB_TYPE enumeration.</returns>
			new BG_JOB_TYPE GetType();

			/// <summary>Retrieves job-related progress information, such as the number of bytes and files transferred.</summary>
			/// <returns>
			/// Contains data that you can use to calculate the percentage of the job that is complete. For more information, see BG_JOB_PROGRESS.
			/// </returns>
			new BG_JOB_PROGRESS GetProgress();

			/// <summary>Retrieves job-related time stamps, such as the time that the job was created or last modified.</summary>
			/// <returns>Contains job-related time stamps. For available time stamps, see the BG_JOB_TIMES structure.</returns>
			new BG_JOB_TIMES GetTimes();

			/// <summary>Retrieves the state of the job.</summary>
			/// <returns>
			/// The state of the job. For example, the state reflects whether the job is in error, transferring data, or suspended. For a
			/// list of job states, see the BG_JOB_STATE enumeration.
			/// </returns>
			new BG_JOB_STATE GetState();

			/// <summary>
			/// Retrieves the error interface after an error occurs.
			/// <para>
			/// BITS generates an error object when the state of the job is BG_JOB_STATE_ERROR or BG_JOB_STATE_TRANSIENT_ERROR.The service
			/// does not create an error object when a call to an IBackgroundCopyXXXX interface method fails.The error object is available
			/// until BITS begins transferring data(the state of the job changes to BG_JOB_STATE_TRANSFERRING) for the job or until your
			/// application exits.
			/// </para>
			/// </summary>
			/// <returns>
			/// Error interface that provides the error code, a description of the error, and the context in which the error occurred. This
			/// parameter also identifies the file being transferred at the time the error occurred. Release ppError when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new IBackgroundCopyError GetError();

			/// <summary>Retrieves the identity of the job's owner.</summary>
			/// <returns>
			/// Null-terminated string that contains the string version of the SID that identifies the job's owner. Call the CoTaskMemFree
			/// function to free ppOwner when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetOwner();

			/// <summary>Specifies a display name for the job. Typically, you use the display name to identify the job in a user interface.</summary>
			/// <param name="pDisplayName">
			/// Null-terminated string that identifies the job. Must not be NULL. The length of the string is limited to 256 characters, not
			/// including the null terminator.
			/// </param>
			new void SetDisplayName([In, MarshalAs(UnmanagedType.LPWStr)] string pDisplayName);

			/// <summary>Retrieves the display name for the job. Typically, you use the display name to identify the job in a user interface.</summary>
			/// <returns>
			/// Null-terminated string that contains the display name that identifies the job. More than one job can have the same display
			/// name. Call the CoTaskMemFree function to free ppDisplayName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetDisplayName();

			/// <summary>Provides a description of the job.</summary>
			/// <param name="pDescription">
			/// Null-terminated string that provides additional information about the job. The length of the string is limited to 1,024
			/// characters, not including the null terminator.
			/// </param>
			new void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string pDescription);

			/// <summary>Retrieves the description of the job.</summary>
			/// <returns>
			/// Null-terminated string that contains a short description of the job. Call the CoTaskMemFree function to free ppDescription
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetDescription();

			/// <summary>
			/// Specifies the priority level of your job. The priority level determines when your job is processed relative to other jobs in
			/// the transfer queue.
			/// </summary>
			/// <param name="Priority">
			/// Specifies the priority level of your job relative to other jobs in the transfer queue. The default is BG_JOB_PRIORITY_NORMAL.
			/// For a list of priority levels, see the BG_JOB_PRIORITY enumeration.
			/// </param>
			new void SetPriority(BG_JOB_PRIORITY Priority);

			/// <summary>
			/// Retrieves the priority level for the job. The priority level determines when the job is processed relative to other jobs in
			/// the transfer queue.
			/// </summary>
			/// <returns>Priority of the job relative to other jobs in the transfer queue.</returns>
			new BG_JOB_PRIORITY GetPriority();

			/// <summary>Specifies the type of event notification you want to receive, such as job transferred events.</summary>
			/// <param name="NotifyFlags">Set one or more of the following flags to identify the events that you want to receive.</param>
			new void SetNotifyFlags([In] BG_NOTIFY NotifyFlags);

			/// <summary>Retrieves the event notification flags for the job.</summary>
			/// <returns>Identifies the events that your application receives.</returns>
			new BG_NOTIFY GetNotifyFlags();

			/// <summary>
			/// Identifies your implementation of the IBackgroundCopyCallback interface to BITS. Use the IBackgroundCopyCallback interface to
			/// receive notification of job-related events.
			/// </summary>
			/// <param name="pNotifyInterface">
			/// An IBackgroundCopyCallback interface pointer. To remove the current callback interface pointer, set this parameter to NULL.
			/// </param>
			new void SetNotifyInterface(IBackgroundCopyCallback pNotifyInterface);

			/// <summary>Retrieves the interface pointer to your implementation of the IBackgroundCopyCallback interface.</summary>
			/// <returns>Interface pointer to your implementation of the IBackgroundCopyCallback interface. When done, release ppNotifyInterface.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetNotifyInterface();

			/// <summary>
			/// Sets the minimum length of time that BITS waits after encountering a transient error condition before trying to transfer the file.
			/// </summary>
			/// <param name="RetryDelay">
			/// Minimum length of time, in seconds, that BITS waits after encountering a transient error before trying to transfer the file.
			/// The default retry delay is 600 seconds (10 minutes). The minimum retry delay that you can specify is 5 seconds. If you
			/// specify a value less than 5 seconds, BITS changes the value to 5 seconds. If the value exceeds the no-progress-timeout value
			/// retrieved from the GetNoProgressTimeout method, BITS will not retry the transfer and moves the job to the BG_JOB_STATE_ERROR state.
			/// </param>
			new void SetMinimumRetryDelay([In] uint RetryDelay);

			/// <summary>
			/// Retrieves the minimum length of time that the service waits after encountering a transient error condition before trying to
			/// transfer the file.
			/// </summary>
			/// <returns>
			/// Length of time, in seconds, that the service waits after encountering a transient error before trying to transfer the file.
			/// </returns>
			new uint GetMinimumRetryDelay();

			/// <summary>
			/// Sets the length of time that BITS tries to transfer the file after a transient error condition occurs. If there is progress,
			/// the timer is reset.
			/// </summary>
			/// <param name="RetryPeriod">
			/// Length of time, in seconds, that BITS tries to transfer the file after the first transient error occurs. The default retry
			/// period is 1,209,600 seconds (14 days). Set the retry period to 0 to prevent retries and to force the job into the
			/// BG_JOB_STATE_ERROR state for all errors. If the retry period value exceeds the JobInactivityTimeout Group Policy value
			/// (90-day default), BITS cancels the job after the policy value is exceeded.
			/// </param>
			new void SetNoProgressTimeout([In] uint RetryPeriod);

			/// <summary>
			/// Retrieves the length of time that the service tries to transfer the file after a transient error condition occurs. If there
			/// is progress, the timer is reset.
			/// </summary>
			/// <returns>Length of time, in seconds, that the service tries to transfer the file after a transient error occurs.</returns>
			new uint GetNoProgressTimeout();

			/// <summary>Retrieves the number of times BITS tried to transfer the job and an error occurred.</summary>
			/// <returns>
			/// Number of errors that occurred while BITS tried to transfer the job. The count increases when the job moves from the
			/// BG_JOB_STATE_TRANSFERRING state to the BG_JOB_STATE_TRANSIENT_ERROR or BG_JOB_STATE_ERROR state.
			/// </returns>
			new uint GetErrorCount();

			/// <summary>Specifies which proxy to use to transfer files.</summary>
			/// <param name="ProxyUsage">
			/// Specifies whether to use the user's proxy settings, not to use a proxy, or to use application-specified proxy settings. The
			/// default is to use the user's proxy settings, BG_JOB_PROXY_USAGE_PRECONFIG. For a list of proxy options, see the
			/// BG_JOB_PROXY_USAGE enumeration.
			/// </param>
			/// <param name="ProxyList">
			/// Null-terminated string that contains the proxies to use to transfer files. The list is space-delimited. For details on
			/// specifying a proxy, see Remarks.
			/// <para>
			/// This parameter must be NULL if the value of ProxyUsage is BG_JOB_PROXY_USAGE_PRECONFIG, BG_JOB_PROXY_USAGE_NO_PROXY, or BG_JOB_PROXY_USAGE_AUTODETECT.
			/// </para>
			/// <para>The length of the proxy list is limited to 4,000 characters, not including the null terminator.</para>
			/// </param>
			/// <param name="ProxyBypassList">
			/// Null-terminated string that contains an optional list of host names, IP addresses, or both, that can bypass the proxy. The
			/// list is space-delimited. For details on specifying a bypass proxy, see Remarks.
			/// <para>
			/// This parameter must be NULL if the value of ProxyUsage is BG_JOB_PROXY_USAGE_PRECONFIG, BG_JOB_PROXY_USAGE_NO_PROXY, or BG_JOB_PROXY_USAGE_AUTODETECT.
			/// </para>
			/// <para>The length of the proxy list is limited to 4,000 characters, not including the null terminator.</para>
			/// </param>
			new void SetProxySettings([In] BG_JOB_PROXY_USAGE ProxyUsage, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyList, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyBypassList);

			/// <summary>Retrieves the proxy information that the job uses to transfer the files.</summary>
			/// <param name="pProxyUsage">
			/// Specifies the proxy settings the job uses to transfer the files. For a list of proxy options, see the BG_JOB_PROXY_USAGE enumeration.
			/// </param>
			/// <param name="pProxyList">
			/// Null-terminated string that contains one or more proxies to use to transfer files. The list is space-delimited. For details
			/// on the format of the string, see the Listing Proxy Servers section of Enabling Internet Functionality. Call the CoTaskMemFree
			/// function to free ppProxyList when done.
			/// </param>
			/// <param name="pProxyBypassList">
			/// Null-terminated string that contains an optional list of host names or IP addresses, or both, that were not routed through
			/// the proxy. The list is space-delimited. For details on the format of the string, see the Listing the Proxy Bypass section of
			/// Enabling Internet Functionality. Call the CoTaskMemFree function to free ppProxyBypassList when done.
			/// </param>
			new void GetProxySettings(out BG_JOB_PROXY_USAGE pProxyUsage, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pProxyList, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pProxyBypassList);

			/// <summary>Changes ownership of the job to the current user.</summary>
			new void TakeOwnership();

			/// <summary>
			/// Specifies a program to execute if the job enters the BG_JOB_STATE_ERROR or BG_JOB_STATE_TRANSFERRED state. BITS executes the
			/// program in the context of the user who called this method.
			/// </summary>
			/// <param name="Program">
			/// Null-terminated string that contains the program to execute. The pProgram parameter is limited to MAX_PATH characters, not
			/// including the null terminator. You should specify a full path to the program; the method will not use the search path to
			/// locate the program.
			/// <para>
			/// To remove command line notification, set pProgram and pParameters to NULL. The method fails if pProgram is NULL and
			/// pParameters is non-NULL.
			/// </para>
			/// </param>
			/// <param name="Parameters">
			/// Null-terminated string that contains the parameters of the program in pProgram. The first parameter must be the program in
			/// pProgram (use quotes if the path uses long file names). The pParameters parameter is limited to 4,000 characters, not
			/// including the null terminator. This parameter can be NULL.
			/// </param>
			new void SetNotifyCmdLine([In, MarshalAs(UnmanagedType.LPWStr)] string Program, [In, MarshalAs(UnmanagedType.LPWStr)] string Parameters);

			/// <summary>Retrieves the program to execute when the job enters the error or transferred state.</summary>
			/// <param name="pProgram">
			/// Null-terminated string that contains the program to execute when the job enters the error or transferred state. Call the
			/// CoTaskMemFree function to free pProgram when done.
			/// </param>
			/// <param name="pParameters">
			/// Null-terminated string that contains the arguments of the program in pProgram. Call the CoTaskMemFree function to free
			/// pParameters when done.
			/// </param>
			new void GetNotifyCmdLine([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pProgram, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pParameters);

			/// <summary>Retrieves progress information related to the transfer of the reply data from an upload-reply job.</summary>
			/// <returns>
			/// Contains information that you use to calculate the percentage of the reply file transfer that is complete. For more
			/// information, see BG_JOB_REPLY_PROGRESS.
			/// </returns>
			new BG_JOB_REPLY_PROGRESS GetReplyProgress();

			/// <summary>
			/// Retrieves an in-memory copy of the reply data from the server application. Call this method only if the job's type is
			/// BG_JOB_TYPE_UPLOAD_REPLY and its state is BG_JOB_STATE_TRANSFERRED.
			/// </summary>
			/// <param name="ppBuffer">
			/// Buffer to contain the reply data. The method sets ppBuffer to NULL if the server application did not return a reply. Call the
			/// CoTaskMemFree function to free ppBuffer when done.
			/// </param>
			/// <param name="pLength">Size, in bytes, of the reply data in ppBuffer.</param>
			new void GetReplyData(out SafeCoTaskMemHandle ppBuffer, out ulong pLength);

			/// <summary>
			/// Specifies the name of the file to contain the reply data from the server application. Call this method only if the job's type
			/// is BG_JOB_TYPE_UPLOAD_REPLY.
			/// </summary>
			/// <param name="ReplyFileName">
			/// Null-terminated string that contains the full path to the reply file. BITS generates the file name if ReplyFileNamePathSpec
			/// is NULL or an empty string. You cannot use wildcards in the path or file name, and directories in the path must exist. The
			/// path is limited to MAX_PATH, not including the null terminator. The user must have permissions to write to the directory.
			/// BITS does not support NTFS streams. Instead of using network drives, which are session specific, use UNC paths (for example,
			/// \\server\share\path\file). Do not include the \\? prefix in the path.
			/// </param>
			new void SetReplyFileName([In, MarshalAs(UnmanagedType.LPWStr)] string ReplyFileName);

			/// <summary>
			/// Retrieves the name of the file that contains the reply data from the server application. Call this method only if the job
			/// type is BG_JOB_TYPE_UPLOAD_REPLY.
			/// </summary>
			/// <returns>
			/// Null-terminated string that contains the full path to the reply file. Call the CoTaskMemFree function to free pReplyFileName
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetReplyFileName();

			/// <summary>Specifies the credentials to use for a proxy or remote server user authentication request.</summary>
			/// <param name="Credentials">
			/// Identifies the target (proxy or server), authentication scheme, and the user's credentials to use for user authentication.
			/// For details, see the BG_AUTH_CREDENTIALS structure.
			/// </param>
			new void SetCredentials(ref BG_AUTH_CREDENTIALS Credentials);

			/// <summary>
			/// Removes credentials from use. The credentials must match an existing target and scheme pair that you specified using the
			/// IBackgroundCopyJob2::SetCredentials method. There is no method to retrieve the credentials you have set.
			/// </summary>
			/// <param name="Target">Identifies whether to use the credentials for proxy or server authentication.</param>
			/// <param name="Scheme">
			/// Identifies the authentication scheme to use (basic or one of several challenge-response schemes). For details, see the
			/// BG_AUTH_SCHEME enumeration.
			/// </param>
			new void RemoveCredentials(BG_AUTH_TARGET Target, BG_AUTH_SCHEME Scheme);

			/// <summary>Replaces the beginning text of all remote names in the download job with the specified string.</summary>
			/// <param name="OldPrefix">
			/// Null-terminated string that identifies the text to replace in the remote name. The text must start at the beginning of the
			/// remote name.
			/// </param>
			/// <param name="NewPrefix">Null-terminated string that contains the replacement text.</param>
			void ReplaceRemotePrefix([In, MarshalAs(UnmanagedType.LPWStr)] string OldPrefix, [In, MarshalAs(UnmanagedType.LPWStr)] string NewPrefix);

			/// <summary>Adds a file to a download job and specifies the ranges of the file you want to download.</summary>
			/// <param name="RemoteUrl">
			/// Null-terminated string that contains the name of the file on the server. For information on specifying the remote name, see
			/// the RemoteName member and Remarks section of the BG_FILE_INFO structure. Starting with BITS 3.0, the SMB protocol is not
			/// supported for ranges.
			/// <para>BITS 2.5 and 2.0: BITS supports the SMB protocol for ranges.</para>
			/// </param>
			/// <param name="LocalName">
			/// Null-terminated string that contains the name of the file on the client. For information on specifying the local name, see
			/// the LocalName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			/// <param name="rangeCount">Number of elements in Ranges.</param>
			/// <param name="ranges">
			/// Array of one or more BG_FILE_RANGE structures that specify the ranges to download. Do not specify duplicate or overlapping ranges.
			/// </param>
			void AddFileWithRanges([In, MarshalAs(UnmanagedType.LPWStr)] string RemoteUrl, [In, MarshalAs(UnmanagedType.LPWStr)] string LocalName, [In] uint rangeCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] BG_FILE_RANGE[] ranges);

			/// <summary>Specifies the owner and ACL information to maintain when using SMB to download or upload a file.</summary>
			/// <param name="Flags">
			/// Flags that identify the owner and ACL information to maintain when transferring a file using SMB. Subsequent calls to this
			/// method overwrite the previous flags. Specify 0 to remove the flags from the job. You can specify any combination of the
			/// following flags.
			/// </param>
			void SetFileACLFlags([In] BG_COPY_FILE Flags);

			/// <summary>Retrieves the flags that identify the owner and ACL information to maintain when transferring a file using SMB.</summary>
			/// <returns>
			/// Flags that identify the owner and ACL information to maintain when transferring a file using SMB. Flags can contain any
			/// combination of the following flags. If no flags are set, Flags is zero.
			/// </returns>
			BG_COPY_FILE GetFileACLFlags();
		}

		/// <summary>
		/// <para>Use this interface to enable peer caching, restrict download time, and inspect user token characteristics.</para>
		/// <para>To get this interface, call the <c>IBackgroundCopyJob::QueryInterface</c> method using as the interface identifier.</para>
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa362995(v=vs.85).aspx
		[PInvokeData("Bits2_5.h", MSDNShortId = "aa362995", MinClient = PInvokeClient.WindowsVista)]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("659CDEAE-489E-11D9-A9CD-000D56965251")]
		public interface IBackgroundCopyJob4 : IBackgroundCopyJob3
		{
			/// <summary>Adds multiple files to a job.</summary>
			/// <param name="cFileCount">Number of elements in paFileSet.</param>
			/// <param name="pFileSet">
			/// Array of BG_FILE_INFO structures that identify the local and remote file names of the files to transfer.
			/// <para>
			/// Upload jobs are restricted to a single file.If the array contains more than one element, or the job already contains a file,
			/// the method returns BG_E_TOO_MANY_FILES.
			/// </para>
			/// </param>
			new void AddFileSet([In] uint cFileCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] BG_FILE_INFO[] pFileSet);

			/// <summary>Adds a single file to the job.</summary>
			/// <param name="RemoteUrl">
			/// Null-terminated string that contains the name of the file on the server. For information on specifying the remote name, see
			/// the RemoteName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			/// <param name="LocalName">
			/// Null-terminated string that contains the name of the file on the client. For information on specifying the local name, see
			/// the LocalName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			new void AddFile([In, MarshalAs(UnmanagedType.LPWStr)] string RemoteUrl, [In, MarshalAs(UnmanagedType.LPWStr)] string LocalName);

			/// <summary>Retrieves an IEnumBackgroundCopyFiles interface pointer that you use to enumerate the files in a job.</summary>
			/// <returns>
			/// IEnumBackgroundCopyFiles interface pointer that you use to enumerate the files in the job. Release ppEnumFiles when done.
			/// </returns>
			new IEnumBackgroundCopyFiles EnumFiles();

			/// <summary>
			/// Suspends a job. New jobs, jobs that are in error, and jobs that have finished transferring files are automatically suspended.
			/// </summary>
			new void Suspend();

			/// <summary>Activates a new job or restarts a job that has been suspended.</summary>
			new void Resume();

			/// <summary>
			/// Deletes the job from the transfer queue and removes related temporary files from the client (downloads) and server (uploads).
			/// </summary>
			new void Cancel();

			/// <summary>Ends the job and saves the transferred files on the client.</summary>
			new void Complete();

			/// <summary>Retrieves the identifier used to identify the job in the queue.</summary>
			/// <returns>GUID that identifies the job within the BITS queue.</returns>
			new Guid GetId();

			/// <summary>Retrieves the type of transfer being performed, such as a file download or upload.</summary>
			/// <returns>Type of transfer being performed. For a list of transfer types, see the BG_JOB_TYPE enumeration.</returns>
			new BG_JOB_TYPE GetType();

			/// <summary>Retrieves job-related progress information, such as the number of bytes and files transferred.</summary>
			/// <returns>
			/// Contains data that you can use to calculate the percentage of the job that is complete. For more information, see BG_JOB_PROGRESS.
			/// </returns>
			new BG_JOB_PROGRESS GetProgress();

			/// <summary>Retrieves job-related time stamps, such as the time that the job was created or last modified.</summary>
			/// <returns>Contains job-related time stamps. For available time stamps, see the BG_JOB_TIMES structure.</returns>
			new BG_JOB_TIMES GetTimes();

			/// <summary>Retrieves the state of the job.</summary>
			/// <returns>
			/// The state of the job. For example, the state reflects whether the job is in error, transferring data, or suspended. For a
			/// list of job states, see the BG_JOB_STATE enumeration.
			/// </returns>
			new BG_JOB_STATE GetState();

			/// <summary>
			/// Retrieves the error interface after an error occurs.
			/// <para>
			/// BITS generates an error object when the state of the job is BG_JOB_STATE_ERROR or BG_JOB_STATE_TRANSIENT_ERROR.The service
			/// does not create an error object when a call to an IBackgroundCopyXXXX interface method fails.The error object is available
			/// until BITS begins transferring data(the state of the job changes to BG_JOB_STATE_TRANSFERRING) for the job or until your
			/// application exits.
			/// </para>
			/// </summary>
			/// <returns>
			/// Error interface that provides the error code, a description of the error, and the context in which the error occurred. This
			/// parameter also identifies the file being transferred at the time the error occurred. Release ppError when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new IBackgroundCopyError GetError();

			/// <summary>Retrieves the identity of the job's owner.</summary>
			/// <returns>
			/// Null-terminated string that contains the string version of the SID that identifies the job's owner. Call the CoTaskMemFree
			/// function to free ppOwner when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetOwner();

			/// <summary>Specifies a display name for the job. Typically, you use the display name to identify the job in a user interface.</summary>
			/// <param name="pDisplayName">
			/// Null-terminated string that identifies the job. Must not be NULL. The length of the string is limited to 256 characters, not
			/// including the null terminator.
			/// </param>
			new void SetDisplayName([In, MarshalAs(UnmanagedType.LPWStr)] string pDisplayName);

			/// <summary>Retrieves the display name for the job. Typically, you use the display name to identify the job in a user interface.</summary>
			/// <returns>
			/// Null-terminated string that contains the display name that identifies the job. More than one job can have the same display
			/// name. Call the CoTaskMemFree function to free ppDisplayName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetDisplayName();

			/// <summary>Provides a description of the job.</summary>
			/// <param name="pDescription">
			/// Null-terminated string that provides additional information about the job. The length of the string is limited to 1,024
			/// characters, not including the null terminator.
			/// </param>
			new void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string pDescription);

			/// <summary>Retrieves the description of the job.</summary>
			/// <returns>
			/// Null-terminated string that contains a short description of the job. Call the CoTaskMemFree function to free ppDescription
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetDescription();

			/// <summary>
			/// Specifies the priority level of your job. The priority level determines when your job is processed relative to other jobs in
			/// the transfer queue.
			/// </summary>
			/// <param name="Priority">
			/// Specifies the priority level of your job relative to other jobs in the transfer queue. The default is BG_JOB_PRIORITY_NORMAL.
			/// For a list of priority levels, see the BG_JOB_PRIORITY enumeration.
			/// </param>
			new void SetPriority(BG_JOB_PRIORITY Priority);

			/// <summary>
			/// Retrieves the priority level for the job. The priority level determines when the job is processed relative to other jobs in
			/// the transfer queue.
			/// </summary>
			/// <returns>Priority of the job relative to other jobs in the transfer queue.</returns>
			new BG_JOB_PRIORITY GetPriority();

			/// <summary>Specifies the type of event notification you want to receive, such as job transferred events.</summary>
			/// <param name="NotifyFlags">Set one or more of the following flags to identify the events that you want to receive.</param>
			new void SetNotifyFlags([In] BG_NOTIFY NotifyFlags);

			/// <summary>Retrieves the event notification flags for the job.</summary>
			/// <returns>Identifies the events that your application receives.</returns>
			new BG_NOTIFY GetNotifyFlags();

			/// <summary>
			/// Identifies your implementation of the IBackgroundCopyCallback interface to BITS. Use the IBackgroundCopyCallback interface to
			/// receive notification of job-related events.
			/// </summary>
			/// <param name="pNotifyInterface">
			/// An IBackgroundCopyCallback interface pointer. To remove the current callback interface pointer, set this parameter to NULL.
			/// </param>
			new void SetNotifyInterface(IBackgroundCopyCallback pNotifyInterface);

			/// <summary>Retrieves the interface pointer to your implementation of the IBackgroundCopyCallback interface.</summary>
			/// <returns>Interface pointer to your implementation of the IBackgroundCopyCallback interface. When done, release ppNotifyInterface.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetNotifyInterface();

			/// <summary>
			/// Sets the minimum length of time that BITS waits after encountering a transient error condition before trying to transfer the file.
			/// </summary>
			/// <param name="RetryDelay">
			/// Minimum length of time, in seconds, that BITS waits after encountering a transient error before trying to transfer the file.
			/// The default retry delay is 600 seconds (10 minutes). The minimum retry delay that you can specify is 5 seconds. If you
			/// specify a value less than 5 seconds, BITS changes the value to 5 seconds. If the value exceeds the no-progress-timeout value
			/// retrieved from the GetNoProgressTimeout method, BITS will not retry the transfer and moves the job to the BG_JOB_STATE_ERROR state.
			/// </param>
			new void SetMinimumRetryDelay([In] uint RetryDelay);

			/// <summary>
			/// Retrieves the minimum length of time that the service waits after encountering a transient error condition before trying to
			/// transfer the file.
			/// </summary>
			/// <returns>
			/// Length of time, in seconds, that the service waits after encountering a transient error before trying to transfer the file.
			/// </returns>
			new uint GetMinimumRetryDelay();

			/// <summary>
			/// Sets the length of time that BITS tries to transfer the file after a transient error condition occurs. If there is progress,
			/// the timer is reset.
			/// </summary>
			/// <param name="RetryPeriod">
			/// Length of time, in seconds, that BITS tries to transfer the file after the first transient error occurs. The default retry
			/// period is 1,209,600 seconds (14 days). Set the retry period to 0 to prevent retries and to force the job into the
			/// BG_JOB_STATE_ERROR state for all errors. If the retry period value exceeds the JobInactivityTimeout Group Policy value
			/// (90-day default), BITS cancels the job after the policy value is exceeded.
			/// </param>
			new void SetNoProgressTimeout([In] uint RetryPeriod);

			/// <summary>
			/// Retrieves the length of time that the service tries to transfer the file after a transient error condition occurs. If there
			/// is progress, the timer is reset.
			/// </summary>
			/// <returns>Length of time, in seconds, that the service tries to transfer the file after a transient error occurs.</returns>
			new uint GetNoProgressTimeout();

			/// <summary>Retrieves the number of times BITS tried to transfer the job and an error occurred.</summary>
			/// <returns>
			/// Number of errors that occurred while BITS tried to transfer the job. The count increases when the job moves from the
			/// BG_JOB_STATE_TRANSFERRING state to the BG_JOB_STATE_TRANSIENT_ERROR or BG_JOB_STATE_ERROR state.
			/// </returns>
			new uint GetErrorCount();

			/// <summary>Specifies which proxy to use to transfer files.</summary>
			/// <param name="ProxyUsage">
			/// Specifies whether to use the user's proxy settings, not to use a proxy, or to use application-specified proxy settings. The
			/// default is to use the user's proxy settings, BG_JOB_PROXY_USAGE_PRECONFIG. For a list of proxy options, see the
			/// BG_JOB_PROXY_USAGE enumeration.
			/// </param>
			/// <param name="ProxyList">
			/// Null-terminated string that contains the proxies to use to transfer files. The list is space-delimited. For details on
			/// specifying a proxy, see Remarks.
			/// <para>
			/// This parameter must be NULL if the value of ProxyUsage is BG_JOB_PROXY_USAGE_PRECONFIG, BG_JOB_PROXY_USAGE_NO_PROXY, or BG_JOB_PROXY_USAGE_AUTODETECT.
			/// </para>
			/// <para>The length of the proxy list is limited to 4,000 characters, not including the null terminator.</para>
			/// </param>
			/// <param name="ProxyBypassList">
			/// Null-terminated string that contains an optional list of host names, IP addresses, or both, that can bypass the proxy. The
			/// list is space-delimited. For details on specifying a bypass proxy, see Remarks.
			/// <para>
			/// This parameter must be NULL if the value of ProxyUsage is BG_JOB_PROXY_USAGE_PRECONFIG, BG_JOB_PROXY_USAGE_NO_PROXY, or BG_JOB_PROXY_USAGE_AUTODETECT.
			/// </para>
			/// <para>The length of the proxy list is limited to 4,000 characters, not including the null terminator.</para>
			/// </param>
			new void SetProxySettings([In] BG_JOB_PROXY_USAGE ProxyUsage, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyList, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyBypassList);

			/// <summary>Retrieves the proxy information that the job uses to transfer the files.</summary>
			/// <param name="pProxyUsage">
			/// Specifies the proxy settings the job uses to transfer the files. For a list of proxy options, see the BG_JOB_PROXY_USAGE enumeration.
			/// </param>
			/// <param name="pProxyList">
			/// Null-terminated string that contains one or more proxies to use to transfer files. The list is space-delimited. For details
			/// on the format of the string, see the Listing Proxy Servers section of Enabling Internet Functionality. Call the CoTaskMemFree
			/// function to free ppProxyList when done.
			/// </param>
			/// <param name="pProxyBypassList">
			/// Null-terminated string that contains an optional list of host names or IP addresses, or both, that were not routed through
			/// the proxy. The list is space-delimited. For details on the format of the string, see the Listing the Proxy Bypass section of
			/// Enabling Internet Functionality. Call the CoTaskMemFree function to free ppProxyBypassList when done.
			/// </param>
			new void GetProxySettings(out BG_JOB_PROXY_USAGE pProxyUsage, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pProxyList, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pProxyBypassList);

			/// <summary>Changes ownership of the job to the current user.</summary>
			new void TakeOwnership();

			/// <summary>
			/// Specifies a program to execute if the job enters the BG_JOB_STATE_ERROR or BG_JOB_STATE_TRANSFERRED state. BITS executes the
			/// program in the context of the user who called this method.
			/// </summary>
			/// <param name="Program">
			/// Null-terminated string that contains the program to execute. The pProgram parameter is limited to MAX_PATH characters, not
			/// including the null terminator. You should specify a full path to the program; the method will not use the search path to
			/// locate the program.
			/// <para>
			/// To remove command line notification, set pProgram and pParameters to NULL. The method fails if pProgram is NULL and
			/// pParameters is non-NULL.
			/// </para>
			/// </param>
			/// <param name="Parameters">
			/// Null-terminated string that contains the parameters of the program in pProgram. The first parameter must be the program in
			/// pProgram (use quotes if the path uses long file names). The pParameters parameter is limited to 4,000 characters, not
			/// including the null terminator. This parameter can be NULL.
			/// </param>
			new void SetNotifyCmdLine([In, MarshalAs(UnmanagedType.LPWStr)] string Program, [In, MarshalAs(UnmanagedType.LPWStr)] string Parameters);

			/// <summary>Retrieves the program to execute when the job enters the error or transferred state.</summary>
			/// <param name="pProgram">
			/// Null-terminated string that contains the program to execute when the job enters the error or transferred state. Call the
			/// CoTaskMemFree function to free pProgram when done.
			/// </param>
			/// <param name="pParameters">
			/// Null-terminated string that contains the arguments of the program in pProgram. Call the CoTaskMemFree function to free
			/// pParameters when done.
			/// </param>
			new void GetNotifyCmdLine([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pProgram, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pParameters);

			/// <summary>Retrieves progress information related to the transfer of the reply data from an upload-reply job.</summary>
			/// <returns>
			/// Contains information that you use to calculate the percentage of the reply file transfer that is complete. For more
			/// information, see BG_JOB_REPLY_PROGRESS.
			/// </returns>
			new BG_JOB_REPLY_PROGRESS GetReplyProgress();

			/// <summary>
			/// Retrieves an in-memory copy of the reply data from the server application. Call this method only if the job's type is
			/// BG_JOB_TYPE_UPLOAD_REPLY and its state is BG_JOB_STATE_TRANSFERRED.
			/// </summary>
			/// <param name="ppBuffer">
			/// Buffer to contain the reply data. The method sets ppBuffer to NULL if the server application did not return a reply. Call the
			/// CoTaskMemFree function to free ppBuffer when done.
			/// </param>
			/// <param name="pLength">Size, in bytes, of the reply data in ppBuffer.</param>
			new void GetReplyData(out SafeCoTaskMemHandle ppBuffer, out ulong pLength);

			/// <summary>
			/// Specifies the name of the file to contain the reply data from the server application. Call this method only if the job's type
			/// is BG_JOB_TYPE_UPLOAD_REPLY.
			/// </summary>
			/// <param name="ReplyFileName">
			/// Null-terminated string that contains the full path to the reply file. BITS generates the file name if ReplyFileNamePathSpec
			/// is NULL or an empty string. You cannot use wildcards in the path or file name, and directories in the path must exist. The
			/// path is limited to MAX_PATH, not including the null terminator. The user must have permissions to write to the directory.
			/// BITS does not support NTFS streams. Instead of using network drives, which are session specific, use UNC paths (for example,
			/// \\server\share\path\file). Do not include the \\? prefix in the path.
			/// </param>
			new void SetReplyFileName([In, MarshalAs(UnmanagedType.LPWStr)] string ReplyFileName);

			/// <summary>
			/// Retrieves the name of the file that contains the reply data from the server application. Call this method only if the job
			/// type is BG_JOB_TYPE_UPLOAD_REPLY.
			/// </summary>
			/// <returns>
			/// Null-terminated string that contains the full path to the reply file. Call the CoTaskMemFree function to free pReplyFileName
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetReplyFileName();

			/// <summary>Specifies the credentials to use for a proxy or remote server user authentication request.</summary>
			/// <param name="Credentials">
			/// Identifies the target (proxy or server), authentication scheme, and the user's credentials to use for user authentication.
			/// For details, see the BG_AUTH_CREDENTIALS structure.
			/// </param>
			new void SetCredentials(ref BG_AUTH_CREDENTIALS Credentials);

			/// <summary>
			/// Removes credentials from use. The credentials must match an existing target and scheme pair that you specified using the
			/// IBackgroundCopyJob2::SetCredentials method. There is no method to retrieve the credentials you have set.
			/// </summary>
			/// <param name="Target">Identifies whether to use the credentials for proxy or server authentication.</param>
			/// <param name="Scheme">
			/// Identifies the authentication scheme to use (basic or one of several challenge-response schemes). For details, see the
			/// BG_AUTH_SCHEME enumeration.
			/// </param>
			new void RemoveCredentials(BG_AUTH_TARGET Target, BG_AUTH_SCHEME Scheme);

			/// <summary>Replaces the beginning text of all remote names in the download job with the specified string.</summary>
			/// <param name="OldPrefix">
			/// Null-terminated string that identifies the text to replace in the remote name. The text must start at the beginning of the
			/// remote name.
			/// </param>
			/// <param name="NewPrefix">Null-terminated string that contains the replacement text.</param>
			new void ReplaceRemotePrefix([In, MarshalAs(UnmanagedType.LPWStr)] string OldPrefix, [In, MarshalAs(UnmanagedType.LPWStr)] string NewPrefix);

			/// <summary>Adds a file to a download job and specifies the ranges of the file you want to download.</summary>
			/// <param name="RemoteUrl">
			/// Null-terminated string that contains the name of the file on the server. For information on specifying the remote name, see
			/// the RemoteName member and Remarks section of the BG_FILE_INFO structure. Starting with BITS 3.0, the SMB protocol is not
			/// supported for ranges.
			/// <para>BITS 2.5 and 2.0: BITS supports the SMB protocol for ranges.</para>
			/// </param>
			/// <param name="LocalName">
			/// Null-terminated string that contains the name of the file on the client. For information on specifying the local name, see
			/// the LocalName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			/// <param name="rangeCount">Number of elements in Ranges.</param>
			/// <param name="ranges">
			/// Array of one or more BG_FILE_RANGE structures that specify the ranges to download. Do not specify duplicate or overlapping ranges.
			/// </param>
			new void AddFileWithRanges([In, MarshalAs(UnmanagedType.LPWStr)] string RemoteUrl, [In, MarshalAs(UnmanagedType.LPWStr)] string LocalName, [In] uint rangeCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] BG_FILE_RANGE[] ranges);

			/// <summary>Specifies the owner and ACL information to maintain when using SMB to download or upload a file.</summary>
			/// <param name="Flags">
			/// Flags that identify the owner and ACL information to maintain when transferring a file using SMB. Subsequent calls to this
			/// method overwrite the previous flags. Specify 0 to remove the flags from the job. You can specify any combination of the
			/// following flags.
			/// </param>
			new void SetFileACLFlags([In] BG_COPY_FILE Flags);

			/// <summary>Retrieves the flags that identify the owner and ACL information to maintain when transferring a file using SMB.</summary>
			/// <returns>
			/// Flags that identify the owner and ACL information to maintain when transferring a file using SMB. Flags can contain any
			/// combination of the following flags. If no flags are set, Flags is zero.
			/// </returns>
			new BG_COPY_FILE GetFileACLFlags();

			/// <summary>
			/// Sets flags that determine if the files of the job can be cached and served to peers and if the job can download content from peers.
			/// </summary>
			/// <param name="Flags">
			/// Flags that determine if the files of the job can be cached and served to peers and if the job can download content from
			/// peers. The following flags can be set:
			/// </param>
			void SetPeerCachingFlags(BG_JOB_ENABLE_PEERCACHING Flags);

			/// <summary>
			/// Retrieves flags that determine if the files of the job can be cached and served to peers and if BITS can download content for
			/// the job from peers.
			/// </summary>
			/// <returns>
			/// Flags that determine if the files of the job can be cached and served to peers and if BITS can download content for the job
			/// from peers. The following flags can be set:
			/// </returns>
			BG_JOB_ENABLE_PEERCACHING GetPeerCachingFlags();

			/// <summary>Gets the integrity level of the token of the owner that created or took ownership of the job.</summary>
			/// <returns>Integrity level of the token of the owner that created or took ownership of the job.</returns>
			uint GetOwnerIntegrityLevel();

			/// <summary>
			/// Gets a value that determines if the token of the owner was elevated at the time they created or took ownership of the job.
			/// </summary>
			/// <returns>
			/// Is TRUE if the token of the owner was elevated at the time they created or took ownership of the job; otherwise, FALSE.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			bool GetOwnerElevationState();

			/// <summary>Sets the maximum time that BITS will spend transferring the files in the job.</summary>
			/// <param name="Timeout">
			/// Maximum time, in seconds, that BITS will spend transferring the files in the job. The default is 7,776,000 seconds (90 days).
			/// </param>
			void SetMaximumDownloadTime(uint Timeout);

			/// <summary>Retrieves the maximum time that BITS will spend transferring the files in the job.</summary>
			/// <returns>Maximum time, in seconds, that BITS will spend transferring the files in the job.</returns>
			uint GetMaximumDownloadTime();
		}

		/// <summary>
		/// <para>Use this interface to query or set several optional behaviors of a job.</para>
		/// <para>To get this interface, call the <c>IBackgroundCopyJob::QueryInterface</c> method using as the interface identifier.</para>
		/// </summary>
		/// <returns></returns>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/hh446781(v=vs.85).aspx
		[PInvokeData("Bits5_0.h", MSDNShortId = "hh446781", MinClient = PInvokeClient.Windows10)]
		[ComImport, Guid("E847030C-BBBA-4657-AF6D-484AA42BF1FE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IBackgroundCopyJob5 : IBackgroundCopyJob4
		{
			/// <summary>Adds multiple files to a job.</summary>
			/// <param name="cFileCount">Number of elements in paFileSet.</param>
			/// <param name="pFileSet">
			/// Array of BG_FILE_INFO structures that identify the local and remote file names of the files to transfer.
			/// <para>
			/// Upload jobs are restricted to a single file.If the array contains more than one element, or the job already contains a file,
			/// the method returns BG_E_TOO_MANY_FILES.
			/// </para>
			/// </param>
			new void AddFileSet([In] uint cFileCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] BG_FILE_INFO[] pFileSet);

			/// <summary>Adds a single file to the job.</summary>
			/// <param name="RemoteUrl">
			/// Null-terminated string that contains the name of the file on the server. For information on specifying the remote name, see
			/// the RemoteName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			/// <param name="LocalName">
			/// Null-terminated string that contains the name of the file on the client. For information on specifying the local name, see
			/// the LocalName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			new void AddFile([In, MarshalAs(UnmanagedType.LPWStr)] string RemoteUrl, [In, MarshalAs(UnmanagedType.LPWStr)] string LocalName);

			/// <summary>Retrieves an IEnumBackgroundCopyFiles interface pointer that you use to enumerate the files in a job.</summary>
			/// <returns>
			/// IEnumBackgroundCopyFiles interface pointer that you use to enumerate the files in the job. Release ppEnumFiles when done.
			/// </returns>
			new IEnumBackgroundCopyFiles EnumFiles();

			/// <summary>
			/// Suspends a job. New jobs, jobs that are in error, and jobs that have finished transferring files are automatically suspended.
			/// </summary>
			new void Suspend();

			/// <summary>Activates a new job or restarts a job that has been suspended.</summary>
			new void Resume();

			/// <summary>
			/// Deletes the job from the transfer queue and removes related temporary files from the client (downloads) and server (uploads).
			/// </summary>
			new void Cancel();

			/// <summary>Ends the job and saves the transferred files on the client.</summary>
			new void Complete();

			/// <summary>Retrieves the identifier used to identify the job in the queue.</summary>
			/// <returns>GUID that identifies the job within the BITS queue.</returns>
			new Guid GetId();

			/// <summary>Retrieves the type of transfer being performed, such as a file download or upload.</summary>
			/// <returns>Type of transfer being performed. For a list of transfer types, see the BG_JOB_TYPE enumeration.</returns>
			new BG_JOB_TYPE GetType();

			/// <summary>Retrieves job-related progress information, such as the number of bytes and files transferred.</summary>
			/// <returns>
			/// Contains data that you can use to calculate the percentage of the job that is complete. For more information, see BG_JOB_PROGRESS.
			/// </returns>
			new BG_JOB_PROGRESS GetProgress();

			/// <summary>Retrieves job-related time stamps, such as the time that the job was created or last modified.</summary>
			/// <returns>Contains job-related time stamps. For available time stamps, see the BG_JOB_TIMES structure.</returns>
			new BG_JOB_TIMES GetTimes();

			/// <summary>Retrieves the state of the job.</summary>
			/// <returns>
			/// The state of the job. For example, the state reflects whether the job is in error, transferring data, or suspended. For a
			/// list of job states, see the BG_JOB_STATE enumeration.
			/// </returns>
			new BG_JOB_STATE GetState();

			/// <summary>
			/// Retrieves the error interface after an error occurs.
			/// <para>
			/// BITS generates an error object when the state of the job is BG_JOB_STATE_ERROR or BG_JOB_STATE_TRANSIENT_ERROR.The service
			/// does not create an error object when a call to an IBackgroundCopyXXXX interface method fails.The error object is available
			/// until BITS begins transferring data(the state of the job changes to BG_JOB_STATE_TRANSFERRING) for the job or until your
			/// application exits.
			/// </para>
			/// </summary>
			/// <returns>
			/// Error interface that provides the error code, a description of the error, and the context in which the error occurred. This
			/// parameter also identifies the file being transferred at the time the error occurred. Release ppError when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new IBackgroundCopyError GetError();

			/// <summary>Retrieves the identity of the job's owner.</summary>
			/// <returns>
			/// Null-terminated string that contains the string version of the SID that identifies the job's owner. Call the CoTaskMemFree
			/// function to free ppOwner when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetOwner();

			/// <summary>Specifies a display name for the job. Typically, you use the display name to identify the job in a user interface.</summary>
			/// <param name="pDisplayName">
			/// Null-terminated string that identifies the job. Must not be NULL. The length of the string is limited to 256 characters, not
			/// including the null terminator.
			/// </param>
			new void SetDisplayName([In, MarshalAs(UnmanagedType.LPWStr)] string pDisplayName);

			/// <summary>Retrieves the display name for the job. Typically, you use the display name to identify the job in a user interface.</summary>
			/// <returns>
			/// Null-terminated string that contains the display name that identifies the job. More than one job can have the same display
			/// name. Call the CoTaskMemFree function to free ppDisplayName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetDisplayName();

			/// <summary>Provides a description of the job.</summary>
			/// <param name="pDescription">
			/// Null-terminated string that provides additional information about the job. The length of the string is limited to 1,024
			/// characters, not including the null terminator.
			/// </param>
			new void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string pDescription);

			/// <summary>Retrieves the description of the job.</summary>
			/// <returns>
			/// Null-terminated string that contains a short description of the job. Call the CoTaskMemFree function to free ppDescription
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetDescription();

			/// <summary>
			/// Specifies the priority level of your job. The priority level determines when your job is processed relative to other jobs in
			/// the transfer queue.
			/// </summary>
			/// <param name="Priority">
			/// Specifies the priority level of your job relative to other jobs in the transfer queue. The default is BG_JOB_PRIORITY_NORMAL.
			/// For a list of priority levels, see the BG_JOB_PRIORITY enumeration.
			/// </param>
			new void SetPriority(BG_JOB_PRIORITY Priority);

			/// <summary>
			/// Retrieves the priority level for the job. The priority level determines when the job is processed relative to other jobs in
			/// the transfer queue.
			/// </summary>
			/// <returns>Priority of the job relative to other jobs in the transfer queue.</returns>
			new BG_JOB_PRIORITY GetPriority();

			/// <summary>Specifies the type of event notification you want to receive, such as job transferred events.</summary>
			/// <param name="NotifyFlags">Set one or more of the following flags to identify the events that you want to receive.</param>
			new void SetNotifyFlags([In] BG_NOTIFY NotifyFlags);

			/// <summary>Retrieves the event notification flags for the job.</summary>
			/// <returns>Identifies the events that your application receives.</returns>
			new BG_NOTIFY GetNotifyFlags();

			/// <summary>
			/// Identifies your implementation of the IBackgroundCopyCallback interface to BITS. Use the IBackgroundCopyCallback interface to
			/// receive notification of job-related events.
			/// </summary>
			/// <param name="pNotifyInterface">
			/// An IBackgroundCopyCallback interface pointer. To remove the current callback interface pointer, set this parameter to NULL.
			/// </param>
			new void SetNotifyInterface(IBackgroundCopyCallback pNotifyInterface);

			/// <summary>Retrieves the interface pointer to your implementation of the IBackgroundCopyCallback interface.</summary>
			/// <returns>Interface pointer to your implementation of the IBackgroundCopyCallback interface. When done, release ppNotifyInterface.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetNotifyInterface();

			/// <summary>
			/// Sets the minimum length of time that BITS waits after encountering a transient error condition before trying to transfer the file.
			/// </summary>
			/// <param name="RetryDelay">
			/// Minimum length of time, in seconds, that BITS waits after encountering a transient error before trying to transfer the file.
			/// The default retry delay is 600 seconds (10 minutes). The minimum retry delay that you can specify is 5 seconds. If you
			/// specify a value less than 5 seconds, BITS changes the value to 5 seconds. If the value exceeds the no-progress-timeout value
			/// retrieved from the GetNoProgressTimeout method, BITS will not retry the transfer and moves the job to the BG_JOB_STATE_ERROR state.
			/// </param>
			new void SetMinimumRetryDelay([In] uint RetryDelay);

			/// <summary>
			/// Retrieves the minimum length of time that the service waits after encountering a transient error condition before trying to
			/// transfer the file.
			/// </summary>
			/// <returns>
			/// Length of time, in seconds, that the service waits after encountering a transient error before trying to transfer the file.
			/// </returns>
			new uint GetMinimumRetryDelay();

			/// <summary>
			/// Sets the length of time that BITS tries to transfer the file after a transient error condition occurs. If there is progress,
			/// the timer is reset.
			/// </summary>
			/// <param name="RetryPeriod">
			/// Length of time, in seconds, that BITS tries to transfer the file after the first transient error occurs. The default retry
			/// period is 1,209,600 seconds (14 days). Set the retry period to 0 to prevent retries and to force the job into the
			/// BG_JOB_STATE_ERROR state for all errors. If the retry period value exceeds the JobInactivityTimeout Group Policy value
			/// (90-day default), BITS cancels the job after the policy value is exceeded.
			/// </param>
			new void SetNoProgressTimeout([In] uint RetryPeriod);

			/// <summary>
			/// Retrieves the length of time that the service tries to transfer the file after a transient error condition occurs. If there
			/// is progress, the timer is reset.
			/// </summary>
			/// <returns>Length of time, in seconds, that the service tries to transfer the file after a transient error occurs.</returns>
			new uint GetNoProgressTimeout();

			/// <summary>Retrieves the number of times BITS tried to transfer the job and an error occurred.</summary>
			/// <returns>
			/// Number of errors that occurred while BITS tried to transfer the job. The count increases when the job moves from the
			/// BG_JOB_STATE_TRANSFERRING state to the BG_JOB_STATE_TRANSIENT_ERROR or BG_JOB_STATE_ERROR state.
			/// </returns>
			new uint GetErrorCount();

			/// <summary>Specifies which proxy to use to transfer files.</summary>
			/// <param name="ProxyUsage">
			/// Specifies whether to use the user's proxy settings, not to use a proxy, or to use application-specified proxy settings. The
			/// default is to use the user's proxy settings, BG_JOB_PROXY_USAGE_PRECONFIG. For a list of proxy options, see the
			/// BG_JOB_PROXY_USAGE enumeration.
			/// </param>
			/// <param name="ProxyList">
			/// Null-terminated string that contains the proxies to use to transfer files. The list is space-delimited. For details on
			/// specifying a proxy, see Remarks.
			/// <para>
			/// This parameter must be NULL if the value of ProxyUsage is BG_JOB_PROXY_USAGE_PRECONFIG, BG_JOB_PROXY_USAGE_NO_PROXY, or BG_JOB_PROXY_USAGE_AUTODETECT.
			/// </para>
			/// <para>The length of the proxy list is limited to 4,000 characters, not including the null terminator.</para>
			/// </param>
			/// <param name="ProxyBypassList">
			/// Null-terminated string that contains an optional list of host names, IP addresses, or both, that can bypass the proxy. The
			/// list is space-delimited. For details on specifying a bypass proxy, see Remarks.
			/// <para>
			/// This parameter must be NULL if the value of ProxyUsage is BG_JOB_PROXY_USAGE_PRECONFIG, BG_JOB_PROXY_USAGE_NO_PROXY, or BG_JOB_PROXY_USAGE_AUTODETECT.
			/// </para>
			/// <para>The length of the proxy list is limited to 4,000 characters, not including the null terminator.</para>
			/// </param>
			new void SetProxySettings([In] BG_JOB_PROXY_USAGE ProxyUsage, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyList, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyBypassList);

			/// <summary>Retrieves the proxy information that the job uses to transfer the files.</summary>
			/// <param name="pProxyUsage">
			/// Specifies the proxy settings the job uses to transfer the files. For a list of proxy options, see the BG_JOB_PROXY_USAGE enumeration.
			/// </param>
			/// <param name="pProxyList">
			/// Null-terminated string that contains one or more proxies to use to transfer files. The list is space-delimited. For details
			/// on the format of the string, see the Listing Proxy Servers section of Enabling Internet Functionality. Call the CoTaskMemFree
			/// function to free ppProxyList when done.
			/// </param>
			/// <param name="pProxyBypassList">
			/// Null-terminated string that contains an optional list of host names or IP addresses, or both, that were not routed through
			/// the proxy. The list is space-delimited. For details on the format of the string, see the Listing the Proxy Bypass section of
			/// Enabling Internet Functionality. Call the CoTaskMemFree function to free ppProxyBypassList when done.
			/// </param>
			new void GetProxySettings(out BG_JOB_PROXY_USAGE pProxyUsage, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pProxyList, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pProxyBypassList);

			/// <summary>Changes ownership of the job to the current user.</summary>
			new void TakeOwnership();

			/// <summary>
			/// Specifies a program to execute if the job enters the BG_JOB_STATE_ERROR or BG_JOB_STATE_TRANSFERRED state. BITS executes the
			/// program in the context of the user who called this method.
			/// </summary>
			/// <param name="Program">
			/// Null-terminated string that contains the program to execute. The pProgram parameter is limited to MAX_PATH characters, not
			/// including the null terminator. You should specify a full path to the program; the method will not use the search path to
			/// locate the program.
			/// <para>
			/// To remove command line notification, set pProgram and pParameters to NULL. The method fails if pProgram is NULL and
			/// pParameters is non-NULL.
			/// </para>
			/// </param>
			/// <param name="Parameters">
			/// Null-terminated string that contains the parameters of the program in pProgram. The first parameter must be the program in
			/// pProgram (use quotes if the path uses long file names). The pParameters parameter is limited to 4,000 characters, not
			/// including the null terminator. This parameter can be NULL.
			/// </param>
			new void SetNotifyCmdLine([In, MarshalAs(UnmanagedType.LPWStr)] string Program, [In, MarshalAs(UnmanagedType.LPWStr)] string Parameters);

			/// <summary>Retrieves the program to execute when the job enters the error or transferred state.</summary>
			/// <param name="pProgram">
			/// Null-terminated string that contains the program to execute when the job enters the error or transferred state. Call the
			/// CoTaskMemFree function to free pProgram when done.
			/// </param>
			/// <param name="pParameters">
			/// Null-terminated string that contains the arguments of the program in pProgram. Call the CoTaskMemFree function to free
			/// pParameters when done.
			/// </param>
			new void GetNotifyCmdLine([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pProgram, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pParameters);

			/// <summary>Retrieves progress information related to the transfer of the reply data from an upload-reply job.</summary>
			/// <returns>
			/// Contains information that you use to calculate the percentage of the reply file transfer that is complete. For more
			/// information, see BG_JOB_REPLY_PROGRESS.
			/// </returns>
			new BG_JOB_REPLY_PROGRESS GetReplyProgress();

			/// <summary>
			/// Retrieves an in-memory copy of the reply data from the server application. Call this method only if the job's type is
			/// BG_JOB_TYPE_UPLOAD_REPLY and its state is BG_JOB_STATE_TRANSFERRED.
			/// </summary>
			/// <param name="ppBuffer">
			/// Buffer to contain the reply data. The method sets ppBuffer to NULL if the server application did not return a reply. Call the
			/// CoTaskMemFree function to free ppBuffer when done.
			/// </param>
			/// <param name="pLength">Size, in bytes, of the reply data in ppBuffer.</param>
			new void GetReplyData(out SafeCoTaskMemHandle ppBuffer, out ulong pLength);

			/// <summary>
			/// Specifies the name of the file to contain the reply data from the server application. Call this method only if the job's type
			/// is BG_JOB_TYPE_UPLOAD_REPLY.
			/// </summary>
			/// <param name="ReplyFileName">
			/// Null-terminated string that contains the full path to the reply file. BITS generates the file name if ReplyFileNamePathSpec
			/// is NULL or an empty string. You cannot use wildcards in the path or file name, and directories in the path must exist. The
			/// path is limited to MAX_PATH, not including the null terminator. The user must have permissions to write to the directory.
			/// BITS does not support NTFS streams. Instead of using network drives, which are session specific, use UNC paths (for example,
			/// \\server\share\path\file). Do not include the \\? prefix in the path.
			/// </param>
			new void SetReplyFileName([In, MarshalAs(UnmanagedType.LPWStr)] string ReplyFileName);

			/// <summary>
			/// Retrieves the name of the file that contains the reply data from the server application. Call this method only if the job
			/// type is BG_JOB_TYPE_UPLOAD_REPLY.
			/// </summary>
			/// <returns>
			/// Null-terminated string that contains the full path to the reply file. Call the CoTaskMemFree function to free pReplyFileName
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetReplyFileName();

			/// <summary>Specifies the credentials to use for a proxy or remote server user authentication request.</summary>
			/// <param name="Credentials">
			/// Identifies the target (proxy or server), authentication scheme, and the user's credentials to use for user authentication.
			/// For details, see the BG_AUTH_CREDENTIALS structure.
			/// </param>
			new void SetCredentials(ref BG_AUTH_CREDENTIALS Credentials);

			/// <summary>
			/// Removes credentials from use. The credentials must match an existing target and scheme pair that you specified using the
			/// IBackgroundCopyJob2::SetCredentials method. There is no method to retrieve the credentials you have set.
			/// </summary>
			/// <param name="Target">Identifies whether to use the credentials for proxy or server authentication.</param>
			/// <param name="Scheme">
			/// Identifies the authentication scheme to use (basic or one of several challenge-response schemes). For details, see the
			/// BG_AUTH_SCHEME enumeration.
			/// </param>
			new void RemoveCredentials(BG_AUTH_TARGET Target, BG_AUTH_SCHEME Scheme);

			/// <summary>Replaces the beginning text of all remote names in the download job with the specified string.</summary>
			/// <param name="OldPrefix">
			/// Null-terminated string that identifies the text to replace in the remote name. The text must start at the beginning of the
			/// remote name.
			/// </param>
			/// <param name="NewPrefix">Null-terminated string that contains the replacement text.</param>
			new void ReplaceRemotePrefix([In, MarshalAs(UnmanagedType.LPWStr)] string OldPrefix, [In, MarshalAs(UnmanagedType.LPWStr)] string NewPrefix);

			/// <summary>Adds a file to a download job and specifies the ranges of the file you want to download.</summary>
			/// <param name="RemoteUrl">
			/// Null-terminated string that contains the name of the file on the server. For information on specifying the remote name, see
			/// the RemoteName member and Remarks section of the BG_FILE_INFO structure. Starting with BITS 3.0, the SMB protocol is not
			/// supported for ranges.
			/// <para>BITS 2.5 and 2.0: BITS supports the SMB protocol for ranges.</para>
			/// </param>
			/// <param name="LocalName">
			/// Null-terminated string that contains the name of the file on the client. For information on specifying the local name, see
			/// the LocalName member and Remarks section of the BG_FILE_INFO structure.
			/// </param>
			/// <param name="rangeCount">Number of elements in Ranges.</param>
			/// <param name="ranges">
			/// Array of one or more BG_FILE_RANGE structures that specify the ranges to download. Do not specify duplicate or overlapping ranges.
			/// </param>
			new void AddFileWithRanges([In, MarshalAs(UnmanagedType.LPWStr)] string RemoteUrl, [In, MarshalAs(UnmanagedType.LPWStr)] string LocalName, [In] uint rangeCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] BG_FILE_RANGE[] ranges);

			/// <summary>Specifies the owner and ACL information to maintain when using SMB to download or upload a file.</summary>
			/// <param name="Flags">
			/// Flags that identify the owner and ACL information to maintain when transferring a file using SMB. Subsequent calls to this
			/// method overwrite the previous flags. Specify 0 to remove the flags from the job. You can specify any combination of the
			/// following flags.
			/// </param>
			new void SetFileACLFlags([In] BG_COPY_FILE Flags);

			/// <summary>Retrieves the flags that identify the owner and ACL information to maintain when transferring a file using SMB.</summary>
			/// <returns>
			/// Flags that identify the owner and ACL information to maintain when transferring a file using SMB. Flags can contain any
			/// combination of the following flags. If no flags are set, Flags is zero.
			/// </returns>
			new BG_COPY_FILE GetFileACLFlags();

			/// <summary>
			/// Sets flags that determine if the files of the job can be cached and served to peers and if the job can download content from peers.
			/// </summary>
			/// <param name="Flags">
			/// Flags that determine if the files of the job can be cached and served to peers and if the job can download content from
			/// peers. The following flags can be set:
			/// </param>
			new void SetPeerCachingFlags(BG_JOB_ENABLE_PEERCACHING Flags);

			/// <summary>
			/// Retrieves flags that determine if the files of the job can be cached and served to peers and if BITS can download content for
			/// the job from peers.
			/// </summary>
			/// <returns>
			/// Flags that determine if the files of the job can be cached and served to peers and if BITS can download content for the job
			/// from peers. The following flags can be set:
			/// </returns>
			new BG_JOB_ENABLE_PEERCACHING GetPeerCachingFlags();

			/// <summary>Gets the integrity level of the token of the owner that created or took ownership of the job.</summary>
			/// <returns>Integrity level of the token of the owner that created or took ownership of the job.</returns>
			new uint GetOwnerIntegrityLevel();

			/// <summary>
			/// Gets a value that determines if the token of the owner was elevated at the time they created or took ownership of the job.
			/// </summary>
			/// <returns>
			/// Is TRUE if the token of the owner was elevated at the time they created or took ownership of the job; otherwise, FALSE.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool GetOwnerElevationState();

			/// <summary>Sets the maximum time that BITS will spend transferring the files in the job.</summary>
			/// <param name="Timeout">
			/// Maximum time, in seconds, that BITS will spend transferring the files in the job. The default is 7,776,000 seconds (90 days).
			/// </param>
			new void SetMaximumDownloadTime(uint Timeout);

			/// <summary>Retrieves the maximum time that BITS will spend transferring the files in the job.</summary>
			/// <returns>Maximum time, in seconds, that BITS will spend transferring the files in the job.</returns>
			new uint GetMaximumDownloadTime();

			/// <summary>A generic method for setting BITS job properties.</summary>
			/// <param name="PropertyId">The ID of the property that is being set specified as a BITS_JOB_PROPERTY_ID enum value.</param>
			/// <param name="PropertyValue">
			/// The value of the property that is being set. In order to hold a value whose type is appropriate to the property, this value
			/// is specified via the BITS_JOB_PROPERTY_VALUE union that is composed of all the known property types.
			/// </param>
			void SetProperty(BITS_JOB_PROPERTY_ID PropertyId, BITS_JOB_PROPERTY_VALUE PropertyValue);

			/// <summary>A generic method for getting BITS job properties.</summary>
			/// <param name="PropertyId">The ID of the property that is being obtained specified as a BITS_JOB_PROPERTY_ID enum value.</param>
			/// <returns>The property value returned as a BITS_JOB_PROPERTY_VALUE union.</returns>
			BITS_JOB_PROPERTY_VALUE GetProperty(BITS_JOB_PROPERTY_ID PropertyId);
		}

		/// <summary>
		/// <para>
		/// Use this interface to specify client certificates for certificate-based client authentication and custom headers for HTTP requests.
		/// </para>
		/// <para>
		/// To get this interface, call the <c>IBackgroundCopyJob::QueryInterface</c> method using __uuidof(IBackgroundCopyJobHttpOptions)
		/// for the interface identifier.
		/// </para>
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa964250(v=vs.85).aspx
		[PInvokeData("Bits2_5.h", MSDNShortId = "aa964250", MinClient = PInvokeClient.WindowsVista)]
		[ComImport, Guid("F1BD1079-9F01-4BDC-8036-F09B70095066"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComConversionLoss]
		public interface IBackgroundCopyJobHttpOptions
		{
			/// <summary>Specifies the identifier of the client certificate to use for client authentication in an HTTPS (SSL) request.</summary>
			/// <param name="StoreLocation">
			/// Identifies the location of a system store to use for looking up the certificate. For possible values, see the
			/// BG_CERT_STORE_LOCATION enumeration.
			/// </param>
			/// <param name="StoreName">
			/// Null-terminated string that contains the name of the certificate store. The string is limited to 256 characters, including
			/// the null terminator. You can specify one of the following system stores or an application-defined store. The store can be a
			/// local or remote store.
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CA</term>
			/// <description>Certification authority certificates</description>
			/// </item>
			/// <item>
			/// <term>MY</term>
			/// <description>Personal certificates</description>
			/// </item>
			/// <item>
			/// <term>ROOT</term>
			/// <description>Root certificates</description>
			/// </item>
			/// <item>
			/// <term>SPC</term>
			/// <description>Software Publisher Certificate</description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pCertHashBlob">
			/// SHA1 hash that identifies the certificate. Use a 20 byte buffer for the hash. For more information, see Remarks.
			/// </param>
			void SetClientCertificateByID(BG_CERT_STORE_LOCATION StoreLocation, [In, MarshalAs(UnmanagedType.LPWStr)] string StoreName, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 20)] byte[] pCertHashBlob);

			/// <summary>Specifies the subject name of the client certificate to use for client authentication in an HTTPS (SSL) request.</summary>
			/// <param name="StoreLocation">
			/// Identifies the location of a system store to use for looking up the certificate. For possible values, see the
			/// BG_CERT_STORE_LOCATION enumeration.
			/// </param>
			/// <param name="StoreName">
			/// Null-terminated string that contains the name of the certificate store. The string is limited to 256 characters, including
			/// the null terminator. You can specify one of the following system stores or an application-defined store. The store can be a
			/// local or remote store.
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CA</term>
			/// <description>Certification authority certificates</description>
			/// </item>
			/// <item>
			/// <term>MY</term>
			/// <description>Personal certificates</description>
			/// </item>
			/// <item>
			/// <term>ROOT</term>
			/// <description>Root certificates</description>
			/// </item>
			/// <item>
			/// <term>SPC</term>
			/// <description>Software Publisher Certificate</description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="SubjectName">
			/// Null-terminated string that contains the simple subject name of the certificate. If the subject name contains multiple
			/// relative distinguished names (RDNs), you can specify one or more adjacent RDNs. If you specify more than one RDN, the list is
			/// comma-delimited. The string is limited to 256 characters, including the null terminator. You cannot specify an empty subject name.
			/// <para>
			/// Do not include the object identifier in the name.You must specify the RDNs in the reverse order from what the certificate
			/// displays. For example, if the subject name in the certificate is "CN=name1, OU=name2, O=name3", specify the subject name as
			/// "name3, name2, name1".
			/// </para>
			/// </param>
			void SetClientCertificateByName(BG_CERT_STORE_LOCATION StoreLocation, [In, MarshalAs(UnmanagedType.LPWStr)] string StoreName, [In, MarshalAs(UnmanagedType.LPWStr)] string SubjectName);

			/// <summary>Removes the client certificate from the job.</summary>
			void RemoveClientCertificate();

			/// <summary>Retrieves the client certificate from the job.</summary>
			/// <param name="pStoreLocation">
			/// Identifies the location of a system store to use for looking up the certificate. For possible values, see the
			/// BG_CERT_STORE_LOCATION enumeration.
			/// </param>
			/// <param name="pStoreName">
			/// Null-terminated string that contains the name of the certificate store. To free the string when done, call the CoTaskMemFree function.
			/// </param>
			/// <param name="ppCertHashBlob">
			/// SHA1 hash that identifies the certificate. To free the blob when done, call the CoTaskMemFree function.
			/// </param>
			/// <param name="pSubjectName">
			/// Null-terminated string that contains the simple subject name of the certificate. The RDNs in the subject name are in the
			/// reverse order from what the certificate displays. Subject name can be empty if the certificate does not contain a subject
			/// name. To free the string when done, call the CoTaskMemFree function.
			/// </param>
			void GetClientCertificate(out BG_CERT_STORE_LOCATION pStoreLocation, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pStoreName, out SafeCoTaskMemHandle ppCertHashBlob, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pSubjectName);

			/// <summary>Specifies one or more custom HTTP headers to include in HTTP requests.</summary>
			/// <param name="RequestHeaders">
			/// Null-terminated string that contains the custom headers to append to the HTTP request. Each header must be terminated by a
			/// carriage return and line feed (CR/LF) character. The string is limited to 16,384 characters, including the null terminator.
			/// <para>To remove the custom headers from the job, set the RequestHeaders parameter to NULL.</para>
			/// </param>
			void SetCustomHeaders([In, MarshalAs(UnmanagedType.LPWStr)] string RequestHeaders);

			/// <summary>
			/// Retrieves the custom headers set by an earlier call to IBackgroundCopyJobHttpOptions::SetCustomHeaders (that is, headers
			/// which BITS will be sending to the remote, not headers which BITS receives from the remote).
			/// </summary>
			/// <returns>
			/// Null-terminated string that contains the custom headers. Each header is terminated by a carriage return and line feed (CR/LF)
			/// character. To free the string when finished, call the CoTaskMemFree function.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetCustomHeaders();

			/// <summary>
			/// Sets flags for HTTP that determine whether the certificate revocation list is checked and certain certificate errors are
			/// ignored, and the policy to use when a server redirects the HTTP request.
			/// </summary>
			/// <param name="Flags">
			/// HTTP security flags that indicate which errors to ignore when connecting to the server. You can set one or more of the
			/// following flags:
			/// </param>
			void SetSecurityFlags([In] BG_HTTP_SECURITY Flags);

			/// <summary>
			/// Retrieves the flags for HTTP that determine whether the certificate revocation list is checked and certain certificate errors
			/// are ignored, and the policy to use when a server redirects the HTTP request.
			/// </summary>
			/// <returns>
			/// HTTP security flags that indicate which errors to ignore when connecting to the server. One or more of the following flags
			/// can be set:
			/// </returns>
			BG_HTTP_SECURITY GetSecurityFlags();
		}

		/// <summary>
		/// <para>Use this interface to retrieve and/or to override the HTTP method used for a BITS transfer.</para>
		/// <para>To get this interface, call the <c>IBackgroundCopyJob::QueryInterface</c> method using __uuidof(IBackgroundCopyJobHttpOptions2) for the interface identifier.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/bits10_2/nn-bits10_2-ibackgroundcopyjobhttpoptions2
		[PInvokeData("bits10_2.h", MSDNShortId = "NN:bits10_2.IBackgroundCopyJobHttpOptions2")]
		[ComImport, Guid("B591A192-A405-4FC3-8323-4C5C542578FC"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComConversionLoss]
		public interface IBackgroundCopyJobHttpOptions2 : IBackgroundCopyJobHttpOptions
		{
			/// <summary>Specifies the identifier of the client certificate to use for client authentication in an HTTPS (SSL) request.</summary>
			/// <param name="StoreLocation">
			/// Identifies the location of a system store to use for looking up the certificate. For possible values, see the
			/// BG_CERT_STORE_LOCATION enumeration.
			/// </param>
			/// <param name="StoreName">
			/// Null-terminated string that contains the name of the certificate store. The string is limited to 256 characters, including
			/// the null terminator. You can specify one of the following system stores or an application-defined store. The store can be a
			/// local or remote store.
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CA</term>
			/// <description>Certification authority certificates</description>
			/// </item>
			/// <item>
			/// <term>MY</term>
			/// <description>Personal certificates</description>
			/// </item>
			/// <item>
			/// <term>ROOT</term>
			/// <description>Root certificates</description>
			/// </item>
			/// <item>
			/// <term>SPC</term>
			/// <description>Software Publisher Certificate</description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pCertHashBlob">
			/// SHA1 hash that identifies the certificate. Use a 20 byte buffer for the hash. For more information, see Remarks.
			/// </param>
			new void SetClientCertificateByID(BG_CERT_STORE_LOCATION StoreLocation, [In, MarshalAs(UnmanagedType.LPWStr)] string StoreName, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 20)] byte[] pCertHashBlob);

			/// <summary>Specifies the subject name of the client certificate to use for client authentication in an HTTPS (SSL) request.</summary>
			/// <param name="StoreLocation">
			/// Identifies the location of a system store to use for looking up the certificate. For possible values, see the
			/// BG_CERT_STORE_LOCATION enumeration.
			/// </param>
			/// <param name="StoreName">
			/// Null-terminated string that contains the name of the certificate store. The string is limited to 256 characters, including
			/// the null terminator. You can specify one of the following system stores or an application-defined store. The store can be a
			/// local or remote store.
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CA</term>
			/// <description>Certification authority certificates</description>
			/// </item>
			/// <item>
			/// <term>MY</term>
			/// <description>Personal certificates</description>
			/// </item>
			/// <item>
			/// <term>ROOT</term>
			/// <description>Root certificates</description>
			/// </item>
			/// <item>
			/// <term>SPC</term>
			/// <description>Software Publisher Certificate</description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="SubjectName">
			/// Null-terminated string that contains the simple subject name of the certificate. If the subject name contains multiple
			/// relative distinguished names (RDNs), you can specify one or more adjacent RDNs. If you specify more than one RDN, the list is
			/// comma-delimited. The string is limited to 256 characters, including the null terminator. You cannot specify an empty subject name.
			/// <para>
			/// Do not include the object identifier in the name.You must specify the RDNs in the reverse order from what the certificate
			/// displays. For example, if the subject name in the certificate is "CN=name1, OU=name2, O=name3", specify the subject name as
			/// "name3, name2, name1".
			/// </para>
			/// </param>
			new void SetClientCertificateByName(BG_CERT_STORE_LOCATION StoreLocation, [In, MarshalAs(UnmanagedType.LPWStr)] string StoreName, [In, MarshalAs(UnmanagedType.LPWStr)] string SubjectName);

			/// <summary>Removes the client certificate from the job.</summary>
			new void RemoveClientCertificate();

			/// <summary>Retrieves the client certificate from the job.</summary>
			/// <param name="pStoreLocation">
			/// Identifies the location of a system store to use for looking up the certificate. For possible values, see the
			/// BG_CERT_STORE_LOCATION enumeration.
			/// </param>
			/// <param name="pStoreName">
			/// Null-terminated string that contains the name of the certificate store. To free the string when done, call the CoTaskMemFree function.
			/// </param>
			/// <param name="ppCertHashBlob">
			/// SHA1 hash that identifies the certificate. To free the blob when done, call the CoTaskMemFree function.
			/// </param>
			/// <param name="pSubjectName">
			/// Null-terminated string that contains the simple subject name of the certificate. The RDNs in the subject name are in the
			/// reverse order from what the certificate displays. Subject name can be empty if the certificate does not contain a subject
			/// name. To free the string when done, call the CoTaskMemFree function.
			/// </param>
			new void GetClientCertificate(out BG_CERT_STORE_LOCATION pStoreLocation, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pStoreName, out SafeCoTaskMemHandle ppCertHashBlob, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pSubjectName);

			/// <summary>Specifies one or more custom HTTP headers to include in HTTP requests.</summary>
			/// <param name="RequestHeaders">
			/// Null-terminated string that contains the custom headers to append to the HTTP request. Each header must be terminated by a
			/// carriage return and line feed (CR/LF) character. The string is limited to 16,384 characters, including the null terminator.
			/// <para>To remove the custom headers from the job, set the RequestHeaders parameter to NULL.</para>
			/// </param>
			new void SetCustomHeaders([In, MarshalAs(UnmanagedType.LPWStr)] string RequestHeaders);

			/// <summary>
			/// Retrieves the custom headers set by an earlier call to IBackgroundCopyJobHttpOptions::SetCustomHeaders (that is, headers
			/// which BITS will be sending to the remote, not headers which BITS receives from the remote).
			/// </summary>
			/// <returns>
			/// Null-terminated string that contains the custom headers. Each header is terminated by a carriage return and line feed (CR/LF)
			/// character. To free the string when finished, call the CoTaskMemFree function.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetCustomHeaders();

			/// <summary>
			/// Sets flags for HTTP that determine whether the certificate revocation list is checked and certain certificate errors are
			/// ignored, and the policy to use when a server redirects the HTTP request.
			/// </summary>
			/// <param name="Flags">
			/// HTTP security flags that indicate which errors to ignore when connecting to the server. You can set one or more of the
			/// following flags:
			/// </param>
			new void SetSecurityFlags([In] BG_HTTP_SECURITY Flags);

			/// <summary>
			/// Retrieves the flags for HTTP that determine whether the certificate revocation list is checked and certain certificate errors
			/// are ignored, and the policy to use when a server redirects the HTTP request.
			/// </summary>
			/// <returns>
			/// HTTP security flags that indicate which errors to ignore when connecting to the server. One or more of the following flags
			/// can be set:
			/// </returns>
			new BG_HTTP_SECURITY GetSecurityFlags();

			/// <summary>Overrides the default HTTP method used for a BITS transfer.</summary>
			/// <param name="method">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a constant null-terminated string of wide characters containing the HTTP method name.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// BITS allows you, as the developer, to choose an HTTP method other than the default method. This increases BITS' ability to
			/// interact with servers that don't adhere to the normal BITS requirements for HTTP servers. Bear the following in mind when
			/// you choose a different HTTP method from the default one.
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>BITS automatically changes the job priority to BG_JOB_PRIORITY_FOREGROUND, and prevents that priority from being changed.</term>
			/// </item>
			/// <item>
			/// <term>
			/// An error that would ordinarily be resumable (such as loss of connectivity) transitions the job to an ERROR state. You, as
			/// the developer, can restart the job by calling IBackgroundCopyJob::Resume, and the job will be restarted from the beginning.
			/// See Life Cycle of a BITS Job for more information on BITS job states.
			/// </term>
			/// </item>
			/// <item>
			/// <term>BITS doesn’t allow DYNAMIC_CONTENT nor ON_DEMAND_MODE jobs with <c>SetHttpMethod</c>.</term>
			/// </item>
			/// </list>
			/// <para>
			/// <c>SetHttpMethod</c> does nothing if the method name that you pass matches the default HTTP method for the transfer type.
			/// For example, if you set a download job method to "GET" (the default), then the job priority won't be changed. The HTTP
			/// method must be set before the first call to IBackgroundCopyJob::Resume that starts the job.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/bits10_2/nf-bits10_2-ibackgroundcopyjobhttpoptions2-sethttpmethod
			// HRESULT SetHttpMethod( [in] LPCWSTR method );
			void SetHttpMethod([MarshalAs(UnmanagedType.LPWStr)] string method);

			/// <summary>
			/// Retrieves a wide string containing the HTTP method name for the BITS transfer. By default, download jobs will be "GET", and
			/// upload and upload-reply jobs will be "BITS_POST".
			/// </summary>
			/// <returns>A string containing the HTTP method name.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/bits10_2/nf-bits10_2-ibackgroundcopyjobhttpoptions2-gethttpmethod
			// HRESULT GetHttpMethod( [out] LPWSTR *method );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetHttpMethod();
		}

		/// <summary>Use this interface to set HTTP customer headers to write-only, or to set a server certificate validation callback method that you've implemented. This interface extends IBackgroundCopyJobHttpOptions2.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/bits10_3/nn-bits10_3-ibackgroundcopyjobhttpoptions3
		[PInvokeData("bits10_3.h", MSDNShortId = "NN:bits10_3.IBackgroundCopyJobHttpOptions3")]
		[ComImport, Guid("8A9263D3-FD4C-4EDA-9B28-30132A4D4E3C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComConversionLoss]
		public interface IBackgroundCopyJobHttpOptions3 : IBackgroundCopyJobHttpOptions2
		{
			/// <summary>Specifies the identifier of the client certificate to use for client authentication in an HTTPS (SSL) request.</summary>
			/// <param name="StoreLocation">
			/// Identifies the location of a system store to use for looking up the certificate. For possible values, see the
			/// BG_CERT_STORE_LOCATION enumeration.
			/// </param>
			/// <param name="StoreName">
			/// Null-terminated string that contains the name of the certificate store. The string is limited to 256 characters, including
			/// the null terminator. You can specify one of the following system stores or an application-defined store. The store can be a
			/// local or remote store.
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CA</term>
			/// <description>Certification authority certificates</description>
			/// </item>
			/// <item>
			/// <term>MY</term>
			/// <description>Personal certificates</description>
			/// </item>
			/// <item>
			/// <term>ROOT</term>
			/// <description>Root certificates</description>
			/// </item>
			/// <item>
			/// <term>SPC</term>
			/// <description>Software Publisher Certificate</description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pCertHashBlob">
			/// SHA1 hash that identifies the certificate. Use a 20 byte buffer for the hash. For more information, see Remarks.
			/// </param>
			new void SetClientCertificateByID(BG_CERT_STORE_LOCATION StoreLocation, [In, MarshalAs(UnmanagedType.LPWStr)] string StoreName, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 20)] byte[] pCertHashBlob);

			/// <summary>Specifies the subject name of the client certificate to use for client authentication in an HTTPS (SSL) request.</summary>
			/// <param name="StoreLocation">
			/// Identifies the location of a system store to use for looking up the certificate. For possible values, see the
			/// BG_CERT_STORE_LOCATION enumeration.
			/// </param>
			/// <param name="StoreName">
			/// Null-terminated string that contains the name of the certificate store. The string is limited to 256 characters, including
			/// the null terminator. You can specify one of the following system stores or an application-defined store. The store can be a
			/// local or remote store.
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CA</term>
			/// <description>Certification authority certificates</description>
			/// </item>
			/// <item>
			/// <term>MY</term>
			/// <description>Personal certificates</description>
			/// </item>
			/// <item>
			/// <term>ROOT</term>
			/// <description>Root certificates</description>
			/// </item>
			/// <item>
			/// <term>SPC</term>
			/// <description>Software Publisher Certificate</description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="SubjectName">
			/// Null-terminated string that contains the simple subject name of the certificate. If the subject name contains multiple
			/// relative distinguished names (RDNs), you can specify one or more adjacent RDNs. If you specify more than one RDN, the list is
			/// comma-delimited. The string is limited to 256 characters, including the null terminator. You cannot specify an empty subject name.
			/// <para>
			/// Do not include the object identifier in the name.You must specify the RDNs in the reverse order from what the certificate
			/// displays. For example, if the subject name in the certificate is "CN=name1, OU=name2, O=name3", specify the subject name as
			/// "name3, name2, name1".
			/// </para>
			/// </param>
			new void SetClientCertificateByName(BG_CERT_STORE_LOCATION StoreLocation, [In, MarshalAs(UnmanagedType.LPWStr)] string StoreName, [In, MarshalAs(UnmanagedType.LPWStr)] string SubjectName);

			/// <summary>Removes the client certificate from the job.</summary>
			new void RemoveClientCertificate();

			/// <summary>Retrieves the client certificate from the job.</summary>
			/// <param name="pStoreLocation">
			/// Identifies the location of a system store to use for looking up the certificate. For possible values, see the
			/// BG_CERT_STORE_LOCATION enumeration.
			/// </param>
			/// <param name="pStoreName">
			/// Null-terminated string that contains the name of the certificate store. To free the string when done, call the CoTaskMemFree function.
			/// </param>
			/// <param name="ppCertHashBlob">
			/// SHA1 hash that identifies the certificate. To free the blob when done, call the CoTaskMemFree function.
			/// </param>
			/// <param name="pSubjectName">
			/// Null-terminated string that contains the simple subject name of the certificate. The RDNs in the subject name are in the
			/// reverse order from what the certificate displays. Subject name can be empty if the certificate does not contain a subject
			/// name. To free the string when done, call the CoTaskMemFree function.
			/// </param>
			new void GetClientCertificate(out BG_CERT_STORE_LOCATION pStoreLocation, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pStoreName, out SafeCoTaskMemHandle ppCertHashBlob, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string pSubjectName);

			/// <summary>Specifies one or more custom HTTP headers to include in HTTP requests.</summary>
			/// <param name="RequestHeaders">
			/// Null-terminated string that contains the custom headers to append to the HTTP request. Each header must be terminated by a
			/// carriage return and line feed (CR/LF) character. The string is limited to 16,384 characters, including the null terminator.
			/// <para>To remove the custom headers from the job, set the RequestHeaders parameter to NULL.</para>
			/// </param>
			new void SetCustomHeaders([In, MarshalAs(UnmanagedType.LPWStr)] string RequestHeaders);

			/// <summary>
			/// Retrieves the custom headers set by an earlier call to IBackgroundCopyJobHttpOptions::SetCustomHeaders (that is, headers
			/// which BITS will be sending to the remote, not headers which BITS receives from the remote).
			/// </summary>
			/// <returns>
			/// Null-terminated string that contains the custom headers. Each header is terminated by a carriage return and line feed (CR/LF)
			/// character. To free the string when finished, call the CoTaskMemFree function.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetCustomHeaders();

			/// <summary>
			/// Sets flags for HTTP that determine whether the certificate revocation list is checked and certain certificate errors are
			/// ignored, and the policy to use when a server redirects the HTTP request.
			/// </summary>
			/// <param name="Flags">
			/// HTTP security flags that indicate which errors to ignore when connecting to the server. You can set one or more of the
			/// following flags:
			/// </param>
			new void SetSecurityFlags([In] BG_HTTP_SECURITY Flags);

			/// <summary>
			/// Retrieves the flags for HTTP that determine whether the certificate revocation list is checked and certain certificate errors
			/// are ignored, and the policy to use when a server redirects the HTTP request.
			/// </summary>
			/// <returns>
			/// HTTP security flags that indicate which errors to ignore when connecting to the server. One or more of the following flags
			/// can be set:
			/// </returns>
			new BG_HTTP_SECURITY GetSecurityFlags();

			/// <summary>Overrides the default HTTP method used for a BITS transfer.</summary>
			/// <param name="method">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a constant null-terminated string of wide characters containing the HTTP method name.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// BITS allows you, as the developer, to choose an HTTP method other than the default method. This increases BITS' ability to
			/// interact with servers that don't adhere to the normal BITS requirements for HTTP servers. Bear the following in mind when
			/// you choose a different HTTP method from the default one.
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>BITS automatically changes the job priority to BG_JOB_PRIORITY_FOREGROUND, and prevents that priority from being changed.</term>
			/// </item>
			/// <item>
			/// <term>
			/// An error that would ordinarily be resumable (such as loss of connectivity) transitions the job to an ERROR state. You, as
			/// the developer, can restart the job by calling IBackgroundCopyJob::Resume, and the job will be restarted from the beginning.
			/// See Life Cycle of a BITS Job for more information on BITS job states.
			/// </term>
			/// </item>
			/// <item>
			/// <term>BITS doesn’t allow DYNAMIC_CONTENT nor ON_DEMAND_MODE jobs with <c>SetHttpMethod</c>.</term>
			/// </item>
			/// </list>
			/// <para>
			/// <c>SetHttpMethod</c> does nothing if the method name that you pass matches the default HTTP method for the transfer type.
			/// For example, if you set a download job method to "GET" (the default), then the job priority won't be changed. The HTTP
			/// method must be set before the first call to IBackgroundCopyJob::Resume that starts the job.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/bits10_2/nf-bits10_2-ibackgroundcopyjobhttpoptions2-sethttpmethod
			// HRESULT SetHttpMethod( [in] LPCWSTR method );
			new void SetHttpMethod([MarshalAs(UnmanagedType.LPWStr)] string method);

			/// <summary>
			/// Retrieves a wide string containing the HTTP method name for the BITS transfer. By default, download jobs will be "GET", and
			/// upload and upload-reply jobs will be "BITS_POST".
			/// </summary>
			/// <returns>A string containing the HTTP method name.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/bits10_2/nf-bits10_2-ibackgroundcopyjobhttpoptions2-gethttpmethod
			// HRESULT GetHttpMethod( [out] LPWSTR *method );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetHttpMethod();

			/// <summary>
			/// Server certificates are sent when an HTTPS connection is opened. Use this method to set a callback to be called to validate
			/// those server certificates.
			/// </summary>
			/// <param name="certValidationCallback">
			/// <para>Type: <c>IUnknown*</c></para>
			/// <para>
			/// A pointer to an object that implements IBackgroundCopyServerCertificateValidationCallback. To remove the current callback
			/// interface pointer, set this parameter to <c>nullptr</c>.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para>Use this method when you want to perform your own checks on the server certificate.</para>
			/// <para>Call this method only if you implement the IBackgroundCopyServerCertificateValidationCallback interface.</para>
			/// <para>
			/// The validation interface becomes invalid when your application terminates; BITS does not maintain a record of the validation
			/// interface. As a result, your application's initialization process should call <c>SetServerCertificateValidationInterface</c>
			/// on those existing jobs for which you want to receive certificate validation requests.
			/// </para>
			/// <para>
			/// If more than one application calls <c>SetServerCertificateValidationInterface</c> to set the notification interface for the
			/// job, the last application to call it is the one that will receive notifications. The other applications will not receive notifications.
			/// </para>
			/// <para>
			/// If any certificate errors are found during the OS validation of the certificate, then the connection is aborted, and the
			/// custom callback is never called. You can customize the OS validation logic with a call to
			/// IBackgroundCopyJobHttpOptions::SetSecurityFlags. For example, you can ignore expected certificate validation errors.
			/// </para>
			/// <para>
			/// If OS validation passes, then the IBackgroundCopyServerCertificateValidationCallback::ValidateServerCertificate method is
			/// called before completing the TLS handshake and before the HTTP request is sent.
			/// </para>
			/// <para>
			/// If your validation method declines the certificate, the job will transition to <c>BG_JOB_STATE_TRANSIENT_ERROR</c> with a
			/// job error context of <c>BG_ERROR_CONTEXT_SERVER_CERTIFICATE_CALLBACK</c> and the error <c>HRESULT</c> from your callback. If
			/// your callback couldn't be called (for example, because BITS needed to validate a server certificate after your program
			/// exited), then the job error code will be <c>BG_E_SERVER_CERT_VALIDATION_INTERFACE_REQUIRED</c>. When your application is
			/// next run, it can fix this error by setting the validation callback again and resuming the job.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/bits10_3/nf-bits10_3-ibackgroundcopyjobhttpoptions3-setservercertificatevalidationinterface
			// HRESULT SetServerCertificateValidationInterface( IUnknown *certValidationCallback );
			void SetServerCertificateValidationInterface(IBackgroundCopyServerCertificateValidationCallback certValidationCallback);

			/// <summary>
			/// Sets the HTTP custom headers for this job to be write-only. Write-only headers cannot be read by BITS methods such as the
			/// IBackgroundCopyJobHttpOptions::GetCustomHeaders method.
			/// </summary>
			/// <remarks>
			/// Use this API when your BITS custom headers must include security information (such as an API token) that you don't want to
			/// be readable by other programs running on the same computer. The BITS process, of course, can still read these headers, and
			/// send them over the HTTP connection. Once the headers are set to write-only, that cannot be unset.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/bits10_3/nf-bits10_3-ibackgroundcopyjobhttpoptions3-makecustomheaderswriteonly
			// HRESULT MakeCustomHeadersWriteOnly();
			void MakeCustomHeadersWriteOnly();
		}

		/// <summary>
		/// Creates transfer jobs, retrieves an enumerator object that contains the jobs in the queue, and retrieves individual jobs from the queue.
		/// </summary>
		[PInvokeData("Bits.h", MSDNShortId = "aa363050")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5CE34C0D-0DC9-4C1F-897C-DAA1B78CEE7C"), CoClass(typeof(BackgroundCopyManager))]
		public interface IBackgroundCopyManager
		{
			/// <summary>
			/// Null-terminated string that contains a display name for the job. Typically, the display name is used to identify the job in a
			/// user interface. Note that more than one job may have the same display name. Must not be NULL. The name is limited to 256
			/// characters, not including the null terminator.
			/// </summary>
			/// <param name="DisplayName">The display name.</param>
			/// <param name="Type">
			/// Type of transfer job, such as BG_JOB_TYPE_DOWNLOAD. For a list of transfer types, see the BG_JOB_TYPE enumeration.
			/// </param>
			/// <param name="pJobId">
			/// Uniquely identifies your job in the queue. Use this identifier when you call the IBackgroundCopyManager::GetJob method to get
			/// a job from the queue.
			/// </param>
			/// <param name="ppJob">
			/// An IBackgroundCopyJob interface pointer that you use to modify the job's properties and specify the files to be transferred.
			/// To activate the job in the queue, call the IBackgroundCopyJob::Resume method. Release ppJob when done.
			/// </param>
			void CreateJob([In, MarshalAs(UnmanagedType.LPWStr)] string DisplayName, [In] BG_JOB_TYPE Type, out Guid pJobId, out IBackgroundCopyJob ppJob);

			/// <summary>
			/// Retrieves a specified job from the transfer queue. Typically, your application persists the job identifier, so you can later
			/// retrieve the job from the queue.
			/// </summary>
			/// <param name="jobID">Identifies the job to retrieve from the transfer queue. The CreateJob method returns the job identifier.</param>
			/// <returns>An IBackgroundCopyJob interface pointer to the job specified by JobID. When done, release ppJob.</returns>
			IBackgroundCopyJob GetJob(in Guid jobID);

			/// <summary>
			/// Retrieves an interface pointer to an enumerator object that you use to enumerate the jobs in the transfer queue. The order of
			/// the jobs in the enumerator is arbitrary.
			/// </summary>
			/// <param name="dwFlags">
			/// Specifies whose jobs to include in the enumeration. If dwFlags is set to 0, the user receives all jobs that they own in the
			/// transfer queue.
			/// </param>
			/// <returns>
			/// An IEnumBackgroundCopyJobs interface pointer that you use to enumerate the jobs in the transfer queue. The contents of the
			/// enumerator depend on the value of dwFlags. Release ppEnumJobs when done.
			/// </returns>
			IEnumBackgroundCopyJobs EnumJobs([In] BG_JOB_ENUM dwFlags);

			/// <summary>Retrieves a description for the specified error code.</summary>
			/// <param name="hResult">Error code from a previous call to a BITS method.</param>
			/// <param name="LanguageId">
			/// Identifies the language identifier to use to generate the description. To create the language identifier, use the MAKELANGID
			/// macro. For example, to specify U.S. English, use the following code sample.
			/// <para>MAKELANGID(LANG_ENGLISH, SUBLANG_ENGLISH_US)</para>
			/// <para>To retrieve the system's default user language identifier, use the following calls.</para>
			/// <para>LANGIDFROMLCID(GetThreadLocale())</para>
			/// </param>
			/// <returns>
			/// Null-terminated string that contains a description of the error. Call the CoTaskMemFree function to free ppErrorDescription
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetErrorDescription([In] HRESULT hResult, [In] uint LanguageId);
		}

		/// <summary>
		/// <para>Use <c>IBitsPeer</c> to get information about a peer in the neighborhood.</para>
		/// <para>To get this interface, call the <c>IEnumBitsPeers::Next</c> method.</para>
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa964270(v=vs.85).aspx
		[PInvokeData("Bits3_0.h", MSDNShortId = "aa964270", MinClient = PInvokeClient.WindowsVista)]
		[ComImport, Guid("659CDEA2-489E-11D9-A9CD-000D56965251"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IBitsPeer
		{
			/// <summary>Gets the server principal name that uniquely identifies the peer.</summary>
			/// <returns>
			/// Null-terminated string that contains the server principal name of the peer. The principal name is of the form,
			/// server$.domain.suffix. Call the CoTaskMemFree function to free pName when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetPeerName();

			/// <summary>Determines whether the peer is authenticated.</summary>
			/// <returns>TRUE if the peer is authenticated, otherwise, FALSE.</returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			bool IsAuthenticated();

			/// <summary>Determines whether the peer is available (online) to serve content.</summary>
			/// <returns>TRUE if the peer is available to serve content, otherwise, FALSE.</returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			bool IsAvailable();
		}

		/// <summary>
		/// <para>Use <c>IBitsPeerCacheAdministration</c> to manage the pool of peers from which you can download content.</para>
		/// <para>
		/// To get this interface, call the <c>IBackgroundCopyManager::QueryInterface</c> method, using
		/// __uuidof(IBitsPeerCacheAdministration) as the interface identifier.
		/// </para>
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa964272(v=vs.85).aspx
		[PInvokeData("Bits3_0.h", MSDNShortId = "aa964272")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("659CDEAD-489E-11D9-A9CD-000D56965251")]
		public interface IBitsPeerCacheAdministration
		{
			/// <summary>Gets the maximum size of the cache.</summary>
			/// <returns>Maximum size of the cache, as a percentage of available hard disk drive space.</returns>
			uint GetMaximumCacheSize();

			/// <summary>Specifies the maximum size of the cache.</summary>
			/// <param name="Bytes">Maximum size of the cache, as a percentage of available hard disk drive space.</param>
			void SetMaximumCacheSize(uint Bytes);

			/// <summary>Gets the age by when files are removed from the cache.</summary>
			/// <returns>
			/// Age, in seconds. If the last time that the file was accessed is older than this age, BITS removes the file from the cache.
			/// </returns>
			uint GetMaximumContentAge();

			/// <summary>Specifies when files are removed from the cache based on age.</summary>
			/// <param name="Seconds">
			/// Age, in seconds. If the last time that the file was accessed is older than this age, BITS removes the file from the cache.
			/// The age is reset each time the file is accessed. The maximum value is 10,368,000 seconds (120 days) and the minimum value is
			/// 86,400 seconds (1 day). The default is 7,776,000 seconds (90 days).
			/// </param>
			void SetMaximumContentAge(uint Seconds);

			/// <summary>
			/// Gets the configuration flags that determine if the computer serves content to peers and can download content from peers.
			/// </summary>
			/// <returns>
			/// Flags that determine if the computer serves content to peers and can download content from peers. The following flags can be set:
			/// </returns>
			BG_ENABLE_PEERCACHING GetConfigurationFlags();

			/// <summary>
			/// Sets the configuration flags that determine if the computer can serve content to peers and can download content from peers.
			/// </summary>
			/// <param name="Flags">
			/// Flags that determine if the computer can serve content to peers and can download content from peers. The following flags can
			/// be set:
			/// </param>
			void SetConfigurationFlags(BG_ENABLE_PEERCACHING Flags);

			/// <summary>
			/// Gets an IEnumBitsPeerCacheRecords interface pointer that you use to enumerate the records in the cache. The enumeration is a
			/// snapshot of the records in the cache.
			/// </summary>
			/// <returns>
			/// An IEnumBitsPeerCacheRecords interface pointer that you use to enumerate the records in the cache. Release ppEnum when done.
			/// </returns>
			IEnumBitsPeerCacheRecords EnumRecords();

			/// <summary>Gets a record from the cache.</summary>
			/// <param name="id">Identifier of the record to get from the cache. The IBitsPeerCacheRecord::GetId method returns the identifier.</param>
			/// <returns>An IBitsPeerCacheRecord interface of the cache record. Release ppRecord when done.</returns>
			IBitsPeerCacheRecord GetRecord(in Guid id);

			/// <summary>Removes all the records and files from the cache.</summary>
			void ClearRecords();

			/// <summary>
			/// Deletes a record and file from the cache. This method uses the record's identifier to identify the record to delete.
			/// </summary>
			/// <param name="id">
			/// Identifier of the record to delete from the cache. The IBitsPeerCacheRecord::GetId method returns the identifier.
			/// </param>
			void DeleteRecord(in Guid id);

			/// <summary>Deletes all cache records and the file from the cache for the given URL.</summary>
			/// <param name="url">
			/// Null-terminated string that contains the URL of the file whose cache records and file you want to delete from the cache.
			/// </param>
			void DeleteUrl([In, MarshalAs(UnmanagedType.LPWStr)] string url);

			/// <summary>
			/// Gets an IEnumBitsPeers interface pointer that you use to enumerate the peers that can serve content. The enumeration is a
			/// snapshot of the records in the cache.
			/// </summary>
			/// <returns>
			/// An IEnumBitsPeers interface pointer that you use to enumerate the peers that can serve content. Release ppEnum when done.
			/// </returns>
			IEnumBitsPeers EnumPeers();

			/// <summary>Removes all peers from the list of peers that can serve content.</summary>
			void ClearPeers();

			/// <summary>Generates a list of peers that can serve content.</summary>
			void DiscoverPeers();
		}

		/// <summary>
		/// <para>Use <c>IBitsPeerCacheRecord</c> to get information about a file in the cache.</para>
		/// <para>To get this interface, call one of the following methods:</para>
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa964291(v=vs.85).aspx
		[PInvokeData("Bits3_0.h", MSDNShortId = "aa964291")]
		[ComImport, Guid("659CDEAF-489E-11D9-A9CD-000D56965251"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComConversionLoss]
		public interface IBitsPeerCacheRecord
		{
			/// <summary>Gets the identifier.</summary>
			/// <returns></returns>
			Guid GetId();

			/// <summary>Gets the origin URL of the cached file.</summary>
			/// <returns>
			/// Null-terminated string that contains the origin URL of the cached file. Call the CoTaskMemFree function to free ppOriginUrl
			/// when done.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetOriginUrl();

			/// <summary>Gets the size of the file.</summary>
			/// <returns>Size of the file, in bytes.</returns>
			ulong GetFileSize();

			/// <summary>Gets the date and time that the file was last modified on the server.</summary>
			/// <returns>Date and time that the file was last modified on the server. The time is specified as FILETIME.</returns>
			FILETIME GetFileModificationTime();

			/// <summary>Gets the date and time that the file was last accessed.</summary>
			/// <returns>Date and time that the file was last accessed. The time is specified as FILETIME.</returns>
			FILETIME GetLastAccessTime();

			/// <summary>Determines whether the file has been validated.</summary>
			/// <returns>The method returns the following return values. S_OK: File has been validated. S_FALSE: File has not been validated.</returns>
			[PreserveSig]
			HRESULT IsFileValidated();

			/// <summary>Gets the ranges of the file that are in the cache.</summary>
			/// <param name="pRangeCount">Number of elements in ppRanges.</param>
			/// <param name="ppRanges">
			/// Array of BG_FILE_RANGE structures that specify the ranges of the file that are in the cache. When done, call the
			/// CoTaskMemFree function to free ppRanges.
			/// </param>
			void GetFileRanges(out uint pRangeCount, out SafeCoTaskMemHandle ppRanges);
		}

		/// <summary>
		/// Server certificates are sent when an HTTPS connection is opened. Use this method to implement a callback to be called to
		/// validate those server certificates. This interface extends IUnknown.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/bits10_3/nn-bits10_3-ibackgroundcopyservercertificatevalidationcallback
		[PInvokeData("bits10_3.h", MSDNShortId = "NN:bits10_3.IBackgroundCopyServerCertificateValidationCallback")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("4CEC0D02-DEF7-4158-813A-C32A46945FF7")]
		public interface IBackgroundCopyServerCertificateValidationCallback
		{
			/// <summary>
			/// A callback method that you implement that will be called so that you can validate the server certificates sent when an HTTPS
			/// connection is opened.
			/// </summary>
			/// <param name="job">
			/// <para>Type: <c>IBackgroundCopyJob*</c></para>
			/// <para>The job.</para>
			/// </param>
			/// <param name="file">
			/// <para>Type: <c>IBackgroundCopyFile*</c></para>
			/// <para>The file being transferred.</para>
			/// </param>
			/// <param name="certLength">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The length in bytes of the certificate data.</para>
			/// </param>
			/// <param name="certData">
			/// <para>Type: <c>const BYTE []</c></para>
			/// <para>An array of bytes containing the certificate data. The number of bytes must match certLength.</para>
			/// </param>
			/// <param name="certEncodingType">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The certificate encoding type.</para>
			/// </param>
			/// <param name="certStoreLength">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The length in bytes of the certificate store data.</para>
			/// </param>
			/// <param name="certStoreData">
			/// <para>Type: <c>const BYTE []</c></para>
			/// <para>An array of bytes containing the certificate store data. The number of bytes must match certStoreLength.</para>
			/// </param>
			/// <returns>
			/// Return <c>S_OK</c> to indicate that the certificate is acceptable. Otherwise, return any <c>HRESULT</c> error code to
			/// indicate that the certificate is not acceptable.
			/// </returns>
			/// <remarks>
			/// <para>
			/// Certificate validation is performed in two phases. The first phase is the operating system (OS) phase where the OS performs
			/// a standard set of validation checks on the certificate. After that, if the OS phase passes the certificate, your callback
			/// will be called to perform additional validation.
			/// </para>
			/// <para>
			/// Implement this validation method when you want to perform your own checks on the server certificate. Your own checks are in
			/// addition to the normal OS certificate validation checks.
			/// </para>
			/// <para>
			/// If your validation method declines the certificate, the job will transition to <c>BG_JOB_STATE_TRANSIENT_ERROR</c> with a
			/// job error context of <c>BG_ERROR_CONTEXT_SERVER_CERTIFICATE_CALLBACK</c> and the error <c>HRESULT</c> from your callback. If
			/// your callback couldn't be called (for example, because BITS needed to validate a server certificate after your program
			/// exited), then the job error code will be <c>BG_E_SERVER_CERT_VALIDATION_INTERFACE_REQUIRED</c>. When your application is
			/// next run, it can fix this error by setting the validation callback again and resuming the job.
			/// </para>
			/// <para>
			/// BITS calls this callback method only if you implement the IBackgroundCopyServerCertificateValidationCallback interface and
			/// pass it into IBackgroundCopyJobHttpOptions3::SetServerCertificateValidationInterface.
			/// </para>
			/// <para>
			/// The validation interface becomes invalid when your application terminates; BITS does not maintain a record of the validation
			/// interface. As a result, your application's initialization process should call SetServerCertificateValidationInterface on
			/// those existing jobs for which you want to receive certificate validation requests.
			/// </para>
			/// <para>
			/// If more than one application calls <c>SetServerCertificateValidationInterface</c> to set the notification interface for the
			/// job, the last application to call it is the one that will receive notifications. The other applications will not receive notifications.
			/// </para>
			/// <para>
			/// Here are the general steps to validate a certificate. Be aware that these steps are just an example. The actual validation
			/// is under your control. Also, steps 5-7 are largely the same as what the OS does during the OS validation step.
			/// </para>
			/// <list type="number">
			/// <item>
			/// Call CertCreateCertificateContext with certEncodingType, certData, and certLength to retrieve a CERT_CONTEXT.
			/// </item>
			/// <item>
			/// Declare and initialize a CRYPT_DATA_BLOB structure (defined in wincrypt.h) with the serialized memory blob passed via certStoreLength and certStoreData.
			/// <code language="cpp"><![CDATA[DATA_BLOB storeData{};
			/// storeData.cbData = certStoreLength;
			/// storeData.pbData = const_cast<PBYTE>(certStoreData);]]></code>
			/// </item>
			/// <item>
			/// Obtain a handle to the certificate chain by calling CertOpenStore with <c>CERT_STORE_PROV_SERIALIZED</c>, 0, nullptr, flags,
			/// and a pointer to the <c>CRYPT_DATA_BLOB</c> from step 2.
			/// </item>
			/// <item>
			/// Obtain a pointer to a certificate chain context by calling CertGetCertificateChain with nullptr, certContext, nullptr, the handle from step 3, chain parameters, flags, and nullptr.
			/// </item>
			/// <item>
			/// Create the certificate validation policy.
			/// <code language="cpp"><![CDATA[CERT_CHAIN_POLICY_PARA policyParams{};
			/// policyParams.cbSize = sizeof(policyParams);
			/// policyParams.dwFlags =
			///     CERT_CHAIN_POLICY_IGNORE_NOT_TIME_VALID_FLAG |
			///     CERT_CHAIN_POLICY_IGNORE_WRONG_USAGE_FLAG |
			///     CERT_CHAIN_POLICY_IGNORE_INVALID_NAME_FLAG |
			///     CERT_CHAIN_POLICY_ALLOW_UNKNOWN_CA_FLAG;]]></code>
			/// </item>
			/// <item>
			/// Call CertVerifyCertificateChainPolicy with policy type, chain context, policy parameters, and policy status.
			/// </item>
			/// <item>
			/// Convert the Win32 error (policyStatus.dwError) to an HRESULT and return that.
			/// </item>
			/// </list>
			/// <para>
			/// A description of the BITS validation caching behaviors follows. BITS maintains a per-job cache of certificates that have
			/// passed custom validation. This is to avoid redundant and potentially expensive re-validation over the lifetime of the job.
			/// The cache consists of &lt;server endpoint, cert hash&gt; tuples, where endpoint is defined as server name:port. If a job has
			/// already allowed a specific certificate from a specific endpoint, then the callback will not be called again.
			/// </para>
			/// <para>
			/// Of course, the certificate will have to pass through the OS validation logic on every connection attempt (you can customize
			/// the OS validation logic with a call to IBackgroundCopyJobHttpOptions::SetSecurityFlags), which addresses time-sensitive
			/// corner cases such as when the certificate was valid very recently (in terms of seconds), but it has expired now.
			/// </para>
			/// <para>
			/// BITS does not cache certificates that are deemed invalid by the app-provided validation callback. It's important that you're
			/// aware of all unsuccessful connection attempts, so that you can detect malicious deployments at the app level. For example, a
			/// one-off bad certificate is much less concerning than thousands of bad certificates from the same server.
			/// </para>
			/// <para>
			/// A job's certificate cache is cleared on every call to <c>SetServerCertificateValidationInterface</c>, since it indicates
			/// that the app's server certificate validation logic has changed.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/bits10_3/nf-bits10_3-ibackgroundcopyservercertificatevalidationcallback-validateservercertificate
			// HRESULT ValidateServerCertificate( IBackgroundCopyJob *job, IBackgroundCopyFile *file, DWORD certLength, const BYTE []
			// certData, DWORD certEncodingType, DWORD certStoreLength, const BYTE [] certStoreData );
			[PreserveSig]
			HRESULT ValidateServerCertificate(IBackgroundCopyJob job, IBackgroundCopyFile file, uint certLength,
				[In, MarshalAs(UnmanagedType.LPArray)] byte[] certData, uint certEncodingType, uint certStoreLength,
				[In, MarshalAs(UnmanagedType.LPArray)] byte[] certStoreData);
		}

		/// <summary>
		/// <para>
		/// Use <c>IBitsTokenOptions</c> to associate and manage a pair of security tokens for a Background Intelligent Transfer Service
		/// (BITS) transfer job.
		/// </para>
		/// <para>
		/// To get this interface, call the <c>IBackgroundCopyJob::QueryInterface</c> method, using __uuidof(IBitsTokenOptions) as the
		/// interface identifier.
		/// </para>
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/dd904470(v=vs.85).aspx
		[PInvokeData("Bits4_0.h", MSDNShortId = "dd904470", MinClient = PInvokeClient.Windows7)]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("9A2584C3-F7D2-457A-9A5E-22B67BFFC7D2")]
		public interface IBitsTokenOptions
		{
			/// <summary>Sets the usage flags for a token that is associated with a BITS transfer job.</summary>
			/// <param name="UsageFlags">
			/// <para>Specifies the usage flag. This parameter must be set to one of the following values:</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>BG_TOKEN_LOCAL_FILE0x0001</term>
			/// <term>If this flag is specified, the helper token is used</term>
			/// </item>
			/// <item>
			/// <term>BG_TOKEN_NETWORK0x0002</term>
			/// <term>
			/// If this flag is specified, the helper token is usedAn application is required to call IBackgroundCopyJob2::SetCredentials
			/// (..., NULL, NULL) to allow the credentials to be sent over HTTP.
			/// </term>
			/// </item>
			/// </list>
			/// </para>
			/// </param>
			void SetHelperTokenFlags(BG_TOKEN UsageFlags);

			/// <summary>Returns the usage flags for a token that is associated with a BITS transfer job.</summary>
			/// <returns>Specifies the usage flag to return.</returns>
			BG_TOKEN GetHelperTokenFlags();

			/// <summary>
			/// Sets the helper token to impersonate the token of the COM client. Because an application sets the token through COM
			/// impersonation, the token is not persistent and is valid only for the lifetime of a session. When the BITS service receives a
			/// log-off notification, the BITS service discards any helper tokens that are associated with the transfer job.
			/// </summary>
			void SetHelperToken();

			/// <summary>Discards the helper token, and does not change the usage flags.</summary>
			void ClearHelperToken();

			/// <summary>Returns the SID of the helper token if one is set.</summary>
			/// <returns>
			/// Returns the SID that is retrieved from the TokenInformation parameter of the GetTokenInformation function. If no SID is
			/// retrieved, this parameter is set to NULL.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetHelperTokenSid();
		}

		/// <summary>
		/// Use the <c>IEnumBackgroundCopyFiles</c> interface to enumerate the files that a job contains. To get an
		/// <c>IEnumBackgroundCopyFiles</c> interface pointer, call the <c>IBackgroundCopyJob::EnumFiles</c> method.
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa363097(v=vs.85).aspx
		[PInvokeData("Bits.h", MSDNShortId = "aa363097")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("CA51E165-C365-424C-8D41-24AAA4FF3C40")]
		public interface IEnumBackgroundCopyFiles
		{
			/// <summary>
			/// Retrieves a specified number of items in the enumeration sequence. If there are fewer than the requested number of elements
			/// left in the sequence, it retrieves the remaining elements.
			/// </summary>
			/// <param name="celt">Number of elements requested.</param>
			/// <param name="rgelt">Array of IBackgroundCopyFile objects. You must release each object in rgelt when done.</param>
			/// <param name="pceltFetched">
			/// Number of elements returned in rgelt. You can set pceltFetched to NULL if celt is one. Otherwise, initialize the value of
			/// pceltFetched to 0 before calling this method.
			/// </param>
			void Next([In] uint celt, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0, ArraySubType = UnmanagedType.Interface)] IBackgroundCopyFile[] rgelt, [In, Out] ref uint pceltFetched);

			/// <summary>
			/// Skips the next specified number of elements in the enumeration sequence. If there are fewer elements left in the sequence
			/// than the requested number of elements to skip, it skips past the last element in the sequence.
			/// </summary>
			/// <param name="celt">Number of elements to skip.</param>
			void Skip([In] uint celt);

			/// <summary>Resets the enumeration sequence to the beginning.</summary>
			void Reset();

			/// <summary>
			/// Creates another IEnumBackgroundCopyFiles enumerator that contains the same enumeration state as the current one.
			/// <para>
			/// Using this method, a client can record a particular point in the enumeration sequence, and then return to that point at a
			/// later time.The new enumerator supports the same interface as the original one.
			/// </para>
			/// </summary>
			/// <returns>
			/// Receives the interface pointer to the enumeration object. If the method is unsuccessful, the value of this output variable is
			/// undefined. You must release ppEnumFiles when done.
			/// </returns>
			IEnumBackgroundCopyFiles Clone();

			/// <summary>Retrieves a count of the number of files in the enumeration.</summary>
			/// <returns>Number of files in the enumeration.</returns>
			uint GetCount();
		}

		/// <summary>
		/// Use the IEnumBackgroundCopyJobs interface to enumerate the list of jobs in the transfer queue. To get an IEnumBackgroundCopyJobs
		/// interface pointer, call the IBackgroundCopyManager::EnumJobs method.
		/// </summary>
		[PInvokeData("Bits.h", MSDNShortId = "aa363109")]
		[ComImport, Guid("1AF4F612-3B71-466F-8F58-7B6F73AC57AD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IEnumBackgroundCopyJobs
		{
			/// <summary>
			/// Retrieves a specified number of items in the enumeration sequence. If there are fewer than the requested number of elements
			/// left in the sequence, it retrieves the remaining elements.
			/// </summary>
			/// <param name="celt">Number of elements requested.</param>
			/// <param name="rgelt">Array of IBackgroundCopyJob objects. You must release each object in rgelt when done.</param>
			/// <param name="pceltFetched">
			/// Number of elements returned in rgelt. You can set pceltFetched to NULL if celt is one. Otherwise, initialize the value of
			/// pceltFetched to 0 before calling this method.
			/// </param>
			void Next([In] uint celt, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0, ArraySubType = UnmanagedType.Interface)] IBackgroundCopyJob[] rgelt, [In, Out] ref uint pceltFetched);

			/// <summary>
			/// Skips the next specified number of elements in the enumeration sequence. If there are fewer elements left in the sequence
			/// than the requested number of elements to skip, it skips past the last element in the sequence.
			/// </summary>
			/// <param name="celt">Number of elements to skip.</param>
			void Skip([In] uint celt);

			/// <summary>Resets the enumeration sequence to the beginning.</summary>
			void Reset();

			/// <summary>
			/// Creates another IEnumBackgroundCopyJobs enumerator that contains the same enumeration state as the current one.
			/// <para>
			/// Using this method, a client can record a particular point in the enumeration sequence, and then return to that point at a
			/// later time.The new enumerator supports the same interface as the original one.
			/// </para>
			/// </summary>
			/// <returns>
			/// Receives the interface pointer to the enumeration object. If the method is unsuccessful, the value of this output variable is
			/// undefined. You must release ppEnumJobs when done.
			/// </returns>
			IEnumBackgroundCopyJobs Clone();

			/// <summary>Retrieves a count of the number of jobs in the enumeration.</summary>
			/// <returns>Number of jobs in the enumeration.</returns>
			uint GetCount();
		}

		/// <summary>
		/// <para>Use <c>IEnumBitsPeerCacheRecords</c> to enumerate the records of the cache.</para>
		/// <para>To get this interface, call the <c>IBitsPeerCacheAdministration::EnumRecords</c> method.</para>
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa964302(v=vs.85).aspx
		[PInvokeData("Bits3_0.h", MSDNShortId = "aa964302")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("659CDEA4-489E-11D9-A9CD-000D56965251")]
		public interface IEnumBitsPeerCacheRecords
		{
			/// <summary>
			/// Retrieves a specified number of items in the enumeration sequence. If there are fewer than the requested number of elements
			/// left in the sequence, it retrieves the remaining elements.
			/// </summary>
			/// <param name="celt">Number of elements requested.</param>
			/// <param name="rgelt">Array of IBitsPeerCacheRecord objects. You must release each object in rgelt when done.</param>
			/// <param name="pceltFetched">
			/// Number of elements returned in rgelt. You can set pceltFetched to NULL if celt is one. Otherwise, initialize the value of
			/// pceltFetched to 0 before calling this method.
			/// </param>
			void Next([In] uint celt, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0, ArraySubType = UnmanagedType.Interface)] IBitsPeerCacheRecord[] rgelt, [In, Out] ref uint pceltFetched);

			/// <summary>
			/// Skips the next specified number of elements in the enumeration sequence. If there are fewer elements left in the sequence
			/// than the requested number of elements to skip, it skips past the last element in the sequence.
			/// </summary>
			/// <param name="celt">Number of elements to skip.</param>
			void Skip([In] uint celt);

			/// <summary>Resets the enumeration sequence to the beginning.</summary>
			void Reset();

			/// <summary>
			/// Creates another IEnumBitsPeerCacheRecords enumerator that contains the same enumeration state as the current one.
			/// <para>
			/// Using this method, a client can record a particular point in the enumeration sequence, and then return to that point at a
			/// later time.The new enumerator supports the same interface as the original one.
			/// </para>
			/// </summary>
			/// <returns>
			/// Receives the interface pointer to the enumeration object. If the method is unsuccessful, the value of this output variable is
			/// undefined. You must release ppEnum when done.
			/// </returns>
			IEnumBitsPeerCacheRecords Clone();

			/// <summary>Retrieves a count of the number of jobs in the enumeration.</summary>
			/// <returns>Number of jobs in the enumeration.</returns>
			uint GetCount();
		}

		/// <summary>
		/// <para>Use <c>IEnumBitsPeers</c> to enumerate the list of peers that BITS has discovered.</para>
		/// <para>To get this interface, call the <c>IBitsPeerCacheAdministration::EnumPeers</c> method.</para>
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa964308(v=vs.85).aspx
		[PInvokeData("Bits3_0.h", MSDNShortId = "aa964308")]
		[ComImport, Guid("659CDEA5-489E-11D9-A9CD-000D56965251"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IEnumBitsPeers
		{
			/// <summary>
			/// Retrieves a specified number of items in the enumeration sequence. If there are fewer than the requested number of elements
			/// left in the sequence, it retrieves the remaining elements.
			/// </summary>
			/// <param name="celt">Number of elements requested.</param>
			/// <param name="rgelt">Array of IBitsPeer objects. You must release each object in rgelt when done.</param>
			/// <param name="pceltFetched">
			/// Number of elements returned in rgelt. You can set pceltFetched to NULL if celt is one. Otherwise, initialize the value of
			/// pceltFetched to 0 before calling this method.
			/// </param>
			void Next([In] uint celt, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0, ArraySubType = UnmanagedType.Interface)] IBitsPeer[] rgelt, [In, Out] ref uint pceltFetched);

			/// <summary>
			/// Skips the next specified number of elements in the enumeration sequence. If there are fewer elements left in the sequence
			/// than the requested number of elements to skip, it skips past the last element in the sequence.
			/// </summary>
			/// <param name="celt">Number of elements to skip.</param>
			void Skip([In] uint celt);

			/// <summary>Resets the enumeration sequence to the beginning.</summary>
			void Reset();

			/// <summary>Clones this instance.</summary>
			/// <returns></returns>
			IEnumBitsPeers Clone();

			/// <summary>Retrieves a count of the number of jobs in the enumeration.</summary>
			/// <returns>Number of jobs in the enumeration.</returns>
			uint GetCount();
		}

		/// <summary>Retrieves the ranges that you want to download from the remote file.</summary>
		/// <param name="obj">The <c>IBackgroundCopyFile2</c> object against which to execute this method.</param>
		/// <returns>Array of BG_FILE_RANGE structures that specify the ranges to download.</returns>
		/// <exception cref="ArgumentNullException">obj</exception>
		public static BG_FILE_RANGE[] GetFileRanges(this IBackgroundCopyFile2 obj)
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));
			obj.GetFileRanges(out var cnt, out var ranges);
			return ranges.ToArray<BG_FILE_RANGE>((int)cnt);
		}

		/// <summary>Gets the ranges of the file that are in the cache.</summary>
		/// <param name="obj">The IBitsPeerCacheRecord instance from which to get the ranges.</param>
		/// <returns>Array of BG_FILE_RANGE structures that specify the ranges of the file that are in the cache.</returns>
		/// <exception cref="ArgumentNullException">obj</exception>
		public static BG_FILE_RANGE[] GetFileRanges(this IBitsPeerCacheRecord obj)
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));
			obj.GetFileRanges(out var cnt, out var ranges);
			return ranges.ToArray<BG_FILE_RANGE>((int)cnt);
		}

		/// <summary>Returns the set of file ranges that have been downloaded.</summary>
		/// <param name="obj">The <c>IBackgroundCopyFile6</c> object against which to execute this method.</param>
		/// <returns>
		/// Array of BG_FILE_RANGE structures that describes the ranges that have been downloaded. Ranges will be merged together as much as
		/// possible. The ranges are ordered by offset.
		/// </returns>
		/// <exception cref="ArgumentNullException">obj</exception>
		public static BG_FILE_RANGE[] GetFilledFileRanges(this IBackgroundCopyFile6 obj)
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));
			obj.GetFilledFileRanges(out var cnt, out var ranges);
			return ranges.ToArray<BG_FILE_RANGE>((int)cnt);
		}

		/// <summary>
		/// Retrieves a specified number of items in the enumeration sequence. If there are fewer than the requested number of elements left
		/// in the sequence, it retrieves the remaining elements.
		/// </summary>
		/// <param name="obj">The object on which to call Next.</param>
		/// <param name="celt">Number of elements requested.</param>
		/// <returns>Array of IBackgroundCopyJob objects.</returns>
		public static IBackgroundCopyJob[] Next(this IEnumBackgroundCopyJobs obj, uint celt)
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));
			uint f = 0;
			var ptr = new IBackgroundCopyJob[celt];
			obj.Next(celt, ptr, ref f);
			Array.Resize(ref ptr, (int)f);
			return ptr;
		}

		/// <summary>
		/// Retrieves a specified number of items in the enumeration sequence. If there are fewer than the requested number of elements left
		/// in the sequence, it retrieves the remaining elements.
		/// </summary>
		/// <param name="obj">The object on which to call Next.</param>
		/// <param name="celt">Number of elements requested.</param>
		/// <returns>Array of IBitsPeerCacheRecord objects.</returns>
		public static IBitsPeerCacheRecord[] Next(this IEnumBitsPeerCacheRecords obj, uint celt)
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));
			uint f = 0;
			var ptr = new IBitsPeerCacheRecord[celt];
			obj.Next(celt, ptr, ref f);
			Array.Resize(ref ptr, (int)f);
			return ptr;
		}

		/// <summary>
		/// Retrieves a specified number of items in the enumeration sequence. If there are fewer than the requested number of elements left
		/// in the sequence, it retrieves the remaining elements.
		/// </summary>
		/// <param name="obj">The object on which to call Next.</param>
		/// <param name="celt">Number of elements requested.</param>
		/// <returns>Array of IBitsPeer objects.</returns>
		public static IBitsPeer[] Next(this IEnumBitsPeers obj, uint celt)
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));
			uint f = 0;
			var ptr = new IBitsPeer[celt];
			obj.Next(celt, ptr, ref f);
			Array.Resize(ref ptr, (int)f);
			return ptr;
		}

		/// <summary>
		/// Retrieves a specified number of items in the enumeration sequence. If there are fewer than the requested number of elements left
		/// in the sequence, it retrieves the remaining elements.
		/// </summary>
		/// <param name="obj">The object on which to call Next.</param>
		/// <param name="celt">Number of elements requested.</param>
		/// <returns>Array of IBackgroundCopyJob objects.</returns>
		public static IBackgroundCopyFile[] Next(this IEnumBackgroundCopyFiles obj, uint celt)
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));
			uint f = 0;
			var ptr = new IBackgroundCopyFile[celt];
			obj.Next(celt, ptr, ref f);
			Array.Resize(ref ptr, (int)f);
			return ptr;
		}

		/// <summary>
		/// The <c>BG_AUTH_CREDENTIALS</c> structure identifies the target (proxy or server), authentication scheme, and the user's
		/// credentials to use for user authentication requests. The structure is passed to the <c>IBackgroundCopyJob2::SetCredentials</c> method.
		/// </summary>
		// typedef struct { BG_AUTH_TARGET Target; BG_AUTH_SCHEME Scheme; BG_AUTH_CREDENTIALS_UNION Credentials;} BG_AUTH_CREDENTIALS; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362785(v=vs.85).aspx
		[PInvokeData("Bits1_5.h", MSDNShortId = "aa362785")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct BG_AUTH_CREDENTIALS
		{
			/// <summary>
			/// Identifies whether to use the credentials for a proxy or server authentication request. For a list of values, see the
			/// <c>BG_AUTH_TARGET</c> enumeration. You can specify only one value.
			/// </summary>
			public BG_AUTH_TARGET Target;

			/// <summary>
			/// Identifies the scheme to use for authentication (for example, Basic or NTLM). For a list of values, see the
			/// <c>BG_AUTH_SCHEME</c> enumeration. You can specify only one value.
			/// </summary>
			public BG_AUTH_SCHEME Scheme;

			/// <summary>
			/// Identifies the credentials to use for the specified authentication scheme. For details, see the
			/// <c>BG_AUTH_CREDENTIALS_UNION</c> union.
			/// </summary>
			public BG_AUTH_CREDENTIALS_UNION Credentials;

			/// <summary>
			/// The <c>BG_AUTH_CREDENTIALS_UNION</c> union identifies the credentials to use for the authentication scheme specified in the
			/// <c>BG_AUTH_CREDENTIALS</c> structure.
			/// </summary>
			/// <returns></returns>
			// typedef union { BG_BASIC_CREDENTIALS Basic;} BG_AUTH_CREDENTIALS_UNION; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362787(v=vs.85).aspx
			[PInvokeData("Bits1_5.h", MSDNShortId = "aa362787")]
			[StructLayout(LayoutKind.Explicit, Size = 8, Pack = 4)]
			public struct BG_AUTH_CREDENTIALS_UNION
			{
				/// <summary>
				/// Identifies the user name and password of the user to authenticate. For details, see the BG_BASIC_CREDENTIALS structure.
				/// </summary>
				[FieldOffset(0)]
				public BG_BASIC_CREDENTIALS Basic;

				/// <summary>The <c>BG_BASIC_CREDENTIALS</c> structure identifies the user name and password to authenticate.</summary>
				// typedef struct { LPWSTR UserName; LPWSTR Password;} BG_BASIC_CREDENTIALS; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362793(v=vs.85).aspx
				[PInvokeData("Bits1_5.h", MSDNShortId = "aa362793")]
				[StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
				public struct BG_BASIC_CREDENTIALS
				{
					/// <summary>
					/// <para>
					/// Null-terminated string that contains the user name to authenticate. The user name is limited to 300 characters, not
					/// including the null terminator. The format of the user name depends on the authentication scheme requested. For
					/// example, for Basic, NTLM, and Negotiate authentication, the user name is of the form DomainName <c>\</c> UserName.
					/// For Passport authentication, the user name is an email address. For more information, see Remarks.
					/// </para>
					/// <para>If <c>NULL</c>, default credentials for this session context are used.</para>
					/// </summary>
					public string UserName;

					/// <summary>
					/// <para>
					/// Null-terminated string that contains the password in plaintext. The password is limited to 65536 characters, not
					/// including the null terminator. The password can be blank. Set it to <c>NULL</c> if <c>UserName</c> is <c>NULL</c>.
					/// BITS encrypts the password before persisting the job if a network disconnect occurs or the user logs off.
					/// </para>
					/// <para>
					/// Live ID encoded passwords are supported through Negotiate 2. For more information about Live IDs, see the Windows
					/// Live ID SDK.
					/// </para>
					/// </summary>
					public string Password;
				}
			}
		}

		/// <summary>The <c>BG_FILE_INFO</c> structure provides the local and remote names of the file to transfer.</summary>
		// typedef struct _BG_FILE_INFO { LPWSTR RemoteName; LPWSTR LocalName;} BG_FILE_INFO; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362800(v=vs.85).aspx
		[PInvokeData("Bits.h", MSDNShortId = "aa362800")]
		[StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
		public struct BG_FILE_INFO
		{
			/// <summary>
			/// <para>
			/// Null-terminated string that contains the name of the file on the server (for example,
			/// http://&lt;server&gt;/&lt;path&gt;/file.ext). The format of the name must conform to the transfer protocol you use. You
			/// cannot use wildcards in the path or file name. The URL must contain only legal URL characters; no escape processing is
			/// performed. The URL is limited to 2,200 characters, not including the null terminator. Each segment of the URL is limited to
			/// MAX_PATH characters.
			/// </para>
			/// <para>
			/// You can use SMB to express the remote name of the file to download or upload; there is no SMB support for upload-reply jobs.
			/// You can specify the remote name as a UNC path, full path with a network drive, or use the "file://" prefix.
			/// </para>
			/// <para><c>BITS 1.5 and earlier:</c> The SMB protocol for <c>RemoteName</c> is not supported.</para>
			/// </summary>
			public string RemoteName;

			/// <summary>
			/// <para>
			/// Null-terminated string that contains the name of the file on the client. The file name must include the full path (for
			/// example, d:\myapp\updates\file.ext). You cannot use wildcards in the path or file name, and directories in the path must
			/// exist. The path is limited to MAX_PATH, not including the null terminator.
			/// </para>
			/// <para>
			/// The user must have permission to write to the local directory for downloads and the reply portion of an upload-reply job.
			/// BITS does not support NTFS streams. Instead of using network drives, which are session specific, use UNC paths (for example,
			/// \\server\share\path\file). Do not include the \\? prefix in the path.
			/// </para>
			/// </summary>
			public string LocalName;

			/// <summary>Initializes a new instance of the <see cref="BG_FILE_INFO"/> struct.</summary>
			/// <param name="remote">The remote file name.</param>
			/// <param name="local">The local file name.</param>
			public BG_FILE_INFO(string remote, string local) { RemoteName = remote; LocalName = local; }
		}

		/// <summary>The <c>BG_FILE_PROGRESS</c> structure provides file-related progress information, such as the number of bytes transferred.</summary>
		// typedef struct _BG_FILE_PROGRESS { UINT64 BytesTotal; UINT64 BytesTransferred; BOOL Completed;} BG_FILE_PROGRESS; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362801(v=vs.85).aspx
		[PInvokeData("Bits.h", MSDNShortId = "aa362801")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct BG_FILE_PROGRESS
		{
			/// <summary>
			/// <para>
			/// Size of the file in bytes. If BITS cannot determine the size of the file (for example, if the file or server does not exist),
			/// the value is BG_SIZE_UNKNOWN.
			/// </para>
			/// <para>
			/// If you are downloading ranges from a file, <c>BytesTotal</c> reflects the total number of bytes you want to download from the file.
			/// </para>
			/// </summary>
			public ulong BytesTotal;

			/// <summary>Number of bytes transferred.</summary>
			public ulong BytesTransferred;

			/// <summary>
			/// <para>
			/// For downloads, the value is <c>TRUE</c> if the file is available to the user; otherwise, the value is <c>FALSE</c>. Files are
			/// available to the user after calling the <c>IBackgroundCopyJob::Complete</c> method. If the <c>Complete</c> method generates a
			/// transient error, those files processed before the error occurred are available to the user; the others are not. Use the
			/// <c>Completed</c> member to determine if the file is available to the user when <c>Complete</c> fails.
			/// </para>
			/// <para>For uploads, the value is <c>TRUE</c> when the file upload is complete; otherwise, the value is <c>FALSE</c>.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool Completed;
		}

		/// <summary>The <c>BG_FILE_RANGE</c> structure identifies a range of bytes to download from a file.</summary>
		// typedef struct { UINT64 InitialOffset; UINT64 Length;} BG_FILE_RANGE; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362802(v=vs.85).aspx
		[PInvokeData("Bits2_0.h", MSDNShortId = "aa362802")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct BG_FILE_RANGE
		{
			/// <summary>Zero-based offset to the beginning of the range of bytes to download from a file.</summary>
			public ulong InitialOffset;

			/// <summary>
			/// The length of the range, in bytes. Do not specify a zero byte length. To indicate that the range extends to the end of the
			/// file, specify <c>BG_LENGTH_TO_EOF</c>.
			/// </summary>
			public ulong Length;
		}

		/// <summary>
		/// The <c>BG_JOB_PROGRESS</c> structure provides job-related progress information, such as the number of bytes and files
		/// transferred. For upload jobs, the progress applies to the upload file, not the reply file. To view reply file progress, see the
		/// <c>BG_JOB_REPLY_PROGRESS</c> structure.
		/// </summary>
		// typedef struct _BG_JOB_PROGRESS { UINT64 BytesTotal; UINT64 BytesTransferred; ULONG FilesTotal; ULONG FilesTransferred;}
		// BG_JOB_PROGRESS; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362806(v=vs.85).aspx
		[PInvokeData("Bits.h", MSDNShortId = "aa362806")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct BG_JOB_PROGRESS
		{
			/// <summary>
			/// <para>
			/// Total number of bytes to transfer for all files in the job. If the value is BG_SIZE_UNKNOWN, the total size of all files in
			/// the job has not been determined. BITS does not set this value if it cannot determine the size of one of the files. For
			/// example, if the specified file or server does not exist, BITS cannot determine the size of the file.
			/// </para>
			/// <para>
			/// If you are downloading ranges from the file, <c>BytesTotal</c> includes the total number of bytes you want to download from
			/// the file.
			/// </para>
			/// </summary>
			public ulong BytesTotal;

			/// <summary>Number of bytes transferred.</summary>
			public ulong BytesTransferred;

			/// <summary>Total number of files to transfer for this job.</summary>
			public uint FilesTotal;

			/// <summary>Number of files transferred.</summary>
			public uint FilesTransferred;
		}

		/// <summary>
		/// The <c>BG_JOB_REPLY_PROGRESS</c> structure provides progress information related to the reply portion of an upload-reply job.
		/// </summary>
		// typedef struct _BG_JOB_REPLY_PROGRESS { UINT64 BytesTotal; UINT64 BytesTransferred;} BG_JOB_REPLY_PROGRESS; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362808(v=vs.85).aspx
		[PInvokeData("Bits1_5.h", MSDNShortId = "aa362808")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct BG_JOB_REPLY_PROGRESS
		{
			/// <summary>Size of the file in bytes. The value is <c>BG_SIZE_UNKNOWN</c> if the reply has not begun.</summary>
			public ulong BytesTotal;

			/// <summary>Number of bytes transferred.</summary>
			public ulong BytesTransferred;
		}

		/// <summary>The <c>BG_JOB_TIMES</c> structure provides job-related time stamps.</summary>
		// typedef struct _BG_JOB_TIMES { FILETIME CreationTime; FILETIME ModificationTime; FILETIME TransferCompletionTime;} BG_JOB_TIMES; https://msdn.microsoft.com/en-us/library/windows/desktop/aa362810(v=vs.85).aspx
		[PInvokeData("Bits.h", MSDNShortId = "aa362810")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct BG_JOB_TIMES
		{
			/// <summary>Time the job was created. The time is specified as FILETIME.</summary>
			public FILETIME CreationTime;

			/// <summary>
			/// Time the job was last modified or bytes were transferred. Adding files or calling any of the set methods in the
			/// <c>IBackgroundCopyJob*</c> interfaces changes this value. In addition, changes to the state of the job and calling the
			/// <c>Suspend</c>, <c>Resume</c>, <c>Cancel</c>, and <c>Complete</c> methods change this value. The time is specified as FILETIME.
			/// </summary>
			public FILETIME ModificationTime;

			/// <summary>Time the job entered the BG_JOB_STATE_TRANSFERRED state. The time is specified as FILETIME.</summary>
			public FILETIME TransferCompletionTime;
		}

		/// <summary>
		/// The <c>BITS_FILE_PROPERTY_VALUE</c> union provides the property value of the BITS file based on a value from the
		/// <c>BITS_FILE_PROPERTY_ID</c> enumeration.
		/// </summary>
		/// <returns></returns>
		// typedef union { LPWSTR String;} BITS_FILE_PROPERTY_VALUE; https://msdn.microsoft.com/en-us/library/windows/desktop/mt147016(v=vs.85).aspx
		[PInvokeData("Bits5_0.h", MSDNShortId = "mt147016")]
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct BITS_FILE_PROPERTY_VALUE
		{
			/// <summary>This value is used when using the property ID enum value BITS_FILE_PROPERTY_ID_HTTP_RESPONSE_HEADERS.</summary>
			[FieldOffset(0)]
			public string String;
		}

		/// <summary>
		/// The <c>BITS_JOB_PROPERTY_VALUE</c> union provides the property value of the BITS job based on the value of the
		/// <c>BITS_JOB_PROPERTY_ID</c> enumeration.
		/// </summary>
		/// <returns></returns>
		// typedef union { DWORD Dword; GUID ClsID; BOOL Enable; UINT64 Uint64; BG_AUTH_TARGET Target;} BITS_JOB_PROPERTY_VALUE; https://msdn.microsoft.com/en-us/library/windows/desktop/hh446784(v=vs.85).aspx
		[PInvokeData("Bits5_0.h", MSDNShortId = "hh446784")]
		[StructLayout(LayoutKind.Explicit, Pack = 8)]
		public struct BITS_JOB_PROPERTY_VALUE
		{
			/// <summary>
			/// This value is returned when using the enum property ID BITS_JOB_PROPERTY_ID_COST_FLAGS and is applied as the transfer policy
			/// on the BITS job.
			/// <para>
			/// This value is also used when using the BITS_JOB_PROPERTY_MINIMUM_NOTIFICATION_INTERVAL_MS to specify the minimum notification interval.
			/// </para>
			/// </summary>
			[FieldOffset(0)]
			public uint Dword;

			/// <summary>
			/// This value is returned when using the enum property ID BITS_JOB_PROPERTY_NOTIFICATION_CLSID and represents the CLSID of the
			/// callback object to register with the BITS job.
			/// </summary>
			[FieldOffset(0)]
			public Guid ClsID;

			/// <summary>
			/// This value is returned when using the enum property ID BITS_JOB_PROPERTY_DYNAMIC_CONTENT to specify whether the BITS job has
			/// dynamic content. This value is also returned when using the enum property ID BITS_JOB_PROPERTY_HIGH_PERFORMANCE to specify
			/// whether to mark the BITS job as an optimized download.
			/// <para>
			/// This value is also used when using the BITS_JOB_PROPERTY_ON_DEMAND_MODE to specify whether the BITS job is in on demand or not.
			/// </para>
			/// </summary>
			[FieldOffset(0), MarshalAs(UnmanagedType.Bool)]
			public bool Enable;

			/// <summary>
			/// This value is returned when using the enum property ID BITS_JOB_PROPERTY_USE_STORED_CREDENTIALS to represent the intranet
			/// authentication target which is permitted to use stored credentials.
			/// </summary>
			[FieldOffset(0)]
			public BG_AUTH_TARGET Target;

			/// <summary>
			/// This value is returned when using the enum property ID BITS_JOB_PROPERTY_MAX_DOWNLOAD_SIZE to represent the maximum allowed
			/// download size of an optimized download.
			/// </summary>
			[FieldOffset(0)]
			public ulong Uint64;
		}

		/// <summary>Class supporting CLSID_BackgroundCopyManager.</summary>
		[ComImport, ClassInterface(ClassInterfaceType.None), Guid("4991D34B-80A1-4291-83B6-3328366B9097")]
		public class BackgroundCopyManager
		{
		}
	}
}