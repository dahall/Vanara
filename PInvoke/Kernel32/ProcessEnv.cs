using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Standard device handle types used by <see cref="GetStdHandle"/>.</summary>
		[PInvokeData("Winbase.h")]
		public enum StdHandleType : int
		{
			/// <summary>The standard input device. Initially, this is the console input buffer, CONIN$.</summary>
			STD_INPUT_HANDLE = -10,

			/// <summary>The standard output device. Initially, this is the active console screen buffer, CONOUT$.</summary>
			STD_OUTPUT_HANDLE = -11,

			/// <summary>The standard error device. Initially, this is the active console screen buffer, CONOUT$.</summary>
			STD_ERROR_HANDLE = -12,
		}

		/// <summary>
		/// <para>Expands environment-variable strings and replaces them with the values defined for the current user.</para>
		/// <para>To specify the environment block for a particular user or the system, use the <c>ExpandEnvironmentStringsForUser</c> function.</para>
		/// </summary>
		/// <param name="lpSrc">
		/// <para>
		/// A buffer that contains one or more environment-variable strings in the form: %variableName%. For each such reference, the
		/// %variableName% portion is replaced with the current value of that environment variable.
		/// </para>
		/// <para>
		/// Case is ignored when looking up the environment-variable name. If the name is not found, the %variableName% portion is left unexpanded.
		/// </para>
		/// <para>
		/// Note that this function does not support all the features that Cmd.exe supports. For example, it does not support
		/// %variableName:str1=str2% or %variableName:~offset,length%.
		/// </para>
		/// </param>
		/// <param name="lpDst">
		/// A pointer to a buffer that receives the result of expanding the environment variable strings in the lpSrc buffer. Note that this
		/// buffer cannot be the same as the lpSrc buffer.
		/// </param>
		/// <param name="nSize">
		/// The maximum number of characters that can be stored in the buffer pointed to by the lpDst parameter. When using ANSI strings, the
		/// buffer size should be the string length, plus terminating null character, plus one. When using Unicode strings, the buffer size
		/// should be the string length plus the terminating null character.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the number of <c>TCHARs</c> stored in the destination buffer, including the
		/// terminating null character. If the destination buffer is too small to hold the expanded string, the return value is the required
		/// buffer size, in characters.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// DWORD WINAPI ExpandEnvironmentStrings( _In_ LPCTSTR lpSrc, _Out_opt_ LPTSTR lpDst, _In_ DWORD nSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724265(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724265")]
		public static extern uint ExpandEnvironmentStrings(string lpSrc, StringBuilder lpDst, uint nSize);

		/// <summary>Frees a block of environment strings.</summary>
		/// <param name="lpszEnvironmentBlock">
		/// A pointer to a block of environment strings. The pointer to the block must be obtained by calling the
		/// <c>GetEnvironmentStrings</c> function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI FreeEnvironmentStrings( _In_ LPTCH lpszEnvironmentBlock); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683151(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683151")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FreeEnvironmentStrings(IntPtr lpszEnvironmentBlock);

		/// <summary>Retrieves the command-line string for the current process.</summary>
		/// <returns>The return value is a pointer to the command-line string for the current process.</returns>
		// LPTSTR WINAPI GetCommandLine(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683156(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "ms683156")]
		public static string GetCommandLine() => Marshal.PtrToStringAuto(GetCommandLineInternal());

		/// <summary>Retrieves the current directory for the current process.</summary>
		/// <param name="nBufferLength">
		/// The length of the buffer for the current directory string, in <c>TCHARs</c>. The buffer length must include room for a
		/// terminating null character.
		/// </param>
		/// <param name="lpBuffer">
		/// <para>
		/// A pointer to the buffer that receives the current directory string. This null-terminated string specifies the absolute path to
		/// the current directory.
		/// </para>
		/// <para>To determine the required buffer size, set this parameter to <c>NULL</c> and the nBufferLength parameter to 0.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value specifies the number of characters that are written to the buffer, not including the
		/// terminating null character.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>
		/// If the buffer that is pointed to by lpBuffer is not large enough, the return value specifies the required size of the buffer, in
		/// characters, including the null-terminating character.
		/// </para>
		/// </returns>
		// DWORD WINAPI GetCurrentDirectory( _In_ DWORD nBufferLength, _Out_ LPTSTR lpBuffer); https://msdn.microsoft.com/en-us/library/windows/desktop/aa364934(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa364934")]
		public static extern uint GetCurrentDirectory(uint nBufferLength, StringBuilder lpBuffer);

		/// <summary>Retrieves the environment variables for the current process.</summary>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to the environment block of the current process.</para>
		/// <para>If the function fails, the return value is NULL.</para>
		/// </returns>
		// LPTCH WINAPI GetEnvironmentStrings(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683187(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "ms683187")]
		public static string[] GetEnvironmentStrings()
		{
			var ptr = InternalGetEnvironmentStrings();
			try { return ptr.ToStringEnum().ToArray(); }
			finally { FreeEnvironmentStrings(ptr); }
		}

		/// <summary>Retrieves the contents of the specified variable from the environment block of the calling process.</summary>
		/// <param name="lpName">The name of the environment variable.</param>
		/// <param name="lpBuffer">
		/// A pointer to a buffer that receives the contents of the specified environment variable as a null-terminated string. An
		/// environment variable has a maximum size limit of 32,767 characters, including the null-terminating character.
		/// </param>
		/// <param name="nSize">
		/// The size of the buffer pointed to by the lpBuffer parameter, including the null-terminating character, in characters.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the number of characters stored in the buffer pointed to by lpBuffer, not including
		/// the terminating null character.
		/// </para>
		/// <para>
		/// If lpBuffer is not large enough to hold the data, the return value is the buffer size, in characters, required to hold the string
		/// and its terminating null character and the contents of lpBuffer are undefined.
		/// </para>
		/// <para>
		/// If the function fails, the return value is zero. If the specified environment variable was not found in the environment block,
		/// <c>GetLastError</c> returns ERROR_ENVVAR_NOT_FOUND.
		/// </para>
		/// </returns>
		// DWORD WINAPI GetEnvironmentVariable( _In_opt_ LPCTSTR lpName, _Out_opt_ LPTSTR lpBuffer, _In_ DWORD nSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683188(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683188")]
		public static extern uint GetEnvironmentVariable(string lpName, StringBuilder lpBuffer, uint nSize);

		/// <summary>Retrieves a handle to the specified standard device (standard input, standard output, or standard error).</summary>
		/// <param name="nStdHandle">
		/// <para>The standard device. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STD_INPUT_HANDLE (DWORD)-10</term>
		/// <term>The standard input device. Initially, this is the console input buffer, CONIN$.</term>
		/// </item>
		/// <item>
		/// <term>STD_OUTPUT_HANDLE (DWORD)-11</term>
		/// <term>The standard output device. Initially, this is the active console screen buffer, CONOUT$.</term>
		/// </item>
		/// <item>
		/// <term>STD_ERROR_HANDLE (DWORD)-12</term>
		/// <term>The standard error device. Initially, this is the active console screen buffer, CONOUT$.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is a handle to the specified device, or a redirected handle set by a previous call to
		/// <c>SetStdHandle</c>. The handle has <c>GENERIC_READ</c> and <c>GENERIC_WRITE</c> access rights, unless the application has used
		/// <c>SetStdHandle</c> to set a standard handle with lesser access.
		/// </para>
		/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>
		/// If an application does not have associated standard handles, such as a service running on an interactive desktop, and has not
		/// redirected them, the return value is <c>NULL</c>.
		/// </para>
		/// </returns>
		// HANDLE WINAPI GetStdHandle( _In_ DWORD nStdHandle ); https://docs.microsoft.com/en-us/windows/console/getstdhandle
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h")]
		public static extern HFILE GetStdHandle(StdHandleType nStdHandle);

		/// <summary>Determines whether the current directory should be included in the search path for the specified executable.</summary>
		/// <param name="ExeName">The name of the executable file.</param>
		/// <returns>
		/// If the current directory should be part of the search path, the return value is TRUE. Otherwise, the return value is FALSE.
		/// </returns>
		// BOOL WINAPI NeedCurrentDirectoryForExePath( _In_ LPCTSTR ExeName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684269(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684269")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool NeedCurrentDirectoryForExePath(string ExeName);

		/// <summary>Searches for a specified file in a specified path.</summary>
		/// <param name="lpPath">
		/// <para>The path to be searched for the file.</para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the function searches for a matching file using a registry-dependent system search path. For
		/// more information, see the Remarks section.
		/// </para>
		/// </param>
		/// <param name="lpFileName">The name of the file for which to search.</param>
		/// <param name="lpExtension">
		/// <para>
		/// The extension to be added to the file name when searching for the file. The first character of the file name extension must be a
		/// period (.). The extension is added only if the specified file name does not end with an extension.
		/// </para>
		/// <para>If a file name extension is not required or if the file name contains an extension, this parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="nBufferLength">
		/// The size of the buffer that receives the valid path and file name (including the terminating null character), in <c>TCHARs</c>.
		/// </param>
		/// <param name="lpBuffer">
		/// A pointer to the buffer to receive the path and file name of the file found. The string is a null-terminated string.
		/// </param>
		/// <param name="lpFilePart">
		/// A pointer to the variable to receive the address (within lpBuffer) of the last component of the valid path and file name, which
		/// is the address of the character immediately following the final backslash (\) in the path.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the value returned is the length, in <c>TCHARs</c>, of the string that is copied to the buffer, not
		/// including the terminating null character. If the return value is greater than nBufferLength, the value returned is the size of
		/// the buffer that is required to hold the path, including the terminating null character.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// DWORD WINAPI SearchPath( _In_opt_ LPCTSTR lpPath, _In_ LPCTSTR lpFileName, _In_opt_ LPCTSTR lpExtension, _In_ DWORD nBufferLength,
		// _Out_ LPTSTR lpBuffer, _Out_opt_ LPTSTR *lpFilePart); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365527(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "aa365527")]
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		public static extern uint SearchPath([In, Optional] string lpPath, string lpFileName, [In, Optional] string lpExtension, uint nBufferLength, StringBuilder lpBuffer, out IntPtr lpFilePart);

		/// <summary>Changes the current directory for the current process.</summary>
		/// <param name="lpPathName">
		/// <para>
		/// The path to the new current directory. This parameter may specify a relative path or a full path. In either case, the full path
		/// of the specified directory is calculated and stored as the current directory. For more information, see File Names, Paths, and Namespaces.
		/// </para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>
		/// The final character before the null character must be a backslash ('\'). If you do not specify the backslash, it will be added
		/// for you; therefore, specify <c>MAX_PATH</c>-2 characters for the path unless you include the trailing backslash, in which case,
		/// specify <c>MAX_PATH</c>-1 characters for the path.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetCurrentDirectory( _In_ LPCTSTR lpPathName); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365530(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa365530")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetCurrentDirectory(string lpPathName);

		/// <summary>Sets the environment strings.</summary>
		/// <param name="NewEnvironment">
		/// The new environment strings. List of unicode null terminated strings with a double null termination at the end.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		[PInvokeData("ProcessEnv.h", MSDNShortId = "")]
		[DllImport(Lib.Kernel32, SetLastError = true, EntryPoint = "SetEnvironmentStringsW", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetEnvironmentStrings([In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Unicode")] string[] NewEnvironment);

		/// <summary>Sets the contents of the specified environment variable for the current process.</summary>
		/// <param name="lpName">
		/// The name of the environment variable. The operating system creates the environment variable if it does not exist and lpValue is
		/// not NULL.
		/// </param>
		/// <param name="lpValue">
		/// <para>
		/// The contents of the environment variable. The maximum size of a user-defined environment variable is 32,767 characters. For more
		/// information, see Environment Variables.
		/// </para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> The total size of the environment block for a process may not exceed 32,767 characters.
		/// </para>
		/// <para>If this parameter is NULL, the variable is deleted from the current process's environment.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetEnvironmentVariable( _In_ LPCTSTR lpName, _In_opt_ LPCTSTR lpValue); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686206(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686206")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetEnvironmentVariable(string lpName, [Optional] string lpValue);

		/// <summary>Sets the handle for the specified standard device (standard input, standard output, or standard error).</summary>
		/// <param name="nStdHandle">
		/// <para>The standard device for which the handle is to be set. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STD_INPUT_HANDLE (DWORD)-10</term>
		/// <term>The standard input device.</term>
		/// </item>
		/// <item>
		/// <term>STD_OUTPUT_HANDLE (DWORD)-11</term>
		/// <term>The standard output device.</term>
		/// </item>
		/// <item>
		/// <term>STD_ERROR_HANDLE (DWORD)-12</term>
		/// <term>The standard error device.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="hHandle">The handle for the standard device.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetStdHandle( _In_ DWORD nStdHandle, _In_ HANDLE hHandle ); https://docs.microsoft.com/en-us/windows/console/setstdhandle
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetStdHandle(StdHandleType nStdHandle, HFILE hHandle);

		/// <summary>Sets the handle for the specified standard device and returns the previous one</summary>
		/// <param name="nStdHandle">The standard handle to replace. Can be STD_INPUT_HANDLE, STD_OUTPUT_HANDLE or STD_ERROR_HANDLE</param>
		/// <param name="hHandle">The new handle</param>
		/// <param name="phPrevValue">
		/// A pointer to a handle that receives the previous value. Can be NULL in which case the function behaves exactly as SetStdHandle
		/// </param>
		/// <returns>Non-zero if the function succeeds, zero otherwise. More information is available via GetLastError</returns>
		// BOOL WINAPI SetStdHandleEx (DWORD nStdHandle, HANDLE hHandle, HANDLE* phPrevValue) http://undoc.airesoft.co.uk/kernel32.dll/SetStdHandleEx.php
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetStdHandleEx(StdHandleType nStdHandle, HFILE hHandle, out HFILE phPrevValue);

		[DllImport(Lib.Kernel32, SetLastError = false, EntryPoint = "GetCommandLine", CharSet = CharSet.Auto)]
		private static extern IntPtr GetCommandLineInternal();

		[DllImport(Lib.Kernel32, SetLastError = false, EntryPoint = "GetEnvironmentStrings", CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683187")]
		private static extern IntPtr InternalGetEnvironmentStrings();
	}
}