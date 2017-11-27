using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>Used by the <see cref="Vanara.ChangeServiceConfig2"/> method.</summary>
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
