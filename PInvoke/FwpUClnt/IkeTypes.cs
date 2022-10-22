#pragma warning disable IDE1006 // Naming Styles
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Vanara.PInvoke;

public static partial class FwpUClnt
{
	/// <summary>
	/// The <c>IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE</c> enumerated type specifies the type of impersonation to perform when Authenticated
	/// Internet Protocol (AuthIP) is used for authentication.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ne-iketypes-ikeext_authentication_impersonation_type typedef enum
	// IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE_ { IKEEXT_IMPERSONATION_NONE = 0, IKEEXT_IMPERSONATION_SOCKET_PRINCIPAL,
	// IKEEXT_IMPERSONATION_MAX } IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE;
	[PInvokeData("iketypes.h", MSDNShortId = "NE:iketypes.IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE_")]
	public enum IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies no impersonation.</para>
		/// </summary>
		IKEEXT_IMPERSONATION_NONE,

		/// <summary>Specifies socket principal impersonation.</summary>
		IKEEXT_IMPERSONATION_SOCKET_PRINCIPAL,

		/// <summary>Maximum value for testing purposes.</summary>
		IKEEXT_IMPERSONATION_MAX,
	}

	/// <summary>
	/// The <c>IKEEXT_AUTHENTICATION_METHOD_TYPE</c> enumerated type specifies the type of authentication method used by Internet Key
	/// Exchange (IKE), Authenticated Internet Protocol (AuthIP), or IKEv2..
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ne-iketypes-ikeext_authentication_method_type typedef enum
	// IKEEXT_AUTHENTICATION_METHOD_TYPE_ { IKEEXT_PRESHARED_KEY = 0, IKEEXT_CERTIFICATE, IKEEXT_KERBEROS, IKEEXT_ANONYMOUS, IKEEXT_SSL,
	// IKEEXT_NTLM_V2, IKEEXT_IPV6_CGA, IKEEXT_CERTIFICATE_ECDSA_P256, IKEEXT_CERTIFICATE_ECDSA_P384, IKEEXT_SSL_ECDSA_P256,
	// IKEEXT_SSL_ECDSA_P384, IKEEXT_EAP, IKEEXT_RESERVED, IKEEXT_AUTHENTICATION_METHOD_TYPE_MAX } IKEEXT_AUTHENTICATION_METHOD_TYPE;
	[PInvokeData("iketypes.h", MSDNShortId = "NE:iketypes.IKEEXT_AUTHENTICATION_METHOD_TYPE_")]
	public enum IKEEXT_AUTHENTICATION_METHOD_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies pre-shared key authentication method. Available only for IKE.</para>
		/// </summary>
		IKEEXT_PRESHARED_KEY,

		/// <summary>Specifies certificate authentication method. Available only for IKE and IKEv2.</summary>
		IKEEXT_CERTIFICATE,

		/// <summary>Specifies Kerberos authentication method.</summary>
		IKEEXT_KERBEROS,

		/// <summary>Specifies anonymous authentication method. Available only for AuthIP.</summary>
		IKEEXT_ANONYMOUS,

		/// <summary>Specifies Secure Sockets Layer (SSL) authentication method. Available only for AuthIP.</summary>
		IKEEXT_SSL,

		/// <summary>Specifies Microsoft Windows NT LAN Manager (NTLM) V2 authentication method. Available only for AuthIP.</summary>
		IKEEXT_NTLM_V2,

		/// <summary>Specifies IPv6 Cryptographically Generated Addresses (CGA) authentication method. Available only for IKE.</summary>
		IKEEXT_IPV6_CGA,

		/// <summary>
		/// <para>
		/// Specifies Elliptic Curve Digital Signature Algorithm (ECDSA) 256 certificate authentication method. Available only for IKE and IKEv2.
		/// </para>
		/// <para><c>Note</c> Available only on Windows Server 2008, Windows Vista with SP1, and later.</para>
		/// </summary>
		IKEEXT_CERTIFICATE_ECDSA_P256,

		/// <summary>
		/// <para>Specifies ECDSA-384 certificate authentication method. Available only for IKE and IKEv2.</para>
		/// <para><c>Note</c> Available only on Windows Server 2008, Windows Vista with SP1, and later.</para>
		/// </summary>
		IKEEXT_CERTIFICATE_ECDSA_P384,

		/// <summary>
		/// <para>Specifies ECDSA-256 SSL authentication method. Available only for AuthIP.</para>
		/// <para><c>Note</c> Available only on Windows Server 2008, Windows Vista with SP1, and later.</para>
		/// </summary>
		IKEEXT_SSL_ECDSA_P256,

		/// <summary>
		/// <para>Specifies ECDSA-384 SSL authentication method. Available only for AuthIP.</para>
		/// <para><c>Note</c> Available only on Windows Server 2008, Windows Vista with SP1, and later.</para>
		/// </summary>
		IKEEXT_SSL_ECDSA_P384,

		/// <summary>
		/// <para>Specifies Extensible Authentication Protocol (EAP) authentication method. Available only for IKEv2.</para>
		/// <para><c>Note</c> Available only on Windows Server 2008 R2, Windows 7, and later.</para>
		/// </summary>
		IKEEXT_EAP,

		/// <summary>
		/// <para>Reserved. Do not use.</para>
		/// <para><c>Note</c> Available only on Windows Server 2012, Windows 8, and later.</para>
		/// </summary>
		IKEEXT_RESERVED,

		/// <summary>Maximum value for testing purposes.</summary>
		IKEEXT_AUTHENTICATION_METHOD_TYPE_MAX,
	}

	/// <summary>specifies the certificate authentication characteristics.</summary>
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CERTIFICATE_AUTHENTICATION0_")]
	[Flags]
	public enum IKEEXT_CERT_AUTH : uint
	{
		/// <summary>Enable SSL one way authentication. Applicable only to AuthIP.</summary>
		IKEEXT_CERT_AUTH_FLAG_SSL_ONE_WAY = 0x00000001,

		/// <summary>
		/// Disable CRL checking. By default weak CRL checking is enabled. Weak checking means that a certificate will be rejected if and
		/// only if CRL is successfully looked up and the certificate is found to be revoked.
		/// </summary>
		IKEEXT_CERT_AUTH_FLAG_DISABLE_CRL_CHECK = 0x00000002,

		/// <summary>
		/// Enable strong CRL checking. Strong checking means that a certificate will be rejected if certificate is found to be revoked, or
		/// if any other error (for example, CRL could not be retrieved) takes place while performing the revocation checking.
		/// </summary>
		IKEEXT_CERT_AUTH_ENABLE_CRL_CHECK_STRONG = 0x00000004,

		/// <summary>
		/// SSL validation requires certain EKUs, like server auth EKU from a server. This flag disables the server authentication EKU check,
		/// but still performs the other IKE-style certificate verification. Applicable only to AuthIP.
		/// </summary>
		IKEEXT_CERT_AUTH_DISABLE_SSL_CERT_VALIDATION = 0x00000008,

		/// <summary>
		/// Allow lookup of peer certificate information from an HTTP URL. Applicable only to IKEv2. Available only on Windows 7, Windows
		/// Server 2008 R2, and later.
		/// </summary>
		IKEEXT_CERT_AUTH_ALLOW_HTTP_CERT_LOOKUP = 0x00000010,

		/// <summary>
		/// Indicates that the URL specified in the certificate authentication policy points to an encoded certificate bundle. If this flag
		/// is not specified, IKEv2 will assume that the URL points to an encoded certificate. Applicable only to IKEv2. Available only on
		/// Windows 7, Windows Server 2008 R2, and later.
		/// </summary>
		IKEEXT_CERT_AUTH_URL_CONTAINS_BUNDLE = 0x00000020,

		/// <summary/>
		IKEEXT_CERT_AUTH_FLAG_DISABLE_REQUEST_PAYLOAD = 0x00000040,
	}

	/// <summary>The <c>IKEEXT_CERT_CONFIG_TYPE</c> enumerated type indicates a type of certificate configuration.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ne-iketypes-ikeext_cert_config_type typedef enum IKEEXT_CERT_CONFIG_TYPE_
	// { IKEEXT_CERT_CONFIG_EXPLICIT_TRUST_LIST = 0, IKEEXT_CERT_CONFIG_ENTERPRISE_STORE, IKEEXT_CERT_CONFIG_TRUSTED_ROOT_STORE,
	// IKEEXT_CERT_CONFIG_UNSPECIFIED, IKEEXT_CERT_CONFIG_TYPE_MAX } IKEEXT_CERT_CONFIG_TYPE;
	[PInvokeData("iketypes.h", MSDNShortId = "NE:iketypes.IKEEXT_CERT_CONFIG_TYPE_")]
	public enum IKEEXT_CERT_CONFIG_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>An explicit trust list will be used for authentication.</para>
		/// </summary>
		IKEEXT_CERT_CONFIG_EXPLICIT_TRUST_LIST,

		/// <summary>The enterprise store will be used as the trust list for authentication.</summary>
		IKEEXT_CERT_CONFIG_ENTERPRISE_STORE,

		/// <summary>The trusted root CA store will be used as the trust list for authentication.</summary>
		IKEEXT_CERT_CONFIG_TRUSTED_ROOT_STORE,

		/// <summary>
		/// <para>No certificate authentication in the direction (inbound or outbound) specified by the configuration.</para>
		/// <para>Available only on Windows 7, Windows Server 2008 R2, and later.</para>
		/// </summary>
		IKEEXT_CERT_CONFIG_UNSPECIFIED,

		/// <summary>Maximum value for testing purposes.</summary>
		IKEEXT_CERT_CONFIG_TYPE_MAX,
	}

	/// <summary>Flags for <c>IKEEXT_CERTIFICATE_CREDENTIAL1</c></summary>
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CERTIFICATE_CREDENTIAL1_")]
	[Flags]
	public enum IKEEXT_CERT_CREDENTIAL_FLAG : uint
	{
		/// <summary/>
		IKEEXT_CERT_CREDENTIAL_FLAG_NAP_CERT = 0x00000001
	}

	/// <summary>
	/// The <c>IKEEXT_CERT_CRITERIA_NAME_TYPE</c> enumerated type specifies the type of NAME fields possible for a certificate selection
	/// "subject" criteria.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ne-iketypes-ikeext_cert_criteria_name_type typedef enum
	// IKEEXT_CERT_CRITERIA_NAME_TYPE_ { IKEEXT_CERT_CRITERIA_DNS = 0, IKEEXT_CERT_CRITERIA_UPN, IKEEXT_CERT_CRITERIA_RFC822,
	// IKEEXT_CERT_CRITERIA_CN, IKEEXT_CERT_CRITERIA_OU, IKEEXT_CERT_CRITERIA_O, IKEEXT_CERT_CRITERIA_DC, IKEEXT_CERT_CRITERIA_NAME_TYPE_MAX
	// } IKEEXT_CERT_CRITERIA_NAME_TYPE;
	[PInvokeData("iketypes.h", MSDNShortId = "NE:iketypes.IKEEXT_CERT_CRITERIA_NAME_TYPE_")]
	public enum IKEEXT_CERT_CRITERIA_NAME_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>DNS name in the Subject Alternative Name of the certificate.</para>
		/// </summary>
		IKEEXT_CERT_CRITERIA_DNS,

		/// <summary>UPN name in the Subject Alternative Name of the certificate.</summary>
		IKEEXT_CERT_CRITERIA_UPN,

		/// <summary>RFC 822 name in the Subject Alternative Name of the certificate.</summary>
		IKEEXT_CERT_CRITERIA_RFC822,

		/// <summary>CN in the Subject of the certificate.</summary>
		IKEEXT_CERT_CRITERIA_CN,

		/// <summary>OU in the Subject of the certificate.</summary>
		IKEEXT_CERT_CRITERIA_OU,

		/// <summary>O in the Subject of the certificate.</summary>
		IKEEXT_CERT_CRITERIA_O,

		/// <summary>DC in the Subject of the certificate.</summary>
		IKEEXT_CERT_CRITERIA_DC,

		/// <summary>Maximum value for testing purposes.</summary>
		IKEEXT_CERT_CRITERIA_NAME_TYPE_MAX,
	}

	/// <summary>Flags for IKEEXT_CERT_ROOT_CONFIG0.</summary>
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CERT_ROOT_CONFIG0_")]
	[Flags]
	public enum IKEEXT_CERT_FLAG : uint
	{
		/// <summary>Enable certificate-to-account mapping for the end-host certificate that chains to this root.</summary>
		IKEEXT_CERT_FLAG_ENABLE_ACCOUNT_MAPPING = 0x00000001,

		/// <summary>Do not send a Cert request payload for this root.</summary>
		IKEEXT_CERT_FLAG_DISABLE_REQUEST_PAYLOAD = 0x00000002,

		/// <summary>Enable Network Access Protection (NAP) certificate handling.</summary>
		IKEEXT_CERT_FLAG_USE_NAP_CERTIFICATE = 0x00000004,

		/// <summary>
		/// The corresponding Certification Authority (CA) can be an intermediate CA and does not have to be a ROOT CA. If this flag is not
		/// specified, the name will have to refer to a ROOT CA.
		/// </summary>
		IKEEXT_CERT_FLAG_INTERMEDIATE_CA = 0x00000008,

		/// <summary>
		/// Ignore mapping failures on the initiator. Available only for IKE and IKEv2. Can be set only if
		/// <c>IKEEXT_CERT_FLAG_ENABLE_ACCOUNT_MAPPING</c> is also specified. By default, IKE and IKEv2 will not ignore certificate to
		/// account mapping failures, even on the initiator. Available only on Windows 7, Windows Server 2008 R2, and later.
		/// </summary>
		IKEEXT_CERT_FLAG_IGNORE_INIT_CERT_MAP_FAILURE = 0x00000010,

		/// <summary>NAP certificates will be preferred for local certificate selection.</summary>
		IKEEXT_CERT_FLAG_PREFER_NAP_CERTIFICATE_OUTBOUND = 0x00000020,

		/// <summary>Select a NAP certificate for outbound. Available only on Windows 8 and Windows Server 2012.</summary>
		IKEEXT_CERT_FLAG_SELECT_NAP_CERTIFICATE = 0x00000040,

		/// <summary>Verify that the inbound certificate is NAP. Available only on Windows 8 and Windows Server 2012.</summary>
		IKEEXT_CERT_FLAG_VERIFY_NAP_CERTIFICATE = 0x00000080,

		/// <summary>
		/// Follow the renewal property on the certificate when selecting local certificate for outbound. Only applicable when the hash of
		/// the certificate is specified. Available only on Windows 8 and Windows Server 2012.
		/// </summary>
		IKEEXT_CERT_FLAG_FOLLOW_RENEWAL_CERTIFICATE = 0x00000100,
	}

	/// <summary>
	/// The <c>IKEEXT_CIPHER_TYPE</c> enumerated type specifies the type of encryption algorithm used for encrypting the Internet Key
	/// Exchange (IKE) and Authenticated Internet Protocol (AuthIP) messages.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ne-iketypes-ikeext_cipher_type typedef enum IKEEXT_CIPHER_TYPE_ {
	// IKEEXT_CIPHER_DES = 0, IKEEXT_CIPHER_3DES, IKEEXT_CIPHER_AES_128, IKEEXT_CIPHER_AES_192, IKEEXT_CIPHER_AES_256,
	// IKEEXT_CIPHER_AES_GCM_128_16ICV, IKEEXT_CIPHER_AES_GCM_256_16ICV, IKEEXT_CIPHER_TYPE_MAX } IKEEXT_CIPHER_TYPE;
	[PInvokeData("iketypes.h", MSDNShortId = "NE:iketypes.IKEEXT_CIPHER_TYPE_")]
	public enum IKEEXT_CIPHER_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies DES encryption.</para>
		/// </summary>
		IKEEXT_CIPHER_DES,

		/// <summary>Specifies 3DES encryption.</summary>
		IKEEXT_CIPHER_3DES,

		/// <summary>Specifies AES-128 encryption.</summary>
		IKEEXT_CIPHER_AES_128,

		/// <summary>Specifies AES-192 encryption.</summary>
		IKEEXT_CIPHER_AES_192,

		/// <summary>Specifies AES-256 encryption.</summary>
		IKEEXT_CIPHER_AES_256,

		/// <summary/>
		IKEEXT_CIPHER_AES_GCM_128_16ICV,

		/// <summary/>
		IKEEXT_CIPHER_AES_GCM_256_16ICV,

		/// <summary>Maximum value for testing purposes.</summary>
		IKEEXT_CIPHER_TYPE_MAX,
	}

	/// <summary>
	/// The <c>IKEEXT_DH_GROUP</c> enumerated type specifies the type of Diffie Hellman group used for Internet Key Exchange (IKE) and
	/// Authenticated Internet Protocol (AuthIP) key generation.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ne-iketypes-ikeext_dh_group typedef enum IKEEXT_DH_GROUP_ {
	// IKEEXT_DH_GROUP_NONE = 0, IKEEXT_DH_GROUP_1, IKEEXT_DH_GROUP_2, IKEEXT_DH_GROUP_14, IKEEXT_DH_GROUP_2048, IKEEXT_DH_ECP_256,
	// IKEEXT_DH_ECP_384, IKEEXT_DH_GROUP_24, IKEEXT_DH_GROUP_MAX } IKEEXT_DH_GROUP;
	[PInvokeData("iketypes.h", MSDNShortId = "NE:iketypes.IKEEXT_DH_GROUP_")]
	public enum IKEEXT_DH_GROUP
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies no Diffie Hellman group. Available only for AuthIP.</para>
		/// </summary>
		IKEEXT_DH_GROUP_NONE,

		/// <summary>Specifies Diffie Hellman group 1.</summary>
		IKEEXT_DH_GROUP_1,

		/// <summary>Specifies Diffie Hellman group 2.</summary>
		IKEEXT_DH_GROUP_2,

		/// <summary>
		/// <para>Specifies Diffie Hellman group 14.</para>
		/// <para><c>Note</c> Available only for Windows 8 and Windows Server 2012.</para>
		/// </summary>
		IKEEXT_DH_GROUP_14,

		/// <summary>
		/// <para>Specifies Diffie Hellman group 14.</para>
		/// <para>
		/// <c>Note</c> This group was called Diffie Hellman group 2048 when it was introduced. The name has since been changed to match
		/// standard terminology.
		/// </para>
		/// </summary>
		IKEEXT_DH_GROUP_2048,

		/// <summary>Specifies Diffie Hellman ECP group 256.</summary>
		IKEEXT_DH_ECP_256,

		/// <summary>Specifies Diffie Hellman ECP group 384.</summary>
		IKEEXT_DH_ECP_384,

		/// <summary>
		/// <para>Specifies Diffie Hellman group 24.</para>
		/// <para><c>Note</c> Available only for Windows 8 and Windows Server 2012.</para>
		/// </summary>
		IKEEXT_DH_GROUP_24,

		/// <summary>Maximum value for testing purposes.</summary>
		IKEEXT_DH_GROUP_MAX,
	}

	/// <summary>Flags for IKEEXT_EAP_AUTHENTICATION0.</summary>
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_EAP_AUTHENTICATION0__")]
	[Flags]
	public enum IKEEXT_EAP_FLAG : uint
	{
		/// <summary>Specifies that EAP authentication will be used only to authenticate a local computer to a remote computer.</summary>
		IKEEXT_EAP_FLAG_LOCAL_AUTH_ONLY = 0x00000001,

		/// <summary>Specifies that EAP authentication will be used only to authenticate a remote computer to a local computer.</summary>
		IKEEXT_EAP_FLAG_REMOTE_AUTH_ONLY = 0x00000002,
	}

	/// <summary>
	/// The <c>IKEEXT_EM_SA_STATE</c> enumerated type defines the states for the Extended Mode (EM) negotiation exchanges that are part of
	/// the Authenticated Internet Protocol (AuthIP) protocol.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ne-iketypes-ikeext_em_sa_state typedef enum IKEEXT_EM_SA_STATE_ {
	// IKEEXT_EM_SA_STATE_NONE = 0, IKEEXT_EM_SA_STATE_SENT_ATTS, IKEEXT_EM_SA_STATE_SSPI_SENT, IKEEXT_EM_SA_STATE_AUTH_COMPLETE,
	// IKEEXT_EM_SA_STATE_FINAL, IKEEXT_EM_SA_STATE_COMPLETE, IKEEXT_EM_SA_STATE_MAX } IKEEXT_EM_SA_STATE;
	[PInvokeData("iketypes.h", MSDNShortId = "NE:iketypes.IKEEXT_EM_SA_STATE_")]
	public enum IKEEXT_EM_SA_STATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Initial state. No Extended Mode packets have been sent to the peer.</para>
		/// </summary>
		IKEEXT_EM_SA_STATE_NONE,

		/// <summary>First packet has been sent to the peer.</summary>
		IKEEXT_EM_SA_STATE_SENT_ATTS,

		/// <summary>Second packet has been sent to the peer.</summary>
		IKEEXT_EM_SA_STATE_SSPI_SENT,

		/// <summary>Third packet has been sent to the peer.</summary>
		IKEEXT_EM_SA_STATE_AUTH_COMPLETE,

		/// <summary>Final packet has been sent to the peer.</summary>
		IKEEXT_EM_SA_STATE_FINAL,

		/// <summary>Extended mode has been completed.</summary>
		IKEEXT_EM_SA_STATE_COMPLETE,

		/// <summary>Maximum value for testing purposes.</summary>
		IKEEXT_EM_SA_STATE_MAX,
	}

	/// <summary>
	/// The <c>IKEEXT_INTEGRITY_TYPE</c> enumerated type specifies the type of hash algorithm used for integrity protection of Internet Key
	/// Exchange (IKE) and Authenticated Internet Protocol (AuthIP) messages.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ne-iketypes-ikeext_integrity_type typedef enum IKEEXT_INTEGRITY_TYPE_ {
	// IKEEXT_INTEGRITY_MD5 = 0, IKEEXT_INTEGRITY_SHA1, IKEEXT_INTEGRITY_SHA_256, IKEEXT_INTEGRITY_SHA_384, IKEEXT_INTEGRITY_TYPE_MAX } IKEEXT_INTEGRITY_TYPE;
	[PInvokeData("iketypes.h", MSDNShortId = "NE:iketypes.IKEEXT_INTEGRITY_TYPE_")]
	public enum IKEEXT_INTEGRITY_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies MD5 hash algorithm.</para>
		/// </summary>
		IKEEXT_INTEGRITY_MD5,

		/// <summary>Specifies SHA1 hash algorithm.</summary>
		IKEEXT_INTEGRITY_SHA1,

		/// <summary>
		/// <para>Specifies a 256-bit SHA encryption.</para>
		/// <para><c>Note</c> Available only on Windows Server 2008, Windows Vista with SP1, and later.</para>
		/// </summary>
		IKEEXT_INTEGRITY_SHA_256,

		/// <summary>
		/// <para>Specifies a 384-bit SHA encryption.</para>
		/// <para><c>Note</c> Available only on Windows Server 2008, Windows Vista with SP1, and later.</para>
		/// </summary>
		IKEEXT_INTEGRITY_SHA_384,

		/// <summary>Maximum value for testing purposes.</summary>
		IKEEXT_INTEGRITY_TYPE_MAX,
	}

	/// <summary>Flags in IKEEXT_KERBEROS_AUTHENTICATION0.</summary>
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_KERBEROS_AUTHENTICATION0__")]
	[Flags]
	public enum IKEEXT_KERB_AUTH : uint
	{
		/// <summary>Disable initiator generation of peer token from the peer's name string.</summary>
		IKEEXT_KERB_AUTH_DISABLE_INITIATOR_TOKEN_GENERATION = 0x00000001,

		/// <summary>Refuse connections if the peer is using explicit credentials. Applicable only to AuthIP.</summary>
		IKEEXT_KERB_AUTH_DONT_ACCEPT_EXPLICIT_CREDENTIALS = 0x00000002,

		/// <summary>Force the use of a Kerberos proxy server when acting as initiator.</summary>
		IKEEXT_KERB_AUTH_FORCE_PROXY_ON_INITIATOR = 0x00000004,
	}

	/// <summary>The <c>IKEEXT_KEY_MODULE_TYPE</c> enumerated type specifies the type of keying module.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ne-iketypes-ikeext_key_module_type typedef enum IKEEXT_KEY_MODULE_TYPE_ {
	// IKEEXT_KEY_MODULE_IKE = 0, IKEEXT_KEY_MODULE_AUTHIP, IKEEXT_KEY_MODULE_IKEV2, IKEEXT_KEY_MODULE_MAX } IKEEXT_KEY_MODULE_TYPE;
	[PInvokeData("iketypes.h", MSDNShortId = "NE:iketypes.IKEEXT_KEY_MODULE_TYPE_")]
	public enum IKEEXT_KEY_MODULE_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies Internet Key Exchange (IKE) keying module.</para>
		/// </summary>
		IKEEXT_KEY_MODULE_IKE,

		/// <summary>Specifies Authenticated Internet Protocol (AuthIP) keying module.</summary>
		IKEEXT_KEY_MODULE_AUTHIP,

		/// <summary>
		/// <para>Specifies Internet Key Exchange version 2 (IKEv2) keying module.</para>
		/// <para>Available only on Windows 7, Windows Server 2008 R2, and later.</para>
		/// </summary>
		IKEEXT_KEY_MODULE_IKEV2,

		/// <summary>Maximum value for testing purposes.</summary>
		IKEEXT_KEY_MODULE_MAX,
	}

	/// <summary>
	/// The <c>IKEEXT_MM_SA_STATE</c> enumerated type defines the states for the Main Mode (MM) negotiation exchanges that are part of the
	/// Authenticated Internet Protocol (AuthIP) and Internet Key Exchange (IKE) protocols.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ne-iketypes-ikeext_mm_sa_state typedef enum IKEEXT_MM_SA_STATE_ {
	// IKEEXT_MM_SA_STATE_NONE = 0, IKEEXT_MM_SA_STATE_SA_SENT, IKEEXT_MM_SA_STATE_SSPI_SENT, IKEEXT_MM_SA_STATE_FINAL,
	// IKEEXT_MM_SA_STATE_FINAL_SENT, IKEEXT_MM_SA_STATE_COMPLETE, IKEEXT_MM_SA_STATE_MAX } IKEEXT_MM_SA_STATE;
	[PInvokeData("iketypes.h", MSDNShortId = "NE:iketypes.IKEEXT_MM_SA_STATE_")]
	public enum IKEEXT_MM_SA_STATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Initial state. No packets have been sent to the peer.</para>
		/// </summary>
		IKEEXT_MM_SA_STATE_NONE,

		/// <summary>First packet has been sent to the peer</summary>
		IKEEXT_MM_SA_STATE_SA_SENT,

		/// <summary>Second packet has been sent to the peer, for SSPI authentication.</summary>
		IKEEXT_MM_SA_STATE_SSPI_SENT,

		/// <summary>Third packet has been sent to the peer.</summary>
		IKEEXT_MM_SA_STATE_FINAL,

		/// <summary>Final packet has been sent to the peer.</summary>
		IKEEXT_MM_SA_STATE_FINAL_SENT,

		/// <summary>MM has been completed.</summary>
		IKEEXT_MM_SA_STATE_COMPLETE,

		/// <summary>Maximum value for testing purposes.</summary>
		IKEEXT_MM_SA_STATE_MAX,
	}

	/// <summary>Flags for <see cref="IKEEXT_NTLM_V2_AUTHENTICATION0"/>.</summary>
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_NTLM_V2_AUTHENTICATION0__")]
	[Flags]
	public enum IKEEXT_NTLM_V2_AUTH : uint
	{
		/// <summary>Refuse connections if the peer is using explicit credentials.</summary>
		IKEEXT_NTLM_V2_AUTH_DONT_ACCEPT_EXPLICIT_CREDENTIALS = 0x00000001
	}

	/// <summary>Flags for IKEEXT_POLICY0.</summary>
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_POLICY0_")]
	[Flags]
	public enum IKEEXT_POLICY_FLAG : uint
	{
		/// <summary>
		/// Disable special diagnostics mode for IKE/Authip. This will prevent IKE/AuthIp from accepting unauthenticated notifications from
		/// peer, or sending MS_STATUS notifications to peer.
		/// </summary>
		IKEEXT_POLICY_FLAG_DISABLE_DIAGNOSTICS = 0x00000001,

		/// <summary>Disable SA verification of machine LUID.</summary>
		IKEEXT_POLICY_FLAG_NO_MACHINE_LUID_VERIFY = 0x00000002,

		/// <summary>Disable SA verification of machine impersonation LUID. Applicable only to AuthIP.</summary>
		IKEEXT_POLICY_FLAG_NO_IMPERSONATION_LUID_VERIFY = 0x00000004,

		/// <summary>
		/// Allow the responder to accept any DH proposal, including no DH, regardless of what is configured in policy. Applicable only to AuthIP.
		/// </summary>
		IKEEXT_POLICY_FLAG_ENABLE_OPTIONAL_DH = 0x00000008,

		/// <summary/>
		IKEEXT_POLICY_FLAG_MOBIKE_NOT_SUPPORTED = 0x00000010,

		/// <summary/>
		IKEEXT_POLICY_FLAG_SITE_TO_SITE = 0x00000020,

		/// <summary/>
		IKEEXT_POLICY_FLAG_IMS_VPN = 0x00000040,

		/// <summary/>
		IKEEXT_POLICY_ENABLE_IKEV2_FRAGMENTATION = 0x00000080,

		/// <summary/>
		IKEEXT_POLICY_SUPPORT_LOW_POWER_MODE = 0x00000100,
	}

	/// <summary>Flags for <c>IKEEXT_PRESHARED_KEY_AUTHENTICATION1</c></summary>
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_PRESHARED_KEY_AUTHENTICATION1__")]
	[Flags]
	public enum IKEEXT_PSK_FLAG : uint
	{
		/// <summary>
		/// Specifies that the pre-shared key authentication will be used only to authenticate a local computer to a remote computer.
		/// Applicable only to IKEv2.
		/// </summary>
		IKEEXT_PSK_FLAG_LOCAL_AUTH_ONLY = 0x00000001,

		/// <summary>
		/// Specifies that the pre-shared key authentication will be used only to authenticate a remote computer to a local computer.
		/// Applicable only to IKEv2.
		/// </summary>
		IKEEXT_PSK_FLAG_REMOTE_AUTH_ONLY = 0x00000002,
	}

	/// <summary>
	/// The <c>IKEEXT_QM_SA_STATE</c> enumerated type defines the states for the Quick Mode (QM) negotiation exchanges that are part of the
	/// Authenticated Internet Protocol (AuthIP) and Internet Key Exchange (IKE) protocols.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ne-iketypes-ikeext_qm_sa_state typedef enum IKEEXT_QM_SA_STATE_ {
	// IKEEXT_QM_SA_STATE_NONE = 0, IKEEXT_QM_SA_STATE_INITIAL, IKEEXT_QM_SA_STATE_FINAL, IKEEXT_QM_SA_STATE_COMPLETE, IKEEXT_QM_SA_STATE_MAX
	// } IKEEXT_QM_SA_STATE;
	[PInvokeData("iketypes.h", MSDNShortId = "NE:iketypes.IKEEXT_QM_SA_STATE_")]
	public enum IKEEXT_QM_SA_STATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Initial state. No QM packets have been sent to the peer.</para>
		/// </summary>
		IKEEXT_QM_SA_STATE_NONE,

		/// <summary>First packet has been sent to the peer.</summary>
		IKEEXT_QM_SA_STATE_INITIAL,

		/// <summary>Final packet has been sent to the peer.</summary>
		IKEEXT_QM_SA_STATE_FINAL,

		/// <summary>QM has been completed.</summary>
		IKEEXT_QM_SA_STATE_COMPLETE,

		/// <summary>Maximum value for testing purposes.</summary>
		IKEEXT_QM_SA_STATE_MAX,
	}

	/// <summary>Flags for IKEEXT_RESERVED_AUTHENTICATION0.</summary>
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_RESERVED_AUTHENTICATION0__")]
	[Flags]
	public enum IKEEXT_RESERVED_AUTH : uint
	{
		/// <summary>Reserved for internal use.</summary>
		IKEEXT_RESERVED_AUTH_DISABLE_INITIATOR_TOKEN_GENERATION = 0x00000001
	}

	/// <summary>
	/// The <c>IKEEXT_SA_ROLE</c> enumerated type defines the security association (SA) role for Internet Key Exchange (IKE) and
	/// Authenticated Internet Protocol (AuthIP) Main Mode or Quick Mode negotiations.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ne-iketypes-ikeext_sa_role typedef enum IKEEXT_SA_ROLE_ {
	// IKEEXT_SA_ROLE_INITIATOR = 0, IKEEXT_SA_ROLE_RESPONDER, IKEEXT_SA_ROLE_MAX } IKEEXT_SA_ROLE;
	[PInvokeData("iketypes.h", MSDNShortId = "NE:iketypes.IKEEXT_SA_ROLE_")]
	public enum IKEEXT_SA_ROLE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>SA is the initiator.</para>
		/// </summary>
		IKEEXT_SA_ROLE_INITIATOR,

		/// <summary>SA is the responder.</summary>
		IKEEXT_SA_ROLE_RESPONDER,

		/// <summary>Maximum value for testing purposes.</summary>
		IKEEXT_SA_ROLE_MAX,
	}

	/// <summary>
	/// Tag interface to represent structures that start with a 32-bit size value followed by a pointer to an aray of <typeparamref name="TElem"/>.
	/// </summary>
	/// <typeparam name="TElem">The type of the array element.</typeparam>
	public interface IBlob<TElem>
	{
	}

	/// <summary>Gets an array from an <see cref="IBlob{T}"/>.</summary>
	/// <typeparam name="TElem">The type of the array element.</typeparam>
	/// <param name="str">The structure instance.</param>
	/// <returns>An array of <typeparamref name="TElem"/>.</returns>
	public static TElem[] Get<TElem>(this IBlob<TElem> str)
	{
		using var p = new PinnedObject(str);
		var c = Marshal.ReadInt32(p);
		return ((IntPtr)p).ToArray<TElem>(c, Marshal.OffsetOf(typeof(FWP_BYTE_BLOB), "data").ToInt32());
	}

	/// <summary>Creates an <see cref="IBlob{T}"/> based structure from a sequence.</summary>
	/// <typeparam name="TIn">The type of the structure.</typeparam>
	/// <typeparam name="TElem">The type of the array element.</typeparam>
	/// <param name="items">The items.</param>
	/// <param name="mem">The allocated native memory assigned to the pointer in the returned structure.</param>
	/// <returns></returns>
	public static TIn Make<TIn, TElem>(IEnumerable<TElem> items, out SafeAllocatedMemoryHandle mem) where TIn : unmanaged, IBlob<TElem>
	{
		var c = items?.Count() ?? 0;
		mem = typeof(TElem) == typeof(string) ? SafeCoTaskMemHandle.CreateFromStringList(items.Cast<string>(), StringListPackMethod.Packed, GetCharSet())
			: SafeCoTaskMemHandle.CreateFromList(items, c);
		var blob = new FWP_BYTE_BLOB() { size = (uint)c, data = mem };
		using var tmem = SafeCoTaskMemHandle.CreateFromStructure<TIn>();
		tmem.Write(blob);
		return tmem.ToStructure<TIn>();

		static CharSet GetCharSet() => typeof(TIn).GetCustomAttribute<StructLayoutAttribute>()?.CharSet ?? CharSet.Auto;
	}

	/// <summary>The IKEEXT_AUTHENTICATION_METHOD1 is available.For Windows 8, IKEEXT_AUTHENTICATION_METHOD2 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_authentication_method0 typedef struct
	// IKEEXT_AUTHENTICATION_METHOD0_ { IKEEXT_AUTHENTICATION_METHOD_TYPE authenticationMethodType; union {
	// IKEEXT_PRESHARED_KEY_AUTHENTICATION0 presharedKeyAuthentication; IKEEXT_CERTIFICATE_AUTHENTICATION0 certificateAuthentication;
	// IKEEXT_KERBEROS_AUTHENTICATION0 kerberosAuthentication; IKEEXT_NTLM_V2_AUTHENTICATION0 ntlmV2Authentication;
	// IKEEXT_CERTIFICATE_AUTHENTICATION0 sslAuthentication; IKEEXT_IPV6_CGA_AUTHENTICATION0 cgaAuthentication; }; } IKEEXT_AUTHENTICATION_METHOD0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_AUTHENTICATION_METHOD0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_AUTHENTICATION_METHOD0
	{
		/// <summary>Type of authentication method specified by IKEEXT_AUTHENTICATION_METHOD_TYPE.</summary>
		public IKEEXT_AUTHENTICATION_METHOD_TYPE authenticationMethodType;

		private UNION union;

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_PRESHARED_KEY</c>.</para>
		/// <para>See IKEEXT_PRESHARED_KEY_AUTHENTICATION0 for more information.</para>
		/// </summary>
		public IKEEXT_PRESHARED_KEY_AUTHENTICATION0 presharedKeyAuthentication { get => union.presharedKeyAuthentication; set => union.presharedKeyAuthentication = value; }

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_CERTIFICATE</c>, <c>IKEEXT_CERTIFICATE_ECDSA_P256</c>, or <c>IKEEXT_CERTIFICATE_ECDSA_P384</c>.</para>
		/// <para>See IKEEXT_CERTIFICATE_AUTHENTICATION0 for more information.</para>
		/// </summary>
		public IKEEXT_CERTIFICATE_AUTHENTICATION0 certificateAuthentication { get => union.certificateAuthentication; set => union.certificateAuthentication = value; }

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_KERBEROS</c>.</para>
		/// <para>See IKEEXT_KERBEROS_AUTHENTICATION0 for more information.</para>
		/// </summary>
		public IKEEXT_KERBEROS_AUTHENTICATION0 kerberosAuthentication { get => union.kerberosAuthentication; set => union.kerberosAuthentication = value; }

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_NTLM_V2</c>.</para>
		/// <para>See IKEEXT_NTLM_V2_AUTHENTICATION0 for more information.</para>
		/// </summary>
		public IKEEXT_NTLM_V2_AUTHENTICATION0 ntlmV2Authentication { get => union.ntlmV2Authentication; set => union.ntlmV2Authentication = value; }

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_SSL</c>, <c>IKEEXT_SSL_ECDSA_P256</c>, or <c>IKEEXT_SSL_ECDSA_P384</c>.</para>
		/// <para>See IKEEXT_CERTIFICATE_AUTHENTICATION0 for more information.</para>
		/// </summary>
		public IKEEXT_CERTIFICATE_AUTHENTICATION0 sslAuthentication { get => union.sslAuthentication; set => union.sslAuthentication = value; }

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_IPV6_CGA</c>. Available only for IKE.</para>
		/// <para>See IKEEXT_IPV6_CGA_AUTHENTICATION0 for more information.</para>
		/// </summary>
		public IKEEXT_IPV6_CGA_AUTHENTICATION0 cgaAuthentication { get => union.cgaAuthentication; set => union.cgaAuthentication = value; }

		[StructLayout(LayoutKind.Explicit)]
		private struct UNION
		{
			[FieldOffset(0)]
			public IKEEXT_PRESHARED_KEY_AUTHENTICATION0 presharedKeyAuthentication;

			[FieldOffset(0)]
			public IKEEXT_CERTIFICATE_AUTHENTICATION0 certificateAuthentication;

			[FieldOffset(0)]
			public IKEEXT_KERBEROS_AUTHENTICATION0 kerberosAuthentication;

			[FieldOffset(0)]
			public IKEEXT_NTLM_V2_AUTHENTICATION0 ntlmV2Authentication;

			[FieldOffset(0)]
			public IKEEXT_CERTIFICATE_AUTHENTICATION0 sslAuthentication;

			[FieldOffset(0)]
			public IKEEXT_IPV6_CGA_AUTHENTICATION0 cgaAuthentication;
		}
	}

	/// <summary>The IKEEXT_AUTHENTICATION_METHOD0 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_authentication_method1 typedef struct
	// IKEEXT_AUTHENTICATION_METHOD1_ { IKEEXT_AUTHENTICATION_METHOD_TYPE authenticationMethodType; union {
	// IKEEXT_PRESHARED_KEY_AUTHENTICATION1 presharedKeyAuthentication; IKEEXT_CERTIFICATE_AUTHENTICATION1 certificateAuthentication;
	// IKEEXT_KERBEROS_AUTHENTICATION0 kerberosAuthentication; IKEEXT_NTLM_V2_AUTHENTICATION0 ntlmV2Authentication;
	// IKEEXT_CERTIFICATE_AUTHENTICATION1 sslAuthentication; IKEEXT_IPV6_CGA_AUTHENTICATION0 cgaAuthentication; IKEEXT_EAP_AUTHENTICATION0
	// eapAuthentication; }; } IKEEXT_AUTHENTICATION_METHOD1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_AUTHENTICATION_METHOD1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_AUTHENTICATION_METHOD1
	{
		/// <summary>Type of authentication method specified by IKEEXT_AUTHENTICATION_METHOD_TYPE.</summary>
		public IKEEXT_AUTHENTICATION_METHOD_TYPE authenticationMethodType;

		private UNION union;

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_PRESHARED_KEY</c>.</para>
		/// <para>See IKEEXT_PRESHARED_KEY_AUTHENTICATION1 for more information.</para>
		/// </summary>
		public IKEEXT_PRESHARED_KEY_AUTHENTICATION1 presharedKeyAuthentication { get => union.presharedKeyAuthentication; set => union.presharedKeyAuthentication = value; }

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_CERTIFICATE</c>, <c>IKEEXT_CERTIFICATE_ECDSA_P256</c>, or <c>IKEEXT_CERTIFICATE_ECDSA_P384</c>.</para>
		/// <para>See IKEEXT_CERTIFICATE_AUTHENTICATION1 for more information.</para>
		/// </summary>
		public IKEEXT_CERTIFICATE_AUTHENTICATION1 certificateAuthentication { get => union.certificateAuthentication; set => union.certificateAuthentication = value; }

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_KERBEROS</c>.</para>
		/// <para>See IKEEXT_KERBEROS_AUTHENTICATION0 for more information.</para>
		/// </summary>
		public IKEEXT_KERBEROS_AUTHENTICATION0 kerberosAuthentication { get => union.kerberosAuthentication; set => union.kerberosAuthentication = value; }

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_NTLM_V2</c>.</para>
		/// <para>See IKEEXT_NTLM_V2_AUTHENTICATION0 for more information.</para>
		/// </summary>
		public IKEEXT_NTLM_V2_AUTHENTICATION0 ntlmV2Authentication { get => union.ntlmV2Authentication; set => union.ntlmV2Authentication = value; }

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_SSL</c>, <c>IKEEXT_SSL_ECDSA_P256</c>, or <c>IKEEXT_SSL_ECDSA_P384</c>.</para>
		/// <para>See IKEEXT_CERTIFICATE_AUTHENTICATION1 for more information.</para>
		/// </summary>
		public IKEEXT_CERTIFICATE_AUTHENTICATION1 sslAuthentication { get => union.sslAuthentication; set => union.sslAuthentication = value; }

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_IPV6_CGA</c>.</para>
		/// <para>See IKEEXT_IPV6_CGA_AUTHENTICATION0 for more information.</para>
		/// </summary>
		public IKEEXT_IPV6_CGA_AUTHENTICATION0 cgaAuthentication { get => union.cgaAuthentication; set => union.cgaAuthentication = value; }

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_EAP</c>.</para>
		/// <para>See IKEEXT_EAP_AUTHENTICATION0 for more information.</para>
		/// </summary>
		public IKEEXT_EAP_AUTHENTICATION0 eapAuthentication { get => union.eapAuthentication; set => union.eapAuthentication = value; }

		[StructLayout(LayoutKind.Explicit)]
		private struct UNION
		{
			[FieldOffset(0)]
			public IKEEXT_PRESHARED_KEY_AUTHENTICATION1 presharedKeyAuthentication;

			[FieldOffset(0)]
			public IKEEXT_CERTIFICATE_AUTHENTICATION1 certificateAuthentication;

			[FieldOffset(0)]
			public IKEEXT_KERBEROS_AUTHENTICATION0 kerberosAuthentication;

			[FieldOffset(0)]
			public IKEEXT_NTLM_V2_AUTHENTICATION0 ntlmV2Authentication;

			[FieldOffset(0)]
			public IKEEXT_CERTIFICATE_AUTHENTICATION1 sslAuthentication;

			[FieldOffset(0)]
			public IKEEXT_IPV6_CGA_AUTHENTICATION0 cgaAuthentication;

			[FieldOffset(0)]
			public IKEEXT_EAP_AUTHENTICATION0 eapAuthentication;
		}
	}

	/// <summary>
	/// The <c>IKEEXT_AUTHENTICATION_METHOD2</c> structure specifies various parameters for IKE/Authip authentication.
	/// IKEEXT_AUTHENTICATION_METHOD0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_authentication_method2 typedef struct
	// IKEEXT_AUTHENTICATION_METHOD2_ { IKEEXT_AUTHENTICATION_METHOD_TYPE authenticationMethodType; union {
	// IKEEXT_PRESHARED_KEY_AUTHENTICATION1 presharedKeyAuthentication; IKEEXT_CERTIFICATE_AUTHENTICATION2 certificateAuthentication;
	// IKEEXT_KERBEROS_AUTHENTICATION1 kerberosAuthentication; IKEEXT_RESERVED_AUTHENTICATION0 reservedAuthentication;
	// IKEEXT_NTLM_V2_AUTHENTICATION0 ntlmV2Authentication; IKEEXT_CERTIFICATE_AUTHENTICATION2 sslAuthentication;
	// IKEEXT_IPV6_CGA_AUTHENTICATION0 cgaAuthentication; IKEEXT_EAP_AUTHENTICATION0 eapAuthentication; }; } IKEEXT_AUTHENTICATION_METHOD2;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_AUTHENTICATION_METHOD2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_AUTHENTICATION_METHOD2
	{
		/// <summary>
		/// <para>Type: <c>IKEEXT_AUTHENTICATION_METHOD_TYPE</c></para>
		/// <para>Type of authentication method.</para>
		/// </summary>
		public IKEEXT_AUTHENTICATION_METHOD_TYPE authenticationMethodType;

		private UNION union;

		/// <summary>
		/// <para>Type: <c>IKEEXT_PRESHARED_KEY_AUTHENTICATION1</c></para>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_PRESHARED_KEY</c>.</para>
		/// </summary>
		public IKEEXT_PRESHARED_KEY_AUTHENTICATION1 presharedKeyAuthentication { get => union.presharedKeyAuthentication; set => union.presharedKeyAuthentication = value; }

		/// <summary>
		/// <para>Type: <c>IKEEXT_CERTIFICATE_AUTHENTICATION2</c></para>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_CERTIFICATE</c>, <c>IKEEXT_CERTIFICATE_ECDSA_P256</c>, or <c>IKEEXT_CERTIFICATE_ECDSA_P384</c>.</para>
		/// </summary>
		public IKEEXT_CERTIFICATE_AUTHENTICATION2 certificateAuthentication { get => union.certificateAuthentication; set => union.certificateAuthentication = value; }

		/// <summary>
		/// <para>Type: IKEEXT_KERBEROS_AUTHENTICATION1</para>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_KERBEROS</c>.</para>
		/// </summary>
		public IKEEXT_KERBEROS_AUTHENTICATION1 kerberosAuthentication { get => union.kerberosAuthentication; set => union.kerberosAuthentication = value; }

		/// <summary>
		/// <para>Type: IKEEXT_RESERVED_AUTHENTICATION0</para>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_RESERVED</c>.</para>
		/// </summary>
		public IKEEXT_RESERVED_AUTHENTICATION0 reservedAuthentication { get => union.reservedAuthentication; set => union.reservedAuthentication = value; }

		/// <summary>
		/// <para>Type: IKEEXT_NTLM_V2_AUTHENTICATION0</para>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_NTLM_V2</c>.</para>
		/// </summary>
		public IKEEXT_NTLM_V2_AUTHENTICATION0 ntlmV2Authentication { get => union.ntlmV2Authentication; set => union.ntlmV2Authentication = value; }

		/// <summary>
		/// <para>Type: <c>IKEEXT_CERTIFICATE_AUTHENTICATION2</c></para>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_SSL</c>, <c>IKEEXT_SSL_ECDSA_P256</c>, or <c>IKEEXT_SSL_ECDSA_P384</c>.</para>
		/// </summary>
		public IKEEXT_CERTIFICATE_AUTHENTICATION2 sslAuthentication { get => union.sslAuthentication; set => union.sslAuthentication = value; }

		/// <summary>
		/// <para>Type: IKEEXT_IPV6_CGA_AUTHENTICATION0</para>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_IPV6_CGA</c>.</para>
		/// </summary>
		public IKEEXT_IPV6_CGA_AUTHENTICATION0 cgaAuthentication { get => union.cgaAuthentication; set => union.cgaAuthentication = value; }

		/// <summary>
		/// <para>Type: IKEEXT_EAP_AUTHENTICATION0</para>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_EAP</c>.</para>
		/// </summary>
		public IKEEXT_EAP_AUTHENTICATION0 eapAuthentication { get => union.eapAuthentication; set => union.eapAuthentication = value; }

		[StructLayout(LayoutKind.Explicit)]
		private struct UNION
		{
			[FieldOffset(0)]
			public IKEEXT_PRESHARED_KEY_AUTHENTICATION1 presharedKeyAuthentication;

			[FieldOffset(0)]
			public IKEEXT_CERTIFICATE_AUTHENTICATION2 certificateAuthentication;

			[FieldOffset(0)]
			public IKEEXT_KERBEROS_AUTHENTICATION1 kerberosAuthentication;

			[FieldOffset(0)]
			public IKEEXT_RESERVED_AUTHENTICATION0 reservedAuthentication;

			[FieldOffset(0)]
			public IKEEXT_NTLM_V2_AUTHENTICATION0 ntlmV2Authentication;

			[FieldOffset(0)]
			public IKEEXT_CERTIFICATE_AUTHENTICATION2 sslAuthentication;

			[FieldOffset(0)]
			public IKEEXT_IPV6_CGA_AUTHENTICATION0 cgaAuthentication;

			[FieldOffset(0)]
			public IKEEXT_EAP_AUTHENTICATION0 eapAuthentication;
		}
	}

	/// <summary>The <c>IKEEXT_CERT_EKUS0</c> structure contains information about the extended key usage (EKU) properties of a certificate.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_cert_ekus0 typedef struct IKEEXT_CERT_EKUS0_ { ULONG
	// numEku; LPSTR *eku; } IKEEXT_CERT_EKUS0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CERT_EKUS0_")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct IKEEXT_CERT_EKUS0 : IBlob<string>
	{
		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of EKUs in the <c>eku</c> member.</para>
		/// </summary>
		public uint numEku;

		/// <summary>
		/// <para>Type: <c>LPSTR*</c></para>
		/// <para>The list of EKU object identifiers (OIDs).</para>
		/// </summary>
		public IntPtr eku;
	}

	/// <summary>The <c>IKEEXT_CERT_NAME0</c> structure specifies certificate selection "subject" criteria for an authentication method.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_cert_name0 typedef struct IKEEXT_CERT_NAME0_ {
	// IKEEXT_CERT_CRITERIA_NAME_TYPE nameType; LPWSTR certName; } IKEEXT_CERT_NAME0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CERT_NAME0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CERT_NAME0
	{
		/// <summary>
		/// <para>Type: IKEEXT_CERT_CRITERIA_NAME_TYPE</para>
		/// <para>The type of NAME field.</para>
		/// </summary>
		public IKEEXT_CERT_CRITERIA_NAME_TYPE nameType;

		/// <summary>
		/// <para>Type: <c>LPWSTR</c></para>
		/// <para>The string to be used for matching the "subject" criteria.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string certName;
	}

	/// <summary>The <c>IKEEXT_CERT_ROOT_CONFIG0</c> structure stores the IKE, AuthIP, or IKEv2 certificate root configuration.</summary>
	/// <remarks>
	/// <c>IKEEXT_CERT_ROOT_CONFIG0</c> is a specific implementation of IKEEXT_CERT_ROOT_CONFIG. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_cert_root_config0 typedef struct
	// IKEEXT_CERT_ROOT_CONFIG0_ { FWP_BYTE_BLOB certData; UINT32 flags; } IKEEXT_CERT_ROOT_CONFIG0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CERT_ROOT_CONFIG0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CERT_ROOT_CONFIG0
	{
		/// <summary>
		/// <para>X509/ASN.1 encoded name of the certificate root.</para>
		/// <para>See FWP_BYTE_BLOB for more information.</para>
		/// </summary>
		public FWP_BYTE_BLOB certData;

		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IKE/AuthIP/IKEv2 certificate flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IKEEXT_CERT_FLAG_ENABLE_ACCOUNT_MAPPING</c></term>
		/// <term>Enable certificate-to-account mapping for the end-host certificate that chains to this root.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_FLAG_DISABLE_REQUEST_PAYLOAD</c></term>
		/// <term>Do not send a Cert request payload for this root.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_FLAG_USE_NAP_CERTIFICATE</c></term>
		/// <term>Enable Network Access Protection (NAP) certificate handling.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_FLAG_INTERMEDIATE_CA</c></term>
		/// <term>
		/// The corresponding Certification Authority (CA) can be an intermediate CA and does not have to be a ROOT CA. If this flag is not
		/// specified, the name will have to refer to a ROOT CA.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_FLAG_IGNORE_INIT_CERT_MAP_FAILURE</c></term>
		/// <term>
		/// Ignore mapping failures on the initiator. Available only for IKE and IKEv2. Can be set only if
		/// <c>IKEEXT_CERT_FLAG_ENABLE_ACCOUNT_MAPPING</c> is also specified. By default, IKE and IKEv2 will not ignore certificate to
		/// account mapping failures, even on the initiator. Available only on Windows 7, Windows Server 2008 R2, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_FLAG_PREFER_NAP_CERTIFICATE_OUTBOUND</c></term>
		/// <term>NAP certificates will be preferred for local certificate selection.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_FLAG_SELECT_NAP_CERTIFICATE</c></term>
		/// <term>Select a NAP certificate for outbound. Available only on Windows 8 and Windows Server 2012.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_FLAG_VERIFY_NAP_CERTIFICATE</c></term>
		/// <term>Verify that the inbound certificate is NAP. Available only on Windows 8 and Windows Server 2012.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_FLAG_FOLLOW_RENEWAL_CERTIFICATE</c></term>
		/// <term>
		/// Follow the renewal property on the certificate when selecting local certificate for outbound. Only applicable when the hash of
		/// the certificate is specified. Available only on Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public IKEEXT_CERT_FLAG flags;
	}

	/// <summary>The IKEEXT_CERTIFICATE_AUTHENTICATION1 is available. For Windows 8, IKEEXT_CERTIFICATE_AUTHENTICATION2 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_certificate_authentication0 typedef struct
	// IKEEXT_CERTIFICATE_AUTHENTICATION0_ { IKEEXT_CERT_CONFIG_TYPE inboundConfigType; union { struct { UINT32 inboundRootArraySize;
	// IKEEXT_CERT_ROOT_CONFIG0 *inboundRootArray; }; IKEEXT_CERT_ROOT_CONFIG0 *inboundEnterpriseStoreConfig; IKEEXT_CERT_ROOT_CONFIG0
	// *inboundTrustedRootStoreConfig; }; IKEEXT_CERT_CONFIG_TYPE outboundConfigType; union { struct { UINT32 outboundRootArraySize;
	// IKEEXT_CERT_ROOT_CONFIG0 *outboundRootArray; }; IKEEXT_CERT_ROOT_CONFIG0 *outboundEnterpriseStoreConfig; IKEEXT_CERT_ROOT_CONFIG0
	// *outboundTrustedRootStoreConfig; }; UINT32 flags; } IKEEXT_CERTIFICATE_AUTHENTICATION0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CERTIFICATE_AUTHENTICATION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CERTIFICATE_AUTHENTICATION0
	{
		/// <summary>
		/// <para>Certificate configuration type for inbound peer certificate verification.</para>
		/// <para>See IKEEXT_CERT_CONFIG_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_CERT_CONFIG_TYPE inboundConfigType;

		private UNION inbound;

		/// <summary>
		/// <para>Number of elements in the <c>inboundRootArray</c> member.</para>
		/// <para>Available when <c>inboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_EXPLICIT_TRUST_LIST</c>.</para>
		/// </summary>
		public uint inboundRootArraySize { get => inbound.a.size; set => inbound.a.size = value; }

		/// <summary>
		/// <para>Explicit trust list for verifying the peer certificate chain.</para>
		/// <para>Available when <c>inboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_EXPLICIT_TRUST_LIST</c>.</para>
		/// <para>See IKEEXT_CERT_ROOT_CONFIG0 for more information.</para>
		/// </summary>
		public IntPtr inboundRootArray { get => inbound.a.data; set => inbound.a.data = value; }

		/// <summary>
		/// <para>Enterprise store configuration for verifying the peer certificate chain.</para>
		/// <para>Available when <c>inboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_ENTERPRISE_STORE</c>.</para>
		/// <para>See IKEEXT_CERT_ROOT_CONFIG0 for more information.</para>
		/// </summary>
		public ref IKEEXT_CERT_ROOT_CONFIG0 inboundEnterpriseStoreConfig => ref inbound.p.AsRef<IKEEXT_CERT_ROOT_CONFIG0>();

		/// <summary>
		/// <para>Trusted root store configuration for verifying the peer certificate chain.</para>
		/// <para>Available when <c>inboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_TRUSTED_ROOT_STORE</c>.</para>
		/// <para>See IKEEXT_CERT_ROOT_CONFIG0 for more information.</para>
		/// </summary>
		public ref IKEEXT_CERT_ROOT_CONFIG0 inboundTrustedRootStoreConfig => ref inbound.p.AsRef<IKEEXT_CERT_ROOT_CONFIG0>();

		/// <summary>
		/// <para>Certificate configuration type for outbound local certificate verification.</para>
		/// <para>See IKEEXT_CERT_CONFIG_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_CERT_CONFIG_TYPE outboundConfigType;

		private UNION outbound;

		/// <summary>
		/// <para>Number of elements in the <c>outboundRootArray</c> member.</para>
		/// <para>Available when <c>outboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_EXPLICIT_TRUST_LIST</c>.</para>
		/// </summary>
		public uint outboundRootArraySize { get => outbound.a.size; set => outbound.a.size = value; }

		/// <summary>
		/// <para>Explicit trust list for selecting a certificate chain to send to the peer.</para>
		/// <para>Available when <c>outboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_EXPLICIT_TRUST_LIST</c>.</para>
		/// <para>See IKEEXT_CERT_ROOT_CONFIG0 for more information.</para>
		/// </summary>
		public IntPtr outboundRootArray { get => outbound.a.data; set => outbound.a.data = value; }

		/// <summary>
		/// <para>Enterprise store configuration for selecting the certificate chain.</para>
		/// <para>Available when <c>outboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_ENTERPRISE_STORE</c>.</para>
		/// <para>See IKEEXT_CERT_ROOT_CONFIG0 for more information.</para>
		/// </summary>
		public ref IKEEXT_CERT_ROOT_CONFIG0 outboundEnterpriseStoreConfig => ref outbound.p.AsRef<IKEEXT_CERT_ROOT_CONFIG0>();

		/// <summary>
		/// <para>Trusted root store configuration for selecting the certificate chain.</para>
		/// <para>Available when <c>outboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_ROOT_STORE</c>.</para>
		/// <para>See IKEEXT_CERT_ROOT_CONFIG0 for more information.</para>
		/// </summary>
		public ref IKEEXT_CERT_ROOT_CONFIG0 outboundTrustedRootStoreConfig => ref outbound.p.AsRef<IKEEXT_CERT_ROOT_CONFIG0>();

		/// <summary>
		/// <para>A combination of the following values that specifies the certificate authentication characteristics.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IKE/AuthIP certificate authentication flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_FLAG_SSL_ONE_WAY</c></term>
		/// <term>Enable SSL one way authentication. Applicable only to AuthIP.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_FLAG_DISABLE_CRL_CHECK</c></term>
		/// <term>
		/// Disable CRL checking. By default weak CRL checking is enabled. Weak checking means that a certificate will be rejected if and
		/// only if CRL is successfully looked up and the certificate is found to be revoked.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_ENABLE_CRL_CHECK_STRONG</c></term>
		/// <term>
		/// Enable strong CRL checking. Strong checking means that a certificate will be rejected if certificate is found to be revoked, or
		/// if any other error (for example, CRL could not be retrieved) takes place while performing the revocation checking.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_DISABLE_SSL_CERT_VALIDATION</c></term>
		/// <term>
		/// SSL validation requires certain EKUs, like server auth EKU from a server. This flag disables the server authentication EKU check,
		/// but still performs the other IKE-style certificate verification. Applicable only to AuthIP.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_ALLOW_HTTP_CERT_LOOKUP</c></term>
		/// <term>
		/// Allow lookup of peer certificate information from an HTTP URL. Applicable only to IKEv2. Available only on Windows 7, Windows
		/// Server 2008 R2, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_URL_CONTAINS_BUNDLE</c></term>
		/// <term>
		/// Indicates that the URL specified in the certificate authentication policy points to an encoded certificate bundle. If this flag
		/// is not specified, IKEv2 will assume that the URL points to an encoded certificate. Applicable only to IKEv2. Available only on
		/// Windows 7, Windows Server 2008 R2, and later.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public IKEEXT_CERT_AUTH flags;

		[StructLayout(LayoutKind.Explicit)]
		internal struct UNION
		{
			[FieldOffset(0)]
			public FWP_BYTE_BLOB a;

			[FieldOffset(0)]
			public IntPtr p;
		}
	}

	/// <summary>The IKEEXT_CERTIFICATE_AUTHENTICATION2 is available. For Windows Vista, IKEEXT_CERTIFICATE_AUTHENTICATION0 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_certificate_authentication1 typedef struct
	// IKEEXT_CERTIFICATE_AUTHENTICATION1_ { IKEEXT_CERT_CONFIG_TYPE inboundConfigType; union { struct { UINT32 inboundRootArraySize;
	// IKEEXT_CERT_ROOT_CONFIG0 *inboundRootArray; }; IKEEXT_CERT_ROOT_CONFIG0 *inboundEnterpriseStoreConfig; IKEEXT_CERT_ROOT_CONFIG0
	// *inboundTrustedRootStoreConfig; }; IKEEXT_CERT_CONFIG_TYPE outboundConfigType; union { struct { UINT32 outboundRootArraySize;
	// IKEEXT_CERT_ROOT_CONFIG0 *outboundRootArray; }; IKEEXT_CERT_ROOT_CONFIG0 *outboundEnterpriseStoreConfig; IKEEXT_CERT_ROOT_CONFIG0
	// *outboundTrustedRootStoreConfig; }; UINT32 flags; FWP_BYTE_BLOB localCertLocationUrl; } IKEEXT_CERTIFICATE_AUTHENTICATION1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CERTIFICATE_AUTHENTICATION1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CERTIFICATE_AUTHENTICATION1
	{
		/// <summary>
		/// <para>Certificate configuration type for inbound peer certificate verification.</para>
		/// <para>See IKEEXT_CERT_CONFIG_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_CERT_CONFIG_TYPE inboundConfigType;

		private IKEEXT_CERTIFICATE_AUTHENTICATION0.UNION inbound;

		/// <summary>
		/// <para>Number of elements in the <c>inboundRootArray</c> member.</para>
		/// <para>Available when <c>inboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_EXPLICIT_TRUST_LIST</c>.</para>
		/// </summary>
		public uint inboundRootArraySize { get => inbound.a.size; set => inbound.a.size = value; }

		/// <summary>
		/// <para>Explicit trust list for verifying the peer certificate chain.</para>
		/// <para>Available when <c>inboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_EXPLICIT_TRUST_LIST</c>.</para>
		/// <para>See IKEEXT_CERT_ROOT_CONFIG0 for more information.</para>
		/// </summary>
		public IntPtr inboundRootArray { get => inbound.a.data; set => inbound.a.data = value; }

		/// <summary>
		/// <para>Enterprise store configuration for verifying the peer certificate chain.</para>
		/// <para>Available when <c>inboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_ENTERPRISE_STORE</c>.</para>
		/// <para>See IKEEXT_CERT_ROOT_CONFIG0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_CERT_ROOT_CONFIG0> inboundEnterpriseStoreConfig { get => new(inbound.p); set => inbound.p = value; }

		/// <summary>
		/// <para>Trusted root store configuration for verifying the peer certificate chain.</para>
		/// <para>Available when <c>inboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_TRUSTED_ROOT_STORE</c>.</para>
		/// <para>See IKEEXT_CERT_ROOT_CONFIG0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_CERT_ROOT_CONFIG0> inboundTrustedRootStoreConfig { get => new(inbound.p); set => inbound.p = value; }

		/// <summary>
		/// <para>Certificate configuration type for outbound local certificate verification.</para>
		/// <para>See IKEEXT_CERT_CONFIG_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_CERT_CONFIG_TYPE outboundConfigType;

		private IKEEXT_CERTIFICATE_AUTHENTICATION0.UNION outbound;

		/// <summary>
		/// <para>Number of elements in the <c>outboundRootArray</c> member.</para>
		/// <para>Available when <c>outboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_EXPLICIT_TRUST_LIST</c>.</para>
		/// </summary>
		public uint outboundRootArraySize { get => outbound.a.size; set => outbound.a.size = value; }

		/// <summary>
		/// <para>Explicit trust list for selecting a certificate chain to send to the peer.</para>
		/// <para>Available when <c>outboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_EXPLICIT_TRUST_LIST</c>.</para>
		/// <para>See IKEEXT_CERT_ROOT_CONFIG0 for more information.</para>
		/// </summary>
		public IntPtr outboundRootArray { get => outbound.a.data; set => outbound.a.data = value; }

		/// <summary>
		/// <para>Enterprise store configuration for selecting the certificate chain.</para>
		/// <para>Available when <c>outboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_ENTERPRISE_STORE</c>.</para>
		/// <para>See IKEEXT_CERT_ROOT_CONFIG0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_CERT_ROOT_CONFIG0> outboundEnterpriseStoreConfig { get => new(outbound.p); set => outbound.p = value; }

		/// <summary>
		/// <para>Trusted root store configuration for selecting the certificate chain.</para>
		/// <para>Available when <c>outboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_ROOT_STORE</c>.</para>
		/// <para>See IKEEXT_CERT_ROOT_CONFIG0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_CERT_ROOT_CONFIG0> outboundTrustedRootStoreConfig { get => new(outbound.p); set => outbound.p = value; }

		/// <summary>
		/// <para>A combination of the following values that specifies the certificate authentication characteristics.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IKE/AuthIP certificate authentication flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_FLAG_SSL_ONE_WAY</c></term>
		/// <term>Enable SSL one way authentication. Applicable only to AuthIP.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_FLAG_DISABLE_CRL_CHECK</c></term>
		/// <term>
		/// Disable CRL checking. By default weak CRL checking is enabled. Weak checking means that a certificate will be rejected if and
		/// only if CRL is successfully looked up and the certificate is found to be revoked.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_ENABLE_CRL_CHECK_STRONG</c></term>
		/// <term>
		/// Enable strong CRL checking. Strong checking means that a certificate will be rejected if certificate is found to be revoked, or
		/// if any other error (for example, CRL could not be retrieved) takes place while performing the revocation checking.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_DISABLE_SSL_CERT_VALIDATION</c></term>
		/// <term>
		/// SSL validation requires certain EKUs, like server auth EKU from a server. This flag disables the server authentication EKU check,
		/// but still performs the other IKE-style certificate verification. Applicable only to AuthIP.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_ALLOW_HTTP_CERT_LOOKUP</c></term>
		/// <term>
		/// Allow lookup of peer certificate information from an HTTP URL. Applicable only to IKEv2. Available only on Windows 7, Windows
		/// Server 2008 R2, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_URL_CONTAINS_BUNDLE</c></term>
		/// <term>
		/// Indicates that the URL specified in the certificate authentication policy points to an encoded certificate bundle. If this flag
		/// is not specified, IKEv2 will assume that the URL points to an encoded certificate. Applicable only to IKEv2. Available only on
		/// Windows 7, Windows Server 2008 R2, and later.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public IKEEXT_CERT_AUTH flags;

		/// <summary>
		/// <para>
		/// HTTP URL pointing to an encoded certificate or certificate-bundle, that will be used by IKEv2 for authenticating local machine to
		/// a peer.
		/// </para>
		/// <para>Applicable only to IKEv2.</para>
		/// <para>See FWP_BYTE_BLOB for more information.</para>
		/// </summary>
		public FWP_BYTE_BLOB localCertLocationUrl;
	}

	/// <summary>
	/// The <c>IKEEXT_CERTIFICATE_AUTHENTICATION2</c> structure is used to specify various parameters for authentication with certificates.
	/// IKEEXT_CERTIFICATE_AUTHENTICATION0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_certificate_authentication2 typedef struct
	// IKEEXT_CERTIFICATE_AUTHENTICATION2_ { IKEEXT_CERT_CONFIG_TYPE inboundConfigType; union { struct { UINT32 inboundRootArraySize;
	// IKEEXT_CERTIFICATE_CRITERIA0 *inboundRootCriteria; }; struct { UINT32 inboundEnterpriseStoreArraySize; IKEEXT_CERTIFICATE_CRITERIA0
	// *inboundEnterpriseStoreCriteria; }; struct { UINT32 inboundRootStoreArraySize; IKEEXT_CERTIFICATE_CRITERIA0
	// *inboundTrustedRootStoreCriteria; }; }; IKEEXT_CERT_CONFIG_TYPE outboundConfigType; union { struct { UINT32 outboundRootArraySize;
	// IKEEXT_CERTIFICATE_CRITERIA0 *outboundRootCriteria; }; struct { UINT32 outboundEnterpriseStoreArraySize; IKEEXT_CERTIFICATE_CRITERIA0
	// *outboundEnterpriseStoreCriteria; }; struct { UINT32 outboundRootStoreArraySize; IKEEXT_CERTIFICATE_CRITERIA0
	// *outboundTrustedRootStoreCriteria; }; }; UINT32 flags; FWP_BYTE_BLOB localCertLocationUrl; } IKEEXT_CERTIFICATE_AUTHENTICATION2;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CERTIFICATE_AUTHENTICATION2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CERTIFICATE_AUTHENTICATION2
	{
		/// <summary>
		/// <para>Type: IKEEXT_CERT_CONFIG_TYPE</para>
		/// <para>Certificate configuration type for inbound peer certificate verification.</para>
		/// </summary>
		public IKEEXT_CERT_CONFIG_TYPE inboundConfigType;

		private FWP_BYTE_BLOB inbound;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of elements in the <c>inboundRootCriteria</c> member.</para>
		/// <para>Available when <c>inboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_EXPLICIT_TRUST_LIST</c>.</para>
		/// </summary>
		public uint inboundRootArraySize { get => inbound.size; set => inbound.size = value; }

		/// <summary>
		/// <para>Type: IKEEXT_CERTIFICATE_CRITERIA0*</para>
		/// <para>
		/// List of certificate criteria containing explicit trusted authorities that should be used to verify the peer certificate chain.
		/// </para>
		/// <para>Available when <c>inboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_EXPLICIT_TRUST_LIST</c>.</para>
		/// </summary>
		public IntPtr inboundRootCriteria { get => inbound.data; set => inbound.data = value; }

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of elements in the <c>inboundEnterpriseStoreCriteria</c> member.</para>
		/// <para>Available when <c>inboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_ENTERPRISE_STORE</c>.</para>
		/// </summary>
		public uint inboundEnterpriseStoreArraySize { get => inbound.size; set => inbound.size = value; }

		/// <summary>
		/// <para>Type: IKEEXT_CERTIFICATE_CRITERIA0*</para>
		/// <para>List of enterprise store criteria that should be used to verify the peer certificate chain.</para>
		/// <para>Available when <c>inboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_ENTERPRISE_STORE</c>.</para>
		/// </summary>
		public IntPtr inboundEnterpriseStoreCriteria { get => inbound.data; set => inbound.data = value; }

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of elements in the <c>inboundTrustedRootStoreCriteria</c> member.</para>
		/// <para>Available when <c>inboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_TRUSTED_ROOT_STORE</c>.</para>
		/// </summary>
		public uint inboundRootStoreArraySize { get => inbound.size; set => inbound.size = value; }

		/// <summary>
		/// <para>Type: IKEEXT_CERTIFICATE_CRITERIA0*</para>
		/// <para>List of trusted root store criteria that should be used to verify the peer certificate chain.</para>
		/// <para>Available when <c>inboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_TRUSTED_ROOT_STORE</c>.</para>
		/// </summary>
		public IntPtr inboundTrustedRootStoreCriteria { get => inbound.data; set => inbound.data = value; }

		/// <summary>
		/// <para>Type: IKEEXT_CERT_CONFIG_TYPE</para>
		/// <para>Certificate configuration type for outbound local certificate verification.</para>
		/// </summary>
		public IKEEXT_CERT_CONFIG_TYPE outboundConfigType;

		private FWP_BYTE_BLOB outbound;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of elements in the <c>outboundRootCriteria</c> member.</para>
		/// <para>Available when <c>outboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_EXPLICIT_TRUST_LIST</c>.</para>
		/// </summary>
		public uint outboundRootArraySize { get => outbound.size; set => outbound.size = value; }

		/// <summary>
		/// <para>Type: IKEEXT_CERTIFICATE_CRITERIA0*</para>
		/// <para>
		/// List of certificate criteria containing explicit trusted authorities that should be used to select the certificate chain that
		/// will be sent to the peer.
		/// </para>
		/// <para>Available when <c>outboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_EXPLICIT_TRUST_LIST</c>.</para>
		/// </summary>
		public IntPtr outboundRootCriteria { get => outbound.data; set => outbound.data = value; }

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of elements in the <c>outboundEnterpriseStoreCriteria</c> member.</para>
		/// <para>Available when <c>outboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_ENTERPRISE_STORE</c>.</para>
		/// </summary>
		public uint outboundEnterpriseStoreArraySize { get => outbound.size; set => outbound.size = value; }

		/// <summary>
		/// <para>Type: IKEEXT_CERTIFICATE_CRITERIA0*</para>
		/// <para>List of enterprise store criteria that should be used to select the certificate chain that will be sent to the peer.</para>
		/// <para>Available when <c>outboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_ENTERPRISE_STORE</c>.</para>
		/// </summary>
		public IntPtr outboundEnterpriseStoreCriteria { get => outbound.data; set => outbound.data = value; }

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of elements in the <c>outboundRootStoreArraySize</c> member.</para>
		/// <para>Available when <c>outboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_TRUSTED_ROOT_STORE</c>.</para>
		/// </summary>
		public uint outboundRootStoreArraySize { get => outbound.size; set => outbound.size = value; }

		/// <summary>
		/// <para>Type: IKEEXT_CERTIFICATE_CRITERIA0*</para>
		/// <para>List of trusted root store criteria that should be used to select the certificate chain that will be sent to the peer.</para>
		/// <para>Available when <c>outboundConfigType</c> is <c>IKEEXT_CERT_CONFIG_TRUSTED_ROOT_STORE</c>.</para>
		/// </summary>
		public IntPtr outboundTrustedRootStoreCriteria { get => outbound.data; set => outbound.data = value; }

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>A combination of the following values that specifies the certificate authentication characteristics.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IKE/AuthIP certificate authentication flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_FLAG_SSL_ONE_WAY</c></term>
		/// <term>Enable SSL one-way authentication. Applicable only to AuthIP.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_FLAG_DISABLE_CRL_CHECK</c></term>
		/// <term>
		/// Disable CRL checking. By default weak CRL checking is enabled. Weak checking means that a certificate will be rejected if and
		/// only if CRL is successfully looked up and the certificate is found to be revoked.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_ENABLE_CRL_CHECK_STRONG</c></term>
		/// <term>
		/// Enable strong CRL checking. Strong checking means that a certificate will be rejected if certificate is found to be revoked, or
		/// if any other error (for example, CRL could not be retrieved) takes place while performing the revocation checking.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_DISABLE_SSL_CERT_VALIDATION</c></term>
		/// <term>
		/// Disables the SSL server authentication extended key usage (EKU) check. Other types of AuthIP validation are still performed.
		/// Applicable only to AuthIP.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_ALLOW_HTTP_CERT_LOOKUP</c></term>
		/// <term>Allow lookup of peer certificate information from an HTTP URL. Applicable only to IKEv2.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_CERT_AUTH_URL_CONTAINS_BUNDLE</c></term>
		/// <term>
		/// The URL specified in the certificate authentication policy points to an encoded certificate-bundle. If this flag is not
		/// specified, IKEv2 will assume that the URL points to an encoded certificate. Applicable only to IKEv2.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public IKEEXT_CERT_AUTH flags;

		/// <summary>
		/// <para>Type: FWP_BYTE_BLOB</para>
		/// <para>
		/// HTTP URL pointing to an encoded certificate or certificate-bundle, that will be used by IKEv2 for authenticating local machine to
		/// a peer.
		/// </para>
		/// <para>Applicable only to IKEv2.</para>
		/// </summary>
		public FWP_BYTE_BLOB localCertLocationUrl;
	}

	/// <summary>
	/// The <c>IKEEXT_CERTIFICATE_CREDENTIAL0</c> structure is used to store credential information specific to certificate authentication.
	/// IKEEXT_CERTIFICATE_CREDENTIAL1 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_certificate_credential0 typedef struct
	// IKEEXT_CERTIFICATE_CREDENTIAL0_ { FWP_BYTE_BLOB subjectName; FWP_BYTE_BLOB certHash; UINT32 flags; } IKEEXT_CERTIFICATE_CREDENTIAL0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CERTIFICATE_CREDENTIAL0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CERTIFICATE_CREDENTIAL0
	{
		/// <summary>
		/// <para>Encoded subject name of the certificate used for authentication.</para>
		/// <para>See FWP_BYTE_BLOB for more information.</para>
		/// </summary>
		public FWP_BYTE_BLOB subjectName;

		/// <summary>
		/// <para>SHA thumbprint of the certificate.</para>
		/// <para>See FWP_BYTE_BLOB for more information.</para>
		/// </summary>
		public FWP_BYTE_BLOB certHash;

		/// <summary>
		/// <para>Possible values:</para>
		/// <para>IKEEXT_CERT_CREDENTIAL_FLAG_NAP_CERT</para>
		/// </summary>
		public IKEEXT_CERT_CREDENTIAL_FLAG flags;
	}

	/// <summary>The IKEEXT_CERTIFICATE_CREDENTIAL0 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_certificate_credential1 typedef struct
	// IKEEXT_CERTIFICATE_CREDENTIAL1_ { FWP_BYTE_BLOB subjectName; FWP_BYTE_BLOB certHash; UINT32 flags; FWP_BYTE_BLOB certificate; } IKEEXT_CERTIFICATE_CREDENTIAL1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CERTIFICATE_CREDENTIAL1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CERTIFICATE_CREDENTIAL1
	{
		/// <summary>
		/// <para>Encoded subject name of the certificate used for authentication. Use CertNameToStr to convert the encoded name to string.</para>
		/// <para>See FWP_BYTE_BLOB for more information.</para>
		/// </summary>
		public FWP_BYTE_BLOB subjectName;

		/// <summary>
		/// <para>SHA thumbprint of the certificate.</para>
		/// <para>See FWP_BYTE_BLOB for more information.</para>
		/// </summary>
		public FWP_BYTE_BLOB certHash;

		/// <summary>
		/// <para>Possible values:</para>
		/// <para>IKEEXT_CERT_CREDENTIAL_FLAG_NAP_CERT</para>
		/// </summary>
		public IKEEXT_CERT_CREDENTIAL_FLAG flags;

		/// <summary>
		/// <para>The encoded certificate. Use CertCreateCertificateContext to create a certificate context from the encoded certificate.</para>
		/// <para>See FWP_BYTE_BLOB for more information.</para>
		/// </summary>
		public FWP_BYTE_BLOB certificate;
	}

	/// <summary>The <c>IKEEXT_CERTIFICATE_CRITERIA0</c> structure contains a set of criteria to applied to an authentication method.</summary>
	/// <remarks>
	/// The <c>certData</c> member refers to the encoded name of the root certificate, while the <c>certHash</c>, <c>eku</c>, and <c>name</c>
	/// members refer to criteria on the end certificate.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_certificate_criteria0 typedef struct
	// IKEEXT_CERTIFICATE_CRITERIA0_ { FWP_BYTE_BLOB certData; FWP_BYTE_BLOB certHash; IKEEXT_CERT_EKUS0 *eku; IKEEXT_CERT_NAME0 *name;
	// UINT32 flags; } IKEEXT_CERTIFICATE_CRITERIA0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CERTIFICATE_CRITERIA0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CERTIFICATE_CRITERIA0
	{
		/// <summary>
		/// <para>Type: FWP_BYTE_BLOB</para>
		/// <para>X509/ASN.1 encoded name of the root certificate. Should be empty when specifying Enterprise or trusted root store config.</para>
		/// </summary>
		public FWP_BYTE_BLOB certData;

		/// <summary>
		/// <para>Type: FWP_BYTE_BLOB</para>
		/// <para>16-character hexadecimal string that represents the ID, thumbprint or HASH of the end certificate.</para>
		/// </summary>
		public FWP_BYTE_BLOB certHash;

		/// <summary>
		/// <para>Type: <see cref="IKEEXT_CERT_EKUS0"/>*</para>
		/// <para>The specific extended key usage (EKU) object identifiers (OIDs) selected for the criteria on the end certificate.</para>
		/// </summary>
		public IntPtr eku;

		/// <summary>
		/// <para>Type: IKEEXT_CERT_NAME0*</para>
		/// <para>The name/subject selected for the criteria on the end certificate.</para>
		/// </summary>
		public IntPtr name;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Reserved for system use.</para>
		/// </summary>
		public uint flags;
	}

	/// <summary>The <c>IKEEXT_CIPHER_ALGORITHM0</c> structure stores information about the IKE/AuthIP encryption algorithm.</summary>
	/// <remarks>
	/// <c>IKEEXT_CIPHER_ALGORITHM0</c> is a specific implementation of IKEEXT_CIPHER_ALGORITHM. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_cipher_algorithm0 typedef struct
	// IKEEXT_CIPHER_ALGORITHM0_ { IKEEXT_CIPHER_TYPE algoIdentifier; UINT32 keyLen; UINT32 rounds; } IKEEXT_CIPHER_ALGORITHM0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CIPHER_ALGORITHM0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CIPHER_ALGORITHM0
	{
		/// <summary>
		/// <para>The type of encryption algorithm.</para>
		/// <para>See IKEEXT_CIPHER_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_CIPHER_TYPE algoIdentifier;

		/// <summary>Unused parameter, always set it to 0.</summary>
		public uint keyLen;

		/// <summary>Unused parameter, always set it to 0.</summary>
		public uint rounds;
	}

	/// <summary>
	/// The <c>IKEEXT_COMMON_STATISTICS0</c> structure contains various statistics common to IKE and Authip. IKEEXT_COMMON_STATISTICS1 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_common_statistics0 typedef struct
	// IKEEXT_COMMON_STATISTICS0_ { IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS0 v4Statistics; IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS0
	// v6Statistics; UINT32 totalPacketsReceived; UINT32 totalInvalidPacketsReceived; UINT32 currentQueuedWorkitems; } IKEEXT_COMMON_STATISTICS0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_COMMON_STATISTICS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_COMMON_STATISTICS0
	{
		/// <summary>
		/// <para>IPv4 common statistics.</para>
		/// <para>See IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS0 for more information.</para>
		/// </summary>
		public IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS0 v4Statistics;

		/// <summary>
		/// <para>IPv6 common statistics.</para>
		/// <para>See IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS0 for more information.</para>
		/// </summary>
		public IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS0 v6Statistics;

		/// <summary>Total number of packets received.</summary>
		public uint totalPacketsReceived;

		/// <summary>Total number of invalid packets received.</summary>
		public uint totalInvalidPacketsReceived;

		/// <summary>Current number of work items that are queued and waiting to be processed.</summary>
		public uint currentQueuedWorkitems;
	}

	/// <summary>
	/// The <c>IKEEXT_COMMON_STATISTICS1</c> structure contains various statistics common to IKE, Authip, and IKEv2.
	/// IKEEXT_COMMON_STATISTICS0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_common_statistics1 typedef struct
	// IKEEXT_COMMON_STATISTICS1_ { IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS1 v4Statistics; IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS1
	// v6Statistics; UINT32 totalPacketsReceived; UINT32 totalInvalidPacketsReceived; UINT32 currentQueuedWorkitems; } IKEEXT_COMMON_STATISTICS1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_COMMON_STATISTICS1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_COMMON_STATISTICS1
	{
		/// <summary>
		/// <para>IPv4 common statistics.</para>
		/// <para>See IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS1 for more information.</para>
		/// </summary>
		public IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS1 v4Statistics;

		/// <summary>
		/// <para>IPv6 common statistics.</para>
		/// <para>See IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS1 for more information.</para>
		/// </summary>
		public IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS1 v6Statistics;

		/// <summary>Total number of packets received.</summary>
		public uint totalPacketsReceived;

		/// <summary>Total number of invalid packets received.</summary>
		public uint totalInvalidPacketsReceived;

		/// <summary>Current number of work items that are queued and waiting to be processed.</summary>
		public uint currentQueuedWorkitems;
	}

	/// <summary>The <c>IKEEXT_COOKIE_PAIR0</c> structure used to store a pair of IKE/Authip cookies.</summary>
	/// <remarks>
	/// <c>IKEEXT_COOKIE_PAIR0</c> is a specific implementation of IKEEXT_COOKIE_PAIR. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_cookie_pair0 typedef struct IKEEXT_COOKIE_PAIR0_ {
	// IKEEXT_COOKIE initiator; IKEEXT_COOKIE responder; } IKEEXT_COOKIE_PAIR0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_COOKIE_PAIR0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_COOKIE_PAIR0
	{
		/// <summary>Initiator cookie. An IKEEXT_COOKIE is a UINT64.</summary>
		public ulong initiator;

		/// <summary>Responder cookie. An IKEEXT_COOKIE is a UINT64.</summary>
		public ulong responder;
	}

	/// <summary>
	/// The <c>IKEEXT_CREDENTIAL_PAIR0</c> structure is used to store credential information used for the authentication.
	/// IKEEXT_CREDENTIAL_PAIR2 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_credential_pair0 typedef struct
	// IKEEXT_CREDENTIAL_PAIR0_ { IKEEXT_CREDENTIAL0 localCredentials; IKEEXT_CREDENTIAL0 peerCredentials; } IKEEXT_CREDENTIAL_PAIR0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CREDENTIAL_PAIR0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CREDENTIAL_PAIR0
	{
		/// <summary>
		/// <para>Local credentials used for authentication.</para>
		/// <para>See IKEEXT_CREDENTIAL0 for more information.</para>
		/// </summary>
		public IKEEXT_CREDENTIAL0 localCredentials;

		/// <summary>
		/// <para>Peer credentials used for authentication.</para>
		/// <para>See IKEEXT_CREDENTIAL0 for more information.</para>
		/// </summary>
		public IKEEXT_CREDENTIAL0 peerCredentials;
	}

	/// <summary>
	/// The <c>IKEEXT_CREDENTIAL_PAIR1</c> structure is used to store credential information used for the authentication.
	/// IKEEXT_CREDENTIAL_PAIR2 is available. For Windows Vista, IKEEXT_CREDENTIAL_PAIR0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_credential_pair1 typedef struct
	// IKEEXT_CREDENTIAL_PAIR1_ { IKEEXT_CREDENTIAL1 localCredentials; IKEEXT_CREDENTIAL1 peerCredentials; } IKEEXT_CREDENTIAL_PAIR1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CREDENTIAL_PAIR1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CREDENTIAL_PAIR1
	{
		/// <summary>
		/// <para>Local credentials used for authentication.</para>
		/// <para>See IKEEXT_CREDENTIAL1 for more information.</para>
		/// </summary>
		public IKEEXT_CREDENTIAL1 localCredentials;

		/// <summary>
		/// <para>Peer credentials used for authentication.</para>
		/// <para>See IKEEXT_CREDENTIAL1 for more information.</para>
		/// </summary>
		public IKEEXT_CREDENTIAL1 peerCredentials;
	}

	/// <summary>
	/// The <c>IKEEXT_CREDENTIAL_PAIR2</c> structure is used to store credential information used for the authentication.
	/// IKEEXT_CREDENTIAL_PAIR1 is available. For Windows Vista, IKEEXT_CREDENTIAL_PAIR0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_credential_pair2 typedef struct
	// IKEEXT_CREDENTIAL_PAIR2_ { IKEEXT_CREDENTIAL2 localCredentials; IKEEXT_CREDENTIAL2 peerCredentials; } IKEEXT_CREDENTIAL_PAIR2;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CREDENTIAL_PAIR2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CREDENTIAL_PAIR2
	{
		/// <summary>
		/// <para>Type: IKEEXT_CREDENTIAL2</para>
		/// <para>Local credentials used for authentication.</para>
		/// </summary>
		public IKEEXT_CREDENTIAL2 localCredentials;

		/// <summary>
		/// <para>Type: IKEEXT_CREDENTIAL2</para>
		/// <para>Peer credentials used for authentication.</para>
		/// </summary>
		public IKEEXT_CREDENTIAL2 peerCredentials;
	}

	/// <summary>
	/// The <c>IKEEXT_CREDENTIAL0</c> structure is used to store credential information used for the authentication. IKEEXT_CREDENTIAL1 is
	/// available. For Windows 8, IKEEXT_CREDENTIAL2 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_credential0 typedef struct IKEEXT_CREDENTIAL0_ {
	// IKEEXT_AUTHENTICATION_METHOD_TYPE authenticationMethodType; IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE impersonationType; union {
	// IKEEXT_PRESHARED_KEY_AUTHENTICATION0 *presharedKey; IKEEXT_CERTIFICATE_CREDENTIAL0 *certificate; IKEEXT_NAME_CREDENTIAL0 *name; }; } IKEEXT_CREDENTIAL0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CREDENTIAL0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CREDENTIAL0
	{
		/// <summary>
		/// <para>Type of authentication method.</para>
		/// <para>See IKEEXT_AUTHENTICATION_METHOD_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_AUTHENTICATION_METHOD_TYPE authenticationMethodType;

		/// <summary>
		/// <para>Type of impersonation.</para>
		/// <para>See IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE impersonationType;

		private IntPtr ptr;

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_PRESHARED_KEY</c>.</para>
		/// <para>See IKEEXT_PRESHARED_KEY_AUTHENTICATION0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_PRESHARED_KEY_AUTHENTICATION0> presharedKey { get => new(ptr, false); set => ptr = value; }
		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is one of the following values.</para>
		/// <para>
		/// <c>IKEEXT_CERTIFICATE</c><c>IKEEXT_CERTIFICATE_ECDSA_P256</c><c>IKEEXT_CERTIFICATE_ECDSA_P384</c><c>IKEEXT_SSL</c><c>IKEEXT_SSL_ECDSA_P256</c><c>IKEEXT_SSL_ECDSA_P384</c><c>IKEEXT_IPV6_CGA</c>
		/// See IKEEXT_CERTIFICATE_CREDENTIAL0 for more information.
		/// </para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_CERTIFICATE_CREDENTIAL0> certificate { get => new(ptr, false); set => ptr = value; }
		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is one of the following values.</para>
		/// <para><c>IKEEXT_KERBEROS</c><c>IKEEXT_NTML_V2</c> See IKEEXT_NAME_CREDENTIAL0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_NAME_CREDENTIAL0> name { get => new(ptr, false); set => ptr = value; }	}

	/// <summary>
	/// The <c>IKEEXT_CREDENTIAL1</c> structure is used to store credential information used for the authentication. IKEEXT_CREDENTIAL2 is
	/// available. For Windows Vista, IKEEXT_CREDENTIAL0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_credential1 typedef struct IKEEXT_CREDENTIAL1_ {
	// IKEEXT_AUTHENTICATION_METHOD_TYPE authenticationMethodType; IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE impersonationType; union {
	// IKEEXT_PRESHARED_KEY_AUTHENTICATION1 *presharedKey; IKEEXT_CERTIFICATE_CREDENTIAL1 *certificate; IKEEXT_NAME_CREDENTIAL0 *name; }; } IKEEXT_CREDENTIAL1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CREDENTIAL1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CREDENTIAL1
	{
		/// <summary>
		/// <para>Type of authentication method.</para>
		/// <para>See IKEEXT_AUTHENTICATION_METHOD_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_AUTHENTICATION_METHOD_TYPE authenticationMethodType;

		/// <summary>
		/// <para>Type of impersonation.</para>
		/// <para>See IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE impersonationType;

		private IntPtr ptr;

		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_PRESHARED_KEY</c>.</para>
		/// <para>See IKEEXT_PRESHARED_KEY_AUTHENTICATION1 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_PRESHARED_KEY_AUTHENTICATION1> presharedKey { get => new(ptr, false); set => ptr = value; }
		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is one of the following values.</para>
		/// <para>
		/// <c>IKEEXT_CERTIFICATE</c><c>IKEEXT_CERTIFICATE_ECDSA_P256</c><c>IKEEXT_CERTIFICATE_ECDSA_P384</c><c>IKEEXT_SSL</c><c>IKEEXT_SSL_ECDSA_P256</c><c>IKEEXT_SSL_ECDSA_P384</c><c>IKEEXT_IPV6_CGA</c>
		/// See IKEEXT_CERTIFICATE_CREDENTIAL1 for more information.
		/// </para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_CERTIFICATE_CREDENTIAL1> certificate { get => new(ptr, false); set => ptr = value; }
		/// <summary>
		/// <para>Available when <c>authenticationMethodType</c> is one of the following values.</para>
		/// <para><c>IKEEXT_KERBEROS</c><c>IKEEXT_NTML_V2</c> See IKEEXT_NAME_CREDENTIAL0 for more information.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_NAME_CREDENTIAL0> name { get => new(ptr, false); set => ptr = value; }	}

	/// <summary>
	/// The <c>IKEEXT_CREDENTIAL2</c> structure is used to store credential information used for the authentication. IKEEXT_CREDENTIAL1 is
	/// available. For Windows Vista, IKEEXT_CREDENTIAL0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_credential2 typedef struct IKEEXT_CREDENTIAL2_ {
	// IKEEXT_AUTHENTICATION_METHOD_TYPE authenticationMethodType; IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE impersonationType; union {
	// IKEEXT_PRESHARED_KEY_AUTHENTICATION1 *presharedKey; IKEEXT_CERTIFICATE_CREDENTIAL1 *certificate; IKEEXT_NAME_CREDENTIAL0 *name; }; } IKEEXT_CREDENTIAL2;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CREDENTIAL2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CREDENTIAL2
	{
		/// <summary>
		/// <para>Type: <c>IKEEXT_AUTHENTICATION_METHOD_TYPE</c></para>
		/// <para>Type of authentication method.</para>
		/// </summary>
		public IKEEXT_AUTHENTICATION_METHOD_TYPE authenticationMethodType;

		/// <summary>
		/// <para>Type: <c>IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE</c></para>
		/// <para>Type of impersonation.</para>
		/// </summary>
		public IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE impersonationType;

		private IntPtr ptr;

		/// <summary>
		/// <para>Type: <c>IKEEXT_PRESHARED_KEY_AUTHENTICATION1*</c></para>
		/// <para>Available when <c>authenticationMethodType</c> is <c>IKEEXT_PRESHARED_KEY</c>.</para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_PRESHARED_KEY_AUTHENTICATION1> presharedKey { get => new(ptr, false); set => ptr = value; }
		/// <summary>
		/// <para>Type: IKEEXT_CERTIFICATE_CREDENTIAL1*</para>
		/// <para>Available when <c>authenticationMethodType</c> is one of the following values.</para>
		/// <para><c>IKEEXT_CERTIFICATE</c><c>IKEEXT_CERTIFICATE_ECDSA_P256</c><c>IKEEXT_CERTIFICATE_ECDSA_P384</c><c>IKEEXT_SSL</c><c>IKEEXT_SSL_ECDSA_P256</c><c>IKEEXT_SSL_ECDSA_P384</c><c>IKEEXT_IPV6_CGA</c></para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_CERTIFICATE_CREDENTIAL1> certificate { get => new(ptr, false); set => ptr = value; }
		/// <summary>
		/// <para>Type: IKEEXT_NAME_CREDENTIAL0*</para>
		/// <para>Available when <c>authenticationMethodType</c> is one of the following values.</para>
		/// <para><c>IKEEXT_KERBEROS</c><c>IKEEXT_NTML_V2</c><c>IKEEXT_RESERVED</c></para>
		/// </summary>
		public SafeCoTaskMemStruct<IKEEXT_NAME_CREDENTIAL0> name { get => new(ptr, false); set => ptr = value; }	}

	/// <summary>
	/// <para>The <c>IKEEXT_CREDENTIALS0</c> structure is used to store multiple credential pairs.</para>
	/// <para>IKEEXT_CREDENTIALS1 is available. For Windows 8, IKEEXT_CREDENTIALS2 is available.</para>
	/// </summary>
	/// <remarks>
	/// <para>IKE has only 1 pair.</para>
	/// <para>AuthIP has 1 pair, or 2 pairs if EM was enabled.</para>
	/// <para>MM authentication is always index 0.</para>
	/// <para>EM authentication, if it occurs, is index 1.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_credentials0 typedef struct IKEEXT_CREDENTIALS0_ {
	// UINT32 numCredentials; IKEEXT_CREDENTIAL_PAIR0 *credentials; } IKEEXT_CREDENTIALS0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CREDENTIALS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CREDENTIALS0 : IBlob<IKEEXT_CREDENTIAL_PAIR0>
	{
		/// <summary>Number of IKEEXT_CREDENTIAL_PAIR0 structures in the array.</summary>
		public uint numCredentials;

		/// <summary>
		/// <para>[size_is(numCredentials)]</para>
		/// <para>Pointer to an array of IKEEXT_CREDENTIAL_PAIR0 structures.</para>
		/// </summary>
		public IntPtr credentials;
	}

	/// <summary>The <c>IKEEXT_CREDENTIALS1</c> structure is used to store multiple credential pairs. IKEEXT_CREDENTIALS0 is available.</summary>
	/// <remarks>
	/// <para>IKE and IKEv2 have only 1 pair.</para>
	/// <para>AuthIP has 1 pair, or 2 pairs if EM was enabled.</para>
	/// <para>MM authentication is always index 0.</para>
	/// <para>EM authentication, if it occurs, is index 1.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_credentials1 typedef struct IKEEXT_CREDENTIALS1_ {
	// UINT32 numCredentials; IKEEXT_CREDENTIAL_PAIR1 *credentials; } IKEEXT_CREDENTIALS1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CREDENTIALS1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CREDENTIALS1 : IBlob<IKEEXT_CREDENTIAL_PAIR1>
	{
		/// <summary>Number of IKEEXT_CREDENTIAL_PAIR1 structures in the array.</summary>
		public uint numCredentials;

		/// <summary>
		/// <para>[size_is(numCredentials)]</para>
		/// <para>Pointer to an array of IKEEXT_CREDENTIAL_PAIR1 structures.</para>
		/// </summary>
		public IntPtr credentials;
	}

	/// <summary>
	/// The <c>IKEEXT_CREDENTIALS2</c> structure is used to store multiple credential pairs. IKEEXT_CREDENTIALS1 is available. For Windows
	/// Vista, IKEEXT_CREDENTIALS0 is available.
	/// </summary>
	/// <remarks>
	/// <para>IKE and IKEv2 have only 1 pair.</para>
	/// <para>AuthIP has 1 pair, or 2 pairs if EM was enabled.</para>
	/// <para>MM authentication is always index 0.</para>
	/// <para>EM authentication, if it occurs, is index 1.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_credentials2 typedef struct IKEEXT_CREDENTIALS2_ {
	// UINT32 numCredentials; IKEEXT_CREDENTIAL_PAIR2 *credentials; } IKEEXT_CREDENTIALS2;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_CREDENTIALS2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_CREDENTIALS2 : IBlob<IKEEXT_CREDENTIAL_PAIR2>
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of IKEEXT_CREDENTIAL_PAIR2 structures in the array.</para>
		/// </summary>
		public uint numCredentials;

		/// <summary>
		/// <para>Type: IKEEXT_CREDENTIAL_PAIR2*</para>
		/// <para>[size_is(numCredentials)]</para>
		/// <para>Pointer to an array of IKEEXT_CREDENTIAL_PAIR2 structures.</para>
		/// </summary>
		public IntPtr credentials;
	}

	/// <summary>
	/// <para>The <c>IKEEXT_EAP_AUTHENTICATION0</c> structure stores information needed for Extensible Authentication Protocol (EAP) authentication.</para>
	/// <para>This structure is only applicable to IKEv2.</para>
	/// </summary>
	/// <remarks>
	/// <c>IKEEXT_EAP_AUTHENTICATION0</c> is a specific implementation of IKEEXT_EAP_AUTHENTICATION. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_eap_authentication0 typedef struct
	// IKEEXT_EAP_AUTHENTICATION0__ { UINT32 flags; } IKEEXT_EAP_AUTHENTICATION0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_EAP_AUTHENTICATION0__")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_EAP_AUTHENTICATION0
	{
		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Pre-shared key authentication flag.</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IKEEXT_EAP_FLAG_LOCAL_AUTH_ONLY</c></term>
		/// <term>Specifies that EAP authentication will be used only to authenticate a local computer to a remote computer.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_EAP_FLAG_REMOTE_AUTH_ONLY</c></term>
		/// <term>Specifies that EAP authentication will be used only to authenticate a remote computer to a local computer.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IKEEXT_EAP_FLAG flags;
	}

	/// <summary>
	/// The <c>IKEEXT_EM_POLICY0</c> structure is used to store AuthIP's extended mode negotiation policy. IKEEXT_EM_POLICY2 is available.
	/// </summary>
	/// <remarks>Applies only to AuthIP.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_em_policy0 typedef struct IKEEXT_EM_POLICY0_ { UINT32
	// numAuthenticationMethods; IKEEXT_AUTHENTICATION_METHOD0 *authenticationMethods; IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE
	// initiatorImpersonationType; } IKEEXT_EM_POLICY0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_EM_POLICY0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_EM_POLICY0
	{
		/// <summary>Number of authentication methods in the array.</summary>
		public uint numAuthenticationMethods;

		/// <summary>
		/// <para>size_is(numAuthenticationMethods)</para>
		/// <para>Array of acceptable authentication methods as specified by IKEEXT_AUTHENTICATION_METHOD0.</para>
		/// </summary>
		public IntPtr authenticationMethods;

		/// <summary>
		/// <para>Type of impersonation.</para>
		/// <para>See IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE initiatorImpersonationType;
	}

	/// <summary>
	/// The <c>IKEEXT_EM_POLICY1</c> structure is used to store AuthIP's extended mode negotiation policy. IKEEXT_EM_POLICY2 is available.
	/// For Windows Vista, IKEEXT_EM_POLICY0 is available.
	/// </summary>
	/// <remarks>Applies only to AuthIP.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_em_policy1 typedef struct IKEEXT_EM_POLICY1_ { UINT32
	// numAuthenticationMethods; IKEEXT_AUTHENTICATION_METHOD1 *authenticationMethods; IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE
	// initiatorImpersonationType; } IKEEXT_EM_POLICY1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_EM_POLICY1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_EM_POLICY1
	{
		/// <summary>Number of authentication methods in the array.</summary>
		public uint numAuthenticationMethods;

		/// <summary>
		/// <para>size_is(numAuthenticationMethods)</para>
		/// <para>Array of acceptable authentication methods as specified by IKEEXT_AUTHENTICATION_METHOD1.</para>
		/// </summary>
		public IntPtr authenticationMethods;

		/// <summary>
		/// <para>Type of impersonation.</para>
		/// <para>See IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE initiatorImpersonationType;
	}

	/// <summary>
	/// The <c>IKEEXT_EM_POLICY2</c> structure is used to store AuthIP's extended mode negotiation policy. IKEEXT_EM_POLICY0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_em_policy2 typedef struct IKEEXT_EM_POLICY2_ { UINT32
	// numAuthenticationMethods; IKEEXT_AUTHENTICATION_METHOD2 *authenticationMethods; IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE
	// initiatorImpersonationType; } IKEEXT_EM_POLICY2;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_EM_POLICY2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_EM_POLICY2
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of authentication methods in the array.</para>
		/// </summary>
		public uint numAuthenticationMethods;

		/// <summary>
		/// <para>Type: IKEEXT_AUTHENTICATION_METHOD2*</para>
		/// <para>size_is(numAuthenticationMethods)</para>
		/// <para>Array of acceptable authentication methods.</para>
		/// </summary>
		public IntPtr authenticationMethods;

		/// <summary>
		/// <para>Type: <c>IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE</c></para>
		/// <para>Type of impersonation.</para>
		/// </summary>
		public IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE initiatorImpersonationType;
	}

	/// <summary>The <c>IKEEXT_INTEGRITY_ALGORITHM0</c> structure stores the IKE/AuthIP hash algorithm.</summary>
	/// <remarks>
	/// <c>IKEEXT_INTEGRITY_ALGORITHM0</c> is a specific implementation of IKEEXT_INTEGRITY_ALGORITHM. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_integrity_algorithm0 typedef struct
	// IKEEXT_INTEGRITY_ALGORITHM0_ { IKEEXT_INTEGRITY_TYPE algoIdentifier; } IKEEXT_INTEGRITY_ALGORITHM0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_INTEGRITY_ALGORITHM0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_INTEGRITY_ALGORITHM0
	{
		/// <summary>
		/// <para>The type of hash algorithm.</para>
		/// <para>See IKEEXT_INTEGRITY_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_INTEGRITY_TYPE algoIdentifier;
	}

	/// <summary>
	/// The <c>IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS0</c> structure contains various statistics common to IKE and Authip.
	/// IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS1 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_ip_version_specific_common_statistics0 typedef struct
	// IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS0_ { UINT32 totalSocketReceiveFailures; UINT32 totalSocketSendFailures; } IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS0
	{
		/// <summary>Total number of UDP 500/4500 socket receive failures.</summary>
		public uint totalSocketReceiveFailures;

		/// <summary>Total number of UDP 500/4500 socket send failures.</summary>
		public uint totalSocketSendFailures;
	}

	/// <summary>
	/// The <c>IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS1</c> structure contains various statistics common to the keying module (IKE,
	/// Authip, and IKEv2). IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_ip_version_specific_common_statistics1 typedef struct
	// IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS1_ { UINT32 totalSocketReceiveFailures; UINT32 totalSocketSendFailures; } IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_IP_VERSION_SPECIFIC_COMMON_STATISTICS1
	{
		/// <summary>Total number of UDP 500/4500 socket receive failures.</summary>
		public uint totalSocketReceiveFailures;

		/// <summary>Total number of UDP 500/4500 socket send failures.</summary>
		public uint totalSocketSendFailures;
	}

	/// <summary>
	/// The <c>IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS0</c> structure contains various statistics specific to the keying module and
	/// IP version. IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS1 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_ip_version_specific_keymodule_statistics0 typedef
	// struct IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS0_ { UINT32 currentActiveMainModes; UINT32 totalMainModesStarted; UINT32
	// totalSuccessfulMainModes; UINT32 totalFailedMainModes; UINT32 totalResponderMainModes; UINT32 currentNewResponderMainModes; UINT32
	// currentActiveQuickModes; UINT32 totalQuickModesStarted; UINT32 totalSuccessfulQuickModes; UINT32 totalFailedQuickModes; UINT32
	// totalAcquires; UINT32 totalReinitAcquires; UINT32 currentActiveExtendedModes; UINT32 totalExtendedModesStarted; UINT32
	// totalSuccessfulExtendedModes; UINT32 totalFailedExtendedModes; UINT32 totalImpersonationExtendedModes; UINT32
	// totalImpersonationMainModes; } IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS0
	{
		/// <summary>Current number of active Main Mode SAs.</summary>
		public uint currentActiveMainModes;

		/// <summary>Total number of Main Mode negotiations.</summary>
		public uint totalMainModesStarted;

		/// <summary>Total number of successful Main Mode negotiations.</summary>
		public uint totalSuccessfulMainModes;

		/// <summary>Total number of failed Main Mode negotiations.</summary>
		public uint totalFailedMainModes;

		/// <summary>Total number of Main Mode negotiations that were externally initiated by a peer.</summary>
		public uint totalResponderMainModes;

		/// <summary>Current number of newly created responder Main Modes that are still in the initial state.</summary>
		public uint currentNewResponderMainModes;

		/// <summary>Current number of active Quick Mode SAs.</summary>
		public uint currentActiveQuickModes;

		/// <summary>Total number of Quick Mode negotiations.</summary>
		public uint totalQuickModesStarted;

		/// <summary>Total number of successful Quick Mode negotiations.</summary>
		public uint totalSuccessfulQuickModes;

		/// <summary>Total number of failed Quick Mode negotiations.</summary>
		public uint totalFailedQuickModes;

		/// <summary>Total number of acquires received from BFE.</summary>
		public uint totalAcquires;

		/// <summary>Total number of acquires that were internally reinitiated.</summary>
		public uint totalReinitAcquires;

		/// <summary>Current number of active extended mode SAs.</summary>
		public uint currentActiveExtendedModes;

		/// <summary>Total number of extended mode negotiations.</summary>
		public uint totalExtendedModesStarted;

		/// <summary>Total number of successful extended mode negotiations.</summary>
		public uint totalSuccessfulExtendedModes;

		/// <summary>Total number of failed extended mode negotiations.</summary>
		public uint totalFailedExtendedModes;

		/// <summary>Total number of successful extended mode negotiations that used impersonation.</summary>
		public uint totalImpersonationExtendedModes;

		/// <summary>Total number of successful Main Mode mode negotiations that used impersonation.</summary>
		public uint totalImpersonationMainModes;
	}

	/// <summary>
	/// <para>
	/// The <c>IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS1</c> structure contains various statistics specific to the keying module (IKE,
	/// Authip, and IKEv2) and IP version.
	/// </para>
	/// <para>
	/// <c>Note</c><c>IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS1</c> is the specific implementation of
	/// IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS used in Windows 7 and later. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information. For Windows Vista, IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS0 is available.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_ip_version_specific_keymodule_statistics1 typedef
	// struct IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS1_ { UINT32 currentActiveMainModes; UINT32 totalMainModesStarted; UINT32
	// totalSuccessfulMainModes; UINT32 totalFailedMainModes; UINT32 totalResponderMainModes; UINT32 currentNewResponderMainModes; UINT32
	// currentActiveQuickModes; UINT32 totalQuickModesStarted; UINT32 totalSuccessfulQuickModes; UINT32 totalFailedQuickModes; UINT32
	// totalAcquires; UINT32 totalReinitAcquires; UINT32 currentActiveExtendedModes; UINT32 totalExtendedModesStarted; UINT32
	// totalSuccessfulExtendedModes; UINT32 totalFailedExtendedModes; UINT32 totalImpersonationExtendedModes; UINT32
	// totalImpersonationMainModes; } IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS1
	{
		/// <summary>Current number of active Main Mode SAs.</summary>
		public uint currentActiveMainModes;

		/// <summary>Total number of Main Mode negotiations.</summary>
		public uint totalMainModesStarted;

		/// <summary>Total number of successful Main Mode negotiations.</summary>
		public uint totalSuccessfulMainModes;

		/// <summary>Total number of failed Main Mode negotiations.</summary>
		public uint totalFailedMainModes;

		/// <summary>Total number of Main Mode negotiations that were externally initiated by a peer.</summary>
		public uint totalResponderMainModes;

		/// <summary>Current number of newly created responder Main Modes that are still in the initial state.</summary>
		public uint currentNewResponderMainModes;

		/// <summary>Current number of active Quick Mode SAs.</summary>
		public uint currentActiveQuickModes;

		/// <summary>Total number of Quick Mode negotiations.</summary>
		public uint totalQuickModesStarted;

		/// <summary>Total number of successful Quick Mode negotiations.</summary>
		public uint totalSuccessfulQuickModes;

		/// <summary>Total number of failed Quick Mode negotiations.</summary>
		public uint totalFailedQuickModes;

		/// <summary>Total number of acquires received from BFE.</summary>
		public uint totalAcquires;

		/// <summary>Total number of acquires that were internally reinitiated.</summary>
		public uint totalReinitAcquires;

		/// <summary>Current number of active extended mode SAs.</summary>
		public uint currentActiveExtendedModes;

		/// <summary>Total number of extended mode negotiations.</summary>
		public uint totalExtendedModesStarted;

		/// <summary>Total number of successful extended mode negotiations.</summary>
		public uint totalSuccessfulExtendedModes;

		/// <summary>Total number of failed extended mode negotiations.</summary>
		public uint totalFailedExtendedModes;

		/// <summary>Total number of successful extended mode negotiations that used impersonation.</summary>
		public uint totalImpersonationExtendedModes;

		/// <summary>Total number of successful Main Mode mode negotiations that used impersonation.</summary>
		public uint totalImpersonationMainModes;
	}

	/// <summary>
	/// The <c>IKEEXT_IPV6_CGA_AUTHENTICATION0</c> structure is used to specify various parameters for IPV6 cryptographically generated
	/// address (CGA) authentication.
	/// </summary>
	/// <remarks>
	/// <c>IKEEXT_IPV6_CGA_AUTHENTICATION0</c> is a specific implementation of IKEEXT_IPV6_CGA_AUTHENTICATION. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_ipv6_cga_authentication0 typedef struct
	// IKEEXT_IPV6_CGA_AUTHENTICATION0_ { wchar_t *keyContainerName; wchar_t *cspName; UINT32 cspType; FWP_BYTE_ARRAY16 cgaModifier; BYTE
	// cgaCollisionCount; } IKEEXT_IPV6_CGA_AUTHENTICATION0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_IPV6_CGA_AUTHENTICATION0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_IPV6_CGA_AUTHENTICATION0
	{
		/// <summary>
		/// <para>Key container name of the public key/private key pair that was used to generate the CGA.</para>
		/// <para>Same semantics as the <c>pwszContainerName</c> member of the CRYPT_KEY_PROV_INFO structure.</para>
		/// </summary>
		public StrPtrUni keyContainerName;

		/// <summary>
		/// <para>Name of the CSP that stores the key container. If <c>NULL</c>, default provider will be used.</para>
		/// <para>Same semantics as the <c>pwszProvName</c> member of the CRYPT_KEY_PROV_INFO structure.</para>
		/// </summary>
		public StrPtrUni cspName;

		/// <summary>
		/// <para>Type of the CSP that stores the key container.</para>
		/// <para>Same semantics as the <c>dwProvType</c> member of the <see cref="Crypt32.CRYPT_KEY_PROV_INFO"/> structure.</para>
		/// </summary>
		public uint cspType;

		/// <summary>
		/// <para>A FWP_BYTE_ARRAY16 structure containing a modifier used during CGA generation.</para>
		/// <para>See CGA RFC for more information.</para>
		/// </summary>
		public FWP_BYTE_ARRAY16 cgaModifier;

		/// <summary>
		/// <para>Collision count used during CGA generation.</para>
		/// <para>See CGA RFC for more information.</para>
		/// </summary>
		public byte cgaCollisionCount;
	}

	/// <summary>
	/// The <c>IKEEXT_KERBEROS_AUTHENTICATION0</c> structure contains information needed for preshared key authentication.
	/// IKEEXT_KERBEROS_AUTHENTICATION1 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_kerberos_authentication0 typedef struct
	// IKEEXT_KERBEROS_AUTHENTICATION0__ { UINT32 flags; } IKEEXT_KERBEROS_AUTHENTICATION0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_KERBEROS_AUTHENTICATION0__")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_KERBEROS_AUTHENTICATION0
	{
		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Kerberos authentication flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IKEEXT_KERB_AUTH_DISABLE_INITIATOR_TOKEN_GENERATION</c></term>
		/// <term>Disable initiator generation of peer token from the peer's name string.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_KERB_AUTH_DONT_ACCEPT_EXPLICIT_CREDENTIALS</c></term>
		/// <term>Refuse connections if the peer is using explicit credentials. Applicable only to AuthIP.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IKEEXT_KERB_AUTH flags;
	}

	/// <summary>
	/// The <c>IKEEXT_KERBEROS_AUTHENTICATION1</c> structure contains information needed for preshared key authentication.
	/// IKEEXT_KERBEROS_AUTHENTICATION0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_kerberos_authentication1 typedef struct
	// IKEEXT_KERBEROS_AUTHENTICATION1__ { UINT32 flags; wchar_t *proxyServer; } IKEEXT_KERBEROS_AUTHENTICATION1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_KERBEROS_AUTHENTICATION1__")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_KERBEROS_AUTHENTICATION1
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Kerberos authentication flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IKEEXT_KERB_AUTH_DISABLE_INITIATOR_TOKEN_GENERATION</c></term>
		/// <term>Disable initiator generation of peer token from the peer's name string.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_KERB_AUTH_DONT_ACCEPT_EXPLICIT_CREDENTIALS</c></term>
		/// <term>Refuse connections if the peer is using explicit credentials. Applicable only to AuthIP.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_KERB_AUTH_FORCE_PROXY_ON_INITIATOR</c></term>
		/// <term>Force the use of a Kerberos proxy server when acting as initiator.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IKEEXT_KERB_AUTH flags;

		/// <summary>
		/// <para>Type: <c>wchar_t*</c></para>
		/// <para>The Kerberos proxy server.</para>
		/// </summary>
		public StrPtrUni proxyServer;
	}

	/// <summary>
	/// The <c>IKEEXT_KEYMODULE_STATISTICS0</c> structure contains various statistics specific to the keying module.
	/// IKEEXT_KEYMODULE_STATISTICS1 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_keymodule_statistics0 typedef struct
	// IKEEXT_KEYMODULE_STATISTICS0_ { IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS0 v4Statistics;
	// IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS0 v6Statistics; UINT32 errorFrequencyTable[97]; UINT32 mainModeNegotiationTime; UINT32
	// quickModeNegotiationTime; UINT32 extendedModeNegotiationTime; } IKEEXT_KEYMODULE_STATISTICS0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_KEYMODULE_STATISTICS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_KEYMODULE_STATISTICS0
	{
		/// <summary>
		/// <para>IPv4 common statistics.</para>
		/// <para>See IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS0 for more information.</para>
		/// </summary>
		public IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS0 v4Statistics;

		/// <summary>
		/// <para>IPv6 common statistics.</para>
		/// <para>See IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS0 for more information.</para>
		/// </summary>
		public IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS0 v6Statistics;

		/// <summary>
		/// <para>
		/// Table containing the frequencies of various IKE Win32 error codes encountered during negotiations. The error codes range from
		/// ERROR_IPSEC_IKE_NEG_STATUS_BEGIN to ERROR_IPSEC_IKE_NEG_STATUS_END.
		/// </para>
		/// <para>The table size, IKEEXT_ERROR_CODE_COUNT, is 84 (ERROR_IPSEC_IKE_NEG_STATUS_END - ERROR_IPSEC_IKE_NEG_STATUS_BEGIN).</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 97)]
		public uint[] errorFrequencyTable;

		/// <summary>Current Main Mode negotiation time.</summary>
		public uint mainModeNegotiationTime;

		/// <summary>Current Quick Mode negotiation time.</summary>
		public uint quickModeNegotiationTime;

		/// <summary>Current Extended Mode negotiation time. This member is applicable for Authip only.</summary>
		public uint extendedModeNegotiationTime;
	}

	/// <summary>
	/// The <c>IKEEXT_KEYMODULE_STATISTICS1</c> structure contains various statistics specific to the keying module.
	/// IKEEXT_KEYMODULE_STATISTICS0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_keymodule_statistics1 typedef struct
	// IKEEXT_KEYMODULE_STATISTICS1_ { IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS1 v4Statistics;
	// IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS1 v6Statistics; UINT32 errorFrequencyTable[97]; UINT32 mainModeNegotiationTime; UINT32
	// quickModeNegotiationTime; UINT32 extendedModeNegotiationTime; } IKEEXT_KEYMODULE_STATISTICS1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_KEYMODULE_STATISTICS1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_KEYMODULE_STATISTICS1
	{
		/// <summary>
		/// <para>IPv4 common statistics.</para>
		/// <para>See IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS1 for more information.</para>
		/// </summary>
		public IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS1 v4Statistics;

		/// <summary>
		/// <para>IPv6 common statistics.</para>
		/// <para>See IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS1 for more information.</para>
		/// </summary>
		public IKEEXT_IP_VERSION_SPECIFIC_KEYMODULE_STATISTICS1 v6Statistics;

		/// <summary>
		/// <para>
		/// Table containing the frequencies of various IKE Win32 error codes encountered during negotiations. The error codes range from
		/// ERROR_IPSEC_IKE_NEG_STATUS_BEGIN to ERROR_IPSEC_IKE_NEG_STATUS_END.
		/// </para>
		/// <para>The table size, IKEEXT_ERROR_CODE_COUNT, is 84 (ERROR_IPSEC_IKE_NEG_STATUS_END - ERROR_IPSEC_IKE_NEG_STATUS_BEGIN).</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 97)]
		public uint[] errorFrequencyTable;

		/// <summary>Current Main Mode negotiation time.</summary>
		public uint mainModeNegotiationTime;

		/// <summary>Current Quick Mode negotiation time.</summary>
		public uint quickModeNegotiationTime;

		/// <summary>Current Extended Mode negotiation time. This member is applicable for AuthIp only.</summary>
		public uint extendedModeNegotiationTime;
	}

	/// <summary>The <c>IKEEXT_NAME_CREDENTIAL0</c> structure is used to store credential name information.</summary>
	/// <remarks>
	/// <c>IKEEXT_NAME_CREDENTIAL0</c> is a specific implementation of IKEEXT_NAME_CREDENTIAL. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_name_credential0 typedef struct
	// IKEEXT_NAME_CREDENTIAL0_ { wchar_t *principalName; } IKEEXT_NAME_CREDENTIAL0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_NAME_CREDENTIAL0_")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct IKEEXT_NAME_CREDENTIAL0
	{
		/// <summary>Name of the principal.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string principalName;
	}

	/// <summary>
	/// The <c>IKEEXT_NTLM_V2_AUTHENTICATION0</c> structure contains information needed for Microsoft Windows NT LAN Manager (NTLM) V2 authentication.
	/// </summary>
	/// <remarks>
	/// <c>IKEEXT_NTLM_V2_AUTHENTICATION0</c> is a specific implementation of IKEEXT_NTLM_V2_AUTHENTICATION. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_ntlm_v2_authentication0 typedef struct
	// IKEEXT_NTLM_V2_AUTHENTICATION0__ { UINT32 flags; } IKEEXT_NTLM_V2_AUTHENTICATION0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_NTLM_V2_AUTHENTICATION0__")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_NTLM_V2_AUTHENTICATION0
	{
		/// <summary>
		/// <para>Possible value:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>NTLM authentication flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IKEEXT_NTLM_V2_AUTH_DONT_ACCEPT_EXPLICIT_CREDENTIALS</c></term>
		/// <term>Refuse connections if the peer is using explicit credentials.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IKEEXT_NTLM_V2_AUTH flags;
	}

	/// <summary>
	/// The <c>IKEEXT_POLICY0</c> structure is used to store the IKE/AuthIP main mode negotiation policy. IKEEXT_POLICY1 is available. For
	/// Windows 8, IKEEXT_POLICY2 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_policy0 typedef struct IKEEXT_POLICY0_ { UINT32
	// softExpirationTime; UINT32 numAuthenticationMethods; IKEEXT_AUTHENTICATION_METHOD0 *authenticationMethods;
	// IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE initiatorImpersonationType; UINT32 numIkeProposals; IKEEXT_PROPOSAL0 *ikeProposals; UINT32
	// flags; UINT32 maxDynamicFilters; } IKEEXT_POLICY0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_POLICY0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_POLICY0
	{
		/// <summary>Unused parameter, always set this to 0.</summary>
		public uint softExpirationTime;

		/// <summary>Number of authentication methods.</summary>
		public uint numAuthenticationMethods;

		/// <summary>
		/// <para>Array of acceptable authentication methods.</para>
		/// <para>See IKEEXT_AUTHENTICATION_METHOD0 for more information.</para>
		/// </summary>
		public IntPtr authenticationMethods;

		/// <summary>
		/// <para>Type of impersonation. Applies only to AuthIP.</para>
		/// <para>See IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE initiatorImpersonationType;

		/// <summary>Number of main mode proposals.</summary>
		public uint numIkeProposals;

		/// <summary>
		/// <para>Array of main mode proposals.</para>
		/// <para>See IKEEXT_PROPOSAL0 for more information.</para>
		/// </summary>
		public IntPtr ikeProposals;

		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IKE/AuthIP policy flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IKEEXT_POLICY_FLAG_DISABLE_DIAGNOSTICS</c></term>
		/// <term>
		/// Disable special diagnostics mode for IKE/Authip. This will prevent IKE/AuthIp from accepting unauthenticated notifications from
		/// peer, or sending MS_STATUS notifications to peer.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_POLICY_FLAG_NO_MACHINE_LUID_VERIFY</c></term>
		/// <term>Disable SA verification of machine LUID.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_POLICY_FLAG_NO_IMPERSONATION_LUID_VERIFY</c></term>
		/// <term>Disable SA verification of machine impersonation LUID. Applicable only to AuthIP.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_POLICY_FLAG_ENABLE_OPTIONAL_DH</c></term>
		/// <term>
		/// Allow the responder to accept any DH proposal, including no DH, regardless of what is configured in policy. Applicable only to AuthIP.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public IKEEXT_POLICY_FLAG flags;

		/// <summary>
		/// <para>
		/// Maximum number of dynamic IPsec filters per remote IP address and per transport layer that is allowed to be added for any SA
		/// negotiated using this policy.
		/// </para>
		/// <para>
		/// Set this to 0 to disable dynamic filter addition. Dynamic filters are added by IKE/AuthIP on responder, when the QM traffic
		/// proposed by initiator is a subset of responder's traffic configuration.
		/// </para>
		/// </summary>
		public uint maxDynamicFilters;
	}

	/// <summary>The <c>IKEEXT_POLICY1</c> structure is used to store the IKE/AuthIP main mode negotiation policy. IKEEXT_POLICY0 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_policy1 typedef struct IKEEXT_POLICY1_ { UINT32
	// softExpirationTime; UINT32 numAuthenticationMethods; IKEEXT_AUTHENTICATION_METHOD1 *authenticationMethods;
	// IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE initiatorImpersonationType; UINT32 numIkeProposals; IKEEXT_PROPOSAL0 *ikeProposals; UINT32
	// flags; UINT32 maxDynamicFilters; UINT32 retransmitDurationSecs; } IKEEXT_POLICY1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_POLICY1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_POLICY1
	{
		/// <summary>Lifetime of the IPsec soft SA, in seconds. The caller must set this to 0.</summary>
		public uint softExpirationTime;

		/// <summary>Number of authentication methods.</summary>
		public uint numAuthenticationMethods;

		/// <summary>
		/// <para>Array of acceptable authentication methods.</para>
		/// <para>See IKEEXT_AUTHENTICATION_METHOD1 for more information.</para>
		/// </summary>
		public IntPtr authenticationMethods;

		/// <summary>
		/// <para>Type of impersonation. Applies only to AuthIP.</para>
		/// <para>See IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE initiatorImpersonationType;

		/// <summary>Number of main mode proposals.</summary>
		public uint numIkeProposals;

		/// <summary>
		/// <para>Array of main mode proposals.</para>
		/// <para>See IKEEXT_PROPOSAL0 for more information.</para>
		/// </summary>
		public IntPtr ikeProposals;

		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IKE/AuthIP policy flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IKEEXT_POLICY_FLAG_DISABLE_DIAGNOSTICS</c></term>
		/// <term>
		/// Disable special diagnostics mode for IKE/Authip. This will prevent IKE/AuthIp from accepting unauthenticated notifications from
		/// peer, or sending MS_STATUS notifications to peer.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_POLICY_FLAG_NO_MACHINE_LUID_VERIFY</c></term>
		/// <term>Disable SA verification of machine LUID.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_POLICY_FLAG_NO_IMPERSONATION_LUID_VERIFY</c></term>
		/// <term>Disable SA verification of machine impersonation LUID.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_POLICY_FLAG_ENABLE_OPTIONAL_DH</c></term>
		/// <term>
		/// Allow the responder to accept any DH proposal, including no DH, regardless of what is configured in policy. This flag is valid
		/// only if AuthIP is used.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public IKEEXT_POLICY_FLAG flags;

		/// <summary>
		/// <para>
		/// Maximum number of dynamic IPsec filters per remote IP address and per transport layer that is allowed to be added for any SA
		/// negotiated using this policy.
		/// </para>
		/// <para>
		/// Set this to 0 to disable dynamic filter addition. Dynamic filters are added by IKE/AuthIP on responder, when the QM traffic
		/// proposed by initiator is a subset of responder's traffic configuration.
		/// </para>
		/// </summary>
		public uint maxDynamicFilters;

		/// <summary>
		/// The number of seconds for which IKEv2 SA negotiation packets will be retransmitted before the SA times out. The caller must set
		/// this to at least 120 seconds.
		/// </summary>
		public uint retransmitDurationSecs;
	}

	/// <summary>The <c>IKEEXT_POLICY2</c> structure is used to store the IKE/AuthIP main mode negotiation policy. IKEEXT_POLICY0 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_policy2 typedef struct IKEEXT_POLICY2_ { UINT32
	// softExpirationTime; UINT32 numAuthenticationMethods; IKEEXT_AUTHENTICATION_METHOD2 *authenticationMethods;
	// IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE initiatorImpersonationType; UINT32 numIkeProposals; IKEEXT_PROPOSAL0 *ikeProposals; UINT32
	// flags; UINT32 maxDynamicFilters; UINT32 retransmitDurationSecs; } IKEEXT_POLICY2;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_POLICY2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_POLICY2
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Lifetime of the IPsec soft SA, in seconds. The caller must set this to 0.</para>
		/// </summary>
		public uint softExpirationTime;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of authentication methods.</para>
		/// </summary>
		public uint numAuthenticationMethods;

		/// <summary>
		/// <para>Type: IKEEXT_AUTHENTICATION_METHOD2*</para>
		/// <para>Array of acceptable authentication methods.</para>
		/// </summary>
		public IntPtr authenticationMethods;

		/// <summary>
		/// <para>Type: <c>IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE</c></para>
		/// <para>Type of impersonation. Applies only to AuthIP.</para>
		/// </summary>
		public IKEEXT_AUTHENTICATION_IMPERSONATION_TYPE initiatorImpersonationType;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Number of main mode proposals.</para>
		/// </summary>
		public uint numIkeProposals;

		/// <summary>
		/// <para>Type: IKEEXT_PROPOSAL0*</para>
		/// <para>Array of main mode proposals.</para>
		/// </summary>
		public IntPtr ikeProposals;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>IKE/AuthIP policy flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IKEEXT_POLICY_FLAG_DISABLE_DIAGNOSTICS</c></term>
		/// <term>
		/// Disable special diagnostics mode for IKE/Authip. This will prevent IKE/AuthIp from accepting unauthenticated notifications from
		/// peer, or sending MS_STATUS notifications to peer.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_POLICY_FLAG_NO_MACHINE_LUID_VERIFY</c></term>
		/// <term>Disable SA verification of machine LUID.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_POLICY_FLAG_NO_IMPERSONATION_LUID_VERIFY</c></term>
		/// <term>Disable SA verification of machine impersonation LUID.</term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_POLICY_FLAG_ENABLE_OPTIONAL_DH</c></term>
		/// <term>
		/// Allow the responder to accept any DH proposal, including no DH, regardless of what is configured in policy. This flag is valid
		/// only if AuthIP is used.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public IKEEXT_POLICY_FLAG flags;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// Maximum number of dynamic IPsec filters per remote IP address and per transport layer that is allowed to be added for any SA
		/// negotiated using this policy.
		/// </para>
		/// <para>
		/// Set this to 0 to disable dynamic filter addition. Dynamic filters are added by IKE/AuthIP on responder, when the QM traffic
		/// proposed by initiator is a subset of responder's traffic configuration.
		/// </para>
		/// </summary>
		public uint maxDynamicFilters;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The number of seconds for which IKEv2 SA negotiation packets will be retransmitted before the SA times out. The caller must set
		/// this to at least 120 seconds.
		/// </para>
		/// </summary>
		public uint retransmitDurationSecs;
	}

	/// <summary>
	/// The <c>IKEEXT_PRESHARED_KEY_AUTHENTICATION0</c> structure stores information needed for pre-shared key authentication.
	/// IKEEXT_PRESHARED_KEY_AUTHENTICATION1 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_preshared_key_authentication0 typedef struct
	// IKEEXT_PRESHARED_KEY_AUTHENTICATION0__ { FWP_BYTE_BLOB presharedKey; } IKEEXT_PRESHARED_KEY_AUTHENTICATION0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_PRESHARED_KEY_AUTHENTICATION0__")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_PRESHARED_KEY_AUTHENTICATION0
	{
		/// <summary>The pre-shared key specified by FWP_BYTE_BLOB.</summary>
		public FWP_BYTE_BLOB presharedKey;
	}

	/// <summary>
	/// The <c>IKEEXT_PRESHARED_KEY_AUTHENTICATION1</c> structure stores information needed for pre-shared key authentication.
	/// IKEEXT_PRESHARED_KEY_AUTHENTICATION0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_preshared_key_authentication1 typedef struct
	// IKEEXT_PRESHARED_KEY_AUTHENTICATION1__ { FWP_BYTE_BLOB presharedKey; UINT32 flags; } IKEEXT_PRESHARED_KEY_AUTHENTICATION1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_PRESHARED_KEY_AUTHENTICATION1__")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_PRESHARED_KEY_AUTHENTICATION1
	{
		/// <summary>The pre-shared key specified by FWP_BYTE_BLOB.</summary>
		public FWP_BYTE_BLOB presharedKey;

		/// <summary>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Pre-shared key authentication flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IKEEXT_PSK_FLAG_LOCAL_AUTH_ONLY</c></term>
		/// <term>
		/// Specifies that the pre-shared key authentication will be used only to authenticate a local computer to a remote computer.
		/// Applicable only to IKEv2.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>IKEEXT_PSK_FLAG_REMOTE_AUTH_ONLY</c></term>
		/// <term>
		/// Specifies that the pre-shared key authentication will be used only to authenticate a remote computer to a local computer.
		/// Applicable only to IKEv2.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public IKEEXT_PSK_FLAG flags;
	}

	/// <summary>The <c>IKEEXT_PROPOSAL0</c> structure is used to store an IKE/AuthIP main mode proposal.</summary>
	/// <remarks>
	/// <para>The proposal describes the various parameters of the IKE/AuthIP main mode SA that is potentially generated from this proposal.</para>
	/// <para>
	/// <c>IKEEXT_PROPOSAL0</c> is a specific implementation of IKEEXT_PROPOSAL. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_proposal0 typedef struct IKEEXT_PROPOSAL0_ {
	// IKEEXT_CIPHER_ALGORITHM0 cipherAlgorithm; IKEEXT_INTEGRITY_ALGORITHM0 integrityAlgorithm; UINT32 maxLifetimeSeconds; IKEEXT_DH_GROUP
	// dhGroup; UINT32 quickModeLimit; } IKEEXT_PROPOSAL0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_PROPOSAL0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_PROPOSAL0
	{
		/// <summary>Parameters for the encryption algorithm specified by IKEEXT_CIPHER_ALGORITHM0.</summary>
		public IKEEXT_CIPHER_ALGORITHM0 cipherAlgorithm;

		/// <summary>Parameters for the hash algorithm specified by IKEEXT_INTEGRITY_ALGORITHM0.</summary>
		public IKEEXT_INTEGRITY_ALGORITHM0 integrityAlgorithm;

		/// <summary>Main mode security association (SA) lifetime in seconds.</summary>
		public uint maxLifetimeSeconds;

		/// <summary>The Diffie Hellman group specified by IKEEXT_DH_GROUP.</summary>
		public IKEEXT_DH_GROUP dhGroup;

		/// <summary>Maximum number of IPsec quick mode SAs that can be generated from this main mode SA. 0 (zero) means infinite.</summary>
		public uint quickModeLimit;
	}

	/// <summary>The <c>IKEEXT_RESERVED_AUTHENTICATION0</c> structure is reserved for internal use. Do not use.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_reserved_authentication0 typedef struct
	// IKEEXT_RESERVED_AUTHENTICATION0__ { UINT32 flags; } IKEEXT_RESERVED_AUTHENTICATION0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_RESERVED_AUTHENTICATION0__")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_RESERVED_AUTHENTICATION0
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>A combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IKEEXT_RESERVED_AUTH_DISABLE_INITIATOR_TOKEN_GENERATION</c></term>
		/// <term>Reserved for internal use.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IKEEXT_RESERVED_AUTH flags;
	}

	/// <summary>
	/// The <c>IKEEXT_SA_DETAILS0</c> structure is used to store information returned when enumerating IKE, AuthIP, or IKEv2 security
	/// associations (SAs). IKEEXT_SA_DETAILS2 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_sa_details0 typedef struct IKEEXT_SA_DETAILS0_ { UINT64
	// saId; IKEEXT_KEY_MODULE_TYPE keyModuleType; FWP_IP_VERSION ipVersion; union { IPSEC_V4_UDP_ENCAPSULATION0 *v4UdpEncapsulation; };
	// IKEEXT_TRAFFIC0 ikeTraffic; IKEEXT_PROPOSAL0 ikeProposal; IKEEXT_COOKIE_PAIR0 cookiePair; IKEEXT_CREDENTIALS0 ikeCredentials; GUID
	// ikePolicyKey; UINT64 virtualIfTunnelId; } IKEEXT_SA_DETAILS0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_SA_DETAILS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_SA_DETAILS0
	{
		/// <summary>LUID identifying the security association.</summary>
		public ulong saId;

		/// <summary>
		/// <para>Key module type.</para>
		/// <para>See IKEEXT_KEY_MODULE_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_KEY_MODULE_TYPE keyModuleType;

		/// <summary>IP version specified by FWP_IP_VERSION.</summary>
		public FWP_IP_VERSION ipVersion;

		/// <summary>
		/// <para>
		/// Points to an IPSEC_V4_UDP_ENCAPSULATION0 structure, which, if a NAT is detected, stores the UDP ports corresponding to the Main Mode.
		/// </para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IntPtr v4UdpEncapsulation;

		/// <summary>The traffic corresponding to this IKE SA specified by IKEEXT_TRAFFIC0.</summary>
		public IKEEXT_TRAFFIC0 ikeTraffic;

		/// <summary>The main mode proposal corresponding to this IKE SA specified by IKEEXT_PROPOSAL0.</summary>
		public IKEEXT_PROPOSAL0 ikeProposal;

		/// <summary>SA cookies specified by IKEEXT_COOKIE_PAIR0.</summary>
		public IKEEXT_COOKIE_PAIR0 cookiePair;

		/// <summary>Credentials information for the SA specified by IKEEXT_CREDENTIALS0.</summary>
		public IKEEXT_CREDENTIALS0 ikeCredentials;

		/// <summary>GUID of the main mode policy provider context corresponding to this SA.</summary>
		public Guid ikePolicyKey;

		/// <summary>
		/// <para>ID/Handle to virtual interface tunneling state.</para>
		/// <para>Applicable only to IKEv2.</para>
		/// <para>Available only on Windows 7, Windows Server 2008 R2, and later.</para>
		/// </summary>
		public ulong virtualIfTunnelId;
	}

	/// <summary>
	/// The <c>IKEEXT_SA_DETAILS1</c> structure is used to store information returned when enumerating IKE, AuthIP, and IKEv2 security
	/// associations (SAs). IKEEXT_SA_DETAILS0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_sa_details1 typedef struct IKEEXT_SA_DETAILS1_ { UINT64
	// saId; IKEEXT_KEY_MODULE_TYPE keyModuleType; FWP_IP_VERSION ipVersion; union { IPSEC_V4_UDP_ENCAPSULATION0 *v4UdpEncapsulation; };
	// IKEEXT_TRAFFIC0 ikeTraffic; IKEEXT_PROPOSAL0 ikeProposal; IKEEXT_COOKIE_PAIR0 cookiePair; IKEEXT_CREDENTIALS1 ikeCredentials; GUID
	// ikePolicyKey; UINT64 virtualIfTunnelId; FWP_BYTE_BLOB correlationKey; } IKEEXT_SA_DETAILS1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_SA_DETAILS1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_SA_DETAILS1
	{
		/// <summary>LUID identifying the security association.</summary>
		public ulong saId;

		/// <summary>
		/// <para>Key module type.</para>
		/// <para>See IKEEXT_KEY_MODULE_TYPE for more information.</para>
		/// </summary>
		public IKEEXT_KEY_MODULE_TYPE keyModuleType;

		/// <summary>IP version specified by FWP_IP_VERSION.</summary>
		public FWP_IP_VERSION ipVersion;

		/// <summary>
		/// <para>
		/// Points to an IPSEC_V4_UDP_ENCAPSULATION0 structure, which, if a NAT is detected, stores the UDP ports corresponding to the Main Mode.
		/// </para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IntPtr v4UdpEncapsulation;

		/// <summary>The traffic corresponding to this IKE SA specified by IKEEXT_TRAFFIC0.</summary>
		public IKEEXT_TRAFFIC0 ikeTraffic;

		/// <summary>The main mode proposal corresponding to this IKE SA specified by IKEEXT_PROPOSAL0.</summary>
		public IKEEXT_PROPOSAL0 ikeProposal;

		/// <summary>SA cookies specified by IKEEXT_COOKIE_PAIR0.</summary>
		public IKEEXT_COOKIE_PAIR0 cookiePair;

		/// <summary>Credentials information for the SA specified by IKEEXT_CREDENTIALS1.</summary>
		public IKEEXT_CREDENTIALS1 ikeCredentials;

		/// <summary>GUID of the main mode policy provider context corresponding to this SA.</summary>
		public Guid ikePolicyKey;

		/// <summary>ID/Handle to virtual interface tunneling state. Applicable only to IKEv2.</summary>
		public ulong virtualIfTunnelId;

		/// <summary/>
		public FWP_BYTE_BLOB correlationKey;
	}

	/// <summary>
	/// The <c>IKEEXT_SA_DETAILS2</c> structure is used to store information returned when enumerating IKE, AuthIP, and IKEv2 security
	/// associations (SAs). IKEEXT_SA_DETAILS1 is available. For Windows Vista, IKEEXT_SA_DETAILS0 is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_sa_details2 typedef struct IKEEXT_SA_DETAILS2_ { UINT64
	// saId; IKEEXT_KEY_MODULE_TYPE keyModuleType; FWP_IP_VERSION ipVersion; union { IPSEC_V4_UDP_ENCAPSULATION0 *v4UdpEncapsulation; };
	// IKEEXT_TRAFFIC0 ikeTraffic; IKEEXT_PROPOSAL0 ikeProposal; IKEEXT_COOKIE_PAIR0 cookiePair; IKEEXT_CREDENTIALS2 ikeCredentials; GUID
	// ikePolicyKey; UINT64 virtualIfTunnelId; FWP_BYTE_BLOB correlationKey; } IKEEXT_SA_DETAILS2;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_SA_DETAILS2_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_SA_DETAILS2
	{
		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>LUID identifying the security association.</para>
		/// </summary>
		public ulong saId;

		/// <summary>
		/// <para>Type: IKEEXT_KEY_MODULE_TYPE</para>
		/// <para>Key module type.</para>
		/// </summary>
		public IKEEXT_KEY_MODULE_TYPE keyModuleType;

		/// <summary>
		/// <para>Type: FWP_IP_VERSION</para>
		/// <para>The IP version.</para>
		/// </summary>
		public FWP_IP_VERSION ipVersion;

		/// <summary>
		/// <para>Type: IPSEC_V4_UDP_ENCAPSULATION0*</para>
		/// <para>Stores the UDP ports corresponding to the Main Mode, if a NAT is detected.</para>
		/// <para>Available when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IntPtr v4UdpEncapsulation;

		/// <summary>
		/// <para>Type: IKEEXT_TRAFFIC0</para>
		/// <para>The traffic corresponding to this IKE SA.</para>
		/// </summary>
		public IKEEXT_TRAFFIC0 ikeTraffic;

		/// <summary>
		/// <para>Type: IKEEXT_PROPOSAL0</para>
		/// <para>The main mode proposal corresponding to this IKE SA.</para>
		/// </summary>
		public IKEEXT_PROPOSAL0 ikeProposal;

		/// <summary>
		/// <para>Type: IKEEXT_COOKIE_PAIR0</para>
		/// <para>The SA cookies.</para>
		/// </summary>
		public IKEEXT_COOKIE_PAIR0 cookiePair;

		/// <summary>
		/// <para>Type: IKEEXT_CREDENTIALS2</para>
		/// <para>Credentials information for the SA.</para>
		/// </summary>
		public IKEEXT_CREDENTIALS2 ikeCredentials;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>GUID of the main mode policy provider context corresponding to this SA.</para>
		/// </summary>
		public Guid ikePolicyKey;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>ID/Handle to virtual interface tunneling state. Applicable only to IKEv2.</para>
		/// </summary>
		public ulong virtualIfTunnelId;

		/// <summary>
		/// <para>Type: FWP_BYTE_BLOB</para>
		/// <para>Key derived from authentications to allow external applications to cryptographically bind their exchanges with this SA.</para>
		/// </summary>
		public FWP_BYTE_BLOB correlationKey;
	}

	/// <summary>
	/// The <c>IKEEXT_SA_ENUM_TEMPLATE0</c> structure is an enumeration template used for enumerating IKE/AuthIP security associations (SAs).
	/// </summary>
	/// <remarks>
	/// <c>IKEEXT_SA_ENUM_TEMPLATE0</c> is a specific implementation of IKEEXT_SA_ENUM_TEMPLATE. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_sa_enum_template0 typedef struct
	// IKEEXT_SA_ENUM_TEMPLATE0_ { FWP_CONDITION_VALUE0 localSubNet; FWP_CONDITION_VALUE0 remoteSubNet; FWP_BYTE_BLOB localMainModeCertHash;
	// } IKEEXT_SA_ENUM_TEMPLATE0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_SA_ENUM_TEMPLATE0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_SA_ENUM_TEMPLATE0
	{
		/// <summary>
		/// <para>Matches SAs whose local address is on the specified subnet. Must be of one of the following types.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>FWP_UINT32</term>
		/// </item>
		/// <item>
		/// <term>FWP_BYTE_ARRAY16_TYPE</term>
		/// </item>
		/// <item>
		/// <term>FWP_V4_ADDR_MASK</term>
		/// </item>
		/// <item>
		/// <term>FWP_V6_ADDR_MASK</term>
		/// </item>
		/// </list>
		/// <para>See [FWP_CONDITION_VALUE0](/windows/desktop/api/fwptypes/ns-fwptypes-fwp_condition_value0) for more information.</para>
		/// </summary>
		public FWP_CONDITION_VALUE0 localSubNet;

		/// <summary>
		/// <para>Matches SAs whose remote address is on the specified subnet. Must be of one of the following types.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>FWP_UINT32</term>
		/// </item>
		/// <item>
		/// <term>FWP_BYTE_ARRAY16_TYPE</term>
		/// </item>
		/// <item>
		/// <term>FWP_V4_ADDR_MASK</term>
		/// </item>
		/// <item>
		/// <term>FWP_V6_ADDR_MASK</term>
		/// </item>
		/// </list>
		/// <para>See [FWP_CONDITION_VALUE0](/windows/desktop/api/fwptypes/ns-fwptypes-fwp_condition_value0) for more information.</para>
		/// </summary>
		public FWP_CONDITION_VALUE0 remoteSubNet;

		/// <summary>
		/// <para>Matches SAs with a matching local main mode SHA thumbprint. If none exist, this member will have a length of zero.</para>
		/// <para>See FWP_BYTE_BLOB for more information.</para>
		/// </summary>
		public FWP_BYTE_BLOB localMainModeCertHash;
	}

	/// <summary>The <c>IKEEXT_STATISTICS0</c> structure stores various IKE/AuthIP statistics. IKEEXT_STATISTICS1 is available.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_statistics0 typedef struct IKEEXT_STATISTICS0_ {
	// IKEEXT_KEYMODULE_STATISTICS0 ikeStatistics; IKEEXT_KEYMODULE_STATISTICS0 authipStatistics; IKEEXT_COMMON_STATISTICS0 commonStatistics;
	// } IKEEXT_STATISTICS0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_STATISTICS0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_STATISTICS0
	{
		/// <summary>
		/// <para>Statistics specific to IKE.</para>
		/// <para>See IKEEXT_KEYMODULE_STATISTICS0 for more information.</para>
		/// </summary>
		public IKEEXT_KEYMODULE_STATISTICS0 ikeStatistics;

		/// <summary>
		/// <para>Statistics specific to AuthIP.</para>
		/// <para>See IKEEXT_KEYMODULE_STATISTICS0 for more information.</para>
		/// </summary>
		public IKEEXT_KEYMODULE_STATISTICS0 authipStatistics;

		/// <summary>
		/// <para>Statistics common to IKE and AuthIP.</para>
		/// <para>See IKEEXT_COMMON_STATISTICS0 for more information.</para>
		/// </summary>
		public IKEEXT_COMMON_STATISTICS0 commonStatistics;
	}

	/// <summary>
	/// The IKEEXT_STATISTICS1 structure stores various IKE, AuthIP, and IKEv2 statistics. IKEEXT_STATISTICS1 is the specific implementation
	/// of IKEEXT_STATISTICS used in Windows 7 and later. See WFP Version-Independent Names and Targeting Specific Versions of Windows for
	/// more information. For Windows Vista, <c>IKEEXT_STATISTICS0</c> is available.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_statistics1 typedef struct IKEEXT_STATISTICS1_ {
	// IKEEXT_KEYMODULE_STATISTICS1 ikeStatistics; IKEEXT_KEYMODULE_STATISTICS1 authipStatistics; IKEEXT_KEYMODULE_STATISTICS1
	// ikeV2Statistics; IKEEXT_COMMON_STATISTICS1 commonStatistics; } IKEEXT_STATISTICS1;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_STATISTICS1_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_STATISTICS1
	{
		/// <summary>
		/// <para>Statistics specific to IKE.</para>
		/// <para>See IKEEXT_KEYMODULE_STATISTICS1 for more information.</para>
		/// </summary>
		public IKEEXT_KEYMODULE_STATISTICS1 ikeStatistics;

		/// <summary>
		/// <para>Statistics specific to AuthIP.</para>
		/// <para>See IKEEXT_KEYMODULE_STATISTICS1 for more information.</para>
		/// </summary>
		public IKEEXT_KEYMODULE_STATISTICS1 authipStatistics;

		/// <summary>
		/// <para>Statistics specific to IKEv2.</para>
		/// <para>See IKEEXT_KEYMODULE_STATISTICS1 for more information.</para>
		/// </summary>
		public IKEEXT_KEYMODULE_STATISTICS1 ikeV2Statistics;

		/// <summary>
		/// <para>Statistics common to IKE, AuthIP, and IKEv2.</para>
		/// <para>See IKEEXT_COMMON_STATISTICS1 for more information.</para>
		/// </summary>
		public IKEEXT_COMMON_STATISTICS1 commonStatistics;
	}

	/// <summary>The <c>IKEEXT_TRAFFIC0</c> structure specifies the IKE/Authip traffic.</summary>
	/// <remarks>
	/// <c>IKEEXT_TRAFFIC0</c> is a specific implementation of IKEEXT_TRAFFIC. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/iketypes/ns-iketypes-ikeext_traffic0 typedef struct IKEEXT_TRAFFIC0_ {
	// FWP_IP_VERSION ipVersion; union { UINT32 localV4Address; UINT8 localV6Address[16]; }; union { UINT32 remoteV4Address; UINT8
	// remoteV6Address[16]; }; UINT64 authIpFilterId; } IKEEXT_TRAFFIC0;
	[PInvokeData("iketypes.h", MSDNShortId = "NS:iketypes.IKEEXT_TRAFFIC0_")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IKEEXT_TRAFFIC0
	{
		/// <summary>IP version specified by FWP_IP_VERSION.</summary>
		public FWP_IP_VERSION ipVersion;

		private FWP_BYTE_ARRAY_ADDR local;
		private FWP_BYTE_ARRAY_ADDR remote;

		/// <summary>
		/// <para>The local IPv4 address of the traffic.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR localV4Address { get => local.addr; set => local.addr = value; }

		/// <summary>
		/// <para>The local IPv6 address of the traffic.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR localV6Address { get => local.addr6; set => local.addr6 = value; }

		/// <summary>
		/// <para>The remote IPv4 address of the traffic.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V4</c>.</para>
		/// </summary>
		public IN_ADDR remoteV4Address { get => remote.addr; set => remote.addr = value; }

		/// <summary>
		/// <para>The remote IPv6 address of the traffic.</para>
		/// <para>Specified when <c>ipVersion</c> is <c>FWP_IP_VERSION_V6</c>.</para>
		/// </summary>
		public IN6_ADDR remoteV6Address { get => remote.addr6; set => remote.addr6 = value; }

		/// <summary>Filter ID from quick mode (QM) policy of matching extended mode (EM) filter.</summary>
		public ulong authIpFilterId;
	}
}