namespace Vanara.PInvoke;

/// <summary>Items from the Rpc.dll</summary>
public static partial class Rpc
{
	/// <summary>Specifies that a client waits an indefinite amount of time.</summary>
	public const int RPC_C_CANCEL_INFINITE_TIMEOUT = -1;

	/// <summary>Max calls value.</summary>
	public const uint RPC_C_LISTEN_MAX_CALLS_DEFAULT = 1234;

	/// <summary>Max length value.</summary>
	public const uint RPC_C_PROTSEQ_MAX_REQS_DEFAULT = 10;

	private const string Lib_rpcrt4 = "rpcrt4.dll";

	/// <summary>
	/// The RPC library uses the binding time-out constants to specify the relative amount of time that should be spent to establish a
	/// binding to the server before giving up. The timeout can be enabled with a call to the <c>RpcMgmtSetComTimeout</c> function. The
	/// following list contains the valid time-out values.
	/// </summary>
	/// <remarks>
	/// The values in the preceding table are not in seconds. These values represent a relative amount of time on a scale of zero to 10.
	/// For more information on avoiding communication delays, refer to Preventing Client-side Hangs.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/rpc/binding-time-out-constants
	[PInvokeData("rpcdce.h")]
	public enum RCP_C_BINDING_TIMEOUT : uint
	{
		/// <summary>Keeps trying to establish communications forever.</summary>
		RPC_C_BINDING_INFINITE_TIMEOUT = 10,

		/// <summary>
		/// Tries the minimum amount of time for the network protocol being used. This value favors response time over correctness in
		/// determining whether the server is running.
		/// </summary>
		RPC_C_BINDING_MIN_TIMEOUT = 0,

		/// <summary>
		/// Tries an average amount of time for the network protocol being used. This value gives correctness in determining whether a
		/// server is running and gives response time equal weight. This is the default value.
		/// </summary>
		RPC_C_BINDING_DEFAULT_TIMEOUT = 5,

		/// <summary>
		/// Tries the longest amount of time for the network protocol being used. This value favors correctness in determining whether a
		/// server is running over response time.
		/// </summary>
		RPC_C_BINDING_MAX_TIMEOUT = 9,
	}

	/// <summary>A set of flags describing specific RPC behaviors.</summary>
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_BINDING_HANDLE_OPTIONS_V1")]
	[Flags]
	public enum RPC_BHO : uint
	{
		/// <summary>Specifies causal ordering whereby calls are executed independently of one another rather than in order of submission.</summary>
		RPC_BHO_NONCAUSAL = 0x1,

		/// <summary>Specifies that a socket association must be shutdown after the last binding handle on it is freed.</summary>
		RPC_BHO_DONTLINGER = 0x2,

		/// <summary/>
		RPC_BHO_EXCLUSIVE_AND_GUARANTEED = 0x4,
	}

	/// <summary>
	/// The authentication-level constants represent authentication levels passed to various run-time functions. These levels are listed
	/// in order of increasing authentication. Each new level adds to the authentication provided by the previous level. If the RPC
	/// run-time library does not support the specified level, it automatically upgrades to the next higher supported level.
	/// </summary>
	/// <remarks>Regardless of the value specified by the constant, <c>ncalrpc</c> always uses RPC_C_AUTHN_LEVEL_PKT_PRIVACY.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/rpc/authentication-level-constants
	[PInvokeData("rpcdce.h")]
	public enum RPC_C_AUTHN : uint
	{
		/// <summary>No authentication.</summary>
		RPC_C_AUTHN_NONE = 0,

		/// <summary>Use Distributed Computing Environment (DCE) private key authentication.</summary>
		RPC_C_AUTHN_DCE_PRIVATE = 1,

		/// <summary>DCE public key authentication (reserved for future use).</summary>
		RPC_C_AUTHN_DCE_PUBLIC = 2,

		/// <summary>DEC public key authentication (reserved for future use).</summary>
		RPC_C_AUTHN_DEC_PUBLIC = 4,

		/// <summary>
		/// Use the Microsoft Negotiate SSP. This SSP negotiates between the use of the NTLM and Kerberos protocol Security Support
		/// Providers (SSP).
		/// </summary>
		RPC_C_AUTHN_GSS_NEGOTIATE = 9,

		/// <summary>Use the Microsoft NT LAN Manager (NTLM) SSP.</summary>
		RPC_C_AUTHN_WINNT = 10,

		/// <summary>
		/// Use the Schannel SSP. This SSP supports Secure Socket Layer (SSL), private communication technology (PCT), and transport
		/// level security (TLS).
		/// </summary>
		RPC_C_AUTHN_GSS_SCHANNEL = 14,

		/// <summary>Use the Microsoft Kerberos SSP.</summary>
		RPC_C_AUTHN_GSS_KERBEROS = 16,

		/// <summary>Use Distributed Password Authentication (DPA).</summary>
		RPC_C_AUTHN_DPA = 17,

		/// <summary>Authentication protocol SSP used for the Microsoft Network (MSN).</summary>
		RPC_C_AUTHN_MSN = 18,

		/// <summary>Windows XP or later: Use the Microsoft Digest SSP</summary>
		RPC_C_AUTHN_DIGEST = 21,

		/// <summary>Windows 7 or later: Reserved. Do not use</summary>
		RPC_C_AUTHN_NEGO_EXTENDER = 30,

		/// <summary>This SSP provides an SSPI-compatible wrapper for the Microsoft Message Queue (MSMQ) transport-level protocol.</summary>
		RPC_C_AUTHN_MQ = 100,

		/// <summary>Use the default authentication service.</summary>
		RPC_C_AUTHN_DEFAULT = 0xffffffff,

		/// <summary/>
		RPC_C_AUTHN_KERNEL = 20,

		/// <summary/>
		RPC_C_AUTHN_PKU2U = 31,

		/// <summary/>
		RPC_C_AUTHN_LIVE_SSP = 32,

		/// <summary/>
		RPC_C_AUTHN_LIVEXP_SSP = 35,

		/// <summary/>
		RPC_C_AUTHN_CLOUD_AP = 36,

		/// <summary/>
		RPC_C_AUTHN_MSONLINE = 82,
	}

	/// <summary>Specifies the type of additional credentials present in the <c>u</c> union.</summary>
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_SECURITY_QOS_V2_A")]
	public enum RPC_C_AUTHN_INFO_TYPE
	{
		/// <summary>No additional credentials are passed in the u union.</summary>
		RPC_C_AUTHN_INFO_TYPE_NONE,

		/// <summary>
		/// The HttpCredentials member of the u union points to a RPC_HTTP_TRANSPORT_CREDENTIALS structure. This value can be used only
		/// when the protocol sequence is ncacn_http. Any other protocol sequence returns RPC_S_INVALID_ARG.
		/// </summary>
		[CorrespondingType(typeof(RPC_HTTP_TRANSPORT_CREDENTIALS))]
		RPC_C_AUTHN_INFO_TYPE_HTTP,
	}

	/// <summary>
	/// The authentication-level constants represent authentication levels passed to various run-time functions. These levels are listed
	/// in order of increasing authentication. Each new level adds to the authentication provided by the previous level. If the RPC
	/// run-time library does not support the specified level, it automatically upgrades to the next higher supported level.
	/// </summary>
	/// <remarks>Regardless of the value specified by the constant, <c>ncalrpc</c> always uses RPC_C_AUTHN_LEVEL_PKT_PRIVACY.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/rpc/authentication-level-constants
	[PInvokeData("rpcdce.h")]
	public enum RPC_C_AUTHN_LEVEL
	{
		/// <summary>Uses the default authentication level for the specified authentication service.</summary>
		RPC_C_AUTHN_LEVEL_DEFAULT = 0,

		/// <summary>Performs no authentication.</summary>
		RPC_C_AUTHN_LEVEL_NONE = 1,

		/// <summary>Authenticates only when the client establishes a relationship with a server.</summary>
		RPC_C_AUTHN_LEVEL_CONNECT = 2,

		/// <summary>
		/// Authenticates only at the beginning of each remote procedure call when the server receives the request. Does not apply to
		/// remote procedure calls made using the connection-based protocol sequences (those that start with the prefix "ncacn"). If the
		/// protocol sequence in a binding handle is a connection-based protocol sequence and you specify this level, this routine
		/// instead uses the RPC_C_AUTHN_LEVEL_PKT constant.
		/// </summary>
		RPC_C_AUTHN_LEVEL_CALL = 3,

		/// <summary>Authenticates only that all data received is from the expected client. Does not validate the data itself.</summary>
		RPC_C_AUTHN_LEVEL_PKT = 4,

		/// <summary>Authenticates and verifies that none of the data transferred between client and server has been modified.</summary>
		RPC_C_AUTHN_LEVEL_PKT_INTEGRITY = 5,

		/// <summary>
		/// Includes all previous levels, and ensures clear text data can only be seen by the sender and the receiver. In the local
		/// case, this involves using a secure channel. In the remote case, this involves encrypting the argument value of each remote
		/// procedure call.
		/// </summary>
		RPC_C_AUTHN_LEVEL_PKT_PRIVACY = 6,
	}

	/// <summary>
	/// <para>The authorization service constants represent the authorization services passed to various run-time functions.</para>
	/// <para>Most applications find RPC_C_AUTHZ_NON sufficient.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/rpc/authorization-service-constants
	[PInvokeData("rpcdce.h")]
	public enum RPC_C_AUTHZ : uint
	{
		/// <summary>Server performs no authorization.</summary>
		RPC_C_AUTHZ_NONE = 0,

		/// <summary>Server performs authorization based on the client's principal name.</summary>
		RPC_C_AUTHZ_NAME = 1,

		/// <summary>
		/// Server performs authorization checking using the client's DCE privilege attribute certificate (PAC) information, which is
		/// sent to the server with each remote procedure call made using the binding handle. Generally, access is checked against DCE
		/// access control lists (ACLs).
		/// </summary>
		RPC_C_AUTHZ_DCE = 2,

		/// <summary>Server uses the default authorization service for the current SSP.</summary>
		RPC_C_AUTHZ_DEFAULT = 0xffffffff,
	}

	/// <summary>RPC authentication schemes.</summary>
	[PInvokeData("rpcdce.h")]
	[Flags]
	public enum RPC_C_HTTP_AUTHN_SCHEME : uint
	{
		/// <summary/>
		RPC_C_HTTP_AUTHN_SCHEME_BASIC = 0x00000001,

		/// <summary/>
		RPC_C_HTTP_AUTHN_SCHEME_NTLM = 0x00000002,

		/// <summary/>
		RPC_C_HTTP_AUTHN_SCHEME_PASSPORT = 0x00000004,

		/// <summary/>
		RPC_C_HTTP_AUTHN_SCHEME_DIGEST = 0x00000008,

		/// <summary/>
		RPC_C_HTTP_AUTHN_SCHEME_NEGOTIATE = 0x00000010,

		/// <summary/>
		RPC_C_HTTP_AUTHN_SCHEME_CERT = 0x00010000,
	}

	/// <summary>Specifies the authentication target.</summary>
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_HTTP_TRANSPORT_CREDENTIALS_A")]
	[Flags]
	public enum RPC_C_HTTP_AUTHN_TARGET : uint
	{
		/// <summary>
		/// Authenticate against the RPC Proxy, which is the HTTP Server from an HTTP perspective. This is the most common value.
		/// </summary>
		RPC_C_HTTP_AUTHN_TARGET_SERVER = 1,

		/// <summary>Authenticate against the HTTP Proxy. This value is uncommon.</summary>
		RPC_C_HTTP_AUTHN_TARGET_PROXY = 2,
	}

	/// <summary>A set of flags that can be combined with the bitwise OR operator.</summary>
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_HTTP_TRANSPORT_CREDENTIALS_A")]
	[Flags]
	public enum RPC_C_HTTP_FLAG : uint
	{
		/// <summary>Instructs RPC to use SSL to communicate with the RPC Proxy.</summary>
		RPC_C_HTTP_FLAG_USE_SSL = 1,

		/// <summary>
		/// When set, RPC chooses the first scheme in the AuthnSchemes array and attempts to authenticate to the RPC Proxy. If the RPC
		/// Proxy does not support the selected authentication scheme, the call fails. When not set, the RPC client queries the RPC
		/// Proxy for supported authentication schemes, and chooses one.
		/// </summary>
		RPC_C_HTTP_FLAG_USE_FIRST_AUTH_SCHEME = 2,

		/// <summary/>
		RPC_C_HTTP_FLAG_IGNORE_CERT_CN_INVALID = 8,

		/// <summary/>
		RPC_C_HTTP_FLAG_ENABLE_CERT_REVOCATION_CHECK = 16,
	}

	/// <summary>
	/// <para>
	/// Specifies an impersonation level, which indicates the amount of authority given to the server when it is impersonating the client.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>GetUserName</c> will fail while impersonating at identify level. The workaround is to impersonate, call
	/// <c>OpenThreadToken</c>, revert, call <c>GetTokenInformation</c>, and finally, call <c>LookupAccountSid</c>. Using
	/// <c>CoSetProxyBlanket</c>, the client sets the impersonation level
	/// </para>
	/// <para>
	/// Using <c>CoSetProxyBlanket</c>, the client sets the impersonation level and proxy identity that will be available when a server
	/// calls <c>CoImpersonateClient</c>. The identity the server will see when impersonating takes place is described in Cloaking. Note
	/// that when making a call while impersonating, the callee will normally receive the caller's process token, not the caller's
	/// impersonation token. To receive the caller's impersonation token, the caller must enable cloaking.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/com/com-impersonation-level-constants
	[PInvokeData("rpcdce.h")]
	public enum RPC_C_IMP_LEVEL
	{
		/// <summary>
		/// DCOM can choose the impersonation level using its normal security blanket negotiation algorithm. For more information, see
		/// Security Blanket Negotiation.
		/// </summary>
		RPC_C_IMP_LEVEL_DEFAULT = 0,

		/// <summary>
		/// The client is anonymous to the server. The server process can impersonate the client, but the impersonation token will not
		/// contain any information and cannot be used.
		/// </summary>
		RPC_C_IMP_LEVEL_ANONYMOUS = 1,

		/// <summary>
		/// The server can obtain the client's identity. The server can impersonate the client for ACL checking, but it cannot access
		/// system objects as the client.
		/// </summary>
		RPC_C_IMP_LEVEL_IDENTIFY = 2,

		/// <summary>
		/// The server process can impersonate the client's security context while acting on behalf of the client. This level of
		/// impersonation can be used to access local resources such as files. When impersonating at this level, the impersonation token
		/// can only be passed across one machine boundary. The Schannel authentication service only supports this level of impersonation.
		/// </summary>
		RPC_C_IMP_LEVEL_IMPERSONATE = 3,

		/// <summary>
		/// The server process can impersonate the client's security context while acting on behalf of the client. The server process
		/// can also make outgoing calls to other servers while acting on behalf of the client, using cloaking. The server may use the
		/// client's security context on other machines to access local and remote resources as the client. When impersonating at this
		/// level, the impersonation token can be passed across any number of computer boundaries.
		/// </summary>
		RPC_C_IMP_LEVEL_DELEGATE = 4,
	}

	/// <summary>Values passed to RPC_MGMT_AUTHORIZATION_FN.</summary>
	[PInvokeData("rpcdce.h")]
	public enum RPC_C_MGMT : uint
	{
		/// <summary>RpcMgmtInqIfIds</summary>
		RPC_C_MGMT_INQ_IF_IDS = 0,

		/// <summary>RpcMgmtInqServerPrincName</summary>
		RPC_C_MGMT_INQ_PRINC_NAME = 1,

		/// <summary>RpcMgmtInqStats</summary>
		RPC_C_MGMT_INQ_STATS = 2,

		/// <summary>RpcMgmtIsServerListening</summary>
		RPC_C_MGMT_IS_SERVER_LISTEN = 3,

		/// <summary>RpcMgmtStopServerListening</summary>
		RPC_C_MGMT_STOP_SERVER_LISTEN = 4,
	}

	/// <summary>
	/// Applications set the binding option constants to control how the RPC run-time library processes remote procedure calls. The
	/// following table lists each binding property, and the relevant constant values for the binding properties.
	/// </summary>
	/// <remarks>
	/// <para>
	/// By default, the RPC run-time library executes the calls on a given binding handle from each thread of an application in strict
	/// order of submission. This does not guarantee that calls from different threads on the same binding handle are serialized.
	/// Multithreaded applications must serialize their RPC calls. If this behavior is too restrictive, you can enable noncausal
	/// ordering. When you do, the RPC run-time library executes calls independently. It imposes no ordering on their submission.
	/// </para>
	/// <para>
	/// One example of an application that might find noncausal ordering useful is a multithreaded program whose threads make calls on
	/// the same binding handle. Similarly, a program that uses multiple asynchronous calls on a binding handle will find noncausal
	/// ordering a convenient option. Another example might be an Internet proxy program that uses a single thread to handle requests
	/// for several clients. In each of these cases, it would be extremely restrictive to try to serialize the remote procedure calls.
	/// </para>
	/// <para>
	/// The <c>RPC_C_OPT_DONT_LINGER</c> option can be set only on binding handles that use the <c>ncalrpc</c> or <c>ncacn_*</c>
	/// protocol sequences. It cannot be used on <c>ncadg_*</c> protocol sequences. The <c>RpcBindingSetOption</c> function with this
	/// option must be called on a binding handle on which at least one RPC call has been made. If no RPC call have been made on the
	/// binding handle, <c>RPC_S_WRONG_KIND_OF_BINDING</c> is returned from the <c>RpcBindingSetOption</c> function call. The option
	/// takes effect for the entire association, regardless of how many binding handles are attached to the association. Since it is
	/// checked before the association is destroyed, it can be set at any time before the binding handle is closed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/rpc/binding-option-constants
	[PInvokeData("rpcdce.h")]
	public enum RPC_C_OPT : uint
	{
		/// <summary>
		/// Default. If FALSE, causal call ordering. RPC calls are executed in strict order of submission. See Remarks.
		/// <para>If TRUE, noncausal call ordering. RPC calls are executed independently. See Remarks.</para>
		/// </summary>
		[CorrespondingType(typeof(BOOL))]
		RPC_C_OPT_BINDING_NONCAUSAL = 9,

		/// <summary>Not needed for application programs. Used internally by Microsoft.</summary>
		RPC_C_OPT_MAX_OPTIONS = 17,

		/// <summary>Not needed for application programs. Used internally by Microsoft.</summary>
		RPC_C_DONT_FAIL = 4,

		/// <summary>If TRUE, a session ID is generated for each connection.</summary>
		[CorrespondingType(typeof(BOOL))]
		RPC_C_OPT_SESSION_ID = 6,

		/// <summary>
		/// If TRUE, client-side cookie-based authentication is used for connections. A pointer to the RPC_C_OPT_COOKIE_AUTH_DESCRIPTOR
		/// structure is passed as the OptionValue parameter in RpcBindingSetOption.
		/// </summary>
		[CorrespondingType(typeof(BOOL))]
		RPC_C_OPT_COOKIE_AUTH = 7,

		/// <summary>Not needed for application programs. Used internally by Microsoft.</summary>
		RPC_C_OPT_RESOURCE_TYPE_UUID = 8,

		/// <summary>If TRUE, force shutdown of the association after the last binding handle/context handle on it is freed.</summary>
		[CorrespondingType(typeof(BOOL))]
		RPC_C_OPT_DONT_LINGER = 13,

		/// <summary>
		/// When set to true, RPC does not reuse existing connections. A unique binding handle is opened for each connection and state
		/// is maintained for each unique binding handle.
		/// </summary>
		[CorrespondingType(typeof(BOOL))]
		RPC_C_OPT_UNIQUE_BINDING = 11,
	}

	/// <summary>Set of flags that determine the attributes of the port or ports where the server receives remote procedure calls.</summary>
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_POLICY")]
	[Flags]
	public enum RPC_C_POL_ENDPT : uint
	{
		/// <summary>
		/// Allocates the endpoint from one of the ports defined in the registry as "Internet Available." Valid only with ncacn_ip_tcp
		/// and ncadg_ip_udp protocol sequences.
		/// </summary>
		RPC_C_USE_INTERNET_PORT = 0x1,

		/// <summary>
		/// Allocates the endpoint from one of the ports defined in the registry as "Intranet Available." Valid only with ncacn_ip_tcp
		/// and ncadg_ip_udp protocol sequences.
		/// </summary>
		RPC_C_USE_INTRANET_PORT = 0x2,

		/// <summary/>
		RPC_C_DONT_FAIL = 0x4,

		/// <summary/>
		RPC_C_RPCHTTP_USE_LOAD_BALANCE = 0x8,
	}

	/// <summary>Policy for binding to Network Interface Cards (NICs).</summary>
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_POLICY")]
	public enum RPC_C_POL_NIC
	{
		/// <summary>
		/// Binds to NICs on the basis of the registry settings. Always use this value when you are using the RPC_POLICY structure to
		/// define message-queue properties.
		/// </summary>
		RPC_C_BIND_TO_REG_NICS,

		/// <summary>
		/// Overrides the registry settings and binds to all NICs. If the Bind key is missing from the registry, then the NICFlags
		/// member will have no effect at run time. If the key contains an invalid value, then the entire configuration is marked as
		/// invalid and all calls to RpcServerUseProtseq* will fail.
		/// </summary>
		RPC_C_BIND_TO_ALL_NICS,
	}

	/// <summary>Security services being provided to the application.</summary>
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_SECURITY_QOS")]
	[Flags]
	public enum RPC_C_QOS_CAPABILITIES : uint
	{
		/// <summary>Used when no provider-specific capabilities are needed.</summary>
		RPC_C_QOS_CAPABILITIES_DEFAULT = 0x0,

		/// <summary>
		/// Specifying this flag causes the RPC run time to request mutual authentication from the security provider. Some security
		/// providers do not support mutual authentication. If the security provider does not support mutual authentication, or the
		/// identity of the server cannot be established, a remote procedure call to such server fails with error RPC_S_SEC_PKG_ERROR.
		/// </summary>
		RPC_C_QOS_CAPABILITIES_MUTUAL_AUTH = 0x1,

		/// <summary>Not currently implemented.</summary>
		RPC_C_QOS_CAPABILITIES_MAKE_FULLSIC = 0x2,

		/// <summary>
		/// Accepts the client's credentials even if the certificate authority (CA) is not in the server's list of trusted CAs. This
		/// constant is used only by the SCHANNEL SSP.
		/// </summary>
		RPC_C_QOS_CAPABILITIES_ANY_AUTHORITY = 0x4,

		/// <summary>
		/// When specified, this flag directs the RPC runtime on the client to ignore an error to establish a security context that
		/// supports delegation. Normally, if the client asks for delegation and the security system cannot establish a security context
		/// that supports delegation, error RPC_S_SEC_PKG_ERROR is returned; when this flag is specified, no error is returned.
		/// </summary>
		RPC_C_QOS_CAPABILITIES_IGNORE_DELEGATE_FAILURE = 0x8,

		/// <summary>
		/// This flag specifies to RPC that the server is local to the machine making the RPC call. In this situation RPC instructs the
		/// endpoint mapper to pick up only endpoints registered by the principal specified in the ServerPrincName or Sid members (these
		/// members are available in RPC_SECURITY_QOS_V3, RPC_SECURITY_QOS_V4, and RPC_SECURITY_QOS_V5 only). See Remarks for more information.
		/// </summary>
		RPC_C_QOS_CAPABILITIES_LOCAL_MA_HINT = 0x10,

		/// <summary>
		/// If set, the RPC runtime uses the SChannel SSP to perform smartcard-based authentication without displaying a PIN prompt
		/// dialog box by the cryptographic services provider (CSP). In the call to RpcBindingSetAuthInfoEx, the AuthIdentity parameter
		/// must be a SEC_WINNT_AUTH_IDENTITY structure whose members contain the following: If the
		/// RPC_C_QOS_CAPABILITIES_SCHANNEL_FULL_AUTH_IDENTITY flag is used for any SSP other than SChannel, or if the members of
		/// SEC_WINNT_AUTH_IDENTITY do not conform to the above, RPC_S_INVALID_ARG will be returned by RpcBindingSetAuthInfoEx.
		/// </summary>
		RPC_C_QOS_CAPABILITIES_SCHANNEL_FULL_AUTH_IDENTITY = 0x20,
	}

	/// <summary>Sets the context tracking mode.</summary>
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_SECURITY_QOS")]
	[Flags]
	public enum RPC_C_QOS_IDENTITY : uint
	{
		/// <summary>
		/// Security context is created only once and is never revised during the entire communication, even if the client side changes
		/// it. This is the default behavior if RPC_SECURITY_QOS is not specified.
		/// </summary>
		RPC_C_QOS_IDENTITY_STATIC = 0,

		/// <summary>
		/// Context is revised whenever the ModifiedId in the client's token is changed. All protocols use the ModifiedId (see note).
		/// Windows 2000: All remote protocols (all protocols other than ncalrpc) use the AuthenticationID, also known as the LogonId,
		/// to track changes in the client's identity. The ncalrpc protocol uses ModifiedId.
		/// </summary>
		RPC_C_QOS_IDENTITY_DYNAMIC = 1,
	}

	/// <summary>
	/// <para>Interface Registration Flags</para>
	/// <para>These constants are used in the Flags parameter of the <c>RpcServerRegisterIf2</c> and <c>RpcServerRegisterIfEx</c> functions.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/rpc/interface-registration-flags
	[PInvokeData("rpcdce.h")]
	[Flags]
	public enum RPC_IF
	{
		/// <summary>
		/// This is an auto-listen interface. The run time begins listening for calls as soon as the first autolisten interface is
		/// registered, and stops listening when the last autolisten interface is unregistered.
		/// </summary>
		RPC_IF_AUTOLISTEN = 0x0001,

		/// <summary>Reserved for OLE. Do not use this flag.</summary>
		RPC_IF_OLE = 0x0002,

		/// <summary>Currently not implemented.</summary>
		RPC_IF_ALLOW_UNKNOWN_AUTHORITY = 0x0004,

		/// <summary>
		/// Limits connections to clients that use an authorization level higher than RPC_C_AUTHN_LEVEL_NONE. Specifying this flag
		/// allows clients to come through on the NULL session. On Windows XP and Windows Server 2003, such clients are not allowed.
		/// Clients that fail the RPC_IF_ALLOW_SECURE_ONLY test receive an RPC_S_ACCESS_DENIED error. Using the RPC_IF_ALLOW_SECURE_ONLY
		/// flag does not imply or guarantee a high level of privilege on the part of the calling user. RPC only checks that the user
		/// has valid credentials; the calling user may be using the guest account or other low privileged accounts. Do not assume high
		/// privilege when RPC_IF_ALLOW_SECURE_ONLY is used. Windows NT 4.0 and Windows Me/98/95:
		/// </summary>
		RPC_IF_ALLOW_SECURE_ONLY = 0x0008,

		/// <summary>
		/// When this interface flag is registered, the RPC runtime invokes the registered security callback for all calls, regardless
		/// of identity, protocol sequence, or authentication level of the client.
		/// </summary>
		RPC_IF_ALLOW_CALLBACKS_WITH_NO_AUTH = 0x0010,

		/// <summary>
		/// When this interface flag is registered, the RPC runtime rejects calls made by remote clients. All local calls using ncadg_*
		/// and ncacn_* protocol sequences are also rejected, with the exception of ncacn_np. RPC allows ncacn_NP calls only if the call
		/// does not come from SRV. Calls from ncalrpc are always processed.
		/// </summary>
		RPC_IF_ALLOW_LOCAL_ONLY = 0x0020,

		/// <summary>Disables security callback caching, forcing a security callback for each RPC call on a given interface.</summary>
		RPC_IF_SEC_NO_CACHE = 0x0040,

		/// <summary/>
		RPC_IF_SEC_CACHE_PER_PROC = 0x0080,

		/// <summary/>
		RPC_IF_ASYNC_CALLBACK = 0x0100,
	}

	/// <summary>Character set used by <see cref="SEC_WINNT_AUTH_IDENTITY"/></summary>
	public enum SEC_WINNT_AUTH_IDENTITY_CHARSET
	{
		/// <summary>The strings in this structure are in ANSI format.</summary>
		SEC_WINNT_AUTH_IDENTITY_ANSI = 0x1,

		/// <summary>The strings in this structure are in Unicode format.</summary>
		SEC_WINNT_AUTH_IDENTITY_UNICODE = 0x2
	}

	/// <summary>
	/// The <c>RPC_BINDING_HANDLE_OPTIONS_V1</c> structure contains additional options with which to create an RPC binding handle.
	/// </summary>
	/// <remarks>If this structure is not specified in a call to RpcBindingCreate, the default values for each option are used.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_binding_handle_options_v1 typedef struct
	// _RPC_BINDING_HANDLE_OPTIONS_V1 { unsigned long Version; unsigned long Flags; unsigned long ComTimeout; unsigned long CallTimeout;
	// } RPC_BINDING_HANDLE_OPTIONS_V1, *PRPC_BINDING_HANDLE_OPTIONS_V1;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_BINDING_HANDLE_OPTIONS_V1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RPC_BINDING_HANDLE_OPTIONS_V1
	{
		/// <summary>The version of this structure. For <c>RPC_BINDING_HANDLE_OPTIONS_V1</c> this must be set to 1.</summary>
		public uint Version;

		/// <summary>
		/// <para>
		/// A set of flags describing specific RPC behaviors. This parameter can be set to one or more of the following values. Note
		/// that by default, RPC calls use causal order and socket lingering.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_BHO_NONCAUSAL</term>
		/// <term>Specifies causal ordering whereby calls are executed independently of one another rather than in order of submission.</term>
		/// </item>
		/// <item>
		/// <term>RPC_BHO_DONTLINGER</term>
		/// <term>Specifies that a socket association must be shutdown after the last binding handle on it is freed.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint Flags;

		/// <summary>
		/// The communication timeout value, specified in microseconds. The default value for RPC is <see
		/// cref="RCP_C_BINDING_TIMEOUT.RPC_C_BINDING_DEFAULT_TIMEOUT"/>. This option can be changed later by calling RpcMgmtSetComTimeout.
		/// </summary>
		public uint ComTimeout;

		/// <summary>The call timeout value, specified in microseconds. The default value for RPC is 0.</summary>
		public uint CallTimeout;
	}

	/// <summary>
	/// The <c>RPC_BINDING_HANDLE_SECURITY_V1</c> structure contains the basic security options with which to create an RPC binding handle.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If this structure is not passed to RpcBindingCreate -- that is, if the Security parameter of <c>RpcBindingCreate</c> is set to
	/// <c>NULL</c> -- then the following default security behaviors are assumed:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// For the protocol sequence ncalrpc (local RPC), RPC will use transport-level security. This means that RPC will use the security
	/// mechanisms offered by the Windows kernel to provide security, and RPC will not authenticate the server since it connects using
	/// the current thread identity. In this case, the identity tracking is static, the impersonation type is set to "Impersonate", and
	/// the authentication level is set to "Privacy".
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// For the protocol sequence ncacn_np, RPC will also use transport-level security. If the call is remote, RPC uses the security
	/// mechanisms provided by the Windows file system redirector and there is no mutual authentication. In this case, the identity is
	/// the current thread identity, the identity tracking state is static, the impersonation type is set to "Impersonate", and the
	/// authentication level is determined by the policies of the remote machine.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// For the protocol sequences ncacn_ip_tcp, ncacn_ip_udp and ncacn_http, no security is used when Security is set to <c>NULL</c>.
	/// The server will not perform impersonation, and all data will be sent as clear text. To provide maximum protection for data, the
	/// application must always provide security data.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The following table summarizes the default security settings for the different protocol sequences if the Security parameter of
	/// RpcBindingCreate is set to <c>NULL</c>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Default Security Settings</term>
	/// <term>ncalrpc</term>
	/// <term>local ncacn_np</term>
	/// <term>remote ncacn_np</term>
	/// <term>ncacn_ip_tcp, ncacn_ip_udp, and ncacn_http</term>
	/// </listheader>
	/// <item>
	/// <term>Security Mechanism</term>
	/// <term>Windows Kernel</term>
	/// <term>NPFS</term>
	/// <term>File system redirector</term>
	/// <term>None</term>
	/// </item>
	/// <item>
	/// <term>Authentication Level</term>
	/// <term>Privacy</term>
	/// <term>Privacy</term>
	/// <term>Server policy dependent</term>
	/// <term>None</term>
	/// </item>
	/// <item>
	/// <term>Mutual Authentication?</term>
	/// <term>No</term>
	/// <term>No</term>
	/// <term>No</term>
	/// <term>No</term>
	/// </item>
	/// <item>
	/// <term>Impersonation Type</term>
	/// <term>Impersonate</term>
	/// <term>Impersonate</term>
	/// <term>Impersonate</term>
	/// <term>N/A</term>
	/// </item>
	/// <item>
	/// <term>Identity Tracking Type</term>
	/// <term>Static</term>
	/// <term>Dynamic</term>
	/// <term>Static</term>
	/// <term>N/A</term>
	/// </item>
	/// <item>
	/// <term>Effective Only?</term>
	/// <term>Yes</term>
	/// <term>No</term>
	/// <term>N/A</term>
	/// <term>N/A</term>
	/// </item>
	/// <item>
	/// <term>Call Identity</term>
	/// <term>Current thread</term>
	/// <term>Current thread</term>
	/// <term>Current thread or "net use" settings</term>
	/// <term>N/A</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> If you create your binding handle by calling the RpcBindingFromStringBinding API, the default identity tracking for
	/// ncalrpc in the absence of specific security settings is dynamic. If you create a fast binding handle by calling the
	/// RpcBindingCreate API, the default identity tracking for ncalrpc in the absence of specific security settings is static. You
	/// should be aware of the differences in these two APIs if you are switching between them in your application. After the binding
	/// handle is created, the RpcBindingSetAuthInfo and RpcBindingSetAuthInfoEx APIs can be used to change the settings of the binding
	/// handle set with this structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_binding_handle_security_v1_a typedef struct
	// _RPC_BINDING_HANDLE_SECURITY_V1_A { unsigned long Version; unsigned char *ServerPrincName; unsigned long AuthnLevel; unsigned
	// long AuthnSvc; SEC_WINNT_AUTH_IDENTITY_A *AuthIdentity; RPC_SECURITY_QOS *SecurityQos; } RPC_BINDING_HANDLE_SECURITY_V1_A, *PRPC_BINDING_HANDLE_SECURITY_V1_A;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_BINDING_HANDLE_SECURITY_V1_A")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RPC_BINDING_HANDLE_SECURITY_V1
	{
		/// <summary>The version of this structure. For <c>RPC_BINDING_HANDLE_SECURITY_V1</c> this must be set to 1.</summary>
		public uint Version;

		/// <summary>
		/// Pointer to a string that contains the server principal name referenced by the binding handle. The content of the name and
		/// its syntax are defined by the authentication service in use.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string ServerPrincName;

		/// <summary>
		/// <para>
		/// Level of authentication to be performed on remote procedure calls made using this binding handle. For a list of the
		/// RPC-supported authentication levels, see Authentication-Level Constants.
		/// </para>
		/// <para>If AuthnSvc is set to RPC_C_AUTHN_NONE, this member must likewise be set to RPC_C_AUTHN_NONE.</para>
		/// </summary>
		public RPC_C_AUTHN AuthnLevel;

		/// <summary>
		/// <para>Authentication service to use when binding.</para>
		/// <para>Specify RPC_C_AUTHN_NONE to turn off authentication for remote procedure calls made using the binding handle.</para>
		/// <para>
		/// If RPC_C_AUTHN_DEFAULT is specified, the RPC run-time library uses the RPC_C_AUTHN_WINNT authentication service for remote
		/// procedure calls made using the binding handle.
		/// </para>
		/// <para>If AuthnLevel is set to RPC_C_AUTHN_NONE, this member must likewise be set to RPC_C_AUTHN_NONE.</para>
		/// </summary>
		public RPC_C_AUTHN AuthnSvc;

		/// <summary>
		/// <see cref="Secur32.SEC_WINNT_AUTH_IDENTITY"/> structure that contains the client's authentication and authorization
		/// credentials appropriate for the selected authentication and authorization service.
		/// </summary>
		public IntPtr AuthIdentity;

		/// <summary>
		/// <para><see cref="RPC_SECURITY_QOS"/> structure that contains the security quality-of-service settings for the binding handle.</para>
		/// <para><c>Note</c> For a list of the RPC-supported authentication services, see Authentication-Service Constants.</para>
		/// </summary>
		public IntPtr SecurityQos;
	}

	/// <summary>
	/// The <c>RPC_BINDING_HANDLE_TEMPLATE_V1</c> structure contains the basic options with which to create an RPC binding handle.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Fast binding handles are slightly different from "classic" binding handles in the way they are handled during calls to
	/// RpcBindingReset. <c>RpcBindingReset</c> is a no-op call for static fast binding handles. For classic binding handles, however,
	/// <c>RpcBindingReset</c> converts a static binding handle into a dynamic one to preserve backwards compatibility.
	/// </para>
	/// <para>
	/// The following table demonstrates the behavior of static and dynamic binding handles with regards to RpcBindingReset and RpcEpResolveBinding.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Endpoint Type</term>
	/// <term>Static</term>
	/// <term>Dynamic</term>
	/// </listheader>
	/// <item>
	/// <term>Binding Handle Type</term>
	/// <term>Fast</term>
	/// <term>Classic</term>
	/// <term>Fast</term>
	/// <term>Classic</term>
	/// </item>
	/// <item>
	/// <term>RpcBindingReset</term>
	/// <term>No-op</term>
	/// <term>Converts to dynamic</term>
	/// <term>Removes resolved endpoint if one is present</term>
	/// <term>Removes resolved endpoint if one is present</term>
	/// </item>
	/// <item>
	/// <term>RpcEpResolveBinding</term>
	/// <term>No-op</term>
	/// <term>No-op</term>
	/// <term>Resolves endpoint if not previously resolved</term>
	/// <term>Resolves endpoint if not previously resolved</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_binding_handle_template_v1_a typedef struct
	// _RPC_BINDING_HANDLE_TEMPLATE_V1_A { unsigned long Version; unsigned long Flags; unsigned long ProtocolSequence; unsigned char
	// *NetworkAddress; unsigned char *StringEndpoint; union { unsigned char *Reserved; } u1; UUID ObjectUuid; }
	// RPC_BINDING_HANDLE_TEMPLATE_V1_A, *PRPC_BINDING_HANDLE_TEMPLATE_V1_A;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_BINDING_HANDLE_TEMPLATE_V1_A")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RPC_BINDING_HANDLE_TEMPLATE_V1
	{
		/// <summary>The version of this structure. For <c>RPC_BINDING_HANDLE_TEMPLATE_V1</c> this must be set to 1.</summary>
		public uint Version;

		/// <summary>
		/// <para>Flag values that describe specific properties of the RPC template.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_BHT_OBJECT_UUID_VALID</term>
		/// <term>
		/// The ObjectUuid member contains a valid value. If this flag is not set, then the ObjectUuid member does not contain a valid UUID.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public uint Flags;

		/// <summary>
		/// <para>A protocol sequence string literal associated with this binding handle. It can be one of the following values.</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>ncalrpc</c> - Specifies local RPC.</term>
		/// </item>
		/// <item>
		/// <term><c>ncacn_ip_tcp</c> - Specifies RPC over TCP/IP.</term>
		/// </item>
		/// <item>
		/// <term><c>ncacn_np</c> - Specifies RPC over named pipes.</term>
		/// </item>
		/// <item>
		/// <term><c>ncacn_http</c> - Specifies RPC over HTTP.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint ProtocolSequence;

		/// <summary>Pointer to a string representation of the network address to bind to.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string NetworkAddress;

		/// <summary>
		/// Pointer to a string representation of the endpoint to bind to. If a dynamic endpoint is used, set this member to
		/// <c>NULL</c>. After the endpoint is resolved, use RpcBindingToStringBinding to obtain it.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? StringEndpoint;

		/// <summary>Reserved. This member must be set to <c>NULL</c>.</summary>
		public IntPtr u1;

		/// <summary>
		/// The UUID of the remote object. The semantics for this UUID are the same as those for a string binding. After the binding
		/// handle is created, call RpcBindingSetObject to change the UUID as needed.
		/// </summary>
		public Guid ObjectUuid;
	}

	/// <summary>
	/// The <c>RPC_BINDING_VECTOR</c> structure contains a list of binding handles over which a server application can receive remote
	/// procedure calls.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The binding vector contains a count member ( <c>Count</c>), followed by an array of binding-handle ( <c>BindingH</c>) elements.
	/// </para>
	/// <para>
	/// The RPC run-time library creates binding handles when a server application registers protocol sequences. To obtain a binding
	/// vector, a server application calls RpcServerInqBindings.
	/// </para>
	/// <para>A client application obtains a binding vector of compatible servers from the name-service database by calling RpcNsBindingLookupNext.</para>
	/// <para>
	/// In both routines, the RPC run-time library allocates memory for the binding vector. An application calls RpcBindingVectorFree to
	/// free the binding vector.
	/// </para>
	/// <para>
	/// To remove an individual binding handle from the vector, the application must set the value in the vector to <c>NULL</c>. When
	/// setting a vector element to <c>NULL</c>, the application must:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Free the individual binding.</term>
	/// </item>
	/// <item>
	/// <term>Not change the value of <c>Count</c>.</term>
	/// </item>
	/// </list>
	/// <para>Calling RpcBindingFree allows an application to free all binding handles in the vector.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_binding_vector typedef struct _RPC_BINDING_VECTOR {
	// unsigned long Count; RPC_BINDING_HANDLE BindingH[1]; } RPC_BINDING_VECTOR;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_BINDING_VECTOR")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<RPC_BINDING_VECTOR>), nameof(Count))]
	[StructLayout(LayoutKind.Sequential)]
	public struct RPC_BINDING_VECTOR
	{
		/// <summary>Number of binding handles present in the binding-handle array <c>BindingH</c>.</summary>
		public uint Count;

		/// <summary>Array of binding handles that contains <c>Count</c> elements.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public RPC_BINDING_HANDLE[] BindingH;
	}

	/// <summary>
	/// The <c>RPC_ENDPOINT_TEMPLATE</c> structure specifies the properties of an RPC interface group server endpoint, including
	/// protocol sequence and name.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The value provided in Backlog by applications is only a hint. The RPC run time or the Windows Sockets provider may override the
	/// value. For example, on Windows XP or Windows 2000 Professional, the value is limited to 5. Values greater than 5 are ignored and
	/// 5 is used instead. On Windows Server 2003 and Windows 2000 Server, the value will be honored.
	/// </para>
	/// <para>
	/// Applications must be careful to pass reasonable values in Backlog. Large values on Server, Advanced Server, or Datacenter Server
	/// can cause a large amount of non-paged pool memory to be used. Using too small a value is also unfavorable, as it may result in
	/// TCP SYN packets being met by TCP RST from the server if the backlog queue gets exhausted.
	/// </para>
	/// <para>
	/// An application developer should balance memory footprint versus scalability requirements when determining the proper value for Backlog.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_endpoint_template typedef struct { unsigned long Version;
	// RPC_CSTR ProtSeq; RPC_CSTR Endpoint; void *SecurityDescriptor; unsigned long Backlog; } RPC_ENDPOINT_TEMPLATE, *PRPC_ENDPOINT_TEMPLATE;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce.__unnamed_struct_5")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RPC_ENDPOINT_TEMPLATE
	{
		/// <summary>This field is reserved and must be set to 0.</summary>
		public uint Version;

		/// <summary>
		/// Pointer to a string identifier of the protocol sequence to register with the RPC run-time library. Only ncalrpc,
		/// ncacn_ip_tcp, and ncacn_np are supported. This value must not be <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string ProtSeq;

		/// <summary>
		/// Optional pointer to the endpoint-address information to use in creating a binding for the protocol sequence specified in the
		/// Protseq parameter. Specify <c>NULL</c> to use dynamic endpoints.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? Endpoint;

		/// <summary>
		/// Pointer to an optional parameter provided for the security subsystem. Used only for ncacn_np and ncalrpc protocol sequences.
		/// All other protocol sequences ignore this parameter. Using a security descriptor on the endpoint in order to make a server
		/// secure is not recommended.
		/// </summary>
		public IntPtr SecurityDescriptor;

		/// <summary>
		/// Backlog queue length for the ncacn_ip_tcp protocol sequence. All other protocol sequences ignore this parameter. Use
		/// <c>RPC_C_PROTSEQ_MAX_REQS_DEFAULT</c> to specify the default value. See Remarks for more informatation.
		/// </summary>
		public uint Backlog;
	}

	/// <summary>
	/// The <c>RPC_HTTP_TRANSPORT_CREDENTIALS</c> structure defines additional credentials to authenticate to an RPC proxy server when
	/// using RPC/HTTP.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If the <c>TransportCredentials</c> member is <c>NULL</c> and the authentication scheme is NTLM, the credentials of the currently
	/// logged on user are used. To avoid exposing user credentials on the network through a weak LM hash, user logon credentials are
	/// used only if one or both of the following conditions are true:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Caller requested use of SSL and used the <c>ServerCertificateSubject</c> member. This scenario guarantees credentials are
	/// protected both in transit and at the final destination, even if a weak hash is used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The lncompatibilitylevel key is set to 2 or higher. This causes the NTLM security provider to emit or respond to only the strong
	/// NT hash, not the weak LM hash. In addition, customers are encouraged to use level 3 or higher, which will attempt NTLMv2.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the Unicode version of the RpcBindingSetAuthInfoEx function is used, Unicode versions of the
	/// <c>RPC_HTTP_TRANSPORT_CREDENTIALS</c> and SEC_WINNT_AUTH_IDENTITY structures must also be provided, and the <c>Flags</c> member
	/// in <c>TransportCredentials</c> must be set to SEC_WINNT_AUTH_IDENTITY_UNICODE. If the ANSI version of the
	/// <c>RpcBindingSetAuthInfoEx</c> function is used, ANSI versions of <c>RPC_HTTP_TRANSPORT_CREDENTIALS</c> and
	/// <c>SEC_WINNT_AUTH_IDENTITY</c> structures must be provided, and the <c>Flags</c> member in <c>TransportCredentials</c> must be
	/// set to SEC_WINNT_AUTH_IDENTITY_ANSI.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_http_transport_credentials_a typedef struct
	// _RPC_HTTP_TRANSPORT_CREDENTIALS_A { SEC_WINNT_AUTH_IDENTITY_A *TransportCredentials; unsigned long Flags; unsigned long
	// AuthenticationTarget; unsigned long NumberOfAuthnSchemes; unsigned long *AuthnSchemes; unsigned char *ServerCertificateSubject; }
	// RPC_HTTP_TRANSPORT_CREDENTIALS_A, *PRPC_HTTP_TRANSPORT_CREDENTIALS_A;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_HTTP_TRANSPORT_CREDENTIALS_A")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RPC_HTTP_TRANSPORT_CREDENTIALS
	{
		/// <summary>
		/// A pointer to a <see cref="Secur32.SEC_WINNT_AUTH_IDENTITY"/> structure that contains the user name, domain, and password for
		/// the user.
		/// </summary>
		public IntPtr TransportCredentials;

		/// <summary>
		/// <para>A set of flags that can be combined with the bitwise OR operator.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_HTTP_FLAG_USE_SSL</term>
		/// <term>Instructs RPC to use SSL to communicate with the RPC Proxy.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_HTTP_FLAG_USE_FIRST_AUTH_SCHEME</term>
		/// <term>
		/// When set, RPC chooses the first scheme in the AuthnSchemes array and attempts to authenticate to the RPC Proxy. If the RPC
		/// Proxy does not support the selected authentication scheme, the call fails. When not set, the RPC client queries the RPC
		/// Proxy for supported authentication schemes, and chooses one.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_HTTP_FLAG Flags;

		/// <summary>
		/// <para>Specifies the authentication target.</para>
		/// <para>Should be set to one or both of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_HTTP_AUTHN_TARGET_SERVER</term>
		/// <term>Authenticate against the RPC Proxy, which is the HTTP Server from an HTTP perspective. This is the most common value.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_HTTP_AUTHN_TARGET_PROXY</term>
		/// <term>Authenticate against the HTTP Proxy. This value is uncommon.</term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_HTTP_AUTHN_TARGET AuthenticationTarget;

		/// <summary>The number of elements in the <c>AuthnScheme</c> array.</summary>
		public uint NumberOfAuthnSchemes;

		/// <summary/>
		public IntPtr AuthnSchemes;

		/// <summary>
		/// Contains an optional string with the expected server principal name. The principal name is in the same format as that
		/// generated for RpcCertGeneratePrincipalName (see Principal Names for more information). This member is used only when SSL is
		/// used. In such cases, the server certificate is checked against the generated principal name. If they do not match, an error
		/// is returned. This member enables clients to authenticate the RPC Proxy.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string ServerCertificateSubject;
	}

	/// <summary>
	/// <para>
	/// The <c>RPC_HTTP_TRANSPORT_CREDENTIALS_V2</c> structure defines additional credentials to authenticate to an RPC proxy server or
	/// HTTP proxy server when using RPC/HTTP.
	/// </para>
	/// <para>
	/// <c>RPC_HTTP_TRANSPORT_CREDENTIALS_V2</c> extends RPC_HTTP_TRANSPORT_CREDENTIALS by allowing authentication against an HTTP proxy server.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// If the <c>TransportCredentials</c> member is <c>NULL</c> and the authentication scheme is NTLM, the credentials of the currently
	/// logged on user are used. To avoid exposing user credentials on the network through a weak LM hash, user logon credentials are
	/// used only if one or both of the following conditions are true:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Caller requested use of SSL and used the <c>ServerCertificateSubject</c> member. This scenario guarantees credentials are
	/// protected both in transit and at the final destination, even if a weak hash is used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The lncompatibilitylevel key is set to 2 or higher. This causes the NTLM security provider to emit or respond to only the strong
	/// NT hash, not the weak LM hash. In addition, customers are encouraged to use level 3 or higher, which will attempt NTLMv2.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the Unicode version of the RpcBindingSetAuthInfoEx function is used, Unicode versions of the
	/// <c>RPC_HTTP_TRANSPORT_CREDENTIALS_V2</c> and SEC_WINNT_AUTH_IDENTITY structures must also be provided, and the <c>Flags</c>
	/// member in <c>TransportCredentials</c> must be set to SEC_WINNT_AUTH_IDENTITY_UNICODE. If the ANSI version of the
	/// <c>RpcBindingSetAuthInfoEx</c> function is used, ANSI versions of <c>RPC_HTTP_TRANSPORT_CREDENTIALS_V2</c> and
	/// <c>SEC_WINNT_AUTH_IDENTITY</c> structures must be provided, and the <c>Flags</c> member in <c>TransportCredentials</c> must be
	/// set to SEC_WINNT_AUTH_IDENTITY_ANSI.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_http_transport_credentials_v2_a typedef struct
	// _RPC_HTTP_TRANSPORT_CREDENTIALS_V2_A { SEC_WINNT_AUTH_IDENTITY_A *TransportCredentials; unsigned long Flags; unsigned long
	// AuthenticationTarget; unsigned long NumberOfAuthnSchemes; unsigned long *AuthnSchemes; unsigned char *ServerCertificateSubject;
	// SEC_WINNT_AUTH_IDENTITY_A *ProxyCredentials; unsigned long NumberOfProxyAuthnSchemes; unsigned long *ProxyAuthnSchemes; }
	// RPC_HTTP_TRANSPORT_CREDENTIALS_V2_A, *PRPC_HTTP_TRANSPORT_CREDENTIALS_V2_A;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_HTTP_TRANSPORT_CREDENTIALS_V2_A")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RPC_HTTP_TRANSPORT_CREDENTIALS_V2
	{
		/// <summary>
		/// A pointer to a <see cref="Secur32.SEC_WINNT_AUTH_IDENTITY"/> structure that contains the user name, domain, and password for
		/// the user.
		/// </summary>
		public IntPtr TransportCredentials;

		/// <summary>
		/// <para>A set of flags that can be combined with the bitwise OR operator.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_HTTP_FLAG_USE_SSL</term>
		/// <term>Instructs RPC to use SSL to communicate with the RPC Proxy.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_HTTP_FLAG_USE_FIRST_AUTH_SCHEME</term>
		/// <term>
		/// When set, RPC chooses the first scheme in the AuthnSchemes array and attempts to authenticate to the RPC Proxy. If the RPC
		/// Proxy does not support the selected authentication scheme, the call fails. When not set, the RPC client queries the RPC
		/// Proxy for supported authentication schemes, and chooses one.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_HTTP_FLAG Flags;

		/// <summary>
		/// <para>Specifies the authentication target.</para>
		/// <para>Should be set to one or both of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_HTTP_AUTHN_TARGET_SERVER</term>
		/// <term>Authenticate against the RPC Proxy, which is the HTTP Server from an HTTP perspective. This is the most common value.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_HTTP_AUTHN_TARGET_PROXY</term>
		/// <term>Authenticate against the HTTP Proxy. This value is uncommon.</term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_HTTP_AUTHN_TARGET AuthenticationTarget;

		/// <summary>The number of elements in the <c>AuthnScheme</c> array.</summary>
		public uint NumberOfAuthnSchemes;

		/// <summary>
		/// <para>
		/// A pointer to an array of <see cref="RPC_C_HTTP_AUTHN_SCHEME"/> values representing authentication schemes the client is
		/// willing to use. Each element of the array can contain one of the following constants:
		/// </para>
		/// <list type="bullet">
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_BASIC</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_NTLM</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_PASSPORT</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_DIGEST</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_NEGOTIATE</item>
		/// </list>
		/// <para>
		/// RPC_C_HTTP_AUTHN_SCHEME_PASSPORT, RPC_C_HTTP_AUTHN_SCHEME_NEGOTIATE and RPC_C_HTTP_AUTHN_SCHEME_DIGEST are defined as
		/// constants, but not currently supported. Callers should not specify them; doing so results in RPC_S_CANNOT_SUPPORT error.
		/// Each constant can be specified once. RPC does not verify this restriction for performance reasons, but specifying a constant
		/// more than once produces undefined results.
		/// </para>
		/// <para>The algorithm for choosing the actual authentication scheme is as follows:</para>
		/// <para>
		/// If RPC_C_HTTP_FLAG_USE_FIRST_AUTH_SCHEME is specified, the first authentication scheme is chosen. If it is not supported by
		/// the server, the connection establishment fails. If RPC_C_HTTP_FLAG_USE_FIRST_AUTH_SCHEME is not specified, the RPC client
		/// first attempts anonymous connection to the RPC Proxy. If IIS returns authentication challenge, the RPC client chooses the
		/// authentication scheme preferred by the server if it is also in the <c>AuthnScheme</c> array. If the scheme preferred by the
		/// server is not in the <c>AuthnScheme</c> array, the <c>AuthnScheme</c> array will be traversed from start to finish, and if a
		/// scheme is found that is also supported by the server, that authentication scheme is used.
		/// </para>
		/// </summary>
		public IntPtr AuthnSchemes;

		/// <summary>
		/// Contains an optional string with the expected server principal name. The principal name is in the same format as that
		/// generated for RpcCertGeneratePrincipalName (see Principal Names for more information). This member is used only when SSL is
		/// used. In such cases, the server certificate is checked against the generated principal name. If they do not match, an error
		/// is returned. This member enables clients to authenticate the RPC Proxy.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string ServerCertificateSubject;

		/// <summary>
		/// A pointer to a <see cref="Secur32.SEC_WINNT_AUTH_IDENTITY"/> structure that contains the user name, domain, and password for
		/// the user when authenticating against an HTTP proxy server. <c>ProxyCredentials</c> is only valid when
		/// <c>AuthenticationTarget</c> contains <c>RPC_C_HTTP_AUTHN_TARGET_PROXY</c>.
		/// </summary>
		public IntPtr ProxyCredentials;

		/// <summary>
		/// The number of elements in the <c>ProxyAuthnSchemes</c> array when authenticating against an HTTP proxy server.
		/// <c>NumberOfProxyAuthnSchemes</c> is only valid when <c>AuthenticationTarget</c> contains <c>RPC_C_HTTP_AUTHN_TARGET_PROXY</c>.
		/// </summary>
		public uint NumberOfProxyAuthnSchemes;

		/// <summary>
		/// <para>
		/// A pointer to an array of <see cref="RPC_C_HTTP_AUTHN_SCHEME"/> values representing authentication schemes the client is
		/// willing to use when authenticating against an HTTP proxy server. Each element of the array can contain one of the following
		/// constants. <c>ProxyAuthnSchemes</c> is only valid when <c>AuthenticationTarget</c> contains <c>RPC_C_HTTP_AUTHN_TARGET_PROXY</c>.
		/// </para>
		/// <list type="bullet">
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_BASIC</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_NTLM</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_PASSPORT</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_DIGEST</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_NEGOTIATE</item>
		/// </list>
		/// </summary>
		public IntPtr ProxyAuthnSchemes;
	}

	/// <summary>
	/// <para>
	/// The <c>RPC_HTTP_TRANSPORT_CREDENTIALS_V3</c> structure defines additional credentials to authenticate to an RPC proxy server or
	/// HTTP proxy server when using RPC/HTTP.
	/// </para>
	/// <para>
	/// <c>RPC_HTTP_TRANSPORT_CREDENTIALS_V3</c> extends RPC_HTTP_TRANSPORT_CREDENTIALS_V2 by allowing arbitrary credential forms to be used.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// If the <c>TransportCredentials</c> member is <c>NULL</c> and the authentication scheme is NTLM, the credentials of the currently
	/// logged on user are used. To avoid exposing user credentials on the network through a weak LM hash, user logon credentials are
	/// used only if one or both of the following conditions are true:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Caller requested use of SSL and used the <c>ServerCertificateSubject</c> member. This scenario guarantees credentials are
	/// protected both in transit and at the final destination, even if a weak hash is used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The lncompatibilitylevel key is set to 2 or higher. This causes the NTLM security provider to emit or respond to only the strong
	/// NT hash, not the weak LM hash. In addition, customers are encouraged to use level 3 or higher, which will attempt NTLMv2.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the Unicode version of the RpcBindingSetAuthInfoEx function is used, Unicode versions of the
	/// <c>RPC_HTTP_TRANSPORT_CREDENTIALS_V3</c> and SEC_WINNT_AUTH_IDENTITY structures must also be provided, and the <c>Flags</c>
	/// member in <c>TransportCredentials</c> must be set to SEC_WINNT_AUTH_IDENTITY_UNICODE. If the ANSI version of the
	/// <c>RpcBindingSetAuthInfoEx</c> function is used, ANSI versions of <c>RPC_HTTP_TRANSPORT_CREDENTIALS_V3</c> and
	/// <c>SEC_WINNT_AUTH_IDENTITY</c> structures must be provided, and the <c>Flags</c> member in <c>TransportCredentials</c> must be
	/// set to SEC_WINNT_AUTH_IDENTITY_ANSI.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_http_transport_credentials_v3_a typedef struct
	// _RPC_HTTP_TRANSPORT_CREDENTIALS_V3_A { RPC_AUTH_IDENTITY_HANDLE TransportCredentials; unsigned long Flags; unsigned long
	// AuthenticationTarget; unsigned long NumberOfAuthnSchemes; unsigned long *AuthnSchemes; unsigned char *ServerCertificateSubject;
	// RPC_AUTH_IDENTITY_HANDLE ProxyCredentials; unsigned long NumberOfProxyAuthnSchemes; unsigned long *ProxyAuthnSchemes; }
	// RPC_HTTP_TRANSPORT_CREDENTIALS_V3_A, *PRPC_HTTP_TRANSPORT_CREDENTIALS_V3_A;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_HTTP_TRANSPORT_CREDENTIALS_V3_A")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RPC_HTTP_TRANSPORT_CREDENTIALS_V3
	{
		/// <summary>
		/// A pointer to a <see cref="Secur32.SEC_WINNT_AUTH_IDENTITY"/> structure that contains the user name, domain, and password for
		/// the user.
		/// </summary>
		public IntPtr TransportCredentials;

		/// <summary>
		/// <para>A set of flags that can be combined with the bitwise OR operator.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_HTTP_FLAG_USE_SSL</term>
		/// <term>Instructs RPC to use SSL to communicate with the RPC Proxy.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_HTTP_FLAG_USE_FIRST_AUTH_SCHEME</term>
		/// <term>
		/// When set, RPC chooses the first scheme in the AuthnSchemes array and attempts to authenticate to the RPC Proxy. If the RPC
		/// Proxy does not support the selected authentication scheme, the call fails. When not set, the RPC client queries the RPC
		/// Proxy for supported authentication schemes, and chooses one.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_HTTP_FLAG Flags;

		/// <summary>
		/// <para>Specifies the authentication target.</para>
		/// <para>Should be set to one or both of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_HTTP_AUTHN_TARGET_SERVER</term>
		/// <term>Authenticate against the RPC Proxy, which is the HTTP Server from an HTTP perspective. This is the most common value.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_HTTP_AUTHN_TARGET_PROXY</term>
		/// <term>Authenticate against the HTTP Proxy. This value is uncommon.</term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_HTTP_AUTHN_TARGET AuthenticationTarget;

		/// <summary>The number of elements in the <c>AuthnScheme</c> array.</summary>
		public uint NumberOfAuthnSchemes;

		/// <summary>
		/// <para>
		/// A pointer to an array of <see cref="RPC_C_HTTP_AUTHN_SCHEME"/> values representing authentication schemes the client is
		/// willing to use. Each element of the array can contain one of the following constants:
		/// </para>
		/// <list type="bullet">
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_BASIC</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_NTLM</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_PASSPORT</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_DIGEST</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_NEGOTIATE</item>
		/// </list>
		/// <para>
		/// RPC_C_HTTP_AUTHN_SCHEME_PASSPORT, RPC_C_HTTP_AUTHN_SCHEME_NEGOTIATE and RPC_C_HTTP_AUTHN_SCHEME_DIGEST are defined as
		/// constants, but not currently supported. Callers should not specify them; doing so results in RPC_S_CANNOT_SUPPORT error.
		/// Each constant can be specified once. RPC does not verify this restriction for performance reasons, but specifying a constant
		/// more than once produces undefined results.
		/// </para>
		/// <para>The algorithm for choosing the actual authentication scheme is as follows:</para>
		/// <para>
		/// If RPC_C_HTTP_FLAG_USE_FIRST_AUTH_SCHEME is specified, the first authentication scheme is chosen. If it is not supported by
		/// the server, the connection establishment fails. If RPC_C_HTTP_FLAG_USE_FIRST_AUTH_SCHEME is not specified, the RPC client
		/// first attempts anonymous connection to the RPC Proxy. If IIS returns authentication challenge, the RPC client chooses the
		/// authentication scheme preferred by the server if it is also in the <c>AuthnScheme</c> array. If the scheme preferred by the
		/// server is not in the <c>AuthnScheme</c> array, the <c>AuthnScheme</c> array will be traversed from start to finish, and if a
		/// scheme is found that is also supported by the server, that authentication scheme is used.
		/// </para>
		/// </summary>
		public IntPtr AuthnSchemes;

		/// <summary>
		/// Contains an optional string with the expected server principal name. The principal name is in the same format as that
		/// generated for RpcCertGeneratePrincipalName (see Principal Names for more information). This member is used only when SSL is
		/// used. In such cases, the server certificate is checked against the generated principal name. If they do not match, an error
		/// is returned. This member enables clients to authenticate the RPC Proxy.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string ServerCertificateSubject;

		/// <summary>
		/// A pointer to an opaque authentication handle in the form of an RPC_AUTH_IDENTITY_HANDLE structure when authenticating
		/// against an HTTP proxy server. <c>ProxyCredentials</c> is only valid when <c>AuthenticationTarget</c> contains <c>RPC_C_HTTP_AUTHN_TARGET_PROXY</c>.
		/// </summary>
		public RPC_AUTH_IDENTITY_HANDLE ProxyCredentials;

		/// <summary>
		/// The number of elements in the <c>ProxyAuthnSchemes</c> array when authenticating against an HTTP proxy server.
		/// <c>NumberOfProxyAuthnSchemes</c> is only valid when <c>AuthenticationTarget</c> contains <c>RPC_C_HTTP_AUTHN_TARGET_PROXY</c>.
		/// </summary>
		public uint NumberOfProxyAuthnSchemes;

		/// <summary>
		/// <para>
		/// A pointer to an array of <see cref="RPC_C_HTTP_AUTHN_SCHEME"/> values representing authentication schemes the client is
		/// willing to use when authenticating against an HTTP proxy server. Each element of the array can contain one of the following
		/// constants. <c>ProxyAuthnSchemes</c> is only valid when <c>AuthenticationTarget</c> contains <c>RPC_C_HTTP_AUTHN_TARGET_PROXY</c>.
		/// </para>
		/// <list type="bullet">
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_BASIC</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_NTLM</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_PASSPORT</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_DIGEST</item>
		/// <item>RPC_C_HTTP_AUTHN_SCHEME_NEGOTIATE</item>
		/// </list>
		/// </summary>
		public IntPtr ProxyAuthnSchemes;
	}

	/// <summary>The <c>RPC_IF_ID</c> structure contains the interface UUID and major and minor version numbers of an interface.</summary>
	/// <remarks>
	/// An interface identification is a subset of the data contained in the interface-specification structure. Routines that require an
	/// interface identification structure show a data type of <c>RPC_IF_ID</c>. In those routines, the application is responsible for
	/// providing memory for the structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_if_id typedef struct _RPC_IF_ID { UUID Uuid; unsigned
	// short VersMajor; unsigned short VersMinor; } RPC_IF_ID;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_IF_ID")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RPC_IF_ID
	{
		/// <summary>Specifies the interface UUID.</summary>
		public Guid Uuid;

		/// <summary>Major version number, an integer from 0 to 65535, inclusive.</summary>
		public ushort VersMajor;

		/// <summary>Minor version number, an integer from 0 to 65535, inclusive.</summary>
		public ushort VersMinor;
	}

	/// <summary>The <c>RPC_IF_ID_VECTOR</c> structure contains a list of interfaces offered by a server.</summary>
	/// <remarks>
	/// <para>
	/// The interface identification vector contains a count member ( <c>Count</c>), followed by an array of pointers to interface
	/// identifiers ( RPC_IF_ID).
	/// </para>
	/// <para>
	/// The interface identification vector is a read-only vector. To obtain a vector of the interface identifiers registered by a
	/// server with the run-time library, an application calls RpcMgmtInqIfIds. To obtain a vector of the interface identifiers exported
	/// by a server, an application calls RpcNsMgmtEntryInqIfIds.
	/// </para>
	/// <para>
	/// The RPC run-time library allocates memory for the interface identification vector. The application calls RpcIfIdVectorFree to
	/// free the interface identification vector.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_if_id_vector typedef struct { unsigned long Count;
	// RPC_IF_ID *IfId[1]; } RPC_IF_ID_VECTOR;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce.__unnamed_struct_1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RPC_IF_ID_VECTOR : IArrayStruct<RPC_IF_ID>
	{
		/// <summary>Number of interface-identification structures present in the array <c>IfHandl</c>.</summary>
		public uint Count;

		/// <summary>An array of pointers to interface identifiers ( <see cref="RPC_IF_ID"/>).</summary>
		public IntPtr IfId;
	}

	/// <summary>The <c>RPC_INTERFACE_TEMPLATE</c> structure defines an RPC interface group server interface.</summary>
	/// <remarks>
	/// <para>To register an interface, the server provides the following information:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Interface specificationThe interface specification is a data structure that the MIDL compiler generates.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Manager type UUID and manager EPVThe manager type UUID and the manager EPV determine which manager routine executes when a
	/// server receives a remote procedure call request from a client. For each implementation of an interface offered by a server, it
	/// must register a separate manager EPV. Note that when specifying a non-nil, manager type <c>UUID</c>, the server must also call
	/// RpcObjectSetType to register objects of this non-nil type.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// All interface group interfaces are treated as <c>auto-listen</c>. The runtime begins listening for calls as soon as the
	/// interface group is activated. Calls to RpcServerListen and RpcMgmtStopServerListening do not affect the interface, nor does a
	/// call to RpcServerUnregisterIf with IfSpec set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// Specifying a security-callback function in IfCallback allows the server application to restrict access to its interfaces on an
	/// individual client basis. That is, by default, security is optional; the server run-time will dispatch unsecured calls even if
	/// the server has called RpcServerRegisterAuthInfo. If the server wants to accept only authenticated clients, an interface callback
	/// function must call RpcBindingInqAuthClient, RpcGetAuthorizationContextForClient, or RpcServerInqCallAttributes to retrieve the
	/// security level, or attempt to impersonate the client with RpcImpersonateClient. It can also specify the RPC_IF_ALLOW_SECURE_ONLY
	/// flag in Flags to reject unauthenticated calls.
	/// </para>
	/// <para>
	/// When a server application specifies a security-callback function for its interface(s) in IfCallback, the RPC run time
	/// automatically rejects calls without authentication information to that interface. In addition, the run-time records the
	/// interfaces each client has used. When a client makes an RPC to an interface that it has not used during the current
	/// communication session, the RPC run-time library calls the interface's security-callback function. Specifying
	/// RPC_IF_ALLOW_CALLBACKS_WITH_NO_AUTH in Flags will prevent the automatic rejection of unauthenticated clients. Note that calls on
	/// the <c>NULL</c> security session can have authentication information, even though they come from anonymous clients. Thus, the
	/// existence of a callback alone is not sufficient to prevent anonymous clients from connecting; either the security callback
	/// function must check for that, or the RPC_IF_ALLOW_SECURE_ONLY flag must be used. RPC_IF_ALLOW_SECURE_ONLY rejects null session
	/// calls only on Windows XP and later versions of Windows.
	/// </para>
	/// <para>For the signature for the callback function, see RPC_IF_CALLBACK_FN.</para>
	/// <para>
	/// The callback function in IfCallback should return <c>RPC_S_OK</c> if the client is allowed to call methods in this interface.
	/// Any other return code will cause the client to receive the exception <c>RPC_S_ACCESS_DENIED</c>.
	/// </para>
	/// <para>
	/// In some cases, the RPC run time may call the security-callback function more than once per client, per interface. The callback
	/// function must be able to handle this possibility.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_interface_templatea typedef struct { unsigned long
	// Version; RPC_IF_HANDLE IfSpec; UUID *MgrTypeUuid; RPC_MGR_EPV *MgrEpv; unsigned int Flags; unsigned int MaxCalls; unsigned int
	// MaxRpcSize; RPC_IF_CALLBACK_FN *IfCallback; UUID_VECTOR *UuidVector; RPC_CSTR Annotation; void *SecurityDescriptor; }
	// RPC_INTERFACE_TEMPLATEA, *PRPC_INTERFACE_TEMPLATEA;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce.__unnamed_struct_6")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RPC_INTERFACE_TEMPLATE
	{
		/// <summary>This field is reserved and must be set to 0.</summary>
		public uint Version;

		/// <summary>MIDL-generated structure that defines the interface to register.</summary>
		public RPC_IF_HANDLE IfSpec;

		/// <summary>Pointer to a UUID to associate with MgrEpv. <c>NULL</c> or a nil <c>UUID</c> registers IfSpec with a nil <c>UUID</c>.</summary>
		public GuidPtr MgrTypeUuid;

		/// <summary>
		/// Pointer to a RPC_MGR_EPV structure that contains the manager routines' entry-point vector (EPV). If
		/// <c>NULL</c>,the MIDL-generated default EPV is used.
		/// </summary>
		public IntPtr MgrEpv;

		/// <summary>
		/// Flags. For a list of flag values, see Interface Registration Flags. Interface group interfaces are always treated as <c>auto-listen</c>.
		/// </summary>
		public RPC_IF Flags;

		/// <summary>
		/// <para>
		/// Maximum number of concurrent remote procedure call requests the server can accept on this interface. The RPC run-time
		/// library makes its best effort to ensure the server does not allow more concurrent call requests than the number of calls
		/// specified in MaxCalls. However, the actual number can be greater than MaxCalls and can vary for each protocol sequence.
		/// </para>
		/// <para>Calls on other interfaces are governed by the value of the process-wide MaxCalls parameter specified in RpcServerListen.</para>
		/// <para>
		/// If the number of concurrent calls is not a concern, slightly better server-side performance can be achieved by specifying
		/// the default value using <c>RPC_C_LISTEN_MAX_CALLS_DEFAULT</c>. Doing so relieves the RPC run-time environment from enforcing
		/// an unnecessary restriction.
		/// </para>
		/// </summary>
		public uint MaxCalls;

		/// <summary>
		/// Maximum size, in bytes, of incoming data blocks. MaxRpcSize may be used to help prevent malicious denial-of-service attacks.
		/// If the data block of a remote procedure call is larger than MaxRpcSize, the RPC run-time library rejects the call and sends
		/// an <c>RPC_S_ACCESS_DENIED</c> error to the client. Specifying a value of (unsigned int) –1 in MaxRpcSize removes the limit
		/// on the size of incoming data blocks. This parameter has no effect on calls made over the ncalrpc protocol.
		/// </summary>
		public uint MaxRpcSize;

		/// <summary>
		/// A pointer to a RPC_INTERFACE_GROUP_IDLE_CALLBACK_FN security-callback function, or <c>NULL</c> for no callback. Each
		/// registered interface can have a different callback function.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public RPC_INTERFACE_GROUP_IDLE_CALLBACK_FN? IfCallback;

		/// <summary>
		/// Pointer to a vector of object UUIDs offered by the server to be registered with the RPC endpoint mapper. The server
		/// application constructs this vector. <c>NULL</c> indicates there are no object <c>UUIDs</c> to register.
		/// </summary>
		public IntPtr UuidVector;

		/// <summary>
		/// <para>
		/// Pointer to the character-string comment applied to each cross-product element added to the local endpoint-map database. The
		/// string can be up to 64 characters long, including the null terminating character. Specify a null value or a null-terminated
		/// string ("\0") if there is no annotation string.
		/// </para>
		/// <para>
		/// The annotation string is used by applications for information only. RPC does not use this string to determine which server
		/// instance a client communicates with or for enumerating elements in the endpoint-map database.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? Annotation;

		/// <summary>Optional security descriptor describing which clients have the right to access the interface.</summary>
		public IntPtr SecurityDescriptor;
	}

	/// <summary>
	/// The <c>RPC_POLICY</c> structure contains flags that determine binding on multihomed computers, and port allocations when using
	/// the ncacn_ip_tcp and ncadg_ip_udp protocols.
	/// </summary>
	/// <remarks>
	/// <para>You can use the <c>RPC_Policy</c> structure to set policies for remote procedure calls at run time. These policies include:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Message queuing: Allows the server to specify message-queuing properties, such as security, quality of delivery, and the
	/// lifetime of the server-process queue. This policy is only effective for remote calls over the message-queuing transport (ncadg_mq).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Port allocation for dynamic ports: Specifies whether the endpoint registered by this application should go to the
	/// Internet-available or intranet-available port set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Selective binding: Allows multihomed machines to bind selectively to NICs.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> Port allocation and selective binding policies are effective only for remote calls over TCP ( ncacn_ip_tcp) and UDP
	/// ( ncadg_ip_udp) connections. For more information, see Configuring the Registry for Port Allocations and Selective Binding.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_policy typedef struct _RPC_POLICY { unsigned int Length;
	// unsigned long EndpointFlags; unsigned long NICFlags; } RPC_POLICY, *PRPC_POLICY;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_POLICY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RPC_POLICY
	{
		/// <summary>
		/// Size of the <c>RPC_POLICY</c> structure, in bytes. The <c>Length</c> member allows compatibility with future versions of
		/// this structure, which may contain additional fields. Always set the <c>Length</c> equal to <c>sizeof</c>(RPC_POLICY) when
		/// you initialize the <c>RPC_POLICY</c> structure in your code.
		/// </summary>
		public uint Length;

		/// <summary>
		/// <para>
		/// Set of flags that determine the attributes of the port or ports where the server receives remote procedure calls. You can
		/// specify more than one flag (by using the bitwise OR operator) from the set of values for a given protocol sequence.
		/// </para>
		/// <para>
		/// <c>Note</c> If the registry does not contain any of the keys that specify the default policies, then the
		/// <c>EndpointFlags</c> member will have no effect at run time. If a key is missing or contains an invalid value, then the
		/// entire configuration for that protocol ( ncacn_ip_tcp, ncadg_ip_udp or ncadg_mq) is marked as invalid and all calls to
		/// <c>RpcServerUseProtseq*</c> functions over that protocol will fail.
		/// </para>
		/// </summary>
		public RPC_C_POL_ENDPT EndpointFlags;

		/// <summary>Policy for binding to Network Interface Cards (NICs).</summary>
		public RPC_C_POL_NIC NICFlags;
	}

	/// <summary>
	/// The <c>RPC_PROTSEQ_VECTOR</c> structure contains a list of protocol sequences the RPC run-time library uses to send and receive
	/// remote procedure calls.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The protocol-sequence vector contains a count member ( <c>Count</c>), followed by an array of pointers to protocol-sequence
	/// strings ( <c>Protseq</c>).
	/// </para>
	/// <para>
	/// The protocol-sequence vector is a read-only vector. To obtain a protocol-sequence vector, a server application calls
	/// RpcNetworkInqProtseqs. The RPC run-time library allocates memory for the protocol-sequence vector. The server application calls
	/// RpcProtseqVectorFree to free the protocol-sequence vector.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_protseq_vector typedef struct _RPC_PROTSEQ_VECTOR {
	// unsigned int Count; unsigned char *Protseq[1]; } RPC_PROTSEQ_VECTOR;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_PROTSEQ_VECTOR")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RPC_PROTSEQ_VECTOR : IArrayStruct<StrPtrAuto>
	{
		/// <summary>Number of protocol-sequence strings present in the array <c>Protseq</c>.</summary>
		public uint Count;

		/// <summary>
		/// Array of pointers to protocol-sequence strings. The number of pointers present is specified by the <c>Count</c> member.
		/// </summary>
		public IntPtr Protseq;
	}

	/// <summary>
	/// The <c>RPC_SECURITY_QOS</c> structure defines security quality-of-service settings on a binding handle. See Remarks for version
	/// availability on Windows editions.
	/// </summary>
	/// <remarks>
	/// <para>The following listing defines the availability of QOS versions on various Windows operating systems:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Version 1: Windows 2000 and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 2: Windows XP with Service Pack 1 (SP1) and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 3: Windows Server 2003 and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 4: Windows Vista and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 5: Windows 8 and later.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Windows editions support downlevel versions as well. For example, Windows Server 2003 supports version 3, but also supports
	/// versions 1 and 2.
	/// </para>
	/// <para>
	/// The client-side security functions RpcBindingInqAuthInfoEx and RpcBindingSetAuthInfo use the <c>RPC_SECURITY_QOS</c> structure
	/// to inquire about, or to set, the security quality of service for a binding handle.
	/// </para>
	/// <para>
	/// RPC supports the RPC_C_QOS_CAPABILITIES_LOCAL_MA_HINT hint. This hint is used only when dynamic endpoints and mutual
	/// authentication are used. Furthermore, it is not supported for the <c>ncadg_</c> protocol sequences. If this flag is used for a
	/// <c>ncadg_</c> protocol sequence, or without using mutual authentication, RPC_S_INVALID_ARG is returned from the
	/// RpcBindingSetAuthInfoEx function call. This flag is designed to prevent a Denial of Service Attack. Using this flag forces the
	/// RPC Runtime to ask the endpoint mapper only for endpoints registered by the principal specified in the <c>ServerPrincName</c> or
	/// <c>Sid</c> members. This prevents an attacker on the local machine from trying to trick your RPC client to connect to a spoof
	/// endpoint it has registered in the endpoint mapper. Note that since the attack is local only (such as from a terminal server
	/// machine with many users), the flag also works only for RPC calls made locally.
	/// </para>
	/// <para>
	/// <c>Note</c> Some security providers, such as Kerberos, support delegation-impersonation type. On Windows editions that support
	/// delegation-impersonation type, if the client has asked for delegation but the security provider is unable to provide it, the
	/// call fails with PRC_S_SEC_PKG_ERROR unless the RPC_C_QOS_CAPABILITIES_IGNORE_DELEGATE_FAILURE flag is specified.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_security_qos typedef struct _RPC_SECURITY_QOS { unsigned
	// long Version; unsigned long Capabilities; unsigned long IdentityTracking; unsigned long ImpersonationType; } RPC_SECURITY_QOS, *PRPC_SECURITY_QOS;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_SECURITY_QOS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RPC_SECURITY_QOS
	{
		/// <summary>
		/// Version of the <c>RPC_SECURITY_QOS</c> structure being used. This topic documents version 1 of the <c>RPC_SECURITY_QOS</c>
		/// structure. See RPC_SECURITY_QOS_V2, RPC_SECURITY_QOS_V3, RPC_SECURITY_QOS_V4 and RPC_SECURITY_QOS_V5 for other versions.
		/// </summary>
		public uint Version;

		/// <summary>
		/// <para>
		/// Security services being provided to the application. Capabilities is a set of flags that can be combined using the bitwise
		/// OR operator.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_DEFAULT</term>
		/// <term>Used when no provider-specific capabilities are needed.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_MUTUAL_AUTH</term>
		/// <term>
		/// Specifying this flag causes the RPC run time to request mutual authentication from the security provider. Some security
		/// providers do not support mutual authentication. If the security provider does not support mutual authentication, or the
		/// identity of the server cannot be established, a remote procedure call to such server fails with error RPC_S_SEC_PKG_ERROR.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_MAKE_FULLSIC</term>
		/// <term>Not currently implemented.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_ANY_AUTHORITY</term>
		/// <term>
		/// Accepts the client's credentials even if the certificate authority (CA) is not in the server's list of trusted CAs. This
		/// constant is used only by the SCHANNEL SSP.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_IGNORE_DELEGATE_FAILURE</term>
		/// <term>
		/// When specified, this flag directs the RPC runtime on the client to ignore an error to establish a security context that
		/// supports delegation. Normally, if the client asks for delegation and the security system cannot establish a security context
		/// that supports delegation, error RPC_S_SEC_PKG_ERROR is returned; when this flag is specified, no error is returned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_LOCAL_MA_HINT</term>
		/// <term>
		/// This flag specifies to RPC that the server is local to the machine making the RPC call. In this situation RPC instructs the
		/// endpoint mapper to pick up only endpoints registered by the principal specified in the ServerPrincName or Sid members (these
		/// members are available in RPC_SECURITY_QOS_V3, RPC_SECURITY_QOS_V4, and RPC_SECURITY_QOS_V5 only). See Remarks for more information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_SCHANNEL_FULL_AUTH_IDENTITY</term>
		/// <term>
		/// If set, the RPC runtime uses the SChannel SSP to perform smartcard-based authentication without displaying a PIN prompt
		/// dialog box by the cryptographic services provider (CSP). In the call to RpcBindingSetAuthInfoEx, the AuthIdentity parameter
		/// must be a SEC_WINNT_AUTH_IDENTITY structure whose members contain the following: If the
		/// RPC_C_QOS_CAPABILITIES_SCHANNEL_FULL_AUTH_IDENTITY flag is used for any SSP other than SChannel, or if the members of
		/// SEC_WINNT_AUTH_IDENTITY do not conform to the above, RPC_S_INVALID_ARG will be returned by RpcBindingSetAuthInfoEx.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_QOS_CAPABILITIES Capabilities;

		/// <summary>
		/// <para>Sets the context tracking mode. Should be set to one of the values shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_QOS_IDENTITY_STATIC</term>
		/// <term>
		/// Security context is created only once and is never revised during the entire communication, even if the client side changes
		/// it. This is the default behavior if RPC_SECURITY_QOS is not specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_IDENTITY_DYNAMIC</term>
		/// <term>
		/// Context is revised whenever the ModifiedId in the client's token is changed. All protocols use the ModifiedId (see note).
		/// Windows 2000: All remote protocols (all protocols other than ncalrpc) use the AuthenticationID, also known as the LogonId,
		/// to track changes in the client's identity. The ncalrpc protocol uses ModifiedId.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_QOS_IDENTITY IdentityTracking;

		/// <summary>
		/// <para>Level at which the server process can impersonate the client.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_DEFAULT</term>
		/// <term>Uses the default impersonation level.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_ANONYMOUS</term>
		/// <term>
		/// Client does not provide identification information to the server. The server cannot impersonate the client or identify the
		/// client. Many servers reject calls with this impersonation type.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_IDENTIFY</term>
		/// <term>
		/// Server can obtain the client's identity, and impersonate the client to perform Access Control List (ACL) checks, but cannot
		/// impersonate the client. See Impersonation Levels for more information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_IMPERSONATE</term>
		/// <term>Server can impersonate the client's security context on its local system, but not on remote systems.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_DELEGATE</term>
		/// <term>
		/// The server can impersonate the client's security context while acting on behalf of the client. The server can also make
		/// outgoing calls to other servers while acting on behalf of the client. The server may use the client's security context on
		/// other machines to access local and remote resources as the client.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_IMP_LEVEL ImpersonationType;
	}

	/// <summary>
	/// The <c>RPC_SECURITY_QOS_V2</c> structure defines version 2 security quality-of-service settings on a binding handle. See Remarks
	/// for version availability on Windows editions.
	/// </summary>
	/// <remarks>
	/// <para>The following listing defines the availability of QOS versions on various Windows operating systems:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Version 1: Windows 2000 and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 2: Windows XP with Service Pack 1 (SP1) and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 3: Windows Server 2003 and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 4: Windows Vista and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 5: Windows 8 and later.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Windows editions support downlevel versions as well. For example, Windows Server 2003 supports version 3, but also supports
	/// versions 1 and 2.
	/// </para>
	/// <para>
	/// The client-side security functions RpcBindingInqAuthInfoEx and RpcBindingSetAuthInfo use the RPC_SECURITY_QOS structure to
	/// inquire about, or to set, the security quality of service for a binding handle.
	/// </para>
	/// <para>
	/// RPC supports the RPC_C_QOS_CAPABILITIES_LOCAL_MA_HINT hint (unsupported on Windows XP and earlier client editions, unsupported
	/// on Windows 2000 and earlier server editions). This hint is used only when dynamic endpoints and mutual authentication are used.
	/// Furthermore, it is not supported for the <c>ncadg_</c> protocol sequences. If this flag is used for a <c>ncadg_</c> protocol
	/// sequence, or without using mutual authentication, RPC_S_INVALID_ARG is returned from the RpcBindingSetAuthInfoEx function call.
	/// This flag is designed to prevent a Denial of Service Attack. Using this flag forces the RPC Runtime to ask the endpoint mapper
	/// only for endpoints registered by the principal specified in the <c>ServerPrincName</c> or <c>Sid</c> members. This prevents an
	/// attacker on the local machine from trying to trick your RPC client to connect to a spoof endpoint it has registered in the
	/// endpoint mapper. Note that since the attack is local only (such as from a terminal server machine with many users), the flag
	/// also works only for RPC calls made locally.
	/// </para>
	/// <para>
	/// <c>Note</c> Some security providers, such as Kerberos, support delegation-impersonation type. On Windows editions that support
	/// delegation-impersonation type, if the client has asked for delegation but the security provider is unable to provide it, the
	/// call fails with PRC_S_SEC_PKG_ERROR unless the RPC_C_QOS_CAPABILITIES_IGNORE_DELEGATE_FAILURE flag is specified.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_security_qos_v2_a typedef struct _RPC_SECURITY_QOS_V2_A {
	// unsigned long Version; unsigned long Capabilities; unsigned long IdentityTracking; unsigned long ImpersonationType; unsigned long
	// AdditionalSecurityInfoType; union { RPC_HTTP_TRANSPORT_CREDENTIALS_A *HttpCredentials; } u; } RPC_SECURITY_QOS_V2_A, *PRPC_SECURITY_QOS_V2_A;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_SECURITY_QOS_V2_A")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RPC_SECURITY_QOS_V2
	{
		/// <summary>
		/// Version of the <c>RPC_SECURITY_QOS</c> structure being used. This topic documents version 1 of the <c>RPC_SECURITY_QOS</c>
		/// structure. See RPC_SECURITY_QOS_V2, RPC_SECURITY_QOS_V3, RPC_SECURITY_QOS_V4 and RPC_SECURITY_QOS_V5 for other versions.
		/// </summary>
		public uint Version;

		/// <summary>
		/// <para>
		/// Security services being provided to the application. Capabilities is a set of flags that can be combined using the bitwise
		/// OR operator.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_DEFAULT</term>
		/// <term>Used when no provider-specific capabilities are needed.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_MUTUAL_AUTH</term>
		/// <term>
		/// Specifying this flag causes the RPC run time to request mutual authentication from the security provider. Some security
		/// providers do not support mutual authentication. If the security provider does not support mutual authentication, or the
		/// identity of the server cannot be established, a remote procedure call to such server fails with error RPC_S_SEC_PKG_ERROR.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_MAKE_FULLSIC</term>
		/// <term>Not currently implemented.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_ANY_AUTHORITY</term>
		/// <term>
		/// Accepts the client's credentials even if the certificate authority (CA) is not in the server's list of trusted CAs. This
		/// constant is used only by the SCHANNEL SSP.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_IGNORE_DELEGATE_FAILURE</term>
		/// <term>
		/// When specified, this flag directs the RPC runtime on the client to ignore an error to establish a security context that
		/// supports delegation. Normally, if the client asks for delegation and the security system cannot establish a security context
		/// that supports delegation, error RPC_S_SEC_PKG_ERROR is returned; when this flag is specified, no error is returned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_LOCAL_MA_HINT</term>
		/// <term>
		/// This flag specifies to RPC that the server is local to the machine making the RPC call. In this situation RPC instructs the
		/// endpoint mapper to pick up only endpoints registered by the principal specified in the ServerPrincName or Sid members (these
		/// members are available in RPC_SECURITY_QOS_V3, RPC_SECURITY_QOS_V4, and RPC_SECURITY_QOS_V5 only). See Remarks for more information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_SCHANNEL_FULL_AUTH_IDENTITY</term>
		/// <term>
		/// If set, the RPC runtime uses the SChannel SSP to perform smartcard-based authentication without displaying a PIN prompt
		/// dialog box by the cryptographic services provider (CSP). In the call to RpcBindingSetAuthInfoEx, the AuthIdentity parameter
		/// must be a SEC_WINNT_AUTH_IDENTITY structure whose members contain the following: If the
		/// RPC_C_QOS_CAPABILITIES_SCHANNEL_FULL_AUTH_IDENTITY flag is used for any SSP other than SChannel, or if the members of
		/// SEC_WINNT_AUTH_IDENTITY do not conform to the above, RPC_S_INVALID_ARG will be returned by RpcBindingSetAuthInfoEx.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_QOS_CAPABILITIES Capabilities;

		/// <summary>
		/// <para>Sets the context tracking mode. Should be set to one of the values shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_QOS_IDENTITY_STATIC</term>
		/// <term>
		/// Security context is created only once and is never revised during the entire communication, even if the client side changes
		/// it. This is the default behavior if RPC_SECURITY_QOS is not specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_IDENTITY_DYNAMIC</term>
		/// <term>
		/// Context is revised whenever the ModifiedId in the client's token is changed. All protocols use the ModifiedId (see note).
		/// Windows 2000: All remote protocols (all protocols other than ncalrpc) use the AuthenticationID, also known as the LogonId,
		/// to track changes in the client's identity. The ncalrpc protocol uses ModifiedId.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_QOS_IDENTITY IdentityTracking;

		/// <summary>
		/// <para>Level at which the server process can impersonate the client.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_DEFAULT</term>
		/// <term>Uses the default impersonation level.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_ANONYMOUS</term>
		/// <term>
		/// Client does not provide identification information to the server. The server cannot impersonate the client or identify the
		/// client. Many servers reject calls with this impersonation type.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_IDENTIFY</term>
		/// <term>
		/// Server can obtain the client's identity, and impersonate the client to perform Access Control List (ACL) checks, but cannot
		/// impersonate the client. See Impersonation Levels for more information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_IMPERSONATE</term>
		/// <term>Server can impersonate the client's security context on its local system, but not on remote systems.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_DELEGATE</term>
		/// <term>
		/// The server can impersonate the client's security context while acting on behalf of the client. The server can also make
		/// outgoing calls to other servers while acting on behalf of the client. The server may use the client's security context on
		/// other machines to access local and remote resources as the client.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_IMP_LEVEL ImpersonationType;

		/// <summary>
		/// <para>Specifies the type of additional credentials present in the <c>u</c> union. The following constants are supported:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Supported Constants</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>No additional credentials are passed in the u union.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_AUTHN_INFO_TYPE_HTTP</term>
		/// <term>
		/// The HttpCredentials member of the u union points to a RPC_HTTP_TRANSPORT_CREDENTIALS structure. This value can be used only
		/// when the protocol sequence is ncacn_http. Any other protocol sequence returns RPC_S_INVALID_ARG.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_AUTHN_INFO_TYPE AdditionalSecurityInfoType;

		/// <summary>
		/// Additional set of credentials to pass to RPC, in the form of an RPC_HTTP_TRANSPORT_CREDENTIALS structure. Used when the
		/// <c>AdditionalSecurityInfoType</c> member is set to RPC_C_AUTHN_INFO_TYPE_HTTP.
		/// </summary>
		public IntPtr u;
	}

	/// <summary>
	/// The <c>RPC_SECURITY_QOS_V3</c> structure defines version 3 security quality-of-service settings on a binding handle. See Remarks
	/// for version availability on Windows editions.
	/// </summary>
	/// <remarks>
	/// <para>The following listing defines the availability of QOS versions on various Windows operating systems:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Version 1: Windows 2000 and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 2: Windows XP with Service Pack 1 (SP1) and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 3: Windows Server 2003 and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 4: Windows Vista and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 5: Windows 8 and later.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Windows editions support downlevel versions as well. For example, Windows Server 2003 supports version 3, but also supports
	/// versions 1 and 2.
	/// </para>
	/// <para>
	/// The client-side security functions RpcBindingInqAuthInfoEx and RpcBindingSetAuthInfo use the RPC_SECURITY_QOS structure to
	/// inquire about, or to set, the security quality of service for a binding handle.
	/// </para>
	/// <para>
	/// RPC supports the RPC_C_QOS_CAPABILITIES_LOCAL_MA_HINT hint (unsupported on Windows XP and earlier client editions, unsupported
	/// on Windows 2000 and earlier server editions). This hint is used only when dynamic endpoints and mutual authentication are used.
	/// Furthermore, it is not supported for the <c>ncadg_</c> protocol sequences. If this flag is used for a <c>ncadg_</c> protocol
	/// sequence, or without using mutual authentication, RPC_S_INVALID_ARG is returned from the RpcBindingSetAuthInfoEx function call.
	/// This flag is designed to prevent a Denial of Service Attack. Using this flag forces the RPC Runtime to ask the endpoint mapper
	/// only for endpoints registered by the principal specified in the <c>ServerPrincName</c> or <c>Sid</c> members. This prevents an
	/// attacker on the local machine from trying to trick your RPC client to connect to a spoof endpoint it has registered in the
	/// endpoint mapper. Note that since the attack is local only (such as from a terminal server machine with many users), the flag
	/// also works only for RPC calls made locally.
	/// </para>
	/// <para>
	/// <c>Note</c> Some security providers, such as Kerberos, support delegation-impersonation type. On Windows editions that support
	/// delegation-impersonation type, if the client has asked for delegation but the security provider is unable to provide it, the
	/// call fails with PRC_S_SEC_PKG_ERROR unless the RPC_C_QOS_CAPABILITIES_IGNORE_DELEGATE_FAILURE flag is specified.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_security_qos_v3_a typedef struct _RPC_SECURITY_QOS_V3_A {
	// unsigned long Version; unsigned long Capabilities; unsigned long IdentityTracking; unsigned long ImpersonationType; unsigned long
	// AdditionalSecurityInfoType; union { RPC_HTTP_TRANSPORT_CREDENTIALS_A *HttpCredentials; } u; void *Sid; } RPC_SECURITY_QOS_V3_A, *PRPC_SECURITY_QOS_V3_A;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_SECURITY_QOS_V3_A")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RPC_SECURITY_QOS_V3
	{
		/// <summary>
		/// Version of the <c>RPC_SECURITY_QOS</c> structure being used. This topic documents version 1 of the <c>RPC_SECURITY_QOS</c>
		/// structure. See RPC_SECURITY_QOS_V2, RPC_SECURITY_QOS_V3, RPC_SECURITY_QOS_V4 and RPC_SECURITY_QOS_V5 for other versions.
		/// </summary>
		public uint Version;

		/// <summary>
		/// <para>
		/// Security services being provided to the application. Capabilities is a set of flags that can be combined using the bitwise
		/// OR operator.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_DEFAULT</term>
		/// <term>Used when no provider-specific capabilities are needed.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_MUTUAL_AUTH</term>
		/// <term>
		/// Specifying this flag causes the RPC run time to request mutual authentication from the security provider. Some security
		/// providers do not support mutual authentication. If the security provider does not support mutual authentication, or the
		/// identity of the server cannot be established, a remote procedure call to such server fails with error RPC_S_SEC_PKG_ERROR.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_MAKE_FULLSIC</term>
		/// <term>Not currently implemented.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_ANY_AUTHORITY</term>
		/// <term>
		/// Accepts the client's credentials even if the certificate authority (CA) is not in the server's list of trusted CAs. This
		/// constant is used only by the SCHANNEL SSP.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_IGNORE_DELEGATE_FAILURE</term>
		/// <term>
		/// When specified, this flag directs the RPC runtime on the client to ignore an error to establish a security context that
		/// supports delegation. Normally, if the client asks for delegation and the security system cannot establish a security context
		/// that supports delegation, error RPC_S_SEC_PKG_ERROR is returned; when this flag is specified, no error is returned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_LOCAL_MA_HINT</term>
		/// <term>
		/// This flag specifies to RPC that the server is local to the machine making the RPC call. In this situation RPC instructs the
		/// endpoint mapper to pick up only endpoints registered by the principal specified in the ServerPrincName or Sid members (these
		/// members are available in RPC_SECURITY_QOS_V3, RPC_SECURITY_QOS_V4, and RPC_SECURITY_QOS_V5 only). See Remarks for more information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_SCHANNEL_FULL_AUTH_IDENTITY</term>
		/// <term>
		/// If set, the RPC runtime uses the SChannel SSP to perform smartcard-based authentication without displaying a PIN prompt
		/// dialog box by the cryptographic services provider (CSP). In the call to RpcBindingSetAuthInfoEx, the AuthIdentity parameter
		/// must be a SEC_WINNT_AUTH_IDENTITY structure whose members contain the following: If the
		/// RPC_C_QOS_CAPABILITIES_SCHANNEL_FULL_AUTH_IDENTITY flag is used for any SSP other than SChannel, or if the members of
		/// SEC_WINNT_AUTH_IDENTITY do not conform to the above, RPC_S_INVALID_ARG will be returned by RpcBindingSetAuthInfoEx.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_QOS_CAPABILITIES Capabilities;

		/// <summary>
		/// <para>Sets the context tracking mode. Should be set to one of the values shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_QOS_IDENTITY_STATIC</term>
		/// <term>
		/// Security context is created only once and is never revised during the entire communication, even if the client side changes
		/// it. This is the default behavior if RPC_SECURITY_QOS is not specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_IDENTITY_DYNAMIC</term>
		/// <term>
		/// Context is revised whenever the ModifiedId in the client's token is changed. All protocols use the ModifiedId (see note).
		/// Windows 2000: All remote protocols (all protocols other than ncalrpc) use the AuthenticationID, also known as the LogonId,
		/// to track changes in the client's identity. The ncalrpc protocol uses ModifiedId.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_QOS_IDENTITY IdentityTracking;

		/// <summary>
		/// <para>Level at which the server process can impersonate the client.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_DEFAULT</term>
		/// <term>Uses the default impersonation level.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_ANONYMOUS</term>
		/// <term>
		/// Client does not provide identification information to the server. The server cannot impersonate the client or identify the
		/// client. Many servers reject calls with this impersonation type.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_IDENTIFY</term>
		/// <term>
		/// Server can obtain the client's identity, and impersonate the client to perform Access Control List (ACL) checks, but cannot
		/// impersonate the client. See Impersonation Levels for more information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_IMPERSONATE</term>
		/// <term>Server can impersonate the client's security context on its local system, but not on remote systems.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_DELEGATE</term>
		/// <term>
		/// The server can impersonate the client's security context while acting on behalf of the client. The server can also make
		/// outgoing calls to other servers while acting on behalf of the client. The server may use the client's security context on
		/// other machines to access local and remote resources as the client.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_IMP_LEVEL ImpersonationType;

		/// <summary>
		/// <para>Specifies the type of additional credentials present in the <c>u</c> union. The following constants are supported:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Supported Constants</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>No additional credentials are passed in the u union.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_AUTHN_INFO_TYPE_HTTP</term>
		/// <term>
		/// The HttpCredentials member of the u union points to a RPC_HTTP_TRANSPORT_CREDENTIALS structure. This value can be used only
		/// when the protocol sequence is ncacn_http. Any other protocol sequence returns RPC_S_INVALID_ARG.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_AUTHN_INFO_TYPE AdditionalSecurityInfoType;

		/// <summary>
		/// Additional set of credentials to pass to RPC, in the form of an RPC_HTTP_TRANSPORT_CREDENTIALS structure. Used when the
		/// <c>AdditionalSecurityInfoType</c> member is set to RPC_C_AUTHN_INFO_TYPE_HTTP.
		/// </summary>
		public IntPtr u;

		/// <summary>
		/// Points to a security identifier (SID). The SID is an alternative to the <c>ServerPrincName</c> member, and only one can be
		/// specified. The <c>Sid</c> member cannot be set to non- <c>NULL</c> if the security provider is the SCHANNEL SSP. Some
		/// protocol sequences use <c>Sid</c> internally for security, and some use a <c>ServerPrincName</c>. For example, ncalrpc uses
		/// a <c>Sid</c> internally, and if the caller knows both the SID and the <c>ServerPrincName</c>, a call using <c>ncalrpc</c>
		/// can complete much faster in some cases if the SID is passed. In contrast, the <c>ncacn_</c> and <c>ncadg_</c> protocol
		/// sequences use a <c>ServerPrincName</c> internally, and therefore can execute calls faster when provided the <c>ServerPrincName</c>.
		/// </summary>
		public PSID Sid;
	}

	/// <summary>
	/// The <c>RPC_SECURITY_QOS_V4</c> structure defines version 4 security quality-of-service settings on a binding handle. See Remarks
	/// for version availability on Windows editions.
	/// </summary>
	/// <remarks>
	/// <para>The following listing defines the availability of QOS versions on various Windows operating systems:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Version 1: Windows 2000 and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 2: Windows XP with Service Pack 1 (SP1) and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 3: Windows Server 2003 and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 4: Windows Vista and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 5: Windows 8 and later.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Windows editions support downlevel versions as well. For example, Windows Server 2003 supports version 3, but also supports
	/// versions 1 and 2.
	/// </para>
	/// <para>
	/// The client-side security functions RpcBindingInqAuthInfoEx and RpcBindingSetAuthInfo use the RPC_SECURITY_QOS structure to
	/// inquire about, or to set, the security quality of service for a binding handle.
	/// </para>
	/// <para>
	/// RPC supports the RPC_C_QOS_CAPABILITIES_LOCAL_MA_HINT hint (unsupported on Windows XP and earlier client editions, unsupported
	/// on Windows 2000 and earlier server editions). This hint is used only when dynamic endpoints and mutual authentication are used.
	/// Furthermore, it is not supported for the <c>ncadg_</c> protocol sequences. If this flag is used for a <c>ncadg_</c> protocol
	/// sequence, or without using mutual authentication, RPC_S_INVALID_ARG is returned from the RpcBindingSetAuthInfoEx function call.
	/// This flag is designed to prevent a Denial of Service Attack. Using this flag forces the RPC Runtime to ask the endpoint mapper
	/// only for endpoints registered by the principal specified in the <c>ServerPrincName</c> or <c>Sid</c> members. This prevents an
	/// attacker on the local machine from trying to trick your RPC client to connect to a spoof endpoint it has registered in the
	/// endpoint mapper. Note that since the attack is local only (such as from a terminal server machine with many users), the flag
	/// also works only for RPC calls made locally.
	/// </para>
	/// <para>
	/// <c>Note</c> Some security providers, such as Kerberos, support delegation-impersonation type. On Windows editions that support
	/// delegation-impersonation type, if the client has asked for delegation but the security provider is unable to provide it, the
	/// call fails with PRC_S_SEC_PKG_ERROR unless the RPC_C_QOS_CAPABILITIES_IGNORE_DELEGATE_FAILURE flag is specified.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_security_qos_v4_a typedef struct _RPC_SECURITY_QOS_V4_A {
	// unsigned long Version; unsigned long Capabilities; unsigned long IdentityTracking; unsigned long ImpersonationType; unsigned long
	// AdditionalSecurityInfoType; union { RPC_HTTP_TRANSPORT_CREDENTIALS_A *HttpCredentials; } u; void *Sid; unsigned int
	// EffectiveOnly; } RPC_SECURITY_QOS_V4_A, *PRPC_SECURITY_QOS_V4_A;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_SECURITY_QOS_V4_A")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RPC_SECURITY_QOS_V4
	{
		/// <summary>
		/// Version of the <c>RPC_SECURITY_QOS</c> structure being used. This topic documents version 1 of the <c>RPC_SECURITY_QOS</c>
		/// structure. See RPC_SECURITY_QOS_V2, RPC_SECURITY_QOS_V3, RPC_SECURITY_QOS_V4 and RPC_SECURITY_QOS_V5 for other versions.
		/// </summary>
		public uint Version;

		/// <summary>
		/// <para>
		/// Security services being provided to the application. Capabilities is a set of flags that can be combined using the bitwise
		/// OR operator.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_DEFAULT</term>
		/// <term>Used when no provider-specific capabilities are needed.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_MUTUAL_AUTH</term>
		/// <term>
		/// Specifying this flag causes the RPC run time to request mutual authentication from the security provider. Some security
		/// providers do not support mutual authentication. If the security provider does not support mutual authentication, or the
		/// identity of the server cannot be established, a remote procedure call to such server fails with error RPC_S_SEC_PKG_ERROR.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_MAKE_FULLSIC</term>
		/// <term>Not currently implemented.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_ANY_AUTHORITY</term>
		/// <term>
		/// Accepts the client's credentials even if the certificate authority (CA) is not in the server's list of trusted CAs. This
		/// constant is used only by the SCHANNEL SSP.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_IGNORE_DELEGATE_FAILURE</term>
		/// <term>
		/// When specified, this flag directs the RPC runtime on the client to ignore an error to establish a security context that
		/// supports delegation. Normally, if the client asks for delegation and the security system cannot establish a security context
		/// that supports delegation, error RPC_S_SEC_PKG_ERROR is returned; when this flag is specified, no error is returned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_LOCAL_MA_HINT</term>
		/// <term>
		/// This flag specifies to RPC that the server is local to the machine making the RPC call. In this situation RPC instructs the
		/// endpoint mapper to pick up only endpoints registered by the principal specified in the ServerPrincName or Sid members (these
		/// members are available in RPC_SECURITY_QOS_V3, RPC_SECURITY_QOS_V4, and RPC_SECURITY_QOS_V5 only). See Remarks for more information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_SCHANNEL_FULL_AUTH_IDENTITY</term>
		/// <term>
		/// If set, the RPC runtime uses the SChannel SSP to perform smartcard-based authentication without displaying a PIN prompt
		/// dialog box by the cryptographic services provider (CSP). In the call to RpcBindingSetAuthInfoEx, the AuthIdentity parameter
		/// must be a SEC_WINNT_AUTH_IDENTITY structure whose members contain the following: If the
		/// RPC_C_QOS_CAPABILITIES_SCHANNEL_FULL_AUTH_IDENTITY flag is used for any SSP other than SChannel, or if the members of
		/// SEC_WINNT_AUTH_IDENTITY do not conform to the above, RPC_S_INVALID_ARG will be returned by RpcBindingSetAuthInfoEx.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_QOS_CAPABILITIES Capabilities;

		/// <summary>
		/// <para>Sets the context tracking mode. Should be set to one of the values shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_QOS_IDENTITY_STATIC</term>
		/// <term>
		/// Security context is created only once and is never revised during the entire communication, even if the client side changes
		/// it. This is the default behavior if RPC_SECURITY_QOS is not specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_IDENTITY_DYNAMIC</term>
		/// <term>
		/// Context is revised whenever the ModifiedId in the client's token is changed. All protocols use the ModifiedId (see note).
		/// Windows 2000: All remote protocols (all protocols other than ncalrpc) use the AuthenticationID, also known as the LogonId,
		/// to track changes in the client's identity. The ncalrpc protocol uses ModifiedId.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_QOS_IDENTITY IdentityTracking;

		/// <summary>
		/// <para>Level at which the server process can impersonate the client.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_DEFAULT</term>
		/// <term>Uses the default impersonation level.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_ANONYMOUS</term>
		/// <term>
		/// Client does not provide identification information to the server. The server cannot impersonate the client or identify the
		/// client. Many servers reject calls with this impersonation type.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_IDENTIFY</term>
		/// <term>
		/// Server can obtain the client's identity, and impersonate the client to perform Access Control List (ACL) checks, but cannot
		/// impersonate the client. See Impersonation Levels for more information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_IMPERSONATE</term>
		/// <term>Server can impersonate the client's security context on its local system, but not on remote systems.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_DELEGATE</term>
		/// <term>
		/// The server can impersonate the client's security context while acting on behalf of the client. The server can also make
		/// outgoing calls to other servers while acting on behalf of the client. The server may use the client's security context on
		/// other machines to access local and remote resources as the client.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_IMP_LEVEL ImpersonationType;

		/// <summary>
		/// <para>Specifies the type of additional credentials present in the <c>u</c> union. The following constants are supported:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Supported Constants</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>No additional credentials are passed in the u union.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_AUTHN_INFO_TYPE_HTTP</term>
		/// <term>
		/// The HttpCredentials member of the u union points to a RPC_HTTP_TRANSPORT_CREDENTIALS structure. This value can be used only
		/// when the protocol sequence is ncacn_http. Any other protocol sequence returns RPC_S_INVALID_ARG.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_AUTHN_INFO_TYPE AdditionalSecurityInfoType;

		/// <summary>
		/// Additional set of credentials to pass to RPC, in the form of an RPC_HTTP_TRANSPORT_CREDENTIALS structure. Used when the
		/// <c>AdditionalSecurityInfoType</c> member is set to RPC_C_AUTHN_INFO_TYPE_HTTP.
		/// </summary>
		public IntPtr u;

		/// <summary>
		/// Points to a security identifier (SID). The SID is an alternative to the <c>ServerPrincName</c> member, and only one can be
		/// specified. The <c>Sid</c> member cannot be set to non- <c>NULL</c> if the security provider is the SCHANNEL SSP. Some
		/// protocol sequences use <c>Sid</c> internally for security, and some use a <c>ServerPrincName</c>. For example, ncalrpc uses
		/// a <c>Sid</c> internally, and if the caller knows both the SID and the <c>ServerPrincName</c>, a call using <c>ncalrpc</c>
		/// can complete much faster in some cases if the SID is passed. In contrast, the <c>ncacn_</c> and <c>ncadg_</c> protocol
		/// sequences use a <c>ServerPrincName</c> internally, and therefore can execute calls faster when provided the <c>ServerPrincName</c>.
		/// </summary>
		public PSID Sid;

		/// <summary>If set, only enabled privileges are seen by the server.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool EffectiveOnly;
	}

	/// <summary>
	/// The <c>RPC_SECURITY_QOS_V5</c> structure defines version 5 security quality-of-service settings on a binding handle. See Remarks
	/// for version availability on Windows editions.
	/// </summary>
	/// <remarks>
	/// <para>The following listing defines the availability of QOS versions on various Windows operating systems:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Version 1: Windows 2000 and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 2: Windows XP with Service Pack 1 (SP1) and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 3: Windows Server 2003 and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 4: Windows Vista and later.</term>
	/// </item>
	/// <item>
	/// <term>Version 5: Windows 8 and later.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Windows editions support downlevel versions as well. For example, Windows Server 2003 supports version 3, but also supports
	/// versions 1 and 2.
	/// </para>
	/// <para>
	/// The client-side security functions RpcBindingInqAuthInfoEx and RpcBindingSetAuthInfo use the RPC_SECURITY_QOS structure to
	/// inquire about, or to set, the security quality of service for a binding handle.
	/// </para>
	/// <para>
	/// RPC supports the RPC_C_QOS_CAPABILITIES_LOCAL_MA_HINT hint (unsupported on Windows XP and earlier client editions, unsupported
	/// on Windows 2000 and earlier server editions). This hint is used only when dynamic endpoints and mutual authentication are used.
	/// Furthermore, it is not supported for the <c>ncadg_</c> protocol sequences. If this flag is used for a <c>ncadg_</c> protocol
	/// sequence, or without using mutual authentication, RPC_S_INVALID_ARG is returned from the RpcBindingSetAuthInfoEx function call.
	/// This flag is designed to prevent a Denial of Service Attack. Using this flag forces the RPC Runtime to ask the endpoint mapper
	/// only for endpoints registered by the principal specified in the <c>ServerPrincName</c> or <c>Sid</c> members. This prevents an
	/// attacker on the local machine from trying to trick your RPC client to connect to a spoof endpoint it has registered in the
	/// endpoint mapper. Note that since the attack is local only (such as from a terminal server machine with many users), the flag
	/// also works only for RPC calls made locally.
	/// </para>
	/// <para>
	/// <c>Note</c> Some security providers, such as Kerberos, support delegation-impersonation type. On Windows editions that support
	/// delegation-impersonation type, if the client has asked for delegation but the security provider is unable to provide it, the
	/// call fails with PRC_S_SEC_PKG_ERROR unless the RPC_C_QOS_CAPABILITIES_IGNORE_DELEGATE_FAILURE flag is specified.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_security_qos_v5_a typedef struct _RPC_SECURITY_QOS_V5_A {
	// unsigned long Version; unsigned long Capabilities; unsigned long IdentityTracking; unsigned long ImpersonationType; unsigned long
	// AdditionalSecurityInfoType; union { RPC_HTTP_TRANSPORT_CREDENTIALS_A *HttpCredentials; } u; void *Sid; unsigned int
	// EffectiveOnly; void *ServerSecurityDescriptor; } RPC_SECURITY_QOS_V5_A, *PRPC_SECURITY_QOS_V5_A;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._RPC_SECURITY_QOS_V5_A")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RPC_SECURITY_QOS_V5
	{
		/// <summary>
		/// Version of the <c>RPC_SECURITY_QOS</c> structure being used. This topic documents version 1 of the <c>RPC_SECURITY_QOS</c>
		/// structure. See RPC_SECURITY_QOS_V2, RPC_SECURITY_QOS_V3, RPC_SECURITY_QOS_V4 and RPC_SECURITY_QOS_V5 for other versions.
		/// </summary>
		public uint Version;

		/// <summary>
		/// <para>
		/// Security services being provided to the application. Capabilities is a set of flags that can be combined using the bitwise
		/// OR operator.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_DEFAULT</term>
		/// <term>Used when no provider-specific capabilities are needed.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_MUTUAL_AUTH</term>
		/// <term>
		/// Specifying this flag causes the RPC run time to request mutual authentication from the security provider. Some security
		/// providers do not support mutual authentication. If the security provider does not support mutual authentication, or the
		/// identity of the server cannot be established, a remote procedure call to such server fails with error RPC_S_SEC_PKG_ERROR.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_MAKE_FULLSIC</term>
		/// <term>Not currently implemented.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_ANY_AUTHORITY</term>
		/// <term>
		/// Accepts the client's credentials even if the certificate authority (CA) is not in the server's list of trusted CAs. This
		/// constant is used only by the SCHANNEL SSP.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_IGNORE_DELEGATE_FAILURE</term>
		/// <term>
		/// When specified, this flag directs the RPC runtime on the client to ignore an error to establish a security context that
		/// supports delegation. Normally, if the client asks for delegation and the security system cannot establish a security context
		/// that supports delegation, error RPC_S_SEC_PKG_ERROR is returned; when this flag is specified, no error is returned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_LOCAL_MA_HINT</term>
		/// <term>
		/// This flag specifies to RPC that the server is local to the machine making the RPC call. In this situation RPC instructs the
		/// endpoint mapper to pick up only endpoints registered by the principal specified in the ServerPrincName or Sid members (these
		/// members are available in RPC_SECURITY_QOS_V3, RPC_SECURITY_QOS_V4, and RPC_SECURITY_QOS_V5 only). See Remarks for more information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_CAPABILITIES_SCHANNEL_FULL_AUTH_IDENTITY</term>
		/// <term>
		/// If set, the RPC runtime uses the SChannel SSP to perform smartcard-based authentication without displaying a PIN prompt
		/// dialog box by the cryptographic services provider (CSP). In the call to RpcBindingSetAuthInfoEx, the AuthIdentity parameter
		/// must be a SEC_WINNT_AUTH_IDENTITY structure whose members contain the following: If the
		/// RPC_C_QOS_CAPABILITIES_SCHANNEL_FULL_AUTH_IDENTITY flag is used for any SSP other than SChannel, or if the members of
		/// SEC_WINNT_AUTH_IDENTITY do not conform to the above, RPC_S_INVALID_ARG will be returned by RpcBindingSetAuthInfoEx.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_QOS_CAPABILITIES Capabilities;

		/// <summary>
		/// <para>Sets the context tracking mode. Should be set to one of the values shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_QOS_IDENTITY_STATIC</term>
		/// <term>
		/// Security context is created only once and is never revised during the entire communication, even if the client side changes
		/// it. This is the default behavior if RPC_SECURITY_QOS is not specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_QOS_IDENTITY_DYNAMIC</term>
		/// <term>
		/// Context is revised whenever the ModifiedId in the client's token is changed. All protocols use the ModifiedId (see note).
		/// Windows 2000: All remote protocols (all protocols other than ncalrpc) use the AuthenticationID, also known as the LogonId,
		/// to track changes in the client's identity. The ncalrpc protocol uses ModifiedId.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_QOS_IDENTITY IdentityTracking;

		/// <summary>
		/// <para>Level at which the server process can impersonate the client.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_DEFAULT</term>
		/// <term>Uses the default impersonation level.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_ANONYMOUS</term>
		/// <term>
		/// Client does not provide identification information to the server. The server cannot impersonate the client or identify the
		/// client. Many servers reject calls with this impersonation type.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_IDENTIFY</term>
		/// <term>
		/// Server can obtain the client's identity, and impersonate the client to perform Access Control List (ACL) checks, but cannot
		/// impersonate the client. See Impersonation Levels for more information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_IMPERSONATE</term>
		/// <term>Server can impersonate the client's security context on its local system, but not on remote systems.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_IMP_LEVEL_DELEGATE</term>
		/// <term>
		/// The server can impersonate the client's security context while acting on behalf of the client. The server can also make
		/// outgoing calls to other servers while acting on behalf of the client. The server may use the client's security context on
		/// other machines to access local and remote resources as the client.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_IMP_LEVEL ImpersonationType;

		/// <summary>
		/// <para>Specifies the type of additional credentials present in the <c>u</c> union. The following constants are supported:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Supported Constants</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>No additional credentials are passed in the u union.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_AUTHN_INFO_TYPE_HTTP</term>
		/// <term>
		/// The HttpCredentials member of the u union points to a RPC_HTTP_TRANSPORT_CREDENTIALS structure. This value can be used only
		/// when the protocol sequence is ncacn_http. Any other protocol sequence returns RPC_S_INVALID_ARG.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RPC_C_AUTHN_INFO_TYPE AdditionalSecurityInfoType;

		/// <summary>
		/// Additional set of credentials to pass to RPC, in the form of an RPC_HTTP_TRANSPORT_CREDENTIALS structure. Used when the
		/// <c>AdditionalSecurityInfoType</c> member is set to RPC_C_AUTHN_INFO_TYPE_HTTP.
		/// </summary>
		public IntPtr u;

		/// <summary>
		/// Points to a security identifier (SID). The SID is an alternative to the <c>ServerPrincName</c> member, and only one can be
		/// specified. The <c>Sid</c> member cannot be set to non- <c>NULL</c> if the security provider is the SCHANNEL SSP. Some
		/// protocol sequences use <c>Sid</c> internally for security, and some use a <c>ServerPrincName</c>. For example, ncalrpc uses
		/// a <c>Sid</c> internally, and if the caller knows both the SID and the <c>ServerPrincName</c>, a call using <c>ncalrpc</c>
		/// can complete much faster in some cases if the SID is passed. In contrast, the <c>ncacn_</c> and <c>ncadg_</c> protocol
		/// sequences use a <c>ServerPrincName</c> internally, and therefore can execute calls faster when provided the <c>ServerPrincName</c>.
		/// </summary>
		public PSID Sid;

		/// <summary>If set, only enabled privileges are seen by the server.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool EffectiveOnly;

		/// <summary>A pointer to the SECURITY_DESCRIPTOR that identifies the server. It is required for mutual authentication.</summary>
		public PSECURITY_DESCRIPTOR ServerSecurityDescriptor;
	}

	/// <summary>The <c>RPC_STATS_VECTOR</c> structure contains statistics from the RPC run-time library on a per-server basis.</summary>
	/// <remarks>
	/// The statistics vector contains a count member ( <c>Count</c>), followed by an array of statistics. To obtain run-time
	/// statistics, an application calls RpcMgmtInqStats. The RPC run-time library allocates memory for the statistics vector. The
	/// application calls RpcMgmtStatsVectorFree to free the statistics vector.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-rpc_stats_vector typedef struct { unsigned int Count;
	// unsigned long Stats[1]; } RPC_STATS_VECTOR;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce.__unnamed_struct_0")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<RPC_STATS_VECTOR>), nameof(Count))]
	[StructLayout(LayoutKind.Sequential)]
	public struct RPC_STATS_VECTOR
	{
		/// <summary>Number of statistics values present in the array <c>Stats</c>.</summary>
		public uint Count;

		/// <summary>
		/// <para>
		/// Array of unsigned long integers representing server statistics that contains <c>Count</c> elements. Each array element
		/// contains an unsigned long value from the following list.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Constant</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_C_STATS_CALLS_IN</term>
		/// <term>The number of remote procedure calls received by the server.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_STATS_CALLS_OUT</term>
		/// <term>The number of remote procedure calls initiated by the server.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_STATS_PKTS_IN</term>
		/// <term>The number of network packets received by the server.</term>
		/// </item>
		/// <item>
		/// <term>RPC_C_STATS_PKTS_OUT</term>
		/// <term>The number of network packets sent by the server.</term>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public uint[] Stats;
	}

	/// <summary>Allows you to pass a particular user name and password to the run-time library for the purpose of authentication.</summary>
	/// <remarks>
	/// <para>When this structure is used with RPC, the structure must remain valid for the lifetime of the binding handle.</para>
	/// <para>The strings may be ANSI or Unicode, depending on the value you assign to the <c>Flags</c> member.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/sspi/ns-sspi-sec_winnt_auth_identity_w typedef struct
	// _SEC_WINNT_AUTH_IDENTITY_W { unsigned short *User; unsigned long UserLength; unsigned short *Domain; unsigned long DomainLength;
	// unsigned short *Password; unsigned long PasswordLength; unsigned long Flags; } SEC_WINNT_AUTH_IDENTITY_W, *PSEC_WINNT_AUTH_IDENTITY_W;
	[PInvokeData("sspi.h", MSDNShortId = "NS:sspi._SEC_WINNT_AUTH_IDENTITY_W")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct SEC_WINNT_AUTH_IDENTITY
	{
		/// <summary>A string that contains the user name.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string User;

		/// <summary>The length, in characters, of the user string, not including the terminating null character.</summary>
		public uint UserLength;

		/// <summary>A string that contains the domain name or the workgroup name.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string Domain;

		/// <summary>The length, in characters, of the domain string, not including the terminating null character.</summary>
		public uint DomainLength;

		/// <summary>
		/// A string that contains the password of the user in the domain or workgroup. When you have finished using the password,
		/// remove the sensitive information from memory by calling SecureZeroMemory. For more information about protecting the
		/// password, see Handling Passwords.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? Password;

		/// <summary>The length, in characters, of the password string, not including the terminating null character.</summary>
		public uint PasswordLength;

		/// <summary>
		/// <para>This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_WINNT_AUTH_IDENTITY_ANSI</term>
		/// <term>The strings in this structure are in ANSI format.</term>
		/// </item>
		/// <item>
		/// <term>SEC_WINNT_AUTH_IDENTITY_UNICODE</term>
		/// <term>The strings in this structure are in Unicode format.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SEC_WINNT_AUTH_IDENTITY_CHARSET Flags;

		/// <summary>Gets the default value of the instance and sets <see cref="Flags"/> to the value defined by the runtime.</summary>
		public static readonly SEC_WINNT_AUTH_IDENTITY Default = new() { Flags = OsCharSet };

		/// <summary>Initializes a new instance of the <see cref="SEC_WINNT_AUTH_IDENTITY"/> struct.</summary>
		/// <param name="user">The user name.</param>
		/// <param name="domain">The domain name or the workgroup name.</param>
		/// <param name="password">The password of the user in the domain or workgroup.</param>
		public SEC_WINNT_AUTH_IDENTITY(string user, string domain, string? password = null)
		{
			User = user;
			UserLength = (uint)(user?.Length ?? 0);
			Domain = domain;
			DomainLength = (uint)(domain?.Length ?? 0);
			Password = password;
			PasswordLength = (uint)(password?.Length ?? 0);
			Flags = OsCharSet;
		}

		private static readonly SEC_WINNT_AUTH_IDENTITY_CHARSET OsCharSet = StringHelper.GetCharSize() == 1 ? SEC_WINNT_AUTH_IDENTITY_CHARSET.SEC_WINNT_AUTH_IDENTITY_ANSI : SEC_WINNT_AUTH_IDENTITY_CHARSET.SEC_WINNT_AUTH_IDENTITY_UNICODE;
	}

	/// <summary>The <c>UUID_VECTOR</c> structure contains a list of UUIDs.</summary>
	/// <remarks>
	/// <para>
	/// The UUID vector contains a count member containing the total number of <c>UUID</c> s in the vector, followed by an array of
	/// pointers to <c>UUID</c> s.
	/// </para>
	/// <para>An application constructs a UUID vector to contain object <c>UUID</c> s to be exported or unexported from the name service.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/ns-rpcdce-uuid_vector typedef struct _UUID_VECTOR { unsigned long
	// Count; UUID *Uuid[1]; } UUID_VECTOR;
	[PInvokeData("rpcdce.h", MSDNShortId = "NS:rpcdce._UUID_VECTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UUID_VECTOR : IArrayStruct<Guid>
	{
		/// <summary>Number of UUIDs present in the array <c>Uuid</c>.</summary>
		public uint Count;

		/// <summary>Array of pointers to UUIDs that contains <c>Count</c> elements.</summary>
		public IntPtr Uuid;
	}
}