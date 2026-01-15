namespace Vanara.PInvoke;

public static partial class Hid
{
	private const string Lib_Vhf = "vhfum.dll";

	/// <summary>
	/// The HID source driver implements this event callback if it wants to support one of the four asynchronous operation to get and set HID reports.
	/// </summary>
	/// <param name="VhfClientContext">
	/// An opaque pointer to a HID source driver-defined buffer that the driver passed in the <c>VHF_CONFIG</c> structure supplied to
	/// <c>VhfCreate</c> to create the virtual HID device.
	/// </param>
	/// <param name="VhfOperationHandle">An opaque handle that uniquely identifies this asynchronous operation.</param>
	/// <param name="VhfOperationContext">
	/// Pointer to a buffer that can be used by the HID source driver for servicing the operation. Size of the buffer is specified by the HID
	/// source driver in the <c>VHF_CONFIG</c> structure supplied to <c>VhfCreate</c>.
	/// </param>
	/// <param name="HidTransferPacket">
	/// A pointer to a <c>HID_XFER_PACKET</c> structure. Contains information about a HID Report and is used by the HID source driver and the
	/// HID class/mini driver pair for I/O requests to get or set a report.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// There are four types of asynchronous operations that your HID source driver can support: <b>GetFeature</b>, <b>SetFeature</b>,
	/// <b>WriteReport</b>, <b>GetInputReport</b>.
	/// </para>
	/// <para>
	/// <b>Note</b>  Those operations are analogous to <c>IOCTL_HID_GET_FEATURE</c>, <c>IOCTL_HID_SET_FEATURE</c>,
	/// <c>IOCTL_HID_WRITE_REPORT</c>, <c>IOCTL_HID_GET_INPUT_REPORT</c> requests that a HID transport minidriver implements.
	/// </para>
	/// <para></para>
	/// <para>
	/// To support such an operation, the HID source driver must implement an <i>EvtVhfAsyncOperation</i> callback function and register it
	/// with the Virtual HID Framework (VHF) in the driver's call to <c>VhfCreate</c> function after calling <c>WdfDeviceCreate</c>. For
	/// example, for <b>GetFeature</b>, the driver must implement <i>EvtVhfAsyncOperation</i> and set the
	/// <b>EvtVhfAsyncOperationGetFeature</b> member of the <c>VHF_CONFIG</c> to a function pointer of the implemented function.
	/// </para>
	/// <para>
	/// When VHF gets a request that sets or queries a HID Report, VHF invokes the previously-registered <i>EvtVhfAsyncOperation</i> callback
	/// function and an asynchronous operation starts. Each operation is identified by a VHFOPERATIONHANDLE handle that is set by VHF. If the
	/// driver specified a non-zero value in the <b>OperationContextSize</b> member of the <c>VHF_CONFIG</c> during initialization, VHF
	/// allocates a buffer of that size and passes a pointer to that buffer in the <i>VhfOperationContext</i> parameter when it invokes <i>EvtVhfAsyncOperation</i>.
	/// </para>
	/// <para>
	/// <i>HidTransferPacket</i> is the transfer buffer for this operation that points to a VHF-allocated structure containing HID
	/// Report-specific details. For example, if the operation is <b>GetFeature</b>, upon completion the buffer is filled by the HID source
	/// driver with the requested HID Feature Report.
	/// </para>
	/// <para>When the operation is complete, HID source calls <c>VhfAsyncOperationComplete</c> to report the completion status.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/vhf/nc-vhf-evt_vhf_async_operation EVT_VHF_ASYNC_OPERATION
	// EvtVhfAsyncOperation; VOID EvtVhfAsyncOperation( [in] PVOID VhfClientContext, [in] VHFOPERATIONHANDLE VhfOperationHandle, [in,
	// optional] PVOID VhfOperationContext, [in] PHID_XFER_PACKET HidTransferPacket ) {...}
	[PInvokeData("vhf.h", MSDNShortId = "NC:vhf.EVT_VHF_ASYNC_OPERATION")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void EVT_VHF_ASYNC_OPERATION([In] IntPtr VhfClientContext, [In] VHFOPERATIONHANDLE VhfOperationHandle,
		[In, Optional] IntPtr VhfOperationContext, in HID_XFER_PACKET HidTransferPacket);

	/// <summary>
	/// The HID source driver implements this event callback to free resources that might the driver allocated to the virtual HID device.
	/// </summary>
	/// <param name="VhfClientContext">
	/// Pointer to the HID source driver-defined context structure that the driver passed in the previous call to <c>VhfCreate</c> to create
	/// the virtual HID device.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// To delete the virtual HID device, the HID source driver calls <c>VhfDelete</c>. That call causes Virtual HID Framework (VHF) to
	/// invoke the previously-registered <i>EvtVhfCleanup</i>, if the callback function is implemented by the HID source driver. When the
	/// driver calls VhfDelete with <i>Wait</i> set to TRUE, <i>EvtVhfCleanup</i> gets called before <b>VhfDelete</b> returns. If <i>Wait</i>
	/// is FALSE, it might get called any time after <b>VhfDelete</b> is called that is before or after <b>VhfDelete</b> returns.
	/// </para>
	/// <para>
	/// The call gives the HID source driver an opportunity to free resources allocated for the virtual HID device when that device is deleted.
	/// </para>
	/// <para>
	/// The HID source driver must not use the VHFHANDLE for the virtual HID device (created by <c>VhfCreate</c>) after this callback
	/// function returns. Before invoking this callback function, VHF makes sure that there are no asynchronous operations pending.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/vhf/nc-vhf-evt_vhf_cleanup EVT_VHF_CLEANUP EvtVhfCleanup; VOID
	// EvtVhfCleanup( [in] PVOID VhfClientContext ) {...}
	[PInvokeData("vhf.h", MSDNShortId = "NC:vhf.EVT_VHF_CLEANUP")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void EVT_VHF_CLEANUP([In] IntPtr VhfClientContext);

	/// <summary>
	/// The HID source driver implements this event call back function to use its buffering scheme for HID Input Reports, and wants to get
	/// notified when the next report can be submitted to VHF.
	/// </summary>
	/// <param name="VhfClientContext">
	/// Pointer to the HID source driver-defined context structure that the driver passed in the previous call to <c>VhfCreate</c> to create
	/// the virtual HID device.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// Virtual HID Framework (VHF) invokes this callback function to notify the HID source driver that it can submit a buffer to get the HID
	/// Input Report. After the callback is invoked, the HID source driver must call <c>VhfReadReportSubmit</c> only once. If a portion of
	/// the HID Input Report is still pending, the driver must wait for VHF to invoke <i>EvtVhfReadyForNextReadReport</i> before the driver
	/// can call <b>VhfReadReportSubmit</b> again.
	/// </para>
	/// <para>
	/// If the HID source driver does not implement this callback function, VHF uses a default buffering policy for HID Read (Input) Reports.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/vhf/nc-vhf-evt_vhf_ready_for_next_read_report
	// EVT_VHF_READY_FOR_NEXT_READ_REPORT EvtVhfReadyForNextReadReport; VOID EvtVhfReadyForNextReadReport( [in] PVOID VhfClientContext ) {...}
	[PInvokeData("vhf.h", MSDNShortId = "NC:vhf.EVT_VHF_READY_FOR_NEXT_READ_REPORT")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void EVT_VHF_READY_FOR_NEXT_READ_REPORT([In] IntPtr VhfClientContext);

	/// <summary>
	/// Use the <b>VHF_CONFIG_INIT</b> function to initialize the required members of the <c>VHF_CONFIG</c> structure allocated by the HID
	/// source driver.
	/// </summary>
	/// <param name="Config">A pointer to the <c>VHF_CONFIG</c> structure to initialize.</param>
	/// <param name="DeviceObject">
	/// <para>
	/// A pointer to the <c>DEVICE_OBJECT</c> structure for the HID source driver. Get that pointer by calling
	/// <c>WdfDeviceWdmGetDeviceObject</c> and passing the WDFDEVICE handle that the driver received in the <c>WdfDeviceCreate</c> call.
	/// </para>
	/// <para>A user-mode driver would instead provide a FileHandle. For more info, see <c><b>VHF_CONFIG</b></c>.</para>
	/// </param>
	/// <param name="ReportDescriptorLength">The length of the HID Report Descriptor contained in a buffer pointer by <i>ReportDescriptor</i>.</param>
	/// <param name="ReportDescriptor">A pointer to a HID source driver-allocated buffer that contains the HID Report Descriptor.</param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/vhf/nf-vhf-vhf_config_init FORCEINLINE VOID VHF_CONFIG_INIT( _Out_
	// PVHF_CONFIG Config, #ifdef _KERNEL_MODE _In_ PDEVICE_OBJECT DeviceObject, #else _In_ HANDLE FileHandle, #endif _In_ USHORT
	// ReportDescriptorLength, _In_reads_bytes_(ReportDescriptorLength) PUCHAR ReportDescriptor )
	[PInvokeData("vhf.h", MSDNShortId = "NF:vhf.VHF_CONFIG_INIT")]
	[DllImport(Lib_Vhf, SetLastError = false, ExactSpelling = true)]
	public static extern void VHF_CONFIG_INIT(out VHF_CONFIG Config, [In] PDEVICE_OBJECT DeviceObject, ushort ReportDescriptorLength,
		[In, SizeDef(nameof(ReportDescriptorLength))] IntPtr ReportDescriptor);

	/// <summary>
	/// Use the <b>VHF_CONFIG_INIT</b> function to initialize the required members of the <c>VHF_CONFIG</c> structure allocated by the HID
	/// source driver.
	/// </summary>
	/// <param name="Config">A pointer to the <c>VHF_CONFIG</c> structure to initialize.</param>
	/// <param name="DeviceObject">
	/// <para>
	/// A pointer to the <c>DEVICE_OBJECT</c> structure for the HID source driver. Get that pointer by calling
	/// <c>WdfDeviceWdmGetDeviceObject</c> and passing the WDFDEVICE handle that the driver received in the <c>WdfDeviceCreate</c> call.
	/// </para>
	/// <para>A user-mode driver would instead provide a FileHandle. For more info, see <c><b>VHF_CONFIG</b></c>.</para>
	/// </param>
	/// <param name="ReportDescriptorLength">The length of the HID Report Descriptor contained in a buffer pointer by <i>ReportDescriptor</i>.</param>
	/// <param name="ReportDescriptor">A pointer to a HID source driver-allocated buffer that contains the HID Report Descriptor.</param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/vhf/nf-vhf-vhf_config_init FORCEINLINE VOID VHF_CONFIG_INIT( _Out_
	// PVHF_CONFIG Config, #ifdef _KERNEL_MODE _In_ PDEVICE_OBJECT DeviceObject, #else _In_ HANDLE FileHandle, #endif _In_ USHORT
	// ReportDescriptorLength, _In_reads_bytes_(ReportDescriptorLength) PUCHAR ReportDescriptor )
	[PInvokeData("vhf.h", MSDNShortId = "NF:vhf.VHF_CONFIG_INIT")]
	[DllImport(Lib_Vhf, SetLastError = false, ExactSpelling = true)]
	public static extern void VHF_CONFIG_INIT(out VHF_CONFIG Config, [In] HFILE DeviceObject, ushort ReportDescriptorLength,
		[In, SizeDef(nameof(ReportDescriptorLength))] IntPtr ReportDescriptor);

	/// <summary>The HID source driver calls this method to set the results of an asynchronous operation.</summary>
	/// <param name="VhfOperationHandle">
	/// The operation handle set by Virtual HID Framework (VHF). This handle is passed to the HID source driver in the
	/// <i>VhfOperationHandle</i> parameter of <c>EvtVhfAsyncOperation</c>.
	/// </param>
	/// <param name="CompletionStatus">
	/// If the operation succeeds, the method returns STATUS_SUCCESS. Otherwise an appropriate <c>NTSTATUS</c> value.
	/// </param>
	/// <returns>
	/// If the <b>VhfAsyncOperationComplete</b> call succeeds, the method returns STATUS_SUCCESS. Otherwise an appropriate <c>NTSTATUS</c> value.
	/// </returns>
	/// <remarks>
	/// The HID source driver can call from the event callback or at a later time after returning from the <c>EvtVhfAsyncOperation</c> callback.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/vhf/nf-vhf-vhfasyncoperationcomplete NTSTATUS
	// VhfAsyncOperationComplete( [in] VHFOPERATIONHANDLE VhfOperationHandle, [in] NTSTATUS CompletionStatus );
	[PInvokeData("vhf.h", MSDNShortId = "NF:vhf.VhfAsyncOperationComplete")]
	[DllImport(Lib_Vhf, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus VhfAsyncOperationComplete([In] VHFOPERATIONHANDLE VhfOperationHandle, [In] NTStatus CompletionStatus);

	/// <summary>The HID source driver calls this method to create a virtual HID device.</summary>
	/// <param name="VhfConfig">A pointer to a <c>VHF_CONFIG</c> structure.</param>
	/// <param name="VhfHandle">A handle to the new virtual HID device.</param>
	/// <returns>If the <b>VhfCreate</b> call succeeds, the method returns STATUS_SUCCESS. Otherwise an appropriate <c>NTSTATUS</c> value.</returns>
	/// <remarks>
	/// <para>
	/// This method returns synchronously after validating the <c>VHF_CONFIG</c> structure and creating a virtual HID device. The virtual HID
	/// device is only reported to PnP. The initialization, installation, and starting of the device may not complete before this method returns.
	/// </para>
	/// <para>
	/// A Kernel-Mode Driver Framework (KMDF) driver can call <b>VhfCreate</b> at any point after successfully creating its own device object
	/// by calling <c>WdfDeviceCreate</c>. The driver can do so in its <c>EvtDriverDeviceAdd</c>, <c>EvtDevicePrepareHardware</c>,
	/// <c>EvtDeviceD0Entry</c>, <c>EvtDeviceSelfManagedIoInit</c>.
	/// </para>
	/// <para>VHF does not invoke any callback functions that are specified in <c>VHF_CONFIG</c> until the HID source driver calls <c>VhfStart</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/vhf/nf-vhf-vhfcreate NTSTATUS VhfCreate( [in] PVHF_CONFIG VhfConfig,
	// [out] VHFHANDLE *VhfHandle );
	[PInvokeData("vhf.h", MSDNShortId = "NF:vhf.VhfCreate")]
	[DllImport(Lib_Vhf, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus VhfCreate(in VHF_CONFIG VhfConfig, out SafeVHFHANDLE VhfHandle);

	/// <summary>The HID Source device driver calls this method to delete a VHF device.</summary>
	/// <param name="VhfHandle">A handle to a virtual HID device that your HID source driver received in the previous call to <c>VhfCreate</c>.</param>
	/// <param name="Wait">
	/// <para>
	/// TRUE to return synchronously after deleting a device. In this case, Virtual HID Framework (VHF) does not return until the device is
	/// reported as missing to PnP Manager and <c>EvtVhfCleanup</c> callback function returns.
	/// </para>
	/// <para>FALSE is reserved and should not be passed. See Remarks for more information.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The HID source driver must stop initiating new requests for the Virtual HID Framework (VHF) just before calling <b>VhfDelete</b>.</para>
	/// <para>
	/// To call <b>VhfDelete</b> synchronously, call it at PASSIVE_LEVEL with the <i>Wait</i> parameter set to TRUE. In this case, it returns
	/// synchronously after completing the deletion. If the HID source driver has registered an <c>EvtVhfCleanup</c> callback function with
	/// VHF, it invokes that callback before <b>VhfDelete</b> returns. The function might be invoked on the same thread.
	/// </para>
	/// <para>
	/// <b>VhfDelete</b> cannot be called asynchronously ( <i>Wait</i> parameter set to FALSE) or at any IRQL higher than PASSIVE_LEVEL.
	/// Doing so may result in undefined behavior.
	/// </para>
	/// <para>
	/// There are no restrictions on when a KMDF driver should call this function. It is recommended to call it from a function matching the
	/// <c>VhfCreate</c> call. For example, if <b>VhfCreate</b> is called from <c>EvtDriverDeviceAdd</c>, then call <b>VhfDelete</b>
	/// synchronously from <i>EvtDeviceCleanupCallback</i>. <b>VhfDelete</b> may be called on a VHFHANDLE without having previously called <b>VhfStart</b>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/vhf/nf-vhf-vhfdelete VOID VhfDelete( [in] VHFHANDLE VhfHandle, [in]
	// BOOLEAN Wait );
	[PInvokeData("vhf.h", MSDNShortId = "NF:vhf.VhfDelete")]
	[DllImport(Lib_Vhf, SetLastError = false, ExactSpelling = true)]
	public static extern void VhfDelete([In] VHFHANDLE VhfHandle, [MarshalAs(UnmanagedType.U1)] bool Wait = true);

	/// <summary>The HID source driver calls this method to submit a HID Read (Input) Report to Virtual HID Framework (VHF).</summary>
	/// <param name="VhfHandle">A handle to a virtual HID device that your HID source driver received in the previous call to <c>VhfCreate</c>.</param>
	/// <param name="HidTransferPacket">A pointer to a <c>HID_XFER_PACKET</c> structure that describes the HID report.</param>
	/// <returns>
	/// If the <b>VhfReadReportSubmit</b> call succeeds, the method returns STATUS_SUCCESS. Otherwise an appropriate <c>NTSTATUS</c> value.
	/// </returns>
	/// <remarks>
	/// <para>The HID source driver can choose to implement its buffering policy or let Virtual HID Framework (VHF) handle buffering.</para>
	/// <para>
	/// If the driver uses its own buffering policy, then it must implement and register an <c>EvtVhfReadyForNextReadReport</c> callback
	/// function in its call to <c>VhfCreate</c>. It must call <i>VhfReadReportSubmit</i> only once after VHF has invoked
	/// <i>EvtVhfReadyForNextReadReport</i>. After the callback has been invoked, the driver can reuse the transfer buffer pointed to by
	/// <i>HidTransferPacket</i>. The driver must wait for the next time that VHF invokes <i>EvtVhfReadyForNextReadReport</i> before calling
	/// this method again.
	/// </para>
	/// <para>
	/// If the HID source driver does not implement the <c>EvtVhfReadyForNextReadReport</c> callback, then there are no restrictions on
	/// calling this method. VHF uses the default buffering policy. The driver can reuse the transfer buffer after the call returns.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/vhf/nf-vhf-vhfreadreportsubmit NTSTATUS VhfReadReportSubmit( [in]
	// VHFHANDLE VhfHandle, [in] PHID_XFER_PACKET HidTransferPacket );
	[PInvokeData("vhf.h", MSDNShortId = "NF:vhf.VhfReadReportSubmit")]
	[DllImport(Lib_Vhf, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus VhfReadReportSubmit([In, AddAsMember] VHFHANDLE VhfHandle, in HID_XFER_PACKET HidTransferPacket);

	/// <summary>The HID source driver calls this method to start the virtual HID device.</summary>
	/// <param name="VhfHandle">A handle to a virtual HID device that your HID source driver received in the previous call to <c>VhfCreate</c>.</param>
	/// <returns>If the <b>VhfStart</b> call succeeds, the method returns STATUS_SUCCESS. Otherwise an appropriate <c>NTSTATUS</c> value.</returns>
	/// <remarks>
	/// <para>
	/// Virtual HID Framework (VHF) does not invoke any callback functions implemented by the HID source driver until the source driver calls
	/// <b>VhfStart</b>. A callback can get invoked before <b>VhfStart</b> returns. After this call succeeds, the driver can call <b>VhfDelete</b>.
	/// </para>
	/// <para>
	/// <b>VhfAsyncOperationComplete</b> and <b>VhfReadReportSubmit</b> may be called before <b>VhfStart</b> returns (e.g. from within an
	/// invoked callback).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/vhf/nf-vhf-vhfstart NTSTATUS VhfStart( [in] VHFHANDLE VhfHandle );
	[PInvokeData("vhf.h", MSDNShortId = "NF:vhf.VhfStart")]
	[DllImport(Lib_Vhf, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus VhfStart([In, AddAsMember] VHFHANDLE VhfHandle);

	/// <summary>
	/// Contains initial configuration information that is provided by the HID source driver when it calls <c>VhfCreate</c> to create a
	/// virtual HID device.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/vhf/ns-vhf-_vhf_config typedef struct _VHF_CONFIG { ULONG Size; PVOID
	// VhfClientContext; ULONG OperationContextSize; #ifdef _KERNEL_MODE PDEVICE_OBJECT DeviceObject; #else HANDLE FileHandle; #endif USHORT
	// VendorID; USHORT ProductID; USHORT VersionNumber; GUID ContainerID; USHORT InstanceIDLength; _Field_size_bytes_full_(InstanceIDLength)
	// PWSTR InstanceID; USHORT ReportDescriptorLength; _Field_size_full_(ReportDescriptorLength) PUCHAR ReportDescriptor;
	// PEVT_VHF_READY_FOR_NEXT_READ_REPORT EvtVhfReadyForNextReadReport; PEVT_VHF_ASYNC_OPERATION EvtVhfAsyncOperationGetFeature;
	// PEVT_VHF_ASYNC_OPERATION EvtVhfAsyncOperationSetFeature; PEVT_VHF_ASYNC_OPERATION EvtVhfAsyncOperationWriteReport;
	// PEVT_VHF_ASYNC_OPERATION EvtVhfAsyncOperationGetInputReport; PEVT_VHF_CLEANUP EvtVhfCleanup; USHORT HardwareIDsLength;
	// _Field_size_bytes_full_(HardwareIDsLength) PWSTR HardwareIDs; } VHF_CONFIG, *PVHF_CONFIG;
	[PInvokeData("vhf.h", MSDNShortId = "NS:vhf._VHF_CONFIG")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VHF_CONFIG
	{
		/// <summary>Required. Size of this structure initialized by <c>VHF_CONFIG_INIT</c>.</summary>
		public uint Size;

		/// <summary>
		/// Optional. An opaque pointer to HID source driver-allocated memory that the Virtual HID Framework (VHF) passes when it invokes
		/// those callback functions.
		/// </summary>
		public IntPtr VhfClientContext;

		/// <summary>
		/// Optional. Size of the buffer that VHF must allocate for an asynchronous operation started by <c>EvtVhfAsyncOperation</c>. If
		/// non-zero, VHF allocates a buffer of this size and passes a pointer to that buffer in the <i>VhfOperationContext</i> parameter
		/// each time it invokes <i>EvtVhfAsyncOperation</i> to start a new operation.
		/// </summary>
		public uint OperationContextSize;

		/// <summary>
		/// Required for kernel-mode drivers. A pointer to the <c>DEVICE_OBJECT</c> structure for the HID source driver. Get that pointer by
		/// calling <c>WdfDeviceWdmGetDeviceObject</c> and passing the WDFDEVICE handle that the driver received in the
		/// <c>WdfDeviceCreate</c> call.
		/// </summary>
		public PDEVICE_OBJECT DeviceObject;

		/// <summary>
		/// Required for user-mode drivers. A file handle obtained by calling <c><b>WdfIoTargetWdmGetTargetFileHandle</b></c>. To open a
		/// WDFIOTARGET, a user-mode (UMDF) VHF source driver should call <c><b>WdfIoTargetOpen</b></c> with <b>OpenParams.Type</b> set to <b>WdfIoTargetOpenLocalTargetByFile</b>.
		/// </summary>
		public HFILE FileHandle { readonly get => (IntPtr)DeviceObject; set => DeviceObject = (IntPtr)value; }

		/// <summary>Optional. Vendor ID of the virtual HID device to be created.</summary>
		public ushort VendorID;

		/// <summary>Optional. Product ID of the virtual HID device to be created.</summary>
		public ushort ProductID;

		/// <summary>Optional. Version number of the virtual HID device to be created.</summary>
		public ushort VersionNumber;

		/// <summary>Optional. Container ID of the virtual HID device to be created.</summary>
		public Guid ContainerID;

		/// <summary/>
		public ushort InstanceIDLength;

		/// <summary/>
		[MarshalAs(UnmanagedType.LPWStr)] public StringBuilder InstanceID;

		/// <summary>Required. The length of the HID Report Descriptor contained in a buffer pointed by <b>ReportDescriptor</b>.</summary>
		public ushort ReportDescriptorLength;

		/// <summary>Required. A pointer to a HID source driver-allocated buffer that contains the HID Report Descriptor.</summary>
		public IntPtr ReportDescriptor;

		/// <summary>
		/// Optional. A pointer to an <c>EvtVhfReadyForNextReadReport</c> callback. The HID source driver must implement and register this
		/// callback function if it wants to handle the buffering policy for submitting HID Input Reports. If this callback is specified, VHF
		/// does not buffer those reports. The HID source driver should submit one report by calling <c>VhfReadReportSubmit</c>, each time
		/// VHF invokes <i>EvtVhfReadyForNextReadReport</i>.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public EVT_VHF_READY_FOR_NEXT_READ_REPORT EvtVhfReadyForNextReadReport;

		/// <summary>
		/// Optional. A pointer to an <c>EvtVhfAsyncOperation</c> callback. The HID source driver must implement and register this callback
		/// function if it wants to a get a HID Feature Report associated with a <c>Top-Level Collection</c> from the HID class driver pair.
		/// The driver can get a Feature Report only if the Report Descriptor declares it.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public EVT_VHF_ASYNC_OPERATION EvtVhfAsyncOperationGetFeature;

		/// <summary>
		/// Optional. A pointer to an <c>EvtVhfAsyncOperation</c> callback. The HID source driver must implement and register this callback
		/// function if it wants to a send a HID Feature Report associated with a <c>Top-Level Collection</c> to the HID class driver pair.
		/// The driver can set a Feature Report only if the Report Descriptor declares it.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public EVT_VHF_ASYNC_OPERATION EvtVhfAsyncOperationSetFeature;

		/// <summary>
		/// Optional. A pointer to an <c>EvtVhfAsyncOperation</c> callback. The HID source driver must implement and register this callback
		/// function if it wants to a support HID Output Reports and send them to the HID class driver pair.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public EVT_VHF_ASYNC_OPERATION EvtVhfAsyncOperationWriteReport;

		/// <summary>
		/// Optional. A pointer to an <c>EvtVhfAsyncOperation</c> callback. The HID source driver must implement and register this callback
		/// function if it wants to support on-demand query for Input Reports.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public EVT_VHF_ASYNC_OPERATION EvtVhfAsyncOperationGetInputReport;

		/// <summary>
		/// Optional. A pointer to a <c>EvtVhfCleanup</c> callback. The HID source driver can implement and register this callback function
		/// if it wants to free the allocated resources for the virtual HID device.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public EVT_VHF_CLEANUP EvtVhfCleanup;

		/// <summary/>
		public ushort HardwareIDsLength;

		/// <summary/>
		public PWSTR HardwareIDs;

		/// <summary>
		/// Use the <b>VHF_CONFIG_INIT</b> function to initialize the required members of the <c>VHF_CONFIG</c> structure allocated by the
		/// HID source driver.
		/// </summary>
		/// <param name="DeviceObject">
		/// <para>
		/// A pointer to the <c>DEVICE_OBJECT</c> structure for the HID source driver. Get that pointer by calling
		/// <c>WdfDeviceWdmGetDeviceObject</c> and passing the WDFDEVICE handle that the driver received in the <c>WdfDeviceCreate</c> call.
		/// </para>
		/// </param>
		/// <param name="pReportDescriptor">A pointer to a HID source driver-allocated buffer that contains the HID Report Descriptor.</param>
		public static VHF_CONFIG Init(PDEVICE_OBJECT DeviceObject, SafeAllocatedMemoryHandle pReportDescriptor)
		{ VHF_CONFIG_INIT(out var c, DeviceObject, (ushort)pReportDescriptor.Size, pReportDescriptor); return c; }

		/// <summary>
		/// Use the <b>VHF_CONFIG_INIT</b> function to initialize the required members of the <c>VHF_CONFIG</c> structure allocated by the
		/// HID source driver.
		/// </summary>
		/// <param name="FileHandle">
		/// <para>A user-mode driver would instead provide a FileHandle. For more info, see <c><b>VHF_CONFIG</b></c>.</para>
		/// </param>
		/// <param name="pReportDescriptor">A pointer to a HID source driver-allocated buffer that contains the HID Report Descriptor.</param>
		public static VHF_CONFIG Init(HFILE FileHandle, SafeAllocatedMemoryHandle pReportDescriptor)
		{ VHF_CONFIG_INIT(out var c, FileHandle, (ushort)pReportDescriptor.Size, pReportDescriptor); return c; }
	}

	/// <summary>A handle to a virtual HID device.</summary>
	[AutoHandle]
	public partial struct VHFHANDLE { }

	/// <summary>An opaque handle that uniquely identifies an asynchronous operation.</summary>
	[AutoHandle]
	public partial struct VHFOPERATIONHANDLE { }

	/// <summary>A safe handle to a virtual HID device.</summary>
	[AutoSafeHandle("{ VhfDelete(handle); return true; }", typeof(VHFHANDLE))]
	public partial class SafeVHFHANDLE { }
}