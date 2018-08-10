using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class ShlwApi
	{
		/// <summary>The flags that specify how to determine the scheme.</summary>
		[PInvokeData("shlwapi.h", MSDNShortId = "af60643e-b1a4-4013-b116-dd9fad4e90bf")]
		[Flags]
		public enum URL_APPLY
		{
			/// <summary>
			/// Apply the default scheme if <c>UrlApplyScheme</c> can't determine one. The default prefix is stored in the registry but is
			/// typically "http".
			/// </summary>
			URL_APPLY_DEFAULT = 0x01,

			/// <summary>Attempt to determine the scheme by examining pszIn.</summary>
			URL_APPLY_GUESSSCHEME = 0x02,

			/// <summary>Attempt to determine a file URL from pszIn.</summary>
			URL_APPLY_GUESSFILE = 0x04,

			/// <summary>Force <c>UrlApplyScheme</c> to determine a scheme for pszIn.</summary>
			URL_APPLY_FORCEAPPLY = 0x08,
		}

		/// <summary>
		/// <para>Used to specify URL schemes.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/ne-shlwapi-url_scheme typedef enum URL_SCHEME { URL_SCHEME_INVALID ,
		// URL_SCHEME_UNKNOWN , URL_SCHEME_FTP , URL_SCHEME_HTTP , URL_SCHEME_GOPHER , URL_SCHEME_MAILTO , URL_SCHEME_NEWS , URL_SCHEME_NNTP
		// , URL_SCHEME_TELNET , URL_SCHEME_WAIS , URL_SCHEME_FILE , URL_SCHEME_MK , URL_SCHEME_HTTPS , URL_SCHEME_SHELL , URL_SCHEME_SNEWS ,
		// URL_SCHEME_LOCAL , URL_SCHEME_JAVASCRIPT , URL_SCHEME_VBSCRIPT , URL_SCHEME_ABOUT , URL_SCHEME_RES , URL_SCHEME_MSSHELLROOTED ,
		// URL_SCHEME_MSSHELLIDLIST , URL_SCHEME_MSHELP , URL_SCHEME_MSSHELLDEVICE , URL_SCHEME_WILDCARD , URL_SCHEME_SEARCH_MS ,
		// URL_SCHEME_SEARCH , URL_SCHEME_KNOWNFOLDER , URL_SCHEME_MAXVALUE } ;
		[PInvokeData("shlwapi.h", MSDNShortId = "45686920-356d-4dd7-8482-2427854a92ed")]
		public enum URL_SCHEME
		{
			/// <summary>An invalid scheme.</summary>
			URL_SCHEME_INVALID = -1,

			/// <summary>An unknown scheme.</summary>
			URL_SCHEME_UNKNOWN = 0,

			/// <summary>FTP (ftp:).</summary>
			URL_SCHEME_FTP,

			/// <summary>HTTP (http:).</summary>
			URL_SCHEME_HTTP,

			/// <summary>Gopher (gopher:).</summary>
			URL_SCHEME_GOPHER,

			/// <summary>Mail-to (mailto:).</summary>
			URL_SCHEME_MAILTO,

			/// <summary>Usenet news (news:).</summary>
			URL_SCHEME_NEWS,

			/// <summary>Usenet news with NNTP (nntp:).</summary>
			URL_SCHEME_NNTP,

			/// <summary>Telnet (telnet:).</summary>
			URL_SCHEME_TELNET,

			/// <summary>Wide Area Information Server (wais:).</summary>
			URL_SCHEME_WAIS,

			/// <summary>File (file:).</summary>
			URL_SCHEME_FILE,

			/// <summary>URL moniker (mk:).</summary>
			URL_SCHEME_MK,

			/// <summary>URL HTTPS (https:).</summary>
			URL_SCHEME_HTTPS,

			/// <summary>Shell (shell:).</summary>
			URL_SCHEME_SHELL,

			/// <summary>NNTP news postings with SSL (snews:).</summary>
			URL_SCHEME_SNEWS,

			/// <summary>Local (local:).</summary>
			URL_SCHEME_LOCAL,

			/// <summary>JavaScript (javascript:).</summary>
			URL_SCHEME_JAVASCRIPT,

			/// <summary>VBScript (vbscript:).</summary>
			URL_SCHEME_VBSCRIPT,

			/// <summary>About (about:).</summary>
			URL_SCHEME_ABOUT,

			/// <summary>Res (res:).</summary>
			URL_SCHEME_RES,

			/// <summary>Internet Explorer 6 and later only. Shell-rooted (ms-shell-rooted:)</summary>
			URL_SCHEME_MSSHELLROOTED,

			/// <summary>Internet Explorer 6 and later only. Shell ID-list (ms-shell-idlist:).</summary>
			URL_SCHEME_MSSHELLIDLIST,

			/// <summary>Internet Explorer 6 and later only. MSHelp (hcp:).</summary>
			URL_SCHEME_MSHELP,

			/// <summary>Not supported.</summary>
			URL_SCHEME_MSSHELLDEVICE,

			/// <summary>Internet Explorer 7 and later only. Wildcard (*:).</summary>
			URL_SCHEME_WILDCARD,

			/// <summary>Windows Vista and later only. Search-MS (search-ms:).</summary>
			URL_SCHEME_SEARCH_MS,

			/// <summary>Windows Vista with SP1 and later only. Search (search:).</summary>
			URL_SCHEME_SEARCH,

			/// <summary>Windows 7 and later. Known folder (knownfolder:).</summary>
			URL_SCHEME_KNOWNFOLDER,

			/// <summary>The highest legitimate value in the enumeration, used for validation purposes.</summary>
			URL_SCHEME_MAXVALUE,
		}

		/// <summary>The flags that specify how the URL is converted to canonical form.</summary>
		[PInvokeData("shlwapi.h", MSDNShortId = "70802745-0611-4d37-800e-b50d5ea23426")]
		[Flags]
		public enum URLFLAGS : uint
		{
			/// <summary>
			/// Un-escape any escape sequences that the URLs contain, with two exceptions. The escape sequences for "?" and "#" are not
			/// un-escaped. If one of the URL_ESCAPE_XXX flags is also set, the two URLs are first un-escaped, then combined, then escaped.
			/// </summary>
			URL_UNESCAPE = 0x10000000,

			/// <summary> Replace unsafe characters with their escape sequences. Unsafe characters are those characters that may be altered
			/// during transport across the Internet, and include the (<, >, ", #, {, }, |, , ^, [, ], and ') characters. This flag applies
			/// to all URLs, including opaque URLs. </summary>
			URL_ESCAPE_UNSAFE = 0x20000000,

			/// <summary>
			/// Combine URLs with client-defined pluggable protocols, according to the W3C specification. This flag does not apply to
			/// standard protocols such as ftp, http, gopher, and so on. If this flag is set, UrlCombine does not simplify URLs, so there is
			/// no need to also set URL_DONT_SIMPLIFY.
			/// </summary>
			URL_PLUGGABLE_PROTOCOL = 0x40000000,

			/// <summary>Undocumented.</summary>
			URL_WININET_COMPATIBILITY = 0x80000000,

			/// <summary>
			/// Used only in conjunction with URL_ESCAPE_SPACES_ONLY to prevent the conversion of characters in the query (the portion of the
			/// URL following the first # or ? character encountered in the string). This flag should not be used alone, nor combined with URL_ESCAPE_SEGMENT_ONLY.
			/// </summary>
			URL_DONT_ESCAPE_EXTRA_INFO = 0x02000000,

			/// <summary>Defined to be the same as URL_DONT_ESCAPE_EXTRA_INFO.</summary>
			URL_DONT_UNESCAPE_EXTRA_INFO = URL_DONT_ESCAPE_EXTRA_INFO,

			/// <summary>Defined to be the same as URL_DONT_ESCAPE_EXTRA_INFO.</summary>
			URL_BROWSER_MODE = URL_DONT_ESCAPE_EXTRA_INFO,

			/// <summary>
			/// Convert only space characters to their escape sequences, including those space characters in the query portion of the URL.
			/// Other unsafe characters are not converted to their escape sequences. This flag assumes that pszURL does not contain a full
			/// URL. It expects only the portions following the server specification.
			/// <para>
			/// Combine this flag with URL_DONT_ESCAPE_EXTRA_INFO to prevent the conversion of space characters in the query portion of the URL.
			/// </para>
			/// <para>This flag cannot be combined with URL_ESCAPE_PERCENT or URL_ESCAPE_SEGMENT_ONLY.</para>
			/// </summary>
			URL_ESCAPE_SPACES_ONLY = 0x04000000,

			/// <summary>
			/// Treat "/./" and "/../" in a URL string as literal characters, not as shorthand for navigation. See Remarks for further discussion.
			/// </summary>
			URL_DONT_SIMPLIFY = 0x08000000,

			/// <summary>Defined to be the same as URL_DONT_SIMPLIFY.</summary>
			URL_NO_META = URL_DONT_SIMPLIFY,

			/// <summary>Converts escape sequences back into ordinary characters and overwrites the original string.</summary>
			URL_UNESCAPE_INPLACE = 0x00100000,

			/// <summary>Undocumented.</summary>
			URL_CONVERT_IF_DOSPATH = 0x00200000,

			/// <summary>Undocumented.</summary>
			URL_UNESCAPE_HIGH_ANSI_ONLY = 0x00400000,

			/// <summary>Undocumented.</summary>
			URL_INTERNAL_PATH = 0x00800000,

			/// <summary>Use DOS path compatibility mode to create "file" URIs.</summary>
			URL_FILE_USE_PATHURL = 0x00010000,

			/// <summary>Undocumented.</summary>
			URL_DONT_UNESCAPE = 0x00020000,

			/// <summary>Windows 7 and later. Percent-encode all non-ASCII characters as their UTF-8 equivalents.</summary>
			URL_ESCAPE_AS_UTF8 = 0x00040000,

			/// <summary>Windows 7 and later. Percent-unencode all non-ASCII characters as their UTF-8 equivalents.</summary>
			URL_UNESCAPE_AS_UTF8 = URL_ESCAPE_AS_UTF8,

			/// <summary>Windows 8 and later. Percent-encode all ASCII characters outside of the unreserved set from URI RFC 3986 (a-zA-Z0-9-.~_).</summary>
			URL_ESCAPE_ASCII_URI_COMPONENT = 0x00080000,

			/// <summary>Undocumented.</summary>
			URL_ESCAPE_URI_COMPONENT = (URL_ESCAPE_ASCII_URI_COMPONENT | URL_ESCAPE_AS_UTF8),

			/// <summary>Undocumented.</summary>
			URL_UNESCAPE_URI_COMPONENT = URL_UNESCAPE_AS_UTF8,

			/// <summary>
			/// Convert any % character found in the segment section of the URL (that section falling between the server specification and
			/// the first # or ? character). By default, the % character is not converted to its escape sequence. Other unsafe characters in
			/// the segment are also converted normally.
			/// <para>
			/// Combining this flag with URL_ESCAPE_SEGMENT_ONLY includes those % characters in the query portion of the URL. However, as the
			/// URL_ESCAPE_SEGMENT_ONLY flag causes the entire string to be considered the segment, any # or ? characters are also converted.
			/// </para>
			/// <para>This flag cannot be combined with URL_ESCAPE_SPACES_ONLY.</para>
			/// </summary>
			URL_ESCAPE_PERCENT = 0x00001000,

			/// <summary>
			/// Indicates that pszURL contains only that section of the URL following the server component but preceding the query. All
			/// unsafe characters in the string are converted. If a full URL is provided when this flag is set, all unsafe characters in the
			/// entire string are converted, including # and ? characters.
			/// <para>Combine this flag with URL_ESCAPE_PERCENT to include that character in the conversion.</para>
			/// <para>This flag cannot be combined with URL_ESCAPE_SPACES_ONLY or URL_DONT_ESCAPE_EXTRA_INFO.</para>
			/// </summary>
			URL_ESCAPE_SEGMENT_ONLY = 0x00002000,
		}

		/// <summary>The type of URL to be tested for. This parameter can take one of the following values.</summary>
		[PInvokeData("shlwapi.h", MSDNShortId = "2e83c953-b4c5-4411-90ca-49ffb94ee374")]
		public enum URLIS
		{
			/// <summary>Is the URL valid?</summary>
			URLIS_URL,

			/// <summary>Is the URL opaque?</summary>
			URLIS_OPAQUE,

			/// <summary>Is the URL a URL that is not typically tracked in navigation history?</summary>
			URLIS_NOHISTORY,

			/// <summary>Is the URL a file URL?</summary>
			URLIS_FILEURL,

			/// <summary>Attempt to determine a valid scheme for the URL.</summary>
			URLIS_APPLIABLE,

			/// <summary>Does the URL string end with a directory?</summary>
			URLIS_DIRECTORY,

			/// <summary>Does the URL have an appended query string?</summary>
			URLIS_HASQUERY,
		}

		/// <summary>
		/// <para>Performs rudimentary parsing of a URL.</para>
		/// </summary>
		/// <param name="pcszURL">
		/// <para>TBD</para>
		/// </param>
		/// <param name="ppu">
		/// <para>Type: <c>PARSEDURL*</c></para>
		/// <para>
		/// A pointer to a PARSEDURL structure that receives the parsed results. The calling application must set the structure's cbSize
		/// member to the size of the structure before calling <c>ParseURL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns <c>S_OK</c> on success, or a COM error code otherwise. The function returns <c>URL_E_INVALID_SYNTAX</c> (defined in
		/// Intshcut.h) if the string could not be parsed as a URL.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The parsing performed by <c>ParseURL</c> is fairly rudimentary. For more sophisticated URL parsing, use InternetCrackUrl.</para>
		/// <para>Examples</para>
		/// <para>This sample console application uses <c>ParseURL</c> to parse several simple URLs.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-parseurla LWSTDAPI ParseURLA( LPCSTR pcszURL, PARSEDURLA
		// *ppu );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "3d42dad0-b9eb-4e40-afc8-68cb85b27504")]
		public static extern HRESULT ParseURL(string pcszURL, ref PARSEDURL ppu);

		/// <summary>
		/// <para>Determines a scheme for a specified URL string, and returns a string with an appropriate prefix.</para>
		/// </summary>
		/// <param name="pszIn">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>A null-terminated string of maximum length INTERNET_MAX_URL_LENGTH that contains a URL.</para>
		/// </param>
		/// <param name="pszOut">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// A pointer to a buffer that, when this function returns successfully, receives a null-terminated string set to the URL specified
		/// by pszIn and converted to the standard scheme://URL_string format.
		/// </para>
		/// </param>
		/// <param name="pcchOut">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// The address of a value set to the number of characters in the pszOut buffer. When the function returns, the value depends on
		/// whether the function is successful or returns E_POINTER. For other return values, the value of this parameter is meaningless.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The flags that specify how to determine the scheme. The following flags can be combined.</para>
		/// <para>URL_APPLY_DEFAULT</para>
		/// <para>
		/// Apply the default scheme if <c>UrlApplyScheme</c> can't determine one. The default prefix is stored in the registry but is
		/// typically "http".
		/// </para>
		/// <para>URL_APPLY_GUESSSCHEME</para>
		/// <para>Attempt to determine the scheme by examining pszIn.</para>
		/// <para>URL_APPLY_GUESSFILE</para>
		/// <para>Attempt to determine a file URL from pszIn.</para>
		/// <para>URL_APPLY_FORCEAPPLY</para>
		/// <para>Force <c>UrlApplyScheme</c> to determine a scheme for pszIn.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns a standard COM return value, including the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>
		/// A scheme was determined. pszOut points to a string containing the URL with the scheme's prefix. The value of pcchOut is set to
		/// the number of characters in the string, not counting the terminating NULL character.
		/// </term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>There were no errors, but no prefix was prepended.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>
		/// The buffer was too small. The value of pcchOut is set to the minimum number of characters that the buffer must be able to
		/// contain, including the terminating NULL character.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the URL has a valid scheme, the string will not be modified. However, almost any combination of two or more characters
		/// followed by a colon will be parsed as a scheme. Valid characters include some common punctuation marks, such as ".". If your
		/// input string fits this description, <c>UrlApplyScheme</c> may treat it as valid and not apply a scheme. To force the function to
		/// apply a scheme to a URL, set the <c>URL_APPLY_FORCEAPPLY</c> and <c>URL_APPLY_DEFAULT</c> flags in dwFlags. This combination of
		/// flags forces the function to apply a scheme to the URL. Typically, the function will not be able to determine a valid scheme. The
		/// second flag guarantees that, if no valid scheme can be determined, the function will apply the default scheme to the URL.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-urlapplyschemea LWSTDAPI UrlApplySchemeA( PCSTR pszIn,
		// PSTR pszOut, DWORD *pcchOut, DWORD dwFlags );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "af60643e-b1a4-4013-b116-dd9fad4e90bf")]
		public static extern HRESULT UrlApplyScheme(string pszIn, StringBuilder pszOut, ref uint pcchOut, URL_APPLY dwFlags);

		/// <summary>
		/// <para>Converts a URL string into canonical form.</para>
		/// </summary>
		/// <param name="pszUrl">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of maximum length INTERNET_MAX_URL_LENGTH that contains a URL string. If the string does
		/// not refer to a file, it must include a valid scheme such as "http://".
		/// </para>
		/// </param>
		/// <param name="pszCanonicalized">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>A pointer to a buffer that, when this function returns successfully, receives the converted URL as a null-terminated string.</para>
		/// </param>
		/// <param name="pcchCanonicalized">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A pointer to a value that, on entry, is set to the number of characters in the pszCanonicalized buffer.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The flags that specify how the URL is converted to canonical form. The following flags can be combined.</para>
		/// <para>URL_UNESCAPE (0x10000000)</para>
		/// <para>
		/// Un-escape any escape sequences that the URLs contain, with two exceptions. The escape sequences for "?" and "#" are not
		/// un-escaped. If one of the URL_ESCAPE_XXX flags is also set, the two URLs are first un-escaped, then combined, then escaped.
		/// </para>
		/// <para>URL_ESCAPE_UNSAFE (0x20000000)</para>
		/// <para>
		/// Replace unsafe characters with their escape sequences. Unsafe characters are those characters that may be altered during
		/// transport across the Internet, and include the (&lt;, &gt;, ", #, {, }, |, , ^, [, ], and ') characters. This flag applies to all
		/// URLs, including opaque URLs.
		/// </para>
		/// <para>URL_PLUGGABLE_PROTOCOL (0x40000000)</para>
		/// <para>
		/// Combine URLs with client-defined pluggable protocols, according to the W3C specification. This flag does not apply to standard
		/// protocols such as ftp, http, gopher, and so on. If this flag is set, UrlCombine does not simplify URLs, so there is no need to
		/// also set <c>URL_DONT_SIMPLIFY</c>.
		/// </para>
		/// <para>URL_ESCAPE_SPACES_ONLY (0x04000000)</para>
		/// <para>
		/// Replace only spaces with escape sequences. This flag takes precedence over <c>URL_ESCAPE_UNSAFE</c>, but does not apply to opaque URLs.
		/// </para>
		/// <para>URL_DONT_SIMPLIFY (0x08000000)</para>
		/// <para>
		/// Treat "/./" and "/../" in a URL string as literal characters, not as shorthand for navigation. See Remarks for further discussion.
		/// </para>
		/// <para>URL_NO_META (0x08000000)</para>
		/// <para>Defined to be the same as <c>URL_DONT_SIMPLIFY</c>.</para>
		/// <para>URL_ESCAPE_PERCENT (0x00001000)</para>
		/// <para>Convert any occurrence of "%" to its escape sequence.</para>
		/// <para>URL_ESCAPE_AS_UTF8 (0x00040000)</para>
		/// <para><c>Windows 7 and later</c>. Percent-encode all non-ASCII characters as their UTF-8 equivalents.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function performs such tasks as replacing unsafe characters with their escape sequences and collapsing sequences like ".....".
		/// </para>
		/// <para>
		/// If a URL string contains "/../" or "/./", <c>UrlCanonicalize</c> treats the characters as indicating navigation in the URL
		/// hierarchy. The function simplifies the URLs before combining them. For instance "/hello/cruel/../world" is simplified to
		/// "/hello/world". Exceptions to this default behavior occur in these cases:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the <c>URL_DONT_SIMPLIFY</c> flag is set in dwFlags, the function does not simplify URLs. In this case,
		/// "/hello/cruel/../world" is left as it is.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If "/../" or "/./" is the first segment in the path (for example, "http://domain/../path1/path2/file.htm"),
		/// <c>UrlCanonicalize</c> outputs the path exactly as it was input.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-urlcanonicalizea LWSTDAPI UrlCanonicalizeA( PCSTR pszUrl,
		// PSTR pszCanonicalized, DWORD *pcchCanonicalized, DWORD dwFlags );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "70802745-0611-4d37-800e-b50d5ea23426")]
		public static extern HRESULT UrlCanonicalize(string pszUrl, StringBuilder pszCanonicalized, ref uint pcchCanonicalized, URLFLAGS dwFlags);

		/// <summary>
		/// <para>When provided with a relative URL and its base, returns a URL in canonical form.</para>
		/// </summary>
		/// <param name="pszBase">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length INTERNET_MAX_URL_LENGTH that contains the base URL.</para>
		/// </param>
		/// <param name="pszRelative">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length INTERNET_MAX_URL_LENGTH that contains the relative URL.</para>
		/// </param>
		/// <param name="pszCombined">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// A pointer to a buffer that, when this function returns successfully, receives a null-terminated string that contains the combined URL.
		/// </para>
		/// </param>
		/// <param name="pcchCombined">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to a value that, on entry, is set to the number of characters in the pszCombined buffer. When the function returns
		/// successfully, the value depends on whether the function is successful or returns E_POINTER. For other return values, the value of
		/// this parameter is meaningless.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Flags that specify how the URL is converted to canonical form. The following flags can be combined.</para>
		/// <para>URL_DONT_SIMPLIFY (0x08000000)</para>
		/// <para>
		/// Treat '/./' and '/../' in a URL string as literal characters, not as shorthand for navigation. See Remarks for further discussion.
		/// </para>
		/// <para>URL_ESCAPE_PERCENT (0x00001000)</para>
		/// <para>Convert any occurrence of '%' to its escape sequence.</para>
		/// <para>URL_ESCAPE_SPACES_ONLY (0x04000000)</para>
		/// <para>
		/// Replace only spaces with escape sequences. This flag takes precedence over <c>URL_ESCAPE_UNSAFE</c>, but does not apply to opaque URLs.
		/// </para>
		/// <para>URL_ESCAPE_UNSAFE (0x20000000)</para>
		/// <para>
		/// Replace unsafe characters with their escape sequences. Unsafe characters are those characters that may be altered during
		/// transport across the Internet, and include the (&lt;, &gt;, ", #, {, }, |, , ^, ~, [, ], and ') characters. This flag applies to
		/// all URLs, including opaque URLs.
		/// </para>
		/// <para>URL_NO_META</para>
		/// <para>Defined to be the same as <c>URL_DONT_SIMPLIFY</c>.</para>
		/// <para>URL_PLUGGABLE_PROTOCOL (0x40000000)</para>
		/// <para>
		/// Combine URLs with client-defined pluggable protocols, according to the W3C specification. This flag does not apply to standard
		/// protocols such as ftp, http, gopher, and so on. If this flag is set, <c>UrlCombine</c> does not simplify URLs, so there is no
		/// need to also set <c>URL_DONT_SIMPLIFY</c>.
		/// </para>
		/// <para>URL_UNESCAPE (0x10000000)</para>
		/// <para>
		/// Un-escape any escape sequences that the URLs contain, with two exceptions. The escape sequences for '?' and '#' are not
		/// un-escaped. If one of the URL_ESCAPE_XXX flags is also set, the two URLs are first un-escaped, then combined, then escaped.
		/// </para>
		/// <para>URL_ESCAPE_AS_UTF8 (0x00040000)</para>
		/// <para><c>Windows 7 and later</c>. Percent-encode all non-ASCII characters as their UTF-8 equivalents.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns standard COM error codes, including the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>
		/// pszCombined points to a string that contains the combined URLs. The value of pcchCombined is set to the number of characters in
		/// the string, not counting the terminating NULL character.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>
		/// The buffer was too small. The value of pcchCombined is set to the minimum number of characters that the buffer must be able to
		/// contain, including the terminating NULL character.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Items between slashes are treated as hierarchical identifiers; the last item specifies the document itself. You must enter a
		/// slash (/) after the document name to append more items; otherwise, <c>UrlCombine</c> exchanges one document for another. For example:
		/// </para>
		/// <para>
		/// The preceding code returns the URL http://xyz/test/bar. If you want the combined URL to be http://xyz/test/abc/bar, use the
		/// following call to <c>UrlCombine</c>.
		/// </para>
		/// <para>
		/// If a URL string contains '/../' or '/./', <c>UrlCombine</c> usually treats the characters as if they indicated navigation in the
		/// URL hierarchy. The function simplifies the URLs before combining them. For instance, "/hello/cruel/../world" is simplified to
		/// "/hello/world". If the <c>URL_DONT_SIMPLIFY</c> flag is set in dwFlags, the function does not simplify URLs. In this case,
		/// "/hello/cruel/../world" is left as it is.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-urlcombinea LWSTDAPI UrlCombineA( PCSTR pszBase, PCSTR
		// pszRelative, PSTR pszCombined, DWORD *pcchCombined, DWORD dwFlags );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "f574d365-1ab9-4de4-84fe-17820c327ccf")]
		public static extern HRESULT UrlCombine(string pszBase, string pszRelative, StringBuilder pszCombined, ref uint pcchCombined, URLFLAGS dwFlags);

		/// <summary>
		/// <para>Makes a case-sensitive comparison of two URL strings.</para>
		/// </summary>
		/// <param name="psz1">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>A null-terminated string of maximum length INTERNET_MAX_URL_LENGTH that contains the first URL.</para>
		/// </param>
		/// <param name="psz2">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>A null-terminated string of maximum length INTERNET_MAX_URL_LENGTH that contains the second URL.</para>
		/// </param>
		/// <param name="fIgnoreSlash">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A value that is set to <c>TRUE</c> to have <c>UrlCompare</c> ignore a trailing '/' character on either or both URLs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Returns zero if the two strings are equal. The function will also return zero if fIgnoreSlash is set to <c>TRUE</c> and one of
		/// the strings has a trailing '' character. The function returns a negative integer if the string pointed to by psz1 is less than
		/// the string pointed to by psz2. Otherwise, it returns a positive integer.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For best results, you should first canonicalize the URLs with UrlCanonicalize. Then, compare the canonicalized URLs with <c>UrlCompare</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-urlcomparea int UrlCompareA( PCSTR psz1, PCSTR psz2, BOOL
		// fIgnoreSlash );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "d5c9e003-b85b-4f9f-b231-e3e4b71d4ce6")]
		public static extern int UrlCompare(string psz1, string psz2, [MarshalAs(UnmanagedType.Bool)] bool fIgnoreSlash);

		/// <summary>
		/// <para>Converts a Microsoft MS-DOS path to a canonicalized URL.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>A null-terminated string of maximum length INTERNET_MAX_URL_LENGTH that contains the MS-DOS path.</para>
		/// </param>
		/// <param name="pszUrl">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>A pointer to a buffer that, when this function returns successfully, receives the URL.</para>
		/// </param>
		/// <param name="pcchUrl">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The number of characters in pszUrl.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Reserved. Set this parameter to <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_FALSE if pszPath is already in URL format. In this case, pszPath will simply be copied to pszUrl. Otherwise, it returns
		/// S_OK if successful or a standard COM error value if not.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Note</c><c>UrlCreateFromPath</c> does not support extended paths. These are paths that include the extended-length path prefix "\\?\".
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-urlcreatefrompatha LWSTDAPI UrlCreateFromPathA( PCSTR
		// pszPath, PSTR pszUrl, DWORD *pcchUrl, DWORD dwFlags );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "b69ab203-daab-4951-b3b9-c5ca37c532b3")]
		public static extern HRESULT UrlCreateFromPath(string pszPath, StringBuilder pszUrl, ref uint pcchUrl, uint dwFlags = 0);

		/// <summary>
		/// <para>
		/// Converts characters or surrogate pairs in a URL that might be altered during transport across the Internet ("unsafe" characters)
		/// into their corresponding escape sequences. Surrogate pairs are characters between U+10000 to U+10FFFF (in UTF-32) or between DC00
		/// to DFFF (in UTF-16).
		/// </para>
		/// </summary>
		/// <param name="pszUrl">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>
		/// A null-terminated string of maximum length <c>INTERNET_MAX_URL_LENGTH</c> that contains a full or partial URL, as appropriate for
		/// the value in dwFlags.
		/// </para>
		/// </param>
		/// <param name="pszEscaped">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>The buffer that receives the converted string, with the unsafe characters converted to their escape sequences.</para>
		/// </param>
		/// <param name="pcchEscaped">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to a <c>DWORD</c> value that, on entry, contains the number of characters in the pszEscaped buffer. Before calling
		/// <c>UrlEscape</c>, the calling application must set the value referenced by pcchEscaped to the size of the buffer. When this
		/// function returns successfully, the value receives the number of characters written to the buffer, not including the terminating
		/// <c>NULL</c> character.
		/// </para>
		/// <para>
		/// If an E_POINTER error code is returned, the buffer was too small to hold the result, and the value referenced by pcchEscaped is
		/// set to the required number of characters in the buffer. If any other errors are returned, the value referenced by pcchEscaped is undefined.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The flags that indicate which portion of the URL is being provided in pszURL and which characters in that string should be
		/// converted to their escape sequences. The following flags are defined.
		/// </para>
		/// <para>URL_DONT_ESCAPE_EXTRA_INFO (0x02000000)</para>
		/// <para>
		/// Used only in conjunction with <c>URL_ESCAPE_SPACES_ONLY</c> to prevent the conversion of characters in the query (the portion of
		/// the URL following the first # or ? character encountered in the string). This flag should not be used alone, nor combined with <c>URL_ESCAPE_SEGMENT_ONLY</c>.
		/// </para>
		/// <para>URL_BROWSER_MODE</para>
		/// <para>Defined to be the same as <c>URL_DONT_ESCAPE_EXTRA_INFO</c>.</para>
		/// <para>URL_ESCAPE_SPACES_ONLY (0x04000000)</para>
		/// <para>
		/// Convert only space characters to their escape sequences, including those space characters in the query portion of the URL. Other
		/// unsafe characters are not converted to their escape sequences. This flag assumes that pszURL does not contain a full URL. It
		/// expects only the portions following the server specification.
		/// </para>
		/// <para>
		/// Combine this flag with <c>URL_DONT_ESCAPE_EXTRA_INFO</c> to prevent the conversion of space characters in the query portion of
		/// the URL.
		/// </para>
		/// <para>This flag cannot be combined with <c>URL_ESCAPE_PERCENT</c> or <c>URL_ESCAPE_SEGMENT_ONLY</c>.</para>
		/// <para>URL_ESCAPE_PERCENT (0x00001000)</para>
		/// <para>
		/// Convert any % character found in the segment section of the URL (that section falling between the server specification and the
		/// first # or ? character). By default, the % character is not converted to its escape sequence. Other unsafe characters in the
		/// segment are also converted normally.
		/// </para>
		/// <para>
		/// Combining this flag with <c>URL_ESCAPE_SEGMENT_ONLY</c> includes those % characters in the query portion of the URL. However, as
		/// the <c>URL_ESCAPE_SEGMENT_ONLY</c> flag causes the entire string to be considered the segment, any # or ? characters are also converted.
		/// </para>
		/// <para>This flag cannot be combined with <c>URL_ESCAPE_SPACES_ONLY</c>.</para>
		/// <para>URL_ESCAPE_SEGMENT_ONLY (0x00002000)</para>
		/// <para>
		/// Indicates that pszURL contains only that section of the URL following the server component but preceding the query. All unsafe
		/// characters in the string are converted. If a full URL is provided when this flag is set, all unsafe characters in the entire
		/// string are converted, including # and ? characters.
		/// </para>
		/// <para>Combine this flag with <c>URL_ESCAPE_PERCENT</c> to include that character in the conversion.</para>
		/// <para>This flag cannot be combined with <c>URL_ESCAPE_SPACES_ONLY</c> or <c>URL_DONT_ESCAPE_EXTRA_INFO</c>.</para>
		/// <para>URL_ESCAPE_AS_UTF8 (0x00040000)</para>
		/// <para><c>Windows 7 and later</c>. Percent-encode all non-ASCII characters as their UTF-8 equivalents.</para>
		/// <para>URL_ESCAPE_ASCII_URI_COMPONENT (0x00080000)</para>
		/// <para><c>Windows 8 and later</c>. Percent-encode all ASCII characters outside of the unreserved set from URI RFC 3986 (a-zA-Z0-9-.~_).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK if successful. If the pcchEscaped buffer was too small to contain the result, E_POINTER is returned, and the value
		/// pointed to by pcchEscaped is set to the required buffer size. Otherwise, a standard error value is returned.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For the purposes of this document, a typical URL is divided into three sections: the server, the segment, and the query. For example:
		/// </para>
		/// <para>The server portion is "http://microsoft.com/". The trailing forward slash is considered part of the server portion.</para>
		/// <para>
		/// The segment portion is any part of the path found following the server portion, but before the first # or ? character, in this
		/// case simply "test.asp".
		/// </para>
		/// <para>
		/// The query portion is the remainder of the path from the first # or ? character (inclusive) to the end. In the example, it is "?url=/example/abc.asp?frame=true#fragment".
		/// </para>
		/// <para>
		/// Unsafe characters are those characters that might be altered during transport across the Internet. This function converts unsafe
		/// characters into their equivalent "%xy" escape sequences. The following table shows unsafe characters and their escape sequences.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Character</term>
		/// <term>Escape Sequence</term>
		/// </listheader>
		/// <item>
		/// <term>^</term>
		/// <term>%5E</term>
		/// </item>
		/// <item>
		/// <term>&amp;</term>
		/// <term>%26</term>
		/// </item>
		/// <item>
		/// <term>`</term>
		/// <term>%60</term>
		/// </item>
		/// <item>
		/// <term>{</term>
		/// <term>%7B</term>
		/// </item>
		/// <item>
		/// <term>}</term>
		/// <term>%7D</term>
		/// </item>
		/// <item>
		/// <term>|</term>
		/// <term>%7C</term>
		/// </item>
		/// <item>
		/// <term>]</term>
		/// <term>%5D</term>
		/// </item>
		/// <item>
		/// <term>[</term>
		/// <term>%5B</term>
		/// </item>
		/// <item>
		/// <term>"</term>
		/// <term>%22</term>
		/// </item>
		/// <item>
		/// <term>&lt;</term>
		/// <term>%3C</term>
		/// </item>
		/// <item>
		/// <term>&gt;</term>
		/// <term>%3E</term>
		/// </item>
		/// <item>
		/// <term>\</term>
		/// <term>%5C</term>
		/// </item>
		/// </list>
		/// <para>Use of the <c>URL_ESCAPE_SEGMENT_ONLY</c> flag also causes the conversion of the # (%23), ? (%3F), and / (%2F) characters.</para>
		/// <para>
		/// By default, <c>UrlEscape</c> ignores any text following a # or ? character. The <c>URL_ESCAPE_SEGMENT_ONLY</c> flag overrides
		/// this behavior by regarding the entire string as the segment. The <c>URL_ESCAPE_SPACES_ONLY</c> flag overrides this behavior, but
		/// only for space characters.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following examples show the effect of the various flags on a URL. The example URL is not valid but is exaggerated for
		/// demonstration purposes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-urlescapea LWSTDAPI UrlEscapeA( PCSTR pszUrl, PSTR
		// pszEscaped, DWORD *pcchEscaped, DWORD dwFlags );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "52ee1501-2cd4-4193-8363-0af91673ec88")]
		public static extern HRESULT UrlEscape(string pszUrl, StringBuilder pszEscaped, ref uint pcchEscaped, URLFLAGS dwFlags);

		/// <summary>
		/// <para>
		/// [ <c>UrlFixupW</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
		/// unavailable in subsequent versions.]
		/// </para>
		/// <para>Attempts to correct a URL whose protocol identifier is incorrect. For example, will be changed to .</para>
		/// </summary>
		/// <param name="pcszUrl">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>
		/// A pointer to a <c>null</c>-terminated string that contains the URL to be corrected. This string must not exceed
		/// INTERNET_MAX_PATH_LENGTH characters in length, including the terminating <c>NULL</c> character.
		/// </para>
		/// </param>
		/// <param name="pszTranslatedUrl">
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>
		/// A pointer to a buffer that, when this function returns successfully, receives the copied characters. The buffer must be large
		/// enough to contain the number of WCHAR characters specified by the cchMax parameter, including the terminating <c>NULL</c>
		/// character. This parameter can be equal to the pcszUrl parameter to correct a URL in place. If pszTranslatedUrl is not equal to
		/// pcszUrl, the buffer pointed to by pszTranslatedUrl must not overlap the buffer pointed to by pcszUrl.
		/// </para>
		/// </param>
		/// <param name="cchMax">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The number of <c>WCHAR</c> characters that can be contained in the buffer pointed to by pszTranslatedUrl. This parameter must be
		/// greater than zero.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK if the proposed URL was already acceptable or was successfully corrected. The pszTranslatedUrl buffer contains the
		/// corrected URL, or the original URL if no correction was needed. Returns S_FALSE if the proposed URL could not be recognized
		/// sufficiently to be corrected. Otherwise, returns a standard COM error code.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The UrlFixup function recognizes the schemes specified by the URL_SCHEME enumeration.</para>
		/// <para>Priority is given to the first character in the protocol identifier section so will be converted to instead of .</para>
		/// <para>
		/// <c>Note</c> Do not use this function for deterministic data transformation. The heuristics used by <c>UrlFixupW</c> can change
		/// from one release to the next. The function should only be used to correct possibly invalid user input.
		/// </para>
		/// <para>This function is available only in a Unicode version.</para>
		/// <para>Examples</para>
		/// <para>
		/// This example shows how to use <c>UrlFixupW</c>. Notice that the last four autocorrections were probably not what the user
		/// intended and demonstrate limitations of the heuristic used by the function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-urlfixupw LWSTDAPI UrlFixupW( PCWSTR pcszUrl, PWSTR
		// pszTranslatedUrl, DWORD cchMax );
		[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("shlwapi.h", MSDNShortId = "3750d027-847f-4f33-851d-a10be7562bcb")]
		public static extern HRESULT UrlFixupW(string pcszUrl, StringBuilder pszTranslatedUrl, uint cchMax);

		/// <summary>
		/// <para>Retrieves the location from a URL.</para>
		/// </summary>
		/// <param name="pszURL">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>A null-terminated string of maximum length INTERNET_MAX_URL_LENGTH that contains the location.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>Returns a pointer to a null-terminated string with the location, or <c>NULL</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The location is the segment of the URL starting with a ? or # character. If a file URL has a query string, the returned string
		/// includes the query string.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-urlgetlocationa LPCSTR UrlGetLocationA( PCSTR pszURL );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "e75bde92-2ca0-4d34-a276-50b4eeceda1c")]
		public static extern IntPtr UrlGetLocation(string pszURL);

		/// <summary>
		/// <para>Accepts a URL string and returns a specified part of that URL.</para>
		/// </summary>
		/// <param name="pszIn">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>A null-terminated string of maximum length INTERNET_MAX_URL_LENGTH that contains the URL.</para>
		/// </param>
		/// <param name="pszOut">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// A pointer to a buffer that, when this function returns successfully, receives a null-terminated string with the specified part of
		/// the URL.
		/// </para>
		/// </param>
		/// <param name="pcchOut">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to a value that, on entry, is set to the number of characters in the pszOut buffer. When this function returns
		/// successfully, the value depends on whether the function is successful or returns E_POINTER. For other return values, the value of
		/// this parameter is meaningless.
		/// </para>
		/// </param>
		/// <param name="dwPart">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The flags that specify which part of the URL to retrieve. It can have one of the following values.</para>
		/// <para>URL_PART_HOSTNAME</para>
		/// <para>The host name.</para>
		/// <para>URL_PART_PASSWORD</para>
		/// <para>The password.</para>
		/// <para>URL_PART_PORT</para>
		/// <para>The port number.</para>
		/// <para>URL_PART_QUERY</para>
		/// <para>The query portion of the URL.</para>
		/// <para>URL_PART_SCHEME</para>
		/// <para>The URL scheme.</para>
		/// <para>URL_PART_USERNAME</para>
		/// <para>The username.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A flag that can be set to keep the URL scheme, in addition to the part that is specified by dwPart.</para>
		/// <para>URL_PARTFLAG_KEEPSCHEME (0x01)</para>
		/// <para>Keep the URL scheme.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK if successful. The value pointed to by pcchOut will be set to the number of characters written to the output buffer,
		/// excluding the terminating <c>NULL</c>. If the buffer was too small, E_POINTER is returned, and the value pointed to by pcchOut
		/// will be set to the minimum number of characters that the buffer must be able to contain, including the terminating <c>NULL</c>
		/// character. Otherwise, a COM error value is returned.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-urlgetparta LWSTDAPI UrlGetPartA( PCSTR pszIn, PSTR
		// pszOut, DWORD *pcchOut, DWORD dwPart, DWORD dwFlags );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "5f43dedd-c543-46b2-b90e-f0af576d2605")]
		public static extern HRESULT UrlGetPart(string pszIn, StringBuilder pszOut, ref uint pcchOut, uint dwPart, uint dwFlags);

		/// <summary>
		/// <para>Hashes a URL string.</para>
		/// </summary>
		/// <param name="pszUrl">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>A null-terminated string of maximum length INTERNET_MAX_URL_LENGTH that contains the URL.</para>
		/// </param>
		/// <param name="pbHash">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointere to a buffer that, when this function returns successfully, receives the hashed array.</para>
		/// </param>
		/// <param name="cbHash">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of elements in the array at pbHash. It should be no larger than 256.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To hash a URL into a single byte, set cbHash = sizeof(BYTE) and pbHash = (LPBYTE)&amp;bHashedValue, where bHashedValue is a
		/// one-byte buffer. To hash a URL into a <c>DWORD</c>, set cbHash = sizeof(DWORD) and pbHash = (LPBYTE)&amp;dwHashedValue, where
		/// dwHashedValue is a <c>DWORD</c> buffer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-urlhasha LWSTDAPI UrlHashA( PCSTR pszUrl, BYTE *pbHash,
		// DWORD cbHash );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "9c0ce709-e097-4501-bee1-b24df9d4828d")]
		public static extern HRESULT UrlHash(string pszUrl, IntPtr pbHash, uint cbHash);

		/// <summary>
		/// <para>Tests whether a URL is a specified type.</para>
		/// </summary>
		/// <param name="pszUrl">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>A null-terminated string of maximum length INTERNET_MAX_URL_LENGTH that contains the URL.</para>
		/// </param>
		/// <param name="UrlIs">
		/// <para>Type: <c>URLIS</c></para>
		/// <para>The type of URL to be tested for. This parameter can take one of the following values.</para>
		/// <para>URLIS_APPLIABLE</para>
		/// <para>Attempt to determine a valid scheme for the URL.</para>
		/// <para>URLIS_DIRECTORY</para>
		/// <para>Does the URL string end with a directory?</para>
		/// <para>URLIS_FILEURL</para>
		/// <para>Is the URL a file URL?</para>
		/// <para>URLIS_HASQUERY</para>
		/// <para>Does the URL have an appended query string?</para>
		/// <para>URLIS_NOHISTORY</para>
		/// <para>Is the URL a URL that is not typically tracked in navigation history?</para>
		/// <para>URLIS_OPAQUE</para>
		/// <para>Is the URL opaque?</para>
		/// <para>URLIS_URL</para>
		/// <para>Is the URL valid?</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// For all but one of the URL types, <c>UrlIs</c> returns <c>TRUE</c> if the URL is the specified type, or <c>FALSE</c> if not.
		/// </para>
		/// <para>
		/// If UrlIs is set to <c>URLIS_APPLIABLE</c>, <c>UrlIs</c> will attempt to determine the URL scheme. If the function is able to
		/// determine a scheme, it returns <c>TRUE</c>, or <c>FALSE</c> otherwise.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-urlisa BOOL UrlIsA( PCSTR pszUrl, URLIS UrlIs );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "2e83c953-b4c5-4411-90ca-49ffb94ee374")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UrlIs(string pszUrl, URLIS UrlIs);

		/// <summary>
		/// <para>Returns whether a URL is a URL that browsers typically do not include in navigation history.</para>
		/// </summary>
		/// <param name="pszURL">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>A null-terminated string of maximum length INTERNET_MAX_URL_LENGTH that contains the URL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns a nonzero value if the URL is a URL that is not included in navigation history, or zero otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function is equivalent to the following:</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-urlisnohistorya BOOL UrlIsNoHistoryA( PCSTR pszURL );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "7602d2ef-1f21-4b2f-8ac9-195bb21d6ae7")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UrlIsNoHistory(string pszURL);

		/// <summary>
		/// <para>Returns whether a URL is opaque.</para>
		/// </summary>
		/// <param name="pszURL">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>A null-terminated string of maximum length INTERNET_MAX_URL_LENGTH that contains the URL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns a nonzero value if the URL is opaque, or zero otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A URL that has a scheme that is not followed by two slashes (//) is opaque. For example, xyz@litwareinc.com is an opaque URL.
		/// Opaque URLs cannot be separated into the standard URL hierarchy. <c>UrlIsOpaque</c> is equivalent to the following:
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-urlisopaquea BOOL UrlIsOpaqueA( PCSTR pszURL );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "460f4d41-2796-496d-9199-f2d1cd6e4a24")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UrlIsOpaque(string pszURL);

		/// <summary>
		/// <para>Converts escape sequences back into ordinary characters.</para>
		/// </summary>
		/// <param name="pszUrl">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string with the URL. If dwFlags is set to <c>URL_UNESCAPE_INPLACE</c>, the converted string is
		/// returned through this parameter.
		/// </para>
		/// </param>
		/// <param name="pszUnescaped">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// A pointer to a buffer that will receive a null-terminated string that contains the unescaped version of pszURL. If
		/// <c>URL_UNESCAPE_INPLACE</c> is set in dwFlags, this parameter is ignored.
		/// </para>
		/// </param>
		/// <param name="pcchUnescaped">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// The number of characters in the buffer pointed to by pszUnescaped. On entry, the value pcchUnescaped points to is set to the size
		/// of the buffer. If the function returns a success code, the value that pcchUnescaped points to is set to the number of characters
		/// written to that buffer, not counting the terminating <c>NULL</c> character. If an E_POINTER error code is returned, the buffer
		/// was too small, and the value to which pcchUnescaped points is set to the required number of characters that the buffer must be
		/// able to contain. If any other errors are returned, the value to which pcchUnescaped points is undefined.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Flags that control which characters are unescaped. It can be a combination of the following flags.</para>
		/// <para>URL_DONT_UNESCAPE_EXTRA_INFO</para>
		/// <para>Do not convert the # or ? character, or any characters following them in the string.</para>
		/// <para>URL_UNESCAPE_AS_UTF8</para>
		/// <para><c>Introduced in Windows 8</c>. Decode URLs that were encoded by using the <c>URL_ESCAPE_AS_UTF8</c> flag.</para>
		/// <para>URL_UNESCAPE_INPLACE</para>
		/// <para>Use pszURL to return the converted string instead of pszUnescaped.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK if successful. If the <c>URL_UNESCAPE_INPLACE</c> flag is not set, the value pointed to by pcchUnescaped will be set
		/// to the number of characters in the output buffer pointed to by pszUnescaped. Returns E_POINTER if the <c>URL_UNESCAPE_INPLACE</c>
		/// flag is not set and the output buffer is too small. The pcchUnescaped parameter will be set to the required buffer size.
		/// Otherwise, returns a standard error value.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>An escape sequence has the form "%xy".</para>
		/// <para>Input strings cannot be longer than INTERNET_MAX_URL_LENGTH.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-urlunescapea LWSTDAPI UrlUnescapeA( PSTR pszUrl, PSTR
		// pszUnescaped, DWORD *pcchUnescaped, DWORD dwFlags );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "5bff5161-3b57-4f12-b126-42eac3f60267")]
		public static extern HRESULT UrlUnescape(StringBuilder pszUrl, StringBuilder pszUnescaped, ref uint pcchUnescaped, URLFLAGS dwFlags);

		/// <summary>
		/// <para>Used by the ParseURL function to return the parsed URL.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/ns-shlwapi-tagparsedurla typedef struct tagPARSEDURLA { DWORD cbSize;
		// LPCSTR pszProtocol; UINT cchProtocol; LPCSTR pszSuffix; UINT cchSuffix; UINT nScheme; } PARSEDURLA, *PPARSEDURLA;
		[PInvokeData("shlwapi.h", MSDNShortId = "9092dd7a-ff5b-465f-a808-ef4e0067f540")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct PARSEDURL
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// [in] The size of the structure, in bytes. The calling application must set this member before calling the ParseURL function.
			/// </para>
			/// </summary>
			public uint cbSize;

			/// <summary>
			/// <para>Type: <c>LPCTSTR</c></para>
			/// <para>[out] A pointer to the beginning of the protocol part of the URL.</para>
			/// </summary>
			public string pszProtocol;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of characters in the URL's protocol section.</para>
			/// </summary>
			public uint cchProtocol;

			/// <summary>
			/// <para>Type: <c>LPCTSTR</c></para>
			/// <para>
			/// [out] A pointer to the section of the URL that follows the protocol and colon (':'). For file URLs, the function also skips
			/// the leading "//" characters.
			/// </para>
			/// </summary>
			public string pszSuffix;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>[out] The number of characters in the URL's suffix.</para>
			/// </summary>
			public uint cchSuffix;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>[out] A value from the URL_SCHEME enumeration that specifies the URL's scheme.</para>
			/// </summary>
			public URL_SCHEME nScheme;
		}
	}
}