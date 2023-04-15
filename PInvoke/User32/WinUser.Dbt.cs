using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>A message indicating a device change.</summary>
	public const uint WM_DEVICECHANGE = 0x0219;

	/// <summary>The device type, which determines the event-specific information that follows the first three members.</summary>
	[PInvokeData("dbt.h", MSDNShortId = "4fc81fcb-b9fe-4016-b639-a43845af2c5f")]
	public enum DBT_DEVTYPE : uint
	{
		/// <summary>OEM- or IHV-defined device type. This structure is a DEV_BROADCAST_OEM structure.</summary>
		[CorrespondingType(typeof(DEV_BROADCAST_OEM))]
		DBT_DEVTYP_OEM = 0,

		/// <summary>devnode number</summary>
		[CorrespondingType(typeof(DEV_BROADCAST_DEVNODE))]
		DBT_DEVTYP_DEVNODE = 1,

		/// <summary>Logical volume. This structure is a DEV_BROADCAST_VOLUME structure.</summary>
		[CorrespondingType(typeof(DEV_BROADCAST_VOLUME))]
		DBT_DEVTYP_VOLUME = 2,

		/// <summary>Port device (serial or parallel). This structure is a DEV_BROADCAST_PORT structure.</summary>
		[CorrespondingType(typeof(DEV_BROADCAST_PORT))]
		DBT_DEVTYP_PORT = 3,

		/// <summary>network resource</summary>
		[CorrespondingType(typeof(DEV_BROADCAST_NET))]
		DBT_DEVTYP_NET = 4,

		/// <summary>Class of devices. This structure is a DEV_BROADCAST_DEVICEINTERFACE structure.</summary>
		[CorrespondingType(typeof(DEV_BROADCAST_DEVICEINTERFACE))]
		DBT_DEVTYP_DEVICEINTERFACE = 5,

		/// <summary>File system handle. This structure is a DEV_BROADCAST_HANDLE structure.</summary>
		[CorrespondingType(typeof(DEV_BROADCAST_HANDLE))]
		DBT_DEVTYP_HANDLE = 6,
	}

	/// <summary>Flags for DEV_BROADCAST_VOLUME.</summary>
	[PInvokeData("dbt.h", MSDNShortId = "8ce644d9-1e95-458e-924f-67bd37831048")]
	public enum DBTF : uint
	{
		/// <summary>Change affects media in drive. If not set, change affects physical device or drive.</summary>
		DBTF_MEDIA = 0x0001,

		/// <summary>Indicated logical volume is a network volume.</summary>
		DBTF_NET = 0x0002,
	}

	/// <summary>Flags for <see cref="RegisterDeviceNotification"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "82094d95-9af3-4222-9c5e-ce2df9bab5e3")]
	public enum DEVICE_NOTIFY
	{
		/// <summary>The hRecipient parameter is a window handle.</summary>
		DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000,

		/// <summary>The hRecipient parameter is a service status handle.</summary>
		DEVICE_NOTIFY_SERVICE_HANDLE = 0x00000001,

		/// <summary>
		/// Notifies the recipient of device interface events for all device interface classes. (The dbcc_classguid member is ignored.)
		/// <para>This value can be used only if the dbch_devicetype member is DBT_DEVTYP_DEVICEINTERFACE.</para>
		/// </summary>
		DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 0x00000004,
	}

	/// <summary>Possible WPARAM values for WM_DEVICECHANGE messages.</summary>
	[PInvokeData("dbt.h")]
	public enum DeviceBroadcastEvent
	{
		/// <summary>'Appy-time is now available.</summary>
		DBT_APPYBEGIN = 0x0000,

		/// <summary>'Appy-time is no longer available.</summary>
		DBT_APPYEND = 0x0001,

		/// <summary>
		/// The system broadcasts the DBT_DEVNODES_CHANGED device event when a device has been added to or removed from the system.
		/// Applications that maintain lists of devices in the system should refresh their lists.
		/// </summary>
		DBT_DEVNODES_CHANGED = 0x0007,

		/// <summary>
		/// The system broadcasts the DBT_QUERYCHANGECONFIG device event to request permission to change the current configuration (dock
		/// or undock). Any application can deny this request and cancel the change.
		/// </summary>
		DBT_QUERYCHANGECONFIG = 0x0017,

		/// <summary>
		/// The system broadcasts the DBT_CONFIGCHANGED device event to indicate that the current configuration has changed, due to a
		/// dock or undock. An application or driver that stores data in the registry under the HKEY_CURRENT_CONFIG key should update the data.
		/// </summary>
		DBT_CONFIGCHANGED = 0x0018,

		/// <summary>
		/// The system broadcasts the DBT_CONFIGCHANGECANCELED device event when a request to change the current configuration (dock or
		/// undock) has been canceled.
		/// </summary>
		DBT_CONFIGCHANGECANCELED = 0x0019,

		/// <summary>
		/// This message is sent when the display monitor has changed and the system should change the display mode to match it.
		/// </summary>
		DBT_MONITORCHANGE = 0x001B,

		/// <summary>The shell has finished login on: VxD can now do Shell_EXEC.</summary>
		DBT_SHELLLOGGEDON = 0x0020,

		/// <summary>CONFIGMG ring 3 call.</summary>
		DBT_CONFIGMGAPI32 = 0x0022,

		/// <summary>CONFIGMG ring 3 call.</summary>
		DBT_VXDINITCOMPLETE = 0x0023,

		/// <summary>
		/// Messages issued by IFSMGR for volume locking purposes on WM_DEVICECHANGE. All these messages pass a pointer to a struct which
		/// has no pointers.
		/// </summary>
		DBT_VOLLOCKQUERYLOCK = 0x8041,

		/// <summary>
		/// Messages issued by IFSMGR for volume locking purposes on WM_DEVICECHANGE. All these messages pass a pointer to a struct which
		/// has no pointers.
		/// </summary>
		DBT_VOLLOCKLOCKTAKEN = 0x8042,

		/// <summary>
		/// Messages issued by IFSMGR for volume locking purposes on WM_DEVICECHANGE. All these messages pass a pointer to a struct which
		/// has no pointers.
		/// </summary>
		DBT_VOLLOCKLOCKFAILED = 0x8043,

		/// <summary>
		/// Messages issued by IFSMGR for volume locking purposes on WM_DEVICECHANGE. All these messages pass a pointer to a struct which
		/// has no pointers.
		/// </summary>
		DBT_VOLLOCKQUERYUNLOCK = 0x8044,

		/// <summary>
		/// Messages issued by IFSMGR for volume locking purposes on WM_DEVICECHANGE. All these messages pass a pointer to a struct which
		/// has no pointers.
		/// </summary>
		DBT_VOLLOCKLOCKRELEASED = 0x8045,

		/// <summary>
		/// Messages issued by IFSMGR for volume locking purposes on WM_DEVICECHANGE. All these messages pass a pointer to a struct which
		/// has no pointers.
		/// </summary>
		DBT_VOLLOCKUNLOCKFAILED = 0x8046,

		/// <summary>Message issued by IFS manager when it detects that a drive is run out of free space.</summary>
		DBT_NO_DISK_SPACE = 0x0047,

		/// <summary>
		/// Message issued by VFAT when it detects that a drive it has mounted has the remaining free space below a threshold specified
		/// by the registry or by a disk space management application. The broadcast is issued by VFAT ONLY when space is either
		/// allocated or freed by VFAT.
		/// </summary>
		DBT_LOW_DISK_SPACE = 0x0048,

		/// <summary>Undocumented.</summary>
		DBT_CONFIGMGPRIVATE = 0x7FFF,

		/// <summary>
		/// The system broadcasts the DBT_DEVICEARRIVAL device event when a device or piece of media has been inserted and becomes available.
		/// </summary>
		DBT_DEVICEARRIVAL = 0x8000,

		/// <summary>
		/// The system broadcasts the DBT_DEVICEQUERYREMOVE device event to request permission to remove a device or piece of media. This
		/// message is the last chance for applications and drivers to prepare for this removal. However, any application can deny this
		/// request and cancel the operation.
		/// </summary>
		DBT_DEVICEQUERYREMOVE = 0x8001,

		/// <summary>
		/// The system broadcasts the DBT_DEVICEQUERYREMOVEFAILED device event when a request to remove a device or piece of media has
		/// been canceled.
		/// </summary>
		DBT_DEVICEQUERYREMOVEFAILED = 0x8002,

		/// <summary>
		/// The system broadcasts the DBT_DEVICEREMOVEPENDING device event when a device or piece of media is being removed and is no
		/// longer available for use.
		/// </summary>
		DBT_DEVICEREMOVEPENDING = 0x8003,

		/// <summary>
		/// The system broadcasts the DBT_DEVICEREMOVECOMPLETE device event when a device or piece of media has been physically removed.
		/// </summary>
		DBT_DEVICEREMOVECOMPLETE = 0x8004,

		/// <summary>The system broadcasts the DBT_DEVICETYPESPECIFIC device event when a device-specific event occurs.</summary>
		DBT_DEVICETYPESPECIFIC = 0x8005,

		/// <summary>The system sends the DBT_CUSTOMEVENT device event when a driver-defined custom event has occurred.</summary>
		DBT_CUSTOMEVENT = 0x8006,

		/// <summary>VPOWERD API for Win95</summary>
		DBT_VPOWERDAPI = 0x8100,

		/// <summary>The DBT_USERDEFINED device event identifies a user-defined event.</summary>
		DBT_USERDEFINED = 0xFFFF,
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("dbt.h")]
	public enum LOCKF : byte
	{
		/// <summary>Undocumented.</summary>
		LOCKF_LOGICAL_LOCK = 0x00,

		/// <summary>Undocumented.</summary>
		LOCKF_PHYSICAL_LOCK = 0x01,
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("dbt.h")]
	public enum LOCKP : byte
	{
		/// <summary>Undocumented.</summary>
		LOCKP_ALLOW_WRITES = 0x01,

		/// <summary>Undocumented.</summary>
		LOCKP_FAIL_WRITES = 0x00,

		/// <summary>Undocumented.</summary>
		LOCKP_FAIL_MEM_MAPPING = 0x02,

		/// <summary>Undocumented.</summary>
		LOCKP_ALLOW_MEM_MAPPING = 0x00,

		/// <summary>Undocumented.</summary>
		LOCKP_USER_MASK = 0x03,

		/// <summary>Undocumented.</summary>
		LOCKP_LOCK_FOR_FORMAT = 0x04,
	}

	/// <summary>Registers the device or type of device for which a window will receive notifications.</summary>
	/// <param name="hRecipient">
	/// <para>
	/// A handle to the window or service that will receive device events for the devices specified in the NotificationFilter parameter.
	/// The same window handle can be used in multiple calls to <c>RegisterDeviceNotification</c>.
	/// </para>
	/// <para>Services can specify either a window handle or service status handle.</para>
	/// </param>
	/// <param name="NotificationFilter">
	/// A pointer to a block of data that specifies the type of device for which notifications should be sent. This block always begins
	/// with the DEV_BROADCAST_HDR structure. The data following this header is dependent on the value of the <c>dbch_devicetype</c>
	/// member, which can be <c>DBT_DEVTYP_DEVICEINTERFACE</c> or <c>DBT_DEVTYP_HANDLE</c>. For more information, see Remarks.
	/// </param>
	/// <param name="Flags">
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DEVICE_NOTIFY_WINDOW_HANDLE 0x00000000</term>
	/// <term>The hRecipient parameter is a window handle.</term>
	/// </item>
	/// <item>
	/// <term>DEVICE_NOTIFY_SERVICE_HANDLE 0x00000001</term>
	/// <term>The hRecipient parameter is a service status handle.</term>
	/// </item>
	/// </list>
	/// <para>In addition, you can specify the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DEVICE_NOTIFY_ALL_INTERFACE_CLASSES 0x00000004</term>
	/// <term>
	/// Notifies the recipient of device interface events for all device interface classes. (The dbcc_classguid member is ignored.) This
	/// value can be used only if the dbch_devicetype member is DBT_DEVTYP_DEVICEINTERFACE.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a device notification handle.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Applications send event notifications using the BroadcastSystemMessage function. Any application with a top-level window can
	/// receive basic notifications by processing the WM_DEVICECHANGE message. Applications can use the <c>RegisterDeviceNotification</c>
	/// function to register to receive device notifications.
	/// </para>
	/// <para>
	/// Services can use the <c>RegisterDeviceNotification</c> function to register to receive device notifications. If a service
	/// specifies a window handle in the hRecipient parameter, the notifications are sent to the window procedure. If hRecipient is a
	/// service status handle, <c>SERVICE_CONTROL_DEVICEEVENT</c> notifications are sent to the service control handler. For more
	/// information about the service control handler, see HandlerEx.
	/// </para>
	/// <para>
	/// Be sure to handle Plug and Play device events as quickly as possible. Otherwise, the system may become unresponsive. If your
	/// event handler is to perform an operation that may block execution (such as I/O), it is best to start another thread to perform
	/// the operation asynchronously.
	/// </para>
	/// <para>
	/// Device notification handles returned by <c>RegisterDeviceNotification</c> must be closed by calling the
	/// UnregisterDeviceNotification function when they are no longer needed.
	/// </para>
	/// <para>
	/// The DBT_DEVICEARRIVAL and DBT_DEVICEREMOVECOMPLETE events are automatically broadcast to all top-level windows for port devices.
	/// Therefore, it is not necessary to call <c>RegisterDeviceNotification</c> for ports, and the function fails if the
	/// <c>dbch_devicetype</c> member is <c>DBT_DEVTYP_PORT</c>. Volume notifications are also broadcast to top-level windows, so the
	/// function fails if <c>dbch_devicetype</c> is <c>DBT_DEVTYP_VOLUME</c>. OEM-defined devices are not used directly by the system, so
	/// the function fails if <c>dbch_devicetype</c> is <c>DBT_DEVTYP_OEM</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Registering for Device Notification.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registerdevicenotificationa HDEVNOTIFY
	// RegisterDeviceNotificationA( HANDLE hRecipient, LPVOID NotificationFilter, DWORD Flags );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "82094d95-9af3-4222-9c5e-ce2df9bab5e3")]
	public static extern SafeHDEVNOTIFY RegisterDeviceNotification(HANDLE hRecipient, IntPtr NotificationFilter, DEVICE_NOTIFY Flags);

	/// <summary>Registers the device or type of device for which a window will receive notifications.</summary>
	/// <param name="hRecipient">
	/// <para>
	/// A handle to the window or service that will receive device events for the devices specified in the NotificationFilter parameter.
	/// The same window handle can be used in multiple calls to <c>RegisterDeviceNotification</c>.
	/// </para>
	/// <para>Services can specify either a window handle or service status handle.</para>
	/// </param>
	/// <param name="NotificationFilter">
	/// A pointer to a block of data that specifies the type of device for which notifications should be sent. This block always begins
	/// with the DEV_BROADCAST_HDR structure. The data following this header is dependent on the value of the <c>dbch_devicetype</c>
	/// member, which can be <c>DBT_DEVTYP_DEVICEINTERFACE</c> or <c>DBT_DEVTYP_HANDLE</c>. For more information, see Remarks.
	/// </param>
	/// <param name="Flags">
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DEVICE_NOTIFY_WINDOW_HANDLE 0x00000000</term>
	/// <term>The hRecipient parameter is a window handle.</term>
	/// </item>
	/// <item>
	/// <term>DEVICE_NOTIFY_SERVICE_HANDLE 0x00000001</term>
	/// <term>The hRecipient parameter is a service status handle.</term>
	/// </item>
	/// </list>
	/// <para>In addition, you can specify the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DEVICE_NOTIFY_ALL_INTERFACE_CLASSES 0x00000004</term>
	/// <term>
	/// Notifies the recipient of device interface events for all device interface classes. (The dbcc_classguid member is ignored.) This
	/// value can be used only if the dbch_devicetype member is DBT_DEVTYP_DEVICEINTERFACE.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a device notification handle.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Applications send event notifications using the BroadcastSystemMessage function. Any application with a top-level window can
	/// receive basic notifications by processing the WM_DEVICECHANGE message. Applications can use the <c>RegisterDeviceNotification</c>
	/// function to register to receive device notifications.
	/// </para>
	/// <para>
	/// Services can use the <c>RegisterDeviceNotification</c> function to register to receive device notifications. If a service
	/// specifies a window handle in the hRecipient parameter, the notifications are sent to the window procedure. If hRecipient is a
	/// service status handle, <c>SERVICE_CONTROL_DEVICEEVENT</c> notifications are sent to the service control handler. For more
	/// information about the service control handler, see HandlerEx.
	/// </para>
	/// <para>
	/// Be sure to handle Plug and Play device events as quickly as possible. Otherwise, the system may become unresponsive. If your
	/// event handler is to perform an operation that may block execution (such as I/O), it is best to start another thread to perform
	/// the operation asynchronously.
	/// </para>
	/// <para>
	/// Device notification handles returned by <c>RegisterDeviceNotification</c> must be closed by calling the
	/// UnregisterDeviceNotification function when they are no longer needed.
	/// </para>
	/// <para>
	/// The DBT_DEVICEARRIVAL and DBT_DEVICEREMOVECOMPLETE events are automatically broadcast to all top-level windows for port devices.
	/// Therefore, it is not necessary to call <c>RegisterDeviceNotification</c> for ports, and the function fails if the
	/// <c>dbch_devicetype</c> member is <c>DBT_DEVTYP_PORT</c>. Volume notifications are also broadcast to top-level windows, so the
	/// function fails if <c>dbch_devicetype</c> is <c>DBT_DEVTYP_VOLUME</c>. OEM-defined devices are not used directly by the system, so
	/// the function fails if <c>dbch_devicetype</c> is <c>DBT_DEVTYP_OEM</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Registering for Device Notification.</para>
	/// </remarks>
	[PInvokeData("winuser.h", MSDNShortId = "82094d95-9af3-4222-9c5e-ce2df9bab5e3")]
	public static SafeHDEVNOTIFY RegisterDeviceNotification<T>(HANDLE hRecipient, in T NotificationFilter, DEVICE_NOTIFY Flags) where T : struct =>
		RegisterDeviceNotification(hRecipient, new SafeCoTaskMemStruct<T>(NotificationFilter), Flags);

	/// <summary>Closes the specified device notification handle.</summary>
	/// <param name="Handle">Device notification handle returned by the RegisterDeviceNotification function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-unregisterdevicenotification BOOL
	// UnregisterDeviceNotification( HDEVNOTIFY Handle );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "bcc0cf87-f996-47b5-937c-14a6332d00d9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UnregisterDeviceNotification(HDEVNOTIFY Handle);

	/// <summary>Contains information about a class of devices.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dbt/ns-dbt-_dev_broadcast_deviceinterface_a typedef struct
	// _DEV_BROADCAST_DEVICEINTERFACE_A { DWORD dbcc_size; DWORD dbcc_devicetype; DWORD dbcc_reserved; GUID dbcc_classguid; char
	// dbcc_name[1]; } DEV_BROADCAST_DEVICEINTERFACE_A, *PDEV_BROADCAST_DEVICEINTERFACE_A;
	[PInvokeData("dbt.h", MSDNShortId = "23e6b2b9-2053-4dfa-9c0a-283279f086b8")]
	[VanaraMarshaler(typeof(AnySizeStringMarshaler<DEV_BROADCAST_DEVICEINTERFACE>), "*")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DEV_BROADCAST_DEVICEINTERFACE
	{
		/// <summary>
		/// The size of this structure, in bytes. This is the size of the members plus the actual length of the <c>dbcc_name</c> string
		/// (the null character is accounted for by the declaration of <c>dbcc_name</c> as a one-character array.)
		/// </summary>
		public uint dbcc_size;

		/// <summary>Set to <c>DBT_DEVTYP_DEVICEINTERFACE</c>.</summary>
		public DBT_DEVTYPE dbcc_devicetype;

		/// <summary>Reserved; do not use.</summary>
		public uint dbcc_reserved;

		/// <summary>The GUID for the interface device class.</summary>
		public Guid dbcc_classguid;

		/// <summary>
		/// <para>A null-terminated string that specifies the name of the device.</para>
		/// <para>
		/// When this structure is returned to a window through the WM_DEVICECHANGE message, the <c>dbcc_name</c> string is converted to
		/// ANSI as appropriate. Services always receive a Unicode string, whether they call <c>RegisterDeviceNotificationW</c> or <c>RegisterDeviceNotificationA</c>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		public string dbcc_name;
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("dbt.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DEV_BROADCAST_DEVNODE
	{
		/// <summary>The size of this structure, in bytes.</summary>
		public uint dbcd_size;

		/// <summary>Set to <c>DBT_DEVTYP_DEVNODE</c>.</summary>
		public DBT_DEVTYPE dbcd_devicetype;

		/// <summary>Reserved; do not use.</summary>
		public uint dbcd_reserved;

		/// <summary>Undocumented.</summary>
		public uint dbcd_devnode;
	}

	/// <summary>Contains information about a file system handle.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dbt/ns-dbt-_dev_broadcast_handle typedef struct _DEV_BROADCAST_HANDLE {
	// DWORD dbch_size; DWORD dbch_devicetype; DWORD dbch_reserved; HANDLE dbch_handle; HDEVNOTIFY dbch_hdevnotify; GUID dbch_eventguid;
	// LONG dbch_nameoffset; BYTE dbch_data[1]; } DEV_BROADCAST_HANDLE, *PDEV_BROADCAST_HANDLE;
	[PInvokeData("dbt.h", MSDNShortId = "5e542abc-8db3-4251-8b68-11456aa2da5e")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DEV_BROADCAST_HANDLE>), "*")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DEV_BROADCAST_HANDLE
	{
		/// <summary>The size of this structure, in bytes.</summary>
		public uint dbch_size;

		/// <summary>Set to DBT_DEVTYP_HANDLE.</summary>
		public DBT_DEVTYPE dbch_devicetype;

		/// <summary>Reserved; do not use.</summary>
		public uint dbch_reserved;

		/// <summary>A handle to the device to be checked.</summary>
		public HANDLE dbch_handle;

		/// <summary>A handle to the device notification. This handle is returned by RegisterDeviceNotification.</summary>
		public HDEVNOTIFY dbch_hdevnotify;

		/// <summary>The GUID for the custom event. For more information, see Device Events. Valid only for DBT_CUSTOMEVENT.</summary>
		public Guid dbch_eventguid;

		/// <summary>The offset of an optional string buffer. Valid only for DBT_CUSTOMEVENT.</summary>
		public int dbch_nameoffset;

		/// <summary>Optional binary data. This member is valid only for DBT_CUSTOMEVENT.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] dbch_data;
	}

	/// <summary>
	/// <para>Serves as a standard header for information related to a device event reported through the WM_DEVICECHANGE message.</para>
	/// <para>
	/// The members of the <c>DEV_BROADCAST_HDR</c> structure are contained in each device management structure. To determine which
	/// structure you have received through WM_DEVICECHANGE, treat the structure as a <c>DEV_BROADCAST_HDR</c> structure and check its
	/// <c>dbch_devicetype</c> member.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/Dbt/ns-dbt-_dev_broadcast_hdr typedef struct _DEV_BROADCAST_HDR { DWORD
	// dbch_size; DWORD dbch_devicetype; DWORD dbch_reserved; } DEV_BROADCAST_HDR;
	[PInvokeData("dbt.h", MSDNShortId = "4fc81fcb-b9fe-4016-b639-a43845af2c5f")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DEV_BROADCAST_HDR
	{
		/// <summary>
		/// <para>The size of this structure, in bytes.</para>
		/// <para>
		/// If this is a user-defined event, this member must be the size of this header, plus the size of the variable-length data in
		/// the _DEV_BROADCAST_USERDEFINED structure.
		/// </para>
		/// </summary>
		public uint dbch_size;

		/// <summary>
		/// <para>
		/// The device type, which determines the event-specific information that follows the first three members. This member can be one
		/// of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DBT_DEVTYP_DEVICEINTERFACE 0x00000005</term>
		/// <term>Class of devices. This structure is a DEV_BROADCAST_DEVICEINTERFACE structure.</term>
		/// </item>
		/// <item>
		/// <term>DBT_DEVTYP_HANDLE 0x00000006</term>
		/// <term>File system handle. This structure is a DEV_BROADCAST_HANDLE structure.</term>
		/// </item>
		/// <item>
		/// <term>DBT_DEVTYP_OEM 0x00000000</term>
		/// <term>OEM- or IHV-defined device type. This structure is a DEV_BROADCAST_OEM structure.</term>
		/// </item>
		/// <item>
		/// <term>DBT_DEVTYP_PORT 0x00000003</term>
		/// <term>Port device (serial or parallel). This structure is a DEV_BROADCAST_PORT structure.</term>
		/// </item>
		/// <item>
		/// <term>DBT_DEVTYP_VOLUME 0x00000002</term>
		/// <term>Logical volume. This structure is a DEV_BROADCAST_VOLUME structure.</term>
		/// </item>
		/// </list>
		/// </summary>
		public DBT_DEVTYPE dbch_devicetype;

		/// <summary>Reserved; do not use.</summary>
		public uint dbch_reserved;
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("dbt.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DEV_BROADCAST_NET
	{
		/// <summary>The size of this structure, in bytes.</summary>
		public uint dbcn_size;

		/// <summary>Set to <c>DBT_DEVTYP_NET</c>.</summary>
		public DBT_DEVTYPE dbcn_devicetype;

		/// <summary>Reserved; do not use.</summary>
		public uint dbcn_reserved;

		/// <summary>Undocumented.</summary>
		public uint dbcn_resource;

		/// <summary>Undocumented.</summary>
		public uint dbcn_flags;
	}

	/// <summary>Contains information about a OEM-defined device type.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dbt/ns-dbt-_dev_broadcast_oem typedef struct _DEV_BROADCAST_OEM { DWORD
	// dbco_size; DWORD dbco_devicetype; DWORD dbco_reserved; DWORD dbco_identifier; DWORD dbco_suppfunc; } DEV_BROADCAST_OEM;
	[PInvokeData("dbt.h", MSDNShortId = "32d72002-1e67-4f72-8821-6712eb898e7d")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DEV_BROADCAST_OEM
	{
		/// <summary>The size of this structure, in bytes.</summary>
		public uint dbco_size;

		/// <summary>Set to <c>DBT_DEVTYP_OEM</c>.</summary>
		public DBT_DEVTYPE dbco_devicetype;

		/// <summary>Reserved; do not use.</summary>
		public uint dbco_reserved;

		/// <summary>The OEM-specific identifier for the device.</summary>
		public uint dbco_identifier;

		/// <summary>The OEM-specific function value. Possible values depend on the device.</summary>
		public uint dbco_suppfunc;
	}

	/// <summary>Contains information about a modem, serial, or parallel port.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dbt/ns-dbt-_dev_broadcast_port_a typedef struct _DEV_BROADCAST_PORT_A { DWORD
	// dbcp_size; DWORD dbcp_devicetype; DWORD dbcp_reserved; char dbcp_name[1]; } DEV_BROADCAST_PORT_A, *PDEV_BROADCAST_PORT_A;
	[PInvokeData("dbt.h", MSDNShortId = "b8789f1c-7d82-4637-bdb0-016a22b3bc8a")]
	[VanaraMarshaler(typeof(AnySizeStringMarshaler<DEV_BROADCAST_PORT>), "*")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DEV_BROADCAST_PORT
	{
		/// <summary>
		/// The size of this structure, in bytes. This is the size of the members plus the actual length of the <c>dbcp_name</c> string
		/// (the null character is accounted for by the declaration of <c>dbcp_name</c> as a one-character array.)
		/// </summary>
		public uint dbcp_size;

		/// <summary>Set to <c>DBT_DEVTYP_PORT</c>.</summary>
		public DBT_DEVTYPE dbcp_devicetype;

		/// <summary>Reserved; do not use.</summary>
		public uint dbcp_reserved;

		/// <summary>
		/// A null-terminated string specifying the friendly name of the port or the device connected to the port. Friendly names are
		/// intended to help the user quickly and accurately identify the device—for example, "COM1" and "Standard 28800 bps Modem" are
		/// considered friendly names.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		public string dbcp_name;
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("dbt.h")]
	[VanaraMarshaler(typeof(AnySizeStringMarshaler<DEV_BROADCAST_USERDEFINED>), "*")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct DEV_BROADCAST_USERDEFINED
	{
		/// <summary>Header.</summary>
		public DEV_BROADCAST_HDR dbud_dbh;

		/// <summary>Undocumented.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		public string dbud_szName;
	}

	/// <summary>Contains information about a logical volume.</summary>
	/// <remarks>
	/// <para>
	/// Although the <c>dbcv_unitmask</c> member may specify more than one volume in any message, this does not guarantee that only one
	/// message is generated for a specified event. Multiple system features may independently generate messages for logical volumes at
	/// the same time.
	/// </para>
	/// <para>
	/// Messages for media arrival and removal are sent only for media in devices that support a soft-eject mechanism. For example,
	/// applications will not see media-related volume messages for floppy disks.
	/// </para>
	/// <para>
	/// Messages for network drive arrival and removal are not sent whenever network commands are issued, but rather when network
	/// connections will disappear as the result of a hardware event.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/dbt/ns-dbt-_dev_broadcast_volume typedef struct _DEV_BROADCAST_VOLUME { DWORD
	// dbcv_size; DWORD dbcv_devicetype; DWORD dbcv_reserved; DWORD dbcv_unitmask; WORD dbcv_flags; } DEV_BROADCAST_VOLUME;
	[PInvokeData("dbt.h", MSDNShortId = "8ce644d9-1e95-458e-924f-67bd37831048")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DEV_BROADCAST_VOLUME
	{
		/// <summary>The size of this structure, in bytes.</summary>
		public uint dbcv_size;

		/// <summary>Set to <c>DBT_DEVTYP_VOLUME</c> (2).</summary>
		public DBT_DEVTYPE dbcv_devicetype;

		/// <summary>Reserved; do not use.</summary>
		public uint dbcv_reserved;

		/// <summary>
		/// The logical unit mask identifying one or more logical units. Each bit in the mask corresponds to one logical drive. Bit 0
		/// represents drive A, bit 1 represents drive B, and so on.
		/// </summary>
		public uint dbcv_unitmask;

		/// <summary>
		/// <para>This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DBTF_MEDIA 0x0001</term>
		/// <term>Change affects media in drive. If not set, change affects physical device or drive.</term>
		/// </item>
		/// <item>
		/// <term>DBTF_NET 0x0002</term>
		/// <term>Indicated logical volume is a network volume.</term>
		/// </item>
		/// </list>
		/// </summary>
		public DBTF dbcv_flags;
	}

	/// <summary>Provides a handle to a device notification.</summary>
	[PInvokeData("dbt.h")]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct HDEVNOTIFY : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HDEVNOTIFY"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HDEVNOTIFY(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HDEVNOTIFY"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HDEVNOTIFY NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HDEVNOTIFY"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HDEVNOTIFY h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDEVNOTIFY"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HDEVNOTIFY(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HDEVNOTIFY h1, HDEVNOTIFY h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HDEVNOTIFY h1, HDEVNOTIFY h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HDEVNOTIFY h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("dbt.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct VolLockBroadcast
	{
		/// <summary>Undocumented.</summary>
		public DEV_BROADCAST_HDR vlb_dbh;

		/// <summary>thread on which lock request is being issued.</summary>
		public uint vlb_owner;

		/// <summary>lock permission flags.</summary>
		public LOCKP vlb_perms;

		/// <summary>type of lock</summary>
		public byte vlb_lockType;

		/// <summary>drive on which lock is issued</summary>
		public byte vlb_drive;

		/// <summary>miscellaneous flags</summary>
		public LOCKF vlb_flags;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HDEVNOTIFY"/> that is disposed using <see cref="UnregisterDeviceNotification"/>.</summary>
	[PInvokeData("dbt.h")]
	public class SafeHDEVNOTIFY : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHDEVNOTIFY"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHDEVNOTIFY(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHDEVNOTIFY"/> class.</summary>
		private SafeHDEVNOTIFY() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHDEVNOTIFY"/> to <see cref="HDEVNOTIFY"/>.</summary>
		/// <param name="h">The SafeHDEVNOTIFY.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HDEVNOTIFY(SafeHDEVNOTIFY h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => UnregisterDeviceNotification(handle);
	}
}