using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>
		/// An application-defined callback function that processes WM_TIMER messages. The <c>TIMERPROC</c> type defines a pointer to this
		/// callback function. TimerProc is a placeholder for the application-defined function name.
		/// </summary>
		/// <param name="hwnd">A handle to the window associated with the timer.</param>
		/// <param name="uMsg">The WM_TIMER message.</param>
		/// <param name="idEvent">The timer's identifier.</param>
		/// <param name="dwTime">
		/// The number of milliseconds that have elapsed since the system was started. This is the value returned by the GetTickCount function.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nc-winuser-timerproc TIMERPROC Timerproc; void Timerproc(_In_ HWND
		// hwnd, _In_ UINT uMsg, _In_ UINT_PTR idEvent, _In_ DWORD dwTime);
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("winuser.h")]
		public delegate void Timerproc(HWND hwnd, uint uMsg, UIntPtr idEvent, uint dwTime);

		/// <summary>Destroys the specified timer.</summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window associated with the specified timer. This value must be the same as the hWnd value passed to the SetTimer
		/// function that created the timer.
		/// </para>
		/// </param>
		/// <param name="uIDEvent">
		/// <para>Type: <c>UINT_PTR</c></para>
		/// <para>The timer to be destroyed. If the window handle passed to SetTimer is valid, this parameter must be the same as the nIDEvent</para>
		/// <para>
		/// value passed to <c>SetTimer</c>. If the application calls <c>SetTimer</c> with hWnd set to <c>NULL</c>, this parameter must be
		/// the timer identifier returned by <c>SetTimer</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>KillTimer</c> function does not remove WM_TIMER messages already posted to the message queue.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Destroying a Timer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-killtimer BOOL KillTimer( HWND hWnd, UINT_PTR uIDEvent );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool KillTimer([Optional] HWND hWnd, UIntPtr uIDEvent);

		/// <summary>Creates a timer with the specified time-out value.</summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window to be associated with the timer. This window must be owned by the calling thread. If a <c>NULL</c> value
		/// for hWnd is passed in along with an nIDEvent of an existing timer, that timer will be replaced in the same way that an existing
		/// non-NULL hWnd timer will be.
		/// </para>
		/// </param>
		/// <param name="nIDEvent">
		/// <para>Type: <c>UINT_PTR</c></para>
		/// <para>
		/// A nonzero timer identifier. If the hWnd parameter is <c>NULL</c>, and the nIDEvent does not match an existing timer then it is
		/// ignored and a new timer ID is generated. If the hWnd parameter is not <c>NULL</c> and the window specified by hWnd already has a
		/// timer with the value nIDEvent, then the existing timer is replaced by the new timer. When <c>SetTimer</c> replaces a timer, the
		/// timer is reset. Therefore, a message will be sent after the current time-out value elapses, but the previously set time-out value
		/// is ignored. If the call is not intended to replace an existing timer, nIDEvent should be 0 if the hWnd is <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="uElapse">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The time-out value, in milliseconds.</para>
		/// <para>
		/// If uElapse is less than <c>USER_TIMER_MINIMUM</c> (0x0000000A), the timeout is set to <c>USER_TIMER_MINIMUM</c>. If uElapse is
		/// greater than <c>USER_TIMER_MAXIMUM</c> (0x7FFFFFFF), the timeout is set to <c>USER_TIMER_MAXIMUM</c>.
		/// </para>
		/// </param>
		/// <param name="lpTimerFunc">
		/// <para>Type: <c>TIMERPROC</c></para>
		/// <para>
		/// A pointer to the function to be notified when the time-out value elapses. For more information about the function, see TimerProc.
		/// If lpTimerFunc is <c>NULL</c>, the system posts a WM_TIMER message to the application queue. The <c>hwnd</c> member of the
		/// message's MSG structure contains the value of the hWnd parameter.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>UINT_PTR</c></c></para>
		/// <para>
		/// If the function succeeds and the hWnd parameter is <c>NULL</c>, the return value is an integer identifying the new timer. An
		/// application can pass this value to the KillTimer function to destroy the timer.
		/// </para>
		/// <para>
		/// If the function succeeds and the hWnd parameter is not <c>NULL</c>, then the return value is a nonzero integer. An application
		/// can pass the value of the nIDEvent parameter to the KillTimer function to destroy the timer.
		/// </para>
		/// <para>If the function fails to create a timer, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can process WM_TIMER messages by including a <c>WM_TIMER</c> case statement in the window procedure or by
		/// specifying a TimerProc callback function when creating the timer. When you specify a <c>TimerProc</c> callback function, the
		/// default window procedure calls the callback function when it processes <c>WM_TIMER</c>. Therefore, you need to dispatch messages
		/// in the calling thread, even when you use <c>TimerProc</c> instead of processing <c>WM_TIMER</c>.
		/// </para>
		/// <para>The wParam parameter of the WM_TIMER message contains the value of the nIDEvent parameter.</para>
		/// <para>
		/// The timer identifier, nIDEvent, is specific to the associated window. Another window can have its own timer which has the same
		/// identifier as a timer owned by another window. The timers are distinct.
		/// </para>
		/// <para><c>SetTimer</c> can reuse timer IDs in the case where hWnd is <c>NULL</c>.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating a Timer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-settimer UINT_PTR SetTimer( HWND hWnd, UINT_PTR nIDEvent,
		// UINT uElapse, TIMERPROC lpTimerFunc );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		public static extern UIntPtr SetTimer([Optional] HWND hWnd, [Optional] UIntPtr nIDEvent, [Optional] uint uElapse, [Optional] Timerproc lpTimerFunc);
	}
}