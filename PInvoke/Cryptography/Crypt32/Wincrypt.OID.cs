using System.Collections.Generic;

namespace Vanara.PInvoke;

/// <summary>Methods and data types found in Crypt32.dll.</summary>
public static partial class Crypt32
{
	/// <summary>Number of bits to shift byte len into an OID Group ID.</summary>
	public const int CRYPT_OID_INFO_OID_GROUP_BIT_LEN_SHIFT = 16;

	/// <summary>The <c>CRYPT_ENUM_OID_FUNCTION</c> callback function is used with the CryptEnumOIDFunction function.</summary>
	/// <param name="dwEncodingType">
	/// <para>Specifies the encoding type to match. Setting this parameter to CRYPT_MATCH_ANY_ENCODING_TYPE matches any encoding type.</para>
	/// <para><c>Note</c> If CRYPT_MATCH_ANY_ENCODING_TYPE is not specified, either a certificate or message encoding type is required.</para>
	/// <para>
	/// If the low-order word containing the certificate encoding type is nonzero, it is used. Otherwise, the high-order word containing the
	/// message encoding type is used. If both are specified, the certificate encoding type in the low-order word is used.Currently defined
	/// encoding types are:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>CRYPT_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_MATCH_ANY_ENCODING_TYPE</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszFuncName"/>
	/// <param name="pszOID">
	/// A pointer to either an OID string, such as "2.5.29.1", an ASCII string, such as "file", or a numeric string, such as #2000.
	/// </param>
	/// <param name="cValue">Count of elements in the array of value types.</param>
	/// <param name="rgdwValueType[]"/>
	/// <param name="rgpwszValueName[]"/>
	/// <param name="rgpbValueData[]"/>
	/// <param name="rgcbValueData[]"/>
	/// <param name="pvArg">A pointer to arguments passed through to the callback function.</param>
	/// <returns>Returns <c>TRUE</c> if the function succeeds, <c>FALSE</c> if it fails.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nc-wincrypt-pfn_crypt_enum_oid_func
	// PFN_CRYPT_ENUM_OID_FUNC PfnCryptEnumOidFunc; BOOL PfnCryptEnumOidFunc( [in] DWORD dwEncodingType, LPCSTR pszFuncName, [in] LPCSTR pszOID, [in] DWORD cValue, const DWORD rgdwValueType[], LPCWSTR const rgpwszValueName[], const BYTE * const rgpbValueData[], const DWORD rgcbValueData[], [in] void *pvArg ) {...}
	[PInvokeData("wincrypt.h", MSDNShortId = "NC:wincrypt.PFN_CRYPT_ENUM_OID_FUNC")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool PFN_CRYPT_ENUM_OID_FUNC(CertEncodingType dwEncodingType, [MarshalAs(UnmanagedType.LPStr)] string pszFuncName, [In] IntPtr pszOID,
		uint cValue, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] REG_VALUE_TYPE[] rgdwValueType,
		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 3)] string[] rgpwszValueName,
		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] IntPtr[] rgpbValueData, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] uint[] rgcbValueData, IntPtr pvArg);

	/// <summary>The <c>CRYPT_ENUM_OID_INFO</c> callback function is used with the CryptEnumOIDInfo function.</summary>
	/// <param name="pInfo">A pointer to the OID information.</param>
	/// <param name="pvArg">A pointer to arguments passed to this function.</param>
	/// <returns>
	/// Returns <c>TRUE</c> to continue the enumeration and <c>FALSE</c> to stop the enumeration. If <c>FALSE</c> is returned, the
	/// CryptEnumOIDInfo enumeration is stopped.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nc-wincrypt-pfn_crypt_enum_oid_info PFN_CRYPT_ENUM_OID_INFO
	// PfnCryptEnumOidInfo; BOOL PfnCryptEnumOidInfo( PCCRYPT_OID_INFO pInfo, void *pvArg ) {...}
	[PInvokeData("wincrypt.h", MSDNShortId = "30ae4274-631d-4c6a-96c5-18f096607cad")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool PFN_CRYPT_ENUM_OID_INFO(PCCRYPT_OID_INFO pInfo, [In, Out, Optional] IntPtr pvArg);

	/// <summary>Flags for <see cref="CryptInstallOIDFunctionAddress"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "934e8278-0e0b-4402-a2b6-ff1e913d54c9")]
	[Flags]
	public enum CryptInstallOIDFuncFlags
	{
		/// <summary>Installs the function set at the end of the list.</summary>
		CRYPT_INSTALL_OID_FUNC_AFTER_FLAG = 0,

		/// <summary>Installs the function set at the beginning of the list.</summary>
		CRYPT_INSTALL_OID_FUNC_BEFORE_FLAG = 1
	}

	/// <summary>Flags for CryptGetOIDFunctionAddress.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "2eef6109-a840-48c6-936c-ec0875039c39")]
	[Flags]
	public enum OIDFuncFlags
	{
		/// <summary>Searches only the installed list of functions.</summary>
		CRYPT_GET_INSTALLED_OID_FUNC_FLAG = 0x1
	}

	/// <summary>Indicates which OID groups to be matched. Setting dwGroupId to zero matches all groups.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "6af23bb4-3a27-425a-90bb-9a69ea081b25")]
	public enum OIDGroupId
	{
		/// <summary>Matches all groups.</summary>
		ALL = 0,

		/// <summary/>
		CRYPT_HASH_ALG_OID_GROUP_ID = 1,

		/// <summary/>
		CRYPT_ENCRYPT_ALG_OID_GROUP_ID = 2,

		/// <summary/>
		CRYPT_PUBKEY_ALG_OID_GROUP_ID = 3,

		/// <summary/>
		CRYPT_SIGN_ALG_OID_GROUP_ID = 4,

		/// <summary/>
		CRYPT_RDN_ATTR_OID_GROUP_ID = 5,

		/// <summary/>
		CRYPT_EXT_OR_ATTR_OID_GROUP_ID = 6,

		/// <summary/>
		CRYPT_ENHKEY_USAGE_OID_GROUP_ID = 7,

		/// <summary/>
		CRYPT_POLICY_OID_GROUP_ID = 8,

		/// <summary/>
		CRYPT_TEMPLATE_OID_GROUP_ID = 9,

		/// <summary/>
		CRYPT_KDF_OID_GROUP_ID = 10,
	}

	/// <summary>
	/// The <c>CryptEnumOIDFunction</c> function enumerates the registered object identifier (OID) functions. OID functions that are
	/// enumerated can be screened to include those identified by their encoding type, function name, OID, or any combination of encoding
	/// type, function name, and OID. For each OID function that matches the selection criteria, an application-provided callback function,
	/// <c>pfnEnumOIDFunc</c>, is called.
	/// </summary>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type to match. Setting this parameter to CRYPT_MATCH_ANY_ENCODING_TYPE matches any encoding type. Note that if
	/// CRYPT_MATCH_ANY_ENCODING_TYPE is not specified, either a certificate or message encoding type is required. If the low-order word that
	/// contains the certificate encoding type is nonzero, it is used; otherwise, the high-order word that contains the message encoding type
	/// is used. If both are specified, the certificate encoding type in the low-order word is used.
	/// </para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CRYPT_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_MATCH_ANY_ENCODING_TYPE</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszFuncName">
	/// Name of a function for which a case insensitive match search is performed. Setting this parameter to <c>NULL</c> results in a match
	/// being found for any function name.
	/// </param>
	/// <param name="pszOID">
	/// If the high-order word of <c>pszOID</c> is nonzero, <c>pszOID</c> specifies the object identifier for which a case insensitive match
	/// search is performed. If the high-order word of <c>pszOID</c> is zero, <c>pszOID</c> is used to match a numeric object identifier.
	/// Setting this parameter to <c>NULL</c> matches any object identifier. Setting this parameter to CRYPT_DEFAULT_OID restricts the
	/// enumeration to only the default functions.
	/// </param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <param name="pvArg">A pointer to arguments to be passed through to the CRYPT_ENUM_OID_FUNCTION callback function.</param>
	/// <param name="pfnEnumOIDFunc">
	/// A pointer to the callback function that is executed for each OID function that matches the input parameters. For details, see CRYPT_ENUM_OID_FUNCTION.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptenumoidfunction
	// BOOL CryptEnumOIDFunction( [in] DWORD dwEncodingType, [in] LPCSTR pszFuncName, [in] LPCSTR pszOID, [in] DWORD dwFlags, [in] void *pvArg, [in] PFN_CRYPT_ENUM_OID_FUNC pfnEnumOIDFunc );
	[PInvokeData("wincrypt.h", MSDNShortId = "NF:wincrypt.CryptEnumOIDFunction")]
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptEnumOIDFunction(CertEncodingType dwEncodingType, [Optional, MarshalAs(UnmanagedType.LPStr)] string? pszFuncName,
		[Optional, In] SafeOID pszOID, [Optional] uint dwFlags, [In, Out, Optional] IntPtr pvArg, PFN_CRYPT_ENUM_OID_FUNC pfnEnumOIDFunc);

	/// <summary>
	/// The <c>CryptEnumOIDFunction</c> function enumerates the registered object identifier (OID) functions. OID functions that are
	/// enumerated can be screened to include those identified by their encoding type, function name, OID, or any combination of encoding
	/// type, function name, and OID. For each OID function that matches the selection criteria, an application-provided callback function,
	/// <c>pfnEnumOIDFunc</c>, is called.
	/// </summary>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type to match. Setting this parameter to CRYPT_MATCH_ANY_ENCODING_TYPE matches any encoding type. Note that if
	/// CRYPT_MATCH_ANY_ENCODING_TYPE is not specified, either a certificate or message encoding type is required. If the low-order word that
	/// contains the certificate encoding type is nonzero, it is used; otherwise, the high-order word that contains the message encoding type
	/// is used. If both are specified, the certificate encoding type in the low-order word is used.
	/// </para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CRYPT_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_MATCH_ANY_ENCODING_TYPE</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszFuncName">
	/// Name of a function for which a case insensitive match search is performed. Setting this parameter to <c>NULL</c> results in a match
	/// being found for any function name.
	/// </param>
	/// <param name="pszOID">
	/// If the high-order word of <c>pszOID</c> is nonzero, <c>pszOID</c> specifies the object identifier for which a case insensitive match
	/// search is performed. If the high-order word of <c>pszOID</c> is zero, <c>pszOID</c> is used to match a numeric object identifier.
	/// Setting this parameter to <c>NULL</c> matches any object identifier. Setting this parameter to CRYPT_DEFAULT_OID restricts the
	/// enumeration to only the default functions.
	/// </param>
	/// <returns>A sequence of encoding types, names, oids and their related value details.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptenumoidfunction
	// BOOL CryptEnumOIDFunction( [in] DWORD dwEncodingType, [in] LPCSTR pszFuncName, [in] LPCSTR pszOID, [in] DWORD dwFlags, [in] void *pvArg, [in] PFN_CRYPT_ENUM_OID_FUNC pfnEnumOIDFunc );
	[PInvokeData("wincrypt.h", MSDNShortId = "NF:wincrypt.CryptEnumOIDFunction")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static IReadOnlyList<(CertEncodingType encType, string funcName, SafeOID oid, (string valueName, object? value)[] values)> CryptEnumOIDFunction(
		CertEncodingType dwEncodingType = CertEncodingType.CRYPT_MATCH_ANY_ENCODING_TYPE, string? pszFuncName = null, SafeOID? pszOID = null)
	{
		List<(CertEncodingType, string, SafeOID, (string, object?)[])> list = new();
		Win32Error.ThrowLastErrorIfFalse(CryptEnumOIDFunction(dwEncodingType, pszFuncName, pszOID ?? SafeOID.NULL, default, default, func));
		return list;

		bool func(CertEncodingType dwEncodingType, string pszFuncName, IntPtr pszOID, uint cValue, REG_VALUE_TYPE[] rgdwValueType, string[] rgpwszValueName,
			IntPtr[] rgpbValueData, uint[] rgcbValueData, IntPtr pvArg)
		{
			var vals = new (string, object?)[(int)cValue];
			for (int i = 0; i < cValue; i++)
				vals[i] = (rgpwszValueName[i], rgdwValueType[i].GetValue(rgpbValueData[i], rgcbValueData[i], CharSet.Unicode));
			list.Add((dwEncodingType, pszFuncName!, pszOID, vals));
			return true;
		}
	}

	/// <summary>
	/// The <c>CryptEnumOIDInfo</c> function enumerates predefined and registered object identifier (OID) CRYPT_OID_INFO structures.
	/// This function enumerates either all of the predefined and registered structures or only structures identified by a selected OID
	/// group. For each OID information structure enumerated, an application provided callback function, pfnEnumOIDInfo, is called.
	/// </summary>
	/// <param name="dwGroupId">
	/// <para>
	/// Indicates which OID groups to be matched. Setting dwGroupId to zero matches all groups. If dwGroupId is greater than zero, only
	/// the OID entries in the specified group are enumerated.
	/// </para>
	/// <para>The currently defined OID group IDs are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CRYPT_HASH_ALG_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ENCRYPT_ALG_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_PUBKEY_ALG_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_SIGN_ALG_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_RDN_ATTR_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_EXT_OR_ATTR_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ENHKEY_USAGE_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_POLICY_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_TEMPLATE_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>
	/// CRYPT_KDF_OID_GROUP_ID <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> The CRYPT_KDF_OID_GROUP_ID
	/// value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LAST_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_FIRST_ALG_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LAST_ALG_OID_GROUP_ID</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">This parameter is reserved for future use. It must be zero.</param>
	/// <param name="pvArg">A pointer to arguments to be passed through to the callback function.</param>
	/// <param name="pfnEnumOIDInfo">
	/// A pointer to the callback function that is executed for each OID information entry enumerated. For information about the
	/// callback parameters, see CRYPT_ENUM_OID_INFO.
	/// </param>
	/// <returns>
	/// <para>If the callback function completes the enumeration, this function returns <c>TRUE</c>.</para>
	/// <para>If the callback function has stopped the enumeration, this function returns <c>FALSE</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptenumoidinfo BOOL CryptEnumOIDInfo( DWORD dwGroupId,
	// DWORD dwFlags, void *pvArg, PFN_CRYPT_ENUM_OID_INFO pfnEnumOIDInfo );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "NF:wincrypt.CryptEnumOIDInfo")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptEnumOIDInfo(OIDGroupId dwGroupId, [Optional] uint dwFlags, [In, Out, Optional] IntPtr pvArg, PFN_CRYPT_ENUM_OID_INFO pfnEnumOIDInfo);

	/// <summary>
	/// The <c>CryptEnumOIDInfo</c> function enumerates predefined and registered object identifier (OID) CRYPT_OID_INFO structures. This
	/// function enumerates either all of the predefined and registered structures or only structures identified by a selected OID group. For
	/// each OID information structure enumerated, an application provided callback function, <c>pfnEnumOIDInfo</c>, is called.
	/// </summary>
	/// <param name="dwGroupId">
	/// <para>
	/// Indicates which OID groups to be matched. Setting <c>dwGroupId</c> to zero matches all groups. If <c>dwGroupId</c> is greater than
	/// zero, only the OID entries in the specified group are enumerated.
	/// </para>
	/// <para>The currently defined OID group IDs are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CRYPT_HASH_ALG_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ENCRYPT_ALG_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_PUBKEY_ALG_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_SIGN_ALG_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_RDN_ATTR_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_EXT_OR_ATTR_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ENHKEY_USAGE_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_POLICY_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_TEMPLATE_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>
	/// CRYPT_KDF_OID_GROUP_ID <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> The CRYPT_KDF_OID_GROUP_ID
	/// value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LAST_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_FIRST_ALG_OID_GROUP_ID</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_LAST_ALG_OID_GROUP_ID</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>A sequence of <see cref="PCCRYPT_OID_INFO"/> structures.</returns>
	[PInvokeData("wincrypt.h", MSDNShortId = "NF:wincrypt.CryptEnumOIDInfo")]
	public static IReadOnlyList<CRYPT_OID_INFO> CryptEnumOIDInfo(OIDGroupId dwGroupId = 0)
	{
		List<CRYPT_OID_INFO> list = new();
		Win32Error.ThrowLastErrorIfFalse(CryptEnumOIDInfo(dwGroupId, default, default, func));
		return list;

		bool func(PCCRYPT_OID_INFO pInfo, IntPtr pvArg) { list.Add((CRYPT_OID_INFO)pInfo); return true; }
	}

	/// <summary>
	/// <para>
	/// The <c>CryptFindOIDInfo</c> function retrieves the first predefined or registered CRYPT_OID_INFO structure that matches a
	/// specified key type and key. The search can be limited to object identifiers (OIDs) within a specified OID group.
	/// </para>
	/// <para>
	/// Use CryptEnumOIDInfo to list all or selected subsets of CRYPT_OID_INFO structures. New <c>CRYPT_OID_INFO</c> structures can be
	/// registered by using CryptRegisterOIDInfo. User-registered OIDs can be removed from the list of registered OIDs by using CryptUnregisterOIDInfo.
	/// </para>
	/// <para>
	/// New OIDs can be placed in the list of registered OIDs either before or after the predefined entries. Because
	/// <c>CryptFindOIDInfo</c> returns the first key on the list that matches the search criteria, a newly registered OID placed before
	/// a predefined OID entry with the same key overrides a predefined entry.
	/// </para>
	/// </summary>
	/// <param name="dwKeyType">
	/// <para>Specifies the key type to use when finding OID information.</para>
	/// <para>This parameter can be one of the following key types.</para>
	/// <para>CRYPT_OID_INFO_OID_KEY</para>
	/// <para>pvKey is the address of a null-terminated ANSI string that contains the OID string to find.</para>
	/// <para>CRYPT_OID_INFO_NAME_KEY</para>
	/// <para>pvKey is the address of a null-terminated Unicode string that contains the name to find.</para>
	/// <para>CRYPT_OID_INFO_ALGID_KEY</para>
	/// <para>pvKey is the address of an ALG_IDvariable. The following <c>ALG_ID</c> s are supported:</para>
	/// <para>Hash Algorithms:</para>
	/// <para>Symmetric Encryption Algorithms:</para>
	/// <para>Public Key Algorithms:</para>
	/// <para>Algorithms that are not listed are supported by using Cryptography API: Next Generation (CNG) only; instead, use <c>CRYPT_OID_INFO_CNG_ALGID_KEY</c>.</para>
	/// <para>CRYPT_OID_INFO_SIGN_KEY</para>
	/// <para>
	/// pvKey is the address of an array of two ALG_IDs where the first element contains the hash algorithm identifier and the second
	/// element contains the public key algorithm identifier.
	/// </para>
	/// <para>The following <c>ALG_ID</c> combinations are supported.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Signature algorithm identifier</term>
	/// <term>Hash algorithm identifier</term>
	/// </listheader>
	/// <item>
	/// <term>CALG_RSA_SIGN</term>
	/// <term>CALG_SHA1 CALG_MD5 CALG_MD4 CALG_MD2</term>
	/// </item>
	/// <item>
	/// <term>CALG_DSS_SIGN</term>
	/// <term>CALG_SHA1</term>
	/// </item>
	/// <item>
	/// <term>CALG_NO_SIGN</term>
	/// <term>CALG_SHA1 CALG_NO_SIGN</term>
	/// </item>
	/// </list>
	/// <para>Algorithms that are not listed are supported through CNG only; instead, use <c>CRYPT_OID_INFO_CNG_SIGN_KEY</c>.</para>
	/// <para>CRYPT_OID_INFO_CNG_ALGID_KEY</para>
	/// <para>
	/// pvKey is the address of a null-terminated Unicode string that contains the CNG algorithm identifier to find. This can be one of
	/// the predefined CNG Algorithm Identifiers or another registered algorithm identifier.
	/// </para>
	/// <para>Windows Server 2003 R2 Windows Server 2003 :</para>
	/// <para>This key type is not supported.</para>
	/// <para>CRYPT_OID_INFO_CNG_SIGN_KEY</para>
	/// <para>
	/// pvKey is the address of an array of two null-terminated Unicode string pointers where the first string contains the hash CNG
	/// algorithm identifier and the second string contains the public key CNG algorithm identifier. These can be from the predefined
	/// CNG Algorithm Identifiers or another registered algorithm identifier.
	/// </para>
	/// <para>Windows Server 2003 R2 Windows Server 2003 :</para>
	/// <para>This key type is not supported.</para>
	/// <para>
	/// Optionally, the following key types can be specified in the dwKeyType parameter by using the logical <c>OR</c> operator (|).
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_OID_INFO_PUBKEY_SIGN_KEY_FLAG</term>
	/// <term>
	/// Skips public keys in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group that are explicitly flagged with the
	/// CRYPT_OID_PUBKEY_ENCRYPT_ONLY_FLAG flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_OID_INFO_PUBKEY_ENCRYPT_KEY_FLAG</term>
	/// <term>
	/// Skips public keys in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group that are explicitly flagged with the
	/// CRYPT_OID_PUBKEY_SIGN_ONLY_FLAG flag.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvKey">
	/// The address of a buffer that contains additional search information. This parameter depends on the value of the dwKeyType
	/// parameter. For more information, see the table under dwKeyType.
	/// </param>
	/// <param name="dwGroupId">
	/// <para>
	/// The group identifier to use when finding OID information. Setting this parameter to zero searches all groups according to the
	/// dwKeyType parameter. Otherwise, only the indicated dwGroupId is searched.
	/// </para>
	/// <para>For information about code that lists the OID information by group identifier, see CryptEnumOIDInfo.</para>
	/// <para>Optionally, the following flag can be specified in the dwGroupId parameter by using the logical <c>OR</c> operator (|).</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_OID_DISABLE_SEARCH_DS_FLAG</term>
	/// <term>Disables searching the directory server.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The bit length shifted left 16 bits can be specified in the dwGroupId parameter by using the logical <c>OR</c> operator (|). For
	/// more information, see Remarks.
	/// </para>
	/// </param>
	/// <returns>
	/// Returns a pointer to a constant structure of type CRYPT_OID_INFO. The returned pointer must not be freed. When the specified key
	/// and group is not found, <c>NULL</c> is returned.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CryptFindOIDInfo</c> function performs a lookup in the active directory to retrieve the friendly names of OIDs under the
	/// following conditions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The key type in the dwKeyType parameter is set to <c>CRYPT_OID_INFO_OID_KEY</c> or <c>CRYPT_OID_INFO_NAME_KEY</c>.</term>
	/// </item>
	/// <item>
	/// <term>
	/// No group identifier is specified in the dwGroupId parameter or the GroupID refers to EKU OIDs, policy OIDs or template OIDs.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Network retrieval of the friendly name can be suppressed by calling the function with the
	/// <c>CRYPT_OID_DISABLE_SEARCH_DS_FLAG</c> flag.
	/// </para>
	/// <para>
	/// The bit length shifted left 16 bits can be specified in the dwGroupId parameter by using the logical <c>OR</c> operator (|).
	/// This is only applicable to the <c>CRYPT_ENCRYPT_ALG_OID_GROUP_ID</c> group entries that have a bit length specified in the
	/// <c>ExtraInfo</c> member of the CRYPT_OID_INFO structure. Currently, only the AES encryption algorithms have this. The constant
	/// <c>CRYPT_OID_INFO_OID_GROUP_BIT_LEN_SHIFT</c> can be used for doing the shift. For example, to find the OID information for
	/// <c>BCRYPT_AES_ALGORITHM</c> with bit length equal to 192, call <c>CryptFindOIDInfo</c> as follows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptfindoidinfo PCCRYPT_OID_INFO CryptFindOIDInfo( DWORD
	// dwKeyType, void *pvKey, DWORD dwGroupId );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "87acf207-d109-4173-9530-8cbbebb473b2")]
	public static extern PCCRYPT_OID_INFO CryptFindOIDInfo(CryptOIDInfoFlags dwKeyType, [In] IntPtr pvKey, OIDGroupId dwGroupId);

	/// <summary>
	/// <para>
	/// The <c>CryptFindOIDInfo</c> function retrieves the first predefined or registered CRYPT_OID_INFO structure that matches a
	/// specified key type and key. The search can be limited to object identifiers (OIDs) within a specified OID group.
	/// </para>
	/// <para>
	/// Use CryptEnumOIDInfo to list all or selected subsets of CRYPT_OID_INFO structures. New <c>CRYPT_OID_INFO</c> structures can be
	/// registered by using CryptRegisterOIDInfo. User-registered OIDs can be removed from the list of registered OIDs by using CryptUnregisterOIDInfo.
	/// </para>
	/// <para>
	/// New OIDs can be placed in the list of registered OIDs either before or after the predefined entries. Because
	/// <c>CryptFindOIDInfo</c> returns the first key on the list that matches the search criteria, a newly registered OID placed before
	/// a predefined OID entry with the same key overrides a predefined entry.
	/// </para>
	/// </summary>
	/// <param name="dwKeyType">
	/// <para>Specifies the key type to use when finding OID information.</para>
	/// <para>This parameter can be one of the following key types.</para>
	/// <para>CRYPT_OID_INFO_OID_KEY</para>
	/// <para>pvKey is the address of a null-terminated ANSI string that contains the OID string to find.</para>
	/// <para>CRYPT_OID_INFO_NAME_KEY</para>
	/// <para>pvKey is the address of a null-terminated Unicode string that contains the name to find.</para>
	/// <para>CRYPT_OID_INFO_ALGID_KEY</para>
	/// <para>pvKey is the address of an ALG_IDvariable. The following <c>ALG_ID</c> s are supported:</para>
	/// <para>Hash Algorithms:</para>
	/// <para>Symmetric Encryption Algorithms:</para>
	/// <para>Public Key Algorithms:</para>
	/// <para>Algorithms that are not listed are supported by using Cryptography API: Next Generation (CNG) only; instead, use <c>CRYPT_OID_INFO_CNG_ALGID_KEY</c>.</para>
	/// <para>CRYPT_OID_INFO_SIGN_KEY</para>
	/// <para>
	/// pvKey is the address of an array of two ALG_IDs where the first element contains the hash algorithm identifier and the second
	/// element contains the public key algorithm identifier.
	/// </para>
	/// <para>The following <c>ALG_ID</c> combinations are supported.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Signature algorithm identifier</term>
	/// <term>Hash algorithm identifier</term>
	/// </listheader>
	/// <item>
	/// <term>CALG_RSA_SIGN</term>
	/// <term>CALG_SHA1 CALG_MD5 CALG_MD4 CALG_MD2</term>
	/// </item>
	/// <item>
	/// <term>CALG_DSS_SIGN</term>
	/// <term>CALG_SHA1</term>
	/// </item>
	/// <item>
	/// <term>CALG_NO_SIGN</term>
	/// <term>CALG_SHA1 CALG_NO_SIGN</term>
	/// </item>
	/// </list>
	/// <para>Algorithms that are not listed are supported through CNG only; instead, use <c>CRYPT_OID_INFO_CNG_SIGN_KEY</c>.</para>
	/// <para>CRYPT_OID_INFO_CNG_ALGID_KEY</para>
	/// <para>
	/// pvKey is the address of a null-terminated Unicode string that contains the CNG algorithm identifier to find. This can be one of
	/// the predefined CNG Algorithm Identifiers or another registered algorithm identifier.
	/// </para>
	/// <para>Windows Server 2003 R2 Windows Server 2003 :</para>
	/// <para>This key type is not supported.</para>
	/// <para>CRYPT_OID_INFO_CNG_SIGN_KEY</para>
	/// <para>
	/// pvKey is the address of an array of two null-terminated Unicode string pointers where the first string contains the hash CNG
	/// algorithm identifier and the second string contains the public key CNG algorithm identifier. These can be from the predefined
	/// CNG Algorithm Identifiers or another registered algorithm identifier.
	/// </para>
	/// <para>Windows Server 2003 R2 Windows Server 2003 :</para>
	/// <para>This key type is not supported.</para>
	/// <para>
	/// Optionally, the following key types can be specified in the dwKeyType parameter by using the logical <c>OR</c> operator (|).
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_OID_INFO_PUBKEY_SIGN_KEY_FLAG</term>
	/// <term>
	/// Skips public keys in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group that are explicitly flagged with the
	/// CRYPT_OID_PUBKEY_ENCRYPT_ONLY_FLAG flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_OID_INFO_PUBKEY_ENCRYPT_KEY_FLAG</term>
	/// <term>
	/// Skips public keys in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group that are explicitly flagged with the
	/// CRYPT_OID_PUBKEY_SIGN_ONLY_FLAG flag.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvKey">
	/// The address of a buffer that contains additional search information. This parameter depends on the value of the dwKeyType
	/// parameter. For more information, see the table under dwKeyType.
	/// </param>
	/// <param name="dwGroupId">
	/// <para>
	/// The group identifier to use when finding OID information. Setting this parameter to zero searches all groups according to the
	/// dwKeyType parameter. Otherwise, only the indicated dwGroupId is searched.
	/// </para>
	/// <para>For information about code that lists the OID information by group identifier, see CryptEnumOIDInfo.</para>
	/// <para>Optionally, the following flag can be specified in the dwGroupId parameter by using the logical <c>OR</c> operator (|).</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_OID_DISABLE_SEARCH_DS_FLAG</term>
	/// <term>Disables searching the directory server.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The bit length shifted left 16 bits can be specified in the dwGroupId parameter by using the logical <c>OR</c> operator (|). For
	/// more information, see Remarks.
	/// </para>
	/// </param>
	/// <returns>
	/// Returns a pointer to a constant structure of type CRYPT_OID_INFO. The returned pointer must not be freed. When the specified key
	/// and group is not found, <c>NULL</c> is returned.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CryptFindOIDInfo</c> function performs a lookup in the active directory to retrieve the friendly names of OIDs under the
	/// following conditions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The key type in the dwKeyType parameter is set to <c>CRYPT_OID_INFO_OID_KEY</c> or <c>CRYPT_OID_INFO_NAME_KEY</c>.</term>
	/// </item>
	/// <item>
	/// <term>
	/// No group identifier is specified in the dwGroupId parameter or the GroupID refers to EKU OIDs, policy OIDs or template OIDs.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Network retrieval of the friendly name can be suppressed by calling the function with the
	/// <c>CRYPT_OID_DISABLE_SEARCH_DS_FLAG</c> flag.
	/// </para>
	/// <para>
	/// The bit length shifted left 16 bits can be specified in the dwGroupId parameter by using the logical <c>OR</c> operator (|).
	/// This is only applicable to the <c>CRYPT_ENCRYPT_ALG_OID_GROUP_ID</c> group entries that have a bit length specified in the
	/// <c>ExtraInfo</c> member of the CRYPT_OID_INFO structure. Currently, only the AES encryption algorithms have this. The constant
	/// <c>CRYPT_OID_INFO_OID_GROUP_BIT_LEN_SHIFT</c> can be used for doing the shift. For example, to find the OID information for
	/// <c>BCRYPT_AES_ALGORITHM</c> with bit length equal to 192, call <c>CryptFindOIDInfo</c> as follows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptfindoidinfo PCCRYPT_OID_INFO CryptFindOIDInfo( DWORD
	// dwKeyType, void *pvKey, DWORD dwGroupId );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "87acf207-d109-4173-9530-8cbbebb473b2")]
	public static extern PCCRYPT_OID_INFO CryptFindOIDInfo(CryptOIDInfoFlags dwKeyType, [In, MarshalAs(UnmanagedType.LPWStr)] string pvKey, OIDGroupId dwGroupId);

	/// <summary>
	/// The <c>CryptFreeOIDFunctionAddress</c> function releases a handle returned by CryptGetOIDFunctionAddress or
	/// CryptGetDefaultOIDFunctionAddress by decrementing the reference count on the function handle. In some cases, the DLL file
	/// associated with the function is unloaded. For details, see Remarks.
	/// </summary>
	/// <param name="hFuncAddr">Handle of the function previously obtained from a call to CryptGetOIDFunctionAddress or CryptGetDefaultOIDFunctionAddress.</param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>).</para>
	/// </returns>
	/// <remarks>
	/// If the reference count becomes zero and a DLL is loaded for the function being freed, the DLL might be unloaded. If the DLL
	/// exports the DLLCanUnloadNow function, that function is called and its return is checked. An S_FALSE return from this function
	/// cancels the unloading of the DLL at this time. If the function returns S_TRUE or if the DLL does not export the
	/// <c>DLLCanUnloadNow</c> function, an unloading process is started. In this case, actual unloading is deferred for 15 seconds. If
	/// another <c>CryptFreeOIDFunctionAddress</c> or CryptGetDefaultOIDFunctionAddress that requires the DLL occurs before the 15
	/// seconds elapse, the deferred unload process is canceled.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptfreeoidfunctionaddress BOOL
	// CryptFreeOIDFunctionAddress( HCRYPTOIDFUNCADDR hFuncAddr, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "cacacff3-25b7-4ed4-885b-b4b0b326628f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptFreeOIDFunctionAddress(HCRYPTOIDFUNCADDR hFuncAddr, uint dwFlags = 0);

	/// <summary>
	/// The <c>CryptGetDefaultOIDDllList</c> function acquires the list of the names of DLL files that contain registered default object
	/// identifier (OID) functions for a specified function set and encoding type.
	/// </summary>
	/// <param name="hFuncSet">Function set handle previously obtained by a call to CryptInitOIDFunctionSet.</param>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type to be matched. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however,
	/// additional encoding types may be added in the future. To match both current encoding types, use:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>
	/// <c>Note</c> Either a certificate or message encoding type is required. X509_ASN_ENCODING is the default. If that type is
	/// indicated, it is used; otherwise, if the PKCS7_ASN_ENCODING type is indicated, it is used.
	/// </para>
	/// </param>
	/// <param name="pwszDllList">
	/// <para>
	/// A pointer to a buffer to receive the list of zero or more null-terminated file names. The returned list is terminated with a
	/// terminating <c>NULL</c> character. For example, a list of two names could be:
	/// </para>
	/// <para>L"first.dll\0" L"second.dll\0" L"\0"</para>
	/// <para>
	/// To retrieve the number of wide characters the buffer must hold, this parameter can be <c>NULL</c>. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcchDllList">
	/// <para>
	/// A pointer to a <c>DWORD</c> that specifies the size, in wide characters, of the returned list pointed to by the pwszDllList
	/// parameter. When the function returns, the variable pointed to by the pcchDllList parameter contains the number of wide
	/// characters stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications need to use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. On input, buffer sizes are usually specified
	/// large enough to ensure that the largest possible output data will fit in the buffer. On output, the variable pointed to by this
	/// parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>This function has the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pwszDllList parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in wide characters, in the variable pointed to by pcchDllList.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgetdefaultoiddlllist BOOL CryptGetDefaultOIDDllList(
	// HCRYPTOIDFUNCSET hFuncSet, DWORD dwEncodingType, WCHAR *pwszDllList, DWORD *pcchDllList );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "9d4643c8-a582-4c19-bd77-33b94e953818")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGetDefaultOIDDllList(HCRYPTOIDFUNCSET hFuncSet, CertEncodingType dwEncodingType,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? pwszDllList, ref int pcchDllList);

	/// <summary>
	/// The <c>CryptGetDefaultOIDFunctionAddress</c> function loads the DLL that contains a default function address. It can also return
	/// the address of the first or next installed default object identifier (OID) function in an initialized function set and load the
	/// DLL that contains the address of that function.
	/// </summary>
	/// <param name="hFuncSet">Function set handle previously obtained from a call to CryptInitOIDFunctionSet.</param>
	/// <param name="dwEncodingType">
	/// <para>
	/// Encoding type to be matched. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however, additional
	/// encoding types may be added in the future. To match both current encoding types, use:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// </param>
	/// <param name="pwszDll">
	/// Name of the DLL to load. Normally, the DLL name is obtained from the list returned by CryptGetDefaultOIDDllList. If pwszDll is
	/// <c>NULL</c>, a search is performed on the list of installed default functions.
	/// </param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <param name="ppvFuncAddr">
	/// A pointer to the address of the return function. If the function fails, a <c>NULL</c> is returned in ppvFuncAddr.
	/// </param>
	/// <param name="phFuncAddr">
	/// <para>
	/// Used only if pwszDll is <c>NULL</c>. On the first call to the function, *phFuncAddr must be <c>NULL</c> to acquire the first
	/// installed function.
	/// </para>
	/// <para>
	/// When this function is successful, *phFuncAddr is set to a function handle. The reference count for the function handle is incremented.
	/// </para>
	/// <para>
	/// After the first call to the function, phFuncAddr is set to the pointer returned by the previous call. This input pointer is
	/// always freed within the function through a call to CryptFreeOIDFunctionAddress by this function. The call to free the pointer is
	/// always made even when the main function returns an error.
	/// </para>
	/// <para>
	/// A non- <c>NULL</c> phFuncAddr must be released either through a call to CryptFreeOIDFunctionAddress or by being passed back as
	/// input to this function or as input to CryptGetOIDFunctionAddress.
	/// </para>
	/// <para>If pwszDll is not <c>NULL</c>, the value of this parameter is ignored and a non- <c>NULL</c> pointer is not freed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>).</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgetdefaultoidfunctionaddress BOOL
	// CryptGetDefaultOIDFunctionAddress( HCRYPTOIDFUNCSET hFuncSet, DWORD dwEncodingType, LPCWSTR pwszDll, DWORD dwFlags, void
	// **ppvFuncAddr, HCRYPTOIDFUNCADDR *phFuncAddr );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "3977368c-ad13-43f9-859b-10c7f170f482")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGetDefaultOIDFunctionAddress([In] HCRYPTOIDFUNCSET hFuncSet, CertEncodingType dwEncodingType,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszDll, [Optional] uint dwFlags, out IntPtr ppvFuncAddr, ref HCRYPTOIDFUNCADDR phFuncAddr);

	/// <summary>
	/// The <c>CryptGetOIDFunctionAddress</c> function searches the list of registered and installed functions for an encoding type and
	/// object identifier (OID) match. If a match is found, the DLL that contains the function is, if necessary, loaded. If a match is
	/// found, a pointer to the function address and a pointer to the function handle are also returned. The reference count on the
	/// function handle is incremented.
	/// </summary>
	/// <param name="hFuncSet">The function set handle previously obtained from a call to the CryptInitOIDFunctionSet function.</param>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type to be matched. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are used; however,
	/// additional encoding types can be added in the future. To match both current encoding types, use:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>For functions that do not use an encoding type, set this parameter to zero.</para>
	/// </param>
	/// <param name="pszOID">
	/// If the high-order word of the OID is nonzero, pszOID is a pointer to either an OID string such as "2.5.29.1" or an ASCII string
	/// such as "file". If the high-order word of the OID is zero, the low-order word specifies the numeric identifier to be used as the
	/// object identifier. This resulting OID maps to the function that was either installed or registered with the same OID.
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_GET_INSTALLED_OID_FUNC_FLAG</term>
	/// <term>Searches only the installed list of functions.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppvFuncAddr">
	/// A pointer to a pointer to a function address. If a match is found, ppvFuncAddr points to the function address.
	/// </param>
	/// <param name="phFuncAddr">
	/// <para>
	/// If a match is found, phFuncAddr points to the function handle. The reference count for the handle is incremented. When you have
	/// finished using the handle, release the handle by calling the CryptFreeOIDFunctionAddress function.
	/// </para>
	/// <para>
	/// <c>Note</c> By default, both the registered and installed function lists are searched. To search only the installed list of
	/// functions, set CRYPT_GET_INSTALLED_OID_FUNC_FLAG. This flag would be set by a registered function to get the address of a
	/// preinstalled function it was replacing. For example, the registered function might handle a new special case and call the
	/// preinstalled function to handle the remaining cases.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds and a match is found, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails or no match is found, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You can call <c>CryptGetOIDFunctionAddress</c> with the pszOID argument set to <c>CMSG_DEFAULT_INSTALLABLE_FUNC_OID</c> to get
	/// the default installable function for the following callback functions.
	/// </para>
	/// <para>
	/// For retrieval of the default functions, set dwEncodingType to a bitwise <c>OR</c> combination of the following encoding types.
	/// </para>
	/// <para><c>CRYPT_ASN_ENCODING</c><c>X509_ASN_ENCODING</c></para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgetoidfunctionaddress BOOL
	// CryptGetOIDFunctionAddress( HCRYPTOIDFUNCSET hFuncSet, DWORD dwEncodingType, LPCSTR pszOID, DWORD dwFlags, void **ppvFuncAddr,
	// HCRYPTOIDFUNCADDR *phFuncAddr );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "2eef6109-a840-48c6-936c-ec0875039c39")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGetOIDFunctionAddress([In] HCRYPTOIDFUNCSET hFuncSet, CertEncodingType dwEncodingType, [Optional, In] SafeOID pszOID,
		OIDFuncFlags dwFlags, out IntPtr ppvFuncAddr, ref HCRYPTOIDFUNCADDR phFuncAddr);

	/// <summary>
	/// The <c>CryptGetOIDFunctionValue</c> function queries a value associated with an OID. The query is made for a specific named
	/// value associated with an OID, function name, and encoding type. The function can return the type of queried value, the value,
	/// itself, or both.
	/// </summary>
	/// <param name="dwEncodingType">
	/// Specifies the encoding type to be matched. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however,
	/// additional encoding types may be added in the future. To match both current encoding types, use X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.
	/// </param>
	/// <param name="pszFuncName">A pointer to the null-terminated string that contains the name of the OID function set.</param>
	/// <param name="pszOID">
	/// If the high-order word of the OID is nonzero, pszOID is a pointer to either a null-terminated OID string such as "2.5.29.1" or a
	/// null-terminated ASCII string such as "file." If the high-order word of the OID is zero, the low-order word specifies the numeric
	/// identifier to be used as the object identifier.
	/// </param>
	/// <param name="pwszValueName">A pointer to a null-terminated Unicode string that contains the name of the value to be queried.</param>
	/// <param name="pdwValueType">
	/// <para>A pointer to a variable to receive the value's type. The type returned through this parameter will be one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>REG_DWORD</term>
	/// <term>A 32-bit number.</term>
	/// </item>
	/// <item>
	/// <term>REG_EXPAND_SZ</term>
	/// <term>
	/// A Unicode string that contains unexpanded references to environment variables such as "%PATH%". Applications should ensure that
	/// the string has a terminating null character before using it. For details about when the string does not have a terminating null
	/// character, see RegQueryValueEx.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REG_MULTI_SZ</term>
	/// <term>
	/// An array of null-terminated Unicode strings. Applications should ensure that the array is properly terminated by two null
	/// characters before using it. For details about when the array is not terminated by two null characters, see RegQueryValueEx.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REG_SZ</term>
	/// <term>
	/// A Unicode string. Applications should ensure that the string has a terminating null character before using it. For details about
	/// when the string does not have a terminating null character, see RegQueryValueEx.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The pdwValueType parameter can be <c>NULL</c> if a returned type is not required.</para>
	/// </param>
	/// <param name="pbValueData">
	/// <para>
	/// A pointer to a buffer to receive the value associated with the pwszValueName parameter. The buffer must be big enough to contain
	/// the terminating <c>NULL</c> character. This parameter can be <c>NULL</c> if returned data is not required.
	/// </para>
	/// <para>
	/// This parameter can also be <c>NULL</c> to find the size of the buffer for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbValueData">
	/// <para>A pointer to a <c>DWORD</c> that specifies the size, in bytes, of the buffer pointed to by the pbValueData.</para>
	/// <para>
	/// In most cases the value returned in *pcbValueData includes the size of the terminating <c>NULL</c> character in the string. For
	/// information about situations where the <c>NULL</c> character is not included, see the Remarks section of RegQueryValueEx.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed
	/// to by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>This function has the following error code.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbValueData parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, into the variable pointed to by pcbValueData.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgetoidfunctionvalue BOOL CryptGetOIDFunctionValue(
	// DWORD dwEncodingType, LPCSTR pszFuncName, LPCSTR pszOID, LPCWSTR pwszValueName, DWORD *pdwValueType, BYTE *pbValueData, DWORD
	// *pcbValueData );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "14eb7f10-f42a-4496-9699-62eeb9878ea2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGetOIDFunctionValue(CertEncodingType dwEncodingType, [MarshalAs(UnmanagedType.LPStr)] string pszFuncName,
		[In] SafeOID pszOID, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszValueName, out REG_VALUE_TYPE pdwValueType,
		[Out] IntPtr pbValueData, ref uint pcbValueData);

	/// <summary>
	/// The <c>CryptInitOIDFunctionSet</c> initializes and returns the handle of the OID function set identified by a supplied function
	/// set name. If the set already exists, the handle of the existing set is returned. If the set does not exist, it is created. This
	/// allows different DLLs to install OID functions for the same function set name.
	/// </summary>
	/// <param name="pszFuncName">Name of the OID function set.</param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <returns>Returns the handle of the OID function set identified by pszFuncName, or <c>NULL</c> if the function fails.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptinitoidfunctionset HCRYPTOIDFUNCSET
	// CryptInitOIDFunctionSet( LPCSTR pszFuncName, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "576a2989-ed7f-417d-b60e-24baf90a6554")]
	public static extern HCRYPTOIDFUNCSET CryptInitOIDFunctionSet([MarshalAs(UnmanagedType.LPStr)] string pszFuncName, uint dwFlags = 0);

	/// <summary>The <c>CryptInstallOIDFunctionAddress</c> function installs a set of callable object identifier (OID) function addresses.</summary>
	/// <param name="hModule">
	/// This parameter is updated with the hModule parameter passed to <c>DllMain</c> to prevent the DLL that contains the function
	/// addresses from being unloaded by CryptGetOIDFunctionAddress or CryptFreeOIDFunctionAddress. This would be the case when the DLL
	/// has also registered OID functions through CryptRegisterOIDFunction.
	/// </param>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type to be matched. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however,
	/// additional encoding types may be added in the future. To match both current encoding types, use:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// </param>
	/// <param name="pszFuncName">Name of the function set being installed.</param>
	/// <param name="cFuncEntry">Number of array elements in rgFuncEntry[].</param>
	/// <param name="rgFuncEntry">
	/// <para>Array of CRYPT_OID_FUNC_ENTRY structures, each containing an OID and the starting address of its correlated routine.</para>
	/// <para>
	/// Default functions are installed by setting the <c>pszOID</c> member of the CRYPT_OID_FUNC_ENTRY structure for their array
	/// element to CRYPT_DEFAULT_OID.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// By default, a new function set is installed at the end of the list of function sets. Setting the
	/// CRYPT_INSTALL_OID_FUNC_BEFORE_FLAG flag installs the function set at the beginning of the list.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>).</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptinstalloidfunctionaddress BOOL
	// CryptInstallOIDFunctionAddress( HMODULE hModule, DWORD dwEncodingType, LPCSTR pszFuncName, DWORD cFuncEntry, const
	// CRYPT_OID_FUNC_ENTRY [] rgFuncEntry, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "934e8278-0e0b-4402-a2b6-ff1e913d54c9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptInstallOIDFunctionAddress([Optional] HINSTANCE hModule, CertEncodingType dwEncodingType, [MarshalAs(UnmanagedType.LPStr)] string pszFuncName,
		uint cFuncEntry, [In, MarshalAs(UnmanagedType.LPArray)] CRYPT_OID_FUNC_ENTRY[] rgFuncEntry, [Optional] CryptInstallOIDFuncFlags dwFlags);

	/// <summary>
	/// The <c>CryptRegisterDefaultOIDFunction</c> registers a DLL containing the default function to be called for the specified
	/// encoding type and function name. Unlike CryptRegisterOIDFunction, the function name to be exported by the DLL cannot be overridden.
	/// </summary>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type to be matched. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however,
	/// additional encoding types may be added in the future. To match both current encoding types, use:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.</para>
	/// </param>
	/// <param name="pszFuncName">Name of the function being registered.</param>
	/// <param name="dwIndex">
	/// Index location for the insertion of the DLL in the list of DLLs. If dwIndex is zero, the DLL is inserted at the beginning of the
	/// list. If it is CRYPT_REGISTER_LAST_INDEX (0xFFFFFFFF), the DLL is appended at the end of the list.
	/// </param>
	/// <param name="pwszDll">
	/// Optional environment-variable string to be expanded using ExpandEnvironmentStrings function before loading the DLL.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>).</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptregisterdefaultoidfunction BOOL
	// CryptRegisterDefaultOIDFunction( DWORD dwEncodingType, LPCSTR pszFuncName, DWORD dwIndex, LPCWSTR pwszDll );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "9633cce4-538e-490e-8a5a-6b28f161a09d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptRegisterDefaultOIDFunction(CertEncodingType dwEncodingType, [MarshalAs(UnmanagedType.LPStr)] string pszFuncName,
		uint dwIndex, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszDll);

	/// <summary>
	/// <para>
	/// The <c>CryptRegisterOIDFunction</c> function registers a DLL that contains the function to be called for the specified encoding
	/// type, function name, and object identifier (OID).
	/// </para>
	/// <para>
	/// By default, new function names are installed at the end of the list. To register a new function before the installed functions,
	/// call the CryptSetOIDFunctionValue function with dwValueType set to <c>REG_DWORD</c> and pwszValueName set to CRYPT_OID_REG_FLAGS_VALUE_NAME.
	/// </para>
	/// <para>CRYPT_OID_REG_FLAGS_VALUE_NAME is defined as L"CryptFlags".</para>
	/// <para>
	/// In addition to registering a DLL, the name of the function to be called can be overridden. For example, the pszFuncName
	/// parameter can be set to CryptDllEncodeObject and the pszOverrideFuncName parameter to MyEncodeXyz. The new form of
	/// CryptDllEncodeObject can then be referred to by using the name MyEncodeXyz. This allows a DLL to export multiple OID functions
	/// for the same function name without needing to interpose its own OID dispatcher function.
	/// </para>
	/// </summary>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type to be matched. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however,
	/// additional encoding types may be added in the future. To match both current encoding types, use:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.</para>
	/// </param>
	/// <param name="pszFuncName">Name of the function being registered.</param>
	/// <param name="pszOID">
	/// OID of the function to be registered. If the high-order word of the OID is nonzero, pszOID is a pointer to either an OID string
	/// such as "2.5.29.1" or an ASCII string such as "file." If the high-order word of the OID is zero, the low-order word specifies
	/// the numeric identifier to be used as the object identifier.
	/// </param>
	/// <param name="pwszDll">
	/// Name of the DLL file to be registered. It can contain environment-variable strings to be expanded by using the
	/// ExpandEnvironmentStrings function before loading the DLL.
	/// </param>
	/// <param name="pszOverrideFuncName">
	/// String that specifies a name for the function exported in the DLL. If pszOverrideFuncName is <c>NULL</c>, the function name
	/// specified by pszFuncName is used.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>).</para>
	/// </returns>
	/// <remarks>When you have finished using an OID function, unregister it by calling the CryptUnregisterOIDFunction function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptregisteroidfunction BOOL CryptRegisterOIDFunction(
	// DWORD dwEncodingType, LPCSTR pszFuncName, LPCSTR pszOID, LPCWSTR pwszDll, LPCSTR pszOverrideFuncName );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b625597d-28fd-4a40-afbe-a09201d36512")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptRegisterOIDFunction(CertEncodingType dwEncodingType, [MarshalAs(UnmanagedType.LPStr)] string pszFuncName, SafeOID pszOID,
		[MarshalAs(UnmanagedType.LPWStr)] string pwszDll, [Optional, MarshalAs(UnmanagedType.LPStr)] string? pszOverrideFuncName);

	/// <summary>
	/// <para>
	/// The <c>CryptRegisterOIDInfo</c> function registers the OID information specified in the CRYPT_OID_INFO structure, persisting it
	/// to the registry.
	/// </para>
	/// <para>
	/// Crypt32.dll contains predefined information for the commonly known OIDs. This function allows applications to augment the
	/// predefined OID information. During <c>CryptRegisterOIDInfo</c>'s first call, the registered OID information is installed.
	/// </para>
	/// <para>
	/// When expanding the tables using <c>CryptRegisterOIDInfo</c>, the new entries can be placed either before or after predefined
	/// entries, controlled by dwFlags. The placement of registered OID information affects the result of CryptFindOIDInfo because the
	/// tables are searched in order. First registered entries placed before the predefined entries are checked, then the predefined
	/// entries are checked, and finally, registered entries placed after the predefined entries are checked. The first match found is
	/// returned. A newly registered entry placed before the predefined entries can override one of the predefined entries.
	/// </para>
	/// </summary>
	/// <param name="pInfo">
	/// <para>
	/// A pointer to a CRYPT_OID_INFO structure with the OID information to register. Specify the group that the OID information is to
	/// be registered for by setting the <c>dwGroupId</c> member of the structure.
	/// </para>
	/// <para>
	/// <c>Note</c> When registering OID information for Suite B algorithms implemented with Cryptography API: Next Generation (CNG),
	/// you must set the <c>Algid</c> member of the CRYPT_OID_INFO structure to <c>CALG_OID_INFO_CNG_ONLY</c> (0xFFFFFFFF).
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// By default, the registered OID information is installed after Crypt32.dll's OID entries. If CRYPT_INSTALL_OID_INFO_BEFORE_FLAG
	/// is set, new OID information is install before Crypt32.dll's entries.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>If the function fails, the return value is zero (FALSE).</para>
	/// </returns>
	/// <remarks>When you have finished using the OID information, unregister it by calling the CryptUnregisterOIDInfo function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptregisteroidinfo BOOL CryptRegisterOIDInfo(
	// PCCRYPT_OID_INFO pInfo, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "7a5b4800-3182-4cd4-b17a-c6d4e11f7047")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptRegisterOIDInfo(in CRYPT_OID_INFO pInfo, [Optional] CryptInstallOIDFuncFlags dwFlags);

	/// <summary>
	/// The <c>CryptSetOIDFunctionValue</c> function sets a value for the specified encoding type, function name, OID, and value name.
	/// </summary>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type to be matched. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however,
	/// additional encoding types may be added in the future. To match both current encoding types, use:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.</para>
	/// </param>
	/// <param name="pszFuncName">Name of the function for which the encoding type, OID, and value name is being updated.</param>
	/// <param name="pszOID">
	/// If the high-order word of the object identifier (OID) is nonzero, pszOID is a pointer to either an OID string such as "2.5.29.1"
	/// or an ASCII string such as "file". If the high-order word of the OID is zero, the low-order word specifies the integer
	/// identifier to be used as the object identifier.
	/// </param>
	/// <param name="pwszValueName">
	/// A pointer to a Unicode string containing the name of the value to set. If a value with this name is not already present, the
	/// function creates it.
	/// </param>
	/// <param name="dwValueType">
	/// <para>Specifies the type of information to be stored as the value's data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>REG_DWORD</term>
	/// <term>A 32-bit number.</term>
	/// </item>
	/// <item>
	/// <term>REG_EXPAND_SZ</term>
	/// <term>A null-terminated Unicode string that contains unexpanded references to environment variables (for example, "%PATH%").</term>
	/// </item>
	/// <item>
	/// <term>REG_MULTI_SZ</term>
	/// <term>An array of null-terminated Unicode strings, terminated by two NULL characters.</term>
	/// </item>
	/// <item>
	/// <term>REG_SZ</term>
	/// <term>A null-terminated Unicode string.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbValueData">Points to a buffer containing the data to be stored for the specified value name.</param>
	/// <param name="cbValueData">
	/// Specifies the size, in bytes, of the information pointed to by the pbValueData parameter. If the data is of type REG_SZ,
	/// REG_EXPAND_SZ, or REG_MULTI_SZ, the size must include the terminating <c>NULL</c> wide character.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>).</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsetoidfunctionvalue BOOL CryptSetOIDFunctionValue(
	// DWORD dwEncodingType, LPCSTR pszFuncName, LPCSTR pszOID, LPCWSTR pwszValueName, DWORD dwValueType, const BYTE *pbValueData, DWORD
	// cbValueData );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "3e167c5d-0000-4359-a7b0-9b3e4e64c50c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptSetOIDFunctionValue(CertEncodingType dwEncodingType, [MarshalAs(UnmanagedType.LPStr)] string pszFuncName,
		SafeOID pszOID, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszValueName, REG_VALUE_TYPE dwValueType, [In, Optional] IntPtr pbValueData, uint cbValueData);

	/// <summary>
	/// The <c>CryptUnregisterDefaultOIDFunction</c> removes the registration of a DLL containing the default function to be called for
	/// the specified encoding type and function name.
	/// </summary>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type to be matched. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however,
	/// additional encoding types may be added in the future. To match both current encoding types, use:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.</para>
	/// </param>
	/// <param name="pszFuncName">Name of the function being unregistered.</param>
	/// <param name="pwszDll">Name of the DLL where the function is located.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>).</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptunregisterdefaultoidfunction BOOL
	// CryptUnregisterDefaultOIDFunction( DWORD dwEncodingType, LPCSTR pszFuncName, LPCWSTR pwszDll );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "63f5b0c7-f574-4dc6-92c7-091f25febd48")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUnregisterDefaultOIDFunction(CertEncodingType dwEncodingType, [MarshalAs(UnmanagedType.LPStr)] string pszFuncName, [MarshalAs(UnmanagedType.LPWStr)] string pwszDll);

	/// <summary>
	/// The <c>CryptUnregisterOIDFunction</c> function removes the registration of a DLL that contains the function to be called for the
	/// specified encoding type, function name, and OID.
	/// </summary>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type to be matched. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are used; however,
	/// additional encoding types may be added in the future. To match both current encoding types, use:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>For functions that do not use an encoding type, set this parameter to zero.</para>
	/// </param>
	/// <param name="pszFuncName">Name of the function being unregistered.</param>
	/// <param name="pszOID">
	/// A pointer to the object identifier (OID) that corresponds to the name of the function being unregistered. If the high order word
	/// of the OID is nonzero, pszOID is a pointer to either an OID string such as "2.5.29.1" or an ASCII string such as "file." If the
	/// high order word of the OID is zero, the low order word specifies the integer identifier to be used as the object identifier.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>).</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptunregisteroidfunction BOOL
	// CryptUnregisterOIDFunction( DWORD dwEncodingType, LPCSTR pszFuncName, LPCSTR pszOID );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "c06ffda5-df7c-4e0e-bf4f-8b8c968fcd4c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUnregisterOIDFunction(CertEncodingType dwEncodingType, [MarshalAs(UnmanagedType.LPStr)] string pszFuncName, SafeOID pszOID);

	/// <summary>
	/// The <c>CryptUnregisterOIDInfo</c> function removes the registration of a specified CRYPT_OID_INFO OID information structure. The
	/// structure to be unregistered is identified by the structure's <c>pszOID</c> and <c>dwGroupId</c> members.
	/// </summary>
	/// <param name="pInfo">
	/// Specifies the object identifier (OID) information for which the registration is to be removed. The group that the registration
	/// is removed for is specified by the <c>dwGroupId</c> member in the pInfo.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>If the function fails, the return value is zero (FALSE).</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptunregisteroidinfo BOOL CryptUnregisterOIDInfo(
	// PCCRYPT_OID_INFO pInfo );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "1217397b-2af9-4f58-8616-5a18ee2f4b8c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUnregisterOIDInfo(in CRYPT_OID_INFO pInfo);

	/// <summary>
	/// The <c>CRYPT_OID_FUNC_ENTRY</c> structure contains an object identifier (OID) and a pointer to its related function. It is used
	/// with CryptInstallOIDFunctionAddress.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_oid_func_entry typedef struct _CRYPT_OID_FUNC_ENTRY
	// { LPCSTR pszOID; void *pvFuncAddr; } CRYPT_OID_FUNC_ENTRY, *PCRYPT_OID_FUNC_ENTRY;
	[PInvokeData("wincrypt.h", MSDNShortId = "84c4aca8-ee38-455f-8330-58f512a6d12c")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_OID_FUNC_ENTRY
	{
		/// <summary>
		/// If the high-order word of the OID is nonzero, <c>pszOID</c> is a pointer to either an OID string, such as "2.5.29.1" or an
		/// ASCII string, such as "file". If the high-order word of the OID is zero, the low-order word specifies the numeric identifier
		/// to be used as the object identifier.
		/// </summary>
		public IntPtr pszOID;

		/// <summary>The starting address of the function that the OID identifies.</summary>
		public IntPtr pvFuncAddr;
	}

	/// <summary>
	/// The <c>CRYPT_OID_INFO</c> structure contains information about an object identifier (OID). These structures give the
	/// relationship among an OID identifier, its name, its group, and other information about the OID. These structures can be listed
	/// by using the CryptEnumOIDInfo function. New CRYPT_OID_STRUCTURES can be added by using the CryptRegisterOIDInfo function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_oid_info typedef struct _CRYPT_OID_INFO { DWORD
	// cbSize; LPCSTR pszOID; LPCWSTR pwszName; DWORD dwGroupId; union { DWORD dwValue; ALG_ID Algid; DWORD dwLength; } DUMMYUNIONNAME;
	// CRYPT_DATA_BLOB ExtraInfo; LPCWSTR pwszCNGAlgid; LPCWSTR pwszCNGExtraAlgid; } CRYPT_OID_INFO, *PCRYPT_OID_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "06ba0f60-778d-450b-8f71-23471b8c4e2c")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_OID_INFO
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>The OID associated with this OID information.</summary>
		public StrPtrAnsi pszOID;

		/// <summary>The display name associated with an OID.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszName;

		/// <summary>
		/// <para>The group identifier value associated with this OID information.</para>
		/// <para>This member can be one of the following <c>dwGroupId</c> group identifiers.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_ENCRYPT_ALG_OID_GROUP_ID</term>
		/// <term>Encryption algorithms</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_ENHKEY_USAGE_OID_GROUP_ID</term>
		/// <term>Enhanced key usages</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_EXT_OR_ATTR_OID_GROUP_ID</term>
		/// <term>Extensions or attributes</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_HASH_ALG_OID_GROUP_ID</term>
		/// <term>Hash algorithms</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_POLICY_OID_GROUP_ID</term>
		/// <term>Policies</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_PUBKEY_ALG_OID_GROUP_ID</term>
		/// <term>Public key algorithms</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_RDN_ATTR_OID_GROUP_ID</term>
		/// <term>RDN attributes</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_SIGN_ALG_OID_GROUP_ID</term>
		/// <term>Signature algorithms</term>
		/// </item>
		/// </list>
		/// </summary>
		public OIDGroupId dwGroupId;

		/// <summary/>
		public CRYPT_OID_INFO_UNION Union;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct CRYPT_OID_INFO_UNION
		{
			/// <summary>A numeric value associated with this OID information. This member is used with <c>dwGroupId</c> CRYPT_SIGN_ALG_OID_GROUP_ID.</summary>
			[FieldOffset(0)]
			public uint dwValue;

			/// <summary>
			/// <para>The algorithm identifier associated with this OID information.</para>
			/// <para>This member applies for the following values of <c>dwGroupId</c>:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>CRYPT_HASH_ALG_OID_GROUP_ID</term>
			/// </item>
			/// <item>
			/// <term>CRYPT_ENCRYPT_ALG_OID_GROUP_ID</term>
			/// </item>
			/// <item>
			/// <term>CRYPT_PUBKEY_ALG_OID_GROUP_ID</term>
			/// </item>
			/// <item>
			/// <term>CRYPT_SIGN_ALG_OID_GROUP_ID</term>
			/// </item>
			/// </list>
			/// </summary>
			[FieldOffset(0)]
			public ALG_ID Algid;

			/// <summary>This member is not implemented. It is always set to zero.</summary>
			[FieldOffset(0)]
			public uint dwLength;
		}

		/// <summary>
		/// <para>Extra information used to find or register OID information. This member applies for the following values of <c>dwGroupId</c>:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>CRYPT_PUBKEY_ALG_OID_GROUP_ID</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_SIGN_ALG_OID_GROUP_ID</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_RDN_ATTR_OID_GROUP_ID</term>
		/// </item>
		/// </list>
		/// <para>
		/// The OIDs in the CRYPT_ENCRYPT_ALG_OID_GROUP_ID OID group have a bit length set for the AES algorithms in the DWORD[0] member
		/// of the ExtraInfo member.
		/// </para>
		/// <para>The OIDs in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group have a flag set in the DWORD[0] member of the ExtraInfo member.</para>
		/// <para>
		/// The OIDs in the ECC curve name public keys, for example, szOID_ECC_CURVE_P256 ("1.2.840.10045.3.1.7"), have a flag set in
		/// the DWORD[0] member, a BCRYPT_ECCKEY_BLOB dwMagic field value set in the DWORD[1] member, and a bit length where the
		/// BCRYPT_ECCKEY_BLOB cbKey value equals dwBitLength / 8 + ((dwBitLength % 8) ? 1 : 0) set in the DWORD[2] member of the
		/// ExtraInfo member.
		/// </para>
		/// <para>
		/// The OIDs in the CRYPT_SIGN_ALG_OID_GROUP_ID group have a public key algorithm identifier set in the DWORD[0] member, a flag
		/// set in the DWORD[1] member, and an optional provider type set in the DWORD[2] member of the ExtraInfo member.
		/// </para>
		/// <para>
		/// The OIDs in the CRYPT_RDN_ATTR_OID_GROUP_ID group have a null-terminated list of acceptable RDN attribute value types set in
		/// an array of <c>DWORD</c> values in the ExtraInfo member. An omitted list implies an array of values where the first value in
		/// the array is CERT_RDN_PRINTABLE_STRING, the second value in the array is CERT_RDN_UNICODE_STRING, and the third value in the
		/// array is zero.
		/// </para>
		/// <para>The following values are used for the flags in the <c>ExtraInfo</c> member.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_OID_INHIBIT_SIGNATURE_FORMAT_FLAG</term>
		/// <term>
		/// This flag is no longer used. Stop the reformatting of the signature before the CryptVerifySignature function is called or
		/// after the CryptSignHash function is called.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPT_OID_NO_NULL_ALGORITHM_PARA_FLAG</term>
		/// <term>Omit NULL parameters when encoding.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_OID_PUBKEY_ENCRYPT_ONLY_FLAG</term>
		/// <term>The public key is only used for encryption.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_OID_PUBKEY_SIGN_ONLY_FLAG</term>
		/// <term>The public key is only used for signatures.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_OID_USE_PUBKEY_PARA_FOR_PKCS7_FLAG</term>
		/// <term>
		/// This flag is no longer used. Include the parameters of the public key algorithm in the digestEncryptionAlgorithm parameters
		/// for the PKCS #7 message.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CRYPTOAPI_BLOB ExtraInfo;

		/// <summary>
		/// <para>
		/// The algorithm identifier string passed to the CNG functions (the BCrypt* and NCrypt* functions that are defined in Bcrypt.h
		/// and Ncrypt.h). CNG functions use algorithm identifier strings, such as L"SHA1", instead of the ALG_ID data type constants,
		/// such as <c>CALG_SHA1</c>. <c>Windows Server 2003 and Windows XP:</c> This member is not available.
		/// </para>
		/// <para><c>Note</c> The <c>pwszCNGAlgid</c> member is only available if you include the following statement in your code.</para>
		/// <para>This member applies for the following values of <c>dwGroupId</c>:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>CRYPT_HASH_ALG_OID_GROUP_ID</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_ENCRYPT_ALG_OID_GROUP_ID</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_PUBKEY_ALG_OID_GROUP_ID</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_SIGN_ALG_OID_GROUP_ID</term>
		/// </item>
		/// </list>
		/// <para>Set the pwszCNGAlgid member to the empty string, L"", for the other values of dwGroupId.</para>
		/// <para>
		/// The <c>pwszCNGAlgid</c> member can also be set to a string value that is not passed directly to the CNG functions. The
		/// following table lists these values and their meanings.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_OID_INFO_ECC_PARAMETERS_ALGORITHM</term>
		/// <term>The ECC curve algorithm is obtained from the encoded parameters of the OID algorithm.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_OID_INFO_ECC_WRAP_PARAMETERS_ALGORITHM</term>
		/// <term>The key wrap algorithm is obtained from the encoded parameters of the OID algorithm.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_OID_INFO_HASH_PARAMETERS_ALGORITHM</term>
		/// <term>The hash algorithm is obtained from the encoded parameters of the OID algorithm.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_OID_INFO_MGF1_PARAMETERS_ALGORITHM</term>
		/// <term>The PKCS #1 v2.1 mask generation hash algorithm is obtained from the encoded parameters of the OID algorithm.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_OID_INFO_NO_SIGN_ALGORITHM</term>
		/// <term>A public key algorithm that indicates the signature value is an unsigned hash.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_OID_INFO_OAEP_PARAMETERS_ALGORITHM</term>
		/// <term>The RSAES-OAEP padding hash algorithm is obtained from the encoded parameters of the OID algorithm.</term>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszCNGAlgid;

		/// <summary>
		/// <para>
		/// An extra algorithm string, other than the string in the <c>pwszCNGAlgid</c> member, that can be passed to the CNG functions
		/// (the BCrypt* and NCrypt* functions that are defined in Bcrypt.h and Ncrypt.h).
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> This member is not available.</para>
		/// <para><c>Note</c> This member is only available if you include the following statement in your code.</para>
		/// <para>
		/// For the signature algorithms (CRYPT_SIGN_ALG_OID_GROUP_ID), this member is the public key algorithm string to pass to the
		/// CNG functions.
		/// </para>
		/// <para>For ECC signatures, this member is the special CRYPT_OID_INFO_ECC_PARAMETERS_ALGORITHM string value.</para>
		/// <para>For unsigned signatures, this member is the special CRYPT_OID_INFO_NO_SIGN_ALGORITHM string value.</para>
		/// <para>
		/// For ECC curve name public keys, for example, szOID_ECC_CURVE_P256 ("1.2.840.10045.3.1.7"), this is the special
		/// CRYPT_OID_INFO_ECC_PARAMETERS_ALGORITHM string value.
		/// </para>
		/// <para>For the other values of <c>dwGroupId</c>, set the <c>pwszCNGExtraAlgid</c> member to the empty string, L"".</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszCNGExtraAlgid;
	}

	public partial struct PCCRYPT_OID_INFO
	{
		/// <summary>Performs an explicit conversion from <see cref="PCCRYPT_OID_INFO"/> to <see cref="CRYPT_OID_INFO"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The resulting <see cref="CRYPT_OID_INFO"/> instance from the conversion.</returns>
		public static explicit operator CRYPT_OID_INFO(PCCRYPT_OID_INFO h) => h.handle.ToStructure<CRYPT_OID_INFO>();
	}

	/// <summary>Definitions of various algorithm object identifiers RSA</summary>
	[PInvokeData("wincrypt.h")]
	public static class AlgOID
	{
		/// <summary/>
		public const string szOID_ANSI_X942 = "1.2.840.10046";

		/// <summary/>
		public const string szOID_ANSI_X942_DH = "1.2.840.10046.2.1";

		/// <summary/>
		public const string szOID_CN_ECDSA_SHA256 = "1.2.156.11235.1.1.1";

		/// <summary/>
		public const string szOID_DH_SINGLE_PASS_STDDH_SHA1_KDF = "1.3.133.16.840.63.0.2";

		/// <summary/>
		public const string szOID_DH_SINGLE_PASS_STDDH_SHA256_KDF = "1.3.132.1.11.1";

		/// <summary/>
		public const string szOID_DH_SINGLE_PASS_STDDH_SHA384_KDF = "1.3.132.1.11.2";

		/// <summary/>
		public const string szOID_DS = "2.5";

		/// <summary/>
		public const string szOID_DSALG = "2.5.8";

		/// <summary/>
		public const string szOID_DSALG_CRPT = "2.5.8.1";

		/// <summary/>
		public const string szOID_DSALG_HASH = "2.5.8.2";

		/// <summary/>
		public const string szOID_DSALG_RSA = "2.5.8.1.1";

		/// <summary/>
		public const string szOID_DSALG_SIGN = "2.5.8.3";

		/// <summary/>
		public const string szOID_ECC_CURVE_BRAINPOOLP160R1 = "1.3.36.3.3.2.8.1.1.1";

		/// <summary/>
		public const string szOID_ECC_CURVE_BRAINPOOLP160T1 = "1.3.36.3.3.2.8.1.1.2";

		/// <summary/>
		public const string szOID_ECC_CURVE_BRAINPOOLP192R1 = "1.3.36.3.3.2.8.1.1.3";

		/// <summary/>
		public const string szOID_ECC_CURVE_BRAINPOOLP192T1 = "1.3.36.3.3.2.8.1.1.4";

		/// <summary/>
		public const string szOID_ECC_CURVE_BRAINPOOLP224R1 = "1.3.36.3.3.2.8.1.1.5";

		/// <summary/>
		public const string szOID_ECC_CURVE_BRAINPOOLP224T1 = "1.3.36.3.3.2.8.1.1.6";

		/// <summary/>
		public const string szOID_ECC_CURVE_BRAINPOOLP256R1 = "1.3.36.3.3.2.8.1.1.7";

		/// <summary/>
		public const string szOID_ECC_CURVE_BRAINPOOLP256T1 = "1.3.36.3.3.2.8.1.1.8";

		/// <summary/>
		public const string szOID_ECC_CURVE_BRAINPOOLP320R1 = "1.3.36.3.3.2.8.1.1.9";

		/// <summary/>
		public const string szOID_ECC_CURVE_BRAINPOOLP320T1 = "1.3.36.3.3.2.8.1.1.10";

		/// <summary/>
		public const string szOID_ECC_CURVE_BRAINPOOLP384R1 = "1.3.36.3.3.2.8.1.1.11";

		/// <summary/>
		public const string szOID_ECC_CURVE_BRAINPOOLP384T1 = "1.3.36.3.3.2.8.1.1.12";

		/// <summary/>
		public const string szOID_ECC_CURVE_BRAINPOOLP512R1 = "1.3.36.3.3.2.8.1.1.13";

		/// <summary/>
		public const string szOID_ECC_CURVE_BRAINPOOLP512T1 = "1.3.36.3.3.2.8.1.1.14";

		/// <summary/>
		public const string szOID_ECC_CURVE_EC192WAPI = "1.2.156.11235.1.1.2.1";

		/// <summary/>
		public const string szOID_ECC_CURVE_NISTP192 = "1.2.840.10045.3.1.1";

		/// <summary/>
		public const string szOID_ECC_CURVE_NISTP224 = "1.3.132.0.33";

		/// <summary/>
		public const string szOID_ECC_CURVE_NISTP256 = szOID_ECC_CURVE_P256;

		/// <summary/>
		public const string szOID_ECC_CURVE_NISTP384 = szOID_ECC_CURVE_P384;

		/// <summary/>
		public const string szOID_ECC_CURVE_NISTP521 = szOID_ECC_CURVE_P521;

		/// <summary/>
		public const string szOID_ECC_CURVE_P256 = "1.2.840.10045.3.1.7";

		/// <summary/>
		public const string szOID_ECC_CURVE_P384 = "1.3.132.0.34";

		/// <summary/>
		public const string szOID_ECC_CURVE_P521 = "1.3.132.0.35";

		/// <summary/>
		public const string szOID_ECC_CURVE_SECP160K1 = "1.3.132.0.9";

		/// <summary/>
		public const string szOID_ECC_CURVE_SECP160R1 = "1.3.132.0.8";

		/// <summary/>
		public const string szOID_ECC_CURVE_SECP160R2 = "1.3.132.0.30";

		/// <summary/>
		public const string szOID_ECC_CURVE_SECP192K1 = "1.3.132.0.31";

		/// <summary/>
		public const string szOID_ECC_CURVE_SECP192R1 = szOID_ECC_CURVE_NISTP192;

		/// <summary/>
		public const string szOID_ECC_CURVE_SECP224K1 = "1.3.132.0.32";

		/// <summary/>
		public const string szOID_ECC_CURVE_SECP224R1 = szOID_ECC_CURVE_NISTP224;

		/// <summary/>
		public const string szOID_ECC_CURVE_SECP256K1 = "1.3.132.0.10";

		/// <summary/>
		public const string szOID_ECC_CURVE_SECP256R1 = szOID_ECC_CURVE_P256;

		/// <summary/>
		public const string szOID_ECC_CURVE_SECP384R1 = szOID_ECC_CURVE_P384;

		/// <summary/>
		public const string szOID_ECC_CURVE_SECP521R1 = szOID_ECC_CURVE_P521;

		/// <summary/>
		public const string szOID_ECC_CURVE_WTLS12 = szOID_ECC_CURVE_NISTP224;

		/// <summary/>
		public const string szOID_ECC_CURVE_WTLS7 = szOID_ECC_CURVE_SECP160R2;

		/// <summary/>
		public const string szOID_ECC_CURVE_WTLS9 = "2.23.43.1.4.9";

		/// <summary/>
		public const string szOID_ECC_CURVE_X962P192V1 = "1.2.840.10045.3.1.1";

		/// <summary/>
		public const string szOID_ECC_CURVE_X962P192V2 = "1.2.840.10045.3.1.2";

		/// <summary/>
		public const string szOID_ECC_CURVE_X962P192V3 = "1.2.840.10045.3.1.3";

		/// <summary/>
		public const string szOID_ECC_CURVE_X962P239V1 = "1.2.840.10045.3.1.4";

		/// <summary/>
		public const string szOID_ECC_CURVE_X962P239V2 = "1.2.840.10045.3.1.5";

		/// <summary/>
		public const string szOID_ECC_CURVE_X962P239V3 = "1.2.840.10045.3.1.6";

		/// <summary/>
		public const string szOID_ECC_CURVE_X962P256V1 = szOID_ECC_CURVE_P256;

		/// <summary/>
		public const string szOID_ECC_PUBLIC_KEY = "1.2.840.10045.2.1";

		/// <summary/>
		public const string szOID_ECDSA_SHA1 = "1.2.840.10045.4.1";

		/// <summary/>
		public const string szOID_ECDSA_SHA256 = "1.2.840.10045.4.3.2";

		/// <summary/>
		public const string szOID_ECDSA_SHA384 = "1.2.840.10045.4.3.3";

		/// <summary/>
		public const string szOID_ECDSA_SHA512 = "1.2.840.10045.4.3.4";

		/// <summary/>
		public const string szOID_ECDSA_SPECIFIED = "1.2.840.10045.4.3";

		/// <summary/>
		public const string szOID_INFOSEC = "2.16.840.1.101.2.1";

		/// <summary/>
		public const string szOID_INFOSEC_mosaicConfidentiality = "2.16.840.1.101.2.1.1.4";

		/// <summary/>
		public const string szOID_INFOSEC_mosaicIntegrity = "2.16.840.1.101.2.1.1.6";

		/// <summary/>
		public const string szOID_INFOSEC_mosaicKeyManagement = "2.16.840.1.101.2.1.1.10";

		/// <summary/>
		public const string szOID_INFOSEC_mosaicKMandSig = "2.16.840.1.101.2.1.1.12";

		/// <summary/>
		public const string szOID_INFOSEC_mosaicKMandUpdSig = "2.16.840.1.101.2.1.1.20";

		/// <summary/>
		public const string szOID_INFOSEC_mosaicSignature = "2.16.840.1.101.2.1.1.2";

		/// <summary/>
		public const string szOID_INFOSEC_mosaicTokenProtection = "2.16.840.1.101.2.1.1.8";

		/// <summary/>
		public const string szOID_INFOSEC_mosaicUpdatedInteg = "2.16.840.1.101.2.1.1.21";

		/// <summary/>
		public const string szOID_INFOSEC_mosaicUpdatedSig = "2.16.840.1.101.2.1.1.19";

		/// <summary/>
		public const string szOID_INFOSEC_sdnsConfidentiality = "2.16.840.1.101.2.1.1.3";

		/// <summary/>
		public const string szOID_INFOSEC_sdnsIntegrity = "2.16.840.1.101.2.1.1.5";

		/// <summary/>
		public const string szOID_INFOSEC_sdnsKeyManagement = "2.16.840.1.101.2.1.1.9";

		/// <summary/>
		public const string szOID_INFOSEC_sdnsKMandSig = "2.16.840.1.101.2.1.1.11";

		/// <summary/>
		public const string szOID_INFOSEC_sdnsSignature = "2.16.840.1.101.2.1.1.1";

		/// <summary/>
		public const string szOID_INFOSEC_sdnsTokenProtection = "2.16.840.1.101.2.1.1.7";

		/// <summary/>
		public const string szOID_INFOSEC_SuiteAConfidentiality = "2.16.840.1.101.2.1.1.14";

		/// <summary/>
		public const string szOID_INFOSEC_SuiteAIntegrity = "2.16.840.1.101.2.1.1.15";

		/// <summary/>
		public const string szOID_INFOSEC_SuiteAKeyManagement = "2.16.840.1.101.2.1.1.17";

		/// <summary/>
		public const string szOID_INFOSEC_SuiteAKMandSig = "2.16.840.1.101.2.1.1.18";

		/// <summary/>
		public const string szOID_INFOSEC_SuiteASignature = "2.16.840.1.101.2.1.1.13";

		/// <summary/>
		public const string szOID_INFOSEC_SuiteATokenProtection = "2.16.840.1.101.2.1.1.16";

		/// <summary/>
		public const string szOID_NIST_AES128_CBC = "2.16.840.1.101.3.4.1.2";

		/// <summary/>
		public const string szOID_NIST_AES128_WRAP = "2.16.840.1.101.3.4.1.5";

		/// <summary/>
		public const string szOID_NIST_AES192_CBC = "2.16.840.1.101.3.4.1.22";

		/// <summary/>
		public const string szOID_NIST_AES192_WRAP = "2.16.840.1.101.3.4.1.25";

		/// <summary/>
		public const string szOID_NIST_AES256_CBC = "2.16.840.1.101.3.4.1.42";

		/// <summary/>
		public const string szOID_NIST_AES256_WRAP = "2.16.840.1.101.3.4.1.45";

		/// <summary/>
		public const string szOID_NIST_sha256 = "2.16.840.1.101.3.4.2.1";

		/// <summary/>
		public const string szOID_NIST_sha384 = "2.16.840.1.101.3.4.2.2";

		/// <summary/>
		public const string szOID_NIST_sha512 = "2.16.840.1.101.3.4.2.3";

		/// <summary/>
		public const string szOID_OIW = "1.3.14";

		/// <summary/>
		public const string szOID_OIWDIR = "1.3.14.7.2";

		/// <summary/>
		public const string szOID_OIWDIR_CRPT = "1.3.14.7.2.1";

		/// <summary/>
		public const string szOID_OIWDIR_HASH = "1.3.14.7.2.2";

		/// <summary/>
		public const string szOID_OIWDIR_md2 = "1.3.14.7.2.2.1";

		/// <summary/>
		public const string szOID_OIWDIR_md2RSA = "1.3.14.7.2.3.1";

		/// <summary/>
		public const string szOID_OIWDIR_SIGN = "1.3.14.7.2.3";

		/// <summary/>
		public const string szOID_OIWSEC = "1.3.14.3.2";

		/// <summary/>
		public const string szOID_OIWSEC_desCBC = "1.3.14.3.2.7";

		/// <summary/>
		public const string szOID_OIWSEC_desCFB = "1.3.14.3.2.9";

		/// <summary/>
		public const string szOID_OIWSEC_desECB = "1.3.14.3.2.6";

		/// <summary/>
		public const string szOID_OIWSEC_desEDE = "1.3.14.3.2.17";

		/// <summary/>
		public const string szOID_OIWSEC_desMAC = "1.3.14.3.2.10";

		/// <summary/>
		public const string szOID_OIWSEC_desOFB = "1.3.14.3.2.8";

		/// <summary/>
		public const string szOID_OIWSEC_dhCommMod = "1.3.14.3.2.16";

		/// <summary/>
		public const string szOID_OIWSEC_dsa = "1.3.14.3.2.12";

		/// <summary/>
		public const string szOID_OIWSEC_dsaComm = "1.3.14.3.2.20";

		/// <summary/>
		public const string szOID_OIWSEC_dsaCommSHA = "1.3.14.3.2.21";

		/// <summary/>
		public const string szOID_OIWSEC_dsaCommSHA1 = "1.3.14.3.2.28";

		/// <summary/>
		public const string szOID_OIWSEC_dsaSHA1 = "1.3.14.3.2.27";

		/// <summary/>
		public const string szOID_OIWSEC_keyHashSeal = "1.3.14.3.2.23";

		/// <summary/>
		public const string szOID_OIWSEC_md2RSASign = "1.3.14.3.2.24";

		/// <summary/>
		public const string szOID_OIWSEC_md4RSA = "1.3.14.3.2.2";

		/// <summary/>
		public const string szOID_OIWSEC_md4RSA2 = "1.3.14.3.2.4";

		/// <summary/>
		public const string szOID_OIWSEC_md5RSA = "1.3.14.3.2.3";

		/// <summary/>
		public const string szOID_OIWSEC_md5RSASign = "1.3.14.3.2.25";

		/// <summary/>
		public const string szOID_OIWSEC_mdc2 = "1.3.14.3.2.19";

		/// <summary/>
		public const string szOID_OIWSEC_mdc2RSA = "1.3.14.3.2.14";

		/// <summary/>
		public const string szOID_OIWSEC_rsaSign = "1.3.14.3.2.11";

		/// <summary/>
		public const string szOID_OIWSEC_rsaXchg = "1.3.14.3.2.22";

		/// <summary/>
		public const string szOID_OIWSEC_sha = "1.3.14.3.2.18";

		/// <summary/>
		public const string szOID_OIWSEC_sha1 = "1.3.14.3.2.26";

		/// <summary/>
		public const string szOID_OIWSEC_sha1RSASign = "1.3.14.3.2.29";

		/// <summary/>
		public const string szOID_OIWSEC_shaDSA = "1.3.14.3.2.13";

		/// <summary/>
		public const string szOID_OIWSEC_shaRSA = "1.3.14.3.2.15";

		/// <summary/>
		public const string szOID_PKCS = "1.2.840.113549.1";

		/// <summary/>
		public const string szOID_PKCS_1 = "1.2.840.113549.1.1";

		/// <summary/>
		public const string szOID_PKCS_10 = "1.2.840.113549.1.10";

		/// <summary/>
		public const string szOID_PKCS_12 = "1.2.840.113549.1.12";

		/// <summary/>
		public const string szOID_PKCS_2 = "1.2.840.113549.1.2";

		/// <summary/>
		public const string szOID_PKCS_3 = "1.2.840.113549.1.3";

		/// <summary/>
		public const string szOID_PKCS_4 = "1.2.840.113549.1.4";

		/// <summary/>
		public const string szOID_PKCS_5 = "1.2.840.113549.1.5";

		/// <summary/>
		public const string szOID_PKCS_6 = "1.2.840.113549.1.6";

		/// <summary/>
		public const string szOID_PKCS_7 = "1.2.840.113549.1.7";

		/// <summary/>
		public const string szOID_PKCS_8 = "1.2.840.113549.1.8";

		/// <summary/>
		public const string szOID_PKCS_9 = "1.2.840.113549.1.9";

		/// <summary/>
		public const string szOID_RFC3161_counterSign = "1.3.6.1.4.1.311.3.3.1";

		/// <summary/>
		public const string szOID_RSA = "1.2.840.113549";

		/// <summary/>
		public const string szOID_RSA_certExtensions = "1.2.840.113549.1.9.14";

		/// <summary/>
		public const string szOID_RSA_challengePwd = "1.2.840.113549.1.9.7";

		/// <summary/>
		public const string szOID_RSA_contentType = "1.2.840.113549.1.9.3";

		/// <summary/>
		public const string szOID_RSA_counterSign = "1.2.840.113549.1.9.6";

		/// <summary/>
		public const string szOID_RSA_data = "1.2.840.113549.1.7.1";

		/// <summary/>
		public const string szOID_RSA_DES_EDE3_CBC = "1.2.840.113549.3.7";

		/// <summary/>
		public const string szOID_RSA_DH = "1.2.840.113549.1.3.1";

		/// <summary/>
		public const string szOID_RSA_digestedData = "1.2.840.113549.1.7.5";

		/// <summary/>
		public const string szOID_RSA_emailAddr = "1.2.840.113549.1.9.1";

		/// <summary/>
		public const string szOID_RSA_ENCRYPT = "1.2.840.113549.3";

		/// <summary/>
		public const string szOID_RSA_encryptedData = "1.2.840.113549.1.7.6";

		/// <summary/>
		public const string szOID_RSA_envelopedData = "1.2.840.113549.1.7.3";

		/// <summary/>
		public const string szOID_RSA_extCertAttrs = "1.2.840.113549.1.9.9";

		/// <summary/>
		public const string szOID_RSA_HASH = "1.2.840.113549.2";

		/// <summary/>
		public const string szOID_RSA_hashedData = "1.2.840.113549.1.7.5";

		/// <summary/>
		public const string szOID_RSA_MD2 = "1.2.840.113549.2.2";

		/// <summary/>
		public const string szOID_RSA_MD2RSA = "1.2.840.113549.1.1.2";

		/// <summary/>
		public const string szOID_RSA_MD4 = "1.2.840.113549.2.4";

		/// <summary/>
		public const string szOID_RSA_MD4RSA = "1.2.840.113549.1.1.3";

		/// <summary/>
		public const string szOID_RSA_MD5 = "1.2.840.113549.2.5";

		/// <summary/>
		public const string szOID_RSA_MD5RSA = "1.2.840.113549.1.1.4";

		/// <summary/>
		public const string szOID_RSA_messageDigest = "1.2.840.113549.1.9.4";

		/// <summary/>
		public const string szOID_RSA_MGF1 = "1.2.840.113549.1.1.8";

		/// <summary/>
		public const string szOID_RSA_preferSignedData = "1.2.840.113549.1.9.15.1";

		/// <summary/>
		public const string szOID_RSA_PSPECIFIED = "1.2.840.113549.1.1.9";

		/// <summary/>
		public const string szOID_RSA_RC2CBC = "1.2.840.113549.3.2";

		/// <summary/>
		public const string szOID_RSA_RC4 = "1.2.840.113549.3.4";

		/// <summary/>
		public const string szOID_RSA_RC5_CBCPad = "1.2.840.113549.3.9";

		/// <summary/>
		public const string szOID_RSA_RSA = "1.2.840.113549.1.1.1";

		/// <summary/>
		public const string szOID_RSA_SETOAEP_RSA = "1.2.840.113549.1.1.6";

		/// <summary/>
		public const string szOID_RSA_SHA1RSA = "1.2.840.113549.1.1.5";

		/// <summary/>
		public const string szOID_RSA_SHA256RSA = "1.2.840.113549.1.1.11";

		/// <summary/>
		public const string szOID_RSA_SHA384RSA = "1.2.840.113549.1.1.12";

		/// <summary/>
		public const string szOID_RSA_SHA512RSA = "1.2.840.113549.1.1.13";

		/// <summary/>
		public const string szOID_RSA_signedData = "1.2.840.113549.1.7.2";

		/// <summary/>
		public const string szOID_RSA_signEnvData = "1.2.840.113549.1.7.4";

		/// <summary/>
		public const string szOID_RSA_signingTime = "1.2.840.113549.1.9.5";

		/// <summary/>
		public const string szOID_RSA_SMIMEalg = "1.2.840.113549.1.9.16.3";

		/// <summary/>
		public const string szOID_RSA_SMIMEalgCMS3DESwrap = "1.2.840.113549.1.9.16.3.6";

		/// <summary/>
		public const string szOID_RSA_SMIMEalgCMSRC2wrap = "1.2.840.113549.1.9.16.3.7";

		/// <summary/>
		public const string szOID_RSA_SMIMEalgESDH = "1.2.840.113549.1.9.16.3.5";

		/// <summary/>
		public const string szOID_RSA_SMIMECapabilities = "1.2.840.113549.1.9.15";

		/// <summary/>
		public const string szOID_RSA_SSA_PSS = "1.2.840.113549.1.1.10";

		/// <summary/>
		public const string szOID_RSA_unstructAddr = "1.2.840.113549.1.9.8";

		/// <summary/>
		public const string szOID_RSA_unstructName = "1.2.840.113549.1.9.2";

		/// <summary/>
		public const string szOID_RSAES_OAEP = "1.2.840.113549.1.1.7";

		/// <summary/>
		public const string szOID_TIMESTAMP_TOKEN = "1.2.840.113549.1.9.16.1.4";

		/// <summary/>
		public const string szOID_X957 = "1.2.840.10040";

		/// <summary/>
		public const string szOID_X957_DSA = "1.2.840.10040.4.1";

		/// <summary/>
		public const string szOID_X957_SHA1DSA = "1.2.840.10040.4.3";
	}

	/// <summary>Definitions of various attribute object identifiers RSA</summary>
	[PInvokeData("wincrypt.h")]
	public static class AttrOID
	{
		/// <summary/>
		public const string szOID_AUTHORITY_REVOCATION_LIST = "2.5.4.38";

		/// <summary/>
		public const string szOID_BUSINESS_CATEGORY = "2.5.4.15";

		/// <summary/>
		public const string szOID_CA_CERTIFICATE = "2.5.4.37";

		/// <summary/>
		public const string szOID_CERTIFICATE_REVOCATION_LIST = "2.5.4.39";

		/// <summary/>
		public const string szOID_COMMON_NAME = "2.5.4.3";

		/// <summary/>
		public const string szOID_COUNTRY_NAME = "2.5.4.6";

		/// <summary/>
		public const string szOID_CROSS_CERTIFICATE_PAIR = "2.5.4.40";

		/// <summary/>
		public const string szOID_DESCRIPTION = "2.5.4.13";

		/// <summary/>
		public const string szOID_DESTINATION_INDICATOR = "2.5.4.27";

		/// <summary/>
		public const string szOID_DEVICE_SERIAL_NUMBER = "2.5.4.5";

		/// <summary/>
		public const string szOID_DN_QUALIFIER = "2.5.4.46";

		/// <summary/>
		public const string szOID_DOMAIN_COMPONENT = "0.9.2342.19200300.100.1.25";

		/// <summary/>
		public const string szOID_EV_RDN_COUNTRY = "1.3.6.1.4.1.311.60.2.1.3";

		/// <summary/>
		public const string szOID_EV_RDN_LOCALE = "1.3.6.1.4.1.311.60.2.1.1";

		/// <summary/>
		public const string szOID_EV_RDN_STATE_OR_PROVINCE = "1.3.6.1.4.1.311.60.2.1.2";

		/// <summary/>
		public const string szOID_FACSIMILE_TELEPHONE_NUMBER = "2.5.4.23";

		/// <summary/>
		public const string szOID_GIVEN_NAME = "2.5.4.42";

		/// <summary/>
		public const string szOID_INITIALS = "2.5.4.43";

		/// <summary/>
		public const string szOID_INTERNATIONAL_ISDN_NUMBER = "2.5.4.25";

		/// <summary/>
		public const string szOID_KEYID_RDN = "1.3.6.1.4.1.311.10.7.1";

		/// <summary/>
		public const string szOID_LOCAL_MACHINE_KEYSET = "1.3.6.1.4.1.311.17.2";

		/// <summary/>
		public const string szOID_LOCALITY_NAME = "2.5.4.7";

		/// <summary/>
		public const string szOID_MEMBER = "2.5.4.31";

		/// <summary/>
		public const string szOID_ORGANIZATION_NAME = "2.5.4.10";

		/// <summary/>
		public const string szOID_ORGANIZATIONAL_UNIT_NAME = "2.5.4.11";

		/// <summary/>
		public const string szOID_OWNER = "2.5.4.32";

		/// <summary/>
		public const string szOID_PHYSICAL_DELIVERY_OFFICE_NAME = "2.5.4.19";

		/// <summary/>
		public const string szOID_PKCS_12_EXTENDED_ATTRIBUTES = "1.3.6.1.4.1.311.17.3";

		/// <summary/>
		public const string szOID_PKCS_12_FRIENDLY_NAME_ATTR = "1.2.840.113549.1.9.20";

		/// <summary/>
		public const string szOID_PKCS_12_KEY_PROVIDER_NAME_ATTR = "1.3.6.1.4.1.311.17.1";

		/// <summary/>
		public const string szOID_PKCS_12_LOCAL_KEY_ID = "1.2.840.113549.1.9.21";

		/// <summary/>
		public const string szOID_PKCS_12_PROTECTED_PASSWORD_SECRET_BAG_TYPE_ID = "1.3.6.1.4.1.311.17.4";

		/// <summary/>
		public const string szOID_POST_OFFICE_BOX = "2.5.4.18";

		/// <summary/>
		public const string szOID_POSTAL_ADDRESS = "2.5.4.16";

		/// <summary/>
		public const string szOID_POSTAL_CODE = "2.5.4.17";

		/// <summary/>
		public const string szOID_PREFERRED_DELIVERY_METHOD = "2.5.4.28";

		/// <summary/>
		public const string szOID_PRESENTATION_ADDRESS = "2.5.4.29";

		/// <summary/>
		public const string szOID_REGISTERED_ADDRESS = "2.5.4.26";

		/// <summary/>
		public const string szOID_ROLE_OCCUPANT = "2.5.4.33";

		/// <summary/>
		public const string szOID_SEARCH_GUIDE = "2.5.4.14";

		/// <summary/>
		public const string szOID_SEE_ALSO = "2.5.4.34";

		/// <summary/>
		public const string szOID_STATE_OR_PROVINCE_NAME = "2.5.4.8";

		/// <summary/>
		public const string szOID_STREET_ADDRESS = "2.5.4.9";

		/// <summary/>
		public const string szOID_SUPPORTED_APPLICATION_CONTEXT = "2.5.4.30";

		/// <summary/>
		public const string szOID_SUR_NAME = "2.5.4.4";

		/// <summary/>
		public const string szOID_TELEPHONE_NUMBER = "2.5.4.20";

		/// <summary/>
		public const string szOID_TELETEXT_TERMINAL_IDENTIFIER = "2.5.4.22";

		/// <summary/>
		public const string szOID_TELEX_NUMBER = "2.5.4.21";

		/// <summary/>
		public const string szOID_TITLE = "2.5.4.12";

		/// <summary/>
		public const string szOID_USER_CERTIFICATE = "2.5.4.36";

		/// <summary/>
		public const string szOID_USER_PASSWORD = "2.5.4.35";

		/// <summary/>
		public const string szOID_X21_ADDRESS = "2.5.4.24";
	}

	/// <summary>OID Strong Sign Parameters used by Windows OS Components</summary>
	[PInvokeData("wincrypt.h")]
	public static class SignOID
	{
		/// <summary/>
		public const string szOID_CERT_STRONG_SIGN_OS_PREFIX = "1.3.6.1.4.1.311.72.1.";

		/// <summary/>
		public const string szOID_CERT_STRONG_SIGN_OS_1 = "1.3.6.1.4.1.311.72.1.1";

		/// <summary/>
		public const string szOID_CERT_STRONG_SIGN_OS_CURRENT = szOID_CERT_STRONG_SIGN_OS_1;


		/// <summary/>
		public const string szOID_CERT_STRONG_KEY_OS_PREFIX = "1.3.6.1.4.1.311.72.2.";

		/// <summary/>
		public const string szOID_CERT_STRONG_KEY_OS_1 = "1.3.6.1.4.1.311.72.2.1";

		/// <summary/>
		public const string szOID_CERT_STRONG_KEY_OS_CURRENT = szOID_CERT_STRONG_KEY_OS_1;
	}
}