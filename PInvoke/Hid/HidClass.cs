using System.Runtime.CompilerServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

/// <summary>Items from the Human Interface Devices (hid.dll) API.</summary>
public static partial class Hid
{
	/// <summary>
	/// HID_REVISION specifies the minimum revision of HIDCLASS.SYS required to support minidrivers compiled with this header file.
	/// </summary>
	public const int HID_REVISION = 0x00000001;

	/// <summary/>
	public static readonly Guid GUID_CLASS_INPUT = GUID_DEVINTERFACE_HID;

	/// <summary/>
	public static readonly Guid GUID_DEVINTERFACE_HID = new(0x4D1E55B2, 0xF16F, 0x11CF, 0x88, 0xCB, 0x00, 0x11, 0x11, 0x00, 0x00, 0x30);

	/// <summary/>
	public static readonly Guid GUID_HID_INTERFACE_HIDPARSE = new(0xf5c315a5, 0x69ac, 0x4bc2, 0x92, 0x79, 0xd0, 0xb6, 0x45, 0x76, 0xf4, 0x4b);

	/// <summary/>
	public static readonly Guid GUID_HID_INTERFACE_NOTIFY = new(0x2c4e2e88, 0x25e6, 0x4c33, 0x88, 0x2f, 0x3d, 0x82, 0xe6, 0x07, 0x36, 0x81);

	/// <summary>
	/// <para>The IOCTL_GET_NUM_DEVICE_INPUT_BUFFERS request obtains the size of the input report queue for a <c>top-level collection</c>.</para>
	/// <para>
	/// The input report queue is implemented as a ring buffer. If a collection transmits data to the HID class driver faster than the input
	/// reports are read, reports can be lost. The size of the input report queue can be adjusted using <c>IOCTL_SET_NUM_DEVICE_INPUT_BUFFERS</c>.
	/// </para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> in the I/O stack location of the IRP indicates the size, in bytes, of the output
	/// buffer, which must be &gt;= <b>sizeof</b>(ULONG).
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of the buffer is <b>sizeof</b>(ULONG).</para>
	/// <para>Output buffer</para>
	/// <para><b>Irp-&gt;AssociatedIrp.SystemBuffer</b> points to a buffer that will receive the size of the report input queue.</para>
	/// <para>Output buffer length</para>
	/// <para>The size of the buffer is <b>sizeof</b>(ULONG).</para>
	/// <para>Status block</para>
	/// <para>The HID class driver sets the following fields of <b>Irp-&gt;IoStatus</b>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><b>Information</b> is set to <b>sizeof</b>(ULONG) if the size of the report input queue is successfully retrieved.</description>
	/// </item>
	/// <item>
	/// <description>
	/// <b>Status</b> is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_get_num_device_input_buffers
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_GET_NUM_DEVICE_INPUT_BUFFERS")]
	public static readonly uint IOCTL_GET_NUM_DEVICE_INPUT_BUFFERS = HID_BUFFER_CTL_CODE(104);

	/// <summary>
	/// <para>
	/// The IOCTL_GET_PHYSICAL_DESCRIPTOR request obtains the physical descriptor of a <c>top-level collection</c>. For a minidriver, this
	/// descriptor is the descriptor of the HIDClass device.
	/// </para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> in the I/O stack location of the IRP indicates the size, in bytes, of the output buffer.
	/// </para>
	/// <para>Output buffer</para>
	/// <para><b>Irp-&gt;MdlAddress</b> must point to the buffer that will receive the physical descriptor.</para>
	/// <para>The HID minidriver copies the physical descriptor into the user buffer at <b>Irp-&gt;UserBuffer</b>.</para>
	/// <para>Status block</para>
	/// <para>
	/// The HID class driver sets the <b>Status</b> member of <b>Irp-&gt;IoStatus</b> to STATUS_SUCCESS if the transfer completed without
	/// error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </para>
	/// <para>HID minidrivers that carry out the I/O to the device set the following fields of <b>Irp-&gt;IoStatus</b>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><b>Information</b> is set to the number of bytes transferred from the device.</description>
	/// </item>
	/// <item>
	/// <description>
	/// <b>Status</b> is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// HID minidrivers that call other drivers with this IRP to carry out the I/O to their device should ensure that the <b>Information</b>
	/// field of the status block is correct and not change the contents of the <b>Status</b> field.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_get_physical_descriptor
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_GET_PHYSICAL_DESCRIPTOR")]
	public static readonly uint IOCTL_GET_PHYSICAL_DESCRIPTOR = HID_OUT_CTL_CODE(102);

	/// <summary>
	/// <para>
	/// The <b>IOCTL_HID_DEVICERESET_NOTIFICATION</b> request is sent by the HID client driver to HID class driver to wait for a
	/// device-initiated reset event. This request can also be sent by the HID Class driver to the HID Minidriver to wait for a
	/// device-initiated reset event.
	/// </para>
	/// <para>Only one device reset notification request is allowed at any one time.</para>
	/// <para>
	/// A HID minidriver can enable this feature by adding a registry value in the INF file. The <b>DeviceResetNotificationEnabled</b> under
	/// the device's hardware key must be set to 1 to enable the feature. Here is an example:
	/// </para>
	/// <para><c>[hidi2c_Device.NT.HW] AddReg = hidi2c_Device.Filter.AddReg, hidi2c_Device.Configuration.AddReg</c></para>
	/// <para>...</para>
	/// <para><c>[hidi2c_Device.Configuration.AddReg]</c></para>
	/// <para>...</para>
	/// <para><c>HKR,,"DeviceResetNotificationEnabled",0x00010001,1</c></para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>None.</para>
	/// <para>Input buffer length</para>
	/// <para>None.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None.</para>
	/// <para>Status block</para>
	/// <para>
	/// I <b>rp-&gt;IoStatus.Status</b> is set to STATUS_SUCCESS if the request is successful. Otherwise, Status to the appropriate error
	/// condition as a <c>NTSTATUS</c> code.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_devicereset_notification
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_DEVICERESET_NOTIFICATION")]
	public static readonly uint IOCTL_HID_DEVICERESET_NOTIFICATION = HID_CTL_CODE(140);

	/// <summary>
	/// <para>
	/// The IOCTL_HID_DISABLE_SECURE_READ request cancels an <c>IOCTL_HID_ENABLE_SECURE_READ</c> request for a <c>HID collection</c>. Only a
	/// "trusted" user-mode application (an application with SeTcbPrivilege privileges) can successfully use this request. Kernel-mode
	/// drivers have SeTcbPrivilege privileges by default, but user-mode applications do not.
	/// </para>
	/// <para>
	/// For information about how to use enable and disable secure read requests to enforce a secure read for a collection, see <c>Enforcing
	/// a Secure Read For a HID Collection</c>.
	/// </para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>None.</para>
	/// <para>Input buffer length</para>
	/// <para>None.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None.</para>
	/// <para>Status block</para>
	/// <para>
	/// The HID class driver sets the <b>Status</b> member of <b>Irp-&gt;IoStatus</b> to STATUS_SUCCESS if the requester has SeTcbPrivilege
	/// privileges and the file is valid. Otherwise, it is set to STATUS_PRIVILEGE_NOT_HELD.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_disable_secure_read
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_DISABLE_SECURE_READ")]
	public static readonly uint IOCTL_HID_DISABLE_SECURE_READ = HID_CTL_CODE(131);

	/// <summary>
	/// <para>
	/// The IOCTL_HID_ENABLE_SECURE_READ request enables a secure read for open files of a <c>HID collection</c>. Only a "trusted" user-mode
	/// application (an application with SeTcbPrivilege privileges) can successfully use this request. Kernel-mode drivers have
	/// SeTcbPrivilege privileges by default, but user-mode applications do not.
	/// </para>
	/// <para>A client uses an <c>IOCTL_HID_DISABLE_SECURE_READ</c> request to cancel an enable secure read request.</para>
	/// <para>
	/// For information about how to use enable and disable secure read requests to enforce a secure read for a collection, see <c>Enforcing
	/// a Secure Read For a HID Collection</c>.
	/// </para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>None.</para>
	/// <para>Input buffer length</para>
	/// <para>None.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None.</para>
	/// <para>Status block</para>
	/// <para>
	/// The HID class driver sets the <b>Status</b> field of <b>Irp-&gt;IoStatus</b> to STATUS_SUCCESS if the requester has SeTcbPrivilege
	/// privileges and the file is valid. Otherwise, it sets the <b>Status</b> field to STATUS_PRIVILEGE_NOT_HELD.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_enable_secure_read
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_ENABLE_SECURE_READ")]
	public static readonly uint IOCTL_HID_ENABLE_SECURE_READ = HID_CTL_CODE(130);

	/// <summary>
	/// <para>
	/// The <b>IOCTL_HID_ENABLE_WAKE_ON_SX</b> request is used to indicate the requirement for a device to be able to wake from system sleep.
	/// </para>
	/// <para>
	/// User mode clients, including user mode driver framework (UMDF) drivers, use this IOCTL to let a device know about the " <i>wake from
	/// sleep</i>" requirement. The user mode clients use this IOCTL because they are not able to send an I/O request packet (IRP) to a device.
	/// </para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// The <b>Parameters.DeviceIoControl.OutputBufferLength</b> member specifies the size, in bytes, of a requester-allocated output buffer.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>This is a buffer of size Boolean.</para>
	/// <para>Output buffer</para>
	/// <para>
	/// The <b>Irp-&gt;AssociatedIrp.SystemBuffer</b> member is a pointer to the requestor-allocated buffer that the HID class driver uses to
	/// return the Boolean value. This Boolean value indicates whether or not the device is configured and ready to wake from system sleep.
	/// The pointer is cast as a pointer to Boolean: (PBOOLEAN)(Irp-&gt;AssociatedIrp.SystemBuffer).
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>This is a buffer of size Boolean.</para>
	/// <para>Status block</para>
	/// <para>
	/// <b>Irp-&gt;IoStatus.Status</b> is set to STATUS_SUCCESS if the request is successful. Otherwise, Status to the appropriate error
	/// condition as a <c>NTSTATUS</c> code.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_enable_wake_on_sx
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_ENABLE_WAKE_ON_SX")]
	public static readonly uint IOCTL_HID_ENABLE_WAKE_ON_SX = HID_BUFFER_CTL_CODE(107);

	/// <summary>
	/// <para>
	/// The IOCTL_HID_FLUSH_QUEUE request dequeues all of the unparsed input reports from a <c>top-level collection's</c> input report queue.
	/// </para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>None.</para>
	/// <para>Input buffer length</para>
	/// <para>None.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None.</para>
	/// <para>Status block</para>
	/// <para>
	/// The HID class driver sets the <b>Status</b> member of <b>Irp-&gt;IoStatus</b> to STATUS_SUCCESS if the transfer completed without
	/// error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_flush_queue
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_FLUSH_QUEUE")]
	public static readonly uint IOCTL_HID_FLUSH_QUEUE = HID_CTL_CODE(101);

	/// <summary>
	/// <para>
	/// The IOCTL_HID_GET_COLLECTION_DESCRIPTOR request obtains a top-level collection's <c>preparsed data</c>, which the HID class driver
	/// extracted from the physical device's report descriptor during device initialization.
	/// </para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> in the I/O stack location of the IRP indicates the size, in bytes, of the output
	/// buffer specified by <b>Irp-&gt;UserBuffer</b>.
	/// </para>
	/// <para>Output buffer</para>
	/// <para>
	/// <b>Irp-&gt;UserBuffer</b> is a PVOID pointer to a requester-allocated buffer that the HID class driver uses to return a variable
	/// length <b>_HIDP_PREPARSED_DATA</b> structure. This buffer must be allocated from nonpaged pool.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The size, in bytes, of the preparsed data structure is obtained using <c>IOCTL_HID_GET_COLLECTION_INFORMATION</c>.</para>
	/// <para>Status block</para>
	/// <para>The HID class driver sets the following fields of <b>Irp-&gt;IoStatus</b>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><b>Information</b> is set to size, in bytes, of the preparsed data.</description>
	/// </item>
	/// <item>
	/// <description>
	/// <b>Status</b> is set to STATUS_SUCCESS if the preparsed data was retrieved without error. Otherwise, it is set to an appropriate
	/// NTSTATUS error code. If the requester-supplied output buffer is not large enough to hold the preparsed data, then status is set to STATUS_INVALID_BUFFER_SIZE.
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// <para>The <b>_HIDP_PREPARSED_DATA</b> structure contains a <c>top-level collection's</c>  <c>preparsed data</c>.</para>
	/// <para><c>typedef struct _HIDP_PREPARSED_DATA * PHIDP_PREPARSED_DATA;</c></para>
	/// <para>
	/// A user-mode application calls <c>HidD_GetPreparsedData</c> to obtain a top-level collection's preparsed data in a variable length
	/// _HIDP_PREPARSED_DATA structure.
	/// </para>
	/// <para>
	/// A kernel-mode driver uses an <b>IOCTL_HID_GET_COLLECTION_DESCRIPTOR</b> request to obtain a pointer to a top-level collection's
	/// preparsed data.
	/// </para>
	/// <para>The internal structure of a _HIDP_PREPARSED_DATA structure is reserved for internal system use.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_get_collection_descriptor
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_GET_COLLECTION_DESCRIPTOR")]
	public static readonly uint IOCTL_HID_GET_COLLECTION_DESCRIPTOR = HID_CTL_CODE(100);

	/// <summary>
	/// <para>
	/// The IOCTL_HID_GET_COLLECTION_INFORMATION request obtains a <c>top-level collection's</c>  <c>HID_COLLECTION_INFORMATION</c>
	/// structure. This information includes the size, in bytes, of a collection's <c>preparsed data</c>.
	/// </para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> in the I/O stack location of the IRP indicates the size, in bytes, of the output
	/// buffer, which must be &gt;= <b>sizeof</b>(HID_COLLECTION_INFORMATION).
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>Greater than or equal to <b>sizeof</b>(HID_COLLECTION_INFORMATION).</para>
	/// <para>Output buffer</para>
	/// <para>
	/// <b>Irp-&gt;AssociatedIrp.SystemBuffer</b> points to a buffer that will receive the collection information. This data will be
	/// formatted in the requester-supplied buffer as a HID_COLLECTION_INFORMATION structure.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The size of a HID_COLLECTION_INFORMATION structure.</para>
	/// <para>Status block</para>
	/// <para>The HID class driver sets the following fields of <b>Irp-&gt;IoStatus</b>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><b>Information</b> is set to <b>sizeof</b>(HID_COLLECTION_INFORMATION) if the data was retrieved successfully.</description>
	/// </item>
	/// <item>
	/// <description>
	/// <b>Status</b> is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_get_collection_information
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_GET_COLLECTION_INFORMATION")]
	public static readonly uint IOCTL_HID_GET_COLLECTION_INFORMATION = HID_BUFFER_CTL_CODE(106);

	/// <summary>
	/// <para>The <b>IOCTL_HID_GET_DRIVER_CONFIG</b> request retrieves the driver configuration.</para>
	/// <para>This IOCTL is reserved for system use.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Status block</para>
	/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
	/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
	/// <para>For more information, see <c>NTSTATUS Values</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_get_driver_config
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_GET_DRIVER_CONFIG")]
	public static readonly uint IOCTL_HID_GET_DRIVER_CONFIG = HID_BUFFER_CTL_CODE(100);

	/// <summary>
	/// <para>The IOCTL_HID_GET_FEATURE request returns a feature report associated with a <c>top-level collection</c>.</para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// The <c>Parameters.DeviceIoControl.OutputBufferLength</c> member specifies the size, in bytes, of a requester-allocated output buffer.
	/// The HID class driver uses this buffer to return a feature report.
	/// </para>
	/// <para>
	/// If the collection includes report IDs, the requester must set the first byte of the output buffer to a nonzero report ID. Otherwise,
	/// the requester must set the first byte of the output buffer to zero.
	/// </para>
	/// <para><b>Minidriver handling</b></para>
	/// <para>
	/// <c>Irp-&gt;UserBuffer</c> points to a <c>HID_XFER_PACKET</c> structure that the HID class driver uses to input the following members:
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>
	/// The size of the buffer in bytes. The buffer must be large enough to hold the feature report plus one additional byte that specifies a
	/// nonzero report ID. If report ID is not used, the ID value is zero.
	/// </para>
	/// <para><b>Minidriver handling</b></para>
	/// <para>The size of the <c>HID_XFER_PACKET</c> structure.</para>
	/// <para>Output buffer</para>
	/// <para>
	/// The <c>Irp-&gt;MdlAddress</c> member points to the requester-allocated output buffer that the HID class driver uses to return the
	/// feature report. The first byte of the buffer, which the requester uses to input a report ID or zero, is unchanged. The feature
	/// report, excluding its report ID, if report IDs are used, is returned at <c>((PUCHAR)Irp-&gt;MdlAddress + 1)</c>.
	/// </para>
	/// <para><b>Minidriver handling</b></para>
	/// <para>
	/// <c>((PHID_XFER_PACKET)(Irp-&gt;UserBuffer))-&gt;reportBuffer</c> points to the requester-allocated output buffer that the HID
	/// minidriver uses to return a feature report.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The length of the buffer that contains the report.</para>
	/// <para><b>Minidriver handling</b></para>
	/// <para>The size of the <c>HID_XFER_PACKET</c> structure.</para>
	/// <para>Status block</para>
	/// <para>The HID class driver sets the following fields of <c>Irp-&gt;IoStatus</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Information is set to the number of bytes transferred from the device.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Status is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// <para><b>Minidriver handling</b></para>
	/// <para>HID minidrivers that carry out the I/O to the device set the following fields of <c>Irp-&gt;IoStatus</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Information is set to the number of bytes transferred from the device.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Status is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// HID minidrivers that call other drivers with this IOCTL to carry out the I/O to their device, should ensure that the Information
	/// field of the status block is correct and not change the contents of the Status field.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_get_feature
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_GET_FEATURE")]
	public static readonly uint IOCTL_HID_GET_FEATURE = HID_OUT_CTL_CODE(100);

	/// <summary>
	/// <para>The IOCTL_HID_GET_HARDWARE_ID request obtains the Plug and Play hardware ID of a <c>top-level collection</c>.</para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> in the I/O stack location of the IRP indicates the size, in bytes, of the output buffer.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The length of the buffer.</para>
	/// <para>Output buffer</para>
	/// <para><b>Irp-&gt;MdlAddress</b> points to a buffer to receive the number of device input buffers.</para>
	/// <para>Output buffer length</para>
	/// <para>The length of the buffer.</para>
	/// <para>Status block</para>
	/// <para>The HID class driver sets the following fields of <b>Irp-&gt;IoStatus</b>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><b>Information</b> is set to the number of bytes of registry information retrieved when the IOCTL succeeds.</description>
	/// </item>
	/// <item>
	/// <description>
	/// <b>Status</b> is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_get_hardware_id
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_GET_HARDWARE_ID")]
	public static readonly uint IOCTL_HID_GET_HARDWARE_ID = HID_OUT_CTL_CODE(103);

	/// <summary>
	/// <para>
	/// The IOCTL_HID_GET_INDEXED_STRING request obtains a specified embedded string from a <c>top-level collection</c>. The retrieved string
	/// is a NULL-terminated wide character string in a human-readable format.
	/// </para>
	/// <para>For general information about HIDClass devices see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.InputBufferLength</b> in the I/O stack location of the IRP indicates the size in bytes of the input
	/// buffer at the location pointed to by <b>Irp-&gt;AssociatedIrp.SystemBuffer</b>.
	/// </para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> in the I/O stack location of the IRP indicates the size, in bytes, of the output
	/// buffer. If the output buffer is not large enough to hold the entire NULL-terminated embedded string, the request returns nothing in
	/// the output buffer.
	/// </para>
	/// <para><b>Minidriver handling</b>: IOCTL_HID_GET_INDEXED_STRING uses two input buffers.</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> in the I/O stack location of the IRP indicates the size, in bytes, of the output
	/// buffer at the location pointed to by <b>Irp-&gt;MdlAddress</b>. If the output buffer is not large enough to hold the entire
	/// NULL-terminated embedded string, the request returns nothing in the output buffer. The maximum possible number of characters in an
	/// embedded string is device specific. For USB devices, the maximum string length is 126 wide characters (not including the terminating
	/// NULL character).
	/// </para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.Type3InputBuffer</b> contains an INT value that describes the string to be retrieved. The most
	/// significant two bytes of the INT value contain the language ID (for example, a value of 1033 indicates English). The least
	/// significant two bytes of the INT value contain the string index.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.InputBufferLength</b> must be &gt;= <b>sizeof</b>(ULONG) and it should contain the index of the string
	/// to be retrieved.
	/// </para>
	/// <para>
	/// For <b>Parameters.DeviceIoControl.OutputBufferLength</b>, the maximum possible number of characters in an embedded string is device
	/// specific. For USB devices, the maximum string length is 126 wide characters (not including the terminating NULL character).
	/// </para>
	/// <para>Output buffer</para>
	/// <para><b>Irp-&gt;MdlAddress</b> points to a buffer to receive the retrieved string (a NULL-terminated wide character string).</para>
	/// <para>
	/// <b>Minidriver handling</b>: <b>Irp-&gt;MdlAddress</b> points to a buffer to receive the retrieved string (a NULL-terminated wide
	/// character string). Note that unlike most device control IRPs for HID minidrivers, this IRP does not use METHOD_NEITHER buffering. In
	/// particular, it must be distinguished from IOCTL_HID_GET_STRING whose output buffer is identified by <b>Irp-&gt;UserBuffer</b>.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>
	/// The length of the retrieved string (a NULL-terminated wide character string). The supplied buffer must be &lt;= 4093 bytes (2^12 – 3).
	/// </para>
	/// <para>Status block</para>
	/// <para>The HID class driver sets the following fields of <b>Irp-&gt;IoStatus</b>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para><b>Information</b> is set to the number of bytes transferred from the device.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// <b>Status</b> is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_get_indexed_string
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_GET_INDEXED_STRING")]
	public static readonly uint IOCTL_HID_GET_INDEXED_STRING = HID_OUT_CTL_CODE(120);

	/// <summary>
	/// <para>The IOCTL_HID_GET_INPUT_REPORT request obtains an input report from a <c>top-level collection</c>.</para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// The <c>Parameters.DeviceIoControl.OutputBufferLength</c> member specifies the size of a requester-allocated output buffer in bytes.
	/// The HID class driver uses this buffer to return an input report.
	/// </para>
	/// <para>
	/// If the collection includes report IDs, the requester must set the first byte of the output buffer to a nonzero report ID. Otherwise,
	/// the requester must set the first byte of the output buffer to zero.
	/// </para>
	/// <para><b>Minidriver handling</b></para>
	/// <para>
	/// <c>Irp-&gt;UserBuffer</c> points to a <c>HID_XFER_PACKET</c> structure that the HID class driver uses to input the following members:
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>
	/// The size of the buffer in bytes. The buffer must be large enough to hold the input report plus one additional byte that specifies a
	/// nonzero report ID. If report ID is not used, the ID value is zero.
	/// </para>
	/// <para>Output buffer</para>
	/// <para>
	/// The <c>Irp-&gt;MdlAddress</c> member points to the requester-allocated output buffer that the HID class driver uses to return the
	/// input report. The first byte of the buffer, which the requester uses to input a report ID or zero, is unchanged. The input report is
	/// returned at <c>((PUCHAR)Irp-&gt;MdlAddress + 1)</c>.
	/// </para>
	/// <para><b>Minidriver handling</b></para>
	/// <para>
	/// <c>((PHID_XFER_PACKET)(Irp-&gt;UserBuffer))-&gt;reportBuffer</c> points to the requester-allocated output buffer that the HID
	/// minidriver uses to return the input report.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The size of the output report.</para>
	/// <para>Status block</para>
	/// <para>The HID class driver sets the following fields of <c>Irp-&gt;IoStatus</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Information is set to zero.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Status is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// <para><b>Minidriver handling</b></para>
	/// <para>HID minidrivers that carry out the I/O to the device set the following fields of <c>Irp-&gt;IoStatus</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Information is set to the number of bytes transferred from the device.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Status is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// HID minidrivers that call other drivers with this IOCTL to carry out the I/O to their device, should ensure that the Information
	/// field of the status block is correct and not change the contents of the Status field.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_get_input_report
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_GET_INPUT_REPORT")]
	public static readonly uint IOCTL_HID_GET_INPUT_REPORT = HID_OUT_CTL_CODE(104);

	/// <summary>
	/// <para>
	/// The IOCTL_HID_GET_MANUFACTURER_STRING request obtains a <c>top-level collection's</c> embedded string that identifies the
	/// manufacturer of the device. The retrieved string is a NULL-terminated wide character string in a human-readable format.
	/// </para>
	/// <para>For general information about HIDClass devices see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> in the I/O stack location of the IRP indicates the size, in bytes, of the output
	/// buffer. If the output buffer is not large enough to hold the entire NULL-terminated embedded string, the request returns nothing in
	/// the output buffer.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>
	/// The maximum possible number of characters in an embedded string is device specific. For USB devices, the maximum string length is 126
	/// wide characters (not including the terminating NULL character).
	/// </para>
	/// <para>Output buffer</para>
	/// <para><b>Irp-&gt;MdlAddress</b> points to a buffer to receive the manufacturer ID (a NULL-terminated wide character string).</para>
	/// <para>Output buffer length</para>
	/// <para>The length of a NULL-terminated wide character string. The supplied buffer must be &lt;= 4093 bytes (2^12 – 3).</para>
	/// <para>Status block</para>
	/// <para>The HID class driver sets the following fields of <b>Irp-&gt;IoStatus</b>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para><b>Information</b> is set to the number of bytes transferred from the device.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// <b>Status</b> is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_get_manufacturer_string
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_GET_MANUFACTURER_STRING")]
	public static readonly uint IOCTL_HID_GET_MANUFACTURER_STRING = HID_OUT_CTL_CODE(110);

	/// <summary>
	/// <para>
	/// The <b>IOCTL_HID_GET_MS_GENRE_DESCRIPTOR</b> request is used for retrieving the Genre <c>Microsoft OS 1.0 feature descriptor</c> for
	/// the device. This descriptor is being considered for future versions of Windows, and no specification is currently available.
	/// </para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// The <b>Parameters.DeviceIoControl.OutputBufferLength</b> member specifies the size, in bytes, of a requester-allocated output buffer.
	/// </para>
	/// <para>Output buffer</para>
	/// <para>
	/// <b>Irp-&gt;IoStatus.Status</b> is set to STATUS_SUCCESS if the request is successful. Otherwise, Status to the appropriate error
	/// condition as a <c>NTSTATUS</c> code.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The size of a status code.</para>
	/// <para>Status block</para>
	/// <para>
	/// <b>Irp-&gt;IoStatus.Status</b> is set to STATUS_SUCCESS if the request is successful. Otherwise, Status to the appropriate error
	/// condition as a <c>NTSTATUS</c> code.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_get_ms_genre_descriptor
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_GET_MS_GENRE_DESCRIPTOR")]
	public static readonly uint IOCTL_HID_GET_MS_GENRE_DESCRIPTOR = HID_OUT_CTL_CODE(121);

	/// <summary/>
	[PInvokeData("hidclass.h")]
	public static readonly uint IOCTL_HID_GET_OUTPUT_REPORT = HID_OUT_CTL_CODE(105);

	/// <summary>
	/// <para>The IOCTL_HID_GET_POLL_FREQUENCY_MSEC request obtains the current polling frequency, in milliseconds, of a <c>top-level collection</c>.</para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> in the I/O stack location of the IRP indicates the size, in bytes, of the output
	/// buffer, which must be &gt;= <b>sizeof</b>(ULONG).
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>Greater than or equal to <b>sizeof</b>(ULONG).</para>
	/// <para>Output buffer</para>
	/// <para><b>Irp-&gt;AssociatedIrp.SystemBuffer</b> points to a buffer that will receive the polling frequency.</para>
	/// <para>Status block</para>
	/// <para>The HID class driver sets the following fields of <b>Irp-&gt;IoStatus</b>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><b>Information</b> is set to <b>sizeof</b>(ULONG) if the polling frequency is successfully retrieved.</description>
	/// </item>
	/// <item>
	/// <description>
	/// <b>Status</b> is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_get_poll_frequency_msec
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_GET_POLL_FREQUENCY_MSEC")]
	public static readonly uint IOCTL_HID_GET_POLL_FREQUENCY_MSEC = HID_BUFFER_CTL_CODE(102);

	/// <summary>
	/// <para>
	/// The IOCTL_HID_GET_PRODUCT_STRING request obtains a <c>top-level collection's</c> embedded string that identifies the manufacturer's
	/// product. The retrieved string is a NULL-terminated wide character string in a human-readable format.
	/// </para>
	/// <para>For general information about HIDClass devices [HID Collections(/windows-hardware/drivers/hid/hid-collections).</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> in the I/O stack location of the IRP indicates the size, in bytes, of the output
	/// buffer. If the output buffer is not large enough to hold the entire NULL-terminated embedded string, the request returns nothing in
	/// the output buffer.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>
	/// The maximum possible number of characters in an embedded string is device specific. For USB devices, the maximum string length is 126
	/// wide characters (not including the terminating NULL character).
	/// </para>
	/// <para>Output buffer</para>
	/// <para><b>Irp-&gt;MdlAddress</b> points to a buffer to receive the product ID string (a NULL-terminated wide character string).</para>
	/// <para>Output buffer length</para>
	/// <para>The length of a NULL-terminated wide character string. The supplied buffer must be &lt;= 4093 bytes (2^12 – 3).</para>
	/// <para>Status block</para>
	/// <para>The HID class driver sets the following fields of <b>Irp-&gt;IoStatus</b>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para><b>Information</b> is set to the number of bytes transferred from the device.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// <b>Status</b> is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_get_product_string
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_GET_PRODUCT_STRING")]
	public static readonly uint IOCTL_HID_GET_PRODUCT_STRING = HID_OUT_CTL_CODE(111);

	/// <summary>
	/// <para>
	/// The IOCTL_HID_GET_SERIALNUMBER_STRING request obtains a <c>top-level collection's</c> embedded string that identifies the device's
	/// serial number. The retrieved string is a NULL-terminated wide character string in a human-readable format.
	/// </para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> in the I/O stack location of the IRP indicates the size, in bytes, of the output
	/// buffer. If the output buffer is not large enough to hold the entire NULL-terminated embedded string, the request returns nothing in
	/// the output buffer.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>
	/// The maximum possible number of characters in an embedded string is device specific. For USB devices, the maximum string length is 126
	/// wide characters (not including the terminating NULL character).
	/// </para>
	/// <para>Output buffer</para>
	/// <para><b>Irp-&gt;MdlAddress</b> points to a buffer to receive the serial number string (a NULL-terminated wide character string).</para>
	/// <para>Output buffer length</para>
	/// <para>The length of a NULL-terminated wide character string. The supplied buffer must be &lt;= 4093 bytes (2^12 – 3).</para>
	/// <para>Status block</para>
	/// <para>The HID class driver sets the following fields of <b>Irp-&gt;IoStatus</b>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para><b>Information</b> is set to the number of bytes transferred from the device.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// <b>Status</b> is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_get_serialnumber_string
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_GET_SERIALNUMBER_STRING")]
	public static readonly uint IOCTL_HID_GET_SERIALNUMBER_STRING = HID_OUT_CTL_CODE(112);

	/// <summary>
	/// <para>The <b>IOCTL_HID_SET_DRIVER_CONFIG</b> request sets the driver configuration.</para>
	/// <para>This IOCTL is reserved for system use.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Status block</para>
	/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
	/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
	/// <para>For more information, see <c>NTSTATUS Values</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_set_driver_config
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_SET_DRIVER_CONFIG")]
	public static readonly uint IOCTL_HID_SET_DRIVER_CONFIG = HID_BUFFER_CTL_CODE(101);

	/// <summary>
	/// <para>The IOCTL_HID_SET_FEATURE request sends a feature report to a <c>top-level collection</c>.</para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// The <c>Parameters.DeviceIoControl.InputBufferLength</c> member is set to the size, in bytes, of a requester-allocated input buffer
	/// that contains a HID class feature report.
	/// </para>
	/// <para>
	/// The size of the input buffer in bytes. The buffer must be large enough to hold the feature report plus one additional byte that
	/// specifies a nonzero report ID. If report ID is not used, the ID value is zero.
	/// </para>
	/// <para>
	/// The <c>Irp-&gt;AssociatedIrp.SystemBuffer</c> member points to the input buffer that contains a feature report. If the collection
	/// includes report IDs, the requester must set the first byte of the buffer to a nonzero report ID; otherwise the requester must set the
	/// first byte to zero. The feature report is located at <c>((PUCHAR)ReportBuffer + 1)</c>.
	/// </para>
	/// <para><b>Minidriver handling</b></para>
	/// <para>
	/// <c>Irp-&gt;UserBuffer</c> points to a <c>HID_XFER_PACKET</c> structure that the HID class driver uses to input the following members:
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>
	/// The size of the input buffer in bytes. The buffer must be large enough to hold the output report plus one additional byte that
	/// specifies a nonzero report ID. If report ID is not used, the ID value is zero.
	/// </para>
	/// <para><b>Minidriver handling</b></para>
	/// <para>The size of a <c>HID_XFER_PACKET</c> structure.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None.</para>
	/// <para>Status block</para>
	/// <para>The HID class driver sets the following fields of <c>Irp-&gt;IoStatus</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Information is set to zero.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Status is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code
	/// </description>
	/// </item>
	/// </list>
	/// <para><b>Minidriver handling</b></para>
	/// <para>HID minidrivers that carry out the I/O to the device set the following fields of <c>Irp-&gt;IoStatus</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Information is set to the number of bytes transferred to the device.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Status is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// HID minidrivers that call other drivers with this IOCTL to carry out the I/O, should ensure that the Information field of the status
	/// block is correct and not change the contents of the Status field.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_set_feature
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_SET_FEATURE")]
	public static readonly uint IOCTL_HID_SET_FEATURE = HID_IN_CTL_CODE(100);

	/// <summary>
	/// <para>The IOCTL_HID_SET_OUTPUT_REPORT request sends an output report to a <c>top-level collection</c>.</para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// The <c>Parameters.DeviceIoControl.InputBufferLength</c> member is set to the size, in bytes, of a requester-allocated input buffer
	/// that contains a HID class output report.
	/// </para>
	/// <para>
	/// The size of the input buffer in bytes. The buffer must be large enough to hold the output report plus one additional byte that
	/// specifies a nonzero report ID. If report ID is not used, the ID value is zero.
	/// </para>
	/// <para>
	/// The <c>Irp-&gt;AssociatedIrp.SystemBuffer</c> member points to the input buffer that contains an output report. If the collection
	/// includes report IDs, the requester must set the first byte of the buffer to a nonzero report ID. Otherwise, the requester must set
	/// the first byte to zero. The output report is located at <c>((PUCHAR)ReportBuffer + 1)</c>.
	/// </para>
	/// <para><b>Minidriver handling</b></para>
	/// <para>
	/// <c>Irp-&gt;UserBuffer</c> points to a <c>HID_XFER_PACKET</c> structure that the HID class driver uses to input the following members:
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>
	/// The size of the input buffer in bytes. The buffer must be large enough to hold the output report plus one additional byte that
	/// specifies a nonzero report ID. If report ID is not used, the ID value is zero.
	/// </para>
	/// <para><b>Minidriver handling</b></para>
	/// <para>The size of a <c>HID_XFER_PACKET</c> structure.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None.</para>
	/// <para>Status block</para>
	/// <para>The HID class driver sets the following fields of <c>Irp-&gt;IoStatus</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Information is set to zero.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Status is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// <para><b>Minidriver handling</b></para>
	/// <para>HID minidrivers that carry out the I/O to the device set the following fields of <c>Irp-&gt;IoStatus</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Information is set to the number of bytes transferred to the device.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Status is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// HID minidrivers that call other drivers with this IOCTL to carry out the I/O should ensure that the Information field of the status
	/// block is correct and not change the contents of the Status field.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_set_output_report
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_SET_OUTPUT_REPORT")]
	public static readonly uint IOCTL_HID_SET_OUTPUT_REPORT = HID_IN_CTL_CODE(101);

	/// <summary>
	/// <para>The IOCTL_HID_SET_POLL_FREQUENCY_MSEC request sets the polling frequency, in milliseconds, for a <c>top-level collection</c>.</para>
	/// <para>
	/// User-mode applications or kernel-mode drivers that perform irregular, opportunistic reads on a polled device must furnish a polling
	/// interval of zero. In such cases, IOCTL_HID_SET_POLL_FREQUENCY_MSEC does not actually change the polling frequency of the device; but
	/// if the report data is not stale when it is read, the read is completed immediately with the latest report data for the indicated
	/// collection. If the report data is stale, it is refreshed immediately, without waiting for the expiration of the polling interval, and
	/// the read is completed with the new data.
	/// </para>
	/// <para>
	/// If the value for the polling interval that is provided in the IRP is not zero, it must be &gt;= MIN_POLL_INTERVAL_MSEC and &lt;= MAX_POLL_INTERVAL_MSEC.
	/// </para>
	/// <para>Polling may be limited if there are multiple top-level collections.</para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.InputBufferLength</b> in the I/O stack location of the IRP indicates the size, in bytes, of the input
	/// buffer, which must be &gt;= <b>sizeof</b>(ULONG).
	/// </para>
	/// <para><b>Irp-&gt;AssociatedIrp.SystemBuffer</b> contains the new polling interval.</para>
	/// <para>Input buffer length</para>
	/// <para>A value greater than or equal to <b>sizeof</b>(ULONG).</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None.</para>
	/// <para>Status block</para>
	/// <para>
	/// The HID class driver sets the <b>Status</b> member of <b>Irp-&gt;IoStatus</b> to STATUS_SUCCESS if the transfer completed without
	/// error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_set_poll_frequency_msec
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_SET_POLL_FREQUENCY_MSEC")]
	public static readonly uint IOCTL_HID_SET_POLL_FREQUENCY_MSEC = HID_BUFFER_CTL_CODE(103);

	/// <summary>
	/// <para>
	/// The <b>IOCTL_HID_SET_S0_IDLE_TIMEOUT</b> request is used by a client to inform the HID class driver about the client's preferred idle
	/// timeout value.
	/// </para>
	/// <para>
	/// When the client sets this value to zero (0), it informs the HID class driver that the preferred idle timeout value is no longer
	/// valid. In this case, the HID class driver will start to use the default idle timeout value.
	/// </para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// The <b>Parameters.DeviceIoControl.OutputBufferLength</b> member specifies the size, in bytes, of a requester-allocated output buffer.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>This is a buffer of size ULONG.</para>
	/// <para>Output buffer</para>
	/// <para>
	/// The <b>Irp-&gt;AssociatedIrp.SystemBuffer</b> member is a pointer to the requestor-allocated buffer that the client uses to return
	/// the idle timeout value.
	/// </para>
	/// <para>Status block</para>
	/// <para>
	/// <b>Irp-&gt;IoStatus.Status</b> is set to STATUS_SUCCESS if the request is successful. Otherwise, Status to the appropriate error
	/// condition as a <c>NTSTATUS</c> code.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_hid_set_s0_idle_timeout
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_HID_SET_S0_IDLE_TIMEOUT")]
	public static readonly uint IOCTL_HID_SET_S0_IDLE_TIMEOUT = HID_BUFFER_CTL_CODE(108);

	/// <summary>
	/// <para>The IOCTL_SET_NUM_DEVICE_INPUT_BUFFERS request sets the number of buffers for the input report queue of a <c>top-level collection</c>.</para>
	/// <para>
	/// Each input report queue is implemented as a ring buffer. If a collection transmits data to the HID class driver faster than the
	/// driver can read it, some of the data may be lost. To prevent this type of loss, you can use an IOCTL_SET_NUM_DEVICE_INPUT_BUFFERS
	/// request to adjust the number of buffers that the input report queue contains. The HID class driver requires a minimum of two input
	/// buffers. On Windows 2000, the maximum number of input buffers that the HID class driver supports is 200, and on Windows XP and later,
	/// the maximum number of input buffers that the HID class driver supports is 512. The default number of input buffers is 32.
	/// </para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Irp-&gt;AssociatedIrp.SystemBuffer</b> points to a ULONG-sized input buffer that receives the new number of buffers for the input
	/// report queue.
	/// </para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.InputBufferLength</b> in the I/O stack location of the IRP contains the size, in bytes, of the input
	/// buffer at <b>Irp-&gt;AssociatedIrp.SystemBuffer</b>. This size must be <b>sizeof</b>(ULONG).
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of a ULONG.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None.</para>
	/// <para>Status block</para>
	/// <para>
	/// If the request succeeds, the HID class driver sets the <b>Status</b> field of <b>Irp-&gt;IoStatus</b> to STATUS_SUCCESS; otherwise,
	/// it sets the <b>Status</b> field to an appropriate NTSTATUS error code.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ni-hidclass-ioctl_set_num_device_input_buffers
	[PInvokeData("hidclass.h", MSDNShortId = "NI:hidclass.IOCTL_SET_NUM_DEVICE_INPUT_BUFFERS")]
	public static readonly uint IOCTL_SET_NUM_DEVICE_INPUT_BUFFERS = HID_BUFFER_CTL_CODE(105);

	private const string Lib_Hid = "Hid.dll";

	/// <summary>The <b>HidP_GetCaps</b> routine returns a <c>top-level collection's</c>  <c>HIDP_CAPS</c> structure.</summary>
	/// <param name="PreparsedData">Pointer to a top-level collection's <c>preparsed data</c>.</param>
	/// <param name="Capabilities">Pointer to a caller-allocated buffer that the routine uses to return a collection's HIDP_CAPS structure.</param>
	/// <returns>
	/// <para><b>HidP_GetCaps</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully returned the collection capability information.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The specified preparsed data is invalid.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For more information about a collection's capability, see <c>Obtaining Collection Information</c>.</para>
	/// <para>See also <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/nc-hidclass-phidp_getcaps PHIDP_GETCAPS PhidpGetcaps; NTSTATUS
	// PhidpGetcaps( [in] PHIDP_PREPARSED_DATA PreparsedData, [out] PHIDP_CAPS Capabilities ) {...}
	[PInvokeData("hidclass.h", MSDNShortId = "NC:hidclass.PHIDP_GETCAPS")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate NTStatus PHIDP_GETCAPS([In] PHIDP_PREPARSED_DATA PreparsedData, out HIDP_CAPS Capabilities);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint HID_BUFFER_CTL_CODE(ushort id) => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, id, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

	// Macro for defining HID ioctls
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint HID_CTL_CODE(ushort id) => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, id, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint HID_IN_CTL_CODE(ushort id) => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, id, IOMethod.METHOD_IN_DIRECT, IOAccess.FILE_ANY_ACCESS);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint HID_OUT_CTL_CODE(ushort id) => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, id, IOMethod.METHOD_OUT_DIRECT, IOAccess.FILE_ANY_ACCESS);

	/// <summary>The HID_COLLECTION_INFORMATION structure contains general information about a <c>top-level collection</c>.</summary>
	/// <remarks>
	/// Kernel-mode drivers can use an <c>IOCTL_HID_GET_COLLECTION_INFORMATION</c> to obtain a collection's <b>HID_COLLECTION_INFORMATION</b> structure.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ns-hidclass-_hid_collection_information typedef struct
	// _HID_COLLECTION_INFORMATION { ULONG DescriptorSize; BOOLEAN Polled; UCHAR Reserved1[1]; USHORT VendorID; USHORT ProductID; USHORT
	// VersionNumber; } HID_COLLECTION_INFORMATION, *PHID_COLLECTION_INFORMATION;
	[PInvokeData("hidclass.h", MSDNShortId = "NS:hidclass._HID_COLLECTION_INFORMATION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HID_COLLECTION_INFORMATION
	{
		/// <summary>Specifies the size, in bytes, of a collection's <c>preparsed data</c>.</summary>
		public uint DescriptorSize;

		/// <summary>
		/// Indicates, if <b>TRUE</b>, that the HID class driver must poll the device to receive data. Otherwise, if <b>Polled</b> is
		/// <b>FALSE</b>, the device uses asynchronous interrupts to signal the host that the device has HID reports to send to the host.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool Polled;

		/// <summary>Reserved for internal system use.</summary>
		public byte Reserved1;

		/// <summary>Specifies a HID device's vendor ID.</summary>
		public ushort VendorID;

		/// <summary>Specifies a HID device's product ID.</summary>
		public ushort ProductID;

		/// <summary>Specifies the manufacturer's revision number for a HID device.</summary>
		public ushort VersionNumber;
	}

	/// <summary>
	/// The HID_XFER_PACKET structure contains information about a HID report that the HID class driver uses with I/O requests to get or set
	/// a report.
	/// </summary>
	/// <remarks>
	/// The HID class driver uses this structure to specify information about a HID report when it uses an I/O request to get or set a report.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidclass/ns-hidclass-_hid_xfer_packet typedef struct _HID_XFER_PACKET {
	// PUCHAR reportBuffer; ULONG reportBufferLen; UCHAR reportId; } HID_XFER_PACKET, *PHID_XFER_PACKET;
	[PInvokeData("hidclass.h", MSDNShortId = "NS:hidclass._HID_XFER_PACKET")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HID_XFER_PACKET
	{
		/// <summary>Pointer to a report buffer.</summary>
		public StructPointer<byte> reportBuffer;

		/// <summary>Specifies the length of the report at <b>reportBuffer</b>.</summary>
		public uint reportBufferLen;

		/// <summary>
		/// Specifies the report ID of the report contained at <b>reportBuffer</b>. This parameter is optional, and, if not specified, should
		/// be set to zero.
		/// </summary>
		public byte reportId;
	}
}