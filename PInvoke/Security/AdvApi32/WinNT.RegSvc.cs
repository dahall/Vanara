using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>Access mask values for the registry.</summary>
		[PInvokeData("winnt.h")]
		public enum RegAccessTypes
		{
			/// <summary>Required to query the values of a registry key.</summary>
			KEY_QUERY_VALUE = 0x0001,
			/// <summary>Required to create, delete, or set a registry value.</summary>
			KEY_SET_VALUE = 0x0002,
			/// <summary>Required to create a subkey of a registry key.</summary>
			KEY_CREATE_SUB_KEY = 0x0004,
			/// <summary>Required to enumerate the subkeys of a registry key.</summary>
			KEY_ENUMERATE_SUB_KEYS = 0x0008,
			/// <summary>Required to request change notifications for a registry key or for subkeys of a registry key.</summary>
			KEY_NOTIFY = 0x0010,
			/// <summary>Reserved for system use.</summary>
			KEY_CREATE_LINK = 0x0020,
			/// <summary>Indicates that an application on 64-bit Windows should operate on the 32-bit registry view. This flag is ignored by 32-bit Windows. For more information, see Accessing an Alternate Registry View.
			/// <para>This flag must be combined using the OR operator with the other flags in this table that either query or access registry values.</para>
			/// <note>Windows 2000:  This flag is not supported.</note></summary>
			KEY_WOW64_32KEY = 0x0200,
			/// <summary>Indicates that an application on 64-bit Windows should operate on the 64-bit registry view. This flag is ignored by 32-bit Windows. For more information, see Accessing an Alternate Registry View.
			/// <para>This flag must be combined using the OR operator with the other flags in this table that either query or access registry values.</para>
			/// <note>Windows 2000:  This flag is not supported.</note></summary>
			KEY_WOW64_64KEY = 0x0100,
			/// <summary></summary>
			KEY_WOW64_RES = 0x0300,
			/// <summary>Combines the STANDARD_RIGHTS_READ, KEY_QUERY_VALUE, KEY_ENUMERATE_SUB_KEYS, and KEY_NOTIFY values.</summary>
			KEY_READ = 0x20019,
			/// <summary>Combines the STANDARD_RIGHTS_WRITE, KEY_SET_VALUE, and KEY_CREATE_SUB_KEY access rights.</summary>
			KEY_WRITE = 0x20006,
			/// <summary>Equivalent to KEY_READ.</summary>
			KEY_EXECUTE = 0x20019,
			/// <summary>Combines the STANDARD_RIGHTS_REQUIRED, KEY_QUERY_VALUE, KEY_SET_VALUE, KEY_CREATE_SUB_KEY, KEY_ENUMERATE_SUB_KEYS, KEY_NOTIFY, and KEY_CREATE_LINK access rights.</summary>
			KEY_ALL_ACCESS = 0xF003F,
		}

		/// <summary>Filter for notifications reported by <see cref="RegNotifyChangeKeyValue"/>.</summary>
		[Flags]
		[PInvokeData("winnt.h")]
		public enum RegNotifyChangeFilter
		{
			/// <summary>Notify the caller if a subkey is added or deleted.</summary>
			REG_NOTIFY_CHANGE_NAME = 1,

			/// <summary>Notify the caller of changes to the attributes of the key, such as the security descriptor information.</summary>
			REG_NOTIFY_CHANGE_ATTRIBUTES = 2,

			/// <summary>Notify the caller of changes to a value of the key. This can include adding or deleting a value, or changing an existing value.</summary>
			REG_NOTIFY_CHANGE_LAST_SET = 4,

			/// <summary>Notify the caller of changes to the security descriptor of the key.</summary>
			REG_NOTIFY_CHANGE_SECURITY = 8,

			/// <summary>
			/// Indicates that the lifetime of the registration must not be tied to the lifetime of the thread issuing the RegNotifyChangeKeyValue call.
			/// <note type="note">This flag value is only supported in Windows 8 and later.</note>
			/// </summary>
			REG_NOTIFY_THREAD_AGNOSTIC = 0x10000000
		}

		/// <summary>
		/// Options for <see cref="RegOpenKeyEx"/>.
		/// </summary>
		[Flags]
		[PInvokeData("winnt.h")]
		public enum RegOpenOptions
		{
			/// <summary>Reserved.</summary>
			REG_OPTION_RESERVED = 0x00000000,
			/// <summary>
			/// This key is not volatile; this is the default. The information is stored in a file and is preserved when the system is restarted. The RegSaveKey
			/// function saves keys that are not volatile.
			/// </summary>
			REG_OPTION_NON_VOLATILE = 0x00000000,
			/// <summary>
			/// All keys created by the function are volatile. The information is stored in memory and is not preserved when the corresponding registry hive is unloaded. For HKEY_LOCAL_MACHINE, this occurs only when the system initiates a full shutdown. For registry keys loaded by the RegLoadKey function, this occurs when the corresponding RegUnLoadKey is performed. The RegSaveKey function does not save volatile keys. This flag is ignored for keys that already exist.
			/// <note type="note">On a user selected shutdown, a fast startup shutdown is the default behavior for the system.</note>
			/// </summary>
			REG_OPTION_VOLATILE = 0x00000001,
			/// <summary>
			/// <note type="note">Registry symbolic links should only be used for for application compatibility when absolutely necessary.</note>
			/// <para>This key is a symbolic link. The target path is assigned to the L"SymbolicLinkValue" value of the key. The target path must be an absolute registry path.</para>
			/// </summary>
			REG_OPTION_CREATE_LINK = 0x00000002,
			/// <summary>
			/// If this flag is set, the function ignores the samDesired parameter and attempts to open the key with the access required to backup or restore the
			/// key. If the calling thread has the SE_BACKUP_NAME privilege enabled, the key is opened with the ACCESS_SYSTEM_SECURITY and KEY_READ access
			/// rights. If the calling thread has the SE_RESTORE_NAME privilege enabled, beginning with Windows Vista, the key is opened with the
			/// ACCESS_SYSTEM_SECURITY, DELETE and KEY_WRITE access rights. If both privileges are enabled, the key has the combined access rights for both
			/// privileges. For more information, see Running with Special Privileges.
			/// </summary>
			REG_OPTION_BACKUP_RESTORE = 0x00000004,
			/// <summary>The key is a symbolic link. Registry symbolic links should only be used when absolutely necessary.</summary>
			REG_OPTION_OPEN_LINK = 0x00000008,
		}

		/// <summary>
		/// Used by the <see cref="ChangeServiceConfig(IntPtr,ServiceTypes,ServiceStartType,ServiceErrorControlType,string,string,IntPtr,char[],string,string,string)"/> function.
		/// </summary>
		public enum ServiceErrorControlType : uint
		{
			/// <summary>Makes no change for this setting.</summary>
			SERVICE_NO_CHANGE = 0xFFFFFFFF,
			/// <summary>The startup program ignores the error and continues the startup operation.</summary>
			SERVICE_ERROR_IGNORE = 0x00000000,
			/// <summary>The startup program logs the error in the event log but continues the startup operation.</summary>
			SERVICE_ERROR_NORMAL = 0x00000001,
			/// <summary>
			/// The startup program logs the error in the event log. If the last-known-good configuration is being started, the startup operation continues.
			/// Otherwise, the system is restarted with the last-known-good configuration.
			/// </summary>
			SERVICE_ERROR_SEVERE = 0x00000002,
			/// <summary>
			/// The startup program logs the error in the event log, if possible. If the last-known-good configuration is being started, the startup operation
			/// fails. Otherwise, the system is restarted with the last-known good configuration.
			/// </summary>
			SERVICE_ERROR_CRITICAL = 0x00000003
		}

		/// <summary>
		/// Used by the <see cref="ChangeServiceConfig(IntPtr,ServiceTypes,ServiceStartType,ServiceErrorControlType,string,string,IntPtr,char[],string,string,string)"/> function.
		/// </summary>
		public enum ServiceStartType : uint
		{
			/// <summary>Makes no change for this setting.</summary>
			SERVICE_NO_CHANGE = 0xFFFFFFFF,
			/// <summary>A device driver started by the system loader. This value is valid only for driver services.</summary>
			SERVICE_BOOT_START = 0x00000000,
			/// <summary>A device driver started by the IoInitSystem function. This value is valid only for driver services.</summary>
			SERVICE_SYSTEM_START = 0x00000001,
			/// <summary>A service started automatically by the service control manager during system startup.</summary>
			SERVICE_AUTO_START = 0x00000002,
			/// <summary>A service started by the service control manager when a process calls the StartService function.</summary>
			SERVICE_DEMAND_START = 0x00000003,
			/// <summary>A service that cannot be started. Attempts to start the service result in the error code ERROR_SERVICE_DISABLED.</summary>
			SERVICE_DISABLED = 0x00000004
		}

		/// <summary>
		/// Used by the <see cref="ChangeServiceConfig(IntPtr,ServiceTypes,ServiceStartType,ServiceErrorControlType,string,string,IntPtr,char[],string,string,string)"/> function.
		/// </summary>
		[Flags]
		public enum ServiceTypes : uint
		{
			/// <summary>Makes no change for this setting.</summary>
			SERVICE_NO_CHANGE = 0xFFFFFFFF,
			/// <summary>Driver service.</summary>
			SERVICE_KERNEL_DRIVER = 0x00000001,
			/// <summary>File system driver service.</summary>
			SERVICE_FILE_SYSTEM_DRIVER = 0x00000002,
			/// <summary>Reserved</summary>
			SERVICE_ADAPTER = 0x00000004,
			/// <summary>Reserved</summary>
			SERVICE_RECOGNIZER_DRIVER = 0x00000008,
			/// <summary>Combination of SERVICE_KERNEL_DRIVER | SERVICE_FILE_SYSTEM_DRIVER | SERVICE_RECOGNIZER_DRIVER</summary>
			SERVICE_DRIVER = SERVICE_KERNEL_DRIVER | SERVICE_FILE_SYSTEM_DRIVER | SERVICE_RECOGNIZER_DRIVER,
			/// <summary>Service that runs in its own process.</summary>
			SERVICE_WIN32_OWN_PROCESS = 0x00000010,
			/// <summary>Service that shares a process with other services.</summary>
			SERVICE_WIN32_SHARE_PROCESS = 0x00000020,
			/// <summary>Combination of SERVICE_WIN32_OWN_PROCESS | SERVICE_WIN32_SHARE_PROCESS</summary>
			SERVICE_WIN32 = SERVICE_WIN32_OWN_PROCESS | SERVICE_WIN32_SHARE_PROCESS,
			/// <summary>The service user service</summary>
			SERVICE_USER_SERVICE = 0x00000040,
			/// <summary>The service userservice instance</summary>
			SERVICE_USERSERVICE_INSTANCE = 0x00000080,
			/// <summary>Combination of SERVICE_USER_SERVICE | SERVICE_WIN32_SHARE_PROCESS</summary>
			SERVICE_USER_SHARE_PROCESS = SERVICE_USER_SERVICE | SERVICE_WIN32_SHARE_PROCESS,
			/// <summary>Combination of SERVICE_USER_SERVICE | SERVICE_WIN32_OWN_PROCESS</summary>
			SERVICE_USER_OWN_PROCESS = SERVICE_USER_SERVICE | SERVICE_WIN32_OWN_PROCESS,
			/// <summary>The service can interact with the desktop.</summary>
			SERVICE_INTERACTIVE_PROCESS = 0x00000100,
			/// <summary>The service PKG service</summary>
			SERVICE_PKG_SERVICE = 0x00000200,
			/// <summary>Combination of all service types</summary>
			SERVICE_TYPE_ALL = SERVICE_WIN32 | SERVICE_ADAPTER | SERVICE_DRIVER | SERVICE_INTERACTIVE_PROCESS | SERVICE_USER_SERVICE | SERVICE_USERSERVICE_INSTANCE | SERVICE_PKG_SERVICE
		}
	}
}
