using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class ShlwApi
	{
		/// <summary>Flags used by <see cref="PathMatchSpecEx"/>.</summary>
		[PInvokeData("shlwapi.h", MSDNShortId = "bd9bf950-e349-4b67-8608-7acad84c0907")]
		[Flags]
		public enum PMSF
		{
			/// <summary>The pszSpec parameter points to a single file name pattern to be matched.</summary>
			PMSF_NORMAL = 0x00000000,

			/// <summary>The pszSpec parameter points to a semicolon-delimited list of file name patterns to be matched.</summary>
			PMSF_MULTIPLE = 0x00000001,

			/// <summary>
			/// If <c>PMSF_NORMAL</c> is used, ignore leading spaces in the string pointed to by pszSpec. If <c>PMSF_MULTIPLE</c> is used,
			/// ignore leading spaces in each file type contained in the string pointed to by pszSpec. This flag can be combined with
			/// <c>PMSF_NORMAL</c> and <c>PMSF_MULTIPLE</c>.
			/// </summary>
			PMSF_DONT_STRIP_SPACES = 0x00010000,
		}

		/// <summary>
		/// <para>
		/// Adds a backslash to the end of a string to create the correct syntax for a path. If the source path already has a trailing
		/// backslash, no backslash will be added.
		/// </para>
		/// <para>
		/// <c>Note</c> Misuse of this function can lead to a buffer overrun. We recommend the use of the safer PathCchAddBackslash or
		/// PathCchAddBackslashEx function in its place.
		/// </para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer that, when this function returns successfully, points to the new string's terminating null character. If the backslash
		/// could not be appended due to inadequate buffer size, this value is <c>NULL</c>.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathaddbackslasha LPSTR PathAddBackslashA( LPSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "27d8aec7-8b00-412a-9a42-8ce27e262781")]
		public static extern IntPtr PathAddBackslash(StringBuilder pszPath);

		/// <summary>
		/// <para>Adds a file name extension to a path string.</para>
		/// <para>
		/// <c>Note</c> Misuse of this function can lead to a buffer overrun. We recommend the use of the safer PathCchAddExtension function
		/// in its place.
		/// </para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a buffer with the null-terminated string to which the file name extension will be appended. You must set the size of
		/// this buffer to MAX_PATH to ensure that it is large enough to hold the returned string.
		/// </para>
		/// </param>
		/// <param name="pszExt">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if an extension was added, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If there is already a file name extension present, no extension will be added. If the pszPath points to a <c>NULL</c> string, the
		/// result will be the file name extension only. If pszExtension points to a <c>NULL</c> string, an ".exe" extension will be added.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathaddextensiona BOOL PathAddExtensionA( LPSTR pszPath,
		// LPCSTR pszExt );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "2c113d11-11d5-4362-bad5-c859d65aca2a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathAddExtension(StringBuilder pszPath, string pszExt);

		/// <summary>
		/// <para>Appends one path to the end of another.</para>
		/// <para>
		/// <c>Note</c> Misuse of this function can lead to a buffer overrun. We recommend the use of the safer PathCchAppend or
		/// PathCchAppendEx function in its place.
		/// </para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string to which the path specified in pszMore is appended. You must set the size of this buffer to
		/// MAX_PATH to ensure that it is large enough to hold the returned string.
		/// </para>
		/// </param>
		/// <param name="pszMore">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the path to be appended.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function automatically inserts a backslash between the two strings, if one is not already present.</para>
		/// <para>
		/// The path supplied in pszPath cannot begin with "..\" or ".\" to produce a relative path string. If present, those periods are
		/// stripped from the output string. For example, appending "path3" to "..\path1\path2" results in an output of "\path1\path2\path3"
		/// rather than "..\path1\path2\path3".
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathappenda BOOL PathAppendA( LPSTR pszPath, LPCSTR
		// pszMore );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "896737ef-a05c-4f0f-b8b0-56355ae9c2d9")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathAppend(StringBuilder pszPath, string pszMore);

		/// <summary>
		/// <para>Creates a root path from a given drive number.</para>
		/// </summary>
		/// <param name="pszRoot">
		/// <para>TBD</para>
		/// </param>
		/// <param name="iDrive">
		/// <para>Type: <c>int</c></para>
		/// <para>A variable of type <c>int</c> that indicates the desired drive number. It should be between 0 and 25.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// Returns the address of the constructed root path. If the call fails for any reason (for example, an invalid drive number), szRoot
		/// is returned unchanged.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathbuildroota LPSTR PathBuildRootA( LPSTR pszRoot, int
		// iDrive );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "0a6895bd-54cf-499c-9057-f2d721bce5d9")]
		public static extern IntPtr PathBuildRoot(StringBuilder pszRoot, int iDrive);

		/// <summary>
		/// <para>Simplifies a path by removing navigation elements such as "." and ".." to produce a direct, well-formed path.</para>
		/// <para>
		/// <c>Note</c> Misuse of this function can lead to a buffer overrun. We recommend the use of the safer PathCchCanonicalize or
		/// PathCchCanonicalizeEx function in its place.
		/// </para>
		/// </summary>
		/// <param name="pszBuf">
		/// <para>TBD</para>
		/// </param>
		/// <param name="pszPath">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Returns <c>TRUE</c> if a result has been computed and the content of the lpszDst output buffer is valid. Returns <c>FALSE</c>
		/// otherwise, and the contents of the buffer pointed to by lpszDst are invalid. To get extended error information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function allows the user to specify what to remove from a path by inserting special character sequences into the path. The
		/// ".." sequence indicates to remove a path segment from the current position to the previous path segment. The "." sequence
		/// indicates to skip over the next path segment to the following path segment. The root segment of the path cannot be removed.
		/// </para>
		/// <para>
		/// If there are more ".." sequences than there are path segments, the function returns <c>TRUE</c> and contents of the buffer
		/// pointed to by lpszDst contains just the root, "".
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathcanonicalizea BOOL PathCanonicalizeA( LPSTR pszBuf,
		// LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "e9b1e877-2cd6-4dd9-a15b-676cb940daed")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathCanonicalize(StringBuilder pszBuf, string pszPath);

		/// <summary>
		/// <para>Concatenates two strings that represent properly formed paths into one path; also concatenates any relative path elements.</para>
		/// <para>
		/// <c>Note</c> Misuse of this function can lead to a buffer overrun. We recommend the use of the safer PathCchCombine or
		/// PathCchCombineEx function in its place.
		/// </para>
		/// </summary>
		/// <param name="pszDest">
		/// <para>TBD</para>
		/// </param>
		/// <param name="pszDir">
		/// <para>TBD</para>
		/// </param>
		/// <param name="pszFile">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a buffer that, when this function returns successfully, receives the concatenated path string. This is the same
		/// string pointed to by pszPathOut. If this function does not return successfully, this value is <c>NULL</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The directory path should be in the form of A:,B:, ..., Z:. The file path should be in a correct form that represents the file
		/// name part of the path. If the directory path ends with a backslash, the backslash will be maintained. Note that while lpszDir and
		/// lpszFile are both optional parameters, they cannot both be <c>NULL</c>.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathcombinea LPSTR PathCombineA( LPSTR pszDest, LPCSTR
		// pszDir, LPCSTR pszFile );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "ed03334b-f688-4993-9685-092135ca29c9")]
		public static extern IntPtr PathCombine(StringBuilder pszDest, string pszDir, string pszFile);

		/// <summary>
		/// <para>Compares two paths to determine if they share a common prefix. A prefix is one of these types: "C:\", ".", "..", "..\".</para>
		/// </summary>
		/// <param name="pszFile1">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of length MAX_PATH that contains the first path name.</para>
		/// </param>
		/// <param name="pszFile2">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of length MAX_PATH that contains the second path name.</para>
		/// </param>
		/// <param name="achPath">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Returns the count of common prefix characters in the path. If the output buffer pointer is not <c>NULL</c>, then these characters
		/// are copied to the output buffer.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathcommonprefixa int PathCommonPrefixA( LPCSTR pszFile1,
		// LPCSTR pszFile2, LPSTR achPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "13c32b32-8541-41c4-82d8-48d3b2439f0c")]
		public static extern int PathCommonPrefix(string pszFile1, string pszFile2, StringBuilder achPath);

		/// <summary>
		/// <para>Truncates a file path to fit within a given pixel width by replacing path components with ellipses.</para>
		/// </summary>
		/// <param name="hDC">
		/// <para>Type: <c>HDC</c></para>
		/// <para>A handle to the device context used for font metrics. This value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="pszPath">
		/// <para>TBD</para>
		/// </param>
		/// <param name="dx">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width, in pixels, in which the string must fit.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Returns <c>TRUE</c> if the path was successfully compacted to the specified width. Returns <c>FALSE</c> on failure, or if the
		/// base portion of the path would not fit the specified width.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function uses the font currently selected in hDC to calculate the width of the text. This function will not compact the path
		/// beyond the base file name preceded by ellipses.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathcompactpatha BOOL PathCompactPathA( HDC hDC, LPSTR
		// pszPath, UINT dx );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "b8184c98-1f86-4714-baf8-af4ef3e71cf2")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathCompactPath(IntPtr hDC, StringBuilder pszPath, uint dx);

		/// <summary>
		/// <para>Truncates a path to fit within a certain number of characters by replacing path components with ellipses.</para>
		/// </summary>
		/// <param name="pszOut">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>The address of the string that has been altered.</para>
		/// </param>
		/// <param name="pszSrc">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of length MAX_PATH that contains the path to be altered.</para>
		/// </param>
		/// <param name="cchMax">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The maximum number of characters to be contained in the new string, including the terminating null character. For example, if
		/// cchMax = 8, the resulting string can contain a maximum of 7 characters plus the terminating null character.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The '/' separator will be used instead of '' if the original string used it. If pszSrc points to a file name that is too long,
		/// instead of a path, the file name will be truncated to cchMax characters, including the ellipsis and the terminating <c>NULL</c>
		/// character. For example, if the input file name is "My Filename" and cchMax is 10, <c>PathCompactPathEx</c> will return "My Fil...".
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathcompactpathexa BOOL PathCompactPathExA( LPSTR pszOut,
		// LPCSTR pszSrc, UINT cchMax, DWORD dwFlags );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "ff108ee6-3d71-4ab2-a04a-d4bcce408f88")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathCompactPathEx(StringBuilder pszOut, string pszSrc, uint cchMax, uint dwFlags = 0);

		/// <summary>
		/// <para>Converts a file URL to a Microsoft MS-DOS path.</para>
		/// </summary>
		/// <param name="pszUrl">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>A null-terminated string of maximum length INTERNET_MAX_URL_LENGTH that contains the URL.</para>
		/// </param>
		/// <param name="pszPath">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// A pointer to a buffer that, when this function returns successfully, receives the MS-DOS path. You must set the size of this
		/// buffer to MAX_PATH to ensure that it is large enough to hold the returned string.
		/// </para>
		/// </param>
		/// <param name="pcchPath">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The number of characters in the pszPath buffer.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Reserved. Set this parameter to <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathcreatefromurla LWSTDAPI PathCreateFromUrlA( PCSTR
		// pszUrl, PSTR pszPath, DWORD *pcchPath, DWORD dwFlags );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "f4136c80-a309-4551-be73-f2f24ecd4675")]
		public static extern HRESULT PathCreateFromUrl(string pszUrl, StringBuilder pszPath, ref uint pcchPath, uint dwFlags = 0);

		/// <summary>
		/// <para>Creates a path from a file URL.</para>
		/// </summary>
		/// <param name="pszIn">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>A pointer to the URL of a file, represented as a null-terminated, Unicode string.</para>
		/// </param>
		/// <param name="ppszOut">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// The address of a pointer to a buffer of length MAX_PATH that, when this function returns successfully, receives the file path.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Reserved, must be 0.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathcreatefromurlalloc LWSTDAPI PathCreateFromUrlAlloc(
		// PCWSTR pszIn, PWSTR *ppszOut, DWORD dwFlags );
		[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("shlwapi.h", MSDNShortId = "274411cd-5922-4db8-8775-feb93cae32dd")]
		public static extern HRESULT PathCreateFromUrlAlloc(string pszIn, ref StringBuilder ppszOut, uint dwFlags = 0);

		/// <summary>
		/// <para>Determines whether a path to a file system object such as a file or folder is valid.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the full path of the object to verify.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the file exists; otherwise, <c>FALSE</c>. Call GetLastError for extended error information.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function tests the validity of the path.</para>
		/// <para>
		/// A path specified by Universal Naming Convention (UNC) is limited to a file only; that is, \server\share\file is permitted. A UNC
		/// path to a server or server share is not permitted; that is, \server or \server\share. This function returns <c>FALSE</c> if a
		/// mounted remote drive is out of service.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathfileexistsa BOOL PathFileExistsA( LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "26d01e9f-cbf2-4e40-9970-a594879b424d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathFileExists(string pszPath);

		/// <summary>
		/// <para>Searches a path for an extension.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of maximum length MAX_PATH that contains the path to search, including the extension being
		/// searched for.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// Returns the address of the "." that precedes the extension within pszPath if an extension is found, or the address of the
		/// terminating null character otherwise.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Note that a valid file name extension cannot contain a space. For more information on valid file name extensions, see File Type Handlers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathfindextensiona LPCSTR PathFindExtensionA( LPCSTR
		// pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "afebd4b7-2685-4b6e-8f8a-d43944dacef5")]
		public static extern IntPtr PathFindExtension(string pszPath);

		/// <summary>
		/// <para>Searches a path for a file name.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>Returns a pointer to the address of the string if successful, or a pointer to the beginning of the path otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathfindfilenamea LPCSTR PathFindFileNameA( LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "f3824dee-1169-4f89-9844-35aa8a1830c4")]
		public static extern IntPtr PathFindFileName(string pszPath);

		/// <summary>
		/// <para>Parses a path and returns the portion of that path that follows the first backslash.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string that contains the path to parse. This string must not be longer than MAX_PATH characters,
		/// plus the terminating null character. Path components are delimited by backslashes. For instance, the path
		/// "c:\path1\path2\file.txt" has four components: c:, path1, path2, and file.txt.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>Returns a pointer to a null-terminated string that contains the truncated path.</para>
		/// <para>If pszPath points to the last component in the path, this function returns a pointer to the terminating null character.</para>
		/// <para>If pszPath points to the terminating null character or if the call fails, this function returns <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>PathFindNextComponent</c> walks a path string until it encounters a backslash ("\"), ignores everything up to that point
		/// including the backslash, and returns the rest of the path. Therefore, if a path begins with a backslash (such as \path1\path2),
		/// the function simply removes the initial backslash and returns the rest (path1\path2).
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following simple console application passes various strings to <c>PathFindNextComponent</c> to demonstrate what the function
		/// recognizes as a path component and to show what is returned. To run this code in Visual Studio, you must link to Shlwapi.lib and
		/// define UNICODE in the preprocessor commands in the project settings.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathfindnextcomponenta LPCSTR PathFindNextComponentA(
		// LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "2c76b901-dc0e-4f26-93c8-3c59b8f7147d")]
		public static extern IntPtr PathFindNextComponent(string pszPath);

		/// <summary>
		/// <para>Searches for a file.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>TBD</para>
		/// </param>
		/// <param name="ppszOtherDirs">
		/// <para>Type: <c>LPCTSTR*</c></para>
		/// <para>An optional, null-terminated array of directories to be searched first. This value can be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>PathFindOnPath</c> searches for the file specified by pszFile. If no directories are specified in ppszOtherDirs, it attempts
		/// to find the file by searching standard directories such as System32 and the directories specified in the PATH environment
		/// variable. To expedite the process or enable <c>PathFindOnPath</c> to search a wider range of directories, use the ppszOtherDirs
		/// parameter to specify one or more directories to be searched first. If more than one file has the name specified by pszFile,
		/// <c>PathFindOnPath</c> returns the first instance it finds.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathfindonpatha BOOL PathFindOnPathA( LPSTR pszPath,
		// PZPCSTR ppszOtherDirs );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "d9281eb2-39b7-444f-85b7-1e1e76c38ae2")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathFindOnPath(StringBuilder pszFile, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr)] string[] ppszOtherDirs);

		/// <summary>
		/// <para>Determines whether a given file name has one of a list of suffixes.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of maximum length MAX_PATH that contains the file name to be tested. A full path can be used.
		/// </para>
		/// </param>
		/// <param name="apszSuffix">
		/// <para>Type: <c>const LPCTSTR*</c></para>
		/// <para>
		/// An array of iArraySize string pointers. Each string pointed to is null-terminated and contains one suffix. The strings can be of
		/// variable lengths.
		/// </para>
		/// </param>
		/// <param name="iArraySize">
		/// <para>Type: <c>int</c></para>
		/// <para>The number of elements in the array pointed to by apszSuffix.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// Returns a pointer to a string with the matching suffix if successful, or <c>NULL</c> if pszPath does not end with one of the
		/// specified suffixes.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>This function uses a case-sensitive comparison. The suffix must match exactly.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathfindsuffixarraya LPCSTR PathFindSuffixArrayA( LPCSTR
		// pszPath, const LPCSTR *apszSuffix, int iArraySize );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "e2285f7d-bb5d-48c5-bdf1-10ca410389f0")]
		public static extern IntPtr PathFindSuffixArray(string pszPath, string[] apszSuffix, int iArraySize);

		/// <summary>
		/// <para>Finds the command line arguments within a given path.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>Pointer to a null-terminated string of maximum length MAX_PATH that contains the path to be searched.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>Returns a pointer to a null-terminated string that contains the arguments portion of the path if successful.</para>
		/// <para>If there are no arguments in the path, the function returns a pointer to the end of the input string.</para>
		/// <para>If the function is given a <c>NULL</c> argument it returns <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function should not be used on generic command path templates (from users or the registry), but rather should be used only
		/// on templates that the application knows to be well formed.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathgetargsa LPCSTR PathGetArgsA( LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "17dfb601-1306-41b6-a504-8bf69ff204c9")]
		public static extern IntPtr PathGetArgs(string pszPath);

		/// <summary>
		/// <para>Determines the type of character in relation to a path.</para>
		/// </summary>
		/// <param name="ch">
		/// <para>Type: <c>TUCHAR</c></para>
		/// <para>The character for which to determine the type.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Returns one or more of the following values that define the type of character.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GCT_INVALID</term>
		/// <term>The character is not valid in a path.</term>
		/// </item>
		/// <item>
		/// <term>GCT_LFNCHAR</term>
		/// <term>The character is valid in a long file name.</term>
		/// </item>
		/// <item>
		/// <term>GCT_SEPARATOR</term>
		/// <term>The character is a path separator.</term>
		/// </item>
		/// <item>
		/// <term>GCT_SHORTCHAR</term>
		/// <term>The character is valid in a short (8.3) file name.</term>
		/// </item>
		/// <item>
		/// <term>GCT_WILD</term>
		/// <term>The character is a wildcard character.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathgetchartypea UINT PathGetCharTypeA( UCHAR ch );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "838a255f-413e-424c-819e-47265224208d")]
		public static extern GCT PathGetCharType(char ch);

		/// <summary>
		/// <para>Searches a path for a drive letter within the range of 'A' to 'Z' and returns the corresponding drive number.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>Returns 0 through 25 (corresponding to 'A' through 'Z') if the path has a drive letter, or -1 otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathgetdrivenumbera int PathGetDriveNumberA( LPCSTR
		// pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "38914866-fdd4-47f2-b0e7-d09d1cfb0eee")]
		public static extern int PathGetDriveNumber(string pszPath);

		/// <summary>
		/// <para>
		/// Determines if a file's registered content type matches the specified content type. This function obtains the content type for the
		/// specified file type and compares that string with the pszContentType. The comparison is not case-sensitive.
		/// </para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the file whose content type will be compared.</para>
		/// </param>
		/// <param name="pszContentType">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The address of a character buffer that contains the null-terminated content type string to which the file's registered content
		/// type will be compared.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns nonzero if the file's registered content type matches pszContentType, or zero otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathiscontenttypea BOOL PathIsContentTypeA( LPCSTR
		// pszPath, LPCSTR pszContentType );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "53eac496-9666-41fc-8682-f7b6583a62fe")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsContentType(string pszPath, string pszContentType);

		/// <summary>
		/// <para>Verifies that a path is a valid directory.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the path to verify.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns (BOOL)FILE_ATTRIBUTE_DIRECTORY if the path is a valid directory; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathisdirectorya BOOL PathIsDirectoryA( LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "9af3e3da-6b3a-4e81-ba50-ff7aeeb73c44")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsDirectory(string pszPath);

		/// <summary>
		/// <para>Determines whether a specified path is an empty directory.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the path to be tested.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Returns <c>TRUE</c> if pszPath is an empty directory. Returns <c>FALSE</c> if pszPath is not a directory, or if it contains at
		/// least one file other than "." or "..".
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>"C:" is considered a directory.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathisdirectoryemptya BOOL PathIsDirectoryEmptyA( LPCSTR
		// pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "833fe68e-8b21-4819-8370-d1b5391a3080")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsDirectoryEmpty(string pszPath);

		/// <summary>
		/// <para>
		/// Searches a path for any path-delimiting characters (for example, ':' or '' ). If there are no path-delimiting characters present,
		/// the path is considered to be a File Spec path.
		/// </para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Returns <c>TRUE</c> if there are no path-delimiting characters within the path, or <c>FALSE</c> if there are path-delimiting characters.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathisfilespeca BOOL PathIsFileSpecA( LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "c69d6cca-44e7-4792-8fb2-3c4ecd2e57f2")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsFileSpec(string pszPath);

		/// <summary>
		/// <para>Determines whether a file name is in long format.</para>
		/// </summary>
		/// <param name="pszName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the file name to be tested.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if pszName exceeds the number of characters allowed by the 8.3 format, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathislfnfilespeca BOOL PathIsLFNFileSpecA( LPCSTR pszName );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "599cb457-da72-4416-bfb7-5bc55a0eeb2d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsLFNFileSpec(string pszName);

		/// <summary>
		/// <para>Determines whether a path string represents a network resource.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the path.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if the string represents a network resource, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>PathIsNetworkPath</c> interprets the following two types of paths as network paths.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Paths that begin with two backslash characters (\\) are interpreted as Universal Naming Convention (UNC) paths.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Paths that begin with a letter followed by a colon (:) are interpreted as a mounted network drive. However,
		/// <c>PathIsNetworkPath</c> cannot recognize a network drive mapped to a drive letter through the Microsoft MS-DOS SUBST command or
		/// the DefineDosDevice function.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The function does not verify that the specified network resource exists, is currently accessible, or that the user
		/// has sufficient permissions to access it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathisnetworkpatha BOOL PathIsNetworkPathA( LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "3a9c33bc-2325-4285-b6c3-4c3e1d323c1e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsNetworkPath(string pszPath);

		/// <summary>
		/// <para>
		/// Searches a path to determine if it contains a valid prefix of the type passed by pszPrefix. A prefix is one of these types:
		/// "C:\", ".", "..", "..\".
		/// </para>
		/// </summary>
		/// <param name="pszPrefix">
		/// <para>Type: <c>IN LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the prefix for which to search.</para>
		/// </param>
		/// <param name="pszPath">
		/// <para>Type: <c>IN LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the path to be searched.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if the compared path is the full prefix for the path, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathisprefixa BOOL PathIsPrefixA( LPCSTR pszPrefix, LPCSTR
		// pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "b24f761e-6492-4a6d-9c7e-d5a5f2cbdaf3")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsPrefix(string pszPrefix, string pszPath);

		/// <summary>
		/// <para>Searches a path and determines if it is relative.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if the path is relative, or <c>FALSE</c> if it is absolute.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathisrelativea BOOL PathIsRelativeA( LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "ad36c277-645f-4c62-af7d-b75e29de573f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsRelative(string pszPath);

		/// <summary>
		/// <para>Determines whether a path string refers to the root of a volume.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if the specified path is a root, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Returns <c>TRUE</c> for paths such as "", "X:" or "\server&lt;i&gt;share". Paths such as "..\path2" or "\server" return <c>FALSE</c>.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathisroota BOOL PathIsRootA( LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "8586df98-91c4-49a6-9b07-7dceb8a63431")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsRoot(string pszPath);

		/// <summary>
		/// <para>Compares two paths to determine if they have a common root component.</para>
		/// </summary>
		/// <param name="pszPath1">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the first path to be compared.</para>
		/// </param>
		/// <param name="pszPath2">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the second path to be compared.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Returns <c>TRUE</c> if both strings have the same root component, or <c>FALSE</c> otherwise. If pszPath1 contains only the server
		/// and share, this function also returns <c>FALSE</c>.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathissameroota BOOL PathIsSameRootA( LPCSTR pszPath1,
		// LPCSTR pszPath2 );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "3409a8f1-e22c-4c13-961e-211a2d10fe10")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsSameRoot(string pszPath1, string pszPath2);

		/// <summary>
		/// <para>
		/// Determines if an existing folder contains the attributes that make it a system folder. Alternately, this function indicates if
		/// certain attributes qualify a folder to be a system folder.
		/// </para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of maximum length MAX_PATH that contains the name of an existing folder. The attributes for
		/// this folder will be retrieved and compared with those that define a system folder. If this folder contains the attributes to make
		/// it a system folder, the function returns nonzero. If this value is <c>NULL</c>, this function determines if the attributes passed
		/// in dwAttrb qualify it to be a system folder.
		/// </para>
		/// </param>
		/// <param name="dwAttrb">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The file attributes to be compared. Used only if pszPath is <c>NULL</c>. In that case, the attributes passed in this value are
		/// compared with those that qualify a folder as a system folder. If the attributes are sufficient to make this a system folder, this
		/// function returns nonzero. These attributes are the attributes that are returned from GetFileAttributes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns nonzero if the pszPath or dwAttrb represent a system folder, or zero otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathissystemfoldera BOOL PathIsSystemFolderA( LPCSTR
		// pszPath, DWORD dwAttrb );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "796901a8-1bc1-4fd1-b5b8-acd8f930ff14")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsSystemFolder(string pszPath, FileFlagsAndAttributes dwAttrb);

		/// <summary>
		/// <para>Determines if a path string is a valid Universal Naming Convention (UNC) path, as opposed to a path based on a drive letter.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the path to validate.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if the string is a valid UNC path; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathisunca BOOL PathIsUNCA( LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "53da5ba7-a2a4-45b2-90e0-ae006415933e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsUNC(string pszPath);

		/// <summary>
		/// <para>Determines if a string is a valid Universal Naming Convention (UNC) for a server path only.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the path to validate.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if the string is a valid UNC path for a server only (no share name), or <c>FALSE</c> otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathisuncservera BOOL PathIsUNCServerA( LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "9158ceb6-dd20-4b1a-93d3-cf7a5a5c6c75")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsUNCServer(string pszPath);

		/// <summary>
		/// <para>Determines if a string is a valid Universal Naming Convention (UNC) share path, \server&lt;i&gt;share.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the path to be validated.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if the string is in the form \server&lt;i&gt;share, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathisuncserversharea BOOL PathIsUNCServerShareA( LPCSTR
		// pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "306cfc34-7cb2-4f60-af5c-8b567149c2fc")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsUNCServerShare(string pszPath);

		/// <summary>
		/// <para>Tests a given string to determine if it conforms to a valid URL format.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the URL path to validate.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if pszPath has a valid URL format, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function does not verify that the path points to an existing site—only that it has a valid URL format.</para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathisurla BOOL PathIsURLA( LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "8791bcd8-0d8f-4f7b-9c8e-59bcb95b5d19")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathIsURL(string pszPath);

		/// <summary>
		/// <para>Converts an all-uppercase path to all lowercase characters to give the path a consistent appearance.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if the path has been converted, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function only operates on paths that are entirely uppercase. For example: C:\WINDOWS will be converted to c:\windows, but
		/// c:\Windows will not be changed.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathmakeprettya BOOL PathMakePrettyA( LPSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "fb871054-4c63-42de-b85b-edefa4b09ea0")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathMakePretty(StringBuilder pszPath);

		/// <summary>
		/// <para>Gives an existing folder the proper attributes to become a system folder.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of length MAX_PATH that contains the name of an existing folder that will be made into a
		/// system folder.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathmakesystemfoldera BOOL PathMakeSystemFolderA( LPCSTR
		// pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "5b0faeb8-f8ae-481b-b5b2-cae9efe638e5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathMakeSystemFolder(string pszPath);

		/// <summary>
		/// <para>Searches a string using a Microsoft MS-DOS wildcard match type.</para>
		/// </summary>
		/// <param name="pszFile">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the path to be searched.</para>
		/// </param>
		/// <param name="pszSpec">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of maximum length MAX_PATH that contains the file type for which to search. For example, to
		/// test whether pszFile is a .doc file, pszSpec should be set to "*.doc".
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if the string matches, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathmatchspeca BOOL PathMatchSpecA( LPCSTR pszFile, LPCSTR
		// pszSpec );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "908e7204-d168-4179-9c7b-ad46ba68bebc")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathMatchSpec(string pszFile, string pszSpec);

		/// <summary>
		/// <para>Matches a file name from a path against one or more file name patterns.</para>
		/// </summary>
		/// <param name="pszFile">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of maximum length MAX_PATH that contains the path from which the file name to be matched is taken.
		/// </para>
		/// </param>
		/// <param name="pszSpec">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of maximum length MAX_PATH that contains the file name pattern for which to search. This
		/// can be the exact name, or it can contain wildcard characters. If exactly one pattern is specified, set the <c>PMSF_NORMAL</c>
		/// flag in dwFlags. If more than one pattern is specified, separate them with semicolons and set the <c>PMSF_MULTIPLE</c> flag.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Modifies the search condition. The following are valid flags.</para>
		/// <para>PMSF_NORMAL (0x00000000)</para>
		/// <para>The pszSpec parameter points to a single file name pattern to be matched.</para>
		/// <para>PMSF_MULTIPLE (0x00000001)</para>
		/// <para>The pszSpec parameter points to a semicolon-delimited list of file name patterns to be matched.</para>
		/// <para>PMSF_DONT_STRIP_SPACES (0x00010000)</para>
		/// <para>
		/// If <c>PMSF_NORMAL</c> is used, ignore leading spaces in the string pointed to by pszSpec. If <c>PMSF_MULTIPLE</c> is used, ignore
		/// leading spaces in each file type contained in the string pointed to by pszSpec. This flag can be combined with <c>PMSF_NORMAL</c>
		/// and <c>PMSF_MULTIPLE</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>A file name pattern specified in pszSpec matched the file name found in the string pointed to by pszFile.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>No file name pattern specified in pszSpec matched the file name found in the string pointed to by pszFile.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathmatchspecexa LWSTDAPI PathMatchSpecExA( LPCSTR
		// pszFile, LPCSTR pszSpec, DWORD dwFlags );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "bd9bf950-e349-4b67-8608-7acad84c0907")]
		public static extern HRESULT PathMatchSpecEx(string pszFile, string pszSpec, PMSF dwFlags);

		/// <summary>
		/// <para>Parses a file location string that contains a file location and icon index, and returns separate values.</para>
		/// </summary>
		/// <param name="pszIconFile">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of length MAX_PATH that contains a file location string. It should be in the form
		/// "path,iconindex". When the function returns, pszIconFile will point to the file's path.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>Returns the valid icon index value.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is useful for taking a DefaultIcon value retrieved from the registry by SHGetValue and separating the icon index
		/// from the path.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathparseiconlocationa int PathParseIconLocationA( LPSTR
		// pszIconFile );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "1ded2f0f-0e11-4730-ab7b-16536e7f4435")]
		public static extern int PathParseIconLocation(StringBuilder pszIconFile);

		/// <summary>
		/// <para>Searches a path for spaces. If spaces are found, the entire path is enclosed in quotation marks.</para>
		/// </summary>
		/// <param name="lpsz">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string that contains the path to search. The size of this buffer must be set to MAX_PATH to ensure
		/// that it is large enough to hold the returned string.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if spaces were found; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathquotespacesa BOOL PathQuoteSpacesA( LPSTR lpsz );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "76a51c21-b924-4919-a6bb-8c6bdec5b3f0")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathQuoteSpaces(StringBuilder lpsz);

		/// <summary>
		/// <para>Creates a relative path from one file or folder to another.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>A pointer to a string that receives the relative path. This buffer must be at least MAX_PATH characters in size.</para>
		/// </param>
		/// <param name="pszFrom">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of maximum length MAX_PATH that contains the path that defines the start of the relative path.
		/// </para>
		/// </param>
		/// <param name="dwAttrFrom">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The file attributes of pszFrom. If this value contains FILE_ATTRIBUTE_DIRECTORY, pszFrom is assumed to be a directory; otherwise,
		/// pszFrom is assumed to be a file.
		/// </para>
		/// </param>
		/// <param name="pszTo">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of maximum length MAX_PATH that contains the path that defines the endpoint of the relative path.
		/// </para>
		/// </param>
		/// <param name="dwAttrTo">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The file attributes of pszTo. If this value contains FILE_ATTRIBUTE_DIRECTORY, pszTo is assumed to be directory; otherwise, pszTo
		/// is assumed to be a file.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function takes a pair of paths and generates a relative path from one to the other. The paths do not have to be fully
		/// qualified, but they must have a common prefix, or the function will fail and return <c>FALSE</c>.
		/// </para>
		/// <para>
		/// For example, let the starting point, pszFrom, be "c:\FolderA\FolderB\FolderC", and the ending point, pszTo, be
		/// "c:\FolderA\FolderD\FolderE". <c>PathRelativePathTo</c> will return the relative path from pszFrom to pszTo as:
		/// "....\FolderD\FolderE". You will get the same result if you set pszFrom to "\FolderA\FolderB\FolderC" and pszTo to
		/// "\FolderA\FolderD\FolderE". On the other hand, "c:\FolderA\FolderB" and "a:\FolderA\FolderD do not share a common prefix, and the
		/// function will fail. Note that "\" is not considered a prefix and is ignored. If you set pszFrom to "\FolderA\FolderB", and pszTo
		/// to "\FolderC\FolderD", the function will fail.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathrelativepathtoa BOOL PathRelativePathToA( LPSTR
		// pszPath, LPCSTR pszFrom, DWORD dwAttrFrom, LPCSTR pszTo, DWORD dwAttrTo );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "7ed8d50a-2ad4-4ddf-941d-aea593341592")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathRelativePathTo(StringBuilder pszPath, string pszFrom, FileFlagsAndAttributes dwAttrFrom, string pszTo, FileFlagsAndAttributes dwAttrTo);

		/// <summary>
		/// <para>Removes any arguments from a given path.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>Pointer to a null-terminated string of length MAX_PATH that contains the path from which to remove arguments.</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function should not be used on generic command path templates (from users or the registry), but rather it should be used
		/// only on templates that the application knows to be well formed.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathremoveargsa void PathRemoveArgsA( LPSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "430072bc-4ddc-4b3d-bf32-fb60d7b56faf")]
		public static extern void PathRemoveArgs(StringBuilder pszPath);

		/// <summary>
		/// <para>Removes the trailing backslash from a given path.</para>
		/// <para>
		/// <c>Note</c> This function is deprecated. We recommend the use of the PathCchRemoveBackslash or PathCchRemoveBackslashEx function
		/// in its place.
		/// </para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer that, when this function returns successfully and if a backslash has been removed, points to the terminating null
		/// character that has replaced the backslash at the end of the string. If the path did not include a trailing backslash, this value
		/// will point to the final character in the string.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathremovebackslasha LPSTR PathRemoveBackslashA( LPSTR
		// pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "58d13c38-40aa-4aaa-81dc-2b68425f1fe0")]
		public static extern IntPtr PathRemoveBackslash(StringBuilder pszPath);

		/// <summary>
		/// <para>Removes all leading and trailing spaces from a string.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathremoveblanksa void PathRemoveBlanksA( LPSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "0f496855-3ea7-4193-b895-fd4ea26ef6c5")]
		public static extern void PathRemoveBlanks(StringBuilder pszPath);

		/// <summary>
		/// <para>Removes the file name extension from a path, if one is present.</para>
		/// <para><c>Note</c> This function is deprecated. We recommend the use of the PathCchRemoveExtension in its place.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>A pointer to a null-terminated string of length MAX_PATH from which to remove the extension.</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathremoveextensiona void PathRemoveExtensionA( LPSTR
		// pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "6e26d005-50af-4376-b734-19ba3d9c470f")]
		public static extern void PathRemoveExtension(StringBuilder pszPath);

		/// <summary>
		/// <para>Removes the trailing file name and backslash from a path, if they are present.</para>
		/// <para><c>Note</c> This function is deprecated. We recommend the use of the PathCchRemoveFileSpec function in its place.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>A pointer to a null-terminated string of length MAX_PATH that contains the path from which to remove the file name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns nonzero if something was removed, or zero otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathremovefilespeca BOOL PathRemoveFileSpecA( LPSTR
		// pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "c47bcf8a-c59d-4d6a-81a9-a3960ae39867")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathRemoveFileSpec(StringBuilder pszPath);

		/// <summary>
		/// <para>
		/// Replaces the extension of a file name with a new extension. If the file name does not contain an extension, the extension will be
		/// attached to the end of the string.
		/// </para>
		/// <para>
		/// <c>Note</c> Misuse of this function can lead to a buffer overrun. We recommend the use of the safer PathCchRenameExtension
		/// function in its place.
		/// </para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>Pointer to a null-terminated string of length MAX_PATH in which to replace the extension.</para>
		/// </param>
		/// <param name="pszExt">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>Pointer to a character buffer that contains a '.' character followed by the new extension.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns nonzero if successful, or zero if the new path and extension would exceed MAX_PATH characters.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathrenameextensiona BOOL PathRenameExtensionA( LPSTR
		// pszPath, LPCSTR pszExt );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "3d94f67c-e3ee-4b64-b0b9-8f771423bdc5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathRenameExtension(StringBuilder pszPath, string pszExt);

		/// <summary>
		/// <para>Determines if a given path is correctly formatted and fully qualified.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>TBD</para>
		/// </param>
		/// <param name="pszBuf">
		/// <para>TBD</para>
		/// </param>
		/// <param name="cchBuf">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if the path is qualified, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathsearchandqualifya BOOL PathSearchAndQualifyA( LPCSTR
		// pszPath, LPSTR pszBuf, UINT cchBuf );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "90da281d-349a-460a-aa5a-14e3b4ced727")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathSearchAndQualify(string pszPath, StringBuilder pszBuf, uint cchBuf);

		/// <summary>
		/// <para>Sets the text of a child control in a window or dialog box, using PathCompactPath to ensure the path fits in the control.</para>
		/// </summary>
		/// <param name="hDlg">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the dialog box or window.</para>
		/// </param>
		/// <param name="id">
		/// <para>Type: <c>int</c></para>
		/// <para>The identifier of the control.</para>
		/// </param>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the path to set in the control.</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathsetdlgitempatha void PathSetDlgItemPathA( HWND hDlg,
		// int id, LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "05737525-d906-482c-847f-bdbf0ba0ce3d")]
		public static extern void PathSetDlgItemPath(HandleRef hDlg, int id, string pszPath);

		/// <summary>
		/// <para>
		/// Retrieves a pointer to the first character in a path following the drive letter or Universal Naming Convention (UNC) server/share
		/// path elements.
		/// </para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the path to parse.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// A pointer that, when this function returns successfully, points to the beginning of the subpath that follows the root (drive
		/// letter or UNC server/share). If the function encounters an error, this value will be <c>NULL</c>.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathskiproota LPCSTR PathSkipRootA( LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "528a3953-26d7-4fff-be31-9c9788d429ab")]
		public static extern IntPtr PathSkipRoot(string pszPath);

		/// <summary>
		/// <para>Removes the path portion of a fully qualified path and file.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of length MAX_PATH that contains the path and file name. When this function returns
		/// successfully, the string contains only the file name, with the path removed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathstrippatha void PathStripPathA( LPSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "84b439f2-f570-4e7f-bc3f-e0fdd185ea15")]
		public static extern void PathStripPath(StringBuilder pszPath);

		/// <summary>
		/// <para>Removes all file and directory elements in a path except for the root information.</para>
		/// <para>
		/// <c>Note</c> Misuse of this function can lead to a buffer overrun. We recommend the use of the safer PathCchStripToRoot function
		/// in its place.
		/// </para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if a valid drive letter was found in the path, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathstriptoroota BOOL PathStripToRootA( LPSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "ce9a1a40-2a03-44d2-80bc-0dc10654550b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathStripToRoot(StringBuilder pszPath);

		/// <summary>
		/// <para>Removes the decoration from a path string.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A null-terminated string of length MAX_PATH that contains the path. When the function returns, pszPath points to the undecorated string.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A decoration consists of a pair of square brackets with one or more digits in between, inserted immediately after the base name
		/// and before the file name extension.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following table illustrates how strings are modified by <c>PathUndecorate</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Initial String</term>
		/// <term>Undecorated String</term>
		/// </listheader>
		/// <item>
		/// <term>C:\Path\File[5].txt</term>
		/// <term>C:\Path\File.txt</term>
		/// </item>
		/// <item>
		/// <term>C:\Path\File[12]</term>
		/// <term>C:\Path\File</term>
		/// </item>
		/// <item>
		/// <term>C:\Path\File.txt</term>
		/// <term>C:\Path\File.txt</term>
		/// </item>
		/// <item>
		/// <term>C:\Path\[3].txt</term>
		/// <term>C:\Path\[3].txt</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathundecoratea void PathUndecorateA( LPSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "2d98ad60-8a7d-4b8d-9b5c-27e348bdc2c3")]
		public static extern void PathUndecorate(StringBuilder pszPath);

		/// <summary>
		/// <para>Replaces certain folder names in a fully qualified path with their associated environment string.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of maximum length MAX_PATH that contains the path to be unexpanded.</para>
		/// </param>
		/// <param name="pszBuf">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a buffer that, when this method returns successfully, receives the unexpanded string. The size of this buffer must
		/// be set to MAX_PATH to ensure that it is large enough to hold the returned string.
		/// </para>
		/// </param>
		/// <param name="cchBuf">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size, in characters, in the pszBuf buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>The following folder paths are replaced by their equivalent environment string.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Folder</term>
		/// <term>Environment String</term>
		/// </listheader>
		/// <item>
		/// <term>The All Users profile folder</term>
		/// <term>%ALLUSERSPROFILE%</term>
		/// </item>
		/// <item>
		/// <term>The current user's application data folder (Windows Vista and later only).</term>
		/// <term>%APPDATA%</term>
		/// </item>
		/// <item>
		/// <term>The system name</term>
		/// <term>%COMPUTERNAME%</term>
		/// </item>
		/// <item>
		/// <term>The Program Files folder</term>
		/// <term>%ProgramFiles%</term>
		/// </item>
		/// <item>
		/// <term>The system root folder</term>
		/// <term>%SystemRoot%</term>
		/// </item>
		/// <item>
		/// <term>The system drive letter</term>
		/// <term>%SystemDrive%</term>
		/// </item>
		/// <item>
		/// <term>The current user's profile folder</term>
		/// <term>%USERPROFILE%</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> %APPDATA% and %USERPROFILE% are relative to the user making the call. This function does not work if the user is
		/// being impersonated from a service. For further discussion of access control issues, see Access Control.
		/// </para>
		/// <para>
		/// The environment variables listed in the above table might not all be set on all systems. If an environment variable is not set,
		/// it is not unexpanded.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathunexpandenvstringsa BOOL PathUnExpandEnvStringsA(
		// LPCSTR pszPath, LPSTR pszBuf, UINT cchBuf );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "cfab1ee0-03f3-4e0f-a29d-5331fec022b5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathUnExpandEnvStrings(string pszPath, StringBuilder pszBuf, uint cchBuf);

		/// <summary>
		/// <para>Removes the attributes from a folder that make it a system folder. This folder must actually exist in the file system.</para>
		/// </summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of maximum length MAX_PATH that contains the name of an existing folder that will have the
		/// system folder attributes removed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathunmakesystemfoldera BOOL PathUnmakeSystemFolderA(
		// LPCSTR pszPath );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "9c748ed6-3ee6-4889-8fdd-b33ed9d711d0")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathUnmakeSystemFolder(string pszPath);

		/// <summary>
		/// <para>Removes quotes from the beginning and end of a path.</para>
		/// </summary>
		/// <param name="lpsz">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of length MAX_PATH that contains the path. When the function returns successfully, points
		/// to the string with beginning and ending quotation marks removed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>No return value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathunquotespacesa BOOL PathUnquoteSpacesA( LPSTR lpsz );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "00474c95-ec59-489a-bee3-191b98a47567")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathUnquoteSpaces(StringBuilder lpsz);
	}
}