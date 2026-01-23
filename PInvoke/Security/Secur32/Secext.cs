namespace Vanara.PInvoke;

public static partial class Secur32
{
	/// <summary>Specifies a format for a directory service object name.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/secext/ne-secext-extended_name_format typedef enum { NameUnknown,
	// NameFullyQualifiedDN, NameSamCompatible, NameDisplay, NameUniqueId, NameCanonical, NameUserPrincipal, NameCanonicalEx,
	// NameServicePrincipal, NameDnsDomain, NameGivenName, NameSurname } *PEXTENDED_NAME_FORMAT;
	[PInvokeData("secext.h", MSDNShortId = "1270c412-2fa5-4f5d-a86e-1ab3146c6683")]
	public enum EXTENDED_NAME_FORMAT
	{
		/// <summary>An unknown name type.</summary>
		NameUnknown = 0,

		/// <summary>The fully qualified distinguished name (for example, CN=Jeff Smith,OU=Users,DC=Engineering,DC=Microsoft,DC=Com).</summary>
		NameFullyQualifiedDN,

		/// <summary>
		/// A legacy account name (for example, Engineering\JSmith). The domain-only version includes trailing backslashes (\\).
		/// </summary>
		NameSamCompatible,

		/// <summary>
		/// A "friendly" display name (for example, Jeff Smith). The display name is not necessarily the defining relative distinguished
		/// name (RDN).
		/// </summary>
		NameDisplay,

		/// <summary>A GUID string that the IIDFromString function returns (for example, {4fa050f0-f561-11cf-bdd9-00aa003a77b6}).</summary>
		NameUniqueId = 6,

		/// <summary>
		/// The complete canonical name (for example, engineering.microsoft.com/software/someone). The domain-only version includes a
		/// trailing forward slash (/).
		/// </summary>
		NameCanonical,

		/// <summary>The user principal name (for example, someone@example.com).</summary>
		NameUserPrincipal,

		/// <summary>
		/// The same as NameCanonical except that the rightmost forward slash (/) is replaced with a new line character (\n), even in a
		/// domain-only case (for example, engineering.microsoft.com/software\nJSmith).
		/// </summary>
		NameCanonicalEx,

		/// <summary>The generalized service principal name (for example, www/www.microsoft.com@microsoft.com).</summary>
		NameServicePrincipal,

		/// <summary>The DNS domain name followed by a backward-slash and the SAM user name.</summary>
		NameDnsDomain = 12,

		/// <summary/>
		NameGivenName,

		/// <summary/>
		NameSurname,
	}

	/// <summary>Retrieves the local computer's name in a specified format.</summary>
	/// <param name="NameFormat">
	/// The format for the name. This parameter is a value from the EXTENDED_NAME_FORMAT enumeration type. It cannot be NameUnknown.
	/// </param>
	/// <param name="lpNameBuffer">
	/// <para>A pointer to a buffer that receives the name in the specified format.</para>
	/// <para>
	/// If this parameter is <c>NULL</c>, either the function succeeds and the lpnSize parameter receives the required size, or the
	/// function fails with ERROR_INSUFFICIENT_BUFFER and lpnSize receives the required size. The behavior depends on the value of
	/// NameFormat and the version of the operating system.
	/// </para>
	/// </param>
	/// <param name="nSize">
	/// On input, specifies the size of the lpNameBuffer buffer, in <c>TCHARs</c>. On success, receives the size of the name copied to
	/// the buffer. If the lpNameBuffer buffer is too small to hold the name, the function fails and lpnSize receives the required buffer size.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/secext/nf-secext-getcomputerobjectnamea BOOLEAN SEC_ENTRY
	// GetComputerObjectNameA( EXTENDED_NAME_FORMAT NameFormat, StrPtrAnsi lpNameBuffer, PULONG nSize );
	[DllImport(Lib.Secur32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("secext.h", MSDNShortId = "aead19ae-a27c-486e-aa2e-220d337044fc")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool GetComputerObjectName(EXTENDED_NAME_FORMAT NameFormat, StringBuilder? lpNameBuffer, ref uint nSize);

	/// <summary>
	/// <para>
	/// Retrieves the name of the user or other security principal associated with the calling thread. You can specify the format of the
	/// returned name.
	/// </para>
	/// <para>If the thread is impersonating a client, <c>GetUserNameEx</c> returns the name of the client.</para>
	/// </summary>
	/// <param name="NameFormat">
	/// The format of the name. This parameter is a value from the EXTENDED_NAME_FORMAT enumeration type. It cannot be
	/// <c>NameUnknown</c>. If the user account is not in a domain, only <c>NameSamCompatible</c> is supported.
	/// </param>
	/// <param name="lpNameBuffer">
	/// A pointer to a buffer that receives the name in the specified format. The buffer must include space for the terminating null character.
	/// </param>
	/// <param name="nSize">
	/// <para>
	/// On input, this variable specifies the size of the lpNameBuffer buffer, in <c>TCHARs</c>. If the function is successful, the
	/// variable receives the number of <c>TCHARs</c> copied to the buffer, not including the terminating null character.
	/// </para>
	/// <para>
	/// If lpNameBuffer is too small, the function fails and GetLastError returns ERROR_MORE_DATA. This parameter receives the required
	/// buffer size, in Unicode characters (whether or not Unicode is being used), including the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible values include
	/// the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The lpNameBuffer buffer is too small. The lpnSize parameter contains the number of bytes required to receive the name.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_DOMAIN</term>
	/// <term>The domain controller is not available to perform the lookup</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NONE_MAPPED</term>
	/// <term>The user name is not available in the specified format.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/secext/nf-secext-getusernameexa BOOLEAN SEC_ENTRY GetUserNameExA(
	// EXTENDED_NAME_FORMAT NameFormat, StrPtrAnsi lpNameBuffer, PULONG nSize );
	[DllImport(Lib.Secur32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("secext.h", MSDNShortId = "7e7d618b-2e64-4b0b-aed3-f3221b0443ca")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool GetUserNameEx(EXTENDED_NAME_FORMAT NameFormat, StringBuilder? lpNameBuffer, ref uint nSize);

	/// <summary>Converts a directory service object name from one format to another.</summary>
	/// <param name="lpAccountName">The name to be translated.</param>
	/// <param name="AccountNameFormat">
	/// The format of the name to be translated. This parameter is a value from the EXTENDED_NAME_FORMAT enumeration type.
	/// </param>
	/// <param name="DesiredNameFormat">
	/// The format of the converted name. This parameter is a value from the EXTENDED_NAME_FORMAT enumeration type. It cannot be NameUnknown.
	/// </param>
	/// <param name="lpTranslatedName">A pointer to a buffer that receives the converted name.</param>
	/// <param name="nSize">
	/// <para>
	/// On input, the variable indicates the size of the lpTranslatedName buffer, in <c>TCHARs</c>. On output, the variable returns the
	/// size of the returned string, in <c>TCHARs</c>, including the terminating <c>null</c> character.
	/// </para>
	/// <para>If lpTranslated is <c>NULL</c> and nSize is 0, the function succeeds and nSize receives the required buffer size.</para>
	/// <para>
	/// If the lpTranslatedName buffer is too small to hold the converted name, the function fails and nSize receives the required buffer size.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks><c>TranslateName</c> fails if it cannot bind to Active Directory on a domain controller.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/secext/nf-secext-translatenamea BOOLEAN SEC_ENTRY TranslateNameA( LPCSTR
	// lpAccountName, EXTENDED_NAME_FORMAT AccountNameFormat, EXTENDED_NAME_FORMAT DesiredNameFormat, StrPtrAnsi lpTranslatedName, PULONG
	// nSize );
	[DllImport(Lib.Secur32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("secext.h", MSDNShortId = "4df25519-e7d6-46ea-b0e8-ba1f82e5f94f")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool TranslateName(string lpAccountName, EXTENDED_NAME_FORMAT AccountNameFormat, EXTENDED_NAME_FORMAT DesiredNameFormat, StringBuilder? lpTranslatedName, ref uint nSize);
}