using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Retrieves the processor group affinity of the specified process.</summary>
		/// <param name="hProcess">
		/// <para>A handle to the process.</para>
		/// <para>
		/// This handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right. For more information, see
		/// Process Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="GroupCount">
		/// On input, specifies the number of elements in GroupArray array. On output, specifies the number of processor groups written to
		/// the array. If the array is too small, the function fails with ERROR_INSUFFICIENT_BUFFER and sets the GroupCount parameter to the
		/// number of elements required.
		/// </param>
		/// <param name="GroupArray">
		/// An array of processor group numbers. A group number is included in the array if a thread in the process is assigned to a
		/// processor in the group.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use <c>GetLastError</c>.</para>
		/// <para>
		/// If the error value is ERROR_INSUFFICIENT_BUFFER, the GroupCount parameter contains the required buffer size in number of elements.
		/// </para>
		/// </returns>
		// BOOL GetProcessGroupAffinity( _In_ HANDLE hProcess, _Inout_ PUSHORT GroupCount, _Out_ PUSHORT GroupArray); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405496(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd405496")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessGroupAffinity(HPROCESS hProcess, ref ushort GroupCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] GroupArray);

		/// <summary>Retrieves the processor group affinity of the specified thread.</summary>
		/// <param name="hThread">
		/// <para>A handle to the thread for which the processor group affinity is desired.</para>
		/// <para>
		/// The handle must have the THREAD_QUERY_INFORMATION or THREAD_QUERY_LIMITED_INFORMATION access right. For more information, see
		/// Thread Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="GroupAffinity">A pointer to a GROUP_AFFINITY structure to receive the group affinity of the thread.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL GetThreadGroupAffinity( _In_ HANDLE hThread, _Out_ PGROUP_AFFINITY GroupAffinity); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405498(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd405498")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetThreadGroupAffinity(HTHREAD hThread, out GROUP_AFFINITY GroupAffinity);

		/// <summary>Sets the processor group affinity for the specified thread.</summary>
		/// <param name="hThread">
		/// <para>A handle to the thread.</para>
		/// <para>The handle must have the THREAD_SET_INFORMATION access right. For more information, see Thread Security and Access Rights.</para>
		/// </param>
		/// <param name="GroupAffinity">
		/// A <c>GROUP_AFFINITY</c> structure that specifies the processor group affinity to be used for the specified thread.
		/// </param>
		/// <param name="PreviousGroupAffinity">
		/// A pointer to a <c>GROUP_AFFINITY</c> structure to receive the thread's previous group affinity. This parameter can be NULL.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL SetThreadGroupAffinity( _In_ HANDLE hThread, _In_ const GROUP_AFFINITY *GroupAffinity, _Out_opt_ PGROUP_AFFINITY
		// PreviousGroupAffinity); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405516(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd405516")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetThreadGroupAffinity(HTHREAD hThread, in GROUP_AFFINITY GroupAffinity, out GROUP_AFFINITY PreviousGroupAffinity);
	}
}