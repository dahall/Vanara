using System.ComponentModel.DataAnnotations;

namespace Vanara.PInvoke;

public static partial class Hid
{
	/// <summary>The HIDD_ATTRIBUTES structure contains vendor information about a HIDClass device.</summary>
	/// <remarks>
	/// <para>A caller of <c>HidD_GetAttributes</c>, uses this structure to obtain a device's vendor information.</para>
	/// <para>Before using a HIDD_ATTRIBUTES structure with <c>HIDClass support routines</c>, the caller must set the <b>Size</b> member.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/ns-hidsdi-_hidd_attributes typedef struct _HIDD_ATTRIBUTES {
	// ULONG Size; USHORT VendorID; USHORT ProductID; USHORT VersionNumber; } HIDD_ATTRIBUTES, *PHIDD_ATTRIBUTES;
	[PInvokeData("hidsdi.h", MSDNShortId = "NS:hidsdi._HIDD_ATTRIBUTES")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HIDD_ATTRIBUTES()
	{
		/// <summary>Specifies the size, in bytes, of a HIDD_ATTRIBUTES structure.</summary>
		public uint Size = (uint)Marshal.SizeOf<HIDD_ATTRIBUTES>();

		/// <summary>Specifies a HID device's vendor ID.</summary>
		public ushort VendorID;

		/// <summary>Specifies a HID device's product ID.</summary>
		public ushort ProductID;

		/// <summary>Specifies the manufacturer's revision number for a HIDClass device.</summary>
		public ushort VersionNumber;
	}

	/// <summary>The <b>HidD_FlushQueue</b> routine deletes all pending input reports in a <c>top-level collection's</c> input queue.</summary>
	/// <param name="HidDeviceObject">Specifies an open handle to the top-level collection whose input queue is flushed.</param>
	/// <returns>
	/// <b>HidD_FlushQueue</b> returns <b>TRUE</b> if it successfully flushes the queue. Otherwise, it returns <b>FALSE</b>. Use
	/// <c><b>GetLastError</b></c> to get extended error information.
	/// </returns>
	/// <remarks>
	/// <para>Only user-mode applications can call <b>HidD_FlushQueue</b>. Kernel-mode drivers can use an <c>IOCTL_HID_FLUSH_QUEUE</c> request.</para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_flushqueue BOOLEAN HidD_FlushQueue( [in] HANDLE
	// HidDeviceObject );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_FlushQueue")]
	[DllImport(Lib_Hid, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_FlushQueue([In] HFILE HidDeviceObject);

	/// <summary>
	/// The <b>HidD_FreePreparsedData</b> routine releases the resources that the HID class driver allocated to hold a <c>top-level
	/// collection's</c>  <c>preparsed data</c>.
	/// </summary>
	/// <param name="PreparsedData">Pointer to the buffer, returned by <c>HidD_GetPreparsedData</c>, that is freed.</param>
	/// <returns>
	/// <b>HidD_FreePreparsedData</b> returns <b>TRUE</b> if it succeeds. Otherwise, it returns <b>FALSE</b> if the buffer was not a
	/// preparsed data buffer. Use <c><b>GetLastError</b></c> to get extended error information.
	/// </returns>
	/// <remarks>
	/// <para>Only user-mode applications can call <b>HidD_FreePreparsedData</b>.</para>
	/// <para>To obtain a collection's preparsed data, use <c>HidD_GetPreparsedData</c>.</para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_freepreparseddata BOOLEAN HidD_FreePreparsedData(
	// [in] PHIDP_PREPARSED_DATA PreparsedData );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_FreePreparsedData")]
	[DllImport(Lib_Hid, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_FreePreparsedData([In] IntPtr PreparsedData);

	/// <summary>The <b>HidD_GetAttributes</b> routine returns the attributes of a specified <c>top-level collection</c>.</summary>
	/// <param name="HidDeviceObject">Specifies an open handle to a top-level collection.</param>
	/// <param name="Attributes">
	/// Pointer to a caller-allocated <c>HIDD_ATTRIBUTES</c> structure that returns the attributes of the collection specified by <i>HidDeviceObject</i>.
	/// </param>
	/// <returns><b>HidD_GetAttributes</b> returns <b>TRUE</b> if succeeds; otherwise, it returns <b>FALSE</b>.</returns>
	/// <remarks>
	/// <para>Only user-mode applications can call <b>HidD_GetAttributes</b>. Kernel-mode drivers can use <c>IOCTL_HID_GET_COLLECTION_INFORMATION</c>.</para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_getattributes BOOLEAN HidD_GetAttributes( [in]
	// HANDLE HidDeviceObject, [out] PHIDD_ATTRIBUTES Attributes );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_GetAttributes")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_GetAttributes([In] HFILE HidDeviceObject, ref HIDD_ATTRIBUTES Attributes);

	/// <summary>The <b>HidD_GetFeature</b> routine returns a feature report from a specified <c>top-level collection</c>.</summary>
	/// <param name="HidDeviceObject">An open handle to a top-level collection.</param>
	/// <param name="ReportBuffer">
	/// <para>
	/// Pointer to a caller-allocated HID report buffer that the caller uses to specify a report ID. <b>HidD_GetFeature</b> uses ReportBuffer
	/// to return the specified feature report.
	/// </para>
	/// <para>For more information about this parameter, see the <c>Remarks</c> section.</para>
	/// </param>
	/// <param name="ReportBufferLength">
	/// The size of the report buffer in bytes. The report buffer must be large enough to hold the feature report plus one additional byte
	/// that specifies a nonzero report ID. If report ID is not used, the ID value is zero.
	/// </param>
	/// <returns>
	/// If <b>HidD_GetFeature</b> succeeds, it returns <b>TRUE</b>; otherwise, it returns <b>FALSE</b>. Use <b><c>GetLastError</c></b> to get
	/// extended error information.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The correct ReportBufferLength is specified by the FeatureReportByteLength member of a top-level collection's <c>HIDP_CAPS</c>
	/// structure returned from <c>HidP_GetCaps</c> call.
	/// </para>
	/// <para>Before it calls the <b>HidD_GetFeature</b> routine, the caller must do the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// If the <c>top-level collection</c> includes report IDs, the caller must set the first byte of the ReportBuffer parameter to a nonzero
	/// report ID.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If the <c>top-level collection</c> does not include report IDs, the caller must set the first byte of the ReportBuffer parameter to zero.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// The feature report is returned in the ReportBuffer parameter. Depending on the report ID, the caller parses the report by calling one
	/// of the following functions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>HidP_GetButtonCaps</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetData</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetExtendedAttributes</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetScaledUsageValue</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetSpecificButtonCaps</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetSpecificValueCaps</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetUsages</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetUsagesEx</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetUsageValue</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetUsageValueArray</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetValueCaps</c></description>
	/// </item>
	/// </list>
	/// <para>
	/// For an example of how to parse a HID report, see the <c>HClient</c> sample application. This sample is located in the MSDN Code Gallery.
	/// </para>
	/// <para>Only user-mode applications can call <b>HidD_GetFeature</b>. Kernel-mode drivers can use an <c>IOCTL_HID_GET_FEATURE</c> request.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_getfeature BOOLEAN HidD_GetFeature( [in] HANDLE
	// HidDeviceObject, [out] PVOID ReportBuffer, [in] ULONG ReportBufferLength );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_GetFeature")]
	[DllImport(Lib_Hid, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_GetFeature([In] HFILE HidDeviceObject, [Out, SizeDef(nameof(ReportBufferLength))] IntPtr ReportBuffer,
		uint ReportBufferLength);

	/// <summary>The <b>HidD_GetHidGuid</b> routine returns the <c>device interface</c><c>GUID</c> for HIDClass devices.</summary>
	/// <param name="HidGuid">
	/// Pointer to a caller-allocated GUID buffer that the routine uses to return the <c>device interface GUID for HIDClass devices</c>.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>Only user-mode applications can call <b>HidD_GetHidGuid</b>.</para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_gethidguid void HidD_GetHidGuid( [out] LPGUID
	// HidGuid );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_GetHidGuid")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern void HidD_GetHidGuid(out Guid HidGuid);

	/// <summary>The <b>HidD_GetIndexedString</b> routine returns a specified embedded string from a <c>top-level collection</c>.</summary>
	/// <param name="HidDeviceObject">Specifies an open handle to a top-level collection.</param>
	/// <param name="StringIndex">Specifies the device-specific index of an embedded string.</param>
	/// <param name="Buffer">
	/// Pointer to a caller-allocated buffer that the routine uses to return the embedded string specified by StringIndex. The routine
	/// returns a NULL-terminated wide character string in a human-readable format.
	/// </param>
	/// <param name="BufferLength">
	/// Specifies the length, in bytes, of a caller-allocated buffer provided at Buffer. If the buffer is not large enough to return the
	/// entire NULL-terminated embedded string, the routine returns nothing in the buffer. The supplied buffer must be &lt;= 4093 bytes (2^12
	/// – 3).
	/// </param>
	/// <returns>
	/// <b>HidD_GetIndexedString</b> returns <b>TRUE</b> if it successfully returns the entire NULL-terminated embedded string. Otherwise,
	/// the routine returns <b>FALSE</b>. Use <c><b>GetLastError</b></c> to get extended error information.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only user-mode applications can call <b>HidD_GetIndexedString</b>. Kernel-mode drivers can use an <c>IOCTL_HID_GET_INDEXED_STRING</c> request.
	/// </para>
	/// <para>
	/// The maximum possible number of characters in an embedded string is device specific. For USB devices, the maximum string length is 126
	/// wide characters (not including the terminating NULL character).
	/// </para>
	/// <para>
	/// The <b>iProduct</b> member of a <c>USB_DEVICE_DESCRIPTOR</c> structure for a particular interface is set by the <c>USB common class
	/// generic parent driver</c> based on the following rules:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para>
	/// If the <b>iInterface</b> member of the <c>USB_INTERFACE_DESCRIPTOR</c> structure for the interface is nonzero, the <b>iProduct</b>
	/// member of the USB_DEVICE_DESCRIPTOR structure for the interface is set to the <b>iInterface</b> member of the
	/// USB_INTERFACE_DESCRIPTOR structure.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// If the interface is grouped by a <c>USB interface association descriptor</c> and the <b>iFunction</b> member of the interface
	/// association descriptor for the interface is nonzero, the <b>iProduct</b> member of the USB_DEVICE_DESCRIPTOR structure for the
	/// interface is set to the <b>iFunction</b> member of the interface association descriptor.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// If the supplied buffer is not &lt;= 4093 bytes (2^12 – 3) the call may fail (depending on the underlying protocol, HID/Bluetooth/SPI)
	/// with error code ERROR_GEN_FAILURE (0x0000001f)
	/// </para>
	/// <para>For more information see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_getindexedstring BOOLEAN HidD_GetIndexedString(
	// [in] HANDLE HidDeviceObject, [in] ULONG StringIndex, [out] PVOID Buffer, [in] ULONG BufferLength );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_GetIndexedString")]
	[DllImport(Lib_Hid, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_GetIndexedString([In] HFILE HidDeviceObject, uint StringIndex,
		[Out, SizeDef(nameof(BufferLength), SizingMethod.Bytes)] StringBuilder? Buffer, [Range(0, 4093)] uint BufferLength);

	/// <summary>
	/// <para>The <b>HidD_GetInputReport</b> routine returns an input report from a <c>top-level collection</c>.</para>
	/// <para>
	/// Only use this routine to obtain the current state of a collection. If an application attempts to use this routine to continuously
	/// obtain input reports, the reports can be lost. For more information, see <c>Obtaining HID Reports by user-mode applications</c>.
	/// </para>
	/// </summary>
	/// <param name="HidDeviceObject">An open handle to a top-level collection.</param>
	/// <param name="ReportBuffer">
	/// <para>
	/// Pointer to a caller-allocated input report buffer that the caller uses to specify a HID report ID and <b>HidD_GetInputReport</b> uses
	/// to return the specified input report.
	/// </para>
	/// <para>For more information about this parameter, see the Remarks section.</para>
	/// </param>
	/// <param name="ReportBufferLength">
	/// The size of the report buffer in bytes. The report buffer must be large enough to hold the input report plus one additional byte that
	/// specifies a report ID. If report ID is not used, the ID value is zero.
	/// </param>
	/// <returns>
	/// <b>HidD_GetInputReport</b> returns <b>TRUE</b> if it succeeds; otherwise, it returns <b>FALSE</b>. Use <c><b>GetLastError</b></c> to
	/// get extended error information.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The correct ReportBufferLength is specified by the InputReportByteLength member of a top-level collection's <c>HIDP_CAPS</c>
	/// structure returned from <c>HidP_GetCaps</c> call.
	/// </para>
	/// <para>Before it calls the <b>HidD_GetInputReport</b> routine, the caller must do the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// If the <c>top-level collection</c> includes report IDs, the caller must set the first byte of the ReportBuffer parameter to a nonzero
	/// report ID.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If the <c>top-level collection</c> does not include report IDs, the caller must set the first byte of the ReportBuffer parameter to zero.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// The input report is returned in the ReportBuffer parameter. Depending on the report ID, the caller parses the report by calling one
	/// of the following functions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>HidP_GetButtonCaps</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetData</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetExtendedAttributes</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetScaledUsageValue</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetSpecificButtonCaps</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetSpecificValueCaps</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetUsages</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetUsagesEx</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetUsageValue</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetUsageValueArray</c></description>
	/// </item>
	/// <item>
	/// <description><c>HidP_GetValueCaps</c></description>
	/// </item>
	/// </list>
	/// <para>For an example of how to parse a HID report, see the <c>HClient</c> sample application.</para>
	/// <para>
	/// Only user-mode applications can call <b>HidD_GetInputReport</b>. Kernel-mode drivers can use an <c>IOCTL_HID_GET_INPUT_REPORT</c> request.
	/// </para>
	/// <para>For more information, see <c>Interpreting HID Reports</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_getinputreport BOOLEAN HidD_GetInputReport( [in]
	// HANDLE HidDeviceObject, [out] PVOID ReportBuffer, [in] ULONG ReportBufferLength );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_GetInputReport")]
	[DllImport(Lib_Hid, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_GetInputReport([In] HFILE HidDeviceObject, [Out, SizeDef(nameof(ReportBufferLength))] IntPtr ReportBuffer,
		uint ReportBufferLength);

	/// <summary>
	/// The <b>HidD_GetManufacturerString</b> routine returns a <c>top-level collection's</c> embedded string that identifies the manufacturer.
	/// </summary>
	/// <param name="HidDeviceObject">Specifies an open handle to a top-level collection.</param>
	/// <param name="Buffer">
	/// Pointer to a caller-allocated buffer that the routine uses to return the collection's manufacturer string. The routine returns a
	/// NULL-terminated wide character string in a human-readable format.
	/// </param>
	/// <param name="BufferLength">
	/// Specifies the length, in bytes, of a caller-allocated buffer provided at Buffer. If the buffer is not large enough to return the
	/// entire NULL-terminated embedded string, the routine returns nothing in the buffer. The supplied buffer must be &lt;= 4093 bytes (2^12
	/// – 3).
	/// </param>
	/// <returns>
	/// HidD_HidD_GetManufacturerString returns <b>TRUE</b> if it returns the entire NULL-terminated embedded string. Otherwise, the routine
	/// returns <b>FALSE</b>. Use <c><b>GetLastError</b></c> to get extended error information.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only user-mode applications can call <b>HidD_GetManufacturerString</b>. Kernel-mode drivers can use an
	/// <c>IOCTL_HID_GET_MANUFACTURER_STRING</c> request.
	/// </para>
	/// <para>
	/// The maximum possible number of characters in an embedded string is device specific. For USB devices, the maximum string length is 126
	/// wide characters (not including the terminating NULL character).
	/// </para>
	/// <para>
	/// If the supplied buffer is not &lt;= 4093 bytes (2^12 – 3) the call may fail (depending on the underlying protocol, HID/Bluetooth/SPI)
	/// with error code ERROR_GEN_FAILURE (0x0000001f).
	/// </para>
	/// <para>For more information see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_getmanufacturerstring BOOLEAN
	// HidD_GetManufacturerString( [in] HANDLE HidDeviceObject, [out] PVOID Buffer, [in] ULONG BufferLength );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_GetManufacturerString")]
	[DllImport(Lib_Hid, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_GetManufacturerString([In] HFILE HidDeviceObject, [Out, SizeDef(nameof(BufferLength), SizingMethod.Bytes)] StringBuilder? Buffer,
		[Range(0, 4093)] uint BufferLength);

	/// <summary>
	/// The <b>HidD_GetNumInputBuffers</b> routine returns the current size, in number of reports, of the ring buffer that the HID class
	/// driver uses to queue input reports from a specified <c>top-level collection</c>.
	/// </summary>
	/// <param name="HidDeviceObject">Specifies an open handle to a top-level collection.</param>
	/// <param name="NumberBuffers">
	/// Pointer to a caller-allocated variable that the routine uses to return the maximum number of input reports the ring buffer can hold.
	/// </param>
	/// <returns>
	/// <b>HidD_GetNumInputBuffers</b> returns <b>TRUE</b> if it succeeds; otherwise, it returns <b>FALSE</b>. Use <c><b>GetLastError</b></c>
	/// to get extended error information.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only user-mode applications can call <b>HidD_GetNumInputBuffers</b>. Kernel-mode drivers can use the
	/// <c>IOCTL_GET_NUM_DEVICE_INPUT_BUFFERS</c> request.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_getnuminputbuffers BOOLEAN
	// HidD_GetNumInputBuffers( [in] HANDLE HidDeviceObject, [out] PULONG NumberBuffers );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_GetNumInputBuffers")]
	[DllImport(Lib_Hid, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_GetNumInputBuffers([In] HFILE HidDeviceObject, out uint NumberBuffers);

	/// <summary>
	/// <para>
	/// The <b>HidD_GetPhysicalDescriptor</b> routine returns the Physical Descriptor of a <c>top-level collection</c> that identifies the
	/// collection's physical device.
	/// </para>
	/// <para>
	/// Physical Descriptor is used to indicate what physical part of the human body is used to activate the controls on a device. For
	/// example, a Physical Descriptor might indicate that the right hand thumb is used to activate button 5.
	/// </para>
	/// <para>
	/// Note that Physical Descriptors are entirely optional. They add complexity and offer very little in return for most devices. However,
	/// some devices, particularly those with a large number of identical controls (for example, buttons) will find that Physical Descriptors
	/// help different applications assign functionality to these controls in a more consistent manner. See <c>HID specification</c> for more info.
	/// </para>
	/// </summary>
	/// <param name="HidDeviceObject">Specifies an open handle to a top-level collection.</param>
	/// <param name="Buffer">Pointer to a caller-allocated buffer that the routine uses to return the requested physical descriptor.</param>
	/// <param name="BufferLength">Specifies the length, in bytes, of the buffer at <i>Buffer</i>.</param>
	/// <returns>
	/// <b>HidD_GetPhysicalDescriptor</b> returns <b>TRUE</b> if it succeeds; otherwise, it returns <b>FALSE</b>. Use
	/// <c><b>GetLastError</b></c> to get extended error information.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only user-mode applications can call <b>HidD_GetPhysicalDescriptor</b>. Kernel-mode drivers can use an
	/// <c>IOCTL_GET_PHYSICAL_DESCRIPTOR</c> request.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_getphysicaldescriptor BOOLEAN
	// HidD_GetPhysicalDescriptor( [in] HANDLE HidDeviceObject, [out] PVOID Buffer, [in] ULONG BufferLength );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_GetPhysicalDescriptor")]
	[DllImport(Lib_Hid, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_GetPhysicalDescriptor([In] HFILE HidDeviceObject,
		[Out, SizeDef(nameof(BufferLength))] IntPtr Buffer, uint BufferLength);

	/// <summary>The <b>HidD_GetPreparsedData</b> routine returns a <c>top-level collection's</c>  <c>preparsed data</c>.</summary>
	/// <param name="HidDeviceObject">Specifies an open handle to a top-level collection.</param>
	/// <param name="PreparsedData">
	/// Pointer to the address of a routine-allocated buffer that contains a collection's preparsed data in a <c>_HIDP_PREPARSED_DATA</c> structure.
	/// </param>
	/// <returns>
	/// <b>HidD_GetPreparsedData</b> returns <b>TRUE</b> if it succeeds; otherwise, it returns <b>FALSE</b>. Use <c><b>GetLastError</b></c>
	/// to get extended error information.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only user-mode applications can call <b>HidD_GetPreparsedData</b>. Kernel-mode drivers can use an
	/// <c>IOCTL_HID_GET_COLLECTION_DESCRIPTOR</c> request.
	/// </para>
	/// <para>
	/// When an application no longer requires the preparsed data, it should call <c>HidD_FreePreparsedData</c> to free the preparsed data buffer.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_getpreparseddata BOOLEAN HidD_GetPreparsedData(
	// [in] HANDLE HidDeviceObject, [out] PHIDP_PREPARSED_DATA *PreparsedData );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_GetPreparsedData")]
	[DllImport(Lib_Hid, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_GetPreparsedData([In] HFILE HidDeviceObject, out SafePHIDP_PREPARSED_DATA PreparsedData);

	/// <summary>A pointer to opaque parser information for the collection automatically released by calling <see cref="HidD_FreePreparsedData"/>.</summary>
	/// <seealso cref="Vanara.PInvoke.SafeHANDLE"/>
	[AutoSafeHandle("HidD_FreePreparsedData(handle)", typeof(PHIDP_PREPARSED_DATA))]
	public partial class SafePHIDP_PREPARSED_DATA { }

	/// <summary>
	/// The <b>HidD_GetProductString</b> routine returns the embedded string of a <c>top-level collection</c> that identifies the
	/// manufacturer's product.
	/// </summary>
	/// <param name="HidDeviceObject">Specifies an open handle to a top-level collection.</param>
	/// <param name="Buffer">
	/// Pointer to a caller-allocated buffer that the routine uses to return the requested product string. The routine returns a
	/// NULL-terminated wide character string.
	/// </param>
	/// <param name="BufferLength">
	/// Specifies the length, in bytes, of a caller-allocated buffer provided at Buffer. If the buffer is not large enough to return the
	/// entire NULL-terminated embedded string, the routine returns nothing in the buffer. The supplied buffer must be &lt;= 4093 bytes (2^12
	/// – 3).
	/// </param>
	/// <returns>
	/// <b>HidD_GetProductString</b> returns <b>TRUE</b> if it successfully returns the entire NULL-terminated embedded string. Otherwise,
	/// the routine returns <b>FALSE</b>. Use <c><b>GetLastError</b></c> to get extended error information.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only user-mode applications can call <b>HidD_GetProductString</b>. Kernel-mode drivers can use an <c>IOCTL_HID_GET_PRODUCT_STRING</c> request.
	/// </para>
	/// <para>
	/// The maximum possible number of characters in an embedded string is device specific. For USB devices, the maximum string length is 126
	/// wide characters (not including the terminating NULL character).
	/// </para>
	/// <para>
	/// The <b>iProduct</b> member of a <c>USB_DEVICE_DESCRIPTOR</c> structure for a particular interface is set by the <c>USB common class
	/// generic parent driver</c> based on the following rules:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para>
	/// If the <b>iInterface</b> member of the <c>USB_INTERFACE_DESCRIPTOR</c> structure for the interface is nonzero, the <b>iProduct</b>
	/// member of the USB_DEVICE_DESCRIPTOR structure for the interface is set to the <b>iInterface</b> member of the
	/// USB_INTERFACE_DESCRIPTOR structure.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// If the interface is grouped by a <c>USB interface association descriptor</c> and the <b>iFunction</b> member of the interface
	/// association descriptor for the interface is nonzero, the <b>iProduct</b> member of the USB_DEVICE_DESCRIPTOR structure for the
	/// interface is set to the <b>iFunction</b> member of the interface association descriptor.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// If the supplied buffer is not &lt;= 4093 bytes (2^12 – 3) the call may fail (depending on the underlying protocol, HID/Bluetooth/SPI)
	/// with error code ERROR_GEN_FAILURE (0x0000001f)
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_getproductstring BOOLEAN HidD_GetProductString(
	// [in] HANDLE HidDeviceObject, [out] PVOID Buffer, [in] ULONG BufferLength );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_GetProductString")]
	[DllImport(Lib_Hid, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_GetProductString([In] HFILE HidDeviceObject, [Out, SizeDef(nameof(BufferLength), SizingMethod.Bytes)] StringBuilder? Buffer,
		[Range(0, 4093)] uint BufferLength);

	/// <summary>
	/// The <b>HidD_GetSerialNumberString</b> routine returns the embedded string of a <c>top-level collection</c> that identifies the serial
	/// number of the collection's physical device.
	/// </summary>
	/// <param name="HidDeviceObject">Specifies an open handle to a top-level collection.</param>
	/// <param name="Buffer">
	/// Pointer to a caller-allocated buffer that the routine uses to return the requested serial number string. The routine returns a
	/// NULL-terminated wide character string.
	/// </param>
	/// <param name="BufferLength">
	/// Specifies the length, in bytes, of a caller-allocated buffer provided at Buffer. If the buffer is not large enough to return the
	/// entire NULL-terminated embedded string, the routine returns nothing in the buffer. The supplied buffer must be &lt;= 4093 bytes (2^12
	/// – 3).
	/// </param>
	/// <returns>
	/// <b>HidD_GetSerialNumberString</b> returns <b>TRUE</b> if it successfully returns the entire NULL-terminated embedded string.
	/// Otherwise, the routine returns <b>FALSE</b>. Use <c><b>GetLastError</b></c> to get extended error information.
	/// </returns>
	/// <remarks>
	/// <para>Only user-mode applications can call <b>HidD_GetSerialNumberString</b>. Kernel-mode drivers can use <c>IOCTL_HID_GET_SERIALNUMBER_STRING</c>.</para>
	/// <para>
	/// The maximum possible number of characters in an embedded string is device specific. For USB devices, the maximum string length is 126
	/// wide characters (not including the terminating NULL character).
	/// </para>
	/// <para>
	/// If the supplied buffer is not &lt;= 4093 bytes (2^12 – 3), the call may fail (depending on the underlying protocol,
	/// HID/Bluetooth/SPI) with error code ERROR_GEN_FAILURE (0x0000001f)
	/// </para>
	/// <para>For more information see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_getserialnumberstring BOOLEAN
	// HidD_GetSerialNumberString( [in] HANDLE HidDeviceObject, [out] PVOID Buffer, [in] ULONG BufferLength );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_GetSerialNumberString")]
	[DllImport(Lib_Hid, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_GetSerialNumberString([In] HFILE HidDeviceObject,
		[Out, SizeDef(nameof(BufferLength), SizingMethod.Bytes)] StringBuilder? Buffer, [Range(0, 4093)] uint BufferLength);

	/// <summary>The <b>HidD_SetFeature</b> routine sends a feature report to a <c>top-level collection</c>.</summary>
	/// <param name="HidDeviceObject">An open handle to a top-level collection.</param>
	/// <param name="ReportBuffer">
	/// <para>Pointer to a caller-allocated feature report buffer that the caller uses to specify a HID report ID.</para>
	/// <para>For more information about this parameter, see the <c>Remarks</c> section.</para>
	/// </param>
	/// <param name="ReportBufferLength">
	/// The size of the report buffer in bytes. The report buffer must be large enough to hold the feature report plus one additional byte
	/// that specifies a nonzero report ID. If report ID is not used, the ID value is zero.
	/// </param>
	/// <returns>
	/// If <b>HidD_SetFeature</b> succeeds, it returns <b>TRUE</b>; otherwise, it returns <b>FALSE</b>. Use <b><c>GetLastError</c></b> to get
	/// extended error information.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The correct ReportBufferLength is specified by the FeatureReportByteLength member of a top-level collection's <c>HIDP_CAPS</c>
	/// structure returned from <c>HidP_GetCaps</c> call.
	/// </para>
	/// <para>Before it calls the <b>HidD_SetFeature</b> routine, the caller must do the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// If the <c>top-level collection</c> includes report IDs, the caller must set the first byte of the ReportBuffer parameter to a nonzero
	/// report ID.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If the <c>top-level collection</c> does not include report IDs, the caller must set the first byte of the ReportBuffer parameter to zero.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// The feature report is referenced by the ReportBuffer parameter. Depending on the report ID, the caller prepares the report by calling
	/// one of the following functions:
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// For an example of how to prepare and a HID report and send it to a <c>top-level collection</c>, see the <c>HClient</c> sample application.
	/// </para>
	/// <para>Only user-mode applications can call <b>HidD_SetFeature</b>. Kernel-mode drivers can use an <c>IOCTL_HID_SET_FEATURE</c> request.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_setfeature BOOLEAN HidD_SetFeature( [in] HANDLE
	// HidDeviceObject, [in] PVOID ReportBuffer, [in] ULONG ReportBufferLength );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_SetFeature")]
	[DllImport(Lib_Hid, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_SetFeature([In] HFILE HidDeviceObject, [In, SizeDef(nameof(ReportBufferLength))] IntPtr ReportBuffer,
		uint ReportBufferLength);

	/// <summary>
	/// The <b>HidD_SetNumInputBuffers</b> routine sets the maximum number of input reports that the HID class driver ring buffer can hold
	/// for a specified <c>top-level collection</c>.
	/// </summary>
	/// <param name="HidDeviceObject">Specifies an open handle to a top-level collection.</param>
	/// <param name="NumberBuffers">
	/// Specifies the maximum number of buffers that the HID class driver should maintain for the input reports generated by the
	/// <i>HidDeviceObject</i> collection.
	/// </param>
	/// <returns>
	/// <b>HidD_SetNumInputBuffers</b> returns <b>TRUE</b> if it succeeds; otherwise, it returns <b>FALSE</b>. Use <c><b>GetLastError</b></c>
	/// to get extended error information.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only user-mode applications can call <b>HidD_SetNumInputBuffers</b>. Kernel-mode drivers must use an
	/// <c>IOCTL_SET_NUM_DEVICE_INPUT_BUFFERS</c> request.
	/// </para>
	/// <para>
	/// If <b>HidD_SetNumInputBuffers</b> returns <b>FALSE</b>, and the Microsoft Win32 <b>GetLastError</b> function indicates that an
	/// invalid parameter was supplied, the value of <i>NumberBuffers</i> is invalid. The HID class driver requires a minimum of two input
	/// buffers. On Windows 2000, the maximum number of input buffers that the HID class driver supports is 200, and on Windows XP and later,
	/// the maximum number of input buffers that the HID class driver supports is 512. The default number of input buffers is 32.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_setnuminputbuffers BOOLEAN
	// HidD_SetNumInputBuffers( [in] HANDLE HidDeviceObject, [in] ULONG NumberBuffers );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_SetNumInputBuffers")]
	[DllImport(Lib_Hid, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_SetNumInputBuffers([In] HFILE HidDeviceObject, uint NumberBuffers);

	/// <summary>
	/// <para>The <b>HidD_SetOutputReport</b> routine sends an output report to a <c>top-level collection</c>.</para>
	/// <para>
	/// Only use this routine to set the current state of a collection. Some devices might not support this routine and will become
	/// unresponsive if this routine is used. For more information, see <c>Sending HID Reports by User-Mode Applications</c>.
	/// </para>
	/// </summary>
	/// <param name="HidDeviceObject">An open handle to a top-level collection.</param>
	/// <param name="ReportBuffer">
	/// <para>Pointer to a caller-allocated output report buffer that the caller uses to specify a report ID.</para>
	/// <para>For more information about this parameter, see the <c>Remarks</c> section.</para>
	/// </param>
	/// <param name="ReportBufferLength">
	/// The size of the report buffer in bytes. The report buffer must be large enough to hold the output report plus one additional byte
	/// that specifies a nonzero report ID. If report ID is not used, the ID value is zero.
	/// </param>
	/// <returns>
	/// If <b>HidD_SetOutputReport</b> succeeds, it returns <b>TRUE</b>; otherwise, it returns <b>FALSE</b>. Use <b><c>GetLastError</c></b>
	/// to get extended error information.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The correct ReportBufferLength is specified by the OutputReportByteLength member of a top-level collection's <c>HIDP_CAPS</c>
	/// structure returned from <c>HidP_GetCaps</c> call.
	/// </para>
	/// <para>Before it calls the <b>HidD_SetOutputReport</b> routine, the caller must do the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// If the <c>top-level collection</c> includes report IDs, the caller must set the first byte of the ReportBuffer parameter to a nonzero
	/// report ID.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If the <c>top-level collection</c> does not include report IDs, the caller must set the first byte of the ReportBuffer parameter to zero.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// The output report is referenced by the ReportBuffer parameter. Depending on the report ID, the caller prepares the report by calling
	/// one of the following functions:
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// For an example of how to prepare and a HID report and send it to a <c>top-level collection</c>, see the <c>HClient</c> sample application.
	/// </para>
	/// <para>
	/// Only user-mode applications can call <b>HidD_SetOutputReport</b>. Kernel-mode drivers can use an <c>IOCTL_HID_SET_OUTPUT_REPORT</c> request.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidsdi/nf-hidsdi-hidd_setoutputreport BOOLEAN HidD_SetOutputReport(
	// [in] HANDLE HidDeviceObject, [in] PVOID ReportBuffer, [in] ULONG ReportBufferLength );
	[PInvokeData("hidsdi.h", MSDNShortId = "NF:hidsdi.HidD_SetOutputReport")]
	[DllImport(Lib_Hid, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool HidD_SetOutputReport([In] HFILE HidDeviceObject, [In, SizeDef(nameof(ReportBufferLength))] IntPtr ReportBuffer,
		uint ReportBufferLength);
}