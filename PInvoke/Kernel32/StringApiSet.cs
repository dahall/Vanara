namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>The system default Windows ANSI code page.</summary>
	public const uint CP_ACP = 0;

	/// <summary>The current system Macintosh code page.</summary>
	public const uint CP_MACCP = 2;

	/// <summary>The current system OEM code page.</summary>
	public const uint CP_OEMCP = 1;

	/// <summary>Symbol code page (42).</summary>
	public const uint CP_SYMBOL = 42;

	/// <summary>The Windows ANSI code page for the current thread.</summary>
	public const uint CP_THREAD_ACP = 3;

	/// <summary>UTF-7. Use this value only when forced by a 7-bit transport mechanism. Use of UTF-8 is preferred.</summary>
	public const uint CP_UTF7 = 65000;

	/// <summary>UTF-8.</summary>
	public const uint CP_UTF8 = 65001;

	/// <summary>
	/// The string indicated by lpString1 is equivalent in lexical value to the string indicated by lpString2. The two strings are
	/// equivalent for sorting purposes, although not necessarily identical.
	/// </summary>
	public const uint CSTR_EQUAL = 2;

	/// <summary>The string indicated by lpString1 is greater in lexical value than the string indicated by lpString2.</summary>
	public const uint CSTR_GREATER_THAN = 3;

	/// <summary>The string indicated by lpString1 is less in lexical value than the string indicated by lpString2.</summary>
	public const uint CSTR_LESS_THAN = 1;

	/// <summary>Flags used by CompareString and CompareStringEx</summary>
	public enum COMPARE_STRING
	{
		/// <summary>Ignore case. For many scripts (notably Latin scripts), NORM_IGNORECASE coincides with LINGUISTIC_IGNORECASE.</summary>
		NORM_IGNORECASE = 1,

		/// <summary>Ignore nonspacing characters. For many scripts (notably Latin scripts), NORM_IGNORENONSPACE coincides with LINGUISTIC_IGNOREDIACRITIC.</summary>
		NORM_IGNORENONSPACE = 2,

		/// <summary>Ignore symbols and punctuation.</summary>
		NORM_IGNORESYMBOLS = 4,

		/// <summary>
		/// Do not differentiate between hiragana and katakana characters. Corresponding hiragana and katakana characters compare as equal.
		/// </summary>
		NORM_IGNOREKANATYPE = 65536,

		/// <summary>
		/// Ignore the difference between half-width and full-width characters, for example, C a t == cat. The full-width form is a
		/// formatting distinction used in Chinese and Japanese scripts.
		/// </summary>
		NORM_IGNOREWIDTH = 131072,

		/// <summary>Ignore case, as linguistically appropriate.</summary>
		LINGUISTIC_IGNORECASE = 16,

		/// <summary>Ignore nonspacing characters, as linguistically appropriate.</summary>
		LINGUISTIC_IGNOREDIACRITIC = 32,

		/// <summary>
		/// Use the default linguistic rules for casing, instead of file system rules. Note that most scenarios for CompareStringEx use
		/// this flag. This flag does not have to be used when your application calls CompareStringOrdinal.
		/// </summary>
		NORM_LINGUISTIC_CASING = 134217728,

		/// <summary>Treat punctuation the same as symbols.</summary>
		SORT_STRINGSORT = 0x00001000,

		/// <summary>Windows 7: Treat digits as numbers during sorting, for example, sort &amp;quot;2&amp;quot; before &amp;quot;10&amp;quot;.</summary>
		SORT_DIGITSASNUMBERS = 8
	}

	/// <summary>Flags indicating the conversion type.</summary>
	[Flags]
	public enum MBCONV
	{
		/// <summary>
		/// Default; do not use with MB_COMPOSITE. Always use precomposed characters, that is, characters having a single character value
		/// for a base or nonspacing character combination. For example, in the character &amp;#232;, the e is the base character and the
		/// accent grave mark is the nonspacing character. If a single Unicode code point is defined for a character, the application
		/// should use it instead of a separate base character and a nonspacing character. For example, &amp;#196; is represented by the
		/// single Unicode code point LATIN CAPITAL LETTER A WITH DIAERESIS (U+00C4).
		/// </summary>
		MB_PRECOMPOSED = 0x00000001,

		/// <summary>
		/// Always use decomposed characters, that is, characters in which a base character and one or more nonspacing characters each
		/// have distinct code point values. For example, &amp;#196; is represented by A + &amp;#168;: LATIN CAPITAL LETTER A (U+0041) +
		/// COMBINING DIAERESIS (U+0308). Note that this flag cannot be used with MB_PRECOMPOSED.
		/// </summary>
		MB_COMPOSITE = 0x00000002,

		/// <summary>Use glyph characters instead of control characters.</summary>
		MB_USEGLYPHCHARS = 0x00000004,

		/// <summary>
		/// Fail if an invalid input character is encountered. Starting with Windows Vista, the function does not drop illegal code
		/// points if the application does not set this flag, but instead replaces illegal sequences with U+FFFD (encoded as appropriate
		/// for the specified codepage).Windows 2000 with SP4 and later, Windows XP: If this flag is not set, the function silently drops
		/// illegal code points. A call to GetLastError returns ERROR_NO_UNICODE_TRANSLATION.
		/// </summary>
		MB_ERR_INVALID_CHARS = 0x00000008,
	}

	/// <summary>Flags specifying the type of transformation to use during string mapping.</summary>
	[PInvokeData("Winnls.h")]
	[Flags]
	public enum STRING_MAPPING
	{
		/// <summary>
		/// Fold compatibility zone characters into standard Unicode equivalents. This flag is equivalent to normalization form KD in
		/// Windows Vista, if the MAP_COMPOSITE flag is also set. If the composite flag is not set (default), this flag is equivalent to
		/// normalization form KC in Windows Vista.
		/// </summary>
		MAP_FOLDCZONE = 16,

		/// <summary>
		/// Map accented characters to precomposed characters, in which the accent and base character are combined into a single
		/// character value. This flag is equivalent to normalization form C in Windows Vista. This value cannot be combined with MAP_COMPOSITE.
		/// </summary>
		MAP_PRECOMPOSED = 32,

		/// <summary>
		/// Map accented characters to decomposed characters, that is, characters in which a base character and one or more nonspacing
		/// characters each have distinct code point values. For example, &amp;#196; is represented by A + &amp;#168;: LATIN CAPITAL
		/// LETTER A (U+0041) + COMBINING DIAERESIS (U+0308). This flag is equivalent to normalization form D in Windows Vista. Note that
		/// this flag cannot be used with MB_PRECOMPOSED.
		/// </summary>
		MAP_COMPOSITE = 64,

		/// <summary>Map all digits to Unicode characters 0 through 9.</summary>
		MAP_FOLDDIGITS = 128,

		/// <summary>
		/// Expand all ligature characters so that they are represented by their two-character equivalent. For example, the ligature
		/// &amp;quot;&amp;#230;&amp;quot; (U+00e6) expands to the two characters &amp;quot;a&amp;quot; (U+0061) + &amp;quot;e&amp;quot;
		/// (U+0065). This value cannot be combined with MAP_PRECOMPOSED or MAP_COMPOSITE.
		/// </summary>
		MAP_EXPAND_LIGATURES = 8192,
	}

	/// <summary>Flags indicating the conversion type.</summary>
	[Flags]
	public enum WCCONV
	{
		/// <summary>
		/// Convert composite characters, consisting of a base character and a nonspacing character, each with different character
		/// values. Translate these characters to precomposed characters, which have a single character value for a base-nonspacing
		/// character combination. For example, in the character &amp;#232;, the e is the base character and the accent grave mark is the
		/// nonspacing character.Your application can combine WC_COMPOSITECHECK with any one of the following flags, with the default
		/// being WC_SEPCHARS. These flags determine the behavior of the function when no precomposed mapping for a base-nonspacing
		/// character combination in a Unicode string is available. If none of these flags is supplied, the function behaves as if the
		/// WC_SEPCHARS flag is set. For more information, see WC_COMPOSITECHECK and related flags in the Remarks section.
		/// </summary>
		WC_COMPOSITECHECK = 0x00000200,

		/// <summary>Discard nonspacing characters during conversion.</summary>
		WC_DISCARDNS = 0x00000010,

		/// <summary>Default. Generate separate characters during conversion.</summary>
		WC_SEPCHARS = 0x00000020,

		/// <summary>Replace exceptions with the default character during conversion.</summary>
		WC_DEFAULTCHAR = 0x00000040,

		/// <summary>
		/// Windows Vista and later: Fail (by returning 0 and setting the last-error code to ERROR_NO_UNICODE_TRANSLATION) if an invalid
		/// input character is encountered. You can retrieve the last-error code with a call to GetLastError. If this flag is not set,
		/// the function replaces illegal sequences with U+FFFD (encoded as appropriate for the specified codepage) and succeeds by
		/// returning the length of the converted string. Note that this flag only applies when CodePage is specified as CP_UTF8 or
		/// 54936. It cannot be used with other code page values.
		/// </summary>
		WC_ERR_INVALID_CHARS = 0x00000080,

		/// <summary>
		/// Translate any Unicode characters that do not translate directly to multibyte equivalents to the default character specified
		/// by lpDefaultChar. In other words, if translating from Unicode to multibyte and back to Unicode again does not yield the same
		/// Unicode character, the function uses the default character. This flag can be used by itself or in combination with the other
		/// defined flags.For strings that require validation, such as file, resource, and user names, the application should always use
		/// the WC_NO_BEST_FIT_CHARS flag. This flag prevents the function from mapping characters to characters that appear similar but
		/// have very different semantics. In some cases, the semantic change can be extreme. For example, the symbol for
		/// &amp;quot;∞&amp;quot; (infinity) maps to 8 (eight) in some code pages.
		/// </summary>
		WC_NO_BEST_FIT_CHARS = 0x00000400,
	}

	/// <summary>Compares two character strings, for a locale specified by identifier.</summary>
	/// <param name="Locale">
	/// Locale identifier of the locale used for the comparison. You can use the <c>MAKELCID</c> macro to create a locale identifier or
	/// use one of the following predefined values.
	/// </param>
	/// <param name="dwCmpFlags">
	/// Flags that indicate how the function compares the two strings. For detailed definitions, see the dwCmpFlags parameter of <c>CompareStringEx</c>.
	/// </param>
	/// <param name="lpString1">Pointer to the first string to compare.</param>
	/// <param name="cchCount1">
	/// Length of the string indicated by lpString1, excluding the terminating null character. This value represents bytes for the ANSI
	/// version of the function and wide characters for the Unicode version. The application can supply a negative value if the string is
	/// null-terminated. In this case, the function determines the length automatically.
	/// </param>
	/// <param name="lpString2">Pointer to the second string to compare.</param>
	/// <param name="cchCount2">
	/// Length of the string indicated by lpString2, excluding the terminating null character. This value represents bytes for the ANSI
	/// version of the function and wide characters for the Unicode version. The application can supply a negative value if the string is
	/// null-terminated. In this case, the function determines the length automatically.
	/// </param>
	/// <returns>Returns the values described for <c>CompareStringEx</c>.</returns>
	// int CompareString( _In_ LCID Locale, _In_ DWORD dwCmpFlags, _In_ LPCTSTR lpString1, _In_ int cchCount1, _In_ LPCTSTR lpString2,
	// _In_ int cchCount2); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317759(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("Winnls.h", MSDNShortId = "dd317759")]
	public static extern int CompareString(LCID Locale, COMPARE_STRING dwCmpFlags, string lpString1, int cchCount1, string lpString2, int cchCount2);

	/// <summary>Compares two Unicode (wide character) strings, for a locale specified by name.</summary>
	/// <param name="lpLocaleName">Pointer to a locale name, or one of the following predefined values.</param>
	/// <param name="dwCmpFlags">
	/// <para>
	/// Flags that indicate how the function compares the two strings. By default, these flags are not set. This parameter can specify a
	/// combination of any of the following values, or it can be set to 0 to obtain the default behavior.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LINGUISTIC_IGNORECASE</term>
	/// <term>Ignore case, as linguistically appropriate.</term>
	/// </item>
	/// <item>
	/// <term>LINGUISTIC_IGNOREDIACRITIC</term>
	/// <term>Ignore nonspacing characters, as linguistically appropriate.</term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNORECASE</term>
	/// <term>Ignore case. For many scripts (notably Latin scripts), NORM_IGNORECASE coincides with LINGUISTIC_IGNORECASE.</term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNOREKANATYPE</term>
	/// <term>
	/// Do not differentiate between hiragana and katakana characters. Corresponding hiragana and katakana characters compare as equal.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNORENONSPACE</term>
	/// <term>Ignore nonspacing characters. For many scripts (notably Latin scripts), NORM_IGNORENONSPACE coincides with LINGUISTIC_IGNOREDIACRITIC.</term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNORESYMBOLS</term>
	/// <term>Ignore symbols and punctuation.</term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNOREWIDTH</term>
	/// <term>
	/// Ignore the difference between half-width and full-width characters, for example, C a t == cat. The full-width form is a
	/// formatting distinction used in Chinese and Japanese scripts.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NORM_LINGUISTIC_CASING</term>
	/// <term>
	/// Use the default linguistic rules for casing, instead of file system rules. Note that most scenarios for CompareStringEx use this
	/// flag. This flag does not have to be used when your application calls CompareStringOrdinal.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SORT_DIGITSASNUMBERS</term>
	/// <term>Windows 7: Treat digits as numbers during sorting, for example, sort &amp;quot;2&amp;quot; before &amp;quot;10&amp;quot;.</term>
	/// </item>
	/// <item>
	/// <term>SORT_STRINGSORT</term>
	/// <term>Treat punctuation the same as symbols.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpString1">Pointer to the first string to compare.</param>
	/// <param name="cchCount1">
	/// Length of the string indicated by lpString1, excluding the terminating null character. The application can supply a negative
	/// value if the string is null-terminated. In this case, the function determines the length automatically.
	/// </param>
	/// <param name="lpString2">Pointer to the second string to compare.</param>
	/// <param name="cchCount2">
	/// Length of the string indicated by lpString2, excluding the terminating null character. The application can supply a negative
	/// value if the string is null-terminated. In this case, the function determines the length automatically.
	/// </param>
	/// <param name="lpVersionInformation">
	/// <para>
	/// Pointer to an <c>NLSVERSIONINFOEX</c> structure that contains the version information about the relevant NLS capability; usually
	/// retrieved from <c>GetNLSVersionEx</c>.
	/// </para>
	/// <para><c>Windows Vista, Windows 7:</c> Reserved; must set to <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpReserved">Reserved; must set to <c>NULL</c>.</param>
	/// <param name="lParam">Reserved; must be set to 0.</param>
	/// <returns>
	/// <para>
	/// Returns one of the following values if successful. To maintain the C runtime convention of comparing strings, the value 2 can be
	/// subtracted from a nonzero return value. Then, the meaning of &lt;0, ==0, and &gt;0 is consistent with the C runtime.
	/// </para>
	/// <para>
	/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>,
	/// which can return one of the following error codes:
	/// </para>
	/// </returns>
	// int CompareStringEx( _In_opt_ LPCWSTR lpLocaleName, _In_ DWORD dwCmpFlags, _In_ LPCWSTR lpString1, _In_ int cchCount1, _In_
	// LPCWSTR lpString2, _In_ int cchCount2, _In_opt_ LPNLSVERSIONINFO lpVersionInformation, _In_opt_ LPVOID lpReserved, _In_opt_ LPARAM
	// lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317761(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("Stringapiset.h", MSDNShortId = "dd317761")]
	public static extern int CompareStringEx(string lpLocaleName, COMPARE_STRING dwCmpFlags, string lpString1, int cchCount1, string lpString2, int cchCount2, [Optional] IntPtr lpVersionInformation, [Optional] IntPtr lpReserved, [Optional] IntPtr lParam);

	/// <summary>Compares two Unicode strings to test binary equivalence.</summary>
	/// <param name="lpString1">Pointer to the first string to compare.</param>
	/// <param name="cchCount1">
	/// Length of the string indicated by lpString1. The application supplies -1 if the string is null-terminated. In this case, the
	/// function determines the length automatically.
	/// </param>
	/// <param name="lpString2">Pointer to the second string to compare.</param>
	/// <param name="cchCount2">
	/// Length of the string indicated by lpString2. The application supplies -1 if the string is null-terminated. In this case, the
	/// function determines the length automatically.
	/// </param>
	/// <param name="bIgnoreCase">
	/// <c>TRUE</c> if the function is to perform a case-insensitive comparison, using the operating system uppercase table information.
	/// The application sets this parameter to <c>FALSE</c> if the function is to compare the strings exactly as they are passed in.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns one of the following values if successful. To maintain the C runtime convention of comparing strings, the value 2 can be
	/// subtracted from a nonzero return value. Then, the meaning of &lt;0, ==0, and &gt;0 is consistent with the C runtime.
	/// </para>
	/// <para>
	/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>,
	/// which can return one of the following error codes:
	/// </para>
	/// </returns>
	// int CompareStringOrdinal( _In_ LPCWSTR lpString1, _In_ int cchCount1, _In_ LPCWSTR lpString2, _In_ int cchCount2, _In_ BOOL
	// bIgnoreCase); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317762(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("Stringapiset.h", MSDNShortId = "dd317762")]
	public static extern int CompareStringOrdinal(string lpString1, int cchCount1, string lpString2, int cchCount2, [MarshalAs(UnmanagedType.Bool)] bool bIgnoreCase);

	/// <summary>
	/// Maps one Unicode string to another, performing the specified transformation. For an overview of the use of the string functions,
	/// see Strings.
	/// </summary>
	/// <param name="dwMapFlags">
	/// <para>
	/// Flags specifying the type of transformation to use during string mapping. This parameter can be a combination of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MAP_COMPOSITE</term>
	/// <term>
	/// Map accented characters to decomposed characters, that is, characters in which a base character and one or more nonspacing
	/// characters each have distinct code point values. For example, &amp;#196; is represented by A + &amp;#168;: LATIN CAPITAL LETTER A
	/// (U+0041) + COMBINING DIAERESIS (U+0308). This flag is equivalent to normalization form D in Windows Vista. Note that this flag
	/// cannot be used with MB_PRECOMPOSED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MAP_EXPAND_LIGATURES</term>
	/// <term>
	/// Expand all ligature characters so that they are represented by their two-character equivalent. For example, the ligature
	/// &amp;quot;&amp;#230;&amp;quot; (U+00e6) expands to the two characters &amp;quot;a&amp;quot; (U+0061) + &amp;quot;e&amp;quot;
	/// (U+0065). This value cannot be combined with MAP_PRECOMPOSED or MAP_COMPOSITE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MAP_FOLDCZONE</term>
	/// <term>
	/// Fold compatibility zone characters into standard Unicode equivalents. This flag is equivalent to normalization form KD in Windows
	/// Vista, if the MAP_COMPOSITE flag is also set. If the composite flag is not set (default), this flag is equivalent to
	/// normalization form KC in Windows Vista.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MAP_FOLDDIGITS</term>
	/// <term>Map all digits to Unicode characters 0 through 9.</term>
	/// </item>
	/// <item>
	/// <term>MAP_PRECOMPOSED</term>
	/// <term>
	/// Map accented characters to precomposed characters, in which the accent and base character are combined into a single character
	/// value. This flag is equivalent to normalization form C in Windows Vista. This value cannot be combined with MAP_COMPOSITE.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpSrcStr">Pointer to a source string that the function maps.</param>
	/// <param name="cchSrc">
	/// Size, in characters, of the source string indicated by lpSrcStr, excluding the terminating null character. The application can
	/// set the parameter to any negative value to specify that the source string is null-terminated. In this case, the function
	/// calculates the string length automatically, and null-terminates the mapped string indicated by lpDestStr.
	/// </param>
	/// <param name="lpDestStr">Pointer to a buffer in which this function retrieves the mapped string.</param>
	/// <param name="cchDest">
	/// <para>
	/// Size, in characters, of the destination string indicated by lpDestStr. If space for a terminating null character is included in
	/// cchSrc, cchDest must also include space for a terminating null character.
	/// </para>
	/// <para>
	/// The application can set cchDest to 0. In this case, the function does not use the lpDestStr parameter and returns the required
	/// buffer size for the mapped string. If the MAP_FOLDDIGITS flag is specified, the return value is the maximum size required, even
	/// if the actual number of characters needed is smaller than the maximum size. If the maximum size is not passed, the function fails
	/// with ERROR_INSUFFICIENT_BUFFER.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// Returns the number of characters in the translated string, including a terminating null character, if successful. If the function
	/// succeeds and the value of cchDest is 0, the return value is the size of the buffer required to hold the translated string,
	/// including a terminating null character.
	/// </para>
	/// <para>
	/// This function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>,
	/// which can return one of the following error codes:
	/// </para>
	/// </returns>
	// int FoldString( _In_ DWORD dwMapFlags, _In_ LPCTSTR lpSrcStr, _In_ int cchSrc, _Out_opt_ LPTSTR lpDestStr, _In_ int cchDest); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318063(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnls.h", MSDNShortId = "dd318063")]
	public static extern int FoldString(STRING_MAPPING dwMapFlags, string lpSrcStr, int cchSrc, StringBuilder? lpDestStr, int cchDest);

	/// <summary>
	/// Maps one Unicode string to another, performing the specified transformation. For an overview of the use of the string functions, see Strings.
	/// </summary>
	/// <param name="lpSrcStr">The source string that the function maps.</param>
	/// <param name="dwMapFlags">
	/// <para>
	/// Flags specifying the type of transformation to use during string mapping. This parameter can be a combination of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MAP_COMPOSITE</term>
	/// <term>
	/// Map accented characters to decomposed characters, that is, characters in which a base character and one or more nonspacing characters
	/// each have distinct code point values. For example, &amp;#196; is represented by A + &amp;#168;: LATIN CAPITAL LETTER A (U+0041) +
	/// COMBINING DIAERESIS (U+0308). This flag is equivalent to normalization form D in Windows Vista. Note that this flag cannot be used
	/// with MB_PRECOMPOSED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MAP_EXPAND_LIGATURES</term>
	/// <term>
	/// Expand all ligature characters so that they are represented by their two-character equivalent. For example, the ligature
	/// &amp;quot;&amp;#230;&amp;quot; (U+00e6) expands to the two characters &amp;quot;a&amp;quot; (U+0061) + &amp;quot;e&amp;quot;
	/// (U+0065). This value cannot be combined with MAP_PRECOMPOSED or MAP_COMPOSITE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MAP_FOLDCZONE</term>
	/// <term>
	/// Fold compatibility zone characters into standard Unicode equivalents. This flag is equivalent to normalization form KD in Windows
	/// Vista, if the MAP_COMPOSITE flag is also set. If the composite flag is not set (default), this flag is equivalent to normalization
	/// form KC in Windows Vista.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MAP_FOLDDIGITS</term>
	/// <term>Map all digits to Unicode characters 0 through 9.</term>
	/// </item>
	/// <item>
	/// <term>MAP_PRECOMPOSED</term>
	/// <term>
	/// Map accented characters to precomposed characters, in which the accent and base character are combined into a single character value.
	/// This flag is equivalent to normalization form C in Windows Vista. This value cannot be combined with MAP_COMPOSITE.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>The translated string if successful.</returns>
	// int FoldString( _In_ DWORD dwMapFlags, _In_ LPCTSTR lpSrcStr, _In_ int cchSrc, _Out_opt_ LPTSTR lpDestStr, _In_ int cchDest); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318063(v=vs.85).aspx
	[PInvokeData("Winnls.h", MSDNShortId = "dd318063")]
	public static string Fold(this string lpSrcStr, STRING_MAPPING dwMapFlags)
	{
		var len = FoldString(dwMapFlags, lpSrcStr, -1, null, 0);
		StringBuilder sb = new(len);
		Win32Error.ThrowLastErrorIf(FoldString(dwMapFlags, lpSrcStr, -1, sb, len), i => i == 0);
		return sb.ToString();
	}

	/// <summary>
	/// Deprecated. Retrieves character type information for the characters in the specified source string. For each character in the
	/// string, the function sets one or more bits in the corresponding 16-bit element of the output array. Each bit identifies a given
	/// character type, for example, letter, digit, or neither.
	/// </summary>
	/// <param name="Locale">
	/// <para>
	/// Locale identifier that specifies the locale. You can use the <c>MAKELCID</c> macro to create a locale identifier or use one of
	/// the following predefined values.
	/// </para>
	/// <para><c>Windows Vista and later:</c> The following custom locale identifiers are also supported.</para>
	/// </param>
	/// <param name="dwInfoType">
	/// Flags specifying the character type information to retrieve. For possible flag values, see the dwInfoType parameter of
	/// <c>GetStringTypeW</c>. For detailed information about the character type bits, see Remarks for <c>GetStringTypeW</c>.
	/// </param>
	/// <param name="lpSrcStr">
	/// Pointer to the ANSI string for which to retrieve the character types. The string can be a double-byte character set (DBCS) string
	/// if the supplied locale is appropriate for DBCS. The string is assumed to be null-terminated if cchSrc is set to any negative value.
	/// </param>
	/// <param name="cchSrc">
	/// Size, in characters, of the string indicated by lpSrcStr. If the size includes a terminating null character, the function
	/// retrieves character type information for that character. If the application sets the size to any negative integer, the source
	/// string is assumed to be null-terminated and the function calculates the size automatically with an additional character for the
	/// null termination.
	/// </param>
	/// <param name="lpCharType">
	/// Pointer to an array of 16-bit values. The length of this array must be large enough to receive one 16-bit value for each
	/// character in the source string. If cchSrc is not a negative number, lpCharType should be an array of words with cchSrc elements.
	/// If cchSrc is set to a negative number, lpCharType is an array of words with lpSrcStr + 1 elements. When the function returns,
	/// this array contains one word corresponding to each character in the source string. The values are of type <see cref="Ctype1"/>,
	/// <see cref="Ctype2"/>, or <see cref="Ctype3"/>.
	/// </param>
	/// <returns>
	/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call
	/// <c>GetLastError</c>, which can return one of the following error codes:
	/// </returns>
	// BOOL GetStringTypeA( _In_ LCID Locale, _In_ DWORD dwInfoType, _In_ LPCSTR lpSrcStr, _In_ int cchSrc, _Out_ LPWORD lpCharType); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318117(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("Winnls.h", MSDNShortId = "dd318117")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetStringTypeA(LCID Locale, CHAR_TYPE_INFO dwInfoType, string lpSrcStr, int cchSrc,
		[In, Out, MarshalAs(UnmanagedType.LPArray)] ushort[] lpCharType);

	/// <summary>
	/// <para>
	/// Retrieves character type information for the characters in the specified source string. For each character in the string, the
	/// function sets one or more bits in the corresponding 16-bit element of the output array. Each bit identifies a given character
	/// type, for example, letter, digit, or neither.
	/// </para>
	/// <para>
	/// <c>Caution</c> Using the <c>GetStringTypeEx</c> function incorrectly can compromise the security of your application. To avoid a
	/// buffer overflow, the application must set the output buffer size correctly. For more security information, see Security
	/// Considerations: Windows User Interface.
	/// </para>
	/// <para>
	/// <c>Note</c> Unlike its close relatives GetStringTypeA and GetStringTypeW, this function exhibits appropriate ANSI or Unicode
	/// behavior through the use of the #define UNICODE switch. This is the recommended function for character type retrieval.
	/// </para>
	/// </summary>
	/// <param name="Locale">
	/// <para>
	/// Locale identifier that specifies the locale. This value uniquely defines the ANSI code page. You can use the MAKELCID macro to
	/// create a locale identifier or use one of the following predefined values.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>LOCALE_SYSTEM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_USER_DEFAULT</term>
	/// </item>
	/// </list>
	/// <para>Windows Vista and later:</para>
	/// <para>The following custom locale identifiers are also supported.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>LOCALE_CUSTOM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_CUSTOM_UI_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_CUSTOM_UNSPECIFIED</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwInfoType">
	/// Flags specifying the character type information to retrieve. For possible flag values, see the dwInfoType parameter of
	/// GetStringTypeW. For detailed information about the character type bits, see Remarks for GetStringTypeW.
	/// </param>
	/// <param name="lpSrcStr">
	/// Pointer to the string for which to retrieve the character types. The string is assumed to be null-terminated if cchSrc is set to
	/// any negative value.
	/// </param>
	/// <param name="cchSrc">
	/// Size, in characters, of the string indicated by lpSrcStr. The size refers to bytes for the ANSI version of the function or wide
	/// characters for the Unicode version. If the size includes a terminating null character, the function retrieves character type
	/// information for that character. If the application sets the size to any negative integer, the source string is assumed to be
	/// null-terminated and the function calculates the size automatically with an additional character for the null termination.
	/// </param>
	/// <param name="lpCharType">
	/// Pointer to an array of 16-bit values. The length of this array must be large enough to receive one 16-bit value for each
	/// character in the source string. If cchSrc is not a negative number, lpCharType should be an array of words with cchSrc elements.
	/// If cchSrc is set to a negative number, lpCharType is an array of words with lpSrcStr + 1 elements. When the function returns,
	/// this array contains one word corresponding to each character in the source string.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call GetLastError,
	/// which can return one of the following error codes:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>ERROR_INVALID_FLAGS</c>. The values supplied for flags were not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c>. Any of the parameter values was invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For an overview of the use of the string functions, see Strings.</para>
	/// <para>
	/// Using the ANSI code page for the supplied locale, this function translates the source string from ANSI to Unicode. It then
	/// analyzes each Unicode character for character type information.
	/// </para>
	/// <para>
	/// The ANSI version of this function converts the source string to Unicode and calls the corresponding GetStringTypeW function. Thus
	/// the words in the output buffer correspond not to the original ANSI string but to its Unicode equivalent. The conversion from ANSI
	/// to Unicode can result in a change in string length, for example, a pair of ANSI characters can map to a single Unicode character.
	/// Therefore, the correspondence between the words in the output buffer and the characters in the original ANSI string is not
	/// one-to-one in all cases, for example, multibyte strings. Thus, the ANSI version of this function is of limited use for
	/// multi-character strings. The Unicode version of the function is recommended instead.
	/// </para>
	/// <para>
	/// This function circumvents a limitation caused by the difference in parameters between GetStringTypeA and GetStringTypeW. Because
	/// of the parameter difference, an application cannot automatically invoke the proper ANSI or Unicode version of a
	/// <c>GetStringType*</c> function through the use of the #define UNICODE switch. On the other hand, <c>GetStringTypeEx</c>, behaves
	/// properly with regard to that switch. Thus it is the recommended function.
	/// </para>
	/// <para>
	/// When the ANSI version of this function is used with a Unicode-only locale identifier, the function can succeed because the
	/// operating system uses the system code page. However, characters that are undefined in the system code page appear in the string
	/// as a question mark (?).
	/// </para>
	/// <para>
	/// The values of the lpSrcStr and lpCharType parameters must not be the same. If they are the same, the function fails with <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// <para>
	/// The Locale parameter is only used to perform string conversion to Unicode. It has nothing to do with the CTYPE* values supplied
	/// by the application. These values are solely determined by Unicode code points, and do not vary on a locale basis. For example,
	/// Greek letters are specified as C1_ALPHA for any value of Locale.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnls/nf-winnls-getstringtypeexa BOOL GetStringTypeExA( LCID Locale, DWORD
	// dwInfoType, LPCSTR lpSrcStr, int cchSrc, LPWORD lpCharType );
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winnls.h", MSDNShortId = "e0cd051f-6627-457a-9a83-d71de607f67f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetStringTypeEx(LCID Locale, CHAR_TYPE_INFO dwInfoType, string lpSrcStr, int cchSrc,
		[In, Out, MarshalAs(UnmanagedType.LPArray)] ushort[] lpCharType);

	/// <summary>
	/// <para>
	/// Retrieves character type information for the characters in the specified source string. For each character in the string, the
	/// function sets one or more bits in the corresponding 16-bit element of the output array. Each bit identifies a given character
	/// type, for example, letter, digit, or neither.
	/// </para>
	/// <para>
	/// <c>Caution</c> Using the <c>GetStringTypeEx</c> function incorrectly can compromise the security of your application. To avoid a
	/// buffer overflow, the application must set the output buffer size correctly. For more security information, see Security
	/// Considerations: Windows User Interface.
	/// </para>
	/// <para>
	/// <c>Note</c> Unlike its close relatives GetStringTypeA and GetStringTypeW, this function exhibits appropriate ANSI or Unicode
	/// behavior through the use of the #define UNICODE switch. This is the recommended function for character type retrieval.
	/// </para>
	/// </summary>
	/// <typeparam name="TCtype">The return type requested. This must be one of the CtypeX enumerated types.</typeparam>
	/// <param name="lpSrcStr">
	/// Pointer to the string for which to retrieve the character types. The string is assumed to be null-terminated if cchSrc is set to
	/// any negative value.
	/// </param>
	/// <param name="Locale">
	/// <para>
	/// Locale identifier that specifies the locale. This value uniquely defines the ANSI code page. You can use the MAKELCID macro to
	/// create a locale identifier or use one of the following predefined values.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>LOCALE_SYSTEM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_USER_DEFAULT</term>
	/// </item>
	/// </list>
	/// <para>Windows Vista and later:</para>
	/// <para>The following custom locale identifiers are also supported.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>LOCALE_CUSTOM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_CUSTOM_UI_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_CUSTOM_UNSPECIFIED</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// An array of 16-bit values. The length of this array must be large enough to receive one 16-bit value for each character in the
	/// source string. If cchSrc is not a negative number, lpCharType should be an array of words with cchSrc elements. If cchSrc is set
	/// to a negative number, lpCharType is an array of words with lpSrcStr + 1 elements. When the function returns, this array contains
	/// one word corresponding to each character in the source string.
	/// </returns>
	/// <exception cref="ArgumentException"></exception>
	/// <exception cref="ArgumentNullException">lpSrcStr</exception>
	[PInvokeData("winnls.h", MSDNShortId = "e0cd051f-6627-457a-9a83-d71de607f67f")]
	public static TCtype[] GetStringTypeEx<TCtype>(string lpSrcStr, LCID Locale) where TCtype : unmanaged, Enum
	{
		if (!CorrespondingTypeAttribute.CanGet<TCtype, CHAR_TYPE_INFO>(out var ct)) throw new ArgumentException($"{nameof(TCtype)} must be one of the CtypeX enumerated types.");
		if (string.IsNullOrEmpty(lpSrcStr)) throw new ArgumentNullException(nameof(lpSrcStr));
		var ctVals = new ushort[lpSrcStr.Length + 1];
		Win32Error.ThrowLastErrorIfFalse(GetStringTypeEx(Locale, ct, lpSrcStr, -1, ctVals));
		return Array.ConvertAll(ctVals, v => v.ToEnum<TCtype>());
	}

	/// <summary>
	/// Retrieves character type information for the characters in the specified Unicode source string. For each character in the string,
	/// the function sets one or more bits in the corresponding 16-bit element of the output array. Each bit identifies a given character
	/// type, for example, letter, digit, or neither.
	/// </summary>
	/// <param name="dwInfoType">
	/// <para>
	/// Flags specifying the character type information to retrieve. This parameter can have the following values. The character types
	/// are divided into different levels as described in the Remarks section.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CT_CTYPE1</term>
	/// <term>Retrieve character type information.</term>
	/// </item>
	/// <item>
	/// <term>CT_CTYPE2</term>
	/// <term>Retrieve bidirectional layout information.</term>
	/// </item>
	/// <item>
	/// <term>CT_CTYPE3</term>
	/// <term>Retrieve text processing information.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpSrcStr">
	/// Pointer to the Unicode string for which to retrieve the character types. The string is assumed to be null-terminated if cchSrc is
	/// set to any negative value.
	/// </param>
	/// <param name="cchSrc">
	/// Size, in characters, of the string indicated by lpSrcStr. If the size includes a terminating null character, the function
	/// retrieves character type information for that character. If the application sets the size to any negative integer, the source
	/// string is assumed to be null-terminated and the function calculates the size automatically with an additional character for the
	/// null termination.
	/// </param>
	/// <param name="lpCharType">
	/// Pointer to an array of 16-bit values. The length of this array must be large enough to receive one 16-bit value for each
	/// character in the source string. If cchSrc is not a negative number, lpCharType should be an array of words with cchSrc elements.
	/// If cchSrc is set to a negative number, lpCharType is an array of words with lpSrcStr + 1 elements. When the function returns,
	/// this array contains one word corresponding to each character in the source string.
	/// </param>
	/// <returns>
	/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call
	/// <c>GetLastError</c>, which can return one of the following error codes:
	/// </returns>
	// BOOL GetStringTypeW( _In_ DWORD dwInfoType, _In_ LPCWSTR lpSrcStr, _In_ int cchSrc, _Out_ LPWORD lpCharType); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318119(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("Stringapiset.h", MSDNShortId = "dd318119")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetStringTypeW(CHAR_TYPE_INFO dwInfoType, string lpSrcStr, int cchSrc,
		[In, Out, MarshalAs(UnmanagedType.LPArray)] ushort[] lpCharType);

	/// <summary>
	/// Maps a character string to a UTF-16 (wide character) string. The character string is not necessarily from a multibyte character set.
	/// </summary>
	/// <param name="CodePage">
	/// <para>
	/// Code page to use in performing the conversion. This parameter can be set to the value of any code page that is installed or
	/// available in the operating system. For a list of code pages, see Code Page Identifiers. Your application can also specify one of
	/// the values shown in the following table.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CP_ACP</term>
	/// <term>The system default Windows ANSI code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_MACCP</term>
	/// <term>The current system Macintosh code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_OEMCP</term>
	/// <term>The current system OEM code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_SYMBOL</term>
	/// <term>Symbol code page (42).</term>
	/// </item>
	/// <item>
	/// <term>CP_THREAD_ACP</term>
	/// <term>The Windows ANSI code page for the current thread.</term>
	/// </item>
	/// <item>
	/// <term>CP_UTF7</term>
	/// <term>UTF-7. Use this value only when forced by a 7-bit transport mechanism. Use of UTF-8 is preferred.</term>
	/// </item>
	/// <item>
	/// <term>CP_UTF8</term>
	/// <term>UTF-8.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Flags indicating the conversion type. The application can specify a combination of the following values, with MB_PRECOMPOSED
	/// being the default. MB_PRECOMPOSED and MB_COMPOSITE are mutually exclusive. MB_USEGLYPHCHARS and MB_ERR_INVALID_CHARS can be set
	/// regardless of the state of the other flags.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MB_COMPOSITE</term>
	/// <term>
	/// Always use decomposed characters, that is, characters in which a base character and one or more nonspacing characters each have
	/// distinct code point values. For example, &amp;#196; is represented by A + &amp;#168;: LATIN CAPITAL LETTER A (U+0041) + COMBINING
	/// DIAERESIS (U+0308). Note that this flag cannot be used with MB_PRECOMPOSED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MB_ERR_INVALID_CHARS</term>
	/// <term>
	/// Fail if an invalid input character is encountered. Starting with Windows Vista, the function does not drop illegal code points if
	/// the application does not set this flag, but instead replaces illegal sequences with U+FFFD (encoded as appropriate for the
	/// specified codepage).Windows 2000 with SP4 and later, Windows XP: If this flag is not set, the function silently drops illegal
	/// code points. A call to GetLastError returns ERROR_NO_UNICODE_TRANSLATION.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MB_PRECOMPOSED</term>
	/// <term>
	/// Default; do not use with MB_COMPOSITE. Always use precomposed characters, that is, characters having a single character value for
	/// a base or nonspacing character combination. For example, in the character &amp;#232;, the e is the base character and the accent
	/// grave mark is the nonspacing character. If a single Unicode code point is defined for a character, the application should use it
	/// instead of a separate base character and a nonspacing character. For example, &amp;#196; is represented by the single Unicode
	/// code point LATIN CAPITAL LETTER A WITH DIAERESIS (U+00C4).
	/// </term>
	/// </item>
	/// <item>
	/// <term>MB_USEGLYPHCHARS</term>
	/// <term>Use glyph characters instead of control characters.</term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>For the code pages listed below, dwFlags must be set to 0. Otherwise, the function fails with ERROR_INVALID_FLAGS.</para>
	/// </param>
	/// <param name="lpMultiByteStr">Pointer to the character string to convert.</param>
	/// <param name="cbMultiByte">
	/// <para>
	/// Size, in bytes, of the string indicated by the lpMultiByteStr parameter. Alternatively, this parameter can be set to -1 if the
	/// string is null-terminated. Note that, if cbMultiByte is 0, the function fails.
	/// </para>
	/// <para>
	/// If this parameter is -1, the function processes the entire input string, including the terminating null character. Therefore, the
	/// resulting Unicode string has a terminating null character, and the length returned by the function includes this character.
	/// </para>
	/// <para>
	/// If this parameter is set to a positive integer, the function processes exactly the specified number of bytes. If the provided
	/// size does not include a terminating null character, the resulting Unicode string is not null-terminated, and the returned length
	/// does not include this character.
	/// </para>
	/// </param>
	/// <param name="lpWideCharStr">Pointer to a buffer that receives the converted string.</param>
	/// <param name="cchWideChar">
	/// Size, in characters, of the buffer indicated by lpWideCharStr. If this value is 0, the function returns the required buffer size,
	/// in characters, including any terminating null character, and makes no use of the lpWideCharStr buffer.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns the number of characters written to the buffer indicated by lpWideCharStr if successful. If the function succeeds and
	/// cchWideChar is 0, the return value is the required size, in characters, for the buffer indicated by lpWideCharStr. Also see
	/// dwFlags for info about how the MB_ERR_INVALID_CHARS flag affects the return value when invalid sequences are input.
	/// </para>
	/// <para>
	/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>,
	/// which can return one of the following error codes:
	/// </para>
	/// </returns>
	// int MultiByteToWideChar( _In_ UINT CodePage, _In_ DWORD dwFlags, _In_ LPCSTR lpMultiByteStr, _In_ int cbMultiByte, _Out_opt_
	// LPWSTR lpWideCharStr, _In_ int cchWideChar); https://msdn.microsoft.com/en-us/library/windows/desktop/dd319072(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Stringapiset.h", MSDNShortId = "dd319072")]
	public static extern int MultiByteToWideChar(uint CodePage, MBCONV dwFlags, [MarshalAs(UnmanagedType.LPStr)] string lpMultiByteStr,
		int cbMultiByte, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpWideCharStr, int cchWideChar);

	/// <summary>
	/// Maps a character string to a UTF-16 (wide character) string. The character string is not necessarily from a multibyte character set.
	/// </summary>
	/// <param name="CodePage">
	/// <para>
	/// Code page to use in performing the conversion. This parameter can be set to the value of any code page that is installed or
	/// available in the operating system. For a list of code pages, see Code Page Identifiers. Your application can also specify one of
	/// the values shown in the following table.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CP_ACP</term>
	/// <term>The system default Windows ANSI code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_MACCP</term>
	/// <term>The current system Macintosh code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_OEMCP</term>
	/// <term>The current system OEM code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_SYMBOL</term>
	/// <term>Symbol code page (42).</term>
	/// </item>
	/// <item>
	/// <term>CP_THREAD_ACP</term>
	/// <term>The Windows ANSI code page for the current thread.</term>
	/// </item>
	/// <item>
	/// <term>CP_UTF7</term>
	/// <term>UTF-7. Use this value only when forced by a 7-bit transport mechanism. Use of UTF-8 is preferred.</term>
	/// </item>
	/// <item>
	/// <term>CP_UTF8</term>
	/// <term>UTF-8.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Flags indicating the conversion type. The application can specify a combination of the following values, with MB_PRECOMPOSED
	/// being the default. MB_PRECOMPOSED and MB_COMPOSITE are mutually exclusive. MB_USEGLYPHCHARS and MB_ERR_INVALID_CHARS can be set
	/// regardless of the state of the other flags.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MB_COMPOSITE</term>
	/// <term>
	/// Always use decomposed characters, that is, characters in which a base character and one or more nonspacing characters each have
	/// distinct code point values. For example, &amp;#196; is represented by A + &amp;#168;: LATIN CAPITAL LETTER A (U+0041) + COMBINING
	/// DIAERESIS (U+0308). Note that this flag cannot be used with MB_PRECOMPOSED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MB_ERR_INVALID_CHARS</term>
	/// <term>
	/// Fail if an invalid input character is encountered. Starting with Windows Vista, the function does not drop illegal code points if
	/// the application does not set this flag, but instead replaces illegal sequences with U+FFFD (encoded as appropriate for the
	/// specified codepage).Windows 2000 with SP4 and later, Windows XP: If this flag is not set, the function silently drops illegal
	/// code points. A call to GetLastError returns ERROR_NO_UNICODE_TRANSLATION.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MB_PRECOMPOSED</term>
	/// <term>
	/// Default; do not use with MB_COMPOSITE. Always use precomposed characters, that is, characters having a single character value for
	/// a base or nonspacing character combination. For example, in the character &amp;#232;, the e is the base character and the accent
	/// grave mark is the nonspacing character. If a single Unicode code point is defined for a character, the application should use it
	/// instead of a separate base character and a nonspacing character. For example, &amp;#196; is represented by the single Unicode
	/// code point LATIN CAPITAL LETTER A WITH DIAERESIS (U+00C4).
	/// </term>
	/// </item>
	/// <item>
	/// <term>MB_USEGLYPHCHARS</term>
	/// <term>Use glyph characters instead of control characters.</term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>For the code pages listed below, dwFlags must be set to 0. Otherwise, the function fails with ERROR_INVALID_FLAGS.</para>
	/// </param>
	/// <param name="lpMultiByteStr">Pointer to the character string to convert.</param>
	/// <param name="cbMultiByte">
	/// <para>
	/// Size, in bytes, of the string indicated by the lpMultiByteStr parameter. Alternatively, this parameter can be set to -1 if the
	/// string is null-terminated. Note that, if cbMultiByte is 0, the function fails.
	/// </para>
	/// <para>
	/// If this parameter is -1, the function processes the entire input string, including the terminating null character. Therefore, the
	/// resulting Unicode string has a terminating null character, and the length returned by the function includes this character.
	/// </para>
	/// <para>
	/// If this parameter is set to a positive integer, the function processes exactly the specified number of bytes. If the provided
	/// size does not include a terminating null character, the resulting Unicode string is not null-terminated, and the returned length
	/// does not include this character.
	/// </para>
	/// </param>
	/// <param name="lpWideCharStr">Pointer to a buffer that receives the converted string.</param>
	/// <param name="cchWideChar">
	/// Size, in characters, of the buffer indicated by lpWideCharStr. If this value is 0, the function returns the required buffer size,
	/// in characters, including any terminating null character, and makes no use of the lpWideCharStr buffer.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns the number of characters written to the buffer indicated by lpWideCharStr if successful. If the function succeeds and
	/// cchWideChar is 0, the return value is the required size, in characters, for the buffer indicated by lpWideCharStr. Also see
	/// dwFlags for info about how the MB_ERR_INVALID_CHARS flag affects the return value when invalid sequences are input.
	/// </para>
	/// <para>
	/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>,
	/// which can return one of the following error codes:
	/// </para>
	/// </returns>
	// int MultiByteToWideChar( _In_ UINT CodePage, _In_ DWORD dwFlags, _In_ LPCSTR lpMultiByteStr, _In_ int cbMultiByte, _Out_opt_
	// LPWSTR lpWideCharStr, _In_ int cchWideChar); https://msdn.microsoft.com/en-us/library/windows/desktop/dd319072(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Stringapiset.h", MSDNShortId = "dd319072")]
	public static extern int MultiByteToWideChar(uint CodePage, MBCONV dwFlags, [MarshalAs(UnmanagedType.LPStr)] string lpMultiByteStr,
		int cbMultiByte, [Out, Optional] byte[]? lpWideCharStr, [Optional] int cchWideChar);

	/// <summary>
	/// Maps a UTF-16 (wide character) string to a new character string. The new character string is not necessarily from a multibyte
	/// character set.
	/// </summary>
	/// <param name="CodePage">
	/// <para>
	/// Code page to use in performing the conversion. This parameter can be set to the value of any code page that is installed or
	/// available in the operating system. For a list of code pages, see Code Page Identifiers. Your application can also specify one of
	/// the values shown in the following table.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CP_ACP</term>
	/// <term>The system default Windows ANSI code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_MACCP</term>
	/// <term>The current system Macintosh code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_OEMCP</term>
	/// <term>The current system OEM code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_SYMBOL</term>
	/// <term>Windows 2000: Symbol code page (42).</term>
	/// </item>
	/// <item>
	/// <term>CP_THREAD_ACP</term>
	/// <term>Windows 2000: The Windows ANSI code page for the current thread.</term>
	/// </item>
	/// <item>
	/// <term>CP_UTF7</term>
	/// <term>
	/// UTF-7. Use this value only when forced by a 7-bit transport mechanism. Use of UTF-8 is preferred. With this value set,
	/// lpDefaultChar and lpUsedDefaultChar must be set to NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CP_UTF8</term>
	/// <term>UTF-8. With this value set, lpDefaultChar and lpUsedDefaultChar must be set to NULL.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Flags indicating the conversion type. The application can specify a combination of the following values. The function performs
	/// more quickly when none of these flags is set. The application should specify WC_NO_BEST_FIT_CHARS and WC_COMPOSITECHECK with the
	/// specific value WC_DEFAULTCHAR to retrieve all possible conversion results. If all three values are not provided, some results
	/// will be missing.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WC_COMPOSITECHECK</term>
	/// <term>
	/// Convert composite characters, consisting of a base character and a nonspacing character, each with different character values.
	/// Translate these characters to precomposed characters, which have a single character value for a base-nonspacing character
	/// combination. For example, in the character &amp;#232;, the e is the base character and the accent grave mark is the nonspacing
	/// character.Your application can combine WC_COMPOSITECHECK with any one of the following flags, with the default being WC_SEPCHARS.
	/// These flags determine the behavior of the function when no precomposed mapping for a base-nonspacing character combination in a
	/// Unicode string is available. If none of these flags is supplied, the function behaves as if the WC_SEPCHARS flag is set. For more
	/// information, see WC_COMPOSITECHECK and related flags in the Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WC_ERR_INVALID_CHARS</term>
	/// <term>
	/// Windows Vista and later: Fail (by returning 0 and setting the last-error code to ERROR_NO_UNICODE_TRANSLATION) if an invalid
	/// input character is encountered. You can retrieve the last-error code with a call to GetLastError. If this flag is not set, the
	/// function replaces illegal sequences with U+FFFD (encoded as appropriate for the specified codepage) and succeeds by returning the
	/// length of the converted string. Note that this flag only applies when CodePage is specified as CP_UTF8 or 54936. It cannot be
	/// used with other code page values.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WC_NO_BEST_FIT_CHARS</term>
	/// <term>
	/// Translate any Unicode characters that do not translate directly to multibyte equivalents to the default character specified by
	/// lpDefaultChar. In other words, if translating from Unicode to multibyte and back to Unicode again does not yield the same Unicode
	/// character, the function uses the default character. This flag can be used by itself or in combination with the other defined
	/// flags.For strings that require validation, such as file, resource, and user names, the application should always use the
	/// WC_NO_BEST_FIT_CHARS flag. This flag prevents the function from mapping characters to characters that appear similar but have
	/// very different semantics. In some cases, the semantic change can be extreme. For example, the symbol for &amp;quot;∞&amp;quot;
	/// (infinity) maps to 8 (eight) in some code pages.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>For the code pages listed below, dwFlags must be 0. Otherwise, the function fails with ERROR_INVALID_FLAGS.</para>
	/// </param>
	/// <param name="lpWideCharStr">Pointer to the Unicode string to convert.</param>
	/// <param name="cchWideChar">
	/// <para>
	/// Size, in characters, of the string indicated by lpWideCharStr. Alternatively, this parameter can be set to -1 if the string is
	/// null-terminated. If cchWideChar is set to 0, the function fails.
	/// </para>
	/// <para>
	/// If this parameter is -1, the function processes the entire input string, including the terminating null character. Therefore, the
	/// resulting character string has a terminating null character, and the length returned by the function includes this character.
	/// </para>
	/// <para>
	/// If this parameter is set to a positive integer, the function processes exactly the specified number of characters. If the
	/// provided size does not include a terminating null character, the resulting character string is not null-terminated, and the
	/// returned length does not include this character.
	/// </para>
	/// </param>
	/// <param name="lpMultiByteStr">Pointer to a buffer that receives the converted string.</param>
	/// <param name="cbMultiByte">
	/// Size, in bytes, of the buffer indicated by lpMultiByteStr. If this parameter is set to 0, the function returns the required
	/// buffer size for lpMultiByteStr and makes no use of the output parameter itself.
	/// </param>
	/// <param name="lpDefaultChar">
	/// <para>
	/// Pointer to the character to use if a character cannot be represented in the specified code page. The application sets this
	/// parameter to <c>NULL</c> if the function is to use a system default value. To obtain the system default character, the
	/// application can call the <c>GetCPInfo</c> or <c>GetCPInfoEx</c> function.
	/// </para>
	/// <para>
	/// For the CP_UTF7 and CP_UTF8 settings for CodePage, this parameter must be set to <c>NULL</c>. Otherwise, the function fails with ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <param name="lpUsedDefaultChar">
	/// <para>
	/// Pointer to a flag that indicates if the function has used a default character in the conversion. The flag is set to <c>TRUE</c>
	/// if one or more characters in the source string cannot be represented in the specified code page. Otherwise, the flag is set to
	/// <c>FALSE</c>. This parameter can be set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// For the CP_UTF7 and CP_UTF8 settings for CodePage, this parameter must be set to <c>NULL</c>. Otherwise, the function fails with ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If successful, returns the number of bytes written to the buffer pointed to by lpMultiByteStr. If the function succeeds and
	/// cbMultiByte is 0, the return value is the required size, in bytes, for the buffer indicated by lpMultiByteStr. Also see dwFlags
	/// for info about how the WC_ERR_INVALID_CHARS flag affects the return value when invalid sequences are input.
	/// </para>
	/// <para>
	/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>,
	/// which can return one of the following error codes:
	/// </para>
	/// </returns>
	// int WideCharToMultiByte( _In_ UINT CodePage, _In_ DWORD dwFlags, _In_ LPCWSTR lpWideCharStr, _In_ int cchWideChar, _Out_opt_ LPSTR
	// lpMultiByteStr, _In_ int cbMultiByte, _In_opt_ LPCSTR lpDefaultChar, _Out_opt_ LPBOOL lpUsedDefaultChar); https://msdn.microsoft.com/en-us/library/windows/desktop/dd374130(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Stringapiset.h", MSDNShortId = "dd374130")]
	public static extern int WideCharToMultiByte(uint CodePage, WCCONV dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string lpWideCharStr,
		int cchWideChar, [Out, Optional, MarshalAs(UnmanagedType.LPStr)] StringBuilder? lpMultiByteStr, int cbMultiByte,
		[Optional, MarshalAs(UnmanagedType.LPStr)] string? lpDefaultChar, [MarshalAs(UnmanagedType.Bool)] out bool lpUsedDefaultChar);

	/// <summary>
	/// Maps a UTF-16 (wide character) string to a new character string. The new character string is not necessarily from a multibyte
	/// character set.
	/// </summary>
	/// <param name="CodePage">
	/// <para>
	/// Code page to use in performing the conversion. This parameter can be set to the value of any code page that is installed or
	/// available in the operating system. For a list of code pages, see Code Page Identifiers. Your application can also specify one of
	/// the values shown in the following table.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CP_ACP</term>
	/// <term>The system default Windows ANSI code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_MACCP</term>
	/// <term>The current system Macintosh code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_OEMCP</term>
	/// <term>The current system OEM code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_SYMBOL</term>
	/// <term>Windows 2000: Symbol code page (42).</term>
	/// </item>
	/// <item>
	/// <term>CP_THREAD_ACP</term>
	/// <term>Windows 2000: The Windows ANSI code page for the current thread.</term>
	/// </item>
	/// <item>
	/// <term>CP_UTF7</term>
	/// <term>
	/// UTF-7. Use this value only when forced by a 7-bit transport mechanism. Use of UTF-8 is preferred. With this value set,
	/// lpDefaultChar and lpUsedDefaultChar must be set to NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CP_UTF8</term>
	/// <term>UTF-8. With this value set, lpDefaultChar and lpUsedDefaultChar must be set to NULL.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Flags indicating the conversion type. The application can specify a combination of the following values. The function performs
	/// more quickly when none of these flags is set. The application should specify WC_NO_BEST_FIT_CHARS and WC_COMPOSITECHECK with the
	/// specific value WC_DEFAULTCHAR to retrieve all possible conversion results. If all three values are not provided, some results
	/// will be missing.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WC_COMPOSITECHECK</term>
	/// <term>
	/// Convert composite characters, consisting of a base character and a nonspacing character, each with different character values.
	/// Translate these characters to precomposed characters, which have a single character value for a base-nonspacing character
	/// combination. For example, in the character &amp;#232;, the e is the base character and the accent grave mark is the nonspacing
	/// character.Your application can combine WC_COMPOSITECHECK with any one of the following flags, with the default being WC_SEPCHARS.
	/// These flags determine the behavior of the function when no precomposed mapping for a base-nonspacing character combination in a
	/// Unicode string is available. If none of these flags is supplied, the function behaves as if the WC_SEPCHARS flag is set. For more
	/// information, see WC_COMPOSITECHECK and related flags in the Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WC_ERR_INVALID_CHARS</term>
	/// <term>
	/// Windows Vista and later: Fail (by returning 0 and setting the last-error code to ERROR_NO_UNICODE_TRANSLATION) if an invalid
	/// input character is encountered. You can retrieve the last-error code with a call to GetLastError. If this flag is not set, the
	/// function replaces illegal sequences with U+FFFD (encoded as appropriate for the specified codepage) and succeeds by returning the
	/// length of the converted string. Note that this flag only applies when CodePage is specified as CP_UTF8 or 54936. It cannot be
	/// used with other code page values.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WC_NO_BEST_FIT_CHARS</term>
	/// <term>
	/// Translate any Unicode characters that do not translate directly to multibyte equivalents to the default character specified by
	/// lpDefaultChar. In other words, if translating from Unicode to multibyte and back to Unicode again does not yield the same Unicode
	/// character, the function uses the default character. This flag can be used by itself or in combination with the other defined
	/// flags.For strings that require validation, such as file, resource, and user names, the application should always use the
	/// WC_NO_BEST_FIT_CHARS flag. This flag prevents the function from mapping characters to characters that appear similar but have
	/// very different semantics. In some cases, the semantic change can be extreme. For example, the symbol for &amp;quot;∞&amp;quot;
	/// (infinity) maps to 8 (eight) in some code pages.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>For the code pages listed below, dwFlags must be 0. Otherwise, the function fails with ERROR_INVALID_FLAGS.</para>
	/// </param>
	/// <param name="lpWideCharStr">Pointer to the Unicode string to convert.</param>
	/// <param name="cchWideChar">
	/// <para>
	/// Size, in characters, of the string indicated by lpWideCharStr. Alternatively, this parameter can be set to -1 if the string is
	/// null-terminated. If cchWideChar is set to 0, the function fails.
	/// </para>
	/// <para>
	/// If this parameter is -1, the function processes the entire input string, including the terminating null character. Therefore, the
	/// resulting character string has a terminating null character, and the length returned by the function includes this character.
	/// </para>
	/// <para>
	/// If this parameter is set to a positive integer, the function processes exactly the specified number of characters. If the
	/// provided size does not include a terminating null character, the resulting character string is not null-terminated, and the
	/// returned length does not include this character.
	/// </para>
	/// </param>
	/// <param name="lpMultiByteStr">Pointer to a buffer that receives the converted string.</param>
	/// <param name="cbMultiByte">
	/// Size, in bytes, of the buffer indicated by lpMultiByteStr. If this parameter is set to 0, the function returns the required
	/// buffer size for lpMultiByteStr and makes no use of the output parameter itself.
	/// </param>
	/// <param name="lpDefaultChar">
	/// <para>
	/// Pointer to the character to use if a character cannot be represented in the specified code page. The application sets this
	/// parameter to <c>NULL</c> if the function is to use a system default value. To obtain the system default character, the
	/// application can call the <c>GetCPInfo</c> or <c>GetCPInfoEx</c> function.
	/// </para>
	/// <para>
	/// For the CP_UTF7 and CP_UTF8 settings for CodePage, this parameter must be set to <c>NULL</c>. Otherwise, the function fails with ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <param name="lpUsedDefaultChar">
	/// <para>
	/// Pointer to a flag that indicates if the function has used a default character in the conversion. The flag is set to <c>TRUE</c>
	/// if one or more characters in the source string cannot be represented in the specified code page. Otherwise, the flag is set to
	/// <c>FALSE</c>. This parameter can be set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// For the CP_UTF7 and CP_UTF8 settings for CodePage, this parameter must be set to <c>NULL</c>. Otherwise, the function fails with ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If successful, returns the number of bytes written to the buffer pointed to by lpMultiByteStr. If the function succeeds and
	/// cbMultiByte is 0, the return value is the required size, in bytes, for the buffer indicated by lpMultiByteStr. Also see dwFlags
	/// for info about how the WC_ERR_INVALID_CHARS flag affects the return value when invalid sequences are input.
	/// </para>
	/// <para>
	/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>,
	/// which can return one of the following error codes:
	/// </para>
	/// </returns>
	// int WideCharToMultiByte( _In_ UINT CodePage, _In_ DWORD dwFlags, _In_ LPCWSTR lpWideCharStr, _In_ int cchWideChar, _Out_opt_ LPSTR
	// lpMultiByteStr, _In_ int cbMultiByte, _In_opt_ LPCSTR lpDefaultChar, _Out_opt_ LPBOOL lpUsedDefaultChar); https://msdn.microsoft.com/en-us/library/windows/desktop/dd374130(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Stringapiset.h", MSDNShortId = "dd374130")]
	public static extern int WideCharToMultiByte(uint CodePage, WCCONV dwFlags, [In][MarshalAs(UnmanagedType.LPWStr)] string lpWideCharStr,
		int cchWideChar, [Out, Optional, MarshalAs(UnmanagedType.LPStr)] StringBuilder? lpMultiByteStr, int cbMultiByte,
		IntPtr lpDefaultChar = default, IntPtr lpUsedDefaultChar = default);

	/// <summary>
	/// Maps a UTF-16 (wide character) string to a new character string. The new character string is not necessarily from a multibyte
	/// character set.
	/// </summary>
	/// <param name="CodePage">
	/// <para>
	/// Code page to use in performing the conversion. This parameter can be set to the value of any code page that is installed or
	/// available in the operating system. For a list of code pages, see Code Page Identifiers. Your application can also specify one of
	/// the values shown in the following table.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CP_ACP</term>
	/// <term>The system default Windows ANSI code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_MACCP</term>
	/// <term>The current system Macintosh code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_OEMCP</term>
	/// <term>The current system OEM code page.</term>
	/// </item>
	/// <item>
	/// <term>CP_SYMBOL</term>
	/// <term>Windows 2000: Symbol code page (42).</term>
	/// </item>
	/// <item>
	/// <term>CP_THREAD_ACP</term>
	/// <term>Windows 2000: The Windows ANSI code page for the current thread.</term>
	/// </item>
	/// <item>
	/// <term>CP_UTF7</term>
	/// <term>
	/// UTF-7. Use this value only when forced by a 7-bit transport mechanism. Use of UTF-8 is preferred. With this value set,
	/// lpDefaultChar and lpUsedDefaultChar must be set to NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CP_UTF8</term>
	/// <term>UTF-8. With this value set, lpDefaultChar and lpUsedDefaultChar must be set to NULL.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Flags indicating the conversion type. The application can specify a combination of the following values. The function performs
	/// more quickly when none of these flags is set. The application should specify WC_NO_BEST_FIT_CHARS and WC_COMPOSITECHECK with the
	/// specific value WC_DEFAULTCHAR to retrieve all possible conversion results. If all three values are not provided, some results
	/// will be missing.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WC_COMPOSITECHECK</term>
	/// <term>
	/// Convert composite characters, consisting of a base character and a nonspacing character, each with different character values.
	/// Translate these characters to precomposed characters, which have a single character value for a base-nonspacing character
	/// combination. For example, in the character &amp;#232;, the e is the base character and the accent grave mark is the nonspacing
	/// character.Your application can combine WC_COMPOSITECHECK with any one of the following flags, with the default being WC_SEPCHARS.
	/// These flags determine the behavior of the function when no precomposed mapping for a base-nonspacing character combination in a
	/// Unicode string is available. If none of these flags is supplied, the function behaves as if the WC_SEPCHARS flag is set. For more
	/// information, see WC_COMPOSITECHECK and related flags in the Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WC_ERR_INVALID_CHARS</term>
	/// <term>
	/// Windows Vista and later: Fail (by returning 0 and setting the last-error code to ERROR_NO_UNICODE_TRANSLATION) if an invalid
	/// input character is encountered. You can retrieve the last-error code with a call to GetLastError. If this flag is not set, the
	/// function replaces illegal sequences with U+FFFD (encoded as appropriate for the specified codepage) and succeeds by returning the
	/// length of the converted string. Note that this flag only applies when CodePage is specified as CP_UTF8 or 54936. It cannot be
	/// used with other code page values.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WC_NO_BEST_FIT_CHARS</term>
	/// <term>
	/// Translate any Unicode characters that do not translate directly to multibyte equivalents to the default character specified by
	/// lpDefaultChar. In other words, if translating from Unicode to multibyte and back to Unicode again does not yield the same Unicode
	/// character, the function uses the default character. This flag can be used by itself or in combination with the other defined
	/// flags.For strings that require validation, such as file, resource, and user names, the application should always use the
	/// WC_NO_BEST_FIT_CHARS flag. This flag prevents the function from mapping characters to characters that appear similar but have
	/// very different semantics. In some cases, the semantic change can be extreme. For example, the symbol for &amp;quot;∞&amp;quot;
	/// (infinity) maps to 8 (eight) in some code pages.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>For the code pages listed below, dwFlags must be 0. Otherwise, the function fails with ERROR_INVALID_FLAGS.</para>
	/// </param>
	/// <param name="lpWideCharStr">Pointer to the Unicode string to convert.</param>
	/// <param name="cchWideChar">
	/// <para>
	/// Size, in characters, of the string indicated by lpWideCharStr. Alternatively, this parameter can be set to -1 if the string is
	/// null-terminated. If cchWideChar is set to 0, the function fails.
	/// </para>
	/// <para>
	/// If this parameter is -1, the function processes the entire input string, including the terminating null character. Therefore, the
	/// resulting character string has a terminating null character, and the length returned by the function includes this character.
	/// </para>
	/// <para>
	/// If this parameter is set to a positive integer, the function processes exactly the specified number of characters. If the
	/// provided size does not include a terminating null character, the resulting character string is not null-terminated, and the
	/// returned length does not include this character.
	/// </para>
	/// </param>
	/// <param name="lpMultiByteStr">Pointer to a buffer that receives the converted string.</param>
	/// <param name="cbMultiByte">
	/// Size, in bytes, of the buffer indicated by lpMultiByteStr. If this parameter is set to 0, the function returns the required
	/// buffer size for lpMultiByteStr and makes no use of the output parameter itself.
	/// </param>
	/// <param name="lpDefaultChar">
	/// <para>
	/// Pointer to the character to use if a character cannot be represented in the specified code page. The application sets this
	/// parameter to <c>NULL</c> if the function is to use a system default value. To obtain the system default character, the
	/// application can call the <c>GetCPInfo</c> or <c>GetCPInfoEx</c> function.
	/// </para>
	/// <para>
	/// For the CP_UTF7 and CP_UTF8 settings for CodePage, this parameter must be set to <c>NULL</c>. Otherwise, the function fails with ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <param name="lpUsedDefaultChar">
	/// <para>
	/// Pointer to a flag that indicates if the function has used a default character in the conversion. The flag is set to <c>TRUE</c>
	/// if one or more characters in the source string cannot be represented in the specified code page. Otherwise, the flag is set to
	/// <c>FALSE</c>. This parameter can be set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// For the CP_UTF7 and CP_UTF8 settings for CodePage, this parameter must be set to <c>NULL</c>. Otherwise, the function fails with ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If successful, returns the number of bytes written to the buffer pointed to by lpMultiByteStr. If the function succeeds and
	/// cbMultiByte is 0, the return value is the required size, in bytes, for the buffer indicated by lpMultiByteStr. Also see dwFlags
	/// for info about how the WC_ERR_INVALID_CHARS flag affects the return value when invalid sequences are input.
	/// </para>
	/// <para>
	/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>,
	/// which can return one of the following error codes:
	/// </para>
	/// </returns>
	// int WideCharToMultiByte( _In_ UINT CodePage, _In_ DWORD dwFlags, _In_ LPCWSTR lpWideCharStr, _In_ int cchWideChar, _Out_opt_ LPSTR
	// lpMultiByteStr, _In_ int cbMultiByte, _In_opt_ LPCSTR lpDefaultChar, _Out_opt_ LPBOOL lpUsedDefaultChar); https://msdn.microsoft.com/en-us/library/windows/desktop/dd374130(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Stringapiset.h", MSDNShortId = "dd374130")]
	public static extern int WideCharToMultiByte(uint CodePage, WCCONV dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string lpWideCharStr,
		int cchWideChar, [Out, Optional] byte[]? lpMultiByteStr, int cbMultiByte, IntPtr lpDefaultChar = default, IntPtr lpUsedDefaultChar = default);
}