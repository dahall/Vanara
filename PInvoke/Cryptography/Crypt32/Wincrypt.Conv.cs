namespace Vanara.PInvoke;

/// <summary>Methods and data types found in Crypt32.dll.</summary>
public static partial class Crypt32
{
	/// <summary>Indicates the type of processing needed.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "300e6345-0be0-48c7-a3a3-174879cf0bbb")]
	[Flags]
	public enum CertNameFlags
	{
		/// <summary>Acquires the issuer's name. If not set, acquires the subject's name.</summary>
		CERT_NAME_ISSUER_FLAG = 0x1,

		/// <summary>Skips the default initial attempt to decode the value as UTF8 and decodes as 8-bit characters.</summary>
		CERT_NAME_DISABLE_IE4_UTF8_FLAG = 0x00010000,

		/// <summary>
		/// If the dwType parameter is set to CERT_NAME_DNS_TYPE, all applicable names are returned for the specified DNS value. If
		/// there is no DNS name but there is a CN component in the subject, the CN is returned instead. If there is a CN and a DNS
		/// name, only the DNS names are returned. This mimics the SSL chain building policy. If you set this flag for a name type other
		/// than CERT_NAME_DNS_TYPE, this function returns a null-terminated empty string.
		/// <para>Windows 8 and Windows Server 2012: Support for this flag begins.</para>
		/// </summary>
		CERT_NAME_SEARCH_ALL_NAMES_FLAG = 0x2,

		/// <summary>
		/// This flag enables decoding of IA5String strings to Unicode string values based on the dwType parameter value as defined below:
		/// <para>
		/// CERT_NAME_EMAIL_TYPE: If the host name portion of the email address contains a Punycode encoded IA5String component, it is
		///                       converted to the Unicode equivalent.
		/// </para>
		/// <para>
		/// CERT_NAME_SIMPLE_DISPLAY_TYPE: If a Subject Name of szOID_RSA_emailAddr or the rfc822Name from the Subject Alternative Name
		///                                is returned from the certificate, and the host name portion of the email address a contains
		///                                Punycode encoded IA5String component, it is converted to the Unicode equivalent.
		/// </para>
		/// <para>
		/// CERT_NAME_DNS_TYPE: If the certificate has an Issuer Alternative Name, with a DNSName choice, and the host name portion of
		///                     the email address a contains Punycode encoded IA5String component, it is converted to the Unicode equivalent.
		/// </para>
		/// <para>
		/// CERT_NAME_URL_TYPE: The URI is decoded and unescaped. If the server host name of the URI contains a Punycode encoded
		///                     IA5String component, the host name string is converted to the Unicode equivalent.
		/// </para>
		/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		CERT_NAME_STR_ENABLE_PUNYCODE_FLAG = 0x00200000,
	}

	/// <summary>Specifies the format of the output string and other options for the contents of the string.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "b3d96de8-5cbc-4ccb-b759-6757520bbda3")]
	[Flags]
	public enum CertNameStringFormat
	{
		/// <summary>
		/// All object identifiers (OIDs) are discarded. CERT_RDN entries are separated by a comma followed by a space (, ). Multiple
		/// attributes in a CERT_RDN are separated by a plus sign enclosed within spaces ( + ), for example, Microsoft, Kim Abercrombie
		/// + Programmer.
		/// </summary>
		CERT_SIMPLE_NAME_STR = 1,

		/// <summary>
		/// OIDs are included with an equal sign (=) separator from their attribute value. CERT_RDN entries are separated by a comma
		/// followed by a space (, ). Multiple attributes in a CERT_RDN are separated by a plus sign followed by a space (+ ).
		/// </summary>
		CERT_OID_NAME_STR = 2,

		/// <summary>
		/// OIDs are converted to their X.500 key names; otherwise, they are the same as <strong>CERT_OID_NAME_STR</strong>. If an OID
		/// does not have a corresponding X.500 name, the OID is used with a prefix of OID.
		/// <para>The RDN value is quoted if it contains leading or trailing white space or one of the following characters:</para>
		/// <list type="bullet">
		/// <item>Comma (,)</item>
		/// <item>Plus sign (+)</item>
		/// <item>Equal sign (=)</item>
		/// <item>Inch mark (")</item>
		/// <item>Backslash followed by the letter n (\n)</item>
		/// <item>Less than sign (&lt;)</item>
		/// <item>Greater than sign (&gt;)</item>
		/// <item>Number sign (#)</item>
		/// <item>Semicolon (;)</item>
		/// </list>
		/// <para>
		/// The quotation character is an inch mark ("). If the RDN value contains an inch mark, it is enclosed within quotation marks ("").
		/// </para>
		/// </summary>
		CERT_X500_NAME_STR = 3,

		/// <summary>Replace the comma followed by a space (, ) separator with a semicolon followed by a space (; ) separator.</summary>
		CERT_NAME_STR_SEMICOLON_FLAG = 0x40000000,

		/// <summary>
		/// Replace the comma followed by a space (, ) separator with a backslash followed by the letter r followed by a backslash
		/// followed by the letter n (\r\n) separator.
		/// </summary>
		CERT_NAME_STR_CRLF_FLAG = 0x08000000,

		/// <summary>Replace the plus sign enclosed within spaces ( + ) separator with a single space separator.</summary>
		CERT_NAME_STR_NO_PLUS_FLAG = 0x20000000,

		/// <summary>Disable quoting.</summary>
		CERT_NAME_STR_NO_QUOTING_FLAG = 0x10000000,

		/// <summary>The order of the RDNs in the distinguished name string is reversed after decoding. This flag is not set by default.</summary>
		CERT_NAME_STR_REVERSE_FLAG = 0x02000000,

		/// <summary>
		/// By default, a CERT_RDN_T61_STRING X.500 key string is decoded as UTF8. If UTF8 decoding fails, the X.500 key is decoded as
		/// an 8 bit character. Use CERT_NAME_STR_DISABLE_IE4_UTF8_FLAG to skip the initial attempt to decode as UTF8.
		/// </summary>
		CERT_NAME_STR_DISABLE_IE4_UTF8_FLAG = 0x00010000,

		/// <summary>
		/// If the name pointed to by the pName parameter contains an email RDN, and the host name portion of the email address contains
		/// a Punycode encoded IA5String, the name is converted to the Unicode equivalent.
		/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		CERT_NAME_STR_ENABLE_PUNYCODE_FLAG = 0x00200000,
	}

	/// <summary>Indicating how the name is to be found and how the output is to be formatted.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "300e6345-0be0-48c7-a3a3-174879cf0bbb")]
	public enum CertNameType
	{
		/// <summary>
		/// If the certificate has a Subject Alternative Name extension or Issuer Alternative Name, uses the first rfc822Name choice. If
		/// no rfc822Name choice is found in the extension, uses the Subject Name field for the Email OID. If either rfc822Name or the
		/// Email OID is found, uses the string. Otherwise, returns an empty string (returned character count is 1). pvTypePara is not
		/// used and is set to NULL.
		/// </summary>
		CERT_NAME_EMAIL_TYPE = 1,

		/// <summary>
		/// Converts the Subject Name BLOB by calling CertNameToStr. pvTypePara points to a DWORD containing the dwStrType passed to
		/// CertNameToStr. If the Subject Name field is empty and the certificate has a Subject Alternative Name extension, uses the
		/// first directory Name choice from CertNameToStr.
		/// </summary>
		CERT_NAME_RDN_TYPE = 2,

		/// <summary>
		/// pvTypePara points to an object identifier (OID) specifying the name attribute to be returned. For example, if pvTypePara is
		/// szOID_COMMON_NAME, uses the Subject Name member. If the Subject Name member is empty and the certificate has a Subject
		/// Alternative Name extension, uses the first directoryName choice.
		/// </summary>
		CERT_NAME_ATTR_TYPE = 3,

		/// <summary>
		/// Iterates through the following list of name attributes and uses the Subject Name or the Subject Alternative Name extension
		/// for the first occurrence of: szOID_COMMON_NAME, szOID_ORGANIZATIONAL_UNIT_NAME, szOID_ORGANIZATION_NAME, or szOID_RSA_emailAddr.
		/// <para>
		/// If one of these attributes is not found, uses the Subject Alternative Name extension for a rfc822Name choice. If there is
		/// still no match, uses the first attribute.
		/// </para>
		/// <para>pvTypePara is not used and is set to NULL.</para>
		/// </summary>
		CERT_NAME_SIMPLE_DISPLAY_TYPE = 4,

		/// <summary>
		/// Checks the certificate for a CERT_FRIENDLY_NAME_PROP_ID property. If the certificate has this property, it is returned. If
		/// the certificate does not have the property, the CERT_NAME_SIMPLE_DISPLAY_TYPE is returned.
		/// </summary>
		CERT_NAME_FRIENDLY_DISPLAY_TYPE = 5,

		/// <summary>
		/// If the certificate has a Subject Alternative Name extension for issuer, Issuer Alternative Name, search for first DNSName choice.
		/// <para>If the DNSName choice is not found in the extension, search the Subject Name field for the CN OID, "2.5.4.3".</para>
		/// <para>If the DNSName or CN OID is found, return the string. Otherwise, return an empty string.</para>
		/// </summary>
		CERT_NAME_DNS_TYPE = 6,

		/// <summary>
		/// If the certificate has a Subject Alternative Name extension for issuer, Issuer Alternative Name, search for first URL
		/// choice. If the URL choice is found, return the string. Otherwise, return an empty string.
		/// </summary>
		CERT_NAME_URL_TYPE = 7,

		/// <summary>
		/// If the certificate has a Subject Alternative Name extension, search the OtherName choices looking for a pszObjId ==
		/// szOID_NT_PRINCIPAL_NAME, ("1.3.6.1.4.1.311.20.2.3").
		/// <para>
		/// If the UPN OID is found, decode the BLOB as a X509_UNICODE_ANY_STRING and return the decoded string. Otherwise, return an
		/// empty string.
		/// </para>
		/// </summary>
		CERT_NAME_UPN_TYPE = 8,
	}

	/// <summary>Indicates the kind of RDN value to be converted.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "c1e0af19-320e-411e-85bf-c7f01befcac4")]
	public enum CertRDNType
	{
		/// <summary/>
		CERT_RDN_ANY_TYPE = 0,

		/// <summary/>
		CERT_RDN_ENCODED_BLOB = 1,

		/// <summary/>
		CERT_RDN_OCTET_STRING = 2,

		/// <summary/>
		CERT_RDN_NUMERIC_STRING = 3,

		/// <summary/>
		CERT_RDN_PRINTABLE_STRING = 4,

		/// <summary/>
		CERT_RDN_TELETEX_STRING = 5,

		/// <summary/>
		CERT_RDN_T61_STRING = 5,

		/// <summary/>
		CERT_RDN_VIDEOTEX_STRING = 6,

		/// <summary/>
		CERT_RDN_IA5_STRING = 7,

		/// <summary/>
		CERT_RDN_GRAPHIC_STRING = 8,

		/// <summary/>
		CERT_RDN_VISIBLE_STRING = 9,

		/// <summary/>
		CERT_RDN_ISO646_STRING = 9,

		/// <summary/>
		CERT_RDN_GENERAL_STRING = 10,

		/// <summary/>
		CERT_RDN_UNIVERSAL_STRING = 11,

		/// <summary/>
		CERT_RDN_INT4_STRING = 11,

		/// <summary/>
		CERT_RDN_BMP_STRING = 12,

		/// <summary/>
		CERT_RDN_UNICODE_STRING = 12,

		/// <summary/>
		CERT_RDN_UTF8_STRING = 13,
	}

	/// <summary>Structure format type values.</summary>
	[Flags]
	[PInvokeData("wincrypt.h", MSDNShortId = "307e0bd5-b8a6-4d85-9775-65aae99e8dc6")]
	public enum CryptFormatStr
	{
		/// <summary>
		/// Display the data in a single line. Each subfield is concatenated with a comma (,). For more information, see Remarks.
		/// </summary>
		CRYPT_FORMAT_STR_SINGLE_LINE = 0,

		/// <summary>Display the data in multiple lines rather than single line (the default). For more information, see Remarks.</summary>
		CRYPT_FORMAT_STR_MULTI_LINE = 0x0001,

		/// <summary>Disables the hexadecimal dump. For more information, see Remarks.</summary>
		CRYPT_FORMAT_STR_NO_HEX = 0x0010,
	}

	/// <summary>Specifies the format of the resulting formatted string.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "e6bdf931-fba3-4a33-b22e-5f818f565842")]
	public enum CryptStringFormat : uint
	{
		/// <summary>Base64, with certificate beginning and ending headers.</summary>
		CRYPT_STRING_BASE64HEADER = 0x00000000,

		/// <summary>Base64, without headers.</summary>
		CRYPT_STRING_BASE64 = 0x00000001,

		/// <summary>Pure binary copy.</summary>
		CRYPT_STRING_BINARY = 0x00000002,

		/// <summary>Base64, with request beginning and ending headers.</summary>
		CRYPT_STRING_BASE64REQUESTHEADER = 0x00000003,

		/// <summary>Hexadecimal only.</summary>
		CRYPT_STRING_HEX = 0x00000004,

		/// <summary>Hexadecimal, with ASCII character display.</summary>
		CRYPT_STRING_HEXASCII = 0x00000005,

		/// <summary>Base64, with X.509 CRL beginning and ending headers.</summary>
		CRYPT_STRING_BASE64X509CRLHEADER = 0x00000009,

		/// <summary>Hexadecimal, with address display.</summary>
		CRYPT_STRING_HEXADDR = 0x0000000a,

		/// <summary>Hexadecimal, with ASCII character and address display.</summary>
		CRYPT_STRING_HEXASCIIADDR = 0x0000000b,

		/// <summary>
		/// A raw hexadecimal string.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		CRYPT_STRING_HEXRAW = 0x0000000c,

		/// <summary>
		/// Enforce strict decoding of ASN.1 text formats. Some ASN.1 binary BLOBS can have the first few bytes of the BLOB incorrectly
		/// interpreted as Base64 text. In this case, the rest of the text is ignored. Use this flag to enforce complete decoding of the BLOB.
		/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		CRYPT_STRING_STRICT = 0x20000000,

		/// <summary>
		/// Do not append any new line characters to the encoded string. The default behavior is to use a carriage return/line feed
		/// (CR/LF) pair (0x0D/0x0A) to represent a new line.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		CRYPT_STRING_NOCRLF = 0x40000000,

		/// <summary>
		/// Only use the line feed (LF) character (0x0A) for a new line. The default behavior is to use a CR/LF pair (0x0D/0x0A) to
		/// represent a new line.
		/// </summary>
		CRYPT_STRING_NOCR = 0x80000000,

		/// <summary>Tries the following, in order: CRYPT_STRING_BASE64HEADER, CRYPT_STRING_BASE64</summary>
		CRYPT_STRING_BASE64_ANY = 0x00000006,

		/// <summary>Tries the following, in order: CRYPT_STRING_BASE64HEADER, CRYPT_STRING_BASE64, CRYPT_STRING_BINARY</summary>
		CRYPT_STRING_ANY = 0x00000007,

		/// <summary>
		/// Tries the following, in order: CRYPT_STRING_HEXADDR, CRYPT_STRING_HEXASCIIADDR, CRYPT_STRING_HEX, CRYPT_STRING_HEXRAW, CRYPT_STRING_HEXASCII
		/// </summary>
		CRYPT_STRING_HEX_ANY = 0x00000008,

		/// <summary/>
		CRYPT_STRING_BASE64URI = 0x0000000d,

		/// <summary/>
		CRYPT_STRING_ENCODEMASK = 0x000000ff,

		/// <summary/>
		CRYPT_STRING_RESERVED100 = 0x00000100,

		/// <summary/>
		CRYPT_STRING_RESERVED200 = 0x00000200,

		/// <summary/>
		CRYPT_STRING_PERCENTESCAPE = 0x08000000,

		/// <summary/>
		CRYPT_STRING_HASHDATA = 0x10000000,
	}

	/// <summary>
	/// <para>
	/// Use the CryptFindOIDInfo function instead of this function because ALG_ID identifiers are no longer supported in CNG. Use the
	/// <c>CRYPT_OID_INFO_CNG_ALGID_KEY</c> value in the dwKeyType parameter of the CryptFindOIDInfo function instead.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> The <c>CertAlgIdToOID</c> function converts a CryptoAPI algorithm identifier (ALG_ID)
	/// to an Abstract Syntax Notation One (ASN.1) object identifier (OID) string.
	/// </para>
	/// </summary>
	/// <param name="dwAlgId">Value to be converted to an OID.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns the null-terminated OID string.</para>
	/// <para>If no OID string corresponds to the algorithm identifier, the function returns <c>NULL</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certalgidtooid LPCSTR CertAlgIdToOID( DWORD dwAlgId );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "2a66c6da-22dd-4192-9f3d-2fb85f8032e0")]
	public static extern PSTR CertAlgIdToOID(uint dwAlgId);

	/// <summary>
	/// The <c>CertGetNameString</c> function obtains the subject or issuer name from a certificate CERT_CONTEXT structure and converts
	/// it to a <c>null</c>-terminated character string.
	/// </summary>
	/// <param name="pCertContext">A pointer to a CERT_CONTEXT certificate context that includes a subject and issuer name to be converted.</param>
	/// <param name="dwType">
	/// <para><c>DWORD</c> indicating how the name is to be found and how the output is to be formatted.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_NAME_EMAIL_TYPE 1</term>
	/// <term>
	/// If the certificate has a Subject Alternative Name extension or Issuer Alternative Name, uses the first rfc822Name choice. If no
	/// rfc822Name choice is found in the extension, uses the Subject Name field for the Email OID. If either rfc822Name or the Email
	/// OID is found, uses the string. Otherwise, returns an empty string (returned character count is 1). pvTypePara is not used and is
	/// set to NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_RDN_TYPE 2</term>
	/// <term>
	/// Converts the Subject Name BLOB by calling CertNameToStr. pvTypePara points to a DWORD containing the dwStrType passed to
	/// CertNameToStr. If the Subject Name field is empty and the certificate has a Subject Alternative Name extension, uses the first
	/// directory Name choice from CertNameToStr.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_ATTR_TYPE 3</term>
	/// <term>
	/// pvTypePara points to an object identifier (OID) specifying the name attribute to be returned. For example, if pvTypePara is
	/// szOID_COMMON_NAME, uses the Subject Name member. If the Subject Name member is empty and the certificate has a Subject
	/// Alternative Name extension, uses the first directoryName choice.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_SIMPLE_DISPLAY_TYPE 4</term>
	/// <term>
	/// Iterates through the following list of name attributes and uses the Subject Name or the Subject Alternative Name extension for
	/// the first occurrence of: szOID_COMMON_NAME, szOID_ORGANIZATIONAL_UNIT_NAME, szOID_ORGANIZATION_NAME, or szOID_RSA_emailAddr. If
	/// one of these attributes is not found, uses the Subject Alternative Name extension for a rfc822Name choice. If there is still no
	/// match, uses the first attribute. pvTypePara is not used and is set to NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_FRIENDLY_DISPLAY_TYPE 5</term>
	/// <term>
	/// Checks the certificate for a CERT_FRIENDLY_NAME_PROP_ID property. If the certificate has this property, it is returned. If the
	/// certificate does not have the property, the CERT_NAME_SIMPLE_DISPLAY_TYPE is returned.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_DNS_TYPE 6</term>
	/// <term>
	/// If the certificate has a Subject Alternative Name extension for issuer, Issuer Alternative Name, search for first DNSName
	/// choice. If the DNSName choice is not found in the extension, search the Subject Name field for the CN OID, "2.5.4.3". If the
	/// DNSName or CN OID is found, return the string. Otherwise, return an empty string.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_URL_TYPE 7</term>
	/// <term>
	/// If the certificate has a Subject Alternative Name extension for issuer, Issuer Alternative Name, search for first URL choice. If
	/// the URL choice is found, return the string. Otherwise, return an empty string.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_UPN_TYPE 8</term>
	/// <term>
	/// If the certificate has a Subject Alternative Name extension, search the OtherName choices looking for a pszObjId ==
	/// szOID_NT_PRINCIPAL_NAME, ("1.3.6.1.4.1.311.20.2.3"). If the UPN OID is found, decode the BLOB as a X509_UNICODE_ANY_STRING and
	/// return the decoded string. Otherwise, return an empty string.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Indicates the type of processing needed.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_NAME_ISSUER_FLAG 0x1</term>
	/// <term>Acquires the issuer's name. If not set, acquires the subject's name.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_DISABLE_IE4_UTF8_FLAG 0x00010000</term>
	/// <term>Skips the default initial attempt to decode the value as UTF8 and decodes as 8-bit characters.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_SEARCH_ALL_NAMES_FLAG 0x2</term>
	/// <term>
	/// If the dwType parameter is set to CERT_NAME_DNS_TYPE, all applicable names are returned for the specified DNS value. If there is
	/// no DNS name but there is a CN component in the subject, the CN is returned instead. If there is a CN and a DNS name, only the
	/// DNS names are returned. This mimics the SSL chain building policy. If you set this flag for a name type other than
	/// CERT_NAME_DNS_TYPE, this function returns a null-terminated empty string. Windows 8 and Windows Server 2012: Support for this
	/// flag begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_ENABLE_PUNYCODE_FLAG 0x00200000</term>
	/// <term>
	/// This flag enables decoding of IA5String strings to Unicode string values based on the dwType parameter value as defined below:
	/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvTypePara">
	/// A pointer to either a <c>DWORD</c> containing the dwStrType or an object identifier (OID) specifying the name attribute. The
	/// type pointed to is determined by the value of dwType.
	/// </param>
	/// <param name="pszNameString">
	/// <para>
	/// A pointer to an allocated buffer to receive the returned string. If pszNameString is not <c>NULL</c> and cchNameString is not
	/// zero, pszNameString is a <c>null</c>-terminated string.
	/// </para>
	/// <para>
	/// If <c>CERT_NAME_SEARCH_ALL_NAMES_FLAG</c> is specified in the dwFlags parameter and <c>CERT_NAME_DNS_TYPE</c> is set in the
	/// dwType parameter, the returned string will contain all of the DNS names that apply. Each string in the output string is
	/// null-terminated and the last string will be double null-terminated. If no DNS names are found, a single null-terminated empty
	/// string is returned.
	/// </para>
	/// </param>
	/// <param name="cchNameString">
	/// Size, in characters, allocated for the returned string. The size must include the terminating <c>NULL</c> character.
	/// </param>
	/// <returns>
	/// Returns the number of characters converted, including the terminating zero character. If pszNameString is <c>NULL</c> or
	/// cchNameString is zero, returns the required size of the destination string (including the terminating <c>NULL</c> character). If
	/// the specified name type is not found, returns a <c>null</c>-terminated empty string with a returned character count of 1.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetnamestringa DWORD CertGetNameStringA(
	// PCCERT_CONTEXT pCertContext, DWORD dwType, DWORD dwFlags, void *pvTypePara, PSTR pszNameString, DWORD cchNameString );
	[DllImport(Lib.Crypt32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "300e6345-0be0-48c7-a3a3-174879cf0bbb")]
	public static extern uint CertGetNameString(PCCERT_CONTEXT pCertContext, CertNameType dwType, CertNameFlags dwFlags, [In] SafeOID pvTypePara,
		[Out, MarshalAs(UnmanagedType.LPTStr), SizeDef(nameof(cchNameString), SizingMethod.QueryResultInReturn | SizingMethod.InclNullTerm)] StringBuilder? pszNameString, uint cchNameString);

	/// <summary>
	/// The <c>CertGetNameString</c> function obtains the subject or issuer name from a certificate CERT_CONTEXT structure and converts
	/// it to a <c>null</c>-terminated character string.
	/// </summary>
	/// <param name="pCertContext">A pointer to a CERT_CONTEXT certificate context that includes a subject and issuer name to be converted.</param>
	/// <param name="dwType">
	/// <para><c>DWORD</c> indicating how the name is to be found and how the output is to be formatted.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_NAME_EMAIL_TYPE 1</term>
	/// <term>
	/// If the certificate has a Subject Alternative Name extension or Issuer Alternative Name, uses the first rfc822Name choice. If no
	/// rfc822Name choice is found in the extension, uses the Subject Name field for the Email OID. If either rfc822Name or the Email
	/// OID is found, uses the string. Otherwise, returns an empty string (returned character count is 1). pvTypePara is not used and is
	/// set to NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_RDN_TYPE 2</term>
	/// <term>
	/// Converts the Subject Name BLOB by calling CertNameToStr. pvTypePara points to a DWORD containing the dwStrType passed to
	/// CertNameToStr. If the Subject Name field is empty and the certificate has a Subject Alternative Name extension, uses the first
	/// directory Name choice from CertNameToStr.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_ATTR_TYPE 3</term>
	/// <term>
	/// pvTypePara points to an object identifier (OID) specifying the name attribute to be returned. For example, if pvTypePara is
	/// szOID_COMMON_NAME, uses the Subject Name member. If the Subject Name member is empty and the certificate has a Subject
	/// Alternative Name extension, uses the first directoryName choice.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_SIMPLE_DISPLAY_TYPE 4</term>
	/// <term>
	/// Iterates through the following list of name attributes and uses the Subject Name or the Subject Alternative Name extension for
	/// the first occurrence of: szOID_COMMON_NAME, szOID_ORGANIZATIONAL_UNIT_NAME, szOID_ORGANIZATION_NAME, or szOID_RSA_emailAddr. If
	/// one of these attributes is not found, uses the Subject Alternative Name extension for a rfc822Name choice. If there is still no
	/// match, uses the first attribute. pvTypePara is not used and is set to NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_FRIENDLY_DISPLAY_TYPE 5</term>
	/// <term>
	/// Checks the certificate for a CERT_FRIENDLY_NAME_PROP_ID property. If the certificate has this property, it is returned. If the
	/// certificate does not have the property, the CERT_NAME_SIMPLE_DISPLAY_TYPE is returned.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_DNS_TYPE 6</term>
	/// <term>
	/// If the certificate has a Subject Alternative Name extension for issuer, Issuer Alternative Name, search for first DNSName
	/// choice. If the DNSName choice is not found in the extension, search the Subject Name field for the CN OID, "2.5.4.3". If the
	/// DNSName or CN OID is found, return the string. Otherwise, return an empty string.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_URL_TYPE 7</term>
	/// <term>
	/// If the certificate has a Subject Alternative Name extension for issuer, Issuer Alternative Name, search for first URL choice. If
	/// the URL choice is found, return the string. Otherwise, return an empty string.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_UPN_TYPE 8</term>
	/// <term>
	/// If the certificate has a Subject Alternative Name extension, search the OtherName choices looking for a pszObjId ==
	/// szOID_NT_PRINCIPAL_NAME, ("1.3.6.1.4.1.311.20.2.3"). If the UPN OID is found, decode the BLOB as a X509_UNICODE_ANY_STRING and
	/// return the decoded string. Otherwise, return an empty string.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Indicates the type of processing needed.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_NAME_ISSUER_FLAG 0x1</term>
	/// <term>Acquires the issuer's name. If not set, acquires the subject's name.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_DISABLE_IE4_UTF8_FLAG 0x00010000</term>
	/// <term>Skips the default initial attempt to decode the value as UTF8 and decodes as 8-bit characters.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_SEARCH_ALL_NAMES_FLAG 0x2</term>
	/// <term>
	/// If the dwType parameter is set to CERT_NAME_DNS_TYPE, all applicable names are returned for the specified DNS value. If there is
	/// no DNS name but there is a CN component in the subject, the CN is returned instead. If there is a CN and a DNS name, only the
	/// DNS names are returned. This mimics the SSL chain building policy. If you set this flag for a name type other than
	/// CERT_NAME_DNS_TYPE, this function returns a null-terminated empty string. Windows 8 and Windows Server 2012: Support for this
	/// flag begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_ENABLE_PUNYCODE_FLAG 0x00200000</term>
	/// <term>
	/// This flag enables decoding of IA5String strings to Unicode string values based on the dwType parameter value as defined below:
	/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvTypePara">
	/// A pointer to either a <c>DWORD</c> containing the dwStrType or an object identifier (OID) specifying the name attribute. The
	/// type pointed to is determined by the value of dwType.
	/// </param>
	/// <param name="pszNameString">
	/// <para>
	/// A pointer to an allocated buffer to receive the returned string. If pszNameString is not <c>NULL</c> and cchNameString is not
	/// zero, pszNameString is a <c>null</c>-terminated string.
	/// </para>
	/// <para>
	/// If <c>CERT_NAME_SEARCH_ALL_NAMES_FLAG</c> is specified in the dwFlags parameter and <c>CERT_NAME_DNS_TYPE</c> is set in the
	/// dwType parameter, the returned string will contain all of the DNS names that apply. Each string in the output string is
	/// null-terminated and the last string will be double null-terminated. If no DNS names are found, a single null-terminated empty
	/// string is returned.
	/// </para>
	/// </param>
	/// <param name="cchNameString">
	/// Size, in characters, allocated for the returned string. The size must include the terminating <c>NULL</c> character.
	/// </param>
	/// <returns>
	/// Returns the number of characters converted, including the terminating zero character. If pszNameString is <c>NULL</c> or
	/// cchNameString is zero, returns the required size of the destination string (including the terminating <c>NULL</c> character). If
	/// the specified name type is not found, returns a <c>null</c>-terminated empty string with a returned character count of 1.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetnamestringa DWORD CertGetNameStringA(
	// PCCERT_CONTEXT pCertContext, DWORD dwType, DWORD dwFlags, void *pvTypePara, PSTR pszNameString, DWORD cchNameString );
	[DllImport(Lib.Crypt32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "300e6345-0be0-48c7-a3a3-174879cf0bbb")]
	public static extern uint CertGetNameString(PCCERT_CONTEXT pCertContext, CertNameType dwType, CertNameFlags dwFlags, in uint pvTypePara,
		[Out, MarshalAs(UnmanagedType.LPTStr), SizeDef(nameof(cchNameString), SizingMethod.QueryResultInReturn | SizingMethod.InclNullTerm)] StringBuilder? pszNameString, uint cchNameString);

	/// <summary>
	/// <para>
	/// The <c>CertNameToStr</c> function converts an encoded name in a CERT_NAME_BLOB structure to a null-terminated character string.
	/// </para>
	/// <para>
	/// The string representation follows the distinguished name specifications in RFC 1779. The exceptions to this rule are listed in
	/// the Remarks section, below.
	/// </para>
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// The certificate encoding type that was used to encode the name. The message encoding type identifier, contained in the high
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
	/// <param name="pName">A pointer to the CERT_NAME_BLOB structure to be converted.</param>
	/// <param name="dwStrType">
	/// <para>
	/// This parameter specifies the format of the output string. This parameter also specifies other options for the contents of the string.
	/// </para>
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SIMPLE_NAME_STR 1</term>
	/// <term>
	/// All object identifiers (OIDs) are discarded. CERT_RDN entries are separated by a comma followed by a space (, ). Multiple
	/// attributes in a CERT_RDN are separated by a plus sign enclosed within spaces ( + ), for example, Microsoft, Kim Abercrombie + Programmer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_OID_NAME_STR 2</term>
	/// <term>
	/// OIDs are included with an equal sign (=) separator from their attribute value. CERT_RDN entries are separated by a comma
	/// followed by a space (, ). Multiple attributes in a CERT_RDN are separated by a plus sign followed by a space (+ ).
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_X500_NAME_STR 3</term>
	/// <term>
	/// OIDs are converted to their X.500 key names; otherwise, they are the same as CERT_OID_NAME_STR. If an OID does not have a
	/// corresponding X.500 name, the OID is used with a prefix of OID. The RDN value is quoted if it contains leading or trailing white
	/// space or one of the following characters: The quotation character is an inch mark ("). If the RDN value contains an inch mark,
	/// it is enclosed within quotation marks ("").
	/// </term>
	/// </item>
	/// </list>
	/// <para>The following options can also be combined with the value above to specify additional options for the string.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_NAME_STR_SEMICOLON_FLAG 0x40000000</term>
	/// <term>Replace the comma followed by a space (, ) separator with a semicolon followed by a space (; ) separator.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_CRLF_FLAG 0x08000000</term>
	/// <term>
	/// Replace the comma followed by a space (, ) separator with a backslash followed by the letter r followed by a backslash followed
	/// by the letter n (\r\n) separator.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_NO_PLUS_FLAG 0x20000000</term>
	/// <term>Replace the plus sign enclosed within spaces ( + ) separator with a single space separator.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_NO_QUOTING_FLAG 0x10000000</term>
	/// <term>Disable quoting.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_REVERSE_FLAG 0x02000000</term>
	/// <term>The order of the RDNs in the distinguished name string is reversed after decoding. This flag is not set by default.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_DISABLE_IE4_UTF8_FLAG 0x00010000</term>
	/// <term>
	/// By default, a CERT_RDN_T61_STRING X.500 key string is decoded as UTF8. If UTF8 decoding fails, the X.500 key is decoded as an 8
	/// bit character. Use CERT_NAME_STR_DISABLE_IE4_UTF8_FLAG to skip the initial attempt to decode as UTF8.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_ENABLE_PUNYCODE_FLAG 0x00200000</term>
	/// <term>
	/// If the name pointed to by the pName parameter contains an email RDN, and the host name portion of the email address contains a
	/// Punycode encoded IA5String, the name is converted to the Unicode equivalent. Windows Server 2008, Windows Vista, Windows Server
	/// 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="psz">
	/// A pointer to a character buffer that receives the returned string. The size of this buffer is specified in the csz parameter.
	/// </param>
	/// <param name="csz">The size, in characters, of the psz buffer. The size must include the terminating null character.</param>
	/// <returns>
	/// <para>Returns the number of characters converted, including the terminating null character.</para>
	/// <para>If psz is <c>NULL</c> or csz is zero, returns the required size of the destination string.</para>
	/// </returns>
	/// <remarks>
	/// <para>If psz is not <c>NULL</c> and csz is not zero, the returned psz is always a null-terminated string.</para>
	/// <para>
	/// We recommend against using multicomponent RDNs (e.g., CN=James+O=Microsoft) to avoid possible ordering problems when decoding
	/// occurs. Instead, consider using single valued RDNs (e.g., CN=James, O=Microsoft).
	/// </para>
	/// <para>
	/// The string representation follows the distinguished name specifications in RFC 1779 except for the deviations described in the
	/// following list.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Names that contain quotes are enclosed within double quotation marks.</term>
	/// </item>
	/// <item>
	/// <term>Empty strings are enclosed within double quotation marks.</term>
	/// </item>
	/// <item>
	/// <term>Strings that contain consecutive spaces are not enclosed within quotation marks.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Relative Distinguished Name (RDN) values of type <c>CERT_RDN_ENCODED_BLOB</c> or <c>CERT_RDN_OCTET_STRING</c> are formatted in hexadecimal.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If an OID does not have a corresponding X.500 name, the “OID” prefix is used before OID.</term>
	/// </item>
	/// <item>
	/// <term>
	/// RDN values are enclosed with double quotation marks (instead of “\”) if they contain leading white space, trailing white space,
	/// or one of the following characters:
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The X.500 key name for stateOrProvinceName (2.5.4.8) OID is “S”. This value is different from the RFC 1779 X.500 key name (“S”).
	/// </term>
	/// </item>
	/// </list>
	/// <para>In addition, the following X.500 key names are not mentioned in RFC 1779, but may be returned by this API:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Key</term>
	/// <term>Object identifier string</term>
	/// </listheader>
	/// <item>
	/// <term>E</term>
	/// <term>1.2.840.113549.1.9.1</term>
	/// </item>
	/// <item>
	/// <term>T</term>
	/// <term>2.5.4.12</term>
	/// </item>
	/// <item>
	/// <term>G</term>
	/// <term>2.5.4.42</term>
	/// </item>
	/// <item>
	/// <term>I</term>
	/// <term>2.5.4.43</term>
	/// </item>
	/// <item>
	/// <term>SN</term>
	/// <term>2.5.4.4</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see</para>
	/// <para>Example C Program: Converting Names from Certificates to ASN.1 and Back.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certnametostra DWORD CertNameToStrA( DWORD
	// dwCertEncodingType, PCERT_NAME_BLOB pName, DWORD dwStrType, PSTR psz, DWORD csz );
	[DllImport(Lib.Crypt32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b3d96de8-5cbc-4ccb-b759-6757520bbda3")]
	public static extern uint CertNameToStr(CertEncodingType dwCertEncodingType, in CRYPTOAPI_BLOB pName, CertNameStringFormat dwStrType,
		[Out, MarshalAs(UnmanagedType.LPTStr), SizeDef(nameof(csz), SizingMethod.QueryResultInReturn | SizingMethod.InclNullTerm)] StringBuilder? psz, uint csz);

	/// <summary>
	/// <para>
	/// Use the CryptFindOIDInfo function instead of this function because ALG_ID identifiers are no longer supported in CNG. Use the
	/// <c>CRYPT_OID_INFO_OID_KEY</c> value in the dwKeyType parameter of the CryptFindOIDInfo function instead.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> The <c>CertOIDToAlgId</c> function converts the Abstract Syntax Notation One (ASN.1)
	/// object identifier (OID) string to the CryptoAPI algorithm identifier (ALG_ID).
	/// </para>
	/// </summary>
	/// <param name="pszObjId">Pointer to the ASN.1 OID to be converted to an algorithm identifier.</param>
	/// <returns>
	/// Returns the ALG_ID that corresponds to the object identifier (OID) or zero if no <c>ALG_ID</c> corresponds to the OID.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certoidtoalgid DWORD CertOIDToAlgId( LPCSTR pszObjId );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "920b2642-ce7c-4098-8720-5a6f24128787")]
	public static extern uint CertOIDToAlgId(SafeOID pszObjId);

	/// <summary>
	/// The <c>CertRDNValueToStr</c> function converts a name in a CERT_RDN_VALUE_BLOB to a <c>null</c>-terminated character string.
	/// </summary>
	/// <param name="dwValueType">
	/// <para>Indicates the kind of RDN value to be converted.</para>
	/// <para>This can be one of the following values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CERT_RDN_ANY_TYPE</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_ENCODED_BLOB</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_OCTET_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_NUMERIC_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_PRINTABLE_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_TELETEX_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_T61_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_VIDEOTEX_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_IA5_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_GRAPHIC_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_VISIBLE_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_ISO646_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_GENERAL_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_UNIVERSAL_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_INT4_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_BMP_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_UNICODE_STRING</term>
	/// </item>
	/// <item>
	/// <term>CERT_RDN_UTF8_STRING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pValue">A pointer to an CERT_RDN_VALUE_BLOB of a type appropriate for the dwValueType.</param>
	/// <param name="psz">A pointer to a buffer to receive the returned string.</param>
	/// <param name="csz">
	/// Size, in characters, allocated for the returned string. The size must include the terminating <c>NULL</c> character.
	/// </param>
	/// <returns>
	/// Returns the number of characters converted, including the terminating <c>NULL</c> character. If psz is <c>NULL</c> or csz is
	/// zero, returns the required size of the destination string.
	/// </returns>
	/// <remarks>
	/// If psz is not <c>NULL</c> and csz is not zero, the returned psz is always a possibly empty <c>null</c>-terminated string.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certrdnvaluetostra DWORD CertRDNValueToStrA( DWORD
	// dwValueType, PCERT_RDN_VALUE_BLOB pValue, PSTR psz, DWORD csz );
	[DllImport(Lib.Crypt32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "c1e0af19-320e-411e-85bf-c7f01befcac4")]
	public static extern uint CertRDNValueToStr(CertRDNType dwValueType, in CRYPTOAPI_BLOB pValue,
		[Out, MarshalAs(UnmanagedType.LPTStr), SizeDef(nameof(csz), SizingMethod.QueryResultInReturn | SizingMethod.InclNullTerm)] StringBuilder? psz, uint csz);

	/// <summary>The <c>CertStrToName</c> function converts a null-terminated X.500 string to an encoded certificate name.</summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// The certificate encoding type that was used to encode the string. The message encoding type identifier, contained in the high
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
	/// <param name="pszX500">
	/// <para>
	/// A pointer to the null-terminated X.500 string to be converted. The format of this string is specified by the dwStrType parameter.
	/// </para>
	/// <para>This string is expected to be formatted the same as the output from the CertNameToStr function.</para>
	/// </param>
	/// <param name="dwStrType">
	/// <para>This parameter specifies the type of the string. This parameter also specifies other options for the contents of the string.</para>
	/// <para>
	/// If no flags are combined with the string type specifier, the string can contain a comma (,) or a semicolon (;) as separators in
	/// the relative distinguished name (RDN) and a plus sign (+) as the separator in multiple RDN values.
	/// </para>
	/// <para>
	/// Quotation marks ("") are supported. A quotation can be included in a quoted value by using two sets of quotation marks, for
	/// example, CN="User ""one""".
	/// </para>
	/// <para>
	/// A value that starts with a number sign (#) is treated as ASCII hexadecimal and converted to a <c>CERT_RDN_OCTET_STRING</c>.
	/// Embedded white space is ignored. For example, 1.2.3 = # AB CD 01 is the same as 1.2.3=#ABCD01.
	/// </para>
	/// <para>White space that surrounds the keys, object identifiers, and values is ignored.</para>
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_SIMPLE_NAME_STR 1</term>
	/// <term>This string type is not supported.</term>
	/// </item>
	/// <item>
	/// <term>CERT_OID_NAME_STR 2</term>
	/// <term>Validates that the string type is supported. The string can be either an object identifier (OID) or an X.500 name.</term>
	/// </item>
	/// <item>
	/// <term>CERT_X500_NAME_STR 3</term>
	/// <term>
	/// Identical to CERT_OID_NAME_STR. Validates that the string type is supported. The string can be either an object identifier (OID)
	/// or an X.500 name.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The following options can also be combined with the value above to specify additional options for the string.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_NAME_STR_COMMA_FLAG 0x04000000</term>
	/// <term>Only a comma (,) is supported as the RDN separator.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_SEMICOLON_FLAG 0x40000000</term>
	/// <term>Only a semicolon (;) is supported as the RDN separator.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_CRLF_FLAG 0x08000000</term>
	/// <term>Only a backslash r (\r) or backslash n (\n) is supported as the RDN separator.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_NO_PLUS_FLAG 0x20000000</term>
	/// <term>The plus sign (+) is ignored as a separator, and multiple values per RDN are not supported.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_NO_QUOTING_FLAG 0x10000000</term>
	/// <term>Quoting is not supported.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_REVERSE_FLAG 0x02000000</term>
	/// <term>The order of the RDNs in a distinguished name is reversed before encoding. This flag is not set by default.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_ENABLE_T61_UNICODE_FLAG 0x00020000</term>
	/// <term>
	/// The CERT_RDN_T61_STRING encoded value type is used instead of CERT_RDN_UNICODE_STRING. This flag can be used if all the Unicode
	/// characters are less than or equal to 0xFF.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_ENABLE_UTF8_UNICODE_FLAG 0x00040000</term>
	/// <term>The CERT_RDN_UTF8_STRING encoded value type is used instead of CERT_RDN_UNICODE_STRING.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_FORCE_UTF8_DIR_STR_FLAG 0x00080000</term>
	/// <term>
	/// Forces the X.500 key to be encoded as a UTF-8 (CERT_RDN_UTF8_STRING) string rather than as a printable Unicode
	/// (CERT_RDN_PRINTABLE_STRING) string. This is the default value for Microsoft certification authorities beginning with Windows
	/// Server 2003.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_DISABLE_UTF8_DIR_STR_FLAG 0x00100000</term>
	/// <term>
	/// Prevents forcing a printable Unicode (CERT_RDN_PRINTABLE_STRING) X.500 key to be encoded by using UTF-8 (CERT_RDN_UTF8_STRING).
	/// Use to enable encoding of X.500 keys as Unicode values when CERT_NAME_STR_FORCE_UTF8_DIR_STR_FLAG is set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_NAME_STR_ENABLE_PUNYCODE_FLAG 0x00200000</term>
	/// <term>
	/// If the string contains an email RDN value, and the email address contains Unicode characters outside of the ASCII character set,
	/// the host name portion of the email address is encoded in Punycode. The resultant email address is then encoded as an IA5String
	/// string. The Punycode encoding of the host name is performed on a label-by-label basis. Windows Server 2008, Windows Vista,
	/// Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvReserved">Reserved for future use and must be <c>NULL</c>.</param>
	/// <param name="pbEncoded">
	/// <para>A pointer to a buffer that receives the encoded structure.</para>
	/// <para>The size of this buffer is specified in the pcbEncoded parameter.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to obtain the required size of the buffer for memory allocation purposes. For more
	/// information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbEncoded">
	/// <para>
	/// A pointer to a <c>DWORD</c> that, before calling the function, contains the size, in bytes, of the buffer pointed to by the
	/// pbEncoded parameter. When the function returns, the <c>DWORD</c> contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>If pbEncoded is <c>NULL</c>, the <c>DWORD</c> receives the size, in bytes, required for the buffer.</para>
	/// </param>
	/// <param name="ppszError">
	/// <para>A pointer to a string pointer that receives additional error information about an input string that is not valid.</para>
	/// <para>
	/// If the pszX500 string is not valid, ppszError is updated by this function to point to the beginning of the character sequence
	/// that is not valid. If no errors are detected in the input string, ppszError is set to <c>NULL</c>.
	/// </para>
	/// <para>If this information is not required, pass <c>NULL</c> for this parameter.</para>
	/// <para>This parameter is updated for the following error codes returned from GetLastError.</para>
	/// <para>CRYPT_E_INVALID_X500_STRING</para>
	/// <para>CRYPT_E_INVALID_NUMERIC_STRING</para>
	/// <para>CRYPT_E_INVALID_PRINTABLE_STRING</para>
	/// <para>CRYPT_E_INVALID_IA5_STRING</para>
	/// </param>
	/// <returns>
	/// <para>Returns nonzero if successful or zero otherwise.</para>
	/// <para>For extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The following table contains the supported X.500 keys, their corresponding object identifier string, string identifier (from
	/// Wincrypt.h), and value types.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Key</term>
	/// <term>Object identifier string</term>
	/// <term>String identifier</term>
	/// <term>RDN value types</term>
	/// </listheader>
	/// <item>
	/// <term>CN</term>
	/// <term>2.5.4.3</term>
	/// <term>szOID_COMMON_NAME</term>
	/// <term>Printable T61</term>
	/// </item>
	/// <item>
	/// <term>L</term>
	/// <term>2.5.4.7</term>
	/// <term>szOID_LOCALITY_NAME</term>
	/// <term>Printable T61</term>
	/// </item>
	/// <item>
	/// <term>O</term>
	/// <term>2.5.4.10</term>
	/// <term>szOID_ORGANIZATION_NAME</term>
	/// <term>Printable T61</term>
	/// </item>
	/// <item>
	/// <term>OU</term>
	/// <term>2.5.4.11</term>
	/// <term>szOID_ORGANIZATIONAL_UNIT_NAME</term>
	/// <term>Printable T61</term>
	/// </item>
	/// <item>
	/// <term>E Email</term>
	/// <term>1.2.840.113549.1.9.1</term>
	/// <term>szOID_RSA_emailAddr</term>
	/// <term>IA5</term>
	/// </item>
	/// <item>
	/// <term>C</term>
	/// <term>2.5.4.6</term>
	/// <term>szOID_COUNTRY_NAME</term>
	/// <term>Printable</term>
	/// </item>
	/// <item>
	/// <term>S ST</term>
	/// <term>2.5.4.8</term>
	/// <term>szOID_STATE_OR_PROVINCE_NAME</term>
	/// <term>Printable T61</term>
	/// </item>
	/// <item>
	/// <term>STREET</term>
	/// <term>2.5.4.9</term>
	/// <term>szOID_STREET_ADDRESS</term>
	/// <term>Printable T61</term>
	/// </item>
	/// <item>
	/// <term>T Title</term>
	/// <term>2.5.4.12</term>
	/// <term>szOID_TITLE</term>
	/// <term>Printable T61</term>
	/// </item>
	/// <item>
	/// <term>G GivenName</term>
	/// <term>2.5.4.42</term>
	/// <term>szOID_GIVEN_NAME</term>
	/// <term>Printable T61</term>
	/// </item>
	/// <item>
	/// <term>I Initials</term>
	/// <term>2.5.4.43</term>
	/// <term>szOID_INITIALS</term>
	/// <term>Printable T61</term>
	/// </item>
	/// <item>
	/// <term>SN</term>
	/// <term>2.5.4.4</term>
	/// <term>szOID_SUR_NAME</term>
	/// <term>Printable T61</term>
	/// </item>
	/// <item>
	/// <term>DC</term>
	/// <term>0.9.2342.19200300.100.1.25</term>
	/// <term>szOID_DOMAIN_COMPONENT</term>
	/// <term>IA5 UTF8</term>
	/// </item>
	/// </list>
	/// <para>
	/// If either Printable or T61 is allowed as the RDN value type for the key, Printable is automatically selected if the name string
	/// component is a member of the following character sets:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>A, B, …, Z</term>
	/// </item>
	/// <item>
	/// <term>a, b, …, z</term>
	/// </item>
	/// <item>
	/// <term>0, 1, …, 9</term>
	/// </item>
	/// <item>
	/// <term>(space) ' ( ) + , - . / : = ?</term>
	/// </item>
	/// </list>
	/// <para>The T61 types are UTF8 encoded.</para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Converting Names from Certificates to ASN.1 and Back.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certstrtonamea BOOL CertStrToNameA( DWORD
	// dwCertEncodingType, LPCSTR pszX500, DWORD dwStrType, void *pvReserved, BYTE *pbEncoded, DWORD *pcbEncoded, LPCSTR *ppszError );
	[DllImport(Lib.Crypt32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "8bdfafa6-9833-4689-a155-dff09647ec8d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertStrToName(CertEncodingType dwCertEncodingType, [MarshalAs(UnmanagedType.LPTStr)] string pszX500, CertNameStringFormat dwStrType,
		[Optional, Ignore] IntPtr pvReserved, [Out, Optional, SizeDef(nameof(pcbEncoded), SizingMethod.Query)] IntPtr pbEncoded, ref uint pcbEncoded, out PTSTR ppszError);

	/// <summary>The <c>CryptBinaryToString</c> function converts an array of bytes into a formatted string.</summary>
	/// <param name="pbBinary">A pointer to the array of bytes to be converted into a string.</param>
	/// <param name="cbBinary">The number of elements in the pbBinary array.</param>
	/// <param name="dwFlags">
	/// <para>Specifies the format of the resulting formatted string. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_STRING_BASE64HEADER 0x00000000</term>
	/// <term>Base64, with certificate beginning and ending headers.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_BASE64 0x00000001</term>
	/// <term>Base64, without headers.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_BINARY 0x00000002</term>
	/// <term>Pure binary copy.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_BASE64REQUESTHEADER 0x00000003</term>
	/// <term>Base64, with request beginning and ending headers.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_HEX 0x00000004</term>
	/// <term>Hexadecimal only.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_HEXASCII 0x00000005</term>
	/// <term>Hexadecimal, with ASCII character display.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_BASE64X509CRLHEADER 0x00000009</term>
	/// <term>Base64, with X.509 CRL beginning and ending headers.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_HEXADDR 0x0000000a</term>
	/// <term>Hexadecimal, with address display.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_HEXASCIIADDR 0x0000000b</term>
	/// <term>Hexadecimal, with ASCII character and address display.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_HEXRAW 0x0000000c</term>
	/// <term>A raw hexadecimal string. Windows Server 2003 and Windows XP: This value is not supported.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_STRICT 0x20000000</term>
	/// <term>
	/// Enforce strict decoding of ASN.1 text formats. Some ASN.1 binary BLOBS can have the first few bytes of the BLOB incorrectly
	/// interpreted as Base64 text. In this case, the rest of the text is ignored. Use this flag to enforce complete decoding of the
	/// BLOB. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// <para>In addition to the values above, one or more of the following values can be specified to modify the behavior of the function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_STRING_NOCRLF 0x40000000</term>
	/// <term>
	/// Do not append any new line characters to the encoded string. The default behavior is to use a carriage return/line feed (CR/LF)
	/// pair (0x0D/0x0A) to represent a new line. Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_NOCR 0x80000000</term>
	/// <term>
	/// Only use the line feed (LF) character (0x0A) for a new line. The default behavior is to use a CR/LF pair (0x0D/0x0A) to
	/// represent a new line.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszString">
	/// A pointer to a buffer that receives the converted string. To calculate the number of characters that must be allocated to hold
	/// the returned string, set this parameter to <c>NULL</c>. The function will place the required number of characters, including the
	/// terminating <c>NULL</c> character, in the value pointed to by pcchString.
	/// </param>
	/// <param name="pcchString">
	/// A pointer to a <c>DWORD</c> variable that contains the size, in <c>TCHAR</c> s, of the pszString buffer. If pszString is
	/// <c>NULL</c>, the function calculates the length of the return string (including the terminating null character) in <c>TCHAR</c>
	/// s and returns it in this parameter. If pszString is not <c>NULL</c> and big enough, the function converts the binary data into a
	/// specified string format including the terminating null character, but pcchString receives the length in <c>TCHAR</c> s, not
	/// including the terminating null character.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>).</para>
	/// </returns>
	/// <remarks>
	/// With the exception of when <c>CRYPT_STRING_BINARY</c> encoding is used, all strings are appended with a new line sequence. By
	/// default, the new line sequence is a CR/LF pair (0x0D/0x0A). If the dwFlags parameter contains the <c>CRYPT_STRING_NOCR</c> flag,
	/// then the new line sequence is a LF character (0x0A). If the dwFlags parameter contains the <c>CRYPT_STRING_NOCRLF</c> flag, then
	/// no new line sequence is appended to the string.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptbinarytostringa BOOL CryptBinaryToStringA( const
	// BYTE *pbBinary, DWORD cbBinary, DWORD dwFlags, PSTR pszString, DWORD *pcchString );
	[DllImport(Lib.Crypt32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e6bdf931-fba3-4a33-b22e-5f818f565842")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptBinaryToString([In, SizeDef(nameof(cbBinary))] IntPtr pbBinary, uint cbBinary, CryptStringFormat dwFlags,
		[Out, MarshalAs(UnmanagedType.LPTStr), SizeDef(nameof(pcchString), SizingMethod.Query | SizingMethod.InclNullTerm)] StringBuilder? pszString, ref uint pcchString);

	/// <summary>
	/// The <c>CryptFormatObject</c> function formats the encoded data and returns a Unicode string in the allocated buffer according to
	/// the certificate encoding type.
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// Type of encoding used on the certificate. The currently defined certificate encoding type used is X509_ASN_ENCODING.
	/// </param>
	/// <param name="dwFormatType">Format type values. Not used. Set to zero.</param>
	/// <param name="dwFormatStrType">
	/// <para>
	/// Structure format type values. This parameter can be zero, or you can specify one or more of the following flags by using the
	/// bitwise- <c>OR</c> operator to combine them.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Display the data in a single line. Each subfield is concatenated with a comma (,). For more information, see Remarks.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_FORMAT_STR_MULTI_LINE 0x0001</term>
	/// <term>Display the data in multiple lines rather than single line (the default). For more information, see Remarks.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_FORMAT_STR_NO_HEX 0x0010</term>
	/// <term>Disables the hexadecimal dump. For more information, see Remarks.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pFormatStruct">A pointer to the format of the structure. Not used. Set to <c>NULL</c>.</param>
	/// <param name="lpszStructType">
	/// <para>
	/// A pointer to an OID that defines the encoded data. If the high-order word of the lpszStructType parameter is zero, the low-order
	/// word specifies the integer identifier for the type of the given structure. Otherwise, this parameter is a long pointer to a
	/// <c>null</c>-terminated string.
	/// </para>
	/// <para>The following table lists supported OIDs with their associated OID extension.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPC_FINANCIAL_CRITERIA_OBJID</term>
	/// <term>1.3.6.1.4.1.311.2.1.27</term>
	/// </item>
	/// <item>
	/// <term>SPC_SP_AGENCY_INFO_OBJID</term>
	/// <term>1.3.6.1.4.1.311.2.1.10</term>
	/// </item>
	/// <item>
	/// <term>szOID_AUTHORITY_INFO_ACCESS</term>
	/// <term>1.3.6.1.5.5.7.1.1</term>
	/// </item>
	/// <item>
	/// <term>szOID_AUTHORITY_KEY_IDENTIFIER2</term>
	/// <term>2.5.29.35</term>
	/// </item>
	/// <item>
	/// <term>szOID_BASIC_CONSTRAINTS2</term>
	/// <term>2.5.29.19</term>
	/// </item>
	/// <item>
	/// <term>szOID_CERT_POLICIES</term>
	/// <term>2.5.29.32</term>
	/// </item>
	/// <item>
	/// <term>szOID_CRL_DIST_POINTS</term>
	/// <term>2.5.29.31</term>
	/// </item>
	/// <item>
	/// <term>szOID_CRL_REASON_CODE</term>
	/// <term>2.5.29.21</term>
	/// </item>
	/// <item>
	/// <term>szOID_ENHANCED_KEY_USAGE</term>
	/// <term>2.5.29.37</term>
	/// </item>
	/// <item>
	/// <term>szOID_ISSUER_ALT_NAME2</term>
	/// <term>2.5.29.18</term>
	/// </item>
	/// <item>
	/// <term>szOID_KEY_ATTRIBUTES</term>
	/// <term>2.5.29.2</term>
	/// </item>
	/// <item>
	/// <term>szOID_KEY_USAGE</term>
	/// <term>2.5.29.15</term>
	/// </item>
	/// <item>
	/// <term>szOID_KEY_USAGE_RESTRICTION</term>
	/// <term>2.5.29.4</term>
	/// </item>
	/// <item>
	/// <term>szOID_NEXT_UPDATE_LOCATION</term>
	/// <term>1.3.6.1.4.1.311.10.2</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_SMIMECapabilities</term>
	/// <term>1.2.840.113549.1.9.15</term>
	/// </item>
	/// <item>
	/// <term>szOID_SUBJECT_ALT_NAME2</term>
	/// <term>2.5.29.17</term>
	/// </item>
	/// <item>
	/// <term>szOID_SUBJECT_KEY_IDENTIFIER</term>
	/// <term>2.5.29.14</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbEncoded">
	/// A pointer to the encoded data to be formatted. If lpszStructType is one of the OIDs listed above, the pbEncoded is the encoded extension.
	/// </param>
	/// <param name="cbEncoded">The size, in bytes, of the pbEncoded structure.</param>
	/// <param name="pbFormat">
	/// A pointer to a buffer that receives the formatted string. When the buffer that is specified is not large enough to receive the
	/// decoded structure, the function sets ERROR_MORE_DATA and stores the required buffer size, in bytes, into the variable pointed to
	/// by pcbFormat. This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more
	/// information, see Retrieving Data of Unknown Length.
	/// </param>
	/// <param name="pcbFormat">
	/// <para>
	/// A pointer to a variable that specifies the size, in bytes, of the buffer pointed to by the pbFormat parameter. When the function
	/// returns, the variable pointed to by the pcbFormat parameter contains the number of bytes stored in the buffer. This parameter
	/// can be <c>NULL</c>, only if pbFormat is <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications need to use the actual size of the data returned. The
	/// actual size may be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data will fit into the buffer.) On output, the variable
	/// pointed to by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is <c>TRUE</c>. If it does not succeed, the return value is <c>FALSE</c>. To retrieve
	/// extended error information, use the GetLastError function.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The default behavior of this function is to return a single-line display of the encoded data, that is, each subfield is
	/// concatenated with a comma (,) on one line. If you prefer to display the data in multiple lines, set the
	/// CRYPT_FORMAT_STR_MULTI_LINE flag. Each subfield will then be displayed on a separate line.
	/// </para>
	/// <para>
	/// If there is no formatting routine installed or registered for the lpszStructType parameter, the hexadecimal dump of the encoded
	/// CRYPT_INTEGER_BLOB will be returned. A user can set the CRYPT_FORMAT_STR_NO_HEX flag to disable the hexadecimal dump.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptformatobject BOOL CryptFormatObject( DWORD
	// dwCertEncodingType, DWORD dwFormatType, DWORD dwFormatStrType, void *pFormatStruct, LPCSTR lpszStructType, const BYTE *pbEncoded,
	// DWORD cbEncoded, void *pbFormat, DWORD *pcbFormat );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "307e0bd5-b8a6-4d85-9775-65aae99e8dc6")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptFormatObject(CertEncodingType dwCertEncodingType, [Optional, Ignore] uint dwFormatType, CryptFormatStr dwFormatStrType, [Optional, Ignore] IntPtr pFormatStruct,
		[In] SafeOID lpszStructType, [In, SizeDef(nameof(cbEncoded))] IntPtr pbEncoded, uint cbEncoded,
		[Out, Optional, SizeDef(nameof(pcbFormat), SizingMethod.Query)] IntPtr pbFormat, ref uint pcbFormat);

	/// <summary>The <c>CryptStringToBinary</c> function converts a formatted string into an array of bytes.</summary>
	/// <param name="pszString">A pointer to a string that contains the formatted string to be converted.</param>
	/// <param name="cchString">
	/// The number of characters of the formatted string to be converted, not including the terminating <c>NULL</c> character. If this
	/// parameter is zero, pszString is considered to be a null-terminated string.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Indicates the format of the string to be converted. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_STRING_BASE64HEADER 0x00000000</term>
	/// <term>Base64, with certificate beginning and ending headers.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_BASE64 0x00000001</term>
	/// <term>Base64, without headers.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_BINARY 0x00000002</term>
	/// <term>Pure binary copy.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_BASE64REQUESTHEADER 0x00000003</term>
	/// <term>Base64, with request beginning and ending headers.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_HEX 0x00000004</term>
	/// <term>Hexadecimal only format.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_HEXASCII 0x00000005</term>
	/// <term>Hexadecimal format with ASCII character display.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_BASE64_ANY 0x00000006</term>
	/// <term>Tries the following, in order: CRYPT_STRING_BASE64HEADER CRYPT_STRING_BASE64</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_ANY 0x00000007</term>
	/// <term>Tries the following, in order: CRYPT_STRING_BASE64HEADER CRYPT_STRING_BASE64 CRYPT_STRING_BINARY</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_HEX_ANY 0x00000008</term>
	/// <term>Tries the following, in order: CRYPT_STRING_HEXADDR CRYPT_STRING_HEXASCIIADDR CRYPT_STRING_HEX CRYPT_STRING_HEXRAW CRYPT_STRING_HEXASCII</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_BASE64X509CRLHEADER 0x00000009</term>
	/// <term>Base64, with X.509 certificate revocation list (CRL) beginning and ending headers.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_HEXADDR 0x0000000a</term>
	/// <term>Hex, with address display.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_HEXASCIIADDR 0x0000000b</term>
	/// <term>Hex, with ASCII character and address display.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_HEXRAW 0x0000000c</term>
	/// <term>A raw hexadecimal string. Windows Server 2003 and Windows XP: This value is not supported.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_STRICT 0x20000000</term>
	/// <term>
	/// Set this flag for Base64 data to specify that the end of the binary data contain only white space and at most three equals "="
	/// signs. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbBinary">
	/// A pointer to a buffer that receives the returned sequence of bytes. If this parameter is <c>NULL</c>, the function calculates
	/// the length of the buffer needed and returns the size, in bytes, of required memory in the <c>DWORD</c> pointed to by pcbBinary.
	/// </param>
	/// <param name="pcbBinary">
	/// <para>
	/// A pointer to a <c>DWORD</c> variable that, on entry, contains the size, in bytes, of the pbBinary buffer. After the function
	/// returns, this variable contains the number of bytes copied to the buffer. If this value is not large enough to contain all of
	/// the data, the function fails and GetLastError returns <c>ERROR_MORE_DATA</c>.
	/// </para>
	/// <para>If pbBinary is <c>NULL</c>, the <c>DWORD</c> pointed to by pcbBinary is ignored.</para>
	/// </param>
	/// <param name="pdwSkip">
	/// A pointer to a <c>DWORD</c> value that receives the number of characters skipped to reach the beginning of the actual base64 or
	/// hexadecimal strings. This parameter is optional and can be <c>NULL</c> if it is not needed.
	/// </param>
	/// <param name="pdwFlags">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the flags actually used in the conversion. These are the same flags used for the
	/// dwFlags parameter. In many cases, these will be the same flags that were passed in the dwFlags parameter. If dwFlags contains
	/// one of the following flags, this value will receive a flag that indicates the actual format of the string. This parameter is
	/// optional and can be <c>NULL</c> if it is not needed.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_STRING_ANY</term>
	/// <term>
	/// This variable will receive one of the following values. Each value indicates the actual format of the string.
	/// CRYPT_STRING_BASE64HEADER CRYPT_STRING_BASE64 CRYPT_STRING_BINARY
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_BASE64_ANY</term>
	/// <term>
	/// This variable will receive one of the following values. Each value indicates the actual format of the string.
	/// CRYPT_STRING_BASE64HEADER CRYPT_STRING_BASE64
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_STRING_HEX_ANY</term>
	/// <term>
	/// This variable will receive one of the following values. Each value indicates the actual format of the string.
	/// CRYPT_STRING_HEXADDR CRYPT_STRING_HEXASCIIADDR CRYPT_STRING_HEX CRYPT_STRING_HEXRAW CRYPT_STRING_HEXASCII
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>).</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptstringtobinarya BOOL CryptStringToBinaryA( LPCSTR
	// pszString, DWORD cchString, DWORD dwFlags, BYTE *pbBinary, DWORD *pcbBinary, DWORD *pdwSkip, DWORD *pdwFlags );
	[DllImport(Lib.Crypt32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "13b6f5ef-174a-4254-8492-6e7dcc58945f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptStringToBinary([In, MarshalAs(UnmanagedType.LPTStr), SizeDef(nameof(cchString))] string pszString, uint cchString,
		CryptStringFormat dwFlags, [Out, Optional, SizeDef(nameof(pcbBinary), SizingMethod.Query)] IntPtr pbBinary, ref uint pcbBinary, out uint pdwSkip, out CryptStringFormat pdwFlags);
}