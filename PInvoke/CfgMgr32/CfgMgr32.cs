using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	/// <summary>Items from the CfgMgr32.dll</summary>
	public static partial class CfgMgr32
	{
		private const string Lib_CfgMgr32 = "CfgMgr32.dll";

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
		[DllImport(Lib_CfgMgr32, SetLastError = false, ExactSpelling = true)]
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
		[DllImport(Lib_CfgMgr32, SetLastError = false, CharSet = CharSet.Unicode)]
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Request_Device_EjectW")]
		public static extern CONFIGRET CM_Request_Device_Eject(uint dnDevInst, out PNP_VETO_TYPE pVetoType, [In, Out, Optional] StringBuilder pszVetoName, [Optional] uint ulNameLength, uint ulFlags = 0);
	}
}