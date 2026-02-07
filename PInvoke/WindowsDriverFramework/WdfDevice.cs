namespace Vanara.PInvoke;

public static partial class WindowsDriverFramework
{
	/// <summary>
	/// <para>[Applies to KMDF and UMDF]</para>
	/// <para>The <b>WdfDeviceCreate</b> method creates a framework device object.</para>
	/// </summary>
	/// <param name="DeviceInit">The address of a pointer to a <c>WDFDEVICE_INIT</c> structure. If <b>WdfDeviceCreate</b> encounters no errors, it sets the pointer to <b>NULL</b>.</param>
	/// <param name="DeviceAttributes">A pointer to a caller-allocated <c>WDF_OBJECT_ATTRIBUTES</c> structure that contains attributes for the new object. (The structure's <b>ParentObject</b> member must be <b>NULL</b>.) This parameter is optional and can be WDF_NO_OBJECT_ATTRIBUTES.</param>
	/// <param name="Device">A pointer to a location that receives a handle to the new framework device object.</param>
	/// <returns>
	/// <para>If the <b>WdfDeviceCreate</b> method encounters no errors, it returns STATUS_SUCCESS. Additional return values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>STATUS_INVALID_PARAMETER</b></description>
	/// <description>An invalid <c>Device</c> or <c>DeviceInit</c> handle is supplied.</description>
	/// </item>
	/// <item>
	/// <description><b>STATUS_INVALID_DEVICE_STATE</b></description>
	/// <description>The driver has already created a device object for the device.</description>
	/// </item>
	/// <item>
	/// <description><b>STATUS_INVALID_SECURITY_DESCR</b></description>
	/// <description>The driver called <b>WdfDeviceInitAssignSDDLString</b> or <b>WdfDeviceInitSetDeviceClass</b> but did not provide a name for the device object.</description>
	/// </item>
	/// <item>
	/// <description><b>STATUS_INSUFFICIENT_RESOURCES</b></description>
	/// <description>A device object could not be allocated.</description>
	/// </item>
	/// <item>
	/// <description><b>STATUS_OBJECT_NAME_COLLISION</b></description>
	/// <description>The device name that was specified by a call to <b>WdfDeviceInitAssignName</b> already exists. The driver can call <b>WdfDeviceInitAssignName</b> again to assign a new name.</description>
	/// </item>
	/// </list>
	/// <para>For a list of other return values that <b>WdfDeviceCreate</b> can return, see <c>Framework Object Creation Errors</c>.</para>
	/// <para>The method might return other <c>NTSTATUS values</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>Before calling <b>WdfDeviceCreate</b>, the driver must call framework-supplied functions that initialize the WDFDEVICE_INIT structure. For more information about initializing this structure, see <c>WDFDEVICE_INIT</c>. If the driver encounters errors while calling the initialization functions, it must not call <b>WdfDeviceCreate</b>. In this case, the driver might have to call <c>WdfDeviceInitFree</c>. For information about when to call <b>WdfDeviceInitFree</b>, see <c>WdfDeviceInitFree</c>.</para>
	/// <para>A call to <b>WdfDeviceCreate</b> creates a framework device object that represents either a functional device object (FDO) or a physical device object (PDO). The type of device object that the function creates depends on how the driver obtained the WDFDEVICE_INIT structure:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>If the driver received the WDFDEVICE_INIT structure from an <c>EvtDriverDeviceAdd</c> callback, <b>WdfDeviceCreate</b> creates an FDO.</description>
	/// </item>
	/// <item>
	/// <description>If the driver received the WDFDEVICE_INIT structure from an <c>EvtChildListCreateDevice</c> callback, or from a call to <c>WdfPdoInitAllocate</c>, <b>WdfDeviceCreate</b> creates a PDO.</description>
	/// </item>
	/// </list>
	/// <para>After the driver calls <b>WdfDeviceCreate</b>, it can no longer access the WDFDEVICE_INIT structure.</para>
	/// <para>Miniport drivers that use the framework must call <c>WdfDeviceMiniportCreate</c> instead of <b>WdfDeviceCreate</b>.</para>
	/// <para>The parent of each framework device object is the driver's framework driver object. The driver cannot change this parent, and the <b>ParentObject</b> member of the <c>WDF_OBJECT_ATTRIBUTES</c> structure must be <b>NULL</b>. The framework deletes each framework device object (except for some <c>control device objects</c>) when the Plug and Play (PnP) manager determines that the device has been removed.</para>
	/// <para>If your driver provides <c>EvtCleanupCallback</c> or <c>EvtDestroyCallback</c> callback functions for the framework device object, note that the framework calls these callback functions at IRQL = PASSIVE_LEVEL.</para>
	/// <para>For more information about creating device objects, see <c>Creating a Framework Device Object</c>.</para>
	/// <para>Examples</para>
	/// <para>The following code example shows how an <c>EvtDriverDeviceAdd</c> callback function might initialize and create a device object.</para>
	/// <para><c>NTSTATUS MyEvtDeviceAdd( IN WDFDRIVER Driver, IN PWDFDEVICE_INIT DeviceInit ) { WDF_PNPPOWER_EVENT_CALLBACKS pnpPowerCallbacks; WDF_OBJECT_ATTRIBUTES attributes; NTSTATUS status; WDFDEVICE device; // // Initialize the WDF_PNPPOWER_EVENT_CALLBACKS structure. // WDF_PNPPOWER_EVENT_CALLBACKS_INIT(&amp;pnpPowerCallbacks); pnpPowerCallbacks.EvtDevicePrepareHardware = MyEvtDevicePrepareHardware; pnpPowerCallbacks.EvtDeviceD0Entry = MyEvtDeviceD0Entry; pnpPowerCallbacks.EvtDeviceD0Exit = MyEvtDeviceD0Exit; WdfDeviceInitSetPnpPowerEventCallbacks( DeviceInit, &amp;pnpPowerCallbacks ); // // This driver uses buffered I/O. // WdfDeviceInitSetIoType( DeviceInit, WdfDeviceIoBuffered ); // // Specify the device object's context space by // using a driver-defined DEVICE_CONTEXT structure. // WDF_OBJECT_ATTRIBUTES_INIT_CONTEXT_TYPE( &amp;attributes, DEVICE_CONTEXT ); // // Create the device object. // status = WdfDeviceCreate( &amp;DeviceInit, &amp;attributes, &amp;device ); if (!NT_SUCCESS(status)) { return status; } return STATUS_SUCCESS; } </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdfdevice/nf-wdfdevice-wdfdevicecreate
	// NTSTATUS WdfDeviceCreate( [in, out] PWDFDEVICE_INIT *DeviceInit, [in, optional] PWDF_OBJECT_ATTRIBUTES DeviceAttributes, [out] WDFDEVICE *Device );
	[PInvokeData("wdfdevice.h", MSDNShortId = "NF:wdfdevice.WdfDeviceCreate")]
	[DllImport(Lib_Wdf, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus WdfDeviceCreate(ref PWDFDEVICE_INIT DeviceInit, in WDF_OBJECT_ATTRIBUTES DeviceAttributes, out WDFDEVICE Device);

	/// <summary>
	/// <para>[Applies to KMDF and UMDF]</para>
	/// <para>The <b>WdfDeviceCreate</b> method creates a framework device object.</para>
	/// </summary>
	/// <param name="DeviceInit">The address of a pointer to a <c>WDFDEVICE_INIT</c> structure. If <b>WdfDeviceCreate</b> encounters no errors, it sets the pointer to <b>NULL</b>.</param>
	/// <param name="DeviceAttributes">A pointer to a caller-allocated <c>WDF_OBJECT_ATTRIBUTES</c> structure that contains attributes for the new object. (The structure's <b>ParentObject</b> member must be <b>NULL</b>.) This parameter is optional and can be WDF_NO_OBJECT_ATTRIBUTES.</param>
	/// <param name="Device">A pointer to a location that receives a handle to the new framework device object.</param>
	/// <returns>
	/// <para>If the <b>WdfDeviceCreate</b> method encounters no errors, it returns STATUS_SUCCESS. Additional return values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>STATUS_INVALID_PARAMETER</b></description>
	/// <description>An invalid <c>Device</c> or <c>DeviceInit</c> handle is supplied.</description>
	/// </item>
	/// <item>
	/// <description><b>STATUS_INVALID_DEVICE_STATE</b></description>
	/// <description>The driver has already created a device object for the device.</description>
	/// </item>
	/// <item>
	/// <description><b>STATUS_INVALID_SECURITY_DESCR</b></description>
	/// <description>The driver called <b>WdfDeviceInitAssignSDDLString</b> or <b>WdfDeviceInitSetDeviceClass</b> but did not provide a name for the device object.</description>
	/// </item>
	/// <item>
	/// <description><b>STATUS_INSUFFICIENT_RESOURCES</b></description>
	/// <description>A device object could not be allocated.</description>
	/// </item>
	/// <item>
	/// <description><b>STATUS_OBJECT_NAME_COLLISION</b></description>
	/// <description>The device name that was specified by a call to <b>WdfDeviceInitAssignName</b> already exists. The driver can call <b>WdfDeviceInitAssignName</b> again to assign a new name.</description>
	/// </item>
	/// </list>
	/// <para>For a list of other return values that <b>WdfDeviceCreate</b> can return, see <c>Framework Object Creation Errors</c>.</para>
	/// <para>The method might return other <c>NTSTATUS values</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>Before calling <b>WdfDeviceCreate</b>, the driver must call framework-supplied functions that initialize the WDFDEVICE_INIT structure. For more information about initializing this structure, see <c>WDFDEVICE_INIT</c>. If the driver encounters errors while calling the initialization functions, it must not call <b>WdfDeviceCreate</b>. In this case, the driver might have to call <c>WdfDeviceInitFree</c>. For information about when to call <b>WdfDeviceInitFree</b>, see <c>WdfDeviceInitFree</c>.</para>
	/// <para>A call to <b>WdfDeviceCreate</b> creates a framework device object that represents either a functional device object (FDO) or a physical device object (PDO). The type of device object that the function creates depends on how the driver obtained the WDFDEVICE_INIT structure:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>If the driver received the WDFDEVICE_INIT structure from an <c>EvtDriverDeviceAdd</c> callback, <b>WdfDeviceCreate</b> creates an FDO.</description>
	/// </item>
	/// <item>
	/// <description>If the driver received the WDFDEVICE_INIT structure from an <c>EvtChildListCreateDevice</c> callback, or from a call to <c>WdfPdoInitAllocate</c>, <b>WdfDeviceCreate</b> creates a PDO.</description>
	/// </item>
	/// </list>
	/// <para>After the driver calls <b>WdfDeviceCreate</b>, it can no longer access the WDFDEVICE_INIT structure.</para>
	/// <para>Miniport drivers that use the framework must call <c>WdfDeviceMiniportCreate</c> instead of <b>WdfDeviceCreate</b>.</para>
	/// <para>The parent of each framework device object is the driver's framework driver object. The driver cannot change this parent, and the <b>ParentObject</b> member of the <c>WDF_OBJECT_ATTRIBUTES</c> structure must be <b>NULL</b>. The framework deletes each framework device object (except for some <c>control device objects</c>) when the Plug and Play (PnP) manager determines that the device has been removed.</para>
	/// <para>If your driver provides <c>EvtCleanupCallback</c> or <c>EvtDestroyCallback</c> callback functions for the framework device object, note that the framework calls these callback functions at IRQL = PASSIVE_LEVEL.</para>
	/// <para>For more information about creating device objects, see <c>Creating a Framework Device Object</c>.</para>
	/// <para>Examples</para>
	/// <para>The following code example shows how an <c>EvtDriverDeviceAdd</c> callback function might initialize and create a device object.</para>
	/// <para><c>NTSTATUS MyEvtDeviceAdd( IN WDFDRIVER Driver, IN PWDFDEVICE_INIT DeviceInit ) { WDF_PNPPOWER_EVENT_CALLBACKS pnpPowerCallbacks; WDF_OBJECT_ATTRIBUTES attributes; NTSTATUS status; WDFDEVICE device; // // Initialize the WDF_PNPPOWER_EVENT_CALLBACKS structure. // WDF_PNPPOWER_EVENT_CALLBACKS_INIT(&amp;pnpPowerCallbacks); pnpPowerCallbacks.EvtDevicePrepareHardware = MyEvtDevicePrepareHardware; pnpPowerCallbacks.EvtDeviceD0Entry = MyEvtDeviceD0Entry; pnpPowerCallbacks.EvtDeviceD0Exit = MyEvtDeviceD0Exit; WdfDeviceInitSetPnpPowerEventCallbacks( DeviceInit, &amp;pnpPowerCallbacks ); // // This driver uses buffered I/O. // WdfDeviceInitSetIoType( DeviceInit, WdfDeviceIoBuffered ); // // Specify the device object's context space by // using a driver-defined DEVICE_CONTEXT structure. // WDF_OBJECT_ATTRIBUTES_INIT_CONTEXT_TYPE( &amp;attributes, DEVICE_CONTEXT ); // // Create the device object. // status = WdfDeviceCreate( &amp;DeviceInit, &amp;attributes, &amp;device ); if (!NT_SUCCESS(status)) { return status; } return STATUS_SUCCESS; } </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdfdevice/nf-wdfdevice-wdfdevicecreate
	// NTSTATUS WdfDeviceCreate( [in, out] PWDFDEVICE_INIT *DeviceInit, [in, optional] PWDF_OBJECT_ATTRIBUTES DeviceAttributes, [out] WDFDEVICE *Device );
	[PInvokeData("wdfdevice.h", MSDNShortId = "NF:wdfdevice.WdfDeviceCreate")]
	[DllImport(Lib_Wdf, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus WdfDeviceCreate(ref PWDFDEVICE_INIT DeviceInit, [In, Optional] IntPtr DeviceAttributes, out WDFDEVICE Device);
}