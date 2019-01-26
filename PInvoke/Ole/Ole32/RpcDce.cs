using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>
		/// Defines authentication services by identifying the security package that provides the service, such as NTLMSSP, Kerberos, or Schannel.
		/// </summary>
		/// <remarks>
		/// These constants are used in the <c>SOLE_AUTHENTICATION_SERVICE</c> and the <c>SOLE_AUTHENTICATION_INFO</c> structures. The
		/// <c>SOLE_AUTHENTICATION_SERVICE</c> structure is passed by the server to the <c>CoInitializeSecurity</c> function and can be
		/// retrieved by the <c>CoQueryAuthenticationServices</c> function. A pointer to a <c>SOLE_AUTHENTICATION_INFO</c> structure is
		/// passed by the client to <c>CoInitializeSecurity</c>. For more information on the security packages identified by these values,
		/// such as NTLMSSP and Kerberos, see COM and Security Packages.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/com/com-authentication-service-constants
		[PInvokeData("rpcdce.h", MSDNShortId = "c16a8e52-a7f9-40d9-99ef-10b382b5cb3c")]
		public enum RPC_C_AUTHN : uint
		{
			/// <summary>No authentication.</summary>
			RPC_C_AUTHN_NONE = 0,

			/// <summary>DCE private key authentication.</summary>
			RPC_C_AUTHN_DCE_PRIVATE = 1,

			/// <summary>DCE public key authentication.</summary>
			RPC_C_AUTHN_DCE_PUBLIC = 2,

			/// <summary>DEC public key authentication. Reserved for future use.</summary>
			RPC_C_AUTHN_DEC_PUBLIC = 4,

			/// <summary>Snego security support provider.</summary>
			RPC_C_AUTHN_GSS_NEGOTIATE = 9,

			/// <summary>NTLMSSP</summary>
			RPC_C_AUTHN_WINNT = 10,

			/// <summary>Schannel security support provider. This authentication service supports SSL 2.0, SSL 3.0, TLS, and PCT.</summary>
			RPC_C_AUTHN_GSS_SCHANNEL = 14,

			/// <summary>Kerberos security support provider.</summary>
			RPC_C_AUTHN_GSS_KERBEROS = 16,

			/// <summary>DPA security support provider.</summary>
			RPC_C_AUTHN_DPA = 17,

			/// <summary>MSN security support provider.</summary>
			RPC_C_AUTHN_MSN = 18,

			/// <summary>Kernel security support provider.</summary>
			RPC_C_AUTHN_KERNEL = 20,

			/// <summary>Digest security support provider.</summary>
			RPC_C_AUTHN_DIGEST = 21,

			/// <summary>NEGO extender security support provider.</summary>
			RPC_C_AUTHN_NEGO_EXTENDER = 30,

			/// <summary>PKU2U security support provider.</summary>
			RPC_C_AUTHN_PKU2U = 31,

			/// <summary>MQ security support provider.</summary>
			RPC_C_AUTHN_MQ = 100,

			/// <summary>
			/// The system default authentication service. When this value is specified, COM uses its normal security blanket negotiation
			/// algorithm to pick an authentication service. For more information, see Security Blanket Negotiation.
			/// </summary>
			RPC_C_AUTHN_DEFAULT = 0xFFFFFFFF,

			/// <summary/>
			RPC_C_AUTHN_LIVE_SSP = 32,

			/// <summary/>
			RPC_C_AUTHN_LIVEXP_SSP = 35,

			/// <summary/>
			RPC_C_AUTHN_CLOUD_AP = 36,

			/// <summary/>
			RPC_C_AUTHN_MSONLINE = 82,
		}

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
			/// <summary>
			/// The server performs no authorization. Currently, RPC_C_AUTHN_WINNT, RPC_C_AUTHN_GSS_SCHANNEL, and RPC_C_AUTHN_GSS_KERBEROS
			/// all use only RPC_C_AUTHZ_NONE.
			/// </summary>
			RPC_C_AUTHZ_NONE = 0,

			/// <summary>The server performs authorization based on the client's principal name.</summary>
			RPC_C_AUTHZ_NAME = 1,

			/// <summary>
			/// The server performs authorization checking using the client's DCE privilege attribute certificate (PAC) information, which is
			/// sent to the server with each remote procedure call made using the binding handle. Generally, access is checked against DCE
			/// access control lists (ACLs).
			/// </summary>
			RPC_C_AUTHZ_DCE = 2,

			/// <summary>
			/// DCOM can choose the authorization level using its normal security blanket negotiation algorithm. For more information, see
			/// Security Blanket Negotiation.
			/// </summary>
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
			/// The server process can impersonate the client's security context while acting on behalf of the client. The server process can
			/// also make outgoing calls to other servers while acting on behalf of the client, using cloaking. The server may use the
			/// client's security context on other machines to access local and remote resources as the client. When impersonating at this
			/// level, the impersonation token can be passed across any number of computer boundaries.
			/// </summary>
			RPC_C_IMP_LEVEL_DELEGATE = 4,
		}

		/// <summary>Provides a RPC_AUTH_IDENTITY_HANDLE.</summary>
		[PInvokeData("rpcdce.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RPC_AUTH_IDENTITY_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="RPC_AUTH_IDENTITY_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public RPC_AUTH_IDENTITY_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="RPC_AUTH_IDENTITY_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static RPC_AUTH_IDENTITY_HANDLE NULL => new RPC_AUTH_IDENTITY_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="RPC_AUTH_IDENTITY_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(RPC_AUTH_IDENTITY_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="RPC_AUTH_IDENTITY_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator RPC_AUTH_IDENTITY_HANDLE(IntPtr h) => new RPC_AUTH_IDENTITY_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(RPC_AUTH_IDENTITY_HANDLE h1, RPC_AUTH_IDENTITY_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(RPC_AUTH_IDENTITY_HANDLE h1, RPC_AUTH_IDENTITY_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is RPC_AUTH_IDENTITY_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a RPC_AUTHZ_HANDLE.</summary>
		[PInvokeData("rpcdce.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RPC_AUTHZ_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="RPC_AUTHZ_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public RPC_AUTHZ_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="RPC_AUTHZ_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static RPC_AUTHZ_HANDLE NULL => new RPC_AUTHZ_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="RPC_AUTHZ_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(RPC_AUTHZ_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="RPC_AUTHZ_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator RPC_AUTHZ_HANDLE(IntPtr h) => new RPC_AUTHZ_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(RPC_AUTHZ_HANDLE h1, RPC_AUTHZ_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(RPC_AUTHZ_HANDLE h1, RPC_AUTHZ_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is RPC_AUTHZ_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}
	}
}