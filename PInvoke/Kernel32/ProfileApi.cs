using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// Retrieves the current value of the performance counter, which is a high resolution (&lt;1us) time stamp that can be used for time-interval measurements.
		/// </summary>
		/// <param name="lpPerformanceCount">A pointer to a variable that receives the current performance-counter value, in counts.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. On systems that run Windows XP or
		/// later, the function will always succeed and will thus never return zero.
		/// </para>
		/// </returns>
		// BOOL WINAPI QueryPerformanceCounter( _Out_ LARGE_INTEGER *lpPerformanceCount);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms644904(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms644904")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

		/// <summary>
		/// Retrieves the frequency of the performance counter. The frequency of the performance counter is fixed at system boot and is consistent across all
		/// processors. Therefore, the frequency need only be queried upon application initialization, and the result can be cached.
		/// </summary>
		/// <param name="lpFrequency">
		/// A pointer to a variable that receives the current performance-counter frequency, in counts per second. If the installed hardware doesn't support a
		/// high-resolution performance counter, this parameter can be zero (this will not occur on systems that run Windows XP or later).
		/// </param>
		/// <returns>
		/// <para>If the installed hardware supports a high-resolution performance counter, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. On systems that run Windows XP or
		/// later, the function will always succeed and will thus never return zero.
		/// </para>
		/// </returns>
		// BOOL WINAPI QueryPerformanceFrequency( _Out_ LARGE_INTEGER *lpFrequency);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms644905(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms644905")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryPerformanceFrequency(out long lpFrequency);
	}
}