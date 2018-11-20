using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
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
		public delegate void LphandlerFunction(uint dwControl);

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

		/// <summary>The current state of the service.</summary>
		[PInvokeData("winsvc.h", MSDNShortId = "d268609b-d442-4d0f-9d49-ed23fee84961")]
		public enum ServiceState
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
		public enum ServiceTriggerAction
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
			[Optional] string lpBinaryPathName, [Optional] string lpLoadOrderGroup, out uint lpdwTagId, [In, Optional] string lpDependencies,
			[Optional] string lpServiceStartName, [Optional] string lpPassword, [Optional] string lpDisplayName);

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
			[Optional] string lpBinaryPathName, [Optional] string lpLoadOrderGroup, [Optional] IntPtr lpdwTagId, [In, Optional] string lpDependencies,
			[Optional] string lpServiceStartName, [Optional] string lpPassword, [Optional] string lpDisplayName);

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
		public static extern bool ChangeServiceConfig2(SC_HANDLE hService, ServiceConfigOption dwInfoLevel, IntPtr lpInfo);

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
			using (var ptr = SafeCoTaskMemHandle.CreateFromStructure(lpInfo))
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
		public static extern SafeSC_HANDLE CreateService(SC_HANDLE hSCManager, string lpServiceName, string lpDisplayName, uint dwDesiredAccess, ServiceTypes dwServiceType,
			ServiceStartType dwStartType, ServiceErrorControlType dwErrorControl, string lpBinaryPathName, [Optional] string lpLoadOrderGroup, out uint lpdwTagId,
			[Optional] string lpDependencies, [Optional] string lpServiceStartName, [Optional] string lpPassword);

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
		public static extern SafeSC_HANDLE OpenSCManager(string lpMachineName, string lpDatabaseName, uint dwDesiredAccess);

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
		public static extern SafeSC_HANDLE OpenService(SC_HANDLE hSCManager, string lpServiceName, uint dwDesiredAccess);

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
		public static extern bool QueryServiceConfig(SC_HANDLE hService, IntPtr lpServiceConfig, uint cbBufSize, out uint pcbBytesNeeded);

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
		public static extern bool QueryServiceConfig2(SC_HANDLE hService, ServiceConfigOption dwInfoLevel, IntPtr lpBuffer, uint cbBufSize, out uint pcbBytesNeeded);

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
		public static bool QueryServiceConfig2<T>(SC_HANDLE hService, ServiceConfigOption dwInfoLevel, out T configInfo)
		{
			if (!CorrespondingTypeAttribute.CanGet(dwInfoLevel, typeof(T))) throw new ArgumentException("Type mismatch", nameof(configInfo));
			var b = QueryServiceConfig2(hService, dwInfoLevel, IntPtr.Zero, 0, out var size);
			configInfo = default;
			if (!b && Win32Error.GetLastError() != Win32Error.ERROR_INSUFFICIENT_BUFFER) return false;
			using (var buf = new SafeHGlobalHandle((int)size))
			{
				if (!QueryServiceConfig2(hService, dwInfoLevel, (IntPtr)buf, size, out size)) return false;
				configInfo = buf.ToStructure<T>();
				return true;
			}
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
		public static extern SERVICE_STATUS_HANDLE RegisterServiceCtrlHandler(string lpServiceName, LphandlerFunction lpHandlerProc);

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
		public static extern SERVICE_STATUS_HANDLE RegisterServiceCtrlHandlerEx(string lpServiceName, LphandlerFunction lpHandlerProc, IntPtr lpContext);

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

			public IEnumerable<string> Dependencies => lpDependencies.ToStringEnum();
		}

		/// <summary>
		/// <para>Represents an action that the service control manager can perform.</para>
		/// </summary>
		/// <remarks>
		/// <para>This structure is used by the ChangeServiceConfig2 and QueryServiceConfig2 functions, in the SERVICE_FAILURE_ACTIONS structure.</para>
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

		/// <summary>Provides a handle to a service.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SC_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="SC_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public SC_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="SC_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static SC_HANDLE NULL => new SC_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="SC_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(SC_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="SC_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SC_HANDLE(IntPtr h) => new SC_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(SC_HANDLE h1, SC_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(SC_HANDLE h1, SC_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is SC_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
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

			public SC_ACTION[] Actions => lpsaActions.ToArray<SC_ACTION>((int)cActions);
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
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
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
			public uint dwWin32ExitCode;

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
		}

		/// <summary>Provides a handle to a service status handle.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SERVICE_STATUS_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="SERVICE_STATUS_HANDLE "/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public SERVICE_STATUS_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="SERVICE_STATUS_HANDLE "/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static SERVICE_STATUS_HANDLE NULL => new SERVICE_STATUS_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="SERVICE_STATUS_HANDLE "/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(SERVICE_STATUS_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="SERVICE_STATUS_HANDLE "/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SERVICE_STATUS_HANDLE(IntPtr h) => new SERVICE_STATUS_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(SERVICE_STATUS_HANDLE h1, SERVICE_STATUS_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(SERVICE_STATUS_HANDLE h1, SERVICE_STATUS_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is SERVICE_STATUS_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
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

			public Guid TriggerSubType => pTriggerSubtype.ToStructure<Guid>();

			public SERVICE_TRIGGER_SPECIFIC_DATA_ITEM[] DataItems => pDataItems.ToArray<SERVICE_TRIGGER_SPECIFIC_DATA_ITEM>((int)cDataItems);
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

			public SERVICE_TRIGGER[] Triggers => pTriggers.ToArray<SERVICE_TRIGGER>((int)cTriggers);
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

		/// <summary>Provides a <see cref="SafeHandle"/> to a service that releases a created SC_HANDLE instance at disposal using CloseServiceHandle.</summary>
		public class SafeSC_HANDLE : HANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SC_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeSC_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SC_HANDLE"/> class.</summary>
			private SafeSC_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeSC_HANDLE"/> to <see cref="SC_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SC_HANDLE(SafeSC_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => CloseServiceHandle(this);
		}

		/*LPHANDLER_FUNCTION_EX callback
		LPSERVICE_MAIN_FUNCTIONA callback
		LPSERVICE_MAIN_FUNCTIONW callback

		ControlService
		ControlServiceEx
		DeleteService
		EnumDependentServices
		EnumServicesStatusEx
		EnumServicesStatus
		GetServiceDisplayName
		GetServiceKeyName
		LockServiceDatabase
		NotifyBootConfigStatus
		NotifyServiceStatusChange
		QueryServiceDynamicInformation
		QueryServiceLockStatus
		QueryServiceObjectSecurity
		QueryServiceStatus
		QueryServiceStatusEx
		SetServiceObjectSecurity
		StartServiceCtrlDispatcher
		StartService
		UnlockServiceDatabase

		ENUM_SERVICE_STATUS_PROCESS
		ENUM_SERVICE_STATUS
		QUERY_SERVICE_LOCK_STATUS
		SERVICE_CONTROL_STATUS_REASON_PARAMS
		SERVICE_NOTIFY_2
		SERVICE_STATUS
		SERVICE_STATUS_PROCESS
		SERVICE_TABLE_ENTRY
		SERVICE_TIMECHANGE_INFO
		SERVICE_TRIGGER_SPECIFIC_DATA_ITEM */
	}
}