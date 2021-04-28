using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	/// <summary>Items from the CfgMgr32.dll</summary>
	public static partial class CfgMgr32
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public const int CONFIGMG_VERSION = 0x0400;
		public const int MAX_CLASS_NAME_LEN = 32;
		public const int MAX_CONFIG_VALUE = 9999;
		public const int MAX_DEVICE_ID_LEN = 200;
		public const int MAX_DEVNODE_ID_LEN = MAX_DEVICE_ID_LEN;
		public const int MAX_DMA_CHANNELS = 7;
		public const int MAX_GUID_STRING_LEN = 39;          // 38 chars + terminator null
		public const int MAX_INSTANCE_VALUE = 9999;
		public const int MAX_IO_PORTS = 20;
		public const int MAX_IRQS = 7;
		public const int MAX_MEM_REGISTERS = 9;
		public const int MAX_PROFILE_LEN = 80;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

		// Win95 compatibility--not applicable to 32-bit ConfigMgr Win95 compatibility--not applicable to 32-bit ConfigMgr Win95
		// compatibility--not applicable to 32-bit ConfigMgr
		private const string Lib_Cfgmgr32 = "CfgMgr32.dll";

		/// <summary>Caller-supplied flag constant that specifies the list onto which the supplied device ID should be appended.</summary>
		[PInvokeData("cfgmgr32.h")]
		public enum CM_ADD_ID
		{
			/// <summary></summary>
			CM_ADD_ID_HARDWARE = 0x00000000,

			/// <summary></summary>
			CM_ADD_ID_COMPATIBLE = 0x00000001,
		}

		/// <summary>One of the CR_-prefixed error codes defined in Cfgmgr32.h.</summary>
		[PInvokeData("cfgmgr32.h")]
		public enum CONFIGRET : uint
		{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			CR_SUCCESS = 0x00000000,
			CR_DEFAULT = 0x00000001,
			CR_OUT_OF_MEMORY = 0x00000002,
			CR_INVALID_POINTER = 0x00000003,
			CR_INVALID_FLAG = 0x00000004,
			CR_INVALID_DEVNODE = 0x00000005,
			CR_INVALID_DEVINST = CR_INVALID_DEVNODE,
			CR_INVALID_RES_DES = 0x00000006,
			CR_INVALID_LOG_CONF = 0x00000007,
			CR_INVALID_ARBITRATOR = 0x00000008,
			CR_INVALID_NODELIST = 0x00000009,
			CR_DEVNODE_HAS_REQS = 0x0000000A,
			CR_DEVINST_HAS_REQS = CR_DEVNODE_HAS_REQS,
			CR_INVALID_RESOURCEID = 0x0000000B,
			CR_DLVXD_NOT_FOUND = 0x0000000C,   // WIN 95 ONLY
			CR_NO_SUCH_DEVNODE = 0x0000000D,
			CR_NO_SUCH_DEVINST = CR_NO_SUCH_DEVNODE,
			CR_NO_MORE_LOG_CONF = 0x0000000E,
			CR_NO_MORE_RES_DES = 0x0000000F,
			CR_ALREADY_SUCH_DEVNODE = 0x00000010,
			CR_ALREADY_SUCH_DEVINST = CR_ALREADY_SUCH_DEVNODE,
			CR_INVALID_RANGE_LIST = 0x00000011,
			CR_INVALID_RANGE = 0x00000012,
			CR_FAILURE = 0x00000013,
			CR_NO_SUCH_LOGICAL_DEV = 0x00000014,
			CR_CREATE_BLOCKED = 0x00000015,
			CR_NOT_SYSTEM_VM = 0x00000016,   // WIN 95 ONLY
			CR_REMOVE_VETOED = 0x00000017,
			CR_APM_VETOED = 0x00000018,
			CR_INVALID_LOAD_TYPE = 0x00000019,
			CR_BUFFER_SMALL = 0x0000001A,
			CR_NO_ARBITRATOR = 0x0000001B,
			CR_NO_REGISTRY_HANDLE = 0x0000001C,
			CR_REGISTRY_ERROR = 0x0000001D,
			CR_INVALID_DEVICE_ID = 0x0000001E,
			CR_INVALID_DATA = 0x0000001F,
			CR_INVALID_API = 0x00000020,
			CR_DEVLOADER_NOT_READY = 0x00000021,
			CR_NEED_RESTART = 0x00000022,
			CR_NO_MORE_HW_PROFILES = 0x00000023,
			CR_DEVICE_NOT_THERE = 0x00000024,
			CR_NO_SUCH_VALUE = 0x00000025,
			CR_WRONG_TYPE = 0x00000026,
			CR_INVALID_PRIORITY = 0x00000027,
			CR_NOT_DISABLEABLE = 0x00000028,
			CR_FREE_RESOURCES = 0x00000029,
			CR_QUERY_VETOED = 0x0000002A,
			CR_CANT_SHARE_IRQ = 0x0000002B,
			CR_NO_DEPENDENT = 0x0000002C,
			CR_SAME_RESOURCES = 0x0000002D,
			CR_NO_SUCH_REGISTRY_KEY = 0x0000002E,
			CR_INVALID_MACHINENAME = 0x0000002F,   // NT ONLY
			CR_REMOTE_COMM_FAILURE = 0x00000030,   // NT ONLY
			CR_MACHINE_UNAVAILABLE = 0x00000031,   // NT ONLY
			CR_NO_CM_SERVICES = 0x00000032,   // NT ONLY
			CR_ACCESS_DENIED = 0x00000033,   // NT ONLY
			CR_CALL_NOT_IMPLEMENTED = 0x00000034,
			CR_INVALID_PROPERTY = 0x00000035,
			CR_DEVICE_INTERFACE_ACTIVE = 0x00000036,
			CR_NO_SUCH_DEVICE_INTERFACE = 0x00000037,
			CR_INVALID_REFERENCE_STRING = 0x00000038,
			CR_INVALID_CONFLICT_LIST = 0x00000039,
			CR_INVALID_INDEX = 0x0000003A,
			CR_INVALID_STRUCTURE_SIZE = 0x0000003B,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		}

		/// <summary>Caller-supplied flags that specify the type of the logical configuration.</summary>
		[PInvokeData("cfgmgr32.h")]
		public enum LOG_CONF_FLAG
		{
			/// <summary>Specifies the req list.</summary>
			BASIC_LOG_CONF = 0x00000000,

			/// <summary>Specifies the filtered req list.</summary>
			FILTERED_LOG_CONF = 0x00000001,

			/// <summary>Specifies the Alloc Element.</summary>
			ALLOC_LOG_CONF = 0x00000002,

			/// <summary>Specifies the RM Alloc Element.</summary>
			BOOT_LOG_CONF = 0x00000003,

			/// <summary>Specifies the Forced Log Conf</summary>
			FORCED_LOG_CONF = 0x00000004,

			/// <summary>Specifies the Override req list.</summary>
			OVERRIDE_LOG_CONF = 0x00000005,

			/// <summary>Number of Log Conf type</summary>
			NUM_LOG_CONF = 0x00000006,

			/// <summary>The bits of the log conf type.</summary>
			LOG_CONF_BITS = 0x00000007,

			/// <summary>Same priority, new one first</summary>
			PRIORITY_EQUAL_FIRST = 0x00000008,

			/// <summary>Same priority, new one last</summary>
			PRIORITY_EQUAL_LAST = 0x00000000,
		}

		/// <summary>
		/// If the PnP manager rejects a request to perform an operation, the PNP_VETO_TYPE enumeration is used to identify the reason for
		/// the rejection.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Text strings are associated with most of the veto types, and a function that receives a veto type value can typically request to
		/// also receive the value's associated text string. The following table identifies the text string associated with each value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>pVeto type value</term>
		/// <term>Text String</term>
		/// </listheader>
		/// <item>
		/// <term>PNP_VetoTypeUnknown</term>
		/// <term>None.</term>
		/// </item>
		/// <item>
		/// <term>PNP_VetoLegacyDevice</term>
		/// <term>A device instance path.</term>
		/// </item>
		/// <item>
		/// <term>PNP_VetoPendingClose</term>
		/// <term>A device instance path.</term>
		/// </item>
		/// <item>
		/// <term>PNP_VetoWindowsApp</term>
		/// <term>An application module name.</term>
		/// </item>
		/// <item>
		/// <term>PNP_VetoWindowsService</term>
		/// <term>A Windows service name.</term>
		/// </item>
		/// <item>
		/// <term>PNP_VetoOutstandingOpen</term>
		/// <term>A device instance path.</term>
		/// </item>
		/// <item>
		/// <term>PNP_VetoDevice</term>
		/// <term>A device instance path.</term>
		/// </item>
		/// <item>
		/// <term>PNP_VetoDriver</term>
		/// <term>A driver name.</term>
		/// </item>
		/// <item>
		/// <term>PNP_VetoIllegalDeviceRequest</term>
		/// <term>A device instance path.</term>
		/// </item>
		/// <item>
		/// <term>PNP_VetoInsufficientPower</term>
		/// <term>None.</term>
		/// </item>
		/// <item>
		/// <term>PNP_VetoNonDisableable</term>
		/// <term>A device instance path.</term>
		/// </item>
		/// <item>
		/// <term>PNP_VetoLegacyDriver</term>
		/// <term>A Windows service name.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfg/ne-cfg-pnp_veto_type typedef enum _PNP_VETO_TYPE { PNP_VetoTypeUnknown,
		// PNP_VetoLegacyDevice, PNP_VetoPendingClose, PNP_VetoWindowsApp, PNP_VetoWindowsService, PNP_VetoOutstandingOpen, PNP_VetoDevice,
		// PNP_VetoDriver, PNP_VetoIllegalDeviceRequest, PNP_VetoInsufficientPower, PNP_VetoNonDisableable, PNP_VetoLegacyDriver,
		// PNP_VetoInsufficientRights, PNP_VetoAlreadyRemoved } PNP_VETO_TYPE, *PPNP_VETO_TYPE;
		[PInvokeData("cfg.h", MSDNShortId = "NE:cfg._PNP_VETO_TYPE")]
		public enum PNP_VETO_TYPE
		{
			/// <summary>The specified operation was rejected for an unknown reason.</summary>
			PNP_VetoTypeUnknown,

			/// <summary>The device does not support the specified PnP operation.</summary>
			PNP_VetoLegacyDevice,

			/// <summary>The specified operation cannot be completed because of a pending close operation.</summary>
			PNP_VetoPendingClose,

			/// <summary>A Microsoft Win32 application vetoed the specified operation.</summary>
			PNP_VetoWindowsApp,

			/// <summary>A Win32 service vetoed the specified operation.</summary>
			PNP_VetoWindowsService,

			/// <summary>The requested operation was rejected because of outstanding open handles.</summary>
			PNP_VetoOutstandingOpen,

			/// <summary>The device supports the specified operation, but the device rejected the operation.</summary>
			PNP_VetoDevice,

			/// <summary>The driver supports the specified operation, but the driver rejected the operation.</summary>
			PNP_VetoDriver,

			/// <summary>The device does not support the specified operation.</summary>
			PNP_VetoIllegalDeviceRequest,

			/// <summary>There is insufficient power to perform the requested operation.</summary>
			PNP_VetoInsufficientPower,

			/// <summary>The device cannot be disabled.</summary>
			PNP_VetoNonDisableable,

			/// <summary>The driver does not support the specified PnP operation.</summary>
			PNP_VetoLegacyDriver,

			/// <summary>The caller has insufficient privileges to complete the operation.</summary>
			PNP_VetoInsufficientRights,
		}

		/// <summary>Caller-supplied configuration priority value.</summary>
		[PInvokeData("cfg.h")]
		public enum PRIORITY
		{
			/// <summary>Coming from a forced config</summary>
			LCPRI_FORCECONFIG = 0x00000000,

			/// <summary>Coming from a boot config</summary>
			LCPRI_BOOTCONFIG = 0x00000001,

			/// <summary>Preferable (better performance)</summary>
			LCPRI_DESIRED = 0x00002000,

			/// <summary>Workable (acceptable performance)</summary>
			LCPRI_NORMAL = 0x00003000,

			/// <summary>CM only--do not use</summary>
			LCPRI_LASTBESTCONFIG = 0x00003FFF,

			/// <summary>Not desired, but will work</summary>
			LCPRI_SUBOPTIMAL = 0x00005000,

			/// <summary>CM only--do not use</summary>
			LCPRI_LASTSOFTCONFIG = 0x00007FFF,

			/// <summary>Need to restart</summary>
			LCPRI_RESTART = 0x00008000,

			/// <summary>Need to reboot</summary>
			LCPRI_REBOOT = 0x00009000,

			/// <summary>Need to shutdown/power-off</summary>
			LCPRI_POWEROFF = 0x0000A000,

			/// <summary>Need to change a jumper</summary>
			LCPRI_HARDRECONFIG = 0x0000C000,

			/// <summary>Cannot be changed</summary>
			LCPRI_HARDWIRED = 0x0000E000,

			/// <summary>Impossible configuration</summary>
			LCPRI_IMPOSSIBLE = 0x0000F000,

			/// <summary>Disabled configuration</summary>
			LCPRI_DISABLED = 0x0000FFFF,
		}

		/// <summary>Caller-supplied resource type identifier, which identifies the type of structure supplied by ResourceData.</summary>
		[PInvokeData("cfgmgr32.h")]
		public enum RESOURCEID
		{
			/// <summary>Return all resource types</summary>
			ResType_All = 0x00000000,

			/// <summary>Arbitration always succeeded</summary>
			ResType_None = 0x00000000,

			/// <summary>Physical address resource</summary>
			ResType_Mem = 0x00000001,

			/// <summary>Physical I/O address resource</summary>
			ResType_IO = 0x00000002,

			/// <summary>DMA channels resource</summary>
			ResType_DMA = 0x00000003,

			/// <summary>IRQ resource</summary>
			ResType_IRQ = 0x00000004,

			/// <summary>Used as spacer to sync subsequent ResTypes w/NT</summary>
			ResType_DoNotUse = 0x00000005,

			/// <summary>bus number resource</summary>
			ResType_BusNumber = 0x00000006,

			/// <summary>Memory resources &gt;= 4GB</summary>
			ResType_MemLarge = 0x00000007,

			/// <summary>Maximum known (arbitrated) ResType</summary>
			ResType_MAX = 0x00000007,

			/// <summary>Ignore this resource</summary>
			ResType_Ignored_Bit = 0x00008000,

			/// <summary>class-specific resource</summary>
			ResType_ClassSpecific = 0x0000FFFF,

			/// <summary>reserved for internal use</summary>
			ResType_Reserved = 0x00008000,

			/// <summary>device private data</summary>
			ResType_DevicePrivate = 0x00008001,

			/// <summary>PC Card configuration data</summary>
			ResType_PcCardConfig = 0x00008002,

			/// <summary>MF Card configuration data</summary>
			ResType_MfCardConfig = 0x00008003,
		}

		/// <summary>
		/// The <c>CM_Add_Empty_Log_Conf</c> function creates an empty logical configuration, for a specified configuration type and a
		/// specified device instance, on the local machine.
		/// </summary>
		/// <param name="plcLogConf">Address of a location to receive the handle to an empty logical configuration.</param>
		/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
		/// <param name="Priority">
		/// <para>
		/// Caller-supplied configuration priority value. This must be one of the constant values listed in the following table. The
		/// constants are listed in order of priority, from highest to lowest. (For multiple configurations with the same ulFlags value, the
		/// system will attempt to use the one with the highest priority first.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Priority Constant</term>
		/// <term>Definition</term>
		/// </listheader>
		/// <item>
		/// <term>LCPRI_FORCECONFIG</term>
		/// <term>Result of a forced configuration.</term>
		/// </item>
		/// <item>
		/// <term>LCPRI_BOOTCONFIG</term>
		/// <term>Result of a boot configuration.</term>
		/// </item>
		/// <item>
		/// <term>LCPRI_DESIRED</term>
		/// <term>Preferred configuration (better performance).</term>
		/// </item>
		/// <item>
		/// <term>LCPRI_NORMAL</term>
		/// <term>Workable configuration (acceptable performance).</term>
		/// </item>
		/// <item>
		/// <term>LCPRI_LASTBESTCONFIG</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>LCPRI_SUBOPTIMAL</term>
		/// <term>Not a desirable configuration, but it will work.</term>
		/// </item>
		/// <item>
		/// <term>LCPRI_LASTSOFTCONFIG</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>LCPRI_RESTART</term>
		/// <term>The system must be restarted</term>
		/// </item>
		/// <item>
		/// <term>LCPRI_REBOOT</term>
		/// <term>The system must be restarted (same as LCPRI_RESTART).</term>
		/// </item>
		/// <item>
		/// <term>LCPRI_POWEROFF</term>
		/// <term>The system must be shut down and powered off.</term>
		/// </item>
		/// <item>
		/// <term>LCPRI_HARDRECONFIG</term>
		/// <term>A jumper must be changed.</term>
		/// </item>
		/// <item>
		/// <term>LCPRI_HARDWIRED</term>
		/// <term>The configuration cannot be changed.</term>
		/// </item>
		/// <item>
		/// <term>LCPRI_IMPOSSIBLE</term>
		/// <term>The configuration cannot exist.</term>
		/// </item>
		/// <item>
		/// <term>LCPRI_DISABLED</term>
		/// <term>Disabled configuration.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ulFlags">
		/// <para>Caller-supplied flags that specify the type of the logical configuration. One of the following flags must be specified.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Configuration Type Flags</term>
		/// <term>Definitions</term>
		/// </listheader>
		/// <item>
		/// <term>BASIC_LOG_CONF</term>
		/// <term>Resource descriptors added to this configuration will describe a basic configuration.</term>
		/// </item>
		/// <item>
		/// <term>FILTERED_LOG_CONF</term>
		/// <term>Do not use. (Only the PnP manager can create a filtered configuration.)</term>
		/// </item>
		/// <item>
		/// <term>ALLOC_LOG_CONF</term>
		/// <term>Do not use. (Only the PnP manager can create an allocated configuration.)</term>
		/// </item>
		/// <item>
		/// <term>BOOT_LOG_CONF</term>
		/// <term>Resource descriptors added to this configuration will describe a boot configuration.</term>
		/// </item>
		/// <item>
		/// <term>FORCED_LOG_CONF</term>
		/// <term>Resource descriptors added to this configuration will describe a forced configuration.</term>
		/// </item>
		/// <item>
		/// <term>OVERRIDE_LOG_CONF</term>
		/// <term>Resource descriptors added to this configuration will describe an override configuration.</term>
		/// </item>
		/// </list>
		/// <para>One of the following bit flags can be ORed with the configuration type flag.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Priority Comparison Flags</term>
		/// <term>Definitions</term>
		/// </listheader>
		/// <item>
		/// <term>PRIORITY_EQUAL_FIRST</term>
		/// <term>
		/// If multiple configurations of the same type (ulFlags) have the same priority (Priority), this configuration is placed at the
		/// head of the list.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PRIORITY_EQUAL_LAST</term>
		/// <term>
		/// (Default) If multiple configurations of the same type (ulFlags) have the same priority (Priority), this configuration is placed
		/// at the tail of the list.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </para>
		/// <para>
		/// <c>Note</c> Starting with Windows 8, <c>CM_Add_Empty_Log_Conf</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario.
		/// To request information about the hardware resources on a local machine it is necessary implement an architecture-native version
		/// of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Calling <c>CM_Add_Empty_Log_Conf</c> can cause the handles returned by CM_Get_First_Log_Conf and CM_Get_Next_Log_Conf to become
		/// invalid. Thus if you want to obtain logical configurations after calling <c>CM_Add_Empty_Log_Conf</c>, your code must call
		/// <c>CM_Get_First_Log_Conf</c> again and start at the first configuration.
		/// </para>
		/// <para>To remove a logical configuration created by <c>CM_Add_Empty_Log_Conf</c>, call CM_Free_Log_Conf.</para>
		/// <para>The handle received in plcLogConf must be explicitly freed by calling CM_Free_Log_Conf_Handle.</para>
		/// <para>
		/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
		/// </para>
		/// <para>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_add_empty_log_conf CMAPI CONFIGRET
		// CM_Add_Empty_Log_Conf( PLOG_CONF plcLogConf, DEVINST dnDevInst, PRIORITY Priority, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Add_Empty_Log_Conf")]
		public static extern CONFIGRET CM_Add_Empty_Log_Conf(out SafeLOG_CONF plcLogConf, uint dnDevInst, PRIORITY Priority, LOG_CONF_FLAG ulFlags);

		/// <summary>
		/// <para>
		/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Add_Empty_Log_Conf instead.]
		/// </para>
		/// <para>
		/// The <c>CM_Add_Empty_Log_Conf_Ex</c> function creates an empty logical configuration, for a specified configuration type and a
		/// specified device instance, on either the local or a remote machine.
		/// </para>
		/// </summary>
		/// <param name="plcLogConf">Pointer to a location to receive the handle to an empty logical configuration.</param>
		/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the machine handle supplied by hMachine.</param>
		/// <param name="Priority">
		/// Caller-supplied configuration priority value. For a list of values, see the Priority description for CM_Add_Empty_Log_Conf.
		/// </param>
		/// <param name="ulFlags">
		/// Caller-supplied flags that specify the type of the logical configuration. For a list of flags, see the description ulFlags
		/// description for CM_Add_Empty_Log_Conf.
		/// </param>
		/// <param name="hMachine">
		/// <para>Caller-supplied machine handle to which the caller-supplied device instance handle is bound.</para>
		/// <para>
		/// <c>Note</c> Using this function to access remote machines is not supported beginning with Windows 8 and Windows Server 2012, as
		/// this functionality has been removed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </para>
		/// <para>
		/// <c>Note</c> Starting with Windows 8, <c>CM_Add_Empty_Log_Conf_Ex</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64
		/// scenario. To request information about the hardware resources on a local machine it is necessary implement an
		/// architecture-native version of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Calling <c>CM_Add_Empty_Log_Conf_Ex</c> can cause the handles returned by CM_Get_First_Log_Conf_Ex and CM_Get_Next_Log_Conf_Ex
		/// to become invalid. Thus if you want to obtain logical configurations after calling <c>CM_Add_Empty_Log_Conf_Ex</c>, your code
		/// must call <c>CM_Get_First_Log_Conf_Ex</c> again and start at the first configuration.
		/// </para>
		/// <para>To remove a logical configuration created by <c>CM_Add_Empty_Log_Conf_Ex</c>, call CM_Free_Log_Conf_Ex.</para>
		/// <para>The handle received in plcLogConf must be explicitly freed by calling CM_Free_Log_Conf_Handle.</para>
		/// <para>
		/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
		/// </para>
		/// <para>For information about using device instance handles that are bound to a local or a remote machine, see CM_Get_Child_Ex.</para>
		/// <para>
		/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
		/// you cannot access remote machines when running on these versions of Windows.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_add_empty_log_conf_ex CMAPI CONFIGRET
		// CM_Add_Empty_Log_Conf_Ex( PLOG_CONF plcLogConf, DEVINST dnDevInst, PRIORITY Priority, ULONG ulFlags, HMACHINE hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Add_Empty_Log_Conf_Ex")]
		public static extern CONFIGRET CM_Add_Empty_Log_Conf_Ex(out SafeLOG_CONF plcLogConf, uint dnDevInst, PRIORITY Priority, LOG_CONF_FLAG ulFlags, HMACHINE hMachine);

		/// <summary>
		/// The <c>CM_Add_ID</c> function appends a specified device ID (if not already present) to a device instance's hardware ID list or
		/// compatible ID list.
		/// </summary>
		/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
		/// <param name="pszID">Caller-supplied pointer to a NULL-terminated device ID string.</param>
		/// <param name="ulFlags">
		/// <para>
		/// Caller-supplied flag constant that specifies the list onto which the supplied device ID should be appended. The following flag
		/// constants are valid.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag Constant</term>
		/// <term>Definition</term>
		/// </listheader>
		/// <item>
		/// <term>CM_ADD_ID_COMPATIBLE</term>
		/// <term>The specified device ID should be appended to the specific device instance's compatible ID list.</term>
		/// </item>
		/// <item>
		/// <term>CM_ADD_ID_HARDWARE</term>
		/// <term>The specified device ID should be appended to the specific device instance's hardware ID list.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CM_Add_ID</c> function can only be used when dnDevInst represents a root-enumerated device. For other devices, the bus
		/// driver reports hardware and compatible IDs when enumerating a child device after receiving IRP_MN_QUERY_ID.
		/// </para>
		/// <para>
		/// Each appended device ID is considered less compatible than IDs already existing in the specified list. For information about
		/// device IDs, hardware IDs, and compatible IDs, see Device Identification Strings.
		/// </para>
		/// <para>
		/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
		/// </para>
		/// <para>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_add_idw CMAPI CONFIGRET CM_Add_IDW( DEVINST dnDevInst,
		// PWSTR pszID, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Add_IDW")]
		public static extern CONFIGRET CM_Add_ID(uint dnDevInst, string pszID, CM_ADD_ID ulFlags);

		/// <summary>
		/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Add_ID instead.]</para>
		/// <para>
		/// The <c>CM_Add_ID_Ex</c> function appends a device ID (if not already present) to a device instance's hardware ID list or
		/// compatible ID list, on either the local or a remote machine.
		/// </para>
		/// </summary>
		/// <param name="dnDevInst">
		/// <para>Caller-supplied device instance handle that is bound to the machine handle supplied by</para>
		/// <para>hMachine</para>
		/// <para>.</para>
		/// </param>
		/// <param name="pszID">Caller-supplied pointer to a NULL-terminated device ID string.</param>
		/// <param name="ulFlags">
		/// <para>
		/// Caller-supplied flag constant that specifies the list onto which the supplied device ID should be appended. The following flag
		/// constants are valid.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag Constant</term>
		/// <term>Definition</term>
		/// </listheader>
		/// <item>
		/// <term>CM_ADD_ID_COMPATIBLE</term>
		/// <term>The specified device ID should be appended to the specific device instance's compatible ID list.</term>
		/// </item>
		/// <item>
		/// <term>CM_ADD_ID_HARDWARE</term>
		/// <term>The specified device ID should be appended to the specific device instance's hardware ID list.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hMachine">
		/// <para>Caller-supplied machine handle to which the caller-supplied device instance handle is bound.</para>
		/// <para>
		/// <c>Note</c> Using this function to access remote machines is not supported beginning with Windows 8 and Windows Server 2012, as
		/// this functionality has been removed.
		/// </para>
		/// </param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Each appended device ID is considered less compatible than IDs already existing in the specified list. For information about
		/// device IDs, hardware IDs, and compatible IDs, see Device Identification Strings.
		/// </para>
		/// <para>
		/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
		/// </para>
		/// <para>For information about using device instance handles that are bound to a local or a remote machine, see CM_Get_Child_Ex.</para>
		/// <para>
		/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
		/// you cannot access remote machines when running on these versions of Windows.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_add_id_exw CMAPI CONFIGRET CM_Add_ID_ExW( DEVINST
		// dnDevInst, PWSTR pszID, ULONG ulFlags, HMACHINE hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Add_ID_ExW")]
		public static extern CONFIGRET CM_Add_ID_Ex(uint dnDevInst, string pszID, CM_ADD_ID ulFlags, HMACHINE hMachine);

		/// <summary>The <c>CM_Add_Res_Des</c> function adds a resource descriptor to a logical configuration.</summary>
		/// <param name="prdResDes">Pointer to a location to receive a handle to the new resource descriptor.</param>
		/// <param name="lcLogConf">
		/// <para>
		/// Caller-supplied handle to the logical configuration to which the resource descriptor should be added. This handle must have been
		/// previously obtained by calling one of the following functions:
		/// </para>
		/// <para>CM_Add_Empty_Log_Conf</para>
		/// <para>CM_Add_Empty_Log_Conf_Ex</para>
		/// <para>CM_Get_First_Log_Conf</para>
		/// <para>CM_Get_First_Log_Conf_Ex</para>
		/// <para>CM_Get_Next_Log_Conf</para>
		/// <para>CM_Get_Next_Log_Conf_Ex</para>
		/// </param>
		/// <param name="ResourceID">
		/// Caller-supplied resource type identifier, which identifies the type of structure supplied by ResourceData. This must be one of
		/// the <c>ResType_</c>-prefixed constants defined in Cfgmgr32.h.
		/// </param>
		/// <param name="ResourceData">
		/// <para>Caller-supplied pointer to one of the resource structures listed in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>ResourceID Parameter</term>
		/// <term>Resource Structure</term>
		/// </listheader>
		/// <item>
		/// <term>ResType_BusNumber</term>
		/// <term>BUSNUMBER_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_ClassSpecific</term>
		/// <term>CS_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_DevicePrivate</term>
		/// <term>DEVPRIVATE_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_DMA</term>
		/// <term>DMA_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_IO</term>
		/// <term>IO_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_IRQ</term>
		/// <term>IRQ_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_Mem</term>
		/// <term>MEM_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_MfCardConfig</term>
		/// <term>MFCARD_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_PcCardConfig</term>
		/// <term>PCCARD_RESOURCE</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ResourceLen">Caller-supplied length of the structure pointed to by ResourceData.</param>
		/// <param name="ulFlags">Not used, must be zero.</param>
		/// <returns>
		/// <para>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </para>
		/// <para>
		/// <c>Note</c> Starting with Windows 8, <c>CM_Add_Res_Des</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario. To
		/// request information about the hardware resources on a local machine it is necessary implement an architecture-native version of
		/// the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Callers of <c>CM_Add_Res_Des</c> must call CM_Free_Res_Des_Handle to deallocate the resource descriptor handle, after it is no
		/// longer needed.
		/// </para>
		/// <para>
		/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_add_res_des CMAPI CONFIGRET CM_Add_Res_Des( PRES_DES
		// prdResDes, LOG_CONF lcLogConf, RESOURCEID ResourceID, PCVOID ResourceData, ULONG ResourceLen, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Add_Res_Des")]
		public static extern CONFIGRET CM_Add_Res_Des(out SafeRES_DES prdResDes, LOG_CONF lcLogConf, RESOURCEID ResourceID, IntPtr ResourceData, uint ResourceLen, uint ulFlags = 0);

		/// <summary>
		/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Add_Res_Des instead.]</para>
		/// <para>
		/// The <c>CM_Add_Res_Des_Ex</c> function adds a resource descriptor to a logical configuration. The logical configuration can be on
		/// either the local or a remote machine.
		/// </para>
		/// </summary>
		/// <param name="prdResDes">Pointer to a location to receive a handle to the new resource descriptor.</param>
		/// <param name="lcLogConf">
		/// <para>
		/// Caller-supplied handle to the logical configuration to which the resource descriptor should be added. This handle must have been
		/// previously obtained by calling one of the following functions:
		/// </para>
		/// <para>CM_Add_Empty_Log_Conf</para>
		/// <para>CM_Add_Empty_Log_Conf_Ex</para>
		/// <para>CM_Get_First_Log_Conf</para>
		/// <para>CM_Get_First_Log_Conf_Ex</para>
		/// <para>CM_Get_Next_Log_Conf</para>
		/// <para>CM_Get_Next_Log_Conf_Ex</para>
		/// </param>
		/// <param name="ResourceID">
		/// Caller-supplied resource type identifier, which identifies the type of structure supplied by ResourceData. This must be one of
		/// the <c>ResType_</c>-prefixed constants defined in Cfgmgr32.h.
		/// </param>
		/// <param name="ResourceData">
		/// <para>Caller-supplied pointer to one of the resource structures listed in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>ResourceID Parameter</term>
		/// <term>Resource Structure</term>
		/// </listheader>
		/// <item>
		/// <term>ResType_BusNumber</term>
		/// <term>BUSNUMBER_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_ClassSpecific</term>
		/// <term>CS_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_DevicePrivate</term>
		/// <term>DEVPRIVATE_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_DMA</term>
		/// <term>DMA_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_IO</term>
		/// <term>IO_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_IRQ</term>
		/// <term>IRQ_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_Mem</term>
		/// <term>MEM_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_MfCardConfig</term>
		/// <term>MFCARD_RESOURCE</term>
		/// </item>
		/// <item>
		/// <term>ResType_PcCardConfig</term>
		/// <term>PCCARD_RESOURCE</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ResourceLen">Caller-supplied length of the structure pointed to by ResourceData.</param>
		/// <param name="ulFlags">Not used, must be zero.</param>
		/// <param name="hMachine">
		/// <para>Caller-supplied machine handle, obtained from a previous call to CM_Connect_Machine, or <c>NULL</c>.</para>
		/// <para>
		/// <c>Note</c> Using this function to access remote machines is not supported beginning with Windows 8 and Windows Server 2012, as
		/// this functionality has been removed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </para>
		/// <para>
		/// <c>Note</c> Starting with Windows 8, <c>CM_Add_Res_Des_Ex</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario. To
		/// request information about the hardware resources on a local machine it is necessary implement an architecture-native version of
		/// the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Callers of <c>CM_Add_Res_Des_Ex</c> must call CM_Free_Res_Des_Handle to deallocate the resource descriptor handle, after it is
		/// no longer needed.
		/// </para>
		/// <para>
		/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
		/// </para>
		/// <para>
		/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
		/// you cannot access remote machines when running on these versions of Windows.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_add_res_des_ex CMAPI CONFIGRET CM_Add_Res_Des_Ex(
		// PRES_DES prdResDes, LOG_CONF lcLogConf, RESOURCEID ResourceID, PCVOID ResourceData, ULONG ResourceLen, ULONG ulFlags, HMACHINE
		// hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Add_Res_Des_Ex")]
		public static extern CONFIGRET CM_Add_Res_Des_Ex(out SafeRES_DES prdResDes, LOG_CONF lcLogConf, RESOURCEID ResourceID, IntPtr ResourceData,
			uint ResourceLen, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

		/// <summary>
		/// <para>
		/// [Beginning in Windows 8 and Windows Server 2012 functionality to access remote machines has been removed. You cannot access
		/// remote machines when running on these versions of Windows.]
		/// </para>
		/// <para>The <c>CM_Connect_Machine</c> function creates a connection to a remote machine.</para>
		/// </summary>
		/// <param name="UNCServerName">
		/// Caller-supplied pointer to a text string representing the UNC name, including the <c>\</c> prefix, of the system for which a
		/// connection will be made. If the pointer is <c>NULL</c>, the local system is used.
		/// </param>
		/// <param name="phMachine">
		/// <para>Address of a location to receive a machine handle.</para>
		/// <para>
		/// <c>Note</c> Using this function to access remote machines is not supported beginning with Windows 8 and Windows Server 2012, as
		/// this functionality has been removed.
		/// </para>
		/// </param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Callers of <c>CM_Connect_Machine</c> must call CM_Disconnect_Machine to deallocate the machine handle, after it is no longer needed.
		/// </para>
		/// <para>Use machine handles obtained with this function only with the PnP configuration manager functions.</para>
		/// <para>
		/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
		/// you cannot access remote machines when running on these versions of Windows.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_connect_machinew CMAPI CONFIGRET CM_Connect_MachineW(
		// PCWSTR UNCServerName, PHMACHINE phMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Connect_MachineW")]
		public static extern CONFIGRET CM_Connect_Machine(string UNCServerName, out SafeHMACHINE phMachine);

		/// <summary>
		/// <para>
		/// [Beginning in Windows 8 and Windows Server 2012 functionality to access remote machines has been removed. You cannot access
		/// remote machines when running on these versions of Windows.]
		/// </para>
		/// <para>The <c>CM_Disconnect_Machine</c> function removes a connection to a remote machine.</para>
		/// </summary>
		/// <param name="hMachine">
		/// <para>Caller-supplied machine handle, obtained from a previous call to CM_Connect_Machine.</para>
		/// <para>
		/// <c>Note</c> Using this function to access remote machines is not supported beginning with Windows 8 and Windows Server 2012, as
		/// this functionality has been removed.
		/// </para>
		/// </param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
		/// you cannot access remote machines when running on these versions of Windows.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_disconnect_machine CMAPI CONFIGRET
		// CM_Disconnect_Machine( HMACHINE hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Disconnect_Machine")]
		public static extern CONFIGRET CM_Disconnect_Machine(HMACHINE hMachine);

		/// <summary>
		/// The <c>CM_Free_Log_Conf</c> function removes a logical configuration and all associated resource descriptors from the local machine.
		/// </summary>
		/// <param name="lcLogConfToBeFreed">
		/// <para>
		/// Caller-supplied handle to a logical configuration. This handle must have been previously obtained by calling one of the
		/// following functions:
		/// </para>
		/// <para>CM_Add_Empty_Log_Conf</para>
		/// <para>CM_Add_Empty_Log_Conf_Ex</para>
		/// <para>CM_Get_First_Log_Conf</para>
		/// <para>CM_Get_First_Log_Conf_Ex</para>
		/// <para>CM_Get_Next_Log_Conf</para>
		/// <para>CM_Get_Next_Log_Conf_Ex</para>
		/// </param>
		/// <param name="ulFlags">Not used, must be zero.</param>
		/// <returns>
		/// <para>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </para>
		/// <para>
		/// <c>Note</c> Starting with Windows 8, <c>CM_Free_Log_Conf</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario. To
		/// request information about the hardware resources on a local machine it is necessary implement an architecture-native version of
		/// the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Calling <c>CM_Free_Log_Conf</c> can cause the handles returned by CM_Get_First_Log_Conf and CM_Get_Next_Log_Conf to become
		/// invalid. Thus if you want to obtain logical configurations after calling <c>CM_Free_Log_Conf</c>, your code must call
		/// <c>CM_Get_First_Log_Conf</c> again and start at the first configuration.
		/// </para>
		/// <para>
		/// Note that calling <c>CM_Free_Log_Conf</c> frees the configuration, but not the configuration's handle. To free the handle, call <c>CM_Free_Log_Conf_Handle</c>.
		/// </para>
		/// <para>
		/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_free_log_conf CMAPI CONFIGRET CM_Free_Log_Conf(
		// LOG_CONF lcLogConfToBeFreed, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Free_Log_Conf")]
		public static extern CONFIGRET CM_Free_Log_Conf([In] LOG_CONF lcLogConfToBeFreed, uint ulFlags = 0);

		/// <summary>
		/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Free_Log_Conf instead.]</para>
		/// <para>
		/// The <c>CM_Free_Log_Conf_Ex</c> function removes a logical configuration and all associated resource descriptors from either a
		/// local or a remote machine.
		/// </para>
		/// </summary>
		/// <param name="lcLogConfToBeFreed">
		/// <para>
		/// Caller-supplied handle to a logical configuration. This handle must have been previously obtained by calling one of the
		/// following functions:
		/// </para>
		/// <para>CM_Add_Empty_Log_Conf</para>
		/// <para>CM_Add_Empty_Log_Conf_Ex</para>
		/// <para>CM_Get_First_Log_Conf</para>
		/// <para>CM_Get_First_Log_Conf_Ex</para>
		/// <para>CM_Get_Next_Log_Conf</para>
		/// <para>CM_Get_Next_Log_Conf_Ex</para>
		/// </param>
		/// <param name="ulFlags">Not used, must be zero.</param>
		/// <param name="hMachine">
		/// <para>Caller-supplied machine handle, obtained from a previous call to CM_Connect_Machine.</para>
		/// <para>
		/// <c>Note</c> Using this function to access remote machines is not supported beginning with Windows 8 and Windows Server 2012, as
		/// this functionality has been removed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </para>
		/// <para>
		/// <c>Note</c> Starting with Windows 8, <c>CM_Free_Log_Conf_Ex</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario.
		/// To request information about the hardware resources on a local machine it is necessary implement an architecture-native version
		/// of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Calling <c>CM_Free_Log_Conf_Ex</c> can cause the handles returned by CM_Get_First_Log_Conf_Ex and CM_Get_Next_Log_Conf_Ex to
		/// become invalid. Thus if you want to obtain logical configurations after calling <c>CM_Free_Log_Conf_Ex</c>, your code must call
		/// <c>CM_Get_First_Log_Conf_Ex</c> again and start at the first configuration.
		/// </para>
		/// <para>
		/// Note that calling <c>CM_Free_Log_Conf_Ex</c> frees the configuration, but not the configuration's handle. To free the handle,
		/// call <c>CM_Free_Log_Conf_Handle_Ex</c>.
		/// </para>
		/// <para>
		/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
		/// </para>
		/// <para>
		/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
		/// you cannot access remote machines when running on these versions of Windows.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_free_log_conf_ex CMAPI CONFIGRET CM_Free_Log_Conf_Ex(
		// LOG_CONF lcLogConfToBeFreed, ULONG ulFlags, HMACHINE hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Free_Log_Conf_Ex")]
		public static extern CONFIGRET CM_Free_Log_Conf_Ex([In] LOG_CONF lcLogConfToBeFreed, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

		/// <summary>The <c>CM_Free_Res_Des</c> function removes a resource descriptor from a logical configuration on the local machine.</summary>
		/// <param name="prdResDes">
		/// Caller-supplied location to receive a handle to the configuration's previous resource descriptor. This parameter can be
		/// <c>NULL</c>. For more information, see the following <c>Remarks</c> section.
		/// </param>
		/// <param name="rdResDes">
		/// <para>
		/// Caller-supplied handle to the resource descriptor to be removed. This handle must have been previously obtained by calling one
		/// of the following functions:
		/// </para>
		/// <para>CM_Add_Res_Des</para>
		/// <para>CM_Add_Res_Des_Ex</para>
		/// <para>CM_Get_Next_Res_Des</para>
		/// <para>CM_Get_Next_Res_Des_Ex</para>
		/// <para>CM_Modify_Res_Des</para>
		/// <para>CM_Modify_Res_Des_Ex</para>
		/// </param>
		/// <param name="ulFlags">Not used, must be zero.</param>
		/// <returns>
		/// <para>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </para>
		/// <para>
		/// <c>Note</c> Starting with Windows 8, <c>CM_Free_Res_Des</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario. To
		/// request information about the hardware resources on a local machine it is necessary implement an architecture-native version of
		/// the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Resource descriptors for each configuration are stored in an array. If you specify an address for prdResDes, then
		/// <c>CM_Free_Res_Des</c> returns a handle to the resource descriptor that was previous, in the array, to the one removed. If the
		/// handle specified by rdResDes represents the resource descriptor located first in the array, then prdResDes receives a handle to
		/// the logical configuration.
		/// </para>
		/// <para>
		/// Note that calling <c>CM_Free_Res_Des</c> frees the resource descriptor, but not the descriptor's handle. To free the handle,
		/// call <c>CM_Free_Res_Des_Handle</c>.
		/// </para>
		/// <para>
		/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_free_res_des CMAPI CONFIGRET CM_Free_Res_Des( PRES_DES
		// prdResDes, RES_DES rdResDes, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Free_Res_Des")]
		public static extern CONFIGRET CM_Free_Res_Des(out SafeRES_DES prdResDes, RES_DES rdResDes, uint ulFlags = 0);

		/// <summary>
		/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Free_Res_Des instead.]</para>
		/// <para>
		/// The <c>CM_Free_Res_Des_Ex</c> function removes a resource descriptor from a logical configuration on either a local or a remote machine.
		/// </para>
		/// </summary>
		/// <param name="prdResDes">
		/// Caller-supplied location to receive a handle to the configuration's previous resource descriptor. This parameter can be
		/// <c>NULL</c>. For more information, see the following <c>Remarks</c> section.
		/// </param>
		/// <param name="rdResDes">
		/// <para>
		/// Caller-supplied handle to the resource descriptor to be removed. This handle must have been previously obtained by calling one
		/// of the following functions:
		/// </para>
		/// <para>CM_Add_Res_Des</para>
		/// <para>CM_Add_Res_Des_Ex</para>
		/// <para>CM_Get_Next_Res_Des</para>
		/// <para>CM_Get_Next_Res_Des_Ex</para>
		/// <para>CM_Modify_Res_Des</para>
		/// <para>CM_Modify_Res_Des_Ex</para>
		/// </param>
		/// <param name="ulFlags">Not used, must be zero.</param>
		/// <param name="hMachine">
		/// <para>Caller-supplied machine handle, obtained from a previous call to CM_Connect_Machine.</para>
		/// <para>
		/// <c>Note</c> Using this function to access remote machines is not supported beginning with Windows 8 and Windows Server 2012, as
		/// this functionality has been removed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </para>
		/// <para>
		/// <c>Note</c> Starting with Windows 8, <c>CM_Free_Res_Des_Ex</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario. To
		/// request information about the hardware resources on a local machine it is necessary implement an architecture-native version of
		/// the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Resource descriptors for each configuration are stored in an array. If you specify an address for prdResDes, then
		/// <c>CM_Free_Res_Des</c> returns a handle to the resource descriptor that was previous, in the array, to the one removed. If the
		/// handle specified by rdResDes represents the resource descriptor located first in the array, then prdResDes receives a handle to
		/// the logical configuration.
		/// </para>
		/// <para>
		/// Note that calling <c>CM_Free_Res_Des_Ex</c> frees the resource descriptor, but not the descriptor's handle. To free the handle,
		/// call <c>CM_Free_Res_Des_Handle_Ex</c>.
		/// </para>
		/// <para>
		/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
		/// </para>
		/// <para>
		/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
		/// you cannot access remote machines when running on these versions of Windows.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_free_res_des_ex CMAPI CONFIGRET CM_Free_Res_Des_Ex(
		// PRES_DES prdResDes, RES_DES rdResDes, ULONG ulFlags, HMACHINE hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Free_Res_Des_Ex")]
		public static extern CONFIGRET CM_Free_Res_Des_Ex(out SafeRES_DES prdResDes, RES_DES rdResDes, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

		/// <summary>
		/// The <c>CM_Free_Res_Des_Handle</c> function invalidates a resource description handle and frees its associated memory allocation.
		/// </summary>
		/// <param name="rdResDes">
		/// <para>
		/// Caller-supplied resource descriptor handle to be freed. This handle must have been previously obtained by calling one of the
		/// following functions:
		/// </para>
		/// <para>CM_Add_Res_Des</para>
		/// <para>CM_Add_Res_Des_Ex</para>
		/// <para>CM_Get_Next_Res_Des</para>
		/// <para>CM_Get_Next_Res_Des_Ex</para>
		/// <para>CM_Modify_Res_Des</para>
		/// <para>CM_Modify_Res_Des_Ex</para>
		/// </param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// Each time your code calls one of the functions listed under the description of rdResDes, it must subsequently call <c>CM_Free_Res_Des_Handle</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_free_res_des_handle CMAPI CONFIGRET
		// CM_Free_Res_Des_Handle( RES_DES rdResDes );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Free_Res_Des_Handle")]
		public static extern CONFIGRET CM_Free_Res_Des_Handle(RES_DES rdResDes);

		/// <summary>
		/// The <c>CM_Get_Parent</c> function obtains a device instance handle to the parent node of a specified device node (devnode) in
		/// the local machine's device tree.
		/// </summary>
		/// <param name="pdnDevInst">
		/// Caller-supplied pointer to the device instance handle to the parent node that this function retrieves. The retrieved handle is
		/// bound to the local machine.
		/// </param>
		/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
		/// <param name="ulFlags">Not used, must be zero.</param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>For information about using a device instance handle that is bound to the local machine, see CM_Get_Child.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_parent CMAPI CONFIGRET CM_Get_Parent( PDEVINST
		// pdnDevInst, DEVINST dnDevInst, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Parent")]
		public static extern CONFIGRET CM_Get_Parent(out uint pdnDevInst, uint dnDevInst, uint ulFlags = 0);

		/// <summary>
		/// The <c>CM_Request_Device_Eject</c> function prepares a local device instance for safe removal, if the device is removable. If
		/// the device can be physically ejected, it will be.
		/// </summary>
		/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
		/// <param name="pVetoType">
		/// (Optional.) If not <c>NULL</c>, this points to a location that, if the removal request fails, receives a PNP_VETO_TYPE-typed
		/// value indicating the reason for the failure.
		/// </param>
		/// <param name="pszVetoName">
		/// (Optional.) If not <c>NULL</c>, this is a caller-supplied pointer to a string buffer that receives a text string. The type of
		/// information this string provides is dependent on the value received by pVetoType. For information about these strings, see PNP_VETO_TYPE.
		/// </param>
		/// <param name="ulNameLength">
		/// (Optional.) Caller-supplied value representing the length of the string buffer supplied by pszVetoName. This should be set to MAX_PATH.
		/// </param>
		/// <param name="ulFlags">Not used.</param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If pszVetoName is <c>NULL</c>, the PnP manager displays a message to the user indicating the device was removed or, if the
		/// request failed, identifying the reason for the failure. If pszVetoName is not <c>NULL</c>, the PnP manager does not display a
		/// message. (Note, however, that for Microsoft Windows 2000 only, the PnP manager displays a message even if pszVetoName is not
		/// <c>NULL</c>, if the device's CM_DEVCAP_DOCKDEVICE capability is set.)
		/// </para>
		/// <para>
		/// Callers of <c>CM_Request_Device_Eject</c> sometimes require <c>SeUndockPrivilege</c> or <c>SeLoadDriverPrivilege</c>, as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the device's CM_DEVCAP_DOCKDEVICE capability is set (the device is a "dock" device), callers must have
		/// <c>SeUndockPrivilege</c>. ( <c>SeLoadDriverPrivilege</c> is not required.)
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the device's CM_DEVCAP_DOCKDEVICE capability is not set (the device is not a "dock" device), and if the calling process is
		/// either not interactive or is running in a multi-user environment in a session not attached to the physical console (such as a
		/// remote Terminal Services session), callers of this function must have <c>SeLoadDriverPrivilege</c>.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Privileges are described in the Microsoft Windows SDK documentation.</para>
		/// <para>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_request_device_ejectw CMAPI CONFIGRET
		// CM_Request_Device_EjectW( DEVINST dnDevInst, PPNP_VETO_TYPE pVetoType, LPWSTR pszVetoName, ULONG ulNameLength, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Request_Device_EjectW")]
		public static extern CONFIGRET CM_Request_Device_Eject(uint dnDevInst, out PNP_VETO_TYPE pVetoType, [In, Out, Optional] StringBuilder pszVetoName, [Optional] uint ulNameLength, uint ulFlags = 0);

		/// <summary>Provides a handle to a device instance.</summary>
		[StructLayout(LayoutKind.Sequential), System.Diagnostics.DebuggerDisplay("{handle}")]
		public struct HMACHINE
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HMACHINE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HMACHINE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HMACHINE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HMACHINE NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HMACHINE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HMACHINE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HMACHINE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HMACHINE(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HMACHINE h1, HMACHINE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HMACHINE h1, HMACHINE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HMACHINE h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a logical configuration.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct LOG_CONF : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="LOG_CONF"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public LOG_CONF(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="LOG_CONF"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static LOG_CONF NULL => new LOG_CONF(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="LOG_CONF"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(LOG_CONF h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="LOG_CONF"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator LOG_CONF(IntPtr h) => new LOG_CONF(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(LOG_CONF h1, LOG_CONF h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(LOG_CONF h1, LOG_CONF h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is LOG_CONF h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a resource descriptor.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct RES_DES : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="RES_DES"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public RES_DES(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="RES_DES"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static RES_DES NULL => new RES_DES(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="RES_DES"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(RES_DES h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="RES_DES"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator RES_DES(IntPtr h) => new RES_DES(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(RES_DES h1, RES_DES h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(RES_DES h1, RES_DES h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is RES_DES h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HMACHINE"/> that is disposed using <see cref="CM_Disconnect_Machine"/>.</summary>
		public class SafeHMACHINE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHMACHINE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHMACHINE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHMACHINE"/> class.</summary>
			private SafeHMACHINE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHMACHINE"/> to <see cref="HMACHINE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HMACHINE(SafeHMACHINE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => CM_Disconnect_Machine(handle) == 0;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="LOG_CONF"/> that is disposed using <see cref="CM_Free_Log_Conf"/>.</summary>
		public class SafeLOG_CONF : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeLOG_CONF"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeLOG_CONF(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeLOG_CONF"/> class.</summary>
			private SafeLOG_CONF() : base() { }

			/// <summary>Gets or sets the machine handle obtained through <see cref="CM_Machine_Connect"/>.</summary>
			public HMACHINE hMachine { get; set; }

			/// <summary>Performs an implicit conversion from <see cref="SafeLOG_CONF"/> to <see cref="LOG_CONF"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator LOG_CONF(SafeLOG_CONF h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => hMachine.IsNull ? CM_Free_Log_Conf(handle) == 0 : CM_Free_Log_Conf_Ex(handle, 0, hMachine) == 0;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="RES_DES"/> that is disposed using <see cref="CM_Free_Res_Des_Handle"/>.</summary>
		public class SafeRES_DES : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeRES_DES"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeRES_DES(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeRES_DES"/> class.</summary>
			private SafeRES_DES() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeRES_DES"/> to <see cref="RES_DES"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator RES_DES(SafeRES_DES h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => CM_Free_Res_Des_Handle(handle) == 0;
		}

		/*
		CM_Delete_Class_Key
		CM_Delete_Device_Interface_Key_ExA
		CM_Delete_Device_Interface_Key_ExW
		CM_Delete_Device_Interface_KeyW
		CM_Delete_DevNode_Key
		CM_Disable_DevNode
		CM_Enable_DevNode
		CM_Enumerate_Classes
		CM_Enumerate_Classes_Ex
		CM_Enumerate_Enumerators_ExW
		CM_Enumerate_EnumeratorsW
		CM_Free_Log_Conf_Handle
		CM_Free_Resource_Conflict_Handle
		CM_Get_Child
		CM_Get_Child_Ex
		CM_Get_Class_Property_ExW
		CM_Get_Class_Property_Keys
		CM_Get_Class_Property_Keys_Ex
		CM_Get_Class_PropertyW
		CM_Get_Class_Registry_PropertyW
		CM_Get_Depth
		CM_Get_Depth_Ex
		CM_Get_Device_ID_ExW
		CM_Get_Device_ID_List_ExW
		CM_Get_Device_ID_List_Size_ExW
		CM_Get_Device_ID_List_SizeA
		CM_Get_Device_ID_List_SizeW
		CM_Get_Device_ID_ListA
		CM_Get_Device_ID_ListW
		CM_Get_Device_ID_Size
		CM_Get_Device_ID_Size_Ex
		CM_Get_Device_IDW
		CM_Get_Device_Interface_AliasW
		CM_Get_Device_Interface_List_SizeA
		CM_Get_Device_Interface_List_SizeW
		CM_Get_Device_Interface_ListA
		CM_Get_Device_Interface_ListW
		CM_Get_Device_Interface_Property_ExW
		CM_Get_Device_Interface_Property_Keys_ExW
		CM_Get_Device_Interface_Property_KeysW
		CM_Get_Device_Interface_PropertyW
		CM_Get_DevNode_Property_ExW
		CM_Get_DevNode_Property_Keys
		CM_Get_DevNode_Property_Keys_Ex
		CM_Get_DevNode_PropertyW
		CM_Get_DevNode_Registry_PropertyW
		CM_Get_DevNode_Status
		CM_Get_DevNode_Status_Ex
		CM_Get_First_Log_Conf
		CM_Get_First_Log_Conf_Ex
		CM_Get_HW_Prof_Flags_ExA
		CM_Get_HW_Prof_Flags_ExW
		CM_Get_HW_Prof_FlagsA
		CM_Get_HW_Prof_FlagsW
		CM_Get_Log_Conf_Priority
		CM_Get_Log_Conf_Priority_Ex
		CM_Get_Next_Log_Conf
		CM_Get_Next_Log_Conf_Ex
		CM_Get_Next_Res_Des
		CM_Get_Next_Res_Des_Ex
		CM_Get_Parent
		CM_Get_Parent_Ex
		CM_Get_Res_Des_Data
		CM_Get_Res_Des_Data_Ex
		CM_Get_Res_Des_Data_Size
		CM_Get_Res_Des_Data_Size_Ex
		CM_Get_Resource_Conflict_Count
		CM_Get_Resource_Conflict_DetailsW
		CM_Get_Sibling
		CM_Get_Sibling_Ex
		CM_Get_Version
		CM_Get_Version_Ex
		CM_Is_Dock_Station_Present
		CM_Is_Dock_Station_Present_Ex
		CM_Is_Version_Available
		CM_Is_Version_Available_Ex
		CM_Locate_DevNode_ExW
		CM_Locate_DevNodeA
		CM_Locate_DevNodeW
		CM_MapCrToWin32Err
		CM_Modify_Res_Des
		CM_Modify_Res_Des_Ex
		CM_Open_Class_KeyW
		CM_Open_Device_Interface_Key_ExA
		CM_Open_Device_Interface_Key_ExW
		CM_Open_Device_Interface_KeyA
		CM_Open_Device_Interface_KeyW
		CM_Open_DevNode_Key
		CM_Query_And_Remove_SubTree_ExW
		CM_Query_And_Remove_SubTreeW
		CM_Query_Resource_Conflict_List
		CM_Reenumerate_DevNode
		CM_Reenumerate_DevNode_Ex
		CM_Register_Notification
		CM_Request_Device_Eject_ExW
		CM_Request_Device_EjectW
		CM_Request_Eject_PC
		CM_Request_Eject_PC_Ex
		CM_Set_Class_Property_ExW
		CM_Set_Class_PropertyW
		CM_Set_Class_Registry_PropertyW
		CM_Set_Device_Interface_Property_ExW
		CM_Set_Device_Interface_PropertyW
		CM_Set_DevNode_Problem
		CM_Set_DevNode_Problem_Ex
		CM_Set_DevNode_Property_ExW
		CM_Set_DevNode_PropertyW
		CM_Set_DevNode_Registry_PropertyW
		CM_Setup_DevNode
		CM_Uninstall_DevNode
		CM_Unregister_Notification
		CM_WaitNoPendingInstallEvents

		BUSNUMBER_DES
		BUSNUMBER_RANGE
		BUSNUMBER_RESOURCE
		CM_NOTIFY_EVENT_DATA
		CM_NOTIFY_FILTER
		CONFLICT_DETAILS_A
		CONFLICT_DETAILS_W
		CS_DES
		CS_RESOURCE
		DMA_DES
		DMA_RANGE
		DMA_RESOURCE
		IO_DES
		IO_RANGE
		IO_RESOURCE
		IRQ_DES_32
		IRQ_DES_64
		IRQ_RANGE
		IRQ_RESOURCE_32
		IRQ_RESOURCE_64
		MEM_DES
		MEM_RANGE
		MEM_RESOURCE
		MFCARD_DES
		MFCARD_RESOURCE
		PCCARD_DES
		PCCARD_RESOURCE

		CM_NOTIFY_ACTION

		 */
	}
}