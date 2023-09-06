using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.SetupAPI;

namespace Vanara.PInvoke;

/// <summary>Items from the CfgMgr32.dll</summary>
public static partial class CfgMgr32
{
	/// <summary>CONFLICT_DETAILS.CD_ulFlags values.</summary>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32._CONFLICT_DETAILS_A")]
	[Flags]
	public enum CM_CDFLAGS : uint
	{
		/// <summary>
		/// If set, the string contained in the CD_szDescription member represents a driver name instead of a device name, and
		/// CD_dnDevInst is -1.
		/// </summary>
		CM_CDFLAGS_DRIVER = 0x00000001,

		/// <summary>If set, the conflicting resources are owned by the root device (that is, the HAL), and CD_dnDevInst is -1.</summary>
		CM_CDFLAGS_ROOT_OWNED = 0x00000002,

		/// <summary>If set, the owner of the conflicting resources cannot be determined, and CD_dnDevInst is -1.</summary>
		CM_CDFLAGS_RESERVED = 0x00000004,
	}

	/// <summary>CONFLICT_DETAILS.CD_ulMask values.</summary>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32._CONFLICT_DETAILS_A")]
	[Flags]
	public enum CM_CDMASK : uint
	{
		/// <summary>If set, CM_Get_Resource_Conflict_Details supplies a value for the CD_dnDevInst member.</summary>
		CM_CDMASK_DEVINST = 0x00000001,

		/// <summary>Not used.</summary>
		CM_CDMASK_RESDES = 0x00000002,

		/// <summary>If set, CM_Get_Resource_Conflict_Details supplies a value for the CD_ulFlags member.</summary>
		CM_CDMASK_FLAGS = 0x00000004,

		/// <summary>If set, CM_Get_Resource_Conflict_Details supplies a value for the CD_szDescription member.</summary>
		CM_CDMASK_DESCRIPTION = 0x00000008,
	}

	/// <summary>Identifies the device property to be obtained from the registry.</summary>
	[PInvokeData("cfgmgr32.h")]
	public enum CM_DRP
	{
		/// <summary>DeviceDesc REG_SZ property (RW)</summary>
		CM_DRP_DEVICEDESC = 0x00000001,

		/// <summary>HardwareID REG_MULTI_SZ property (RW)</summary>
		CM_DRP_HARDWAREID = 0x00000002,

		/// <summary>CompatibleIDs REG_MULTI_SZ property (RW)</summary>
		CM_DRP_COMPATIBLEIDS = 0x00000003,

		/// <summary>unused</summary>
		CM_DRP_UNUSED0 = 0x00000004,

		/// <summary>Service REG_SZ property (RW)</summary>
		CM_DRP_SERVICE = 0x00000005,

		/// <summary>unused</summary>
		CM_DRP_UNUSED1 = 0x00000006,

		/// <summary>unused</summary>
		CM_DRP_UNUSED2 = 0x00000007,

		/// <summary>Class REG_SZ property (RW)</summary>
		CM_DRP_CLASS = 0x00000008,

		/// <summary>ClassGUID REG_SZ property (RW)</summary>
		CM_DRP_CLASSGUID = 0x00000009,

		/// <summary>Driver REG_SZ property (RW)</summary>
		CM_DRP_DRIVER = 0x0000000A,

		/// <summary>ConfigFlags REG_DWORD property (RW)</summary>
		CM_DRP_CONFIGFLAGS = 0x0000000B,

		/// <summary>Mfg REG_SZ property (RW)</summary>
		CM_DRP_MFG = 0x0000000C,

		/// <summary>FriendlyName REG_SZ property (RW)</summary>
		CM_DRP_FRIENDLYNAME = 0x0000000D,

		/// <summary>LocationInformation REG_SZ property (RW)</summary>
		CM_DRP_LOCATION_INFORMATION = 0x0000000E,

		/// <summary>PhysicalDeviceObjectName REG_SZ property (R)</summary>
		CM_DRP_PHYSICAL_DEVICE_OBJECT_NAME = 0x0000000F,

		/// <summary>Capabilities REG_DWORD property (R)</summary>
		CM_DRP_CAPABILITIES = 0x00000010,

		/// <summary>UiNumber REG_DWORD property (R)</summary>
		CM_DRP_UI_NUMBER = 0x00000011,

		/// <summary>UpperFilters REG_MULTI_SZ property (RW)</summary>
		CM_DRP_UPPERFILTERS = 0x00000012,

		/// <summary>LowerFilters REG_MULTI_SZ property (RW)</summary>
		CM_DRP_LOWERFILTERS = 0x00000013,

		/// <summary>Bus Type Guid, GUID, (R)</summary>
		CM_DRP_BUSTYPEGUID = 0x00000014,

		/// <summary>Legacy bus type, INTERFACE_TYPE, (R)</summary>
		CM_DRP_LEGACYBUSTYPE = 0x00000015,

		/// <summary>Bus Number, DWORD, (R)</summary>
		CM_DRP_BUSNUMBER = 0x00000016,

		/// <summary>Enumerator Name REG_SZ property (R)</summary>
		CM_DRP_ENUMERATOR_NAME = 0x00000017,

		/// <summary>Security - Device override (RW)</summary>
		CM_DRP_SECURITY = 0x00000018,

		/// <summary>Security - Device override (RW)</summary>
		CM_DRP_SECURITY_SDS = 0x00000019,

		/// <summary>Device Type - Device override (RW)</summary>
		CM_DRP_DEVTYPE = 0x0000001A,

		/// <summary>Exclusivity - Device override (RW)</summary>
		CM_DRP_EXCLUSIVE = 0x0000001B,

		/// <summary>Characteristics - Device Override (RW)</summary>
		CM_DRP_CHARACTERISTICS = 0x0000001C,

		/// <summary>Device Address (R)</summary>
		CM_DRP_ADDRESS = 0x0000001D,

		/// <summary>UINumberDescFormat REG_SZ property (RW)</summary>
		CM_DRP_UI_NUMBER_DESC_FORMAT = 0x0000001E,

		/// <summary>CM_POWER_DATA REG_BINARY property (R)</summary>
		CM_DRP_DEVICE_POWER_DATA = 0x0000001F,

		/// <summary>CM_DEVICE_REMOVAL_POLICY REG_DWORD (R)</summary>
		CM_DRP_REMOVAL_POLICY = 0x00000020,

		/// <summary>CM_DRP_REMOVAL_POLICY_HW_DEFAULT REG_DWORD (R)</summary>
		CM_DRP_REMOVAL_POLICY_HW_DEFAULT = 0x00000021,

		/// <summary>CM_DRP_REMOVAL_POLICY_OVERRIDE REG_DWORD (RW)</summary>
		CM_DRP_REMOVAL_POLICY_OVERRIDE = 0x00000022,

		/// <summary>CM_DRP_INSTALL_STATE REG_DWORD (R)</summary>
		CM_DRP_INSTALL_STATE = 0x00000023,

		/// <summary>CM_DRP_LOCATION_PATHS REG_MULTI_SZ (R)</summary>
		CM_DRP_LOCATION_PATHS = 0x00000024,

		/// <summary>Base ContainerID REG_SZ property (R)</summary>
		CM_DRP_BASE_CONTAINERID = 0x00000025,
	}

	/// <summary>Flags for CM_Get_Device_Interface_List_Size.</summary>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_Interface_List_SizeW")]
	public enum CM_GET_DEVICE_INTERFACE_LIST
	{
		/// <summary>
		/// The function provides the size of a list containing device interfaces associated with devices that are currently active, and
		/// which match the specified GUID and device instance ID, if any.
		/// </summary>
		CM_GET_DEVICE_INTERFACE_LIST_PRESENT = 0x00000000,

		/// <summary>
		/// The function provides the size of a list that contains device interfaces associated with all devices that match the
		/// specified GUID and device instance ID, if any.
		/// </summary>
		CM_GET_DEVICE_INTERFACE_LIST_ALL_DEVICES = 0x00000001,
	}

	/// <summary>Device problem.</summary>
	[PInvokeData("cfg.h")]
	public enum CM_PROB
	{
		/// <summary>no config for device</summary>
		CM_PROB_NOT_CONFIGURED = 0x00000001,

		/// <summary>service load failed</summary>
		CM_PROB_DEVLOADER_FAILED = 0x00000002,

		/// <summary>out of memory</summary>
		CM_PROB_OUT_OF_MEMORY = 0x00000003,

		/// <summary></summary>
		CM_PROB_ENTRY_IS_WRONG_TYPE = 0x00000004,

		/// <summary></summary>
		CM_PROB_LACKED_ARBITRATOR = 0x00000005,

		/// <summary>boot config conflict</summary>
		CM_PROB_BOOT_CONFIG_CONFLICT = 0x00000006,

		/// <summary></summary>
		CM_PROB_FAILED_FILTER = 0x00000007,

		/// <summary>Devloader not found</summary>
		CM_PROB_DEVLOADER_NOT_FOUND = 0x00000008,

		/// <summary>Invalid ID</summary>
		CM_PROB_INVALID_DATA = 0x00000009,

		/// <summary></summary>
		CM_PROB_FAILED_START = 0x0000000A,

		/// <summary></summary>
		CM_PROB_LIAR = 0x0000000B,

		/// <summary>config conflict</summary>
		CM_PROB_NORMAL_CONFLICT = 0x0000000C,

		/// <summary></summary>
		CM_PROB_NOT_VERIFIED = 0x0000000D,

		/// <summary>requires restart</summary>
		CM_PROB_NEED_RESTART = 0x0000000E,

		/// <summary></summary>
		CM_PROB_REENUMERATION = 0x0000000F,

		/// <summary></summary>
		CM_PROB_PARTIAL_LOG_CONF = 0x00000010,

		/// <summary>unknown res type</summary>
		CM_PROB_UNKNOWN_RESOURCE = 0x00000011,

		/// <summary></summary>
		CM_PROB_REINSTALL = 0x00000012,

		/// <summary></summary>
		CM_PROB_REGISTRY = 0x00000013,

		/// <summary>WINDOWS 95 ONLY</summary>
		CM_PROB_VXDLDR = 0x00000014,

		/// <summary>devinst will remove</summary>
		CM_PROB_WILL_BE_REMOVED = 0x00000015,

		/// <summary>devinst is disabled</summary>
		CM_PROB_DISABLED = 0x00000016,

		/// <summary>Devloader not ready</summary>
		CM_PROB_DEVLOADER_NOT_READY = 0x00000017,

		/// <summary>device doesn't exist</summary>
		CM_PROB_DEVICE_NOT_THERE = 0x00000018,

		/// <summary></summary>
		CM_PROB_MOVED = 0x00000019,

		/// <summary></summary>
		CM_PROB_TOO_EARLY = 0x0000001A,

		/// <summary>no valid log config</summary>
		CM_PROB_NO_VALID_LOG_CONF = 0x0000001B,

		/// <summary>install failed</summary>
		CM_PROB_FAILED_INSTALL = 0x0000001C,

		/// <summary>device disabled</summary>
		CM_PROB_HARDWARE_DISABLED = 0x0000001D,

		/// <summary>can't share IRQ</summary>
		CM_PROB_CANT_SHARE_IRQ = 0x0000001E,

		/// <summary>driver failed add</summary>
		CM_PROB_FAILED_ADD = 0x0000001F,

		/// <summary>service's Start = 4</summary>
		CM_PROB_DISABLED_SERVICE = 0x00000020,

		/// <summary>resource translation failed</summary>
		CM_PROB_TRANSLATION_FAILED = 0x00000021,

		/// <summary>no soft config</summary>
		CM_PROB_NO_SOFTCONFIG = 0x00000022,

		/// <summary>device missing in BIOS table</summary>
		CM_PROB_BIOS_TABLE = 0x00000023,

		/// <summary>IRQ translator failed</summary>
		CM_PROB_IRQ_TRANSLATION_FAILED = 0x00000024,

		/// <summary>DriverEntry() failed.</summary>
		CM_PROB_FAILED_DRIVER_ENTRY = 0x00000025,

		/// <summary>Driver should have unloaded.</summary>
		CM_PROB_DRIVER_FAILED_PRIOR_UNLOAD = 0x00000026,

		/// <summary>Driver load unsuccessful.</summary>
		CM_PROB_DRIVER_FAILED_LOAD = 0x00000027,

		/// <summary>Error accessing driver's service key</summary>
		CM_PROB_DRIVER_SERVICE_KEY_INVALID = 0x00000028,

		/// <summary>Loaded legacy service created no devices</summary>
		CM_PROB_LEGACY_SERVICE_NO_DEVICES = 0x00000029,

		/// <summary>Two devices were discovered with the same name</summary>
		CM_PROB_DUPLICATE_DEVICE = 0x0000002A,

		/// <summary>The drivers set the device state to failed</summary>
		CM_PROB_FAILED_POST_START = 0x0000002B,

		/// <summary>This device was failed post start via usermode</summary>
		CM_PROB_HALTED = 0x0000002C,

		/// <summary>The devinst currently exists only in the registry</summary>
		CM_PROB_PHANTOM = 0x0000002D,

		/// <summary>The system is shutting down</summary>
		CM_PROB_SYSTEM_SHUTDOWN = 0x0000002E,

		/// <summary>The device is offline awaiting removal</summary>
		CM_PROB_HELD_FOR_EJECT = 0x0000002F,

		/// <summary>One or more drivers is blocked from loading</summary>
		CM_PROB_DRIVER_BLOCKED = 0x00000030,

		/// <summary>System hive has grown too large</summary>
		CM_PROB_REGISTRY_TOO_LARGE = 0x00000031,

		/// <summary>Failed to apply one or more registry properties</summary>
		CM_PROB_SETPROPERTIES_FAILED = 0x00000032,

		/// <summary>Device is stalled waiting on a dependency to start</summary>
		CM_PROB_WAITING_ON_DEPENDENCY = 0x00000033,

		/// <summary>Failed load driver due to unsigned image.</summary>
		CM_PROB_UNSIGNED_DRIVER = 0x00000034,

		/// <summary>Device is being used by kernel debugger</summary>
		CM_PROB_USED_BY_DEBUGGER = 0x00000035,

		/// <summary>Device is being reset</summary>
		CM_PROB_DEVICE_RESET = 0x00000036,

		/// <summary>Device is blocked while console is locked</summary>
		CM_PROB_CONSOLE_LOCKED = 0x00000037,

		/// <summary>Device needs extended class configuration to start</summary>
		CM_PROB_NEED_CLASS_CONFIG = 0x00000038,

		/// <summary>Assignment to guest partition failed</summary>
		CM_PROB_GUEST_ASSIGNMENT_FAILED = 0x00000039,
	}

	/// <summary>Configuration flags</summary>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_HW_Prof_FlagsA")]
	[Flags]
	public enum CSCONFIGFLAG
	{
		/// <summary>The device instance is disabled in the specified hardware profile.</summary>
		CSCONFIGFLAG_DISABLED = 1,

		/// <summary>The hardware profile does not support the specified device instance.</summary>
		CSCONFIGFLAG_DO_NOT_CREATE = 2,

		/// <summary>The device cannot be started in the specified hardware profile.</summary>
		CSCONFIGFLAG_DO_NOT_START = 4,
	}

	/// <summary>
	/// The <c>CM_Get_Device_ID_List_Size</c> function retrieves the buffer size required to hold a list of device instance IDs for the
	/// local machine's device instances.
	/// </summary>
	/// <param name="pulLen">Receives a value representing the required buffer size, in characters.</param>
	/// <param name="pszFilter">
	/// Caller-supplied pointer to a character string specifying a subset of the machine's device instance identifiers, or <c>NULL</c>.
	/// See the following description of ulFlags.
	/// </param>
	/// <param name="ulFlags">
	/// One of the optional, caller-supplied bit flags that specify search filters. If no flags are specified, the function supplies the
	/// buffer size required to hold all instance identifiers for all device instances. For a list of bit flags, see the ulFlags
	/// description for CM_Get_Device_ID_List.
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>The <c>CM_Get_Device_ID_List_Size</c> function should be called to determine the buffer size required by CM_Get_Device_ID_List.</para>
	/// <para>
	/// The size value supplied in the location pointed to by pulLen is guaranteed to represent a buffer size large enough to hold all
	/// device instance identifier strings and terminating NULLs. The supplied value might actually represent a buffer size that is
	/// larger than necessary, so don't assume the value represents the true length of the character strings that CM_Get_Device_ID_List
	/// will provide.
	/// </para>
	/// <para>For information about device instance IDs, see Device Identification Strings.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The cfgmgr32.h header defines CM_Get_Device_ID_List_Size as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_id_list_sizea CMAPI CONFIGRET
	// CM_Get_Device_ID_List_SizeA( PULONG pulLen, PCSTR pszFilter, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_ID_List_SizeA")]
	public static extern CONFIGRET CM_Get_Device_ID_List_Size(out uint pulLen, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? pszFilter, CM_GETIDLIST ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Device_ID_List_Size instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Get_Device_ID_List_Size_Ex</c> function retrieves the buffer size required to hold a list of device instance IDs for a
	/// local or a remote machine's device instances.
	/// </para>
	/// </summary>
	/// <param name="pulLen">Receives a value representing the required buffer size, in characters.</param>
	/// <param name="pszFilter">
	/// Caller-supplied pointer to a character string specifying a subset of the machine's device instance identifiers, or <c>NULL</c>.
	/// See the following description of ulFlags.
	/// </param>
	/// <param name="ulFlags">
	/// One of the optional, caller-supplied bit flags that specify search filters. If no flags are specified, the function supplies the
	/// buffer size required to hold all instance identifiers for all device instances. For a list of bit flags, see the ulFlags
	/// description for CM_Get_Device_ID_List_Ex.
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
	/// <para>The <c>CM_Get_Device_ID_List_Size_Ex</c> function should be called to determine the buffer size required by CM_Get_Device_ID_List_Ex.</para>
	/// <para>
	/// The size value supplied in the location pointed to by pulLen is guaranteed to represent a buffer size large enough to hold all
	/// device instance identifier strings and terminating NULLs. The supplied value might actually represent a buffer size that is
	/// larger than necessary, so don't assume the value represents the true length of the character strings that
	/// CM_Get_Device_ID_List_Ex will provide.
	/// </para>
	/// <para>For information about device instance IDs, see Device Identification Strings.</para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_id_list_size_exw CMAPI CONFIGRET
	// CM_Get_Device_ID_List_Size_ExW( PULONG pulLen, PCWSTR pszFilter, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_ID_List_Size_ExW")]
	public static extern CONFIGRET CM_Get_Device_ID_List_Size_Ex(out uint pulLen, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? pszFilter, [In, Optional] CM_GETIDLIST ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Get_Device_ID_Size</c> function retrieves the buffer size required to hold a device instance ID for a device instance
	/// on the local machine.
	/// </summary>
	/// <param name="pulLen">Receives a value representing the required buffer size, in characters.</param>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>The <c>CM_Get_Device_ID_Size</c> function should be called to determine the buffer size required by CM_Get_Device_ID.</para>
	/// <para>
	/// The size value supplied in the location pointed to by pulLen is less than MAX_DEVICE_ID_LEN, and does not include the identifier
	/// string's terminating <c>NULL</c>. If the specified device instance does not exist, the function supplies a size value of zero.
	/// </para>
	/// <para>For information about device instance IDs, see Device Identification Strings.</para>
	/// <para>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_id_size CMAPI CONFIGRET
	// CM_Get_Device_ID_Size( PULONG pulLen, DEVINST dnDevInst, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_ID_Size")]
	public static extern CONFIGRET CM_Get_Device_ID_Size(out uint pulLen, uint dnDevInst, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Device_ID_Size instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Get_Device_ID_Size_Ex</c> function retrieves the buffer size required to hold a device instance ID for a device
	/// instance on a local or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="pulLen">Receives a value representing the required buffer size, in characters.</param>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
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
	/// <para>The <c>CM_Get_Device_ID_Size_Ex</c> function should be called to determine the buffer size required by CM_Get_Device_ID_Ex.</para>
	/// <para>
	/// The size value supplied in the location pointed to by pulLen is less than MAX_DEVICE_ID_LEN, and does not include the identifier
	/// string's terminating <c>NULL</c>. If the specified device instance does not exist, the function supplies a size value of zero.
	/// </para>
	/// <para>For information about device instance IDs, see Device Identification Strings.</para>
	/// <para>For information about using device instance handles that are bound to a local or a remote machine, see CM_Get_Child_Ex.</para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_id_size_ex CMAPI CONFIGRET
	// CM_Get_Device_ID_Size_Ex( PULONG pulLen, DEVINST dnDevInst, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_ID_Size_Ex")]
	public static extern CONFIGRET CM_Get_Device_ID_Size_Ex(out uint pulLen, uint dnDevInst, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Get_Device_ID</c> function retrieves the device instance ID for a specified device instance on the local machine.
	/// </summary>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
	/// <param name="Buffer">
	/// Address of a buffer to receive a device instance ID string. The required buffer size can be obtained by calling
	/// CM_Get_Device_ID_Size, then incrementing the received value to allow room for the string's terminating <c>NULL</c>.
	/// </param>
	/// <param name="BufferLen">Caller-supplied length, in characters, of the buffer specified by Buffer.</param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The function appends a NULL terminator to the supplied device instance ID string, unless the buffer is too small to hold the
	/// string. In this case, the function supplies as much of the identifier string as will fit into the buffer, and then returns CR_BUFFER_SMALL.
	/// </para>
	/// <para>For information about device instance IDs, see Device Identification Strings.</para>
	/// <para>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_idw CMAPI CONFIGRET CM_Get_Device_IDW(
	// DEVINST dnDevInst, PWSTR Buffer, ULONG BufferLen, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_IDW")]
	public static extern CONFIGRET CM_Get_Device_ID(uint dnDevInst, StringBuilder Buffer, uint BufferLen, uint ulFlags = 0);

	/// <summary>
	/// The <c>CM_Get_Device_Interface_Alias</c> function returns the alias of the specified device interface instance, if the alias exists.
	/// </summary>
	/// <param name="pszDeviceInterface">
	/// Pointer to the name of the device interface instance for which to retrieve an alias. The caller typically received this string
	/// from a call to CM_Get_Device_Interface_List, or in a PnP notification structure.
	/// </param>
	/// <param name="AliasInterfaceGuid">Pointer to a GUID specifying the interface class of the alias to retrieve.</param>
	/// <param name="pszAliasDeviceInterface">
	/// <para>
	/// Specifies a pointer to a buffer, that upon successful return, points to a string containing the name of the alias. The caller
	/// must free this string when it is no longer needed.
	/// </para>
	/// <para>A buffer is required. Otherwise, the call will fail.</para>
	/// </param>
	/// <param name="pulLength">
	/// <para>
	/// Supplies the count of characters in pszAliasDeviceInterface and receives the number of characters required to hold the alias
	/// device interface.
	/// </para>
	/// <para>On input, this parameter must be greater than 0.</para>
	/// </param>
	/// <param name="ulFlags">Reserved. Do not use.</param>
	/// <returns>
	/// <para>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CR_NO_SUCH_DEVICE_INTERFACE</term>
	/// <term>Possibly indicates that there is no alias of the specified interface class.</term>
	/// </item>
	/// <item>
	/// <term>CR_OUT_OF_MEMORY</term>
	/// <term>There is not enough memory to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>CR_BUFFER_SMALL</term>
	/// <term>The buffer passed is too small.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Device interfaces are considered aliases if they are exposed by the same underlying device and have identical interface
	/// reference strings, but are of different interface classes.
	/// </para>
	/// <para>
	/// The pszDeviceInterface parameter specifies a device interface instance for a particular device, belonging to a particular
	/// interface class, with a particular reference string. <c>CM_Get_Device_Interface_Alias</c> returns another device interface
	/// instance for the same device and reference string, but of a different interface class, if it exists.
	/// </para>
	/// <para>
	/// For example, the function driver for a fault-tolerant volume could register and set two device interfaces, one of the
	/// fault-tolerant-volume interface class and one of the volume interface class. Another driver could call
	/// <c>CM_Get_Device_Interface_Alias</c> with the symbolic link for one of the interfaces and ask whether the other interface exists
	/// by specifying its interface class.
	/// </para>
	/// <para>
	/// Two device interfaces with <c>NULL</c> reference strings are aliases if they are exposed by the same underlying device and have
	/// different interface class GUIDs.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_interface_aliasw CMAPI CONFIGRET
	// CM_Get_Device_Interface_AliasW( LPCWSTR pszDeviceInterface, LPGUID AliasInterfaceGuid, LPWSTR pszAliasDeviceInterface, PULONG
	// pulLength, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_Interface_AliasW")]
	public static extern CONFIGRET CM_Get_Device_Interface_Alias([MarshalAs(UnmanagedType.LPTStr)] string pszDeviceInterface, in Guid AliasInterfaceGuid,
		[MarshalAs(UnmanagedType.LPTStr)] StringBuilder pszAliasDeviceInterface, ref uint pulLength, uint ulFlags = 0);

	/// <summary>
	/// The <c>CM_Get_Device_Interface_List</c> function retrieves a list of device interface instances that belong to a specified
	/// device interface class.
	/// </summary>
	/// <param name="InterfaceClassGuid">Supplies a GUID that identifies a device interface class.</param>
	/// <param name="pDeviceID">
	/// Caller-supplied pointer to a NULL-terminated string that represents a device instance ID. If specified, the function retrieves
	/// device interfaces that are supported by the device for the specified class. If this value is <c>NULL</c>, or if it points to a
	/// zero-length string, the function retrieves all interfaces that belong to the specified class.
	/// </param>
	/// <param name="Buffer">
	/// Caller-supplied pointer to a buffer that receives multiple, NULL-terminated Unicode strings, each representing the symbolic link
	/// name of an interface instance.
	/// </param>
	/// <param name="BufferLen">
	/// Caller-supplied value that specifies the length, in characters, of the buffer pointed to by Buffer. Call
	/// CM_Get_Device_Interface_List_Size to determine the required buffer size.
	/// </param>
	/// <param name="ulFlags">
	/// <para>Contains one of the following caller-supplied flags:</para>
	/// <para>CM_GET_DEVICE_INTERFACE_LIST_ALL_DEVICES</para>
	/// <para>
	/// The function provides a list containing device interfaces associated with all devices that match the specified GUID and device
	/// instance ID, if any.
	/// </para>
	/// <para>CM_GET_DEVICE_INTERFACE_LIST_PRESENT</para>
	/// <para>
	/// The function provides a list containing device interfaces associated with devices that are currently active, and which match the
	/// specified GUID and device instance ID, if any.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the error codes with the CR_ prefix as
	/// defined in Cfgmgr32.h.
	/// </para>
	/// <para>The following table includes some of the more common error codes that this function might return.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CR_BUFFER_SMALL</term>
	/// <term>The Buffer buffer is too small to hold the requested list of device interfaces.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Between calling CM_Get_Device_Interface_List_Size to get the size of the list and calling <c>CM_Get_Device_Interface_List</c> to
	/// get the list, a new device interface can be added to the system causing the size returned to no longer be valid. Callers should
	/// be robust to that condition and retry getting the size and the list if <c>CM_Get_Device_Interface_List</c> returns <c>CR_BUFFER_SMALL</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>This snippet illustrates retrying getting the size and the list as described in the Remarks section.</para>
	/// <para>
	/// <code> CONFIGRET cr = CR_SUCCESS; PWSTR DeviceInterfaceList = NULL; ULONG DeviceInterfaceListLength = 0; do { cr = CM_Get_Device_Interface_List_Size(&amp;DeviceInterfaceListLength, (LPGUID)&amp;GUID_DEVINTERFACE_VOLUME, NULL, CM_GET_DEVICE_INTERFACE_LIST_ALL_DEVICES); if (cr != CR_SUCCESS) { break; } if (DeviceInterfaceList != NULL) { HeapFree(GetProcessHeap(), 0, DeviceInterfaceList); } DeviceInterfaceList = (PWSTR)HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, DeviceInterfaceListLength * sizeof(WCHAR)); if (DeviceInterfaceList == NULL) { cr = CR_OUT_OF_MEMORY; break; } cr = CM_Get_Device_Interface_List((LPGUID)&amp;GUID_DEVINTERFACE_VOLUME, NULL, DeviceInterfaceList, DeviceInterfaceListLength, CM_GET_DEVICE_INTERFACE_LIST_ALL_DEVICES); } while (cr == CR_BUFFER_SMALL); if (cr != CR_SUCCESS) { goto Exit; }</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The cfgmgr32.h header defines CM_Get_Device_Interface_List as an alias which automatically selects the ANSI or Unicode version
	/// of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with
	/// code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_interface_lista CMAPI CONFIGRET
	// CM_Get_Device_Interface_ListA( LPGUID InterfaceClassGuid, DEVINSTID_A pDeviceID, PZZSTR Buffer, ULONG BufferLen, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_Interface_ListA")]
	public static extern CONFIGRET CM_Get_Device_Interface_List(in Guid InterfaceClassGuid, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? pDeviceID,
		IntPtr Buffer, uint BufferLen, CM_GET_DEVICE_INTERFACE_LIST ulFlags);

	/// <summary>
	/// The <c>CM_Get_Device_Interface_List</c> function retrieves a list of device interface instances that belong to a specified
	/// device interface class.
	/// </summary>
	/// <param name="InterfaceClassGuid">Supplies a GUID that identifies a device interface class.</param>
	/// <param name="ulFlags">
	/// <para>Contains one of the following caller-supplied flags:</para>
	/// <para>CM_GET_DEVICE_INTERFACE_LIST_ALL_DEVICES</para>
	/// <para>
	/// The function provides a list containing device interfaces associated with all devices that match the specified GUID and device
	/// instance ID, if any.
	/// </para>
	/// <para>CM_GET_DEVICE_INTERFACE_LIST_PRESENT</para>
	/// <para>
	/// The function provides a list containing device interfaces associated with devices that are currently active, and which match the
	/// specified GUID and device instance ID, if any.
	/// </para>
	/// </param>
	/// <param name="pDeviceID">
	/// Caller-supplied string that represents a device instance ID. If specified, the function retrieves device interfaces that are
	/// supported by the device for the specified class. If this value is <see langword="null"/>, or if it is a zero-length string, the
	/// function retrieves all interfaces that belong to the specified class.
	/// </param>
	/// <returns>An array of strings, each representing the symbolic link name of an interface instance.</returns>
	public static string[] CM_Get_Device_Interface_List(in Guid InterfaceClassGuid, CM_GET_DEVICE_INTERFACE_LIST ulFlags, string? pDeviceID = null)
	{
		while (true)
		{
			CM_Get_Device_Interface_List_Size(out var len, InterfaceClassGuid, pDeviceID, ulFlags).ThrowIfFailed();
			using var mem = new SafeCoTaskMemHandle(len * StringHelper.GetCharSize());
			var ret = CM_Get_Device_Interface_List(InterfaceClassGuid, pDeviceID, mem, len, ulFlags);
			if (ret == CONFIGRET.CR_SUCCESS)
				return mem.ToStringEnum().ToArray();
			else if (ret != CONFIGRET.CR_BUFFER_SMALL)
				ret.ThrowIfFailed();
		}
	}

	/// <summary>
	/// The <c>CM_Get_Device_Interface_List_Size</c> function retrieves the buffer size that must be passed to the
	/// CM_Get_Device_Interface_List function.
	/// </summary>
	/// <param name="pulLen">
	/// Caller-supplied pointer to a location that receives the required length, in characters, of a buffer to hold the multiple Unicode
	/// strings that will be returned by <c>CM_Get_Device_Interface_List</c>.
	/// </param>
	/// <param name="InterfaceClassGuid">Supplies a GUID that identifies a device interface class.</param>
	/// <param name="pDeviceID">
	/// Caller-supplied pointer to a NULL-terminated string that represents a device instance ID. If specified, the function retrieves
	/// the length of symbolic link names for the device interfaces that are supported by the device, for the specified class. If this
	/// value is <c>NULL</c>, or if it points to a zero-length string, the function retrieves the length of symbolic link names for all
	/// interfaces that belong to the specified class.
	/// </param>
	/// <param name="ulFlags">
	/// <para>Contains one of the following caller-supplied flags:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CM_GET_DEVICE_INTERFACE_LIST_ALL_DEVICES</term>
	/// <term>
	/// The function provides the size of a list that contains device interfaces associated with all devices that match the specified
	/// GUID and device instance ID, if any.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CM_GET_DEVICE_INTERFACE_LIST_PRESENT</term>
	/// <term>
	/// The function provides the size of a list containing device interfaces associated with devices that are currently active, and
	/// which match the specified GUID and device instance ID, if any.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns <c>CR_SUCCESS</c>. Otherwise, it returns one of the error codes with the
	/// <c>CR_</c> prefix as defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The cfgmgr32.h header defines CM_Get_Device_Interface_List_Size as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
	/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
	/// information, see Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_interface_list_sizew CMAPI CONFIGRET
	// CM_Get_Device_Interface_List_SizeW( PULONG pulLen, LPGUID InterfaceClassGuid, DEVINSTID_W pDeviceID, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_Interface_List_SizeW")]
	public static extern CONFIGRET CM_Get_Device_Interface_List_Size(out uint pulLen, in Guid InterfaceClassGuid,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? pDeviceID, CM_GET_DEVICE_INTERFACE_LIST ulFlags);

	/// <summary>The <c>CM_Get_Device_Interface_Property</c> function retrieves a device property that is set for a device interface.</summary>
	/// <param name="pszDeviceInterface">
	/// Pointer to a string that identifies the device interface instance to retrieve the property from.
	/// </param>
	/// <param name="PropertyKey">
	/// Pointer to a DEVPROPKEY structure that represents the device interface property key of the device interface property to retrieve.
	/// </param>
	/// <param name="PropertyType">
	/// Pointer to a DEVPROPTYPE-typed variable that receives the property-data-type identifier of the requested device interface
	/// property. The property-data-type identifier is a bitwise OR between a base-data-type identifier and, if the base-data type is
	/// modified, a property-data-type modifier.
	/// </param>
	/// <param name="PropertyBuffer">
	/// A pointer to a buffer that receives the requested device interface property. <c>CM_Get_Device_Interface_Property</c> retrieves
	/// the requested property only if the buffer is large enough to hold all the property value data. The pointer can be NULL.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to NULL, *PropertyBufferSize must be set to zero. As
	/// output, if the buffer is not large enough to hold all the property value data, <c>CM_Get_Device_Interface_Property</c> returns
	/// the size of the data, in bytes, in *PropertyBufferSize.
	/// </param>
	/// <param name="ulFlags">Reserved. Must be set to zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks><c>CM_Get_Device_Interface_Property</c> is part of the Unified Device Property Model.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_interface_propertyw CMAPI CONFIGRET
	// CM_Get_Device_Interface_PropertyW( LPCWSTR pszDeviceInterface, const DEVPROPKEY *PropertyKey, DEVPROPTYPE *PropertyType, PBYTE
	// PropertyBuffer, PULONG PropertyBufferSize, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_Interface_PropertyW")]
	public static extern CONFIGRET CM_Get_Device_Interface_Property([MarshalAs(UnmanagedType.LPTStr)] string pszDeviceInterface, in DEVPROPKEY PropertyKey,
		out DEVPROPTYPE PropertyType, [Out, Optional] IntPtr PropertyBuffer, ref uint PropertyBufferSize, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use
	/// CM_Get_Device_Interface_Property instead.]
	/// </para>
	/// <para>The <c>CM_Get_Device_Interface_Property_ExW</c> function retrieves a device property that is set for a device interface.</para>
	/// </summary>
	/// <param name="pszDeviceInterface">
	/// Pointer to a string that identifies the device interface instance to retrieve the property from.
	/// </param>
	/// <param name="PropertyKey">
	/// Pointer to a DEVPROPKEY structure that represents the device interface property key of the device interface property to retrieve.
	/// </param>
	/// <param name="PropertyType">
	/// Pointer to a DEVPROPTYPE-typed variable that receives the property-data-type identifier of the requested device interface
	/// property. The property-data-type identifier is a bitwise OR between a base-data-type identifier and, if the base-data type is
	/// modified, a property-data-type modifier.
	/// </param>
	/// <param name="PropertyBuffer">
	/// A pointer to a buffer that receives the requested device interface property. <c>CM_Get_Device_Interface_Property_ExW</c>
	/// retrieves the requested property only if the buffer is large enough to hold all the property value data. The pointer can be NULL.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to NULL, *PropertyBufferSize must be set to zero. As
	/// output, if the buffer is not large enough to hold all the property value data, <c>CM_Get_Device_Interface_Property_ExW</c>
	/// returns the size of the data, in bytes, in *PropertyBufferSize.
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
	/// <remarks><c>CM_Get_Device_Interface_Property_ExW</c> is part of the Unified Device Property Model.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_interface_property_exw CMAPI CONFIGRET
	// CM_Get_Device_Interface_Property_ExW( LPCWSTR pszDeviceInterface, const DEVPROPKEY *PropertyKey, DEVPROPTYPE *PropertyType, PBYTE
	// PropertyBuffer, PULONG PropertyBufferSize, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_Interface_Property_ExW")]
	public static extern CONFIGRET CM_Get_Device_Interface_Property_Ex([MarshalAs(UnmanagedType.LPTStr)] string pszDeviceInterface, in DEVPROPKEY PropertyKey, out DEVPROPTYPE PropertyType,
		[Out, Optional] IntPtr PropertyBuffer, ref uint PropertyBufferSize, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Get_Device_Interface_Property_Keys</c> function retrieves an array of device property keys that represent the device
	/// properties that are set for a device interface.
	/// </summary>
	/// <param name="pszDeviceInterface">
	/// Pointer to a string that identifies the device interface instance to retrieve the property keys from.
	/// </param>
	/// <param name="PropertyKeyArray">
	/// Pointer to a buffer that receives an array of DEVPROPKEY-typed values, where each value is a device property key that represents
	/// a device property that is set for the device interface. The pointer is optional and can be NULL
	/// </param>
	/// <param name="PropertyKeyCount">
	/// The size, in DEVPROPKEY-typed units, of the PropertyKeyArray buffer. If PropertyKeyArray is set to NULL, *PropertyKeyCount must
	/// be set to zero. As output, if PropertyKeyArray is not large enough to hold all the property key data,
	/// <c>CM_Get_Device_Interface_Property_Keys</c> returns the count of the keys, in *PropertyKeyCount.
	/// </param>
	/// <param name="ulFlags">Reserved. Must be set to zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks><c>CM_Get_Device_Interface_Property_Keys</c> is part of the Unified Device Property Model.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_interface_property_keysw CMAPI CONFIGRET
	// CM_Get_Device_Interface_Property_KeysW( LPCWSTR pszDeviceInterface, DEVPROPKEY *PropertyKeyArray, PULONG PropertyKeyCount, ULONG
	// ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_Interface_Property_KeysW")]
	public static extern CONFIGRET CM_Get_Device_Interface_Property_Keys([MarshalAs(UnmanagedType.LPTStr)] string pszDeviceInterface,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEVPROPKEY[]? PropertyKeyArray, ref uint PropertyKeyCount, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use
	/// CM_Get_Device_Interface_Property_Keys instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Get_Device_Interface_Property_Keys_ExW</c> function retrieves an array of device property keys that represent the
	/// device properties that are set for a device interface.
	/// </para>
	/// </summary>
	/// <param name="pszDeviceInterface">
	/// Pointer to a string that identifies the device interface instance to retrieve the property keys from.
	/// </param>
	/// <param name="PropertyKeyArray">
	/// Pointer to a buffer that receives an array of DEVPROPKEY-typed values, where each value is a device property key that represents
	/// a device property that is set for the device interface. The pointer is optional and can be NULL
	/// </param>
	/// <param name="PropertyKeyCount">
	/// The size, in DEVPROPKEY-typed units, of the PropertyKeyArray buffer. If PropertyKeyArray is set to NULL, *PropertyKeyCount must
	/// be set to zero. As output, if PropertyKeyArray is not large enough to hold all the property key data,
	/// <c>CM_Get_Device_Interface_Property_Keys_ExW</c> returns the count of the keys, in *PropertyKeyCount.
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
	/// <remarks><c>CM_Get_Device_Interface_Property_Keys_ExW</c> is part of the Unified Device Property Model.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_interface_property_keys_exw CMAPI CONFIGRET
	// CM_Get_Device_Interface_Property_Keys_ExW( LPCWSTR pszDeviceInterface, DEVPROPKEY *PropertyKeyArray, PULONG PropertyKeyCount,
	// ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Device_Interface_Property_Keys_ExW")]
	public static extern CONFIGRET CM_Get_Device_Interface_Property_Keys_Ex([MarshalAs(UnmanagedType.LPTStr)] string pszDeviceInterface,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEVPROPKEY[]? PropertyKeyArray, ref uint PropertyKeyCount, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>The <c>CM_Get_DevNode_Property</c> function retrieves a device instance property.</summary>
	/// <param name="dnDevInst">Device instance handle that is bound to the local machine.</param>
	/// <param name="PropertyKey">
	/// Pointer to a DEVPROPKEY structure that represents the device property key of the requested device instance property.
	/// </param>
	/// <param name="PropertyType">
	/// Pointer to a DEVPROPTYPE-typed variable that receives the property-data-type identifier of the requested device instance
	/// property, where the property-data-type identifier is the bitwise OR between a base-data-type identifier and, if the base-data
	/// type is modified, a property-data-type modifier.
	/// </param>
	/// <param name="PropertyBuffer">
	/// Pointer to a buffer that receives the requested device instance property. <c>CM_Get_DevNode_Property</c> retrieves the requested
	/// property only if the buffer is large enough to hold all the property value data. The pointer can be NULL.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to NULL, *PropertyBufferSize must be set to zero. As
	/// output, if the buffer is not large enough to hold all the property value data, <c>CM_Get_DevNode_Property</c> returns the size
	/// of the data, in bytes, in *PropertyBufferSize.
	/// </param>
	/// <param name="ulFlags">Reserved. Must be set to zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks><c>CM_Get_DevNode_Property</c> is part of the Unified Device Property Model.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_devnode_propertyw CMAPI CONFIGRET
	// CM_Get_DevNode_PropertyW( DEVINST dnDevInst, const DEVPROPKEY *PropertyKey, DEVPROPTYPE *PropertyType, PBYTE PropertyBuffer,
	// PULONG PropertyBufferSize, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_DevNode_PropertyW")]
	public static extern CONFIGRET CM_Get_DevNode_Property(uint dnDevInst, in DEVPROPKEY PropertyKey, out DEVPROPTYPE PropertyType, [Out, Optional] IntPtr PropertyBuffer,
		ref uint PropertyBufferSize, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_DevNode_Property instead.]
	/// </para>
	/// <para>The <c>CM_Get_DevNode_Property_ExW</c> function retrieves a device instance property.</para>
	/// </summary>
	/// <param name="dnDevInst">Device instance handle that is bound to the local machine.</param>
	/// <param name="PropertyKey">
	/// Pointer to a DEVPROPKEY structure that represents the device property key of the requested device instance property.
	/// </param>
	/// <param name="PropertyType">
	/// Pointer to a DEVPROPTYPE-typed variable that receives the property-data-type identifier of the requested device instance
	/// property, where the property-data-type identifier is the bitwise OR between a base-data-type identifier and, if the base-data
	/// type is modified, a property-data-type modifier.
	/// </param>
	/// <param name="PropertyBuffer">
	/// Pointer to a buffer that receives the requested device instance property. <c>CM_Get_DevNode_Property_ExW</c> retrieves the
	/// requested property only if the buffer is large enough to hold all the property value data. The pointer can be NULL.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to NULL, *PropertyBufferSize must be set to zero. As
	/// output, if the buffer is not large enough to hold all the property value data, <c>CM_Get_DevNode_Property_ExW</c> returns the
	/// size of the data, in bytes, in *PropertyBufferSize.
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
	/// <remarks><c>CM_Get_DevNode_Property_ExW</c> is part of the Unified Device Property Model.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_devnode_property_exw CMAPI CONFIGRET
	// CM_Get_DevNode_Property_ExW( DEVINST dnDevInst, const DEVPROPKEY *PropertyKey, DEVPROPTYPE *PropertyType, PBYTE PropertyBuffer,
	// PULONG PropertyBufferSize, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_DevNode_Property_ExW")]
	public static extern CONFIGRET CM_Get_DevNode_Property_Ex(uint dnDevInst, in DEVPROPKEY PropertyKey, out DEVPROPTYPE PropertyType, [Out, Optional] IntPtr PropertyBuffer,
		ref uint PropertyBufferSize, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Get_DevNode_Property_Keys</c> function retrieves an array of the device property keys that represent the device
	/// properties that are set for a device instance.
	/// </summary>
	/// <param name="dnDevInst">Device instance handle that is bound to the local machine.</param>
	/// <param name="PropertyKeyArray">
	/// Pointer to a buffer that receives an array of DEVPROPKEY-typed values, where each value is a device property key that represents
	/// a device property that is set for the device instance. The pointer is optional and can be NULL.
	/// </param>
	/// <param name="PropertyKeyCount">
	/// The size, in DEVPROPKEY-typed units, of the PropertyKeyArray buffer. If PropertyKeyArray is set to NULL, *PropertyKeyCount must
	/// be set to zero. As output, If PropertyKeyArray is not large enough to hold all the property key data,
	/// <c>CM_Get_DevNode_Property_Keys</c> returns the count of the keys in *PropertyKeyCount.
	/// </param>
	/// <param name="ulFlags">Reserved. Must be set to zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks><c>CM_Get_DevNode_Property_Keys</c> is part of the Unified Device Property Model.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_devnode_property_keys CMAPI CONFIGRET
	// CM_Get_DevNode_Property_Keys( DEVINST dnDevInst, DEVPROPKEY *PropertyKeyArray, PULONG PropertyKeyCount, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_DevNode_Property_Keys")]
	public static extern CONFIGRET CM_Get_DevNode_Property_Keys(uint dnDevInst, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEVPROPKEY[]? PropertyKeyArray,
		ref uint PropertyKeyCount, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_DevNode_Property_Keys instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Get_DevNode_Property_Keys_Ex</c> function retrieves an array of the device property keys that represent the device
	/// properties that are set for a device instance.
	/// </para>
	/// </summary>
	/// <param name="dnDevInst">Device instance handle that is bound to the local machine.</param>
	/// <param name="PropertyKeyArray">
	/// Pointer to a buffer that receives an array of DEVPROPKEY-typed values, where each value is a device property key that represents
	/// a device property that is set for the device instance. The pointer is optional and can be NULL.
	/// </param>
	/// <param name="PropertyKeyCount">
	/// The size, in DEVPROPKEY-typed units, of the PropertyKeyArray buffer. If PropertyKeyArray is set to NULL, *PropertyKeyCount must
	/// be set to zero. As output, If PropertyKeyArray is not large enough to hold all the property key data,
	/// <c>CM_Get_DevNode_Property_Keys_Ex</c> returns the count of the keys in *PropertyKeyCount.
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
	/// <remarks><c>CM_Get_DevNode_Property_Keys_Ex</c> is part of the Unified Device Property Model.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_devnode_property_keys_ex CMAPI CONFIGRET
	// CM_Get_DevNode_Property_Keys_Ex( DEVINST dnDevInst, DEVPROPKEY *PropertyKeyArray, PULONG PropertyKeyCount, ULONG ulFlags,
	// HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_DevNode_Property_Keys_Ex")]
	public static extern CONFIGRET CM_Get_DevNode_Property_Keys_Ex(uint dnDevInst, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEVPROPKEY[]? PropertyKeyArray,
		ref uint PropertyKeyCount, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>The <c>CM_Get_DevNode_Registry_Property</c> function retrieves a specified device property from the registry.</summary>
	/// <param name="dnDevInst">A caller-supplied device instance handle that is bound to the local machine.</param>
	/// <param name="ulProperty">
	/// A CM_DRP_-prefixed constant value that identifies the device property to be obtained from the registry. These constants are
	/// defined in Cfgmgr32.h.
	/// </param>
	/// <param name="pulRegDataType">
	/// Optional, can be <c>NULL</c>. A pointer to a location that receives the registry data type, specified as a REG_-prefixed
	/// constant defined in Winnt.h.
	/// </param>
	/// <param name="Buffer">
	/// Optional, can be <c>NULL</c>. A pointer to a caller-supplied buffer that receives the requested device property. If this value
	/// is <c>NULL</c>, the function supplies only the length of the requested data in the address pointed to by pulLength.
	/// </param>
	/// <param name="pulLength">
	/// <para>A pointer to a ULONG variable into which the function stores the length, in bytes, of the requested device property.</para>
	/// <para>If the Buffer parameter is set to <c>NULL</c>, the ULONG variable must be set to zero.</para>
	/// <para>
	/// If the Buffer parameter is not set to <c>NULL</c>, the ULONG variable must be set to the length, in bytes, of the
	/// caller-supplied buffer.
	/// </para>
	/// </param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes that are
	/// defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>For information about how to use device instance handles that are bound to the local machine, see CM_Get_Child.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_devnode_registry_propertyw CMAPI CONFIGRET
	// CM_Get_DevNode_Registry_PropertyW( DEVINST dnDevInst, ULONG ulProperty, PULONG pulRegDataType, PVOID Buffer, PULONG pulLength,
	// ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_DevNode_Registry_PropertyW")]
	public static extern CONFIGRET CM_Get_DevNode_Registry_Property(uint dnDevInst, CM_DRP ulProperty, out REG_VALUE_TYPE pulRegDataType,
		[Out, Optional] IntPtr Buffer, ref uint pulLength, uint ulFlags = 0);

	/// <summary>
	/// The <c>CM_Get_DevNode_Status</c> function obtains the status of a device instance from its device node (devnode) in the local
	/// machine's device tree.
	/// </summary>
	/// <param name="pulStatus">
	/// Address of a location to receive status bit flags. The function can set any combination of the <c>DN_-</c> prefixed bit flags
	/// defined in Cfg.h.
	/// </param>
	/// <param name="pulProblemNumber">
	/// Address of a location to receive one of the <c>CM_PROB_</c>-prefixed problem values defined in Cfg.h. Used only if
	/// DN_HAS_PROBLEM is set in pulStatus.
	/// </param>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_devnode_status CMAPI CONFIGRET
	// CM_Get_DevNode_Status( PULONG pulStatus, PULONG pulProblemNumber, DEVINST dnDevInst, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_DevNode_Status")]
	public static extern CONFIGRET CM_Get_DevNode_Status(out DN pulStatus, out CM_PROB pulProblemNumber, uint dnDevInst, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_DevNode_Status instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Get_DevNode_Status_Ex</c> function obtains the status of a device instance from its device node (devnode) on a local
	/// or a remote machine's device tree.
	/// </para>
	/// </summary>
	/// <param name="pulStatus">
	/// Address of a location to receive status bit flags. The function can set any combination of the DN_-prefixed bit flags defined in Cfg.h.
	/// </param>
	/// <param name="pulProblemNumber">
	/// Address of a location to receive one of the CM_PROB_-prefixed problem values defined in Cfg.h. Used only if DN_HAS_PROBLEM is
	/// set in pulStatus.
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
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_devnode_status_ex CMAPI CONFIGRET
	// CM_Get_DevNode_Status_Ex( PULONG pulStatus, PULONG pulProblemNumber, DEVINST dnDevInst, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_DevNode_Status_Ex")]
	public static extern CONFIGRET CM_Get_DevNode_Status_Ex(out DN pulStatus, out CM_PROB pulProblemNumber, uint dnDevInst, [In, Optional] uint ulFlags,
		[In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Get_First_Log_Conf</c> function obtains the first logical configuration, of a specified configuration type, associated
	/// with a specified device instance on the local machine.
	/// </summary>
	/// <param name="plcLogConf">
	/// Address of a location to receive the handle to a logical configuration, or <c>NULL</c>. See the following <c>Remarks</c> section.
	/// </param>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
	/// <param name="ulFlags">
	/// <para>
	/// Caller-supplied flag value indicating the type of logical configuration being requested. One of the flags in the following table
	/// must be specified.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Configuration Type Flags</term>
	/// <term>Definitions</term>
	/// </listheader>
	/// <item>
	/// <term>BASIC_LOG_CONF</term>
	/// <term>The caller is requesting basic configuration information.</term>
	/// </item>
	/// <item>
	/// <term>FILTERED_LOG_CONF</term>
	/// <term>The caller is requesting filtered configuration information.</term>
	/// </item>
	/// <item>
	/// <term>ALLOC_LOG_CONF</term>
	/// <term>The caller is requesting allocated configuration information.</term>
	/// </item>
	/// <item>
	/// <term>BOOT_LOG_CONF</term>
	/// <term>The caller is requesting boot configuration information.</term>
	/// </item>
	/// <item>
	/// <term>FORCED_LOG_CONF</term>
	/// <term>The caller is requesting forced configuration information.</term>
	/// </item>
	/// <item>
	/// <term>OVERRIDE_LOG_CONF</term>
	/// <term>The caller is requesting override configuration information.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_First_Log_Conf</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario.
	/// To request information about the hardware resources on a local machine it is necessary implement an architecture-native version
	/// of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Calling CM_Add_Empty_Log_Conf or CM_Free_Log_Conf can invalidate the handle obtained from a previous call to
	/// <c>CM_Get_First_Log_Conf</c>. Thus if you want to obtain logical configurations after calling <c>CM_Add_Empty_Log_Conf</c> or
	/// <c>CM_Free_Log_Conf</c>, your code must call <c>CM_Get_First_Log_Conf</c> again and start at the first configuration.
	/// </para>
	/// <para>The handle received in plcLogConf must be explicitly freed by calling CM_Free_Log_Conf_Handle.</para>
	/// <para>
	/// If <c>CM_Get_First_Log_Conf</c> is called with plcLogConf set to <c>NULL</c>, no handle is returned. This allows you to use the
	/// return status to determine if a configuration exists without the need to subsequently free the handle.
	/// </para>
	/// <para>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_first_log_conf CMAPI CONFIGRET
	// CM_Get_First_Log_Conf( PLOG_CONF plcLogConf, DEVINST dnDevInst, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_First_Log_Conf")]
	public static extern CONFIGRET CM_Get_First_Log_Conf(out SafeLOG_CONF plcLogConf, uint dnDevInst, LOG_CONF_FLAG ulFlags);

	/// <summary>
	/// The <c>CM_Get_First_Log_Conf</c> function obtains the first logical configuration, of a specified configuration type, associated
	/// with a specified device instance on the local machine.
	/// </summary>
	/// <param name="plcLogConf">
	/// Address of a location to receive the handle to a logical configuration, or <c>NULL</c>. See the following <c>Remarks</c> section.
	/// </param>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
	/// <param name="ulFlags">
	/// <para>
	/// Caller-supplied flag value indicating the type of logical configuration being requested. One of the flags in the following table
	/// must be specified.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Configuration Type Flags</term>
	/// <term>Definitions</term>
	/// </listheader>
	/// <item>
	/// <term>BASIC_LOG_CONF</term>
	/// <term>The caller is requesting basic configuration information.</term>
	/// </item>
	/// <item>
	/// <term>FILTERED_LOG_CONF</term>
	/// <term>The caller is requesting filtered configuration information.</term>
	/// </item>
	/// <item>
	/// <term>ALLOC_LOG_CONF</term>
	/// <term>The caller is requesting allocated configuration information.</term>
	/// </item>
	/// <item>
	/// <term>BOOT_LOG_CONF</term>
	/// <term>The caller is requesting boot configuration information.</term>
	/// </item>
	/// <item>
	/// <term>FORCED_LOG_CONF</term>
	/// <term>The caller is requesting forced configuration information.</term>
	/// </item>
	/// <item>
	/// <term>OVERRIDE_LOG_CONF</term>
	/// <term>The caller is requesting override configuration information.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_First_Log_Conf</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario.
	/// To request information about the hardware resources on a local machine it is necessary implement an architecture-native version
	/// of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Calling CM_Add_Empty_Log_Conf or CM_Free_Log_Conf can invalidate the handle obtained from a previous call to
	/// <c>CM_Get_First_Log_Conf</c>. Thus if you want to obtain logical configurations after calling <c>CM_Add_Empty_Log_Conf</c> or
	/// <c>CM_Free_Log_Conf</c>, your code must call <c>CM_Get_First_Log_Conf</c> again and start at the first configuration.
	/// </para>
	/// <para>The handle received in plcLogConf must be explicitly freed by calling CM_Free_Log_Conf_Handle.</para>
	/// <para>
	/// If <c>CM_Get_First_Log_Conf</c> is called with plcLogConf set to <c>NULL</c>, no handle is returned. This allows you to use the
	/// return status to determine if a configuration exists without the need to subsequently free the handle.
	/// </para>
	/// <para>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_first_log_conf CMAPI CONFIGRET
	// CM_Get_First_Log_Conf( PLOG_CONF plcLogConf, DEVINST dnDevInst, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_First_Log_Conf")]
	public static extern CONFIGRET CM_Get_First_Log_Conf([In, Optional] IntPtr plcLogConf, uint dnDevInst, LOG_CONF_FLAG ulFlags);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_First_Log_Conf instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Get_First_Log_Conf_Ex</c> function obtains the first logical configuration associated with a specified device instance
	/// on a local or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="plcLogConf">
	/// Address of a location to receive the handle to a logical configuration, or <c>NULL</c>. See the <c>Remarks</c> section.
	/// </param>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the machine handle supplied by hMachine.</param>
	/// <param name="ulFlags">
	/// Caller-supplied flag value indicating the type of logical configuration being requested. For a list of flags, see the ulFlags
	/// description for CM_Get_First_Log_Conf.
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
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_First_Log_Conf_Ex</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64
	/// scenario. To request information about the hardware resources on a local machine it is necessary implement an
	/// architecture-native version of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Calling CM_Add_Empty_Log_Conf_Ex or CM_Free_Log_Conf_Ex can invalidate the handle obtained from a previous call to
	/// <c>CM_Get_First_Log_Conf_Ex</c>. Thus if you want to obtain logical configurations after calling <c>CM_Add_Empty_Log_Conf_Ex</c>
	/// or <c>CM_Free_Log_Conf_Ex</c>, your code must call <c>CM_Get_First_Log_Conf_Ex</c> again and start at the first configuration.
	/// </para>
	/// <para>The handle received in plcLogConf must be explicitly freed by calling CM_Free_Log_Conf_Handle.</para>
	/// <para>
	/// If <c>CM_Get_First_Log_Conf_Ex</c> is called with plcLogConf set to <c>NULL</c>, no handle is returned. This allows you to use
	/// the return status to determine if a configuration exists without the need to subsequently free the handle.
	/// </para>
	/// <para>For information about using device instance handles that are bound to a local or a remote machine, see CM_Get_Child_Ex.</para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_first_log_conf_ex CMAPI CONFIGRET
	// CM_Get_First_Log_Conf_Ex( PLOG_CONF plcLogConf, DEVINST dnDevInst, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_First_Log_Conf_Ex")]
	public static extern CONFIGRET CM_Get_First_Log_Conf_Ex(out SafeLOG_CONF plcLogConf, uint dnDevInst, LOG_CONF_FLAG ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_First_Log_Conf instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Get_First_Log_Conf_Ex</c> function obtains the first logical configuration associated with a specified device instance
	/// on a local or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="plcLogConf">
	/// Address of a location to receive the handle to a logical configuration, or <c>NULL</c>. See the <c>Remarks</c> section.
	/// </param>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the machine handle supplied by hMachine.</param>
	/// <param name="ulFlags">
	/// Caller-supplied flag value indicating the type of logical configuration being requested. For a list of flags, see the ulFlags
	/// description for CM_Get_First_Log_Conf.
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
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_First_Log_Conf_Ex</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64
	/// scenario. To request information about the hardware resources on a local machine it is necessary implement an
	/// architecture-native version of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Calling CM_Add_Empty_Log_Conf_Ex or CM_Free_Log_Conf_Ex can invalidate the handle obtained from a previous call to
	/// <c>CM_Get_First_Log_Conf_Ex</c>. Thus if you want to obtain logical configurations after calling <c>CM_Add_Empty_Log_Conf_Ex</c>
	/// or <c>CM_Free_Log_Conf_Ex</c>, your code must call <c>CM_Get_First_Log_Conf_Ex</c> again and start at the first configuration.
	/// </para>
	/// <para>The handle received in plcLogConf must be explicitly freed by calling CM_Free_Log_Conf_Handle.</para>
	/// <para>
	/// If <c>CM_Get_First_Log_Conf_Ex</c> is called with plcLogConf set to <c>NULL</c>, no handle is returned. This allows you to use
	/// the return status to determine if a configuration exists without the need to subsequently free the handle.
	/// </para>
	/// <para>For information about using device instance handles that are bound to a local or a remote machine, see CM_Get_Child_Ex.</para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_first_log_conf_ex CMAPI CONFIGRET
	// CM_Get_First_Log_Conf_Ex( PLOG_CONF plcLogConf, DEVINST dnDevInst, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_First_Log_Conf_Ex")]
	public static extern CONFIGRET CM_Get_First_Log_Conf_Ex([In, Optional] IntPtr plcLogConf, uint dnDevInst, LOG_CONF_FLAG ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated and should not be used.]</para>
	/// <para>
	/// The <c>CM_Get_HW_Prof_Flags</c> function retrieves the hardware profile-specific configuration flags for a device instance on a
	/// local machine.
	/// </para>
	/// </summary>
	/// <param name="pDeviceID">
	/// Pointer to a NULL-terminated string that contains the device instance ID of the device for which to retrieve hardware
	/// profile-specific configuration flags.
	/// </param>
	/// <param name="ulHardwareProfile">
	/// A variable of ULONG type that specifies the identifier of the hardware profile for which to retrieve configuration flags. If
	/// this parameter is zero, this function retrieves the configuration flags for the current hardware profile.
	/// </param>
	/// <param name="pulValue">
	/// <para>
	/// Pointer to a caller-supplied variable of ULONG type that receives zero or a bitwise OR of the following configuration flags that
	/// are defined in Regstr.h:
	/// </para>
	/// <para>CSCONFIGFLAG_BITS</para>
	/// <para>Bitwise OR of the other CSCONFIGFLAG_Xxx flags.</para>
	/// <para>CSCONFIGFLAG_DISABLE</para>
	/// <para>The device instance is disabled in the specified hardware profile.</para>
	/// <para>CSCONFIGFLAG_DO_NOT_CREATE</para>
	/// <para>The hardware profile does not support the specified device instance.</para>
	/// <para>CSCONFIGFLAG_DO_NOT_START</para>
	/// <para>The device cannot be started in the specified hardware profile.</para>
	/// </param>
	/// <param name="ulFlags">Reserved for internal use. Must be set to zero.</param>
	/// <returns>
	/// If the operation succeeds, <c>CM_Get_HW_Prof_Flags</c> returns CR_SUCCESS. Otherwise, the function returns one of the CR_Xxx
	/// error codes that are defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>To retrieve a list of hardware profile IDs that are currently defined on a local machine, call SetupDiGetHwProfileList.</para>
	/// <para>To retrieve configuration flags for a device instance on a remote machine, call CM_Get_HW_Prof_Flags_Ex.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The cfgmgr32.h header defines CM_Get_HW_Prof_Flags as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_hw_prof_flagsa CMAPI CONFIGRET
	// CM_Get_HW_Prof_FlagsA( DEVINSTID_A pDeviceID, ULONG ulHardwareProfile, PULONG pulValue, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_HW_Prof_FlagsA")]
	public static extern CONFIGRET CM_Get_HW_Prof_Flags([MarshalAs(UnmanagedType.LPTStr)] string pDeviceID, uint ulHardwareProfile, out CSCONFIGFLAG pulValue, uint ulFlags = 0);

	/// <summary>
	/// <para>[This function has been deprecated and should not be used.]</para>
	/// <para>
	/// The <c>CM_Get_HW_Prof_Flags_Ex</c> function retrieves the hardware profile-specific configuration flags for a device instance on
	/// a remote machine or a local machine.
	/// </para>
	/// </summary>
	/// <param name="pDeviceID">
	/// Pointer to a NULL-terminated string that contains the device instance ID of the device for which to retrieve hardware
	/// profile-specific configuration flags.
	/// </param>
	/// <param name="ulHardwareProfile">
	/// A variable of ULONG type that specifies the identifier of the hardware profile for which to retrieve configuration flags. If
	/// this parameter is zero, this function retrieves the configuration flags for the current hardware profile.
	/// </param>
	/// <param name="pulValue">
	/// <para>
	/// Pointer to a caller-supplied variable of ULONG type that receives zero or a bitwise OR of the following configuration flags that
	/// are defined in Regstr.h:
	/// </para>
	/// <para>CSCONFIGFLAG_BITS</para>
	/// <para>Bitwise OR of the other CSCONFIGFLAG_Xxx flags.</para>
	/// <para>CSCONFIGFLAG_DISABLE</para>
	/// <para>The device instance is disabled in the specified hardware profile.</para>
	/// <para>CSCONFIGFLAG_DO_NOT_CREATE</para>
	/// <para>The hardware profile does not support the specified device instance.</para>
	/// <para>CSCONFIGFLAG_DO_NOT_START</para>
	/// <para>The device cannot be started in the specified hardware profile.</para>
	/// </param>
	/// <param name="ulFlags">Reserved for internal use. Must be set to zero.</param>
	/// <param name="hMachine">
	/// <para>
	/// A machine handle that is returned by call to CM_Connect_Machine or <c>NULL</c>. If this parameter is set to <c>NULL</c>,
	/// <c>CM_Get_HW_Prof_Flags_Ex</c> retrieves the configuration flags on the local machine.
	/// </para>
	/// <para>
	/// <c>Note</c> Using this function to access remote machines is not supported beginning with Windows 8 and Windows Server 2012, as
	/// this functionality has been removed.
	/// </para>
	/// </param>
	/// <returns>
	/// If the operation succeeds, <c>CM_Get_HW_Prof_Flags</c> returns CR_SUCCESS. Otherwise, the function returns one of the
	/// CR_-prefixed error codes that are defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>To retrieve a list of the hardware profile IDs that are currently defined on a remote machine, call SetupDiGetHwProfileListEx.</para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The cfgmgr32.h header defines CM_Get_HW_Prof_Flags_Ex as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_hw_prof_flags_exa CMAPI CONFIGRET
	// CM_Get_HW_Prof_Flags_ExA( DEVINSTID_A pDeviceID, ULONG ulHardwareProfile, PULONG pulValue, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_HW_Prof_Flags_ExA")]
	public static extern CONFIGRET CM_Get_HW_Prof_Flags_Ex([MarshalAs(UnmanagedType.LPTStr)] string pDeviceID, uint ulHardwareProfile, out CSCONFIGFLAG pulValue,
		[In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Get_Log_Conf_List</c> function obtains the logical configurations, of a specified configuration type, associated with
	/// a specified device instance on the local machine.
	/// </summary>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
	/// <param name="ulFlags">
	/// <para>
	/// Caller-supplied flag value indicating the type of logical configuration being requested. One of the flags in the following table
	/// must be specified.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Configuration Type Flags</term>
	/// <term>Definitions</term>
	/// </listheader>
	/// <item>
	/// <term>BASIC_LOG_CONF</term>
	/// <term>The caller is requesting basic configuration information.</term>
	/// </item>
	/// <item>
	/// <term>FILTERED_LOG_CONF</term>
	/// <term>The caller is requesting filtered configuration information.</term>
	/// </item>
	/// <item>
	/// <term>ALLOC_LOG_CONF</term>
	/// <term>The caller is requesting allocated configuration information.</term>
	/// </item>
	/// <item>
	/// <term>BOOT_LOG_CONF</term>
	/// <term>The caller is requesting boot configuration information.</term>
	/// </item>
	/// <item>
	/// <term>FORCED_LOG_CONF</term>
	/// <term>The caller is requesting forced configuration information.</term>
	/// </item>
	/// <item>
	/// <term>OVERRIDE_LOG_CONF</term>
	/// <term>The caller is requesting override configuration information.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>A sequence of safe handles to a logical configurations.</para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_First_Log_Conf</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario.
	/// To request information about the hardware resources on a local machine it is necessary implement an architecture-native version
	/// of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_First_Log_Conf")]
	public static IEnumerable<SafeLOG_CONF> CM_Get_Log_Conf_List(uint dnDevInst, LOG_CONF_FLAG ulFlags)
	{
		CONFIGRET ret = CM_Get_First_Log_Conf(out var lc, dnDevInst, ulFlags);
		if (ret == CONFIGRET.CR_NO_MORE_LOG_CONF)
			yield break;
		ret.ThrowIfFailed();
		yield return lc;
		while ((ret = CM_Get_Next_Log_Conf(out lc, lc)) == CONFIGRET.CR_SUCCESS)
			yield return lc;
		if (ret != CONFIGRET.CR_NO_MORE_LOG_CONF) ret.ThrowIfFailed();
	}

	/// <summary>
	/// The <c>CM_Get_Log_Conf_Priority</c> function obtains the configuration priority of a specified logical configuration on the
	/// local machine.
	/// </summary>
	/// <param name="lcLogConf">
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
	/// <param name="pPriority">
	/// Caller-supplied address of a location to receive a configuration priority value. For a list of priority values, see the
	/// description of Priority for CM_Add_Empty_Log_Conf.
	/// </param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <returns>
	/// <para>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Log_Conf_Priority</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64
	/// scenario. To request information about the hardware resources on a local machine it is necessary implement an
	/// architecture-native version of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_log_conf_priority CMAPI CONFIGRET
	// CM_Get_Log_Conf_Priority( LOG_CONF lcLogConf, PPRIORITY pPriority, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Log_Conf_Priority")]
	public static extern CONFIGRET CM_Get_Log_Conf_Priority(LOG_CONF lcLogConf, out PRIORITY pPriority, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Log_Conf_Priority instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Get_Log_Conf_Priority_Ex</c> function obtains the configuration priority of a specified logical configuration on a
	/// local or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="lcLogConf">
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
	/// <param name="pPriority">
	/// Caller-supplied address of a location to receive a configuration priority value. For a list of priority values, see the
	/// description of Priority for CM_Add_Empty_Log_Conf_Ex.
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
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Log_Conf_Priority_Ex</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64
	/// scenario. To request information about the hardware resources on a local machine it is necessary implement an
	/// architecture-native version of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_log_conf_priority_ex CMAPI CONFIGRET
	// CM_Get_Log_Conf_Priority_Ex( LOG_CONF lcLogConf, PPRIORITY pPriority, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Log_Conf_Priority_Ex")]
	public static extern CONFIGRET CM_Get_Log_Conf_Priority_Ex(LOG_CONF lcLogConf, out PRIORITY pPriority, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Get_Next_Log_Conf</c> function obtains the next logical configuration associated with a specific device instance on
	/// the local machine.
	/// </summary>
	/// <param name="plcLogConf">
	/// Address of a location to receive the handle to a logical configuration, or <c>NULL</c>. (See the following <c>Remarks</c> section.
	/// </param>
	/// <param name="lcLogConf">
	/// <para>
	/// Caller-supplied handle to a logical configuration. This handle must have been previously obtained by calling one of the
	/// following functions:
	/// </para>
	/// <para>CM_Get_First_Log_Conf</para>
	/// <para><c>CM_Get_Next_Log_Conf</c></para>
	/// </param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <returns>
	/// <para>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Next_Log_Conf</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario.
	/// To request information about the hardware resources on a local machine it is necessary implement an architecture-native version
	/// of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate the logical configurations associated with a device instance, call CM_Get_First_Log_Conf to obtain the first
	/// logical configuration of a specified configuration type, then call <c>CM_Get_Next_Log_Conf</c> repeatedly until it returns CR_NO_MORE_LOG_CONF.
	/// </para>
	/// <para>
	/// Calling CM_Add_Empty_Log_Conf or CM_Free_Log_Conf can invalidate the handle obtained from a previous call to
	/// <c>CM_Get_Next_Log_Conf</c>. Thus if you want to obtain logical configurations after calling <c>CM_Add_Empty_Log_Conf</c> or
	/// <c>CM_Free_Log_Conf</c>, your code must call <c>CM_Get_First_Log_Conf</c> again and start at the first configuration.
	/// </para>
	/// <para>The handle received in plcLogConf must be explicitly freed by calling CM_Free_Log_Conf_Handle.</para>
	/// <para>
	/// If <c>CM_Get_Next_Log_Conf</c> is called with plcLogConf set to <c>NULL</c>, no handle is returned. This allows you to use the
	/// return status to determine if a configuration exists without the need to subsequently free the handle.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_next_log_conf CMAPI CONFIGRET
	// CM_Get_Next_Log_Conf( PLOG_CONF plcLogConf, LOG_CONF lcLogConf, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Next_Log_Conf")]
	public static extern CONFIGRET CM_Get_Next_Log_Conf(out SafeLOG_CONF plcLogConf, LOG_CONF lcLogConf, uint ulFlags = 0);

	/// <summary>
	/// The <c>CM_Get_Next_Log_Conf</c> function obtains the next logical configuration associated with a specific device instance on
	/// the local machine.
	/// </summary>
	/// <param name="plcLogConf">
	/// Address of a location to receive the handle to a logical configuration, or <c>NULL</c>. (See the following <c>Remarks</c> section.
	/// </param>
	/// <param name="lcLogConf">
	/// <para>
	/// Caller-supplied handle to a logical configuration. This handle must have been previously obtained by calling one of the
	/// following functions:
	/// </para>
	/// <para>CM_Get_First_Log_Conf</para>
	/// <para><c>CM_Get_Next_Log_Conf</c></para>
	/// </param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <returns>
	/// <para>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Next_Log_Conf</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario.
	/// To request information about the hardware resources on a local machine it is necessary implement an architecture-native version
	/// of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate the logical configurations associated with a device instance, call CM_Get_First_Log_Conf to obtain the first
	/// logical configuration of a specified configuration type, then call <c>CM_Get_Next_Log_Conf</c> repeatedly until it returns CR_NO_MORE_LOG_CONF.
	/// </para>
	/// <para>
	/// Calling CM_Add_Empty_Log_Conf or CM_Free_Log_Conf can invalidate the handle obtained from a previous call to
	/// <c>CM_Get_Next_Log_Conf</c>. Thus if you want to obtain logical configurations after calling <c>CM_Add_Empty_Log_Conf</c> or
	/// <c>CM_Free_Log_Conf</c>, your code must call <c>CM_Get_First_Log_Conf</c> again and start at the first configuration.
	/// </para>
	/// <para>The handle received in plcLogConf must be explicitly freed by calling CM_Free_Log_Conf_Handle.</para>
	/// <para>
	/// If <c>CM_Get_Next_Log_Conf</c> is called with plcLogConf set to <c>NULL</c>, no handle is returned. This allows you to use the
	/// return status to determine if a configuration exists without the need to subsequently free the handle.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_next_log_conf CMAPI CONFIGRET
	// CM_Get_Next_Log_Conf( PLOG_CONF plcLogConf, LOG_CONF lcLogConf, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Next_Log_Conf")]
	public static extern CONFIGRET CM_Get_Next_Log_Conf([In, Optional] IntPtr plcLogConf, LOG_CONF lcLogConf, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Next_Log_Conf instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Get_Next_Log_Conf_Ex</c> function obtains the next logical configuration associated with a specific device instance on
	/// a local or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="plcLogConf">
	/// Address of a location to receive the handle to a logical configuration, or <c>NULL</c>. (See the following <c>Remarks</c> section.
	/// </param>
	/// <param name="lcLogConf">
	/// <para>
	/// Caller-supplied handle to a logical configuration. This handle must have been previously obtained by calling one of the
	/// following functions:
	/// </para>
	/// <para>CM_Get_First_Log_Conf_Ex</para>
	/// <para><c>CM_Get_Next_Log_Conf_Ex</c></para>
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
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Next_Log_Conf_Ex</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64
	/// scenario. To request information about the hardware resources on a local machine it is necessary implement an
	/// architecture-native version of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate the logical configurations associated with a device instance, call CM_Get_First_Log_Conf_Ex to obtain the first
	/// logical configuration, then call <c>CM_Get_Next_Log_Conf_Ex</c> repeatedly until it returns CR_NO_MORE_LOG_CONF.
	/// </para>
	/// <para>
	/// Calling CM_Add_Empty_Log_Conf_Ex or CM_Free_Log_Conf_Ex can invalidate the handle obtained from a previous call to
	/// <c>CM_Get_Next_Log_Conf_Ex</c>. Thus if you want to obtain logical configurations after calling <c>CM_Add_Empty_Log_Conf_Ex</c>
	/// or <c>CM_Free_Log_Conf_Ex</c>, your code must call <c>CM_Get_First_Log_Conf_Ex</c> again and start at the first configuration.
	/// </para>
	/// <para>The handle received in plcLogConf must be explicitly freed by calling CM_Free_Log_Conf_Handle.</para>
	/// <para>
	/// If <c>CM_Get_Next_Log_Conf_Ex</c> is called with plcLogConf set to <c>NULL</c>, no handle is returned. This allows you to use
	/// the return status to determine if a configuration exists without the need to subsequently free the handle.
	/// </para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_next_log_conf_ex CMAPI CONFIGRET
	// CM_Get_Next_Log_Conf_Ex( PLOG_CONF plcLogConf, LOG_CONF lcLogConf, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Next_Log_Conf_Ex")]
	public static extern CONFIGRET CM_Get_Next_Log_Conf_Ex(out SafeLOG_CONF plcLogConf, LOG_CONF lcLogConf, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Next_Log_Conf instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Get_Next_Log_Conf_Ex</c> function obtains the next logical configuration associated with a specific device instance on
	/// a local or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="plcLogConf">
	/// Address of a location to receive the handle to a logical configuration, or <c>NULL</c>. (See the following <c>Remarks</c> section.
	/// </param>
	/// <param name="lcLogConf">
	/// <para>
	/// Caller-supplied handle to a logical configuration. This handle must have been previously obtained by calling one of the
	/// following functions:
	/// </para>
	/// <para>CM_Get_First_Log_Conf_Ex</para>
	/// <para><c>CM_Get_Next_Log_Conf_Ex</c></para>
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
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Next_Log_Conf_Ex</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64
	/// scenario. To request information about the hardware resources on a local machine it is necessary implement an
	/// architecture-native version of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate the logical configurations associated with a device instance, call CM_Get_First_Log_Conf_Ex to obtain the first
	/// logical configuration, then call <c>CM_Get_Next_Log_Conf_Ex</c> repeatedly until it returns CR_NO_MORE_LOG_CONF.
	/// </para>
	/// <para>
	/// Calling CM_Add_Empty_Log_Conf_Ex or CM_Free_Log_Conf_Ex can invalidate the handle obtained from a previous call to
	/// <c>CM_Get_Next_Log_Conf_Ex</c>. Thus if you want to obtain logical configurations after calling <c>CM_Add_Empty_Log_Conf_Ex</c>
	/// or <c>CM_Free_Log_Conf_Ex</c>, your code must call <c>CM_Get_First_Log_Conf_Ex</c> again and start at the first configuration.
	/// </para>
	/// <para>The handle received in plcLogConf must be explicitly freed by calling CM_Free_Log_Conf_Handle.</para>
	/// <para>
	/// If <c>CM_Get_Next_Log_Conf_Ex</c> is called with plcLogConf set to <c>NULL</c>, no handle is returned. This allows you to use
	/// the return status to determine if a configuration exists without the need to subsequently free the handle.
	/// </para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_next_log_conf_ex CMAPI CONFIGRET
	// CM_Get_Next_Log_Conf_Ex( PLOG_CONF plcLogConf, LOG_CONF lcLogConf, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Next_Log_Conf_Ex")]
	public static extern CONFIGRET CM_Get_Next_Log_Conf_Ex([In, Optional] IntPtr plcLogConf, LOG_CONF lcLogConf, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Get_Next_Res_Des</c> function obtains a handle to the next resource descriptor, of a specified resource type, for a
	/// logical configuration on the local machine.
	/// </summary>
	/// <param name="prdResDes">Pointer to a location to receive a resource descriptor handle.</param>
	/// <param name="rdResDes">
	/// Caller-supplied handle to either a resource descriptor or a logical configuration. For more information, see the following
	/// <c>Remarks</c> section.
	/// </param>
	/// <param name="ForResource">
	/// Caller-supplied resource type identifier, indicating the type of resource descriptor being requested. This must be one of the
	/// <c>ResType_</c>-prefixed constants defined in Cfgmgr32.h.
	/// </param>
	/// <param name="pResourceID">
	/// Pointer to a location to receive a resource type identifier, if ForResource specifies <c>ResType_All</c>. For any other
	/// ForResource value, callers should set this to <c>NULL</c>.
	/// </param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <returns>
	/// <para>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Next_Res_Des</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario.
	/// To request information about the hardware resources on a local machine it is necessary implement an architecture-native version
	/// of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate a logical configuration's resource descriptors, begin by calling <c>CM_Get_Next_Res_Des</c> with the logical
	/// configuration's handle as the argument for rdResDes. This obtains a handle to the first resource descriptor of the type
	/// specified by ForResource. Then for each subsequent call to <c>CM_Get_Next_Res_Des</c>, specify the most recently obtained
	/// descriptor handle as the argument for rdResDes. Repeat until the function returns CR_NO_MORE_RES_DES.
	/// </para>
	/// <para>To retrieve the information stored in a resource descriptor, call CM_Get_Res_Des_Data.</para>
	/// <para>To modify the information stored in a resource descriptor, call CM_Modify_Res_Des.</para>
	/// <para>
	/// Callers of <c>CM_Get_Next_Res_Des</c> must call CM_Free_Res_Des_Handle to deallocate the resource descriptor handle, after it is
	/// no longer needed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_next_res_des CMAPI CONFIGRET CM_Get_Next_Res_Des(
	// PRES_DES prdResDes, RES_DES rdResDes, RESOURCEID ForResource, PRESOURCEID pResourceID, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Next_Res_Des")]
	public static extern CONFIGRET CM_Get_Next_Res_Des(out SafeRES_DES prdResDes, RES_DES rdResDes, RESOURCEID ForResource, out RESOURCEID pResourceID, uint ulFlags = 0);

	/// <summary>
	/// The <c>CM_Get_Next_Res_Des</c> function obtains a handle to the next resource descriptor, of a specified resource type, for a
	/// logical configuration on the local machine.
	/// </summary>
	/// <param name="prdResDes">Pointer to a location to receive a resource descriptor handle.</param>
	/// <param name="rdResDes">
	/// Caller-supplied handle to either a resource descriptor or a logical configuration. For more information, see the following
	/// <c>Remarks</c> section.
	/// </param>
	/// <param name="ForResource">
	/// Caller-supplied resource type identifier, indicating the type of resource descriptor being requested. This must be one of the
	/// <c>ResType_</c>-prefixed constants defined in Cfgmgr32.h.
	/// </param>
	/// <param name="pResourceID">
	/// Pointer to a location to receive a resource type identifier, if ForResource specifies <c>ResType_All</c>. For any other
	/// ForResource value, callers should set this to <c>NULL</c>.
	/// </param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <returns>
	/// <para>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Next_Res_Des</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario.
	/// To request information about the hardware resources on a local machine it is necessary implement an architecture-native version
	/// of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate a logical configuration's resource descriptors, begin by calling <c>CM_Get_Next_Res_Des</c> with the logical
	/// configuration's handle as the argument for rdResDes. This obtains a handle to the first resource descriptor of the type
	/// specified by ForResource. Then for each subsequent call to <c>CM_Get_Next_Res_Des</c>, specify the most recently obtained
	/// descriptor handle as the argument for rdResDes. Repeat until the function returns CR_NO_MORE_RES_DES.
	/// </para>
	/// <para>To retrieve the information stored in a resource descriptor, call CM_Get_Res_Des_Data.</para>
	/// <para>To modify the information stored in a resource descriptor, call CM_Modify_Res_Des.</para>
	/// <para>
	/// Callers of <c>CM_Get_Next_Res_Des</c> must call CM_Free_Res_Des_Handle to deallocate the resource descriptor handle, after it is
	/// no longer needed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_next_res_des CMAPI CONFIGRET CM_Get_Next_Res_Des(
	// PRES_DES prdResDes, RES_DES rdResDes, RESOURCEID ForResource, PRESOURCEID pResourceID, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Next_Res_Des")]
	public static extern CONFIGRET CM_Get_Next_Res_Des(out SafeRES_DES prdResDes, LOG_CONF rdResDes, RESOURCEID ForResource, out RESOURCEID pResourceID, uint ulFlags = 0);

	/// <summary>
	/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Next_Res_Des instead.]</para>
	/// <para>
	/// The <c>CM_Get_Next_Res_Des_Ex</c> function obtains a handle to the next resource descriptor, of a specified resource type, for a
	/// logical configuration on a local or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="prdResDes">Pointer to a location to receive a resource descriptor handle.</param>
	/// <param name="rdResDes">
	/// Caller-supplied handle to either a resource descriptor or a logical configuration. For more information, see the following
	/// <c>Remarks</c> section.
	/// </param>
	/// <param name="ForResource">
	/// Caller-supplied resource type identifier, indicating the type of resource descriptor being requested. This must be one of the
	/// ResType_-prefixed constants defined in Cfgmgr32.h.
	/// </param>
	/// <param name="pResourceID">
	/// Pointer to a location to receive a resource type identifier, if ForResource specifies <c>ResType_All</c>. For any other
	/// ForResource value, callers should set this to <c>NULL</c>.
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
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Next_Res_Des_Ex</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64
	/// scenario. To request information about the hardware resources on a local machine it is necessary implement an
	/// architecture-native version of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate a logical configuration's resource descriptors, begin by calling <c>CM_Get_Next_Res_Des_Ex</c> with the logical
	/// configuration's handle as the argument for rdResDes. This obtains a handle to the first resource descriptor of the type
	/// specified by ForResource. Then for each subsequent call to <c>CM_Get_Next_Res_Des_Ex</c>, specify the most recently obtained
	/// descriptor handle as the argument for rdResDes. Repeat until the function returns CR_NO_MORE_RES_DES.
	/// </para>
	/// <para>To retrieve the information stored in a resource descriptor, call CM_Get_Res_Des_Data_Ex.</para>
	/// <para>To modify the information stored in a resource descriptor, call CM_Modify_Res_Des_Ex.</para>
	/// <para>
	/// Callers of <c>CM_Get_Next_Res_Des_Ex</c> must call CM_Free_Res_Des_Handle to deallocate the resource descriptor handle, after it
	/// is no longer needed.
	/// </para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_next_res_des_ex CMAPI CONFIGRET
	// CM_Get_Next_Res_Des_Ex( PRES_DES prdResDes, RES_DES rdResDes, RESOURCEID ForResource, PRESOURCEID pResourceID, ULONG ulFlags,
	// HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Next_Res_Des_Ex")]
	public static extern CONFIGRET CM_Get_Next_Res_Des_Ex(out SafeRES_DES prdResDes, RES_DES rdResDes, RESOURCEID ForResource, out RESOURCEID pResourceID, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Next_Res_Des instead.]</para>
	/// <para>
	/// The <c>CM_Get_Next_Res_Des_Ex</c> function obtains a handle to the next resource descriptor, of a specified resource type, for a
	/// logical configuration on a local or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="prdResDes">Pointer to a location to receive a resource descriptor handle.</param>
	/// <param name="rdResDes">
	/// Caller-supplied handle to either a resource descriptor or a logical configuration. For more information, see the following
	/// <c>Remarks</c> section.
	/// </param>
	/// <param name="ForResource">
	/// Caller-supplied resource type identifier, indicating the type of resource descriptor being requested. This must be one of the
	/// ResType_-prefixed constants defined in Cfgmgr32.h.
	/// </param>
	/// <param name="pResourceID">
	/// Pointer to a location to receive a resource type identifier, if ForResource specifies <c>ResType_All</c>. For any other
	/// ForResource value, callers should set this to <c>NULL</c>.
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
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Next_Res_Des_Ex</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64
	/// scenario. To request information about the hardware resources on a local machine it is necessary implement an
	/// architecture-native version of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate a logical configuration's resource descriptors, begin by calling <c>CM_Get_Next_Res_Des_Ex</c> with the logical
	/// configuration's handle as the argument for rdResDes. This obtains a handle to the first resource descriptor of the type
	/// specified by ForResource. Then for each subsequent call to <c>CM_Get_Next_Res_Des_Ex</c>, specify the most recently obtained
	/// descriptor handle as the argument for rdResDes. Repeat until the function returns CR_NO_MORE_RES_DES.
	/// </para>
	/// <para>To retrieve the information stored in a resource descriptor, call CM_Get_Res_Des_Data_Ex.</para>
	/// <para>To modify the information stored in a resource descriptor, call CM_Modify_Res_Des_Ex.</para>
	/// <para>
	/// Callers of <c>CM_Get_Next_Res_Des_Ex</c> must call CM_Free_Res_Des_Handle to deallocate the resource descriptor handle, after it
	/// is no longer needed.
	/// </para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_next_res_des_ex CMAPI CONFIGRET
	// CM_Get_Next_Res_Des_Ex( PRES_DES prdResDes, RES_DES rdResDes, RESOURCEID ForResource, PRESOURCEID pResourceID, ULONG ulFlags,
	// HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Next_Res_Des_Ex")]
	public static extern CONFIGRET CM_Get_Next_Res_Des_Ex(out SafeRES_DES prdResDes, LOG_CONF rdResDes, RESOURCEID ForResource, out RESOURCEID pResourceID, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Parent instead.]</para>
	/// <para>
	/// The <c>CM_Get_Parent_Ex</c> function obtains a device instance handle to the parent node of a specified device node (devnode) in
	/// a local or a remote machine's device tree.
	/// </para>
	/// </summary>
	/// <param name="pdnDevInst">
	/// Caller-supplied pointer to the device instance handle to the parent node that this function retrieves. The retrieved handle is
	/// bound to the machine handle specified by hMachine.
	/// </param>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the machine handle specified by hMachine.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_parent_ex CMAPI CONFIGRET CM_Get_Parent_Ex(
	// PDEVINST pdnDevInst, DEVINST dnDevInst, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Parent_Ex")]
	public static extern CONFIGRET CM_Get_Parent_Ex(out uint pdnDevInst, uint dnDevInst, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>The <c>CM_Get_Res_Des_Data</c> function retrieves the information stored in a resource descriptor on the local machine.</summary>
	/// <param name="rdResDes">Caller-supplied handle to a resource descriptor, obtained by a previous call to CM_Get_Next_Res_Des.</param>
	/// <param name="Buffer">
	/// Address of a buffer to receive the contents of a resource descriptor. The required buffer size should be obtained by calling CM_Get_Res_Des_Data_Size.
	/// </param>
	/// <param name="BufferLen">Caller-supplied length of the buffer specified by Buffer.</param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <returns>
	/// <para>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Res_Des_Data</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario.
	/// To request information about the hardware resources on a local machine it is necessary implement an architecture-native version
	/// of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// Information returned in the buffer supplied by Buffer will be formatted as one of the resource type structures listed in the
	/// description of CM_Add_Res_Des, based on the resource type that was specified when CM_Get_Next_Res_Des was called to obtain the
	/// resource descriptor handle.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_res_des_data CMAPI CONFIGRET CM_Get_Res_Des_Data(
	// RES_DES rdResDes, PVOID Buffer, ULONG BufferLen, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Res_Des_Data")]
	public static extern CONFIGRET CM_Get_Res_Des_Data(RES_DES rdResDes, [Out] IntPtr Buffer, uint BufferLen, uint ulFlags = 0);

	/// <summary>
	/// The <c>CM_Get_Res_Des_Data</c> function retrieves the information stored in a resource descriptor on the local machine.
	/// </summary>
	/// <typeparam name="T">The type of the data to retrieve.</typeparam>
	/// <param name="rdResDes">Caller-supplied handle to a resource descriptor, obtained by a previous call to CM_Get_Next_Res_Des.</param>
	/// <returns>
	/// <para>
	/// Returns the structure specified in as the contents of the resource descriptor.
	/// </para>
	/// <para>
	///   <c>Note</c> Starting with Windows 8, <c>CM_Get_Res_Des_Data</c> throws CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario.
	/// To request information about the hardware resources on a local machine it is necessary implement an architecture-native version
	/// of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Res_Des_Data")]
	public static T CM_Get_Res_Des_Data<T>(RES_DES rdResDes) where T : struct
	{
		CM_Get_Res_Des_Data_Size(out var size, rdResDes).ThrowIfFailed();
		using var mem = new SafeCoTaskMemHandle(size);
		CM_Get_Res_Des_Data(rdResDes, mem, size).ThrowIfFailed();
		return mem.ToStructure<T>();
	}

	/// <summary>
	/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Res_Des_Data instead.]</para>
	/// <para>
	/// The <c>CM_Get_Res_Des_Data_Ex</c> function retrieves the information stored in a resource descriptor on a local or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="rdResDes">Caller-supplied handle to a resource descriptor, obtained by a previous call to CM_Get_Next_Res_Des_Ex.</param>
	/// <param name="Buffer">
	/// Address of a buffer to receive the contents of a resource descriptor. The required buffer size should be obtained by calling CM_Get_Res_Des_Data_Size_Ex.
	/// </param>
	/// <param name="BufferLen">Caller-supplied length of the buffer specified by Buffer.</param>
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
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Res_Des_Data_Ex</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64
	/// scenario. To request information about the hardware resources on a local machine it is necessary implement an
	/// architecture-native version of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Information returned in the buffer supplied by Buffer will be formatted as one of the resource type structures listed in the
	/// description of CM_Add_Res_Des_Ex, based on the resource type that was specified when CM_Get_Next_Res_Des_Ex was called to obtain
	/// the resource descriptor handle.
	/// </para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_res_des_data_ex CMAPI CONFIGRET
	// CM_Get_Res_Des_Data_Ex( RES_DES rdResDes, PVOID Buffer, ULONG BufferLen, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Res_Des_Data_Ex")]
	public static extern CONFIGRET CM_Get_Res_Des_Data_Ex(RES_DES rdResDes, [Out] IntPtr Buffer, uint BufferLen, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Get_Res_Des_Data_Size</c> function obtains the buffer size required to hold the information contained in a specified
	/// resource descriptor on the local machine.
	/// </summary>
	/// <param name="pulSize">Caller-supplied address of a location to receive the required buffer size.</param>
	/// <param name="rdResDes">Caller-supplied handle to a resource descriptor, obtained by a previous call to CM_Get_Next_Res_Des.</param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <returns>
	/// <para>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Res_Des_Data_Size</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64
	/// scenario. To request information about the hardware resources on a local machine it is necessary implement an
	/// architecture-native version of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// The returned size value represents the size of the appropriate resource structure (see CM_Add_Res_Des). If the resource
	/// descriptor resides in a resource requirements list, the returned size includes both the size of the resource structure and the
	/// space allocated for associated range arrays.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_res_des_data_size CMAPI CONFIGRET
	// CM_Get_Res_Des_Data_Size( PULONG pulSize, RES_DES rdResDes, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Res_Des_Data_Size")]
	public static extern CONFIGRET CM_Get_Res_Des_Data_Size(out uint pulSize, RES_DES rdResDes, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Res_Des_Data_Size instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Get_Res_Des_Data_Size_Ex</c> function obtains the buffer size required to hold the information contained in a
	/// specified resource descriptor on a local or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="pulSize">Caller-supplied address of a location to receive the required buffer size.</param>
	/// <param name="rdResDes">Caller-supplied handle to a resource descriptor, obtained by a previous call to CM_Get_Next_Res_Des_Ex.</param>
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
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Res_Des_Data_Size_Ex</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64
	/// scenario. To request information about the hardware resources on a local machine it is necessary implement an
	/// architecture-native version of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The returned size value represents the size of the appropriate resource structure (see CM_Add_Res_Des_Ex). If the resource
	/// descriptor resides in a resource requirements list, the returned size includes both the size of the resource structure and the
	/// space allocated for associated range arrays.
	/// </para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_res_des_data_size_ex CMAPI CONFIGRET
	// CM_Get_Res_Des_Data_Size_Ex( PULONG pulSize, RES_DES rdResDes, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Res_Des_Data_Size_Ex")]
	public static extern CONFIGRET CM_Get_Res_Des_Data_Size_Ex(out uint pulSize, RES_DES rdResDes, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Get_Next_Res_Des</c> function obtains a handle to the next resource descriptor, of a specified resource type, for a
	/// logical configuration on the local machine.
	/// </summary>
	/// <param name="lcLogConf">Handle to a logical configuration.</param>
	/// <param name="ForResource">
	/// Caller-supplied resource type identifier, indicating the type of resource descriptor being requested. This must be one of the
	/// <c>ResType_</c>-prefixed constants defined in Cfgmgr32.h.
	/// </param>
	/// <returns>A sequence of resource descriptor handles and their associated resource type identifiers.</returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Get_Next_Res_Des</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario.
	/// To request information about the hardware resources on a local machine it is necessary implement an architecture-native version
	/// of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// <para>To retrieve the information stored in a resource descriptor, call CM_Get_Res_Des_Data.</para>
	/// <para>To modify the information stored in a resource descriptor, call CM_Modify_Res_Des.</para>
	/// </remarks>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Next_Res_Des")]
	public static IEnumerable<(SafeRES_DES prdResDes, RESOURCEID pResourceID)> CM_Get_Res_Des_List([In] LOG_CONF lcLogConf, RESOURCEID ForResource = RESOURCEID.ResType_All)
	{
		CONFIGRET ret = CM_Get_Next_Res_Des(out var rd, lcLogConf, ForResource, out var resId);
		if (ret == CONFIGRET.CR_NO_MORE_RES_DES)
			yield break;
		ret.ThrowIfFailed();
		yield return (rd, resId);
		while ((ret = CM_Get_Next_Res_Des(out rd, rd, ForResource, out resId)) == CONFIGRET.CR_SUCCESS)
			yield return (rd, resId);
		if (ret != CONFIGRET.CR_NO_MORE_RES_DES) ret.ThrowIfFailed();
	}

	/// <summary>
	/// The <c>CM_Get_Resource_Conflict_Count</c> function obtains the number of conflicts contained in a specified resource conflict list.
	/// </summary>
	/// <param name="clConflictList">Caller-supplied handle to a conflict list, obtained by a previous call to CM_Query_Resource_Conflict_List.</param>
	/// <param name="pulCount">Caller-supplied address of a location to receive the conflict count.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The count value obtained by calling <c>CM_Get_Resource_Conflict_Count</c> can be used to determine the number of times to call
	/// CM_Get_Resource_Conflict_Details, which supplies information about each conflict.
	/// </para>
	/// <para>If there are no entries in the conflict list, the location supplied by pulCount will receive zero.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_resource_conflict_count CMAPI CONFIGRET
	// CM_Get_Resource_Conflict_Count( CONFLICT_LIST clConflictList, PULONG pulCount );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Resource_Conflict_Count")]
	public static extern CONFIGRET CM_Get_Resource_Conflict_Count(CONFLICT_LIST clConflictList, out uint pulCount);

	/// <summary>
	/// The <c>CM_Get_Resource_Conflict_Details</c> function obtains the details about one of the resource conflicts in a conflict list.
	/// </summary>
	/// <param name="clConflictList">Caller-supplied handle to a conflict list, obtained by a previous call to CM_Query_Resource_Conflict_List.</param>
	/// <param name="ulIndex">
	/// Caller-supplied value used as an index into the conflict list. This value can be from zero to one less than the number returned
	/// by CM_Get_Resource_Conflict_Count.
	/// </param>
	/// <param name="pConflictDetails">
	/// Caller-supplied address of a CONFLICT_DETAILS structure to receive conflict details. The caller must supply values for the
	/// structure's CD_ulSize and CD_ulMask structures.
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// To determine conflicting resource requirements between a specified device and other devices on a machine, use the following steps.
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Call CM_Query_Resource_Conflict_List to obtain a handle to a list of resource conflicts.</term>
	/// </item>
	/// <item>
	/// <term>Call CM_Get_Resource_Conflict_Count to determine the number of conflicts contained in the resource conflict list.</term>
	/// </item>
	/// <item>
	/// <term>Call <c>CM_Get_Resource_Conflict_Details</c> for each entry in the conflict list.</term>
	/// </item>
	/// </list>
	/// <para>The following conflicts are typically not reported:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If there are multiple conflicts for a resource, and the owners of only some of the conflicts can be determined, the conflicts
	/// without identifiable owners are not reported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Conflicts that appear to be with the specified device (that is, the device conflicts with itself) are not reported.</term>
	/// </item>
	/// <item>
	/// <term>If multiple non-Plug and Play devices use the same driver, resource conflicts among these devices might not be reported.</term>
	/// </item>
	/// </list>
	/// <para>Sometimes, resources assigned to the HAL might be reported as either conflicting with the HAL or not available.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_resource_conflict_detailsw CMAPI CONFIGRET
	// CM_Get_Resource_Conflict_DetailsW( CONFLICT_LIST clConflictList, ULONG ulIndex, PCONFLICT_DETAILS_W pConflictDetails );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Resource_Conflict_DetailsW")]
	public static extern CONFIGRET CM_Get_Resource_Conflict_Details(CONFLICT_LIST clConflictList, uint ulIndex, ref CONFLICT_DETAILS pConflictDetails);
}