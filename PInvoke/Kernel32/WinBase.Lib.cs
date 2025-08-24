using System.Collections.Generic;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>Retrieves the application-specific portion of the search path used to locate DLLs for the application.</summary>
	/// <param name="nBufferLength">The size of the output buffer, in characters.</param>
	/// <param name="lpBuffer">A pointer to a buffer that receives the application-specific portion of the search path.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the length of the string copied to lpBuffer, in characters, not including the
	/// terminating null character. If the return value is greater than nBufferLength, it specifies the size of the buffer required for
	/// the path.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// DWORD WINAPI GetDllDirectory( _In_ DWORD nBufferLength, _Out_ LPTSTR lpBuffer); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683186(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms683186")]
	public static extern uint GetDllDirectory(uint nBufferLength, [Optional, SizeDef(nameof(nBufferLength), SizingMethod.Query | SizingMethod.QueryResultInReturn)] StringBuilder? lpBuffer);

	/// <summary>Retrieves the application-specific portion of the search path used to locate DLLs for the application.</summary>
	/// <returns>The application-specific portion of the search path.</returns>
	public static string GetDllDirectory() => FunctionHelper.CallMethodWithStrBuf((StringBuilder? sb, ref uint sz) => GetDllDirectory(sz, sb), out var str, (sz, r) => r <= sz) > 0 ? str! : throw Win32Error.GetExceptionForLastError()!;

	/// <summary>
	/// <para>Loads and executes an application or creates a new instance of an existing application.</para>
	/// <para>
	///   <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the
	/// CreateProcess function.
	/// </para>
	/// </summary>
	/// <param name="lpModuleName"><para>
	/// The file name of the application to be run. When specifying a path, be sure to use backslashes (), not forward slashes (/). If
	/// the lpModuleName parameter does not contain a directory path, the system searches for the executable file in this order:
	/// </para>
	/// <list type="number">
	///   <item>
	///     <term>The directory from which the application loaded.</term>
	///   </item>
	///   <item>
	///     <term>The current directory.</term>
	///   </item>
	///   <item>
	///     <term>The system directory. Use the GetSystemDirectory function to get the path of this directory.</term>
	///   </item>
	///   <item>
	///     <term>
	/// The 16-bit system directory. There is no function that obtains the path of this directory, but it is searched. The name of this
	/// directory is System.
	/// </term>
	///   </item>
	///   <item>
	///     <term>The Windows directory. Use the GetWindowsDirectory function to get the path of this directory.</term>
	///   </item>
	///   <item>
	///     <term>The directories that are listed in the PATH environment variable.</term>
	///   </item>
	/// </list></param>
	/// <param name="lpParameterBlock"><para>A pointer to an application-defined <c>LOADPARMS32</c> structure that defines the new application's parameter block.</para>
	/// <para>
	/// Set all unused members to NULL, except for <c>lpCmdLine</c>, which must point to a null-terminated string if it is not used. For
	/// more information, see Remarks.
	/// </para></param>
	/// <returns>
	/// <para>If the function succeeds, the return value is greater than 31.</para>
	/// <para>If the function fails, the return value is an error value, which may be one of the following values.</para>
	/// <list type="table">
	///   <listheader>
	///     <term>Return code/value</term>
	///     <term>Description</term>
	///   </listheader>
	///   <item>
	///     <term>0</term>
	///     <term>The system is out of memory or resources.</term>
	///   </item>
	///   <item>
	///     <term>ERROR_BAD_FORMAT 11L</term>
	///     <term>The .exe file is invalid.</term>
	///   </item>
	///   <item>
	///     <term>ERROR_FILE_NOT_FOUND 2L</term>
	///     <term>The specified file was not found.</term>
	///   </item>
	///   <item>
	///     <term>ERROR_PATH_NOT_FOUND 3L</term>
	///     <term>The specified path was not found.</term>
	///   </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>LOADPARMS32</c> structure has the following form:</para>
	/// <list type="table">
	///   <listheader>
	///     <term>Member</term>
	///     <term>Meaning</term>
	///   </listheader>
	///   <item>
	///     <term>lpEnvAddress</term>
	///     <term>
	/// Pointer to an array of null-terminated strings that supply the environment strings for the new process. The array has a value of
	/// NULL as its last entry. A value of NULL for this parameter causes the new process to start with the same environment as the
	/// calling process.
	/// </term>
	///   </item>
	///   <item>
	///     <term>lpCmdLine</term>
	///     <term>
	/// Pointer to a Pascal-style string that contains a correctly formed command line. The first byte of the string contains the number
	/// of bytes in the string. The remainder of the string contains the command line arguments, excluding the name of the child process.
	/// If there are no command line arguments, this parameter must point to a zero length string; it cannot be NULL.
	/// </term>
	///   </item>
	///   <item>
	///     <term>lpCmdShow</term>
	///     <term>
	/// Pointer to a structure containing two WORD values. The first value must always be set to two. The second value specifies how the
	/// application window is to be shown and is used to supply the wShowWindow member of the STARTUPINFO structure to the CreateProcess
	/// function. See the description of the nCmdShow parameter of the ShowWindow function for a list of acceptable values.
	/// </term>
	///   </item>
	///   <item>
	///     <term>dwReserved</term>
	///     <term>This parameter is reserved; it must be zero.</term>
	///   </item>
	/// </list>
	/// <para>
	/// Applications should use the CreateProcess function instead of <c>LoadModule</c>. The <c>LoadModule</c> function calls
	/// CreateProcess by forming the parameters as follows.
	/// </para>
	/// <list type="table">
	///   <listheader>
	///     <term>CreateProcess parameter</term>
	///     <term>Argument used</term>
	///   </listheader>
	///   <item>
	///     <term>lpszApplicationName</term>
	///     <term>lpModuleName</term>
	///   </item>
	///   <item>
	///     <term>lpszCommandLine</term>
	///     <term>lpParameterBlock.lpCmdLine</term>
	///   </item>
	///   <item>
	///     <term>lpProcessAttributes</term>
	///     <term>NULL</term>
	///   </item>
	///   <item>
	///     <term>lpThreadAttributes</term>
	///     <term>NULL</term>
	///   </item>
	///   <item>
	///     <term>bInheritHandles</term>
	///     <term>FALSE</term>
	///   </item>
	///   <item>
	///     <term>dwCreationFlags</term>
	///     <term>0</term>
	///   </item>
	///   <item>
	///     <term>lpEnvironment</term>
	///     <term>lpParameterBlock.lpEnvAddress</term>
	///   </item>
	///   <item>
	///     <term>lpCurrentDirectory</term>
	///     <term>NULL</term>
	///   </item>
	///   <item>
	///     <term>lpStartupInfo</term>
	///     <term>
	/// The structure is initialized to zero. The cb member is set to the size of the structure. The wShowWindow member is set to the
	/// value of the second word of lpParameterBlock.lpCmdShow.
	/// </term>
	///   </item>
	///   <item>
	///     <term>lpProcessInformation.hProcess</term>
	///     <term>The handle is immediately closed.</term>
	///   </item>
	///   <item>
	///     <term>lpProcessInformation.hThread</term>
	///     <term>The handle is immediately closed.</term>
	///   </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-loadmodule DWORD LoadModule( LPCSTR lpModuleName, LPVOID
	// lpParameterBlock );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "80571b80-851a-4272-bfa6-d26e217e714a")]
	public static extern uint LoadModule([MarshalAs(UnmanagedType.LPStr)] string lpModuleName, [In] LOADPARMS32 lpParameterBlock);

	/// <summary>Adds a directory to the search path used to locate DLLs for the application.</summary>
	/// <param name="lpPathName">
	/// The directory to be added to the search path. If this parameter is an empty string (""), the call removes the current directory
	/// from the default DLL search order. If this parameter is NULL, the function restores the default search order.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetDllDirectory( _In_opt_ LPCTSTR lpPathName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686203(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms686203")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetDllDirectory([Optional] string? lpPathName);

	/// <summary>Defines the new application's parameter block.</summary>
	[PInvokeData("winbase.h", MSDNShortId = "80571b80-851a-4272-bfa6-d26e217e714a")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public class LOADPARMS32 : IDisposable
	{
		/// <summary>
		/// Pointer to an array of null-terminated strings that supply the environment strings for the new process. The array has a value
		/// of NULL as its last entry. A value of NULL for this parameter causes the new process to start with the same environment as
		/// the calling process.
		/// </summary>
		private IntPtr lpEnvAddress;

		/// <summary>
		/// Pointer to a Pascal-style string that contains a correctly formed command line. The first byte of the string contains the
		/// number of bytes in the string. The remainder of the string contains the command line arguments, excluding the name of the
		/// child process. If there are no command line arguments, this parameter must point to a zero length string; it cannot be NULL.
		/// </summary>
		private IntPtr lpCmdLine;

		/// <summary>
		/// Pointer to a structure containing two WORD values. The first value must always be set to two. The second value specifies how
		/// the application window is to be shown and is used to supply the wShowWindow member of the STARTUPINFO structure to the
		/// CreateProcess function. See the description of the nCmdShow parameter of the ShowWindow function for a list of acceptable values.
		/// </summary>
		private IntPtr lpCmdShow;

		/// <summary>This parameter is reserved; it must be zero.</summary>
		private readonly uint dwReserved;

		/// <summary>Initializes a new instance of the <see cref="LOADPARMS32"/> class.</summary>
		public LOADPARMS32()
		{
			lpCmdShow = Marshal.AllocHGlobal(4);
			Marshal.WriteInt16(lpCmdShow, 2);
			lpCmdLine = StringHelper.AllocChars(1, Marshal.AllocHGlobal, CharSet.Ansi);
		}

		/// <summary>A string that contains a correctly formed command line, excluding the name of the child process.</summary>
		public string CmdLine
		{
			get
			{
				var l = Marshal.ReadByte(lpCmdLine);
				return l == 0 ? string.Empty : StringHelper.GetString(lpCmdLine.Offset(1), CharSet.Ansi, l)!;
			}
			set
			{
				Marshal.FreeHGlobal(lpCmdLine);
				if (string.IsNullOrEmpty(value))
					lpCmdLine = StringHelper.AllocChars(1, Marshal.AllocHGlobal, CharSet.Ansi);
				else
				{
					lpCmdLine = Marshal.AllocHGlobal(value.Length + 1);
					Marshal.WriteByte(lpCmdLine, (byte)value.Length);
					StringHelper.Write(value, lpCmdLine.Offset(1), out _, false, CharSet.Ansi);
				}
			}
		}

		/// <summary>
		/// Specifies how application window is to be shown and is used to supply the wShowWindow member of the STARTUPINFO structure to
		/// the CreateProcess function.
		/// </summary>
		public ShowWindowCommand CmdShow
		{
			get => (ShowWindowCommand)Marshal.ReadInt16(lpCmdShow, 2);
			set => Marshal.WriteInt16(lpCmdShow, 2, (short)value);
		}

		/// <summary>
		/// A list of strings that supply the environment strings for the new process. A value of <see langword="null"/> for this
		/// parameter causes the new process to start with the same environment as the calling process.
		/// </summary>
		public IEnumerable<string> EnvAddress
		{
			get => lpEnvAddress.ToStringEnum(CharSet.Ansi);
			set
			{
				if (lpEnvAddress != IntPtr.Zero)
					Marshal.FreeHGlobal(lpEnvAddress);
				lpEnvAddress = value is null ? IntPtr.Zero : value.MarshalToPtr(StringListPackMethod.Concatenated, Marshal.AllocHGlobal, out _, CharSet.Ansi);
			}
		}

		void IDisposable.Dispose()
		{
			Marshal.FreeHGlobal(lpEnvAddress);
			Marshal.FreeHGlobal(lpCmdLine);
			Marshal.FreeHGlobal(lpCmdShow);
			lpEnvAddress = lpCmdLine = lpCmdShow = IntPtr.Zero;
		}
	}
}