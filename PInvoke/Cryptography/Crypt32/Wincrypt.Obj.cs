namespace Vanara.PInvoke;

/// <summary>Methods and data types found in Crypt32.dll.</summary>
public static partial class Crypt32
{
	/// <summary>Decoding options.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "7d5ed4f4-9d76-4a16-9059-27b0edd83459")]
	[Flags]
	public enum CryptDecodeFlags
	{
		/// <summary>
		/// This flag can be set to indicate that "no copy" optimization is enabled. This optimization, where applicable, updates the
		/// pvStructInfo parameter to point to content residing within pbEncoded instead of making a copy of the content and appending
		/// it to pvStructInfo. For applicable cases, less memory needs to be allocated by the calling application and execution is
		/// faster because a copy is not being made. Note that the trade-off when performing a "no copy" decoding is that pbEncoded
		/// cannot be freed until pvStructInfo is freed.
		/// </summary>
		CRYPT_DECODE_NOCOPY_FLAG = 0x1,

		/// <summary>
		/// By default, the contents of the buffer pointed to by pbEncoded included the signed content and the signature. If this flag
		/// is set, the buffer includes only the "to be signed" content. This flag is applicable to X509_CERT_TO_BE_SIGNED,
		/// X509_CERT_CRL_TO_BE_SIGNED, X509_CRT_REQUEST_TO_BE_SIGNED, and X509_KEYGEN_REQUEST_TO_BE_SIGNED objects.
		/// </summary>
		CRYPT_DECODE_TO_BE_SIGNED_FLAG = 0x2,

		/// <summary>
		/// When this flag is set, the OID stings are allocated in Crypt32.dll and shared instead of being copied into the returned data
		/// structure. This flag can be set if Crypt32.dll is not unloaded before the caller is unloaded.
		/// </summary>
		CRYPT_DECODE_SHARE_OID_STRING_FLAG = 0x4,

		/// <summary>By default, the signature bytes are reversed. If this flag is set, this byte reversal is inhibited.</summary>
		CRYPT_DECODE_NO_SIGNATURE_BYTE_REVERSAL_FLAG = 0x8,

		/// <summary>
		/// The called decoding function allocates memory for the decoded structure. A pointer to the allocated structure is returned in pvStructInfo.
		/// <para>
		/// If pDecodePara or the pfnAlloc member of pDecodePara is NULL, then LocalAlloc is called for the allocation and LocalFree
		/// must be called to free the memory.
		/// </para>
		/// <para>
		/// If pDecodePara and the pfnAlloc member of pDecodePara are not NULL, then the function pointed to by pfnAlloc is called for
		/// the allocation and the function pointed to by the pfnFree member of pDecodePara must be called to free the memory.
		/// </para>
		/// </summary>
		CRYPT_DECODE_ALLOC_FLAG = 0x8000,

		/// <summary>
		/// This flag is applicable when decoding X509_UNICODE_NAME, X509_UNICODE_NAME_VALUE, or X509_UNICODE_ANY_STRING. By default,
		/// CERT_RDN_T61_STRING encoded values are initially decoded as UTF8. If the UTF8 decoding fails, then the value is decoded as
		/// eight-bit characters. If this flag is set, it skips the initial attempt to decode the value as UTF8 and decodes the value as
		/// eight-bit characters.
		/// </summary>
		CRYPT_UNICODE_NAME_DECODE_DISABLE_IE4_UTF8_FLAG = 0x01000000,

		/// <summary>
		/// This flag is applicable for enabling Punycode decoding of Unicode string values. For more information, see Remarks.
		/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.</para>
		/// </summary>
		CRYPT_DECODE_ENABLE_PUNYCODE_FLAG = 0x02000000,

		/// <summary/>
		CRYPT_DECODE_ENABLE_UTF8PERCENT_FLAG = 0x04000000,

		/// <summary/>
		CRYPT_DECODE_ENABLE_IA5CONVERSION_FLAG = CRYPT_DECODE_ENABLE_PUNYCODE_FLAG | CRYPT_DECODE_ENABLE_UTF8PERCENT_FLAG,
	}

	/// <summary>Specifies options for the encoding.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "45134db8-059b-43d3-90c2-9b6cc970fca0")]
	[Flags]
	public enum CryptEncodeFlags : uint
	{
		/// <summary/>
		CRYPT_ENCODE_NO_SIGNATURE_BYTE_REVERSAL_FLAG = 0x8,

		/// <summary>
		/// The called encoding function allocates memory for the encoded bytes. A pointer to the allocated bytes is returned in pvEncoded.
		/// </summary>
		CRYPT_ENCODE_ALLOC_FLAG = 0x8000,

		/// <summary> This flag is applicable when encoding X509_UNICODE_NAME. If this flag is set and all the Unicode characters are &lt;=
		/// 0xFF, the CERT_RDN_T61_STRING is selected instead of the CERT_RDN_UNICODE_STRING. </summary>
		CRYPT_UNICODE_NAME_ENCODE_ENABLE_T61_UNICODE_FLAG = 0x80000000,

		/// <summary>
		/// This flag is applicable when encoding an X509_UNICODE_NAME. When set, CERT_RDN_UTF8_STRING is selected instead of CERT_RDN_UNICODE_STRING.
		/// </summary>
		CRYPT_UNICODE_NAME_ENCODE_ENABLE_UTF8_UNICODE_FLAG = 0x20000000,

		/// <summary>
		/// This flag is applicable when encoding an X509_UNICODE_NAME. When set, CERT_RDN_UTF8_STRING is selected instead of
		/// CERT_RDN_PRINTABLE_STRING for directory string types. Also, this flag enables CRYPT_UNICODE_NAME_ENCODE_ENABLE_UTF8_UNICODE_FLAG.
		/// </summary>
		CRYPT_UNICODE_NAME_ENCODE_FORCE_UTF8_UNICODE_FLAG = 0x10000000,

		/// <summary>
		/// This flag is applicable when encoding X509_UNICODE_NAME, X509_UNICODE_NAME_VALUE, or X509_UNICODE_ANY_STRING. If this flag
		/// is set, the characters are not checked to determine whether they are valid for the specified value type.
		/// </summary>
		CRYPT_UNICODE_NAME_ENCODE_DISABLE_CHECK_TYPE_FLAG = 0x40000000,

		/// <summary/>
		CRYPT_SORTED_CTL_ENCODE_HASHED_SUBJECT_IDENTIFIER_FLAG = 0x10000,

		/// <summary>
		/// This flag is applicable for enabling Punycode encoding of Unicode string values. For more information, see Remarks.
		/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.</para>
		/// </summary>
		CRYPT_ENCODE_ENABLE_PUNYCODE_FLAG = 0x20000,

		/// <summary/>
		CRYPT_ENCODE_ENABLE_UTF8PERCENT_FLAG = 0x40000,

		/// <summary/>
		CRYPT_ENCODE_ENABLE_IA5CONVERSION_FLAG = CRYPT_ENCODE_ENABLE_PUNYCODE_FLAG | CRYPT_ENCODE_ENABLE_UTF8PERCENT_FLAG,
	}

	/// <summary>
	/// The <c>CryptDecodeObject</c> function decodes a structure of the type indicated by the lpszStructType parameter. The use of
	/// CryptDecodeObjectEx is recommended as an API that performs the same function with significant performance improvements.
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them with
	/// a bitwise- <c>OR</c> operation as shown in the following example:
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
	/// <para>
	/// <c>Note</c> Either a certificate or message encoding type is required. X509_ASN_ENCODING is the default. If that type is
	/// indicated, it is used. Otherwise, if the PKCS7_ASN_ENCODING type is indicated, it is used.
	/// </para>
	/// </param>
	/// <param name="lpszStructType">
	/// <para>
	/// A pointer to an OID defining the structure type. If the high-order word of the lpszStructType parameter is zero, the low-order
	/// word specifies the integer identifier for the type of the specified structure. Otherwise, this parameter is a long pointer to a
	/// null-terminated string.
	/// </para>
	/// <para>
	/// For more information about object identifier strings, their predefined constants and corresponding structures, see Constants for
	/// CryptEncodeObject and CryptDecodeObject.
	/// </para>
	/// </param>
	/// <param name="pbEncoded">A pointer to the encoded structure to be decoded.</param>
	/// <param name="cbEncoded">Number of bytes pointed to by pbEncoded.</param>
	/// <param name="dwFlags">
	/// <para>The following flags are defined. They can be combined with a bitwise- <c>OR</c> operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_DECODE_NOCOPY_FLAG</term>
	/// <term>
	/// This flag can be set to indicate that "no copy" optimization is enabled. This optimization, where applicable, updates the
	/// pvStructInfo parameter to point to content residing within pbEncoded instead of making a copy of the content and appending it to
	/// pvStructInfo. For applicable cases, less memory needs to be allocated by the calling application and execution is faster because
	/// a copy is not being made. Note that the trade-off when performing a "no copy" decoding is that pbEncoded cannot be freed until
	/// pvStructInfo is freed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_UNICODE_NAME_DECODE_DISABLE_IE4_UTF8_FLAG</term>
	/// <term>
	/// This flag is applicable when decoding X509_UNICODE_NAME, X509_UNICODE_NAME_VALUE, or X509_UNICODE_ANY_STRING. By default,
	/// CERT_RDN_T61_STRING encoded values are initially decoded as UTF8. If the UTF8 decoding fails, then the value is decoded as
	/// eight-bit characters. If this flag is set, it skips the initial attempt to decode the value as UTF8 and decodes the value as
	/// eight-bit characters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECODE_TO_BE_SIGNED_FLAG</term>
	/// <term>
	/// By default, the contents of the buffer pointed to by pbEncoded included the signed content and the signature. If this flag is
	/// set, the buffer includes only the "to be signed" content. This flag is applicable to X509_CERT_TO_BE_SIGNED,
	/// X509_CERT_CRL_TO_BE_SIGNED, X509_CRT_REQUEST_TO_BE_SIGNED, and X509_KEYGEN_REQUEST_TO_BE_SIGNED objects.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECODE_SHARE_OID_STRING_FLAG</term>
	/// <term>
	/// When this flag is set, the OID stings are allocated in Crypt32.dll and shared instead of being copied into the returned data
	/// structure. This flag can be set if Crypt32.dll is not unloaded before the caller is unloaded.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECODE_NO_SIGNATURE_BYTE_REVERSAL_FLAG</term>
	/// <term>By default, the signature bytes are reversed. If this flag is set, this byte reversal is inhibited.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvStructInfo">
	/// <para>
	/// A pointer to a buffer to receive the decoded structure. When the buffer that is specified is not large enough to receive the
	/// decoded structure, the function sets the ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable
	/// pointed to by pcbStructInfo.
	/// </para>
	/// <para>
	/// This parameter can be <c>NULL</c> to retrieve the size of this information for memory allocation purposes. For more information,
	/// see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbStructInfo">
	/// <para>
	/// A pointer to a <c>DWORD</c> value specifying the size, in bytes, of the buffer pointed to by the pvStructInfo parameter. When
	/// the function returns, this <c>DWORD</c> value contains the size of the decoded data copied to pvStructInfo. The size contained
	/// in the variable pointed to by pcbStructInfo can indicate a size larger than the decoded structure, as the decoded structure can
	/// include pointers to other structures. This size is the sum of the size needed by the decoded structure and other structures
	/// pointed to.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to
	/// by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>
	/// If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError. Some
	/// possible error codes are listed in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_BAD_ENCODE</term>
	/// <term>An error was encountered while decoding.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>A decoding function could not be found for the specified dwCertEncodingType and lpszStructType</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pvStructInfo parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by pcbStructInfo.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When encoding a cryptographic object using the preferred CryptEncodeObjectEx function, the terminating <c>NULL</c> character is
	/// included. When decoding, using the preferred CryptDecodeObjectEx function, the terminating <c>NULL</c> character is not retained.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: ASN.1 Encoding and Decoding.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptdecodeobject BOOL CryptDecodeObject( DWORD
	// dwCertEncodingType, LPCSTR lpszStructType, const BYTE *pbEncoded, DWORD cbEncoded, DWORD dwFlags, void *pvStructInfo, DWORD
	// *pcbStructInfo );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "7d5ed4f4-9d76-4a16-9059-27b0edd83459")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDecodeObject(CertEncodingType dwCertEncodingType, [In] SafeOID lpszStructType, [In] IntPtr pbEncoded, uint cbEncoded,
		CryptDecodeFlags dwFlags, [Out] IntPtr pvStructInfo, ref uint pcbStructInfo);

	/// <summary>
	/// The <c>CryptDecodeObjectEx</c> function decodes a structure of the type indicated by the lpszStructType parameter.
	/// <c>CryptDecodeObjectEx</c> offers a significant performance improvement over CryptDecodeObject by supporting memory allocation
	/// with the CRYPT_DECODE_ALLOC_FLAG value.
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// The type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them
	/// with a bitwise- <c>OR</c> operation as shown in the following example:
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
	/// <para>
	/// <c>Note</c> Either a certificate or message encoding type is required. X509_ASN_ENCODING is the default. If that type is
	/// indicated, it is used. Otherwise, if the PKCS7_ASN_ENCODING type is indicated, it is used.
	/// </para>
	/// </param>
	/// <param name="lpszStructType">
	/// <para>
	/// A pointer to an object identifier (OID) that defines the structure type. If the high-order word of the lpszStructType parameter
	/// is zero, the low-order word specifies the integer identifier for the type of the specified structure. Otherwise, this parameter
	/// is a long pointer to a null-terminated string.
	/// </para>
	/// <para>
	/// For more information about object identifier strings, their predefined constants, and corresponding structures, see Constants
	/// for CryptEncodeObject and CryptDecodeObject.
	/// </para>
	/// </param>
	/// <param name="pbEncoded">A pointer to the data to be decoded. The structure must be of the type specified by lpszStructType.</param>
	/// <param name="cbEncoded">The number of bytes pointed to by pbEncoded. This is the number of bytes to be decoded.</param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one or more of the following flags. The flags can be combined by using a bitwise- <c>OR</c> operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_DECODE_ALLOC_FLAG</term>
	/// <term>
	/// The called decoding function allocates memory for the decoded structure. A pointer to the allocated structure is returned in
	/// pvStructInfo. If pDecodePara or the pfnAlloc member of pDecodePara is NULL, then LocalAlloc is called for the allocation and
	/// LocalFree must be called to free the memory. If pDecodePara and the pfnAlloc member of pDecodePara are not NULL, then the
	/// function pointed to by pfnAlloc is called for the allocation and the function pointed to by the pfnFree member of pDecodePara
	/// must be called to free the memory.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECODE_ENABLE_PUNYCODE_FLAG 33554432 (0x2000000)</term>
	/// <term>
	/// This flag is applicable for enabling Punycode decoding of Unicode string values. For more information, see Remarks. Windows
	/// Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECODE_NOCOPY_FLAG</term>
	/// <term>
	/// This flag can be set to enable a "no copy" optimization. This optimization updates the pvStructInfo members to point to content
	/// that resides within pbEncoded instead of making a copy of the content and appending it to pvStructInfo. The calling application
	/// needs to allocate less memory and execution is faster because a copy is not made. Note that when performing "no copy" decoding,
	/// pbEncoded cannot be freed until pvStructInfo is freed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_UNICODE_NAME_DECODE_DISABLE_IE4_UTF8_FLAG</term>
	/// <term>
	/// This flag is applicable when decoding X509_UNICODE_NAME, X509_UNICODE_NAME_VALUE, or X509_UNICODE_ANY_STRING. By default,
	/// CERT_RDN_T61_STRING encoded values are initially decoded as UTF8. If the UTF8 decoding fails, then the value is decoded as
	/// eight-bit characters. If this flag is set, it skips the initial attempt to decode the value as UTF8 and decodes the value as
	/// eight-bit characters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECODE_TO_BE_SIGNED_FLAG</term>
	/// <term>
	/// By default, the contents of the buffer pointed to by pbEncoded included the signed content and the signature. If this flag is
	/// set, the buffer includes only the "to be signed" content. This flag is applicable to X509_CERT_TO_BE_SIGNED,
	/// X509_CERT_CRL_TO_BE_SIGNED, X509_CRT_REQUEST_TO_BE_SIGNED, and X509_KEYGEN_REQUEST_TO_BE_SIGNED objects.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECODE_SHARE_OID_STRING_FLAG</term>
	/// <term>
	/// When this flag is set, the OID strings are allocated in Crypt32.dll and shared instead of being copied into the returned data
	/// structure. This flag can be set if Crypt32.dll is not unloaded before the caller is unloaded.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECODE_NO_SIGNATURE_BYTE_REVERSAL_FLAG</term>
	/// <term>By default, the signature bytes are reversed. If this flag is set, this byte reversal is inhibited.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pDecodePara">
	/// A pointer to a CRYPT_DECODE_PARA structure that contains decoding paragraph information. If pDecodePara is set to <c>NULL</c>,
	/// then LocalAlloc and LocalFree are used to allocate and free memory. If pDecodePara points to a <c>CRYPT_DECODE_PARA</c>
	/// structure, that structure passes in callback functions to allocate and free memory. These callback functions override the
	/// default memory allocation of <c>LocalAlloc</c> and <c>LocalFree</c>.
	/// </param>
	/// <param name="pvStructInfo">
	/// <para>
	/// If the dwFlags CRYPT_ENCODE_ALLOC_FLAG is set, pvStructInfo is not a pointer to a buffer but is the address of a pointer to the
	/// buffer. Because memory is allocated inside the function and the pointer is stored at *pvStructInfo, pvStructInfo must never be <c>NULL</c>.
	/// </para>
	/// <para>
	/// If CRYPT_ENCODE_ALLOC_FLAG is not set, pvStructInfo is a pointer to a buffer that receives the decoded structure. When the
	/// buffer that is specified is not large enough to receive the decoded structure, the function sets the ERROR_MORE_DATA code and
	/// stores the required buffer size, in bytes, in the variable pointed to by pcbStructInfo.
	/// </para>
	/// <para>
	/// This parameter can be <c>NULL</c> to retrieve the size of this information for memory allocation purposes. For more information,
	/// see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbStructInfo">
	/// <para>
	/// A pointer to a <c>DWORD</c> variable that contains the size, in bytes, of the buffer pointed to by the pvStructInfo parameter.
	/// When the function returns, the <c>DWORD</c> value contains the number of bytes stored in the buffer. The size contained in the
	/// variable pointed to by pcbStructInfo can indicate a size larger than the decoded structure because the decoded structure can
	/// include pointers to auxiliary data. This size is the sum of the size needed by the decoded structure and the auxiliary data.
	/// </para>
	/// <para>
	/// When CRYPT_DECODE_ALLOC_FLAG is set, the initial value of *pcbStructInfo is not used by the function, and on return,
	/// *pcbStructInfo contains the number of bytes allocated for pvStructInfo.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to
	/// by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>
	/// If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError. The following table
	/// shows some possible error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_BAD_ENCODE</term>
	/// <term>An error was encountered while decoding.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>A decoding function could not be found for the specified dwCertEncodingType and lpszStructType.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pvStructInfo parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by pcbStructInfo.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When encoding a cryptographic object using the preferred CryptEncodeObjectEx function, the terminating <c>NULL</c> character is
	/// included. When decoding, using the preferred <c>CryptDecodeObjectEx</c> function, the terminating <c>NULL</c> character is not retained.
	/// </para>
	/// <para>
	/// Each constant in the list below has an associated structure type that is pointed to by the pvStructInfo parameter. The structure
	/// pointed to, directly or indirectly, has a reference to a CERT_ALT_NAME_ENTRY structure.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ALTERNATE_NAME</term>
	/// </item>
	/// <item>
	/// <term>szOID_AUTHORITY_INFO_ACCESS</term>
	/// </item>
	/// <item>
	/// <term>X509_AUTHORITY_INFO_ACCESS</term>
	/// </item>
	/// <item>
	/// <term>X509_AUTHORITY_KEY_ID2</term>
	/// </item>
	/// <item>
	/// <term>szOID_AUTHORITY_KEY_IDENTIFIER2</term>
	/// </item>
	/// <item>
	/// <term>szOID_CRL_DIST_POINTS</term>
	/// </item>
	/// <item>
	/// <term>X509_CRL_DIST_POINTS</term>
	/// </item>
	/// <item>
	/// <term>szOID_CROSS_CERT_DIST_POINTS</term>
	/// </item>
	/// <item>
	/// <term>X509_CROSS_CERT_DIST_POINTS</term>
	/// </item>
	/// <item>
	/// <term>szOID_ISSUER_ALT_NAME</term>
	/// </item>
	/// <item>
	/// <term>szOID_ISSUER_ALT_NAME2</term>
	/// </item>
	/// <item>
	/// <term>szOID_ISSUING_DIST_POINT</term>
	/// </item>
	/// <item>
	/// <term>X509_ISSUING_DIST_POINT</term>
	/// </item>
	/// <item>
	/// <term>X509_NAME_CONSTRAINTS</term>
	/// </item>
	/// <item>
	/// <term>szOID_NAME_CONSTRAINTS</term>
	/// </item>
	/// <item>
	/// <term>szOID_NEXT_UPDATE_LOCATION</term>
	/// </item>
	/// <item>
	/// <term>OCSP_REQUEST</term>
	/// </item>
	/// <item>
	/// <term>zOID_SUBJECT_ALT_NAME</term>
	/// </item>
	/// <item>
	/// <term>szOID_SUBJECT_ALT_NAME2</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>CRYPT_DECODE_ENABLE_PUNYCODE_FLAG</c> flag, in conjunction with the value of the <c>dwAltNameChoice</c> member of the
	/// CERT_ALT_NAME_ENTRY structure, determines the manner in which strings are encoded.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwAltNameChoice</term>
	/// <term>Effect</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_ALT_NAME_DNS_NAME</term>
	/// <term>If the host name contains a Punycode encoded IA5String string, it is converted to the Unicode equivalent.</term>
	/// </item>
	/// <item>
	/// <term>CERT_ALT_NAME_RFC822_NAME</term>
	/// <term>
	/// If the host name portion of the email address contains a Punycode encoded IA5String string, it is converted to its Unicode equivalent.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_ALT_NAME_URL</term>
	/// <term>
	/// The URI is decoded. If the server host name of the URI contains a Punycode encoded IA5String string, the host name string is
	/// decoded to the Unicode equivalent.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Each constant in the list below has an associated structure type that is pointed to by the pvStructInfo parameter. The structure
	/// pointed to, directly or indirectly, has a reference to a CERT_HASHED_URL structure.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>szOID_LOGOTYPE_EXT</term>
	/// </item>
	/// <item>
	/// <term>X509_LOGOTYPE_EXT</term>
	/// </item>
	/// <item>
	/// <term>szOID_BIOMETRIC_EXT</term>
	/// </item>
	/// <item>
	/// <term>X509_BIOMETRIC_EXT</term>
	/// </item>
	/// </list>
	/// <para>
	/// When decoding the CERT_HASHED_URL structure value, the URI is decoded. If the host name contains a Punycode encoded host name,
	/// it is converted to the Unicode equivalent.
	/// </para>
	/// <para>
	/// Each <c>X509_UNICODE_NAME</c> constant in the list below has an associated structure type that is pointed to by the pvStructInfo parameter.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_UNICODE_NAME</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the pszObjId member of the CERT_RDN_ATTR structure is set to <c>szOID_RSA_emailAddr</c> and the email address in the
	/// <c>Value</c> member contains Punycode encoded string, it is converted to the Unicode equivalent.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: ASN.1 Encoding and Decoding.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptdecodeobjectex BOOL CryptDecodeObjectEx( DWORD
	// dwCertEncodingType, LPCSTR lpszStructType, const BYTE *pbEncoded, DWORD cbEncoded, DWORD dwFlags, PCRYPT_DECODE_PARA pDecodePara,
	// void *pvStructInfo, DWORD *pcbStructInfo );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "bf1935f0-1ab0-4068-9ed5-8fbb2c286b8a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDecodeObjectEx(CertEncodingType dwCertEncodingType, [In] SafeOID lpszStructType, [In] IntPtr pbEncoded, uint cbEncoded,
		CryptDecodeFlags dwFlags, in CRYPT_DECODE_PARA pDecodePara, [Out] IntPtr pvStructInfo, ref uint pcbStructInfo);

	/// <summary>
	/// The <c>CryptDecodeObjectEx</c> function decodes a structure of the type indicated by the lpszStructType parameter.
	/// <c>CryptDecodeObjectEx</c> offers a significant performance improvement over CryptDecodeObject by supporting memory allocation
	/// with the CRYPT_DECODE_ALLOC_FLAG value.
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// The type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them
	/// with a bitwise- <c>OR</c> operation as shown in the following example:
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
	/// <para>
	/// <c>Note</c> Either a certificate or message encoding type is required. X509_ASN_ENCODING is the default. If that type is
	/// indicated, it is used. Otherwise, if the PKCS7_ASN_ENCODING type is indicated, it is used.
	/// </para>
	/// </param>
	/// <param name="lpszStructType">
	/// <para>
	/// A pointer to an object identifier (OID) that defines the structure type. If the high-order word of the lpszStructType parameter
	/// is zero, the low-order word specifies the integer identifier for the type of the specified structure. Otherwise, this parameter
	/// is a long pointer to a null-terminated string.
	/// </para>
	/// <para>
	/// For more information about object identifier strings, their predefined constants, and corresponding structures, see Constants
	/// for CryptEncodeObject and CryptDecodeObject.
	/// </para>
	/// </param>
	/// <param name="pbEncoded">A pointer to the data to be decoded. The structure must be of the type specified by lpszStructType.</param>
	/// <param name="cbEncoded">The number of bytes pointed to by pbEncoded. This is the number of bytes to be decoded.</param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one or more of the following flags. The flags can be combined by using a bitwise- <c>OR</c> operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_DECODE_ALLOC_FLAG</term>
	/// <term>
	/// The called decoding function allocates memory for the decoded structure. A pointer to the allocated structure is returned in
	/// pvStructInfo. If pDecodePara or the pfnAlloc member of pDecodePara is NULL, then LocalAlloc is called for the allocation and
	/// LocalFree must be called to free the memory. If pDecodePara and the pfnAlloc member of pDecodePara are not NULL, then the
	/// function pointed to by pfnAlloc is called for the allocation and the function pointed to by the pfnFree member of pDecodePara
	/// must be called to free the memory.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECODE_ENABLE_PUNYCODE_FLAG 33554432 (0x2000000)</term>
	/// <term>
	/// This flag is applicable for enabling Punycode decoding of Unicode string values. For more information, see Remarks. Windows
	/// Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECODE_NOCOPY_FLAG</term>
	/// <term>
	/// This flag can be set to enable a "no copy" optimization. This optimization updates the pvStructInfo members to point to content
	/// that resides within pbEncoded instead of making a copy of the content and appending it to pvStructInfo. The calling application
	/// needs to allocate less memory and execution is faster because a copy is not made. Note that when performing "no copy" decoding,
	/// pbEncoded cannot be freed until pvStructInfo is freed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_UNICODE_NAME_DECODE_DISABLE_IE4_UTF8_FLAG</term>
	/// <term>
	/// This flag is applicable when decoding X509_UNICODE_NAME, X509_UNICODE_NAME_VALUE, or X509_UNICODE_ANY_STRING. By default,
	/// CERT_RDN_T61_STRING encoded values are initially decoded as UTF8. If the UTF8 decoding fails, then the value is decoded as
	/// eight-bit characters. If this flag is set, it skips the initial attempt to decode the value as UTF8 and decodes the value as
	/// eight-bit characters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECODE_TO_BE_SIGNED_FLAG</term>
	/// <term>
	/// By default, the contents of the buffer pointed to by pbEncoded included the signed content and the signature. If this flag is
	/// set, the buffer includes only the "to be signed" content. This flag is applicable to X509_CERT_TO_BE_SIGNED,
	/// X509_CERT_CRL_TO_BE_SIGNED, X509_CRT_REQUEST_TO_BE_SIGNED, and X509_KEYGEN_REQUEST_TO_BE_SIGNED objects.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECODE_SHARE_OID_STRING_FLAG</term>
	/// <term>
	/// When this flag is set, the OID strings are allocated in Crypt32.dll and shared instead of being copied into the returned data
	/// structure. This flag can be set if Crypt32.dll is not unloaded before the caller is unloaded.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECODE_NO_SIGNATURE_BYTE_REVERSAL_FLAG</term>
	/// <term>By default, the signature bytes are reversed. If this flag is set, this byte reversal is inhibited.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pDecodePara">
	/// A pointer to a CRYPT_DECODE_PARA structure that contains decoding paragraph information. If pDecodePara is set to <c>NULL</c>,
	/// then LocalAlloc and LocalFree are used to allocate and free memory. If pDecodePara points to a <c>CRYPT_DECODE_PARA</c>
	/// structure, that structure passes in callback functions to allocate and free memory. These callback functions override the
	/// default memory allocation of <c>LocalAlloc</c> and <c>LocalFree</c>.
	/// </param>
	/// <param name="pvStructInfo">
	/// <para>
	/// If the dwFlags CRYPT_ENCODE_ALLOC_FLAG is set, pvStructInfo is not a pointer to a buffer but is the address of a pointer to the
	/// buffer. Because memory is allocated inside the function and the pointer is stored at *pvStructInfo, pvStructInfo must never be <c>NULL</c>.
	/// </para>
	/// <para>
	/// If CRYPT_ENCODE_ALLOC_FLAG is not set, pvStructInfo is a pointer to a buffer that receives the decoded structure. When the
	/// buffer that is specified is not large enough to receive the decoded structure, the function sets the ERROR_MORE_DATA code and
	/// stores the required buffer size, in bytes, in the variable pointed to by pcbStructInfo.
	/// </para>
	/// <para>
	/// This parameter can be <c>NULL</c> to retrieve the size of this information for memory allocation purposes. For more information,
	/// see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbStructInfo">
	/// <para>
	/// A pointer to a <c>DWORD</c> variable that contains the size, in bytes, of the buffer pointed to by the pvStructInfo parameter.
	/// When the function returns, the <c>DWORD</c> value contains the number of bytes stored in the buffer. The size contained in the
	/// variable pointed to by pcbStructInfo can indicate a size larger than the decoded structure because the decoded structure can
	/// include pointers to auxiliary data. This size is the sum of the size needed by the decoded structure and the auxiliary data.
	/// </para>
	/// <para>
	/// When CRYPT_DECODE_ALLOC_FLAG is set, the initial value of *pcbStructInfo is not used by the function, and on return,
	/// *pcbStructInfo contains the number of bytes allocated for pvStructInfo.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to
	/// by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>
	/// If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError. The following table
	/// shows some possible error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_BAD_ENCODE</term>
	/// <term>An error was encountered while decoding.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>A decoding function could not be found for the specified dwCertEncodingType and lpszStructType.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pvStructInfo parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by pcbStructInfo.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When encoding a cryptographic object using the preferred CryptEncodeObjectEx function, the terminating <c>NULL</c> character is
	/// included. When decoding, using the preferred <c>CryptDecodeObjectEx</c> function, the terminating <c>NULL</c> character is not retained.
	/// </para>
	/// <para>
	/// Each constant in the list below has an associated structure type that is pointed to by the pvStructInfo parameter. The structure
	/// pointed to, directly or indirectly, has a reference to a CERT_ALT_NAME_ENTRY structure.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ALTERNATE_NAME</term>
	/// </item>
	/// <item>
	/// <term>szOID_AUTHORITY_INFO_ACCESS</term>
	/// </item>
	/// <item>
	/// <term>X509_AUTHORITY_INFO_ACCESS</term>
	/// </item>
	/// <item>
	/// <term>X509_AUTHORITY_KEY_ID2</term>
	/// </item>
	/// <item>
	/// <term>szOID_AUTHORITY_KEY_IDENTIFIER2</term>
	/// </item>
	/// <item>
	/// <term>szOID_CRL_DIST_POINTS</term>
	/// </item>
	/// <item>
	/// <term>X509_CRL_DIST_POINTS</term>
	/// </item>
	/// <item>
	/// <term>szOID_CROSS_CERT_DIST_POINTS</term>
	/// </item>
	/// <item>
	/// <term>X509_CROSS_CERT_DIST_POINTS</term>
	/// </item>
	/// <item>
	/// <term>szOID_ISSUER_ALT_NAME</term>
	/// </item>
	/// <item>
	/// <term>szOID_ISSUER_ALT_NAME2</term>
	/// </item>
	/// <item>
	/// <term>szOID_ISSUING_DIST_POINT</term>
	/// </item>
	/// <item>
	/// <term>X509_ISSUING_DIST_POINT</term>
	/// </item>
	/// <item>
	/// <term>X509_NAME_CONSTRAINTS</term>
	/// </item>
	/// <item>
	/// <term>szOID_NAME_CONSTRAINTS</term>
	/// </item>
	/// <item>
	/// <term>szOID_NEXT_UPDATE_LOCATION</term>
	/// </item>
	/// <item>
	/// <term>OCSP_REQUEST</term>
	/// </item>
	/// <item>
	/// <term>zOID_SUBJECT_ALT_NAME</term>
	/// </item>
	/// <item>
	/// <term>szOID_SUBJECT_ALT_NAME2</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>CRYPT_DECODE_ENABLE_PUNYCODE_FLAG</c> flag, in conjunction with the value of the <c>dwAltNameChoice</c> member of the
	/// CERT_ALT_NAME_ENTRY structure, determines the manner in which strings are encoded.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwAltNameChoice</term>
	/// <term>Effect</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_ALT_NAME_DNS_NAME</term>
	/// <term>If the host name contains a Punycode encoded IA5String string, it is converted to the Unicode equivalent.</term>
	/// </item>
	/// <item>
	/// <term>CERT_ALT_NAME_RFC822_NAME</term>
	/// <term>
	/// If the host name portion of the email address contains a Punycode encoded IA5String string, it is converted to its Unicode equivalent.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_ALT_NAME_URL</term>
	/// <term>
	/// The URI is decoded. If the server host name of the URI contains a Punycode encoded IA5String string, the host name string is
	/// decoded to the Unicode equivalent.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Each constant in the list below has an associated structure type that is pointed to by the pvStructInfo parameter. The structure
	/// pointed to, directly or indirectly, has a reference to a CERT_HASHED_URL structure.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>szOID_LOGOTYPE_EXT</term>
	/// </item>
	/// <item>
	/// <term>X509_LOGOTYPE_EXT</term>
	/// </item>
	/// <item>
	/// <term>szOID_BIOMETRIC_EXT</term>
	/// </item>
	/// <item>
	/// <term>X509_BIOMETRIC_EXT</term>
	/// </item>
	/// </list>
	/// <para>
	/// When decoding the CERT_HASHED_URL structure value, the URI is decoded. If the host name contains a Punycode encoded host name,
	/// it is converted to the Unicode equivalent.
	/// </para>
	/// <para>
	/// Each <c>X509_UNICODE_NAME</c> constant in the list below has an associated structure type that is pointed to by the pvStructInfo parameter.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_UNICODE_NAME</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the pszObjId member of the CERT_RDN_ATTR structure is set to <c>szOID_RSA_emailAddr</c> and the email address in the
	/// <c>Value</c> member contains Punycode encoded string, it is converted to the Unicode equivalent.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: ASN.1 Encoding and Decoding.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptdecodeobjectex BOOL CryptDecodeObjectEx( DWORD
	// dwCertEncodingType, LPCSTR lpszStructType, const BYTE *pbEncoded, DWORD cbEncoded, DWORD dwFlags, PCRYPT_DECODE_PARA pDecodePara,
	// void *pvStructInfo, DWORD *pcbStructInfo );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "bf1935f0-1ab0-4068-9ed5-8fbb2c286b8a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDecodeObjectEx(CertEncodingType dwCertEncodingType, [In] SafeOID lpszStructType, [In] IntPtr pbEncoded, uint cbEncoded,
		CryptDecodeFlags dwFlags, [In, Optional] IntPtr pDecodePara, [Out] IntPtr pvStructInfo, ref uint pcbStructInfo);

	/// <summary>
	/// The <c>CryptEncodeObject</c> function encodes a structure of the type indicated by the value of the lpszStructType parameter.
	/// The use of CryptEncodeObjectEx is recommended as an API that performs the same function with significant performance improvements.
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them with
	/// a bitwise- <c>OR</c> operation as shown in the following example:
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
	/// <para>
	/// <c>Note</c> Either a certificate or message encoding type is required. X509_ASN_ENCODING is the default. If that type is
	/// indicated, it is used. Otherwise, if the PKCS7_ASN_ENCODING type is indicated, it is used.
	/// </para>
	/// </param>
	/// <param name="lpszStructType">
	/// <para>
	/// A pointer to an OID defining the structure type. If the high-order word of the lpszStructType parameter is zero, the low-order
	/// word specifies the integer identifier for the type of the specified structure. Otherwise, this parameter is a long pointer to a
	/// null-terminated string.
	/// </para>
	/// <para>
	/// For more information about object identifier strings, their predefined constants and corresponding structures, see Constants for
	/// CryptEncodeObject and CryptDecodeObject.
	/// </para>
	/// </param>
	/// <param name="pvStructInfo">A pointer to the structure to be encoded. The structure must be of a type specified by lpszStructType.</param>
	/// <param name="pbEncoded">
	/// <para>
	/// A pointer to a buffer to receive the encoded structure. When the buffer that is specified is not large enough to receive the
	/// decoded structure, the function sets the ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable
	/// pointed to by pcbEncoded.
	/// </para>
	/// <para>
	/// This parameter can be <c>NULL</c> to retrieve the size of this information for memory allocation purposes. For more information,
	/// see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbEncoded">
	/// <para>
	/// A pointer to a <c>DWORD</c> variable that contains the size, in bytes, of the buffer pointed to by the pbEncoded parameter. When
	/// the function returns, the <c>DWORD</c> value contains the number of allocated encoded bytes stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to
	/// by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>
	/// If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError. Some
	/// possible error codes are listed in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_BAD_ENCODE</term>
	/// <term>An error was encountered while encoding.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>An encoding function could not be found for the specified dwCertEncodingType and lpszStructType.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbEncoded parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by pcbEncoded.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When encoding a cryptographic object using the preferred CryptEncodeObjectEx function, the terminating <c>NULL</c> character is
	/// included. When decoding, using the preferred CryptDecodeObjectEx function, the terminating <c>NULL</c> character is not retained.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// For an example that uses this function, see Example C Program: Making a Certificate Request and Example C Program: ASN.1
	/// Encoding and Decoding.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptencodeobject BOOL CryptEncodeObject( DWORD
	// dwCertEncodingType, LPCSTR lpszStructType, const void *pvStructInfo, BYTE *pbEncoded, DWORD *pcbEncoded );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "9576a2a7-4379-4c1b-8ad5-284720cf7ccc")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptEncodeObject(CertEncodingType dwCertEncodingType, [In] SafeOID lpszStructType, [In] IntPtr pvStructInfo, [Out] IntPtr pbEncoded, ref uint pcbEncoded);

	/// <summary>
	/// The <c>CryptEncodeObjectEx</c> function encodes a structure of the type indicated by the value of the lpszStructType parameter.
	/// This function offers a significant performance improvement over CryptEncodeObject by supporting memory allocation with the
	/// <c>CRYPT_ENCODE_ALLOC_FLAG</c> value.
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// The certificate encoding type and message encoding type to use to encode the object. This parameter can be a combination of one
	/// or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING 65536 (0x10000)</term>
	/// <term>Specifies PKCS 7 message encoding.</term>
	/// </item>
	/// <item>
	/// <term>X509_ASN_ENCODING 1 (0x1)</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpszStructType">
	/// <para>
	/// A pointer to an object identifier (OID) that defines the structure type. If the high-order word of the lpszStructType parameter
	/// is zero, the low-order word specifies an integer identifier for the type of the specified structure. Otherwise, this parameter
	/// is a pointer to a null-terminated string that contains the string representation of the OID.
	/// </para>
	/// <para>
	/// For more information about object identifier strings, their predefined constants and corresponding structures, see Constants for
	/// CryptEncodeObject and CryptDecodeObject.
	/// </para>
	/// </param>
	/// <param name="pvStructInfo">A pointer to the structure to be encoded. The structure must be of the type specified by lpszStructType.</param>
	/// <param name="dwFlags">
	/// <para>Specifies options for the encoding. This parameter can be zero or a combination of one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_ENCODE_ALLOC_FLAG 32768 (0x8000)</term>
	/// <term>The called encoding function allocates memory for the encoded bytes. A pointer to the allocated bytes is returned in pvEncoded.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ENCODE_ENABLE_PUNYCODE_FLAG 131072 (0x20000)</term>
	/// <term>
	/// This flag is applicable for enabling Punycode encoding of Unicode string values. For more information, see Remarks. Windows
	/// Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_UNICODE_NAME_ENCODE_DISABLE_CHECK_TYPE_FLAG 1073741824 (0x40000000)</term>
	/// <term>
	/// This flag is applicable when encoding X509_UNICODE_NAME, X509_UNICODE_NAME_VALUE, or X509_UNICODE_ANY_STRING. If this flag is
	/// set, the characters are not checked to determine whether they are valid for the specified value type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_UNICODE_NAME_ENCODE_ENABLE_T61_UNICODE_FLAG 2147483648 (0x80000000)</term>
	/// <term>
	/// This flag is applicable when encoding X509_UNICODE_NAME. If this flag is set and all the Unicode characters are &lt;= 0xFF, the
	/// CERT_RDN_T61_STRING is selected instead of the CERT_RDN_UNICODE_STRING.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_UNICODE_NAME_ENCODE_ENABLE_UTF8_UNICODE_FLAG 536870912 (0x20000000)</term>
	/// <term>This flag is applicable when encoding an X509_UNICODE_NAME. When set, CERT_RDN_UTF8_STRING is selected instead of CERT_RDN_UNICODE_STRING.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_UNICODE_NAME_ENCODE_FORCE_UTF8_UNICODE_FLAG 268435456 (0x10000000)</term>
	/// <term>
	/// This flag is applicable when encoding an X509_UNICODE_NAME. When set, CERT_RDN_UTF8_STRING is selected instead of
	/// CERT_RDN_PRINTABLE_STRING for directory string types. Also, this flag enables CRYPT_UNICODE_NAME_ENCODE_ENABLE_UTF8_UNICODE_FLAG.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pEncodePara">
	/// <para>A pointer to a CRYPT_ENCODE_PARA structure that contains encoding information. This parameter can be <c>NULL</c>.</para>
	/// <para>
	/// If either pEncodePara or the <c>pfnAlloc</c> member of pEncodePara is <c>NULL</c>, then LocalAlloc is used for the allocation
	/// and LocalFree must be called to free the memory.
	/// </para>
	/// <para>
	/// If both pEncodePara and the <c>pfnAlloc</c> member of pEncodePara are not <c>NULL</c>, then the function pointed to by the
	/// <c>pfnAlloc</c> member of the CRYPT_ENCODE_PARA structure pointed to by pEncodePara is called for the allocation. The function
	/// pointed to by the <c>pfnFree</c> member of pEncodePara must be called to free the memory.
	/// </para>
	/// </param>
	/// <param name="pvEncoded">
	/// <para>
	/// A pointer to a buffer to receive the encoded structure. The size of this buffer is specified in the pcbEncoded parameter. When
	/// the buffer that is specified is not large enough to receive the decoded structure, the function sets the <c>ERROR_MORE_DATA</c>
	/// code and stores the required buffer size, in bytes, in the variable pointed to by pcbEncoded.
	/// </para>
	/// <para>
	/// This parameter can be <c>NULL</c> to retrieve the size of the buffer for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// <para>
	/// If dwFlags contains the <c>CRYPT_ENCODE_ALLOC_FLAG</c> flag, pvEncoded is not a pointer to a buffer but is the address of a
	/// pointer to the buffer. Because memory is allocated inside the function and the pointer is stored in pvEncoded, pvEncoded cannot
	/// be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pcbEncoded">
	/// <para>
	/// A pointer to a <c>DWORD</c> variable that contains the size, in bytes, of the buffer pointed to by the pvEncoded parameter. When
	/// the function returns, the variable pointed to by the pcbEncoded parameter contains the number of allocated, encoded bytes stored
	/// in the buffer.
	/// </para>
	/// <para>
	/// When dwFlags contains the <c>CRYPT_ENCODE_ALLOC_FLAG</c> flag, pcbEncoded is the address of a pointer to the <c>DWORD</c> value
	/// that is updated.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to
	/// by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns nonzero if successful or zero otherwise.</para>
	/// <para>
	/// For extended error information, call GetLastError. The following table shows some possible error codes that can be returned from
	/// <c>GetLastError</c> when <c>CryptEncodeObjectEx</c> fails.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_BAD_ENCODE</term>
	/// <term>An error was encountered while encoding.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>An encoding function could not be found for the specified dwCertEncodingType and lpszStructType.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pvEncoded parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by pcbEncoded.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When encoding a cryptographic object using the preferred <c>CryptEncodeObjectEx</c> function, the terminating <c>NULL</c>
	/// character is included. When decoding, using the preferred CryptDecodeObjectEx function, the terminating <c>NULL</c> character is
	/// not retained.
	/// </para>
	/// <para>
	/// <c>CryptEncodeObjectEx</c> first looks for an installable extended encoding function. If no extended encoding function is found,
	/// the old, nonextended, installable function is located.
	/// </para>
	/// <para>
	/// When direct IA5String encoding of the object is not possible, you can specify Punycode encoding by setting the dwFlag parameter
	/// to the <c>CRYPT_ENCODE_ENABLE_PUNYCODE_FLAG</c> value. Setting the <c>CRYPT_ENCODE_ENABLE_PUNYCODE_FLAG</c> flag has different
	/// effects based on the structure type being encoded as specified by the value of the lpszStructType parameter.
	/// </para>
	/// <para>
	/// Each constant in the list below has an associated structure type that is pointed to by the pvStructInfo parameter. The structure
	/// pointed to, directly or indirectly, has a reference to a CERT_ALT_NAME_ENTRY structure.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ALTERNATE_NAME</term>
	/// </item>
	/// <item>
	/// <term>szOID_AUTHORITY_INFO_ACCESS</term>
	/// </item>
	/// <item>
	/// <term>X509_AUTHORITY_INFO_ACCESS</term>
	/// </item>
	/// <item>
	/// <term>X509_AUTHORITY_KEY_ID2</term>
	/// </item>
	/// <item>
	/// <term>szOID_AUTHORITY_KEY_IDENTIFIER2</term>
	/// </item>
	/// <item>
	/// <term>szOID_CRL_DIST_POINTS</term>
	/// </item>
	/// <item>
	/// <term>X509_CRL_DIST_POINTS</term>
	/// </item>
	/// <item>
	/// <term>szOID_CROSS_CERT_DIST_POINTS</term>
	/// </item>
	/// <item>
	/// <term>X509_CROSS_CERT_DIST_POINTS</term>
	/// </item>
	/// <item>
	/// <term>szOID_ISSUER_ALT_NAME</term>
	/// </item>
	/// <item>
	/// <term>szOID_ISSUER_ALT_NAME2</term>
	/// </item>
	/// <item>
	/// <term>szOID_ISSUING_DIST_POINT</term>
	/// </item>
	/// <item>
	/// <term>X509_ISSUING_DIST_POINT</term>
	/// </item>
	/// <item>
	/// <term>szOID_NAME_CONSTRAINTS</term>
	/// </item>
	/// <item>
	/// <term>X509_NAME_CONSTRAINTS</term>
	/// </item>
	/// <item>
	/// <term>szOID_NEXT_UPDATE_LOCATION</term>
	/// </item>
	/// <item>
	/// <term>OCSP_REQUEST</term>
	/// </item>
	/// <item>
	/// <term>zOID_SUBJECT_ALT_NAME</term>
	/// </item>
	/// <item>
	/// <term>szOID_SUBJECT_ALT_NAME2</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>CRYPT_ENCODE_ENABLE_PUNYCODE_FLAG</c> flag, in conjunction with the value of the <c>dwAltNameChoice</c> member of the
	/// CERT_ALT_NAME_ENTRY structure, determines the manner in which strings are encoded.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwAltNameChoice</term>
	/// <term>Effect</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_ALT_NAME_DNS_NAME</term>
	/// <term>
	/// If the host name contains Unicode characters outside of the ASCII character set, the host name is first encoded in Punycode and
	/// then encoded as an IA5String string.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_ALT_NAME_RFC822_NAME</term>
	/// <term>
	/// If the host name portion of the email address contains Unicode characters outside of the ASCII character set, the host name
	/// portion of the email address is encoded in Punycode. The resultant email address is then encoded as an IA5String string.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_ALT_NAME_URL</term>
	/// <term>
	/// If the server host name of the URI contains Unicode characters outside of the ASCII character set, then the host name portion of
	/// URI is encoded in Punycode. Then the resultant URI is escaped, and the URL is then encoded as an IA5String string.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Each constant in the list below has an associated structure type that is pointed to by the pvStructInfo parameter. The structure
	/// pointed to, directly or indirectly, has a reference to a CERT_HASHED_URL structure.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>szOID_BIOMETRIC_EXT</term>
	/// </item>
	/// <item>
	/// <term>X509_BIOMETRIC_EXT</term>
	/// </item>
	/// <item>
	/// <term>szOID_LOGOTYPE_EXT</term>
	/// </item>
	/// <item>
	/// <term>X509_LOGOTYPE_EXT</term>
	/// </item>
	/// </list>
	/// <para>
	/// When encoding the CERT_HASHED_URL structure value, if the server host name of the URI contains Unicode characters outside of the
	/// ASCII character set, and the <c>CRYPT_ENCODE_ENABLE_PUNYCODE_FLAG</c> is set, the host name portion of URI is encoded in
	/// Punycode. Then the resultant URI is escaped, and the URL is then encoded as an IA5String string.
	/// </para>
	/// <para>
	/// Each <c>X509_UNICODE_NAME</c> constant in the list below has an associated structure type that is pointed to by the pvStructInfo parameter.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_UNICODE_NAME</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the pszObjId member of the CERT_RDN_ATTR structure is set to <c>szOID_RSA_emailAddr</c> and the email address in the
	/// <c>Value</c> member contains Unicode characters outside of the ASCII character set, the host name portion of the email address
	/// is encoded in Punycode. Then the resultant email address is then encoded as an IA5String string.
	/// </para>
	/// <para>In all cases, the Punycode encoding of the host name is performed on a label-by-label basis.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows initializing and encoding an X509_NAME structure using <c>CryptEncodeObjectEx</c>. For an example
	/// that includes the complete context for this example, see Example C Program: ASN.1 Encoding and Decoding.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptencodeobjectex BOOL CryptEncodeObjectEx( DWORD
	// dwCertEncodingType, LPCSTR lpszStructType, const void *pvStructInfo, DWORD dwFlags, PCRYPT_ENCODE_PARA pEncodePara, void
	// *pvEncoded, DWORD *pcbEncoded );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "45134db8-059b-43d3-90c2-9b6cc970fca0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptEncodeObjectEx(CertEncodingType dwCertEncodingType, [In] SafeOID lpszStructType, [In] IntPtr pvStructInfo,
		CryptEncodeFlags dwFlags, in CRYPT_ENCODE_PARA pEncodePara, [Out] IntPtr pvEncoded, ref uint pcbEncoded);

	/// <summary>
	/// The <c>CRYPT_DECODE_PARA</c> structure is used by the CryptDecodeObjectEx function to provide access to memory allocation and
	/// memory freeing callback functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_decode_para typedef struct _CRYPT_DECODE_PARA {
	// DWORD cbSize; PFN_CRYPT_ALLOC pfnAlloc; PFN_CRYPT_FREE pfnFree; } CRYPT_DECODE_PARA, *PCRYPT_DECODE_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "08ed4627-8cbf-415f-b0d0-2c4b9ed9aed1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_DECODE_PARA
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>This member is an optional pointer to a callback function used to allocate memory.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PFN_CRYPT_ALLOC pfnAlloc;

		/// <summary>
		/// This member is an optional pointer to a callback function used to free memory allocated by the allocate callback function.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PFN_CRYPT_FREE pfnFree;

		/// <summary>Gets an instance which uses the CoTaskMem... methods for allocating and freeing memory.</summary>
		public static readonly CRYPT_DECODE_PARA CoTaskMemInstance = new() { cbSize = (uint)Marshal.SizeOf(typeof(CRYPT_DECODE_PARA)), pfnAlloc = s => Marshal.AllocCoTaskMem(s), pfnFree = Marshal.FreeCoTaskMem };
	}

	/// <summary>
	/// The <c>CRYPT_ENCODE_PARA</c> structure is used by the CryptEncodeObjectEx function to provide access to memory allocation and
	/// memory freeing callback functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_encode_para typedef struct _CRYPT_ENCODE_PARA {
	// DWORD cbSize; PFN_CRYPT_ALLOC pfnAlloc; PFN_CRYPT_FREE pfnFree; } CRYPT_ENCODE_PARA, *PCRYPT_ENCODE_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "330af6ac-f1db-4cee-81fd-d3c2c341d493")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_ENCODE_PARA
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>This member is an optional pointer to a callback function used to allocate memory.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PFN_CRYPT_ALLOC pfnAlloc;

		/// <summary>
		/// This member is an optional pointer to a callback function used to free memory allocated by the allocate callback function.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PFN_CRYPT_FREE pfnFree;

		/// <summary>Gets an instance which uses the CoTaskMem... methods for allocating and freeing memory.</summary>
		public static readonly CRYPT_ENCODE_PARA CoTaskMemInstance = new() { cbSize = (uint)Marshal.SizeOf(typeof(CRYPT_ENCODE_PARA)), pfnAlloc = s => Marshal.AllocCoTaskMem(s), pfnFree = Marshal.FreeCoTaskMem };
	}
}