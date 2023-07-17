namespace Vanara.PInvoke;

public static partial class ShlwApi
{
	/// <summary>
	/// <para>Specifies how the StrFormatByteSizeEx function should handle rounding of undisplayed digits.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/ne-shlwapi-tagsfbs_flags typedef enum tagSFBS_FLAGS {
	// SFBS_FLAGS_ROUND_TO_NEAREST_DISPLAYED_DIGIT , SFBS_FLAGS_TRUNCATE_UNDISPLAYED_DECIMAL_DIGITS } ;
	[PInvokeData("shlwapi.h", MSDNShortId = "9b26734b-bda4-4b60-92a3-fe5b3d360dd0")]
	[Flags]
	public enum SFBS_FLAGS
	{
		/// <summary>Round to the nearest displayed digit.</summary>
		SFBS_FLAGS_ROUND_TO_NEAREST_DISPLAYED_DIGIT = 1,

		/// <summary>Discard undisplayed digits.</summary>
		SFBS_FLAGS_TRUNCATE_UNDISPLAYED_DECIMAL_DIGITS = 2,
	}

	/// <summary>Flags that control the output of string to number conversions.</summary>
	[PInvokeData("shlwapi.h", MSDNShortId = "8ea04c9f-6485-4931-a5d5-b22eb6681bd1")]
	public enum STIF_FLAGS
	{
		/// <summary>The string at pszString contains the representation of a decimal value.</summary>
		STIF_DEFAULT = 0,

		/// <summary>
		/// The string at pszString contains the representation of either a decimal or hexadecimal value. Note that in hexadecimal
		/// representations, the characters A-F are case-insensitive.
		/// </summary>
		STIF_SUPPORT_HEX = 1
	}

	/// <summary>
	/// <para>Copies and appends characters from one string to the end of another.</para>
	/// <para><c>Note</c> Do not use. See Remarks for alternative functions.</para>
	/// </summary>
	/// <param name="pszDest">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>
	/// A pointer to a null-terminated string. When this function returns successfully, this string contains its original content with
	/// the string pszSrc appended.
	/// </para>
	/// </param>
	/// <param name="pszSrc">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the string to be appended to pszDest.</para>
	/// </param>
	/// <param name="cchDestBuffSize">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The size of the buffer, in characters, pointed to by pszDest. This value must be at least the length of the combined string plus
	/// the terminating null character. If the buffer is too small to fit the entire string, the string will be truncated.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>Returns a pointer to the destination string.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Security Warning:</c> Using this function incorrectly can compromise the security of your application. The final string is not
	/// guaranteed to be null-terminated. Consider using one of the following alternatives: StringCbCat, StringCbCatEx, StringCbCatN,
	/// StringCbCatNEx, StringCchCat, StringCchCatEx, StringCchCatN, or StringCchCatNEx. You should review Security Considerations:
	/// Microsoft Windows Shell before continuing.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcatbuffa PSTR StrCatBuffA( PSTR pszDest, PCSTR pszSrc,
	// int cchDestBuffSize );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "ce8c002f-f4f8-4b5f-a9e2-7bcd21f8808c")]
	public static extern StrPtrAuto StrCatBuff(StringBuilder pszDest, string pszSrc, int cchDestBuffSize);

	/// <summary>
	/// <para>Concatenates two Unicode strings. Used when repeated concatenations to the same buffer are required.</para>
	/// </summary>
	/// <param name="pszDst">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>A pointer to a buffer that, when this function returns successfully, receives the null-terminated, Unicode string.</para>
	/// </param>
	/// <param name="cchDst">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The size of the destination buffer, in characters. This buffer must be of sufficient size to hold both strings as well as a
	/// terminating null character. If the buffer is too small, the final string is truncated.
	/// </para>
	/// </param>
	/// <param name="ichAt">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The offset into the destination buffer at which to begin the append action. If the string is not empty, set this value to -1 to
	/// have the current number of filled characters (not including the terminating null character) calculated for you.
	/// </para>
	/// </param>
	/// <param name="pszSrc">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>A pointer to the null-terminated Unicode source string.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Returns the offset of the null character after the last character added to pszDst.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Security Warning:</c> Using this function incorrectly can compromise the security of your application. The final string is not
	/// guaranteed to be null-terminated. Consider using one of the following alternatives: StringCbCatEx, StringCbCatNEx,
	/// StringCchCatEx, or StringCchCatNEx. You should review Security Considerations: Microsoft Windows Shell before continuing.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcatchainw DWORD StrCatChainW( PWSTR pszDst, DWORD
	// cchDst, DWORD ichAt, PCWSTR pszSrc );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "8df35616-f6f3-45eb-9a83-89fc84938fd7")]
	public static extern uint StrCatChainW(StringBuilder pszDst, uint cchDst, uint ichAt, string pszSrc);

	/// <summary>
	/// <para>Appends one string to another.</para>
	/// <para><c>Note</c> Do not use. See Remarks for alternative functions.</para>
	/// </summary>
	/// <param name="psz1">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>
	/// A pointer to a null-terminated string. When this function returns successfully, this string contains its original content with
	/// the string psz2 appended. This buffer must be large enough to hold both strings and the terminating null character.
	/// </para>
	/// </param>
	/// <param name="psz2">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to a null-terminated string to be appended to psz1.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>Returns a pointer to psz1, which holds the combined strings.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Security Warning:</c> Using this function incorrectly can compromise the security of your application. The first argument,
	/// psz1, must be large enough to hold psz2 and the closing '\0', otherwise a buffer overrun may occur. Buffer overruns may lead to a
	/// denial of service attack against the application if an access violation occurs. In the worst case, a buffer overrun may allow an
	/// attacker to inject executable code into your process, especially if psz1 is a stack-based buffer. Consider using one of the
	/// following alternatives: StringCbCat, StringCbCatEx, StringCbCatN, StringCbCatNEx, StringCchCat, StringCchCatEx, StringCchCatN, or
	/// StringCchCatNEx. You should review Security Considerations: Microsoft Windows Shell before continuing.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcatw PWSTR StrCatW( PWSTR psz1, PCWSTR psz2 );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "fd357462-83be-42a8-9f39-1e023bd5f86e")]
	public static extern StrPtrUni StrCatW(StringBuilder psz1, string psz2);

	/// <summary>
	/// <para>Searches a string for the first occurrence of a character that matches the specified character. The comparison is case-sensitive.</para>
	/// </summary>
	/// <param name="pszStart">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>The address of the string to be searched.</para>
	/// </param>
	/// <param name="wMatch">
	/// <para>Type: <c>TCHAR</c></para>
	/// <para>The character to be used for comparison.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>Returns the address of the first occurrence of the character in the string if successful, or <c>NULL</c> otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>The comparison assumes pszStart points to the start of a null-terminated string.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strchra PCSTR StrChrA( PCSTR pszStart, WORD wMatch );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "3e4c20cb-0b46-4f84-bbd1-860fdedde8c8")]
	public static extern StrPtrAuto StrChr(string pszStart, char wMatch);

	/// <summary>
	/// <para>
	/// Searches a string for the first occurrence of a character that matches the specified character. The comparison is not case-sensitive.
	/// </para>
	/// </summary>
	/// <param name="pszStart">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>A pointer to the string to be searched.</para>
	/// </param>
	/// <param name="wMatch">
	/// <para>Type: <c>TCHAR</c></para>
	/// <para>The character to be used for comparison.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>Returns the address of the first occurrence of the character in the string if successful, or <c>NULL</c> otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>The comparison assumes pszStart points to the start of a null-terminated string.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strchria PCSTR StrChrIA( PCSTR pszStart, WORD wMatch );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "bad606d2-e337-42b5-853e-c7afa8d3d71b")]
	public static extern StrPtrAuto StrChrI(string pszStart, char wMatch);

	/// <summary>
	/// <para>Searches a string for the first occurrence of a specified character. The comparison is not case-sensitive.</para>
	/// </summary>
	/// <param name="pszStart">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>A pointer to the string to be searched.</para>
	/// </param>
	/// <param name="wMatch">
	/// <para>Type: <c>WCHAR</c></para>
	/// <para>The character to be used for comparison.</para>
	/// </param>
	/// <param name="cchMax">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The maximum number of characters to search.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>Returns the address of the first occurrence of the character in the string if successful, or <c>NULL</c> otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para><c>StrChrNIW</c> searches for wMatch from pszStart to pszStart + cchMax, or until a <c>NULL</c> character is encountered.</para>
	/// <para>To help ensure optimal performance, pszStart should be word-aligned.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strchrniw PCWSTR StrChrNIW( PCWSTR pszStart, WCHAR wMatch,
	// UINT cchMax );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "01F2CC10-F59A-45dd-8A18-7DC33BDD717F")]
	public static extern StrPtrUni StrChrNIW(string pszStart, char wMatch, uint cchMax);

	/// <summary>
	/// <para>Searches a string for the first occurrence of a specified character. The comparison is case-sensitive.</para>
	/// </summary>
	/// <param name="pszStart">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>A pointer to the string to be searched.</para>
	/// </param>
	/// <param name="wMatch">
	/// <para>Type: <c>WCHAR</c></para>
	/// <para>The character to be used for comparison.</para>
	/// </param>
	/// <param name="cchMax">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The maximum number of characters to search.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>Returns the address of the first occurrence of the character in the string if successful, or <c>NULL</c> otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para><c>StrChrNW</c> searches for wMatch from pszStart to pszStart + cchMax, or until a <c>NULL</c> character is encountered.</para>
	/// <para>To help ensure optimal performance, pszStart should be word-aligned.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strchrnw PCWSTR StrChrNW( PCWSTR pszStart, WCHAR wMatch,
	// UINT cchMax );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "f90470c3-62db-4fbb-a045-8fdd300a6aa4")]
	public static extern StrPtrUni StrChrNW(string pszStart, char wMatch, uint cchMax);

	/// <summary>
	/// <para>Compares strings using C run-time (ASCII) collation rules. The comparison is case-sensitive.</para>
	/// </summary>
	/// <param name="pszStr1">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to the first null-terminated string to be compared.</para>
	/// </param>
	/// <param name="pszStr2">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to the second null-terminated string to be compared.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// Returns zero if the strings are identical. Returns a positive value if the string pointed to by lpStr1 is alphabetically greater
	/// than that pointed to by lpStr2. Returns a negative value if the string pointed to by lpStr1 is alphabetically less than that
	/// pointed to by lpStr2.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// It is strongly recommended that you use the CompareString function in place of this function. <c>StrCmpC</c> was designed for
	/// comparing canonical strings. These strings are not localized and consist only of characters below ASCII value 128. Therefore, it
	/// will not function correctly with a double-byte character set (DBCS) or other multiple-character data.
	/// </para>
	/// <para>
	/// This function locates the first unequal characters and returns a positive number if the character from the first string is
	/// greater than the character from the second, a negative number if it is less, or zero if they are equal. For example, if
	/// lpStr1="abczb" and lpStr2="abcdefg", <c>StrCmpC</c> determines that the first unequal character is at position four ("z" in
	/// lpStr1 and "d" in lpStr2) and returns a positive value since the ASCII code for "z" is greater than the ASCII code for "d".
	/// </para>
	/// <para>
	/// For those versions of Windows that do not include <c>StrCmpC</c> in Shlwapi.h, this function's individual ANSI or Unicode version
	/// must be called directly from Shlwapi.dll. <c>StrCmpCA</c> is ordinal 155 and <c>StrCmpCW</c> is ordinal 156.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcmpca int StrCmpCA( LPCSTR pszStr1, LPCSTR pszStr2 );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "f4c4bc76-1e42-4cb0-bf74-d395743c9b1c")]
	public static extern int StrCmpC(string pszStr1, string pszStr2);

	/// <summary>
	/// <para>Compares two strings using C run-time (ASCII) collation rules. The comparison is not case-sensitive.</para>
	/// </summary>
	/// <param name="pszStr1">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to the first null-terminated string to be compared.</para>
	/// </param>
	/// <param name="pszStr2">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to the second null-terminated string to be compared.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// Returns zero if the strings are identical. Returns a positive value if the string pointed to by lpStr1 is alphabetically greater
	/// than that pointed to by lpStr2. Returns a negative value if the string pointed to by lpStr1 is alphabetically less than that
	/// pointed to by lpStr2
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// It is strongly recommended that you use CompareString in place of this function. <c>StrCmpIC</c> was designed for comparing
	/// canonical strings. These strings are not localized and consist only of characters below ASCII value 128. Therefore, it will not
	/// function correctly with double-byte character set (DBCS) data.
	/// </para>
	/// <para>
	/// Uppercase characters are converted to lowercase characters before comparing, and the return value is based on comparing the
	/// converted values. This function returns the difference in value of the first unequal characters it encounters, or zero if they
	/// are all equal. For example, if lpStr1="abczb" and lpStr2="abcdefg", <c>StrCmpIC</c> determines that "abczb" is greater than
	/// "abcdefg" and returns z - d.
	/// </para>
	/// <para>
	/// For those versions of Windows that do not include <c>StrCmpIC</c> in Shlwapi.h, this function's individual ANSI or Unicode
	/// version must be called directly from Shlwapi.dll. <c>StrCmpICA</c> is ordinal 157 and <c>StrCmpICW</c> is ordinal 158.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcmpica int StrCmpICA( LPCSTR pszStr1, LPCSTR pszStr2 );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "3f6d1ca1-fbd2-4ce2-b6d4-c3dfb37f1f87")]
	public static extern int StrCmpIC(string pszStr1, string pszStr2);

	/// <summary>
	/// <para>Compares two strings to determine if they are the same. The comparison is not case-sensitive.</para>
	/// </summary>
	/// <param name="psz1">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the first null-terminated string to be compared.</para>
	/// </param>
	/// <param name="psz2">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the second null-terminated string to be compared.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// Returns zero if the strings are identical. Returns a positive value if the string pointed to by psz1 is greater than that pointed
	/// to by psz2. Returns a negative value if the string pointed to by psz1 is less than that pointed to by psz2.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcmpiw int StrCmpIW( PCWSTR psz1, PCWSTR psz2 );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "d059b6bd-8f03-4273-aa7a-b8b07f84d268")]
	public static extern int StrCmpIW(string psz1, string psz2);

	/// <summary>
	/// <para>
	/// Compares two Unicode strings. Digits in the strings are considered as numerical content rather than text. This test is not case-sensitive.
	/// </para>
	/// </summary>
	/// <param name="psz1">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>A pointer to the first null-terminated string to be compared.</para>
	/// </param>
	/// <param name="psz2">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>A pointer to the second null-terminated string to be compared.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <list type="bullet">
	/// <item>
	/// <term>Returns zero if the strings are identical.</term>
	/// </item>
	/// <item>
	/// <term>Returns 1 if the string pointed to by psz1 has a greater value than that pointed to by psz2.</term>
	/// </item>
	/// <item>
	/// <term>Returns -1 if the string pointed to by psz1 has a lesser value than that pointed to by psz2.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function's ordering schema differs somewhat from StrCmpI, which also compares strings without regard to case sensitivity.
	/// Considering digits by their numerical value—as <c>StrCmpLogicalW</c> does—strings are ordered as follows:
	/// </para>
	/// <para><c>StrCmpI</c> considers digits in the string only as text so that those same strings are ordered as follows:</para>
	/// <para>
	/// <c>Note</c> Behavior of this function, and therefore the results it returns, can change from release to release. It should not be
	/// used for canonical sorting applications.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcmplogicalw int StrCmpLogicalW( PCWSTR psz1, PCWSTR
	// psz2 );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "013c6db3-7d14-44ef-89af-b3aac28f4e3f")]
	public static extern int StrCmpLogicalW(string psz1, string psz2);

	/// <summary>
	/// <para>
	/// Compares a specified number of characters from the beginning of two strings to determine if they are the same. The comparison is
	/// case-sensitive. The <c>StrNCmp</c> macro differs from this function in name only.
	/// </para>
	/// </summary>
	/// <param name="psz1">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the first null-terminated string to be compared.</para>
	/// </param>
	/// <param name="psz2">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the second null-terminated string to be compared.</para>
	/// </param>
	/// <param name="nChar">
	/// <para>Type: <c>int</c></para>
	/// <para>The number of characters from the beginning of each string to be compared.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// Returns zero if the strings are identical. Returns a positive value if the first nChar characters of the string pointed to by
	/// psz1 are greater than those from the string pointed to by psz2. It returns a negative value if the first nChar characters of the
	/// string pointed to by psz1 are less than those from the string pointed to by psz2.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcmpna int StrCmpNA( PCSTR psz1, PCSTR psz2, int nChar );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "e2d97502-1819-463e-a56a-2d22b33502b7")]
	public static extern int StrCmpN(string psz1, string psz2, int nChar);

	/// <summary>
	/// <para>
	/// Compares a specified number of characters from the beginning of two strings using C run-time (ASCII) collation rules. The
	/// comparison is case-sensitive.
	/// </para>
	/// </summary>
	/// <param name="pszStr1">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to the first null-terminated string to be compared.</para>
	/// </param>
	/// <param name="pszStr2">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to the second null-terminated string to be compared.</para>
	/// </param>
	/// <param name="nChar">
	/// <para>Type: <c>int</c></para>
	/// <para>The number of characters from the beginning of each string to be compared.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// Returns zero if the substrings are identical. Returns a positive value if the string taken from that pointed to by pszStr1 is
	/// alphabetically greater than the string taken from that pointed to by pszStr2. Returns a negative value if the string taken from
	/// that pointed to by pszStr1 is alphabetically less than the string taken from that pointed to by pszStr2.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Note that <c>StrCmpNC</c> was designed for comparing canonical strings. These strings are not localized and consist only of
	/// characters below ASCII value 128. Therefore, it will not function correctly with a double-byte character set (DBCS) or other
	/// multiple-character data.
	/// </para>
	/// <para>
	/// This function locates the first unequal characters and returns a positive number if the character from the first string is
	/// greater than the character from the second, a negative number if it is less, or zero if they are equal. For example, suppose that
	/// pszStr1="abczb", pszStr2="abcdefg", and you are comparing the first four characters from each. <c>StrCmpNC</c> determines that
	/// the first unequal character is at position four ("z" in pszStr1 and "d" in pszStr2) and returns a positive value since the ASCII
	/// code for "z" is greater than the ASCII code for "d".
	/// </para>
	/// <para>
	/// For those versions of Windows that do not include <c>StrCmpNC</c> in Shlwapi.h, this function's individual ANSI or Unicode
	/// version must be called directly from Shlwapi.dll. <c>StrCmpNCA</c> is ordinal 151 and <c>StrCmpNCW</c> is ordinal 152.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcmpnca int StrCmpNCA( LPCSTR pszStr1, LPCSTR pszStr2,
	// int nChar );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "4b4f18d3-9325-4bd9-ac65-af7f3012fdaa")]
	public static extern int StrCmpNC(string pszStr1, string pszStr2, int nChar);

	/// <summary>
	/// <para>
	/// Compares a specified number of characters from the beginning of two strings to determine if they are the same. The comparison is
	/// not case-sensitive. The <c>StrNCmpI</c> macro differs from this function in name only.
	/// </para>
	/// </summary>
	/// <param name="psz1">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the first null-terminated string to be compared.</para>
	/// </param>
	/// <param name="psz2">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the second null-terminated string to be compared.</para>
	/// </param>
	/// <param name="nChar">
	/// <para>Type: <c>int</c></para>
	/// <para>The number of characters from the beginning of each string to be compared.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// Returns zero if the strings are identical. Returns a positive value if the first nChar characters of the string pointed to by
	/// psz1 are greater than those from the string pointed to by psz2. It returns a negative value if the first nChar characters of the
	/// string pointed to by psz1 are less than those from the string pointed to by psz2.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcmpnia int StrCmpNIA( PCSTR psz1, PCSTR psz2, int nChar );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "c6657bd5-21b6-457c-9ed0-45e44b2571ba")]
	public static extern int StrCmpNI(string psz1, string psz2, int nChar);

	/// <summary>
	/// <para>
	/// Compares a specified number of characters from the beginning of two strings using C run-time (ASCII) collation rules. The
	/// comparison is not case-sensitive.
	/// </para>
	/// </summary>
	/// <param name="pszStr1">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to the first null-terminated string to be compared.</para>
	/// </param>
	/// <param name="pszStr2">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>A pointer to the second null-terminated string to be compared.</para>
	/// </param>
	/// <param name="nChar">
	/// <para>Type: <c>int</c></para>
	/// <para>The number of characters from the beginning of each string to be compared.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// Returns zero if the substrings are identical. Returns a positive value if the string taken from that pointed to by pszStr1 is
	/// alphabetically greater the string taken from that pointed to by pszStr2. Returns a negative value if the string taken from that
	/// pointed to by pszStr1 is alphabetically less than the string taken from that pointed to by pszStr2.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Note that <c>StrCmpNIC</c> was designed for comparing canonical strings. These strings are not localized and consist only of
	/// characters below ASCII value 128. Therefore, it will not function correctly with a double-byte character set (DBCS) or other
	/// multiple-character data.
	/// </para>
	/// <para>
	/// This function locates the first unequal characters and returns a positive number if the character from the first string is
	/// greater than the character from the second, a negative number if it is less, or zero if they are equal. For example, suppose that
	/// pszStr1="abczb", pszStr2="abcdefg", and you are comparing the first four characters from each. <c>StrCmpNIC</c> determines that
	/// the first unequal character is at position four ("z" in pszStr1 and "d" in pszStr2) and returns a positive value since the ASCII
	/// code for "z" is greater than the ASCII code for "d".
	/// </para>
	/// <para>
	/// For those versions of Windows that do not include <c>StrCmpNIC</c> in Shlwapi.h, this function's individual ANSI or Unicode
	/// version must be called directly from Shlwapi.dll. <c>StrCmpNICA</c> is ordinal 153 and <c>StrCmpNICW</c> is ordinal 154.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcmpnica int StrCmpNICA( LPCSTR pszStr1, LPCSTR pszStr2,
	// int nChar );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "ed2e7df9-7f36-4566-8a3e-e3517307a584")]
	public static extern int StrCmpNIC(string pszStr1, string pszStr2, int nChar);

	/// <summary>
	/// <para>Compares two strings to determine if they are the same. The comparison is case-sensitive.</para>
	/// </summary>
	/// <param name="psz1">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the first null-terminated string to be compared.</para>
	/// </param>
	/// <param name="psz2">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the second null-terminated string to be compared.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// Returns zero if the strings are identical. Returns a positive value if the string pointed to by psz1 is greater than that pointed
	/// to by psz2. Returns a negative value if the string pointed to by psz1 is less than that pointed to by psz2.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcmpw int StrCmpW( PCWSTR psz1, PCWSTR psz2 );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "12530a04-776c-4506-86d1-07e2c3569a36")]
	public static extern int StrCmpW(string psz1, string psz2);

	/// <summary>
	/// <para>Copies a specified number of characters from the beginning of one string to another.</para>
	/// <para><c>Note</c> Do not use this function or the <c>StrNCpy</c> macro. See Remarks for alternative functions.</para>
	/// </summary>
	/// <param name="pszDst">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>
	/// A pointer to a buffer that, when this function returns successfully, receives the copied string. This buffer must be of
	/// sufficient size to hold the copied characters. This string is not guaranteed to be null-terminated.
	/// </para>
	/// </param>
	/// <param name="pszSrc">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the null-terminated source string.</para>
	/// </param>
	/// <param name="cchMax">
	/// <para>Type: <c>int</c></para>
	/// <para>The number of characters to be copied, including the terminating null character.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>Returns a pointer to pszDst.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Security Warning:</c> Using this function incorrectly can compromise the security of your application. The copied string is
	/// not guaranteed to be null-terminated. Consider using one of the following alternatives. StringCbCopy, StringCbCopyEx,
	/// StringCbCopyN, StringCbCopyNEx, StringCchCopy, StringCchCopyEx, StringCchCopyN, StringCchCopyNEx. You should review Security
	/// Considerations: Microsoft Windows Shell before continuing.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcpynw PWSTR StrCpyNW( PWSTR pszDst, PCWSTR pszSrc, int
	// cchMax );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "7e21414d-0d82-40b9-b32f-5eaf351166da")]
	public static extern StrPtrUni StrCpyNW(StringBuilder pszDst, string pszSrc, int cchMax);

	/// <summary>
	/// <para>Copies one string to another.</para>
	/// <para><c>Note</c> Do not use. See Remarks for alternative functions.</para>
	/// </summary>
	/// <param name="psz1">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>
	/// A pointer to a buffer that, when this function returns successfully, receives the copied string. This string is not guaranteed to
	/// be null-terminated.
	/// </para>
	/// </param>
	/// <param name="psz2">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the null-terminated source string.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>Returns a pointer to psz1.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Security Warning:</c> Using this function incorrectly can compromise the security of your application. The first argument,
	/// psz1, must be large enough to hold psz2 and the closing '\0', otherwise a buffer overrun may occur. Buffer overruns may lead to a
	/// denial of service attack against the application if an access violation occurs. In the worst case, a buffer overrun may allow an
	/// attacker to inject executable code into your process, especially if psz1 is a stack-based buffer. Consider using one of the
	/// following alternatives: StringCbCopy, StringCbCopyEx, StringCbCopyN, StringCbCopyNEx, StringCchCopy, StringCchCopyEx,
	/// StringCchCopyN, or StringCchCopyNEx. You should review Security Considerations: Microsoft Windows Shell before continuing.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcpyw PWSTR StrCpyW( PWSTR psz1, PCWSTR psz2 );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "83d1a8dc-fc43-4b06-b36c-c9c91d779d25")]
	public static extern StrPtrUni StrCpyW(StringBuilder psz1, string psz2);

	/// <summary>
	/// <para>
	/// Searches a string for the first occurrence of any of a group of characters. The search method is case-sensitive, and the
	/// terminating <c>NULL</c> character is included within the search pattern match.
	/// </para>
	/// </summary>
	/// <param name="pszStr">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the null-terminated string to be searched.</para>
	/// </param>
	/// <param name="pszSet">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to a null-terminated string that contains the characters to search for.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// Returns the index of the first occurrence in pszStr of any character from pszSet, or the length of pszStr if no match is found.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The return value of this function is equal to the length of the initial substring in pszStr that does not include any characters
	/// from pszSet.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcspna int StrCSpnA( PCSTR pszStr, PCSTR pszSet );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "24e9ec52-a5d7-4220-8e71-f850b53c49dd")]
	public static extern int StrCSpn(string pszStr, string pszSet);

	/// <summary>
	/// <para>
	/// Searches a string for the first occurrence of any of a group of characters. The search method is not case-sensitive, and the
	/// terminating <c>NULL</c> character is included within the search pattern match.
	/// </para>
	/// </summary>
	/// <param name="pszStr">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the null-terminated string to be searched.</para>
	/// </param>
	/// <param name="pszSet">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to a null-terminated string containing the characters to search for.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// Returns the index of the first occurrence in pszStr of any character from pszSet, or the length of pszStr if no match is found.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The return value of this function is equal to the length of the initial substring in pszStr that does not include any characters
	/// from pszSet.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strcspnia int StrCSpnIA( PCSTR pszStr, PCSTR pszSet );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "d21eb80b-5f02-4eb7-9a22-02425b7050b3")]
	public static extern int StrCSpnI(string pszStr, string pszSet);

	/// <summary>
	/// <para>Duplicates a string.</para>
	/// </summary>
	/// <param name="pszSrch">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to a constant <c>null</c>-terminated character string.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>Returns the address of the string that was copied, or <c>NULL</c> if the string cannot be copied.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>StrDup</c> will allocate storage the size of the original string. If storage allocation is successful, the original string is
	/// copied to the duplicate string.
	/// </para>
	/// <para>
	/// This function uses LocalAlloc to allocate storage space for the copy of the string. The calling application must free this memory
	/// by calling the LocalFree function on the pointer returned by the call to <c>StrDup</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>This simple console application illustrates the use of <c>StrDup</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strdupa PSTR StrDupA( PCSTR pszSrch );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "fa77f0b3-8a9b-4221-87e3-9aebff4409fb")]
	public static extern StrPtrAuto StrDup(string pszSrch);

	/// <summary>
	/// <para>
	/// Converts a numeric value into a string that represents the number expressed as a size value in bytes, kilobytes, megabytes, or
	/// gigabytes, depending on the size.
	/// </para>
	/// </summary>
	/// <param name="qdw">
	/// <para>Type: <c>LONGLONG</c></para>
	/// <para>The numeric value to be converted.</para>
	/// </param>
	/// <param name="pszBuf">
	/// <para>Type: <c>PSTR</c></para>
	/// <para>A pointer to a buffer that, when this function returns successfully, receives the converted number.</para>
	/// </param>
	/// <param name="cchBuf">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of the buffer pointed to by pszBuf, in characters.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PSTR</c></para>
	/// <para>Returns a pointer to the converted string, or <c>NULL</c> if the conversion fails.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>StrFormatByteSize64</c> can be used for either ANSI or Unicode characters. However, while <c>StrFormatByteSize64A</c> can be
	/// called directly, <c>StrFormatByteSize64W</c> is not defined. When <c>StrFormatByteSize64</c> is called with a Unicode value,
	/// StrFormatByteSizeW is used.
	/// </para>
	/// <para>In Windows 10, size is reported in base 10 rather than base 2. For example, 1 KB is 1000 bytes rather than 1024.</para>
	/// <para>The following table illustrates how this function converts a numeric value into a text string.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Numeric value</term>
	/// <term>Text string</term>
	/// </listheader>
	/// <item>
	/// <term>532</term>
	/// <term>532 bytes</term>
	/// </item>
	/// <item>
	/// <term>1340</term>
	/// <term>1.30 KB</term>
	/// </item>
	/// <item>
	/// <term>23506</term>
	/// <term>23.5 KB</term>
	/// </item>
	/// <item>
	/// <term>2400016</term>
	/// <term>2.40 MB</term>
	/// </item>
	/// <item>
	/// <term>2400000000</term>
	/// <term>2.4 GB</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strformatbytesize64a PSTR StrFormatByteSize64A( LONGLONG
	// qdw, PSTR pszBuf, UINT cchBuf );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("shlwapi.h", MSDNShortId = "b56dd90a-7033-409b-a8ea-e81a7a8a2342")]
	public static extern StrPtrAnsi StrFormatByteSize64A(long qdw, StringBuilder pszBuf, uint cchBuf);

	/// <summary>
	/// <para>
	/// Converts a numeric value into a string that represents the number expressed as a size value in bytes, kilobytes, megabytes, or
	/// gigabytes, depending on the size. Differs from StrFormatByteSizeW in one parameter type.
	/// </para>
	/// </summary>
	/// <param name="dw">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The numeric value to be converted.</para>
	/// </param>
	/// <param name="pszBuf">
	/// <para>Type: <c>PSTR</c></para>
	/// <para>A pointer to a buffer that receives the converted string.</para>
	/// </param>
	/// <param name="cchBuf">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of the buffer pointed to by pszBuf, in characters.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PSTR</c></para>
	/// <para>Returns a pointer to the converted string, or <c>NULL</c> if the conversion fails.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The first parameter of this function has a different type for the ANSI and Unicode versions. If your numeric value is a
	/// <c>DWORD</c>, you can use <c>StrFormatByteSize</c> with text macros for both cases. The compiler will cast the numerical value to
	/// a <c>LONGLONG</c> for the Unicode case. If your numerical value is a <c>LONGLONG</c>, you should use StrFormatByteSizeW explicitly.
	/// </para>
	/// <para>In Windows 10, size is reported in base 10 rather than base 2. For example, 1 KB is 1000 bytes rather than 1024.</para>
	/// <para>The following table illustrates how this function converts a numeric value into a text string.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Numeric value</term>
	/// <term>Text string</term>
	/// </listheader>
	/// <item>
	/// <term>532</term>
	/// <term>532 bytes</term>
	/// </item>
	/// <item>
	/// <term>1340</term>
	/// <term>1.30 KB</term>
	/// </item>
	/// <item>
	/// <term>23506</term>
	/// <term>22.9 KB</term>
	/// </item>
	/// <item>
	/// <term>2400016</term>
	/// <term>2.28 MB</term>
	/// </item>
	/// <item>
	/// <term>2400000000</term>
	/// <term>2.23 GB</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strformatbytesizea PSTR StrFormatByteSizeA( DWORD dw, PSTR
	// pszBuf, UINT cchBuf );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "244f93cb-0976-4a31-958c-ae0ed81c1dcf")]
	public static extern StrPtrAnsi StrFormatByteSizeA(uint dw, StringBuilder pszBuf, uint cchBuf);

	/// <summary>
	/// <para>
	/// Converts a numeric value into a string that represents the number in bytes, kilobytes, megabytes, or gigabytes, depending on the
	/// size. Extends StrFormatByteSizeW by offering the option to round to the nearest displayed digit or to discard undisplayed digits.
	/// </para>
	/// </summary>
	/// <param name="ull">
	/// <para>Type: <c>ULONGLONG</c></para>
	/// <para>The numeric value to be converted.</para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>SFBS_FLAGS</c></para>
	/// <para>
	/// One of the SFBS_FLAGS enumeration values that specifies whether to round or truncate undisplayed digits. This value cannot be NULL.
	/// </para>
	/// </param>
	/// <param name="pszBuf">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>A pointer to a buffer that receives the converted string.</para>
	/// </param>
	/// <param name="cchBuf">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of the buffer pointed to by pszBuf, in characters.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The following table illustrates how this function converts a numeric value into a text string in relation to the passed flag.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Numeric value</term>
	/// <term>Flag</term>
	/// <term>Text string</term>
	/// </listheader>
	/// <item>
	/// <term>2147483647</term>
	/// <term>SFBS_FLAGS_ROUND_TO_NEAREST_DISPLAYED_DIGIT</term>
	/// <term>2.00 GB</term>
	/// </item>
	/// <item>
	/// <term>2147483647</term>
	/// <term>SFBS_FLAGS_TRUNCATE_UNDISPLAYED_DECIMAL_DIGITS</term>
	/// <term>1.99 GB</term>
	/// </item>
	/// </list>
	/// <para>In Windows 10, size is reported in base 10 rather than base 2. For example, 1 KB is 1000 bytes rather than 1024.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strformatbytesizeex LWSTDAPI StrFormatByteSizeEx(
	// ULONGLONG ull, SFBS_FLAGS flags, PWSTR pszBuf, UINT cchBuf );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "9ecc6427-e7bb-43ec-ab78-665ef52f8b10")]
	public static extern HRESULT StrFormatByteSizeEx(ulong ull, SFBS_FLAGS flags, StringBuilder pszBuf, uint cchBuf);

	/// <summary>
	/// <para>
	/// Converts a numeric value into a string that represents the number expressed as a size value in bytes, kilobytes, megabytes, or
	/// gigabytes, depending on the size. Differs from StrFormatByteSizeW in one parameter type.
	/// </para>
	/// </summary>
	/// <param name="dw">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The numeric value to be converted.</para>
	/// </param>
	/// <param name="pszBuf">
	/// <para>Type: <c>PSTR</c></para>
	/// <para>A pointer to a buffer that receives the converted string.</para>
	/// </param>
	/// <param name="cchBuf">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of the buffer pointed to by pszBuf, in characters.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PSTR</c></para>
	/// <para>Returns a pointer to the converted string, or <c>NULL</c> if the conversion fails.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The first parameter of this function has a different type for the ANSI and Unicode versions. If your numeric value is a
	/// <c>DWORD</c>, you can use <c>StrFormatByteSize</c> with text macros for both cases. The compiler will cast the numerical value to
	/// a <c>LONGLONG</c> for the Unicode case. If your numerical value is a <c>LONGLONG</c>, you should use StrFormatByteSizeW explicitly.
	/// </para>
	/// <para>In Windows 10, size is reported in base 10 rather than base 2. For example, 1 KB is 1000 bytes rather than 1024.</para>
	/// <para>The following table illustrates how this function converts a numeric value into a text string.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Numeric value</term>
	/// <term>Text string</term>
	/// </listheader>
	/// <item>
	/// <term>532</term>
	/// <term>532 bytes</term>
	/// </item>
	/// <item>
	/// <term>1340</term>
	/// <term>1.30 KB</term>
	/// </item>
	/// <item>
	/// <term>23506</term>
	/// <term>22.9 KB</term>
	/// </item>
	/// <item>
	/// <term>2400016</term>
	/// <term>2.28 MB</term>
	/// </item>
	/// <item>
	/// <term>2400000000</term>
	/// <term>2.23 GB</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strformatbytesizea PSTR StrFormatByteSizeA( DWORD dw, PSTR
	// pszBuf, UINT cchBuf );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "244f93cb-0976-4a31-958c-ae0ed81c1dcf")]
	public static extern StrPtrUni StrFormatByteSizeW(long dw, StringBuilder pszBuf, uint cchBuf);

	/// <summary>
	/// <para>Converts a numeric value into a string that represents the number expressed as a size value in kilobytes.</para>
	/// </summary>
	/// <param name="qdw">
	/// <para>Type: <c>LONGLONG</c></para>
	/// <para>The numeric value to be converted.</para>
	/// </param>
	/// <param name="pszBuf">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>A pointer to a buffer that, when this function returns successfully, receives the converted number.</para>
	/// </param>
	/// <param name="cchBuf">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of pszBuf, in characters.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>Returns a pointer to the converted string, or <c>NULL</c> if the conversion fails.</para>
	/// </returns>
	/// <remarks>
	/// <para>In Windows 10, size is reported in base 10 rather than base 2. For example, 1 KB is 1000 bytes rather than 1024.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strformatkbsizea PSTR StrFormatKBSizeA( LONGLONG qdw, PSTR
	// pszBuf, UINT cchBuf );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "029c2eb8-3bcd-4302-8894-be2dbe430426")]
	public static extern StrPtrAuto StrFormatKBSize(long qdw, StringBuilder pszBuf, uint cchBuf);

	/// <summary>
	/// <para>Converts a time interval, specified in milliseconds, to a string.</para>
	/// </summary>
	/// <param name="pszOut">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>A pointer to a buffer that, when this function returns successfully, receives the converted number.</para>
	/// </param>
	/// <param name="cchMax">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The size of pszOut, in characters. If cchMax is set to zero, <c>StrFromTimeInterval</c> will return the minimum size of the
	/// character buffer needed to hold the converted string. In this case, pszOut will not contain the converted string.
	/// </para>
	/// </param>
	/// <param name="dwTimeMS">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The time interval, in milliseconds.</para>
	/// </param>
	/// <param name="digits">
	/// <para>Type: <c>int</c></para>
	/// <para>The maximum number of significant digits to be represented in pszOut. Some examples are:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwTimeMS</term>
	/// <term>digits</term>
	/// <term>pszOut</term>
	/// </listheader>
	/// <item>
	/// <term>34000</term>
	/// <term>3</term>
	/// <term>34 sec</term>
	/// </item>
	/// <item>
	/// <term>34000</term>
	/// <term>2</term>
	/// <term>34 sec</term>
	/// </item>
	/// <item>
	/// <term>34000</term>
	/// <term>1</term>
	/// <term>30 sec</term>
	/// </item>
	/// <item>
	/// <term>74000</term>
	/// <term>3</term>
	/// <term>1 min 14 sec</term>
	/// </item>
	/// <item>
	/// <term>74000</term>
	/// <term>2</term>
	/// <term>1 min 10 sec</term>
	/// </item>
	/// <item>
	/// <term>74000</term>
	/// <term>1</term>
	/// <term>1 min</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>Returns the number of characters in pszOut, excluding the terminating <c>NULL</c> character.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The time value returned in pszOut will always be in the form hh hours mm minutes ss seconds. Times that exceed twenty four hours
	/// are not converted to days or months. Fractions of seconds are ignored.
	/// </para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strfromtimeintervala int StrFromTimeIntervalA( PSTR
	// pszOut, UINT cchMax, DWORD dwTimeMS, int digits );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "e2a9492f-acfa-4cbd-8426-895e361f0174")]
	public static extern int StrFromTimeInterval(StringBuilder pszOut, uint cchMax, uint dwTimeMS, int digits);

	/// <summary>
	/// <para>Compares a specified number of characters from the beginning of two strings to determine if they are equal.</para>
	/// </summary>
	/// <param name="fCaseSens">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// The case sensitivity of the comparison. If this value is nonzero, the comparison is case-sensitive. If this value is zero, the
	/// comparison is not case-sensitive.
	/// </para>
	/// </param>
	/// <param name="pszString1">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the first null-terminated string to be compared.</para>
	/// </param>
	/// <param name="pszString2">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the second null-terminated string to be compared.</para>
	/// </param>
	/// <param name="nChar">
	/// <para>Type: <c>int</c></para>
	/// <para>The number of characters from the beginning of each string to be compared.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if the first nChar characters from the two strings are equal; otherwise, <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You can set case sensitivity with the <c>StrIntlEqN</c> and <c>StrIntlEqNI</c> macros. <c>StrIntlEqN</c> performs a
	/// case-sensitive comparison, and <c>StrIntlEqNI</c> performs a case-insensitive comparison.
	/// </para>
	/// <para>The syntax of the two macros is:</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strisintlequalw BOOL StrIsIntlEqualW( BOOL fCaseSens,
	// PCWSTR pszString1, PCWSTR pszString2, int nChar );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "02c66644-8aab-4ddd-a3ab-d52aeaa900a3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool StrIsIntlEqual([MarshalAs(UnmanagedType.Bool)] bool fCaseSens, string pszString1, string pszString2, int nChar);

	/// <summary>
	/// <para>Appends a specified number of characters from the beginning of one string to the end of another.</para>
	/// <para><c>Note</c> Do not use this function or the <c>StrCatN</c> macro. See Remarks for alternative functions.</para>
	/// </summary>
	/// <param name="psz1">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>
	/// A pointer to a null-terminated string to which the function appends the characters from psz2. It must be large enough to hold the
	/// combined strings plus the terminating null character.
	/// </para>
	/// </param>
	/// <param name="psz2">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the null-terminated string to be appended.</para>
	/// </param>
	/// <param name="cchMax">
	/// <para>Type: <c>int</c></para>
	/// <para>The number of characters to be appended to psz1 from the beginning of psz2.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>Returns a pointer to psz1, which holds the combined string.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Security Warning:</c> Using this function incorrectly can compromise the security of your application. The first argument,
	/// psz1, must be large enough to hold psz2 and the closing '\0', otherwise a buffer overrun may occur. Buffer overruns may lead to a
	/// denial of service attack against the application if an access violation occurs. In the worst case, a buffer overrun may allow an
	/// attacker to inject executable code into your process, especially if psz1 is a stack-based buffer. Be aware that the last
	/// argument, cchMax, is the number of characters to copy into psz1, not necessarily the size of the psz1 in bytes. Consider using
	/// one of the following alternatives. StringCbCat, StringCbCatEx, StringCbCatN, StringCbCatNEx, StringCchCat, StringCchCatEx,
	/// StringCchCatN, or StringCchCatNEx. You should review Security Considerations: Microsoft Windows Shell before continuing.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strncata PSTR StrNCatA( PSTR psz1, PCSTR psz2, int cchMax );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "28099350-5759-4595-8353-3452c5cf6ca8")]
	public static extern StrPtrAuto StrNCat(StringBuilder psz1, string psz2, int cchMax);

	/// <summary>
	/// <para>
	/// Searches a string for the first occurrence of a character contained in a specified buffer. This search does not include the
	/// terminating null character.
	/// </para>
	/// </summary>
	/// <param name="psz">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>A pointer to the null-terminated string to be searched.</para>
	/// </param>
	/// <param name="pszSet">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to a null-terminated character buffer that contains the characters for which to search.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>
	/// Returns the address in psz of the first occurrence of a character contained in the buffer at pszSet, or <c>NULL</c> if no match
	/// is found.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strpbrka PCSTR StrPBrkA( PCSTR psz, PCSTR pszSet );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "116c0791-33dd-4c3f-b8a4-a7df91fc5f6a")]
	public static extern StrPtrAuto StrPBrk(string psz, string pszSet);

	/// <summary>
	/// <para>Searches a string for the last occurrence of a specified character. The comparison is case-sensitive.</para>
	/// </summary>
	/// <param name="pszStart">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>A pointer to the null-terminated string to be searched.</para>
	/// </param>
	/// <param name="pszEnd">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>
	/// A pointer into the source string that defines the range of the search. Set pszEnd to point to a character in the string and the
	/// search will stop with the preceding character. Set pszEnd to <c>NULL</c> to search the entire string.
	/// </para>
	/// </param>
	/// <param name="wMatch">
	/// <para>Type: <c>TCHAR</c></para>
	/// <para>The character to search for.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>Returns a pointer to the last occurrence of the character in the string, if successful, or <c>NULL</c> if not.</para>
	/// </returns>
	/// <remarks>
	/// <para>The comparison assumes that pszEnd points to the end of the string.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strrchra PCSTR StrRChrA( PCSTR pszStart, PCSTR pszEnd,
	// WORD wMatch );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "7f1e91ad-aaa0-4449-834e-8e309c88d6b1")]
	public static extern StrPtrAuto StrRChr(string pszStart, [Optional] string? pszEnd, char wMatch);

	/// <summary>
	/// <para>Searches a string for the last occurrence of a specified character. The comparison is not case-sensitive.</para>
	/// </summary>
	/// <param name="pszStart">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>A pointer to the null-terminated string to be searched.</para>
	/// </param>
	/// <param name="pszEnd">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>
	/// A pointer into the source string that defines the range of the search. Set pszEnd to point to a character in the string and the
	/// search will stop with the preceding character. Set pszEnd to <c>NULL</c> to search the entire string.
	/// </para>
	/// </param>
	/// <param name="wMatch">
	/// <para>Type: <c>TCHAR</c></para>
	/// <para>The character to search for.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>Returns a pointer to the last occurrence of the character in the string, if successful, or <c>NULL</c> if not.</para>
	/// </returns>
	/// <remarks>
	/// <para>The comparison assumes that pszEnd points to the end of the string.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strrchria PCSTR StrRChrIA( PCSTR pszStart, PCSTR pszEnd,
	// WORD wMatch );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "3dc39c2a-d621-4f46-b65b-eb8a531e5abe")]
	public static extern StrPtrAuto StrRChrI(string pszStart, [Optional] string? pszEnd, char wMatch);

	/// <summary>
	/// Accepts a STRRET structure returned by IShellFolder::GetDisplayNameOf that contains or points to a string, and returns that
	/// string as a BSTR.
	/// </summary>
	/// <param name="pstr">
	/// <para>Type: <c>STRRET*</c></para>
	/// <para>A pointer to a STRRET structure. When the function returns, this pointer is longer valid.</para>
	/// </param>
	/// <param name="pidl">
	/// <para>Type: <c>PCUITEMID_CHILD</c></para>
	/// <para>
	/// A pointer to an ITEMIDLIST that uniquely identifies a file object or subfolder relative to the parent folder. This value can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pbstr">
	/// <para>Type: <c>BSTR*</c></para>
	/// <para>A pointer to a variable of type BSTR that receives the converted string.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// If the uType member of the STRRET structure pointed to by pstr is set to <c>STRRET_WSTR</c>, the pOleStr member of that
	/// structure is freed on return.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shlwapi/nf-shlwapi-strrettobstr
	// LWSTDAPI StrRetToBSTR( STRRET *pstr, PCUITEMID_CHILD pidl, BSTR *pbstr );
	[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("shlwapi.h", MSDNShortId = "NF:shlwapi.StrRetToBSTR")]
	public static extern HRESULT StrRetToBSTR([In] IntPtr pstr, [In, Optional] IntPtr pidl, [MarshalAs(UnmanagedType.BStr)] out string pbstr);

	/// <summary>
	/// <para>Converts an STRRET structure returned by IShellFolder::GetDisplayNameOf to a string, and places the result in a buffer.</para>
	/// </summary>
	/// <param name="pstr">
	/// <para>Type: <c>STRRET*</c></para>
	/// <para>A pointer to the STRRET structure. When the function returns, this pointer will no longer be valid.</para>
	/// </param>
	/// <param name="pidl">
	/// <para>Type: <c>PCUITEMID_CHILD</c></para>
	/// <para>A pointer to the item's ITEMIDLIST structure.</para>
	/// </param>
	/// <param name="pszBuf">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// A buffer to hold the display name. It will be returned as a null-terminated string. If cchBuf is too small, the name will be
	/// truncated to fit.
	/// </para>
	/// </param>
	/// <param name="cchBuf">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of pszBuf, in characters. If cchBuf is too small, the string will be truncated to fit.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the <c>uType</c> member of the structure pointed to by pstr is set to <c>STRRET_WSTR</c>, the <c>pOleStr</c> member of that
	/// structure will be freed on return.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strrettobufa LWSTDAPI StrRetToBufA( STRRET *pstr,
	// PCUITEMID_CHILD pidl, LPSTR pszBuf, UINT cchBuf );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "89dab3ee-e9f8-499a-97ec-6fe732315891")]
	public static extern HRESULT StrRetToBuf([In] IntPtr pstr, [In] IntPtr pidl, StringBuilder pszBuf, uint cchBuf);

	/// <summary>
	/// <para>
	/// Takes an STRRET structure returned by IShellFolder::GetDisplayNameOf and returns a pointer to an allocated string containing the
	/// display name.
	/// </para>
	/// </summary>
	/// <param name="pstr">
	/// <para>Type: <c>STRRET*</c></para>
	/// <para>A pointer to the STRRET structure. When the function returns, this pointer will no longer be valid.</para>
	/// </param>
	/// <param name="pidl">
	/// <para>Type: <c>PCUITEMID_CHILD</c></para>
	/// <para>A pointer to the item's ITEMIDLIST structure. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="ppsz">
	/// <para>Type: <c>LPTSTR*</c></para>
	/// <para>
	/// A pointer to an allocated string containing the result. <c>StrRetToStr</c> allocates memory for this string with CoTaskMemAlloc.
	/// You should free the string with CoTaskMemFree when it is no longer needed.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strrettostra LWSTDAPI StrRetToStrA( STRRET *pstr,
	// PCUITEMID_CHILD pidl, LPSTR *ppsz );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "03b0dffb-8ef7-41da-9773-81ed55275802")]
	public static extern HRESULT StrRetToStr([In] IntPtr pstr, [In, Optional] IntPtr pidl,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppsz);

	/// <summary>
	/// <para>Searches for the last occurrence of a specified substring within a string. The comparison is not case-sensitive.</para>
	/// </summary>
	/// <param name="pszSource">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>A pointer to a <c>null</c>-terminated source string.</para>
	/// </param>
	/// <param name="pszLast">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>
	/// A pointer into the source string that defines the range of the search. Set pszLast to point to a character in the source string,
	/// and the search will stop with the preceding character. Set pszLast to <c>NULL</c> to search the entire source string.
	/// </para>
	/// </param>
	/// <param name="pszSrch">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the substring to search for.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>Returns the address of the last occurrence of the substring if successful, or <c>NULL</c> otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strrstria PCSTR StrRStrIA( PCSTR pszSource, PCSTR pszLast,
	// PCSTR pszSrch );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "41057976-6443-40dc-96f7-f2cbd5d494de")]
	public static extern StrPtrAuto StrRStrI(string pszSource, [Optional] string? pszLast, string pszSrch);

	/// <summary>
	/// <para>Obtains the length of a substring within a string that consists entirely of characters contained in a specified buffer.</para>
	/// </summary>
	/// <param name="psz">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the null-terminated string that is to be searched.</para>
	/// </param>
	/// <param name="pszSet">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to a null-terminated character buffer that contains the set of characters for which to search.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>Returns the length, in characters, of the matching string or zero if no match is found.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strspna int StrSpnA( PCSTR psz, PCSTR pszSet );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "1a57da7f-76e7-49f2-aa31-50c224376e95")]
	public static extern int StrSpn(string psz, string pszSet);

	/// <summary>
	/// <para>Finds the first occurrence of a substring within a string. The comparison is case-sensitive.</para>
	/// </summary>
	/// <param name="pszFirst">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>A pointer to the null-terminated string to search.</para>
	/// </param>
	/// <param name="pszSrch">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the substring to search for.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>Returns the address of the first occurrence of the matching substring if successful, or <c>NULL</c> otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strstra PCSTR StrStrA( PCSTR pszFirst, PCSTR pszSrch );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "b1de5007-6773-4dea-8a15-ccd5f6924a13")]
	public static extern StrPtrAuto StrStr(string pszFirst, string pszSrch);

	/// <summary>
	/// <para>Finds the first occurrence of a substring within a string. The comparison is not case-sensitive.</para>
	/// </summary>
	/// <param name="pszFirst">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>A pointer to the null-terminated string being searched.</para>
	/// </param>
	/// <param name="pszSrch">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to the substring to search for.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>Returns the address of the first occurrence of the matching substring if successful, or <c>NULL</c> otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strstria PCSTR StrStrIA( PCSTR pszFirst, PCSTR pszSrch );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "b0281641-1375-4815-a707-03e1ce7e5a29")]
	public static extern StrPtrAuto StrStrI(string pszFirst, string pszSrch);

	/// <summary>
	/// <para>Finds the first occurrence of a substring within a string. The comparison is case-insensitive.</para>
	/// </summary>
	/// <param name="pszFirst">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>A pointer to the null-terminated, Unicode string that is being searched.</para>
	/// </param>
	/// <param name="pszSrch">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>A pointer to the null-terminated, Unicode substring that is being searched for.</para>
	/// </param>
	/// <param name="cchMax">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The maximum number of characters from the beginning of the searched string in which to search for the substring.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>Returns the address of the first occurrence of the matching substring if successful, or <c>NULL</c> otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strstrniw PCWSTR StrStrNIW( PCWSTR pszFirst, PCWSTR
	// pszSrch, UINT cchMax );
	[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "743f74f6-a0a6-4c03-b3bf-7f819bbc665f")]
	public static extern StrPtrUni StrStrNIW(string pszFirst, string pszSrch, uint cchMax);

	/// <summary>
	/// <para>Finds the first occurrence of a substring within a string. The comparison is case-sensitive.</para>
	/// </summary>
	/// <param name="pszFirst">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>A pointer to the null-terminated, Unicode string that is being searched.</para>
	/// </param>
	/// <param name="pszSrch">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>A pointer to the null-terminated, Unicode substring that is being searched for.</para>
	/// </param>
	/// <param name="cchMax">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The maximum number of characters from the beginning of the searched string in which to search for the substring.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>Returns the address of the first occurrence of the matching substring if successful, or <c>NULL</c> otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strstrnw PCWSTR StrStrNW( PCWSTR pszFirst, PCWSTR pszSrch,
	// UINT cchMax );
	[DllImport(Lib.Shell32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("shlwapi.h", MSDNShortId = "e7aac4c7-b2d5-43d8-97f5-1b11ebb24ee1")]
	public static extern StrPtrUni StrStrNW(string pszFirst, string pszSrch, uint cchMax);

	/// <summary>
	/// <para>Converts a string that represents a decimal value to an integer. The <c>StrToLong</c> macro is identical to this function.</para>
	/// </summary>
	/// <param name="pszSrc">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>
	/// A pointer to the null-terminated string to be converted. A valid string representing a decimal value contains only the characters
	/// 0-9 and must have the following form to be parsed successfully.
	/// </para>
	/// <para>The optional sign can be the character '-' or '+'; if omitted, the sign is assumed to be positive.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>Returns the <c>int</c> value represented by pszSrc. For instance, the string "123" returns the integer value 123.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the string pointed to by pszSrc contains an invalid character, that character is considered the end of the string to be
	/// converted and the remainder is ignored. For instance, given the invalid decimal string "12b34", <c>StrToInt</c> only recognizes
	/// "12" and returns that integer value.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strtointa int StrToIntA( PCSTR pszSrc );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "74313e56-a820-4d02-91f4-f629d2fc72d4")]
	public static extern int StrToInt(string pszSrc);

	/// <summary>
	/// <para>Converts a string representing a decimal or hexadecimal value to a 64-bit integer.</para>
	/// </summary>
	/// <param name="pszString">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>
	/// A pointer to the <c>null</c>-terminated string to be converted. For further details concerning the valid forms of the string, see
	/// the Remarks section.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>STIF_FLAGS</c></para>
	/// <para>One of the following values that specify how pszString should be parsed for its conversion to a 64-bit integer.</para>
	/// <para>STIF_DEFAULT</para>
	/// <para>The string at pszString contains the representation of a decimal value.</para>
	/// <para>STIF_SUPPORT_HEX</para>
	/// <para>
	/// The string at pszString contains the representation of either a decimal or hexadecimal value. Note that in hexadecimal
	/// representations, the characters A-F are case-insensitive.
	/// </para>
	/// </param>
	/// <param name="pllRet">
	/// <para>Type: <c>LONGLONG*</c></para>
	/// <para>
	/// A pointer to a variable of type <c>LONGLONG</c> that receives the 64-bit integer value of the converted string. For instance, in
	/// the case of the string "123", the integer pointed to by this value receives the value 123.
	/// </para>
	/// <para>If this function returns <c>FALSE</c>, this value is undefined.</para>
	/// <para>
	/// If the value returned is too large to be contained in a variable of type <c>LONGLONG</c>, this parameter contains the 64
	/// low-order bits of the value. Any high-order bits beyond that are lost.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns <c>TRUE</c> if the string is converted; otherwise <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>The string pointed to by the pszString parameter must have one of the following forms to be parsed successfully.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>This form is accepted as a decimal value under either flag.</term>
	/// </item>
	/// <item>
	/// <term>These forms are required for hexadecimal values when the STIF_SUPPORT_HEX flag is passed.</term>
	/// </item>
	/// </list>
	/// <para>The optional sign can be the character '-' or '+'; if omitted, the sign is assumed to be positive.</para>
	/// <para>
	/// <c>Note</c> If the value is parsed as hexadecimal, the optional sign is ignored, even if it is a '-' character. For example, the
	/// string "-0x1" is parsed as 1 instead of -1.
	/// </para>
	/// <para>
	/// If the string pointed to by pszString contains an invalid character, that character is considered the end of the string to be
	/// converted and the remainder is ignored. For instance, given the invalid hexadecimal string "0x00am123", <c>StrToInt64Ex</c> only
	/// recognizes "0x00a", converts it to the integer value 10, and returns <c>TRUE</c>.
	/// </para>
	/// <para>
	/// If pllRet is <c>NULL</c>, the function returns <c>TRUE</c> if the string can be converted, even though it does not perform the conversion.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strtoint64exa BOOL StrToInt64ExA( PCSTR pszString,
	// STIF_FLAGS dwFlags, LONGLONG *pllRet );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "8ea04c9f-6485-4931-a5d5-b22eb6681bd1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool StrToInt64Ex(string pszString, STIF_FLAGS dwFlags, out long pllRet);

	/// <summary>
	/// <para>Converts a string representing a decimal or hexadecimal number to an integer.</para>
	/// </summary>
	/// <param name="pszString">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>
	/// A pointer to the null-terminated string to be converted. For further details concerning the valid forms of the string, see the
	/// Remarks section.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>STIF_FLAGS</c></para>
	/// <para>One of the following values that specify how pszString should be parsed for its conversion to an integer.</para>
	/// <para>STIF_DEFAULT</para>
	/// <para>The string at pszString contains the representation of a decimal value.</para>
	/// <para>STIF_SUPPORT_HEX</para>
	/// <para>
	/// The string at pszString contains the representation of either a decimal or hexadecimal value. Note that in hexadecimal
	/// representations, the characters A-F are case-insensitive.
	/// </para>
	/// </param>
	/// <param name="piRet">
	/// <para>Type: <c>int*</c></para>
	/// <para>
	/// A pointer to an <c>int</c> that receives the converted string. For instance, in the case of the string "123", the integer pointed
	/// to by this value receives the integer value 123.
	/// </para>
	/// <para>If this function returns <c>FALSE</c>, this value is undefined.</para>
	/// <para>
	/// If the value returned is too large to be contained in a variable of type <c>int</c>, this parameter contains the 32 low-order
	/// bits of the value. Any high-order bits beyond that are lost.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns <c>TRUE</c> if the string is converted; otherwise <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>The string pointed to by the pszString parameter must have one of the following forms to be parsed successfully.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>This form is accepted as a decimal value under either flag.</term>
	/// </item>
	/// <item>
	/// <term>These forms are required for hexadecimal values when the STIF_SUPPORT_HEX flag is passed.</term>
	/// </item>
	/// </list>
	/// <para>The optional sign can be the character '-' or '+'; if omitted, the sign is assumed to be positive.</para>
	/// <para>
	/// <c>Note</c> If the value is parsed as hexadecimal, the optional sign is ignored, even if it is a '-' character. For example, the
	/// string "-0x1" is parsed as 1 instead of -1.
	/// </para>
	/// <para>
	/// If the string pointed to by pszString contains an invalid character, that character is considered the end of the string to be
	/// converted and the remainder is ignored. For instance, given the invalid hexadecimal string "0x00am123", <c>StrToIntEx</c> only
	/// recognizes "0x00a", converts it to the integer value 10, and returns <c>TRUE</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strtointexa BOOL StrToIntExA( PCSTR pszString, STIF_FLAGS
	// dwFlags, int *piRet );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "2e8286c7-585f-441b-904b-f3b4e8cf95f9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool StrToIntEx(string pszString, STIF_FLAGS dwFlags, out int piRet);

	/// <summary>
	/// <para>Removes specified leading and trailing characters from a string.</para>
	/// </summary>
	/// <param name="psz">
	/// <para>Type: <c>PTSTR</c></para>
	/// <para>
	/// A pointer to the null-terminated string to be trimmed. When this function returns successfully, psz receives the trimmed string.
	/// </para>
	/// </param>
	/// <param name="pszTrimChars">
	/// <para>Type: <c>PCTSTR</c></para>
	/// <para>A pointer to a null-terminated string that contains the characters to trim from psz.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if any characters were removed; otherwise, <c>FALSE</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-strtrima BOOL StrTrimA( PSTR psz, PCSTR pszTrimChars );
	[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("shlwapi.h", MSDNShortId = "aea422b9-326e-4b12-b2a9-7c220677a467")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool StrTrim(StringBuilder psz, string pszTrimChars);
}