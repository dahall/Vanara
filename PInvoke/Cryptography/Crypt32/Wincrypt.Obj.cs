using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
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

		/// <summary>Flags for CryptDecrypt.</summary>
		[PInvokeData("wincrypt.h", MSDNShortId = "7c3d2838-6fd1-4f6c-9586-8b94b459a31a")]
		[Flags]
		public enum CryptDecryptFlags
		{
			/// <summary>
			/// Use Optimal Asymmetric Encryption Padding (OAEP) (PKCS #1 version 2). This flag is only supported by the Microsoft Enhanced
			/// Cryptographic Provider with RSA encryption/decryption. This flag cannot be combined with the
			/// CRYPT_DECRYPT_RSA_NO_PADDING_CHECK flag.
			/// </summary>
			CRYPT_OAEP = 0x00000040,

			/// <summary>
			/// Perform the decryption on the BLOB without checking the padding. This flag is only supported by the Microsoft Enhanced
			/// Cryptographic Provider with RSA encryption/decryption. This flag cannot be combined with the CRYPT_OAEP flag.
			/// </summary>
			CRYPT_DECRYPT_RSA_NO_PADDING_CHECK = 0x00000020,
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

			/// <summary> This flag is applicable when encoding X509_UNICODE_NAME. If this flag is set and all the Unicode characters are <=
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

		/// <summary>Flags for CryptEncrypt.</summary>
		[PInvokeData("wincrypt.h", MSDNShortId = "697c4960-552b-4c3a-95cf-4632af56945b")]
		[Flags]
		public enum CryptEncryptFlags
		{
			/// <summary>
			/// Use Optimal Asymmetric Encryption Padding (OAEP) (PKCS #1 version 2). This flag is only supported by the Microsoft Enhanced
			/// Cryptographic Provider with RSA encryption/decryption. This flag cannot be combined with the
			/// CRYPT_DECRYPT_RSA_NO_PADDING_CHECK flag.
			/// </summary>
			CRYPT_OAEP = 0x00000040,
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
		public static extern bool CryptDecodeObject(CertEncodingType dwCertEncodingType, [MarshalAs(UnmanagedType.LPStr)] string lpszStructType, [In] IntPtr pbEncoded, uint cbEncoded,
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
		public static extern bool CryptDecodeObjectEx(CertEncodingType dwCertEncodingType, [MarshalAs(UnmanagedType.LPStr)] string lpszStructType, [In] IntPtr pbEncoded, uint cbEncoded,
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
		public static extern bool CryptDecodeObjectEx(CertEncodingType dwCertEncodingType, [MarshalAs(UnmanagedType.LPStr)] string lpszStructType, [In] IntPtr pbEncoded, uint cbEncoded,
			CryptDecodeFlags dwFlags, [In, Optional] IntPtr pDecodePara, [Out] IntPtr pvStructInfo, ref uint pcbStructInfo);

		/// <summary>
		/// Important changes to support Secure/Multipurpose Internet Mail Extensions (S/MIME) email interoperability have been made to
		/// CryptoAPI that affect the handling of enveloped messages. For more information, see the Remarks section of CryptMsgOpenToEncode.
		/// </summary>
		/// <param name="hKey">
		/// <para>
		/// A handle to the key to use for the decryption. An application obtains this handle by using either the CryptGenKey or
		/// CryptImportKey function.
		/// </para>
		/// <para>This key specifies the decryption algorithm to be used.</para>
		/// </param>
		/// <param name="hHash">
		/// <para>
		/// A handle to a hash object. If data is to be decrypted and hashed simultaneously, a handle to a hash object is passed in this
		/// parameter. The hash value is updated with the decrypted plaintext. This option is useful when simultaneously decrypting and
		/// verifying a signature.
		/// </para>
		/// <para>
		/// Before calling <c>CryptDecrypt</c>, the application must obtain a handle to the hash object by calling the CryptCreateHash
		/// function. After the decryption is complete, the hash value can be obtained by using the CryptGetHashParam function, it can also
		/// be signed by using the CryptSignHash function, or it can be used to verify a digital signature by using the CryptVerifySignature function.
		/// </para>
		/// <para>If no hash is to be done, this parameter must be zero.</para>
		/// </param>
		/// <param name="Final">
		/// A Boolean value that specifies whether this is the last section in a series being decrypted. This value is <c>TRUE</c> if this
		/// is the last or only block. If this is not the last block, this value is <c>FALSE</c>. For more information, see Remarks.
		/// </param>
		/// <param name="dwFlags">
		/// <para>The following flag values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_OAEP 0x00000040</term>
		/// <term>
		/// Use Optimal Asymmetric Encryption Padding (OAEP) (PKCS #1 version 2). This flag is only supported by the Microsoft Enhanced
		/// Cryptographic Provider with RSA encryption/decryption. This flag cannot be combined with the CRYPT_DECRYPT_RSA_NO_PADDING_CHECK flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPT_DECRYPT_RSA_NO_PADDING_CHECK 0x00000020</term>
		/// <term>
		/// Perform the decryption on the BLOB without checking the padding. This flag is only supported by the Microsoft Enhanced
		/// Cryptographic Provider with RSA encryption/decryption. This flag cannot be combined with the CRYPT_OAEP flag.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbData">
		/// <para>
		/// A pointer to a buffer that contains the data to be decrypted. After the decryption has been performed, the plaintext is placed
		/// back into this same buffer.
		/// </para>
		/// <para>The number of encrypted bytes in this buffer is specified by pdwDataLen.</para>
		/// </param>
		/// <param name="pdwDataLen">
		/// <para>
		/// A pointer to a <c>DWORD</c> value that indicates the length of the pbData buffer. Before calling this function, the calling
		/// application sets the <c>DWORD</c> value to the number of bytes to be decrypted. Upon return, the <c>DWORD</c> value contains the
		/// number of bytes of the decrypted plaintext.
		/// </para>
		/// <para>
		/// When a block cipher is used, this data length must be a multiple of the block size unless this is the final section of data to
		/// be decrypted and the Final parameter is <c>TRUE</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
		/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
		/// <para>The error codes prefaced by NTE are generated by the particular CSP being used. Some possible error codes follow.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>One of the parameters specifies a handle that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_ALGID</term>
		/// <term>The hKey session key specifies an algorithm that this CSP does not support.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_DATA</term>
		/// <term>
		/// The data to be decrypted is not valid. For example, when a block cipher is used and the Final flag is FALSE, the value specified
		/// by pdwDataLen must be a multiple of the block size. This error can also be returned when the padding is found to be not valid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter is nonzero.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_HASH</term>
		/// <term>The hHash parameter contains a handle that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_KEY</term>
		/// <term>The hKey parameter does not contain a valid handle to a key.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_LEN</term>
		/// <term>The size of the output buffer is too small to hold the generated plaintext.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_UID</term>
		/// <term>The CSP context that was specified when the key was created cannot be found.</term>
		/// </item>
		/// <item>
		/// <term>NTE_DOUBLE_ENCRYPT</term>
		/// <term>The application attempted to decrypt the same data twice.</term>
		/// </item>
		/// <item>
		/// <term>NTE_FAIL</term>
		/// <term>The function failed in some unexpected way.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If a large amount of data is to be decrypted, it can be done in sections by calling <c>CryptDecrypt</c> repeatedly. The Final
		/// parameter must be set to <c>TRUE</c> only on the last call to <c>CryptDecrypt</c>, so that the decryption engine can properly
		/// finish the decryption process. The following extra actions are performed when Final is <c>TRUE</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the key is a block cipher key, the data is padded to a multiple of the block size of the cipher. To find the block size of a
		/// cipher, use CryptGetKeyParam to get the KP_BLOCKLEN value of the key.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the cipher is operating in a chaining mode, the next <c>CryptDecrypt</c> operation resets the cipher's feedback register to
		/// the KP_IV value of the key.
		/// </term>
		/// </item>
		/// <item>
		/// <term>If the cipher is a stream cipher, the next <c>CryptDecrypt</c> call resets the cipher to its initial state.</term>
		/// </item>
		/// </list>
		/// <para>
		/// There is no way to set the cipher's feedback register to the KP_IV value of the key without setting the Final parameter to
		/// <c>TRUE</c>. If this is necessary, as in the case where you do not want to add an additional padding block or change the size of
		/// each block, you can simulate this by creating a duplicate of the original key by using the CryptDuplicateKey function, and
		/// passing the duplicate key to the <c>CryptDecrypt</c> function. This causes the KP_IV of the original key to be placed in the
		/// duplicate key. After you create or import the original key, you cannot use the original key for encryption because the feedback
		/// register of the key will be changed. The following pseudocode shows how this can be done.
		/// </para>
		/// <para>
		/// The Microsoft Enhanced Cryptographic Provider supports direct encryption with RSA public keys and decryption with RSA private
		/// keys. The encryption uses PKCS #1 padding. On decryption, this padding is verified. The length of ciphertext data to be
		/// decrypted must be the same length as the modulus of the RSA key used to decrypt the data. If the ciphertext has zeros in the
		/// most significant bytes, these bytes must be included in the input data buffer and in the input buffer length. The ciphertext
		/// must be in little-endian format.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Example C Program: Decrypting a File.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptdecrypt BOOL CryptDecrypt( HCRYPTKEY hKey,
		// HCRYPTHASH hHash, BOOL Final, DWORD dwFlags, BYTE *pbData, DWORD *pdwDataLen );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "7c3d2838-6fd1-4f6c-9586-8b94b459a31a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptDecrypt(HCRYPTKEY hKey, HCRYPTHASH hHash, [MarshalAs(UnmanagedType.Bool)] bool Final, CryptDecryptFlags dwFlags, [In, Out] IntPtr pbData, ref uint pdwDataLen);

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
		public static extern bool CryptEncodeObject(CertEncodingType dwCertEncodingType, [MarshalAs(UnmanagedType.LPStr)] string lpszStructType, [In] IntPtr pvStructInfo, [Out] IntPtr pbEncoded, ref uint pcbEncoded);

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
		public static extern bool CryptEncodeObjectEx(CertEncodingType dwCertEncodingType, [MarshalAs(UnmanagedType.LPStr)] string lpszStructType, [In] IntPtr pvStructInfo,
			CryptEncodeFlags dwFlags, in CRYPT_ENCODE_PARA pEncodePara, [Out] IntPtr pvEncoded, ref uint pcbEncoded);

		/// <summary>
		/// <para>
		/// Important changes to support Secure/Multipurpose Internet Mail Extensions (S/MIME) email interoperability have been made to
		/// CryptoAPI that affect the handling of enveloped messages. For more information, see the Remarks section of CryptMsgOpenToEncode.
		/// </para>
		/// <para>
		/// <c>Important</c> The <c>CryptEncrypt</c> function is not guaranteed to be thread safe and may return incorrect results if
		/// invoked simultaneously by multiple callers.
		/// </para>
		/// </summary>
		/// <param name="hKey">
		/// <para>
		/// A handle to the encryption key. An application obtains this handle by using either the CryptGenKey or the CryptImportKey function.
		/// </para>
		/// <para>The key specifies the encryption algorithm used.</para>
		/// </param>
		/// <param name="hHash">
		/// <para>
		/// A handle to a hash object. If data is to be hashed and encrypted simultaneously, a handle to a hash object can be passed in the
		/// hHash parameter. The hash value is updated with the plaintext passed in. This option is useful when generating signed and
		/// encrypted text.
		/// </para>
		/// <para>
		/// Before calling <c>CryptEncrypt</c>, the application must obtain a handle to the hash object by calling the CryptCreateHash
		/// function. After the encryption is complete, the hash value can be obtained by using the CryptGetHashParam function, or the hash
		/// can be signed by using the CryptSignHash function.
		/// </para>
		/// <para>If no hash is to be done, this parameter must be <c>NULL</c>.</para>
		/// </param>
		/// <param name="Final">
		/// A Boolean value that specifies whether this is the last section in a series being encrypted. Final is set to <c>TRUE</c> for the
		/// last or only block and to <c>FALSE</c> if there are more blocks to be encrypted. For more information, see Remarks.
		/// </param>
		/// <param name="dwFlags">
		/// <para>The following dwFlags value is defined but reserved for future use.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_OAEP</term>
		/// <term>
		/// Use Optimal Asymmetric Encryption Padding (OAEP) (PKCS #1 version 2). This flag is only supported by the Microsoft Enhanced
		/// Cryptographic Provider with RSA encryption/decryption.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbData">
		/// <para>
		/// A pointer to a buffer that contains the plaintext to be encrypted. The plaintext in this buffer is overwritten with the
		/// ciphertext created by this function.
		/// </para>
		/// <para>
		/// The pdwDataLen parameter points to a variable that contains the length, in bytes, of the plaintext. The dwBufLen parameter
		/// contains the total size, in bytes, of this buffer.
		/// </para>
		/// <para>
		/// If this parameter contains <c>NULL</c>, this function will calculate the required size for the ciphertext and place that in the
		/// value pointed to by the pdwDataLen parameter.
		/// </para>
		/// </param>
		/// <param name="pdwDataLen">
		/// <para>
		/// A pointer to a <c>DWORD</c> value that , on entry, contains the length, in bytes, of the plaintext in the pbData buffer. On
		/// exit, this <c>DWORD</c> contains the length, in bytes, of the ciphertext written to the pbData buffer.
		/// </para>
		/// <para>
		/// If the buffer allocated for pbData is not large enough to hold the encrypted data, GetLastError returns <c>ERROR_MORE_DATA</c>
		/// and stores the required buffer size, in bytes, in the <c>DWORD</c> value pointed to by pdwDataLen.
		/// </para>
		/// <para>
		/// If pbData is <c>NULL</c>, no error is returned, and the function stores the size of the encrypted data, in bytes, in the
		/// <c>DWORD</c> value pointed to by pdwDataLen. This allows an application to determine the correct buffer size.
		/// </para>
		/// <para>
		/// When a block cipher is used, this data length must be a multiple of the block size unless this is the final section of data to
		/// be encrypted and the Final parameter is <c>TRUE</c>.
		/// </para>
		/// </param>
		/// <param name="dwBufLen">
		/// <para>Specifies the total size, in bytes, of the input pbData buffer.</para>
		/// <para>
		/// Note that, depending on the algorithm used, the encrypted text can be larger than the original plaintext. In this case, the
		/// pbData buffer needs to be large enough to contain the encrypted text and any padding.
		/// </para>
		/// <para>
		/// As a rule, if a stream cipher is used, the ciphertext is the same size as the plaintext. If a block cipher is used, the
		/// ciphertext is up to a block length larger than the plaintext.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
		/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
		/// <para>The error codes prefaced by NTE are generated by the particular CSP being used. Some possible error codes follow.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>One of the parameters specifies a handle that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_ALGID</term>
		/// <term>The hKey session key specifies an algorithm that this CSP does not support.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_DATA</term>
		/// <term>
		/// The data to be encrypted is not valid. For example, when a block cipher is used and the Final flag is FALSE, the value specified
		/// by pdwDataLen must be a multiple of the block size.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter is nonzero.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_HASH</term>
		/// <term>The hHash parameter contains a handle that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_HASH_STATE</term>
		/// <term>An attempt was made to add data to a hash object that is already marked "finished."</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_KEY</term>
		/// <term>The hKey parameter does not contain a valid handle to a key.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_LEN</term>
		/// <term>The size of the output buffer is too small to hold the generated ciphertext.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_UID</term>
		/// <term>The CSP context that was specified when the key was created cannot be found.</term>
		/// </item>
		/// <item>
		/// <term>NTE_DOUBLE_ENCRYPT</term>
		/// <term>The application attempted to encrypt the same data twice.</term>
		/// </item>
		/// <item>
		/// <term>NTE_FAIL</term>
		/// <term>The function failed in some unexpected way.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>The CSP ran out of memory during the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If a large amount of data is to be encrypted, it can be done in sections by calling <c>CryptEncrypt</c> repeatedly. The Final
		/// parameter must be set to <c>TRUE</c> on the last call to <c>CryptEncrypt</c>, so that the encryption engine can properly finish
		/// the encryption process. The following extra actions are performed when Final is <c>TRUE</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the key is a block cipher key, the data is padded to a multiple of the block size of the cipher. If the data length equals
		/// the block size of the cipher, one additional block of padding is appended to the data. To find the block size of a cipher, use
		/// CryptGetKeyParam to get the KP_BLOCKLEN value of the key.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the cipher is operating in a chaining mode, the next <c>CryptEncrypt</c> operation resets the cipher's feedback register to
		/// the KP_IV value of the key.
		/// </term>
		/// </item>
		/// <item>
		/// <term>If the cipher is a stream cipher, the next <c>CryptEncrypt</c> resets the cipher to its initial state.</term>
		/// </item>
		/// </list>
		/// <para>
		/// There is no way to set the cipher's feedback register to the KP_IV value of the key without setting the Final parameter to
		/// <c>TRUE</c>. If this is necessary, as in the case where you do not want to add an additional padding block or change the size of
		/// each block, you can simulate this by creating a duplicate of the original key by using the CryptDuplicateKey function, and
		/// passing the duplicate key to the <c>CryptEncrypt</c> function. This causes the KP_IV of the original key to be placed in the
		/// duplicate key. After you create or import the original key, you cannot use the original key for encryption because the feedback
		/// register of the key will be changed. The following pseudocode shows how this can be done.
		/// </para>
		/// <para>
		/// The Microsoft Enhanced Cryptographic Provider supports direct encryption with RSA public keys and decryption with RSA private
		/// keys. The encryption uses PKCS #1 padding. On decryption, this padding is verified. The length of plaintext data that can be
		/// encrypted with a call to <c>CryptEncrypt</c> with an RSA key is the length of the key modulus minus eleven bytes. The eleven
		/// bytes is the chosen minimum for PKCS #1 padding. The ciphertext is returned in little-endian format.
		/// </para>
		/// <para>Examples</para>
		/// <para>For examples that use this function, see Example C Program: Encrypting a File and Example C Program: Decrypting a File.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptencrypt BOOL CryptEncrypt( HCRYPTKEY hKey,
		// HCRYPTHASH hHash, BOOL Final, DWORD dwFlags, BYTE *pbData, DWORD *pdwDataLen, DWORD dwBufLen );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "697c4960-552b-4c3a-95cf-4632af56945b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptEncrypt(HCRYPTKEY hKey, HCRYPTHASH hHash, [MarshalAs(UnmanagedType.Bool)] bool Final, CryptEncryptFlags dwFlags, [In, Out] IntPtr pbData, ref uint pdwDataLen, uint dwBufLen);

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
			public static readonly CRYPT_DECODE_PARA CoTaskMemInstance = new CRYPT_DECODE_PARA { cbSize = (uint)Marshal.SizeOf(typeof(CRYPT_DECODE_PARA)), pfnAlloc = s => Marshal.AllocCoTaskMem(s), pfnFree = Marshal.FreeCoTaskMem };
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
			public static readonly CRYPT_ENCODE_PARA CoTaskMemInstance = new CRYPT_ENCODE_PARA { cbSize = (uint)Marshal.SizeOf(typeof(CRYPT_ENCODE_PARA)), pfnAlloc = s => Marshal.AllocCoTaskMem(s), pfnFree = Marshal.FreeCoTaskMem };
		}
	}
}