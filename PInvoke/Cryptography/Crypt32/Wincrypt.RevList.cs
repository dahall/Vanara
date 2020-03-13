using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.PInvoke
{
	/// <summary>Methods and data types found in Crypt32.dll.</summary>
	public static partial class Crypt32
	{
		/// <summary>Enable verification checks on the returned CRL.</summary>
		[PInvokeData("wincrypt.h", MSDNShortId = "7bd21424-4f74-4bac-ab47-00d51ebdca1c")]
		[Flags]
		public enum CertStoreVerification
		{
			/// <summary>Uses the public key in the issuer's certificate to verify the signature on the returned CRL.</summary>
			CERT_STORE_SIGNATURE_FLAG = 0x00000001,

			/// <summary>Gets the current time and verifies that it is within the time between the CRL's ThisUpdate and NextUpdate.</summary>
			CERT_STORE_TIME_VALIDITY_FLAG = 0x00000002,

			/// <summary>Checks whether the subject certificate is on the issuer's revocation list.</summary>
			CERT_STORE_REVOCATION_FLAG = 0x00000004,

			/// <summary>Indicates no matching CRL was found.</summary>
			CERT_STORE_NO_CRL_FLAG = 0x00010000,

			/// <summary>Indicates no issuer certificate was found.</summary>
			CERT_STORE_NO_ISSUER_FLAG = 0x00020000,

			/// <summary>Gets a base CRL.</summary>
			CERT_STORE_BASE_CRL_FLAG = 0x00000100,

			/// <summary>Gets a delta CRL.</summary>
			CERT_STORE_DELTA_CRL_FLAG = 0x00000200,
		}

		/// <summary>Flags that can be used to do additional filtering.</summary>
		[PInvokeData("wincrypt.h", MSDNShortId = "3e481912-204a-4d86-ab67-81f8ae4d1aaa")]
		[Flags]
		public enum CrlFindFlags : uint
		{
			/// <summary>
			/// Checks for a CRL that has an Authority Key Identifier (AKI) extension. If the CRL has an AKI, only a CRL whose AKI matches
			/// the issuer is returned. <note>The AKI extension has the object identifier(OID) value szOID_AUTHORITY_KEY_IDENTIFIER2 and its
			/// corresponding data structure.</note>
			/// </summary>
			CRL_FIND_ISSUED_BY_AKI_FLAG = 0x1,

			/// <summary>
			/// Use the public key in the issuer's certificate to verify the signature on the CRL. Only returns a CRL that has a valid signature.
			/// </summary>
			CRL_FIND_ISSUED_BY_SIGNATURE_FLAG = 0x2,

			/// <summary>Finds and returns a delta CRL.</summary>
			CRL_FIND_ISSUED_BY_DELTA_FLAG = 0x4,

			/// <summary>Finds and returns a base CRL.</summary>
			CRL_FIND_ISSUED_BY_BASE_FLAG = 0x8,

			/// <summary>
			/// The signature is checked for strength after successful verification. This flag applies only when the dwFindType parameter is
			/// set to <strong>CRL_FIND_ISSUED_FOR</strong>. You must also set <strong>CRL_FIND_ISSUED_BY_SIGNATURE_FLAG</strong>. If
			/// successful, the following strong signature properties will be set on the CRL context:
			/// <list type="bullet">
			/// <item><strong>CERT_SIGN_HASH_CNG_ALG_PROP_ID</strong></item>
			/// <item><strong>CERT_ISSUER_PUB_KEY_BIT_LENGTH_PROP_ID</strong></item>
			/// </list>
			/// <para><strong>Windows 8 and Windows Server 2012:</strong> Support for this flag begins.</para>
			/// </summary>
			CRL_FIND_ISSUED_FOR_SET_STRONG_PROPERTIES_FLAG = 0x10,
		}

		/// <summary>
		/// Specifies the type of search being made. The value of dwFindType determines the data type, contents, and use of the pvFindPara parameter.
		/// </summary>
		[PInvokeData("wincrypt.h", MSDNShortId = "3e481912-204a-4d86-ab67-81f8ae4d1aaa")]
		public enum CrlFindType : uint
		{
			/// <summary>No search criteria. The next CRL in the store is returned.</summary>
			CRL_FIND_ANY = 0,

			/// <summary>Searches for the next CRL in the store matching the issuer in the CERT_CONTEXT.</summary>
			CRL_FIND_ISSUED_BY = 1,

			/// <summary>
			/// <para>Searches for the next CRL that matches the CRL_CONTEXT in the following ways:</para>
			/// <list type="bullet">
			/// <item>Both are base or delta CRLs.</item>
			/// <item>The issuer-name BLOBs for both are identical.</item>
			/// <item>If they exist, the Authority/KeyIdentifier and IssuingDistributionPoint encoded extension BLOBs match.</item>
			/// </list>
			/// </summary>
			CRL_FIND_EXISTING = 2,

			/// <summary>
			/// Searches for the next CRL in the store that matches the issuer of the subject certificate in the CRL_FIND_ISSUED_FOR_PARA structure.
			/// <para>
			/// If no CRL is found, searches for the next CRL in the store that matches the issuer in the CRL_FIND_ISSUED_FOR_PARA structure.
			/// </para>
			/// <note>When using cross certificates, the subject name in the issuer's certificate might not match the issuer name in the
			/// subject certificate and its corresponding CRL.</note>
			/// </summary>
			CRL_FIND_ISSUED_FOR = 3,
		}

		/// <summary>
		/// The <c>CertAddCRLContextToStore</c> function adds a certificate revocation list (CRL) context to the specified certificate store.
		/// </summary>
		/// <param name="hCertStore">Handle of a certificate store.</param>
		/// <param name="pCrlContext">A pointer to the CRL_CONTEXT structure to be added.</param>
		/// <param name="dwAddDisposition">
		/// <para>
		/// Specifies the action to take if a matching CRL or a link to a matching CRL already exists in the store. Currently defined
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
		/// Makes no check for an existing matching CRL or link to a matching CRL. A new CRL is always added to the store. This can lead to
		/// duplicates in a store.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEW</term>
		/// <term>If a matching CRL or a link to a matching CRL exists, the operation fails. GetLastError returns the CRYPT_E_EXISTS code.</term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEWER</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, the function compares the ThisUpdate times on the CRLs. If the existing
		/// CRL has a ThisUpdate time less than the ThisUpdate time on the new CRL, the old CRL or link is replaced just as with
		/// CERT_STORE_ADD_REPLACE_EXISTING. If the existing CRL has a ThisUpdate time greater than or equal to the ThisUpdate time on the
		/// CRL to be added, the function fails with GetLastError returning the CRYPT_E_EXISTS code. If a matching CRL or a link to a
		/// matching CRL is not found in the store, a new CRL is added to the store.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEWER_INHERIT_PROPERTIES</term>
		/// <term>
		/// The action is the same as for CERT_STORE_ADD_NEWER, except that if an older CRL is replaced, the properties of the older CRL are
		/// incorporated into the replacement CRL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, the existing CRL or link is deleted and a new CRL is created and added to
		/// the store. If a matching CRL or a link to a matching CRL does not exist, one is added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_REPLACE_EXISTING_INHERIT_PROPERTIES</term>
		/// <term>
		/// If a matching CRL exists in the store, the existing context is deleted before creating and adding the new context. The added
		/// context inherits properties from the existing CRL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_USE_EXISTING</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, that existing CRL is used and properties from the new CRL are added. The
		/// function does not fail, but no new CRL is added. If ppCertContext is not NULL, the existing context is duplicated. If a matching
		/// CRL or a link to a matching CRL does not exist, a new CRL is added.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppStoreContext">
		/// A pointer to a pointer to the decoded CRL context. This is an optional parameter and can be <c>NULL</c>, indicating that the
		/// calling application does not require a copy of the added or existing CRL. If a copy is made, that context must be freed by using CertFreeCRLContext.
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
		/// This error is returned if CERT_STORE_ADD_NEW is set and the CRL already exists in the store or if CERT_STORE_ADD_NEWER is set
		/// and a CRL exists in the store with a ThisUpdate date greater than or equal to the ThisUpdate date on the CRL to be added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The dwAddDisposition parameter specified a disposition value that is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The CRL context is not duplicated using CertDuplicateCRLContext. Instead, a new copy is created and added to the store. In
		/// addition to copying the encoded CRL, the function copies the context's properties.
		/// </para>
		/// <para>To remove the CRL context from the certificate store, use the CertDeleteCRLFromStore function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddcrlcontexttostore BOOL CertAddCRLContextToStore(
		// HCERTSTORE hCertStore, PCCRL_CONTEXT pCrlContext, DWORD dwAddDisposition, PCCRL_CONTEXT *ppStoreContext );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "5dfa1c08-5d75-4ee4-bd65-ce56eb61ecce")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertAddCRLContextToStore(HCERTSTORE hCertStore, [In] PCCRL_CONTEXT pCrlContext, CertStoreAdd dwAddDisposition, IntPtr ppStoreContext = default);

		/// <summary>
		/// The <c>CertAddCRLContextToStore</c> function adds a certificate revocation list (CRL) context to the specified certificate store.
		/// </summary>
		/// <param name="hCertStore">Handle of a certificate store.</param>
		/// <param name="pCrlContext">A pointer to the CRL_CONTEXT structure to be added.</param>
		/// <param name="dwAddDisposition">
		/// <para>
		/// Specifies the action to take if a matching CRL or a link to a matching CRL already exists in the store. Currently defined
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
		/// Makes no check for an existing matching CRL or link to a matching CRL. A new CRL is always added to the store. This can lead to
		/// duplicates in a store.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEW</term>
		/// <term>If a matching CRL or a link to a matching CRL exists, the operation fails. GetLastError returns the CRYPT_E_EXISTS code.</term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEWER</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, the function compares the ThisUpdate times on the CRLs. If the existing
		/// CRL has a ThisUpdate time less than the ThisUpdate time on the new CRL, the old CRL or link is replaced just as with
		/// CERT_STORE_ADD_REPLACE_EXISTING. If the existing CRL has a ThisUpdate time greater than or equal to the ThisUpdate time on the
		/// CRL to be added, the function fails with GetLastError returning the CRYPT_E_EXISTS code. If a matching CRL or a link to a
		/// matching CRL is not found in the store, a new CRL is added to the store.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEWER_INHERIT_PROPERTIES</term>
		/// <term>
		/// The action is the same as for CERT_STORE_ADD_NEWER, except that if an older CRL is replaced, the properties of the older CRL are
		/// incorporated into the replacement CRL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, the existing CRL or link is deleted and a new CRL is created and added to
		/// the store. If a matching CRL or a link to a matching CRL does not exist, one is added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_REPLACE_EXISTING_INHERIT_PROPERTIES</term>
		/// <term>
		/// If a matching CRL exists in the store, the existing context is deleted before creating and adding the new context. The added
		/// context inherits properties from the existing CRL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_USE_EXISTING</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, that existing CRL is used and properties from the new CRL are added. The
		/// function does not fail, but no new CRL is added. If ppCertContext is not NULL, the existing context is duplicated. If a matching
		/// CRL or a link to a matching CRL does not exist, a new CRL is added.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppStoreContext">
		/// A pointer to a pointer to the decoded CRL context. This is an optional parameter and can be <c>NULL</c>, indicating that the
		/// calling application does not require a copy of the added or existing CRL. If a copy is made, that context must be freed by using CertFreeCRLContext.
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
		/// This error is returned if CERT_STORE_ADD_NEW is set and the CRL already exists in the store or if CERT_STORE_ADD_NEWER is set
		/// and a CRL exists in the store with a ThisUpdate date greater than or equal to the ThisUpdate date on the CRL to be added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The dwAddDisposition parameter specified a disposition value that is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The CRL context is not duplicated using CertDuplicateCRLContext. Instead, a new copy is created and added to the store. In
		/// addition to copying the encoded CRL, the function copies the context's properties.
		/// </para>
		/// <para>To remove the CRL context from the certificate store, use the CertDeleteCRLFromStore function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddcrlcontexttostore BOOL CertAddCRLContextToStore(
		// HCERTSTORE hCertStore, PCCRL_CONTEXT pCrlContext, DWORD dwAddDisposition, PCCRL_CONTEXT *ppStoreContext );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "5dfa1c08-5d75-4ee4-bd65-ce56eb61ecce")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertAddCRLContextToStore(HCERTSTORE hCertStore, [In] PCCRL_CONTEXT pCrlContext, CertStoreAdd dwAddDisposition, out SafePCCRL_CONTEXT ppStoreContext);

		/// <summary>
		/// The <c>CertAddCRLLinkToStore</c> function adds a link in a store to a certificate revocation list (CRL) context in a different
		/// store. Instead of creating and adding a duplicate of the CRL, this function adds a link to the original CRL context.
		/// </summary>
		/// <param name="hCertStore">Handle of a certificate store where the link is to be added.</param>
		/// <param name="pCrlContext">A pointer to the CRL_CONTEXT structure to be linked.</param>
		/// <param name="dwAddDisposition">
		/// <para>
		/// Specifies the action to take if a matching CRL or a link to a matching CRL exists in the store. Currently defined disposition
		/// values and their uses are as follows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_STORE_ADD_ALWAYS</term>
		/// <term>
		/// Makes no check for an existing matching CRL or link to a matching CRL. A new link is always added to the store. This can lead to
		/// duplicates in a store.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEW</term>
		/// <term>If a matching CRL or a link to a matching CRL exists, the operation fails. GetLastError returns the CRYPT_E_EXISTS code.</term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEWER</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, the ThisUpdate times on the CRLs are compared. If the existing CRL has a
		/// ThisUpdate time less than the ThisUpdate time on the new CRL, the old link is replaced just as with
		/// CERT_STORE_ADD_REPLACE_EXISTING. If the existing CRL has a ThisUpdate time greater than or equal to the ThisUpdate time on the
		/// CRL to be added, the function fails with GetLastError returning the CRYPT_E_EXISTS code. If a matching CRL or a link to a
		/// matching CRL is not found in the store, a new link is added to the store.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
		/// <term>
		/// If a link to the matching CRL exists, that existing link is deleted and a new link is created and added to the store. If a
		/// matching CRL or a link to a matching CRL does not exist, a new link is added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_USE_EXISTING</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, that existing link is used. The function does not fail, but no new link is
		/// added. If a matching CRL or link to a CRL does not exist, a new link is added.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppStoreContext">
		/// A pointer to a pointer of a copy of the link created. The ppStoreContext parameter can be <c>NULL</c> to indicate that a copy of
		/// the link is not needed. If a copy of the link is created, that copy must be freed using CertFreeCRLContext.
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
		/// <term>A disposition value that is not valid was specified in the dwAddDisposition parameter.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Because the link provides access to an original CRL context, setting an extended property in the linked CRL context changes that
		/// extended property in the CRL's original location and in any other links to that CRL.
		/// </para>
		/// <para>
		/// Links cannot be added to a store that is opened as a collection. Stores opened as collections include all stores opened with
		/// CertOpenSystemStore or CertOpenStore using CERT_STORE_PROV_SYSTEM or CERT_STORE_PROV_COLLECTION. For more information, see CertAddStoreToCollection.
		/// </para>
		/// <para>
		/// If links are used and CertCloseStore is called with CERT_CLOSE_STORE_FORCE_FLAG, the store using links must be closed before the
		/// store containing the original contexts can be closed. If CERT_CLOSE_STORE_FORCE_FLAG is not used, the two stores can be closed
		/// in either order.
		/// </para>
		/// <para>To remove the CRL context link from the certificate store, use the CertDeleteCRLFromStore function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddcrllinktostore BOOL CertAddCRLLinkToStore(
		// HCERTSTORE hCertStore, PCCRL_CONTEXT pCrlContext, DWORD dwAddDisposition, PCCRL_CONTEXT *ppStoreContext );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "2fde63ed-7522-4400-a16b-059a001e7c26")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertAddCRLLinkToStore(HCERTSTORE hCertStore, [In] PCCRL_CONTEXT pCrlContext, CertStoreAdd dwAddDisposition, out SafePCCRL_CONTEXT ppStoreContext);

		/// <summary>
		/// The <c>CertAddCRLLinkToStore</c> function adds a link in a store to a certificate revocation list (CRL) context in a different
		/// store. Instead of creating and adding a duplicate of the CRL, this function adds a link to the original CRL context.
		/// </summary>
		/// <param name="hCertStore">Handle of a certificate store where the link is to be added.</param>
		/// <param name="pCrlContext">A pointer to the CRL_CONTEXT structure to be linked.</param>
		/// <param name="dwAddDisposition">
		/// <para>
		/// Specifies the action to take if a matching CRL or a link to a matching CRL exists in the store. Currently defined disposition
		/// values and their uses are as follows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_STORE_ADD_ALWAYS</term>
		/// <term>
		/// Makes no check for an existing matching CRL or link to a matching CRL. A new link is always added to the store. This can lead to
		/// duplicates in a store.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEW</term>
		/// <term>If a matching CRL or a link to a matching CRL exists, the operation fails. GetLastError returns the CRYPT_E_EXISTS code.</term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEWER</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, the ThisUpdate times on the CRLs are compared. If the existing CRL has a
		/// ThisUpdate time less than the ThisUpdate time on the new CRL, the old link is replaced just as with
		/// CERT_STORE_ADD_REPLACE_EXISTING. If the existing CRL has a ThisUpdate time greater than or equal to the ThisUpdate time on the
		/// CRL to be added, the function fails with GetLastError returning the CRYPT_E_EXISTS code. If a matching CRL or a link to a
		/// matching CRL is not found in the store, a new link is added to the store.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
		/// <term>
		/// If a link to the matching CRL exists, that existing link is deleted and a new link is created and added to the store. If a
		/// matching CRL or a link to a matching CRL does not exist, a new link is added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_USE_EXISTING</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, that existing link is used. The function does not fail, but no new link is
		/// added. If a matching CRL or link to a CRL does not exist, a new link is added.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppStoreContext">
		/// A pointer to a pointer of a copy of the link created. The ppStoreContext parameter can be <c>NULL</c> to indicate that a copy of
		/// the link is not needed. If a copy of the link is created, that copy must be freed using CertFreeCRLContext.
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
		/// <term>A disposition value that is not valid was specified in the dwAddDisposition parameter.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Because the link provides access to an original CRL context, setting an extended property in the linked CRL context changes that
		/// extended property in the CRL's original location and in any other links to that CRL.
		/// </para>
		/// <para>
		/// Links cannot be added to a store that is opened as a collection. Stores opened as collections include all stores opened with
		/// CertOpenSystemStore or CertOpenStore using CERT_STORE_PROV_SYSTEM or CERT_STORE_PROV_COLLECTION. For more information, see CertAddStoreToCollection.
		/// </para>
		/// <para>
		/// If links are used and CertCloseStore is called with CERT_CLOSE_STORE_FORCE_FLAG, the store using links must be closed before the
		/// store containing the original contexts can be closed. If CERT_CLOSE_STORE_FORCE_FLAG is not used, the two stores can be closed
		/// in either order.
		/// </para>
		/// <para>To remove the CRL context link from the certificate store, use the CertDeleteCRLFromStore function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddcrllinktostore BOOL CertAddCRLLinkToStore(
		// HCERTSTORE hCertStore, PCCRL_CONTEXT pCrlContext, DWORD dwAddDisposition, PCCRL_CONTEXT *ppStoreContext );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "2fde63ed-7522-4400-a16b-059a001e7c26")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertAddCRLLinkToStore(HCERTSTORE hCertStore, [In] PCCRL_CONTEXT pCrlContext, CertStoreAdd dwAddDisposition, IntPtr ppStoreContext = default);

		/// <summary>
		/// The <c>CertAddEncodedCRLToStore</c> function creates a certificate revocation list (CRL) context from an encoded CRL and adds it
		/// to the certificate store. The function makes a copy of the CRL context before adding it to the store.
		/// </summary>
		/// <param name="hCertStore">Handle of a certificate store.</param>
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
		/// <param name="pbCrlEncoded">A pointer to a buffer containing the encoded CRL to be added to the certificate store.</param>
		/// <param name="cbCrlEncoded">The size, in bytes, of the pbCrlEncoded buffer.</param>
		/// <param name="dwAddDisposition">
		/// <para>
		/// Specifies the action to take if a matching CRL or a link to a matching CRL already exists in the store. Currently defined
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
		/// Makes no check for an existing matching CRL or link to a matching CRL. A new CRL is always added to the store. This can lead to
		/// duplicates in a store.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEW</term>
		/// <term>If a matching CRL or a link to a matching CRL exists, the operation fails. GetLastError returns the CRYPT_E_EXISTS code.</term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEWER</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, the ThisUpdate times on the CRLs are compared. If the existing CRL has a
		/// ThisUpdate time less than the ThisUpdate time on the new CRL, the old CRL or link is replaced just as with
		/// CERT_STORE_ADD_REPLACE_EXISTING. If the existing CRL has a ThisUpdate time greater than or equal to the ThisUpdate time on the
		/// CRL to be added, the function fails with GetLastError returning the CRYPT_E_EXISTS code. If a matching CRL or a link to a
		/// matching CRL is not found in the store, a new CRL is added to the store.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEWER_INHERIT_PROPERTIES</term>
		/// <term>
		/// The action is the same as for CERT_STORE_ADD_NEWER, except that if an older CRL is replaced, the properties of the older CRL are
		/// incorporated into the replacement CRL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, that existing CRL or link is deleted and a new CRL is created and added to
		/// the store. If a matching CRL or a link to a matching CRL does not exist, one is added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_REPLACE_EXISTING_INHERIT_PROPERTIES</term>
		/// <term>
		/// If a matching CRL exists in the store, that existing context is deleted before creating and adding the new context. The new
		/// context inherits properties from the existing CRL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_USE_EXISTING</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, that existing CRL is used and properties from the new CRL are added. The
		/// function does not fail, but no new CRL is added. If ppCertContext is not NULL, the existing context is duplicated. If a matching
		/// CRL or a link to a matching CRL does not exist, a new CRL is added.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppCrlContext">
		/// A pointer to a pointer to the decoded CRL_CONTEXT structure. This is an optional parameter that can be <c>NULL</c>, indicating
		/// that the calling application does not require a copy of the new or existing CRL. If a copy is made, that context must be freed
		/// using CertFreeCRLContext.
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
		/// CERT_STORE_ADD_NEW is set and the CRL already exists in the store, or CERT_STORE_ADD_NEWER is set and there is a CRL in the
		/// store with a ThisUpdate time greater than or equal to the ThisUpdate time for the CRL to be added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// A disposition value that is not valid was specified in the dwAddDisposition parameter, or an encoding type that is not valid was
		/// specified. Currently, only the encoding type X509_ASN_ENCODING is supported.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
		/// about these errors, see ASN.1 Encoding/Decoding Return Values.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddencodedcrltostore BOOL CertAddEncodedCRLToStore(
		// HCERTSTORE hCertStore, DWORD dwCertEncodingType, const BYTE *pbCrlEncoded, DWORD cbCrlEncoded, DWORD dwAddDisposition,
		// PCCRL_CONTEXT *ppCrlContext );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "ec2361e6-a1e6-413a-828e-d543a09c88f8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertAddEncodedCRLToStore(HCERTSTORE hCertStore, CertEncodingType dwCertEncodingType, [In] IntPtr pbCrlEncoded, uint cbCrlEncoded, CertStoreAdd dwAddDisposition, out SafePCCRL_CONTEXT ppCrlContext);

		/// <summary>
		/// The <c>CertAddEncodedCRLToStore</c> function creates a certificate revocation list (CRL) context from an encoded CRL and adds it
		/// to the certificate store. The function makes a copy of the CRL context before adding it to the store.
		/// </summary>
		/// <param name="hCertStore">Handle of a certificate store.</param>
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
		/// <param name="pbCrlEncoded">A pointer to a buffer containing the encoded CRL to be added to the certificate store.</param>
		/// <param name="cbCrlEncoded">The size, in bytes, of the pbCrlEncoded buffer.</param>
		/// <param name="dwAddDisposition">
		/// <para>
		/// Specifies the action to take if a matching CRL or a link to a matching CRL already exists in the store. Currently defined
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
		/// Makes no check for an existing matching CRL or link to a matching CRL. A new CRL is always added to the store. This can lead to
		/// duplicates in a store.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEW</term>
		/// <term>If a matching CRL or a link to a matching CRL exists, the operation fails. GetLastError returns the CRYPT_E_EXISTS code.</term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEWER</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, the ThisUpdate times on the CRLs are compared. If the existing CRL has a
		/// ThisUpdate time less than the ThisUpdate time on the new CRL, the old CRL or link is replaced just as with
		/// CERT_STORE_ADD_REPLACE_EXISTING. If the existing CRL has a ThisUpdate time greater than or equal to the ThisUpdate time on the
		/// CRL to be added, the function fails with GetLastError returning the CRYPT_E_EXISTS code. If a matching CRL or a link to a
		/// matching CRL is not found in the store, a new CRL is added to the store.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_NEWER_INHERIT_PROPERTIES</term>
		/// <term>
		/// The action is the same as for CERT_STORE_ADD_NEWER, except that if an older CRL is replaced, the properties of the older CRL are
		/// incorporated into the replacement CRL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_REPLACE_EXISTING</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, that existing CRL or link is deleted and a new CRL is created and added to
		/// the store. If a matching CRL or a link to a matching CRL does not exist, one is added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_REPLACE_EXISTING_INHERIT_PROPERTIES</term>
		/// <term>
		/// If a matching CRL exists in the store, that existing context is deleted before creating and adding the new context. The new
		/// context inherits properties from the existing CRL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_ADD_USE_EXISTING</term>
		/// <term>
		/// If a matching CRL or a link to a matching CRL exists, that existing CRL is used and properties from the new CRL are added. The
		/// function does not fail, but no new CRL is added. If ppCertContext is not NULL, the existing context is duplicated. If a matching
		/// CRL or a link to a matching CRL does not exist, a new CRL is added.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppCrlContext">
		/// A pointer to a pointer to the decoded CRL_CONTEXT structure. This is an optional parameter that can be <c>NULL</c>, indicating
		/// that the calling application does not require a copy of the new or existing CRL. If a copy is made, that context must be freed
		/// using CertFreeCRLContext.
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
		/// CERT_STORE_ADD_NEW is set and the CRL already exists in the store, or CERT_STORE_ADD_NEWER is set and there is a CRL in the
		/// store with a ThisUpdate time greater than or equal to the ThisUpdate time for the CRL to be added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// A disposition value that is not valid was specified in the dwAddDisposition parameter, or an encoding type that is not valid was
		/// specified. Currently, only the encoding type X509_ASN_ENCODING is supported.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
		/// about these errors, see ASN.1 Encoding/Decoding Return Values.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddencodedcrltostore BOOL CertAddEncodedCRLToStore(
		// HCERTSTORE hCertStore, DWORD dwCertEncodingType, const BYTE *pbCrlEncoded, DWORD cbCrlEncoded, DWORD dwAddDisposition,
		// PCCRL_CONTEXT *ppCrlContext );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "ec2361e6-a1e6-413a-828e-d543a09c88f8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertAddEncodedCRLToStore(HCERTSTORE hCertStore, CertEncodingType dwCertEncodingType, [In] IntPtr pbCrlEncoded, uint cbCrlEncoded, CertStoreAdd dwAddDisposition, IntPtr ppCrlContext = default);

		/// <summary>
		/// The <c>CertCreateCRLContext</c> function creates a certificate revocation list (CRL) context from an encoded CRL. The created
		/// context is not persisted to a certificate store. It makes a copy of the encoded CRL within the created context.
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
		/// <param name="pbCrlEncoded">A pointer to a buffer containing the encoded CRL from which the context is to be created.</param>
		/// <param name="cbCrlEncoded">The size, in bytes, of the pbCrlEncoded buffer.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to a read-only CRL_CONTEXT.</para>
		/// <para>
		/// If the function fails and is unable to decode and create the CRL_CONTEXT, the return value is <c>NULL</c>. For extended error
		/// information, call GetLastError. The following table shows a possible error code.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>Invalid certificate encoding type. Currently, only the encoding type X509_ASN_ENCODING is supported.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
		/// about these errors, see ASN.1 Encoding/Decoding Return Values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The CRL_CONTEXT must be freed by calling CertFreeCRLContext. CertDuplicateCRLContext can be called to make a duplicate.
		/// CertSetCRLContextProperty and CertGetCRLContextProperty can be called to store and read properties for the CRL.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcreatecrlcontext PCCRL_CONTEXT CertCreateCRLContext(
		// DWORD dwCertEncodingType, const BYTE *pbCrlEncoded, DWORD cbCrlEncoded );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "23d9dfb0-926d-443e-b960-a03338f1cc1b")]
		public static extern SafePCCRL_CONTEXT CertCreateCRLContext(CertEncodingType dwCertEncodingType, [In] IntPtr pbCrlEncoded, uint cbCrlEncoded);

		/// <summary>
		/// The <c>CertDeleteCRLFromStore</c> function deletes the specified certificate revocation list (CRL) context from the certificate store.
		/// </summary>
		/// <param name="pCrlContext">A pointer to the CRL_CONTEXT structure to be deleted.</param>
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
		/// All subsequent get or find operations for the CRL in this store fail. However, memory allocated for the CRL is not freed until
		/// all duplicated contexts have also been freed.
		/// </para>
		/// <para>The pCrlContext parameter is always freed by this function by using CertFreeCRLContext, even for an error.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certdeletecrlfromstore BOOL CertDeleteCRLFromStore(
		// PCCRL_CONTEXT pCrlContext );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "eb542c25-8d2b-4427-8f2a-719b472613a5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertDeleteCRLFromStore([In] PCCRL_CONTEXT pCrlContext);

		/// <summary>
		/// The <c>CertDuplicateCRLContext</c> function duplicates a certificate revocation list (CRL) context by incrementing its reference count.
		/// </summary>
		/// <param name="pCrlContext">A pointer to the CRL_CONTEXT structure for which the reference count is being incremented.</param>
		/// <returns>
		/// Currently, a copy is not made of the context, and the returned context is the same as the context that was input. If the pointer
		/// passed into this function is <c>NULL</c>, <c>NULL</c> is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certduplicatecrlcontext PCCRL_CONTEXT
		// CertDuplicateCRLContext( PCCRL_CONTEXT pCrlContext );
		[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "ea14c494-d1c7-46d0-9d56-fc89a4b4afa9")]
		public static extern PCCRL_CONTEXT CertDuplicateCRLContext([In] PCCRL_CONTEXT pCrlContext);

		/// <summary>
		/// The <c>CertEnumCRLsInStore</c> function retrieves the first or next certificate revocation list (CRL) context in a certificate
		/// store. Used in a loop, this function can retrieve in sequence all CRL contexts in a certificate store.
		/// </summary>
		/// <param name="hCertStore">Handle of a certificate store.</param>
		/// <param name="pPrevCrlContext">
		/// A pointer to the previous CRL_CONTEXT structure found. The pPrevCrlContext parameter must be <c>NULL</c> to get the first CRL in
		/// the store. Successive CRLs are enumerated by setting pPrevCrlContext to the pointer returned by a previous call to the function.
		/// This function frees the <c>CRL_CONTEXT</c> referenced by non- <c>NULL</c> values of this parameter. The enumeration skips any
		/// CRLs previously deleted by CertDeleteCRLFromStore.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to the next CRL_CONTEXT in the store.</para>
		/// <para>
		/// <c>NULL</c> is returned if the function fails. For extended error information, call GetLastError. Some possible error codes follow.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The handle in the hCertStore parameter is not the same as that in the certificate context pointed to by pPrevCrlContext.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_E_NOT_FOUND</term>
		/// <term>No CRL was found. This happens if the store is empty or the end of the store's list is reached.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The returned pointer is freed when it is passed as the pPrevCrlContext on a subsequent call to the function. Otherwise, the
		/// pointer must explicitly be freed by calling CertFreeCRLContext. A pPrevCrlContext that is not <c>NULL</c> is always freed when
		/// passed to this function through a call to <c>CertFreeCRLContext</c>, even if the function itself returns an error.
		/// </para>
		/// <para>A duplicate of the CRL context returned by this function can be made by calling CertDuplicateCRLContext.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certenumcrlsinstore PCCRL_CONTEXT CertEnumCRLsInStore(
		// HCERTSTORE hCertStore, PCCRL_CONTEXT pPrevCrlContext );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "fc25ca04-8520-4053-9591-afc81c88670c")]
		public static extern SafePCCRL_CONTEXT CertEnumCRLsInStore(HCERTSTORE hCertStore, [In] PCCRL_CONTEXT pPrevCrlContext);

		/// <summary>The <c>CertFindCertificateInCRL</c> function searches the certificate revocation list (CRL) for the specified certificate.</summary>
		/// <param name="pCert">A pointer to a CERT_CONTEXT of the certificate to be searched for in the CRL.</param>
		/// <param name="pCrlContext">A pointer to the CRL_CONTEXT to be searched.</param>
		/// <param name="dwFlags">Reserved for future use. Must be set to zero.</param>
		/// <param name="pvReserved">Reserved for future use. Must be set to zero.</param>
		/// <param name="ppCrlEntry">
		/// If the certificate is found in the CRL, this pointer is updated with a pointer to the entry. Otherwise, it is set to
		/// <c>NULL</c>. The returned entry is not allocated and must not be freed.
		/// </param>
		/// <returns><c>TRUE</c> if the list was searched; otherwise <c>FALSE</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfindcertificateincrl BOOL CertFindCertificateInCRL(
		// PCCERT_CONTEXT pCert, PCCRL_CONTEXT pCrlContext, DWORD dwFlags, void *pvReserved, PCRL_ENTRY *ppCrlEntry );
		[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "c05a99e6-da38-431e-8d02-04056047a211")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertFindCertificateInCRL([In] PCCERT_CONTEXT pCert, [In] PCCRL_CONTEXT pCrlContext, [Optional] uint dwFlags, [Optional] IntPtr pvReserved, out IntPtr ppCrlEntry);

		/// <summary>
		/// The <c>CertFindCRLInStore</c> function finds the first or next certificate revocation list (CRL) context in a certificate store
		/// that matches a search criterion established by the dwFindType parameter and the associated pvFindPara parameter. This function
		/// can be used in a loop to find all of the CRL contexts in a certificate store that match the specified find criteria.
		/// </summary>
		/// <param name="hCertStore">A handle of the certificate store to be searched.</param>
		/// <param name="dwCertEncodingType">This parameter is not currently used. It must be set to zero.</param>
		/// <param name="dwFindFlags">
		/// <para>
		/// If dwFindType is CRL_FIND_ISSUED_BY, by default, only issuer name matching is done. The following flags can be used to do
		/// additional filtering.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRL_FIND_ISSUED_BY_AKI_FLAG</term>
		/// <term>
		/// Checks for a CRL that has an Authority Key Identifier (AKI) extension. If the CRL has an AKI, only a CRL whose AKI matches the
		/// issuer is returned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRL_FIND_ISSUED_BY_SIGNATURE_FLAG</term>
		/// <term>
		/// Use the public key in the issuer's certificate to verify the signature on the CRL. Only returns a CRL that has a valid signature.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRL_FIND_ISSUED_BY_DELTA_FLAG</term>
		/// <term>Finds and returns a delta CRL.</term>
		/// </item>
		/// <item>
		/// <term>CRL_FIND_ISSUED_BY_BASE_FLAG</term>
		/// <term>Finds and returns a base CRL.</term>
		/// </item>
		/// <item>
		/// <term>CRL_FIND_ISSUED_FOR_SET_STRONG_PROPERTIES_FLAG</term>
		/// <term>
		/// The signature is checked for strength after successful verification. This flag applies only when the dwFindType parameter is set
		/// to CRL_FIND_ISSUED_FOR. You must also set CRL_FIND_ISSUED_BY_SIGNATURE_FLAG. If successful, the following strong signature
		/// properties will be set on the CRL context: Windows 8 and Windows Server 2012: Support for this flag begins.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFindType">
		/// <para>
		/// Specifies the type of search being made. The value of dwFindType determines the data type, contents, and use of the pvFindPara
		/// parameter. Currently defined search types and their pvFindPara requirements are as follows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRL_FIND_ANY The pvFindPara parameter is not used. It must be set to NULL.</term>
		/// <term>No search criteria. The next CRL in the store is returned.</term>
		/// </item>
		/// <item>
		/// <term>CRL_FIND_ISSUED_BY A pointer to a CERT_CONTEXT.</term>
		/// <term>Searches for the next CRL in the store matching the issuer in the CERT_CONTEXT.</term>
		/// </item>
		/// <item>
		/// <term>CRL_FIND_EXISTING A pointer to a CRL_CONTEXT.</term>
		/// <term>Searches for the next CRL that matches the CRL_CONTEXT in the following ways:</term>
		/// </item>
		/// <item>
		/// <term>CRL_FIND_ISSUED_FOR A pointer to a CRL_FIND_ISSUED_FOR_PARA.</term>
		/// <term>
		/// Searches for the next CRL in the store that matches the issuer of the subject certificate in the CRL_FIND_ISSUED_FOR_PARA
		/// structure. If no CRL is found, searches for the next CRL in the store that matches the issuer in the CRL_FIND_ISSUED_FOR_PARA structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pvFindPara">
		/// This parameter is determined by the value of dwFindType. For details, see the table earlier in this topic.
		/// </param>
		/// <param name="pPrevCrlContext">
		/// A pointer to the last CRL_CONTEXT returned by this function. Must be <c>NULL</c> to get the first CRL in the store meeting the
		/// search criteria. Successive CRLs meeting the search criteria can be found by setting pPrevCrlContext to the <c>PCCRL_CONTEXT</c>
		/// pointer returned by a previous call to the function. The search process skips any CRLs that do not match the search criteria or
		/// that have been previously deleted from the store by CertDeleteCRLFromStore. This function frees the <c>CRL_CONTEXT</c>
		/// referenced by values of this parameter that are not <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the function returns a pointer to a read-only CRL context. When you have finished using the returned
		/// CRL context, free it by calling the CertFreeCRLContext function or implicitly free it by passing it as the pPrevCrlContext
		/// parameter on a subsequent call to the <c>CertFindCRLInStore</c> function.
		/// </para>
		/// <para>
		/// If the function fails and a CRL that matches the search criteria is not found, the return value is <c>NULL</c>. For extended
		/// error information, call GetLastError. Some possible error codes follow.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// The handle in the hCertStore parameter is not the same as that in the CRL context pointed to by the pPrevCrlContext parameter,
		/// or a search type that is not valid was specified in the dwFindType parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPT_E_NOT_FOUND</term>
		/// <term>No CRLs are in the store, no CRL was found that matched the search criteria, or the end of the store's list was reached.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The returned pointer is freed when passed as the pPrevCrlContext parameter on a subsequent call to the function. Otherwise, the
		/// pointer must be explicitly freed by calling CertFreeCRLContext. A pPrevCrlContext that is not <c>NULL</c> is always freed by
		/// <c>CertFindCRLInStore</c> using a call to <c>CertFreeCRLContext</c>, even if there is an error in the function.
		/// </para>
		/// <para>
		/// CertDuplicateCRLContext can be called to make a duplicate of the returned context. The returned CRL context can be added to a
		/// different certificate store by using CertAddCRLContextToStore, or a link to that CRL context can be added to a noncollection
		/// store by using CertAddCRLLinkToStore.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfindcrlinstore PCCRL_CONTEXT CertFindCRLInStore(
		// HCERTSTORE hCertStore, DWORD dwCertEncodingType, DWORD dwFindFlags, DWORD dwFindType, const void *pvFindPara, PCCRL_CONTEXT
		// pPrevCrlContext );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "3e481912-204a-4d86-ab67-81f8ae4d1aaa")]
		public static extern SafePCCRL_CONTEXT CertFindCRLInStore(HCERTSTORE hCertStore, CertEncodingType dwCertEncodingType, CrlFindFlags dwFindFlags, CrlFindType dwFindType, [In, Optional] IntPtr pvFindPara, [In, Optional] PCCRL_CONTEXT pPrevCrlContext);

		/// <summary>
		/// <para>
		/// The <c>CertFreeCRLContext</c> function frees a certificate revocation list (CRL) context by decrementing its reference count.
		/// When the reference count goes to zero, <c>CertFreeCRLContext</c> frees the memory used by a CRL context.
		/// </para>
		/// <para>
		/// To free a context obtained by a get, duplicate, or create function, call the appropriate free function. To free a context
		/// obtained by a find or enumerate function, either pass it in as the previous context parameter to a subsequent invocation of the
		/// function, or call the appropriate free function. For more information, see the reference topic for the function that obtains the context.
		/// </para>
		/// </summary>
		/// <param name="pCrlContext">A pointer to the CRL_CONTEXT to be freed.</param>
		/// <returns>The function always returns <c>TRUE</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfreecrlcontext BOOL CertFreeCRLContext( PCCRL_CONTEXT
		// pCrlContext );
		[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "19a590a5-bd39-4bbe-ad86-4e648baa1ba8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertFreeCRLContext([In] PCCRL_CONTEXT pCrlContext);

		/// <summary>
		/// The <c>CertGetCRLFromStore</c> function gets the first or next certificate revocation list (CRL) context from the certificate
		/// store for the specified issuer. The function also performs the enabled verification checks on the CRL. The new Certificate Chain
		/// Verification Functions are recommended instead of this function.
		/// </summary>
		/// <param name="hCertStore">Handle of a certificate store.</param>
		/// <param name="pIssuerContext">
		/// A pointer to an issuer CERT_CONTEXT. The pIssuerContext pointer can come from this store or another store, or could have been
		/// created by the calling CertCreateCertificateContext. If <c>NULL</c> is passed for this parameter, all the CRLs in the store are found.
		/// </param>
		/// <param name="pPrevCrlContext">
		/// A pointer to a CRL_CONTEXT. An issuer can have multiple CRLs. For example, it can generate delta CRLs by using an X.509 version
		/// 3 extension. This parameter must be <c>NULL</c> on the first call to get the CRL. To get the next CRL for the issuer, the
		/// parameter is set to the <c>CRL_CONTEXT</c> returned by a previous call. A non- <c>NULL</c> pPrevCrlContext is always freed by
		/// this function by calling CertFreeCRLContext, even for an error.
		/// </param>
		/// <param name="pdwFlags">
		/// <para>
		/// The following flag values are defined to enable verification checks on the returned CRL. These flags can be combined using a
		/// bitwise- <c>OR</c> operation.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_STORE_SIGNATURE_FLAG</term>
		/// <term>Uses the public key in the issuer's certificate to verify the signature on the returned CRL.</term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_TIME_VALIDITY_FLAG</term>
		/// <term>Gets the current time and verifies that it is within the time between the CRL's ThisUpdate and NextUpdate.</term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_BASE_CRL_FLAG</term>
		/// <term>Gets a base CRL.</term>
		/// </item>
		/// <item>
		/// <term>CERT_STORE_DELTA_CRL_FLAG</term>
		/// <term>Gets a delta CRL.</term>
		/// </item>
		/// </list>
		/// <para>If an enabled verification check succeeds, its flag is set to zero.</para>
		/// <para>
		/// If an enabled verification check fails, its flag remains set upon return. If pIssuerContext is <c>NULL</c>, then an enabled
		/// CERT_STORE_SIGNATURE_FLAG always fails and the CERT_STORE_NO_ISSUER_FLAG is also set. For more details, see Remarks.
		/// </para>
		/// <para>
		/// If only one of CERT_STORE_BASE_CRL_FLAG or CERT_STORE_DELTA_CRL_FLAG is set, this function returns either a base or delta CRL
		/// and the appropriate base or delta flag will be cleared on return. If both flags are set, only one of the flags will be cleared.
		/// </para>
		/// <para>
		/// For a verification check failure, a pointer to the first or next CRL_CONTEXT is still returned and GetLastError is not updated.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to a read-only CRL_CONTEXT.</para>
		/// <para>If the function fails and the first or next CRL is not found, the return value is <c>NULL</c>.</para>
		/// <para>
		/// The returned CRL_CONTEXT must be freed by calling CertFreeCRLContext. However, when the returned <c>CRL_CONTEXT</c> is supplied
		/// for pPrevCrlContext on a subsequent call, the function frees it.
		/// </para>
		/// <para>For extended error information, call GetLastError. Some possible error codes follow.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// The handle in the hCertStore parameter is not the same as that in the CRL context pointed to by the pPrevCrlContext parameter,
		/// or an unsupported flag was set in pdwFlags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPT_E_NOT_FOUND</term>
		/// <term>Either no CRLs existed in the store for the issuer, or the function reached the end of the store's list.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>CertDuplicateCRLContext can be called to make a duplicate CRL.</para>
		/// <para>
		/// The hexadecimal values of the flags can be combined using a bitwise- <c>OR</c> operation to enable both verifications. For
		/// example, to enable both verifications, the <c>DWORD</c> value pointed to by pdwFlags is set to value CERT_STORE_SIGNATURE_FLAG |
		/// CERT_STORE_TIME_VALIDITY_FLAG. If the CERT_STORE_SIGNATURE_FLAG verification succeeded, but CERT_STORE_TIME_VALIDITY_FLAG
		/// verification failed, the <c>DWORD</c> value pointed to by pdwFlags is set to CERT_STORE_TIME_VALIDITY_FLAG when the function returns.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetcrlfromstore PCCRL_CONTEXT CertGetCRLFromStore(
		// HCERTSTORE hCertStore, PCCERT_CONTEXT pIssuerContext, PCCRL_CONTEXT pPrevCrlContext, DWORD *pdwFlags );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "7bd21424-4f74-4bac-ab47-00d51ebdca1c")]
		public static extern SafePCCRL_CONTEXT CertGetCRLFromStore(HCERTSTORE hCertStore, [In, Optional] PCCERT_CONTEXT pIssuerContext, [In, Optional] PCCRL_CONTEXT pPrevCrlContext, ref CertStoreVerification pdwFlags);

		/// <summary>
		/// The <c>CertSerializeCRLStoreElement</c> function serializes an encoded certificate revocation list (CRL) context and the encoded
		/// representation of its properties. The result can be persisted to storage so that the CRL and properties can be retrieved at a
		/// later time.
		/// </summary>
		/// <param name="pCrlContext">A pointer to the CRL_CONTEXT structure being serialized.</param>
		/// <param name="dwFlags">Reserved for future use and must be zero.</param>
		/// <param name="pbElement">
		/// <para>A pointer to a buffer to receive the serialized output, including the encoded CRL, and possibly its properties.</para>
		/// <para>
		/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
		/// Retrieving Data of Unknown Length.
		/// </para>
		/// </param>
		/// <param name="pcbElement">
		/// <para>
		/// A pointer to a <c>DWORD</c> value specifying the size, in bytes, of the buffer pointed to by the pbElement parameter. When the
		/// function returns, the <c>DWORD</c> value contains the number of bytes stored in the buffer.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certserializecrlstoreelement BOOL
		// CertSerializeCRLStoreElement( PCCRL_CONTEXT pCrlContext, DWORD dwFlags, BYTE *pbElement, DWORD *pcbElement );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "4ab053cd-d3d4-483c-b0ff-b8de63d88707")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertSerializeCRLStoreElement([In] PCCRL_CONTEXT pCrlContext, [Optional] uint dwFlags, IntPtr pbElement, ref uint pcbElement);

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="PCCRL_CONTEXT"/> that is disposed using <see cref="CertFreeCRLContext"/>.</summary>
		public class SafePCCRL_CONTEXT : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafePCCRL_CONTEXT"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafePCCRL_CONTEXT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafePCCRL_CONTEXT"/> class.</summary>
			private SafePCCRL_CONTEXT() : base() { }

			/// <summary>Performs an explicit conversion from <see cref="SafePCCRL_CONTEXT"/> to <see cref="CRL_CONTEXT"/>.</summary>
			/// <param name="ctx">The <see cref="SafePCCRL_CONTEXT"/> instance.</param>
			/// <returns>The resulting <see cref="CRL_CONTEXT"/> instance from the conversion.</returns>
			public static unsafe explicit operator CRL_CONTEXT*(SafePCCRL_CONTEXT ctx) => (CRL_CONTEXT*)(void*)ctx.handle;

			/// <summary>Performs an implicit conversion from <see cref="SafePCCRL_CONTEXT"/> to <see cref="PCCRL_CONTEXT"/>.</summary>
			/// <param name="ctx">The <see cref="SafePCCRL_CONTEXT"/> instance.</param>
			/// <returns>The resulting <see cref="PCCRL_CONTEXT"/> instance from the conversion.</returns>
			public static implicit operator PCCRL_CONTEXT(SafePCCRL_CONTEXT ctx) => ctx.DangerousGetHandle();

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => CertFreeCRLContext(handle);
		}
	}
}