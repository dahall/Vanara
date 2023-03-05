using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

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
	/// <para>If the function fails, the return value is zero. To get extended error information, use GetLastError.</para>
	/// <para>
	/// If the error value is ERROR_INSUFFICIENT_BUFFER, the GroupCount parameter contains the required buffer size in number of elements.
	/// </para>
	/// </returns>
	/// <remarks>
	/// To compile an application that uses this function, set _WIN32_WINNT &gt;= 0x0601. For more information, see Using the Windows Headers.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/processtopologyapi/nf-processtopologyapi-getprocessgroupaffinity BOOL
	// GetProcessGroupAffinity( HANDLE hProcess, PUSHORT GroupCount, PUSHORT GroupArray );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("processtopologyapi.h", MSDNShortId = "e22a4910-45dd-4eb6-9ed5-a8e0bcdfad7b")]
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
	/// <para>If the function fails, the return value is zero. To get extended error information, use GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// To compile an application that uses this function, set _WIN32_WINNT &gt;= 0x0601. For more information, see Using the Windows Headers.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/processtopologyapi/nf-processtopologyapi-getthreadgroupaffinity BOOL
	// GetThreadGroupAffinity( HANDLE hThread, PGROUP_AFFINITY GroupAffinity );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("processtopologyapi.h", MSDNShortId = "effc75be-60da-43cc-bfb3-5fb905e1404d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetThreadGroupAffinity(HTHREAD hThread, out GROUP_AFFINITY GroupAffinity);

	/// <summary>Sets the processor group affinity for the specified thread.</summary>
	/// <param name="hThread">
	/// <para>A handle to the thread.</para>
	/// <para>The handle must have the THREAD_SET_INFORMATION access right. For more information, see Thread Security and Access Rights.</para>
	/// </param>
	/// <param name="GroupAffinity">
	/// A GROUP_AFFINITY structure that specifies the processor group affinity to be used for the specified thread.
	/// </param>
	/// <param name="PreviousGroupAffinity">
	/// A pointer to a GROUP_AFFINITY structure to receive the thread's previous group affinity. This parameter can be NULL.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, use GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// To compile an application that uses this function, set _WIN32_WINNT &gt;= 0x0601. For more information, see Using the Windows Headers.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/processtopologyapi/nf-processtopologyapi-setthreadgroupaffinity BOOL
	// SetThreadGroupAffinity( HANDLE hThread, const GROUP_AFFINITY *GroupAffinity, PGROUP_AFFINITY PreviousGroupAffinity );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("processtopologyapi.h", MSDNShortId = "9f24f1bf-a63d-4318-af2a-eb3553f2b0f9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetThreadGroupAffinity(HTHREAD hThread, in GROUP_AFFINITY GroupAffinity, out GROUP_AFFINITY PreviousGroupAffinity);
}