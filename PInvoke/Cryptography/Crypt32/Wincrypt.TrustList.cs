namespace Vanara.PInvoke;

/// <summary>Methods and data types found in Crypt32.dll.</summary>
public static partial class Crypt32
{
	/// <summary>The <c>CertAddCTLContextToStore</c> function adds a certificate trust list (CTL) context to a certificate store.</summary>
	/// <param name="hCertStore">Handle of a certificate store.</param>
	/// <param name="pCtlContext">A pointer to the CTL_CONTEXT structure to be added to the store.</param>
	/// <param name="dwAddDisposition">
	/// <para>
	/// Specifies the action to take if a matching CTL or a link to a matching CTL already exists in the store. Currently defined
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
	/// Makes no check for an existing matching CTL or link to a matching CTL. A new CTL is always added to the store. This can lead to
	/// duplicates in a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEW</term>
	/// <term>If a matching CTL or a link to a matching CTL exists, the operation fails. GetLastError returns the CRYPT_E_EXISTS code.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEWER</term>
	/// <term>
	/// If a matching CTL or a link to a matching CTL exists, the ThisUpdate times on the CTLs are compared. If the existing CTL has a
	/// ThisUpdate time less than the ThisUpdate time on the new CTL, the old CTL or link is replaced just as with
	/// CERT_STORE_ADD_REPLACE_EXISTING. If the existing CTL has a ThisUpdate time greater than or equal to the ThisUpdate time on the
	/// CTL to be added, the function fails with GetLastError returning the CRYPT_E_EXISTS code. If a matching CTL or a link to a
	/// matching CTL is not found in the store, a new CTL is added to the store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEWER_INHERIT_PROPERTIES</term>
	/// <term>
	/// The action is the same as for CERT_STORE_ADD_NEWER, except that if an older CTL is replaced, the properties of the older CTL are
	/// incorporated into the replacement CTL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
	/// <term>
	/// If a matching CTL or a link to a matching CTL exists, the existing CTL or link is deleted and a new CTL is created and added to
	/// the store. If a matching CTL or a link to a matching CTL does not exist, one is added.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING_INHERIT_PROPERTIES</term>
	/// <term>
	/// If a matching CTL exists in the store, that existing context is deleted before creating and adding the new context. The added
	/// context inherits properties from the existing CTL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_USE_EXISTING</term>
	/// <term>
	/// If a matching CTL or a link to a matching CTL exists, that existing CTL is used and properties from the new CTL are added. The
	/// function does not fail, but no new CTL is added. If ppCertContext is not NULL, the existing context is duplicated. If a matching
	/// CTL or a link to a matching CTL does not exist, a new CTL is added.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppStoreContext">
	/// Pointer to a pointer to the decoded CTL context. This optional parameter can be <c>NULL</c> indicating that the calling
	/// application does not require a copy of the added or existing CTL. If a copy is made, that context must be freed using CertFreeCTLContext.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, the return value is <c>FALSE</c>. Errors from the called functions CertAddEncodedCRLToStore and
	/// CertSetCRLContextProperty can be propagated to this function.
	/// </para>
	/// <para>For extended error information, call GetLastError. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_EXISTS</term>
	/// <term>
	/// This error is returned if CERT_STORE_ADD_NEW is set and the CTL exists in the store or if CERT_STORE_ADD_NEWER is set and a CTL
	/// exists in the store with a ThisUpdate date greater than or equal to the ThisUpdate date on the CTL to be added.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>An add disposition that is not valid was specified by the dwAddDisposition parameter.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The CTL context is not duplicated using CertDuplicateCTLContext. Instead, a new copy is created and added to the store. In
	/// addition to the encoded CTL, the context's properties are copied.
	/// </para>
	/// <para>To remove the CTL context from the certificate store, use the CertDeleteCTLFromStore function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddctlcontexttostore BOOL CertAddCTLContextToStore(
	// HCERTSTORE hCertStore, PCCTL_CONTEXT pCtlContext, DWORD dwAddDisposition, PCCTL_CONTEXT *ppStoreContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e8858f75-77a1-4c5f-a3e3-a645c5e0f053")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertAddCTLContextToStore(HCERTSTORE hCertStore, [In] PCCTL_CONTEXT pCtlContext, CertStoreAdd dwAddDisposition, out SafePCCTL_CONTEXT ppStoreContext);

	/// <summary>
	/// The <c>CertAddCTLLinkToStore</c> function adds a link in a store to a certificate trust list (CTL) context in a different store.
	/// Instead of creating and adding a duplicate of a CTL context, this function adds a link to the original CTL context.
	/// </summary>
	/// <param name="hCertStore">Handle of the certificate store where the link is to be added.</param>
	/// <param name="pCtlContext">A pointer to the CTL_CONTEXT structure to be linked.</param>
	/// <param name="dwAddDisposition">
	/// <para>
	/// Specifies the action to take if a matching CTL or a link to a matching CTL already exists in the store. Currently defined
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
	/// Makes no check for an existing matching CTL or link to a matching CTL. A new CTL is always added to the store. This can lead to
	/// duplicates in a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEW</term>
	/// <term>If a matching CTL or a link to a matching CTL exists, the operation fails. GetLastError returns the CRYPT_E_EXISTS code.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEWER</term>
	/// <term>
	/// If a matching CTL or a link to a matching CTL exists, the ThisUpdate times on the CTLs are compared. If the existing CTL has a
	/// ThisUpdate time less than the ThisUpdate time on the new CTL, the old CTL or link is replaced just as with
	/// CERT_STORE_ADD_REPLACE_EXISTING. If the existing CTL has a ThisUpdate time greater than or equal to the ThisUpdate time on the
	/// CTL to be added, the function fails with GetLastError returning the CRYPT_E_EXISTS code. If a matching CTL or a link to a
	/// matching CTL is not found in the store, a new CTL is added to the store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEWER_INHERIT_PROPERTIES</term>
	/// <term>
	/// The action is the same as for CERT_STORE_ADD_NEWER, except that if an older CTL is replaced, the properties of the older CTL are
	/// incorporated into the replacement CTL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
	/// <term>
	/// If a matching CTL or a link to a matching CTL exists, the existing CTL or link is deleted and a new CTL is created and added to
	/// the store. If a matching CTL or a link to a matching CTL does not exist, one is added.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING_INHERIT_PROPERTIES</term>
	/// <term>
	/// If a matching CTL exists in the store, that existing context is deleted before creating and adding the new context. The added
	/// context inherits properties from the existing CTL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_USE_EXISTING</term>
	/// <term>
	/// If a matching CTL or a link to a matching CTL exists, that existing CTL is used and properties from the new CTL are added. The
	/// function does not fail, but no new CTL is added. If ppCertContext is not NULL, the existing context is duplicated. If a matching
	/// CTL or a link to a matching CTL does not exist, a new CTL is added.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppStoreContext">
	/// A pointer to a pointer to a copy of the link created. ppStoreContext can be <c>NULL</c> to indicate that a copy of the link is
	/// not needed. If a copy of the link is created, that copy must be freed using CertFreeCTLContext.
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
	/// <term>For a dwAddDisposition of CERT_STORE_ADD_NEW, the CTL already exists in the store.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The add disposition specified by the dwAddDisposition parameter is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Because the link provides access to the original CTL context, setting an extended property in the linked CTL context changes
	/// that extended property in the original CTL's location and in any other links to that CTL.
	/// </para>
	/// <para>
	/// Links cannot be added to a store that is opened as a collection. Stores opened as collections include all stores opened with
	/// CertOpenSystemStore or CertOpenStore using CERT_STORE_PROV_SYSTEM or CERT_STORE_PROV_COLLECTION. Also see CertAddStoreToCollection.
	/// </para>
	/// <para>
	/// When links are used and CertCloseStore is called with CERT_CLOSE_STORE_FORCE_FLAG, the store using links must be closed before
	/// the store containing the original contexts is closed. If CERT_CLOSE_STORE_FORCE_FLAG is not used, the two stores can be closed
	/// in either order.
	/// </para>
	/// <para>To remove the CTL context link from the certificate store, use the CertDeleteCTLFromStore function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddctllinktostore BOOL CertAddCTLLinkToStore(
	// HCERTSTORE hCertStore, PCCTL_CONTEXT pCtlContext, DWORD dwAddDisposition, PCCTL_CONTEXT *ppStoreContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "c129aeae-69d9-440a-979d-e9e481c64538")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertAddCTLLinkToStore(HCERTSTORE hCertStore, [In] PCCTL_CONTEXT pCtlContext, CertStoreAdd dwAddDisposition, out SafePCCTL_CONTEXT ppStoreContext);

	/// <summary>
	/// The <c>CertAddEncodedCTLToStore</c> function creates a certificate trust list (CTL) context from an encoded CTL and adds it to
	/// the certificate store. The function makes a copy of the CTL context before adding it to the store.
	/// </summary>
	/// <param name="hCertStore">Handle of a certificate store.</param>
	/// <param name="dwMsgAndCertEncodingType">
	/// <para>
	/// Specifies the type of encoding used. Both the certificate and message encoding types must be specified by combining them with a
	/// bitwise- <c>OR</c> operation as shown in the following example:
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
	/// <param name="pbCtlEncoded">A pointer to a buffer containing the encoded CTL to be added to the certificate store.</param>
	/// <param name="cbCtlEncoded">The size, in bytes, of the pbCtlEncoded buffer.</param>
	/// <param name="dwAddDisposition">
	/// <para>
	/// Specifies the action to take if a matching CTL or a link to a matching CTL already exists in the store. Currently defined
	/// disposition values and their uses are as follows
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_ADD_ALWAYS</term>
	/// <term>
	/// Makes no check for an existing matching CTL or link to a matching CTL. A new CTL is always added to the store. This can lead to
	/// duplicates in a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEW</term>
	/// <term>If a matching CTL or a link to a matching CTL exists, the operation fails. GetLastError returns the CRYPT_E_EXISTS code.</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEWER</term>
	/// <term>
	/// If a matching CTL or a link to a matching CTL exists, the ThisUpdate times on the CTLs are compared. If the existing CTL has a
	/// ThisUpdate time less than the ThisUpdate time on the new CTL, the old CTL or link is replaced just as with
	/// CERT_STORE_ADD_REPLACE_EXISTING. If the existing CTL has a ThisUpdate time greater than or equal to the ThisUpdate time on the
	/// CTL to be added, the function fails with GetLastError returning the CRYPT_E_EXISTS code. If a matching CTL or a link to a
	/// matching CTL is not found in the store, a new CTL is added to the store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_NEWER_INHERIT_PROPERTIES</term>
	/// <term>
	/// The action is the same as for CERT_STORE_ADD_NEWER, except that if an older CTL is replaced, the properties of the older CTL are
	/// incorporated into the replacement CTL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
	/// <term>
	/// If a matching CTL or a link to a matching CTL exists, the existing CTL or link is deleted and a new CTL is created and added to
	/// the store. If a matching CTL or a link to a matching CTL does not exist, one is added.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_REPLACE_EXISTING_INHERIT_PROPERTIES</term>
	/// <term>
	/// If a matching CTL exists in the store, that existing context is deleted before creating and adding the new context. The added
	/// context inherits properties from the existing CTL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_ADD_USE_EXISTING</term>
	/// <term>
	/// If a matching CTL or a link to a matching CTL exists, that existing CTL is used and properties from the new CTL are added. The
	/// function does not fail, but no new CTL is added. If ppCertContext is not NULL, the existing context is duplicated. If a matching
	/// CTL or a link to a matching CTL does not exist, a new CTL is added.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppCtlContext">
	/// A pointer to a pointer to the decoded CTL_CONTEXT structure. Can be <c>NULL</c> indicating that the calling application does not
	/// require a copy of the added or existing CTL. If a copy is made, it must be freed by using CertFreeCTLContext.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// <para>Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_EXISTS</term>
	/// <term>
	/// CERT_STORE_ADD_NEW is set, and the CTL already exists in the store; or CERT_STORE_ADD_NEWER is set and there is a CTL in the
	/// store with a ThisUpdate time greater than or equal to the ThisUpdate time on the CTL to be added.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// A disposition value that is not valid was specified in the dwAddDisposition parameter, or an encoding type that is not valid was
	/// specified. Currently, only the encoding types X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are supported.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddencodedctltostore BOOL CertAddEncodedCTLToStore(
	// HCERTSTORE hCertStore, DWORD dwMsgAndCertEncodingType, const BYTE *pbCtlEncoded, DWORD cbCtlEncoded, DWORD dwAddDisposition,
	// PCCTL_CONTEXT *ppCtlContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "4239d43e-187d-4f40-99ae-6f914b7577ac")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertAddEncodedCTLToStore(HCERTSTORE hCertStore, CertEncodingType dwMsgAndCertEncodingType, [In] IntPtr pbCtlEncoded, uint cbCtlEncoded, CertStoreAdd dwAddDisposition, out SafePCCTL_CONTEXT ppCtlContext);

	/// <summary>
	/// The <c>CertCreateCTLContext</c> function creates a certificate trust list (CTL) context from an encoded CTL. The created context
	/// is not persisted to a certificate store. The function makes a copy of the encoded CTL within the created context.
	/// </summary>
	/// <param name="dwMsgAndCertEncodingType">
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
	/// <param name="pbCtlEncoded">A pointer to a buffer containing the encoded CTL from which the context is to be created.</param>
	/// <param name="cbCtlEncoded">The size, in bytes, of the pbCtlEncoded buffer.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to a read-only CTL_CONTEXT.</para>
	/// <para>
	/// If the function fails and is unable to decode and create the CTL_CONTEXT, the return value is <c>NULL</c>. For extended error
	/// information, call GetLastError. The following table shows a possible error code.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>Invalid certificate encoding type. Only PKCS_7_ASN_ENCODING and X509_ASN_ENCODING are supported.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// The CTL_CONTEXT must be freed by calling CertFreeCTLContext. CertDuplicateCTLContext can be called to make a duplicate.
	/// CertSetCTLContextProperty and CertGetCTLContextProperty can be called to store and read properties for the CTL.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcreatectlcontext PCCTL_CONTEXT CertCreateCTLContext(
	// DWORD dwMsgAndCertEncodingType, const BYTE *pbCtlEncoded, DWORD cbCtlEncoded );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "172c59ee-9e06-4169-aaa7-2624e3fcf015")]
	public static extern SafePCCTL_CONTEXT CertCreateCTLContext(CertEncodingType dwMsgAndCertEncodingType, [In] IntPtr pbCtlEncoded, uint cbCtlEncoded);

	/// <summary>
	/// The <c>CertDeleteCTLFromStore</c> function deletes the specified certificate trust list (CTL) context from a certificate store.
	/// </summary>
	/// <param name="pCtlContext">A pointer to the CTL_CONTEXT structure to be deleted.</param>
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
	/// <term>The store was opened read-only, and a delete operation is not allowed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// All subsequent get or find operations for the CTL in this store fail. However, memory allocated for the CTL is not freed until
	/// all duplicated contexts have also been freed.
	/// </para>
	/// <para>The pCtlContext parameter is always freed by this function by using CertFreeCTLContext, even for an error.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certdeletectlfromstore BOOL CertDeleteCTLFromStore(
	// PCCTL_CONTEXT pCtlContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e24d3445-8929-463a-b771-1f25f4e999b5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertDeleteCTLFromStore([In] PCCTL_CONTEXT pCtlContext);

	/// <summary>
	/// The <c>CertDuplicateCTLContext</c> function duplicates a certificate trust list (CTL) context by incrementing its reference count.
	/// </summary>
	/// <param name="pCtlContext">A pointer to the CTL_CONTEXT structure for which the reference count is being incremented.</param>
	/// <returns>
	/// Currently, a copy is not made of the context, and the returned pointer to CTL_CONTEXT is the same as pointer input. If the
	/// pointer passed into this function is <c>NULL</c>, <c>NULL</c> is returned.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certduplicatectlcontext PCCTL_CONTEXT
	// CertDuplicateCTLContext( PCCTL_CONTEXT pCtlContext );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "512d246f-9f22-4ac1-a4fc-d5c615a65cf9")]
	public static extern PCCTL_CONTEXT CertDuplicateCTLContext(PCCTL_CONTEXT pCtlContext);

	/// <summary>
	/// The <c>CertEnumCTLsInStore</c> function retrieves the first or next certificate trust list (CTL) context in a certificate store.
	/// Used in a loop, this function can retrieve in sequence all CTL contexts in a certificate store.
	/// </summary>
	/// <param name="hCertStore">Handle of a certificate store.</param>
	/// <param name="pPrevCtlContext">
	/// A pointer to the previous CTL_CONTEXT structure found. It must be <c>NULL</c> to get the first CTL in the store. Successive CTLs
	/// are enumerated by setting pPrevCtlContext to the pointer returned by a previous call. This function frees the <c>CTL_CONTEXT</c>
	/// referenced by non- <c>NULL</c> values of this parameter. The enumeration skips any CTLs previously deleted by CertDeleteCTLFromStore.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to a read-only CTL_CONTEXT.</para>
	/// <para>If the function fails and a CTL is not found, the return value is <c>NULL</c>. For extended error information, call GetLastError.</para>
	/// <para>Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NOT_FOUND</term>
	/// <term>Either no CTLs exist in the store, or the function reached the end of the store's list.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The handle in the hCertStore parameter is not the same as that in the CTL context pointed to by the pPrevCtlContext parameter.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The returned pointer is freed when passed as the pPrevCtlContext on a subsequent call. Otherwise, the pointer must be explicitly
	/// freed by calling CertFreeCTLContext. A pPrevCtlContext that is not <c>NULL</c> is always freed by this function (through a call
	/// to <c>CertFreeCTLContext</c>), even for an error.
	/// </para>
	/// <para>A duplicate can be made by calling CertDuplicateCTLContext.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certenumctlsinstore PCCTL_CONTEXT CertEnumCTLsInStore(
	// HCERTSTORE hCertStore, PCCTL_CONTEXT pPrevCtlContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "dac9f91e-8ed4-43ce-8147-485c2ed7edd5")]
	public static extern SafePCCTL_CONTEXT CertEnumCTLsInStore(HCERTSTORE hCertStore, [In] PCCTL_CONTEXT pPrevCtlContext);

	/// <summary>
	/// The <c>CertFindCTLInStore</c> function finds the first or next certificate trust list (CTL) context that matches search criteria
	/// established by the dwFindType and its associated pvFindPara. This function can be used in a loop to find all of the CTL contexts
	/// in a certificate store that match the specified find criteria.
	/// </summary>
	/// <param name="hCertStore">Handle of the certificate store to be searched.</param>
	/// <param name="dwMsgAndCertEncodingType">
	/// <para>
	/// Specifies the type of encoding used on the CTL. It is always acceptable to specify both the certificate and message encoding
	/// types by combining them with a bitwise- <c>OR</c> operation as shown in the following example:
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
	/// <para>This parameter is used only when the dwFindType parameter is set to CTL_FIND_USAGE.</para>
	/// </param>
	/// <param name="dwFindFlags">
	/// Can be set when dwFindType is set to CTL_FIND_USAGE. For details, see the comments under CTL_FIND_USAGE, following.
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
	/// <term>CTL_FIND_ANY</term>
	/// <term>Data type of pvFindPara: NULL. Any CTL is a match.</term>
	/// </item>
	/// <item>
	/// <term>CTL_FIND_SHA1_HASH</term>
	/// <term>Data type of pvFindPara: CRYPT_HASH_BLOB. A CTL with a hash matching the hash in the CRYPT_HASH_BLOB structure is found.</term>
	/// </item>
	/// <item>
	/// <term>CTL_FIND_MD5_HASH</term>
	/// <term>Data type of pvFindPara: CRYPT_HASH_BLOB. A CTL with a hash matching the hash in the CRYPT_HASH_BLOB structure is found.</term>
	/// </item>
	/// <item>
	/// <term>CTL_FIND_USAGE</term>
	/// <term>
	/// Data type of pvFindPara: CTL_FIND_USAGE_PARA. Any CTL is found that has a usage identifier, list identifier, or signer matching
	/// the usage identifier, list identifier, or signer in the CTL_FIND_USAGE_PARA structure. If the cUsageIdentifier member is of
	/// SubjectUsage size, any CTL is a match. If the cbData member of ListIdentifier member is zero, any list identifier is a match. If
	/// the cbData member of ListIdentifier is CTL_FIND_NO_LIST_ID_CBDATA, only a CTL without a list identifier is a match. If the
	/// pSigner member in the CTL_FIND_USAGE_PARA structure is NULL, any CTL signer is a match, and only the Issuer and SerialNumber
	/// members in the pSigner CERT_INFO structure are used. If pSigner is CTL_FIND_NO_SIGNER_PTR, only a CTL without a signer is a match.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CTL_FIND_SAME_USAGE_FLAG</term>
	/// <term>
	/// Data type of pvFindPara: CTL_FIND_USAGE_PARA. Only CTLs with exactly the same usage identifiers are matched. CTLs having
	/// additional usage identifiers are not matched. For example, if only "1.2.3" is specified in the CTL_FIND_USAGE_PARA structure,
	/// then for a match, the CTL must only contain "1.2.3" and no additional usage identifiers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CTL_FIND_EXISTING</term>
	/// <term>Data type of pvFindPara: PCCTL_CONTEXT. Searches for the next CRL that is an exact match of the CTL_CONTEXT.</term>
	/// </item>
	/// <item>
	/// <term>CTL_FIND_SUBJECT</term>
	/// <term>
	/// Data type of pvFindPara: CTL_FIND_SUBJECT_PARA. A CTL having the specified subject is found. CertFindSubjectInCTL can be called
	/// to get a pointer to the subject's entry in the CTL. The pUsagePara member in CTL_FIND_SUBJECT_PARA can optionally be set to
	/// enable the matching described preceding under CTL_FIND_USAGE.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvFindPara">A pointer to the search value associated with the dwFindType parameter.</param>
	/// <param name="pPrevCtlContext">
	/// A pointer to the last CTL_CONTEXT returned by this function. It must be <c>NULL</c> to get the first CTL in the store.
	/// Successive CTLs are retrieved by setting pPrevCtlContext to the pointer to the <c>CTL_CONTEXT</c> returned by a previous
	/// function call. Any certificates that do not meet the search criteria or that have been previously deleted by
	/// CertDeleteCTLFromStore are skipped. This function frees the <c>CTL_CONTEXT</c> referenced by non- <c>NULL</c> values of this parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to a read-only CTLcontext.</para>
	/// <para>For extended error information, call GetLastError. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NOT_FOUND</term>
	/// <term>
	/// Either no CTLs were found in the store, no CTL was found matching the search criteria, or the function reached the end of the
	/// store's list.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The handle in the hCertStore parameter is not the same as that in the CTL context pointed to by the pPrevCtlContext parameter,
	/// or a value that is not valid was specified in the dwFindType parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A returned pointer is freed when passed as the pPrevCtlContext on a subsequent call to the function. Otherwise, the pointer must
	/// be freed by calling CertFreeCTLContext. A non- <c>NULL</c> pPrevCtlContext passed to the function is always freed with a call to
	/// <c>CertFreeCTLContext</c>, even if the function generates an error.
	/// </para>
	/// <para>
	/// CertDuplicateCTLContext can be called to make a duplicate of the returned context. The returned CTL context can be added to a
	/// different certificate store using CertAddCTLContextToStore, or a link to that CTL context can be added to a noncollection store
	/// using CertAddCTLLinkToStore. If a CTL matching the search criteria is not found, <c>NULL</c> is returned.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfindctlinstore PCCTL_CONTEXT CertFindCTLInStore(
	// HCERTSTORE hCertStore, DWORD dwMsgAndCertEncodingType, DWORD dwFindFlags, DWORD dwFindType, const void *pvFindPara, PCCTL_CONTEXT
	// pPrevCtlContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e5ed3b22-e96f-4e7d-a20e-eebed0a84d3c")]
	public static extern SafePCCTL_CONTEXT CertFindCTLInStore(HCERTSTORE hCertStore, CertEncodingType dwMsgAndCertEncodingType, CertInfoFlags dwFindFlags,
		CertFindType dwFindType, [In] IntPtr pvFindPara, [In] PCCTL_CONTEXT pPrevCtlContext);

	/// <summary>
	/// <para>
	/// The <c>CertFreeCTLContext</c> function frees a certificate trust list (CTL) context by decrementing its reference count. When
	/// the reference count goes to zero, <c>CertFreeCTLContext</c> frees the memory used by a CTL context.
	/// </para>
	/// <para>
	/// To free a context obtained by a get, duplicate, or create function, call the appropriate free function. To free a context
	/// obtained by a find or enumerate function, either pass it in as the previous context parameter to a subsequent invocation of the
	/// function, or call the appropriate free function. For more information, see the reference topic for the function that obtains the context.
	/// </para>
	/// </summary>
	/// <param name="pCtlContext">A pointer to the CTL_CONTEXT to be freed.</param>
	/// <returns>The function always returns <c>TRUE</c>.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfreectlcontext BOOL CertFreeCTLContext( PCCTL_CONTEXT
	// pCtlContext );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "84b1aa0c-44d9-4a2f-861c-fa7d8caac192")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertFreeCTLContext([In] PCCTL_CONTEXT pCtlContext);

	/// <summary>
	/// The <c>CertSerializeCTLStoreElement</c> function serializes an encoded certificate trust list (CTL) context and the encoded
	/// representation of its properties. The result can be persisted to storage so that the CTL and properties can be retrieved later.
	/// </summary>
	/// <param name="pCtlContext">A pointer to the CTL_CONTEXT structure being serialized.</param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <param name="pbElement">
	/// <para>A pointer to a buffer that receives the serialized output, including the encoded CTL and, possibly, its properties.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbElement">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that specifies the size, in bytes, of the buffer that is pointed to by the pbElement
	/// parameter. When the function returns the <c>DWORD</c> value contains the number of bytes stored in the buffer.
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
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certserializectlstoreelement BOOL
	// CertSerializeCTLStoreElement( PCCTL_CONTEXT pCtlContext, DWORD dwFlags, BYTE *pbElement, DWORD *pcbElement );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "63d343c1-fa65-4cd1-a210-3805c7d92208")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertSerializeCTLStoreElement([In] PCCTL_CONTEXT pCtlContext, [Optional] uint dwFlags, [In, Out, Optional] IntPtr pbElement, ref uint pcbElement);

	public partial class SafePCCTL_CONTEXT
	{
		/// <summary>Performs an explicit conversion from <see cref="SafePCCTL_CONTEXT"/> to <see cref="CTL_CONTEXT"/>.</summary>
		/// <param name="ctx">The handle.</param>
		/// <returns>The resulting <see cref="CTL_CONTEXT"/> instance from the conversion.</returns>
		public static unsafe explicit operator CTL_CONTEXT*(SafePCCTL_CONTEXT ctx) => (CTL_CONTEXT*)(void*)ctx.handle;
	}
}