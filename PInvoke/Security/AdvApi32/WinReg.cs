using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>
		/// The maximum shutdown timeout that can be used as the dwGracePeriod in the <see cref="InitiateShutdown(string, string, uint, ShutdownFlags, SystemShutDownReason)"/> function.
		/// </summary>
		public const uint MAX_SHUTDOWN_TIMEOUT = 10 * 365 * 24 * 60 * 60;

		/// <summary>Registry entries subordinate to this key define types (or classes) of documents and the properties associated with those types. Shell and COM applications use the information stored under this key.</summary>
		public static readonly SafeRegistryHandle HKEY_CLASSES_ROOT = new SafeRegistryHandle(new IntPtr(unchecked((int)0x80000000)), false);

		/// <summary>Contains information about the current hardware profile of the local computer system. The information under HKEY_CURRENT_CONFIG describes only the differences between the current hardware configuration and the standard configuration. Information about the standard hardware configuration is stored under the Software and System keys of HKEY_LOCAL_MACHINE.</summary>
		public static readonly SafeRegistryHandle HKEY_CURRENT_CONFIG = new SafeRegistryHandle(new IntPtr(unchecked((int)0x80000005)), false);

		/// <summary>Registry entries subordinate to this key define the preferences of the current user. These preferences include the settings of environment variables, data about program groups, colors, printers, network connections, and application preferences. This key makes it easier to establish the current user's settings; the key maps to the current user's branch in HKEY_USERS. In HKEY_CURRENT_USER, software vendors store the current user-specific preferences to be used within their applications. Microsoft, for example, creates the HKEY_CURRENT_USER\Software\Microsoft key for its applications to use, with each application creating its own subkey under the Microsoft key.</summary>
		public static readonly SafeRegistryHandle HKEY_CURRENT_USER = new SafeRegistryHandle(new IntPtr(unchecked((int)0x80000001)), false);

		/// <summary></summary>
		public static readonly SafeRegistryHandle HKEY_DYN_DATA = new SafeRegistryHandle(new IntPtr(unchecked((int)0x80000006)), false);

		/// <summary>Registry entries subordinate to this key define the physical state of the computer, including data about the bus type, system memory, and installed hardware and software. It contains subkeys that hold current configuration data, including Plug and Play information (the Enum branch, which includes a complete list of all hardware that has ever been on the system), network logon preferences, network security information, software-related information (such as server names and the location of the server), and other system information.</summary>
		public static readonly SafeRegistryHandle HKEY_LOCAL_MACHINE = new SafeRegistryHandle(new IntPtr(unchecked((int)0x80000002)), false);

		/// <summary>Registry entries subordinate to this key allow you to access performance data. The data is not actually stored in the registry; the registry functions cause the system to collect the data from its source.</summary>
		public static readonly SafeRegistryHandle HKEY_PERFORMANCE_DATA = new SafeRegistryHandle(new IntPtr(unchecked((int)0x80000004)), false);

		/// <summary>Registry entries subordinate to this key define the default user configuration for new users on the local computer and the user configuration for the current user.</summary>
		public static readonly SafeRegistryHandle HKEY_USERS = new SafeRegistryHandle(new IntPtr(unchecked((int)0x80000003)), false);

		/// <summary>Flags used in the <see cref="Vanara.InitiateShutdown"/> function.</summary>
		[Flags]
		public enum ShutdownFlags
		{
			/// <summary>
			/// All sessions are forcefully logged off. If this flag is not set and users other than the current user are logged on to the computer specified by
			/// the lpMachineName parameter, this function fails with a return value of ERROR_SHUTDOWN_USERS_LOGGED_ON.
			/// </summary>
			SHUTDOWN_FORCE_OTHERS = 0x00000001,
			/// <summary>
			/// Specifies that the originating session is logged off forcefully. If this flag is not set, the originating session is shut down interactively, so
			/// a shutdown is not guaranteed even if the function returns successfully.
			/// </summary>
			SHUTDOWN_FORCE_SELF = 0x00000002,
			/// <summary>The computer is shut down and rebooted.</summary>
			SHUTDOWN_RESTART = 0x00000004,
			/// <summary>The computer is shut down and powered down.</summary>
			SHUTDOWN_POWEROFF = 0x00000008,
			/// <summary>The computer is shut down but is not powered down or rebooted.</summary>
			SHUTDOWN_NOREBOOT = 0x00000010,
			/// <summary>Overrides the grace period so that the computer is shut down immediately.</summary>
			SHUTDOWN_GRACE_OVERRIDE = 0x00000020,
			/// <summary>The computer installs any updates before starting the shutdown.</summary>
			SHUTDOWN_INSTALL_UPDATES = 0x00000040,
			/// <summary>
			/// The system is rebooted using the ExitWindowsEx function with the EWX_RESTARTAPPS flag. This restarts any applications that have been registered
			/// for restart using the RegisterApplicationRestart function.
			/// </summary>
			SHUTDOWN_RESTARTAPPS = 0x00000080,
			/// <summary></summary>
			SHUTDOWN_SKIP_SVC_PRESHUTDOWN = 0x00000100,
			/// <summary>
			/// Beginning with InitiateShutdown running on Windows 8, you must include the SHUTDOWN_HYBRID flag with one or more of the flags in this table to
			/// specify options for the shutdown.
			/// <para>Beginning with Windows 8, InitiateShutdown always initiate a full system shutdown if the SHUTDOWN_HYBRID flag is absent.</para>
			/// </summary>
			SHUTDOWN_HYBRID = 0x00000200,
			/// <summary></summary>
			SHUTDOWN_RESTART_BOOTOPTIONS = 0x00000400,
			/// <summary></summary>
			SHUTDOWN_SOFT_REBOOT = 0x00000800,
			/// <summary></summary>
			SHUTDOWN_MOBILE_UI = 0x00001000,
		}

		/// <summary>Stops a system shutdown started by using the InitiateSystemShutdown function.</summary>
		/// <param name="lpMachineName">
		/// String that specifies the network name of the computer where the shutdown is to be stopped. If NULL or an empty string, the function stops the
		/// shutdown on the local computer.
		/// </param>
		/// <returns>0 on failure, non-zero for success</returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winreg.h", MSDNShortId = "aa376630")]
		public static extern bool AbortSystemShutdown(string lpMachineName);
	
		/// <summary>Initiates a shutdown and restart of the specified computer, and restarts any applications that have been registered for restart.</summary>
		/// <param name="lpMachineName">The name of the computer to be shut down. If the value of this parameter is NULL, the local computer is shut down.</param>
		/// <param name="lpMessage">The message to be displayed in the interactive shutdown dialog box.</param>
		/// <param name="dwGracePeriod">
		/// The number of seconds to wait before shutting down the computer. If the value of this parameter is zero, the computer is shut down immediately. This
		/// value is limited to MAX_SHUTDOWN_TIMEOUT.
		/// <para>
		/// If the value of this parameter is greater than zero, and the dwShutdownFlags parameter specifies the flag SHUTDOWN_GRACE_OVERRIDE, the function fails
		/// and returns the error code ERROR_BAD_ARGUMENTS.
		/// </para>
		/// </param>
		/// <param name="dwShutdownFlags">One or more bit flags that specify options for the shutdown.</param>
		/// <param name="dwReason">
		/// The reason for initiating the shutdown. This parameter must be one of the system shutdown reason codes. If this parameter is zero, the default is an
		/// undefined shutdown that is logged as "No title for this reason could be found". By default, it is also an unplanned shutdown. Depending on how the
		/// system is configured, an unplanned shutdown triggers the creation of a file that contains the system state information, which can delay shutdown.
		/// Therefore, do not use zero for this parameter.
		/// </param>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto)]
		[PInvokeData("winreg.h", MSDNShortId = "aa376872")]
		public static extern Win32Error InitiateShutdown(string lpMachineName, string lpMessage, uint dwGracePeriod, ShutdownFlags dwShutdownFlags, SystemShutDownReason dwReason);

		/// <summary>Initiates a shutdown and optional restart of the specified computer.</summary>
		/// <param name="lpMachineName">
		/// String that specifies the network name of the computer to shut down. If NULL or an empty string, the function shuts down the local computer.
		/// </param>
		/// <param name="lpMessage">String that specifies a message to display in the shutdown dialog box. This parameter can be NULL if no message is required.</param>
		/// <param name="dwTimeout">
		/// Time that the shutdown dialog box should be displayed, in seconds. While this dialog box is displayed, shutdown can be stopped by the
		/// AbortSystemShutdown function.
		/// <para>
		/// If dwTimeout is not zero, InitiateSystemShutdownEx displays a dialog box on the specified computer. The dialog box displays the name of the user who
		/// called the function, displays the message specified by the lpMessage parameter, and prompts the user to log off. The dialog box beeps when it is
		/// created and remains on top of other windows in the system. The dialog box can be moved but not closed. A timer counts down the remaining time before shutdown.
		/// </para>
		/// <para>If dwTimeout is zero, the computer shuts down without displaying the dialog box, and the shutdown cannot be stopped by AbortSystemShutdown.</para>
		/// <para><c>Windows Server 2003 and Windows XP with SP1:</c> The time-out value is limited to MAX_SHUTDOWN_TIMEOUT seconds.</para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP with SP1:</c> If the computer to be shut down is a Terminal Services server, the system displays a dialog box
		/// to all local and remote users warning them that shutdown has been initiated. The dialog box includes who requested the shutdown, the display message
		/// (see lpMessage), and how much time there is until the server is shut down.
		/// </para>
		/// </param>
		/// <param name="bForceAppsClosed">
		/// If this parameter is TRUE, applications with unsaved changes are to be forcibly closed. If this parameter is FALSE, the system displays a dialog box
		/// instructing the user to close the applications.
		/// </param>
		/// <param name="bRebootAfterShutdown">
		/// If this parameter is TRUE, the computer is to restart immediately after shutting down. If this parameter is FALSE, the system flushes all caches to
		/// disk and clears the screen.
		/// </param>
		/// <param name="dwReason">Reason for initiating the shutdown. This parameter must be one of the system shutdown reason codes.</param>
		/// <returns>0 on failure, non-zero for success</returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winreg.h", MSDNShortId = "aa376874")]
		public static extern bool InitiateSystemShutdownEx(string lpMachineName, string lpMessage, uint dwTimeout,
			[MarshalAs(UnmanagedType.Bool)] bool bForceAppsClosed, [MarshalAs(UnmanagedType.Bool)] bool bRebootAfterShutdown,
			SystemShutDownReason dwReason);

		/// <summary>Closes a handle to the specified registry key.</summary>
		/// <param name="hKey">
		/// A handle to the open key to be closed. The handle must have been opened by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx,
		/// RegOpenKeyTransacted, or RegConnectRegistry function.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS.
		/// <para>
		/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function with the
		/// FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
		/// </para>
		/// </returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winreg.h", MSDNShortId = "ms724837")]
		public static extern Win32Error RegCloseKey(IntPtr hKey);

		/// <summary>Notifies the caller about changes to the attributes or contents of a specified registry key.</summary>
		/// <param name="hKey">A handle to an open registry key. This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function.</param>
		/// <param name="bWatchSubtree">
		/// If this parameter is TRUE, the function reports changes in the specified key and its subkeys. If the parameter is FALSE, the function reports changes
		/// only in the specified key.
		/// </param>
		/// <param name="dwFilter">A value that indicates the changes that should be reported.</param>
		/// <param name="hEvent">
		/// A handle to an event. If the fAsynchronous parameter is TRUE, the function returns immediately and changes are reported by signaling this event. If
		/// fAsynchronous is FALSE, hEvent is ignored.
		/// </param>
		/// <param name="fAsynchronous">
		/// If this parameter is TRUE, the function returns immediately and reports changes by signaling the specified event. If this parameter is FALSE, the
		/// function does not return until a change has occurred.
		/// <para>If hEvent does not specify a valid event, the fAsynchronous parameter cannot be TRUE.</para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS.
		/// <para>
		/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function with the
		/// FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
		/// </para>
		/// </returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winreg.h", MSDNShortId = "ms724892")]
		public static extern Win32Error RegNotifyChangeKeyValue(SafeRegistryHandle hKey, [MarshalAs(UnmanagedType.Bool)] bool bWatchSubtree, RegNotifyChangeFilter dwFilter, IntPtr hEvent, [MarshalAs(UnmanagedType.Bool)] bool fAsynchronous);

		/// <summary>Opens the specified registry key. Note that key names are not case sensitive.</summary>
		/// <param name="hKey">
		/// A handle to an open registry key. This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function, or it can be one of the predefined keys.
		/// </param>
		/// <param name="lpSubKey">
		/// The name of the registry subkey to be opened.
		/// <para>Key names are not case sensitive.</para>
		/// <para>
		/// The lpSubKey parameter can be a pointer to an empty string. If lpSubKey is a pointer to an empty string and hKey is HKEY_CLASSES_ROOT, phkResult
		/// receives the same hKey handle passed into the function. Otherwise, phkResult receives a new handle to the key specified by hKey.
		/// </para>
		/// <para>
		/// The lpSubKey parameter can be NULL only if hKey is one of the predefined keys. If lpSubKey is NULL and hKey is HKEY_CLASSES_ROOT, phkResult receives
		/// a new handle to the key specified by hKey. Otherwise, phkResult receives the same hKey handle passed in to the function.
		/// </para>
		/// </param>
		/// <param name="ulOptions">Specifies the option to apply when opening the key.</param>
		/// <param name="samDesired">
		/// A mask that specifies the desired access rights to the key to be opened. The function fails if the security descriptor of the key does not permit the
		/// requested access for the calling process. For more information, see Registry Key Security and Access Rights.
		/// </param>
		/// <param name="phkResult">
		/// A pointer to a variable that receives a handle to the opened key. If the key is not one of the predefined registry keys, call the RegCloseKey
		/// function after you have finished using the handle.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS.
		/// <para>
		/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function with the
		/// FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
		/// </para>
		/// </returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winreg.h", MSDNShortId = "ms724897")]
		public static extern Win32Error RegOpenKeyEx(SafeRegistryHandle hKey, string lpSubKey, RegOpenOptions ulOptions, RegAccessTypes samDesired, out SafeRegistryHandle phkResult);
	}
}
