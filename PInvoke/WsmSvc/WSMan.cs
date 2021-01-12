using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the WsmSvc.dll</summary>
	public static partial class WsmSvc
	{
		/// <summary>Code page option name to be used with WSManCreateShell API to remotely set the code page</summary>
		public const string WSMAN_CMDSHELL_OPTION_CODEPAGE = "WINRS_CODEPAGE";

		/// <summary>
		/// Option name used with WSManRunShellCommand API to indicate that the client side mode of standard input is Console; default
		/// implies Pipe.
		/// </summary>
		public const string WSMAN_CMDSHELL_OPTION_CONSOLEMODE_STDIN = "WINRS_CONSOLEMODE_STDIN";

		/// <summary>To be used with WSManRunShellCommand API to not use cmd.exe /c prefix when launching the command</summary>
		public const string WSMAN_CMDSHELL_OPTION_SKIP_CMD_SHELL = "WINRS_SKIP_CMD_SHELL";

		/// <summary>pre-defined command states</summary>
		public const string WSMAN_COMMAND_STATE_DONE = "/CommandState/Done";

		/// <summary>pre-defined command states</summary>
		public const string WSMAN_COMMAND_STATE_PENDING= "/CommandState/Pending";

		/// <summary>pre-defined command states</summary>
		public const string WSMAN_COMMAND_STATE_RUNNING= "/CommandState/Running";

		/// <summary>Option name used with WSManCreateShell API to not load the user profile on the remote server</summary>
		public const string WSMAN_SHELL_OPTION_NOPROFILE = "WINRS_NOPROFILE";

		/// <summary/>
		public const string WSMAN_STREAM_ID_STDERR = "stderr";
		/// <summary/>
		public const string WSMAN_STREAM_ID_STDIN = "stdin";
		/// <summary/>
		public const string WSMAN_STREAM_ID_STDOUT = "stdout";

		private const string Lib_WsmSvc = "WsmSvc.dll";

		/// <summary>The callback function that is called for shell operations, which result in a remote request.</summary>
		/// <param name="operationContext">
		/// Represents user-defined context passed to the WinRM (WinRM) Client Shell application programming interface (API) .
		/// </param>
		/// <param name="flags">Specifies one or more flags from the WSManCallbackFlags enumeration.</param>
		/// <param name="error"/>
		/// <param name="shell">
		/// Specifies the shell handle associated with the user context. The shell handle must be closed by calling the WSManCloseShell method.
		/// </param>
		/// <param name="command">
		/// Specifies the command handle associated with the user context. The command handle must be closed by calling the
		/// WSManCloseCommand API method.
		/// </param>
		/// <param name="operationHandle">
		/// Defines the operation handle associated with the user context. The operation handle is valid only for callbacks that are
		/// associated with WSManReceiveShellOutput, WSManSendShellInput, and WSManSignalShell calls. This handle must be closed by calling
		/// the WSManCloseOperation method.
		/// </param>
		/// <param name="data"/>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_shell_completion_function WSMAN_SHELL_COMPLETION_FUNCTION
		// WsmanShellCompletionFunction; void WsmanShellCompletionFunction( PVOID operationContext, DWORD flags, WSMAN_ERROR *error,
		// WSMAN_SHELL_HANDLE shell, WSMAN_COMMAND_HANDLE command, WSMAN_OPERATION_HANDLE operationHandle, WSMAN_RESPONSE_DATA *data ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_SHELL_COMPLETION_FUNCTION")]
		public delegate void WSMAN_SHELL_COMPLETION_FUNCTION(IntPtr operationContext, WSManCallbackFlags flags, in WSMAN_ERROR error,
			[In, Optional] WSMAN_SHELL_HANDLE shell, [In, Optional] WSMAN_COMMAND_HANDLE command, [In, Optional] WSMAN_OPERATION_HANDLE operationHandle,
			[In, Optional] IntPtr data);

		/// <summary>Flags for <see cref="WSManInitialize"/>.</summary>
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManInitialize")]
		public enum WSMAN_FLAG_REQUESTED_API_VERSION
		{
			/// <summary/>
			WSMAN_FLAG_REQUESTED_API_VERSION_1_0 = 0x0,

			/// <summary>For clients that will use the disconnect-reconnect functionality.</summary>
			WSMAN_FLAG_REQUESTED_API_VERSION_1_1 = 0x1
		}

		/// <summary>Determines the authentication method for the operation.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ne-wsman-wsmanauthenticationflags typedef enum WSManAuthenticationFlags
		// { WSMAN_FLAG_DEFAULT_AUTHENTICATION, WSMAN_FLAG_NO_AUTHENTICATION, WSMAN_FLAG_AUTH_DIGEST, WSMAN_FLAG_AUTH_NEGOTIATE,
		// WSMAN_FLAG_AUTH_BASIC, WSMAN_FLAG_AUTH_KERBEROS, WSMAN_FLAG_AUTH_CREDSSP, WSMAN_FLAG_AUTH_CLIENT_CERTIFICATE } ;
		[PInvokeData("wsman.h", MSDNShortId = "NE:wsman.WSManAuthenticationFlags")]
		[Flags]
		public enum WSManAuthenticationFlags
		{
			/// <summary>Use the default authentication.</summary>
			WSMAN_FLAG_DEFAULT_AUTHENTICATION = 0x0,

			/// <summary>Use no authentication for a remote operation.</summary>
			WSMAN_FLAG_NO_AUTHENTICATION = 0x1,

			/// <summary>
			/// Use Digest authentication. Only the client computer can initiate a Digest authentication request. The client sends a request
			/// to the server to authenticate and receives from the server a token string. The client then sends the resource request,
			/// including the user name and a cryptographic hash of the password combined with the token string. Digest authentication is
			/// supported for HTTP and HTTPS. WinRM Shell client scripts and applications can specify Digest authentication, but the service cannot.
			/// </summary>
			WSMAN_FLAG_AUTH_DIGEST = 0x2,

			/// <summary>
			/// Use Negotiate authentication. The client sends a request to the server to authenticate. The server determines whether to use
			/// Kerberos or NTLM. In general, Kerberos is selected to authenticate a domain account and NTLM is selected for local computer
			/// accounts. But there are also some special cases in which Kerberos/NTLM are selected. The user name should be specified in
			/// the form DOMAIN\username for a domain user or SERVERNAME\username for a local user on a server computer.
			/// </summary>
			WSMAN_FLAG_AUTH_NEGOTIATE = 0x4,

			/// <summary>
			/// Use Basic authentication. The client presents credentials in the form of a user name and password that are directly
			/// transmitted in the request message. You can specify the credentials only of a local administrator account on the remote computer.
			/// </summary>
			WSMAN_FLAG_AUTH_BASIC = 0x8,

			/// <summary>Use Kerberos authentication. The client and server mutually authenticate by using Kerberos certificates.</summary>
			WSMAN_FLAG_AUTH_KERBEROS = 0x10,

			/// <summary>
			/// Use CredSSP authentication for a remote operation. If a certificate from the local machine is used to authenticate the
			/// server, the Network service must be allowed access to the private key of the certificate.
			/// </summary>
			WSMAN_FLAG_AUTH_CREDSSP = 0x80,

			/// <summary>
			/// Use client certificate authentication. The certificate thumbprint is passed as part of the WSMAN_AUTHENTICATION_CREDENTIALS
			/// structure. The WinRM client will try to find the certificate in the computer store and then, if it is not found, in the
			/// current user store. If no matching certificate is found, an error will be reported to the user.
			/// </summary>
			WSMAN_FLAG_AUTH_CLIENT_CERTIFICATE = 0x20,
		}

		/// <summary>Defines a set of flags used by all callback functions.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ne-wsman-wsmancallbackflags typedef enum WSManCallbackFlags {
		// WSMAN_FLAG_CALLBACK_END_OF_OPERATION, WSMAN_FLAG_CALLBACK_END_OF_STREAM, WSMAN_FLAG_CALLBACK_SHELL_SUPPORTS_DISCONNECT,
		// WSMAN_FLAG_CALLBACK_SHELL_AUTODISCONNECTED, WSMAN_FLAG_CALLBACK_NETWORK_FAILURE_DETECTED,
		// WSMAN_FLAG_CALLBACK_RETRYING_AFTER_NETWORK_FAILURE, WSMAN_FLAG_CALLBACK_RECONNECTED_AFTER_NETWORK_FAILURE,
		// WSMAN_FLAG_CALLBACK_SHELL_AUTODISCONNECTING, WSMAN_FLAG_CALLBACK_RETRY_ABORTED_DUE_TO_INTERNAL_ERROR,
		// WSMAN_FLAG_CALLBACK_RECEIVE_DELAY_STREAM_REQUEST_PROCESSED } ;
		[PInvokeData("wsman.h", MSDNShortId = "NE:wsman.WSManCallbackFlags")]
		[Flags]
		public enum WSManCallbackFlags
		{
			/// <summary>
			/// Indicates the end of a single step of a multi-step operation. This flag is used for optimization purposes if the shell
			/// cannot be determined.
			/// </summary>
			WSMAN_FLAG_CALLBACK_END_OF_OPERATION = 0x1,

			/// <summary>
			/// Indicates the end of a particular stream. This flag is used for optimization purposes if an indication has been provided to
			/// the shell that no more output will occur for this stream.
			/// </summary>
			WSMAN_FLAG_CALLBACK_END_OF_STREAM = 0x8,

			/// <summary>Flag that if present on CreateShell callback indicates that it supports disconnect</summary>
			WSMAN_FLAG_CALLBACK_SHELL_SUPPORTS_DISCONNECT = 0x20,

			/// <summary>Flag that indicates that the shell got disconnected due to netowrk failure</summary>
			WSMAN_FLAG_CALLBACK_SHELL_AUTODISCONNECTED = 0x40,

			/// <summary>Flag indicates that the client shell detected a network failure</summary>
			WSMAN_FLAG_CALLBACK_NETWORK_FAILURE_DETECTED = 0x100,

			/// <summary>Flag indicates that client shell is retrying to establish network connection with the server</summary>
			WSMAN_FLAG_CALLBACK_RETRYING_AFTER_NETWORK_FAILURE = 0x200,

			/// <summary>
			/// Flag indicates that client shell successfully reconnected with the server after attempting to reconnect to the server
			/// </summary>
			WSMAN_FLAG_CALLBACK_RECONNECTED_AFTER_NETWORK_FAILURE = 0x400,

			/// <summary>Flag indicates that the client shell attempts to reconnect to the server failed and hence it is AutoDisconnecting</summary>
			WSMAN_FLAG_CALLBACK_SHELL_AUTODISCONNECTING = 0x800,

			/// <summary>
			/// Flag indicates that the client shell got into broken state in the middle of retry notification sequence due to some internal
			/// error at wsman layer
			/// </summary>
			WSMAN_FLAG_CALLBACK_RETRY_ABORTED_DUE_TO_INTERNAL_ERROR = 0x1000,

			/// <summary>Flag that indicates for a receive operation that a delay stream request has been processed</summary>
			WSMAN_FLAG_CALLBACK_RECEIVE_DELAY_STREAM_REQUEST_PROCESSED = 0x2000,
		}

		/// <summary>Specifies the current data type of the union in the WSMAN_DATA structure.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ne-wsman-wsmandatatype typedef enum WSManDataType { WSMAN_DATA_NONE,
		// WSMAN_DATA_TYPE_TEXT, WSMAN_DATA_TYPE_BINARY, WSMAN_DATA_TYPE_DWORD } ;
		[PInvokeData("wsman.h", MSDNShortId = "NE:wsman.WSManDataType")]
		public enum WSManDataType
		{
			/// <summary>The structure is not valid yet.</summary>
			WSMAN_DATA_NONE = 0,

			/// <summary>The structure contains text.</summary>
			WSMAN_DATA_TYPE_TEXT = 1,

			/// <summary>The structure contains binary data.</summary>
			WSMAN_DATA_TYPE_BINARY = 2,

			/// <summary>The structure contains a DWORD integer.</summary>
			WSMAN_DATA_TYPE_DWORD = 4,
		}

		/// <summary>Defines the proxy access type.</summary>
		/// <remarks>
		/// <para>
		/// The <c>WSMAN_OPTION_PROXY_IE_PROXY_CONFIG</c> option returns the current user Internet Explorer proxy settings for the current
		/// active network connection. This option requires the user profile to be loaded. This option can be directly used when called
		/// within a process that is running under an interactive user account identity. If the client application is running under a user
		/// context that is different than the interactive user, the client application must explicitly load the user profile prior to using
		/// this option.
		/// </para>
		/// <para>
		/// If the Windows Remote Management API is called from a service, <c>WSMAN_OPTION_PROXY_WINHTTP_PROXY_CONFIG</c> or
		/// <c>WSMAN_OPTION_PROXY_AUTO_DETECT</c> should be used if a proxy is required.
		/// </para>
		/// <para>
		/// The <c>WSMAN_OPTION_PROXY_WINHTTP_PROXY_CONFIG</c> option translates into the <c>WINHTTP_ACCESS_TYPE_DEFAULT_PROXY</c> option in
		/// WinHTTP. WinHTTP retrieves the static proxy or direct configuration from the registry. <c>WINHTTP_ACCESS_TYPE_DEFAULT_PROXY</c>
		/// does not inherit browser proxy settings. WinHTTP does not share any proxy settings with Internet Explorer. This option gets the
		/// WinHTTP proxy configuration set by the ProxyCfg.exe utility.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ne-wsman-wsmanproxyaccesstype typedef enum WSManProxyAccessType {
		// WSMAN_OPTION_PROXY_IE_PROXY_CONFIG, WSMAN_OPTION_PROXY_WINHTTP_PROXY_CONFIG, WSMAN_OPTION_PROXY_AUTO_DETECT,
		// WSMAN_OPTION_PROXY_NO_PROXY_SERVER } ;
		[PInvokeData("wsman.h", MSDNShortId = "NE:wsman.WSManProxyAccessType")]
		[Flags]
		public enum WSManProxyAccessType
		{
			/// <summary>Use the Internet Explorer proxy configuration for the current user. This is the default setting.</summary>
			WSMAN_OPTION_PROXY_IE_PROXY_CONFIG = 1,

			/// <summary>Use the proxy settings configured for WinHTTP.</summary>
			WSMAN_OPTION_PROXY_WINHTTP_PROXY_CONFIG = 2,

			/// <summary>Force autodetection of a proxy.</summary>
			WSMAN_OPTION_PROXY_AUTO_DETECT = 4,

			/// <summary>Do not use a proxy server. All host names are resolved locally.</summary>
			WSMAN_OPTION_PROXY_NO_PROXY_SERVER = 8,
		}

		/// <summary>Defines a set of extended options for the session. These options are used with the WSManSetSessionOption method.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ne-wsman-wsmansessionoption typedef enum WSManSessionOption {
		// WSMAN_OPTION_DEFAULT_OPERATION_TIMEOUTMS, WSMAN_OPTION_MAX_RETRY_TIME, WSMAN_OPTION_TIMEOUTMS_CREATE_SHELL,
		// WSMAN_OPTION_TIMEOUTMS_RUN_SHELL_COMMAND, WSMAN_OPTION_TIMEOUTMS_RECEIVE_SHELL_OUTPUT, WSMAN_OPTION_TIMEOUTMS_SEND_SHELL_INPUT,
		// WSMAN_OPTION_TIMEOUTMS_SIGNAL_SHELL, WSMAN_OPTION_TIMEOUTMS_CLOSE_SHELL, WSMAN_OPTION_SKIP_CA_CHECK, WSMAN_OPTION_SKIP_CN_CHECK,
		// WSMAN_OPTION_UNENCRYPTED_MESSAGES, WSMAN_OPTION_UTF16, WSMAN_OPTION_ENABLE_SPN_SERVER_PORT, WSMAN_OPTION_MACHINE_ID,
		// WSMAN_OPTION_LOCALE, WSMAN_OPTION_UI_LANGUAGE, WSMAN_OPTION_MAX_ENVELOPE_SIZE_KB,
		// WSMAN_OPTION_SHELL_MAX_DATA_SIZE_PER_MESSAGE_KB, WSMAN_OPTION_REDIRECT_LOCATION, WSMAN_OPTION_SKIP_REVOCATION_CHECK,
		// WSMAN_OPTION_ALLOW_NEGOTIATE_IMPLICIT_CREDENTIALS, WSMAN_OPTION_USE_SSL, WSMAN_OPTION_USE_INTEARACTIVE_TOKEN } ;
		[PInvokeData("wsman.h", MSDNShortId = "NE:wsman.WSManSessionOption")]
		public enum WSManSessionOption
		{
			/// <summary>Default time-out in milliseconds that applies to all operations on the client side.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_DEFAULT_OPERATION_TIMEOUTMS = 1,

			/// <summary/>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_MAX_RETRY_TIME = 11,

			/// <summary>Time-out in milliseconds for WSManCreateShell operations.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_TIMEOUTMS_CREATE_SHELL,

			/// <summary>Time-out in milliseconds for WSManRunShellCommand operations.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_TIMEOUTMS_RUN_SHELL_COMMAND,

			/// <summary>Time-out in milliseconds for WSManReceiveShellOutput operations.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_TIMEOUTMS_RECEIVE_SHELL_OUTPUT,

			/// <summary>Time-out in milliseconds for WSManSendShellInput operations.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_TIMEOUTMS_SEND_SHELL_INPUT,

			/// <summary>Time-out in milliseconds for WSManSignalShell and WSManCloseCommand operations.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_TIMEOUTMS_SIGNAL_SHELL,

			/// <summary>Time-out in milliseconds for WSManCloseShell operations connection options.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_TIMEOUTMS_CLOSE_SHELL,

			/// <summary>Set to 1 to not validate the CA on the server certificate. The default is 0.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_SKIP_CA_CHECK,

			/// <summary>Set to 1 to not validate the CN on the server certificate. The default is 0.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_SKIP_CN_CHECK,

			/// <summary>Set to 1 to not encrypt messages. The default is 0.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_UNENCRYPTED_MESSAGES,

			/// <summary>
			/// Set to 1 to send all network packets for remote operations in UTF16. Default of 0 causes network packets to be sent in UTF8.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_UTF16,

			/// <summary>Set to 1 when using Negotiate authentication and the port number is included in the connection. Default is 0.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_ENABLE_SPN_SERVER_PORT,

			/// <summary>Set to 1 to identify this machine to the server by including the MachineID. The default is 0.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_MACHINE_ID,

			/// <summary>
			/// The language locale options. For more information about the language locales, see the RFC 3066 specification from the
			/// Internet Engineering Task Force at http://www.ietf.org/rfc/rfc3066.txt.
			/// </summary>
			[CorrespondingType(typeof(string))]
			WSMAN_OPTION_LOCALE = 25,

			/// <summary>
			/// The UI language options. The UI language options are defined in RFC 3066 format. For more information about the UI language
			/// options, see the RFC 3066 specification from the Internet Engineering Task Force at http://www.ietf.org/rfc/rfc3066.txt.
			/// </summary>
			[CorrespondingType(typeof(string))]
			WSMAN_OPTION_UI_LANGUAGE,

			/// <summary>The maximum Simple Object Access Protocol (SOAP) envelope size. The default is 150 KB.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_MAX_ENVELOPE_SIZE_KB = 28,

			/// <summary>The maximum size of the data that is provided by the client.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_SHELL_MAX_DATA_SIZE_PER_MESSAGE_KB,

			/// <summary>The redirect location.</summary>
			[CorrespondingType(typeof(string))]
			WSMAN_OPTION_REDIRECT_LOCATION,

			/// <summary>Set to 1 to not validate the revocation status on the server certificate. The default is 0.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_SKIP_REVOCATION_CHECK,

			/// <summary>Set to 1 to allow default credentials for Negotiate. The default is 0.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_ALLOW_NEGOTIATE_IMPLICIT_CREDENTIALS,

			/// <summary/>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_USE_SSL,

			/// <summary/>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_USE_INTEARACTIVE_TOKEN,
		}

		/// <summary>Deletes a command and frees the resources that are associated with it.</summary>
		/// <param name="commandHandle">Specifies the command handle to be closed. This handle is returned by a WSManRunShellCommand call.</param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanclosecommand void WSManCloseCommand( WSMAN_COMMAND_HANDLE
		// commandHandle, DWORD flags, WSMAN_SHELL_ASYNC *async );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCloseCommand")]
		public static extern void WSManCloseCommand(WSMAN_COMMAND_HANDLE commandHandle, [In, Optional] uint flags, in WSMAN_SHELL_ASYNC async);

		/// <summary>Cancels or closes an asynchronous operation. All resources that are associated with the operation are freed.</summary>
		/// <param name="operationHandle">Specifies the operation handle to be closed.</param>
		/// <param name="flags">Reserved for future use. Set to zero.</param>
		/// <returns>This method returns zero on success. Otherwise, this method returns an error code.</returns>
		/// <remarks>
		/// The method de-allocates local and remote resources associated with the operation. After the <c>WSManCloseOperation</c> method is
		/// called, the operationHandle parameter cannot be passed to any other call. If the callback associated with the operation is
		/// pending and has not completed before <c>WSManCloseOperation</c> is called, the operation is marked for deletion and the method
		/// returns immediately.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmancloseoperation DWORD WSManCloseOperation(
		// WSMAN_OPERATION_HANDLE operationHandle, DWORD flags );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCloseOperation")]
		public static extern Win32Error WSManCloseOperation(WSMAN_OPERATION_HANDLE operationHandle, uint flags = 0);

		/// <summary>Closes a session object.</summary>
		/// <param name="session">
		/// Specifies the session handle to close. This handle is returned by a WSManCreateSession call. This parameter cannot be NULL.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <returns>This method returns zero on success. Otherwise, this method returns an error code.</returns>
		/// <remarks>
		/// The <c>WSManCloseSession</c> method frees the memory associated with a session and closes all related operations before
		/// returning. This is a synchronous call. All operations are explicitly canceled. It is recommended that all pending operations are
		/// either completed or explicitly canceled before calling this function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanclosesession DWORD WSManCloseSession( WSMAN_SESSION_HANDLE
		// session, DWORD flags );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCloseSession")]
		public static extern Win32Error WSManCloseSession(WSMAN_SESSION_HANDLE session, uint flags = 0);

		/// <summary>Deletes a shell object and frees the resources associated with the shell.</summary>
		/// <param name="shellHandle">
		/// Specifies the shell handle to close. This handle is returned by a WSManCreateShell call. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmancloseshell void WSManCloseShell( WSMAN_SHELL_HANDLE
		// shellHandle, DWORD flags, WSMAN_SHELL_ASYNC *async );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCloseShell")]
		public static extern void WSManCloseShell(WSMAN_SHELL_HANDLE shellHandle, [Optional] uint flags, in WSMAN_SHELL_ASYNC async);

		/// <summary>Creates a session object.</summary>
		/// <param name="apiHandle">Specifies the API handle returned by the WSManInitialize call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="connection">
		/// <para>
		/// Indicates to which protocol and agent to connect. If this parameter is <c>NULL</c>, the connection will default to localhost
		/// (127.0.0.1). This parameter can be a simple host name or a complete URL. The format is the following:
		/// </para>
		/// <para>[transport://]host[:port][/prefix] where:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Element</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>transport</term>
		/// <term>Either HTTP or HTTPS. Default is HTTP.</term>
		/// </item>
		/// <item>
		/// <term>host</term>
		/// <term>Can be in a DNS name, NetBIOS name, or IP address.</term>
		/// </item>
		/// <item>
		/// <term>port</term>
		/// <term>Defaults to 80 for HTTP and to 443 for HTTPS. The defaults can be changed in the local configuration.</term>
		/// </item>
		/// <item>
		/// <term>prefix</term>
		/// <term>Any string. Default is "wsman". The default can be changed in the local configuration.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="serverAuthenticationCredentials">
		/// <para>
		/// Defines the authentication method such as Negotiate, Kerberos, Digest, Basic, or client certificate. If the authentication
		/// mechanism is Negotiate, Kerberos, Digest, or Basic, the structure can also contain the credentials used for authentication. If
		/// client certificate authentication is used, the certificate thumbprint must be specified.
		/// </para>
		/// <para>
		/// If credentials are specified, this parameter contains the user name and password of a local account or domain account. If this
		/// parameter is <c>NULL</c>, the default credentials are used. The default credentials are the credentials that the current thread
		/// is executing under. The client must explicitly specify the credentials when Basic or Digest authentication is used. If explicit
		/// credentials are used, both the user name and the password must be valid. For more information about the authentication
		/// credentials, see the WSMAN_AUTHENTICATION_CREDENTIALS structure.
		/// </para>
		/// </param>
		/// <param name="proxyInfo">A pointer to a WSMAN_PROXY_INFO structure that specifies proxy information. This value can be <c>NULL</c>.</param>
		/// <param name="session">
		/// Defines the session handle that uniquely identifies the session. This parameter cannot be <c>NULL</c>. This handle should be
		/// closed by calling the WSManCloseSession method.
		/// </param>
		/// <returns>If the function succeeds, the return value is zero. Otherwise, the return value is an error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmancreatesession DWORD WSManCreateSession( WSMAN_API_HANDLE
		// apiHandle, PCWSTR connection, DWORD flags, WSMAN_AUTHENTICATION_CREDENTIALS *serverAuthenticationCredentials, WSMAN_PROXY_INFO
		// *proxyInfo, WSMAN_SESSION_HANDLE *session );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCreateSession")]
		public static extern uint WSManCreateSession(WSMAN_API_HANDLE apiHandle, [Optional, MarshalAs(UnmanagedType.LPWStr)] string connection,
			[Optional] uint flags, IntPtr serverAuthenticationCredentials, [In, Optional] IntPtr proxyInfo, out SafeWSMAN_SESSION_HANDLE session);

		/// <summary>
		/// Creates a shell object. The returned shell handle identifies an object that defines the context in which commands can be run.
		/// The context is defined by the environment variables, the input and output streams, and the working directory. The context can
		/// directly affect the behavior of a command. A shell context is created on the remote computer specified by the connection
		/// parameter and authenticated by using the credentials parameter.
		/// </summary>
		/// <param name="session">Specifies the session handle returned by a WSManCreateSession call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="resourceUri">
		/// Defines the shell type to create. The shell type is defined by a unique URI. The actual shell object returned by the call is
		/// dependent on the URI specified. This parameter cannot be <c>NULL</c>. To create a Windows cmd.exe shell, use the
		/// <c>WSMAN_CMDSHELL_URI</c> resource URI.
		/// </param>
		/// <param name="startupInfo">
		/// <para>
		/// A pointer to a WSMAN_SHELL_STARTUP_INFO structure that specifies the input and output streams, working directory, idle time-out,
		/// and options for the shell.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, the default values will be used.</para>
		/// </param>
		/// <param name="options">A pointer to a WSMAN_OPTION_SET structure that specifies a set of options for the shell.</param>
		/// <param name="createXml">
		/// A pointer to a WSMAN_DATA structure that defines an open context for the shell. The content should be a valid XML string. This
		/// parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseShell method.
		/// </param>
		/// <param name="shell">
		/// Defines a shell handle that uniquely identifies the shell object. The resource handle is used to track the client endpoint for
		/// the shell and is used by other WinRM methods to interact with the shell object. The shell object should be deleted by calling
		/// the WSManCloseShell method. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmancreateshell void WSManCreateShell( WSMAN_SESSION_HANDLE
		// session, DWORD flags, PCWSTR resourceUri, WSMAN_SHELL_STARTUP_INFO *startupInfo, WSMAN_OPTION_SET *options, WSMAN_DATA
		// *createXml, WSMAN_SHELL_ASYNC *async, WSMAN_SHELL_HANDLE *shell );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCreateShell")]
		public static extern void WSManCreateShell(WSMAN_SESSION_HANDLE session, [Optional] uint flags, [MarshalAs(UnmanagedType.LPWStr)] string resourceUri,
			[In, Optional] IntPtr startupInfo, in WSMAN_OPTION_SET options, in WSMAN_DATA createXml, in WSMAN_SHELL_ASYNC async, out WSMAN_SHELL_HANDLE shell);

		/// <summary>
		/// Creates a shell object. The returned shell handle identifies an object that defines the context in which commands can be run.
		/// The context is defined by the environment variables, the input and output streams, and the working directory. The context can
		/// directly affect the behavior of a command. A shell context is created on the remote computer specified by the connection
		/// parameter and authenticated by using the credentials parameter.
		/// </summary>
		/// <param name="session">Specifies the session handle returned by a WSManCreateSession call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="resourceUri">
		/// Defines the shell type to create. The shell type is defined by a unique URI. The actual shell object returned by the call is
		/// dependent on the URI specified. This parameter cannot be <c>NULL</c>. To create a Windows cmd.exe shell, use the
		/// <c>WSMAN_CMDSHELL_URI</c> resource URI.
		/// </param>
		/// <param name="startupInfo">
		/// <para>
		/// A pointer to a WSMAN_SHELL_STARTUP_INFO structure that specifies the input and output streams, working directory, idle time-out,
		/// and options for the shell.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, the default values will be used.</para>
		/// </param>
		/// <param name="options">A pointer to a WSMAN_OPTION_SET structure that specifies a set of options for the shell.</param>
		/// <param name="createXml">
		/// A pointer to a WSMAN_DATA structure that defines an open context for the shell. The content should be a valid XML string. This
		/// parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseShell method.
		/// </param>
		/// <param name="shell">
		/// Defines a shell handle that uniquely identifies the shell object. The resource handle is used to track the client endpoint for
		/// the shell and is used by other WinRM methods to interact with the shell object. The shell object should be deleted by calling
		/// the WSManCloseShell method. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmancreateshell void WSManCreateShell( WSMAN_SESSION_HANDLE
		// session, DWORD flags, PCWSTR resourceUri, WSMAN_SHELL_STARTUP_INFO *startupInfo, WSMAN_OPTION_SET *options, WSMAN_DATA
		// *createXml, WSMAN_SHELL_ASYNC *async, WSMAN_SHELL_HANDLE *shell );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCreateShell")]
		public static extern void WSManCreateShell(WSMAN_SESSION_HANDLE session, [Optional] uint flags, [MarshalAs(UnmanagedType.LPWStr)] string resourceUri,
			[In, Optional] IntPtr startupInfo, [In, Optional] IntPtr options, [In, Optional] IntPtr createXml, in WSMAN_SHELL_ASYNC async, out WSMAN_SHELL_HANDLE shell);

		/// <summary>
		/// Deinitializes the Windows Remote Management client stack. All operations must be complete before a call to this function will
		/// return. This is a synchronous call. It is recommended that all operations are explicitly canceled and that all sessions are
		/// closed before calling this function.
		/// </summary>
		/// <param name="apiHandle">Specifies the API handle returned by a WSManInitialize call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <returns>This method returns zero on success. Otherwise, this method returns an error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmandeinitialize DWORD WSManDeinitialize( WSMAN_API_HANDLE
		// apiHandle, DWORD flags );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManDeinitialize")]
		public static extern Win32Error WSManDeinitialize(WSMAN_API_HANDLE apiHandle, uint flags = 0);

		/// <summary>
		/// Initializes the Windows Remote Management Client API. <c>WSManInitialize</c> can be used by different clients on the same process.
		/// </summary>
		/// <param name="flags">
		/// A flag of type <c>WSMAN_FLAG_REQUESTED_API_VERSION_1_0</c> or <c>WSMAN_FLAG_REQUESTED_API_VERSION_1_1</c>. The client that will
		/// use the disconnect-reconnect functionality should use the <c>WSMAN_FLAG_REQUESTED_API_VERSION_1_1</c> flag.
		/// </param>
		/// <param name="apiHandle">
		/// Defines a handle that uniquely identifies the client. This parameter cannot be <c>NULL</c>. When you have finished used the
		/// handle, close it by calling the WSManDeinitialize method.
		/// </param>
		/// <returns>This method returns zero on success. Otherwise, this method returns an error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmaninitialize DWORD WSManInitialize( DWORD flags,
		// WSMAN_API_HANDLE *apiHandle );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManInitialize")]
		public static extern Win32Error WSManInitialize(WSMAN_FLAG_REQUESTED_API_VERSION flags, out SafeWSMAN_API_HANDLE apiHandle);

		/// <summary>Retrieves output from a running command or from the shell.</summary>
		/// <param name="shell">Specifies the shell handle returned by a WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="command">Specifies the command handle returned by a WSManRunShellCommand call.</param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="desiredStreamSet">Specifies the requested output from a particular stream or a list of streams.</param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseOperation method.
		/// </param>
		/// <param name="receiveOperation">
		/// Defines the operation handle for the receive operation. This handle is returned from a successful call of the function and can
		/// be used to asynchronously cancel the receive operation. This handle should be closed by calling the WSManCloseOperation method.
		/// This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanreceiveshelloutput void WSManReceiveShellOutput(
		// WSMAN_SHELL_HANDLE shell, WSMAN_COMMAND_HANDLE command, DWORD flags, WSMAN_STREAM_ID_SET *desiredStreamSet, WSMAN_SHELL_ASYNC
		// *async, WSMAN_OPERATION_HANDLE *receiveOperation );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManReceiveShellOutput")]
		public static extern void WSManReceiveShellOutput(WSMAN_SHELL_HANDLE shell, [In, Optional] WSMAN_COMMAND_HANDLE command, [In, Optional] uint flags,
			in WSMAN_STREAM_ID_SET desiredStreamSet, in WSMAN_SHELL_ASYNC async, out SafeWSMAN_OPERATION_HANDLE receiveOperation);

		/// <summary>Retrieves output from a running command or from the shell.</summary>
		/// <param name="shell">Specifies the shell handle returned by a WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="command">Specifies the command handle returned by a WSManRunShellCommand call.</param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="desiredStreamSet">Specifies the requested output from a particular stream or a list of streams.</param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseOperation method.
		/// </param>
		/// <param name="receiveOperation">
		/// Defines the operation handle for the receive operation. This handle is returned from a successful call of the function and can
		/// be used to asynchronously cancel the receive operation. This handle should be closed by calling the WSManCloseOperation method.
		/// This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanreceiveshelloutput void WSManReceiveShellOutput(
		// WSMAN_SHELL_HANDLE shell, WSMAN_COMMAND_HANDLE command, DWORD flags, WSMAN_STREAM_ID_SET *desiredStreamSet, WSMAN_SHELL_ASYNC
		// *async, WSMAN_OPERATION_HANDLE *receiveOperation );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManReceiveShellOutput")]
		public static extern void WSManReceiveShellOutput(WSMAN_SHELL_HANDLE shell, [In, Optional] WSMAN_COMMAND_HANDLE command, [In, Optional] uint flags,
			[In, Optional] IntPtr desiredStreamSet, in WSMAN_SHELL_ASYNC async, out SafeWSMAN_OPERATION_HANDLE receiveOperation);

		/// <summary>Starts the execution of a command within an existing shell and does not wait for the completion of the command.</summary>
		/// <param name="shell">Specifies the shell handle returned by the WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="commandLine">
		/// Defines a required <c>null</c>-terminated string that represents the command to be executed. Typically, the command is specified
		/// without any arguments, which are specified separately. However, a user can specify the command line and all of the arguments by
		/// using this parameter. If arguments are specified for the commandLine parameter, the args parameter should be <c>NULL</c>.
		/// </param>
		/// <param name="args">
		/// A pointer to a WSMAN_COMMAND_ARG_SET structure that defines an array of argument values, which are passed to the command on
		/// creation. If no arguments are required, this parameter should be <c>NULL</c>.
		/// </param>
		/// <param name="options">
		/// Defines a set of options for the command. These options are passed to the service to modify or refine the command execution.
		/// This parameter can be <c>NULL</c>. For more information about the options, see WSMAN_OPTION_SET.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseCommand method.
		/// </param>
		/// <param name="command">
		/// Defines the command object associated with a command within a shell. This handle is returned on a successful call and is used to
		/// send and receive data and to signal the command. This handle should be closed by calling the WSManCloseCommand method. This
		/// parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanrunshellcommand void WSManRunShellCommand(
		// WSMAN_SHELL_HANDLE shell, DWORD flags, PCWSTR commandLine, WSMAN_COMMAND_ARG_SET *args, WSMAN_OPTION_SET *options,
		// WSMAN_SHELL_ASYNC *async, WSMAN_COMMAND_HANDLE *command );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManRunShellCommand")]
		public static extern void WSManRunShellCommand(WSMAN_SHELL_HANDLE shell, [Optional] uint flags, [MarshalAs(UnmanagedType.LPWStr)] string commandLine,
			in WSMAN_COMMAND_ARG_SET args, in WSMAN_OPTION_SET options, in WSMAN_SHELL_ASYNC async, out WSMAN_COMMAND_HANDLE command);

		/// <summary>Starts the execution of a command within an existing shell and does not wait for the completion of the command.</summary>
		/// <param name="shell">Specifies the shell handle returned by the WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="commandLine">
		/// Defines a required <c>null</c>-terminated string that represents the command to be executed. Typically, the command is specified
		/// without any arguments, which are specified separately. However, a user can specify the command line and all of the arguments by
		/// using this parameter. If arguments are specified for the commandLine parameter, the args parameter should be <c>NULL</c>.
		/// </param>
		/// <param name="args">
		/// A pointer to a WSMAN_COMMAND_ARG_SET structure that defines an array of argument values, which are passed to the command on
		/// creation. If no arguments are required, this parameter should be <c>NULL</c>.
		/// </param>
		/// <param name="options">
		/// Defines a set of options for the command. These options are passed to the service to modify or refine the command execution.
		/// This parameter can be <c>NULL</c>. For more information about the options, see WSMAN_OPTION_SET.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseCommand method.
		/// </param>
		/// <param name="command">
		/// Defines the command object associated with a command within a shell. This handle is returned on a successful call and is used to
		/// send and receive data and to signal the command. This handle should be closed by calling the WSManCloseCommand method. This
		/// parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanrunshellcommand void WSManRunShellCommand(
		// WSMAN_SHELL_HANDLE shell, DWORD flags, PCWSTR commandLine, WSMAN_COMMAND_ARG_SET *args, WSMAN_OPTION_SET *options,
		// WSMAN_SHELL_ASYNC *async, WSMAN_COMMAND_HANDLE *command );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManRunShellCommand")]
		public static extern void WSManRunShellCommand(WSMAN_SHELL_HANDLE shell, [Optional] uint flags, [MarshalAs(UnmanagedType.LPWStr)] string commandLine,
			[In, Optional] IntPtr args, [In, Optional] IntPtr options, in WSMAN_SHELL_ASYNC async, out WSMAN_COMMAND_HANDLE command);

		/// <summary>Pipes the input stream to a running command or to the shell.</summary>
		/// <param name="shell">Specifies the shell handle returned by a WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="command">
		/// Specifies the command handle returned by a WSManRunShellCommand call. This handle should be closed by calling the
		/// WSManCloseCommand method.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="streamId">Specifies the input stream ID. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="streamData">
		/// Uses the WSMAN_DATA structure to specify the stream data to be sent to the command or shell. This structure should be allocated
		/// by the calling client and must remain allocated until <c>WSManSendShellInput</c> completes. If the end of the stream has been
		/// reached, the endOfStream parameter should be set to <c>TRUE</c>.
		/// </param>
		/// <param name="endOfStream">
		/// Set to <c>TRUE</c>, if the end of the stream has been reached. Otherwise, this parameter is set to <c>FALSE</c>.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseCommand method.
		/// </param>
		/// <param name="sendOperation">
		/// Defines the operation handle for the send operation. This handle is returned from a successful call of the function and can be
		/// used to asynchronously cancel the send operation. This handle should be closed by calling the WSManCloseOperation method. This
		/// parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmansendshellinput void WSManSendShellInput(
		// WSMAN_SHELL_HANDLE shell, WSMAN_COMMAND_HANDLE command, DWORD flags, PCWSTR streamId, WSMAN_DATA *streamData, BOOL endOfStream,
		// WSMAN_SHELL_ASYNC *async, WSMAN_OPERATION_HANDLE *sendOperation );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManSendShellInput")]
		public static extern void WSManSendShellInput(WSMAN_SHELL_HANDLE shell, [In, Optional] WSMAN_COMMAND_HANDLE command, [In, Optional] uint flags,
			[MarshalAs(UnmanagedType.LPWStr)] string streamId, in WSMAN_DATA streamData, [MarshalAs(UnmanagedType.Bool)] bool endOfStream,
			in WSMAN_SHELL_ASYNC async, out SafeWSMAN_OPERATION_HANDLE sendOperation);

		/// <summary>Sets an extended set of options for the session.</summary>
		/// <param name="session">Specifies the session handle returned by a WSManCreateSession call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="option">
		/// Specifies the option to be set. This parameter must be set to one of the values in the WSManSessionOption enumeration.
		/// </param>
		/// <param name="data">A pointer to a WSMAN_DATA structure that defines the option value.</param>
		/// <returns>This method returns zero on success. Otherwise, this method returns an error code.</returns>
		/// <remarks>
		/// <para>
		/// If the <c>WSManSetSessionOption</c> method is called with different values specified for the option parameter, the order of the
		/// different options is important. The first time <c>WSManSetSessionOption</c> is called, the transport is set for the session. If
		/// a second call requests a different type of transport, the call will fail.
		/// </para>
		/// <para>For example, the second method call will fail if the methods are called in the following order:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <code>WSManSetSessionOption(WSMAN_OPTION_UNENCRYPTED_MESSAGES)</code>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <code>WSManSetSessionOption(WSMAN_OPTION_ALLOW_NEGOTIATE_IMPLICIT_CREDENTIALS)</code>
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The first method call sets the transport to HTTP because the option parameter is set to
		/// <c>WSMAN_OPTION_UNENCRYPTED_MESSAGES</c>. The second call fails because the option that was passed is applicable for HTTPS and
		/// the transport was set to HTTP by the first message.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmansetsessionoption DWORD WSManSetSessionOption(
		// WSMAN_SESSION_HANDLE session, WSManSessionOption option, WSMAN_DATA *data );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManSetSessionOption")]
		public static extern Win32Error WSManSetSessionOption(WSMAN_SESSION_HANDLE session, WSManSessionOption option, in WSMAN_DATA data);

		/// <summary>Provides a handle to a Windows Remote Client unique identifier.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_API_HANDLE : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="WSMAN_API_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public WSMAN_API_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="WSMAN_API_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static WSMAN_API_HANDLE NULL => new WSMAN_API_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="WSMAN_API_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(WSMAN_API_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WSMAN_API_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_API_HANDLE(IntPtr h) => new WSMAN_API_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(WSMAN_API_HANDLE h1, WSMAN_API_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(WSMAN_API_HANDLE h1, WSMAN_API_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is WSMAN_API_HANDLE h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Defines the authentication method and the credentials used for server or proxy authentication.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_authentication_credentials typedef struct
		// _WSMAN_AUTHENTICATION_CREDENTIALS { DWORD authenticationMechanism; union { WSMAN_USERNAME_PASSWORD_CREDS userAccount; PCWSTR
		// certificateThumbprint; }; } WSMAN_AUTHENTICATION_CREDENTIALS;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_AUTHENTICATION_CREDENTIALS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_AUTHENTICATION_CREDENTIALS
		{
			/// <summary>
			/// Defines the authentication mechanism. This member can be set to zero. If it is set to zero, the WinRM client will choose
			/// between Kerberos and Negotiate. If it is not set to zero, this member must be one of the values of the
			/// WSManAuthenticationFlags enumeration.
			/// </summary>
			public WSManAuthenticationFlags authenticationMechanism;

			/// <summary>Defines the credentials used for authentication. See WSMAN_USERNAME_PASSWORD_CREDS for more information.</summary>
			public WSMAN_USERNAME_PASSWORD_CREDS userAccount;

			/// <summary>Defines the certificate thumbprint.</summary>
			public string certificateThumbprint { get => userAccount.username; set => userAccount.username = value; }
		}

		/// <summary>Represents the set of arguments that are passed in to the command line.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_command_arg_set typedef struct _WSMAN_COMMAND_ARG_SET {
		// DWORD argsCount; PCWSTR *args; } WSMAN_COMMAND_ARG_SET;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_COMMAND_ARG_SET")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_COMMAND_ARG_SET
		{
			/// <summary>Specifies the number of arguments in the array.</summary>
			public uint argsCount;

			/// <summary>Defines an array of strings that specify the arguments.</summary>
			public IntPtr args;
		}

		/// <summary>Provides a handle to a remote management command.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_COMMAND_HANDLE : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="WSMAN_COMMAND_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public WSMAN_COMMAND_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="WSMAN_COMMAND_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static WSMAN_COMMAND_HANDLE NULL => new WSMAN_COMMAND_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="WSMAN_COMMAND_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(WSMAN_COMMAND_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WSMAN_COMMAND_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_COMMAND_HANDLE(IntPtr h) => new WSMAN_COMMAND_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(WSMAN_COMMAND_HANDLE h1, WSMAN_COMMAND_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(WSMAN_COMMAND_HANDLE h1, WSMAN_COMMAND_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is WSMAN_COMMAND_HANDLE h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Contains inbound and outbound data used in the Windows Remote Management (WinRM) API.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_data typedef struct _WSMAN_DATA { WSManDataType type;
		// union { WSMAN_DATA_TEXT text; WSMAN_DATA_BINARY binaryData; DWORD number; }; } WSMAN_DATA;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_DATA")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_DATA
		{
			/// <summary>Specifies the type of data currently stored in the union.</summary>
			public WSManDataType type;

			/// <summary/>
			public WSMAN_DATA_UNION union;

			/// <summary/>
			[StructLayout(LayoutKind.Explicit)]
			public struct WSMAN_DATA_UNION
			{
				/// <summary/>
				[FieldOffset(0)]
				public WSMAN_DATA_TEXT text;

				/// <summary/>
				[FieldOffset(0)]
				public WSMAN_DATA_BINARY binaryData;

				/// <summary/>
				[FieldOffset(0)]
				public uint number;
			}
		}

		/// <summary>A WSMAN_DATA structure component that holds binary data for use with various Windows Remote Management functions.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_data_binary typedef struct _WSMAN_DATA_BINARY { DWORD
		// dataLength; BYTE *data; } WSMAN_DATA_BINARY;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_DATA_BINARY")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_DATA_BINARY
		{
			/// <summary>Represents the number of BYTEs stored in the data field.</summary>
			public uint dataLength;

			/// <summary>Specifies the storage location for the binary data.</summary>
			public IntPtr data;
		}

		/// <summary>A WSMAN_DATA structure component that holds textual data for use with various Windows Remote Management functions.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_data_text typedef struct _WSMAN_DATA_TEXT { DWORD
		// bufferLength; PCWSTR buffer; } WSMAN_DATA_TEXT;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_DATA_TEXT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_DATA_TEXT
		{
			/// <summary>Specifies the number of UNICODE characters stored in the buffer.</summary>
			public uint bufferLength;

			/// <summary>Specifies the storage location for the textual data.</summary>
			public StrPtrUni buffer;
		}

		/// <summary>
		/// Defines an individual environment variable by using a name and value pair. This structure is used by the WSManCreateShell
		/// method. The representation of the <c>value</c> variable is shell specific. The client and server must agree on the format of the
		/// <c>value</c> variable.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_environment_variable typedef struct
		// _WSMAN_ENVIRONMENT_VARIABLE { PCWSTR name; PCWSTR value; } WSMAN_ENVIRONMENT_VARIABLE;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_ENVIRONMENT_VARIABLE")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_ENVIRONMENT_VARIABLE
		{
			/// <summary>Defines the environment variable name. This parameter cannot be <c>NULL</c>.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string name;

			/// <summary>Defines the environment variable value. <c>NULL</c> or empty string values are permitted.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string value;
		}

		/// <summary>Defines an array of environment variables.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_environment_variable_set typedef struct
		// _WSMAN_ENVIRONMENT_VARIABLE_SET { DWORD varsCount; WSMAN_ENVIRONMENT_VARIABLE *vars; } WSMAN_ENVIRONMENT_VARIABLE_SET;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_ENVIRONMENT_VARIABLE_SET")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_ENVIRONMENT_VARIABLE_SET
		{
			/// <summary>Specifies the number of environment variables contained within the <c>vars</c> array.</summary>
			public uint varsCount;

			/// <summary>Defines an array of environment variables. Each element of the array is of type WSMAN_ENVIRONMENT_VARIABLE.</summary>
			public IntPtr vars;
		}

		/// <summary>
		/// Contains error information that is returned by a Windows Remote Management (WinRM) client. The WSMAN_ERROR structure is used by
		/// all callbacks to return error information and is valid only for the callback.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_error typedef struct _WSMAN_ERROR { DWORD code; PCWSTR
		// errorDetail; PCWSTR language; PCWSTR machineName; PCWSTR pluginName; } WSMAN_ERROR;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_ERROR")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_ERROR
		{
			/// <summary>
			/// Specifies an error code. This error can be a general error code that is defined in winerror.h or a WinRM-specific error code.
			/// </summary>
			public uint code;

			/// <summary>
			/// Specifies extended error information that relates to a failed call. This field contains the fault detail text if it is
			/// present in the fault. If there is no fault detail, this field contains the fault reason text. This field can be set to <c>NULL</c>.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string errorDetail;

			/// <summary>
			/// Specifies the language for the error description. This field can be set to <c>NULL</c>. For more information about the
			/// language format, see the RFC 3066 specification from the Internet Engineering Task Force at http://www.ietf.org/rfc/rfc3066.txt.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string language;

			/// <summary>Specifies the name of the computer. This field can be set to <c>NULL</c>.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string machineName;

			/// <summary>Specifies the name of the plug-in that generated the error. This field can be set to <c>NULL</c>.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pluginName;
		}

		/// <summary>Provides a handle to a remote management operation.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_OPERATION_HANDLE : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="WSMAN_OPERATION_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public WSMAN_OPERATION_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="WSMAN_OPERATION_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static WSMAN_OPERATION_HANDLE NULL => new WSMAN_OPERATION_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="WSMAN_OPERATION_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(WSMAN_OPERATION_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WSMAN_OPERATION_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_OPERATION_HANDLE(IntPtr h) => new WSMAN_OPERATION_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(WSMAN_OPERATION_HANDLE h1, WSMAN_OPERATION_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(WSMAN_OPERATION_HANDLE h1, WSMAN_OPERATION_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is WSMAN_OPERATION_HANDLE h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// Represents a specific option name and value pair. An option that is not understood and has a <c>mustComply</c> value of
		/// <c>TRUE</c> should result in the plug-in operation failing the request with an error.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_option typedef struct _WSMAN_OPTION { PCWSTR name; PCWSTR
		// value; BOOL mustComply; } WSMAN_OPTION;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_OPTION")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_OPTION
		{
			/// <summary>Specifies the name of the option.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string name;

			/// <summary>Specifies the value of the option.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string value;

			/// <summary>
			/// Specifies whether the option must be understood and complied with. If this value is <c>TRUE</c>, the plug-in must understand
			/// and adhere to the meaning of the option; otherwise, the plug-in must return an error. If this is <c>FALSE</c>, the plug-in
			/// should ignore the option if it is not understood.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool mustComply;
		}

		/// <summary>
		/// Represents a set of options. Additionally, this structure defines a flag that specifies whether all options must be understood.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_option_set typedef struct _WSMAN_OPTION_SET { DWORD
		// optionsCount; WSMAN_OPTION *options; BOOL optionsMustUnderstand; } WSMAN_OPTION_SET;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_OPTION_SET")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_OPTION_SET
		{
			/// <summary>Specifies the number of options in the <c>options</c> array.</summary>
			public uint optionsCount;

			/// <summary>Specifies an array of option names and values</summary>
			public IntPtr options;

			/// <summary>If this member is <c>TRUE</c>, the plug-in must return an error if any of the options are not understood.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool optionsMustUnderstand;
		}

		/// <summary>Specifies proxy information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_proxy_info typedef struct _WSMAN_PROXY_INFO { DWORD
		// accessType; WSMAN_AUTHENTICATION_CREDENTIALS authenticationCredentials; } WSMAN_PROXY_INFO;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_PROXY_INFO")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_PROXY_INFO
		{
			/// <summary>
			/// Specifies the access type for the proxy. This member must be set to one of the values defined in the WSManProxyAccessType enumeration.
			/// </summary>
			public WSManProxyAccessType accessType;

			/// <summary>
			/// A WSMAN_AUTHENTICATION_CREDENTIALS structure that specifies the credentials and authentication scheme used for proxy access.
			/// </summary>
			public WSMAN_AUTHENTICATION_CREDENTIALS authenticationCredentials;
		}

		/// <summary>Represents the output data received from a WSManReceiveShellOutput method.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_receive_data_result typedef struct
		// _WSMAN_RECEIVE_DATA_RESULT { PCWSTR streamId; WSMAN_DATA streamData; PCWSTR commandState; DWORD exitCode; } WSMAN_RECEIVE_DATA_RESULT;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_RECEIVE_DATA_RESULT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_RECEIVE_DATA_RESULT
		{
			/// <summary>Represents the <c>streamId</c> for which <c>streamData</c> is defined.</summary>
			public StrPtrUni streamId;

			/// <summary>
			/// Represents the data associated with <c>streamId</c>. The data can be stream text, binary content, or XML. For more
			/// information about the possible data, see WSMAN_DATA.
			/// </summary>
			public WSMAN_DATA streamData;

			/// <summary>
			/// Specifies the status of the command. If this member is set to <c>WSMAN_COMMAND_STATE_DONE</c>, the command should be
			/// immediately closed.
			/// </summary>
			public StrPtrUni commandState;

			/// <summary>
			/// Defines the exit code of the command. This value is relevant only if the <c>commandState</c> member is set to <c>WSMAN_COMMAND_STATE_DONE</c>.
			/// </summary>
			public uint exitCode;
		}

		/// <summary>Represents the output data received from a WSMan operation.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_response_data typedef union _WSMAN_RESPONSE_DATA {
		// WSMAN_RECEIVE_DATA_RESULT receiveData; WSMAN_CONNECT_DATA connectData; WSMAN_CREATE_SHELL_DATA createData; } WSMAN_RESPONSE_DATA;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_RESPONSE_DATA")]
		[StructLayout(LayoutKind.Explicit)]
		public struct WSMAN_RESPONSE_DATA
		{
			/// <summary>Represents the output data received from a WSManReceiveShellOutput method.</summary>
			[FieldOffset(0)]
			public WSMAN_RECEIVE_DATA_RESULT receiveData;

			/// <summary>Represents the output data received from a WSManConnectShell or WSManConnectShellCommand method.</summary>
			[FieldOffset(0)]
			public WSMAN_DATA connectData;

			/// <summary/>
			[FieldOffset(0)]
			public WSMAN_DATA createData;
		}

		/// <summary>Provides a handle to a remote managment session.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_SESSION_HANDLE : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="WSMAN_SESSION_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public WSMAN_SESSION_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="WSMAN_SESSION_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static WSMAN_SESSION_HANDLE NULL => new WSMAN_SESSION_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="WSMAN_SESSION_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(WSMAN_SESSION_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WSMAN_SESSION_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_SESSION_HANDLE(IntPtr h) => new WSMAN_SESSION_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(WSMAN_SESSION_HANDLE h1, WSMAN_SESSION_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(WSMAN_SESSION_HANDLE h1, WSMAN_SESSION_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is WSMAN_SESSION_HANDLE h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// Defines an asynchronous structure to be passed to all shell operations. It contains an optional user context and the callback function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_shell_async typedef struct _WSMAN_SHELL_ASYNC { PVOID
		// operationContext; WSMAN_SHELL_COMPLETION_FUNCTION completionFunction; } WSMAN_SHELL_ASYNC;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_SHELL_ASYNC")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_SHELL_ASYNC
		{
			/// <summary>Specifies the optional user context associated with the operation.</summary>
			public IntPtr operationContext;

			/// <summary>Specifies the WSMAN_SHELL_COMPLETION_FUNCTION callback function for the operation.</summary>
			public WSMAN_SHELL_COMPLETION_FUNCTION completionFunction;
		}

		/// <summary>Provides a handle to a remote management shell.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_SHELL_HANDLE : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="WSMAN_SHELL_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public WSMAN_SHELL_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="WSMAN_SHELL_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static WSMAN_SHELL_HANDLE NULL => new WSMAN_SHELL_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="WSMAN_SHELL_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(WSMAN_SHELL_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WSMAN_SHELL_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_SHELL_HANDLE(IntPtr h) => new WSMAN_SHELL_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(WSMAN_SHELL_HANDLE h1, WSMAN_SHELL_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(WSMAN_SHELL_HANDLE h1, WSMAN_SHELL_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is WSMAN_SHELL_HANDLE h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// <para>
		/// Defines the shell startup parameters to be used with the WSManCreateShell function. The structure must be allocated by the
		/// client and passed to the <c>WSManCreateShell</c> function.
		/// </para>
		/// <para>
		/// The configuration passed to the WSManCreateShell function can directly affect the behavior of a command executed within the
		/// shell. A typical example is the workingDirectory argument that describes the working directory associated with each process,
		/// which the operating system uses when attempting to locate files specified by using a relative path.
		/// </para>
		/// <para>
		/// In the absence of specific requirements for stream naming, clients and services should attempt to use <c>STDIN</c> for input
		/// streams, <c>STDOUT</c> for the default output stream, and <c>STDERR</c> for the error or status output stream.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_shell_startup_info_v10 typedef struct
		// _WSMAN_SHELL_STARTUP_INFO_V10 { WSMAN_STREAM_ID_SET *inputStreamSet; WSMAN_STREAM_ID_SET *outputStreamSet; DWORD idleTimeoutMs;
		// PCWSTR workingDirectory; WSMAN_ENVIRONMENT_VARIABLE_SET *variableSet; } WSMAN_SHELL_STARTUP_INFO_V10;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_SHELL_STARTUP_INFO_V10")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_SHELL_STARTUP_INFO_V10
		{
			/// <summary>
			/// A pointer to a WSMAN_STREAM_ID_SET structure that specifies a set of input streams for the shell. Streams not present in the
			/// filter can be ignored by the shell implementation. For the Windows Cmd.exe shell, this value should be L"stdin". If the
			/// value is <c>NULL</c>, the implementation uses an array with L"stdin" as the default value.
			/// </summary>
			public IntPtr inputStreamSet;

			/// <summary>
			/// A pointer to a WSMAN_STREAM_ID_SET structure that specifies a set of output streams for the shell. Streams not present in
			/// the filter can be ignored by the shell implementation. For the Windows cmd.exe shell, this value should be L"stdout stderr".
			/// If the value is <c>NULL</c>, the implementation uses an array with L"stdout" and L"stderr" as the default value.
			/// </summary>
			public IntPtr outputStreamSet;

			/// <summary>
			/// Specifies the maximum duration, in milliseconds, the shell will stay open without any client request. When the maximum
			/// duration is exceeded, the shell is automatically deleted. Any value from 0 to 0xFFFFFFFF can be set. This duration has a
			/// maximum value specified by the Idle time-out GPO setting, if enabled, or by the IdleTimeout local configuration. The default
			/// value of the maximum duration in the GPO/local configuration is 15 minutes. However, a system administrator can change this
			/// value. To use the maximum value from the GPO/local configuration, the client should specify 0 (zero) in this field. If an
			/// explicit value between 0 to 0xFFFFFFFF is used, the minimum value between the explicit API value and the value from the
			/// GPO/local configuration is used.
			/// </summary>
			public uint idleTimeoutMs;

			/// <summary>
			/// Specifies the starting directory for a shell. It is used with any execution command. If this member is a <c>NULL</c> value,
			/// a default directory will be used by the remote machine when executing the command. An empty value is treated by the
			/// underlying protocol as an omitted value.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string workingDirectory;

			/// <summary>
			/// A pointer to a WSMAN_ENVIRONMENT_VARIABLE_SET structure that specifies an array of variable name and value pairs, which
			/// describe the starting environment for the shell. The content of these elements is shell specific and can be defined in terms
			/// of other environment variables. If a <c>NULL</c> value is passed, the default environment is used on the server side.
			/// </summary>
			public IntPtr variableSet;
		}

		/// <summary>
		/// <para>
		/// Defines the shell startup parameters to be used with the WSManCreateShell function. The structure must be allocated by the
		/// client and passed to the <c>WSManCreateShell</c> function.
		/// </para>
		/// <para>
		/// The configuration passed to the WSManCreateShell function can directly affect the behavior of a command executed within the
		/// shell. A typical example is the workingDirectory argument that describes the working directory associated with each process,
		/// which the operating system uses when attempting to locate files specified by using a relative path.
		/// </para>
		/// <para>
		/// In the absence of specific requirements for stream naming, clients and services should attempt to use <c>STDIN</c> for input
		/// streams, <c>STDOUT</c> for the default output stream, and <c>STDERR</c> for the error or status output stream.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_shell_startup_info_v11 typedef struct
		// _WSMAN_SHELL_STARTUP_INFO_V11 : _WSMAN_SHELL_STARTUP_INFO_V10 { PCWSTR name; } WSMAN_SHELL_STARTUP_INFO_V11;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_SHELL_STARTUP_INFO_V11")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_SHELL_STARTUP_INFO_V11
		{
			/// <summary>
			/// A pointer to a WSMAN_STREAM_ID_SET structure that specifies a set of input streams for the shell. Streams not present in the
			/// filter can be ignored by the shell implementation. For the Windows Cmd.exe shell, this value should be L"stdin". If the
			/// value is <c>NULL</c>, the implementation uses an array with L"stdin" as the default value.
			/// </summary>
			public IntPtr inputStreamSet;

			/// <summary>
			/// A pointer to a WSMAN_STREAM_ID_SET structure that specifies a set of output streams for the shell. Streams not present in
			/// the filter can be ignored by the shell implementation. For the Windows cmd.exe shell, this value should be L"stdout stderr".
			/// If the value is <c>NULL</c>, the implementation uses an array with L"stdout" and L"stderr" as the default value.
			/// </summary>
			public IntPtr outputStreamSet;

			/// <summary>
			/// Specifies the maximum duration, in milliseconds, the shell will stay open without any client request. When the maximum
			/// duration is exceeded, the shell is automatically deleted. Any value from 0 to 0xFFFFFFFF can be set. This duration has a
			/// maximum value specified by the Idle time-out GPO setting, if enabled, or by the IdleTimeout local configuration. The default
			/// value of the maximum duration in the GPO/local configuration is 15 minutes. However, a system administrator can change this
			/// value. To use the maximum value from the GPO/local configuration, the client should specify 0 (zero) in this field. If an
			/// explicit value between 0 to 0xFFFFFFFF is used, the minimum value between the explicit API value and the value from the
			/// GPO/local configuration is used.
			/// </summary>
			public uint idleTimeoutMs;

			/// <summary>
			/// Specifies the starting directory for a shell. It is used with any execution command. If this member is a <c>NULL</c> value,
			/// a default directory will be used by the remote machine when executing the command. An empty value is treated by the
			/// underlying protocol as an omitted value.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string workingDirectory;

			/// <summary>
			/// A pointer to a WSMAN_ENVIRONMENT_VARIABLE_SET structure that specifies an array of variable name and value pairs, which
			/// describe the starting environment for the shell. The content of these elements is shell specific and can be defined in terms
			/// of other environment variables. If a <c>NULL</c> value is passed, the default environment is used on the server side.
			/// </summary>
			public IntPtr variableSet;

			/// <summary>
			/// Specifies an optional friendly name to be associated with the shell. This parameter is only functional when the client
			/// passes the flag <c>WSMAN_FLAG_REQUESTED_API_VERSION_1_1</c> to WSManInitialize.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string name;
		}

		/// <summary>Lists all the streams that are used for either input or output for the shell and commands.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_stream_id_set typedef struct _WSMAN_STREAM_ID_SET { DWORD
		// streamIDsCount; PCWSTR *streamIDs; } WSMAN_STREAM_ID_SET;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_STREAM_ID_SET")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_STREAM_ID_SET
		{
			/// <summary>Defines the number of stream IDs in <c>streamIDs</c>.</summary>
			public uint streamIDsCount;

			/// <summary>Specifies an array of stream IDs.</summary>
			public IntPtr streamIDs;
		}

		/// <summary>Defines the credentials used for authentication.</summary>
		/// <remarks>
		/// <para>
		/// The client can specify the credentials to use when creating a shell on a computer. The user name should be specified in the form
		/// DOMAIN\username for a domain account or SERVERNAME\username for a local account on a server computer.
		/// </para>
		/// <para>
		/// If this structure is used, it should have both the user name and password fields specified. It can be used with Basic, Digest,
		/// Negotiate, or Kerberos authentication. The client must explicitly specify the credentials when either Basic or Digest
		/// authentication is used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_username_password_creds typedef struct
		// _WSMAN_USERNAME_PASSWORD_CREDS { PCWSTR username; PCWSTR password; } WSMAN_USERNAME_PASSWORD_CREDS;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_USERNAME_PASSWORD_CREDS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_USERNAME_PASSWORD_CREDS
		{
			/// <summary>Defines the user name for a local or domain account. It cannot be <c>NULL</c>.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string username;

			/// <summary>Defines the password for a local or domain account. It cannot be <c>NULL</c>.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string password;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="WSMAN_API_HANDLE"/> that is disposed using <see cref="WSManDeinitialize"/>.</summary>
		public class SafeWSMAN_API_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeWSMAN_API_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeWSMAN_API_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeWSMAN_API_HANDLE"/> class.</summary>
			private SafeWSMAN_API_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeWSMAN_API_HANDLE"/> to <see cref="WSMAN_API_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_API_HANDLE(SafeWSMAN_API_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => WSManDeinitialize(handle).Succeeded;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="WSMAN_OPERATION_HANDLE"/> that is disposed using <see cref="WSManCloseOperation"/>.</summary>
		public class SafeWSMAN_OPERATION_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeWSMAN_OPERATION_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeWSMAN_OPERATION_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeWSMAN_OPERATION_HANDLE"/> class.</summary>
			private SafeWSMAN_OPERATION_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeWSMAN_OPERATION_HANDLE"/> to <see cref="WSMAN_OPERATION_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_OPERATION_HANDLE(SafeWSMAN_OPERATION_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => WSManCloseOperation(handle).Succeeded;
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> for <see cref="WSMAN_SESSION_HANDLE"/> that is disposed using <see
		/// cref="WSManCloseSession(WSMAN_SESSION_HANDLE, uint)"/>.
		/// </summary>
		public class SafeWSMAN_SESSION_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeWSMAN_SESSION_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeWSMAN_SESSION_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeWSMAN_SESSION_HANDLE"/> class.</summary>
			private SafeWSMAN_SESSION_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeWSMAN_SESSION_HANDLE"/> to <see cref="WSMAN_SESSION_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_SESSION_HANDLE(SafeWSMAN_SESSION_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => WSManCloseSession(handle).Succeeded;
		}

		/*
		Structures
		WSMAN_AUTHZ_QUOTA
		WSMAN_CERTIFICATE_DETAILS
		WSMAN_FILTER
		WSMAN_FRAGMENT
		WSMAN_KEY
		WSMAN_OPERATION_INFO
		WSMAN_PLUGIN_REQUEST
		WSMAN_SELECTOR_SET
		WSMAN_SENDER_DETAILS
		WSMAN_SHELL_DISCONNECT_INFO

		Callback functions
		WSMAN_PLUGIN_AUTHORIZE_OPERATION
		WSMAN_PLUGIN_AUTHORIZE_QUERY_QUOTA
		WSMAN_PLUGIN_AUTHORIZE_RELEASE_CONTEXT
		WSMAN_PLUGIN_AUTHORIZE_USER
		WSMAN_PLUGIN_COMMAND
		WSMAN_PLUGIN_CONNECT
		WSMAN_PLUGIN_RECEIVE
		WSMAN_PLUGIN_RELEASE_COMMAND_CONTEXT
		WSMAN_PLUGIN_RELEASE_SHELL_CONTEXT
		WSMAN_PLUGIN_SEND
		WSMAN_PLUGIN_SHELL
		WSMAN_PLUGIN_SHUTDOWN
		WSMAN_PLUGIN_SIGNAL

		Functions
		WSManConnectShell
		WSManConnectShellCommand
		WSManCreateShellEx
		WSManDisconnectShell
		WSManGetErrorMessage
		WSManGetSessionOptionAsDword
		WSManGetSessionOptionAsString
		WSManPluginAuthzOperationComplete
		WSManPluginAuthzQueryQuotaComplete
		WSManPluginAuthzUserComplete
		WSManPluginFreeRequestDetails
		WSManPluginGetOperationParameters
		WSManPluginOperationComplete
		WSManPluginReceiveResult
		WSManPluginReportContext
		WSManReconnectShell
		WSManReconnectShellCommand
		WSManRunShellCommandEx
		WSManSignalShell
		WSMAN_PLUGIN_STARTUP
		*/
	}
}