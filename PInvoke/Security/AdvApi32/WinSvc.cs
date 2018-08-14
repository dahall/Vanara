using System;
using System.Runtime.InteropServices;
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nc-winsvc-lphandler_function
		// LPHANDLER_FUNCTION LphandlerFunction; void LphandlerFunction( DWORD dwControl ) {...}
		[PInvokeData("winsvc.h", MSDNShortId = "e2d6d3a7-070e-4343-abd7-b4b9f8dd6fbc")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void LphandlerFunction(uint dwControl);

		/// <summary>Used by the <see cref="ChangeServiceConfig2"/> method.</summary>
		public enum ServiceConfigOption : uint
		{
			/// <summary>
			/// The lpInfo parameter is a pointer to a SERVICE_DELAYED_AUTO_START_INFO structure.
			/// <para><c>Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
			/// </summary>
			SERVICE_CONFIG_DELAYED_AUTO_START_INFO = 3,
			/// <summary>The lpInfo parameter is a pointer to a SERVICE_DESCRIPTION structure.</summary>
			SERVICE_CONFIG_DESCRIPTION = 1,
			/// <summary>
			/// The lpInfo parameter is a pointer to a SERVICE_FAILURE_ACTIONS structure.
			/// <para>
			/// If the service controller handles the SC_ACTION_REBOOT action, the caller must have the SE_SHUTDOWN_NAME privilege. For more information, see
			/// Running with Special Privileges.
			/// </para>
			/// </summary>
			SERVICE_CONFIG_FAILURE_ACTIONS = 2,
			/// <summary>
			/// The lpInfo parameter is a pointer to a SERVICE_FAILURE_ACTIONS_FLAG structure.
			/// <para><c>Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
			/// </summary>
			SERVICE_CONFIG_FAILURE_ACTIONS_FLAG = 4,
			/// <summary>
			/// The lpInfo parameter is a pointer to a SERVICE_PREFERRED_NODE_INFO structure.
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
			/// </summary>
			SERVICE_CONFIG_PREFERRED_NODE = 9,
			/// <summary>
			/// The lpInfo parameter is a pointer to a SERVICE_PRESHUTDOWN_INFO structure.
			/// <para><c>Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
			/// </summary>
			SERVICE_CONFIG_PRESHUTDOWN_INFO = 7,
			/// <summary>
			/// The lpInfo parameter is a pointer to a SERVICE_REQUIRED_PRIVILEGES_INFO structure.
			/// <para><c>Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
			/// </summary>
			SERVICE_CONFIG_REQUIRED_PRIVILEGES_INFO = 6,
			/// <summary>The lpInfo parameter is a pointer to a SERVICE_SID_INFO structure.</summary>
			SERVICE_CONFIG_SERVICE_SID_INFO = 5,
			/// <summary>
			/// The lpInfo parameter is a pointer to a SERVICE_TRIGGER_INFO structure. This value is not supported by the ANSI version of ChangeServiceConfig2.
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported until Windows Server 2008 R2.</para>
			/// </summary>
			SERVICE_CONFIG_TRIGGER_INFO = 8,
			/// <summary>
			/// <para>The lpInfo parameter is a pointer a SERVICE_LAUNCH_P/// ROTECTED_INFO structure.</para>
			/// <note>This value is supported starting with Windows 8.1.</note>
			/// </summary>
			SERVICE_CONFIG_LAUNCH_PROTECTED = 12,
		}

		/// <summary>Changes the configuration parameters of a service.</summary>
		/// <param name="hService">
		/// A handle to the service. This handle is returned by the OpenService or CreateService function and must have the SERVICE_CHANGE_CONFIG access right.
		/// </param>
		/// <param name="nServiceType">
		/// The type of service. Specify SERVICE_NO_CHANGE if you are not changing the existing service type. If you specify either SERVICE_WIN32_OWN_PROCESS or
		/// SERVICE_WIN32_SHARE_PROCESS, and the service is running in the context of the LocalSystem account, you can also specify SERVICE_INTERACTIVE_PROCESS.
		/// </param>
		/// <param name="nStartType">The service start options. Specify SERVICE_NO_CHANGE if you are not changing the existing start type.</param>
		/// <param name="nErrorControl">
		/// The severity of the error, and action taken, if this service fails to start. Specify SERVICE_NO_CHANGE if you are not changing the existing error control.
		/// </param>
		/// <param name="lpBinaryPathName">
		/// The fully qualified path to the service binary file. Specify NULL if you are not changing the existing path. If the path contains a space, it must be
		/// quoted so that it is correctly interpreted. For example, "d:\\my share\\myservice.exe" should be specified as "\"d:\\my share\\myservice.exe\"".
		/// <para>
		/// The path can also include arguments for an auto-start service. For example, "d:\\myshare\\myservice.exe arg1 arg2". These arguments are passed to the
		/// service entry point (typically the main function).
		/// </para>
		/// <para>
		/// If you specify a path on another computer, the share must be accessible by the computer account of the local computer because this is the security
		/// context used in the remote call. However, this requirement allows any potential vulnerabilities in the remote computer to affect the local computer.
		/// Therefore, it is best to use a local file.
		/// </para>
		/// </param>
		/// <param name="lpLoadOrderGroup">
		/// The name of the load ordering group of which this service is a member. Specify NULL if you are not changing the existing group. Specify an empty
		/// string if the service does not belong to a group.
		/// <para>
		/// The startup program uses load ordering groups to load groups of services in a specified order with respect to the other groups. The list of load
		/// ordering groups is contained in the ServiceGroupOrder value of the following registry key:
		/// </para>
		/// <para>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control</para>
		/// </param>
		/// <param name="lpdwTagId">
		/// A pointer to a variable that receives a tag value that is unique in the group specified in the lpLoadOrderGroup parameter. Specify NULL if you are
		/// not changing the existing tag.
		/// <para>
		/// You can use a tag for ordering service startup within a load ordering group by specifying a tag order vector in the GroupOrderList value of the
		/// following registry key:
		/// </para>
		/// <para>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control</para>
		/// <para>Tags are only evaluated for driver services that have SERVICE_BOOT_START or SERVICE_SYSTEM_START start types.</para>
		/// </param>
		/// <param name="lpDependencies">
		/// A pointer to a double null-terminated array of null-separated names of services or load ordering groups that the system must start before this
		/// service can be started. (Dependency on a group means that this service can run if at least one member of the group is running after an attempt to
		/// start all members of the group.) Specify NULL if you are not changing the existing dependencies. Specify an empty string if the service has no dependencies.
		/// <para>
		/// You must prefix group names with SC_GROUP_IDENTIFIER so that they can be distinguished from a service name, because services and service groups share
		/// the same name space.
		/// </para>
		/// </param>
		/// <param name="lpServiceStartName">
		/// The name of the account under which the service should run. Specify NULL if you are not changing the existing account name. If the service type is
		/// SERVICE_WIN32_OWN_PROCESS, use an account name in the form DomainName\UserName. The service process will be logged on as this user. If the account
		/// belongs to the built-in domain, you can specify .\UserName (note that the corresponding C/C++ string is ".\\UserName"). For more information, see
		/// Service User Accounts and the warning in the Remarks section.
		/// <para>A shared process can run as any user.</para>
		/// <para>
		/// If the service type is SERVICE_KERNEL_DRIVER or SERVICE_FILE_SYSTEM_DRIVER, the name is the driver object name that the system uses to load the
		/// device driver. Specify NULL if the driver is to use a default object name created by the I/O system.
		/// </para>
		/// <para>
		/// A service can be configured to use a managed account or a virtual account. If the service is configured to use a managed service account, the name is
		/// the managed service account name. If the service is configured to use a virtual account, specify the name as NT SERVICE\ServiceName. For more
		/// information about managed service accounts and virtual accounts, see the Service Accounts Step-by-Step Guide.
		/// </para>
		/// <para>
		/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: Managed service accounts and virtual accounts are not supported until Windows
		/// 7 and Windows Server 2008 R2.
		/// </para>
		/// </param>
		/// <param name="lpPassword">
		/// The password to the account name specified by the lpServiceStartName parameter. Specify NULL if you are not changing the existing password. Specify
		/// an empty string if the account has no password or if the service runs in the LocalService, NetworkService, or LocalSystem account. For more
		/// information, see Service Record List.
		/// <para>
		/// If the account name specified by the lpServiceStartName parameter is the name of a managed service account or virtual account name, the lpPassword
		/// parameter must be NULL.
		/// </para>
		/// <para>Passwords are ignored for driver services.</para>
		/// </param>
		/// <param name="lpDisplayName">
		/// The display name to be used by applications to identify the service for its users. Specify NULL if you are not changing the existing display name;
		/// otherwise, this string has a maximum length of 256 characters. The name is case-preserved in the service control manager. Display name comparisons
		/// are always case-insensitive.
		/// <para>This parameter can specify a localized string using the following format:</para>
		/// <para>@[path\]dllname,-strID</para>
		/// <para>The string with identifier strID is loaded from dllname; the path is optional. For more information, see RegLoadMUIString.</para>
		/// <para>Windows Server 2003 and Windows XP: Localized strings are not supported until Windows Vista.</para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winsvc.h", MSDNShortId = "ms681987")]
		public static extern bool ChangeServiceConfig(IntPtr hService, ServiceTypes nServiceType, ServiceStartType nStartType, ServiceErrorControlType nErrorControl,
			[Optional] string lpBinaryPathName, [Optional] string lpLoadOrderGroup, [Optional] IntPtr lpdwTagId, [In, Optional] char[] lpDependencies,
			[Optional] string lpServiceStartName, [Optional] string lpPassword, [Optional] string lpDisplayName);

		/// <summary>Changes the optional configuration parameters of a service.</summary>
		/// <param name="hService">
		/// A handle to the service. This handle is returned by the OpenService or CreateService function and must have the SERVICE_CHANGE_CONFIG access right.
		/// </param>
		/// <param name="dwInfoLevel">The configuration information to be changed.</param>
		/// <param name="lpInfo">A pointer to the new value to be set for the configuration information. The format of this data depends on the value of the dwInfoLevel parameter. If this value is NULL, the information remains unchanged.</param>
		/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winsvc.h", MSDNShortId = "ms681988")]
		public static extern bool ChangeServiceConfig2(IntPtr hService, ServiceConfigOption dwInfoLevel, IntPtr lpInfo);

		/// <summary>Retrieves the configuration parameters of the specified service. Optional configuration parameters are available using the QueryServiceConfig2 function.</summary>
		/// <param name="hService">A handle to the service. This handle is returned by the OpenService or CreateService function, and it must have the SERVICE_QUERY_CONFIG access right. For more information, see Service Security and Access Rights.</param>
		/// <param name="lpServiceConfig">A pointer to a buffer that receives the service configuration information. The format of the data is a QUERY_SERVICE_CONFIG structure.
		/// <para>The maximum size of this array is 8K bytes. To determine the required size, specify NULL for this parameter and 0 for the cbBufSize parameter. The function will fail and GetLastError will return ERROR_INSUFFICIENT_BUFFER. The pcbBytesNeeded parameter will receive the required size.</para></param>
		/// <param name="cbBufSize">The size of the buffer pointed to by the lpServiceConfig parameter, in bytes.</param>
		/// <param name="pcbBytesNeeded">A pointer to a variable that receives the number of bytes needed to store all the configuration information, if the function fails with ERROR_INSUFFICIENT_BUFFER.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winsvc.h", MSDNShortId = "ms684932")]
		public static extern bool QueryServiceConfig(IntPtr hService, IntPtr lpServiceConfig, uint cbBufSize, out uint pcbBytesNeeded);

		/// <summary>Retrieves the optional configuration parameters of a service.</summary>
		/// <param name="hService">A handle to the service. This handle is returned by the OpenService or CreateService function and must have the SERVICE_CHANGE_CONFIG access right.</param>
		/// <param name="dwInfoLevel">The configuration information to be queried.</param>
		/// <param name="lpBuffer">A pointer to the buffer that receives the service configuration information. The format of this data depends on the value of the dwInfoLevel parameter.
		/// <para>The maximum size of this array is 8K bytes. To determine the required size, specify NULL for this parameter and 0 for the cbBufSize parameter. The function fails and GetLastError returns ERROR_INSUFFICIENT_BUFFER. The pcbBytesNeeded parameter receives the needed size.</para></param>
		/// <param name="cbBufSize">The size of the structure pointed to by the lpBuffer parameter, in bytes.</param>
		/// <param name="pcbBytesNeeded">A pointer to a variable that receives the number of bytes required to store the configuration information, if the function fails with ERROR_INSUFFICIENT_BUFFER.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winsvc.h", MSDNShortId = "ms684935")]
		public static extern bool QueryServiceConfig2(IntPtr hService, ServiceConfigOption dwInfoLevel, IntPtr lpBuffer, uint cbBufSize, out uint pcbBytesNeeded);

		/// <summary>Retrieves the optional configuration parameters of a service.</summary>
		/// <param name="hService">A handle to the service. This handle is returned by the OpenService or CreateService function and must have the SERVICE_CHANGE_CONFIG access right.</param>
		/// <param name="dwInfoLevel">The configuration information to be queried.</param>
		/// <param name="configInfo">A variable that receives the service configuration information. The format of this data depends on the value of the dwInfoLevel parameter.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[PInvokeData("winsvc.h", MSDNShortId = "ms684935")]
		public static bool QueryServiceConfig2<T>(IntPtr hService, ServiceConfigOption dwInfoLevel, out T configInfo)
		{
			var b = QueryServiceConfig2(hService, dwInfoLevel, IntPtr.Zero, 0, out uint size);
			configInfo = default(T);
			if (!b && Win32Error.GetLastError() != Win32Error.ERROR_INSUFFICIENT_BUFFER) return false;
			if (size < Marshal.SizeOf(typeof(T))) throw new ArgumentException("Type mismatch", nameof(configInfo));
			using (var buf = new SafeHGlobalHandle((int) size))
			{
				if (!QueryServiceConfig2(hService, dwInfoLevel, (IntPtr)buf, size, out size)) return false;
				configInfo = buf.ToStructure<T>();
			}
			return true;
		}

		/// <summary><para>Registers a function to handle service control requests.</para><para>This function has been superseded by the RegisterServiceCtrlHandlerEx function. A service can use either function, but the new function supports user-defined context data, and the new handler function supports additional extended control codes.</para></summary><param name="lpServiceName"><para>The name of the service run by the calling thread. This is the service name that the service control program specified in the CreateService function when creating the service.</para><para>If the service type is SERVICE_WIN32_OWN_PROCESS, the function does not verify that the specified name is valid, because there is only one registered service in the process.</para></param><param name="lpHandlerProc"><para>A pointer to the handler function to be registered. For more information, see Handler.</para></param><returns><para>If the function succeeds, the return value is a service status handle.</para><para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para><para>The following error codes can be set by the service control manager.</para><list type="table"><listheader><term>Return code</term><term>Description</term></listheader><item><term> ERROR_NOT_ENOUGH_MEMORY </term><term>Not enough memory is available to convert an ANSI string parameter to Unicode. This error does not occur for Unicode string parameters.</term></item><item><term> ERROR_SERVICE_NOT_IN_EXE </term><term> The service entry was specified incorrectly when the process called the StartServiceCtrlDispatcher function. </term></item></list></returns><remarks><para>The ServiceMain function of a new service should immediately call the <c>RegisterServiceCtrlHandler</c> function to register a control handler function with the control dispatcher. This enables the control dispatcher to invoke the specified function when it receives control requests for this service. For a list of possible control codes, see Handler. The threads of the calling process can use the service status handle returned by this function to identify the service in subsequent calls to the SetServiceStatus function.</para><para>The <c>RegisterServiceCtrlHandler</c> function must be called before the first SetServiceStatus call because <c>RegisterServiceCtrlHandler</c> returns a service status handle for the caller to use so that no other service can inadvertently set this service status. In addition, the control handler must be in place to receive control requests by the time the service specifies the controls it accepts through the <c>SetServiceStatus</c> function.</para><para>When the control handler function is invoked with a control request, the service must call SetServiceStatus to report status to the service control manager only if the service status has changed, such as when the service is processing stop or shutdown controls. If the service status has not changed, the service should not report status to the service control manager.</para><para>The service status handle does not have to be closed.</para><para>Examples</para><para>For an example, see Writing a ServiceMain Function.</para></remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-registerservicectrlhandlera
		// SERVICE_STATUS_HANDLE RegisterServiceCtrlHandlerA( LPCSTR lpServiceName, LPHANDLER_FUNCTION lpHandlerProc );
		[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsvc.h", MSDNShortId = "31ec28fe-8774-48fc-91ba-6fa43108e2cc")]
		public static extern IntPtr RegisterServiceCtrlHandler(string lpServiceName, LphandlerFunction lpHandlerProc);

		/// <summary><para>Registers a function to handle extended service control requests.</para></summary><param name="lpServiceName"><para>The name of the service run by the calling thread. This is the service name that the service control program specified in the CreateService function when creating the service.</para></param><param name="lpHandlerProc"><para>A pointer to the handler function to be registered. For more information, see HandlerEx.</para></param><param name="lpContext"><para>Any user-defined data. This parameter, which is passed to the handler function, can help identify the service when multiple services share a process.</para></param><returns><para>If the function succeeds, the return value is a service status handle.</para><para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para><para>The following error codes can be set by the service control manager.</para><list type="table"><listheader><term>Return code</term><term>Description</term></listheader><item><term> ERROR_NOT_ENOUGH_MEMORY </term><term>Not enough memory is available to convert an ANSI string parameter to Unicode. This error does not occur for Unicode string parameters.</term></item><item><term> ERROR_SERVICE_NOT_IN_EXE </term><term> The service entry was specified incorrectly when the process called the StartServiceCtrlDispatcher function. </term></item></list></returns><remarks><para>The ServiceMain function of a new service should immediately call the <c>RegisterServiceCtrlHandlerEx</c> function to register a control handler function with the control dispatcher. This enables the control dispatcher to invoke the specified function when it receives control requests for this service. For a list of possible control codes, see HandlerEx. The threads of the calling process can use the service status handle returned by this function to identify the service in subsequent calls to the SetServiceStatus function.</para><para>The <c>RegisterServiceCtrlHandlerEx</c> function must be called before the first SetServiceStatus call because <c>RegisterServiceCtrlHandlerEx</c> returns a service status handle for the caller to use so that no other service can inadvertently set this service status. In addition, the control handler must be in place to receive control requests by the time the service specifies the controls it accepts through the <c>SetServiceStatus</c> function.</para><para>When the control handler function is invoked with a control request, the service must call SetServiceStatus to report status to the service control manager only if the service status has changed, such as when the service is processing stop or shutdown controls. If the service status has not changed, the service should not report status to the service control manager.</para><para>The service status handle does not have to be closed.</para></remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsvc/nf-winsvc-registerservicectrlhandlerexa
		// SERVICE_STATUS_HANDLE RegisterServiceCtrlHandlerExA( LPCSTR lpServiceName, LPHANDLER_FUNCTION_EX lpHandlerProc, LPVOID lpContext );
		[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsvc.h", MSDNShortId = "23eea346-9899-4214-88f4-9b7eb7ce1332")]
		public static extern IntPtr RegisterServiceCtrlHandlerEx(string lpServiceName, LphandlerFunction lpHandlerProc, IntPtr lpContext);

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[PInvokeData("Winsvc.h", MSDNShortId = "ms684950")]
		public struct QUERY_SERVICE_CONFIG
		{
			public ServiceTypes dwServiceType;
			public ServiceStartType dwStartType;
			public ServiceErrorControlType dwErrorControl;
			public string lpBinaryPathName;
			public string lpLoadOrderGroup;
			public uint dwTagID;
			public IntPtr lpDependencies;
			public string lpServiceStartName;
			public string lpDisplayName;
		}

		/// <summary>
		/// Contains a service description.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[PInvokeData("Winsvc.h", MSDNShortId = "ms685156")]
		public struct SERVICE_DESCRIPTION
		{
			/// <summary>The description of the service. If this member is NULL, the description remains unchanged. If this value is an empty string (""), the current description is deleted.
			/// <para>The service description must not exceed the size of a registry value of type REG_SZ.</para>
			/// <para>This member can specify a localized string using the following format:</para>
			/// <para>@[path\]dllname,-strID</para>
			/// <para>The string with identifier strID is loaded from dllname; the path is optional. For more information, see RegLoadMUIString.</para>
			/// <para><c>Windows Server 2003 and Windows XP:</c> Localized strings are not supported until Windows Vista.</para></summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpDescription;
		}
	}
}
