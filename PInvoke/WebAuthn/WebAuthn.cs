using System.Collections.Generic;
using System.Linq;

namespace Vanara.PInvoke;

/// <summary>Items from the WebAuthn.dll.</summary>
public static partial class WebAuthn
{
	/// <summary/>
	public const uint CTAPCBOR_HYBRID_STORAGE_LINKED_DATA_CURRENT_VERSION = CTAPCBOR_HYBRID_STORAGE_LINKED_DATA_VERSION_1;

	/// <summary/>
	public const uint CTAPCBOR_HYBRID_STORAGE_LINKED_DATA_VERSION_1 = 1;

	/// <summary/>
	public const uint EXPERIMENTAL_WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS_CURRENT_VERSION = EXPERIMENTAL_WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS_VERSION_1;

	/// <summary/>
	public const uint EXPERIMENTAL_WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS_VERSION_1 = 1;

	/// <summary/>
	public const uint EXPERIMENTAL_WEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY_CURRENT_VERSION = EXPERIMENTAL_WEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY_VERSION_1;

	/// <summary/>
	public const uint EXPERIMENTAL_WEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY_VERSION_1 = 1;

	/// <summary/>
	public const uint EXPERIMENTAL_WEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST_CURRENT_VERSION = EXPERIMENTAL_WEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST_VERSION_1;

	/// <summary/>
	public const uint EXPERIMENTAL_WEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST_VERSION_1 = 1;

	/// <summary/>
	public const uint EXPERIMENTAL_WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION_CURRENT_VERSION = EXPERIMENTAL_WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION_VERSION_1;

	/// <summary/>
	public const uint EXPERIMENTAL_WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION_VERSION_1 = 1;

	/// <summary/>
	public const uint EXPERIMENTAL_WEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST_CURRENT_VERSION = EXPERIMENTAL_WEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST_VERSION_1;

	/// <summary/>
	public const uint EXPERIMENTAL_WEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST_VERSION_1 = 1;

	/// <summary/>
	public const uint WEBAUTHN_API_CURRENT_VERSION = WEBAUTHN_API_VERSION_9;

	/// <summary/>
	public const uint WEBAUTHN_API_VERSION_1 = 1;

	/// <summary/>
	public const uint WEBAUTHN_API_VERSION_2 = 2;

	/// <summary/>
	public const uint WEBAUTHN_API_VERSION_3 = 3;

	/// <summary/>
	public const uint WEBAUTHN_API_VERSION_4 = 4;

	/// <summary/>
	public const uint WEBAUTHN_API_VERSION_5 = 5;

	/// <summary/>
	public const uint WEBAUTHN_API_VERSION_6 = 6;

	/// <summary/>
	public const uint WEBAUTHN_API_VERSION_7 = 7;

	/// <summary/>
	public const uint WEBAUTHN_API_VERSION_8 = 8;

	/// <summary/>
	public const uint WEBAUTHN_API_VERSION_9 = 9;

	/// <summary/>
	public const uint WEBAUTHN_ASSERTION_CURRENT_VERSION = WEBAUTHN_ASSERTION_VERSION_6;

	/// <summary/>
	public const uint WEBAUTHN_ASSERTION_VERSION_1 = 1;

	/// <summary/>
	public const uint WEBAUTHN_ASSERTION_VERSION_2 = 2;

	/// <summary/>
	public const uint WEBAUTHN_ASSERTION_VERSION_3 = 3;

	/// <summary/>
	public const uint WEBAUTHN_ASSERTION_VERSION_4 = 4;

	/// <summary/>
	public const uint WEBAUTHN_ASSERTION_VERSION_5 = 5;

	/// <summary/>
	public const uint WEBAUTHN_ASSERTION_VERSION_6 = 6;

	/// <summary/>
	public const string WEBAUTHN_ATTESTATION_TYPE_NONE = "none";

	/// <summary/>
	public const string WEBAUTHN_ATTESTATION_TYPE_PACKED = "packed";

	/// <summary/>
	public const string WEBAUTHN_ATTESTATION_TYPE_TPM = "tpm";

	/// <summary/>
	public const string WEBAUTHN_ATTESTATION_TYPE_U2F = "fido-u2f";

	/// <summary/>
	public const string WEBAUTHN_ATTESTATION_VER_TPM_2_0 = "2.0";

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_DETAILS_CURRENT_VERSION = WEBAUTHN_AUTHENTICATOR_DETAILS_VERSION_1;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_DETAILS_OPTIONS_CURRENT_VERSION = WEBAUTHN_AUTHENTICATOR_DETAILS_OPTIONS_VERSION_1;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_DETAILS_OPTIONS_VERSION_1 = 1;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_DETAILS_VERSION_1 = 1;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_CURRENT_VERSION = WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_9;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_1 = 1;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_2 = 2;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_3 = 3;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_4 = 4;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_5 = 5;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_6 = 6;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_7 = 7;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_8 = 8;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_9 = 9;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS_CURRENT_VERSION = WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS_VERSION_9;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS_VERSION_1 = 1;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS_VERSION_2 = 2;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS_VERSION_3 = 3;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS_VERSION_4 = 4;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS_VERSION_5 = 5;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS_VERSION_6 = 6;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS_VERSION_7 = 7;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS_VERSION_8 = 8;

	/// <summary/>
	public const uint WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS_VERSION_9 = 9;

	/// <summary/>
	public const uint WEBAUTHN_CLIENT_DATA_CURRENT_VERSION = 1;

	/// <summary/>
	public const uint WEBAUTHN_COMMON_ATTESTATION_CURRENT_VERSION = 1;

	/// <summary/>
	public const uint WEBAUTHN_COSE_ALGORITHM_ECDSA_P256_WITH_SHA256 = unchecked((uint)-7);

	/// <summary/>
	public const uint WEBAUTHN_COSE_ALGORITHM_ECDSA_P384_WITH_SHA384 = unchecked((uint)-35);

	/// <summary/>
	public const uint WEBAUTHN_COSE_ALGORITHM_ECDSA_P521_WITH_SHA512 = unchecked((uint)-36);

	/// <summary/>
	public const uint WEBAUTHN_COSE_ALGORITHM_RSA_PSS_WITH_SHA256 = unchecked((uint)-37);

	/// <summary/>
	public const uint WEBAUTHN_COSE_ALGORITHM_RSA_PSS_WITH_SHA384 = unchecked((uint)-38);

	/// <summary/>
	public const uint WEBAUTHN_COSE_ALGORITHM_RSA_PSS_WITH_SHA512 = unchecked((uint)-39);

	/// <summary/>
	public const uint WEBAUTHN_COSE_ALGORITHM_RSASSA_PKCS1_V1_5_WITH_SHA256 = unchecked((uint)-257);

	/// <summary/>
	public const uint WEBAUTHN_COSE_ALGORITHM_RSASSA_PKCS1_V1_5_WITH_SHA384 = unchecked((uint)-258);

	/// <summary/>
	public const uint WEBAUTHN_COSE_ALGORITHM_RSASSA_PKCS1_V1_5_WITH_SHA512 = unchecked((uint)-259);

	/// <summary/>
	public const uint WEBAUTHN_COSE_CREDENTIAL_PARAMETER_CURRENT_VERSION = 1;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_ATTESTATION_CURRENT_VERSION = WEBAUTHN_CREDENTIAL_ATTESTATION_VERSION_8;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_ATTESTATION_VERSION_1 = 1;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_ATTESTATION_VERSION_2 = 2;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_ATTESTATION_VERSION_3 = 3;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_ATTESTATION_VERSION_4 = 4;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_ATTESTATION_VERSION_5 = 5;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_ATTESTATION_VERSION_6 = 6;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_ATTESTATION_VERSION_7 = 7;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_ATTESTATION_VERSION_8 = 8;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_CURRENT_VERSION = 1;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_DETAILS_CURRENT_VERSION = WEBAUTHN_CREDENTIAL_DETAILS_VERSION_4;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_DETAILS_VERSION_1 = 1;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_DETAILS_VERSION_2 = 2;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_DETAILS_VERSION_3 = 3;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_DETAILS_VERSION_4 = 4;

	/// <summary/>
	public const uint WEBAUTHN_CREDENTIAL_EX_CURRENT_VERSION = 1;

	/// <summary/>
	public const string WEBAUTHN_CREDENTIAL_HINT_CLIENT_DEVICE = "client-device";

	/// <summary/>
	public const string WEBAUTHN_CREDENTIAL_HINT_HYBRID = "hybrid";

	/// <summary/>
	public const string WEBAUTHN_CREDENTIAL_HINT_SECURITY_KEY = "security-key";

	/// <summary/>
	public const string WEBAUTHN_CREDENTIAL_TYPE_PUBLIC_KEY = "public-key";

	/// <summary/>
	public const uint WEBAUTHN_CTAP_ONE_HMAC_SECRET_LENGTH = 32;

	/// <summary/>
	public const string WEBAUTHN_CTAP_TRANSPORT_BLE_STRING = "ble";

	/// <summary/>
	public const uint WEBAUTHN_CTAP_TRANSPORT_FLAGS_MASK = 0x0000007F;

	/// <summary/>
	public const string WEBAUTHN_CTAP_TRANSPORT_HYBRID_STRING = "hybrid";

	/// <summary/>
	public const string WEBAUTHN_CTAP_TRANSPORT_INTERNAL_STRING = "internal";

	/// <summary/>
	public const string WEBAUTHN_CTAP_TRANSPORT_NFC_STRING = "nfc";

	/// <summary/>
	public const string WEBAUTHN_CTAP_TRANSPORT_SMART_CARD_STRING = "smart-card";

	/// <summary/>
	public const string WEBAUTHN_CTAP_TRANSPORT_USB_STRING = "usb";

	/// <summary/>
	public const string WEBAUTHN_EXTENSIONS_IDENTIFIER_CRED_BLOB = "credBlob";

	/// <summary/>
	public const string WEBAUTHN_EXTENSIONS_IDENTIFIER_CRED_PROTECT = "credProtect";

	/// <summary/>
	public const string WEBAUTHN_EXTENSIONS_IDENTIFIER_HMAC_SECRET = "hmac-secret";

	/// <summary/>
	public const string WEBAUTHN_EXTENSIONS_IDENTIFIER_MIN_PIN_LENGTH = "minPinLength";

	/// <summary/>
	public const uint WEBAUTHN_GET_CREDENTIALS_OPTIONS_CURRENT_VERSION = WEBAUTHN_GET_CREDENTIALS_OPTIONS_VERSION_1;

	/// <summary/>
	public const uint WEBAUTHN_GET_CREDENTIALS_OPTIONS_VERSION_1 = 1;

	/// <summary/>
	public const string WEBAUTHN_HASH_ALGORITHM_SHA_256 = "SHA-256";

	/// <summary/>
	public const string WEBAUTHN_HASH_ALGORITHM_SHA_384 = "SHA-384";

	/// <summary/>
	public const string WEBAUTHN_HASH_ALGORITHM_SHA_512 = "SHA-512";

	/// <summary/>
	public const uint WEBAUTHN_MAX_USER_ID_LENGTH = 64;

	/// <summary/>
	public const uint WEBAUTHN_RP_ENTITY_INFORMATION_CURRENT_VERSION = WEBAUTHN_RP_ENTITY_INFORMATION_VERSION_1;

	/// <summary/>
	public const uint WEBAUTHN_RP_ENTITY_INFORMATION_VERSION_1 = 1;

	/// <summary/>
	public const uint WEBAUTHN_USER_ENTITY_INFORMATION_CURRENT_VERSION = WEBAUTHN_USER_ENTITY_INFORMATION_VERSION_1;

	/// <summary/>
	public const uint WEBAUTHN_USER_ENTITY_INFORMATION_VERSION_1 = 1;

	private const string Lib_WebAuthn = "webauthn.dll";

	/// <summary>The <c>EXPERIMENTAL_PLUGIN_AUTHENTICATOR_STATE</c> enumeration defines the possible states of a plugin authenticator.</summary>
	public enum EXPERIMENTAL_PLUGIN_AUTHENTICATOR_STATE
	{
		/// <summary/>
		PluginAuthenticatorState_Unknown = 0,

		/// <summary/>
		PluginAuthenticatorState_Disabled,

		/// <summary/>
		PluginAuthenticatorState_Enabled
	}

	/// <summary>
	/// The <c>EXPERIMENTAL_WEBAUTHN_PLUGIN_PERFORM_UV_OPERATION_TYPE</c> enumeration defines the types of operations that can be performed
	/// </summary>
	public enum EXPERIMENTAL_WEBAUTHN_PLUGIN_PERFORM_UV_OPERATION_TYPE
	{
		/// <summary/>
		PerformUv = 1,

		/// <summary/>
		GetUvCount,

		/// <summary/>
		GetPubKey
	}

	/// <summary/>
	public enum WEBAUTHN_ATTESTATION_CONVEYANCE_PREFERENCE : uint
	{
		/// <summary/>
		ANY = 0,

		/// <summary/>
		NONE = 1,

		/// <summary/>
		INDIRECT = 2,

		/// <summary/>
		DIRECT = 3
	}

	/// <summary>
	/// The <c>WEBAUTHN_ATTESTATION_DECODE</c> enumeration defines the types of attestation decoding that can be performed on the attestation
	/// data returned by an authenticator.
	/// </summary>
	public enum WEBAUTHN_ATTESTATION_DECODE
	{
		/// <summary/>
		WEBAUTHN_ATTESTATION_DECODE_NONE = 0,

		/// <summary/>
		WEBAUTHN_ATTESTATION_DECODE_COMMON = 1
	}

	/// <summary/>
	public enum WEBAUTHN_AUTHENTICATOR_ATTACHMENT : uint
	{
		/// <summary/>
		ANY = 0,

		/// <summary/>
		PLATFORM = 1,

		/// <summary/>
		CROSS_PLATFORM = 2,

		/// <summary/>
		CROSS_PLATFORM_U2F_V2 = 3
	}

	/// <summary/>
	public enum WEBAUTHN_CRED_LARGE_BLOB_OPERATION : uint
	{
		/// <summary/>
		NONE = 0,

		/// <summary/>
		GET = 1,

		/// <summary/>
		SET = 2,

		/// <summary/>
		DELETE = 3
	}

	/// <summary/>
	public enum WEBAUTHN_CRED_LARGE_BLOB_STATUS : uint
	{
		/// <summary/>
		NONE = 0,

		/// <summary/>
		SUCCESS = 1,

		/// <summary/>
		NOT_SUPPORTED = 2,

		/// <summary/>
		INVALID_DATA = 3,

		/// <summary/>
		INVALID_PARAMETER = 4,

		/// <summary/>
		NOT_FOUND = 5,

		/// <summary/>
		MULTIPLE_CREDENTIALS = 6,

		/// <summary/>
		LACK_OF_SPACE = 7,

		/// <summary/>
		PLATFORM_ERROR = 8,

		/// <summary/>
		AUTHENTICATOR_ERROR = 9
	}

	/// <summary>
	/// The <c>WEBAUTHN_CTAP_TRANSPORT</c> enumeration defines the transport methods that can be used for communication between the client
	/// platform and an authenticator.
	/// </summary>
	[Flags]
	public enum WEBAUTHN_CTAP_TRANSPORT : uint
	{
		/// <summary/>
		WEBAUTHN_CTAP_TRANSPORT_USB = 0x00000001,

		/// <summary/>
		WEBAUTHN_CTAP_TRANSPORT_NFC = 0x00000002,

		/// <summary/>
		WEBAUTHN_CTAP_TRANSPORT_BLE = 0x00000004,

		/// <summary/>
		WEBAUTHN_CTAP_TRANSPORT_TEST = 0x00000008,

		/// <summary/>
		WEBAUTHN_CTAP_TRANSPORT_INTERNAL = 0x00000010,

		/// <summary/>
		WEBAUTHN_CTAP_TRANSPORT_HYBRID = 0x00000020,

		/// <summary/>
		WEBAUTHN_CTAP_TRANSPORT_SMART_CARD = 0x00000040,
	}

	/// <summary/>
	public enum WEBAUTHN_ENTERPRISE_ATTESTATION : uint
	{
		/// <summary/>
		NONE = 0,

		/// <summary/>
		VENDOR_FACILITATED = 1,

		/// <summary/>
		PLATFORM_MANAGED = 2
	}

	/// <summary/>
	public enum WEBAUTHN_LARGE_BLOB_SUPPORT : uint
	{
		/// <summary/>
		NONE = 0,

		/// <summary/>
		REQUIRED = 1,

		/// <summary/>
		PREFERRED = 2
	}

	/// <summary/>
	public enum WEBAUTHN_USER_VERIFICATION : uint
	{
		/// <summary/>
		ANY = 0,

		/// <summary/>
		OPTIONAL = 1,

		/// <summary/>
		OPTIONAL_WITH_CREDENTIAL_ID_LIST = 2,

		/// <summary/>
		REQUIRED = 3
	}

	/// <summary/>
	public enum WEBAUTHN_USER_VERIFICATION_REQUIREMENT : uint
	{
		/// <summary/>
		ANY = 0,

		/// <summary/>
		DISCOURAGED = 3,

		/// <summary/>
		PREFERRED = 2,

		/// <summary/>
		REQUIRED = 1
	}

	/// <summary>
	/// Produces an assertion signature representing an assertion by the authenticator that the user has consented to a specific transaction,
	/// such as logging in or completing a purchase.
	/// </summary>
	/// <param name="hWnd">The handle for the window that will be used to display the UI.</param>
	/// <param name="pwszRpId">The ID of the Relying Party.</param>
	/// <param name="pWebAuthNClientData">The client data to be sent to the authenticator for the Relying Party.</param>
	/// <param name="pWebAuthNGetAssertionOptions">The options for the <b>WebAuthNAuthenticatorGetAssertion</b> operation.</param>
	/// <param name="ppWebAuthNAssertion">A pointer to a <b>WEBAUTHN_ASSERTION</b> that receives the assertion.</param>
	/// <returns>
	/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code. Call
	/// <c>WebAuthNGetErrorName</c> to get a human-readable error string. Call <c>WebAuthNGetW3CExceptionDOMError</c> to map the result to a
	/// W3C DOM exception code.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <para>
	/// Note: Before performing this operation, all other operations in progress in the authenticator session MUST be aborted by running the
	///       <c>WebAuthNCancelCurrentOperation</c> operation.
	/// </para>
	/// </para>
	/// <para>
	/// If the authenticator cannot find any credential corresponding to the specified Relying Party that matches the specified criteria, it
	/// terminates the operation and returns an error.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/nf-webauthn-webauthnauthenticatorgetassertion HRESULT
	// WebAuthNAuthenticatorGetAssertion( HWND hWnd, LPCWSTR pwszRpId, PCWEBAUTHN_CLIENT_DATA pWebAuthNClientData,
	// PCWEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS pWebAuthNGetAssertionOptions, PWEBAUTHN_ASSERTION *ppWebAuthNAssertion );
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNAuthenticatorGetAssertion")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNAuthenticatorGetAssertion(HWND hWnd, [MarshalAs(UnmanagedType.LPWStr)] string pwszRpId,
		in WEBAUTHN_CLIENT_DATA pWebAuthNClientData, in WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS pWebAuthNGetAssertionOptions,
		out SafeWEBAUTHN_ASSERTION ppWebAuthNAssertion);

	/// <summary>
	/// Creates a public key credential source bound to a managing authenticator and returns the credential public key associated with its
	/// credential private key. The Relying Party can use this credential public key to verify the authentication assertions created by this
	/// public key credential source.
	/// </summary>
	/// <param name="hWnd">The handle of the window used to display the WebAuthn UI to the user.</param>
	/// <param name="pRpInformation">
	/// A pointer to a <c>WEBAUTHN_RP_ENTITY_INFORMATION</c> structure that identifies the Relying Party on whose behalf the credential is created.
	/// </param>
	/// <param name="pUserInformation">
	/// A pointer to a <c>WEBAUTHN_USER_ENTITY_INFORMATION</c> structure that contains the user account information, including the user
	/// handle specified by the Relying Party.
	/// </param>
	/// <param name="pPubKeyCredParams">
	/// A pointer to a <c>WEBAUTHN_COSE_CREDENTIAL_PARAMETERS</c> structure that contains the Relying Party's ordered list of preferred
	/// public key credential types and algorithms. The authenticator makes a best-effort to create the most preferred credential that it can.
	/// </param>
	/// <param name="pWebAuthNClientData">
	/// A pointer to a <c>WEBAUTHN_CLIENT_DATA</c> structure that contains the client data hash to be sent to the authenticator.
	/// </param>
	/// <param name="pWebAuthNMakeCredentialOptions">
	/// An optional pointer to a <c>WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS</c> structure that specifies additional options for
	/// credential creation, such as exclude lists and authenticator selection criteria. This parameter can be <b>NULL</b>.
	/// </param>
	/// <param name="ppWebAuthNCredentialAttestation">
	/// When this function returns successfully, contains a pointer to a <c>WEBAUTHN_CREDENTIAL_ATTESTATION</c> structure that holds the
	/// attestation object returned by the authenticator. Free this with <c>WebAuthNFreeCredentialAttestation</c>.
	/// </param>
	/// <returns>
	/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code. Call
	/// <c>WebAuthNGetErrorName</c> to get a human-readable error string. Call <c>WebAuthNGetW3CExceptionDOMError</c> to map the result to a
	/// W3C DOM exception code.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function implements the <c>authenticatorMakeCredential</c> operation defined in the W3C Web Authentication specification. The
	/// caller is typically a client application acting on behalf of a Relying Party.
	/// </para>
	/// <para>
	/// The operation is modal and displays system UI through the window specified by hWnd. The caller can cancel a pending operation by
	/// calling <c>WebAuthNCancelCurrentOperation</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/nf-webauthn-webauthnauthenticatormakecredential HRESULT
	// WebAuthNAuthenticatorMakeCredential( HWND hWnd, PCWEBAUTHN_RP_ENTITY_INFORMATION pRpInformation, PCWEBAUTHN_USER_ENTITY_INFORMATION
	// pUserInformation, PCWEBAUTHN_COSE_CREDENTIAL_PARAMETERS pPubKeyCredParams, PCWEBAUTHN_CLIENT_DATA pWebAuthNClientData,
	// PCWEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS pWebAuthNMakeCredentialOptions, PWEBAUTHN_CREDENTIAL_ATTESTATION
	// *ppWebAuthNCredentialAttestation );
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNAuthenticatorMakeCredential")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNAuthenticatorMakeCredential(HWND hWnd,
		in WEBAUTHN_RP_ENTITY_INFORMATION pRpInformation, in WEBAUTHN_USER_ENTITY_INFORMATION pUserInformation,
		in WEBAUTHN_COSE_CREDENTIAL_PARAMETERS pPubKeyCredParams, in WEBAUTHN_CLIENT_DATA pWebAuthNClientData,
		in WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS pWebAuthNMakeCredentialOptions,
		out SafeWEBAUTHN_CREDENTIAL_ATTESTATION ppWebAuthNCredentialAttestation);

	/// <summary>
	/// Cancels a <c>WebAuthNAuthenticatorMakeCredential</c> or <c>WebAuthNAuthenticatorGetAssertion</c> operation currently in progress. The
	/// authenticator stops prompting for, or accepting, any user input related to the canceled operation.
	/// </summary>
	/// <param name="pCancellationId">
	/// A pointer to the <b>GUID</b> that identifies the operation to cancel. Obtain this value by calling <c>WebAuthNGetCancellationId</c>.
	/// </param>
	/// <returns>
	/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code. Call
	/// <c>WebAuthNGetErrorName</c> to get a human-readable error string.
	/// </returns>
	/// <remarks>
	/// This function has no effect if the specified cancellation ID does not correspond to an operation that is currently in progress.
	/// </remarks>
	// https://learn.microsoft.com/bg-bg/windows/win32/api/webauthn/nf-webauthn-webauthncancelcurrentoperation HRESULT
	// WebAuthNCancelCurrentOperation( const GUID *pCancellationId );
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNCancelCurrentOperation")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNCancelCurrentOperation(in Guid pCancellationId);

	/// <summary>Deletes a platform credential stored on the authenticator.</summary>
	/// <param name="cbCredentialId">The size, in bytes, of the credential ID pointed to by pbCredentialId.</param>
	/// <param name="pbCredentialId">A pointer to a byte array that contains the credential ID of the credential to delete.</param>
	/// <returns>
	/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code. Call
	/// <c>WebAuthNGetErrorName</c> to get a human-readable error string.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/nf-webauthn-webauthndeleteplatformcredential HRESULT
	// WebAuthNDeletePlatformCredential( DWORD cbCredentialId, const BYTE *pbCredentialId );
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNDeletePlatformCredential")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNDeletePlatformCredential(uint cbCredentialId, [In, SizeDef(nameof(cbCredentialId))] byte[] pbCredentialId);

	/// <summary>Frees a <c>WEBAUTHN_ASSERTION</c> allocated by <c>WebAuthNAuthenticatorGetAssertion</c>.</summary>
	/// <param name="pWebAuthNAssertion">A pointer to the <c>WEBAUTHN_ASSERTION</c> to free.</param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/nf-webauthn-webauthnfreeassertion void WebAuthNFreeAssertion(
	// PWEBAUTHN_ASSERTION pWebAuthNAssertion );
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNFreeAssertion")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern void WebAuthNFreeAssertion(IntPtr pWebAuthNAssertion);

	/// <summary>Frees a <c>WEBAUTHN_AUTHENTICATOR_DETAILS_LIST</c> allocated by <c>WebAuthNGetAuthenticatorList</c>.</summary>
	/// <param name="pAuthenticatorDetailsList">A pointer to the <c>WEBAUTHN_AUTHENTICATOR_DETAILS_LIST</c> to free.</param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/nf-webauthn-webauthnfreeauthenticatorlist void
	// WebAuthNFreeAuthenticatorList( PWEBAUTHN_AUTHENTICATOR_DETAILS_LIST pAuthenticatorDetailsList );
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNFreeAuthenticatorList")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern void WebAuthNFreeAuthenticatorList(IntPtr pAuthenticatorDetailsList);

	/// <summary>Frees a <c>WEBAUTHN_CREDENTIAL_ATTESTATION</c> allocated by <c>WebAuthNAuthenticatorMakeCredential</c>.</summary>
	/// <param name="pWebAuthNCredentialAttestation">A pointer to the <c>WEBAUTHN_CREDENTIAL_ATTESTATION</c> to free.</param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/nf-webauthn-webauthnfreecredentialattestation void
	// WebAuthNFreeCredentialAttestation( PWEBAUTHN_CREDENTIAL_ATTESTATION pWebAuthNCredentialAttestation );
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNFreeCredentialAttestation")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern void WebAuthNFreeCredentialAttestation(IntPtr pWebAuthNCredentialAttestation);

	/// <summary>Frees a <c>WEBAUTHN_CREDENTIAL_DETAILS_LIST</c> allocated by <c>WebAuthNGetPlatformCredentialList</c>.</summary>
	/// <param name="pCredentialDetailsList">A pointer to the <c>WEBAUTHN_CREDENTIAL_DETAILS_LIST</c> to free.</param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/nf-webauthn-webauthnfreeplatformcredentiallist void
	// WebAuthNFreePlatformCredentialList( PWEBAUTHN_CREDENTIAL_DETAILS_LIST pCredentialDetailsList );
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNFreePlatformCredentialList")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern void WebAuthNFreePlatformCredentialList(IntPtr pCredentialDetailsList);

	/// <summary>Returns the version number of the WebAuthn API supported by the current platform.</summary>
	/// <returns>
	/// A <b>DWORD</b> that contains the WebAuthn API version number. Compare the return value against the <b>WEBAUTHN_API_VERSION_*</b>
	/// constants defined in <c>webauthn.h</c> to determine which features are available.
	/// </returns>
	/// <remarks>Call this function before using features introduced in later API versions to verify that the platform supports them.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/nf-webauthn-webauthngetapiversionnumber DWORD WebAuthNGetApiVersionNumber();
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNGetApiVersionNumber")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern uint WebAuthNGetApiVersionNumber();

	/// <summary>Retrieves a list of authenticators available on the system, including plugin authenticators.</summary>
	/// <param name="pWebAuthNGetAuthenticatorListOptions">
	/// An optional pointer to a <c>WEBAUTHN_AUTHENTICATOR_DETAILS_OPTIONS</c> structure that specifies options for the query. May be <b>NULL</b>.
	/// </param>
	/// <param name="ppAuthenticatorDetailsList">
	/// When this function returns successfully, contains a pointer to a <c>WEBAUTHN_AUTHENTICATOR_DETAILS_LIST</c> structure. Free this with <c>WebAuthNFreeAuthenticatorList</c>.
	/// </param>
	/// <returns>
	/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code. Call
	/// <c>WebAuthNGetErrorName</c> to get a human-readable error string.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use this function to enumerate authenticators on the system. Each authenticator is described by a
	/// <c>WEBAUTHN_AUTHENTICATOR_DETAILS</c> structure that includes its identifier, display name, logo, and lock state.
	/// </para>
	/// <para>
	/// The authenticator ID returned in each entry can be passed to <c>WebAuthNAuthenticatorMakeCredential</c> or
	/// <c>WebAuthNAuthenticatorGetAssertion</c> via the <b>cbAuthenticatorId</b> and <b>pbAuthenticatorId</b> fields in the options
	/// structure to target a specific authenticator.
	/// </para>
	/// <para>This function requires WebAuthn API version 9 or later. Call <c>WebAuthNGetApiVersionNumber</c> to verify support.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/nf-webauthn-webauthngetauthenticatorlist HRESULT
	// WebAuthNGetAuthenticatorList( PCWEBAUTHN_AUTHENTICATOR_DETAILS_OPTIONS pWebAuthNGetAuthenticatorListOptions,
	// PWEBAUTHN_AUTHENTICATOR_DETAILS_LIST *ppAuthenticatorDetailsList );
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNGetAuthenticatorList")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNGetAuthenticatorList(in WEBAUTHN_AUTHENTICATOR_DETAILS_OPTIONS pWebAuthNGetAuthenticatorListOptions,
		out SafeWEBAUTHN_AUTHENTICATOR_DETAILS_LIST ppAuthenticatorDetailsList);

	/// <summary>
	/// Returns a cancellation ID that can be passed to <c>WebAuthNCancelCurrentOperation</c> to cancel a pending
	/// <c>WebAuthNAuthenticatorMakeCredential</c> or <c>WebAuthNAuthenticatorGetAssertion</c> call.
	/// </summary>
	/// <param name="pCancellationId">
	/// A pointer to a <b>GUID</b> that receives the cancellation ID. Pass this value to <c>WebAuthNCancelCurrentOperation</c> to cancel the operation.
	/// </param>
	/// <returns>
	/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code. Call
	/// <c>WebAuthNGetErrorName</c> to get a human-readable error string.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/nf-webauthn-webauthngetcancellationid HRESULT WebAuthNGetCancellationId(
	// GUID *pCancellationId );
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNGetCancellationId")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNGetCancellationId(out Guid pCancellationId);

	/// <summary>Returns a human-readable error name string for the specified <b>HRESULT</b> error code returned by a WebAuthn function.</summary>
	/// <param name="hr">The <b>HRESULT</b> error code to translate.</param>
	/// <returns>A pointer to a null-terminated wide string that contains the W3C error name. The caller must not free this string.</returns>
	/// <remarks>
	/// <para>The following table lists the mappings from <b>HRESULT</b> values to W3C error name strings:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Error Code</description>
	/// <description>Error Name</description>
	/// </listheader>
	/// <item>
	/// <description><b>S_OK</b></description>
	/// <description>Success</description>
	/// </item>
	/// <item>
	/// <description><b>NTE_EXISTS</b></description>
	/// <description>InvalidStateError</description>
	/// </item>
	/// <item>
	/// <description><b>HRESULT_FROM_WIN32(ERROR_NOT_SUPPORTED)</b><b>NTE_NOT_SUPPORTED</b><b>NTE_TOKEN_KEYSET_STORAGE_FULL</b></description>
	/// <description>ConstraintError</description>
	/// </item>
	/// <item>
	/// <description><b>NTE_INVALID_PARAMETER</b></description>
	/// <description>NotSupportedError</description>
	/// </item>
	/// <item>
	/// <description><b>NTE_DEVICE_NOT_FOUND</b><b>NTE_NOT_FOUND</b><b>HRESULT_FROM_WIN32(ERROR_CANCELLED)</b><b>NTE_USER_CANCELLED</b><b>HRESULT_FROM_WIN32(ERROR_TIMEOUT)</b></description>
	/// <description>NotAllowedError</description>
	/// </item>
	/// <item>
	/// <description>All other <b>HRESULT</b> values</description>
	/// <description>UnknownError</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/nf-webauthn-webauthngeterrorname PCWSTR WebAuthNGetErrorName( HRESULT hr );
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNGetErrorName")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string? WebAuthNGetErrorName(HRESULT hr);

	/// <summary>Retrieves the list of platform credentials stored for the current user.</summary>
	/// <param name="pGetCredentialsOptions">
	/// A pointer to a <c>WEBAUTHN_GET_CREDENTIALS_OPTIONS</c> structure that specifies filtering criteria for the credential list.
	/// </param>
	/// <param name="ppCredentialDetailsList">
	/// When this function returns successfully, contains a pointer to a <c>WEBAUTHN_CREDENTIAL_DETAILS_LIST</c> structure that receives the
	/// matching credentials. Free this with <c>WebAuthNFreePlatformCredentialList</c>.
	/// </param>
	/// <returns>
	/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code. Call
	/// <c>WebAuthNGetErrorName</c> to get a human-readable error string.
	/// </returns>
	// https://learn.microsoft.com/sr-latn-rs/windows/win32/api/webauthn/nf-webauthn-webauthngetplatformcredentiallist HRESULT
	// WebAuthNGetPlatformCredentialList( PCWEBAUTHN_GET_CREDENTIALS_OPTIONS pGetCredentialsOptions, PWEBAUTHN_CREDENTIAL_DETAILS_LIST
	// *ppCredentialDetailsList );
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNGetPlatformCredentialList")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNGetPlatformCredentialList(in WEBAUTHN_GET_CREDENTIALS_OPTIONS pGetCredentialsOptions,
		out SafeWEBAUTHN_CREDENTIAL_DETAILS_LIST ppCredentialDetailsList);

	/// <summary>Maps an <b>HRESULT</b> error code returned by a WebAuthn function to the corresponding W3C WebAuthn DOM exception code.</summary>
	/// <param name="hr">The <b>HRESULT</b> error code to map.</param>
	/// <returns>An <b>HRESULT</b> that represents the W3C DOM exception code corresponding to hr.</returns>
	/// <remarks>
	/// Use this function when you need to propagate WebAuthn errors through a W3C-compliant API surface. To get a human-readable error name
	/// string instead, call <c>WebAuthNGetErrorName</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/nf-webauthn-webauthngetw3cexceptiondomerror HRESULT
	// WebAuthNGetW3CExceptionDOMError( HRESULT hr );
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNGetW3CExceptionDOMError")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNGetW3CExceptionDOMError(HRESULT hr);

	/// <summary>Determines whether a user-verifying platform authenticator is available on this device.</summary>
	/// <param name="pbIsUserVerifyingPlatformAuthenticatorAvailable">
	/// A pointer to a <b>BOOL</b> that receives <b>TRUE</b> if a user-verifying platform authenticator is available; otherwise, <b>FALSE</b>.
	/// </param>
	/// <returns>
	/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code. Call
	/// <c>WebAuthNGetErrorName</c> to get a human-readable error string.
	/// </returns>
	/// <remarks>
	/// This function corresponds to the W3C <c>isUserVerifyingPlatformAuthenticatorAvailable</c> method. A platform authenticator is one
	/// built into the client device, such as Windows Hello.
	/// </remarks>
	// https://learn.microsoft.com/hr-hr/windows/win32/api/webauthn/nf-webauthn-webauthnisuserverifyingplatformauthenticatoravailable HRESULT
	// WebAuthNIsUserVerifyingPlatformAuthenticatorAvailable( BOOL *pbIsUserVerifyingPlatformAuthenticatorAvailable );
	[PInvokeData("webauthn.h", MSDNShortId = "NF:webauthn.WebAuthNIsUserVerifyingPlatformAuthenticatorAvailable")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNIsUserVerifyingPlatformAuthenticatorAvailable([MarshalAs(UnmanagedType.Bool)] out bool pbIsUserVerifyingPlatformAuthenticatorAvailable);

	/// <summary>
	/// Contains hybrid transport linked device data used to establish a connection between the client platform and an external CTAP2
	/// authenticator over a hybrid (cross-device) transport channel.
	/// </summary>
	/// <remarks>
	/// This structure represents the state of a linked device for the CTAP2 hybrid transport, as defined in the <c>CTAP2 specification</c>.
	/// It is used internally to persist linked device information across sessions.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-ctapcbor_hybrid_storage_linked_data typedef struct
	// _CTAPCBOR_HYBRID_STORAGE_LINKED_DATA { DWORD dwVersion; DWORD cbContactId; PBYTE pbContactId; DWORD cbLinkId; PBYTE pbLinkId; DWORD
	// cbLinkSecret; PBYTE pbLinkSecret; DWORD cbPublicKey; PBYTE pbPublicKey; PCWSTR pwszAuthenticatorName; WORD wEncodedTunnelServerDomain;
	// } CTAPCBOR_HYBRID_STORAGE_LINKED_DATA, *PCTAPCBOR_HYBRID_STORAGE_LINKED_DATA;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._CTAPCBOR_HYBRID_STORAGE_LINKED_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CTAPCBOR_HYBRID_STORAGE_LINKED_DATA()
	{
		/// <summary>Version of this structure, to allow for modifications in the future.</summary>
		public uint dwVersion = CTAPCBOR_HYBRID_STORAGE_LINKED_DATA_CURRENT_VERSION;

		/// <summary>The size, in bytes, of the contact ID pointed to by <b>pbContactId</b>.</summary>
		public uint cbContactId;

		/// <summary>A pointer to the contact ID that identifies this linked device.</summary>
		[SizeDef(nameof(cbContactId))]
		public ArrayPointer<byte> pbContactId;

		/// <summary>The size, in bytes, of the link ID pointed to by <b>pbLinkId</b>.</summary>
		public uint cbLinkId;

		/// <summary>A pointer to the link ID for this linked device.</summary>
		[SizeDef(nameof(cbLinkId))]
		public ArrayPointer<byte> pbLinkId;

		/// <summary>The size, in bytes, of the link secret pointed to by <b>pbLinkSecret</b>.</summary>
		public uint cbLinkSecret;

		/// <summary>A pointer to the shared secret used to secure the hybrid transport link.</summary>
		[SizeDef(nameof(cbLinkSecret))]
		public ArrayPointer<byte> pbLinkSecret;

		/// <summary>The size, in bytes, of the authenticator public key pointed to by <b>pbPublicKey</b>.</summary>
		public uint cbPublicKey;

		/// <summary>A pointer to the authenticator's public key.</summary>
		[SizeDef(nameof(cbPublicKey))]
		public ArrayPointer<byte> pbPublicKey;

		/// <summary>A pointer to a null-terminated string that contains the display name of the linked authenticator.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszAuthenticatorName;

		/// <summary>An encoded value representing the tunnel server domain used for the hybrid transport connection.</summary>
		public ushort wEncodedTunnelServerDomain;
	}

	/// <summary>Contains the data returned by the authenticator to verify an assertion.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_assertion typedef struct _WEBAUTHN_ASSERTION { DWORD
	// dwVersion; DWORD cbAuthenticatorData; PBYTE pbAuthenticatorData; DWORD cbSignature; PBYTE pbSignature; WEBAUTHN_CREDENTIAL Credential;
	// DWORD cbUserId; PBYTE pbUserId; WEBAUTHN_EXTENSIONS Extensions; DWORD cbCredLargeBlob; PBYTE pbCredLargeBlob; DWORD
	// dwCredLargeBlobStatus; PWEBAUTHN_HMAC_SECRET_SALT pHmacSecret; DWORD dwUsedTransport; DWORD cbUnsignedExtensionOutputs; PBYTE
	// pbUnsignedExtensionOutputs; DWORD cbClientDataJSON; PBYTE pbClientDataJSON; DWORD cbAuthenticationResponseJSON; PBYTE
	// pbAuthenticationResponseJSON; } WEBAUTHN_ASSERTION, *PWEBAUTHN_ASSERTION;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_ASSERTION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_ASSERTION()
	{
		/// <summary>The version of this structure.</summary>
		public uint dwVersion = WEBAUTHN_ASSERTION_CURRENT_VERSION;

		/// <summary>The size, in bytes, of the authenticator data pointed to by <b>pbAuthenticatorData</b>.</summary>
		public uint cbAuthenticatorData;

		/// <summary>A pointer to the authenticator data.</summary>
		[SizeDef(nameof(cbAuthenticatorData))]
		public ArrayPointer<byte> pbAuthenticatorData;

		/// <summary>The size, in bytes, of the signature pointed to by <b>pbSignature</b>.</summary>
		public uint cbSignature;

		/// <summary>A pointer to the signature generated for this assertion.</summary>
		[SizeDef(nameof(cbSignature))]
		public ArrayPointer<byte> pbSignature;

		/// <summary>A <c>WEBAUTHN_CREDENTIAL</c> that identifies the credential used for this assertion.</summary>
		public WEBAUTHN_CREDENTIAL Credential;

		/// <summary>The size, in bytes, of the user ID pointed to by <b>pbUserId</b>.</summary>
		public uint cbUserId;

		/// <summary>A pointer to the user handle returned by the authenticator.</summary>
		[SizeDef(nameof(cbUserId))]
		public ArrayPointer<byte> pbUserId;

		/// <summary>A <c>WEBAUTHN_EXTENSIONS</c> structure that contains the authenticator extension outputs, if any.</summary>
		public WEBAUTHN_EXTENSIONS Extensions;

		/// <summary>The size, in bytes, of <b>pbCredLargeBlob</b>.</summary>
		public uint cbCredLargeBlob;

		/// <summary>A pointer to the large blob data associated with the credential.</summary>
		[SizeDef(nameof(cbCredLargeBlob))]
		public ArrayPointer<byte> pbCredLargeBlob;

		/// <summary>
		/// A <b>DWORD</b> value that indicates the status of the large blob operation. See the <c>WEBAUTHN_CRED_LARGE_BLOB_STATUS_*</c>
		/// status constants.
		/// </summary>
		public WEBAUTHN_CRED_LARGE_BLOB_STATUS dwCredLargeBlobStatus;

		/// <summary>A pointer to a <c>WEBAUTHN_HMAC_SECRET_SALT</c> structure that contains the HMAC secret output.</summary>
		public StructPointer<WEBAUTHN_HMAC_SECRET_SALT> pHmacSecret;

		/// <summary/>
		public uint dwUsedTransport;

		/// <summary/>
		public uint cbUnsignedExtensionOutputs;

		/// <summary/>
		[SizeDef(nameof(cbUnsignedExtensionOutputs))]
		public ArrayPointer<byte> pbUnsignedExtensionOutputs;

		/// <summary/>
		public uint cbClientDataJSON;

		/// <summary/>
		[SizeDef(nameof(cbClientDataJSON))]
		public ArrayPointer<byte> pbClientDataJSON;

		/// <summary/>
		public uint cbAuthenticationResponseJSON;

		/// <summary/>
		[SizeDef(nameof(cbAuthenticationResponseJSON))]
		public ArrayPointer<byte> pbAuthenticationResponseJSON;
	}

	/// <summary>Contains information about an authenticator available on the system, returned by <c>WebAuthNGetAuthenticatorList</c>.</summary>
	/// <remarks>
	/// <para>
	/// Use <c>WebAuthNGetAuthenticatorList</c> to obtain an array of these structures. The <b>pbAuthenticatorId</b> value uniquely
	/// identifies each authenticator and can be passed to <c>WebAuthNAuthenticatorMakeCredential</c> or
	/// <c>WebAuthNAuthenticatorGetAssertion</c> to target a specific authenticator for an operation.
	/// </para>
	/// <para>
	/// When <b>bLocked</b> is <b>TRUE</b>, the authenticator's credentials may not appear in the list returned by
	/// <c>WebAuthNGetPlatformCredentialList</c> until the user unlocks the authenticator.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_authenticator_details typedef struct
	// _WEBAUTHN_AUTHENTICATOR_DETAILS { DWORD dwVersion; DWORD cbAuthenticatorId; PBYTE pbAuthenticatorId; PCWSTR pwszAuthenticatorName;
	// DWORD cbAuthenticatorLogo; PBYTE pbAuthenticatorLogo; BOOL bLocked; } WEBAUTHN_AUTHENTICATOR_DETAILS, *PWEBAUTHN_AUTHENTICATOR_DETAILS;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_AUTHENTICATOR_DETAILS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_AUTHENTICATOR_DETAILS()
	{
		/// <summary>Version of this structure, to allow for modifications in the future.</summary>
		public uint dwVersion = WEBAUTHN_AUTHENTICATOR_DETAILS_CURRENT_VERSION;

		/// <summary>The size, in bytes, of the authenticator ID pointed to by <b>pbAuthenticatorId</b>.</summary>
		public uint cbAuthenticatorId;

		/// <summary>
		/// A pointer to a unique identifier for this authenticator. Pass this value in the <b>cbAuthenticatorId</b> and
		/// <b>pbAuthenticatorId</b> fields of <c>WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS</c> or
		/// <c>WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS</c> to target this specific authenticator.
		/// </summary>
		[SizeDef(nameof(cbAuthenticatorId))]
		public ArrayPointer<byte> pbAuthenticatorId;

		/// <summary>A pointer to a null-terminated string that contains the display name of the authenticator.</summary>
		public StrPtrUni pwszAuthenticatorName;

		/// <summary>
		/// The size, in bytes, of the authenticator logo data pointed to by <b>pbAuthenticatorLogo</b>. The logo is expected to be in SVG format.
		/// </summary>
		public uint cbAuthenticatorLogo;

		/// <summary>A pointer to the authenticator logo data. The logo is expected to be in SVG format.</summary>
		[SizeDef(nameof(cbAuthenticatorLogo))]
		public ArrayPointer<byte> pbAuthenticatorLogo;

		/// <summary>
		/// <b>TRUE</b> if the authenticator is currently locked. When locked, this authenticator's credentials might not be present or
		/// updated in the list returned by <c>WebAuthNGetPlatformCredentialList</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bLocked;
	}

	/// <summary>Contains a list of <c>WEBAUTHN_AUTHENTICATOR_DETAILS</c> structures returned by <c>WebAuthNGetAuthenticatorList</c>.</summary>
	/// <remarks>Free this structure by calling <c>WebAuthNFreeAuthenticatorList</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_authenticator_details_list typedef struct
	// _WEBAUTHN_AUTHENTICATOR_DETAILS_LIST { DWORD cAuthenticatorDetails; PWEBAUTHN_AUTHENTICATOR_DETAILS *ppAuthenticatorDetails; }
	// WEBAUTHN_AUTHENTICATOR_DETAILS_LIST, *PWEBAUTHN_AUTHENTICATOR_DETAILS_LIST;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_AUTHENTICATOR_DETAILS_LIST")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_AUTHENTICATOR_DETAILS_LIST : IArrayStruct<IntPtr>
	{
		/// <summary>The number of elements in the <b>ppAuthenticatorDetails</b> array.</summary>
		public uint cAuthenticatorDetails;

		/// <summary>A pointer to an array of pointers to <c>WEBAUTHN_AUTHENTICATOR_DETAILS</c> structures.</summary>
		[SizeDef(nameof(cAuthenticatorDetails))]
		public ArrayPointer<StructPointer<WEBAUTHN_AUTHENTICATOR_DETAILS>> ppAuthenticatorDetails;
	}

	/// <summary>Contains options for the <c>WebAuthNGetAuthenticatorList</c> function.</summary>
	/// <remarks>
	/// This structure is reserved for future use. Set <b>dwVersion</b> to <b>WEBAUTHN_AUTHENTICATOR_DETAILS_OPTIONS_CURRENT_VERSION</b> and
	/// pass a pointer to <c>WebAuthNGetAuthenticatorList</c>, or pass <b>NULL</b> to use defaults.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_authenticator_details_options typedef struct
	// _WEBAUTHN_AUTHENTICATOR_DETAILS_OPTIONS { DWORD dwVersion; } WEBAUTHN_AUTHENTICATOR_DETAILS_OPTIONS, *PWEBAUTHN_AUTHENTICATOR_DETAILS_OPTIONS;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_AUTHENTICATOR_DETAILS_OPTIONS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_AUTHENTICATOR_DETAILS_OPTIONS()
	{
		/// <summary>
		/// Version of this structure, to allow for modifications in the future. This field is required and should be set to <b>WEBAUTHN_AUTHENTICATOR_DETAILS_OPTIONS_CURRENT_VERSION</b>.
		/// </summary>
		public uint dwVersion = WEBAUTHN_AUTHENTICATOR_DETAILS_OPTIONS_CURRENT_VERSION;
	}

	/// <summary>Contains options for the <c>WebAuthNAuthenticatorGetAssertion</c> operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_authenticator_get_assertion_options typedef struct
	// _WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS { DWORD dwVersion; DWORD dwTimeoutMilliseconds; WEBAUTHN_CREDENTIALS CredentialList;
	// WEBAUTHN_EXTENSIONS Extensions; DWORD dwAuthenticatorAttachment; DWORD dwUserVerificationRequirement; DWORD dwFlags; PCWSTR
	// pwszU2fAppId; BOOL *pbU2fAppId; GUID *pCancellationId; PWEBAUTHN_CREDENTIAL_LIST pAllowCredentialList; DWORD dwCredLargeBlobOperation;
	// DWORD cbCredLargeBlob; PBYTE pbCredLargeBlob; PWEBAUTHN_HMAC_SECRET_SALT_VALUES pHmacSecretSaltValues; BOOL bBrowserInPrivateMode;
	// PCTAPCBOR_HYBRID_STORAGE_LINKED_DATA pLinkedDevice; BOOL bAutoFill; DWORD cbJsonExt; PBYTE pbJsonExt; DWORD cCredentialHints; LPCWSTR
	// *ppwszCredentialHints; PCWSTR pwszRemoteWebOrigin; DWORD cbPublicKeyCredentialRequestOptionsJSON; PBYTE
	// pbPublicKeyCredentialRequestOptionsJSON; DWORD cbAuthenticatorId; PBYTE pbAuthenticatorId; }
	// WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS, *PWEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS()
	{
		/// <summary>The version of this structure.</summary>
		public uint dwVersion = WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_CURRENT_VERSION;

		/// <summary>Time that the operation is expected to complete within. This is used as guidance and can be overridden by the platform.</summary>
		public uint dwTimeoutMilliseconds;

		/// <summary>A <c>WEBAUTHN_CREDENTIALS</c> structure that specifies the list of allowed credentials for the assertion.</summary>
		public WEBAUTHN_CREDENTIALS CredentialList;

		/// <summary>A <c>WEBAUTHN_EXTENSIONS</c> structure that contains optional extensions to parse when performing the operation.</summary>
		public WEBAUTHN_EXTENSIONS Extensions;

		/// <summary>The attachment for the assertion. Optional platform vs cross-platform authenticators.</summary>
		public WEBAUTHN_AUTHENTICATOR_ATTACHMENT dwAuthenticatorAttachment;

		/// <summary>The effective user verification requirement.</summary>
		public WEBAUTHN_USER_VERIFICATION_REQUIREMENT dwUserVerificationRequirement;

		/// <summary>The flags for the assertion.</summary>
		public uint dwFlags;

		/// <summary>Optional identifier for the U2F AppId. Converted to UTF8 before being hashed. Not lower-cased.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszU2fAppId;

		/// <summary>If this is non-NULL, then, set to <b>TRUE</b> if the <b>pwszU2fAppid</b> was used instead of <b>PCWSTR pwszRpId</b>.</summary>
		public StructPointer<BOOL> pbU2fAppId;

		/// <summary>Optional cancellation Id. See <c>WebAuthNGetCancellationId</c> for more information.</summary>
		public GuidPtr pCancellationId;

		/// <summary>
		/// An optional pointer to a <c>WEBAUTHN_CREDENTIAL_LIST</c> that specifies credentials acceptable to the Relying Party. If present,
		/// <b>CredentialList</b> is ignored.
		/// </summary>
		public ManagedStructPointer<WEBAUTHN_CREDENTIAL_LIST> pAllowCredentialList;

		/// <summary>The large blob operation.</summary>
		public WEBAUTHN_CRED_LARGE_BLOB_OPERATION dwCredLargeBlobOperation;

		/// <summary>Size of <b>pbCredLargeBlob</b>.</summary>
		public uint cbCredLargeBlob;

		/// <summary>A pointer to the large credential blob.</summary>
		[SizeDef(nameof(cbCredLargeBlob))]
		public ArrayPointer<byte> pbCredLargeBlob;

		/// <summary>
		/// A pointer to a <c>WEBAUTHN_HMAC_SECRET_SALT_VALUES</c> structure that contains PRF values to be converted into HMAC-SECRET values
		/// according to the WebAuthn specification.
		/// </summary>
		public ManagedStructPointer<WEBAUTHN_HMAC_SECRET_SALT_VALUES> pHmacSecretSaltValues;

		/// <summary>Indicates whether the client is using in-private mode in the browser. An optional parameter that defaults to <b>FALSE</b>.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bBrowserInPrivateMode;

		/// <summary/>
		public ManagedStructPointer<CTAPCBOR_HYBRID_STORAGE_LINKED_DATA> pLinkedDevice;

		/// <summary/>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bAutoFill;

		/// <summary/>
		public uint cbJsonExt;

		/// <summary/>
		[SizeDef(nameof(cbJsonExt))]
		public ArrayPointer<byte> pbJsonExt;

		/// <summary/>
		public uint cCredentialHints;

		/// <summary/>
		[SizeDef(nameof(cCredentialHints))]
		public ArrayPointer<StrPtrUni> ppwszCredentialHints;

		/// <summary/>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszRemoteWebOrigin;

		/// <summary/>
		public uint cbPublicKeyCredentialRequestOptionsJSON;

		/// <summary/>
		[SizeDef(nameof(cbPublicKeyCredentialRequestOptionsJSON))]
		public ArrayPointer<byte> pbPublicKeyCredentialRequestOptionsJSON;

		/// <summary>
		/// The size, in bytes, of the authenticator ID pointed to by <b>pbAuthenticatorId</b>. Set to 0 if not targeting a specific authenticator.
		/// </summary>
		public uint cbAuthenticatorId;

		/// <summary>
		/// An optional pointer to the ID of a specific authenticator to target for this operation. Obtain authenticator IDs by calling
		/// <c>WebAuthNGetAuthenticatorList</c>. Set to <b>NULL</b> to use the default authenticator selection behavior.
		/// </summary>
		[SizeDef(nameof(cbAuthenticatorId))]
		public ArrayPointer<byte> pbAuthenticatorId;
	}

	/// <summary>Contains options for the <c>WebAuthNAuthenticatorMakeCredential</c> operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_authenticator_make_credential_options typedef struct
	// _WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS { DWORD dwVersion; DWORD dwTimeoutMilliseconds; WEBAUTHN_CREDENTIALS CredentialList;
	// WEBAUTHN_EXTENSIONS Extensions; DWORD dwAuthenticatorAttachment; BOOL bRequireResidentKey; DWORD dwUserVerificationRequirement; DWORD
	// dwAttestationConveyancePreference; DWORD dwFlags; GUID *pCancellationId; PWEBAUTHN_CREDENTIAL_LIST pExcludeCredentialList; DWORD
	// dwEnterpriseAttestation; DWORD dwLargeBlobSupport; BOOL bPreferResidentKey; BOOL bBrowserInPrivateMode; BOOL bEnablePrf;
	// PCTAPCBOR_HYBRID_STORAGE_LINKED_DATA pLinkedDevice; DWORD cbJsonExt; PBYTE pbJsonExt; PWEBAUTHN_HMAC_SECRET_SALT pPRFGlobalEval; DWORD
	// cCredentialHints; LPCWSTR *ppwszCredentialHints; BOOL bThirdPartyPayment; PCWSTR pwszRemoteWebOrigin; DWORD
	// cbPublicKeyCredentialCreationOptionsJSON; PBYTE pbPublicKeyCredentialCreationOptionsJSON; DWORD cbAuthenticatorId; PBYTE
	// pbAuthenticatorId; } WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS, *PWEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS()
	{
		/// <summary>Version of this structure.</summary>
		public uint dwVersion = WEBAUTHN_AUTHENTICATOR_MAKE_CREDENTIAL_OPTIONS_CURRENT_VERSION;

		/// <summary>Time that the operation is expected to complete within. This is used as guidance, and can be overridden by the platform.</summary>
		public uint dwTimeoutMilliseconds;

		/// <summary>
		/// A <c>WEBAUTHN_CREDENTIALS</c> structure that specifies credentials to exclude. If a matching credential already exists on the
		/// authenticator, the operation fails.
		/// </summary>
		public WEBAUTHN_CREDENTIALS CredentialList;

		/// <summary>A <c>WEBAUTHN_EXTENSIONS</c> structure that contains optional extensions to parse when performing the operation.</summary>
		public WEBAUTHN_EXTENSIONS Extensions;

		/// <summary>Optional platform vs cross-platform authenticators.</summary>
		public WEBAUTHN_AUTHENTICATOR_ATTACHMENT dwAuthenticatorAttachment;

		/// <summary>Require key to be resident or not. This is optional and defaults to <b>FALSE</b>.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bRequireResidentKey;

		/// <summary>The user verification requirement.</summary>
		public WEBAUTHN_USER_VERIFICATION_REQUIREMENT dwUserVerificationRequirement;

		/// <summary>The attestation conveyance preference.</summary>
		public WEBAUTHN_ATTESTATION_CONVEYANCE_PREFERENCE dwAttestationConveyancePreference;

		/// <summary>The flags (reserved for future use).</summary>
		public uint dwFlags;

		/// <summary>The optional cancellation Id. See <c>WebAuthNGetCancellationId</c> for more information.</summary>
		public GuidPtr pCancellationId;

		/// <summary>
		/// An optional pointer to a <c>WEBAUTHN_CREDENTIAL_LIST</c> that specifies credentials to exclude. If present, <b>CredentialList</b>
		/// is ignored.
		/// </summary>
		public ManagedStructPointer<WEBAUTHN_CREDENTIAL_LIST> pExcludeCredentialList;

		/// <summary>The enterprise attestation.</summary>
		public WEBAUTHN_ENTERPRISE_ATTESTATION dwEnterpriseAttestation;

		/// <summary>
		/// The requested large blob support: <b>none</b>, <b>required</b> or <b>preferred</b>. User will receive
		/// <b>NTE_INVALID_PARAMETER</b> when large blob is set to <b>required</b> or <b>preferred</b> and <b>bRequireResidentKey</b> isn't
		/// set to <b>TRUE</b>.
		/// </summary>
		public WEBAUTHN_LARGE_BLOB_SUPPORT dwLargeBlobSupport;

		/// <summary>Prefer key to be resident. Optional parameter, defaulting to <b>FALSE</b>. When <b>TRUE</b>, overrides <b>bRequireResidentKey</b>.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bPreferResidentKey;

		/// <summary>Indicates whether the client is using in-private mode in the browser. An optional parameter that defaults to <b>FALSE</b>.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bBrowserInPrivateMode;

		/// <summary/>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bEnablePrf;

		/// <summary/>
		public ManagedStructPointer<CTAPCBOR_HYBRID_STORAGE_LINKED_DATA> pLinkedDevice;

		/// <summary/>
		public uint cbJsonExt;

		/// <summary/>
		[SizeDef(nameof(cbJsonExt))]
		public ArrayPointer<byte> pbJsonExt;

		/// <summary/>
		public StructPointer<WEBAUTHN_HMAC_SECRET_SALT> pPRFGlobalEval;

		/// <summary/>
		public uint cCredentialHints;

		/// <summary/>
		[SizeDef(nameof(cCredentialHints))]
		public ArrayPointer<StrPtrUni> ppwszCredentialHints;

		/// <summary/>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bThirdPartyPayment;

		/// <summary/>
		public string? pwszRemoteWebOrigin;

		/// <summary/>
		public uint cbPublicKeyCredentialCreationOptionsJSON;

		/// <summary/>
		[SizeDef(nameof(cbPublicKeyCredentialCreationOptionsJSON))]
		public ArrayPointer<byte> pbPublicKeyCredentialCreationOptionsJSON;

		/// <summary>
		/// The size, in bytes, of the authenticator ID pointed to by <b>pbAuthenticatorId</b>. Set to 0 if not targeting a specific authenticator.
		/// </summary>
		public uint cbAuthenticatorId;

		/// <summary>
		/// An optional pointer to the ID of a specific authenticator to target for this operation. Obtain authenticator IDs by calling
		/// <c>WebAuthNGetAuthenticatorList</c>. Set to <b>NULL</b> to use the default authenticator selection behavior.
		/// </summary>
		[SizeDef(nameof(cbAuthenticatorId))]
		public ArrayPointer<byte> pbAuthenticatorId;
	}

	/// <summary>Contains the client data to be sent to the authenticator.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_client_data typedef struct _WEBAUTHN_CLIENT_DATA {
	// DWORD dwVersion; DWORD cbClientDataJSON; PBYTE pbClientDataJSON; LPCWSTR pwszHashAlgId; } WEBAUTHN_CLIENT_DATA, *PWEBAUTHN_CLIENT_DATA;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_CLIENT_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CLIENT_DATA()
	{
		/// <summary>
		/// Version of this structure, to allow for modifications in the future. This field is required and should be set to <b>CURRENT_VERSION</b>.
		/// </summary>
		public uint dwVersion = WEBAUTHN_CLIENT_DATA_CURRENT_VERSION;

		/// <summary>The size, in bytes, of the JSON data pointed to by <b>pbClientDataJSON</b>.</summary>
		public uint cbClientDataJSON;

		/// <summary>UTF-8 encoded JSON serialization of the client data.</summary>
		[SizeDef(nameof(cbClientDataJSON))]
		public ArrayPointer<byte> pbClientDataJSON;

		/// <summary>Hash algorithm ID used to hash the <b>pbClientDataJSON</b> field.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszHashAlgId;
	}

	/// <summary>Contains common attestation data shared across attestation statement formats.</summary>
	// https://learn.microsoft.com/hi-in/windows/win32/api/webauthn/ns-webauthn-webauthn_common_attestation typedef struct
	// _WEBAUTHN_COMMON_ATTESTATION { DWORD dwVersion; PCWSTR pwszAlg; LONG lAlg; DWORD cbSignature; PBYTE pbSignature; DWORD cX5c;
	// PWEBAUTHN_X5C pX5c; PCWSTR pwszVer; DWORD cbCertInfo; PBYTE pbCertInfo; DWORD cbPubArea; PBYTE pbPubArea; }
	// WEBAUTHN_COMMON_ATTESTATION, *PWEBAUTHN_COMMON_ATTESTATION;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_COMMON_ATTESTATION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_COMMON_ATTESTATION()
	{
		/// <summary>
		/// Version of this structure, to allow for modifications in the future. This field is required and should be set to <b>CURRENT_VERSION</b>.
		/// </summary>
		public uint dwVersion = WEBAUTHN_COMMON_ATTESTATION_CURRENT_VERSION;

		/// <summary>The hash and padding algorithm. This won't be set for fido-u2f which assumes <b>"ES256"</b>.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszAlg;

		/// <summary>
		/// The COSE algorithm identifier. This value is a number identifying a cryptographic algorithm. The algorithm identifiers should be
		/// values registered in the <c>IANA COSE Algorithms registry</c>, for instance, -7 for "ES256" and -257 for "RS256".
		/// </summary>
		public int lAlg;

		/// <summary>The size, in bytes, of the signature pointed to by <b>pbSignature</b>.</summary>
		public uint cbSignature;

		/// <summary>A pointer to the signature generated for this attestation.</summary>
		[SizeDef(nameof(cbSignature))]
		public ArrayPointer<byte> pbSignature;

		/// <summary>
		/// The number of X.509 DER-encoded certificates in the <b>pX5c</b> array. The first certificate is the signer (leaf) certificate. If
		/// zero, this is a self attestation.
		/// </summary>
		public uint cX5c;

		/// <summary>A pointer to an array of <c>WEBAUTHN_X5C</c> structures that contain the X.509 certificate chain.</summary>
		[SizeDef(nameof(cX5c))]
		public ManagedArrayPointer<WEBAUTHN_X5C> pX5c;

		/// <summary>A pointer to the version string of the attestation statement. Set for TPM attestation.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszVer;

		/// <summary>The size, in bytes, of the certificate information pointed to by <b>pbCertInfo</b>. Set for TPM attestation.</summary>
		public uint cbCertInfo;

		/// <summary>A pointer to the certificate information. Set for TPM attestation.</summary>
		[SizeDef(nameof(cbCertInfo))]
		public ArrayPointer<byte> pbCertInfo;

		/// <summary>The size, in bytes, of the public key area pointed to by <b>pbPubArea</b>. Set for TPM attestation.</summary>
		public uint cbPubArea;

		/// <summary>A pointer to the public key area. Set for TPM attestation.</summary>
		[SizeDef(nameof(cbPubArea))]
		public ArrayPointer<byte> pbPubArea;
	}

	/// <summary>Contains a single COSE credential type and algorithm pair requested by the Relying Party.</summary>
	// https://learn.microsoft.com/en-au/windows/win32/api/webauthn/ns-webauthn-webauthn_cose_credential_parameter typedef struct
	// _WEBAUTHN_COSE_CREDENTIAL_PARAMETER { DWORD dwVersion; LPCWSTR pwszCredentialType; LONG lAlg; } WEBAUTHN_COSE_CREDENTIAL_PARAMETER, *PWEBAUTHN_COSE_CREDENTIAL_PARAMETER;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_COSE_CREDENTIAL_PARAMETER")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_COSE_CREDENTIAL_PARAMETER()
	{
		/// <summary>
		/// Version of this structure, to allow for modifications in the future. This field is required and should be set to <b>CURRENT_VERSION</b>.
		/// </summary>
		public uint dwVersion = WEBAUTHN_COSE_CREDENTIAL_PARAMETER_CURRENT_VERSION;

		/// <summary>Well-known credential type specifying a credential to create.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszCredentialType;

		/// <summary>Well-known COSE algorithm specifying the algorithm to use for the credential.</summary>
		public int lAlg;
	}

	/// <summary>
	/// Contains an array of <c>WEBAUTHN_COSE_CREDENTIAL_PARAMETER</c> structures that specify the Relying Party's preferred credential types
	/// and algorithms.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_cose_credential_parameters typedef struct
	// _WEBAUTHN_COSE_CREDENTIAL_PARAMETERS { DWORD cCredentialParameters; PWEBAUTHN_COSE_CREDENTIAL_PARAMETER pCredentialParameters; }
	// WEBAUTHN_COSE_CREDENTIAL_PARAMETERS, *PWEBAUTHN_COSE_CREDENTIAL_PARAMETERS;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_COSE_CREDENTIAL_PARAMETERS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_COSE_CREDENTIAL_PARAMETERS : IArrayStruct<WEBAUTHN_COSE_CREDENTIAL_PARAMETER>
	{
		/// <summary>The number of elements in the <b>pCredentialParameters</b> array.</summary>
		public uint cCredentialParameters;

		/// <summary>A pointer to an array of <c>WEBAUTHN_COSE_CREDENTIAL_PARAMETER</c> structures.</summary>
		[SizeDef(nameof(cCredentialParameters))]
		public ManagedArrayPointer<WEBAUTHN_COSE_CREDENTIAL_PARAMETER> pCredentialParameters;
	}

	/// <summary>Contains the credBlob extension data for a credential.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_cred_blob_extension typedef struct
	// _WEBAUTHN_CRED_BLOB_EXTENSION { DWORD cbCredBlob; PBYTE pbCredBlob; } WEBAUTHN_CRED_BLOB_EXTENSION, *PWEBAUTHN_CRED_BLOB_EXTENSION;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_CRED_BLOB_EXTENSION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CRED_BLOB_EXTENSION
	{
		/// <summary>The size, in bytes, of the data pointed to by <b>pbCredBlob</b>.</summary>
		public uint cbCredBlob;

		/// <summary>A pointer to the credential blob data.</summary>
		public IntPtr pbCredBlob;
	}

	/// <summary>Contains the input parameters for the credProtect extension.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_cred_protect_extension_in typedef struct
	// _WEBAUTHN_CRED_PROTECT_EXTENSION_IN { DWORD dwCredProtect; BOOL bRequireCredProtect; } WEBAUTHN_CRED_PROTECT_EXTENSION_IN, *PWEBAUTHN_CRED_PROTECT_EXTENSION_IN;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_CRED_PROTECT_EXTENSION_IN")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CRED_PROTECT_EXTENSION_IN
	{
		/// <summary>One of the <b>WEBAUTHN_USER_VERIFICATION_*</b> values that specifies the credential protection policy.</summary>
		public WEBAUTHN_USER_VERIFICATION dwCredProtect;

		/// <summary>
		/// Set to <b>TRUE</b> to require authenticator support for the <b>credProtect</b> extension. If the authenticator does not support
		/// it, the operation fails.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bRequireCredProtect;
	}

	/// <summary>Contains a credential ID paired with HMAC secret salt values for use with the PRF extension.</summary>
	// https://learn.microsoft.com/sv-se/windows/win32/api/webauthn/ns-webauthn-webauthn_cred_with_hmac_secret_salt typedef struct
	// _WEBAUTHN_CRED_WITH_HMAC_SECRET_SALT { DWORD cbCredID; PBYTE pbCredID; PWEBAUTHN_HMAC_SECRET_SALT pHmacSecretSalt; }
	// WEBAUTHN_CRED_WITH_HMAC_SECRET_SALT, *PWEBAUTHN_CRED_WITH_HMAC_SECRET_SALT;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_CRED_WITH_HMAC_SECRET_SALT")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CRED_WITH_HMAC_SECRET_SALT
	{
		/// <summary>The size, in bytes, of the credential ID pointed to by <b>pbCredID</b>.</summary>
		public uint cbCredID;

		/// <summary>A pointer to the credential ID.</summary>
		public IntPtr pbCredID;

		/// <summary>A pointer to a <c>WEBAUTHN_HMAC_SECRET_SALT</c> structure that contains the PRF salt values for this credential.</summary>
		public StructPointer<WEBAUTHN_HMAC_SECRET_SALT> pHmacSecretSalt;
	}

	/// <summary>Contains information about a credential.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_credential typedef struct _WEBAUTHN_CREDENTIAL {
	// DWORD dwVersion; DWORD cbId; PBYTE pbId; PCWSTR pwszCredentialType; } WEBAUTHN_CREDENTIAL, *PWEBAUTHN_CREDENTIAL;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_CREDENTIAL")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CREDENTIAL()
	{
		/// <summary>
		/// Version of this structure, to allow for modifications in the future. This field is required and should be set to <b>CURRENT_VERSION</b>.
		/// </summary>
		public uint dwVersion = WEBAUTHN_CREDENTIAL_CURRENT_VERSION;

		/// <summary>The size, in bytes, of the credential ID pointed to by <b>pbId</b>.</summary>
		public uint cbId;

		/// <summary>A pointer to the unique identifier for this credential.</summary>
		[SizeDef(nameof(cbId))]
		public ArrayPointer<byte> pbId;

		/// <summary>Well-known credential type specifying the type of this particular credential.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszCredentialType;
	}

	/// <summary>Contains the attestation data returned by the authenticator after creating a credential.</summary>
	/// <remarks>
	/// <para>The <b>pvAttestationDecode</b> depends on the <b>dwAttestationDecodeType</b>:</para>
	/// <list type="table">
	/// <listheader>
	/// <description><b>Decode type</b></description>
	/// <description><b>Decode value</b></description>
	/// </listheader>
	/// <item>
	/// <description><b>WEBAUTHN_ATTESTATION_DECODE_NONE</b></description>
	/// <description><b>NULL</b> - not able to decode the CBOR attestation information</description>
	/// </item>
	/// <item>
	/// <description><b>WEBAUTHN_ATTESTATION_DECODE_COMMON</b></description>
	/// <description><b>PWEBAUTHN_COMMON_ATTESTATION</b></description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_credential_attestation typedef struct
	// _WEBAUTHN_CREDENTIAL_ATTESTATION { DWORD dwVersion; PCWSTR pwszFormatType; DWORD cbAuthenticatorData; PBYTE pbAuthenticatorData; DWORD
	// cbAttestation; PBYTE pbAttestation; DWORD dwAttestationDecodeType; PVOID pvAttestationDecode; DWORD cbAttestationObject; PBYTE
	// pbAttestationObject; DWORD cbCredentialId; PBYTE pbCredentialId; WEBAUTHN_EXTENSIONS Extensions; DWORD dwUsedTransport; BOOL bEpAtt;
	// BOOL bLargeBlobSupported; BOOL bResidentKey; BOOL bPrfEnabled; DWORD cbUnsignedExtensionOutputs; PBYTE pbUnsignedExtensionOutputs;
	// PWEBAUTHN_HMAC_SECRET_SALT pHmacSecret; BOOL bThirdPartyPayment; DWORD dwTransports; DWORD cbClientDataJSON; PBYTE pbClientDataJSON;
	// DWORD cbRegistrationResponseJSON; PBYTE pbRegistrationResponseJSON; } WEBAUTHN_CREDENTIAL_ATTESTATION, *PWEBAUTHN_CREDENTIAL_ATTESTATION;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_CREDENTIAL_ATTESTATION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CREDENTIAL_ATTESTATION()
	{
		/// <summary>
		/// Version of this structure, to allow for modifications in the future. This field is required and should be set to <b>CURRENT_VERSION</b>.
		/// </summary>
		public uint dwVersion = WEBAUTHN_CREDENTIAL_ATTESTATION_CURRENT_VERSION;

		/// <summary>The attestation format type.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszFormatType;

		/// <summary>The size, in bytes, of the authenticator data pointed to by <b>pbAuthenticatorData</b>.</summary>
		public uint cbAuthenticatorData;

		/// <summary>The authenticator data that was created for this credential.</summary>
		[SizeDef(nameof(cbAuthenticatorData))]
		public ArrayPointer<byte> pbAuthenticatorData;

		/// <summary>The size, in bytes, of the CBOR-encoded attestation information pointed to by <b>pbAttestation</b>.</summary>
		public uint cbAttestation;

		/// <summary>A pointer to the CBOR-encoded attestation information.</summary>
		[SizeDef(nameof(cbAttestation))]
		public ArrayPointer<byte> pbAttestation;

		/// <summary>The type used to decode <b>pvAttestationDecode</b>. See Remarks for possible values.</summary>
		public WEBAUTHN_ATTESTATION_DECODE dwAttestationDecodeType;

		/// <summary>A pointer to the decoded attestation data. The type depends on <b>dwAttestationDecodeType</b>. See Remarks for details.</summary>
		public IntPtr pvAttestationDecode;

		/// <summary>The size, in bytes, of the attestation object pointed to by <b>pbAttestationObject</b>.</summary>
		public uint cbAttestationObject;

		/// <summary>The CBOR encoded Attestation Object to be returned to the Relying Party.</summary>
		[SizeDef(nameof(cbAttestationObject))]
		public ArrayPointer<byte> pbAttestationObject;

		/// <summary>The size, in bytes, of the credential ID pointed to by <b>pbCredentialId</b>.</summary>
		public uint cbCredentialId;

		/// <summary>The CredentialId bytes extracted from the Authenticator Data. Used by Edge to return to the Relying Party.</summary>
		[SizeDef(nameof(cbCredentialId))]
		public ArrayPointer<byte> pbCredentialId;

		/// <summary>A <c>WEBAUTHN_EXTENSIONS</c> structure that contains the authenticator extension outputs for this credential.</summary>
		public WEBAUTHN_EXTENSIONS Extensions;

		/// <summary>A bitmask of <b>WEBAUTHN_CTAP_TRANSPORT_*</b> values indicating which transport was used.</summary>
		public WEBAUTHN_CTAP_TRANSPORT dwUsedTransport;

		/// <summary><b>TRUE</b> if the credential has enterprise attestation.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bEpAtt;

		/// <summary><b>TRUE</b> if the authenticator supports the large blob extension for this credential.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bLargeBlobSupported;

		/// <summary><b>TRUE</b> if the credential was created as a resident (discoverable) key.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bResidentKey;

		/// <summary/>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bPrfEnabled;

		/// <summary/>
		public uint cbUnsignedExtensionOutputs;

		/// <summary/>
		[SizeDef(nameof(cbUnsignedExtensionOutputs))]
		public ArrayPointer<byte> pbUnsignedExtensionOutputs;

		/// <summary/>
		public StructPointer<WEBAUTHN_HMAC_SECRET_SALT> pHmacSecret;

		/// <summary/>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bThirdPartyPayment;

		/// <summary/>
		public WEBAUTHN_CTAP_TRANSPORT dwTransports;

		/// <summary/>
		public uint cbClientDataJSON;

		/// <summary/>
		[SizeDef(nameof(cbClientDataJSON))]
		public ArrayPointer<byte> pbClientDataJSON;

		/// <summary/>
		public uint cbRegistrationResponseJSON;

		/// <summary/>
		[SizeDef(nameof(cbRegistrationResponseJSON))]
		public ArrayPointer<byte> pbRegistrationResponseJSON;
	}

	/// <summary>Contains detailed information about a platform credential stored on the authenticator.</summary>
	// https://learn.microsoft.com/nl-nl/windows/win32/api/webauthn/ns-webauthn-webauthn_credential_details typedef struct
	// _WEBAUTHN_CREDENTIAL_DETAILS { DWORD dwVersion; DWORD cbCredentialID; PBYTE pbCredentialID; PWEBAUTHN_RP_ENTITY_INFORMATION
	// pRpInformation; PWEBAUTHN_USER_ENTITY_INFORMATION pUserInformation; BOOL bRemovable; BOOL bBackedUp; } WEBAUTHN_CREDENTIAL_DETAILS, *PWEBAUTHN_CREDENTIAL_DETAILS;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_CREDENTIAL_DETAILS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CREDENTIAL_DETAILS()
	{
		/// <summary>
		/// Version of this structure, to allow for modifications in the future. This field is required and should be set to <b>CURRENT_VERSION</b>.
		/// </summary>
		public uint dwVersion = WEBAUTHN_CREDENTIAL_DETAILS_CURRENT_VERSION;

		/// <summary>The size, in bytes, of the credential ID pointed to by <b>pbCredentialID</b>.</summary>
		public uint cbCredentialID;

		/// <summary>A pointer to the credential ID.</summary>
		[SizeDef(nameof(cbCredentialID))]
		public ArrayPointer<byte> pbCredentialID;

		/// <summary>
		/// A pointer to a <c>WEBAUTHN_RP_ENTITY_INFORMATION</c> structure that identifies the Relying Party this credential is registered with.
		/// </summary>
		public ManagedStructPointer<WEBAUTHN_RP_ENTITY_INFORMATION> pRpInformation;

		/// <summary>
		/// A pointer to a <c>WEBAUTHN_USER_ENTITY_INFORMATION</c> structure that identifies the user account associated with this credential.
		/// </summary>
		public ManagedStructPointer<WEBAUTHN_USER_ENTITY_INFORMATION> pUserInformation;

		/// <summary><b>TRUE</b> if this credential can be removed from the authenticator.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bRemovable;

		/// <summary><b>TRUE</b> if this credential has been backed up.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bBackedUp;

		/// <summary/>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszAuthenticatorName;

		/// <summary/>
		public uint cbAuthenticatorLogo;

		/// <summary/>
		[SizeDef(nameof(cbAuthenticatorLogo))]
		public ArrayPointer<byte> pbAuthenticatorLogo;

		/// <summary/>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bThirdPartyPayment;

		/// <summary/>
		public WEBAUTHN_CTAP_TRANSPORT dwTransports;
	}

	/// <summary>Contains a list of <c>WEBAUTHN_CREDENTIAL_DETAILS</c> structures returned by <c>WebAuthNGetPlatformCredentialList</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_credential_details_list typedef struct
	// _WEBAUTHN_CREDENTIAL_DETAILS_LIST { DWORD cCredentialDetails; PWEBAUTHN_CREDENTIAL_DETAILS *ppCredentialDetails; }
	// WEBAUTHN_CREDENTIAL_DETAILS_LIST, *PWEBAUTHN_CREDENTIAL_DETAILS_LIST;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_CREDENTIAL_DETAILS_LIST")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CREDENTIAL_DETAILS_LIST : IArrayStruct<WEBAUTHN_CREDENTIAL_DETAILS>
	{
		/// <summary>The number of elements in the <b>ppCredentialDetails</b> array.</summary>
		public uint cCredentialDetails;

		/// <summary>A pointer to an array of pointers to <c>WEBAUTHN_CREDENTIAL_DETAILS</c> structures.</summary>
		[SizeDef(nameof(cCredentialDetails))]
		public ManagedArrayPointer<WEBAUTHN_CREDENTIAL_DETAILS> ppCredentialDetails;
	}

	/// <summary>Contains information about a credential, including transport hints.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_credential_ex typedef struct _WEBAUTHN_CREDENTIAL_EX
	// { DWORD dwVersion; DWORD cbId; PBYTE pbId; LPCWSTR pwszCredentialType; DWORD dwTransports; } WEBAUTHN_CREDENTIAL_EX, *PWEBAUTHN_CREDENTIAL_EX;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_CREDENTIAL_EX")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CREDENTIAL_EX()
	{
		/// <summary>
		/// Version of this structure, to allow for modifications in the future. This field is required and should be set to <b>CURRENT_VERSION</b>.
		/// </summary>
		public uint dwVersion = WEBAUTHN_CREDENTIAL_EX_CURRENT_VERSION;

		/// <summary>The size, in bytes, of the credential ID pointed to by <b>pbId</b>.</summary>
		public uint cbId;

		/// <summary>A pointer to the unique identifier for this credential.</summary>
		[SizeDef(nameof(cbId))]
		public ArrayPointer<byte> pbId;

		/// <summary>Well-known credential type specifying the type of this credential.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszCredentialType;

		/// <summary>
		/// A bitmask of <b>WEBAUTHN_CTAP_TRANSPORT_*</b> values that indicate the transports the credential is available on. A value of
		/// <b>0</b> implies no transport restrictions.
		/// </summary>
		public WEBAUTHN_CTAP_TRANSPORT dwTransports;
	}

	/// <summary>Contains an array of <c>WEBAUTHN_CREDENTIAL_EX</c> structures.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_credential_list typedef struct
	// _WEBAUTHN_CREDENTIAL_LIST { DWORD cCredentials; PWEBAUTHN_CREDENTIAL_EX *ppCredentials; } WEBAUTHN_CREDENTIAL_LIST, *PWEBAUTHN_CREDENTIAL_LIST;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_CREDENTIAL_LIST")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CREDENTIAL_LIST : IArrayStruct<WEBAUTHN_CREDENTIAL_EX>
	{
		/// <summary>The number of elements in the <b>ppCredentials</b> array.</summary>
		public uint cCredentials;

		/// <summary>A pointer to an array of pointers to <c>WEBAUTHN_CREDENTIAL_EX</c> structures.</summary>
		[SizeDef(nameof(cCredentials))]
		public ManagedArrayPointer<WEBAUTHN_CREDENTIAL_EX> ppCredentials;
	}

	/// <summary>Contains an array of <c>WEBAUTHN_CREDENTIAL</c> structures.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_credentials typedef struct _WEBAUTHN_CREDENTIALS {
	// DWORD cCredentials; PWEBAUTHN_CREDENTIAL pCredentials; } WEBAUTHN_CREDENTIALS, *PWEBAUTHN_CREDENTIALS;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_CREDENTIALS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CREDENTIALS : IArrayStruct<WEBAUTHN_CREDENTIAL>
	{
		/// <summary>The number of elements in the <b>pCredentials</b> array.</summary>
		public uint cCredentials;

		/// <summary>A pointer to an array of <c>WEBAUTHN_CREDENTIAL</c> structures.</summary>
		[SizeDef(nameof(cCredentials))]
		public ManagedArrayPointer<WEBAUTHN_CREDENTIAL> pCredentials;
	}

	/// <summary>Contains a single WebAuthn extension with its identifier and data.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_extension typedef struct _WEBAUTHN_EXTENSION {
	// LPCWSTR pwszExtensionIdentifier; DWORD cbExtension; PVOID pvExtension; } WEBAUTHN_EXTENSION, *PWEBAUTHN_EXTENSION;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_EXTENSION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_EXTENSION
	{
		/// <summary>A pointer to a null-terminated string that contains the extension identifier.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszExtensionIdentifier;

		/// <summary>The size, in bytes, of the extension data pointed to by <b>pvExtension</b>.</summary>
		public uint cbExtension;

		/// <summary>A pointer to the CBOR-encoded extension data.</summary>
		[SizeDef(nameof(cbExtension))]
		public ArrayPointer<byte> pvExtension;
	}

	/// <summary>Contains an array of <c>WEBAUTHN_EXTENSION</c> structures.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_extensions typedef struct _WEBAUTHN_EXTENSIONS {
	// DWORD cExtensions; PWEBAUTHN_EXTENSION pExtensions; } WEBAUTHN_EXTENSIONS, *PWEBAUTHN_EXTENSIONS;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_EXTENSIONS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_EXTENSIONS : IArrayStruct<WEBAUTHN_EXTENSION>
	{
		/// <summary>The number of elements in the <b>pExtensions</b> array.</summary>
		public uint cExtensions;

		/// <summary>A pointer to an array of <c>WEBAUTHN_EXTENSION</c> structures.</summary>
		[SizeDef(nameof(cExtensions))]
		public ManagedArrayPointer<WEBAUTHN_EXTENSION> pExtensions;
	}

	/// <summary>Contains options for the <c>WebAuthNGetPlatformCredentialList</c> function.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_get_credentials_options typedef struct
	// _WEBAUTHN_GET_CREDENTIALS_OPTIONS { DWORD dwVersion; LPCWSTR pwszRpId; BOOL bBrowserInPrivateMode; } WEBAUTHN_GET_CREDENTIALS_OPTIONS, *PWEBAUTHN_GET_CREDENTIALS_OPTIONS;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_GET_CREDENTIALS_OPTIONS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_GET_CREDENTIALS_OPTIONS()
	{
		/// <summary>
		/// Version of this structure, to allow for modifications in the future. This field is required and should be set to <b>CURRENT_VERSION</b>.
		/// </summary>
		public uint dwVersion = WEBAUTHN_GET_CREDENTIALS_OPTIONS_CURRENT_VERSION;

		/// <summary>An optional pointer to a null-terminated string that specifies the Relying Party ID to filter credentials by.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszRpId;

		/// <summary><b>TRUE</b> if the browser is in private (InPrivate) mode. Optional, defaults to <b>FALSE</b>.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bBrowserInPrivateMode;
	}

	/// <summary>Contains the salt values for the HMAC-SECRET extension (PRF).</summary>
	/// <remarks>SALT values, by default, are converted into RAW Hmac-Secret values as per PRF extension.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_hmac_secret_salt typedef struct
	// _WEBAUTHN_HMAC_SECRET_SALT { DWORD cbFirst; PBYTE pbFirst; DWORD cbSecond; PBYTE pbSecond; } WEBAUTHN_HMAC_SECRET_SALT, *PWEBAUTHN_HMAC_SECRET_SALT;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_HMAC_SECRET_SALT")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_HMAC_SECRET_SALT
	{
		/// <summary>The size, in bytes, of the first salt value pointed to by <b>pbFirst</b>.</summary>
		public uint cbFirst;

		/// <summary>A pointer to the first salt value.</summary>
		[SizeDef(nameof(cbFirst))]
		public ArrayPointer<byte> pbFirst;

		/// <summary>The size, in bytes, of the second salt value pointed to by <b>pbSecond</b>.</summary>
		public uint cbSecond;

		/// <summary>A pointer to the optional second salt value.</summary>
		[SizeDef(nameof(cbSecond))]
		public ArrayPointer<byte> pbSecond;
	}

	/// <summary>Contains HMAC secret salt values, including a global salt and optional per-credential salts for use with the PRF extension.</summary>
	// https://learn.microsoft.com/nb-no/windows/win32/api/webauthn/ns-webauthn-webauthn_hmac_secret_salt_values typedef struct
	// _WEBAUTHN_HMAC_SECRET_SALT_VALUES { PWEBAUTHN_HMAC_SECRET_SALT pGlobalHmacSalt; DWORD cCredWithHmacSecretSaltList;
	// PWEBAUTHN_CRED_WITH_HMAC_SECRET_SALT pCredWithHmacSecretSaltList; } WEBAUTHN_HMAC_SECRET_SALT_VALUES, *PWEBAUTHN_HMAC_SECRET_SALT_VALUES;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_HMAC_SECRET_SALT_VALUES")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_HMAC_SECRET_SALT_VALUES
	{
		/// <summary>A pointer to a <c>WEBAUTHN_HMAC_SECRET_SALT</c> structure that contains the global HMAC salt applied to all credentials.</summary>
		public StructPointer<WEBAUTHN_HMAC_SECRET_SALT> pGlobalHmacSalt;

		/// <summary>The number of elements in the <b>pCredWithHmacSecretSaltList</b> array.</summary>
		public uint cCredWithHmacSecretSaltList;

		/// <summary>A pointer to an array of <c>WEBAUTHN_CRED_WITH_HMAC_SECRET_SALT</c> structures that contain per-credential salt values.</summary>
		[SizeDef(nameof(cCredWithHmacSecretSaltList))]
		public ManagedArrayPointer<WEBAUTHN_CRED_WITH_HMAC_SECRET_SALT> pCredWithHmacSecretSaltList;
	}

	/// <summary>Contains information about the Relying Party that is requesting the WebAuthn operation.</summary>
	// https://learn.microsoft.com/en-my/windows/win32/api/webauthn/ns-webauthn-webauthn_rp_entity_information typedef struct
	// _WEBAUTHN_RP_ENTITY_INFORMATION { DWORD dwVersion; PCWSTR pwszId; PCWSTR pwszName; PCWSTR pwszIcon; } WEBAUTHN_RP_ENTITY_INFORMATION, *PWEBAUTHN_RP_ENTITY_INFORMATION;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_RP_ENTITY_INFORMATION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_RP_ENTITY_INFORMATION()
	{
		/// <summary>
		/// Version of this structure, to allow for modifications in the future. This field is required and should be set to <b>CURRENT_VERSION</b>.
		/// </summary>
		public uint dwVersion = WEBAUTHN_RP_ENTITY_INFORMATION_CURRENT_VERSION;

		/// <summary>Identifier for the Relying Party. This field is required.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszId;

		/// <summary>
		/// Contains the friendly name of the Relying Party, such as "Acme Corporation", "Widgets Inc", or "Contoso". This field is required.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszName;

		/// <summary>Optional URL pointing to the Relying Party's logo.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszIcon;
	}

	/// <summary>Contains information about the user account for which a credential is being created or used.</summary>
	// https://learn.microsoft.com/nl-nl/windows/win32/api/webauthn/ns-webauthn-webauthn_user_entity_information typedef struct
	// _WEBAUTHN_USER_ENTITY_INFORMATION { DWORD dwVersion; DWORD cbId; PBYTE pbId; PCWSTR pwszName; PCWSTR pwszIcon; PCWSTR pwszDisplayName;
	// } WEBAUTHN_USER_ENTITY_INFORMATION, *PWEBAUTHN_USER_ENTITY_INFORMATION;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_USER_ENTITY_INFORMATION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_USER_ENTITY_INFORMATION()
	{
		/// <summary>
		/// Version of this structure, to allow for modifications in the future. This field is required and should be set to <b>CURRENT_VERSION</b>.
		/// </summary>
		public uint dwVersion = WEBAUTHN_USER_ENTITY_INFORMATION_CURRENT_VERSION;

		/// <summary>The size, in bytes, of the user handle pointed to by <b>pbId</b>.</summary>
		public uint cbId;

		/// <summary>
		/// A pointer to the user handle. This field is required. The Relying Party sets this to a unique, opaque identifier for the user account.
		/// </summary>
		[SizeDef(nameof(cbId))]
		public ArrayPointer<byte> pbId;

		/// <summary>Contains a detailed name for this account, such as "john.p.smith@example.com".</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszName;

		/// <summary>
		/// Optional URL that can be used to retrieve an image containing the user's current avatar or a data URI that contains the image data.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszIcon;

		/// <summary>Contains the friendly name associated with the user account by the Relying Party, such as "John P. Smith".</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszDisplayName;
	}

	/// <summary>Contains a single X.509 DER-encoded certificate.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthn/ns-webauthn-webauthn_x5c typedef struct _WEBAUTHN_X5C { DWORD cbData;
	// PBYTE pbData; } WEBAUTHN_X5C, *PWEBAUTHN_X5C;
	[PInvokeData("webauthn.h", MSDNShortId = "NS:webauthn._WEBAUTHN_X5C")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_X5C
	{
		/// <summary>The size, in bytes, of the certificate data pointed to by <b>pbData</b>.</summary>
		public uint cbData;

		/// <summary>A pointer to the X.509 DER-encoded certificate bytes.</summary>
		[SizeDef(nameof(cbData))]
		public ArrayPointer<byte> pbData;
	}

	/// <summary>Contains detailed information about a platform credential stored on the authenticator.</summary>
	public class AuthenticatorDetails
	{
		/// <summary>The unique identifier for the authenticator.</summary>
		public readonly byte[] Id;

		/// <summary><b>TRUE</b> if the authenticator is locked and cannot be used for authentication.</summary>
		public readonly bool Locked;

		/// <summary>The logo for the authenticator.</summary>
		public readonly byte[] Logo;

		/// <summary>The name of the authenticator.</summary>
		public readonly string? Name;

		internal AuthenticatorDetails(ref WEBAUTHN_AUTHENTICATOR_DETAILS details)
		{
			Locked = details.bLocked;
			Id = details.pbAuthenticatorId.ToArray((int)details.cbAuthenticatorId);
			Logo = details.pbAuthenticatorLogo.ToArray((int)details.cbAuthenticatorLogo);
			Name = details.pwszAuthenticatorName;
		}
	}

	/// <summary>Contains detailed information about a platform credential stored on the authenticator.</summary>
	public class CredentialDetails
	{
		/// <summary><b>TRUE</b> if this credential has been backed up.</summary>
		public readonly bool BackedUp;

		/// <summary>The credential ID.</summary>
		public readonly byte[] CredentialId;

		/// <summary>The logo for this credential.</summary>
		public readonly byte[] Logo;

		/// <summary>The name of the authenticator.</summary>
		public readonly string? Name;

		/// <summary>The icon of the relying party.</summary>
		public readonly string? RelyingPartyIcon;

		/// <summary>The ID of the relying party.</summary>
		public readonly string? RelyingPartyId;

		/// <summary>The name of the relying party.</summary>
		public readonly string? RelyingPartyName;

		/// <summary><b>TRUE</b> if this credential is removable.</summary>
		public readonly bool Removable;

		/// <summary><b>TRUE</b> if this credential can be used for third-party payments.</summary>
		public readonly bool ThirdPartyPayment;

		/// <summary>The transports supported by this credential.</summary>
		public readonly WEBAUTHN_CTAP_TRANSPORT Transports;

		/// <summary>The display name of the user.</summary>
		public readonly string? UserDisplayName;

		/// <summary>The icon of the user.</summary>
		public readonly string? UserIcon;

		/// <summary>The ID of the user.</summary>
		public readonly byte[] UserId;

		/// <summary>The name of the user.</summary>
		public readonly string? UserName;

		internal CredentialDetails(in WEBAUTHN_CREDENTIAL_DETAILS details)
		{
			CredentialId = details.pbCredentialID.ToArray((int)details.cbCredentialID);
			BackedUp = details.bBackedUp;
			Removable = details.bRemovable;
			ThirdPartyPayment = details.bThirdPartyPayment;
			Transports = details.dwTransports;
			Logo = details.pbAuthenticatorLogo.ToArray((int)details.cbAuthenticatorLogo);
			ref WEBAUTHN_RP_ENTITY_INFORMATION rpi = ref details.pRpInformation.AsRef();
			RelyingPartyId = rpi.pwszId;
			RelyingPartyName = rpi.pwszName;
			RelyingPartyIcon = rpi.pwszIcon;
			ref WEBAUTHN_USER_ENTITY_INFORMATION rui = ref details.pUserInformation.AsRef();
			UserName = rui.pwszName;
			UserDisplayName = rui.pwszDisplayName;
			UserIcon = rui.pwszIcon;
			UserId = rui.pbId.ToArray((int)rui.cbId);
			Name = details.pwszAuthenticatorName;
		}
	}

	/// <summary>
	/// A <see cref="SafeHandle"/> class for a <c>WEBAUTHN_ASSERTION</c> structure. This class is used to ensure that the unmanaged memory
	/// allocated for the structure is properly released.
	/// </summary>
	public partial class SafeWEBAUTHN_ASSERTION : SafeHANDLE
	{
		/// <summary>
		/// A <b>DWORD</b> value that indicates the status of the large blob operation. See the <c>WEBAUTHN_CRED_LARGE_BLOB_STATUS_*</c>
		/// status constants.
		/// </summary>
		public WEBAUTHN_CRED_LARGE_BLOB_STATUS dwCredLargeBlobStatus;

		/// <summary/>
		public uint dwUsedTransport;

		/// <summary>A <c>WEBAUTHN_CREDENTIAL</c> that identifies the credential used for this assertion.</summary>
		public ref WEBAUTHN_CREDENTIAL Credential => ref AsRef().Credential;

		/// <summary>A <c>WEBAUTHN_EXTENSIONS</c> structure that contains the authenticator extension outputs, if any.</summary>
		public ref WEBAUTHN_EXTENSIONS Extensions => ref AsRef().Extensions;

		/// <summary>
		/// Gets a value indicating whether the handle is valid and not closed. This property returns <b>TRUE</b> if the handle is valid and
		/// not closed; otherwise, it returns <b>FALSE</b>.
		/// </summary>
		public bool HasValue => !IsClosed && !IsInvalid;

		/// <summary>The authentication response JSON.</summary>
		public ReadOnlySpan<byte> pbAuthenticationResponseJSON => AsRef().pbAuthenticationResponseJSON.AsReadOnlySpan(AsRef().cbAuthenticationResponseJSON);

		/// <summary>The authenticator data.</summary>
		public ReadOnlySpan<byte> pbAuthenticatorData => AsRef().pbAuthenticatorData.AsReadOnlySpan(AsRef().cbAuthenticatorData);

		/// <summary/>
		public ReadOnlySpan<byte> pbClientDataJSON => AsRef().pbClientDataJSON.AsReadOnlySpan(AsRef().cbClientDataJSON);

		/// <summary>The large blob data associated with the credential.</summary>
		public ReadOnlySpan<byte> pbCredLargeBlob => AsRef().pbCredLargeBlob.AsReadOnlySpan(AsRef().cbCredLargeBlob);

		/// <summary>The signature generated for this assertion.</summary>
		public ReadOnlySpan<byte> pbSignature => AsRef().pbSignature.AsReadOnlySpan(AsRef().cbSignature);

		/// <summary/>
		public ReadOnlySpan<byte> pbUnsignedExtensionOutputs => AsRef().pbUnsignedExtensionOutputs.AsReadOnlySpan(AsRef().cbUnsignedExtensionOutputs);

		/// <summary>The user handle returned by the authenticator.</summary>
		public ReadOnlySpan<byte> pbUserId => AsRef().pbUserId.AsReadOnlySpan(AsRef().cbUserId);

		/// <summary>A pointer to a <c>WEBAUTHN_HMAC_SECRET_SALT</c> structure that contains the HMAC secret output.</summary>
		public ref WEBAUTHN_HMAC_SECRET_SALT pHmacSecret => ref AsRef().pHmacSecret.AsRef();

		/// <summary>Returns a reference to the <c>WEBAUTHN_ASSERTION</c> structure that this handle represents.</summary>
		/// <returns>A reference to the <c>WEBAUTHN_ASSERTION</c> structure.</returns>
		/// <exception cref="NullReferenceException"/>
		public ref WEBAUTHN_ASSERTION AsRef()
		{
			if (!HasValue) throw new NullReferenceException();
			return ref handle.AsRef<WEBAUTHN_ASSERTION>();
		}
		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { WebAuthNFreeAssertion(handle); return true; }
	}

	/// <summary>
	/// A <see cref="SafeHandle"/> class for a <c>WEBAUTHN_AUTHENTICATOR_DETAILS_LIST</c> structure. This class is used to ensure that the
	/// unmanaged memory
	/// </summary>
	public class SafeWEBAUTHN_AUTHENTICATOR_DETAILS_LIST : SafeHANDLE, IReadOnlyList<AuthenticatorDetails>
	{
		/// <summary>Gets the number of authenticator details in the list.</summary>
		public int Count => IsClosed || IsInvalid ? 0 : (int)handle.ToStructure<uint>();

		/// <summary>Gets the authenticator details at the specified index.</summary>
		/// <param name="index">The index of the authenticator details to get.</param>
		/// <returns>The authenticator details at the specified index.</returns>
		public AuthenticatorDetails this[int index]
		{
			get
			{
				if (IsClosed || IsInvalid)
					throw new InvalidOperationException();
				else if (index < 0 || index >= Count)
					throw new ArgumentOutOfRangeException(nameof(index));
				return new(ref AsRef().ppAuthenticatorDetails[index].AsRef());
			}
		}

		/// <summary>Returns a reference to the <c>WEBAUTHN_AUTHENTICATOR_DETAILS_LIST</c> structure that this handle represents.</summary>
		/// <returns>A reference to the <c>WEBAUTHN_AUTHENTICATOR_DETAILS_LIST</c> structure.</returns>
		/// <exception cref="InvalidOperationException">The handle is closed or invalid.</exception>
		public ref WEBAUTHN_AUTHENTICATOR_DETAILS_LIST AsRef() { if (IsClosed || IsInvalid) throw new InvalidOperationException(); return ref handle.AsRef<WEBAUTHN_AUTHENTICATOR_DETAILS_LIST>(); }

		/// <summary>Returns an enumerator that iterates through the authenticator details.</summary>
		/// <returns>An enumerator for the authenticator details.</returns>
		public IEnumerator<AuthenticatorDetails> GetEnumerator()
		{
			ref WEBAUTHN_AUTHENTICATOR_DETAILS_LIST l = ref AsRef();
			List<AuthenticatorDetails> list = [];
			foreach (StructPointer<WEBAUTHN_AUTHENTICATOR_DETAILS> p in l.ppAuthenticatorDetails.AsReadOnlySpan(l.cAuthenticatorDetails))
				list.Add(new AuthenticatorDetails(ref p.AsRef()));
			return list.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { WebAuthNFreeAuthenticatorList(handle); return true; }
	}

	/// <summary>
	/// A <see cref="SafeHandle"/> class for a <c>WEBAUTHN_CREDENTIAL_ATTESTATION</c> structure. This class is used to ensure that the unmanaged memory
	/// associated with the structure is properly released when the handle is no longer needed.
	/// </summary>
	public class SafeWEBAUTHN_CREDENTIAL_ATTESTATION : SafeHANDLE
	{
		/// <summary><b>TRUE</b> if the credential has enterprise attestation.</summary>
		public ref bool bEpAtt => ref AsRef().bEpAtt;

		/// <summary><b>TRUE</b> if the authenticator supports the large blob extension for this credential.</summary>
		public ref bool bLargeBlobSupported => ref AsRef().bLargeBlobSupported;

		/// <summary/>
		public ref bool bPrfEnabled => ref AsRef().bPrfEnabled;

		/// <summary><b>TRUE</b> if the credential was created as a resident (discoverable) key.</summary>
		public ref bool bResidentKey => ref AsRef().bResidentKey;

		/// <summary/>
		public ref bool bThirdPartyPayment => ref AsRef().bThirdPartyPayment;

		/// <summary>The type used to decode <b>pvAttestationDecode</b>. See Remarks for possible values.</summary>
		public ref WEBAUTHN_ATTESTATION_DECODE dwAttestationDecodeType => ref AsRef().dwAttestationDecodeType;

		/// <summary/>
		public ref WEBAUTHN_CTAP_TRANSPORT dwTransports => ref AsRef().dwTransports;

		/// <summary>A bitmask of <b>WEBAUTHN_CTAP_TRANSPORT_*</b> values indicating which transport was used.</summary>
		public ref WEBAUTHN_CTAP_TRANSPORT dwUsedTransport => ref AsRef().dwUsedTransport;

		/// <summary>A <c>WEBAUTHN_EXTENSIONS</c> structure that contains the authenticator extension outputs for this credential.</summary>
		public ref WEBAUTHN_EXTENSIONS Extensions => ref AsRef().Extensions;

		/// <summary>A pointer to the CBOR-encoded attestation information.</summary>
		public ReadOnlySpan<byte> pbAttestation => AsRef().pbAttestation.AsReadOnlySpan(AsRef().cbAttestation);

		/// <summary>The CBOR encoded Attestation Object to be returned to the Relying Party.</summary>
		public ReadOnlySpan<byte> pbAttestationObject => AsRef().pbAttestationObject.AsReadOnlySpan(AsRef().cbAttestationObject);

		/// <summary>The authenticator data that was created for this credential.</summary>
		public ReadOnlySpan<byte> pbAuthenticatorData => AsRef().pbAuthenticatorData.AsReadOnlySpan(AsRef().cbAuthenticatorData);

		/// <summary/>
		public ReadOnlySpan<byte> pbClientDataJSON => AsRef().pbClientDataJSON.AsReadOnlySpan(AsRef().cbClientDataJSON);

		/// <summary>The CredentialId bytes extracted from the Authenticator Data. Used by Edge to return to the Relying Party.</summary>
		public ReadOnlySpan<byte> pbCredentialId => AsRef().pbCredentialId.AsReadOnlySpan(AsRef().cbCredentialId);

		/// <summary/>
		public ReadOnlySpan<byte> pbRegistrationResponseJSON => AsRef().pbRegistrationResponseJSON.AsReadOnlySpan(AsRef().cbRegistrationResponseJSON);

		/// <summary/>
		public ReadOnlySpan<byte> pbUnsignedExtensionOutputs => AsRef().pbUnsignedExtensionOutputs.AsReadOnlySpan(AsRef().cbUnsignedExtensionOutputs);

		/// <summary/>
		public ref WEBAUTHN_HMAC_SECRET_SALT pHmacSecret => ref AsRef().pHmacSecret.AsRef();

		/// <summary>A pointer to the decoded attestation data. The type depends on <b>dwAttestationDecodeType</b>. See Remarks for details.</summary>
		public ref IntPtr pvAttestationDecode => ref AsRef().pvAttestationDecode;

		/// <summary>The attestation format type.</summary>
		public string? pwszFormatType => AsRef().pwszFormatType;

		/// <summary>Returns a reference to the <c>WEBAUTHN_CREDENTIAL_ATTESTATION</c> structure that this handle represents.</summary>
		/// <returns>A reference to the <c>WEBAUTHN_CREDENTIAL_ATTESTATION</c> structure.</returns>
		/// <exception cref="InvalidOperationException">The handle is closed or invalid.</exception>
		public ref WEBAUTHN_CREDENTIAL_ATTESTATION AsRef() { if (IsClosed || IsInvalid) throw new InvalidOperationException(); return ref handle.AsRef<WEBAUTHN_CREDENTIAL_ATTESTATION>(); }
		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { WebAuthNFreeCredentialAttestation(handle); return true; }
	}

	/// <summary>
	/// A <see cref="SafeHandle"/> class for a <c>WEBAUTHN_CREDENTIAL_DETAILS_LIST</c> structure. This class is used to ensure that the unmanaged memory
	/// associated with the structure is properly released when the handle is no longer needed.
	/// </summary>
	public class SafeWEBAUTHN_CREDENTIAL_DETAILS_LIST : SafeHANDLE, IReadOnlyList<CredentialDetails>
	{
		/// <summary>Gets the number of credential details in the list.</summary>
		public int Count => IsClosed || IsInvalid ? 0 : (int)handle.ToStructure<uint>();

		/// <summary>Gets the credential details at the specified index.</summary>
		/// <param name="index">The index of the credential details to get.</param>
		/// <returns>The credential details at the specified index.</returns>
		public CredentialDetails this[int index]
		{
			get
			{
				if (IsClosed || IsInvalid)
					throw new InvalidOperationException();
				else if (index < 0 || index >= Count)
					throw new ArgumentOutOfRangeException(nameof(index));
				return new(AsRef().ppCredentialDetails[index]);
			}
		}

		/// <summary>Returns a reference to the <c>WEBAUTHN_CREDENTIAL_DETAILS_LIST</c> structure that this handle represents.</summary>
		/// <returns>A reference to the <c>WEBAUTHN_CREDENTIAL_DETAILS_LIST</c> structure.</returns>
		/// <exception cref="InvalidOperationException">The handle is closed or invalid.</exception>
		public ref WEBAUTHN_CREDENTIAL_DETAILS_LIST AsRef() { if (IsClosed || IsInvalid) throw new InvalidOperationException(); return ref handle.AsRef<WEBAUTHN_CREDENTIAL_DETAILS_LIST>(); }

		/// <summary>Returns an enumerator that iterates through the credential details.</summary>
		/// <returns>An enumerator for the credential details.</returns>
		public IEnumerator<CredentialDetails> GetEnumerator()
		{
			ref WEBAUTHN_CREDENTIAL_DETAILS_LIST l = ref AsRef();
			List<CredentialDetails> list = [.. l.ppCredentialDetails.ToArray(l.cCredentialDetails).Select(p => new CredentialDetails(p))];
			return list.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { WebAuthNFreePlatformCredentialList(handle); return true; }
	}
}