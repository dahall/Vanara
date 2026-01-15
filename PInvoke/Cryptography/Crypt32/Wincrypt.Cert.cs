namespace Vanara.PInvoke;

/// <summary>Methods and data types found in Crypt32.dll.</summary>
public static partial class Crypt32
{
	/// <summary>A set of flags that override the default behavior of this function.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "89028c4e-f896-4c50-9fa2-bcb4e1784244")]
	[Flags]
	public enum CertCreateSelfSignFlags
	{
		/// <summary>
		/// By default, the returned PCCERT_CONTEXT references the private keys by setting the CERT_KEY_PROV_INFO_PROP_ID. If you do not
		/// want the returned PCCERT_CONTEXT to reference private keys by setting the CERT_KEY_PROV_INFO_PROP_ID, specify CERT_CREATE_SELFSIGN_NO_KEY_INFO.
		/// </summary>
		CERT_CREATE_SELFSIGN_NO_KEY_INFO = 2,

		/// <summary>
		/// By default, the certificate being created is signed. If the certificate being created is only a dummy placeholder, the
		/// certificate might not need to be signed. Signing of the certificate is skipped if CERT_CREATE_SELFSIGN_NO_SIGN is specified.
		/// </summary>
		CERT_CREATE_SELFSIGN_NO_SIGN = 1,
	}

	/// <summary>Specifies the type of selection criteria used for the <c>ppPara</c> member.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "246722a9-5db6-4a82-8f29-f60f0a2263e3")]
	public enum CertSelectBy : uint
	{
		/// <summary>
		/// Select certificates based on a specific enhanced key usage. When this flag is set, the ppPara must reference a
		/// null-terminated object identifier (OID) ANSI string that specifies the enhanced key usage.
		/// <para>This criteria is evaluated on the certificate.</para>
		/// </summary>
		CERT_SELECT_BY_ENHKEY_USAGE = 1,

		/// <summary>
		/// Select certificates based on a specific szOID_KEY_USAGE extension in the certificate. When this flag is set, the ppPara
		/// member must reference a CERT_EXTENSION structure where the value of the extension is a DWORD that identifies the Key Usage bits.
		/// <para>This criteria is evaluated on the certificate.</para>
		/// </summary>
		CERT_SELECT_BY_KEY_USAGE = 2,

		/// <summary>
		/// Select certificates based on a specific issuance policy. The ppPara member must reference a null-terminated OID ANSI string
		/// of the desired issuance policy.
		/// <para>This criteria is evaluated on the issuance policy of the certificate chain.</para>
		/// </summary>
		CERT_SELECT_BY_POLICY_OID = 3,

		/// <summary>
		/// Select certificates based on a specific private key provider. The ppPara member must reference a null-terminated Unicode
		/// string that represents the name of the provider.
		/// </summary>
		CERT_SELECT_BY_PROV_NAME = 4,

		/// <summary>
		/// Select certificates based on the presence of a specified extension and an optional specified value. The ppPara member must
		/// reference a CERT_EXTENSION structure that specifies the extension OID and the associated value.
		/// </summary>
		CERT_SELECT_BY_EXTENSION = 5,

		/// <summary>
		/// Select certificates based on the Subject DNS HOST Name. The ppPara member must reference a null-terminated Unicode string
		/// that contains the subject host name. The selection performed based on this flag is the same as the evaluation of the
		/// pwszServerName member of the SSL_EXTRA_CERT_CHAIN_POLICY_PARA structure during a call to the
		/// CertVerifyCertificateChainPolicy function.
		/// <para>This criteria is evaluated on the certificate.</para>
		/// </summary>
		CERT_SELECT_BY_SUBJECT_HOST_NAME = 6,

		/// <summary>
		/// Select certificates based on the relative distinguished name (RDN) element of the issuer of the certificate. The ppPara
		/// member must reference a CERT_RDN structure that contains the RDN element of the issuer.
		/// <para>This criteria is evaluated on the certificate chain.</para>
		/// </summary>
		CERT_SELECT_BY_ISSUER_ATTR = 7,

		/// <summary>
		/// Select certificates based on the RDN element in the Subject of the certificate. The ppPara member must be a reference to a
		/// CERT_RDN structure that contains the RDN element of the Subject.
		/// <para>This criteria is evaluated on the certificate.</para>
		/// </summary>
		CERT_SELECT_BY_SUBJECT_ATTR = 8,

		/// <summary>
		/// Select certificates based on the issuer of the certificate. The ppPara member must be a reference to a CERT_NAME_BLOB
		/// structure that contains the name of the issuer.
		/// <para>This criteria is evaluated on the certificate chain.</para>
		/// </summary>
		CERT_SELECT_BY_ISSUER_NAME = 9,

		/// <summary>
		/// Select certificates based on the public key of the certificate. The ppPara member must reference a pointer to a
		/// CERT_PUBLIC_KEY_INFO structure that contains the public key.
		/// <para>This criteria is evaluated on the certificate.</para>
		/// </summary>
		CERT_SELECT_BY_PUBLIC_KEY = 10,

		/// <summary>
		/// Select certificates based on the Transport Layer Security protocol (TLS) Signature requirement. The ppPara member must
		/// reference a SecPkgContext_SupportedSignatures structure.
		/// <para>This criteria is evaluated on the certificate.</para>
		/// </summary>
		CERT_SELECT_BY_TLS_SIGNATURES = 11,
	}

	/// <summary>Flags for controlling the certificate selection process.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "b740772b-d25b-4b3d-9acb-03f7018750d6")]
	public enum CertSelection : uint
	{
		/// <summary>
		/// Select expired certificates that meet selection criteria. By default expired certificates are rejected from selection.
		/// </summary>
		CERT_SELECT_ALLOW_EXPIRED = 0x00000001,

		/// <summary>
		/// Select certificates on which the error bit in the certificate chain trust status is not set to CERT_TRUST_IS_UNTRUSTED_ROOT,
		/// CERT_TRUST_IS_PARTIAL_CHAIN, or CERT_TRUST_IS_NOT_TIME_VALID.
		/// <para>In addition, certificates that have one of the following invalid constraint errors are not selected:</para>
		/// <para>CERT_TRUST_INVALID_POLICY_CONSTRAINTS</para>
		/// <para>CERT_TRUST_INVALID_BASIC_CONSTRAINTS</para>
		/// <para>CERT_TRUST_INVALID_NAME_CONSTRAINTS</para>
		/// </summary>
		CERT_SELECT_TRUSTED_ROOT = 0x00000002,

		/// <summary>Select certificates that are not self-issued and self-signed.</summary>
		CERT_SELECT_DISALLOW_SELFSIGNED = 0x00000004,

		/// <summary>Select certificates that have a value set for the CERT_KEY_PROV_INFO_PROP_ID property of the certificate.</summary>
		CERT_SELECT_HAS_PRIVATE_KEY = 0x00000008,

		/// <summary>
		/// Select certificates on which the value of the dwKeySpec member of the CERT_KEY_PROV_INFO_PROP_ID property is set to AT_SIGNATURE.
		/// <para>
		/// If this function is being called as part of a CNG enabled application and the dwKeySpec member of the
		/// CERT_KEY_PROV_INFO_PROP_ID property is set to -1, select certificates on which the value of the NCRYPT_KEY_USAGE_PROPERTY
		/// property of the associated private key has the NCRYPT_ALLOW_SIGNING_FLAG set.
		/// </para>
		/// </summary>
		CERT_SELECT_HAS_KEY_FOR_SIGNATURE = 0x00000010,

		/// <summary>
		/// Select certificates on which the value of the dwKeySpec member of the CERT_KEY_PROV_INFO_PROP_ID property is set to AT_KEYEXCHANGE.
		/// <para>
		/// If this function is being called as part of a CNG enabled application and the dwKeySpec member of the
		/// CERT_KEY_PROV_INFO_PROP_ID property is set to -1, select certificates on which either NCRYPT_ALLOW_DECRYPT_FLAG or
		/// NCRYPT_ALLOW_KEY_AGREEMENT_FLAG is set.
		/// </para>
		/// </summary>
		CERT_SELECT_HAS_KEY_FOR_KEY_EXCHANGE = 0x00000020,

		/// <summary>
		/// Select certificates on which the value of the PP_IMPTYPE property of the associated private key provider is set to either
		/// CRYPT_IMPL_HARDWARE or CRYPT_IMPL_REMOVABLE. (For CNG providers, NCRYPT_IMPL_TYPE_PROPERTY property value MUST have either
		/// the NCRYPT_IMPL_HARDWARE_FLAG or NCRYPT_IMPL_REMOVABLE_FLAG bit set).
		/// <para>
		/// If this function is being called as part of a CNG enabled application, select certificates on which the
		/// NCRYPT_IMPL_TYPE_PROPERTY property is set to NCRYPT_IMPL_HARDWARE_FLAG or NCRYPT_IMPL_REMOVABLE_FLAG.
		/// </para>
		/// </summary>
		CERT_SELECT_HARDWARE_ONLY = 0x00000040,

		/// <summary>
		/// Allow the selection of certificates on which the Subject and Subject Alt Name contain the same information and the
		/// certificate template extension value is equivalent. By default when certificates match this criteria, only the most recent
		/// certificate is selected.
		/// </summary>
		CERT_SELECT_ALLOW_DUPLICATES = 0x00000080,

		/// <summary/>
		CERT_SELECT_IGNORE_AUTOSELECT = 0x00000100,
	}

	/// <summary>A set of flags that specify how the information should be retrieved.</summary>
	[Flags]
	public enum CryptRetrievalFlags
	{
		/// <summary>
		/// Validates the content retrieved by a wire URL before writing the URL to the cache. The default provider does not support the
		/// HTTPS protocol for AIA retrievals.
		/// </summary>
		CRYPT_AIA_RETRIEVAL = 0x00080000,

		/// <summary>This value is not supported.</summary>
		CRYPT_ASYNC_RETRIEVAL = 0x00000010,

		/// <summary>Retrieves the encoded bits from the URL cache only. Do not use the wire to retrieve the URL.</summary>
		CRYPT_CACHE_ONLY_RETRIEVAL = 0x00000002,

		/// <summary>The crypt create new flush entry</summary>
		CRYPT_CREATE_NEW_FLUSH_ENTRY = 0x10000000,

		/// <summary>Does not store the retrieved encoded bits to the URL cache. If this flag is not set, the retrieved URL is cached.</summary>
		CRYPT_DONT_CACHE_RESULT = 0x00000008,

		/// <summary>The crypt enable file retrieval</summary>
		CRYPT_ENABLE_FILE_RETRIEVAL = 0x08000000,

		/// <summary>The crypt enable SSL revocation retrieval</summary>
		CRYPT_ENABLE_SSL_REVOCATION_RETRIEVAL = 0x00800000,

		/// <summary>
		/// <para>Uses the POST method instead of the default GET method for HTTP retrievals.</para>
		/// <para>In a POST URL, additional binary data and header strings are appended to the base URL in the following format:</para>
		/// <para><em>BaseURL/OptionalURLEscaped&amp;Base64EncodedAdditionalData?OptionalAdditionalHTTPHeaders</em></para>
		/// <para>
		/// The following example shows the additional binary data delimited by the last slash mark (/) and a Content-Type header
		/// delimited by a question mark (?) appended to a base URL.
		/// </para>
		/// <para>
		/// <c>http://ocsp.openvalidation.org/MEIwQDA%2BMDwwOjAJBgUrDgMCGgUABBQdKNEwjytjKBQADcgM61jfflNpyQQUv1NDgnjQnsOA5RtnygUA37lIg6UCAQI%3D?Content-Type: application/ocsp-request</c>
		/// </para>
		/// <para>
		/// When this flag is set, the <strong>CryptRetrieveObjectByUrl</strong> function parses the URL by using the last slash mark
		/// (/) and question mark (?) delimiters. The string, which is delimited by a slash mark (/), contains an unescaped URL (that
		/// is, a plain text URL without escape characters or escape sequences) and Base64 data decoded into binary form before being
		/// passed to the WinHttpSendRequest function as the lpOptional parameter. The string delimited by a question mark (?) is passed
		/// to the <strong>WinHttpSendRequest</strong> function as the pwszHeaders parameter.
		/// </para>
		/// </summary>
		CRYPT_HTTP_POST_RETRIEVAL = 0x00100000,

		/// <summary>
		/// Performs A-Record-only DNS lookup on the supplied host string, preventing the generation of false DNS queries when resolving
		/// host names. This flag should be used when passing a host name as opposed to a domain name.
		/// </summary>
		CRYPT_LDAP_AREC_EXCLUSIVE_RETRIEVAL = 0x00040000,

		/// <summary>
		/// Retrieves the entry index and attribute name for each LDAP object. The beginning of each returned BLOB contains the
		/// following ANSI string:
		/// <para><c>"entry index in decimal\0attribute name\0"</c></para>
		/// <para>When this flag is set, pszObjectOid must be NULL so that a BLOB is returned. This flag only applies to the ldap scheme.</para>
		/// </summary>
		CRYPT_LDAP_INSERT_ENTRY_ATTRIBUTE = 0x00008000,

		/// <summary>Fails if the LDAP search scope is not set to base in the URL. Use with LDAP only.</summary>
		CRYPT_LDAP_SCOPE_BASE_ONLY_RETRIEVAL = 0x00002000,

		/// <summary>
		/// Digitally signs all of the LDAP traffic to and from a server by using the Kerberos authentication protocol. This feature
		/// provides integrity required by some applications.
		/// </summary>
		CRYPT_LDAP_SIGN_RETRIEVAL = 0x00010000,

		/// <summary>Inhibits automatic authentication handling.</summary>
		CRYPT_NO_AUTH_RETRIEVAL = 0x00020000,

		/// <summary>
		/// Enables a conditional HTTP URL retrieval. When this flag is set, for a conditional retrieval that returns
		/// HTTP_STATUS_NOT_MODIFIED, CryptRetrieveObjectByUrl returns TRUE and ppvObject is set to NULL. If pAuxInfo is not NULL,
		/// dwHttpStatusCode is set to HTTP_STATUS_NOT_MODIFIED. Otherwise, ppvObject is updated for a successful retrieval.
		/// </summary>
		CRYPT_NOT_MODIFIED_RETRIEVAL = 0x00400000,

		/// <summary>
		/// Keeps track of offline failures and delays before hitting the wire on subsequent retrievals. This value is for wire
		/// retrieval only.
		/// </summary>
		CRYPT_OFFLINE_CHECK_RETRIEVAL = 0x00004000,

		/// <summary>
		/// Enables proxy cache retrieval of an object. If a proxy cache was not explicitly bypassed, fProxyCacheRetrieval is set to
		/// TRUE in pAuxInfo. This value only applies to HTTP URL retrievals.
		/// </summary>
		CRYPT_PROXY_CACHE_RETRIEVAL = 0x00200000,

		/// <summary/>
		CRYPT_RANDOM_QUERY_STRING_RETRIEVAL = 0x04000000,

		/// <summary>
		/// Retrieves multiple objects if available. All objects must be of a homogeneous object type as determined by the value of
		/// pszObjectOid, unless the object identifier (OID) value is CONTEXT_OID_CAPI2_ANY.
		/// </summary>
		CRYPT_RETRIEVE_MULTIPLE_OBJECTS = 0x00000001,

		/// <summary>Tags the URL as exempt from being flushed from the cache. For more information, see STICKY_CACHE_ENTRY in INTERNET_CACHE_ENTRY_INFO.</summary>
		CRYPT_STICKY_CACHE_RETRIEVAL = 0x00001000,

		/// <summary>Retrieves the encoded bits from the wire only. Does not use the URL cache.</summary>
		CRYPT_WIRE_ONLY_RETRIEVAL = 0x00000004,
	}

	/// <summary>The <c>CertAddCertificateContextToStore</c> function adds a certificate context to the certificate store.</summary>
	/// <param name="hCertStore">Handle of a certificate store.</param>
	/// <param name="pCertContext">A pointer to the CERT_CONTEXT structure to be added to the store.</param>
	/// <param name="dwAddDisposition">
	/// <para>
	/// Specifies the action to take if a matching certificate or a link to a matching certificate already exists in the store.
	/// Currently defined disposition values and their uses are as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_ADD_ALWAYS</term>
	/// <term>
	/// The function makes no check for an existing matching certificate or link to a matching certificate. A new certificate is always
	/// added to the store. This can lead to duplicates in a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEW</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists, the operation fails. GetLastError returns the
	/// CRYPT_E_EXISTS code.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEWER</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists and the NotBefore time of the existing context is equal to
	/// or greater than the NotBefore time of the new context being added, the operation fails and GetLastError returns the
	/// CRYPT_E_EXISTS code. If the NotBefore time of the existing context is less than the NotBefore time of the new context being
	/// added, the existing certificate or link is deleted and a new certificate is created and added to the store. If a matching
	/// certificate or a link to a matching certificate does not exist, a new link is added. If certificate revocation lists (CRLs) or
	/// certificate trust list (CTLs) are being compared, the ThisUpdate time is used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEWER_INHERIT_PROPERTIES</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists and the NotBefore time of the existing context is equal to
	/// or greater than the NotBefore time of the new context being added, the operation fails and GetLastError returns the
	/// CRYPT_E_EXISTS code. If the NotBefore time of the existing context is less than the NotBefore time of the new context being
	/// added, the existing context is deleted before creating and adding the new context. The new added context inherits properties
	/// from the existing certificate. If CRLs or CTLs are being compared, the ThisUpdate time is used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
	/// <term>
	/// If a link to a matching certificate exists, that existing certificate or link is deleted and a new certificate is created and
	/// added to the store. If a matching certificate or a link to a matching certificate does not exist, a new link is added.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING_INHERIT_PROPERTIES</term>
	/// <term>
	/// If a matching certificate exists in the store, the existing context is not replaced. The existing context inherits properties
	/// from the new certificate.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_USE_EXISTING</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists, that existing certificate or link is used and properties
	/// from the new certificate are added. The function does not fail, but it does not add a new context. If pCertContext is not NULL,
	/// the existing context is duplicated. If a matching certificate or a link to a matching certificate does not exist, a new
	/// certificate is added.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppStoreContext">
	/// <para>A pointer to a pointer to the copy to be made of the certificate that was added to the store.</para>
	/// <para>
	/// The ppStoreContext parameter can be <c>NULL</c>, indicating that the calling application does not require a copy of the added
	/// certificate. If a copy is made, it must be freed by using CertFreeCertificateContext.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError. Some possible error
	/// codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_EXISTS</term>
	/// <term>
	/// This value is returned if CERT_STORE_ADD_NEW is set and the certificate already exists in the store, or if CERT_STORE_ADD_NEWER
	/// is set and a certificate exists in the store with a NotBefore date greater than or equal to the NotBefore date on the
	/// certificate to be added.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>A disposition value that is not valid was specified in the dwAddDisposition parameter.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Errors from the called functions, CertAddEncodedCertificateToStore and CertSetCertificateContextProperty, can be propagated to
	/// this function.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The certificate context is not duplicated using CertDuplicateCertificateContext. Instead, the function creates a new copy of the
	/// context and adds it to the store.
	/// </para>
	/// <para>
	/// In addition to the encoded certificate, CertDuplicateCertificateContext also copies the context's properties, with the exception
	/// of the CERT_KEY_PROV_HANDLE_PROP_ID and CERT_KEY_CONTEXT_PROP_ID properties.
	/// </para>
	/// <para>To remove the certificate context from the certificate store, use the CertDeleteCertificateFromStore function.</para>
	/// <para>
	/// <c>Note</c> The order of the certificate context may not be preserved within the store. To access a specific certificate you
	/// must iterate across the certificates in the store.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddcertificatecontexttostore BOOL
	// CertAddCertificateContextToStore( HCERTSTORE hCertStore, PCCERT_CONTEXT pCertContext, DWORD dwAddDisposition, PCCERT_CONTEXT
	// *ppStoreContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "5e4d8cae-1096-491f-9a04-92b7e9c020bb")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertAddCertificateContextToStore([In, AddAsMember] HCERTSTORE hCertStore, [In] PCCERT_CONTEXT pCertContext, CertStoreAdd dwAddDisposition, out SafePCCERT_CONTEXT ppStoreContext);

	/// <summary>The <c>CertAddCertificateContextToStore</c> function adds a certificate context to the certificate store.</summary>
	/// <param name="hCertStore">Handle of a certificate store.</param>
	/// <param name="pCertContext">A pointer to the CERT_CONTEXT structure to be added to the store.</param>
	/// <param name="dwAddDisposition">
	/// <para>
	/// Specifies the action to take if a matching certificate or a link to a matching certificate already exists in the store.
	/// Currently defined disposition values and their uses are as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_ADD_ALWAYS</term>
	/// <term>
	/// The function makes no check for an existing matching certificate or link to a matching certificate. A new certificate is always
	/// added to the store. This can lead to duplicates in a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEW</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists, the operation fails. GetLastError returns the
	/// CRYPT_E_EXISTS code.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEWER</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists and the NotBefore time of the existing context is equal to
	/// or greater than the NotBefore time of the new context being added, the operation fails and GetLastError returns the
	/// CRYPT_E_EXISTS code. If the NotBefore time of the existing context is less than the NotBefore time of the new context being
	/// added, the existing certificate or link is deleted and a new certificate is created and added to the store. If a matching
	/// certificate or a link to a matching certificate does not exist, a new link is added. If certificate revocation lists (CRLs) or
	/// certificate trust list (CTLs) are being compared, the ThisUpdate time is used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEWER_INHERIT_PROPERTIES</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists and the NotBefore time of the existing context is equal to
	/// or greater than the NotBefore time of the new context being added, the operation fails and GetLastError returns the
	/// CRYPT_E_EXISTS code. If the NotBefore time of the existing context is less than the NotBefore time of the new context being
	/// added, the existing context is deleted before creating and adding the new context. The new added context inherits properties
	/// from the existing certificate. If CRLs or CTLs are being compared, the ThisUpdate time is used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
	/// <term>
	/// If a link to a matching certificate exists, that existing certificate or link is deleted and a new certificate is created and
	/// added to the store. If a matching certificate or a link to a matching certificate does not exist, a new link is added.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING_INHERIT_PROPERTIES</term>
	/// <term>
	/// If a matching certificate exists in the store, the existing context is not replaced. The existing context inherits properties
	/// from the new certificate.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_USE_EXISTING</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists, that existing certificate or link is used and properties
	/// from the new certificate are added. The function does not fail, but it does not add a new context. If pCertContext is not NULL,
	/// the existing context is duplicated. If a matching certificate or a link to a matching certificate does not exist, a new
	/// certificate is added.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppStoreContext">
	/// <para>A pointer to a pointer to the copy to be made of the certificate that was added to the store.</para>
	/// <para>
	/// The ppStoreContext parameter can be <c>NULL</c>, indicating that the calling application does not require a copy of the added
	/// certificate. If a copy is made, it must be freed by using CertFreeCertificateContext.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError. Some possible error
	/// codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_EXISTS</term>
	/// <term>
	/// This value is returned if CERT_STORE_ADD_NEW is set and the certificate already exists in the store, or if CERT_STORE_ADD_NEWER
	/// is set and a certificate exists in the store with a NotBefore date greater than or equal to the NotBefore date on the
	/// certificate to be added.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>A disposition value that is not valid was specified in the dwAddDisposition parameter.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Errors from the called functions, CertAddEncodedCertificateToStore and CertSetCertificateContextProperty, can be propagated to
	/// this function.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The certificate context is not duplicated using CertDuplicateCertificateContext. Instead, the function creates a new copy of the
	/// context and adds it to the store.
	/// </para>
	/// <para>
	/// In addition to the encoded certificate, CertDuplicateCertificateContext also copies the context's properties, with the exception
	/// of the CERT_KEY_PROV_HANDLE_PROP_ID and CERT_KEY_CONTEXT_PROP_ID properties.
	/// </para>
	/// <para>To remove the certificate context from the certificate store, use the CertDeleteCertificateFromStore function.</para>
	/// <para>
	/// <c>Note</c> The order of the certificate context may not be preserved within the store. To access a specific certificate you
	/// must iterate across the certificates in the store.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddcertificatecontexttostore BOOL
	// CertAddCertificateContextToStore( HCERTSTORE hCertStore, PCCERT_CONTEXT pCertContext, DWORD dwAddDisposition, PCCERT_CONTEXT
	// *ppStoreContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "5e4d8cae-1096-491f-9a04-92b7e9c020bb")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertAddCertificateContextToStore([In, AddAsMember] HCERTSTORE hCertStore, [In] PCCERT_CONTEXT pCertContext, CertStoreAdd dwAddDisposition, [Optional, Ignore] IntPtr ppStoreContext);

	/// <summary>
	/// The <c>CertAddCertificateLinkToStore</c> function adds a link in a certificate store to a certificate context in a different
	/// store. Instead of creating and adding a duplicate of the certificate context, this function adds a link to the original certificate.
	/// </summary>
	/// <param name="hCertStore">A handle to the certificate store where the link is to be added.</param>
	/// <param name="pCertContext">A pointer to the CERT_CONTEXT structure to be linked.</param>
	/// <param name="dwAddDisposition">
	/// <para>
	/// Specifies the action if a matching certificate or a link to a matching certificate already exists in the store. Currently
	/// defined disposition values and their uses are as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_ADD_ALWAYS</term>
	/// <term>
	/// The function makes no check for an existing matching certificate or link to a matching certificate. A new certificate is always
	/// added to the store. This can lead to duplicates in a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEW</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists, the operation fails. GetLastError returns the
	/// CRYPT_E_EXISTS code.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
	/// <term>
	/// If a link to a matching certificate exists, that existing link is deleted and a new link is created and added to the store. If
	/// no matching certificate or link to a matching certificate exists, one is added.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_USE_EXISTING</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists, the existing certificate is used. The function does not
	/// fail, but no new link is added. If no matching certificate or link to a matching certificate exists, a new link is added.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppStoreContext">
	/// A pointer to a pointer to a copy of the link created. The ppStoreContext parameter can be <c>NULL</c> to indicate that a copy of
	/// the link is not needed. If a copy of the link is created, that copy must be freed using the CertFreeCertificateContext function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError. Some possible error
	/// codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_EXISTS</term>
	/// <term>For a dwAddDisposition parameter of CERT_STORE_ADD_NEW, the certificate already exists in the store.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>A disposition value that is not valid was specified in the dwAddDisposition parameter.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Because the link provides access to the original certificate context, setting an extended property in the linked certificate
	/// context changes that extended property in the certificate's original location and in any other links to that certificate.
	/// </para>
	/// <para>
	/// Links cannot be added to a store opened as a collection. Stores opened as collections include all stores opened with
	/// CertOpenSystemStore or CertOpenStore using CERT_STORE_PROV_SYSTEM or CERT_STORE_PROV_COLLECTION. For more information, see CertAddStoreToCollection.
	/// </para>
	/// <para>
	/// If links are used and CertCloseStore is called with CERT_CLOSE_STORE_FORCE_FLAG, the store that uses links must be closed before
	/// the store that contains the original contexts is closed. If CERT_CLOSE_STORE_FORCE_FLAG is not used, the two stores can be
	/// closed in either order.
	/// </para>
	/// <para>To remove the certificate context link from the certificate store, use the CertDeleteCertificateFromStore function.</para>
	/// <para>Examples</para>
	/// <para>
	/// For an example that uses this function, see Example C Program: Certificate Store Operations. For additional code that uses this
	/// function, see Example C Program: Collection and Sibling Certificate Store Operations.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddcertificatelinktostore BOOL
	// CertAddCertificateLinkToStore( HCERTSTORE hCertStore, PCCERT_CONTEXT pCertContext, DWORD dwAddDisposition, PCCERT_CONTEXT
	// *ppStoreContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "bcbf7755-d0ce-4dd5-8462-72760364fdc3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertAddCertificateLinkToStore([In, AddAsMember] HCERTSTORE hCertStore, [In] PCCERT_CONTEXT pCertContext, CertStoreAdd dwAddDisposition, out SafePCCERT_CONTEXT ppStoreContext);

	/// <summary>
	/// The <c>CertAddCertificateLinkToStore</c> function adds a link in a certificate store to a certificate context in a different
	/// store. Instead of creating and adding a duplicate of the certificate context, this function adds a link to the original certificate.
	/// </summary>
	/// <param name="hCertStore">A handle to the certificate store where the link is to be added.</param>
	/// <param name="pCertContext">A pointer to the CERT_CONTEXT structure to be linked.</param>
	/// <param name="dwAddDisposition">
	/// <para>
	/// Specifies the action if a matching certificate or a link to a matching certificate already exists in the store. Currently
	/// defined disposition values and their uses are as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_ADD_ALWAYS</term>
	/// <term>
	/// The function makes no check for an existing matching certificate or link to a matching certificate. A new certificate is always
	/// added to the store. This can lead to duplicates in a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEW</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists, the operation fails. GetLastError returns the
	/// CRYPT_E_EXISTS code.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
	/// <term>
	/// If a link to a matching certificate exists, that existing link is deleted and a new link is created and added to the store. If
	/// no matching certificate or link to a matching certificate exists, one is added.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_USE_EXISTING</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists, the existing certificate is used. The function does not
	/// fail, but no new link is added. If no matching certificate or link to a matching certificate exists, a new link is added.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppStoreContext">
	/// A pointer to a pointer to a copy of the link created. The ppStoreContext parameter can be <c>NULL</c> to indicate that a copy of
	/// the link is not needed. If a copy of the link is created, that copy must be freed using the CertFreeCertificateContext function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError. Some possible error
	/// codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_EXISTS</term>
	/// <term>For a dwAddDisposition parameter of CERT_STORE_ADD_NEW, the certificate already exists in the store.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>A disposition value that is not valid was specified in the dwAddDisposition parameter.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Because the link provides access to the original certificate context, setting an extended property in the linked certificate
	/// context changes that extended property in the certificate's original location and in any other links to that certificate.
	/// </para>
	/// <para>
	/// Links cannot be added to a store opened as a collection. Stores opened as collections include all stores opened with
	/// CertOpenSystemStore or CertOpenStore using CERT_STORE_PROV_SYSTEM or CERT_STORE_PROV_COLLECTION. For more information, see CertAddStoreToCollection.
	/// </para>
	/// <para>
	/// If links are used and CertCloseStore is called with CERT_CLOSE_STORE_FORCE_FLAG, the store that uses links must be closed before
	/// the store that contains the original contexts is closed. If CERT_CLOSE_STORE_FORCE_FLAG is not used, the two stores can be
	/// closed in either order.
	/// </para>
	/// <para>To remove the certificate context link from the certificate store, use the CertDeleteCertificateFromStore function.</para>
	/// <para>Examples</para>
	/// <para>
	/// For an example that uses this function, see Example C Program: Certificate Store Operations. For additional code that uses this
	/// function, see Example C Program: Collection and Sibling Certificate Store Operations.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddcertificatelinktostore BOOL
	// CertAddCertificateLinkToStore( HCERTSTORE hCertStore, PCCERT_CONTEXT pCertContext, DWORD dwAddDisposition, PCCERT_CONTEXT
	// *ppStoreContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "bcbf7755-d0ce-4dd5-8462-72760364fdc3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertAddCertificateLinkToStore([In, AddAsMember] HCERTSTORE hCertStore, [In] PCCERT_CONTEXT pCertContext, CertStoreAdd dwAddDisposition, [Optional, Ignore] IntPtr ppStoreContext);

	/// <summary>
	/// <para>
	/// The <c>CertAddEncodedCertificateToStore</c> function creates a certificate context from an encoded certificate and adds it to
	/// the certificate store. The context created does not include any extended properties.
	/// </para>
	/// <para>
	/// The <c>CertAddEncodedCertificateToStore</c> function also makes a copy of the encoded certificate before adding the certificate
	/// to the store.
	/// </para>
	/// </summary>
	/// <param name="hCertStore">A handle to the certificate store.</param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the type of encoding used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbCertEncoded">
	/// A pointer to a buffer containing the encoded certificate that is to be added to the certificate store.
	/// </param>
	/// <param name="cbCertEncoded">The size, in bytes, of the pbCertEncoded buffer.</param>
	/// <param name="dwAddDisposition">
	/// <para>
	/// Specifies the action to take if a matching certificate or link to a matching certificate exists in the store. Currently defined
	/// disposition values and their uses are as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_ADD_ALWAYS</term>
	/// <term>
	/// The function makes no check for an existing matching certificate or link to a matching certificate. A new certificate is always
	/// added to the store. This can lead to duplicates in a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEW</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists in the store, the operation fails. GetLastError returns the
	/// CRYPT_E_EXISTS code.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
	/// <term>
	/// If a matching certificate or link to a matching certificate exists in the store, the existing certificate or link is deleted and
	/// a new certificate is created and added to the store. If a matching certificate or link to a matching certificate does not exist,
	/// a new certificate is created and added to the store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING_INHERIT_PROPERTIES</term>
	/// <term>
	/// If a matching certificate exists in the store, that existing context is deleted before creating and adding the new context. The
	/// new context inherits properties from the existing certificate.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_USE_EXISTING</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists, that existing certificate or link is used and properties
	/// from the new certificate are added. The function does not fail, but it does not add a new context. If ppCertContext is not NULL,
	/// the existing context is duplicated. If a matching certificate or link to a matching certificate does not exist, a new
	/// certificate is added.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppCertContext">
	/// A pointer to a pointer to the decoded certificate context. This is an optional parameter that can be <c>NULL</c>, indicating
	/// that the calling application does not require a copy of the new or existing certificate. When a copy is made, its context must
	/// be freed by using CertFreeCertificateContext.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError. Some possible error
	/// codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_EXISTS</term>
	/// <term>
	/// This code is returned if CERT_STORE_ADD_NEW is set and the certificate already exists in the store, or if CERT_STORE_ADD_NEWER
	/// is set and there is a certificate in the store with a NotBefore date greater than or equal to the NotBefore date on the
	/// certificate to be added.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// A disposition value that is not valid was specified in the dwAddDisposition parameter, or a certificate encoding type that is
	/// not valid was specified. Currently, only the X509_ASN_ENCODING type is supported.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError returns an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddencodedcertificatetostore BOOL
	// CertAddEncodedCertificateToStore( HCERTSTORE hCertStore, DWORD dwCertEncodingType, const BYTE *pbCertEncoded, DWORD
	// cbCertEncoded, DWORD dwAddDisposition, PCCERT_CONTEXT *ppCertContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "7c092bf5-f8b2-47d0-94ee-c8e0f4bca62d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertAddEncodedCertificateToStore([In, AddAsMember] HCERTSTORE hCertStore, CertEncodingType dwCertEncodingType, [In, SizeDef(nameof(cbCertEncoded))] IntPtr pbCertEncoded,
		uint cbCertEncoded, CertStoreAdd dwAddDisposition, out SafePCCERT_CONTEXT ppCertContext);

	/// <summary>
	/// <para>
	/// The <c>CertAddEncodedCertificateToStore</c> function creates a certificate context from an encoded certificate and adds it to
	/// the certificate store. The context created does not include any extended properties.
	/// </para>
	/// <para>
	/// The <c>CertAddEncodedCertificateToStore</c> function also makes a copy of the encoded certificate before adding the certificate
	/// to the store.
	/// </para>
	/// </summary>
	/// <param name="hCertStore">A handle to the certificate store.</param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the type of encoding used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbCertEncoded">
	/// A pointer to a buffer containing the encoded certificate that is to be added to the certificate store.
	/// </param>
	/// <param name="cbCertEncoded">The size, in bytes, of the pbCertEncoded buffer.</param>
	/// <param name="dwAddDisposition">
	/// <para>
	/// Specifies the action to take if a matching certificate or link to a matching certificate exists in the store. Currently defined
	/// disposition values and their uses are as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_ADD_ALWAYS</term>
	/// <term>
	/// The function makes no check for an existing matching certificate or link to a matching certificate. A new certificate is always
	/// added to the store. This can lead to duplicates in a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEW</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists in the store, the operation fails. GetLastError returns the
	/// CRYPT_E_EXISTS code.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
	/// <term>
	/// If a matching certificate or link to a matching certificate exists in the store, the existing certificate or link is deleted and
	/// a new certificate is created and added to the store. If a matching certificate or link to a matching certificate does not exist,
	/// a new certificate is created and added to the store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING_INHERIT_PROPERTIES</term>
	/// <term>
	/// If a matching certificate exists in the store, that existing context is deleted before creating and adding the new context. The
	/// new context inherits properties from the existing certificate.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_USE_EXISTING</term>
	/// <term>
	/// If a matching certificate or a link to a matching certificate exists, that existing certificate or link is used and properties
	/// from the new certificate are added. The function does not fail, but it does not add a new context. If ppCertContext is not NULL,
	/// the existing context is duplicated. If a matching certificate or link to a matching certificate does not exist, a new
	/// certificate is added.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppCertContext">
	/// A pointer to a pointer to the decoded certificate context. This is an optional parameter that can be <c>NULL</c>, indicating
	/// that the calling application does not require a copy of the new or existing certificate. When a copy is made, its context must
	/// be freed by using CertFreeCertificateContext.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError. Some possible error
	/// codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_EXISTS</term>
	/// <term>
	/// This code is returned if CERT_STORE_ADD_NEW is set and the certificate already exists in the store, or if CERT_STORE_ADD_NEWER
	/// is set and there is a certificate in the store with a NotBefore date greater than or equal to the NotBefore date on the
	/// certificate to be added.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// A disposition value that is not valid was specified in the dwAddDisposition parameter, or a certificate encoding type that is
	/// not valid was specified. Currently, only the X509_ASN_ENCODING type is supported.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError returns an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddencodedcertificatetostore BOOL
	// CertAddEncodedCertificateToStore( HCERTSTORE hCertStore, DWORD dwCertEncodingType, const BYTE *pbCertEncoded, DWORD
	// cbCertEncoded, DWORD dwAddDisposition, PCCERT_CONTEXT *ppCertContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "7c092bf5-f8b2-47d0-94ee-c8e0f4bca62d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertAddEncodedCertificateToStore([In, AddAsMember] HCERTSTORE hCertStore, CertEncodingType dwCertEncodingType, [In, SizeDef(nameof(cbCertEncoded))] IntPtr pbCertEncoded,
		uint cbCertEncoded, CertStoreAdd dwAddDisposition, [Optional, Ignore] IntPtr ppCertContext);

	/// <summary>
	/// The <c>CertAddRefServerOcspResponse</c> function increments the reference count for an <c>HCERT_SERVER_OCSP_RESPONSE</c> handle.
	/// </summary>
	/// <param name="hServerOcspResponse">A handle to an <c>HCERT_SERVER_OCSP_RESPONSE</c> returned by CertOpenServerOcspResponse.</param>
	/// <returns>This function has no return value.</returns>
	/// <remarks>Each CertOpenServerOcspResponse and <c>CertAddRefServerOcspResponse</c> requires a corresponding CertCloseServerOcspResponse.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddrefserverocspresponse void
	// CertAddRefServerOcspResponse( HCERT_SERVER_OCSP_RESPONSE hServerOcspResponse );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "6ccc0e85-1fa0-480c-a5b4-b21ba811e5d0")]
	public static extern void CertAddRefServerOcspResponse([In] HCERT_SERVER_OCSP_RESPONSE hServerOcspResponse);

	/// <summary>
	/// The <c>CertAddRefServerOcspResponseContext</c> function increments the reference count for a CERT_SERVER_OCSP_RESPONSE_CONTEXT structure.
	/// </summary>
	/// <param name="pServerOcspResponseContext">A pointer to a CERT_SERVER_OCSP_RESPONSE_CONTEXT returned by CertGetServerOcspResponseContext.</param>
	/// <returns>The function has no return value.</returns>
	/// <remarks>
	/// Each call to CertGetServerOcspResponseContext and <c>CertAddRefServerOcspResponseContext</c> requires a corresponding call to CertFreeServerOcspResponseContext.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddrefserverocspresponsecontext void
	// CertAddRefServerOcspResponseContext( PCCERT_SERVER_OCSP_RESPONSE_CONTEXT pServerOcspResponseContext );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b7cdce9b-25fe-4fb9-b266-61989793699b")]
	public static extern void CertAddRefServerOcspResponseContext([In] PCCERT_SERVER_OCSP_RESPONSE_CONTEXT pServerOcspResponseContext);

	/// <summary>
	/// The <c>CertCloseServerOcspResponse</c> function closes an online certificate status protocol (OCSP) server response handle.
	/// </summary>
	/// <param name="hServerOcspResponse">The handle to close for an OCSP server response.</param>
	/// <param name="dwFlags">This parameter is not used and must be zero.</param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// The <c>CertCloseServerOcspResponse</c> function closes a handle returned by either the CertOpenServerOcspResponse or
	/// CertAddRefServerOcspResponse function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcloseserverocspresponse void
	// CertCloseServerOcspResponse( HCERT_SERVER_OCSP_RESPONSE hServerOcspResponse, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "6247e8ca-ba12-432f-9bf8-a6c644f253e9")]
	public static extern void CertCloseServerOcspResponse([In] HCERT_SERVER_OCSP_RESPONSE hServerOcspResponse, uint dwFlags = 0);

	/// <summary>
	/// The <c>CertCreateCertificateContext</c> function creates a certificate context from an encoded certificate. The created context
	/// is not persisted to a certificate store. The function makes a copy of the encoded certificate within the created context.
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the type of encoding used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbCertEncoded">A pointer to a buffer that contains the encoded certificate from which the context is to be created.</param>
	/// <param name="cbCertEncoded">The size, in bytes, of the pbCertEncoded buffer.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the function returns a pointer to a read-only CERT_CONTEXT. When you have finished using the
	/// certificate context, free it by calling the CertFreeCertificateContext function.
	/// </para>
	/// <para>
	/// If the function is unable to decode and create the certificate context, it returns <c>NULL</c>. For extended error information,
	/// call GetLastError. Some possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>A certificate encoding type that is not valid was specified. Currently, only the X509_ASN_ENCODING type is supported.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The CERT_CONTEXT must be freed by calling CertFreeCertificateContext. CertDuplicateCertificateContext can be called to make a
	/// duplicate. CertSetCertificateContextProperty and CertGetCertificateContextProperty can be called to store and read properties
	/// for the certificate.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows creating a certificate context from an encoded certificate. The created context is not put in a
	/// certificate store. For another example that uses this function, see Example C Program: Certificate Store Operations.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcreatecertificatecontext PCCERT_CONTEXT
	// CertCreateCertificateContext( DWORD dwCertEncodingType, const BYTE *pbCertEncoded, DWORD cbCertEncoded );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "a32714c4-ee88-48a8-a40a-bbbfec0613ac")]
	[return: AddAsCtor]
	public static extern SafePCCERT_CONTEXT CertCreateCertificateContext(CertEncodingType dwCertEncodingType, [In, SizeDef(nameof(cbCertEncoded))] IntPtr pbCertEncoded, uint cbCertEncoded);

	/// <summary>
	/// The <c>CertCreateSelfSignCertificate</c> function builds a self-signed certificate and returns a pointer to a CERT_CONTEXT
	/// structure that represents the certificate.
	/// </summary>
	/// <param name="hCryptProvOrNCryptKey">
	/// <para>
	/// A handle of a cryptographic provider used to sign the certificate created. If <c>NULL</c>, information from the pKeyProvInfo
	/// parameter is used to acquire the needed handle. If pKeyProvInfo is also <c>NULL</c>, the default provider type, PROV_RSA_FULL
	/// provider type, the default key specification, AT_SIGNATURE, and a newly created key container with a unique container name are used.
	/// </para>
	/// <para>
	/// This handle must be an HCRYPTPROV handle that has been created by using the CryptAcquireContext function or an
	/// <c>NCRYPT_KEY_HANDLE</c> handle that has been created by using the NCryptOpenKey function. New applications should always pass
	/// in the <c>NCRYPT_KEY_HANDLE</c> handle of a CNG cryptographic service provider (CSP).
	/// </para>
	/// </param>
	/// <param name="pSubjectIssuerBlob">
	/// A pointer to a BLOB that contains the distinguished name (DN) for the certificate subject. This parameter cannot be <c>NULL</c>.
	/// Minimally, a pointer to an empty DN must be provided. This BLOB is normally created by using the CertStrToName function. It can
	/// also be created by using the CryptEncodeObject function and specifying either the X509_NAME or X509_UNICODE_NAME StructType.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that override the default behavior of this function. This can be zero or a combination of one or more of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_CREATE_SELFSIGN_NO_KEY_INFO 2</term>
	/// <term>
	/// By default, the returned PCCERT_CONTEXT references the private keys by setting the CERT_KEY_PROV_INFO_PROP_ID. If you do not
	/// want the returned PCCERT_CONTEXT to reference private keys by setting the CERT_KEY_PROV_INFO_PROP_ID, specify CERT_CREATE_SELFSIGN_NO_KEY_INFO.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CREATE_SELFSIGN_NO_SIGN 1</term>
	/// <term>
	/// By default, the certificate being created is signed. If the certificate being created is only a dummy placeholder, the
	/// certificate might not need to be signed. Signing of the certificate is skipped if CERT_CREATE_SELFSIGN_NO_SIGN is specified.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pKeyProvInfo">
	/// <para>
	/// A pointer to a CRYPT_KEY_PROV_INFO structure. Before a certificate is created, the CSP is queried for the key provider, key
	/// provider type, and the key container name. If the CSP queried does not support these queries, the function fails. If the default
	/// provider does not support these queries, a pKeyProvInfo value must be specified. The RSA BASE does support these queries.
	/// </para>
	/// <para>
	/// If the pKeyProvInfo parameter is not <c>NULL</c>, the corresponding values are set in the <c>CERT_KEY_PROV_INFO_PROP_ID</c>
	/// value of the generated certificate. You must ensure that all parameters of the supplied structure are correctly specified.
	/// </para>
	/// </param>
	/// <param name="pSignatureAlgorithm">
	/// A pointer to a CRYPT_ALGORITHM_IDENTIFIER structure. If <c>NULL</c>, the default algorithm, SHA1RSA, is used.
	/// </param>
	/// <param name="pStartTime">A pointer to a SYSTEMTIME structure. If <c>NULL</c>, the system current time is used by default.</param>
	/// <param name="pEndTime">
	/// A pointer to a SYSTEMTIME structure. If <c>NULL</c>, the pStartTime value plus one year will be used by default.
	/// </param>
	/// <param name="pExtensions">
	/// A pointer to a CERT_EXTENSIONS array of CERT_EXTENSION structures. By default, the array is empty. An alternate subject name, if
	/// desired, can be specified as one of these extensions.
	/// </param>
	/// <returns>
	/// If the function succeeds, a PCCERT_CONTEXT variable that points to the created certificate is returned. If the function fails,
	/// it returns <c>NULL</c>. For extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// As the pEndTime must be a valid date, and is automatically generated if it is not supplied by the user, unexpected failures may
	/// easily be caused when this API is called on a leap day without accompanying app logic to compensate. For more information,
	/// please see leap year readiness.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcreateselfsigncertificate PCCERT_CONTEXT
	// CertCreateSelfSignCertificate( HCRYPTPROV_OR_NCRYPT_KEY_HANDLE hCryptProvOrNCryptKey, PCERT_NAME_BLOB pSubjectIssuerBlob, DWORD
	// dwFlags, PCRYPT_KEY_PROV_INFO pKeyProvInfo, PCRYPT_ALGORITHM_IDENTIFIER pSignatureAlgorithm, PSYSTEMTIME pStartTime, PSYSTEMTIME
	// pEndTime, PCERT_EXTENSIONS pExtensions );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "89028c4e-f896-4c50-9fa2-bcb4e1784244")]
	[return: AddAsCtor]
	public static extern SafePCCERT_CONTEXT CertCreateSelfSignCertificate(IntPtr hCryptProvOrNCryptKey, in CRYPTOAPI_BLOB pSubjectIssuerBlob,
		CertCreateSelfSignFlags dwFlags, [In, Optional] ManagedStructPointer<CRYPT_KEY_PROV_INFO> pKeyProvInfo,
		[In, Optional] StructPointer<CRYPT_ALGORITHM_IDENTIFIER> pSignatureAlgorithm, [In, Optional] PSYSTEMTIME? pStartTime,
		[In, Optional] PSYSTEMTIME? pEndTime, [In, Optional] StructPointer<CERT_EXTENSIONS> pExtensions);

	/// <summary>
	/// The <c>CertCreateSelfSignCertificate</c> function builds a self-signed certificate and returns a pointer to a CERT_CONTEXT
	/// structure that represents the certificate.
	/// </summary>
	/// <param name="hCryptProvOrNCryptKey">
	/// <para>
	/// A handle of a cryptographic provider used to sign the certificate created. If <c>NULL</c>, information from the pKeyProvInfo
	/// parameter is used to acquire the needed handle. If pKeyProvInfo is also <c>NULL</c>, the default provider type, PROV_RSA_FULL
	/// provider type, the default key specification, AT_SIGNATURE, and a newly created key container with a unique container name are used.
	/// </para>
	/// <para>
	/// This handle must be an HCRYPTPROV handle that has been created by using the CryptAcquireContext function or an
	/// <c>NCRYPT_KEY_HANDLE</c> handle that has been created by using the NCryptOpenKey function. New applications should always pass
	/// in the <c>NCRYPT_KEY_HANDLE</c> handle of a CNG cryptographic service provider (CSP).
	/// </para>
	/// </param>
	/// <param name="pSubjectIssuerBlob">
	/// A pointer to a BLOB that contains the distinguished name (DN) for the certificate subject. This parameter cannot be <c>NULL</c>.
	/// Minimally, a pointer to an empty DN must be provided. This BLOB is normally created by using the CertStrToName function. It can
	/// also be created by using the CryptEncodeObject function and specifying either the X509_NAME or X509_UNICODE_NAME StructType.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that override the default behavior of this function. This can be zero or a combination of one or more of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_CREATE_SELFSIGN_NO_KEY_INFO 2</term>
	/// <term>
	/// By default, the returned PCCERT_CONTEXT references the private keys by setting the CERT_KEY_PROV_INFO_PROP_ID. If you do not
	/// want the returned PCCERT_CONTEXT to reference private keys by setting the CERT_KEY_PROV_INFO_PROP_ID, specify CERT_CREATE_SELFSIGN_NO_KEY_INFO.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CREATE_SELFSIGN_NO_SIGN 1</term>
	/// <term>
	/// By default, the certificate being created is signed. If the certificate being created is only a dummy placeholder, the
	/// certificate might not need to be signed. Signing of the certificate is skipped if CERT_CREATE_SELFSIGN_NO_SIGN is specified.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pKeyProvInfo">
	/// <para>
	/// A pointer to a CRYPT_KEY_PROV_INFO structure. Before a certificate is created, the CSP is queried for the key provider, key
	/// provider type, and the key container name. If the CSP queried does not support these queries, the function fails. If the default
	/// provider does not support these queries, a pKeyProvInfo value must be specified. The RSA BASE does support these queries.
	/// </para>
	/// <para>
	/// If the pKeyProvInfo parameter is not <c>NULL</c>, the corresponding values are set in the <c>CERT_KEY_PROV_INFO_PROP_ID</c>
	/// value of the generated certificate. You must ensure that all parameters of the supplied structure are correctly specified.
	/// </para>
	/// </param>
	/// <param name="pSignatureAlgorithm">
	/// A pointer to a CRYPT_ALGORITHM_IDENTIFIER structure. If <c>NULL</c>, the default algorithm, SHA1RSA, is used.
	/// </param>
	/// <param name="pStartTime">A pointer to a SYSTEMTIME structure. If <c>NULL</c>, the system current time is used by default.</param>
	/// <param name="pEndTime">
	/// A pointer to a SYSTEMTIME structure. If <c>NULL</c>, the pStartTime value plus one year will be used by default.
	/// </param>
	/// <param name="pExtensions">
	/// A pointer to a CERT_EXTENSIONS array of CERT_EXTENSION structures. By default, the array is empty. An alternate subject name, if
	/// desired, can be specified as one of these extensions.
	/// </param>
	/// <returns>
	/// If the function succeeds, a PCCERT_CONTEXT variable that points to the created certificate is returned. If the function fails,
	/// it returns <c>NULL</c>. For extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// As the pEndTime must be a valid date, and is automatically generated if it is not supplied by the user, unexpected failures may
	/// easily be caused when this API is called on a leap day without accompanying app logic to compensate. For more information,
	/// please see leap year readiness.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcreateselfsigncertificate PCCERT_CONTEXT
	// CertCreateSelfSignCertificate( HCRYPTPROV_OR_NCRYPT_KEY_HANDLE hCryptProvOrNCryptKey, PCERT_NAME_BLOB pSubjectIssuerBlob, DWORD
	// dwFlags, PCRYPT_KEY_PROV_INFO pKeyProvInfo, PCRYPT_ALGORITHM_IDENTIFIER pSignatureAlgorithm, PSYSTEMTIME pStartTime, PSYSTEMTIME
	// pEndTime, PCERT_EXTENSIONS pExtensions );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "89028c4e-f896-4c50-9fa2-bcb4e1784244")]
	public static extern SafePCCERT_CONTEXT CertCreateSelfSignCertificate(IntPtr hCryptProvOrNCryptKey, in CRYPTOAPI_BLOB pSubjectIssuerBlob,
		CertCreateSelfSignFlags dwFlags, in CRYPT_KEY_PROV_INFO pKeyProvInfo, in CRYPT_ALGORITHM_IDENTIFIER pSignatureAlgorithm,
		[In, Optional] PSYSTEMTIME? pStartTime, [In, Optional] PSYSTEMTIME? pEndTime, IntPtr pExtensions);

	/// <summary>
	/// The <c>CertCreateSelfSignCertificate</c> function builds a self-signed certificate and returns a pointer to a CERT_CONTEXT
	/// structure that represents the certificate.
	/// </summary>
	/// <param name="hCryptProvOrNCryptKey">
	/// <para>
	/// A handle of a cryptographic provider used to sign the certificate created. If <c>NULL</c>, information from the pKeyProvInfo
	/// parameter is used to acquire the needed handle. If pKeyProvInfo is also <c>NULL</c>, the default provider type, PROV_RSA_FULL
	/// provider type, the default key specification, AT_SIGNATURE, and a newly created key container with a unique container name are used.
	/// </para>
	/// <para>
	/// This handle must be an HCRYPTPROV handle that has been created by using the CryptAcquireContext function or an
	/// <c>NCRYPT_KEY_HANDLE</c> handle that has been created by using the NCryptOpenKey function. New applications should always pass
	/// in the <c>NCRYPT_KEY_HANDLE</c> handle of a CNG cryptographic service provider (CSP).
	/// </para>
	/// </param>
	/// <param name="pSubjectIssuerBlob">
	/// A pointer to a BLOB that contains the distinguished name (DN) for the certificate subject. This parameter cannot be <c>NULL</c>.
	/// Minimally, a pointer to an empty DN must be provided. This BLOB is normally created by using the CertStrToName function. It can
	/// also be created by using the CryptEncodeObject function and specifying either the X509_NAME or X509_UNICODE_NAME StructType.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that override the default behavior of this function. This can be zero or a combination of one or more of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_CREATE_SELFSIGN_NO_KEY_INFO 2</term>
	/// <term>
	/// By default, the returned PCCERT_CONTEXT references the private keys by setting the CERT_KEY_PROV_INFO_PROP_ID. If you do not
	/// want the returned PCCERT_CONTEXT to reference private keys by setting the CERT_KEY_PROV_INFO_PROP_ID, specify CERT_CREATE_SELFSIGN_NO_KEY_INFO.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CREATE_SELFSIGN_NO_SIGN 1</term>
	/// <term>
	/// By default, the certificate being created is signed. If the certificate being created is only a dummy placeholder, the
	/// certificate might not need to be signed. Signing of the certificate is skipped if CERT_CREATE_SELFSIGN_NO_SIGN is specified.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pKeyProvInfo">
	/// <para>
	/// A pointer to a CRYPT_KEY_PROV_INFO structure. Before a certificate is created, the CSP is queried for the key provider, key
	/// provider type, and the key container name. If the CSP queried does not support these queries, the function fails. If the default
	/// provider does not support these queries, a pKeyProvInfo value must be specified. The RSA BASE does support these queries.
	/// </para>
	/// <para>
	/// If the pKeyProvInfo parameter is not <c>NULL</c>, the corresponding values are set in the <c>CERT_KEY_PROV_INFO_PROP_ID</c>
	/// value of the generated certificate. You must ensure that all parameters of the supplied structure are correctly specified.
	/// </para>
	/// </param>
	/// <param name="pSignatureAlgorithm">
	/// A pointer to a CRYPT_ALGORITHM_IDENTIFIER structure. If <c>NULL</c>, the default algorithm, SHA1RSA, is used.
	/// </param>
	/// <param name="pStartTime">A pointer to a SYSTEMTIME structure. If <c>NULL</c>, the system current time is used by default.</param>
	/// <param name="pEndTime">
	/// A pointer to a SYSTEMTIME structure. If <c>NULL</c>, the pStartTime value plus one year will be used by default.
	/// </param>
	/// <param name="pExtensions">
	/// A pointer to a CERT_EXTENSIONS array of CERT_EXTENSION structures. By default, the array is empty. An alternate subject name, if
	/// desired, can be specified as one of these extensions.
	/// </param>
	/// <returns>
	/// If the function succeeds, a PCCERT_CONTEXT variable that points to the created certificate is returned. If the function fails,
	/// it returns <c>NULL</c>. For extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// As the pEndTime must be a valid date, and is automatically generated if it is not supplied by the user, unexpected failures may
	/// easily be caused when this API is called on a leap day without accompanying app logic to compensate. For more information,
	/// please see leap year readiness.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcreateselfsigncertificate PCCERT_CONTEXT
	// CertCreateSelfSignCertificate( HCRYPTPROV_OR_NCRYPT_KEY_HANDLE hCryptProvOrNCryptKey, PCERT_NAME_BLOB pSubjectIssuerBlob, DWORD
	// dwFlags, PCRYPT_KEY_PROV_INFO pKeyProvInfo, PCRYPT_ALGORITHM_IDENTIFIER pSignatureAlgorithm, PSYSTEMTIME pStartTime, PSYSTEMTIME
	// pEndTime, PCERT_EXTENSIONS pExtensions );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "89028c4e-f896-4c50-9fa2-bcb4e1784244")]
	public static extern SafePCCERT_CONTEXT CertCreateSelfSignCertificate(IntPtr hCryptProvOrNCryptKey, in CRYPTOAPI_BLOB pSubjectIssuerBlob,
		CertCreateSelfSignFlags dwFlags, in CRYPT_KEY_PROV_INFO pKeyProvInfo, in CRYPT_ALGORITHM_IDENTIFIER pSignatureAlgorithm, [In, Optional] PSYSTEMTIME? pStartTime,
		[In, Optional] PSYSTEMTIME? pEndTime, in CERT_EXTENSIONS pExtensions);

	/// <summary>
	/// The <c>CertDeleteCertificateFromStore</c> function deletes the specified certificate context from the certificate store.
	/// </summary>
	/// <param name="pCertContext">A pointer to the CERT_CONTEXT structure to be deleted.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError. One possible error
	/// code is the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>Indicates the store was opened as read-only and a delete operation is not allowed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// After a certificate is deleted from a store, all subsequent attempts to get or find that certificate in that store will fail.
	/// However, memory allocated for the certificate is not freed until all duplicated contexts have also been freed.
	/// </para>
	/// <para>
	/// The <c>CertDeleteCertificateFromStore</c> function always frees pCertContext by calling the CertFreeCertificateContext function,
	/// even if an error is encountered. Freeing the context reduces the context's reference count by one. If the reference count
	/// reaches zero, memory allocated for the certificate is freed.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Deleting Certificates from a Certificate Store.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certdeletecertificatefromstore BOOL
	// CertDeleteCertificateFromStore( PCCERT_CONTEXT pCertContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "4390c8da-9c4d-47a4-9af4-d179829f77f3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertDeleteCertificateFromStore(PCCERT_CONTEXT pCertContext);

	/// <summary>
	/// The <c>CertDuplicateCertificateContext</c> function duplicates a certificate context by incrementing its reference count.
	/// </summary>
	/// <param name="pCertContext">A pointer to the CERT_CONTEXT structure for which the reference count is incremented.</param>
	/// <returns>
	/// Currently, a copy is not made of the context, and the returned pointer to a context has the same value as the pointer to a
	/// context that was input. If the pointer passed into this function is <c>NULL</c>, <c>NULL</c> is returned. When you have finished
	/// using the duplicate context, decrease its reference count by calling the CertFreeCertificateContext function.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certduplicatecertificatecontext PCCERT_CONTEXT
	// CertDuplicateCertificateContext( PCCERT_CONTEXT pCertContext );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "589edd25-c8d0-4f93-83b2-9df2ed2e2812")]
	public static extern SafePCCERT_CONTEXT CertDuplicateCertificateContext(PCCERT_CONTEXT pCertContext);

	/// <summary>
	/// The <c>CertEnumCertificatesInStore</c> function retrieves the first or next certificate in a certificate store. Used in a loop,
	/// this function can retrieve in sequence all certificates in a certificate store.
	/// </summary>
	/// <param name="hCertStore">A handle of a certificate store.</param>
	/// <param name="pPrevCertContext">
	/// <para>A pointer to the CERT_CONTEXT of the previous certificate context found.</para>
	/// <para>
	/// This parameter must be <c>NULL</c> to begin the enumeration and get the first certificate in the store. Successive certificates
	/// are enumerated by setting pPrevCertContext to the pointer returned by a previous call to the function. This function frees the
	/// CERT_CONTEXT referenced by non- <c>NULL</c> values of this parameter.
	/// </para>
	/// <para>
	/// For logical stores, including collection stores, a duplicate of the pCertContext returned by this function cannot be used to
	/// begin a new subsequence of enumerations because the duplicated certificate loses the initial enumeration state. The enumeration
	/// skips any certificate previously deleted by CertDeleteCertificateFromStore.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the function returns a pointer to the next CERT_CONTEXT in the store. If no more certificates exist in
	/// the store, the function returns <c>NULL</c>.
	/// </para>
	/// <para>For extended error information, call GetLastError. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The handle in the hCertStore parameter is not the same as that in the certificate context pointed to by pPrevCertContext.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NOT_FOUND</term>
	/// <term>No certificates were found. This happens if the store is empty or if the function reached the end of the store's list.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MORE_FILES</term>
	/// <term>
	/// Applies to external stores. No certificates were found. This happens if the store is empty or if the function reached the end of
	/// the store's list.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The returned pointer is freed when passed as the pPrevCertContext parameter on a subsequent call. Otherwise, the pointer must be
	/// freed by calling CertFreeCertificateContext. A non- <c>NULL</c> pPrevCertContext passed to <c>CertEnumCertificatesInStore</c> is
	/// always freed even for an error.
	/// </para>
	/// <para>A duplicate of the currently enumerated certificate can be made by calling CertDuplicateCertificateContext.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example lists the certificate contexts in the certificate store. For another example that uses this function, see
	/// Example C Program: Deleting Certificates from a Certificate Store.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certenumcertificatesinstore PCCERT_CONTEXT
	// CertEnumCertificatesInStore( HCERTSTORE hCertStore, PCCERT_CONTEXT pPrevCertContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "c5ab5b4c-dc0c-416b-aa9e-b939398cfa6d")]
	public static extern PCCERT_CONTEXT CertEnumCertificatesInStore([In, AddAsMember] HCERTSTORE hCertStore, PCCERT_CONTEXT pPrevCertContext);

	/// <summary>
	/// The <c>CertFindCertificateInStore</c> function finds the first or next certificate context in a certificate store that matches a
	/// search criteria established by the dwFindType and its associated pvFindPara. This function can be used in a loop to find all of
	/// the certificates in a certificate store that match the specified find criteria.
	/// </summary>
	/// <param name="hCertStore">A handle of the certificate store to be searched.</param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the type of encoding used. Both the certificate and message encoding types must be specified by combining them with a
	/// bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFindFlags">
	/// Used with some dwFindType values to modify the search criteria. For most dwFindType values, dwFindFlags is not used and should
	/// be set to zero. For detailed information, see Remarks.
	/// </param>
	/// <param name="dwFindType">
	/// <para>
	/// Specifies the type of search being made. The search type determines the data type, contents, and the use of pvFindPara. This
	/// parameter can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_FIND_ANY</term>
	/// <term>Data type of pvFindPara: NULL, not used. No search criteria used. Returns the next certificate in the store.</term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_CERT_ID</term>
	/// <term>Data type of pvFindPara: CERT_ID structure. Find the certificate identified by the specified CERT_ID.</term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_CTL_USAGE</term>
	/// <term>
	/// Data type of pvFindPara: CTL_USAGE structure. Searches for a certificate that has a szOID_ENHANCED_KEY_USAGE extension or a
	/// CERT_CTL_PROP_ID that matches the pszUsageIdentifier member of the CTL_USAGE structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_ENHKEY_USAGE</term>
	/// <term>
	/// Data type of pvFindPara: CERT_ENHKEY_USAGE structure. Searches for a certificate in the store that has either an enhanced key
	/// usage extension or an enhanced key usage property and a usage identifier that matches the cUsageIdentifier member in the
	/// CERT_ENHKEY_USAGE structure. A certificate has an enhanced key usage extension if it has a CERT_EXTENSION structure with the
	/// pszObjId member set to szOID_ENHANCED_KEY_USAGE. A certificate has an enhanced key usage property if its
	/// CERT_ENHKEY_USAGE_PROP_ID identifier is set. If CERT_FIND_OPTIONAL_ENHKEY_USAGE_FLAG is set in dwFindFlags, certificates without
	/// the key usage extension or property are also matches. Setting this flag takes precedence over passing NULL in pvFindPara. If
	/// CERT_FIND_EXT_ONLY_ENHKEY_USAGE_FLAG is set, a match is done only on the key usage extension. For information about flag
	/// modifications to search criteria, see Remarks.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_EXISTING</term>
	/// <term>
	/// Data type of pvFindPara: CERT_CONTEXT structure. Searches for a certificate that is an exact match of the specified certificate context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_HASH</term>
	/// <term>
	/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with a SHA1 hash that matches the hash in the
	/// CRYPT_HASH_BLOB structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_HAS_PRIVATE_KEY</term>
	/// <term>
	/// Data type of pvFindPara: NULL, not used. Searches for a certificate that has a private key. The key can be ephemeral or saved on
	/// disk. The key can be a legacy Cryptography API (CAPI) key or a CNG key. Windows 8 and Windows Server 2012: Support for this flag begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_ISSUER_ATTR</term>
	/// <term>
	/// Data type of pvFindPara: CERT_RDN structure. Searches for a certificate with specified issuer attributes that match attributes
	/// in the CERT_RDN structure. If these values are set, the function compares attributes of the issuer in a certificate with
	/// elements of the CERT_RDN_ATTR array in this CERT_RDN structure. Comparisons iterate through the CERT_RDN_ATTR attributes looking
	/// for a match with the certificate's issuer attributes. If the pszObjId member of CERT_RDN_ATTR is NULL, the attribute object
	/// identifier is ignored. If the dwValueType member of CERT_RDN_ATTR is CERT_RDN_ANY_TYPE, the value type is ignored. If the pbData
	/// member of CERT_RDN_VALUE_BLOB is NULL, any value is a match. Currently only an exact, case-sensitive match is supported. For
	/// information about Unicode options, see Remarks. When these values are set, the search is restricted to certificates whose
	/// encoding type matches dwCertEncodingType.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_ISSUER_NAME</term>
	/// <term>
	/// Data type of pvFindPara: CERT_NAME_BLOB structure. Search for a certificate with an exact match of the entire issuer name with
	/// the name in CERT_NAME_BLOB The search is restricted to certificates that match the dwCertEncodingType.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_ISSUER_OF</term>
	/// <term>
	/// Data type of pvFindPara: CERT_CONTEXT structure. Searches for a certificate with an subject that matches the issuer in
	/// CERT_CONTEXT. Instead of using CertFindCertificateInStore with this value, use the CertGetCertificateChain function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_ISSUER_STR</term>
	/// <term>
	/// Data type of pvFindPara: Null-terminated Unicode string. Searches for a certificate that contains the specified issuer name
	/// string. The certificate's issuer member is converted to a name string of the appropriate type using the appropriate form of
	/// CertNameToStr formatted as CERT_SIMPLE_NAME_STR. Then a case-insensitive substring-within-a-string match is performed. When this
	/// value is set, the search is restricted to certificates whose encoding type matches dwCertEncodingType. If the substring match
	/// fails and the subject contains an email RDN with Punycode encoded string, CERT_NAME_STR_ENABLE_PUNYCODE_FLAG is used to convert
	/// the subject to a Unicode string and the substring match is performed again.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_KEY_IDENTIFIER</term>
	/// <term>
	/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with a CERT_KEY_IDENTIFIER_PROP_ID property that
	/// matches the key identifier in CRYPT_HASH_BLOB.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_KEY_SPEC</term>
	/// <term>
	/// Data type of pvFindPara: DWORD variable that contains a key specification. Searches for a certificate that has a
	/// CERT_KEY_SPEC_PROP_ID property that matches the key specification in pvFindPara.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_MD5_HASH</term>
	/// <term>
	/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with an MD5 hash that matches the hash in CRYPT_HASH_BLOB.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_PROPERTY</term>
	/// <term>
	/// Data type of pvFindPara: DWORD variable that contains a property identifier. Searches for a certificate with a property that
	/// matches the property identifier specified by the DWORD value in pvFindPara.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_PUBLIC_KEY</term>
	/// <term>
	/// Data type of pvFindPara: CERT_PUBLIC_KEY_INFO structure. Searches for a certificate with a public key that matches the public
	/// key in the CERT_PUBLIC_KEY_INFO structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_SHA1_HASH</term>
	/// <term>
	/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with a SHA1 hash that matches the hash in the
	/// CRYPT_HASH_BLOB structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_SIGNATURE_HASH</term>
	/// <term>
	/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with a signature hash that matches the signature
	/// hash in the CRYPT_HASH_BLOB structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_SUBJECT_ATTR</term>
	/// <term>
	/// Data type of pvFindPara: CERT_RDN structure. Searches for a certificate with specified subject attributes that match attributes
	/// in the CERT_RDN structure. If RDN values are set, the function compares attributes of the subject in a certificate with elements
	/// of the CERT_RDN_ATTR array in this CERT_RDN structure. Comparisons iterate through the CERT_RDN_ATTR attributes looking for a
	/// match with the certificate's subject's attributes. If the pszObjId member of CERT_RDN_ATTR is NULL, the attribute object
	/// identifier is ignored. If the dwValueType member of CERT_RDN_ATTR is CERT_RDN_ANY_TYPE, the value type is ignored. If the pbData
	/// member of CERT_RDN_VALUE_BLOB is NULL, any value is a match. Currently only an exact, case-sensitive match is supported. For
	/// information about Unicode options, see Remarks. When these values are set, the search is restricted to certificates whose
	/// encoding type matches dwCertEncodingType.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_SUBJECT_CERT</term>
	/// <term>
	/// Data type of pvFindPara: CERT_INFO structure. Searches for a certificate with both an issuer and a serial number that match the
	/// issuer and serial number in the CERT_INFO structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_SUBJECT_NAME</term>
	/// <term>
	/// Data type of pvFindPara: CERT_NAME_BLOB structure. Searches for a certificate with an exact match of the entire subject name
	/// with the name in the CERT_NAME_BLOB structure. The search is restricted to certificates that match the value of dwCertEncodingType.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_SUBJECT_STR</term>
	/// <term>
	/// Data type of pvFindPara: Null-terminated Unicode string. Searches for a certificate that contains the specified subject name
	/// string. The certificate's subject member is converted to a name string of the appropriate type using the appropriate form of
	/// CertNameToStr formatted as CERT_SIMPLE_NAME_STR. Then a case-insensitive substring-within-a-string match is performed. When this
	/// value is set, the search is restricted to certificates whose encoding type matches dwCertEncodingType.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_CROSS_CERT_DIST_POINTS</term>
	/// <term>
	/// Data type of pvFindPara: Not used. Find a certificate that has either a cross certificate distribution point extension or property.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_PUBKEY_MD5_HASH</term>
	/// <term>
	/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Find a certificate whose MD5-hashed public key matches the specified hash.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> There are alternate forms of the value of dwFindType that pass a string in pvFindPara. One form uses a Unicode
	/// string, and the other an ASCII string. Values that end in "_W" or without a suffix use Unicode. Values that end with "_A" use
	/// ASCII strings.
	/// </para>
	/// </param>
	/// <param name="pvFindPara">Points to a data item or structure used with dwFindType.</param>
	/// <param name="pPrevCertContext">
	/// A pointer to the last CERT_CONTEXT structure returned by this function. This parameter must be <c>NULL</c> on the first call of
	/// the function. To find successive certificates meeting the search criteria, set pPrevCertContext to the pointer returned by the
	/// previous call to the function. This function frees the <c>CERT_CONTEXT</c> referenced by non- <c>NULL</c> values of this parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns a pointer to a read-only CERT_CONTEXT structure.</para>
	/// <para>If the function fails and a certificate that matches the search criteria is not found, the return value is <c>NULL</c>.</para>
	/// <para>
	/// A non- <c>NULL</c> CERT_CONTEXT that <c>CertFindCertificateInStore</c> returns must be freed by CertFreeCertificateContext or by
	/// being passed as the pPrevCertContext parameter on a subsequent call to <c>CertFindCertificateInStore</c>.
	/// </para>
	/// <para>For extended error information, call GetLastError. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NOT_FOUND</term>
	/// <term>
	/// No certificate was found matching the search criteria. This can happen if the store is empty or the end of the store's list is reached.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The handle in the hCertStore parameter is not the same as that in the certificate context pointed to by the pPrevCertContext
	/// parameter, or a value that is not valid was specified in the dwFindType parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The dwFindFlags parameter is used to modify the criteria of some search types.</para>
	/// <para>
	/// The CERT_UNICODE_IS_RDN_ATTRS_FLAG dwFindFlags value is used only with the CERT_FIND_SUBJECT_ATTR and CERT_FIND_ISSUER_ATTR
	/// values for dwFindType. CERT_UNICODE_IS_RDN_ATTRS_FLAG must be set if the CERT_RDN_ATTR structure pointed to by pvFindPara was
	/// initialized with Unicode strings. Before any comparison is made, the string to be matched is converted by using
	/// X509_UNICODE_NAME to provide for Unicode comparisons.
	/// </para>
	/// <para>The following dwFindFlags values are used only with the CERT_FIND_ENKEY_USAGE value for dwFindType:</para>
	/// <para>
	/// CertDuplicateCertificateContext can be called to make a duplicate of the returned context. The returned context can be added to
	/// a different certificate store by using CertAddCertificateContextToStore, or a link to that certificate context can be added to a
	/// store that is not a collection store by using CertAddCertificateLinkToStore.
	/// </para>
	/// <para>
	/// The returned pointer is freed when passed as the pPrevCertContext parameter on a subsequent call to the function. Otherwise, the
	/// pointer must be explicitly freed by calling CertFreeCertificateContext. A pPrevCertContext that is not <c>NULL</c> is always
	/// freed by <c>CertFindCertificateInStore</c> using a call to <c>CertFreeCertificateContext</c>, even if there is an error in the function.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows finding a certificate context in the certificate store meeting a search criterion. For a complete
	/// example that includes the context for this example, see Example C Program: Certificate Store Operations.
	/// </para>
	/// <para>For another example that uses this function, see Example C Program: Collection and Sibling Certificate Store Operations.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfindcertificateinstore PCCERT_CONTEXT
	// CertFindCertificateInStore( HCERTSTORE hCertStore, DWORD dwCertEncodingType, DWORD dwFindFlags, DWORD dwFindType, const void
	// *pvFindPara, PCCERT_CONTEXT pPrevCertContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "20b3fcfb-55df-46ff-80a5-70f31a3d03b2")]
	public static extern SafePCCERT_CONTEXT CertFindCertificateInStore([In, AddAsMember] HCERTSTORE hCertStore, CertEncodingType dwCertEncodingType, CertFindUsageFlags dwFindFlags,
		CertFindType dwFindType, [In] IntPtr pvFindPara, PCCERT_CONTEXT pPrevCertContext);

	/// <summary>
	/// The <c>CertFindCertificateInStore</c> function finds the first or next certificate context in a certificate store that matches a
	/// search criteria established by the dwFindType and its associated pvFindPara. This function can be used in a loop to find all of
	/// the certificates in a certificate store that match the specified find criteria.
	/// </summary>
	/// <param name="hCertStore">A handle of the certificate store to be searched.</param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the type of encoding used. Both the certificate and message encoding types must be specified by combining them with a
	/// bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFindFlags">
	/// Used with some dwFindType values to modify the search criteria. For most dwFindType values, dwFindFlags is not used and should
	/// be set to zero. For detailed information, see Remarks.
	/// </param>
	/// <param name="dwFindType">
	/// <para>
	/// Specifies the type of search being made. The search type determines the data type, contents, and the use of pvFindPara. This
	/// parameter can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_FIND_ANY</term>
	/// <term>Data type of pvFindPara: NULL, not used. No search criteria used. Returns the next certificate in the store.</term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_CERT_ID</term>
	/// <term>Data type of pvFindPara: CERT_ID structure. Find the certificate identified by the specified CERT_ID.</term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_CTL_USAGE</term>
	/// <term>
	/// Data type of pvFindPara: CTL_USAGE structure. Searches for a certificate that has a szOID_ENHANCED_KEY_USAGE extension or a
	/// CERT_CTL_PROP_ID that matches the pszUsageIdentifier member of the CTL_USAGE structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_ENHKEY_USAGE</term>
	/// <term>
	/// Data type of pvFindPara: CERT_ENHKEY_USAGE structure. Searches for a certificate in the store that has either an enhanced key
	/// usage extension or an enhanced key usage property and a usage identifier that matches the cUsageIdentifier member in the
	/// CERT_ENHKEY_USAGE structure. A certificate has an enhanced key usage extension if it has a CERT_EXTENSION structure with the
	/// pszObjId member set to szOID_ENHANCED_KEY_USAGE. A certificate has an enhanced key usage property if its
	/// CERT_ENHKEY_USAGE_PROP_ID identifier is set. If CERT_FIND_OPTIONAL_ENHKEY_USAGE_FLAG is set in dwFindFlags, certificates without
	/// the key usage extension or property are also matches. Setting this flag takes precedence over passing NULL in pvFindPara. If
	/// CERT_FIND_EXT_ONLY_ENHKEY_USAGE_FLAG is set, a match is done only on the key usage extension. For information about flag
	/// modifications to search criteria, see Remarks.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_EXISTING</term>
	/// <term>
	/// Data type of pvFindPara: CERT_CONTEXT structure. Searches for a certificate that is an exact match of the specified certificate context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_HASH</term>
	/// <term>
	/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with a SHA1 hash that matches the hash in the
	/// CRYPT_HASH_BLOB structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_HAS_PRIVATE_KEY</term>
	/// <term>
	/// Data type of pvFindPara: NULL, not used. Searches for a certificate that has a private key. The key can be ephemeral or saved on
	/// disk. The key can be a legacy Cryptography API (CAPI) key or a CNG key. Windows 8 and Windows Server 2012: Support for this flag begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_ISSUER_ATTR</term>
	/// <term>
	/// Data type of pvFindPara: CERT_RDN structure. Searches for a certificate with specified issuer attributes that match attributes
	/// in the CERT_RDN structure. If these values are set, the function compares attributes of the issuer in a certificate with
	/// elements of the CERT_RDN_ATTR array in this CERT_RDN structure. Comparisons iterate through the CERT_RDN_ATTR attributes looking
	/// for a match with the certificate's issuer attributes. If the pszObjId member of CERT_RDN_ATTR is NULL, the attribute object
	/// identifier is ignored. If the dwValueType member of CERT_RDN_ATTR is CERT_RDN_ANY_TYPE, the value type is ignored. If the pbData
	/// member of CERT_RDN_VALUE_BLOB is NULL, any value is a match. Currently only an exact, case-sensitive match is supported. For
	/// information about Unicode options, see Remarks. When these values are set, the search is restricted to certificates whose
	/// encoding type matches dwCertEncodingType.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_ISSUER_NAME</term>
	/// <term>
	/// Data type of pvFindPara: CERT_NAME_BLOB structure. Search for a certificate with an exact match of the entire issuer name with
	/// the name in CERT_NAME_BLOB The search is restricted to certificates that match the dwCertEncodingType.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_ISSUER_OF</term>
	/// <term>
	/// Data type of pvFindPara: CERT_CONTEXT structure. Searches for a certificate with an subject that matches the issuer in
	/// CERT_CONTEXT. Instead of using CertFindCertificateInStore with this value, use the CertGetCertificateChain function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_ISSUER_STR</term>
	/// <term>
	/// Data type of pvFindPara: Null-terminated Unicode string. Searches for a certificate that contains the specified issuer name
	/// string. The certificate's issuer member is converted to a name string of the appropriate type using the appropriate form of
	/// CertNameToStr formatted as CERT_SIMPLE_NAME_STR. Then a case-insensitive substring-within-a-string match is performed. When this
	/// value is set, the search is restricted to certificates whose encoding type matches dwCertEncodingType. If the substring match
	/// fails and the subject contains an email RDN with Punycode encoded string, CERT_NAME_STR_ENABLE_PUNYCODE_FLAG is used to convert
	/// the subject to a Unicode string and the substring match is performed again.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_KEY_IDENTIFIER</term>
	/// <term>
	/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with a CERT_KEY_IDENTIFIER_PROP_ID property that
	/// matches the key identifier in CRYPT_HASH_BLOB.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_KEY_SPEC</term>
	/// <term>
	/// Data type of pvFindPara: DWORD variable that contains a key specification. Searches for a certificate that has a
	/// CERT_KEY_SPEC_PROP_ID property that matches the key specification in pvFindPara.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_MD5_HASH</term>
	/// <term>
	/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with an MD5 hash that matches the hash in CRYPT_HASH_BLOB.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_PROPERTY</term>
	/// <term>
	/// Data type of pvFindPara: DWORD variable that contains a property identifier. Searches for a certificate with a property that
	/// matches the property identifier specified by the DWORD value in pvFindPara.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_PUBLIC_KEY</term>
	/// <term>
	/// Data type of pvFindPara: CERT_PUBLIC_KEY_INFO structure. Searches for a certificate with a public key that matches the public
	/// key in the CERT_PUBLIC_KEY_INFO structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_SHA1_HASH</term>
	/// <term>
	/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with a SHA1 hash that matches the hash in the
	/// CRYPT_HASH_BLOB structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_SIGNATURE_HASH</term>
	/// <term>
	/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with a signature hash that matches the signature
	/// hash in the CRYPT_HASH_BLOB structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_SUBJECT_ATTR</term>
	/// <term>
	/// Data type of pvFindPara: CERT_RDN structure. Searches for a certificate with specified subject attributes that match attributes
	/// in the CERT_RDN structure. If RDN values are set, the function compares attributes of the subject in a certificate with elements
	/// of the CERT_RDN_ATTR array in this CERT_RDN structure. Comparisons iterate through the CERT_RDN_ATTR attributes looking for a
	/// match with the certificate's subject's attributes. If the pszObjId member of CERT_RDN_ATTR is NULL, the attribute object
	/// identifier is ignored. If the dwValueType member of CERT_RDN_ATTR is CERT_RDN_ANY_TYPE, the value type is ignored. If the pbData
	/// member of CERT_RDN_VALUE_BLOB is NULL, any value is a match. Currently only an exact, case-sensitive match is supported. For
	/// information about Unicode options, see Remarks. When these values are set, the search is restricted to certificates whose
	/// encoding type matches dwCertEncodingType.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_SUBJECT_CERT</term>
	/// <term>
	/// Data type of pvFindPara: CERT_INFO structure. Searches for a certificate with both an issuer and a serial number that match the
	/// issuer and serial number in the CERT_INFO structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_SUBJECT_NAME</term>
	/// <term>
	/// Data type of pvFindPara: CERT_NAME_BLOB structure. Searches for a certificate with an exact match of the entire subject name
	/// with the name in the CERT_NAME_BLOB structure. The search is restricted to certificates that match the value of dwCertEncodingType.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_SUBJECT_STR</term>
	/// <term>
	/// Data type of pvFindPara: Null-terminated Unicode string. Searches for a certificate that contains the specified subject name
	/// string. The certificate's subject member is converted to a name string of the appropriate type using the appropriate form of
	/// CertNameToStr formatted as CERT_SIMPLE_NAME_STR. Then a case-insensitive substring-within-a-string match is performed. When this
	/// value is set, the search is restricted to certificates whose encoding type matches dwCertEncodingType.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_CROSS_CERT_DIST_POINTS</term>
	/// <term>
	/// Data type of pvFindPara: Not used. Find a certificate that has either a cross certificate distribution point extension or property.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_FIND_PUBKEY_MD5_HASH</term>
	/// <term>
	/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Find a certificate whose MD5-hashed public key matches the specified hash.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> There are alternate forms of the value of dwFindType that pass a string in pvFindPara. One form uses a Unicode
	/// string, and the other an ASCII string. Values that end in "_W" or without a suffix use Unicode. Values that end with "_A" use
	/// ASCII strings.
	/// </para>
	/// </param>
	/// <param name="pvFindPara">Points to a data item or structure used with dwFindType.</param>
	/// <param name="pPrevCertContext">
	/// A pointer to the last CERT_CONTEXT structure returned by this function. This parameter must be <c>NULL</c> on the first call of
	/// the function. To find successive certificates meeting the search criteria, set pPrevCertContext to the pointer returned by the
	/// previous call to the function. This function frees the <c>CERT_CONTEXT</c> referenced by non- <c>NULL</c> values of this parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns a pointer to a read-only CERT_CONTEXT structure.</para>
	/// <para>If the function fails and a certificate that matches the search criteria is not found, the return value is <c>NULL</c>.</para>
	/// <para>
	/// A non- <c>NULL</c> CERT_CONTEXT that <c>CertFindCertificateInStore</c> returns must be freed by CertFreeCertificateContext or by
	/// being passed as the pPrevCertContext parameter on a subsequent call to <c>CertFindCertificateInStore</c>.
	/// </para>
	/// <para>For extended error information, call GetLastError. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NOT_FOUND</term>
	/// <term>
	/// No certificate was found matching the search criteria. This can happen if the store is empty or the end of the store's list is reached.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The handle in the hCertStore parameter is not the same as that in the certificate context pointed to by the pPrevCertContext
	/// parameter, or a value that is not valid was specified in the dwFindType parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The dwFindFlags parameter is used to modify the criteria of some search types.</para>
	/// <para>
	/// The CERT_UNICODE_IS_RDN_ATTRS_FLAG dwFindFlags value is used only with the CERT_FIND_SUBJECT_ATTR and CERT_FIND_ISSUER_ATTR
	/// values for dwFindType. CERT_UNICODE_IS_RDN_ATTRS_FLAG must be set if the CERT_RDN_ATTR structure pointed to by pvFindPara was
	/// initialized with Unicode strings. Before any comparison is made, the string to be matched is converted by using
	/// X509_UNICODE_NAME to provide for Unicode comparisons.
	/// </para>
	/// <para>The following dwFindFlags values are used only with the CERT_FIND_ENKEY_USAGE value for dwFindType:</para>
	/// <para>
	/// CertDuplicateCertificateContext can be called to make a duplicate of the returned context. The returned context can be added to
	/// a different certificate store by using CertAddCertificateContextToStore, or a link to that certificate context can be added to a
	/// store that is not a collection store by using CertAddCertificateLinkToStore.
	/// </para>
	/// <para>
	/// The returned pointer is freed when passed as the pPrevCertContext parameter on a subsequent call to the function. Otherwise, the
	/// pointer must be explicitly freed by calling CertFreeCertificateContext. A pPrevCertContext that is not <c>NULL</c> is always
	/// freed by <c>CertFindCertificateInStore</c> using a call to <c>CertFreeCertificateContext</c>, even if there is an error in the function.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows finding a certificate context in the certificate store meeting a search criterion. For a complete
	/// example that includes the context for this example, see Example C Program: Certificate Store Operations.
	/// </para>
	/// <para>For another example that uses this function, see Example C Program: Collection and Sibling Certificate Store Operations.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfindcertificateinstore PCCERT_CONTEXT
	// CertFindCertificateInStore( HCERTSTORE hCertStore, DWORD dwCertEncodingType, DWORD dwFindFlags, DWORD dwFindType, const void
	// *pvFindPara, PCCERT_CONTEXT pPrevCertContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "20b3fcfb-55df-46ff-80a5-70f31a3d03b2")]
	public static extern SafePCCERT_CONTEXT CertFindCertificateInStore([In, AddAsMember] HCERTSTORE hCertStore, CertEncodingType dwCertEncodingType, CertFindUsageFlags dwFindFlags,
		CertFindType dwFindType, [In, MarshalAs(UnmanagedType.LPWStr)] string? pvFindPara, PCCERT_CONTEXT pPrevCertContext);

	/// <summary>
	/// The <c>CertFreeServerOcspResponseContext</c> function decrements the reference count for a CERT_SERVER_OCSP_RESPONSE_CONTEXT
	/// structure. If the reference count becomes zero, memory allocated for the structure is released.
	/// </summary>
	/// <param name="pServerOcspResponseContext">
	/// A pointer to a CERT_SERVER_OCSP_RESPONSE_CONTEXT structure that contains a value returned by the
	/// CertGetServerOcspResponseContext function.
	/// </param>
	/// <returns>This function has no return value.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfreeserverocspresponsecontext void
	// CertFreeServerOcspResponseContext( PCCERT_SERVER_OCSP_RESPONSE_CONTEXT pServerOcspResponseContext );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "a07fc1e0-6f06-4336-b33c-d4d6a838b609")]
	public static extern void CertFreeServerOcspResponseContext(PCCERT_SERVER_OCSP_RESPONSE_CONTEXT pServerOcspResponseContext);

	/// <summary>
	/// The <c>CertGetIssuerCertificateFromStore</c> function retrieves the certificate context from the certificate store for the first
	/// or next issuer of the specified subject certificate. The new Certificate Chain Verification Functions are recommended instead of
	/// the use of this function.
	/// </summary>
	/// <param name="hCertStore">Handle of a certificate store.</param>
	/// <param name="pSubjectContext">
	/// A pointer to a CERT_CONTEXT structure that contains the subject information. This parameter can be obtained from any certificate
	/// store or can be created by the calling application using the CertCreateCertificateContext function.
	/// </param>
	/// <param name="pPrevIssuerContext">
	/// <para>
	/// A pointer to a CERT_CONTEXT structure that contains the issuer information. An issuer can have multiple certificates, especially
	/// when a validity period is about to change. This parameter must be <c>NULL</c> on the call to get the first issuer certificate.
	/// To get the next certificate for the issuer, set pPrevIssuerContext to the <c>CERT_CONTEXT</c> structure returned by the previous call.
	/// </para>
	/// <para>This function frees the CERT_CONTEXT referenced by non- <c>NULL</c> values of this parameter.</para>
	/// </param>
	/// <param name="pdwFlags">
	/// <para>
	/// The following flags enable verification checks on the returned certificate. They can be combined using a bitwise- <c>OR</c>
	/// operation to enable multiple verifications.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_NO_CRL_FLAG</term>
	/// <term>Indicates no matching CRL was found.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_NO_ISSUER_FLAG</term>
	/// <term>Indicates no issuer certificate was found.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_REVOCATION_FLAG</term>
	/// <term>Checks whether the subject certificate is on the issuer's revocation list.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_SIGNATURE_FLAG</term>
	/// <term>Uses the public key in the issuer's certificate to verify the signature on the subject certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_TIME_VALIDITY_FLAG</term>
	/// <term>Gets the current time and verifies that it is within the subject certificate's validity period.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If a verification check of an enabled type succeeds, its flag is set to zero. If it fails, its flag remains set upon return. For
	/// CERT_STORE_REVOCATION_FLAG, the verification succeeds if the function does not find a CRL related to the subject certificate.
	/// </para>
	/// <para>
	/// If CERT_STORE_REVOCATION_FLAG is set and the issuer does not have a CRL in the store, CERT_STORE_NO_CRL_FLAG is set and
	/// CERT_STORE_REVOCATION_FLAG remains set.
	/// </para>
	/// <para>
	/// If CERT_STORE_SIGNATURE_FLAG or CERT_STORE_REVOCATION_FLAG is set, CERT_STORE_NO_ISSUER_FLAG is set if the function does not
	/// find an issuer certificate in the store. For more details, see Remarks.
	/// </para>
	/// <para>
	/// In the case of a verification check failure, a pointer to the issuer's CERT_CONTEXT is still returned and GetLastError is not updated.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to a read-only issuer CERT_CONTEXT.</para>
	/// <para>If the function fails and the first or next issuer certificate is not found, the return value is <c>NULL</c>.</para>
	/// <para>
	/// Only the last returned CERT_CONTEXT structure must be freed by calling CertFreeCertificateContext. When the returned
	/// <c>CERT_CONTEXT</c> from one call to the function is supplied as the pPrevIssuerContext parameter on a subsequent call, the
	/// context is freed as part of the action of the function.
	/// </para>
	/// <para>For extended error information, call GetLastError. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NOT_FOUND</term>
	/// <term>No issuer was found for the subject certificate.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_SELF_SIGNED</term>
	/// <term>The issuer certificate is the same as the subject certificate. It is a self-signed root certificate.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The handle in the hCertStore parameter is not the same as that of the certificate context pointed to by the pPrevIssuerContext
	/// parameter, or an unsupported flag was set in pdwFlags.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The returned pointer is freed when passed as the pPrevIssuerContext parameter on a subsequent call to the function. Otherwise,
	/// the pointer must be explicitly freed by calling CertFreeCertificateContext. A pPrevIssuerContext that is not <c>NULL</c> is
	/// always freed by <c>CertGetIssuerCertificateFromStore</c> using a call to <c>CertFreeCertificateContext</c>, even if there is an
	/// error in the function.
	/// </para>
	/// <para>CertDuplicateCertificateContext can be called to make a duplicate of the issuer certificate.</para>
	/// <para>
	/// The hexadecimal values for dwFlags can be combined using a bitwise- <c>OR</c> operation to enable multiple verifications. For
	/// example, to enable both signature and time validity, the value 0x00000003 is passed in dwFlags on input. In this case, if
	/// CERT_STORE_SIGNATURE_FLAG verification succeeds but CERT_STORE_TIME_VALIDITY_FLAG verification fails, dwFlags returns as
	/// 0x00000002 on output.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetissuercertificatefromstore PCCERT_CONTEXT
	// CertGetIssuerCertificateFromStore( HCERTSTORE hCertStore, PCCERT_CONTEXT pSubjectContext, PCCERT_CONTEXT pPrevIssuerContext,
	// DWORD *pdwFlags );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b57982d0-cba8-43cd-a544-3635fdf599e2")]
	public static extern SafePCCERT_CONTEXT CertGetIssuerCertificateFromStore([In, AddAsMember] HCERTSTORE hCertStore, PCCERT_CONTEXT pSubjectContext,
		PCCERT_CONTEXT pPrevIssuerContext, ref CertStoreVerification pdwFlags);

	/// <summary>
	/// The <c>CertGetServerOcspResponseContext</c> function retrieves a non-blocking, time valid online certificate status protocol
	/// (OCSP) response context for the specified handle.
	/// </summary>
	/// <param name="hServerOcspResponse">
	/// The OCSP server response handle for which to retrieve a response context. This handle is returned by the
	/// CertOpenServerOcspResponse function.
	/// </param>
	/// <param name="dwFlags">This parameter is reserved for future use and must be zero.</param>
	/// <param name="pvReserved">This parameter is reserved for future use and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns a pointer to a CERT_SERVER_OCSP_RESPONSE_CONTEXT structure.</para>
	/// <para>
	/// For a response to be time valid, the current time on the system hosting this function call must be less than the next update
	/// time for the certificate revocation list (CRL) context. When a time valid OCSP response is not available, this function returns
	/// <c>NULL</c> with the last error set to CRYPT_E_REVOCATION_OFFLINE.
	/// </para>
	/// </returns>
	/// <remarks>
	/// If you use the <c>CertGetServerOcspResponseContext</c> function to create multiple references to an OCSP response context, you
	/// must call CertAddRefServerOcspResponseContext to increment the reference count for the CERT_SERVER_OCSP_RESPONSE_CONTEXT
	/// structure. When you have finished using the structure, you must free it by calling the CertFreeServerOcspResponseContext function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetserverocspresponsecontext
	// PCCERT_SERVER_OCSP_RESPONSE_CONTEXT CertGetServerOcspResponseContext( HCERT_SERVER_OCSP_RESPONSE hServerOcspResponse, DWORD
	// dwFlags, LPVOID pvReserved );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "07476e43-db6b-4119-8d6b-41143b98744e")]
	public static extern SafePCCERT_SERVER_OCSP_RESPONSE_CONTEXT CertGetServerOcspResponseContext(HCERT_SERVER_OCSP_RESPONSE hServerOcspResponse, uint dwFlags = 0, IntPtr pvReserved = default);

	/// <summary>
	/// The <c>CertGetSubjectCertificateFromStore</c> function returns from a certificate store a subject certificate context uniquely
	/// identified by its issuer and serial number.
	/// </summary>
	/// <param name="hCertStore">A handle of a certificate store.</param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// The type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them
	/// with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pCertId">A pointer to a CERT_INFO structure. Only the <c>Issuer</c> and <c>SerialNumber</c> members are used.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the function returns a pointer to a read-only CERT_CONTEXT. The <c>CERT_CONTEXT</c> must be freed by
	/// calling CertFreeCertificateContext.
	/// </para>
	/// <para>The returned certificate might not be valid. Usually, it is verified when getting its issuer certificate (CertGetIssuerCertificateFromStore).</para>
	/// <para>For extended error information, call GetLastError. One possible error code is the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NOT_FOUND</term>
	/// <term>The subject certificate was not found in the store.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>CertDuplicateCertificateContext can be called to make a duplicate certificate.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows retrieving a subject's certificate context, uniquely identified by its issuer and serial number,
	/// from the certificate store. For an example that includes the complete context for this example, see Example C Program: Signing,
	/// Encoding, Decoding, and Verifying a Message.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetsubjectcertificatefromstore PCCERT_CONTEXT
	// CertGetSubjectCertificateFromStore( HCERTSTORE hCertStore, DWORD dwCertEncodingType, PCERT_INFO pCertId );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "61d73501-91b1-4498-b1a3-17392360c700")]
	public static extern SafePCCERT_CONTEXT CertGetSubjectCertificateFromStore([In, AddAsMember] HCERTSTORE hCertStore, CertEncodingType dwCertEncodingType, in CERT_INFO pCertId);

	/// <summary>
	/// The <c>CertGetValidUsages</c> function returns an array of usages that consist of the intersection of the valid usages for all
	/// certificates in an array of certificates.
	/// </summary>
	/// <param name="cCerts">The number of certificates in the array to be checked.</param>
	/// <param name="rghCerts">An array of certificates to be checked for valid usage.</param>
	/// <param name="cNumOIDs">
	/// The number of valid usages found as the intersection of the valid usages of all certificates in the array. If all of the
	/// certificates are valid for all usages, cNumOIDs is set to negative one (–1).
	/// </param>
	/// <param name="rghOIDs">
	/// An array of the object identifiers (OIDs) of the valid usages that are shared by all of the certificates in the rghCerts array.
	/// This parameter can be <c>NULL</c> to set the size of this structure for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </param>
	/// <param name="pcbOIDs">
	/// A pointer to a <c>DWORD</c> value that specifies the size, in bytes, of the rghOIDs array and the strings pointed to. When the
	/// function returns, the <c>DWORD</c> value contains the number of bytes needed for the array.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. For extended error
	/// information, call GetLastError.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetvalidusages BOOL CertGetValidUsages( DWORD cCerts,
	// PCCERT_CONTEXT *rghCerts, int *cNumOIDs, LPSTR *rghOIDs, DWORD *pcbOIDs );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "1504f166-2fa9-4041-9d72-b150cd8baa8a")]
	[SuppressAutoGen]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertGetValidUsages(uint cCerts, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PCCERT_CONTEXT[] rghCerts,
		out int cNumOIDs, [Out, Optional, MarshalAs(UnmanagedType.LPArray)] IntPtr[]? rghOIDs, ref uint pcbOIDs);

	/// <summary>
	/// The <c>CertGetValidUsages</c> function returns an array of usages that consist of the intersection of the valid usages for all
	/// certificates in an array of certificates.
	/// </summary>
	/// <param name="rghCerts">An array of certificates to be checked for valid usage.</param>
	/// <param name="rghOIDs">
	/// An array of the object identifiers (OIDs) of the valid usages that are shared by all of the certificates in the rghCerts array.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. For extended error
	/// information, call GetLastError.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetvalidusages BOOL CertGetValidUsages( DWORD cCerts,
	// PCCERT_CONTEXT *rghCerts, int *cNumOIDs, LPSTR *rghOIDs, DWORD *pcbOIDs );
	[PInvokeData("wincrypt.h", MSDNShortId = "1504f166-2fa9-4041-9d72-b150cd8baa8a")]
	public static bool CertGetValidUsages(PCCERT_CONTEXT[] rghCerts, out string[] rghOIDs)
	{
		rghOIDs = [];
		uint pcbOIDs = 0;
		if (!CertGetValidUsages((uint)rghCerts.Length, rghCerts, out _, IntPtr.Zero, ref pcbOIDs))
			return false;
		if (pcbOIDs == 0)
			return true;
		using SafeCoTaskMemHandle rghOIDPtrs = new(pcbOIDs);
		if (!CertGetValidUsages((uint)rghCerts.Length, rghCerts, out var cNumOIDs, rghOIDPtrs, ref pcbOIDs))
			return false;
		if (cNumOIDs != -1)
			rghOIDs = [.. rghOIDPtrs.ToStringEnum(cNumOIDs, CharSet.Ansi).WhereNotNull()];
		return true;

		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool CertGetValidUsages(uint cCerts, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PCCERT_CONTEXT[] rghCerts,
			out int cNumOIDs, [Out, Optional] IntPtr rghOIDs, ref uint pcbOIDs);
	}

	/// <summary>
	/// The <c>CertOpenServerOcspResponse</c> function opens a handle to an online certificate status protocol (OCSP) response
	/// associated with a server certificate chain.
	/// </summary>
	/// <param name="pChainContext">The address of a CERT_CHAIN_CONTEXT structure that contains the certificate chain.</param>
	/// <param name="dwFlags">This parameter is not used and must be zero.</param>
	/// <param name="pOpenPara">This parameter is not used and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>
	/// Returns a handle to the OCSP response associated with a server certificate chain if successful; otherwise, <c>NULL</c>. This
	/// handle must be passed to the CertCloseServerOcspResponse function when it is no longer needed.
	/// </para>
	/// <para>
	/// For extended error information, call GetLastError. Possible error codes returned by the <c>GetLastError</c> function include,
	/// but are not limited to, the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NOT_IN_REVOCATION_DATABASE</term>
	/// <term>The end certificate does not contain an OCSP authority information access (AIA) URL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CertOpenServerOcspResponse</c> function tries to retrieve an initial OCSP response before it returns. It blocks its
	/// process thread during the retrieval. The <c>CertOpenServerOcspResponse</c> function creates a background thread that prefetches
	/// time-valid OCSP responses.
	/// </para>
	/// <para>
	/// The <c>CertOpenServerOcspResponse</c> function increments the reference count for the chain context represented by the
	/// pChainContext parameter. When you have finished using the chain context, close the returned handle by calling the
	/// CertCloseServerOcspResponse function.
	/// </para>
	/// <para>The <c>CertOpenServerOcspResponse</c> function initializes configuration settings used by the following functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CertAddRefServerOcspResponse</term>
	/// </item>
	/// <item>
	/// <term>CertCloseServerOcspResponse</term>
	/// </item>
	/// <item>
	/// <term>CertGetServerOcspResponseContext</term>
	/// </item>
	/// <item>
	/// <term>CertAddRefServerOcspResponseContext</term>
	/// </item>
	/// <item>
	/// <term>CertFreeServerOcspResponseContext</term>
	/// </item>
	/// </list>
	/// <para>
	/// First, the <c>CertOpenServerOcspResponse</c> function initializes the settings based on default values in Wincrypt.h. If the
	/// function subsequently finds the registry key defined in <c>CERT_CHAIN_CONFIG_REGPATH</c>, it updates the previously initialized
	/// values with the registry values.
	/// </para>
	/// <para>The following configuration setting names and default values are initialized by this function:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>CERT_SRV_OCSP_RESP_MIN_VALIDITY_SECONDS_VALUE_NAME</c></term>
	/// </item>
	/// <item>
	/// <term><c>CERT_SRV_OCSP_RESP_MIN_VALIDITY_SECONDS_DEFAULT</c></term>
	/// </item>
	/// <item>
	/// <term><c>CERT_SRV_OCSP_RESP_URL_RETRIEVAL_TIMEOUT_MILLISECONDS_VALUE_NAME</c></term>
	/// </item>
	/// <item>
	/// <term><c>CERT_SRV_OCSP_RESP_URL_RETRIEVAL_TIMEOUT_MILLISECONDS_DEFAULT</c></term>
	/// </item>
	/// <item>
	/// <term><c>CERT_SRV_OCSP_RESP_MAX_BEFORE_NEXT_UPDATE_SECONDS_VALUE_NAME</c></term>
	/// </item>
	/// <item>
	/// <term><c>CERT_SRV_OCSP_RESP_MAX_BEFORE_NEXT_UPDATE_SECONDS_DEFAULT</c></term>
	/// </item>
	/// <item>
	/// <term><c>CERT_SRV_OCSP_RESP_MIN_BEFORE_NEXT_UPDATE_SECONDS_VALUE_NAME</c></term>
	/// </item>
	/// <item>
	/// <term><c>CERT_SRV_OCSP_RESP_MIN_BEFORE_NEXT_UPDATE_SECONDS_DEFAULT</c></term>
	/// </item>
	/// <item>
	/// <term><c>CERT_SRV_OCSP_RESP_MIN_AFTER_NEXT_UPDATE_SECONDS_VALUE_NAME</c></term>
	/// </item>
	/// <item>
	/// <term><c>CERT_SRV_OCSP_RESP_MIN_AFTER_NEXT_UPDATE_SECONDS_DEFAULT</c></term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certopenserverocspresponse HCERT_SERVER_OCSP_RESPONSE
	// CertOpenServerOcspResponse( PCCERT_CHAIN_CONTEXT pChainContext, DWORD dwFlags, PCERT_SERVER_OCSP_RESPONSE_OPEN_PARA pOpenPara );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "c29d1972-b329-4e32-aead-a038130fb85e")]
	public static extern HCERT_SERVER_OCSP_RESPONSE CertOpenServerOcspResponse([In] PCCERT_CHAIN_CONTEXT pChainContext, uint dwFlags = 0, IntPtr pOpenPara = default);

	/// <summary>
	/// The <c>CertRetrieveLogoOrBiometricInfo</c> function performs a URL retrieval of logo or biometric information specified in
	/// either the <c>szOID_LOGOTYPE_EXT</c> or <c>szOID_BIOMETRIC_EXT</c> certificate extension. The <c>szOID_BIOMETRIC_EXT</c>
	/// extension (IETF RFC 3739) supports the addition of a signature or a pictorial representation of the human holder of the
	/// certificate. The <c>szOID_LOGOTYPE_EXT</c> extension (IETF RFC 3709) supports the addition of organizational pictorial
	/// representations in certificates.
	/// </summary>
	/// <param name="pCertContext">The address of a CERT_CONTEXT structure that contains the certificate.</param>
	/// <param name="lpszLogoOrBiometricType">
	/// <para>
	/// The address of a null-terminated ANSI string that contains an object identifier (OID) string that identifies the type of
	/// information to retrieve.
	/// </para>
	/// <para>This parameter may also contain one of the following predefined values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_RETRIEVE_ISSUER_LOGO</term>
	/// <term>Retrieve the certificate issuer logotype.</term>
	/// </item>
	/// <item>
	/// <term>CERT_RETRIEVE_SUBJECT_LOGO</term>
	/// <term>Retrieve the certificate subject logotype.</term>
	/// </item>
	/// <item>
	/// <term>CERT_RETRIEVE_COMMUNITY_LOGO</term>
	/// <term>Retrieve the certificate community logotype.</term>
	/// </item>
	/// <item>
	/// <term>CERT_RETRIEVE_BIOMETRIC_PICTURE_TYPE</term>
	/// <term>Retrieve the picture associated with the certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_RETRIEVE_BIOMETRIC_SIGNATURE_TYPE</term>
	/// <term>Retrieve the signature associated with the certificate.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwRetrievalFlags">
	/// A set of flags that specify how the information should be retrieved. This parameter is passed as the dwRetrievalFlags in the
	/// CryptRetrieveObjectByUrl function.
	/// </param>
	/// <param name="dwTimeout">The maximum amount of time, in milliseconds, to wait for the retrieval.</param>
	/// <param name="dwFlags">This parameter is not used and must be zero.</param>
	/// <param name="pvReserved">This parameter is not used and must be <c>NULL</c>.</param>
	/// <param name="ppbData">
	/// The address of a <c>BYTE</c> pointer that receives the logotype or biometric data. This memory must be freed when it is no
	/// longer needed by passing this pointer to the CryptMemFree function.
	/// </param>
	/// <param name="pcbData">The address of a <c>DWORD</c> variable that receives the number of bytes in the ppbData buffer.</param>
	/// <param name="ppwszMimeType">
	/// <para>
	/// The address of a pointer to a null-terminated Unicode string that receives the Multipurpose Internet Mail Extensions (MIME) type
	/// of the data. This parameter can be <c>NULL</c> if this information is not needed. This memory must be freed when it is no longer
	/// needed by passing this pointer to the CryptMemFree function.
	/// </para>
	/// <para>
	/// This address always receives <c>NULL</c> for biometric types. You must always ensure that this parameter contains a valid memory
	/// address before attempting to access the memory.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns nonzero if successful or zero otherwise.</para>
	/// <para>
	/// For extended error information, call GetLastError. Possible error codes returned by the <c>GetLastError</c> function include,
	/// but are not limited to, the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_HASH_VALUE</term>
	/// <term>The computed hash value does not match the hash value in the certificate.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NOT_FOUND</term>
	/// <term>
	/// The certificate does not contain the szOID_LOGOTYPE_EXT or szOID_BIOMETRIC_EXT extension, or the specified
	/// lpszLogoOrBiometricType was not found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>No data could be retrieved from the URL specified by the certificate extension.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>The certificate does not support the required extension.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The hash algorithm OID is unknown.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certretrievelogoorbiometricinfo BOOL
	// CertRetrieveLogoOrBiometricInfo( PCCERT_CONTEXT pCertContext, LPCSTR lpszLogoOrBiometricType, DWORD dwRetrievalFlags, DWORD
	// dwTimeout, DWORD dwFlags, void *pvReserved, BYTE **ppbData, DWORD *pcbData, LPWSTR *ppwszMimeType );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "35813928-728e-40b7-b627-817d3094eeb1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertRetrieveLogoOrBiometricInfo(PCCERT_CONTEXT pCertContext, [In] SafeOID lpszLogoOrBiometricType, CryptRetrievalFlags dwRetrievalFlags,
		uint dwTimeout, [Optional] uint dwFlags, [Optional] IntPtr pvReserved, out SafeCryptMem ppbData, out uint pcbData, out SafeCryptMem ppwszMimeType);

	/// <summary>
	/// The <c>CertRetrieveLogoOrBiometricInfo</c> function performs a URL retrieval of logo or biometric information specified in either the
	/// <c>szOID_LOGOTYPE_EXT</c> or <c>szOID_BIOMETRIC_EXT</c> certificate extension. The <c>szOID_BIOMETRIC_EXT</c> extension (IETF RFC
	/// 3739) supports the addition of a signature or a pictorial representation of the human holder of the certificate. The
	/// <c>szOID_LOGOTYPE_EXT</c> extension (IETF RFC 3709) supports the addition of organizational pictorial representations in certificates.
	/// </summary>
	/// <param name="pCertContext">The address of a CERT_CONTEXT structure that contains the certificate.</param>
	/// <param name="lpszLogoOrBiometricType">
	/// <para>
	/// The address of a null-terminated ANSI string that contains an object identifier (OID) string that identifies the type of information
	/// to retrieve.
	/// </para>
	/// <para>This parameter may also contain one of the following predefined values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_RETRIEVE_ISSUER_LOGO</term>
	/// <term>Retrieve the certificate issuer logotype.</term>
	/// </item>
	/// <item>
	/// <term>CERT_RETRIEVE_SUBJECT_LOGO</term>
	/// <term>Retrieve the certificate subject logotype.</term>
	/// </item>
	/// <item>
	/// <term>CERT_RETRIEVE_COMMUNITY_LOGO</term>
	/// <term>Retrieve the certificate community logotype.</term>
	/// </item>
	/// <item>
	/// <term>CERT_RETRIEVE_BIOMETRIC_PICTURE_TYPE</term>
	/// <term>Retrieve the picture associated with the certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_RETRIEVE_BIOMETRIC_SIGNATURE_TYPE</term>
	/// <term>Retrieve the signature associated with the certificate.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwRetrievalFlags">
	/// A set of flags that specify how the information should be retrieved. This parameter is passed as the dwRetrievalFlags in the
	/// CryptRetrieveObjectByUrl function.
	/// </param>
	/// <param name="dwTimeout">The maximum amount of time, in milliseconds, to wait for the retrieval.</param>
	/// <param name="ppbData">The address of a <c>BYTE</c> pointer that receives the logotype or biometric data.</param>
	/// <param name="ppwszMimeType">A string that receives the Multipurpose Internet Mail Extensions (MIME) type of the data.</param>
	/// <returns>
	/// <para>Returns nonzero if successful or zero otherwise.</para>
	/// <para>
	/// For extended error information, call GetLastError. Possible error codes returned by the <c>GetLastError</c> function include, but are
	/// not limited to, the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_HASH_VALUE</term>
	/// <term>The computed hash value does not match the hash value in the certificate.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NOT_FOUND</term>
	/// <term>
	/// The certificate does not contain the szOID_LOGOTYPE_EXT or szOID_BIOMETRIC_EXT extension, or the specified lpszLogoOrBiometricType
	/// was not found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>No data could be retrieved from the URL specified by the certificate extension.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>The certificate does not support the required extension.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The hash algorithm OID is unknown.</term>
	/// </item>
	/// </list>
	/// </returns>
	[PInvokeData("wincrypt.h", MSDNShortId = "35813928-728e-40b7-b627-817d3094eeb1")]
	public static bool CertRetrieveLogoOrBiometricInfo([In] PCCERT_CONTEXT pCertContext, [In] SafeOID lpszLogoOrBiometricType, CryptRetrievalFlags dwRetrievalFlags,
		TimeSpan dwTimeout, out byte[] ppbData, out string ppwszMimeType)
	{
		ppbData = [];
		ppwszMimeType = string.Empty;
		if (!CertRetrieveLogoOrBiometricInfo(pCertContext, lpszLogoOrBiometricType, dwRetrievalFlags, (uint)dwTimeout.TotalMilliseconds, 0, default, out var pData, out var cbData, out var pMimeType))
			return false;
		pData.DangerousOverrideSize(cbData);
		ppbData = pData.GetBytes();
		ppwszMimeType = Marshal.PtrToStringUni(pMimeType) ?? "";
		return true;
	}

	/// <summary>The <c>CertSelectCertificateChains</c> function retrieves certificate chains based on specified selection criteria.</summary>
	/// <param name="pSelectionContext">A pointer to the GUID of the certificate selection scenario to use for this call.</param>
	/// <param name="dwFlags">
	/// <para>
	/// Flags for controlling the certificate selection process. This parameter can be a combination of zero or more of the following flags:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SELECT_ALLOW_EXPIRED</term>
	/// <term>Select expired certificates that meet selection criteria. By default expired certificates are rejected from selection.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SELECT_TRUSTED_ROOT</term>
	/// <term>
	/// Select certificates on which the error bit in the certificate chain trust status is not set to CERT_TRUST_IS_UNTRUSTED_ROOT,
	/// CERT_TRUST_IS_PARTIAL_CHAIN, or CERT_TRUST_IS_NOT_TIME_VALID. In addition, certificates that have one of the following invalid
	/// constraint errors are not selected:
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_SELECT_DISALLOW_SELFSIGNED</term>
	/// <term>Select certificates that are not self-issued and self-signed.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SELECT_HAS_PRIVATE_KEY</term>
	/// <term>Select certificates that have a value set for the CERT_KEY_PROV_INFO_PROP_ID property of the certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SELECT_HAS_KEY_FOR_SIGNATURE</term>
	/// <term>
	/// Select certificates on which the value of the dwKeySpec member of the CERT_KEY_PROV_INFO_PROP_ID property is set to
	/// AT_SIGNATURE. If this function is being called as part of a CNG enabled application and the dwKeySpec member of the
	/// CERT_KEY_PROV_INFO_PROP_ID property is set to -1, select certificates on which the value of the NCRYPT_KEY_USAGE_PROPERTY
	/// property of the associated private key has the NCRYPT_ALLOW_SIGNING_FLAG set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_SELECT_HAS_KEY_FOR_KEY_EXCHANGE</term>
	/// <term>
	/// Select certificates on which the value of the dwKeySpec member of the CERT_KEY_PROV_INFO_PROP_ID property is set to
	/// AT_KEYEXCHANGE. If this function is being called as part of a CNG enabled application and the dwKeySpec member of the
	/// CERT_KEY_PROV_INFO_PROP_ID property is set to -1, select certificates on which either NCRYPT_ALLOW_DECRYPT_FLAG or
	/// NCRYPT_ALLOW_KEY_AGREEMENT_FLAG is set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_SELECT_HARDWARE_ONLY</term>
	/// <term>
	/// Select certificates on which the value of the PP_IMPTYPE property of the associated private key provider is set to either
	/// CRYPT_IMPL_HARDWARE or CRYPT_IMPL_REMOVABLE. (For CNG providers, NCRYPT_IMPL_TYPE_PROPERTY property value MUST have either the
	/// NCRYPT_IMPL_HARDWARE_FLAG or NCRYPT_IMPL_REMOVABLE_FLAG bit set). If this function is being called as part of a CNG enabled
	/// application, select certificates on which the NCRYPT_IMPL_TYPE_PROPERTY property is set to NCRYPT_IMPL_HARDWARE_FLAG or NCRYPT_IMPL_REMOVABLE_FLAG.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_SELECT_ALLOW_DUPLICATES</term>
	/// <term>
	/// Allow the selection of certificates on which the Subject and Subject Alt Name contain the same information and the certificate
	/// template extension value is equivalent. By default when certificates match this criteria, only the most recent certificate is selected.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pChainParameters">
	/// <para>
	/// A pointer to a CERT_SELECT_CHAIN_PARA structure to specify parameters for chain building. If <c>NULL</c>, default parameters
	/// will be used.
	/// </para>
	/// <para>
	/// The <c>pChainPara</c> member of the CERT_SELECT_CHAIN_PARA structure points to a CERT_CHAIN_PARA structure that can be used to
	/// enable strong signing.
	/// </para>
	/// </param>
	/// <param name="cCriteria">The number of elements in the array pointed to by the rgpCriteria array.</param>
	/// <param name="rgpCriteria">
	/// A pointer to an array of CERT_SELECT_CRITERIA structures that define the selection criteria. If this parameter is set to
	/// <c>NULL</c>, the value of the cCriteria parameter must be zero.
	/// </param>
	/// <param name="hStore">The handle to a store from which to select the certificates.</param>
	/// <param name="pcSelection">
	/// A pointer to a <c>DWORD</c> value to receive the number of elements in the array pointed to by the pprgpSelection parameter.
	/// </param>
	/// <param name="pprgpSelection">
	/// <para>
	/// A pointer to a pointer to a location to receive an array of CERT_CHAIN_CONTEXT structure. The <c>CertSelectCertificateChains</c>
	/// function only returns certificate chains that match all the selection criteria. The entries in the array are ordered by quality,
	/// i.e. the chain with the highest quality is the first entry.
	/// </para>
	/// <para>
	/// Storage for the array is allocated by the <c>CertSelectCertificateChains</c> function. To free the allocated memory you must
	/// first release each individual chain context in the array by calling the CertFreeCertificateChain function. Then you must free
	/// the memory by calling the CertFreeCertificateChainList function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns zero (FALSE). For extended error information, call the GetLastError function.</para>
	/// <para>
	/// <c>Note</c> If the selection does not yield any results, the <c>CertSelectCertificateChains</c> function returns <c>TRUE</c>,
	/// but the value pointed to by pcSelection parameter is set to zero.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Selection criteria can be specified through either the dwFlags parameter, through the rgpCriteria parameter, or through both
	/// parameters. If no selection criteria are specified, the function succeeds and returns certificate chains for all certificates in
	/// the store specified by the hStore parameter.
	/// </para>
	/// <para>Certificate chains that are selected are ordered based on the following preference logic:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Prefer certificates that are smart card certificates over certificates that are not smart-card based.</term>
	/// </item>
	/// <item>
	/// <term>Prefer certificates that have a longer validity period (the expiration date is later.)</term>
	/// </item>
	/// <item>
	/// <term>If multiple certificates have same expiration date, prefer certificates that were issued more recently.</term>
	/// </item>
	/// <item>
	/// <term>If there is a tie, prefer shorter chains.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Certain selection criteria require that a certificate chain be built before you can select that criteria for use. If the
	/// intermediate certificates required to build the chain are not available locally, a network retrieval is performed for the issuer
	/// certificates. This network retrieval is performed if the <c>CERT_SELECT_TRUSTED_ROOT</c> flag is set or for the following criteria:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>CERT_SELECT_BY_ISSUER_NAME</c></term>
	/// </item>
	/// <item>
	/// <term><c>CERT_SELECT_BY_ISSUER_ATTR</c></term>
	/// </item>
	/// <item>
	/// <term><c>CERT_SELECT_BY_POLICY_OID</c></term>
	/// </item>
	/// </list>
	/// <para>Perform the following actions to enable strong signature checking:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Create a CERT_STRONG_SIGN_PARA structure, specify the required strong signing parameters, and set a pointer to the structure in
	/// the <c>pStrongSignPara</c> member of a CERT_CHAIN_PARA structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Set a pointer to the CERT_CHAIN_PARA structure in the <c>pChainPara</c> member of a CERT_SELECT_CHAIN_PARA structure.</term>
	/// </item>
	/// <item>
	/// <term>Set a pointer to the CERT_SELECT_CHAIN_PARA structure in the pChainParameters parameter of this ( <c>CertSelectCertificateChains</c>)function.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When you enable strong signature checking, any certificate chain that returns a <c>CERT_TRUST_IS_NOT_SIGNATURE_VALID</c> error
	/// in the <c>dwErrorStatus</c> field of the CERT_TRUST_STATUS structure will be skipped. (The pprgpSelection parameter points to a
	/// CERT_CHAIN_CONTEXT structure which, in turn, points to the <c>CERT_TRUST_STATUS</c> structure.) The
	/// <c>CERT_TRUST_HAS_WEAK_SIGNATURE</c> value is also set for a weak signature.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certselectcertificatechains BOOL
	// CertSelectCertificateChains( LPCGUID pSelectionContext, DWORD dwFlags, PCCERT_SELECT_CHAIN_PARA pChainParameters, DWORD
	// cCriteria, PCCERT_SELECT_CRITERIA rgpCriteria, HCERTSTORE hStore, PDWORD pcSelection, PCCERT_CHAIN_CONTEXT **pprgpSelection );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b740772b-d25b-4b3d-9acb-03f7018750d6")]
	[SuppressAutoGen]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertSelectCertificateChains([In, Optional] GuidPtr pSelectionContext, CertSelection dwFlags, [In, Optional] StructPointer<CERT_SELECT_CHAIN_PARA> pChainParameters,
		uint cCriteria, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] CERT_SELECT_CRITERIA[]? rgpCriteria, HCERTSTORE hStore, out uint pcSelection,
		out ArrayPointer<StructPointer<CERT_CHAIN_CONTEXT>> pprgpSelection);

	/// <summary>The <c>CertSelectCertificateChains</c> function retrieves certificate chains based on specified selection criteria.</summary>
	/// <param name="pSelectionContext">A pointer to the GUID of the certificate selection scenario to use for this call.</param>
	/// <param name="dwFlags">
	/// <para>
	/// Flags for controlling the certificate selection process. This parameter can be a combination of zero or more of the following flags:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SELECT_ALLOW_EXPIRED</term>
	/// <term>Select expired certificates that meet selection criteria. By default expired certificates are rejected from selection.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SELECT_TRUSTED_ROOT</term>
	/// <term>
	/// Select certificates on which the error bit in the certificate chain trust status is not set to CERT_TRUST_IS_UNTRUSTED_ROOT,
	/// CERT_TRUST_IS_PARTIAL_CHAIN, or CERT_TRUST_IS_NOT_TIME_VALID. In addition, certificates that have one of the following invalid
	/// constraint errors are not selected:
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_SELECT_DISALLOW_SELFSIGNED</term>
	/// <term>Select certificates that are not self-issued and self-signed.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SELECT_HAS_PRIVATE_KEY</term>
	/// <term>Select certificates that have a value set for the CERT_KEY_PROV_INFO_PROP_ID property of the certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_SELECT_HAS_KEY_FOR_SIGNATURE</term>
	/// <term>
	/// Select certificates on which the value of the dwKeySpec member of the CERT_KEY_PROV_INFO_PROP_ID property is set to
	/// AT_SIGNATURE. If this function is being called as part of a CNG enabled application and the dwKeySpec member of the
	/// CERT_KEY_PROV_INFO_PROP_ID property is set to -1, select certificates on which the value of the NCRYPT_KEY_USAGE_PROPERTY
	/// property of the associated private key has the NCRYPT_ALLOW_SIGNING_FLAG set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_SELECT_HAS_KEY_FOR_KEY_EXCHANGE</term>
	/// <term>
	/// Select certificates on which the value of the dwKeySpec member of the CERT_KEY_PROV_INFO_PROP_ID property is set to
	/// AT_KEYEXCHANGE. If this function is being called as part of a CNG enabled application and the dwKeySpec member of the
	/// CERT_KEY_PROV_INFO_PROP_ID property is set to -1, select certificates on which either NCRYPT_ALLOW_DECRYPT_FLAG or
	/// NCRYPT_ALLOW_KEY_AGREEMENT_FLAG is set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_SELECT_HARDWARE_ONLY</term>
	/// <term>
	/// Select certificates on which the value of the PP_IMPTYPE property of the associated private key provider is set to either
	/// CRYPT_IMPL_HARDWARE or CRYPT_IMPL_REMOVABLE. (For CNG providers, NCRYPT_IMPL_TYPE_PROPERTY property value MUST have either the
	/// NCRYPT_IMPL_HARDWARE_FLAG or NCRYPT_IMPL_REMOVABLE_FLAG bit set). If this function is being called as part of a CNG enabled
	/// application, select certificates on which the NCRYPT_IMPL_TYPE_PROPERTY property is set to NCRYPT_IMPL_HARDWARE_FLAG or NCRYPT_IMPL_REMOVABLE_FLAG.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_SELECT_ALLOW_DUPLICATES</term>
	/// <term>
	/// Allow the selection of certificates on which the Subject and Subject Alt Name contain the same information and the certificate
	/// template extension value is equivalent. By default when certificates match this criteria, only the most recent certificate is selected.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pChainParameters">
	/// <para>
	/// A pointer to a CERT_SELECT_CHAIN_PARA structure to specify parameters for chain building. If <c>NULL</c>, default parameters
	/// will be used.
	/// </para>
	/// <para>
	/// The <c>pChainPara</c> member of the CERT_SELECT_CHAIN_PARA structure points to a CERT_CHAIN_PARA structure that can be used to
	/// enable strong signing.
	/// </para>
	/// </param>
	/// <param name="rgpCriteria">
	/// A pointer to an array of CERT_SELECT_CRITERIA structures that define the selection criteria.
	/// </param>
	/// <param name="hStore">The handle to a store from which to select the certificates.</param>
	/// <returns>
	/// A pointer to a pointer to a location to receive an array of CERT_CHAIN_CONTEXT structure. The <c>CertSelectCertificateChains</c>
	/// function only returns certificate chains that match all the selection criteria. The entries in the array are ordered by quality,
	/// i.e. the chain with the highest quality is the first entry.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Selection criteria can be specified through either the dwFlags parameter, through the rgpCriteria parameter, or through both
	/// parameters. If no selection criteria are specified, the function succeeds and returns certificate chains for all certificates in
	/// the store specified by the hStore parameter.
	/// </para>
	/// <para>Certificate chains that are selected are ordered based on the following preference logic:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Prefer certificates that are smart card certificates over certificates that are not smart-card based.</term>
	/// </item>
	/// <item>
	/// <term>Prefer certificates that have a longer validity period (the expiration date is later.)</term>
	/// </item>
	/// <item>
	/// <term>If multiple certificates have same expiration date, prefer certificates that were issued more recently.</term>
	/// </item>
	/// <item>
	/// <term>If there is a tie, prefer shorter chains.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Certain selection criteria require that a certificate chain be built before you can select that criteria for use. If the
	/// intermediate certificates required to build the chain are not available locally, a network retrieval is performed for the issuer
	/// certificates. This network retrieval is performed if the <c>CERT_SELECT_TRUSTED_ROOT</c> flag is set or for the following criteria:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>CERT_SELECT_BY_ISSUER_NAME</c></term>
	/// </item>
	/// <item>
	/// <term><c>CERT_SELECT_BY_ISSUER_ATTR</c></term>
	/// </item>
	/// <item>
	/// <term><c>CERT_SELECT_BY_POLICY_OID</c></term>
	/// </item>
	/// </list>
	/// <para>Perform the following actions to enable strong signature checking:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Create a CERT_STRONG_SIGN_PARA structure, specify the required strong signing parameters, and set a pointer to the structure in
	/// the <c>pStrongSignPara</c> member of a CERT_CHAIN_PARA structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Set a pointer to the CERT_CHAIN_PARA structure in the <c>pChainPara</c> member of a CERT_SELECT_CHAIN_PARA structure.</term>
	/// </item>
	/// <item>
	/// <term>Set a pointer to the CERT_SELECT_CHAIN_PARA structure in the pChainParameters parameter of this ( <c>CertSelectCertificateChains</c>)function.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When you enable strong signature checking, any certificate chain that returns a <c>CERT_TRUST_IS_NOT_SIGNATURE_VALID</c> error
	/// in the <c>dwErrorStatus</c> field of the CERT_TRUST_STATUS structure will be skipped. (The pprgpSelection parameter points to a
	/// CERT_CHAIN_CONTEXT structure which, in turn, points to the <c>CERT_TRUST_STATUS</c> structure.) The
	/// <c>CERT_TRUST_HAS_WEAK_SIGNATURE</c> value is also set for a weak signature.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certselectcertificatechains BOOL
	// CertSelectCertificateChains( LPCGUID pSelectionContext, DWORD dwFlags, PCCERT_SELECT_CHAIN_PARA pChainParameters, DWORD
	// cCriteria, PCCERT_SELECT_CRITERIA rgpCriteria, HCERTSTORE hStore, PDWORD pcSelection, PCCERT_CHAIN_CONTEXT **pprgpSelection );
	public static SafeCertificateChainList CertSelectCertificateChains([In] Guid? pSelectionContext, CertSelection dwFlags,
		[In, Optional] CERT_SELECT_CHAIN_PARA? pChainParameters, [In, Optional] CERT_SELECT_CRITERIA[]? rgpCriteria, [In, AddAsMember] HCERTSTORE hStore)
	{
		unsafe
		{
			var _pSelectionContext = pSelectionContext.GetValueOrDefault();
			var cpdef = pChainParameters.GetValueOrDefault();
			Win32Error.ThrowLastErrorIfFalse(CertSelectCertificateChains(pSelectionContext.HasValue ? &_pSelectionContext : null, dwFlags,
				pChainParameters.HasValue ? &cpdef : null, rgpCriteria?.Length ?? 0, rgpCriteria, hStore, out var cSelections, out var ppSelections));
			return new SafeCertificateChainList((IntPtr)ppSelections, cSelections);
		}

		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static unsafe extern bool CertSelectCertificateChains([In, Optional] Guid* pSelectionContext, CertSelection dwFlags,
			[In, Optional] CERT_SELECT_CHAIN_PARA* pChainParameters, int cCriteria,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] CERT_SELECT_CRITERIA[]? rgpCriteria, HCERTSTORE hStore,
			out uint pcSelection, out CERT_CHAIN_CONTEXT** pprgpSelection);
	}

	/// <summary>
	/// The <c>CertSerializeCertificateStoreElement</c> function serializes a certificate context's encoded certificate and its encoded
	/// properties. The result can be persisted to storage so that the certificate and properties can be retrieved at a later time.
	/// </summary>
	/// <param name="pCertContext">A pointer to the CERT_CONTEXT to be serialized.</param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <param name="pbElement">
	/// <para>A pointer to a buffer that receives the serialized output, including the encoded certificate and possibly its properties.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbElement">
	/// <para>
	/// A pointer to a <c>DWORD</c> value specifying the size, in bytes, of the buffer pointed to by the pbElement parameter. When the
	/// function returns, <c>DWORD</c> value contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to
	/// by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certserializecertificatestoreelement BOOL
	// CertSerializeCertificateStoreElement( PCCERT_CONTEXT pCertContext, DWORD dwFlags, BYTE *pbElement, DWORD *pcbElement );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "104fc986-6344-41b7-8843-23c3c72405a2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertSerializeCertificateStoreElement(PCCERT_CONTEXT pCertContext, [Optional, Ignore] uint dwFlags,
		[Out, Optional, SizeDef(nameof(pcbElement), SizingMethod.Query)] IntPtr pbElement, ref uint pcbElement);

	/// <summary>
	/// The <c>CertVerifySubjectCertificateContext</c> function performs the enabled verification checks on a certificate by checking
	/// the validity of the certificate's issuer. The new Certificate Chain Verification Functions are recommended instead of this function.
	/// </summary>
	/// <param name="pSubject">A pointer to a CERT_CONTEXT structure containing the subject's certificate.</param>
	/// <param name="pIssuer">
	/// A pointer to a CERT_CONTEXT containing the issuer's certificate. When checking just CERT_STORE_TIME_VALIDITY_FLAG, pIssuer can
	/// be <c>NULL</c>.
	/// </param>
	/// <param name="pdwFlags">
	/// <para>
	/// A pointer to a <c>DWORD</c> value contain verification check flags. The following flags can be set to enable verification checks
	/// on the subject certificate. They can be combined using a bitwise- <c>OR</c> operation to enable multiple verifications.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_REVOCATION_FLAG</term>
	/// <term>Checks whether the subject certificate is on the issuer's revocation list.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_SIGNATURE_FLAG</term>
	/// <term>Uses the public key in the issuer's certificate to verify the signature on the subject certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_TIME_VALIDITY_FLAG</term>
	/// <term>Gets the current time and verifies that it is within the subject certificate's validity period.</term>
	/// </item>
	/// </list>
	/// <para>If an enabled verification check succeeds, its flag is set to zero. If it fails, then its flag is set upon return.</para>
	/// <para>
	/// If CERT_STORE_REVOCATION_FLAG was enabled and the issuer does not have a CRL in the store, then CERT_STORE_NO_CRL_FLAG is set in
	/// addition to CERT_STORE_REVOCATION_FLAG.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>.</para>
	/// <para>
	/// For a verification check failure, <c>TRUE</c> is still returned. <c>FALSE</c> is returned only when a bad parameter is passed in.
	/// </para>
	/// <para>For extended error information, call GetLastError. One possible error code is the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// An unsupported bit was set in pdwFlags. Any combination of CERT_STORE_SIGNATURE_FLAG, CERT_STORE_TIME_VALIDITY_FLAG, and
	/// CERT_STORE_REVOCATION_FLAG can be set. If pIssuer is NULL, only CERT_STORE_TIME_VALIDITY_FLAG can be set.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The hexadecimal value of the flags can be combined using bitwise- <c>OR</c> operations to enable multiple verifications. For
	/// example, to enable both signature and time validity, the value
	/// </para>
	/// <para>
	/// is placed in the pdwFlags <c>DWORD</c> value as an input parameter. If CERT_STORE_SIGNATURE_FLAG verification succeeds, but
	/// CERT_STORE_TIME_VALIDITY_FLAG verification fails, pdwFlags is set to CERT_STORE_TIME_VALIDITY_FLAG when the function returns.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certverifysubjectcertificatecontext BOOL
	// CertVerifySubjectCertificateContext( PCCERT_CONTEXT pSubject, PCCERT_CONTEXT pIssuer, DWORD *pdwFlags );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "063b19cf-d3b3-4ec3-bfd3-9406eecd3e10")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertVerifySubjectCertificateContext(PCCERT_CONTEXT pSubject, PCCERT_CONTEXT pIssuer, ref CertStoreVerification pdwFlags);

	/// <summary>
	/// The <c>CERT_CHAIN_CONTEXT</c> structure contains an array of simple certificate chains and a trust status structure that
	/// indicates summary validity data on all of the connected simple chains.
	/// </summary>
	/// <remarks>
	/// When a <c>CERT_CHAIN_CONTEXT</c> is built, the first simple chain begins with an end certificate and ends with a self-signed
	/// certificate. If that self-signed certificate is not a root or otherwise trusted certificate, an attempt is made to build a new
	/// chain. CTLs are used to create the new chain beginning with the self-signed certificate from the original chain as the end
	/// certificate of the new chain. This process continues building additional simple chains until the first self-signed certificate
	/// is a trusted certificate or until an additional simple chain cannot be built.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_chain_context typedef struct _CERT_CHAIN_CONTEXT {
	// DWORD cbSize; CERT_TRUST_STATUS TrustStatus; DWORD cChain; PCERT_SIMPLE_CHAIN *rgpChain; DWORD cLowerQualityChainContext;
	// PCCERT_CHAIN_CONTEXT *rgpLowerQualityChainContext; BOOL fHasRevocationFreshnessTime; DWORD dwRevocationFreshnessTime; DWORD
	// dwCreateFlags; GUID ChainId; } CERT_CHAIN_CONTEXT, *PCERT_CHAIN_CONTEXT;
	[PInvokeData("wincrypt.h", MSDNShortId = "609311f4-9cd6-4945-9f93-7266b3fc4a74")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_CHAIN_CONTEXT
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// A structure that indicates the combined trust status of the simple chains array. The structure includes an error status code
		/// and an information status code. For information about status code values, see CERT_TRUST_STATUS.
		/// </summary>
		public CERT_TRUST_STATUS TrustStatus;

		/// <summary>The number of simple chains in the array.</summary>
		public uint cChain;

		/// <summary>
		/// An array of pointers to simple chain structures. <c>rgpChain</c>[0] is the end certificate simple chain, and
		/// <c>rgpChain</c>[ <c>cChain</c>–1] is the final chain. If the end certificate is to be considered valid, the final chain must
		/// begin with a certificate contained in the root store or an otherwise trusted, self-signed certificate. If the original chain
		/// begins with a trusted certificate, there will be only a single simple chain in the array.
		/// </summary>
		public ArrayPointer<StructPointer<CERT_SIMPLE_CHAIN>> rgpChain;

		/// <summary>The number of chains in the <c>rgpLowerQualityChainContext</c> array.</summary>
		public uint cLowerQualityChainContext;

		/// <summary>
		/// An array of pointers to CERT_CHAIN_CONTEXT structures. Returned when CERT_CHAIN_RETURN_LOWER_QUALITY_CONTEXTS is set in dwFlags.
		/// </summary>
		public ArrayPointer<StructPointer<CERT_CHAIN_CONTEXT>> rgpLowerQualityChainContext;

		/// <summary>A Boolean value set to <c>TRUE</c> if <c>dwRevocationFreshnessTime</c> is available.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fHasRevocationFreshnessTime;

		/// <summary>
		/// The largest CurrentTime, in seconds, minus the certificate revocation list's (CRL's) ThisUpdate of all elements checked.
		/// </summary>
		public uint dwRevocationFreshnessTime;

		/// <summary/>
		public uint dwCreateFlags;

		/// <summary/>
		public Guid ChainId;

		/// <summary>Gets the chain from <see cref="rgpChain"/>.</summary>
		public readonly unsafe CERT_SIMPLE_CHAIN*[] GetChain()
		{
			var ret = new CERT_SIMPLE_CHAIN*[(int)cChain];
			for (int i = 0; i < cChain; i++)
				ret[i] = ((CERT_SIMPLE_CHAIN**)(IntPtr)rgpChain)[i];
			return ret;
		}

		/// <summary>Gets the contexts from <see cref="rgpLowerQualityChainContext"/>.</summary>
		public readonly unsafe CERT_CHAIN_CONTEXT*[] GetLowerQualityChainContext()
		{
			var ret = new CERT_CHAIN_CONTEXT*[(int)cLowerQualityChainContext];
			for (int i = 0; i < cLowerQualityChainContext; i++)
				ret[i] = ((CERT_CHAIN_CONTEXT**)(IntPtr)rgpLowerQualityChainContext)[i];
			return ret;
		}
	}

	/// <summary>
	/// The <c>CERT_CHAIN_ELEMENT</c> structure is a single element in a simple certificate chain. Each element has a pointer to a
	/// certificate context, a pointer to a structure that indicates the error status and information status of the certificate, and a
	/// pointer to a structure that indicates the revocation status of the certificate.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_chain_element typedef struct _CERT_CHAIN_ELEMENT {
	// DWORD cbSize; PCCERT_CONTEXT pCertContext; CERT_TRUST_STATUS TrustStatus; PCERT_REVOCATION_INFO pRevocationInfo;
	// PCERT_ENHKEY_USAGE pIssuanceUsage; PCERT_ENHKEY_USAGE pApplicationUsage; LPCWSTR pwszExtendedErrorInfo; } CERT_CHAIN_ELEMENT, *PCERT_CHAIN_ELEMENT;
	[PInvokeData("wincrypt.h", MSDNShortId = "a1f6ba18-63ef-43ac-a17f-900fa13398aa")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_CHAIN_ELEMENT
	{
		/// <summary>Size of this structure in bytes.</summary>
		public uint cbSize;

		/// <summary>A pointer to a certificate context.</summary>
		public PCCERT_CONTEXT pCertContext;

		/// <summary>
		/// Structure indicating the status of the certificate. The structure includes an error status code and an information status
		/// code. For information about status code values, see CERT_TRUST_STATUS.
		/// </summary>
		public CERT_TRUST_STATUS TrustStatus;

		/// <summary>
		/// A pointer to a CERT_REVOCATION_INFO structure with information on the revocation status of the certificate. If revocation
		/// checking was not enabled, <c>pRevocationInfo</c> is <c>NULL</c>.
		/// </summary>
		public StructPointer<CERT_REVOCATION_INFO> pRevocationInfo;

		/// <summary>A pointer to a CERT_ENHKEY_USAGE structure. If <c>NULL</c>, any issuance policy is acceptable.</summary>
		public StructPointer<CTL_USAGE> pIssuanceUsage;

		/// <summary>A pointer to a CERT_ENHKEY_USAGE structure. If <c>NULL</c>, any enhanced key usage is acceptable.</summary>
		public StructPointer<CTL_USAGE> pApplicationUsage;

		/// <summary>
		/// A pointer to a <c>null</c>-terminated wide character string that contains extended error information. If <c>NULL</c>, there
		/// is no extended error information.
		/// </summary>
		public LPWSTR pwszExtendedErrorInfo;
	}

	/// <summary>
	/// Contains information updated by a certificate revocation list (CRL) revocation type handler. The <c>CERT_REVOCATION_CRL_INFO</c>
	/// structure is used with both base and delta CRLs.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_revocation_crl_info typedef struct
	// _CERT_REVOCATION_CRL_INFO { DWORD cbSize; PCCRL_CONTEXT pBaseCrlContext; PCCRL_CONTEXT pDeltaCrlContext; PCRL_ENTRY pCrlEntry;
	// BOOL fDeltaCrlEntry; } CERT_REVOCATION_CRL_INFO, *PCERT_REVOCATION_CRL_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "069ff521-90fd-4de8-9b5c-045e44e87f75")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_REVOCATION_CRL_INFO
	{
		/// <summary>Size, in bytes, of the structure.</summary>
		public uint cbSize;

		/// <summary/>
		public PCCRL_CONTEXT pBaseCrlContext;

		/// <summary/>
		public PCCRL_CONTEXT pDeltaCrlContext;

		/// <summary>A pointer to an entry in either the base CRL or the delta CRL.</summary>
		public IntPtr pCrlEntry;

		/// <summary>
		/// <c>TRUE</c> if <c>pCrlEntry</c> points to an entry in the delta CRL. <c>FALSE</c> if <c>pCrlEntry</c> points to an entry in
		/// the base CRL.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fDeltaCrlEntry;
	}

	/// <summary>The <c>CERT_REVOCATION_INFO</c> structure indicates the revocation status of a certificate in a CERT_CHAIN_ELEMENT.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_revocation_info typedef struct _CERT_REVOCATION_INFO
	// { DWORD cbSize; DWORD dwRevocationResult; LPCSTR pszRevocationOid; LPVOID pvOidSpecificInfo; BOOL fHasFreshnessTime; DWORD
	// dwFreshnessTime; PCERT_REVOCATION_CRL_INFO pCrlInfo; } CERT_REVOCATION_INFO, *PCERT_REVOCATION_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "798aa2d7-bf8a-425f-bc36-98a44ba3a9d6")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_REVOCATION_INFO
	{
		/// <summary>Size of this structure in bytes.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>Currently defined values are:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>CERT_TRUST_IS_REVOKED</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_REVOCATION_STATUS_IS_UNKNOWN</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwRevocationResult;

		/// <summary>Not currently used and is set to <c>NULL</c>.</summary>
		public LPSTR pszRevocationOid;

		/// <summary>Not currently used and is set to <c>NULL</c>.</summary>
		public IntPtr pvOidSpecificInfo;

		/// <summary>BOOL set to <c>TRUE</c> if dwFreshnessTime has been updated.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fHasFreshnessTime;

		/// <summary>
		/// If <c>fHasFreshnessTime</c> is <c>TRUE</c>, holds the CurrentTime minus the certificate revocation list's (CRL's). This time
		/// is in seconds.
		/// </summary>
		public uint dwFreshnessTime;

		/// <summary>For CRL base revocation checking, a non- <c>NULL</c> pointer to a CERT_REVOCATION_CRL_INFO structure.</summary>
		public StructPointer<CERT_REVOCATION_CRL_INFO> pCrlInfo;
	}

	/// <summary>
	/// The <c>CERT_SELECT_CHAIN_PARA</c> structure contains the parameters used for building and selecting chains. This structure is
	/// used by the CertGetCertificateChain and CertSelectCertificateChains functions.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Trust in a particular certificate being a trusted root is based on the current state of the root store and not the state of the
	/// root store at a time passed in by this parameter. For revocation, a certificate revocation list (CRL), itself, must be valid at
	/// the current time. The value of this parameter is used to determine whether a certificate listed in a CRL has been revoked.
	/// </para>
	/// <para>The following remarks apply to strong signature checking:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// You can enable strong signature checking by using the CERT_CHAIN_PARA structure referenced by the <c>pChainPara</c> member. The
	/// <c>pStrongSignPara</c> member of the <c>CERT_CHAIN_PARA</c> structure points to a CERT_STRONG_SIGN_PARA structure that can be
	/// used to determine signature strength.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// When you enable strong checking and a weak signature is encountered, the <c>CERT_TRUST_IS_NOT_SIGNATURE_VALID</c> and
	/// <c>CERT_TRUST_HAS_WEAK_SIGNATURE</c> errors are set in the <c>dwErrorStatus</c> field of the CERT_TRUST_STATUS structure.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_select_chain_para typedef struct
	// _CERT_SELECT_CHAIN_PARA { HCERTCHAINENGINE hChainEngine; PFILETIME pTime; HCERTSTORE hAdditionalStore; PCERT_CHAIN_PARA
	// pChainPara; DWORD dwFlags; } CERT_SELECT_CHAIN_PARA, *PCERT_SELECT_CHAIN_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "55c6c063-2a65-40ad-8d3f-7723b83cf021")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_SELECT_CHAIN_PARA
	{
		/// <summary>
		/// The handle of the chain engine to use to build the chain. If the value of the hChainEngine parameter is <c>NULL</c>, the
		/// default chain engine, <c>HCCE_CURRENT_USER</c>, is used.
		/// </summary>
		public HCERTCHAINENGINE hChainEngine;

		/// <summary>
		/// <para>
		/// A pointer to a FILETIME structure that contains the time for which the chain is to be validated. If the value of the pTime
		/// parameter is <c>NULL</c>, the current system time is passed to this parameter.
		/// </para>
		/// <para><c>Note</c> The time does not affect trust list, revocation, or root store checking.</para>
		/// </summary>
		public StructPointer<FILETIME> pTime;

		/// <summary>
		/// The handle of any additional store to search for supporting certificates and certificate trust lists (CTLs). This parameter
		/// can be <c>NULL</c> if no additional store is to be searched.
		/// </summary>
		public HCERTSTORE hAdditionalStore;

		/// <summary>A pointer to a CERT_CHAIN_PARA structure that includes chain-building parameters.</summary>
		public StructPointer<CERT_CHAIN_PARA> pChainPara;

		/// <summary>
		/// <para>Flag values that indicate special processing during chain build.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_CHAIN_REVOCATION_CHECK_CACHE_ONLY 0x00000004</term>
		/// <term>Revocation checking only accesses cached URLs.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_CACHE_ONLY_URL_RETRIEVAL 0x80000000</term>
		/// <term>Use only cached URLs in building a certificate chain. The Internet and intranet are not searched for URL-based objects.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CertChainFlags dwFlags;
	}

	/// <summary>
	/// The <c>CERT_SELECT_CRITERIA</c> structure specifies selection criteria that is passed to the CertSelectCertificateChains function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_select_criteria typedef struct _CERT_SELECT_CRITERIA
	// { DWORD dwType; DWORD cPara; void **ppPara; } CERT_SELECT_CRITERIA, *PCERT_SELECT_CRITERIA;
	[PInvokeData("wincrypt.h", MSDNShortId = "246722a9-5db6-4a82-8f29-f60f0a2263e3")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct CERT_SELECT_CRITERIA
	{
		/// <summary>
		/// <para>
		/// Specifies the type of selection criteria used for the <c>ppPara</c> member. This member can have one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_SELECT_BY_ENHKEY_USAGE 1</term>
		/// <term>
		/// Select certificates based on a specific enhanced key usage. When this flag is set, the ppPara must reference a
		/// null-terminated object identifier (OID) ANSI string that specifies the enhanced key usage. This criteria is evaluated on the certificate.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SELECT_BY_KEY_USAGE 2</term>
		/// <term>
		/// Select certificates based on a specific szOID_KEY_USAGE extension in the certificate. When this flag is set, the ppPara
		/// member must reference a CERT_EXTENSION structure where the value of the extension is a DWORD that identifies the Key Usage
		/// bits. This criteria is evaluated on the certificate.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SELECT_BY_POLICY_OID 3</term>
		/// <term>
		/// Select certificates based on a specific issuance policy. The ppPara member must reference a null-terminated OID ANSI string
		/// of the desired issuance policy. This criteria is evaluated on the issuance policy of the certificate chain.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SELECT_BY_PROV_NAME 4</term>
		/// <term>
		/// Select certificates based on a specific private key provider. The ppPara member must reference a null-terminated Unicode
		/// string that represents the name of the provider.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SELECT_BY_EXTENSION 5</term>
		/// <term>
		/// Select certificates based on the presence of a specified extension and an optional specified value. The ppPara member must
		/// reference a CERT_EXTENSION structure that specifies the extension OID and the associated value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SELECT_BY_SUBJECT_HOST_NAME 6</term>
		/// <term>
		/// Select certificates based on the Subject DNS HOST Name. The ppPara member must reference a null-terminated Unicode string
		/// that contains the subject host name. The selection performed based on this flag is the same as the evaluation of the
		/// pwszServerName member of the SSL_EXTRA_CERT_CHAIN_POLICY_PARA structure during a call to the
		/// CertVerifyCertificateChainPolicy function. This criteria is evaluated on the certificate.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SELECT_BY_ISSUER_ATTR 7</term>
		/// <term>
		/// Select certificates based on the relative distinguished name (RDN) element of the issuer of the certificate. The ppPara
		/// member must reference a CERT_RDN structure that contains the RDN element of the issuer. This criteria is evaluated on the
		/// certificate chain.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SELECT_BY_SUBJECT_ATTR 8</term>
		/// <term>
		/// Select certificates based on the RDN element in the Subject of the certificate. The ppPara member must be a reference to a
		/// CERT_RDN structure that contains the RDN element of the Subject. This criteria is evaluated on the certificate.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SELECT_BY_ISSUER_NAME 9</term>
		/// <term>
		/// Select certificates based on the issuer of the certificate. The ppPara member must be a reference to a CERT_NAME_BLOB
		/// structure that contains the name of the issuer. This criteria is evaluated on the certificate chain.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SELECT_BY_PUBLIC_KEY 10</term>
		/// <term>
		/// Select certificates based on the public key of the certificate. The ppPara member must reference a pointer to a
		/// CERT_PUBLIC_KEY_INFO structure that contains the public key. This criteria is evaluated on the certificate.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SELECT_BY_TLS_SIGNATURES 11</term>
		/// <term>
		/// Select certificates based on the Transport Layer Security protocol (TLS) Signature requirement. The ppPara member must
		/// reference a SecPkgContext_SupportedSignatures structure. This criteria is evaluated on the certificate.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CertSelectBy dwType;

		/// <summary>A <c>DWORD</c> value that specifies the number of search attributes specified in the <c>ppPara</c> member.</summary>
		public uint cPara;

		/// <summary>
		/// A pointer to a pointer to one or more selection values. The data type depends on the selection type specified by the
		/// <c>dwType</c> member. If more than one selection value is present, an application must match only one value.
		/// </summary>
		public IntPtr ppPara;
	}

	/// <summary>
	/// The <c>CERT_SIMPLE_CHAIN</c> structure contains an array of chain elements and a summary trust status for the chain that the
	/// array represents.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_simple_chain typedef struct _CERT_SIMPLE_CHAIN {
	// DWORD cbSize; CERT_TRUST_STATUS TrustStatus; DWORD cElement; PCERT_CHAIN_ELEMENT *rgpElement; PCERT_TRUST_LIST_INFO
	// pTrustListInfo; BOOL fHasRevocationFreshnessTime; DWORD dwRevocationFreshnessTime; } CERT_SIMPLE_CHAIN, *PCERT_SIMPLE_CHAIN;
	[PInvokeData("wincrypt.h", MSDNShortId = "c130cab4-bf8d-429a-beb7-04cb5d37d466")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_SIMPLE_CHAIN
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// A structure that indicates the trust status of the whole chain. The structure includes an error status code and an
		/// information status code. For information about status code values, see CERT_TRUST_STATUS.
		/// </summary>
		public CERT_TRUST_STATUS TrustStatus;

		/// <summary>The number of CERT_CHAIN_ELEMENT structures in the array.</summary>
		public uint cElement;

		/// <summary>
		/// An array of pointers to CERT_CHAIN_ELEMENT structures. <c>rgpElement</c>[0] is the end certificate chain element.
		/// <c>rgpElement</c>[ <c>cElement</c>–1] is the self-signed "root" certificate element.
		/// </summary>
		public ArrayPointer<StructPointer<CERT_CHAIN_ELEMENT>> rgpElement;

		/// <summary>
		/// A pointer to a CERT_TRUST_LIST_INFO structure that contains a pointer to a certificate trust list (CTL) connecting this
		/// chain to a next certificate chain. If the current chain is the final chain, <c>pTrustListInfo</c> is <c>NULL</c>.
		/// </summary>
		public StructPointer<CERT_TRUST_LIST_INFO> pTrustListInfo;

		/// <summary>BOOL. If <c>TRUE</c>, <c>dwRevocationFreshnessTime</c> has been calculated.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fHasRevocationFreshnessTime;

		/// <summary>
		/// The age of a certificate revocation list (CRL) in seconds, calculated as the CurrentTime minus the CRL's ThisUpdate time.
		/// This values is the largest time across all elements checked.
		/// </summary>
		public uint dwRevocationFreshnessTime;

		/// <summary>Gets the elements from <see cref="rgpElement"/>.</summary>
		public readonly unsafe CERT_CHAIN_ELEMENT*[] GetElements()
		{
			var ret = new CERT_CHAIN_ELEMENT*[(int)cElement];
			for (int i = 0; i < cElement; i++)
				ret[i] = ((CERT_CHAIN_ELEMENT**)(IntPtr)rgpElement)[i];
			return ret;
		}
	}

	/// <summary>The <c>CERT_TRUST_LIST_INFO</c> structure that indicates valid usage of a CTL.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_trust_list_info typedef struct _CERT_TRUST_LIST_INFO
	// { DWORD cbSize; PCTL_ENTRY pCtlEntry; PCCTL_CONTEXT pCtlContext; } CERT_TRUST_LIST_INFO, *PCERT_TRUST_LIST_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "774f5626-9b48-4585-b713-adbf191861cc")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_TRUST_LIST_INFO
	{
		/// <summary>Size of this structure in bytes.</summary>
		public uint cbSize;

		/// <summary>
		/// A pointer to a structure that includes a subject identifier, the count of attributes associated with a CTL, and an array of
		/// those attributes.
		/// </summary>
		public StructPointer<CTL_ENTRY> pCtlEntry;

		/// <summary>A pointer to a CTL context.</summary>
		public PCCTL_CONTEXT pCtlContext;
	}

	public partial class SafePCCERT_CONTEXT
	{
		/// <summary>Performs an explicit conversion from <see cref="SafePCCERT_CONTEXT"/> to <see cref="CERT_CONTEXT"/>.</summary>
		/// <param name="h">The h.</param>
		/// <returns>The resulting <see cref="CERT_CONTEXT"/> instance from the conversion.</returns>
		public static unsafe explicit operator CERT_CONTEXT*(SafePCCERT_CONTEXT h) => (CERT_CONTEXT*)(void*)h.handle;

		/// <summary>Extracts a reference to <see cref="CERT_CONTEXT"/> from the <see cref="SafePCCERT_CONTEXT"/> handle.</summary>
		/// <returns>The resulting <see cref="CERT_CONTEXT"/> reference.</returns>
		public ref CERT_CONTEXT AsRef() => ref handle.AsRef<CERT_CONTEXT>();
	}
}