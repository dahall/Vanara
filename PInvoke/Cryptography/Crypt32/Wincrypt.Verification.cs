namespace Vanara.PInvoke;

/// <summary>Methods and data types found in Crypt32.dll.</summary>
public static partial class Crypt32
{
	/// <summary>Flags used by <see cref="CERT_CHAIN_ENGINE_CONFIG"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "9e010eb9-2cbb-4fca-ba5c-4a5a50f23786")]
	[Flags]
	public enum CertChainEngineExclusiveFlags
	{
		/// <summary>
		/// Indicates that a non-self-signed intermediate CA certificate in the hExclusiveRoot store should be treated as a trust anchor
		/// during certificate validation. If a certificate chains up to this CA, chain building is terminated and the certificate is
		/// considered trusted. No signature verification or revocation checking is performed on the CA certificate.
		/// <para>
		/// By default, if this flag is not set, only self-signed certificates in the hExclusiveRoot store are treated as trust anchors.
		/// </para>
		/// <para>See also the CERT_TRUST_IS_CA_TRUSTED value in the CERT_TRUST_STATUS structure.</para>
		/// </summary>
		CERT_CHAIN_EXCLUSIVE_ENABLE_CA_FLAG = 0x00000001,
	}

	/// <summary>Flags used by <see cref="CERT_CHAIN_ENGINE_CONFIG"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "9e010eb9-2cbb-4fca-ba5c-4a5a50f23786")]
	[Flags]
	public enum CertChainEngineFlags
	{
		/// <summary>
		/// Information in the end certificate is cached. By default, information in all certificates except the end certificate is
		/// cached as a chain is built. Setting this flag extends the caching to the end certificate.
		/// </summary>
		CERT_CHAIN_CACHE_END_CERT = 0x00000001,

		/// <summary/>
		CERT_CHAIN_THREAD_STORE_SYNC = 0x00000002,

		/// <summary>
		/// Use only cached URLs in building a certificate chain. The Internet and intranet are not searched for URL-based objects.
		/// </summary>
		CERT_CHAIN_CACHE_ONLY_URL_RETRIEVAL = 0x00000004,

		/// <summary>Build the chain using the LocalMachine registry location as opposed to the CurrentUser location.</summary>
		CERT_CHAIN_USE_LOCAL_MACHINE_STORE = 0x00000008,

		/// <summary>Enable automatic updating of the cache as a chain is being built.</summary>
		CERT_CHAIN_ENABLE_CACHE_AUTO_UPDATE = 0x00000010,

		/// <summary>Allow certificate stores used to build the chain to be shared.</summary>
		CERT_CHAIN_ENABLE_SHARE_STORE = 0x00000020,

		/// <summary>Turn off Authority Information Access (AIA) retrievals explicitly.</summary>
		CERT_CHAIN_DISABLE_AIA = 0x00002000,
	}

	/// <summary>Flags used by <see cref="CertGetCertificateChain(HCERTCHAINENGINE, PCCERT_CONTEXT, in FILETIME, HCERTSTORE, in CERT_CHAIN_PARA, CertChainFlags, IntPtr, out SafePCCERT_CHAIN_CONTEXT)"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "8c93036c-0b93-40d4-b0e3-ba1f2fc72db1")]
	[Flags]
	public enum CertChainFlags : uint
	{
		/// <summary>
		/// When this flag is set, the end certificate is cached, which might speed up the chain-building process. By default, the end
		/// certificate is not cached, and it would need to be verified each time a chain is built for it.
		/// </summary>
		CERT_CHAIN_CACHE_END_CERT = 0x00000001,

		/// <summary>Revocation checking only accesses cached URLs.</summary>
		CERT_CHAIN_REVOCATION_CHECK_CACHE_ONLY = 0x80000000,

		/// <summary>
		/// This flag is used internally during chain building for an online certificate status protocol (OCSP) signer certificate to
		/// prevent cyclic revocation checks. During chain building, if the OCSP response is signed by an independent OCSP signer, then,
		/// in addition to the original chain build, there is a second chain built for the OCSP signer certificate itself. This flag is
		/// used during this second chain build to inhibit a recursive independent OCSP signer certificate. If the signer certificate
		/// contains the szOID_PKIX_OCSP_NOCHECK extension, revocation checking is skipped for the leaf signer certificate. Both OCSP
		/// and CRL checking are allowed.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		CERT_CHAIN_REVOCATION_CHECK_OCSP_CERT = 0x04000000,

		/// <summary>
		/// Uses only cached URLs in building a certificate chain. The Internet and intranet are not searched for URL-based objects.
		/// <para>
		/// Note This flag is not applicable to revocation checking. Set CERT_CHAIN_REVOCATION_CHECK_CACHE_ONLY to use only cached URLs
		/// for revocation checking.
		/// </para>
		/// </summary>
		CERT_CHAIN_CACHE_ONLY_URL_RETRIEVAL = 0x00000004,

		/// <summary>
		/// For performance reasons, the second pass of chain building only considers potential chain paths that have quality greater
		/// than or equal to the highest quality determined during the first pass. The first pass only considers valid signature,
		/// complete chain, and trusted roots to calculate chain quality. This flag can be set to disable this optimization and consider
		/// all potential chain paths during the second pass.
		/// </summary>
		CERT_CHAIN_DISABLE_PASS1_QUALITY_FILTERING = 0x00000040,

		/// <summary>This flag is not supported. Certificates in the "My" store are never considered for peer trust.</summary>
		CERT_CHAIN_DISABLE_MY_PEER_TRUST = 0x00000800,

		/// <summary>
		/// End entity certificates in the "TrustedPeople" store are trusted without performing any chain building. This function does
		/// not set the CERT_TRUST_IS_PARTIAL_CHAIN or CERT_TRUST_IS_UNTRUSTED_ROOT dwErrorStatus member bits of the ppChainContext
		/// parameter. Windows Server 2003 Windows XP : This flag is not supported.
		/// </summary>
		CERT_CHAIN_ENABLE_PEER_TRUST = 0x00000400,

		/// <summary>
		/// Setting this flag indicates the caller wishes to opt into weak signature checks.
		/// <para>This flag is available in the rollup update for each OS starting with Windows 7 and Windows Server 2008 R2.</para>
		/// </summary>
		CERT_CHAIN_OPT_IN_WEAK_SIGNATURE = 0x00010000,

		/// <summary>
		/// The default is to return only the highest quality chain path. Setting this flag will return the lower quality chains. These
		/// are returned in the cLowerQualityChainContext and rgpLowerQualityChainContext fields of the chain context.
		/// </summary>
		CERT_CHAIN_RETURN_LOWER_QUALITY_CONTEXTS = 0x00000080,

		/// <summary>Setting this flag inhibits the auto update of third-party roots from the Windows Update Web Server.</summary>
		CERT_CHAIN_DISABLE_AUTH_ROOT_AUTO_UPDATE = 0x00000100,

		/// <summary>
		/// When you set CERT_CHAIN_REVOCATION_ACCUMULATIVE_TIMEOUT and you also specify a value for the dwUrlRetrievalTimeout member of
		/// the CERT_CHAIN_PARA structure, the value you specify in dwUrlRetrievalTimeout represents the cumulative timeout across all
		/// revocation URL retrievals.
		/// <para>
		/// If you set CERT_CHAIN_REVOCATION_ACCUMULATIVE_TIMEOUT but do not specify a dwUrlRetrievalTimeout value, the maximum
		/// cumulative timeout is set, by default, to 20 seconds. Each URL tested will timeout after half of the remaining cumulative
		/// balance has passed. That is, the first URL times out after 10 seconds, the second after 5 seconds, the third after 2.5
		/// seconds and so on until a URL succeeds, 20 seconds has passed, or there are no more URLs to test.
		/// </para>
		/// <para>
		/// If you do not set CERT_CHAIN_REVOCATION_ACCUMULATIVE_TIMEOUT, each revocation URL in the chain is assigned a maximum timeout
		/// equal to the value specified in dwUrlRetrievalTimeout. If you do not specify a value for the dwUrlRetrievalTimeout member,
		/// each revocation URL is assigned a maximum default timeout of 15 seconds. If no URL succeeds, the maximum cumulative timeout
		/// value is 15 seconds multiplied by the number of URLs in the chain.
		/// </para>
		/// <para>You can set the default values by using Group Policy.</para>
		/// </summary>
		CERT_CHAIN_REVOCATION_ACCUMULATIVE_TIMEOUT = 0x08000000,

		/// <summary>
		/// When this flag is set, pTime is used as the time stamp time to determine whether the end certificate was time valid. Current
		/// time can also be used to determine whether the end certificate remains time valid. All other certification authority (CA)
		/// and root certificates in the chain are checked by using current time and not pTime.
		/// </summary>
		CERT_CHAIN_TIMESTAMP_TIME = 0x00000200,

		/// <summary>Setting this flag explicitly turns off Authority Information Access (AIA) retrievals.</summary>
		CERT_CHAIN_DISABLE_AIA = 0x00002000,

		/// <summary>Revocation checking is done on the end certificate and only the end certificate.</summary>
		CERT_CHAIN_REVOCATION_CHECK_END_CERT = 0x10000000,

		/// <summary>Revocation checking is done on all of the certificates in every chain.</summary>
		CERT_CHAIN_REVOCATION_CHECK_CHAIN = 0x20000000,

		/// <summary>Revocation checking is done on all certificates in all of the chains except the root certificate.</summary>
		CERT_CHAIN_REVOCATION_CHECK_CHAIN_EXCLUDE_ROOT = 0x40000000,
	}

	/// <summary>Flags used by <see cref="CERT_CHAIN_POLICY_PARA"/></summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "5e4fffcb-132b-42c0-81b2-9f866e274c32")]
	[Flags]
	public enum CertChainPolicyFlags : uint
	{
		/// <summary>Ignore not time valid errors.</summary>
		CERT_CHAIN_POLICY_IGNORE_NOT_TIME_VALID_FLAG = 0x00000001,

		/// <summary>Ignore certificate trust list (CTL) not time valid errors.</summary>
		CERT_CHAIN_POLICY_IGNORE_CTL_NOT_TIME_VALID_FLAG = 0x00000002,

		/// <summary>Ignore time nesting errors.</summary>
		CERT_CHAIN_POLICY_IGNORE_NOT_TIME_NESTED_FLAG = 0x00000004,

		/// <summary>Ignore basic constraint errors.</summary>
		CERT_CHAIN_POLICY_IGNORE_INVALID_BASIC_CONSTRAINTS_FLAG = 0x00000008,

		/// <summary>Ignore all time validity errors.</summary>
		CERT_CHAIN_POLICY_IGNORE_ALL_NOT_TIME_VALID_FLAGS = (CERT_CHAIN_POLICY_IGNORE_NOT_TIME_VALID_FLAG | CERT_CHAIN_POLICY_IGNORE_CTL_NOT_TIME_VALID_FLAG | CERT_CHAIN_POLICY_IGNORE_NOT_TIME_NESTED_FLAG),

		/// <summary>Allow untrusted roots.</summary>
		CERT_CHAIN_POLICY_ALLOW_UNKNOWN_CA_FLAG = 0x00000010,

		/// <summary>Ignore invalid usage errors.</summary>
		CERT_CHAIN_POLICY_IGNORE_WRONG_USAGE_FLAG = 0x00000020,

		/// <summary>Ignore invalid name errors.</summary>
		CERT_CHAIN_POLICY_IGNORE_INVALID_NAME_FLAG = 0x00000040,

		/// <summary>Ignore invalid policy errors.</summary>
		CERT_CHAIN_POLICY_IGNORE_INVALID_POLICY_FLAG = 0x00000080,

		/// <summary>Ignores errors in obtaining valid revocation information.</summary>
		CERT_CHAIN_POLICY_IGNORE_END_REV_UNKNOWN_FLAG = 0x00000100,

		/// <summary>Ignores errors in obtaining valid CTL revocation information.</summary>
		CERT_CHAIN_POLICY_IGNORE_CTL_SIGNER_REV_UNKNOWN_FLAG = 0x00000200,

		/// <summary>Ignores errors in obtaining valid certification authority (CA) revocation information.</summary>
		CERT_CHAIN_POLICY_IGNORE_CA_REV_UNKNOWN_FLAG = 0x00000400,

		/// <summary>Ignores errors in obtaining valid root revocation information.</summary>
		CERT_CHAIN_POLICY_IGNORE_ROOT_REV_UNKNOWN_FLAG = 0x00000800,

		/// <summary>Ignores errors in obtaining valid revocation information.</summary>
		CERT_CHAIN_POLICY_IGNORE_ALL_REV_UNKNOWN_FLAGS = (CERT_CHAIN_POLICY_IGNORE_END_REV_UNKNOWN_FLAG | CERT_CHAIN_POLICY_IGNORE_CTL_SIGNER_REV_UNKNOWN_FLAG | CERT_CHAIN_POLICY_IGNORE_CA_REV_UNKNOWN_FLAG | CERT_CHAIN_POLICY_IGNORE_ROOT_REV_UNKNOWN_FLAG),

		/// <summary>Allow untrusted test roots.</summary>
		CERT_CHAIN_POLICY_ALLOW_TESTROOT_FLAG = 0x00008000,

		/// <summary>Always trust test roots.</summary>
		CERT_CHAIN_POLICY_TRUST_TESTROOT_FLAG = 0x00004000,

		/// <summary>Ignore critical extension not supported errors.</summary>
		CERT_CHAIN_POLICY_IGNORE_NOT_SUPPORTED_CRITICAL_EXT_FLAG = 0x00002000,

		/// <summary>Ignore peer trusts.</summary>
		CERT_CHAIN_POLICY_IGNORE_PEER_TRUST_FLAG = 0x00001000,

		/// <summary/>
		CERT_CHAIN_POLICY_IGNORE_WEAK_SIGNATURE_FLAG = 0x08000000,

		/// <summary>Checks if the first certificate element is a CA.</summary>
		BASIC_CONSTRAINTS_CERT_CHAIN_POLICY_CA_FLAG = 0x80000000,

		/// <summary>Checks if the first certificate element is an end entity.</summary>
		BASIC_CONSTRAINTS_CERT_CHAIN_POLICY_END_ENTITY_FLAG = 0x40000000,

		/// <summary>Also check for the Microsoft test roots in addition to the Microsoft public root.</summary>
		MICROSOFT_ROOT_CERT_CHAIN_POLICY_ENABLE_TEST_ROOT_FLAG = 0x00010000,

		/// <summary/>
		MICROSOFT_ROOT_CERT_CHAIN_POLICY_CHECK_APPLICATION_ROOT_FLAG = 0x00020000,

		/// <summary/>
		MICROSOFT_ROOT_CERT_CHAIN_POLICY_DISABLE_FLIGHT_ROOT_FLAG = 0x00040000,
	}

	/// <summary>Optional flags that modify chain retrieval behavior.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "86094e1c-be59-4a15-a05b-21769f80e653")]
	[Flags]
	public enum CertChainStrongSignFlags
	{
		/// <summary>
		/// If the chain is strong signed, the public key in the end certificate will be checked to verify whether it satisfies the
		/// minimum public key length requirements for a strong signature. You can specify CERT_CHAIN_STRONG_SIGN_DISABLE_END_CHECK_FLAG
		/// to disable default checking.
		/// </summary>
		CERT_CHAIN_STRONG_SIGN_DISABLE_END_CHECK_FLAG = 0x00000001,
	}

	/// <summary>Flags used by <see cref="CertCreateCTLEntryFromCertificateContextProperties"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "90ac512f-3cbe-4543-9b34-8e384f730cfe")]
	[Flags]
	public enum CertCreateCTLEntryFlags
	{
		/// <summary>Force the inclusion of the chain building hash properties as attributes.</summary>
		CTL_ENTRY_FROM_PROP_CHAIN_FLAG = 1
	}

	/// <summary>Flags for CertVerifyCTLUsage.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "d87d8157-8e52-4198-bfd4-46d83d72eb13")]
	[Flags]
	public enum CertVerifyCTLFlags
	{
		/// <summary>
		/// If the CERT_VERIFY_INHIBIT_CTL_UPDATE_FLAG is not set, a CTL whose time is no longer valid in one of the stores specified by
		/// rghCtlStore in CTL_VERIFY_USAGE_PARA can be replaced. When replaced, the CERT_VERIFY_UPDATED_CTL_FLAG is set in the dwFlags
		/// member of pVerifyUsageStatus. If this flag is set, an update will not be made, even if a time-valid, updated CTL is received
		/// for a CTL that is in the store and whose time is no longer valid.
		/// </summary>
		CERT_VERIFY_INHIBIT_CTL_UPDATE_FLAG = 0x1,

		/// <summary>
		/// If the CERT_VERIFY_TRUSTED_SIGNERS_FLAG is set, only the signer stores specified by rghSignerStore in CTL_VERIFY_USAGE_PARA
		/// are searched to find the signer. Otherwise, the signer stores provide additional sources to find the signer's certificate.
		/// </summary>
		CERT_VERIFY_TRUSTED_SIGNERS_FLAG = 0x2,

		/// <summary>If CERT_VERIFY_NO_TIME_CHECK_FLAG is set, the CTLs are not checked for time validity. Otherwise, they are.</summary>
		CERT_VERIFY_NO_TIME_CHECK_FLAG = 0x4,

		/// <summary>
		/// If CERT_VERIFY_ALLOW_MORE_USAGE_FLAG is set, the CTL can contain usage identifiers in addition to those specified by
		/// pSubjectUsage. Otherwise, the found CTL will contain no additional usage identifiers.
		/// </summary>
		CERT_VERIFY_ALLOW_MORE_USAGE_FLAG = 0x8,
	}

	/// <summary>Flags used by <see cref="CryptMsgEncodeAndSignCTL"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "5c0e9e2e-a50d-45d0-b51d-065784d1d912")]
	[Flags]
	public enum CryptMsgEncodeFlags
	{
		/// <summary>
		/// Set if the CTL entries are to be sorted before encoding. This flag is set if the CertFindSubjectInSortedCTL or
		/// CertEnumSubjectInSortedCTL functions will be called.
		/// </summary>
		CMSG_ENCODE_SORTED_CTL_FLAG = 0x1,

		/// <summary>
		/// Set if CMSG_ENCODE_SORTED_CTL_FLAG is set, and the identifier for the TrustedSubjects is a hash, such as MD5 or SHA1.
		/// </summary>
		CMSG_ENCODE_HASHED_SUBJECT_IDENTIFIER_FLAG = 0x2,
	}

	/// <summary>Flags for <see cref="CryptMsgGetAndVerifySigner"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "380c9cf3-27a2-4354-b1c8-97cec33f4e44")]
	[Flags]
	public enum CryptMsgSignerFlags
	{
		/// <summary>
		/// The stores in rghSignerStore are assumed trusted and they are the only stores searched to find the certificate corresponding
		/// to the signer's issuer and serial number. Otherwise, signer stores can be provided to supplement the message's store of
		/// certificates. If a signer certificate is found, its public key is used to verify the message signature.
		/// </summary>
		CMSG_TRUSTED_SIGNER_FLAG = 0x1,

		/// <summary>Return the signer without doing the signature verification.</summary>
		CMSG_SIGNER_ONLY_FLAG = 0x2,

		/// <summary>
		/// Only the signer specified by *pdwSignerIndex is returned. Otherwise, iterate through all the signers until a signature is
		/// verified or there are no more signers.
		/// </summary>
		CMSG_USE_SIGNER_INDEX_FLAG = 0x4,
	}

	/// <summary>Flags for <see cref="CryptMsgSignCTL"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "85ae8ce3-d0a7-4fcb-beaa-ede09d30930e")]
	[Flags]
	public enum CryptMsgSignFlags
	{
		/// <summary>
		/// If CMS_PKCS7 is defined, can be set to CMSG_CMS_ENCAPSULATED_CTL_FLAG to encode a CMS compatible V3 SignedData message.
		/// </summary>
		CMSG_CMS_ENCAPSULATED_CTL_FLAG = 0x00008000
	}

	/// <summary>Flags returned in CTL_VERIFY_USAGE_STATUS.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "2b7ef953-9422-4dcf-b293-a78a06bb080e")]
	[Flags]
	public enum CtlVerifyUsageStatusFlags
	{
		/// <summary>CertVerifyCTLUsage updated a CTL whose time was no longer valid with a new, time-valid CTL.</summary>
		CERT_VERIFY_UPDATED_CTL_FLAG = 0x1
	}

	/// <summary>
	/// Determines the kind of issuer matching to be done. In <c>AND</c> logic, the certificate must meet all criteria. In <c>OR</c>
	/// logic, the certificate must meet at least one of the criteria.
	/// </summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "6154f1f7-4293-4b8e-91ab-9f57bb6f5743")]
	public enum UsageMatchType
	{
		/// <summary>AND logic</summary>
		USAGE_MATCH_TYPE_AND = 0x00000000,

		/// <summary>OR logic</summary>
		USAGE_MATCH_TYPE_OR = 0x00000001,
	}

	/// <summary>
	/// The <c>CertCreateCertificateChainEngine</c> function creates a new, nondefault chain engine for an application. A chain engine
	/// restricts the certificates in the root store that can be used for verification, restricts the certificate stores to be searched
	/// for certificates and certificate trust lists (CTLs), sets a time-out limit for searches that involve URLs, and limits the number
	/// of certificates checked between checking for a certificate cycle.
	/// </summary>
	/// <param name="pConfig">A pointer to a CERT_CHAIN_ENGINE_CONFIG data structure that specifies the parameters for the chain engine.</param>
	/// <param name="phChainEngine">
	/// A pointer to the handle of the chain engine created. When you have finished using the chain engine, release the chain engine by
	/// calling the CertFreeCertificateChainEngine function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The phChainEngine parameter returns the chain engine handle.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcreatecertificatechainengine BOOL
	// CertCreateCertificateChainEngine( PCERT_CHAIN_ENGINE_CONFIG pConfig, HCERTCHAINENGINE *phChainEngine );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e173016a-d3d7-42e0-aad8-e738abaf1df9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertCreateCertificateChainEngine(in CERT_CHAIN_ENGINE_CONFIG pConfig, out SafeHCERTCHAINENGINE phChainEngine);

	/// <summary>
	/// <para>
	/// The <c>CertCreateCTLEntryFromCertificateContextProperties</c> function creates a certificate trust list (CTL) entry whose
	/// attributes are the properties of the certificate context. The SubjectIdentifier in the CTL entry is the SHA1 hash of the certificate.
	/// </para>
	/// <para>
	/// The certificate properties are added as attributes. The property attribute OID is the decimal PROP_ID preceded by
	/// szOID_CERT_PROP_ID_PREFIX. Each property value is copied as a single attribute value.
	/// </para>
	/// <para>Additional attributes can be included in the CTL entry by using the cOptAttr and rgOptAttr parameters.</para>
	/// </summary>
	/// <param name="pCertContext">A pointer to the CERT_CONTEXT used to create the CTL.</param>
	/// <param name="cOptAttr">A <c>DWORD</c> that specifies the number of additional attributes to be added.</param>
	/// <param name="rgOptAttr">A pointer to any array of CRYPT_ATTRIBUTE attributes to be added to the CTL.</param>
	/// <param name="dwFlags">
	/// A <c>DWORD</c>. Can be set to CTL_ENTRY_FROM_PROP_CHAIN_FLAG to force the inclusion of the chain building hash properties as attributes.
	/// </param>
	/// <param name="pvReserved">A pointer to a <c>VOID</c>. Reserved for future use.</param>
	/// <param name="pCtlEntry">
	/// Address of a pointer to a CTL_ENTRY structure. Call this function twice to retrieve a CTL entry. Set this parameter to
	/// <c>NULL</c> on the first call. When the function returns, use the number of bytes retrieved from the pcbCtlEntry parameter to
	/// allocate memory. Call the function again, setting this parameter to the address of the allocated memory.
	/// </param>
	/// <param name="pcbCtlEntry">
	/// Pointer to a <c>DWORD</c> that contains the number of bytes that must be allocated for the CTL_ENTRY structure. Call this
	/// function twice to retrieve the number of bytes. For the first call, set this parameter to the address of a <c>DWORD</c> value
	/// that contains zero and set the pCtlEntry parameter to <c>NULL</c>. If the first call succeeds, the <c>DWORD</c> value will
	/// contain the number of bytes that you must allocate for the <c>CTL_ENTRY</c> structure. Allocate the required memory and call the
	/// function again, supplying the address of the memory in the pCtlEntry parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcreatectlentryfromcertificatecontextproperties BOOL
	// CertCreateCTLEntryFromCertificateContextProperties( PCCERT_CONTEXT pCertContext, DWORD cOptAttr, PCRYPT_ATTRIBUTE rgOptAttr,
	// DWORD dwFlags, void *pvReserved, PCTL_ENTRY pCtlEntry, DWORD *pcbCtlEntry );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "90ac512f-3cbe-4543-9b34-8e384f730cfe")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertCreateCTLEntryFromCertificateContextProperties([In] PCCERT_CONTEXT pCertContext, uint cOptAttr, [In, MarshalAs(UnmanagedType.LPArray)] CRYPT_ATTRIBUTE[] rgOptAttr,
		CertCreateCTLEntryFlags dwFlags, [Optional] IntPtr pvReserved, [Out, Optional] IntPtr pCtlEntry, ref uint pcbCtlEntry);

	/// <summary>
	/// The <c>CertDuplicateCertificateChain</c> function duplicates a pointer to a certificate chain by incrementing the chain's
	/// reference count.
	/// </summary>
	/// <param name="pChainContext">A pointer to a CERT_CHAIN_CONTEXT chain context to be duplicated.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, a pointer is returned to the chain context. This pointer has the same value as the pChainContext
	/// passed into the function. When you have finished using the chain context, release the chain context by calling the
	/// CertFreeCertificateChain function.
	/// </para>
	/// <para>If the function fails, <c>NULL</c> is returned.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certduplicatecertificatechain PCCERT_CHAIN_CONTEXT
	// CertDuplicateCertificateChain( PCCERT_CHAIN_CONTEXT pChainContext );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "fea72a3e-5a22-47c7-8f6e-0d76fc3339f8")]
	public static extern PCCERT_CHAIN_CONTEXT CertDuplicateCertificateChain(PCCERT_CHAIN_CONTEXT pChainContext);

	/// <summary>
	/// The <c>CertFindChainInStore</c> function finds the first or next certificate in a store that meets the specified criteria. It
	/// then builds and verifies a certificate chain context for that certificate. The certificate that is found and for which the chain
	/// is built is selected according to criteria established by the dwFindFlags, dwFindType, and pvFindPara parameters. This function
	/// can be used in a loop to find all of the certificates in a certificate store that match the specified find criteria and to build
	/// a certificate chain context for each certificate found.
	/// </summary>
	/// <param name="hCertStore">
	/// The handle of the store to be searched for a certificate upon which a chain is built. This handle is passed as an additional
	/// store to the CertGetCertificateChain function as the chain is built.
	/// </param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// The certificate encoding type that was used to encode the store. The message encoding type identifier, contained in the high
	/// <c>WORD</c> of this value, is ignored by this function.
	/// </para>
	/// <para>This parameter can be the following currently defined certificate encoding type.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>X509_ASN_ENCODING 1 (0x1)</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFindFlags">
	/// <para>
	/// Contains additional options for the search. The possible values for this parameter depend on the value of the dwFindType parameter.
	/// </para>
	/// <para>This parameter can contain zero or a combination of one or more of the following values when dwFindType contains <c>CERT_CHAIN_FIND_BY_ISSUER</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_CHAIN_FIND_BY_ISSUER_COMPARE_KEY_FLAG</term>
	/// <term>
	/// Compares the public key in the certificate with the cryptographic service provider's public key. This comparison is the last
	/// check made on the chain when it is built. Because the hCryptProv member of an issuer contains a private key, it might need to be
	/// checked several times during this process; to facilitate this checking, the dwAcquirePrivateKeyFlags member can be set in the
	/// CERT_CHAIN_FIND_BY_ISSUER_PARA structure to enable caching of that hCryptProv.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_FIND_BY_ISSUER_COMPLEX_CHAIN_FLAG</term>
	/// <term>
	/// By default, only the first simple chain is checked for issuer name matches. With this flag set, the default is overridden and
	/// subsequent simple chains are also checked for issuer name matches.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_FIND_BY_ISSUER_CACHE_ONLY_FLAG</term>
	/// <term>
	/// Improves the performance of this function by causing it to search only the cached system stores (Root, My, Ca, Trust) to find
	/// issuer certificates. If this flag is not set, the function searches the cached system stores and the store represented by the
	/// hCertStore parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_FIND_BY_ISSUER_CACHE_ONLY_URL_FLAG</term>
	/// <term>Only the URL cache is searched. The Internet is not searched.</term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_FIND_BY_ISSUER_LOCAL_MACHINE_FLAG</term>
	/// <term>Only opens the Local Machine certificate stores. The certificate stores of the current user are not opened.</term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_FIND_BY_ISSUER_NO_KEY_FLAG</term>
	/// <term>No check is made to determine whether the certificate has an associated private key.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFindType">
	/// <para>Determines what criteria to use to find a certificate in the store.</para>
	/// <para>This parameter can be the following currently defined value.</para>
	/// <para>CERT_CHAIN_FIND_BY_ISSUER</para>
	/// <para>
	/// Finds the certificate based on the name of the issuer. The pvFindPara parameter is a pointer to a CERT_CHAIN_FIND_BY_ISSUER_PARA
	/// structure that contains members that modify the search.
	/// </para>
	/// <para>
	/// The certificate chain is built for a certificate with an available private key. By default, only the issuers in the first simple
	/// chain are compared in an issuer name match. If this flag is set, all of the chains are checked for an issuer certificate that
	/// matches one of a set of issuer names.
	/// </para>
	/// <para>
	/// This function will compare the name BLOBs passed in the pvFindPara structure to any certification authority (CA) in the chain,
	/// not just the certification authority in the root certificate.
	/// </para>
	/// <para>This function does not perform any revocation checks.</para>
	/// <para>
	/// If pPrevChainContext is not <c>NULL</c>, this function will return a chain for a different certificate every time the function
	/// is called. If there is only one suitable certificate, but there are two matching issuing certificate authorities, one of which
	/// is revoked, it is possible for this function to return the revoked chain. If the application then checks for revocation itself
	/// through calls to the CertVerifyRevocation function and finds the chain unsuitable, an additional call to the
	/// <c>CertFindChainInStore</c> function will not return a chain that includes the same certificate from the valid certification
	/// authority. It will instead return a completely different chain with a different certificate or <c>NULL</c>, if no such chain can
	/// be found.
	/// </para>
	/// </param>
	/// <param name="pvFindPara">
	/// A pointer that contains additional search criteria. The type and format of the data this parameter points to depends on the
	/// value of the dwFindType parameter.
	/// </param>
	/// <param name="pPrevChainContext">
	/// A pointer to a CERT_CHAIN_CONTEXT structure returned from a previous call to this function. The search is begun from this
	/// certificate. For the first call to this function, this parameter must be <c>NULL</c>. In subsequent calls, it is the pointer
	/// returned by the previous call to the function. If this parameter is not <c>NULL</c>, this function will free this structure.
	/// </param>
	/// <returns>
	/// If the first or next chain context is not built, <c>NULL</c> is returned. Otherwise, a pointer to a read-only CERT_CHAIN_CONTEXT
	/// structure is returned. The <c>CERT_CHAIN_CONTEXT</c> structure is freed when passed as the pPrevChainContext parameter on a
	/// subsequent call to this function. Otherwise, the <c>CERT_CHAIN_CONTEXT</c> structure must be freed explicitly by calling the
	/// CertFreeCertificateChain function.
	/// </returns>
	/// <remarks>
	/// The pPrevChainContext parameter must be <c>NULL</c> on the first call to build the chain context. To build the next chain
	/// context, the pPrevChainContext is set to the CERT_CHAIN_CONTEXT structure returned by a previous call. If pPrevChainContext is
	/// not <c>NULL</c>, the structure is always freed by this function by using the CertFreeCertificateChain function, even if an error occurs.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfindchaininstore PCCERT_CHAIN_CONTEXT
	// CertFindChainInStore( HCERTSTORE hCertStore, DWORD dwCertEncodingType, DWORD dwFindFlags, DWORD dwFindType, const void
	// *pvFindPara, PCCERT_CHAIN_CONTEXT pPrevChainContext );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "698cece8-71a8-4bfa-8ee6-8035a6dcbe05")]
	public static extern SafePCCERT_CHAIN_CONTEXT CertFindChainInStore(HCERTSTORE hCertStore, uint dwCertEncodingType, uint dwFindFlags, uint dwFindType, IntPtr pvFindPara, PCCERT_CHAIN_CONTEXT pPrevChainContext);

	/// <summary>
	/// <para>
	/// The <c>CertFreeCertificateChain</c> function frees a certificate chain by reducing its reference count. If the reference count
	/// becomes zero, memory allocated for the chain is released.
	/// </para>
	/// <para>
	/// To free a context obtained by a get, duplicate, or create function, call the appropriate free function. To free a context
	/// obtained by a find or enumerate function, either pass it in as the previous context parameter to a subsequent invocation of the
	/// function, or call the appropriate free function. For more information, see the reference topic for the function that obtains the context.
	/// </para>
	/// </summary>
	/// <param name="pChainContext">
	/// A pointer to a CERT_CHAIN_CONTEXT certificate chain context to be freed. If the reference count on the context reaches zero, the
	/// storage allocated for the context is freed.
	/// </param>
	/// <returns>This function does not return a value.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfreecertificatechain void CertFreeCertificateChain(
	// PCCERT_CHAIN_CONTEXT pChainContext );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "5ba181c2-6936-4848-a571-2bb58f46f081")]
	public static extern void CertFreeCertificateChain(PCCERT_CHAIN_CONTEXT pChainContext);

	/// <summary>The <c>CertFreeCertificateChainEngine</c> function frees a certificate trust engine.</summary>
	/// <param name="hChainEngine">Handle of the chain engine to be freed.</param>
	/// <returns>This function does not return a value.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfreecertificatechainengine void
	// CertFreeCertificateChainEngine( HCERTCHAINENGINE hChainEngine );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "5aebc09d-342d-4938-8a1a-0cbfdc147bb5")]
	public static extern void CertFreeCertificateChainEngine(HCERTCHAINENGINE hChainEngine);

	/// <summary>The <c>CertFreeCertificateChainList</c> function frees the array of pointers to chain contexts.</summary>
	/// <param name="prgpSelection">A pointer to a PCCERT_CHAIN_CONTEXT structure returned by the CertSelectCertificateChains function.</param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// Before calling the <c>CertFreeCertificateChainList</c> function, you must call the CertFreeCertificateChain function on each
	/// chain context within the array pointed to by the prgpSelection parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfreecertificatechainlist void
	// CertFreeCertificateChainList( PCCERT_CHAIN_CONTEXT *prgpSelection );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "a53b02ca-bc3f-43fd-8c90-2f646d550182")]
	public static extern void CertFreeCertificateChainList(in IntPtr prgpSelection);

	/// <summary>
	/// The <c>CertGetCertificateChain</c> function builds a certificate chain context starting from an end certificate and going back,
	/// if possible, to a trusted root certificate.
	/// </summary>
	/// <param name="hChainEngine">
	/// A handle of the chain engine (namespace and cache) to be used. If hChainEngine is <c>NULL</c>, the default chain engine,
	/// HCCE_CURRENT_USER, is used. This parameter can be set to HCCE_LOCAL_MACHINE.
	/// </param>
	/// <param name="pCertContext">
	/// A pointer to the CERT_CONTEXT of the end certificate, the certificate for which a chain is being built. This certificate context
	/// will be the zero-index element in the first simple chain.
	/// </param>
	/// <param name="pTime">
	/// A pointer to a FILETIME variable that indicates the time for which the chain is to be validated. Note that the time does not
	/// affect trust list, revocation, or root store checking. The current system time is used if <c>NULL</c> is passed to this
	/// parameter. Trust in a particular certificate being a trusted root is based on the current state of the root store and not the
	/// state of the root store at a time passed in by this parameter. For revocation, a certificate revocation list (CRL), itself, must
	/// be valid at the current time. The value of this parameter is used to determine whether a certificate listed in a CRL has been revoked.
	/// </param>
	/// <param name="hAdditionalStore">
	/// A handle to any additional store to search for supporting certificates and certificate trust lists (CTLs). This parameter can be
	/// <c>NULL</c> if no additional store is to be searched.
	/// </param>
	/// <param name="pChainPara">A pointer to a CERT_CHAIN_PARA structure that includes chain-building parameters.</param>
	/// <param name="dwFlags">
	/// <para>Flag values that indicate special processing. This parameter can be a combination of one or more of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_CHAIN_CACHE_END_CERT 0x00000001</term>
	/// <term>
	/// When this flag is set, the end certificate is cached, which might speed up the chain-building process. By default, the end
	/// certificate is not cached, and it would need to be verified each time a chain is built for it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_REVOCATION_CHECK_CACHE_ONLY 0x80000000</term>
	/// <term>Revocation checking only accesses cached URLs.</term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_REVOCATION_CHECK_OCSP_CERT 0x04000000</term>
	/// <term>
	/// This flag is used internally during chain building for an online certificate status protocol (OCSP) signer certificate to
	/// prevent cyclic revocation checks. During chain building, if the OCSP response is signed by an independent OCSP signer, then, in
	/// addition to the original chain build, there is a second chain built for the OCSP signer certificate itself. This flag is used
	/// during this second chain build to inhibit a recursive independent OCSP signer certificate. If the signer certificate contains
	/// the szOID_PKIX_OCSP_NOCHECK extension, revocation checking is skipped for the leaf signer certificate. Both OCSP and CRL
	/// checking are allowed. Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_CACHE_ONLY_URL_RETRIEVAL 0x00000004</term>
	/// <term>
	/// Uses only cached URLs in building a certificate chain. The Internet and intranet are not searched for URL-based objects. Note
	/// This flag is not applicable to revocation checking. Set CERT_CHAIN_REVOCATION_CHECK_CACHE_ONLY to use only cached URLs for
	/// revocation checking.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_DISABLE_PASS1_QUALITY_FILTERING 0x00000040</term>
	/// <term>
	/// For performance reasons, the second pass of chain building only considers potential chain paths that have quality greater than
	/// or equal to the highest quality determined during the first pass. The first pass only considers valid signature, complete chain,
	/// and trusted roots to calculate chain quality. This flag can be set to disable this optimization and consider all potential chain
	/// paths during the second pass.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_DISABLE_MY_PEER_TRUST 0x00000800</term>
	/// <term>This flag is not supported. Certificates in the "My" store are never considered for peer trust.</term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_ENABLE_PEER_TRUST 0x00000400</term>
	/// <term>
	/// End entity certificates in the "TrustedPeople" store are trusted without performing any chain building. This function does not
	/// set the CERT_TRUST_IS_PARTIAL_CHAIN or CERT_TRUST_IS_UNTRUSTED_ROOT dwErrorStatus member bits of the ppChainContext parameter.
	/// Windows Server 2003 Windows XP : This flag is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_OPT_IN_WEAK_SIGNATURE 0x00010000</term>
	/// <term>
	/// Setting this flag indicates the caller wishes to opt into weak signature checks. This flag is available in the rollup update for
	/// each OS starting with Windows 7 and Windows Server 2008 R2.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_RETURN_LOWER_QUALITY_CONTEXTS 0x00000080</term>
	/// <term>
	/// The default is to return only the highest quality chain path. Setting this flag will return the lower quality chains. These are
	/// returned in the cLowerQualityChainContext and rgpLowerQualityChainContext fields of the chain context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_DISABLE_AUTH_ROOT_AUTO_UPDATE 0x00000100</term>
	/// <term>Setting this flag inhibits the auto update of third-party roots from the Windows Update Web Server.</term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_REVOCATION_ACCUMULATIVE_TIMEOUT 0x08000000</term>
	/// <term>
	/// When you set CERT_CHAIN_REVOCATION_ACCUMULATIVE_TIMEOUT and you also specify a value for the dwUrlRetrievalTimeout member of the
	/// CERT_CHAIN_PARA structure, the value you specify in dwUrlRetrievalTimeout represents the cumulative timeout across all
	/// revocation URL retrievals. If you set CERT_CHAIN_REVOCATION_ACCUMULATIVE_TIMEOUT but do not specify a dwUrlRetrievalTimeout
	/// value, the maximum cumulative timeout is set, by default, to 20 seconds. Each URL tested will timeout after half of the
	/// remaining cumulative balance has passed. That is, the first URL times out after 10 seconds, the second after 5 seconds, the
	/// third after 2.5 seconds and so on until a URL succeeds, 20 seconds has passed, or there are no more URLs to test. If you do not
	/// set CERT_CHAIN_REVOCATION_ACCUMULATIVE_TIMEOUT, each revocation URL in the chain is assigned a maximum timeout equal to the
	/// value specified in dwUrlRetrievalTimeout. If you do not specify a value for the dwUrlRetrievalTimeout member, each revocation
	/// URL is assigned a maximum default timeout of 15 seconds. If no URL succeeds, the maximum cumulative timeout value is 15 seconds
	/// multiplied by the number of URLs in the chain. You can set the default values by using Group Policy.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_TIMESTAMP_TIME 0x00000200</term>
	/// <term>
	/// When this flag is set, pTime is used as the time stamp time to determine whether the end certificate was time valid. Current
	/// time can also be used to determine whether the end certificate remains time valid. All other certification authority (CA) and
	/// root certificates in the chain are checked by using current time and not pTime.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_DISABLE_AIA 0x00002000</term>
	/// <term>Setting this flag explicitly turns off Authority Information Access (AIA) retrievals.</term>
	/// </item>
	/// </list>
	/// <para>You can also set the following revocation flags, but only one flag from this group may be set at a time.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_CHAIN_REVOCATION_CHECK_END_CERT 0x10000000</term>
	/// <term>Revocation checking is done on the end certificate and only the end certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_REVOCATION_CHECK_CHAIN 0x20000000</term>
	/// <term>Revocation checking is done on all of the certificates in every chain.</term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_REVOCATION_CHECK_CHAIN_EXCLUDE_ROOT 0x40000000</term>
	/// <term>Revocation checking is done on all certificates in all of the chains except the root certificate.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvReserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="ppChainContext">
	/// The address of a pointer to the chain context created. When you have finished using the chain context, release the chain by
	/// calling the CertFreeCertificateChain function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When an application requests a certificate chain, the structure returned is in the form of a CERT_CHAIN_CONTEXT. This context
	/// contains an array of CERT_SIMPLE_CHAIN structures where each simple chain goes from an end certificate to a self-signed
	/// certificate. The chain context connects simple chains through trust lists. Each simple chain contains the chain of certificates,
	/// summary trust information about the chain, and trust information about each certificate element in the chain.
	/// </para>
	/// <para>The following remarks apply to strong signature checking:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// You can enable strong signature checking for this function by setting the <c>pStrongSignPara</c> member of the CERT_CHAIN_PARA
	/// structure that is pointed to by the pChainPara parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If a certificate without a strong signature is found in the chain, the <c>CERT_TRUST_HAS_WEAK_SIGNATURE</c> and
	/// <c>CERT_TRUST_IS_NOT_SIGNATURE_VALID</c> errors are set in the <c>dwErrorStatus</c> field of the CERT_TRUST_STATUS structure.
	/// The ppChainContext parameter points to a CERT_CHAIN_CONTEXT structure which, in turn, points to the <c>CERT_TRUST_STATUS</c> structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the chain is strong signed, the public key in the end certificate is checked to determine whether it satisfies the minimum
	/// public key length requirements for a strong signature. If the condition is not satisfied, the
	/// <c>CERT_TRUST_HAS_WEAK_SIGNATURE</c> and <c>CERT_TRUST_IS_NOT_SIGNATURE_VALID</c> errors are set in the <c>dwErrorStatus</c>
	/// field of the CERT_TRUST_STATUS structure. To disable checking the key length, set the
	/// <c>CERT_CHAIN_STRONG_SIGN_DISABLE_END_CHECK_FLAG</c> value in the <c>dwStrongSignFlags</c> member of the CERT_CHAIN_PARA
	/// structure pointed to by the pChainPara parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the <c>CERT_STRONG_SIGN_ENABLE_CRL_CHECK</c> or <c>CERT_STRONG_SIGN_ENABLE_OCSP_CHECK</c> flags are set in the
	/// CERT_STRONG_SIGN_SERIALIZED_INFO structure and a CRL or OCSP response is found without a strong signature, the CRL or OCSP
	/// response will be treated as being offline. That is, the <c>CERT_TRUST_IS_OFFLINE_REVOCATION</c> and
	/// <c>CERT_TRUST_REVOCATION_STATUS_UNKNOWN</c> errors are set in the <c>dwErrorStatus</c> field of the CERT_TRUST_STATUS structure.
	/// Also, the <c>dwRevocationResult</c> member of the CERT_REVOCATION_INFO structure is set to <c>NTE_BAD_ALGID</c>.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Creating a Certificate Chain.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetcertificatechain BOOL CertGetCertificateChain(
	// HCERTCHAINENGINE hChainEngine, PCCERT_CONTEXT pCertContext, LPFILETIME pTime, HCERTSTORE hAdditionalStore, PCERT_CHAIN_PARA
	// pChainPara, DWORD dwFlags, LPVOID pvReserved, PCCERT_CHAIN_CONTEXT *ppChainContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "8c93036c-0b93-40d4-b0e3-ba1f2fc72db1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertGetCertificateChain([Optional] HCERTCHAINENGINE hChainEngine, [In] PCCERT_CONTEXT pCertContext, in FILETIME pTime,
		[Optional] HCERTSTORE hAdditionalStore, in CERT_CHAIN_PARA pChainPara, CertChainFlags dwFlags, [Optional] IntPtr pvReserved, out SafePCCERT_CHAIN_CONTEXT ppChainContext);

	/// <summary>
	/// The <c>CertGetCertificateChain</c> function builds a certificate chain context starting from an end certificate and going back,
	/// if possible, to a trusted root certificate.
	/// </summary>
	/// <param name="hChainEngine">
	/// A handle of the chain engine (namespace and cache) to be used. If hChainEngine is <c>NULL</c>, the default chain engine,
	/// HCCE_CURRENT_USER, is used. This parameter can be set to HCCE_LOCAL_MACHINE.
	/// </param>
	/// <param name="pCertContext">
	/// A pointer to the CERT_CONTEXT of the end certificate, the certificate for which a chain is being built. This certificate context
	/// will be the zero-index element in the first simple chain.
	/// </param>
	/// <param name="pTime">
	/// A pointer to a FILETIME variable that indicates the time for which the chain is to be validated. Note that the time does not
	/// affect trust list, revocation, or root store checking. The current system time is used if <c>NULL</c> is passed to this
	/// parameter. Trust in a particular certificate being a trusted root is based on the current state of the root store and not the
	/// state of the root store at a time passed in by this parameter. For revocation, a certificate revocation list (CRL), itself, must
	/// be valid at the current time. The value of this parameter is used to determine whether a certificate listed in a CRL has been revoked.
	/// </param>
	/// <param name="hAdditionalStore">
	/// A handle to any additional store to search for supporting certificates and certificate trust lists (CTLs). This parameter can be
	/// <c>NULL</c> if no additional store is to be searched.
	/// </param>
	/// <param name="pChainPara">A pointer to a CERT_CHAIN_PARA structure that includes chain-building parameters.</param>
	/// <param name="dwFlags">
	/// <para>Flag values that indicate special processing. This parameter can be a combination of one or more of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_CHAIN_CACHE_END_CERT 0x00000001</term>
	/// <term>
	/// When this flag is set, the end certificate is cached, which might speed up the chain-building process. By default, the end
	/// certificate is not cached, and it would need to be verified each time a chain is built for it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_REVOCATION_CHECK_CACHE_ONLY 0x80000000</term>
	/// <term>Revocation checking only accesses cached URLs.</term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_REVOCATION_CHECK_OCSP_CERT 0x04000000</term>
	/// <term>
	/// This flag is used internally during chain building for an online certificate status protocol (OCSP) signer certificate to
	/// prevent cyclic revocation checks. During chain building, if the OCSP response is signed by an independent OCSP signer, then, in
	/// addition to the original chain build, there is a second chain built for the OCSP signer certificate itself. This flag is used
	/// during this second chain build to inhibit a recursive independent OCSP signer certificate. If the signer certificate contains
	/// the szOID_PKIX_OCSP_NOCHECK extension, revocation checking is skipped for the leaf signer certificate. Both OCSP and CRL
	/// checking are allowed. Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_CACHE_ONLY_URL_RETRIEVAL 0x00000004</term>
	/// <term>
	/// Uses only cached URLs in building a certificate chain. The Internet and intranet are not searched for URL-based objects. Note
	/// This flag is not applicable to revocation checking. Set CERT_CHAIN_REVOCATION_CHECK_CACHE_ONLY to use only cached URLs for
	/// revocation checking.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_DISABLE_PASS1_QUALITY_FILTERING 0x00000040</term>
	/// <term>
	/// For performance reasons, the second pass of chain building only considers potential chain paths that have quality greater than
	/// or equal to the highest quality determined during the first pass. The first pass only considers valid signature, complete chain,
	/// and trusted roots to calculate chain quality. This flag can be set to disable this optimization and consider all potential chain
	/// paths during the second pass.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_DISABLE_MY_PEER_TRUST 0x00000800</term>
	/// <term>This flag is not supported. Certificates in the "My" store are never considered for peer trust.</term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_ENABLE_PEER_TRUST 0x00000400</term>
	/// <term>
	/// End entity certificates in the "TrustedPeople" store are trusted without performing any chain building. This function does not
	/// set the CERT_TRUST_IS_PARTIAL_CHAIN or CERT_TRUST_IS_UNTRUSTED_ROOT dwErrorStatus member bits of the ppChainContext parameter.
	/// Windows Server 2003 Windows XP : This flag is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_OPT_IN_WEAK_SIGNATURE 0x00010000</term>
	/// <term>
	/// Setting this flag indicates the caller wishes to opt into weak signature checks. This flag is available in the rollup update for
	/// each OS starting with Windows 7 and Windows Server 2008 R2.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_RETURN_LOWER_QUALITY_CONTEXTS 0x00000080</term>
	/// <term>
	/// The default is to return only the highest quality chain path. Setting this flag will return the lower quality chains. These are
	/// returned in the cLowerQualityChainContext and rgpLowerQualityChainContext fields of the chain context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_DISABLE_AUTH_ROOT_AUTO_UPDATE 0x00000100</term>
	/// <term>Setting this flag inhibits the auto update of third-party roots from the Windows Update Web Server.</term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_REVOCATION_ACCUMULATIVE_TIMEOUT 0x08000000</term>
	/// <term>
	/// When you set CERT_CHAIN_REVOCATION_ACCUMULATIVE_TIMEOUT and you also specify a value for the dwUrlRetrievalTimeout member of the
	/// CERT_CHAIN_PARA structure, the value you specify in dwUrlRetrievalTimeout represents the cumulative timeout across all
	/// revocation URL retrievals. If you set CERT_CHAIN_REVOCATION_ACCUMULATIVE_TIMEOUT but do not specify a dwUrlRetrievalTimeout
	/// value, the maximum cumulative timeout is set, by default, to 20 seconds. Each URL tested will timeout after half of the
	/// remaining cumulative balance has passed. That is, the first URL times out after 10 seconds, the second after 5 seconds, the
	/// third after 2.5 seconds and so on until a URL succeeds, 20 seconds has passed, or there are no more URLs to test. If you do not
	/// set CERT_CHAIN_REVOCATION_ACCUMULATIVE_TIMEOUT, each revocation URL in the chain is assigned a maximum timeout equal to the
	/// value specified in dwUrlRetrievalTimeout. If you do not specify a value for the dwUrlRetrievalTimeout member, each revocation
	/// URL is assigned a maximum default timeout of 15 seconds. If no URL succeeds, the maximum cumulative timeout value is 15 seconds
	/// multiplied by the number of URLs in the chain. You can set the default values by using Group Policy.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_TIMESTAMP_TIME 0x00000200</term>
	/// <term>
	/// When this flag is set, pTime is used as the time stamp time to determine whether the end certificate was time valid. Current
	/// time can also be used to determine whether the end certificate remains time valid. All other certification authority (CA) and
	/// root certificates in the chain are checked by using current time and not pTime.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_DISABLE_AIA 0x00002000</term>
	/// <term>Setting this flag explicitly turns off Authority Information Access (AIA) retrievals.</term>
	/// </item>
	/// </list>
	/// <para>You can also set the following revocation flags, but only one flag from this group may be set at a time.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_CHAIN_REVOCATION_CHECK_END_CERT 0x10000000</term>
	/// <term>Revocation checking is done on the end certificate and only the end certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_REVOCATION_CHECK_CHAIN 0x20000000</term>
	/// <term>Revocation checking is done on all of the certificates in every chain.</term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_REVOCATION_CHECK_CHAIN_EXCLUDE_ROOT 0x40000000</term>
	/// <term>Revocation checking is done on all certificates in all of the chains except the root certificate.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvReserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="ppChainContext">
	/// The address of a pointer to the chain context created. When you have finished using the chain context, release the chain by
	/// calling the CertFreeCertificateChain function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When an application requests a certificate chain, the structure returned is in the form of a CERT_CHAIN_CONTEXT. This context
	/// contains an array of CERT_SIMPLE_CHAIN structures where each simple chain goes from an end certificate to a self-signed
	/// certificate. The chain context connects simple chains through trust lists. Each simple chain contains the chain of certificates,
	/// summary trust information about the chain, and trust information about each certificate element in the chain.
	/// </para>
	/// <para>The following remarks apply to strong signature checking:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// You can enable strong signature checking for this function by setting the <c>pStrongSignPara</c> member of the CERT_CHAIN_PARA
	/// structure that is pointed to by the pChainPara parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If a certificate without a strong signature is found in the chain, the <c>CERT_TRUST_HAS_WEAK_SIGNATURE</c> and
	/// <c>CERT_TRUST_IS_NOT_SIGNATURE_VALID</c> errors are set in the <c>dwErrorStatus</c> field of the CERT_TRUST_STATUS structure.
	/// The ppChainContext parameter points to a CERT_CHAIN_CONTEXT structure which, in turn, points to the <c>CERT_TRUST_STATUS</c> structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the chain is strong signed, the public key in the end certificate is checked to determine whether it satisfies the minimum
	/// public key length requirements for a strong signature. If the condition is not satisfied, the
	/// <c>CERT_TRUST_HAS_WEAK_SIGNATURE</c> and <c>CERT_TRUST_IS_NOT_SIGNATURE_VALID</c> errors are set in the <c>dwErrorStatus</c>
	/// field of the CERT_TRUST_STATUS structure. To disable checking the key length, set the
	/// <c>CERT_CHAIN_STRONG_SIGN_DISABLE_END_CHECK_FLAG</c> value in the <c>dwStrongSignFlags</c> member of the CERT_CHAIN_PARA
	/// structure pointed to by the pChainPara parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the <c>CERT_STRONG_SIGN_ENABLE_CRL_CHECK</c> or <c>CERT_STRONG_SIGN_ENABLE_OCSP_CHECK</c> flags are set in the
	/// CERT_STRONG_SIGN_SERIALIZED_INFO structure and a CRL or OCSP response is found without a strong signature, the CRL or OCSP
	/// response will be treated as being offline. That is, the <c>CERT_TRUST_IS_OFFLINE_REVOCATION</c> and
	/// <c>CERT_TRUST_REVOCATION_STATUS_UNKNOWN</c> errors are set in the <c>dwErrorStatus</c> field of the CERT_TRUST_STATUS structure.
	/// Also, the <c>dwRevocationResult</c> member of the CERT_REVOCATION_INFO structure is set to <c>NTE_BAD_ALGID</c>.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Creating a Certificate Chain.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetcertificatechain BOOL CertGetCertificateChain(
	// HCERTCHAINENGINE hChainEngine, PCCERT_CONTEXT pCertContext, LPFILETIME pTime, HCERTSTORE hAdditionalStore, PCERT_CHAIN_PARA
	// pChainPara, DWORD dwFlags, LPVOID pvReserved, PCCERT_CHAIN_CONTEXT *ppChainContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "8c93036c-0b93-40d4-b0e3-ba1f2fc72db1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertGetCertificateChain([Optional] HCERTCHAINENGINE hChainEngine, [In] PCCERT_CONTEXT pCertContext, [In, Optional] IntPtr pTime,
		[Optional] HCERTSTORE hAdditionalStore, in CERT_CHAIN_PARA pChainPara, CertChainFlags dwFlags, [Optional] IntPtr pvReserved, out SafePCCERT_CHAIN_CONTEXT ppChainContext);

	/// <summary>
	/// The <c>CertIsValidCRLForCertificate</c> function checks a CRL to find out if it is a CRL that would include a specific
	/// certificate if that certificate were revoked. If the CRL has an issuing distribution point (IDP) extension, the function checks
	/// whether that IDP is valid for the certificate being checked.
	/// </summary>
	/// <param name="pCert">A pointer to a certificate context.</param>
	/// <param name="pCrl">
	/// A pointer to a CRL. The function checks this CRL to determine whether it could contain the certificate context pointed to by
	/// pCert. The function does not look for the certificate in the CRL.
	/// </param>
	/// <param name="dwFlags">Currently not used and must be set to zero.</param>
	/// <param name="pvReserved">Currently not used and must be set to <c>NULL</c>.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if the CRL is a valid CRL to be searched for the specific certificate. It returns <c>FALSE</c>
	/// if the CRL is not a valid CRL for searching for the certificate.
	/// </returns>
	/// <remarks>
	/// For the CRL to be valid for the certificate, the <c>CertIsValidCRLForCertificate</c> function does not require the CRL to be
	/// issued by the same certification authority (CA) as the issuer of the certificate.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certisvalidcrlforcertificate BOOL
	// CertIsValidCRLForCertificate( PCCERT_CONTEXT pCert, PCCRL_CONTEXT pCrl, DWORD dwFlags, void *pvReserved );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "06047b7a-4bdd-42f9-bb85-49b6ec6f35a0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertIsValidCRLForCertificate(PCCERT_CONTEXT pCert, PCCRL_CONTEXT pCrl, uint dwFlags = 0, IntPtr pvReserved = default);

	/// <summary>
	/// The <c>CertSetCertificateContextPropertiesFromCTLEntry</c> function sets the properties on the certificate context by using the
	/// attributes in the specified certificate trust list (CTL) entry.
	/// </summary>
	/// <param name="pCertContext">A pointer to the CERT_CONTEXT whose attributes are to be set.</param>
	/// <param name="pCtlEntry">A pointer to the CTL_ENTRY structure used to set the attributes on the certificate.</param>
	/// <param name="dwFlags">
	/// A <c>DWORD</c>. This parameter can be set to CERT_SET_PROPERTY_IGNORE_PERSIST_ERROR_FLAG to ignore any persisted error flags.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certsetcertificatecontextpropertiesfromctlentry BOOL
	// CertSetCertificateContextPropertiesFromCTLEntry( PCCERT_CONTEXT pCertContext, PCTL_ENTRY pCtlEntry, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b53b046a-68d4-4dc5-ab89-1b30ebd1de60")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertSetCertificateContextPropertiesFromCTLEntry(PCCERT_CONTEXT pCertContext, in CTL_ENTRY pCtlEntry, uint dwFlags);

	/// <summary>
	/// The <c>CertVerifyCertificateChainPolicy</c> function checks a certificate chain to verify its validity, including its compliance
	/// with any specified validity policy criteria.
	/// </summary>
	/// <param name="pszPolicyOID">
	/// <para>Current predefined verify chain policy structures are listed in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_BASE (LPCSTR) 1</term>
	/// <term>
	/// Implements the base chain policy verification checks. The dwFlags member of the structure pointed to by pPolicyPara can be set
	/// to alter the default policy checking behavior.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_AUTHENTICODE (LPCSTR) 2</term>
	/// <term>
	/// Implements the Authenticode chain policy verification checks. The pvExtraPolicyPara member of the structure pointed to by
	/// pPolicyPara can be set to point to an AUTHENTICODE_EXTRA_CERT_CHAIN_POLICY_PARA structure. The pvExtraPolicyStatus member of the
	/// structure pointed to by pPolicyStatus can be set to point to an AUTHENTICODE_EXTRA_CERT_CHAIN_POLICY_STATUS structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_AUTHENTICODE_TS (LPCSTR) 3</term>
	/// <term>
	/// Implements Authenticode Time Stamp chain policy verification checks. The pvExtraPolicyPara member of the data structure pointed
	/// to by pPolicyPara can be set to point to an AUTHENTICODE_TS_EXTRA_CERT_CHAIN_POLICY_PARA structure. The pvExtraPolicyStatus
	/// member of the data structure pointed to by pPolicyStatus is not used and must be set to NULL
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_SSL (LPCSTR) 4</term>
	/// <term>
	/// Implements the SSL client/server chain policy verification checks. The pvExtraPolicyPara member in the data structure pointed to
	/// by pPolicyPara can be set to point to an SSL_EXTRA_CERT_CHAIN_POLICY_PARA structure initialized with additional policy criteria.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_BASIC_CONSTRAINTS (LPCSTR) 5</term>
	/// <term>
	/// Implements the basic constraints chain policy. Iterates through all the certificates in the chain checking for either a
	/// szOID_BASIC_CONSTRAINTS or a szOID_BASIC_CONSTRAINTS2 extension. If neither extension is present, the certificate is assumed to
	/// have valid policy. Otherwise, for the first certificate element, checks if it matches the expected CA_FLAG or END_ENTITY_FLAG
	/// specified in the dwFlags member of the CERT_CHAIN_POLICY_PARA structure pointed to by the pPolicyPara parameter. If neither or
	/// both flags are set, then, the first element can be either a CA or END_ENTITY. All other elements must be a certification
	/// authority (CA). If the PathLenConstraint is present in the extension, it is checked. The first elements in the remaining simple
	/// chains (that is, the certificates used to sign the CTL) are checked to be an END_ENTITY. If this verification fails, dwError
	/// will be set to TRUST_E_BASIC_CONSTRAINTS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_NT_AUTH (LPCSTR) 6</term>
	/// <term>
	/// Implements the Windows NT Authentication chain policy, which consists of three distinct chain verifications in the following order:
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_MICROSOFT_ROOT (LPCSTR) 7</term>
	/// <term>
	/// Checks the last element of the first simple chain for a Microsoft root public key. If that element does not contain a Microsoft
	/// root public key, the dwError member of the CERT_CHAIN_POLICY_STATUS structure pointed to by the pPolicyStatus parameter is set
	/// to CERT_E_UNTRUSTEDROOT. The dwFlags member of the CERT_CHAIN_POLICY_PARA structure pointed to by the pPolicyStatus parameter
	/// can contain the MICROSOFT_ROOT_CERT_CHAIN_POLICY_CHECK_APPLICATION_ROOT_FLAG flag, which causes this function to also check for
	/// the Microsoft application root "Microsoft Root Certificate Authority 2011". The dwFlags member of the CERT_CHAIN_POLICY_PARA
	/// structure pointed to by the pPolicyPara parameter can contain the MICROSOFT_ROOT_CERT_CHAIN_POLICY_ENABLE_TEST_ROOT_FLAG flag,
	/// which causes this function to also check for the Microsoft test roots.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_EV (LPCSTR) 8</term>
	/// <term>
	/// Specifies that extended validation of certificates is performed. Windows Server 2008, Windows Vista, Windows Server 2003 and
	/// Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_SSL_F12 (LPCSTR) 9</term>
	/// <term>
	/// Checks if any certificates in the chain have weak crypto or if third party root certificate compliance and provide an error
	/// string. The pvExtraPolicyStatus member of the CERT_CHAIN_POLICY_STATUS structure pointed to by the pPolicyStatus parameter must
	/// point to SSL_F12_EXTRA_CERT_CHAIN_POLICY_STATUS, which is updated with the results of the weak crypto and root program
	/// compliance checks. Before calling, the cbSize member of the CERT_CHAIN_POLICY_STATUS structure pointed to by the pPolicyStatus
	/// parameter must be set to a value greater than or equal to sizeof(SSL_F12_EXTRA_CERT_CHAIN_POLICY_STATUS). The dwError member in
	/// CERT_CHAIN_POLICY_STATUS structure pointed to by the pPolicyStatus parameter will be set to TRUST_E_CERT_SIGNATURE for potential
	/// weak crypto and set to CERT_E_UNTRUSTEDROOT for Third Party Roots not in compliance with the Microsoft Root Program. Windows 10,
	/// version 1607, Windows Server 2016, Windows 10, version 1511 with KB3172985, Windows 10 RTM with KB3163912, Windows 8.1 and
	/// Windows Server 2012 R2 with KB3163912, and Windows 7 with SP1 and Windows Server 2008 R2 SP1 with KB3161029
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pChainContext">A pointer to a CERT_CHAIN_CONTEXT structure that contains a chain to be verified.</param>
	/// <param name="pPolicyPara">
	/// <para>
	/// A pointer to a CERT_CHAIN_POLICY_PARA structure that provides the policy verification criteria for the chain. The <c>dwFlags</c>
	/// member of that structure can be set to change the default policy checking behavior.
	/// </para>
	/// <para>In addition, policy-specific parameters can also be passed in the <c>pvExtraPolicyPara</c> member of the structure.</para>
	/// </param>
	/// <param name="pPolicyStatus">
	/// A pointer to a CERT_CHAIN_POLICY_STATUS structure where status information on the chain is returned. OID-specific extra status
	/// can be returned in the <c>pvExtraPolicyStatus</c> member of this structure.
	/// </param>
	/// <returns>
	/// <para>
	/// The return value indicates whether the function was able to check for the policy, it does not indicate whether the policy check
	/// failed or passed.
	/// </para>
	/// <para>
	/// If the chain can be verified for the specified policy, <c>TRUE</c> is returned and the <c>dwError</c> member of the
	/// pPolicyStatus is updated. A <c>dwError</c> of 0 (ERROR_SUCCESS or S_OK) indicates the chain satisfies the specified policy.
	/// </para>
	/// <para>
	/// If the chain cannot be validated, the return value is <c>TRUE</c> and you need to verify the pPolicyStatus parameter for the
	/// actual error.
	/// </para>
	/// <para>A value of <c>FALSE</c> indicates that the function wasn't able to check for the policy.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A <c>dwError</c> member of the CERT_CHAIN_POLICY_STATUS structure pointed to by pPolicyStatus can apply to a single chain
	/// element, to a simple chain, or to an entire chain context. If <c>dwError</c> applies to the entire chain context, both the
	/// <c>lChainIndex</c> and the <c>lElementIndex</c> members of the <c>CERT_CHAIN_POLICY_STATUS</c> structure are set to –1. If
	/// <c>dwError</c> applies to a complete simple chain, <c>lElementIndex</c> is set to –1 and <c>lChainIndex</c> is set to the index
	/// of the first chain that has an error. If <c>dwError</c> applies to a single certificate element, <c>lChainIndex</c> and
	/// <c>lElementIndex</c> index the first certificate that has the error.
	/// </para>
	/// <para>To get the certificate element use this syntax:</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certverifycertificatechainpolicy BOOL
	// CertVerifyCertificateChainPolicy( LPCSTR pszPolicyOID, PCCERT_CHAIN_CONTEXT pChainContext, PCERT_CHAIN_POLICY_PARA pPolicyPara,
	// PCERT_CHAIN_POLICY_STATUS pPolicyStatus );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "19c37f77-1072-4740-b244-764b816a2a1f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertVerifyCertificateChainPolicy([In] SafeOID pszPolicyOID, [In] PCCERT_CHAIN_CONTEXT pChainContext,
		in CERT_CHAIN_POLICY_PARA pPolicyPara, ref CERT_CHAIN_POLICY_STATUS pPolicyStatus);

	/// <summary>
	/// The <c>CertVerifyCertificateChainPolicy</c> function checks a certificate chain to verify its validity, including its compliance
	/// with any specified validity policy criteria.
	/// </summary>
	/// <param name="pszPolicyOID">
	/// <para>Current predefined verify chain policy structures are listed in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_BASE (LPCSTR) 1</term>
	/// <term>
	/// Implements the base chain policy verification checks. The dwFlags member of the structure pointed to by pPolicyPara can be set
	/// to alter the default policy checking behavior.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_AUTHENTICODE (LPCSTR) 2</term>
	/// <term>
	/// Implements the Authenticode chain policy verification checks. The pvExtraPolicyPara member of the structure pointed to by
	/// pPolicyPara can be set to point to an AUTHENTICODE_EXTRA_CERT_CHAIN_POLICY_PARA structure. The pvExtraPolicyStatus member of the
	/// structure pointed to by pPolicyStatus can be set to point to an AUTHENTICODE_EXTRA_CERT_CHAIN_POLICY_STATUS structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_AUTHENTICODE_TS (LPCSTR) 3</term>
	/// <term>
	/// Implements Authenticode Time Stamp chain policy verification checks. The pvExtraPolicyPara member of the data structure pointed
	/// to by pPolicyPara can be set to point to an AUTHENTICODE_TS_EXTRA_CERT_CHAIN_POLICY_PARA structure. The pvExtraPolicyStatus
	/// member of the data structure pointed to by pPolicyStatus is not used and must be set to NULL
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_SSL (LPCSTR) 4</term>
	/// <term>
	/// Implements the SSL client/server chain policy verification checks. The pvExtraPolicyPara member in the data structure pointed to
	/// by pPolicyPara can be set to point to an SSL_EXTRA_CERT_CHAIN_POLICY_PARA structure initialized with additional policy criteria.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_BASIC_CONSTRAINTS (LPCSTR) 5</term>
	/// <term>
	/// Implements the basic constraints chain policy. Iterates through all the certificates in the chain checking for either a
	/// szOID_BASIC_CONSTRAINTS or a szOID_BASIC_CONSTRAINTS2 extension. If neither extension is present, the certificate is assumed to
	/// have valid policy. Otherwise, for the first certificate element, checks if it matches the expected CA_FLAG or END_ENTITY_FLAG
	/// specified in the dwFlags member of the CERT_CHAIN_POLICY_PARA structure pointed to by the pPolicyPara parameter. If neither or
	/// both flags are set, then, the first element can be either a CA or END_ENTITY. All other elements must be a certification
	/// authority (CA). If the PathLenConstraint is present in the extension, it is checked. The first elements in the remaining simple
	/// chains (that is, the certificates used to sign the CTL) are checked to be an END_ENTITY. If this verification fails, dwError
	/// will be set to TRUST_E_BASIC_CONSTRAINTS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_NT_AUTH (LPCSTR) 6</term>
	/// <term>
	/// Implements the Windows NT Authentication chain policy, which consists of three distinct chain verifications in the following order:
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_MICROSOFT_ROOT (LPCSTR) 7</term>
	/// <term>
	/// Checks the last element of the first simple chain for a Microsoft root public key. If that element does not contain a Microsoft
	/// root public key, the dwError member of the CERT_CHAIN_POLICY_STATUS structure pointed to by the pPolicyStatus parameter is set
	/// to CERT_E_UNTRUSTEDROOT. The dwFlags member of the CERT_CHAIN_POLICY_PARA structure pointed to by the pPolicyStatus parameter
	/// can contain the MICROSOFT_ROOT_CERT_CHAIN_POLICY_CHECK_APPLICATION_ROOT_FLAG flag, which causes this function to also check for
	/// the Microsoft application root "Microsoft Root Certificate Authority 2011". The dwFlags member of the CERT_CHAIN_POLICY_PARA
	/// structure pointed to by the pPolicyPara parameter can contain the MICROSOFT_ROOT_CERT_CHAIN_POLICY_ENABLE_TEST_ROOT_FLAG flag,
	/// which causes this function to also check for the Microsoft test roots.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_EV (LPCSTR) 8</term>
	/// <term>
	/// Specifies that extended validation of certificates is performed. Windows Server 2008, Windows Vista, Windows Server 2003 and
	/// Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_CHAIN_POLICY_SSL_F12 (LPCSTR) 9</term>
	/// <term>
	/// Checks if any certificates in the chain have weak crypto or if third party root certificate compliance and provide an error
	/// string. The pvExtraPolicyStatus member of the CERT_CHAIN_POLICY_STATUS structure pointed to by the pPolicyStatus parameter must
	/// point to SSL_F12_EXTRA_CERT_CHAIN_POLICY_STATUS, which is updated with the results of the weak crypto and root program
	/// compliance checks. Before calling, the cbSize member of the CERT_CHAIN_POLICY_STATUS structure pointed to by the pPolicyStatus
	/// parameter must be set to a value greater than or equal to sizeof(SSL_F12_EXTRA_CERT_CHAIN_POLICY_STATUS). The dwError member in
	/// CERT_CHAIN_POLICY_STATUS structure pointed to by the pPolicyStatus parameter will be set to TRUST_E_CERT_SIGNATURE for potential
	/// weak crypto and set to CERT_E_UNTRUSTEDROOT for Third Party Roots not in compliance with the Microsoft Root Program. Windows 10,
	/// version 1607, Windows Server 2016, Windows 10, version 1511 with KB3172985, Windows 10 RTM with KB3163912, Windows 8.1 and
	/// Windows Server 2012 R2 with KB3163912, and Windows 7 with SP1 and Windows Server 2008 R2 SP1 with KB3161029
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pChainContext">A pointer to a CERT_CHAIN_CONTEXT structure that contains a chain to be verified.</param>
	/// <param name="pPolicyPara">
	/// <para>
	/// A pointer to a CERT_CHAIN_POLICY_PARA structure that provides the policy verification criteria for the chain. The <c>dwFlags</c>
	/// member of that structure can be set to change the default policy checking behavior.
	/// </para>
	/// <para>In addition, policy-specific parameters can also be passed in the <c>pvExtraPolicyPara</c> member of the structure.</para>
	/// </param>
	/// <param name="pPolicyStatus">
	/// A pointer to a CERT_CHAIN_POLICY_STATUS structure where status information on the chain is returned. OID-specific extra status
	/// can be returned in the <c>pvExtraPolicyStatus</c> member of this structure.
	/// </param>
	/// <returns>
	/// <para>
	/// The return value indicates whether the function was able to check for the policy, it does not indicate whether the policy check
	/// failed or passed.
	/// </para>
	/// <para>
	/// If the chain can be verified for the specified policy, <c>TRUE</c> is returned and the <c>dwError</c> member of the
	/// pPolicyStatus is updated. A <c>dwError</c> of 0 (ERROR_SUCCESS or S_OK) indicates the chain satisfies the specified policy.
	/// </para>
	/// <para>
	/// If the chain cannot be validated, the return value is <c>TRUE</c> and you need to verify the pPolicyStatus parameter for the
	/// actual error.
	/// </para>
	/// <para>A value of <c>FALSE</c> indicates that the function wasn't able to check for the policy.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A <c>dwError</c> member of the CERT_CHAIN_POLICY_STATUS structure pointed to by pPolicyStatus can apply to a single chain
	/// element, to a simple chain, or to an entire chain context. If <c>dwError</c> applies to the entire chain context, both the
	/// <c>lChainIndex</c> and the <c>lElementIndex</c> members of the <c>CERT_CHAIN_POLICY_STATUS</c> structure are set to –1. If
	/// <c>dwError</c> applies to a complete simple chain, <c>lElementIndex</c> is set to –1 and <c>lChainIndex</c> is set to the index
	/// of the first chain that has an error. If <c>dwError</c> applies to a single certificate element, <c>lChainIndex</c> and
	/// <c>lElementIndex</c> index the first certificate that has the error.
	/// </para>
	/// <para>To get the certificate element use this syntax:</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certverifycertificatechainpolicy BOOL
	// CertVerifyCertificateChainPolicy( LPCSTR pszPolicyOID, PCCERT_CHAIN_CONTEXT pChainContext, PCERT_CHAIN_POLICY_PARA pPolicyPara,
	// PCERT_CHAIN_POLICY_STATUS pPolicyStatus );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "19c37f77-1072-4740-b244-764b816a2a1f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertVerifyCertificateChainPolicy(IntPtr pszPolicyOID, [In] PCCERT_CHAIN_CONTEXT pChainContext,
		in CERT_CHAIN_POLICY_PARA pPolicyPara, ref CERT_CHAIN_POLICY_STATUS pPolicyStatus);

	/// <summary>
	/// The <c>CertVerifyCTLUsage</c> function verifies that a subject is trusted for a specified usage by finding a signed and
	/// time-valid certificate trust list (CTL) with the usage identifiers that contain the subject. A certificate's subject can be
	/// identified by either its certificate context or any unique identifier such as the SHA1 hash of the subject's certificate.
	/// </summary>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type used. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however, additional
	/// encoding types can be added in the future. For either current encoding type, use
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.</para>
	/// </param>
	/// <param name="dwSubjectType">
	/// <para>
	/// If the dwSubjectType parameter is set to CTL_CERT_SUBJECT_TYPE, pvSubject points to a CERT_CONTEXT structure. The structure's
	/// <c>SubjectAlgorithm</c> member is examined to determine the representation of the subject's identity. Initially, only SHA1 and
	/// MD5 hashes are supported as values for <c>SubjectAlgorithm</c>. The appropriate hash property is obtained from the
	/// <c>CERT_CONTEXT</c> structure.
	/// </para>
	/// <para>
	/// If the dwSubjectType parameter is set to CTL_ANY_SUBJECT_TYPE, pvSubject points to the CTL_ANY_SUBJECT_INFO structure. The
	/// <c>SubjectAlgorithm</c> member of this structure must match the algorithm type of the CTL, and the <c>SubjectIdentifier</c>
	/// member must match one of the CTL entries.
	/// </para>
	/// <para>If dwSubjectType is set to either preceding value, dwEncodingType is not used.</para>
	/// </param>
	/// <param name="pvSubject">Value used in conjunction with the dwSubjectType parameter.</param>
	/// <param name="pSubjectUsage">A pointer to a CTL_USAGE structure used to specify the intended usage of the subject.</param>
	/// <param name="dwFlags">
	/// <para>
	/// If the CERT_VERIFY_INHIBIT_CTL_UPDATE_FLAG is not set, a CTL whose time is no longer valid in one of the stores specified by
	/// <c>rghCtlStore</c> in CTL_VERIFY_USAGE_PARA can be replaced. When replaced, the CERT_VERIFY_UPDATED_CTL_FLAG is set in the
	/// <c>dwFlags</c> member of pVerifyUsageStatus. If this flag is set, an update will not be made, even if a time-valid, updated CTL
	/// is received for a CTL that is in the store and whose time is no longer valid.
	/// </para>
	/// <para>
	/// If the CERT_VERIFY_TRUSTED_SIGNERS_FLAG is set, only the signer stores specified by <c>rghSignerStore</c> in
	/// CTL_VERIFY_USAGE_PARA are searched to find the signer. Otherwise, the signer stores provide additional sources to find the
	/// signer's certificate. For more information, see Remarks.
	/// </para>
	/// <para>If CERT_VERIFY_NO_TIME_CHECK_FLAG is set, the CTLs are not checked for time validity. Otherwise, they are.</para>
	/// <para>
	/// If CERT_VERIFY_ALLOW_MORE_USAGE_FLAG is set, the CTL can contain usage identifiers in addition to those specified by
	/// pSubjectUsage. Otherwise, the found CTL will contain no additional usage identifiers.
	/// </para>
	/// </param>
	/// <param name="pVerifyUsagePara">
	/// A pointer to a CTL_VERIFY_USAGE_PARA structure that specifies the stores to be searched to find the CTL and the stores that
	/// contain acceptable CTL signers. Setting the <c>ListIdentifier</c> member further limits the search.
	/// </param>
	/// <param name="pVerifyUsageStatus">
	/// A pointer to a CTL_VERIFY_USAGE_STATUS structure. The <c>cbSize</c> member of the structure must to be set to the size, in
	/// bytes, of the structure, and all other fields must be set to zero before <c>CertVerifyCTLUsage</c> is called. For more
	/// information, see <c>CTL_VERIFY_USAGE_STATUS</c>.
	/// </param>
	/// <returns>
	/// <para>
	/// If the subject is trusted for the specified usage, <c>TRUE</c> is returned. Otherwise, <c>FALSE</c> is returned. GetLastError
	/// can return one of the following error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NO_VERIFY_USAGE_DLL</term>
	/// <term>No DLL or exported function was found to verify subject usage.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NO_VERIFY_USAGE_CHECK</term>
	/// <term>The called function was not able to do a usage check on the subject.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_VERIFY_USAGE_OFFLINE</term>
	/// <term>The server was offline; therefore, the called function could not complete the usage check.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NOT_IN_CTL</term>
	/// <term>The subject was not found in a CTL.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NO_TRUSTED_SIGNER</term>
	/// <term>No trusted signer was found to verify the signature of the message or trust list.</term>
	/// </item>
	/// </list>
	/// <para>The <c>dwError</c> member of the CTL_VERIFY_USAGE_PARA pointed to by pVerifyUsageStatus is set to the same error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>CertVerifyCTLUsage</c> is a dispatcher to functions that can be installed by using an object identifier (OID). First, it
	/// tries to find an OID function that matches the first usage object identifier in the CLT_USAGE structure pointed to by
	/// pSubjectUsage. If this fails, it uses the default <c>CertDllVerifyCTLUsage</c> functions.
	/// </para>
	/// <para>The <c>CertDllVerifyCTLUsage</c> function in Cryptnet.dll can be installed by using an OID; it has the following properties:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If CTL stores are specified by <c>rghCtlStore</c> in pVerifyUsagePara, only those stores are searched to find a CTL. Otherwise,
	/// the Trust system store is searched to find a CTL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If CERT_VERIFY_TRUSTED_SIGNERS_FLAG is set, only the signer stores specified by <c>rghSignerStore</c> in pVerifyUsagePara are
	/// searched to find the certificate that corresponds to the signer's issuer and serial number. Otherwise, the CTL message's store,
	/// the signer stores specified by <c>rghSignerStore</c> in pVerifyUsagePara, the Trust system store, CA system store, ROOT, and
	/// Software Publisher Certificate (SPC) system stores are searched to find the signer's certificate. In either case, the public key
	/// in the found certificate is used to verify the signature of the CTL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If the CTL has a set <c>NextUpdate</c> member and CERT_VERIFY_NO_TIME_CHECK is not set, it is verified for time validity.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If the CTL obtained from the store has a time that is not valid, an attempt is made to get a time-valid version. The
	/// <c>CertDllVerifyCTLUsage</c> function uses the <c>NextUpdateLocation</c> property or the <c>NextUpdateLocation</c> extension of
	/// the CTL, or it searches the signer's information for a <c>NextUpdateLocation</c> attribute.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certverifyctlusage BOOL CertVerifyCTLUsage( DWORD
	// dwEncodingType, DWORD dwSubjectType, void *pvSubject, PCTL_USAGE pSubjectUsage, DWORD dwFlags, PCTL_VERIFY_USAGE_PARA
	// pVerifyUsagePara, PCTL_VERIFY_USAGE_STATUS pVerifyUsageStatus );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "d87d8157-8e52-4198-bfd4-46d83d72eb13")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertVerifyCTLUsage(CertEncodingType dwEncodingType, CtlCertSubject dwSubjectType, [In] IntPtr pvSubject, in CTL_USAGE pSubjectUsage,
		CertVerifyCTLFlags dwFlags, in CTL_VERIFY_USAGE_PARA pVerifyUsagePara, ref CTL_VERIFY_USAGE_STATUS pVerifyUsageStatus);

	/// <summary>
	/// The <c>CertVerifyCTLUsage</c> function verifies that a subject is trusted for a specified usage by finding a signed and
	/// time-valid certificate trust list (CTL) with the usage identifiers that contain the subject. A certificate's subject can be
	/// identified by either its certificate context or any unique identifier such as the SHA1 hash of the subject's certificate.
	/// </summary>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type used. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however, additional
	/// encoding types can be added in the future. For either current encoding type, use
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.</para>
	/// </param>
	/// <param name="dwSubjectType">
	/// <para>
	/// If the dwSubjectType parameter is set to CTL_CERT_SUBJECT_TYPE, pvSubject points to a CERT_CONTEXT structure. The structure's
	/// <c>SubjectAlgorithm</c> member is examined to determine the representation of the subject's identity. Initially, only SHA1 and
	/// MD5 hashes are supported as values for <c>SubjectAlgorithm</c>. The appropriate hash property is obtained from the
	/// <c>CERT_CONTEXT</c> structure.
	/// </para>
	/// <para>
	/// If the dwSubjectType parameter is set to CTL_ANY_SUBJECT_TYPE, pvSubject points to the CTL_ANY_SUBJECT_INFO structure. The
	/// <c>SubjectAlgorithm</c> member of this structure must match the algorithm type of the CTL, and the <c>SubjectIdentifier</c>
	/// member must match one of the CTL entries.
	/// </para>
	/// <para>If dwSubjectType is set to either preceding value, dwEncodingType is not used.</para>
	/// </param>
	/// <param name="pvSubject">Value used in conjunction with the dwSubjectType parameter.</param>
	/// <param name="pSubjectUsage">A pointer to a CTL_USAGE structure used to specify the intended usage of the subject.</param>
	/// <param name="dwFlags">
	/// <para>
	/// If the CERT_VERIFY_INHIBIT_CTL_UPDATE_FLAG is not set, a CTL whose time is no longer valid in one of the stores specified by
	/// <c>rghCtlStore</c> in CTL_VERIFY_USAGE_PARA can be replaced. When replaced, the CERT_VERIFY_UPDATED_CTL_FLAG is set in the
	/// <c>dwFlags</c> member of pVerifyUsageStatus. If this flag is set, an update will not be made, even if a time-valid, updated CTL
	/// is received for a CTL that is in the store and whose time is no longer valid.
	/// </para>
	/// <para>
	/// If the CERT_VERIFY_TRUSTED_SIGNERS_FLAG is set, only the signer stores specified by <c>rghSignerStore</c> in
	/// CTL_VERIFY_USAGE_PARA are searched to find the signer. Otherwise, the signer stores provide additional sources to find the
	/// signer's certificate. For more information, see Remarks.
	/// </para>
	/// <para>If CERT_VERIFY_NO_TIME_CHECK_FLAG is set, the CTLs are not checked for time validity. Otherwise, they are.</para>
	/// <para>
	/// If CERT_VERIFY_ALLOW_MORE_USAGE_FLAG is set, the CTL can contain usage identifiers in addition to those specified by
	/// pSubjectUsage. Otherwise, the found CTL will contain no additional usage identifiers.
	/// </para>
	/// </param>
	/// <param name="pVerifyUsagePara">
	/// A pointer to a CTL_VERIFY_USAGE_PARA structure that specifies the stores to be searched to find the CTL and the stores that
	/// contain acceptable CTL signers. Setting the <c>ListIdentifier</c> member further limits the search.
	/// </param>
	/// <param name="pVerifyUsageStatus">
	/// A pointer to a CTL_VERIFY_USAGE_STATUS structure. The <c>cbSize</c> member of the structure must to be set to the size, in
	/// bytes, of the structure, and all other fields must be set to zero before <c>CertVerifyCTLUsage</c> is called. For more
	/// information, see <c>CTL_VERIFY_USAGE_STATUS</c>.
	/// </param>
	/// <returns>
	/// <para>
	/// If the subject is trusted for the specified usage, <c>TRUE</c> is returned. Otherwise, <c>FALSE</c> is returned. GetLastError
	/// can return one of the following error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NO_VERIFY_USAGE_DLL</term>
	/// <term>No DLL or exported function was found to verify subject usage.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NO_VERIFY_USAGE_CHECK</term>
	/// <term>The called function was not able to do a usage check on the subject.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_VERIFY_USAGE_OFFLINE</term>
	/// <term>The server was offline; therefore, the called function could not complete the usage check.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NOT_IN_CTL</term>
	/// <term>The subject was not found in a CTL.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NO_TRUSTED_SIGNER</term>
	/// <term>No trusted signer was found to verify the signature of the message or trust list.</term>
	/// </item>
	/// </list>
	/// <para>The <c>dwError</c> member of the CTL_VERIFY_USAGE_PARA pointed to by pVerifyUsageStatus is set to the same error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>CertVerifyCTLUsage</c> is a dispatcher to functions that can be installed by using an object identifier (OID). First, it
	/// tries to find an OID function that matches the first usage object identifier in the CLT_USAGE structure pointed to by
	/// pSubjectUsage. If this fails, it uses the default <c>CertDllVerifyCTLUsage</c> functions.
	/// </para>
	/// <para>The <c>CertDllVerifyCTLUsage</c> function in Cryptnet.dll can be installed by using an OID; it has the following properties:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If CTL stores are specified by <c>rghCtlStore</c> in pVerifyUsagePara, only those stores are searched to find a CTL. Otherwise,
	/// the Trust system store is searched to find a CTL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If CERT_VERIFY_TRUSTED_SIGNERS_FLAG is set, only the signer stores specified by <c>rghSignerStore</c> in pVerifyUsagePara are
	/// searched to find the certificate that corresponds to the signer's issuer and serial number. Otherwise, the CTL message's store,
	/// the signer stores specified by <c>rghSignerStore</c> in pVerifyUsagePara, the Trust system store, CA system store, ROOT, and
	/// Software Publisher Certificate (SPC) system stores are searched to find the signer's certificate. In either case, the public key
	/// in the found certificate is used to verify the signature of the CTL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If the CTL has a set <c>NextUpdate</c> member and CERT_VERIFY_NO_TIME_CHECK is not set, it is verified for time validity.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If the CTL obtained from the store has a time that is not valid, an attempt is made to get a time-valid version. The
	/// <c>CertDllVerifyCTLUsage</c> function uses the <c>NextUpdateLocation</c> property or the <c>NextUpdateLocation</c> extension of
	/// the CTL, or it searches the signer's information for a <c>NextUpdateLocation</c> attribute.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certverifyctlusage BOOL CertVerifyCTLUsage( DWORD
	// dwEncodingType, DWORD dwSubjectType, void *pvSubject, PCTL_USAGE pSubjectUsage, DWORD dwFlags, PCTL_VERIFY_USAGE_PARA
	// pVerifyUsagePara, PCTL_VERIFY_USAGE_STATUS pVerifyUsageStatus );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "d87d8157-8e52-4198-bfd4-46d83d72eb13")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertVerifyCTLUsage(CertEncodingType dwEncodingType, CtlCertSubject dwSubjectType, [In] IntPtr pvSubject, in CTL_USAGE pSubjectUsage,
		CertVerifyCTLFlags dwFlags, [In, Optional] IntPtr pVerifyUsagePara, ref CTL_VERIFY_USAGE_STATUS pVerifyUsageStatus);

	/// <summary>
	/// <para>The <c>CryptMsgEncodeAndSignCTL</c> function encodes a CTL and creates a signed message containing the encoded CTL.</para>
	/// <para>This function first encodes the CTL pointed to by pCtlInfo and then calls CryptMsgSignCTL to sign the encoded message.</para>
	/// </summary>
	/// <param name="dwMsgEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pCtlInfo">A pointer to the CTL_INFO structure containing the CTL to be encoded and signed.</param>
	/// <param name="pSignInfo">
	/// <para>A pointer to a CMSG_SIGNED_ENCODE_INFO structure that contains an array of a CMSG_SIGNER_ENCODE_INFO structures.</para>
	/// <para>
	/// The message can be encoded without signers if the <c>cbSize</c> member of the structure is set to the size of the structure and
	/// all of the other members are set to zero.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// CMSG_ENCODE_SORTED_CTL_FLAG is set if the CTL entries are to be sorted before encoding. This flag is set if the
	/// CertFindSubjectInSortedCTL or CertEnumSubjectInSortedCTL functions will be called.
	/// </para>
	/// <para>
	/// CMSG_ENCODE_HASHED_SUBJECT_IDENTIFIER_FLAG is set if CMSG_ENCODE_SORTED_CTL_FLAG is set, and the identifier for the
	/// TrustedSubjects is a hash, such as MD5 or SHA1.
	/// </para>
	/// <para>
	/// If CMS_PKCS7 is defined, dwFlags can be set to CMSG_CMS_ENCAPSULATED_CTL_FLAG to encode a CMS compatible V3 SignedData message.
	/// </para>
	/// </param>
	/// <param name="pbEncoded">
	/// <para>A pointer to a buffer that receives the encoded, signed message created.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbEncoded">
	/// A pointer to a <c>DWORD</c> that specifies the size, in bytes, of the pbEncoded buffer. When the function returns, the
	/// <c>DWORD</c> contains the number of bytes stored or to be stored in the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>
	/// If the function fails, the return value is zero ( <c>FALSE</c>). To get extended error information, call GetLastError. Errors
	/// can be propagated from calls to CryptMsgOpenToEncode and CryptMsgUpdate.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgencodeandsignctl BOOL CryptMsgEncodeAndSignCTL(
	// DWORD dwMsgEncodingType, PCTL_INFO pCtlInfo, PCMSG_SIGNED_ENCODE_INFO pSignInfo, DWORD dwFlags, BYTE *pbEncoded, DWORD
	// *pcbEncoded );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "5c0e9e2e-a50d-45d0-b51d-065784d1d912")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptMsgEncodeAndSignCTL(CertEncodingType dwMsgEncodingType, in CTL_INFO pCtlInfo, in CMSG_SIGNED_ENCODE_INFO pSignInfo,
		CryptMsgEncodeFlags dwFlags, [Out, Optional] IntPtr pbEncoded, ref uint pcbEncoded);

	/// <summary>The <c>CryptMsgGetAndVerifySigner</c> function verifies a cryptographic message's signature.</summary>
	/// <param name="hCryptMsg">Handle of a cryptographic message.</param>
	/// <param name="cSignerStore">Number of stores in the rghSignerStore array.</param>
	/// <param name="rghSignerStore">Array of certificate store handles that can be searched for a signer's certificate.</param>
	/// <param name="dwFlags">
	/// <para>Indicates particular use of the function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_TRUSTED_SIGNER_FLAG</term>
	/// <term>
	/// The stores in rghSignerStore are assumed trusted and they are the only stores searched to find the certificate corresponding to
	/// the signer's issuer and serial number. Otherwise, signer stores can be provided to supplement the message's store of
	/// certificates. If a signer certificate is found, its public key is used to verify the message signature.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNER_ONLY_FLAG</term>
	/// <term>Return the signer without doing the signature verification.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_USE_SIGNER_INDEX_FLAG</term>
	/// <term>
	/// Only the signer specified by *pdwSignerIndex is returned. Otherwise, iterate through all the signers until a signature is
	/// verified or there are no more signers.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppSigner">
	/// If the signature is verified, ppSigner is updated to point to the signer's certificate context. When you have finished using the
	/// certificate, free the context by calling the CertFreeCertificateContext function. This parameter can be <c>NULL</c> if the
	/// application has no need for the signer's certificate.
	/// </param>
	/// <param name="pdwSignerIndex">
	/// If the signature is verified, pdwSigner is updated to point to the index of the signer in the array of signers. This parameter
	/// can be <c>NULL</c> if the application has no need for the index of the signer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>If the function fails, the return value is zero (FALSE). For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsggetandverifysigner BOOL
	// CryptMsgGetAndVerifySigner( HCRYPTMSG hCryptMsg, DWORD cSignerStore, HCERTSTORE *rghSignerStore, DWORD dwFlags, PCCERT_CONTEXT
	// *ppSigner, DWORD *pdwSignerIndex );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "380c9cf3-27a2-4354-b1c8-97cec33f4e44")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptMsgGetAndVerifySigner(HCRYPTMSG hCryptMsg, uint cSignerStore, [In, MarshalAs(UnmanagedType.LPArray)] HCERTSTORE[] rghSignerStore,
		CryptMsgSignerFlags dwFlags, out SafePCCERT_CONTEXT ppSigner, ref uint pdwSignerIndex);

	/// <summary>The <c>CryptMsgSignCTL</c> function creates a signed message containing an encoded CTL.</summary>
	/// <param name="dwMsgEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbCtlContent">
	/// The encoded CTL_INFO that can be a member of a CTL_CONTEXT structure or can be created using the CryptEncodeObject function.
	/// </param>
	/// <param name="cbCtlContent">The size, in bytes, of the content pointed to by pbCtlContent.</param>
	/// <param name="pSignInfo">
	/// <para>A pointer to a CMSG_SIGNED_ENCODE_INFO structure containing an array of a CMSG_SIGNER_ENCODE_INFO structures.</para>
	/// <para>
	/// The message can be encoded without signers if the <c>cbSize</c> member of the structure is set to the size of the structure and
	/// all of the other members are set to zero.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// If CMS_PKCS7 is defined, can be set to CMSG_CMS_ENCAPSULATED_CTL_FLAG to encode a CMS compatible V3 SignedData message.
	/// </param>
	/// <param name="pbEncoded">
	/// <para>A pointer to a buffer to receives the encoded message.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to get the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbEncoded">
	/// A pointer to a <c>DWORD</c> specifying the size, in bytes, of the pbEncoded buffer. When the function returns, the <c>DWORD</c>
	/// contains the number of bytes stored or to be stored in the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>
	/// If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError. This
	/// function can return errors propagated from calls to CryptMsgOpenToEncode and CryptMsgUpdate.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgsignctl BOOL CryptMsgSignCTL( DWORD
	// dwMsgEncodingType, BYTE *pbCtlContent, DWORD cbCtlContent, PCMSG_SIGNED_ENCODE_INFO pSignInfo, DWORD dwFlags, BYTE *pbEncoded,
	// DWORD *pcbEncoded );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "85ae8ce3-d0a7-4fcb-beaa-ede09d30930e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptMsgSignCTL(CertEncodingType dwMsgEncodingType, [In] IntPtr pbCtlContent, uint cbCtlContent, in CMSG_SIGNED_ENCODE_INFO pSignInfo,
		CryptMsgSignFlags dwFlags, [Out, Optional] IntPtr pbEncoded, ref uint pcbEncoded);

	/// <summary>
	/// The <c>CERT_CHAIN_ENGINE_CONFIG</c> structure sets parameters for building a non-default certificate chain engine. The engine
	/// used determines the ways that certificate chains are built.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The chain-building engine uses four certificate stores in building chains. These are hRoot, hWorld, hTrust, and hOther. These
	/// stores' handles are established by using information in this structure when a chain engine is created.
	/// </para>
	/// <para>
	/// hRoot is the store handle from <c>hRestrictedRoot</c> or, if <c>hRestrictedRoot</c> is <c>NULL</c>, the handle for System Store "Root."
	/// </para>
	/// <para>
	/// hWorld is a collection certificate store including sibling stores hRoot, "CA," "My," "Trust," and any additional stores whose
	/// handles are in the array pointed to by <c>rghAdditionalStore</c>.
	/// </para>
	/// <para>hTrust is the store handle from <c>hRestrictedTrust</c> or, if <c>hRestrictedTrust</c> is <c>NULL</c>, hWorld.</para>
	/// <para>
	/// hOther is <c>hRestrictedOther</c> plus hRoot or, if <c>hRestrictedTrust</c> is non- <c>NULL</c>, the hWorld collection store
	/// plus the store handle from <c>hRestrictedTrust</c>.
	/// </para>
	/// <para>
	/// Exclusive trust mode allows applications to specify trust anchors and peer-trusted certificates for certificate chain
	/// validation. In the exclusive trust mode, the root store and the trusted people store on the system are ignored, and the anchors
	/// and certificates pointed to by the <c>hExclusiveRoot</c> and <c>hExclusiveTrustedPeople</c> members are used instead.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_chain_engine_config typedef struct
	// _CERT_CHAIN_ENGINE_CONFIG { DWORD cbSize; HCERTSTORE hRestrictedRoot; HCERTSTORE hRestrictedTrust; HCERTSTORE hRestrictedOther;
	// DWORD cAdditionalStore; HCERTSTORE *rghAdditionalStore; DWORD dwFlags; DWORD dwUrlRetrievalTimeout; DWORD
	// MaximumCachedCertificates; DWORD CycleDetectionModulus; HCERTSTORE hExclusiveRoot; HCERTSTORE hExclusiveTrustedPeople; DWORD
	// dwExclusiveFlags; } CERT_CHAIN_ENGINE_CONFIG, *PCERT_CHAIN_ENGINE_CONFIG;
	[PInvokeData("wincrypt.h", MSDNShortId = "9e010eb9-2cbb-4fca-ba5c-4a5a50f23786")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_CHAIN_ENGINE_CONFIG
	{
		/// <summary>Size of this structure in bytes.</summary>
		public uint cbSize;

		/// <summary>
		/// This configuration parameter can be used to restrict the root store. If used, it can be the handle of any HCERTSTORE
		/// containing only a proper subset of the certificates in the root store.
		/// </summary>
		public HCERTSTORE hRestrictedRoot;

		/// <summary>Store handle. If used, restricts the stores searched to find CTLs.</summary>
		public HCERTSTORE hRestrictedTrust;

		/// <summary>Store handle. If used, restricts the stores searched for certificates and CRLs.</summary>
		public HCERTSTORE hRestrictedOther;

		/// <summary>Count of additional stores to be searched for certificates and CRLs needed to build chains.</summary>
		public uint cAdditionalStore;

		/// <summary>A pointer to an array of store handles for any additional stores to be searched in building chains.</summary>
		public IntPtr rghAdditionalStore;

		/// <summary>
		/// <para>The following flags are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_CHAIN_CACHE_END_CERT 0x00000001</term>
		/// <term>
		/// Information in the end certificate is cached. By default, information in all certificates except the end certificate is
		/// cached as a chain is built. Setting this flag extends the caching to the end certificate.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_CACHE_ONLY_URL_RETRIEVAL 0x00000004</term>
		/// <term>Use only cached URLs in building a certificate chain. The Internet and intranet are not searched for URL-based objects.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_USE_LOCAL_MACHINE_STORE 0x00000008</term>
		/// <term>Build the chain using the LocalMachine registry location as opposed to the CurrentUser location.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_ENABLE_CACHE_AUTO_UPDATE 0x00000010</term>
		/// <term>Enable automatic updating of the cache as a chain is being built.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_ENABLE_SHARE_STORE 0x00000020</term>
		/// <term>Allow certificate stores used to build the chain to be shared.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_DISABLE_AIA 0x00002000</term>
		/// <term>Turn off Authority Information Access (AIA) retrievals explicitly.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CertChainEngineFlags dwFlags;

		/// <summary>
		/// Number of milliseconds before a time-out for network based–URL object retrievals. Can be set to zero to use the default limit.
		/// </summary>
		public uint dwUrlRetrievalTimeout;

		/// <summary>
		/// Limit on the number of certificates that can be cached as a chain is built. Can be set to 0 to use the default limit.
		/// </summary>
		public uint MaximumCachedCertificates;

		/// <summary>
		/// <para>
		/// Number of certificates added to the chain before a check is made to determine whether there is a cycle of certificates in
		/// the chain. A cycle may be defined as having the same certificate in two different places in a chain.
		/// </para>
		/// <para>
		/// The lower the number, the more frequently checks will be made. Extra checking for cycles of certificates will slow the
		/// process considerably. This parameter can be set to zero to use the default limit.
		/// </para>
		/// </summary>
		public uint CycleDetectionModulus;

		/// <summary>
		/// <para>
		/// Handle to a certificate store that contains exclusive trust anchors. If either the <c>hExclusiveRoot</c> or
		/// <c>hExclusiveTrustedPeople</c> member points to a valid store, exclusive trust mode is used for the chain building.
		/// </para>
		/// <para><c>Windows 7 and Windows Server 2008 R2:</c> Support for this member begins.</para>
		/// </summary>
		public HCERTSTORE hExclusiveRoot;

		/// <summary>
		/// <para>
		/// Handle to a certificate store that contains application-specific peer trusted certificates. If either the
		/// <c>hExclusiveRoot</c> or <c>hExclusiveTrustedPeople</c> member points to a valid store, exclusive trust mode is used for the
		/// chain building.
		/// </para>
		/// <para><c>Windows 7 and Windows Server 2008 R2:</c> Support for this member begins.</para>
		/// </summary>
		public HCERTSTORE hExclusiveTrustedPeople;

		/// <summary>
		/// <para>
		/// The following flag can be set. The flag applies only if the <c>hExclusiveRoot</c> or <c>hExclusiveTrustedPeople</c> or both
		/// are not <c>NULL</c>.
		/// </para>
		/// <para><c>Windows 8 and Windows Server 2012:</c> Support for this member begins.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_CHAIN_EXCLUSIVE_ENABLE_CA_FLAG 0x00000001</term>
		/// <term>
		/// Indicates that a non-self-signed intermediate CA certificate in the hExclusiveRoot store should be treated as a trust anchor
		/// during certificate validation. If a certificate chains up to this CA, chain building is terminated and the certificate is
		/// considered trusted. No signature verification or revocation checking is performed on the CA certificate. By default, if this
		/// flag is not set, only self-signed certificates in the hExclusiveRoot store are treated as trust anchors. See also the
		/// CERT_TRUST_IS_CA_TRUSTED value in the CERT_TRUST_STATUS structure.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CertChainEngineExclusiveFlags dwExclusiveFlags;
	}

	/// <summary>
	/// The <c>CERT_CHAIN_PARA</c> structure establishes the searching and matching criteria to be used in building a certificate chain.
	/// </summary>
	/// <remarks>
	/// <para>The following remarks apply when checking for strong signatures.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Set the <c>pStrongSignPara</c> member to check for strong signatures when using the CertGetCertificateChain or
	/// CertSelectCertificateChains function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If a certificate without a strong signature is found in the chain, the <c>CERT_TRUST_HAS_WEAK_SIGNATURE</c> and
	/// <c>CERT_TRUST_IS_NOT_SIGNATURE_VALID</c> errors are set in the <c>dwErrorStatus</c> field of the CERT_TRUST_STATUS structure.
	/// The ppChainContext parameter of the CertGetCertificateChain function and the pprgpSelection parameter of the
	/// CertSelectCertificateChains function point to a CERT_CHAIN_CONTEXT structure which, in turn, points to the
	/// <c>CERT_TRUST_STATUS</c> structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the chain is strong signed, the public key in the end certificate is checked to determine whether it satisfies the minimum
	/// public key length requirements for a strong signature. If the condition is not satisfied, the
	/// <c>CERT_TRUST_HAS_WEAK_SIGNATURE</c> and <c>CERT_TRUST_IS_NOT_SIGNATURE_VALID</c> errors are set in the <c>dwErrorStatus</c>
	/// field of the CERT_TRUST_STATUS structure. Set the <c>CERT_CHAIN_STRONG_SIGN_DISABLE_END_CHECK_FLAG</c> value in the
	/// <c>dwStrongSignFlags</c> member to disable this check.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the <c>CERT_STRONG_SIGN_ENABLE_CRL_CHECK</c> or <c>CERT_STRONG_SIGN_ENABLE_OCSP_CHECK</c> flags are set in the
	/// CERT_STRONG_SIGN_SERIALIZED_INFO structure referenced by the CERT_STRONG_SIGN_PARA structure pointed to by the
	/// <c>pStrongSignPara</c> member, and a CRL or OCSP response is found without a strong signature, the CRL or OCSP response will be
	/// treated as being offline. That is, the <c>CERT_TRUST_IS_OFFLINE_REVOCATION</c> and <c>CERT_TRUST_REVOCATION_STATUS_UNKNOWN</c>
	/// errors are set in the <c>dwErrorStatus</c> field of the CERT_TRUST_STATUS structure. Also, the <c>dwRevocationResult</c> member
	/// of the CERT_REVOCATION_INFO structure is set to <c>NTE_BAD_ALGID</c>.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_chain_para typedef struct _CERT_CHAIN_PARA { DWORD
	// cbSize; CERT_USAGE_MATCH RequestedUsage; CERT_USAGE_MATCH RequestedIssuancePolicy; DWORD dwUrlRetrievalTimeout; BOOL
	// fCheckRevocationFreshnessTime; DWORD dwRevocationFreshnessTime; LPFILETIME pftCacheResync; PCCERT_STRONG_SIGN_PARA
	// pStrongSignPara; DWORD dwStrongSignFlags; } CERT_CHAIN_PARA, *PCERT_CHAIN_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "86094e1c-be59-4a15-a05b-21769f80e653")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_CHAIN_PARA
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// Structure indicating the kind of matching necessary to find issuer certificates for building a certificate chain. The
		/// structure pointed to indicates whether AND or OR logic is to be used in the matching process. The structure also includes an
		/// array of OIDs to be matched.
		/// </summary>
		public CERT_USAGE_MATCH RequestedUsage;

		/// <summary>
		/// <para>
		/// Optional structure that indicates the kind of issuance policy constraint matching that applies when building a certificate
		/// chain. The structure pointed to indicates whether AND or OR logic is to be used in the matching process. The structure also
		/// includes an array of OIDs to be matched.
		/// </para>
		/// <para>
		/// <c>Note</c> This member can be used only if <c>CERT_CHAIN_PARA_HAS_EXTRA_FIELDS</c> is defined by using the <c>#define</c>
		/// directive before including Wincrypt.h. If this value is defined, the application must zero all unused fields.
		/// </para>
		/// </summary>
		public CERT_USAGE_MATCH RequestedIssuancePolicy;

		/// <summary>
		/// <para>Optional time, in milliseconds, before revocation checking times out. This member is optional.</para>
		/// <para>
		/// <c>Note</c> This member can be used only if <c>CERT_CHAIN_PARA_HAS_EXTRA_FIELDS</c> is defined by using the <c>#define</c>
		/// directive before including Wincrypt.h. If this value is defined, the application must zero all unused fields.
		/// </para>
		/// </summary>
		public uint dwUrlRetrievalTimeout;

		/// <summary>
		/// <para>
		/// Optional member. When this flag is <c>TRUE</c>, an attempt is made to retrieve a new CRL if this update is greater than or
		/// equal to the current system time minus the <c>dwRevocationFreshnessTime</c> value. If this flag is not set, the CRL's next
		/// update time is used.
		/// </para>
		/// <para>
		/// <c>Note</c> This member can be used only if <c>CERT_CHAIN_PARA_HAS_EXTRA_FIELDS</c> is defined by using the <c>#define</c>
		/// directive before including Wincrypt.h. If this value is defined, the application must zero all unused fields.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fCheckRevocationFreshnessTime;

		/// <summary>
		/// <para>The current time, in seconds, minus the CRL's update time of all elements checked.</para>
		/// <para>
		/// <c>Note</c> This member can be used only if <c>CERT_CHAIN_PARA_HAS_EXTRA_FIELDS</c> is defined by using the <c>#define</c>
		/// directive before including Wincrypt.h. If this value is defined, the application must zero all unused fields.
		/// </para>
		/// </summary>
		public uint dwRevocationFreshnessTime;

		/// <summary>
		/// <para>
		/// Optional member. When set to a non- <c>NULL</c> value, information cached before the time specified is considered to be not
		/// valid and cache resynchronization is performed.
		/// </para>
		/// <para><c>Windows Vista:</c> Support for this member begins.</para>
		/// <para>
		/// <c>Note</c> This member can be used only if <c>CERT_CHAIN_PARA_HAS_EXTRA_FIELDS</c> is defined by using the <c>#define</c>
		/// directive before including Wincrypt.h. If this value is defined, the application must zero all unused fields.
		/// </para>
		/// </summary>
		public IntPtr pftCacheResync;

		/// <summary>
		/// <para>Optional. Specify a pointer to a CERT_STRONG_SIGN_PARA structure to enable strong signature checking.</para>
		/// <para><c>Windows 8 and Windows Server 2012:</c> Support for this member begins.</para>
		/// <para>
		/// <c>Note</c> This member can be used only if <c>CERT_CHAIN_PARA_HAS_EXTRA_FIELDS</c> is defined by using the <c>#define</c>
		/// directive before including Wincrypt.h. If this value is defined, the application must zero all unused fields.
		/// </para>
		/// </summary>
		public IntPtr pStrongSignPara;

		/// <summary>
		/// <para>Optional flags that modify chain retrieval behavior. This can be zero or the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_CHAIN_STRONG_SIGN_DISABLE_END_CHECK_FLAG 0x00000001</term>
		/// <term>
		/// If the chain is strong signed, the public key in the end certificate will be checked to verify whether it satisfies the
		/// minimum public key length requirements for a strong signature. You can specify CERT_CHAIN_STRONG_SIGN_DISABLE_END_CHECK_FLAG
		/// to disable default checking.
		/// </term>
		/// </item>
		/// </list>
		/// <para><c>Windows 8 and Windows Server 2012:</c> Support for this property begins.</para>
		/// <para>
		/// <c>Note</c> This member can be used only if <c>CERT_CHAIN_PARA_HAS_EXTRA_FIELDS</c> is defined by using the <c>#define</c>
		/// directive before including Wincrypt.h. If this value is defined, the application must zero all unused fields.
		/// </para>
		/// </summary>
		public uint dwStrongSignFlags;
	}

	/// <summary>
	/// The <c>CERT_CHAIN_POLICY_PARA</c> structure contains information used in CertVerifyCertificateChainPolicy to establish policy
	/// criteria for the verification of certificate chains.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_chain_policy_para typedef struct
	// _CERT_CHAIN_POLICY_PARA { DWORD cbSize; DWORD dwFlags; void *pvExtraPolicyPara; } CERT_CHAIN_POLICY_PARA, *PCERT_CHAIN_POLICY_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "5e4fffcb-132b-42c0-81b2-9f866e274c32")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_CHAIN_POLICY_PARA
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>
		/// A set of flags that indicate conditions that could potentially be not valid and that are to be ignored in building
		/// certificate chains.
		/// </para>
		/// <para>The pszPolicyOID parameter of the CertVerifyCertificateChainPolicy function can contain one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>CERT_CHAIN_POLICY_BASE</c></term>
		/// </item>
		/// <item>
		/// <term><c>CERT_CHAIN_POLICY_AUTHENTICODE</c></term>
		/// </item>
		/// <item>
		/// <term><c>CERT_CHAIN_POLICY_AUTHENTICODE_TS</c></term>
		/// </item>
		/// <item>
		/// <term><c>CERT_CHAIN_POLICY_SSL</c></term>
		/// </item>
		/// <item>
		/// <term><c>CERT_CHAIN_POLICY_NT_AUTH</c></term>
		/// </item>
		/// </list>
		/// <para>If the</para>
		/// <para>pszPolicyOID</para>
		/// <para>parameter of the</para>
		/// <para>CertVerifyCertificateChainPolicy</para>
		/// <para>
		/// function contains one of the preceding values, then this member can be zero or a combination of one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_NOT_TIME_VALID_FLAG</term>
		/// <term>Ignore not time valid errors.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_CTL_NOT_TIME_VALID_FLAG</term>
		/// <term>Ignore certificate trust list (CTL) not time valid errors.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_NOT_TIME_NESTED_FLAG</term>
		/// <term>Ignore time nesting errors.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_ALL_NOT_TIME_VALID_FLAGS</term>
		/// <term>Ignore all time validity errors.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_INVALID_BASIC_CONSTRAINTS_FLAG</term>
		/// <term>Ignore basic constraint errors.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_ALLOW_UNKNOWN_CA_FLAG</term>
		/// <term>Allow untrusted roots.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_WRONG_USAGE_FLAG</term>
		/// <term>Ignore invalid usage errors.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_INVALID_NAME_FLAG</term>
		/// <term>Ignore invalid name errors.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_INVALID_POLICY_FLAG</term>
		/// <term>Ignore invalid policy errors.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_END_REV_UNKNOWN_FLAG</term>
		/// <term>Ignores errors in obtaining valid revocation information.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_CTL_SIGNER_REV_UNKNOWN_FLAG</term>
		/// <term>Ignores errors in obtaining valid CTL revocation information.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_CA_REV_UNKNOWN_FLAG</term>
		/// <term>Ignores errors in obtaining valid certification authority (CA) revocation information.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_ROOT_REV_UNKNOWN_FLAG</term>
		/// <term>Ignores errors in obtaining valid root revocation information.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_ALL_REV_UNKNOWN_FLAGS</term>
		/// <term>Ignores errors in obtaining valid revocation information.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_ALLOW_TESTROOT_FLAG</term>
		/// <term>Allow untrusted test roots.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_TRUST_TESTROOT_FLAG</term>
		/// <term>Always trust test roots.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_NOT_SUPPORTED_CRITICAL_EXT_FLAG</term>
		/// <term>Ignore critical extension not supported errors.</term>
		/// </item>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_PEER_TRUST_FLAG</term>
		/// <term>Ignore peer trusts.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the pszPolicyOID parameter of the CertVerifyCertificateChainPolicy function contains
		/// <c>CERT_CHAIN_POLICY_BASIC_CONSTRAINTS</c>, this member can be zero or a combination of one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_CHAIN_POLICY_IGNORE_PEER_TRUST_FLAG</term>
		/// <term>Ignore peer trusts.</term>
		/// </item>
		/// <item>
		/// <term>BASIC_CONSTRAINTS_CERT_CHAIN_POLICY_CA_FLAG</term>
		/// <term>Checks if the first certificate element is a CA.</term>
		/// </item>
		/// <item>
		/// <term>BASIC_CONSTRAINTS_CERT_CHAIN_POLICY_END_ENTITY_FLAG</term>
		/// <term>Checks if the first certificate element is an end entity.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the pszPolicyOID parameter of the CertVerifyCertificateChainPolicy function contains
		/// <c>CERT_CHAIN_POLICY_MICROSOFT_ROOT</c>, this member can be zero or the following value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MICROSOFT_ROOT_CERT_CHAIN_POLICY_ENABLE_TEST_ROOT_FLAG</term>
		/// <term>Also check for the Microsoft test roots in addition to the Microsoft public root.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CertChainPolicyFlags dwFlags;

		/// <summary>The address of a pszPolicyOID-specific structure that provides additional validity policy conditions.</summary>
		public IntPtr pvExtraPolicyPara;
	}

	/// <summary>
	/// The <c>CERT_CHAIN_POLICY_STATUS</c> structure holds certificate chain status information returned by the
	/// CertVerifyCertificateChainPolicy function when the certificate chains are validated.
	/// </summary>
	/// <remarks>
	/// If both <c>lChainIndex</c> and <c>lElementIndex</c> are set to –1, the error or condition that is not valid applies to the whole
	/// chain context. If only <c>lElementIndex</c> is set to –1, the error or condition that is not valid applies to the chain indexed
	/// by <c>lChainIndex</c>. Otherwise, the error or condition that is not valid applies to the certificate element at
	/// pChainContext-&gt;rgpChain[ <c>lChainIndex</c>]-&gt;rgpElement[ <c>lElementIndex</c>].
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_chain_policy_status typedef struct
	// _CERT_CHAIN_POLICY_STATUS { DWORD cbSize; DWORD dwError; LONG lChainIndex; LONG lElementIndex; void *pvExtraPolicyStatus; }
	// CERT_CHAIN_POLICY_STATUS, *PCERT_CHAIN_POLICY_STATUS;
	[PInvokeData("wincrypt.h", MSDNShortId = "599a09b6-fe9e-4489-99ae-8a88fa78a660")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_CHAIN_POLICY_STATUS
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>
		/// A value that indicates that an error or invalid condition was encountered during the validation process. The values of this
		/// member are specific to the policy type as specified by the value of the pszPolicyOID parameter of the
		/// CertVerifyCertificateChainPolicy function.
		/// </para>
		/// <para>Base Policy errors ( <c>CERT_CHAIN_POLICY_BASE</c>)</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUST_E_CERT_SIGNATURE 0x80096004L</term>
		/// <term>The signature of the certificate cannot be verified.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_E_REVOKED 0x80092010L</term>
		/// <term>The certificate or signature has been revoked.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_UNTRUSTEDROOT 0x800B0109L</term>
		/// <term>A certification chain processed correctly but terminated in a root certificate that is not trusted by the trust provider.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_UNTRUSTEDTESTROOT 0x800B010DL</term>
		/// <term>The root certificate is a testing certificate, and policy settings disallow test certificates.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_CHAINING 0x800B010AL</term>
		/// <term>A chain of certificates was not correctly created.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_WRONG_USAGE 0x800B0110L</term>
		/// <term>The certificate is not valid for the requested usage.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_EXPIRED 0x800B0101L</term>
		/// <term>A required certificate is not within its validity period.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_INVALID_NAME 0x800B0114L</term>
		/// <term>The certificate has an invalid name. Either the name is not included in the permitted list, or it is explicitly excluded.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_INVALID_POLICY 0x800B0113L</term>
		/// <term>The certificate has an invalid policy.</term>
		/// </item>
		/// <item>
		/// <term>TRUST_E_BASIC_CONSTRAINTS 0x80096019L</term>
		/// <term>The basic constraints of the certificate are not valid, or they are missing.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_CRITICAL 0x800B0105L</term>
		/// <term>The certificate is being used for a purpose other than the purpose specified by its CA.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_VALIDITYPERIODNESTING 0x800B0102L</term>
		/// <term>The validity periods of the certification chain do not nest correctly.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_E_NO_REVOCATION_CHECK 0x80092012L</term>
		/// <term>The revocation function was unable to check revocation for the certificate.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_E_REVOCATION_OFFLINE 0x80092013L</term>
		/// <term>The revocation function was unable to check revocation because the revocation server was offline.</term>
		/// </item>
		/// </list>
		/// <para>Basic Constraints Policy errors ( <c>CERT_CHAIN_POLICY_BASIC_CONSTRAINTS</c>).</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUST_E_BASIC_CONSTRAINTS 0x80096019L</term>
		/// <term>The basic constraints of the certificate are not valid, or they are missing.</term>
		/// </item>
		/// </list>
		/// <para>Authenticode Policy errors ( <c>CERT_CHAIN_POLICY_AUTHENTICODE</c> and <c>CERT_CHAIN_POLICY_AUTHENTICODE_TS</c>).</para>
		/// <para>These errors are in addition to the Base Policy errors.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_E_PURPOSE 0x800B0106L</term>
		/// <term>The certificate is being used for a purpose other than one specified by the issuing CA.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_REVOKED 0x800B010CL</term>
		/// <term>The certificate has been explicitly revoked by the issuer.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_REVOCATION_FAILURE 0x800B010EL</term>
		/// <term>The revocation process could not continue, and the certificate could not be checked.</term>
		/// </item>
		/// </list>
		/// <para>SSL Policy errors ( <c>CERT_CHAIN_POLICY_SSL</c>).</para>
		/// <para>These errors are in addition to the Base Policy errors.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_E_UNTRUSTEDROOT 0x800B0109L</term>
		/// <term>A certification chain processed correctly but terminated in a root certificate that is not trusted by the trust provider.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_CN_NO_MATCH 0x800B010FL</term>
		/// <term>The certificate's CN name does not match the passed value.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_PURPOSE 0x800B0106L</term>
		/// <term>The certificate is being used for a purpose other than the purposes specified by its CA.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_ROLE 0x800B0103L</term>
		/// <term>A certificate that can only be used as an end-entity is being used as a CA or vice versa.</term>
		/// </item>
		/// </list>
		/// <para>Microsoft Root Policy errors ( <c>CERT_CHAIN_POLICY_MICROSOFT_ROOT</c>).</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_E_UNTRUSTEDROOT 0x800B0109L</term>
		/// <term>A certification chain processed correctly but terminated in a root certificate that is not trusted by the trust provider.</term>
		/// </item>
		/// </list>
		/// <para>EV Policy errors.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_E_CHAINING 0x800B010AL</term>
		/// <term>The certificate chain to a trusted root authority could not be built.</term>
		/// </item>
		/// <item>
		/// <term>CERT_E_WRONG_USAGE 0x800B0110L</term>
		/// <term>The certificate is not valid for the requested usage.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwError;

		/// <summary>
		/// Index that indicates the chain in which an error or condition that is not valid was found. For more information, see Remarks.
		/// </summary>
		public int lChainIndex;

		/// <summary>
		/// Index that indicates the element in a chain where an error or condition that is not valid was found. For more information,
		/// see Remarks.
		/// </summary>
		public int lElementIndex;

		/// <summary>
		/// A pointer to a structure. The structure type is determined by the value of the <c>pszPolicyOID</c> parameter of the
		/// CertVerifyCertificateChainPolicy function. In addition to <c>dwError</c> errors, policy OID–specific extra status can also
		/// be returned here to provide additional chain status information. This pointer can be optionally set to point to an
		/// AUTHENTICODE_EXTRA_CERT_CHAIN_POLICY_STATUS structure.
		/// </summary>
		public IntPtr pvExtraPolicyStatus;
	}

	/// <summary>
	/// The <c>CERT_USAGE_MATCH</c> structure provides criteria for identifying issuer certificates to be used to build a certificate chain.
	/// </summary>
	/// <remarks>
	/// <para>If the dwType member is set to <c>USAGE_MATCH_TYPE_OR</c>, the Usage member cannot be empty.</para>
	/// <para>
	/// If the dwType member is set to <c>USAGE_MATCH_TYPE_AND</c>, an empty Usage member means that any nested usage in the chain will work.
	/// </para>
	/// <para>The following describes the behavior given two enhanced key usage (EKU) extensions EKU A and EKU B.</para>
	/// <para>AND Logic</para>
	/// <para>
	/// If the caller specifies EKU A AND EKU B then the target certificate is valid if EKU A and EKU B are supported by every
	/// certificate in the path (either by an explicit EKU setting or through an absent EKU extension in CA certificates.)
	/// </para>
	/// <para>OR Logic</para>
	/// <para>
	/// If the caller specifies EKU A OR EKU B then the target certificate is valid if either EKU A or EKU B is supported in the path.
	/// </para>
	/// <para>
	/// Besides the simple case where the certificates in the path contain EKU A or EKU B, the <c>OR</c> clause has the following
	/// special evaluation.
	/// </para>
	/// <para>Given the following path, the <c>OR</c> test is deemed valid:</para>
	/// <para>
	/// Although the intersection of the EKUs in the chain is an empty set, the use of the EE certificate is valid for EKU A because the
	/// request to the cryptography API specifies that the certificate is valid if each certificate of the path supports either EKU A OR
	/// EKU B.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_usage_match typedef struct _CERT_USAGE_MATCH { DWORD
	// dwType; CERT_ENHKEY_USAGE Usage; } CERT_USAGE_MATCH, *PCERT_USAGE_MATCH;
	[PInvokeData("wincrypt.h", MSDNShortId = "6154f1f7-4293-4b8e-91ab-9f57bb6f5743")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_USAGE_MATCH
	{
		/// <summary>
		/// <para>
		/// Determines the kind of issuer matching to be done. In <c>AND</c> logic, the certificate must meet all criteria. In <c>OR</c>
		/// logic, the certificate must meet at least one of the criteria. The following codes are defined to determine the logic used
		/// in the match. For more information about how this applied, see Remarks.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>USAGE_MATCH_TYPE_AND</term>
		/// <term>AND logic</term>
		/// </item>
		/// <item>
		/// <term>USAGE_MATCH_TYPE_OR</term>
		/// <term>OR logic</term>
		/// </item>
		/// </list>
		/// <para>Default usage match logic is USAGE_MATCH_TYPE_AND.</para>
		/// </summary>
		public UsageMatchType dwType;

		/// <summary>
		/// CERT_ENHKEY_USAGE structure ( <c>CERT_ENHKEY_USAGE</c> is an alternate typedef name for the <c>CTL_USAGE</c> structure) that
		/// includes an array of certificate object identifiers (OIDs) that a certificate must match in order to be valid.
		/// </summary>
		public CTL_USAGE Usage;
	}

	/// <summary>
	/// The <c>CMSG_SIGNED_ENCODE_INFO</c> structure contains information to be passed to CryptMsgOpenToEncode if dwMsgType is CMSG_SIGNED.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_signed_encode_info typedef struct
	// _CMSG_SIGNED_ENCODE_INFO { DWORD cbSize; DWORD cSigners; PCMSG_SIGNER_ENCODE_INFO rgSigners; DWORD cCertEncoded; PCERT_BLOB
	// rgCertEncoded; DWORD cCrlEncoded; PCRL_BLOB rgCrlEncoded; DWORD cAttrCertEncoded; PCERT_BLOB rgAttrCertEncoded; }
	// CMSG_SIGNED_ENCODE_INFO, *PCMSG_SIGNED_ENCODE_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "93138744-8316-461b-908a-1eab47e83f63")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_SIGNED_ENCODE_INFO
	{
		/// <summary>Size of this structure in bytes.</summary>
		public uint cbSize;

		/// <summary>Number of elements in the <c>rgSigners</c> array.</summary>
		public uint cSigners;

		/// <summary>Array of pointers to CMSG_SIGNER_ENCODE_INFOstructures each holding signer information.</summary>
		public IntPtr rgSigners;

		/// <summary>Number of elements in the <c>rgCertEncoded</c> array.</summary>
		public uint cCertEncoded;

		/// <summary>Array of pointers to CERT_BLOB structures, each containing an encoded certificate.</summary>
		public IntPtr rgCertEncoded;

		/// <summary>Number of elements in the <c>rgCrlEncoded</c> array.</summary>
		public uint cCrlEncoded;

		/// <summary>Array of pointers to CRL_BLOB structures, each containing an encoded CRL.</summary>
		public IntPtr rgCrlEncoded;

		/// <summary>
		/// Number of elements in the <c>rgAttrCertEncoded</c> array. Used only if CMSG_SIGNED_ENCODE_INFO_HAS_CMS_FIELDS is defined.
		/// </summary>
		public uint cAttrCertEncoded;

		/// <summary>
		/// Array of encoded attribute certificates. Used only if CMSG_SIGNED_ENCODE_INFO_HAS_CMS_FIELDS is defined. This array of
		/// encoded attribute certificates can be used with CMS for PKCS #7 processing.
		/// </summary>
		public IntPtr rgAttrCertEncoded;
	}

	/// <summary>
	/// The <c>CTL_VERIFY_USAGE_PARA</c> structure contains parameters used by CertVerifyCTLUsage to establish the validity of a CTL's usage.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-ctl_verify_usage_para typedef struct
	// _CTL_VERIFY_USAGE_PARA { DWORD cbSize; CRYPT_DATA_BLOB ListIdentifier; DWORD cCtlStore; HCERTSTORE *rghCtlStore; DWORD
	// cSignerStore; HCERTSTORE *rghSignerStore; } CTL_VERIFY_USAGE_PARA, *PCTL_VERIFY_USAGE_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "bf9a3c81-f8c4-45a6-b045-8cbefebebbd3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CTL_VERIFY_USAGE_PARA
	{
		/// <summary>Size of this structure in bytes.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>
		/// BLOB that specifies a <c>ListIdentifier</c> of a CTL to be found or verified. Normally the <c>cbData</c> member of the
		/// <c>ListIdentifier</c> BLOB will be zero, indicating that a CTL with any <c>ListIdentifier</c> can be a match.
		/// </para>
		/// <para>
		/// To match only CTLs with no <c>ListIdentifier</c>, the <c>cbData</c> member of the <c>ListIdentifier</c> BLOB is set to CTL_FIND_NO_LIST_ID_CBDATA.
		/// </para>
		/// <para>
		/// If an issuer creates multiple CTLs for the same <c>SubjectUsage</c>, a <c>ListIdentifier</c> can distinguish among them.
		/// </para>
		/// </summary>
		public CRYPTOAPI_BLOB ListIdentifier;

		/// <summary>The count of stores to be searched for a matching CTL.</summary>
		public uint cCtlStore;

		/// <summary>Array of handles of stores to be searched to find a matching CTL.</summary>
		public IntPtr rghCtlStore;

		/// <summary>Count of stores to be searched for acceptable CTL signers.</summary>
		public uint cSignerStore;

		/// <summary>Array of handles of stores to be searched for acceptable CTL signers.</summary>
		public IntPtr rghSignerStore;
	}

	/// <summary>
	/// The <c>CTL_VERIFY_USAGE_STATUS</c> structure contains information about a Certificate Trust List (CTL) returned by CertVerifyCTLUsage.
	/// </summary>
	/// <remarks>
	/// The members <c>dwError</c>, <c>dwFlags</c>, <c>dwCtlEntryIndex</c>, and <c>dwSignerIndex</c> should be initialized to zero by
	/// the calling application.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-ctl_verify_usage_status typedef struct
	// _CTL_VERIFY_USAGE_STATUS { DWORD cbSize; DWORD dwError; DWORD dwFlags; PCCTL_CONTEXT *ppCtl; DWORD dwCtlEntryIndex;
	// PCCERT_CONTEXT *ppSigner; DWORD dwSignerIndex; } CTL_VERIFY_USAGE_STATUS, *PCTL_VERIFY_USAGE_STATUS;
	[PInvokeData("wincrypt.h", MSDNShortId = "2b7ef953-9422-4dcf-b293-a78a06bb080e")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CTL_VERIFY_USAGE_STATUS
	{
		/// <summary>
		/// The size, in bytes, of the structure. The application calling CertVerifyCTLUsage sets this parameter. If <c>cbSize</c> is
		/// not greater than or equal to the required size of the structure, <c>CertVerifyCTLUsage</c> returns <c>FALSE</c> and
		/// GetLastError returns <c>E_INVALIDARG</c>.
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// The error status, if any, returned by the call to CertVerifyCTLUsage. For the list of possible error values, see the Return
		/// Values section in <c>CertVerifyCTLUsage</c>.
		/// </summary>
		public uint dwError;

		/// <summary>
		/// If <c>CERT_VERIFY_UPDATED_CTL_FLAG</c> is returned, CertVerifyCTLUsage updated a CTL whose time was no longer valid with a
		/// new, time-valid CTL.
		/// </summary>
		public CtlVerifyUsageStatusFlags dwFlags;

		/// <summary>
		/// <para>
		/// Pointer to a pointer to a CTL context containing the matched subject. The calling application can set this pointer to
		/// <c>NULL</c> to indicate that a CTL containing the subject is not to be returned.
		/// </para>
		/// <para>If <c>ppCtl</c> is not <c>NULL</c>, the calling application must free the returned context using CertFreeCTLContext.</para>
		/// </summary>
		public IntPtr ppCtl;

		/// <summary>Returns the array location of the matching subject's entry in the CTL's array.</summary>
		public uint dwCtlEntryIndex;

		/// <summary>
		/// <para>
		/// A pointer to a pointer to the certificate context of the signer of the CTL. This pointer can be set to <c>NULL</c> by the
		/// calling application indicating that the certificate of the signer of the CTL is not to be returned.
		/// </para>
		/// <para>If <c>ppSigner</c> is not <c>NULL</c>, the calling application must free the returned context using CertFreeCTLContext.</para>
		/// </summary>
		public IntPtr ppSigner;

		/// <summary>Index of the signer actually used. Needed if a message has more than one signer.</summary>
		public uint dwSignerIndex;
	}

	/// <summary>Provides a handle to a CERT_CHAIN_CONTEXT.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct PCCERT_CHAIN_CONTEXT : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="PCCERT_CHAIN_CONTEXT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public PCCERT_CHAIN_CONTEXT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="PCCERT_CHAIN_CONTEXT"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static PCCERT_CHAIN_CONTEXT NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="PCCERT_CHAIN_CONTEXT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(PCCERT_CHAIN_CONTEXT h) => h.handle;

		/// <summary>Performs an explicit conversion from <see cref="PCCERT_CHAIN_CONTEXT"/> to <see cref="CERT_CHAIN_CONTEXT"/>.</summary>
		/// <param name="h">The <see cref="PCCERT_CHAIN_CONTEXT"/> instance.</param>
		/// <returns>The resulting <see cref="CERT_CHAIN_CONTEXT"/> instance from the conversion.</returns>
		public static explicit operator CERT_CHAIN_CONTEXT(PCCERT_CHAIN_CONTEXT h) => h.handle.ToStructure<CERT_CHAIN_CONTEXT>();

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PCCERT_CHAIN_CONTEXT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PCCERT_CHAIN_CONTEXT(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(PCCERT_CHAIN_CONTEXT h1, PCCERT_CHAIN_CONTEXT h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(PCCERT_CHAIN_CONTEXT h1, PCCERT_CHAIN_CONTEXT h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is PCCERT_CHAIN_CONTEXT h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HCERTCHAINENGINE"/> that is disposed using <see cref="CertFreeCertificateChainEngine"/>.</summary>
	public class SafeHCERTCHAINENGINE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHCERTCHAINENGINE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHCERTCHAINENGINE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHCERTCHAINENGINE"/> class.</summary>
		private SafeHCERTCHAINENGINE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHCERTCHAINENGINE"/> to <see cref="HCERTCHAINENGINE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HCERTCHAINENGINE(SafeHCERTCHAINENGINE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { CertFreeCertificateChainEngine(handle); return true; }
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="PCCERT_CHAIN_CONTEXT"/> that is disposed using <see cref="CertFreeCertificateChain"/>.</summary>
	public class SafePCCERT_CHAIN_CONTEXT : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafePCCERT_CHAIN_CONTEXT"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafePCCERT_CHAIN_CONTEXT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafePCCERT_CHAIN_CONTEXT"/> class.</summary>
		private SafePCCERT_CHAIN_CONTEXT() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafePCCERT_CHAIN_CONTEXT"/> to <see cref="PCCERT_CHAIN_CONTEXT"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PCCERT_CHAIN_CONTEXT(SafePCCERT_CHAIN_CONTEXT h) => h.handle;

		/// <summary>Performs an explicit conversion from <see cref="SafePCCERT_CHAIN_CONTEXT"/> to <see cref="CERT_CHAIN_CONTEXT"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The resulting <see cref="CERT_CHAIN_CONTEXT"/> instance from the conversion.</returns>
		public static explicit operator CERT_CHAIN_CONTEXT(SafePCCERT_CHAIN_CONTEXT h) => h.handle.ToStructure<CERT_CHAIN_CONTEXT>();

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { CertFreeCertificateChain(handle); return true; }
	}

	/// <summary>Predefined verify chain policies.</summary>
	public static class CertVerifyChainPolicy
	{
		/// <summary/>
		public const int CERT_CHAIN_POLICY_BASE = 1;
		/// <summary/>
		public const int CERT_CHAIN_POLICY_AUTHENTICODE = 2;
		/// <summary/>
		public const int CERT_CHAIN_POLICY_AUTHENTICODE_TS = 3;
		/// <summary/>
		public const int CERT_CHAIN_POLICY_SSL = 4;
		/// <summary/>
		public const int CERT_CHAIN_POLICY_BASIC_CONSTRAINTS = 5;
		/// <summary/>
		public const int CERT_CHAIN_POLICY_NT_AUTH = 6;
		/// <summary/>
		public const int CERT_CHAIN_POLICY_MICROSOFT_ROOT = 7;
		/// <summary/>
		public const int CERT_CHAIN_POLICY_EV = 8;
		/// <summary/>
		public const int CERT_CHAIN_POLICY_SSL_F12 = 9;
		/// <summary/>
		public const int CERT_CHAIN_POLICY_SSL_HPKP_HEADER = 10;
		/// <summary/>
		public const int CERT_CHAIN_POLICY_THIRD_PARTY_ROOT = 11;
		/// <summary/>
		public const int CERT_CHAIN_POLICY_SSL_KEY_PIN = 12;
	}
}