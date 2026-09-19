namespace Vanara.PInvoke;

public static partial class WebAuthn
{
	/// <summary/>
	public const uint WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS_CURRENT_VERSION = WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS_VERSION_1;

	/// <summary/>
	public const uint WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS_VERSION_1 = 1;
	/// <summary/>
	public const uint WEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY_CURRENT_VERSION = WEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY_VERSION_1;

	/// <summary/>
	public const uint WEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY_VERSION_1 = 1;
	/// <summary/>
	public const uint WEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST_CURRENT_VERSION = WEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST_VERSION_1;

	/// <summary/>
	public const uint WEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST_VERSION_1 = 1;

	/// <summary/>
	public const uint WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION_CURRENT_VERSION = WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION_VERSION_1;

	/// <summary/>
	public const uint WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION_VERSION_1 = 1;
	/// <summary/>
	public const uint WEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST_CURRENT_VERSION = WEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST_VERSION_1;

	/// <summary/>
	public const uint WEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST_VERSION_1 = 1;

	/// <summary>An application-defined callback that Windows invokes when the status of a registered plugin authenticator changes.</summary>
	/// <param name="context">A caller-defined context pointer that was supplied when the callback was registered.</param>
	/// <returns>None</returns>
	/// <remarks>Register this callback by calling <c>WebAuthNPluginRegisterStatusChangeCallback</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nc-webauthnplugin-webauthn_plugin_status_change_callback
	// WEBAUTHN_PLUGIN_STATUS_CHANGE_CALLBACK WebauthnPluginStatusChangeCallback; void WebauthnPluginStatusChangeCallback( void *context ) {...}
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NC:webauthnplugin.WEBAUTHN_PLUGIN_STATUS_CHANGE_CALLBACK")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void WEBAUTHN_PLUGIN_STATUS_CHANGE_CALLBACK(IntPtr context);

	/// <summary>Specifies whether a plugin authenticator is enabled.</summary>
	/// <remarks>Use this enumeration with <c>WebAuthNPluginGetAuthenticatorState</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ne-webauthnplugin-authenticator_state
	// typedef enum _PLUGIN_AUTHENTICATOR_STATE { AuthenticatorState_Disabled = 0, AuthenticatorState_Enabled = 1 } AUTHENTICATOR_STATE;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NE:webauthnplugin._PLUGIN_AUTHENTICATOR_STATE")]
	public enum AUTHENTICATOR_STATE
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>The plugin authenticator is disabled.</para>
		/// </summary>
		AuthenticatorState_Disabled,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>The plugin authenticator is enabled.</para>
		/// </summary>
		AuthenticatorState_Enabled,
	}

	/// <summary>Specifies the type of Windows Hello user-verification operation for a plugin authenticator.</summary>
	/// <remarks>Use values from this enumeration when working with plugin user-verification workflows.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ne-webauthnplugin-webauthn_plugin_perform_uv_operation_type
	// typedef enum _WEBAUTHN_PLUGIN_PERFORM_UV_OPERATION_TYPE { PerformUserVerification = 1, GetUserVerificationCount = 2, GetPublicKey = 3 } WEBAUTHN_PLUGIN_PERFORM_UV_OPERATION_TYPE;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NE:webauthnplugin._WEBAUTHN_PLUGIN_PERFORM_UV_OPERATION_TYPE")]
	public enum WEBAUTHN_PLUGIN_PERFORM_UV_OPERATION_TYPE
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>Perform user verification.</para>
		/// </summary>
		PerformUserVerification = 1,

		/// <summary>
		///   <para>Value:</para>
		///   <para>2</para>
		///   <para>Retrieve the user-verification counter.</para>
		/// </summary>
		GetUserVerificationCount,

		/// <summary>
		///   <para>Value:</para>
		///   <para>3</para>
		///   <para>Retrieve the user-verification public key.</para>
		/// </summary>
		GetPublicKey,
	}
	/// <summary>Decodes a CTAP CBOR-encoded getAssertion request.</summary>
	/// <param name="cbEncoded">The size, in bytes, of the buffer pointed to by <b>pbEncoded</b>.</param>
	/// <param name="pbEncoded">A pointer to the encoded getAssertion request buffer.</param>
	/// <param name="ppGetAssertionRequest">When this function returns successfully, contains a pointer to a <c>WEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST</c> structure. Free this value with <c>WebAuthNFreeDecodedGetAssertionRequest</c>.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this helper to decode the request payload received by an <c>IPluginAuthenticator::GetAssertion</c> implementation.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthndecodegetassertionrequest
	// HRESULT WebAuthNDecodeGetAssertionRequest( DWORD cbEncoded, const BYTE *pbEncoded, PWEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST *ppGetAssertionRequest );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNDecodeGetAssertionRequest")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNDecodeGetAssertionRequest(uint cbEncoded, in byte pbEncoded,
		out ManagedStructPointer<WEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST> ppGetAssertionRequest);

	/// <summary>Decodes a CTAP CBOR-encoded makeCredential request.</summary>
	/// <param name="cbEncoded">The size, in bytes, of the buffer pointed to by <b>pbEncoded</b>.</param>
	/// <param name="pbEncoded">A pointer to the encoded makeCredential request buffer.</param>
	/// <param name="ppMakeCredentialRequest">When this function returns successfully, contains a pointer to a <c>WEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST</c> structure. Free this value with <c>WebAuthNFreeDecodedMakeCredentialRequest</c>.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this helper to decode the request payload received by an <c>IPluginAuthenticator::MakeCredential</c> implementation.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthndecodemakecredentialrequest
	// HRESULT WebAuthNDecodeMakeCredentialRequest( DWORD cbEncoded, const BYTE *pbEncoded, PWEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST *ppMakeCredentialRequest );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNDecodeMakeCredentialRequest")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNDecodeMakeCredentialRequest(uint cbEncoded, in byte pbEncoded,
		out ManagedStructPointer<WEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST> ppMakeCredentialRequest);

	/// <summary>Encodes a getAssertion response as CTAP CBOR.</summary>
	/// <param name="pGetAssertionResponse">A pointer to a <c>WEBAUTHN_CTAPCBOR_GET_ASSERTION_RESPONSE</c> structure to encode.</param>
	/// <param name="pcbResp">Receives the size, in bytes, of the encoded response buffer returned in <b>ppbResp</b>.</param>
	/// <param name="ppbResp">When this function returns successfully, contains a pointer to the encoded response buffer.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this helper when an <c>IPluginAuthenticator::GetAssertion</c> implementation needs to return a CTAP CBOR-encoded getAssertion response.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnencodegetassertionresponse
	// HRESULT WebAuthNEncodeGetAssertionResponse( PCWEBAUTHN_CTAPCBOR_GET_ASSERTION_RESPONSE pGetAssertionResponse, DWORD *pcbResp, BYTE **ppbResp );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNEncodeGetAssertionResponse")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNEncodeGetAssertionResponse(
		in WEBAUTHN_CTAPCBOR_GET_ASSERTION_RESPONSE pGetAssertionResponse, ref uint pcbResp, out byte[] ppbResp);

	/// <summary>Encodes a credential attestation as a CTAP CBOR makeCredential response.</summary>
	/// <param name="pCredentialAttestation">A pointer to a <c>WEBAUTHN_CREDENTIAL_ATTESTATION</c> structure to encode.</param>
	/// <param name="pcbResp">Receives the size, in bytes, of the encoded response buffer returned in <b>ppbResp</b>.</param>
	/// <param name="ppbResp">When this function returns successfully, contains a pointer to the encoded response buffer.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this helper when an <c>IPluginAuthenticator::MakeCredential</c> implementation needs to return a CTAP CBOR-encoded makeCredential response.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnencodemakecredentialresponse
	// HRESULT WebAuthNEncodeMakeCredentialResponse( PCWEBAUTHN_CREDENTIAL_ATTESTATION pCredentialAttestation, DWORD *pcbResp, BYTE **ppbResp );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNEncodeMakeCredentialResponse")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNEncodeMakeCredentialResponse(
		in WEBAUTHN_CREDENTIAL_ATTESTATION pCredentialAttestation, ref uint pcbResp, out byte[] ppbResp);

	/// <summary>Frees a decoded getAssertion request.</summary>
	/// <param name="pGetAssertionRequest">The decoded request pointer to free. This pointer may be <b>NULL</b>.</param>
	/// <returns>None</returns>
	/// <remarks>Call this function after you are finished with the structure returned by <c>WebAuthNDecodeGetAssertionRequest</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnfreedecodedgetassertionrequest
	// void WebAuthNFreeDecodedGetAssertionRequest( PWEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST pGetAssertionRequest );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNFreeDecodedGetAssertionRequest")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern void WebAuthNFreeDecodedGetAssertionRequest(IntPtr pGetAssertionRequest);

	/// <summary>Frees a decoded makeCredential request.</summary>
	/// <param name="pMakeCredentialRequest">The decoded request pointer to free. This pointer may be <b>NULL</b>.</param>
	/// <returns>None</returns>
	/// <remarks>Call this function after you are finished with the structure returned by <c>WebAuthNDecodeMakeCredentialRequest</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnfreedecodedmakecredentialrequest
	// void WebAuthNFreeDecodedMakeCredentialRequest( PWEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST pMakeCredentialRequest );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNFreeDecodedMakeCredentialRequest")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern void WebAuthNFreeDecodedMakeCredentialRequest(IntPtr pMakeCredentialRequest);

	/// <summary>Registers a plugin authenticator with Windows.</summary>
	/// <param name="pPluginAddAuthenticatorOptions">A pointer to a <c>WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS</c> structure that describes the plugin authenticator to register.</param>
	/// <param name="ppPluginAddAuthenticatorResponse">When this function returns successfully, contains a pointer to a <c>WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_RESPONSE</c> structure. Free this value with <c>WebAuthNPluginFreeAddAuthenticatorResponse</c>.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>This function adds the plugin authenticator to the system so that Windows can route WebAuthn operations to it and expose its metadata to supported experiences.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginaddauthenticator
	// HRESULT WebAuthNPluginAddAuthenticator( PCWEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS pPluginAddAuthenticatorOptions, PWEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_RESPONSE *ppPluginAddAuthenticatorResponse );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginAddAuthenticator")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginAddAuthenticator(in WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS pPluginAddAuthenticatorOptions,
		out ManagedStructPointer<WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_RESPONSE> ppPluginAddAuthenticatorResponse);

	/// <summary>Registers a plugin authenticator with Windows by using the extended add-authenticator options.</summary>
	/// <param name="pPluginAddAuthenticatorOptions">A pointer to a <c>WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS_2</c> structure that describes the plugin authenticator to register.</param>
	/// <param name="ppPluginAddAuthenticatorResponse">When this function returns successfully, contains a pointer to a <c>WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_RESPONSE</c> structure. Free this value with <c>WebAuthNPluginFreeAddAuthenticatorResponse</c>.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this function when you need the additional fields exposed by version 2 of the add-authenticator options structure, such as the user-verification key name. To register a plugin authenticator without those fields, use <c>WebAuthNPluginAddAuthenticator</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginaddauthenticator2
	// HRESULT WebAuthNPluginAddAuthenticator2( PCWEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS_2 pPluginAddAuthenticatorOptions, PWEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_RESPONSE *ppPluginAddAuthenticatorResponse );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginAddAuthenticator2")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginAddAuthenticator2(in WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS_2 pPluginAddAuthenticatorOptions,
		out ManagedStructPointer<WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_RESPONSE> ppPluginAddAuthenticatorResponse);

	/// <summary>Adds cached credential metadata for a plugin authenticator.</summary>
	/// <param name="rclsid">The class identifier of the registered plugin authenticator.</param>
	/// <param name="cCredentialDetails">The number of entries in the array pointed to by <b>pCredentialDetails</b>.</param>
	/// <param name="pCredentialDetails">A pointer to an array of <c>WEBAUTHN_PLUGIN_CREDENTIAL_DETAILS</c> structures that describe the credentials to add.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Credential metadata added by this function can be surfaced by browser autofill and related platform experiences.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginauthenticatoraddcredentials
	// HRESULT WebAuthNPluginAuthenticatorAddCredentials( REFCLSID rclsid, DWORD cCredentialDetails, PCWEBAUTHN_PLUGIN_CREDENTIAL_DETAILS pCredentialDetails );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginAuthenticatorAddCredentials")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginAuthenticatorAddCredentials(in Guid rclsid, uint cCredentialDetails,
		in WEBAUTHN_PLUGIN_CREDENTIAL_DETAILS pCredentialDetails);

	/// <summary>WebAuthNPluginAuthenticatorGetAllCredentials에서 반환된 배열을 해제합니다.</summary>
	/// <param name="cCredentialDetails"><b>pCredentialDetailsArray</b>가 가리키는 배열의 요소 수입니다.</param>
	/// <param name="pCredentialDetailsArray">해제할 배열입니다. <b>cCredentialDetails</b>가 0인 경우 이 포인터는 <b>NULL</b>일 수 있습니다.</param>
	/// <returns>None</returns>
	/// <remarks><c>WebAuthNPluginAuthenticatorGetAllCredentials</c>에서 반환된 배열 처리를 완료한 후 이 함수를 호출합니다.</remarks>
	// https://learn.microsoft.com/ko-kr/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginauthenticatorfreecredentialdetailsarray
	// void WebAuthNPluginAuthenticatorFreeCredentialDetailsArray( DWORD cCredentialDetails, PWEBAUTHN_PLUGIN_CREDENTIAL_DETAILS pCredentialDetailsArray );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginAuthenticatorFreeCredentialDetailsArray")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern void WebAuthNPluginAuthenticatorFreeCredentialDetailsArray(uint cCredentialDetails,
		in WEBAUTHN_PLUGIN_CREDENTIAL_DETAILS pCredentialDetailsArray);

	/// <summary>Gets all cached credential metadata for a plugin authenticator.</summary>
	/// <param name="rclsid">The class identifier of the registered plugin authenticator.</param>
	/// <param name="pcCredentialDetails">Receives the number of elements in the array returned in <b>ppCredentialDetailsArray</b>.</param>
	/// <param name="ppCredentialDetailsArray">When this function returns successfully, contains a pointer to an array of <c>WEBAUTHN_PLUGIN_CREDENTIAL_DETAILS</c> structures. Free the returned array with <c>WebAuthNPluginAuthenticatorFreeCredentialDetailsArray</c>.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this function to inspect the credential metadata Windows currently caches for the specified plugin authenticator.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginauthenticatorgetallcredentials
	// HRESULT WebAuthNPluginAuthenticatorGetAllCredentials( REFCLSID rclsid, DWORD *pcCredentialDetails, PWEBAUTHN_PLUGIN_CREDENTIAL_DETAILS *ppCredentialDetailsArray );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginAuthenticatorGetAllCredentials")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginAuthenticatorGetAllCredentials(in Guid rclsid, ref uint pcCredentialDetails,
		out ManagedStructPointer<WEBAUTHN_PLUGIN_CREDENTIAL_DETAILS> ppCredentialDetailsArray);

	/// <summary>Removes all cached credential metadata for a plugin authenticator.</summary>
	/// <param name="rclsid">The class identifier of the registered plugin authenticator.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>This function clears all credential metadata that Windows currently caches for the specified plugin authenticator.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginauthenticatorremoveallcredentials
	// HRESULT WebAuthNPluginAuthenticatorRemoveAllCredentials( REFCLSID rclsid );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginAuthenticatorRemoveAllCredentials")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginAuthenticatorRemoveAllCredentials(in Guid rclsid);

	/// <summary>Removes cached credential metadata for a plugin authenticator.</summary>
	/// <param name="rclsid">The class identifier of the registered plugin authenticator.</param>
	/// <param name="cCredentialDetails">The number of entries in the array pointed to by <b>pCredentialDetails</b>.</param>
	/// <param name="pCredentialDetails">A pointer to an array of <c>WEBAUTHN_PLUGIN_CREDENTIAL_DETAILS</c> structures that describe the credentials to remove.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this function when specific credential metadata entries should no longer be exposed through Windows-managed autofill experiences.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginauthenticatorremovecredentials
	// HRESULT WebAuthNPluginAuthenticatorRemoveCredentials( REFCLSID rclsid, DWORD cCredentialDetails, PCWEBAUTHN_PLUGIN_CREDENTIAL_DETAILS pCredentialDetails );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginAuthenticatorRemoveCredentials")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginAuthenticatorRemoveCredentials(in Guid rclsid, uint cCredentialDetails,
		in WEBAUTHN_PLUGIN_CREDENTIAL_DETAILS pCredentialDetails);

	/// <summary>Frees a response returned by WebAuthNPluginAddAuthenticator or EXPERIMENTAL_WebAuthNPluginAddAuthenticator2.</summary>
	/// <param name="pPluginAddAuthenticatorResponse">The response pointer to free. This pointer may be <b>NULL</b>.</param>
	/// <returns>None</returns>
	/// <remarks>Call this function after you are finished with the response returned by <c>WebAuthNPluginAddAuthenticator</c> or <c>EXPERIMENTAL_WebAuthNPluginAddAuthenticator2</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginfreeaddauthenticatorresponse
	// void WebAuthNPluginFreeAddAuthenticatorResponse( PWEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_RESPONSE pPluginAddAuthenticatorResponse );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginFreeAddAuthenticatorResponse")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern void WebAuthNPluginFreeAddAuthenticatorResponse(IntPtr pPluginAddAuthenticatorResponse);

	/// <summary>Frees a public-key buffer returned by a WebAuthN plugin public-key function.</summary>
	/// <param name="pbOpSignPubKey">The buffer to free. This pointer may be <b>NULL</b>.</param>
	/// <returns>None</returns>
	/// <remarks>Call this function after you are finished with the buffer returned by <c>WebAuthNPluginGetUserVerificationPublicKey</c> or <c>WebAuthNPluginGetOperationSigningPublicKey</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginfreepublickeyresponse
	// void WebAuthNPluginFreePublicKeyResponse( PBYTE pbOpSignPubKey );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginFreePublicKeyResponse")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern void WebAuthNPluginFreePublicKeyResponse(IntPtr pbOpSignPubKey);

	/// <summary>Frees a response buffer returned by a plugin user-verification function.</summary>
	/// <param name="ppbResponse">The response buffer to free. This pointer may be <b>NULL</b>.</param>
	/// <returns>None</returns>
	/// <remarks>Call this function after you are finished with the buffer returned by <c>WebAuthNPluginPerformUserVerification</c> or <c>EXPERIMENTAL_WebAuthNPluginPerformUserVerification2</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginfreeuserverificationresponse
	// void WebAuthNPluginFreeUserVerificationResponse( PBYTE ppbResponse );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginFreeUserVerificationResponse")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern void WebAuthNPluginFreeUserVerificationResponse(IntPtr ppbResponse);

	/// <summary>Gets the current enabled or disabled state of a plugin authenticator.</summary>
	/// <param name="rclsid">The class identifier of the registered plugin authenticator.</param>
	/// <param name="pluginAuthenticatorState">Receives an <c>AUTHENTICATOR_STATE</c> value that indicates whether the plugin authenticator is enabled or disabled.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this function to determine whether Windows currently considers the specified plugin authenticator available for WebAuthn operations.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnplugingetauthenticatorstate
	// HRESULT WebAuthNPluginGetAuthenticatorState( REFCLSID rclsid, AUTHENTICATOR_STATE *pluginAuthenticatorState );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginGetAuthenticatorState")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginGetAuthenticatorState(in Guid rclsid, out AUTHENTICATOR_STATE pluginAuthenticatorState);

	/// <summary>Gets the operation-signing public key for a plugin authenticator.</summary>
	/// <param name="rclsid">The class identifier of the registered plugin authenticator.</param>
	/// <param name="pcbOpSignPubKey">Receives the size, in bytes, of the buffer returned in <b>ppbOpSignPubKey</b>.</param>
	/// <param name="ppbOpSignPubKey">When this function returns successfully, contains a pointer to the public-key buffer. Free this buffer with <c>WebAuthNPluginFreePublicKeyResponse</c>.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>The operation-signing public key pairs with the signature material carried in <c>WEBAUTHN_PLUGIN_OPERATION_REQUEST</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnplugingetoperationsigningpublickey
	// HRESULT WebAuthNPluginGetOperationSigningPublicKey( REFCLSID rclsid, DWORD *pcbOpSignPubKey, PBYTE *ppbOpSignPubKey );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginGetOperationSigningPublicKey")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginGetOperationSigningPublicKey(in Guid rclsid, out uint pcbOpSignPubKey, out IntPtr ppbOpSignPubKey);

	/// <summary>Gets the user-verification counter for a plugin authenticator.</summary>
	/// <param name="rclsid">The class identifier of the registered plugin authenticator.</param>
	/// <param name="pdwVerificationCount">Receives the current user-verification counter value.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this function to retrieve the counter value that the plugin authenticator uses for user-verification operations.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnplugingetuserverificationcount
	// HRESULT WebAuthNPluginGetUserVerificationCount( REFCLSID rclsid, DWORD *pdwVerificationCount );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginGetUserVerificationCount")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginGetUserVerificationCount(in Guid rclsid, out uint pdwVerificationCount);

	/// <summary>Gets the public key associated with plugin user verification.</summary>
	/// <param name="rclsid">The class identifier of the registered plugin authenticator.</param>
	/// <param name="pcbPublicKey">Receives the size, in bytes, of the buffer returned in <b>ppbPublicKey</b>.</param>
	/// <param name="ppbPublicKey">When this function returns successfully, contains a pointer to the public-key buffer. Free this buffer with <c>WebAuthNPluginFreePublicKeyResponse</c>.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this function to retrieve the public key that Windows associates with user-verification operations for the specified plugin authenticator.</remarks>
	// https://learn.microsoft.com/fi-fi/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnplugingetuserverificationpublickey
	// HRESULT WebAuthNPluginGetUserVerificationPublicKey( REFCLSID rclsid, DWORD *pcbPublicKey, PBYTE *ppbPublicKey );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginGetUserVerificationPublicKey")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginGetUserVerificationPublicKey(in Guid rclsid, out uint pcbPublicKey, out IntPtr ppbPublicKey);

	/// <summary>Performs Windows Hello user verification for a plugin authenticator operation.</summary>
	/// <param name="pPluginUserVerification">A pointer to a <c>WEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST</c> structure that describes the user-verification request.</param>
	/// <param name="pcbResponse">Receives the size, in bytes, of the buffer returned in <b>ppbResponse</b>.</param>
	/// <param name="ppbResponse">When this function returns successfully, contains a pointer to the response buffer. Free this buffer with <c>WebAuthNPluginFreeUserVerificationResponse</c>.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this function to invoke Windows Hello user verification during a plugin authenticator operation.</remarks>
	// https://learn.microsoft.com/bs-latn-ba/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginperformuserverification
	// HRESULT WebAuthNPluginPerformUserVerification( PCWEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST pPluginUserVerification, DWORD *pcbResponse, PBYTE *ppbResponse );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginPerformUserVerification")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginPerformUserVerification(in WEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST pPluginUserVerification, out uint pcbResponse,
		out IntPtr ppbResponse);

	/// <summary>Performs Windows Hello user verification for a plugin authenticator operation by using the extended user-verification request.</summary>
	/// <param name="pPluginUserVerification">A pointer to a <c>WEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST_2</c> structure that describes the user-verification request.</param>
	/// <param name="pcbResponse">Receives the size, in bytes, of the buffer returned in <b>ppbResponse</b>.</param>
	/// <param name="ppbResponse">When this function returns successfully, contains a pointer to the response buffer. Free this buffer with <c>WebAuthNPluginFreeUserVerificationResponse</c>.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this function when you need to supply a custom buffer to sign during user verification. Version 2 adds the <b>pbBufferToSign</b> field to the request structure. To perform user verification without a custom buffer, use <c>WebAuthNPluginPerformUserVerification</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginperformuserverification2
	// HRESULT WebAuthNPluginPerformUserVerification2( PCWEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST_2 pPluginUserVerification, DWORD *pcbResponse, PBYTE *ppbResponse );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginPerformUserVerification2")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginPerformUserVerification2(
		in WEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST_2 pPluginUserVerification, out uint pcbResponse,
		out IntPtr ppbResponse);

	/// <summary>Registers a callback that is invoked when plugin authenticator status changes.</summary>
	/// <param name="callback">A <c>WEBAUTHN_PLUGIN_STATUS_CHANGE_CALLBACK</c> function pointer.</param>
	/// <param name="context">An optional caller-defined context pointer that Windows passes to the callback.</param>
	/// <param name="rclsid">The class identifier of the registered plugin authenticator to monitor.</param>
	/// <param name="pdwRegister">Receives a registration token that you pass to <c>WebAuthNPluginUnregisterStatusChangeCallback</c> to unregister the callback.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this function to receive notification when the availability or enabled state of a plugin authenticator changes.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginregisterstatuschangecallback
	// HRESULT WebAuthNPluginRegisterStatusChangeCallback( WEBAUTHN_PLUGIN_STATUS_CHANGE_CALLBACK callback, void *context, REFCLSID rclsid, DWORD *pdwRegister );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginRegisterStatusChangeCallback")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginRegisterStatusChangeCallback(WEBAUTHN_PLUGIN_STATUS_CHANGE_CALLBACK callback,
		IntPtr context, in Guid rclsid, out uint pdwRegister);

	/// <summary>Unregisters a plugin authenticator from Windows.</summary>
	/// <param name="rclsid">The class identifier of the registered plugin authenticator to remove.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>After removal, Windows no longer routes WebAuthn operations to the specified plugin authenticator.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginremoveauthenticator
	// HRESULT WebAuthNPluginRemoveAuthenticator( REFCLSID rclsid );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginRemoveAuthenticator")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginRemoveAuthenticator(in Guid rclsid);

	/// <summary>Unregisters a previously registered plugin status-change callback.</summary>
	/// <param name="pdwRegister">A pointer to the registration token returned by <c>WebAuthNPluginRegisterStatusChangeCallback</c>.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Call this function to stop receiving notifications for a callback registration created by <c>WebAuthNPluginRegisterStatusChangeCallback</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginunregisterstatuschangecallback
	// HRESULT WebAuthNPluginUnregisterStatusChangeCallback( DWORD *pdwRegister );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginUnregisterStatusChangeCallback")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginUnregisterStatusChangeCallback(ref uint pdwRegister);

	/// <summary>Updates metadata for a registered plugin authenticator.</summary>
	/// <param name="pPluginUpdateAuthenticatorDetails">A pointer to a <c>WEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS</c> structure that contains the updated metadata.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this function to update the authenticator display name, logos, authenticatorGetInfo payload, supported relying parties, or class identifier for an existing plugin authenticator.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginupdateauthenticatordetails
	// HRESULT WebAuthNPluginUpdateAuthenticatorDetails( PCWEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS pPluginUpdateAuthenticatorDetails );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginUpdateAuthenticatorDetails")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginUpdateAuthenticatorDetails(
		in WEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS pPluginUpdateAuthenticatorDetails);

	/// <summary>Updates metadata for a registered plugin authenticator by using the extended update-details structure.</summary>
	/// <param name="pPluginUpdateAuthenticatorDetails">A pointer to a <c>WEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS_2</c> structure that contains the updated metadata.</param>
	/// <returns>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>Use this function when you need the additional fields exposed by version 2 of the update-details structure, such as the user-verification key name. To update a plugin authenticator without those fields, use <c>WebAuthNPluginUpdateAuthenticatorDetails</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/nf-webauthnplugin-webauthnpluginupdateauthenticatordetails2
	// HRESULT WebAuthNPluginUpdateAuthenticatorDetails2( PCWEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS_2 pPluginUpdateAuthenticatorDetails );
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NF:webauthnplugin.WebAuthNPluginUpdateAuthenticatorDetails2")]
	[DllImport(Lib_WebAuthn, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebAuthNPluginUpdateAuthenticatorDetails2(
		in WEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS_2 pPluginUpdateAuthenticatorDetails);

	/// <summary>Contains CTAP authenticator option values used with decoded plugin requests.</summary>
	/// <remarks>Use this structure as part of decoded CTAP CBOR requests.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ns-webauthnplugin-webauthn_ctapcbor_authenticator_options
	// typedef struct _WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS { DWORD dwVersion; LONG lUp; LONG lUv; LONG lRequireResidentKey; } WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS, *PWEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NS:webauthnplugin._WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS()
	{
		/// <summary>The version of this structure.</summary>
		public uint dwVersion = WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS_CURRENT_VERSION;

		/// <summary>The CTAP <c>up</c> option. Use <b>+1</b> for <b>TRUE</b>, <b>0</b> for not specified, and <b>-1</b> for <b>FALSE</b>.</summary>
		public int lUp;

		/// <summary>The CTAP <c>uv</c> option. Use <b>+1</b> for <b>TRUE</b>, <b>0</b> for not specified, and <b>-1</b> for <b>FALSE</b>.</summary>
		public int lUv;

		/// <summary>The CTAP <c>rk</c> option. Use <b>+1</b> for <b>TRUE</b>, <b>0</b> for not specified, and <b>-1</b> for <b>FALSE</b>.</summary>
		public int lRequireResidentKey;
	}

	/// <summary>Represents an elliptic-curve public key used in CTAP CBOR extensions.</summary>
	/// <remarks>Use this structure with CTAP HMAC-salt extension data.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ns-webauthnplugin-webauthn_ctapcbor_ecc_public_key
	// typedef struct _WEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY { DWORD dwVersion; LONG lKty; LONG lAlg; LONG lCrv; DWORD cbX; PBYTE pbX; DWORD cbY; PBYTE pbY; } WEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY, *PWEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NS:webauthnplugin._WEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY()
	{
		/// <summary>The version of this structure.</summary>
		public uint dwVersion = WEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY_CURRENT_VERSION;

		/// <summary>The COSE key type.</summary>
		public int lKty;

		/// <summary>The COSE algorithm identifier, such as ES256, ES384, or ES512.</summary>
		public int lAlg;

		/// <summary>The elliptic-curve identifier.</summary>
		public int lCrv;

		/// <summary>The size, in bytes, of the X coordinate pointed to by <b>pbX</b>.</summary>
		public uint cbX;

		/// <summary>A pointer to the big-endian X coordinate bytes.</summary>
		[SizeDef(nameof(cbX))]
		public ArrayPointer<byte> pbX;

		/// <summary>The size, in bytes, of the Y coordinate pointed to by <b>pbY</b>.</summary>
		public uint cbY;

		/// <summary>A pointer to the big-endian Y coordinate bytes.</summary>
		[SizeDef(nameof(cbY))]
		public ArrayPointer<byte> pbY;
	}

	/// <summary>Contains a decoded CTAP CBOR getAssertion request.</summary>
	/// <remarks>Use this structure with <c>WebAuthNDecodeGetAssertionRequest</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ns-webauthnplugin-webauthn_ctapcbor_get_assertion_request
	// typedef struct _WEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST { DWORD dwVersion; PCWSTR pwszRpId; DWORD cbRpId; PBYTE pbRpId; DWORD cbClientDataHash; PBYTE pbClientDataHash; WEBAUTHN_CREDENTIAL_LIST CredentialList; DWORD cbCborExtensionsMap; PBYTE pbCborExtensionsMap; PWEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS pAuthenticatorOptions; BOOL fEmptyPinAuth; DWORD cbPinAuth; PBYTE pbPinAuth; PWEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION pHmacSaltExtension; DWORD cbHmacSecretSaltValues; PBYTE pbHmacSecretSaltValues; DWORD dwPinProtocol; LONG lCredBlobExt; LONG lLargeBlobKeyExt; DWORD dwCredLargeBlobOperation; DWORD cbCredLargeBlobCompressed; PBYTE pbCredLargeBlobCompressed; DWORD dwCredLargeBlobOriginalSize; DWORD cbJsonExt; PBYTE pbJsonExt; } WEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST, *PWEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NS:webauthnplugin._WEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST()
	{
		/// <summary>The version of this structure.</summary>
		public uint dwVersion = WEBAUTHN_CTAPCBOR_GET_ASSERTION_REQUEST_CURRENT_VERSION;

		/// <summary>A pointer to the relying-party identifier after UTF-8 to Unicode conversion.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszRpId;

		/// <summary>The size, in bytes, of the raw UTF-8 relying-party identifier pointed to by <b>pbRpId</b>.</summary>
		public uint cbRpId;

		/// <summary>A pointer to the raw UTF-8 relying-party identifier bytes that are hashed into the authenticator data.</summary>
		[SizeDef(nameof(cbRpId))]
		public ArrayPointer<byte> pbRpId;

		/// <summary>The size, in bytes, of the client-data hash pointed to by <b>pbClientDataHash</b>.</summary>
		public uint cbClientDataHash;

		/// <summary>A pointer to the client-data hash.</summary>
		[SizeDef(nameof(cbClientDataHash))]
		public ArrayPointer<byte> pbClientDataHash;

		/// <summary>A <c>WEBAUTHN_CREDENTIAL_LIST</c> structure that contains the allow list.</summary>
		public WEBAUTHN_CREDENTIAL_LIST CredentialList;

		/// <summary>The size, in bytes, of the CBOR extensions map pointed to by <b>pbCborExtensionsMap</b>.</summary>
		public uint cbCborExtensionsMap;

		/// <summary>A pointer to the raw CBOR extensions map.</summary>
		[SizeDef(nameof(cbCborExtensionsMap))]
		public ArrayPointer<byte> pbCborExtensionsMap;

		/// <summary>An optional pointer to a <c>WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS</c> structure.</summary>
		public StructPointer<WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS> pAuthenticatorOptions;

		/// <summary>If <b>TRUE</b>, a zero-length pinAuth field is included in the request.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fEmptyPinAuth;

		/// <summary>The size, in bytes, of the pinAuth buffer pointed to by <b>pbPinAuth</b>.</summary>
		public uint cbPinAuth;

		/// <summary>A pointer to the pinAuth buffer.</summary>
		[SizeDef(nameof(cbPinAuth))]
		public ArrayPointer<byte> pbPinAuth;

		/// <summary>An optional pointer to a <c>WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION</c> structure.</summary>
		public ManagedStructPointer<WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION> pHmacSaltExtension;

		/// <summary>The size, in bytes, of the PRF salt-values buffer pointed to by <b>pbHmacSecretSaltValues</b>.</summary>
		public uint cbHmacSecretSaltValues;

		/// <summary>A pointer to the PRF salt-values buffer.</summary>
		[SizeDef(nameof(cbHmacSecretSaltValues))]
		public ArrayPointer<byte> pbHmacSecretSaltValues;

		/// <summary>The PIN protocol value.</summary>
		public uint dwPinProtocol;

		/// <summary>The <c>credBlob</c> extension state.</summary>
		public int lCredBlobExt;

		/// <summary>The <c>largeBlobKey</c> extension state.</summary>
		public int lLargeBlobKeyExt;

		/// <summary>The requested <c>largeBlob</c> operation.</summary>
		public uint dwCredLargeBlobOperation;

		/// <summary>The size, in bytes, of the compressed large-blob buffer pointed to by <b>pbCredLargeBlobCompressed</b>.</summary>
		public uint cbCredLargeBlobCompressed;

		/// <summary>A pointer to the compressed large-blob buffer.</summary>
		[SizeDef(nameof(cbCredLargeBlobCompressed))]
		public ArrayPointer<byte> pbCredLargeBlobCompressed;

		/// <summary>The original, uncompressed large-blob size.</summary>
		public uint dwCredLargeBlobOriginalSize;

		/// <summary>The size, in bytes, of the <c>json</c> extension buffer pointed to by <b>pbJsonExt</b>.</summary>
		public uint cbJsonExt;

		/// <summary>A pointer to the <c>json</c> extension buffer.</summary>
		[SizeDef(nameof(cbJsonExt))]
		public ArrayPointer<byte> pbJsonExt;
	}

	/// <summary>Contains data for a CTAP CBOR getAssertion response.</summary>
	/// <remarks>Use this structure with <c>WebAuthNEncodeGetAssertionResponse</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ns-webauthnplugin-webauthn_ctapcbor_get_assertion_response
	// typedef struct _WEBAUTHN_CTAPCBOR_GET_ASSERTION_RESPONSE { WEBAUTHN_ASSERTION WebAuthNAssertion; PCWEBAUTHN_USER_ENTITY_INFORMATION pUserInformation; DWORD dwNumberOfCredentials; LONG lUserSelected; DWORD cbLargeBlobKey; PBYTE pbLargeBlobKey; DWORD cbUnsignedExtensionOutputs; PBYTE pbUnsignedExtensionOutputs; } WEBAUTHN_CTAPCBOR_GET_ASSERTION_RESPONSE, *PWEBAUTHN_CTAPCBOR_GET_ASSERTION_RESPONSE;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NS:webauthnplugin._WEBAUTHN_CTAPCBOR_GET_ASSERTION_RESPONSE")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CTAPCBOR_GET_ASSERTION_RESPONSE
	{
		/// <summary>A <c>WEBAUTHN_ASSERTION</c> structure that contains the credential, authenticator data, and signature.</summary>
		public WEBAUTHN_ASSERTION WebAuthNAssertion;

		/// <summary>An optional pointer to a <c>WEBAUTHN_USER_ENTITY_INFORMATION</c> structure.</summary>
		public ManagedStructPointer<WEBAUTHN_USER_ENTITY_INFORMATION> pUserInformation;

		/// <summary>The optional <c>numberOfCredentials</c> value.</summary>
		public uint dwNumberOfCredentials;

		/// <summary>The optional <c>userSelected</c> value.</summary>
		public int lUserSelected;

		/// <summary>The size, in bytes, of the large-blob key pointed to by <b>pbLargeBlobKey</b>.</summary>
		public uint cbLargeBlobKey;

		/// <summary>A pointer to the large-blob key buffer.</summary>
		[SizeDef(nameof(cbLargeBlobKey))]
		public ArrayPointer<byte> pbLargeBlobKey;

		/// <summary>The size, in bytes, of the unsigned extension outputs pointed to by <b>pbUnsignedExtensionOutputs</b>.</summary>
		public uint cbUnsignedExtensionOutputs;

		/// <summary>A pointer to the unsigned extension outputs buffer.</summary>
		[SizeDef(nameof(cbUnsignedExtensionOutputs))]
		public ArrayPointer<byte> pbUnsignedExtensionOutputs;
	}

	/// <summary>Contains data for the CTAP HMAC-salt extension.</summary>
	/// <remarks>Use this structure when processing CTAP HMAC-secret or PRF extension data.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ns-webauthnplugin-webauthn_ctapcbor_hmac_salt_extension
	// typedef struct _WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION { DWORD dwVersion; PWEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY pKeyAgreement; DWORD cbEncryptedSalt; PBYTE pbEncryptedSalt; DWORD cbSaltAuth; PBYTE pbSaltAuth; } WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION, *PWEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NS:webauthnplugin._WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION()
	{
		/// <summary>The version of this structure.</summary>
		public uint dwVersion = WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION_CURRENT_VERSION;

		/// <summary>A pointer to a <c>WEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY</c> structure that contains the platform key-agreement public key.</summary>
		public StructPointer<WEBAUTHN_CTAPCBOR_ECC_PUBLIC_KEY> pKeyAgreement;

		/// <summary>The size, in bytes, of the encrypted salt pointed to by <b>pbEncryptedSalt</b>.</summary>
		public uint cbEncryptedSalt;

		/// <summary>A pointer to the encrypted salt bytes.</summary>
		[SizeDef(nameof(cbEncryptedSalt))]
		public ArrayPointer<byte> pbEncryptedSalt;

		/// <summary>The size, in bytes, of the salt-auth buffer pointed to by <b>pbSaltAuth</b>.</summary>
		public uint cbSaltAuth;

		/// <summary>A pointer to the salt-auth bytes.</summary>
		[SizeDef(nameof(cbSaltAuth))]
		public ArrayPointer<byte> pbSaltAuth;
	}

	/// <summary>Contains a decoded CTAP CBOR makeCredential request.</summary>
	/// <remarks>Use this structure with <c>WebAuthNDecodeMakeCredentialRequest</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ns-webauthnplugin-webauthn_ctapcbor_make_credential_request
	// typedef struct _WEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST { DWORD dwVersion; DWORD cbRpId; PBYTE pbRpId; DWORD cbClientDataHash; PBYTE pbClientDataHash; PCWEBAUTHN_RP_ENTITY_INFORMATION pRpInformation; PCWEBAUTHN_USER_ENTITY_INFORMATION pUserInformation; WEBAUTHN_COSE_CREDENTIAL_PARAMETERS WebAuthNCredentialParameters; WEBAUTHN_CREDENTIAL_LIST CredentialList; DWORD cbCborExtensionsMap; PBYTE pbCborExtensionsMap; PWEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS pAuthenticatorOptions; BOOL fEmptyPinAuth; DWORD cbPinAuth; PBYTE pbPinAuth; LONG lHmacSecretExt; PWEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION pHmacSecretMcExtension; LONG lPrfExt; DWORD cbHmacSecretSaltValues; PBYTE pbHmacSecretSaltValues; DWORD dwCredProtect; DWORD dwPinProtocol; DWORD dwEnterpriseAttestation; DWORD cbCredBlobExt; PBYTE pbCredBlobExt; LONG lLargeBlobKeyExt; DWORD dwLargeBlobSupport; LONG lMinPinLengthExt; DWORD cbJsonExt; PBYTE pbJsonExt; } WEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST, *PWEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NS:webauthnplugin._WEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_CTAPCBOR_MAKE_CREDENTIAL_REQUEST
	{
		/// <summary>The version of this structure.</summary>
		public uint dwVersion;

		/// <summary>The size, in bytes, of the raw UTF-8 relying-party identifier pointed to by <b>pbRpId</b>.</summary>
		public uint cbRpId;

		/// <summary>A pointer to the raw UTF-8 relying-party identifier bytes that are hashed into the authenticator data.</summary>
		[SizeDef(nameof(cbRpId))]
		public ArrayPointer<byte> pbRpId;

		/// <summary>The size, in bytes, of the client-data hash pointed to by <b>pbClientDataHash</b>.</summary>
		public uint cbClientDataHash;

		/// <summary>A pointer to the client-data hash.</summary>
		[SizeDef(nameof(cbClientDataHash))]
		public ArrayPointer<byte> pbClientDataHash;

		/// <summary>A pointer to a <c>WEBAUTHN_RP_ENTITY_INFORMATION</c> structure.</summary>
		public ManagedStructPointer<WEBAUTHN_RP_ENTITY_INFORMATION> pRpInformation;

		/// <summary>A pointer to a <c>WEBAUTHN_USER_ENTITY_INFORMATION</c> structure.</summary>
		public ManagedStructPointer<WEBAUTHN_USER_ENTITY_INFORMATION> pUserInformation;

		/// <summary>A <c>WEBAUTHN_COSE_CREDENTIAL_PARAMETERS</c> structure that contains the acceptable credential parameters.</summary>
		public WEBAUTHN_COSE_CREDENTIAL_PARAMETERS WebAuthNCredentialParameters;

		/// <summary>A <c>WEBAUTHN_CREDENTIAL_LIST</c> structure that contains the exclusion list.</summary>
		public WEBAUTHN_CREDENTIAL_LIST CredentialList;

		/// <summary>The size, in bytes, of the CBOR extensions map pointed to by <b>pbCborExtensionsMap</b>.</summary>
		public uint cbCborExtensionsMap;

		/// <summary>A pointer to the raw CBOR extensions map.</summary>
		[SizeDef(nameof(cbCborExtensionsMap))]
		public ArrayPointer<byte> pbCborExtensionsMap;

		/// <summary>An optional pointer to a <c>WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS</c> structure.</summary>
		public StructPointer<WEBAUTHN_CTAPCBOR_AUTHENTICATOR_OPTIONS> pAuthenticatorOptions;

		/// <summary>If <b>TRUE</b>, a zero-length pinAuth field is included in the request.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fEmptyPinAuth;

		/// <summary>The size, in bytes, of the pinAuth buffer pointed to by <b>pbPinAuth</b>.</summary>
		public uint cbPinAuth;

		/// <summary>A pointer to the pinAuth buffer.</summary>
		[SizeDef(nameof(cbPinAuth))]
		public ArrayPointer<byte> pbPinAuth;

		/// <summary>The <c>hmac-secret</c> extension state.</summary>
		public int lHmacSecretExt;

		/// <summary>An optional pointer to a <c>WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION</c> structure for the <c>hmac-secret-mc</c> extension.</summary>
		public StructPointer<WEBAUTHN_CTAPCBOR_HMAC_SALT_EXTENSION> pHmacSecretMcExtension;

		/// <summary>The <c>prf</c> extension state.</summary>
		public int lPrfExt;

		/// <summary>The size, in bytes, of the PRF salt-values buffer pointed to by <b>pbHmacSecretSaltValues</b>.</summary>
		public uint cbHmacSecretSaltValues;

		/// <summary>A pointer to the PRF salt-values buffer.</summary>
		[SizeDef(nameof(cbHmacSecretSaltValues))]
		public ArrayPointer<byte> pbHmacSecretSaltValues;

		/// <summary>The <c>credProtect</c> extension value, or zero if the extension is not present.</summary>
		public uint dwCredProtect;

		/// <summary>The PIN protocol value, or zero if it is not present.</summary>
		public uint dwPinProtocol;

		/// <summary>The enterprise-attestation value, or zero if it is not present.</summary>
		public uint dwEnterpriseAttestation;

		/// <summary>The size, in bytes, of the <c>credBlob</c> extension buffer pointed to by <b>pbCredBlobExt</b>.</summary>
		public uint cbCredBlobExt;

		/// <summary>A pointer to the <c>credBlob</c> extension buffer.</summary>
		[SizeDef(nameof(cbCredBlobExt))]
		public ArrayPointer<byte> pbCredBlobExt;

		/// <summary>The <c>largeBlobKey</c> extension state.</summary>
		public int lLargeBlobKeyExt;

		/// <summary>The <c>largeBlob</c> extension value.</summary>
		public uint dwLargeBlobSupport;

		/// <summary>The <c>minPinLength</c> extension state.</summary>
		public int lMinPinLengthExt;

		/// <summary>The size, in bytes, of the <c>json</c> extension buffer pointed to by <b>pbJsonExt</b>.</summary>
		public uint cbJsonExt;

		/// <summary>A pointer to the <c>json</c> extension buffer.</summary>
		[SizeDef(nameof(cbJsonExt))]
		public ArrayPointer<byte> pbJsonExt;
	}

	/// <summary>Contains options for registering a plugin authenticator with Windows.</summary>
	/// <remarks>Use this structure with <c>WebAuthNPluginAddAuthenticator</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ns-webauthnplugin-webauthn_plugin_add_authenticator_options
	// typedef struct _WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS { LPCWSTR pwszAuthenticatorName; REFCLSID rclsid; LPCWSTR pwszPluginRpId; LPCWSTR pwszLightThemeLogoSvg; LPCWSTR pwszDarkThemeLogoSvg; DWORD cbAuthenticatorInfo; const BYTE *pbAuthenticatorInfo; DWORD cSupportedRpIds; const LPCWSTR *ppwszSupportedRpIds; } WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS, *PWEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NS:webauthnplugin._WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS
	{
		/// <summary>A pointer to a null-terminated string that contains the display name of the plugin authenticator.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszAuthenticatorName;

		/// <summary>The class identifier of the plugin authenticator COM implementation.</summary>
		public GuidPtr rclsid;

		/// <summary>An optional pointer to a null-terminated relying-party identifier string used for nested WebAuthn calls that originate from the plugin.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszPluginRpId;

		/// <summary>An optional pointer to a base64-encoded SVG 1.1 logo to use in light theme.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszLightThemeLogoSvg;

		/// <summary>An optional pointer to a base64-encoded SVG 1.1 logo to use in dark theme.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszDarkThemeLogoSvg;

		/// <summary>The size, in bytes, of the CTAP CBOR authenticatorGetInfo payload pointed to by <b>pbAuthenticatorInfo</b>.</summary>
		public uint cbAuthenticatorInfo;

		/// <summary>A pointer to the CTAP CBOR authenticatorGetInfo payload.</summary>
		[SizeDef(nameof(cbAuthenticatorInfo))]
		public ArrayPointer<byte> pbAuthenticatorInfo;

		/// <summary>The number of entries in the array pointed to by <b>ppwszSupportedRpIds</b>. Specify zero if all relying parties are supported.</summary>
		public uint cSupportedRpIds;

		/// <summary>A pointer to an array of supported relying-party identifiers. Specify <b>NULL</b> if all relying parties are supported.</summary>
		[SizeDef(nameof(cSupportedRpIds))]
		public LPCWSTRArrayPointer ppwszSupportedRpIds;
	}

	/// <summary>Contains extended options for registering a plugin authenticator with Windows.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ns-webauthnplugin-webauthn_plugin_add_authenticator_options_2
	// typedef struct _WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS_2 { LPCWSTR pwszAuthenticatorName; const CLSID *pClsid; LPCWSTR pwszPluginRpId; LPCWSTR pwszLightThemeLogoSvg; LPCWSTR pwszDarkThemeLogoSvg; DWORD cbAuthenticatorInfo; const BYTE *pbAuthenticatorInfo; DWORD cSupportedRpIds; const LPCWSTR *ppwszSupportedRpIds; LPCWSTR pwszUserVerificationKeyName; } WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS_2, *PWEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS_2;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NS:webauthnplugin._WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS_2")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_OPTIONS_2
	{
		/// <summary>A pointer to a null-terminated string that contains the display name of the plugin authenticator.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszAuthenticatorName;

		/// <summary>A pointer to the class identifier of the plugin authenticator COM implementation.</summary>
		public GuidPtr pClsid;

		/// <summary>A pointer to a null-terminated relying-party identifier string used for nested WebAuthn calls that originate from the plugin.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszPluginRpId;

		/// <summary>An optional pointer to a base64-encoded SVG 1.1 logo to use in light theme.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszLightThemeLogoSvg;

		/// <summary>An optional pointer to a base64-encoded SVG 1.1 logo to use in dark theme.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszDarkThemeLogoSvg;

		/// <summary>The size, in bytes, of the CTAP CBOR authenticatorGetInfo payload pointed to by <b>pbAuthenticatorInfo</b>.</summary>
		public uint cbAuthenticatorInfo;

		/// <summary>A pointer to the CTAP CBOR authenticatorGetInfo payload.</summary>
		[SizeDef(nameof(cbAuthenticatorInfo))]
		public ArrayPointer<byte> pbAuthenticatorInfo;

		/// <summary>The number of entries in the array pointed to by <b>ppwszSupportedRpIds</b>. Specify zero if all relying parties are supported.</summary>
		public uint cSupportedRpIds;

		/// <summary>A pointer to an array of supported relying-party identifiers. Specify <b>NULL</b> if all relying parties are supported.</summary>
		[SizeDef(nameof(cSupportedRpIds))]
		public LPCWSTRArrayPointer ppwszSupportedRpIds;

		/// <summary>An optional pointer to the string name used with <c>KeyCredentialManager.RequestCreateAsync</c> from the same app context.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszUserVerificationKeyName;
	}

	/// <summary>Contains the response returned when a plugin authenticator is registered.</summary>
	/// <remarks>Use this structure with <c>WebAuthNPluginAddAuthenticator</c> or <c>EXPERIMENTAL_WebAuthNPluginAddAuthenticator2</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ns-webauthnplugin-webauthn_plugin_add_authenticator_response
	// typedef struct _WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_RESPONSE { DWORD cbOpSignPubKey; PBYTE pbOpSignPubKey; } WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_RESPONSE, *PWEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_RESPONSE;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NS:webauthnplugin._WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_RESPONSE")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_PLUGIN_ADD_AUTHENTICATOR_RESPONSE
	{
		/// <summary>The size, in bytes, of the operation-signing public key pointed to by <b>pbOpSignPubKey</b>.</summary>
		public uint cbOpSignPubKey;

		/// <summary>A pointer to the operation-signing public key that the plugin uses to sign <c>WEBAUTHN_PLUGIN_OPERATION_REQUEST</c> payloads.</summary>
		[SizeDef(nameof(cbOpSignPubKey))]
		public ArrayPointer<byte> pbOpSignPubKey;
	}

	/// <summary>Contains metadata for a credential exposed by a plugin authenticator.</summary>
	/// <remarks>Use this structure when adding, removing, or enumerating plugin credential metadata.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ns-webauthnplugin-webauthn_plugin_credential_details
	// typedef struct _WEBAUTHN_PLUGIN_CREDENTIAL_DETAILS { DWORD cbCredentialId; const BYTE *pbCredentialId; LPCWSTR pwszRpId; LPCWSTR pwszRpName; DWORD cbUserId; const BYTE *pbUserId; LPCWSTR pwszUserName; LPCWSTR pwszUserDisplayName; } WEBAUTHN_PLUGIN_CREDENTIAL_DETAILS, *PWEBAUTHN_PLUGIN_CREDENTIAL_DETAILS;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NS:webauthnplugin._WEBAUTHN_PLUGIN_CREDENTIAL_DETAILS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_PLUGIN_CREDENTIAL_DETAILS
	{
		/// <summary>The size, in bytes, of the credential identifier pointed to by <b>pbCredentialId</b>.</summary>
		public uint cbCredentialId;

		/// <summary>A pointer to the credential identifier bytes.</summary>
		[SizeDef(nameof(cbCredentialId))]
		public ArrayPointer<byte> pbCredentialId;

		/// <summary>A pointer to the relying-party identifier for the credential.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszRpId;

		/// <summary>A pointer to the friendly relying-party name, such as a site or organization name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszRpName;

		/// <summary>The size, in bytes, of the user identifier pointed to by <b>pbUserId</b>.</summary>
		public uint cbUserId;

		/// <summary>A pointer to the user identifier bytes.</summary>
		[SizeDef(nameof(cbUserId))]
		public ArrayPointer<byte> pbUserId;

		/// <summary>A pointer to the user name associated with the credential, such as an email address.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszUserName;

		/// <summary>A pointer to the friendly display name associated with the credential.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszUserDisplayName;
	}

	/// <summary>Contains updated metadata for a registered plugin authenticator.</summary>
	/// <remarks>Use this structure with <c>WebAuthNPluginUpdateAuthenticatorDetails</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ns-webauthnplugin-webauthn_plugin_update_authenticator_details
	// typedef struct _WEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS { LPCWSTR pwszAuthenticatorName; REFCLSID rclsid; REFCLSID rclsidNew; LPCWSTR pwszLightThemeLogoSvg; LPCWSTR pwszDarkThemeLogoSvg; DWORD cbAuthenticatorInfo; const BYTE *pbAuthenticatorInfo; DWORD cSupportedRpIds; const LPCWSTR *ppwszSupportedRpIds; } WEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS, *PWEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NS:webauthnplugin._WEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS
	{
		/// <summary>A pointer to a null-terminated string that contains the updated display name of the plugin authenticator.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszAuthenticatorName;

		/// <summary>The current class identifier of the plugin authenticator.</summary>
		public GuidPtr rclsid;

		/// <summary>The new class identifier for the plugin authenticator.</summary>
		public GuidPtr rclsidNew;

		/// <summary>An optional pointer to a base64-encoded SVG 1.1 logo to use in light theme. <b>NULL</b> removes the light-theme logo.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszLightThemeLogoSvg;

		/// <summary>An optional pointer to a base64-encoded SVG 1.1 logo to use in dark theme. <b>NULL</b> removes the dark-theme logo.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszDarkThemeLogoSvg;

		/// <summary>The size, in bytes, of the CTAP CBOR authenticatorGetInfo payload pointed to by <b>pbAuthenticatorInfo</b>.</summary>
		public uint cbAuthenticatorInfo;

		/// <summary>A pointer to the CTAP CBOR authenticatorGetInfo payload.</summary>
		[SizeDef(nameof(cbAuthenticatorInfo))]
		public ArrayPointer<byte> pbAuthenticatorInfo;

		/// <summary>The number of entries in the array pointed to by <b>ppwszSupportedRpIds</b>. Specify zero if all relying parties are supported.</summary>
		public uint cSupportedRpIds;

		/// <summary>A pointer to an array of supported relying-party identifiers. Specify <b>NULL</b> if all relying parties are supported.</summary>
		[SizeDef(nameof(cSupportedRpIds))]
		public LPCWSTRArrayPointer ppwszSupportedRpIds;
	}

	/// <summary>Contains extended metadata for updating a registered plugin authenticator.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ns-webauthnplugin-webauthn_plugin_update_authenticator_details_2
	// typedef struct _WEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS_2 { LPCWSTR pwszAuthenticatorName; const CLSID *pClsid; const CLSID *pClsidNew; LPCWSTR pwszLightThemeLogoSvg; LPCWSTR pwszDarkThemeLogoSvg; DWORD cbAuthenticatorInfo; const BYTE *pbAuthenticatorInfo; DWORD cSupportedRpIds; const LPCWSTR *ppwszSupportedRpIds; LPCWSTR pwszUserVerificationKeyName; } WEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS_2, *PWEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS_2;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NS:webauthnplugin._WEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS_2")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_PLUGIN_UPDATE_AUTHENTICATOR_DETAILS_2
	{
		/// <summary>A pointer to a null-terminated string that contains the updated display name of the plugin authenticator.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszAuthenticatorName;

		/// <summary>A pointer to the current class identifier of the plugin authenticator.</summary>
		public GuidPtr pClsid;

		/// <summary>A pointer to the new class identifier for the plugin authenticator.</summary>
		public GuidPtr pClsidNew;

		/// <summary>An optional pointer to a base64-encoded SVG 1.1 logo to use in light theme. <b>NULL</b> removes the light-theme logo.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszLightThemeLogoSvg;

		/// <summary>An optional pointer to a base64-encoded SVG 1.1 logo to use in dark theme. <b>NULL</b> removes the dark-theme logo.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszDarkThemeLogoSvg;

		/// <summary>The size, in bytes, of the CTAP CBOR authenticatorGetInfo payload pointed to by <b>pbAuthenticatorInfo</b>.</summary>
		public uint cbAuthenticatorInfo;

		/// <summary>A pointer to the CTAP CBOR authenticatorGetInfo payload.</summary>
		[SizeDef(nameof(cbAuthenticatorInfo))]
		public ArrayPointer<byte> pbAuthenticatorInfo;

		/// <summary>The number of entries in the array pointed to by <b>ppwszSupportedRpIds</b>. Specify zero if all relying parties are supported.</summary>
		public uint cSupportedRpIds;

		/// <summary>A pointer to an array of supported relying-party identifiers. Specify <b>NULL</b> if all relying parties are supported.</summary>
		[SizeDef(nameof(cSupportedRpIds))]
		public LPCWSTRArrayPointer ppwszSupportedRpIds;

		/// <summary>An optional pointer to the string name used with <c>KeyCredentialManager.RequestCreateAsync</c>. <b>NULL</b> removes the key name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszUserVerificationKeyName;
	}

	/// <summary>Describes a Windows Hello user-verification request for a plugin authenticator.</summary>
	/// <remarks>Use this structure with <c>WebAuthNPluginPerformUserVerification</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ns-webauthnplugin-webauthn_plugin_user_verification_request
	// typedef struct _WEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST { HWND hwnd; REFGUID rguidTransactionId; LPCWSTR pwszUsername; LPCWSTR pwszDisplayHint; } WEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST, *PWEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NS:webauthnplugin._WEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST
	{
		/// <summary>The window handle for the top-level plugin window that is currently in the foreground for the WebAuthn operation.</summary>
		public HWND hwnd;

		/// <summary>The transaction identifier from the corresponding <c>WEBAUTHN_PLUGIN_OPERATION_REQUEST</c>.</summary>
		public GuidPtr rguidTransactionId;

		/// <summary>A pointer to the user name associated with the credential in use for the WebAuthn operation.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszUsername;

		/// <summary>A pointer to the text hint displayed on the Windows Hello prompt.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszDisplayHint;
	}

	/// <summary>Describes an extended Windows Hello user-verification request for a plugin authenticator.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/webauthnplugin/ns-webauthnplugin-webauthn_plugin_user_verification_request_2
	// typedef struct _WEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST_2 { HWND hwnd; const GUID *pGuidTransactionId; LPCWSTR pwszUsername; LPCWSTR pwszDisplayHint; DWORD cbBufferToSign; PBYTE pbBufferToSign; } WEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST_2, *PWEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST_2;
	[PInvokeData("webauthnplugin.h", MSDNShortId = "NS:webauthnplugin._WEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST_2")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_PLUGIN_USER_VERIFICATION_REQUEST_2
	{
		/// <summary>The window handle for the top-level plugin window that is currently in the foreground for the WebAuthn operation.</summary>
		public HWND hwnd;

		/// <summary>A pointer to the transaction identifier from the corresponding <c>WEBAUTHN_PLUGIN_OPERATION_REQUEST</c>.</summary>
		public GuidPtr pGuidTransactionId;

		/// <summary>A pointer to the user name associated with the credential in use for the WebAuthn operation.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszUsername;

		/// <summary>A pointer to the text hint displayed on the Windows Hello prompt.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszDisplayHint;

		/// <summary>The size, in bytes, of the custom buffer pointed to by <b>pbBufferToSign</b>.</summary>
		public uint cbBufferToSign;

		/// <summary>An optional pointer to a custom buffer that the user-verification key signs. This API does not hash the buffer before signing it.</summary>
		[SizeDef(nameof(cbBufferToSign))]
		public ArrayPointer<byte> pbBufferToSign;
	}
}