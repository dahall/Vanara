using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary/>
	public const uint SERVICE_DYNAMIC_INFORMATION_LEVEL_START_REASON = 1;

	/// <summary>
	/// <para>
	/// An application-defined callback function used with the RegisterServiceCtrlHandler function. A service program can use it as the
	/// control handler function of a particular service.
	/// </para>
	/// <para>
	/// The <c>LPHANDLER_FUNCTION</c> type defines a pointer to this function. <c>Handler</c> is a placeholder for the
	/// application-defined name.
	/// </para>
	/// <para>
	/// This function has been superseded by the HandlerEx control handler function used with the RegisterServiceCtrlHandlerEx function.
	/// A service can use either control handler, but the new control handler supports user-defined context data and additional extended
	/// control codes.
	/// </para>
	/// </summary>
	/// <param name="dwControl"/>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When a service is started, its ServiceMain function should immediately call the RegisterServiceCtrlHandler function to specify a
	/// <c>Handler</c> function to process control requests.
	/// </para>
	/// <para>
	/// The control dispatcher in the main thread of a service process invokes the control handler function for the specified service
	/// whenever it receives a control request from the service control manager. After processing the control request, the control
	/// handler must call the SetServiceStatus function if the service state changes to report its new status to the service control manager.
	/// </para>
	/// <para>
	/// The control handler function is intended to receive notification and return immediately. The callback function should save its
	/// parameters and create other threads to perform additional work. (Your application must ensure that such threads have exited
	/// before stopping the service.) In particular, a control handler should avoid operations that might block, such as taking a lock,
	/// because this could result in a deadlock or cause the system to stop responding.
	/// </para>
	/// <para>
	/// When the service control manager sends a control code to a service, it waits for the handler function to return before sending
	/// additional control codes to other services. The control handler should return as quickly as possible; if it does not return
	/// within 30 seconds, the SCM returns an error. If a service must do lengthy processing when the service is executing the control
	/// handler, it should create a secondary thread to perform the lengthy processing, and then return from the control handler. This
	/// prevents the service from tying up the control dispatcher and blocking other services from receiving control codes.
	/// </para>
	/// <para>
	/// The <c>SERVICE_CONTROL_SHUTDOWN</c> control code should only be processed by services that must absolutely clean up during
	/// shutdown, because there is a limited time (about 20 seconds) available for service shutdown. After this time expires, system
	/// shutdown proceeds regardless of whether service shutdown is complete. Note that if the system is left in the shutdown state (not
	/// restarted or powered down), the service continues to run. If your service registers to accept <c>SERVICE_CONTROL_SHUTDOWN</c>, it
	/// must handle the control code and stop in a timely fashion. Otherwise, the service can increase the time required to shut down the
	/// system, because the system must wait for the full amount of time allowed for service shutdown before system shutdown can proceed.
	/// </para>
	/// <para>
	/// If the service requires more time to clean up, it should send <c>STOP_PENDING</c> status messages, along with a wait hint, so the
	/// service controller knows how long to wait before reporting to the system that service shutdown is complete. However, to prevent a
	/// service from stopping shutdown, there is a limit to how long the service controller will wait. If the service is being shut down
	/// through the Services snap-in, the limit is 125 seconds. If the operating system is rebooting, the time limit is specified in the
	/// <c>WaitToKillServiceTimeout</c> value of the following registry key:
	/// </para>
	/// <para><c>HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control</c></para>
	/// <para>
	/// Services can also use the SetConsoleCtrlHandler function to receive shutdown notification. This notification is received when the
	/// running applications are shutting down, which occurs before services are shut down.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Writing a Control Handler Function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nc-winsvc-lphandler_function LPHANDLER_FUNCTION LphandlerFunction;
	// void LphandlerFunction( DWORD dwControl ) {...}
	[PInvokeData("winsvc.h", MSDNShortId = "e2d6d3a7-070e-4343-abd7-b4b9f8dd6fbc")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void Handler(ServiceControl dwControl);

	/// <summary>
	/// <para>
	/// An application-defined callback function used with the RegisterServiceCtrlHandlerEx function. A service program can use it as the
	/// control handler function of a particular service.
	/// </para>
	/// <para>
	/// The <c>LPHANDLER_FUNCTION_EX</c> type defines a pointer to this function. <c>HandlerEx</c> is a placeholder for the
	/// application-defined name.
	/// </para>
	/// <para>
	/// This function supersedes the Handler control handler function used with the RegisterServiceCtrlHandler function. A service can
	/// use either control handler, but the new control handler supports user-defined context data and additional extended control codes.
	/// </para>
	/// </summary>
	/// <param name="dwControl">
	/// <para>The control code. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Control code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_CONTROL_CONTINUE 0x00000003</term>
	/// <term>Notifies a paused service that it should resume.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_INTERROGATE 0x00000004</term>
	/// <term>
	/// Notifies a service to report its current status information to the service control manager. The handler should simply return
	/// NO_ERROR; the SCM is aware of the current state of the service.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_NETBINDADD 0x00000007</term>
	/// <term>
	/// Notifies a network service that there is a new component for binding. The service should bind to the new component. Applications
	/// should use Plug and Play functionality instead.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_NETBINDDISABLE 0x0000000A</term>
	/// <term>
	/// Notifies a network service that one of its bindings has been disabled. The service should reread its binding information and
	/// remove the binding. Applications should use Plug and Play functionality instead.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_NETBINDENABLE 0x00000009</term>
	/// <term>
	/// Notifies a network service that a disabled binding has been enabled. The service should reread its binding information and add
	/// the new binding. Applications should use Plug and Play functionality instead.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_NETBINDREMOVE 0x00000008</term>
	/// <term>
	/// Notifies a network service that a component for binding has been removed. The service should reread its binding information and
	/// unbind from the removed component. Applications should use Plug and Play functionality instead.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_PARAMCHANGE 0x00000006</term>
	/// <term>Notifies a service that service-specific startup parameters have changed. The service should reread its startup parameters.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_PAUSE 0x00000002</term>
	/// <term>Notifies a service that it should pause.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_PRESHUTDOWN 0x0000000F</term>
	/// <term>
	/// Notifies a service that the system will be shutting down. Services that need additional time to perform cleanup tasks beyond the
	/// tight time restriction at system shutdown can use this notification. The service control manager sends this notification to
	/// applications that have registered for it before sending a SERVICE_CONTROL_SHUTDOWN notification to applications that have
	/// registered for that notification. A service that handles this notification blocks system shutdown until the service stops or the
	/// preshutdown time-out interval specified through SERVICE_PRESHUTDOWN_INFO expires. Because this affects the user experience,
	/// services should use this feature only if it is absolutely necessary to avoid data loss or significant recovery time at the next
	/// system start. Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_SHUTDOWN 0x00000005</term>
	/// <term>
	/// Notifies a service that the system is shutting down so the service can perform cleanup tasks. Note that services that register
	/// for SERVICE_CONTROL_PRESHUTDOWN notifications cannot receive this notification because they have already stopped. If a service
	/// accepts this control code, it must stop after it performs its cleanup tasks and return NO_ERROR. After the SCM sends this control
	/// code, it will not send other control codes to the service. For more information, see the Remarks section of this topic.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_STOP 0x00000001</term>
	/// <term>
	/// Notifies a service that it should stop. If a service accepts this control code, it must stop upon receipt and return NO_ERROR.
	/// After the SCM sends this control code, it will not send other control codes to the service. Windows XP: If the service returns
	/// NO_ERROR and continues to run, it continues to receive control codes. This behavior changed starting with Windows Server 2003 and
	/// Windows XP with SP2.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// This parameter can also be one of the following extended control codes. Note that these control codes are not supported by the
	/// Handler function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Control Code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_CONTROL_DEVICEEVENT 0x0000000B</term>
	/// <term>
	/// Notifies a service of device events. (The service must have registered to receive these notifications using the
	/// RegisterDeviceNotification function.) The dwEventType and lpEventData parameters contain additional information.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_HARDWAREPROFILECHANGE 0x0000000C</term>
	/// <term>Notifies a service that the computer's hardware profile has changed. The dwEventType parameter contains additional information.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_POWEREVENT 0x0000000D</term>
	/// <term>
	/// Notifies a service of system power events. The dwEventType parameter contains additional information. If dwEventType is
	/// PBT_POWERSETTINGCHANGE, the lpEventData parameter also contains additional information.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_SESSIONCHANGE 0x0000000E</term>
	/// <term>
	/// Notifies a service of session change events. Note that a service will only be notified of a user logon if it is fully loaded
	/// before the logon attempt is made. The dwEventType and lpEventData parameters contain additional information.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_TIMECHANGE 0x00000010</term>
	/// <term>
	/// Notifies a service that the system time has changed. The lpEventData parameter contains additional information. The dwEventType
	/// parameter is not used. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This control code is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_TRIGGEREVENT 0x00000020</term>
	/// <term>
	/// Notifies a service registered for a service trigger event that the event has occurred. Windows Server 2008, Windows Vista,
	/// Windows Server 2003 and Windows XP: This control code is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_USERMODEREBOOT 0x00000040</term>
	/// <term>
	/// Notifies a service that the user has initiated a reboot. Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista,
	/// Windows Server 2003 and Windows XP: This control code is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// <para>This parameter can also be a user-defined control code, as described in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Control code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>Range 128 to 255.</term>
	/// <term>The service defines the action associated with the control code.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwEventType">
	/// <para>
	/// The type of event that has occurred. This parameter is used if dwControl is <c>SERVICE_CONTROL_DEVICEEVENT</c>,
	/// <c>SERVICE_CONTROL_HARDWAREPROFILECHANGE</c>, <c>SERVICE_CONTROL_POWEREVENT</c>, or <c>SERVICE_CONTROL_SESSIONCHANGE</c>.
	/// Otherwise, it is zero.
	/// </para>
	/// <para>If dwControl is <c>SERVICE_CONTROL_DEVICEEVENT</c>, this parameter can be one of the following values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>DBT_DEVICEARRIVAL</term>
	/// </item>
	/// <item>
	/// <term>DBT_DEVICEREMOVECOMPLETE</term>
	/// </item>
	/// <item>
	/// <term>DBT_DEVICEQUERYREMOVE</term>
	/// </item>
	/// <item>
	/// <term>DBT_DEVICEQUERYREMOVEFAILED</term>
	/// </item>
	/// <item>
	/// <term>DBT_DEVICEREMOVEPENDING</term>
	/// </item>
	/// <item>
	/// <term>DBT_CUSTOMEVENT</term>
	/// </item>
	/// </list>
	/// <para>If</para>
	/// <para>dwControl</para>
	/// <para>is</para>
	/// <para>SERVICE_CONTROL_HARDWAREPROFILECHANGE</para>
	/// <para>, this parameter can be one of the following values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>DBT_CONFIGCHANGED</term>
	/// </item>
	/// <item>
	/// <term>DBT_QUERYCHANGECONFIG</term>
	/// </item>
	/// <item>
	/// <term>DBT_CONFIGCHANGECANCELED</term>
	/// </item>
	/// </list>
	/// <para>If</para>
	/// <para>dwControl</para>
	/// <para>is</para>
	/// <para>SERVICE_CONTROL_POWEREVENT</para>
	/// <para>, this parameter can be one of the values specified in the</para>
	/// <para>wParam</para>
	/// <para>parameter of the</para>
	/// <para>WM_POWERBROADCAST</para>
	/// <para>message.</para>
	/// <para>
	/// If dwControl is <c>SERVICE_CONTROL_SESSIONCHANGE</c>, this parameter can be one of the values specified in the wParam parameter
	/// of the WM_WTSSESSION_CHANGE message.
	/// </para>
	/// </param>
	/// <param name="lpEventData">
	/// <para>
	/// Additional device information, if required. The format of this data depends on the value of the dwControl and dwEventType parameters.
	/// </para>
	/// <para>
	/// If dwControl is <c>SERVICE_CONTROL_DEVICEEVENT</c>, this data corresponds to the lParam parameter that applications receive as
	/// part of a WM_DEVICECHANGE message.
	/// </para>
	/// <para>
	/// If dwControl is <c>SERVICE_CONTROL_POWEREVENT</c> and dwEventType is PBT_POWERSETTINGCHANGE, this data is a pointer to a
	/// POWERBROADCAST_SETTING structure.
	/// </para>
	/// <para>If dwControl is <c>SERVICE_CONTROL_SESSIONCHANGE</c>, this parameter is a pointer to a WTSSESSION_NOTIFICATION structure.</para>
	/// <para>If dwControl is <c>SERVICE_CONTROL_TIMECHANGE</c>, this data is a pointer to a SERVICE_TIMECHANGE_INFO structure.</para>
	/// </param>
	/// <param name="lpContext">
	/// User-defined data passed from RegisterServiceCtrlHandlerEx. When multiple services share a process, the lpContext parameter can
	/// help identify the service.
	/// </param>
	/// <returns>
	/// <para>The return value for this function depends on the control code received.</para>
	/// <para>The following list identifies the rules for this return value:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// In general, if your service does not handle the control, return <c>ERROR_CALL_NOT_IMPLEMENTED</c>. However, your service should
	/// return <c>NO_ERROR</c> for <c>SERVICE_CONTROL_INTERROGATE</c> even if your service does not handle it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If your service handles <c>SERVICE_CONTROL_STOP</c> or <c>SERVICE_CONTROL_SHUTDOWN</c>, return <c>NO_ERROR</c>.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If your service handles <c>SERVICE_CONTROL_DEVICEEVENT</c>, return <c>NO_ERROR</c> to grant the request and an error code to deny
	/// the request.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If your service handles <c>SERVICE_CONTROL_HARDWAREPROFILECHANGE</c>, return <c>NO_ERROR</c> to grant the request and an error
	/// code to deny the request.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If your service handles <c>SERVICE_CONTROL_POWEREVENT</c>, return <c>NO_ERROR</c> to grant the request and an error code to deny
	/// the request.
	/// </term>
	/// </item>
	/// <item>
	/// <term>For all other control codes your service handles, return <c>NO_ERROR</c>.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When a service is started, its ServiceMain function should immediately call the RegisterServiceCtrlHandlerEx function to specify
	/// a <c>HandlerEx</c> function to process control requests. To specify the control codes to be accepted, use the SetServiceStatus
	/// and RegisterDeviceNotification functions.
	/// </para>
	/// <para>
	/// The control dispatcher in the main thread of a service invokes the control handler function for the specified service whenever it
	/// receives a control request from the service control manager. After processing the control request, the control handler must call
	/// SetServiceStatus if the service state changes to report its new status to the service control manager.
	/// </para>
	/// <para>
	/// The control handler function is intended to receive notification and return immediately. The callback function should save its
	/// parameters and create other threads to perform additional work. (Your application must ensure that such threads have exited
	/// before stopping the service.) In particular, a control handler should avoid operations that might block, such as taking a lock,
	/// because this could result in a deadlock or cause the system to stop responding.
	/// </para>
	/// <para>
	/// When the service control manager sends a control code to a service, it waits for the handler function to return before sending
	/// additional control codes to other services. The control handler should return as quickly as possible; if it does not return
	/// within 30 seconds, the SCM returns an error. If a service must do lengthy processing when the service is executing the control
	/// handler, it should create a secondary thread to perform the lengthy processing, and then return from the control handler. This
	/// prevents the service from tying up the control dispatcher and blocking other services from receiving control codes.
	/// </para>
	/// <para>
	/// The <c>SERVICE_CONTROL_SHUTDOWN</c> control code should only be processed by services that must absolutely clean up during
	/// shutdown, because there is a limited time (about 20 seconds) available for service shutdown. After this time expires, system
	/// shutdown proceeds regardless of whether service shutdown is complete. Note that if the system is left in the shutdown state (not
	/// restarted or powered down), the service continues to run. If your service registers to accept <c>SERVICE_CONTROL_SHUTDOWN</c>, it
	/// must handle the control code and return <c>NO_ERROR</c>. Returning an error for this control code and not stopping in a timely
	/// fashion can increase the time required to shut down the system, because the system must wait for the full amount of time allowed
	/// for service shutdown before system shutdown can proceed.
	/// </para>
	/// <para>
	/// If the service requires more time to clean up, it should send <c>STOP_PENDING</c> status messages, along with a wait hint, so the
	/// service controller knows how long to wait before reporting to the system that service shutdown is complete. However, to prevent a
	/// service from stopping shutdown, there is a limit to how long the service controller waits. If the service is being shut down
	/// through the Services snap-in, the limit is 125 seconds. If the operating system is rebooting, the time limit is specified in the
	/// <c>WaitToKillServiceTimeout</c> value of the following registry key:
	/// </para>
	/// <para><c>HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control</c></para>
	/// <para>
	/// Be sure to handle Plug and Play device events as quickly as possible; otherwise, the system may become unresponsive. If your
	/// event handler is to perform an operation that may block execution (such as I/O), it is best to start another thread to perform
	/// the operation asynchronously.
	/// </para>
	/// <para>
	/// Services can also use the SetConsoleCtrlHandler function to receive shutdown notification. This notification is received when the
	/// running applications are shutting down, which occurs before services are shut down.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsvc/nc-winsvc-lphandler_function_ex LPHANDLER_FUNCTION_EX
	// LphandlerFunctionEx; DWORD LphandlerFunctionEx( DWORD dwControl, DWORD dwEventType, LPVOID lpEventData, LPVOID lpContext ) {...}
	[PInvokeData("winsvc.h", MSDNShortId = "bb1b863f-e29f-496f-a50e-9ea524fe8603")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate Win32Error HandlerEx(ServiceControl dwControl, uint dwEventType, IntPtr lpEventData, [Optional] IntPtr lpContext);

	/// <summary>Callback function used in <see cref="SERVICE_NOTIFY_2"/> to alert changes registered by <see cref="NotifyServiceStatusChange"/>.</summary>
	/// <param name="pParameter">A pointer to the SERVICE_NOTIFY structure provided by the caller.</param>
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	[PInvokeData("winsvc.h", MSDNShortId = "52ede72e-eb50-48e2-b5c1-125816f6fe57")]
	public delegate void PFN_SC_NOTIFY_CALLBACK(IntPtr pParameter); //in SERVICE_NOTIFY_2 pParameter);

	/// <summary>
	/// <para>The entry point for a service.</para>
	/// <para>
	/// The <c>LPSERVICE_MAIN_FUNCTION</c> type defines a pointer to this callback function. <c>ServiceMain</c> is a placeholder for an
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="dwNumServicesArgs">Number of arguments in the <paramref name="lpServiceArgVectors"/> array.</param>
	/// <param name="lpServiceArgVectors">
	/// Array of strings. The first string is the name of the service and subsequent strings are passed by the process that called the
	/// StartService function to start the service.
	/// </param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// <para>
	/// A service program can start one or more services. A service process has a SERVICE_TABLE_ENTRY structure for each service that it
	/// can start. The structure specifies the service name and a pointer to the <c>ServiceMain</c> function for that service.
	/// </para>
	/// <para>
	/// When the service control manager receives a request to start a service, it starts the service process (if it is not already
	/// running). The main thread of the service process calls the StartServiceCtrlDispatcher function with a pointer to an array of
	/// SERVICE_TABLE_ENTRY structures. Then the service control manager sends a start request to the service control dispatcher for this
	/// service process. The service control dispatcher creates a new thread to execute the <c>ServiceMain</c> function of the service
	/// being started.
	/// </para>
	/// <para>
	/// The <c>ServiceMain</c> function should immediately call the RegisterServiceCtrlHandlerEx function to specify a HandlerEx function
	/// to handle control requests. Next, it should call the SetServiceStatus function to send status information to the service control
	/// manager. After these calls, the function should complete the initialization of the service. Do not attempt to start another
	/// service in the <c>ServiceMain</c> function.
	/// </para>
	/// <para>
	/// The Service Control Manager (SCM) waits until the service reports a status of SERVICE_RUNNING. It is recommended that the service
	/// reports this status as quickly as possible, as other components in the system that require interaction with SCM will be blocked
	/// during this time. Some functions may require interaction with the SCM either directly or indirectly.
	/// </para>
	/// <para>
	/// The SCM locks the service control database during initialization, so if a service attempts to call StartService during
	/// initialization, the call will block. When the service reports to the SCM that it has successfully started, it can call
	/// <c>StartService</c>. If the service requires another service to be running, the service should set the required dependencies.
	/// </para>
	/// <para>
	/// Furthermore, you should not call any system functions during service initialization. The service code should call system
	/// functions only after it reports a status of SERVICE_RUNNING.
	/// </para>
	/// <para>
	/// The <c>ServiceMain</c> function should create a global event, call the RegisterWaitForSingleObject function on this event, and
	/// exit. This will terminate the thread that is running the <c>ServiceMain</c> function, but will not terminate the service. When
	/// the service is stopping, the service control handler should call SetServiceStatus with SERVICE_STOP_PENDING and signal this
	/// event. A thread from the thread pool will execute the wait callback function; this function should perform clean-up tasks,
	/// including closing the global event, and call <c>SetServiceStatus</c> with SERVICE_STOPPED. After the service has stopped, you
	/// should not execute any additional service code because you can introduce a race condition if the service receives a start control
	/// and <c>ServiceMain</c> is called again. Note that this problem is more likely to occur when multiple services share a process.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Writing a ServiceMain Function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nc-winsvc-lpservice_main_functiona LPSERVICE_MAIN_FUNCTIONA
	// LpserviceMainFunctiona; void LpserviceMainFunctiona( DWORD dwNumServicesArgs, LPSTR *lpServiceArgVectors ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "d7f3235e-91bd-4107-a30c-4a8f9a6c731e")]
	public delegate void ServiceMain(uint dwNumServicesArgs, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr, SizeParamIndex = 0)] string[] lpServiceArgVectors);

	/// <summary>Defines the action to be performed in a <see cref="SC_ACTION"/>.</summary>
	[PInvokeData("winsvc.h", MSDNShortId = "e2c355a6-affe-46bf-a3e6-f8c420422d46")]
	public enum SC_ACTION_TYPE
	{
		/// <summary>No action.</summary>
		SC_ACTION_NONE = 0,

		/// <summary>Reboot the computer.</summary>
		SC_ACTION_REBOOT = 2,

		/// <summary>Restart the service.</summary>
		SC_ACTION_RESTART = 1,

		/// <summary>Run a command.</summary>
		SC_ACTION_RUN_COMMAND = 3,

		/// <summary>Undocumented.</summary>
		SC_ACTION_OWN_RESTART = 4
	}

	/// <summary>The service attributes that are to be returned from <see cref="EnumServicesStatusEx(SC_HANDLE, ServiceTypes, SERVICE_STATE, string)"/>.</summary>
	public enum SC_ENUM_TYPE
	{
		/// <summary>
		/// Retrieve the name and service status information for each service in the database. The lpServices parameter is a pointer to a
		/// buffer that receives an array of ENUM_SERVICE_STATUS_PROCESS structures.
		/// </summary>
		SC_ENUM_PROCESS_INFO = 0
	}

	/// <summary>Info levels for <see cref="QueryServiceStatusEx"/></summary>
	public enum SC_STATUS_TYPE
	{
		/// <summary/>
		[CorrespondingType(typeof(SERVICE_STATUS_PROCESS))]
		SC_STATUS_PROCESS_INFO = 0
	}

	/// <summary>Service Control Manager object specific access types</summary>
	[PInvokeData("winsvc.h")]
	[Flags]
	public enum ScManagerAccessTypes : uint
	{
		/// <summary>Required to connect to the service control manager.</summary>
		SC_MANAGER_CONNECT = 0x0001,

		/// <summary>Required to call the CreateService function to create a service object and add it to the database.</summary>
		SC_MANAGER_CREATE_SERVICE = 0x0002,

		/// <summary>
		/// Required to call the <see cref="EnumServicesStatus(SC_HANDLE, ServiceTypes, SERVICE_STATE)"/> or <see cref="EnumServicesStatusEx(SC_HANDLE, ServiceTypes, SERVICE_STATE, string)"/> function to list the services
		/// that are in the database. Required to call the <see cref="NotifyServiceStatusChange"/> function to receive notification when
		/// any service is created or deleted.
		/// </summary>
		SC_MANAGER_ENUMERATE_SERVICE = 0x0004,

		/// <summary>Required to call the <see cref="LockServiceDatabase"/> function to acquire a lock on the database.</summary>
		SC_MANAGER_LOCK = 0x0008,

		/// <summary>
		/// Required to call the <see cref="QueryServiceLockStatus"/> function to retrieve the lock status information for the database.
		/// </summary>
		SC_MANAGER_QUERY_LOCK_STATUS = 0x0010,

		/// <summary>Required to call the <see cref="NotifyBootConfigStatus"/> function.</summary>
		SC_MANAGER_MODIFY_BOOT_CONFIG = 0x0020,

		/// <summary>Includes <see cref="ACCESS_MASK.STANDARD_RIGHTS_REQUIRED"/>, in addition to all access rights in this table.</summary>
		SC_MANAGER_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED |
										  SC_MANAGER_CONNECT |
										  SC_MANAGER_CREATE_SERVICE |
										  SC_MANAGER_ENUMERATE_SERVICE |
										  SC_MANAGER_LOCK |
										  SC_MANAGER_QUERY_LOCK_STATUS |
										  SC_MANAGER_MODIFY_BOOT_CONFIG
	}

	/// <summary>The type of status changes that should be reported.</summary>
	[PInvokeData("winsvc.h", MSDNShortId = "e22b7f69-f096-486f-97fa-0465bef499cd")]
	[Flags]
	public enum SERVICE_NOTIFY_FLAGS
	{
		/// <summary>
		/// Report when the service has been created.
		/// <para>The hService parameter must be a handle to the SCM.</para>
		/// </summary>
		SERVICE_NOTIFY_CREATED = 0x00000080,

		/// <summary>
		/// Report when the service is about to continue.
		/// <para>The hService parameter must be a handle to the service.</para>
		/// </summary>
		SERVICE_NOTIFY_CONTINUE_PENDING = 0x00000010,

		/// <summary>
		/// Report when an application has specified the service in a call to the DeleteService function. Your application should close
		/// any handles to the service so it can be deleted.
		/// <para>The hService parameter must be a handle to the service.</para>
		/// </summary>
		SERVICE_NOTIFY_DELETE_PENDING = 0x00000200,

		/// <summary>
		/// Report when the service has been deleted. An application cannot receive this notification if it has an open handle to the service.
		/// <para>The hService parameter must be a handle to the SCM.</para>
		/// </summary>
		SERVICE_NOTIFY_DELETED = 0x00000100,

		/// <summary>
		/// Report when the service is pausing.
		/// <para>The hService parameter must be a handle to the service.</para>
		/// </summary>
		SERVICE_NOTIFY_PAUSE_PENDING = 0x00000020,

		/// <summary>
		/// Report when the service has paused.
		/// <para>The hService parameter must be a handle to the service.</para>
		/// </summary>
		SERVICE_NOTIFY_PAUSED = 0x00000040,

		/// <summary>
		/// Report when the service is running.
		/// <para>The hService parameter must be a handle to the service.</para>
		/// </summary>
		SERVICE_NOTIFY_RUNNING = 0x00000008,

		/// <summary>
		/// Report when the service is starting.
		/// <para>The hService parameter must be a handle to the service.</para>
		/// </summary>
		SERVICE_NOTIFY_START_PENDING = 0x00000002,

		/// <summary>
		/// Report when the service is stopping.
		/// <para>The hService parameter must be a handle to the service.</para>
		/// </summary>
		SERVICE_NOTIFY_STOP_PENDING = 0x00000004,

		/// <summary>
		/// Report when the service has stopped.
		/// <para>The hService parameter must be a handle to the service.</para>
		/// </summary>
		SERVICE_NOTIFY_STOPPED = 0x00000001,
	}

	/// <summary>The state of the services to be enumerated.</summary>
	[PInvokeData("winsvc.h", MSDNShortId = "905d4453-96d4-4055-8a17-36714c547cdd")]
	[Flags]
	public enum SERVICE_STATE
	{
		/// <summary>
		/// Enumerates services that are in the following states: SERVICE_START_PENDING, SERVICE_STOP_PENDING, SERVICE_RUNNING,
		/// SERVICE_CONTINUE_PENDING, SERVICE_PAUSE_PENDING, and SERVICE_PAUSED.
		/// </summary>
		SERVICE_ACTIVE = 0x00000001,

		/// <summary>Enumerates services that are in the SERVICE_STOPPED state.</summary>
		SERVICE_INACTIVE = 0x00000002,

		/// <summary>Combines the following states: SERVICE_ACTIVE and SERVICE_INACTIVE.</summary>
		SERVICE_STATE_ALL = 0x00000003,
	}

	/// <summary/>
	[Flags]
	public enum SERVICE_STOP_REASON : uint
	{
		// Stop reason flags. Update SERVICE_STOP_REASON_FLAG_MAX when new flags are added.
		/// <summary/>
		SERVICE_STOP_REASON_FLAG_MIN = 0x00000000,

		/// <summary/>
		SERVICE_STOP_REASON_FLAG_UNPLANNED = 0x10000000,
		/// <summary/>
		SERVICE_STOP_REASON_FLAG_CUSTOM = 0x20000000,
		/// <summary/>
		SERVICE_STOP_REASON_FLAG_PLANNED = 0x40000000,
		/// <summary/>
		SERVICE_STOP_REASON_FLAG_MAX = 0x80000000,

		// Microsoft major reasons. Update SERVICE_STOP_REASON_MAJOR_MAX when new codes are added.

		/// <summary/>
		SERVICE_STOP_REASON_MAJOR_MIN = 0x00000000,

		/// <summary/>
		SERVICE_STOP_REASON_MAJOR_OTHER = 0x00010000,
		/// <summary/>
		SERVICE_STOP_REASON_MAJOR_HARDWARE = 0x00020000,
		/// <summary/>
		SERVICE_STOP_REASON_MAJOR_OPERATINGSYSTEM = 0x00030000,
		/// <summary/>
		SERVICE_STOP_REASON_MAJOR_SOFTWARE = 0x00040000,
		/// <summary/>
		SERVICE_STOP_REASON_MAJOR_APPLICATION = 0x00050000,
		/// <summary/>
		SERVICE_STOP_REASON_MAJOR_NONE = 0x00060000,
		/// <summary/>
		SERVICE_STOP_REASON_MAJOR_MAX = 0x00070000,
		/// <summary/>
		SERVICE_STOP_REASON_MAJOR_MIN_CUSTOM = 0x00400000,
		/// <summary/>
		SERVICE_STOP_REASON_MAJOR_MAX_CUSTOM = 0x00ff0000,

		// Microsoft minor reasons. Update SERVICE_STOP_REASON_MINOR_MAX when new codes are added.

		/// <summary/>
		SERVICE_STOP_REASON_MINOR_MIN = 0x00000000,

		/// <summary/>
		SERVICE_STOP_REASON_MINOR_OTHER = 0x00000001,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_MAINTENANCE = 0x00000002,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_INSTALLATION = 0x00000003,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_UPGRADE = 0x00000004,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_RECONFIG = 0x00000005,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_HUNG = 0x00000006,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_UNSTABLE = 0x00000007,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_DISK = 0x00000008,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_NETWORKCARD = 0x00000009,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_ENVIRONMENT = 0x0000000a,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_HARDWARE_DRIVER = 0x0000000b,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_OTHERDRIVER = 0x0000000c,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_SERVICEPACK = 0x0000000d,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_SOFTWARE_UPDATE = 0x0000000e,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_SECURITYFIX = 0x0000000f,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_SECURITY = 0x00000010,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_NETWORK_CONNECTIVITY = 0x00000011,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_WMI = 0x00000012,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_SERVICEPACK_UNINSTALL = 0x00000013,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_SOFTWARE_UPDATE_UNINSTALL = 0x00000014,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_SECURITYFIX_UNINSTALL = 0x00000015,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_MMC = 0x00000016,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_NONE = 0x00000017,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_MEMOTYLIMIT = 0x00000018,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_MAX = 0x00000019,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_MIN_CUSTOM = 0x00000100,
		/// <summary/>
		SERVICE_STOP_REASON_MINOR_MAX_CUSTOM = 0x0000FFFF
	}

	/// <summary>Service control codes.</summary>
	[PInvokeData("winsvc.h", MSDNShortId = "d268609b-d442-4d0f-9d49-ed23fee84961")]
	[Flags]
	public enum ServiceAcceptedControlCodes : uint
	{
		/// <summary>The service can be stopped. This control code allows the service to receive SERVICE_CONTROL_STOP notifications.</summary>
		SERVICE_ACCEPT_STOP = 0x00000001,

		/// <summary>
		/// The service can be paused and continued. This control code allows the service to receive SERVICE_CONTROL_PAUSE and
		/// SERVICE_CONTROL_CONTINUE notifications.
		/// </summary>
		SERVICE_ACCEPT_PAUSE_CONTINUE = 0x00000002,

		/// <summary>
		/// The service is notified when system shutdown occurs. This control code allows the service to receive SERVICE_CONTROL_SHUTDOWN
		/// notifications. Note that ControlService and ControlServiceEx cannot send this notification; only the system can send it.
		/// </summary>
		SERVICE_ACCEPT_SHUTDOWN = 0x00000004,

		/// <summary>
		/// The service can reread its startup parameters without being stopped and restarted. This control code allows the service to
		/// receive SERVICE_CONTROL_PARAMCHANGE notifications.
		/// </summary>
		SERVICE_ACCEPT_PARAMCHANGE = 0x00000008,

		/// <summary>
		/// The service is a network component that can accept changes in its binding without being stopped and restarted. This control
		/// code allows the service to receive SERVICE_CONTROL_NETBINDADD, SERVICE_CONTROL_NETBINDREMOVE, SERVICE_CONTROL_NETBINDENABLE,
		/// and SERVICE_CONTROL_NETBINDDISABLE notifications.
		/// </summary>
		SERVICE_ACCEPT_NETBINDCHANGE = 0x00000010,

		/// <summary>
		/// The service is notified when the computer's hardware profile has changed. This enables the system to send
		/// SERVICE_CONTROL_HARDWAREPROFILECHANGE notifications to the service.
		/// </summary>
		SERVICE_ACCEPT_HARDWAREPROFILECHANGE = 0x00000020,

		/// <summary>
		/// The service is notified when the computer's power status has changed. This enables the system to send
		/// SERVICE_CONTROL_POWEREVENT notifications to the service.
		/// </summary>
		SERVICE_ACCEPT_POWEREVENT = 0x00000040,

		/// <summary>
		/// The service is notified when the computer's session status has changed. This enables the system to send
		/// SERVICE_CONTROL_SESSIONCHANGE notifications to the service.
		/// </summary>
		SERVICE_ACCEPT_SESSIONCHANGE = 0x00000080,

		/// <summary>
		/// The service can perform preshutdown tasks. This control code enables the service to receive SERVICE_CONTROL_PRESHUTDOWN
		/// notifications. Note that ControlService and ControlServiceEx cannot send this notification; only the system can send it.
		/// Windows Server 2003 and Windows XP: This value is not supported.
		/// </summary>
		SERVICE_ACCEPT_PRESHUTDOWN = 0x00000100,

		/// <summary>
		/// The service is notified when the system time has changed. This enables the system to send SERVICE_CONTROL_TIMECHANGE
		/// notifications to the service. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This control code is
		/// not supported.
		/// </summary>
		SERVICE_ACCEPT_TIMECHANGE = 0x00000200,

		/// <summary>
		/// The service is notified when an event for which the service has registered occurs. This enables the system to send
		/// SERVICE_CONTROL_TRIGGEREVENT notifications to the service. Windows Server 2008, Windows Vista, Windows Server 2003 and
		/// Windows XP: This control code is not supported.
		/// </summary>
		SERVICE_ACCEPT_TRIGGEREVENT = 0x00000400,

		/// <summary>
		/// The services is notified when the user initiates a reboot. Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows
		/// Vista, Windows Server 2003 and Windows XP: This control code is not supported.
		/// </summary>
		SERVICE_ACCEPT_USER_LOGOFF = 0x00000800,

		/// <summary>Undocumented.</summary>
		SERVICE_ACCEPT_LOWRESOURCES = 0x00002000,

		/// <summary>Undocumented.</summary>
		SERVICE_ACCEPT_SYSTEMLOWRESOURCES = 0x00004000,
	}

	/// <summary>Service access rights.</summary>
	[Flags]
	public enum ServiceAccessRights : uint
	{
		/// <summary>Includes STANDARD_RIGHTS_REQUIRED in addition to all access rights in this table.</summary>
		SERVICE_ALL_ACCESS = 0xF01FF,

		/// <summary>
		/// Required to call the ChangeServiceConfig or ChangeServiceConfig2 function to change the service configuration. Because this
		/// grants the caller the right to change the executable file that the system runs, it should be granted only to administrators.
		/// </summary>
		SERVICE_CHANGE_CONFIG = 0x0002,

		/// <summary>Required to call the EnumDependentServices function to enumerate all the services dependent on the service.</summary>
		SERVICE_ENUMERATE_DEPENDENTS = 0x0008,

		/// <summary>Required to call the ControlService function to ask the service to report its status immediately.</summary>
		SERVICE_INTERROGATE = 0x0080,

		/// <summary>Required to call the ControlService function to pause or continue the service.</summary>
		SERVICE_PAUSE_CONTINUE = 0x0040,

		/// <summary>Required to call the QueryServiceConfig and QueryServiceConfig2 functions to query the service configuration.</summary>
		SERVICE_QUERY_CONFIG = 0x0001,

		/// <summary>
		/// Required to call the QueryServiceStatus or QueryServiceStatusEx function to ask the service control manager about the status
		/// of the service.
		/// <para>Required to call the NotifyServiceStatusChange function to receive notification when a service changes status.</para>
		/// </summary>
		SERVICE_QUERY_STATUS = 0x0004,

		/// <summary>Required to call the StartService function to start the service.</summary>
		SERVICE_START = 0x0010,

		/// <summary>Required to call the ControlService function to stop the service.</summary>
		SERVICE_STOP = 0x0020,

		/// <summary>Required to call the ControlService function to specify a user-defined control code.</summary>
		SERVICE_USER_DEFINED_CONTROL = 0x0100,

		/// <summary>
		/// Required to call the QueryServiceObjectSecurity or SetServiceObjectSecurity function to access the SACL. The proper way to
		/// obtain this access is to enable the SE_SECURITY_NAMEprivilege in the caller's current access token, open the handle for
		/// ACCESS_SYSTEM_SECURITY access, and then disable the privilege.
		/// </summary>
		ACCESS_SYSTEM_SECURITY = 0x01000000,

		/// <summary>Required to call the DeleteService function to delete the service.</summary>
		DELETE = ACCESS_MASK.DELETE,

		/// <summary>Required to call the QueryServiceObjectSecurity function to query the security descriptor of the service object.</summary>
		READ_CONTROL = ACCESS_MASK.READ_CONTROL,

		/// <summary>
		/// Required to call the SetServiceObjectSecurity function to modify the Dacl member of the service object's security descriptor.
		/// </summary>
		WRITE_DAC = ACCESS_MASK.WRITE_DAC,

		/// <summary>
		/// Required to call the SetServiceObjectSecurity function to modify the Owner and Group members of the service object's security descriptor.
		/// </summary>
		WRITE_OWNER = ACCESS_MASK.WRITE_OWNER,

		/// <summary/>
		GENERIC_READ = ACCESS_MASK.STANDARD_RIGHTS_READ | SERVICE_QUERY_CONFIG | SERVICE_QUERY_STATUS | SERVICE_INTERROGATE | SERVICE_ENUMERATE_DEPENDENTS,
		/// <summary/>
		GENERIC_WRITE = ACCESS_MASK.STANDARD_RIGHTS_WRITE | SERVICE_CHANGE_CONFIG,
		/// <summary/>
		GENERIC_EXECUTE = ACCESS_MASK.STANDARD_RIGHTS_EXECUTE | SERVICE_START | SERVICE_STOP | SERVICE_PAUSE_CONTINUE | SERVICE_USER_DEFINED_CONTROL,
	}

	/// <summary>Service object specific access type</summary>
	[PInvokeData("winsvc.h")]
	[Flags]
	public enum ServiceAccessTypes : uint
	{
		/// <summary>
		/// Required to call the <see cref="QueryServiceConfig"/> and <see cref="QueryServiceConfig2"/> functions to query the service configuration.
		/// </summary>
		SERVICE_QUERY_CONFIG = 0x0001,

		/// <summary>
		/// Required to call the <see cref="ChangeServiceConfig(SC_HANDLE, ServiceTypes, ServiceStartType, ServiceErrorControlType,
		/// string, string, IntPtr, string[], string, string, string)"/> or <see cref="ChangeServiceConfig2"/> function to change the
		/// service configuration. Because this grants the caller the right to change the executable file that the system runs, it should
		/// be granted only to administrators.
		/// </summary>
		SERVICE_CHANGE_CONFIG = 0x0002,

		/// <summary>
		/// Required to call the <see cref="QueryServiceStatus"/> or <see cref="QueryServiceStatusEx"/> function to ask the service
		/// control manager about the status of the service. Required to call the <see cref="NotifyServiceStatusChange"/> function to
		/// receive notification when a service changes status.
		/// </summary>
		SERVICE_QUERY_STATUS = 0x0004,

		/// <summary>
		/// Required to call the <see cref="EnumDependentServices(SC_HANDLE, SERVICE_STATE)"/> function to enumerate all the services dependent on the service.
		/// </summary>
		SERVICE_ENUMERATE_DEPENDENTS = 0x0008,

		/// <summary>Required to call the <see cref="StartService"/> function to start the service.</summary>
		SERVICE_START = 0x0010,

		/// <summary>Required to call the <see cref="ControlService"/> function to stop the service.</summary>
		SERVICE_STOP = 0x0020,

		/// <summary>Required to call the <see cref="ControlService"/> function to pause or continue the service.</summary>
		SERVICE_PAUSE_CONTINUE = 0x0040,

		/// <summary>Required to call the <see cref="ControlService"/> function to ask the service to report its status immediately.</summary>
		SERVICE_INTERROGATE = 0x0080,

		/// <summary>Required to call the <see cref="ControlService"/> function to specify a user-defined control code.</summary>
		SERVICE_USER_DEFINED_CONTROL = 0x0100,

		/// <summary>Includes <see cref="ACCESS_MASK.STANDARD_RIGHTS_REQUIRED"/> in addition to all access rights in this table.</summary>
		SERVICE_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED |
										 SERVICE_QUERY_CONFIG |
										 SERVICE_CHANGE_CONFIG |
										 SERVICE_QUERY_STATUS |
										 SERVICE_ENUMERATE_DEPENDENTS |
										 SERVICE_START |
										 SERVICE_STOP |
										 SERVICE_PAUSE_CONTINUE |
										 SERVICE_INTERROGATE |
										 SERVICE_USER_DEFINED_CONTROL
	}

	/// <summary>Used by the <see cref="ChangeServiceConfig2"/> method.</summary>
	public enum ServiceConfigOption : uint
	{
		/// <summary>
		/// The lpInfo parameter is a pointer to a SERVICE_DELAYED_AUTO_START_INFO structure.
		/// <para><c>Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
		/// </summary>
		[CorrespondingType(typeof(SERVICE_DELAYED_AUTO_START_INFO))]
		SERVICE_CONFIG_DELAYED_AUTO_START_INFO = 3,

		/// <summary>The lpInfo parameter is a pointer to a SERVICE_DESCRIPTION structure.</summary>
		[CorrespondingType(typeof(SERVICE_DESCRIPTION))]
		SERVICE_CONFIG_DESCRIPTION = 1,

		/// <summary>
		/// The lpInfo parameter is a pointer to a SERVICE_FAILURE_ACTIONS structure.
		/// <para>
		/// If the service controller handles the SC_ACTION_REBOOT action, the caller must have the SE_SHUTDOWN_NAME privilege. For more
		/// information, see Running with Special Privileges.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(SERVICE_FAILURE_ACTIONS))]
		SERVICE_CONFIG_FAILURE_ACTIONS = 2,

		/// <summary>
		/// The lpInfo parameter is a pointer to a SERVICE_FAILURE_ACTIONS_FLAG structure.
		/// <para><c>Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
		/// </summary>
		[CorrespondingType(typeof(SERVICE_FAILURE_ACTIONS_FLAG))]
		SERVICE_CONFIG_FAILURE_ACTIONS_FLAG = 4,

		/// <summary>
		/// The lpInfo parameter is a pointer to a SERVICE_PREFERRED_NODE_INFO structure.
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
		/// </summary>
		[CorrespondingType(typeof(SERVICE_PREFERRED_NODE_INFO))]
		SERVICE_CONFIG_PREFERRED_NODE = 9,

		/// <summary>
		/// The lpInfo parameter is a pointer to a SERVICE_PRESHUTDOWN_INFO structure.
		/// <para><c>Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
		/// </summary>
		[CorrespondingType(typeof(SERVICE_PRESHUTDOWN_INFO))]
		SERVICE_CONFIG_PRESHUTDOWN_INFO = 7,

		/// <summary>
		/// The lpInfo parameter is a pointer to a SERVICE_REQUIRED_PRIVILEGES_INFO structure.
		/// <para><c>Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
		/// </summary>
		[CorrespondingType(typeof(SERVICE_REQUIRED_PRIVILEGES_INFO))]
		SERVICE_CONFIG_REQUIRED_PRIVILEGES_INFO = 6,

		/// <summary>The lpInfo parameter is a pointer to a SERVICE_SID_INFO structure.</summary>
		[CorrespondingType(typeof(SERVICE_SID_INFO))]
		SERVICE_CONFIG_SERVICE_SID_INFO = 5,

		/// <summary>
		/// The lpInfo parameter is a pointer to a SERVICE_TRIGGER_INFO structure. This value is not supported by the ANSI version of ChangeServiceConfig2.
		/// <para>
		/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported until Windows
		/// Server 2008 R2.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(SERVICE_TRIGGER_INFO))]
		SERVICE_CONFIG_TRIGGER_INFO = 8,

		/// <summary>
		/// <para>The lpInfo parameter is a pointer a SERVICE_LAUNCH_P/// ROTECTED_INFO structure.</para>
		/// <note>This value is supported starting with Windows 8.1.</note>
		/// </summary>
		[CorrespondingType(typeof(SERVICE_LAUNCH_PROTECTED_INFO))]
		SERVICE_CONFIG_LAUNCH_PROTECTED = 12,
	}

	/// <summary>Service control codes to be used with <see cref="ControlService"/> and <see cref="ControlServiceEx"/></summary>
	public enum ServiceControl : uint
	{
		/// <summary>Notifies a service that it should pause. The hService handle must have the SERVICE_PAUSE_CONTINUE access right.</summary>
		SERVICE_CONTROL_PAUSE = 0x00000002,

		/// <summary>
		/// Notifies a paused service that it should resume. The hService handle must have the SERVICE_PAUSE_CONTINUE access right.
		/// </summary>
		SERVICE_CONTROL_CONTINUE = 0x00000003,

		/// <summary>
		/// Notifies a service that it should report its current status information to the service control manager. The hService handle
		/// must have the SERVICE_INTERROGATE access right. Note that this control is not generally useful as the SCM is aware of the
		/// current state of the service
		/// </summary>
		SERVICE_CONTROL_INTERROGATE = 0x00000004,

		/// <summary>
		/// Notifies a service that its startup parameters have changed. The hService handle must have the SERVICE_PAUSE_CONTINUE access right.
		/// </summary>
		SERVICE_CONTROL_PARAMCHANGE = 0x00000006,

		/// <summary>
		/// Notifies a network service that there is a new component for binding. The hService handle must have the
		/// SERVICE_PAUSE_CONTINUE access right. However, this control code has been deprecated; use Plug and Play functionality instead.
		/// </summary>
		SERVICE_CONTROL_NETBINDADD = 0x00000007,

		/// <summary>
		/// Notifies a network service that a component for binding has been removed. The hService handle must have the
		/// SERVICE_PAUSE_CONTINUE access right. However, this control code has been deprecated; use Plug and Play functionality instead.
		/// </summary>
		SERVICE_CONTROL_NETBINDREMOVE = 0x00000008,

		/// <summary>
		/// Notifies a network service that a disabled binding has been enabled. The hService handle must have the SERVICE_PAUSE_CONTINUE
		/// access right. However, this control code has been deprecated; use Plug and Play functionality instead.
		/// </summary>
		SERVICE_CONTROL_NETBINDENABLE = 0x00000009,

		/// <summary>
		/// Notifies a network service that one of its bindings has been disabled. The hService handle must have the
		/// SERVICE_PAUSE_CONTINUE access right. However, this control code has been deprecated; use Plug and Play functionality instead.
		/// </summary>
		SERVICE_CONTROL_NETBINDDISABLE = 0x0000000A,

		//#define SERVICE_CONTROL_USER_LOGOFF  = 0x00000011
		//reserved for internal use            = 0x00000021
		//reserved for internal use            = 0x00000050

		/// <summary></summary>
		SERVICE_CONTROL_LOWRESOURCES = 0x00000060,

		/// <summary></summary>
		SERVICE_CONTROL_SYSTEMLOWRESOURCES = 0x00000061,

		/// <summary>
		/// Notifies a service that the system will be shutting down. Services that need additional time to perform cleanup tasks beyond
		/// the tight time restriction at system shutdown can use this notification. The service control manager sends this notification
		/// to applications that have registered for it before sending a SERVICE_CONTROL_SHUTDOWN notification to applications that have
		/// registered for that notification.
		/// <para>
		/// A service that handles this notification blocks system shutdown until the service stops or the pre-shutdown time-out interval
		/// specified through SERVICE_PRESHUTDOWN_INFO expires. Because this affects the user experience, services should use this
		/// feature only if it is absolutely necessary to avoid data loss or significant recovery time at the next system start.
		/// </para>
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		SERVICE_CONTROL_PRESHUTDOWN = 0x0000000F,

		/// <summary>
		/// Notifies a service that the system is shutting down so the service can perform cleanup tasks. Note that services that
		/// register for SERVICE_CONTROL_PRESHUTDOWN notifications cannot receive this notification because they have already stopped.
		/// <para>
		/// If a service accepts this control code, it must stop after it performs its cleanup tasks and return NO_ERROR. After the SCM
		/// sends this control code, it will not send other control codes to the service.
		/// </para>
		/// <para>For more information, see the Remarks section of this topic.</para>
		/// </summary>
		SERVICE_CONTROL_SHUTDOWN = 0x00000005,

		/// <summary>
		/// Notifies a service that it should stop.
		/// <para>
		/// If a service accepts this control code, it must stop upon receipt and return NO_ERROR. After the SCM sends this control code,
		/// it will not send other control codes to the service. Windows XP: If the service returns NO_ERROR and continues to run, it
		/// continues to receive control codes. This behavior changed starting with Windows Server 2003 and Windows XP with SP2.
		/// </para>
		/// <para>
		/// This parameter can also be one of the following extended control codes. Note that these control codes are not supported by
		/// the Handler function.
		/// </para>
		/// </summary>
		SERVICE_CONTROL_STOP = 0x00000001,

		/// <summary>
		/// Notifies a service of device events. (The service must have registered to receive these notifications using the
		/// RegisterDeviceNotification function.) The dwEventType and lpEventData parameters contain additional information.
		/// </summary>
		SERVICE_CONTROL_DEVICEEVENT = 0x0000000B,

		/// <summary>
		/// Notifies a service that the computer's hardware profile has changed. The dwEventType parameter contains additional information.
		/// </summary>
		SERVICE_CONTROL_HARDWAREPROFILECHANGE = 0x0000000C,

		/// <summary>
		/// Notifies a service of system power events. The dwEventType parameter contains additional information. If dwEventType is
		/// PBT_POWERSETTINGCHANGE, the lpEventData parameter also contains additional information.
		/// </summary>
		SERVICE_CONTROL_POWEREVENT = 0x0000000D,

		/// <summary>
		/// Notifies a service of session change events. Note that a service will only be notified of a user logon if it is fully loaded
		/// before the logon attempt is made. The dwEventType and lpEventData parameters contain additional information.
		/// </summary>
		SERVICE_CONTROL_SESSIONCHANGE = 0x0000000E,

		/// <summary>
		/// Notifies a service that the system time has changed. The lpEventData parameter contains additional information. The
		/// dwEventType parameter is not used.
		/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This control code is not supported.</para>
		/// </summary>
		SERVICE_CONTROL_TIMECHANGE = 0x00000010,

		/// <summary>
		/// Notifies a service registered for a service trigger event that the event has occurred.
		/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This control code is not supported.</para>
		/// </summary>
		SERVICE_CONTROL_TRIGGEREVENT = 0x00000020,

		/// <summary>
		/// Notifies a service that the user has initiated a reboot.
		/// <para>
		/// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This control code
		/// is not supported.
		/// </para>
		/// </summary>
		SERVICE_CONTROL_USERMODEREBOOT = 0x00000040,
	}

	/// <summary>Info levels for <see cref="ControlServiceEx"/></summary>
	public enum ServiceInfoLevels : uint
	{
		/// <summary/>
		[CorrespondingType(typeof(SERVICE_CONTROL_STATUS_REASON_PARAMS))]
		SERVICE_CONTROL_STATUS_REASON_INFO = 1
	}

	/// <summary/>
	[Flags]
	public enum ServiceStartReason : uint
	{
		/// <summary/>
		SERVICE_START_REASON_DEMAND = 1 << 0,
		/// <summary/>
		SERVICE_START_REASON_AUTO = 1 << 1,
		/// <summary/>
		SERVICE_START_REASON_TRIGGER = 1 << 2,
		/// <summary/>
		SERVICE_START_REASON_RESTART_ON_FAILURE = 1 << 3,
		/// <summary/>
		SERVICE_START_REASON_DELAYEDAUTO = 1 << 4,
	}

	/// <summary>The current state of the service.</summary>
	[PInvokeData("winsvc.h", MSDNShortId = "d268609b-d442-4d0f-9d49-ed23fee84961")]
	public enum ServiceState : uint
	{
		/// <summary>The service continue is pending.</summary>
		SERVICE_CONTINUE_PENDING = 0x00000005,

		/// <summary>The service pause is pending.</summary>
		SERVICE_PAUSE_PENDING = 0x00000006,

		/// <summary>The service is paused.</summary>
		SERVICE_PAUSED = 0x00000007,

		/// <summary>The service is running.</summary>
		SERVICE_RUNNING = 0x00000004,

		/// <summary>The service is starting.</summary>
		SERVICE_START_PENDING = 0x00000002,

		/// <summary>The service is stopping.</summary>
		SERVICE_STOP_PENDING = 0x00000003,

		/// <summary>The service is not running.</summary>
		SERVICE_STOPPED = 0x00000001,
	}

	/// <summary>Service trigger action types referenced by <see cref="SERVICE_TRIGGER"/>.</summary>
	[PInvokeData("winsvc.h", MSDNShortId = "a57aa702-40a2-4880-80db-6c4f43c3e7ea")]
	public enum ServiceTriggerAction : uint
	{
		/// <summary>Start the service when the specified trigger event occurs.</summary>
		SERVICE_TRIGGER_ACTION_SERVICE_START = 1,

		/// <summary>Stop the service when the specified trigger event occurs.</summary>
		SERVICE_TRIGGER_ACTION_SERVICE_STOP = 2,
	}

	/// <summary>The data type of the trigger-specific data pointed to by <c>pData</c> in <see cref="SERVICE_TRIGGER_SPECIFIC_DATA_ITEM"/>.</summary>
	[PInvokeData("winsvc.h", MSDNShortId = "670e6c49-bbc0-4af6-9e47-6c89801ebb45")]
	public enum ServiceTriggerDataType
	{
		/// <summary>The trigger-specific data is in binary format.</summary>
		SERVICE_TRIGGER_DATA_TYPE_BINARY = 1,

		/// <summary>The trigger-specific data is in string format.</summary>
		SERVICE_TRIGGER_DATA_TYPE_STRING = 2,

		/// <summary>The trigger-specific data is a byte value.</summary>
		SERVICE_TRIGGER_DATA_TYPE_LEVEL = 3,

		/// <summary>The trigger-specific data is a 64-bit unsigned integer value.</summary>
		SERVICE_TRIGGER_DATA_TYPE_KEYWORD_ANY = 4,

		/// <summary>The trigger-specific data is a 64-bit unsigned integer value.</summary>
		SERVICE_TRIGGER_DATA_TYPE_KEYWORD_ALL = 5,
	}

	/// <summary>Service trigger types referenced by <see cref="SERVICE_TRIGGER"/>.</summary>
	[PInvokeData("winsvc.h", MSDNShortId = "a57aa702-40a2-4880-80db-6c4f43c3e7ea")]
	public enum ServiceTriggerType
	{
		/// <summary>
		/// The event is triggered when a device of the specified device interface class arrives or is present when the system starts.
		/// This trigger event is commonly used to start a service. The pTriggerSubtype member specifies the device interface class GUID.
		/// These GUIDs are defined in device-specific header files provided with the Windows Driver Kit (WDK). The pDataItems member
		/// specifies one or more hardware ID and compatible ID strings for the device interface class. Strings must be Unicode. If more
		/// than one string is specified, the event is triggered if any one of the strings match. For example, the Wpdbusenum service is
		/// started when a device of device interface class GUID_DEVINTERFACE_DISK {53f56307-b6bf-11d0-94f2-00a0c91efb8b} and a hardware
		/// ID string of arrives.
		/// </summary>
		SERVICE_TRIGGER_TYPE_DEVICE_INTERFACE_ARRIVAL = 1,

		/// <summary>
		/// The event is triggered when the first IP address on the TCP/IP networking stack becomes available or the last IP address on
		/// the stack becomes unavailable. This trigger event can be used to start or stop a service. The pTriggerSubtype member
		/// specifies NETWORK_MANAGER_FIRST_IP_ADDRESS_ARRIVAL_GUID or NETWORK_MANAGER_LAST_IP_ADDRESS_REMOVAL_GUID. The pDataItems
		/// member is not used.
		/// </summary>
		SERVICE_TRIGGER_TYPE_IP_ADDRESS_AVAILABILITY = 2,

		/// <summary>
		/// The event is triggered when the computer joins or leaves a domain. This trigger event can be used to start or stop a service.
		/// The pTriggerSubtype member specifies DOMAIN_JOIN_GUID or DOMAIN_LEAVE_GUID. The pDataItems member is not used.
		/// </summary>
		SERVICE_TRIGGER_TYPE_DOMAIN_JOIN = 3,

		/// <summary>
		/// The event is triggered when a firewall port is opened or approximately 60 seconds after the firewall port is closed. This
		/// trigger event can be used to start or stop a service. The pTriggerSubtype member specifies FIREWALL_PORT_OPEN_GUID or
		/// FIREWALL_PORT_CLOSE_GUID. The pDataItems member specifies the port, the protocol, and optionally the executable path and user
		/// information (SID string or name) of the service listening on the event. The "RPC" token can be used in place of the port to
		/// specify any listening socket used by RPC. The "system" token can be used in place of the executable path to specify ports
		/// created by and listened on by the Windows kernel. The event is triggered only if all strings match. For example, if MyService
		/// hosted inside MyServiceProcess.exe is to be trigger-started when port UDP 5001 opens, the trigger-specific data would be the
		/// Unicode representation of .
		/// </summary>
		SERVICE_TRIGGER_TYPE_FIREWALL_PORT_EVENT = 4,

		/// <summary>
		/// The event is triggered when a machine policy or user policy change occurs. This trigger event is commonly used to start a
		/// service. The pTriggerSubtype member specifies MACHINE_POLICY_PRESENT_GUID or USER_POLICY_PRESENT_GUID. The pDataItems member
		/// is not used.
		/// </summary>
		SERVICE_TRIGGER_TYPE_GROUP_POLICY = 5,

		/// <summary>
		/// The event is triggered when a packet or request arrives on a particular network protocol. This request is commonly used to
		/// start a service that has stopped itself after an idle time-out when there is no work to do. Windows 7 and Windows Server 2008
		/// R2: This trigger type is not supported until Windows 8 and Windows Server 2012. The pTriggerSubtype member specifies one of
		/// the following values: RPC_INTERFACE_EVENT_GUID or NAMED_PIPE_EVENT_GUID. The pDataItems member specifies an endpoint or
		/// interface GUID. The string must be Unicode. The event triggers if the string is an exact match. The dwAction member must be SERVICE_TRIGGER_ACTION_SERVICE_START.
		/// </summary>
		SERVICE_TRIGGER_TYPE_NETWORK_ENDPOINT = 6,

		/// <summary>Undocumented.</summary>
		SERVICE_TRIGGER_TYPE_CUSTOM_SYSTEM_STATE_CHANGE = 7,

		/// <summary>
		/// The event is a custom event generated by an Event Tracing for Windows (ETW) provider. This trigger event can be used to start
		/// or stop a service. The pTriggerSubtype member specifies the event provider's GUID. The pDataItems member specifies
		/// trigger-specific data defined by the provider.
		/// </summary>
		SERVICE_TRIGGER_TYPE_CUSTOM = 20,

		/// <summary>Undocumented.</summary>
		SERVICE_TRIGGER_TYPE_AGGREGATE = 30,
	}

	/// <summary>Changes the configuration parameters of a service.</summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the OpenService or CreateService function and must have the
	/// SERVICE_CHANGE_CONFIG access right.
	/// </param>
	/// <param name="nServiceType">
	/// The type of service. Specify SERVICE_NO_CHANGE if you are not changing the existing service type. If you specify either
	/// SERVICE_WIN32_OWN_PROCESS or SERVICE_WIN32_SHARE_PROCESS, and the service is running in the context of the LocalSystem account,
	/// you can also specify SERVICE_INTERACTIVE_PROCESS.
	/// </param>
	/// <param name="nStartType">The service start options. Specify SERVICE_NO_CHANGE if you are not changing the existing start type.</param>
	/// <param name="nErrorControl">
	/// The severity of the error, and action taken, if this service fails to start. Specify SERVICE_NO_CHANGE if you are not changing
	/// the existing error control.
	/// </param>
	/// <param name="lpBinaryPathName">
	/// The fully qualified path to the service binary file. Specify NULL if you are not changing the existing path. If the path contains
	/// a space, it must be quoted so that it is correctly interpreted. For example, "d:\\my share\\myservice.exe" should be specified as
	/// "\"d:\\my share\\myservice.exe\"".
	/// <para>
	/// The path can also include arguments for an auto-start service. For example, "d:\\myshare\\myservice.exe arg1 arg2". These
	/// arguments are passed to the service entry point (typically the main function).
	/// </para>
	/// <para>
	/// If you specify a path on another computer, the share must be accessible by the computer account of the local computer because
	/// this is the security context used in the remote call. However, this requirement allows any potential vulnerabilities in the
	/// remote computer to affect the local computer. Therefore, it is best to use a local file.
	/// </para>
	/// </param>
	/// <param name="lpLoadOrderGroup">
	/// The name of the load ordering group of which this service is a member. Specify NULL if you are not changing the existing group.
	/// Specify an empty string if the service does not belong to a group.
	/// <para>
	/// The startup program uses load ordering groups to load groups of services in a specified order with respect to the other groups.
	/// The list of load ordering groups is contained in the ServiceGroupOrder value of the following registry key:
	/// </para>
	/// <para>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control</para>
	/// </param>
	/// <param name="lpdwTagId">
	/// A pointer to a variable that receives a tag value that is unique in the group specified in the lpLoadOrderGroup parameter.
	/// Specify NULL if you are not changing the existing tag.
	/// <para>
	/// You can use a tag for ordering service startup within a load ordering group by specifying a tag order vector in the
	/// GroupOrderList value of the following registry key:
	/// </para>
	/// <para>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control</para>
	/// <para>Tags are only evaluated for driver services that have SERVICE_BOOT_START or SERVICE_SYSTEM_START start types.</para>
	/// </param>
	/// <param name="lpDependencies">
	/// A pointer to a double null-terminated array of null-separated names of services or load ordering groups that the system must
	/// start before this service can be started. (Dependency on a group means that this service can run if at least one member of the
	/// group is running after an attempt to start all members of the group.) Specify NULL if you are not changing the existing
	/// dependencies. Specify an empty string if the service has no dependencies.
	/// <para>
	/// You must prefix group names with SC_GROUP_IDENTIFIER so that they can be distinguished from a service name, because services and
	/// service groups share the same name space.
	/// </para>
	/// </param>
	/// <param name="lpServiceStartName">
	/// The name of the account under which the service should run. Specify NULL if you are not changing the existing account name. If
	/// the service type is SERVICE_WIN32_OWN_PROCESS, use an account name in the form DomainName\UserName. The service process will be
	/// logged on as this user. If the account belongs to the built-in domain, you can specify .\UserName (note that the corresponding
	/// C/C++ string is ".\\UserName"). For more information, see Service User Accounts and the warning in the Remarks section.
	/// <para>A shared process can run as any user.</para>
	/// <para>
	/// If the service type is SERVICE_KERNEL_DRIVER or SERVICE_FILE_SYSTEM_DRIVER, the name is the driver object name that the system
	/// uses to load the device driver. Specify NULL if the driver is to use a default object name created by the I/O system.
	/// </para>
	/// <para>
	/// A service can be configured to use a managed account or a virtual account. If the service is configured to use a managed service
	/// account, the name is the managed service account name. If the service is configured to use a virtual account, specify the name as
	/// NT SERVICE\ServiceName. For more information about managed service accounts and virtual accounts, see the Service Accounts
	/// Step-by-Step Guide.
	/// </para>
	/// <para>
	/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: Managed service accounts and virtual accounts are not
	/// supported until Windows 7 and Windows Server 2008 R2.
	/// </para>
	/// </param>
	/// <param name="lpPassword">
	/// The password to the account name specified by the lpServiceStartName parameter. Specify NULL if you are not changing the existing
	/// password. Specify an empty string if the account has no password or if the service runs in the LocalService, NetworkService, or
	/// LocalSystem account. For more information, see Service Record List.
	/// <para>
	/// If the account name specified by the lpServiceStartName parameter is the name of a managed service account or virtual account
	/// name, the lpPassword parameter must be NULL.
	/// </para>
	/// <para>Passwords are ignored for driver services.</para>
	/// </param>
	/// <param name="lpDisplayName">
	/// The display name to be used by applications to identify the service for its users. Specify NULL if you are not changing the
	/// existing display name; otherwise, this string has a maximum length of 256 characters. The name is case-preserved in the service
	/// control manager. Display name comparisons are always case-insensitive.
	/// <para>This parameter can specify a localized string using the following format:</para>
	/// <para>@[path\]dllname,-strID</para>
	/// <para>The string with identifier strID is loaded from dllname; the path is optional. For more information, see RegLoadMUIString.</para>
	/// <para>Windows Server 2003 and Windows XP: Localized strings are not supported until Windows Vista.</para>
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error
	/// information, call GetLastError.
	/// </returns>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("winsvc.h", MSDNShortId = "ms681987")]
	public static extern bool ChangeServiceConfig(SC_HANDLE hService, ServiceTypes nServiceType, ServiceStartType nStartType, ServiceErrorControlType nErrorControl,
		[Optional] string? lpBinaryPathName, [Optional] string? lpLoadOrderGroup, out uint lpdwTagId,
		[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")] string[]? lpDependencies,
		[Optional] string? lpServiceStartName, [Optional] string? lpPassword, [Optional] string? lpDisplayName);

	/// <summary>Changes the configuration parameters of a service.</summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the OpenService or CreateService function and must have the
	/// SERVICE_CHANGE_CONFIG access right.
	/// </param>
	/// <param name="nServiceType">
	/// The type of service. Specify SERVICE_NO_CHANGE if you are not changing the existing service type. If you specify either
	/// SERVICE_WIN32_OWN_PROCESS or SERVICE_WIN32_SHARE_PROCESS, and the service is running in the context of the LocalSystem account,
	/// you can also specify SERVICE_INTERACTIVE_PROCESS.
	/// </param>
	/// <param name="nStartType">The service start options. Specify SERVICE_NO_CHANGE if you are not changing the existing start type.</param>
	/// <param name="nErrorControl">
	/// The severity of the error, and action taken, if this service fails to start. Specify SERVICE_NO_CHANGE if you are not changing
	/// the existing error control.
	/// </param>
	/// <param name="lpBinaryPathName">
	/// The fully qualified path to the service binary file. Specify NULL if you are not changing the existing path. If the path contains
	/// a space, it must be quoted so that it is correctly interpreted. For example, "d:\\my share\\myservice.exe" should be specified as
	/// "\"d:\\my share\\myservice.exe\"".
	/// <para>
	/// The path can also include arguments for an auto-start service. For example, "d:\\myshare\\myservice.exe arg1 arg2". These
	/// arguments are passed to the service entry point (typically the main function).
	/// </para>
	/// <para>
	/// If you specify a path on another computer, the share must be accessible by the computer account of the local computer because
	/// this is the security context used in the remote call. However, this requirement allows any potential vulnerabilities in the
	/// remote computer to affect the local computer. Therefore, it is best to use a local file.
	/// </para>
	/// </param>
	/// <param name="lpLoadOrderGroup">
	/// The name of the load ordering group of which this service is a member. Specify NULL if you are not changing the existing group.
	/// Specify an empty string if the service does not belong to a group.
	/// <para>
	/// The startup program uses load ordering groups to load groups of services in a specified order with respect to the other groups.
	/// The list of load ordering groups is contained in the ServiceGroupOrder value of the following registry key:
	/// </para>
	/// <para>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control</para>
	/// </param>
	/// <param name="lpdwTagId">
	/// A pointer to a variable that receives a tag value that is unique in the group specified in the lpLoadOrderGroup parameter.
	/// Specify NULL if you are not changing the existing tag.
	/// <para>
	/// You can use a tag for ordering service startup within a load ordering group by specifying a tag order vector in the
	/// GroupOrderList value of the following registry key:
	/// </para>
	/// <para>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control</para>
	/// <para>Tags are only evaluated for driver services that have SERVICE_BOOT_START or SERVICE_SYSTEM_START start types.</para>
	/// </param>
	/// <param name="lpDependencies">
	/// A pointer to a double null-terminated array of null-separated names of services or load ordering groups that the system must
	/// start before this service can be started. (Dependency on a group means that this service can run if at least one member of the
	/// group is running after an attempt to start all members of the group.) Specify NULL if you are not changing the existing
	/// dependencies. Specify an empty string if the service has no dependencies.
	/// <para>
	/// You must prefix group names with SC_GROUP_IDENTIFIER so that they can be distinguished from a service name, because services and
	/// service groups share the same name space.
	/// </para>
	/// </param>
	/// <param name="lpServiceStartName">
	/// The name of the account under which the service should run. Specify NULL if you are not changing the existing account name. If
	/// the service type is SERVICE_WIN32_OWN_PROCESS, use an account name in the form DomainName\UserName. The service process will be
	/// logged on as this user. If the account belongs to the built-in domain, you can specify .\UserName (note that the corresponding
	/// C/C++ string is ".\\UserName"). For more information, see Service User Accounts and the warning in the Remarks section.
	/// <para>A shared process can run as any user.</para>
	/// <para>
	/// If the service type is SERVICE_KERNEL_DRIVER or SERVICE_FILE_SYSTEM_DRIVER, the name is the driver object name that the system
	/// uses to load the device driver. Specify NULL if the driver is to use a default object name created by the I/O system.
	/// </para>
	/// <para>
	/// A service can be configured to use a managed account or a virtual account. If the service is configured to use a managed service
	/// account, the name is the managed service account name. If the service is configured to use a virtual account, specify the name as
	/// NT SERVICE\ServiceName. For more information about managed service accounts and virtual accounts, see the Service Accounts
	/// Step-by-Step Guide.
	/// </para>
	/// <para>
	/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: Managed service accounts and virtual accounts are not
	/// supported until Windows 7 and Windows Server 2008 R2.
	/// </para>
	/// </param>
	/// <param name="lpPassword">
	/// The password to the account name specified by the lpServiceStartName parameter. Specify NULL if you are not changing the existing
	/// password. Specify an empty string if the account has no password or if the service runs in the LocalService, NetworkService, or
	/// LocalSystem account. For more information, see Service Record List.
	/// <para>
	/// If the account name specified by the lpServiceStartName parameter is the name of a managed service account or virtual account
	/// name, the lpPassword parameter must be NULL.
	/// </para>
	/// <para>Passwords are ignored for driver services.</para>
	/// </param>
	/// <param name="lpDisplayName">
	/// The display name to be used by applications to identify the service for its users. Specify NULL if you are not changing the
	/// existing display name; otherwise, this string has a maximum length of 256 characters. The name is case-preserved in the service
	/// control manager. Display name comparisons are always case-insensitive.
	/// <para>This parameter can specify a localized string using the following format:</para>
	/// <para>@[path\]dllname,-strID</para>
	/// <para>The string with identifier strID is loaded from dllname; the path is optional. For more information, see RegLoadMUIString.</para>
	/// <para>Windows Server 2003 and Windows XP: Localized strings are not supported until Windows Vista.</para>
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error
	/// information, call GetLastError.
	/// </returns>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("winsvc.h", MSDNShortId = "ms681987")]
	public static extern bool ChangeServiceConfig(SC_HANDLE hService, ServiceTypes nServiceType, ServiceStartType nStartType, ServiceErrorControlType nErrorControl,
		[Optional] string? lpBinaryPathName, [Optional] string? lpLoadOrderGroup, [Optional] IntPtr lpdwTagId,
		[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")] string[]? lpDependencies,
		[Optional] string? lpServiceStartName, [Optional] string? lpPassword, [Optional] string? lpDisplayName);

	/// <summary>Changes the optional configuration parameters of a service.</summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the OpenService or CreateService function and must have the
	/// SERVICE_CHANGE_CONFIG access right.
	/// </param>
	/// <param name="dwInfoLevel">The configuration information to be changed.</param>
	/// <param name="lpInfo">
	/// A pointer to the new value to be set for the configuration information. The format of this data depends on the value of the
	/// dwInfoLevel parameter. If this value is NULL, the information remains unchanged.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
	/// information, call GetLastError.
	/// </returns>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("winsvc.h", MSDNShortId = "ms681988")]
	public static extern bool ChangeServiceConfig2(SC_HANDLE hService, ServiceConfigOption dwInfoLevel, [Optional] IntPtr lpInfo);

	/// <summary>Changes the optional configuration parameters of a service.</summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the OpenService or CreateService function and must have the
	/// SERVICE_CHANGE_CONFIG access right.
	/// </param>
	/// <param name="dwInfoLevel">The configuration information to be changed.</param>
	/// <param name="lpInfo">
	/// The new value to be set for the configuration information. The format of this data depends on the value of the dwInfoLevel
	/// parameter. If this value is NULL, the information remains unchanged.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
	/// information, call GetLastError.
	/// </returns>
	[PInvokeData("winsvc.h", MSDNShortId = "ms681988")]
	public static bool ChangeServiceConfig2<T>(SC_HANDLE hService, ServiceConfigOption dwInfoLevel, in T lpInfo) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanSet(dwInfoLevel, typeof(T))) throw new ArgumentException("Type mismatch", nameof(lpInfo));
		using var ptr = SafeCoTaskMemHandle.CreateFromStructure(lpInfo);
		return ChangeServiceConfig2(hService, dwInfoLevel, ptr.DangerousGetHandle());
	}

	/// <summary>
	/// <para>Closes a handle to a service control manager or service object.</para>
	/// </summary>
	/// <param name="hSCObject">
	/// <para>
	/// A handle to the service control manager object or the service object to close. Handles to service control manager objects are
	/// returned by the OpenSCManager function, and handles to service objects are returned by either the OpenService or CreateService function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error code can be set by the service control manager. Other error codes can be set by registry functions that are
	/// called by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CloseServiceHandle</c> function does not destroy the service control manager object referred to by the handle. A service
	/// control manager object cannot be destroyed. A service object can be destroyed by calling the DeleteService function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Deleting a Service.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-closeservicehandle BOOL CloseServiceHandle( SC_HANDLE
	// hSCObject );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsvc.h", MSDNShortId = "6cf25994-4939-4aff-af38-5ffc8fc606ae")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseServiceHandle(SC_HANDLE hSCObject);

	/// <summary>
	/// <para>Sends a control code to a service.</para>
	/// <para>To specify additional information when stopping a service, use the ControlServiceEx function.</para>
	/// </summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the OpenService or CreateService function. The access rights required for
	/// this handle depend on the dwControl code requested.
	/// </param>
	/// <param name="dwControl">
	/// <para>This parameter can be one of the following control codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Control code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_CONTROL_CONTINUE 0x00000003</term>
	/// <term>Notifies a paused service that it should resume. The hService handle must have the SERVICE_PAUSE_CONTINUE access right.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_INTERROGATE 0x00000004</term>
	/// <term>
	/// Notifies a service that it should report its current status information to the service control manager. The hService handle must
	/// have the SERVICE_INTERROGATE access right. Note that this control is not generally useful as the SCM is aware of the current
	/// state of the service.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_NETBINDADD 0x00000007</term>
	/// <term>
	/// Notifies a network service that there is a new component for binding. The hService handle must have the SERVICE_PAUSE_CONTINUE
	/// access right. However, this control code has been deprecated; use Plug and Play functionality instead.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_NETBINDDISABLE 0x0000000A</term>
	/// <term>
	/// Notifies a network service that one of its bindings has been disabled. The hService handle must have the SERVICE_PAUSE_CONTINUE
	/// access right. However, this control code has been deprecated; use Plug and Play functionality instead.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_NETBINDENABLE 0x00000009</term>
	/// <term>
	/// Notifies a network service that a disabled binding has been enabled. The hService handle must have the SERVICE_PAUSE_CONTINUE
	/// access right. However, this control code has been deprecated; use Plug and Play functionality instead.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_NETBINDREMOVE 0x00000008</term>
	/// <term>
	/// Notifies a network service that a component for binding has been removed. The hService handle must have the
	/// SERVICE_PAUSE_CONTINUE access right. However, this control code has been deprecated; use Plug and Play functionality instead.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_PARAMCHANGE 0x00000006</term>
	/// <term>
	/// Notifies a service that its startup parameters have changed. The hService handle must have the SERVICE_PAUSE_CONTINUE access right.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_PAUSE 0x00000002</term>
	/// <term>Notifies a service that it should pause. The hService handle must have the SERVICE_PAUSE_CONTINUE access right.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_STOP 0x00000001</term>
	/// <term>
	/// Notifies a service that it should stop. The hService handle must have the SERVICE_STOP access right. After sending the stop
	/// request to a service, you should not send other controls to the service.
	/// </term>
	/// </item>
	/// </list>
	/// <para>This value can also be a user-defined control code, as described in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Control code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>Range 128 to 255</term>
	/// <term>
	/// The service defines the action associated with the control code. The hService handle must have the SERVICE_USER_DEFINED_CONTROL
	/// access right.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpServiceStatus">
	/// <para>
	/// A pointer to a SERVICE_STATUS structure that receives the latest service status information. The information returned reflects
	/// the most recent status that the service reported to the service control manager.
	/// </para>
	/// <para>
	/// The service control manager fills in the structure only when <c>ControlService</c> returns one of the following error codes:
	/// <c>NO_ERROR</c>, <c>ERROR_INVALID_SERVICE_CONTROL</c>, <c>ERROR_SERVICE_CANNOT_ACCEPT_CTRL</c>, or
	/// <c>ERROR_SERVICE_NOT_ACTIVE</c>. Otherwise, the structure is not filled in.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the service control manager. Other error codes can be set by the registry functions that
	/// are called by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle does not have the required access right.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEPENDENT_SERVICES_RUNNING</term>
	/// <term>The service cannot be stopped because other running services are dependent on it.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle was not obtained using CreateService or OpenService, or the handle is no longer valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The requested control code is undefined.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_SERVICE_CONTROL</term>
	/// <term>The requested control code is not valid, or it is unacceptable to the service.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_CANNOT_ACCEPT_CTRL</term>
	/// <term>
	/// The requested control code cannot be sent to the service because the state of the service is SERVICE_STOPPED,
	/// SERVICE_START_PENDING, or SERVICE_STOP_PENDING.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_REQUEST_TIMEOUT</term>
	/// <term>
	/// The process for the service was started, but it did not call StartServiceCtrlDispatcher, or the thread that called
	/// StartServiceCtrlDispatcher may be blocked in a control handler function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SHUTDOWN_IN_PROGRESS</term>
	/// <term>The system is shutting down.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ControlService</c> function asks the Service Control Manager (SCM) to send the requested control code to the service. The
	/// SCM sends the code if the service has specified that it will accept the code, and is in a state in which a control code can be
	/// sent to it.
	/// </para>
	/// <para>
	/// The SCM processes service control notifications in a serial fashion—it will wait for one service to complete processing a service
	/// control notification before sending the next one. Because of this, a call to <c>ControlService</c> will block for 30 seconds if
	/// any service is busy handling a control code. If the busy service still has not returned from its handler function when the
	/// timeout expires, <c>ControlService</c> fails with <c>ERROR_SERVICE_REQUEST_TIMEOUT</c>.
	/// </para>
	/// <para>
	/// To stop and start a service requires a security descriptor that allows you to do so. The default security descriptor allows the
	/// LocalSystem account, and members of the Administrators and Power Users groups to stop and start services. To change the security
	/// descriptor of a service, see Modifying the DACL for a Service.
	/// </para>
	/// <para>
	/// The QueryServiceStatusEx function returns a SERVICE_STATUS_PROCESS structure whose <c>dwCurrentState</c> and
	/// <c>dwControlsAccepted</c> members indicate the current state and controls accepted by a running service. All running services
	/// accept the <c>SERVICE_CONTROL_INTERROGATE</c> control code by default. Drivers do not accept control codes other than
	/// <c>SERVICE_CONTROL_STOP</c> and <c>SERVICE_CONTROL_INTERROGATE</c>. Each service specifies the other control codes that it
	/// accepts when it calls the SetServiceStatus function to report its status. A service should always accept these codes when it is
	/// running, no matter what it is doing.
	/// </para>
	/// <para>The following table shows the action of the SCM in each of the possible service states.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Service state</term>
	/// <term>Stop</term>
	/// <term>Other controls</term>
	/// </listheader>
	/// <item>
	/// <term>STOPPED</term>
	/// <term>(c)</term>
	/// <term>(c)</term>
	/// </item>
	/// <item>
	/// <term>STOP_PENDING</term>
	/// <term>(b)</term>
	/// <term>(b)</term>
	/// </item>
	/// <item>
	/// <term>START_PENDING</term>
	/// <term>(a)</term>
	/// <term>(b)</term>
	/// </item>
	/// <item>
	/// <term>RUNNING</term>
	/// <term>(a)</term>
	/// <term>(a)</term>
	/// </item>
	/// <item>
	/// <term>CONTINUE_PENDING</term>
	/// <term>(a)</term>
	/// <term>(a)</term>
	/// </item>
	/// <item>
	/// <term>PAUSE_PENDING</term>
	/// <term>(a)</term>
	/// <term>(a)</term>
	/// </item>
	/// <item>
	/// <term>PAUSED</term>
	/// <term>(a)</term>
	/// <term>(a)</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example, see Stopping a Service.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-controlservice BOOL ControlService( SC_HANDLE hService,
	// DWORD dwControl, LPSERVICE_STATUS lpServiceStatus );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsvc.h", MSDNShortId = "c112b587-7455-4f15-93e1-ded73de6dbbd")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ControlService(SC_HANDLE hService, ServiceControl dwControl, out SERVICE_STATUS lpServiceStatus);

	/// <summary>Sends a control code to a service.</summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the OpenService or CreateService function. The access rights required for
	/// this handle depend on the dwControl code requested.
	/// </param>
	/// <param name="dwControl">
	/// <para>This parameter can be one of the following control codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Control code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_CONTROL_CONTINUE 0x00000003</term>
	/// <term>Notifies a paused service that it should resume. The hService handle must have the SERVICE_PAUSE_CONTINUE access right.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_INTERROGATE 0x00000004</term>
	/// <term>
	/// Notifies a service that it should report its current status information to the service control manager. The hService handle must
	/// have the SERVICE_INTERROGATE access right. Note that this control is not generally useful as the SCM is aware of the current
	/// state of the service.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_NETBINDADD 0x00000007</term>
	/// <term>
	/// Notifies a network service that there is a new component for binding. The hService handle must have the SERVICE_PAUSE_CONTINUE
	/// access right. However, this control code has been deprecated; use Plug and Play functionality instead.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_NETBINDDISABLE 0x0000000A</term>
	/// <term>
	/// Notifies a network service that one of its bindings has been disabled. The hService handle must have the SERVICE_PAUSE_CONTINUE
	/// access right. However, this control code has been deprecated; use Plug and Play functionality instead.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_NETBINDENABLE 0x00000009</term>
	/// <term>
	/// Notifies a network service that a disabled binding has been enabled. The hService handle must have the SERVICE_PAUSE_CONTINUE
	/// access right. However, this control code has been deprecated; use Plug and Play functionality instead.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_NETBINDREMOVE 0x00000008</term>
	/// <term>
	/// Notifies a network service that a component for binding has been removed. The hService handle must have the
	/// SERVICE_PAUSE_CONTINUE access right. However, this control code has been deprecated; use Plug and Play functionality instead.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_PARAMCHANGE 0x00000006</term>
	/// <term>
	/// Notifies a service that its startup parameters have changed. The hService handle must have the SERVICE_PAUSE_CONTINUE access right.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_PAUSE 0x00000002</term>
	/// <term>Notifies a service that it should pause. The hService handle must have the SERVICE_PAUSE_CONTINUE access right.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONTROL_STOP 0x00000001</term>
	/// <term>
	/// Notifies a service that it should stop. The hService handle must have the SERVICE_STOP access right. After sending the stop
	/// request to a service, you should not send other controls to the service.
	/// </term>
	/// </item>
	/// </list>
	/// <para>This parameter can also be a user-defined control code, as described in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Control code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>Range 128 to 255</term>
	/// <term>
	/// The service defines the action associated with the control code. The hService handle must have the SERVICE_USER_DEFINED_CONTROL
	/// access right.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwInfoLevel">
	/// The information level for the service control parameters. This parameter must be set to SERVICE_CONTROL_STATUS_REASON_INFO (1).
	/// </param>
	/// <param name="pControlParams">
	/// A pointer to the service control parameters. If dwInfoLevel is SERVICE_CONTROL_STATUS_REASON_INFO, this member is a pointer to a
	/// SERVICE_CONTROL_STATUS_REASON_PARAMS structure.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the service control manager. Other error codes can be set by the registry functions that
	/// are called by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle does not have the required access right.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEPENDENT_SERVICES_RUNNING</term>
	/// <term>The service cannot be stopped because other running services are dependent on it.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle was not obtained using CreateService or OpenService, or the handle is no longer valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// The requested control code in the dwControl parameter is undefined, or dwControl is SERVICE_CONTROL_STOP but the dwReason or
	/// pszComment members of the SERVICE_CONTROL_STATUS_REASON_PARAMS structure are not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_SERVICE_CONTROL</term>
	/// <term>The requested control code is not valid, or it is unacceptable to the service.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_CANNOT_ACCEPT_CTRL</term>
	/// <term>
	/// The requested control code cannot be sent to the service because the state of the service is SERVICE_STOPPED,
	/// SERVICE_START_PENDING, or SERVICE_STOP_PENDING.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_REQUEST_TIMEOUT</term>
	/// <term>
	/// The process for the service was started, but it did not call StartServiceCtrlDispatcher, or the thread that called
	/// StartServiceCtrlDispatcher may be blocked in a control handler function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SHUTDOWN_IN_PROGRESS</term>
	/// <term>The system is shutting down.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ControlServiceEx</c> function asks the Service Control Manager (SCM) to send the requested control code to the service.
	/// The SCM sends the code if the service has specified that it will accept the code, and is in a state in which a control code can
	/// be sent to it.
	/// </para>
	/// <para>
	/// The SCM processes service control notifications in a serial fashion — it waits for one service to complete processing a service
	/// control notification before sending the next one. Because of this, a call to <c>ControlServiceEx</c> blocks for 30 seconds if any
	/// service is busy handling a control code. If the busy service still has not returned from its handler function when the timeout
	/// expires, <c>ControlServiceEx</c> fails with ERROR_SERVICE_REQUEST_TIMEOUT.
	/// </para>
	/// <para>
	/// To stop and start a service requires a security descriptor that allows you to do so. The default security descriptor allows the
	/// LocalSystem account, and members of the Administrators and Power Users groups to stop and start services. To change the security
	/// descriptor of a service, see Modifying the DACL for a Service.
	/// </para>
	/// <para>
	/// The QueryServiceStatusEx function returns a SERVICE_STATUS_PROCESS structure whose <c>dwCurrentState</c> and
	/// <c>dwControlsAccepted</c> members indicate the current state and controls accepted by a running service. All running services
	/// accept the SERVICE_CONTROL_INTERROGATE control code by default. Drivers do not accept control codes other than
	/// SERVICE_CONTROL_STOP and SERVICE_CONTROL_INTERROGATE. Each service specifies the other control codes that it accepts when it
	/// calls the SetServiceStatus function to report its status. A service should always accept these codes when it is running, no
	/// matter what it is doing.
	/// </para>
	/// <para>The following table shows the action of the SCM in each of the possible service states.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Service state</term>
	/// <term>Stop</term>
	/// <term>Other controls</term>
	/// </listheader>
	/// <item>
	/// <term>STOPPED</term>
	/// <term>(c)</term>
	/// <term>(c)</term>
	/// </item>
	/// <item>
	/// <term>STOP_PENDING</term>
	/// <term>(b)</term>
	/// <term>(b)</term>
	/// </item>
	/// <item>
	/// <term>START_PENDING</term>
	/// <term>(a)</term>
	/// <term>(b)</term>
	/// </item>
	/// <item>
	/// <term>RUNNING</term>
	/// <term>(a)</term>
	/// <term>(a)</term>
	/// </item>
	/// <item>
	/// <term>CONTINUE_PENDING</term>
	/// <term>(a)</term>
	/// <term>(a)</term>
	/// </item>
	/// <item>
	/// <term>PAUSE_PENDING</term>
	/// <term>(a)</term>
	/// <term>(a)</term>
	/// </item>
	/// <item>
	/// <term>PAUSED</term>
	/// <term>(a)</term>
	/// <term>(a)</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-controlserviceexa BOOL ControlServiceExA( SC_HANDLE
	// hService, DWORD dwControl, DWORD dwInfoLevel, PVOID pControlParams );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "de249903-7545-4fb6-925a-aa647f862f93")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ControlServiceEx(SC_HANDLE hService, ServiceControl dwControl, ServiceInfoLevels dwInfoLevel, ref SERVICE_CONTROL_STATUS_REASON_PARAMS pControlParams);

	/// <summary>
	/// <para>Creates a service object and adds it to the specified service control manager database.</para>
	/// </summary>
	/// <param name="hSCManager">
	/// <para>
	/// A handle to the service control manager database. This handle is returned by the OpenSCManager function and must have the
	/// <c>SC_MANAGER_CREATE_SERVICE</c> access right. For more information, see Service Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="lpServiceName">
	/// <para>
	/// The name of the service to install. The maximum string length is 256 characters. The service control manager database preserves
	/// the case of the characters, but service name comparisons are always case insensitive. Forward-slash (/) and backslash () are not
	/// valid service name characters.
	/// </para>
	/// </param>
	/// <param name="lpDisplayName">
	/// <para>
	/// The display name to be used by user interface programs to identify the service. This string has a maximum length of 256
	/// characters. The name is case-preserved in the service control manager. Display name comparisons are always case-insensitive.
	/// </para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>
	/// The access to the service. Before granting the requested access, the system checks the access token of the calling process. For a
	/// list of values, see Service Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="dwServiceType">
	/// <para>The service type. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_ADAPTER 0x00000004</term>
	/// <term>Reserved.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_FILE_SYSTEM_DRIVER 0x00000002</term>
	/// <term>File system driver service.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_KERNEL_DRIVER 0x00000001</term>
	/// <term>Driver service.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_RECOGNIZER_DRIVER 0x00000008</term>
	/// <term>Reserved.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_WIN32_OWN_PROCESS 0x00000010</term>
	/// <term>Service that runs in its own process.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_WIN32_SHARE_PROCESS 0x00000020</term>
	/// <term>Service that shares a process with one or more other services. For more information, see Service Programs.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_USER_OWN_PROCESS 0x00000050</term>
	/// <term>The service runs in its own process under the logged-on user account.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_USER_SHARE_PROCESS 0x00000060</term>
	/// <term>The service shares a process with one or more other services that run under the logged-on user account.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If you specify either <c>SERVICE_WIN32_OWN_PROCESS</c> or <c>SERVICE_WIN32_SHARE_PROCESS</c>, and the service is running in the
	/// context of the LocalSystem account, you can also specify the following value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_INTERACTIVE_PROCESS 0x00000100</term>
	/// <term>The service can interact with the desktop. For more information, see Interactive Services.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwStartType">
	/// <para>The service start options. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_AUTO_START 0x00000002</term>
	/// <term>
	/// A service started automatically by the service control manager during system startup. For more information, see Automatically
	/// Starting Services.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_BOOT_START 0x00000000</term>
	/// <term>A device driver started by the system loader. This value is valid only for driver services.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_DEMAND_START 0x00000003</term>
	/// <term>
	/// A service started by the service control manager when a process calls the StartService function. For more information, see
	/// Starting Services on Demand.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_DISABLED 0x00000004</term>
	/// <term>A service that cannot be started. Attempts to start the service result in the error code ERROR_SERVICE_DISABLED.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_SYSTEM_START 0x00000001</term>
	/// <term>A device driver started by the IoInitSystem function. This value is valid only for driver services.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwErrorControl">
	/// <para>
	/// The severity of the error, and action taken, if this service fails to start. This parameter can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_ERROR_CRITICAL 0x00000003</term>
	/// <term>
	/// The startup program logs the error in the event log, if possible. If the last-known-good configuration is being started, the
	/// startup operation fails. Otherwise, the system is restarted with the last-known good configuration.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_ERROR_IGNORE 0x00000000</term>
	/// <term>The startup program ignores the error and continues the startup operation.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_ERROR_NORMAL 0x00000001</term>
	/// <term>The startup program logs the error in the event log but continues the startup operation.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_ERROR_SEVERE 0x00000002</term>
	/// <term>
	/// The startup program logs the error in the event log. If the last-known-good configuration is being started, the startup operation
	/// continues. Otherwise, the system is restarted with the last-known-good configuration.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpBinaryPathName">
	/// <para>
	/// The fully qualified path to the service binary file. If the path contains a space, it must be quoted so that it is correctly
	/// interpreted. For example, "d:\my share\myservice.exe" should be specified as ""d:\my share\myservice.exe"".
	/// </para>
	/// <para>
	/// The path can also include arguments for an auto-start service. For example, "d:\myshare\myservice.exe arg1 arg2". These arguments
	/// are passed to the service entry point (typically the <c>main</c> function).
	/// </para>
	/// <para>
	/// If you specify a path on another computer, the share must be accessible by the computer account of the local computer because
	/// this is the security context used in the remote call. However, this requirement allows any potential vulnerabilities in the
	/// remote computer to affect the local computer. Therefore, it is best to use a local file.
	/// </para>
	/// </param>
	/// <param name="lpLoadOrderGroup">
	/// <para>
	/// The names of the load ordering group of which this service is a member. Specify NULL or an empty string if the service does not
	/// belong to a group.
	/// </para>
	/// <para>
	/// The startup program uses load ordering groups to load groups of services in a specified order with respect to the other groups.
	/// The list of load ordering groups is contained in the following registry value: <c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control</c>&lt;b&gt;ServiceGroupOrder
	/// </para>
	/// </param>
	/// <param name="lpdwTagId">
	/// <para>
	/// A pointer to a variable that receives a tag value that is unique in the group specified in the lpLoadOrderGroup parameter.
	/// Specify NULL if you are not changing the existing tag.
	/// </para>
	/// <para>
	/// You can use a tag for ordering service startup within a load ordering group by specifying a tag order vector in the following
	/// registry value: <c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control</c>&lt;b&gt;GroupOrderList
	/// </para>
	/// <para>Tags are only evaluated for driver services that have <c>SERVICE_BOOT_START</c> or <c>SERVICE_SYSTEM_START</c> start types.</para>
	/// </param>
	/// <param name="lpDependencies">
	/// <para>
	/// A pointer to a double null-terminated array of null-separated names of services or load ordering groups that the system must
	/// start before this service. Specify NULL or an empty string if the service has no dependencies. Dependency on a group means that
	/// this service can run if at least one member of the group is running after an attempt to start all members of the group.
	/// </para>
	/// <para>
	/// You must prefix group names with <c>SC_GROUP_IDENTIFIER</c> so that they can be distinguished from a service name, because
	/// services and service groups share the same name space.
	/// </para>
	/// </param>
	/// <param name="lpServiceStartName">
	/// <para>
	/// The name of the account under which the service should run. If the service type is SERVICE_WIN32_OWN_PROCESS, use an account name
	/// in the form DomainName&lt;i&gt;UserName. The service process will be logged on as this user. If the account belongs to the
	/// built-in domain, you can specify .&lt;i&gt;UserName.
	/// </para>
	/// <para>
	/// If this parameter is NULL, <c>CreateService</c> uses the LocalSystem account. If the service type specifies
	/// <c>SERVICE_INTERACTIVE_PROCESS</c>, the service must run in the LocalSystem account.
	/// </para>
	/// <para>
	/// If this parameter is NT AUTHORITY\LocalService, <c>CreateService</c> uses the LocalService account. If the parameter is NT
	/// AUTHORITY\NetworkService, <c>CreateService</c> uses the NetworkService account.
	/// </para>
	/// <para>A shared process can run as any user.</para>
	/// <para>
	/// If the service type is <c>SERVICE_KERNEL_DRIVER</c> or <c>SERVICE_FILE_SYSTEM_DRIVER</c>, the name is the driver object name that
	/// the system uses to load the device driver. Specify NULL if the driver is to use a default object name created by the I/O system.
	/// </para>
	/// <para>
	/// A service can be configured to use a managed account or a virtual account. If the service is configured to use a managed service
	/// account, the name is the managed service account name. If the service is configured to use a virtual account, specify the name as
	/// NT SERVICE&lt;i&gt;ServiceName. For more information about managed service accounts and virtual accounts, see the Service
	/// Accounts Step-by-Step Guide.
	/// </para>
	/// <para>
	/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> Managed service accounts and virtual accounts are
	/// not supported until Windows 7 and Windows Server 2008 R2.
	/// </para>
	/// </param>
	/// <param name="lpPassword">
	/// <para>
	/// The password to the account name specified by the lpServiceStartName parameter. Specify an empty string if the account has no
	/// password or if the service runs in the LocalService, NetworkService, or LocalSystem account. For more information, see Service
	/// Record List.
	/// </para>
	/// <para>
	/// If the account name specified by the lpServiceStartName parameter is the name of a managed service account or virtual account
	/// name, the lpPassword parameter must be NULL.
	/// </para>
	/// <para>Passwords are ignored for driver services.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the service.</para>
	/// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the service control manager. Other error codes can be set by the registry functions that
	/// are called by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle to the SCM database does not have the SC_MANAGER_CREATE_SERVICE access right.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CIRCULAR_DEPENDENCY</term>
	/// <term>A circular service dependency was specified.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DUPLICATE_SERVICE_NAME</term>
	/// <term>
	/// The display name already exists in the service control manager database either as a service name or as another display name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle to the specified service control manager database is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_NAME</term>
	/// <term>The specified service name is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter that was specified is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_SERVICE_ACCOUNT</term>
	/// <term>The user account name specified in the lpServiceStartName parameter does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_EXISTS</term>
	/// <term>The specified service already exists in this database.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_MARKED_FOR_DELETE</term>
	/// <term>The specified service already exists in this database and has been marked for deletion.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CreateService</c> function creates a service object and installs it in the service control manager database by creating a
	/// key with the same name as the service under the following registry key: <c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services</c>
	/// </para>
	/// <para>
	/// Information specified by <c>CreateService</c>, ChangeServiceConfig, and ChangeServiceConfig2 is saved as values under this key.
	/// The following are examples of values stored for a service.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>DependOnGroup</term>
	/// <term>Load-ordering groups on which this service depends, as specified by lpDependencies.</term>
	/// </item>
	/// <item>
	/// <term>DependOnService</term>
	/// <term>Services on which this service depends, as specified by lpDependencies.</term>
	/// </item>
	/// <item>
	/// <term>Description</term>
	/// <term>Description specified by ChangeServiceConfig2.</term>
	/// </item>
	/// <item>
	/// <term>DisplayName</term>
	/// <term>Display name specified by lpDisplayName.</term>
	/// </item>
	/// <item>
	/// <term>ErrorControl</term>
	/// <term>Error control specified by dwErrorControl.</term>
	/// </item>
	/// <item>
	/// <term>FailureActions</term>
	/// <term>Failure actions specified by ChangeServiceConfig2.</term>
	/// </item>
	/// <item>
	/// <term>Group</term>
	/// <term>
	/// Load ordering group specified by lpLoadOrderGroup. Note that setting this value can override the setting of the DependOnService value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ImagePath</term>
	/// <term>Name of binary file, as specified by lpBinaryPathName.</term>
	/// </item>
	/// <item>
	/// <term>ObjectName</term>
	/// <term>Account name specified by lpServiceStartName.</term>
	/// </item>
	/// <item>
	/// <term>Start</term>
	/// <term>When to start service, as specified by dwStartType.</term>
	/// </item>
	/// <item>
	/// <term>Tag</term>
	/// <term>Tag identifier specified by lpdwTagId.</term>
	/// </item>
	/// <item>
	/// <term>Type</term>
	/// <term>Service type specified by dwServiceType.</term>
	/// </item>
	/// </list>
	/// <para>Setup programs and the service itself can create additional subkeys for service-specific information.</para>
	/// <para>
	/// The returned handle is only valid for the process that called <c>CreateService</c>. It can be closed by calling the
	/// CloseServiceHandle function.
	/// </para>
	/// <para>
	/// If you are creating services that share a process, avoid calling functions with process-wide effects, such as ExitProcess. In
	/// addition, do not unload your service DLL.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Installing a Service.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-createservicea SC_HANDLE CreateServiceA( SC_HANDLE
	// hSCManager, LPCSTR lpServiceName, LPCSTR lpDisplayName, DWORD dwDesiredAccess, DWORD dwServiceType, DWORD dwStartType, DWORD
	// dwErrorControl, LPCSTR lpBinaryPathName, LPCSTR lpLoadOrderGroup, LPDWORD lpdwTagId, LPCSTR lpDependencies, LPCSTR
	// lpServiceStartName, LPCSTR lpPassword );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "47288924-3294-4a50-b27d-7df80d5c957c")]
	public static extern SafeSC_HANDLE CreateService(SC_HANDLE hSCManager, string lpServiceName, [Optional] string? lpDisplayName, uint dwDesiredAccess, ServiceTypes dwServiceType,
		ServiceStartType dwStartType, ServiceErrorControlType dwErrorControl, string lpBinaryPathName, [Optional] string? lpLoadOrderGroup, out uint lpdwTagId,
		[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")] string[]? lpDependencies,
		[Optional] string? lpServiceStartName, [Optional] string? lpPassword);

	/// <summary>
	/// <para>Creates a service object and adds it to the specified service control manager database.</para>
	/// </summary>
	/// <param name="hSCManager">
	/// <para>
	/// A handle to the service control manager database. This handle is returned by the OpenSCManager function and must have the
	/// <c>SC_MANAGER_CREATE_SERVICE</c> access right. For more information, see Service Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="lpServiceName">
	/// <para>
	/// The name of the service to install. The maximum string length is 256 characters. The service control manager database preserves
	/// the case of the characters, but service name comparisons are always case insensitive. Forward-slash (/) and backslash () are not
	/// valid service name characters.
	/// </para>
	/// </param>
	/// <param name="lpDisplayName">
	/// <para>
	/// The display name to be used by user interface programs to identify the service. This string has a maximum length of 256
	/// characters. The name is case-preserved in the service control manager. Display name comparisons are always case-insensitive.
	/// </para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>
	/// The access to the service. Before granting the requested access, the system checks the access token of the calling process. For a
	/// list of values, see Service Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="dwServiceType">
	/// <para>The service type. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_ADAPTER 0x00000004</term>
	/// <term>Reserved.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_FILE_SYSTEM_DRIVER 0x00000002</term>
	/// <term>File system driver service.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_KERNEL_DRIVER 0x00000001</term>
	/// <term>Driver service.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_RECOGNIZER_DRIVER 0x00000008</term>
	/// <term>Reserved.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_WIN32_OWN_PROCESS 0x00000010</term>
	/// <term>Service that runs in its own process.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_WIN32_SHARE_PROCESS 0x00000020</term>
	/// <term>Service that shares a process with one or more other services. For more information, see Service Programs.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_USER_OWN_PROCESS 0x00000050</term>
	/// <term>The service runs in its own process under the logged-on user account.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_USER_SHARE_PROCESS 0x00000060</term>
	/// <term>The service shares a process with one or more other services that run under the logged-on user account.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If you specify either <c>SERVICE_WIN32_OWN_PROCESS</c> or <c>SERVICE_WIN32_SHARE_PROCESS</c>, and the service is running in the
	/// context of the LocalSystem account, you can also specify the following value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_INTERACTIVE_PROCESS 0x00000100</term>
	/// <term>The service can interact with the desktop. For more information, see Interactive Services.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwStartType">
	/// <para>The service start options. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_AUTO_START 0x00000002</term>
	/// <term>
	/// A service started automatically by the service control manager during system startup. For more information, see Automatically
	/// Starting Services.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_BOOT_START 0x00000000</term>
	/// <term>A device driver started by the system loader. This value is valid only for driver services.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_DEMAND_START 0x00000003</term>
	/// <term>
	/// A service started by the service control manager when a process calls the StartService function. For more information, see
	/// Starting Services on Demand.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_DISABLED 0x00000004</term>
	/// <term>A service that cannot be started. Attempts to start the service result in the error code ERROR_SERVICE_DISABLED.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_SYSTEM_START 0x00000001</term>
	/// <term>A device driver started by the IoInitSystem function. This value is valid only for driver services.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwErrorControl">
	/// <para>
	/// The severity of the error, and action taken, if this service fails to start. This parameter can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_ERROR_CRITICAL 0x00000003</term>
	/// <term>
	/// The startup program logs the error in the event log, if possible. If the last-known-good configuration is being started, the
	/// startup operation fails. Otherwise, the system is restarted with the last-known good configuration.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_ERROR_IGNORE 0x00000000</term>
	/// <term>The startup program ignores the error and continues the startup operation.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_ERROR_NORMAL 0x00000001</term>
	/// <term>The startup program logs the error in the event log but continues the startup operation.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_ERROR_SEVERE 0x00000002</term>
	/// <term>
	/// The startup program logs the error in the event log. If the last-known-good configuration is being started, the startup operation
	/// continues. Otherwise, the system is restarted with the last-known-good configuration.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpBinaryPathName">
	/// <para>
	/// The fully qualified path to the service binary file. If the path contains a space, it must be quoted so that it is correctly
	/// interpreted. For example, "d:\my share\myservice.exe" should be specified as ""d:\my share\myservice.exe"".
	/// </para>
	/// <para>
	/// The path can also include arguments for an auto-start service. For example, "d:\myshare\myservice.exe arg1 arg2". These arguments
	/// are passed to the service entry point (typically the <c>main</c> function).
	/// </para>
	/// <para>
	/// If you specify a path on another computer, the share must be accessible by the computer account of the local computer because
	/// this is the security context used in the remote call. However, this requirement allows any potential vulnerabilities in the
	/// remote computer to affect the local computer. Therefore, it is best to use a local file.
	/// </para>
	/// </param>
	/// <param name="lpLoadOrderGroup">
	/// <para>
	/// The names of the load ordering group of which this service is a member. Specify NULL or an empty string if the service does not
	/// belong to a group.
	/// </para>
	/// <para>
	/// The startup program uses load ordering groups to load groups of services in a specified order with respect to the other groups.
	/// The list of load ordering groups is contained in the following registry value: <c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control</c>&lt;b&gt;ServiceGroupOrder
	/// </para>
	/// </param>
	/// <param name="lpdwTagId">
	/// <para>
	/// A pointer to a variable that receives a tag value that is unique in the group specified in the lpLoadOrderGroup parameter.
	/// Specify NULL if you are not changing the existing tag.
	/// </para>
	/// <para>
	/// You can use a tag for ordering service startup within a load ordering group by specifying a tag order vector in the following
	/// registry value: <c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control</c>&lt;b&gt;GroupOrderList
	/// </para>
	/// <para>Tags are only evaluated for driver services that have <c>SERVICE_BOOT_START</c> or <c>SERVICE_SYSTEM_START</c> start types.</para>
	/// </param>
	/// <param name="lpDependencies">
	/// <para>
	/// A pointer to a double null-terminated array of null-separated names of services or load ordering groups that the system must
	/// start before this service. Specify NULL or an empty string if the service has no dependencies. Dependency on a group means that
	/// this service can run if at least one member of the group is running after an attempt to start all members of the group.
	/// </para>
	/// <para>
	/// You must prefix group names with <c>SC_GROUP_IDENTIFIER</c> so that they can be distinguished from a service name, because
	/// services and service groups share the same name space.
	/// </para>
	/// </param>
	/// <param name="lpServiceStartName">
	/// <para>
	/// The name of the account under which the service should run. If the service type is SERVICE_WIN32_OWN_PROCESS, use an account name
	/// in the form DomainName&lt;i&gt;UserName. The service process will be logged on as this user. If the account belongs to the
	/// built-in domain, you can specify .&lt;i&gt;UserName.
	/// </para>
	/// <para>
	/// If this parameter is NULL, <c>CreateService</c> uses the LocalSystem account. If the service type specifies
	/// <c>SERVICE_INTERACTIVE_PROCESS</c>, the service must run in the LocalSystem account.
	/// </para>
	/// <para>
	/// If this parameter is NT AUTHORITY\LocalService, <c>CreateService</c> uses the LocalService account. If the parameter is NT
	/// AUTHORITY\NetworkService, <c>CreateService</c> uses the NetworkService account.
	/// </para>
	/// <para>A shared process can run as any user.</para>
	/// <para>
	/// If the service type is <c>SERVICE_KERNEL_DRIVER</c> or <c>SERVICE_FILE_SYSTEM_DRIVER</c>, the name is the driver object name that
	/// the system uses to load the device driver. Specify NULL if the driver is to use a default object name created by the I/O system.
	/// </para>
	/// <para>
	/// A service can be configured to use a managed account or a virtual account. If the service is configured to use a managed service
	/// account, the name is the managed service account name. If the service is configured to use a virtual account, specify the name as
	/// NT SERVICE&lt;i&gt;ServiceName. For more information about managed service accounts and virtual accounts, see the Service
	/// Accounts Step-by-Step Guide.
	/// </para>
	/// <para>
	/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> Managed service accounts and virtual accounts are
	/// not supported until Windows 7 and Windows Server 2008 R2.
	/// </para>
	/// </param>
	/// <param name="lpPassword">
	/// <para>
	/// The password to the account name specified by the lpServiceStartName parameter. Specify an empty string if the account has no
	/// password or if the service runs in the LocalService, NetworkService, or LocalSystem account. For more information, see Service
	/// Record List.
	/// </para>
	/// <para>
	/// If the account name specified by the lpServiceStartName parameter is the name of a managed service account or virtual account
	/// name, the lpPassword parameter must be NULL.
	/// </para>
	/// <para>Passwords are ignored for driver services.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the service.</para>
	/// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the service control manager. Other error codes can be set by the registry functions that
	/// are called by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle to the SCM database does not have the SC_MANAGER_CREATE_SERVICE access right.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CIRCULAR_DEPENDENCY</term>
	/// <term>A circular service dependency was specified.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DUPLICATE_SERVICE_NAME</term>
	/// <term>
	/// The display name already exists in the service control manager database either as a service name or as another display name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle to the specified service control manager database is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_NAME</term>
	/// <term>The specified service name is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter that was specified is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_SERVICE_ACCOUNT</term>
	/// <term>The user account name specified in the lpServiceStartName parameter does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_EXISTS</term>
	/// <term>The specified service already exists in this database.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_MARKED_FOR_DELETE</term>
	/// <term>The specified service already exists in this database and has been marked for deletion.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CreateService</c> function creates a service object and installs it in the service control manager database by creating a
	/// key with the same name as the service under the following registry key: <c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services</c>
	/// </para>
	/// <para>
	/// Information specified by <c>CreateService</c>, ChangeServiceConfig, and ChangeServiceConfig2 is saved as values under this key.
	/// The following are examples of values stored for a service.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>DependOnGroup</term>
	/// <term>Load-ordering groups on which this service depends, as specified by lpDependencies.</term>
	/// </item>
	/// <item>
	/// <term>DependOnService</term>
	/// <term>Services on which this service depends, as specified by lpDependencies.</term>
	/// </item>
	/// <item>
	/// <term>Description</term>
	/// <term>Description specified by ChangeServiceConfig2.</term>
	/// </item>
	/// <item>
	/// <term>DisplayName</term>
	/// <term>Display name specified by lpDisplayName.</term>
	/// </item>
	/// <item>
	/// <term>ErrorControl</term>
	/// <term>Error control specified by dwErrorControl.</term>
	/// </item>
	/// <item>
	/// <term>FailureActions</term>
	/// <term>Failure actions specified by ChangeServiceConfig2.</term>
	/// </item>
	/// <item>
	/// <term>Group</term>
	/// <term>
	/// Load ordering group specified by lpLoadOrderGroup. Note that setting this value can override the setting of the DependOnService value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ImagePath</term>
	/// <term>Name of binary file, as specified by lpBinaryPathName.</term>
	/// </item>
	/// <item>
	/// <term>ObjectName</term>
	/// <term>Account name specified by lpServiceStartName.</term>
	/// </item>
	/// <item>
	/// <term>Start</term>
	/// <term>When to start service, as specified by dwStartType.</term>
	/// </item>
	/// <item>
	/// <term>Tag</term>
	/// <term>Tag identifier specified by lpdwTagId.</term>
	/// </item>
	/// <item>
	/// <term>Type</term>
	/// <term>Service type specified by dwServiceType.</term>
	/// </item>
	/// </list>
	/// <para>Setup programs and the service itself can create additional subkeys for service-specific information.</para>
	/// <para>
	/// The returned handle is only valid for the process that called <c>CreateService</c>. It can be closed by calling the
	/// CloseServiceHandle function.
	/// </para>
	/// <para>
	/// If you are creating services that share a process, avoid calling functions with process-wide effects, such as ExitProcess. In
	/// addition, do not unload your service DLL.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Installing a Service.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-createservicea SC_HANDLE CreateServiceA( SC_HANDLE
	// hSCManager, LPCSTR lpServiceName, LPCSTR lpDisplayName, DWORD dwDesiredAccess, DWORD dwServiceType, DWORD dwStartType, DWORD
	// dwErrorControl, LPCSTR lpBinaryPathName, LPCSTR lpLoadOrderGroup, LPDWORD lpdwTagId, LPCSTR lpDependencies, LPCSTR
	// lpServiceStartName, LPCSTR lpPassword );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "47288924-3294-4a50-b27d-7df80d5c957c")]
	public static extern SafeSC_HANDLE CreateService(SC_HANDLE hSCManager, string lpServiceName, [Optional] string? lpDisplayName, uint dwDesiredAccess, ServiceTypes dwServiceType,
		ServiceStartType dwStartType, ServiceErrorControlType dwErrorControl, string lpBinaryPathName, [Optional] string? lpLoadOrderGroup, [Optional] IntPtr lpdwTagId,
		[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")] string[]? lpDependencies,
		[Optional] string? lpServiceStartName, [Optional] string? lpPassword);

	/// <summary>Marks the specified service for deletion from the service control manager database.</summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the OpenService or CreateService function, and it must have the DELETE access
	/// right. For more information, see Service Security and Access Rights.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes may be set by the service control manager. Others may be set by the registry functions that are called
	/// by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle does not have the DELETE access right.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_MARKED_FOR_DELETE</term>
	/// <term>The specified service has already been marked for deletion.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DeleteService</c> function marks a service for deletion from the service control manager database. The database entry is
	/// not removed until all open handles to the service have been closed by calls to the CloseServiceHandle function, and the service
	/// is not running. A running service is stopped by a call to the ControlService function with the SERVICE_CONTROL_STOP control code.
	/// If the service cannot be stopped, the database entry is removed when the system is restarted.
	/// </para>
	/// <para>The service control manager deletes the service by deleting the service key and its subkeys from the registry.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Deleting a Service.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-deleteservice BOOL DeleteService( SC_HANDLE hService );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsvc.h", MSDNShortId = "5b0fc714-60e0-4ae3-8fa8-ace36dab2fb0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteService(SC_HANDLE hService);

	/// <summary>
	/// Retrieves the name and status of each service that depends on the specified service; that is, the specified service must be
	/// running before the dependent services can run.
	/// </summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the OpenService or CreateService function, and it must have the
	/// <c>SERVICE_ENUMERATE_DEPENDENTS</c> access right. For more information, see Service Security and Access Rights.
	/// </param>
	/// <param name="dwServiceState">The state of the services to be enumerated. This parameter can be one of the following values.</param>
	/// <param name="lpServices">
	/// <para>
	/// A pointer to an array of ENUM_SERVICE_STATUS structures that receives the name and service status information for each dependent
	/// service in the database. The buffer must be large enough to hold the structures, plus the strings to which their members point.
	/// </para>
	/// <para>
	/// The order of the services in this array is the reverse of the start order of the services. In other words, the first service in
	/// the array is the one that would be started last, and the last service in the array is the one that would be started first.
	/// </para>
	/// <para>
	/// The maximum size of this array is 64,000 bytes. To determine the required size, specify <c>NULL</c> for this parameter and 0 for
	/// the cbBufSize parameter. The function will fail and GetLastError will return <c>ERROR_MORE_DATA</c>. The pcbBytesNeeded parameter
	/// will receive the required size.
	/// </para>
	/// </param>
	/// <param name="cbBufSize">The size of the buffer pointed to by the lpServices parameter, in bytes.</param>
	/// <param name="pcbBytesNeeded">
	/// A pointer to a variable that receives the number of bytes needed to store the array of service entries. The variable only
	/// receives this value if the buffer pointed to by lpServices is too small, indicated by function failure and the
	/// <c>ERROR_MORE_DATA</c> error; otherwise, the contents of pcbBytesNeeded are undefined.
	/// </param>
	/// <param name="lpServicesReturned">A pointer to a variable that receives the number of service entries returned.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes may be set by the service control manager. Other error codes may be set by the registry functions that
	/// are called by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle does not have the SERVICE_ENUMERATE_DEPENDENTS access right.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter that was specified is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// The buffer pointed to by lpServices is not large enough. The function sets the variable pointed to by lpServicesReturned to the
	/// actual number of service entries stored into the buffer. The function sets the variable pointed to by pcbBytesNeeded to the
	/// number of bytes required to store all of the service entries.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The returned services entries are ordered in the reverse order of the start order, with group order taken into account. If you
	/// need to stop the dependent services, you can use the order of entries written to the lpServices buffer to stop the dependent
	/// services in the proper order.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Stopping a Service.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-enumdependentservicesa BOOL EnumDependentServicesA(
	// SC_HANDLE hService, DWORD dwServiceState, LPENUM_SERVICE_STATUSA lpServices, DWORD cbBufSize, LPDWORD pcbBytesNeeded, LPDWORD
	// lpServicesReturned );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "905d4453-96d4-4055-8a17-36714c547cdd")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumDependentServices(SC_HANDLE hService, SERVICE_STATE dwServiceState, [Optional] IntPtr lpServices, uint cbBufSize, out uint pcbBytesNeeded, out uint lpServicesReturned);

	/// <summary>
	/// Retrieves the name and status of each service that depends on the specified service; that is, the specified service must be
	/// running before the dependent services can run.
	/// </summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the OpenService or CreateService function, and it must have the
	/// <c>SERVICE_ENUMERATE_DEPENDENTS</c> access right. For more information, see Service Security and Access Rights.
	/// </param>
	/// <param name="dwServiceState">The state of the services to be enumerated. This parameter can be one of the following values.</param>
	/// <returns>
	/// <para>
	/// An array of ENUM_SERVICE_STATUS structures that receives the name and service status information for each dependent service in
	/// the database.
	/// </para>
	/// <para>
	/// The order of the services in this array is the reverse of the start order of the services. In other words, the first service in
	/// the array is the one that would be started last, and the last service in the array is the one that would be started first.
	/// </para>
	/// </returns>
	[PInvokeData("winsvc.h", MSDNShortId = "905d4453-96d4-4055-8a17-36714c547cdd")]
	public static IEnumerable<ENUM_SERVICE_STATUS> EnumDependentServices(SC_HANDLE hService, SERVICE_STATE dwServiceState = SERVICE_STATE.SERVICE_STATE_ALL)
	{
		EnumDependentServices(hService, dwServiceState, IntPtr.Zero, 0, out var sz, out var cnt);
		if (sz == 0) Win32Error.ThrowLastError();
		var mem = new SafeHGlobalHandle((int)sz);
		if (!EnumDependentServices(hService, dwServiceState, (IntPtr)mem, (uint)mem.Size, out sz, out cnt))
			Win32Error.ThrowLastError();
		return mem.ToArray<ENUM_SERVICE_STATUS>((int)cnt);
	}

	/// <summary>
	/// <para>Enumerates services in the specified service control manager database. The name and status of each service are provided.</para>
	/// <para>
	/// This function has been superseded by the EnumServicesStatusEx function. It returns the same information <c>EnumServicesStatus</c>
	/// returns, plus the process identifier and additional information for the service. In addition, <c>EnumServicesStatusEx</c> enables
	/// you to enumerate services that belong to a specified group.
	/// </para>
	/// </summary>
	/// <param name="hSCManager">
	/// A handle to the service control manager database. This handle is returned by the OpenSCManager function, and must have the
	/// SC_MANAGER_ENUMERATE_SERVICE access right. For more information, see Service Security and Access Rights.
	/// </param>
	/// <param name="dwServiceType">The type of services to be enumerated. This parameter can be one or more of the following values.</param>
	/// <param name="dwServiceState">The state of the services to be enumerated. This parameter can be one of the following values.</param>
	/// <param name="lpServices">
	/// <para>
	/// A pointer to a buffer that contains an array of ENUM_SERVICE_STATUS structures that receive the name and service status
	/// information for each service in the database. The buffer must be large enough to hold the structures, plus the strings to which
	/// their members point.
	/// </para>
	/// <para>
	/// The maximum size of this array is 256K bytes. To determine the required size, specify NULL for this parameter and 0 for the
	/// cbBufSize parameter. The function will fail and GetLastError will return ERROR_INSUFFICIENT_BUFFER. The pcbBytesNeeded parameter
	/// will receive the required size.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> The maximum size of this array is 64K bytes. This limit was increased as of Windows
	/// Server 2003 with SP1 and Windows XP with SP2.
	/// </para>
	/// </param>
	/// <param name="cbBufSize">The size of the buffer pointed to by the lpServices parameter, in bytes.</param>
	/// <param name="pcbBytesNeeded">
	/// A pointer to a variable that receives the number of bytes needed to return the remaining service entries, if the buffer is too small.
	/// </param>
	/// <param name="lpServicesReturned">A pointer to a variable that receives the number of service entries returned.</param>
	/// <param name="lpResumeHandle">
	/// A pointer to a variable that, on input, specifies the starting point of enumeration. You must set this value to zero the first
	/// time this function is called. On output, this value is zero if the function succeeds. However, if the function returns zero and
	/// the GetLastError function returns ERROR_MORE_DATA, this value is used to indicate the next service entry to be read when the
	/// function is called to retrieve the additional data.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the service control manager. Other error codes can be set by the registry functions that
	/// are called by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle does not have the SC_MANAGER_ENUMERATE_SERVICE access right.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter that was specified is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// There are more service entries than would fit into the lpServices buffer. The actual number of service entries written to
	/// lpServices is returned in the lpServicesReturned parameter. The number of bytes required to get the remaining entries is returned
	/// in the pcbBytesNeeded parameter. The remaining services can be enumerated by additional calls to EnumServicesStatus with the
	/// lpResumeHandle parameter indicating the next service to read.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-enumservicesstatusa BOOL EnumServicesStatusA( SC_HANDLE
	// hSCManager, DWORD dwServiceType, DWORD dwServiceState, LPENUM_SERVICE_STATUSA lpServices, DWORD cbBufSize, LPDWORD pcbBytesNeeded,
	// LPDWORD lpServicesReturned, LPDWORD lpResumeHandle );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "3a82ac0e-f3e8-4a5a-9b13-84e952712229")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumServicesStatus(SC_HANDLE hSCManager, ServiceTypes dwServiceType, SERVICE_STATE dwServiceState, [Optional] IntPtr lpServices, uint cbBufSize, out uint pcbBytesNeeded, out uint lpServicesReturned, ref uint lpResumeHandle);

	/// <summary>
	/// <para>Enumerates services in the specified service control manager database. The name and status of each service are provided.</para>
	/// <para>
	/// This function has been superseded by the EnumServicesStatusEx function. It returns the same information <c>EnumServicesStatus</c>
	/// returns, plus the process identifier and additional information for the service. In addition, <c>EnumServicesStatusEx</c> enables
	/// you to enumerate services that belong to a specified group.
	/// </para>
	/// </summary>
	/// <param name="hSCManager">
	/// A handle to the service control manager database. This handle is returned by the OpenSCManager function, and must have the
	/// SC_MANAGER_ENUMERATE_SERVICE access right. For more information, see Service Security and Access Rights.
	/// </param>
	/// <param name="dwServiceType">The type of services to be enumerated. This parameter can be one or more of the following values.</param>
	/// <param name="dwServiceState">The state of the services to be enumerated. This parameter can be one of the following values.</param>
	/// <returns>A list of ENUM_SERVICE_STATUS structures with the name and service status information for each service in the database.</returns>
	public static IEnumerable<ENUM_SERVICE_STATUS> EnumServicesStatus(SC_HANDLE hSCManager, ServiceTypes dwServiceType = ServiceTypes.SERVICE_TYPE_ALL, SERVICE_STATE dwServiceState = SERVICE_STATE.SERVICE_STATE_ALL)
	{
		var hRes = 0U;
		Win32Error lastErr;
		var res = EnumServicesStatus(hSCManager, dwServiceType, dwServiceState, default, 0, out var sz, out _, ref hRes);
		if (!res && (lastErr = Win32Error.GetLastError()) != Win32Error.ERROR_MORE_DATA)
			lastErr.ThrowIfFailed();
		using var mem = new SafeHGlobalHandle((int)sz);
		do
		{
			res = EnumServicesStatus(hSCManager, dwServiceType, dwServiceState, (IntPtr)mem, sz, out sz, out var cnt, ref hRes);
			if (!res && (lastErr = Win32Error.GetLastError()) != Win32Error.ERROR_MORE_DATA)
				lastErr.ThrowIfFailed();
			foreach (var i in mem.ToArray<ENUM_SERVICE_STATUS>((int)cnt))
				yield return i;
		} while (!res);
	}

	/// <summary>
	/// Enumerates services in the specified service control manager database. The name and status of each service are provided, along
	/// with additional data based on the specified information level.
	/// </summary>
	/// <param name="hSCManager">
	/// A handle to the service control manager database. This handle is returned by the OpenSCManager function, and must have the
	/// <c>SC_MANAGER_ENUMERATE_SERVICE</c> access right. For more information, see Service Security and Access Rights.
	/// </param>
	/// <param name="InfoLevel">
	/// <para>
	/// The service attributes that are to be returned. Use <c>SC_ENUM_PROCESS_INFO</c> to retrieve the name and service status
	/// information for each service in the database. The lpServices parameter is a pointer to a buffer that receives an array of
	/// ENUM_SERVICE_STATUS_PROCESS structures. The buffer must be large enough to hold the structures as well as the strings to which
	/// their members point.
	/// </para>
	/// <para>Currently, no other information levels are defined.</para>
	/// </param>
	/// <param name="dwServiceType">The type of services to be enumerated. This parameter can be one or more of the following values.</param>
	/// <param name="dwServiceState">The state of the services to be enumerated. This parameter can be one of the following values.</param>
	/// <param name="lpServices">
	/// <para>
	/// A pointer to the buffer that receives the status information. The format of this data depends on the value of the InfoLevel parameter.
	/// </para>
	/// <para>
	/// The maximum size of this array is 256K bytes. To determine the required size, specify <c>NULL</c> for this parameter and 0 for
	/// the cbBufSize parameter. The function will fail and GetLastError will return <c>ERROR_MORE_DATA</c>. The pcbBytesNeeded parameter
	/// will receive the required size.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> The maximum size of this array is 64K bytes. This limit was increased as of Windows
	/// Server 2003 with SP1 and Windows XP with SP2.
	/// </para>
	/// </param>
	/// <param name="cbBufSize">The size of the buffer pointed to by the lpServices parameter, in bytes.</param>
	/// <param name="pcbBytesNeeded">
	/// A pointer to a variable that receives the number of bytes needed to return the remaining service entries, if the buffer is too small.
	/// </param>
	/// <param name="lpServicesReturned">A pointer to a variable that receives the number of service entries returned.</param>
	/// <param name="lpResumeHandle">
	/// A pointer to a variable that, on input, specifies the starting point of enumeration. You must set this value to zero the first
	/// time the <c>EnumServicesStatusEx</c> function is called. On output, this value is zero if the function succeeds. However, if the
	/// function returns zero and the GetLastError function returns <c>ERROR_MORE_DATA</c>, this value indicates the next service entry
	/// to be read when the <c>EnumServicesStatusEx</c> function is called to retrieve the additional data.
	/// </param>
	/// <param name="pszGroupName">
	/// The load-order group name. If this parameter is a string, the only services enumerated are those that belong to the group that
	/// has the name specified by the string. If this parameter is an empty string, only services that do not belong to any group are
	/// enumerated. If this parameter is <c>NULL</c>, group membership is ignored and all services are enumerated.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following errors may
	/// be returned.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle does not have the SC_MANAGER_ENUMERATE_SERVICE access right.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// The buffer is too small. Not all data in the active database could be returned. The pcbBytesNeeded parameter contains the number
	/// of bytes required to receive the remaining entries.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An illegal parameter value was used.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_LEVEL</term>
	/// <term>The InfoLevel parameter contains an unsupported value.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SHUTDOWN_IN_PROGRESS</term>
	/// <term>The system is shutting down; this function cannot be called.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// If the caller does not have the <c>SERVICE_QUERY_STATUS</c> access right to a service, the service is silently omitted from the
	/// list of services returned to the client.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-enumservicesstatusexa BOOL EnumServicesStatusExA( SC_HANDLE
	// hSCManager, SC_ENUM_TYPE InfoLevel, DWORD dwServiceType, DWORD dwServiceState, LPBYTE lpServices, DWORD cbBufSize, LPDWORD
	// pcbBytesNeeded, LPDWORD lpServicesReturned, LPDWORD lpResumeHandle, LPCSTR pszGroupName );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "7d7940c3-b562-455f-9a21-6d5fb5953030")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumServicesStatusEx(SC_HANDLE hSCManager, SC_ENUM_TYPE InfoLevel, ServiceTypes dwServiceType, SERVICE_STATE dwServiceState, [Optional] IntPtr lpServices, uint cbBufSize, out uint pcbBytesNeeded,
		out uint lpServicesReturned, ref uint lpResumeHandle, [Optional] string? pszGroupName);

	/// <summary>
	/// <para>Enumerates services in the specified service control manager database. The name and status of each service are provided.</para>
	/// <para>
	/// This function has been superseded by the EnumServicesStatusEx function. It returns the same information <c>EnumServicesStatus</c>
	/// returns, plus the process identifier and additional information for the service. In addition, <c>EnumServicesStatusEx</c> enables
	/// you to enumerate services that belong to a specified group.
	/// </para>
	/// </summary>
	/// <param name="hSCManager">
	/// A handle to the service control manager database. This handle is returned by the OpenSCManager function, and must have the
	/// SC_MANAGER_ENUMERATE_SERVICE access right. For more information, see Service Security and Access Rights.
	/// </param>
	/// <param name="dwServiceType">The type of services to be enumerated. This parameter can be one or more of the following values.</param>
	/// <param name="dwServiceState">The state of the services to be enumerated. This parameter can be one of the following values.</param>
	/// <param name="pszGroupName">
	/// The load-order group name. If this parameter is a string, the only services enumerated are those that belong to the group that
	/// has the name specified by the string. If this parameter is an empty string, only services that do not belong to any group are
	/// enumerated. If this parameter is <c>NULL</c>, group membership is ignored and all services are enumerated.
	/// </param>
	/// <returns>A list of ENUM_SERVICE_STATUS structures with the name and service status information for each service in the database.</returns>
	public static IEnumerable<ENUM_SERVICE_STATUS_PROCESS> EnumServicesStatusEx(SC_HANDLE hSCManager, ServiceTypes dwServiceType = ServiceTypes.SERVICE_TYPE_ALL, SERVICE_STATE dwServiceState = SERVICE_STATE.SERVICE_STATE_ALL, string? pszGroupName = null)
	{
		var hRes = 0U;
		Win32Error lastErr;
		var res = EnumServicesStatusEx(hSCManager, 0, dwServiceType, dwServiceState, default, 0, out var sz, out _, ref hRes, pszGroupName);
		if (!res && (lastErr = Win32Error.GetLastError()) != Win32Error.ERROR_MORE_DATA)
			lastErr.ThrowIfFailed();
		using var mem = new SafeHGlobalHandle((int)sz);
		do
		{
			res = EnumServicesStatusEx(hSCManager, 0, dwServiceType, dwServiceState, (IntPtr)mem, sz, out sz, out var cnt, ref hRes, pszGroupName);
			if (!res && (lastErr = Win32Error.GetLastError()) != Win32Error.ERROR_MORE_DATA)
				lastErr.ThrowIfFailed();
			foreach (var i in mem.ToArray<ENUM_SERVICE_STATUS_PROCESS>((int)cnt))
				yield return i;
		} while (!res);
	}

	/// <summary>Retrieves the display name of the specified service.</summary>
	/// <param name="hSCManager">A handle to the service control manager database, as returned by the OpenSCManager function.</param>
	/// <param name="lpServiceName">
	/// The service name. This name is the same as the service's registry key name. It is best to choose a name that is less than 256 characters.
	/// </param>
	/// <param name="lpDisplayName">
	/// <para>
	/// A pointer to a buffer that receives the service's display name. If the function fails, this buffer will contain an empty string.
	/// </para>
	/// <para>
	/// The maximum size of this array is 4K bytes. To determine the required size, specify NULL for this parameter and 0 for the
	/// lpcchBuffer parameter. The function will fail and GetLastError will return <c>ERROR_INSUFFICIENT_BUFFER</c>. The lpcchBuffer
	/// parameter will receive the required size.
	/// </para>
	/// <para>This parameter can specify a localized string using the following format:</para>
	/// <para>@[path]dllname,-strID</para>
	/// <para>The string with identifier strID is loaded from dllname; the path is optional. For more information, see RegLoadMUIString.</para>
	/// <para><c>Windows Server 2003 and Windows XP:</c> Localized strings are not supported until Windows Vista.</para>
	/// </param>
	/// <param name="lpcchBuffer">
	/// <para>A pointer to a variable that specifies the size of the buffer pointed to by lpDisplayName, in <c>TCHARs</c>.</para>
	/// <para>
	/// On output, this variable receives the size of the service's display name, in characters, excluding the null-terminating character.
	/// </para>
	/// <para>
	/// If the buffer pointed to by lpDisplayName is too small to contain the display name, the function does not store it. When the
	/// function returns, lpcchBuffer contains the size of the service's display name, excluding the null-terminating character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the functions succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// There are two names for a service: the service name and the display name. The service name is the name of the service's key in
	/// the registry. The display name is a user-friendly name that appears in the Services control panel application, and is used with
	/// the <c>NET START</c> command. To map the service name to the display name, use the <c>GetServiceDisplayName</c> function. To map
	/// the display name to the service name, use the GetServiceKeyName function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-getservicedisplaynamea BOOL GetServiceDisplayNameA(
	// SC_HANDLE hSCManager, LPCSTR lpServiceName, LPSTR lpDisplayName, LPDWORD lpcchBuffer );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "704812f3-134c-4161-b3b4-a955d87ff563")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetServiceDisplayName(SC_HANDLE hSCManager, string lpServiceName, StringBuilder? lpDisplayName, ref uint lpcchBuffer);

	/// <summary>Retrieves the service name of the specified service.</summary>
	/// <param name="hSCManager">A handle to the computer's service control manager database, as returned by OpenSCManager.</param>
	/// <param name="lpDisplayName">The service display name. This string has a maximum length of 256 characters.</param>
	/// <param name="lpServiceName">
	/// <para>A pointer to a buffer that receives the service name. If the function fails, this buffer will contain an empty string.</para>
	/// <para>
	/// The maximum size of this array is 4K bytes. To determine the required size, specify NULL for this parameter and 0 for the
	/// lpcchBuffer parameter. The function will fail and GetLastError will return <c>ERROR_INSUFFICIENT_BUFFER</c>. The lpcchBuffer
	/// parameter will receive the required size.
	/// </para>
	/// </param>
	/// <param name="lpcchBuffer">
	/// <para>
	/// A pointer to variable that specifies the size of the buffer pointed to by the lpServiceName parameter, in <c>TCHARs</c>. When the
	/// function returns, this parameter contains the size of the service name, in <c>TCHARs</c>, excluding the null-terminating character.
	/// </para>
	/// <para>
	/// If the buffer pointed to by lpServiceName is too small to contain the service name, the function stores no data in it. When the
	/// function returns, lpcchBuffer contains the size of the service name, excluding the NULL terminator.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the functions succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// There are two names for a service: the service name and the display name. The service name is the name of the service's key in
	/// the registry. The display name is a user-friendly name that appears in the Services control panel application, and is used with
	/// the <c>NET START</c> command. Both names are specified with the CreateService function and can be modified with the
	/// ChangeServiceConfig function. Information specified for a service is stored in a key with the same name as the service name under
	/// the <c>HKEY_LOCAL_MACHINE</c>&lt;b&gt;System&lt;b&gt;CurrentControlSet&lt;b&gt;Services&lt;i&gt;ServiceName registry key.
	/// </para>
	/// <para>
	/// To map the service name to the display name, use the GetServiceDisplayName function. To map the display name to the service name,
	/// use the <c>GetServiceKeyName</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-getservicekeynamea BOOL GetServiceKeyNameA( SC_HANDLE
	// hSCManager, LPCSTR lpDisplayName, LPSTR lpServiceName, LPDWORD lpcchBuffer );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "d2421566-de4a-49e5-bb41-ea98c6f6d19d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetServiceKeyName(SC_HANDLE hSCManager, string lpDisplayName, StringBuilder? lpServiceName, ref uint lpcchBuffer);

	/// <summary>
	/// <para>[As of Windows Vista, this function is provided for application compatibility and has no effect on the database.]</para>
	/// <para>
	/// Requests ownership of the service control manager (SCM) database lock. Only one process can own the lock at any specified time.
	/// </para>
	/// </summary>
	/// <param name="hSCManager">
	/// A handle to the SCM database. This handle is returned by the OpenSCManager function, and must have the <c>SC_MANAGER_LOCK</c>
	/// access right. For more information, see Service Security and Access Rights.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a lock to the specified SCM database.</para>
	/// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the SCM. Other error codes can be set by registry functions that are called by the SCM.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle does not have the SC_MANAGER_LOCK access right.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_DATABASE_LOCKED</term>
	/// <term>The database is locked.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A lock is a protocol used by setup and configuration programs and the SCM to serialize access to the service tree in the
	/// registry. The only time the SCM requests ownership of the lock is when it is starting a service.
	/// </para>
	/// <para>
	/// A program that acquires the SCM database lock and fails to release it prevents the SCM from starting other services. Because of
	/// the severity of this issue, processes are no longer allowed to lock the database. For compatibility with older applications, the
	/// <c>LockServiceDatabase</c> function returns a lock but has no other effect.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> Acquiring the SCM database lock prevents the SCM from starting a service until the
	/// lock is released. For example, a program that must configure several related services before any of them starts could call
	/// <c>LockServiceDatabase</c> before configuring the first service. Alternatively, it could ensure that none of the services are
	/// started until the configuration has been completed.
	/// </para>
	/// <para>
	/// A call to the StartService function to start a service in a locked database fails. No other SCM functions are affected by a lock.
	/// </para>
	/// <para>
	/// The lock is held until the <c>SC_LOCK</c> handle is specified in a subsequent call to the UnlockServiceDatabase function. If a
	/// process that owns a lock terminates, the SCM automatically cleans up and releases ownership of the lock.
	/// </para>
	/// <para>Failing to release the lock can cause system problems. A process that acquires the lock should release it as soon as possible.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-lockservicedatabase SC_LOCK LockServiceDatabase( SC_HANDLE
	// hSCManager );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsvc.h", MSDNShortId = "87861465-c966-479a-b906-27ae36cc83c8")]
	public static extern SC_LOCK LockServiceDatabase(SC_HANDLE hSCManager);

	/// <summary>
	/// Reports the boot status to the service control manager. It is used by boot verification programs. This function can be called
	/// only by a process running in the LocalSystem or Administrator's account.
	/// </summary>
	/// <param name="BootAcceptable">
	/// If the value is TRUE, the system saves the configuration as the last-known good configuration. If the value is FALSE, the system
	/// immediately reboots, using the previously saved last-known good configuration.
	/// </param>
	/// <returns>
	/// <para>If the BootAcceptable parameter is FALSE, the function does not return.</para>
	/// <para>If the last-known good configuration was successfully saved, the return value is nonzero.</para>
	/// <para>If an error occurs, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes may be set by the service control manager. Other error codes may be set by the registry functions that
	/// are called by the service control manager to set parameters in the configuration registry.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The user does not have permission to perform this operation. Only the system and members of the Administrator's group can do so.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Saving the configuration of a running system with this function is an acceptable method for saving the last-known good
	/// configuration. If the boot configuration is unacceptable, use this function to reboot the system using the existing last-known
	/// good configuration.
	/// </para>
	/// <para>
	/// This function call requires the caller's token to have permission to acquire the SC_MANAGER_MODIFY_BOOT_CONFIG access right. For
	/// more information, see Service Security and Access Rights.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-notifybootconfigstatus BOOL NotifyBootConfigStatus( BOOL
	// BootAcceptable );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsvc.h", MSDNShortId = "0b2b9cd0-f897-4681-9e99-5d0bed986112")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool NotifyBootConfigStatus([MarshalAs(UnmanagedType.Bool)] bool BootAcceptable);

	/// <summary>
	/// Enables an application to receive notification when the specified service is created or deleted or when its status changes.
	/// </summary>
	/// <param name="hService">
	/// <para>
	/// A handle to the service or the service control manager. Handles to services are returned by the OpenService or CreateService
	/// function and must have the SERVICE_QUERY_STATUS access right. Handles to the service control manager are returned by the
	/// OpenSCManager function and must have the SC_MANAGER_ENUMERATE_SERVICE access right. For more information, see Service Security
	/// and Access Rights.
	/// </para>
	/// <para>There can only be one outstanding notification request per service.</para>
	/// </param>
	/// <param name="dwNotifyMask">
	/// The type of status changes that should be reported. This parameter can be one or more of the following values.
	/// </param>
	/// <param name="pNotifyBuffer">
	/// <para>
	/// A pointer to a SERVICE_NOTIFY structure that contains notification information, such as a pointer to the callback function. This
	/// structure must remain valid until the callback function is invoked or the calling thread cancels the notification request.
	/// </para>
	/// <para>
	/// Do not make multiple calls to <c>NotifyServiceStatusChange</c> with the same buffer parameter until the callback function from
	/// the first call has finished with the buffer or the first notification request has been canceled. Otherwise, there is no guarantee
	/// which version of the buffer the callback function will receive.
	/// </para>
	/// <para>
	/// <c>Windows Vista:</c> The address of the callback function must be within the address range of a loaded module. Therefore, the
	/// callback function cannot be code that is generated at run time (such as managed code generated by the JIT compiler) or native
	/// code that is decompressed at run time. This restriction was removed in Windows Server 2008 and Windows Vista with SP1.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is ERROR_SUCCESS. If the service has been marked for deletion, the return value is
	/// ERROR_SERVICE_MARKED_FOR_DELETE and the handle to the service must be closed. If service notification is lagging too far behind
	/// the system state, the function returns ERROR_SERVICE_NOTIFY_CLIENT_LAGGING. In this case, the client should close the handle to
	/// the SCM, open a new handle, and call this function again.
	/// </para>
	/// <para>If the function fails, the return value is one of the system error codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>NotifyServiceStatusChange</c> function can be used to receive notifications about service applications. It cannot be used
	/// to receive notifications about driver services.
	/// </para>
	/// <para>
	/// When the service status changes, the system invokes the specified callback function as an asynchronous procedure call (APC)
	/// queued to the calling thread. The calling thread must enter an alertable wait (for example, by calling the SleepEx function) to
	/// receive notification. For more information, see Asynchronous Procedure Calls.
	/// </para>
	/// <para>
	/// If the service is already in any of the requested states when <c>NotifyServiceStatusChange</c> is called, the callback function
	/// is queued immediately. If the service state has not changed by the next time the function is called with the same service and
	/// state, the callback function is not queued immediately; the callback function is queued the next time the service enters the
	/// requested state.
	/// </para>
	/// <para>
	/// The <c>NotifyServiceStatusChange</c> function calls the OpenThread function on the calling thread with the THREAD_SET_CONTEXT
	/// access right. If the calling thread does not have this access right, <c>NotifyServiceStatusChange</c> fails. If the calling
	/// thread is impersonating another user, it may not have sufficient permission to set context.
	/// </para>
	/// <para>
	/// It is more efficient to call <c>NotifyServiceStatusChange</c> from a thread that performs a wait than to create an additional thread.
	/// </para>
	/// <para>
	/// After the callback function is invoked, the caller must call <c>NotifyServiceStatusChange</c> to receive additional
	/// notifications. Note that certain functions in the Windows API, including <c>NotifyServiceStatusChange</c> and other SCM
	/// functions, use remote procedure calls (RPC); these functions might perform an alertable wait operation, so they are not safe to
	/// call from within the callback function. Instead, the callback function should save the notification parameters and perform any
	/// additional work outside the callback.
	/// </para>
	/// <para>
	/// To cancel outstanding notifications, close the service handle using the CloseServiceHandle function. After
	/// <c>CloseServiceHandle</c> succeeds, no more notification APCs will be queued. If the calling thread exits without closing the
	/// service handle or waiting until the APC is generated, a memory leak can occur.
	/// </para>
	/// <para>
	/// <c>Important</c> If the calling thread is in a DLL and the DLL is unloaded before the thread receives the notification or calls
	/// CloseServiceHandle, the notification will cause unpredictable results and might cause the process to stop responding.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-notifyservicestatuschangea DWORD NotifyServiceStatusChangeA(
	// SC_HANDLE hService, DWORD dwNotifyMask, PSERVICE_NOTIFYA pNotifyBuffer );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "e22b7f69-f096-486f-97fa-0465bef499cd")]
	public static extern Win32Error NotifyServiceStatusChange(SC_HANDLE hService, SERVICE_NOTIFY_FLAGS dwNotifyMask, IntPtr pNotifyBuffer); // ref SERVICE_NOTIFY_2 pNotifyBuffer);

	/// <summary>
	/// <para>
	/// Establishes a connection to the service control manager on the specified computer and opens the specified service control manager database.
	/// </para>
	/// </summary>
	/// <param name="lpMachineName">
	/// <para>
	/// The name of the target computer. If the pointer is NULL or points to an empty string, the function connects to the service
	/// control manager on the local computer.
	/// </para>
	/// </param>
	/// <param name="lpDatabaseName">
	/// <para>
	/// The name of the service control manager database. This parameter should be set to SERVICES_ACTIVE_DATABASE. If it is NULL, the
	/// SERVICES_ACTIVE_DATABASE database is opened by default.
	/// </para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>The access to the service control manager. For a list of access rights, see Service Security and Access Rights.</para>
	/// <para>
	/// Before granting the requested access rights, the system checks the access token of the calling process against the discretionary
	/// access-control list of the security descriptor associated with the service control manager.
	/// </para>
	/// <para>The SC_MANAGER_CONNECT access right is implicitly specified by calling this function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the specified service control manager database.</para>
	/// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the SCM. Other error codes can be set by the registry functions that are called by the SCM.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The requested access was denied.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DATABASE_DOES_NOT_EXIST</term>
	/// <term>The specified database does not exist.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When a process uses the <c>OpenSCManager</c> function to open a handle to a service control manager database, the system performs
	/// a security check before granting the requested access. For more information, see Service Security and Access Rights.
	/// </para>
	/// <para>
	/// If the current user does not have proper access when connecting to a service on another computer, the <c>OpenSCManager</c>
	/// function call fails. To connect to a service remotely, call the LogonUser function with LOGON32_LOGON_NEW_CREDENTIALS and then
	/// call ImpersonateLoggedOnUser before calling <c>OpenSCManager</c>. For more information about connecting to services remotely, see
	/// Services and RPC/TCP.
	/// </para>
	/// <para>
	/// Only processes with Administrator privileges are able to open a database handle that can be used by the CreateService function.
	/// </para>
	/// <para>
	/// The returned handle is only valid for the process that called the <c>OpenSCManager</c> function. It can be closed by calling the
	/// CloseServiceHandle function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Changing a Service's Configuration.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-openscmanagera SC_HANDLE OpenSCManagerA( LPCSTR
	// lpMachineName, LPCSTR lpDatabaseName, DWORD dwDesiredAccess );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "a0237989-e5a7-4a3a-ab23-e2474a995341")]
	public static extern SafeSC_HANDLE OpenSCManager([Optional] string? lpMachineName, [Optional] string? lpDatabaseName, ScManagerAccessTypes dwDesiredAccess);

	/// <summary>
	/// <para>Opens an existing service.</para>
	/// </summary>
	/// <param name="hSCManager">
	/// <para>
	/// A handle to the service control manager database. The OpenSCManager function returns this handle. For more information, see
	/// Service Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="lpServiceName">
	/// <para>
	/// The name of the service to be opened. This is the name specified by the lpServiceName parameter of the CreateService function
	/// when the service object was created, not the service display name that is shown by user interface applications to identify the service.
	/// </para>
	/// <para>
	/// The maximum string length is 256 characters. The service control manager database preserves the case of the characters, but
	/// service name comparisons are always case insensitive. Forward-slash (/) and backslash () are invalid service name characters.
	/// </para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>The access to the service. For a list of access rights, see Service Security and Access Rights.</para>
	/// <para>
	/// Before granting the requested access, the system checks the access token of the calling process against the discretionary
	/// access-control list of the security descriptor associated with the service object.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the service.</para>
	/// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the service control manager. Others can be set by the registry functions that are called
	/// by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle does not have access to the service.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_NAME</term>
	/// <term>The specified service name is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_DOES_NOT_EXIST</term>
	/// <term>The specified service does not exist.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The returned handle is only valid for the process that called <c>OpenService</c>. It can be closed by calling the
	/// CloseServiceHandle function.
	/// </para>
	/// <para>To use <c>OpenService</c>, no privileges are required aside from <c>SC_MANAGER_CONNECT</c>.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Starting a Service.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-openservicea SC_HANDLE OpenServiceA( SC_HANDLE hSCManager,
	// LPCSTR lpServiceName, DWORD dwDesiredAccess );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "e0a42613-95ad-4d0f-a464-c6df33014064")]
	public static extern SafeSC_HANDLE OpenService(SC_HANDLE hSCManager, string lpServiceName, ServiceAccessTypes dwDesiredAccess);

	/// <summary>
	/// Retrieves the configuration parameters of the specified service. Optional configuration parameters are available using the
	/// QueryServiceConfig2 function.
	/// </summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the OpenService or CreateService function, and it must have the
	/// SERVICE_QUERY_CONFIG access right. For more information, see Service Security and Access Rights.
	/// </param>
	/// <param name="lpServiceConfig">
	/// A pointer to a buffer that receives the service configuration information. The format of the data is a QUERY_SERVICE_CONFIG structure.
	/// <para>
	/// The maximum size of this array is 8K bytes. To determine the required size, specify NULL for this parameter and 0 for the
	/// cbBufSize parameter. The function will fail and GetLastError will return ERROR_INSUFFICIENT_BUFFER. The pcbBytesNeeded parameter
	/// will receive the required size.
	/// </para>
	/// </param>
	/// <param name="cbBufSize">The size of the buffer pointed to by the lpServiceConfig parameter, in bytes.</param>
	/// <param name="pcbBytesNeeded">
	/// A pointer to a variable that receives the number of bytes needed to store all the configuration information, if the function
	/// fails with ERROR_INSUFFICIENT_BUFFER.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
	/// information, call GetLastError.
	/// </returns>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("winsvc.h", MSDNShortId = "ms684932")]
	public static extern bool QueryServiceConfig(SC_HANDLE hService, [Optional] IntPtr lpServiceConfig, uint cbBufSize, out uint pcbBytesNeeded);

	/// <summary>
	/// <para>Retrieves the optional configuration parameters of the specified service.</para>
	/// </summary>
	/// <param name="hService">
	/// <para>
	/// A handle to the service. This handle is returned by the OpenService or CreateService function and must have the
	/// <c>SERVICE_QUERY_CONFIG</c> access right. For more information, see Service Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="dwInfoLevel">
	/// <para>The configuration information to be queried. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_CONFIG_DELAYED_AUTO_START_INFO 3</term>
	/// <term>
	/// The lpInfo parameter is a pointer to a SERVICE_DELAYED_AUTO_START_INFO structure. Windows Server 2003 and Windows XP: This value
	/// is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONFIG_DESCRIPTION 1</term>
	/// <term>The lpBuffer parameter is a pointer to a SERVICE_DESCRIPTION structure.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONFIG_FAILURE_ACTIONS 2</term>
	/// <term>The lpBuffer parameter is a pointer to a SERVICE_FAILURE_ACTIONS structure.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONFIG_FAILURE_ACTIONS_FLAG 4</term>
	/// <term>
	/// The lpInfo parameter is a pointer to a SERVICE_FAILURE_ACTIONS_FLAG structure. Windows Server 2003 and Windows XP: This value is
	/// not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONFIG_PREFERRED_NODE 9</term>
	/// <term>
	/// The lpInfo parameter is a pointer to a SERVICE_PREFERRED_NODE_INFO structure. Windows Server 2008, Windows Vista, Windows Server
	/// 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONFIG_PRESHUTDOWN_INFO 7</term>
	/// <term>
	/// The lpInfo parameter is a pointer to a SERVICE_PRESHUTDOWN_INFO structure. Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONFIG_REQUIRED_PRIVILEGES_INFO 6</term>
	/// <term>
	/// The lpInfo parameter is a pointer to a SERVICE_REQUIRED_PRIVILEGES_INFO structure. Windows Server 2003 and Windows XP: This value
	/// is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONFIG_SERVICE_SID_INFO 5</term>
	/// <term>
	/// The lpInfo parameter is a pointer to a SERVICE_SID_INFO structure. Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONFIG_TRIGGER_INFO 8</term>
	/// <term>
	/// The lpInfo parameter is a pointer to a SERVICE_TRIGGER_INFO structure. Windows Server 2008, Windows Vista, Windows Server 2003
	/// and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_CONFIG_LAUNCH_PROTECTED 12</term>
	/// <term>The lpInfo parameter is a pointer a SERVICE_LAUNCH_PROTECTED_INFO structure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpBuffer">
	/// <para>
	/// A pointer to the buffer that receives the service configuration information. The format of this data depends on the value of the
	/// dwInfoLevel parameter.
	/// </para>
	/// <para>
	/// The maximum size of this array is 8K bytes. To determine the required size, specify <c>NULL</c> for this parameter and 0 for the
	/// cbBufSize parameter. The function fails and GetLastError returns <c>ERROR_INSUFFICIENT_BUFFER</c>. The pcbBytesNeeded parameter
	/// receives the needed size.
	/// </para>
	/// </param>
	/// <param name="cbBufSize">
	/// <para>The size of the structure pointed to by the lpBuffer parameter, in bytes.</para>
	/// </param>
	/// <param name="pcbBytesNeeded">
	/// <para>
	/// A pointer to a variable that receives the number of bytes required to store the configuration information, if the function fails
	/// with <c>ERROR_INSUFFICIENT_BUFFER</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the service control manager. Others can be set by the registry functions that are called
	/// by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle does not have the SERVICE_QUERY_CONFIG access right.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// There is more service configuration information than would fit into the lpBuffer buffer. The number of bytes required to get all
	/// the information is returned in the pcbBytesNeeded parameter. Nothing is written to lpBuffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>QueryServiceConfig2</c> function returns the optional configuration information stored in the service control manager
	/// database for the specified service. You can change this configuration information by using the ChangeServiceConfig2 function.
	/// </para>
	/// <para>
	/// You can change and query additional configuration information using the ChangeServiceConfig and QueryServiceConfig functions, respectively.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Querying a Service's Configuration.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-queryserviceconfig2a BOOL QueryServiceConfig2A( SC_HANDLE
	// hService, DWORD dwInfoLevel, LPBYTE lpBuffer, DWORD cbBufSize, LPDWORD pcbBytesNeeded );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "cb090e59-aeff-4420-bb7c-912a4911006f")]
	public static extern bool QueryServiceConfig2(SC_HANDLE hService, ServiceConfigOption dwInfoLevel, [Optional] IntPtr lpBuffer, uint cbBufSize, out uint pcbBytesNeeded);

	/// <summary>Retrieves the optional configuration parameters of a service.</summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the OpenService or CreateService function and must have the
	/// SERVICE_CHANGE_CONFIG access right.
	/// </param>
	/// <param name="dwInfoLevel">The configuration information to be queried.</param>
	/// <param name="configInfo">
	/// A variable that receives the service configuration information. The format of this data depends on the value of the dwInfoLevel parameter.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
	/// information, call GetLastError.
	/// </returns>
	[PInvokeData("winsvc.h", MSDNShortId = "ms684935")]
	public static bool QueryServiceConfig2<T>(SC_HANDLE hService, ServiceConfigOption dwInfoLevel, [NotNullWhen(true)] out T? configInfo)
	{
		if (!CorrespondingTypeAttribute.CanGet(dwInfoLevel, typeof(T))) throw new ArgumentException("Type mismatch", nameof(configInfo));
		var b = QueryServiceConfig2(hService, dwInfoLevel, IntPtr.Zero, 0, out var size);
		configInfo = default;
		if (!b && Win32Error.GetLastError() != Win32Error.ERROR_INSUFFICIENT_BUFFER) return false;
		using var buf = new SafeHGlobalHandle((int)size);
		if (!QueryServiceConfig2(hService, dwInfoLevel, (IntPtr)buf, size, out size)) return false;
		configInfo = buf.ToStructure<T>()!;
		return true;
	}

	/// <summary>Retrieves dynamic information related to the current service start.</summary>
	/// <param name="hServiceStatus">A service status handle provided by RegisterServiceCtrlHandlerEx</param>
	/// <param name="dwInfoLevel">Indicates the information level.</param>
	/// <param name="ppDynamicInfo">
	/// A dynamic information buffer. If this parameter is valid, the callback function must free the buffer after use with the LocalFree function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is TRUE.</para>
	/// <para>
	/// If the function fails, the return value is FALSE. When this happens the GetLastError function should be called to retrieve the
	/// error code.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-queryservicedynamicinformation BOOL
	// QueryServiceDynamicInformation( SERVICE_STATUS_HANDLE hServiceStatus, DWORD dwInfoLevel, PVOID *ppDynamicInfo );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsvc.h", MSDNShortId = "499b63fd-e77b-4b90-9ee7-ff4b7b12c431")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QueryServiceDynamicInformation(SERVICE_STATUS_HANDLE hServiceStatus, uint dwInfoLevel, out SafeLocalHandle ppDynamicInfo);

	/// <summary>
	/// <para>[This function has no effect as of Windows Vista.]</para>
	/// <para>Retrieves the lock status of the specified service control manager database.</para>
	/// </summary>
	/// <param name="hSCManager">
	/// A handle to the service control manager database. The OpenSCManager function returns this handle, which must have the
	/// SC_MANAGER_QUERY_LOCK_STATUS access right. For more information, see Service Security and Access Rights.
	/// </param>
	/// <param name="lpLockStatus">
	/// A pointer to a QUERY_SERVICE_LOCK_STATUS structure that receives the lock status of the specified database is returned, plus the
	/// strings to which its members point.
	/// </param>
	/// <param name="cbBufSize">The size of the buffer pointed to by the lpLockStatus parameter, in bytes.</param>
	/// <param name="pcbBytesNeeded">
	/// A pointer to a variable that receives the number of bytes needed to return all the lock status information, if the function fails.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the service control manager. Other error codes can be set by the registry functions that
	/// are called by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle does not have the SC_MANAGER_QUERY_LOCK_STATUS access right.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// There is more lock status information than would fit into the lpLockStatus buffer. The number of bytes required to get all the
	/// information is returned in the pcbBytesNeeded parameter. Nothing is written to lpLockStatus.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>QueryServiceLockStatus</c> function returns a QUERY_SERVICE_LOCK_STATUS structure that indicates whether the specified
	/// database is locked. If the database is locked, the structure provides the account name of the user that owns the lock and the
	/// length of time that the lock has been held.
	/// </para>
	/// <para>
	/// A process calls the LockServiceDatabase function to acquire ownership of a service control manager database lock and the
	/// UnlockServiceDatabase function to release the lock.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-queryservicelockstatusa BOOL QueryServiceLockStatusA(
	// SC_HANDLE hSCManager, LPQUERY_SERVICE_LOCK_STATUSA lpLockStatus, DWORD cbBufSize, LPDWORD pcbBytesNeeded );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "5139d31b-65f1-41ba-852a-91eab1dc366e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QueryServiceLockStatus(SC_HANDLE hSCManager, IntPtr lpLockStatus, uint cbBufSize, out uint pcbBytesNeeded);

	/// <summary>
	/// The <c>QueryServiceObjectSecurity</c> function retrieves a copy of the security descriptor associated with a service object. You
	/// can also use the GetNamedSecurityInfo function to retrieve a security descriptor.
	/// </summary>
	/// <param name="hService">
	/// A handle to the service control manager or the service. Handles to the service control manager are returned by the OpenSCManager
	/// function, and handles to a service are returned by either the OpenService or CreateService function. The handle must have the
	/// READ_CONTROL access right.
	/// </param>
	/// <param name="dwSecurityInformation">
	/// A set of bit flags that indicate the type of security information to retrieve. This parameter can be a combination of the
	/// SECURITY_INFORMATION bit flags, with the exception that this function does not support the <c>LABEL_SECURITY_INFORMATION</c> value.
	/// </param>
	/// <param name="lpSecurityDescriptor">
	/// A pointer to a buffer that receives a copy of the security descriptor of the specified service object. The calling process must
	/// have the appropriate access to view the specified aspects of the security descriptor of the object. The SECURITY_DESCRIPTOR
	/// structure is returned in self-relative format.
	/// </param>
	/// <param name="cbBufSize">
	/// The size of the buffer pointed to by the lpSecurityDescriptor parameter, in bytes. The largest size allowed is 8 kilobytes.
	/// </param>
	/// <param name="pcbBytesNeeded">
	/// A pointer to a variable that receives the number of bytes needed to return the requested security descriptor information, if the
	/// function fails.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes may be set by the service control manager. Other error codes may be set by the registry functions that
	/// are called by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The specified handle was not opened with READ_CONTROL access, or the calling process is not the owner of the object.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// The security descriptor information is too large for the lpSecurityDescriptor buffer. The number of bytes required to get all the
	/// information is returned in the pcbBytesNeeded parameter. Nothing is written to the lpSecurityDescriptor buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified security information is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When a service is created, the service control manager assigns a default security descriptor to the service object. To retrieve a
	/// copy of the security descriptor for a service object, call the <c>QueryServiceObjectSecurity</c> function. To change the security
	/// descriptor, call the SetServiceObjectSecurity function. For a description of the default security descriptor for a service
	/// object, see Service Security and Access Rights.
	/// </para>
	/// <para>
	/// To read the owner, group, or DACL from the security descriptor of the service object, the calling process must have been granted
	/// READ_CONTROL access when the handle was opened. To get READ_CONTROL access, the caller must be the owner of the object or the
	/// DACL of the object must grant the access.
	/// </para>
	/// <para>
	/// To read the SACL from the security descriptor, the calling process must have been granted ACCESS_SYSTEM_SECURITY access when the
	/// handle was opened. The correct way to get this access is to enable the SE_SECURITY_NAME privilege in the caller's current token,
	/// open the handle for ACCESS_SYSTEM_SECURITY access, and then disable the privilege.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-queryserviceobjectsecurity BOOL QueryServiceObjectSecurity(
	// SC_HANDLE hService, SECURITY_INFORMATION dwSecurityInformation, PSECURITY_DESCRIPTOR lpSecurityDescriptor, DWORD cbBufSize,
	// LPDWORD pcbBytesNeeded );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsvc.h", MSDNShortId = "5d95945f-f11b-42af-b302-8d924917b9ab")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QueryServiceObjectSecurity(SC_HANDLE hService, SECURITY_INFORMATION dwSecurityInformation, PSECURITY_DESCRIPTOR lpSecurityDescriptor, uint cbBufSize, out uint pcbBytesNeeded);

	/// <summary>
	/// <para>Retrieves the current status of the specified service.</para>
	/// <para>
	/// This function has been superseded by the QueryServiceStatusEx function. <c>QueryServiceStatusEx</c> returns the same information
	/// <c>QueryServiceStatus</c> returns, with the addition of the process identifier and additional information for the service.
	/// </para>
	/// </summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the OpenService or the CreateService function, and it must have the
	/// SERVICE_QUERY_STATUS access right. For more information, see Service Security and Access Rights.
	/// </param>
	/// <param name="lpServiceStatus">A pointer to a SERVICE_STATUS structure that receives the status information.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the service control manager. Other error codes can be set by the registry functions that
	/// are called by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle does not have the SERVICE_QUERY_STATUS access right.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The <c>QueryServiceStatus</c> function returns the most recent service status information reported to the service control
	/// manager. If the service just changed its status, it may not have updated the service control manager yet.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-queryservicestatus BOOL QueryServiceStatus( SC_HANDLE
	// hService, LPSERVICE_STATUS lpServiceStatus );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsvc.h", MSDNShortId = "dcd2d8a1-10ef-4229-b873-b4fc3ec9293f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QueryServiceStatus(SC_HANDLE hService, out SERVICE_STATUS lpServiceStatus);

	/// <summary>Retrieves the current status of the specified service based on the specified information level.</summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the CreateService or OpenService function, and it must have the
	/// SERVICE_QUERY_STATUS access right. For more information, see Service Security and Access Rights.
	/// </param>
	/// <param name="InfoLevel">
	/// <para>
	/// The service attributes to be returned. Use SC_STATUS_PROCESS_INFO to retrieve the service status information. The lpBuffer
	/// parameter is a pointer to a SERVICE_STATUS_PROCESS structure.
	/// </para>
	/// <para>Currently, no other information levels are defined.</para>
	/// </param>
	/// <param name="lpBuffer">
	/// <para>
	/// A pointer to the buffer that receives the status information. The format of this data depends on the value of the InfoLevel parameter.
	/// </para>
	/// <para>
	/// The maximum size of this array is 8K bytes. To determine the required size, specify NULL for this parameter and 0 for the
	/// cbBufSize parameter. The function will fail and GetLastError will return ERROR_INSUFFICIENT_BUFFER. The pcbBytesNeeded parameter
	/// will receive the required size.
	/// </para>
	/// </param>
	/// <param name="cbBufSize">The size of the buffer pointed to by the lpBuffer parameter, in bytes.</param>
	/// <param name="pcbBytesNeeded">
	/// A pointer to a variable that receives the number of bytes needed to store all status information, if the function fails with ERROR_INSUFFICIENT_BUFFER.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following errors can
	/// be returned.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle does not have the SERVICE_QUERY_STATUS access right.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is too small for the SERVICE_STATUS_PROCESS structure. Nothing was written to the structure.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The cbSize member of SERVICE_STATUS_PROCESS is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_LEVEL</term>
	/// <term>The InfoLevel parameter contains an unsupported value.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SHUTDOWN_IN_PROGRESS</term>
	/// <term>The system is shutting down; this function cannot be called.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>QueryServiceStatusEx</c> function returns the most recent service status information reported to the service control
	/// manager. If the service just changed its status, it may not have updated the service control manager yet.
	/// </para>
	/// <para>
	/// The process identifier returned in the SERVICE_STATUS_PROCESS structure is valid provided that the state of the service is one of
	/// SERVICE_RUNNING, SERVICE_PAUSE_PENDING, SERVICE_PAUSED, or SERVICE_CONTINUE_PENDING. If the service is in a SERVICE_START_PENDING
	/// or SERVICE_STOP_PENDING state, however, the process identifier may not be valid, and if the service is in the SERVICE_STOPPED
	/// state, it is never valid.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Starting a Service or Stopping a Service.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-queryservicestatusex BOOL QueryServiceStatusEx( SC_HANDLE
	// hService, SC_STATUS_TYPE InfoLevel, LPBYTE lpBuffer, DWORD cbBufSize, LPDWORD pcbBytesNeeded );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsvc.h", MSDNShortId = "3fe02245-97b1-49f3-8f35-2dcd6f221547")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QueryServiceStatusEx(SC_HANDLE hService, SC_STATUS_TYPE InfoLevel, [Optional] IntPtr lpBuffer, uint cbBufSize, out uint pcbBytesNeeded);

	/// <summary>Retrieves the current status of the specified service based on the specified information level.</summary>
	/// <typeparam name="T">The type of the structure to return. This must align to the structured defined by <paramref name="InfoLevel"/>.</typeparam>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the CreateService or OpenService function, and it must have the
	/// SERVICE_QUERY_STATUS access right. For more information, see Service Security and Access Rights.
	/// </param>
	/// <param name="InfoLevel">
	/// <para>
	/// The service attributes to be returned. Use SC_STATUS_PROCESS_INFO to retrieve the service status information. The lpBuffer
	/// parameter is a pointer to a SERVICE_STATUS_PROCESS structure.
	/// </para>
	/// <para>Currently, no other information levels are defined.</para>
	/// </param>
	/// <returns>
	/// A variable that receives the service status information. The format of this data depends on the value of the dwInfoLevel parameter.
	/// </returns>
	/// <exception cref="ArgumentException">Type mismatch - T</exception>
	public static T QueryServiceStatusEx<T>(SC_HANDLE hService, SC_STATUS_TYPE InfoLevel = SC_STATUS_TYPE.SC_STATUS_PROCESS_INFO) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanGet(InfoLevel, typeof(T))) throw new ArgumentException("Type mismatch", nameof(T));
		var b = QueryServiceStatusEx(hService, InfoLevel, IntPtr.Zero, 0, out var size);
		if (!b && Win32Error.GetLastError() != Win32Error.ERROR_INSUFFICIENT_BUFFER) Win32Error.ThrowLastError();
		using var buf = new SafeHGlobalHandle((int)size);
		if (!QueryServiceStatusEx(hService, InfoLevel, (IntPtr)buf, size, out size)) Win32Error.ThrowLastError();
		return buf.ToStructure<T>();
	}

	/// <summary>
	/// <para>Registers a function to handle service control requests.</para>
	/// <para>
	/// This function has been superseded by the RegisterServiceCtrlHandlerEx function. A service can use either function, but the new
	/// function supports user-defined context data, and the new handler function supports additional extended control codes.
	/// </para>
	/// </summary>
	/// <param name="lpServiceName">
	/// <para>
	/// The name of the service run by the calling thread. This is the service name that the service control program specified in the
	/// CreateService function when creating the service.
	/// </para>
	/// <para>
	/// If the service type is SERVICE_WIN32_OWN_PROCESS, the function does not verify that the specified name is valid, because there is
	/// only one registered service in the process.
	/// </para>
	/// </param>
	/// <param name="lpHandlerProc">
	/// <para>A pointer to the handler function to be registered. For more information, see Handler.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a service status handle.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following error codes can be set by the service control manager.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Not enough memory is available to convert an ANSI string parameter to Unicode. This error does not occur for Unicode string parameters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_IN_EXE</term>
	/// <term>The service entry was specified incorrectly when the process called the StartServiceCtrlDispatcher function.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The ServiceMain function of a new service should immediately call the <c>RegisterServiceCtrlHandler</c> function to register a
	/// control handler function with the control dispatcher. This enables the control dispatcher to invoke the specified function when
	/// it receives control requests for this service. For a list of possible control codes, see Handler. The threads of the calling
	/// process can use the service status handle returned by this function to identify the service in subsequent calls to the
	/// SetServiceStatus function.
	/// </para>
	/// <para>
	/// The <c>RegisterServiceCtrlHandler</c> function must be called before the first SetServiceStatus call because
	/// <c>RegisterServiceCtrlHandler</c> returns a service status handle for the caller to use so that no other service can
	/// inadvertently set this service status. In addition, the control handler must be in place to receive control requests by the time
	/// the service specifies the controls it accepts through the <c>SetServiceStatus</c> function.
	/// </para>
	/// <para>
	/// When the control handler function is invoked with a control request, the service must call SetServiceStatus to report status to
	/// the service control manager only if the service status has changed, such as when the service is processing stop or shutdown
	/// controls. If the service status has not changed, the service should not report status to the service control manager.
	/// </para>
	/// <para>The service status handle does not have to be closed.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Writing a ServiceMain Function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-registerservicectrlhandlera SERVICE_STATUS_HANDLE
	// RegisterServiceCtrlHandlerA( LPCSTR lpServiceName, LPHANDLER_FUNCTION lpHandlerProc );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "31ec28fe-8774-48fc-91ba-6fa43108e2cc")]
	public static extern SERVICE_STATUS_HANDLE RegisterServiceCtrlHandler(string lpServiceName, Handler lpHandlerProc);

	/// <summary>
	/// <para>Registers a function to handle extended service control requests.</para>
	/// </summary>
	/// <param name="lpServiceName">
	/// <para>
	/// The name of the service run by the calling thread. This is the service name that the service control program specified in the
	/// CreateService function when creating the service.
	/// </para>
	/// </param>
	/// <param name="lpHandlerProc">
	/// <para>A pointer to the handler function to be registered. For more information, see HandlerEx.</para>
	/// </param>
	/// <param name="lpContext">
	/// <para>
	/// Any user-defined data. This parameter, which is passed to the handler function, can help identify the service when multiple
	/// services share a process.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a service status handle.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following error codes can be set by the service control manager.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Not enough memory is available to convert an ANSI string parameter to Unicode. This error does not occur for Unicode string parameters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_IN_EXE</term>
	/// <term>The service entry was specified incorrectly when the process called the StartServiceCtrlDispatcher function.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The ServiceMain function of a new service should immediately call the <c>RegisterServiceCtrlHandlerEx</c> function to register a
	/// control handler function with the control dispatcher. This enables the control dispatcher to invoke the specified function when
	/// it receives control requests for this service. For a list of possible control codes, see HandlerEx. The threads of the calling
	/// process can use the service status handle returned by this function to identify the service in subsequent calls to the
	/// SetServiceStatus function.
	/// </para>
	/// <para>
	/// The <c>RegisterServiceCtrlHandlerEx</c> function must be called before the first SetServiceStatus call because
	/// <c>RegisterServiceCtrlHandlerEx</c> returns a service status handle for the caller to use so that no other service can
	/// inadvertently set this service status. In addition, the control handler must be in place to receive control requests by the time
	/// the service specifies the controls it accepts through the <c>SetServiceStatus</c> function.
	/// </para>
	/// <para>
	/// When the control handler function is invoked with a control request, the service must call SetServiceStatus to report status to
	/// the service control manager only if the service status has changed, such as when the service is processing stop or shutdown
	/// controls. If the service status has not changed, the service should not report status to the service control manager.
	/// </para>
	/// <para>The service status handle does not have to be closed.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-registerservicectrlhandlerexa SERVICE_STATUS_HANDLE
	// RegisterServiceCtrlHandlerExA( LPCSTR lpServiceName, LPHANDLER_FUNCTION_EX lpHandlerProc, LPVOID lpContext );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "23eea346-9899-4214-88f4-9b7eb7ce1332")]
	public static extern SERVICE_STATUS_HANDLE RegisterServiceCtrlHandlerEx(string lpServiceName, HandlerEx lpHandlerProc, [Optional] IntPtr lpContext);

	/// <summary>
	/// Registers a service type with the service control manager and the Server service. The Server service can then announce the
	/// registered service type as one it currently supports. The NetServerGetInfo and NetServerEnum functions obtain a specified
	/// machine's supported service types.
	/// </summary>
	/// <param name="hServiceStatus">
	/// A handle to the status information structure for the service. A service obtains the handle by calling the
	/// RegisterServiceCtrlHandlerEx function.
	/// </param>
	/// <param name="dwServiceBits">
	/// <para>The service type.</para>
	/// <para>
	/// Certain bit flags (0xC00F3F7B) are reserved for use by Microsoft. The <c>SetServiceBits</c> function fails with the error
	/// ERROR_INVALID_DATA if any of these bit flags are set in dwServiceBits. The following bit flags are reserved for use by Microsoft.
	/// </para>
	/// <para>SV_TYPE_WORKSTATION (0x00000001)</para>
	/// <para>SV_TYPE_SERVER (0x00000002)</para>
	/// <para>SV_TYPE_DOMAIN_CTRL (0x00000008)</para>
	/// <para>SV_TYPE_DOMAIN_BAKCTRL (0x00000010)</para>
	/// <para>SV_TYPE_TIME_SOURCE (0x00000020)</para>
	/// <para>SV_TYPE_AFP (0x00000040)</para>
	/// <para>SV_TYPE_DOMAIN_MEMBER (0x00000100)</para>
	/// <para>SV_TYPE_PRINTQ_SERVER (0x00000200)</para>
	/// <para>SV_TYPE_DIALIN_SERVER (0x00000400)</para>
	/// <para>SV_TYPE_XENIX_SERVER (0x00000800)</para>
	/// <para>SV_TYPE_SERVER_UNIX (0x00000800)</para>
	/// <para>SV_TYPE_NT (0x00001000)</para>
	/// <para>SV_TYPE_WFW (0x00002000)</para>
	/// <para>SV_TYPE_POTENTIAL_BROWSER (0x00010000)</para>
	/// <para>SV_TYPE_BACKUP_BROWSER (0x00020000)</para>
	/// <para>SV_TYPE_MASTER_BROWSER (0x00040000)</para>
	/// <para>SV_TYPE_DOMAIN_MASTER (0x00080000)</para>
	/// <para>SV_TYPE_LOCAL_LIST_ONLY (0x40000000)</para>
	/// <para>SV_TYPE_DOMAIN_ENUM (0x80000000)</para>
	/// <para>
	/// Certain bit flags (0x00300084) are defined by Microsoft, but are not specifically reserved for systems software. The following
	/// are these bit flags.
	/// </para>
	/// <para>SV_TYPE_SV_TYPE_SQLSERVER (0x00000004)</para>
	/// <para>SV_TYPE_NOVELL (0x00000080)</para>
	/// <para>SV_TYPE_DOMAIN_CTRL (0x00100000)</para>
	/// <para>SV_TYPE_DOMAIN_BAKCTRL (0x00200000)</para>
	/// <para>
	/// Certain bit flags (0x3FC0C000) are not defined by Microsoft, and their use is not coordinated by Microsoft. Developers of
	/// applications that use these bits should be aware that other applications can also use them, thus creating a conflict. The
	/// following are these bit flags.
	/// </para>
	/// <para>0x00004000</para>
	/// <para>0x00008000</para>
	/// <para>0x00400000</para>
	/// <para>0x00800000</para>
	/// <para>0x01000000</para>
	/// <para>0x02000000</para>
	/// <para>0x04000000</para>
	/// <para>0x08000000</para>
	/// <para>0x10000000</para>
	/// <para>0x20000000</para>
	/// </param>
	/// <param name="bSetBitsOn">
	/// If this value is TRUE, the bits in dwServiceBit are to be set. If this value is FALSE, the bits are to be cleared.
	/// </param>
	/// <param name="bUpdateImmediately">
	/// If this value is TRUE, the Server service is to perform an immediate update. If this value is FALSE, the update is not be
	/// performed immediately.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/nf-lmserver-setservicebits BOOL NET_API_FUNCTION SetServiceBits( IN
	// SERVICE_STATUS_HANDLE hServiceStatus, IN DWORD dwServiceBits, IN BOOL bSetBitsOn, IN BOOL bUpdateImmediately );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("lmserver.h", MSDNShortId = "91a985d4-d1af-4161-ae67-a8a9d6740838")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetServiceBits([In] SERVICE_STATUS_HANDLE hServiceStatus, uint dwServiceBits, [MarshalAs(UnmanagedType.Bool)] bool bSetBitsOn, [MarshalAs(UnmanagedType.Bool)] bool bUpdateImmediately);

	/// <summary>
	/// <para>
	/// [ <c>SetServiceObjectSecurity</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions. Instead, use the SetNamedSecurityInfo function.]
	/// </para>
	/// <para>The <c>SetServiceObjectSecurity</c> function sets the security descriptor of a service object.</para>
	/// </summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the OpenService or CreateService function. The access required for this
	/// handle depends on the security information specified in the dwSecurityInformation parameter.
	/// </param>
	/// <param name="dwSecurityInformation">
	/// Specifies the components of the security descriptor to set. This parameter can be a combination of the following values. Note
	/// that flags not handled by <c>SetServiceObjectSecurity</c> will be silently ignored.
	/// </param>
	/// <param name="lpSecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure that contains the new security information.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the service control manager. Other error codes can be set by the registry functions that
	/// are called by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The specified handle was not opened with the required access, or the calling process is not the owner of the object.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified security information or security descriptor is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_MARKED_FOR_DELETE</term>
	/// <term>The specified service has been marked for deletion.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SetServiceObjectSecurity</c> function sets the specified portions of the security descriptor of the service object based
	/// on the information specified in the lpSecurityDescriptor buffer. This function replaces any or all of the security information
	/// associated with the service object, according to the flags set in the dwSecurityInformation parameter and subject to the access
	/// rights of the calling process.
	/// </para>
	/// <para>
	/// When a service is created, the service control manager assigns a default security descriptor to the service object. To retrieve a
	/// copy of the security descriptor for a service object, call the QueryServiceObjectSecurity function. For a description of the
	/// default security descriptor for a service object, see Service Security and Access Rights.
	/// </para>
	/// <para>
	/// Note that granting certain access to untrusted users (such as SERVICE_CHANGE_CONFIG or SERVICE_STOP) can allow them to interfere
	/// with the execution of your service and possibly allow them to run applications under the LocalSystem account.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-setserviceobjectsecurity BOOL SetServiceObjectSecurity(
	// SC_HANDLE hService, SECURITY_INFORMATION dwSecurityInformation, PSECURITY_DESCRIPTOR lpSecurityDescriptor );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsvc.h", MSDNShortId = "39481d9a-79d5-4bbf-8480-4095a34dddb6")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetServiceObjectSecurity(SC_HANDLE hService, SECURITY_INFORMATION dwSecurityInformation, PSECURITY_DESCRIPTOR lpSecurityDescriptor);

	/// <summary>
	/// <para>Updates the service control manager's status information for the calling service.</para>
	/// </summary>
	/// <param name="hServiceStatus">
	/// <para>
	/// A handle to the status information structure for the current service. This handle is returned by the RegisterServiceCtrlHandlerEx function.
	/// </para>
	/// </param>
	/// <param name="lpServiceStatus">
	/// <para>A pointer to the SERVICE_STATUS structure the contains the latest status information for the calling service.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the service control manager. Other error codes can be set by the registry functions that
	/// are called by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>The specified service status structure is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A ServiceMain function first calls the RegisterServiceCtrlHandlerEx function to get the service's SERVICE_STATUS_HANDLE. Then it
	/// immediately calls the <c>SetServiceStatus</c> function to notify the service control manager that its status is
	/// SERVICE_START_PENDING. During initialization, the service can provide updated status to indicate that it is making progress but
	/// it needs more time. A common bug is for the service to have the main thread perform the initialization while a separate thread
	/// continues to call <c>SetServiceStatus</c> to prevent the service control manager from marking it as hung. However, if the main
	/// thread hangs, then the service start ends up in an infinite loop because the worker thread continues to report that the main
	/// thread is making progress.
	/// </para>
	/// <para>
	/// After processing a control request, the service's Handler function must call <c>SetServiceStatus</c> if the service status
	/// changes to report its new status to the service control manager. It is only necessary to do so when the service is changing
	/// state, such as when it is processing stop or shutdown controls. A service can also use this function at any time from any thread
	/// of the service to notify the service control manager of state changes, such as when the service must stop due to a recoverable error.
	/// </para>
	/// <para>A service can call this function only after it has called RegisterServiceCtrlHandlerEx to get a service status handle.</para>
	/// <para>
	/// If a service calls <c>SetServiceStatus</c> with the <c>dwCurrentState</c> member set to SERVICE_STOPPED and the
	/// <c>dwWin32ExitCode</c> member set to a nonzero value, the following entry is written into the System event log:
	/// </para>
	/// <para>The following are best practices when calling this function:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Initialize all fields in the SERVICE_STATUS structure, ensuring that there are valid check-point and wait hint values for pending
	/// states. Use reasonable wait hints.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Do not register to accept controls while the status is SERVICE_START_PENDING or the service can crash. After initialization is
	/// completed, accept the SERVICE_CONTROL_STOP code.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Call this function with checkpoint and wait-hint values only if the service is making progress on the tasks related to the
	/// pending start, stop, pause, or continue operation. Otherwise, SCM cannot detect if your service is hung.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Enter the stopped state with an appropriate exit code if ServiceMain fails.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If the status is SERVICE_STOPPED, perform all necessary cleanup and call <c>SetServiceStatus</c> one time only. This function
	/// makes an LRPC call to the SCM. The first call to the function in the SERVICE_STOPPED state closes the RPC context handle and any
	/// subsequent calls can cause the process to crash.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Do not attempt to perform any additional work after calling <c>SetServiceStatus</c> with SERVICE_STOPPED, because the service
	/// process can be terminated at any time.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example, see Writing a ServiceMain Function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-setservicestatus BOOL SetServiceStatus(
	// SERVICE_STATUS_HANDLE hServiceStatus, LPSERVICE_STATUS lpServiceStatus );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsvc.h", MSDNShortId = "bb5943ff-2814-40f2-bee0-ae7132befde9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetServiceStatus(SERVICE_STATUS_HANDLE hServiceStatus, in SERVICE_STATUS lpServiceStatus);

	/// <summary>Starts a service.</summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the OpenService or CreateService function, and it must have the SERVICE_START
	/// access right. For more information, see Service Security and Access Rights.
	/// </param>
	/// <param name="dwNumServiceArgs">
	/// The number of strings in the lpServiceArgVectors array. If lpServiceArgVectors is NULL, this parameter can be zero.
	/// </param>
	/// <param name="lpServiceArgVectors">
	/// <para>
	/// The null-terminated strings to be passed to the ServiceMain function for the service as arguments. If there are no arguments,
	/// this parameter can be NULL. Otherwise, the first argument (lpServiceArgVectors[0]) is the name of the service, followed by any
	/// additional arguments (lpServiceArgVectors[1] through lpServiceArgVectors[dwNumServiceArgs-1]).
	/// </para>
	/// <para>Driver services do not receive these arguments.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the service control manager. Others can be set by the registry functions that are called
	/// by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The handle does not have the SERVICE_START access right.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PATH_NOT_FOUND</term>
	/// <term>The service binary file could not be found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_ALREADY_RUNNING</term>
	/// <term>An instance of the service is already running.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_DATABASE_LOCKED</term>
	/// <term>The database is locked.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_DEPENDENCY_DELETED</term>
	/// <term>The service depends on a service that does not exist or has been marked for deletion.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_DEPENDENCY_FAIL</term>
	/// <term>The service depends on another service that has failed to start.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_DISABLED</term>
	/// <term>The service has been disabled.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_LOGON_FAILED</term>
	/// <term>
	/// The service did not start due to a logon failure. This error occurs if the service is configured to run under an account that
	/// does not have the "Log on as a service" right.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_MARKED_FOR_DELETE</term>
	/// <term>The service has been marked for deletion.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NO_THREAD</term>
	/// <term>A thread could not be created for the service.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_REQUEST_TIMEOUT</term>
	/// <term>
	/// The process for the service was started, but it did not call StartServiceCtrlDispatcher, or the thread that called
	/// StartServiceCtrlDispatcher may be blocked in a control handler function.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When a driver service is started, the <c>StartService</c> function does not return until the device driver has finished initializing.
	/// </para>
	/// <para>
	/// When a service is started, the Service Control Manager (SCM) spawns the service process, if necessary. If the specified service
	/// shares a process with other services, the required process may already exist. The <c>StartService</c> function does not wait for
	/// the first status update from the new service, because it can take a while. Instead, it returns when the SCM receives notification
	/// from the service control dispatcher that the ServiceMain thread for this service was created successfully.
	/// </para>
	/// <para>The SCM sets the following default status values before returning from <c>StartService</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Current state of the service is set to SERVICE_START_PENDING.</term>
	/// </item>
	/// <item>
	/// <term>Controls accepted is set to none (zero).</term>
	/// </item>
	/// <item>
	/// <term>The CheckPoint value is set to zero.</term>
	/// </item>
	/// <item>
	/// <term>The WaitHint time is set to 2 seconds.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The calling process can determine if the new service has finished its initialization by calling the QueryServiceStatus function
	/// periodically to query the service's status.
	/// </para>
	/// <para>
	/// A service cannot call <c>StartService</c> during initialization. The reason is that the SCM locks the service control database
	/// during initialization, so a call to <c>StartService</c> will block. After the service reports to the SCM that it has successfully
	/// started, it can call <c>StartService</c>.
	/// </para>
	/// <para>
	/// As with ControlService, <c>StartService</c> will block for 30 seconds if any service is busy handling a control code. If the busy
	/// service still has not returned from its handler function when the timeout expires, <c>StartService</c> fails with
	/// ERROR_SERVICE_REQUEST_TIMEOUT. This is because the SCM processes only one service control notification at a time.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Starting a Service.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-startservicea BOOL StartServiceA( SC_HANDLE hService, DWORD
	// dwNumServiceArgs, LPCSTR *lpServiceArgVectors );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "f185a878-e1c3-4fe5-8ec9-c5296d27f985")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool StartService(SC_HANDLE hService, [Optional] int dwNumServiceArgs, [Optional] string[]? lpServiceArgVectors);

	/// <summary>
	/// Connects the main thread of a service process to the service control manager, which causes the thread to be the service control
	/// dispatcher thread for the calling process.
	/// </summary>
	/// <param name="lpServiceStartTable">
	/// A pointer to an array of SERVICE_TABLE_ENTRY structures containing one entry for each service that can execute in the calling
	/// process. The members of the last entry in the table must have NULL values to designate the end of the table.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error code can be set by the service control manager. Other error codes can be set by the registry functions that
	/// are called by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FAILED_SERVICE_CONTROLLER_CONNECT</term>
	/// <term>
	/// This error is returned if the program is being run as a console application rather than as a service. If the program will be run
	/// as a console application for debugging purposes, structure it such that service-specific code is not called when this error is returned.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>The specified dispatch table contains entries that are not in the proper format.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_ALREADY_RUNNING</term>
	/// <term>The process has already called StartServiceCtrlDispatcher. Each process can call StartServiceCtrlDispatcher only one time.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When the service control manager starts a service process, it waits for the process to call the <c>StartServiceCtrlDispatcher</c>
	/// function. The main thread of a service process should make this call as soon as possible after it starts up (within 30 seconds).
	/// If <c>StartServiceCtrlDispatcher</c> succeeds, it connects the calling thread to the service control manager and does not return
	/// until all running services in the process have entered the SERVICE_STOPPED state. The service control manager uses this
	/// connection to send control and service start requests to the main thread of the service process. The main thread acts as a
	/// dispatcher by invoking the appropriate HandlerEx function to handle control requests, or by creating a new thread to execute the
	/// appropriate ServiceMain function when a new service is started.
	/// </para>
	/// <para>
	/// The lpServiceTable parameter contains an entry for each service that can run in the calling process. Each entry specifies the
	/// ServiceMain function for that service. For SERVICE_WIN32_SHARE_PROCESS services, each entry must contain the name of a service.
	/// This name is the service name that was specified by the CreateService function when the service was installed. For
	/// SERVICE_WIN32_OWN_PROCESS services, the service name in the table entry is ignored.
	/// </para>
	/// <para>
	/// If a service runs in its own process, the main thread of the service process should immediately call
	/// <c>StartServiceCtrlDispatcher</c>. All initialization tasks are done in the service's ServiceMain function when the service is started.
	/// </para>
	/// <para>
	/// If multiple services share a process and some common process-wide initialization needs to be done before any ServiceMain function
	/// is called, the main thread can do the work before calling <c>StartServiceCtrlDispatcher</c>, as long as it takes less than 30
	/// seconds. Otherwise, another thread must be created to do the process-wide initialization, while the main thread calls
	/// <c>StartServiceCtrlDispatcher</c> and becomes the service control dispatcher. Any service-specific initialization should still be
	/// done in the individual service main functions.
	/// </para>
	/// <para>Services should not attempt to display a user interface directly. For more information, see Interactive Services.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Writing a Service Program's Main Function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-startservicectrldispatchera BOOL
	// StartServiceCtrlDispatcherA( const SERVICE_TABLE_ENTRYA *lpServiceStartTable );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winsvc.h", MSDNShortId = "8e275eb7-a8af-4bd7-bb39-0eac4f3735ad")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool StartServiceCtrlDispatcher([In, MarshalAs(UnmanagedType.LPArray)] SERVICE_TABLE_ENTRY[] lpServiceStartTable);

	/// <summary>Stops a service using <see cref="ControlService"/> with <see cref="ServiceControl.SERVICE_CONTROL_STOP"/></summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService(SC_HANDLE, string, string, uint, ServiceTypes, ServiceStartType, ServiceErrorControlType, string, string, IntPtr, string[], string, string)"/> function. The
	/// access rights required for this handle depend on the <see cref="ServiceControl"/> code requested.
	/// </param>
	/// <param name="lpServiceStatus">
	/// A pointer to a <see cref="SERVICE_STATUS"/> structure that receives the latest service status information. The information
	/// returned reflects the most recent status that the service reported to the service control manager.
	/// </param>
	/// <returns></returns>
	public static bool StopService(SC_HANDLE hService, out SERVICE_STATUS lpServiceStatus) =>
		ControlService(hService, ServiceControl.SERVICE_CONTROL_STOP, out lpServiceStatus);

	/// <summary>Stops a service using <see cref="ControlServiceEx"/> with <see cref="ServiceControl.SERVICE_CONTROL_STOP"/></summary>
	/// <param name="hService">
	/// A handle to the service. This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService(SC_HANDLE, string, string, uint, ServiceTypes, ServiceStartType, ServiceErrorControlType, string, string, IntPtr, string[], string, string)"/> function. The
	/// access rights required for this handle depend on the <see cref="ServiceControl"/> code requested.
	/// </param>
	/// <param name="reason">A reason and comment for why the service is being stopped</param>
	/// <returns></returns>
	public static bool StopService(SC_HANDLE hService, ref SERVICE_CONTROL_STATUS_REASON_PARAMS reason) =>
		ControlServiceEx(hService, ServiceControl.SERVICE_CONTROL_STOP, ServiceInfoLevels.SERVICE_CONTROL_STATUS_REASON_INFO, ref reason);

	/// <summary>
	/// <para>[This function has no effect as of Windows Vista.]</para>
	/// <para>Unlocks a service control manager database by releasing the specified lock.</para>
	/// </summary>
	/// <param name="ScLock">The lock, which is obtained from a previous call to the LockServiceDatabase function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The following error codes can be set by the service control manager. Other error codes can be set by the registry functions that
	/// are called by the service control manager.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_SERVICE_LOCK</term>
	/// <term>The specified lock is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-unlockservicedatabase BOOL UnlockServiceDatabase( SC_LOCK
	// ScLock );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsvc.h", MSDNShortId = "3277d175-ab0b-43ce-965f-f8087d0124e4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UnlockServiceDatabase(SC_LOCK ScLock);

	/// <summary>
	/// Contains the name of a service in a service control manager database and information about that service. It is used by the
	/// EnumDependentServices and EnumServicesStatus functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_enum_service_statusa typedef struct _ENUM_SERVICE_STATUSA {
	// LPSTR lpServiceName; LPSTR lpDisplayName; SERVICE_STATUS ServiceStatus; } ENUM_SERVICE_STATUSA, *LPENUM_SERVICE_STATUSA;
	[PInvokeData("winsvc.h", MSDNShortId = "b088bd94-5d25-44a7-93c0-80ce6588b811")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ENUM_SERVICE_STATUS
	{
		/// <summary>
		/// The name of a service in the service control manager database. The maximum string length is 256 characters. The service
		/// control manager database preserves the case of the characters, but service name comparisons are always case insensitive. A
		/// slash (/), backslash (), comma, and space are invalid service name characters.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpServiceName;

		/// <summary>
		/// A display name that can be used by service control programs, such as Services in Control Panel, to identify the service. This
		/// string has a maximum length of 256 characters. The name is case-preserved in the service control manager. Display name
		/// comparisons are always case-insensitive.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpDisplayName;

		/// <summary>A SERVICE_STATUS structure that contains status information for the <c>lpServiceName</c> service.</summary>
		public SERVICE_STATUS ServiceStatus;
	}

	/// <summary>
	/// Contains the name of a service in a service control manager database and information about the service. It is used by the
	/// EnumServicesStatusEx function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_enum_service_status_processa typedef struct
	// _ENUM_SERVICE_STATUS_PROCESSA { LPSTR lpServiceName; LPSTR lpDisplayName; SERVICE_STATUS_PROCESS ServiceStatusProcess; }
	// ENUM_SERVICE_STATUS_PROCESSA, *LPENUM_SERVICE_STATUS_PROCESSA;
	[PInvokeData("winsvc.h", MSDNShortId = "6a683cc8-c2ac-4093-aed7-33e6bdd02d79")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ENUM_SERVICE_STATUS_PROCESS
	{
		/// <summary>
		/// The name of a service in the service control manager database. The maximum string length is 256 characters. The service
		/// control manager database preserves the case of the characters, but service name comparisons are always case insensitive. A
		/// slash (/), backslash (), comma, and space are invalid service name characters.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpServiceName;

		/// <summary>
		/// A display name that can be used by service control programs, such as Services in Control Panel, to identify the service. This
		/// string has a maximum length of 256 characters. The case is preserved in the service control manager. Display name comparisons
		/// are always case-insensitive.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpDisplayName;

		/// <summary>A SERVICE_STATUS_PROCESS structure that contains status information for the <c>lpServiceName</c> service.</summary>
		public SERVICE_STATUS_PROCESS ServiceStatusProcess;
	}

	/// <summary>Contains configuration information for an installed service. It is used by the QueryServiceConfig function.</summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	[PInvokeData("Winsvc.h", MSDNShortId = "ms684950")]
	public struct QUERY_SERVICE_CONFIG
	{
		/// <summary>The type of service.</summary>
		public ServiceTypes dwServiceType;

		/// <summary>When to start the service.</summary>
		public ServiceStartType dwStartType;

		/// <summary>The severity of the error, and action taken, if this service fails to start.</summary>
		public ServiceErrorControlType dwErrorControl;

		/// <summary>
		/// The fully qualified path to the service binary file.
		/// <para>
		/// The path can also include arguments for an auto-start service.These arguments are passed to the service entry point
		/// (typically the main function).
		/// </para>
		/// </summary>
		public string lpBinaryPathName;

		/// <summary>
		/// The name of the load ordering group to which this service belongs. If the member is NULL or an empty string, the service does
		/// not belong to a load ordering group.
		/// <para>
		/// The startup program uses load ordering groups to load groups of services in a specified order with respect to the other
		/// groups.The list of load ordering groups is contained in the following registry value:
		/// </para>
		/// <para><c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\ServiceGroupOrder</c></para>
		/// </summary>
		public string lpLoadOrderGroup;

		/// <summary>
		/// A unique tag value for this service in the group specified by the lpLoadOrderGroup parameter. A value of zero indicates that
		/// the service has not been assigned a tag. You can use a tag for ordering service startup within a load order group by
		/// specifying a tag order vector in the registry located at:
		/// <para><c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\GroupOrderList</c></para>
		/// <para>
		/// Tags are only evaluated for SERVICE_KERNEL_DRIVER and SERVICE_FILE_SYSTEM_DRIVER type services that have SERVICE_BOOT_START
		/// or SERVICE_SYSTEM_START start types.
		/// </para>
		/// </summary>
		public uint dwTagID;

		/// <summary>
		/// A pointer to an array of null-separated names of services or load ordering groups that must start before this service. The
		/// array is doubly null-terminated. If the pointer is NULL or if it points to an empty string, the service has no dependencies.
		/// If a group name is specified, it must be prefixed by the SC_GROUP_IDENTIFIER (defined in WinSvc.h) character to differentiate
		/// it from a service name, because services and service groups share the same name space. Dependency on a service means that
		/// this service can only run if the service it depends on is running. Dependency on a group means that this service can run if
		/// at least one member of the group is running after an attempt to start all members of the group.
		/// </summary>
		public IntPtr lpDependencies;

		/// <summary>
		/// If the service type is SERVICE_WIN32_OWN_PROCESS or SERVICE_WIN32_SHARE_PROCESS, this member is the name of the account that
		/// the service process will be logged on as when it runs. This name can be of the form Domain\UserName. If the account belongs
		/// to the built-in domain, the name can be of the form .\UserName. The name can also be "LocalSystem" if the process is running
		/// under the LocalSystem account.
		/// <para>
		/// If the service type is SERVICE_KERNEL_DRIVER or SERVICE_FILE_SYSTEM_DRIVER, this member is the driver object name(that is,
		/// \FileSystem\Rdr or \Driver\Xns) which the input and output(I/O) system uses to load the device driver.If this member is NULL,
		/// the driver is to be run with a default object name created by the I/O system, based on the service name.
		/// </para>
		/// </summary>
		public string lpServiceStartName;

		/// <summary>
		/// The display name to be used by service control programs to identify the service. This string has a maximum length of 256
		/// characters. The name is case-preserved in the service control manager. Display name comparisons are always case-insensitive.
		/// <para>This parameter can specify a localized string using the following format:</para>
		/// <para>@[Path] DLLName,-StrID</para>
		/// <para>The string with identifier StrID is loaded from DLLName; the Path is optional.For more information, see RegLoadMUIString.</para>
		/// <para>Windows Server 2003 and Windows XP: Localized strings are not supported until Windows Vista.</para>
		/// </summary>
		public string lpDisplayName;

		/// <summary/>
		public IEnumerable<string> Dependencies => lpDependencies.ToStringEnum();
	}

	/// <summary>
	/// Contains information about the lock status of a service control manager database. It is used by the QueryServiceLockStatus function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-query_service_lock_statusw typedef struct
	// _QUERY_SERVICE_LOCK_STATUSW { DWORD fIsLocked; LPWSTR lpLockOwner; DWORD dwLockDuration; } QUERY_SERVICE_LOCK_STATUSW, *LPQUERY_SERVICE_LOCK_STATUSW;
	[PInvokeData("winsvc.h", MSDNShortId = "de9797b7-02b0-43cb-bed3-50b7e8676f36")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct QUERY_SERVICE_LOCK_STATUS
	{
		/// <summary>
		/// The lock status of the database. If this member is nonzero, the database is locked. If it is zero, the database is unlocked.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fIsLocked;

		/// <summary>The name of the user who acquired the lock.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpLockOwner;

		/// <summary>The time since the lock was first acquired, in seconds.</summary>
		public uint dwLockDuration;
	}

	/// <summary>
	/// <para>Represents an action that the service control manager can perform.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// This structure is used by the <see cref="ChangeServiceConfig2"/> and <see cref="QueryServiceConfig2"/> functions, in the
	/// SERVICE_FAILURE_ACTIONS structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_sc_action typedef struct _SC_ACTION { SC_ACTION_TYPE Type;
	// DWORD Delay; } SC_ACTION, *LPSC_ACTION;
	[PInvokeData("winsvc.h", MSDNShortId = "e2c355a6-affe-46bf-a3e6-f8c420422d46")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SC_ACTION
	{
		/// <summary>
		/// <para>
		/// The action to be performed. This member can be one of the following values from the <c>SC_ACTION_TYPE</c> enumeration type.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SC_ACTION_NONE 0</term>
		/// <term>No action.</term>
		/// </item>
		/// <item>
		/// <term>SC_ACTION_REBOOT 2</term>
		/// <term>Reboot the computer.</term>
		/// </item>
		/// <item>
		/// <term>SC_ACTION_RESTART 1</term>
		/// <term>Restart the service.</term>
		/// </item>
		/// <item>
		/// <term>SC_ACTION_RUN_COMMAND 3</term>
		/// <term>Run a command.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SC_ACTION_TYPE Type;

		/// <summary>
		/// <para>The time to wait before performing the specified action, in milliseconds.</para>
		/// </summary>
		public uint Delay;
	}

	/// <summary>Contains service control parameters.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-service_control_status_reason_paramsa typedef struct
	// _SERVICE_CONTROL_STATUS_REASON_PARAMSA { DWORD dwReason; LPSTR pszComment; SERVICE_STATUS_PROCESS ServiceStatus; }
	// SERVICE_CONTROL_STATUS_REASON_PARAMSA, *PSERVICE_CONTROL_STATUS_REASON_PARAMSA;
	[PInvokeData("winsvc.h", MSDNShortId = "f7213cbb-255f-4ce3-93c9-5537256e078f")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct SERVICE_CONTROL_STATUS_REASON_PARAMS
	{
		/// <summary>
		/// <para>
		/// The reason for changing the service status to SERVICE_CONTROL_STOP. If the current control code is not SERVICE_CONTROL_STOP,
		/// this member is ignored.
		/// </para>
		/// <para>This member must be set to a combination of one general code, one major reason code, and one minor reason code.</para>
		/// <para>The following are the general reason codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_STOP_REASON_FLAG_CUSTOM 0x20000000</term>
		/// <term>
		/// The reason code is defined by the user. If this flag is not present, the reason code is defined by the system. If this flag
		/// is specified with a system reason code, the function call fails. Users can create custom major reason codes in the range
		/// SERVICE_STOP_REASON_MAJOR_MIN_CUSTOM (0x00400000) through SERVICE_STOP_REASON_MAJOR_MAX_CUSTOM (0x00ff0000) and minor reason
		/// codes in the range SERVICE_STOP_REASON_MINOR_MIN_CUSTOM (0x00000100) through SERVICE_STOP_REASON_MINOR_MAX_CUSTOM (0x0000FFFF).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_FLAG_PLANNED 0x40000000</term>
		/// <term>The service stop was planned.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_FLAG_UNPLANNED 0x10000000</term>
		/// <term>The service stop was not planned.</term>
		/// </item>
		/// </list>
		/// <para>The following are the major reason codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MAJOR_APPLICATION 0x00050000</term>
		/// <term>Application issue.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MAJOR_HARDWARE 0x00020000</term>
		/// <term>Hardware issue.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MAJOR_NONE 0x00060000</term>
		/// <term>No major reason.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MAJOR_OPERATINGSYSTEM 0x00030000</term>
		/// <term>Operating system issue.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MAJOR_OTHER 0x00010000</term>
		/// <term>Other issue.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MAJOR_SOFTWARE 0x00040000</term>
		/// <term>Software issue.</term>
		/// </item>
		/// </list>
		/// <para>The following are the minor reason codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_DISK 0x00000008</term>
		/// <term>Disk.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_ENVIRONMENT 0x0000000a</term>
		/// <term>Environment.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_HARDWARE_DRIVER 0x0000000b</term>
		/// <term>Driver.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_HUNG 0x00000006</term>
		/// <term>Unresponsive.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_INSTALLATION 0x00000003</term>
		/// <term>Installation.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_MAINTENANCE 0x00000002</term>
		/// <term>Maintenance.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_MMC 0x00000016</term>
		/// <term>MMC issue.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_NETWORK_CONNECTIVITY 0x00000011</term>
		/// <term>Network connectivity.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_NETWORKCARD 0x00000009</term>
		/// <term>Network card.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_NONE 0x00060000</term>
		/// <term>No minor reason.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_OTHER 0x00000001</term>
		/// <term>Other issue.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_OTHERDRIVER 0x0000000c</term>
		/// <term>Other driver event.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_RECONFIG 0x00000005</term>
		/// <term>Reconfigure.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_SECURITY 0x00000010</term>
		/// <term>Security issue.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_SECURITYFIX 0x0000000f</term>
		/// <term>Security update.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_SECURITYFIX_UNINSTALL 0x00000015</term>
		/// <term>Security update uninstall.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_SERVICEPACK 0x0000000d</term>
		/// <term>Service pack.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_SERVICEPACK_UNINSTALL 0x00000013</term>
		/// <term>Service pack uninstall.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_SOFTWARE_UPDATE 0x0000000e</term>
		/// <term>Software update.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_SOFTWARE_UPDATE_UNINSTALL 0x0000000e</term>
		/// <term>Software update uninstall.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_UNSTABLE 0x00000007</term>
		/// <term>Unstable.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_UPGRADE 0x00000004</term>
		/// <term>Upgrade.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_REASON_MINOR_WMI 0x00000012</term>
		/// <term>WMI issue.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SERVICE_STOP_REASON dwReason;

		/// <summary>
		/// An optional string that provides additional information about the service stop. This string is stored in the event log along
		/// with the stop reason code. This member must be <c>NULL</c> or a valid string that is less than 128 characters, including the
		/// terminating null character.
		/// </summary>
		public string pszComment;

		/// <summary>
		/// <para>
		/// A pointer to a SERVICE_STATUS_PROCESS structure that receives the latest service status information. The information returned
		/// reflects the most recent status that the service reported to the service control manager.
		/// </para>
		/// <para>
		/// The service control manager fills in the structure only when ControlServiceEx returns one of the following error codes:
		/// NO_ERROR, ERROR_INVALID_SERVICE_CONTROL, ERROR_SERVICE_CANNOT_ACCEPT_CTRL, or ERROR_SERVICE_NOT_ACTIVE. Otherwise, the
		/// structure is not filled in.
		/// </para>
		/// </summary>
		public SERVICE_STATUS_PROCESS serviceStatus;
	}

	/// <summary>
	/// <para>Contains the delayed auto-start setting of an auto-start service.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Any service can be marked as a delayed auto-start service; however, this setting has no effect unless the service is an
	/// auto-start service. The change takes effect the next time the system is started.
	/// </para>
	/// <para>
	/// The service control manager (SCM) supports delayed auto-start services to improve system performance at boot time without
	/// affecting the user experience. The SCM makes a list of delayed auto-start services during boot and starts them one at a time
	/// after the delay has passed, honoring dependencies. There is no specific time guarantee as to when the service will be started. To
	/// minimize the impact on the user, the ServiceMain thread for the service is started with THREAD_PRIORITY_LOWEST. Threads that are
	/// started by the ServiceMain thread should also be run at a low priority. After the service has reported that it has entered the
	/// SERVICE_RUNNING state, the priority of the ServiceMain thread is raised to THREAD_PRIORITY_NORMAL.
	/// </para>
	/// <para>
	/// A delayed auto-start service cannot be a member of a load ordering group. It can depend on another auto-start service. An
	/// auto-start service can depend on a delayed auto-start service, but this is not generally desirable as the SCM must start the
	/// dependent delayed auto-start service at boot.
	/// </para>
	/// <para>
	/// If a delayed auto-start service is demand-started using the StartService function shortly after boot, the system starts the
	/// service on demand instead of delaying its start further. If this situation is likely to occur on a regular basis, the service
	/// should not be marked as a delayed auto-start service.
	/// </para>
	/// <para>
	/// If a client calls a delayed auto-start service before it is loaded, the call fails. Therefore, clients should be prepared to
	/// either retry the call or demand start the service.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_service_delayed_auto_start_info typedef struct
	// _SERVICE_DELAYED_AUTO_START_INFO { BOOL fDelayedAutostart; } SERVICE_DELAYED_AUTO_START_INFO, *LPSERVICE_DELAYED_AUTO_START_INFO;
	[PInvokeData("winsvc.h", MSDNShortId = "16117450-eb73-47de-8be7-c7aff3d44c81")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_DELAYED_AUTO_START_INFO
	{
		/// <summary>
		/// <para>
		/// If this member is <c>TRUE</c>, the service is started after other auto-start services are started plus a short delay.
		/// Otherwise, the service is started during system boot.
		/// </para>
		/// <para>This setting is ignored unless the service is an auto-start service.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fDelayedAutostart;
	}

	/// <summary>Contains a service description.</summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	[PInvokeData("Winsvc.h", MSDNShortId = "ms685156")]
	public struct SERVICE_DESCRIPTION
	{
		/// <summary>
		/// The description of the service. If this member is NULL, the description remains unchanged. If this value is an empty string
		/// (""), the current description is deleted.
		/// <para>The service description must not exceed the size of a registry value of type REG_SZ.</para>
		/// <para>This member can specify a localized string using the following format:</para>
		/// <para>@[path\]dllname,-strID</para>
		/// <para>The string with identifier strID is loaded from dllname; the path is optional. For more information, see RegLoadMUIString.</para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> Localized strings are not supported until Windows Vista.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpDescription;
	}

	/// <summary>
	/// <para>
	/// Represents the action the service controller should take on each failure of a service. A service is considered failed when it
	/// terminates without reporting a status of <c>SERVICE_STOPPED</c> to the service controller.
	/// </para>
	/// <para>To configure additional circumstances under which the failure actions are to be executed, see SERVICE_FAILURE_ACTIONS_FLAG.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The service control manager counts the number of times each service has failed since the system booted. The count is reset to 0
	/// if the service has not failed for <c>dwResetPeriod</c> seconds. When the service fails for the Nth time, the service controller
	/// performs the action specified in element [N-1] of the <c>lpsaActions</c> array. If N is greater than cActions, the service
	/// controller repeats the last action in the array.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_service_failure_actionsa typedef struct
	// _SERVICE_FAILURE_ACTIONSA { DWORD dwResetPeriod; LPSTR lpRebootMsg; LPSTR lpCommand; DWORD cActions; SC_ACTION *lpsaActions; }
	// SERVICE_FAILURE_ACTIONSA, *LPSERVICE_FAILURE_ACTIONSA;
	[PInvokeData("winsvc.h", MSDNShortId = "180ca6d9-f2c3-4ea1-b2c6-319d08ef88ee")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct SERVICE_FAILURE_ACTIONS
	{
		/// <summary>
		/// <para>
		/// The time after which to reset the failure count to zero if there are no failures, in seconds. Specify <c>INFINITE</c> to
		/// indicate that this value should never be reset.
		/// </para>
		/// </summary>
		public uint dwResetPeriod;

		/// <summary>
		/// <para>
		/// The message to be broadcast to server users before rebooting in response to the <c>SC_ACTION_REBOOT</c> service controller action.
		/// </para>
		/// <para>
		/// If this value is <c>NULL</c>, the reboot message is unchanged. If the value is an empty string (""), the reboot message is
		/// deleted and no message is broadcast.
		/// </para>
		/// <para>This member can specify a localized string using the following format:</para>
		/// <para>@[path]dllname,-strID</para>
		/// <para>The string with identifier strID is loaded from dllname; the path is optional. For more information, see RegLoadMUIString.</para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> Localized strings are not supported until Windows Vista.</para>
		/// </summary>
		public string lpRebootMsg;

		/// <summary>
		/// <para>
		/// The command line of the process for the CreateProcess function to execute in response to the <c>SC_ACTION_RUN_COMMAND</c>
		/// service controller action. This process runs under the same account as the service.
		/// </para>
		/// <para>
		/// If this value is <c>NULL</c>, the command is unchanged. If the value is an empty string (""), the command is deleted and no
		/// program is run when the service fails.
		/// </para>
		/// </summary>
		public string lpCommand;

		/// <summary>
		/// <para>The number of elements in the <c>lpsaActions</c> array.</para>
		/// <para>If this value is 0, but <c>lpsaActions</c> is not NULL, the reset period and array of failure actions are deleted.</para>
		/// </summary>
		public uint cActions;

		/// <summary>
		/// <para>A pointer to an array of SC_ACTION structures.</para>
		/// <para>If this value is NULL, the <c>cActions</c> and <c>dwResetPeriod</c> members are ignored.</para>
		/// </summary>
		public IntPtr lpsaActions;

		/// <summary/>
		public SC_ACTION[] Actions => lpsaActions.ToArray<SC_ACTION>((int)cActions) ?? new SC_ACTION[0];
	}

	/// <summary>
	/// <para>Contains the failure actions flag setting of a service. This setting determines when failure actions are to be executed.</para>
	/// </summary>
	/// <remarks>
	/// <para>The change takes effect the next time the system is started.</para>
	/// <para>
	/// It can be useful to set this flag if your service has common failure paths where is it possible that the service could recover.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_service_failure_actions_flag typedef struct
	// _SERVICE_FAILURE_ACTIONS_FLAG { BOOL fFailureActionsOnNonCrashFailures; } SERVICE_FAILURE_ACTIONS_FLAG, *LPSERVICE_FAILURE_ACTIONS_FLAG;
	[PInvokeData("winsvc.h", MSDNShortId = "49736b26-9565-4d56-abcd-1585b692ff12")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_FAILURE_ACTIONS_FLAG
	{
		/// <summary>
		/// <para>
		/// If this member is <c>TRUE</c> and the service has configured failure actions, the failure actions are queued if the service
		/// process terminates without reporting a status of SERVICE_STOPPED or if it enters the SERVICE_STOPPED state but the
		/// <c>dwWin32ExitCode</c> member of the SERVICE_STATUS structure is not ERROR_SUCCESS (0).
		/// </para>
		/// <para>
		/// If this member is <c>FALSE</c> and the service has configured failure actions, the failure actions are queued only if the
		/// service terminates without reporting a status of SERVICE_STOPPED.
		/// </para>
		/// <para>
		/// This setting is ignored unless the service has configured failure actions. For information on configuring failure actions,
		/// see ChangeServiceConfig2.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fFailureActionsOnNonCrashFailures;
	}

	/// <summary>
	/// <para>Indicates a service protection type.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// This structure is used by the ChangeServiceConfig2 function to specify the protection type of the service, and it is used with
	/// QueryServiceConfig2 to retrieve service configuration information for protected services. In order to apply any protection type
	/// to a service, the service must be signed with an appropriate certificate.
	/// </para>
	/// <para>
	/// The <c>SERVICE_LAUNCH_PROTECTED_WINDOWS</c> and <c>SERVICE_LAUNCH_PROTECTED_WINDOWS_LIGHT</c> protection types are reserved for
	/// internal Windows use only.
	/// </para>
	/// <para>
	/// The <c>SERVICE_LAUNCH_PROTECTED_ANTIMALWARE_LIGHT</c> protection type can be used by the anti-malware vendors to launch their
	/// anti-malware service as protected. See Protecting Anti-Malware Services for more info.
	/// </para>
	/// <para>
	/// Once the service is launched as protected, other unprotected processes will not be able to call the following APIs on the
	/// protected service.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ChangeServiceConfig</term>
	/// </item>
	/// <item>
	/// <term>ChangeServiceConfig2</term>
	/// </item>
	/// <item>
	/// <term>ControlService</term>
	/// </item>
	/// <item>
	/// <term>ControlServiceEx</term>
	/// </item>
	/// <item>
	/// <term>DeleteService</term>
	/// </item>
	/// <item>
	/// <term>SetServiceObjectSecurity</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_service_launch_protected_info typedef struct
	// _SERVICE_LAUNCH_PROTECTED_INFO { DWORD dwLaunchProtected; } SERVICE_LAUNCH_PROTECTED_INFO, *PSERVICE_LAUNCH_PROTECTED_INFO;
	[PInvokeData("winsvc.h", MSDNShortId = "ECD44E9F-BE48-4038-94B4-37C8CA5C89F7")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_LAUNCH_PROTECTED_INFO
	{
		/// <summary>
		/// <para>The protection type of the service. This member can be one of the following values:</para>
		/// <para>SERVICE_LAUNCH_PROTECTED_NONE (0)</para>
		/// <para>SERVICE_LAUNCH_PROTECTED_WINDOWS (1)</para>
		/// <para>SERVICE_LAUNCH_PROTECTED_WINDOWS_LIGHT (2)</para>
		/// <para>SERVICE_LAUNCH_PROTECTED_ANTIMALWARE_LIGHT (3)</para>
		/// </summary>
		public uint dwLaunchProtected;
	}

	/// <summary>Represents service status notification information. It is used by the NotifyServiceStatusChange function.</summary>
	/// <remarks>
	/// <para>The callback function is declared as follows:</para>
	/// <para>The callback function receives a pointer to the <c>SERVICE_NOTIFY</c> structure provided by the caller.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_service_notify_2a typedef struct _SERVICE_NOTIFY_2A { DWORD
	// dwVersion; PFN_SC_NOTIFY_CALLBACK pfnNotifyCallback; PVOID pContext; DWORD dwNotificationStatus; SERVICE_STATUS_PROCESS
	// ServiceStatus; DWORD dwNotificationTriggered; LPSTR pszServiceNames; } SERVICE_NOTIFY_2A, *PSERVICE_NOTIFY_2A;
	[PInvokeData("winsvc.h", MSDNShortId = "52ede72e-eb50-48e2-b5c1-125816f6fe57")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct SERVICE_NOTIFY_2
	{
		/// <summary>The structure version. This member must be <c>SERVICE_NOTIFY_STATUS_CHANGE</c> (2).</summary>
		public uint dwVersion;

		/// <summary>A pointer to the callback function. For more information, see Remarks.</summary>
		public IntPtr pfnNotifyCallback;

		/// <summary>Any user-defined data to be passed to the callback function.</summary>
		public IntPtr pContext;

		/// <summary>
		/// A value that indicates the notification status. If this member is <c>ERROR_SUCCESS</c>, the notification has succeeded and
		/// the <c>ServiceStatus</c> member contains valid information. If this member is <c>ERROR_SERVICE_MARKED_FOR_DELETE</c>, the
		/// service has been marked for deletion and the service handle used by NotifyServiceStatusChange must be closed.
		/// </summary>
		public Win32Error dwNotificationStatus;

		/// <summary>
		/// A SERVICE_STATUS_PROCESS structure that contains the service status information. This member is only valid if
		/// <c>dwNotificationStatus</c> is <c>ERROR_SUCCESS</c>.
		/// </summary>
		public SERVICE_STATUS_PROCESS ServiceStatus;

		/// <summary>
		/// If <c>dwNotificationStatus</c> is <c>ERROR_SUCCESS</c>, this member contains a bitmask of the notifications that triggered
		/// this call to the callback function.
		/// </summary>
		public SERVICE_NOTIFY_FLAGS dwNotificationTriggered;

		/// <summary>
		/// <para>
		/// If <c>dwNotificationStatus</c> is <c>ERROR_SUCCESS</c> and the notification is <c>SERVICE_NOTIFY_CREATED</c> or
		/// <c>SERVICE_NOTIFY_DELETED</c>, this member is valid and it is a <c>MULTI_SZ</c> string that contains one or more service
		/// names. The names of the created services will have a '/' prefix so you can distinguish them from the names of the deleted services.
		/// </para>
		/// <para>If this member is valid, the notification callback function must free the string using the LocalFree function.</para>
		/// </summary>
		public StrPtrAuto pszServiceNames;
	}

	/// <summary>
	/// <para>Represents the preferred node on which to run a service.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_service_preferred_node_info typedef struct
	// _SERVICE_PREFERRED_NODE_INFO { USHORT usPreferredNode; BOOLEAN fDelete; } SERVICE_PREFERRED_NODE_INFO, *LPSERVICE_PREFERRED_NODE_INFO;
	[PInvokeData("winsvc.h", MSDNShortId = "aa16cc56-0a95-47e0-9390-c219b83aeeb4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_PREFERRED_NODE_INFO
	{
		/// <summary>
		/// <para>The node number of the preferred node.</para>
		/// </summary>
		public ushort usPreferredNode;

		/// <summary>
		/// <para>If this member is TRUE, the preferred node setting is deleted.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool fDelete;
	}

	/// <summary>
	/// <para>Contains preshutdown settings.</para>
	/// </summary>
	/// <remarks>
	/// <para>The default preshutdown time-out value is 180,000 milliseconds (three minutes).</para>
	/// <para>
	/// After the service control manager sends the SERVICE_CONTROL_PRESHUTDOWN notification to the HandlerEx function, it waits for one
	/// of the following to occur before proceeding with other shutdown actions: the specified time elapses or the service enters the
	/// SERVICE_STOPPED state. The service can continue to update its status for as long as it is in the SERVICE_STOP_PENDING state.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_service_preshutdown_info typedef struct
	// _SERVICE_PRESHUTDOWN_INFO { DWORD dwPreshutdownTimeout; } SERVICE_PRESHUTDOWN_INFO, *LPSERVICE_PRESHUTDOWN_INFO;
	[PInvokeData("winsvc.h", MSDNShortId = "b9d2362c-e4d7-4072-88c2-5294b3838095")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_PRESHUTDOWN_INFO
	{
		/// <summary>
		/// <para>The time-out value, in milliseconds.</para>
		/// </summary>
		public uint dwPreshutdownTimeout;
	}

	/// <summary>
	/// <para>Represents the required privileges for a service.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The change in required privileges takes effect the next time the service is started. The SCM determines whether the service can
	/// support the specified privileges when it attempts to start the service.
	/// </para>
	/// <para>It is best to analyze your service and use the minimum set of privileges required.</para>
	/// <para>
	/// If you do not set the required privileges, the SCM uses all the privileges assigned by default to the process token. If you
	/// specify privileges for a service, the SCM will remove the privileges that are not required from the process token when the
	/// process starts. If multiple services share a process, the SCM computes the union of privileges required by all services in the process.
	/// </para>
	/// <para>
	/// For compatibility, the SeChangeNotifyPrivilege privilege is never removed from a process token, even if no service in the process
	/// has requested the privilege. Therefore, a service need not explicitly specify this privilege.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_service_required_privileges_infoa typedef struct
	// _SERVICE_REQUIRED_PRIVILEGES_INFOA { LPSTR pmszRequiredPrivileges; } SERVICE_REQUIRED_PRIVILEGES_INFOA, *LPSERVICE_REQUIRED_PRIVILEGES_INFOA;
	[PInvokeData("winsvc.h", MSDNShortId = "15a2e042-cfd5-443e-a3b8-822f48eb9654")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct SERVICE_REQUIRED_PRIVILEGES_INFO
	{
		/// <summary>
		/// <para>A multi-string that specifies the privileges. For a list of possible values, see Privilege Constants.</para>
		/// <para>
		/// A multi-string is a sequence of null-terminated strings, terminated by an empty string (\0). The following is an example: .
		/// </para>
		/// </summary>
		public string pmszRequiredPrivileges;
	}

	/// <summary>
	/// <para>Represents a service security identifier (SID).</para>
	/// </summary>
	/// <remarks>
	/// <para>The change takes effect the next time the system is started.</para>
	/// <para>The SCM adds the specified service SIDs to the process token, plus the following additional SIDs.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>SID</term>
	/// <term>Attributes</term>
	/// </listheader>
	/// <item>
	/// <term>Logon SID</term>
	/// <term>SE_GROUP_ENABLED | SE_GROUP_ENABLED_BY_DEFAULT | SE_GROUP_LOGON_ID | SE_GROUP_MANDATORY</term>
	/// </item>
	/// <item>
	/// <term>Local SID</term>
	/// <term>SE_GROUP_MANDATORY | SE_GROUP_ENABLED | SE_GROUP_ENABLED_BY_DEFAULT</term>
	/// </item>
	/// </list>
	/// <para>
	/// This enables developers to control access to the objects a service uses, instead of relying on the use of the LocalSystem account
	/// to obtain access.
	/// </para>
	/// <para>
	/// Use the LookupAccountName and LookupAccountSid functions to convert between a service name and a service SID. The account name is
	/// of the following form:
	/// </para>
	/// <para>NT SERVICE&lt;i&gt;SvcName</para>
	/// <para>Note that NT SERVICE is the domain name.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_service_sid_info typedef struct _SERVICE_SID_INFO { DWORD
	// dwServiceSidType; } SERVICE_SID_INFO, *LPSERVICE_SID_INFO;
	[PInvokeData("winsvc.h", MSDNShortId = "cb1a32bd-aafb-4e41-8d6f-673c3d747f14")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_SID_INFO
	{
		/// <summary>
		/// <para>The service SID type.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_SID_TYPE_NONE 0x00000000</term>
		/// <term>Use this type to reduce application compatibility issues.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_SID_TYPE_RESTRICTED 0x00000003</term>
		/// <term>
		/// This type includes SERVICE_SID_TYPE_UNRESTRICTED. The service SID is also added to the restricted SID list of the process
		/// token. Three additional SIDs are also added to the restricted SID list: One ACE that allows GENERIC_ALL access for the
		/// service logon SID is also added to the service process token object. If there are multiple services hosted in the same
		/// process and one service has SERVICE_SID_TYPE_RESTRICTED, all services must have SERVICE_SID_TYPE_RESTRICTED.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_SID_TYPE_UNRESTRICTED 0x00000001</term>
		/// <term>
		/// When the service process is created, the service SID is added to the service process token with the following attributes:
		/// SE_GROUP_ENABLED_BY_DEFAULT | SE_GROUP_OWNER.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwServiceSidType;
	}

	/// <summary/>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct SERVICE_START_REASON
	{
		/// <summary/>
		public readonly ServiceStartReason dwReason;
	}

	/// <summary>
	/// <para>
	/// Contains status information for a service. The ControlService, EnumDependentServices, EnumServicesStatus, and QueryServiceStatus
	/// functions use this structure. A service uses this structure in the SetServiceStatus function to report its current status to the
	/// service control manager.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_service_status typedef struct _SERVICE_STATUS { DWORD
	// dwServiceType; DWORD dwCurrentState; DWORD dwControlsAccepted; DWORD dwWin32ExitCode; DWORD dwServiceSpecificExitCode; DWORD
	// dwCheckPoint; DWORD dwWaitHint; } SERVICE_STATUS, *LPSERVICE_STATUS;
	[PInvokeData("winsvc.h", MSDNShortId = "d268609b-d442-4d0f-9d49-ed23fee84961")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_STATUS
	{
		/// <summary>
		/// <para>The type of service. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_FILE_SYSTEM_DRIVER 0x00000002</term>
		/// <term>The service is a file system driver.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_KERNEL_DRIVER 0x00000001</term>
		/// <term>The service is a device driver.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_WIN32_OWN_PROCESS 0x00000010</term>
		/// <term>The service runs in its own process.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_WIN32_SHARE_PROCESS 0x00000020</term>
		/// <term>The service shares a process with other services.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_USER_OWN_PROCESS 0x00000050</term>
		/// <term>The service runs in its own process under the logged-on user account.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_USER_SHARE_PROCESS 0x00000060</term>
		/// <term>The service shares a process with one or more other services that run under the logged-on user account.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the service type is either SERVICE_WIN32_OWN_PROCESS or SERVICE_WIN32_SHARE_PROCESS, and the service is running in the
		/// context of the LocalSystem account, the following type may also be specified.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_INTERACTIVE_PROCESS 0x00000100</term>
		/// <term>The service can interact with the desktop. For more information, see Interactive Services.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ServiceTypes dwServiceType;

		/// <summary>
		/// <para>The current state of the service. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_CONTINUE_PENDING 0x00000005</term>
		/// <term>The service continue is pending.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_PAUSE_PENDING 0x00000006</term>
		/// <term>The service pause is pending.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_PAUSED 0x00000007</term>
		/// <term>The service is paused.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_RUNNING 0x00000004</term>
		/// <term>The service is running.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_START_PENDING 0x00000002</term>
		/// <term>The service is starting.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_PENDING 0x00000003</term>
		/// <term>The service is stopping.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOPPED 0x00000001</term>
		/// <term>The service is not running.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ServiceState dwCurrentState;

		/// <summary>
		/// <para>
		/// The control codes the service accepts and processes in its handler function (see Handler and HandlerEx). A user interface
		/// process can control a service by specifying a control command in the ControlService or ControlServiceEx function. By default,
		/// all services accept the <c>SERVICE_CONTROL_INTERROGATE</c> value.
		/// </para>
		/// <para>
		/// To accept the <c>SERVICE_CONTROL_DEVICEEVENT</c> value, the service must register to receive device events by using the
		/// RegisterDeviceNotification function.
		/// </para>
		/// <para>The following are the control codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Control code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_ACCEPT_NETBINDCHANGE 0x00000010</term>
		/// <term>
		/// The service is a network component that can accept changes in its binding without being stopped and restarted. This control
		/// code allows the service to receive SERVICE_CONTROL_NETBINDADD, SERVICE_CONTROL_NETBINDREMOVE, SERVICE_CONTROL_NETBINDENABLE,
		/// and SERVICE_CONTROL_NETBINDDISABLE notifications.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_PARAMCHANGE 0x00000008</term>
		/// <term>
		/// The service can reread its startup parameters without being stopped and restarted. This control code allows the service to
		/// receive SERVICE_CONTROL_PARAMCHANGE notifications.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_PAUSE_CONTINUE 0x00000002</term>
		/// <term>
		/// The service can be paused and continued. This control code allows the service to receive SERVICE_CONTROL_PAUSE and
		/// SERVICE_CONTROL_CONTINUE notifications.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_PRESHUTDOWN 0x00000100</term>
		/// <term>
		/// The service can perform preshutdown tasks. This control code enables the service to receive SERVICE_CONTROL_PRESHUTDOWN
		/// notifications. Note that ControlService and ControlServiceEx cannot send this notification; only the system can send it.
		/// Windows Server 2003 and Windows XP: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_SHUTDOWN 0x00000004</term>
		/// <term>
		/// The service is notified when system shutdown occurs. This control code allows the service to receive SERVICE_CONTROL_SHUTDOWN
		/// notifications. Note that ControlService and ControlServiceEx cannot send this notification; only the system can send it.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_STOP 0x00000001</term>
		/// <term>The service can be stopped. This control code allows the service to receive SERVICE_CONTROL_STOP notifications.</term>
		/// </item>
		/// </list>
		/// <para>
		/// This member can also contain the following extended control codes, which are supported only by HandlerEx. (Note that these
		/// control codes cannot be sent by ControlService or ControlServiceEx.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Control code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_ACCEPT_HARDWAREPROFILECHANGE 0x00000020</term>
		/// <term>
		/// The service is notified when the computer's hardware profile has changed. This enables the system to send
		/// SERVICE_CONTROL_HARDWAREPROFILECHANGE notifications to the service.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_POWEREVENT 0x00000040</term>
		/// <term>
		/// The service is notified when the computer's power status has changed. This enables the system to send
		/// SERVICE_CONTROL_POWEREVENT notifications to the service.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_SESSIONCHANGE 0x00000080</term>
		/// <term>
		/// The service is notified when the computer's session status has changed. This enables the system to send
		/// SERVICE_CONTROL_SESSIONCHANGE notifications to the service.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_TIMECHANGE 0x00000200</term>
		/// <term>
		/// The service is notified when the system time has changed. This enables the system to send SERVICE_CONTROL_TIMECHANGE
		/// notifications to the service. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This control code is
		/// not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_TRIGGEREVENT 0x00000400</term>
		/// <term>
		/// The service is notified when an event for which the service has registered occurs. This enables the system to send
		/// SERVICE_CONTROL_TRIGGEREVENT notifications to the service. Windows Server 2008, Windows Vista, Windows Server 2003 and
		/// Windows XP: This control code is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_USERMODEREBOOT 0x00000800</term>
		/// <term>
		/// The services is notified when the user initiates a reboot. Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows
		/// Vista, Windows Server 2003 and Windows XP: This control code is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ServiceAcceptedControlCodes dwControlsAccepted;

		/// <summary>
		/// <para>
		/// The error code the service uses to report an error that occurs when it is starting or stopping. To return an error code
		/// specific to the service, the service must set this value to <c>ERROR_SERVICE_SPECIFIC_ERROR</c> to indicate that the
		/// <c>dwServiceSpecificExitCode</c> member contains the error code. The service should set this value to <c>NO_ERROR</c> when it
		/// is running and on normal termination.
		/// </para>
		/// </summary>
		public Win32Error dwWin32ExitCode;

		/// <summary>
		/// <para>
		/// A service-specific error code that the service returns when an error occurs while the service is starting or stopping. This
		/// value is ignored unless the <c>dwWin32ExitCode</c> member is set to <c>ERROR_SERVICE_SPECIFIC_ERROR</c>.
		/// </para>
		/// </summary>
		public Win32Error dwServiceSpecificExitCode;

		/// <summary>
		/// <para>
		/// The check-point value the service increments periodically to report its progress during a lengthy start, stop, pause, or
		/// continue operation. For example, the service should increment this value as it completes each step of its initialization when
		/// it is starting up. The user interface program that invoked the operation on the service uses this value to track the progress
		/// of the service during a lengthy operation. This value is not valid and should be zero when the service does not have a start,
		/// stop, pause, or continue operation pending.
		/// </para>
		/// </summary>
		public uint dwCheckPoint;

		/// <summary>
		/// <para>
		/// The estimated time required for a pending start, stop, pause, or continue operation, in milliseconds. Before the specified
		/// amount of time has elapsed, the service should make its next call to the SetServiceStatus function with either an incremented
		/// <c>dwCheckPoint</c> value or a change in <c>dwCurrentState</c>. If the amount of time specified by <c>dwWaitHint</c> passes,
		/// and <c>dwCheckPoint</c> has not been incremented or <c>dwCurrentState</c> has not changed, the service control manager or
		/// service control program can assume that an error has occurred and the service should be stopped. However, if the service
		/// shares a process with other services, the service control manager cannot terminate the service application because it would
		/// have to terminate the other services sharing the process as well.
		/// </para>
		/// </summary>
		public uint dwWaitHint;
	}

	/// <summary>
	/// <para>
	/// Contains status information for a service. The ControlService, EnumDependentServices, EnumServicesStatus, and QueryServiceStatus
	/// functions use this structure. A service uses this structure in the SetServiceStatus function to report its current status to the
	/// service control manager.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-gb/windows/desktop/api/winsvc/ns-winsvc-_service_status_process typedef struct
	// _SERVICE_STATUS_PROCESS { DWORD dwServiceType; DWORD dwCurrentState; DWORD dwControlsAccepted; DWORD dwWin32ExitCode; DWORD
	// dwServiceSpecificExitCode; DWORD dwCheckPoint; DWORD dwWaitHint; DWORD dwProcessId; DWORD dwServiceFlags; }
	// SERVICE_STATUS_PROCESS, * LPSERVICE_STATUS_PROCESS;
	[PInvokeData("winsvc.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_STATUS_PROCESS
	{
		/// <summary>
		/// <para>The type of service. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_FILE_SYSTEM_DRIVER 0x00000002</term>
		/// <term>The service is a file system driver.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_KERNEL_DRIVER 0x00000001</term>
		/// <term>The service is a device driver.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_WIN32_OWN_PROCESS 0x00000010</term>
		/// <term>The service runs in its own process.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_WIN32_SHARE_PROCESS 0x00000020</term>
		/// <term>The service shares a process with other services.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_USER_OWN_PROCESS 0x00000050</term>
		/// <term>The service runs in its own process under the logged-on user account.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_USER_SHARE_PROCESS 0x00000060</term>
		/// <term>The service shares a process with one or more other services that run under the logged-on user account.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the service type is either SERVICE_WIN32_OWN_PROCESS or SERVICE_WIN32_SHARE_PROCESS, and the service is running in the
		/// context of the LocalSystem account, the following type may also be specified.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_INTERACTIVE_PROCESS 0x00000100</term>
		/// <term>The service can interact with the desktop. For more information, see Interactive Services.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ServiceTypes dwServiceType;

		/// <summary>
		/// <para>The current state of the service. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_CONTINUE_PENDING 0x00000005</term>
		/// <term>The service continue is pending.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_PAUSE_PENDING 0x00000006</term>
		/// <term>The service pause is pending.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_PAUSED 0x00000007</term>
		/// <term>The service is paused.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_RUNNING 0x00000004</term>
		/// <term>The service is running.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_START_PENDING 0x00000002</term>
		/// <term>The service is starting.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOP_PENDING 0x00000003</term>
		/// <term>The service is stopping.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_STOPPED 0x00000001</term>
		/// <term>The service is not running.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ServiceState dwCurrentState;

		/// <summary>
		/// <para>
		/// The control codes the service accepts and processes in its handler function (see Handler and HandlerEx). A user interface
		/// process can control a service by specifying a control command in the ControlService or ControlServiceEx function. By default,
		/// all services accept the <c>SERVICE_CONTROL_INTERROGATE</c> value.
		/// </para>
		/// <para>
		/// To accept the <c>SERVICE_CONTROL_DEVICEEVENT</c> value, the service must register to receive device events by using the
		/// RegisterDeviceNotification function.
		/// </para>
		/// <para>The following are the control codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Control code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_ACCEPT_NETBINDCHANGE 0x00000010</term>
		/// <term>
		/// The service is a network component that can accept changes in its binding without being stopped and restarted. This control
		/// code allows the service to receive SERVICE_CONTROL_NETBINDADD, SERVICE_CONTROL_NETBINDREMOVE, SERVICE_CONTROL_NETBINDENABLE,
		/// and SERVICE_CONTROL_NETBINDDISABLE notifications.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_PARAMCHANGE 0x00000008</term>
		/// <term>
		/// The service can reread its startup parameters without being stopped and restarted. This control code allows the service to
		/// receive SERVICE_CONTROL_PARAMCHANGE notifications.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_PAUSE_CONTINUE 0x00000002</term>
		/// <term>
		/// The service can be paused and continued. This control code allows the service to receive SERVICE_CONTROL_PAUSE and
		/// SERVICE_CONTROL_CONTINUE notifications.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_PRESHUTDOWN 0x00000100</term>
		/// <term>
		/// The service can perform preshutdown tasks. This control code enables the service to receive SERVICE_CONTROL_PRESHUTDOWN
		/// notifications. Note that ControlService and ControlServiceEx cannot send this notification; only the system can send it.
		/// Windows Server 2003 and Windows XP: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_SHUTDOWN 0x00000004</term>
		/// <term>
		/// The service is notified when system shutdown occurs. This control code allows the service to receive SERVICE_CONTROL_SHUTDOWN
		/// notifications. Note that ControlService and ControlServiceEx cannot send this notification; only the system can send it.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_STOP 0x00000001</term>
		/// <term>The service can be stopped. This control code allows the service to receive SERVICE_CONTROL_STOP notifications.</term>
		/// </item>
		/// </list>
		/// <para>
		/// This member can also contain the following extended control codes, which are supported only by HandlerEx. (Note that these
		/// control codes cannot be sent by ControlService or ControlServiceEx.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Control code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_ACCEPT_HARDWAREPROFILECHANGE 0x00000020</term>
		/// <term>
		/// The service is notified when the computer's hardware profile has changed. This enables the system to send
		/// SERVICE_CONTROL_HARDWAREPROFILECHANGE notifications to the service.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_POWEREVENT 0x00000040</term>
		/// <term>
		/// The service is notified when the computer's power status has changed. This enables the system to send
		/// SERVICE_CONTROL_POWEREVENT notifications to the service.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_SESSIONCHANGE 0x00000080</term>
		/// <term>
		/// The service is notified when the computer's session status has changed. This enables the system to send
		/// SERVICE_CONTROL_SESSIONCHANGE notifications to the service.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_TIMECHANGE 0x00000200</term>
		/// <term>
		/// The service is notified when the system time has changed. This enables the system to send SERVICE_CONTROL_TIMECHANGE
		/// notifications to the service. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This control code is
		/// not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_TRIGGEREVENT 0x00000400</term>
		/// <term>
		/// The service is notified when an event for which the service has registered occurs. This enables the system to send
		/// SERVICE_CONTROL_TRIGGEREVENT notifications to the service. Windows Server 2008, Windows Vista, Windows Server 2003 and
		/// Windows XP: This control code is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_ACCEPT_USERMODEREBOOT 0x00000800</term>
		/// <term>
		/// The services is notified when the user initiates a reboot. Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows
		/// Vista, Windows Server 2003 and Windows XP: This control code is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ServiceAcceptedControlCodes dwControlsAccepted;

		/// <summary>
		/// <para>
		/// The error code the service uses to report an error that occurs when it is starting or stopping. To return an error code
		/// specific to the service, the service must set this value to <c>ERROR_SERVICE_SPECIFIC_ERROR</c> to indicate that the
		/// <c>dwServiceSpecificExitCode</c> member contains the error code. The service should set this value to <c>NO_ERROR</c> when it
		/// is running and on normal termination.
		/// </para>
		/// </summary>
		public Win32Error dwWin32ExitCode;

		/// <summary>
		/// <para>
		/// A service-specific error code that the service returns when an error occurs while the service is starting or stopping. This
		/// value is ignored unless the <c>dwWin32ExitCode</c> member is set to <c>ERROR_SERVICE_SPECIFIC_ERROR</c>.
		/// </para>
		/// </summary>
		public uint dwServiceSpecificExitCode;

		/// <summary>
		/// <para>
		/// The check-point value the service increments periodically to report its progress during a lengthy start, stop, pause, or
		/// continue operation. For example, the service should increment this value as it completes each step of its initialization when
		/// it is starting up. The user interface program that invoked the operation on the service uses this value to track the progress
		/// of the service during a lengthy operation. This value is not valid and should be zero when the service does not have a start,
		/// stop, pause, or continue operation pending.
		/// </para>
		/// </summary>
		public uint dwCheckPoint;

		/// <summary>
		/// <para>
		/// The estimated time required for a pending start, stop, pause, or continue operation, in milliseconds. Before the specified
		/// amount of time has elapsed, the service should make its next call to the SetServiceStatus function with either an incremented
		/// <c>dwCheckPoint</c> value or a change in <c>dwCurrentState</c>. If the amount of time specified by <c>dwWaitHint</c> passes,
		/// and <c>dwCheckPoint</c> has not been incremented or <c>dwCurrentState</c> has not changed, the service control manager or
		/// service control program can assume that an error has occurred and the service should be stopped. However, if the service
		/// shares a process with other services, the service control manager cannot terminate the service application because it would
		/// have to terminate the other services sharing the process as well.
		/// </para>
		/// </summary>
		public uint dwWaitHint;

		/// <summary>The process identifier of the service.</summary>
		public uint dwProcessId;

		/// <summary>
		/// This member can be one of the following values. 0 = The service is running in a process that is not a system process, or it
		/// is not running. If the service is running in a process that is not a system process, dwProcessId is nonzero.If the service is
		/// not running, dwProcessId is zero. 1 = SERVICE_RUNS_IN_SYSTEM_PROCESS The service runs in a system process that must always be running.
		/// </summary>
		public uint dwServiceFlags;
	}

	/// <summary>
	/// Specifies the ServiceMain function for a service that can run in the calling process. It is used by the
	/// StartServiceCtrlDispatcher function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_service_table_entrya typedef struct _SERVICE_TABLE_ENTRYA {
	// LPSTR lpServiceName; LPSERVICE_MAIN_FUNCTIONA lpServiceProc; } SERVICE_TABLE_ENTRYA, *LPSERVICE_TABLE_ENTRYA;
	[PInvokeData("winsvc.h", MSDNShortId = "dd40c4f0-cbbe-429f-91c0-3ba141dab702")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct SERVICE_TABLE_ENTRY
	{
		/// <summary>
		/// <para>The name of a service to be run in this service process.</para>
		/// <para>
		/// If the service is installed with the SERVICE_WIN32_OWN_PROCESS service type, this member is ignored, but cannot be NULL. This
		/// member can be an empty string ("").
		/// </para>
		/// <para>
		/// If the service is installed with the SERVICE_WIN32_SHARE_PROCESS service type, this member specifies the name of the service
		/// that uses the ServiceMain function pointed to by the <c>lpServiceProc</c> member.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpServiceName;

		/// <summary>A pointer to a ServiceMain function.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public ServiceMain lpServiceProc;

		/// <summary>Initializes a new instance of the <see cref="SERVICE_TABLE_ENTRY"/> struct.</summary>
		/// <param name="serviceName">Name of the service.</param>
		/// <param name="serviceProc">The service proc.</param>
		public SERVICE_TABLE_ENTRY(string serviceName, ServiceMain serviceProc)
		{
			lpServiceName = serviceName;
			lpServiceProc = serviceProc;
		}
	}

	/// <summary>
	/// <para>Represents a service trigger event. This structure is used by the SERVICE_TRIGGER_INFO structure.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// On a system that is joined to a domain, security policy settings may prevent the BFE service and its dependent services from
	/// being stopped or cause them to restart automatically. In this case, it is necessary to disable the services and then re-enable
	/// them after the event is registered. To do this programmatically, store each service's original start type, change the service
	/// start type to SERVICE_DISABLED, register the event, and then restore the service's original start type. For information about
	/// changing a service's start type, see ChangeServiceConfig.
	/// </para>
	/// <para>
	/// To disable the services using the SC command-line tool, use the command <c>sc config bfe start= disabled</c> to disable the BFE
	/// service and its dependent services, then use the command <c>net stop bfe /Y</c> to stop them. To re-enable the services, use the
	/// command <c>sc config bfe start= auto</c>. For more information about the SC command-line tool, see Controlling a Service Using SC.
	/// </para>
	/// <para>
	/// If it is not possible to disable the services, it may be necessary to restart the system after installing the service that is
	/// registering the event. In this case, do not disable the BFE service and its dependent services before restarting the system,
	/// because the system may not work correctly if these services remain disabled.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_service_trigger typedef struct _SERVICE_TRIGGER { DWORD
	// dwTriggerType; DWORD dwAction; GUID *pTriggerSubtype; DWORD cDataItems; PSERVICE_TRIGGER_SPECIFIC_DATA_ITEM pDataItems; }
	// SERVICE_TRIGGER, *PSERVICE_TRIGGER;
	[PInvokeData("winsvc.h", MSDNShortId = "a57aa702-40a2-4880-80db-6c4f43c3e7ea")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_TRIGGER
	{
		/// <summary>
		/// <para>The trigger event type. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_TRIGGER_TYPE_CUSTOM 20</term>
		/// <term>
		/// The event is a custom event generated by an Event Tracing for Windows (ETW) provider. This trigger event can be used to start
		/// or stop a service. The pTriggerSubtype member specifies the event provider's GUID. The pDataItems member specifies
		/// trigger-specific data defined by the provider.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_TRIGGER_TYPE_DEVICE_INTERFACE_ARRIVAL 1</term>
		/// <term>
		/// The event is triggered when a device of the specified device interface class arrives or is present when the system starts.
		/// This trigger event is commonly used to start a service. The pTriggerSubtype member specifies the device interface class GUID.
		/// These GUIDs are defined in device-specific header files provided with the Windows Driver Kit (WDK). The pDataItems member
		/// specifies one or more hardware ID and compatible ID strings for the device interface class. Strings must be Unicode. If more
		/// than one string is specified, the event is triggered if any one of the strings match. For example, the Wpdbusenum service is
		/// started when a device of device interface class GUID_DEVINTERFACE_DISK {53f56307-b6bf-11d0-94f2-00a0c91efb8b} and a hardware
		/// ID string of arrives.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_TRIGGER_TYPE_DOMAIN_JOIN 3</term>
		/// <term>
		/// The event is triggered when the computer joins or leaves a domain. This trigger event can be used to start or stop a service.
		/// The pTriggerSubtype member specifies DOMAIN_JOIN_GUID or DOMAIN_LEAVE_GUID. The pDataItems member is not used.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_TRIGGER_TYPE_FIREWALL_PORT_EVENT 4</term>
		/// <term>
		/// The event is triggered when a firewall port is opened or approximately 60 seconds after the firewall port is closed. This
		/// trigger event can be used to start or stop a service. The pTriggerSubtype member specifies FIREWALL_PORT_OPEN_GUID or
		/// FIREWALL_PORT_CLOSE_GUID. The pDataItems member specifies the port, the protocol, and optionally the executable path and user
		/// information (SID string or name) of the service listening on the event. The "RPC" token can be used in place of the port to
		/// specify any listening socket used by RPC. The "system" token can be used in place of the executable path to specify ports
		/// created by and listened on by the Windows kernel. The event is triggered only if all strings match. For example, if MyService
		/// hosted inside MyServiceProcess.exe is to be trigger-started when port UDP 5001 opens, the trigger-specific data would be the
		/// Unicode representation of .
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_TRIGGER_TYPE_GROUP_POLICY 5</term>
		/// <term>
		/// The event is triggered when a machine policy or user policy change occurs. This trigger event is commonly used to start a
		/// service. The pTriggerSubtype member specifies MACHINE_POLICY_PRESENT_GUID or USER_POLICY_PRESENT_GUID. The pDataItems member
		/// is not used.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_TRIGGER_TYPE_IP_ADDRESS_AVAILABILITY 2</term>
		/// <term>
		/// The event is triggered when the first IP address on the TCP/IP networking stack becomes available or the last IP address on
		/// the stack becomes unavailable. This trigger event can be used to start or stop a service. The pTriggerSubtype member
		/// specifies NETWORK_MANAGER_FIRST_IP_ADDRESS_ARRIVAL_GUID or NETWORK_MANAGER_LAST_IP_ADDRESS_REMOVAL_GUID. The pDataItems
		/// member is not used.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVICE_TRIGGER_TYPE_NETWORK_ENDPOINT 6</term>
		/// <term>
		/// The event is triggered when a packet or request arrives on a particular network protocol. This request is commonly used to
		/// start a service that has stopped itself after an idle time-out when there is no work to do. Windows 7 and Windows Server 2008
		/// R2: This trigger type is not supported until Windows 8 and Windows Server 2012. The pTriggerSubtype member specifies one of
		/// the following values: RPC_INTERFACE_EVENT_GUID or NAMED_PIPE_EVENT_GUID. The pDataItems member specifies an endpoint or
		/// interface GUID. The string must be Unicode. The event triggers if the string is an exact match. The dwAction member must be SERVICE_TRIGGER_ACTION_SERVICE_START.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ServiceTriggerType dwTriggerType;

		/// <summary>
		/// <para>The action to take when the specified trigger event occurs. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_TRIGGER_ACTION_SERVICE_START 1</term>
		/// <term>Start the service when the specified trigger event occurs.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_TRIGGER_ACTION_SERVICE_STOP 2</term>
		/// <term>Stop the service when the specified trigger event occurs.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ServiceTriggerAction dwAction;

		/// <summary>
		/// <para>
		/// Points to a GUID that identifies the trigger event subtype. The value of this member depends on the value of the
		/// <c>dwTriggerType</c> member.
		/// </para>
		/// <para>
		/// If <c>dwTriggerType</c> is SERVICE_TRIGGER_TYPE_CUSTOM, <c>pTriggerSubtype</c> is the GUID that identifies the custom event provider.
		/// </para>
		/// <para>
		/// If <c>dwTriggerType</c> is SERVICE_TRIGGER_TYPE_DEVICE_INTERFACE_ARRIVAL, <c>pTriggerSubtype</c> is the GUID that identifies
		/// the device interface class.
		/// </para>
		/// <para>If <c>dwTriggerType</c> is SERVICE_TRIGGER_TYPE_NETWORK_ENDPOINT, <c>pTriggerSubtype</c> is one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NAMED_PIPE_EVENT_GUID 1F81D131-3FAC-4537-9E0C-7E7B0C2F4B55</term>
		/// <term>
		/// The event is triggered when a request is made to open the named pipe specified by pDataItems. The dwTriggerType member must
		/// be SERVICE_TRIGGER_TYPE_NETWORK_ENDPOINT. The dwAction member must be SERVICE_TRIGGER_ACTION_SERVICE_START.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RPC_INTERFACE_EVENT_GUID BC90D167-9470-4139-A9BA-BE0BBBF5B74D</term>
		/// <term>
		/// The event is triggered when an endpoint resolution request arrives for the RPC interface GUID specified by pDataItems. The
		/// dwTriggerType member must be SERVICE_TRIGGER_TYPE_NETWORK_ENDPOINT. The dwAction member must be SERVICE_TRIGGER_ACTION_SERVICE_START.
		/// </term>
		/// </item>
		/// </list>
		/// <para>For other trigger event types, <c>pTriggerSubType</c> can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DOMAIN_JOIN_GUID 1ce20aba-9851-4421-9430-1ddeb766e809</term>
		/// <term>The event is triggered when the computer joins a domain. The dwTriggerType member must be SERVICE_TRIGGER_TYPE_DOMAIN_JOIN.</term>
		/// </item>
		/// <item>
		/// <term>DOMAIN_LEAVE_GUID ddaf516e-58c2-4866-9574-c3b615d42ea1</term>
		/// <term>The event is triggered when the computer leaves a domain. The dwTriggerType member must be SERVICE_TRIGGER_TYPE_DOMAIN_JOIN.</term>
		/// </item>
		/// <item>
		/// <term>FIREWALL_PORT_OPEN_GUID b7569e07-8421-4ee0-ad10-86915afdad09</term>
		/// <term>The event is triggered when the specified firewall port is opened. The dwTriggerType member must be SERVICE_TRIGGER_TYPE_FIREWALL_PORT_EVENT.</term>
		/// </item>
		/// <item>
		/// <term>FIREWALL_PORT_CLOSE_GUID a144ed38-8e12-4de4-9d96-e64740b1a524</term>
		/// <term>
		/// The event is triggered approximately 60 seconds after the specified firewall port is closed. The dwTriggerType member must be SERVICE_TRIGGER_TYPE_FIREWALL_PORT_EVENT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MACHINE_POLICY_PRESENT_GUID 659FCAE6-5BDB-4DA9-B1FF-CA2A178D46E0</term>
		/// <term>The event is triggered when the machine policy has changed. The dwTriggerType member must be SERVICE_TRIGGER_TYPE_GROUP_POLICY.</term>
		/// </item>
		/// <item>
		/// <term>NETWORK_MANAGER_FIRST_IP_ADDRESS_ARRIVAL_GUID 4f27f2de-14e2-430b-a549-7cd48cbc8245</term>
		/// <term>
		/// The event is triggered when the first IP address on the TCP/IP networking stack becomes available. The dwTriggerType member
		/// must be SERVICE_TRIGGER_TYPE_IP_ADDRESS_AVAILABILITY.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NETWORK_MANAGER_LAST_IP_ADDRESS_REMOVAL_GUID cc4ba62a-162e-4648-847a-b6bdf993e335</term>
		/// <term>
		/// The event is triggered when the last IP address on the TCP/IP networking stack becomes unavailable. The dwTriggerType member
		/// must be SERVICE_TRIGGER_TYPE_IP_ADDRESS_AVAILABILITY.
		/// </term>
		/// </item>
		/// <item>
		/// <term>USER_POLICY_PRESENT_GUID 54FB46C8-F089-464C-B1FD-59D1B62C3B50</term>
		/// <term>The event is triggered when the user policy has changed. The dwTriggerType member must be SERVICE_TRIGGER_TYPE_GROUP_POLICY.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IntPtr pTriggerSubtype;

		/// <summary>
		/// <para>The number of SERVICE_TRIGGER_SPECIFIC_DATA_ITEM structures in the array pointed to by pDataItems.</para>
		/// <para>
		/// This member is valid only if the <c>dwDataType</c> member is SERVICE_TRIGGER_TYPE_CUSTOM,
		/// SERVICE_TRIGGER_TYPE_DEVICE_ARRIVAL, SERVICE_TRIGGER_TYPE_FIREWALL_PORT_EVENT, or SERVICE_TRIGGER_TYPE_NETWORK_ENDPOINT.
		/// </para>
		/// </summary>
		public uint cDataItems;

		/// <summary>
		/// <para>A pointer to an array of SERVICE_TRIGGER_SPECIFIC_DATA_ITEM structures that contain trigger-specific data.</para>
		/// </summary>
		public IntPtr pDataItems;

		/// <summary/>
		public Guid TriggerSubType => pTriggerSubtype.ToStructure<Guid>();

		/// <summary/>
		public SERVICE_TRIGGER_SPECIFIC_DATA_ITEM[] DataItems => pDataItems.ToArray<SERVICE_TRIGGER_SPECIFIC_DATA_ITEM>((int)cDataItems) ?? new SERVICE_TRIGGER_SPECIFIC_DATA_ITEM[0];
	}

	/// <summary>
	/// <para>
	/// Contains trigger event information for a service. This structure is used by the ChangeServiceConfig2 and QueryServiceConfig2 functions.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_service_trigger_info typedef struct _SERVICE_TRIGGER_INFO {
	// DWORD cTriggers; PSERVICE_TRIGGER pTriggers; PBYTE pReserved; } SERVICE_TRIGGER_INFO, *PSERVICE_TRIGGER_INFO;
	[PInvokeData("winsvc.h", MSDNShortId = "8de46056-1ea5-46f2-a260-ad140fd77bc1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_TRIGGER_INFO
	{
		/// <summary>
		/// <para>The number of triggers in the array of SERVICE_TRIGGER structures pointed to by the <c>pTriggers</c> member.</para>
		/// <para>
		/// If this member is 0 in a <c>SERVICE_TRIGGER_INFO</c> structure passed to ChangeServiceConfig2, all previously configured
		/// triggers are removed from the service. If the service has no triggers configured, <c>ChangeServiceConfig2</c> fails with ERROR_INVALID_PARAMETER.
		/// </para>
		/// </summary>
		public uint cTriggers;

		/// <summary>
		/// <para>
		/// A pointer to an array of SERVICE_TRIGGER structures that specify the trigger events for the service. If the <c>cTriggers</c>
		/// member is 0, this member is not used.
		/// </para>
		/// </summary>
		public IntPtr pTriggers;

		/// <summary>
		/// <para>This member is reserved and must be NULL.</para>
		/// </summary>
		public IntPtr pReserved;

		/// <summary/>
		public SERVICE_TRIGGER[] Triggers => pTriggers.ToArray<SERVICE_TRIGGER>((int)cTriggers) ?? new SERVICE_TRIGGER[0];
	}

	/// <summary>
	/// <para>
	/// Contains trigger-specific data for a service trigger event. This structure is used by the SERVICE_TRIGGER structure for
	/// SERVICE_TRIGGER_TYPE_CUSTOM, SERVICE_TRIGGER_TYPE_DEVICE_ARRIVAL, SERVICE_TRIGGER_TYPE_FIREWALL_PORT_EVENT, or
	/// SERVICE_TRIGGER_TYPE_NETWORK_ENDPOINT trigger events.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>The following table lists trigger-specific data by trigger event type.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Event type</term>
	/// <term>Trigger-specific data</term>
	/// </listheader>
	/// <item>
	/// <term>SERVICE_TRIGGER_TYPE_CUSTOM</term>
	/// <term>Specified by the Event Tracing for Windows (ETW) provider that defines the custom event.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_TRIGGER_TYPE_DEVICE_INTERFACE_ARRIVAL</term>
	/// <term>
	/// A SERVICE_TRIGGER_DATA_TYPE_STRING string that specifies a hardware ID or compatible ID string for the device interface class.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_TRIGGER_TYPE_DOMAIN_JOIN</term>
	/// <term>Not applicable.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_TRIGGER_TYPE_FIREWALL_PORT_EVENT</term>
	/// <term>
	/// A SERVICE_TRIGGER_DATA_TYPE_STRING multi-string that specifies the port, the protocol, and optionally the executable path and
	/// name of the service listening on the event.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SERVICE_TRIGGER_TYPE_GROUP_POLICY</term>
	/// <term>Not applicable.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_TRIGGER_TYPE_IP_ADDRESS_AVAILABILITY</term>
	/// <term>Not applicable.</term>
	/// </item>
	/// <item>
	/// <term>SERVICE_TRIGGER_TYPE_NETWORK_ENDPOINT</term>
	/// <term>A SERVICE_TRIGGER_DATA_TYPE_STRING that specifies the port, named pipe, or RPC interface for the network endpoint.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/ns-winsvc-_service_trigger_specific_data_item typedef struct
	// _SERVICE_TRIGGER_SPECIFIC_DATA_ITEM { DWORD dwDataType; DWORD cbData; PBYTE pData; } SERVICE_TRIGGER_SPECIFIC_DATA_ITEM, *PSERVICE_TRIGGER_SPECIFIC_DATA_ITEM;
	[PInvokeData("winsvc.h", MSDNShortId = "670e6c49-bbc0-4af6-9e47-6c89801ebb45")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_TRIGGER_SPECIFIC_DATA_ITEM
	{
		/// <summary>
		/// <para>The data type of the trigger-specific data pointed to by <c>pData</c>. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_TRIGGER_DATA_TYPE_BINARY 1</term>
		/// <term>The trigger-specific data is in binary format.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_TRIGGER_DATA_TYPE_STRING 2</term>
		/// <term>The trigger-specific data is in string format.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_TRIGGER_DATA_TYPE_LEVEL 3</term>
		/// <term>The trigger-specific data is a byte value.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_TRIGGER_DATA_TYPE_KEYWORD_ANY 4</term>
		/// <term>The trigger-specific data is a 64-bit unsigned integer value.</term>
		/// </item>
		/// <item>
		/// <term>SERVICE_TRIGGER_DATA_TYPE_KEYWORD_ALL 5</term>
		/// <term>The trigger-specific data is a 64-bit unsigned integer value.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ServiceTriggerDataType dwDataType;

		/// <summary>
		/// <para>The size of the trigger-specific data pointed to <c>pData</c>, in bytes. The maximum value is 1024.</para>
		/// </summary>
		public uint cbData;

		/// <summary>
		/// <para>
		/// A pointer to the trigger-specific data for the service trigger event. The trigger-specific data depends on the trigger event
		/// type; see Remarks.
		/// </para>
		/// <para>If the <c>dwDataType</c> member is SERVICE_TRIGGER_DATA_TYPE_BINARY, the trigger-specific data is an array of bytes.</para>
		/// <para>
		/// If the <c>dwDataType</c> member is SERVICE_TRIGGER_DATA_TYPE_STRING, the trigger-specific data is a null-terminated string or
		/// a multistring of null-terminated strings, ending with two null-terminating characters. For example: .
		/// </para>
		/// <para>Strings must be Unicode; ANSI strings are not supported.</para>
		/// </summary>
		public IntPtr pData;
	}
}