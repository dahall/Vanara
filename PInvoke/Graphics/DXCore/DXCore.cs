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
		[MarshalAs(UnmanagedType.IUnknown)] object? @object, [In] IntPtr context);

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
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>Specifies the InstanceLuid adapter property, which contains a locally unique identifier representing the adapter. This value remains constant for the
		/// lifetime of this adapter. The LUID of an adapter changes on reboot, driver upgrade, or device disablement/enablement.
		/// </para>
		///   <para>The InstanceLuid adapter property has type LUID.</para>
		/// </summary>
		InstanceLuid,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>Specifies the DriverVersion adapter property, which contains the driver version, represented in WORDs as a LARGE_INTEGER.</para>
		///   <para>The DriverVersion adapter property has type ulong, representing a Boolean value.</para>
		/// </summary>
		DriverVersion,

		/// <summary>
		///   <para>Value:</para>
		///   <para>2</para>
		///   <para>Specifies the DriverDescription adapter property, which contains a NULL-terminated array of CHARs describing the driver, as specified by the driver, in UTF-8 encoding.</para>
		///   <para>The DriverDescription adapter property has type char*.</para>
		/// </summary>
		DriverDescription,

		/// <summary>
		///   <para>Value:</para>
		///   <para>3</para>
		///   <para>Specifies the HardwareID adapter property, which represents the PnP hardware ID parts. But use HardwareIDParts instead, if available.</para>
		///   <para>The HardwareID adapter property has type DXCoreHardwareID.</para>
		/// </summary>
		HardwareID,

		/// <summary>
		///   <para>Value:</para>
		///   <para>4</para>
		///   <para>Specifies the KmdModelVersion adapter property, which represents the driver model.</para>
		///   <para>The KmdModelVersion adapter property has type D3DKMT_DRIVERVERSION.</para>
		/// </summary>
		KmdModelVersion,

		/// <summary>
		///   <para>Value:</para>
		///   <para>5</para>
		///   <para>Specifies the ComputePreemptionGranularity adapter property, which represents the compute preemption granularity.</para>
		///   <para>The ComputePreemptionGranularity adapter property has type uint16_t , representing a D3DKMDT_COMPUTE_PREEMPTION_GRANULARITY value.</para>
		/// </summary>
		ComputePreemptionGranularity,

		/// <summary>
		///   <para>Value:</para>
		///   <para>6</para>
		///   <para>Specifies the GraphicsPreemptionGranularity adapter property, which represents the graphics preemption granularity.</para>
		///   <para>The GraphicsPreemptionGranularity adapter property has type uint16_t , representing a D3DKMDT_GRAPHICS_PREEMPTION_GRANULARITY value.</para>
		/// </summary>
		GraphicsPreemptionGranularity,

		/// <summary>
		///   <para>Value:</para>
		///   <para>7</para>
		///   <para>Specifies the DedicatedAdapterMemory adapter property, which represents the number of bytes of dedicated adapter memory that are not shared with the CPU.</para>
		///   <para>The DedicatedVideoMemory adapter property has type ulong.</para>
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
		///   <para>Value:</para>
		///   <para>9</para>
		///   <para>Specifies the SharedSystemMemory adapter property, which represents the number of bytes of shared system memory. This is the maximum value of system memory that
		/// may be consumed by the adapter during operation. Any incidental memory consumed by the driver as it manages and uses video
		/// memory is additional.
		/// </para>
		///   <para>The SharedSystemMemory adapter property has type ulong.</para>
		/// </summary>
		SharedSystemMemory,

		/// <summary>
		///   <para>Value:</para>
		///   <para>10</para>
		///   <para>Specifies the AcgCompatible adapter property, which indicates whether the adapter is compatible with processes that enforce Arbitrary Code Guard.</para>
		///   <para>The AcgCompatible adapter property has type bool.</para>
		/// </summary>
		AcgCompatible,

		/// <summary>
		///   <para>Value:</para>
		///   <para>11</para>
		///   <para>Specifies the IsHardware adapter property, which determines whether or not this is a hardware adapter. An adapter that's not a hardware adapter is a
		/// software adapter.
		/// </para>
		///   <para>The IsHardware adapter property has type bool.</para>
		/// </summary>
		IsHardware,

		/// <summary>
		///   <para>Value:</para>
		///   <para>12</para>
		///   <para>Specifies the IsIntegrated adapter property, which determines whether the adapter is reported to be an integrated graphics processor (iGPU).</para>
		///   <para>The IsIntegrated adapter property has type bool.</para>
		/// </summary>
		IsIntegrated,

		/// <summary>
		///   <para>Value:</para>
		///   <para>13</para>
		///   <para>Specifies the IsDetachable adapter property, which determines whether the adapter has been reported to be detachable, or removable.</para>
		///   <para>The IsDetachable adapter property has type bool.</para>
		///   <para>Note. Even if IDXCoreAdapter::GetProperty indicates false for this property, the adapter still has the ability to be reported as removed, such as in the case of malfunction, or driver update.
		/// </para>
		/// </summary>
		IsDetachable,

		/// <summary>
		///   <para>Value:</para>
		///   <para>14</para>
		///   <para>Specifies the HardwareIDParts adapter property, which represents the PnP hardware ID parts.</para>
		///   <para>The HardwareIDParts adapter property has type DXCoreHardwareID.</para>
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
	public static extern HRESULT DXCoreCreateAdapterFactory(in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object? ppvFactory);

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