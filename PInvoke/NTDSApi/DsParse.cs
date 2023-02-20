using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class NTDSApi
	{
		/// <summary>
		/// <para>
		/// The <c>DS_MANGLE_FOR</c> enumeration is used to define whether a relative distinguished name is mangled (encoded) and in what
		/// form the mangling occurs.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsparse/ne-dsparse-_ds_mangle_for typedef enum _DS_MANGLE_FOR {
		// DS_MANGLE_UNKNOWN , DS_MANGLE_OBJECT_RDN_FOR_DELETION , DS_MANGLE_OBJECT_RDN_FOR_NAME_CONFLICT } DS_MANGLE_FOR;
		[PInvokeData("dsparse.h", MSDNShortId = "79a66a54-889e-464e-8199-ad911ea84a86")]
		public enum DS_MANGLE_FOR
		{
			/// <summary>Indicates that the relative distinguished name is not mangled or that the type of mangling is unknown.</summary>
			DS_MANGLE_UNKNOWN,

			/// <summary>Indicates that the relative distinguished name has been mangled for deletion.</summary>
			DS_MANGLE_OBJECT_RDN_FOR_DELETION,

			/// <summary>Indicates that the relative distinguished name has been mangled due to a naming conflict.</summary>
			DS_MANGLE_OBJECT_RDN_FOR_NAME_CONFLICT,
		}

		/// <summary>
		/// <para>The <c>DsCrackSpn</c> function parses a service principal name (SPN) into its component strings.</para>
		/// </summary>
		/// <param name="pszSpn">
		/// <para>
		/// Pointer to a constant null-terminated string that contains the SPN to parse. The SPN has the following format, in which the
		/// &lt;service class&gt; and &lt;instance name&gt; components must be present and the &lt;port number&gt; and &lt;service name&gt;
		/// components are optional. The &lt;port number&gt; component must be a numeric string value.
		/// </para>
		/// </param>
		/// <param name="pcServiceClass">
		/// <para>
		/// Pointer to a <c>DWORD</c> value that, on entry, contains the size, in <c>TCHARs</c>, of the ServiceClass buffer, including the
		/// terminating null character. On exit, this parameter contains the number of <c>TCHARs</c> in the ServiceClass string, including
		/// the terminating null character.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, contains zero, or ServiceClass is <c>NULL</c>, this parameter and ServiceClass are ignored.</para>
		/// <para>
		/// To obtain the number of characters required for the ServiceClass string, including the null terminator, call this function with a
		/// valid SPN, a non- <c>NULL</c> ServiceClass and this parameter set to 1.
		/// </para>
		/// </param>
		/// <param name="ServiceClass">
		/// <para>
		/// Pointer to a <c>TCHAR</c> buffer that receives a null-terminated string containing the &lt;service class&gt; component of the
		/// SPN. This buffer must be at least *pcServiceClass <c>TCHARs</c> in size. This parameter may be <c>NULL</c> if the service class
		/// is not required.
		/// </para>
		/// </param>
		/// <param name="pcServiceName">
		/// <para>
		/// Pointer to a <c>DWORD</c> value that, on entry, contains the size, in <c>TCHARs</c>, of the ServiceName buffer, including the
		/// terminating null character. On exit, this parameter contains the number of <c>TCHARs</c> in the ServiceName string, including the
		/// terminating null character.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, contains zero, or ServiceName is <c>NULL</c>, this parameter and ServiceName are ignored.</para>
		/// <para>
		/// To obtain the number of characters required for the ServiceName string, including the null terminator, call this function with a
		/// valid SPN, a non- <c>NULL</c> ServiceName and this parameter set to 1.
		/// </para>
		/// </param>
		/// <param name="ServiceName">
		/// <para>
		/// Pointer to a <c>TCHAR</c> buffer that receives a null-terminated string containing the &lt;service name&gt; component of the SPN.
		/// This buffer must be at least *pcServiceName <c>TCHARs</c> in size. If the &lt;service name&gt; component is not present in the
		/// SPN, this buffer receives the &lt;instance name&gt; component. This parameter may be <c>NULL</c> if the service name is not required.
		/// </para>
		/// </param>
		/// <param name="pcInstanceName">
		/// <para>
		/// Pointer to a <c>DWORD</c> value that, on entry, contains the size, in <c>TCHARs</c>, of the InstanceName buffer, including the
		/// terminating null character. On exit, this parameter contains the number of <c>TCHARs</c> in the InstanceName string, including
		/// the terminating null character.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, contains zero, or InstanceName is <c>NULL</c>, this parameter and InstanceName are ignored.</para>
		/// <para>
		/// To obtain the number of characters required for the InstanceName string, including the null terminator, call this function with a
		/// valid SPN, a non- <c>NULL</c> InstanceName and this parameter set to 1.
		/// </para>
		/// </param>
		/// <param name="InstanceName">
		/// <para>
		/// Pointer to a <c>TCHAR</c> buffer that receives a null-terminated string containing the &lt;instance name&gt; component of the
		/// SPN. This buffer must be at least *pcInstanceName <c>TCHARs</c> in size. This parameter may be <c>NULL</c> if the instance name
		/// is not required.
		/// </para>
		/// </param>
		/// <param name="pInstancePort">
		/// <para>
		/// Pointer to a <c>DWORD</c> value that receives the integer value of the &lt;port number&gt; component of the SPN. If the SPN does
		/// not contain a &lt;port number&gt; component, this parameter receives zero. This parameter may be <c>NULL</c> if the port number
		/// is not required.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Returns a Win32 error code, including the following.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsparse/nf-dsparse-dscrackspna DSPARSE DWORD DsCrackSpnA( LPCSTR pszSpn,
		// LPDWORD pcServiceClass, LPSTR ServiceClass, LPDWORD pcServiceName, LPSTR ServiceName, LPDWORD pcInstanceName, LPSTR InstanceName,
		// USHORT *pInstancePort );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("dsparse.h", MSDNShortId = "65c81c23-a259-480c-9c1e-03484d3e89c9")]
		public static extern Win32Error DsCrackSpn(string pszSpn, ref uint pcServiceClass, StringBuilder ServiceClass, ref uint pcServiceName,
			[Optional] StringBuilder? ServiceName, ref uint pcInstanceName, [Optional] StringBuilder? InstanceName, out ushort pInstancePort);

		/// <summary>
		/// <para>
		/// The <c>DsCrackUnquotedMangledRdn</c> function unmangles (unencodes) a given relative distinguished name and returns both the
		/// decoded GUID and the mangling type used.
		/// </para>
		/// </summary>
		/// <param name="pszRDN">
		/// <para>
		/// Pointer to a string that contains the relative distinguished name (RDN) to translate. This string length is specified by the
		/// cchRDN parameter, so this string is not required to be null-terminated. This string must be in unquoted form. For more
		/// information about unquoted relative distinguished names, see DsUnquoteRdnValue.
		/// </para>
		/// </param>
		/// <param name="cchRDN">
		/// <para>Contains the length, in characters, of the pszRDN string.</para>
		/// </param>
		/// <param name="pGuid">
		/// <para>
		/// Pointer to <c>GUID</c> value that receives the GUID of the unmangled relative distinguished name. This parameter can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="peDsMangleFor">
		/// <para>
		/// Pointer to a DS_MANGLE_FOR value that receives the type of mangling used in the mangled relative distinguished name. This
		/// parameter can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// This function returns <c>TRUE</c> if the relative distinguished name is mangled or <c>FALSE</c> otherwise. If this function
		/// returns <c>FALSE</c>, neither pGuid or peDsMangleFor receive any data.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function attempts to decode (unmangle) an RDN that has been previously mangled due to a deletion or a naming conflict. If
		/// the relative distinguished name is mangled, the function returns <c>TRUE</c> and retrieves the GUID and mangle type, if
		/// requested. If the relative distinguished name is not mangled, the function returns <c>FALSE</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsparse/nf-dsparse-dscrackunquotedmangledrdna DSPARSE BOOL
		// DsCrackUnquotedMangledRdnA( LPCSTR pszRDN, DWORD cchRDN, GUID *pGuid, DS_MANGLE_FOR *peDsMangleFor );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("dsparse.h", MSDNShortId = "30711d2d-f541-46b4-a301-a0f9fc7d6676")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DsCrackUnquotedMangledRdn(string pszRDN, uint cchRDN, out Guid pGuid, out DS_MANGLE_FOR peDsMangleFor);

		/// <summary>
		/// <para>
		/// The <c>DsGetRdnW</c> function retrieves the key and value of the first relative distinguished name and a pointer to the next
		/// relative distinguished name from a distinguished name string.
		/// </para>
		/// </summary>
		/// <param name="ppDN">
		/// <para>
		/// Address of a Unicode string pointer that, on entry, contains the distinguished name string to be parsed. The length of this
		/// string is specified in the pcDN parameter. If the function succeeds, this parameter is adjusted to point to the remainder of the
		/// distinguished name exclusive of current relative distinguished name. For example, if this parameter points to the string
		/// "dc=corp,dc=fabrikam,dc=com", after the function is complete this parameter points to the string ",dc=fabrikam,dc=com".
		/// </para>
		/// </param>
		/// <param name="pcDN">
		/// <para>
		/// Pointer to a <c>DWORD</c> value that, on entry, contains the number of characters in the ppDN string. If the function succeeds,
		/// this parameter receives the number of characters in the remainder of the distinguished name. These values do not include the
		/// null-terminated character.
		/// </para>
		/// </param>
		/// <param name="ppKey">
		/// <para>
		/// Pointer to a <c>LPCWCH</c> value that, if the function succeeds, receives a pointer to the key in the relative distinguished name
		/// string. This pointer is within the ppDN string and is not null-terminated. The pcKey parameter receives the number of characters
		/// in the key. This parameter is undefined if pcKey receives zero.
		/// </para>
		/// </param>
		/// <param name="pcKey">
		/// <para>
		/// Pointer to a <c>DWORD</c> value that, if the function succeeds, receives the number of characters in the key string represented
		/// by the ppKey parameter. If this parameter receives zero, ppKey is undefined.
		/// </para>
		/// </param>
		/// <param name="ppVal">
		/// <para>
		/// Pointer to a <c>LPCWCH</c> value that, if the function is successful, receives a pointer to the value in the relative
		/// distinguished name string. This pointer is within the ppDN string and is not null-terminated. The pcVal parameter receives the
		/// number of characters in the value. This parameter is undefined if pcVal receives zero.
		/// </para>
		/// </param>
		/// <param name="pcVal">
		/// <para>
		/// Pointer to a <c>DWORD</c> value that, if the function succeeds, receives the number of characters in the value string represented
		/// by the ppVal parameter. If this parameter receives zero, ppVal is undefined.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>ERROR_SUCCESS</c> if successful or a Win32 error code otherwise. Possible error codes include the following values.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsparse/nf-dsparse-dsgetrdnw DSPARSE DWORD DsGetRdnW( LPCWCH *ppDN, DWORD
		// *pcDN, LPCWCH *ppKey, DWORD *pcKey, LPCWCH *ppVal, DWORD *pcVal );
		[DllImport(Lib.NTDSApi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("dsparse.h", MSDNShortId = "22627f2e-adfb-49de-bae5-20aaf69830ac")]
		public static extern Win32Error DsGetRdnW(ref IntPtr ppDN, ref uint pcDN, ref IntPtr ppKey, out uint pcKey, ref IntPtr ppVal, out uint pcVal);

		/// <summary>
		/// The <c>DsGetRdnW</c> function retrieves the key and value of the first relative distinguished name and a pointer to the next
		/// relative distinguished name from a distinguished name string.
		/// </summary>
		/// <param name="fullDN">Address of a string that contains the distinguished name string to be parsed.</param>
		/// <param name="dn">A string that recieves the remainder of the distinguished name exclusive of current relative distinguished name.</param>
		/// <param name="key">A string that, if the function succeeds, receives the key in the relative distinguished name string.</param>
		/// <param name="val">A string that, if the function is successful, receives the value in the relative distinguished name string.</param>
		/// <returns>Returns <c>ERROR_SUCCESS</c> if successful or a Win32 error code otherwise.</returns>
		[PInvokeData("dsparse.h", MSDNShortId = "22627f2e-adfb-49de-bae5-20aaf69830ac")]
		public static Win32Error DsGetRdnW(string fullDN, out string? dn, out string? key, out string? val)
		{
			var s = new SafeCoTaskMemString(fullDN, CharSet.Unicode);
			IntPtr ppDN = s.DangerousGetHandle(), ppKey = IntPtr.Zero, ppVal = IntPtr.Zero;
			var cDN = (uint)fullDN.Length;
			var ret = DsGetRdnW(ref ppDN, ref cDN, ref ppKey, out var cKey, ref ppVal, out var cVal);
			if (ret != 0)
			{
				dn = key = val = null;
			}
			else
			{
				dn = StringHelper.GetString(ppDN, (int)cDN, CharSet.Unicode);
				key = StringHelper.GetString(ppKey, (int)cKey, CharSet.Unicode);
				val = StringHelper.GetString(ppVal, (int)cVal, CharSet.Unicode);
			}
			return ret;
		}

		/// <summary>
		/// <para>
		/// The <c>DsIsMangledDn</c> function determines if the first relative distinguished name (RDN) in a distinguished name (DN) is a
		/// mangled name of a given type.
		/// </para>
		/// </summary>
		/// <param name="pszDn">
		/// <para>
		/// Pointer to a null-terminated string that contains the distinguished name to retrieve the relative distinguished name from. This
		/// can also be a quoted distinguished name as returned by other directory service functions.
		/// </para>
		/// </param>
		/// <param name="eDsMangleFor">
		/// <para>Contains one of the DS_MANGLE_FOR values that specifies the type of name mangling to look for.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if the first relative distinguished name in pszDn is mangled in the manner specified by eDsMangleFor or
		/// <c>FALSE</c> otherwise.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsparse/nf-dsparse-dsismangleddna DSPARSE BOOL DsIsMangledDnA( LPCSTR pszDn,
		// DS_MANGLE_FOR eDsMangleFor );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("dsparse.h", MSDNShortId = "e4aaa83c-3bd6-48db-9d34-367b76ba629c")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DsIsMangledDn(string pszDn, DS_MANGLE_FOR eDsMangleFor);

		/// <summary>
		/// <para>
		/// The <c>DsIsMangledRdnValue</c> function determines if a given relative distinguished name value is a mangled name of the given type.
		/// </para>
		/// </summary>
		/// <param name="pszRdn">
		/// <para>
		/// Pointer to a null-terminated string that contains the relative distinguished name to determine if it is mangled. The cRdn
		/// parameter contains the number of characters in this string.
		/// </para>
		/// </param>
		/// <param name="cRdn">
		/// <para>Contains the number of characters in the pszRdn string.</para>
		/// </param>
		/// <param name="eDsMangleForDesired">
		/// <para>Contains one of the DS_MANGLE_FOR values that specifies the type of name mangling to search for.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if the relative distinguished name is mangled and the mangle type is the same as specified. Returns
		/// <c>FALSE</c> if the relative distinguished name is not mangled or the mangle type is different than specified.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function determines if the given relative distinguished name value is mangled and mangled in the given type. The pszRdn
		/// parameter should only contain the value of the relative distinguished name and not the key. The relative distinguished name value
		/// may be quoted or unquoted.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsparse/nf-dsparse-dsismangledrdnvaluea DSPARSE BOOL DsIsMangledRdnValueA(
		// LPCSTR pszRdn, DWORD cRdn, DS_MANGLE_FOR eDsMangleForDesired );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("dsparse.h", MSDNShortId = "adf5e133-9e48-4e97-af0c-4f8ea9b8bf8f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DsIsMangledRdnValue(string pszRdn, uint cRdn, DS_MANGLE_FOR eDsMangleForDesired);

		/// <summary>
		/// <para>The <c>DsMakeSpn</c> function constructs a service principal name (SPN) that identifies a service instance.</para>
		/// <para>
		/// A client application uses this function to compose an SPN, which it uses to authenticate the service instance. For example, the
		/// client can pass an SPN in the pszTargetName parameter of the InitializeSecurityContext function.
		/// </para>
		/// </summary>
		/// <param name="ServiceClass">
		/// <para>
		/// Pointer to a constant null-terminated string that specifies the class of the service. This parameter can be any string unique to
		/// that service; either the protocol name, for example, ldap, or the string form of a GUID are acceptable.
		/// </para>
		/// </param>
		/// <param name="ServiceName">
		/// <para>
		/// Pointer to a constant null-terminated string that specifies the DNS name, NetBIOS name, or distinguished name (DN). This
		/// parameter must be non- <c>NULL</c>.
		/// </para>
		/// <para>
		/// For more information about how the ServiceName, InstanceName and InstancePort parameters are used to compose an SPN, see the
		/// following Remarks section.
		/// </para>
		/// </param>
		/// <param name="InstanceName">
		/// <para>
		/// Pointer to a constant null-terminated string that specifies the DNS name or IP address of the host for an instance of the service.
		/// </para>
		/// <para>If ServiceName specifies the DNS or NetBIOS name of the service host computer, the InstanceName parameter must be <c>NULL</c>.</para>
		/// <para>
		/// If ServiceName specifies a DNS domain name, the name of a DNS SRV record, or a distinguished name, such as the DN of a service
		/// connection point, the InstanceName parameter must specify the DNS or NetBIOS name of the service host computer.
		/// </para>
		/// </param>
		/// <param name="InstancePort">
		/// <para>
		/// Port number for an instance of the service. Use 0 for the default port. If this parameter is zero, the SPN does not include a
		/// port number.
		/// </para>
		/// </param>
		/// <param name="Referrer">
		/// <para>
		/// Pointer to a constant null-terminated string that specifies the DNS name of the host that gave an IP address referral. This
		/// parameter is ignored unless the ServiceName parameter specifies an IP address.
		/// </para>
		/// </param>
		/// <param name="pcSpnLength">
		/// <para>
		/// Pointer to a variable that contains the length, in characters, of the buffer that will receive the new constructed SPN. This
		/// value may be 0 to request the final buffer size in advance.
		/// </para>
		/// <para>The pcSpnLength parameter also receives the actual length of the SPN created, including the terminating null character.</para>
		/// </param>
		/// <param name="pszSpn">
		/// <para>
		/// Pointer to a null-terminated string that receives the constructed SPN. This buffer should be the length specified by pcSpnLength.
		/// The pszSpn parameter may be <c>NULL</c> to request the final buffer size in advance.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function returns an SPN, the return value is <c>ERROR_SUCCESS</c>. If the function fails, the return value can be one of
		/// the following error codes.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The format of the SPN produced by the <c>DsMakeSpn</c> function depends on the input parameters. There are two basic formats.
		/// Both formats begin with the ServiceClass string followed by a host computer name and an optional InstancePort component.
		/// </para>
		/// <para><c>Note</c> This format is used by host-based services.</para>
		/// <para><c>To produce an SPN with the "&lt;ServiceClass&gt;/&lt;host&gt;" format</c></para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// Set the ServiceName parameter to the DNS name of the host computer for the service instance. This is the host component of the SPN.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Set the InstanceName and Referrer parameters to <c>NULL</c>.</term>
		/// </item>
		/// <item>
		/// <term>Set the InstancePort parameter to zero. If InstancePort is nonzero, the SPN has the following format:</term>
		/// </item>
		/// </list>
		/// <para><c>Note</c> This format is used by replicable services.</para>
		/// <para><c>To produce an SPN with the "&lt;ServiceClass&gt;/&lt;host&gt;:&lt;InstancePort&gt;" format</c></para>
		/// <list type="number">
		/// <item>
		/// <term>Set the InstanceName parameter to the DNS name of the host computer for the service instance. This is the host component.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Set the ServiceName parameter to a string that identifies an instance of the service. For example, it could be the distinguished
		/// name of the service connection point for this service instance.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Set the Referrer parameter to <c>NULL</c>.</term>
		/// </item>
		/// <item>
		/// <term>Set the InstancePort parameter to zero. If InstancePort is nonzero, the SPN has the following format:</term>
		/// </item>
		/// </list>
		/// <para>
		/// The Referrer parameter is used only if the ServiceName parameter specifies the IP address of the service's host computer. In this
		/// case, Referrer specifies the DNS name of the computer that gave the IP address as a referral. The SPN has the following format:
		/// </para>
		/// <para>
		/// where the host component is the InstanceName string or the ServiceName string if InstanceName is <c>NULL</c>, and the
		/// InstancePort component is optional.
		/// </para>
		/// <para>String parameters cannot include the forward slash (/) character, as it is used to separate the components of the SPN.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsparse/nf-dsparse-dsmakespnw DSPARSE DWORD DsMakeSpnW( LPCWSTR ServiceClass,
		// LPCWSTR ServiceName, LPCWSTR InstanceName, USHORT InstancePort, LPCWSTR Referrer, DWORD *pcSpnLength, LPWSTR pszSpn );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("dsparse.h", MSDNShortId = "fca3c59c-bb81-42a0-acd3-2e55c902febe")]
		public static extern Win32Error DsMakeSpn(string ServiceClass, string ServiceName, [Optional] string? InstanceName, ushort InstancePort, [Optional] string? Referrer, ref uint pcSpnLength, [Optional] StringBuilder? pszSpn);

		/// <summary>
		/// <para>
		/// The <c>DsQuoteRdnValue</c> function converts an RDN into a quoted RDN value, if the RDN value contains characters that require
		/// quotes. The quoted RDN can then be submitted as part of a distinguished name (DN) to the directory service using various APIs
		/// such as LDAP. An example of an RDN that would require quotes would be one that has a comma-separated value, such as an RDN for a
		/// name that uses the format "last,first".
		/// </para>
		/// </summary>
		/// <param name="cUnquotedRdnValueLength">
		/// <para>The number of characters in the psUnquotedRdnValue string.</para>
		/// </param>
		/// <param name="psUnquotedRdnValue">
		/// <para>The string that specifies the unquoted RDN value.</para>
		/// </param>
		/// <param name="pcQuotedRdnValueLength">
		/// <para>The maximum number of characters in the psQuotedRdnValue string.</para>
		/// <para>The following flags are the output for this parameter.</para>
		/// <para>ERROR_SUCCESS</para>
		/// <para>Indicates that the correct number of characters were found in psQuotedRdnValue.</para>
		/// <para>ERROR_BUFFER_OVERFLOW</para>
		/// <para>Indicates that the number of characters in the string do not match psQuotedRdnValue.</para>
		/// </param>
		/// <param name="psQuotedRdnValue">
		/// <para>The string that receives the converted, and perhaps quoted, RDN value.</para>
		/// </param>
		/// <returns>
		/// <para>The following list contains the possible values returned for the <c>DsQuoteRdnValue</c> function.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Quotes are not added to the RDN if none are required. In this case, the output RDN value is the same as the input RDN value.
		/// </para>
		/// <para>
		/// When quoting is required, the RDN is quoted in accordance with the specification "Lightweight Directory Access Protocol (v3):
		/// UTF-8 String Representation of Distinguished Names," RFC 2253.
		/// </para>
		/// <para>The input and output RDN values are not <c>NULL</c>-terminated strings.</para>
		/// <para>To revert changes made by this call, call the DsUnquoteRdnValue function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsparse/nf-dsparse-dsquoterdnvaluea DSPARSE DWORD DsQuoteRdnValueA( DWORD
		// cUnquotedRdnValueLength, IN LPCCH psUnquotedRdnValue, DWORD *pcQuotedRdnValueLength, LPCH psQuotedRdnValue );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("dsparse.h", MSDNShortId = "a1e8a4c0-965a-4061-aab3-3e719ec6374d")]
		public static extern Win32Error DsQuoteRdnValue(uint cUnquotedRdnValueLength, string psUnquotedRdnValue, ref uint pcQuotedRdnValueLength, StringBuilder psQuotedRdnValue);

		/// <summary>
		/// <para>
		/// The <c>DsUnquoteRdnValue</c> function is a client call that converts a quoted RDN value back to an unquoted RDN value. Because
		/// the RDN was originally put into quotes because it contained characters that could be misinterpreted when it was embedded within a
		/// distinguished name (DN), the unquoted RDN value should not be submitted as part of a DN to the directory service using various
		/// APIs such as LDAP.
		/// </para>
		/// </summary>
		/// <param name="cQuotedRdnValueLength">
		/// <para>The number of characters in the psQuotedRdnValue string.</para>
		/// </param>
		/// <param name="psQuotedRdnValue">
		/// <para>The RDN value that may be quoted and escaped.</para>
		/// </param>
		/// <param name="pcUnquotedRdnValueLength">
		/// <para>The input value for this argument is the maximum length, in characters, of psQuotedRdnValue.</para>
		/// <para>The output value for this argument includes the following flags.</para>
		/// <para>ERROR_SUCCESS</para>
		/// <para>This is returned if the number of characters match the string used in psQuotedRdnValue.</para>
		/// <para>ERROR_BUFFER_OVERFLOW</para>
		/// <para>This is returned if the number of characters do not match the string used in psQuotedRdnValue.</para>
		/// </param>
		/// <param name="psUnquotedRdnValue">
		/// <para>The converted, unquoted RDN value.</para>
		/// </param>
		/// <returns>
		/// <para>The following list contains the possible values that are returned for the <c>DsUnquoteRdnValue</c> function.</para>
		/// </returns>
		/// <remarks>
		/// <para>When psQuotedRdnValue is quoted:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The leading and trailing quotes are removed.</term>
		/// </item>
		/// <item>
		/// <term>White space before the first quote is discarded.</term>
		/// </item>
		/// <item>
		/// <term>White space trailing the last quote is discarded.</term>
		/// </item>
		/// <item>
		/// <term>Escapes are removed and the character following the escape is kept.</term>
		/// </item>
		/// </list>
		/// <para>The following actions are taken when psQuotedRdnValue is unquoted:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The leading white space is discarded.</term>
		/// </item>
		/// <item>
		/// <term>The trailing white space is kept.</term>
		/// </item>
		/// <item>
		/// <term>Escaped non-special characters return an error.</term>
		/// </item>
		/// <item>
		/// <term>Unescaped special characters return an error.</term>
		/// </item>
		/// <item>
		/// <term>
		/// RDN values beginning with # (ignoring leading white space) are handled as a BER value that has previously been converted to a
		/// string, and converted accordingly.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Escaped hex digits (\89) are converted into a binary byte (0x89).</term>
		/// </item>
		/// <item>
		/// <term>Escapes are removed from escaped special characters.</term>
		/// </item>
		/// </list>
		/// <para>The following actions are always taken:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Escaped special characters are unescaped.</term>
		/// </item>
		/// <item>
		/// <term>The input and output RDN values are not null-terminated values.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsparse/nf-dsparse-dsunquoterdnvaluea DSPARSE DWORD DsUnquoteRdnValueA( DWORD
		// cQuotedRdnValueLength, LPCCH psQuotedRdnValue, DWORD *pcUnquotedRdnValueLength, LPCH psUnquotedRdnValue );
		[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("dsparse.h", MSDNShortId = "6e3dd220-ba98-46b5-8522-93cbe2029aa4")]
		public static extern Win32Error DsUnquoteRdnValue(uint cQuotedRdnValueLength, string psQuotedRdnValue, ref uint pcUnquotedRdnValueLength, StringBuilder psUnquotedRdnValue);
	}
}