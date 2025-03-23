namespace Vanara.PInvoke;

/// <summary>Items from the DXCore</summary>
public static partial class DXCore
{
	private const string Lib_dxcore = "dxcore.dll";

	/// <summary>A callback function (implemented by your application), which is called by a DXCore object for notification events.</summary>
	/// <param name="notificationType">
	/// <para>Type: <c>DXCoreNotificationType</c></para>
	/// <para>
	/// The type of notification representing this invocation. See the table in DXCoreNotificationType for info about what types are valid
	/// with which kinds of objects.
	/// </para>
	/// </param>
	/// <param name="object">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>The IDXCoreAdapter or IDXCoreAdapterList object raising the notification.</para>
	/// </param>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer, which may be , to an object containing context info.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/nc-dxcore_interface-pfn_dxcore_notification_callback
	// PFN_DXCORE_NOTIFICATION_CALLBACK PfnDxcoreNotificationCallback; void PfnDxcoreNotificationCallback( DXCoreNotificationType
	// notificationType, IUnknown *object, [in] void *context ) {...}
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NC:dxcore_interface.PFN_DXCORE_NOTIFICATION_CALLBACK")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void PFN_DXCORE_NOTIFICATION_CALLBACK(DXCoreNotificationType notificationType,
		[MarshalAs(UnmanagedType.Interface)] object? @object, [In] IntPtr context);

	/// <summary>
	/// Defines constants that specify DXCore adapter preferences to be used as list-sorting criteria. You can sort a DXCore adapter list by
	/// passing an array of <c>DXCoreAdapterPreference</c> to IDXCoreAdapterList::Sort.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ne-dxcore_interface-dxcoreadapterpreference typedef enum
	// DXCoreAdapterPreference { Hardware = 0, MinimumPower = 1, HighPerformance = 2 } ;
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NE:dxcore_interface.DXCoreAdapterPreference")]
	public enum DXCoreAdapterPreference
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies a preference for hardware adapters (as opposed to software adapters).</para>
		/// </summary>
		Hardware,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Specifies a preference for the minimum-powered GPU (such as an integrated graphics processor, or iGPU).</para>
		/// </summary>
		MinimumPower,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// Specifies a preference for the highest-performance GPU, such as an external graphics processor (xGPU), if available, or discrete
		/// graphics processor (dGPU) if available.
		/// </para>
		/// </summary>
		HighPerformance,
	}

	/// <summary>
	/// <para>Important</para>
	/// <para>
	/// Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft
	/// makes no warranties, express or implied, with respect to the information provided here.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ne-dxcore_interface-dxcoreadapterproperty typedef enum
	// DXCoreAdapterProperty { InstanceLuid = 0, DriverVersion = 1, DriverDescription = 2, HardwareID = 3, KmdModelVersion = 4,
	// ComputePreemptionGranularity = 5, GraphicsPreemptionGranularity = 6, DedicatedAdapterMemory = 7, DedicatedSystemMemory = 8,
	// SharedSystemMemory = 9, AcgCompatible = 10, IsHardware = 11, IsIntegrated = 12, IsDetachable = 13, HardwareIDParts = 14,
	// PhysicalAdapterCount = 15, AdapterEngineCount = 16, AdapterEngineName = 17 } ;
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NE:dxcore_interface.DXCoreAdapterProperty")]
	public enum DXCoreAdapterProperty
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// Specifies the InstanceLuid adapter property, which contains a locally unique identifier representing the adapter. This value
		/// remains constant for the lifetime of this adapter. The LUID of an adapter changes on reboot, driver upgrade, or device disablement/enablement.
		/// </para>
		/// <para>The InstanceLuid adapter property has type LUID.</para>
		/// </summary>
		InstanceLuid,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Specifies the DriverVersion adapter property, which contains the driver version, represented in WORDs as a LARGE_INTEGER.</para>
		/// <para>The DriverVersion adapter property has type ulong, representing a Boolean value.</para>
		/// </summary>
		DriverVersion,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// Specifies the DriverDescription adapter property, which contains a NULL-terminated array of CHARs describing the driver, as
		/// specified by the driver, in UTF-8 encoding.
		/// </para>
		/// <para>The DriverDescription adapter property has type char*.</para>
		/// </summary>
		DriverDescription,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>
		/// Specifies the HardwareID adapter property, which represents the PnP hardware ID parts. But use HardwareIDParts instead, if available.
		/// </para>
		/// <para>The HardwareID adapter property has type DXCoreHardwareID.</para>
		/// </summary>
		HardwareID,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Specifies the KmdModelVersion adapter property, which represents the driver model.</para>
		/// <para>The KmdModelVersion adapter property has type D3DKMT_DRIVERVERSION.</para>
		/// </summary>
		KmdModelVersion,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Specifies the ComputePreemptionGranularity adapter property, which represents the compute preemption granularity.</para>
		/// <para>
		/// The ComputePreemptionGranularity adapter property has type uint16_t , representing a D3DKMDT_COMPUTE_PREEMPTION_GRANULARITY value.
		/// </para>
		/// </summary>
		ComputePreemptionGranularity,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Specifies the GraphicsPreemptionGranularity adapter property, which represents the graphics preemption granularity.</para>
		/// <para>
		/// The GraphicsPreemptionGranularity adapter property has type uint16_t , representing a D3DKMDT_GRAPHICS_PREEMPTION_GRANULARITY value.
		/// </para>
		/// </summary>
		GraphicsPreemptionGranularity,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>
		/// Specifies the DedicatedAdapterMemory adapter property, which represents the number of bytes of dedicated adapter memory that are
		/// not shared with the CPU.
		/// </para>
		/// <para>The DedicatedVideoMemory adapter property has type ulong.</para>
		/// </summary>
		DedicatedAdapterMemory,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>
		/// Specifies the DedicatedSystemMemory adapter property, which represents the number of bytes of dedicated system memory that are
		/// not shared with the CPU. This memory is allocated from available system memory at boot time.
		/// </para>
		/// <para>The DedicatedSystemMemory adapter property has type ulong.</para>
		/// </summary>
		DedicatedSystemMemory,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>
		/// Specifies the SharedSystemMemory adapter property, which represents the number of bytes of shared system memory. This is the
		/// maximum value of system memory that may be consumed by the adapter during operation. Any incidental memory consumed by the
		/// driver as it manages and uses video memory is additional.
		/// </para>
		/// <para>The SharedSystemMemory adapter property has type ulong.</para>
		/// </summary>
		SharedSystemMemory,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>
		/// Specifies the AcgCompatible adapter property, which indicates whether the adapter is compatible with processes that enforce
		/// Arbitrary Code Guard.
		/// </para>
		/// <para>The AcgCompatible adapter property has type bool.</para>
		/// </summary>
		AcgCompatible,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>
		/// Specifies the IsHardware adapter property, which determines whether or not this is a hardware adapter. An adapter that's not a
		/// hardware adapter is a software adapter.
		/// </para>
		/// <para>The IsHardware adapter property has type bool.</para>
		/// </summary>
		IsHardware,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>
		/// Specifies the IsIntegrated adapter property, which determines whether the adapter is reported to be an integrated graphics
		/// processor (iGPU).
		/// </para>
		/// <para>The IsIntegrated adapter property has type bool.</para>
		/// </summary>
		IsIntegrated,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <para>
		/// Specifies the IsDetachable adapter property, which determines whether the adapter has been reported to be detachable, or removable.
		/// </para>
		/// <para>The IsDetachable adapter property has type bool.</para>
		/// <para>
		/// Note. Even if IDXCoreAdapter::GetProperty indicates false for this property, the adapter still has the ability to be reported as
		/// removed, such as in the case of malfunction, or driver update.
		/// </para>
		/// </summary>
		IsDetachable,

		/// <summary>
		/// <para>Value:</para>
		/// <para>14</para>
		/// <para>Specifies the HardwareIDParts adapter property, which represents the PnP hardware ID parts.</para>
		/// <para>The HardwareIDParts adapter property has type DXCoreHardwareID.</para>
		/// </summary>
		HardwareIDParts,

		/// <summary>
		/// <para>Value:</para>
		/// <para>15</para>
		/// <para>This query outputs the number of physical adapters grouped under the logical adapter.</para>
		/// </summary>
		PhysicalAdapterCount,

		/// <summary>
		/// <para>Value:</para>
		/// <para>16</para>
		/// <para>This query takes physical adapter index as input, and outputs the count of engines on the physical adapter.</para>
		/// </summary>
		AdapterEngineCount,

		/// <summary>
		/// <para>Value:</para>
		/// <para>17</para>
		/// <para>This query takes physical adapter index and engine ID as input, and outputs engine type.</para>
		/// </summary>
		AdapterEngineName,
	}

	/// <summary>
	/// <para>Important</para>
	/// <para>
	/// Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft
	/// makes no warranties, express or implied, with respect to the information provided here.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ne-dxcore_interface-dxcoreadapterstate typedef enum
	// DXCoreAdapterState { IsDriverUpdateInProgress = 0, AdapterMemoryBudget = 1, AdapterMemoryUsageBytes = 2,
	// AdapterMemoryUsageByProcessBytes = 3, AdapterEngineRunningTimeMicroseconds = 4, AdapterEngineRunningTimeByProcessMicroseconds = 5,
	// AdapterTemperatureCelsius = 6, AdapterInUseProcessCount = 7, AdapterInUseProcessSet = 8, AdapterEngineFrequencyHertz = 9,
	// AdapterMemoryFrequencyHertz = 10 } ;
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NE:dxcore_interface.DXCoreAdapterState")]
	public enum DXCoreAdapterState
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// Specifies the IsDriverUpdateInProgress adapter state, which when true indicates that a driver update has been initiated on the
		/// adapter but it has not yet completed. If the driver update has already completed, then the adapter will have been invalidated,
		/// and your QueryState call will return a HRESULT of DXGI_ERROR_DEVICE_REMOVED.
		/// </para>
		/// <para>When calling QueryState, the IsDriverUpdateInProgress state item has type uint8_t, representing a Boolean value.</para>
		/// <para>Important. This state item is not supported for SetState.</para>
		/// </summary>
		IsDriverUpdateInProgress,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Specifies the AdapterMemoryBudget adapter state, which retrieves or requests the adapter memory budget on the adapter.</para>
		/// <para>
		/// When calling QueryState, the AdapterMemoryBudget adapter state has type DXCoreAdapterMemoryBudgetNodeSegmentGroup for
		/// inputStateDetails, and type DXCoreAdapterMemoryBudget for outputBuffer.
		/// </para>
		/// <para>Important . This state item is not supported for SetState.</para>
		/// </summary>
		AdapterMemoryBudget,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// This query takes Physical Adapter Index and Dedicated vs. Shared as input; and outputs the Committed and Resident Memory
		/// Dedicated or Shared portions of GPU Memory, respectively.
		/// </para>
		/// </summary>
		AdapterMemoryUsageBytes,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>
		/// This query takes Engine ID, Physical Adapter Index, and Process Handle as input; and outputs Committed Memory and Resident
		/// Memory on Dedicated or Shared portions of GPU Memory, respectively.
		/// </para>
		/// </summary>
		AdapterMemoryUsageByProcessBytes,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>This query takes Engine ID and Physical Adapter Index as input; and outputs Engine Running Time as output.</para>
		/// </summary>
		AdapterEngineRunningTimeMicroseconds,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>This query takes Engine ID, Physical Adapter Index, and Process Handle as input; and outputs Engine Running Time as output.</para>
		/// </summary>
		AdapterEngineRunningTimeByProcessMicroseconds,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>This query takes Physical Adapter Index as input, and outputs Current GPU Temperature in Degrees Celsius.</para>
		/// </summary>
		AdapterTemperatureCelsius,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>This returns the number of processes using this adapter, and the PIDs in it, respectively.</para>
		/// </summary>
		AdapterInUseProcessCount,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>This returns the number of processes using this adapter, and the PIDs in it, respectively.</para>
		/// </summary>
		AdapterInUseProcessSet,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>
		/// This query takes in the physical adapter and engine indices, and outputs the clock frequency of the respective engine in hertz.
		/// The output structure also includes the maximum frequency for the engine, with and without overclocking.
		/// </para>
		/// </summary>
		AdapterEngineFrequencyHertz,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>
		/// This query takes in the physical adapter index, and outputs the clock frequency of its memory in hertz. The output structure
		/// also includes the maximum frequency for the memory, with and without overclocking.
		/// </para>
		/// </summary>
		AdapterMemoryFrequencyHertz,
	}

	/// <summary>Defines constants that specify a hardware type specified when enumerating adapters.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ne-dxcore_interface-dxcorehardwaretypefilterflags typedef enum
	// DXCoreHardwareTypeFilterFlags { None, GPU, ComputeAccelerator, NPU, MediaAccelerator } ;
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NE:dxcore_interface.DXCoreHardwareTypeFilterFlags")]
	public enum DXCoreHardwareTypeFilterFlags
	{
		/// <summary>Specifies no specific hardware type.</summary>
		None,

		/// <summary>Specifies a graphics processing unit (GPU).</summary>
		GPU,

		/// <summary>Specifies a compute accelerator.</summary>
		ComputeAccelerator,

		/// <summary>Specifies a neural processing unit (NPU).</summary>
		NPU,

		/// <summary>Specifies a media accelerator.</summary>
		MediaAccelerator,
	}

	/// <summary>Defines constants that specify memory type.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ne-dxcore_interface-dxcorememorytype typedef enum
	// DXCoreMemoryType { Dedicated, Shared } ;
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NE:dxcore_interface.DXCoreMemoryType")]
	public enum DXCoreMemoryType
	{
		/// <summary>Specifies dedicated memory.</summary>
		Dedicated,

		/// <summary>Specifies shared memory.</summary>
		Shared,
	}

	/// <summary>
	/// <para>Defines constants that specify types of notifications raised by IDXCoreAdapter or IDXCoreAdapterList objects.</para>
	/// <para>
	/// You can register and unregister for these notifications by calling IDXCoreAdapterFactory::RegisterEventNotification and
	/// IDXCoreAdapterFactory::UnregisterEventNotification, respectively.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ne-dxcore_interface-dxcorenotificationtype typedef enum
	// DXCoreNotificationType { AdapterListStale = 0, AdapterNoLongerValid = 1, AdapterBudgetChange = 2,
	// AdapterHardwareContentProtectionTeardown = 3 } ;
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NE:dxcore_interface.DXCoreNotificationType")]
	public enum DXCoreNotificationType
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>This notification is raised by an</para>
		/// <para>IDXCoreAdapterList</para>
		/// <para>
		/// object when the adapter list becomes stale. The fresh-to-stale transition is one-way, and one-time, so this notification is
		/// raised at most one time.
		/// </para>
		/// </summary>
		AdapterListStale,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>This notification is raised by an</para>
		/// <para>IDXCoreAdapter</para>
		/// <para>
		/// object when the adapter becomes no longer valid. The valid-to-invalid transition is one-way, and one-time, so this notification
		/// is raised at most one time.
		/// </para>
		/// </summary>
		AdapterNoLongerValid,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>This notification is raised by an</para>
		/// <para>IDXCoreAdapter</para>
		/// <para>
		/// object when an adapter budget change occurs. This notification can occur many times. Using this notification is functionally
		/// similar to
		/// </para>
		/// <para>IDXGIAdapter3::RegisterVideoMemoryBudgetChangeNotificationEvent</para>
		/// <para>. In response to this event, you should call</para>
		/// <para>IDXCoreAdapter::QueryState</para>
		/// <para>(with</para>
		/// <para>DXCoreAdapterState::AdapterMemoryBudget</para>
		/// <para>) to evaluate the current memory budget state.</para>
		/// </summary>
		AdapterBudgetChange,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>This notification is raised by an</para>
		/// <para>IDXCoreAdapter</para>
		/// <para>
		/// object to notify of an adapter's hardware content protection teardown. This notification can occur many times. It is
		/// functionally similar to
		/// </para>
		/// <para>IDXGIAdapter3::RegisterHardwareContentProtectionTeardownStatusEvent</para>
		/// <para>. In response to this event, you should re-evaluate the current crypto session status; for example, by calling</para>
		/// <para>ID3D11VideoContext1::CheckCryptoSessionStatus</para>
		/// <para>to determine the impact of the hardware teardown for a specific</para>
		/// <para>ID3D11CryptoSession</para>
		/// <para>interface.</para>
		/// </summary>
		AdapterHardwareContentProtectionTeardown,
	}

	/// <summary>Defines constants that specify runtime filter flags.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ne-dxcore_interface-dxcoreruntimefilterflags typedef enum
	// DXCoreRuntimeFilterFlags { None, D3D11, D3D12 } ;
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NE:dxcore_interface.DXCoreRuntimeFilterFlags")]
	public enum DXCoreRuntimeFilterFlags
	{
		/// <summary>Specifies no filter.</summary>
		None,

		/// <summary>Specifies Direct3D 11.</summary>
		D3D11,

		/// <summary>Specifies Direct3D 12.</summary>
		D3D12,
	}

	/// <summary>Defines constants that specify an adapter's memory segment grouping.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ne-dxcore_interface-dxcoresegmentgroup typedef enum
	// DXCoreSegmentGroup { Local = 0, NonLocal = 1 } ;
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NE:dxcore_interface.DXCoreSegmentGroup")]
	public enum DXCoreSegmentGroup
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// Specifies a grouping of segments that is considered local to the adapter, and represents the fastest memory available to the
		/// GPU. Your application should target the local segment group as the target size for its working set.
		/// </para>
		/// </summary>
		Local,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Specifies a grouping of segments that is considered non-local to the adapter, and may have slower performance than the local
		/// segment group.
		/// </para>
		/// </summary>
		NonLocal,
	}

	/// <summary>Defines constants that specify a workload type.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ne-dxcore_interface-dxcoreworkload typedef enum DXCoreWorkload {
	// Graphics, Compute, Media, MachineLearning } ;
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NE:dxcore_interface.DXCoreWorkload")]
	public enum DXCoreWorkload
	{
		/// <summary>Specifies a graphics workload.</summary>
		Graphics,

		/// <summary>Specifies a compute workload.</summary>
		Compute,

		/// <summary>Specifies a media workload.</summary>
		Media,

		/// <summary>Specifies a machine learning workload.</summary>
		MachineLearning,
	}

	/// <summary>
	/// The  <b>IDXCoreAdapter</b> interface implements methods for retrieving details about an adapter item. <b>IDXCoreAdapter</b> inherits
	/// from the <c>IUnknown</c> interface. For programming guidance, and code examples, see <c>Using DXCore to enumerate adapters</c>.
	/// </summary>
	/// <remarks>
	/// An adapter's properties are established at the time the adapter starts, and they're immutable for the lifetime of the adapter. This
	/// is in contrast to an adapter's state, which can be queried or set, and the values of which can change over time.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nn-dxcore_interface-idxcoreadapter
	[PInvokeData("dxcore_interface.h")]
	[ComImport, Guid("f0db4c7f-fe5a-42a2-bd62-f2a6cf6fc83e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXCoreAdapter
	{
		/// <summary>
		/// Determines whether this DXCore adapter object is still valid. For programming guidance, and code examples, see <c>Using DXCore
		/// to enumerate adapters</c>.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns  <c>true</c> if this DXCore adapter object is still valid. Otherwise, returns  <c>false</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-isvalid virtual bool
		// STDMETHODCALLTYPE IsValid() = 0;
		[PreserveSig]
		bool IsValid();

		/// <summary>Determines whether this DXCore adapter object supports the specified adapter attribute.</summary>
		/// <param name="attributeGUID">
		/// A reference to an adapter attribute GUID. For a list of attribute GUIDs, see DXCore adapter attribute GUIDs.
		/// </param>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns  <c>true</c> if this DXCore adapter object supports the specified adapter attribute. Otherwise, returns  <c>false</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-isattributesupported
		// virtual bool STDMETHODCALLTYPE IsAttributeSupported( REFGUID attributeGUID) = 0;
		[PreserveSig]
		bool IsAttributeSupported(in Guid attributeGUID);

		/// <summary>
		/// Determines whether this DXCore adapter object and the current operating system (OS) support the specified adapter property.
		/// </summary>
		/// <param name="property">
		/// The type of property that you're querying about support for. See the table in DXCoreAdapterProperty for more info about each
		/// adapter property.
		/// </param>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// Returns  <c>true</c> if this DXCore adapter object and the current operating system (OS) support the specified adapter property.
		/// Otherwise, returns  <c>false</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-ispropertysupported
		// virtual bool STDMETHODCALLTYPE IsPropertySupported( DXCoreAdapterProperty property) = 0;
		[PreserveSig]
		bool IsPropertySupported(DXCoreAdapterProperty property);

		/// <summary>
		/// Retrieves the value of the specified adapter property. Before calling <b>GetProperty</b> for a property type, call
		/// <c>IsPropertySupported</c> to confirm that the property type is available for this adapter and operating system (OS). Also
		/// before calling <b>GetProperty</b>, call <c>GetPropertySize</c> to determine the necessary size of the buffer in which to receive
		/// the property value.
		/// </summary>
		/// <param name="property">
		/// The type of the property whose value you wish to retrieve. See the table in DXCoreAdapterProperty for more info about each
		/// adapter property.
		/// </param>
		/// <param name="bufferSize">The size, in bytes, of the output buffer that you allocate and provide in propertyData.</param>
		/// <param name="propertyData">
		/// A pointer to an output buffer that you allocate in your application, and that the function fills in. Call GetPropertySize to
		/// determine the size that the propertyData buffer should be for a given adapter property.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL</description>
		/// <description>
		/// The property type specified in <c>property</c> is not recognized by this operating system (OS). Call <c>IsPropertySupported</c>
		/// to confirm that the property type is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_UNSUPPORTED</description>
		/// <description>
		/// The property type specified in <c>property</c> is not supported by the adapter. Call <c>IsPropertySupported</c> to confirm that
		/// the property type is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// An insufficient buffer size is provided in <c>propertyData</c>. Call <c>GetPropertySize</c> to determine the size that the
		/// <c>propertyData</c> buffer should be for a given adapter property.
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>propertyData</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// You can call <b>GetProperty</b> on an adapter that's no longer valid—the function won't fail as a result of that. This function
		/// zeros out the propertyData buffer prior to filling it in.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-getproperty virtual
		// HRESULT STDMETHODCALLTYPE GetProperty( DXCoreAdapterProperty property, size_t bufferSize, _Out_writes_bytes_(bufferSize) void
		// *propertyData) = 0; template &lt;class T&gt; HRESULT GetProperty( DXCoreAdapterProperty property, _Out_writes_bytes_(sizeof(T)) T *propertyData);
		[PreserveSig]
		HRESULT GetProperty(DXCoreAdapterProperty property, ulong bufferSize, [Out] IntPtr propertyData);

		/// <summary>
		/// For a specified adapter property, retrieves the size of buffer, in bytes, that is required for a call to <c>GetProperty</c>.
		/// Before calling <b>GetPropertySize</b> for a property type, call <c>IsPropertySupported</c> to confirm that the property type is
		/// available for this adapter and operating system (OS).
		/// </summary>
		/// <param name="property">The type of the property whose size, in bytes, you wish to retrieve.</param>
		/// <param name="bufferSize">
		/// A pointer to a size_t value. The function dereferences the pointer and sets the value to the size, in bytes, of the output
		/// buffer that you should allocate and pass as the propertyData argument in your call to GetProperty.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL</description>
		/// <description>
		/// The property type specified in <c>property</c> is not recognized by this operating system (OS). Call <c>IsPropertySupported</c>
		/// to confirm that the property type is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_UNSUPPORTED</description>
		/// <description>
		/// The property type specified in <c>property</c> is not supported by the adapter. Call <c>IsPropertySupported</c> to confirm that
		/// the property type is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>bufferSize</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>You can call <b>GetPropertySize</b> on an adapter that's no longer valid—the function won't fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-getpropertysize
		// virtual HRESULT STDMETHODCALLTYPE GetPropertySize( DXCoreAdapterProperty property, _Out_ size_t *bufferSize) = 0;
		[PreserveSig]
		HRESULT GetPropertySize(DXCoreAdapterProperty property, out ulong bufferSize);

		/// <summary>
		/// Determines whether this DXCore adapter object and the current operating system (OS) support querying the value of the specified
		/// adapter state.
		/// </summary>
		/// <param name="property">
		/// The kind of state item that you're querying about support for. See the table in DXCoreAdapterState for more info about each
		/// adapter state kind.
		/// </param>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// Returns  <c>true</c> if this DXCore adapter object and the current operating system (OS) support querying the specified adapter
		/// state. Otherwise, returns  <c>false</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-isquerystatesupported
		// virtual bool STDMETHODCALLTYPE IsQueryStateSupported( DXCoreAdapterState property) = 0;
		[PreserveSig]
		bool IsQueryStateSupported(DXCoreAdapterState property);

		/// <summary>
		/// Retrieves the current state of the specified item on the adapter. Before calling <b>QueryState</b> for a property type, call
		/// <c>IsQueryStateSupported</c> to confirm that querying the state kind is available for this adapter and operating system (OS).
		/// </summary>
		/// <param name="state">
		/// The kind of state item on the adapter whose state you wish to retrieve. See the table in DXCoreAdapterState for more info about
		/// each adapter state kind.
		/// </param>
		/// <param name="inputStateDetailsSize">
		/// The size, in bytes, of the input state details buffer that you (optionally) allocate and provide in inputStateDetails.
		/// </param>
		/// <param name="inputStateDetails">
		/// An optional pointer to a constant input state details buffer that you allocate in your application, containing any information
		/// about your request that's required for the state kind you specify in state. See the table in DXCoreAdapterState for more info
		/// about any input buffer requirement for a given state kind.
		/// </param>
		/// <param name="outputBufferSize">The size, in bytes, of the output buffer that you allocate and provide in outputBuffer.</param>
		/// <param name="outputBuffer">
		/// A pointer to an output buffer that you allocate in your application, and that the function fills in. See the table in
		/// DXCoreAdapterState for more info about the output buffer requirement for a given state kind.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_DEVICE_REMOVED</description>
		/// <description>The adapter is no longer in a valid state.</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL</description>
		/// <description>
		/// The state kind specified in <c>state</c> is not recognized by this operating system (OS). Call <c>IsQueryStateSupported</c> to
		/// confirm that querying the state kind is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_UNSUPPORTED</description>
		/// <description>
		/// The state kind specified in <c>state</c> is not supported by the adapter. Call <c>IsQueryStateSupported</c> to confirm that
		/// querying the state kind is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// An insufficient buffer size is provided for <c>outputBuffer</c> (or for <c>inputStateDetails</c> where an input state details
		/// buffer is necessary).
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>outputBuffer</c> (or for <c>inputStateDetails</c> where an input state details buffer is necessary).
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// See <c>DXCoreAdapterState</c> for more info about each adapter state kind, and what inputs and outputs are used. This function
		/// zeros out the outputBuffer buffer prior to filling it in.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-querystate virtual
		// HRESULT STDMETHODCALLTYPE QueryState( DXCoreAdapterState state, size_t inputStateDetailsSize,
		// _In_reads_bytes_opt_(inputStateDetailsSize) const void *inputStateDetails, size_t outputBufferSize,
		// _Out_writes_bytes_(outputBufferSize) void *outputBuffer) = 0; template &lt;class T1, class T2&gt; HRESULT QueryState(
		// DXCoreAdapterState state, _In_reads_bytes_opt_(sizeof(T1)) const T1 *inputStateDetails, _Out_writes_bytes_(sizeof(T2)) T2
		// *outputBuffer); template &lt;class T&gt; HRESULT QueryState( DXCoreAdapterState state, _Out_writes_bytes_(sizeof(T)) T *outputBuffer);
		[PreserveSig]
		HRESULT QueryState(DXCoreAdapterState state, SizeT inputStateDetailsSize, [In, Optional] IntPtr inputStateDetails, SizeT outputBufferSize,
			[Out] IntPtr outputBuffer);

		/// <summary>
		/// Determines whether this DXCore adapter object and the current operating system (OS) support setting the value of the specified
		/// adapter state.
		/// </summary>
		/// <param name="property">
		/// The kind of state item that you're querying about support for. See the table in DXCoreAdapterState for more info about each
		/// adapter state kind.
		/// </param>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// Returns  <c>true</c> if this DXCore adapter object and the current operating system (OS) support setting the specified adapter
		/// state. Otherwise, returns  <c>false</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-issetstatesupported
		// virtual bool STDMETHODCALLTYPE IsSetStateSupported( DXCoreAdapterState property) = 0;
		[PreserveSig]
		bool IsSetStateSupported(DXCoreAdapterState property);

		/// <summary>
		/// Sets the state of the specified item on the adapter. Before calling <b>SetState</b> for a property type, call
		/// <c>IsSetStateSupported</c> to confirm that setting the state kind is available for this adapter and operating system (OS).
		/// </summary>
		/// <param name="state">
		/// The kind of state item on the adapter whose state you wish to set. See the table in DXCoreAdapterState for more info about each
		/// adapter state kind.
		/// </param>
		/// <param name="inputStateDetailsSize">
		/// The size, in bytes, of the input state details buffer that you (optionally) allocate and provide in inputStateDetails.
		/// </param>
		/// <param name="inputStateDetails">
		/// An optional pointer to a constant input state details buffer that you allocate in your application, containing any information
		/// about your request that's required for the state kind you specify in state. See the table in DXCoreAdapterState for more info
		/// about any input buffer requirement for a given state kind.
		/// </param>
		/// <param name="inputDataSize">The size, in bytes, of the input buffer that you allocate and provide in inputData.</param>
		/// <param name="inputData">
		/// A pointer to an input buffer that you allocate in your application, containing the state information to set for the state item
		/// whose kind you specify in state. See the table in DXCoreAdapterState for more info about the input buffer requirement for a
		/// given state kind.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_DEVICE_REMOVED</description>
		/// <description>The adapter is no longer in a valid state.</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL</description>
		/// <description>
		/// The state kind specified in <c>state</c> is not recognized by this operating system (OS). Call <c>IsSetStateSupported</c> to
		/// confirm that setting the state kind is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_UNSUPPORTED</description>
		/// <description>
		/// The state kind specified in <c>state</c> is not supported by the adapter. Call <c>IsSetStateSupported</c> to confirm that
		/// setting the state kind is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// An insufficient buffer size is provided for <c>inputData</c> (or for <c>inputStateDetails</c> where an input state details
		/// buffer is necessary).
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>inputData</c> (or for <c>inputStateDetails</c> where an input state details buffer is necessary).
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-setstate virtual
		// HRESULT STDMETHODCALLTYPE SetState( DXCoreAdapterState state, size_t inputStateDetailsSize,
		// _In_reads_bytes_opt_(inputStateDetailsSize) const void *inputStateDetails, size_t inputDataSize, _In_reads_bytes_(inputDataSize)
		// const void *inputData) = 0; template &lt;class T1, class T2&gt; HRESULT SetState( DXCoreAdapterState state, const T1
		// *inputStateDetails, const T2 *inputData);
		[PreserveSig]
		HRESULT SetState(DXCoreAdapterState state, SizeT inputStateDetailsSize, [In, Optional] IntPtr inputStateDetails, SizeT inputDataSize,
			[Out] IntPtr inputData);

		/// <summary>
		/// Retrieves an <c>IDXCoreAdapterFactory</c> interface pointer to the DXCore adapter factory object. For programming guidance, and
		/// code examples, see <c>Using DXCore to enumerate adapters</c>.
		/// </summary>
		/// <param name="riid">
		/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in ppvFactory. This is
		/// expected to be the interface identifier (IID) of IDXCoreAdapterFactory.
		/// </param>
		/// <param name="ppvFactory">
		/// The address of a pointer to an interface with the IID specified in the riid parameter. Upon successful return, *ppvFactory (the
		/// dereferenced address) contains a pointer to the existing DXCore adapter factory object. Before returning, the function
		/// increments the reference count on the factory object's IDXCoreAdapterFactory interface.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_NOINTERFACE</description>
		/// <description>An invalid value was provided for <c>riid</c>.</description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>ppvFactory</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// For the duration of time that a reference exists on an <c>IDXCoreAdapterFactory</c> interface, an <c>IDXCoreAdapterList</c>
		/// interface, or an <c>IDXCoreAdapter</c> interface, additional calls to <c>DXCoreCreateAdapterFactory</c>,
		/// <c>IDXCoreAdapterList::GetFactory</c>, or <b>IDXCoreAdapter::GetFactory</b> will return pointers to the same object, increasing
		/// the reference count of the <b>IDXCoreAdapterFactory</b> interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-getfactory virtual
		// HRESULT STDMETHODCALLTYPE GetFactory( REFIID riid, _COM_Outptr_ void** ppvFactory ) = 0; template &lt;class T&gt; HRESULT
		// GetFactory(_COM_Outptr_ T** ppvFactory);
		[PreserveSig]
		HRESULT GetFactory(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvFactory);
	}

	/// <summary>
	/// The  <b>IDXCoreAdapter1</b> interface implements methods for retrieving details about an adapter item. <b>IDXCoreAdapter1</b>
	/// inherits from the <c>IDXCoreAdapter</c> interface. For programming guidance, and code examples, see <c>Using DXCore to enumerate adapters</c>.
	/// </summary>
	/// <remarks>
	/// An adapter's properties are established at the time the adapter starts, and they're immutable for the lifetime of the adapter. This
	/// is in contrast to an adapter's state, which can be queried or set, and the values of which can change over time.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nn-dxcore_interface-idxcoreadapter1
	[PInvokeData("dxcore_interface.h")]
	[ComImport, Guid("a0783366-cfa3-43be-9d79-55b2da97c63c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXCoreAdapter1 : IDXCoreAdapter
	{
		/// <summary>
		/// Determines whether this DXCore adapter object is still valid. For programming guidance, and code examples, see <c>Using DXCore
		/// to enumerate adapters</c>.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns  <c>true</c> if this DXCore adapter object is still valid. Otherwise, returns  <c>false</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-isvalid virtual bool
		// STDMETHODCALLTYPE IsValid() = 0;
		[PreserveSig]
		new bool IsValid();

		/// <summary>Determines whether this DXCore adapter object supports the specified adapter attribute.</summary>
		/// <param name="attributeGUID">
		/// A reference to an adapter attribute GUID. For a list of attribute GUIDs, see DXCore adapter attribute GUIDs.
		/// </param>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns  <c>true</c> if this DXCore adapter object supports the specified adapter attribute. Otherwise, returns  <c>false</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-isattributesupported
		// virtual bool STDMETHODCALLTYPE IsAttributeSupported( REFGUID attributeGUID) = 0;
		[PreserveSig]
		new bool IsAttributeSupported(in Guid attributeGUID);

		/// <summary>
		/// Determines whether this DXCore adapter object and the current operating system (OS) support the specified adapter property.
		/// </summary>
		/// <param name="property">
		/// The type of property that you're querying about support for. See the table in DXCoreAdapterProperty for more info about each
		/// adapter property.
		/// </param>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// Returns  <c>true</c> if this DXCore adapter object and the current operating system (OS) support the specified adapter property.
		/// Otherwise, returns  <c>false</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-ispropertysupported
		// virtual bool STDMETHODCALLTYPE IsPropertySupported( DXCoreAdapterProperty property) = 0;
		[PreserveSig]
		new bool IsPropertySupported(DXCoreAdapterProperty property);

		/// <summary>
		/// Retrieves the value of the specified adapter property. Before calling <b>GetProperty</b> for a property type, call
		/// <c>IsPropertySupported</c> to confirm that the property type is available for this adapter and operating system (OS). Also
		/// before calling <b>GetProperty</b>, call <c>GetPropertySize</c> to determine the necessary size of the buffer in which to receive
		/// the property value.
		/// </summary>
		/// <param name="property">
		/// The type of the property whose value you wish to retrieve. See the table in DXCoreAdapterProperty for more info about each
		/// adapter property.
		/// </param>
		/// <param name="bufferSize">The size, in bytes, of the output buffer that you allocate and provide in propertyData.</param>
		/// <param name="propertyData">
		/// A pointer to an output buffer that you allocate in your application, and that the function fills in. Call GetPropertySize to
		/// determine the size that the propertyData buffer should be for a given adapter property.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL</description>
		/// <description>
		/// The property type specified in <c>property</c> is not recognized by this operating system (OS). Call <c>IsPropertySupported</c>
		/// to confirm that the property type is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_UNSUPPORTED</description>
		/// <description>
		/// The property type specified in <c>property</c> is not supported by the adapter. Call <c>IsPropertySupported</c> to confirm that
		/// the property type is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// An insufficient buffer size is provided in <c>propertyData</c>. Call <c>GetPropertySize</c> to determine the size that the
		/// <c>propertyData</c> buffer should be for a given adapter property.
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>propertyData</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// You can call <b>GetProperty</b> on an adapter that's no longer valid—the function won't fail as a result of that. This function
		/// zeros out the propertyData buffer prior to filling it in.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-getproperty virtual
		// HRESULT STDMETHODCALLTYPE GetProperty( DXCoreAdapterProperty property, size_t bufferSize, _Out_writes_bytes_(bufferSize) void
		// *propertyData) = 0; template &lt;class T&gt; HRESULT GetProperty( DXCoreAdapterProperty property, _Out_writes_bytes_(sizeof(T)) T *propertyData);
		[PreserveSig]
		new HRESULT GetProperty(DXCoreAdapterProperty property, ulong bufferSize, [Out] IntPtr propertyData);

		/// <summary>
		/// For a specified adapter property, retrieves the size of buffer, in bytes, that is required for a call to <c>GetProperty</c>.
		/// Before calling <b>GetPropertySize</b> for a property type, call <c>IsPropertySupported</c> to confirm that the property type is
		/// available for this adapter and operating system (OS).
		/// </summary>
		/// <param name="property">The type of the property whose size, in bytes, you wish to retrieve.</param>
		/// <param name="bufferSize">
		/// A pointer to a size_t value. The function dereferences the pointer and sets the value to the size, in bytes, of the output
		/// buffer that you should allocate and pass as the propertyData argument in your call to GetProperty.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL</description>
		/// <description>
		/// The property type specified in <c>property</c> is not recognized by this operating system (OS). Call <c>IsPropertySupported</c>
		/// to confirm that the property type is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_UNSUPPORTED</description>
		/// <description>
		/// The property type specified in <c>property</c> is not supported by the adapter. Call <c>IsPropertySupported</c> to confirm that
		/// the property type is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>bufferSize</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>You can call <b>GetPropertySize</b> on an adapter that's no longer valid—the function won't fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-getpropertysize
		// virtual HRESULT STDMETHODCALLTYPE GetPropertySize( DXCoreAdapterProperty property, _Out_ size_t *bufferSize) = 0;
		[PreserveSig]
		new HRESULT GetPropertySize(DXCoreAdapterProperty property, out ulong bufferSize);

		/// <summary>
		/// Determines whether this DXCore adapter object and the current operating system (OS) support querying the value of the specified
		/// adapter state.
		/// </summary>
		/// <param name="property">
		/// The kind of state item that you're querying about support for. See the table in DXCoreAdapterState for more info about each
		/// adapter state kind.
		/// </param>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// Returns  <c>true</c> if this DXCore adapter object and the current operating system (OS) support querying the specified adapter
		/// state. Otherwise, returns  <c>false</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-isquerystatesupported
		// virtual bool STDMETHODCALLTYPE IsQueryStateSupported( DXCoreAdapterState property) = 0;
		[PreserveSig]
		new bool IsQueryStateSupported(DXCoreAdapterState property);

		/// <summary>
		/// Retrieves the current state of the specified item on the adapter. Before calling <b>QueryState</b> for a property type, call
		/// <c>IsQueryStateSupported</c> to confirm that querying the state kind is available for this adapter and operating system (OS).
		/// </summary>
		/// <param name="state">
		/// The kind of state item on the adapter whose state you wish to retrieve. See the table in DXCoreAdapterState for more info about
		/// each adapter state kind.
		/// </param>
		/// <param name="inputStateDetailsSize">
		/// The size, in bytes, of the input state details buffer that you (optionally) allocate and provide in inputStateDetails.
		/// </param>
		/// <param name="inputStateDetails">
		/// An optional pointer to a constant input state details buffer that you allocate in your application, containing any information
		/// about your request that's required for the state kind you specify in state. See the table in DXCoreAdapterState for more info
		/// about any input buffer requirement for a given state kind.
		/// </param>
		/// <param name="outputBufferSize">The size, in bytes, of the output buffer that you allocate and provide in outputBuffer.</param>
		/// <param name="outputBuffer">
		/// A pointer to an output buffer that you allocate in your application, and that the function fills in. See the table in
		/// DXCoreAdapterState for more info about the output buffer requirement for a given state kind.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_DEVICE_REMOVED</description>
		/// <description>The adapter is no longer in a valid state.</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL</description>
		/// <description>
		/// The state kind specified in <c>state</c> is not recognized by this operating system (OS). Call <c>IsQueryStateSupported</c> to
		/// confirm that querying the state kind is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_UNSUPPORTED</description>
		/// <description>
		/// The state kind specified in <c>state</c> is not supported by the adapter. Call <c>IsQueryStateSupported</c> to confirm that
		/// querying the state kind is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// An insufficient buffer size is provided for <c>outputBuffer</c> (or for <c>inputStateDetails</c> where an input state details
		/// buffer is necessary).
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>outputBuffer</c> (or for <c>inputStateDetails</c> where an input state details buffer is necessary).
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// See <c>DXCoreAdapterState</c> for more info about each adapter state kind, and what inputs and outputs are used. This function
		/// zeros out the outputBuffer buffer prior to filling it in.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-querystate virtual
		// HRESULT STDMETHODCALLTYPE QueryState( DXCoreAdapterState state, size_t inputStateDetailsSize,
		// _In_reads_bytes_opt_(inputStateDetailsSize) const void *inputStateDetails, size_t outputBufferSize,
		// _Out_writes_bytes_(outputBufferSize) void *outputBuffer) = 0; template &lt;class T1, class T2&gt; HRESULT QueryState(
		// DXCoreAdapterState state, _In_reads_bytes_opt_(sizeof(T1)) const T1 *inputStateDetails, _Out_writes_bytes_(sizeof(T2)) T2
		// *outputBuffer); template &lt;class T&gt; HRESULT QueryState( DXCoreAdapterState state, _Out_writes_bytes_(sizeof(T)) T *outputBuffer);
		[PreserveSig]
		new HRESULT QueryState(DXCoreAdapterState state, SizeT inputStateDetailsSize, [In, Optional] IntPtr inputStateDetails, SizeT outputBufferSize,
			[Out] IntPtr outputBuffer);

		/// <summary>
		/// Determines whether this DXCore adapter object and the current operating system (OS) support setting the value of the specified
		/// adapter state.
		/// </summary>
		/// <param name="property">
		/// The kind of state item that you're querying about support for. See the table in DXCoreAdapterState for more info about each
		/// adapter state kind.
		/// </param>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// Returns  <c>true</c> if this DXCore adapter object and the current operating system (OS) support setting the specified adapter
		/// state. Otherwise, returns  <c>false</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-issetstatesupported
		// virtual bool STDMETHODCALLTYPE IsSetStateSupported( DXCoreAdapterState property) = 0;
		[PreserveSig]
		new bool IsSetStateSupported(DXCoreAdapterState property);

		/// <summary>
		/// Sets the state of the specified item on the adapter. Before calling <b>SetState</b> for a property type, call
		/// <c>IsSetStateSupported</c> to confirm that setting the state kind is available for this adapter and operating system (OS).
		/// </summary>
		/// <param name="state">
		/// The kind of state item on the adapter whose state you wish to set. See the table in DXCoreAdapterState for more info about each
		/// adapter state kind.
		/// </param>
		/// <param name="inputStateDetailsSize">
		/// The size, in bytes, of the input state details buffer that you (optionally) allocate and provide in inputStateDetails.
		/// </param>
		/// <param name="inputStateDetails">
		/// An optional pointer to a constant input state details buffer that you allocate in your application, containing any information
		/// about your request that's required for the state kind you specify in state. See the table in DXCoreAdapterState for more info
		/// about any input buffer requirement for a given state kind.
		/// </param>
		/// <param name="inputDataSize">The size, in bytes, of the input buffer that you allocate and provide in inputData.</param>
		/// <param name="inputData">
		/// A pointer to an input buffer that you allocate in your application, containing the state information to set for the state item
		/// whose kind you specify in state. See the table in DXCoreAdapterState for more info about the input buffer requirement for a
		/// given state kind.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_DEVICE_REMOVED</description>
		/// <description>The adapter is no longer in a valid state.</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL</description>
		/// <description>
		/// The state kind specified in <c>state</c> is not recognized by this operating system (OS). Call <c>IsSetStateSupported</c> to
		/// confirm that setting the state kind is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_UNSUPPORTED</description>
		/// <description>
		/// The state kind specified in <c>state</c> is not supported by the adapter. Call <c>IsSetStateSupported</c> to confirm that
		/// setting the state kind is available for this adapter and operating system (OS).
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// An insufficient buffer size is provided for <c>inputData</c> (or for <c>inputStateDetails</c> where an input state details
		/// buffer is necessary).
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>inputData</c> (or for <c>inputStateDetails</c> where an input state details buffer is necessary).
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-setstate virtual
		// HRESULT STDMETHODCALLTYPE SetState( DXCoreAdapterState state, size_t inputStateDetailsSize,
		// _In_reads_bytes_opt_(inputStateDetailsSize) const void *inputStateDetails, size_t inputDataSize, _In_reads_bytes_(inputDataSize)
		// const void *inputData) = 0; template &lt;class T1, class T2&gt; HRESULT SetState( DXCoreAdapterState state, const T1
		// *inputStateDetails, const T2 *inputData);
		[PreserveSig]
		new HRESULT SetState(DXCoreAdapterState state, SizeT inputStateDetailsSize, [In, Optional] IntPtr inputStateDetails, SizeT inputDataSize,
			[Out] IntPtr inputData);

		/// <summary>
		/// Retrieves an <c>IDXCoreAdapterFactory</c> interface pointer to the DXCore adapter factory object. For programming guidance, and
		/// code examples, see <c>Using DXCore to enumerate adapters</c>.
		/// </summary>
		/// <param name="riid">
		/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in ppvFactory. This is
		/// expected to be the interface identifier (IID) of IDXCoreAdapterFactory.
		/// </param>
		/// <param name="ppvFactory">
		/// The address of a pointer to an interface with the IID specified in the riid parameter. Upon successful return, *ppvFactory (the
		/// dereferenced address) contains a pointer to the existing DXCore adapter factory object. Before returning, the function
		/// increments the reference count on the factory object's IDXCoreAdapterFactory interface.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_NOINTERFACE</description>
		/// <description>An invalid value was provided for <c>riid</c>.</description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>ppvFactory</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// For the duration of time that a reference exists on an <c>IDXCoreAdapterFactory</c> interface, an <c>IDXCoreAdapterList</c>
		/// interface, or an <c>IDXCoreAdapter</c> interface, additional calls to <c>DXCoreCreateAdapterFactory</c>,
		/// <c>IDXCoreAdapterList::GetFactory</c>, or <b>IDXCoreAdapter::GetFactory</b> will return pointers to the same object, increasing
		/// the reference count of the <b>IDXCoreAdapterFactory</b> interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter-getfactory virtual
		// HRESULT STDMETHODCALLTYPE GetFactory( REFIID riid, _COM_Outptr_ void** ppvFactory ) = 0; template &lt;class T&gt; HRESULT
		// GetFactory(_COM_Outptr_ T** ppvFactory);
		[PreserveSig]
		new HRESULT GetFactory(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvFactory);

		/// <summary>TBD</summary>
		/// <param name="property">TBD</param>
		/// <param name="inputPropertyDetailsSize">TBD</param>
		/// <param name="inputPropertyDetails">TBD</param>
		/// <param name="outputBufferSize">TBD</param>
		/// <param name="outputBuffer">TBD</param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapter1-getpropertywithinput
		// virtual HRESULT STDMETHODCALLTYPE GetPropertyWithInput( DXCoreAdapterProperty property, size_t inputPropertyDetailsSize,
		// _In_reads_bytes_opt_(inputPropertyDetailsSize) const void *inputPropertyDetails, size_t outputBufferSize,
		// _Out_writes_bytes_(outputBufferSize) void *outputBuffer) = 0; template &lt;class T1, class T2&gt; HRESULT GetPropertyWithInput(
		// DXCoreAdapterProperty property, _In_reads_bytes_opt_(sizeof(T1)) const T1 *inputPropertyDetails, _Out_writes_bytes_(sizeof(T2))
		// T2 *outputBuffer);
		[PreserveSig]
		HRESULT GetPropertyWithInput(DXCoreAdapterProperty property, SizeT inputPropertyDetailsSize, [In, Optional] IntPtr inputPropertyDetails,
			SizeT outputBufferSize, [Out] IntPtr outputBuffer);
	}

	/// <summary>
	/// The  <b>IDXCoreAdapterFactory</b> interface implements methods for generating DXCore adapter enumeration objects, and for retrieving
	/// their details. <b>IDXCoreAdapterFactory</b> inherits from the <c>IUnknown</c> interface. For programming guidance, and code
	/// examples, see <c>Using DXCore to enumerate adapters</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nn-dxcore_interface-idxcoreadapterfactory
	[PInvokeData("dxcore_interface.h")]
	[ComImport, Guid("78ee5945-c36e-4b13-a669-005dd11c0f06"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXCoreAdapterFactory
	{
		/// <summary>
		/// Generates a list of adapter objects representing the current adapter state of the system, and meeting the criteria specified.
		/// For programming guidance, and code examples, see <c>Using DXCore to enumerate adapters</c>.
		/// </summary>
		/// <param name="numAttributes">The number of elements in the array pointed to by the filterAttributes argument.</param>
		/// <param name="filterAttributes">
		/// A pointer to an array of adapter attribute GUIDs. For a list of attribute GUIDs, see DXCore adapter attribute GUIDs. At least
		/// one GUID must be provided. In the case that more than one GUID is provided in the array, only adapters that meet all of the
		/// requested attributes will be included in the returned list.
		/// </param>
		/// <param name="riid">
		/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in ppvAdapterList. This is
		/// expected to be the interface identifier (IID) of IDXCoreAdapterList.
		/// </param>
		/// <param name="ppvAdapterList">
		/// The address of a pointer to an interface with the IID specified in the riid parameter. Upon successful return, *ppvAdapterList
		/// (the dereferenced address) contains a pointer to the adapter list created.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>filterAttributes</c>, or 0 was provided for <c>numAttributes</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_NOINTERFACE</description>
		/// <description>An invalid value was provided for <c>riid</c>.</description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>ppvAdapterList</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Even if no adapters are found, as long as the arguments are valid, <b>CreateAdapterList</b> creates a valid
		/// <c>IDXCoreAdapterList</c> object, and returns <b>S_OK</b>. Once generated, the adapters in this specific list won't change. But
		/// the list will be considered stale if one of the adapters later becomes invalid, or if a new adapter arrives that meets the
		/// provided filter criteria. The list returned by <b>CreateAdapterList</b> is not ordered in any particular way, but the ordering
		/// of a list is consistent across multiple calls, and even across operating system restarts. The ordering may change upon system
		/// configuration changes, including the addition or removal of an adapter, or a driver update on an existing adapter. You can
		/// register for these changes with <c>IDXCoreAdapterFactory::RegisterEventNotification</c> using the notification type <b>DXCoreNotificationType.AdapterListStale</b>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterfactory-createadapterlist
		// virtual HRESULT STDMETHODCALLTYPE CreateAdapterList( uint32_t numAttributes, _In_reads_(numAttributes) const GUID
		// *filterAttributes, REFIID riid, _COM_Outptr_ void **ppvAdapterList) = 0; template&lt;class T&gt; HRESULT STDMETHODCALLTYPE
		// CreateAdapterList( uint32_t numAttributes, _In_reads_(numAttributes) const GUID *filterAttributes, _COM_Outptr_ T **ppvAdapterList);
		[PreserveSig]
		HRESULT CreateAdapterList(int numAttributes, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Guid[] filterAttributes,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppvAdapterList);

		/// <summary>
		/// Retrieves the DXCore adapter object ( <c>IDXCoreAdapter</c>) for a specified LUID, if available. For programming guidance, and
		/// code examples, see <c>Using DXCore to enumerate adapters</c>.
		/// </summary>
		/// <param name="adapterLUID">The locally unique value that identifies the adapter instance.</param>
		/// <param name="riid">
		/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in ppvAdapter. This is
		/// expected to be the interface identifier (IID) of IDXCoreAdapter.
		/// </param>
		/// <param name="ppvAdapter">
		/// The address of a pointer to an interface with the IID specified in the riid parameter. Upon successful return, *ppvAdapter (the
		/// dereferenced address) contains a pointer to the DXCore adapter created.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_DEVICE_REMOVED</description>
		/// <description>The adapter LUID passed in <c>adapterLUID</c> is recognized, but the adapter is no longer in a valid state.</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>No such adapter LUID as the value passed in <c>adapterLUID</c> is available through DXCore.</description>
		/// </item>
		/// <item>
		/// <description>E_NOINTERFACE</description>
		/// <description>An invalid value was provided for <c>riid</c>.</description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>ppvAdapter</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Multiple calls passing the same <c>LUID</c> return identical interface pointers. As a result, it's safe to compare interface
		/// pointers to determine whether multiple pointers refer to the same adapter object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterfactory-getadapterbyluid
		// virtual HRESULT STDMETHODCALLTYPE GetAdapterByLuid( const LUID &amp;adapterLUID, REFIID riid, _COM_Outptr_ void **ppvAdapter) =
		// 0; template&lt;class T&gt; HRESULT STDMETHODCALLTYPE GetAdapterByLuid( const LUID &amp;adapterLUID, _COM_Outptr_ T **ppvAdapter);
		[PreserveSig]
		HRESULT GetAdapterByLuid(in LUID adapterLUID, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvAdapter);

		/// <summary>
		/// Determines whether a specified notification type is supported by the operating system (OS). For programming guidance, and code
		/// examples, see <c>Using DXCore to enumerate adapters</c>.
		/// </summary>
		/// <param name="notificationType">
		/// The type of notification that you're querying about support for. See the table in DXCoreNotificationType for info about the
		/// notification types.
		/// </param>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns  <c>true</c> if the notification type is supported by the system. Otherwise, returns  <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// You can call <b>IsNotificationTypeSupported</b> to determine whether a given notification type is known to this version of the
		/// OS. For example, a notification type that's introduced in a particular version of Windows is unknown to previous versions of Windows.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterfactory-isnotificationtypesupported
		// virtual bool STDMETHODCALLTYPE IsNotificationTypeSupported( DXCoreNotificationType notificationType) = 0;
		[PreserveSig]
		bool IsNotificationTypeSupported(DXCoreNotificationType notificationType);

		/// <summary>
		/// Registers to receive notifications of specific conditions from a DXCore adapter or adapter list. For programming guidance, and
		/// code examples, see <c>Using DXCore to enumerate adapters</c>.
		/// </summary>
		/// <param name="dxCoreObject">
		/// The DXCore object (IDXCoreAdapter or IDXCoreAdapterList) whose notifications you're subscribing to.
		/// </param>
		/// <param name="notificationType">
		/// The type of notification that you're registering for. See the table in DXCoreNotificationType for info about what types are
		/// valid with which kinds of objects.
		/// </param>
		/// <param name="callbackFunction">
		/// A pointer to a callback function (implemented by your application), which is called by the DXCore object for notification
		/// events. For the signature of the function, see PFN_DXCORE_NOTIFICATION_CALLBACK.
		/// </param>
		/// <param name="callbackContext">
		/// An optional pointer to an object containing context info. This object is passed to your callback function when the notification
		/// is raised.
		/// </param>
		/// <param name="eventCookie">
		/// A pointer to a uint32_t value. If successful, the function dereferences the pointer and sets the value to a non-zero cookie
		/// value representing this registration. Use this cookie value to unregister from the notification by calling
		/// IDXCoreAdapterFactory::UnregisterEventNotification. See Remarks.
		/// <para>
		/// If unsuccessful, the function dereferences the pointer and sets the value to zero, which represents an invalid cookie value.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL</description>
		/// <description><c>notificationType</c> is unsupported by the operating system (OS).</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>dxCoreObject</c>, or if an invalid <c>notificationType</c> and <c>dxCoreObject</c> combination was provided.
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for either <c>callbackFunction</c> or <c>eventCookie</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You use <b>RegisterEventNotification</b> to register for events raised by <c>IDXCoreAdapterList</c> and <c>IDXCoreAdapter</c>
		/// interfaces. These notification types are supported.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>DXCoreNotificationType</c></description>
		/// <description>Supported <c>dxCoreObject</c></description>
		/// <description>Notes</description>
		/// </listheader>
		/// <item>
		/// <description>AdapterListStale</description>
		/// <description><b>IDXCoreAdapterList</b></description>
		/// <description>
		/// Indicates that the list of adapters meeting your filter criteria has changed. If the adapter list is stale at the time of
		/// registration, then your callback is immediately called. This callback occurs at most one time per registration.
		/// </description>
		/// </item>
		/// <item>
		/// <description>AdapterNoLongerValid</description>
		/// <description><b>IDXCoreAdapter</b></description>
		/// <description>
		/// Indicates that the adapter is no longer valid. If the adapter is invalid at registration time, then your callback is immediately called.
		/// </description>
		/// </item>
		/// <item>
		/// <description>AdapterBudgetChange</description>
		/// <description><b>IDXCoreAdapter</b></description>
		/// <description>
		/// Indicates that a memory budgeting event has occurred, and that you should call <c>IDXCoreAdapter::QueryState</c> (with
		/// <c>DXCoreAdapterState::AdapterMemoryBudget</c>) to evaluate the current memory budget state. Upon registration, an initial
		/// callback will always occur to allow you to query the initial state.
		/// </description>
		/// </item>
		/// <item>
		/// <description>AdapterHardwareContentProtectionTeardown</description>
		/// <description><b>IDXCoreAdapter</b></description>
		/// <description>
		/// Indicates that you should re-evaluate the current crypto session status; for example, by calling
		/// <c>ID3D11VideoContext1::CheckCryptoSessionStatus</c> to determine the impact of the hardware teardown for a specific
		/// <c>ID3D11CryptoSession</c> interface. Upon registration, an initial callback will always occur to allow you to query the initial state.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// A call to the function that you provide in callbackFunction is made asynchronously on a background thread by DXCore when the
		/// detected event occurs. No guarantee is made as to the ordering or timing of callbacks—multiple callbacks may occur in any order,
		/// or even simultaneously. It's even possible for your callback to be invoked before <b>RegisterEventNotification</b> has
		/// completed. In that case, DXCore guarantees that your eventCookie is set before your callback is called. Multiple callbacks for a
		/// specific registration will be serialized in order.
		/// </para>
		/// <para>
		/// Callbacks may occur at any time until you call <c>UnregisterEventNotification</c>, and it completes. Callbacks occur on their
		/// own threads, and you may make calls into the DXCore API on those threads, including <b>UnregisterEventNotification</b>. However,
		/// you must not release the last reference to the dxCoreObject on this thread.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Before you destroy the DXCore object represented by the dxCoreObject argument passed to <b>RegisterEventNotification</b>, you
		/// must use the cookie value to unregister that object from notifications by calling
		/// <c>IDXCoreAdapterFactory::UnregisterEventNotification</c>. If you don't do that, then a fatal exception is raised when the
		/// situation is detected.
		/// </para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterfactory-registereventnotification
		// virtual HRESULT STDMETHODCALLTYPE RegisterEventNotification( _In_ IUnknown *dxCoreObject, DXCoreNotificationType
		// notificationType, _In_ PFN_DXCORE_NOTIFICATION_CALLBACK callbackFunction, _In_opt_ void *callbackContext, _Out_ uint32_t
		// *eventCookie) = 0;
		[PreserveSig]
		HRESULT RegisterEventNotification([In, MarshalAs(UnmanagedType.IUnknown)] object dxCoreObject, DXCoreNotificationType notificationType,
			PFN_DXCORE_NOTIFICATION_CALLBACK callbackFunction, [In, Optional] IntPtr callbackContext, out uint eventCookie);

		/// <summary>
		/// Unregisters from a notification that you previously registered for. For programming guidance, and code examples, see <c>Using
		/// DXCore to enumerate adapters</c>.
		/// </summary>
		/// <param name="eventCookie">
		/// The cookie value (returned when you called IDXCoreAdapterFactory::RegisterEventNotification) representing a prior registration
		/// that you now wish to unregister for.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>The value of <c>eventCookie</c> is not a valid cookie representing a prior registration.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>UnregisterEventNotification</b> returns only after all pending/in-progress callbacks for this registration have completed.
		/// DXCore guarantees that no new callbacks will occur for this registration after <b>UnregisterEventNotification</b> has returned.
		/// However, to avoid a deadlock, if you call <b>UnregisterEventNotification</b> from within your callback, then
		/// <b>UnregisterEventNotification</b> doesn't wait for the active callback to complete.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Before you destroy the DXCore object represented by the dxCoreObject argument passed to
		/// <c>IDXCoreAdapterFactory::RegisterEventNotification</c>, you must use the cookie value to unregister that object from
		/// notifications by calling <b>UnregisterEventNotification</b>. If you don't do that, then a fatal exception is raised when the
		/// situation is detected.
		/// </para>
		/// </para>
		/// <para>Once you unregister a cookie value, that value is then eligible for being returned by a subsequent registration</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterfactory-unregistereventnotification
		// virtual HRESULT STDMETHODCALLTYPE UnregisterEventNotification( uint32_t eventCookie) = 0;
		[PreserveSig]
		HRESULT UnregisterEventNotification(uint eventCookie);
	}

	/// <summary>
	/// The  <b>IDXCoreAdapterFactory1</b> interface implements methods for generating DXCore adapter enumeration objects, and for
	/// retrieving their details; including support for NPUs and media accelerators. <b>IDXCoreAdapterFactory1</b> inherits from the
	/// <c>IDXCoreAdapterFactory</c> interface. For programming guidance, and code examples, see <c>Using DXCore to enumerate adapters</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nn-dxcore_interface-idxcoreadapterfactory1
	[PInvokeData("dxcore_interface.h")]
	[ComImport, Guid("d5682e19-6d21-401c-827a-9a51a4ea35d7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXCoreAdapterFactory1 : IDXCoreAdapterFactory
	{
		/// <summary>
		/// Generates a list of adapter objects representing the current adapter state of the system, and meeting the criteria specified.
		/// For programming guidance, and code examples, see <c>Using DXCore to enumerate adapters</c>.
		/// </summary>
		/// <param name="numAttributes">The number of elements in the array pointed to by the filterAttributes argument.</param>
		/// <param name="filterAttributes">
		/// A pointer to an array of adapter attribute GUIDs. For a list of attribute GUIDs, see DXCore adapter attribute GUIDs. At least
		/// one GUID must be provided. In the case that more than one GUID is provided in the array, only adapters that meet all of the
		/// requested attributes will be included in the returned list.
		/// </param>
		/// <param name="riid">
		/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in ppvAdapterList. This is
		/// expected to be the interface identifier (IID) of IDXCoreAdapterList.
		/// </param>
		/// <param name="ppvAdapterList">
		/// The address of a pointer to an interface with the IID specified in the riid parameter. Upon successful return, *ppvAdapterList
		/// (the dereferenced address) contains a pointer to the adapter list created.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>filterAttributes</c>, or 0 was provided for <c>numAttributes</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_NOINTERFACE</description>
		/// <description>An invalid value was provided for <c>riid</c>.</description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>ppvAdapterList</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Even if no adapters are found, as long as the arguments are valid, <b>CreateAdapterList</b> creates a valid
		/// <c>IDXCoreAdapterList</c> object, and returns <b>S_OK</b>. Once generated, the adapters in this specific list won't change. But
		/// the list will be considered stale if one of the adapters later becomes invalid, or if a new adapter arrives that meets the
		/// provided filter criteria. The list returned by <b>CreateAdapterList</b> is not ordered in any particular way, but the ordering
		/// of a list is consistent across multiple calls, and even across operating system restarts. The ordering may change upon system
		/// configuration changes, including the addition or removal of an adapter, or a driver update on an existing adapter. You can
		/// register for these changes with <c>IDXCoreAdapterFactory::RegisterEventNotification</c> using the notification type <b>DXCoreNotificationType.AdapterListStale</b>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterfactory-createadapterlist
		// virtual HRESULT STDMETHODCALLTYPE CreateAdapterList( uint32_t numAttributes, _In_reads_(numAttributes) const GUID
		// *filterAttributes, REFIID riid, _COM_Outptr_ void **ppvAdapterList) = 0; template&lt;class T&gt; HRESULT STDMETHODCALLTYPE
		// CreateAdapterList( uint32_t numAttributes, _In_reads_(numAttributes) const GUID *filterAttributes, _COM_Outptr_ T **ppvAdapterList);
		[PreserveSig]
		new HRESULT CreateAdapterList(int numAttributes, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Guid[] filterAttributes,
			in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object? ppvAdapterList);

		/// <summary>
		/// Retrieves the DXCore adapter object ( <c>IDXCoreAdapter</c>) for a specified LUID, if available. For programming guidance, and
		/// code examples, see <c>Using DXCore to enumerate adapters</c>.
		/// </summary>
		/// <param name="adapterLUID">The locally unique value that identifies the adapter instance.</param>
		/// <param name="riid">
		/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in ppvAdapter. This is
		/// expected to be the interface identifier (IID) of IDXCoreAdapter.
		/// </param>
		/// <param name="ppvAdapter">
		/// The address of a pointer to an interface with the IID specified in the riid parameter. Upon successful return, *ppvAdapter (the
		/// dereferenced address) contains a pointer to the DXCore adapter created.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_DEVICE_REMOVED</description>
		/// <description>The adapter LUID passed in <c>adapterLUID</c> is recognized, but the adapter is no longer in a valid state.</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>No such adapter LUID as the value passed in <c>adapterLUID</c> is available through DXCore.</description>
		/// </item>
		/// <item>
		/// <description>E_NOINTERFACE</description>
		/// <description>An invalid value was provided for <c>riid</c>.</description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>ppvAdapter</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Multiple calls passing the same <c>LUID</c> return identical interface pointers. As a result, it's safe to compare interface
		/// pointers to determine whether multiple pointers refer to the same adapter object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterfactory-getadapterbyluid
		// virtual HRESULT STDMETHODCALLTYPE GetAdapterByLuid( const LUID &amp;adapterLUID, REFIID riid, _COM_Outptr_ void **ppvAdapter) =
		// 0; template&lt;class T&gt; HRESULT STDMETHODCALLTYPE GetAdapterByLuid( const LUID &amp;adapterLUID, _COM_Outptr_ T **ppvAdapter);
		[PreserveSig]
		new HRESULT GetAdapterByLuid(in LUID adapterLUID, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvAdapter);

		/// <summary>
		/// Determines whether a specified notification type is supported by the operating system (OS). For programming guidance, and code
		/// examples, see <c>Using DXCore to enumerate adapters</c>.
		/// </summary>
		/// <param name="notificationType">
		/// The type of notification that you're querying about support for. See the table in DXCoreNotificationType for info about the
		/// notification types.
		/// </param>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns  <c>true</c> if the notification type is supported by the system. Otherwise, returns  <c>false</c>.</para>
		/// </returns>
		/// <remarks>
		/// You can call <b>IsNotificationTypeSupported</b> to determine whether a given notification type is known to this version of the
		/// OS. For example, a notification type that's introduced in a particular version of Windows is unknown to previous versions of Windows.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterfactory-isnotificationtypesupported
		// virtual bool STDMETHODCALLTYPE IsNotificationTypeSupported( DXCoreNotificationType notificationType) = 0;
		[PreserveSig]
		new bool IsNotificationTypeSupported(DXCoreNotificationType notificationType);

		/// <summary>
		/// Registers to receive notifications of specific conditions from a DXCore adapter or adapter list. For programming guidance, and
		/// code examples, see <c>Using DXCore to enumerate adapters</c>.
		/// </summary>
		/// <param name="dxCoreObject">
		/// The DXCore object (IDXCoreAdapter or IDXCoreAdapterList) whose notifications you're subscribing to.
		/// </param>
		/// <param name="notificationType">
		/// The type of notification that you're registering for. See the table in DXCoreNotificationType for info about what types are
		/// valid with which kinds of objects.
		/// </param>
		/// <param name="callbackFunction">
		/// A pointer to a callback function (implemented by your application), which is called by the DXCore object for notification
		/// events. For the signature of the function, see PFN_DXCORE_NOTIFICATION_CALLBACK.
		/// </param>
		/// <param name="callbackContext">
		/// An optional pointer to an object containing context info. This object is passed to your callback function when the notification
		/// is raised.
		/// </param>
		/// <param name="eventCookie">
		/// A pointer to a uint32_t value. If successful, the function dereferences the pointer and sets the value to a non-zero cookie
		/// value representing this registration. Use this cookie value to unregister from the notification by calling
		/// IDXCoreAdapterFactory::UnregisterEventNotification. See Remarks.
		/// <para>
		/// If unsuccessful, the function dereferences the pointer and sets the value to zero, which represents an invalid cookie value.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL</description>
		/// <description><c>notificationType</c> is unsupported by the operating system (OS).</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>dxCoreObject</c>, or if an invalid <c>notificationType</c> and <c>dxCoreObject</c> combination was provided.
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for either <c>callbackFunction</c> or <c>eventCookie</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You use <b>RegisterEventNotification</b> to register for events raised by <c>IDXCoreAdapterList</c> and <c>IDXCoreAdapter</c>
		/// interfaces. These notification types are supported.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>DXCoreNotificationType</c></description>
		/// <description>Supported <c>dxCoreObject</c></description>
		/// <description>Notes</description>
		/// </listheader>
		/// <item>
		/// <description>AdapterListStale</description>
		/// <description><b>IDXCoreAdapterList</b></description>
		/// <description>
		/// Indicates that the list of adapters meeting your filter criteria has changed. If the adapter list is stale at the time of
		/// registration, then your callback is immediately called. This callback occurs at most one time per registration.
		/// </description>
		/// </item>
		/// <item>
		/// <description>AdapterNoLongerValid</description>
		/// <description><b>IDXCoreAdapter</b></description>
		/// <description>
		/// Indicates that the adapter is no longer valid. If the adapter is invalid at registration time, then your callback is immediately called.
		/// </description>
		/// </item>
		/// <item>
		/// <description>AdapterBudgetChange</description>
		/// <description><b>IDXCoreAdapter</b></description>
		/// <description>
		/// Indicates that a memory budgeting event has occurred, and that you should call <c>IDXCoreAdapter::QueryState</c> (with
		/// <c>DXCoreAdapterState::AdapterMemoryBudget</c>) to evaluate the current memory budget state. Upon registration, an initial
		/// callback will always occur to allow you to query the initial state.
		/// </description>
		/// </item>
		/// <item>
		/// <description>AdapterHardwareContentProtectionTeardown</description>
		/// <description><b>IDXCoreAdapter</b></description>
		/// <description>
		/// Indicates that you should re-evaluate the current crypto session status; for example, by calling
		/// <c>ID3D11VideoContext1::CheckCryptoSessionStatus</c> to determine the impact of the hardware teardown for a specific
		/// <c>ID3D11CryptoSession</c> interface. Upon registration, an initial callback will always occur to allow you to query the initial state.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// A call to the function that you provide in callbackFunction is made asynchronously on a background thread by DXCore when the
		/// detected event occurs. No guarantee is made as to the ordering or timing of callbacks—multiple callbacks may occur in any order,
		/// or even simultaneously. It's even possible for your callback to be invoked before <b>RegisterEventNotification</b> has
		/// completed. In that case, DXCore guarantees that your eventCookie is set before your callback is called. Multiple callbacks for a
		/// specific registration will be serialized in order.
		/// </para>
		/// <para>
		/// Callbacks may occur at any time until you call <c>UnregisterEventNotification</c>, and it completes. Callbacks occur on their
		/// own threads, and you may make calls into the DXCore API on those threads, including <b>UnregisterEventNotification</b>. However,
		/// you must not release the last reference to the dxCoreObject on this thread.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Before you destroy the DXCore object represented by the dxCoreObject argument passed to <b>RegisterEventNotification</b>, you
		/// must use the cookie value to unregister that object from notifications by calling
		/// <c>IDXCoreAdapterFactory::UnregisterEventNotification</c>. If you don't do that, then a fatal exception is raised when the
		/// situation is detected.
		/// </para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterfactory-registereventnotification
		// virtual HRESULT STDMETHODCALLTYPE RegisterEventNotification( _In_ IUnknown *dxCoreObject, DXCoreNotificationType
		// notificationType, _In_ PFN_DXCORE_NOTIFICATION_CALLBACK callbackFunction, _In_opt_ void *callbackContext, _Out_ uint32_t
		// *eventCookie) = 0;
		[PreserveSig]
		new HRESULT RegisterEventNotification([In, MarshalAs(UnmanagedType.IUnknown)] object dxCoreObject, DXCoreNotificationType notificationType,
			PFN_DXCORE_NOTIFICATION_CALLBACK callbackFunction, [In, Optional] IntPtr callbackContext, out uint eventCookie);

		/// <summary>
		/// Unregisters from a notification that you previously registered for. For programming guidance, and code examples, see <c>Using
		/// DXCore to enumerate adapters</c>.
		/// </summary>
		/// <param name="eventCookie">
		/// The cookie value (returned when you called IDXCoreAdapterFactory::RegisterEventNotification) representing a prior registration
		/// that you now wish to unregister for.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>The value of <c>eventCookie</c> is not a valid cookie representing a prior registration.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>UnregisterEventNotification</b> returns only after all pending/in-progress callbacks for this registration have completed.
		/// DXCore guarantees that no new callbacks will occur for this registration after <b>UnregisterEventNotification</b> has returned.
		/// However, to avoid a deadlock, if you call <b>UnregisterEventNotification</b> from within your callback, then
		/// <b>UnregisterEventNotification</b> doesn't wait for the active callback to complete.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Before you destroy the DXCore object represented by the dxCoreObject argument passed to
		/// <c>IDXCoreAdapterFactory::RegisterEventNotification</c>, you must use the cookie value to unregister that object from
		/// notifications by calling <b>UnregisterEventNotification</b>. If you don't do that, then a fatal exception is raised when the
		/// situation is detected.
		/// </para>
		/// </para>
		/// <para>Once you unregister a cookie value, that value is then eligible for being returned by a subsequent registration</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterfactory-unregistereventnotification
		// virtual HRESULT STDMETHODCALLTYPE UnregisterEventNotification( uint32_t eventCookie) = 0;
		[PreserveSig]
		new HRESULT UnregisterEventNotification(uint eventCookie);

		/// <summary>
		/// <para>
		/// Generates a list of adapter objects representing the current adapter state of the system, and meeting the workload and hardware
		/// type criteria specified. For programming guidance, and code examples, see <c>Using DXCore to enumerate adapters</c>. With
		/// <b>CreateAdapterListByWorkload</b>, DXCore supports neural processing units (NPUs), which process machine-learning (ML)
		/// workloads, and media accelerators, for video encode/decode/processing workloads.
		/// </para>
		/// <para>
		/// You can retrieve MCDM NPUs and media accelerators by calling <c>CreateAdapterList</c>, but the default sorting for that method
		/// is based on runtime capabilities and device performance. <b>CreateAdapterListByWorkload</b> allows DXCore to provide an adapter
		/// list sorted by what works best for a given workload, based on operating system (OS) policy, that you can easily narrow down by
		/// the type of hardware and level of Direct 3D runtime support. The default sorting in <b>CreateAdapterListByWorkload</b> can be
		/// thought of as the opposite of <b>CreateAdapterList</b>, where more specialized hardware is prioritized in the ordering that may
		/// be less generally capable than a full GPU.
		/// </para>
		/// </summary>
		/// <param name="workload">TBD</param>
		/// <param name="runtimeFilter">TBD</param>
		/// <param name="hardwareTypeFilter">TBD</param>
		/// <param name="riid">
		/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in ppvAdapterList. This is
		/// expected to be the interface identifier (IID) of IDXCoreAdapterList.
		/// </param>
		/// <param name="ppvAdapterList">
		/// The address of a pointer to an interface with the IID specified in the riid parameter. Upon successful return, *ppvAdapterList
		/// (the dereferenced address) contains a pointer to the adapter list created.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// A value was provided outside of the range of the <c>workload</c>, <c>runtimeFilter</c>, or <c>hardwareTypeFilter</c> parameters.
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_NOINTERFACE</description>
		/// <description>An invalid value was provided for <c>riid</c>.</description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>ppvAdapterList</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Even if no adapters are found, as long as the arguments are valid, <b>CreateAdapterListByWorkload</b> creates a valid
		/// <c>IDXCoreAdapterList</c> object, and returns <b>S_OK</b>. Once generated, the adapters in this specific list won't change. But
		/// the list will be considered stale if one of the adapters later becomes invalid, or if a new adapter arrives that meets the
		/// provided filter criteria. The list returned by <b>CreateAdapterList</b> is not ordered in any particular way, and multiple calls
		/// to <b>CreateAdapterList</b> may produce differently ordered lists.
		/// </para>
		/// <para>
		/// The resulting list is not ordered in any particular way, but the ordering of a list is consistent across multiple calls, and
		/// even across operating system restarts. The ordering may change upon system configuration changes, including the addition or
		/// removal of an adapter, or a driver update on an existing adapter.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterfactory1-createadapterlistbyworkload
		// virtual HRESULT STDMETHODCALLTYPE CreateAdapterListByWorkload( DXCoreWorkload workload, DXCoreRuntimeFilterFlags runtimeFilter,
		// DXCoreHardwareTypeFilterFlags hardwareTypeFilter, REFIID riid, _COM_Outptr_ void **ppvAdapterList) = 0; template&lt;class T&gt;
		// HRESULT STDMETHODCALLTYPE CreateAdapterListByWorkload( DXCoreWorkload workload, DXCoreRuntimeFilterFlags runtimeFilter,
		// DXCoreHardwareTypeFilterFlags hardwareTypeFilter, _COM_Outptr_ T **ppvAdapterList);
		[PreserveSig]
		HRESULT CreateAdapterListByWorkload(DXCoreWorkload workload, DXCoreRuntimeFilterFlags runtimeFilter,
			DXCoreHardwareTypeFilterFlags hardwareTypeFilter, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object? ppvAdapterList);
	}

	/// <summary>
	/// The  <b>IDXCoreAdapterList</b> interface implements methods for retrieving adapter items from a generated list, as well as details
	/// about the list. <b>IDXCoreAdapterList</b> inherits from the <c>IUnknown</c> interface. For programming guidance, and code examples,
	/// see <c>Using DXCore to enumerate adapters</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nn-dxcore_interface-idxcoreadapterlist
	[PInvokeData("dxcore_interface.h")]
	[ComImport, Guid("526c7776-40e9-459b-b711-f32ad76dfc28"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXCoreAdapterList
	{
		/// <summary>
		/// Retrieves a specific adapter by index from a DXCore adapter list object. For programming guidance, and code examples, see
		/// <c>Using DXCore to enumerate adapters</c>.
		/// </summary>
		/// <param name="index">A zero-based index, identifying an adapter instance within the DXCore adapter list.</param>
		/// <param name="riid">
		/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in ppvAdapter. This is
		/// expected to be the interface identifier (IID) of IDXCoreAdapter.
		/// </param>
		/// <param name="ppvAdapter">
		/// The address of a pointer to an interface with the IID specified in the riid parameter. Upon successful return, *ppvAdapter (the
		/// dereferenced address) contains a pointer to the DXCore adapter created.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_DEVICE_REMOVED</description>
		/// <description>The <c>index</c> is valid, but the adapter is no longer in a valid state.</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>The provided <c>index</c> is not valid.</description>
		/// </item>
		/// <item>
		/// <description>E_NOINTERFACE</description>
		/// <description>An invalid value was provided for <c>riid</c>.</description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>ppvAdapter</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Multiple calls passing an index that represents the same adapter return identical interface pointers, even across different
		/// adapter lists. As a result, it's safe to compare interface pointers to determine whether multiple pointers refer to the same
		/// adapter object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterlist-getadapter virtual
		// HRESULT STDMETHODCALLTYPE GetAdapter( uint32_t index, REFIID riid, _COM_Outptr_ void **ppvAdapter) = 0; template&lt;class T&gt;
		// HRESULT STDMETHODCALLTYPE GetAdapter( uint32_t index, _COM_Outptr_ T **ppvAdapter);
		[PreserveSig]
		HRESULT GetAdapter(uint index, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvAdapter);

		/// <summary>
		/// Retrieves the number of adapters in a DXCore adapter list object. For programming guidance, and code examples, see <c>Using
		/// DXCore to enumerate adapters</c>.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>uint32_t</b></para>
		/// <para>Returns the number of adapter items in the list.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterlist-getadaptercount
		// virtual uint32_t STDMETHODCALLTYPE GetAdapterCount() = 0;
		[PreserveSig]
		uint GetAdapterCount();

		/// <summary>
		/// Determines whether changes to this system have resulted in this DXCore adapter list object becoming out of date. For programming
		/// guidance, and code examples, see <c>Using DXCore to enumerate adapters</c>.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// Returns  <c>true</c> if, since generating the list, changes to system conditions have occurred that would cause this adapter
		/// list to become stale. Otherwise, returns  <c>false</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// You can poll <b>IsStale</b> to determine whether changing system conditions have led to this list becoming out of date. If
		/// <b>IsStale</b> returns <c>true</c> once, then it returns <c>true</c> for the remaining lifetime of the DXCore adapter list
		/// object. A stale list object is still considered stale even if system conditions return to a state that matches the list (the
		/// same conditions obtain now as did when the list was first generated).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterlist-isstale virtual
		// bool STDMETHODCALLTYPE IsStale() = 0;
		[PreserveSig]
		bool IsStale();

		/// <summary>
		/// Retrieves an <c>IDXCoreAdapterFactory</c> interface pointer to the DXCore adapter factory object. For programming guidance, and
		/// code examples, see <c>Using DXCore to enumerate adapters</c>.
		/// </summary>
		/// <param name="riid">
		/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in ppvFactory. This is
		/// expected to be the interface identifier (IID) of IDXCoreAdapterFactory.
		/// </param>
		/// <param name="ppvFactory">
		/// The address of a pointer to an interface with the IID specified in the riid parameter. Upon successful return, *ppvFactory (the
		/// dereferenced address) contains a pointer to the existing DXCore adapter factory object. Before returning, the function
		/// increments the reference count on the factory object's IDXCoreAdapterFactory interface.
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_NOINTERFACE</description>
		/// <description>An invalid value was provided for <c>riid</c>.</description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description>
		/// <code>nullptr</code>
		/// was provided for <c>ppvFactory</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// For the duration of time that a reference exists on an <c>IDXCoreAdapterFactory</c> interface, an <c>IDXCoreAdapterList</c>
		/// interface, or an <c>IDXCoreAdapter</c> interface, additional calls to <c>DXCoreCreateAdapterFactory</c>,
		/// <c>IDXCoreAdapterList::GetFactory</c>, or <c>IDXCoreAdapter::GetFactory</c> will return pointers to the same object, increasing
		/// the reference count of the <b>IDXCoreAdapterFactory</b> interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterlist-getfactory virtual
		// HRESULT STDMETHODCALLTYPE GetFactory( REFIID riid, _COM_Outptr_ void** ppvFactory) = 0; template &lt;class T&gt; HRESULT
		// GetFactory( _COM_Outptr_ T** ppvFactory);
		[PreserveSig]
		HRESULT GetFactory(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvFactory);

		/// <summary>
		/// Sorts a DXCore adapter list object based on a provided input array of sort criteria, where array items earlier in the array of
		/// criteria are given a higher weight. <b>Sort</b> helps you to more easily find your ideal adapter in an adapter list.
		/// </summary>
		/// <param name="numPreferences">The number of elements that are in the array pointed to by the preferences parameter.</param>
		/// <param name="preferences">A pointer to a constant array of DXCoreAdapterPreference values, representing sort criteria.</param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>The <c>numPreferences</c> argument is zero, or the <c>preferences</c> argument is
		/// <code>nullptr</code>
		/// .
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In cases where a provided <c>DXCoreAdapterPreference</c> value isn't recognized by the operating system (OS), it is ignored, and
		/// won't cause the API to fail. Known <b>DXCoreAdapterPreference</b> values will still be considered in this case. To determine
		/// whether a sort type is understood by the API, call <c>IDXCoreAdapterList::IsAdapterPreferenceSupported</c>.
		/// </para>
		/// <para><b>DXCoreAdapterPreference</b> values that occur earlier in the provided preferences array are treated with higher priority.</para>
		/// <para>
		/// Refer to the <b>DXCoreAdapterPreference</b> enumeration documentation for details about what logic is applied for each type. The
		/// internal logic for a type may develop as the OS develops.
		/// </para>
		/// <para>
		/// When <b>Sort</b> returns, items in the DXCore adapter list will have been sorted from most preferable to least preferable. So,
		/// calling <c>IDXCoreAdapterList::GetAdapter</c> with index 0 retrieves the adapter that best matches the requested sort preference
		/// types; index 1 is the next best match, and so on.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterlist-sort HRESULT Sort(
		// uint32_t numPreferences, _In_reads_(numPreferences) const DXCoreAdapterPreference* preferences );
		[PreserveSig]
		HRESULT Sort(int numPreferences, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DXCoreAdapterPreference[] preferences);

		/// <summary>
		/// Determines whether a specified <c>DXCoreAdapterPreference</c> value is understood by the current operating system (OS). You can
		/// call <b>IsAdapterPreferenceSupported</b> before calling <c>IDXCoreAdapterList::Sort</c>.
		/// </summary>
		/// <param name="preference">A DXCoreAdapterPreference value that will be checked to see whether it's supported by the OS.</param>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns <c>true</c> if the sort type is understood by the current OS. Otherwise, returns <c>false</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/dxcore/dxcore_interface/nf-dxcore_interface-idxcoreadapterlist-isadapterpreferencesupported
		// bool IsAdapterPreferenceSupported( DXCoreAdapterPreference preference );
		[PreserveSig]
		bool IsAdapterPreferenceSupported(DXCoreAdapterPreference preference);
	}

	/// <summary>
	/// Generates a list of adapter objects representing the current adapter state of the system, and meeting the criteria specified. For
	/// programming guidance, and code examples, see <c>Using DXCore to enumerate adapters</c>.
	/// </summary>
	/// <typeparam name="T">The type of the interface that you wish to be returned in ppvAdapterList. This is expected to be IDXCoreAdapterList.</typeparam>
	/// <param name="factory">The <see cref="IDXCoreAdapterFactory"/> instance.</param>
	/// <param name="filterAttributes">
	/// An array of adapter attribute GUIDs. For a list of attribute GUIDs, see DXCore adapter attribute GUIDs. At least one GUID must be
	/// provided. In the case that more than one GUID is provided in the array, only adapters that meet all of the requested attributes will
	/// be included in the returned list.
	/// </param>
	/// <param name="ppvAdapterList">
	/// The address of a pointer to an interface with the IID specified in the riid parameter. Upon successful return, *ppvAdapterList (the
	/// dereferenced address) contains a pointer to the adapter list created.
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return value</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>E_INVALIDARG</description>
	/// <description>
	/// <code>nullptr</code>
	/// was provided for <c>filterAttributes</c>, or 0 was provided for <c>numAttributes</c>.
	/// </description>
	/// </item>
	/// <item>
	/// <description>E_NOINTERFACE</description>
	/// <description>An invalid value was provided for <c>riid</c>.</description>
	/// </item>
	/// <item>
	/// <description>E_POINTER</description>
	/// <description>
	/// <code>nullptr</code>
	/// was provided for <c>ppvAdapterList</c>.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Even if no adapters are found, as long as the arguments are valid, <b>CreateAdapterList</b> creates a valid
	/// <c>IDXCoreAdapterList</c> object, and returns <b>S_OK</b>. Once generated, the adapters in this specific list won't change. But the
	/// list will be considered stale if one of the adapters later becomes invalid, or if a new adapter arrives that meets the provided
	/// filter criteria. The list returned by <b>CreateAdapterList</b> is not ordered in any particular way, but the ordering of a list is
	/// consistent across multiple calls, and even across operating system restarts. The ordering may change upon system configuration
	/// changes, including the addition or removal of an adapter, or a driver update on an existing adapter. You can register for these
	/// changes with <c>IDXCoreAdapterFactory::RegisterEventNotification</c> using the notification type <b>DXCoreNotificationType.AdapterListStale</b>.
	/// </remarks>
	public static HRESULT CreateAdapterList<T>(this IDXCoreAdapterFactory factory, Guid[] filterAttributes, out T? ppvAdapterList) where T : class
	{
		var hr = factory.CreateAdapterList(filterAttributes.Length, filterAttributes, typeof(T).GUID, out var ppv);
		ppvAdapterList = (T?)ppv;
		return hr;
	}

	/// <summary>
	/// Creates a DXCore adapter factory, which you can use to generate further DXCore objects. For programming guidance, and code examples,
	/// see Using DXCore to enumerate adapters.
	/// </summary>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>
	/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in ppvFactory. This is expected
	/// to be the interface identifier (IID) of IDXCoreAdapterFactory.
	/// </para>
	/// </param>
	/// <param name="ppvFactory">
	/// <para>Type: <c>void**</c></para>
	/// <para>
	/// The address of a pointer to an interface with the IID specified in the riid parameter. Upon successful return, *ppvFactory (the
	/// dereferenced address) contains a pointer to the DXCore factory created.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return value</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>E_NOINTERFACE</description>
	/// <description>An invalid value was provided for <c>riid</c>.</description>
	/// </item>
	/// <item>
	/// <description>E_POINTER</description>
	/// <description>
	/// <code>nullptr</code>
	/// was provided for <c>ppvFactory</c>.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// For the duration of time that a reference exists on an IDXCoreAdapterFactory interface, an IDXCoreAdapterList interface, or an
	/// IDXCoreAdapter interface, additional calls to <c>DXCoreCreateAdapterFactory</c>, IDXCoreAdapterList::GetFactory, or
	/// IDXCoreAdapter::GetFactory will return pointers to the same object, increasing the reference count of the
	/// <c>IDXCoreAdapterFactory</c> interface.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore/nf-dxcore-dxcorecreateadapterfactory HRESULT DXCoreCreateAdapterFactory(
	// REFIID riid, [out] void **ppvFactory );
	[PInvokeData("dxcore.h", MSDNShortId = "NF:dxcore.DXCoreCreateAdapterFactory")]
	[DllImport(Lib_dxcore, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT DXCoreCreateAdapterFactory(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object? ppvFactory);

	/// <summary>
	/// Retrieves the value of the specified adapter property. Before calling <b>GetProperty</b> for a property type, call
	/// <c>IsPropertySupported</c> to confirm that the property type is available for this adapter and operating system (OS). Also before
	/// calling <b>GetProperty</b>, call <c>GetPropertySize</c> to determine the necessary size of the buffer in which to receive the
	/// property value.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="propertyData"/>.</typeparam>
	/// <param name="adp">The <see cref="IDXCoreAdapter"/> instance.</param>
	/// <param name="property">
	/// The type of the property whose value you wish to retrieve. See the table in DXCoreAdapterProperty for more info about each adapter property.
	/// </param>
	/// <param name="propertyData">
	/// A pointer to an output buffer that you allocate in your application, and that the function fills in. Call GetPropertySize to
	/// determine the size that the propertyData buffer should be for a given adapter property.
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return value</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>DXGI_ERROR_INVALID_CALL</description>
	/// <description>
	/// The property type specified in <c>property</c> is not recognized by this operating system (OS). Call <c>IsPropertySupported</c> to
	/// confirm that the property type is available for this adapter and operating system (OS).
	/// </description>
	/// </item>
	/// <item>
	/// <description>DXGI_ERROR_UNSUPPORTED</description>
	/// <description>
	/// The property type specified in <c>property</c> is not supported by the adapter. Call <c>IsPropertySupported</c> to confirm that the
	/// property type is available for this adapter and operating system (OS).
	/// </description>
	/// </item>
	/// <item>
	/// <description>E_INVALIDARG</description>
	/// <description>
	/// An insufficient buffer size is provided in <c>propertyData</c>. Call <c>GetPropertySize</c> to determine the size that the
	/// <c>propertyData</c> buffer should be for a given adapter property.
	/// </description>
	/// </item>
	/// <item>
	/// <description>E_POINTER</description>
	/// <description>
	/// <code>nullptr</code>
	/// was provided for <c>propertyData</c>.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You can call <b>GetProperty</b> on an adapter that's no longer valid—the function won't fail as a result of that. This function
	/// zeros out the propertyData buffer prior to filling it in.
	/// </remarks>
	public static HRESULT GetProperty<T>(this IDXCoreAdapter adp, DXCoreAdapterProperty property, out T propertyData) where T : struct
	{
		using SafeCoTaskMemStruct<T> mem = new();
		var hr = adp.GetProperty(property, (uint)mem.Size, mem);
		propertyData = mem.Value;
		return hr;
	}

	/// <summary>TBD</summary>
	/// <typeparam name="TIn">The type of <paramref name="inputPropertyDetails"/>.</typeparam>
	/// <typeparam name="TOut">The type of <paramref name="outputBuffer"/>.</typeparam>
	/// <param name="adp">The <see cref="IDXCoreAdapter1"/> instance.</param>
	/// <param name="property">TBD</param>
	/// <param name="inputPropertyDetails">TBD</param>
	/// <param name="outputBuffer">TBD</param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
	/// </returns>
	public static HRESULT GetPropertyWithInput<TIn, TOut>(this IDXCoreAdapter1 adp, DXCoreAdapterProperty property, TIn? inputPropertyDetails,
		out TOut outputBuffer)
		where TIn : struct where TOut : struct
	{
		using SafeCoTaskMemStruct<TIn> tin = inputPropertyDetails;
		using SafeCoTaskMemStruct<TOut> tout = new();
		var hr = adp.GetPropertyWithInput(property, tin.Size, tin, tout.Size, tout);
		outputBuffer = tout.Value;
		return hr;
	}

	/// <summary>
	/// Retrieves the current state of the specified item on the adapter. Before calling <b>QueryState</b> for a property type, call
	/// <c>IsQueryStateSupported</c> to confirm that querying the state kind is available for this adapter and operating system (OS).
	/// </summary>
	/// <typeparam name="TIn">The type of <paramref name="inputStateDetails"/>.</typeparam>
	/// <typeparam name="TOut">The type of <paramref name="outputBuffer"/>.</typeparam>
	/// <param name="adp">The <see cref="IDXCoreAdapter"/> instance.</param>
	/// <param name="state">
	/// The kind of state item on the adapter whose state you wish to retrieve. See the table in DXCoreAdapterState for more info about each
	/// adapter state kind.
	/// </param>
	/// <param name="inputStateDetails">
	/// An optional pointer to a constant input state details buffer that you allocate in your application, containing any information about
	/// your request that's required for the state kind you specify in state. See the table in DXCoreAdapterState for more info about any
	/// input buffer requirement for a given state kind.
	/// </param>
	/// <param name="outputBuffer">
	/// A pointer to an output buffer that you allocate in your application, and that the function fills in. See the table in
	/// DXCoreAdapterState for more info about the output buffer requirement for a given state kind.
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return value</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>DXGI_ERROR_DEVICE_REMOVED</description>
	/// <description>The adapter is no longer in a valid state.</description>
	/// </item>
	/// <item>
	/// <description>DXGI_ERROR_INVALID_CALL</description>
	/// <description>
	/// The state kind specified in <c>state</c> is not recognized by this operating system (OS). Call <c>IsQueryStateSupported</c> to
	/// confirm that querying the state kind is available for this adapter and operating system (OS).
	/// </description>
	/// </item>
	/// <item>
	/// <description>DXGI_ERROR_UNSUPPORTED</description>
	/// <description>
	/// The state kind specified in <c>state</c> is not supported by the adapter. Call <c>IsQueryStateSupported</c> to confirm that querying
	/// the state kind is available for this adapter and operating system (OS).
	/// </description>
	/// </item>
	/// <item>
	/// <description>E_INVALIDARG</description>
	/// <description>
	/// An insufficient buffer size is provided for <c>outputBuffer</c> (or for <c>inputStateDetails</c> where an input state details buffer
	/// is necessary).
	/// </description>
	/// </item>
	/// <item>
	/// <description>E_POINTER</description>
	/// <description>
	/// <code>nullptr</code>
	/// was provided for <c>outputBuffer</c> (or for <c>inputStateDetails</c> where an input state details buffer is necessary).
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// See <c>DXCoreAdapterState</c> for more info about each adapter state kind, and what inputs and outputs are used. This function zeros
	/// out the outputBuffer buffer prior to filling it in.
	/// </remarks>
	public static HRESULT QueryState<TIn, TOut>(this IDXCoreAdapter adp, DXCoreAdapterState state, in TIn inputStateDetails, out TOut outputBuffer)
		where TIn : struct where TOut : struct
	{
		using SafeCoTaskMemStruct<TIn> tin = inputStateDetails;
		using SafeCoTaskMemStruct<TOut> tout = new();
		var hr = adp.QueryState(state, tin.Size, tin, tout.Size, tout);
		outputBuffer = tout.Value;
		return hr;
	}

	/// <summary>
	/// Retrieves the current state of the specified item on the adapter. Before calling <b>QueryState</b> for a property type, call
	/// <c>IsQueryStateSupported</c> to confirm that querying the state kind is available for this adapter and operating system (OS).
	/// </summary>
	/// <typeparam name="TOut">The type of <paramref name="outputBuffer"/>.</typeparam>
	/// <param name="adp">The <see cref="IDXCoreAdapter"/> instance.</param>
	/// <param name="state">
	/// The kind of state item on the adapter whose state you wish to retrieve. See the table in DXCoreAdapterState for more info about each
	/// adapter state kind.
	/// </param>
	/// <param name="outputBuffer">
	/// A pointer to an output buffer that you allocate in your application, and that the function fills in. See the table in
	/// DXCoreAdapterState for more info about the output buffer requirement for a given state kind.
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return value</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>DXGI_ERROR_DEVICE_REMOVED</description>
	/// <description>The adapter is no longer in a valid state.</description>
	/// </item>
	/// <item>
	/// <description>DXGI_ERROR_INVALID_CALL</description>
	/// <description>
	/// The state kind specified in <c>state</c> is not recognized by this operating system (OS). Call <c>IsQueryStateSupported</c> to
	/// confirm that querying the state kind is available for this adapter and operating system (OS).
	/// </description>
	/// </item>
	/// <item>
	/// <description>DXGI_ERROR_UNSUPPORTED</description>
	/// <description>
	/// The state kind specified in <c>state</c> is not supported by the adapter. Call <c>IsQueryStateSupported</c> to confirm that querying
	/// the state kind is available for this adapter and operating system (OS).
	/// </description>
	/// </item>
	/// <item>
	/// <description>E_INVALIDARG</description>
	/// <description>
	/// An insufficient buffer size is provided for <c>outputBuffer</c> (or for <c>inputStateDetails</c> where an input state details buffer
	/// is necessary).
	/// </description>
	/// </item>
	/// <item>
	/// <description>E_POINTER</description>
	/// <description>
	/// <code>nullptr</code>
	/// was provided for <c>outputBuffer</c> (or for <c>inputStateDetails</c> where an input state details buffer is necessary).
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// See <c>DXCoreAdapterState</c> for more info about each adapter state kind, and what inputs and outputs are used. This function zeros
	/// out the outputBuffer buffer prior to filling it in.
	/// </remarks>
	public static HRESULT QueryState<TOut>(this IDXCoreAdapter adp, DXCoreAdapterState state, out TOut outputBuffer) where TOut : struct
	{
		SafeCoTaskMemStruct<TOut> tout = new();
		var hr = adp.QueryState(state, 0, default, tout.Size, tout);
		outputBuffer = tout.Value;
		return hr;
	}

	/// <summary>
	/// Sets the state of the specified item on the adapter. Before calling <b>SetState</b> for a property type, call
	/// <c>IsSetStateSupported</c> to confirm that setting the state kind is available for this adapter and operating system (OS).
	/// </summary>
	/// <typeparam name="T1">The type of <paramref name="inputStateDetails"/>.</typeparam>
	/// <typeparam name="T2">The type of <paramref name="inputData"/>.</typeparam>
	/// <param name="adp">The <see cref="IDXCoreAdapter"/> instance.</param>
	/// <param name="state">
	/// The kind of state item on the adapter whose state you wish to set. See the table in DXCoreAdapterState for more info about each
	/// adapter state kind.
	/// </param>
	/// <param name="inputStateDetails">
	/// An optional pointer to a constant input state details buffer that you allocate in your application, containing any information about
	/// your request that's required for the state kind you specify in state. See the table in DXCoreAdapterState for more info about any
	/// input buffer requirement for a given state kind.
	/// </param>
	/// <param name="inputData">
	/// A pointer to an input buffer that you allocate in your application, containing the state information to set for the state item whose
	/// kind you specify in state. See the table in DXCoreAdapterState for more info about the input buffer requirement for a given state kind.
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return value</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>DXGI_ERROR_DEVICE_REMOVED</description>
	/// <description>The adapter is no longer in a valid state.</description>
	/// </item>
	/// <item>
	/// <description>DXGI_ERROR_INVALID_CALL</description>
	/// <description>
	/// The state kind specified in <c>state</c> is not recognized by this operating system (OS). Call <c>IsSetStateSupported</c> to confirm
	/// that setting the state kind is available for this adapter and operating system (OS).
	/// </description>
	/// </item>
	/// <item>
	/// <description>DXGI_ERROR_UNSUPPORTED</description>
	/// <description>
	/// The state kind specified in <c>state</c> is not supported by the adapter. Call <c>IsSetStateSupported</c> to confirm that setting
	/// the state kind is available for this adapter and operating system (OS).
	/// </description>
	/// </item>
	/// <item>
	/// <description>E_INVALIDARG</description>
	/// <description>
	/// An insufficient buffer size is provided for <c>inputData</c> (or for <c>inputStateDetails</c> where an input state details buffer is necessary).
	/// </description>
	/// </item>
	/// <item>
	/// <description>E_POINTER</description>
	/// <description>
	/// <code>nullptr</code>
	/// was provided for <c>inputData</c> (or for <c>inputStateDetails</c> where an input state details buffer is necessary).
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	public static HRESULT SetState<T1, T2>(this IDXCoreAdapter adp, DXCoreAdapterState state, [Optional] T1? inputStateDetails, T2 inputData)
		where T1 : struct where T2 : struct
	{
		using SafeCoTaskMemStruct<T1> t1 = inputStateDetails;
		using SafeCoTaskMemStruct<T2> t2 = inputData;
		return adp.SetState(state, t1.Size, t1, t2.Size, t2);
	}

	/// <summary>Represents the physical adapter index and the engine ID.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcoreadapterengineindex struct
	// DXCoreAdapterEngineIndex { uint physicalAdapterIndex; uint engineIndex; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreAdapterEngineIndex")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreAdapterEngineIndex
	{
		/// <summary>The physical adapter index.</summary>
		public uint physicalAdapterIndex;

		/// <summary>The engine ID.</summary>
		public uint engineIndex;
	}

	/// <summary>Describes the memory budget for an adapter.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcoreadaptermemorybudget struct
	// DXCoreAdapterMemoryBudget { ulong budget; ulong currentUsage; ulong availableForReservation; ulong currentReservation; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreAdapterMemoryBudget")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreAdapterMemoryBudget
	{
		/// <summary>
		/// <para>Type: <c>ulong</c></para>
		/// <para>
		/// Specifies the OS-provided adapter memory budget, in bytes, that your application should target. If currentUsage is greater than
		/// budget, then your application may incur stuttering or performance penalties due to background activity by the OS, which is
		/// intended to provide other applications with a fair usage of adapter memory.
		/// </para>
		/// </summary>
		public ulong budget;

		/// <summary>
		/// <para>Type: <c>ulong</c></para>
		/// <para>Specifies your application's current adapter memory usage, in bytes.</para>
		/// </summary>
		public ulong currentUsage;

		/// <summary>
		/// <para>Type: <c>ulong</c></para>
		/// <para>
		/// Specifies the amount of adapter memory, in bytes, that your application has available for reservation. To reserve this adapter
		/// memory, your application should call IDXCoreAdapter::SetState with state set to DXCoreAdapterState::AdapterMemoryBudget.
		/// </para>
		/// </summary>
		public ulong availableForReservation;

		/// <summary>
		/// <para>Type: <c>ulong</c></para>
		/// <para>
		/// Specifies the amount of adapter memory, in bytes, that is reserved by your application. The OS uses the reservation as a hint to
		/// determine your application's minimum working set. Your application should attempt to ensure that its adapter memory usage can be
		/// trimmed to meet this requirement.
		/// </para>
		/// </summary>
		public ulong currentReservation;
	}

	/// <summary>Describes a memory segment group for an adapter.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcoreadaptermemorybudgetnodesegmentgroup
	// struct DXCoreAdapterMemoryBudgetNodeSegmentGroup { uint nodeIndex; DXCoreSegmentGroup segmentGroup; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreAdapterMemoryBudgetNodeSegmentGroup")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreAdapterMemoryBudgetNodeSegmentGroup
	{
		/// <summary>
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Specifies the device's physical adapter for which the adapter memory information is queried. For single-adapter operation, set
		/// this to zero. If there are multiple adapter nodes, then set this to the index of the node (the device's physical adapter) for
		/// which you want to query for adapter memory information (see Multi-adapter).
		/// </para>
		/// </summary>
		public uint nodeIndex;

		/// <summary>
		/// <para>Type: <c>DXCoreSegmentGroup</c></para>
		/// <para>Specifies the adapter memory segment grouping that you want to query about.</para>
		/// </summary>
		public DXCoreSegmentGroup segmentGroup;
	}

	/// <summary>Represents an array of processes (PIDs) running on the adapter. Also see DXCoreAdapterProcessSetQueryOutput.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcoreadapterprocesssetqueryinput struct
	// DXCoreAdapterProcessSetQueryInput { uint arraySize; uint *processIds; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreAdapterProcessSetQueryInput")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreAdapterProcessSetQueryInput
	{
		/// <summary>The number of elements in processIds.</summary>
		public uint arraySize;

		/// <summary>An array which, on return, contains the IDs of the processes running on the adapter.</summary>
		public ArrayPointer<uint> processIds;
	}

	/// <summary>Represents the number of processes (PIDs) running on the adapter. Also see DXCoreAdapterProcessSetQueryInput.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcoreadapterprocesssetqueryoutput struct
	// DXCoreAdapterProcessSetQueryOutput { uint processesWritten; uint processesTotal; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreAdapterProcessSetQueryOutput")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreAdapterProcessSetQueryOutput
	{
		/// <summary>The number of PIDs actually written into the pre-allocated array in DXCoreAdapterProcessSetQueryInput::processIds.</summary>
		public uint processesWritten;

		/// <summary>The total number of PIDs available to write.</summary>
		public uint processesTotal;
	}

	/// <summary>For an engine name query, represents physical adapter index, and/or engine ID, and engine name.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcoreenginenamepropertyinput struct
	// DXCoreEngineNamePropertyInput { DXCoreAdapterEngineIndex adapterEngineIndex; uint engineNameLength; wchar_t *engineName; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreEngineNamePropertyInput")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreEngineNamePropertyInput
	{
		/// <summary>A DXCoreAdapterEngineIndex struct containing the physical adapter index and the engine ID.</summary>
		public DXCoreAdapterEngineIndex adapterEngineIndex;

		/// <summary>The number of characters in engineName.</summary>
		public uint engineNameLength;

		/// <summary>The engine name string.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string engineName;
	}

	/// <summary>Represents an engine name string length so that you can correctly allocate DXCoreEngineNamePropertyInput::engineName.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcoreenginenamepropertyoutput struct
	// DXCoreEngineNamePropertyOutput { uint engineNameLength; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreEngineNamePropertyOutput")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreEngineNamePropertyOutput
	{
		/// <summary>The engine name string length</summary>
		public uint engineNameLength;
	}

	/// <summary>For an engine query, represents physical adapter index, and/or engine ID, and/or process handle.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcoreenginequeryinput struct
	// DXCoreEngineQueryInput { DXCoreAdapterEngineIndex adapterEngineIndex; uint processId; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreEngineQueryInput")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreEngineQueryInput
	{
		/// <summary>A DXCoreAdapterEngineIndex struct containing the physical adapter index and the engine ID.</summary>
		public DXCoreAdapterEngineIndex adapterEngineIndex;

		/// <summary>A process ID.</summary>
		public uint processId;
	}

	/// <summary>For an engine query, represents running time and/or whether or not the query succeeded.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcoreenginequeryoutput struct
	// DXCoreEngineQueryOutput { ulong runningTime; bool processQuerySucceeded; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreEngineQueryOutput")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreEngineQueryOutput
	{
		/// <summary>The engine running time.</summary>
		public ulong runningTime;

		/// <summary>A Boolean value indicating whether or not the query succeeded.</summary>
		public bool processQuerySucceeded;
	}

	/// <summary>Represents the results of a query about the clock frequency of an engine.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcorefrequencyqueryoutput struct
	// DXCoreFrequencyQueryOutput { ulong frequency; ulong maxFrequency; ulong maxOverclockedFrequency; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreFrequencyQueryOutput")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreFrequencyQueryOutput
	{
		/// <summary>the clock frequency of an engine (in Hertz).</summary>
		public ulong frequency;

		/// <summary>the maximum frequency for an engine (in Hertz), without overclocking.</summary>
		public ulong maxFrequency;

		/// <summary>The maximum frequency for an engine (in Hertz), with overclocking.</summary>
		public ulong maxOverclockedFrequency;
	}

	/// <summary>Represents the PnP hardware ID parts for an adapter.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcorehardwareid struct DXCoreHardwareID {
	// uint vendorID; uint deviceID; uint subSysID; uint revision; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreHardwareID")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreHardwareID
	{
		/// <summary>
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// The PCI ID or ACPI ID of the adapter's hardware vendor. If this value is less than or equal to 0xFFFF, it is a PCI ID;
		/// otherwise, it is an ACPI ID.
		/// </para>
		/// </summary>
		public uint vendorID;

		/// <summary>
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// The PCI ID or ACPI ID of the adapter's hardware device. If <c>vendorID</c> is a PCI ID, it is also a PCI ID; otherwise, it is an
		/// ACPI ID.
		/// </para>
		/// </summary>
		public uint deviceID;

		/// <summary>
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// The PCI ID or ACPI ID of the adapter's hardware subsystem. If <c>vendorID</c> is a PCI ID, it is also a PCI ID; otherwise, it is
		/// an ACPI ID.
		/// </para>
		/// </summary>
		public uint subSysID;

		/// <summary>
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// The adapter's PCI or ACPI revision number. If <c>vendorID</c> is a PCI ID, it is a PCI device revision number; otherwise, it is
		/// an ACPI device revision number.
		/// </para>
		/// </summary>
		public uint revision;
	}

	/// <summary>TBD</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcorehardwareidparts struct
	// DXCoreHardwareIDParts { uint vendorID; uint deviceID; uint subSystemID; uint subVendorID; uint revisionID; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreHardwareIDParts")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreHardwareIDParts
	{
		/// <summary>TBD</summary>
		public uint vendorID;

		/// <summary>TBD</summary>
		public uint deviceID;

		/// <summary>TBD</summary>
		public uint subSystemID;

		/// <summary>TBD</summary>
		public uint subVendorID;

		/// <summary/>
		public uint revisionID;
	}

	/// <summary>For a memory query, represents physical adapter index and memory type (dedicated or shared).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcorememoryqueryinput struct
	// DXCoreMemoryQueryInput { uint physicalAdapterIndex; DXCoreMemoryType memoryType; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreMemoryQueryInput")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreMemoryQueryInput
	{
		/// <summary>A physical adapter index.</summary>
		public uint physicalAdapterIndex;

		/// <summary>A DXCoreMemoryType struct indicating a memory type (dedicated or shared).</summary>
		public DXCoreMemoryType memoryType;
	}

	/// <summary>For a memory query, represents the returned values of committed memory and resident memory on the specified memory segments.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcorememoryusage struct DXCoreMemoryUsage {
	// ulong committed; ulong resident; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreMemoryUsage")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreMemoryUsage
	{
		/// <summary>The committed memory.</summary>
		public ulong committed;

		/// <summary>The resident memory.</summary>
		public ulong resident;
	}

	/// <summary>For a memory query, represents physical adapter index, and memory type (dedicated or shared), and process ID.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcoreprocessmemoryqueryinput struct
	// DXCoreProcessMemoryQueryInput { uint physicalAdapterIndex; DXCoreMemoryType memoryType; uint processId; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreProcessMemoryQueryInput")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreProcessMemoryQueryInput
	{
		/// <summary>A physical adapter index.</summary>
		public uint physicalAdapterIndex;

		/// <summary>A DXCoreMemoryType struct indicating a memory type (dedicated or shared).</summary>
		public DXCoreMemoryType memoryType;

		/// <summary>A process ID.</summary>
		public uint processId;
	}

	/// <summary>For a process memory query, represents process memory usage and/or whether or not the query succeeded.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcore_interface/ns-dxcore_interface-dxcoreprocessmemoryqueryoutput struct
	// DXCoreProcessMemoryQueryOutput { DXCoreMemoryUsage memoryUsage; bool processQuerySucceeded; };
	[PInvokeData("dxcore_interface.h", MSDNShortId = "NS:dxcore_interface.DXCoreProcessMemoryQueryOutput")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXCoreProcessMemoryQueryOutput
	{
		/// <summary>Process memory usage.</summary>
		public DXCoreMemoryUsage memoryUsage;

		/// <summary>A Boolean value indicating whether or not the query succeeded.</summary>
		public bool processQuerySucceeded;
	}
}