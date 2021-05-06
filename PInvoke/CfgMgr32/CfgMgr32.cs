using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.SetupAPI;

namespace Vanara.PInvoke
{
	/// <summary>
	/// Items from the CfgMgr32.dll
	/// </summary>
	public static partial class CfgMgr32
	{
		// Win95 compatibility--not applicable to 32-bit ConfigMgr Win95 compatibility--not applicable to 32-bit ConfigMgr Win95
		// compatibility--not applicable to 32-bit ConfigMgr
		private const string Lib_Cfgmgr32 = "CfgMgr32.dll";

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

		/// <summary>Caller-supplied flag constant that specifies the list onto which the supplied device ID should be appended.</summary>
		[PInvokeData("cfgmgr32.h")]
		public enum CM_ADD_ID
		{
			/// <summary></summary>
			CM_ADD_ID_HARDWARE = 0x00000000,

			/// <summary></summary>
			CM_ADD_ID_COMPATIBLE = 0x00000001,
		}

		/// <summary>Class property flags</summary>
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Class_Property_ExW")]
		public enum CM_CLASS_PROPERTY
		{
			/// <summary>ClassGUID specifies a device setup class. Do not combine with CM_CLASS_PROPERTY_INTERFACE.</summary>
			CM_CLASS_PROPERTY_INSTALLER = 0x00000000,

			/// <summary>ClassGUID specifies a device interface class. Do not combine with CM_CLASS_PROPERTY_INSTALLER.</summary>
			CM_CLASS_PROPERTY_INTERFACE = 0x00000001,
		}

		/// <summary>
		/// A value of type ULONG that identifies the property to be retrieved.
		/// </summary>
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Class_Registry_PropertyW")]
		public enum CM_CRP
		{
			/// <summary>UpperFilters REG_MULTI_SZ property (RW)</summary>
			CM_CRP_UPPERFILTERS = CM_DRP.CM_DRP_UPPERFILTERS,

			/// <summary>LowerFilters REG_MULTI_SZ property (RW)</summary>
			CM_CRP_LOWERFILTERS = CM_DRP.CM_DRP_LOWERFILTERS,

			/// <summary>Class default security (RW)</summary>
			CM_CRP_SECURITY = CM_DRP.CM_DRP_SECURITY,

			/// <summary>Class default security (RW)</summary>
			CM_CRP_SECURITY_SDS = CM_DRP.CM_DRP_SECURITY_SDS,

			/// <summary>Class default Device-type (RW)</summary>
			CM_CRP_DEVTYPE = CM_DRP.CM_DRP_DEVTYPE,

			/// <summary>Class default (RW)</summary>
			CM_CRP_EXCLUSIVE = CM_DRP.CM_DRP_EXCLUSIVE,

			/// <summary>Class default (RW)</summary>
			CM_CRP_CHARACTERISTICS = CM_DRP.CM_DRP_CHARACTERISTICS,
		}

		/// <summary>Delete class key flags</summary>
		[PInvokeData("cfgmgr32.h")]
		public enum CM_DELETE_CLASS
		{
			/// <summary>Delete the class only if it does not contain any subkeys.</summary>
			CM_DELETE_CLASS_ONLY = 0x00000000,

			/// <summary>Delete the class and all of its subkeys.</summary>
			CM_DELETE_CLASS_SUBKEYS = 0x00000001,

			/// <summary>Indicates that ClassGuid specifies a device interface class and not a device setup class.</summary>
			CM_DELETE_CLASS_INTERFACE = 0x00000002,
		}

		/// <summary>Disable flags</summary>
		[PInvokeData("cfgmgr32.h")]
		[Flags]
		public enum CM_DISABLE : uint
		{
			/// <summary>Ask the driver</summary>
			CM_DISABLE_POLITE = 0x00000000,

			/// <summary>Don't ask the driver</summary>
			CM_DISABLE_ABSOLUTE = 0x00000001,

			/// <summary>Don't ask the driver, and won't be restarteable</summary>
			CM_DISABLE_HARDWARE = 0x00000002,

			/// <summary>Do not display any interface to the user if the attempt to disable the device fails.</summary>
			CM_DISABLE_UI_NOT_OK = 0x00000004,

			/// <summary>Disables the device across reboots.</summary>
			CM_DISABLE_PERSIST = 0x00000008,
		}

		/// <summary>Enumerate flags.</summary>
		[Flags]
		public enum CM_ENUMERATE_CLASSES : uint
		{
			/// <summary>Enumerate device setup classes.</summary>
			CM_ENUMERATE_CLASSES_INSTALLER = 0x00000000,

			/// <summary>Enumerate device interface classes.</summary>
			CM_ENUMERATE_CLASSES_INTERFACE = 0x00000001,
		}

		/// <summary>One of the following caller-supplied bit flags that specifies search filters.</summary>
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_ID_ListA")]
		[Flags]
		public enum CM_GETIDLIST
		{
			/// <summary>If this flag is set, pszFilter is ignored, and a list of all devices on the system is returned.</summary>
			CM_GETIDLIST_FILTER_NONE = 0x00000000,

			/// <summary>
			/// <para>
			/// If this flag is set, pszFilter must specify the name of a device enumerator, optionally followed by a device ID. The string
			/// format is EnumeratorName\&lt;DeviceID&gt;, such as <c>ROOT</c> or <c>ROOT\*PNP0500</c>.
			/// </para>
			/// <para>
			/// If pszFilter supplies only an enumerator name, the function returns device instance IDs for the instances of each device
			/// associated with the enumerator. Enumerator names can be obtained by calling CM_Enumerate_Enumerators.
			/// </para>
			/// <para>
			/// If pszFilter supplies both an enumerator and a device ID, the function returns device instance IDs only for the instances of
			/// the specified device that is associated with the enumerator.
			/// </para>
			/// </summary>
			CM_GETIDLIST_FILTER_ENUMERATOR = 0x00000001,

			/// <summary>
			/// <para>
			/// If this flag is set, pszFilter must specify the name of a Microsoft Windows service (typically a driver). The function
			/// returns device instance IDs for the device instances controlled by the specified service.
			/// </para>
			/// <para>
			/// Note that if the device tree does not contain a devnode for the specified service, this function creates one by default. To
			/// inhibit this behavior, also set CM_GETIDLIST_DONOTGENERATE.
			/// </para>
			/// </summary>
			CM_GETIDLIST_FILTER_SERVICE = 0x00000002,

			/// <summary>
			/// If this flag is set, pszFilter must specify a device instance identifier. The function returns device instance IDs for the
			/// ejection relations of the specified device instance.
			/// </summary>
			CM_GETIDLIST_FILTER_EJECTRELATIONS = 0x00000004,

			/// <summary>
			/// If this flag is set, pszFilter must specify a device instance identifier. The function returns device instance IDs for the
			/// removal relations of the specified device instance.
			/// </summary>
			CM_GETIDLIST_FILTER_REMOVALRELATIONS = 0x00000008,

			/// <summary>
			/// If this flag is set, pszFilter must specify a device instance identifier. The function returns device instance IDs for the
			/// power relations of the specified device instance.
			/// </summary>
			CM_GETIDLIST_FILTER_POWERRELATIONS = 0x00000010,

			/// <summary>
			/// If this flag is set, pszFilter must specify a device instance identifier. The function returns device instance IDs for the
			/// bus relations of the specified device instance.
			/// </summary>
			CM_GETIDLIST_FILTER_BUSRELATIONS = 0x00000020,

			/// <summary>
			/// Used only with CM_GETIDLIST_FILTER_SERVICE. If set, and if the device tree does not contain a devnode for the specified
			/// service, this flag prevents the function from creating a devnode for the service.
			/// </summary>
			CM_GETIDLIST_DONOTGENERATE = 0x10000040,

			/// <summary>
			/// <para>If this flag is set, pszFilter must specify the device instance identifier of a composite device node (devnode).</para>
			/// <para>
			/// The function returns the device instance identifiers of the devnodes that represent the transport relations of the specified
			/// composite devnode.
			/// </para>
			/// <para>For more information about composite devnodes and transport relations, see the following <c>Remarks</c> section.</para>
			/// </summary>
			CM_GETIDLIST_FILTER_TRANSPORTRELATIONS = 0x00000080,

			/// <summary>
			/// If this flag is set, the returned list contains only device instances that are currently present on the system. This value
			/// can be combined with other ulFlags values, such as CM_GETIDLIST_FILTER_CLASS.
			/// </summary>
			CM_GETIDLIST_FILTER_PRESENT = 0x00000100,

			/// <summary>
			/// If this flag is set, pszFilter contains a string that specifies a device setup class GUID. The returned list contains device
			/// instances for which the property (referenced by the CM_DRP_CLASSGUID constant) matches the specified device setup class GUID.
			/// </summary>
			CM_GETIDLIST_FILTER_CLASS = 0x00000200,
		}

		/// <summary>Delete device node key flags. Indicates the scope and type of registry storage key to delete.</summary>
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Delete_DevNode_Key")]
		[Flags]
		public enum CM_REGISTRY
		{
			/// <summary>Delete the device’s hardware key. Do not combine with CM_REGISTRY_SOFTWARE.</summary>
			CM_REGISTRY_HARDWARE = 0x00000000,

			/// <summary>Delete the device’s software key. Do not combine with CM_REGISTRY_HARDWARE.</summary>
			CM_REGISTRY_SOFTWARE = 0x00000001,

			/// <summary>Delete the per-user key for the current user. Do not combine with CM_REGISTRY_CONFIG.</summary>
			CM_REGISTRY_USER = 0x00000100,

			/// <summary>Delete the key that stores hardware profile-specific configuration information. Do not combine with CM_REGISTRY_USER.</summary>
			CM_REGISTRY_CONFIG = 0x00000200,
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
			[CorrespondingType(typeof(MEM_RESOURCE))]
			ResType_Mem = 0x00000001,

			/// <summary>Physical I/O address resource</summary>
			[CorrespondingType(typeof(IO_RESOURCE))]
			ResType_IO = 0x00000002,

			/// <summary>DMA channels resource</summary>
			[CorrespondingType(typeof(DMA_RESOURCE))]
			ResType_DMA = 0x00000003,

			/// <summary>IRQ resource</summary>
			[CorrespondingType(typeof(IRQ_RESOURCE_32))]
			[CorrespondingType(typeof(IRQ_RESOURCE_64))]
			ResType_IRQ = 0x00000004,

			/// <summary>Used as spacer to sync subsequent ResTypes w/NT</summary>
			ResType_DoNotUse = 0x00000005,

			/// <summary>bus number resource</summary>
			[CorrespondingType(typeof(BUSNUMBER_RESOURCE))]
			ResType_BusNumber = 0x00000006,

			/// <summary>Memory resources &gt;= 4GB</summary>
			ResType_MemLarge = 0x00000007,

			/// <summary>Maximum known (arbitrated) ResType</summary>
			ResType_MAX = 0x00000007,

			/// <summary>Ignore this resource</summary>
			ResType_Ignored_Bit = 0x00008000,

			/// <summary>class-specific resource</summary>
			[CorrespondingType(typeof(CS_RESOURCE))]
			ResType_ClassSpecific = 0x0000FFFF,

			/// <summary>reserved for internal use</summary>
			ResType_Reserved = 0x00008000,

			/// <summary>device private data</summary>
			//[CorrespondingType(typeof(DEVPRIVATE_RESOURCE))]
			ResType_DevicePrivate = 0x00008001,

			/// <summary>PC Card configuration data</summary>
			[CorrespondingType(typeof(PCCARD_RESOURCE))]
			ResType_PcCardConfig = 0x00008002,

			/// <summary>MF Card configuration data</summary>
			[CorrespondingType(typeof(MFCARD_RESOURCE))]
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

		/// <summary>The <c>CM_Add_Res_Des</c> function adds a resource descriptor to a logical configuration.</summary>
		/// <typeparam name="T">The type of the data.</typeparam>
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
		/// <param name="data">Caller-supplied resource structure.</param>
		/// <param name="ResourceID">
		/// Caller-supplied resource type identifier, which identifies the type of structure supplied by ResourceData. If this value is 0,
		/// the method will attempt to determine the value using <typeparamref name="T"/>.
		/// </param>
		/// <returns>
		/// <para>Pointer to a location to receive a handle to the new resource descriptor.</para>
		/// <para>
		/// <c>Note</c> Starting with Windows 8, <c>CM_Add_Res_Des</c> throws CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario. To
		/// request information about the hardware resources on a local machine it is necessary implement an architecture-native version of
		/// the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
		/// </para>
		/// </remarks>
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Add_Res_Des")]
		public static SafeRES_DES CM_Add_Res_Des<T>(LOG_CONF lcLogConf, T data, RESOURCEID ResourceID = 0) where T : struct
		{
			if (ResourceID == 0 && !CorrespondingTypeAttribute.CanSet<T, RESOURCEID>(out ResourceID))
				throw new ArgumentException("Unable to determine RESOURCEID from type.", nameof(T));
			using var mem = new SafeAnysizeStruct<T>(data);
			CM_Add_Res_Des(out var hRD, lcLogConf, ResourceID, mem, mem.Size).ThrowIfFailed();
			return hRD;
		}

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

		/// <summary>The <c>CM_Delete_Class_Key</c> function removes the specified installed device class from the system.</summary>
		/// <param name="ClassGuid">Pointer to the GUID of the device class to remove.</param>
		/// <param name="ulFlags">
		/// <para>Delete class key flags:</para>
		/// <para>CM_DELETE_CLASS_ONLY</para>
		/// <para>Delete the class only if it does not contain any subkeys.</para>
		/// <para>CM_DELETE_CLASS_SUBKEYS</para>
		/// <para>Delete the class and all of its subkeys.</para>
		/// <para>CM_DELETE_CLASS_INTERFACE (available only in Windows Vista and later)</para>
		/// <para>Indicates that ClassGuid specifies a device interface class and not a device setup class.</para>
		/// </param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_delete_class_key CMAPI CONFIGRET CM_Delete_Class_Key(
		// LPGUID ClassGuid, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Delete_Class_Key")]
		public static extern CONFIGRET CM_Delete_Class_Key(in Guid ClassGuid, CM_DELETE_CLASS ulFlags);

		/// <summary>
		/// The <c>CM_Delete_Device_Interface_Key</c> function deletes the registry subkey that is used by applications and drivers to store
		/// interface-specific information.
		/// </summary>
		/// <param name="pszDeviceInterface">
		/// Pointer to a string that identifies the device interface instance of the registry subkey to delete.
		/// </param>
		/// <param name="ulFlags">Reserved. Must be set to zero.</param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_delete_device_interface_keyw CMAPI CONFIGRET
		// CM_Delete_Device_Interface_KeyW( LPCWSTR pszDeviceInterface, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Delete_Device_Interface_KeyW")]
		public static extern CONFIGRET CM_Delete_Device_Interface_Key(string pszDeviceInterface, uint ulFlags = 0);

		/// <summary>
		/// <para>
		/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Delete_Device_Interface_Key instead.]
		/// </para>
		/// <para>
		/// The <c>CM_Delete_Device_Interface_Key_ExW</c> function deletes the registry subkey that is used by applications and drivers to
		/// store interface-specific information.
		/// </para>
		/// </summary>
		/// <param name="pszDeviceInterface">
		/// Pointer to a string that identifies the device interface instance of the registry subkey to delete.
		/// </param>
		/// <param name="ulFlags">Reserved. Must be set to zero.</param>
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
		/// <para>Note</para>
		/// <para>
		/// The cfgmgr32.h header defines CM_Delete_Device_Interface_Key_Ex as an alias which automatically selects the ANSI or Unicode
		/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
		/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
		/// information, see Conventions for Function Prototypes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_delete_device_interface_key_exw CMAPI CONFIGRET
		// CM_Delete_Device_Interface_Key_ExW( LPCWSTR pszDeviceInterface, ULONG ulFlags, HMACHINE hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Delete_Device_Interface_Key_ExW")]
		public static extern CONFIGRET CM_Delete_Device_Interface_Key_Ex(string pszDeviceInterface, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

		/// <summary>
		/// The <c>CM_Delete_DevNode_Key</c> function deletes the specified user-accessible registry keys that are associated with a device.
		/// </summary>
		/// <param name="dnDevNode">Device instance handle that is bound to the local machine.</param>
		/// <param name="ulHardwareProfile">
		/// The hardware profile to delete if ulFlags includes CM_REGISTRY_CONFIG. If this value is zero, the key for the current hardware
		/// profile is deleted. If this value is 0xFFFFFFFF, the registry keys for all hardware profiles are deleted.
		/// </param>
		/// <param name="ulFlags">
		/// <para>
		/// Delete device node key flags. Indicates the scope and type of registry storage key to delete. Can be a combination of the
		/// following flags:
		/// </para>
		/// <para>CM_REGISTRY_HARDWARE</para>
		/// <para>Delete the device’s hardware key. Do not combine with CM_REGISTRY_SOFTWARE.</para>
		/// <para>CM_REGISTRY_SOFTWARE</para>
		/// <para>Delete the device’s software key. Do not combine with CM_REGISTRY_HARDWARE.</para>
		/// <para>CM_REGISTRY_USER</para>
		/// <para>Delete the per-user key for the current user. Do not combine with CM_REGISTRY_CONFIG.</para>
		/// <para>CM_REGISTRY_CONFIG</para>
		/// <para>Delete the key that stores hardware profile-specific configuration information. Do not combine with CM_REGISTRY_USER.</para>
		/// </param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_delete_devnode_key CMAPI CONFIGRET
		// CM_Delete_DevNode_Key( DEVNODE dnDevNode, ULONG ulHardwareProfile, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Delete_DevNode_Key")]
		public static extern CONFIGRET CM_Delete_DevNode_Key(uint dnDevNode, uint ulHardwareProfile, CM_REGISTRY ulFlags);

		/// <summary>The <c>CM_Disable_DevNode</c> function disables a device.</summary>
		/// <param name="dnDevInst">Device instance handle that is bound to the local machine.</param>
		/// <param name="ulFlags">
		/// <para>Disable flags:</para>
		/// <para>CM_DISABLE_UI_NOT_OK</para>
		/// <para>Do not display any interface to the user if the attempt to disable the device fails.</para>
		/// <para>CM_DISABLE_PERSIST</para>
		/// <para>Disables the device across reboots.</para>
		/// </param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// By default, <c>CM_Disable_DevNode</c> disables a device at one time, but after reboot the device is enabled again. Starting in
		/// Windows 10, you can specify the <c>CM_DISABLE_PERSIST</c> flag to disable the device across reboots.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_disable_devnode CMAPI CONFIGRET CM_Disable_DevNode(
		// DEVINST dnDevInst, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Disable_DevNode")]
		public static extern CONFIGRET CM_Disable_DevNode(uint dnDevInst, CM_DISABLE ulFlags = 0);

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

		/// <summary>The <c>CM_Enable_DevNode</c> function enables a device.</summary>
		/// <param name="dnDevInst">Device instance handle that is bound to the local machine.</param>
		/// <param name="ulFlags">Reserved. Must be set to zero.</param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_enable_devnode CMAPI CONFIGRET CM_Enable_DevNode(
		// DEVINST dnDevInst, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Enable_DevNode")]
		public static extern CONFIGRET CM_Enable_DevNode(uint dnDevInst, uint ulFlags = 0);

		/// <summary>
		/// The <c>CM_Enumerate_Classes</c> function, when called repeatedly, enumerates the local machine's installed device classes by
		/// supplying each class's GUID.
		/// </summary>
		/// <param name="ulClassIndex">
		/// Caller-supplied index into the machine's list of device classes. For more information, see the <c>Remarks</c> section.
		/// </param>
		/// <param name="ClassGuid">
		/// Caller-supplied address of a GUID structure (described in the Microsoft Windows SDK) to receive a device class's GUID.
		/// </param>
		/// <param name="ulFlags">
		/// <para>Beginning with Windows 8, callers can specify the following flags:</para>
		/// <para>CM_ENUMERATE_CLASSES_INSTALLER</para>
		/// <para>Enumerate device setup classes.</para>
		/// <para>CM_ENUMERATE_CLASSES_INTERFACE</para>
		/// <para>Enumerate device interface classes.</para>
		/// <para>Otherwise, should be set to zero.</para>
		/// </param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// <para>
		/// To enumerate the local machine's device classes, call <c>CM_Enumerate_Classes</c> repeatedly, starting with a ulClassIndex value
		/// of zero and incrementing the index value with each subsequent call until the function returns CR_NO_SUCH_VALUE. Some index
		/// values might represent list entries containing invalid class data, in which case the function returns CR_INVALID_DATA. This
		/// return value can be ignored.
		/// </para>
		/// <para>The class GUIDs obtained from this function can be used as input to the device installation functions.</para>
		/// <para>
		/// Beginning with Windows 8 and later operating systems, callers can use the <c>ulFlags</c> member to specify which device classes
		/// CM_Enumerate_Classes should return. Prior to Windows 8, CM_Enumerate_Classes returned only device setup classes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_enumerate_classes CMAPI CONFIGRET
		// CM_Enumerate_Classes( ULONG ulClassIndex, LPGUID ClassGuid, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Enumerate_Classes")]
		public static extern CONFIGRET CM_Enumerate_Classes(uint ulClassIndex, out Guid ClassGuid, CM_ENUMERATE_CLASSES ulFlags);

		/// <summary>
		/// The <c>CM_Enumerate_Classes</c> function, when called repeatedly, enumerates the local machine's installed device classes by
		/// supplying each class's GUID.
		/// </summary>
		/// <param name="ulFlags">
		/// <para>Beginning with Windows 8, callers can specify the following flags:</para>
		/// <para>CM_ENUMERATE_CLASSES_INSTALLER</para>
		/// <para>Enumerate device setup classes.</para>
		/// <para>CM_ENUMERATE_CLASSES_INTERFACE</para>
		/// <para>Enumerate device interface classes.</para>
		/// <para>Otherwise, should be set to zero.</para>
		/// </param>
		/// <returns>A sequence of device class GUIDs.</returns>
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Enumerate_Classes")]
		public static IEnumerable<Guid> CM_Enumerate_Classes(CM_ENUMERATE_CLASSES ulFlags)
		{
			var i = 0U;
			var cr = CM_Enumerate_Classes(i, out var guid, ulFlags);
			while (cr == CONFIGRET.CR_SUCCESS || cr == CONFIGRET.CR_INVALID_DATA)
			{
				if (cr == CONFIGRET.CR_SUCCESS)
					yield return guid;
				cr = CM_Enumerate_Classes(++i, out guid, ulFlags);
			}
			if (cr != CONFIGRET.CR_NO_SUCH_VALUE && cr != CONFIGRET.CR_SUCCESS && cr != CONFIGRET.CR_INVALID_DATA)
				throw cr.GetException();
		}

		/// <summary>
		/// <para>
		/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Enumerate_Classes instead.]
		/// </para>
		/// <para>
		/// The <c>CM_Enumerate_Classes_Ex</c> function, when called repeatedly, enumerates a local or a remote machine's installed device
		/// classes, by supplying each class's GUID.
		/// </para>
		/// </summary>
		/// <param name="ulClassIndex">
		/// Caller-supplied index into the machine's list of device classes. For more information, see the following <c>Remarks</c> section.
		/// </param>
		/// <param name="ClassGuid">
		/// Caller-supplied address of a GUID structure (described in the Microsoft Windows SDK) to receive a device class's GUID.
		/// </param>
		/// <param name="ulFlags">
		/// <para>Beginning with Windows 8, callers can specify the following flags:</para>
		/// <para>CM_ENUMERATE_CLASSES_INSTALLER</para>
		/// <para>Enumerate device setup classes.</para>
		/// <para>CM_ENUMERATE_CLASSES_INTERFACE</para>
		/// <para>Enumerate device interface classes.</para>
		/// <para>Otherwise, should be set to zero.</para>
		/// </param>
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
		/// <para>
		/// To enumerate the local or a remote machine's device classes, call <c>CM_Enumerate_Classes_Ex</c> repeatedly, starting with a
		/// ulClassIndex index value of zero and incrementing the index value with each subsequent call until the function returns
		/// CR_NO_SUCH_VALUE. Some index values might represent list entries containing invalid class data, in which case the function
		/// returns CR_INVALID_DATA. This return value can be ignored.
		/// </para>
		/// <para>The class GUIDs obtained from this function can be used as input to the device installation functions.</para>
		/// <para>
		/// Beginning with Windows 8 and later operating systems, callers can use the <c>ulFlags</c> member to specify which device classes
		/// CM_Enumerate_Classes_Ex should return. Prior to Windows 8, CM_Enumerate_Classes_Ex returned only device setup classes.
		/// </para>
		/// <para>
		/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
		/// you cannot access remote machines when running on these versions of Windows.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_enumerate_classes_ex CMAPI CONFIGRET
		// CM_Enumerate_Classes_Ex( ULONG ulClassIndex, LPGUID ClassGuid, ULONG ulFlags, HMACHINE hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Enumerate_Classes_Ex")]
		public static extern CONFIGRET CM_Enumerate_Classes_Ex(uint ulClassIndex, out Guid ClassGuid, CM_ENUMERATE_CLASSES ulFlags, [In, Optional] HMACHINE hMachine);

		/// <summary>
		/// The <c>CM_Enumerate_Enumerators</c> function enumerates the local machine's device enumerators by supplying each enumerator's name.
		/// </summary>
		/// <param name="ulEnumIndex">
		/// Caller-supplied index into the machine's list of device enumerators. For more information, see the following <c>Remarks</c> section.
		/// </param>
		/// <param name="Buffer">
		/// Address of a buffer to receive an enumerator name. This buffer should be MAX_DEVICE_ID_LEN-sized (or, set Buffer to zero and
		/// obtain the actual name length in the location referenced by puLength).
		/// </param>
		/// <param name="pulLength">
		/// Caller-supplied address of a location to hold the buffer size. The caller supplies the length of the buffer pointed to by
		/// Buffer. The function replaces this value with the actual size of the enumerator's name string. If the caller-supplied buffer
		/// length is too small, the function supplies the required buffer size and returns CR_BUFFER_SMALL.
		/// </param>
		/// <param name="ulFlags">Not used, must be zero.</param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// <para>
		/// To enumerate the local machine's device enumerators, call <c>CM_Enumerate_Enumerators</c> repeatedly, starting with a
		/// ulEnumIndex index value of zero. and incrementing the index value with each subsequent call until the function returns CR_NO_SUCH_VALUE.
		/// </para>
		/// <para>After enumerator names have been obtained, the names can be used as input to CM_Get_Device_ID_List.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_enumerate_enumeratorsw CMAPI CONFIGRET
		// CM_Enumerate_EnumeratorsW( ULONG ulEnumIndex, PWSTR Buffer, PULONG pulLength, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Enumerate_EnumeratorsW")]
		public static extern CONFIGRET CM_Enumerate_Enumerators(uint ulEnumIndex, StringBuilder Buffer, ref int pulLength, uint ulFlags = 0);

		/// <summary>
		/// The <c>CM_Enumerate_Enumerators</c> function enumerates the local machine's device enumerators by supplying each enumerator's name.
		/// </summary>
		/// <returns>A sequence of enumerator names.</returns>
		public static IEnumerable<string> CM_Enumerate_Enumerators()
		{
			var i = 0U;
			CONFIGRET cr;
			var sbCap = MAX_DEVICE_ID_LEN;
			StringBuilder sb = new(sbCap);
			while ((cr = CM_Enumerate_Enumerators(i, sb, ref sbCap)) == CONFIGRET.CR_SUCCESS)
			{
				yield return sb.ToString();
				i++;
				sbCap = sb.Capacity;
			}
			if (cr != CONFIGRET.CR_NO_SUCH_VALUE && cr != CONFIGRET.CR_SUCCESS)
				throw cr.GetException();
		}

		/// <summary>
		/// <para>
		/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Enumerate_Enumerators instead.]
		/// </para>
		/// <para>
		/// The <c>CM_Enumerate_Enumerators_Ex</c> function enumerates a local or a remote machine's device enumerators, by supplying each
		/// enumerator's name.
		/// </para>
		/// </summary>
		/// <param name="ulEnumIndex">
		/// Caller-supplied index into the machine's list of device enumerators. For more information, see the following <c>Remarks</c> section.
		/// </param>
		/// <param name="Buffer">
		/// Address of a buffer to receive an enumerator name. This buffer should be MAX_DEVICE_ID_LEN-sized (or, set Buffer to zero and
		/// obtain the actual name length in the location referenced by <c>puLength</c>).
		/// </param>
		/// <param name="pulLength">
		/// Caller-supplied address of a location to hold the buffer size. The caller supplies the length of the buffer pointed to by
		/// Buffer. The function replaces this value with the actual size of the enumerator's name string. If the caller-supplied buffer
		/// length is too small, the function supplies the required buffer size and returns CR_BUFFER_SMALL.
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
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// <para>
		/// To enumerate the local or a remote machine's device enumerators, call <c>CM_Enumerate_Enumerators_Ex</c> repeatedly, starting
		/// with a ulEnumIndex index value of zero, and incrementing the index value with each subsequent call until the function returns CR_NO_SUCH_VALUE.
		/// </para>
		/// <para>After enumerator names have been obtained, the names can be used as input to CM_Get_Device_ID_List.</para>
		/// <para>
		/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
		/// you cannot access remote machines when running on these versions of Windows.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_enumerate_enumerators_exw CMAPI CONFIGRET
		// CM_Enumerate_Enumerators_ExW( ULONG ulEnumIndex, PWSTR Buffer, PULONG pulLength, ULONG ulFlags, HMACHINE hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Enumerate_Enumerators_ExW")]
		public static extern CONFIGRET CM_Enumerate_Enumerators_Ex(uint ulEnumIndex, StringBuilder Buffer, ref int pulLength, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

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

		/// <summary>
		/// The <c>CM_Free_Log_Conf_Handle</c> function invalidates a logical configuration handle and frees its associated memory allocation.
		/// </summary>
		/// <param name="lcLogConf">
		/// <para>
		/// Caller-supplied logical configuration handle. This handle must have been previously obtained by calling one of the following functions:
		/// </para>
		/// <para>CM_Add_Empty_Log_Conf</para>
		/// <para>CM_Add_Empty_Log_Conf_Ex</para>
		/// <para>CM_Get_First_Log_Conf</para>
		/// <para>CM_Get_First_Log_Conf_Ex</para>
		/// <para>CM_Get_Next_Log_Conf</para>
		/// <para>CM_Get_Next_Log_Conf_Ex</para>
		/// </param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// Each time your code calls one of the functions listed under the description of lcLogConf, it must subsequently call <c>CM_Free_Log_Conf_Handle</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_free_log_conf_handle CMAPI CONFIGRET
		// CM_Free_Log_Conf_Handle( LOG_CONF lcLogConf );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Free_Log_Conf_Handle")]
		public static extern CONFIGRET CM_Free_Log_Conf_Handle(LOG_CONF lcLogConf);

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
		public static extern CONFIGRET CM_Free_Res_Des([In, Optional] IntPtr prdResDes, RES_DES rdResDes, uint ulFlags = 0);

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
		public static extern CONFIGRET CM_Free_Res_Des_Ex([In, Optional] IntPtr prdResDes, RES_DES rdResDes, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

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
		/// The <c>CM_Free_Resource_Conflict_Handle</c> function invalidates a handle to a resource conflict list, and frees the handle's
		/// associated memory allocation.
		/// </summary>
		/// <param name="clConflictList">
		/// Caller-supplied handle to be freed. This conflict list handle must have been previously obtained by calling CM_Query_Resource_Conflict_List.
		/// </param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// An application must call <c>CM_Free_Resource_Conflict_Handle</c> after it has finished using the handle that was obtained
		/// calling CM_Query_Resource_Conflict_List.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_free_resource_conflict_handle CMAPI CONFIGRET
		// CM_Free_Resource_Conflict_Handle( CONFLICT_LIST clConflictList );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Free_Resource_Conflict_Handle")]
		public static extern CONFIGRET CM_Free_Resource_Conflict_Handle(CONFLICT_LIST clConflictList);

		/// <summary>
		/// The <c>CM_Get_Child</c> function is used to retrieve a device instance handle to the first child node of a specified device node
		/// (devnode) in the local machine's device tree.
		/// </summary>
		/// <param name="pdnDevInst">
		/// Caller-supplied pointer to the device instance handle to the child node that this function retrieves. The retrieved handle is
		/// bound to the local machine. See the <c>Remarks</c> section.
		/// </param>
		/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
		/// <param name="ulFlags">Not used, must be zero.</param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// <para>
		/// To enumerate all children of a devnode in the local machine's device tree, first call <c>CM_Get_Child</c> to obtain a device
		/// instance handle to the first child node, then call CM_Get_Sibling to obtain handles for the rest of the children.
		/// </para>
		/// <para><c>Using Device Instance Handles</c></para>
		/// <para>Device instance handle that you use with PnP configuration manager functions are bound to machine handles, as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>All local device instance handles are bound to a NULL-valued local machine handle.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If you use a remote machine handle to obtain a device instance handle, the resulting remote device instance handle is bound to
		/// the remote machine handle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>A device instance handle can be used only with the machine handle to which it is bound.</term>
		/// </item>
		/// <item>
		/// <term>
		/// A device instance handle can be used with another device instance handle only if both device instance handles are bound to the
		/// same machine handle.
		/// </term>
		/// </item>
		/// </list>
		/// <para>To obtain a device instance handle that is bound to the local machine, do one of the following.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Use one of the following functions that retrieve only local device instance handles: CM_Locate_DevNode, <c>CM_Get_Child</c>,
		/// CM_Get_Parent, or CM_Get_Sibling.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Use one of the following functions, which retrieves local and remote device instance handles, to retrieve a local device
		/// instance handle: CM_Locate_DevNode_Ex, CM_Get_Child_Ex, CM_Get_Parent_Ex, or CM_Get_Sibling_Ex.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// You can also use the device installation functions to obtain local device instance handles from a device information set that is
		/// bound to the local machine. Do the following steps:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// Obtain a device information set that is bound to the local machine. (A device instance handle obtained from a device information
		/// set is bound to the machine handle to which the device information set is bound. You obtain the machine handle for a device
		/// information set from the <c>RemoteMachineHandle</c> member of its SP_DEVINFO_LIST_DETAIL_DATA structure. For a local device
		/// information set that is bound to the local machine, the value of <c>RemoteMachineHandle</c> is <c>NULL</c>. Call
		/// SetupDiGetDeviceInfoListDetail to obtain an SP_DEVINFO_LIST_DETAIL_DATA structure.)
		/// </term>
		/// </item>
		/// <item>
		/// <term>Obtain an SP_DEVINFO_DATA structure for a device instance in the device information set.</term>
		/// </item>
		/// <item>
		/// <term>Obtain the device instance handle for the device instance from the <c>DevInst</c> member of the SP_DEVINFO_DATA structure.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_child CMAPI CONFIGRET CM_Get_Child( PDEVINST
		// pdnDevInst, DEVINST dnDevInst, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Child")]
		public static extern CONFIGRET CM_Get_Child(out uint pdnDevInst, uint dnDevInst, uint ulFlags = 0);

		/// <summary>
		/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Child instead.]</para>
		/// <para>
		/// The <c>CM_Get_Child_Ex</c> function is used to retrieve a device instance handle to the first child node of a specified device
		/// node (devnode) in a local or a remote machine's device tree.
		/// </para>
		/// </summary>
		/// <param name="pdnDevInst">
		/// Caller-supplied pointer to the device instance handle to the child node that this function retrieves. The retrieved handle is
		/// bound to the machine handle supplied by hMachine. See the <c>Remarks</c> section.
		/// </param>
		/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the machine handle supplied by hMachine.</param>
		/// <param name="ulFlags">Not used, must be zero.</param>
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
		/// To enumerate all children of a devnode in a local or a remote machine's device tree, first call <c>CM_Get_Child_Ex</c> to obtain
		/// a handle to the first child node, then call CM_Get_Sibling_Ex to obtain handles for the rest of the children.
		/// </para>
		/// <para><c>Using Device Instance Handles</c></para>
		/// <para>Device instance handle that you use with PnP configuration manager functions are bound to machine handles, as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>All local device instance handles are bound to a NULL-valued local machine handle.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If you use a remote machine handle to obtain a device instance handle, the resulting remote device instance handle is bound to
		/// the remote machine handle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>A device instance handle can be used only with the machine handle to which it is bound.</term>
		/// </item>
		/// <item>
		/// <term>
		/// A device instance handle can be used with another device instance handle only if both device instance handles are bound to the
		/// same machine handle.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Use CM_Connect_Machine to obtain a remote machine handle for use with remote device instance handles.</para>
		/// <para>To obtain a local or a remote device instance handle, do one of the following.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Use one of the following functions to retrieve a device instance handle bound to the local machine: CM_Locate_DevNode,
		/// CM_Get_Child, CM_Get_Parent, or CM_Get_Sibling.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Use one of the following functions to retrieve a device instance handle bound to a local or a remote machine:
		/// CM_Locate_DevNode_Ex, <c>CM_Get_Child_Ex</c>, CM_Get_Parent_Ex, or CM_Get_Sibling_Ex.
		/// </term>
		/// </item>
		/// </list>
		/// <para>You can also use the device installation functions to obtain device instance handles. Do the following steps:</para>
		/// <list type="number">
		/// <item>
		/// <term>Obtain a device information set.</term>
		/// </item>
		/// <item>
		/// <term>Obtain an SP_DEVINFO_DATA structure for a device instance in the device information set.</term>
		/// </item>
		/// <item>
		/// <term>Obtain the device instance handle for the device instance from the <c>DevInst</c> member of the SP_DEVINFO_DATA structure.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Obtain the machine handle to which the device instance handle is bound. A device instance handle obtained from a device
		/// information set is bound to the machine handle to which the device information set is bound. You obtain the machine handle for a
		/// device information set from the <c>RemoteMachineHandle</c> member of its SP_DEVINFO_LIST_DETAIL_DATA structure. (Call
		/// SetupDiGetDeviceInfoListDetail to obtain an SP_DEVINFO_LIST_DETAIL_DATA structure.)
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
		/// you cannot access remote machines when running on these versions of Windows.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_child_ex CMAPI CONFIGRET CM_Get_Child_Ex( PDEVINST
		// pdnDevInst, DEVINST dnDevInst, ULONG ulFlags, HMACHINE hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Child_Ex")]
		public static extern CONFIGRET CM_Get_Child_Ex(out uint pdnDevInst, uint dnDevInst, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

		/// <summary>
		/// The <c>CM_Get_Class_Property</c> function retrieves a device property that is set for a device interface class or device setup class.
		/// </summary>
		/// <param name="ClassGUID">
		/// Pointer to the GUID that identifies the device interface class or device setup class for which to retrieve a device property
		/// that is set for the device class. For information about specifying the class type, see the ulFlags parameter.
		/// </param>
		/// <param name="PropertyKey">
		/// Pointer to a DEVPROPKEY structure that represents the device property key of the requested device class property.
		/// </param>
		/// <param name="PropertyType">
		/// Pointer to a DEVPROPTYPE-typed variable that receives the property-data-type identifier of the requested device class property,
		/// where the property-data-type identifier is the bitwise OR between a base-data-type identifier and, if the base data type is
		/// modified, a property-data-type modifier.
		/// </param>
		/// <param name="PropertyBuffer">
		/// Pointer to a buffer that receives the requested device class property. <c>CM_Get_Class_Property</c> retrieves the requested
		/// property value only if the buffer is large enough to hold all the property value data. The pointer can be NULL.
		/// </param>
		/// <param name="PropertyBufferSize">
		/// The size, in bytes, of the PropertyBuffer buffer. If the PropertyBuffer parameter is set to NULL, *PropertyBufferSize must be
		/// set to zero. As output, if the buffer is not large enough to hold all the property value data, <c>CM_Get_Class_Property</c>
		/// returns the size of the data, in bytes, in *PropertyBufferSize.
		/// </param>
		/// <param name="ulFlags">
		/// <para>Class property flags:</para>
		/// <para>CM_CLASS_PROPERTY_INSTALLER</para>
		/// <para>ClassGUID specifies a device setup class. Do not combine with CM_CLASS_PROPERTY_INTERFACE.</para>
		/// <para>CM_CLASS_PROPERTY_INTERFACE</para>
		/// <para>ClassGUID specifies a device interface class. Do not combine with CM_CLASS_PROPERTY_INSTALLER.</para>
		/// </param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks><c>CM_Get_Class_Property</c> is part of the Unified Device Property Model.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_class_propertyw CMAPI CONFIGRET
		// CM_Get_Class_PropertyW( LPCGUID ClassGUID, const DEVPROPKEY *PropertyKey, DEVPROPTYPE *PropertyType, PBYTE PropertyBuffer, PULONG
		// PropertyBufferSize, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Class_PropertyW")]
		public static extern CONFIGRET CM_Get_Class_Property(in Guid ClassGUID, in DEVPROPKEY PropertyKey, out DEVPROPTYPE PropertyType, [Out, Optional] IntPtr PropertyBuffer,
			ref uint PropertyBufferSize, CM_CLASS_PROPERTY ulFlags);

		/// <summary>
		/// <para>
		/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Class_Property instead.]
		/// </para>
		/// <para>
		/// The <c>CM_Get_Class_Property_ExW</c> function retrieves a device property that is set for a device interface class or device
		/// setup class.
		/// </para>
		/// </summary>
		/// <param name="ClassGUID">
		/// Pointer to the GUID that identifies the device interface class or device setup class for which to retrieve a device property
		/// that is set for the device class. For information about specifying the class type, see the ulFlags parameter.
		/// </param>
		/// <param name="PropertyKey">
		/// Pointer to a DEVPROPKEY structure that represents the device property key of the requested device class property.
		/// </param>
		/// <param name="PropertyType">
		/// Pointer to a DEVPROPTYPE-typed variable that receives the property-data-type identifier of the requested device class property,
		/// where the property-data-type identifier is the bitwise OR between a base-data-type identifier and, if the base data type is
		/// modified, a property-data-type modifier.
		/// </param>
		/// <param name="PropertyBuffer">
		/// Pointer to a buffer that receives the requested device class property. <c>CM_Get_Class_Property_ExW</c> retrieves the requested
		/// property value only if the buffer is large enough to hold all the property value data. The pointer can be NULL.
		/// </param>
		/// <param name="PropertyBufferSize">
		/// The size, in bytes, of the PropertyBuffer buffer. If the PropertyBuffer parameter is set to NULL, *PropertyBufferSize must be
		/// set to zero. As output, if the buffer is not large enough to hold all the property value data, <c>CM_Get_Class_Property_ExW</c>
		/// returns the size of the data, in bytes, in *PropertyBufferSize.
		/// </param>
		/// <param name="ulFlags">
		/// <para>Class property flags:</para>
		/// <para>CM_CLASS_PROPERTY_INSTALLER</para>
		/// <para>ClassGUID specifies a device setup class. Do not combine with CM_CLASS_PROPERTY_INTERFACE.</para>
		/// <para>CM_CLASS_PROPERTY_INTERFACE</para>
		/// <para>ClassGUID specifies a device interface class. Do not combine with CM_CLASS_PROPERTY_INSTALLER.</para>
		/// </param>
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
		/// <remarks><c>CM_Get_Class_Property_ExW</c> is part of the Unified Device Property Model.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_class_property_exw CMAPI CONFIGRET
		// CM_Get_Class_Property_ExW( LPCGUID ClassGUID, const DEVPROPKEY *PropertyKey, DEVPROPTYPE *PropertyType, PBYTE PropertyBuffer,
		// PULONG PropertyBufferSize, ULONG ulFlags, HMACHINE hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Class_Property_ExW")]
		public static extern CONFIGRET CM_Get_Class_Property_Ex(in Guid ClassGUID, in DEVPROPKEY PropertyKey, out DEVPROPTYPE PropertyType, [Out, Optional] IntPtr PropertyBuffer,
			ref uint PropertyBufferSize, CM_CLASS_PROPERTY ulFlags, [In, Optional] HMACHINE hMachine);

		/// <summary>
		/// The <c>CM_Get_Class_Property_Keys</c> function retrieves an array of the device property keys that represent the device
		/// properties that are set for a device interface class or device setup class.
		/// </summary>
		/// <param name="ClassGUID">
		/// Pointer to the GUID that identifies the device interface class or device setup class for which to retrieve the property keys
		/// for. For information about specifying the class type, see the ulFlags parameter.
		/// </param>
		/// <param name="PropertyKeyArray">
		/// Pointer to a buffer that receives an array of DEVPROPKEY-typed values, where each value is a device property key that represents
		/// a device property that is set for the device class. The pointer is optional and can be NULL.
		/// </param>
		/// <param name="PropertyKeyCount">
		/// The size, in DEVPROPKEY-typed units, of the PropertyKeyArray buffer. If PropertyKeyArray is set to NULL, *PropertyKeyCount must
		/// be set to zero. As output, if PropertyKeyArray is not large enough to hold all the property key data,
		/// <c>CM_Get_Class_Property_Keys</c> returns the count of the keys, in *PropertyKeyCount.
		/// </param>
		/// <param name="ulFlags">
		/// <para>Class property key flags:</para>
		/// <para>CM_CLASS_PROPERTY_INSTALLER</para>
		/// <para>ClassGUID specifies a device setup class. Do not combine with CM_CLASS_PROPERTY_INTERFACE.</para>
		/// <para>CM_CLASS_PROPERTY_INTERFACE</para>
		/// <para>ClassGUID specifies a device interface class. Do not combine with CM_CLASS_PROPERTY_INSTALLER.</para>
		/// </param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks><c>CM_Get_Class_Property_Keys</c> is part of the Unified Device Property Model.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_class_property_keys CMAPI CONFIGRET
		// CM_Get_Class_Property_Keys( LPCGUID ClassGUID, DEVPROPKEY *PropertyKeyArray, PULONG PropertyKeyCount, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Class_Property_Keys")]
		public static extern CONFIGRET CM_Get_Class_Property_Keys(in Guid ClassGUID, [In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEVPROPKEY[] PropertyKeyArray,
			ref int PropertyKeyCount, CM_CLASS_PROPERTY ulFlags);

		/// <summary>
		/// <para>
		/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Class_Property_Keys instead.]
		/// </para>
		/// <para>
		/// The <c>CM_Get_Class_Property_Keys_Ex</c> function retrieves an array of the device property keys that represent the device
		/// properties that are set for a device interface class or device setup class.
		/// </para>
		/// </summary>
		/// <param name="ClassGUID">
		/// Pointer to the GUID that identifies the device interface class or device setup class for which to retrieve the property keys
		/// for. For information about specifying the class type, see the ulFlags parameter.
		/// </param>
		/// <param name="PropertyKeyArray">
		/// Pointer to a buffer that receives an array of DEVPROPKEY-typed values, where each value is a device property key that represents
		/// a device property that is set for the device class. The pointer is optional and can be NULL.
		/// </param>
		/// <param name="PropertyKeyCount">
		/// The size, in DEVPROPKEY-typed units, of the PropertyKeyArray buffer. If PropertyKeyArray is set to NULL, *PropertyKeyCount must
		/// be set to zero. As output, if PropertyKeyArray is not large enough to hold all the property key data,
		/// <c>CM_Get_Class_Property_Keys_Ex</c> returns the count of the keys, in *PropertyKeyCount.
		/// </param>
		/// <param name="ulFlags">
		/// <para>Class property key flags:</para>
		/// <para>CM_CLASS_PROPERTY_INSTALLER</para>
		/// <para>ClassGUID specifies a device setup class. Do not combine with CM_CLASS_PROPERTY_INTERFACE.</para>
		/// <para>CM_CLASS_PROPERTY_INTERFACE</para>
		/// <para>ClassGUID specifies a device interface class. Do not combine with CM_CLASS_PROPERTY_INSTALLER.</para>
		/// </param>
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
		/// <remarks><c>CM_Get_Class_Property_Keys_Ex</c> is part of the Unified Device Property Model.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_class_property_keys_ex CMAPI CONFIGRET
		// CM_Get_Class_Property_Keys_Ex( LPCGUID ClassGUID, DEVPROPKEY *PropertyKeyArray, PULONG PropertyKeyCount, ULONG ulFlags, HMACHINE
		// hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Class_Property_Keys_Ex")]
		public static extern CONFIGRET CM_Get_Class_Property_Keys_Ex(in Guid ClassGUID, [In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEVPROPKEY[] PropertyKeyArray,
			ref uint PropertyKeyCount, CM_CLASS_PROPERTY ulFlags, [In, Optional] HMACHINE hMachine);

		/// <summary>The <c>CM_Get_Class_Registry_Property</c> function retrieves a device setup class property.</summary>
		/// <param name="ClassGuid">A pointer to the GUID that represents the device setup class for which to retrieve a property.</param>
		/// <param name="ulProperty">
		/// <para>
		/// A value of type ULONG that identifies the property to be retrieved. This value must be one of the following CM_CRP_Xxx values
		/// that are defined in Cfgmgr32.h:
		/// </para>
		/// <para>CM_CRP_UPPERFILTERS</para>
		/// <para>
		/// Represents a REG_MULTI_SZ-type list of strings, where each string contains the name of an upper-level filter driver that is
		/// registered for the class.
		/// </para>
		/// <para>CM_CRP_LOWERFILTERS</para>
		/// <para>
		/// Represents a REG_MULTI_SZ-typed list of strings, where each string contains the name of a lower-level filter drivers that is
		/// registered for the class.
		/// </para>
		/// <para>CM_CRP_SECURITY</para>
		/// <para>Represents a value of type REG_BINARY that contains a variable-length, self-relative, SECURITY_DESCRIPTOR structure.</para>
		/// <para>CM_CRP_SECURITY_SDS</para>
		/// <para>
		/// Represents a string of type REG_SZ that contains a security descriptor in the Security Descriptor Definition Language (SDDL) format.
		/// </para>
		/// <para>CM_CRP_DEVTYPE</para>
		/// <para>
		/// Represents a value of type REG_DWORD that indicates the device type for the class. For more information, see Specifying Device Types.
		/// </para>
		/// <para>CM_CRP_EXCLUSIVE</para>
		/// <para>
		/// Represents a value of type REG_DWORD that indicates whether users can obtain exclusive access to devices for this class. The
		/// returned value is 1 if exclusive access is allowed, or zero otherwise.
		/// </para>
		/// <para>CM_CRP_CHARACTERISTICS</para>
		/// <para>
		/// Represents a value of type DWORD that indicates the device characteristics for the class. For a list of characteristics flags,
		/// see the DeviceCharacteristics parameter of the IoCreateDevice routine.
		/// </para>
		/// </param>
		/// <param name="pulRegDataType">
		/// A pointer to a variable of type ULONG that receives the REG_Xxx constant that represents the data type of the requested
		/// property. The REG_Xxx constants are defined in Winnt.h and are described in the <c>Type</c> member of the
		/// KEY_VALUE_BASIC_INFORMATION structure. This parameter is optional and can be set to <c>NULL</c>.
		/// </param>
		/// <param name="Buffer">
		/// A pointer to a buffer that receives the requested property data. For more information about this parameter and the buffer-size
		/// parameter pulLength, see the following <c>Remarks</c> section.
		/// </param>
		/// <param name="pulLength">
		/// A pointer to variable of type ULONG whose value, on input, is the size, in bytes, of the buffer that is supplied by Buffer. On
		/// return, <c>CM_Get_Class_Registry_Property</c> sets this variable to the size, in bytes, of the requested property.
		/// </param>
		/// <param name="ulFlags">Reserved for internal use only. Must be set to zero.</param>
		/// <param name="hMachine">
		/// A handle to a remote machine from which to retrieve the specified device class property. This parameter is optional, and, if it
		/// is set to <c>NULL</c>, the property is retrieved from the local machine.
		/// </param>
		/// <returns>
		/// If the operation succeeds, <c>CM_Get_Class_Registry_Property</c> returns CR_SUCCESS. Otherwise, the function returns one of the
		/// other CR_Xxx status codes that are defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// To determine the size, in bytes, of a property before attempting to retrieve the property, first call
		/// <c>CM_Get_Class_Registry_Property</c>, supplying a <c>NULL</c> Buffer pointer and a <c></c> pulLength value of zero. In response
		/// to such a call, the function does not retrieve the property, but sets <c></c> pulLength to the size of the requested property
		/// and returns CR_BUFFER_SMALL. After obtaining the property size, call <c>CM_Get_Class_Registry_Property</c> again, supplying a
		/// Buffer pointer to the buffer to receive the property data and supplying the property size in <c>*</c> pulLength.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_class_registry_propertyw CMAPI CONFIGRET
		// CM_Get_Class_Registry_PropertyW( LPGUID ClassGuid, ULONG ulProperty, PULONG pulRegDataType, PVOID Buffer, PULONG pulLength, ULONG
		// ulFlags, HMACHINE hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Class_Registry_PropertyW")]
		public static extern CONFIGRET CM_Get_Class_Registry_Property(in Guid ClassGuid, CM_CRP ulProperty, out REG_VALUE_TYPE pulRegDataType, [Out, Optional] IntPtr Buffer,
			ref uint pulLength, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

		/// <summary>
		/// The <c>CM_Get_Depth</c> function is used to obtain the depth of a specified device node (devnode) within the local machine's
		/// device tree.
		/// </summary>
		/// <param name="pulDepth">
		/// Caller-supplied address of a location to receive a depth value, where zero represents the device tree's root node, one
		/// represents the root node's children, and so on.
		/// </param>
		/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
		/// <param name="ulFlags">Not used, must be zero.</param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_depth CMAPI CONFIGRET CM_Get_Depth( PULONG
		// pulDepth, DEVINST dnDevInst, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Depth")]
		public static extern CONFIGRET CM_Get_Depth(out uint pulDepth, uint dnDevInst, uint ulFlags = 0);

		/// <summary>
		/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Depth instead.]</para>
		/// <para>
		/// The <c>CM_Get_Depth_Ex</c> function is used to obtain the depth of a specified device node (devnode) within a local or a remote
		/// machine's device tree.
		/// </para>
		/// </summary>
		/// <param name="pulDepth">
		/// Caller-supplied address of a location to receive a depth value, where zero represents the device tree's root node, one
		/// represents the root node's children, and so on.
		/// </param>
		/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the machine handle supplied by hMachine.</param>
		/// <param name="ulFlags">Not used, must be zero.</param>
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
		/// <para>For information about using device instance handles that are bound to a local or a remote machine, see CM_Get_Child_Ex.</para>
		/// <para>
		/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
		/// you cannot access remote machines when running on these versions of Windows.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_depth_ex CMAPI CONFIGRET CM_Get_Depth_Ex( PULONG
		// pulDepth, DEVINST dnDevInst, ULONG ulFlags, HMACHINE hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Depth_Ex")]
		public static extern CONFIGRET CM_Get_Depth_Ex(out uint pulDepth, uint dnDevInst, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

		/// <summary>
		/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Device_ID instead.]</para>
		/// <para>
		/// The <c>CM_Get_Device_ID_Ex</c> function retrieves the device instance ID for a specified device instance on a local or a remote machine.
		/// </para>
		/// </summary>
		/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the machine handle supplied by hMachine.</param>
		/// <param name="Buffer">
		/// Address of a buffer to receive a device instance ID string. The required buffer size can be obtained by calling
		/// CM_Get_Device_ID_Size_Ex, then incrementing the received value to allow room for the string's terminating <c>NULL</c>.
		/// </param>
		/// <param name="BufferLen">Caller-supplied length, in characters, of the buffer specified by Buffer.</param>
		/// <param name="ulFlags">Not used, must be zero.</param>
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
		/// The function appends a NULL terminator to the supplied device instance ID string, unless the buffer is too small to hold the
		/// string. In this case, the function supplies as much of the identifier string as will fit into the buffer, and then returns CR_BUFFER_SMALL.
		/// </para>
		/// <para>For information about device instance IDs, see Device Identification Strings.</para>
		/// <para>For information about using device instance handles that are bound to a local or a remote machine, see CM_Get_Child_Ex.</para>
		/// <para>
		/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
		/// you cannot access remote machines when running on these versions of Windows.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_id_exw CMAPI CONFIGRET
		// CM_Get_Device_ID_ExW( DEVINST dnDevInst, PWSTR Buffer, ULONG BufferLen, ULONG ulFlags, HMACHINE hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_ID_ExW")]
		public static extern CONFIGRET CM_Get_Device_ID_Ex(uint dnDevInst, StringBuilder Buffer, uint BufferLen, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

		/// <summary>
		/// The <c>CM_Get_Device_ID_List</c> function retrieves a list of device instance IDs for the local computer's device instances.
		/// </summary>
		/// <param name="pszFilter">
		/// Caller-supplied pointer to a character string that is either set to a subset of the computer's device instance identifiers
		/// (IDs), or to <c>NULL</c>. See the following description of ulFlags.
		/// </param>
		/// <param name="Buffer">
		/// Address of a buffer to receive a set of NULL-terminated device instance identifier strings. The end of the set is terminated by
		/// an extra <c>NULL</c>. The required buffer size should be obtained by calling CM_Get_Device_ID_List_Size.
		/// </param>
		/// <param name="BufferLen">Caller-supplied length, in characters, of the buffer specified by Buffer.</param>
		/// <param name="ulFlags">
		/// <para>One of the following caller-supplied bit flags that specifies search filters:</para>
		/// <para>CM_GETIDLIST_FILTER_BUSRELATIONS</para>
		/// <para>
		/// If this flag is set, pszFilter must specify a device instance identifier. The function returns device instance IDs for the bus
		/// relations of the specified device instance.
		/// </para>
		/// <para>CM_GETIDLIST_FILTER_CLASS (Windows 7 and later versions of Windows)</para>
		/// <para>
		/// If this flag is set, pszFilter contains a string that specifies a device setup class GUID. The returned list contains device
		/// instances for which the property (referenced by the CM_DRP_CLASSGUID constant) matches the specified device setup class GUID.
		/// </para>
		/// <para>The CM_DRP_CLASSGUID constant is defined in Cfgmgr32.h.</para>
		/// <para>CM_GETIDLIST_FILTER_PRESENT (Windows 7 and later versions of Windows)</para>
		/// <para>
		/// If this flag is set, the returned list contains only device instances that are currently present on the system. This value can
		/// be combined with other ulFlags values, such as CM_GETIDLIST_FILTER_CLASS.
		/// </para>
		/// <para>CM_GETIDLIST_FILTER_TRANSPORTRELATIONS (Windows 7 and later versions of Windows)</para>
		/// <para>If this flag is set, pszFilter must specify the device instance identifier of a composite device node (devnode).</para>
		/// <para>
		/// The function returns the device instance identifiers of the devnodes that represent the transport relations of the specified
		/// composite devnode.
		/// </para>
		/// <para>For more information about composite devnodes and transport relations, see the following <c>Remarks</c> section.</para>
		/// <para>CM_GETIDLIST_DONOTGENERATE</para>
		/// <para>
		/// Used only with CM_GETIDLIST_FILTER_SERVICE. If set, and if the device tree does not contain a devnode for the specified service,
		/// this flag prevents the function from creating a devnode for the service.
		/// </para>
		/// <para>CM_GETIDLIST_FILTER_EJECTRELATIONS</para>
		/// <para>
		/// If this flag is set, pszFilter must specify a device instance identifier. The function returns device instance IDs for the
		/// ejection relations of the specified device instance.
		/// </para>
		/// <para>CM_GETIDLIST_FILTER_ENUMERATOR</para>
		/// <para>
		/// If this flag is set, pszFilter must specify the name of a device enumerator, optionally followed by a device ID. The string
		/// format is EnumeratorName\&lt;DeviceID&gt;, such as <c>ROOT</c> or <c>ROOT\*PNP0500</c>.
		/// </para>
		/// <para>
		/// If pszFilter supplies only an enumerator name, the function returns device instance IDs for the instances of each device
		/// associated with the enumerator. Enumerator names can be obtained by calling CM_Enumerate_Enumerators.
		/// </para>
		/// <para>
		/// If pszFilter supplies both an enumerator and a device ID, the function returns device instance IDs only for the instances of the
		/// specified device that is associated with the enumerator.
		/// </para>
		/// <para>CM_GETIDLIST_FILTER_NONE</para>
		/// <para>If this flag is set, pszFilter is ignored, and a list of all devices on the system is returned.</para>
		/// <para>CM_GETIDLIST_FILTER_POWERRELATIONS</para>
		/// <para>
		/// If this flag is set, pszFilter must specify a device instance identifier. The function returns device instance IDs for the power
		/// relations of the specified device instance.
		/// </para>
		/// <para>CM_GETIDLIST_FILTER_REMOVALRELATIONS</para>
		/// <para>
		/// If this flag is set, pszFilter must specify a device instance identifier. The function returns device instance IDs for the
		/// removal relations of the specified device instance.
		/// </para>
		/// <para>CM_GETIDLIST_FILTER_SERVICE</para>
		/// <para>
		/// If this flag is set, pszFilter must specify the name of a Microsoft Windows service (typically a driver). The function returns
		/// device instance IDs for the device instances controlled by the specified service.
		/// </para>
		/// <para>
		/// Note that if the device tree does not contain a devnode for the specified service, this function creates one by default. To
		/// inhibit this behavior, also set CM_GETIDLIST_DONOTGENERATE.
		/// </para>
		/// <para>If no search filter flag is specified, the function returns all device instance IDs for all device instances.</para>
		/// </param>
		/// <returns>
		/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Starting with Windows 7, a device that supports multiple transport paths for packet-based data is referred to as a composite
		/// device and is represented by a composite devnode. A composite devnode logically represents the composite device to the user and
		/// applications as a single device, even though the composite devnode can have multiple paths to the physical device.
		/// </para>
		/// <para>
		/// Each active transport path to the physical device is represented by a transport devnode and is referred to as a transport
		/// relation for the composite device.
		/// </para>
		/// <para>
		/// The composite devnode (but not the related transport devnodes) exposes device interfaces to applications and the system. When an
		/// application uses these public device interfaces, the composite device routes the packet-based data to one or more of these
		/// transport devnodes, which then transport the data to the physical device.
		/// </para>
		/// <para>
		/// For example, if a physical cell phone is simultaneously connected to the computer on the USB and the Bluetooth buses, each bus
		/// enumerates a child transport devnode on that bus to represent the device's physical connection.
		/// </para>
		/// <para>
		/// In this case, if you set the CM_GETIDLIST_FILTER_TRANSPORTRELATIONS flags in ulFlags and specify the device instance ID of the
		/// cell phone's composite devnode in pszFilter, the function returns the device instance IDs for the two transport devnodes in the
		/// Buffer parameter.
		/// </para>
		/// <para>For more information about device instance IDs, see Device Identification Strings.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The cfgmgr32.h header defines CM_Get_Device_ID_List as an alias which automatically selects the ANSI or Unicode version of this
		/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
		/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
		/// for Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_id_lista CMAPI CONFIGRET
		// CM_Get_Device_ID_ListA( PCSTR pszFilter, PZZSTR Buffer, ULONG BufferLen, ULONG ulFlags );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_ID_ListA")]
		public static extern CONFIGRET CM_Get_Device_ID_List([In, Optional, MarshalAs(UnmanagedType.LPTStr)] string pszFilter, [Out] IntPtr Buffer,
			uint BufferLen, CM_GETIDLIST ulFlags = 0);

		/// <summary>
		/// The <c>CM_Get_Device_ID_List</c> function retrieves a list of device instance IDs for the local computer's device instances.
		/// </summary>
		/// <param name="ulFlags">Bit flags that specifies search filters</param>
		/// <param name="pszFilter">
		/// Caller-supplied string that is either set to a subset of the computer's device instance identifiers
		/// (IDs), or to <see langword="null"/>. See the description of ulFlags.
		/// </param>
		/// <returns>A sequence of device instance identifier strings.</returns>
		/// <remarks>
		/// <para>
		/// Starting with Windows 7, a device that supports multiple transport paths for packet-based data is referred to as a composite
		/// device and is represented by a composite devnode. A composite devnode logically represents the composite device to the user and
		/// applications as a single device, even though the composite devnode can have multiple paths to the physical device.
		/// </para>
		/// <para>
		/// Each active transport path to the physical device is represented by a transport devnode and is referred to as a transport
		/// relation for the composite device.
		/// </para>
		/// <para>
		/// The composite devnode (but not the related transport devnodes) exposes device interfaces to applications and the system. When an
		/// application uses these public device interfaces, the composite device routes the packet-based data to one or more of these
		/// transport devnodes, which then transport the data to the physical device.
		/// </para>
		/// <para>
		/// For example, if a physical cell phone is simultaneously connected to the computer on the USB and the Bluetooth buses, each bus
		/// enumerates a child transport devnode on that bus to represent the device's physical connection.
		/// </para>
		/// <para>
		/// In this case, if you set the CM_GETIDLIST_FILTER_TRANSPORTRELATIONS flags in ulFlags and specify the device instance ID of the
		/// cell phone's composite devnode in pszFilter, the function returns the device instance IDs for the two transport devnodes in the
		/// Buffer parameter.
		/// </para>
		/// <para>For more information about device instance IDs, see Device Identification Strings.</para>
		/// </remarks>
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_ID_ListA")]
		public static IEnumerable<string> CM_Get_Device_ID_List(CM_GETIDLIST ulFlags = 0, string pszFilter = null)
		{
			while (true)
			{
				CM_Get_Device_ID_List_Size(out var len, pszFilter, ulFlags).ThrowIfFailed();
				using var mem = new SafeCoTaskMemHandle(len * StringHelper.GetCharSize());
				var ret = CM_Get_Device_ID_List(pszFilter, mem, len, ulFlags);
				if (ret == CONFIGRET.CR_SUCCESS)
					return mem.ToStringEnum().ToArray();
				else if (ret != CONFIGRET.CR_BUFFER_SMALL)
					ret.ThrowIfFailed();
			}
		}

		/// <summary>
		/// <para>
		/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Device_ID_List instead.]
		/// </para>
		/// <para>
		/// The <c>CM_Get_Device_ID_List_Ex</c> function retrieves a list of device instance IDs for the device instances on a local or a
		/// remote machine.
		/// </para>
		/// </summary>
		/// <param name="pszFilter">
		/// Caller-supplied pointer to a character string specifying a subset of the machine's device instance identifiers, or <c>NULL</c>.
		/// See the following description of ulFlags.
		/// </param>
		/// <param name="Buffer">
		/// Address of a buffer to receive a set of NULL-terminated device instance identifier strings. The end of the set is terminated by
		/// an extra <c>NULL</c>. The required buffer size should be obtained by calling CM_Get_Device_ID_List_Size_Ex.
		/// </param>
		/// <param name="BufferLen">Caller-supplied length, in characters, of the buffer specified by Buffer.</param>
		/// <param name="ulFlags">
		/// One of the optional, caller-supplied bit flags that specify search filters. If no flags are specified, the function supplies all
		/// instance identifiers for all device instances. For a list of bit flags, see the ulFlags description for CM_Get_Device_ID_List.
		/// </param>
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
		/// <para>For information about device instance IDs, see Device Identification Strings.</para>
		/// <para>
		/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
		/// you cannot access remote machines when running on these versions of Windows.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_id_list_exw CMAPI CONFIGRET
		// CM_Get_Device_ID_List_ExW( PCWSTR pszFilter, PZZWSTR Buffer, ULONG BufferLen, ULONG ulFlags, HMACHINE hMachine );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_ID_List_ExW")]
		public static extern CONFIGRET CM_Get_Device_ID_List_Ex([In, Optional, MarshalAs(UnmanagedType.LPTStr)] string pszFilter, [Out] IntPtr Buffer,
			uint BufferLen, [In, Optional] CM_GETIDLIST ulFlags, [In, Optional] HMACHINE hMachine);

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

		/// <summary>Provides a handle to a resource conflict list.</summary>
		[PInvokeData("cfgmgr32.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CONFLICT_LIST : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="CONFLICT_LIST"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public CONFLICT_LIST(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="CONFLICT_LIST"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static CONFLICT_LIST NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="CONFLICT_LIST"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(CONFLICT_LIST h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="CONFLICT_LIST"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator CONFLICT_LIST(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(CONFLICT_LIST h1, CONFLICT_LIST h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(CONFLICT_LIST h1, CONFLICT_LIST h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is CONFLICT_LIST h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a notification context.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HCMNOTIFICATION : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HCMNOTIFICATION"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HCMNOTIFICATION(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HCMNOTIFICATION"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HCMNOTIFICATION NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HCMNOTIFICATION"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HCMNOTIFICATION h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCMNOTIFICATION"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HCMNOTIFICATION(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HCMNOTIFICATION h1, HCMNOTIFICATION h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HCMNOTIFICATION h1, HCMNOTIFICATION h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HCMNOTIFICATION h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a device instance.</summary>
		[PInvokeData("cfgmgr32.h")]
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
		[PInvokeData("cfgmgr32.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct LOG_CONF : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="LOG_CONF"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public LOG_CONF(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="LOG_CONF"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static LOG_CONF NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="LOG_CONF"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(LOG_CONF h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="LOG_CONF"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator LOG_CONF(IntPtr h) => new(h);

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
		[PInvokeData("cfgmgr32.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RES_DES : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="RES_DES"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public RES_DES(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="RES_DES"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static RES_DES NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="RES_DES"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(RES_DES h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="RES_DES"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator RES_DES(IntPtr h) => new(h);

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

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="CONFLICT_LIST"/> that is disposed using <see cref="CM_Free_Resource_Conflict_Handle(CONFLICT_LIST)"/>.</summary>
		public class SafeCONFLICT_LIST : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeCONFLICT_LIST"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeCONFLICT_LIST(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeCONFLICT_LIST"/> class.</summary>
			private SafeCONFLICT_LIST() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeCONFLICT_LIST"/> to <see cref="CONFLICT_LIST"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator CONFLICT_LIST(SafeCONFLICT_LIST h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => CM_Free_Resource_Conflict_Handle(handle) == 0;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HCMNOTIFICATION"/> that is disposed using <see cref="CM_Unregister_Notification"/>.</summary>
		public class SafeHCMNOTIFICATION : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHCMNOTIFICATION"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHCMNOTIFICATION(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHCMNOTIFICATION"/> class.</summary>
			private SafeHCMNOTIFICATION() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHCMNOTIFICATION"/> to <see cref="HCMNOTIFICATION"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HCMNOTIFICATION(SafeHCMNOTIFICATION h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => CM_Unregister_Notification(handle) == 0;
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

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="LOG_CONF"/> that is disposed using <see cref="CM_Free_Log_Conf_Handle"/>.</summary>
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

			/// <summary>Performs an implicit conversion from <see cref="SafeLOG_CONF"/> to <see cref="LOG_CONF"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator LOG_CONF(SafeLOG_CONF h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => CM_Free_Log_Conf_Handle(handle) == 0;
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
	}
}