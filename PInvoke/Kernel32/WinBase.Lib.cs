using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Retrieves the application-specific portion of the search path used to locate DLLs for the application.</summary>
		/// <param name="nBufferLength">The size of the output buffer, in characters.</param>
		/// <param name="lpBuffer">A pointer to a buffer that receives the application-specific portion of the search path.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the length of the string copied to lpBuffer, in characters, not including the terminating null
		/// character. If the return value is greater than nBufferLength, it specifies the size of the buffer required for the path.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// DWORD WINAPI GetDllDirectory( _In_ DWORD nBufferLength, _Out_ LPTSTR lpBuffer); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683186(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683186")]
		public static extern uint GetDllDirectory(uint nBufferLength, [Out] StringBuilder lpBuffer);

		/// <summary>Loads and executes an application or creates a new instance of an existing application.</summary>
		/// <param name="lpModuleName">
		/// The file name of the application to be run. When specifying a path, be sure to use backslashes (\), not forward slashes (/). If the lpModuleName
		/// parameter does not contain a directory path, the system searches for the executable file in this order:
		/// </param>
		/// <param name="lpParameterBlock">
		/// A pointer to an application-defined <c>LOADPARMS32</c> structure that defines the new application's parameter block. Set all unused members to NULL,
		/// except for <c>lpCmdLine</c>, which must point to a null-terminated string if it is not used. For more information, see Remarks.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is greater than 31.</para>
		/// <para>If the function fails, the return value is an error value, which may be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The system is out of memory or resources.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_FORMAT11L</term>
		/// <term>The .exe file is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND2L</term>
		/// <term>The specified file was not found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATH_NOT_FOUND3L</term>
		/// <term>The specified path was not found.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// DWORD WINAPI LoadModule( _In_ LPCSTR lpModuleName, _In_ LPVOID lpParameterBlock); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684183(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Ansi)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms684183")]
		public static extern Win32Error LoadModule([In] string lpModuleName, [In] IntPtr lpParameterBlock);

		/// <summary>Adds a directory to the search path used to locate DLLs for the application.</summary>
		/// <param name="lpPathName">
		/// The directory to be added to the search path. If this parameter is an empty string (""), the call removes the current directory from the default DLL
		/// search order. If this parameter is NULL, the function restores the default search order.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetDllDirectory( _In_opt_ LPCTSTR lpPathName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686203(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms686203")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetDllDirectory([In] string lpPathName);
	}
}