using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>Returns the system DPI.</summary>
		/// <returns>The system DPI value.</returns>
		/// <remarks>
		/// <para>
		/// The return value will be dependent based upon the calling context. If the current thread has a DPI_AWARENESS value of
		/// <c>DPI_AWARENESS_UNAWARE</c>, the return value will be 96. That is because the current context always assumes a DPI of 96. For
		/// any other <c>DPI_AWARENESS</c> value, the return value will be the actual system DPI.
		/// </para>
		/// <para>You should not cache the system DPI, but should use <c>GetDpiForSystem</c> whenever you need the system DPI value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdpiforsystem UINT GetDpiForSystem( );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "B744EC4A-DB78-4654-B50F-C27CB7702899")]
		public static extern uint GetDpiForSystem();

		/// <summary>
		/// Retrieves the system DPI associated with a given process. This is useful for avoiding compatibility issues that arise from
		/// sharing DPI-sensitive information between multiple system-aware processes with different system DPI values.
		/// </summary>
		/// <param name="hProcess">The handle for the process to examine. If this value is null, this API behaves identically to GetDpiForSystem.</param>
		/// <returns>The process's system DPI value.</returns>
		/// <remarks>
		/// The return value will be dependent based upon the process passed as a parameter. If the specified process has a DPI_AWARENESS
		/// value of <c>DPI_AWARENESS_UNAWARE</c>, the return value will be 96. That is because the current context always assumes a DPI of
		/// 96. For any other <c>DPI_AWARENESS</c> value, the return value will be the actual system DPI of the given process.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getsystemdpiforprocess UINT GetSystemDpiForProcess( HANDLE
		// hProcess );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "94236ECF-E69A-4D77-AABA-D43FE8DF8203")]
		public static extern uint GetSystemDpiForProcess(HPROCESS hProcess);

		/// <summary>Retrieves the specified system metric or system configuration setting taking into account a provided DPI.</summary>
		/// <param name="nIndex">The system metric or configuration setting to be retrieved. See GetSystemMetrics for the possible values.</param>
		/// <param name="dpi">The DPI to use for scaling the metric.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// This function returns the same result as GetSystemMetrics but scales it according to an arbitrary DPI you provide if appropriate.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getsystemmetricsfordpi int GetSystemMetricsForDpi( int
		// nIndex, UINT dpi );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "E95BB417-81FA-4824-BE68-A1E3E003F8E0")]
		public static extern int GetSystemMetricsForDpi(SystemMetric nIndex, uint dpi);

		/// <summary>Retrieves the value of one of the system-wide parameters, taking into account the provided DPI value.</summary>
		/// <param name="uiAction">
		/// The system-wide parameter to be retrieved. This function is only intended for use with <c>SPI_GETICONTITLELOGFONT</c>,
		/// <c>SPI_GETICONMETRICS</c>, or <c>SPI_GETNONCLIENTMETRICS</c>. See SystemParametersInfo for more information on these values.
		/// </param>
		/// <param name="uiParam">
		/// A parameter whose usage and format depends on the system parameter being queried. For more information about system-wide
		/// parameters, see the uiAction parameter. If not otherwise indicated, you must specify zero for this parameter.
		/// </param>
		/// <param name="pvParam">
		/// A parameter whose usage and format depends on the system parameter being queried. For more information about system-wide
		/// parameters, see the uiAction parameter. If not otherwise indicated, you must specify <c>NULL</c> for this parameter. For
		/// information on the <c>PVOID</c> datatype, see Windows Data Types.
		/// </param>
		/// <param name="fWinIni">Has no effect for with this API. This parameter only has an effect if you're setting parameter.</param>
		/// <param name="dpi">The DPI to use for scaling the metric.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function returns a similar result as SystemParametersInfo, but scales it according to an arbitrary DPI you provide (if
		/// appropriate). It only scales with the following possible values for uiAction: <c>SPI_GETICONTITLELOGFONT</c>,
		/// <c>SPI_GETICONMETRICS</c>, <c>SPI_GETNONCLIENTMETRICS</c>. Other possible uiAction values do not provide ForDPI behavior, and
		/// therefore this function returns 0 if called with them.
		/// </para>
		/// <para>
		/// For uiAction values that contain strings within their associated structures, only Unicode (LOGFONTW) strings are supported in
		/// this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-systemparametersinfofordpi BOOL
		// SystemParametersInfoForDpi( UINT uiAction, UINT uiParam, PVOID pvParam, UINT fWinIni, UINT dpi );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "BA460A5B-5356-43A5-B232-03E6E72D15A2")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SystemParametersInfoForDpi(SPI uiAction, uint uiParam, IntPtr pvParam, uint fWinIni, uint dpi);

		/// <summary>Sets the DPI scale for which the cursors being created on this thread are intended. This value is taken into account when scaling the cursor for the specific monitor on which it is being shown.</summary>
		/// <param name="cursorDpi">
		/// <para>The 96-based DPI scale of the cursors that the application will be creating. For example, a 96 DPI value corresponds to 100% monitor scale factor, 144 DPI corresponds to 150%, and so on.</para>
		/// <para>There are two special values:</para>
		/// <para>CURSOR_CREATION_SCALING_DEFAULT – resets cursor scaling to default system behavior (as if SetThreadCursorCreationScaling was never called on this thread).</para>
		/// <para>CURSOR_CREATION_SCALING_NONE – disables all cursor scaling (the cursors created after calling SetThreadCursorCreationScaling with this parameter will never be scaled up or down on any monitor).</para>
		/// </param>
		/// <returns>The previous value set for the thread before calling this API.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setthreadcursorcreationscaling
		// UINT SetThreadCursorCreationScaling( UINT cursorDpi );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.SetThreadCursorCreationScaling")]
		public static extern uint SetThreadCursorCreationScaling(uint cursorDpi);
	}
}