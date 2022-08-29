#pragma warning disable IDE1006 // Naming Styles
namespace Vanara.PInvoke;

public static partial class FwpUClnt
{
	/// <summary>
	/// Additional configuration information for the IPsec SA hash algorithm as specified by a <c>IPSEC_AUTH_CONFIG</c> which maps to a <c>UINT8</c>.
	/// </summary>
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_AUTH_TRANSFORM_ID0_")]
	public enum IPSEC_AUTH_CONFIG : byte
	{
		/// <summary>
		/// HMAC (Hash Message Authentication Code) secret key authentication algorithm. MD5 (Message Digest) data integrity and data origin
		/// authentication algorithm.
		/// </summary>
		IPSEC_AUTH_CONFIG_HMAC_MD5_96,

		/// <summary>
		/// HMAC secret key authentication algorithm. SHA-1 (Secure Hash Algorithm) data integrity and data origin authentication algorithm.
		/// </summary>
		IPSEC_AUTH_CONFIG_HMAC_SHA_1_96,

		/// <summary>HMAC secret key authentication algorithm. SHA-256 data integrity and data origin authentication algorithm.</summary>
		IPSEC_AUTH_CONFIG_HMAC_SHA_256_128,

		/// <summary>
		/// GCM (Galois Counter Mode) secret key authentication algorithm. AES(Advanced Encryption Standard) data integrity and data origin
		/// authentication algorithm, with 128-bit key.
		/// </summary>
		IPSEC_AUTH_CONFIG_GCM_AES_128,

		/// <summary>
		/// GCM secret key authentication algorithm. AES data integrity and data origin authentication algorithm, with 192-bit key.
		/// </summary>
		IPSEC_AUTH_CONFIG_GCM_AES_192,

		/// <summary>
		/// GCM secret key authentication algorithm. AES data integrity and data origin authentication algorithm, with 256-bit key.
		/// </summary>
		IPSEC_AUTH_CONFIG_GCM_AES_256,

		/// <summary/>
		IPSEC_AUTH_CONFIG_MAX,
	}

	/// <summary>
	/// The <c>IPSEC_AUTH_TYPE</c> enumerated type indicates the type of hash algorithm used in an IPsec SA for data origin authentication
	/// and integrity protection.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ne-ipsectypes-ipsec_auth_type typedef enum IPSEC_AUTH_TYPE_ {
	// IPSEC_AUTH_MD5 = 0, IPSEC_AUTH_SHA_1, IPSEC_AUTH_SHA_256, IPSEC_AUTH_AES_128, IPSEC_AUTH_AES_192, IPSEC_AUTH_AES_256, IPSEC_AUTH_MAX } IPSEC_AUTH_TYPE;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NE:ipsectypes.IPSEC_AUTH_TYPE_")]
	public enum IPSEC_AUTH_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies MD5 hash algorithm.</para>
		/// <para>See</para>
		/// <para>RFC 1321</para>
		/// <para>for further information.</para>
		/// </summary>
		IPSEC_AUTH_MD5,

		/// <summary>
		/// <para>Specifies SHA 1 hash algorithm.</para>
		/// <para>See NIST, FIPS PUB 180-1 for more information.</para>
		/// </summary>
		IPSEC_AUTH_SHA_1,

		/// <summary>
		/// <para>Specifies SHA 256 hash algorithm.</para>
		/// <para>See NIST, Draft FIPS PUB 180-2 for more information.</para>
		/// <para><c>Note</c> Available only on Windows Server 2008, Windows Vista with SP1, and later.</para>
		/// </summary>
		IPSEC_AUTH_SHA_256,

		/// <summary>
		/// <para>Specifies 128-bit AES hash algorithm.</para>
		/// <para><c>Note</c> Available only on Windows Server 2008, Windows Vista with SP1, and later.</para>
		/// </summary>
		IPSEC_AUTH_AES_128,

		/// <summary>
		/// <para>Specifies 192-bit AES hash algorithm.</para>
		/// <para><c>Note</c> Available only on Windows Server 2008, Windows Vista with SP1, and later.</para>
		/// </summary>
		IPSEC_AUTH_AES_192,

		/// <summary>
		/// <para>Specifies 256-bit AES hash algorithm.</para>
		/// <para><c>Note</c> Available only on Windows Server 2008, Windows Vista with SP1, and later.</para>
		/// </summary>
		IPSEC_AUTH_AES_256,

		/// <summary>Maximum value for testing purposes.</summary>
		IPSEC_AUTH_MAX,
	}

	/// <summary>
	/// Additional configuration information for the encryption algorithm as specified by <c>IPSEC_CIPHER_CONFIG</c> which maps to a <c>UINT8</c>.
	/// </summary>
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_CIPHER_TRANSFORM_ID0_")]
	public enum IPSEC_CIPHER_CONFIG : byte
	{
		/// <summary>DES (Data Encryption Standard) algorithm. CBC (Cipher Block Chaining) mode of operation.</summary>
		IPSEC_CIPHER_CONFIG_CBC_DES = 1,

		/// <summary>3DES algorithm. CBC mode of operation.</summary>
		IPSEC_CIPHER_CONFIG_CBC_3DES = 2,

		/// <summary>AES-128 (Advanced Encryption Standard) algorithm. CBC mode of operation.</summary>
		IPSEC_CIPHER_CONFIG_CBC_AES_128 = 3,

		/// <summary>AES-192 algorithm. CBC mode of operation.</summary>
		IPSEC_CIPHER_CONFIG_CBC_AES_192 = 4,

		/// <summary>AES-256 algorithm. CBC mode of operation.</summary>
		IPSEC_CIPHER_CONFIG_CBC_AES_256 = 5,

		/// <summary>AES-128 algorithm. GCM (Galois Counter Mode) mode of operation.</summary>
		IPSEC_CIPHER_CONFIG_GCM_AES_128 = 6,

		/// <summary>AES-192 algorithm. GCM (Galois Counter Mode) mode of operation.</summary>
		IPSEC_CIPHER_CONFIG_GCM_AES_192 = 7,

		/// <summary>AES-256 algorithm. GCM (Galois Counter Mode) mode of operation.</summary>
		IPSEC_CIPHER_CONFIG_GCM_AES_256 = 8,

		/// <summary/>
		IPSEC_CIPHER_CONFIG_MAX = 9,
	}

	/// <summary>
	/// The <c>IPSEC_CIPHER_TYPE</c> enumerated type indicates the type of encryption algorithm used in an IPsec SA for data privacy.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ne-ipsectypes-ipsec_cipher_type typedef enum IPSEC_CIPHER_TYPE_ {
	// IPSEC_CIPHER_TYPE_DES = 1, IPSEC_CIPHER_TYPE_3DES, IPSEC_CIPHER_TYPE_AES_128, IPSEC_CIPHER_TYPE_AES_192, IPSEC_CIPHER_TYPE_AES_256,
	// IPSEC_CIPHER_TYPE_MAX } IPSEC_CIPHER_TYPE;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NE:ipsectypes.IPSEC_CIPHER_TYPE_")]
	public enum IPSEC_CIPHER_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Specifies DES encryption.</para>
		/// </summary>
		IPSEC_CIPHER_TYPE_DES,

		/// <summary>Specifies 3DES encryption.</summary>
		IPSEC_CIPHER_TYPE_3DES,

		/// <summary>Specifies AES-128 encryption.</summary>
		IPSEC_CIPHER_TYPE_AES_128,

		/// <summary>Specifies AES-192 encryption.</summary>
		IPSEC_CIPHER_TYPE_AES_192,

		/// <summary>Specifies AES-256 encryption.</summary>
		IPSEC_CIPHER_TYPE_AES_256,

		/// <summary>Maximum value for testing only.</summary>
		IPSEC_CIPHER_TYPE_MAX,
	}

	/// <summary>Flags for IPSEC_DOSP_OPTIONS0.</summary>
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_DOSP_OPTIONS0_")]
	[Flags]
	public enum IPSEC_DOSP_FLAG : uint
	{
		/// <summary>Allows the IKEv1 keying module. By default, it is blocked.</summary>
		IPSEC_DOSP_FLAG_ENABLE_IKEV1 = 0x00000001,

		/// <summary>Allows the IKEv2 keying module. By default, it is blocked.</summary>
		IPSEC_DOSP_FLAG_ENABLE_IKEV2 = 0x00000002,

		/// <summary>Blocks the AuthIP keying module. By default, it is allowed.</summary>
		IPSEC_DOSP_FLAG_DISABLE_AUTHIP = 0x00000004,

		/// <summary>
		/// Allows all matching IPv4 traffic and non-IPsec IPv6 traffic. By default, all IPv4 traffic and non-IPsecIPv6 traffic, except IPv6
		/// ICMP, will be blocked.
		/// </summary>
		IPSEC_DOSP_FLAG_DISABLE_DEFAULT_BLOCK = 0x00000008,

		/// <summary>Blocks all matching IPv6 traffic.</summary>
		IPSEC_DOSP_FLAG_FILTER_BLOCK = 0x00000010,

		/// <summary>Allows all matching IPv6 traffic.</summary>
		IPSEC_DOSP_FLAG_FILTER_EXEMPT = 0x00000020,
	}

	/// <summary>The <c>IPSEC_FAILURE_POINT</c> enumerated type specifies at what point IPsec has failed.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ne-ipsectypes-ipsec_failure_point typedef enum IPSEC_FAILURE_POINT_ {
	// IPSEC_FAILURE_NONE = 0, IPSEC_FAILURE_ME, IPSEC_FAILURE_PEER, IPSEC_FAILURE_POINT_MAX } IPSEC_FAILURE_POINT;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NE:ipsectypes.IPSEC_FAILURE_POINT_")]
	public enum IPSEC_FAILURE_POINT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>IPsec has not failed.</para>
		/// </summary>
		IPSEC_FAILURE_NONE,

		/// <summary>The local system is the failure point.</summary>
		IPSEC_FAILURE_ME,

		/// <summary>A peer system is the failure point.</summary>
		IPSEC_FAILURE_PEER,

		/// <summary>Maximum value for testing only.</summary>
		IPSEC_FAILURE_POINT_MAX,
	}

	/// <summary>Flags for IPSEC_KEY_MANAGER0.</summary>
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes._IPSEC_KEY_MANAGER0")]
	[Flags]
	public enum IPSEC_KEY_MANAGER_FLAG : uint
	{
		/// <summary>
		/// Specifies that the TIA will be able to accept key notifications and also potentially dictate keys. If this flag is not set, the
		/// TIA can only accept key notifications and will not be able to dictate keys.
		/// </summary>
		IPSEC_KEY_MANAGER_FLAG_DICTATE_KEY = 0x00000001
	}

	/// <summary>Flags for <see cref="IPSEC_KEYING_POLICY1"/></summary>
	[Flags]
	public enum IPSEC_KEYING_POLICY_FLAG : uint
	{
		/// <summary>Forces the use of a Kerberos proxy server when acting as initiator.</summary>
		IPSEC_KEYING_POLICY_FLAG_TERMINATING_MATCH = 0x00000001
	}

	/// <summary>
	/// The <c>IPSEC_PFS_GROUP</c> enumerated type specifies the Diffie Hellman algorithm that should be used for Quick Mode PFS (Perfect
	/// Forward Secrecy).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ne-ipsectypes-ipsec_pfs_group typedef enum IPSEC_PFS_GROUP_ {
	// IPSEC_PFS_NONE = 0, IPSEC_PFS_1, IPSEC_PFS_2, IPSEC_PFS_2048, IPSEC_PFS_14, IPSEC_PFS_ECP_256, IPSEC_PFS_ECP_384, IPSEC_PFS_MM,
	// IPSEC_PFS_24, IPSEC_PFS_MAX } IPSEC_PFS_GROUP;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NE:ipsectypes.IPSEC_PFS_GROUP_")]
	public enum IPSEC_PFS_GROUP
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies no Quick Mode PFS.</para>
		/// </summary>
		IPSEC_PFS_NONE = 0,

		/// <summary>Specifies Diffie Hellman group 1.</summary>
		IPSEC_PFS_1,

		/// <summary>Specifies Diffie Hellman group 2.</summary>
		IPSEC_PFS_2,

		/// <summary>Specifies Diffie Hellman group 14.</summary>
		IPSEC_PFS_2048,

		/// <summary>
		/// <para>Specifies Diffie Hellman group 14.</para>
		/// <para>
		/// <c>Note</c> This group was called Diffie Hellman group 2048 when it was introduced. The name has since been changed to match
		/// standard terminology.
		/// </para>
		/// <para><c>Note</c> Available only for Windows 8 and Windows Server 2012.</para>
		/// </summary>
		IPSEC_PFS_14,

		/// <summary>Specifies Diffie Hellman ECP group 256.</summary>
		IPSEC_PFS_ECP_256,

		/// <summary>Specifies Diffie Hellman ECP group 384.</summary>
		IPSEC_PFS_ECP_384,

		/// <summary>Use the same Diffie Hellman as the main mode that contains this quick mode.</summary>
		IPSEC_PFS_MM,

		/// <summary>
		/// <para>Specifies Diffie Hellman group 24.</para>
		/// <para><c>Note</c> Available only for Windows 8 and Windows Server 2012.</para>
		/// </summary>
		IPSEC_PFS_24,

		/// <summary>Maximum value for testing only.</summary>
		IPSEC_PFS_MAX,
	}

	/// <summary>Flags for <c>IPSEC_TUNNEL_POLICY0</c>.</summary>
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TUNNEL_POLICY0_")]
	[Flags]
	public enum IPSEC_POLICY_FLAG : uint
	{
		/// <summary>Do negotiation discovery in secure ring.</summary>
		IPSEC_POLICY_FLAG_ND_SECURE = 0x00000002,

		/// <summary>Do negotiation discovery in the untrusted perimeter zone.</summary>
		IPSEC_POLICY_FLAG_ND_BOUNDARY = 0x00000004,

		/// <summary>Clear the "DontFragment" bit on the outer IP header of an IPsec tunneled packet.</summary>
		IPSEC_POLICY_FLAG_CLEAR_DF_ON_TUNNEL = 0x00000008,

		/// <summary>
		/// If set, IPsec expects that either the local or remote machine is behind a network address translation (NAT) device, but not both.
		/// This allows for less secure, but more flexible behavior.
		/// </summary>
		IPSEC_POLICY_FLAG_NAT_ENCAP_ALLOW_PEER_BEHIND_NAT = 0x00000010,

		/// <summary>If set, IPsec expects default ports when either the local, the remote, or both machines are behind a NAT device.</summary>
		IPSEC_POLICY_FLAG_NAT_ENCAP_ALLOW_GENERAL_NAT_TRAVERSAL = 0x00000020,

		/// <summary>If set, Internet Key Exchange (IKE) will not send the ISAKMP attribute for 'seconds' lifetime during quick mode negotiation.</summary>
		IPSEC_POLICY_FLAG_DONT_NEGOTIATE_SECOND_LIFETIME = 0x00000040,

		/// <summary>If set, IKE will not send the ISAKMP attribute for 'byte' lifetime during quick mode negotiation.</summary>
		IPSEC_POLICY_FLAG_DONT_NEGOTIATE_BYTE_LIFETIME = 0x00000080,

		/// <summary>Negotiate IPv6 inside IPv4 IPsec tunneling. Applicable only for tunnel mode policy, and supported only by IKEv2.</summary>
		IPSEC_POLICY_FLAG_ENABLE_V6_IN_V4_TUNNELING = 0x00000100,

		/// <summary>
		/// Enable calls to RAS VPN server for address assignment. Applicable only for tunnel mode policy, and supported only by IKEv2.
		/// </summary>
		IPSEC_POLICY_FLAG_ENABLE_SERVER_ADDR_ASSIGNMENT = 0x00000200,

		/// <summary>
		/// Allow outbound connections to bypass the tunnel policy. Applicable only for tunnel mode policy on a tunnel gateway. Do not set on
		/// a tunnel client.
		/// </summary>
		IPSEC_POLICY_FLAG_TUNNEL_ALLOW_OUTBOUND_CLEAR_CONNECTION = 0x00000400,

		/// <summary>Allow ESP or UDP 500/4500 traffic to bypass the tunnel. Applicable only for tunnel mode policy.</summary>
		IPSEC_POLICY_FLAG_TUNNEL_BYPASS_ALREADY_SECURE_CONNECTION = 0x00000800,

		/// <summary>Allow ICMPv6 traffic to bypass the tunnel. Applicable only for tunnel mode policy.</summary>
		IPSEC_POLICY_FLAG_TUNNEL_BYPASS_ICMPV6 = 0x00001000,

		/// <summary>Allow key dictation for quick mode policy. Applicable only for AuthIP policy.</summary>
		IPSEC_POLICY_FLAG_KEY_MANAGER_ALLOW_DICTATE_KEY = 0x00002000,

		/// <summary>Allow key notification for quick mode policy. Applicable for AuthIP/IKE/IKEv2 policy.</summary>
		IPSEC_POLICY_FLAG_KEY_MANAGER_ALLOW_NOTIFY_KEY = 0x00004000,

		/// <summary/>
		IPSEC_POLICY_FLAG_RESERVED1 = 0x00008000,

		/// <summary/>
		IPSEC_POLICY_FLAG_SITE_TO_SITE_TUNNEL = 0x00010000,
	}

	/// <summary>Flags for IPSEC_SA_BUNDLE0.</summary>
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_BUNDLE0_")]
	[Flags]
	public enum IPSEC_SA_BUNDLE_FLAG : uint
	{
		/// <summary>Negotiation discovery is enabled in secure ring.</summary>
		IPSEC_SA_BUNDLE_FLAG_ND_SECURE = 0x00000001,

		/// <summary>Negotiation discovery in enabled in the untrusted perimeter zone.</summary>
		IPSEC_SA_BUNDLE_FLAG_ND_BOUNDARY = 0x00000002,

		/// <summary>Peer is in untrusted perimeter zone ring and a NAT is in the way. Used with negotiation discovery.</summary>
		IPSEC_SA_BUNDLE_FLAG_ND_PEER_NAT_BOUNDARY = 0x00000004,

		/// <summary>Indicates that this is an SA for connections that require guaranteed encryption.</summary>
		IPSEC_SA_BUNDLE_FLAG_GUARANTEE_ENCRYPTION = 0x00000008,

		/// <summary>Indicates that this is an SA to an NLB server.</summary>
		IPSEC_SA_BUNDLE_FLAG_NLB = 0x00000010,

		/// <summary>Indicates that this SA should bypass machine LUID verification.</summary>
		IPSEC_SA_BUNDLE_FLAG_NO_MACHINE_LUID_VERIFY = 0x00000020,

		/// <summary>Indicates that this SA should bypass impersonation LUID verification.</summary>
		IPSEC_SA_BUNDLE_FLAG_NO_IMPERSONATION_LUID_VERIFY = 0x00000040,

		/// <summary>Indicates that this SA should bypass explicit credential handle matching.</summary>
		IPSEC_SA_BUNDLE_FLAG_NO_EXPLICIT_CRED_MATCH = 0x00000080,

		/// <summary>Allows an SA formed with a peer name to carry traffic that does not have an associated peer target.</summary>
		IPSEC_SA_BUNDLE_FLAG_ALLOW_NULL_TARGET_NAME_MATCH = 0x00000200,

		/// <summary>
		/// Clears the <c>DontFragment</c> bit on the outer IP header of an IPsec-tunneled packet. This flag is applicable only to tunnel
		/// mode SAs.
		/// </summary>
		IPSEC_SA_BUNDLE_FLAG_CLEAR_DF_ON_TUNNEL = 0x00000400,

		/// <summary>
		/// Default encapsulation ports (4500 and 4000) can be used when matching this SA with packets on outbound connections that do not
		/// have an associated IPsec-NAT-shim context.
		/// </summary>
		IPSEC_SA_BUNDLE_FLAG_ASSUME_UDP_CONTEXT_OUTBOUND = 0x00000800,

		/// <summary>Peer has negotiation discovery enabled, and is on a perimeter network.</summary>
		IPSEC_SA_BUNDLE_FLAG_ND_PEER_BOUNDARY = 0x00001000,

		/// <summary>
		/// Suppresses the duplicate SA deletion logic. THis logic is performed by the kernel when an outbound SA is added, to prevent
		/// unnecessary duplicate SAs.
		/// </summary>
		IPSEC_SA_BUNDLE_FLAG_SUPPRESS_DUPLICATE_DELETION = 0x00002000,

		/// <summary>Indicates that the peer computer supports negotiating a separate SA for connections that require guaranteed encryption.</summary>
		IPSEC_SA_BUNDLE_FLAG_PEER_SUPPORTS_GUARANTEE_ENCRYPTION = 0x00004000,

		/// <summary/>
		IPSEC_SA_BUNDLE_FLAG_FORCE_INBOUND_CONNECTIONS = 0x00008000,

		/// <summary/>
		IPSEC_SA_BUNDLE_FLAG_FORCE_OUTBOUND_CONNECTIONS = 0x00010000,

		/// <summary/>
		IPSEC_SA_BUNDLE_FLAG_FORWARD_PATH_INITIATOR = 0x00020000,

		/// <summary/>
		IPSEC_SA_BUNDLE_FLAG_ENABLE_OPTIONAL_ASYMMETRIC_IDLE = 0x0040000,

		/// <summary/>
		IPSEC_SA_BUNDLE_FLAG_USING_DICTATED_KEYS = 0x00080000,

		/// <summary/>
		IPSEC_SA_BUNDLE_FLAG_LOCALLY_DICTATED_KEYS = 0x00100000,

		/// <summary/>
		IPSEC_SA_BUNDLE_FLAG_SA_OFFLOADED = 0x00200000,

		/// <summary/>
		/// <summary/>
		IPSEC_SA_BUNDLE_FLAG_IP_IN_IP_PKT = 0x00400000,

		/// <summary/>
		IPSEC_SA_BUNDLE_FLAG_LOW_POWER_MODE_SUPPORT = 0x00800000,
	}

	/// <summary>
	/// The <c>IPSEC_SA_CONTEXT_EVENT_TYPE0</c> enumeration specifies the type of IPsec security association (SA) context change event.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ne-ipsectypes-ipsec_sa_context_event_type0 typedef enum
	// IPSEC_SA_CONTEXT_EVENT_TYPE0_ { IPSEC_SA_CONTEXT_EVENT_ADD = 1, IPSEC_SA_CONTEXT_EVENT_DELETE, IPSEC_SA_CONTEXT_EVENT_MAX } IPSEC_SA_CONTEXT_EVENT_TYPE0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NE:ipsectypes.IPSEC_SA_CONTEXT_EVENT_TYPE0_")]
	public enum IPSEC_SA_CONTEXT_EVENT_TYPE0
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>A new IPsec SA context was added.</para>
		/// </summary>
		IPSEC_SA_CONTEXT_EVENT_ADD,

		/// <summary>An IPsec SA context was deleted.</summary>
		IPSEC_SA_CONTEXT_EVENT_DELETE,

		/// <summary>Maximum value for testing purposes.</summary>
		IPSEC_SA_CONTEXT_EVENT_MAX,
	}

	/// <summary>The <c>IPSEC_TOKEN_MODE</c> enumerated type specifies different IPsec modes in which a token can be obtained.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ne-ipsectypes-ipsec_token_mode typedef enum IPSEC_TOKEN_MODE_ {
	// IPSEC_TOKEN_MODE_MAIN = 0, IPSEC_TOKEN_MODE_EXTENDED, IPSEC_TOKEN_MODE_MAX } IPSEC_TOKEN_MODE;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NE:ipsectypes.IPSEC_TOKEN_MODE_")]
	public enum IPSEC_TOKEN_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Token was obtained in main mode.</para>
		/// </summary>
		IPSEC_TOKEN_MODE_MAIN,

		/// <summary>Token was obtained in extended mode.</summary>
		IPSEC_TOKEN_MODE_EXTENDED,

		/// <summary>Maximum value for testing only.</summary>
		IPSEC_TOKEN_MODE_MAX,
	}

	/// <summary>The <c>IPSEC_TOKEN_PRINCIPAL</c> enumerated type specifies an access token principal.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ne-ipsectypes-ipsec_token_principal typedef enum IPSEC_TOKEN_PRINCIPAL_
	// { IPSEC_TOKEN_PRINCIPAL_LOCAL = 0, IPSEC_TOKEN_PRINCIPAL_PEER, IPSEC_TOKEN_PRINCIPAL_MAX } IPSEC_TOKEN_PRINCIPAL;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NE:ipsectypes.IPSEC_TOKEN_PRINCIPAL_")]
	public enum IPSEC_TOKEN_PRINCIPAL
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The principal for the IPsec access token is "Local".</para>
		/// </summary>
		IPSEC_TOKEN_PRINCIPAL_LOCAL,

		/// <summary>The principal for the IPsec access token is "Peer".</summary>
		IPSEC_TOKEN_PRINCIPAL_PEER,

		/// <summary>Maximum value for testing only.</summary>
		IPSEC_TOKEN_PRINCIPAL_MAX,
	}

	/// <summary>The <c>IPSEC_TOKEN_TYPE</c> enumerated type specifies an IPsec token type.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ne-ipsectypes-ipsec_token_type typedef enum IPSEC_TOKEN_TYPE_ {
	// IPSEC_TOKEN_TYPE_MACHINE = 0, IPSEC_TOKEN_TYPE_IMPERSONATION, IPSEC_TOKEN_TYPE_MAX } IPSEC_TOKEN_TYPE;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NE:ipsectypes.IPSEC_TOKEN_TYPE_")]
	public enum IPSEC_TOKEN_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Machine token.</para>
		/// </summary>
		IPSEC_TOKEN_TYPE_MACHINE,

		/// <summary>Impersonation token.</summary>
		IPSEC_TOKEN_TYPE_IMPERSONATION,

		/// <summary>Maximum value for testing only.</summary>
		IPSEC_TOKEN_TYPE_MAX,
	}

	/// <summary>The <c>IPSEC_TRAFFIC_TYPE</c> enumerated type specifies the type of IPsec traffic being described.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ne-ipsectypes-ipsec_traffic_type typedef enum IPSEC_TRAFFIC_TYPE_ {
	// IPSEC_TRAFFIC_TYPE_TRANSPORT = 0, IPSEC_TRAFFIC_TYPE_TUNNEL, IPSEC_TRAFFIC_TYPE_MAX } IPSEC_TRAFFIC_TYPE;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NE:ipsectypes.IPSEC_TRAFFIC_TYPE_")]
	public enum IPSEC_TRAFFIC_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies transport traffic.</para>
		/// </summary>
		IPSEC_TRAFFIC_TYPE_TRANSPORT,

		/// <summary>Specifies tunnel traffic.</summary>
		IPSEC_TRAFFIC_TYPE_TUNNEL,

		/// <summary>Maximum value for testing only.</summary>
		IPSEC_TRAFFIC_TYPE_MAX,
	}

	/// <summary>The <c>IPSEC_TRANSFORM_TYPE</c> enumerated type indicates the type of an IPsec security association (SA) transform.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ne-ipsectypes-ipsec_transform_type typedef enum IPSEC_TRANSFORM_TYPE_ {
	// IPSEC_TRANSFORM_AH = 1, IPSEC_TRANSFORM_ESP_AUTH, IPSEC_TRANSFORM_ESP_CIPHER, IPSEC_TRANSFORM_ESP_AUTH_AND_CIPHER,
	// IPSEC_TRANSFORM_ESP_AUTH_FW, IPSEC_TRANSFORM_TYPE_MAX } IPSEC_TRANSFORM_TYPE;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NE:ipsectypes.IPSEC_TRANSFORM_TYPE_")]
	public enum IPSEC_TRANSFORM_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Specifies Authentication Header (AH) transform.</para>
		/// </summary>
		IPSEC_TRANSFORM_AH = 1,

		/// <summary>Specifies Encapsulating Security Payload (ESP) authentication-only transform.</summary>
		IPSEC_TRANSFORM_ESP_AUTH,

		/// <summary>Specifies ESP cipher transform.</summary>
		IPSEC_TRANSFORM_ESP_CIPHER,

		/// <summary>Specifies ESP authentication and cipher transform.</summary>
		IPSEC_TRANSFORM_ESP_AUTH_AND_CIPHER,

		/// <summary>
		/// <para>
		/// Specifies that the first packet should be sent twice: once with ESP/AH encapsulation, and once in clear text. The entire session
		/// is then sent in clear text.
		/// </para>
		/// <para>
		/// The initial packet will allow the existing firewall rules to apply to the connection. The subsequent clear text data stream
		/// allows intermediaries to modify the stream.
		/// </para>
		/// <para><c>Note</c> Available only on Windows Server 2008 R2, Windows 7, or later.</para>
		/// </summary>
		IPSEC_TRANSFORM_ESP_AUTH_FW,

		/// <summary>Maximum value for testing only.</summary>
		IPSEC_TRANSFORM_TYPE_MAX,
	}

	/// <summary>The <c>IPSEC_ADDRESS_INFO0</c> structure is used to store mobile additional address information.</summary>
	/// <remarks>
	/// <c>IPSEC_ADDRESS_INFO0</c> is a specific implementation of IPSEC_ADDRESS_INFO. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_address_info0 typedef struct IPSEC_ADDRESS_INFO0_ {
	// UINT32 numV4Addresses; UINT32 *v4Addresses; UINT32 numV6Addresses; FWP_BYTE_ARRAY16 *v6Addresses; } IPSEC_ADDRESS_INFO0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_ADDRESS_INFO0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_ADDRESS_INFO0
	{
		/// <summary>The number of IPv4 addresses stored in the <c>v4Addresses</c> member.</summary>
		public uint numV4Addresses;

		/// <summary>Pointer to an array of IPv4 local addresses to indicate to peer.</summary>
		public IntPtr pv4Addresses;

		/// <summary>Array of IPv4 local addresses to indicate to peer.</summary>
		public IN_ADDR[] v4Addresses => pv4Addresses.ToArray<IN_ADDR>((int)numV4Addresses);

		/// <summary>The number of IPv6 addresses stored in the <c>v6Addresses</c> member.</summary>
		public uint numV6Addresses;

		/// <summary>Pointer to an array of IPv6 local addresses to indicate to peer.</summary>
		public IntPtr pv6Addresses;

		/// <summary>Array of IPv6 local addresses to indicate to peer.</summary>
		public IN6_ADDR[] v6Addresses => pv6Addresses.ToArray<IN6_ADDR>((int)numV6Addresses);
	}

	/// <summary>The IPSEC_AGGREGATE_DROP_PACKET_STATISTICS1 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_aggregate_drop_packet_statistics0 typedef struct
	// IPSEC_AGGREGATE_DROP_PACKET_STATISTICS0_ { UINT32 invalidSpisOnInbound; UINT32 decryptionFailuresOnInbound; UINT32
	// authenticationFailuresOnInbound; UINT32 udpEspValidationFailuresOnInbound; UINT32 replayCheckFailuresOnInbound; UINT32
	// invalidClearTextInbound; UINT32 saNotInitializedOnInbound; UINT32 receiveOverIncorrectSaInbound; UINT32
	// secureReceivesNotMatchingFilters; } IPSEC_AGGREGATE_DROP_PACKET_STATISTICS0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_AGGREGATE_DROP_PACKET_STATISTICS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_AGGREGATE_DROP_PACKET_STATISTICS0
	{
		/// <summary>Number of invalid SPIs on inbound.</summary>
		public uint invalidSpisOnInbound;

		/// <summary>Number of decryption failures on inbound.</summary>
		public uint decryptionFailuresOnInbound;

		/// <summary>Number of authentication failures on inbound.</summary>
		public uint authenticationFailuresOnInbound;

		/// <summary>Number of UDP ESP validation failures on inbound.</summary>
		public uint udpEspValidationFailuresOnInbound;

		/// <summary>Number of replay check failures on inbound.</summary>
		public uint replayCheckFailuresOnInbound;

		/// <summary>Number of invalid clear text instances on inbound.</summary>
		public uint invalidClearTextInbound;

		/// <summary>Number of inbound drops for packets received on SAs that were not fully initialized.</summary>
		public uint saNotInitializedOnInbound;

		/// <summary>Number of inbound drops for packets received on SAs whose characteristics did not match the packet.</summary>
		public uint receiveOverIncorrectSaInbound;

		/// <summary>Number of inbound IPsec secured packets that did not match any inbound IPsec transport layer filter.</summary>
		public uint secureReceivesNotMatchingFilters;
	}

	/// <summary>
	/// The <c>IPSEC_AGGREGATE_DROP_PACKET_STATISTICS1</c> structure stores aggregate IPsec kernel packet drop statistics.
	/// IPSEC_AGGREGATE_DROP_PACKET_STATISTICS0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_aggregate_drop_packet_statistics1 typedef struct
	// IPSEC_AGGREGATE_DROP_PACKET_STATISTICS1_ { UINT32 invalidSpisOnInbound; UINT32 decryptionFailuresOnInbound; UINT32
	// authenticationFailuresOnInbound; UINT32 udpEspValidationFailuresOnInbound; UINT32 replayCheckFailuresOnInbound; UINT32
	// invalidClearTextInbound; UINT32 saNotInitializedOnInbound; UINT32 receiveOverIncorrectSaInbound; UINT32
	// secureReceivesNotMatchingFilters; UINT32 totalDropPacketsInbound; } IPSEC_AGGREGATE_DROP_PACKET_STATISTICS1;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_AGGREGATE_DROP_PACKET_STATISTICS1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_AGGREGATE_DROP_PACKET_STATISTICS1
	{
		/// <summary>Number of invalid SPIs on inbound.</summary>
		public uint invalidSpisOnInbound;

		/// <summary>Number of decryption failures on inbound.</summary>
		public uint decryptionFailuresOnInbound;

		/// <summary>Number of authentication failures on inbound.</summary>
		public uint authenticationFailuresOnInbound;

		/// <summary>Number of UDP ESP validation failures on inbound.</summary>
		public uint udpEspValidationFailuresOnInbound;

		/// <summary>Number of replay check failures on inbound.</summary>
		public uint replayCheckFailuresOnInbound;

		/// <summary>Number of invalid clear text instances on inbound.</summary>
		public uint invalidClearTextInbound;

		/// <summary>Number of inbound drops for packets received on SAs that were not fully initialized.</summary>
		public uint saNotInitializedOnInbound;

		/// <summary>Number of inbound drops for packets received on SAs whose characteristics did not match the packet.</summary>
		public uint receiveOverIncorrectSaInbound;

		/// <summary>Number of inbound IPsec secured packets that did not match any inbound IPsec transport layer filter.</summary>
		public uint secureReceivesNotMatchingFilters;

		/// <summary>Number of inbound drops for all packets.</summary>
		public uint totalDropPacketsInbound;
	}

	/// <summary>The <c>IPSEC_AGGREGATE_SA_STATISTICS0</c> structure stores aggregate IPsec kernel security association (SA) statistics.</summary>
	/// <remarks>
	/// <c>IPSEC_AGGREGATE_SA_STATISTICS0</c> is a specific implementation of IPSEC_AGGREGATE_SA_STATISTICS. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_aggregate_sa_statistics0 typedef struct
	// IPSEC_AGGREGATE_SA_STATISTICS0_ { UINT32 activeSas; UINT32 pendingSaNegotiations; UINT32 totalSasAdded; UINT32 totalSasDeleted; UINT32
	// successfulRekeys; UINT32 activeTunnels; UINT32 offloadedSas; } IPSEC_AGGREGATE_SA_STATISTICS0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_AGGREGATE_SA_STATISTICS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_AGGREGATE_SA_STATISTICS0
	{
		/// <summary>Number of active SAs.</summary>
		public uint activeSas;

		/// <summary>Number of pending SA negotiations.</summary>
		public uint pendingSaNegotiations;

		/// <summary>Total number of SAs added.</summary>
		public uint totalSasAdded;

		/// <summary>Total number of SAs deleted.</summary>
		public uint totalSasDeleted;

		/// <summary>Number of successful re-keys.</summary>
		public uint successfulRekeys;

		/// <summary>Number of active tunnels.</summary>
		public uint activeTunnels;

		/// <summary>Number of offloaded SAs.</summary>
		public uint offloadedSas;
	}

	/// <summary>The <c>IPSEC_AH_DROP_PACKET_STATISTICS0</c> structure stores IPsec AH drop packet statistics.</summary>
	/// <remarks>
	/// <c>IPSEC_AH_DROP_PACKET_STATISTICS0</c> is a specific implementation of IPSEC_AH_DROP_PACKET_STATISTICS. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_ah_drop_packet_statistics0 typedef struct
	// IPSEC_AH_DROP_PACKET_STATISTICS0_ { UINT32 invalidSpisOnInbound; UINT32 authenticationFailuresOnInbound; UINT32
	// replayCheckFailuresOnInbound; UINT32 saNotInitializedOnInbound; } IPSEC_AH_DROP_PACKET_STATISTICS0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_AH_DROP_PACKET_STATISTICS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_AH_DROP_PACKET_STATISTICS0
	{
		/// <summary>Number of invalid SPIs on inbound.</summary>
		public uint invalidSpisOnInbound;

		/// <summary>Number of authentication failures on inbound.</summary>
		public uint authenticationFailuresOnInbound;

		/// <summary>Number of replay check failures on inbound.</summary>
		public uint replayCheckFailuresOnInbound;

		/// <summary>Number of inbound drops for packets received on SAs that were not fully initialized.</summary>
		public uint saNotInitializedOnInbound;
	}

	/// <summary>
	/// The <c>IPSEC_AUTH_AND_CIPHER_TRANSFORM0</c> structure is used to store hash and encryption specific information together for an SA
	/// transform in an IPsec quick mode policy.
	/// </summary>
	/// <remarks>
	/// <c>IPSEC_AUTH_AND_CIPHER_TRANSFORM0</c> is a specific implementation of IPSEC_AUTH_AND_CIPHER_TRANSFORM. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_auth_and_cipher_transform0 typedef struct
	// IPSEC_AUTH_AND_CIPHER_TRANSFORM0_ { IPSEC_AUTH_TRANSFORM0 authTransform; IPSEC_CIPHER_TRANSFORM0 cipherTransform; } IPSEC_AUTH_AND_CIPHER_TRANSFORM0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_AUTH_AND_CIPHER_TRANSFORM0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_AUTH_AND_CIPHER_TRANSFORM0
	{
		/// <summary>Hash specific information as specified by IPSEC_AUTH_TRANSFORM0.</summary>
		public IPSEC_AUTH_TRANSFORM0 authTransform;

		/// <summary>Encryption specific information as specified by IPSEC_CIPHER_TRANSFORM0.</summary>
		public IPSEC_CIPHER_TRANSFORM0 cipherTransform;
	}

	/// <summary>
	/// The <c>IPSEC_AUTH_TRANSFORM_ID0</c> structure is used to uniquely identify the hash algorithm used in an IPsec security association (SA).
	/// </summary>
	/// <remarks>
	/// <c>IPSEC_AUTH_TRANSFORM_ID0</c> is a specific implementation of IPSEC_AUTH_TRANSFORM_ID. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_auth_transform_id0 typedef struct
	// IPSEC_AUTH_TRANSFORM_ID0_ { IPSEC_AUTH_TYPE authType; IPSEC_AUTH_CONFIG authConfig; } IPSEC_AUTH_TRANSFORM_ID0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_AUTH_TRANSFORM_ID0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_AUTH_TRANSFORM_ID0
	{
		/// <summary>The type of the hash algorithm as specified by IPSEC_AUTH_TYPE.</summary>
		public IPSEC_AUTH_TYPE authType;

		/// <summary>
		/// <para>
		/// Additional configuration information for the IPsec SA hash algorithm as specified by a <c>IPSEC_AUTH_CONFIG</c> which maps to a <c>UINT8</c>.
		/// </para>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IPsec authentication configuration</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_AUTH_CONFIG_HMAC_MD5_96</c></term>
		/// <term>
		/// HMAC (Hash Message Authentication Code) secret key authentication algorithm. MD5 (Message Digest) data integrity and data origin
		/// authentication algorithm.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_AUTH_CONFIG_HMAC_SHA_1_96</c></term>
		/// <term>HMAC secret key authentication algorithm. SHA-1 (Secure Hash Algorithm) data integrity and data origin authentication algorithm.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_AUTH_CONFIG_HMAC_SHA_256_128</c></term>
		/// <term>HMAC secret key authentication algorithm. SHA-256 data integrity and data origin authentication algorithm.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_AUTH_CONFIG_GCM_AES_128</c></term>
		/// <term>
		/// GCM (Galois Counter Mode) secret key authentication algorithm. AES(Advanced Encryption Standard) data integrity and data origin
		/// authentication algorithm, with 128-bit key.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_AUTH_CONFIG_GCM_AES_192</c></term>
		/// <term>GCM secret key authentication algorithm. AES data integrity and data origin authentication algorithm, with 192-bit key.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_AUTH_CONFIG_GCM_AES_256</c></term>
		/// <term>GCM secret key authentication algorithm. AES data integrity and data origin authentication algorithm, with 256-bit key.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_AUTH_CONFIG authConfig;

		/// <summary>Initializes a new instance of the <see cref="IPSEC_AUTH_TRANSFORM_ID0"/> struct.</summary>
		/// <param name="type">The type of the hash algorithm as specified by IPSEC_AUTH_TYPE.</param>
		/// <param name="config">Additional configuration information for the IPsec SA hash algorithm.</param>
		public IPSEC_AUTH_TRANSFORM_ID0(IPSEC_AUTH_TYPE type, IPSEC_AUTH_CONFIG config)
		{
			authType = type;
			authConfig = config;
		}
	}

	/// <summary>The <c>IPSEC_AUTH_TRANSFORM0</c> structure specifies hash specific information for an SA transform.</summary>
	/// <remarks>
	/// <c>IPSEC_AUTH_TRANSFORM0</c> is a specific implementation of IPSEC_AUTH_TRANSFORM. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_auth_transform0 typedef struct
	// IPSEC_AUTH_TRANSFORM0_ { IPSEC_AUTH_TRANSFORM_ID0 authTransformId; IPSEC_CRYPTO_MODULE_ID *cryptoModuleId; } IPSEC_AUTH_TRANSFORM0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_AUTH_TRANSFORM0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_AUTH_TRANSFORM0
	{
		/// <summary>
		/// <para>The identifier of the hash algorithm as specified by IPSEC_AUTH_TRANSFORM_ID0.</para>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_AUTH_TRANSFORM_ID_HMAC_MD5_96</c></term>
		/// <term>IPSEC_AUTH_MD5, IPSEC_AUTH_CONFIG_HMAC_MD5_96</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_AUTH_TRANSFORM_ID_HMAC_SHA_1_96</c></term>
		/// <term>IPSEC_AUTH_SHA_1, IPSEC_AUTH_CONFIG_HMAC_SHA_1_96</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_AUTH_TRANSFORM_ID_HMAC_SHA_256_128</c></term>
		/// <term>IPSEC_AUTH_SHA_256, IPSEC_AUTH_CONFIG_HMAC_SHA_256_128</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_AUTH_TRANSFORM_ID_GCM_AES_128</c></term>
		/// <term>IPSEC_AUTH_AES_128, IPSEC_AUTH_CONFIG_GCM_AES_128</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_AUTH_TRANSFORM_ID_GCM_AES_192</c></term>
		/// <term>IPSEC_AUTH_AES_192, IPSEC_AUTH_CONFIG_GCM_AES_192</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_AUTH_TRANSFORM_ID_GCM_AES_256</c></term>
		/// <term>IPSEC_AUTH_AES_256, IPSEC_AUTH_CONFIG_GCM_AES_256</term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_AUTH_TRANSFORM_ID0 authTransformId;

		/// <summary>Unused parameter, always set this to <c>NULL</c>.</summary>
		public IntPtr cryptoModuleId;
	}

	/// <summary>
	/// The <c>IPSEC_CIPHER_TRANSFORM_ID0</c> structure specifies information used to uniquely identify the encryption algorithm used in an
	/// IPsec SA.
	/// </summary>
	/// <remarks>
	/// <c>IPSEC_CIPHER_TRANSFORM_ID0</c> is a specific implementation of IPSEC_CIPHER_TRANSFORM_ID. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_cipher_transform_id0 typedef struct
	// IPSEC_CIPHER_TRANSFORM_ID0_ { IPSEC_CIPHER_TYPE cipherType; IPSEC_CIPHER_CONFIG cipherConfig; } IPSEC_CIPHER_TRANSFORM_ID0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_CIPHER_TRANSFORM_ID0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_CIPHER_TRANSFORM_ID0
	{
		/// <summary>The type of the encryption algorithm as specified by IPSEC_CIPHER_TYPE.</summary>
		public IPSEC_CIPHER_TYPE cipherType;

		/// <summary>
		/// <para>
		/// Additional configuration information for the encryption algorithm as specified by <c>IPSEC_CIPHER_CONFIG</c> which maps to a <c>UINT8</c>.
		/// </para>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IPsec encryption configuration</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_CIPHER_CONFIG_CBC_DES</c></term>
		/// <term>DES (Data Encryption Standard) algorithm. CBC (Cipher Block Chaining) mode of operation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_CIPHER_CONFIG_CBC_3DES</c></term>
		/// <term>3DES algorithm. CBC mode of operation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_CIPHER_CONFIG_CBC_AES_128</c></term>
		/// <term>AES-128 (Advanced Encryption Standard) algorithm. CBC mode of operation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_CIPHER_CONFIG_CBC_AES_192</c></term>
		/// <term>AES-192 algorithm. CBC mode of operation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_CIPHER_CONFIG_CBC_AES_256</c></term>
		/// <term>AES-256 algorithm. CBC mode of operation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_CIPHER_CONFIG_GCM_AES_128</c></term>
		/// <term>AES-128 algorithm. GCM (Galois Counter Mode) mode of operation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_CIPHER_CONFIG_GCM_AES_192</c></term>
		/// <term>AES-192 algorithm. GCM (Galois Counter Mode) mode of operation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_CIPHER_CONFIG_GCM_AES_256</c></term>
		/// <term>AES-256 algorithm. GCM (Galois Counter Mode) mode of operation.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_CIPHER_CONFIG cipherConfig;

		/// <summary>Initializes a new instance of the <see cref="IPSEC_AUTH_TRANSFORM_ID0"/> struct.</summary>
		/// <param name="type">The type of the encryption algorithm.</param>
		/// <param name="config">Additional configuration information for the encryption algorithm.</param>
		public IPSEC_CIPHER_TRANSFORM_ID0(IPSEC_CIPHER_TYPE type, IPSEC_CIPHER_CONFIG config)
		{
			cipherType = type;
			cipherConfig = config;
		}
	}

	/// <summary>
	/// The <c>IPSEC_CIPHER_TRANSFORM0</c> structure is used to store encryption specific information for an SA transform in an IPsec quick
	/// mode policy.
	/// </summary>
	/// <remarks>
	/// <c>IPSEC_CIPHER_TRANSFORM0</c> is a specific implementation of IPSEC_CIPHER_TRANSFORM. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_cipher_transform0 typedef struct
	// IPSEC_CIPHER_TRANSFORM0_ { IPSEC_CIPHER_TRANSFORM_ID0 cipherTransformId; IPSEC_CRYPTO_MODULE_ID *cryptoModuleId; } IPSEC_CIPHER_TRANSFORM0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_CIPHER_TRANSFORM0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_CIPHER_TRANSFORM0
	{
		/// <summary>
		/// <para>The identifier of the encryption algorithm as specified by IPSEC_CIPHER_TRANSFORM_ID0.</para>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_CIPHER_TRANSFORM_ID_CBC_DES</c></term>
		/// <term>IPSEC_CIPHER_TYPE_DES, IPSEC_CIPHER_CONFIG_CBC_DES</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_CIPHER_TRANSFORM_ID_CBC_3DES</c></term>
		/// <term>IPSEC_CIPHER_TYPE_3DES, IPSEC_CIPHER_CONFIG_CBC_3DES</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_CIPHER_TRANSFORM_ID_AES_128</c></term>
		/// <term>IPSEC_CIPHER_TYPE_AES_128, IPSEC_CIPHER_CONFIG_CBC_AES_128</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_CIPHER_TRANSFORM_ID_AES_192</c></term>
		/// <term>IPSEC_CIPHER_TYPE_AES_192, IPSEC_CIPHER_CONFIG_CBC_AES_192</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_CIPHER_TRANSFORM_ID_AES_256</c></term>
		/// <term>IPSEC_CIPHER_TYPE_AES_256, IPSEC_CIPHER_CONFIG_CBC_AES_256</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_CIPHER_TRANSFORM_ID_GCM_AES_128</c></term>
		/// <term>IPSEC_CIPHER_TYPE_AES_128, IPSEC_CIPHER_CONFIG_GCM_AES_128</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_CIPHER_TRANSFORM_ID_GCM_AES_192</c></term>
		/// <term>IPSEC_CIPHER_TYPE_AES_192, IPSEC_CIPHER_CONFIG_GCM_AES_192</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_CIPHER_TRANSFORM_ID_GCM_AES_256</c></term>
		/// <term>IPSEC_CIPHER_TYPE_AES_256, IPSEC_CIPHER_CONFIG_GCM_AES_256</term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_CIPHER_TRANSFORM_ID0 cipherTransformId;

		/// <summary>Unused parameter, always set this to <c>NULL</c>.</summary>
		public IntPtr cryptoModuleId;
	}

	/// <summary>The <c>IPSEC_DOSP_OPTIONS0</c> structure is used to store configuration parameters for IPsec DoS Protection.</summary>
	/// <remarks>
	/// <c>IPSEC_DOSP_OPTIONS0</c> is a specific implementation of IPSEC_DOSP_OPTIONS. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_dosp_options0 typedef struct IPSEC_DOSP_OPTIONS0_ {
	// UINT32 stateIdleTimeoutSeconds; UINT32 perIPRateLimitQueueIdleTimeoutSeconds; UINT8 ipV6IPsecUnauthDscp; UINT32
	// ipV6IPsecUnauthRateLimitBytesPerSec; UINT32 ipV6IPsecUnauthPerIPRateLimitBytesPerSec; UINT8 ipV6IPsecAuthDscp; UINT32
	// ipV6IPsecAuthRateLimitBytesPerSec; UINT8 icmpV6Dscp; UINT32 icmpV6RateLimitBytesPerSec; UINT8 ipV6FilterExemptDscp; UINT32
	// ipV6FilterExemptRateLimitBytesPerSec; UINT8 defBlockExemptDscp; UINT32 defBlockExemptRateLimitBytesPerSec; UINT32 maxStateEntries;
	// UINT32 maxPerIPRateLimitQueues; UINT32 flags; UINT32 numPublicIFLuids; UINT64 *publicIFLuids; UINT32 numInternalIFLuids; UINT64
	// *internalIFLuids; FWP_V6_ADDR_AND_MASK publicV6AddrMask; FWP_V6_ADDR_AND_MASK internalV6AddrMask; } IPSEC_DOSP_OPTIONS0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_DOSP_OPTIONS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_DOSP_OPTIONS0
	{
		/// <summary>The number of seconds before idle timeout. This value must be greater than 0.</summary>
		public uint stateIdleTimeoutSeconds;

		/// <summary>The idle timeout for the per IP rate limit queue object. This value must be greater than 0.</summary>
		public uint perIPRateLimitQueueIdleTimeoutSeconds;

		/// <summary>
		/// The DSCP marking for unauthenticated inbound IPv6 IPsec traffic. This value must be less than or equal to 63. Specify
		/// IPSEC_DOSP_DSCP_DISABLE_VALUE to disable DSCP marking for this category.
		/// </summary>
		public byte ipV6IPsecUnauthDscp;

		/// <summary>
		/// The rate limit for unauthenticated inbound IPv6 IPsec traffic. Specify IPSEC_DOSP_RATE_LIMIT_DISABLE_VALUE to disable rate
		/// limiting for this category.
		/// </summary>
		public uint ipV6IPsecUnauthRateLimitBytesPerSec;

		/// <summary>
		/// The rate limit for unauthenticated inbound IPv6 IPsec traffic per internal IP address. Specify
		/// IPSEC_DOSP_RATE_LIMIT_DISABLE_VALUE to disable rate limiting for this category.
		/// </summary>
		public uint ipV6IPsecUnauthPerIPRateLimitBytesPerSec;

		/// <summary>
		/// The DSCP marking for authenticated inbound IPv6 IPsec traffic. The value must be less than or equal to 63. Specify
		/// IPSEC_DOSP_DSCP_DISABLE_VALUE to disable DSCP marking for this category.
		/// </summary>
		public byte ipV6IPsecAuthDscp;

		/// <summary>
		/// The rate limit for authenticated inbound IPv6 IPsec traffic. Specify IPSEC_DOSP_RATE_LIMIT_DISABLE_VALUE to disable rate limiting
		/// for this category..
		/// </summary>
		public uint ipV6IPsecAuthRateLimitBytesPerSec;

		/// <summary>
		/// The DSCP marking for inbound ICMPv6 traffic. The value must be less than or equal to 63. Specify IPSEC_DOSP_DSCP_DISABLE_VALUE to
		/// disable DSCP marking for this category.
		/// </summary>
		public byte icmpV6Dscp;

		/// <summary>
		/// The rate limit for inbound ICMPv6 traffic. Specify IPSEC_DOSP_RATE_LIMIT_DISABLE_VALUE to disable rate limiting for this category.
		/// </summary>
		public uint icmpV6RateLimitBytesPerSec;

		/// <summary>
		/// The DSCP marking for inbound IPv6 filter exempted traffic. The value must be less than or equal to 63. Specify
		/// IPSEC_DOSP_DSCP_DISABLE_VALUE to disable DSCP marking for this category.
		/// </summary>
		public byte ipV6FilterExemptDscp;

		/// <summary>
		/// The rate limit for inbound IPV6 filter exempted traffic. Specify IPSEC_DOSP_RATE_LIMIT_DISABLE_VALUE to disable rate limiting for
		/// this category.
		/// </summary>
		public uint ipV6FilterExemptRateLimitBytesPerSec;

		/// <summary>
		/// The DSCP marking for inbound default-block exempted traffic. The value must be less than or equal to 63. Specify
		/// IPSEC_DOSP_DSCP_DISABLE_VALUE to disable DSCP marking for this category.
		/// </summary>
		public byte defBlockExemptDscp;

		/// <summary>
		/// The rate limit for inbound default-block exempted traffic. Specify IPSEC_DOSP_RATE_LIMIT_DISABLE_VALUE to disable rate limiting
		/// for this category.
		/// </summary>
		public uint defBlockExemptRateLimitBytesPerSec;

		/// <summary>The maximum number of state entries in the table. The value must be greater than 0.</summary>
		public uint maxStateEntries;

		/// <summary>
		/// The maximum number of rate limit queues for inbound unauthenticated IPv6 IPsec traffic per internal IP address. The value must be
		/// greater than 0.
		/// </summary>
		public uint maxPerIPRateLimitQueues;

		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IPsec DoS Protection options flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_DOSP_FLAG_ENABLE_IKEV1</c></term>
		/// <term>Allows the IKEv1 keying module. By default, it is blocked.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_DOSP_FLAG_ENABLE_IKEV2</c></term>
		/// <term>Allows the IKEv2 keying module. By default, it is blocked.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_DOSP_FLAG_DISABLE_AUTHIP</c></term>
		/// <term>Blocks the AuthIP keying module. By default, it is allowed.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_DOSP_FLAG_DISABLE_DEFAULT_BLOCK</c></term>
		/// <term>
		/// Allows all matching IPv4 traffic and non-IPsec IPv6 traffic. By default, all IPv4 traffic and non-IPsecIPv6 traffic, except IPv6
		/// ICMP, will be blocked.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_DOSP_FLAG_FILTER_BLOCK</c></term>
		/// <term>Blocks all matching IPv6 traffic.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_DOSP_FLAG_FILTER_EXEMPT</c></term>
		/// <term>Allows all matching IPv6 traffic.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_DOSP_FLAG flags;

		/// <summary>The number of public Internet facing interface identifiers for which DOS protection should be enabled.</summary>
		public uint numPublicIFLuids;

		/// <summary>Pointer to an array of public Internet facing interface identifiers for which DOS protection should be enabled.</summary>
		public IntPtr publicIFLuids;

		/// <summary>The number of internal network facing interface identifiers for which DOS protection should be enabled.</summary>
		public uint numInternalIFLuids;

		/// <summary>Pointer to an array of internal network facing interface identifiers for which DOS protection should be enabled.</summary>
		public IntPtr internalIFLuids;

		/// <summary>Optional public IPv6 address or subnet for this policy, as specified in FWP_V6_ADDR_AND_MASK.</summary>
		public FWP_V6_ADDR_AND_MASK publicV6AddrMask;

		/// <summary>Optional internal IPv6 address or subnet for this policy, as specified in FWP_V6_ADDR_AND_MASK.</summary>
		public FWP_V6_ADDR_AND_MASK internalV6AddrMask;
	}

	/// <summary>The <c>IPSEC_DOSP_STATE_ENUM_TEMPLATE0</c> structure is used to enumerate IPsec DoS Protection state entries.</summary>
	/// <remarks>
	/// <c>IPSEC_DOSP_STATE_ENUM_TEMPLATE0</c> is a specific implementation of IPSEC_DOSP_STATE_ENUM_TEMPLATE. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_dosp_state_enum_template0 typedef struct
	// IPSEC_DOSP_STATE_ENUM_TEMPLATE0_ { FWP_V6_ADDR_AND_MASK publicV6AddrMask; FWP_V6_ADDR_AND_MASK internalV6AddrMask; } IPSEC_DOSP_STATE_ENUM_TEMPLATE0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_DOSP_STATE_ENUM_TEMPLATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_DOSP_STATE_ENUM_TEMPLATE0
	{
		/// <summary>An FWP_V6_ADDR_AND_MASK structure that specifies the public IPv6 address.</summary>
		public FWP_V6_ADDR_AND_MASK publicV6AddrMask;

		/// <summary>An FWP_V6_ADDR_AND_MASK structure that specifies the internal IPv6 address.</summary>
		public FWP_V6_ADDR_AND_MASK internalV6AddrMask;
	}

	/// <summary>The <c>IPSEC_DOSP_STATE0</c> structure is used to store state information for IPsec DoS Protection.</summary>
	/// <remarks>
	/// <c>IPSEC_DOSP_STATE0</c> is a specific implementation of IPSEC_DOSP_STATE. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_dosp_state0 typedef struct IPSEC_DOSP_STATE0_ {
	// UINT8 publicHostV6Addr[16]; UINT8 internalHostV6Addr[16]; UINT64 totalInboundIPv6IPsecAuthPackets; UINT64
	// totalOutboundIPv6IPsecAuthPackets; UINT32 durationSecs; } IPSEC_DOSP_STATE0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_DOSP_STATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_DOSP_STATE0
	{
		/// <summary>The IPv6 address of the public host.</summary>
		public IN6_ADDR publicHostV6Addr;

		/// <summary>The IPv6 address of the internal host.</summary>
		public IN6_ADDR internalHostV6Addr;

		/// <summary>The total number of inbound IPv6 IPsec packets that have been allowed since the state entry was created.</summary>
		public ulong totalInboundIPv6IPsecAuthPackets;

		/// <summary>The total number of outbound IPv6 IPsec packets that have been allowed since the state entry was created.</summary>
		public ulong totalOutboundIPv6IPsecAuthPackets;

		/// <summary>The duration, in seconds, since the state entry was created.</summary>
		public uint durationSecs;
	}

	/// <summary>The <c>IPSEC_DOSP_STATISTICS0</c> structure is used to store statistics for IPsec DoS Protection.</summary>
	/// <remarks>
	/// <c>IPSEC_DOSP_STATISTICS0</c> is a specific implementation of IPSEC_DOSP_STATISTICS. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_dosp_statistics0 typedef struct
	// IPSEC_DOSP_STATISTICS0_ { UINT64 totalStateEntriesCreated; UINT64 currentStateEntries; UINT64 totalInboundAllowedIPv6IPsecUnauthPkts;
	// UINT64 totalInboundRatelimitDiscardedIPv6IPsecUnauthPkts; UINT64 totalInboundPerIPRatelimitDiscardedIPv6IPsecUnauthPkts; UINT64
	// totalInboundOtherDiscardedIPv6IPsecUnauthPkts; UINT64 totalInboundAllowedIPv6IPsecAuthPkts; UINT64
	// totalInboundRatelimitDiscardedIPv6IPsecAuthPkts; UINT64 totalInboundOtherDiscardedIPv6IPsecAuthPkts; UINT64
	// totalInboundAllowedICMPv6Pkts; UINT64 totalInboundRatelimitDiscardedICMPv6Pkts; UINT64 totalInboundAllowedIPv6FilterExemptPkts; UINT64
	// totalInboundRatelimitDiscardedIPv6FilterExemptPkts; UINT64 totalInboundDiscardedIPv6FilterBlockPkts; UINT64
	// totalInboundAllowedDefBlockExemptPkts; UINT64 totalInboundRatelimitDiscardedDefBlockExemptPkts; UINT64
	// totalInboundDiscardedDefBlockPkts; UINT64 currentInboundIPv6IPsecUnauthPerIPRateLimitQueues; } IPSEC_DOSP_STATISTICS0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_DOSP_STATISTICS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_DOSP_STATISTICS0
	{
		/// <summary>The total number of state entries that have been created since the computer was last started.</summary>
		public ulong totalStateEntriesCreated;

		/// <summary>The current number of state entries in the table.</summary>
		public ulong currentStateEntries;

		/// <summary>
		/// The total number of inbound IPv6 IPsec unauthenticated packets that have been allowed since the computer was last started.
		/// </summary>
		public ulong totalInboundAllowedIPv6IPsecUnauthPkts;

		/// <summary>
		/// The total number of inbound IPv6 IPsec unauthenticated packets that have been discarded due to rate limiting since the computer
		/// was last started.
		/// </summary>
		public ulong totalInboundRatelimitDiscardedIPv6IPsecUnauthPkts;

		/// <summary>
		/// The total number of inbound IPv6 IPsec unauthenticated packets that have been discarded due to per internal IP address rate
		/// limiting since the computer was last started.
		/// </summary>
		public ulong totalInboundPerIPRatelimitDiscardedIPv6IPsecUnauthPkts;

		/// <summary>
		/// The total number of inbound IPV6 IPsec unauthenticated packets that have been discarded due to all other reasons since the
		/// computer was last started.
		/// </summary>
		public ulong totalInboundOtherDiscardedIPv6IPsecUnauthPkts;

		/// <summary>The total number of inbound IPv6 IPsec authenticated packets that have been allowed since the computer was last started.</summary>
		public ulong totalInboundAllowedIPv6IPsecAuthPkts;

		/// <summary>
		/// The total number of inbound IPv6 IPsec authenticated packets that have been discarded due to rate limiting since the computer was
		/// last started.
		/// </summary>
		public ulong totalInboundRatelimitDiscardedIPv6IPsecAuthPkts;

		/// <summary>
		/// The total number of inbound IPV6 IPsec authenticated packets that have been discarded due to all other reasons since the computer
		/// was last started.
		/// </summary>
		public ulong totalInboundOtherDiscardedIPv6IPsecAuthPkts;

		/// <summary>The total number of inbound ICMPv6 packets that have been allowed since the computer was last started.</summary>
		public ulong totalInboundAllowedICMPv6Pkts;

		/// <summary>
		/// The total number of inbound ICMPv6 packets that have been discarded due to rate limiting since the computer was last started.
		/// </summary>
		public ulong totalInboundRatelimitDiscardedICMPv6Pkts;

		/// <summary>The total number of inbound IPv6 filter exempted packets that have been allowed since the computer was last started.</summary>
		public ulong totalInboundAllowedIPv6FilterExemptPkts;

		/// <summary>
		/// The total number of inbound IPv6 filter exempted packets that have been discarded due to rate limiting since the computer was
		/// last started.
		/// </summary>
		public ulong totalInboundRatelimitDiscardedIPv6FilterExemptPkts;

		/// <summary>The total number of inbound IPv6 filter blocked packets that have been discarded since the computer was last started.</summary>
		public ulong totalInboundDiscardedIPv6FilterBlockPkts;

		/// <summary>The total number of inbound default-block exempted packets that have been allowed since the computer was last started.</summary>
		public ulong totalInboundAllowedDefBlockExemptPkts;

		/// <summary>
		/// The total number of inbound default-block exempted packets that have been discarded due to rate limiting since the computer was
		/// last started.
		/// </summary>
		public ulong totalInboundRatelimitDiscardedDefBlockExemptPkts;

		/// <summary>The total number of inbound default-block packets that have been discarded since the computer was last started.</summary>
		public ulong totalInboundDiscardedDefBlockPkts;

		/// <summary>The current number of per internal IP address rate limit queues for inbound IPv6 unauthenticated IPsec traffic.</summary>
		public ulong currentInboundIPv6IPsecUnauthPerIPRateLimitQueues;
	}

	/// <summary>The <c>IPSEC_ESP_DROP_PACKET_STATISTICS0</c> structure stores ESP drop packet statistics.</summary>
	/// <remarks>
	/// <c>IPSEC_ESP_DROP_PACKET_STATISTICS0</c> is a specific implementation of IPSEC_ESP_DROP_PACKET_STATISTICS. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_esp_drop_packet_statistics0 typedef struct
	// IPSEC_ESP_DROP_PACKET_STATISTICS0_ { UINT32 invalidSpisOnInbound; UINT32 decryptionFailuresOnInbound; UINT32
	// authenticationFailuresOnInbound; UINT32 replayCheckFailuresOnInbound; UINT32 saNotInitializedOnInbound; } IPSEC_ESP_DROP_PACKET_STATISTICS0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_ESP_DROP_PACKET_STATISTICS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_ESP_DROP_PACKET_STATISTICS0
	{
		/// <summary>Number of invalid SPIs on inbound.</summary>
		public uint invalidSpisOnInbound;

		/// <summary>Number of decryption failures on inbound.</summary>
		public uint decryptionFailuresOnInbound;

		/// <summary>Number of authentication failures on inbound.</summary>
		public uint authenticationFailuresOnInbound;

		/// <summary>Number of replay check failures on inbound.</summary>
		public uint replayCheckFailuresOnInbound;

		/// <summary>Number of inbound drops for packets received on SAs that were not fully initialized.</summary>
		public uint saNotInitializedOnInbound;
	}

	/// <summary>
	/// The <c>IPSEC_GETSPI0</c> structure contains information that must be supplied when requesting a security parameter index (SPI) from
	/// the IPsec driver. IPSEC_GETSPI1 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_getspi0 typedef struct IPSEC_GETSPI0_ {
	// IPSEC_TRAFFIC0 inboundIpsecTraffic; FWP_IP_VERSION ipVersion; union { IPSEC_V4_UDP_ENCAPSULATION0 *inboundUdpEncapsulation; };
	// IPSEC_CRYPTO_MODULE_ID *rngCryptoModuleID; } IPSEC_GETSPI0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_GETSPI0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_GETSPI0
	{
		/// <summary>An IPSEC_TRAFFIC0 structure that describes traffic characteristics of the inbound IPsec SA.</summary>
		public IPSEC_TRAFFIC0 inboundIpsecTraffic;

		/// <summary>A FWP_IP_VERSION value that indicates the IP version of the inbound IPsec traffic.</summary>
		public FWP_IP_VERSION ipVersion;

		/// <summary>
		/// <para>
		/// Optional <see cref="IPSEC_V4_UDP_ENCAPSULATION0"/> structure that specifies the IPsec NAT Traversal (NATT) UDP encapsulation ports.
		/// </para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IntPtr inboundUdpEncapsulation;

		/// <summary>Not used. A <c>IPSEC_CRYPTO_MODULE_ID</c> is a <c>GUID</c> value.</summary>
		public GuidPtr rngCryptoModuleID;
	}

	/// <summary>
	/// The <c>IPSEC_GETSPI1</c> structure contains information that must be supplied when requesting a security parameter index (SPI) from
	/// the IPsec driver. IPSEC_GETSPI0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_getspi1 typedef struct IPSEC_GETSPI1_ {
	// IPSEC_TRAFFIC1 inboundIpsecTraffic; FWP_IP_VERSION ipVersion; union { IPSEC_V4_UDP_ENCAPSULATION0 *inboundUdpEncapsulation; };
	// IPSEC_CRYPTO_MODULE_ID *rngCryptoModuleID; } IPSEC_GETSPI1;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_GETSPI1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_GETSPI1
	{
		/// <summary>An IPSEC_TRAFFIC1 structure that describes traffic characteristics of the inbound IPsec SA.</summary>
		public IPSEC_TRAFFIC1 inboundIpsecTraffic;

		/// <summary>An FWP_IP_VERSION value that indicates the IP version of the inbound IPsec traffic.</summary>
		public FWP_IP_VERSION ipVersion;

		/// <summary>
		/// <para>
		/// Optional <see cref="IPSEC_V4_UDP_ENCAPSULATION0"/> structure that specifies the IPsec NAT Traversal (NATT) UDP encapsulation ports.
		/// </para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IntPtr inboundUdpEncapsulation;

		/// <summary>Not used. An <c>IPSEC_CRYPTO_MODULE_ID</c> is a <c>GUID</c> value.</summary>
		public GuidPtr rngCryptoModuleID;
	}

	/// <summary>The <c>IPSEC_ID0</c> structure contains information corresponding to identities that are authenticated by IPsec.</summary>
	/// <remarks>
	/// <c>IPSEC_ID0</c> is a specific implementation of IPSEC_ID. See WFP Version-Independent Names and Targeting Specific Versions of
	/// Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_id0 typedef struct IPSEC_ID0_ { wchar_t
	// *mmTargetName; wchar_t *emTargetName; UINT32 numTokens; IPSEC_TOKEN0 *tokens; UINT64 explicitCredentials; UINT64 logonId; } IPSEC_ID0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_ID0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_ID0
	{
		/// <summary>Optional main mode target service principal name (SPN). This is often the machine name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string mmTargetName;

		/// <summary>Optional extended mode target SPN.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string emTargetName;

		/// <summary>Optional. Number of IPSEC_TOKEN0 structures present in the <c>tokens</c> member.</summary>
		public uint numTokens;

		/// <summary>Optional array of <see cref="IPSEC_TOKEN0"/> structures.</summary>
		public IntPtr tokens;

		/// <summary>Optional handle to explicit credentials.</summary>
		public ulong explicitCredentials;

		/// <summary>Unused parameter. This should always be 0.</summary>
		public ulong logonId;
	}

	/// <summary>The <c>IPSEC_KEY_MANAGER0</c> structure is used to register key management callbacks with IPsec.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_key_manager0 typedef struct _IPSEC_KEY_MANAGER0 {
	// GUID keyManagerKey; FWPM_DISPLAY_DATA0 displayData; UINT32 flags; UINT8 keyDictationTimeoutHint; } IPSEC_KEY_MANAGER0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes._IPSEC_KEY_MANAGER0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_KEY_MANAGER0
	{
		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>Uniquely identifies the Key Manager.</para>
		/// </summary>
		public Guid keyManagerKey;

		/// <summary>
		/// <para>Type: FWPM_DISPLAY_DATA0</para>
		/// <para>Contains annotations associated with the filter.</para>
		/// </summary>
		public FWPM_DISPLAY_DATA0 displayData;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_KEY_MANAGER_FLAG_DICTATE_KEY</c></term>
		/// <term>
		/// Specifies that the TIA will be able to accept key notifications and also potentially dictate keys. If this flag is not set, the
		/// TIA can only accept key notifications and will not be able to dictate keys.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_KEY_MANAGER_FLAG flags;

		/// <summary>
		/// <para>Type: <c>UINT8</c></para>
		/// <para>
		/// Time, in seconds, after which the <c>keyDictation</c> callback must return in order for registration to succeed. Set this field
		/// to <c>0</c> in order to use the default timeout (5 seconds).
		/// </para>
		/// </summary>
		public byte keyDictationTimeoutHint;
	}

	/// <summary>The IPSEC_KEYING_POLICY1 is available.</summary>
	/// <remarks>
	/// <c>IPSEC_KEYING_POLICY0</c> is a specific implementation of IPSEC_KEYING_POLICY. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_keying_policy0 typedef struct IPSEC_KEYING_POLICY0_
	// { UINT32 numKeyMods; GUID *keyModKeys; } IPSEC_KEYING_POLICY0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_KEYING_POLICY0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_KEYING_POLICY0
	{
		/// <summary>Number of keying modules in the array.</summary>
		public uint numKeyMods;

		/// <summary>Array of distinct keying modules.</summary>
		public IntPtr keyModKeys;
	}

	/// <summary>The structure defines an unordered set of keying modules that will be tried for IPsec.IPSEC_KEYING_POLICY0 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_keying_policy1 typedef struct IPSEC_KEYING_POLICY1_
	// { UINT32 numKeyMods; GUID *keyModKeys; UINT32 flags; } IPSEC_KEYING_POLICY1;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_KEYING_POLICY1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_KEYING_POLICY1
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of keying modules in the array.</para>
		/// </summary>
		public uint numKeyMods;

		/// <summary>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Array of distinct keying modules.</para>
		/// </summary>
		public IntPtr keyModKeys;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_KEYING_POLICY_FLAG_TERMINATING_MATCH</c></term>
		/// <term>Forces the use of a Kerberos proxy server when acting as initiator.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_KEYING_POLICY_FLAG flags;
	}

	/// <summary>The <c>IPSEC_KEYMODULE_STATE0</c> structure stores Internet Protocol Security (IPsec) keying module specific information.</summary>
	/// <remarks>
	/// <c>IPSEC_KEYMODULE_STATE0</c> is a specific implementation of IPSEC_KEYMODULE_STATE. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_keymodule_state0 typedef struct
	// IPSEC_KEYMODULE_STATE0_ { GUID keyModuleKey; FWP_BYTE_BLOB stateBlob; } IPSEC_KEYMODULE_STATE0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_KEYMODULE_STATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_KEYMODULE_STATE0
	{
		/// <summary>The identifier of the keying module.</summary>
		public Guid keyModuleKey;

		/// <summary>A byte blob containing opaque keying module specific information.</summary>
		public FWP_BYTE_BLOB stateBlob;
	}

	/// <summary>The <c>IPSEC_PROPOSAL0</c> structure is used to store an IPsec quick mode proposal.</summary>
	/// <remarks>
	/// <para>The proposal describes the various parameters of the IPsec SA that is potentially generated from this proposal.</para>
	/// <para>
	/// <c>IPSEC_PROPOSAL0</c> is a specific implementation of IPSEC_PROPOSAL. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_proposal0 typedef struct IPSEC_PROPOSAL0_ {
	// IPSEC_SA_LIFETIME0 lifetime; UINT32 numSaTransforms; IPSEC_SA_TRANSFORM0 *saTransforms; IPSEC_PFS_GROUP pfsGroup; } IPSEC_PROPOSAL0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_PROPOSAL0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_PROPOSAL0
	{
		/// <summary>Lifetime of the IPsec security association (SA) as specified by IPSEC_SA_LIFETIME0. Cannot be zero.</summary>
		public IPSEC_SA_LIFETIME0 lifetime;

		/// <summary>Number of IPsec SA transforms. The only possible values are 1 and 2. Use 2 only when specifying AH plus ESP transforms.</summary>
		public uint numSaTransforms;

		/// <summary>Array of IPsec SA transforms as specified by <see cref="IPSEC_SA_TRANSFORM0"/>.</summary>
		public IntPtr saTransforms;

		/// <summary>Perfect forward secrecy (PFS) group of the IPsec SA as specified by IPSEC_PFS_GROUP.</summary>
		public IPSEC_PFS_GROUP pfsGroup;
	}

	/// <summary>
	/// The <c>IPSEC_SA_AUTH_AND_CIPHER_INFORMATION0</c> structure stores information about the authentication and encryption algorithms of
	/// an IPsec security association (SA).
	/// </summary>
	/// <remarks>
	/// <c>IPSEC_SA_AUTH_AND_CIPHER_INFORMATION0</c> is a specific implementation of IPSEC_SA_AUTH_AND_CIPHER_INFORMATION. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_auth_and_cipher_information0 typedef struct
	// IPSEC_SA_AUTH_AND_CIPHER_INFORMATION0_ { IPSEC_SA_CIPHER_INFORMATION0 saCipherInformation; IPSEC_SA_AUTH_INFORMATION0
	// saAuthInformation; } IPSEC_SA_AUTH_AND_CIPHER_INFORMATION0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_AUTH_AND_CIPHER_INFORMATION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_AUTH_AND_CIPHER_INFORMATION0
	{
		/// <summary>Encryption algorithm information as specified by IPSEC_SA_CIPHER_INFORMATION0.</summary>
		public IPSEC_SA_CIPHER_INFORMATION0 saCipherInformation;

		/// <summary>Authentication algorithm information as specified by IPSEC_SA_AUTH_INFORMATION0.</summary>
		public IPSEC_SA_AUTH_INFORMATION0 saAuthInformation;
	}

	/// <summary>
	/// The <c>IPSEC_SA_AUTH_INFORMATION0</c> structure stores information about the authentication algorithm of an IPsec security
	/// association (SA).
	/// </summary>
	/// <remarks>
	/// <c>IPSEC_SA_AUTH_INFORMATION0</c> is a specific implementation of IPSEC_SA_AUTH_INFORMATION. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_auth_information0 typedef struct
	// IPSEC_SA_AUTH_INFORMATION0_ { IPSEC_AUTH_TRANSFORM0 authTransform; FWP_BYTE_BLOB authKey; } IPSEC_SA_AUTH_INFORMATION0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_AUTH_INFORMATION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_AUTH_INFORMATION0
	{
		/// <summary>Authentication algorithm details as specified by IPSEC_AUTH_TRANSFORM0.</summary>
		public IPSEC_AUTH_TRANSFORM0 authTransform;

		/// <summary>Key used for the authentication algorithm stored in a FWP_BYTE_BLOB structure.</summary>
		public FWP_BYTE_BLOB authKey;
	}

	/// <summary>
	/// The <c>IPSEC_SA_BUNDLE0</c> structure is used to store information about an IPsec security association (SA) bundle. IPSEC_SA_BUNDLE1
	/// is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_bundle0 typedef struct IPSEC_SA_BUNDLE0_ { UINT32
	// flags; IPSEC_SA_LIFETIME0 lifetime; UINT32 idleTimeoutSeconds; UINT32 ndAllowClearTimeoutSeconds; IPSEC_ID0 *ipsecId; UINT32
	// napContext; UINT32 qmSaId; UINT32 numSAs; IPSEC_SA0 *saList; IPSEC_KEYMODULE_STATE0 *keyModuleState; FWP_IP_VERSION ipVersion; union {
	// UINT32 peerV4PrivateAddress; }; UINT64 mmSaId; IPSEC_PFS_GROUP pfsGroup; } IPSEC_SA_BUNDLE0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_BUNDLE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_BUNDLE0
	{
		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IPsec SA bundle flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_ND_SECURE</c></term>
		/// <term>Negotiation discovery is enabled in secure ring.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_ND_BOUNDARY</c></term>
		/// <term>Negotiation discovery in enabled in the untrusted perimeter zone.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_ND_PEER_NAT_BOUNDARY</c></term>
		/// <term>Peer is in untrusted perimeter zone ring and a NAT is in the way. Used with negotiation discovery.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_GUARANTEE_ENCRYPTION</c></term>
		/// <term>Indicates that this is an SA for connections that require guaranteed encryption.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_NLB</c></term>
		/// <term>Indicates that this is an SA to an NLB server.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_NO_MACHINE_LUID_VERIFY</c></term>
		/// <term>Indicates that this SA should bypass machine LUID verification.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_NO_IMPERSONATION_LUID_VERIFY</c></term>
		/// <term>Indicates that this SA should bypass impersonation LUID verification.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_NO_EXPLICIT_CRED_MATCH</c></term>
		/// <term>Indicates that this SA should bypass explicit credential handle matching.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_ALLOW_NULL_TARGET_NAME_MATCH</c></term>
		/// <term>Allows an SA formed with a peer name to carry traffic that does not have an associated peer target.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_CLEAR_DF_ON_TUNNEL</c></term>
		/// <term>
		/// Clears the <c>DontFragment</c> bit on the outer IP header of an IPsec-tunneled packet. This flag is applicable only to tunnel
		/// mode SAs.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_ASSUME_UDP_CONTEXT_OUTBOUND</c></term>
		/// <term>
		/// Default encapsulation ports (4500 and 4000) can be used when matching this SA with packets on outbound connections that do not
		/// have an associated IPsec-NAT-shim context.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_ND_PEER_BOUNDARY</c></term>
		/// <term>Peer has negotiation discovery enabled, and is on a perimeter network.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_SA_BUNDLE_FLAG flags;

		/// <summary>Lifetime of all the SAs in the bundle as specified by IPSEC_SA_LIFETIME0.</summary>
		public IPSEC_SA_LIFETIME0 lifetime;

		/// <summary>Timeout in seconds after which the SAs in the bundle will idle out (due to traffic inactivity) and expire.</summary>
		public uint idleTimeoutSeconds;

		/// <summary>
		/// <para>Timeout in seconds, after which the IPsec SA should stop accepting packets coming in the clear.</para>
		/// <para>Used for negotiation discovery.</para>
		/// </summary>
		public uint ndAllowClearTimeoutSeconds;

		/// <summary>Pointer to an <see cref="IPSEC_ID0"/> structure that contains optional IPsec identity info.</summary>
		public IntPtr ipsecId;

		/// <summary>Network Access Protection (NAP) peer credentials information.</summary>
		public uint napContext;

		/// <summary>
		/// SA identifier used by IPsec when choosing the SA to expire. For an IPsec SA pair, the <c>qmSaId</c> must be the same between the
		/// initiating and responding machines and across inbound and outbound SA bundles. For different IPsec pairs, the <c>qmSaId</c> must
		/// be different.
		/// </summary>
		public uint qmSaId;

		/// <summary>Number of SAs in the bundle. The only possible values are 1 and 2. Use 2 only when specifying AH + ESP SAs.</summary>
		public uint numSAs;

		/// <summary>
		/// <para>Array of IPsec SAs in the bundle. For AH + ESP SAs, use index [0] for ESP SA and index [1] for AH SA.</para>
		/// <para>See IPSEC_SA0 for more information.</para>
		/// </summary>
		public IntPtr saList;

		/// <summary>Optional keying module specific information as specified by IPSEC_KEYMODULE_STATE0.</summary>
		public IntPtr keyModuleState;

		/// <summary>IP version as specified by FWP_IP_VERSION.</summary>
		public FWP_IP_VERSION ipVersion;

		/// <summary>
		/// Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>. If peer is behind a network address translation (NAT) device, this
		/// member stores the peer's private address.
		/// </summary>
		public IN_ADDR peerV4PrivateAddress;

		/// <summary>Use this ID to correlate this IPsec SA with the IKE SA that generated it.</summary>
		public ulong mmSaId;

		/// <summary>
		/// <para>
		/// Specifies whether Quick Mode perfect forward secrecy (PFS) was enabled for this SA, and if so, contains the Diffie-Hellman group
		/// that was used for PFS.
		/// </para>
		/// <para>See IPSEC_PFS_GROUP for more information.</para>
		/// </summary>
		public IPSEC_PFS_GROUP pfsGroup;
	}

	/// <summary>
	/// The <c>IPSEC_SA_BUNDLE1</c> structure is used to store information about an IPsec security association (SA) bundle. IPSEC_SA_BUNDLE0
	/// is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_bundle1 typedef struct IPSEC_SA_BUNDLE1_ { UINT32
	// flags; IPSEC_SA_LIFETIME0 lifetime; UINT32 idleTimeoutSeconds; UINT32 ndAllowClearTimeoutSeconds; IPSEC_ID0 *ipsecId; UINT32
	// napContext; UINT32 qmSaId; UINT32 numSAs; IPSEC_SA0 *saList; IPSEC_KEYMODULE_STATE0 *keyModuleState; FWP_IP_VERSION ipVersion; union {
	// UINT32 peerV4PrivateAddress; }; UINT64 mmSaId; IPSEC_PFS_GROUP pfsGroup; GUID saLookupContext; UINT64 qmFilterId; } IPSEC_SA_BUNDLE1;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_BUNDLE1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_BUNDLE1
	{
		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IPsec SA bundle flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_ND_SECURE</c></term>
		/// <term>Negotiation discovery is enabled in secure ring.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_ND_BOUNDARY</c></term>
		/// <term>Negotiation discovery in enabled in the untrusted perimeter zone.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_ND_PEER_NAT_BOUNDARY</c></term>
		/// <term>Peer is in untrusted perimeter zone ring and a network address translation (NAT) is in the way. Used with negotiation discovery.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_GUARANTEE_ENCRYPTION</c></term>
		/// <term>Indicates that this is an SA for connections that require guaranteed encryption.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_NLB</c></term>
		/// <term>Indicates that this is an SA to an NLB server.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_NO_MACHINE_LUID_VERIFY</c></term>
		/// <term>Indicates that this SA should bypass machine LUID verification.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_NO_IMPERSONATION_LUID_VERIFY</c></term>
		/// <term>Indicates that this SA should bypass impersonation LUID verification.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_NO_EXPLICIT_CRED_MATCH</c></term>
		/// <term>Indicates that this SA should bypass explicit credential handle matching.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_ALLOW_NULL_TARGET_NAME_MATCH</c></term>
		/// <term>Allows an SA formed with a peer name to carry traffic that does not have an associated peer target.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_CLEAR_DF_ON_TUNNEL</c></term>
		/// <term>
		/// Clears the <c>DontFragment</c> bit on the outer IP header of an IPsec-tunneled packet. This flag is applicable only to tunnel
		/// mode SAs.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_ASSUME_UDP_CONTEXT_OUTBOUND</c></term>
		/// <term>
		/// Default encapsulation ports (4500 and 4000) can be used when matching this SA with packets on outbound connections that do not
		/// have an associated IPsec-NAT-shim context.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_ND_PEER_BOUNDARY</c></term>
		/// <term>Peer has negotiation discovery enabled, and is on a perimeter network.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_SUPPRESS_DUPLICATE_DELETION</c></term>
		/// <term>
		/// Suppresses the duplicate SA deletion logic. THis logic is performed by the kernel when an outbound SA is added, to prevent
		/// unnecessary duplicate SAs.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_SA_BUNDLE_FLAG_PEER_SUPPORTS_GUARANTEE_ENCRYPTION</c></term>
		/// <term>Indicates that the peer computer supports negotiating a separate SA for connections that require guaranteed encryption.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_SA_BUNDLE_FLAG flags;

		/// <summary>Lifetime of all the SAs in the bundle as specified by IPSEC_SA_LIFETIME0.</summary>
		public IPSEC_SA_LIFETIME0 lifetime;

		/// <summary>Timeout in seconds after which the SAs in the bundle will idle out (due to traffic inactivity) and expire.</summary>
		public uint idleTimeoutSeconds;

		/// <summary>
		/// <para>Timeout in seconds, after which the IPsec SA should stop accepting packets coming in the clear.</para>
		/// <para>Used for negotiation discovery.</para>
		/// </summary>
		public uint ndAllowClearTimeoutSeconds;

		/// <summary>Pointer to an IPSEC_ID0 structure that contains optional IPsec identity info.</summary>
		public IntPtr ipsecId;

		/// <summary>Network Access Point (NAP) peer credentials information.</summary>
		public uint napContext;

		/// <summary>
		/// SA identifier used by IPsec when choosing the SA to expire. For an IPsec SA pair, the <c>qmSaId</c> must be the same between the
		/// initiating and responding machines and across inbound and outbound SA bundles. For different IPsec pairs, the <c>qmSaId</c> must
		/// be different.
		/// </summary>
		public uint qmSaId;

		/// <summary>Number of SAs in the bundle. The only possible values are 1 and 2. Use 2 only when specifying AH and ESP SAs.</summary>
		public uint numSAs;

		/// <summary>
		/// <para>Array of IPsec SAs in the bundle. For AH and ESP SAs, use index 0 for ESP SA and index 1 for AH SA.</para>
		/// <para>See IPSEC_SA0 for more information.</para>
		/// </summary>
		public IntPtr saList;

		/// <summary>Optional keying module specific information as specified by IPSEC_KEYMODULE_STATE0.</summary>
		public IntPtr keyModuleState;

		/// <summary>IP version as specified by FWP_IP_VERSION.</summary>
		public FWP_IP_VERSION ipVersion;

		/// <summary>
		/// Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>. If peer is behind a NAT device, this member stores the peer's
		/// private address.
		/// </summary>
		public IN_ADDR peerV4PrivateAddress;

		/// <summary>Use this ID to correlate this IPsec SA with the IKE SA that generated it.</summary>
		public ulong mmSaId;

		/// <summary>
		/// <para>
		/// Specifies whether Quick Mode perfect forward secrecy (PFS) was enabled for this SA, and if so, contains the Diffie-Hellman group
		/// that was used for PFS.
		/// </para>
		/// <para>See IPSEC_PFS_GROUP for more information.</para>
		/// </summary>
		public IPSEC_PFS_GROUP pfsGroup;

		/// <summary>
		/// SA lookup context which is propagated from the SA to data connections flowing over that SA. It is made available to any
		/// application that queries socket security properties using the Winsock API WSAQuerySocketSecurity function, allowing the
		/// application to obtain detailed IPsec authentication information for its connection.
		/// </summary>
		public Guid saLookupContext;

		/// <summary/>
		public ulong qmFilterId;
	}

	/// <summary>
	/// The <c>IPSEC_SA_CIPHER_INFORMATION0</c> structure stores information about the encryption algorithm of an IPsec security association (SA).
	/// </summary>
	/// <remarks>
	/// <c>IPSEC_SA_CIPHER_INFORMATION0</c> is a specific implementation of IPSEC_SA_CIPHER_INFORMATION. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_cipher_information0 typedef struct
	// IPSEC_SA_CIPHER_INFORMATION0_ { IPSEC_CIPHER_TRANSFORM0 cipherTransform; FWP_BYTE_BLOB cipherKey; } IPSEC_SA_CIPHER_INFORMATION0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_CIPHER_INFORMATION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_CIPHER_INFORMATION0
	{
		/// <summary>Encryption algorithm specific details as specified by IPSEC_CIPHER_TRANSFORM0.</summary>
		public IPSEC_CIPHER_TRANSFORM0 cipherTransform;

		/// <summary>Key used for the encryption algorithm as specified by FWP_BYTE_BLOB.</summary>
		public FWP_BYTE_BLOB cipherKey;
	}

	/// <summary>The <c>IPSEC_SA_CONTEXT_CHANGE0</c> structure contains information about an IPsec security association (SA) context change.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_context_change0 typedef struct
	// IPSEC_SA_CONTEXT_CHANGE0_ { IPSEC_SA_CONTEXT_EVENT_TYPE0 changeType; UINT64 saContextId; } IPSEC_SA_CONTEXT_CHANGE0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_CONTEXT_CHANGE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_CONTEXT_CHANGE0
	{
		/// <summary>
		/// <para>Type: IPSEC_SA_CONTEXT_EVENT_TYPE0</para>
		/// <para>The type of IPsec SA context change event.</para>
		/// </summary>
		public IPSEC_SA_CONTEXT_EVENT_TYPE0 changeType;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>Identifier of the IPsec SA context that changed.</para>
		/// </summary>
		public ulong saContextId;
	}

	/// <summary>
	/// The <c>IPSEC_SA_CONTEXT_ENUM_TEMPLATE0</c> structure is an enumeration template used to enumerate security association (SA) contexts.
	/// </summary>
	/// <remarks>
	/// <c>IPSEC_SA_CONTEXT_ENUM_TEMPLATE0</c> is a specific implementation of IPSEC_SA_CONTEXT_ENUM_TEMPLATE. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_context_enum_template0 typedef struct
	// IPSEC_SA_CONTEXT_ENUM_TEMPLATE0_ { FWP_CONDITION_VALUE0 localSubNet; FWP_CONDITION_VALUE0 remoteSubNet; } IPSEC_SA_CONTEXT_ENUM_TEMPLATE0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_CONTEXT_ENUM_TEMPLATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_CONTEXT_ENUM_TEMPLATE0
	{
		/// <summary>
		/// <para>
		/// An FWP_CONDITION_VALUE0 structure that specifies a subnet from which SA contexts that contain a local address will be returned.
		/// This member may be empty.
		/// </para>
		/// <para>Acceptable type values for this member are: FWP_V6_ADDR_AND_MASK.</para>
		/// </summary>
		public FWP_CONDITION_VALUE0 localSubNet;

		/// <summary>
		/// <para>
		/// An FWP_CONDITION_VALUE0 structure that specifies a subnet from which SA contexts that contain a remote address will be returned.
		/// This member may be empty.
		/// </para>
		/// <para>Acceptable type values for this member are: FWP_V6_ADDR_AND_MASK.</para>
		/// </summary>
		public FWP_CONDITION_VALUE0 remoteSubNet;
	}

	/// <summary>
	/// The <c>IPSEC_SA_CONTEXT_SUBSCRIPTION0</c> structure stores information used to subscribe to notifications about a particular IPsec
	/// security association (SA) context.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_context_subscription0 typedef struct
	// IPSEC_SA_CONTEXT_SUBSCRIPTION0_ { IPSEC_SA_CONTEXT_ENUM_TEMPLATE0 *enumTemplate; UINT32 flags; GUID sessionKey; } IPSEC_SA_CONTEXT_SUBSCRIPTION0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_CONTEXT_SUBSCRIPTION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_CONTEXT_SUBSCRIPTION0
	{
		/// <summary>
		/// <para>Type: <c>IPSEC_SA_CONTEXT_ENUM_TEMPLATE0*</c></para>
		/// <para>Enumeration template for limiting the subscription.</para>
		/// </summary>
		public IntPtr enumTemplate;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>This member is reserved for system use.</para>
		/// </summary>
		public uint flags;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>Identifies the session that created the subscription.</para>
		/// </summary>
		public Guid sessionKey;
	}

	/// <summary>The <c>IPSEC_SA_CONTEXT0</c> structure encapsulates an inbound and outbound SA pair. IPSEC_SA_CONTEXT1 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_context0 typedef struct IPSEC_SA_CONTEXT0_ {
	// UINT64 saContextId; IPSEC_SA_DETAILS0 *inboundSa; IPSEC_SA_DETAILS0 *outboundSa; } IPSEC_SA_CONTEXT0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_CONTEXT0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_CONTEXT0
	{
		/// <summary>Identifies the SA context.</summary>
		public ulong saContextId;

		/// <summary>An <see cref="IPSEC_SA_DETAILS0"/> structure that contains information about the inbound SA.</summary>
		public IntPtr inboundSa;

		/// <summary>An IPSEC_SA_DETAILS0 structure that contains information about the outbound SA.</summary>
		public IntPtr outboundSa;
	}

	/// <summary>
	/// The <c>IPSEC_SA_CONTEXT1</c> structure encapsulates an inbound and outbound security association (SA) pair. IPSEC_SA_CONTEXT0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_context1 typedef struct IPSEC_SA_CONTEXT1_ {
	// UINT64 saContextId; IPSEC_SA_DETAILS1 *inboundSa; IPSEC_SA_DETAILS1 *outboundSa; } IPSEC_SA_CONTEXT1;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_CONTEXT1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_CONTEXT1
	{
		/// <summary>Identifies the SA context.</summary>
		public ulong saContextId;

		/// <summary>An <see cref="IPSEC_SA_DETAILS1"/> structure that contains information about the inbound SA.</summary>
		public IntPtr inboundSa;

		/// <summary>An IPSEC_SA_DETAILS1 structure that contains information about the outbound SA.</summary>
		public IntPtr outboundSa;
	}

	/// <summary>
	/// The <c>IPSEC_SA_DETAILS0</c> structure is used to store information returned when enumerating IPsec security associations (SAs).
	/// IPSEC_SA_DETAILS1 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_details0 typedef struct IPSEC_SA_DETAILS0_ {
	// FWP_IP_VERSION ipVersion; FWP_DIRECTION saDirection; IPSEC_TRAFFIC0 traffic; IPSEC_SA_BUNDLE0 saBundle; union {
	// IPSEC_V4_UDP_ENCAPSULATION0 *udpEncapsulation; }; FWPM_FILTER0 *transportFilter; } IPSEC_SA_DETAILS0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_DETAILS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_DETAILS0
	{
		/// <summary>Internet Protocol (IP) version as specified by FWP_IP_VERSION.</summary>
		public FWP_IP_VERSION ipVersion;

		/// <summary>Indicates direction of the IPsec SA as specified by FWP_DIRECTION.</summary>
		public FWP_DIRECTION saDirection;

		/// <summary>The traffic being secured by this IPsec SA as specified by IPSEC_TRAFFIC0.</summary>
		public IPSEC_TRAFFIC0 traffic;

		/// <summary>Various parameters of the SA as specified by IPSEC_SA_BUNDLE0.</summary>
		public IPSEC_SA_BUNDLE0 saBundle;

		/// <summary>
		/// <para>
		/// An <see cref="IPSEC_V4_UDP_ENCAPSULATION0"/> structure that stores the UDP encapsulation ports if UDP-ESP encapsulation is
		/// enabled on the SA.
		/// </para>
		/// <para>Available if <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IntPtr udpEncapsulation;

		/// <summary>The transport layer filter corresponding to this IPsec SA as specified by FWPM_FILTER0.</summary>
		public IntPtr transportFilter;
	}

	/// <summary>
	/// The <c>IPSEC_SA_DETAILS1</c> structure is used to store information returned when enumerating IPsec security associations (SAs).
	/// IPSEC_SA_DETAILS0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_details1 typedef struct IPSEC_SA_DETAILS1_ {
	// FWP_IP_VERSION ipVersion; FWP_DIRECTION saDirection; IPSEC_TRAFFIC1 traffic; IPSEC_SA_BUNDLE1 saBundle; union {
	// IPSEC_V4_UDP_ENCAPSULATION0 *udpEncapsulation; }; FWPM_FILTER0 *transportFilter; IPSEC_VIRTUAL_IF_TUNNEL_INFO0 virtualIfTunnelInfo; } IPSEC_SA_DETAILS1;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_DETAILS1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_DETAILS1
	{
		/// <summary>An FWP_IP_VERSION value that specifies the IP version. In tunnel mode, this is the version of the outer header.</summary>
		public FWP_IP_VERSION ipVersion;

		/// <summary>An FWP_DIRECTION value that indicates the direction of the IPsec SA.</summary>
		public FWP_DIRECTION saDirection;

		/// <summary>
		/// An IPSEC_TRAFFIC1 structure that specifies the traffic being secured by this IPsec SA. In tunnel mode, this contains both the
		/// tunnel endpoints and Quick Mode (QM) traffic selectors.
		/// </summary>
		public IPSEC_TRAFFIC1 traffic;

		/// <summary>An IPSEC_SA_BUNDLE1 structure that specifies various parameters of the SA .</summary>
		public IPSEC_SA_BUNDLE1 saBundle;

		/// <summary>
		/// <para>
		/// An IPSEC_V4_UDP_ENCAPSULATION0 structure that stores the UDP encapsulation ports if UDP-ESP encapsulation is enabled on the SA.
		/// </para>
		/// <para>Available if <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IntPtr udpEncapsulation;

		/// <summary>An FWPM_FILTER0 structure that specifies the transport layer filter that corresponds to this IPsec SA.</summary>
		public IntPtr transportFilter;

		/// <summary>
		/// An IPSEC_VIRTUAL_IF_TUNNEL_INFO0 structure that specifies the virtual interface tunnel information. Only supported by Internet
		/// Key Exchange version 2 (IKEv2).
		/// </summary>
		public IPSEC_VIRTUAL_IF_TUNNEL_INFO0 virtualIfTunnelInfo;
	}

	/// <summary>
	/// The <c>IPSEC_SA_ENUM_TEMPLATE0</c> structure specifies a template used for restricting the enumeration of IPsec security associations (SAs).
	/// </summary>
	/// <remarks>
	/// <c>IPSEC_SA_ENUM_TEMPLATE0</c> is a specific implementation of IPSEC_SA_ENUM_TEMPLATE. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_enum_template0 typedef struct
	// IPSEC_SA_ENUM_TEMPLATE0_ { FWP_DIRECTION saDirection; } IPSEC_SA_ENUM_TEMPLATE0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_ENUM_TEMPLATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_ENUM_TEMPLATE0
	{
		/// <summary>
		/// <para>Direction of the SA.</para>
		/// <para>See FWP_DIRECTION for more information.</para>
		/// </summary>
		public FWP_DIRECTION saDirection;
	}

	/// <summary>The <c>IPSEC_SA_IDLE_TIMEOUT0</c> structure specifies the security association (SA) idle timeout in IPsec policy.</summary>
	/// <remarks>
	/// <c>IPSEC_SA_IDLE_TIMEOUT0</c> is a specific implementation of IPSEC_SA_IDLE_TIMEOUT. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_idle_timeout0 typedef struct
	// IPSEC_SA_IDLE_TIMEOUT0_ { UINT32 idleTimeoutSeconds; UINT32 idleTimeoutSecondsFailOver; } IPSEC_SA_IDLE_TIMEOUT0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_IDLE_TIMEOUT0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_IDLE_TIMEOUT0
	{
		/// <summary>Specifies the amount of time in seconds after which IPsec SAs should become idle.</summary>
		public uint idleTimeoutSeconds;

		/// <summary>
		/// Specifies the amount of time in seconds after which IPsec SAs should become idle if the peer machine supports fail over.
		/// </summary>
		public uint idleTimeoutSecondsFailOver;
	}

	/// <summary>
	/// The <c>IPSEC_SA_LIFETIME0</c> structure stores the lifetime in seconds/kilobytes/packets for an IPsec security association (SA).
	/// </summary>
	/// <remarks>
	/// <c>IPSEC_SA_LIFETIME0</c> is a specific implementation of IPSEC_SA_LIFETIME. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_lifetime0 typedef struct IPSEC_SA_LIFETIME0_ {
	// UINT32 lifetimeSeconds; UINT32 lifetimeKilobytes; UINT32 lifetimePackets; } IPSEC_SA_LIFETIME0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_LIFETIME0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_LIFETIME0
	{
		/// <summary>SA lifetime in seconds.</summary>
		public uint lifetimeSeconds;

		/// <summary>SA lifetime in kilobytes.</summary>
		public uint lifetimeKilobytes;

		/// <summary>SA lifetime in packets.</summary>
		public uint lifetimePackets;
	}

	/// <summary>
	/// The <c>IPSEC_SA_TRANSFORM0</c> structure is used to store an IPsec security association (SA) transform in an IPsec quick mode policy.
	/// </summary>
	/// <remarks>
	/// <c>IPSEC_SA_TRANSFORM0</c> is a specific implementation of IPSEC_SA_TRANSFORM. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa_transform0 typedef struct IPSEC_SA_TRANSFORM0_ {
	// IPSEC_TRANSFORM_TYPE ipsecTransformType; union { IPSEC_AUTH_TRANSFORM0 *ahTransform; IPSEC_AUTH_TRANSFORM0 *espAuthTransform;
	// IPSEC_CIPHER_TRANSFORM0 *espCipherTransform; IPSEC_AUTH_AND_CIPHER_TRANSFORM0 *espAuthAndCipherTransform; IPSEC_AUTH_TRANSFORM0
	// *espAuthFwTransform; }; } IPSEC_SA_TRANSFORM0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA_TRANSFORM0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA_TRANSFORM0
	{
		/// <summary>
		/// <para>Type of the SA transform.</para>
		/// <para>See IPSEC_TRANSFORM_TYPE for more information.</para>
		/// </summary>
		public IPSEC_TRANSFORM_TYPE ipsecTransformType;

		private IntPtr ptr;

		/// <summary>
		/// <para>SA transform data. Available when <c>ipsecTransformType</c> is <c>IPSEC_TRANSFORM_AH</c>.</para>
		/// <para>See IPSEC_AUTH_TRANSFORM0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_AUTH_TRANSFORM0> ahTransform { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>SA transform data. Available when <c>ipsecTransformType</c> is <c>IPSEC_TRANSFORM_ESP_AUTH</c>.</para>
		/// <para>See IPSEC_AUTH_TRANSFORM0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_AUTH_TRANSFORM0> espAuthTransform { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>SA transform data. Available when <c>ipsecTransformType</c> is <c>IPSEC_TRANSFORM_ESP_CIPHER</c>.</para>
		/// <para>See IPSEC_CIPHER_TRANSFORM0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_CIPHER_TRANSFORM0> espCipherTransform { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>SA transform data. Available when <c>ipsecTransformType</c> is <c>IPSEC_TRANSFORM_ESP_AUTH_AND_CIPHER</c>.</para>
		/// <para>See IPSEC_AUTH_AND_CIPHER_TRANSFORM0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_AUTH_AND_CIPHER_TRANSFORM0> espAuthAndCipherTransform { get => new(ptr, false); set => ptr = value; }

		/// <summary>
		/// <para>SA transform data. Available when <c>ipsecTransformType</c> is <c>IPSEC_TRANSFORM_ESP_AUTH_FW</c>.</para>
		/// <para>See IPSEC_AUTH_TRANSFORM0 for more information.</para>
		/// <para><c>Note</c> Available only on Windows Server 2008 R2, Windows 7, or later.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_AUTH_TRANSFORM0> espAuthFwTransform { get => new(ptr, false); set => ptr = value; }
	}

	/// <summary>The <c>IPSEC_SA0</c> structure is used to store information about an IPsec security association (SA).</summary>
	/// <remarks>
	/// <c>IPSEC_SA0</c> is a specific implementation of IPSEC_SA. See WFP Version-Independent Names and Targeting Specific Versions of
	/// Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_sa0 typedef struct IPSEC_SA0_ { IPSEC_SA_SPI spi;
	// IPSEC_TRANSFORM_TYPE saTransformType; union { IPSEC_SA_AUTH_INFORMATION0 *ahInformation; IPSEC_SA_AUTH_INFORMATION0
	// *espAuthInformation; IPSEC_SA_CIPHER_INFORMATION0 *espCipherInformation; IPSEC_SA_AUTH_AND_CIPHER_INFORMATION0
	// *espAuthAndCipherInformation; IPSEC_SA_AUTH_INFORMATION0 *espAuthFwInformation; }; } IPSEC_SA0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_SA0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_SA0
	{
		/// <summary>Security parameter index (SPI) of the IPsec SA. <c>IPSEC_SA_SPI</c> is defined in ipsectypes.h as UINT32.</summary>
		public uint spi;

		/// <summary>
		/// <para>Transform type of the SA specifying the IPsec security protocol.</para>
		/// <para>See IPSEC_TRANSFORM_TYPE for more information.</para>
		/// </summary>
		public IPSEC_TRANSFORM_TYPE saTransformType;

		private IntPtr ptr;

		/// <summary>
		/// <para>Security algorithms of the SA transform. Available when <c>saTransformType</c> is <c>IPSEC_TRANSFORM_AH</c>.</para>
		/// <para>See IPSEC_SA_AUTH_INFORMATION0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_SA_AUTH_INFORMATION0> ahInformation { get => new(ptr, false); set => ptr = value; }
		/// <summary>
		/// <para>Security algorithms of the SA transform. Available when <c>saTransformType</c> is <c>IPSEC_TRANSFORM_ESP_AUTH</c>.</para>
		/// <para>See IPSEC_SA_AUTH_INFORMATION0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_SA_AUTH_INFORMATION0> espAuthInformation { get => new(ptr, false); set => ptr = value; }
		/// <summary>
		/// <para>Security algorithms of the SA transform. Available when <c>saTransformType</c> is <c>IPSEC_TRANSFORM_ESP_CIPHER</c>.</para>
		/// <para>See IPSEC_SA_CIPHER_INFORMATION0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_SA_CIPHER_INFORMATION0> espCipherInformation { get => new(ptr, false); set => ptr = value; }
		/// <summary>
		/// <para>Security algorithms of the SA transform. Available when <c>saTransformType</c> is <c>IPSEC_TRANSFORM_ESP_AUTH_AND_CIPHER</c>.</para>
		/// <para>See IPSEC_SA_AUTH_AND_CIPHER_INFORMATION0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_SA_AUTH_AND_CIPHER_INFORMATION0> espAuthAndCipherInformation { get => new(ptr, false); set => ptr = value; }
		/// <summary>
		/// <para>Security algorithms of the SA transform. Available when <c>saTransformType</c> is <c>IPSEC_TRANSFORM_ESP_AUTH_FW</c>.</para>
		/// <para><c>Note</c> Available only on Windows Server 2008 R2, Windows 7, or later.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IPSEC_SA_AUTH_INFORMATION0> espAuthFwInformation { get => new(ptr, false); set => ptr = value; }	}

	/// <summary>The <c>IPSEC_STATISTICS0</c> structure is the top-level of the IPsec statistics structures. IPSEC_STATISTICS1 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_statistics0 typedef struct IPSEC_STATISTICS0_ {
	// IPSEC_AGGREGATE_SA_STATISTICS0 aggregateSaStatistics; IPSEC_ESP_DROP_PACKET_STATISTICS0 espDropPacketStatistics;
	// IPSEC_AH_DROP_PACKET_STATISTICS0 ahDropPacketStatistics; IPSEC_AGGREGATE_DROP_PACKET_STATISTICS0 aggregateDropPacketStatistics;
	// IPSEC_TRAFFIC_STATISTICS0 inboundTrafficStatistics; IPSEC_TRAFFIC_STATISTICS0 outboundTrafficStatistics; } IPSEC_STATISTICS0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_STATISTICS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_STATISTICS0
	{
		/// <summary>IPSEC_AGGREGATE_SA_STATISTICS0 structure containing IPsec aggregate SA statistics.</summary>
		public IPSEC_AGGREGATE_SA_STATISTICS0 aggregateSaStatistics;

		/// <summary>IPSEC_ESP_DROP_PACKET_STATISTICS0 structure containing IPsec ESP drop packet statistics.</summary>
		public IPSEC_ESP_DROP_PACKET_STATISTICS0 espDropPacketStatistics;

		/// <summary>IPSEC_AH_DROP_PACKET_STATISTICS0 structure containing IPsec AH drop packet statistics.</summary>
		public IPSEC_AH_DROP_PACKET_STATISTICS0 ahDropPacketStatistics;

		/// <summary>IPSEC_AGGREGATE_DROP_PACKET_STATISTICS0 structure containing IPsec aggregate drop packet statistics.</summary>
		public IPSEC_AGGREGATE_DROP_PACKET_STATISTICS0 aggregateDropPacketStatistics;

		/// <summary>IPSEC_TRAFFIC_STATISTICS0 structure containing IPsec inbound traffic statistics.</summary>
		public IPSEC_TRAFFIC_STATISTICS0 inboundTrafficStatistics;

		/// <summary>IPSEC_TRAFFIC_STATISTICS0 structure containing IPsec outbound traffic statistics.</summary>
		public IPSEC_TRAFFIC_STATISTICS0 outboundTrafficStatistics;
	}

	/// <summary>The <c>IPSEC_STATISTICS1</c> structure is the top-level of the IPsec statistics structures. IPSEC_STATISTICS0 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_statistics1 typedef struct IPSEC_STATISTICS1_ {
	// IPSEC_AGGREGATE_SA_STATISTICS0 aggregateSaStatistics; IPSEC_ESP_DROP_PACKET_STATISTICS0 espDropPacketStatistics;
	// IPSEC_AH_DROP_PACKET_STATISTICS0 ahDropPacketStatistics; IPSEC_AGGREGATE_DROP_PACKET_STATISTICS1 aggregateDropPacketStatistics;
	// IPSEC_TRAFFIC_STATISTICS1 inboundTrafficStatistics; IPSEC_TRAFFIC_STATISTICS1 outboundTrafficStatistics; } IPSEC_STATISTICS1;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_STATISTICS1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_STATISTICS1
	{
		/// <summary>IPSEC_AGGREGATE_SA_STATISTICS0 structure containing IPsec aggregate SA statistics.</summary>
		public IPSEC_AGGREGATE_SA_STATISTICS0 aggregateSaStatistics;

		/// <summary>IPSEC_ESP_DROP_PACKET_STATISTICS0 structure containing IPsec ESP drop packet statistics.</summary>
		public IPSEC_ESP_DROP_PACKET_STATISTICS0 espDropPacketStatistics;

		/// <summary>IPSEC_AH_DROP_PACKET_STATISTICS0 structure containing IPsec AH drop packet statistics.</summary>
		public IPSEC_AH_DROP_PACKET_STATISTICS0 ahDropPacketStatistics;

		/// <summary>IPSEC_AGGREGATE_DROP_PACKET_STATISTICS1 structure containing IPsec aggregate drop packet statistics.</summary>
		public IPSEC_AGGREGATE_DROP_PACKET_STATISTICS1 aggregateDropPacketStatistics;

		/// <summary>IPSEC_TRAFFIC_STATISTICS1 structure containing IPsec inbound traffic statistics.</summary>
		public IPSEC_TRAFFIC_STATISTICS1 inboundTrafficStatistics;

		/// <summary>IPSEC_TRAFFIC_STATISTICS1 structure containing IPsec outbound traffic statistics.</summary>
		public IPSEC_TRAFFIC_STATISTICS1 outboundTrafficStatistics;
	}

	/// <summary>The <c>IPSEC_TOKEN0</c> structure contains various information about an IPsec-specific access token.</summary>
	/// <remarks>
	/// <c>IPSEC_TOKEN0</c> is a specific implementation of IPSEC_TOKEN. See WFP Version-Independent Names and Targeting Specific Versions of
	/// Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_token0 typedef struct IPSEC_TOKEN0_ {
	// IPSEC_TOKEN_TYPE type; IPSEC_TOKEN_PRINCIPAL principal; IPSEC_TOKEN_MODE mode; IPSEC_TOKEN_HANDLE token; } IPSEC_TOKEN0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TOKEN0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TOKEN0
	{
		/// <summary>An IPSEC_TOKEN_TYPE value that specifies the type of token.</summary>
		public IPSEC_TOKEN_TYPE type;

		/// <summary>An IPSEC_TOKEN_PRINCIPAL value that specifies the token principal.</summary>
		public IPSEC_TOKEN_PRINCIPAL principal;

		/// <summary>An IPSEC_TOKEN_MODE value that indicates in which mode the token was obtained.</summary>
		public IPSEC_TOKEN_MODE mode;

		/// <summary>Handle to the access token. An <c>IPSEC_TOKEN_HANDLE</c> is of type <c>UINT64</c>.</summary>
		public ulong token;
	}

	/// <summary>The <c>IPSEC_TRAFFIC_STATISTICS0</c> structure stores IPsec traffic statistics. IPSEC_TRAFFIC_STATISTICS1 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_traffic_statistics0 typedef struct
	// IPSEC_TRAFFIC_STATISTICS0_ { UINT64 encryptedByteCount; UINT64 authenticatedAHByteCount; UINT64 authenticatedESPByteCount; UINT64
	// transportByteCount; UINT64 tunnelByteCount; UINT64 offloadByteCount; } IPSEC_TRAFFIC_STATISTICS0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TRAFFIC_STATISTICS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TRAFFIC_STATISTICS0
	{
		/// <summary>Specifies encrypted byte count.</summary>
		public ulong encryptedByteCount;

		/// <summary>Specifies authenticated AH byte count.</summary>
		public ulong authenticatedAHByteCount;

		/// <summary>Specifies authenticated ESP byte count.</summary>
		public ulong authenticatedESPByteCount;

		/// <summary>Specifies transport byte count.</summary>
		public ulong transportByteCount;

		/// <summary>Specifies tunnel byte count.</summary>
		public ulong tunnelByteCount;

		/// <summary>Specifies offload byte count.</summary>
		public ulong offloadByteCount;
	}

	/// <summary>The <c>IPSEC_TRAFFIC_STATISTICS1</c> structure stores IPsec traffic statistics. IPSEC_TRAFFIC_STATISTICS0 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_traffic_statistics1 typedef struct
	// IPSEC_TRAFFIC_STATISTICS1_ { UINT64 encryptedByteCount; UINT64 authenticatedAHByteCount; UINT64 authenticatedESPByteCount; UINT64
	// transportByteCount; UINT64 tunnelByteCount; UINT64 offloadByteCount; UINT64 totalSuccessfulPackets; } IPSEC_TRAFFIC_STATISTICS1;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TRAFFIC_STATISTICS1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TRAFFIC_STATISTICS1
	{
		/// <summary>Specifies encrypted byte count.</summary>
		public ulong encryptedByteCount;

		/// <summary>Specifies authenticated AH byte count.</summary>
		public ulong authenticatedAHByteCount;

		/// <summary>Specifies authenticated ESP byte count.</summary>
		public ulong authenticatedESPByteCount;

		/// <summary>Specifies transport byte count.</summary>
		public ulong transportByteCount;

		/// <summary>Specifies tunnel byte count.</summary>
		public ulong tunnelByteCount;

		/// <summary>Specifies offload byte count.</summary>
		public ulong offloadByteCount;

		/// <summary>The total number of packets that were successfully transmitted.</summary>
		public ulong totalSuccessfulPackets;
	}

	/// <summary>The <c>IPSEC_TRAFFIC0</c> structure specifies parameters to describe IPsec traffic. IPSEC_TRAFFIC1 is available.</summary>
	/// <remarks>
	/// <para>The <c>IPSEC_TRAFFIC0</c> type describes the characteristics of the traffic that will match the SA.</para>
	/// <para>
	/// For IPsec transport mode, the <c>localVAddress</c> and <c>remoteVAddress</c> members specify the IP addresses. The
	/// <c>ipsecFilterId</c> member specifies (as part of the transport layer filter conditions) the transport protocol information (such as
	/// IP protocol, ports, etc), of the matching traffic. However, if the <c>remotePort</c> member is nonzero, its value will override the
	/// remote port specified in the transport layer filter.
	/// </para>
	/// <para>
	/// For IPsec tunnel mode, the <c>localVAddress</c> and <c>remoteVAddress</c> members specify the outer IP header tunnel endpoints. The
	/// <c>tunnelPolicyId</c> member specifies (as part of the filter conditions specified via FwpmIPsecTunnelAdd0) the inner IP header
	/// addresses, transport protocol information, of the matching traffic. The <c>remotePort</c> member should not be specified for tunnel mode.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_traffic0 typedef struct IPSEC_TRAFFIC0_ {
	// FWP_IP_VERSION ipVersion; union { UINT32 localV4Address; UINT8 localV6Address[16]; }; union { UINT32 remoteV4Address; UINT8
	// remoteV6Address[16]; }; IPSEC_TRAFFIC_TYPE trafficType; union { UINT64 ipsecFilterId; UINT64 tunnelPolicyId; }; UINT16 remotePort; } IPSEC_TRAFFIC0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TRAFFIC0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TRAFFIC0
	{
		/// <summary>
		/// <para>Internet Protocol (IP) version.</para>
		/// <para>See FWP_IP_VERSION for more information.</para>
		/// </summary>
		public FWP_IP_VERSION ipVersion;

		private FWP_BYTE_ARRAY_ADDR local;
		private FWP_BYTE_ARRAY_ADDR remote;

		/// <summary>
		/// <para>The local IPv4 address of the IPsec traffic.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR localV4Address { get => local.addr; set => local.addr = value; }

		/// <summary>
		/// <para>The local IPv6 address of the IPsec traffic.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR localV6Address { get => local.addr6; set => local.addr6 = value; }

		/// <summary>
		/// <para>The remote IPv4 address of the IPsec traffic.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR remoteV4Address { get => remote.addr; set => remote.addr = value; }

		/// <summary>
		/// <para>The remote IPv6 address of the IPsec traffic.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR remoteV6Address { get => remote.addr6; set => remote.addr6 = value; }

		/// <summary>
		/// <para>Type of IPsec traffic.</para>
		/// <para>See IPSEC_TRAFFIC_TYPE for more information.</para>
		/// </summary>
		public IPSEC_TRAFFIC_TYPE trafficType;

		/// <summary>
		/// <para>The LUID of the FWPS transport layer filter corresponding to this traffic.</para>
		/// <para>Available if <c>trafficType</c> is <c>IPSEC_TRAFFIC_TYPE_TRANSPORT</c>.</para>
		/// </summary>
		public ulong ipsecFilterId;

		/// <summary>
		/// <para>The LUID of the associated Quick Mode (QM) tunnel policy.</para>
		/// <para>Available if <c>trafficType</c> is <c>IPSEC_TRAFFIC_TYPE_TUNNEL</c>.</para>
		/// </summary>
		public ulong tunnelPolicyId { get => ipsecFilterId; set => ipsecFilterId = value; }

		/// <summary>
		/// The remote TCP/UDP port for this traffic. This is used when the remote port condition in the transport layer filter is more
		/// generic than the actual remote port.
		/// </summary>
		public ushort remotePort;
	}

	/// <summary>The <c>IPSEC_TRAFFIC1</c> structure specifies parameters to describe IPsec traffic. IPSEC_TRAFFIC0 is available.</summary>
	/// <remarks>
	/// <para>The <c>IPSEC_TRAFFIC1</c> type describes the characteristics of the traffic that will match the SA.</para>
	/// <para>
	/// For IPsec transport mode, the <c>localVAddress</c> and <c>remoteVAddress</c> members specify the IP addresses. The
	/// <c>ipsecFilterId</c> member specifies (as part of the transport layer filter conditions) the transport protocol information (such as
	/// IP protocol, ports, etc), of the matching traffic. However, if the <c>localPort</c>, <c>remotePort</c>, or <c>ipProtocol</c> member
	/// is nonzero, its value will override the corresponding value specified in the transport layer filter.
	/// </para>
	/// <para>
	/// For IPsec tunnel mode, the <c>localVAddress</c> and <c>remoteVAddress</c> members specify the outer IP header tunnel endpoints. The
	/// <c>tunnelPolicyId</c> member specifies (as part of the filter conditions specified via FwpmIPsecTunnelAdd1) the inner IP header
	/// addresses and transport protocol information of the matching traffic. The <c>localPort</c>, <c>remotePort</c>, and <c>ipProtocol</c>
	/// members should not be specified for tunnel mode.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_traffic1 typedef struct IPSEC_TRAFFIC1_ {
	// FWP_IP_VERSION ipVersion; union { UINT32 localV4Address; UINT8 localV6Address[16]; }; union { UINT32 remoteV4Address; UINT8
	// remoteV6Address[16]; }; IPSEC_TRAFFIC_TYPE trafficType; union { UINT64 ipsecFilterId; UINT64 tunnelPolicyId; }; UINT16 remotePort;
	// UINT16 localPort; UINT8 ipProtocol; UINT64 localIfLuid; UINT32 realIfProfileId; } IPSEC_TRAFFIC1;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TRAFFIC1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TRAFFIC1
	{
		/// <summary>
		/// <para>Internet Protocol (IP) version.</para>
		/// <para>See FWP_IP_VERSION for more information.</para>
		/// </summary>
		public FWP_IP_VERSION ipVersion;

		private FWP_BYTE_ARRAY_ADDR local;
		private FWP_BYTE_ARRAY_ADDR remote;

		/// <summary>
		/// <para>The local IPv4 address of the IPsec traffic.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR localV4Address { get => local.addr; set => local.addr = value; }

		/// <summary>
		/// <para>The local IPv6 address of the IPsec traffic.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR localV6Address { get => local.addr6; set => local.addr6 = value; }

		/// <summary>
		/// <para>The remote IPv4 address of the IPsec traffic.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR remoteV4Address { get => remote.addr; set => remote.addr = value; }

		/// <summary>
		/// <para>The remote IPv6 address of the IPsec traffic.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR remoteV6Address { get => remote.addr6; set => remote.addr6 = value; }

		/// <summary>
		/// <para>Type of IPsec traffic.</para>
		/// <para>See IPSEC_TRAFFIC_TYPE for more information.</para>
		/// </summary>
		public IPSEC_TRAFFIC_TYPE trafficType;

		/// <summary>
		/// <para>The LUID of the FWPS transport layer filter corresponding to this traffic.</para>
		/// <para>Available if <c>trafficType</c> is <c>IPSEC_TRAFFIC_TYPE_TRANSPORT</c>.</para>
		/// </summary>
		public ulong ipsecFilterId;

		/// <summary>
		/// <para>The LUID of the associated Quick Mode (QM) tunnel policy.</para>
		/// <para>Available if <c>trafficType</c> is <c>IPSEC_TRAFFIC_TYPE_TUNNEL</c>.</para>
		/// </summary>
		public ulong tunnelPolicyId { get => ipsecFilterId; set => ipsecFilterId = value; }

		/// <summary>
		/// The remote TCP/UDP port for this traffic. This is used when the remote port condition in the transport layer filter is more
		/// generic than the actual remote port.
		/// </summary>
		public ushort remotePort;

		/// <summary>
		/// The local TCP/UDP port for this traffic. This is used when the local port condition in the transport layer filter is more generic
		/// than the actual local port.
		/// </summary>
		public ushort localPort;

		/// <summary>
		/// The IP protocol for this traffic. This is used when the IP protocol condition in the transport layer filter is more generic than
		/// the actual IP protocol.
		/// </summary>
		public byte ipProtocol;

		/// <summary>The LUID of the local interface corresponding to the local address specified above.</summary>
		public ulong localIfLuid;

		/// <summary>The profile ID corresponding to the actual interface that the traffic is using.</summary>
		public uint realIfProfileId;
	}

	/// <summary>
	/// The <c>IPSEC_TRANSPORT_POLICY0</c> structure stores the quick mode negotiation policy for transport mode IPsec.
	/// IPSEC_TRANSPORT_POLICY2 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_transport_policy0 typedef struct
	// IPSEC_TRANSPORT_POLICY0_ { UINT32 numIpsecProposals; IPSEC_PROPOSAL0 *ipsecProposals; UINT32 flags; UINT32 ndAllowClearTimeoutSeconds;
	// IPSEC_SA_IDLE_TIMEOUT0 saIdleTimeout; IKEEXT_EM_POLICY0 *emPolicy; } IPSEC_TRANSPORT_POLICY0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TRANSPORT_POLICY0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TRANSPORT_POLICY0
	{
		/// <summary>Number of quick mode proposals in the policy.</summary>
		public uint numIpsecProposals;

		/// <summary>
		/// <para>Array of quick mode proposals.</para>
		/// <para>See IPSEC_PROPOSAL0 for more information.</para>
		/// </summary>
		public IntPtr ipsecProposals;

		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IPsec policy flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ND_SECURE</c></term>
		/// <term>Do negotiation discovery in secure ring.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ND_BOUNDARY</c></term>
		/// <term>Do negotiation discovery in the untrusted perimeter zone.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_NAT_ENCAP_ALLOW_PEER_BEHIND_NAT</c></term>
		/// <term>
		/// If set, IPsec expects that either the local or remote machine is behind a network address translation (NAT) device, but not both.
		/// This allows for less secure, but more flexible behavior.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_NAT_ENCAP_ALLOW_GENERAL_NAT_TRAVERSAL</c></term>
		/// <term>If set, IPsec expects default ports when either the local, the remote, or both machines are behind a NAT device.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_DONT_NEGOTIATE_SECOND_LIFETIME</c></term>
		/// <term>If set, Internet Key Exchange (IKE) will not send the ISAKMP attribute for 'seconds' lifetime during quick mode negotiation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_DONT_NEGOTIATE_BYTE_LIFETIME</c></term>
		/// <term>If set, IKE will not send the ISAKMP attribute for 'byte' lifetime during quick mode negotiation.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_POLICY_FLAG flags;

		/// <summary>
		/// Timeout in seconds, after which the IPsec security association (SA) should stop accepting packets coming in the clear. Used for
		/// negotiation discovery.
		/// </summary>
		public uint ndAllowClearTimeoutSeconds;

		/// <summary>An IPSEC_SA_IDLE_TIMEOUT0 structure that specifies the SA idle timeout in IPsec policy.</summary>
		public IPSEC_SA_IDLE_TIMEOUT0 saIdleTimeout;

		/// <summary>
		/// <para>The AuthIP extended mode authentication policy.</para>
		/// <para>See IKEEXT_EM_POLICY0 for more information.</para>
		/// </summary>
		public IntPtr emPolicy;
	}

	/// <summary>
	/// The <c>IPSEC_TRANSPORT_POLICY1</c> structure stores the quick mode negotiation policy for transport mode IPsec.
	/// IPSEC_TRANSPORT_POLICY2 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_transport_policy1 typedef struct
	// IPSEC_TRANSPORT_POLICY1_ { UINT32 numIpsecProposals; IPSEC_PROPOSAL0 *ipsecProposals; UINT32 flags; UINT32 ndAllowClearTimeoutSeconds;
	// IPSEC_SA_IDLE_TIMEOUT0 saIdleTimeout; IKEEXT_EM_POLICY1 *emPolicy; } IPSEC_TRANSPORT_POLICY1;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TRANSPORT_POLICY1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TRANSPORT_POLICY1
	{
		/// <summary>Number of quick mode proposals in the policy.</summary>
		public uint numIpsecProposals;

		/// <summary>
		/// <para>Array of quick mode proposals.</para>
		/// <para>See IPSEC_PROPOSAL0 for more information.</para>
		/// </summary>
		public IntPtr ipsecProposals;

		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IPsec policy flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ND_SECURE</c></term>
		/// <term>Do negotiation discovery in secure ring.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ND_BOUNDARY</c></term>
		/// <term>Do negotiation discovery in the untrusted perimeter zone.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_NAT_ENCAP_ALLOW_PEER_BEHIND_NAT</c></term>
		/// <term>
		/// If set, IPsec expects that either the local or remote machine is behind a network address translation (NAT) device, but not both.
		/// This allows for less secure, but more flexible behavior.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_NAT_ENCAP_ALLOW_GENERAL_NAT_TRAVERSAL</c></term>
		/// <term>If set, IPsec expects default ports when either the local, the remote, or both machines are behind a NAT device.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_DONT_NEGOTIATE_SECOND_LIFETIME</c></term>
		/// <term>If set, Internet Key Exchange (IKE) will not send the ISAKMP attribute for 'seconds' lifetime during quick mode negotiation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_DONT_NEGOTIATE_BYTE_LIFETIME</c></term>
		/// <term>If set, IKE will not send the ISAKMP attribute for 'byte' lifetime during quick mode negotiation.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_POLICY_FLAG flags;

		/// <summary>
		/// Timeout in seconds, after which the IPsec security association (SA) should stop accepting packets coming in the clear. Used for
		/// negotiation discovery.
		/// </summary>
		public uint ndAllowClearTimeoutSeconds;

		/// <summary>An IPSEC_SA_IDLE_TIMEOUT0 structure that specifies the SA idle timeout in IPsec policy.</summary>
		public IPSEC_SA_IDLE_TIMEOUT0 saIdleTimeout;

		/// <summary>
		/// <para>The AuthIP extended mode authentication policy.</para>
		/// <para>See IKEEXT_EM_POLICY1 for more information.</para>
		/// </summary>
		public IntPtr emPolicy;
	}

	/// <summary>
	/// The <c>IPSEC_TRANSPORT_POLICY2</c> structure stores the quick mode negotiation policy for transport mode IPsec.
	/// IPSEC_TRANSPORT_POLICY0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_transport_policy2 typedef struct
	// IPSEC_TRANSPORT_POLICY2_ { UINT32 numIpsecProposals; IPSEC_PROPOSAL0 *ipsecProposals; UINT32 flags; UINT32 ndAllowClearTimeoutSeconds;
	// IPSEC_SA_IDLE_TIMEOUT0 saIdleTimeout; IKEEXT_EM_POLICY2 *emPolicy; } IPSEC_TRANSPORT_POLICY2;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TRANSPORT_POLICY2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TRANSPORT_POLICY2
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of quick mode proposals in the policy.</para>
		/// </summary>
		public uint numIpsecProposals;

		/// <summary>
		/// <para>Type: IPSEC_PROPOSAL0*</para>
		/// <para>Array of quick mode proposals.</para>
		/// </summary>
		public IntPtr ipsecProposals;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IPsec policy flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ND_SECURE</c></term>
		/// <term>Do negotiation discovery in secure ring.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ND_BOUNDARY</c></term>
		/// <term>Do negotiation discovery in the untrusted perimeter zone.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_NAT_ENCAP_ALLOW_PEER_BEHIND_NAT</c></term>
		/// <term>
		/// If set, IPsec expects that either the local or remote machine is behind a network address translation (NAT) device, but not both.
		/// This allows for less secure, but more flexible behavior.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_NAT_ENCAP_ALLOW_GENERAL_NAT_TRAVERSAL</c></term>
		/// <term>If set, IPsec expects default ports when either the local, the remote, or both machines are behind a NAT device.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_DONT_NEGOTIATE_SECOND_LIFETIME</c></term>
		/// <term>If set, Internet Key Exchange (IKE) will not send the ISAKMP attribute for 'seconds' lifetime during quick mode negotiation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_DONT_NEGOTIATE_BYTE_LIFETIME</c></term>
		/// <term>If set, IKE will not send the ISAKMP attribute for 'byte' lifetime during quick mode negotiation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_KEY_MANAGER_ALLOW_DICTATE_KEY</c></term>
		/// <term>Allow key dictation for quick mode policy. Applicable only for AuthIP policy.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_KEY_MANAGER_ALLOW_NOTIFY_KEY</c></term>
		/// <term>Allow key notification for quick mode policy. Applicable for AuthIP/IKE/IKEv2 policy.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_POLICY_FLAG flags;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// Timeout in seconds, after which the IPsec security association (SA) should stop accepting packets coming in the clear. Used for
		/// negotiation discovery.
		/// </para>
		/// </summary>
		public uint ndAllowClearTimeoutSeconds;

		/// <summary>
		/// <para>Type: IPSEC_SA_IDLE_TIMEOUT0</para>
		/// <para>The SA idle timeout in IPsec policy.</para>
		/// </summary>
		public IPSEC_SA_IDLE_TIMEOUT0 saIdleTimeout;

		/// <summary>
		/// <para>Type: IKEEXT_EM_POLICY2*</para>
		/// <para>The AuthIP extended mode authentication policy.</para>
		/// </summary>
		public IntPtr emPolicy;
	}

	/// <summary>The IPSEC_TUNNEL_ENDPOINT0 structure is used to store address information for an end point of a tunnel mode SA.</summary>
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TUNNEL_ENDPOINT0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TUNNEL_ENDPOINT0
	{
		/// <summary>Specifies the IP version. In tunnel mode, this is the version of the outer header.</summary>
		public FWP_IP_VERSION ipVersion;

		private FWP_BYTE_ARRAY_ADDR _addr;

		/// <summary/>
		public IN_ADDR v4Address { get => _addr.addr; set => _addr.addr = value; }

		/// <summary/>
		public IN6_ADDR v6Address { get => _addr.addr6; set => _addr.addr6 = value; }
	}

	/// <summary>
	/// The <c>IPSEC_TUNNEL_ENDPOINTS0</c> structure is used to store end points of a tunnel mode SA. IPSEC_TUNNEL_ENDPOINTS2 is available.
	/// </summary>
	/// <remarks>For the unnamed union containing the local tunnel end point address, switch_type(FWP_IP_VERSION), switch_is(ipVersion).</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_tunnel_endpoints0 typedef struct
	// IPSEC_TUNNEL_ENDPOINTS0_ { FWP_IP_VERSION ipVersion; union { UINT32 localV4Address; UINT8 localV6Address[16]; }; union { UINT32
	// remoteV4Address; UINT8 remoteV6Address[16]; }; } IPSEC_TUNNEL_ENDPOINTS0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TUNNEL_ENDPOINTS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TUNNEL_ENDPOINTS0
	{
		/// <summary>
		/// <para>IP version of the addresses.</para>
		/// <para>See FWP_IP_VERSION for more information.</para>
		/// </summary>
		public FWP_IP_VERSION ipVersion;

		private FWP_BYTE_ARRAY_ADDR local;
		private FWP_BYTE_ARRAY_ADDR remote;

		/// <summary>case(FWP_IP_VERSION_V4)</summary>
		public IN_ADDR localV4Address { get => local.addr; set => local.addr = value; }

		/// <summary>
		/// <para>case(FWP_IP_VERSION_V6)</para>
		/// <para>switch_type(FWP_IP_VERSION), switch_is(ipVersion)</para>
		/// <para>Tagged union containing the remote tunnel end point address.</para>
		/// </summary>
		public IN6_ADDR localV6Address { get => local.addr6; set => local.addr6 = value; }

		/// <summary>case(FWP_IP_VERSION_V4)</summary>
		public IN_ADDR remoteV4Address { get => remote.addr; set => remote.addr = value; }

		/// <summary>case(FWP_IP_VERSION_V6)</summary>
		public IN6_ADDR remoteV6Address { get => remote.addr6; set => remote.addr6 = value; }
	}

	/// <summary>
	/// The <c>IPSEC_TUNNEL_ENDPOINTS1</c> structure is used to store end points of a tunnel mode SA. IPSEC_TUNNEL_ENDPOINTS2 is available.
	/// </summary>
	/// <remarks>For the unnamed union containing the local tunnel end point address, switch_type(FWP_IP_VERSION), switch_is(ipVersion).</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_tunnel_endpoints1 typedef struct
	// IPSEC_TUNNEL_ENDPOINTS1_ { FWP_IP_VERSION ipVersion; union { UINT32 localV4Address; UINT8 localV6Address[16]; }; union { UINT32
	// remoteV4Address; UINT8 remoteV6Address[16]; }; UINT64 localIfLuid; } IPSEC_TUNNEL_ENDPOINTS1;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TUNNEL_ENDPOINTS1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TUNNEL_ENDPOINTS1
	{
		/// <summary>An FWP_IP_VERSION value that specifies the IP version. In tunnel mode, this is the version of the outer header.</summary>
		public FWP_IP_VERSION ipVersion;

		private FWP_BYTE_ARRAY_ADDR local;
		private FWP_BYTE_ARRAY_ADDR remote;

		/// <summary>Optional LUID of the local interface corresponding to the local address specified above.</summary>
		public ulong localIfLuid;

		/// <summary>case(FWP_IP_VERSION_V4)</summary>
		public IN_ADDR localV4Address { get => local.addr; set => local.addr = value; }

		/// <summary>
		/// <para>case(FWP_IP_VERSION_V6)</para>
		/// <para>switch_type(FWP_IP_VERSION), switch_is(ipVersion)</para>
		/// <para>Tagged union containing the remote tunnel end point address.</para>
		/// </summary>
		public IN6_ADDR localV6Address { get => local.addr6; set => local.addr6 = value; }

		/// <summary>case(FWP_IP_VERSION_V4)</summary>
		public IN_ADDR remoteV4Address { get => remote.addr; set => remote.addr = value; }

		/// <summary>case(FWP_IP_VERSION_V6)</summary>
		public IN6_ADDR remoteV6Address { get => remote.addr6; set => remote.addr6 = value; }
	}

	/// <summary>
	/// The <c>IPSEC_TUNNEL_ENDPOINTS2</c> structure is used to store end points of a tunnel mode SA. IPSEC_TUNNEL_ENDPOINTS1 is available.
	/// For Windows Vista, IPSEC_TUNNEL_ENDPOINTS0 is available.
	/// </summary>
	/// <remarks>For the unnamed union containing the local tunnel end point address, switch_type(FWP_IP_VERSION), switch_is(ipVersion).</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_tunnel_endpoints2 typedef struct
	// IPSEC_TUNNEL_ENDPOINTS2_ { FWP_IP_VERSION ipVersion; union { UINT32 localV4Address; UINT8 localV6Address[16]; }; union { UINT32
	// remoteV4Address; UINT8 remoteV6Address[16]; }; UINT64 localIfLuid; wchar_t *remoteFqdn; UINT32 numAddresses; IPSEC_TUNNEL_ENDPOINT0
	// *remoteAddresses; } IPSEC_TUNNEL_ENDPOINTS2;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TUNNEL_ENDPOINTS2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TUNNEL_ENDPOINTS2
	{
		/// <summary>An FWP_IP_VERSION value that specifies the IP version. In tunnel mode, this is the version of the outer header.</summary>
		public FWP_IP_VERSION ipVersion;

		private FWP_BYTE_ARRAY_ADDR local;
		private FWP_BYTE_ARRAY_ADDR remote;

		/// <summary>Optional LUID of the local interface corresponding to the local address specified above.</summary>
		public ulong localIfLuid;

		/// <summary>Configuration of multiple remote addresses and fully qualified domain names for asymmetric tunneling support.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string remoteFqdn;

		/// <summary>The number of remote tunnel addresses.</summary>
		public uint numAddresses;

		/// <summary>The remote tunnel end point address information.</summary>
		public IntPtr remoteAddresses;

		/// <summary>case(FWP_IP_VERSION_V4)</summary>
		public IN_ADDR localV4Address { get => local.addr; set => local.addr = value; }

		/// <summary>
		/// <para>case(FWP_IP_VERSION_V6)</para>
		/// <para>switch_type(FWP_IP_VERSION), switch_is(ipVersion)</para>
		/// <para>Tagged union containing the remote tunnel end point address.</para>
		/// </summary>
		public IN6_ADDR localV6Address { get => local.addr6; set => local.addr6 = value; }

		/// <summary>case(FWP_IP_VERSION_V4)</summary>
		public IN_ADDR remoteV4Address { get => remote.addr; set => remote.addr = value; }

		/// <summary>case(FWP_IP_VERSION_V6)</summary>
		public IN6_ADDR remoteV6Address { get => remote.addr6; set => remote.addr6 = value; }
	}

	/// <summary>
	/// The <c>IPSEC_TUNNEL_POLICY0</c> structure stores the quick mode negotiation policy for tunnel mode IPsec. IPSEC_TUNNEL_POLICY2 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_tunnel_policy0 typedef struct IPSEC_TUNNEL_POLICY0_
	// { UINT32 flags; UINT32 numIpsecProposals; IPSEC_PROPOSAL0 *ipsecProposals; IPSEC_TUNNEL_ENDPOINTS0 tunnelEndpoints;
	// IPSEC_SA_IDLE_TIMEOUT0 saIdleTimeout; IKEEXT_EM_POLICY0 *emPolicy; } IPSEC_TUNNEL_POLICY0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TUNNEL_POLICY0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TUNNEL_POLICY0
	{
		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IPsec policy flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ND_SECURE</c></term>
		/// <term>Do negotiation discovery in secure ring.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ND_BOUNDARY</c></term>
		/// <term>Do negotiation discovery in the untrusted perimeter zone.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_CLEAR_DF_ON_TUNNEL</c></term>
		/// <term>Clear the "DontFragment" bit on the outer IP header of an IPsec tunneled packet.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_DONT_NEGOTIATE_SECOND_LIFETIME</c></term>
		/// <term>If set, Internet Key Exchange (IKE) will not send the ISAKMP attribute for 'seconds' lifetime during quick mode negotiation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_DONT_NEGOTIATE_BYTE_LIFETIME</c></term>
		/// <term>If set, IKE will not send the ISAKMP attribute for 'byte' lifetime during quick mode negotiation.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_POLICY_FLAG flags;

		/// <summary>Number of quick mode proposals in the policy.</summary>
		public uint numIpsecProposals;

		/// <summary>
		/// <para>Array of quick mode proposals.</para>
		/// <para>See <see cref="IPSEC_PROPOSAL0"/> for more information.</para>
		/// </summary>
		public IntPtr ipsecProposals;

		/// <summary>
		/// <para>Tunnel endpoints of the IPsec security association (SA) generated from this policy.</para>
		/// <para>See IPSEC_TUNNEL_ENDPOINTS0 for more information.</para>
		/// </summary>
		public IPSEC_TUNNEL_ENDPOINTS0 tunnelEndpoints;

		/// <summary>An IPSEC_SA_IDLE_TIMEOUT0 structure that specifies the SA idle timeout in IPsec policy.</summary>
		public IPSEC_SA_IDLE_TIMEOUT0 saIdleTimeout;

		/// <summary>
		/// <para>The AuthIP extended mode authentication policy.</para>
		/// <para>See IKEEXT_EM_POLICY0 for more information.</para>
		/// </summary>
		public IntPtr emPolicy;
	}

	/// <summary>
	/// The <c>IPSEC_TUNNEL_POLICY1</c> structure stores the quick mode negotiation policy for tunnel mode IPsec. IPSEC_TUNNEL_POLICY2 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_tunnel_policy1 typedef struct IPSEC_TUNNEL_POLICY1_
	// { UINT32 flags; UINT32 numIpsecProposals; IPSEC_PROPOSAL0 *ipsecProposals; IPSEC_TUNNEL_ENDPOINTS1 tunnelEndpoints;
	// IPSEC_SA_IDLE_TIMEOUT0 saIdleTimeout; IKEEXT_EM_POLICY1 *emPolicy; } IPSEC_TUNNEL_POLICY1;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TUNNEL_POLICY1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TUNNEL_POLICY1
	{
		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IPsec policy flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ND_SECURE</c></term>
		/// <term>Do negotiation discovery in secure ring.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ND_BOUNDARY</c></term>
		/// <term>Do negotiation discovery in the untrusted perimeter zone.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_CLEAR_DF_ON_TUNNEL</c></term>
		/// <term>Clear the "DontFragment" bit on the outer IP header of an IPsec tunneled packet.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_DONT_NEGOTIATE_SECOND_LIFETIME</c></term>
		/// <term>If set, Internet Key Exchange (IKE) will not send the ISAKMP attribute for 'seconds' lifetime during quick mode negotiation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_DONT_NEGOTIATE_BYTE_LIFETIME</c></term>
		/// <term>If set, IKE will not send the ISAKMP attribute for 'byte' lifetime during quick mode negotiation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ENABLE_V6_IN_V4_TUNNELING</c></term>
		/// <term>Negotiate IPv6 inside IPv4 IPsec tunneling. Applicable only for tunnel mode policy, and supported only by IKEv2.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ENABLE_SERVER_ADDR_ASSIGNMENT</c></term>
		/// <term>Enable calls to RAS VPN server for address assignment. Applicable only for tunnel mode policy, and supported only by IKEv2.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_TUNNEL_ALLOW_OUTBOUND_CLEAR_CONNECTION</c></term>
		/// <term>
		/// Allow outbound connections to bypass the tunnel policy. Applicable only for tunnel mode policy on a tunnel gateway. Do not set on
		/// a tunnel client.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_TUNNEL_BYPASS_ALREADY_SECURE_CONNECTION</c></term>
		/// <term>Allow ESP or UDP 500/4500 traffic to bypass the tunnel. Applicable only for tunnel mode policy.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_TUNNEL_BYPASS_ICMPV6</c></term>
		/// <term>Allow ICMPv6 traffic to bypass the tunnel. Applicable only for tunnel mode policy.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_POLICY_FLAG flags;

		/// <summary>Number of quick mode proposals in the policy.</summary>
		public uint numIpsecProposals;

		/// <summary>
		/// <para>Array of quick mode proposals.</para>
		/// <para>See IPSEC_PROPOSAL0 for more information.</para>
		/// </summary>
		public IntPtr ipsecProposals;

		/// <summary>
		/// <para>Tunnel endpoints of the IPsec security association (SA) generated from this policy.</para>
		/// <para>See IPSEC_TUNNEL_ENDPOINTS1 for more information.</para>
		/// </summary>
		public IPSEC_TUNNEL_ENDPOINTS1 tunnelEndpoints;

		/// <summary>An IPSEC_SA_IDLE_TIMEOUT0 structure that specifies the SA idle timeout in IPsec policy.</summary>
		public IPSEC_SA_IDLE_TIMEOUT0 saIdleTimeout;

		/// <summary>
		/// <para>The AuthIP extended mode authentication policy.</para>
		/// <para>See IKEEXT_EM_POLICY1 for more information.</para>
		/// </summary>
		public IntPtr emPolicy;
	}

	/// <summary>
	/// The <c>IPSEC_TUNNEL_POLICY2</c> structure stores the quick mode negotiation policy for tunnel mode IPsec. IPSEC_TUNNEL_POLICY1 is
	/// available. For Windows Vista, IPSEC_TUNNEL_POLICY0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_tunnel_policy2 typedef struct IPSEC_TUNNEL_POLICY2_
	// { UINT32 flags; UINT32 numIpsecProposals; IPSEC_PROPOSAL0 *ipsecProposals; IPSEC_TUNNEL_ENDPOINTS2 tunnelEndpoints;
	// IPSEC_SA_IDLE_TIMEOUT0 saIdleTimeout; IKEEXT_EM_POLICY2 *emPolicy; UINT32 fwdPathSaLifetime; } IPSEC_TUNNEL_POLICY2;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_TUNNEL_POLICY2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_TUNNEL_POLICY2
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IPsec policy flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ND_SECURE</c></term>
		/// <term>Do negotiation discovery in secure ring.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ND_BOUNDARY</c></term>
		/// <term>Do negotiation discovery in the untrusted perimeter zone.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_CLEAR_DF_ON_TUNNEL</c></term>
		/// <term>Clear the "DontFragment" bit on the outer IP header of an IPsec tunneled packet.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_DONT_NEGOTIATE_SECOND_LIFETIME</c></term>
		/// <term>If set, Internet Key Exchange (IKE) will not send the ISAKMP attribute for 'seconds' lifetime during quick mode negotiation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_DONT_NEGOTIATE_BYTE_LIFETIME</c></term>
		/// <term>If set, IKE will not send the ISAKMP attribute for 'byte' lifetime during quick mode negotiation.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ENABLE_V6_IN_V4_TUNNELING</c></term>
		/// <term>Negotiate IPv6 inside IPv4 IPsec tunneling. Applicable only for tunnel mode policy, and supported only by IKEv2.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_ENABLE_SERVER_ADDR_ASSIGNMENT</c></term>
		/// <term>Enable calls to RAS VPN server for address assignment. Applicable only for tunnel mode policy, and supported only by IKEv2.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_TUNNEL_ALLOW_OUTBOUND_CLEAR_CONNECTION</c></term>
		/// <term>
		/// Allow outbound connections to bypass the tunnel policy. Applicable only for tunnel mode policy on a tunnel gateway. Do not set on
		/// a tunnel client.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_TUNNEL_BYPASS_ALREADY_SECURE_CONNECTION</c></term>
		/// <term>Allow ESP or UDP 500/4500 traffic to bypass the tunnel. Applicable only for tunnel mode policy.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_TUNNEL_BYPASS_ICMPV6</c></term>
		/// <term>Allow ICMPv6 traffic to bypass the tunnel. Applicable only for tunnel mode policy.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_KEY_MANAGER_ALLOW_DICTATE_KEY</c></term>
		/// <term>Allow key dictation for quick mode policy. Applicable only for AuthIP policy.</term>
		/// </item>
		/// <item>
		/// <term><c>IPSEC_POLICY_FLAG_KEY_MANAGER_ALLOW_NOTIFY_KEY</c></term>
		/// <term>Allow key notification for quick mode policy. Applicable for AuthIP/IKE/IKEv2 policy.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IPSEC_POLICY_FLAG flags;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of quick mode proposals in the policy.</para>
		/// </summary>
		public uint numIpsecProposals;

		/// <summary>
		/// <para>Type: IPSEC_PROPOSAL0*</para>
		/// <para>Array of quick mode proposals.</para>
		/// </summary>
		public IntPtr ipsecProposals;

		/// <summary>
		/// <para>Type: IPSEC_TUNNEL_ENDPOINTS2</para>
		/// <para>Tunnel endpoints of the IPsec security association (SA) generated from this policy.</para>
		/// </summary>
		public IPSEC_TUNNEL_ENDPOINTS2 tunnelEndpoints;

		/// <summary>
		/// <para>Type: IPSEC_SA_IDLE_TIMEOUT0</para>
		/// <para>Specifies the SA idle timeout in IPsec policy.</para>
		/// </summary>
		public IPSEC_SA_IDLE_TIMEOUT0 saIdleTimeout;

		/// <summary>
		/// <para>Type: IKEEXT_EM_POLICY2*</para>
		/// <para>The AuthIP extended mode authentication policy.</para>
		/// </summary>
		public IntPtr emPolicy;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The forward path SA lifetime indicating the length of time for this connection.</para>
		/// </summary>
		public uint fwdPathSaLifetime;
	}

	/// <summary>
	/// The <c>IPSEC_V4_UDP_ENCAPSULATION0</c> structure stores the User Datagram Protocol (UDP) encapsulation ports for Encapsulating
	/// Security Payload (ESP) encapsulation.
	/// </summary>
	/// <remarks>
	/// <para>This is used only when a NAT was detected as part of the IPsec NAT traversal specification.</para>
	/// <para>
	/// <c>IPSEC_V4_UDP_ENCAPSULATION0</c> is a specific implementation of IPSEC_V4_UDP_ENCAPSULATION. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ipsectypes/ns-ipsectypes-ipsec_v4_udp_encapsulation0 typedef struct
	// IPSEC_V4_UDP_ENCAPSULATION0_ { UINT16 localUdpEncapPort; UINT16 remoteUdpEncapPort; } IPSEC_V4_UDP_ENCAPSULATION0;
	[PInvokeData("ipsectypes.h", MSDNShortId = "NS:ipsectypes.IPSEC_V4_UDP_ENCAPSULATION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_V4_UDP_ENCAPSULATION0
	{
		/// <summary>Source UDP encapsulation port.</summary>
		public ushort localUdpEncapPort;

		/// <summary>Destination UDP encapsulation port.</summary>
		public ushort remoteUdpEncapPort;
	}
}