namespace Vanara.PInvoke;

public static partial class WindowsDriverFramework
{
	/// <summary>
	/// A driver's <i>EvtDriverDeviceAdd</i> event callback function performs device initialization operations when the Plug and Play (PnP)
	/// manager reports the existence of a device.
	/// </summary>
	/// <param name="Driver">A handle to a framework driver object that represents the driver.</param>
	/// <param name="DeviceInit">A pointer to a framework-allocated <c>WDFDEVICE_INIT</c> structure.</param>
	/// <returns>
	/// The <i>EvtDriverDeviceAdd</i> callback function must return STATUS_SUCCESS if the operation succeeds. Otherwise, this callback
	/// function must return one of the error status values that are defined in <i>Ntstatus.h</i>. For more information, see the following
	/// Remarks section.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Each framework-based driver that supports PnP devices must provide the <i>EvtDriverDeviceAdd</i> callback function. The driver must
	/// place the callback function's address in its <c>WDF_DRIVER_CONFIG</c> structure before calling <c>WdfDriverCreate</c>.
	/// </para>
	/// <para>
	/// The framework calls your driver's <i>EvtDriverDeviceAdd</i> callback function after a bus driver detects a device that has a hardware
	/// identifier (ID) that matches a hardware ID that your driver supports. You specify the hardware IDs that your driver supports by
	/// providing an INF file, which the operating system uses to install drivers the first time that one of your devices is connected to the
	/// computer. For more information about how the system uses INF files and hardware IDs, see <c>How Setup Selects Drivers</c>.
	/// </para>
	/// <para>A driver's <i>EvtDriverDeviceAdd</i> callback function typically performs at least some of the following initialization operations:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para><c>Create a framework device object</c> to represent the device.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para><c>Create I/O queues</c> so the driver can receive I/O requests.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para><c>Create device interfaces</c> that applications use to communicate with the device.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para><c>Create driver-defined interfaces</c> that other drivers can use.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>Initialize <c>Windows Management Instrumentation (WMI)</c> support.</description>
	/// </item>
	/// <item>
	/// <description>
	/// <para><c>Create interrupt objects</c>, if the driver handles device interrupts.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para><c>Enable direct memory access (DMA) transactions</c>, if the driver handles DMA operations.</para>
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// Some drivers, especially filter drivers, might not create device objects for some devices. If an <i>EvtDriverDeviceAdd</i> callback
	/// function does not create a device object, it must still return STATUS_SUCCESS unless an error was encountered.
	/// </para>
	/// <para>
	/// If a driver's <i>EvtDriverDeviceAdd</i> callback function creates a device object but does not return STATUS_SUCCESS, the framework
	/// deletes the device object and its child devices.
	/// </para>
	/// <para>
	/// If a function driver's <i>EvtDriverDeviceAdd</i> callback function does not return STATUS_SUCCESS, the I/O manager does not build a
	/// device stack for the device.
	/// </para>
	/// <para>
	/// If a filter driver's <i>EvtDriverDeviceAdd</i> callback function does not return STATUS_SUCCESS, the framework converts the return
	/// value to STATUS_SUCCESS, and the I/O manager builds the device stack without the filter driver.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdfdriver/nc-wdfdriver-evt_wdf_driver_device_add
	// EVT_WDF_DRIVER_DEVICE_ADD EvtWdfDriverDeviceAdd; NTSTATUS EvtWdfDriverDeviceAdd( [in] WDFDRIVER Driver, [in, out] PWDFDEVICE_INIT
	// DeviceInit ) {...}
	[PInvokeData("wdfdriver.h", MSDNShortId = "NC:wdfdriver.EVT_WDF_DRIVER_DEVICE_ADD")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate NTStatus EVT_WDF_DRIVER_DEVICE_ADD([In] WDFDRIVER Driver, [In, Out] PWDFDEVICE_INIT DeviceInit);

	/// <summary>
	/// A driver's <i>EvtDriverUnload</i> event callback function performs operations that must take place before the driver is unloaded.
	/// </summary>
	/// <param name="Driver">A handle to a framework driver object.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>A driver registers an <i>EvtDriverUnload</i> callback function when it calls <c><b>WdfDriverCreate</b></c>.</para>
	/// <para>
	/// The <i>EvtDriverUnload</i> callback function must deallocate any non-device-specific system resources that the driver's
	/// <c>DriverEntry</c> routine allocated.
	/// </para>
	/// <para>
	/// The framework does not call a driver's <i>EvtDriverUnload</i> callback function if the driver's <c>DriverEntry</c> routine returns an
	/// error status value.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdfdriver/nc-wdfdriver-evt_wdf_driver_unload EVT_WDF_DRIVER_UNLOAD
	// EvtWdfDriverUnload; VOID EvtWdfDriverUnload( [in] WDFDRIVER Driver ) {...}
	[PInvokeData("wdfdriver.h", MSDNShortId = "NC:wdfdriver.EVT_WDF_DRIVER_UNLOAD")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void EVT_WDF_DRIVER_UNLOAD([In] WDFDRIVER Driver);
}