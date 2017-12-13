using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>
		/// The shutdown type for the <see cref="ExitWindowsEx"/> method.
		/// </summary>
		[Flags]
		public enum ExitWindowsFlags
		{
			/// <summary>
			/// Shuts down all processes running in the logon session of the process that called the ExitWindowsEx function. Then it logs the user off.
			/// <para>This flag can be used only by processes running in an interactive user's logon session.</para>
			/// </summary>
			EWX_LOGOFF = 0x00000000,
			/// <summary>
			/// Shuts down the system to a point at which it is safe to turn off the power. All file buffers have been flushed to disk, and all running processes have stopped.
			/// <para>The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.</para>
			/// <para>Specifying this flag will not turn off the power even if the system supports the power-off feature. You must specify EWX_POWEROFF to do this.</para>
			/// <para>Windows XP with SP1:  If the system supports the power-off feature, specifying this flag turns off the power.</para>
			/// </summary>
			EWX_SHUTDOWN = 0x00000001,
			/// <summary>
			/// Shuts down the system and then restarts the system.
			/// <para>The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.</para>
			/// </summary>
			EWX_REBOOT = 0x00000002,
			/// <summary>
			/// This flag has no effect if terminal services is enabled. Otherwise, the system does not send the WM_QUERYENDSESSION message. This can cause applications to lose data. Therefore, you should only use this flag in an emergency.
			/// </summary>
			EWX_FORCE = 0x00000004,
			/// <summary>
			/// Shuts down the system and turns off the power. The system must support the power-off feature.
			/// <para>The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.</para>
			/// </summary>
			EWX_POWEROFF = 0x00000008,
			/// <summary>
			/// Forces processes to terminate if they do not respond to the WM_QUERYENDSESSION or WM_ENDSESSION message within the timeout interval. For more information, see the Remarks.
			/// </summary>
			EWX_FORCEIFHUNG = 0x00000010,
			/// <summary>
			/// The ewx quickresolve
			/// </summary>
			EWX_QUICKRESOLVE = 0x00000020,
			/// <summary>
			/// Shuts down the system and then restarts it, as well as any applications that have been registered for restart using the RegisterApplicationRestart function. These application receive the WM_QUERYENDSESSION message with lParam set to the ENDSESSION_CLOSEAPP value. For more information, see Guidelines for Applications.
			/// </summary>
			EWX_RESTARTAPPS = 0x00000040,
			/// <summary>
			/// Beginning with Windows 8:  You can prepare the system for a faster startup by combining the EWX_HYBRID_SHUTDOWN flag with the EWX_SHUTDOWN flag.
			/// </summary>
			EWX_HYBRID_SHUTDOWN = 0x00400000,
			/// <summary>
			/// When combined with the EWX_REBOOT flag, will reboot to the boot options.
			/// </summary>
			EWX_BOOTOPTIONS = 0x01000000,
		}

		/// <summary>
		/// The ExitWindowsEx function either logs off the current user, shuts down the system, or shuts down and restarts the system. It sends the WM_QUERYENDSESSION message to all applications to determine if they can be terminated.
		/// </summary>
		/// <param name="uFlags">Specifies the type of shutdown.</param>
		/// <param name="dwReason">The reason for initiating the shutdown.</param>
		/// <returns>If the function succeeds, the return value is nonzero.<br></br><br>If the function fails, the return value is zero. To get extended error information, call Marshal.GetLastWin32Error.</br></returns>
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ExitWindowsEx(ExitWindowsFlags uFlags, SystemShutDownReason dwReason);

		/// <summary>
		/// Locks the workstation's display, protecting it from unauthorized use.
		/// </summary>
		/// <returns>0 on failure, non-zero for success</returns>
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool LockWorkStation();

		/// <summary>
		/// Indicates that the system cannot be shut down and sets a reason string to be displayed to the user if system shutdown is initiated.
		/// </summary>
		/// <param name="hWnd">A handle to the main window of the application.</param>
		/// <param name="reason">The reason the application must block system shutdown. This string will be truncated for display purposes after MAX_STR_BLOCKREASON characters.</param>
		/// <returns>If the call succeeds, the return value is nonzero. If the call fails, the return value is zero. To get extended error information, call GetLastError.</returns>
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShutdownBlockReasonCreate(HandleRef hWnd, [MarshalAs(UnmanagedType.LPWStr)] string reason);

		/// <summary>
		/// Indicates that the system can be shut down and frees the reason string.
		/// </summary>
		/// <param name="hWnd">A handle to the main window of the application.</param>
		/// <returns>If the call succeeds, the return value is nonzero. If the call fails, the return value is zero. To get extended error information, call GetLastError.</returns>
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShutdownBlockReasonDestroy(HandleRef hWnd);

		/// <summary>Retrieves the reason string set by the <see cref="ShutdownBlockReasonCreate"/> function.</summary>
		/// <param name="hWnd">A handle to the main window of the application.</param>
		/// <param name="pwszBuff">
		/// A pointer to a buffer that receives the reason string. If this parameter is NULL, the function retrieves the number of characters in the reason string.
		/// </param>
		/// <param name="pcchBuff">
		/// A pointer to a variable that specifies the size of the pwszBuff buffer, in characters. If the function succeeds, this variable receives the number of
		/// characters copied into the buffer, including the null-terminating character. If the buffer is too small, the variable receives the required buffer
		/// size, in characters, not including the null-terminating character.
		/// </param>
		/// <returns>
		/// If the call succeeds, the return value is nonzero. If the call fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShutdownBlockReasonQuery(HandleRef hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, ref uint pcchBuff);

		/// <summary>Retrieves the reason string set by the <see cref="ShutdownBlockReasonCreate"/> function.</summary>
		/// <param name="hWnd">A handle to the main window of the application.</param>
		/// <param name="reason">On success, receives the reason string.</param>
		/// <returns>If the call succeeds, the return value is nonzero. If the call fails, the return value is zero. To get extended error information, call GetLastError.</returns>
		public static bool ShutdownBlockReasonQuery(HandleRef hWnd, out string reason)
		{
			uint sz = 0;
			reason = null;
			if (!ShutdownBlockReasonQuery(hWnd, null, ref sz)) return false;
			var sb = new StringBuilder((int)sz);
			if (!ShutdownBlockReasonQuery(hWnd, sb, ref sz)) return false;
			reason = sb.ToString();
			return true;
		}
	}
}