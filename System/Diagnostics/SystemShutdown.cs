using System;
using Vanara.PInvoke;
using Vanara.Security.AccessControl;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.User32;

namespace Vanara.Diagnostics;

/// <summary>Provides access to system shutdown, restart, lock and notifications.</summary>
public static class SystemShutdown
{
	/// <summary>Stops a system shutdown started by using the InitiateSystemShutdown function.</summary>
	/// <param name="machineName">
	/// String that specifies the network name of the computer where the shutdown is to be stopped. If NULL or an empty string, the
	/// function stops the shutdown on the local computer.
	/// </param>
	/// <returns>0 on failure, non-zero for success</returns>
	public static bool AbortShutdown(string machineName = null) => AbortSystemShutdown(machineName);

	/// <summary>
	/// Logs off the current user, shuts down the system, or shuts down and restarts the system. It sends the WM_QUERYENDSESSION message
	/// to all applications to determine if they can be terminated.
	/// </summary>
	/// <param name="flags">Specifies the type of shutdown.</param>
	/// <param name="reason">The reason for initiating the shutdown.</param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. <br></br><br>If the function fails, the return value is zero. To get
	/// extended error information, call Marshal.GetLastWin32Error.</br>
	/// </returns>
	public static bool ExitWindows(ExitWindowsFlags flags = ExitWindowsFlags.EWX_LOGOFF, SystemShutDownReason reason = SystemShutDownReason.SHTDN_REASON_UNKNOWN)
	{
		var reqPriv = (flags & (ExitWindowsFlags.EWX_POWEROFF | ExitWindowsFlags.EWX_REBOOT | ExitWindowsFlags.EWX_SHUTDOWN)) != 0;
		using (new PrivilegedCodeBlock(reqPriv ? new[] { SystemPrivilege.Shutdown } : new SystemPrivilege[0]))
			return ExitWindowsEx(flags, reason);
	}

	/// <summary>Suspends the system by entering hibernation (S4).</summary>
	/// <param name="wakeupEventsDisabled">
	/// If this parameter is <see langword="true"/>, the system disables all wake events. If the parameter is <see langword="false"/>,
	/// any system wake events remain enabled.
	/// </param>
	/// <returns>
	/// <see langword="true"/> if the operation was successful; <see langword="false"/> if operation is not allowed by system
	/// administrator settings or account privileges.
	/// </returns>
	public static bool Hibernate(bool wakeupEventsDisabled = false) => Suspend(true, wakeupEventsDisabled);

	/// <summary>
	/// Initiates a shutdown and restart of the specified computer, and restarts any applications that have been registered for restart.
	/// </summary>
	/// <param name="machineName">
	/// The name of the computer to be shut down. If the value of this parameter is NULL, the local computer is shut down.
	/// </param>
	/// <param name="message">The message to be displayed in the interactive shutdown dialog box.</param>
	/// <param name="gracePeriod">
	/// The number of seconds to wait before shutting down the computer. If the value of this parameter is zero, the computer is shut
	/// down immediately. This value is limited to MAX_SHUTDOWN_TIMEOUT.
	/// <para>
	/// If the value of this parameter is greater than zero, and the dwShutdownFlags parameter specifies the flag
	/// SHUTDOWN_GRACE_OVERRIDE, the function fails and returns the error code ERROR_BAD_ARGUMENTS.
	/// </para>
	/// </param>
	/// <param name="flags">One or more bit flags that specify options for the shutdown.</param>
	/// <param name="reason">
	/// The reason for initiating the shutdown. This parameter must be one of the system shutdown reason codes. If this parameter is
	/// zero, the default is an undefined shutdown that is logged as "No title for this reason could be found". By default, it is also an
	/// unplanned shutdown. Depending on how the system is configured, an unplanned shutdown triggers the creation of a file that
	/// contains the system state information, which can delay shutdown. Therefore, do not use zero for this parameter.
	/// </param>
	public static void InitiateShutdown(string machineName, string message, TimeSpan gracePeriod, ShutdownFlags flags, SystemShutDownReason reason = SystemShutDownReason.SHTDN_REASON_UNKNOWN)
	{
		var graceSecs = (uint)gracePeriod.TotalSeconds;
		if (graceSecs > MAX_SHUTDOWN_TIMEOUT) throw new ArgumentOutOfRangeException(nameof(gracePeriod), $"Grace period can be no longer than {MAX_SHUTDOWN_TIMEOUT} seconds.");
		using (string.IsNullOrEmpty(machineName) ? new PrivilegedCodeBlock(SystemPrivilege.Shutdown) : new PrivilegedCodeBlock(SystemPrivilege.RemoteShutdown))
			AdvApi32.InitiateShutdown(machineName, message, graceSecs, flags, reason);
	}

	/// <summary>Initiates a shutdown and optional restart of the specified computer.</summary>
	/// <param name="machineName">
	/// String that specifies the network name of the computer to shut down. If NULL or an empty string, the function shuts down the
	/// local computer.
	/// </param>
	/// <param name="message">
	/// String that specifies a message to display in the shutdown dialog box. This parameter can be NULL if no message is required.
	/// </param>
	/// <param name="timeout">
	/// Time that the shutdown dialog box should be displayed, in seconds. While this dialog box is displayed, shutdown can be stopped by
	/// the AbortSystemShutdown function.
	/// </param>
	/// <param name="forceAppsClosed">
	/// If this parameter is TRUE, applications with unsaved changes are to be forcibly closed. If this parameter is FALSE, the system
	/// displays a dialog box instructing the user to close the applications.
	/// </param>
	/// <param name="rebootAfterShutdown">
	/// If this parameter is TRUE, the computer is to restart immediately after shutting down. If this parameter is FALSE, the system
	/// flushes all caches to disk and clears the screen.
	/// </param>
	/// <param name="reason">Reason for initiating the shutdown. This parameter must be one of the system shutdown reason codes.</param>
	/// <returns>0 on failure, non-zero for success</returns>
	public static bool InitiateShutdown(string machineName = null, string message = null, TimeSpan? timeout = null, bool forceAppsClosed = false, bool rebootAfterShutdown = false, SystemShutDownReason reason = SystemShutDownReason.SHTDN_REASON_UNKNOWN)
	{
		var graceSecs = (uint)timeout.GetValueOrDefault().TotalSeconds;
		if (Environment.OSVersion.Version.Major <= 5 && graceSecs > MAX_SHUTDOWN_TIMEOUT) throw new ArgumentOutOfRangeException(nameof(timeout), $"Timeout can be no longer than {MAX_SHUTDOWN_TIMEOUT} seconds on Windows XP and earlier systems.");
		using (string.IsNullOrEmpty(machineName) ? new PrivilegedCodeBlock(SystemPrivilege.Shutdown) : new PrivilegedCodeBlock(SystemPrivilege.RemoteShutdown))
			return InitiateSystemShutdownEx(machineName, message, graceSecs, forceAppsClosed, rebootAfterShutdown, reason);
	}

	/// <summary>Locks the workstation's display, protecting it from unauthorized use.</summary>
	public static bool LockWorkStation() => User32.LockWorkStation();

	/// <summary>Suspends the system by entering a suspend (sleep) state.</summary>
	/// <param name="wakeupEventsDisabled">
	/// If this parameter is <see langword="true"/>, the system disables all wake events. If the parameter is <see langword="false"/>,
	/// any system wake events remain enabled.
	/// </param>
	/// <returns>
	/// <see langword="true"/> if the operation was successful; <see langword="false"/> if operation is not allowed by system
	/// administrator settings or account privileges.
	/// </returns>
	public static bool Suspend(bool wakeupEventsDisabled = false) => Suspend(false, wakeupEventsDisabled);

	private static bool Suspend(bool hibernate, bool wakeupEventsDisabled)
	{
		try
		{
			using (new PrivilegedCodeBlock(SystemPrivilege.Shutdown))
			{
				if (hibernate)
					return PowrProf.IsPwrHibernateAllowed() ? PowrProf.SetSuspendState(true, false, wakeupEventsDisabled) : false;
				else
					return PowrProf.IsPwrSuspendAllowed() ? PowrProf.SetSuspendState(false, false, wakeupEventsDisabled) : false;
			}
		}
		catch
		{
			return false;
		}
	}
}