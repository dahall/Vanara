using static Vanara.PInvoke.WindowsDriverFramework;

namespace Vanara.PInvoke;

public static partial class Hid
{
	/// <summary>
	/// The <b>EvtHidspicxNotifyPowerdown</b> callback function is implemented by the client driver to receive notifications when the device
	/// is about to transition to a low-power state.
	/// </summary>
	/// <param name="Device">A handle to a framework device object the client driver obtained from a previous call to <c><b>WdfDeviceCreate</b></c>.</param>
	/// <param name="ArmForWake">
	/// Boolean value indicating whether the device will be armed for wake in the target state for the impending power transition.
	/// </param>
	/// <returns>
	/// <c><b>NTSTATUS</b></c> indicating whether preparation for the power transition was successful or not. This method is not expected to
	/// fail at runtime, and may result in a failure of the device by HidSpiCx.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The client driver is expected to implement and provide a callback which HidSpiCx will use to notify the client of an impending power
	/// down. The purpose of this callback is to allow the class extension to instruct the client to stop processing interrupts from the
	/// device, as the device is about to enter a low-power state. The client should not resume processing interrupts until a callback to the
	/// client's D0Entry WDF callback has occurred.
	/// </para>
	/// <para>
	/// The purpose of this function is to avoid the case when entering a sleep state where the class extension sends a <c>SET_POWER
	/// SLEEP</c> command to the device, and the device asserts interrupt to wake before the Dx IRP is completed by both the class extension
	/// and client driver. Without an additional callback instructing the client to stop hardware processing of interrupts, the hardware
	/// would issue a SPI read in response to a wake interrupt, which would violate the protocol requiring the host to first send a
	/// <c>SET_POWER ON</c> command before processing interrupts from the device.
	/// </para>
	/// <para>
	/// This function will be called by the class extension at passive IRQL, and the client should not return until interrupt processing has ceased.
	/// </para>
	/// <para>
	/// Whether or not the device will be armed for wake at the bus level is provided to the client as a convenience, allowing the client
	/// driver to avoid monitoring for <c>WAIT_WAKE</c> commands if it is not a bus driver.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidspicx/nc-hidspicx-evt_hidspicx_notify_powerdown
	// EVT_HIDSPICX_NOTIFY_POWERDOWN EvtHidspicxNotifyPowerdown; NTSTATUS EvtHidspicxNotifyPowerdown( WDFDEVICE Device, BOOLEAN ArmForWake ) {...}
	[PInvokeData("hidspicx.h", MSDNShortId = "NC:hidspicx.EVT_HIDSPICX_NOTIFY_POWERDOWN")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate NTStatus EVT_HIDSPICX_NOTIFY_POWERDOWN(WDFDEVICE Device, [MarshalAs(UnmanagedType.U1)] bool ArmForWake);

	/// <summary>
	/// The <b>EVT_HIDSPICX_RESETDEVICE</b> callback function is implemented by the client driver to respond to requests to reset the device.
	/// </summary>
	/// <param name="Device">A handle to a framework device object the client driver obtained from a previous call to <c><b>WdfDeviceCreate</b></c>.</param>
	/// <returns><c><b>NTSTATUS</b></c> value indicating whether the reset was successful or not.</returns>
	/// <remarks>
	/// <para>The class extension will call this function only while the hardware is in a working state, at passive IRQL.</para>
	/// <para>The client driver synchronously resets the device and returns a status code indicating whether the reset was successful.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidspicx/nc-hidspicx-evt_hidspicx_resetdevice EVT_HIDSPICX_RESETDEVICE
	// EvtHidspicxResetdevice; NTSTATUS EvtHidspicxResetdevice( WDFDEVICE Device ) {...}
	[PInvokeData("hidspicx.h", MSDNShortId = "NC:hidspicx.EVT_HIDSPICX_RESETDEVICE")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate NTStatus EVT_HIDSPICX_RESETDEVICE(WDFDEVICE Device);

	/// <summary>
	/// The <b>HIDSPICX_DEVICE_CONFIG_INIT</b> routine is used to initialize a <c><b>HIDSPICX_DEVICE_CONFIG</b></c> structure before passing
	/// it to the to the <b>HidSpiCxDeviceConfigure</b> function.
	/// </summary>
	/// <param name="DeviceConfig">A pointer to the client driver-allocated <c><b>HIDSPICX_DEVICE_CONFIG</b></c> structure.</param>
	/// <param name="EvtResetDevice">
	/// A pointer to the client driver's implementation of the <c><b>EVT_HIDSPICX_RESETDEVICE</b></c> callback function.
	/// </param>
	/// <param name="EvtNotifyPowerDown">
	/// A pointer to the client driver's implementation of the <c><b>EVT_HIDSPICX_NOTIFY_POWERDOWN</b></c> callback function.
	/// </param>
	/// <param name="InputReportQueue">
	/// A <b>WDFQUEUE</b> handle to a client-created, non-power-managed, queue for receipt of input report requests from the HID SPI class extension.
	/// </param>
	/// <param name="OutputReportQueue">
	/// A <b>WDFQUEUE</b> handle to a client-created, non-power-managed, queue for receipt of output report requests from the HID SPI class extension.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// Before passing a <c><b>HIDSPICX_DEVICE_CONFIG</b></c> structure pointer to the <c><b>HidSpiCxDeviceConfigure</b></c> function, it
	/// must first be initialized by a call to this macro.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidspicx/nf-hidspicx-hidspicx_device_config_init VOID
	// HIDSPICX_DEVICE_CONFIG_INIT( PHIDSPICX_DEVICE_CONFIG DeviceConfig, PFN_HIDSPICX_RESETDEVICE EvtResetDevice,
	// PFN_HIDSPICX_NOTIFY_POWERDOWN EvtNotifyPowerDown, WDFQUEUE InputReportQueue, WDFQUEUE OutputReportQueue );
	[PInvokeData("hidspicx.h", MSDNShortId = "NF:hidspicx.HIDSPICX_DEVICE_CONFIG_INIT")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern void HIDSPICX_DEVICE_CONFIG_INIT(ref HIDSPICX_DEVICE_CONFIG DeviceConfig, EVT_HIDSPICX_RESETDEVICE EvtResetDevice,
		EVT_HIDSPICX_NOTIFY_POWERDOWN EvtNotifyPowerDown, WDFQUEUE InputReportQueue, WDFQUEUE OutputReportQueue);

	/// <summary>
	/// After calling <c><b>WdfDeviceCreate</b></c>, and still in its <c><b>EVT_WDF_DRIVER_DEVICE_ADD</b></c> callback, the client driver
	/// calls this function with a pointer to a <c><b>HIDSPICX_DEVICE_CONFIG</b></c> structure, specifying interfaces the class extension
	/// will use to communicate with the device. The class extension initializes its internal state, returning whether or not this is successful.
	/// </summary>
	/// <param name="Device">A handle to a framework device object the client driver obtained from a previous call to <c><b>WdfDeviceCreate</b></c>.</param>
	/// <param name="DeviceConfiguration">
	/// Pointer to an initialized <c><b>HIDSPICX_DEVICE_CONFIG</b></c> structure, specifying the details of the callbacks and queues to be
	/// used for communication between the class extension and client driver.
	/// </param>
	/// <returns><c><b>NTSTATUS</b></c> indicating whether the class extension was able to successfully configure the device.</returns>
	/// <remarks>
	/// <para>The class extension initializes the internal state, returning whether or not this is successful.</para>
	/// <para>
	/// The client driver may create a default queue before or after making this callback, in order to handle IOCTLs not handled by the class extension.
	/// </para>
	/// <para>
	/// Client drivers should not attempt to acquire power policy ownership to configure power policy settings. <c><b>HidClass</b></c> and
	/// <c><b>HidSpiCx</b></c> are responsible for managing the power policy of the device.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidspicx/nf-hidspicx-hidspicxdeviceconfigure NTSTATUS
	// HidSpiCxDeviceConfigure( [in] WDFDEVICE Device, [in] PHIDSPICX_DEVICE_CONFIG DeviceConfiguration );
	[PInvokeData("hidspicx.h", MSDNShortId = "NF:hidspicx.HidSpiCxDeviceConfigure")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidSpiCxDeviceConfigure([In] WDFDEVICE Device, in HIDSPICX_DEVICE_CONFIG DeviceConfiguration);

	/// <summary>
	/// The client driver must call <b>HidSpiCxDeviceInitConfig</b> in its <c>EVT_WDF_DRIVER_DEVICE_ADD</c> callback, before calling <c><b>WdfDeviceCreate</b></c>.
	/// </summary>
	/// <param name="DeviceInit">
	/// A pointer to a <c>WDFDEVICE_INIT</c> object that the client received in its <c>EVT_WDF_DRIVER_DEVICE_ADD</c> routine.
	/// </param>
	/// <returns><c><b>NTSTATUS</b></c> indicating whether the class extension was able to successfully initialize the structure.</returns>
	/// <remarks>The class extension initializes private Plug-and-Play and power hooks for the device.</remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidspicx/nf-hidspicx-hidspicxdeviceinitconfig NTSTATUS
	// HidSpiCxDeviceInitConfig( PWDFDEVICE_INIT DeviceInit );
	[PInvokeData("hidspicx.h", MSDNShortId = "NF:hidspicx.HidSpiCxDeviceInitConfig")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidSpiCxDeviceInitConfig(PWDFDEVICE_INIT DeviceInit);

	/// <summary>Informs the class extension of a requirement to reset the device.</summary>
	/// <param name="Device">A handle to a framework device object the client driver obtained from a previous call to <c><b>WdfDeviceCreate</b></c>.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// The client driver may call the <b>HidSpiCxNotifyDeviceReset</b> function at any time when the device is in, or transitioning to D0.
	/// The class extension then calls the <c><b>EVT_HIDSPICX_RESETDEVICE</b></c> callback for the device. The device is then reinitialized
	/// by the class extension.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidspicx/nf-hidspicx-hidspicxnotifydevicereset VOID
	// HidSpiCxNotifyDeviceReset( WDFDEVICE Device );
	[PInvokeData("hidspicx.h", MSDNShortId = "NF:hidspicx.HidSpiCxNotifyDeviceReset")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern void HidSpiCxNotifyDeviceReset(WDFDEVICE Device);

	/// <summary>The <b>HIDSPICX_DEVICE_CONFIG</b> structure provides configuration information to the class extension.</summary>
	/// <remarks>Instances of this structure must be initialized by calling the <c><b>HIDSPICX_DEVICE_CONFIG_INIT</b></c> function.</remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidspicx/ns-hidspicx-hidspicx_device_config typedef struct
	// _HIDSPICX_DEVICE_CONFIG { ULONG Size; PFN_HIDSPICX_RESETDEVICE EvtResetDevice; PFN_HIDSPICX_NOTIFY_POWERDOWN EvtNotifyPowerDown;
	// WDFQUEUE InputReportQueue; WDFQUEUE OutputReportQueue; ULONG NumberOfInputReportRequestsToPend; ULONG Reserved; }
	// HIDSPICX_DEVICE_CONFIG, *PHIDSPICX_DEVICE_CONFIG;
	[PInvokeData("hidspicx.h", MSDNShortId = "NS:hidspicx._HIDSPICX_DEVICE_CONFIG")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HIDSPICX_DEVICE_CONFIG
	{
		/// <summary>This field is set by the <c><b>HIDSPICX_DEVICE_CONFIG_INIT</b></c> function.</summary>
		public uint Size;

		/// <summary>A pointer to the client driver's implementation of the <c><b>EVT_HIDSPICX_RESETDEVICE</b></c> callback function.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public EVT_HIDSPICX_RESETDEVICE EvtResetDevice;

		/// <summary>A pointer to the client driver's implementation of the <c><b>EVT_HIDSPICX_NOTIFY_POWERDOWN</b></c> callback function.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public EVT_HIDSPICX_NOTIFY_POWERDOWN EvtNotifyPowerDown;

		/// <summary>
		/// A <b>WDFQUEUE</b> handle to a client-created, non-power-managed, queue for receipt of input report requests from the HID SPI
		/// class extension.
		/// </summary>
		public WDFQUEUE InputReportQueue;

		/// <summary>
		/// A <b>WDFQUEUE</b> handle to a client-created, non-power-managed, queue for receipt of output report requests from the HID SPI
		/// class extension.
		/// </summary>
		public WDFQUEUE OutputReportQueue;

		/// <summary>
		/// <b>Optional:</b> Specifies how many requests are to be placed in the input report queue at a given time. If this is zero, the
		/// class extension will choose a default.
		/// </summary>
		public uint NumberOfInputReportRequestsToPend;

		/// <summary>Must be zero and should not be explicitly set by client drivers.</summary>
		public uint Reserved;

		/// <summary>Initializes a new instance of the <see cref="HIDSPICX_DEVICE_CONFIG"/> struct.</summary>
		/// <param name="EvtResetDevice">
		/// A pointer to the client driver's implementation of the <c><b>EVT_HIDSPICX_RESETDEVICE</b></c> callback function.
		/// </param>
		/// <param name="EvtNotifyPowerDown">
		/// A pointer to the client driver's implementation of the <c><b>EVT_HIDSPICX_NOTIFY_POWERDOWN</b></c> callback function.
		/// </param>
		/// <param name="InputReportQueue">
		/// A <b>WDFQUEUE</b> handle to a client-created, non-power-managed, queue for receipt of input report requests from the HID SPI
		/// class extension.
		/// </param>
		/// <param name="OutputReportQueue">
		/// A <b>WDFQUEUE</b> handle to a client-created, non-power-managed, queue for receipt of output report requests from the HID SPI
		/// class extension.
		/// </param>
		public HIDSPICX_DEVICE_CONFIG(EVT_HIDSPICX_RESETDEVICE EvtResetDevice, EVT_HIDSPICX_NOTIFY_POWERDOWN EvtNotifyPowerDown,
			WDFQUEUE InputReportQueue, WDFQUEUE OutputReportQueue) =>
			HIDSPICX_DEVICE_CONFIG_INIT(ref this, EvtResetDevice, EvtNotifyPowerDown, InputReportQueue, OutputReportQueue);
	}

	/// <summary>The <b>HIDSPICX_DRIVER_GLOBALS</b> structure is used internally by the framework. Do not use.</summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidspicx/ns-hidspicx-hidspicx_driver_globals typedef struct
	// _HIDSPICX_DRIVER_GLOBALS { ULONG Reserved; } HIDSPICX_DRIVER_GLOBALS, *PHIDSPICX_DRIVER_GLOBALS;
	[PInvokeData("hidspicx.h", MSDNShortId = "NS:hidspicx._HIDSPICX_DRIVER_GLOBALS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HIDSPICX_DRIVER_GLOBALS
	{
		/// <summary>Reserved.</summary>
		public uint Reserved;
	}

	/// <summary>The <b>HIDSPICX_REPORT</b> structure is used to represent input and output reports.</summary>
	/// <remarks>
	/// This structure is used rather than the full report structure including the header as the client is expected to marshall the data
	/// structures to be sent on the wire.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidspicx/ns-hidspicx-hidspicx_report typedef struct _HIDSPICX_REPORT {
	// UCHAR ReportType; USHORT ReportContentLength; UCHAR ReportId; UCHAR ReportContent[0]; } HIDSPICX_REPORT;
	[PInvokeData("hidspicx.h", MSDNShortId = "NS:hidspicx._HIDSPICX_REPORT")]
	//[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<HIDSPICX_REPORT>), nameof(ReportContentLength))]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 2)]
	public struct HIDSPICX_REPORT
	{
		/// <summary>The content type of the report.</summary>
		public byte ReportType;

		/// <summary>The length of the ReportContent field.</summary>
		public ushort ReportContentLength;

		/// <summary>A unique report identifier.</summary>
		public byte ReportId;

		// *** Removed as zero-length arrays are not CLS-compliant ***
		///// <summary>The raw HID report or command parameters.</summary>
		//[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		//public byte[] ReportContent;
	}
}