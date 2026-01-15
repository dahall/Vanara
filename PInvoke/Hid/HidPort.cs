namespace Vanara.PInvoke;

public static partial class Hid
{
	/// <summary>Codes for HID-specific descriptor types, from HID USB spec.</summary>
	public const int HID_HID_DESCRIPTOR_TYPE = 0x21;

	/// <summary>Codes for HID-specific descriptor types, from HID USB spec.</summary>
	public const int HID_PHYSICAL_DESCRIPTOR_TYPE = 0x23;

	/// <summary>Codes for HID-specific descriptor types, from HID USB spec.</summary>
	public const int HID_REPORT_DESCRIPTOR_TYPE = 0x22;

	/// <summary>These are string IDs for use with IOCTL_HID_GET_STRING. They match the string field offsets in Chapter 9 of the USB Spec.</summary>
	public const int HID_STRING_ID_IMANUFACTURER = 14;

	/// <summary>These are string IDs for use with IOCTL_HID_GET_STRING. They match the string field offsets in Chapter 9 of the USB Spec.</summary>
	public const int HID_STRING_ID_IPRODUCT = 15;

	/// <summary>These are string IDs for use with IOCTL_HID_GET_STRING. They match the string field offsets in Chapter 9 of the USB Spec.</summary>
	public const int HID_STRING_ID_ISERIALNUMBER = 16;

	/// <summary>Used in conjunction with IOCTL_HID_SEND_IDLE_NOTIFICATION_REQUEST sent down by HIDCLASS during runtime idling.</summary>
	/// <param name="Context">The context.</param>
	[PInvokeData("hidport.h")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void HID_SEND_IDLE_CALLBACK([In] IntPtr Context);

	/// <summary>
	/// <para>The IOCTL_HID_ACTIVATE_DEVICE request activates a HIDClass device, which makes it ready for I/O operations.</para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.Type3InputBuffer</b> contains a collection identifier, as a ULONG value, of the collection to activate.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The length of a ULONG value.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None.</para>
	/// <para>Status block</para>
	/// <para>HID minidrivers that carry out the I/O to the device set the following fields of <b>Irp-&gt;IoStatus</b>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><b>Information</b> is set to zero.</description>
	/// </item>
	/// <item>
	/// <description>
	/// <b>Status</b> is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// Minidrivers that call other drivers with this IRP to carry out the I/O to their device should ensure that the <b>Information</b>
	/// field of the status block is zero and not change the contents of the <b>Status</b> field.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ni-hidport-ioctl_hid_activate_device
	[PInvokeData("hidport.h", MSDNShortId = "NI:hidport.IOCTL_HID_ACTIVATE_DEVICE")]
	[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
	public static uint IOCTL_HID_ACTIVATE_DEVICE => HID_CTL_CODE(7);

	/// <summary>
	/// <para>
	/// The IOCTL_HID_DEACTIVATE_DEVICE request deactivates a HIDClass device, which causes it to stop operations and terminate all
	/// outstanding I/O requests.
	/// </para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.Type3InputBuffer</b> contains the collection identifier, as a ULONG value, of the collection that is
	/// ceasing operations.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The length of a ULONG value.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None</para>
	/// <para>Status block</para>
	/// <para>HID minidrivers that carry out the I/O to the device set the following fields of <b>Irp-&gt;IoStatus</b>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><b>Information</b> is set to zero.</description>
	/// </item>
	/// <item>
	/// <description>
	/// <b>Status</b> is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// HID minidrivers that call other drivers with this IRP to carry out the I/O to their device should ensure that the <b>Information</b>
	/// field of the status block is zero and must not change the contents of the <b>Status</b> field.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ni-hidport-ioctl_hid_deactivate_device
	[PInvokeData("hidport.h", MSDNShortId = "NI:hidport.IOCTL_HID_DEACTIVATE_DEVICE")]
	[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
	public static uint IOCTL_HID_DEACTIVATE_DEVICE => HID_CTL_CODE(8);

	/// <summary>
	/// <para>The IOCTL_HID_GET_DEVICE_ATTRIBUTES request obtains a HIDClass device's attributes in a <c>HID_DEVICE_ATTRIBUTES</c> structure.</para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> contains the length, in bytes, of the HID class driver's buffer located at <b>Irp-&gt;UserBuffer</b>.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size, in bytes, of the buffer must be greater than or equal to the size, in bytes, of a HID_DEVICE_ATTRIBUTES structure.</para>
	/// <para>Output buffer</para>
	/// <para>The HID minidriver returns the device attributes in a HID_DEVICE_ATTRIBUTES structure at <b>Irp-&gt;UserBuffer</b>.</para>
	/// <para>Output buffer length</para>
	/// <para>The size of a HID_DEVICE_ATTRIBUTES structure.</para>
	/// <para>Status block</para>
	/// <para>The HID minidriver sets the following fields of <b>Irp-&gt;IoStatus</b>:</para>
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
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ni-hidport-ioctl_hid_get_device_attributes
	[PInvokeData("hidport.h", MSDNShortId = "NI:hidport.IOCTL_HID_GET_DEVICE_ATTRIBUTES")]
	public static uint IOCTL_HID_GET_DEVICE_ATTRIBUTES => HID_CTL_CODE(9);

	/// <summary>
	/// <para>The IOCTL_HID_GET_DEVICE_DESCRIPTOR request obtains a HIDClass device's HID descriptor.</para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para><b>Parameters.DeviceIoControl.OutputBufferLength</b> contains the length of the system-resident buffer provided at <b>Irp-&gt;UserBuffer</b>.</para>
	/// <para>Input buffer length</para>
	/// <para>The size of <b>OutputBufferLength</b>.</para>
	/// <para>Output buffer</para>
	/// <para>The HID minidriver returns the device descriptor in the user buffer at <b>Irp-&gt;UserBuffer</b>.</para>
	/// <para>Output buffer length</para>
	/// <para>The size of the device descriptor.</para>
	/// <para>Status block</para>
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
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ni-hidport-ioctl_hid_get_device_descriptor
	[PInvokeData("hidport.h", MSDNShortId = "NI:hidport.IOCTL_HID_GET_DEVICE_DESCRIPTOR")]
	public static uint IOCTL_HID_GET_DEVICE_DESCRIPTOR => HID_CTL_CODE(0);

	/// <summary>
	/// <para>The IOCTL_HID_GET_REPORT_DESCRIPTOR request obtains the report descriptor for a HIDClass device.</para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para><b>Parameters.DeviceIoControl.OutputBufferLength</b> specifies the length, in bytes, of the locked-down buffer at <b>Irp-&gt;UserBuffer</b>.</para>
	/// <para>Input buffer length</para>
	/// <para>The size of <b>OutputBufferLength</b>.</para>
	/// <para>Output buffer</para>
	/// <para>The HID minidriver fills the buffer at <b>Irp-&gt;UserBuffer</b> with the report descriptor.</para>
	/// <para>Output buffer length</para>
	/// <para>The size of the report descriptor.</para>
	/// <para>Status block</para>
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
	/// HID minidrivers that call other drivers with this IOCTL to carry out the I/O to their device, should ensure that the
	/// <b>Information</b> field of the status block is correct and not change the contents of the <b>Status</b> field.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ni-hidport-ioctl_hid_get_report_descriptor
	[PInvokeData("hidport.h", MSDNShortId = "NI:hidport.IOCTL_HID_GET_REPORT_DESCRIPTOR")]
	public static uint IOCTL_HID_GET_REPORT_DESCRIPTOR => HID_CTL_CODE(1);

	/// <summary>
	/// <para>
	/// The IOCTL_HID_GET_STRING request obtains a manufacturer ID, product ID, or serial number for a <c>top-level collection</c>. The
	/// retrieved string is a NULL-terminated wide character string in a human-readable format.
	/// </para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>IOCTL_HID_GET_STRING makes use of two input buffers.</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> in the I/O stack location of the IRP indicates the size, in bytes, of the
	/// locked-down output buffer at <b>Irp-&gt;UserBuffer</b>. If the output buffer is not large enough to hold the entire NULL-terminated
	/// embedded string, the request returns nothing in the output buffer. The maximum possible number of characters in an embedded string is
	/// device specific. For USB devices, the maximum string length is 126 wide characters (not including the terminating NULL character).
	/// </para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.Type3InputBuffer</b> in the I/O stack location of the IRP contains a composite value. The two most
	/// significant bytes contain the language ID of the string to be retrieved. The two least significant bytes contain one of the following
	/// three constant values:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>HID_STRING_ID_IMANUFACTURER</description>
	/// </item>
	/// <item>
	/// <description>HID_STRING_ID_IPRODUCT</description>
	/// </item>
	/// <item>
	/// <description>HID_STRING_ID_ISERIALNUMBER</description>
	/// </item>
	/// </list>
	/// <para>
	/// The HID minidriver determines which of these three constants is present in the lower two bytes of the input buffer, then it must
	/// retrieve the corresponding string index from the device descriptor. Device descriptor information is stored in the device extension
	/// of a top-level collection associated with the device.
	/// </para>
	/// <para>
	/// It is important not to confuse these three constants with the actual string indices of the IDs. These constants represent the offsets
	/// in the device descriptor where the corresponding string indices can be found.
	/// </para>
	/// <para>
	/// For example, HID_STRING_ID_IMANUFACTURER indicates the location in the device descriptor where the index for the manufacturer ID is
	/// found. This index, in turn, serves as an offset into the string descriptor where the human-readable form of the manufacturer ID is located.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of the <b>OutputBufferLength</b> and the size of the <b>Type3InputBuffer</b>.</para>
	/// <para>Output buffer</para>
	/// <para>
	/// The HID minidriver fills the buffer at <b>Irp-&gt;UserBuffer</b> with the requested string (a NULL-terminated wide character string).
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The size of the <b>UserBuffer</b>.</para>
	/// <para>Status block</para>
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
	/// HID minidrivers that call other drivers with this IOCTL to carry out the I/O to their device, should ensure that the
	/// <b>Information</b> field of the status block is correct and not change the contents of the <b>Status</b> field.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ni-hidport-ioctl_hid_get_string
	[PInvokeData("hidport.h", MSDNShortId = "NI:hidport.IOCTL_HID_GET_STRING")]
	public static uint IOCTL_HID_GET_STRING => HID_CTL_CODE(4);

	/// <summary>
	/// <para>The IOCTL_HID_READ_REPORT request transfers an input report from a HIDClass device into the HID class driver's buffer.</para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para><b>Parameters.DeviceIoControl.OutputBufferLength</b> contains the size of the buffer provided at <b>Irp-&gt;UserBuffer</b>.</para>
	/// <para>Input buffer length</para>
	/// <para>The size of <b>OutputBufferLength</b></para>
	/// <para>Output buffer</para>
	/// <para>
	/// HID minidriver fills the system-resident buffer pointed to by <b>Irp-&gt;UserBuffer</b> with the report data retrieved from the device.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The size of the <b>UserBuffer</b>.</para>
	/// <para>Status block</para>
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
	/// <remarks>
	/// IOCTL_HID_READ_REPORT is typically used for continuously completing input reports that are sent by the device. This IOCTL is sent
	/// down by the HID class driver (HIDCLASS) in ping-pong fashion. In other words, as soon as a request is fulfilled (completed), another
	/// one can be sent down to the device, allowing for continuous reporting of data. This is an “asynchronous” mechanism, so for example,
	/// the device can use it to send data up to the host, regarding changes in state as those changes occur.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ni-hidport-ioctl_hid_read_report
	[PInvokeData("hidport.h", MSDNShortId = "NI:hidport.IOCTL_HID_READ_REPORT")]
	public static uint IOCTL_HID_READ_REPORT => HID_CTL_CODE(2);

	/// <summary>
	/// <para>
	/// The <b>IOCTL_HID_SEND_IDLE_NOTIFICATION_REQUEST</b> control code is the IOCTL of the idle notification request IRP that HIDClass
	/// sends to HID mini drivers, such as HIDUSB, to inform the bus driver that the device is now idle.
	/// </para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Irp-&gt;IoStatus.Status</b> is set to STATUS_SUCCESS if the request is successful. Otherwise, Status to the appropriate error
	/// condition as a <c>NTSTATUS</c> code.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of a status code.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None.</para>
	/// <para>Status block</para>
	/// <para>The bus or port driver sets Irp-&gt;IoStatus.Status to STATUS_SUCCESS or the appropriate error status.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ni-hidport-ioctl_hid_send_idle_notification_request
	[PInvokeData("hidport.h", MSDNShortId = "NI:hidport.IOCTL_HID_SEND_IDLE_NOTIFICATION_REQUEST")]
	public static uint IOCTL_HID_SEND_IDLE_NOTIFICATION_REQUEST => HID_CTL_CODE(10);

	/// <summary>
	/// <para>The IOCTL_HID_WRITE_REPORT request sends a HID report to a HIDClass device.</para>
	/// <para>For general information about HIDClass devices, see <c>HID Collections</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Irp-&gt;UserBuffer</b> points to a <c>HID_XFER_PACKET</c> structure the contains the parameters and report to be transmitted to
	/// the device. The following members are used:
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of a <c>HID_XFER_PACKET</c> structure.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None.</para>
	/// <para>Status block</para>
	/// <para>HID minidrivers that carry out the I/O to the device set the following fields of <b>Irp-&gt;IoStatus</b>:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><b>Information</b> is set to the number of bytes transferred to the device.</description>
	/// </item>
	/// <item>
	/// <description>
	/// <b>Status</b> is set to STATUS_SUCCESS if the transfer completed without error. Otherwise, it is set to an appropriate NTSTATUS error code.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// HID minidrivers that call other drivers with this IOCTL to carry out the I/O to their device, should ensure that the
	/// <b>Information</b> field of the status block is correct and not change the contents of the <b>Status</b> field.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ni-hidport-ioctl_hid_write_report
	[PInvokeData("hidport.h", MSDNShortId = "NI:hidport.IOCTL_HID_WRITE_REPORT")]
	[CorrespondingType(typeof(HID_XFER_PACKET), CorrespondingAction.Get)]
	public static uint IOCTL_HID_WRITE_REPORT => HID_CTL_CODE(3);

	/// <summary>
	/// <para>The <b>IOCTL_UMDF_GET_PHYSICAL_DESCRIPTOR</b> control code obtains the physical descriptor of a HIDClass device.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// A UMDF-based driver obtains the size, in bytes, of the buffer by calling <c>IWDFRequest::GetDeviceIoControlParameters</c> and
	/// providing the <i>pOutBufferSize</i> parameter.
	/// </para>
	/// <para>Output buffer</para>
	/// <para>The driver copies the physical descriptor to the user buffer that is retrieved by calling <c>IWDFIoRequest::GetOutputMemory</c>.</para>
	/// <para>Output buffer length</para>
	/// <para>The size of the buffer that is retrieved by calling <c>IWDFIoRequest::GetOutputMemory</c>.</para>
	/// <para>Status block</para>
	/// <para>HID minidrivers that carry out the I/O to the device must also:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Call <c>IWDFRequest::SetInformation</c> to set the number of bytes transferred from the device.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Call <c>IWDFRequest::Complete</c> with S_OK to complete the request without error. Otherwise, set the appropriate HRESULT error code.
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ni-hidport-ioctl_umdf_get_physical_descriptor
	[PInvokeData("hidport.h", MSDNShortId = "NI:hidport.IOCTL_UMDF_GET_PHYSICAL_DESCRIPTOR")]
	public static uint IOCTL_UMDF_GET_PHYSICAL_DESCRIPTOR => HID_CTL_CODE(24);

	/// <summary>
	/// <para>The <b>IOCTL_UMDF_HID_GET_FEATURE</b> control code obtains a <c>feature report</c> from a HIDClass device.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// A UMDF-based driver calls <c>IWDFRequest::GetInputMemory</c> to retrieve a requester-allocated input buffer that contains the report
	/// ID of the collection.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of the buffer obtained by calling <c>IWDFRequest::GetInputMemory</c>.</para>
	/// <para>Output buffer</para>
	/// <para>
	/// A UMDF-based driver calls <c>IWDFRequest::GetOutputMemory</c> to retrieve a requester-allocated output buffer. The driver uses the
	/// buffer to return a feature report.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The size of the buffer that is retrieved by calling <c>IWDFIoRequest::GetOutputMemory</c>.</para>
	/// <para>Status block</para>
	/// <para>HID minidrivers that carry out the I/O to the device must also:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Call <c>IWDFRequest::SetInformation</c> to set the number of bytes transferred from the device.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Call <c>IWDFRequest::Complete</c> with S_OK to complete the request without error. Otherwise, set the appropriate HRESULT error code.
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ni-hidport-ioctl_umdf_hid_get_feature
	[PInvokeData("hidport.h", MSDNShortId = "NI:hidport.IOCTL_UMDF_HID_GET_FEATURE")]
	public static uint IOCTL_UMDF_HID_GET_FEATURE => HID_CTL_CODE(21);

	/// <summary>
	/// <para>The <b>IOCTL_UMDF_HID_GET_INPUT_REPORT</b> control code returns an <c>input report</c> from a HIDClass device.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// A UMDF-based driver calls <c>IWDFRequest::GetInputMemory</c> to retrieve a memory buffer that contains the report ID of the collection.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of the buffer retrieved by calling <c>IWDFRequest::GetInputMemory</c>.</para>
	/// <para>Output buffer</para>
	/// <para>
	/// A UMDF-based driver calls <c>IWDFRequest::GetOutputMemory</c> to retrieve a requester-allocated output buffer that it uses to return
	/// a feature report.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The size of the buffer that is retrieved by calling <c>IWDFIoRequest::GetOutputMemory</c>.</para>
	/// <para>Status block</para>
	/// <para>HID minidrivers that carry out the I/O to the device must also:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Call <c>IWDFRequest::SetInformation</c> to set the number of bytes transferred from the device.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Call <c>IWDFRequest::Complete</c> with S_OK to complete the request without error. Otherwise, set the appropriate HRESULT error code.
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ni-hidport-ioctl_umdf_hid_get_input_report
	[PInvokeData("hidport.h", MSDNShortId = "NI:hidport.IOCTL_UMDF_HID_GET_INPUT_REPORT")]
	public static uint IOCTL_UMDF_HID_GET_INPUT_REPORT => HID_CTL_CODE(23);

	/// <summary>
	/// <para>The <c>IOCTL_UMDF_HID_GET_FEATURE</c> control code sends a <c>feature report</c> to a HIDClass device.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// A UMDF-based driver calls <c>IWDFRequest::GetInputMemory</c> to retrieve a requester-allocated input buffer that contains a feature report.
	/// </para>
	/// <para>
	/// The driver retrieves the report ID associated with the top-level collection by calling
	/// <c>IWDFRequest::GetDeviceIoControlParameters</c> and providing the <i>pOutBufferSize</i> parameter, as shown in the following example.
	/// </para>
	/// <para>
	/// <c>UCHAR reportId; SIZE_T outBufferSize; FxRequest-&gt;GetDeviceIoControlParameters(NULL, NULL, &amp;outBufferSize); reportId = (UCHAR)outBufferSize;</c>
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>None.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>The size of the buffer that is retrieved by calling <c>IWDFIoRequest::GetOutputMemory</c>.</para>
	/// <para>Status block</para>
	/// <para>HID minidrivers that carry out the I/O to the device must also:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Call <c>IWDFRequest::SetInformation</c> to set the number of bytes transferred to the device.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Call <c>IWDFRequest::Complete</c> with S_OK to complete the request without error. Otherwise, set the appropriate HRESULT error code.
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ni-hidport-ioctl_umdf_hid_set_feature
	[PInvokeData("hidport.h", MSDNShortId = "NI:hidport.IOCTL_UMDF_HID_SET_FEATURE")]
	public static uint IOCTL_UMDF_HID_SET_FEATURE => HID_CTL_CODE(20);

	/// <summary>
	/// <para>The <b>IOCTL_UMDF_HID_SET_OUTPUT_REPORT</b> control code sends an <c>output report</c> to a <c>top-level collection</c>.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// A UMDF-based driver calls <c>IWDFRequest::GetInputMemory</c> to retrieve a requester-allocated input buffer that contains an output report.
	/// </para>
	/// <para>
	/// The driver retrieves the report ID associated with the top-level collection by calling
	/// <c>IWDFRequest::GetDeviceIoControlParameters</c> and providing the <i>pOutBufferSize</i> parameter, as shown in the following example.
	/// </para>
	/// <para>
	/// <c>UCHAR reportId; SIZE_T outBufferSize; FxRequest-&gt;GetDeviceIoControlParameters(NULL, NULL, &amp;outBufferSize); reportId = (UCHAR)outBufferSize;</c>
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>None.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>The size of the buffer that is retrieved by calling <c>IWDFIoRequest::GetOutputMemory</c>.</para>
	/// <para>Status block</para>
	/// <para>HID minidrivers that carry out the I/O to the device must also:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Call <c>IWDFRequest::SetInformation</c> to set the number of bytes transferred to the device.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Call <c>IWDFRequest::Complete</c> with S_OK to complete the request without error. Otherwise, set the appropriate HRESULT error code.
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ni-hidport-ioctl_umdf_hid_set_output_report
	[PInvokeData("hidport.h", MSDNShortId = "NI:hidport.IOCTL_UMDF_HID_SET_OUTPUT_REPORT")]
	public static uint IOCTL_UMDF_HID_SET_OUTPUT_REPORT => HID_CTL_CODE(22);

	/// <summary>
	/// The HidNotifyPresence function is reserved for the HID driver internal framework and is not intended to be used by your code.
	/// </summary>
	/// <param name="DeviceObject"/>
	/// <param name="IsPresent"/>
	/// <returns>This function returns NTSTATUS.</returns>
	[PInvokeData("hidport.h", MSDNShortId = "NF:hidport.HidNotifyPresence")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidNotifyPresence(PDEVICE_OBJECT DeviceObject, [MarshalAs(UnmanagedType.U1)] bool IsPresent);

	/// <summary>
	/// The <b>HidRegisterMinidriver</b> routine is called by HID minidrivers, during their initialization, to register with the HID class driver.
	/// </summary>
	/// <param name="MinidriverRegistration">
	/// Pointer to a caller-allocated buffer that contains an initialized <c>HID_MINIDRIVER_REGISTRATION</c> structure for the minidriver.
	/// </param>
	/// <returns>
	/// <para><b>HidRegisterMinidriver</b> returns one of the following NTSTATUS codes:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>STATUS_SUCCESS</b></description>
	/// <description>Indicates that the routine completed without error and the minidriver is now registered with the HID class driver.</description>
	/// </item>
	/// <item>
	/// <description><b>STATUS_INSUFFICIENT_RESOURCES</b></description>
	/// <description>Indicates that there was insufficient memory for the system to register the minidriver.</description>
	/// </item>
	/// <item>
	/// <description><b>STATUS_REVISION_MISMATCH</b></description>
	/// <description>
	/// Indicates that the HID revision number provided in <i>MinidriverRegistration-&gt;</i> Revision is not supported by this version of
	/// the HID class driver.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Before calling this routine, HID minidrivers must initialize all members of the HID_MINIDRIVER_REGISTRATION structure that is
	/// provided at <i>MinidriverRegistration</i>. For information about these members, see <c>HID_MINIDRIVER_REGISTRATION</c>.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/nf-hidport-hidregisterminidriver NTSTATUS
	// HidRegisterMinidriver( [in] PHID_MINIDRIVER_REGISTRATION MinidriverRegistration );
	[PInvokeData("hidport.h", MSDNShortId = "NF:hidport.HidRegisterMinidriver")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidRegisterMinidriver(in HID_MINIDRIVER_REGISTRATION MinidriverRegistration);

	/// <summary>The HID_DESCRIPTOR structure represents a HID descriptor for a HIDClass device.</summary>
	/// <remarks>
	/// <para>
	/// The HID class driver uses an <c>IOCTL_HID_GET_DEVICE_DESCRIPTOR</c> request to obtain a device's HID descriptor from a HID minidriver.
	/// </para>
	/// <para>
	/// For information about HID descriptors, see the Universal Serial Bus (USB) standard <i>Device Class Definition for Human Interface
	/// Devices (HID)</i> located at the <c>USB Implementers Forum website</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ns-hidport-_hid_descriptor typedef struct _HID_DESCRIPTOR {
	// UCHAR bLength; UCHAR bDescriptorType; USHORT bcdHID; UCHAR bCountry; UCHAR bNumDescriptors; struct { UCHAR bReportType; USHORT
	// wReportLength; } _HID_DESCRIPTOR_DESC_LIST; _HID_DESCRIPTOR_DESC_LIST DescriptorList[1]; } HID_DESCRIPTOR, *PHID_DESCRIPTOR;
	[PInvokeData("hidport.h", MSDNShortId = "NS:hidport._HID_DESCRIPTOR")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<HID_DESCRIPTOR>), nameof(bNumDescriptors))]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HID_DESCRIPTOR
	{
		/// <summary/>
		public byte bLength;

		/// <summary/>
		public byte bDescriptorType;

		/// <summary/>
		public ushort bcdHID;

		/// <summary/>
		public byte bCountry;

		/// <summary/>
		public byte bNumDescriptors;

		/// <summary/>
		public HID_DESCRIPTOR_DESC_LIST[] DescriptorList;

		/// <summary/>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct HID_DESCRIPTOR_DESC_LIST
		{
			/// <summary/>
			public byte bReportType;

			/// <summary/>
			public ushort wReportLength;
		}
	}

	/// <summary>The HID_DEVICE_ATTRIBUTES structure contains information about a HIDClass device.</summary>
	/// <remarks>
	/// The HID class driver uses this structure to obtain device attributes when it sends an <c>IOCTL_HID_GET_DEVICE_ATTRIBUTES</c> request
	/// to a HID minidriver.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ns-hidport-_hid_device_attributes typedef struct
	// _HID_DEVICE_ATTRIBUTES { ULONG Size; USHORT VendorID; USHORT ProductID; USHORT VersionNumber; USHORT Reserved[11]; }
	// HID_DEVICE_ATTRIBUTES, *PHID_DEVICE_ATTRIBUTES;
	[PInvokeData("hidport.h", MSDNShortId = "NS:hidport._HID_DEVICE_ATTRIBUTES")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HID_DEVICE_ATTRIBUTES
	{
		/// <summary>
		/// Specifies the size of the structure. This member should be treated as read-only when a HID minidriver uses this structure to
		/// complete an <c>IOCTL_HID_GET_DEVICE_ATTRIBUTES</c> request.
		/// </summary>
		public uint Size;

		/// <summary>Specifies a HID device's vendor ID.</summary>
		public ushort VendorID;

		/// <summary>Specifies a HID device's product ID.</summary>
		public ushort ProductID;

		/// <summary>Specifies the manufacturer's revision number for a HID device.</summary>
		public ushort VersionNumber;

		/// <summary>Reserved for internal system use.</summary>
		public unsafe fixed ushort Reserved[11];
	}

	/// <summary>
	/// The HID_DEVICE_EXTENSION structure is used by a HID minidriver as its layout for the device extension of a HIDClass device's
	/// functional device object.
	/// </summary>
	// https://learn.microsoft.com/en-nz/windows-hardware/drivers/ddi/hidport/ns-hidport-_hid_device_extension typedef struct
	// _HID_DEVICE_EXTENSION { PDEVICE_OBJECT PhysicalDeviceObject; PDEVICE_OBJECT NextDeviceObject; PVOID MiniDeviceExtension; }
	// HID_DEVICE_EXTENSION, *PHID_DEVICE_EXTENSION;
	[PInvokeData("hidport.h", MSDNShortId = "NS:hidport._HID_DEVICE_EXTENSION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HID_DEVICE_EXTENSION
	{
		/// <summary>Pointer to HID device's physical device object.</summary>
		public PDEVICE_OBJECT PhysicalDeviceObject;

		/// <summary>Pointer to the device object immediately below the functional device object in the HID device's device stack.</summary>
		public PDEVICE_OBJECT NextDeviceObject;

		/// <summary>Pointer to the minidriver-specific portion of the device extension.</summary>
		public IntPtr MiniDeviceExtension;
	}

	/// <summary>
	/// The HID_MINIDRIVER_REGISTRATION structure contains registration information that a HID minidriver passes to the <c>HID Client
	/// Drivers</c> when the minidriver registers with the class driver.
	/// </summary>
	/// <remarks>
	/// When a HID minidriver calls <c>HidRegisterMinidriver</c>, it uses this structure to pass information to the HID class driver. The
	/// minidriver must zero-initialize this structure before setting members. A minidriver sets the members <b>DriverObject</b> and
	/// <b>RegistryPath</b> to the driver object and registry path parameters that are passed to the minidriver as system-supplied parameters
	/// to its <c>DriverEntry</c> routine. <b>Revision</b> should be set to HID_REVISION.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidport/ns-hidport-_hid_minidriver_registration typedef struct
	// _HID_MINIDRIVER_REGISTRATION { ULONG Revision; PDRIVER_OBJECT DriverObject; PUNICODE_STRING RegistryPath; ULONG DeviceExtensionSize;
	// BOOLEAN DevicesArePolled; UCHAR Reserved[3]; } HID_MINIDRIVER_REGISTRATION, *PHID_MINIDRIVER_REGISTRATION;
	[PInvokeData("hidport.h", MSDNShortId = "NS:hidport._HID_MINIDRIVER_REGISTRATION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HID_MINIDRIVER_REGISTRATION
	{
		/// <summary>Specifies the HID version that this minidriver supports.</summary>
		public uint Revision;

		/// <summary>Pointer to the minidriver's <c>DRIVER_OBJECT</c>.</summary>
		public PDRIVER_OBJECT DriverObject;

		/// <summary>Pointer to the minidriver's registry path.</summary>
		public PWSTR RegistryPath;

		/// <summary>Specifies the length, in bytes, that the minidriver requests for a device extension.</summary>
		public uint DeviceExtensionSize;

		/// <summary>
		/// Specifies that the devices on the bus that this minidriver supports must be polled in order to obtain data from the device.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool DevicesArePolled;

		/// <summary>Reserved for internal system use.</summary>
		public unsafe fixed byte Reserved[3];
	}

	/// <summary>Used in conjunction with IOCTL_HID_SEND_IDLE_NOTIFICATION_REQUEST sent down by HIDCLASS during runtime idling.</summary>
	[PInvokeData("hidport.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HID_SUBMIT_IDLE_NOTIFICATION_CALLBACK_INFO
	{
		/// <summary>Pointer to the callback function that the minidriver must call when it is ready to be idled.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public HID_SEND_IDLE_CALLBACK IdleCallback;

		/// <summary>The context.</summary>
		public IntPtr IdleContext;
	}

	/// <summary>Pointer to a <c>DEVICE_OBJECT</c> structure.</summary>
	[AutoHandle]
	public partial struct PDEVICE_OBJECT { }

	/// <summary>Pointer to a <c>DRIVER_OBJECT</c> structure.</summary>
	[AutoHandle]
	public partial struct PDRIVER_OBJECT { }

	/// <summary>Pointer to a <c>FILE_OBJECT</c> structure.</summary>
	[AutoHandle]
	public partial struct PFILE_OBJECT { }
}