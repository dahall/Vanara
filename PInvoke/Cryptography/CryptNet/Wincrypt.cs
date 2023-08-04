using System.Linq;
using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke;

/// <summary>Methods and data types found in CryptNet.dll.</summary>
public static partial class CryptNet
{
	/// <summary>A set of flags used to get the URL locator for an object.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "a92117b8-9144-4480-b88a-b9ffe1026d63")]
	[Flags]
	public enum CryptGetUrlFlags
	{
		/// <summary>Locates the URL from the property of the object (the location of the data).</summary>
		CRYPT_GET_URL_FROM_PROPERTY = 0x00000001,

		/// <summary>Locates the URL from the extension of the object.</summary>
		CRYPT_GET_URL_FROM_EXTENSION = 0x00000002,

		/// <summary>Locates the URL from an unauthenticated attribute from the signer information data.</summary>
		CRYPT_GET_URL_FROM_UNAUTH_ATTRIBUTE = 0x00000004,

		/// <summary>Locates the URL from an authenticated attribute from the signer information data.</summary>
		CRYPT_GET_URL_FROM_AUTH_ATTRIBUTE = 0x00000008,
	}

	/// <summary>A set of flags used to get the URL locator for an object.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "a92117b8-9144-4480-b88a-b9ffe1026d63")]
	[Flags]
	public enum CryptGetUrlFromFlags
	{
		/// <term>Locates the URL from the property of the object (the location of the data).</term>
		CRYPT_GET_URL_FROM_PROPERTY = 0x00000001,

		/// <term>Locates the URL from the extension of the object.</term>
		CRYPT_GET_URL_FROM_EXTENSION = 0x00000002,

		/// <term>Locates the URL from an unauthenticated attribute from the signer information data.</term>
		CRYPT_GET_URL_FROM_UNAUTH_ATTRIBUTE = 0x00000004,

		/// <term>Locates the URL from an authenticated attribute from the signer information data.</term>
		CRYPT_GET_URL_FROM_AUTH_ATTRIBUTE = 0x00000008,
	}

	/// <summary>A value that determines various retrieval factors such as time-out, source, and validity checks.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "dd639b43-1560-4e9f-a778-9e20484ae012")]
	[Flags]
	public enum TimeValidObjectFlags
	{
		/// <summary>Use the cumulative time-out registry setting of the client computer for revocation URL retrievals.</summary>
		CRYPT_ACCUMULATIVE_TIMEOUT = 0x00000800,

		/// <summary>Retrieve the encoded bits from the client URL cache only. Do not use the wire to retrieve the URL.</summary>
		CRYPT_CACHE_ONLY_RETRIEVAL = 0x00000002,

		/// <summary>
		/// Check if the ThisUpdate property or extension of the current context is greater than or equal to the ftValidFor parameter.
		/// </summary>
		CRYPT_CHECK_FRESHNESS_TIME_VALIDITY = 0x00000400,

		/// <summary>
		/// Do not perform time validity check. Use this to retrieve a more recent base CRL over the wire or to bypass time validity
		/// check during a cache retrieval. When this flag is set, pftValidFor can be NULL.
		/// </summary>
		CRYPT_DONT_CHECK_TIME_VALIDITY = 0x00000200,

		/// <summary>
		/// Do not perform signature verification. Use this when verification of the retrieved object will be performed outside of this
		/// function or to force a replacement of a retrieved cache entry with a new cache entry for the object.
		/// </summary>
		CRYPT_DONT_VERIFY_SIGNATURE = 0x00000100,

		/// <summary>This value is reserved for future use.</summary>
		CRYPT_KEEP_TIME_VALID = 0x00000080,

		/// <summary>
		/// Retrieves the time valid object from an OCSP responder service only based on Authority Information Access URLs in the
		/// current context. The CertVerifyRevocation function sets this flag when it is called with the dwFlags parameter set to CERT_VERIFY_REV_SERVER_OCSP_FLAG.
		/// </summary>
		CRYPT_OCSP_ONLY_RETRIEVAL = 0x01000000,

		/// <summary>Retrieves the encoded bits from the wire only. Does not use the URL cache.</summary>
		CRYPT_WIRE_ONLY_RETRIEVAL = 0x00000004,
	}

	/// <summary>
	/// <para>
	/// The <c>CryptGetObjectUrl</c> function acquires the URL of the remote object from a certificate, certificate trust list (CTL), or
	/// certificate revocation list (CRL).
	/// </para>
	/// <para>
	/// The function takes the object, decodes it, and provides a pointer to an array of URLs from the object. For example, from a
	/// certificate, a CRL distribution list of URLs would be in the array.
	/// </para>
	/// </summary>
	/// <param name="pszUrlOid">
	/// <para>
	/// A pointer to an object identifier (OID) that identifies the URL being requested. If the HIWORD of the pszUrlOid parameter is
	/// zero, the LOWORD specifies the integer identifier for the type of the specified structure.
	/// </para>
	/// <para>
	/// This parameter can be one of the following values. For information about how these values affect the pvPara parameter, see the
	/// heading "For the pvPara parameter" in the <c>Meaning</c> column.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_ISSUER</term>
	/// <term>
	/// Provides the URL of the certificate issuer retrieved from the authority information access extension or property of a
	/// certificate. For the pvPara parameter: A pointer to a CERT_CONTEXT structure that was issued by the issuer whose URL is being requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_CRL_DIST_POINT</term>
	/// <term>
	/// Provides a list of URLs of the CRL distribution points retrieved from the CRL distribution point extension or property of a
	/// certificate. For the pvPara parameter: A pointer to a CERT_CONTEXT structure whose CRL distribution point is requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_CRL_DIST_POINT_AND_OCSP</term>
	/// <term>
	/// Provides a list of OCSP and CRL distribution point URLs from the authority information access (AIA) and CRL distribution point
	/// extensions or properties of a certificate. The function returns any CRL distribution point URLs first. Before using any OCSP
	/// URLs, you must remove the L"ocsp:" prefix. For the pvPara parameter: A pointer to a CERT_CONTEXT structure whose OCSP and CRL
	/// distribution point URLs are requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_OCSP</term>
	/// <term>
	/// Provides an OCSP URL from the authority information access (AIA) extension or property of a certificate. For the pvPara
	/// parameter: A pointer to a CERT_CONTEXT structure whose OCSP URL is requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_OCSP_AND_CRL_DIST_POINT</term>
	/// <term>
	/// Provides a list of OCSP and CRL distribution point URLs from the authority information access (AIA) and CRL distribution point
	/// extensions or properties of a certificate. The function returns any OCSP URLs first. Before using any OCSP URLs, you must remove
	/// the L"ocsp:" prefix. For the pvPara parameter: A pointer to a CERT_CONTEXT structure whose OCSP and CRL distribution point URLs
	/// are requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_ONLY_OCSP</term>
	/// <term>
	/// Provides a list of OCSP URLs from the authority information access (AIA) extension or property of a certificate. Before using
	/// any OCSP URLs, you must remove the L"ocsp:" prefix. For the pvPara parameter: A pointer to a CERT_CONTEXT structure whose OCSP
	/// URLs are requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CTL_ISSUER</term>
	/// <term>
	/// Provides the URL of the CTL issuer retrieved from an authority information access attribute method encoded in each signer
	/// information in the PKCS #7 CTL. For the pvPara parameter: A pointer to a Signer Index CTL_CONTEXT structure that was issued by
	/// the issuer whose URL, identified by the signer index, is requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CTL_NEXT_UPDATE</term>
	/// <term>
	/// Provides the URL of the next update of that CTL retrieved from an authority information access CTL extension, property, or
	/// signer information attribute method. For the pvPara parameter: A pointer to a Signer Index CTL_CONTEXT structure whose next
	/// update URL is requested, and an optional signer index, in case it is needed to check the signer information attributes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CRL_ISSUER</term>
	/// <term>
	/// Provides the URL of the CRL issuer retrieved from a property on a CRL that was inherited from the subject certificate (either
	/// from the subject certificate issuer or the subject certificate distribution point extension). It is encoded as an authority
	/// information access extension method. For the pvPara parameter: A pointer to a CRL_CONTEXT structure that was issued by the
	/// issuer whose URL is requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_FRESHEST_CRL</term>
	/// <term>
	/// Retrieves the most recent CRL extension or property of the certificate. For the pvPara parameter: The PCCERT_CONTEXT of a
	/// certificate whose most recent CRL distribution point is being requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CRL_FRESHEST_CRL</term>
	/// <term>
	/// Retrieves the most recent CRL extension or property of the CRL. For the pvPara parameter: A pointer to a CERT_CRL_CONTEXT_PAIR
	/// structure that contains the base CRL of a certificate whose most recent CRL distribution point is being requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CROSS_CERT_DIST_POINT</term>
	/// <term>
	/// Retrieves the cross certificate distribution point extension or property of the certificate. For the pvPara parameter: The
	/// PCCERT_CONTEXT of a certificate whose cross certificate distribution point is being requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CROSS_CERT_SUBJECT_INFO_ACCESS</term>
	/// <term>
	/// Retrieves the cross certificate Subject Information Access extension or property of the certificate. For the pvPara parameter:
	/// The PCCERT_CONTEXT of a certificate whose cross certificate Subject Information Access is being requested.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvPara">A structure determined by the value of pszUrlOid. For details, see the description for the pszUrlOid parameter.</param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags used to get the URL locator for an object. This can be zero or a combination of one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_GET_URL_FROM_PROPERTY</term>
	/// <term>Locates the URL from the property of the object (the location of the data).</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_GET_URL_FROM_EXTENSION</term>
	/// <term>Locates the URL from the extension of the object.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_GET_URL_FROM_UNAUTH_ATTRIBUTE</term>
	/// <term>Locates the URL from an unauthenticated attribute from the signer information data.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_GET_URL_FROM_AUTH_ATTRIBUTE</term>
	/// <term>Locates the URL from an authenticated attribute from the signer information data.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pUrlArray">
	/// <para>
	/// A pointer to a buffer to receive the data for the value entry. This parameter can be <c>NULL</c> to find the length of the
	/// buffer required to hold the data.
	/// </para>
	/// <para>For more information, see Retrieving Data of Unknown Length.</para>
	/// </param>
	/// <param name="pcbUrlArray">
	/// A pointer to a <c>DWORD</c> that specifies the size, in bytes, of the buffer pointed to by the pUrlArray parameter. When the
	/// function returns, the <c>DWORD</c> contains the number of bytes stored in the buffer. This parameter can be <c>NULL</c> only if
	/// pUrlArray is <c>NULL</c>.
	/// </param>
	/// <param name="pUrlInfo">An optional pointer to a CRYPT_URL_INFO structure that receives the data for the value entry.</param>
	/// <param name="pcbUrlInfo">
	/// <para>
	/// A pointer to a <c>DWORD</c> that specifies the size, in bytes, of the buffer pointed to by the pUrlArray parameter. When the
	/// function returns, the <c>DWORD</c> contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. On input, buffer sizes are usually specified
	/// large enough to ensure that the largest possible output data will fit in the buffer. On output, the variable pointed to by this
	/// parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <param name="pvReserved">Reserved for future use and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgetobjecturl BOOL CryptGetObjectUrl( LPCSTR
	// pszUrlOid, LPVOID pvPara, DWORD dwFlags, PCRYPT_URL_ARRAY pUrlArray, DWORD *pcbUrlArray, PCRYPT_URL_INFO pUrlInfo, DWORD
	// *pcbUrlInfo, LPVOID pvReserved );
	[DllImport(Lib.Cryptnet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "a92117b8-9144-4480-b88a-b9ffe1026d63")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGetObjectUrl([In] SafeOID pszUrlOid, [In] IntPtr pvPara, CryptGetUrlFromFlags dwFlags,
		[Optional] IntPtr pUrlArray, ref uint pcbUrlArray, [Optional] IntPtr pUrlInfo, ref uint pcbUrlInfo, IntPtr pvReserved = default);

	/// <summary>
	/// <para>
	/// The <c>CryptGetObjectUrl</c> function acquires the URL of the remote object from a certificate, certificate trust list (CTL), or
	/// certificate revocation list (CRL).
	/// </para>
	/// <para>
	/// The function takes the object, decodes it, and provides a pointer to an array of URLs from the object. For example, from a
	/// certificate, a CRL distribution list of URLs would be in the array.
	/// </para>
	/// </summary>
	/// <param name="pszUrlOid">
	/// <para>
	/// A pointer to an object identifier (OID) that identifies the URL being requested. If the HIWORD of the pszUrlOid parameter is
	/// zero, the LOWORD specifies the integer identifier for the type of the specified structure.
	/// </para>
	/// <para>
	/// This parameter can be one of the following values. For information about how these values affect the pvPara parameter, see the
	/// heading "For the pvPara parameter" in the <c>Meaning</c> column.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_ISSUER</term>
	/// <term>
	/// Provides the URL of the certificate issuer retrieved from the authority information access extension or property of a
	/// certificate. For the pvPara parameter: A pointer to a CERT_CONTEXT structure that was issued by the issuer whose URL is being requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_CRL_DIST_POINT</term>
	/// <term>
	/// Provides a list of URLs of the CRL distribution points retrieved from the CRL distribution point extension or property of a
	/// certificate. For the pvPara parameter: A pointer to a CERT_CONTEXT structure whose CRL distribution point is requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_CRL_DIST_POINT_AND_OCSP</term>
	/// <term>
	/// Provides a list of OCSP and CRL distribution point URLs from the authority information access (AIA) and CRL distribution point
	/// extensions or properties of a certificate. The function returns any CRL distribution point URLs first. Before using any OCSP
	/// URLs, you must remove the L"ocsp:" prefix. For the pvPara parameter: A pointer to a CERT_CONTEXT structure whose OCSP and CRL
	/// distribution point URLs are requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_OCSP</term>
	/// <term>
	/// Provides an OCSP URL from the authority information access (AIA) extension or property of a certificate. For the pvPara
	/// parameter: A pointer to a CERT_CONTEXT structure whose OCSP URL is requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_OCSP_AND_CRL_DIST_POINT</term>
	/// <term>
	/// Provides a list of OCSP and CRL distribution point URLs from the authority information access (AIA) and CRL distribution point
	/// extensions or properties of a certificate. The function returns any OCSP URLs first. Before using any OCSP URLs, you must remove
	/// the L"ocsp:" prefix. For the pvPara parameter: A pointer to a CERT_CONTEXT structure whose OCSP and CRL distribution point URLs
	/// are requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_ONLY_OCSP</term>
	/// <term>
	/// Provides a list of OCSP URLs from the authority information access (AIA) extension or property of a certificate. Before using
	/// any OCSP URLs, you must remove the L"ocsp:" prefix. For the pvPara parameter: A pointer to a CERT_CONTEXT structure whose OCSP
	/// URLs are requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CTL_ISSUER</term>
	/// <term>
	/// Provides the URL of the CTL issuer retrieved from an authority information access attribute method encoded in each signer
	/// information in the PKCS #7 CTL. For the pvPara parameter: A pointer to a Signer Index CTL_CONTEXT structure that was issued by
	/// the issuer whose URL, identified by the signer index, is requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CTL_NEXT_UPDATE</term>
	/// <term>
	/// Provides the URL of the next update of that CTL retrieved from an authority information access CTL extension, property, or
	/// signer information attribute method. For the pvPara parameter: A pointer to a Signer Index CTL_CONTEXT structure whose next
	/// update URL is requested, and an optional signer index, in case it is needed to check the signer information attributes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CRL_ISSUER</term>
	/// <term>
	/// Provides the URL of the CRL issuer retrieved from a property on a CRL that was inherited from the subject certificate (either
	/// from the subject certificate issuer or the subject certificate distribution point extension). It is encoded as an authority
	/// information access extension method. For the pvPara parameter: A pointer to a CRL_CONTEXT structure that was issued by the
	/// issuer whose URL is requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_FRESHEST_CRL</term>
	/// <term>
	/// Retrieves the most recent CRL extension or property of the certificate. For the pvPara parameter: The PCCERT_CONTEXT of a
	/// certificate whose most recent CRL distribution point is being requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CRL_FRESHEST_CRL</term>
	/// <term>
	/// Retrieves the most recent CRL extension or property of the CRL. For the pvPara parameter: A pointer to a CERT_CRL_CONTEXT_PAIR
	/// structure that contains the base CRL of a certificate whose most recent CRL distribution point is being requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CROSS_CERT_DIST_POINT</term>
	/// <term>
	/// Retrieves the cross certificate distribution point extension or property of the certificate. For the pvPara parameter: The
	/// PCCERT_CONTEXT of a certificate whose cross certificate distribution point is being requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CROSS_CERT_SUBJECT_INFO_ACCESS</term>
	/// <term>
	/// Retrieves the cross certificate Subject Information Access extension or property of the certificate. For the pvPara parameter:
	/// The PCCERT_CONTEXT of a certificate whose cross certificate Subject Information Access is being requested.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvPara">A structure determined by the value of pszUrlOid. For details, see the description for the pszUrlOid parameter.</param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags used to get the URL locator for an object. This can be zero or a combination of one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_GET_URL_FROM_PROPERTY</term>
	/// <term>Locates the URL from the property of the object (the location of the data).</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_GET_URL_FROM_EXTENSION</term>
	/// <term>Locates the URL from the extension of the object.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_GET_URL_FROM_UNAUTH_ATTRIBUTE</term>
	/// <term>Locates the URL from an unauthenticated attribute from the signer information data.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_GET_URL_FROM_AUTH_ATTRIBUTE</term>
	/// <term>Locates the URL from an authenticated attribute from the signer information data.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pUrlArray">
	/// <para>
	/// A pointer to a buffer to receive the data for the value entry. This parameter can be <c>NULL</c> to find the length of the
	/// buffer required to hold the data.
	/// </para>
	/// <para>For more information, see Retrieving Data of Unknown Length.</para>
	/// </param>
	/// <param name="pcbUrlArray">
	/// A pointer to a <c>DWORD</c> that specifies the size, in bytes, of the buffer pointed to by the pUrlArray parameter. When the
	/// function returns, the <c>DWORD</c> contains the number of bytes stored in the buffer. This parameter can be <c>NULL</c> only if
	/// pUrlArray is <c>NULL</c>.
	/// </param>
	/// <param name="pUrlInfo">An optional pointer to a CRYPT_URL_INFO structure that receives the data for the value entry.</param>
	/// <param name="pcbUrlInfo">
	/// <para>
	/// A pointer to a <c>DWORD</c> that specifies the size, in bytes, of the buffer pointed to by the pUrlArray parameter. When the
	/// function returns, the <c>DWORD</c> contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. On input, buffer sizes are usually specified
	/// large enough to ensure that the largest possible output data will fit in the buffer. On output, the variable pointed to by this
	/// parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <param name="pvReserved">Reserved for future use and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgetobjecturl BOOL CryptGetObjectUrl( LPCSTR
	// pszUrlOid, LPVOID pvPara, DWORD dwFlags, PCRYPT_URL_ARRAY pUrlArray, DWORD *pcbUrlArray, PCRYPT_URL_INFO pUrlInfo, DWORD
	// *pcbUrlInfo, LPVOID pvReserved );
	[DllImport(Lib.Cryptnet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "a92117b8-9144-4480-b88a-b9ffe1026d63")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGetObjectUrl([In] SafeOID pszUrlOid, [In] IntPtr pvPara, CryptGetUrlFlags dwFlags, [Optional] IntPtr pUrlArray,
		ref uint pcbUrlArray, [Optional] IntPtr pUrlInfo, ref uint pcbUrlInfo, IntPtr pvReserved = default);

	/// <summary>
	/// <para>
	/// The <c>CryptGetObjectUrl</c> function acquires the URL of the remote object from a certificate, certificate trust list (CTL), or
	/// certificate revocation list (CRL).
	/// </para>
	/// <para>
	/// The function takes the object, decodes it, and provides a pointer to an array of URLs from the object. For example, from a
	/// certificate, a CRL distribution list of URLs would be in the array.
	/// </para>
	/// </summary>
	/// <param name="pszUrlOid">
	/// <para>
	/// A pointer to an object identifier (OID) that identifies the URL being requested. If the HIWORD of the pszUrlOid parameter is
	/// zero, the LOWORD specifies the integer identifier for the type of the specified structure.
	/// </para>
	/// <para>
	/// This parameter can be one of the following values. For information about how these values affect the pvPara parameter, see the
	/// heading "For the pvPara parameter" in the <c>Meaning</c> column.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_ISSUER</term>
	/// <term>
	/// Provides the URL of the certificate issuer retrieved from the authority information access extension or property of a
	/// certificate. For the pvPara parameter: A pointer to a CERT_CONTEXT structure that was issued by the issuer whose URL is being requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_CRL_DIST_POINT</term>
	/// <term>
	/// Provides a list of URLs of the CRL distribution points retrieved from the CRL distribution point extension or property of a
	/// certificate. For the pvPara parameter: A pointer to a CERT_CONTEXT structure whose CRL distribution point is requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_CRL_DIST_POINT_AND_OCSP</term>
	/// <term>
	/// Provides a list of OCSP and CRL distribution point URLs from the authority information access (AIA) and CRL distribution point
	/// extensions or properties of a certificate. The function returns any CRL distribution point URLs first. Before using any OCSP
	/// URLs, you must remove the L"ocsp:" prefix. For the pvPara parameter: A pointer to a CERT_CONTEXT structure whose OCSP and CRL
	/// distribution point URLs are requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_OCSP</term>
	/// <term>
	/// Provides an OCSP URL from the authority information access (AIA) extension or property of a certificate. For the pvPara
	/// parameter: A pointer to a CERT_CONTEXT structure whose OCSP URL is requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_OCSP_AND_CRL_DIST_POINT</term>
	/// <term>
	/// Provides a list of OCSP and CRL distribution point URLs from the authority information access (AIA) and CRL distribution point
	/// extensions or properties of a certificate. The function returns any OCSP URLs first. Before using any OCSP URLs, you must remove
	/// the L"ocsp:" prefix. For the pvPara parameter: A pointer to a CERT_CONTEXT structure whose OCSP and CRL distribution point URLs
	/// are requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_ONLY_OCSP</term>
	/// <term>
	/// Provides a list of OCSP URLs from the authority information access (AIA) extension or property of a certificate. Before using
	/// any OCSP URLs, you must remove the L"ocsp:" prefix. For the pvPara parameter: A pointer to a CERT_CONTEXT structure whose OCSP
	/// URLs are requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CTL_ISSUER</term>
	/// <term>
	/// Provides the URL of the CTL issuer retrieved from an authority information access attribute method encoded in each signer
	/// information in the PKCS #7 CTL. For the pvPara parameter: A pointer to a Signer Index CTL_CONTEXT structure that was issued by
	/// the issuer whose URL, identified by the signer index, is requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CTL_NEXT_UPDATE</term>
	/// <term>
	/// Provides the URL of the next update of that CTL retrieved from an authority information access CTL extension, property, or
	/// signer information attribute method. For the pvPara parameter: A pointer to a Signer Index CTL_CONTEXT structure whose next
	/// update URL is requested, and an optional signer index, in case it is needed to check the signer information attributes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CRL_ISSUER</term>
	/// <term>
	/// Provides the URL of the CRL issuer retrieved from a property on a CRL that was inherited from the subject certificate (either
	/// from the subject certificate issuer or the subject certificate distribution point extension). It is encoded as an authority
	/// information access extension method. For the pvPara parameter: A pointer to a CRL_CONTEXT structure that was issued by the
	/// issuer whose URL is requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CERTIFICATE_FRESHEST_CRL</term>
	/// <term>
	/// Retrieves the most recent CRL extension or property of the certificate. For the pvPara parameter: The PCCERT_CONTEXT of a
	/// certificate whose most recent CRL distribution point is being requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CRL_FRESHEST_CRL</term>
	/// <term>
	/// Retrieves the most recent CRL extension or property of the CRL. For the pvPara parameter: A pointer to a CERT_CRL_CONTEXT_PAIR
	/// structure that contains the base CRL of a certificate whose most recent CRL distribution point is being requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CROSS_CERT_DIST_POINT</term>
	/// <term>
	/// Retrieves the cross certificate distribution point extension or property of the certificate. For the pvPara parameter: The
	/// PCCERT_CONTEXT of a certificate whose cross certificate distribution point is being requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term>URL_OID_CROSS_CERT_SUBJECT_INFO_ACCESS</term>
	/// <term>
	/// Retrieves the cross certificate Subject Information Access extension or property of the certificate. For the pvPara parameter:
	/// The PCCERT_CONTEXT of a certificate whose cross certificate Subject Information Access is being requested.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvPara">A structure determined by the value of pszUrlOid. For details, see the description for the pszUrlOid parameter.</param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags used to get the URL locator for an object. This can be zero or a combination of one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_GET_URL_FROM_PROPERTY</term>
	/// <term>Locates the URL from the property of the object (the location of the data).</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_GET_URL_FROM_EXTENSION</term>
	/// <term>Locates the URL from the extension of the object.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_GET_URL_FROM_UNAUTH_ATTRIBUTE</term>
	/// <term>Locates the URL from an unauthenticated attribute from the signer information data.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_GET_URL_FROM_AUTH_ATTRIBUTE</term>
	/// <term>Locates the URL from an authenticated attribute from the signer information data.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pUrlArray">
	/// <para>
	/// A pointer to a buffer to receive the data for the value entry. This parameter can be <c>NULL</c> to find the length of the
	/// buffer required to hold the data.
	/// </para>
	/// <para>For more information, see Retrieving Data of Unknown Length.</para>
	/// </param>
	/// <param name="dwSyncDeltaTime">Number of seconds between synchronizations.</param>
	/// <param name="rgcGroupEntry">Array of URL groups returned.</param>
	[PInvokeData("wincrypt.h", MSDNShortId = "a92117b8-9144-4480-b88a-b9ffe1026d63")]
	public static void CryptGetObjectUrl<T>([In] SafeOID pszUrlOid, [In] in T pvPara, CryptGetUrlFlags dwFlags, out string?[] pUrlArray, out uint dwSyncDeltaTime, out uint[]? rgcGroupEntry) where T : struct
	{
		using SafeCoTaskMemStruct<T> para = pvPara;
		uint asz = 0, isz = 0;
		CryptGetObjectUrl(pszUrlOid, para, dwFlags, default, ref asz, default, ref isz);
		using SafeCoTaskMemStruct<CRYPT_URL_ARRAY> urls = new(asz);
		using SafeCoTaskMemStruct<CRYPT_URL_INFO> info = new(isz);
		Win32Error.ThrowLastErrorIfFalse(CryptGetObjectUrl(pszUrlOid, para, dwFlags, urls, ref asz, info, ref isz));
		pUrlArray = urls.AsRef().rgwszUrl.ToStringEnum((int)urls.AsRef().cUrl, CharSet.Unicode, 0, asz).ToArray();
		dwSyncDeltaTime = info.AsRef().dwSyncDeltaTime;
		rgcGroupEntry = info.AsRef().rgcGroupEntry.ToArray<uint>((int)info.AsRef().cGroup, 0, isz);
	}

	/// <summary>
	/// The <c>CryptGetTimeValidObject</c> function retrieves a CRL, an OCSP response, or CTL object that is valid within a given
	/// context and time.
	/// </summary>
	/// <param name="pszTimeValidOid">
	/// <para>
	/// A pointer to an object identifier (OID) that identifies the object being requested. If the HIWORD of the pszTimeValidOid
	/// parameter is zero, the LOWORD specifies the integer identifier for the type of the specified structure.
	/// </para>
	/// <para>
	/// This parameter can be one of the following values. For information about how these values affect the pvPara parameter, see the
	/// heading "For the pvPara parameter" in the Meaning column.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TIME_VALID_OID_GET_CTL ((LPCSTR)1)</term>
	/// <term>
	/// Provides a certificate trust list (CTL) based on a URL obtained from the NextUpdateLocation property or extension of the current
	/// CTL context. For the pvPara parameter: A pointer to a PCCTL_CONTEXT that represents the current certificate trust list.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TIME_VALID_OID_GET_CRL</term>
	/// <term>This value is reserved for future use.</term>
	/// </item>
	/// <item>
	/// <term>TIME_VALID_OID_GET_CRL_FROM_CERT ((LPCSTR)3)</term>
	/// <term>
	/// Provides a CRL based on information obtained from the CRL distribution points extension of the current certificate context. For
	/// the pvPara parameter: A pointer to a PCCERT_CONTEXT that represents the subject certificate.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TIME_VALID_OID_GET_FRESHEST_CRL_FROM_CERT ((LPCSTR)4)</term>
	/// <term>
	/// Provides a delta CRL based on information obtained from the freshest CRL extension of the current certificate context. For the
	/// pvPara parameter: A pointer to a PCCERT_CONTEXT that represents the subject certificate.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TIME_VALID_OID_GET_FRESHEST_CRL_FROM_CRL ((LPCSTR)5)</term>
	/// <term>
	/// Provides a delta CRL based on information obtained from the freshest CRL extension of the current CRL context. For the pvPara
	/// parameter: A pointer to a PCCERT_CRL_CONTEXT_PAIR that represents the subject certificate and its base CRL.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvPara">
	/// A structure determined by the value of pszTimeValidOid. For details, see the description for the pszTimeValidOid parameter.
	/// </param>
	/// <param name="pIssuer">A pointer to a CERT_CONTEXT containing the issuer's certificate.</param>
	/// <param name="pftValidFor">
	/// A pointer to an optional FILETIME structure version of the current system time or a freshness time from the current context.
	/// </param>
	/// <param name="dwFlags">
	/// <para>A value that determines various retrieval factors such as time-out, source, and validity checks.</para>
	/// <para>The following table lists possible values for the dwFlags parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_ACCUMULATIVE_TIMEOUT 0x00000800</term>
	/// <term>Use the cumulative time-out registry setting of the client computer for revocation URL retrievals.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_CACHE_ONLY_RETRIEVAL 0x00000002</term>
	/// <term>Retrieve the encoded bits from the client URL cache only. Do not use the wire to retrieve the URL.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_CHECK_FRESHNESS_TIME_VALIDITY 0x00000400</term>
	/// <term>Check if the ThisUpdate property or extension of the current context is greater than or equal to the ftValidFor parameter.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DONT_CHECK_TIME_VALIDITY 0x00000200</term>
	/// <term>
	/// Do not perform time validity check. Use this to retrieve a more recent base CRL over the wire or to bypass time validity check
	/// during a cache retrieval. When this flag is set, pftValidFor can be NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DONT_VERIFY_SIGNATURE 0x00000100</term>
	/// <term>
	/// Do not perform signature verification. Use this when verification of the retrieved object will be performed outside of this
	/// function or to force a replacement of a retrieved cache entry with a new cache entry for the object.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_KEEP_TIME_VALID 0x00000080</term>
	/// <term>This value is reserved for future use.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_OCSP_ONLY_RETRIEVAL 0x01000000</term>
	/// <term>
	/// Retrieves the time valid object from an OCSP responder service only based on Authority Information Access URLs in the current
	/// context. The CertVerifyRevocation function sets this flag when it is called with the dwFlags parameter set to CERT_VERIFY_REV_SERVER_OCSP_FLAG.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_WIRE_ONLY_RETRIEVAL 0x00000004</term>
	/// <term>Retrieves the encoded bits from the wire only. Does not use the URL cache.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwTimeout">
	/// A value, in milliseconds, that specifies when to terminate an URL retrieval attempt that has not returned a result.
	/// </param>
	/// <param name="ppvObject">
	/// A pointer to an address for the returned object. The return type can be one of the supported types shown in the pszObjectOid
	/// parameter of the CryptRetrieveObjectByUrl function.
	/// </param>
	/// <param name="pCredentials">
	/// A pointer to an optional CRYPT_CREDENTIALS structure used to access the URL. The only type of credentials currently supported
	/// are user name and password credentials.
	/// </param>
	/// <param name="pExtraInfo">
	/// A pointer to an optional CRYPT_GET_TIME_VALID_OBJECT_EXTRA_INFO structure that contains extra information about the cache entry
	/// for an object.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// <para>Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NOT_FOUND</term>
	/// <term>The caller specified TIME_VALID_OID_GET_CRL for the pszTimeValidOid parameter. This OID is not supported.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NOT_IN_REVOCATION_DATABASE</term>
	/// <term>The caller set the CRYPT_OCSP_ONLY_RETRIEVAL flag and the context includes a non-OCSP URL.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The function failed to retrieve a CRL from a certificate context or retrieve a CTL, and it failed to copy any URLs from a cache entry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The function could not allocate memory for an internal array operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_CONNECTED</term>
	/// <term>The caller did not set the CRYPT_CACHE_ONLY_RETRIEVAL flag and is not connected to the Internet.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The Cryptnet dynamic link library implements a time valid object (TVO) cache that is used to support the
	/// <c>CryptGetTimeValidObject</c> function. The cache is used by a process-global TVO agent where each cache entry consists of the
	/// following information.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Origin Identifier</term>
	/// </item>
	/// <item>
	/// <term>Context OID</term>
	/// </item>
	/// <item>
	/// <term>Context</term>
	/// </item>
	/// <item>
	/// <term>Retrieval URL</term>
	/// </item>
	/// <item>
	/// <term>Expire Time</term>
	/// </item>
	/// <item>
	/// <term>Offline URL Time Information</term>
	/// </item>
	/// </list>
	/// <para>The TVO agent supports retrieval of TVO objects on-demand or by auto-update.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgettimevalidobject BOOL CryptGetTimeValidObject(
	// LPCSTR pszTimeValidOid, LPVOID pvPara, PCCERT_CONTEXT pIssuer, LPFILETIME pftValidFor, DWORD dwFlags, DWORD dwTimeout, LPVOID
	// *ppvObject, PCRYPT_CREDENTIALS pCredentials, PCRYPT_GET_TIME_VALID_OBJECT_EXTRA_INFO pExtraInfo );
	[DllImport(Lib.Cryptnet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "dd639b43-1560-4e9f-a778-9e20484ae012")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGetTimeValidObject(SafeOID pszTimeValidOid, [In] IntPtr pvPara, [In] PCCERT_CONTEXT pIssuer,
		in FILETIME pftValidFor, TimeValidObjectFlags dwFlags, uint dwTimeout, out IntPtr ppvObject, in CRYPT_CREDENTIALS pCredentials, ref CRYPT_GET_TIME_VALID_OBJECT_EXTRA_INFO pExtraInfo);

	/// <summary>
	/// The <c>CryptGetTimeValidObject</c> function retrieves a CRL, an OCSP response, or CTL object that is valid within a given
	/// context and time.
	/// </summary>
	/// <param name="pszTimeValidOid">
	/// <para>
	/// A pointer to an object identifier (OID) that identifies the object being requested. If the HIWORD of the pszTimeValidOid
	/// parameter is zero, the LOWORD specifies the integer identifier for the type of the specified structure.
	/// </para>
	/// <para>
	/// This parameter can be one of the following values. For information about how these values affect the pvPara parameter, see the
	/// heading "For the pvPara parameter" in the Meaning column.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TIME_VALID_OID_GET_CTL ((LPCSTR)1)</term>
	/// <term>
	/// Provides a certificate trust list (CTL) based on a URL obtained from the NextUpdateLocation property or extension of the current
	/// CTL context. For the pvPara parameter: A pointer to a PCCTL_CONTEXT that represents the current certificate trust list.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TIME_VALID_OID_GET_CRL</term>
	/// <term>This value is reserved for future use.</term>
	/// </item>
	/// <item>
	/// <term>TIME_VALID_OID_GET_CRL_FROM_CERT ((LPCSTR)3)</term>
	/// <term>
	/// Provides a CRL based on information obtained from the CRL distribution points extension of the current certificate context. For
	/// the pvPara parameter: A pointer to a PCCERT_CONTEXT that represents the subject certificate.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TIME_VALID_OID_GET_FRESHEST_CRL_FROM_CERT ((LPCSTR)4)</term>
	/// <term>
	/// Provides a delta CRL based on information obtained from the freshest CRL extension of the current certificate context. For the
	/// pvPara parameter: A pointer to a PCCERT_CONTEXT that represents the subject certificate.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TIME_VALID_OID_GET_FRESHEST_CRL_FROM_CRL ((LPCSTR)5)</term>
	/// <term>
	/// Provides a delta CRL based on information obtained from the freshest CRL extension of the current CRL context. For the pvPara
	/// parameter: A pointer to a PCCERT_CRL_CONTEXT_PAIR that represents the subject certificate and its base CRL.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvPara">
	/// A structure determined by the value of pszTimeValidOid. For details, see the description for the pszTimeValidOid parameter.
	/// </param>
	/// <param name="pIssuer">A pointer to a CERT_CONTEXT containing the issuer's certificate.</param>
	/// <param name="pftValidFor">
	/// A pointer to an optional FILETIME structure version of the current system time or a freshness time from the current context.
	/// </param>
	/// <param name="dwFlags">
	/// <para>A value that determines various retrieval factors such as time-out, source, and validity checks.</para>
	/// <para>The following table lists possible values for the dwFlags parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_ACCUMULATIVE_TIMEOUT 0x00000800</term>
	/// <term>Use the cumulative time-out registry setting of the client computer for revocation URL retrievals.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_CACHE_ONLY_RETRIEVAL 0x00000002</term>
	/// <term>Retrieve the encoded bits from the client URL cache only. Do not use the wire to retrieve the URL.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_CHECK_FRESHNESS_TIME_VALIDITY 0x00000400</term>
	/// <term>Check if the ThisUpdate property or extension of the current context is greater than or equal to the ftValidFor parameter.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DONT_CHECK_TIME_VALIDITY 0x00000200</term>
	/// <term>
	/// Do not perform time validity check. Use this to retrieve a more recent base CRL over the wire or to bypass time validity check
	/// during a cache retrieval. When this flag is set, pftValidFor can be NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DONT_VERIFY_SIGNATURE 0x00000100</term>
	/// <term>
	/// Do not perform signature verification. Use this when verification of the retrieved object will be performed outside of this
	/// function or to force a replacement of a retrieved cache entry with a new cache entry for the object.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_KEEP_TIME_VALID 0x00000080</term>
	/// <term>This value is reserved for future use.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_OCSP_ONLY_RETRIEVAL 0x01000000</term>
	/// <term>
	/// Retrieves the time valid object from an OCSP responder service only based on Authority Information Access URLs in the current
	/// context. The CertVerifyRevocation function sets this flag when it is called with the dwFlags parameter set to CERT_VERIFY_REV_SERVER_OCSP_FLAG.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_WIRE_ONLY_RETRIEVAL 0x00000004</term>
	/// <term>Retrieves the encoded bits from the wire only. Does not use the URL cache.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwTimeout">
	/// A value, in milliseconds, that specifies when to terminate an URL retrieval attempt that has not returned a result.
	/// </param>
	/// <param name="ppvObject">
	/// A pointer to an address for the returned object. The return type can be one of the supported types shown in the pszObjectOid
	/// parameter of the CryptRetrieveObjectByUrl function.
	/// </param>
	/// <param name="pCredentials">
	/// A pointer to an optional CRYPT_CREDENTIALS structure used to access the URL. The only type of credentials currently supported
	/// are user name and password credentials.
	/// </param>
	/// <param name="pExtraInfo">
	/// A pointer to an optional CRYPT_GET_TIME_VALID_OBJECT_EXTRA_INFO structure that contains extra information about the cache entry
	/// for an object.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// <para>Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NOT_FOUND</term>
	/// <term>The caller specified TIME_VALID_OID_GET_CRL for the pszTimeValidOid parameter. This OID is not supported.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NOT_IN_REVOCATION_DATABASE</term>
	/// <term>The caller set the CRYPT_OCSP_ONLY_RETRIEVAL flag and the context includes a non-OCSP URL.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The function failed to retrieve a CRL from a certificate context or retrieve a CTL, and it failed to copy any URLs from a cache entry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The function could not allocate memory for an internal array operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_CONNECTED</term>
	/// <term>The caller did not set the CRYPT_CACHE_ONLY_RETRIEVAL flag and is not connected to the Internet.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The Cryptnet dynamic link library implements a time valid object (TVO) cache that is used to support the
	/// <c>CryptGetTimeValidObject</c> function. The cache is used by a process-global TVO agent where each cache entry consists of the
	/// following information.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Origin Identifier</term>
	/// </item>
	/// <item>
	/// <term>Context OID</term>
	/// </item>
	/// <item>
	/// <term>Context</term>
	/// </item>
	/// <item>
	/// <term>Retrieval URL</term>
	/// </item>
	/// <item>
	/// <term>Expire Time</term>
	/// </item>
	/// <item>
	/// <term>Offline URL Time Information</term>
	/// </item>
	/// </list>
	/// <para>The TVO agent supports retrieval of TVO objects on-demand or by auto-update.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgettimevalidobject BOOL CryptGetTimeValidObject(
	// LPCSTR pszTimeValidOid, LPVOID pvPara, PCCERT_CONTEXT pIssuer, LPFILETIME pftValidFor, DWORD dwFlags, DWORD dwTimeout, LPVOID
	// *ppvObject, PCRYPT_CREDENTIALS pCredentials, PCRYPT_GET_TIME_VALID_OBJECT_EXTRA_INFO pExtraInfo );
	[DllImport(Lib.Cryptnet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "dd639b43-1560-4e9f-a778-9e20484ae012")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGetTimeValidObject(SafeOID pszTimeValidOid, [In] IntPtr pvPara, [In] PCCERT_CONTEXT pIssuer, [Optional] IntPtr pftValidFor,
		TimeValidObjectFlags dwFlags, uint dwTimeout, out IntPtr ppvObject, [Optional] IntPtr pCredentials, [Optional] IntPtr pExtraInfo);

	/// <summary>
	/// <para>
	/// The <c>CryptRetrieveObjectByUrl</c> function retrieves the public key infrastructure (PKI) object from a location specified by a URL.
	/// </para>
	/// <para>These remote objects are in encoded format and are retrieved in a "context" form.</para>
	/// </summary>
	/// <param name="pszUrl">
	/// <para>The address of a PKI object to be retrieved. The following schemes are supported:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>ldap (Lightweight Directory Access Protocol)</term>
	/// </item>
	/// <item>
	/// <term>http</term>
	/// </item>
	/// <item>
	/// <term>https (certificate revocation list (CRL) or online certificate status protocol (OCSP) retrievals only)</term>
	/// </item>
	/// <item>
	/// <term>file</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszObjectOid">
	/// <para>
	/// The address of a null-terminated ANSI string that identifies the type of object to retrieve. This can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL BLOB</term>
	/// <term>
	/// Retrieve one or more data BLOBs. The encoded bits are returned in an array of BLOBs. ppvObject is the address of a
	/// CRYPT_BLOB_ARRAY structure pointer that receives the BLOB array. When this structure is no longer needed, you must free it by
	/// passing the address of this structure to the CryptMemFree function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_CERTIFICATE certificate</term>
	/// <term>
	/// Retrieve one or more certificates. If a single object is being retrieved, ppvObject is the address of a CERT_CONTEXT structure
	/// pointer that receives the context. When this context is no longer needed, you must free it by passing the CERT_CONTEXT structure
	/// pointer to the CertFreeCertificateContext function. If multiple objects are being retrieved, ppvObject is the address of an
	/// HCERTSTORE variable that receives the handle of a store that contains the certificates. When this store is no longer needed, you
	/// must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_CRL CRL</term>
	/// <term>
	/// Retrieve one or more certificate revocation lists (CRLs). If a single object is being retrieved, ppvObject is the address of a
	/// CRL_CONTEXT structure pointer that receives the context. When this context is no longer needed, you must free it by passing the
	/// CRL_CONTEXT structure pointer to the CertFreeCRLContext function. If multiple objects are being retrieved, ppvObject is the
	/// address of an HCERTSTORE variable that receives the handle of a store that contains the CRLs. When this store is no longer
	/// needed, you must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_CTL CTL</term>
	/// <term>
	/// Retrieve one or more certificate trust lists (CTLs). If a single object is being retrieved, ppvObject is the address of a
	/// CTL_CONTEXT structure pointer that receives the context. When this context is no longer needed, you must free it by passing the
	/// CTL_CONTEXT structure pointer to the CertFreeCTLContext function. If multiple objects are being retrieved, ppvObject is the
	/// address of an HCERTSTORE variable that receives the handle of a store that contains the CTLs. When this store is no longer
	/// needed, you must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_PKCS7 PKCS7</term>
	/// <term>
	/// ppvObject is the address of an HCERTSTORE variable that receives the handle of a store that contains the objects from the
	/// message. When this store is no longer needed, you must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_CAPI2_ANY Function will determine appropriate item</term>
	/// <term>
	/// ppvObject is the address of an HCERTSTORE variable that receives the handle of a store that contains the objects. When this
	/// store is no longer needed, you must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_OCSP_RESP OCSP Response</term>
	/// <term>ppvObject is the address of a pointer to a CRYPT_BLOB_ARRAY structure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwRetrievalFlags">
	/// <para>
	/// Determines whether to use the cached URL or a URL retrieved from the wire URL. The form in which objects are returned is
	/// determined by the value of pszObjectOid.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_AIA_RETRIEVAL</term>
	/// <term>
	/// Validates the content retrieved by a wire URL before writing the URL to the cache. The default provider does not support the
	/// HTTPS protocol for AIA retrievals.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ASYNC_RETRIEVAL</term>
	/// <term>This value is not supported.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_CACHE_ONLY_RETRIEVAL</term>
	/// <term>Retrieves the encoded bits from the URL cache only. Do not use the wire to retrieve the URL.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DONT_CACHE_RESULT</term>
	/// <term>Does not store the retrieved encoded bits to the URL cache. If this flag is not set, the retrieved URL is cached.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_HTTP_POST_RETRIEVAL</term>
	/// <term>
	/// Uses the POST method instead of the default GET method for HTTP retrievals. In a POST URL, additional binary data and header
	/// strings are appended to the base URL in the following format:
	/// BaseURL/OptionalURLEscaped&amp;Base64EncodedAdditionalData?OptionalAdditionalHTTPHeaders The following example shows the
	/// additional binary data delimited by the last slash mark (/) and a Content-Type header delimited by a question mark (?) appended
	/// to a base URL. When this flag is set, the CryptRetrieveObjectByUrl function parses the URL by using the last slash mark (/) and
	/// question mark (?) delimiters. The string, which is delimited by a slash mark (/), contains an unescaped URL (that is, a plain
	/// text URL without escape characters or escape sequences) and Base64 data decoded into binary form before being passed to the
	/// WinHttpSendRequest function as the lpOptional parameter. The string delimited by a question mark (?) is passed to the
	/// WinHttpSendRequest function as the pwszHeaders parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LDAP_AREC_EXCLUSIVE_RETRIEVAL</term>
	/// <term>
	/// Performs A-Record-only DNS lookup on the supplied host string, preventing the generation of false DNS queries when resolving
	/// host names. This flag should be used when passing a host name as opposed to a domain name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LDAP_INSERT_ENTRY_ATTRIBUTE</term>
	/// <term>
	/// Retrieves the entry index and attribute name for each LDAP object. The beginning of each returned BLOB contains the following
	/// ANSI string: "entry index in decimal\0attribute name\0" When this flag is set, pszObjectOid must be NULL so that a BLOB is
	/// returned. This flag only applies to the ldap scheme.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LDAP_SCOPE_BASE_ONLY_RETRIEVAL</term>
	/// <term>Fails if the LDAP search scope is not set to base in the URL. Use with LDAP only.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LDAP_SIGN_RETRIEVAL</term>
	/// <term>
	/// Digitally signs all of the LDAP traffic to and from a server by using the Kerberos authentication protocol. This feature
	/// provides integrity required by some applications.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_NO_AUTH_RETRIEVAL</term>
	/// <term>Inhibits automatic authentication handling.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_NOT_MODIFIED_RETRIEVAL</term>
	/// <term>
	/// Enables a conditional HTTP URL retrieval. When this flag is set, for a conditional retrieval that returns
	/// HTTP_STATUS_NOT_MODIFIED, CryptRetrieveObjectByUrl returns TRUE and ppvObject is set to NULL. If pAuxInfo is not NULL,
	/// dwHttpStatusCode is set to HTTP_STATUS_NOT_MODIFIED. Otherwise, ppvObject is updated for a successful retrieval.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_OFFLINE_CHECK_RETRIEVAL</term>
	/// <term>
	/// Keeps track of offline failures and delays before hitting the wire on subsequent retrievals. This value is for wire retrieval only.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_PROXY_CACHE_RETRIEVAL</term>
	/// <term>
	/// Enables proxy cache retrieval of an object. If a proxy cache was not explicitly bypassed, fProxyCacheRetrieval is set to TRUE in
	/// pAuxInfo. This value only applies to HTTP URL retrievals.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_RETRIEVE_MULTIPLE_OBJECTS</term>
	/// <term>
	/// Retrieves multiple objects if available. All objects must be of a homogeneous object type as determined by the value of
	/// pszObjectOid, unless the object identifier (OID) value is CONTEXT_OID_CAPI2_ANY.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STICKY_CACHE_RETRIEVAL</term>
	/// <term>Tags the URL as exempt from being flushed from the cache. For more information, see STICKY_CACHE_ENTRY in INTERNET_CACHE_ENTRY_INFO.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VERIFY_CONTEXT_SIGNATURE</term>
	/// <term>
	/// Acquires signature verification on the context created. In this case pszObjectOid must be non-NULL and pvVerify points to the
	/// signer certificate context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VERIFY_DATA_HASH</term>
	/// <term>This flag is not implemented. Do not use it.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_WIRE_ONLY_RETRIEVAL</term>
	/// <term>Retrieves the encoded bits from the wire only. Does not use the URL cache.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwTimeout">
	/// Specifies the maximum number of milliseconds to wait for retrieval. If a value of zero is specified, this function does not time
	/// out. This parameter is not used if the URL scheme is file:///.
	/// </param>
	/// <param name="ppvObject">
	/// The address of a pointer to the returned object. The return type can be one of the supported types shown in pszObjectOid.
	/// </param>
	/// <param name="hAsyncRetrieve">This parameter is reserved and must be set to <c>NULL</c>.</param>
	/// <param name="pCredentials">This parameter is not used.</param>
	/// <param name="pvVerify">
	/// A pointer to a verification object. This object is a function of the dwRetrievalFlags parameter. It can be <c>NULL</c> to
	/// indicate that the caller is not interested in getting the certificate context or index of the signer if dwRetrievalFlags is CRYPT_VERIFY_CONTEXT_SIGNATURE.
	/// </param>
	/// <param name="pAuxInfo">
	/// An optional pointer to a CRYPT_RETRIEVE_AUX_INFO structure. If not <c>NULL</c> and if the <c>cbSize</c> member of the structure
	/// is set, this parameter returns the time of the last successful wire retrieval.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>).</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The remote object retrieval manager exposes two provider models. One is the Scheme Provider model that allows for installable
	/// protocol providers as defined by the URL scheme, that is, ldap, http, ftp, or file. The scheme provider entry point is the same
	/// as the <c>CryptRetrieveObjectByUrl</c> function; however, the *ppvObject returned is always a counted array of encoded bits (one
	/// per object retrieved).
	/// </para>
	/// <para>
	/// The second provider model is the Context Provider model that allows for installable creators of the context handles (objects)
	/// based on the retrieved encoded bits. These are dispatched based on the object identifier (OID) specified in the call to <c>CryptRetrieveObjectByUrl</c>.
	/// </para>
	/// <para>
	/// Individual PKI objects such as certificates, trusts lists, revocation lists, PKCS #7 messages, and multiple homogenous objects
	/// can be retrieved. Starting with Windows Vista with Service Pack 1 (SP1) and Windows Server 2008, security of "http:" and "ldap:"
	/// retrievals have been hardened. For more information, see http://support.microsoft.com/kb/946401.
	/// </para>
	/// <para>This function supports "http:" and "ldap:" URL schemes as well as newly defined schemes.</para>
	/// <para>
	/// <c>Windows XP:</c>"ftp:" is not supported for network retrieval. For a summary of changes to the CryptoAPI certificate chain
	/// validation logic in Q835732 on Windows XP, see http://support.microsoft.com/kb/887195.
	/// </para>
	/// <para><c>Note</c> By default, "file:" is not supported for network retrieval.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptretrieveobjectbyurla BOOL CryptRetrieveObjectByUrlA(
	// LPCSTR pszUrl, LPCSTR pszObjectOid, DWORD dwRetrievalFlags, DWORD dwTimeout, LPVOID *ppvObject, HCRYPTASYNC hAsyncRetrieve,
	// PCRYPT_CREDENTIALS pCredentials, LPVOID pvVerify, PCRYPT_RETRIEVE_AUX_INFO pAuxInfo );
	[DllImport(Lib.Cryptnet, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "2e205f97-be9b-4358-ba22-d475b6a250b7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptRetrieveObjectByUrl([MarshalAs(UnmanagedType.LPTStr)] string pszUrl, [MarshalAs(UnmanagedType.LPTStr)] string pszObjectOid, CryptRetrievalFlags dwRetrievalFlags,
		uint dwTimeout, ref IntPtr ppvObject, [Optional] IntPtr hAsyncRetrieve, [Optional] IntPtr pCredentials, [Optional] IntPtr pvVerify, ref CRYPT_RETRIEVE_AUX_INFO pAuxInfo);

	/// <summary>
	/// <para>
	/// The <c>CryptRetrieveObjectByUrl</c> function retrieves the public key infrastructure (PKI) object from a location specified by a URL.
	/// </para>
	/// <para>These remote objects are in encoded format and are retrieved in a "context" form.</para>
	/// </summary>
	/// <param name="pszUrl">
	/// <para>The address of a PKI object to be retrieved. The following schemes are supported:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>ldap (Lightweight Directory Access Protocol)</term>
	/// </item>
	/// <item>
	/// <term>http</term>
	/// </item>
	/// <item>
	/// <term>https (certificate revocation list (CRL) or online certificate status protocol (OCSP) retrievals only)</term>
	/// </item>
	/// <item>
	/// <term>file</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszObjectOid">
	/// <para>
	/// The address of a null-terminated ANSI string that identifies the type of object to retrieve. This can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL BLOB</term>
	/// <term>
	/// Retrieve one or more data BLOBs. The encoded bits are returned in an array of BLOBs. ppvObject is the address of a
	/// CRYPT_BLOB_ARRAY structure pointer that receives the BLOB array. When this structure is no longer needed, you must free it by
	/// passing the address of this structure to the CryptMemFree function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_CERTIFICATE certificate</term>
	/// <term>
	/// Retrieve one or more certificates. If a single object is being retrieved, ppvObject is the address of a CERT_CONTEXT structure
	/// pointer that receives the context. When this context is no longer needed, you must free it by passing the CERT_CONTEXT structure
	/// pointer to the CertFreeCertificateContext function. If multiple objects are being retrieved, ppvObject is the address of an
	/// HCERTSTORE variable that receives the handle of a store that contains the certificates. When this store is no longer needed, you
	/// must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_CRL CRL</term>
	/// <term>
	/// Retrieve one or more certificate revocation lists (CRLs). If a single object is being retrieved, ppvObject is the address of a
	/// CRL_CONTEXT structure pointer that receives the context. When this context is no longer needed, you must free it by passing the
	/// CRL_CONTEXT structure pointer to the CertFreeCRLContext function. If multiple objects are being retrieved, ppvObject is the
	/// address of an HCERTSTORE variable that receives the handle of a store that contains the CRLs. When this store is no longer
	/// needed, you must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_CTL CTL</term>
	/// <term>
	/// Retrieve one or more certificate trust lists (CTLs). If a single object is being retrieved, ppvObject is the address of a
	/// CTL_CONTEXT structure pointer that receives the context. When this context is no longer needed, you must free it by passing the
	/// CTL_CONTEXT structure pointer to the CertFreeCTLContext function. If multiple objects are being retrieved, ppvObject is the
	/// address of an HCERTSTORE variable that receives the handle of a store that contains the CTLs. When this store is no longer
	/// needed, you must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_PKCS7 PKCS7</term>
	/// <term>
	/// ppvObject is the address of an HCERTSTORE variable that receives the handle of a store that contains the objects from the
	/// message. When this store is no longer needed, you must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_CAPI2_ANY Function will determine appropriate item</term>
	/// <term>
	/// ppvObject is the address of an HCERTSTORE variable that receives the handle of a store that contains the objects. When this
	/// store is no longer needed, you must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_OCSP_RESP OCSP Response</term>
	/// <term>ppvObject is the address of a pointer to a CRYPT_BLOB_ARRAY structure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwRetrievalFlags">
	/// <para>
	/// Determines whether to use the cached URL or a URL retrieved from the wire URL. The form in which objects are returned is
	/// determined by the value of pszObjectOid.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_AIA_RETRIEVAL</term>
	/// <term>
	/// Validates the content retrieved by a wire URL before writing the URL to the cache. The default provider does not support the
	/// HTTPS protocol for AIA retrievals.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ASYNC_RETRIEVAL</term>
	/// <term>This value is not supported.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_CACHE_ONLY_RETRIEVAL</term>
	/// <term>Retrieves the encoded bits from the URL cache only. Do not use the wire to retrieve the URL.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DONT_CACHE_RESULT</term>
	/// <term>Does not store the retrieved encoded bits to the URL cache. If this flag is not set, the retrieved URL is cached.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_HTTP_POST_RETRIEVAL</term>
	/// <term>
	/// Uses the POST method instead of the default GET method for HTTP retrievals. In a POST URL, additional binary data and header
	/// strings are appended to the base URL in the following format:
	/// BaseURL/OptionalURLEscaped&amp;Base64EncodedAdditionalData?OptionalAdditionalHTTPHeaders The following example shows the
	/// additional binary data delimited by the last slash mark (/) and a Content-Type header delimited by a question mark (?) appended
	/// to a base URL. When this flag is set, the CryptRetrieveObjectByUrl function parses the URL by using the last slash mark (/) and
	/// question mark (?) delimiters. The string, which is delimited by a slash mark (/), contains an unescaped URL (that is, a plain
	/// text URL without escape characters or escape sequences) and Base64 data decoded into binary form before being passed to the
	/// WinHttpSendRequest function as the lpOptional parameter. The string delimited by a question mark (?) is passed to the
	/// WinHttpSendRequest function as the pwszHeaders parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LDAP_AREC_EXCLUSIVE_RETRIEVAL</term>
	/// <term>
	/// Performs A-Record-only DNS lookup on the supplied host string, preventing the generation of false DNS queries when resolving
	/// host names. This flag should be used when passing a host name as opposed to a domain name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LDAP_INSERT_ENTRY_ATTRIBUTE</term>
	/// <term>
	/// Retrieves the entry index and attribute name for each LDAP object. The beginning of each returned BLOB contains the following
	/// ANSI string: "entry index in decimal\0attribute name\0" When this flag is set, pszObjectOid must be NULL so that a BLOB is
	/// returned. This flag only applies to the ldap scheme.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LDAP_SCOPE_BASE_ONLY_RETRIEVAL</term>
	/// <term>Fails if the LDAP search scope is not set to base in the URL. Use with LDAP only.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LDAP_SIGN_RETRIEVAL</term>
	/// <term>
	/// Digitally signs all of the LDAP traffic to and from a server by using the Kerberos authentication protocol. This feature
	/// provides integrity required by some applications.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_NO_AUTH_RETRIEVAL</term>
	/// <term>Inhibits automatic authentication handling.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_NOT_MODIFIED_RETRIEVAL</term>
	/// <term>
	/// Enables a conditional HTTP URL retrieval. When this flag is set, for a conditional retrieval that returns
	/// HTTP_STATUS_NOT_MODIFIED, CryptRetrieveObjectByUrl returns TRUE and ppvObject is set to NULL. If pAuxInfo is not NULL,
	/// dwHttpStatusCode is set to HTTP_STATUS_NOT_MODIFIED. Otherwise, ppvObject is updated for a successful retrieval.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_OFFLINE_CHECK_RETRIEVAL</term>
	/// <term>
	/// Keeps track of offline failures and delays before hitting the wire on subsequent retrievals. This value is for wire retrieval only.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_PROXY_CACHE_RETRIEVAL</term>
	/// <term>
	/// Enables proxy cache retrieval of an object. If a proxy cache was not explicitly bypassed, fProxyCacheRetrieval is set to TRUE in
	/// pAuxInfo. This value only applies to HTTP URL retrievals.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_RETRIEVE_MULTIPLE_OBJECTS</term>
	/// <term>
	/// Retrieves multiple objects if available. All objects must be of a homogeneous object type as determined by the value of
	/// pszObjectOid, unless the object identifier (OID) value is CONTEXT_OID_CAPI2_ANY.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STICKY_CACHE_RETRIEVAL</term>
	/// <term>Tags the URL as exempt from being flushed from the cache. For more information, see STICKY_CACHE_ENTRY in INTERNET_CACHE_ENTRY_INFO.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VERIFY_CONTEXT_SIGNATURE</term>
	/// <term>
	/// Acquires signature verification on the context created. In this case pszObjectOid must be non-NULL and pvVerify points to the
	/// signer certificate context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VERIFY_DATA_HASH</term>
	/// <term>This flag is not implemented. Do not use it.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_WIRE_ONLY_RETRIEVAL</term>
	/// <term>Retrieves the encoded bits from the wire only. Does not use the URL cache.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwTimeout">
	/// Specifies the maximum number of milliseconds to wait for retrieval. If a value of zero is specified, this function does not time
	/// out. This parameter is not used if the URL scheme is file:///.
	/// </param>
	/// <param name="ppvObject">
	/// The address of a pointer to the returned object. The return type can be one of the supported types shown in pszObjectOid.
	/// </param>
	/// <param name="hAsyncRetrieve">This parameter is reserved and must be set to <c>NULL</c>.</param>
	/// <param name="pCredentials">This parameter is not used.</param>
	/// <param name="pvVerify">
	/// A pointer to a verification object. This object is a function of the dwRetrievalFlags parameter. It can be <c>NULL</c> to
	/// indicate that the caller is not interested in getting the certificate context or index of the signer if dwRetrievalFlags is CRYPT_VERIFY_CONTEXT_SIGNATURE.
	/// </param>
	/// <param name="pAuxInfo">
	/// An optional pointer to a CRYPT_RETRIEVE_AUX_INFO structure. If not <c>NULL</c> and if the <c>cbSize</c> member of the structure
	/// is set, this parameter returns the time of the last successful wire retrieval.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>).</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The remote object retrieval manager exposes two provider models. One is the Scheme Provider model that allows for installable
	/// protocol providers as defined by the URL scheme, that is, ldap, http, ftp, or file. The scheme provider entry point is the same
	/// as the <c>CryptRetrieveObjectByUrl</c> function; however, the *ppvObject returned is always a counted array of encoded bits (one
	/// per object retrieved).
	/// </para>
	/// <para>
	/// The second provider model is the Context Provider model that allows for installable creators of the context handles (objects)
	/// based on the retrieved encoded bits. These are dispatched based on the object identifier (OID) specified in the call to <c>CryptRetrieveObjectByUrl</c>.
	/// </para>
	/// <para>
	/// Individual PKI objects such as certificates, trusts lists, revocation lists, PKCS #7 messages, and multiple homogenous objects
	/// can be retrieved. Starting with Windows Vista with Service Pack 1 (SP1) and Windows Server 2008, security of "http:" and "ldap:"
	/// retrievals have been hardened. For more information, see http://support.microsoft.com/kb/946401.
	/// </para>
	/// <para>This function supports "http:" and "ldap:" URL schemes as well as newly defined schemes.</para>
	/// <para>
	/// <c>Windows XP:</c>"ftp:" is not supported for network retrieval. For a summary of changes to the CryptoAPI certificate chain
	/// validation logic in Q835732 on Windows XP, see http://support.microsoft.com/kb/887195.
	/// </para>
	/// <para><c>Note</c> By default, "file:" is not supported for network retrieval.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptretrieveobjectbyurla BOOL CryptRetrieveObjectByUrlA(
	// LPCSTR pszUrl, LPCSTR pszObjectOid, DWORD dwRetrievalFlags, DWORD dwTimeout, LPVOID *ppvObject, HCRYPTASYNC hAsyncRetrieve,
	// PCRYPT_CREDENTIALS pCredentials, LPVOID pvVerify, PCRYPT_RETRIEVE_AUX_INFO pAuxInfo );
	[DllImport(Lib.Cryptnet, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "2e205f97-be9b-4358-ba22-d475b6a250b7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptRetrieveObjectByUrl(SafeOID pszUrl, [Optional] SafeOID pszObjectOid, uint dwRetrievalFlags, uint dwTimeout,
		out IntPtr ppvObject, [Optional] IntPtr hAsyncRetrieve, in CRYPT_CREDENTIALS pCredentials, [Optional] IntPtr pvVerify, ref CRYPT_RETRIEVE_AUX_INFO pAuxInfo);

	/// <summary>
	/// <para>
	/// The <c>CryptRetrieveObjectByUrl</c> function retrieves the public key infrastructure (PKI) object from a location specified by a URL.
	/// </para>
	/// <para>These remote objects are in encoded format and are retrieved in a "context" form.</para>
	/// </summary>
	/// <param name="pszUrl">
	/// <para>The address of a PKI object to be retrieved. The following schemes are supported:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>ldap (Lightweight Directory Access Protocol)</term>
	/// </item>
	/// <item>
	/// <term>http</term>
	/// </item>
	/// <item>
	/// <term>https (certificate revocation list (CRL) or online certificate status protocol (OCSP) retrievals only)</term>
	/// </item>
	/// <item>
	/// <term>file</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszObjectOid">
	/// <para>
	/// The address of a null-terminated ANSI string that identifies the type of object to retrieve. This can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL BLOB</term>
	/// <term>
	/// Retrieve one or more data BLOBs. The encoded bits are returned in an array of BLOBs. ppvObject is the address of a
	/// CRYPT_BLOB_ARRAY structure pointer that receives the BLOB array. When this structure is no longer needed, you must free it by
	/// passing the address of this structure to the CryptMemFree function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_CERTIFICATE certificate</term>
	/// <term>
	/// Retrieve one or more certificates. If a single object is being retrieved, ppvObject is the address of a CERT_CONTEXT structure
	/// pointer that receives the context. When this context is no longer needed, you must free it by passing the CERT_CONTEXT structure
	/// pointer to the CertFreeCertificateContext function. If multiple objects are being retrieved, ppvObject is the address of an
	/// HCERTSTORE variable that receives the handle of a store that contains the certificates. When this store is no longer needed, you
	/// must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_CRL CRL</term>
	/// <term>
	/// Retrieve one or more certificate revocation lists (CRLs). If a single object is being retrieved, ppvObject is the address of a
	/// CRL_CONTEXT structure pointer that receives the context. When this context is no longer needed, you must free it by passing the
	/// CRL_CONTEXT structure pointer to the CertFreeCRLContext function. If multiple objects are being retrieved, ppvObject is the
	/// address of an HCERTSTORE variable that receives the handle of a store that contains the CRLs. When this store is no longer
	/// needed, you must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_CTL CTL</term>
	/// <term>
	/// Retrieve one or more certificate trust lists (CTLs). If a single object is being retrieved, ppvObject is the address of a
	/// CTL_CONTEXT structure pointer that receives the context. When this context is no longer needed, you must free it by passing the
	/// CTL_CONTEXT structure pointer to the CertFreeCTLContext function. If multiple objects are being retrieved, ppvObject is the
	/// address of an HCERTSTORE variable that receives the handle of a store that contains the CTLs. When this store is no longer
	/// needed, you must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_PKCS7 PKCS7</term>
	/// <term>
	/// ppvObject is the address of an HCERTSTORE variable that receives the handle of a store that contains the objects from the
	/// message. When this store is no longer needed, you must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_CAPI2_ANY Function will determine appropriate item</term>
	/// <term>
	/// ppvObject is the address of an HCERTSTORE variable that receives the handle of a store that contains the objects. When this
	/// store is no longer needed, you must close it by passing this handle to the CertCloseStore function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONTEXT_OID_OCSP_RESP OCSP Response</term>
	/// <term>ppvObject is the address of a pointer to a CRYPT_BLOB_ARRAY structure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwRetrievalFlags">
	/// <para>
	/// Determines whether to use the cached URL or a URL retrieved from the wire URL. The form in which objects are returned is
	/// determined by the value of pszObjectOid.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_AIA_RETRIEVAL</term>
	/// <term>
	/// Validates the content retrieved by a wire URL before writing the URL to the cache. The default provider does not support the
	/// HTTPS protocol for AIA retrievals.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ASYNC_RETRIEVAL</term>
	/// <term>This value is not supported.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_CACHE_ONLY_RETRIEVAL</term>
	/// <term>Retrieves the encoded bits from the URL cache only. Do not use the wire to retrieve the URL.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DONT_CACHE_RESULT</term>
	/// <term>Does not store the retrieved encoded bits to the URL cache. If this flag is not set, the retrieved URL is cached.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_HTTP_POST_RETRIEVAL</term>
	/// <term>
	/// Uses the POST method instead of the default GET method for HTTP retrievals. In a POST URL, additional binary data and header
	/// strings are appended to the base URL in the following format:
	/// BaseURL/OptionalURLEscaped&amp;Base64EncodedAdditionalData?OptionalAdditionalHTTPHeaders The following example shows the
	/// additional binary data delimited by the last slash mark (/) and a Content-Type header delimited by a question mark (?) appended
	/// to a base URL. When this flag is set, the CryptRetrieveObjectByUrl function parses the URL by using the last slash mark (/) and
	/// question mark (?) delimiters. The string, which is delimited by a slash mark (/), contains an unescaped URL (that is, a plain
	/// text URL without escape characters or escape sequences) and Base64 data decoded into binary form before being passed to the
	/// WinHttpSendRequest function as the lpOptional parameter. The string delimited by a question mark (?) is passed to the
	/// WinHttpSendRequest function as the pwszHeaders parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LDAP_AREC_EXCLUSIVE_RETRIEVAL</term>
	/// <term>
	/// Performs A-Record-only DNS lookup on the supplied host string, preventing the generation of false DNS queries when resolving
	/// host names. This flag should be used when passing a host name as opposed to a domain name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LDAP_INSERT_ENTRY_ATTRIBUTE</term>
	/// <term>
	/// Retrieves the entry index and attribute name for each LDAP object. The beginning of each returned BLOB contains the following
	/// ANSI string: "entry index in decimal\0attribute name\0" When this flag is set, pszObjectOid must be NULL so that a BLOB is
	/// returned. This flag only applies to the ldap scheme.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LDAP_SCOPE_BASE_ONLY_RETRIEVAL</term>
	/// <term>Fails if the LDAP search scope is not set to base in the URL. Use with LDAP only.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LDAP_SIGN_RETRIEVAL</term>
	/// <term>
	/// Digitally signs all of the LDAP traffic to and from a server by using the Kerberos authentication protocol. This feature
	/// provides integrity required by some applications.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_NO_AUTH_RETRIEVAL</term>
	/// <term>Inhibits automatic authentication handling.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_NOT_MODIFIED_RETRIEVAL</term>
	/// <term>
	/// Enables a conditional HTTP URL retrieval. When this flag is set, for a conditional retrieval that returns
	/// HTTP_STATUS_NOT_MODIFIED, CryptRetrieveObjectByUrl returns TRUE and ppvObject is set to NULL. If pAuxInfo is not NULL,
	/// dwHttpStatusCode is set to HTTP_STATUS_NOT_MODIFIED. Otherwise, ppvObject is updated for a successful retrieval.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_OFFLINE_CHECK_RETRIEVAL</term>
	/// <term>
	/// Keeps track of offline failures and delays before hitting the wire on subsequent retrievals. This value is for wire retrieval only.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_PROXY_CACHE_RETRIEVAL</term>
	/// <term>
	/// Enables proxy cache retrieval of an object. If a proxy cache was not explicitly bypassed, fProxyCacheRetrieval is set to TRUE in
	/// pAuxInfo. This value only applies to HTTP URL retrievals.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_RETRIEVE_MULTIPLE_OBJECTS</term>
	/// <term>
	/// Retrieves multiple objects if available. All objects must be of a homogeneous object type as determined by the value of
	/// pszObjectOid, unless the object identifier (OID) value is CONTEXT_OID_CAPI2_ANY.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STICKY_CACHE_RETRIEVAL</term>
	/// <term>Tags the URL as exempt from being flushed from the cache. For more information, see STICKY_CACHE_ENTRY in INTERNET_CACHE_ENTRY_INFO.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VERIFY_CONTEXT_SIGNATURE</term>
	/// <term>
	/// Acquires signature verification on the context created. In this case pszObjectOid must be non-NULL and pvVerify points to the
	/// signer certificate context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VERIFY_DATA_HASH</term>
	/// <term>This flag is not implemented. Do not use it.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_WIRE_ONLY_RETRIEVAL</term>
	/// <term>Retrieves the encoded bits from the wire only. Does not use the URL cache.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwTimeout">
	/// Specifies the maximum number of milliseconds to wait for retrieval. If a value of zero is specified, this function does not time
	/// out. This parameter is not used if the URL scheme is file:///.
	/// </param>
	/// <param name="ppvObject">
	/// The address of a pointer to the returned object. The return type can be one of the supported types shown in pszObjectOid.
	/// </param>
	/// <param name="hAsyncRetrieve">This parameter is reserved and must be set to <c>NULL</c>.</param>
	/// <param name="pCredentials">This parameter is not used.</param>
	/// <param name="pvVerify">
	/// A pointer to a verification object. This object is a function of the dwRetrievalFlags parameter. It can be <c>NULL</c> to
	/// indicate that the caller is not interested in getting the certificate context or index of the signer if dwRetrievalFlags is CRYPT_VERIFY_CONTEXT_SIGNATURE.
	/// </param>
	/// <param name="pAuxInfo">
	/// An optional pointer to a CRYPT_RETRIEVE_AUX_INFO structure. If not <c>NULL</c> and if the <c>cbSize</c> member of the structure
	/// is set, this parameter returns the time of the last successful wire retrieval.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>).</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The remote object retrieval manager exposes two provider models. One is the Scheme Provider model that allows for installable
	/// protocol providers as defined by the URL scheme, that is, ldap, http, ftp, or file. The scheme provider entry point is the same
	/// as the <c>CryptRetrieveObjectByUrl</c> function; however, the *ppvObject returned is always a counted array of encoded bits (one
	/// per object retrieved).
	/// </para>
	/// <para>
	/// The second provider model is the Context Provider model that allows for installable creators of the context handles (objects)
	/// based on the retrieved encoded bits. These are dispatched based on the object identifier (OID) specified in the call to <c>CryptRetrieveObjectByUrl</c>.
	/// </para>
	/// <para>
	/// Individual PKI objects such as certificates, trusts lists, revocation lists, PKCS #7 messages, and multiple homogenous objects
	/// can be retrieved. Starting with Windows Vista with Service Pack 1 (SP1) and Windows Server 2008, security of "http:" and "ldap:"
	/// retrievals have been hardened. For more information, see http://support.microsoft.com/kb/946401.
	/// </para>
	/// <para>This function supports "http:" and "ldap:" URL schemes as well as newly defined schemes.</para>
	/// <para>
	/// <c>Windows XP:</c>"ftp:" is not supported for network retrieval. For a summary of changes to the CryptoAPI certificate chain
	/// validation logic in Q835732 on Windows XP, see http://support.microsoft.com/kb/887195.
	/// </para>
	/// <para><c>Note</c> By default, "file:" is not supported for network retrieval.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptretrieveobjectbyurla BOOL CryptRetrieveObjectByUrlA(
	// LPCSTR pszUrl, LPCSTR pszObjectOid, DWORD dwRetrievalFlags, DWORD dwTimeout, LPVOID *ppvObject, HCRYPTASYNC hAsyncRetrieve,
	// PCRYPT_CREDENTIALS pCredentials, LPVOID pvVerify, PCRYPT_RETRIEVE_AUX_INFO pAuxInfo );
	[DllImport(Lib.Cryptnet, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "2e205f97-be9b-4358-ba22-d475b6a250b7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptRetrieveObjectByUrl(SafeOID pszUrl, [Optional] SafeOID pszObjectOid, uint dwRetrievalFlags, uint dwTimeout,
		[Optional] IntPtr ppvObject, [Optional] IntPtr hAsyncRetrieve, [Optional] IntPtr pCredentials, [Optional] IntPtr pvVerify, [Optional] IntPtr pAuxInfo);

	/// <summary>
	/// The <c>CERT_REVOCATION_CHAIN_PARA</c> structure contains parameters used for building a chain for an independent online
	/// certificate status protocol (OCSP) response signer certificate. The CERT_REVOCATION_PARA and
	/// CRYPT_GET_TIME_VALID_OBJECT_EXTRA_INFO structure definitions include optional pointers to this structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_revocation_chain_para typedef struct
	// _CERT_REVOCATION_CHAIN_PARA { DWORD cbSize; HCERTCHAINENGINE hChainEngine; HCERTSTORE hAdditionalStore; DWORD dwChainFlags; DWORD
	// dwUrlRetrievalTimeout; LPFILETIME pftCurrentTime; LPFILETIME pftCacheResync; DWORD cbMaxUrlRetrievalByteCount; }
	// CERT_REVOCATION_CHAIN_PARA, *PCERT_REVOCATION_CHAIN_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "9cdcc81a-aef1-4a1e-94f8-7aa461225dae")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_REVOCATION_CHAIN_PARA
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>A handle to the chain engine used by the caller.</summary>
		public HCERTCHAINENGINE hChainEngine;

		/// <summary>A handle to a store that contains the certificates used to build the original chain. The handle can be <c>NULL</c>.</summary>
		public HCERTSTORE hAdditionalStore;

		/// <summary>
		/// <para>A value for the dwFlags parameter passed to the CertGetCertificateChain function.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_CHAIN_REVOCATION_CHECK_OCSP_CERT 0x04000000</term>
		/// <term>
		/// This flag will be set by the CertVerifyRevocation provider when it calls CertGetCertificateChain with an independent OCSP
		/// signer certificate. When set, CertGetCertificateChain will call CertVerifyRevocation without setting the pointer to the
		/// above CERT_REVOCATION_CHAIN_PARA data structure; this helps to prevent circular revocation checking.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwChainFlags;

		/// <summary>
		/// A value that contains the time-out limit, in milliseconds. If zero, the revocation handler's default time-out is used.
		/// </summary>
		public uint dwUrlRetrievalTimeout;

		/// <summary>
		/// A pointer to a FILETIME structure used in the freshness time check. If this pointer is <c>NULL</c>, the revocation handler
		/// uses the current time.
		/// </summary>
		public IntPtr pftCurrentTime;

		/// <summary>
		/// A pointer to a FILETIME structure that governs the use of cached information. Any information cached before this time is
		/// considered invalid and new information is retrieved. When set, this value overrides the registry configuration CacheResync time.
		/// </summary>
		public IntPtr pftCacheResync;

		/// <summary>
		/// <para>
		/// A <c>DWORD</c> value that specifies the maximum number of bytes to download from the URL object. A value of 0 specifies no limit.
		/// </para>
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This member is not supported.</para>
		/// </summary>
		public uint cbMaxUrlRetrievalByteCount;
	}

	/// <summary>
	/// The <c>CRYPT_CREDENTIALS</c> structure contains information about credentials that can be passed as optional input to a remote
	/// object retrieval function such as CryptRetrieveObjectByUrl or CryptGetTimeValidObject.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_credentials typedef struct _CRYPT_CREDENTIALS {
	// DWORD cbSize; LPCSTR pszCredentialsOid; LPVOID pvCredentials; } CRYPT_CREDENTIALS, *PCRYPT_CREDENTIALS;
	[PInvokeData("wincrypt.h", MSDNShortId = "d28b2f52-3258-44ad-a3ab-0743d3afcd62")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_CREDENTIALS
	{
		/// <summary>The size in bytes of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>
		/// A pointer to a null-terminated string that contains the type of credential object represented by the <c>pvCredentials</c> member.
		/// </para>
		/// <para>This member can contain the following possible value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CREDENTIAL_OID_PASSWORD_CREDENTIALS</term>
		/// <term>
		/// The pvCredentials member contains a CRYPT_PASSWORD_CREDENTIALS structure that represents a user name and password combination.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public IntPtr pszCredentialsOid;

		/// <summary>A pointer to a structure as defined by the <c>pszCredentialsOid</c> member.</summary>
		public IntPtr pvCredentials;
	}

	/// <summary>
	/// The <c>CRYPT_GET_TIME_VALID_OBJECT_EXTRA_INFO</c> structure contains optional extra information that can be passed to the
	/// CryptGetTimeValidObject function in the pExtraInfo parameter.
	/// </summary>
	/// <remarks>
	/// All members of the <c>CRYPT_GET_TIME_VALID_OBJECT_EXTRA_INFO</c> structure that do not have a value must be set to zero.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_get_time_valid_object_extra_info typedef struct
	// _CRYPT_GET_TIME_VALID_OBJECT_EXTRA_INFO { DWORD cbSize; int iDeltaCrlIndicator; LPFILETIME pftCacheResync; LPFILETIME
	// pLastSyncTime; LPFILETIME pMaxAgeTime; PCERT_REVOCATION_CHAIN_PARA pChainPara; PCRYPT_INTEGER_BLOB pDeltaCrlIndicator; }
	// CRYPT_GET_TIME_VALID_OBJECT_EXTRA_INFO, *PCRYPT_GET_TIME_VALID_OBJECT_EXTRA_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "3de595f9-c922-4c8f-8328-819e91a2997c")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_GET_TIME_VALID_OBJECT_EXTRA_INFO
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>
		/// A value used to compare to the base certificate revocation list (CRL) number. If the base CRL number is less than this
		/// value, the caller should attempt to retrieve a newer base CRL.
		/// </para>
		/// <para>
		/// If the <c>pDeltaCrlIndicator</c> member is non- <c>NULL</c> the value of this member must be 0x7fffffff. <c>Windows Server
		/// 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> Because the <c>pDeltaCrlIndicator</c> member does not exist,
		/// the <c>iDeltaCrlIndicator</c> value requirement does not apply.
		/// </para>
		/// </summary>
		public int iDeltaCrlIndicator;

		/// <summary>
		/// A pointer to a FILETIME structure that governs the use of cached information. Any information cached before this time is
		/// considered invalid and new information is retrieved.
		/// </summary>
		public IntPtr pftCacheResync;

		/// <summary>
		/// A pointer to a FILETIME structure that contains the time of the last synchronization of the data retrieved for the object.
		/// </summary>
		public IntPtr pLastSyncTime;

		/// <summary>
		/// A pointer to a FILETIME structure that specifies an expiration time of the data retrieved based on the <c>dwMaxAge</c>
		/// member of the CRYPTNET_URL_CACHE_RESPONSE_INFO structure.
		/// </summary>
		public IntPtr pMaxAgeTime;

		/// <summary>
		/// A pointer to a <see cref="CERT_REVOCATION_CHAIN_PARA"/> structure that contains the CertGetCertificateChain function
		/// parameters used by the caller. The data in this member enables independent online certificate status protocol (OCSP) signer
		/// certificate chain verification.
		/// </summary>
		public IntPtr pChainPara;

		/// <summary>
		/// <para>
		/// A pointer to a CRYPT_INTEGER_BLOB structure that contains a CRL with a length of more than 4 bytes. If this member is non-
		/// <c>NULL</c> and the <c>iDeltaCrlIndicator</c> member is equal to <c>MAXLONG</c>, then if the base CRL number is less than
		/// this value, the caller should attempt to retrieve a newer base CRL.
		/// </para>
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This member is not supported.</para>
		/// </summary>
		public IntPtr pDeltaCrlIndicator;
	}

	/// <summary>
	/// The <c>CRYPT_RETRIEVE_AUX_INFO</c> structure contains optional information to pass to the CryptRetrieveObjectByUrl function. All
	/// unused members of this structure must contain zero.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_retrieve_aux_info typedef struct
	// _CRYPT_RETRIEVE_AUX_INFO { DWORD cbSize; FILETIME *pLastSyncTime; DWORD dwMaxUrlRetrievalByteCount;
	// PCRYPTNET_URL_CACHE_PRE_FETCH_INFO pPreFetchInfo; PCRYPTNET_URL_CACHE_FLUSH_INFO pFlushInfo; PCRYPTNET_URL_CACHE_RESPONSE_INFO
	// *ppResponseInfo; LPWSTR pwszCacheFileNamePrefix; LPFILETIME pftCacheResync; BOOL fProxyCacheRetrieval; DWORD dwHttpStatusCode;
	// LPWSTR *ppwszErrorResponseHeaders; PCRYPT_DATA_BLOB *ppErrorContentBlob; } CRYPT_RETRIEVE_AUX_INFO, *PCRYPT_RETRIEVE_AUX_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "33ea51e7-c3e3-4cf8-ade0-099cb8b2e651")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_RETRIEVE_AUX_INFO
	{
		/// <summary>The size, in bytes, of the structure.</summary>
		public uint cbSize;

		/// <summary>A FILETIME structure that contains the time of the last synchronization of the data retrieved.</summary>
		public IntPtr pLastSyncTime;

		/// <summary>A value that specifies a limit to the number of byes retrieved. A value of zero or less specifies no limit.</summary>
		public uint dwMaxUrlRetrievalByteCount;

		/// <summary>
		/// A pointer to a CRYPTNET_URL_CACHE_PRE_FETCH_INFO structure. To get prefetch information, set its <c>cbSize</c> upon input.
		/// For no prefetch information, except for <c>cbSize</c>, the data structure contains zero upon return.
		/// </summary>
		public IntPtr pPreFetchInfo;

		/// <summary>
		/// A pointer to a CRYPTNET_URL_CACHE_FLUSH_INFO structure. To get flush information, set its <c>cbSize</c> upon input. For no
		/// flush information, except for <c>cbSize</c>, the data structure contains zero upon return.
		/// </summary>
		public IntPtr pFlushInfo;

		/// <summary>
		/// A pointer to a PCRYPTNET_URL_CACHE_RESPONSE_INFO structure. To get response information, set the pointer to the address of a
		/// <c>CRYPTNET_URL_CACHE_RESPONSE_INFO</c> pointer updated with the allocated structure. For no response information,
		/// <c>ppResponseInfo</c> is set to <c>NULL</c>. If it is not <c>NULL</c>, it must be freed by using the CryptMemFree function.
		/// </summary>
		public IntPtr ppResponseInfo;

		/// <summary>
		/// A pointer to a string that contains a prefix for a cached file name. If not <c>NULL</c>, the specified prefix string is
		/// concatenated to the front of the cached file name.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszCacheFileNamePrefix;

		/// <summary>
		/// A pointer to a FILETIME structure that specifies a cache synchronization time. If not <c>NULL</c>, any information cached
		/// before this time is considered time invalid. For a <c>CRYPT_CACHE_ONLY_RETRIEVAL</c>, if there is a cached entry before this
		/// time, CryptRetrieveObjectByUrl returns <c>ERROR_INVALID_TIME</c>. When used with an HTTP retrieval, this specifies the
		/// maximum age for a time-valid object.
		/// </summary>
		public IntPtr pftCacheResync;

		/// <summary>
		/// A value that indicates whether CryptRetrieveObjectByUrl was called with <c>CRYPT_PROXY_CACHE_RETRIEVAL</c> set in
		/// dwRetrievalFlags and a proxy cache was not explicitly bypassed for the retrieval. This flag is not explicitly cleared and
		/// only applies to HTTP URL retrievals.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fProxyCacheRetrieval;

		/// <summary>
		/// A value that specifies a status code from an unsuccessful HTTP response header. If <c>CRYPT_NOT_MODIFIED_RETRIEVAL</c> was
		/// set in dwRetrievalFlags, and the HTTP retrieval returns <c>HTTP_STATUS_NOT_MODIFIED</c>, this contains the
		/// <c>HTTP_STATUS_NOT_MODIFIED</c> status code. This value is not explicitly cleared and is only updated for HTTP or HTTPS URL retrievals.
		/// </summary>
		public uint dwHttpStatusCode;

		/// <summary/>
		public IntPtr ppwszErrorResponseHeaders;

		/// <summary/>
		public IntPtr ppErrorContentBlob;
	}

	/// <summary>The data for the value entry.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "a92117b8-9144-4480-b88a-b9ffe1026d63")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_URL_ARRAY
	{
		/// <summary>Number of elements in the rgwszUrl array of URLs.</summary>
		public uint cUrl;

		/// <summary>An array of Unicode string pointers to URLs.</summary>
		public IntPtr rgwszUrl;
	}

	/// <summary>The <c>CRYPT_URL_INFO</c> structure contains information about groupings of URLs.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_url_info typedef struct _CRYPT_URL_INFO { DWORD
	// cbSize; DWORD dwSyncDeltaTime; DWORD cGroup; DWORD *rgcGroupEntry; } CRYPT_URL_INFO, *PCRYPT_URL_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "58289a66-6580-468c-b001-5da08cf6d4a9")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_URL_INFO
	{
		/// <summary>The size, in bytes, of the structure.</summary>
		public uint cbSize;

		/// <summary>Number of seconds between synchronizations.</summary>
		public uint dwSyncDeltaTime;

		/// <summary>Number of elements in the rgcGroupEntry array of URL groups.</summary>
		public uint cGroup;

		/// <summary>Array of URL groups returned.</summary>
		public IntPtr rgcGroupEntry;
	}
}