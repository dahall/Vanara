#pragma warning disable IDE1006 // Naming Styles

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants used by Windows Restart Manager (rstrtmgr.dll)</summary>
public static class RstrtMgr
{
	/// <summary>CCH_RM_MAX_APP_NAME - maximum character count of application friendly name</summary>
	public const int CCH_RM_MAX_APP_NAME = 255;

	/// <summary>CCH_RM_MAX_SVC_NAME - maximum character count of service short name</summary>
	public const int CCH_RM_MAX_SVC_NAME = 63;

	/// <summary>CCH_RM_SESSION_KEY - character count of text-encoded session key</summary>
	public const int CCH_RM_SESSION_KEY = RM_SESSION_KEY_LEN * 2;

	/// <summary>Uninitialized value for Process ID</summary>
	public const int RM_INVALID_PROCESS = -1;

	/// <summary>Uninitialized value for TS Session ID</summary>
	public const int RM_INVALID_TS_SESSION = -1;

	/// <summary>RM_SESSION_KEY_LEN - size in bytes of binary session key</summary>
	public const int RM_SESSION_KEY_LEN = 16;

	private const string Lib_Rstrtmgr = "rstrtmgr.dll";

	/// <summary>
	/// The <c>RM_WRITE_STATUS_CALLBACK</c> function can be implemented by the user interface that controls the Restart Manager. The
	/// installer that started the Restart Manager session can pass a pointer to this function to the Restart Manager functions to
	/// receive a percentage of completeness. The percentage of completeness is strictly increasing and describes the current operation
	/// being performed and the name of the application being affected.
	/// </summary>
	/// <param name="nPercentComplete">
	/// An integer value between 0 and 100 that indicates the percentage of the total number of applications that have either been shut
	/// down or restarted.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/nc-restartmanager-rm_write_status_callback
	// RM_WRITE_STATUS_CALLBACK RmWriteStatusCallback; void RmWriteStatusCallback( UINT nPercentComplete ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("restartmanager.h", MSDNShortId = "NC:restartmanager.RM_WRITE_STATUS_CALLBACK")]
	public delegate void RM_WRITE_STATUS_CALLBACK(uint nPercentComplete);

	/// <summary>Describes the current status of an application that is acted upon by the Restart Manager.</summary>
	/// <remarks>
	/// The constants of <c>RM_APP_STATUS</c> can be combined with OR operators. The combination describes the history of actions taken
	/// by Restart Manager on the application.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/ne-restartmanager-rm_app_status typedef enum _RM_APP_STATUS {
	// RmStatusUnknown, RmStatusRunning, RmStatusStopped, RmStatusStoppedOther, RmStatusRestarted, RmStatusErrorOnStop,
	// RmStatusErrorOnRestart, RmStatusShutdownMasked, RmStatusRestartMasked } RM_APP_STATUS;
	[PInvokeData("restartmanager.h", MSDNShortId = "NE:restartmanager._RM_APP_STATUS")]
	[Flags]
	public enum RM_APP_STATUS
	{
		/// <summary>The application is in a state that is not described by any other enumerated state.</summary>
		RmStatusUnknown = 0x0,

		/// <summary>The application is currently running.</summary>
		RmStatusRunning = 0x1,

		/// <summary>The Restart Manager has stopped the application.</summary>
		RmStatusStopped = 0x2,

		/// <summary>An action outside the Restart Manager has stopped the application.</summary>
		RmStatusStoppedOther = 0x4,

		/// <summary>The Restart Manager has restarted the application.</summary>
		RmStatusRestarted = 0x8,

		/// <summary>The Restart Manager encountered an error when stopping the application.</summary>
		RmStatusErrorOnStop = 0x10,

		/// <summary>The Restart Manager encountered an error when restarting the application.</summary>
		RmStatusErrorOnRestart = 0x20,

		/// <summary>Shutdown is masked by a filter.</summary>
		RmStatusShutdownMasked = 0x40,

		/// <summary>Restart is masked by a filter.</summary>
		RmStatusRestartMasked = 0x80,
	}

	/// <summary>Specifies the type of application that is described by the RM_PROCESS_INFO structure.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/ne-restartmanager-rm_app_type typedef enum _RM_APP_TYPE {
	// RmUnknownApp, RmMainWindow, RmOtherWindow, RmService, RmExplorer, RmConsole, RmCritical } RM_APP_TYPE;
	[PInvokeData("restartmanager.h", MSDNShortId = "NE:restartmanager._RM_APP_TYPE")]
	public enum RM_APP_TYPE
	{
		/// <summary>
		/// The application cannot be classified as any other type. An application of this type can only be shut down by a forced shutdown.
		/// </summary>
		RmUnknownApp = 0,

		/// <summary>A Windows application run as a stand-alone process that displays a top-level window.</summary>
		RmMainWindow,

		/// <summary>A Windows application that does not run as a stand-alone process and does not display a top-level window.</summary>
		RmOtherWindow,

		/// <summary>The application is a Windows service.</summary>
		RmService,

		/// <summary>The application is Windows Explorer.</summary>
		RmExplorer,

		/// <summary>The application is a stand-alone console application.</summary>
		RmConsole,

		/// <summary>
		/// A system restart is required to complete the installation because a process cannot be shut down. The process cannot be shut
		/// down because of the following reasons. The process may be a critical process. The current user may not have permission to
		/// shut down the process. The process may belong to the primary installer that started the Restart Manager.
		/// </summary>
		RmCritical = 1000,
	}

	/// <summary>Specifies the type of modification that is applied to restart or shutdown actions.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/ne-restartmanager-rm_filter_action typedef enum
	// _RM_FILTER_ACTION { RmInvalidFilterAction, RmNoRestart, RmNoShutdown } RM_FILTER_ACTION;
	[PInvokeData("restartmanager.h", MSDNShortId = "NE:restartmanager._RM_FILTER_ACTION")]
	public enum RM_FILTER_ACTION
	{
		/// <summary>An invalid filter action.</summary>
		RmInvalidFilterAction = 0,

		/// <summary>Prevents the restart of the specified application or service.</summary>
		RmNoRestart,

		/// <summary>Prevents the shut down and restart of the specified application or service.</summary>
		RmNoShutdown,
	}

	/// <summary>Describes the restart or shutdown actions for an application or service.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/ne-restartmanager-rm_filter_trigger typedef enum
	// _RM_FILTER_TRIGGER { RmFilterTriggerInvalid, RmFilterTriggerFile, RmFilterTriggerProcess, RmFilterTriggerService } RM_FILTER_TRIGGER;
	[PInvokeData("restartmanager.h", MSDNShortId = "NE:restartmanager._RM_FILTER_TRIGGER")]
	public enum RM_FILTER_TRIGGER
	{
		/// <summary>An invalid filter trigger.</summary>
		RmFilterTriggerInvalid = 0,

		/// <summary>Modifies the shutdown or restart actions for an application identified by its executable filename.</summary>
		RmFilterTriggerFile,

		/// <summary>Modifies the shutdown or restart actions for an application identified by a RM_UNIQUE_PROCESS structure.</summary>
		RmFilterTriggerProcess,

		/// <summary>Modifies the shutdown or restart actions for a service identified by a service short name.</summary>
		RmFilterTriggerService,
	}

	/// <summary>Describes the reasons a restart of the system is needed.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/ne-restartmanager-rm_reboot_reason typedef enum
	// _RM_REBOOT_REASON { RmRebootReasonNone, RmRebootReasonPermissionDenied, RmRebootReasonSessionMismatch,
	// RmRebootReasonCriticalProcess, RmRebootReasonCriticalService, RmRebootReasonDetectedSelf } RM_REBOOT_REASON;
	[PInvokeData("restartmanager.h", MSDNShortId = "NE:restartmanager._RM_REBOOT_REASON")]
	[Flags]
	public enum RM_REBOOT_REASON
	{
		/// <summary>A system restart is not required.</summary>
		RmRebootReasonNone = 0x0,

		/// <summary>The current user does not have sufficient privileges to shut down one or more processes.</summary>
		RmRebootReasonPermissionDenied = 0x1,

		/// <summary>One or more processes are running in another Terminal Services session.</summary>
		RmRebootReasonSessionMismatch = 0x2,

		/// <summary>A system restart is needed because one or more processes to be shut down are critical processes.</summary>
		RmRebootReasonCriticalProcess = 0x4,

		/// <summary>A system restart is needed because one or more services to be shut down are critical services.</summary>
		RmRebootReasonCriticalService = 0x8,

		/// <summary>A system restart is needed because the current process must be shut down.</summary>
		RmRebootReasonDetectedSelf = 0x10,
	}

	/// <summary>Configures the shut down of applications.</summary>
	/// <remarks>
	/// <para>
	/// The time to wait before initiating a forced shutdown of applications is specified by the following registry key. <c>HKCU</c>\
	/// <c>Control Panel</c>\ <c>Desktop</c>\ <c>HungAppTimeout</c>
	/// </para>
	/// <para>
	/// The time to wait before initiating a forced shutdown of services is specified by the following registry key. <c>HKLM</c>\
	/// <c>System</c>\ <c>CurrentControlSet</c>\ <c>Control</c>\ <c>WaitToKillServiceTimeout</c>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/ne-restartmanager-rm_shutdown_type typedef enum
	// _RM_SHUTDOWN_TYPE { RmForceShutdown, RmShutdownOnlyRegistered } RM_SHUTDOWN_TYPE;
	[PInvokeData("restartmanager.h", MSDNShortId = "NE:restartmanager._RM_SHUTDOWN_TYPE")]
	[Flags]
	public enum RM_SHUTDOWN_TYPE
	{
		/// <summary>
		/// Forces unresponsive applications and services to shut down after the timeout period. An application that does not respond to
		/// a shutdown request by the Restart Manager is forced to shut down after 30 seconds. A service that does not respond to a
		/// shutdown request is forced to shut down after 20 seconds. These default times can be changed by modifying the registry keys
		/// described in the Remarks section.
		/// </summary>
		RmForceShutdown = 0x1,

		/// <summary>
		/// Shuts down applications if and only if all the applications have been registered for restart using the
		/// RegisterApplicationRestart function. If any processes or services cannot be restarted, then no processes or services are
		/// shut down.
		/// </summary>
		RmShutdownOnlyRegistered = 0x10,
	}

	/// <summary>
	/// Modifies the shutdown or restart actions that are applied to an application or service. The primary installer can call the
	/// <c>RmAddFilter</c> function multiple times. The most recent call overrides any previous modifications to the same file, process,
	/// or service.
	/// </summary>
	/// <param name="dwSessionHandle">A handle to an existing Restart Manager session.</param>
	/// <param name="strModuleName">
	/// A pointer to a <c>null</c>-terminated string value that contains the full path to the application's executable file.
	/// Modifications to shutdown or restart actions are applied for the application that is referenced by the full path. This parameter
	/// must be <c>NULL</c> if the Application or strServiceShortName parameter is non- <c>NULL</c>.
	/// </param>
	/// <param name="pProcess">
	/// A pointer to a RM_UNIQUE_PROCESS structure for the application. Modifications to shutdown or restart actions are applied for the
	/// application that is referenced by the <c>RM_UNIQUE_PROCESS</c> structure. This parameter must be <c>NULL</c> if the strFilename
	/// or strShortServiceName parameter is non- <c>NULL</c>.
	/// </param>
	/// <param name="strServiceShortName">
	/// A pointer to a <c>null</c>-terminated string value that contains the short service name. Modifications to shutdown or restart
	/// actions are applied for the service that is referenced by short service filename. This parameter must be <c>NULL</c> if the
	/// strFilename or Application parameter is non- <c>NULL</c>.
	/// </param>
	/// <param name="FilterAction">An RM_FILTER_ACTION enumeration value that specifies the type of modification to be applied.</param>
	/// <returns>
	/// <para>This is the most recent error received. The function can return one of the system error codes that are defined in Winerror.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_ARGUMENTS 160</term>
	/// <term>
	/// One or more arguments are not correct. This error value is returned by the Restart Manager function if a NULL pointer or 0 is
	/// passed in as a parameter that requires a non-null and non-zero value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SESSION_CREDENTIAL_CONFLICT 1219</term>
	/// <term>This error is returned when a secondary installer calls this function. This function is only available to primary installers.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/nf-restartmanager-rmaddfilter DWORD RmAddFilter( DWORD
	// dwSessionHandle, LPCWSTR strModuleName, RM_UNIQUE_PROCESS *pProcess, LPCWSTR strServiceShortName, RM_FILTER_ACTION FilterAction );
	[DllImport(Lib_Rstrtmgr, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("restartmanager.h", MSDNShortId = "NF:restartmanager.RmAddFilter")]
	public static extern Win32Error RmAddFilter(uint dwSessionHandle, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? strModuleName,
		in RM_UNIQUE_PROCESS pProcess, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? strServiceShortName, RM_FILTER_ACTION FilterAction);

	/// <summary>
	/// Modifies the shutdown or restart actions that are applied to an application or service. The primary installer can call the
	/// <c>RmAddFilter</c> function multiple times. The most recent call overrides any previous modifications to the same file, process,
	/// or service.
	/// </summary>
	/// <param name="dwSessionHandle">A handle to an existing Restart Manager session.</param>
	/// <param name="strModuleName">
	/// A pointer to a <c>null</c>-terminated string value that contains the full path to the application's executable file.
	/// Modifications to shutdown or restart actions are applied for the application that is referenced by the full path. This parameter
	/// must be <c>NULL</c> if the Application or strServiceShortName parameter is non- <c>NULL</c>.
	/// </param>
	/// <param name="pProcess">
	/// A pointer to a RM_UNIQUE_PROCESS structure for the application. Modifications to shutdown or restart actions are applied for the
	/// application that is referenced by the <c>RM_UNIQUE_PROCESS</c> structure. This parameter must be <c>NULL</c> if the strFilename
	/// or strShortServiceName parameter is non- <c>NULL</c>.
	/// </param>
	/// <param name="strServiceShortName">
	/// A pointer to a <c>null</c>-terminated string value that contains the short service name. Modifications to shutdown or restart
	/// actions are applied for the service that is referenced by short service filename. This parameter must be <c>NULL</c> if the
	/// strFilename or Application parameter is non- <c>NULL</c>.
	/// </param>
	/// <param name="FilterAction">An RM_FILTER_ACTION enumeration value that specifies the type of modification to be applied.</param>
	/// <returns>
	/// <para>This is the most recent error received. The function can return one of the system error codes that are defined in Winerror.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_ARGUMENTS 160</term>
	/// <term>
	/// One or more arguments are not correct. This error value is returned by the Restart Manager function if a NULL pointer or 0 is
	/// passed in as a parameter that requires a non-null and non-zero value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SESSION_CREDENTIAL_CONFLICT 1219</term>
	/// <term>This error is returned when a secondary installer calls this function. This function is only available to primary installers.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/nf-restartmanager-rmaddfilter DWORD RmAddFilter( DWORD
	// dwSessionHandle, LPCWSTR strModuleName, RM_UNIQUE_PROCESS *pProcess, LPCWSTR strServiceShortName, RM_FILTER_ACTION FilterAction );
	[DllImport(Lib_Rstrtmgr, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("restartmanager.h", MSDNShortId = "NF:restartmanager.RmAddFilter")]
	public static extern Win32Error RmAddFilter(uint dwSessionHandle, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? strModuleName,
		[In, Optional] IntPtr pProcess, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? strServiceShortName, RM_FILTER_ACTION FilterAction);

	/// <summary>
	/// Cancels the current RmShutdown or RmRestart operation. This function must be called from the application that has started the
	/// session by calling the RmStartSession function.
	/// </summary>
	/// <param name="dwSessionHandle">A handle to an existing session.</param>
	/// <returns>
	/// <para>This is the most recent error received. The function can return one of the system error codes that are defined in Winerror.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0</term>
	/// <term>A cancellation of the current operation is requested.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_ARGUMENTS 160</term>
	/// <term>
	/// One or more arguments are not correct. This error value is returned by the Restart Manager function if a NULL pointer or 0 is
	/// passed in a parameter that requires a non-null and non-zero value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY 14</term>
	/// <term>A Restart Manager operation could not complete because not enough memory was available.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE 6</term>
	/// <term>No Restart Manager session exists for the handle supplied.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/nf-restartmanager-rmcancelcurrenttask DWORD
	// RmCancelCurrentTask( DWORD dwSessionHandle );
	[DllImport(Lib_Rstrtmgr, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("restartmanager.h", MSDNShortId = "NF:restartmanager.RmCancelCurrentTask")]
	public static extern Win32Error RmCancelCurrentTask(uint dwSessionHandle);

	/// <summary>
	/// Ends the Restart Manager session. This function should be called by the primary installer that has previously started the
	/// session by calling the RmStartSession function. The <c>RmEndSession</c> function can be called by a secondary installer that is
	/// joined to the session once no more resources need to be registered by the secondary installer.
	/// </summary>
	/// <param name="dwSessionHandle">A handle to an existing Restart Manager session.</param>
	/// <returns>
	/// <para>This is the most recent error received. The function can return one of the system error codes that are defined in Winerror.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SEM_TIMEOUT 121</term>
	/// <term>
	/// A Restart Manager function could not obtain a Registry write mutex in the allotted time. A system restart is recommended because
	/// further use of the Restart Manager is likely to fail.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_FAULT 29</term>
	/// <term>An operation was unable to read or write to the registry.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY 14</term>
	/// <term>A Restart Manager operation could not complete because not enough memory was available.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE 6</term>
	/// <term>An invalid handle was passed to the function. No Restart Manager session exists for the handle supplied.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/nf-restartmanager-rmendsession DWORD RmEndSession( DWORD
	// dwSessionHandle );
	[DllImport(Lib_Rstrtmgr, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("restartmanager.h", MSDNShortId = "NF:restartmanager.RmEndSession")]
	public static extern Win32Error RmEndSession(uint dwSessionHandle);

	/// <summary>
	/// Lists the modifications to shutdown and restart actions that have already been applied by the RmAddFilter function. The function
	/// returns a pointer to a buffer containing information about the modifications which have been applied.
	/// </summary>
	/// <param name="dwSessionHandle">A handle to an existing Restart Manager session.</param>
	/// <param name="pbFilterBuf">A pointer to a buffer that contains modification information.</param>
	/// <param name="cbFilterBuf">The size of the buffer that contains modification information in bytes.</param>
	/// <param name="cbFilterBufNeeded">The number of bytes needed in the buffer.</param>
	/// <returns>
	/// <para>This is the most recent error received. The function can return one of the system error codes that are defined in Winerror.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_ARGUMENTS 160</term>
	/// <term>
	/// One or more arguments are not correct. This error value is returned by the Restart Manager function if a NULL pointer or 0 is
	/// passed in as a parameter that requires a non-null and non-zero value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA 234</term>
	/// <term>
	/// This error value is returned by the RmGetFilterList function if the pbFilterBuf buffer is too small to hold all the application
	/// information in the list or if cbFilterBufNeeded was not specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SESSION_CREDENTIAL_CONFLICT 1219</term>
	/// <term>This error is returned when a secondary installer calls this function. This function is only available to primary installers.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The returned pbFilterBuf buffer has to be typecast to <c>RM_FILTER_INFO</c> to access the filter list.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/nf-restartmanager-rmgetfilterlist DWORD RmGetFilterList( DWORD
	// dwSessionHandle, PBYTE pbFilterBuf, DWORD cbFilterBuf, LPDWORD cbFilterBufNeeded );
	[DllImport(Lib_Rstrtmgr, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("restartmanager.h", MSDNShortId = "NF:restartmanager.RmGetFilterList")]
	public static extern Win32Error RmGetFilterList(uint dwSessionHandle, [Out, Optional] IntPtr pbFilterBuf, uint cbFilterBuf, out uint cbFilterBufNeeded);

	/// <summary>
	/// Gets a list of all applications and services that are currently using resources that have been registered with the Restart
	/// Manager session.
	/// </summary>
	/// <param name="dwSessionHandle">A handle to an existing Restart Manager session.</param>
	/// <param name="pnProcInfoNeeded">
	/// A pointer to an array size necessary to receive RM_PROCESS_INFO structures required to return information for all affected
	/// applications and services.
	/// </param>
	/// <param name="pnProcInfo">A pointer to the total number of RM_PROCESS_INFO structures in an array and number of structures filled.</param>
	/// <param name="rgAffectedApps">
	/// An array of RM_PROCESS_INFO structures that list the applications and services using resources that have been registered with
	/// the session.
	/// </param>
	/// <param name="lpdwRebootReasons">
	/// Pointer to location that receives a value of the RM_REBOOT_REASON enumeration that describes the reason a system restart is needed.
	/// </param>
	/// <returns>
	/// <para>This is the most recent error received. The function can return one of the system error codes that are defined in Winerror.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA 234</term>
	/// <term>
	/// This error value is returned by the RmGetList function if the rgAffectedApps buffer is too small to hold all application
	/// information in the list.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_CANCELLED 1223</term>
	/// <term>The current operation is canceled by user.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SEM_TIMEOUT 121</term>
	/// <term>
	/// A Restart Manager function could not obtain a Registry write mutex in the allotted time. A system restart is recommended because
	/// further use of the Restart Manager is likely to fail.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_ARGUMENTS 160</term>
	/// <term>
	/// One or more arguments are not correct. This error value is returned by the Restart Manager function if a NULL pointer or 0 is
	/// passed in a parameter that requires a non-null and non-zero value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_FAULT 29</term>
	/// <term>An operation was unable to read or write to the registry.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY 14</term>
	/// <term>A Restart Manager operation could not complete because not enough memory was available.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE 6</term>
	/// <term>No Restart Manager session exists for the handle supplied.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/nf-restartmanager-rmgetlist DWORD RmGetList( DWORD
	// dwSessionHandle, UINT *pnProcInfoNeeded, UINT *pnProcInfo, RM_PROCESS_INFO [] rgAffectedApps, LPDWORD lpdwRebootReasons );
	[DllImport(Lib_Rstrtmgr, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("restartmanager.h", MSDNShortId = "NF:restartmanager.RmGetList")]
	public static extern Win32Error RmGetList(uint dwSessionHandle, out uint pnProcInfoNeeded, ref uint pnProcInfo,
		[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RM_PROCESS_INFO[] rgAffectedApps, out RM_REBOOT_REASON lpdwRebootReasons);

	/// <summary>
	/// Joins a secondary installer to an existing Restart Manager session. This function must be called with a session key that can
	/// only be obtained from the primary installer that started the session. A valid session key is required to use any of the Restart
	/// Manager functions. After a secondary installer joins a session, it can call the RmRegisterResources function to register resources.
	/// </summary>
	/// <param name="pSessionHandle">A pointer to the handle of an existing Restart Manager Session.</param>
	/// <param name="strSessionKey">A <c>null</c>-terminated string that contains the session key of an existing session.</param>
	/// <returns>
	/// <para>This is the most recent error received. The function can return one of the system error codes that are defined in Winerror.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SESSION_CREDENTIAL_CONFLICT 1219</term>
	/// <term>The session key cannot be validated.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SEM_TIMEOUT 121</term>
	/// <term>
	/// A Restart Manager function could not obtain a Registry write mutex in the allotted time. A system restart is recommended because
	/// further use of the Restart Manager is likely to fail.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_ARGUMENTS 22</term>
	/// <term>
	/// One or more arguments are not correct. This error value is returned by the Restart Manager function if a NULL pointer or 0 is
	/// passed in a parameter that requires a non-null and non-zero value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_FAULT 29</term>
	/// <term>An operation was unable to read or write to the registry.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MAX_SESSIONS_REACHED 353</term>
	/// <term>The maximum number of sessions has been reached.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY 14</term>
	/// <term>A Restart Manager operation could not complete because not enough memory was available.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The <c>RmJoinSession</c> function joins a secondary installer to an existing Restart Manager session. This is typically an
	/// installer that does not control the user interface and can run either in-process or out-of-process of the primary installer.
	/// Only the primary installer can call the RmStartSession function and this is typically the application that controls the user
	/// interface or that controls the installation sequence of multiple patches in an update.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/nf-restartmanager-rmjoinsession DWORD RmJoinSession( DWORD
	// *pSessionHandle, const WCHAR [] strSessionKey );
	[DllImport(Lib_Rstrtmgr, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("restartmanager.h", MSDNShortId = "NF:restartmanager.RmJoinSession")]
	public static extern Win32Error RmJoinSession(out uint pSessionHandle, [MarshalAs(UnmanagedType.LPWStr)] string strSessionKey);

	/// <summary>
	/// Registers resources to a Restart Manager session. The Restart Manager uses the list of resources registered with the session to
	/// determine which applications and services must be shut down and restarted. Resources can be identified by filenames, service
	/// short names, or RM_UNIQUE_PROCESS structures that describe running applications. The <c>RmRegisterResources</c> function can be
	/// used by a primary or secondary installer.
	/// </summary>
	/// <param name="dwSessionHandle">A handle to an existing Restart Manager session.</param>
	/// <param name="nFiles">The number of files being registered.</param>
	/// <param name="rgsFileNames">
	/// An array of <c>null</c>-terminated strings of full filename paths. This parameter can be <c>NULL</c> if nFiles is 0.
	/// </param>
	/// <param name="nApplications">The number of processes being registered.</param>
	/// <param name="rgApplications">
	/// An array of RM_UNIQUE_PROCESS structures. This parameter can be <c>NULL</c> if nApplications is 0.
	/// </param>
	/// <param name="nServices">The number of services to be registered.</param>
	/// <param name="rgsServiceNames">
	/// An array of <c>null</c>-terminated strings of service short names. This parameter can be <c>NULL</c> if nServices is 0.
	/// </param>
	/// <returns>
	/// <para>This is the most recent error received. The function can return one of the system error codes that are defined in Winerror.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0</term>
	/// <term>The resources specified have been registered.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SEM_TIMEOUT 121</term>
	/// <term>
	/// A Restart Manager function could not obtain a Registry write mutex in the allotted time. A system restart is recommended because
	/// further use of the Restart Manager is likely to fail.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_ARGUMENTS 160</term>
	/// <term>
	/// One or more arguments are not correct. This error value is returned by Restart Manager function if a NULL pointer or 0 is passed
	/// in a parameter that requires a non-null and non-zero value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_FAULT 29</term>
	/// <term>An operation was unable to read or write to the registry.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY 14</term>
	/// <term>A Restart Manager operation could not complete because not enough memory was available.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE 6</term>
	/// <term>No Restart Manager session exists for the handle supplied.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Each call to the <c>RmRegisterResources</c> function performs relatively expensive write operations. Do not call this function
	/// once per file, instead group related files together into components and register these together.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/nf-restartmanager-rmregisterresources DWORD
	// RmRegisterResources( DWORD dwSessionHandle, UINT nFiles, LPCWSTR [] rgsFileNames, UINT nApplications, RM_UNIQUE_PROCESS []
	// rgApplications, UINT nServices, LPCWSTR [] rgsServiceNames );
	[DllImport(Lib_Rstrtmgr, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("restartmanager.h", MSDNShortId = "NF:restartmanager.RmRegisterResources")]
	public static extern Win32Error RmRegisterResources(uint dwSessionHandle, [Optional] uint nFiles,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.LPWStr)] string[]? rgsFileNames,
		[Optional] uint nApplications, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] RM_UNIQUE_PROCESS[]? rgApplications,
		[Optional] uint nServices, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5, ArraySubType = UnmanagedType.LPWStr)] string[]? rgsServiceNames);

	/// <summary>
	/// Removes any modifications to shutdown or restart actions that have been applied using the RmAddFilter function. The primary
	/// installer can call the <c>RmRemoveFilter</c> function multiple times.
	/// </summary>
	/// <param name="dwSessionHandle">A handle to an existing Restart Manager session.</param>
	/// <param name="strModuleName">
	/// A pointer to a <c>null</c>-terminated string value that contains the full path for the application's executable file. The
	/// <c>RmRemoveFilter</c> function removes any modifications to the referenced application's shutdown or restart actions previously
	/// applied by the RmAddFilter function. This parameter must be <c>NULL</c> if the Application or strServiceShortName parameter is
	/// non- <c>NULL</c>.
	/// </param>
	/// <param name="pProcess">
	/// The RM_UNIQUE_PROCESS structure for the application. The <c>RmRemoveFilter</c> function removes any modifications to the
	/// referenced application's shutdown or restart actions previously applied by the RmAddFilter function. This parameter must be
	/// <c>NULL</c> if the strFilename or strShortServiceName parameter is non- <c>NULL</c>.
	/// </param>
	/// <param name="strServiceShortName">
	/// A pointer to a <c>null</c>-terminated string value that contains the short service name. The <c>RmRemoveFilter</c> function
	/// removes any modifications to the referenced service's shutdown or restart actions previously applied by the RmAddFilter
	/// function. This parameter must be <c>NULL</c> if the strFilename or Application parameter is non- <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>This is the most recent error received. The function can return one of the system error codes that are defined in Winerror.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND 1</term>
	/// <term>The specified filter could not be found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SESSION_CREDENTIAL_CONFLICT 1219</term>
	/// <term>This error is returned when a secondary installer calls this function. This function is only available to primary installers.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/nf-restartmanager-rmremovefilter DWORD RmRemoveFilter( DWORD
	// dwSessionHandle, LPCWSTR strModuleName, RM_UNIQUE_PROCESS *pProcess, LPCWSTR strServiceShortName );
	[DllImport(Lib_Rstrtmgr, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("restartmanager.h", MSDNShortId = "NF:restartmanager.RmRemoveFilter")]
	public static extern Win32Error RmRemoveFilter(uint dwSessionHandle, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? strModuleName,
		in RM_UNIQUE_PROCESS pProcess, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? strServiceShortName);

	/// <summary>
	/// Removes any modifications to shutdown or restart actions that have been applied using the RmAddFilter function. The primary
	/// installer can call the <c>RmRemoveFilter</c> function multiple times.
	/// </summary>
	/// <param name="dwSessionHandle">A handle to an existing Restart Manager session.</param>
	/// <param name="strModuleName">
	/// A pointer to a <c>null</c>-terminated string value that contains the full path for the application's executable file. The
	/// <c>RmRemoveFilter</c> function removes any modifications to the referenced application's shutdown or restart actions previously
	/// applied by the RmAddFilter function. This parameter must be <c>NULL</c> if the Application or strServiceShortName parameter is
	/// non- <c>NULL</c>.
	/// </param>
	/// <param name="pProcess">
	/// The RM_UNIQUE_PROCESS structure for the application. The <c>RmRemoveFilter</c> function removes any modifications to the
	/// referenced application's shutdown or restart actions previously applied by the RmAddFilter function. This parameter must be
	/// <c>NULL</c> if the strFilename or strShortServiceName parameter is non- <c>NULL</c>.
	/// </param>
	/// <param name="strServiceShortName">
	/// A pointer to a <c>null</c>-terminated string value that contains the short service name. The <c>RmRemoveFilter</c> function
	/// removes any modifications to the referenced service's shutdown or restart actions previously applied by the RmAddFilter
	/// function. This parameter must be <c>NULL</c> if the strFilename or Application parameter is non- <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>This is the most recent error received. The function can return one of the system error codes that are defined in Winerror.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND 1</term>
	/// <term>The specified filter could not be found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SESSION_CREDENTIAL_CONFLICT 1219</term>
	/// <term>This error is returned when a secondary installer calls this function. This function is only available to primary installers.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/nf-restartmanager-rmremovefilter DWORD RmRemoveFilter( DWORD
	// dwSessionHandle, LPCWSTR strModuleName, RM_UNIQUE_PROCESS *pProcess, LPCWSTR strServiceShortName );
	[DllImport(Lib_Rstrtmgr, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("restartmanager.h", MSDNShortId = "NF:restartmanager.RmRemoveFilter")]
	public static extern Win32Error RmRemoveFilter(uint dwSessionHandle, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? strModuleName,
		[In, Optional] IntPtr pProcess, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? strServiceShortName);

	/// <summary>
	/// Restarts applications and services that have been shut down by the RmShutdown function and that have been registered to be
	/// restarted using the RegisterApplicationRestart function. This function can only be called by the primary installer that called
	/// the RmStartSession function to start the Restart Manager session.
	/// </summary>
	/// <param name="dwSessionHandle">A handle to the existing Restart Manager session.</param>
	/// <param name="dwRestartFlags">Reserved. This parameter should be 0.</param>
	/// <param name="fnStatus">
	/// A pointer to a status message callback function that is used to communicate status while the <c>RmRestart</c> function is
	/// running. If <c>NULL</c>, no status is provided.
	/// </param>
	/// <returns>
	/// <para>This is the most recent error received. The function can return one of the system error codes that are defined in Winerror.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_REQUEST_OUT_OF_SEQUENCE 776</term>
	/// <term>
	/// This error value is returned if the RmRestart function is called with a valid session handle before calling the RmShutdown function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_FAIL_RESTART 352</term>
	/// <term>
	/// One or more applications could not be restarted. The RM_PROCESS_INFO structures that are returned by the RmGetList function
	/// contain updated status information.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SEM_TIMEOUT 121</term>
	/// <term>
	/// A Restart Manager function could not obtain a registry write mutex in the allotted time. A system restart is recommended because
	/// further use of the Restart Manager is likely to fail.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_CANCELLED 1223</term>
	/// <term>This error value is returned by the RmRestart function when the request to cancel an operation is successful.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_ARGUMENTS 160</term>
	/// <term>
	/// One or more arguments are not correct. This error value is returned by the Restart Manager function if a NULL pointer or 0 is
	/// passed in a parameter that requires a non-null and non-zero value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_FAULT 29</term>
	/// <term>An operation was unable to read or write to the registry.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY 14</term>
	/// <term>A Restart Manager operation could not complete because not enough memory was available.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE 6</term>
	/// <term>No Restart Manager session exists for the handle supplied.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS 0</term>
	/// <term>The function succeeds and returns.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// After calling the <c>RmRestart</c> function, the RM_PROCESS_INFO structures that are returned by the RmGetList function contain
	/// updated status information.
	/// </para>
	/// <para>
	/// The Restart Manager respects the privileges that separate different user or terminal sessions. An installer that is running as a
	/// service with LocalSystem privileges cannot shut down or restart any applications in another user or terminal session. Installers
	/// should implement custom methods to shut down and restart applications that are running in other sessions. One method would be to
	/// start a new installer process in the other session to perform shutdown and restart operations.
	/// </para>
	/// <para>When a console application is shut down and restarted by Restart Manager, the application is restarted in a new console.</para>
	/// <para>
	/// Installers should always restart application and services using the <c>RmRestart</c> function even when the RmShutdown function
	/// returns an error indicating that not all applications and services could be shut down.
	/// </para>
	/// <para>
	/// The <c>RmRestart</c> function does not restart any applications that run with elevated privileges. Even if the application was
	/// shutdown by Restart Manager.
	/// </para>
	/// <para>
	/// The <c>RmRestart</c> function does not restart any applications that do not run as the currently-logged on user. Even if the
	/// application was shutdown by Restart Manager. For example, the <c>RmRestart</c> function does not restart applications started
	/// with the <c>Run As</c> command that do not run as the currently-logged on user. These applications must be manually restarted.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/nf-restartmanager-rmrestart DWORD RmRestart( DWORD
	// dwSessionHandle, DWORD dwRestartFlags, RM_WRITE_STATUS_CALLBACK fnStatus );
	[DllImport(Lib_Rstrtmgr, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("restartmanager.h", MSDNShortId = "NF:restartmanager.RmRestart")]
	public static extern Win32Error RmRestart(uint dwSessionHandle, [Optional] uint dwRestartFlags, [In, Optional] RM_WRITE_STATUS_CALLBACK? fnStatus);

	/// <summary>
	/// Initiates the shutdown of applications. This function can only be called from the installer that started the Restart Manager
	/// session using the RmStartSession function.
	/// </summary>
	/// <param name="dwSessionHandle">A handle to an existing Restart Manager session.</param>
	/// <param name="lActionFlags">
	/// <para>
	/// One or more RM_SHUTDOWN_TYPE options that configure the shut down of components. The following values can be combined by an OR
	/// operator to specify that unresponsive applications and services are to be forced to shut down if, and only if, all applications
	/// have been registered for restart.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RmForceShutdown 0x1</term>
	/// <term>
	/// Force unresponsive applications and services to shut down after the timeout period. An application that does not respond to a
	/// shutdown request is forced to shut down within 30 seconds. A service that does not respond to a shutdown request is forced to
	/// shut down after 20 seconds.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RmShutdownOnlyRegistered 0x10</term>
	/// <term>
	/// Shut down applications if and only if all the applications have been registered for restart using the RegisterApplicationRestart
	/// function. If any processes or services cannot be restarted, then no processes or services are shut down.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="fnStatus">
	/// A pointer to an RM_WRITE_STATUS_CALLBACK function that is used to communicate detailed status while this function is executing.
	/// If <c>NULL</c>, no status is provided.
	/// </param>
	/// <returns>
	/// <para>This is the most recent error received. The function can return one of the system error codes that are defined in Winerror.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0</term>
	/// <term>All shutdown, restart, and callback operations were successfully completed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FAIL_NOACTION_REBOOT 350</term>
	/// <term>
	/// No shutdown actions were performed. One or more processes or services require a restart of the system to be shut down. This
	/// error code is returned when the Restart Manager detects that a restart of the system is required before shutting down any application.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_FAIL_SHUTDOWN 351</term>
	/// <term>
	/// Some applications could not be shut down. The AppStatus of the RM_PROCESS_INFO structures returned by the RmGetList function
	/// contain updated status information.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_CANCELLED 1223</term>
	/// <term>This error value is returned by the RmShutdown function when the request to cancel an operation is successful.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SEM_TIMEOUT 121</term>
	/// <term>
	/// A Restart Manager function could not obtain a Registry write mutex in the allotted time. A system restart is recommended because
	/// further use of the Restart Manager is likely to fail.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_ARGUMENTS 160</term>
	/// <term>
	/// One or more arguments are not correct. This error value is returned by the Restart Manager function if a NULL pointer or 0 is
	/// passed in a parameter that requires a non-null and non-zero value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_FAULT 29</term>
	/// <term>An operation was unable to read or write to the registry.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY 14</term>
	/// <term>A Restart Manager operation could not be completed because not enough memory is available.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE 6</term>
	/// <term>No Restart Manager session exists for the handle supplied.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RmShutdown</c> function calls RmGetList and updates the list of processes currently using registered resources before
	/// attempting to shut down any processes. The <c>RmShutdown</c> function then attempts to shut down the processes using registered
	/// resources in the most current list. The <c>RmShutdown</c> function updates the <c>AppStatus</c> member of the RM_PROCESS_INFO
	/// structures that are returned by the <c>RmGetList</c> function with detailed status information.
	/// </para>
	/// <para>
	/// The Restart Manager respects the privileges that separate different user or terminal sessions. An installer that is running as a
	/// service with LocalSystem privileges cannot shut down or restart any applications in another user or terminal session. Installers
	/// should implement custom methods to shut down and restart applications that are running in other sessions. One method would be to
	/// start a new installer process in the other session to perform shutdown and restart operations.
	/// </para>
	/// <para>
	/// Installers should always restart application and services using the RmRestart function even when the <c>RmShutdown</c> function
	/// returns an error indicating that not all applications and services could be shut down.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/nf-restartmanager-rmshutdown DWORD RmShutdown( DWORD
	// dwSessionHandle, ULONG lActionFlags, RM_WRITE_STATUS_CALLBACK fnStatus );
	[DllImport(Lib_Rstrtmgr, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("restartmanager.h", MSDNShortId = "NF:restartmanager.RmShutdown")]
	public static extern Win32Error RmShutdown(uint dwSessionHandle, [Optional] RM_SHUTDOWN_TYPE lActionFlags, [In, Optional] RM_WRITE_STATUS_CALLBACK? fnStatus);

	/// <summary>
	/// Starts a new Restart Manager session. A maximum of 64 Restart Manager sessions per user session can be open on the system at the
	/// same time. When this function starts a session, it returns a session handle and session key that can be used in subsequent calls
	/// to the Restart Manager API.
	/// </summary>
	/// <param name="pSessionHandle">
	/// A pointer to the handle of a Restart Manager session. The session handle can be passed in subsequent calls to the Restart
	/// Manager API.
	/// </param>
	/// <param name="dwSessionFlags">Reserved. This parameter should be 0.</param>
	/// <param name="strSessionKey">
	/// A <c>null</c>-terminated string that contains the session key to the new session. The string must be allocated before calling
	/// the <c>RmStartSession</c> function.
	/// </param>
	/// <returns>
	/// <para>This is the most recent error received. The function can return one of the system error codes that are defined in Winerror.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SEM_TIMEOUT 121</term>
	/// <term>
	/// A Restart Manager function could not obtain a Registry write mutex in the allotted time. A system restart is recommended because
	/// further use of the Restart Manager is likely to fail.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_ARGUMENTS 160</term>
	/// <term>
	/// One or more arguments are not correct. This error value is returned by the Restart Manager function if a NULL pointer or 0 is
	/// passed in a parameter that requires a non-null and non-zero value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_MAX_SESSIONS_REACHED 353</term>
	/// <term>The maximum number of sessions has been reached.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_FAULT 29</term>
	/// <term>The system cannot write to the specified device.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY 14</term>
	/// <term>A Restart Manager operation could not complete because not enough memory was available.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>RmStartSession</c> function returns an error if a session with the same session key already exists.</para>
	/// <para>
	/// The <c>RmStartSession</c> function should be called by the primary installer that controls the user interface or that controls
	/// the installation sequence of multiple patches in an update.
	/// </para>
	/// <para>
	/// A secondary installer can join an existing Restart Manager session by calling the RmJoinSession function with the session handle
	/// and session key returned from the <c>RmStartSession</c> function call of the primary installer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/nf-restartmanager-rmstartsession DWORD RmStartSession( DWORD
	// *pSessionHandle, DWORD dwSessionFlags, WCHAR [] strSessionKey );
	[DllImport(Lib_Rstrtmgr, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("restartmanager.h", MSDNShortId = "NF:restartmanager.RmStartSession")]
	public static extern Win32Error RmStartSession(out uint pSessionHandle, [Optional] uint dwSessionFlags,
		[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder strSessionKey);

	/// <summary>
	/// Contains information about modifications to restart or shutdown actions. Add, remove, and list modifications to specified
	/// applications and services that have been registered with the Restart Manager session by using the RmAddFilter, RmRemoveFilter,
	/// and the RmGetFilterList functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/ns-restartmanager-rm_filter_info typedef struct _RM_FILTER_INFO
	// { RM_FILTER_ACTION FilterAction; RM_FILTER_TRIGGER FilterTrigger; DWORD cbNextOffset; union { LPWSTR strFilename;
	// RM_UNIQUE_PROCESS Process; LPWSTR strServiceShortName; }; } RM_FILTER_INFO, *PRM_FILTER_INFO;
	[PInvokeData("restartmanager.h", MSDNShortId = "NS:restartmanager._RM_FILTER_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RM_FILTER_INFO
	{
		/// <summary>
		/// This member contains a RM_FILTER_ACTION enumeration value. Use the value <c>RmNoRestart</c> to prevent the restart of the
		/// application or service. Use the value <c>RmNoShutdown</c> to prevent the shutdown and restart of the application or service.
		/// </summary>
		public RM_FILTER_ACTION FilterAction;

		/// <summary>
		/// This member contains a RM_FILTER_TRIGGER enumeration value. Use the value <c>RmFilterTriggerFile</c> to modify the restart
		/// or shutdown actions of an application referenced by the executable's full path filename. Use the value
		/// <c>RmFilterTriggerProcess</c> to modify the restart or shutdown actions of an application referenced by a RM_UNIQUE_PROCESS
		/// structure. Use the value <c>RmFilterTriggerService</c> to modify the restart or shutdown actions of a service referenced by
		/// the short service name.
		/// </summary>
		public RM_FILTER_TRIGGER FilterTrigger;

		/// <summary>The offset in bytes to the next structure.</summary>
		public uint cbNextOffset;

		private UNION union;

		[StructLayout(LayoutKind.Explicit)]
		private struct UNION
		{
			[FieldOffset(0)]
			public LPWSTR str;

			[FieldOffset(0)]
			public RM_UNIQUE_PROCESS proc;
		}

		/// <summary>
		/// If the value of <c>FilterTrigger</c> is <c>RmFilterTriggerFile</c>, this member contains a pointer to a string value that
		/// contains the application filename.
		/// </summary>
		public string? strFilename => union.str;

		/// <summary>
		/// If the value of <c>FilterTrigger</c> is <c>RmFilterTriggerProcess</c>, this member is a RM_PROCESS_INFO structure for the application.
		/// </summary>
		public RM_UNIQUE_PROCESS Process => union.proc;

		/// <summary>
		/// If the value of <c>FilterTrigger</c> is <c>RmFilterTriggerService</c> this member is a pointer to a string value that
		/// contains the short service name.
		/// </summary>
		public string? strServiceShortName => union.str;
	}

	/// <summary>Describes an application that is to be registered with the Restart Manager.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/ns-restartmanager-rm_process_info typedef struct
	// _RM_PROCESS_INFO { RM_UNIQUE_PROCESS Process; WCHAR strAppName[CCH_RM_MAX_APP_NAME + 1]; WCHAR
	// strServiceShortName[CCH_RM_MAX_SVC_NAME + 1]; RM_APP_TYPE ApplicationType; ULONG AppStatus; DWORD TSSessionId; BOOL bRestartable;
	// } RM_PROCESS_INFO, *PRM_PROCESS_INFO;
	[PInvokeData("restartmanager.h", MSDNShortId = "NS:restartmanager._RM_PROCESS_INFO")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct RM_PROCESS_INFO
	{
		/// <summary>
		/// Contains an RM_UNIQUE_PROCESS structure that uniquely identifies the application by its PID and the time the process began.
		/// </summary>
		public RM_UNIQUE_PROCESS Process;

		/// <summary>
		/// If the process is a service, this parameter returns the long name for the service. If the process is not a service, this
		/// parameter returns the user-friendly name for the application. If the process is a critical process, and the installer is run
		/// with elevated privileges, this parameter returns the name of the executable file of the critical process. If the process is
		/// a critical process, and the installer is run as a service, this parameter returns the long name of the critical process.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_APP_NAME + 1)]
		public string strAppName;

		/// <summary>
		/// If the process is a service, this is the short name for the service. This member is not used if the process is not a service.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_SVC_NAME + 1)]
		public string strServiceShortName;

		/// <summary>
		/// Contains an RM_APP_TYPE enumeration value that specifies the type of application as <c>RmUnknownApp</c>,
		/// <c>RmMainWindow</c>, <c>RmOtherWindow</c>, <c>RmService</c>, <c>RmExplorer</c> or <c>RmCritical</c>.
		/// </summary>
		public RM_APP_TYPE ApplicationType;

		/// <summary>Contains a bit mask that describes the current status of the application. See the RM_APP_STATUS enumeration.</summary>
		public RM_APP_STATUS AppStatus;

		/// <summary>
		/// Contains the Terminal Services session ID of the process. If the terminal session of the process cannot be determined, the
		/// value of this member is set to <c>RM_INVALID_SESSION</c> (-1). This member is not used if the process is a service or a
		/// system critical process.
		/// </summary>
		public uint TSSessionId;

		/// <summary>
		/// <c>TRUE</c> if the application can be restarted by the Restart Manager; otherwise, <c>FALSE</c>. This member is always
		/// <c>TRUE</c> if the process is a service. This member is always <c>FALSE</c> if the process is a critical system process.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bRestartable;
	}

	/// <summary>
	/// Uniquely identifies a process by its PID and the time the process began. An array of <c>RM_UNIQUE_PROCESS</c> structures can be
	/// passed to the RmRegisterResources function.
	/// </summary>
	/// <remarks>
	/// The <c>RM_UNIQUE_PROCESS</c> structure can be used to uniquely identify an application in an RM_PROCESS_INFO structure or
	/// registered with the Restart Manager session by the RmRegisterResources function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/restartmanager/ns-restartmanager-rm_unique_process typedef struct
	// _RM_UNIQUE_PROCESS { DWORD dwProcessId; FILETIME ProcessStartTime; } RM_UNIQUE_PROCESS, *PRM_UNIQUE_PROCESS;
	[PInvokeData("restartmanager.h", MSDNShortId = "NS:restartmanager._RM_UNIQUE_PROCESS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RM_UNIQUE_PROCESS
	{
		/// <summary>The product identifier (PID).</summary>
		public uint dwProcessId;

		/// <summary>
		/// The creation time of the process. The time is provided as a <c>FILETIME</c> structure that is returned by the lpCreationTime
		/// parameter of the GetProcessTimes function.
		/// </summary>
		public FILETIME ProcessStartTime;
	}
}