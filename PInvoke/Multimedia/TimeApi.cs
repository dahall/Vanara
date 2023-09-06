namespace Vanara.PInvoke;

/// <summary>Items from the WinMm.dll</summary>
public static partial class WinMm
{
	/// <summary>The <c>timeBeginPeriod</c> function requests a minimum resolution for periodic timers.</summary>
	/// <param name="uPeriod">
	/// Minimum timer resolution, in milliseconds, for the application or device driver. A lower value specifies a higher (more
	/// accurate) resolution.
	/// </param>
	/// <returns>
	/// Returns <c>TIMERR_NOERROR</c> if successful or <c>TIMERR_NOCANDO</c> if the resolution specified in uPeriod is out of range.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call this function immediately before using timer services, and call the timeEndPeriod function immediately after you are
	/// finished using the timer services.
	/// </para>
	/// <para>
	/// You must match each call to <c>timeBeginPeriod</c> with a call to timeEndPeriod, specifying the same minimum resolution in both
	/// calls. An application can make multiple <c>timeBeginPeriod</c> calls as long as each call is matched with a call to <c>timeEndPeriod</c>.
	/// </para>
	/// <para>
	/// Prior to Windows 10, version 2004, this function affects a global Windows setting. For all processes Windows uses the lowest
	/// value (that is, highest resolution) requested by any process. Starting with Windows 10, version 2004, this function no longer
	/// affects global timer resolution. For processes which call this function, Windows uses the lowest value (that is, highest
	/// resolution) requested by any process. For processes which have not called this function, Windows does not guarantee a higher
	/// resolution than the default system resolution.
	/// </para>
	/// <para>
	/// Setting a higher resolution can improve the accuracy of time-out intervals in wait functions. However, it can also reduce
	/// overall system performance, because the thread scheduler switches tasks more often. High resolutions can also prevent the CPU
	/// power management system from entering power-saving modes. Setting a higher resolution does not improve the accuracy of the
	/// high-resolution performance counter.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/timeapi/nf-timeapi-timebeginperiod MMRESULT timeBeginPeriod( UINT uPeriod );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("timeapi.h", MSDNShortId = "NF:timeapi.timeBeginPeriod")]
	public static extern MMRESULT timeBeginPeriod(uint uPeriod);

	/// <summary>The <c>timeEndPeriod</c> function clears a previously set minimum timer resolution.</summary>
	/// <param name="uPeriod">Minimum timer resolution specified in the previous call to the timeBeginPeriod function.</param>
	/// <returns>
	/// Returns <c>TIMERR_NOERROR</c> if successful or <c>TIMERR_NOCANDO</c> if the resolution specified in uPeriod is out of range.
	/// </returns>
	/// <remarks>
	/// <para>Call this function immediately after you are finished using timer services.</para>
	/// <para>
	/// You must match each call to timeBeginPeriod with a call to <c>timeEndPeriod</c>, specifying the same minimum resolution in both
	/// calls. An application can make multiple <c>timeBeginPeriod</c> calls as long as each call is matched with a call to <c>timeEndPeriod</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/timeapi/nf-timeapi-timeendperiod MMRESULT timeEndPeriod( UINT uPeriod );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("timeapi.h", MSDNShortId = "NF:timeapi.timeEndPeriod")]
	public static extern MMRESULT timeEndPeriod(uint uPeriod);

	/// <summary>The <c>timeGetDevCaps</c> function queries the timer device to determine its resolution.</summary>
	/// <param name="ptc">
	/// A pointer to a TIMECAPS structure. This structure is filled with information about the resolution of the timer device.
	/// </param>
	/// <param name="cbtc">The size, in bytes, of the TIMECAPS structure.</param>
	/// <returns>
	/// <para>Returns <c>MMSYSERR_NOERROR</c> if successful or an error code otherwise. Possible error codes include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMSYSERR_ERROR</term>
	/// <term>General error code.</term>
	/// </item>
	/// <item>
	/// <term>TIMERR_NOCANDO</term>
	/// <term>The ptc parameter is NULL, or the cbtc parameter is invalid, or some other error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/timeapi/nf-timeapi-timegetdevcaps MMRESULT timeGetDevCaps( LPTIMECAPS ptc,
	// UINT cbtc );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("timeapi.h", MSDNShortId = "NF:timeapi.timeGetDevCaps")]
	public static extern MMRESULT timeGetDevCaps(out TIMECAPS ptc, uint cbtc = 8);

	/// <summary>
	/// The <c>timeGetSystemTime</c> function retrieves the system time, in milliseconds. The system time is the time elapsed since
	/// Windows was started. This function works very much like the timeGetTime function. See <c>timeGetTime</c> for details of these
	/// functions' operation.
	/// </summary>
	/// <param name="pmmt">Pointer to an MMTIME structure.</param>
	/// <param name="cbmmt">Size, in bytes, of the MMTIME structure.</param>
	/// <returns>If successful, returns <c>TIMERR_NOERROR</c>. Otherwise, returns an error code.</returns>
	/// <remarks>The system time is returned in the <c>ms</c> member of the MMTIME structure.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/timeapi/nf-timeapi-timegetsystemtime MMRESULT timeGetSystemTime( LPMMTIME
	// pmmt, UINT cbmmt );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("timeapi.h", MSDNShortId = "NF:timeapi.timeGetSystemTime")]
	public static extern MMRESULT timeGetSystemTime(out MMTIME pmmt, uint cbmmt = 8);

	/// <summary>
	/// The <c>timeGetTime</c> function retrieves the system time, in milliseconds. The system time is the time elapsed since Windows
	/// was started.
	/// </summary>
	/// <returns>Returns the system time, in milliseconds.</returns>
	/// <remarks>
	/// <para>
	/// The only difference between this function and the timeGetSystemTime function is that <c>timeGetSystemTime</c> uses the MMTIME
	/// structure to return the system time. The <c>timeGetTime</c> function has less overhead than <c>timeGetSystemTime</c>.
	/// </para>
	/// <para>
	/// Note that the value returned by the <c>timeGetTime</c> function is a <c>DWORD</c> value. The return value wraps around to 0
	/// every 2^32 milliseconds, which is about 49.71 days. This can cause problems in code that directly uses the <c>timeGetTime</c>
	/// return value in computations, particularly where the value is used to control code execution. You should always use the
	/// difference between two <c>timeGetTime</c> return values in computations.
	/// </para>
	/// <para>
	/// The default precision of the <c>timeGetTime</c> function can be five milliseconds or more, depending on the machine. You can use
	/// the timeBeginPeriod and timeEndPeriod functions to increase the precision of <c>timeGetTime</c>. If you do so, the minimum
	/// difference between successive values returned by <c>timeGetTime</c> can be as large as the minimum period value set using
	/// <c>timeBeginPeriod</c> and <c>timeEndPeriod</c>. Use the QueryPerformanceCounter and QueryPerformanceFrequency functions to
	/// measure short time intervals at a high resolution.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/timeapi/nf-timeapi-timegettime DWORD timeGetTime();
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("timeapi.h", MSDNShortId = "NF:timeapi.timeGetTime")]
	public static extern uint timeGetTime();

	/// <summary>The <c>TIMECAPS</c> structure contains information about the resolution of the timer.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/timeapi/ns-timeapi-timecaps typedef struct timecaps_tag { UINT wPeriodMin;
	// UINT wPeriodMax; } TIMECAPS, *PTIMECAPS, *NPTIMECAPS, *LPTIMECAPS;
	[PInvokeData("timeapi.h", MSDNShortId = "NS:timeapi.timecaps_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TIMECAPS
	{
		/// <summary>The minimum supported resolution, in milliseconds.</summary>
		public uint wPeriodMin;

		/// <summary>The maximum supported resolution, in milliseconds.</summary>
		public uint wPeriodMax;
	}
}