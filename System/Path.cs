using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.ShlwApi;

namespace Vanara.IO
{
	/// <summary>
	/// Performs operations on String instances that contain file or directory path information. These operations are performed in a cross-platform manner.
	/// </summary>
	public static class PathEx
	{
		[Flags]
		public enum PathCharType : uint
		{
			/// <summary>The character is not valid in a path.</summary>
			Invalid = 0x0000,

			/// <summary>The character is valid in a long file name.</summary>
			LongFileName = 0x0001,

			/// <summary>The character is valid in a short (8.3) file name.</summary>
			ShortFileName = 0x0002,

			/// <summary>The character is a wildcard character.</summary>
			Wildcard = 0x0004,

			/// <summary>The character is a path separator.</summary>
			Separator = 0x0008,
		}

		/// <summary>
		/// Adds a backslash to the end of a string to create the correct syntax for a path. If the source path already has a trailing
		/// backslash, no backslash will be added.
		/// </summary>
		/// <param name="pszPath">The path string. This value should not be <see langword="null"/>.</param>
		/// <returns>The path string with the appended backslash.</returns>
		public static string AddBackslash(string pszPath) => SBAllocCallRet((s, sz) => PathCchAddBackslash(s, sz), pszPath, err: ThrowIfNotOkOrFalse);

		/// <summary>
		/// Adds a file name extension to a path string.
		/// </summary>
		/// <param name="path">The path of the file. This value should not be <see langword="null"/>.</param>
		/// <param name="ext">The extension to add. This string can be given either with or without a preceding period (".ext" or "ext").</param>
		/// <returns>The string with the appended extension.</returns>
		public static string AddExtension(string path, string ext) => SBAllocCallRet((s, sz) => PathCchAddExtension(s, sz, ext), path, err: ThrowIfNotOkOrFalse);

		/// <summary>
		/// Converts a path string into a canonical form.
		/// </summary>
		/// <param name="path">The file or directory to canonicalize.</param>
		/// <returns>The canonicalized path string.</returns>
		public static string Canonicalize(string path) { PathAllocCanonicalize(path, PATHCCH_OPTIONS.PATHCCH_ALLOW_LONG_PATHS, out var s).ThrowIfFailed(); return s; }

		/// <summary>Truncates a path to fit within a certain number of characters by replacing path components with ellipses.</summary>
		/// <param name="path">The file or directory to compact.</param>
		/// <param name="maxChars">The maximum number of characters to be contained in the new string.</param>
		/// <returns>The altered, compacted path string.</returns>
		public static string Compact(string path, int maxChars) => SBAllocCallRet((s, sz) => PathCompactPathEx(s, path, (uint)maxChars + 1));

#if (NET20 || NET35 || NET40 || NET45)
		/// <summary>
		/// Truncates a file path to fit within a given pixel width by replacing path components with ellipses.
		/// </summary>
		/// <param name="path">The file or directory to compact.</param>
		/// <param name="pixelWidth">The width, in pixels, in which the string must fit.</param>
		/// <param name="dc">A device context used for font metrics. This value can be <see langword="null"/>.</param>
		/// <returns>The modified string.</returns>
		public static string Compact(string path, int pixelWidth, System.Drawing.IDeviceContext dc) => SBAllocCallRet((s, sz) => PathCompactPath(dc?.GetHdc() ?? default, s, (uint)pixelWidth), path, (uint)(path?.Length + 1 ?? MAX_PATH));
#endif

		/// <summary>Converts a file URL to a Microsoft MS-DOS path.</summary>
		/// <param name="url">The URL.</param>
		/// <returns>The resulting MS-DOS path.</returns>
		public static string CreateFromUrl(string url) => SBAllocCallRet((s, sz) => PathCreateFromUrl(url, s, ref sz));

		/// <summary>Searches for a file in a list of directories.</summary>
		/// <param name="fileName">The file name for which to search.</param>
		/// <param name="searchDirectories">
		/// An optional array of directories to be searched first. This value can be <see langword="null"/>. If no directories are specified,
		/// it attempts to find the file by searching standard directories such as System32 and the directories specified in the PATH
		/// environment variable.
		/// </param>
		/// <param name="foundFilePath">If the file is found, this variable holds the fully qualified path name of the found file.</param>
		/// <returns>Returns <see langword="true"/> if found, or <see langword="false"/> otherwise.</returns>
		public static bool FileExistsOnPath(string fileName, IEnumerable<string> searchDirectories, out string foundFilePath)
		{
			var sb = new StringBuilder(fileName, MAX_PATH);
			string[] dirs = searchDirectories?.ToArray();
			if (dirs != null)
			{
				Array.Resize(ref dirs, dirs.Length + 1);
				dirs[dirs.Length - 1] = null;
			}
			foundFilePath = PathFindOnPath(sb, dirs) ? sb.ToString() : null;
			return foundFilePath != null;
		}

		/// <summary>Determines the type of character in relation to a path string.</summary>
		/// <param name="ch">The character for which to determine the type.</param>
		/// <returns>The type of character.</returns>
		public static PathCharType GetCharType(char ch) => (PathCharType)PathGetCharType(ch);

		/// <summary>Searches a path for a drive letter within the range of 'A' to 'Z' and returns the corresponding drive number.</summary>
		/// <param name="path">The file or directory to assess.</param>
		/// <returns>Returns 0 through 25 (corresponding to 'A' through 'Z') if the path has a drive letter, or -1 otherwise.</returns>
		public static int GetDriveNumber(string path) => PathGetDriveNumber(path);

		/// <summary>Removes the file name extension from a path, if one is present.</summary>
		/// <param name="path">The path string to edit.</param>
		/// <returns>The path with any extension removed. If no extension was found, the string is unchanged.</returns>
		public static string GetPathWithoutExtension(string path) => SBAllocCallRet((s, sz) => PathCchRemoveExtension(s, sz), path, err: ThrowIfNotOkOrFalse);

		/// <summary>
		/// Removes the last element in a path string, whether that element is a file name or a directory name. The element's leading
		/// backslash is also removed.
		/// </summary>
		/// <param name="path">The path string to edit.</param>
		/// <returns>
		/// The path with its last element and its leading backslash removed. This function does not affect root paths such as "C:". In the
		/// case of a root path, the path string is returned unaltered. If a path string ends with a trailing backslash, only that backslash
		/// is removed.
		/// </returns>
		public static string GetPathWithoutLastElement(string path) => SBAllocCallRet((s, sz) => PathCchRemoveFileSpec(s, sz), path, err: ThrowIfNotOkOrFalse);

		/// <summary>
		/// Gets the string following the drive letter or Universal Naming Convention (UNC) server/share path elements in a path.
		/// </summary>
		/// <param name="path">The path string.</param>
		/// <returns>
		/// The string following the drive letter or UNC server/share path elements. If the path consists of only a root, this value will be
		/// <see cref="string.Empty"/>.
		/// </returns>
		public static string GetPathWithoutRoot(string path)
		{
			PathCchSkipRoot(path, out var ptr).ThrowIfFailed();
			return StringHelper.GetString(ptr, System.Runtime.InteropServices.CharSet.Unicode);
		}

		/// <summary>Gets the path without the trailing backslash from the end of a path string.</summary>
		/// <param name="path">The path string.</param>
		/// <returns>
		/// The path with any trailing backslash removed. If no trailing backslash was found, the string is the same as <paramref name="path"/>.
		/// </returns>
		public static string GetPathWithoutTrailingBackslash(string path) => SBAllocCallRet((s, sz) => PathCchRemoveBackslash(s, sz), path, (uint)path.Length + 1, ThrowIfNotOkOrFalse);

		/// <summary>Gets a relative path from one file or folder to another.</summary>
		/// <param name="fromPath">The path that defines the start of the relative path.</param>
		/// <param name="fromIsDir">If <see langword="true"/>, assume that <paramref name="fromPath"/> is a directory.</param>
		/// <param name="toPath">The path that defines the endpoint of the relative path.</param>
		/// <param name="toIsDir">If <see langword="true"/>, assume that <paramref name="toPath"/> is a directory.</param>
		/// <returns>The relative path of <paramref name="toPath"/> from <paramref name="fromPath"/>.</returns>
		/// <remarks>
		/// This function takes a pair of paths and generates a relative path from one to the other. The paths do not have to be fully
		/// qualified, but they must have a common prefix, or the function will fail and return <see langword="null"/>.
		/// <para>
		/// For example, let the starting point, <paramref name="fromPath"/>, be "c:\FolderA\FolderB\FolderC", and the ending point,
		/// <paramref name="toPath"/>, be "c:\FolderA\FolderD\FolderE". <c>GetRelativePath</c> will return the relative path from
		/// <paramref name="fromPath"/> to <paramref name="toPath"/> as: "....\FolderD\FolderE". You will get the same result if you set
		/// <paramref name="fromPath"/> to "\FolderA\FolderB\FolderC" and <paramref name="toPath"/> to "\FolderA\FolderD\FolderE". On the other hand,
		/// "c:\FolderA\FolderB" and "a:\FolderA\FolderD" do not share a common prefix, and the function will fail. Note that "\" is not
		/// considered a prefix and is ignored. If you set <paramref name="fromPath"/> to "\FolderA\FolderB", and <paramref name="toPath"/>
		/// to "\FolderC\FolderD", the function will return <see langword="null"/>.
		/// </para>
		/// </remarks>
		public static string GetRelativePath(string fromPath, bool fromIsDir, string toPath, bool toIsDir) => SBAllocCallRet((s, sz) => PathRelativePathTo(s, fromPath, fromIsDir ? PInvoke.FileFlagsAndAttributes.FILE_ATTRIBUTE_EA : 0, toPath, toIsDir ? PInvoke.FileFlagsAndAttributes.FILE_ATTRIBUTE_DIRECTORY : 0));

		/// <summary>Creates a root path from a given drive number.</summary>
		/// <param name="drive">A variable that indicates the desired drive number. It should be between 0 and 25.</param>
		/// <returns>
		/// The constructed root path. If the call fails for any reason (for example, an invalid drive number), <see cref="string.Empty"/> is returned.
		/// </returns>
		public static string GetRootFromDriveNumber(int drive) => SBAllocCallRet((s, sz) => PathBuildRoot(s, drive), "", 4);


		/// <summary>
		/// Determines if a path string is a valid Universal Naming Convention (UNC) path and extract the name of the server from the path.
		/// </summary>
		/// <param name="path">The UNC path.</param>
		/// <returns>On success, the server portion of the UNC path. On failure, <see langword="null"/> is returned.</returns>
		public static string GetUNCServer(string path) => PathIsUNCEx(path, out var ptr) ? StringHelper.GetString(ptr, System.Runtime.InteropServices.CharSet.Unicode, (path.Length + 1) * 2) : null;

		/// <summary>
		/// Searches a path to determine if it contains a valid prefix of the type passed by <paramref name="prefix"/>. A prefix is one of
		/// these types: "C:\", ".", "..", "..\".
		/// </summary>
		/// <param name="path">The file or directory path.</param>
		/// <param name="prefix">The prefix for which to search.</param>
		/// <returns><c>true</c> if the specified path has the supplied prefix; otherwise, <c>false</c>.</returns>
		public static bool HasPrefix(string path, string prefix) => PathIsPrefix(prefix, path);

		/// <summary>Determines whether a given file name has one of a list of suffixes.</summary>
		/// <param name="path">The file path.</param>
		/// <param name="suffixes">The list of suffixes to check.</param>
		/// <returns>
		/// A string with the matching suffix if successful, or <see langword="null"/> if <paramref name="path"/> does not end with one of
		/// the specified suffixes.
		/// </returns>
		public static string HasSuffix(string path, string[] suffixes) => Vanara.Extensions.StringHelper.GetString(PathFindSuffixArray(path, suffixes, suffixes.Length));

		/// <summary>Compares two paths to determine if they have a common root component.</summary>
		/// <param name="path1">A string of maximum length MAX_PATH that contains the first path to be compared.</param>
		/// <param name="path2">A string of maximum length MAX_PATH that contains the second path to be compared.</param>
		/// <returns>
		/// Returns <see langword="true"/> if both strings have the same root component, or <see langword="false"/> otherwise. If
		/// <paramref name="path1"/> contains only the server and share, this function also returns <see langword="false"/>.
		/// </returns>
		public static bool HaveSameRoot(string path1, string path2) => PathIsSameRoot(path1, path2);

		/// <summary>
		/// Determines if a file's registered content type matches the specified content type. This function obtains the content type for the
		/// specified file type and compares that string with the <paramref name="contentType"/>. The comparison is not case-sensitive.
		/// </summary>
		/// <param name="path">A string of maximum length MAX_PATH that contains the file whose content type will be compared.</param>
		/// <param name="contentType">The content type string to which the file's registered content type will be compared.</param>
		/// <returns>
		/// Returns <see langword="true"/> if the file's registered content type matches <paramref name="contentType"/>, or 
		/// <see langword="false"/> otherwise.
		/// </returns>
		public static bool IsContentType(string path, string contentType) => PathIsContentType(path, contentType);

		/// <summary>Verifies that a path is a valid directory.</summary>
		/// <param name="path">A string of maximum length MAX_PATH that contains the path to verify.</param>
		/// <returns>Returns <see langword="true"/> if the path is a valid directory; otherwise, <see langword="false"/>.</returns>
		public static bool IsDirectory(string path) => PathIsDirectory(path);

		/// <summary>Determines whether a specified path is an empty directory.</summary>
		/// <param name="path">A string of maximum length MAX_PATH that contains the path to be tested.</param>
		/// <returns>
		/// Returns <see langword="true"/> if <paramref name="path"/> is an empty directory. Returns <see langword="false"/> if 
		/// <paramref name="path"/> is not a directory, or if it contains at least one file other than "." or "..".
		/// </returns>
		/// <remarks>"C:" is considered a directory.</remarks>
		public static bool IsEmptyDirectory(string path) => PathIsDirectoryEmpty(path);

		/// <summary>
		/// Searches a path for any path-delimiting characters (for example, ':' or '' ). If there are no path-delimiting characters present,
		/// the path is considered to be a File Spec path.
		/// </summary>
		/// <param name="path">A string of maximum length MAX_PATH that contains the path to be searched.</param>
		/// <returns>
		/// Returns <see langword="true"/> if there are no path-delimiting characters within the path, or <see langword="false"/> if there
		/// are path-delimiting characters.
		/// </returns>
		public static bool IsFileSpec(string path) => PathIsFileSpec(path);

		/// <summary>Determines whether a path string represents a network resource.</summary>
		/// <param name="path">A string of maximum length MAX_PATH that contains the path.</param>
		/// <returns>Returns <see langword="true"/> if the string represents a network resource, or <see langword="false"/> otherwise.</returns>
		public static bool IsNetworkPath(string path) => PathIsNetworkPath(path);

		/// <summary>Searches a path and determines if it is relative.</summary>
		/// <param name="path">A string of maximum length MAX_PATH that contains the path to be searched.</param>
		/// <returns>Returns <see langword="true"/> if the path is relative, or <see langword="false"/> if it is absolute.</returns>
		public static bool IsRelative(string path) => PathIsRelative(path);

		/// <summary>Determines whether a file name is in long format.</summary>
		/// <param name="path">A string of maximum length MAX_PATH that contains the file name to be tested.</param>
		/// <returns>
		/// Returns <see langword="true"/> if <paramref name="path"/> exceeds the number of characters allowed by the 8.3 format, or
		/// <see langword="false"/> otherwise.
		/// </returns>
		public static bool IsShortFileNameCompatible(string path) => !PathIsLFNFileSpec(path);

		/// <summary>Determines if an existing folder contains the attributes that make it a system folder.</summary>
		/// <param name="path">
		/// A string of maximum length MAX_PATH that contains the name of an existing folder. The attributes for this folder will be
		/// retrieved and compared with those that define a system folder. If this folder contains the attributes to make it a system folder,
		/// the function returns <see langword="true"/>.
		/// </param>
		/// <returns>
		/// Returns <see langword="true"/> if the <paramref name="path"/> represents a system folder, or <see langword="false"/> otherwise.
		/// </returns>
		public static bool IsSystemFolder(string path) => PathIsSystemFolder(path, 0);

		/// <summary>
		/// Determines if a path string is a valid Universal Naming Convention (UNC) path, as opposed to a path based on a drive letter.
		/// </summary>
		/// <param name="path">A string of maximum length MAX_PATH that contains the path to validate.</param>
		/// <returns>Returns <see langword="true"/> if the string is a valid UNC path; otherwise, <see langword="false"/>.</returns>
		public static bool IsUNC(string path) => PathIsUNC(path);

		/// <summary>Determines if a string is a valid Universal Naming Convention (UNC) for a server path only.</summary>
		/// <param name="path">A string of maximum length MAX_PATH that contains the path to validate.</param>
		/// <returns>
		/// Returns <see langword="true"/> if the string is a valid UNC path for a server only (no share name), or <see langword="false"/> otherwise.
		/// </returns>
		public static bool IsUNCServer(string path) => PathIsUNCServer(path);

		/// <summary>Determines if a string is a valid Universal Naming Convention (UNC) share path, \server\share.</summary>
		/// <param name="path">A string of maximum length MAX_PATH that contains the path to be validated.</param>
		/// <returns>Returns <see langword="true"/> if the string is in the form \server\share, or <see langword="false"/> otherwise.</returns>
		public static bool IsUNCServerShare(string path) => PathIsUNCServerShare(path);

		/// <summary>Tests a given string to determine if it conforms to a valid URL format.</summary>
		/// <param name="path">A string of maximum length MAX_PATH that contains the URL path to validate.</param>
		/// <returns>Returns <see langword="true"/> if <paramref name="path"/> has a valid URL format, or <see langword="false"/> otherwise.</returns>
		/// <remarks>This function does not verify that the path points to an existing site—only that it has a valid URL format.</remarks>
		public static bool IsURL(string path) => PathIsURL(path);

		/// <summary>Gives an existing folder the proper attributes to become a system folder.</summary>
		/// <param name="path">
		/// A string of length MAX_PATH that contains the name of an existing folder that will be made into a system folder.
		/// </param>
		/// <returns>Returns <see langword="true"/> if successful, or <see langword="false"/> otherwise.</returns>
		public static bool MakeSystemFolder(string path) => PathMakeSystemFolder(path);

		/// <summary>Matches a file name from a path against one or more file name patterns.</summary>
		/// <param name="path">A string of maximum length MAX_PATH that contains the path from which the file name to be matched is taken.</param>
		/// <param name="pattern">
		/// A string of maximum length MAX_PATH that contains the file name pattern for which to search. This can be the exact name, or it
		/// can contain wildcard characters. This value can contain one pattern or multiple patterns separated with semicolons.
		/// </param>
		/// <param name="ignorePatternWhitespace">
		/// If <see langword="true"/>, ignore leading spaces in the string pointed to by <paramref name="pattern"/>.
		/// </param>
		/// <returns>
		/// Return <see langword="true"/> if a file name pattern specified in <paramref name="pattern"/> matched the file name found in the
		/// string pointed to by <paramref name="path"/>.
		/// </returns>
		public static bool MatchesLookupPattern(string path, string pattern, bool ignorePatternWhitespace = false) => PathMatchSpecEx(path, pattern, (ignorePatternWhitespace ? PMSF.PMSF_DONT_STRIP_SPACES : 0) | (pattern.IndexOf(';') < 0 ? PMSF.PMSF_NORMAL : PMSF.PMSF_MULTIPLE)) == HRESULT.S_OK;

		/// <summary>Searches a path for spaces. If spaces are found, the entire path is enclosed in quotation marks.</summary>
		/// <param name="path">A string that contains the path to search.</param>
		/// <returns>A quoted string if spaces were found; otherwise, the value of <paramref name="path"/>.</returns>
		public static string QuoteIfHasSpaces(string path) => SBAllocCallRet((s, sz) => PathQuoteSpaces(s), path);

		/// <summary>
		/// Replaces a file name's extension at the end of a path string with a new extension. If the path string does not end with an
		/// extension, the new extension is added.
		/// </summary>
		/// <param name="path">A path string.</param>
		/// <param name="newExt">
		/// A new extension string. The leading '.' character is optional. In the case of an empty string (""), any existing extension in the
		/// path string is removed.
		/// </param>
		/// <returns>If this function succeeds, it returns <paramref name="path"/> with the renamed or added extension.</returns>
		public static string RenameExtension(string path, string newExt) => SBAllocCallRet((s, sz) => PathCchRenameExtension(s, sz, newExt), path);

		/// <summary>Removes the decoration from a path string.</summary>
		/// <param name="path">A string of length MAX_PATH that contains the path.</param>
		/// <returns>The undecorated string.</returns>
		/// <remarks>
		/// <para>
		/// A decoration consists of a pair of square brackets with one or more digits in between, inserted immediately after the base name
		/// and before the file name extension.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following table illustrates how strings are modified by <c>Undecorate</c>.</para>
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
		public static string Undecorate(string path) => SBAllocCallRet((s, sz) => PathUndecorate(s), path);

		/// <summary>Replaces certain folder names in a fully qualified path with their associated environment string.</summary>
		/// <param name="path">A string of maximum length MAX_PATH that contains the path to be unexpanded.</param>
		/// <returns>Returns <see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
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
		public static string UnexpandEnvironmentStrings(string path) => SBAllocCallRet((s, sz) => PathUnExpandEnvStrings(path, s, sz));

		/// <summary>
		/// <para>Removes the attributes from a folder that make it a system folder. This folder must actually exist in the file system.</para>
		/// </summary>
		/// <param name="path">
		/// A string of maximum length MAX_PATH that contains the name of an existing folder that will have the system folder attributes removed.
		/// </param>
		/// <returns>Returns <see langword="true"/> if successful, or <see langword="false"/> otherwise.</returns>
		public static bool UnmakeSystemFolder(string path) => PathUnmakeSystemFolder(path);

		/// <summary>Removes quotes from the beginning and end of a path.</summary>
		/// <param name="path">A string of length MAX_PATH that contains the path.</param>
		/// <returns>A string with beginning and ending quotation marks removed.</returns>
		public static string Unquote(string path) => SBAllocCallRet((s, sz) => PathUnquoteSpaces(s), path);

		private static string SBAllocCallRet(Action<StringBuilder, uint> func, string inval = "", uint sz = MAX_PATH)
		{
			if (inval == null) throw new ArgumentNullException("path");
			var sb = new StringBuilder((int)sz, (int)sz);
			sb.Append(inval); // Done this way in case the input string is longer than the buffer.
			func(sb, sz);
			return sb.ToString();
		}

		private static string SBAllocCallRet(Func<StringBuilder, uint, HRESULT> func, string inval = "", uint sz = PATHCCH_MAX_CCH, Action<HRESULT> err = null)
		{
			if (inval == null) throw new ArgumentNullException("path");
			var sb = new StringBuilder(inval, (int)sz);
			var hr = func(sb, sz);
			if (err != null) err?.Invoke(hr); else hr.ThrowIfFailed();
			return sb.ToString();
		}

		private static void ThrowIfNotOkOrFalse(HRESULT hr) { if (hr.Failed && hr != HRESULT.S_FALSE) hr.ThrowIfFailed(); }
	}
}
