using System.ComponentModel.DataAnnotations;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>The maximum number of characters supported using the "\\?\" syntax for a file path.</summary>
	public const uint PATHCCH_MAX_CCH = 0x8000;

	/// <summary>Flags used by PathCch functions.</summary>
	[PInvokeData("pathcch.h", MSDNShortId = "3179fe78-a969-4ee2-a50b-5f4f7d4dad71")]
	[Flags]
	public enum PATHCCH_OPTIONS
	{
		/// <summary>Do not allow for the construction of \\?\ paths (ie, long paths) longer than MAX_PATH.</summary>
		PATHCCH_NONE = 0x0000000,

		/// <summary>Allow the building of \\?\ paths longer than MAX_PATH.</summary>
		PATHCCH_ALLOW_LONG_PATHS = 0x00000001,

		/// <summary>
		/// Forces the API to treat the caller as long path enabled, independent of the PATHCCH_FORCE_DISABLE_LONG_NAME_PROCESS. Note
		/// This value is available starting in Windows 10, version 1703.
		/// </summary>
		PATHCCH_FORCE_ENABLE_LONG_NAME_PROCESS = 0x00000002,

		/// <summary>
		/// Forces the API to treat the caller as long path disabled, independent of the Note This value is available starting in Windows
		/// 10, version 1703.
		/// </summary>
		PATHCCH_FORCE_DISABLE_LONG_NAME_PROCESS = 0x00000004,

		/// <summary>
		/// Disables the normalization of path segments that includes removing trailing dots and spaces. Note This value is available
		/// starting in Windows 10, version 1703.
		/// </summary>
		PATHCCH_DO_NOT_NORMALIZE_SEGMENTS = 0x00000008,

		/// <summary>
		/// Converts the input path into the extended length DOS device path form (with the \\?\ prefix) Note This value is available
		/// starting in Windows 10, version 1703.
		/// </summary>
		PATHCCH_ENSURE_IS_EXTENDED_LENGTH_PATH = 0x00000010,

		/// <summary>
		/// When combining or normalizing a path, ensure there is a trailing backslash. Note This value is available starting in Windows
		/// 10, version 1703.
		/// </summary>
		PATHCCH_ENSURE_TRAILING_SLASH = 0x00000020,
	}

	/// <summary>
	/// <para>Converts a path string into a canonical form.</para>
	/// <para>
	/// This function differs from PathCchCanonicalize and PathCchCanonicalizeEx in that it returns the result on the heap. This means
	/// that the caller does not have to declare the size of the returned string and reduces stack use.
	/// </para>
	/// <para>This function differs from PathCanonicalize in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para><c>Note</c> This function, PathCchCanonicalize, or PathCchCanonicalizeEx, should be used in place of PathCanonicalize.</para>
	/// </summary>
	/// <param name="pszPathIn">
	/// <para>A pointer to a buffer that contains the original string. This value cannot be <c>NULL</c>.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>One or more of the following flags:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PATHCCH_NONE 0x0000000</term>
	/// <term>Do not allow for the construction of \\?\ paths (ie, long paths) longer than MAX_PATH.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_ALLOW_LONG_PATHS 0x00000001</term>
	/// <term>Allow the building of \\?\ paths longer than MAX_PATH.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_FORCE_ENABLE_LONG_NAME_PROCESS 0x00000002</term>
	/// <term>
	/// Forces the API to treat the caller as long path enabled, independent of the PATHCCH_FORCE_DISABLE_LONG_NAME_PROCESS. Note This
	/// value is available starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_FORCE_DISABLE_LONG_NAME_PROCESS 0x00000004</term>
	/// <term>
	/// Forces the API to treat the caller as long path disabled, independent of the Note This value is available starting in Windows 10,
	/// version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_DO_NOT_NORMALIZE_SEGMENTS 0x00000008</term>
	/// <term>
	/// Disables the normalization of path segments that includes removing trailing dots and spaces. Note This value is available
	/// starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_ENSURE_IS_EXTENDED_LENGTH_PATH 0x00000010</term>
	/// <term>
	/// Converts the input path into the extended length DOS device path form (with the \\?\ prefix) Note This value is available
	/// starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_ENSURE_TRAILING_SLASH 0x00000020</term>
	/// <term>
	/// When combining or normalizing a path, ensure there is a trailing backslash. Note This value is available starting in Windows 10,
	/// version 1703.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppszPathOut">
	/// <para>
	/// The address of a pointer to a buffer that, when this function returns successfully, receives the canonicalized path string. It is
	/// the responsibility of the caller to free this resource, when it is no longer needed, by calling the LocalFree function. This
	/// value cannot be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function supports these alternate path forms:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>\\?\</term>
	/// </item>
	/// <item>
	/// <term>\\?\\UNC\</term>
	/// </item>
	/// <item>
	/// <term>\\?\Volume{guid}\</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathalloccanonicalize HRESULT PathAllocCanonicalize(
	// PCWSTR pszPathIn, ULONG dwFlags, PWSTR *ppszPathOut );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "3179fe78-a969-4ee2-a50b-5f4f7d4dad71")]
	public static extern HRESULT PathAllocCanonicalize(string pszPathIn, PATHCCH_OPTIONS dwFlags, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LocalStringMarshaler))] out string ppszPathOut);

	/// <summary>
	/// <para>
	/// Concatenates two path fragments into a single path. This function also canonicalizes any relative path elements, replacing path
	/// elements such as "." and "..".
	/// </para>
	/// <para>
	/// This function differs from PathCchCombine and PathCchCombineEx in that it returns the result on the heap. This means that the
	/// caller does not have to declare the size of the returned string and reduces stack use.
	/// </para>
	/// <para>This function differs from PathCombine in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para><c>Note</c> This function, PathCchCombine, or PathCchCombineEx, should be used in place of PathCombine.</para>
	/// </summary>
	/// <param name="pszPathIn">
	/// <para>A pointer to the first path string.</para>
	/// </param>
	/// <param name="pszMore">
	/// <para>
	/// A pointer to the second path string. If this path begins with a single backslash, it is combined with only the root of the path
	/// pointed to by pszPathIn. If this path is fully qualified, it is copied directly to the output buffer without being combined with
	/// the other path.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>One or more of the following flags:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PATHCCH_NONE 0x0000000</term>
	/// <term>Do not allow for the construction of \\?\ paths (ie, long paths) longer than MAX_PATH.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_ALLOW_LONG_PATHS 0x00000001</term>
	/// <term>Allow the construction of \\?\ paths longer than MAX_PATH.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_FORCE_ENABLE_LONG_NAME_PROCESS 0x00000002</term>
	/// <term>
	/// Forces the API to treat the caller as long path enabled, independent of the PATHCCH_FORCE_DISABLE_LONG_NAME_PROCESS. Note This
	/// value is available starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_FORCE_DISABLE_LONG_NAME_PROCESS 0x00000004</term>
	/// <term>
	/// Forces the API to treat the caller as long path disabled, independent of the Note This value is available starting in Windows 10,
	/// version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_DO_NOT_NORMALIZE_SEGMENTS 0x00000008</term>
	/// <term>
	/// Disables the normalization of path segments that includes removing trailing dots and spaces. Note This value is available
	/// starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_ENSURE_IS_EXTENDED_LENGTH_PATH 0x00000010</term>
	/// <term>
	/// Converts the input path into the extended length DOS device path form (with the \\?\ prefix) Note This value is available
	/// starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_ENSURE_TRAILING_SLASH 0x00000020</term>
	/// <term>
	/// When combining or normalizing a path, ensure there is a trailing backslash. Note This value is available starting in Windows 10,
	/// version 1703.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppszPathOut">
	/// <para>
	/// The address of a pointer to a buffer that, when this function returns successfully, receives the combined path string. It is the
	/// responsibility of the caller to free this resource, when it is no longer needed, by calling the LocalFree function. This value
	/// cannot be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>While either pszPathIn or pszMore can <c>NULL</c>, they cannot both be <c>NULL</c>.</para>
	/// <para>This function supports these alternate path forms:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>\\?\</term>
	/// </item>
	/// <item>
	/// <term>\\?\\UNC\</term>
	/// </item>
	/// <item>
	/// <term>\\?\Volume{guid}\</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathalloccombine HRESULT PathAllocCombine( PCWSTR
	// pszPathIn, PCWSTR pszMore, ULONG dwFlags, PWSTR *ppszPathOut );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "dd619138-f867-4517-bc67-a52c598efad0")]
	public static extern HRESULT PathAllocCombine(string pszPathIn, string pszMore, PATHCCH_OPTIONS dwFlags, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LocalStringMarshaler))] out string ppszPathOut);

	/// <summary>
	/// <para>
	/// Adds a backslash to the end of a string to create the correct syntax for a path. If the source path already has a trailing
	/// backslash, no backslash will be added.
	/// </para>
	/// <para>This function differs from <c>PathCchAddBackslash</c> in that you are restricted to a final path of length MAX_PATH.</para>
	/// <para>This function differs from PathAddBackslash in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para>
	/// <c>Note</c> This function, or PathCchAddBackslashEx, should be used in place of PathAddBackslash to prevent the possibility of a
	/// buffer overrun.
	/// </para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>
	/// A pointer to the path string. When this function returns successfully, the buffer contains the string with the appended
	/// backslash. This value should not be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// This function returns S_OK if the function was successful, S_FALSE if the path string already ends in a backslash, or an error
	/// code otherwise.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchaddbackslash HRESULT PathCchAddBackslash( PWSTR
	// pszPath, SizeT cchPath );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "b50677cd-8815-4d84-b70a-c83863378c56")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchAddBackslash([In, Out, SizeDef(nameof(cchPath))] StringBuilder pszPath, SizeT cchPath);

	/// <summary>
	/// <para>
	/// Adds a backslash to the end of a string to create the correct syntax for a path. If the source path already has a trailing
	/// backslash, no backslash will be added.
	/// </para>
	/// <para>
	/// This function differs from PathCchAddBackslash in that it can return a pointer to the new end of the string and report the number
	/// of unused characters remaining in the buffer.
	/// </para>
	/// <para>This function differs from PathAddBackslash in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para>
	/// <c>Note</c> This function, or <c>PathCchAddBackslashEx</c>, should be used in place of PathAddBackslash to prevent the
	/// possibility of a buffer overrun.
	/// </para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>
	/// A pointer to the path string. When this function returns successfully, the buffer contains the string with the appended
	/// backslash. This value should not be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <param name="ppszEnd">
	/// <para>
	/// A value that, when this function returns successfully, receives the address of a pointer to the terminating null character at the
	/// end of the string.
	/// </para>
	/// </param>
	/// <param name="pcchRemaining">
	/// <para>
	/// A pointer to a value that, when this function returns successfully, is set to the number of unused characters in the destination
	/// buffer, including the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// This function returns S_OK if the function was successful, S_FALSE if the path string already ends in a backslash, or an error
	/// code otherwise.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchaddbackslashex HRESULT PathCchAddBackslashEx( PWSTR
	// pszPath, SizeT cchPath, PWSTR *ppszEnd, SizeT *pcchRemaining );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "89adf45f-f16d-49d1-9e76-b57b73b4d4c3")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchAddBackslashEx([In, Out, SizeDef(nameof(cchPath))] StringBuilder pszPath, [Range(1, PATHCCH_MAX_CCH)] SizeT cchPath, out LPWSTR ppszEnd, out SizeT pcchRemaining);

	/// <summary>
	/// <para>
	/// Adds a backslash to the end of a string to create the correct syntax for a path. If the source path already has a trailing
	/// backslash, no backslash will be added.
	/// </para>
	/// <para>
	/// This function differs from PathCchAddBackslash in that it can return a pointer to the new end of the string and report the number
	/// of unused characters remaining in the buffer.
	/// </para>
	/// <para>This function differs from PathAddBackslash in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para>
	/// <c>Note</c> This function, or <c>PathCchAddBackslashEx</c>, should be used in place of PathAddBackslash to prevent the
	/// possibility of a buffer overrun.
	/// </para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>
	/// A pointer to the path string. When this function returns successfully, the buffer contains the string with the appended
	/// backslash. This value should not be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <param name="ppszEnd">
	/// <para>
	/// A value that, when this function returns successfully, receives the address of a pointer to the terminating null character at the
	/// end of the string.
	/// </para>
	/// </param>
	/// <param name="pcchRemaining">
	/// <para>
	/// A pointer to a value that, when this function returns successfully, is set to the number of unused characters in the destination
	/// buffer, including the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// This function returns S_OK if the function was successful, S_FALSE if the path string already ends in a backslash, or an error
	/// code otherwise.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchaddbackslashex HRESULT PathCchAddBackslashEx( PWSTR
	// pszPath, SizeT cchPath, PWSTR *ppszEnd, SizeT *pcchRemaining );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "89adf45f-f16d-49d1-9e76-b57b73b4d4c3")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchAddBackslashEx([In, Out, SizeDef(nameof(cchPath))] LPWSTR pszPath, [Range(1, PATHCCH_MAX_CCH)] SizeT cchPath, out LPWSTR ppszEnd, out SizeT pcchRemaining);

	/// <summary>
	/// <para>Adds a file name extension to a path string.</para>
	/// <para>This function differs from PathAddExtension in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para><c>Note</c> This function should be used in place of PathAddExtension to prevent the possibility of a buffer overrun.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>
	/// A pointer to the path string. When this function returns successfully, the buffer contains the string with the appended
	/// extension. This value should not be <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> If the original string already has a file name extension present, no new extension will be added and the original
	/// string will be unchanged.
	/// </para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <param name="pszExt">
	/// <para>
	/// A pointer to the file name extension string. This string can be given either with or without a preceding period (".ext" or "ext").
	/// </para>
	/// </param>
	/// <returns>
	/// <para>This function returns an <c>HRESULT</c> code, including the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>
	/// The function succeeded. Note that this also includes the case of an empty extension, such as a period with no characters
	/// following it. In that case, the original string is returned unaltered.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// This value can be caused by several things, such as the pszPath param being set to NULL, the cchPath being set to 0 or a value
	/// greater than PATHCCH_MAX_CCH, or the extension string containing illegal characters or otherwise not being a valid extension.
	/// </term>
	/// </item>
	/// <item>
	/// <term>S_FALSE</term>
	/// <term>The original string already has an extension.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_E_FILENAME_TOO_LONG</term>
	/// <term>The buffer is too small to hold the returned string.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchaddextension HRESULT PathCchAddExtension( PWSTR
	// pszPath, SizeT cchPath, PCWSTR pszExt );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "c37b438b-39e7-4f24-b076-2401900dab71")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchAddExtension([In, Out, SizeDef(nameof(cchPath))] StringBuilder pszPath, [Range(1, PATHCCH_MAX_CCH)] SizeT cchPath, string pszExt);

	/// <summary>
	/// <para>Appends one path to the end of another.</para>
	/// <para>This function differs from PathCchAppendEx in that you are restricted to a final path of length MAX_PATH.</para>
	/// <para>This function differs from PathAppend in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para>
	/// <c>Note</c> This function, or PathCchAppendEx, should be used in place of PathAppend to prevent the possibility of a buffer overrun.
	/// </para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>
	/// A pointer to a buffer that, on entry, contains the original path. When this function returns successfully, the buffer contains
	/// the original path plus the appended path.
	/// </para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <param name="pszMore">
	/// <para>
	/// A pointer to the path to append to the end of the path pointed to by pszPath. UNC paths and paths beginning with the "\?"
	/// sequence are accepted and recognized as fully-qualified paths. These paths replace the string pointed to by pszPath instead of
	/// being appended to it.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> code, including the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>Either pszPath or pszMore is NULL, cchPath is 0, or cchPath is greater than PATHCCH_MAX_CCH.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_E_FILENAME_TOO_LONG</term>
	/// <term>The resulting string would exceed PATHCCH_MAX_CCH.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The function could not allocate a buffer of the neccessary size.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function inserts a backslash between the two strings, if one is not already present.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchappend HRESULT PathCchAppend( PWSTR pszPath, SizeT
	// cchPath, PCWSTR pszMore );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "b64884ad-15c7-495e-8037-34daf68f8cf7")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchAppend([In, Out, SizeDef(nameof(cchPath))] StringBuilder pszPath, [Range(1, MAX_PATH)] SizeT cchPath, string pszMore);

	/// <summary>
	/// <para>Appends one path to the end of another.</para>
	/// <para>This function differs from PathCchAppend in that it allows for a longer final path to be constructed.</para>
	/// <para>This function differs from PathAppend in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para>
	/// <c>Note</c> This function, or PathCchAppend, should be used in place of PathAppend to prevent the possibility of a buffer overrun.
	/// </para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>
	/// A pointer to a buffer that, on entry, contains the original path. When this function returns successfully, the buffer contains
	/// the original path plus the appended path.
	/// </para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <param name="pszMore">
	/// <para>
	/// A pointer the path to append to the end of the path pointed to by pszPath. UNC paths and paths that begin with the sequence \?\
	/// are accepted and recognized as fully-qualified paths. These paths replace the string pointed to by pszPath instead of being
	/// appended to it.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>One or more of the following flags:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PATHCCH_NONE 0x0000000</term>
	/// <term>Do not allow for the construction of \\?\ paths (ie, long paths) longer than MAX_PATH.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_ALLOW_LONG_PATHS 0x00000001</term>
	/// <term>Allow the building of \\?\ paths longer than MAX_PATH.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_FORCE_ENABLE_LONG_NAME_PROCESS 0x00000002</term>
	/// <term>
	/// Forces the API to treat the caller as long path enabled, independent of the PATHCCH_FORCE_DISABLE_LONG_NAME_PROCESS. Note This
	/// value is available starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_FORCE_DISABLE_LONG_NAME_PROCESS 0x00000004</term>
	/// <term>
	/// Forces the API to treat the caller as long path disabled, independent of the Note This value is available starting in Windows 10,
	/// version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_DO_NOT_NORMALIZE_SEGMENTS 0x00000008</term>
	/// <term>
	/// Disables the normalization of path segments that includes removing trailing dots and spaces. Note This value is available
	/// starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_ENSURE_IS_EXTENDED_LENGTH_PATH 0x00000010</term>
	/// <term>
	/// Converts the input path into the extended length DOS device path form (with the \\?\ prefix) Note This value is available
	/// starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> code, including the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>Either pszPath or pszMore is NULL, cchPath is 0, or cchPath is greater than PATHCCH_MAX_CCH.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_E_FILENAME_TOO_LONG</term>
	/// <term>The resulting string would exceed PATHCCH_MAX_CCH.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The function could not allocate a buffer of the neccessary size.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function inserts a backslash between the two strings, if one is not already present.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchappendex HRESULT PathCchAppendEx( PWSTR pszPath,
	// SizeT cchPath, PCWSTR pszMore, ULONG dwFlags );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "5421c666-1c8a-4ae8-baba-9e6f69c877df")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchAppendEx([In, Out] StringBuilder pszPath, [Range(1, PATHCCH_MAX_CCH)] SizeT cchPath, string pszMore, PATHCCH_OPTIONS dwFlags);

	/// <summary>
	/// <para>Converts a path string into a canonical form.</para>
	/// <para>This function differs from PathCchCanonicalizeEx in that you are restricted to a final path of length MAX_PATH.</para>
	/// <para>
	/// This function differs from PathAllocCanonicalize in that the caller must declare the size of the returned string, which is stored
	/// on the stack.
	/// </para>
	/// <para>This function differs from PathCanonicalize in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para>
	/// <c>Note</c> This function, PathCchCanonicalizeEx, or PathAllocCanonicalize should be used in place of PathCanonicalize to prevent
	/// the possibility of a buffer overrun.
	/// </para>
	/// </summary>
	/// <param name="pszPathOut">
	/// <para>A pointer to a buffer that, when this function returns successfully, receives the canonicalized path string.</para>
	/// </param>
	/// <param name="cchPathOut">
	/// <para>The size of the buffer pointed to by pszPathOut, in characters.</para>
	/// </param>
	/// <param name="pszPathIn">
	/// <para>
	/// A pointer to the original path string. If this value points to an empty string, or results in an empty string once the "." and
	/// ".." elements are removed, a single backslash is copied to the buffer pointed to by pszPathOut.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> code, including the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The cchPathOut value is greater than PATHCCH_MAX_CCH.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_E_FILENAME_TOO_LONG</term>
	/// <term>A path segment exceeds the standard path segment length limit of 256 characters.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The function could not allocate a buffer of the neccessary size.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function responds to the strings "." and ".." embedded in a path. The ".." string indicates to remove the immediately
	/// preceding path segment. The "." string indicates to skip over the next path segment. Note that the root segment of the path
	/// cannot be removed. If there are more ".." strings than there are path segments, the function returns S_OK and the buffer pointed
	/// to by pszPathOut contains a single backslash, "".
	/// </para>
	/// <para>
	/// All trailing periods are removed from the path, except when preceded by the "" wild card character. In that case, a single period
	/// is retained after the '' character, but all other trailing periods are removed.
	/// </para>
	/// <para>If the resulting path is a root drive ("x:"), a backslash is appended ("x:").</para>
	/// <para>The following examples show the effect of these strings.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Original string</term>
	/// <term>Canonicalized string</term>
	/// </listheader>
	/// <item>
	/// <term>C:\name_1\.\name_2\..\name_3</term>
	/// <term>C:\name_1\name_3</term>
	/// </item>
	/// <item>
	/// <term>C:\name_1\..\name_2\.\name_3</term>
	/// <term>C:\name_2\name_3</term>
	/// </item>
	/// <item>
	/// <term>C:\name_1\name_2\.\name_3\..\name_4</term>
	/// <term>C:\name_1\name_2\name_4</term>
	/// </item>
	/// <item>
	/// <term>C:\name_1\.\name_2\.\name_3\..\name_4\..</term>
	/// <term>C:\name_1\name_2</term>
	/// </item>
	/// <item>
	/// <term>C:\name_1\*...</term>
	/// <term>C:\name_1\*.</term>
	/// </item>
	/// <item>
	/// <term>C:\..</term>
	/// <term>C:\</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchcanonicalize HRESULT PathCchCanonicalize( PWSTR
	// pszPathOut, SizeT cchPathOut, PCWSTR pszPathIn );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "25ff08b2-5978-4d44-9877-ba4230ef7d12")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchCanonicalize([In, Out, SizeDef(nameof(cchPathOut))] StringBuilder pszPathOut, [Range(0, MAX_PATH)] SizeT cchPathOut, [MaxLength(MAX_PATH)] string pszPathIn);

	/// <summary>
	/// <para>Simplifies a path by removing navigation elements such as "." and ".." to produce a direct, well-formed path.</para>
	/// <para>This function differs from PathCchCanonicalize in that it allows for a longer final path to be constructed.</para>
	/// <para>
	/// This function differs from PathAllocCanonicalize in that the caller must declare the size of the returned string, which is stored
	/// on the stack.
	/// </para>
	/// <para>This function differs from PathCanonicalize in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para>
	/// <c>Note</c> This function, PathCchCanonicalize, or PathAllocCanonicalize should be used in place of PathCanonicalize to prevent
	/// the possibility of a buffer overrun.
	/// </para>
	/// </summary>
	/// <param name="pszPathOut">
	/// <para>A pointer to a buffer that, when this function returns successfully, receives the edited path string.</para>
	/// </param>
	/// <param name="cchPathOut">
	/// <para>The size of the buffer pointed to by pszPathOut, in characters.</para>
	/// </param>
	/// <param name="pszPathIn">
	/// <para>
	/// A pointer to the original path string. If this value is <c>NULL</c>, points to an empty string, or results in an empty string
	/// once the "." and ".." elements are removed, a single backslash is copied to the buffer pointed to by pszPathOut.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>One or more of the following flags:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PATHCCH_NONE 0x0000000</term>
	/// <term>Do not allow for the construction of \\?\ paths (ie, long paths) longer than MAX_PATH.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_ALLOW_LONG_PATHS 0x00000001</term>
	/// <term>
	/// Allow the building of \\?\ paths longer than MAX_PATH. Note that cchPathOut must be greater than MAX_PATH. If it is not, this
	/// flag is ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_FORCE_ENABLE_LONG_NAME_PROCESS 0x00000002</term>
	/// <term>
	/// Forces the API to treat the caller as long path enabled, independent of the PATHCCH_FORCE_DISABLE_LONG_NAME_PROCESS. Note This
	/// value is available starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_FORCE_DISABLE_LONG_NAME_PROCESS 0x00000004</term>
	/// <term>
	/// Forces the API to treat the caller as long path disabled, independent of the Note This value is available starting in Windows 10,
	/// version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_DO_NOT_NORMALIZE_SEGMENTS 0x00000008</term>
	/// <term>
	/// Disables the normalization of path segments that includes removing trailing dots and spaces. Note This value is available
	/// starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_ENSURE_IS_EXTENDED_LENGTH_PATH 0x00000010</term>
	/// <term>
	/// Converts the input path into the extended length DOS device path form (with the \\?\ prefix) Note This value is available
	/// starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_ENSURE_TRAILING_SLASH 0x00000020</term>
	/// <term>
	/// When combining or normalizing a path, ensure there is a trailing backslash. Note This value is available starting in Windows 10,
	/// version 1703.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> code, including but not limited to the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The cchPathOut value is greater than PATHCCH_MAX_CCH.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_E_FILENAME_TOO_LONG</term>
	/// <term>
	/// A path segment has more than PATHCCH_MAX_CCH characters, or, if the PATHCCH_ALLOW_LONG_PATHS flag is not set, exceeds the
	/// standard path segment length limit of 256 characters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The function could not allocate a buffer of the neccessary size.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function responds to the strings "." and ".." embedded in a path. The ".." string indicates to remove the immediately
	/// preceding path segment. The "." string indicates to skip over the next path segment. Note that the root segment of the path
	/// cannot be removed. If there are more ".." strings than there are path segments, the function returns S_OK and the buffer pointed
	/// to by pszPathOut contains a single backslash, "".
	/// </para>
	/// <para>
	/// All trailing periods are removed from the path, except when preceded by the "" wild card character. In that case, a single period
	/// is retained after the '' character, but all other trailing periods are removed.
	/// </para>
	/// <para>If the resulting path is a root drive ("x:"), a backslash is appended ("x:").</para>
	/// <para>The following examples show the effect of these strings.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Original string</term>
	/// <term>Canonicalized string</term>
	/// </listheader>
	/// <item>
	/// <term>C:\name_1\.\name_2\..\name_3</term>
	/// <term>C:\name_1\name_3</term>
	/// </item>
	/// <item>
	/// <term>C:\name_1\..\name_2\.\name_3</term>
	/// <term>C:\name_2\name_3</term>
	/// </item>
	/// <item>
	/// <term>C:\name_1\name_2\.\name_3\..\name_4</term>
	/// <term>C:\name_1\name_2\name_4</term>
	/// </item>
	/// <item>
	/// <term>C:\name_1\.\name_2\.\name_3\..\name_4\..</term>
	/// <term>C:\name_1\name_2</term>
	/// </item>
	/// <item>
	/// <term>C:\name_1\*...</term>
	/// <term>C:\name_1\*.</term>
	/// </item>
	/// <item>
	/// <term>C:\..</term>
	/// <term>C:\</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchcanonicalizeex HRESULT PathCchCanonicalizeEx( PWSTR
	// pszPathOut, SizeT cchPathOut, PCWSTR pszPathIn, ULONG dwFlags );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "fd7b8ce0-3c67-48fb-8e7e-521a6b438676")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchCanonicalizeEx([In, Out, SizeDef(nameof(cchPathOut))] StringBuilder pszPathOut, [Range(1, PATHCCH_MAX_CCH)] SizeT cchPathOut,
		[MaxLength((int)PATHCCH_MAX_CCH)] string pszPathIn, PATHCCH_OPTIONS dwFlags);

	/// <summary>
	/// <para>
	/// Combines two path fragments into a single path. This function also canonicalizes any relative path elements, removing "." and
	/// ".." elements to simplify the final path.
	/// </para>
	/// <para>This function differs from PathCchCombineEx in that you are restricted to a final path of length MAX_PATH.</para>
	/// <para>
	/// This function differs from PathAllocCombine in that the caller must declare the size of the returned string, which is stored on
	/// the stack.
	/// </para>
	/// <para>This function differs from PathCombine in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para>
	/// <c>Note</c> This function, PathCchCombineEx, or PathAllocCombine should be used in place of PathCombine to prevent the
	/// possibility of a buffer overrun.
	/// </para>
	/// </summary>
	/// <param name="pszPathOut">
	/// <para>
	/// A pointer to a buffer that, when this function returns successfully, receives the combined path string. This parameter can point
	/// to the same buffer as pszPathIn or pszMore.
	/// </para>
	/// </param>
	/// <param name="cchPathOut">
	/// <para>The size of the buffer pointed to by pszPathOut, in characters.</para>
	/// </param>
	/// <param name="pszPathIn">
	/// <para>A pointer to the first path string. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pszMore">
	/// <para>
	/// A pointer to the second path string. If this path begins with a single backslash, it is combined with only the root of the path
	/// pointed to by pszPathIn. If this path is fully qualfied, it is copied directly to the output buffer without being combined with
	/// the other path. This value can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>This function returns an <c>HRESULT</c> code, including the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>
	/// The function succeeded. Note that this also includes the case of an empty extension, such as a period with no characters
	/// following it. In that case, the original string is returned unaltered.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// This value can be caused by several things, such as the pszPathOut param being set to NULL, or the cchPathOut value being set to
	/// 0 or a value greater than PATHCCH_MAX_CCH.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The function could not allocate enough memory to perform the operation.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_E_FILENAME_TOO_LONG</term>
	/// <term>The size of one or both of the original paths exceeded PATHCCH_MAX_CCH.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If both pszPathIn and pszMore are <c>NULL</c> or point to empty strings, a single backslash is copied to the buffer pointed to by pszPathOut.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchcombine HRESULT PathCchCombine( PWSTR pszPathOut,
	// SizeT cchPathOut, PCWSTR pszPathIn, PCWSTR pszMore );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "506a4165-f572-4521-958f-56a0296f9c05")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchCombine([In, Out, SizeDef(nameof(cchPathOut))] StringBuilder pszPathOut, [Range(0, MAX_PATH)] SizeT cchPathOut,
		[MaxLength(MAX_PATH)] string pszPathIn, [Optional] string? pszMore);

	/// <summary>
	/// <para>
	/// Combines two path fragments into a single path. This function also canonicalizes any relative path elements, removing "." and
	/// ".." elements to simplify the final path.
	/// </para>
	/// <para>This function differs from PathCchCombine in that it allows for a longer final path to be constructed.</para>
	/// <para>
	/// This function differs from PathAllocCombine in that the caller must declare the size of the returned string, which is stored on
	/// the stack.
	/// </para>
	/// <para>This function differs from PathCombine in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para>
	/// <c>Note</c> This function, PathCchCombine, or PathAllocCombine should be used in place of PathCombine to prevent the possibility
	/// of a buffer overrun.
	/// </para>
	/// </summary>
	/// <param name="pszPathOut">
	/// <para>
	/// A pointer to a buffer that, when this function returns successfully, receives the combined path string. This parameter can point
	/// to the same buffer as pszPathIn or pszMore.
	/// </para>
	/// </param>
	/// <param name="cchPathOut">
	/// <para>The size of the buffer pointed to by pszPathOut, in characters.</para>
	/// </param>
	/// <param name="pszPathIn">
	/// <para>A pointer to the first path string. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pszMore">
	/// <para>
	/// A pointer to the second path string. If this path begins with a single backslash, it is combined with only the root of the path
	/// pointed to by pszPathIn. If this path is fully qualfied, it is copied directly to the output buffer without being combined with
	/// the other path. This value can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>One or more of the following flags:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PATHCCH_NONE 0x0000000</term>
	/// <term>Do not allow for the construction of \\?\ paths (ie, long paths) longer than MAX_PATH.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_ALLOW_LONG_PATHS 0x00000001</term>
	/// <term>
	/// Allow the construction of \\?\ paths longer than MAX_PATH. Note that cchPathOut must be greater than MAX_PATH. Note that
	/// cchPathOut must be greater than MAX_PATH. If it is not, this flag is ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_FORCE_ENABLE_LONG_NAME_PROCESS 0x00000002</term>
	/// <term>
	/// Forces the API to treat the caller as long path enabled, independent of the PATHCCH_FORCE_DISABLE_LONG_NAME_PROCESS. Note This
	/// value is available starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_FORCE_DISABLE_LONG_NAME_PROCESS 0x00000004</term>
	/// <term>
	/// Forces the API to treat the caller as long path disabled, independent of the Note This value is available starting in Windows 10,
	/// version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_DO_NOT_NORMALIZE_SEGMENTS 0x00000008</term>
	/// <term>
	/// Disables the normalization of path segments that includes removing trailing dots and spaces. Note This value is available
	/// starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_ENSURE_IS_EXTENDED_LENGTH_PATH 0x00000010</term>
	/// <term>
	/// Converts the input path into the extended length DOS device path form (with the \\?\ prefix) Note This value is available
	/// starting in Windows 10, version 1703.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function returns an <c>HRESULT</c> code, including the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>
	/// The function succeeded. Note that this also includes the case of an empty extension, such as a period with no characters
	/// following it. In that case, the original string is returned unaltered.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// This value can be caused by several things, such as the pszPathOut param being set to NULL, or the cchPathOut value being set to
	/// 0 or a value greater than PATHCCH_MAX_CCH.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The function could not allocate enough memory to perform the operation.</term>
	/// </item>
	/// <item>
	/// <term>PATHCCH_E_FILENAME_TOO_LONG</term>
	/// <term>The size of one or both of the original paths exceeded PATHCCH_MAX_CCH.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If both pszPathIn and pszMore are <c>NULL</c> or point to empty strings, a single backslash is copied to the buffer pointed to by pszPathOut.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchcombineex HRESULT PathCchCombineEx( PWSTR
	// pszPathOut, SizeT cchPathOut, PCWSTR pszPathIn, PCWSTR pszMore, ULONG dwFlags );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "798c2e49-04a5-4270-b584-41faf1519e4b")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchCombineEx([In, Out, SizeDef(nameof(cchPathOut))] StringBuilder pszPathOut, [Range(0, PATHCCH_MAX_CCH)] SizeT cchPathOut,
		[MaxLength((int)PATHCCH_MAX_CCH)] string pszPathIn, [Optional] string? pszMore, PATHCCH_OPTIONS dwFlags);

	/// <summary>
	/// <para>
	/// Searches a path to find its file name extension, such as ".exe" or ".ini". This function does not search for a specific
	/// extension; it searches for the presence of any extension.
	/// </para>
	/// <para>This function differs from PathFindExtension in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para><c>Note</c> This function should be used in place of PathFindExtension to prevent the possibility of a buffer overrun.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>A pointer to the path to search.</para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <param name="ppszExt">
	/// <para>
	/// The address of a pointer that, when this function returns successfully, points to the "." character that precedes the extension
	/// within pszPath. If no extension is found, it points to the string's terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchfindextension HRESULT PathCchFindExtension( PCWSTR
	// pszPath, SizeT cchPath, PCWSTR *ppszExt );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "dac6cf02-7b53-449c-b788-4a7b6d1622ed")]
	public static extern HRESULT PathCchFindExtension(string pszPath, SizeT cchPath, out LPWSTR ppszExt);

	/// <summary>
	/// <para>
	/// Searches a path to find its file name extension, such as ".exe" or ".ini". This function does not search for a specific
	/// extension; it searches for the presence of any extension.
	/// </para>
	/// <para>This function differs from PathFindExtension in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para><c>Note</c> This function should be used in place of PathFindExtension to prevent the possibility of a buffer overrun.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>A pointer to the path to search.</para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <param name="ppszExt">
	/// <para>
	/// The address of a pointer that, when this function returns successfully, points to the "." character that precedes the extension
	/// within pszPath. If no extension is found, it points to the string's terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchfindextension HRESULT PathCchFindExtension( PCWSTR
	// pszPath, SizeT cchPath, PCWSTR *ppszExt );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "dac6cf02-7b53-449c-b788-4a7b6d1622ed")]
	public static extern HRESULT PathCchFindExtension([In] LPWSTR pszPath, SizeT cchPath, out LPWSTR ppszExt);

	/// <summary>
	/// <para>Determines whether a path string refers to the root of a volume.</para>
	/// <para>This function differs from PathIsRoot in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>A pointer to the path string.</para>
	/// </param>
	/// <returns>
	/// <para>Returns <c>TRUE</c> if the specified path is a root, or <c>FALSE</c> otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>The following table shows the <c>PathCchIsRoot</c> return value for various paths.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Path</term>
	/// <term>PathCchIsRoot</term>
	/// </listheader>
	/// <item>
	/// <term>"c:\"</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>"c:"</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>"c:\path1"</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>"\path1"</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>"path1"</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>"\\path1\path2"</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>"\\path1\path2\"</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>"\\path1\path2\path3"</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>"\\path1"</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>"\\path1\"</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>"\\"</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>"\\?\UNC\"</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>"\\?\UNC\path1\path2"</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>"\\?\UNC\path1\path2\"</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>"\\?\UNC\path1\path2\path3"</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>"\\?\UNC\path1"</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>"\\?\UNC\path1\"</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>"\\?\c:\"</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>"\\?\c:"</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>"\\?\c:\path1"</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>"\\?\Volume{guid}\"</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>"\\?\Volume{guid}"</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>"\\?\Volume{guid}\path1"</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>""</term>
	/// <term>FALSE</term>
	/// </item>
	/// </list>
	/// <para>
	/// This function returns <c>TRUE</c> for paths such as "", "X:" or "\server&lt;i&gt;share". Paths such as "..\path2" or "\server"
	/// return <c>FALSE</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchisroot BOOL PathCchIsRoot( PCWSTR pszPath );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "b9770030-b298-47f8-98a7-3ce9b4d44dd1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PathCchIsRoot(string pszPath);

	/// <summary>
	/// <para>Removes the trailing backslash from the end of a path string.</para>
	/// <para>This function differs from PathRemoveBackslash in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para>
	/// <c>Note</c> This function, or PathCchRemoveBackslashEx, should be used in place of PathRemoveBackslash to prevent the possibility
	/// of a buffer overrun.
	/// </para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>
	/// A pointer to the path string. When this function returns successfully, the string contains the path with any trailing backslash
	/// removed. If no trailing backslash was found, the string is unchanged.
	/// </para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// This function returns S_OK if the function was successful, S_FALSE if the string was a root path or if no backslash was found, or
	/// an error code otherwise.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>This function will not remove the backslash from a root path string, such as "C:".</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchremovebackslash HRESULT PathCchRemoveBackslash(
	// PWSTR pszPath, SizeT cchPath );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "61afc20e-ee6c-46ad-a058-64c57de41ba4")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchRemoveBackslash([In, Out] StringBuilder pszPath, SizeT cchPath);

	/// <summary>
	/// <para>Removes the trailing backslash from the end of a path string.</para>
	/// <para>
	/// This function differs from PathCchRemoveBackslash in that it can return a pointer to the new end of the string and report the
	/// number of unused characters remaining in the buffer.
	/// </para>
	/// <para>This function differs from PathRemoveBackslash in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para>
	/// <c>Note</c> This function, or PathCchRemoveBackslash, should be used in place of PathRemoveBackslash to prevent the possibility
	/// of a buffer overrun.
	/// </para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>
	/// A pointer to the path string. When this function returns successfully, the string contains the path with any trailing backslash
	/// removed. If no trailing backslash was found, the string is unchanged.
	/// </para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <param name="ppszEnd">
	/// <para>
	/// A value that, when this function returns successfully, receives the address of a pointer to end of the new string. If the string
	/// is a root path such as "C:", the pointer points to the backslash; otherwise the pointer points to the string's terminating null character.
	/// </para>
	/// </param>
	/// <param name="pcchRemaining">
	/// <para>
	/// A pointer to a value that, when this function returns successfully, receives the number of unused characters in the destination
	/// buffer, including the terminating null character. If the string is a root path such as "C:", this count includes the backslash in
	/// that string.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// This function returns S_OK if the function was successful, S_FALSE if the string was a root path or if no backslash was found, or
	/// an error code otherwise.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>This function will not remove the backslash from a root path string, such as "C:".</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchremovebackslashex HRESULT PathCchRemoveBackslashEx(
	// PWSTR pszPath, SizeT cchPath, PWSTR *ppszEnd, SizeT *pcchRemaining );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "250c2faa-94bb-42c1-97d4-37f8f59dbde6")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchRemoveBackslashEx([In, Out, SizeDef(nameof(cchPath))] StringBuilder pszPath,
		[Range(0, PATHCCH_MAX_CCH)] SizeT cchPath, out LPWSTR ppszEnd, out SizeT pcchRemaining);

	/// <summary>
	/// <para>Removes the trailing backslash from the end of a path string.</para>
	/// <para>
	/// This function differs from PathCchRemoveBackslash in that it can return a pointer to the new end of the string and report the
	/// number of unused characters remaining in the buffer.
	/// </para>
	/// <para>This function differs from PathRemoveBackslash in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para>
	/// <c>Note</c> This function, or PathCchRemoveBackslash, should be used in place of PathRemoveBackslash to prevent the possibility
	/// of a buffer overrun.
	/// </para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>
	/// A pointer to the path string. When this function returns successfully, the string contains the path with any trailing backslash
	/// removed. If no trailing backslash was found, the string is unchanged.
	/// </para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <param name="ppszEnd">
	/// <para>
	/// A value that, when this function returns successfully, receives the address of a pointer to end of the new string. If the string
	/// is a root path such as "C:", the pointer points to the backslash; otherwise the pointer points to the string's terminating null character.
	/// </para>
	/// </param>
	/// <param name="pcchRemaining">
	/// <para>
	/// A pointer to a value that, when this function returns successfully, receives the number of unused characters in the destination
	/// buffer, including the terminating null character. If the string is a root path such as "C:", this count includes the backslash in
	/// that string.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// This function returns S_OK if the function was successful, S_FALSE if the string was a root path or if no backslash was found, or
	/// an error code otherwise.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>This function will not remove the backslash from a root path string, such as "C:".</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchremovebackslashex HRESULT PathCchRemoveBackslashEx(
	// PWSTR pszPath, SizeT cchPath, PWSTR *ppszEnd, SizeT *pcchRemaining );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "250c2faa-94bb-42c1-97d4-37f8f59dbde6")]
	public static extern HRESULT PathCchRemoveBackslashEx([In, Out, SizeDef(nameof(cchPath))] LPWSTR pszPath,
		[Range(0, PATHCCH_MAX_CCH)] SizeT cchPath, out LPWSTR ppszEnd, out SizeT pcchRemaining);

	/// <summary>
	/// <para>Removes the file name extension from a path, if one is present.</para>
	/// <para>This function differs from PathRemoveExtension in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para><c>Note</c> This function, should be used in place of PathRemoveExtension to prevent the possibility of a buffer overrun.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>
	/// A pointer to the path string. When this function returns successfully, the string contains the path with any extension removed.
	/// If no extension was found, the string is unchanged.
	/// </para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <returns>
	/// <para>This function returns S_OK if the function was successful, S_FALSE if no extension was found, or an error code otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchremoveextension HRESULT PathCchRemoveExtension(
	// PWSTR pszPath, SizeT cchPath );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "9adfb054-6d62-41bb-9036-0bf670ea24b2")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchRemoveExtension([In, Out, SizeDef(nameof(cchPath))] StringBuilder pszPath, [Range(0, PATHCCH_MAX_CCH)] SizeT cchPath);

	/// <summary>
	/// <para>
	/// Removes the last element in a path string, whether that element is a file name or a directory name. The element's leading
	/// backslash is also removed.
	/// </para>
	/// <para>This function differs from PathRemoveFileSpec in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para><c>Note</c> This function should be used in place of PathRemoveFileSpec to prevent the possibility of a buffer overrun.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>
	/// A pointer to the fully-qualified path string. When this function returns successfully, the string will have had its last element
	/// and its leading backslash removed. This function does not affect root paths such as "C:". In the case of a root path, the path
	/// string is returned unaltered. If a path string ends with a trailing backslash, only that backslash is removed.
	/// </para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <returns>
	/// <para>This function returns S_OK if the function was successful, S_FALSE if there was nothing to remove, or an error code otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>The following table shows the effect of this function on a selection of path strings.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Original String</term>
	/// <term>Returned String</term>
	/// </listheader>
	/// <item>
	/// <term>"C:\path1"</term>
	/// <term>"C:\"</term>
	/// </item>
	/// <item>
	/// <term>"C:\path1\path2"</term>
	/// <term>"C:\path1"</term>
	/// </item>
	/// <item>
	/// <term>"C:\path1\"</term>
	/// <term>"C:\path1"</term>
	/// </item>
	/// <item>
	/// <term>"\\path1\path2\path3"</term>
	/// <term>"\\path1\path2"</term>
	/// </item>
	/// <item>
	/// <term>"\path1"</term>
	/// <term>"\"</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchremovefilespec HRESULT PathCchRemoveFileSpec( PWSTR
	// pszPath, SizeT cchPath );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "c37aeddc-ed24-4828-b92b-bce0e6384726")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchRemoveFileSpec([In, Out, SizeDef(nameof(cchPath))] StringBuilder pszPath, [Range(0, PATHCCH_MAX_CCH)] SizeT cchPath);

	/// <summary>
	/// <para>
	/// Replaces a file name's extension at the end of a path string with a new extension. If the path string does not end with an
	/// extension, the new extension is added.
	/// </para>
	/// <para>This function differs from PathRenameExtension in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para><c>Note</c> This function should be used in place of PathRenameExtension to prevent the possibility of a buffer overrun.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>
	/// A pointer to the path string. When this function returns successfully, this value points to the same string, but with the renamed
	/// or added extension.
	/// </para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <param name="pszExt">
	/// <para>
	/// A pointer to the new extension string. The leading '.' character is optional. In the case of an empty string (""), any existing
	/// extension in the path string is removed.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchrenameextension HRESULT PathCchRenameExtension(
	// PWSTR pszPath, SizeT cchPath, PCWSTR pszExt );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "79cd9499-03b7-4482-abd3-a42edd1b2b67")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchRenameExtension([In, Out, SizeDef(nameof(cchPath))] StringBuilder pszPath, [Range(0, PATHCCH_MAX_CCH)] SizeT cchPath, string pszExt);

	/// <summary>
	/// <para>
	/// Retrieves a pointer to the first character in a path following the drive letter or Universal Naming Convention (UNC) server/share
	/// path elements.
	/// </para>
	/// <para>This function differs from PathSkipRoot in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>A pointer to the path string.</para>
	/// </param>
	/// <param name="ppszRootEnd">
	/// <para>
	/// The address of a pointer that, when this function returns successfully, points to the first character in a path following the
	/// drive letter or UNC server/share path elements. If the path consists of only a root, this value will point to the string's
	/// terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchskiproot HRESULT PathCchSkipRoot( PCWSTR pszPath,
	// PCWSTR *ppszRootEnd );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "187bc49e-c5ae-42b8-acbd-a765f871d73b")]
	public static extern HRESULT PathCchSkipRoot(string pszPath, out LPWSTR ppszRootEnd);

	/// <summary>
	/// <para>
	/// Retrieves a pointer to the first character in a path following the drive letter or Universal Naming Convention (UNC) server/share
	/// path elements.
	/// </para>
	/// <para>This function differs from PathSkipRoot in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>A pointer to the path string.</para>
	/// </param>
	/// <param name="ppszRootEnd">
	/// <para>
	/// The address of a pointer that, when this function returns successfully, points to the first character in a path following the
	/// drive letter or UNC server/share path elements. If the path consists of only a root, this value will point to the string's
	/// terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchskiproot HRESULT PathCchSkipRoot( PCWSTR pszPath,
	// PCWSTR *ppszRootEnd );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "187bc49e-c5ae-42b8-acbd-a765f871d73b")]
	public static extern HRESULT PathCchSkipRoot([In] LPWSTR pszPath, out LPWSTR ppszRootEnd);

	/// <summary>
	/// <para>Removes the "\?" prefix, if present, from a file path.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>
	/// A pointer to the path string. When this function returns successfully, the same path string will have had the prefix removed, if
	/// the prefix was present. If no prefix was present, the string will be unchanged.
	/// </para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// This function returns S_OK if the prefix was removed, S_FALSE if the path did not have a prefix to remove, or an HRESULT failure code.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchstripprefix HRESULT PathCchStripPrefix( PWSTR
	// pszPath, SizeT cchPath );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "2e50b23e-2725-4200-bd5e-845ff3458026")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchStripPrefix([In, Out, SizeDef(nameof(cchPath))] StringBuilder pszPath, [Range(0, PATHCCH_MAX_CCH)] SizeT cchPath);

	/// <summary>
	/// <para>Removes all file and directory elements in a path except for the root information.</para>
	/// <para>This function differs from PathStripToRoot in that it accepts paths with "\", "\?" and "\?\UNC" prefixes.</para>
	/// <para><c>Note</c> This function should be used in place of PathStripToRoot to prevent the possibility of a buffer overrun.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>
	/// A pointer to the path string. When this function returns successfully, this string contains only the root information taken from
	/// that path.
	/// </para>
	/// </param>
	/// <param name="cchPath">
	/// <para>The size of the buffer pointed to by pszPath, in characters.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// This function returns S_OK if the path was truncated, S_FALSE if the path was already just a root, or an HRESULT failure code.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Some examples of the effect of this function:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Initial string</term>
	/// <term>Final string</term>
	/// </listheader>
	/// <item>
	/// <term>"C:\path1\path2\file"</term>
	/// <term>"C:\"</term>
	/// </item>
	/// <item>
	/// <term>"\\path1\path2\path3"</term>
	/// <term>"\\path1\path2"</term>
	/// </item>
	/// <item>
	/// <term>"\path1"</term>
	/// <term>"\"</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathcchstriptoroot HRESULT PathCchStripToRoot( PWSTR
	// pszPath, SizeT cchPath );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "e0539478-8c64-4445-ab99-22f1df70afe8")]
	[SuppressAutoGen]
	public static extern HRESULT PathCchStripToRoot([In, Out, SizeDef(nameof(cchPath))] StringBuilder pszPath, [Range(0, PATHCCH_MAX_CCH)] SizeT cchPath);

	/// <summary>
	/// <para>Determines if a path string is a valid Universal Naming Convention (UNC) path, as opposed to a path based on a drive letter.</para>
	/// <para>This function differs from PathIsUNC in that it also allows you to extract the name of the server from the path.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>A pointer to the path string.</para>
	/// </param>
	/// <param name="ppszServer">
	/// <para>
	/// A pointer to a string that, when this function returns successfully, receives the server portion of the UNC path. This value can
	/// be <c>NULL</c> if you don't need this information.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns <c>TRUE</c> if the string is a valid UNC path; otherwise, <c>FALSE</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathisuncex BOOL PathIsUNCEx( PCWSTR pszPath, PCWSTR
	// *ppszServer );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "3b2a4158-63ec-49eb-a031-7493d02f2caa")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PathIsUNCEx(string pszPath, out LPWSTR ppszServer);

	/// <summary>
	/// <para>Determines if a path string is a valid Universal Naming Convention (UNC) path, as opposed to a path based on a drive letter.</para>
	/// <para>This function differs from PathIsUNC in that it also allows you to extract the name of the server from the path.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>A pointer to the path string.</para>
	/// </param>
	/// <param name="ppszServer">
	/// <para>
	/// A pointer to a string that, when this function returns successfully, receives the server portion of the UNC path. This value can
	/// be <c>NULL</c> if you don't need this information.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns <c>TRUE</c> if the string is a valid UNC path; otherwise, <c>FALSE</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/pathcch/nf-pathcch-pathisuncex BOOL PathIsUNCEx( PCWSTR pszPath, PCWSTR
	// *ppszServer );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("pathcch.h", MSDNShortId = "3b2a4158-63ec-49eb-a031-7493d02f2caa")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PathIsUNCEx([In] LPWSTR pszPath, out LPWSTR ppszServer);
}