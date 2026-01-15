using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary>
	/// The maximum shutdown timeout that can be used as the dwGracePeriod in the
	/// <see cref="InitiateShutdown(string, string, uint, ShutdownFlags, SystemShutDownReason)"/> function.
	/// </summary>
	public const uint MAX_SHUTDOWN_TIMEOUT = 10 * 365 * 24 * 60 * 60;

	/// <summary>Flags used by RegLoadAppKey.</summary>
	[PInvokeData("winreg.h", MSDNShortId = "88eb79c1-9ea0-436e-ad2e-9ce05b8dcb2c")]
	public enum REG_APPKEY
	{
		/// <summary>No flags</summary>
		NONE = 0,

		/// <summary>
		/// The hive cannot be loaded again while it is loaded by the caller. This prevents access to this registry hive by another caller.
		/// </summary>
		REG_PROCESS_APPKEY = 1,
	}

	/// <summary>Flags used by RegLoadMUIString.</summary>
	[PInvokeData("winreg.h", MSDNShortId = "76ffc77f-a1bc-4e01-858f-4a76563a2bbc")]
	public enum REG_MUI_STRING
	{
		/// <summary>No flags</summary>
		NONE = 0,

		/// <summary>
		/// The string is truncated to fit the available size of the pszOutBuf buffer.If this flag is specified, pcbData must be NULL.
		/// </summary>
		REG_MUI_STRING_TRUNCATE = 0x00000001,
	}

	/// <summary>Flags used by RegSaveKeyEx</summary>
	[PInvokeData("winreg.h", MSDNShortId = "f93b4162-cac4-42f7-bfd4-9e23fff80a03")]
	[Flags]
	public enum REG_SAVE : uint
	{
		/// <summary>The key or hive is saved in standard format. The standard format is the only format supported by Windows 2000.</summary>
		REG_STANDARD_FORMAT = 1,

		/// <summary>
		/// The key or hive is saved in the latest format. The latest format is supported starting with Windows XP. After the key or hive
		/// is saved in this format, it cannot be loaded on an earlier system.
		/// </summary>
		REG_LATEST_FORMAT = 2,

		/// <summary>
		/// The hive is saved with no compression, for faster save operations. The hKey parameter must specify the root of a hive under
		/// HKEY_LOCAL_MACHINE or HKEY_USERS. For example, HKLM\SOFTWARE is the root of a hive.
		/// </summary>
		REG_NO_COMPRESSION = 4,
	}

	/// <summary>Flags used in the <see cref="InitiateShutdown"/> function.</summary>
	[Flags]
	public enum ShutdownFlags
	{
		/// <summary>
		/// All sessions are forcefully logged off. If this flag is not set and users other than the current user are logged on to the
		/// computer specified by the lpMachineName parameter, this function fails with a return value of ERROR_SHUTDOWN_USERS_LOGGED_ON.
		/// </summary>
		SHUTDOWN_FORCE_OTHERS = 0x00000001,

		/// <summary>
		/// Specifies that the originating session is logged off forcefully. If this flag is not set, the originating session is shut
		/// down interactively, so a shutdown is not guaranteed even if the function returns successfully.
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
		/// The system is rebooted using the ExitWindowsEx function with the EWX_RESTARTAPPS flag. This restarts any applications that
		/// have been registered for restart using the RegisterApplicationRestart function.
		/// </summary>
		SHUTDOWN_RESTARTAPPS = 0x00000080,

		/// <summary></summary>
		SHUTDOWN_SKIP_SVC_PRESHUTDOWN = 0x00000100,

		/// <summary>
		/// Beginning with InitiateShutdown running on Windows 8, you must include the SHUTDOWN_HYBRID flag with one or more of the flags
		/// in this table to specify options for the shutdown.
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
	/// String that specifies the network name of the computer where the shutdown is to be stopped. If NULL or an empty string, the
	/// function stops the shutdown on the local computer.
	/// </param>
	/// <returns>0 on failure, non-zero for success</returns>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("winreg.h", MSDNShortId = "aa376630")]
	public static extern bool AbortSystemShutdown([Optional] string? lpMachineName);

	/// <summary>
	/// Initiates a shutdown and restart of the specified computer, and restarts any applications that have been registered for restart.
	/// </summary>
	/// <param name="lpMachineName">
	/// The name of the computer to be shut down. If the value of this parameter is NULL, the local computer is shut down.
	/// </param>
	/// <param name="lpMessage">The message to be displayed in the interactive shutdown dialog box.</param>
	/// <param name="dwGracePeriod">
	/// The number of seconds to wait before shutting down the computer. If the value of this parameter is zero, the computer is shut
	/// down immediately. This value is limited to MAX_SHUTDOWN_TIMEOUT.
	/// <para>
	/// If the value of this parameter is greater than zero, and the dwShutdownFlags parameter specifies the flag
	/// SHUTDOWN_GRACE_OVERRIDE, the function fails and returns the error code ERROR_BAD_ARGUMENTS.
	/// </para>
	/// </param>
	/// <param name="dwShutdownFlags">One or more bit flags that specify options for the shutdown.</param>
	/// <param name="dwReason">
	/// The reason for initiating the shutdown. This parameter must be one of the system shutdown reason codes. If this parameter is
	/// zero, the default is an undefined shutdown that is logged as "No title for this reason could be found". By default, it is also an
	/// unplanned shutdown. Depending on how the system is configured, an unplanned shutdown triggers the creation of a file that
	/// contains the system state information, which can delay shutdown. Therefore, do not use zero for this parameter.
	/// </param>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "aa376872")]
	public static extern Win32Error InitiateShutdown([Optional] string? lpMachineName, [Optional] string? lpMessage, uint dwGracePeriod, ShutdownFlags dwShutdownFlags, SystemShutDownReason dwReason);

	/// <summary>
	/// <para>Initiates a shutdown and optional restart of the specified computer.</para>
	/// <para>To record a reason for the shutdown in the event log, call the InitiateSystemShutdownEx function.</para>
	/// </summary>
	/// <param name="lpMachineName">
	/// <para>
	/// The network name of the computer to be shut down. If lpMachineName is <c>NULL</c> or an empty string, the function shuts down the
	/// local computer.
	/// </para>
	/// </param>
	/// <param name="lpMessage">
	/// <para>The message to be displayed in the shutdown dialog box. This parameter can be <c>NULL</c> if no message is required.</para>
	/// <para><c>Windows Server 2003 and Windows XP:</c> This string is also stored as a comment in the event log entry.</para>
	/// <para><c>Windows Server 2003 and Windows XP with SP1:</c> The string is limited to 3072 <c>TCHARs</c>.</para>
	/// </param>
	/// <param name="dwTimeout">
	/// <para>
	/// The length of time that the shutdown dialog box should be displayed, in seconds. While this dialog box is displayed, the shutdown
	/// can be stopped by the AbortSystemShutdown function.
	/// </para>
	/// <para>
	/// If dwTimeout is not zero, <c>InitiateSystemShutdown</c> displays a dialog box on the specified computer. The dialog box displays
	/// the name of the user who called the function, displays the message specified by the lpMessage parameter, and prompts the user to
	/// log off. The dialog box beeps when it is created and remains on top of other windows in the system. The dialog box can be moved
	/// but not closed. A timer counts down the remaining time before a forced shutdown.
	/// </para>
	/// <para>
	/// If dwTimeout is zero, the computer shuts down without displaying the dialog box, and the shutdown cannot be stopped by AbortSystemShutdown.
	/// </para>
	/// <para><c>Windows Server 2003 and Windows XP with SP1:</c> The time-out value is limited to <c>MAX_SHUTDOWN_TIMEOUT</c> seconds.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP with SP1:</c> If the computer to be shut down is a Terminal Services server, the system
	/// displays a dialog box to all local and remote users warning them that shutdown has been initiated. The dialog box includes who
	/// requested the shutdown, the display message (see lpMessage), and how much time there is until the server is shut down.
	/// </para>
	/// </param>
	/// <param name="bForceAppsClosed">
	/// <para>
	/// If this parameter is <c>TRUE</c>, applications with unsaved changes are to be forcibly closed. Note that this can result in data loss.
	/// </para>
	/// <para>If this parameter is <c>FALSE</c>, the system displays a dialog box instructing the user to close the applications.</para>
	/// </param>
	/// <param name="bRebootAfterShutdown">
	/// <para>
	/// If this parameter is <c>TRUE</c>, the computer is to restart immediately after shutting down. If this parameter is <c>FALSE</c>,
	/// the system flushes all caches to disk and safely powers down the system.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To shut down the local computer, the calling thread must have the <c>SE_SHUTDOWN_NAME</c> privilege. To shut down a remote
	/// computer, the calling thread must have the <c>SE_REMOTE_SHUTDOWN_NAME</c> privilege on the remote computer. By default, users can
	/// enable the <c>SE_SHUTDOWN_NAME</c> privilege on the computer they are logged onto, and administrators can enable the
	/// <c>SE_REMOTE_SHUTDOWN_NAME</c> privilege on remote computers. For more information, see Running with Special Privileges.
	/// </para>
	/// <para>
	/// Common reasons for failure include an invalid or inaccessible computer name or insufficient privilege. The error
	/// <c>ERROR_SHUTDOWN_IN_PROGRESS</c> is returned if a shutdown is already in progress on the specified computer. The error
	/// <c>ERROR_NOT_READY</c> can be returned if fast-user switching is enabled but no user is logged on.
	/// </para>
	/// <para>
	/// A non-zero return value does not mean the logoff was or will be successful. The shutdown is an asynchronous process, and it can
	/// occur long after the API call has returned, or not at all. Even if the timeout value is zero, the shutdown can still be aborted
	/// by applications, services or even the system. The non-zero return value indicates that the validation of the rights and
	/// parameters was successful and that the system accepted the shutdown request.
	/// </para>
	/// <para>
	/// When this function is called, the caller must specify whether or not applications with unsaved changes should be forcibly closed.
	/// If the caller chooses not to force these applications closed, and an application with unsaved changes is running on the console
	/// session, the shutdown will remain in progress until the user logged into the console session aborts the shutdown, saves changes,
	/// closes the application, or forces the application to close. During this period, the shutdown may not be aborted except by the
	/// console user, and another shutdown may not be initiated.
	/// </para>
	/// <para>
	/// Note that calling this function with the value of the bForceAppsClosed parameter set to <c>TRUE</c> avoids this situation.
	/// Remember that doing this may result in loss of data.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> If the computer is locked and the bForceAppsClosed parameter is <c>FALSE</c>, the last
	/// error code is <c>ERROR_MACHINE_LOCKED</c>. If the system is not ready to handle the request, the last error code is
	/// <c>ERROR_NOT_READY</c>. The application should wait a short while and retry the call. For example, the system can be unready to
	/// initiate a shutdown, and return <c>ERROR_NOT_READY</c>, if the shutdown request comes at the same time a user tries to log onto
	/// the system. In this case, the application should wait a short while and retry the call.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Displaying the Shutdown Dialog Box.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-initiatesystemshutdowna BOOL InitiateSystemShutdownA( PSTR
	// lpMachineName, PSTR lpMessage, DWORD dwTimeout, BOOL bForceAppsClosed, BOOL bRebootAfterShutdown );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "cad54fea-7f59-438c-83ac-f0160d81496b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InitiateSystemShutdown([Optional] string? lpMachineName, [Optional] string? lpMessage, uint dwTimeout, [MarshalAs(UnmanagedType.Bool)] bool bForceAppsClosed, [MarshalAs(UnmanagedType.Bool)] bool bRebootAfterShutdown);

	/// <summary>Initiates a shutdown and optional restart of the specified computer.</summary>
	/// <param name="lpMachineName">
	/// String that specifies the network name of the computer to shut down. If NULL or an empty string, the function shuts down the
	/// local computer.
	/// </param>
	/// <param name="lpMessage">
	/// String that specifies a message to display in the shutdown dialog box. This parameter can be NULL if no message is required.
	/// </param>
	/// <param name="dwTimeout">
	/// Time that the shutdown dialog box should be displayed, in seconds. While this dialog box is displayed, shutdown can be stopped by
	/// the AbortSystemShutdown function.
	/// <para>
	/// If dwTimeout is not zero, InitiateSystemShutdownEx displays a dialog box on the specified computer. The dialog box displays the
	/// name of the user who called the function, displays the message specified by the lpMessage parameter, and prompts the user to log
	/// off. The dialog box beeps when it is created and remains on top of other windows in the system. The dialog box can be moved but
	/// not closed. A timer counts down the remaining time before shutdown.
	/// </para>
	/// <para>
	/// If dwTimeout is zero, the computer shuts down without displaying the dialog box, and the shutdown cannot be stopped by AbortSystemShutdown.
	/// </para>
	/// <para><c>Windows Server 2003 and Windows XP with SP1:</c> The time-out value is limited to MAX_SHUTDOWN_TIMEOUT seconds.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP with SP1:</c> If the computer to be shut down is a Terminal Services server, the system
	/// displays a dialog box to all local and remote users warning them that shutdown has been initiated. The dialog box includes who
	/// requested the shutdown, the display message (see lpMessage), and how much time there is until the server is shut down.
	/// </para>
	/// </param>
	/// <param name="bForceAppsClosed">
	/// If this parameter is TRUE, applications with unsaved changes are to be forcibly closed. If this parameter is FALSE, the system
	/// displays a dialog box instructing the user to close the applications.
	/// </param>
	/// <param name="bRebootAfterShutdown">
	/// If this parameter is TRUE, the computer is to restart immediately after shutting down. If this parameter is FALSE, the system
	/// flushes all caches to disk and clears the screen.
	/// </param>
	/// <param name="dwReason">Reason for initiating the shutdown. This parameter must be one of the system shutdown reason codes.</param>
	/// <returns>0 on failure, non-zero for success</returns>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("winreg.h", MSDNShortId = "aa376874")]
	public static extern bool InitiateSystemShutdownEx([Optional] string? lpMachineName, [Optional] string? lpMessage, uint dwTimeout,
		[MarshalAs(UnmanagedType.Bool)] bool bForceAppsClosed, [MarshalAs(UnmanagedType.Bool)] bool bRebootAfterShutdown,
		SystemShutDownReason dwReason);

	/// <summary>Closes a handle to the specified registry key.</summary>
	/// <param name="hKey">
	/// A handle to the open key to be closed. The handle must have been opened by the RegCreateKeyEx, RegCreateKeyTransacted,
	/// RegOpenKeyEx, RegOpenKeyTransacted, or RegConnectRegistry function.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is ERROR_SUCCESS.
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winreg.h", MSDNShortId = "ms724837")]
	public static extern Win32Error RegCloseKey(HKEY hKey);

	/// <summary>
	/// <para>Establishes a connection to a predefined registry key on another computer.</para>
	/// </summary>
	/// <param name="lpMachineName">
	/// <para>The name of the remote computer. The string has the following form:</para>
	/// <para>\computername</para>
	/// <para>The caller must have access to the remote computer or the function fails.</para>
	/// <para>If this parameter is <c>NULL</c>, the local computer name is used.</para>
	/// </param>
	/// <param name="hKey">
	/// <para>A predefined registry handle. This parameter can be one of the following predefined keys on the remote computer.</para>
	/// <para><c>HKEY_LOCAL_MACHINE</c><c>HKEY_PERFORMANCE_DATA</c><c>HKEY_USERS</c></para>
	/// </param>
	/// <param name="phkResult">
	/// <para>A pointer to a variable that receives a key handle identifying the predefined handle on the remote computer.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>RegConnectRegistry</c> requires the Remote Registry service to be running on the remote computer. By default, this service is
	/// configured to be started manually. To configure the Remote Registry service to start automatically, run Services.msc and change
	/// the Startup Type of the service to Automatic.
	/// </para>
	/// <para><c>Windows Server 2003 and Windows XP/2000:</c> The Remote Registry service is configured to start automatically by default.</para>
	/// <para>When a handle returned by <c>RegConnectRegistry</c> is no longer needed, it should be closed by calling RegCloseKey.</para>
	/// <para>
	/// If the computer is joined to a workgroup and the "Force network logons using local accounts to authenticate as Guest" policy is
	/// enabled, the function fails. Note that this policy is enabled by default if the computer is joined to a workgroup.
	/// </para>
	/// <para>
	/// If the current user does not have proper access to the remote computer, the call to <c>RegConnectRegistry</c> fails. To connect
	/// to a remote registry, call LogonUser with LOGON32_LOGON_NEW_CREDENTIALS and ImpersonateLoggedOnUser before calling <c>RegConnectRegistry</c>.
	/// </para>
	/// <para>
	/// <c>Windows 2000:</c> One possible workaround is to establish a session to an administrative share such as IPC$ using a different
	/// set of credentials. To specify credentials other than those of the current user, use the WNetAddConnection2 function to connect
	/// to the share. When you have finished accessing the registry, cancel the connection.
	/// </para>
	/// <para>
	/// <c>Windows XP Home Edition:</c> You cannot use this function to connect to a remote computer running Windows XP Home Edition.
	/// This function does work with the name of the local computer even if it is running Windows XP Home Edition because this bypasses
	/// the authentication layer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regconnectregistrya LSTATUS RegConnectRegistryA( LPCSTR
	// lpMachineName, HKEY hKey, PHKEY phkResult );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "d7fb41cc-4855-4ad7-879c-b1ac85ac5803")]
	public static extern Win32Error RegConnectRegistry([Optional] string? lpMachineName, HKEY hKey, out SafeRegistryHandle phkResult);

	/// <summary>
	/// <para>Copies the specified registry key, along with its values and subkeys, to the specified destination key.</para>
	/// </summary>
	/// <param name="hKeySrc">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_READ access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function, or it can be one of the predefined keys.</para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>
	/// The name of the key. This key must be a subkey of the key identified by the hKeySrc parameter. This parameter can also be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="hKeyDest">
	/// <para>A handle to the destination key. The calling process must have KEY_CREATE_SUB_KEY access to the key.</para>
	/// <para>This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function, or it can be one of the predefined keys.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>This function also copies the security descriptor for the key.</para>
	/// <para>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later. For more information, see Using the
	/// Windows Headers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regcopytreea LSTATUS RegCopyTreeA( HKEY hKeySrc, LPCSTR
	// lpSubKey, HKEY hKeyDest );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "d16f2b47-e537-42b0-90b3-9f9a00e61e76")]
	public static extern Win32Error RegCopyTree(HKEY hKeySrc, [Optional] string? lpSubKey, HKEY hKeyDest);

	/// <summary>
	/// <para>Creates the specified registry key. If the key already exists in the registry, the function opens it.</para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the
	/// RegCreateKeyEx function. However, applications that back up or restore system state including system files and registry hives
	/// should use the Volume Shadow Copy Service instead of the registry functions.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The calling process must have KEY_CREATE_SUB_KEY access to the key. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// Access for key creation is checked against the security descriptor of the registry key, not the access mask specified when the
	/// handle was obtained. Therefore, even if hKey was opened with a samDesired of KEY_READ, it can be used in operations that create
	/// keys if allowed by its security descriptor.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>or</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>function, or it can be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>The name of a key that this function opens or creates. This key must be a subkey of the key identified by the hKey parameter.</para>
	/// <para>For more information on key names, see Structure of the Registry.</para>
	/// <para>
	/// If hKey is one of the predefined keys, lpSubKey may be <c>NULL</c>. In that case, phkResult receives the same hKey handle passed
	/// in to the function.
	/// </para>
	/// </param>
	/// <param name="phkResult">
	/// <para>
	/// A pointer to a variable that receives a handle to the opened or created key. If the key is not one of the predefined registry
	/// keys, call the RegCloseKey function after you have finished using the handle.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application cannot create a key that is a direct child of <c>HKEY_USERS</c> or <c>HKEY_LOCAL_MACHINE</c>. An application can
	/// create subkeys in lower levels of the <c>HKEY_USERS</c> or <c>HKEY_LOCAL_MACHINE</c> trees.
	/// </para>
	/// <para>
	/// If your service or application impersonates different users, do not use this function with <c>HKEY_CURRENT_USER</c>. Instead,
	/// call the RegOpenCurrentUser function.
	/// </para>
	/// <para>
	/// The <c>RegCreateKey</c> function creates all missing keys in the specified path. An application can take advantage of this
	/// behavior to create several keys at once. For example, an application can create a subkey four levels deep at the same time as the
	/// three preceding subkeys by specifying a string of the following form for the lpSubKey parameter:
	/// </para>
	/// <para>subkey1\subkey2\subkey3\subkey4</para>
	/// <para>Note that this behavior will result in creation of unwanted keys if an existing key in the path is spelled incorrectly.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regcreatekeya LSTATUS RegCreateKeyA( HKEY hKey, LPCSTR
	// lpSubKey, PHKEY phkResult );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "cb4d30f4-e288-41e8-86e0-807c313db53d")]
	public static extern Win32Error RegCreateKey(HKEY hKey, [Optional] string? lpSubKey, out SafeRegistryHandle phkResult);

	/// <summary>
	/// <para>
	/// Creates the specified registry key. If the key already exists, the function opens it. Note that key names are not case sensitive.
	/// </para>
	/// <para>To perform transacted registry operations on a key, call the RegCreateKeyTransacted function.</para>
	/// <para>
	/// Applications that back up or restore system state including system files and registry hives should use the Volume Shadow Copy
	/// Service instead of the registry functions.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The calling process must have KEY_CREATE_SUB_KEY access to the key. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// Access for key creation is checked against the security descriptor of the registry key, not the access mask specified when the
	/// handle was obtained. Therefore, even if hKey was opened with a samDesired of KEY_READ, it can be used in operations that modify
	/// the registry if allowed by its security descriptor.
	/// </para>
	/// <para>
	/// This handle is returned by the <c>RegCreateKeyEx</c> or RegOpenKeyEx function, or it can be one of the following predefined keys:
	/// </para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>
	/// The name of a subkey that this function opens or creates. The subkey specified must be a subkey of the key identified by the hKey
	/// parameter; it can be up to 32 levels deep in the registry tree. For more information on key names, see Structure of the Registry.
	/// </para>
	/// <para>If lpSubKey is a pointer to an empty string, phkResult receives a new handle to the key specified by hKey.</para>
	/// <para>This parameter cannot be <c>NULL</c>.</para>
	/// </param>
	/// <param name="Reserved">
	/// <para>This parameter is reserved and must be zero.</para>
	/// </param>
	/// <param name="lpClass">
	/// <para>The user-defined class type of this key. This parameter may be ignored. This parameter can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="dwOptions">
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>REG_OPTION_BACKUP_RESTORE 0x00000004L</term>
	/// <term>
	/// If this flag is set, the function ignores the samDesired parameter and attempts to open the key with the access required to
	/// backup or restore the key. If the calling thread has the SE_BACKUP_NAME privilege enabled, the key is opened with the
	/// ACCESS_SYSTEM_SECURITY and KEY_READ access rights. If the calling thread has the SE_RESTORE_NAME privilege enabled, beginning
	/// with Windows Vista, the key is opened with the ACCESS_SYSTEM_SECURITY, DELETE and KEY_WRITE access rights. If both privileges are
	/// enabled, the key has the combined access rights for both privileges. For more information, see Running with Special Privileges.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REG_OPTION_CREATE_LINK 0x00000002L</term>
	/// <term>
	/// This key is a symbolic link. The target path is assigned to the L"SymbolicLinkValue" value of the key. The target path must be an
	/// absolute registry path.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REG_OPTION_NON_VOLATILE 0x00000000L</term>
	/// <term>
	/// This key is not volatile; this is the default. The information is stored in a file and is preserved when the system is restarted.
	/// The RegSaveKey function saves keys that are not volatile.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REG_OPTION_VOLATILE 0x00000001L</term>
	/// <term>
	/// All keys created by the function are volatile. The information is stored in memory and is not preserved when the corresponding
	/// registry hive is unloaded. For HKEY_LOCAL_MACHINE, this occurs only when the system initiates a full shutdown. For registry keys
	/// loaded by the RegLoadKey function, this occurs when the corresponding RegUnLoadKey is performed. The RegSaveKey function does not
	/// save volatile keys. This flag is ignored for keys that already exist.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="samDesired">
	/// <para>
	/// A mask that specifies the access rights for the key to be created. For more information, see Registry Key Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="lpSecurityAttributes">
	/// <para>
	/// A pointer to a SECURITY_ATTRIBUTES structure that determines whether the returned handle can be inherited by child processes. If
	/// lpSecurityAttributes is <c>NULL</c>, the handle cannot be inherited.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new key. If lpSecurityAttributes
	/// is <c>NULL</c>, the key gets a default security descriptor. The ACLs in a default security descriptor for a key are inherited
	/// from its direct parent key.
	/// </para>
	/// </param>
	/// <param name="phkResult">
	/// <para>
	/// A pointer to a variable that receives a handle to the opened or created key. If the key is not one of the predefined registry
	/// keys, call the RegCloseKey function after you have finished using the handle.
	/// </para>
	/// </param>
	/// <param name="lpdwDisposition">
	/// <para>A pointer to a variable that receives one of the following disposition values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>REG_CREATED_NEW_KEY 0x00000001L</term>
	/// <term>The key did not exist and was created.</term>
	/// </item>
	/// <item>
	/// <term>REG_OPENED_EXISTING_KEY 0x00000002L</term>
	/// <term>The key existed and was simply opened without being changed.</term>
	/// </item>
	/// </list>
	/// <para>If lpdwDisposition is <c>NULL</c>, no disposition information is returned.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The key that the <c>RegCreateKeyEx</c> function creates has no values. An application can use the RegSetValueEx function to set
	/// key values.
	/// </para>
	/// <para>
	/// The <c>RegCreateKeyEx</c> function creates all missing keys in the specified path. An application can take advantage of this
	/// behavior to create several keys at once. For example, an application can create a subkey four levels deep at the same time as the
	/// three preceding subkeys by specifying a string of the following form for the lpSubKey parameter:
	/// </para>
	/// <para>subkey1\subkey2\subkey3\subkey4</para>
	/// <para>Note that this behavior will result in creation of unwanted keys if an existing key in the path is spelled incorrectly.</para>
	/// <para>
	/// An application cannot create a key that is a direct child of <c>HKEY_USERS</c> or <c>HKEY_LOCAL_MACHINE</c>. An application can
	/// create subkeys in lower levels of the <c>HKEY_USERS</c> or <c>HKEY_LOCAL_MACHINE</c> trees.
	/// </para>
	/// <para>
	/// If your service or application impersonates different users, do not use this function with <c>HKEY_CURRENT_USER</c>. Instead,
	/// call the RegOpenCurrentUser function.
	/// </para>
	/// <para>
	/// Note that operations that access certain registry keys are redirected. For more information, see Registry Virtualization and
	/// 32-bit and 64-bit Application Data in the Registry.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regcreatekeyexa LSTATUS RegCreateKeyExA( HKEY hKey, LPCSTR
	// lpSubKey, DWORD Reserved, PSTR lpClass, DWORD dwOptions, REGSAM samDesired, CONST LPSECURITY_ATTRIBUTES lpSecurityAttributes,
	// PHKEY phkResult, LPDWORD lpdwDisposition );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "e9ffad7f-c0b6-44ce-bf22-fbe45ca98bf4")]
	public static extern Win32Error RegCreateKeyEx(HKEY hKey, string lpSubKey, [Optional] uint Reserved, [Optional] string? lpClass, [Optional] RegOpenOptions dwOptions,
		[Optional] REGSAM samDesired, [Optional] SECURITY_ATTRIBUTES? lpSecurityAttributes, out SafeRegistryHandle phkResult, out REG_DISPOSITION lpdwDisposition);

	/// <summary>
	/// <para>
	/// Creates the specified registry key and associates it with a transaction. If the key already exists, the function opens it. Note
	/// that key names are not case sensitive.
	/// </para>
	/// <para>
	/// Applications that back up or restore system state including system files and registry hives should use the Volume Shadow Copy
	/// Service instead of the registry functions.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The calling process must have KEY_CREATE_SUB_KEY access to the key. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// Access for key creation is checked against the security descriptor of the registry key, not the access mask specified when the
	/// handle was obtained. Therefore, even if hKey was opened with a samDesired of KEY_READ, it can be used in operations that create
	/// keys if allowed by its security descriptor.
	/// </para>
	/// <para>
	/// This handle is returned by the <c>RegCreateKeyTransacted</c> or RegOpenKeyTransacted function, or it can be one of the following
	/// predefined keys:
	/// </para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>
	/// The name of a subkey that this function opens or creates. The subkey specified must be a subkey of the key identified by the hKey
	/// parameter; it can be up to 32 levels deep in the registry tree. For more information on key names, see Structure of the Registry.
	/// </para>
	/// <para>If lpSubKey is a pointer to an empty string, phkResult receives a new handle to the key specified by hKey.</para>
	/// <para>This parameter cannot be <c>NULL</c>.</para>
	/// </param>
	/// <param name="Reserved">
	/// <para>This parameter is reserved and must be zero.</para>
	/// </param>
	/// <param name="lpClass">
	/// <para>The user-defined class of this key. This parameter may be ignored. This parameter can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="dwOptions">
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>REG_OPTION_BACKUP_RESTORE 0x00000004L</term>
	/// <term>
	/// If this flag is set, the function ignores the samDesired parameter and attempts to open the key with the access required to
	/// backup or restore the key. If the calling thread has the SE_BACKUP_NAME privilege enabled, the key is opened with the
	/// ACCESS_SYSTEM_SECURITY and KEY_READ access rights. If the calling thread has the SE_RESTORE_NAME privilege enabled, the key is
	/// opened with the ACCESS_SYSTEM_SECURITY and KEY_WRITE access rights. If both privileges are enabled, the key has the combined
	/// access rights for both privileges. For more information, see Running with Special Privileges.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REG_OPTION_NON_VOLATILE 0x00000000L</term>
	/// <term>
	/// This key is not volatile; this is the default. The information is stored in a file and is preserved when the system is restarted.
	/// The RegSaveKey function saves keys that are not volatile.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REG_OPTION_VOLATILE 0x00000001L</term>
	/// <term>
	/// All keys created by the function are volatile. The information is stored in memory and is not preserved when the corresponding
	/// registry hive is unloaded. For HKEY_LOCAL_MACHINE, this occurs when the system is shut down. For registry keys loaded by the
	/// RegLoadKey function, this occurs when the corresponding RegUnLoadKey is performed. The RegSaveKey function does not save volatile
	/// keys. This flag is ignored for keys that already exist.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="samDesired">
	/// <para>
	/// A mask that specifies the access rights for the key to be created. For more information, see Registry Key Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="lpSecurityAttributes">
	/// <para>
	/// A pointer to a SECURITY_ATTRIBUTES structure that determines whether the returned handle can be inherited by child processes. If
	/// lpSecurityAttributes is <c>NULL</c>, the handle cannot be inherited.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new key. If lpSecurityAttributes
	/// is <c>NULL</c>, the key gets a default security descriptor. The ACLs in a default security descriptor for a key are inherited
	/// from its direct parent key.
	/// </para>
	/// </param>
	/// <param name="phkResult">
	/// <para>
	/// A pointer to a variable that receives a handle to the opened or created key. If the key is not one of the predefined registry
	/// keys, call the RegCloseKey function after you have finished using the handle.
	/// </para>
	/// </param>
	/// <param name="lpdwDisposition">
	/// <para>A pointer to a variable that receives one of the following disposition values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>REG_CREATED_NEW_KEY 0x00000001L</term>
	/// <term>The key did not exist and was created.</term>
	/// </item>
	/// <item>
	/// <term>REG_OPENED_EXISTING_KEY 0x00000002L</term>
	/// <term>The key existed and was simply opened without being changed.</term>
	/// </item>
	/// </list>
	/// <para>If lpdwDisposition is <c>NULL</c>, no disposition information is returned.</para>
	/// </param>
	/// <param name="hTransaction">
	/// <para>A handle to an active transaction. This handle is returned by the CreateTransaction function.</para>
	/// </param>
	/// <param name="pExtendedParemeter">
	/// <para>This parameter is reserved and must be <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When a key is created using this function, subsequent operations on the key are transacted. If a non-transacted operation is
	/// performed on the key before the transaction is committed, the transaction is rolled back. After a transaction is committed or
	/// rolled back, you must re-open the key using <c>RegCreateKeyTransacted</c> or RegOpenKeyTransacted with an active transaction
	/// handle to make additional operations transacted. For more information about transactions, see Kernel Transaction Manager.
	/// </para>
	/// <para>
	/// Note that subsequent operations on subkeys of this key are not automatically transacted. Therefore, RegDeleteKeyEx does not
	/// perform a transacted delete operation. Instead, use the RegDeleteKeyTransacted function to perform a transacted delete operation.
	/// </para>
	/// <para>
	/// The key that the <c>RegCreateKeyTransacted</c> function creates has no values. An application can use the RegSetValueEx function
	/// to set key values.
	/// </para>
	/// <para>
	/// The <c>RegCreateKeyTransacted</c> function creates all missing keys in the specified path. An application can take advantage of
	/// this behavior to create several keys at once. For example, an application can create a subkey four levels deep at the same time
	/// as the three preceding subkeys by specifying a string of the following form for the lpSubKey parameter:
	/// </para>
	/// <para>subkey1\subkey2\subkey3\subkey4</para>
	/// <para>Note that this behavior will result in creation of unwanted keys if an existing key in the path is spelled incorrectly.</para>
	/// <para>
	/// An application cannot create a key that is a direct child of <c>HKEY_USERS</c> or <c>HKEY_LOCAL_MACHINE</c>. An application can
	/// create subkeys in lower levels of the <c>HKEY_USERS</c> or <c>HKEY_LOCAL_MACHINE</c> trees.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regcreatekeytransacteda LSTATUS RegCreateKeyTransactedA(
	// HKEY hKey, LPCSTR lpSubKey, DWORD Reserved, PSTR lpClass, DWORD dwOptions, REGSAM samDesired, CONST LPSECURITY_ATTRIBUTES
	// lpSecurityAttributes, PHKEY phkResult, LPDWORD lpdwDisposition, HANDLE hTransaction, PVOID pExtendedParemeter );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "f18e5ff9-41c3-4c26-8d01-a8ec69bcdef2")]
	public static extern Win32Error RegCreateKeyTransacted(HKEY hKey, string lpSubKey, [Optional] uint Reserved, [Optional] string? lpClass, [Optional] RegOpenOptions dwOptions,
		[Optional] REGSAM samDesired, [Optional] SECURITY_ATTRIBUTES? lpSecurityAttributes, out SafeRegistryHandle phkResult, out REG_DISPOSITION lpdwDisposition,
		HTRXN hTransaction, IntPtr pExtendedParemeter = default);

	/// <summary>
	/// <para>Deletes a subkey and its values. Note that key names are not case sensitive.</para>
	/// <para>
	/// <c>64-bit Windows:</c> On WOW64, 32-bit applications view a registry tree that is separate from the registry tree that 64-bit
	/// applications view. To enable an application to delete an entry in the alternate registry view, use the RegDeleteKeyEx function.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The access rights of this key do not affect the delete operation. For more information about
	/// access rights, see Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>or</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>function, or it can be one of the following</para>
	/// <para>Predefined Keys</para>
	/// <para>:</para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>
	/// The name of the key to be deleted. It must be a subkey of the key that hKey identifies, but it cannot have subkeys. This
	/// parameter cannot be <c>NULL</c>.
	/// </para>
	/// <para>The function opens the subkey with the DELETE access right.</para>
	/// <para>Key names are not case sensitive.</para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. To get a generic description of the error,
	/// you can use the FormatMessage function with the FORMAT_MESSAGE_FROM_SYSTEM flag.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>A deleted key is not removed until the last handle to it is closed.</para>
	/// <para>
	/// The subkey to be deleted must not have subkeys. To delete a key and all its subkeys, you need to enumerate the subkeys and delete
	/// them individually. To delete keys recursively, use the RegDeleteTree or SHDeleteKey function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Deleting a Key with Subkeys.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regdeletekeya LSTATUS RegDeleteKeyA( HKEY hKey, LPCSTR
	// lpSubKey );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "a2310ca0-1b9f-48d1-a3b5-ea3a528bfaba")]
	public static extern Win32Error RegDeleteKey(HKEY hKey, string lpSubKey);

	/// <summary>
	/// <para>
	/// Deletes a subkey and its values from the specified platform-specific view of the registry. Note that key names are not case sensitive.
	/// </para>
	/// <para>To delete a subkey as a transacted operation, call the RegDeleteKeyTransacted function.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The access rights of this key do not affect the delete operation. For more information about
	/// access rights, see Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>or</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>function, or it can be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>The name of the key to be deleted. This key must be a subkey of the key specified by the value of the hKey parameter.</para>
	/// <para>The function opens the subkey with the DELETE access right.</para>
	/// <para>Key names are not case sensitive.</para>
	/// <para>The value of this parameter cannot be <c>NULL</c>.</para>
	/// </param>
	/// <param name="samDesired">
	/// <para>An access mask the specifies the platform-specific view of the registry.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KEY_WOW64_32KEY 0x0200</term>
	/// <term>Delete the key from the 32-bit registry view.</term>
	/// </item>
	/// <item>
	/// <term>KEY_WOW64_64KEY 0x0100</term>
	/// <term>Delete the key from the 64-bit registry view.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Reserved">
	/// <para>This parameter is reserved and must be zero.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>A deleted key is not removed until the last handle to it is closed.</para>
	/// <para>
	/// On WOW64, 32-bit applications view a registry tree that is separate from the registry tree that 64-bit applications view. This
	/// function enables an application to delete an entry in the alternate registry view.
	/// </para>
	/// <para>
	/// The subkey to be deleted must not have subkeys. To delete a key and all its subkeys, you need to enumerate the subkeys and delete
	/// them individually. To delete keys recursively, use the RegDeleteTree or SHDeleteKey function.
	/// </para>
	/// <para>
	/// If the function succeeds, <c>RegDeleteKeyEx</c> removes the specified key from the registry. The entire key, including all of its
	/// values, is removed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regdeletekeyexa LSTATUS RegDeleteKeyExA( HKEY hKey, LPCSTR
	// lpSubKey, REGSAM samDesired, DWORD Reserved );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "41fde6a5-647c-4293-92b8-74be54fa4136")]
	public static extern Win32Error RegDeleteKeyEx(HKEY hKey, string lpSubKey, [Optional] REGSAM samDesired, uint Reserved = 0);

	/// <summary>
	/// <para>
	/// Deletes a subkey and its values from the specified platform-specific view of the registry as a transacted operation. Note that
	/// key names are not case sensitive.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The access rights of this key do not affect the delete operation. For more information about
	/// access rights, see Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>,</para>
	/// <para>RegCreateKeyTransacted</para>
	/// <para>,</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>, or</para>
	/// <para>RegOpenKeyTransacted</para>
	/// <para>function. It can also be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>The name of the key to be deleted. This key must be a subkey of the key specified by the value of the hKey parameter.</para>
	/// <para>The function opens the subkey with the DELETE access right.</para>
	/// <para>Key names are not case sensitive.</para>
	/// <para>The value of this parameter cannot be <c>NULL</c>.</para>
	/// </param>
	/// <param name="samDesired">
	/// <para>An access mask the specifies the platform-specific view of the registry.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KEY_WOW64_32KEY 0x0200</term>
	/// <term>Delete the key from the 32-bit registry view.</term>
	/// </item>
	/// <item>
	/// <term>KEY_WOW64_64KEY 0x0100</term>
	/// <term>Delete the key from the 64-bit registry view.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Reserved">
	/// <para>This parameter is reserved and must be zero.</para>
	/// </param>
	/// <param name="hTransaction">
	/// <para>A handle to an active transaction. This handle is returned by the CreateTransaction function.</para>
	/// </param>
	/// <param name="pExtendedParameter">
	/// <para>This parameter is reserved and must be <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>A deleted key is not removed until the last handle to it is closed.</para>
	/// <para>
	/// On WOW64, 32-bit applications view a registry tree that is separate from the registry tree that 64-bit applications view. This
	/// function enables an application to delete an entry in the alternate registry view.
	/// </para>
	/// <para>
	/// The subkey to be deleted must not have subkeys. To delete a key and all its subkeys, you need to enumerate the subkeys and delete
	/// them individually. To delete keys recursively, use the RegDeleteTree or SHDeleteKey function.
	/// </para>
	/// <para>
	/// If the function succeeds, <c>RegDeleteKeyTransacted</c> removes the specified key from the registry. The entire key, including
	/// all of its values, is removed. To remove the entire tree as a transacted operation, use the RegDeleteTree function with a handle
	/// returned from RegCreateKeyTransacted or RegOpenKeyTransacted.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regdeletekeytransacteda LSTATUS RegDeleteKeyTransactedA(
	// HKEY hKey, LPCSTR lpSubKey, REGSAM samDesired, DWORD Reserved, HANDLE hTransaction, PVOID pExtendedParameter );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "4c67e08b-4338-4441-8300-6b6ed31d4b21")]
	public static extern Win32Error RegDeleteKeyTransacted(HKEY hKey, string lpSubKey, [Optional] REGSAM samDesired, [Optional] uint Reserved, HTRXN hTransaction, IntPtr pExtendedParameter = default);

	/// <summary>Removes the specified value from the specified registry key and subkey.</summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_SET_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function, or it can be one of the following predefined keys:</para>
	/// <list type="bullet">
	/// <item><c>HKEY_CLASSES_ROOT</c></item>
	/// <item><c>HKEY_CURRENT_CONFIG</c></item>
	/// <item><c>HKEY_CURRENT_USER</c></item>
	/// <item><c>HKEY_LOCAL_MACHINE</c></item>
	/// <item><c>HKEY_USERS</c></item>
	/// </list>
	/// </param>
	/// <param name="lpSubKey">The name of the registry key. This key must be a subkey of the key identified by the hKey parameter.</param>
	/// <param name="lpValueName">The registry value to be removed from the key.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function with
	/// the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later. For more information, see Using the
	/// Windows Headers.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regdeletekeyvaluea LSTATUS RegDeleteKeyValueA( HKEY hKey,
	// LPCSTR lpSubKey, LPCSTR lpValueName );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "a4a082c2-8cf3-41eb-87c0-a6c453821f8b")]
	public static extern Win32Error RegDeleteKeyValue(HKEY hKey, string? lpSubKey, string? lpValueName);

	/// <summary>
	/// <para>Deletes the subkeys and values of the specified key recursively.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the following access rights: DELETE, KEY_ENUMERATE_SUB_KEYS,
	/// and KEY_QUERY_VALUE. For more information, see Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>or</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>function, or it can be one of the following</para>
	/// <para>Predefined Keys</para>
	/// <para>:</para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>
	/// The name of the key. This key must be a subkey of the key identified by the hKey parameter. If this parameter is <c>NULL</c>, the
	/// subkeys and values of hKey are deleted.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>If the key has values, it must be opened with KEY_SET_VALUE or this function will fail with ERROR_ACCESS_DENIED.</para>
	/// <para>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later. For more information, see Using the
	/// Windows Headers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regdeletetreea LSTATUS RegDeleteTreeA( HKEY hKey, LPCSTR
	// lpSubKey );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "984813a9-e191-498f-8288-b8a4c567112b")]
	public static extern Win32Error RegDeleteTree(HKEY hKey, [Optional] string? lpSubKey);

	/// <summary>
	/// <para>Removes a named value from the specified registry key. Note that value names are not case sensitive.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_SET_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or RegOpenKeyTransacted function. It can
	/// also be one of the following predefined keys:
	/// </para>
	/// <para><c></c><c>HKEY_CLASSES_ROOT</c><c>HKEY_CURRENT_CONFIG</c><c>HKEY_CURRENT_USER</c><c>HKEY_LOCAL_MACHINE</c><c>HKEY_USERS</c></para>
	/// </param>
	/// <param name="lpValueName">
	/// <para>
	/// The registry value to be removed. If this parameter is <c>NULL</c> or an empty string, the value set by the RegSetValue function
	/// is removed.
	/// </para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regdeletevaluea LSTATUS RegDeleteValueA( HKEY hKey, LPCSTR
	// lpValueName );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "4393b4ef-cd10-40d4-bb12-2d84e7cb7d3c")]
	public static extern Win32Error RegDeleteValue(HKEY hKey, [Optional] string? lpValueName);

	/// <summary>
	/// <para>
	/// Disables handle caching of the predefined registry handle for <c>HKEY_CURRENT_USER</c> for the current process. This function
	/// does not work on a remote computer.
	/// </para>
	/// <para>To disables handle caching of all predefined registry handles, use the RegDisablePredefinedCacheEx function.</para>
	/// </summary>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Any access of <c>HKEY_CURRENT_USER</c> after this function is called will result in operations being performed on
	/// <c>HKEY_USERS</c>&lt;b&gt;SID_of_current_user, or on <c>HKEY_USERS.DEFAULT</c> if the current user's hive is not loaded. For more
	/// information on SIDs, see Security Identifiers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regdisablepredefinedcache LSTATUS RegDisablePredefinedCache( );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winreg.h", MSDNShortId = "837584b3-5f61-4535-9e66-56f50ab3fa46")]
	public static extern Win32Error RegDisablePredefinedCache();

	/// <summary>
	/// <para>Disables handle caching for all predefined registry handles for the current process.</para>
	/// </summary>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function does not work on a remote computer.</para>
	/// <para>Services that change impersonation should call this function before using any of the predefined handles.</para>
	/// <para>
	/// For example, any access of <c>HKEY_CURRENT_USER</c> after this function is called results in open and close operations being
	/// performed on <c>HKEY_USERS</c>&lt;b&gt;SID_of_current_user, or on <c>HKEY_USERS.DEFAULT</c> if the current user's hive is not
	/// loaded. For more information on SIDs, see Security Identifiers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regdisablepredefinedcacheex LSTATUS
	// RegDisablePredefinedCacheEx( );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winreg.h", MSDNShortId = "a56cf7d9-0ac4-4719-af41-3c0cdcef6faf")]
	public static extern Win32Error RegDisablePredefinedCacheEx();

	/// <summary>
	/// <para>Disables registry reflection for the specified key. Disabling reflection for a key does not affect reflection of any subkeys.</para>
	/// </summary>
	/// <param name="hBase">
	/// <para>
	/// A handle to an open registry key. This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or
	/// RegOpenKeyTransacted function; it cannot specify a key on a remote computer.
	/// </para>
	/// <para>
	/// If the key is not on the reflection list, the function succeeds but has no effect. For more information, see Registry
	/// Redirectorand Registry Reflection.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// On WOW64, 32-bit applications view a registry tree that is separate from the registry tree that 64-bit applications view.
	/// Registry reflection copies specific registry keys and values between the two views.
	/// </para>
	/// <para>To restore registry reflection for a disabled key, use the RegEnableReflectionKey function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regdisablereflectionkey LONG RegDisableReflectionKey( HKEY
	// hBase );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winreg.h", MSDNShortId = "294a1d28-d09f-44a3-8bc0-6fae50c3a8f8")]
	public static extern Win32Error RegDisableReflectionKey(HKEY hBase);

	/// <summary>
	/// <para>
	/// Restores registry reflection for the specified disabled key. Restoring reflection for a key does not affect reflection of any subkeys.
	/// </para>
	/// </summary>
	/// <param name="hBase">
	/// <para>
	/// A handle to the registry key that was previously disabled using the RegDisableReflectionKey function. This handle is returned by
	/// the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or RegOpenKeyTransacted function; it cannot specify a key on a remote computer.
	/// </para>
	/// <para>
	/// If the key is not on the reflection list, this function succeeds but has no effect. For more information, see Registry
	/// Redirectorand Registry Reflection.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// On WOW64, 32-bit applications view a registry tree that is separate from the registry tree that 64-bit applications view.
	/// Registry reflection copies specific registry keys and values between the two views.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regenablereflectionkey LONG RegEnableReflectionKey( HKEY
	// hBase );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winreg.h", MSDNShortId = "6dfbc3d8-cd71-4ee9-a10b-955c26a6894c")]
	public static extern Win32Error RegEnableReflectionKey(HKEY hBase);

	/// <summary>
	/// <para>
	/// Enumerates the subkeys of the specified open registry key. The function retrieves the name of one subkey each time it is called.
	/// </para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the
	/// RegEnumKeyEx function.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_ENUMERATE_SUB_KEYS access right. For more
	/// information, see Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>,</para>
	/// <para>RegCreateKeyTransacted</para>
	/// <para>,</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>, or</para>
	/// <para>RegOpenKeyTransacted</para>
	/// <para>function. It can also be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// </param>
	/// <param name="dwIndex">
	/// <para>
	/// The index of the subkey of hKey to be retrieved. This value should be zero for the first call to the <c>RegEnumKey</c> function
	/// and then incremented for subsequent calls.
	/// </para>
	/// <para>
	/// Because subkeys are not ordered, any new subkey will have an arbitrary index. This means that the function may return subkeys in
	/// any order.
	/// </para>
	/// </param>
	/// <param name="lpName">
	/// <para>
	/// A pointer to a buffer that receives the name of the subkey, including the terminating null character. This function copies only
	/// the name of the subkey, not the full key hierarchy, to the buffer.
	/// </para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// </param>
	/// <param name="cchName">
	/// <para>
	/// The size of the buffer pointed to by the lpName parameter, in <c>TCHARs</c>. To determine the required buffer size, use the
	/// RegQueryInfoKey function to determine the size of the largest subkey for the key identified by the hKey parameter.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a system error code. If there are no more subkeys available, the function returns ERROR_NO_MORE_ITEMS.
	/// </para>
	/// <para>If the lpName buffer is too small to receive the name of the key, the function returns ERROR_MORE_DATA.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate subkeys, an application should initially call the <c>RegEnumKey</c> function with the dwIndex parameter set to zero.
	/// The application should then increment the dwIndex parameter and call the <c>RegEnumKey</c> function until there are no more
	/// subkeys (meaning the function returns ERROR_NO_MORE_ITEMS).
	/// </para>
	/// <para>
	/// The application can also set dwIndex to the index of the last key on the first call to the function and decrement the index until
	/// the subkey with index 0 is enumerated. To retrieve the index of the last subkey, use the RegQueryInfoKey.
	/// </para>
	/// <para>
	/// While an application is using the <c>RegEnumKey</c> function, it should not make calls to any registration functions that might
	/// change the key being queried.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regenumkeya LSTATUS RegEnumKeyA( HKEY hKey, DWORD dwIndex,
	// PSTR lpName, DWORD cchName );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "18a05c60-6c6d-438f-9003-f07d688d86a3")]
	public static extern Win32Error RegEnumKey(HKEY hKey, uint dwIndex, StringBuilder lpName, uint cchName);

	/// <summary>
	/// Enumerates the subkeys of the specified open registry key. The function retrieves information about one subkey each time it is called.
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_ENUMERATE_SUB_KEYS access right. For more information,
	/// see Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or RegOpenKeyTransacted function. It can also be
	/// one of the following predefined keys:
	/// </para>
	/// <list type="bullet">
	/// <item>HKEY_CLASSES_ROOT</item>
	/// <item>HKEY_CURRENT_CONFIG</item>
	/// <item>HKEY_CURRENT_USER</item>
	/// <item>HKEY_LOCAL_MACHINE</item>
	/// <item>HKEY_PERFORMANCE_DATA</item>
	/// <item>HKEY_USERS</item>
	/// </list>
	/// </param>
	/// <param name="dwIndex">
	/// <para>
	/// The index of the subkey to retrieve. This parameter should be zero for the first call to the <c>RegEnumKeyEx</c> function and then
	/// incremented for subsequent calls.
	/// </para>
	/// <para>
	/// Because subkeys are not ordered, any new subkey will have an arbitrary index. This means that the function may return subkeys in any order.
	/// </para>
	/// </param>
	/// <param name="lpName">
	/// <para>
	/// A pointer to a buffer that receives the name of the subkey, including the terminating <c>null</c> character. The function copies only
	/// the name of the subkey, not the full key hierarchy, to the buffer.
	/// </para>
	/// <para>If the function fails, no information is copied to this buffer.</para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// </param>
	/// <param name="lpcchName">
	/// <para>
	/// A pointer to a variable that specifies the size of the buffer specified by the <c>lpName</c> parameter, in characters. This size
	/// should include the terminating <c>null</c> character. If the function succeeds, the variable pointed to by <c>lpcchName</c> contains
	/// the number of characters stored in the buffer, not including the terminating <c>null</c> character.
	/// </para>
	/// <para>
	/// To determine the required buffer size, use the RegQueryInfoKey function to determine the size of the largest subkey for the key
	/// identified by the <c>hKey</c> parameter.
	/// </para>
	/// </param>
	/// <param name="lpReserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="lpClass">
	/// A pointer to a buffer that receives the user-defined class of the enumerated subkey. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="lpcchClass">
	/// A pointer to a variable that specifies the size of the buffer specified by the <c>lpClass</c> parameter, in characters. The size
	/// should include the terminating <c>null</c> character. If the function succeeds, <c>lpcchClass</c> contains the number of characters
	/// stored in the buffer, not including the terminating <c>null</c> character. This parameter can be <c>NULL</c> only if <c>lpClass</c>
	/// is <c>NULL</c>.
	/// </param>
	/// <param name="lpftLastWriteTime">
	/// A pointer to FILETIME structure that receives the time at which the enumerated subkey was last written. This parameter can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a system error code. If there are no more subkeys available, the function returns ERROR_NO_MORE_ITEMS.
	/// </para>
	/// <para>If the <c>lpName</c> buffer is too small to receive the name of the key, the function returns ERROR_MORE_DATA.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate subkeys, an application should initially call the <c>RegEnumKeyEx</c> function with the <c>dwIndex</c> parameter set to
	/// zero. The application should then increment the <c>dwIndex</c> parameter and call <c>RegEnumKeyEx</c> until there are no more subkeys
	/// (meaning the function returns ERROR_NO_MORE_ITEMS).
	/// </para>
	/// <para>
	/// The application can also set <c>dwIndex</c> to the index of the last subkey on the first call to the function and decrement the index
	/// until the subkey with the index 0 is enumerated. To retrieve the index of the last subkey, use the RegQueryInfoKey function.
	/// </para>
	/// <para>
	/// While an application is using the <c>RegEnumKeyEx</c> function, it should not make calls to any registration functions that might
	/// change the key being enumerated.
	/// </para>
	/// <para>
	/// Note that operations that access certain registry keys are redirected. For more information, see Registry Virtualization and 32-bit
	/// and 64-bit Application Data in the Registry.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>On legacy versions of Windows, this API is also exposed by kernel32.dll.</para>
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Enumerating Registry Subkeys.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winreg.h header defines RegEnumKeyEx as an alias which automatically selects the ANSI or Unicode version of this function based
	/// on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regenumkeyexa
	// LSTATUS RegEnumKeyExA( [in] HKEY hKey, [in] DWORD dwIndex, [out] PSTR lpName, [in, out] LPDWORD lpcchName, LPDWORD lpReserved, [in, out] PSTR lpClass, [in, out, optional] LPDWORD lpcchClass, [out, optional] PFILETIME lpftLastWriteTime );
	[PInvokeData("winreg.h", MSDNShortId = "NF:winreg.RegEnumKeyExA")]
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	public static extern Win32Error RegEnumKeyEx(HKEY hKey, uint dwIndex, StringBuilder lpName, ref uint lpcchName, [Optional] IntPtr lpReserved, [Optional] StringBuilder? lpClass, ref uint lpcchClass, out FILETIME lpftLastWriteTime);

	/// <summary>
	/// Enumerates the subkeys of the specified open registry key. The function retrieves information about one subkey each time it is called.
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_ENUMERATE_SUB_KEYS access right. For more information,
	/// see Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or RegOpenKeyTransacted function. It can also be
	/// one of the following predefined keys:
	/// </para>
	/// <list type="bullet">
	/// <item>HKEY_CLASSES_ROOT</item>
	/// <item>HKEY_CURRENT_CONFIG</item>
	/// <item>HKEY_CURRENT_USER</item>
	/// <item>HKEY_LOCAL_MACHINE</item>
	/// <item>HKEY_PERFORMANCE_DATA</item>
	/// <item>HKEY_USERS</item>
	/// </list>
	/// </param>
	/// <returns>
	/// A sequence of subkey details including the name of the subkey, the user-defined class of the subkey, and the time at which the subkey
	/// was last written.
	/// </returns>
	/// <remarks>
	/// <para>
	/// While an application is using the <c>RegEnumKeyEx</c> function, it should not make calls to any registration functions that might
	/// change the key being enumerated.
	/// </para>
	/// <para>
	/// Note that operations that access certain registry keys are redirected. For more information, see Registry Virtualization and 32-bit
	/// and 64-bit Application Data in the Registry.
	/// </para>
	/// <para></para>
	/// <para>Examples</para>
	/// <para>For an example, see Enumerating Registry Subkeys.</para>
	/// <para></para>
	/// </remarks>
	[PInvokeData("winreg.h", MSDNShortId = "NF:winreg.RegEnumKeyExA")]
	public static IEnumerable<(string name, string @class, FILETIME lastWrite)> RegEnumKeyEx(HKEY hKey)
	{
		uint sn = 1024, cn = 1024;
		StringBuilder n = new((int)sn), c = new((int)cn);
		Win32Error err = 0;
		uint idx = 0;
		while (err == Win32Error.ERROR_SUCCESS)
		{
			sn = (uint)n.Capacity; cn = (uint)c.Capacity;
			if ((err = RegEnumKeyEx(hKey, idx, n, ref sn, default, c, ref cn, out var ft)) == Win32Error.ERROR_MORE_DATA)
			{
				n.EnsureCapacity((int)sn);
				c.EnsureCapacity((int)cn);
				err = RegEnumKeyEx(hKey, idx, n, ref sn, default, c, ref cn, out ft);
			}
			if (err.Succeeded)
				yield return (n.ToString(), c.ToString(), ft);
			idx++;
		}
		if (err != Win32Error.ERROR_NO_MORE_ITEMS)
			err.ThrowIfFailed();
	}

	/// <summary>
	/// <para>
	/// Enumerates the values for the specified open registry key. The function copies one indexed value name and data block for the key
	/// each time it is called.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_QUERY_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>,</para>
	/// <para>RegCreateKeyTransacted</para>
	/// <para>,</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>, or</para>
	/// <para>RegOpenKeyTransacted</para>
	/// <para>function. It can also be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// </param>
	/// <param name="dwIndex">
	/// <para>
	/// The index of the value to be retrieved. This parameter should be zero for the first call to the <c>RegEnumValue</c> function and
	/// then be incremented for subsequent calls.
	/// </para>
	/// <para>
	/// Because values are not ordered, any new value will have an arbitrary index. This means that the function may return values in any order.
	/// </para>
	/// </param>
	/// <param name="lpValueName">
	/// <para>A pointer to a buffer that receives the name of the value as a <c>null</c>-terminated string.</para>
	/// <para>This buffer must be large enough to include the terminating <c>null</c> character.</para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// </param>
	/// <param name="lpcchValueName">
	/// <para>
	/// A pointer to a variable that specifies the size of the buffer pointed to by the lpValueName parameter, in characters. When the
	/// function returns, the variable receives the number of characters stored in the buffer, not including the terminating <c>null</c> character.
	/// </para>
	/// <para>
	/// Registry value names are limited to 32,767 bytes. The ANSI version of this function treats this parameter as a <c>SHORT</c>
	/// value. Therefore, if you specify a value greater than 32,767 bytes, there is an overflow and the function may return ERROR_MORE_DATA.
	/// </para>
	/// </param>
	/// <param name="lpReserved">
	/// <para>This parameter is reserved and must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpType">
	/// <para>
	/// A pointer to a variable that receives a code indicating the type of data stored in the specified value. For a list of the
	/// possible type codes, see Registry Value Types. The lpType parameter can be <c>NULL</c> if the type code is not required.
	/// </para>
	/// </param>
	/// <param name="lpData">
	/// <para>
	/// A pointer to a buffer that receives the data for the value entry. This parameter can be <c>NULL</c> if the data is not required.
	/// </para>
	/// <para>
	/// If lpData is <c>NULL</c> and lpcbData is non- <c>NULL</c>, the function stores the size of the data, in bytes, in the variable
	/// pointed to by lpcbData. This enables an application to determine the best way to allocate a buffer for the data.
	/// </para>
	/// </param>
	/// <param name="lpcbData">
	/// <para>
	/// A pointer to a variable that specifies the size of the buffer pointed to by the lpData parameter, in bytes. When the function
	/// returns, the variable receives the number of bytes stored in the buffer.
	/// </para>
	/// <para>This parameter can be <c>NULL</c> only if lpData is <c>NULL</c>.</para>
	/// <para>
	/// If the data has the REG_SZ, REG_MULTI_SZ or REG_EXPAND_SZ type, this size includes any terminating <c>null</c> character or
	/// characters. For more information, see Remarks.
	/// </para>
	/// <para>
	/// If the buffer specified by lpData is not large enough to hold the data, the function returns ERROR_MORE_DATA and stores the
	/// required buffer size in the variable pointed to by lpcbData. In this case, the contents of lpData are undefined.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a system error code. If there are no more values available, the function returns ERROR_NO_MORE_ITEMS.
	/// </para>
	/// <para>If the lpData buffer is too small to receive the value, the function returns ERROR_MORE_DATA.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate values, an application should initially call the <c>RegEnumValue</c> function with the dwIndex parameter set to
	/// zero. The application should then increment dwIndex and call the <c>RegEnumValue</c> function until there are no more values
	/// (until the function returns ERROR_NO_MORE_ITEMS).
	/// </para>
	/// <para>
	/// The application can also set dwIndex to the index of the last value on the first call to the function and decrement the index
	/// until the value with index 0 is enumerated. To retrieve the index of the last value, use the RegQueryInfoKey function.
	/// </para>
	/// <para>
	/// While using <c>RegEnumValue</c>, an application should not call any registry functions that might change the key being queried.
	/// </para>
	/// <para>
	/// If the data has the REG_SZ, REG_MULTI_SZ or REG_EXPAND_SZ type, the string may not have been stored with the proper
	/// <c>null</c>-terminating characters. Therefore, even if the function returns ERROR_SUCCESS, the application should ensure that the
	/// string is properly terminated before using it; otherwise, it may overwrite a buffer. (Note that REG_MULTI_SZ strings should have
	/// two <c>null</c>-terminating characters.)
	/// </para>
	/// <para>To determine the maximum size of the name and data buffers, use the RegQueryInfoKey function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Enumerating Registry Subkeys.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regenumvaluea LSTATUS RegEnumValueA( HKEY hKey, DWORD
	// dwIndex, PSTR lpValueName, LPDWORD lpcchValueName, LPDWORD lpReserved, LPDWORD lpType, __out_data_source(REGISTRY)LPBYTE lpData,
	// LPDWORD lpcbData );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "7014ff96-c655-486f-af32-180b87281b06")]
	public static extern Win32Error RegEnumValue(HKEY hKey, uint dwIndex, StringBuilder lpValueName, ref uint lpcchValueName, [Optional] IntPtr lpReserved, out REG_VALUE_TYPE lpType, [Optional] IntPtr lpData, ref uint lpcbData);

	/// <summary>
	/// Enumerates the values for the specified open registry key. The function copies one indexed value name and data block for the key
	/// each time it is called.
	/// </summary>
	/// <param name="hKey">
	/// <para>A handle to an open registry key. The key must have been opened with the KEY_QUERY_VALUE access right. For more information, see Registry Key Security and Access Rights.</para>
	/// <para>This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or RegOpenKeyTransacted function. It can also be one of the following predefined keys:</para>
	/// <list type="bullet">
	/// <item>HKEY_CLASSES_ROOT</item>
	/// <item>HKEY_CURRENT_CONFIG</item>
	/// <item>HKEY_CURRENT_USER</item>
	/// <item>HKEY_LOCAL_MACHINE</item>
	/// <item>HKEY_PERFORMANCE_DATA</item>
	/// <item>HKEY_USERS</item>
	/// </list>
	/// </param>
	/// <param name="dwIndex">
	/// <para>
	/// The index of the value to be retrieved. This parameter should be zero for the first call to the <c>RegEnumValue</c> function and
	/// then be incremented for subsequent calls.
	/// </para>
	/// <para>
	/// Because values are not ordered, any new value will have an arbitrary index. This means that the function may return values in any order.
	/// </para>
	/// </param>
	/// <param name="lpValueName">
	/// <para>A pointer to a buffer that receives the name of the value as a <c>null</c>-terminated string.</para>
	/// <para>This buffer must be large enough to include the terminating <c>null</c> character.</para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// </param>
	/// <param name="lpcchValueName">
	/// <para>
	/// A pointer to a variable that specifies the size of the buffer pointed to by the lpValueName parameter, in characters. When the
	/// function returns, the variable receives the number of characters stored in the buffer, not including the terminating <c>null</c> character.
	/// </para>
	/// <para>
	/// Registry value names are limited to 32,767 bytes. The ANSI version of this function treats this parameter as a <c>SHORT</c>
	/// value. Therefore, if you specify a value greater than 32,767 bytes, there is an overflow and the function may return ERROR_MORE_DATA.
	/// </para>
	/// </param>
	/// <param name="lpReserved">
	/// <para>This parameter is reserved and must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpType">
	/// <para>
	/// A pointer to a variable that receives a code indicating the type of data stored in the specified value. For a list of the
	/// possible type codes, see Registry Value Types. The lpType parameter can be <c>NULL</c> if the type code is not required.
	/// </para>
	/// </param>
	/// <param name="lpData">
	/// <para>
	/// A pointer to a buffer that receives the data for the value entry. This parameter can be <c>NULL</c> if the data is not required.
	/// </para>
	/// <para>
	/// If lpData is <c>NULL</c> and lpcbData is non- <c>NULL</c>, the function stores the size of the data, in bytes, in the variable
	/// pointed to by lpcbData. This enables an application to determine the best way to allocate a buffer for the data.
	/// </para>
	/// </param>
	/// <param name="lpcbData">
	/// <para>
	/// A pointer to a variable that specifies the size of the buffer pointed to by the lpData parameter, in bytes. When the function
	/// returns, the variable receives the number of bytes stored in the buffer.
	/// </para>
	/// <para>This parameter can be <c>NULL</c> only if lpData is <c>NULL</c>.</para>
	/// <para>
	/// If the data has the REG_SZ, REG_MULTI_SZ or REG_EXPAND_SZ type, this size includes any terminating <c>null</c> character or
	/// characters. For more information, see Remarks.
	/// </para>
	/// <para>
	/// If the buffer specified by lpData is not large enough to hold the data, the function returns ERROR_MORE_DATA and stores the
	/// required buffer size in the variable pointed to by lpcbData. In this case, the contents of lpData are undefined.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a system error code. If there are no more values available, the function returns ERROR_NO_MORE_ITEMS.
	/// </para>
	/// <para>If the lpData buffer is too small to receive the value, the function returns ERROR_MORE_DATA.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate values, an application should initially call the <c>RegEnumValue</c> function with the dwIndex parameter set to
	/// zero. The application should then increment dwIndex and call the <c>RegEnumValue</c> function until there are no more values
	/// (until the function returns ERROR_NO_MORE_ITEMS).
	/// </para>
	/// <para>
	/// The application can also set dwIndex to the index of the last value on the first call to the function and decrement the index
	/// until the value with index 0 is enumerated. To retrieve the index of the last value, use the RegQueryInfoKey function.
	/// </para>
	/// <para>
	/// While using <c>RegEnumValue</c>, an application should not call any registry functions that might change the key being queried.
	/// </para>
	/// <para>
	/// If the data has the REG_SZ, REG_MULTI_SZ or REG_EXPAND_SZ type, the string may not have been stored with the proper
	/// <c>null</c>-terminating characters. Therefore, even if the function returns ERROR_SUCCESS, the application should ensure that the
	/// string is properly terminated before using it; otherwise, it may overwrite a buffer. (Note that REG_MULTI_SZ strings should have
	/// two <c>null</c>-terminating characters.)
	/// </para>
	/// <para>To determine the maximum size of the name and data buffers, use the RegQueryInfoKey function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Enumerating Registry Subkeys.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regenumvaluea LSTATUS RegEnumValueA( HKEY hKey, DWORD
	// dwIndex, PSTR lpValueName, LPDWORD lpcchValueName, LPDWORD lpReserved, LPDWORD lpType, __out_data_source(REGISTRY)LPBYTE lpData,
	// LPDWORD lpcbData );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "7014ff96-c655-486f-af32-180b87281b06")]
	public static extern Win32Error RegEnumValue(HKEY hKey, uint dwIndex, StringBuilder lpValueName, ref uint lpcchValueName,
		[Optional] IntPtr lpReserved, [Optional] IntPtr lpType, [Optional] IntPtr lpData, [Optional] IntPtr lpcbData);

	/// <summary>
	/// Enumerates the values for the specified open registry key. The function copies one indexed value name and data block for the key each
	/// time it is called.
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_QUERY_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or RegOpenKeyTransacted function. It can also be
	/// one of the following predefined keys:
	/// </para>
	/// <list type="bullet">
	/// <item>HKEY_CLASSES_ROOT</item>
	/// <item>HKEY_CURRENT_CONFIG</item>
	/// <item>HKEY_CURRENT_USER</item>
	/// <item>HKEY_LOCAL_MACHINE</item>
	/// <item>HKEY_PERFORMANCE_DATA</item>
	/// <item>HKEY_USERS</item>
	/// </list>
	/// </param>
	/// <param name="inclData">if set to <see langword="true"/>, retrieves the data value.</param>
	/// <returns>
	/// A sequence of tuples with information from each value in the specified key with the name of the value, the value's type, and,
	/// optionally, the value.
	/// </returns>
	/// <remarks>
	/// While using <c>RegEnumValue</c>, an application should not call any registry functions that might change the key being queried.
	/// </remarks>
	[PInvokeData("winreg.h", MSDNShortId = "NF:winreg.RegEnumValueA")]
	public static IEnumerable<(string valueName, REG_VALUE_TYPE type, object? data)> RegEnumValue(HKEY hKey, bool inclData = false)
	{
		QueryValueInfo(hKey, out var c, out var sn, out var sz);
		Win32Error err = 0;
		StringBuilder n = new((int)sn + 1);
		using SafeCoTaskMemHandle mem = new(inclData ? sz : 0);
		uint idx = 0;
		uint utype = 0;
		using PinnedObject pType = new(utype);
		REG_VALUE_TYPE type = 0;
		while (err == Win32Error.ERROR_SUCCESS/* && idx < c*/)
		{
			sn = (uint)n.Capacity;
			if (!inclData)
			{
				if ((err = RegEnumValue(hKey, idx, n, ref sn, default, pType)).Succeeded)
					yield return (n.ToString(), (REG_VALUE_TYPE)utype, null);
			}
			else
			{
				sz = mem.Size;
				if ((err = RegEnumValue(hKey, idx, n, ref sn, default, out type, mem, ref sz)).Succeeded)
					yield return (n.ToString(), type, sz == 0 ? null : type.GetValue(mem.DangerousGetHandle(), sz));
			}
			idx++;
		}
		if (err != Win32Error.ERROR_NO_MORE_ITEMS)
			err.ThrowIfFailed();

		static void QueryValueInfo(HKEY hKey, out uint values, out uint maxValueNameLen, out uint maxValueLen)
		{
			unsafe
			{
				uint vc = 0, sn = 0, sz = 0;
				RegQueryInfoKey(hKey, lpcValues: &vc, lpcbMaxValueNameLen: &sn, lpcbMaxValueLen: &sz).ThrowIfFailed();
				values = vc; maxValueNameLen = sn; maxValueLen = sz;
			}
		}
	}

	/// <summary>
	/// <para>Writes all the attributes of the specified open registry key into the registry.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_QUERY_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>,</para>
	/// <para>RegCreateKeyTransacted</para>
	/// <para>,</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>, or</para>
	/// <para>RegOpenKeyTransacted</para>
	/// <para>function. It can also be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Calling <c>RegFlushKey</c> is an expensive operation that significantly affects system-wide performance as it consumes disk
	/// bandwidth and blocks modifications to all keys by all processes in the registry hive that is being flushed until the flush
	/// operation completes. <c>RegFlushKey</c> should only be called explicitly when an application must guarantee that registry changes
	/// are persisted to disk immediately after modification. All modifications made to keys are visible to other processes without the
	/// need to flush them to disk.
	/// </para>
	/// <para>
	/// Alternatively, the registry has a 'lazy flush' mechanism that flushes registry modifications to disk at regular intervals of
	/// time. In addition to this regular flush operation, registry changes are also flushed to disk at system shutdown. Allowing the
	/// 'lazy flush' to flush registry changes is the most efficient way to manage registry writes to the registry store on disk.
	/// </para>
	/// <para>
	/// The <c>RegFlushKey</c> function returns only when all the data for the hive that contains the specified key has been written to
	/// the registry store on disk.
	/// </para>
	/// <para>
	/// The <c>RegFlushKey</c> function writes out the data for other keys in the hive that have been modified since the last lazy flush
	/// or system start.
	/// </para>
	/// <para>After <c>RegFlushKey</c> returns, use RegCloseKey to close the handle to the registry key.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regflushkey LSTATUS RegFlushKey( HKEY hKey );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winreg.h", MSDNShortId = "ae1160be-1da7-4621-a0fc-727aa229ec06")]
	public static extern Win32Error RegFlushKey(HKEY hKey);

	/// <summary>
	/// <para>
	/// The <c>RegGetKeySecurity</c> function retrieves a copy of the security descriptor protecting the specified open registry key.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>A handle to an open key for which to retrieve the security descriptor.</para>
	/// </param>
	/// <param name="SecurityInformation">
	/// <para>A SECURITY_INFORMATION value that indicates the requested security information.</para>
	/// </param>
	/// <param name="pSecurityDescriptor">
	/// <para>A pointer to a buffer that receives a copy of the requested security descriptor.</para>
	/// </param>
	/// <param name="lpcbSecurityDescriptor">
	/// <para>
	/// A pointer to a variable that specifies the size, in bytes, of the buffer pointed to by the pSecurityDescriptor parameter. When
	/// the function returns, the variable contains the number of bytes written to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, it returns a nonzero error code defined in WinError.h. You can use the FormatMessage function with the
	/// FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the buffer specified by the pSecurityDescriptor parameter is too small, the function returns ERROR_INSUFFICIENT_BUFFER and the
	/// lpcbSecurityDescriptor parameter contains the number of bytes required for the requested security descriptor.
	/// </para>
	/// <para>
	/// To read the owner, group, or discretionary access control list (DACL) from the key's security descriptor, the calling process
	/// must have been granted READ_CONTROL access when the handle was opened. To get READ_CONTROL access, the caller must be the owner
	/// of the key or the key's DACL must grant the access.
	/// </para>
	/// <para>
	/// To read the system access control list (SACL) from the security descriptor, the calling process must have been granted
	/// ACCESS_SYSTEM_SECURITY access when the key was opened. The correct way to get this access is to enable the SE_SECURITY_NAME
	/// privilege in the caller's current token, open the handle for ACCESS_SYSTEM_SECURITY access, and then disable the privilege.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-reggetkeysecurity LSTATUS RegGetKeySecurity( HKEY hKey,
	// SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor, LPDWORD lpcbSecurityDescriptor );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winreg.h", MSDNShortId = "26bd8f89-9241-4c13-a214-c2b276d68c92")]
	public static extern Win32Error RegGetKeySecurity(HKEY hKey, SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor, ref uint lpcbSecurityDescriptor);

	/// <summary>
	/// <para>Retrieves the type and data for the specified registry value.</para>
	/// </summary>
	/// <param name="hkey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_QUERY_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>,</para>
	/// <para>RegCreateKeyTransacted</para>
	/// <para>,</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>, or</para>
	/// <para>RegOpenKeyTransacted</para>
	/// <para>function. It can also be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>The name of the registry key. This key must be a subkey of the key specified by the hkey parameter.</para>
	/// <para>Key names are not case sensitive.</para>
	/// </param>
	/// <param name="lpValue">
	/// <para>The name of the registry value.</para>
	/// <para>
	/// If this parameter is <c>NULL</c> or an empty string, "", the function retrieves the type and data for the key's unnamed or
	/// default value, if any.
	/// </para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// <para>Keys do not automatically have an unnamed or default value. Unnamed values can be of any type.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// The flags that restrict the data type of value to be queried. If the data type of the value does not meet this criteria, the
	/// function fails. This parameter can be one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RRF_RT_ANY 0x0000ffff</term>
	/// <term>No type restriction.</term>
	/// </item>
	/// <item>
	/// <term>RRF_RT_DWORD 0x00000018</term>
	/// <term>Restrict type to 32-bit RRF_RT_REG_BINARY | RRF_RT_REG_DWORD.</term>
	/// </item>
	/// <item>
	/// <term>RRF_RT_QWORD 0x00000048</term>
	/// <term>Restrict type to 64-bit RRF_RT_REG_BINARY | RRF_RT_REG_DWORD.</term>
	/// </item>
	/// <item>
	/// <term>RRF_RT_REG_BINARY 0x00000008</term>
	/// <term>Restrict type to REG_BINARY.</term>
	/// </item>
	/// <item>
	/// <term>RRF_RT_REG_DWORD 0x00000010</term>
	/// <term>Restrict type to REG_DWORD.</term>
	/// </item>
	/// <item>
	/// <term>RRF_RT_REG_EXPAND_SZ 0x00000004</term>
	/// <term>Restrict type to REG_EXPAND_SZ.</term>
	/// </item>
	/// <item>
	/// <term>RRF_RT_REG_MULTI_SZ 0x00000020</term>
	/// <term>Restrict type to REG_MULTI_SZ.</term>
	/// </item>
	/// <item>
	/// <term>RRF_RT_REG_NONE 0x00000001</term>
	/// <term>Restrict type to REG_NONE.</term>
	/// </item>
	/// <item>
	/// <term>RRF_RT_REG_QWORD 0x00000040</term>
	/// <term>Restrict type to REG_QWORD.</term>
	/// </item>
	/// <item>
	/// <term>RRF_RT_REG_SZ 0x00000002</term>
	/// <term>Restrict type to REG_SZ.</term>
	/// </item>
	/// </list>
	/// <para>This parameter can also include one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RRF_NOEXPAND 0x10000000</term>
	/// <term>Do not automatically expand environment strings if the value is of type REG_EXPAND_SZ.</term>
	/// </item>
	/// <item>
	/// <term>RRF_ZEROONFAILURE 0x20000000</term>
	/// <term>If pvData is not NULL, set the contents of the buffer to zeroes on failure.</term>
	/// </item>
	/// <item>
	/// <term>RRF_SUBKEY_WOW6464KEY 0x00010000</term>
	/// <term>
	/// If lpSubKey is not NULL, open the subkey that lpSubKey specifies with the KEY_WOW64_64KEY access rights. For information about
	/// these access rights, see Registry Key Security and Access Rights. You cannot specify RRF_SUBKEY_WOW6464KEY in combination with RRF_SUBKEY_WOW6432KEY.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RRF_SUBKEY_WOW6432KEY 0x00020000</term>
	/// <term>
	/// If lpSubKey is not NULL, open the subkey that lpSubKey specifies with the KEY_WOW64_32KEY access rights. For information about
	/// these access rights, see Registry Key Security and Access Rights. You cannot specify RRF_SUBKEY_WOW6432KEY in combination with RRF_SUBKEY_WOW6464KEY.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwType">
	/// <para>
	/// A pointer to a variable that receives a code indicating the type of data stored in the specified value. For a list of the
	/// possible type codes, see Registry Value Types. This parameter can be <c>NULL</c> if the type is not required.
	/// </para>
	/// </param>
	/// <param name="pvData">
	/// <para>A pointer to a buffer that receives the value's data. This parameter can be <c>NULL</c> if the data is not required.</para>
	/// <para>
	/// If the data is a string, the function checks for a terminating <c>null</c> character. If one is not found, the string is stored
	/// with a <c>null</c> terminator if the buffer is large enough to accommodate the extra character. Otherwise, the function fails and
	/// returns ERROR_MORE_DATA.
	/// </para>
	/// </param>
	/// <param name="pcbData">
	/// <para>
	/// A pointer to a variable that specifies the size of the buffer pointed to by the pvData parameter, in bytes. When the function
	/// returns, this variable contains the size of the data copied to pvData.
	/// </para>
	/// <para>The pcbData parameter can be <c>NULL</c> only if pvData is <c>NULL</c>.</para>
	/// <para>
	/// If the data has the REG_SZ, REG_MULTI_SZ or REG_EXPAND_SZ type, this size includes any terminating <c>null</c> character or
	/// characters. For more information, see Remarks.
	/// </para>
	/// <para>
	/// If the buffer specified by pvData parameter is not large enough to hold the data, the function returns ERROR_MORE_DATA and stores
	/// the required buffer size in the variable pointed to by pcbData. In this case, the contents of the pvData buffer are undefined.
	/// </para>
	/// <para>
	/// If pvData is <c>NULL</c>, and pcbData is non- <c>NULL</c>, the function returns ERROR_SUCCESS and stores the size of the data, in
	/// bytes, in the variable pointed to by pcbData. This enables an application to determine the best way to allocate a buffer for the
	/// value's data.
	/// </para>
	/// <para>
	/// If hKey specifies <c>HKEY_PERFORMANCE_DATA</c> and the pvData buffer is not large enough to contain all of the returned data, the
	/// function returns ERROR_MORE_DATA and the value returned through the pcbData parameter is undefined. This is because the size of
	/// the performance data can change from one call to the next. In this case, you must increase the buffer size and call
	/// <c>RegGetValue</c> again passing the updated buffer size in the pcbData parameter. Repeat this until the function succeeds. You
	/// need to maintain a separate variable to keep track of the buffer size, because the value returned by pcbData is unpredictable.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// <para>If the pvData buffer is too small to receive the value, the function returns ERROR_MORE_DATA.</para>
	/// <para>
	/// If dwFlags specifies a combination of both <c>RRF_SUBKEY_WOW6464KEY</c> and <c>RRF_SUBKEY_WOW6432KEY</c>, the function returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application typically calls RegEnumValue to determine the value names and then <c>RegGetValue</c> to retrieve the data for the names.
	/// </para>
	/// <para>
	/// If the data has the REG_SZ, REG_MULTI_SZ or REG_EXPAND_SZ type, and the ANSI version of this function is used (either by
	/// explicitly calling <c>RegGetValueA</c> or by not defining UNICODE before including the Windows.h file), this function converts
	/// the stored Unicode string to an ANSI string before copying it to the buffer pointed to by pvData.
	/// </para>
	/// <para>
	/// When calling this function with hkey set to the <c>HKEY_PERFORMANCE_DATA</c> handle and a value string of a specified object, the
	/// returned data structure sometimes has unrequested objects. Do not be surprised; this is normal behavior. You should always expect
	/// to walk the returned data structure to look for the requested object.
	/// </para>
	/// <para>
	/// Note that operations that access certain registry keys are redirected. For more information, see Registry Virtualization and
	/// 32-bit and 64-bit Application Data in the Registry.
	/// </para>
	/// <para>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later. For more information, see Using the
	/// Windows Headers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-reggetvaluea LSTATUS RegGetValueA( HKEY hkey, LPCSTR
	// lpSubKey, LPCSTR lpValue, DWORD dwFlags, LPDWORD pdwType, PVOID pvData, LPDWORD pcbData );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "1c06facb-6735-4b3f-b77d-f162e3faaada")]
	public static extern Win32Error RegGetValue(HKEY hkey, [Optional] string? lpSubKey, [Optional] string? lpValue, RRF dwFlags, out REG_VALUE_TYPE pdwType, [Optional] IntPtr pvData, ref uint pcbData);

	/// <summary>
	/// <para>Loads the specified registry hive as an application hive.</para>
	/// </summary>
	/// <param name="lpFile">
	/// <para>
	/// The name of the hive file. This hive must have been created with the RegSaveKey or RegSaveKeyEx function. If the file does not
	/// exist, an empty hive file is created with the specified name.
	/// </para>
	/// </param>
	/// <param name="phkResult">
	/// <para>Pointer to the handle for the root key of the loaded hive.</para>
	/// <para>
	/// The only way to access keys in the hive is through this handle. The registry will prevent an application from accessing keys in
	/// this hive using an absolute path to the key. As a result, it is not possible to navigate to this hive through the registry's namespace.
	/// </para>
	/// </param>
	/// <param name="samDesired">
	/// <para>
	/// A mask that specifies the access rights requested for the returned root key. For more information, see Registry Key Security and
	/// Access Rights.
	/// </para>
	/// </param>
	/// <param name="dwOptions">
	/// <para>
	/// If this parameter is REG_PROCESS_APPKEY, the hive cannot be loaded again while it is loaded by the caller. This prevents access
	/// to this registry hive by another caller.
	/// </para>
	/// </param>
	/// <param name="Reserved">
	/// <para>This parameter is reserved.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Unlike RegLoadKey, <c>RegLoadAppKey</c> does not load the hive under HKEY_LOCAL_MACHINE or HKEY_USERS. Instead, the hive is
	/// loaded under a special root that cannot be enumerated. As a result, there is no way to enumerate hives currently loaded by
	/// <c>RegLoadAppKey</c>. All operations on hives loaded by <c>RegLoadAppKey</c> have to be performed relative to the handle returned
	/// in phkResult.
	/// </para>
	/// <para>
	/// If two processes are required to perform operations on the same hive, each process must call <c>RegLoadAppKey</c> to retrieve a
	/// handle. During the <c>RegLoadAppKey</c> operation, the registry will verify if the file has already been loaded. If it has been
	/// loaded, the registry will return a handle to the previously loaded hive rather than re-loading the hive.
	/// </para>
	/// <para>
	/// All keys inside the hive must have the same security descriptor, otherwise the function will fail. This security descriptor must
	/// grant the caller the access specified by the samDesired parameter or the function will fail. You cannot use the RegSetKeySecurity
	/// function on any key inside the hive.
	/// </para>
	/// <para>
	/// In Windows 8 and later, each process can call <c>RegLoadAppKey</c> to load multiple hives. In Windows 7 and earlier, each process
	/// can load only one hive using <c>RegLoadAppKey</c> at a time.
	/// </para>
	/// <para>
	/// Any hive loaded using <c>RegLoadAppKey</c> is automatically unloaded when all handles to the keys inside the hive are closed
	/// using RegCloseKey.
	/// </para>
	/// <para>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later. For more information, see Using the
	/// Windows Headers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regloadappkeya LSTATUS RegLoadAppKeyA( LPCSTR lpFile, PHKEY
	// phkResult, REGSAM samDesired, DWORD dwOptions, DWORD Reserved );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "88eb79c1-9ea0-436e-ad2e-9ce05b8dcb2c")]
	public static extern Win32Error RegLoadAppKey(string lpFile, out SafeRegistryHandle phkResult, REGSAM samDesired, [Optional] REG_APPKEY dwOptions, uint Reserved = 0);

	/// <summary>
	/// <para>
	/// Creates a subkey under <c>HKEY_USERS</c> or <c>HKEY_LOCAL_MACHINE</c> and loads the data from the specified registry hive into
	/// that subkey.
	/// </para>
	/// <para>
	/// Applications that back up or restore system state including system files and registry hives should use the Volume Shadow Copy
	/// Service instead of the registry functions.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to the key where the subkey will be created. This can be a handle returned by a call to RegConnectRegistry, or one of
	/// the following predefined handles:
	/// </para>
	/// <para>
	/// <c>HKEY_LOCAL_MACHINE</c><c>HKEY_USERS</c> This function always loads information at the top of the registry hierarchy. The
	/// <c>HKEY_CLASSES_ROOT</c> and <c>HKEY_CURRENT_USER</c> handle values cannot be specified for this parameter, because they
	/// represent subsets of the <c>HKEY_LOCAL_MACHINE</c> and <c>HKEY_USERS</c> handle values, respectively.
	/// </para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>
	/// The name of the key to be created under hKey. This subkey is where the registration information from the file will be loaded.
	/// </para>
	/// <para>Key names are not case sensitive.</para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// </param>
	/// <param name="lpFile">
	/// <para>
	/// The name of the file containing the registry data. This file must be a local file that was created with the RegSaveKey function.
	/// If this file does not exist, a file is created with the specified name.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// There are two registry hive file formats. Registry hives created on current operating systems typically cannot be loaded by
	/// earlier ones.
	/// </para>
	/// <para>If hKey is a handle returned by RegConnectRegistry, then the path specified in lpFile is relative to the remote computer.</para>
	/// <para>
	/// The calling process must have the SE_RESTORE_NAME and SE_BACKUP_NAME privileges on the computer in which the registry resides.
	/// For more information, see Running with Special Privileges. To load a hive without requiring these special privileges, use the
	/// RegLoadAppKey function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regloadkeya LSTATUS RegLoadKeyA( HKEY hKey, LPCSTR lpSubKey,
	// LPCSTR lpFile );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "536395aa-03ba-430d-a66d-fcabdc9dfe22")]
	public static extern Win32Error RegLoadKey(HKEY hKey, string lpSubKey, string lpFile);

	/// <summary>
	/// <para>Loads the specified string from the specified key and subkey.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_QUERY_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>or</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>function. It can also be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// </param>
	/// <param name="pszValue">
	/// <para>The name of the registry value.</para>
	/// </param>
	/// <param name="pszOutBuf">
	/// <para>A pointer to a buffer that receives the string.</para>
	/// <para>Strings of the following form receive special handling:</para>
	/// <para>@[path]&lt;i&gt;dllname,-strID</para>
	/// <para>
	/// The string with identifier strID is loaded from dllname; the path is optional. If the pszDirectory parameter is not <c>NULL</c>,
	/// the directory is prepended to the path specified in the registry data. Note that dllname can contain environment variables to be expanded.
	/// </para>
	/// </param>
	/// <param name="cbOutBuf">
	/// <para>The size of the pszOutBuf buffer, in bytes.</para>
	/// </param>
	/// <param name="pcbData">
	/// <para>A pointer to a variable that receives the size of the data copied to the pszOutBuf buffer, in bytes.</para>
	/// <para>
	/// If the buffer is not large enough to hold the data, the function returns ERROR_MORE_DATA and stores the required buffer size in
	/// the variable pointed to by pcbData. In this case, the contents of the buffer are undefined.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>This parameter can be 0 or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>REG_MUI_STRING_TRUNCATE 0x00000001</term>
	/// <term>
	/// The string is truncated to fit the available size of the pszOutBuf buffer. If this flag is specified, pcbData must be NULL.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszDirectory">
	/// <para>The directory path.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// <para>If the pcbData buffer is too small to receive the string, the function returns ERROR_MORE_DATA.</para>
	/// <para>The ANSI version of this function returns ERROR_CALL_NOT_IMPLEMENTED.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RegLoadMUIString</c> function is supported only for Unicode. Although both Unicode (W) and ANSI (A) versions of this
	/// function are declared, the <c>RegLoadMUIStringA</c> function returns ERROR_CALL_NOT_IMPLEMENTED. Applications should explicitly
	/// call <c>RegLoadMUIStringW</c> or specify Unicode as the character set in platform invoke (PInvoke) calls.
	/// </para>
	/// <para>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later. For more information, see Using the
	/// Windows Headers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regloadmuistringa LSTATUS RegLoadMUIStringA( HKEY hKey,
	// LPCSTR pszValue, PSTR pszOutBuf, DWORD cbOutBuf, LPDWORD pcbData, DWORD Flags, LPCSTR pszDirectory );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Unicode)]
	[PInvokeData("winreg.h", MSDNShortId = "76ffc77f-a1bc-4e01-858f-4a76563a2bbc")]
	public static extern Win32Error RegLoadMUIString(HKEY hKey, string pszValue, StringBuilder pszOutBuf, uint cbOutBuf, out uint pcbData, [Optional] REG_MUI_STRING Flags, [Optional] string? pszDirectory);

	/// <summary>Notifies the caller about changes to the attributes or contents of a specified registry key.</summary>
	/// <param name="hKey">A handle to an open registry key. This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function.</param>
	/// <param name="bWatchSubtree">
	/// If this parameter is TRUE, the function reports changes in the specified key and its subkeys. If the parameter is FALSE, the
	/// function reports changes only in the specified key.
	/// </param>
	/// <param name="dwFilter">A value that indicates the changes that should be reported.</param>
	/// <param name="hEvent">
	/// A handle to an event. If the fAsynchronous parameter is TRUE, the function returns immediately and changes are reported by
	/// signaling this event. If fAsynchronous is FALSE, hEvent is ignored.
	/// </param>
	/// <param name="fAsynchronous">
	/// If this parameter is TRUE, the function returns immediately and reports changes by signaling the specified event. If this
	/// parameter is FALSE, the function does not return until a change has occurred.
	/// <para>If hEvent does not specify a valid event, the fAsynchronous parameter cannot be TRUE.</para>
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is ERROR_SUCCESS.
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winreg.h", MSDNShortId = "ms724892")]
	public static extern Win32Error RegNotifyChangeKeyValue(HKEY hKey, [MarshalAs(UnmanagedType.Bool)] bool bWatchSubtree, RegNotifyChangeFilter dwFilter, HEVENT hEvent, [MarshalAs(UnmanagedType.Bool)] bool fAsynchronous);

	/// <summary>
	/// <para>Retrieves a handle to the <c>HKEY_CURRENT_USER</c> key for the user the current thread is impersonating.</para>
	/// </summary>
	/// <param name="samDesired">
	/// <para>
	/// A mask that specifies the desired access rights to the key. The function fails if the security descriptor of the key does not
	/// permit the requested access for the calling process. For more information, see Registry Key Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="phkResult">
	/// <para>
	/// A pointer to a variable that receives a handle to the opened key. When you no longer need the returned handle, call the
	/// RegCloseKey function to close it.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>HKEY_CURRENT_USER</c> key maps to the root of the current user's branch in the <c>HKEY_USERS</c> key. It is cached for all
	/// threads in a process. Therefore, this value does not change when another user's profile is loaded. <c>RegOpenCurrentUser</c> uses
	/// the thread's token to access the appropriate key, or the default if the profile is not loaded.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regopencurrentuser LSTATUS RegOpenCurrentUser( REGSAM
	// samDesired, PHKEY phkResult );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winreg.h", MSDNShortId = "10a8cbfb-52dc-436a-827e-78f12eb62af0")]
	public static extern Win32Error RegOpenCurrentUser(REGSAM samDesired, out SafeRegistryHandle phkResult);

	/// <summary>
	/// <para>Opens the specified registry key.</para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the
	/// RegOpenKeyEx function.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function, or it can be one of the
	/// following predefined keys:
	/// </para>
	/// <para><c>HKEY_CLASSES_ROOT</c><c>HKEY_CURRENT_CONFIG</c><c>HKEY_CURRENT_USER</c><c>HKEY_LOCAL_MACHINE</c><c>HKEY_USERS</c></para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>The name of the registry key to be opened. This key must be a subkey of the key identified by the hKey parameter.</para>
	/// <para>Key names are not case sensitive.</para>
	/// <para>
	/// If this parameter is <c>NULL</c> or a pointer to an empty string, the function returns the same handle that was passed in.
	/// </para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// </param>
	/// <param name="phkResult">
	/// <para>
	/// A pointer to a variable that receives a handle to the opened key. If the key is not one of the predefined registry keys, call the
	/// RegCloseKey function after you have finished using the handle.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RegOpenKey</c> function uses the default security access mask to open a key. If opening the key requires a different
	/// access right, the function fails, returning ERROR_ACCESS_DENIED. An application should use the RegOpenKeyEx function to specify
	/// an access mask in this situation.
	/// </para>
	/// <para><c>RegOpenKey</c> does not create the specified key if the key does not exist in the database.</para>
	/// <para>
	/// If your service or application impersonates different users, do not use this function with <c>HKEY_CURRENT_USER</c>. Instead,
	/// call the RegOpenCurrentUser function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regopenkeya LSTATUS RegOpenKeyA( HKEY hKey, LPCSTR lpSubKey,
	// PHKEY phkResult );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "bad0a0f8-1889-4eff-98be-084c95d69f3b")]
	public static extern Win32Error RegOpenKey(HKEY hKey, [Optional] string? lpSubKey, out SafeRegistryHandle phkResult);

	/// <summary>Opens the specified registry key. Note that key names are not case sensitive.</summary>
	/// <param name="hKey">
	/// A handle to an open registry key. This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function, or it can be one of the
	/// predefined keys.
	/// </param>
	/// <param name="lpSubKey">
	/// The name of the registry subkey to be opened.
	/// <para>Key names are not case sensitive.</para>
	/// <para>
	/// The lpSubKey parameter can be a pointer to an empty string. If lpSubKey is a pointer to an empty string and hKey is
	/// HKEY_CLASSES_ROOT, phkResult receives the same hKey handle passed into the function. Otherwise, phkResult receives a new handle
	/// to the key specified by hKey.
	/// </para>
	/// <para>
	/// The lpSubKey parameter can be NULL only if hKey is one of the predefined keys. If lpSubKey is NULL and hKey is HKEY_CLASSES_ROOT,
	/// phkResult receives a new handle to the key specified by hKey. Otherwise, phkResult receives the same hKey handle passed in to the function.
	/// </para>
	/// </param>
	/// <param name="ulOptions">Specifies the option to apply when opening the key.</param>
	/// <param name="samDesired">
	/// A mask that specifies the desired access rights to the key to be opened. The function fails if the security descriptor of the key
	/// does not permit the requested access for the calling process. For more information, see Registry Key Security and Access Rights.
	/// </param>
	/// <param name="phkResult">
	/// A pointer to a variable that receives a handle to the opened key. If the key is not one of the predefined registry keys, call the
	/// RegCloseKey function after you have finished using the handle.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is ERROR_SUCCESS.
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "ms724897")]
	public static extern Win32Error RegOpenKeyEx(HKEY hKey, [Optional] string? lpSubKey, [Optional] RegOpenOptions ulOptions, [Optional] REGSAM samDesired, out SafeRegistryHandle phkResult);

	/// <summary>
	/// <para>Opens the specified registry key and associates it with a transaction. Note that key names are not case sensitive.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or
	/// <c>RegOpenKeyTransacted</c> function. It can also be one of the following predefined keys:
	/// </para>
	/// <para><c>HKEY_CLASSES_ROOT</c><c>HKEY_CURRENT_USER</c><c>HKEY_LOCAL_MACHINE</c><c>HKEY_USERS</c></para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>The name of the registry subkey to be opened.</para>
	/// <para>Key names are not case sensitive.</para>
	/// <para>
	/// If this parameter is <c>NULL</c> or a pointer to an empty string, the function will open a new handle to the key identified by
	/// the hKey parameter.
	/// </para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// </param>
	/// <param name="ulOptions">
	/// <para>This parameter is reserved and must be zero.</para>
	/// </param>
	/// <param name="samDesired">
	/// <para>
	/// A mask that specifies the desired access rights to the key. The function fails if the security descriptor of the key does not
	/// permit the requested access for the calling process. For more information, see Registry Key Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="phkResult">
	/// <para>
	/// A pointer to a variable that receives a handle to the opened key. If the key is not one of the predefined registry keys, call the
	/// RegCloseKey function after you have finished using the handle.
	/// </para>
	/// </param>
	/// <param name="hTransaction">
	/// <para>A handle to an active transaction. This handle is returned by the CreateTransaction function.</para>
	/// </param>
	/// <param name="pExtendedParemeter">
	/// <para>This parameter is reserved and must be <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When a key is opened using this function, subsequent operations on the key are transacted. If a non-transacted operation is
	/// performed on the key before the transaction is committed, the transaction is rolled back. After a transaction is committed or
	/// rolled back, you must re-open the key using the RegCreateKeyTransacted or <c>RegOpenKeyTransacted</c> function with an active
	/// transaction handle to make additional operations transacted. For more information about transactions, see Kernel Transaction Manager.
	/// </para>
	/// <para>
	/// Note that subsequent operations on subkeys of this key are not automatically transacted. Therefore, the RegDeleteKeyEx function
	/// does not perform a transacted delete operation. Instead, use the RegDeleteKeyTransacted function to perform a transacted delete operation.
	/// </para>
	/// <para>
	/// Unlike the RegCreateKeyTransacted function, the <c>RegOpenKeyTransacted</c> function does not create the specified key if the key
	/// does not exist in the registry.
	/// </para>
	/// <para>
	/// If your service or application impersonates different users, do not use this function with <c>HKEY_CURRENT_USER</c>. Instead,
	/// call the RegOpenCurrentUser function.
	/// </para>
	/// <para>
	/// A single registry key can be opened only 65,534 times. When attempting the 65,535 open operation, this function fails with ERROR_NO_SYSTEM_RESOURCES.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regopenkeytransacteda LSTATUS RegOpenKeyTransactedA( HKEY
	// hKey, LPCSTR lpSubKey, DWORD ulOptions, REGSAM samDesired, PHKEY phkResult, HANDLE hTransaction, PVOID pExtendedParemeter );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "11663ed2-d17c-4f08-be7b-9b591271fbcd")]
	public static extern Win32Error RegOpenKeyTransacted(HKEY hKey, [Optional] string? lpSubKey, [Optional] uint ulOptions, [Optional] REGSAM samDesired, out SafeRegistryHandle phkResult, HTRXN hTransaction, [Optional] IntPtr pExtendedParemeter);

	/// <summary>
	/// <para>
	/// Retrieves a handle to the <c>HKEY_CLASSES_ROOT</c> key for a specified user. The user is identified by an access token. The
	/// returned key has a view of the registry that merges the contents of the <c>HKEY_LOCAL_MACHINE</c>\Software\Classes key with the
	/// contents of the Software\Classes keys in the user's registry hive. For more information, see HKEY_CLASSES_ROOT Key.
	/// </para>
	/// </summary>
	/// <param name="hToken">
	/// <para>
	/// A handle to a primary or impersonation access token that identifies the user of interest. This can be a token handle returned by
	/// a call to LogonUser, CreateRestrictedToken, DuplicateToken, DuplicateTokenEx, OpenProcessToken, or OpenThreadToken functions.
	/// </para>
	/// <para>The handle must have TOKEN_QUERY access. For more information, see Access Rights for Access-Token Objects.</para>
	/// </param>
	/// <param name="dwOptions">
	/// <para>This parameter is reserved and must be zero.</para>
	/// </param>
	/// <param name="samDesired">
	/// <para>
	/// A mask that specifies the desired access rights to the key. The function fails if the security descriptor of the key does not
	/// permit the requested access for the calling process. For more information, see Registry Key Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="phkResult">
	/// <para>
	/// A pointer to a variable that receives a handle to the opened key. When you no longer need the returned handle, call the
	/// RegCloseKey function to close it.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RegOpenUserClassesRoot</c> function enables you to retrieve the merged <c>HKEY_CLASSES_ROOT</c> information for users
	/// other than the interactive user. For example, the server component of a client/server application could use
	/// <c>RegOpenUserClassesRoot</c> to retrieve the merged information for a client.
	/// </para>
	/// <para>
	/// <c>RegOpenUserClassesRoot</c> fails if the user profile for the specified user is not loaded. When a user logs on interactively,
	/// the system automatically loads the user's profile. For other users, you can call the LoadUserProfile function to load the user's
	/// profile. However, <c>LoadUserProfile</c> can be very time-consuming, so do not call it for this purpose unless it is absolutely
	/// necessary to have the user's merged <c>HKEY_CLASSES_ROOT</c> information.
	/// </para>
	/// <para>
	/// Applications running in the security context of the interactively logged-on user do not need to use
	/// <c>RegOpenUserClassesRoot</c>. These applications can call the RegOpenKeyEx function to retrieve a merged view of the
	/// <c>HKEY_CLASSES_ROOT</c> key for the interactive user.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regopenuserclassesroot LSTATUS RegOpenUserClassesRoot(
	// HANDLE hToken, DWORD dwOptions, REGSAM samDesired, PHKEY phkResult );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winreg.h", MSDNShortId = "bd068826-cf88-4fc7-a7d6-96cc03e923c7")]
	public static extern Win32Error RegOpenUserClassesRoot(HTOKEN hToken, [Optional] uint dwOptions, [Optional] REGSAM samDesired, out SafeRegistryHandle phkResult);

	/// <summary>
	/// <para>Maps a predefined registry key to the specified registry key.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>A handle to one of the following predefined keys:</para>
	/// <para><c>HKEY_CLASSES_ROOT</c><c>HKEY_CURRENT_CONFIG</c><c>HKEY_CURRENT_USER</c><c>HKEY_LOCAL_MACHINE</c><c>HKEY_PERFORMANCE_DATA</c><c>HKEY_USERS</c></para>
	/// </param>
	/// <param name="hNewHKey">
	/// <para>
	/// A handle to an open registry key. This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function. It cannot be one of the
	/// predefined keys. The function maps hKey to refer to the hNewHKey key. This affects only the calling process.
	/// </para>
	/// <para>If hNewHKey is <c>NULL</c>, the function restores the default mapping of the predefined key.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RegOverridePredefKey</c> function is intended for software installation programs. It allows them to remap a predefined
	/// key, load a DLL component that will be installed on the system, call an entry point in the DLL, and examine the changes to the
	/// registry that the component attempted to make. The installation program can then write those changes to the locations intended by
	/// the DLL, or make changes to the data before writing it.
	/// </para>
	/// <para>
	/// For example, consider an installation program that installs an ActiveX control as part of an application installation. The
	/// installation program needs to call the control's DllRegisterServer entry point to enable the control to register itself. Before
	/// this call, the installation program can call <c>RegOverridePredefKey</c> to remap <c>HKEY_CLASSES_ROOT</c> to a temporary key
	/// such as <c>HKEY_CURRENT_USER</c>&lt;b&gt;TemporaryInstall&lt;b&gt;DllRegistration. It then calls <c>DllRegisterServer</c>, which
	/// causes the ActiveX control to write its registry entries to the temporary key. The installation program then calls
	/// <c>RegOverridePredefKey</c> again to restore the original mapping of <c>HKEY_CLASSES_ROOT</c>. The installation program can
	/// modify the keys written to the temporary key, if necessary, before copying them to the original <c>HKEY_CLASSES_ROOT</c>.
	/// </para>
	/// <para>
	/// After the call to <c>RegOverridePredefKey</c>, you can safely call RegCloseKey to close the hNewHKey handle. The system maintains
	/// its own reference to hNewHKey.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regoverridepredefkey LSTATUS RegOverridePredefKey( HKEY
	// hKey, HKEY hNewHKey );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winreg.h", MSDNShortId = "ad58b7ff-cd61-4719-9028-b470ae7e9bb0")]
	public static extern Win32Error RegOverridePredefKey(HKEY hKey, HKEY hNewHKey);

	/// <summary>
	/// <para>Retrieves information about the specified registry key.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_QUERY_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or RegOpenKeyTransacted function. It can
	/// also be one of the following predefined keys:
	/// </para>
	/// </param>
	/// <param name="lpClass">
	/// <para>A pointer to a buffer that receives the user-defined class of the key. This parameter can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpcchClass">
	/// <para>A pointer to a variable that specifies the size of the buffer pointed to by the lpClass parameter, in characters.</para>
	/// <para>
	/// The size should include the terminating <c>null</c> character. When the function returns, this variable contains the size of the
	/// class string that is stored in the buffer. The count returned does not include the terminating <c>null</c> character. If the
	/// buffer is not big enough, the function returns ERROR_MORE_DATA, and the variable contains the size of the string, in characters,
	/// without counting the terminating <c>null</c> character.
	/// </para>
	/// <para>If lpClass is <c>NULL</c>, lpcClass can be <c>NULL</c>.</para>
	/// <para>
	/// If the lpClass parameter is a valid address, but the lpcClass parameter is not, for example, it is <c>NULL</c>, then the function
	/// returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <param name="lpReserved">
	/// <para>This parameter is reserved and must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpcSubKeys">
	/// <para>
	/// A pointer to a variable that receives the number of subkeys that are contained by the specified key. This parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="lpcbMaxSubKeyLen">
	/// <para>
	/// A pointer to a variable that receives the size of the key's subkey with the longest name, in Unicode characters, not including
	/// the terminating <c>null</c> character. This parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="lpcbMaxClassLen">
	/// <para>
	/// A pointer to a variable that receives the size of the longest string that specifies a subkey class, in Unicode characters. The
	/// count returned does not include the terminating <c>null</c> character. This parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="lpcValues">
	/// <para>A pointer to a variable that receives the number of values that are associated with the key. This parameter can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpcbMaxValueNameLen">
	/// <para>
	/// A pointer to a variable that receives the size of the key's longest value name, in Unicode characters. The size does not include
	/// the terminating <c>null</c> character. This parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="lpcbMaxValueLen">
	/// <para>
	/// A pointer to a variable that receives the size of the longest data component among the key's values, in bytes. This parameter can
	/// be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="lpcbSecurityDescriptor">
	/// <para>A pointer to a variable that receives the size of the key's security descriptor, in bytes. This parameter can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpftLastWriteTime">
	/// <para>A pointer to a FILETIME structure that receives the last write time. This parameter can be <c>NULL</c>.</para>
	/// <para>
	/// The function sets the members of the FILETIME structure to indicate the last time that the key or any of its value entries is modified.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// <para>If the lpClass buffer is too small to receive the name of the class, the function returns ERROR_MORE_DATA.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regqueryinfokeya LSTATUS RegQueryInfoKeyA( HKEY hKey, PSTR
	// lpClass, LPDWORD lpcchClass, LPDWORD lpReserved, LPDWORD lpcSubKeys, LPDWORD lpcbMaxSubKeyLen, LPDWORD lpcbMaxClassLen, LPDWORD
	// lpcValues, LPDWORD lpcbMaxValueNameLen, LPDWORD lpcbMaxValueLen, LPDWORD lpcbSecurityDescriptor, PFILETIME lpftLastWriteTime );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "25eb2cd2-9fdd-4d6f-8071-daab56f9aae1")]
	public static extern Win32Error RegQueryInfoKey(HKEY hKey, [Optional] StringBuilder? lpClass, ref uint lpcchClass, [Optional] IntPtr lpReserved, out uint lpcSubKeys, out uint lpcbMaxSubKeyLen,
		out uint lpcbMaxClassLen, out uint lpcValues, out uint lpcbMaxValueNameLen, out uint lpcbMaxValueLen, out uint lpcbSecurityDescriptor, out FILETIME lpftLastWriteTime);

	/// <summary>
	/// <para>Retrieves information about the specified registry key.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_QUERY_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or RegOpenKeyTransacted function. It can
	/// also be one of the following predefined keys:
	/// </para>
	/// </param>
	/// <param name="lpClass">
	/// <para>A pointer to a buffer that receives the user-defined class of the key. This parameter can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpcchClass">
	/// <para>A pointer to a variable that specifies the size of the buffer pointed to by the lpClass parameter, in characters.</para>
	/// <para>
	/// The size should include the terminating <c>null</c> character. When the function returns, this variable contains the size of the
	/// class string that is stored in the buffer. The count returned does not include the terminating <c>null</c> character. If the
	/// buffer is not big enough, the function returns ERROR_MORE_DATA, and the variable contains the size of the string, in characters,
	/// without counting the terminating <c>null</c> character.
	/// </para>
	/// <para>If lpClass is <c>NULL</c>, lpcClass can be <c>NULL</c>.</para>
	/// <para>
	/// If the lpClass parameter is a valid address, but the lpcClass parameter is not, for example, it is <c>NULL</c>, then the function
	/// returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <param name="lpReserved">
	/// <para>This parameter is reserved and must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpcSubKeys">
	/// <para>
	/// A pointer to a variable that receives the number of subkeys that are contained by the specified key. This parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="lpcbMaxSubKeyLen">
	/// <para>
	/// A pointer to a variable that receives the size of the key's subkey with the longest name, in Unicode characters, not including
	/// the terminating <c>null</c> character. This parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="lpcbMaxClassLen">
	/// <para>
	/// A pointer to a variable that receives the size of the longest string that specifies a subkey class, in Unicode characters. The
	/// count returned does not include the terminating <c>null</c> character. This parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="lpcValues">
	/// <para>A pointer to a variable that receives the number of values that are associated with the key. This parameter can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpcbMaxValueNameLen">
	/// <para>
	/// A pointer to a variable that receives the size of the key's longest value name, in Unicode characters. The size does not include
	/// the terminating <c>null</c> character. This parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="lpcbMaxValueLen">
	/// <para>
	/// A pointer to a variable that receives the size of the longest data component among the key's values, in bytes. This parameter can
	/// be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="lpcbSecurityDescriptor">
	/// <para>A pointer to a variable that receives the size of the key's security descriptor, in bytes. This parameter can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpftLastWriteTime">
	/// <para>A pointer to a FILETIME structure that receives the last write time. This parameter can be <c>NULL</c>.</para>
	/// <para>
	/// The function sets the members of the FILETIME structure to indicate the last time that the key or any of its value entries is modified.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// <para>If the lpClass buffer is too small to receive the name of the class, the function returns ERROR_MORE_DATA.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regqueryinfokeya LSTATUS RegQueryInfoKeyA( HKEY hKey, PSTR
	// lpClass, LPDWORD lpcchClass, LPDWORD lpReserved, LPDWORD lpcSubKeys, LPDWORD lpcbMaxSubKeyLen, LPDWORD lpcbMaxClassLen, LPDWORD
	// lpcValues, LPDWORD lpcbMaxValueNameLen, LPDWORD lpcbMaxValueLen, LPDWORD lpcbSecurityDescriptor, PFILETIME lpftLastWriteTime );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "25eb2cd2-9fdd-4d6f-8071-daab56f9aae1")]
	public static extern unsafe Win32Error RegQueryInfoKey(HKEY hKey, [Optional] void* lpClass, [Optional] uint* lpcchClass, [Optional] void* lpReserved, [Optional] uint* lpcSubKeys, [Optional] uint* lpcbMaxSubKeyLen,
		[Optional] uint* lpcbMaxClassLen, [Optional] uint* lpcValues, [Optional] uint* lpcbMaxValueNameLen, [Optional] uint* lpcbMaxValueLen, [Optional] uint* lpcbSecurityDescriptor, [Optional] FILETIME* lpftLastWriteTime);

	/// <summary>
	/// <para>Retrieves the type and data for a list of value names associated with an open registry key.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_QUERY_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>,</para>
	/// <para>RegCreateKeyTransacted</para>
	/// <para>,</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>, or</para>
	/// <para>RegOpenKeyTransacted</para>
	/// <para>function. It can also be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// </param>
	/// <param name="val_list">
	/// <para>
	/// A pointer to an array of VALENT structures that describe one or more value entries. On input, the <c>ve_valuename</c> member of
	/// each structure must contain a pointer to the name of a value to retrieve. The function fails if any of the specified values do
	/// not exist in the specified key.
	/// </para>
	/// <para>If the function succeeds, each element of the array contains the information for the specified value.</para>
	/// </param>
	/// <param name="num_vals">
	/// <para>The number of elements in the val_list array.</para>
	/// </param>
	/// <param name="lpValueBuf">
	/// <para>A pointer to a buffer. If the function succeeds, the buffer receives the data for each value.</para>
	/// <para>
	/// If lpValueBuf is <c>NULL</c>, the value pointed to by the ldwTotsize parameter must be zero, in which case the function returns
	/// ERROR_MORE_DATA and ldwTotsize receives the required size of the buffer, in bytes.
	/// </para>
	/// </param>
	/// <param name="ldwTotsize">
	/// <para>
	/// A pointer to a variable that specifies the size of the buffer pointed to by the lpValueBuf parameter, in bytes. If the function
	/// succeeds, ldwTotsize receives the number of bytes copied to the buffer. If the function fails because the buffer is too small,
	/// ldwTotsize receives the required size, in bytes.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_CANTREAD</term>
	/// <term>RegQueryMultipleValues cannot instantiate or access the provider of the dynamic key.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The buffer pointed to by lpValueBuf was too small. In this case, ldwTotsize receives the required buffer size.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_TRANSFER_TOO_LONG</term>
	/// <term>The total size of the requested data (size of the val_list array + ldwTotSize) is more than the system limit of one megabyte.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RegQueryMultipleValues</c> function allows an application to query one or more values of a static or dynamic key. If the
	/// target key is a static key, the system provides all of the values in an atomic fashion. To prevent excessive serialization, the
	/// aggregate data returned by the function cannot exceed one megabyte.
	/// </para>
	/// <para>
	/// If the target key is a dynamic key, its provider must provide all the values in an atomic fashion. This means the provider should
	/// fill the results buffer synchronously, providing a consistent view of all the values in the buffer while avoiding excessive
	/// serialization. The provider can provide at most one megabyte of total output data during an atomic call to this function.
	/// </para>
	/// <para>
	/// <c>RegQueryMultipleValues</c> is supported remotely; that is, the hKey parameter passed to the function can refer to a remote computer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regquerymultiplevaluesa LSTATUS RegQueryMultipleValuesA(
	// HKEY hKey, PVALENTA val_list, DWORD num_vals, __out_data_source(REGISTRY)PSTR lpValueBuf, LPDWORD ldwTotsize );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "e718534a-6e68-40f5-9cdd-170ce9b5e6e5")]
	public static extern Win32Error RegQueryMultipleValues(HKEY hKey, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] VALENT[] val_list, uint num_vals, [Optional] IntPtr lpValueBuf, ref uint ldwTotsize);

	/// <summary>Retrieves the type and data for a list of value names associated with an open registry key.</summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_QUERY_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or RegOpenKeyTransacted function. It can also be
	/// one of the following predefined keys:
	/// </para>
	/// <list/>
	/// </param>
	/// <param name="val_list">
	/// <para>
	/// A pointer to an array of names of the values to retrieve. The function fails if any of the specified values do not exist in the
	/// specified key.
	/// </para>
	/// </param>
	/// <returns>A dictionary with the specified names and their queried values.</returns>
	/// <remarks>
	/// <para>
	/// The <c>RegQueryMultipleValues</c> function allows an application to query one or more values of a static or dynamic key. If the
	/// target key is a static key, the system provides all of the values in an atomic fashion. To prevent excessive serialization, the
	/// aggregate data returned by the function cannot exceed one megabyte.
	/// </para>
	/// <para>
	/// If the target key is a dynamic key, its provider must provide all the values in an atomic fashion. This means the provider should
	/// fill the results buffer synchronously, providing a consistent view of all the values in the buffer while avoiding excessive
	/// serialization. The provider can provide at most one megabyte of total output data during an atomic call to this function.
	/// </para>
	/// <para>
	/// <c>RegQueryMultipleValues</c> is supported remotely; that is, the <c>hKey</c> parameter passed to the function can refer to a remote computer.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regquerymultiplevaluesa
	// LSTATUS RegQueryMultipleValuesA( [in] HKEY hKey, [out] PVALENTA val_list, [in] DWORD num_vals, [out, optional] PSTR lpValueBuf, [in, out, optional] LPDWORD ldwTotsize );
	[PInvokeData("winreg.h", MSDNShortId = "NF:winreg.RegQueryMultipleValuesA")]
	public static IReadOnlyDictionary<string, object?> RegQueryMultipleValues(HKEY hKey, params string[] val_list)
	{
		var val = Array.ConvertAll(val_list, s => new VALENT(s));
		uint sz = 0;
		RegQueryMultipleValues(hKey, val, (uint)val.Length, default, ref sz).ThrowUnless(Win32Error.ERROR_MORE_DATA);
		using SafeCoTaskMemHandle mem = new(sz);
		RegQueryMultipleValues(hKey, val, (uint)val.Length, mem, ref sz).ThrowIfFailed();
		return val.ToDictionary(v => v.ve_valuename, v => v.ve_type.GetValue(v.ve_valueptr, v.ve_valuelen));
	}

	/// <summary>
	/// <para>Determines whether reflection has been disabled or enabled for the specified key.</para>
	/// </summary>
	/// <param name="hBase">
	/// <para>
	/// A handle to the registry key. This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or
	/// RegOpenKeyTransacted function; it cannot specify a key on a remote computer.
	/// </para>
	/// </param>
	/// <param name="bIsReflectionDisabled">
	/// <para>A value that indicates whether reflection has been disabled through RegDisableReflectionKey or enabled through RegEnableReflectionKey.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// On WOW64, 32-bit applications view a registry tree that is separate from the registry tree that 64-bit applications view.
	/// Registry reflection copies specific registry keys and values between the two views.
	/// </para>
	/// <para>
	/// To disable registry reflection, use the RegDisableReflectionKey function. To restore reflection for a disabled key, use the
	/// RegEnableReflectionKey function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regqueryreflectionkey LONG RegQueryReflectionKey( HKEY
	// hBase, BOOL *bIsReflectionDisabled );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winreg.h", MSDNShortId = "d7516eab-dbcf-4ece-931e-d7bb2a983503")]
	public static extern Win32Error RegQueryReflectionKey(HKEY hBase, [MarshalAs(UnmanagedType.Bool)] out bool bIsReflectionDisabled);

	/// <summary>
	/// <para>
	/// Retrieves the data associated with the default or unnamed value of a specified registry key. The data must be a
	/// <c>null</c>-terminated string.
	/// </para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the
	/// RegQueryValueEx function.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_QUERY_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>,</para>
	/// <para>RegCreateKeyTransacted</para>
	/// <para>,</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>, or</para>
	/// <para>RegOpenKeyTransacted</para>
	/// <para>function. It can also be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>The name of the subkey of the hKey parameter for which the default value is retrieved.</para>
	/// <para>Key names are not case sensitive.</para>
	/// <para>
	/// If this parameter is <c>NULL</c> or points to an empty string, the function retrieves the default value for the key identified by hKey.
	/// </para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// </param>
	/// <param name="lpData">
	/// <para>A pointer to a buffer that receives the default value of the specified key.</para>
	/// <para>
	/// If lpValue is <c>NULL</c>, and lpcbValue is non- <c>NULL</c>, the function returns ERROR_SUCCESS, and stores the size of the
	/// data, in bytes, in the variable pointed to by lpcbValue. This enables an application to determine the best way to allocate a
	/// buffer for the value's data.
	/// </para>
	/// </param>
	/// <param name="lpcbData">
	/// <para>
	/// A pointer to a variable that specifies the size of the buffer pointed to by the lpValue parameter, in bytes. When the function
	/// returns, this variable contains the size of the data copied to lpValue, including any terminating <c>null</c> characters.
	/// </para>
	/// <para>
	/// If the data has the REG_SZ, REG_MULTI_SZ or REG_EXPAND_SZ type, this size includes any terminating <c>null</c> character or
	/// characters. For more information, see Remarks.
	/// </para>
	/// <para>
	/// If the buffer specified lpValue is not large enough to hold the data, the function returns ERROR_MORE_DATA and stores the
	/// required buffer size in the variable pointed to by lpcbValue. In this case, the contents of the lpValue buffer are undefined.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// <para>If the lpValue buffer is too small to receive the value, the function returns ERROR_MORE_DATA.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the ANSI version of this function is used (either by explicitly calling <c>RegQueryValueA</c> or by not defining UNICODE
	/// before including the Windows.h file), this function converts the stored Unicode string to an ANSI string before copying it to the
	/// buffer specified by the lpValue parameter.
	/// </para>
	/// <para>
	/// If the data has the REG_SZ, REG_MULTI_SZ or REG_EXPAND_SZ type, the string may not have been stored with the proper
	/// <c>null</c>-terminating characters. Therefore, even if the function returns ERROR_SUCCESS, the application should ensure that the
	/// string is properly terminated before using it; otherwise, it may overwrite a buffer. (Note that REG_MULTI_SZ strings should have
	/// two <c>null</c>-terminating characters.)
	/// </para>
	/// <para>
	/// Note that operations that access certain registry keys are redirected. For more information, see Registry Virtualization and
	/// 32-bit and 64-bit Application Data in the Registry.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regqueryvaluea LSTATUS RegQueryValueA( HKEY hKey, LPCSTR
	// lpSubKey, __out_data_source(REGISTRY)PSTR lpData, PLONG lpcbData );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "18f27717-3bd9-45ac-a1ea-61abc1753a52")]
	public static extern Win32Error RegQueryValue(HKEY hKey, [Optional] string? lpSubKey, [Optional] IntPtr lpData, ref int lpcbData);

	/// <summary>
	/// <para>Retrieves the type and data for the specified value name associated with an open registry key.</para>
	/// <para>
	/// To ensure that any string values (REG_SZ, REG_MULTI_SZ, and REG_EXPAND_SZ) returned are <c>null</c>-terminated, use the
	/// RegGetValue function.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_QUERY_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>,</para>
	/// <para>RegCreateKeyTransacted</para>
	/// <para>,</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>, or</para>
	/// <para>RegOpenKeyTransacted</para>
	/// <para>function. It can also be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// </param>
	/// <param name="lpValueName">
	/// <para>The name of the registry value.</para>
	/// <para>
	/// If lpValueName is <c>NULL</c> or an empty string, "", the function retrieves the type and data for the key's unnamed or default
	/// value, if any.
	/// </para>
	/// <para>If lpValueName specifies a value that is not in the registry, the function returns ERROR_FILE_NOT_FOUND.</para>
	/// <para>
	/// Keys do not automatically have an unnamed or default value. Unnamed values can be of any type. For more information, see Registry
	/// Element Size Limits.
	/// </para>
	/// </param>
	/// <param name="lpReserved">
	/// <para>This parameter is reserved and must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpType">
	/// <para>
	/// A pointer to a variable that receives a code indicating the type of data stored in the specified value. For a list of the
	/// possible type codes, see Registry Value Types. The lpType parameter can be <c>NULL</c> if the type code is not required.
	/// </para>
	/// </param>
	/// <param name="lpData">
	/// <para>A pointer to a buffer that receives the value's data. This parameter can be <c>NULL</c> if the data is not required.</para>
	/// </param>
	/// <param name="lpcbData">
	/// <para>
	/// A pointer to a variable that specifies the size of the buffer pointed to by the lpData parameter, in bytes. When the function
	/// returns, this variable contains the size of the data copied to lpData.
	/// </para>
	/// <para>The lpcbData parameter can be <c>NULL</c> only if lpData is <c>NULL</c>.</para>
	/// <para>
	/// If the data has the REG_SZ, REG_MULTI_SZ or REG_EXPAND_SZ type, this size includes any terminating <c>null</c> character or
	/// characters unless the data was stored without them. For more information, see Remarks.
	/// </para>
	/// <para>
	/// If the buffer specified by lpData parameter is not large enough to hold the data, the function returns ERROR_MORE_DATA and stores
	/// the required buffer size in the variable pointed to by lpcbData. In this case, the contents of the lpData buffer are undefined.
	/// </para>
	/// <para>
	/// If lpData is <c>NULL</c>, and lpcbData is non- <c>NULL</c>, the function returns ERROR_SUCCESS and stores the size of the data,
	/// in bytes, in the variable pointed to by lpcbData. This enables an application to determine the best way to allocate a buffer for
	/// the value's data.
	/// </para>
	/// <para>
	/// If hKey specifies <c>HKEY_PERFORMANCE_DATA</c> and the lpData buffer is not large enough to contain all of the returned data,
	/// <c>RegQueryValueEx</c> returns ERROR_MORE_DATA and the value returned through the lpcbData parameter is undefined. This is
	/// because the size of the performance data can change from one call to the next. In this case, you must increase the buffer size
	/// and call <c>RegQueryValueEx</c> again passing the updated buffer size in the lpcbData parameter. Repeat this until the function
	/// succeeds. You need to maintain a separate variable to keep track of the buffer size, because the value returned by lpcbData is unpredictable.
	/// </para>
	/// <para>
	/// If the lpValueName registry value does not exist, <c>RegQueryValueEx</c> returns ERROR_FILE_NOT_FOUND and the value returned
	/// through the lpcbData parameter is undefined.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// <para>If the lpData buffer is too small to receive the data, the function returns ERROR_MORE_DATA.</para>
	/// <para>If the lpValueName registry value does not exist, the function returns ERROR_FILE_NOT_FOUND.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application typically calls RegEnumValue to determine the value names and then <c>RegQueryValueEx</c> to retrieve the data for
	/// the names.
	/// </para>
	/// <para>
	/// If the data has the REG_SZ, REG_MULTI_SZ or REG_EXPAND_SZ type, the string may not have been stored with the proper terminating
	/// <c>null</c> characters. Therefore, even if the function returns ERROR_SUCCESS, the application should ensure that the string is
	/// properly terminated before using it; otherwise, it may overwrite a buffer. (Note that REG_MULTI_SZ strings should have two
	/// terminating <c>null</c> characters.) One way an application can ensure that the string is properly terminated is to use
	/// RegGetValue, which adds terminating <c>null</c> characters if needed.
	/// </para>
	/// <para>
	/// If the data has the REG_SZ, REG_MULTI_SZ or REG_EXPAND_SZ type, and the ANSI version of this function is used (either by
	/// explicitly calling <c>RegQueryValueExA</c> or by not defining UNICODE before including the Windows.h file), this function
	/// converts the stored Unicode string to an ANSI string before copying it to the buffer pointed to by lpData.
	/// </para>
	/// <para>
	/// When calling the <c>RegQueryValueEx</c> function with hKey set to the <c>HKEY_PERFORMANCE_DATA</c> handle and a value string of a
	/// specified object, the returned data structure sometimes has unrequested objects. Do not be surprised; this is normal behavior.
	/// When calling the <c>RegQueryValueEx</c> function, you should always expect to walk the returned data structure to look for the
	/// requested object.
	/// </para>
	/// <para>
	/// Note that operations that access certain registry keys are redirected. For more information, see Registry Virtualization and
	/// 32-bit and 64-bit Application Data in the Registry.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// Ensure that you reinitialize the value pointed to by the lpcbData parameter each time you call this function. This is very
	/// important when you call this function in a loop, as in the following code example.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regqueryvalueexa LSTATUS RegQueryValueExA( HKEY hKey, LPCSTR
	// lpValueName, LPDWORD lpReserved, LPDWORD lpType, __out_data_source(REGISTRY)LPBYTE lpData, LPDWORD lpcbData );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "202d253a-10ff-40e7-8eec-a49717443b81")]
	public static extern Win32Error RegQueryValueEx(HKEY hKey, string? lpValueName, [Optional] IntPtr lpReserved, out REG_VALUE_TYPE lpType, [Optional] IntPtr lpData, ref uint lpcbData);

	/// <summary>
	/// <para>Retrieves the type and data for the specified value name associated with an open registry key.</para>
	/// <para>
	/// <para>Warning</para>
	/// <para>
	/// If the value being queried is a string (REG_SZ, REG_MULTI_SZ, and REG_EXPAND_SZ) the value returned is NOT guaranteed to be
	/// null-terminated. Use the RegGetValue function if you want to ensure returned string values are null-terminated. More information is
	/// in the remarks below.
	/// </para>
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_QUERY_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or RegOpenKeyTransacted function. It can also be
	/// one of the following predefined keys:
	/// </para>
	/// <list/>
	/// </param>
	/// <param name="lpValueName">
	/// <para>The name of the registry value.</para>
	/// <para>
	/// If <c>lpValueName</c> is <c>NULL</c> or an empty string, "", the function retrieves the type and data for the key's unnamed or
	/// default value, if any.
	/// </para>
	/// <para>If <c>lpValueName</c> specifies a value that is not in the registry, the function returns ERROR_FILE_NOT_FOUND.</para>
	/// <para>
	/// Keys do not automatically have an unnamed or default value. Unnamed values can be of any type. For more information, see Registry
	/// Element Size Limits.
	/// </para>
	/// </param>
	/// <returns>The value's data, if present.</returns>
	/// <exception cref="System.ComponentModel.Win32Exception">
	/// <para>If the function fails, the return value is a system error code.</para>
	/// <para>If the <c>lpData</c> buffer is too small to receive the data, the function returns ERROR_MORE_DATA.</para>
	/// <para>If the <c>lpValueName</c> registry value does not exist, the function returns ERROR_FILE_NOT_FOUND.</para>
	/// </exception>
	/// <remarks>
	/// <para>
	/// An application typically calls RegEnumValue to determine the value names and then <c>RegQueryValueEx</c> to retrieve the data for the names.
	/// </para>
	/// <para>
	/// When calling the <c>RegQueryValueEx</c> function with <c>hKey</c> set to the <c>HKEY_PERFORMANCE_DATA</c> handle and a value string
	/// of a specified object, the returned data structure sometimes has unrequested objects. Do not be surprised; this is normal behavior.
	/// When calling the <c>RegQueryValueEx</c> function, you should always expect to walk the returned data structure to look for the
	/// requested object.
	/// </para>
	/// <para>
	/// Note that operations that access certain registry keys are redirected. For more information, see Registry Virtualization and 32-bit
	/// and 64-bit Application Data in the Registry.
	/// </para>
	/// </remarks>
	[PInvokeData("winreg.h", MSDNShortId = "NF:winreg.RegQueryValueExA")]
	public static object? RegQueryValueEx(HKEY hKey, string? lpValueName)
	{
		uint sz = 8;
		using SafeCoTaskMemHandle mem = new(sz);
		Win32Error err = RegQueryValueEx(hKey, lpValueName, default, out var type, mem, ref sz);
		if (err == Win32Error.ERROR_MORE_DATA)
		{
			mem.Size = sz;
			err = RegQueryValueEx(hKey, lpValueName, default, out type, mem, ref sz);
		}
		err.ThrowIfFailed();
		return type.GetValue(mem, sz);
	}

	/// <summary>Changes the name of the specified registry key.</summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to the key to be renamed. The handle must be opened with the KEY_WRITE access right. For more information, see <c>Registry
	/// Key Security and Access Rights</c>.
	/// </para>
	/// <para>
	/// This handle is returned by the <c>RegCreateKeyEx</c> or <c>RegOpenKeyEx</c> function, or it can be one of the following <c>Predefined Keys</c>:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>HKEY_CLASSES_ROOT</description>
	/// </item>
	/// <item>
	/// <description>HKEY_CURRENT_CONFIG</description>
	/// </item>
	/// <item>
	/// <description>HKEY_CURRENT_USER</description>
	/// </item>
	/// <item>
	/// <description>HKEY_LOCAL_MACHINE</description>
	/// </item>
	/// <item>
	/// <description>HKEY_USERS</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpSubKeyName">
	/// The name of the subkey to be renamed. This key must be a subkey of the key identified by the hKey parameter. This parameter can also
	/// be <b>NULL</b>, in which case the key identified by the hKey parameter will be renamed.
	/// </param>
	/// <param name="lpNewKeyName">The new name of the key. The new name must not already exist.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the <c>FormatMessage</c> function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error. An error code of STATUS_ACCESS_DENIED indicates
	/// that the caller does not have the necessary access rights to the specified registry key or subkeys.
	/// </para>
	/// </returns>
	/// <remarks>
	/// This function can be used to rename an entire registry subtree. The caller must have KEY_CREATE_SUB_KEY access to the parent of the
	/// specified key and DELETE access to the entire subtree being renamed.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regrenamekey
	// LSTATUS RegRenameKey( HKEY hKey, LPCWSTR lpSubKeyName, LPCWSTR lpNewKeyName );
	[PInvokeData("winreg.h", MSDNShortId = "NF:winreg.RegRenameKey")]
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error RegRenameKey(HKEY hKey, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? lpSubKeyName,
		[MarshalAs(UnmanagedType.LPWStr)] string lpNewKeyName);

	/// <summary>
	/// <para>
	/// Replaces the file backing a registry key and all its subkeys with another file, so that when the system is next started, the key
	/// and subkeys will have the values stored in the new file.
	/// </para>
	/// <para>
	/// Applications that back up or restore system state including system files and registry hives should use the Volume Shadow Copy
	/// Service instead of the registry functions.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function, or it can be one of the
	/// following predefined keys:
	/// </para>
	/// <para><c>HKEY_CLASSES_ROOT</c><c>HKEY_CURRENT_CONFIG</c><c>HKEY_CURRENT_USER</c><c>HKEY_LOCAL_MACHINE</c><c>HKEY_USERS</c></para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>
	/// The name of the registry key whose subkeys and values are to be replaced. If the key exists, it must be a subkey of the key
	/// identified by the hKey parameter. If the subkey does not exist, it is created. This parameter can be <c>NULL</c>.
	/// </para>
	/// <para>
	/// If the specified subkey is not the root of a hive, <c>RegReplaceKey</c> traverses up the hive tree structure until it encounters
	/// a hive root, then it replaces the contents of that hive with the contents of the data file specified by lpNewFile.
	/// </para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// </param>
	/// <param name="lpNewFile">
	/// <para>The name of the file with the registry information. This file is typically created by using the RegSaveKey function.</para>
	/// </param>
	/// <param name="lpOldFile">
	/// <para>The name of the file that receives a backup copy of the registry information being replaced.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// There are two different registry hive file formats. Registry hives created on current operating systems typically cannot be
	/// loaded by earlier ones.
	/// </para>
	/// <para>The file specified by the lpNewFile parameter remains open until the system is restarted.</para>
	/// <para>
	/// If hKey is a handle returned by RegConnectRegistry, then the paths specified in lpNewFile and lpOldFile are relative to the
	/// remote computer.
	/// </para>
	/// <para>
	/// The calling process must have the SE_RESTORE_NAME and SE_BACKUP_NAME privileges on the computer in which the registry resides.
	/// For more information, see Running with Special Privileges.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regreplacekeya LSTATUS RegReplaceKeyA( HKEY hKey, LPCSTR
	// lpSubKey, LPCSTR lpNewFile, LPCSTR lpOldFile );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "f968fa71-edc8-4f49-b9fa-1e89224df33b")]
	public static extern Win32Error RegReplaceKey(HKEY hKey, [Optional] string? lpSubKey, string lpNewFile, string lpOldFile);

	/// <summary>
	/// <para>
	/// Reads the registry information in a specified file and copies it over the specified key. This registry information may be in the
	/// form of a key and multiple levels of subkeys.
	/// </para>
	/// <para>
	/// Applications that back up or restore system state including system files and registry hives should use the Volume Shadow Copy
	/// Service instead of the registry functions.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function. It can also be one of
	/// the following predefined keys:
	/// </para>
	/// <para>
	/// <c>HKEY_CLASSES_ROOT</c><c>HKEY_CURRENT_CONFIG</c><c>HKEY_CURRENT_USER</c><c>HKEY_LOCAL_MACHINE</c><c>HKEY_USERS</c> Any
	/// information contained in this key and its descendent keys is overwritten by the information in the file pointed to by the lpFile parameter.
	/// </para>
	/// </param>
	/// <param name="lpFile">
	/// <para>The name of the file with the registry information. This file is typically created by using the RegSaveKey function.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>The flags that indicate how the key or keys are to be restored. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>REG_FORCE_RESTORE 0x00000008L</term>
	/// <term>
	/// If specified, the restore operation is executed even if open handles exist at or beneath the location in the registry hierarchy
	/// to which the hKey parameter points.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REG_WHOLE_HIVE_VOLATILE 0x00000001L</term>
	/// <term>
	/// If specified, a new, volatile (memory only) set of registry information, or hive, is created. If REG_WHOLE_HIVE_VOLATILE is
	/// specified, the key identified by the hKey parameter must be either the HKEY_USERS or HKEY_LOCAL_MACHINE value.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// There are two different registry hive file formats. Registry hives created on current operating systems typically cannot be
	/// loaded by earlier ones.
	/// </para>
	/// <para>If any subkeys of the hKey parameter are open, <c>RegRestoreKey</c> fails.</para>
	/// <para>
	/// The calling process must have the SE_RESTORE_NAME and SE_BACKUP_NAME privileges on the computer in which the registry resides.
	/// For more information, see Running with Special Privileges.
	/// </para>
	/// <para>
	/// This function replaces the keys and values below the specified key with the keys and values that are subsidiary to the top-level
	/// key in the file, no matter what the name of the top-level key in the file might be. For example, hKey might identify a key A with
	/// subkeys B and C, while the lpFile parameter specifies a file containing key X with subkeys Y and Z. After a call to
	/// <c>RegRestoreKey</c>, the registry would contain key A with subkeys Y and Z. The value entries of A would be replaced by the
	/// value entries of X.
	/// </para>
	/// <para>
	/// The new information in the file specified by lpFile overwrites the contents of the key specified by the hKey parameter, except
	/// for the key name.
	/// </para>
	/// <para>If hKey represents a key in a remote computer, the path described by lpFile is relative to the remote computer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regrestorekeya LSTATUS RegRestoreKeyA( HKEY hKey, LPCSTR
	// lpFile, DWORD dwFlags );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "6267383d-427a-4ae8-b9cc-9c1861d3b7bb")]
	public static extern Win32Error RegRestoreKey(HKEY hKey, string lpFile, REG_HIVE dwFlags);

	/// <summary>
	/// <para>Saves the specified key and all of its subkeys and values to a new file, in the standard format.</para>
	/// <para>To specify the format for the saved key or hive, use the RegSaveKeyEx function.</para>
	/// <para>
	/// Applications that back up or restore system state including system files and registry hives should use the Volume Shadow Copy
	/// Service instead of the registry functions.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>A handle to an open registry key.</para>
	/// <para>This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function, or it can be one of the following predefined keys:</para>
	/// </param>
	/// <param name="lpFile">
	/// <para>
	/// The name of the file in which the specified key and subkeys are to be saved. If the file already exists, the function fails.
	/// </para>
	/// <para>
	/// If the string does not include a path, the file is created in the current directory of the calling process for a local key, or in
	/// the %systemroot%\system32 directory for a remote key. The new file has the archive attribute.
	/// </para>
	/// </param>
	/// <param name="lpSecurityAttributes">
	/// <para>
	/// A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new file. If lpSecurityAttributes is
	/// <c>NULL</c>, the file gets a default security descriptor. The ACLs in a default security descriptor for a file are inherited from
	/// its parent directory.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// <para>If the file already exists, the function fails with the ERROR_ALREADY_EXISTS error.</para>
	/// </returns>
	/// <remarks>
	/// <para>If hKey represents a key on a remote computer, the path described by lpFile is relative to the remote computer.</para>
	/// <para>
	/// The <c>RegSaveKey</c> function saves only nonvolatile keys. It does not save volatile keys. A key is made volatile or nonvolatile
	/// at its creation; see RegCreateKeyEx.
	/// </para>
	/// <para>
	/// You can use the file created by <c>RegSaveKey</c> in subsequent calls to the RegLoadKey, RegReplaceKey, or RegRestoreKey
	/// functions. If <c>RegSaveKey</c> fails part way through its operation, the file will be corrupt and subsequent calls to
	/// <c>RegLoadKey</c>, <c>RegReplaceKey</c>, or <c>RegRestoreKey</c> for the file will fail.
	/// </para>
	/// <para>
	/// Using <c>RegSaveKey</c> together with RegRestoreKey to copy subtrees in the registry is not recommended. This method does not
	/// trigger notifications and can invalidate handles used by other applications. Instead, use the SHCopyKey function or the
	/// RegCopyTree function.
	/// </para>
	/// <para>The calling process must have the SE_BACKUP_NAME privilege enabled. For more information, see Running with Special Privileges.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regsavekeya LSTATUS RegSaveKeyA( HKEY hKey, LPCSTR lpFile,
	// CONST LPSECURITY_ATTRIBUTES lpSecurityAttributes );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "da80f40d-0099-4748-94ca-5d3b001e633e")]
	public static extern Win32Error RegSaveKey(HKEY hKey, string lpFile, [Optional] SECURITY_ATTRIBUTES? lpSecurityAttributes);

	/// <summary>
	/// <para>Saves the specified key and all of its subkeys and values to a registry file, in the specified format.</para>
	/// <para>
	/// Applications that back up or restore system state including system files and registry hives should use the Volume Shadow Copy
	/// Service instead of the registry functions.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>A handle to an open registry key.</para>
	/// <para>This function does not support the <c>HKEY_CLASSES_ROOT</c> predefined key.</para>
	/// </param>
	/// <param name="lpFile">
	/// <para>
	/// The name of the file in which the specified key and subkeys are to be saved. If the file already exists, the function fails.
	/// </para>
	/// <para>The new file has the archive attribute.</para>
	/// <para>
	/// If the string does not include a path, the file is created in the current directory of the calling process for a local key, or in
	/// the %systemroot%\system32 directory for a remote key.
	/// </para>
	/// </param>
	/// <param name="lpSecurityAttributes">
	/// <para>
	/// A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new file. If lpSecurityAttributes is
	/// <c>NULL</c>, the file gets a default security descriptor. The ACLs in a default security descriptor for a file are inherited from
	/// its parent directory.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>The format of the saved key or hive. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>REG_STANDARD_FORMAT 1</term>
	/// <term>The key or hive is saved in standard format. The standard format is the only format supported by Windows 2000.</term>
	/// </item>
	/// <item>
	/// <term>REG_LATEST_FORMAT 2</term>
	/// <term>
	/// The key or hive is saved in the latest format. The latest format is supported starting with Windows XP. After the key or hive is
	/// saved in this format, it cannot be loaded on an earlier system.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REG_NO_COMPRESSION 4</term>
	/// <term>
	/// The hive is saved with no compression, for faster save operations. The hKey parameter must specify the root of a hive under
	/// HKEY_LOCAL_MACHINE or HKEY_USERS. For example, HKLM\SOFTWARE is the root of a hive.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// <para>
	/// If more than one of the possible values listed above for the Flags parameter is specified in one call to this function—for
	/// example, if two or more values are OR'ed— or if REG_NO_COMPRESSION is specified and hKey specifies a key that is not the root of
	/// a hive, this function returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Unlike RegSaveKey, this function does not support the <c>HKEY_CLASSES_ROOT</c> predefined key.</para>
	/// <para>If hKey represents a key on a remote computer, the path described by lpFile is relative to the remote computer.</para>
	/// <para>
	/// The <c>RegSaveKeyEx</c> function saves only nonvolatile keys. It does not save volatile keys. A key is made volatile or
	/// nonvolatile at its creation; see <c>RegCreateKeyEx</c>.
	/// </para>
	/// <para>
	/// You can use the file created by <c>RegSaveKeyEx</c> in subsequent calls to the RegLoadKey, RegReplaceKey, or RegRestoreKey
	/// function. If <c>RegSaveKeyEx</c> fails partway through its operation, the file will be corrupt and subsequent calls to
	/// <c>RegLoadKey</c>, <c>RegReplaceKey</c>, or <c>RegRestoreKey</c> for the file will fail.
	/// </para>
	/// <para>
	/// Using <c>RegSaveKeyEx</c> together with RegRestoreKey to copy subtrees in the registry is not recommended. This method does not
	/// trigger notifications and can invalidate handles used by other applications. Instead, use the SHCopyKey function or the
	/// RegCopyTree function.
	/// </para>
	/// <para>The calling process must have the SE_BACKUP_NAME privilege enabled. For more information, see Running with Special Privileges.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regsavekeyexa LSTATUS RegSaveKeyExA( HKEY hKey, LPCSTR
	// lpFile, CONST LPSECURITY_ATTRIBUTES lpSecurityAttributes, DWORD Flags );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "f93b4162-cac4-42f7-bfd4-9e23fff80a03")]
	public static extern Win32Error RegSaveKeyEx(HKEY hKey, string lpFile, [Optional] SECURITY_ATTRIBUTES? lpSecurityAttributes, REG_SAVE Flags);

	/// <summary>
	/// <para>The <c>RegSetKeySecurity</c> function sets the security of an open registry key.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>A handle to an open key for which the security descriptor is set.</para>
	/// </param>
	/// <param name="SecurityInformation">
	/// <para>
	/// A set of bit flags that indicate the type of security information to set. This parameter can be a combination of the
	/// SECURITY_INFORMATION bit flags.
	/// </para>
	/// </param>
	/// <param name="pSecurityDescriptor">
	/// <para>A pointer to a SECURITY_DESCRIPTOR structure that specifies the security attributes to set for the specified key.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, it returns a nonzero error code defined in WinError.h. You can use the FormatMessage function with the
	/// FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If hKey is one of the predefined keys, use the RegCloseKey function to close the predefined key to ensure that the new security
	/// information is in effect the next time the predefined key is referenced.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regsetkeysecurity LSTATUS RegSetKeySecurity( HKEY hKey,
	// SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winreg.h", MSDNShortId = "08bf8fc1-6a08-490e-b589-730211774257")]
	public static extern Win32Error RegSetKeySecurity(HKEY hKey, SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor);

	/// <summary>Sets the data for the specified value in the specified registry key and subkey.</summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_SET_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or RegOpenKeyTransacted function. It can
	/// also be one of the following predefined keys:
	/// </para>
	/// <para><c></c><c>HKEY_CLASSES_ROOT</c><c>HKEY_CURRENT_CONFIG</c><c>HKEY_CURRENT_USER</c><c>HKEY_LOCAL_MACHINE</c><c>HKEY_USERS</c></para>
	/// </param>
	/// <param name="lpSubKey">
	/// The name of a key and a subkey to the key identified by hKey. If this parameter is <c>NULL</c>, then this value is created in the
	/// key using the hKey value and the key gets a default security descriptor.
	/// </param>
	/// <param name="lpValueName">The name of the registry value whose data is to be updated.</param>
	/// <param name="dwType">
	/// The type of data pointed to by the lpData parameter. For a list of the possible types, see Registry Value Types.
	/// </param>
	/// <param name="lpData">
	/// <para>The data to be stored with the specified value name.</para>
	/// <para>
	/// For string-based types, such as REG_SZ, the string must be null-terminated. With the REG_MULTI_SZ data type, the string must be
	/// terminated with two null characters.
	/// </para>
	/// </param>
	/// <param name="cbData">
	/// The size of the information pointed to by the lpData parameter, in bytes. If the data is of type REG_SZ, REG_EXPAND_SZ, or
	/// REG_MULTI_SZ, cbData must include the size of the terminating null character or characters.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later. For more information, see Using the
	/// Windows Headers.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regsetkeyvaluea LSTATUS RegSetKeyValueA( HKEY hKey, LPCSTR
	// lpSubKey, LPCSTR lpValueName, DWORD dwType, LPCVOID lpData, DWORD cbData );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "e27d2dd6-b139-4ac1-8dd8-527022333364")]
	public static extern Win32Error RegSetKeyValue(HKEY hKey, [Optional] string? lpSubKey, string lpValueName, REG_VALUE_TYPE dwType, IntPtr lpData, uint cbData);

	/// <summary>Sets the data for the specified value in the specified registry key and subkey.</summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_SET_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or RegOpenKeyTransacted function. It can
	/// also be one of the following predefined keys:
	/// </para>
	/// <para><c></c><c>HKEY_CLASSES_ROOT</c><c>HKEY_CURRENT_CONFIG</c><c>HKEY_CURRENT_USER</c><c>HKEY_LOCAL_MACHINE</c><c>HKEY_USERS</c></para>
	/// </param>
	/// <param name="lpSubKey">
	/// The name of a key and a subkey to the key identified by hKey. If this parameter is <c>NULL</c>, then this value is created in the
	/// key using the hKey value and the key gets a default security descriptor.
	/// </param>
	/// <param name="lpValueName">The name of the registry value whose data is to be updated.</param>
	/// <param name="dwType">
	/// The type of data pointed to by the lpData parameter. For a list of the possible types, see Registry Value Types.
	/// </param>
	/// <param name="lpData">
	/// <para>The data to be stored with the specified value name.</para>
	/// <para>
	/// For string-based types, such as REG_SZ, the string must be null-terminated. With the REG_MULTI_SZ data type, the string must be
	/// terminated with two null characters.
	/// </para>
	/// </param>
	/// <param name="cbData">
	/// The size of the information pointed to by the lpData parameter, in bytes. If the data is of type REG_SZ, REG_EXPAND_SZ, or
	/// REG_MULTI_SZ, cbData must include the size of the terminating null character or characters.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later. For more information, see Using the
	/// Windows Headers.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regsetkeyvaluea LSTATUS RegSetKeyValueA( HKEY hKey, LPCSTR
	// lpSubKey, LPCSTR lpValueName, DWORD dwType, LPCVOID lpData, DWORD cbData );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "e27d2dd6-b139-4ac1-8dd8-527022333364")]
	public static extern Win32Error RegSetKeyValue(HKEY hKey, [Optional] string? lpSubKey, string lpValueName, REG_VALUE_TYPE dwType, string lpData, uint cbData);

	/// <summary>Sets the data for the specified value in the specified registry key and subkey.</summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_SET_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, or RegOpenKeyTransacted function. It can
	/// also be one of the following predefined keys:
	/// </para>
	/// <para><c></c><c>HKEY_CLASSES_ROOT</c><c>HKEY_CURRENT_CONFIG</c><c>HKEY_CURRENT_USER</c><c>HKEY_LOCAL_MACHINE</c><c>HKEY_USERS</c></para>
	/// </param>
	/// <param name="lpSubKey">
	/// The name of a key and a subkey to the key identified by hKey. If this parameter is <c>NULL</c>, then this value is created in the
	/// key using the hKey value and the key gets a default security descriptor.
	/// </param>
	/// <param name="lpValueName">The name of the registry value whose data is to be updated.</param>
	/// <param name="dwType">
	/// The type of data pointed to by the lpData parameter. For a list of the possible types, see Registry Value Types.
	/// </param>
	/// <param name="lpData">
	/// <para>The data to be stored with the specified value name.</para>
	/// <para>
	/// For string-based types, such as REG_SZ, the string must be null-terminated. With the REG_MULTI_SZ data type, the string must be
	/// terminated with two null characters.
	/// </para>
	/// </param>
	/// <param name="cbData">
	/// The size of the information pointed to by the lpData parameter, in bytes. If the data is of type REG_SZ, REG_EXPAND_SZ, or
	/// REG_MULTI_SZ, cbData must include the size of the terminating null character or characters.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later. For more information, see Using the
	/// Windows Headers.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regsetkeyvaluea LSTATUS RegSetKeyValueA( HKEY hKey, LPCSTR
	// lpSubKey, LPCSTR lpValueName, DWORD dwType, LPCVOID lpData, DWORD cbData );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "e27d2dd6-b139-4ac1-8dd8-527022333364")]
	public static extern Win32Error RegSetKeyValue(HKEY hKey, [Optional] string? lpSubKey, string lpValueName, REG_VALUE_TYPE dwType, byte[] lpData, uint cbData);

	/// <summary>
	/// <para>Sets the data for the default or unnamed value of a specified registry key. The data must be a text string.</para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the
	/// RegSetValueEx function.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_SET_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>,</para>
	/// <para>RegCreateKeyTransacted</para>
	/// <para>,</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>, or</para>
	/// <para>RegOpenKeyTransacted</para>
	/// <para>function. It can also be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>
	/// The name of a subkey of the hKey parameter. The function sets the default value of the specified subkey. If lpSubKey does not
	/// exist, the function creates it.
	/// </para>
	/// <para>Key names are not case sensitive.</para>
	/// <para>
	/// If this parameter is <c>NULL</c> or points to an empty string, the function sets the default value of the key identified by hKey.
	/// </para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// </param>
	/// <param name="dwType">
	/// The type of information to be stored. This parameter must be the REG_SZ type. To store other data types, use the RegSetValueEx function.
	/// </param>
	/// <param name="lpData">The data to be stored. This parameter cannot be <c>NULL</c>.</param>
	/// <param name="cbData">
	/// This parameter is ignored. The function calculates this value based on the size of the data in the lpData parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>If the key specified by the lpSubKey parameter does not exist, the <c>RegSetValue</c> function creates it.</para>
	/// <para>
	/// If the ANSI version of this function is used (either by explicitly calling <c>RegSetValueA</c> or by not defining UNICODE before
	/// including the Windows.h file), the lpData parameter must be an ANSI character string. The string is converted to Unicode before
	/// it is stored in the registry.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regsetvaluea LSTATUS RegSetValueA( HKEY hKey, LPCSTR
	// lpSubKey, DWORD dwType, LPCSTR lpData, DWORD cbData );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "f99774d4-575b-43a3-8887-e15acb0477fd")]
	public static extern Win32Error RegSetValue(HKEY hKey, [Optional] string? lpSubKey, REG_VALUE_TYPE dwType, string lpData, uint cbData = 0);

	/// <summary>Sets the data and type of a specified value under a registry key.</summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_SET_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>,</para>
	/// <para>RegCreateKeyTransacted</para>
	/// <para>,</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>, or</para>
	/// <para>RegOpenKeyTransacted</para>
	/// <para>function. It can also be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// <para>The Unicode version of this function supports the following additional predefined keys:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>HKEY_PERFORMANCE_TEXT</c></term>
	/// </item>
	/// <item>
	/// <term><c>HKEY_PERFORMANCE_NLSTEXT</c></term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpValueName">
	/// <para>
	/// The name of the value to be set. If a value with this name is not already present in the key, the function adds it to the key.
	/// </para>
	/// <para>
	/// If lpValueName is <c>NULL</c> or an empty string, "", the function sets the type and data for the key's unnamed or default value.
	/// </para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// <para>Registry keys do not have default values, but they can have one unnamed value, which can be of any type.</para>
	/// </param>
	/// <param name="Reserved">This parameter is reserved and must be zero.</param>
	/// <param name="dwType">
	/// The type of data pointed to by the lpData parameter. For a list of the possible types, see Registry Value Types.
	/// </param>
	/// <param name="lpData">
	/// <para>The data to be stored.</para>
	/// <para>
	/// For string-based types, such as REG_SZ, the string must be <c>null</c>-terminated. With the REG_MULTI_SZ data type, the string
	/// must be terminated with two <c>null</c> characters.
	/// </para>
	/// <para><c>Note</c> lpData indicating a <c>null</c> value is valid, however, if this is the case, cbData must be set to '0'.</para>
	/// </param>
	/// <param name="cbData">
	/// The size of the information pointed to by the lpData parameter, in bytes. If the data is of type REG_SZ, REG_EXPAND_SZ, or
	/// REG_MULTI_SZ, cbData must include the size of the terminating <c>null</c> character or characters.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Value sizes are limited by available memory. However, storing large values in the registry can affect its performance. Long
	/// values (more than 2,048 bytes) should be stored as files, with the locations of the files stored in the registry.
	/// </para>
	/// <para>Application elements such as icons, bitmaps, and executable files should be stored as files and not be placed in the registry.</para>
	/// <para>
	/// If dwType is the REG_SZ, REG_MULTI_SZ, or REG_EXPAND_SZ type and the ANSI version of this function is used (either by explicitly
	/// calling <c>RegSetValueExA</c> or by not defining UNICODE before including the Windows.h file), the data pointed to by the lpData
	/// parameter must be an ANSI character string. The string is converted to Unicode before it is stored in the registry.
	/// </para>
	/// <para>
	/// Note that operations that access certain registry keys are redirected. For more information, see Registry Virtualization and
	/// 32-bit and 64-bit Application Data in the Registry.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regsetvalueexa LSTATUS RegSetValueExA( HKEY hKey, LPCSTR
	// lpValueName, DWORD Reserved, DWORD dwType, CONST BYTE *lpData, DWORD cbData );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "29b0e27c-4999-4e92-bd8b-bba74920bccc")]
	public static extern Win32Error RegSetValueEx(HKEY hKey, [Optional] string? lpValueName, [Optional] uint Reserved, REG_VALUE_TYPE dwType, IntPtr lpData = default, uint cbData = 0U);

	/// <summary>Sets the data and type of a specified value under a registry key.</summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_SET_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>,</para>
	/// <para>RegCreateKeyTransacted</para>
	/// <para>,</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>, or</para>
	/// <para>RegOpenKeyTransacted</para>
	/// <para>function. It can also be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// <para>The Unicode version of this function supports the following additional predefined keys:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>HKEY_PERFORMANCE_TEXT</c></term>
	/// </item>
	/// <item>
	/// <term><c>HKEY_PERFORMANCE_NLSTEXT</c></term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpValueName">
	/// <para>
	/// The name of the value to be set. If a value with this name is not already present in the key, the function adds it to the key.
	/// </para>
	/// <para>
	/// If lpValueName is <c>NULL</c> or an empty string, "", the function sets the type and data for the key's unnamed or default value.
	/// </para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// <para>Registry keys do not have default values, but they can have one unnamed value, which can be of any type.</para>
	/// </param>
	/// <param name="Reserved">This parameter is reserved and must be zero.</param>
	/// <param name="dwType">
	/// The type of data pointed to by the lpData parameter. For a list of the possible types, see Registry Value Types.
	/// </param>
	/// <param name="lpData">
	/// <para>The data to be stored.</para>
	/// <para>
	/// For string-based types, such as REG_SZ, the string must be <c>null</c>-terminated. With the REG_MULTI_SZ data type, the string
	/// must be terminated with two <c>null</c> characters.
	/// </para>
	/// <para><c>Note</c> lpData indicating a <c>null</c> value is valid, however, if this is the case, cbData must be set to '0'.</para>
	/// </param>
	/// <param name="cbData">
	/// The size of the information pointed to by the lpData parameter, in bytes. If the data is of type REG_SZ, REG_EXPAND_SZ, or
	/// REG_MULTI_SZ, cbData must include the size of the terminating <c>null</c> character or characters.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Value sizes are limited by available memory. However, storing large values in the registry can affect its performance. Long
	/// values (more than 2,048 bytes) should be stored as files, with the locations of the files stored in the registry.
	/// </para>
	/// <para>Application elements such as icons, bitmaps, and executable files should be stored as files and not be placed in the registry.</para>
	/// <para>
	/// If dwType is the REG_SZ, REG_MULTI_SZ, or REG_EXPAND_SZ type and the ANSI version of this function is used (either by explicitly
	/// calling <c>RegSetValueExA</c> or by not defining UNICODE before including the Windows.h file), the data pointed to by the lpData
	/// parameter must be an ANSI character string. The string is converted to Unicode before it is stored in the registry.
	/// </para>
	/// <para>
	/// Note that operations that access certain registry keys are redirected. For more information, see Registry Virtualization and
	/// 32-bit and 64-bit Application Data in the Registry.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regsetvalueexa LSTATUS RegSetValueExA( HKEY hKey, LPCSTR
	// lpValueName, DWORD Reserved, DWORD dwType, CONST BYTE *lpData, DWORD cbData );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "29b0e27c-4999-4e92-bd8b-bba74920bccc")]
	public static extern Win32Error RegSetValueEx(HKEY hKey, [Optional] string? lpValueName, [Optional] uint Reserved, REG_VALUE_TYPE dwType, byte[] lpData, uint cbData);

	/// <summary>Sets the data and type of a specified value under a registry key.</summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to an open registry key. The key must have been opened with the KEY_SET_VALUE access right. For more information, see
	/// Registry Key Security and Access Rights.
	/// </para>
	/// <para>This handle is returned by the</para>
	/// <para>RegCreateKeyEx</para>
	/// <para>,</para>
	/// <para>RegCreateKeyTransacted</para>
	/// <para>,</para>
	/// <para>RegOpenKeyEx</para>
	/// <para>, or</para>
	/// <para>RegOpenKeyTransacted</para>
	/// <para>function. It can also be one of the following</para>
	/// <para>predefined keys</para>
	/// <para>:</para>
	/// <para>The Unicode version of this function supports the following additional predefined keys:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>HKEY_PERFORMANCE_TEXT</c></term>
	/// </item>
	/// <item>
	/// <term><c>HKEY_PERFORMANCE_NLSTEXT</c></term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpValueName">
	/// <para>
	/// The name of the value to be set. If a value with this name is not already present in the key, the function adds it to the key.
	/// </para>
	/// <para>
	/// If lpValueName is <c>NULL</c> or an empty string, "", the function sets the type and data for the key's unnamed or default value.
	/// </para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// <para>Registry keys do not have default values, but they can have one unnamed value, which can be of any type.</para>
	/// </param>
	/// <param name="Reserved">This parameter is reserved and must be zero.</param>
	/// <param name="dwType">
	/// The type of data pointed to by the lpData parameter. For a list of the possible types, see Registry Value Types.
	/// </param>
	/// <param name="lpData">
	/// <para>The data to be stored.</para>
	/// <para>
	/// For string-based types, such as REG_SZ, the string must be <c>null</c>-terminated. With the REG_MULTI_SZ data type, the string
	/// must be terminated with two <c>null</c> characters.
	/// </para>
	/// <para><c>Note</c> lpData indicating a <c>null</c> value is valid, however, if this is the case, cbData must be set to '0'.</para>
	/// </param>
	/// <param name="cbData">
	/// The size of the information pointed to by the lpData parameter, in bytes. If the data is of type REG_SZ, REG_EXPAND_SZ, or
	/// REG_MULTI_SZ, cbData must include the size of the terminating <c>null</c> character or characters.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Value sizes are limited by available memory. However, storing large values in the registry can affect its performance. Long
	/// values (more than 2,048 bytes) should be stored as files, with the locations of the files stored in the registry.
	/// </para>
	/// <para>Application elements such as icons, bitmaps, and executable files should be stored as files and not be placed in the registry.</para>
	/// <para>
	/// If dwType is the REG_SZ, REG_MULTI_SZ, or REG_EXPAND_SZ type and the ANSI version of this function is used (either by explicitly
	/// calling <c>RegSetValueExA</c> or by not defining UNICODE before including the Windows.h file), the data pointed to by the lpData
	/// parameter must be an ANSI character string. The string is converted to Unicode before it is stored in the registry.
	/// </para>
	/// <para>
	/// Note that operations that access certain registry keys are redirected. For more information, see Registry Virtualization and
	/// 32-bit and 64-bit Application Data in the Registry.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regsetvalueexa LSTATUS RegSetValueExA( HKEY hKey, LPCSTR
	// lpValueName, DWORD Reserved, DWORD dwType, CONST BYTE *lpData, DWORD cbData );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "29b0e27c-4999-4e92-bd8b-bba74920bccc")]
	public static extern Win32Error RegSetValueEx(HKEY hKey, [Optional] string? lpValueName, [Optional] uint Reserved, REG_VALUE_TYPE dwType, string lpData, uint cbData);

	/// <summary>
	/// <para>Unloads the specified registry key and its subkeys from the registry.</para>
	/// <para>
	/// Applications that back up or restore system state including system files and registry hives should use the Volume Shadow Copy
	/// Service instead of the registry functions.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to the registry key to be unloaded. This parameter can be a handle returned by a call to RegConnectRegistry function or
	/// one of the following predefined handles:
	/// </para>
	/// <para><c>HKEY_LOCAL_MACHINE</c><c>HKEY_USERS</c></para>
	/// </param>
	/// <param name="lpSubKey">
	/// <para>
	/// The name of the subkey to be unloaded. The key referred to by the lpSubKey parameter must have been created by using the
	/// RegLoadKey function.
	/// </para>
	/// <para>Key names are not case sensitive.</para>
	/// <para>For more information, see Registry Element Size Limits.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>
	/// If the function fails, the return value is a nonzero error code defined in Winerror.h. You can use the FormatMessage function
	/// with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function removes a hive from the registry but does not modify the file containing the registry information. A hive is a
	/// discrete body of keys, subkeys, and values that is rooted at the top of the registry hierarchy.
	/// </para>
	/// <para>
	/// The calling process must have the SE_RESTORE_NAME and SE_BACKUP_NAME privileges on the computer in which the registry resides.
	/// For more information, see Running with Special Privileges.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/nf-winreg-regunloadkeya LSTATUS RegUnLoadKeyA( HKEY hKey, LPCSTR
	// lpSubKey );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winreg.h", MSDNShortId = "73b4b6a9-4acb-4247-bd7f-82024ba3e14a")]
	public static extern Win32Error RegUnLoadKey(HKEY hKey, string lpSubKey);

	/// <summary>Contains information about a registry value. The RegQueryMultipleValues function uses this structure.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winreg/ns-winreg-value_enta typedef struct value_entA { PSTR ve_valuename;
	// DWORD ve_valuelen; DWORD_PTR ve_valueptr; DWORD ve_type; } VALENTA, *PVALENTA;
	[PInvokeData("winreg.h", MSDNShortId = "7881eea8-e4e3-48cf-ba8f-b5c23910ae7d")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct VALENT
	{
		/// <summary>
		/// <para>The name of the value to be retrieved. Be sure to set this member before calling RegQueryMultipleValues.</para>
		/// </summary>
		public string ve_valuename;

		/// <summary>
		/// <para>The size of the data pointed to by <c>ve_valueptr</c>, in bytes.</para>
		/// </summary>
		public uint ve_valuelen;

		/// <summary>
		/// <para>
		/// A pointer to the data for the value entry. This is a pointer to the value's data returned in the <c>lpValueBuf</c> buffer
		/// filled in by RegQueryMultipleValues.
		/// </para>
		/// </summary>
		public IntPtr ve_valueptr;

		/// <summary>
		/// <para>The type of data pointed to by <c>ve_valueptr</c>. For a list of the possible types, see Registry Value Types.</para>
		/// </summary>
		public REG_VALUE_TYPE ve_type;

		/// <summary>Initializes a new instance of the <see cref="VALENT"/> struct with the name of the value to fetch.</summary>
		/// <param name="valueName">The name of the value to be retrieved.</param>
		public VALENT(string valueName) : this() => ve_valuename = valueName;
	}
}