using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke;

/// <summary>Items from version.dll.</summary>
public static partial class VersionDll
{
	private const string Lib_Version = "version.dll";

	/// <summary>Retrieves version information for the specified file.</summary>
	/// <param name="lptstrFilename">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The name of the file. If a full path is not specified, the function uses the search sequence specified by the LoadLibrary function.
	/// </para>
	/// </param>
	/// <param name="dwHandle">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>This parameter is ignored.</para>
	/// </param>
	/// <param name="dwLen">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The size, in bytes, of the buffer pointed to by the lpData parameter.</para>
	/// <para>
	/// Call the GetFileVersionInfoSize function first to determine the size, in bytes, of a file's version information. The dwLen
	/// member should be equal to or greater than that value.
	/// </para>
	/// <para>
	/// If the buffer pointed to by lpData is not large enough, the function truncates the file's version information to the size of the buffer.
	/// </para>
	/// </param>
	/// <param name="lpData">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>Pointer to a buffer that receives the file-version information.</para>
	/// <para>You can use this value in a subsequent call to the VerQueryValue function to retrieve data from the buffer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// File version info has fixed and non-fixed part. The fixed part contains information like version number. The non-fixed part
	/// contains things like strings. In the past <c>GetFileVersionInfo</c> was taking version information from the binary (exe/dll).
	/// Currently, it is querying fixed version from language neutral file (exe/dll) and the non-fixed part from mui file, merges them
	/// and returns to the user. If the given binary does not have a mui file then behavior is as in previous version.
	/// </para>
	/// <para>
	/// Call the GetFileVersionInfoSize function before calling the <c>GetFileVersionInfo</c> function. To retrieve information from the
	/// file-version information buffer, use the VerQueryValue function.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winver.h header defines GetFileVersionInfo as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winver/nf-winver-getfileversioninfoa BOOL GetFileVersionInfoA( LPCSTR
	// lptstrFilename, DWORD dwHandle, DWORD dwLen, LPVOID lpData );
	[DllImport(Lib_Version, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winver.h", MSDNShortId = "NF:winver.GetFileVersionInfoA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetFileVersionInfo([MarshalAs(UnmanagedType.LPTStr)] string lptstrFilename, [Optional] uint dwHandle,
		uint dwLen, [Out] IntPtr lpData);

	/// <summary>Retrieves version information for the specified file.</summary>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// Controls the MUI DLLs (if any) from which the version resource is extracted. The value of this flag must match the flags passed
	/// to the corresponding GetFileVersionInfoSizeEx call, which was used to determine the buffer size that is passed in the dwLen
	/// parameter. Zero or more of the following flags.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_VER_GET_LOCALISED 0x01</term>
	/// <term>Loads the entire version resource (both strings and binary version information) from the corresponding MUI file, if available.</term>
	/// </item>
	/// <item>
	/// <term>FILE_VER_GET_NEUTRAL 0x02</term>
	/// <term>
	/// Loads the version resource strings from the corresponding MUI file, if available, and loads the binary version information
	/// (VS_FIXEDFILEINFO) from the corresponding language-neutral file, if available.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_VER_GET_PREFETCHED 0x04</term>
	/// <term>
	/// Indicates a preference for version.dll to attempt to preload the image outside of the loader lock to avoid contention. This flag
	/// does not change the behavior or semantics of the function.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpwstrFilename">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The name of the file. If a full path is not specified, the function uses the search sequence specified by the LoadLibrary function.
	/// </para>
	/// </param>
	/// <param name="dwHandle">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>This parameter is ignored.</para>
	/// </param>
	/// <param name="dwLen">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The size, in bytes, of the buffer pointed to by the lpData parameter.</para>
	/// <para>
	/// Call the GetFileVersionInfoSizeEx function first to determine the size, in bytes, of a file's version information. The dwLen
	/// parameter should be equal to or greater than that value.
	/// </para>
	/// <para>
	/// If the buffer pointed to by lpData is not large enough, the function truncates the file's version information to the size of the buffer.
	/// </para>
	/// </param>
	/// <param name="lpData">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>When this function returns, contains a pointer to a buffer that contains the file-version information.</para>
	/// <para>You can use this value in a subsequent call to the VerQueryValue function to retrieve data from the buffer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call the GetFileVersionInfoSizeEx function before calling the <c>GetFileVersionInfoEx</c> function. To retrieve information from
	/// the file-version information buffer, use the VerQueryValue function.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winver.h header defines GetFileVersionInfoEx as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winver/nf-winver-getfileversioninfoexa BOOL GetFileVersionInfoExA( DWORD
	// dwFlags, LPCSTR lpwstrFilename, DWORD dwHandle, DWORD dwLen, LPVOID lpData );
	[DllImport(Lib_Version, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winver.h", MSDNShortId = "NF:winver.GetFileVersionInfoExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetFileVersionInfoEx(FILE_VER_GET dwFlags, [MarshalAs(UnmanagedType.LPTStr)] string lpwstrFilename, [Optional] uint dwHandle,
		uint dwLen, [Out] IntPtr lpData);

	/// <summary>
	/// Determines whether the operating system can retrieve version information for a specified file. If version information is
	/// available, <c>GetFileVersionInfoSize</c> returns the size, in bytes, of that information.
	/// </summary>
	/// <param name="lptstrFilename">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The name of the file of interest. The function uses the search sequence specified by the LoadLibrary function.</para>
	/// </param>
	/// <param name="lpdwHandle">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>A pointer to a variable that the function sets to zero.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>If the function succeeds, the return value is the size, in bytes, of the file's version information.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call the <c>GetFileVersionInfoSize</c> function before calling the GetFileVersionInfo function. The size returned by
	/// <c>GetFileVersionInfoSize</c> indicates the buffer size required for the version information returned by <c>GetFileVersionInfo</c>.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winver.h header defines GetFileVersionInfoSize as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winver/nf-winver-getfileversioninfosizea DWORD GetFileVersionInfoSizeA( LPCSTR
	// lptstrFilename, LPDWORD lpdwHandle );
	[DllImport(Lib_Version, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winver.h", MSDNShortId = "NF:winver.GetFileVersionInfoSizeA")]
	public static extern uint GetFileVersionInfoSize([MarshalAs(UnmanagedType.LPTStr)] string lptstrFilename, out uint lpdwHandle);

	/// <summary>
	/// Determines whether the operating system can retrieve version information for a specified file. If version information is
	/// available, <c>GetFileVersionInfoSizeEx</c> returns the size, in bytes, of that information.
	/// </summary>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Controls which MUI DLLs (if any) from which the version resource is extracted. Zero or more of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_VER_GET_LOCALISED 0x01</term>
	/// <term>Loads the entire version resource (both strings and binary version information) from the corresponding MUI file, if available.</term>
	/// </item>
	/// <item>
	/// <term>FILE_VER_GET_NEUTRAL 0x002</term>
	/// <term>
	/// Loads the version resource strings from the corresponding MUI file, if available, and loads the binary version information
	/// (VS_FIXEDFILEINFO) from the corresponding language-neutral file, if available.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpwstrFilename">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The name of the file of interest. The function uses the search sequence specified by the LoadLibrary function.</para>
	/// </param>
	/// <param name="lpdwHandle">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>
	/// When this function returns, contains a pointer to a variable that is set to zero because this function sets it to zero. This
	/// parameter exists for historical reasons.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>If the function succeeds, the return value is the size, in bytes, of the file's version information.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call the <c>GetFileVersionInfoSizeEx</c> function before calling the GetFileVersionInfoEx function. The size returned by
	/// <c>GetFileVersionInfoSizeEx</c> indicates the buffer size required for the version information returned by <c>GetFileVersionInfoEx</c>.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winver.h header defines GetFileVersionInfoSizeEx as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winver/nf-winver-getfileversioninfosizeexa DWORD GetFileVersionInfoSizeExA(
	// DWORD dwFlags, LPCSTR lpwstrFilename, LPDWORD lpdwHandle );
	[DllImport(Lib_Version, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winver.h", MSDNShortId = "NF:winver.GetFileVersionInfoSizeExA")]
	public static extern uint GetFileVersionInfoSizeEx(FILE_VER_GET dwFlags, [MarshalAs(UnmanagedType.LPTStr)] string lpwstrFilename,
		out uint lpdwHandle);

	/// <summary>
	/// Determines where to install a file based on whether it locates another version of the file in the system. The values
	/// <c>VerFindFile</c> returns in the specified buffers are used in a subsequent call to the VerInstallFile function.
	/// </summary>
	/// <param name="uFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>This parameter can be the following value. All other bits are reserved.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>VFFF_ISSHAREDFILE 0x0001</term>
	/// <term>
	/// The source file can be shared by multiple applications. An application can use this information to determine where the file
	/// should be copied.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szFileName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The name of the file to be installed. Include only the file name and extension, not a path.</para>
	/// </param>
	/// <param name="szWinDir">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The directory in which Windows is running or will be run. This string is returned by the GetWindowsDirectory function.</para>
	/// </param>
	/// <param name="szAppDir">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The directory where the installation program is installing a set of related files. If the installation program is installing an
	/// application, this is the directory where the application will reside. This parameter also points to the application's current
	/// directory unless otherwise specified.
	/// </para>
	/// </param>
	/// <param name="szCurDir">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>
	/// A buffer that receives the path to a current version of the file being installed. The path is a zero-terminated string. If a
	/// current version is not installed, the buffer will contain a zero-length string. The buffer should be at least <c>_MAX_PATH</c>
	/// characters long, although this is not required.
	/// </para>
	/// </param>
	/// <param name="puCurDirLen">
	/// <para>Type: <c>PUINT</c></para>
	/// <para>The length of the szCurDir buffer. This pointer must not be <c>NULL</c>.</para>
	/// <para>
	/// When the function returns, lpuCurDirLen contains the size, in characters, of the data returned in szCurDir, including the
	/// terminating null character. If the buffer is too small to contain all the data, lpuCurDirLen will be the size of the buffer
	/// required to hold the path.
	/// </para>
	/// </param>
	/// <param name="szDestDir">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// A buffer that receives the path to the installation location recommended by <c>VerFindFile</c>. The path is a zero-terminated
	/// string. The buffer should be at least <c>_MAX_PATH</c> characters long, although this is not required.
	/// </para>
	/// </param>
	/// <param name="puDestDirLen">
	/// <para>Type: <c>PUINT</c></para>
	/// <para>A pointer to a variable that specifies the length of the szDestDir buffer. This pointer must not be <c>NULL</c>.</para>
	/// <para>
	/// When the function returns, lpuDestDirLen contains the size, in characters, of the data returned in szDestDir, including the
	/// terminating null character. If the buffer is too small to contain all the data, lpuDestDirLen will be the size of the buffer
	/// needed to hold the path.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The return value is a bitmask that indicates the status of the file. It can be one or more of the following values. All other
	/// values are reserved.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>VFF_CURNEDEST 0x0001</term>
	/// <term>The currently installed version of the file is not in the recommended destination.</term>
	/// </item>
	/// <item>
	/// <term>VFF_FILEINUSE 0x0002</term>
	/// <term>The system is using the currently installed version of the file; therefore, the file cannot be overwritten or deleted.</term>
	/// </item>
	/// <item>
	/// <term>VFF_BUFFTOOSMALL 0x0004</term>
	/// <term>
	/// At least one of the buffers was too small to contain the corresponding string. An application should check the output buffers to
	/// determine which buffer was too small.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function works on 16-, 32-, and 64-bit file images.</para>
	/// <para>
	/// <c>VerFindFile</c> searches for a copy of the specified file by using the OpenFile function. However, it determines the system
	/// directory from the specified Windows directory, or searches the path.
	/// </para>
	/// <para>
	/// If the dwFlags parameter indicates that the file is private to this application (not <c>VFFF_ISSHAREDFILE</c>),
	/// <c>VerFindFile</c> recommends installing the file in the application's directory. Otherwise, if the system is running a shared
	/// copy of the system, the function recommends installing the file in the Windows directory. If the system is running a private
	/// copy of the system, the function recommends installing the file in the system directory.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winver.h header defines VerFindFile as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winver/nf-winver-verfindfilea DWORD VerFindFileA( DWORD uFlags, LPCSTR
	// szFileName, LPCSTR szWinDir, LPCSTR szAppDir, LPSTR szCurDir, PUINT puCurDirLen, LPSTR szDestDir, PUINT puDestDirLen );
	[DllImport(Lib_Version, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winver.h", MSDNShortId = "NF:winver.VerFindFileA")]
	public static extern VFF VerFindFile(VFFF uFlags, [MarshalAs(UnmanagedType.LPTStr)] string szFileName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szWinDir, [MarshalAs(UnmanagedType.LPTStr)] string szAppDir,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szCurDir, ref uint puCurDirLen,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szDestDir, ref uint puDestDirLen);

	/// <summary>
	/// Installs the specified file based on information returned from the VerFindFile function. <c>VerInstallFile</c> decompresses the
	/// file, if necessary, assigns a unique filename, and checks for errors, such as outdated files.
	/// </summary>
	/// <param name="uFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>This parameter can be one of the following values. All other bits are reserved.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>VIFF_FORCEINSTALL 0x0001</term>
	/// <term>Installs the file regardless of mismatched version numbers. The function checks only for physical errors during installation.</term>
	/// </item>
	/// <item>
	/// <term>VIFF_DONTDELETEOLD 0x0002</term>
	/// <term>
	/// Installs the file without deleting the previously installed file, if the previously installed file is not in the destination directory.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szSrcFileName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The name of the file to be installed. This is the filename in the directory pointed to by the szSrcDir parameter; the filename
	/// can include only the filename and extension, not a path.
	/// </para>
	/// </param>
	/// <param name="szDestFileName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The name <c>VerInstallFile</c> will give the new file upon installation. This file name may be different from the filename in
	/// the szSrcFileName directory. The new name should include only the file name and extension, not a path.
	/// </para>
	/// </param>
	/// <param name="szSrcDir">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The name of the directory where the file can be found.</para>
	/// </param>
	/// <param name="szDestDir">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>The name of the directory where the file should be installed. VerFindFile returns this value in its szDestDir parameter.</para>
	/// </param>
	/// <param name="szCurDir">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The name of the directory where a preexisting version of this file can be found. VerFindFile returns this value in its szCurDir parameter.
	/// </para>
	/// </param>
	/// <param name="szTmpFile">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// The name of a temporary copy of the source file. The buffer should be at least <c>_MAX_PATH</c> characters long, although this
	/// is not required, and should be empty on input.
	/// </para>
	/// </param>
	/// <param name="puTmpFileLen">
	/// <para>Type: <c>PUINT</c></para>
	/// <para>The length of the szTmpFile buffer. This pointer must not be <c>NULL</c>.</para>
	/// <para>
	/// When the function returns, lpuTmpFileLen receives the size, in characters, of the data returned in szTmpFile, including the
	/// terminating null character. If the buffer is too small to contain all the data, lpuTmpFileLen will be the size of the buffer
	/// required to hold the data.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The return value is a bitmask that indicates exceptions. It can be one or more of the following values. All other values are reserved.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>VIF_ACCESSVIOLATION 0x00000200L</term>
	/// <term>A read, create, delete, or rename operation failed due to an access violation.</term>
	/// </item>
	/// <item>
	/// <term>VIF_BUFFTOOSMALL 0x00040000L</term>
	/// <term>
	/// The szTmpFile buffer was too small to contain the name of the temporary source file. When the function returns, lpuTmpFileLen
	/// contains the size of the buffer required to hold the filename.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VIF_CANNOTCREATE 0x00000800L</term>
	/// <term>The function cannot create the temporary file. The specific error may be described by another flag.</term>
	/// </item>
	/// <item>
	/// <term>VIF_CANNOTDELETE 0x00001000L</term>
	/// <term>
	/// The function cannot delete the destination file, or cannot delete the existing version of the file located in another directory.
	/// If the VIF_TEMPFILE bit is set, the installation failed, and the destination file probably cannot be deleted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VIF_CANNOTDELETECUR 0x00004000L</term>
	/// <term>The existing version of the file could not be deleted and VIFF_DONTDELETEOLD was not specified.</term>
	/// </item>
	/// <item>
	/// <term>VIF_CANNOTLOADCABINET 0x00100000L</term>
	/// <term>The function cannot load the cabinet file.</term>
	/// </item>
	/// <item>
	/// <term>VIF_CANNOTLOADLZ32 0x00080000L</term>
	/// <term>The function cannot load the compressed file.</term>
	/// </item>
	/// <item>
	/// <term>VIF_CANNOTREADDST 0x00020000L</term>
	/// <term>The function cannot read the destination (existing) files. This prevents the function from examining the file's attributes.</term>
	/// </item>
	/// <item>
	/// <term>VIF_CANNOTREADSRC 0x00010000L</term>
	/// <term>The function cannot read the source file. This could mean that the path was not specified properly.</term>
	/// </item>
	/// <item>
	/// <term>VIF_CANNOTRENAME 0x00002000L</term>
	/// <term>The function cannot rename the temporary file, but already deleted the destination file.</term>
	/// </item>
	/// <item>
	/// <term>VIF_DIFFCODEPG 0x00000010L</term>
	/// <term>
	/// The new file requires a code page that cannot be displayed by the version of the system currently running. This error can be
	/// overridden by calling VerInstallFile with the VIFF_FORCEINSTALL flag set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VIF_DIFFLANG 0x00000008L</term>
	/// <term>
	/// The new and preexisting files have different language or code-page values. This error can be overridden by calling
	/// VerInstallFile again with the VIFF_FORCEINSTALL flag set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VIF_DIFFTYPE 0x00000020L</term>
	/// <term>
	/// The new file has a different type, subtype, or operating system from the preexisting file. This error can be overridden by
	/// calling VerInstallFile again with the VIFF_FORCEINSTALL flag set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VIF_FILEINUSE 0x00000080L</term>
	/// <term>The preexisting file is in use by the system and cannot be deleted.</term>
	/// </item>
	/// <item>
	/// <term>VIF_MISMATCH 0x00000002L</term>
	/// <term>
	/// The new and preexisting files differ in one or more attributes. This error can be overridden by calling VerInstallFile again
	/// with the VIFF_FORCEINSTALL flag set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VIF_OUTOFMEMORY 0x00008000L</term>
	/// <term>
	/// The function cannot complete the requested operation due to insufficient memory. Generally, this means the application ran out
	/// of memory attempting to expand a compressed file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VIF_OUTOFSPACE 0x00000100L</term>
	/// <term>The function cannot create the temporary file due to insufficient disk space on the destination drive.</term>
	/// </item>
	/// <item>
	/// <term>VIF_SHARINGVIOLATION 0x00000400L</term>
	/// <term>A read, create, delete, or rename operation failed due to a sharing violation.</term>
	/// </item>
	/// <item>
	/// <term>VIF_SRCOLD 0x00000004L</term>
	/// <term>
	/// The file to install is older than the preexisting file. This error can be overridden by calling VerInstallFile again with the
	/// VIFF_FORCEINSTALL flag set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VIF_TEMPFILE 0x00000001L</term>
	/// <term>The temporary copy of the new file is in the destination directory. The cause of failure is reflected in other flags.</term>
	/// </item>
	/// <item>
	/// <term>VIF_WRITEPROT 0x00000040L</term>
	/// <term>
	/// The preexisting file is write-protected. This error can be overridden by calling VerInstallFile again with the VIFF_FORCEINSTALL
	/// flag set.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function works on 16-, 32-, and 64-bit file images.</para>
	/// <para>
	/// <c>VerInstallFile</c> copies the file from the source directory to the destination directory. If szCurDir indicates that a
	/// previous version of the file exists on the system, <c>VerInstallFile</c> compares the files' version stamp information. If the
	/// previously installed version of the file is more recent than the new version, or if the files' attributes are significantly
	/// different, for example, if they are in different languages, then <c>VerInstallFile</c> returns with one or more recoverable
	/// error codes.
	/// </para>
	/// <para>
	/// <c>VerInstallFile</c> leaves the temporary file in the destination directory. The application can either override the error or
	/// delete the temporary file. If the application overrides the error, <c>VerInstallFile</c> deletes the previously installed
	/// version and renames the temporary file with the original filename.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winver.h header defines VerInstallFile as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winver/nf-winver-verinstallfilea DWORD VerInstallFileA( DWORD uFlags, LPCSTR
	// szSrcFileName, LPCSTR szDestFileName, LPCSTR szSrcDir, LPCSTR szDestDir, LPCSTR szCurDir, LPSTR szTmpFile, PUINT puTmpFileLen );
	[DllImport(Lib_Version, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winver.h", MSDNShortId = "NF:winver.VerInstallFileA")]
	public static extern VIF VerInstallFile(VIFF uFlags, [MarshalAs(UnmanagedType.LPTStr)] string szSrcFileName,
		[MarshalAs(UnmanagedType.LPTStr)] string szDestFileName, [MarshalAs(UnmanagedType.LPTStr)] string szSrcDir,
		[MarshalAs(UnmanagedType.LPTStr)] string szDestDir, [MarshalAs(UnmanagedType.LPTStr)] string szCurDir,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szTmpFile, ref uint puTmpFileLen);

	/// <summary>Retrieves a description string for the language associated with a specified binary Microsoft language identifier.</summary>
	/// <param name="wLang">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The binary language identifier. For a complete list of the language identifiers, see Language Identifiers.</para>
	/// <para>
	/// For example, the description string associated with the language identifier 0x040A is "Spanish (Traditional Sort)". If the
	/// identifier is unknown, the szLang parameter points to a default string ("Language Neutral").
	/// </para>
	/// </param>
	/// <param name="szLang">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>The language specified by the wLang parameter.</para>
	/// </param>
	/// <param name="cchLang">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The size, in characters, of the buffer pointed to by szLang.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The return value is the size, in characters, of the string returned in the buffer. This value does not include the terminating
	/// null character. If the description string is smaller than or equal to the buffer, the entire description string is in the
	/// buffer. If the description string is larger than the buffer, the description string is truncated to the length of the buffer.
	/// </para>
	/// <para>If an error occurs, the return value is zero. Unknown language identifiers do not produce errors.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function works on 16-, 32-, and 64-bit file images.</para>
	/// <para>
	/// Typically, an installation program uses this function to translate a language identifier returned by the VerQueryValue function.
	/// The text string may be used in a dialog box that asks the user how to proceed in the event of a language conflict.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winver.h header defines VerLanguageName as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winver/nf-winver-verlanguagenamea DWORD VerLanguageNameA( DWORD wLang, LPSTR
	// szLang, DWORD cchLang );
	[DllImport(Lib_Version, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winver.h", MSDNShortId = "NF:winver.VerLanguageNameA")]
	public static extern uint VerLanguageName(uint wLang, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szLang, uint cchLang);

	/// <summary>
	/// Retrieves specified version information from the specified version-information resource. To retrieve the appropriate resource,
	/// before you call <c>VerQueryValue</c>, you must first call the GetFileVersionInfoSize function, and then the GetFileVersionInfo function.
	/// </summary>
	/// <param name="pBlock">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>The version-information resource returned by the GetFileVersionInfo function.</para>
	/// </param>
	/// <param name="lpSubBlock">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The version-information value to be retrieved. The string must consist of names separated by backslashes (\) and it must have
	/// one of the following forms.
	/// </para>
	/// <para>\</para>
	/// <para>The root block. The function retrieves a pointer to the VS_FIXEDFILEINFO structure for the version-information resource.</para>
	/// <para>\VarFileInfo\Translation</para>
	/// <para>
	/// The translation array in a Var variable information structure—the <c>Value</c> member of this structure. The function retrieves
	/// a pointer to this array of language and code page identifiers. An application can use these identifiers to access a
	/// language-specific StringTable structure (using the <c>szKey</c> member) in the version-information resource.
	/// </para>
	/// <para>\StringFileInfo\lang-codepage\string-name</para>
	/// <para>
	/// A value in a language-specific StringTable structure. The lang-codepage name is a concatenation of a language and code page
	/// identifier pair found as a <c>DWORD</c> in the translation array for the resource. Here the lang-codepage name must be specified
	/// as a hexadecimal string. The string-name name must be one of the predefined strings described in the following Remarks section.
	/// The function retrieves a string value specific to the language and code page indicated.
	/// </para>
	/// </param>
	/// <param name="lplpBuffer">
	/// <para>Type: <c>LPVOID*</c></para>
	/// <para>
	/// When this method returns, contains the address of a pointer to the requested version information in the buffer pointed to by
	/// pBlock. The memory pointed to by lplpBuffer is freed when the associated pBlock memory is freed.
	/// </para>
	/// </param>
	/// <param name="puLen">
	/// <para>Type: <c>PUINT</c></para>
	/// <para>
	/// When this method returns, contains a pointer to the size of the requested data pointed to by lplpBuffer: for version information
	/// values, the length in characters of the string stored at lplpBuffer; for translation array values, the size in bytes of the
	/// array stored at lplpBuffer; and for root block, the size in bytes of the structure.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// If the specified version-information structure exists, and version information is available, the return value is nonzero. If the
	/// address of the length buffer is zero, no value is available for the specified version-information name.
	/// </para>
	/// <para>If the specified name does not exist or the specified resource is not valid, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function works on 16-, 32-, and 64-bit file images.</para>
	/// <para>The following are predefined version information Unicode strings.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Comments</term>
	/// <term>InternalName</term>
	/// <term>ProductName</term>
	/// </listheader>
	/// <item>
	/// <term>CompanyName</term>
	/// <term>LegalCopyright</term>
	/// <term>ProductVersion</term>
	/// </item>
	/// <item>
	/// <term>FileDescription</term>
	/// <term>LegalTrademarks</term>
	/// <term>PrivateBuild</term>
	/// </item>
	/// <item>
	/// <term>FileVersion</term>
	/// <term>OriginalFilename</term>
	/// <term>SpecialBuild</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to enumerate the available version languages and retrieve the FileDescription string-value for
	/// each language.
	/// </para>
	/// <para>
	/// Be sure to call the GetFileVersionInfoSize and GetFileVersionInfo functions before calling <c>VerQueryValue</c> to properly
	/// initialize the pBlock buffer.
	/// </para>
	/// <para>
	/// <code>// Structure used to store enumerated languages and code pages. HRESULT hr; struct LANGANDCODEPAGE { WORD wLanguage; WORD wCodePage; } *lpTranslate; // Read the list of languages and code pages. VerQueryValue(pBlock, TEXT("\\VarFileInfo\\Translation"), (LPVOID*)&amp;lpTranslate, &amp;cbTranslate); // Read the file description for each language and code page. for( i=0; i &lt; (cbTranslate/sizeof(struct LANGANDCODEPAGE)); i++ ) { hr = StringCchPrintf(SubBlock, 50, TEXT("\\StringFileInfo\\%04x%04x\\FileDescription"), lpTranslate[i].wLanguage, lpTranslate[i].wCodePage); if (FAILED(hr)) { // TODO: write error handler. } // Retrieve file description for language and code page "i". VerQueryValue(pBlock, SubBlock, &amp;lpBuffer, &amp;dwBytes); }</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winver.h header defines VerQueryValue as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winver/nf-winver-verqueryvaluea BOOL VerQueryValueA( LPCVOID pBlock, LPCSTR
	// lpSubBlock, LPVOID *lplpBuffer, PUINT puLen );
	[DllImport(Lib_Version, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winver.h", MSDNShortId = "NF:winver.VerQueryValueA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool VerQueryValue(IntPtr pBlock, [MarshalAs(UnmanagedType.LPTStr)] string lpSubBlock, out IntPtr lplpBuffer, out uint puLen);
}