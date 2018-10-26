namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>
		/// These values specify an authentication level, which indicates the amount of authentication provided to help protect the integrity
		/// of the data. Each level includes the protection provided by the previous levels.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/com/com-authentication-level-constants
		[PInvokeData("rpcdce.h", MSDNShortId = "06c409e4-3772-45cf-8c31-c64f99aca244")]
		public enum RPC_C_AUTHN_LEVEL : uint
		{
			/// <summary>
			/// Tells DCOM to choose the authentication level using its normal security blanket negotiation algorithm. For more information,
			/// see Security Blanket Negotiation.
			/// </summary>
			RPC_C_AUTHN_LEVEL_DEFAULT = 0,
			/// <summary>Performs no authentication.</summary>
			RPC_C_AUTHN_LEVEL_NONE = 1,
			/// <summary>
			/// Authenticates the credentials of the client only when the client establishes a relationship with the server. Datagram
			/// transports always use RPC_AUTHN_LEVEL_PKT instead.
			/// </summary>
			RPC_C_AUTHN_LEVEL_CONNECT = 2,
			/// <summary>
			/// Authenticates only at the beginning of each remote procedure call when the server receives the request. Datagram transports
			/// use RPC_C_AUTHN_LEVEL_PKT instead.
			/// </summary>
			RPC_C_AUTHN_LEVEL_CALL = 3,
			/// <summary>Authenticates that all data received is from the expected client.</summary>
			RPC_C_AUTHN_LEVEL_PKT = 4,
			/// <summary>Authenticates and verifies that none of the data transferred between client and server has been modified.</summary>
			RPC_C_AUTHN_LEVEL_PKT_INTEGRITY = 5,
			/// <summary>Authenticates all previous levels and encrypts the argument value of each remote procedure call.</summary>
			RPC_C_AUTHN_LEVEL_PKT_PRIVACY = 6,
		}

		/// <summary>
		/// <para>Defines what the server authorizes.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// These constants are used by methods of the <c>IClientSecurity</c> interface. They are used in the
		/// <c>SOLE_AUTHENTICATION_SERVICE</c> structure, which is retrieved by the <c>CoQueryAuthenticationServices</c> function. They are
		/// also used in the <c>SOLE_AUTHENTICATION_INFO</c> structure, which in turn is a member of the <c>SOLE_AUTHENTICATION_LIST</c>
		/// structure. This structure, which is a list of authentication services, the authorization services they perform, and the
		/// authentication information for each service, is passed to the <c>CoInitializeSecurity</c> function and the
		/// <c>IClientSecurity::SetBlanket</c> method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/com/com-authorization-constants
		[PInvokeData("RpcDce.h", MSDNShortId = "a0bc9337-b7e4-41c5-ae36-4843fa7d98ce")]
		public enum RPC_C_AUTHZ : uint
		{
			/// <summary>The server performs no authorization. Currently, RPC_C_AUTHN_WINNT, RPC_C_AUTHN_GSS_SCHANNEL, and RPC_C_AUTHN_GSS_KERBEROS all use only RPC_C_AUTHZ_NONE.</summary>
			RPC_C_AUTHZ_NONE = 0,
			/// <summary>The server performs authorization based on the client's principal name. </summary>
			RPC_C_AUTHZ_NAME = 1,
			/// <summary>The server performs authorization checking using the client's DCE privilege attribute certificate (PAC) information, which is sent to the server with each remote procedure call made using the binding handle. Generally, access is checked against DCE access control lists (ACLs). </summary>
			RPC_C_AUTHZ_DCE = 2,
			/// <summary>DCOM can choose the authorization level using its normal security blanket negotiation algorithm. For more information, see Security Blanket Negotiation.</summary>
			RPC_C_AUTHZ_DEFAULT = 0xffffffff,
		}

		/// <summary>
		/// Specifies an impersonation level, which indicates the amount of authority given to the server when it is impersonating the client.
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
		// https://docs.microsoft.com/en-us/windows/desktop/com/com-impersonation-level-constants
		[PInvokeData("RpcDce.h", MSDNShortId = "ea5a3b46-b607-4192-a3cc-b2ec55ca94a6")]
		public enum RPC_C_IMP_LEVEL : uint
		{
			/// <summary>DCOM can choose the impersonation level using its normal security blanket negotiation algorithm. For more information, see Security Blanket Negotiation.</summary>
			RPC_C_IMP_LEVEL_DEFAULT = 0,
			/// <summary>The client is anonymous to the server. The server process can impersonate the client, but the impersonation token will not contain any information and cannot be used.</summary>
			RPC_C_IMP_LEVEL_ANONYMOUS = 1,
			/// <summary>The server can obtain the client's identity. The server can impersonate the client for ACL checking, but it cannot access system objects as the client. </summary>
			RPC_C_IMP_LEVEL_IDENTIFY = 2,
			/// <summary>The server process can impersonate the client's security context while acting on behalf of the client. This level of impersonation can be used to access local resources such as files. When impersonating at this level, the impersonation token can only be passed across one machine boundary. The Schannel authentication service only supports this level of impersonation. </summary>
			RPC_C_IMP_LEVEL_IMPERSONATE = 3,
			/// <summary>The server process can impersonate the client's security context while acting on behalf of the client. The server process can also make outgoing calls to other servers while acting on behalf of the client, using cloaking. The server may use the client's security context on other machines to access local and remote resources as the client. When impersonating at this level, the impersonation token can be passed across any number of computer boundaries.</summary>
			RPC_C_IMP_LEVEL_DELEGATE = 4,
		}
	}
}