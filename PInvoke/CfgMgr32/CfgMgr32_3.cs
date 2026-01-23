using Microsoft.Win32.SafeHandles;
using System.ComponentModel.DataAnnotations;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.SetupAPI;

namespace Vanara.PInvoke;

/// <summary>Items from the CfgMgr32.dll</summary>
public static partial class CfgMgr32
{
	/// <summary>The callback routine invoked by the Configuration Manager when listening for events.</summary>
	/// <param name="notify">The handle of the notification context which invoked the callback.</param>
	/// <param name="context">A user-provided callback context.</param>
	/// <param name="action">The device action which triggered the callback.</param>
	/// <param name="eventData">The callback data.</param>
	/// <param name="eventDataSize">The size of the callback data struct.</param>
	/// <returns>
	/// If responding to a <see cref="CM_NOTIFY_ACTION.CM_NOTIFY_ACTION_DEVICEQUERYREMOVE"/> notification, the <see
	/// cref="CM_NOTIFY_CALLBACK"/> callback should return either <see cref="Win32Error.ERROR_SUCCESS"/> or <see
	/// cref="Win32Error.ERROR_CANCELLED"/>, as appropriate. Otherwise, the callback should return <see
	/// cref="Win32Error.ERROR_SUCCESS"/>. The callback should not return any other values.
	/// </returns>
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate Win32Error CM_NOTIFY_CALLBACK(HCMNOTIFICATION notify, [Optional] IntPtr context, CM_NOTIFY_ACTION action, [In] IntPtr eventData, uint eventDataSize);

	/// <summary>
	/// A variable of ULONG type that supplies one of the following flag values that apply if the caller supplies a device instance identifier
	/// </summary>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Locate_DevNodeA")]
	[Flags]
	public enum CM_LOCATE_DEVINST : uint
	{
		/// <summary></summary>
		CM_LOCATE_DEVINST_NORMAL = CM_LOCATE_DEVNODE.CM_LOCATE_DEVNODE_NORMAL,

		/// <summary></summary>
		CM_LOCATE_DEVINST_PHANTOM = CM_LOCATE_DEVNODE.CM_LOCATE_DEVNODE_PHANTOM,

		/// <summary></summary>
		CM_LOCATE_DEVINST_CANCELREMOVE = CM_LOCATE_DEVNODE.CM_LOCATE_DEVNODE_CANCELREMOVE,

		/// <summary></summary>
		CM_LOCATE_DEVINST_NOVALIDATION = CM_LOCATE_DEVNODE.CM_LOCATE_DEVNODE_NOVALIDATION,
	}

	/// <summary>
	/// A variable of ULONG type that supplies one of the following flag values that apply if the caller supplies a device instance identifier
	/// </summary>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Locate_DevNodeA")]
	[Flags]
	public enum CM_LOCATE_DEVNODE : uint
	{
		/// <summary>
		/// The function retrieves the device instance handle for the specified device only if the device is currently configured in the
		/// device tree.
		/// </summary>
		CM_LOCATE_DEVNODE_NORMAL = 0x00000000,

		/// <summary>
		/// The function retrieves a device instance handle for the specified device if the device is currently configured in the device
		/// tree or the device is a nonpresent device that is not currently configured in the device tree.
		/// </summary>
		CM_LOCATE_DEVNODE_PHANTOM = 0x00000001,

		/// <summary>
		/// The function retrieves a device instance handle for the specified device if the device is currently configured in the device
		/// tree or in the process of being removed from the device tree. If the device is in the process of being removed, the function
		/// cancels the removal of the device.
		/// </summary>
		CM_LOCATE_DEVNODE_CANCELREMOVE = 0x00000002,

		/// <summary>Not used.</summary>
		CM_LOCATE_DEVNODE_NOVALIDATION = 0x00000004,
	}

	/// <summary>This enumeration identifies Plug and Play device event types.</summary>
	/// <remarks>
	/// When a driver calls the CM_Register_Notification function, the pCallback parameter contains a pointer to a routine to be called
	/// when a specified PnP event occurs. The callback routine's Action parameter is a value from the <c>CM_NOTIFY_ACTION</c> enumeration.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ne-cfgmgr32-cm_notify_action typedef enum _CM_NOTIFY_ACTION {
	// CM_NOTIFY_ACTION_DEVICEINTERFACEARRIVAL, CM_NOTIFY_ACTION_DEVICEINTERFACEREMOVAL, CM_NOTIFY_ACTION_DEVICEQUERYREMOVE,
	// CM_NOTIFY_ACTION_DEVICEQUERYREMOVEFAILED, CM_NOTIFY_ACTION_DEVICEREMOVEPENDING, CM_NOTIFY_ACTION_DEVICEREMOVECOMPLETE,
	// CM_NOTIFY_ACTION_DEVICECUSTOMEVENT, CM_NOTIFY_ACTION_DEVICEINSTANCEENUMERATED, CM_NOTIFY_ACTION_DEVICEINSTANCESTARTED,
	// CM_NOTIFY_ACTION_DEVICEINSTANCEREMOVED, CM_NOTIFY_ACTION_MAX } CM_NOTIFY_ACTION, *PCM_NOTIFY_ACTION;
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NE:cfgmgr32._CM_NOTIFY_ACTION")]
	public enum CM_NOTIFY_ACTION
	{
		/// <summary>
		/// For this value, set the FilterType member of the CM_NOTIFY_FILTER structure to CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE. This
		/// action indicates that a device interface that meets your filter criteria has been enabled.
		/// </summary>
		CM_NOTIFY_ACTION_DEVICEINTERFACEARRIVAL = 0,

		/// <summary>
		/// For this value, set the FilterType member of the CM_NOTIFY_FILTER structure to CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE. This
		/// action indicates that a device interface that meets your filter criteria has been disabled.
		/// </summary>
		CM_NOTIFY_ACTION_DEVICEINTERFACEREMOVAL,

		/// <summary>
		/// For this value, set the FilterType member of the CM_NOTIFY_FILTER structure to CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE. This
		/// action indicates that the device is being query removed. In order to allow the query remove to succeed, call CloseHandle to
		/// close any handles you have open to the device. If you do not do this, your open handle prevents the query remove of this
		/// device from succeeding. See Registering for Notification of Device Interface Arrival and Device Removal for more
		/// information.To veto the query remove, return ERROR_CANCELLED. However, it is recommended that you do not veto the query
		/// remove and allow it to happen by closing any handles you have open to the device.
		/// </summary>
		CM_NOTIFY_ACTION_DEVICEQUERYREMOVE,

		/// <summary>
		/// For this value, set the FilterType member of the CM_NOTIFY_FILTER structure to CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE. This
		/// action indicates that the query remove of a device was failed. If you closed the handle to this device during a previous
		/// notification of CM_NOTIFY_ACTION_DEVICEQUERYREMOVE, open a new handle to the device to continue sending I/O requests to it.
		/// See Registering for Notification of Device Interface Arrival and Device Removal for more information.
		/// </summary>
		CM_NOTIFY_ACTION_DEVICEQUERYREMOVEFAILED,

		/// <summary>
		/// For this value, set the FilterType member of the CM_NOTIFY_FILTER structure to CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE.The device
		/// will be removed. If you still have an open handle to the device, call CloseHandle to close the device handle. See
		/// Registering for Notification of Device Interface Arrival and Device Removal for more information. The system may send a
		/// CM_NOTIFY_ACTION_DEVICEREMOVEPENDING notification without sending a corresponding CM_NOTIFY_ACTION_DEVICEQUERYREMOVE
		/// message. In such cases, the applications and drivers must recover from the loss of the device as best they can.
		/// </summary>
		CM_NOTIFY_ACTION_DEVICEREMOVEPENDING,

		/// <summary>
		/// For this value, set the FilterType member of the CM_NOTIFY_FILTER structure to CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE.The device
		/// has been removed. If you still have an open handle to the device, call CloseHandle to close the device handle. See
		/// Registering for Notification of Device Interface Arrival and Device Removal for more information. The system may send a
		/// CM_NOTIFY_ACTION_DEVICEREMOVECOMPLETE notification without sending corresponding CM_NOTIFY_ACTION_DEVICEQUERYREMOVE or
		/// CM_NOTIFY_ACTION_DEVICEREMOVEPENDING messages. In such cases, the applications and drivers must recover from the loss of the
		/// device as best they can.
		/// </summary>
		CM_NOTIFY_ACTION_DEVICEREMOVECOMPLETE,

		/// <summary>
		/// For this value, set the FilterType member of the CM_NOTIFY_FILTER structure to CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE. This
		/// action is sent when a driver-defined custom event has occurred.
		/// </summary>
		CM_NOTIFY_ACTION_DEVICECUSTOMEVENT,

		/// <summary>
		/// For this value, set the FilterType member of the CM_NOTIFY_FILTER structure to CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE. This
		/// action is sent when a new device instance that meets your filter criteria has been enumerated.
		/// </summary>
		CM_NOTIFY_ACTION_DEVICEINSTANCEENUMERATED,

		/// <summary>
		/// For this value, set the FilterType member of the CM_NOTIFY_FILTER structure to CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE. This
		/// action is sent when a device instance that meets your filter criteria becomes started.
		/// </summary>
		CM_NOTIFY_ACTION_DEVICEINSTANCESTARTED,

		/// <summary>
		/// For this value, set the FilterType member of the CM_NOTIFY_FILTER structure to CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE. This
		/// action is sent when a device instance that meets your filter criteria is no longer present.
		/// </summary>
		CM_NOTIFY_ACTION_DEVICEINSTANCEREMOVED,
	}

	/// <summary>Flags for <see cref="CM_NOTIFY_FILTER"/></summary>
	[Flags]
	public enum CM_NOTIFY_FILTER_FLAG : uint
	{
		/// <summary>
		/// Register to receive notifications for PnP events for all device interface classes. The memory at
		/// <c>pFilter-&gt;u.DeviceInterface.ClassGuid</c> must be zeroes. Do not use this flag with
		/// CM_NOTIFY_FILTER_FLAG_ALL_DEVICE_INSTANCES. This flag is only valid if <c>pFilter-&gt;FilterType</c> is CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE.
		/// </summary>
		CM_NOTIFY_FILTER_FLAG_ALL_INTERFACE_CLASSES = 0x00000001,

		/// <summary>
		/// Register to receive notifications for PnP events for all devices. <c>pFilter-&gt;u.DeviceInstance.InstanceId</c> must be an
		/// empty string. Do not use this flag with CM_NOTIFY_FILTER_FLAG_ALL_INTERFACE_CLASSES. This flag is only valid if
		/// <c>pFilter-&gt;FilterType</c> is CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE.
		/// </summary>
		CM_NOTIFY_FILTER_FLAG_ALL_DEVICE_INSTANCES = 0x00000002,
	}

	/// <summary>Options for <see cref="CM_NOTIFY_FILTER"/></summary>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32._CM_NOTIFY_FILTER")]
	public enum CM_NOTIFY_FILTER_TYPE
	{
		/// <summary>
		/// Register for notifications for device interface events. <c>pFilter-&gt;u.DeviceInterface.ClassGuid</c> should be filled in
		/// with the GUID of the device interface class to receive notifications for.
		/// </summary>
		CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE = 0,

		/// <summary>
		/// Register for notifications for device handle events. <c>pFilter-&gt;u.DeviceHandle.hTarget</c> must be filled in with a
		/// handle to the device to receive notifications for.
		/// </summary>
		CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE,

		/// <summary>
		/// Register for notifications for device instance events. <c>pFilter-&gt;u.DeviceInstance.InstanceId</c> should be filled in
		/// with the device instance ID of the device to receive notifications for.
		/// </summary>
		CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE,
	}

	/// <summary>Open class key flags</summary>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Open_Class_KeyW")]
	public enum CM_OPEN_CLASS_KEY
	{
		/// <summary>The key to be opened is for a device setup class.</summary>
		CM_OPEN_CLASS_KEY_INSTALLER = 0x00000000,

		/// <summary>The key to be opened is for a device interface class.</summary>
		CM_OPEN_CLASS_KEY_INTERFACE = 0x00000001,
	}

	/// <summary>Caller-supplied flags that specify how reenumeration should occur.</summary>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Reenumerate_DevNode")]
	[Flags]
	public enum CM_REENUMERATE : uint
	{
		/// <summary>
		/// Specifies default reenumeration behavior, in which reenumeration occurs synchronously. This flag is functionally equivalent
		/// to CM_REENUMERATE_SYNCHRONOUS.
		/// </summary>
		CM_REENUMERATE_NORMAL = 0x00000000,

		/// <summary>
		/// Reenumeration should occur synchronously. The call to this function returns when all devices in the specified subtree have
		/// been reenumerated. If this flag is set, the CM_REENUMERATE_ASYNCHRONOUS flag should not also be set. This flag is
		/// functionally equivalent to CM_REENUMERATE_NORMAL.
		/// </summary>
		CM_REENUMERATE_SYNCHRONOUS = 0x00000001,

		/// <summary>
		/// <para>
		/// Specifies that Plug and Play should make another attempt to install any devices in the specified subtree that have been
		/// detected but are not yet configured, or are marked as needing reinstallation, or for which installation must be completed.
		/// This flag can be set along with either the CM_REENUMERATE_SYNCHRONOUS flag or the CM_REENUMERATE_ASYNCHRONOUS flag.
		/// </para>
		/// <para>
		/// This flag must be used with extreme caution, because it can cause the PnP manager to prompt the user to perform installation
		/// of any such devices. Currently, only components such as Device Manager and Hardware Wizard use this flag, to allow the user
		/// to retry installation of devices that might already have been detected but are not currently installed.
		/// </para>
		/// </summary>
		CM_REENUMERATE_RETRY_INSTALLATION = 0x00000002,

		/// <summary>
		/// Reenumeration should occur asynchronously. The call to this function returns immediately after the PnP manager receives the
		/// reenumeration request. If this flag is set, the CM_REENUMERATE_SYNCHRONOUS flag should not also be set.
		/// </summary>
		CM_REENUMERATE_ASYNCHRONOUS = 0x00000004,
	}

	/// <summary>A bitwise OR of the caller-supplied flag constants</summary>
	[Flags]
	public enum CM_REMOVE : uint
	{
		/// <summary></summary>
		CM_REMOVE_UI_OK = 0x00000000,

		/// <summary></summary>
		CM_REMOVE_UI_NOT_OK = 0x00000001,

		/// <summary></summary>
		CM_REMOVE_NO_RESTART = 0x00000002,
	}

	/// <summary>Flags for <see cref="CM_Setup_DevNode"/>.</summary>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Setup_DevNode")]
	public enum CM_SETUP_DEVNODE
	{
		/// <summary>Configure devinst without (re)starting</summary>
		CM_SETUP_DEVNODE_CONFIG = 0x00000005,

		/// <summary>Configure devinst class without (re)starting</summary>
		CM_SETUP_DEVNODE_CONFIG_CLASS = 0x00000006,

		/// <summary>Configure devinst extensions without (re)starting</summary>
		CM_SETUP_DEVNODE_CONFIG_EXTENSIONS = 0x00000007,

		/// <summary>Reset devinst configuration without (re)starting</summary>
		CM_SETUP_DEVNODE_CONFIG_RESET = 0x00000008,

		/// <summary>Restarts a device instance that is not running because of a problem with the device configuration.</summary>
		CM_SETUP_DEVNODE_READY = 0x00000000,

		/// <summary>
		/// Resets a device instance that has the no restart device status flag set. The no restart device status flag is set if a
		/// device is removed by calling <c>CM_Query_And_Remove_SubTree</c> or <c>CM_Query_And_Remove_SubTree_Ex</c> and specifying the
		/// CM_REMOVE_NO_RESTART flag.
		/// </summary>
		CM_SETUP_DEVNODE_RESET = 0x00000004,
	}

	/// <summary>Flags for <see cref="DMA_DES"/>.</summary>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.DMA_Des_s")]
	[Flags]
	public enum DMA_DES_FLAGS : uint
	{
		/// <summary>Bitmask for the bits within DD_Flags that specify the channel width value.</summary>
		mDD_Width = 0x3,

		/// <summary>8-bit DMA channel</summary>
		fDD_BYTE = 0x0,

		/// <summary>16-bit DMA channel</summary>
		fDD_WORD = 0x1,

		/// <summary>32-bit DMA channel</summary>
		fDD_DWORD = 0x2,

		/// <summary>8-bit and 16-bit DMA channel</summary>
		fDD_BYTE_AND_WORD = 0x3,

		/// <summary>Bitmask for the bits within DD_Flags that specify the bus mastering value.</summary>
		mDD_BusMaster = 0x4,

		/// <summary>No bus mastering</summary>
		fDD_NoBusMaster = 0x0,

		/// <summary>Bus mastering</summary>
		fDD_BusMaster = 0x4,

		/// <summary>Bitmask for the bits within DD_Flags that specify the DMA type value.</summary>
		mDD_Type = 0x18,

		/// <summary>Standard DMA</summary>
		fDD_TypeStandard = 0x00,

		/// <summary>Type-A DMA</summary>
		fDD_TypeA = 0x08,

		/// <summary>Type-B DMA</summary>
		fDD_TypeB = 0x10,

		/// <summary>Type-F DMA</summary>
		fDD_TypeF = 0x18,
	}

	/// <summary>Flags for <see cref="IO_DES"/>.</summary>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.IO_Des_s")]
	[Flags]
	public enum IO_DES_FLAGS : uint
	{
		/// <summary>Bitmask for the bits within IOD_DesFlags that specify the port type value.</summary>
		fIOD_PortType = 0x1,

		/// <summary>The device is accessed in memory address space.</summary>
		fIOD_Memory = 0x0,

		/// <summary>The device is accessed in I/O address space.</summary>
		fIOD_IO = 0x1,

		/// <summary>Bitmask for the bits within IOD_DesFlags that specify the decode value.</summary>
		fIOD_DECODE = 0x00fc,

		/// <summary>The device decodes 10 bits of the port address.</summary>
		fIOD_10_BIT_DECODE = 0x0004,

		/// <summary>The device decodes 12 bits of the port address.</summary>
		fIOD_12_BIT_DECODE = 0x0008,

		/// <summary>The device decodes 16 bits of the port address.</summary>
		fIOD_16_BIT_DECODE = 0x0010,

		/// <summary>The device uses "positive decode" instead of "subtractive decode."</summary>
		fIOD_POSITIVE_DECODE = 0x0020,

		/// <summary></summary>
		fIOD_PASSIVE_DECODE = 0x0040,

		/// <summary></summary>
		fIOD_WINDOW_DECODE = 0x0080,

		/// <summary></summary>
		fIOD_PORT_BAR = 0x0100,
	}

	/// <summary>Flags for <see cref="IRQ_DES_32"/></summary>
	[Flags]
	public enum IRQD_FLAGS : ushort
	{
		/// <summary>Bitmask,whether the IRQ may be shared:</summary>
		mIRQD_Share = 0x1,

		/// <summary>The IRQ may not be shared</summary>
		fIRQD_Exclusive = 0x0,

		/// <summary>The IRQ may be shared</summary>
		fIRQD_Share = 0x1,

		/// <summary>Bitmask,whether edge or level triggered:</summary>
		mIRQD_Edge_Level = 0x2,

		/// <summary>The IRQ is level-sensitive</summary>
		fIRQD_Level = 0x0,

		/// <summary>The IRQ is edge-sensitive</summary>
		fIRQD_Edge = 0x2,
	}

	/// <summary>Flags for <see cref="MEM_DES"/></summary>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.Mem_Des_s")]
	[Flags]
	public enum MEM_DES_FLAGS : uint
	{
		/// <summary>Bitmask, whether memory is writable</summary>
		mMD_MemoryType = 0x1,

		/// <summary>Memory range is read-only</summary>
		fMD_ROM = 0x0,

		/// <summary>Memory range may be written to</summary>
		fMD_RAM = 0x1,

		/// <summary>Bitmask, memory is 24 or 32-bit</summary>
		mMD_32_24 = 0x2,

		/// <summary>Memory range is 24-bit</summary>
		fMD_24 = 0x0,

		/// <summary>Memory range is 32-bit</summary>
		fMD_32 = 0x2,

		/// <summary>Bitmask,whether memory prefetchable</summary>
		mMD_Prefetchable = 0x4,

		/// <summary>Memory range is not prefetchable</summary>
		fMD_PrefetchDisallowed = 0x0,

		/// <summary>Memory range is prefetchable</summary>
		fMD_PrefetchAllowed = 0x4,

		/// <summary>Bitmask,whether memory is readable</summary>
		mMD_Readable = 0x8,

		/// <summary>Memory range is readable</summary>
		fMD_ReadAllowed = 0x0,

		/// <summary>Memory range is write-only</summary>
		fMD_ReadDisallowed = 0x8,

		/// <summary>Bitmask,supports write-behind</summary>
		mMD_CombinedWrite = 0x10,

		/// <summary>no combined-write caching</summary>
		fMD_CombinedWriteDisallowed = 0x0,

		/// <summary>supports combined-write caching</summary>
		fMD_CombinedWriteAllowed = 0x10,

		/// <summary>Bitmask,whether memory is cacheable</summary>
		mMD_Cacheable = 0x20,

		/// <summary>Memory range is non-cacheable</summary>
		fMD_NonCacheable = 0x0,

		/// <summary>Memory range is cacheable</summary>
		fMD_Cacheable = 0x20,

		/// <summary>Memory range is bridge window decode.</summary>
		fMD_WINDOW_DECODE = 0x40,

		/// <summary>Memory BAR resource.</summary>
		fMD_MEMORY_BAR = 0x80,
	}

	/// <summary>Flags for <see cref="MFCARD_DES"/></summary>
	[Flags]
	public enum MFCARD_DES_FLAGS : uint
	{
		/// <summary>Bitmask, whether audio is enabled or not</summary>
		mPMF_AUDIO_ENABLE = 0x8,

		/// <summary>Audio is enabled</summary>
		fPMF_AUDIO_ENABLE = 0x8,
	}

	/// <summary>Flags for <see cref="PCCARD_DES"/>.</summary>
	[Flags]
	public enum PCD_FLAGS : uint
	{
		/// <summary>Bitmask, whether I/O is 8 or 16 bits</summary>
		mPCD_IO_8_16 = 0x1,

		/// <summary>I/O is 8-bit</summary>
		fPCD_IO_8 = 0x0,

		/// <summary>I/O is 16-bit</summary>
		fPCD_IO_16 = 0x1,

		/// <summary>Bitmask, whether MEM is 8 or 16 bits</summary>
		mPCD_MEM_8_16 = 0x2,

		/// <summary>MEM is 8-bit</summary>
		fPCD_MEM_8 = 0x0,

		/// <summary>MEM is 16-bit</summary>
		fPCD_MEM_16 = 0x2,

		/// <summary>Bitmask, whether MEMx is Attribute or Common</summary>
		mPCD_MEM_A_C = 0xC,

		/// <summary>MEM1 is Attribute</summary>
		fPCD_MEM1_A = 0x4,

		/// <summary>MEM2 is Attribute</summary>
		fPCD_MEM2_A = 0x8,

		/// <summary>zero wait on 8 bit I/O</summary>
		fPCD_IO_ZW_8 = 0x10,

		/// <summary>iosrc 16</summary>
		fPCD_IO_SRC_16 = 0x20,

		/// <summary>wait states on 16 bit io</summary>
		fPCD_IO_WS_16 = 0x40,

		/// <summary>Bitmask, for additional wait states on memory windows</summary>
		mPCD_MEM_WS = 0x300,

		/// <summary>1 wait state</summary>
		fPCD_MEM_WS_ONE = 0x100,

		/// <summary>2 wait states</summary>
		fPCD_MEM_WS_TWO = 0x200,

		/// <summary>3 wait states</summary>
		fPCD_MEM_WS_THREE = 0x300,

		/// <summary>MEM is Attribute</summary>
		fPCD_MEM_A = 0x4,

		/// <summary></summary>
		fPCD_ATTRIBUTES_PER_WINDOW = 0x8000,

		/// <summary>I/O window 1 is 16-bit</summary>
		fPCD_IO1_16 = 0x00010000,

		/// <summary>I/O window 1 zero wait on 8 bit I/O</summary>
		fPCD_IO1_ZW_8 = 0x00020000,

		/// <summary>I/O window 1 iosrc 16</summary>
		fPCD_IO1_SRC_16 = 0x00040000,

		/// <summary>I/O window 1 wait states on 16 bit io</summary>
		fPCD_IO1_WS_16 = 0x00080000,

		/// <summary>I/O window 2 is 16-bit</summary>
		fPCD_IO2_16 = 0x00100000,

		/// <summary>I/O window 2 zero wait on 8 bit I/O</summary>
		fPCD_IO2_ZW_8 = 0x00200000,

		/// <summary>I/O window 2 iosrc 16</summary>
		fPCD_IO2_SRC_16 = 0x00400000,

		/// <summary>I/O window 2 wait states on 16 bit io</summary>
		fPCD_IO2_WS_16 = 0x00800000,

		/// <summary>MEM window 1 Bitmask, for additional wait states on memory windows</summary>
		mPCD_MEM1_WS = 0x03000000,

		/// <summary>MEM window 1, 1 wait state</summary>
		fPCD_MEM1_WS_ONE = 0x01000000,

		/// <summary>MEM window 1, 2 wait states</summary>
		fPCD_MEM1_WS_TWO = 0x02000000,

		/// <summary>MEM window 1, 3 wait states</summary>
		fPCD_MEM1_WS_THREE = 0x03000000,

		/// <summary>MEM window 1 is 16-bit</summary>
		fPCD_MEM1_16 = 0x04000000,

		/// <summary>MEM window 2 Bitmask, for additional wait states on memory windows</summary>
		mPCD_MEM2_WS = 0x30000000,

		/// <summary>MEM window 2, 1 wait state</summary>
		fPCD_MEM2_WS_ONE = 0x10000000,

		/// <summary>MEM window 2, 2 wait states</summary>
		fPCD_MEM2_WS_TWO = 0x20000000,

		/// <summary>MEM window 2, 3 wait states</summary>
		fPCD_MEM2_WS_THREE = 0x30000000,

		/// <summary>MEM window 2 is 16-bit</summary>
		fPCD_MEM2_16 = 0x40000000,
	}

	/// <summary>Specifies how the registry key is to be opened.</summary>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Open_Class_KeyW")]
	public enum REGDISPOSITION
	{
		/// <summary>Open the key if it exists. Otherwise, create the key.</summary>
		RegDisposition_OpenAlways = 0x00000000,

		/// <summary>Open the key only if it exists.</summary>
		RegDisposition_OpenExisting = 0x00000001,
	}

	/// <summary>
	/// The <c>CM_Get_Sibling</c> function obtains a device instance handle to the next sibling node of a specified device node
	/// (devnode) in the local machine's device tree.
	/// </summary>
	/// <param name="pdnDevInst">
	/// Caller-supplied pointer to the device instance handle to the sibling node that this function retrieves. The retrieved handle is
	/// bound to the local machine.
	/// </param>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate all children of a devnode in the local machine's device tree, first call CM_Get_Child to obtain a handle to the
	/// first child node, then call <c>CM_Get_Sibling</c> to obtain handles for the rest of the children.
	/// </para>
	/// <para>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_sibling CMAPI CONFIGRET CM_Get_Sibling( PDEVINST
	// pdnDevInst, DEVINST dnDevInst, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Sibling")]
	public static extern CONFIGRET CM_Get_Sibling(out uint pdnDevInst, uint dnDevInst, uint ulFlags = 0);

	/// <summary>
	/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Get_Sibling instead.]</para>
	/// <para>
	/// The <c>CM_Get_Sibling_Ex</c> function obtains a device instance handle to the next sibling node of a specified device node, in a
	/// local or a remote machine's device tree.
	/// </para>
	/// </summary>
	/// <param name="pdnDevInst">
	/// Caller-supplied pointer to the device instance handle to the sibling node that this function retrieves. The retrieved handle is
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
	/// <para>
	/// To enumerate all children of a device node in the local machine's device tree, first call CM_Get_Child_Ex to obtain a handle to
	/// the first child node, then call <c>CM_Get_Sibling_Ex</c> to obtain handles for the rest of the children.
	/// </para>
	/// <para>For information about using device instance handles that are bound to a local or a remote machine, see CM_Get_Child_Ex.</para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_sibling_ex CMAPI CONFIGRET CM_Get_Sibling_Ex(
	// PDEVINST pdnDevInst, DEVINST dnDevInst, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Sibling_Ex")]
	public static extern CONFIGRET CM_Get_Sibling_Ex(out uint pdnDevInst, uint dnDevInst, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated and should not be used.]</para>
	/// <para>
	/// The <c>CM_Get_Version</c> function returns version 4.0 of the Plug and Play (PnP) Configuration Manager DLL (Cfgmgr32.dll) for a
	/// local machine.
	/// </para>
	/// </summary>
	/// <returns>
	/// If the function succeeds, it returns the major revision number in the high-order byte, and the minor revision number in the
	/// low-order byte. Version 4.0 is returned as 0x0400. By default, version 4.0 is supported by Microsoft Windows 2000 and later
	/// versions of Windows. If an internal error occurs, the function returns 0x0000. Call GetLastError to obtain the error code for
	/// the failure.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function returns version 4.0 of the configuration manager to ensure compatibility with version 4.0 and all later versions
	/// of the configuration manager, and to ensure compatibility with all applications that require version 4.0 of the configuration manager.
	/// </para>
	/// <para>
	/// To determine if a specific version of the configuration manager is available on a machine, use CM_Is_Version_Available or CM_Is_Version_Available_Ex.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_version CMAPI WORD CM_Get_Version();
	[DllImport(Lib_Cfgmgr32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Version")]
	public static extern ushort CM_Get_Version();

	/// <summary>
	/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated and should not be used.]</para>
	/// <para>
	/// The <c>CM_Get_Version_Ex</c> function returns version 4.0 of the Plug and Play (PnP) Configuration Manager DLL (Cfgmgr32.dll)
	/// for a local or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="hMachine">
	/// <para>Supplies a machine handle that is returned by CM_Connect_Machine.</para>
	/// <para>
	/// <c>Note</c> Using this function to access remote machines is not supported beginning with Windows 8 and Windows Server 2012, as
	/// this functionality has been removed.
	/// </para>
	/// </param>
	/// <returns>
	/// If the function succeeds, it returns the major revision number in the high-order byte and the minor revision number in the
	/// low-order byte. Version 4.0 is returned as 0x0400. By default, version 4.0 is supported by Microsoft Windows 2000 and later
	/// versions of Windows. If an internal error occurs, the function returns 0x0000. Call GetLastError to obtain the error code for
	/// the failure.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function returns version 4.0 of the configuration manager to ensure compatibility with version 4.0 and all later versions
	/// of the configuration manager, and to ensure compatibility with all applications that require version 4.0 of the configuration manager.
	/// </para>
	/// <para>
	/// To determine if a specific version of the configuration manager is available on a machine, use CM_Is_Version_Available or CM_Is_Version_Available_Ex.
	/// </para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_version_ex CMAPI WORD CM_Get_Version_Ex( HMACHINE
	// hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Get_Version_Ex")]
	public static extern ushort CM_Get_Version_Ex([In, Optional] HMACHINE hMachine);

	/// <summary>The <c>CM_Is_Dock_Station_Present</c> function identifies whether a docking station is present in a local machine.</summary>
	/// <param name="pbPresent">
	/// Pointer to a Boolean value that indicates whether a docking station is present in a local machine. The function sets *pbPresent
	/// to <c>TRUE</c> if a docking station is present. Otherwise, the function sets *pbPresent to <c>FALSE</c>.
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, the function returns one of the CR_-prefixed error codes
	/// that are defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use this function to determine whether a docking station is present in a local machine. You can also use the following related
	/// functions with docking stations:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// <para>CM_Is_Dock_Station_Present_Ex identifies whether a docking station is present in a local or a remote machine.</para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>CM_Request_Eject_PC requests that a portable PC, which is inserted in a local docking station, be ejected.</para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>CM_Request_Eject_PC_Ex requests that a portable PC, which is inserted in a local or a remote docking station, be ejected.</para>
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_is_dock_station_present CMAPI CONFIGRET
	// CM_Is_Dock_Station_Present( PBOOL pbPresent );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Is_Dock_Station_Present")]
	public static extern CONFIGRET CM_Is_Dock_Station_Present([MarshalAs(UnmanagedType.Bool)] out bool pbPresent);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Is_Dock_Station_Present instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Is_Dock_Station_Present_Ex</c> function identifies whether a docking station is present in a local or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="pbPresent">
	/// Pointer to a Boolean value that indicates whether a docking station is present in a local machine. The function sets *pbPresent
	/// to <c>TRUE</c> if a docking station is present. The function sets *pbPresent to <c>FALSE</c> if the function cannot connect to
	/// the specified machine or a docking station is not present.
	/// </param>
	/// <param name="hMachine">
	/// <para>Supplies a machine handle that is returned by CM_Connect_Machine.</para>
	/// <para>
	/// <c>Note</c> Using this function to access remote machines is not supported beginning with Windows 8 and Windows Server 2012, as
	/// this functionality has been removed.
	/// </para>
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, the function returns one of the CR_-prefixed error codes
	/// that are defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use this function to determine whether a docking station is present in a local or a remote machine. You can also use the
	/// following related functions with docking stations:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// <para>CM_Is_Dock_Station_Present identifies whether a docking station is present in a local machine.</para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>CM_Request_Eject_PC requests that a portable PC, which is inserted in a local docking station, be ejected.</para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>CM_Request_Eject_PC_Ex requests that a portable PC, which is inserted in a local or a remote docking station, be ejected.</para>
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_is_dock_station_present_ex CMAPI CONFIGRET
	// CM_Is_Dock_Station_Present_Ex( PBOOL pbPresent, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Is_Dock_Station_Present_Ex")]
	public static extern CONFIGRET CM_Is_Dock_Station_Present_Ex([MarshalAs(UnmanagedType.Bool)] out bool pbPresent, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated and should not be used.]</para>
	/// <para>
	/// The <c>CM_Is_Version_Available</c> function indicates whether a specified version of the Plug and Play (PnP) Configuration
	/// Manager DLL (Cfgmgr32.dll) is supported by a local machine.
	/// </para>
	/// </summary>
	/// <param name="wVersion">
	/// <para>
	/// Identifies a version of the configuration manager. The supported version of the configuration manager corresponds directly to
	/// the operating system version. The major version is specified by the high-order byte and the minor version is specified by the
	/// low-order byte.
	/// </para>
	/// <para>
	/// For example, 0x0400 specifies version 4.0, which is supported by default by Microsoft Windows 2000 and later versions of
	/// Windows. 0x0501 specifies version 5.1, which is supported by Windows XP and later versions of Windows.
	/// </para>
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if the local machine supports the specified version of the configuration manager. Otherwise,
	/// the function returns <c>FALSE</c>.
	/// </returns>
	/// <remarks>
	/// Use this function to determine whether a specified version of the configuration manager is supported by a local machine. If the
	/// specified version is supported, all versions earlier and including this version are supported by the machine. You can also use
	/// CM_Is_Version_Available_Ex to determine if a local or a remote machine supports a specific version of the configuration manager.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_is_version_available CMAPI BOOL
	// CM_Is_Version_Available( WORD wVersion );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Is_Version_Available")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CM_Is_Version_Available(ushort wVersion);

	/// <summary>
	/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated and should not be used.]</para>
	/// <para>
	/// The <c>CM_Is_Version_Available_Ex</c> function indicates whether a specified version of the Plug and Play (PNP) Configuration
	/// Manager DLL (Cfgmgr32.dll) is supported by a local or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="wVersion">
	/// Identifies a version of the configuration manager. The supported version of the configuration manager corresponds directly to
	/// the operating system version. The major version is specified by the high-order byte and the minor version is specified by the
	/// low-order byte. For example, 0x0400 specifies version 4.0, which is supported by default by Microsoft Windows NT 4.0 and later
	/// versions of Windows. Version 0x0501 specifies version 5.1, which is supported by Windows XP and later versions of Windows.
	/// </param>
	/// <param name="hMachine">
	/// <para>Supplies a machine handle that is returned by CM_Connect_Machine.</para>
	/// <para>
	/// <c>Note</c> Using this function to access remote machines is not supported beginning with Windows 8 and Windows Server 2012, as
	/// this functionality has been removed.
	/// </para>
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if the function can connect to the specified machine and if the machine supports the specified
	/// version. Otherwise, the function returns <c>FALSE</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use this function to determine whether a specified version of the configuration manager is supported by a local or a remote
	/// machine. If the specified version is supported, all versions earlier and including this version are supported by the machine.
	/// You can also use CM_Is_Version_Available to determine if the local machine supports a specific version of the configuration manager.
	/// </para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_is_version_available_ex CMAPI BOOL
	// CM_Is_Version_Available_Ex( WORD wVersion, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Is_Version_Available_Ex")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CM_Is_Version_Available_Ex(ushort wVersion, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Locate_DevNode</c> function obtains a device instance handle to the device node that is associated with a specified
	/// device instance ID on the local machine.
	/// </summary>
	/// <param name="pdnDevInst">
	/// A pointer to a device instance handle that <c>CM_Locate_DevNode</c> retrieves. The retrieved handle is bound to the local machine.
	/// </param>
	/// <param name="pDeviceID">
	/// A pointer to a NULL-terminated string representing a device instance ID. If this value is <c>NULL</c>, or if it points to a
	/// zero-length string, the function retrieves a device instance handle to the device at the root of the device tree.
	/// </param>
	/// <param name="ulFlags">
	/// <para>
	/// A variable of ULONG type that supplies one of the following flag values that apply if the caller supplies a device instance identifier:
	/// </para>
	/// <para>CM_LOCATE_DEVNODE_NORMAL</para>
	/// <para>
	/// The function retrieves the device instance handle for the specified device only if the device is currently configured in the
	/// device tree.
	/// </para>
	/// <para>CM_LOCATE_DEVNODE_PHANTOM</para>
	/// <para>
	/// The function retrieves a device instance handle for the specified device if the device is currently configured in the device
	/// tree or the device is a nonpresent device that is not currently configured in the device tree.
	/// </para>
	/// <para>CM_LOCATE_DEVNODE_CANCELREMOVE</para>
	/// <para>
	/// The function retrieves a device instance handle for the specified device if the device is currently configured in the device
	/// tree or in the process of being removed from the device tree. If the device is in the process of being removed, the function
	/// cancels the removal of the device.
	/// </para>
	/// <para>CM_LOCATE_DEVNODE_NOVALIDATION</para>
	/// <para>Not used.</para>
	/// </param>
	/// <returns>
	/// If the operation succeeds, <c>CM_Locate_DevNode</c> returns CR_SUCCESS. Otherwise, the function returns one of the CR_Xxx error
	/// codes that are defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The cfgmgr32.h header defines CM_Locate_DevNode as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_locate_devnodea CMAPI CONFIGRET CM_Locate_DevNodeA(
	// PDEVINST pdnDevInst, DEVINSTID_A pDeviceID, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Locate_DevNodeA")]
	public static extern CONFIGRET CM_Locate_DevNode(out uint pdnDevInst, [In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? pDeviceID, CM_LOCATE_DEVNODE ulFlags = CM_LOCATE_DEVNODE.CM_LOCATE_DEVNODE_NORMAL);

	/// <summary>
	/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Locate_DevNode instead.]</para>
	/// <para>
	/// The <c>CM_Locate_DevNode_Ex</c> function obtains a device instance handle to the device node that is associated with a specified
	/// device instance ID, on a local machine or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="pdnDevInst">
	/// A pointer to the device instance handle that this function retrieves. The retrieved handle is bound to the machine handle
	/// specified by hMachine.
	/// </param>
	/// <param name="pDeviceID">
	/// A pointer to a NULL-terminated string representing a device instance ID. If this value is <c>NULL</c>, or if it points to a
	/// zero-length string, the function supplies a device instance handle to the device at the root of the device tree.
	/// </param>
	/// <param name="ulFlags">
	/// <para>
	/// A variable of ULONG type that supplies one of the following flag values that apply if the caller supplies a device instance identifier:
	/// </para>
	/// <para>CM_LOCATE_DEVNODE_NORMAL</para>
	/// <para>
	/// The function retrieves the device instance handle for the specified device only if the device is currently configured in the
	/// device tree.
	/// </para>
	/// <para>CM_LOCATE_DEVNODE_PHANTOM</para>
	/// <para>
	/// The function retrieves a device instance handle for the specified device if the device is currently configured in the device
	/// tree or the device is a nonpresent device that is not currently configured in the device tree.
	/// </para>
	/// <para>CM_LOCATE_DEVNODE_CANCELREMOVE</para>
	/// <para>
	/// The function retrieves a device instance handle for the specified device if the device is currently configured in the device
	/// tree or in the process of being removed for the device tree. If the device is in the process of being removed, the function
	/// cancels the removal of the device.
	/// </para>
	/// <para>CM_LOCATE_DEVNODE_NOVALIDATION</para>
	/// <para>Not used.</para>
	/// </param>
	/// <param name="hMachine">
	/// <para>
	/// A machine handle obtained from a call to CM_Connect_Machine, or a machine handle to which a device information set is bound. The
	/// machine handle for a device information set is obtained from the <c>RemoteMachineHandle</c> member of the
	/// SP_DEVINFO_LIST_DETAIL_DATA structure for the device information set. Call SetupDiGetDeviceInfoListDetail to obtain an
	/// SP_DEVINFO_LIST_DETAIL_DATA structure.
	/// </para>
	/// <para>
	/// <c>Note</c> Using this function to access remote machines is not supported beginning with Windows 8 and Windows Server 2012, as
	/// this functionality has been removed.
	/// </para>
	/// </param>
	/// <returns>
	/// If the operation succeeds, <c>CM_Locate_DevNode</c> returns CR_SUCCESS. Otherwise, the function returns one of the CR_-prefixed
	/// error codes that are defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>For information about using device instance handles that are bound to a local or a remote machine, see CM_Get_Child_Ex.</para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_locate_devnode_exw CMAPI CONFIGRET
	// CM_Locate_DevNode_ExW( PDEVINST pdnDevInst, DEVINSTID_W pDeviceID, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Locate_DevNode_ExW")]
	public static extern CONFIGRET CM_Locate_DevNode_Ex(out uint pdnDevInst, [In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? pDeviceID, CM_LOCATE_DEVNODE ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>Converts a specified <c>CONFIGRET</c> code to its equivalent system error code.</summary>
	/// <param name="CmReturnCode">The <c>CONFIGRET</c> code to be converted. <c>CONFIGRET</c> error codes are defined in CfgMgr32.h.</param>
	/// <param name="DefaultErr">
	/// A default system error code to be returned when no system error code is mapped to the specified <c>CONFIGRET</c> code.
	/// </param>
	/// <returns>
	/// <para>The system error code that corresponds to the <c>CONFIGRET</c> code. System error codes are defined in Winerror.h.</para>
	/// <para>
	/// When there is no mapping from the specified <c>CONFIGRET</c> code to a system error code, <c>CM_MapCrToWin32Err</c> returns the
	/// value specified in the DefaultErr parameter.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_mapcrtowin32err CMAPI DWORD CM_MapCrToWin32Err(
	// CONFIGRET CmReturnCode, DWORD DefaultErr );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_MapCrToWin32Err")]
	public static extern Win32Error CM_MapCrToWin32Err(CONFIGRET CmReturnCode, uint DefaultErr);

	/// <summary>The <c>CM_Modify_Res_Des</c> function modifies a specified resource descriptor on the local machine.</summary>
	/// <param name="prdResDes">Pointer to a location to receive a handle to the modified resource descriptor.</param>
	/// <param name="rdResDes">
	/// <para>
	/// Caller-supplied handle to the resource descriptor to be modified. This handle must have been previously obtained by calling one
	/// of the following functions:
	/// </para>
	/// <para>CM_Add_Res_Des</para>
	/// <para>CM_Add_Res_Des_Ex</para>
	/// <para>CM_Get_Next_Res_Des</para>
	/// <para>CM_Get_Next_Res_Des_Ex</para>
	/// <para><c>CM_Modify_Res_Des</c></para>
	/// <para>CM_Modify_Res_Des_Ex</para>
	/// </param>
	/// <param name="ResourceID">
	/// Caller-supplied resource type identifier. This must be one of the <c>ResType_</c>-prefixed constants defined in Cfgmgr32.h.
	/// </param>
	/// <param name="ResourceData">
	/// Caller-supplied pointer to a resource descriptor, which can be one of the structures listed under the CM_Add_Res_Des function's
	/// description of ResourceData.
	/// </param>
	/// <param name="ResourceLen">Caller-supplied length of the structure pointed to by ResourceData.</param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <returns>
	/// <para>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Modify_Res_Des</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario. To
	/// request information about the hardware resources on a local machine it is necessary implement an architecture-native version of
	/// the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller-supplied resource descriptor data replaces the existing data. The values specified for ResourceID and ResourceLen do
	/// not have to match the existing resource descriptor.
	/// </para>
	/// <para>
	/// If the value specified for ResourceID is <c>ResType_ClassSpecific</c>, then the specified resource descriptor must be the last
	/// one associated with the logical configuration.
	/// </para>
	/// <para>
	/// Callers of <c>CM_Modify_Res_Des</c> must call CM_Free_Res_Des_Handle to deallocate the resource descriptor handle, after it is
	/// no longer needed.
	/// </para>
	/// <para>
	/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_modify_res_des CMAPI CONFIGRET CM_Modify_Res_Des(
	// PRES_DES prdResDes, RES_DES rdResDes, RESOURCEID ResourceID, PCVOID ResourceData, ULONG ResourceLen, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Modify_Res_Des")]
	public static extern CONFIGRET CM_Modify_Res_Des(out SafeRES_DES prdResDes, RES_DES rdResDes, RESOURCEID ResourceID, [In] IntPtr ResourceData, uint ResourceLen, uint ulFlags = 0);

	/// <summary>The <c>CM_Modify_Res_Des</c> function modifies a specified resource descriptor on the local machine.</summary>
	/// <typeparam name="T">The type of the data.</typeparam>
	/// <param name="rdResDes">
	/// <para>
	/// Caller-supplied handle to the resource descriptor to be modified. This handle must have been previously obtained by calling one
	/// of the following functions:
	/// </para>
	/// <para>CM_Add_Res_Des</para>
	/// <para>CM_Add_Res_Des_Ex</para>
	/// <para>CM_Get_Next_Res_Des</para>
	/// <para>CM_Get_Next_Res_Des_Ex</para>
	/// <para><c>CM_Modify_Res_Des</c></para>
	/// <para>CM_Modify_Res_Des_Ex</para>
	/// </param>
	/// <param name="data">
	/// Caller-supplied pointer to a resource descriptor, which can be one of the structures listed under the CM_Add_Res_Des function's
	/// description of ResourceData.
	/// </param>
	/// <param name="ResourceID">
	/// Caller-supplied resource type identifier. This must be one of the <c>ResType_</c>-prefixed constants defined in Cfgmgr32.h.
	/// </param>
	/// <returns>
	/// <para>A handle to the modified resource descriptor.</para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Modify_Res_Des</c> throws CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario. To
	/// request information about the hardware resources on a local machine it is necessary implement an architecture-native version of
	/// the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <exception cref="ArgumentException">Unable to determine RESOURCEID from type. - T</exception>
	/// <remarks>
	/// <para>
	/// The caller-supplied resource descriptor data replaces the existing data. The values specified for ResourceID and ResourceLen do
	/// not have to match the existing resource descriptor.
	/// </para>
	/// <para>
	/// If the value specified for ResourceID is <c>ResType_ClassSpecific</c>, then the specified resource descriptor must be the last
	/// one associated with the logical configuration.
	/// </para>
	/// <para>
	/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
	/// </para>
	/// </remarks>
	public static SafeRES_DES CM_Modify_Res_Des<T>(RES_DES rdResDes, T data, RESOURCEID ResourceID = 0) where T : struct
	{
		if (ResourceID == 0 && !CorrespondingTypeAttribute.CanSet<T, RESOURCEID>(out ResourceID))
			throw new ArgumentException("Unable to determine RESOURCEID from type.", nameof(T));
		using var mem = new SafeAnysizeStruct<T>(data);
		CM_Modify_Res_Des(out var hRD, rdResDes, ResourceID, mem, mem.Size).ThrowIfFailed();
		return hRD;
	}

	/// <summary>
	/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Modify_Res_Des instead.]</para>
	/// <para>The <c>CM_Modify_Res_Des_Ex</c> function modifies a specified resource descriptor on a local or a remote machine.</para>
	/// </summary>
	/// <param name="prdResDes">Pointer to a location to receive a handle to the modified resource descriptor.</param>
	/// <param name="rdResDes">
	/// <para>
	/// Caller-supplied handle to the resource descriptor to be modified. This handle must have been previously obtained by calling one
	/// of the following functions:
	/// </para>
	/// <para>CM_Add_Res_Des</para>
	/// <para>CM_Add_Res_Des_Ex</para>
	/// <para>CM_Get_Next_Res_Des</para>
	/// <para>CM_Get_Next_Res_Des_Ex</para>
	/// <para>CM_Modify_Res_Des</para>
	/// <para><c>CM_Modify_Res_Des_Ex</c></para>
	/// </param>
	/// <param name="ResourceID">
	/// Caller-supplied resource type identifier. This must be one of the <c>ResType_</c>-prefixed constants defined in Cfgmgr32.h.
	/// </param>
	/// <param name="ResourceData">
	/// Caller-supplied pointer to a resource descriptor, which can be one of the structures listed under the CM_Add_Res_Des_Ex
	/// function's description of ResourceData.
	/// </param>
	/// <param name="ResourceLen">Caller-supplied length of the structure pointed to by ResourceData.</param>
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
	/// <c>Note</c> Starting with Windows 8, <c>CM_Modify_Res_Des_Ex</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64 scenario.
	/// To request information about the hardware resources on a local machine it is necessary implement an architecture-native version
	/// of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller-supplied resource descriptor data replaces the existing data. The values specified for ResourceID and ResourceLen do
	/// not have to match the existing resource descriptor.
	/// </para>
	/// <para>
	/// If the value specified for ResourceID is <c>ResType_ClassSpecific</c>, then the specified resource descriptor must be the last
	/// one associated with the logical configuration.
	/// </para>
	/// <para>
	/// Callers of <c>CM_Modify_Res_Des_Ex</c> must call CM_Free_Res_Des_Handle to deallocate the resource descriptor handle, after it
	/// is no longer needed.
	/// </para>
	/// <para>
	/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
	/// </para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_modify_res_des_ex CMAPI CONFIGRET
	// CM_Modify_Res_Des_Ex( PRES_DES prdResDes, RES_DES rdResDes, RESOURCEID ResourceID, PCVOID ResourceData, ULONG ResourceLen, ULONG
	// ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Modify_Res_Des_Ex")]
	public static extern CONFIGRET CM_Modify_Res_Des_Ex(out SafeRES_DES prdResDes, RES_DES rdResDes, RESOURCEID ResourceID, [In] IntPtr ResourceData, uint ResourceLen, [In, Optional] uint ulFlags,
		[In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Open_Class_Key</c> function opens the device setup class registry key, the device interface class registry key, or a
	/// specific subkey of a class.
	/// </summary>
	/// <param name="ClassGuid">
	/// Pointer to the GUID of the class whose registry key is to be opened. This parameter is optional and can be NULL. If this
	/// parameter is NULL, the root of the class tree is opened.
	/// </param>
	/// <param name="pszClassName">Reserved. Must be set to NULL.</param>
	/// <param name="samDesired">The registry security access for the key to be opened.</param>
	/// <param name="Disposition">
	/// <para>Specifies how the registry key is to be opened. May be one of the following values:</para>
	/// <para>RegDisposition_OpenAlways</para>
	/// <para>Open the key if it exists. Otherwise, create the key.</para>
	/// <para>RegDisposition_OpenExisting</para>
	/// <para>Open the key only if it exists.</para>
	/// </param>
	/// <param name="phkClass">Pointer to an HKEY that will receive the opened key upon success.</param>
	/// <param name="ulFlags">
	/// <para>Open class key flags:</para>
	/// <para>CM_OPEN_CLASS_KEY_INSTALLER</para>
	/// <para>The key to be opened is for a device setup class.</para>
	/// <para>CM_OPEN_CLASS_KEY_INTERFACE</para>
	/// <para>The key to be opened is for a device interface class.</para>
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>Close the handle returned from this function by calling <c>RegCloseKey</c>.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_open_class_keyw CMAPI CONFIGRET CM_Open_Class_KeyW(
	// LPGUID ClassGuid, LPCWSTR pszClassName, REGSAM samDesired, REGDISPOSITION Disposition, PHKEY phkClass, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Open_Class_KeyW")]
	public static extern CONFIGRET CM_Open_Class_Key(in Guid ClassGuid, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? pszClassName,
		REGSAM samDesired, REGDISPOSITION Disposition, out SafeRegistryHandle phkClass, CM_OPEN_CLASS_KEY ulFlags);

	/// <summary>
	/// The <c>CM_Open_Class_Key</c> function opens the device setup class registry key, the device interface class registry key, or a
	/// specific subkey of a class.
	/// </summary>
	/// <param name="ClassGuid">
	/// Pointer to the GUID of the class whose registry key is to be opened. This parameter is optional and can be NULL. If this
	/// parameter is NULL, the root of the class tree is opened.
	/// </param>
	/// <param name="pszClassName">Reserved. Must be set to NULL.</param>
	/// <param name="samDesired">The registry security access for the key to be opened.</param>
	/// <param name="Disposition">
	/// <para>Specifies how the registry key is to be opened. May be one of the following values:</para>
	/// <para>RegDisposition_OpenAlways</para>
	/// <para>Open the key if it exists. Otherwise, create the key.</para>
	/// <para>RegDisposition_OpenExisting</para>
	/// <para>Open the key only if it exists.</para>
	/// </param>
	/// <param name="phkClass">Pointer to an HKEY that will receive the opened key upon success.</param>
	/// <param name="ulFlags">
	/// <para>Open class key flags:</para>
	/// <para>CM_OPEN_CLASS_KEY_INSTALLER</para>
	/// <para>The key to be opened is for a device setup class.</para>
	/// <para>CM_OPEN_CLASS_KEY_INTERFACE</para>
	/// <para>The key to be opened is for a device interface class.</para>
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>Close the handle returned from this function by calling <c>RegCloseKey</c>.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_open_class_keyw CMAPI CONFIGRET CM_Open_Class_KeyW(
	// LPGUID ClassGuid, LPCWSTR pszClassName, REGSAM samDesired, REGDISPOSITION Disposition, PHKEY phkClass, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Open_Class_KeyW")]
	public static extern CONFIGRET CM_Open_Class_Key([In, Optional] GuidPtr ClassGuid, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? pszClassName,
		REGSAM samDesired, REGDISPOSITION Disposition, out SafeRegistryHandle phkClass, CM_OPEN_CLASS_KEY ulFlags);

	/// <summary>
	/// The <c>CM_Open_Device_Interface_Key</c> function opens the registry subkey that is used by applications and drivers to store
	/// information that is specific to a device interface.
	/// </summary>
	/// <param name="pszDeviceInterface">
	/// Pointer to a string that identifies the device interface instance to open the registry subkey for.
	/// </param>
	/// <param name="samDesired">The requested registry security access to the registry subkey.</param>
	/// <param name="Disposition">
	/// <para>Specifies how the registry key is to be opened. May be one of the following values:</para>
	/// <para>RegDisposition_OpenAlways</para>
	/// <para>Open the key if it exists. Otherwise, create the key.</para>
	/// <para>RegDisposition_OpenExisting</para>
	/// <para>Open the key only if it exists.</para>
	/// </param>
	/// <param name="phkDeviceInterface">Pointer to an HKEY that will receive the opened key upon success.</param>
	/// <param name="ulFlags">Reserved. Must be set to zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>Close the handle returned from this function by calling <c>RegCloseKey</c>.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The cfgmgr32.h header defines CM_Open_Device_Interface_Key as an alias which automatically selects the ANSI or Unicode version
	/// of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with
	/// code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_open_device_interface_keya CMAPI CONFIGRET
	// CM_Open_Device_Interface_KeyA( LPCSTR pszDeviceInterface, REGSAM samDesired, REGDISPOSITION Disposition, PHKEY
	// phkDeviceInterface, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Open_Device_Interface_KeyA")]
	public static extern CONFIGRET CM_Open_Device_Interface_Key([MarshalAs(UnmanagedType.LPTStr)] string pszDeviceInterface, REGSAM samDesired, REGDISPOSITION Disposition,
		out SafeRegistryHandle phkDeviceInterface, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Open_Device_Interface_Key instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Open_Device_Interface_Key_ExA</c> function opens the registry subkey that is used by applications and drivers to store
	/// information that is specific to a device interface.
	/// </para>
	/// </summary>
	/// <param name="pszDeviceInterface">
	/// Pointer to a string that identifies the device interface instance to open the registry subkey for.
	/// </param>
	/// <param name="samDesired">The requested registry security access to the registry subkey.</param>
	/// <param name="Disposition">
	/// <para>Specifies how the registry key is to be opened. May be one of the following values:</para>
	/// <para>RegDisposition_OpenAlways</para>
	/// <para>Open the key if it exists. Otherwise, create the key.</para>
	/// <para>RegDisposition_OpenExisting</para>
	/// <para>Open the key only if it exists.</para>
	/// </param>
	/// <param name="phkDeviceInterface">Pointer to an HKEY that will receive the opened key upon success.</param>
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
	/// <para>Close the handle returned from this function by calling <c>RegCloseKey</c>.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The cfgmgr32.h header defines CM_Open_Device_Interface_Key_Ex as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
	/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
	/// information, see Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_open_device_interface_key_exa CMAPI CONFIGRET
	// CM_Open_Device_Interface_Key_ExA( LPCSTR pszDeviceInterface, REGSAM samDesired, REGDISPOSITION Disposition, PHKEY
	// phkDeviceInterface, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Open_Device_Interface_Key_ExA")]
	public static extern CONFIGRET CM_Open_Device_Interface_Key_Ex([MarshalAs(UnmanagedType.LPTStr)] string pszDeviceInterface, REGSAM samDesired, REGDISPOSITION Disposition,
		out SafeRegistryHandle phkDeviceInterface, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>The <c>CM_Open_DevNode_Key</c> function opens a registry key for device-specific configuration information.</summary>
	/// <param name="dnDevNode">Caller-supplied device instance handle that is bound to the local machine</param>
	/// <param name="samDesired">The registry security access that is required for the requested key.</param>
	/// <param name="ulHardwareProfile">
	/// The hardware profile to open if ulFlags includes CM_REGISTRY_CONFIG. If this value is zero, the key for the current hardware
	/// profile is opened.
	/// </param>
	/// <param name="Disposition">
	/// <para>Specifies how the registry key is to be opened. May be one of the following values:</para>
	/// <para>RegDisposition_OpenAlways</para>
	/// <para>Open the key if it exists. Otherwise, create the key.</para>
	/// <para>RegDisposition_OpenExisting</para>
	/// <para>Open the key only if it exists.</para>
	/// </param>
	/// <param name="phkDevice">Pointer to an HKEY that will receive the opened key upon success.</param>
	/// <param name="ulFlags">
	/// <para>
	/// Open device node key flags. Indicates the scope and type of registry storage key to open. Can be a combination of the following flags:
	/// </para>
	/// <para>CM_REGISTRY_HARDWARE</para>
	/// <para>Open the device’s hardware key. Do not combine with CM_REGISTRY_SOFTWARE.</para>
	/// <para>CM_REGISTRY_SOFTWARE</para>
	/// <para>Open the device’s software key. Do not combine with CM_REGISTRY_HARDWARE.</para>
	/// <para>CM_REGISTRY_USER</para>
	/// <para>Open the per-user key for the current user. Do not combine with CM_REGISTRY_CONFIG.</para>
	/// <para>CM_REGISTRY_CONFIG</para>
	/// <para>Open the key that stores hardware profile-specific configuration information. Do not combine with CM_REGISTRY_USER.</para>
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>Close the handle returned from this function by calling <c>RegCloseKey</c>.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_open_devnode_key CMAPI CONFIGRET CM_Open_DevNode_Key(
	// DEVINST dnDevNode, REGSAM samDesired, ULONG ulHardwareProfile, REGDISPOSITION Disposition, PHKEY phkDevice, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Open_DevNode_Key")]
	public static extern CONFIGRET CM_Open_DevNode_Key(uint dnDevNode, REGSAM samDesired, uint ulHardwareProfile, REGDISPOSITION Disposition, out SafeRegistryHandle phkDevice, CM_REGISTRY ulFlags);

	/// <summary>
	/// The <c>CM_Query_And_Remove_SubTree</c> function checks whether a device instance and its children can be removed and, if so, it
	/// removes them.
	/// </summary>
	/// <param name="dnAncestor">
	/// Caller-supplied device instance handle to the device at the root of the subtree to be removed. This device instance handle is
	/// bound to the local machine.
	/// </param>
	/// <param name="pVetoType">
	/// (Optional) If the caller does not pass <c>NULL</c> and the removal request is vetoed (that is, the function returns
	/// CR_REMOVE_VETOED), on return this points to a PNP_VETO_TYPE-typed value that indicates the reason for the veto.
	/// </param>
	/// <param name="pszVetoName">
	/// (Optional) If the caller does not pass <c>NULL</c> and the removal request is vetoed (that is, the function returns
	/// CR_REMOVE_VETOED), on return this points to a text string that is associated with the veto type. The type of information this
	/// string provides is dependent on the value received by pVetoType. For information about these strings, see PNP_VETO_TYPE.
	/// </param>
	/// <param name="ulNameLength">
	/// Caller-supplied value representing the length (number of characters) of the string buffer supplied by pszVetoName. This should
	/// be set to MAX_PATH.
	/// </param>
	/// <param name="ulFlags">A bitwise OR of the caller-supplied flag constants that are described in the <c>Remarks</c> section.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the other CR_-prefixed error codes
	/// defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The purpose of the <c>CM_Query_And_Remove_SubTree</c> function is to allow an application to prepare a device for safe removal
	/// from the local machine. Use this function to remove devices only if a driver has not set the <c>SurpriseRemovalOK</c> member of
	/// DEVICE_CAPABILITIES. If a driver has set <c>SurpriseRemovalOK</c>, the application should call CM_Request_Device_Eject instead
	/// of <c>CM_Query_And_Remove_SubTree</c>.
	/// </para>
	/// <para>
	/// <c>CM_Query_And_Remove_SubTree</c> supports setting the flags parameter ulFlags with one of the following two flags; these flags
	/// apply only if Windows or an installer vetoes the removal of a device:
	/// </para>
	/// <para>
	/// Beginning with Windows XP, <c>CM_Query_And_Remove_SubTree</c> also supports setting the following additional flag; this flag
	/// applies only if the function successfully removes the device instance:
	/// </para>
	/// <para>
	/// Windows applications that do not require the low-level operation <c>CM_Query_And_Remove_SubTree</c> should use the
	/// DIF_PROPERTYCHANGE request to disable a device instead of using <c>CM_Query_And_Remove_SubTree</c> to remove a device. The
	/// DIF_PROPERTYCHANGE request can be used to enable, disable, restart, stop, or change the properties of a device.
	/// </para>
	/// <para>
	/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
	/// </para>
	/// <para>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_query_and_remove_subtreew CMAPI CONFIGRET
	// CM_Query_And_Remove_SubTreeW( DEVINST dnAncestor, PPNP_VETO_TYPE pVetoType, StrPtrUni pszVetoName, ULONG ulNameLength, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Query_And_Remove_SubTreeW")]
	public static extern CONFIGRET CM_Query_And_Remove_SubTree(uint dnAncestor, out PNP_VETO_TYPE pVetoType,
		[Optional, SizeDef(nameof(ulNameLength), SizingMethod.InclNullTerm)] StringBuilder? pszVetoName, [Range(0, Kernel32.MAX_PATH)] uint ulNameLength, CM_REMOVE ulFlags);

	/// <summary>
	/// The <c>CM_Query_And_Remove_SubTree</c> function checks whether a device instance and its children can be removed and, if so, it
	/// removes them.
	/// </summary>
	/// <param name="dnAncestor">
	/// Caller-supplied device instance handle to the device at the root of the subtree to be removed. This device instance handle is
	/// bound to the local machine.
	/// </param>
	/// <param name="pVetoType">
	/// (Optional) If the caller does not pass <c>NULL</c> and the removal request is vetoed (that is, the function returns
	/// CR_REMOVE_VETOED), on return this points to a PNP_VETO_TYPE-typed value that indicates the reason for the veto.
	/// </param>
	/// <param name="pszVetoName">
	/// (Optional) If the caller does not pass <c>NULL</c> and the removal request is vetoed (that is, the function returns
	/// CR_REMOVE_VETOED), on return this points to a text string that is associated with the veto type. The type of information this
	/// string provides is dependent on the value received by pVetoType. For information about these strings, see PNP_VETO_TYPE.
	/// </param>
	/// <param name="ulNameLength">
	/// Caller-supplied value representing the length (number of characters) of the string buffer supplied by pszVetoName. This should
	/// be set to MAX_PATH.
	/// </param>
	/// <param name="ulFlags">A bitwise OR of the caller-supplied flag constants that are described in the <c>Remarks</c> section.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the other CR_-prefixed error codes
	/// defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The purpose of the <c>CM_Query_And_Remove_SubTree</c> function is to allow an application to prepare a device for safe removal
	/// from the local machine. Use this function to remove devices only if a driver has not set the <c>SurpriseRemovalOK</c> member of
	/// DEVICE_CAPABILITIES. If a driver has set <c>SurpriseRemovalOK</c>, the application should call CM_Request_Device_Eject instead
	/// of <c>CM_Query_And_Remove_SubTree</c>.
	/// </para>
	/// <para>
	/// <c>CM_Query_And_Remove_SubTree</c> supports setting the flags parameter ulFlags with one of the following two flags; these flags
	/// apply only if Windows or an installer vetoes the removal of a device:
	/// </para>
	/// <para>
	/// Beginning with Windows XP, <c>CM_Query_And_Remove_SubTree</c> also supports setting the following additional flag; this flag
	/// applies only if the function successfully removes the device instance:
	/// </para>
	/// <para>
	/// Windows applications that do not require the low-level operation <c>CM_Query_And_Remove_SubTree</c> should use the
	/// DIF_PROPERTYCHANGE request to disable a device instead of using <c>CM_Query_And_Remove_SubTree</c> to remove a device. The
	/// DIF_PROPERTYCHANGE request can be used to enable, disable, restart, stop, or change the properties of a device.
	/// </para>
	/// <para>
	/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
	/// </para>
	/// <para>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_query_and_remove_subtreew CMAPI CONFIGRET
	// CM_Query_And_Remove_SubTreeW( DEVINST dnAncestor, PPNP_VETO_TYPE pVetoType, StrPtrUni pszVetoName, ULONG ulNameLength, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Query_And_Remove_SubTreeW")]
	public static extern CONFIGRET CM_Query_And_Remove_SubTree(uint dnAncestor, [In, Optional] IntPtr pVetoType,
		[Optional, SizeDef(nameof(ulNameLength), SizingMethod.InclNullTerm)] StringBuilder? pszVetoName, [Range(0, Kernel32.MAX_PATH)] uint ulNameLength, CM_REMOVE ulFlags);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Query_And_Remove_SubTree instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Query_And_Remove_SubTree_Ex</c> function checks whether a device instance and its children can be removed and, if so,
	/// it removes them.
	/// </para>
	/// </summary>
	/// <param name="dnAncestor">
	/// Caller-supplied device instance handle to the device at the root of the subtree to be removed. This device instance handle is
	/// bound to the machine handle supplied by hMachine.
	/// </param>
	/// <param name="pVetoType">
	/// (Optional) If the caller does not pass <c>NULL</c> and the removal request is vetoed (that is, the function returns
	/// CR_REMOVE_VETOED), on return this points to a PNP_VETO_TYPE-typed value that indicates the reason for the veto.
	/// </param>
	/// <param name="pszVetoName">
	/// (Optional) If the caller does not pass <c>NULL</c> and the removal request is vetoed (that is, the function returns
	/// CR_REMOVE_VETOED), on return this points to a text string that is associated with the veto type. The type of information this
	/// string provides is dependent on the value received by pVetoType. For information about these strings, see PNP_VETO_TYPE.
	/// </param>
	/// <param name="ulNameLength">
	/// (Optional.) Caller-supplied value representing the length (number of characters) of the string buffer supplied by pszVetoName.
	/// This should be set to MAX_PATH.
	/// </param>
	/// <param name="ulFlags">A bitwise OR of the caller-supplied flag constants that are described in the <c>Remarks</c> section.</param>
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
	/// The purpose of the <c>CM_Query_And_Remove_SubTree_Ex</c> function is to allow an application to prepare a device for safe
	/// removal from a remote machine. Use this function to remove devices only if a driver has not set the <c>SurpriseRemovalOK</c>
	/// member of DEVICE_CAPABILITIES. If a driver has set <c>SurpriseRemovalOK</c>, the application should call
	/// CM_Request_Device_Eject_Ex instead of <c>CM_Query_And_Remove_SubTree_Ex</c>.
	/// </para>
	/// <para>
	/// <c>CM_Query_And_Remove_SubTree_Ex</c> supports setting the flags parameter ulFlags with one of the following two flags; these
	/// flags apply only if Windows or an installer vetoes the removal of a device:
	/// </para>
	/// <para>
	/// Beginning with Windows XP, <c>CM_Query_And_Remove_SubTree_Ex</c> also supports setting the following additional flag; this flag
	/// applies only if the function successfully removes the device instance:
	/// </para>
	/// <para>
	/// Device installation applications that do not require the low-level operation of <c>CM_Query_And_Remove_SubTree_Ex</c> should use
	/// the DIF_PROPERTYCHANGE request to disable a device instead of using <c>CM_Query_And_Remove_SubTree_Ex</c> to remove a device.
	/// The DIF_PROPERTYCHANGE request can be used to enable, disable, restart, stop, or change the properties of a device.
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
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_query_and_remove_subtree_exw CMAPI CONFIGRET
	// CM_Query_And_Remove_SubTree_ExW( DEVINST dnAncestor, PPNP_VETO_TYPE pVetoType, StrPtrUni pszVetoName, ULONG ulNameLength, ULONG
	// ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Query_And_Remove_SubTree_ExW")]
	public static extern CONFIGRET CM_Query_And_Remove_SubTree_Ex(uint dnAncestor, out PNP_VETO_TYPE pVetoType,
		[Optional, SizeDef(nameof(ulNameLength), SizingMethod.InclNullTerm)] StringBuilder? pszVetoName,
		[Range(0, Kernel32.MAX_PATH)] uint ulNameLength, CM_REMOVE ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Query_And_Remove_SubTree instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Query_And_Remove_SubTree_Ex</c> function checks whether a device instance and its children can be removed and, if so,
	/// it removes them.
	/// </para>
	/// </summary>
	/// <param name="dnAncestor">
	/// Caller-supplied device instance handle to the device at the root of the subtree to be removed. This device instance handle is
	/// bound to the machine handle supplied by hMachine.
	/// </param>
	/// <param name="pVetoType">
	/// (Optional) If the caller does not pass <c>NULL</c> and the removal request is vetoed (that is, the function returns
	/// CR_REMOVE_VETOED), on return this points to a PNP_VETO_TYPE-typed value that indicates the reason for the veto.
	/// </param>
	/// <param name="pszVetoName">
	/// (Optional) If the caller does not pass <c>NULL</c> and the removal request is vetoed (that is, the function returns
	/// CR_REMOVE_VETOED), on return this points to a text string that is associated with the veto type. The type of information this
	/// string provides is dependent on the value received by pVetoType. For information about these strings, see PNP_VETO_TYPE.
	/// </param>
	/// <param name="ulNameLength">
	/// (Optional.) Caller-supplied value representing the length (number of characters) of the string buffer supplied by pszVetoName.
	/// This should be set to MAX_PATH.
	/// </param>
	/// <param name="ulFlags">A bitwise OR of the caller-supplied flag constants that are described in the <c>Remarks</c> section.</param>
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
	/// The purpose of the <c>CM_Query_And_Remove_SubTree_Ex</c> function is to allow an application to prepare a device for safe
	/// removal from a remote machine. Use this function to remove devices only if a driver has not set the <c>SurpriseRemovalOK</c>
	/// member of DEVICE_CAPABILITIES. If a driver has set <c>SurpriseRemovalOK</c>, the application should call
	/// CM_Request_Device_Eject_Ex instead of <c>CM_Query_And_Remove_SubTree_Ex</c>.
	/// </para>
	/// <para>
	/// <c>CM_Query_And_Remove_SubTree_Ex</c> supports setting the flags parameter ulFlags with one of the following two flags; these
	/// flags apply only if Windows or an installer vetoes the removal of a device:
	/// </para>
	/// <para>
	/// Beginning with Windows XP, <c>CM_Query_And_Remove_SubTree_Ex</c> also supports setting the following additional flag; this flag
	/// applies only if the function successfully removes the device instance:
	/// </para>
	/// <para>
	/// Device installation applications that do not require the low-level operation of <c>CM_Query_And_Remove_SubTree_Ex</c> should use
	/// the DIF_PROPERTYCHANGE request to disable a device instead of using <c>CM_Query_And_Remove_SubTree_Ex</c> to remove a device.
	/// The DIF_PROPERTYCHANGE request can be used to enable, disable, restart, stop, or change the properties of a device.
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
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_query_and_remove_subtree_exw CMAPI CONFIGRET
	// CM_Query_And_Remove_SubTree_ExW( DEVINST dnAncestor, PPNP_VETO_TYPE pVetoType, StrPtrUni pszVetoName, ULONG ulNameLength, ULONG
	// ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Query_And_Remove_SubTree_ExW")]
	public static extern CONFIGRET CM_Query_And_Remove_SubTree_Ex(uint dnAncestor, [In, Optional] IntPtr pVetoType,
		[Optional, SizeDef(nameof(ulNameLength), SizingMethod.InclNullTerm)] StringBuilder? pszVetoName,
		[Range(0, Kernel32.MAX_PATH)] uint ulNameLength, CM_REMOVE ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Query_Resource_Conflict_List</c> function identifies device instances having resource requirements that conflict with
	/// a specified device instance's resource description.
	/// </summary>
	/// <param name="pclConflictList">Caller-supplied address of a location to receive a handle to a conflict list.</param>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the machine handle supplied by hMachine.</param>
	/// <param name="ResourceID">
	/// Caller-supplied resource type identifier. This must be one of the <c>ResType_</c>-prefixed constants defined in Cfgmgr32.h.
	/// </param>
	/// <param name="ResourceData">
	/// Caller-supplied pointer to a resource descriptor, which can be one of the structures listed under the CM_Add_Res_Des function's
	/// description of ResourceData.
	/// </param>
	/// <param name="ResourceLen">Caller-supplied length of the structure pointed to by ResourceData.</param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <param name="hMachine">Caller-supplied machine handle to which the caller-supplied device instance handle is bound.</param>
	/// <returns>
	/// <para>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Query_Resource_Conflict_List</c> returns CR_CALL_NOT_IMPLEMENTED when used in a Wow64
	/// scenario. To request information about the hardware resources on a local machine it is necessary implement an
	/// architecture-native version of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When calling <c>CM_Query_Resource_Conflict_List</c>, specify a device instance handle and resource descriptor. (Resource
	/// descriptors for existing device nodes can be obtained by calling CM_Get_Res_Des_Data.) These parameters indicate the specific
	/// resources you'd like a specific device to use. The resulting conflict list identifies devices that use the same resources, along
	/// with resources reserved by the machine.
	/// </para>
	/// <para>
	/// After calling <c>CM_Query_Resource_Conflict_List</c>, an application can call CM_Get_Resource_Conflict_Count to determine the
	/// number of conflicts contained in the resource conflict list. (The number of conflicts can be zero.) Then the application can
	/// call CM_Get_Resource_Conflict_Details for each entry in the conflict list.
	/// </para>
	/// <para>After an application has finished using the handle received for pclConflictList, it must call CM_Free_Resource_Conflict_Handle.</para>
	/// <para>For information about using device instance handles that are bound to a local or a remote machine, see CM_Get_Child_Ex.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_query_resource_conflict_list CMAPI CONFIGRET
	// CM_Query_Resource_Conflict_List( PCONFLICT_LIST pclConflictList, DEVINST dnDevInst, RESOURCEID ResourceID, PCVOID ResourceData,
	// ULONG ResourceLen, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Query_Resource_Conflict_List")]
	public static extern CONFIGRET CM_Query_Resource_Conflict_List(out SafeCONFLICT_LIST pclConflictList, uint dnDevInst, RESOURCEID ResourceID, [In] IntPtr ResourceData,
		uint ResourceLen, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Query_Resource_Conflict_List</c> function identifies device instances having resource requirements that conflict with
	/// a specified device instance's resource description.
	/// </summary>
	/// <typeparam name="T">The type of the supplied data.</typeparam>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the machine handle supplied by hMachine.</param>
	/// <param name="data">
	/// Caller-supplied pointer to a resource descriptor, which can be one of the structures listed under the CM_Add_Res_Des function's
	/// description of ResourceData.
	/// </param>
	/// <param name="ResourceID">
	/// Caller-supplied resource type identifier. If <c>0</c>, then the <see cref="RESOURCEID"/> is determined by <typeparamref name="T"/>.
	/// </param>
	/// <returns>
	/// <para>A handle to a conflict list.</para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, <c>CM_Query_Resource_Conflict_List</c> throws CR_CALL_NOT_IMPLEMENTED when used in a Wow64
	/// scenario. To request information about the hardware resources on a local machine it is necessary implement an
	/// architecture-native version of the application using the hardware resource APIs. For example: An AMD64 application for AMD64 systems.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When calling <c>CM_Query_Resource_Conflict_List</c>, specify a device instance handle and resource descriptor. (Resource
	/// descriptors for existing device nodes can be obtained by calling CM_Get_Res_Des_Data.) These parameters indicate the specific
	/// resources you'd like a specific device to use. The resulting conflict list identifies devices that use the same resources, along
	/// with resources reserved by the machine.
	/// </para>
	/// <para>
	/// After calling <c>CM_Query_Resource_Conflict_List</c>, an application can call CM_Get_Resource_Conflict_Count to determine the
	/// number of conflicts contained in the resource conflict list. (The number of conflicts can be zero.) Then the application can
	/// call CM_Get_Resource_Conflict_Details for each entry in the conflict list.
	/// </para>
	/// <para>For information about using device instance handles that are bound to a local or a remote machine, see CM_Get_Child_Ex.</para>
	/// </remarks>
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Query_Resource_Conflict_List")]
	public static SafeCONFLICT_LIST CM_Query_Resource_Conflict_List<T>(uint dnDevInst, T data, RESOURCEID ResourceID = 0) where T : struct
	{
		if (ResourceID == 0 && !CorrespondingTypeAttribute.CanSet<T, RESOURCEID>(out ResourceID))
			throw new ArgumentException("Unable to determine RESOURCEID from type.", nameof(T));
		using var mem = new SafeAnysizeStruct<T>(data);
		CM_Query_Resource_Conflict_List(out var hcl, dnDevInst, ResourceID, mem, mem.Size).ThrowIfFailed();
		return hcl;
	}

	/// <summary>
	/// The <c>CM_Reenumerate_DevNode</c> function enumerates the devices identified by a specified device node and all of its children.
	/// </summary>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
	/// <param name="ulFlags">
	/// <para>
	/// Caller-supplied flags that specify how reenumeration should occur. This parameter can be set to a combination of the following
	/// flags, as noted:
	/// </para>
	/// <para>CM_REENUMERATE_ASYNCHRONOUS</para>
	/// <para>
	/// Reenumeration should occur asynchronously. The call to this function returns immediately after the PnP manager receives the
	/// reenumeration request. If this flag is set, the CM_REENUMERATE_SYNCHRONOUS flag should not also be set.
	/// </para>
	/// <para>CM_REENUMERATE_NORMAL</para>
	/// <para>
	/// Specifies default reenumeration behavior, in which reenumeration occurs synchronously. This flag is functionally equivalent to CM_REENUMERATE_SYNCHRONOUS.
	/// </para>
	/// <para>CM_REENUMERATE_RETRY_INSTALLATION</para>
	/// <para>
	/// Specifies that Plug and Play should make another attempt to install any devices in the specified subtree that have been detected
	/// but are not yet configured, or are marked as needing reinstallation, or for which installation must be completed. This flag can
	/// be set along with either the CM_REENUMERATE_SYNCHRONOUS flag or the CM_REENUMERATE_ASYNCHRONOUS flag.
	/// </para>
	/// <para>
	/// This flag must be used with extreme caution, because it can cause the PnP manager to prompt the user to perform installation of
	/// any such devices. Currently, only components such as Device Manager and Hardware Wizard use this flag, to allow the user to
	/// retry installation of devices that might already have been detected but are not currently installed.
	/// </para>
	/// <para>CM_REENUMERATE_SYNCHRONOUS</para>
	/// <para>
	/// Reenumeration should occur synchronously. The call to this function returns when all devices in the specified subtree have been
	/// reenumerated. If this flag is set, the CM_REENUMERATE_ASYNCHRONOUS flag should not also be set. This flag is functionally
	/// equivalent to CM_REENUMERATE_NORMAL.
	/// </para>
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the specified device node represents a hardware or software bus device, the PnP manager queries the device's drivers for a
	/// list of children, then attempts to configure and start any child devices that were not previously configured. The PnP manager
	/// also initiates surprise-removal of devices that are no longer present (see IRP_MN_SURPRISE_REMOVAL).
	/// </para>
	/// <para>
	/// Callers of this function must have <c>SeLoadDriverPrivilege</c>. (Privileges are described in the Microsoft Windows SDK documentation.)
	/// </para>
	/// <para>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_reenumerate_devnode CMAPI CONFIGRET
	// CM_Reenumerate_DevNode( DEVINST dnDevInst, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Reenumerate_DevNode")]
	public static extern CONFIGRET CM_Reenumerate_DevNode(uint dnDevInst, CM_REENUMERATE ulFlags);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Reenumerate_DevNode instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Reenumerate_DevNode_Ex</c> function enumerates the devices identified by a specified device node and all of its children.
	/// </para>
	/// </summary>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the machine handle supplied by hMachine.</param>
	/// <param name="ulFlags">
	/// <para>
	/// Caller-supplied flags that specify how reenumeration should occur. This parameter can be set to a combination of the following
	/// flags, as noted:
	/// </para>
	/// <para>CM_REENUMERATE_ASYNCHRONOUS</para>
	/// <para>
	/// Reenumeration should occur asynchronously. The call to this function returns immediately after the PnP manager receives the
	/// reenumeration request. If this flag is set, the CM_REENUMERATE_SYNCHRONOUS flag should not also be set.
	/// </para>
	/// <para>CM_REENUMERATE_NORMAL</para>
	/// <para>
	/// Specifies default reenumeration behavior, in which reenumeration occurs synchronously. This flag is currently equivalent to CM_REENUMERATE_SYNCHRONOUS.
	/// </para>
	/// <para>CM_REENUMERATE_RETRY_INSTALLATION</para>
	/// <para>
	/// Specifies that Plug and Play should make another attempt to install any devices in the specified subtree that have been detected
	/// but are not yet configured, or are marked as needing reinstallation, or for which installation must be completed. This flag can
	/// be set along with either the CM_REENUMERATE_SYNCHRONOUS flag or the CM_REENUMERATE_ASYNCHRONOUS flag.
	/// </para>
	/// <para>
	/// This flag must be used with extreme caution, because it can cause the PnP manager to prompt the user to perform installation of
	/// any such devices. Currently, only components such as Device Manager and Hardware Wizard use this flag, to allow the user to
	/// retry installation of devices that might already have been detected but are not currently installed.
	/// </para>
	/// <para>CM_REENUMERATE_SYNCHRONOUS</para>
	/// <para>
	/// Reenumeration should occur synchronously. The call to this function returns when all devices in the specified subtree have been
	/// reenumerated. If this flag is set, the CM_REENUMERATE_ASYNCHRONOUS flag should not also be set. This flag is currently
	/// equivalent to CM_REENUMERATE_NORMAL.
	/// </para>
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
	/// If the specified device node represents a hardware or software bus device, the PnP manager queries the device's drivers for a
	/// list of children, then attempts to configure and start any child devices that were not previously configured. The PnP manager
	/// also initiates surprise-removal of devices that are no longer present (see IRP_MN_SURPRISE_REMOVAL).
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
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_reenumerate_devnode_ex CMAPI CONFIGRET
	// CM_Reenumerate_DevNode_Ex( DEVINST dnDevInst, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Reenumerate_DevNode_Ex")]
	public static extern CONFIGRET CM_Reenumerate_DevNode_Ex(uint dnDevInst, CM_REENUMERATE ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// <para>
	/// Use RegisterDeviceNotification instead of <c>CM_Register_Notification</c> if your code targets Windows 7 or earlier versions of
	/// Windows. Kernel mode callers should use IoRegisterPlugPlayNotification instead.
	/// </para>
	/// <para>
	/// The <c>CM_Register_Notification</c> function registers an application callback routine to be called when a PnP event of the
	/// specified type occurs.
	/// </para>
	/// </summary>
	/// <param name="pFilter">Pointer to a CM_NOTIFY_FILTER structure.</param>
	/// <param name="pContext">
	/// Pointer to a caller-allocated buffer containing the context to be passed to the callback routine in pCallback.
	/// </param>
	/// <param name="pCallback">
	/// <para>
	/// Pointer to the routine to be called when the specified PnP event occurs. See the <c>Remarks</c> section for the callback
	/// function's prototype.
	/// </para>
	/// <para>The callback routine’s Action parameter will be a value from the CM_NOTIFY_ACTION enumeration.</para>
	/// <para>
	/// Upon receiving a notification, how the callback examines the notification will depend on the <c>FilterType</c> member of the
	/// callback routine's EventData parameter:
	/// </para>
	/// <para>CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE</para>
	/// <para>The callback should examine <c>EventData-&gt;u.DeviceInterface</c>.</para>
	/// <para>CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE</para>
	/// <para>The callback should examine <c>EventData-&gt;u.DeviceHandle</c>.</para>
	/// <para>CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE</para>
	/// <para>The callback should examine <c>EventData-&gt;u.DeviceInstance</c>.</para>
	/// </param>
	/// <param name="pNotifyContext">Pointer to receive the HCMNOTIFICATION handle that corresponds to the registration call.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Be sure to handle Plug and Play device events as quickly as possible. If your event handler performs any operation that may
	/// block execution (such as I/O), it is best to start another thread to perform the operation asynchronously.
	/// </para>
	/// <para>
	/// The <c>CM_Register_Notification</c> function does not provide notification of existing device interfaces. To retrieve existing
	/// interfaces, first call <c>CM_Register_Notification</c>, and then call CM_Get_Device_Interface_List. If the interface is enabled
	/// after your driver calls <c>CM_Register_Notification</c>, but before your driver calls <c>CM_Get_Device_Interface_List</c>, the
	/// driver receives a notification for the interface arrival, and the interface also appears in the list of device interface
	/// instances returned by <c>CM_Get_Device_Interface_List</c>.
	/// </para>
	/// <para>
	/// HCMNOTIFICATION handles returned by <c>CM_Register_Notification</c> must be closed by calling the CM_Unregister_Notification
	/// function when they are no longer needed.
	/// </para>
	/// <para>A callback routine uses the following function prototype:</para>
	/// <para>
	/// <code>typedef __callback DWORD (CALLBACK *PCM_NOTIFY_CALLBACK)( _In_ HCMNOTIFICATION hNotify, _In_opt_ PVOID Context, _In_ CM_NOTIFY_ACTION Action, _In_reads_bytes_(EventDataSize) PCM_NOTIFY_EVENT_DATA EventData, _In_ DWORD EventDataSize );</code>
	/// </para>
	/// <para>
	/// If responding to a <c>CM_NOTIFY_ACTION_DEVICEQUERYREMOVE</c> notification, the PCM_NOTIFY_CALLBACK callback should return either
	/// ERROR_SUCCESS or ERROR_CANCELLED, as appropriate. Otherwise, the callback should return ERROR_SUCCESS. The callback should not
	/// return any other values. For a description of other actions, please refer to the CM_NOTIFY_ACTION documentation. Also see
	/// CM_NOTIFY_EVENT_DATA for information about the structure that this callback receives in the EventData parameter.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Registering for Notification of Device Interface Arrival and Device Removal.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_register_notification CMAPI CONFIGRET
	// CM_Register_Notification( PCM_NOTIFY_FILTER pFilter, PVOID pContext, PCM_NOTIFY_CALLBACK pCallback, PHCMNOTIFICATION
	// pNotifyContext );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Register_Notification")]
	public static extern CONFIGRET CM_Register_Notification(in CM_NOTIFY_FILTER pFilter, [In, Optional] IntPtr pContext, CM_NOTIFY_CALLBACK pCallback, out SafeHCMNOTIFICATION pNotifyContext);

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
	// CM_Request_Device_EjectW( DEVINST dnDevInst, PPNP_VETO_TYPE pVetoType, StrPtrUni pszVetoName, ULONG ulNameLength, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Request_Device_EjectW")]
	public static extern CONFIGRET CM_Request_Device_Eject(uint dnDevInst, out PNP_VETO_TYPE pVetoType,
		[Out, SizeDef(nameof(ulNameLength), SizingMethod.InclNullTerm)] StringBuilder? pszVetoName,
		[Range(0, Kernel32.MAX_PATH)] uint ulNameLength, [Optional, Ignore] uint ulFlags);

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
	// CM_Request_Device_EjectW( DEVINST dnDevInst, PPNP_VETO_TYPE pVetoType, StrPtrUni pszVetoName, ULONG ulNameLength, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Request_Device_EjectW")]
	public static extern CONFIGRET CM_Request_Device_Eject(uint dnDevInst, [In, Optional] IntPtr pVetoType,
		[Out, SizeDef(nameof(ulNameLength), SizingMethod.InclNullTerm)] StringBuilder? pszVetoName,
		[Range(0, Kernel32.MAX_PATH)] uint ulNameLength, [Optional, Ignore] uint ulFlags);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Request_Device_Eject instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Request_Device_Eject_Ex</c> function prepares a local or a remote device instance for safe removal, if the device is
	/// removable. If the device can be physically ejected, it will be.
	/// </para>
	/// </summary>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the machine handle supplied by hMachine.</param>
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
	/// If pszVetoName is <c>NULL</c>, the PnP manager displays a message to the user indicating the device was removed or, if the
	/// request failed, identifying the reason for the failure. If pszVetoName is not <c>NULL</c>, the PnP manager does not display a
	/// message. (Note, however, that for Microsoft Windows 2000 only, the PnP manager displays a message even if pszVetoName is not
	/// <c>NULL</c>, if the device's CM_DEVCAP_DOCKDEVICE capability is set.)
	/// </para>
	/// <para>
	/// For remote machines, this function only works for "dock" device instances. That is, the function can only be used remotely to
	/// undock a machine. In that case, the caller must have <c>SeUndockPrivilege</c>.
	/// </para>
	/// <para>Callers of <c>CM_Request_Eject_Ex</c> sometimes require <c>SeUndockPrivilege</c> or <c>SeLoadDriverPrivilege</c>, as follows:</para>
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
	/// remote Terminal Services session) callers of this function must have <c>SeLoadDriverPrivilege</c>.
	/// </term>
	/// </item>
	/// </list>
	/// <para>(Privileges are described in the Microsoft Windows SDK documentation.)</para>
	/// <para>For information about using device instance handles that are bound to a local or a remote machine, see CM_Get_Child_Ex.</para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_request_device_eject_exw CMAPI CONFIGRET
	// CM_Request_Device_Eject_ExW( DEVINST dnDevInst, PPNP_VETO_TYPE pVetoType, StrPtrUni pszVetoName, ULONG ulNameLength, ULONG ulFlags,
	// HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Request_Device_Eject_ExW")]
	public static extern CONFIGRET CM_Request_Device_Eject_Ex(uint dnDevInst, out PNP_VETO_TYPE pVetoType,
		[Out, SizeDef(nameof(ulNameLength), SizingMethod.InclNullTerm)] StringBuilder? pszVetoName,
		[Range(0, Kernel32.MAX_PATH)] uint ulNameLength, [Optional, Ignore] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Request_Device_Eject instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Request_Device_Eject_Ex</c> function prepares a local or a remote device instance for safe removal, if the device is
	/// removable. If the device can be physically ejected, it will be.
	/// </para>
	/// </summary>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the machine handle supplied by hMachine.</param>
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
	/// If pszVetoName is <c>NULL</c>, the PnP manager displays a message to the user indicating the device was removed or, if the
	/// request failed, identifying the reason for the failure. If pszVetoName is not <c>NULL</c>, the PnP manager does not display a
	/// message. (Note, however, that for Microsoft Windows 2000 only, the PnP manager displays a message even if pszVetoName is not
	/// <c>NULL</c>, if the device's CM_DEVCAP_DOCKDEVICE capability is set.)
	/// </para>
	/// <para>
	/// For remote machines, this function only works for "dock" device instances. That is, the function can only be used remotely to
	/// undock a machine. In that case, the caller must have <c>SeUndockPrivilege</c>.
	/// </para>
	/// <para>Callers of <c>CM_Request_Eject_Ex</c> sometimes require <c>SeUndockPrivilege</c> or <c>SeLoadDriverPrivilege</c>, as follows:</para>
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
	/// remote Terminal Services session) callers of this function must have <c>SeLoadDriverPrivilege</c>.
	/// </term>
	/// </item>
	/// </list>
	/// <para>(Privileges are described in the Microsoft Windows SDK documentation.)</para>
	/// <para>For information about using device instance handles that are bound to a local or a remote machine, see CM_Get_Child_Ex.</para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_request_device_eject_exw CMAPI CONFIGRET
	// CM_Request_Device_Eject_ExW( DEVINST dnDevInst, PPNP_VETO_TYPE pVetoType, StrPtrUni pszVetoName, ULONG ulNameLength, ULONG ulFlags,
	// HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Request_Device_Eject_ExW")]
	public static extern CONFIGRET CM_Request_Device_Eject_Ex(uint dnDevInst, [In, Optional] IntPtr pVetoType,
		[Out, SizeDef(nameof(ulNameLength), SizingMethod.InclNullTerm)] StringBuilder? pszVetoName,
		[Range(0, Kernel32.MAX_PATH)] uint ulNameLength, [Optional, Ignore] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>
	/// The <c>CM_Request_Eject_PC</c> function requests that a portable PC, which is inserted in a local docking station, be ejected.
	/// </summary>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, the function returns one of the CR_-prefixed error codes
	/// that are defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use this function to request that a portable PC, which is inserted in a local docking station, be ejected. You can also use the
	/// following related functions with docking stations:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// <para>CM_Is_Dock_Station_Present identifies whether a docking station is present in a local machine.</para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>CM_Is_Dock_Station_Present_Ex identifies whether a docking station is present in a local or a remote machine.</para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>CM_Request_Eject_PC_Ex requests that a portable PC, which is inserted in a local or a remote docking station, be ejected.</para>
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_request_eject_pc CMAPI CONFIGRET CM_Request_Eject_PC();
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Request_Eject_PC")]
	public static extern CONFIGRET CM_Request_Eject_PC();

	/// <summary>
	/// <para>[Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Request_Eject_PC instead.]</para>
	/// <para>
	/// The <c>CM_Request_Eject_PC_Ex</c> function requests that a portable PC, which is inserted in a local or a remote docking
	/// station, be ejected.
	/// </para>
	/// </summary>
	/// <param name="hMachine">
	/// <para>Supplies a machine handle that is returned by CM_Connect_Machine.</para>
	/// <para>
	/// <c>Note</c> Using this function to access remote machines is not supported beginning with Windows 8 and Windows Server 2012, as
	/// this functionality has been removed.
	/// </para>
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, the function returns one of the CR_-prefixed error codes
	/// that are defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use this function to request that a portable PC, which is inserted in a local or a remote docking station, be ejected. You can
	/// also use the following related functions with docking stations:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// <para>CM_Is_Dock_Station_Present identifies whether a docking station is present in a local machine.</para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>CM_Is_Dock_Station_Present_Ex identifies whether a docking station is present in a local or a remote machine.</para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>CM_Request_Eject_PC requests that a portable PC, which is inserted in a local docking station, be ejected.</para>
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_request_eject_pc_ex CMAPI CONFIGRET
	// CM_Request_Eject_PC_Ex( HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Request_Eject_PC_Ex")]
	public static extern CONFIGRET CM_Request_Eject_PC_Ex([In, Optional] HMACHINE hMachine);

	/// <summary>The <c>CM_Set_Class_Property</c> function sets a class property for a device setup class or a device interface class.</summary>
	/// <param name="ClassGUID">
	/// Pointer to the GUID that identifies the device interface class or device setup class for which to set a device property. For
	/// information about specifying the class type, see the ulFlags parameter.
	/// </param>
	/// <param name="PropertyKey">
	/// Pointer to a DEVPROPKEY structure that represents the property key of the device class property to set.
	/// </param>
	/// <param name="PropertyType">
	/// A DEVPROPTYPE-typed value that represents the property-data-type identifier for the device class property. To delete a property,
	/// set this to DEVPROP_TYPE_EMPTY.
	/// </param>
	/// <param name="PropertyBuffer">
	/// Pointer to a buffer that contains the property value of the device class property. If either the property or the data is to be
	/// deleted, this pointer must be set to NULL, and PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to NULL, PropertyBufferSize must be set to zero.
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
	/// <remarks><c>CM_Set_Class_Property</c> is part of the Unified Device Property Model.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_set_class_propertyw CMAPI CONFIGRET
	// CM_Set_Class_PropertyW( LPCGUID ClassGUID, const DEVPROPKEY *PropertyKey, DEVPROPTYPE PropertyType, const PBYTE PropertyBuffer,
	// ULONG PropertyBufferSize, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Set_Class_PropertyW")]
	public static extern CONFIGRET CM_Set_Class_Property(in Guid ClassGUID, in DEVPROPKEY PropertyKey, DEVPROPTYPE PropertyType,
		[In, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Set_Class_Property instead.]
	/// </para>
	/// <para>The <c>CM_Set_Class_Property_ExW</c> function sets a class property for a device setup class or a device interface class.</para>
	/// </summary>
	/// <param name="ClassGUID">
	/// Pointer to the GUID that identifies the device interface class or device setup class for which to set a device property. For
	/// information about specifying the class type, see the ulFlags parameter.
	/// </param>
	/// <param name="PropertyKey">
	/// Pointer to a DEVPROPKEY structure that represents the property key of the device class property to set.
	/// </param>
	/// <param name="PropertyType">
	/// A DEVPROPTYPE-typed value that represents the property-data-type identifier for the device class property. To delete a property,
	/// set this to <c>DEVPROP_TYPE_EMPTY</c>.
	/// </param>
	/// <param name="PropertyBuffer">
	/// Pointer to a buffer that contains the property value of the device class property. If either the property or the data is to be
	/// deleted, this pointer must be set to NULL, and PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to NULL, PropertyBufferSize must be set to zero.
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
	/// <remarks><c>CM_Set_Class_Property_ExW</c> is part of the Unified Device Property Model.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_set_class_property_exw CMAPI CONFIGRET
	// CM_Set_Class_Property_ExW( LPCGUID ClassGUID, const DEVPROPKEY *PropertyKey, DEVPROPTYPE PropertyType, const PBYTE
	// PropertyBuffer, ULONG PropertyBufferSize, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Set_Class_Property_ExW")]
	public static extern CONFIGRET CM_Set_Class_Property_Ex(in Guid ClassGUID, in DEVPROPKEY PropertyKey, DEVPROPTYPE PropertyType,
		[In, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, CM_CLASS_PROPERTY ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>The <c>CM_Set_Class_Registry_Property</c> function sets or deletes a property of a device setup class.</summary>
	/// <param name="ClassGuid">A pointer to the GUID that represents the device setup class for which to set a property.</param>
	/// <param name="ulProperty">
	/// A value of type ULONG that identifies the property to set. This value must be one of the CM_CRP_Xxx values that are described
	/// for the ulProperty parameter of the CM_Get_Class_Registry_Property function.
	/// </param>
	/// <param name="Buffer">
	/// A pointer to a buffer that contains the property data. This parameter is optional and can be set to <c>NULL</c>. For more
	/// information about setting this parameter and the corresponding ulLength parameter, see the following <c>Remarks</c> section.
	/// </param>
	/// <param name="ulLength">A value of type ULONG that specifies the size, in bytes, of the property data.</param>
	/// <param name="ulFlags">Reserved for internal use only. Must be set to zero.</param>
	/// <param name="hMachine">
	/// A handle to a remote machine on which to set the specified device setup class property. This parameter is optional. If set to
	/// <c>NULL</c>, the property is set on the local machine.
	/// </param>
	/// <returns>
	/// If the operation succeeds, <c>CM_Set_Class_Registry_Property</c> returns CR_SUCCESS. Otherwise, the function returns one of the
	/// other CR_Xxx status codes that are defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>If Buffer is <c>NULL</c>, ulLength must be set to zero.</para>
	/// <para>If ulLength is set to zero, the function deletes the property.</para>
	/// <para>
	/// If Buffer is not set to <c>NULL</c> and ulLength is not set to zero, the supplied value must be the correct size for the REG_Xxx
	/// data type for the property that is specified in ulProperty.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_set_class_registry_propertyw CMAPI CONFIGRET
	// CM_Set_Class_Registry_PropertyW( LPGUID ClassGuid, ULONG ulProperty, PCVOID Buffer, ULONG ulLength, ULONG ulFlags, HMACHINE
	// hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Set_Class_Registry_PropertyW")]
	public static extern CONFIGRET CM_Set_Class_Registry_Property(in Guid ClassGuid, CM_CRP ulProperty, [In, Optional] IntPtr Buffer,
		uint ulLength, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>The <c>CM_Set_Device_Interface_Property</c> function sets a device property of a device interface.</summary>
	/// <param name="pszDeviceInterface">
	/// Pointer to a string that identifies the device interface instance for which to set a property for.
	/// </param>
	/// <param name="PropertyKey">
	/// Pointer to a DEVPROPKEY structure that represents the property key of the device interface property to set.
	/// </param>
	/// <param name="PropertyType">
	/// A DEVPROPTYPE-typed value that represents the property-data-type identifier for the device interface property. To delete a
	/// property, this must be set to DEVPROP_TYPE_EMPTY.
	/// </param>
	/// <param name="PropertyBuffer">
	/// Pointer to a buffer that contains the property value of the device interface property. If either the property or the data is
	/// being deleted, this pointer must be set to NULL, and PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to NULL, PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="ulFlags">Reserved. Must be set to zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks><c>CM_Set_Device_Interface_Property</c> is part of the Unified Device Property Model.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_set_device_interface_propertyw CMAPI CONFIGRET
	// CM_Set_Device_Interface_PropertyW( LPCWSTR pszDeviceInterface, const DEVPROPKEY *PropertyKey, DEVPROPTYPE PropertyType, const
	// PBYTE PropertyBuffer, ULONG PropertyBufferSize, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Set_Device_Interface_PropertyW")]
	public static extern CONFIGRET CM_Set_Device_Interface_Property(string pszDeviceInterface, in DEVPROPKEY PropertyKey,
		DEVPROPTYPE PropertyType, [In, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use
	/// CM_Set_Device_Interface_Property instead.]
	/// </para>
	/// <para>The <c>CM_Set_Device_Interface_Property_ExW</c> function sets a device property of a device interface.</para>
	/// </summary>
	/// <param name="pszDeviceInterface">
	/// Pointer to a string that identifies the device interface instance for which to set a property for.
	/// </param>
	/// <param name="PropertyKey">
	/// Pointer to a DEVPROPKEY structure that represents the property key of the device interface property to set.
	/// </param>
	/// <param name="PropertyType">
	/// A DEVPROPTYPE-typed value that represents the property-data-type identifier for the device interface property. To delete a
	/// property, this must be set to DEVPROP_TYPE_EMPTY.
	/// </param>
	/// <param name="PropertyBuffer">
	/// Pointer to a buffer that contains the property value of the device interface property. If either the property or the data is
	/// being deleted, this pointer must be set to NULL, and PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to NULL, PropertyBufferSize must be set to zero.
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
	/// <remarks><c>CM_Set_Device_Interface_Property_ExW</c> is part of the Unified Device Property Model.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_set_device_interface_property_exw CMAPI CONFIGRET
	// CM_Set_Device_Interface_Property_ExW( LPCWSTR pszDeviceInterface, const DEVPROPKEY *PropertyKey, DEVPROPTYPE PropertyType, const
	// PBYTE PropertyBuffer, ULONG PropertyBufferSize, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Set_Device_Interface_Property_ExW")]
	public static extern CONFIGRET CM_Set_Device_Interface_Property_Ex(string pszDeviceInterface, in DEVPROPKEY PropertyKey, DEVPROPTYPE PropertyType,
		[In, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>The <c>CM_Set_DevNode_Problem</c> function sets a problem code for a device that is installed in a local machine.</summary>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
	/// <param name="ulProblem">
	/// Supplies a problem code, which is zero or one of the CM_PROB_Xxx flags that are described in Device Manager Error Messages. A
	/// value of zero indicates that a problem is not set for the device.
	/// </param>
	/// <param name="ulFlags">Must be set to zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, the function returns one of the CR_-prefixed error codes
	/// that are defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use this function to set a problem code for a device that is installed in a local machine. You can also use the following
	/// functions to set a device's problem code and to obtain the problem code set for the device:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// <para>CM_Get_DevNode_Status returns the problem code set for a device installed in a local machine.</para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>CM_Get_DevNode_Status_Ex returns the problem code set for a device installed in a local or a remote machine.</para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>CM_Set_DevNode_Problem_Ex sets a problem code for a device installed in a local or a remote machine.</para>
	/// </term>
	/// </item>
	/// </list>
	/// <para>For information about using device instance handles that are bound to the local machine, see CM_Get_Child.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_set_devnode_problem CMAPI CONFIGRET
	// CM_Set_DevNode_Problem( DEVINST dnDevInst, ULONG ulProblem, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Set_DevNode_Problem")]
	public static extern CONFIGRET CM_Set_DevNode_Problem(uint dnDevInst, CM_PROB ulProblem, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Set_DevNode_Problem instead.]
	/// </para>
	/// <para>
	/// The <c>CM_Set_DevNode_Problem_Ex</c> function sets a problem code for a device that is installed in a local or a remote machine.
	/// </para>
	/// </summary>
	/// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the machine handle supplied by hMachine.</param>
	/// <param name="ulProblem">
	/// Supplies a problem code, which is zero or one of the CM_PROB_Xxx flags that are described in Device Manager Error Messages. A
	/// value of zero indicates that a problem code is not set for the device.
	/// </param>
	/// <param name="ulFlags">Must be set to zero.</param>
	/// <param name="hMachine">
	/// <para>Caller-supplied machine handle to which the caller-supplied device instance handle is bound.</para>
	/// <para>
	/// <c>Note</c> Using this function to access remote machines is not supported beginning with Windows 8 and Windows Server 2012, as
	/// this functionality has been removed.
	/// </para>
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, the function returns one of the CR_-prefixed error codes
	/// that are defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use this function to set a problem code for a device that is installed in a local or a remote machine. You can also use the
	/// following functions to set a device's problem code and to obtain the problem code set for the device:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// <para>CM_Get_DevNode_Status returns the problem code set for a device installed in a local machine.</para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>CM_Get_DevNode_Status_Ex returns the problem code set for a device installed in a local or a remote machine.</para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>CM_Set_DevNode_Problem sets a problem code for a device installed in a local machine.</para>
	/// </term>
	/// </item>
	/// </list>
	/// <para>For information about using device instance handles that are bound to a local or a remote machine, see CM_Get_Child_Ex.</para>
	/// <para>
	/// Functionality to access remote machines has been removed in Windows 8 and Windows Server 2012 and later operating systems thus
	/// you cannot access remote machines when running on these versions of Windows.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_set_devnode_problem_ex CMAPI CONFIGRET
	// CM_Set_DevNode_Problem_Ex( DEVINST dnDevInst, ULONG ulProblem, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Set_DevNode_Problem_Ex")]
	public static extern CONFIGRET CM_Set_DevNode_Problem_Ex(uint dnDevInst, CM_PROB ulProblem, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>The <c>CM_Set_DevNode_Property</c> function sets a device instance property.</summary>
	/// <param name="dnDevInst">Device instance handle that is bound to the local machine.</param>
	/// <param name="PropertyKey">
	/// Pointer to a DEVPROPKEY structure that represents the property key of the device instance property to set.
	/// </param>
	/// <param name="PropertyType">
	/// A DEVPROPTYPE-typed value that represents the property-data-type identifier for the device instance property. To delete a
	/// property, this must be set to DEVPROP_TYPE_EMPTY.
	/// </param>
	/// <param name="PropertyBuffer">
	/// Pointer to a buffer that contains the property value of the device instance property. If either the property or the data is
	/// being deleted, this pointer must be set to NULL, and PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to NULL, PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="ulFlags">Reserved. Must be set to zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks><c>CM_Set_DevNode_Property</c> is part of the Unified Device Property Model.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_set_devnode_propertyw CMAPI CONFIGRET
	// CM_Set_DevNode_PropertyW( DEVINST dnDevInst, const DEVPROPKEY *PropertyKey, DEVPROPTYPE PropertyType, const PBYTE PropertyBuffer,
	// ULONG PropertyBufferSize, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Set_DevNode_PropertyW")]
	public static extern CONFIGRET CM_Set_DevNode_Property(uint dnDevInst, in DEVPROPKEY PropertyKey, DEVPROPTYPE PropertyType,
		[In, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// [Beginning with Windows 8 and Windows Server 2012, this function has been deprecated. Please use CM_Set_DevNode_Property instead.]
	/// </para>
	/// <para>The <c>CM_Set_DevNode_Property_ExW</c> function sets a device instance property.</para>
	/// </summary>
	/// <param name="dnDevInst">Device instance handle that is bound to the local machine.</param>
	/// <param name="PropertyKey">
	/// Pointer to a DEVPROPKEY structure that represents the property key of the device instance property to set.
	/// </param>
	/// <param name="PropertyType">
	/// A DEVPROPTYPE-typed value that represents the property-data-type identifier for the device instance property. To delete a
	/// property, this must be set to DEVPROP_TYPE_EMPTY.
	/// </param>
	/// <param name="PropertyBuffer">
	/// Pointer to a buffer that contains the property value of the device instance property. If either the property or the data is
	/// being deleted, this pointer must be set to NULL, and PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to NULL, PropertyBufferSize must be set to zero.
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
	/// <remarks><c>CM_Set_DevNode_Property_ExW</c> is part of the Unified Device Property Model.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_set_devnode_property_exw CMAPI CONFIGRET
	// CM_Set_DevNode_Property_ExW( DEVINST dnDevInst, const DEVPROPKEY *PropertyKey, DEVPROPTYPE PropertyType, const PBYTE
	// PropertyBuffer, ULONG PropertyBufferSize, ULONG ulFlags, HMACHINE hMachine );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Unicode)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Set_DevNode_Property_ExW")]
	public static extern CONFIGRET CM_Set_DevNode_Property_Ex(uint dnDevInst, in DEVPROPKEY PropertyKey, DEVPROPTYPE PropertyType,
		[In, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, [In, Optional] uint ulFlags, [In, Optional] HMACHINE hMachine);

	/// <summary>The <c>CM_Set_DevNode_Registry_Property</c> function sets a specified device property in the registry.</summary>
	/// <param name="dnDevInst">A caller-supplied device instance handle that is bound to the local machine.</param>
	/// <param name="ulProperty">
	/// A CM_DRP_-prefixed constant value that identifies the device property to be set in the registry. These constants are defined in Cfgmgr32.h.
	/// </param>
	/// <param name="Buffer">
	/// A pointer to a caller-supplied buffer that supplies the requested device property, formatted appropriately for the property's
	/// data type.
	/// </param>
	/// <param name="ulLength">The length, in bytes, of the supplied device property.</param>
	/// <param name="ulFlags">Not used, must be zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes that are
	/// defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>For information about how to use device instance handles that are bound to the local machine, see CM_Get_Child.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_set_devnode_registry_propertyw CMAPI CONFIGRET
	// CM_Set_DevNode_Registry_PropertyW( DEVINST dnDevInst, ULONG ulProperty, PCVOID Buffer, ULONG ulLength, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Set_DevNode_Registry_PropertyW")]
	public static extern CONFIGRET CM_Set_DevNode_Registry_Property(uint dnDevInst, CM_DRP ulProperty, [In, Optional] IntPtr Buffer, uint ulLength, uint ulFlags = 0);

	/// <summary>
	/// The <c>CM_Setup_DevNode</c> function restarts a device instance that is not running because there is a problem with the device configuration.
	/// </summary>
	/// <param name="dnDevInst">A device instance handle that is bound to the local system.</param>
	/// <param name="ulFlags">
	/// <para>One of the following flag values:</para>
	/// <para>CM_SETUP_DEVNODE_READY</para>
	/// <para>Restarts a device instance that is not running because of a problem with the device configuration.</para>
	/// <para>CM_SETUP_DEVNODE_RESET (Windows XP and later versions of Windows)</para>
	/// <para>
	/// Resets a device instance that has the no restart device status flag set. The no restart device status flag is set if a device is
	/// removed by calling <c>CM_Query_And_Remove_SubTree</c> or <c>CM_Query_And_Remove_SubTree_Ex</c> and specifying the
	/// CM_REMOVE_NO_RESTART flag.
	/// </para>
	/// </param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise it returns one of the error codes with "CR_" prefix that
	/// are defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Device installation applications should use the DIF_PROPERTYCHANGE request to restart a device instead of using this function.
	/// The DIF_PROPERTYCHANGE request can be used to enable, disable, restart, stop, or change the properties of a device.
	/// </para>
	/// <para>
	/// If a device instance does not have a problem and is already started, <c>CM_Setup_DevNode</c> returns without changing the status
	/// of the device instance.
	/// </para>
	/// <para>Call CM_Get_DevNode_Status or CM_Get_DevNode_Status_Ex to determine the status and problem code for a device instance.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_setup_devnode CMAPI CONFIGRET CM_Setup_DevNode(
	// DEVINST dnDevInst, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Setup_DevNode")]
	public static extern CONFIGRET CM_Setup_DevNode(uint dnDevInst, CM_SETUP_DEVNODE ulFlags);

	/// <summary>The <c>CM_Uninstall_DevNode</c> function removes all persistent state associated with a device instance.</summary>
	/// <param name="dnDevInst">Device instance handle that is bound to the local machine.</param>
	/// <param name="ulFlags">Reserved. Must be set to zero.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function uninstalls the device without sending an <c>IRP_MN_QUERY_REMOVE_DEVICE</c> request or calling class installers or
	/// co-installers. If your application will run only on a Target Platform of Desktop, instead of calling
	/// <c>CM_Uninstall_DevNode</c>, the application should uninstall the device by calling SetupDiCallClassInstaller with the
	/// DIF_REMOVE code, or by calling DiUninstallDevice.
	/// </para>
	/// <para>Use the following sequence to call this function:</para>
	/// <list type="number">
	/// <item>
	/// <term>Check if CM_Get_DevNode_Status returns success. This means that the device is present.</term>
	/// </item>
	/// <item>
	/// <term>If the device is present, call CM_Query_And_Remove_SubTree.</term>
	/// </item>
	/// <item>
	/// <term>Call <c>CM_Uninstall_DevNode</c>.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_uninstall_devnode CMAPI CONFIGRET
	// CM_Uninstall_DevNode( DEVNODE dnDevInst, ULONG ulFlags );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Uninstall_DevNode")]
	public static extern CONFIGRET CM_Uninstall_DevNode(uint dnDevInst, uint ulFlags = 0);

	/// <summary>
	/// <para>
	/// Use UnregisterDeviceNotification instead of <c>CM_Unregister_Notification</c> if your code targets Windows 7 or earlier versions
	/// of Windows.
	/// </para>
	/// <para>The <c>CM_Unregister_Notification</c> function closes the specified HCMNOTIFICATION handle.</para>
	/// </summary>
	/// <param name="NotifyContext">The HCMNOTIFICATION handle returned by the CM_Register_Notification function.</param>
	/// <returns>
	/// If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Do not call <c>CM_Unregister_Notification</c> from a notification callback. Doing so may cause a deadlock because
	/// <c>CM_Unregister_Notification</c> waits for pending callbacks to finish.
	/// </para>
	/// <para>
	/// Instead, if you want to unregister from the notification callback, you must do so asynchronously. The following sequence shows
	/// one way to do this:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Allocate a context structure to use with your notifications. Include a pointer to a threadpool work structure ( <c>PTP_WORK</c>)
	/// and any other information you would like to pass to the notification callback.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Call CreateThreadpoolWork. Provide a callback function that calls <c>CM_Unregister_Notification</c>. Add the returned work
	/// structure to the previously allocated context structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Call CM_Register_Notification and provide the context structure as the pContext parameter.</term>
	/// </item>
	/// <item>
	/// <term>Do work, get notifications, etc.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Call SubmitThreadpoolWork from within the notification callback, providing the pointer to a threadpool work structure (
	/// <c>PTP_WORK</c>) stored in your context structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>When the threadpool thread runs, the work item calls <c>CM_Unregister_Notification</c>.</term>
	/// </item>
	/// <item>
	/// <term>Call CloseThreadpoolWork to release the work object.</term>
	/// </item>
	/// </list>
	/// <para>If you are finished with the context structure, don't forget to release resources and and free the structure.</para>
	/// <para>
	/// <c>Caution</c> Do not free the context structure until after the work item has called <c>CM_Unregister_Notification</c>. You can
	/// still receive notifications after submitting the threadpool work item and before the work item calls <c>CM_Unregister_Notification</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows how to unregister from the notification callback, as described in the Remarks section.</para>
	/// <para>
	/// <code>typedef struct _CALLBACK_CONTEXT { BOOL bUnregister; PTP_WORK pWork; HCMNOTIFICATION hNotify; CRITICAL_SECTION lock; } CALLBACK_CONTEXT, *PCALLBACK_CONTEXT; DWORD WINAPI EventCallback( __in HCMNOTIFICATION hNotification, __in PVOID Context, __in CM_NOTIFY_ACTION Action, __in PCM_NOTIFY_EVENT_DATA EventData, __in DWORD EventDataSize ) { PCALLBACK_CONTEXT pCallbackContext = (PCALLBACK_CONTEXT)Context; // unregister from the callback EnterCriticalSection(&amp;(pCallbackContext-&gt;lock)); // in case this callback fires before the registration call returns, make sure the notification handle is properly set Context-&gt;hNotify = hNotification; if (!pCallbackContext-&gt;bUnregister) { pCallbackContext-&gt;bUnregister = TRUE; SubmitThreadpoolWork(pCallbackContext-&gt;pWork); } LeaveCriticalSection(&amp;(pCallbackContext-&gt;lock)); return ERROR_SUCCESS; }; VOID CALLBACK WorkCallback( _Inout_ PTP_CALLBACK_INSTANCE Instance, _Inout_opt_ PVOID Context, _Inout_ PTP_WORK pWork ) { PCALLBACK_CONTEXT pCallbackContext = (PCALLBACK_CONTEXT)Context; CM_Unregister_Notification(pCallbackContext-&gt;hNotify); } VOID NotificationFunction() { CONFIGRET cr = CR_SUCCESS; HRESULT hr = S_OK; CM_NOTIFY_FILTER NotifyFilter = { 0 }; BOOL bShouldUnregister = FALSE; PCALLBACK_CONTEXT context; context = (PCALLBACK_CONTEXT)HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, sizeof(CALLBACK_CONTEXT)); if (context == NULL) { goto end; } InitializeCriticalSection(&amp;(context-&gt;lock)); NotifyFilter.cbSize = sizeof(NotifyFilter); NotifyFilter.Flags = 0; NotifyFilter.FilterType = CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE; NotifyFilter.Reserved = 0; hr = StringCchCopy(NotifyFilter.u.DeviceInstance.InstanceId, MAX_DEVICE_ID_LEN, TEST_DEVICE_INSTANCE_ID); if (FAILED(hr)) { goto end; } context-&gt;pWork = CreateThreadpoolWork(WorkCallback, context, NULL); if (context-&gt;pWork == NULL) { goto end; } cr = CM_Register_Notification(&amp;NotifyFilter, context, EventCallback, &amp;context-&gt;hNotify); if (cr != CR_SUCCESS) { goto end; } // ... do work here ... EnterCriticalSection(&amp;(context-&gt;lock)); if (!context-&gt;bUnregister) { // unregister not from the callback bShouldUnregister = TRUE; context-&gt;bUnregister = TRUE; } LeaveCriticalSection(&amp;(context-&gt;lock)); if (bShouldUnregister) { cr = CM_Unregister_Notification(context-&gt;hNotify); if (cr != CR_SUCCESS) { goto end; } } else { // if the callback is the one performing the unregister, wait for the threadpool work item to complete the unregister WaitForThreadpoolWorkCallbacks(context-&gt;pWork, FALSE); } end: if (context != NULL) { if (context-&gt;pWork != NULL) { CloseThreadpoolWork(context-&gt;pWork); } DeleteCriticalSection(&amp;(context-&gt;lock)); HeapFree(GetProcessHeap(), 0, context); } return; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_unregister_notification CMAPI CONFIGRET
	// CM_Unregister_Notification( HCMNOTIFICATION NotifyContext );
	[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_Unregister_Notification")]
	public static extern CONFIGRET CM_Unregister_Notification([In] HCMNOTIFICATION NotifyContext);

	/// <summary>
	/// The <c>CMP_WaitNoPendingInstallEvents</c> (CM_WaitNoPendingInstallEvents) function waits until there are no pending device
	/// installation activities for the PnP manager to perform.
	/// </summary>
	/// <param name="dwTimeout">
	/// <para>Specifies a time-out interval, in milliseconds.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If dwTimeout is set to zero, the function tests whether there are pending installation events and returns immediately.</term>
	/// </item>
	/// <item>
	/// <term>If dwTimeout is set to INFINITE (defined in Winbase.h), the function's time-out interval never elapses.</term>
	/// </item>
	/// <item>
	/// <term>
	/// For all other dwTimeout values, the function returns when the specified interval elapses, even if there are still pending
	/// installation events.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>The function returns one of the following values (defined in Winbase.h):</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>WAIT_OBJECT_0</term>
	/// <term>There are no pending installation activities.</term>
	/// </item>
	/// <item>
	/// <term>WAIT_TIMEOUT</term>
	/// <term>The time-out interval elapsed, and installation activities are still pending.</term>
	/// </item>
	/// <item>
	/// <term>WAIT_FAILED</term>
	/// <term>The function failed. Call GetLastError for additional error information.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The function waits for an internal event object, which the PnP manager sets when it determines that no installation activities
	/// are pending.
	/// </para>
	/// <para>
	/// If a non-zero time-out value is specified, then <c>CMP_WaitNoPendingInstallEvents</c> will return either when no installation
	/// events are pending or when the time-out period has expired, whichever comes first.
	/// </para>
	/// <para>
	/// New installation events can occur at any time. This function just indicates that there are no pending installation activities at
	/// the moment it is called.
	/// </para>
	/// <para>
	/// This function is typically used by device installation applications. For more information, see Writing a Device Installation Application.
	/// </para>
	/// <para>
	/// Do not call this function while processing any events inside of a system-initiated callback function that is expected to return
	/// within a short amount of time. This includes service startup (for example in the <c>ServiceMain</c> callback function) or while
	/// processing any control in the service handler (for example, the <c>Handler</c> callback function), or from installation
	/// components such as class-installers or co-installers.
	/// </para>
	/// <para>
	/// For Windows XP (with no service pack installed), this function must be called from session zero, with administrator privileges.
	/// For Windows XP with Service Pack 1 (SP1) and later versions of Windows, the function can be called from any session, and
	/// administrator privileges are not required.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_waitnopendinginstallevents DWORD
	// CM_WaitNoPendingInstallEvents( DWORD dwTimeout );
	[DllImport(Lib_Cfgmgr32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("cfgmgr32.h", MSDNShortId = "NF:cfgmgr32.CM_WaitNoPendingInstallEvents")]
	public static extern Kernel32.WAIT_STATUS CM_WaitNoPendingInstallEvents(uint dwTimeout);

	/// <summary>Gets the .NET exception for a <see cref="CONFIGRET"/> value.</summary>
	/// <param name="cr">The <see cref="CONFIGRET"/> value to check.</param>
	/// <param name="message">The message.</param>
	/// <returns>An exception instance or <see langword="null"/> if value indicated success.</returns>
	public static Exception? GetException(this CONFIGRET cr, string? message = null)
	{
		if (cr == CONFIGRET.CR_SUCCESS) return null;
		var err = cr.ToError(Win32Error.RPC_S_UNKNOWN_IF);
		if (err == Win32Error.RPC_S_UNKNOWN_IF)
		{
			var ex = new Exception(message);
			ex.Data.Add("CONFIGRET", cr);
			return ex;
		}
		return err.GetException(message);
	}

	/// <summary>Throws an exception if <see cref="CONFIGRET"/> value is not <see cref="CONFIGRET.CR_SUCCESS"/>.</summary>
	/// <param name="cr">The <see cref="CONFIGRET"/> value to check.</param>
	/// <param name="message">The message.</param>
	public static void ThrowIfFailed(this CONFIGRET cr, string? message = null) { if (cr != CONFIGRET.CR_SUCCESS) throw cr.GetException(message)!; }

	/// <summary>Converts a specified <c>CONFIGRET</c> code to its equivalent system error code.</summary>
	/// <param name="cr">The <c>CONFIGRET</c> code to be converted.</param>
	/// <param name="defaultErr">
	/// A default system error code to be returned when no system error code is mapped to the specified <c>CONFIGRET</c> code.
	/// </param>
	/// <returns>
	/// <para>The system error code that corresponds to the <c>CONFIGRET</c> code.</para>
	/// <para>
	/// When there is no mapping from the specified <c>CONFIGRET</c> code to a system error code, <c>CM_MapCrToWin32Err</c> returns the
	/// value specified in <paramref name="defaultErr"/>.
	/// </para>
	/// </returns>
	public static Win32Error ToError(this CONFIGRET cr, Win32Error defaultErr) => CM_MapCrToWin32Err(cr, (uint)defaultErr);
}