using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Determines whether the process is running in the specified job.</summary>
		/// <param name="ProcessHandle">
		/// <para>
		/// A handle to the process to be tested. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right. For more
		/// information, see Process Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the PROCESS_QUERY_INFORMATION access right.</para>
		/// </param>
		/// <param name="JobHandle">
		/// <para>A handle to the job. If this parameter is NULL, the function tests if the process is running under any job.</para>
		/// <para>
		/// If this parameter is not NULL, the handle must have the JOB_OBJECT_QUERY access right. For more information, see Job Object Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="Result">A pointer to a value that receives TRUE if the process is running in the job, and FALSE otherwise.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI IsProcessInJob( _In_ HANDLE ProcessHandle, _In_opt_ HANDLE JobHandle, _Out_ PBOOL Result);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms684127(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684127")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsProcessInJob([In] IntPtr ProcessHandle, [In] IntPtr JobHandle, [MarshalAs(UnmanagedType.Bool)] out bool Result);
	}
}