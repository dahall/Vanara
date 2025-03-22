using System.Collections.Generic;

namespace Vanara.PInvoke;

public static partial class DXGI
{
	/// <summary>Identifies the type of DXGI adapter.</summary>
	/// <remarks>
	/// The <c>DXGI_ADAPTER_FLAG3</c> enumerated type is used by the <c>Flags</c> member of the DXGI_ADAPTER_DESC3 structure to ientify the
	/// type of DXGI adapter.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/ne-dxgi1_6-dxgi_adapter_flag3 typedef enum DXGI_ADAPTER_FLAG3 {
	// DXGI_ADAPTER_FLAG3_NONE = 0, DXGI_ADAPTER_FLAG3_REMOTE = 1, DXGI_ADAPTER_FLAG3_SOFTWARE = 2, DXGI_ADAPTER_FLAG3_ACG_COMPATIBLE = 4,
	// DXGI_ADAPTER_FLAG3_SUPPORT_MONITORED_FENCES = 8, DXGI_ADAPTER_FLAG3_SUPPORT_NON_MONITORED_FENCES = 0x10,
	// DXGI_ADAPTER_FLAG3_KEYED_MUTEX_CONFORMANCE = 0x20, DXGI_ADAPTER_FLAG3_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("dxgi1_6.h", MSDNShortId = "NE:dxgi1_6.DXGI_ADAPTER_FLAG3"), Flags]
	public enum DXGI_ADAPTER_FLAG3 : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies no flags.</para>
		/// </summary>
		DXGI_ADAPTER_FLAG3_NONE = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Value always set to 0. This flag is reserved.</para>
		/// </summary>
		DXGI_ADAPTER_FLAG3_REMOTE = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Specifies a software adapter. For more info about this flag, see</para>
		/// <para>new info in Windows 8 about enumerating adapters</para>
		/// <para>.</para>
		/// <para>Direct3D 11:  </para>
		/// <para>This enumeration value is supported starting with Windows 8.</para>
		/// </summary>
		DXGI_ADAPTER_FLAG3_SOFTWARE = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>
		/// Specifies that the adapter's driver has been confirmed to work in an OS process where Arbitrary Code Guard (ACG) is enabled
		/// (i.e. dynamic code generation is disallowed).
		/// </para>
		/// </summary>
		DXGI_ADAPTER_FLAG3_ACG_COMPATIBLE = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Specifies that the adapter supports monitored fences. These adapters support the</para>
		/// <para>ID3D12Device::CreateFence</para>
		/// <para>and</para>
		/// <para>ID3D11Device5::CreateFence</para>
		/// <para>functions.</para>
		/// </summary>
		DXGI_ADAPTER_FLAG3_SUPPORT_MONITORED_FENCES = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>Specifies that the adapter supports non-monitored fences. These adapters support the</para>
		/// <para>ID3D12Device::CreateFence</para>
		/// <para>function together with the</para>
		/// <para>D3D12_FENCE_FLAG_NON_MONITORED</para>
		/// <para>flag.</para>
		/// <para>
		/// <c>Note</c>  For adapters that support both monitored and non-monitored fences, non-monitored fences are only supported when
		/// created with the D3D12_FENCE_FLAG_SHARED and <c>D3D12_FENCE_FLAG_SHARED_CROSS_ADAPTER</c> flags. Monitored fences should always
		/// be used by supporting adapters unless communicating with an adapter that only supports non-monitored fences.
		/// </para>
		/// <para></para>
		/// </summary>
		DXGI_ADAPTER_FLAG3_SUPPORT_NON_MONITORED_FENCES = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>Specifies that the adapter claims keyed mutex conformance. This signals a stronger guarantee that the</para>
		/// <para>IDXGIKeyedMutex</para>
		/// <para>interface behaves correctly.</para>
		/// </summary>
		DXGI_ADAPTER_FLAG3_KEYED_MUTEX_CONFORMANCE = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xffffffff</para>
		/// <para>
		/// Forces this enumeration to compile to 32 bits in size. Without this value, some compilers would allow this enumeration to
		/// compile to a size other than 32 bits. This value is not used.
		/// </para>
		/// </summary>
		DXGI_ADAPTER_FLAG3_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>The preference of GPU for the app to run on.</summary>
	/// <remarks>This enumeration is used in the IDXGIFactory6::EnumAdapterByGpuPreference method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/ne-dxgi1_6-dxgi_gpu_preference typedef enum DXGI_GPU_PREFERENCE {
	// DXGI_GPU_PREFERENCE_UNSPECIFIED = 0, DXGI_GPU_PREFERENCE_MINIMUM_POWER, DXGI_GPU_PREFERENCE_HIGH_PERFORMANCE } ;
	[PInvokeData("dxgi1_6.h", MSDNShortId = "NE:dxgi1_6.DXGI_GPU_PREFERENCE")]
	public enum DXGI_GPU_PREFERENCE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>No preference of GPU.</para>
		/// </summary>
		DXGI_GPU_PREFERENCE_UNSPECIFIED,

		/// <summary>Preference for the minimum-powered GPU (such as an integrated graphics processor, or iGPU).</summary>
		DXGI_GPU_PREFERENCE_MINIMUM_POWER,

		/// <summary>
		/// Preference for the highest performing GPU, such as a discrete graphics processor (dGPU) or external graphics processor (xGPU).
		/// </summary>
		DXGI_GPU_PREFERENCE_HIGH_PERFORMANCE,
	}

	/// <summary>Describes which levels of hardware composition are supported.</summary>
	/// <remarks>
	/// Values of this enumeration are returned from the IDXGIOutput6::CheckHardwareCompositionSupport method in the <c>pFlags</c> out parameter.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/ne-dxgi1_6-dxgi_hardware_composition_support_flags typedef enum
	// DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAGS { DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAG_FULLSCREEN = 1,
	// DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAG_WINDOWED = 2, DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAG_CURSOR_STRETCHED = 4 } ;
	[PInvokeData("dxgi1_6.h", MSDNShortId = "NE:dxgi1_6.DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAGS"), Flags]
	public enum DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAGS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// This flag specifies that swapchain composition can be facilitated in a performant manner using hardware for fullscreen applications.
		/// </para>
		/// </summary>
		DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAG_FULLSCREEN = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>This flag specifies that swapchain composition can be facilitated in a performant manner using hardware for windowed applications.</para>
		/// </summary>
		DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAG_WINDOWED = 2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>This flag specifies that swapchain composition facilitated using hardware can cause the cursor to appear stretched.</para>
		/// </summary>
		DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAG_CURSOR_STRETCHED = 4,
	}

	/// <summary>
	/// This interface represents a display subsystem, and extends this family of interfaces to expose a method to check for an adapter's
	/// compatibility with Arbitrary Code Guard (ACG).
	/// </summary>
	/// <remarks>For more details, refer to the <c>Residency</c> section of the D3D12 documentation.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nn-dxgi1_6-idxgiadapter4
	[PInvokeData("dxgi1_6.h", MSDNShortId = "NN:dxgi1_6.IDXGIAdapter4")]
	[ComImport, Guid("3c8d99d1-4fbf-4181-a82c-af66bf7bd24e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIAdapter4 : IDXGIAdapter3
	{
		/// <summary>Sets application-defined data to the object and associates that data with a GUID.</summary>
		/// <param name="Name">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>A GUID that identifies the data. Use this GUID in a call to GetPrivateData to get the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the object's data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to the object's data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the DXGI_ERROR values.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>SetPrivateData</c> makes a copy of the specified data and stores it with the object.</para>
		/// <para>
		/// Private data that <c>SetPrivateData</c> stores in the object occupies the same storage space as private data that is stored by
		/// associated Direct3D objects (for example, by a Microsoft Direct3D 11 device through ID3D11Device::SetPrivateData or by a
		/// Direct3D 11 child device through ID3D11DeviceChild::SetPrivateData).
		/// </para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the well-known private
		/// data GUID ( <c>WKPDID_D3DDebugObjectName</c>) that is in D3Dcommon.h. For example, to give pContext a friendly name of My name,
		/// use the following code:
		/// </para>
		/// <para>
		/// You can use <c>WKPDID_D3DDebugObjectName</c> to track down memory leaks and understand performance characteristics of your
		/// applications. This information is reflected in the output of the debug layer that is related to memory leaks
		/// (ID3D11Debug::ReportLiveDeviceObjects) and with the event tracing for Windows events that we've added to Windows 8.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-setprivatedata HRESULT SetPrivateData( REFGUID Name,
		// UINT DataSize, const void *pData );
		new void SetPrivateData(in Guid Name, uint DataSize, IntPtr pData);

		/// <summary>Set an interface in the object's private data.</summary>
		/// <param name="Name">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>A GUID identifying the interface.</para>
		/// </param>
		/// <param name="pUnknown">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>The interface to set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following DXGI_ERROR.</para>
		/// </returns>
		/// <remarks>
		/// <para>This API associates an interface pointer with the object.</para>
		/// <para>
		/// When the interface is set its reference count is incremented. When the data are overwritten (by calling SPD or SPDI with the
		/// same GUID) or the object is destroyed, ::Release() is called and the interface's reference count is decremented.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( REFGUID Name, const IUnknown *pUnknown );
		new void SetPrivateDataInterface(in Guid Name, [In, Optional, MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] object? pUnknown);

		/// <summary>Get a pointer to the object's data.</summary>
		/// <param name="Name">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>A GUID identifying the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>Pointer to the data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following DXGI_ERROR.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, previously set by
		/// IDXGIObject::SetPrivateDataInterface, you must call ::Release() on the pointer before the pointer is freed to decrement the
		/// reference count.
		/// </para>
		/// <para>
		/// You can pass <c>GUID_DeviceType</c> in the Name parameter of <c>GetPrivateData</c> to retrieve the device type from the display
		/// adapter object (IDXGIAdapter, IDXGIAdapter1, IDXGIAdapter2).
		/// </para>
		/// <para><c>To get the type of device on which the display adapter was created</c></para>
		/// <list type="number">
		/// <item>
		/// <term>Call IUnknown::QueryInterface on the ID3D11Device or ID3D10Device object to retrieve the IDXGIDevice object.</term>
		/// </item>
		/// <item>
		/// <term>Call GetParent on the IDXGIDevice object to retrieve the IDXGIAdapter object.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Call <c>GetPrivateData</c> on the IDXGIAdapter object with <c>GUID_DeviceType</c> to retrieve the type of device on which the
		/// display adapter was created. pData will point to a value from the driver-type enumeration (for example, a value from D3D_DRIVER_TYPE).
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// On Windows 7 or earlier, this type is either a value from D3D10_DRIVER_TYPE or D3D_DRIVER_TYPE depending on which kind of device
		/// was created. On Windows 8, this type is always a value from <c>D3D_DRIVER_TYPE</c>. Don't use IDXGIObject::SetPrivateData with
		/// <c>GUID_DeviceType</c> because the behavior when doing so is undefined.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-getprivatedata HRESULT GetPrivateData( REFGUID Name,
		// UINT *pDataSize, void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid Name, ref uint pDataSize, [Out] IntPtr pData);

		/// <summary>Gets the parent of the object.</summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>The ID of the requested interface.</para>
		/// </param>
		/// <param name="ppParent">
		/// <para>Type: <c>void**</c></para>
		/// <para>The address of a pointer to the parent object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the DXGI_ERROR values.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-getparent HRESULT GetParent( REFIID riid, void
		// **ppParent );
		[PreserveSig]
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object? ppParent);

		/// <summary>Enumerate adapter (video card) outputs.</summary>
		/// <param name="Output">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The index of the output.</para>
		/// </param>
		/// <param name="ppOutput">
		/// <para>Type: <b><c>IDXGIOutput</c>**</b></para>
		/// <para>The address of a pointer to an <c>IDXGIOutput</c> interface at the position specified by the <i>Output</i> parameter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// A code that indicates success or failure (see <c>DXGI_ERROR</c>). DXGI_ERROR_NOT_FOUND is returned if the index is greater than
		/// the number of outputs.
		/// </para>
		/// <para>
		/// If the adapter came from a device created using D3D_DRIVER_TYPE_WARP, then the adapter has no outputs, so DXGI_ERROR_NOT_FOUND
		/// is returned.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para><b>Note</b>  If you call this API in a Session 0 process, it returns <c>DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</c>.</para>
		/// <para></para>
		/// <para>
		/// When the <b>EnumOutputs</b> method succeeds and fills the <i>ppOutput</i> parameter with the address of the pointer to the
		/// output interface, <b>EnumOutputs</b> increments the output interface's reference count. To avoid a memory leak, when you finish
		/// using the output interface, call the <c>Release</c> method to decrement the reference count.
		/// </para>
		/// <para>
		/// <b>EnumOutputs</b> first returns the output on which the desktop primary is displayed. This output corresponds with an index of
		/// zero. <b>EnumOutputs</b> then returns other outputs.
		/// </para>
		/// <para>Examples</para>
		/// <para>Enumerating Outputs</para>
		/// <para>Here is an example of how to use <b>EnumOutputs</b> to enumerate all the outputs on an adapter:</para>
		/// <para>
		/// <c>UINT i = 0; IDXGIOutput * pOutput; std::vector&lt;IDXGIOutput*&gt; vOutputs; while(pAdapter-&gt;EnumOutputs(i, &amp;pOutput)
		/// != DXGI_ERROR_NOT_FOUND) { vOutputs.push_back(pOutput); ++i; }</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiadapter-enumoutputs HRESULT EnumOutputs( UINT Output, [out]
		// IDXGIOutput **ppOutput );
		[PreserveSig]
		new HRESULT EnumOutputs(uint Output, [MarshalAs(UnmanagedType.Interface)] out IDXGIOutput ppOutput);

		/// <summary>Gets a DXGI 1.0 description of an adapter (or video card).</summary>
		/// <returns>
		/// <para>Type: <c>DXGI_ADAPTER_DESC*</c></para>
		/// <para>
		/// A pointer to a DXGI_ADAPTER_DESC structure that describes the adapter. This parameter must not be <c>NULL</c>. On feature level
		/// 9 graphics hardware, <c>GetDesc</c> returns zeros for the PCI ID in the <c>VendorId</c>, <c>DeviceId</c>, <c>SubSysId</c>, and
		/// <c>Revision</c> members of <c>DXGI_ADAPTER_DESC</c> and “Software Adapter” for the description string in the <c>Description</c> member.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Graphics apps can use the DXGI API to retrieve an accurate set of graphics memory values on systems that have Windows Display
		/// Driver Model (WDDM) drivers. The following are the critical steps involved.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Graphics driver model determination —Because DXGI is only available on systems with WDDM drivers, the app must first confirm the
		/// driver model by using the following API.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Retrieval of graphics memory values.—After the app determines the driver model to be WDDM, the app can use the Direct3D 10 or
		/// later API and DXGI to get the amount of graphics memory. After you create a Direct3D device, use this code to obtain a
		/// DXGI_ADAPTER_DESC structure that contains the amount of available graphics memory.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiadapter-getdesc HRESULT GetDesc( DXGI_ADAPTER_DESC
		// *pDesc );
		new DXGI_ADAPTER_DESC GetDesc();

		/// <summary>Checks whether the system supports a device interface for a graphics component.</summary>
		/// <param name="InterfaceName">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>The GUID of the interface of the device version for which support is being checked. For example, __uuidof(ID3D10Device).</para>
		/// </param>
		/// <param name="pUMDVersion">
		/// <para>Type: <c>LARGE_INTEGER*</c></para>
		/// <para>
		/// The user mode driver version of InterfaceName. This is returned only if the interface is supported, otherwise this parameter
		/// will be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// S_OK indicates that the interface is supported, otherwise DXGI_ERROR_UNSUPPORTED is returned (For more information, see DXGI_ERROR).
		/// </para>
		/// </returns>
		/// <remarks>
		/// <c>Note</c> You can use <c>CheckInterfaceSupport</c> only to check whether a Direct3D 10.x interface is supported, and only on
		/// Windows Vista SP1 and later versions of the operating system. If you try to use <c>CheckInterfaceSupport</c> to check whether a
		/// Direct3D 11.x and later version interface is supported, <c>CheckInterfaceSupport</c> returns DXGI_ERROR_UNSUPPORTED. Therefore,
		/// do not use <c>CheckInterfaceSupport</c>. Instead, to verify whether the operating system supports a particular interface, try to
		/// create the interface. For example, if you call the ID3D11Device::CreateBlendState method and it fails, the operating system does
		/// not support the ID3D11BlendState interface.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiadapter-checkinterfacesupport HRESULT CheckInterfaceSupport(
		// REFGUID InterfaceName, LARGE_INTEGER *pUMDVersion );
		[PreserveSig]
		new HRESULT CheckInterfaceSupport(in Guid InterfaceName, out long pUMDVersion);

		/// <summary>Gets a DXGI 1.1 description of an adapter (or video card).</summary>
		/// <returns>
		/// <para>Type: <c>DXGI_ADAPTER_DESC1*</c></para>
		/// <para>
		/// A pointer to a DXGI_ADAPTER_DESC1 structure that describes the adapter. This parameter must not be <c>NULL</c>. On feature level
		/// 9 graphics hardware, <c>GetDesc1</c> returns zeros for the PCI ID in the <c>VendorId</c>, <c>DeviceId</c>, <c>SubSysId</c>, and
		/// <c>Revision</c> members of <c>DXGI_ADAPTER_DESC1</c> and “Software Adapter” for the description string in the <c>Description</c> member.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
		/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644)
		/// and Windows Server 2008 (KB 971512).
		/// </para>
		/// <para>
		/// Use the <c>GetDesc1</c> method to get a DXGI 1.1 description of an adapter. To get a DXGI 1.0 description, use the IDXGIAdapter method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiadapter1-getdesc1 HRESULT GetDesc1( DXGI_ADAPTER_DESC1
		// *pDesc );
		new DXGI_ADAPTER_DESC1 GetDesc1();

		/// <summary>
		/// Gets a Microsoft DirectX Graphics Infrastructure (DXGI) 1.2 description of an adapter or video card. This description includes
		/// information about the granularity at which the graphics processing unit (GPU) can be preempted from performing its current task.
		/// </summary>
		/// <returns>
		/// A pointer to a <c>DXGI_ADAPTER_DESC2</c> structure that describes the adapter. This parameter must not be <b>NULL</b>. On
		/// <c>feature level</c> 9 graphics hardware, earlier versions of <b>GetDesc2</b> ( <c>GetDesc</c> and <c>GetDesc1</c>) return zeros
		/// for <b>VendorId</b>, <b>DeviceId</b>, <b>SubSysId</b>, and <b>Revision</b> members of the adapter description structure and
		/// “Software Adapter” for the description string in the <b>Description</b> member. <b>GetDesc2</b> returns the actual feature level
		/// 9 hardware values in these members.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use the <b>GetDesc2</b> method to get a DXGI 1.2 description of an adapter. To get a DXGI 1.1 description, use the
		/// <c>IDXGIAdapter1::GetDesc1</c> method. To get a DXGI 1.0 description, use the <c>IDXGIAdapter::GetDesc</c> method.
		/// </para>
		/// <para>
		/// The Windows Display Driver Model (WDDM) scheduler can preempt the GPU's execution of application tasks. The granularity at which
		/// the GPU can be preempted from performing its current task in the WDDM 1.1 or earlier driver model is a direct memory access
		/// (DMA) buffer for graphics tasks or a compute packet for compute tasks. The GPU can switch between tasks only after it completes
		/// the currently executing unit of work, a DMA buffer or a compute packet.
		/// </para>
		/// <para>
		/// A DMA buffer is the largest independent unit of graphics work that the WDDM scheduler can submit to the GPU. This buffer
		/// contains a set of GPU instructions that the WDDM driver and GPU use. A compute packet is the largest independent unit of compute
		/// work that the WDDM scheduler can submit to the GPU. A compute packet contains dispatches (for example, calls to the
		/// <c>ID3D11DeviceContext::Dispatch</c> method), which contain thread groups. The WDDM 1.2 or later driver model allows the GPU to
		/// be preempted at finer granularity levels than a DMA buffer or compute packet. You can use the <b>GetDesc2</b> method to retrieve
		/// the granularity levels for graphics and compute tasks.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiadapter2-getdesc2 HRESULT GetDesc2( [out]
		// DXGI_ADAPTER_DESC2 *pDesc );
		new DXGI_ADAPTER_DESC2 GetDesc2();

		/// <summary>Registers to receive notification of hardware content protection teardown events.</summary>
		/// <param name="hEvent">
		/// <para>Type: <b>HANDLE</b></para>
		/// <para>
		/// A handle to the event object that the operating system sets when hardware content protection teardown occurs. The
		/// <c>CreateEvent</c> or <c>OpenEvent</c> function returns this handle.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>DWORD*</b></para>
		/// <para>
		/// A pointer to a key value that an application can pass to the
		/// <c>IDXGIAdapter3::UnregisterHardwareContentProtectionTeardownStatus</c> method to unregister the notification event that
		/// <i>hEvent</i> specifies.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Call <c>ID3D11VideoDevice::GetContentProtectionCaps</c>() to check for the presence of the
		/// <c>D3D11_CONTENT_PROTECTION_CAPS_HARDWARE_TEARDOWN</c> capability to know whether the hardware contains an automatic teardown mechanism.
		/// </para>
		/// <para>
		/// After the event is signaled, the application can call <c>ID3D11VideoContext1::CheckCryptoSessionStatus</c> to determine the
		/// impact of the hardware teardown for a specific <c>ID3D11CryptoSession</c> interface.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgiadapter3-registerhardwarecontentprotectionteardownstatusevent
		// HRESULT RegisterHardwareContentProtectionTeardownStatusEvent( [in] HANDLE hEvent, [out] DWORD *pdwCookie );
		new uint RegisterHardwareContentProtectionTeardownStatusEvent(HEVENT hEvent);

		/// <summary>Unregisters an event to stop it from receiving notification of hardware content protection teardown events.</summary>
		/// <param name="dwCookie">
		/// <para>Type: <b>DWORD</b></para>
		/// <para>
		/// A key value for the window or event to unregister. The
		/// <c>IDXGIAdapter3::RegisterHardwareContentProtectionTeardownStatusEvent</c> method returns this value.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgiadapter3-unregisterhardwarecontentprotectionteardownstatus
		// void UnregisterHardwareContentProtectionTeardownStatus( [in] DWORD dwCookie );
		[PreserveSig]
		new void UnregisterHardwareContentProtectionTeardownStatus(uint dwCookie);

		/// <summary>This method informs the process of the current budget and process usage.</summary>
		/// <param name="NodeIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// Specifies the device's physical adapter for which the video memory information is queried. For single-GPU operation, set this to
		/// zero. If there are multiple GPU nodes, set this to the index of the node (the device's physical adapter) for which the video
		/// memory information is queried. See <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="MemorySegmentGroup">
		/// <para>Type: <b><c>DXGI_MEMORY_SEGMENT_GROUP</c></b></para>
		/// <para>Specifies a DXGI_MEMORY_SEGMENT_GROUP that identifies the group as local or non-local.</para>
		/// </param>
		/// <param name="pVideoMemoryInfo">
		/// <para>Type: <b><c>DXGI_QUERY_VIDEO_MEMORY_INFO</c>*</b></para>
		/// <para>Fills in a DXGI_QUERY_VIDEO_MEMORY_INFO structure with the current values.</para>
		/// </param>
		/// <remarks>
		/// Applications must explicitly manage their usage of physical memory explicitly and keep usage within the budget assigned to the
		/// application process. Processes that cannot kept their usage within their assigned budgets will likely experience stuttering, as
		/// they are intermittently frozen and paged-out to allow other processes to run.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgiadapter3-queryvideomemoryinfo HRESULT
		// QueryVideoMemoryInfo( [in] UINT NodeIndex, [in] DXGI_MEMORY_SEGMENT_GROUP MemorySegmentGroup, [out] DXGI_QUERY_VIDEO_MEMORY_INFO
		// *pVideoMemoryInfo );
		new void QueryVideoMemoryInfo(uint NodeIndex, DXGI_MEMORY_SEGMENT_GROUP MemorySegmentGroup, out DXGI_QUERY_VIDEO_MEMORY_INFO pVideoMemoryInfo);

		/// <summary>This method sends the minimum required physical memory for an application, to the OS.</summary>
		/// <param name="NodeIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// Specifies the device's physical adapter for which the video memory information is being set. For single-GPU operation, set this
		/// to zero. If there are multiple GPU nodes, set this to the index of the node (the device's physical adapter) for which the video
		/// memory information is being set. See <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="MemorySegmentGroup">
		/// <para>Type: <b><c>DXGI_MEMORY_SEGMENT_GROUP</c></b></para>
		/// <para>Specifies a DXGI_MEMORY_SEGMENT_GROUP that identifies the group as local or non-local.</para>
		/// </param>
		/// <param name="Reservation">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies a UINT64 that sets the minimum required physical memory, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</para>
		/// </returns>
		/// <remarks>
		/// Applications are encouraged to set a video reservation to denote the amount of physical memory they cannot go without. This
		/// value helps the OS quickly minimize the impact of large memory pressure situations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgiadapter3-setvideomemoryreservation HRESULT
		// SetVideoMemoryReservation( [in] UINT NodeIndex, [in] DXGI_MEMORY_SEGMENT_GROUP MemorySegmentGroup, [in] UINT64 Reservation );
		new void SetVideoMemoryReservation(uint NodeIndex, DXGI_MEMORY_SEGMENT_GROUP MemorySegmentGroup, ulong Reservation);

		/// <summary>This method establishes a correlation between a CPU synchronization object and the budget change event.</summary>
		/// <param name="hEvent">
		/// <para>Type: <b>HANDLE</b></para>
		/// <para>
		/// A handle to the event object that the operating system sets when memory budgets change. The <c>CreateEvent</c> and
		/// <c>OpenEvent</c> functions return this handle.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>DWORD*</b></para>
		/// <para>
		/// A pointer to a key value that you can pass to the <c>IDXGIAdapter3::UnregisterVideoMemoryBudgetChangeNotification</c> method to
		/// unregister the notification event that hEvent specifies.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Instead of calling <c>QueryVideoMemoryInfo</c> regularly, applications can use CPU synchronization objects to efficiently wake
		/// threads when budget changes occur.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgiadapter3-registervideomemorybudgetchangenotificationevent
		// HRESULT RegisterVideoMemoryBudgetChangeNotificationEvent( [in] HANDLE hEvent, [out] DWORD *pdwCookie );
		new uint RegisterVideoMemoryBudgetChangeNotificationEvent(HEVENT hEvent);

		/// <summary>
		/// This method stops notifying a CPU synchronization object whenever a budget change occurs. An application may switch back to
		/// polling the information regularly.
		/// </summary>
		/// <param name="dwCookie">
		/// <para>Type: <b>DWORD</b></para>
		/// <para>
		/// A key value for the window or event to unregister. The
		/// <c>IDXGIAdapter3::RegisterHardwareContentProtectionTeardownStatusEvent</c> method returns this value.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>An application may switch back to polling for the information regularly.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgiadapter3-unregistervideomemorybudgetchangenotification
		// void UnregisterVideoMemoryBudgetChangeNotification( [in] DWORD dwCookie );
		[PreserveSig]
		new void UnregisterVideoMemoryBudgetChangeNotification(uint dwCookie);

		/// <summary>
		/// Gets a Microsoft DirectX Graphics Infrastructure (DXGI) 1.6 description of an adapter or video card. This description includes
		/// information about ACG compatibility.
		/// </summary>
		/// <returns>
		/// A pointer to a <c>DXGI_ADAPTER_DESC3</c> structure that describes the adapter. This parameter must not be <b>NULL</b>. On
		/// <c>feature level</c> 9 graphics hardware, early versions of <b>GetDesc3</b> ( <c>GetDesc1</c>, and <c>GetDesc</c>) return zeros
		/// for <b>VendorId</b>, <b>DeviceId</b>, <b>SubSysId</b>, and <b>Revision</b> members of the adapter description structure and
		/// “Software Adapter” for the description string in the <b>Description</b> member. <b>GetDesc3</b> and <c>GetDesc2</c> return the
		/// actual feature level 9 hardware values in these members.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use the <b>GetDesc3</b> method to get a DXGI 1.6 description of an adapter. To get a DXGI 1.2 description, use the
		/// <c>IDXGIAdapter2::GetDesc2</c> method. To get a DXGI 1.1 description, use the <c>IDXGIAdapter1::GetDesc1</c> method. To get a
		/// DXGI 1.0 description, use the <c>IDXGIAdapter::GetDesc</c> method.
		/// </para>
		/// <para>
		/// The Windows Display Driver Model (WDDM) scheduler can preempt the graphics processing unit (GPU)'s execution of application
		/// tasks. The granularity at which the GPU can be preempted from performing its current task in the WDDM 1.1 or earlier driver
		/// model is a direct memory access (DMA) buffer for graphics tasks or a compute packet for compute tasks. The GPU can switch
		/// between tasks only after it completes the currently executing unit of work, a DMA buffer or a compute packet.
		/// </para>
		/// <para>
		/// A DMA buffer is the largest independent unit of graphics work that the WDDM scheduler can submit to the GPU. This buffer
		/// contains a set of GPU instructions that the WDDM driver and GPU use. A compute packet is the largest independent unit of compute
		/// work that the WDDM scheduler can submit to the GPU. A compute packet contains dispatches (for example, calls to the
		/// <c>ID3D11DeviceContext::Dispatch</c> method), which contain thread groups. The WDDM 1.2 or later driver model allows the GPU to
		/// be preempted at finer granularity levels than a DMA buffer or compute packet. You can use the <b>GetDesc3</b> or <c>GetDesc2</c>
		/// methods to retrieve the granularity levels for graphics and compute tasks.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nf-dxgi1_6-idxgiadapter4-getdesc3 HRESULT GetDesc3( [out]
		// DXGI_ADAPTER_DESC3 *pDesc );
		DXGI_ADAPTER_DESC3 GetDesc3();
	}

	/// <summary>This interface enables a single method that enumerates graphics adapters based on a given GPU preference.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nn-dxgi1_6-idxgifactory6
	[PInvokeData("dxgi1_6.h", MSDNShortId = "NN:dxgi1_6.IDXGIFactory6")]
	[ComImport, Guid("c1b6694f-ff09-44a9-b03c-77900a0a1d17"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIFactory6 : IDXGIFactory5
	{
		/// <summary>Sets application-defined data to the object and associates that data with a GUID.</summary>
		/// <param name="Name">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>A GUID that identifies the data. Use this GUID in a call to GetPrivateData to get the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the object's data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to the object's data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the DXGI_ERROR values.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>SetPrivateData</c> makes a copy of the specified data and stores it with the object.</para>
		/// <para>
		/// Private data that <c>SetPrivateData</c> stores in the object occupies the same storage space as private data that is stored by
		/// associated Direct3D objects (for example, by a Microsoft Direct3D 11 device through ID3D11Device::SetPrivateData or by a
		/// Direct3D 11 child device through ID3D11DeviceChild::SetPrivateData).
		/// </para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the well-known private
		/// data GUID ( <c>WKPDID_D3DDebugObjectName</c>) that is in D3Dcommon.h. For example, to give pContext a friendly name of My name,
		/// use the following code:
		/// </para>
		/// <para>
		/// You can use <c>WKPDID_D3DDebugObjectName</c> to track down memory leaks and understand performance characteristics of your
		/// applications. This information is reflected in the output of the debug layer that is related to memory leaks
		/// (ID3D11Debug::ReportLiveDeviceObjects) and with the event tracing for Windows events that we've added to Windows 8.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-setprivatedata HRESULT SetPrivateData( REFGUID Name,
		// UINT DataSize, const void *pData );
		new void SetPrivateData(in Guid Name, uint DataSize, IntPtr pData);

		/// <summary>Set an interface in the object's private data.</summary>
		/// <param name="Name">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>A GUID identifying the interface.</para>
		/// </param>
		/// <param name="pUnknown">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>The interface to set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following DXGI_ERROR.</para>
		/// </returns>
		/// <remarks>
		/// <para>This API associates an interface pointer with the object.</para>
		/// <para>
		/// When the interface is set its reference count is incremented. When the data are overwritten (by calling SPD or SPDI with the
		/// same GUID) or the object is destroyed, ::Release() is called and the interface's reference count is decremented.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( REFGUID Name, const IUnknown *pUnknown );
		new void SetPrivateDataInterface(in Guid Name, [In, Optional, MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] object? pUnknown);

		/// <summary>Get a pointer to the object's data.</summary>
		/// <param name="Name">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>A GUID identifying the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>Pointer to the data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following DXGI_ERROR.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, previously set by
		/// IDXGIObject::SetPrivateDataInterface, you must call ::Release() on the pointer before the pointer is freed to decrement the
		/// reference count.
		/// </para>
		/// <para>
		/// You can pass <c>GUID_DeviceType</c> in the Name parameter of <c>GetPrivateData</c> to retrieve the device type from the display
		/// adapter object (IDXGIAdapter, IDXGIAdapter1, IDXGIAdapter2).
		/// </para>
		/// <para><c>To get the type of device on which the display adapter was created</c></para>
		/// <list type="number">
		/// <item>
		/// <term>Call IUnknown::QueryInterface on the ID3D11Device or ID3D10Device object to retrieve the IDXGIDevice object.</term>
		/// </item>
		/// <item>
		/// <term>Call GetParent on the IDXGIDevice object to retrieve the IDXGIAdapter object.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Call <c>GetPrivateData</c> on the IDXGIAdapter object with <c>GUID_DeviceType</c> to retrieve the type of device on which the
		/// display adapter was created. pData will point to a value from the driver-type enumeration (for example, a value from D3D_DRIVER_TYPE).
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// On Windows 7 or earlier, this type is either a value from D3D10_DRIVER_TYPE or D3D_DRIVER_TYPE depending on which kind of device
		/// was created. On Windows 8, this type is always a value from <c>D3D_DRIVER_TYPE</c>. Don't use IDXGIObject::SetPrivateData with
		/// <c>GUID_DeviceType</c> because the behavior when doing so is undefined.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-getprivatedata HRESULT GetPrivateData( REFGUID Name,
		// UINT *pDataSize, void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid Name, ref uint pDataSize, [Out] IntPtr pData);

		/// <summary>Gets the parent of the object.</summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>The ID of the requested interface.</para>
		/// </param>
		/// <param name="ppParent">
		/// <para>Type: <c>void**</c></para>
		/// <para>The address of a pointer to the parent object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the DXGI_ERROR values.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-getparent HRESULT GetParent( REFIID riid, void
		// **ppParent );
		[PreserveSig]
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object? ppParent);

		/// <summary>Enumerates the adapters (video cards).</summary>
		/// <param name="Adapter">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The index of the adapter to enumerate.</para>
		/// </param>
		/// <param name="ppAdapter">
		/// <para>Type: <b><c>IDXGIAdapter</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDXGIAdapter</c> interface at the position specified by the <i>Adapter</i> parameter. This
		/// parameter must not be <b>NULL</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns S_OK if successful; otherwise, returns <c>DXGI_ERROR_NOT_FOUND</c> if the index is greater than or equal to the number
		/// of adapters in the local system, or <c>DXGI_ERROR_INVALID_CALL</c> if <i>ppAdapter</i> parameter is <b>NULL</b>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When you create a factory, the factory enumerates the set of adapters that are available in the system. Therefore, if you change
		/// the adapters in a system, you must destroy and recreate the <c>IDXGIFactory</c> object. The number of adapters in a system
		/// changes when you add or remove a display card, or dock or undock a laptop.
		/// </para>
		/// <para>
		/// When the <b>EnumAdapters</b> method succeeds and fills the <i>ppAdapter</i> parameter with the address of the pointer to the
		/// adapter interface, <b>EnumAdapters</b> increments the adapter interface's reference count. When you finish using the adapter
		/// interface, call the <c>Release</c> method to decrement the reference count before you destroy the pointer.
		/// </para>
		/// <para>
		/// <b>EnumAdapters</b> first returns the adapter with the output on which the desktop primary is displayed. This adapter
		/// corresponds with an index of zero. <b>EnumAdapters</b> next returns other adapters with outputs. <b>EnumAdapters</b> finally
		/// returns adapters without outputs.
		/// </para>
		/// <para>Examples</para>
		/// <para>Enumerating Adapters</para>
		/// <para>The following code example demonstrates how to enumerate adapters using the <b>EnumAdapters</b> method.</para>
		/// <para>
		/// <code language="cpp">
		///UINT i = 0;
		///IDXGIAdapter * pAdapter;
		///std::vector &lt;IDXGIAdapter*&gt; vAdapters;
		///while(pFactory-&gt;EnumAdapters(i, &amp;pAdapter) != DXGI_ERROR_NOT_FOUND) { vAdapters.push_back(pAdapter); ++i; }
		/// </code>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory-enumadapters HRESULT EnumAdapters( UINT Adapter,
		// [out] IDXGIAdapter **ppAdapter );
		[PreserveSig]
		new HRESULT EnumAdapters(uint Adapter, out IDXGIAdapter? ppAdapter);

		/// <summary>
		/// Allows DXGI to monitor an application's message queue for the alt-enter key sequence (which causes the application to switch
		/// from windowed to full screen or vice versa).
		/// </summary>
		/// <param name="WindowHandle">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the window that is to be monitored. This parameter can be <c>NULL</c>; but only if the flags are also 0.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>One or more of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// DXGI_MWA_NO_WINDOW_CHANGES - Prevent DXGI from monitoring an applications message queue; this makes DXGI unable to respond to
		/// mode changes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DXGI_MWA_NO_ALT_ENTER - Prevent DXGI from responding to an alt-enter sequence.</term>
		/// </item>
		/// <item>
		/// <term>DXGI_MWA_NO_PRINT_SCREEN - Prevent DXGI from responding to a print-screen key.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para><c>Note</c> If you call this API in a Session 0 process, it returns DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.</para>
		/// <para>
		/// The combination of WindowHandle and Flags informs DXGI to stop monitoring window messages for the previously-associated window.
		/// </para>
		/// <para>
		/// If the application switches to full-screen mode, DXGI will choose a full-screen resolution to be the smallest supported
		/// resolution that is larger or the same size as the current back buffer size.
		/// </para>
		/// <para>
		/// Applications can make some changes to make the transition from windowed to full screen more efficient. For example, on a WM_SIZE
		/// message, the application should release any outstanding swap-chain back buffers, call IDXGISwapChain::ResizeBuffers, then
		/// re-acquire the back buffers from the swap chain(s). This gives the swap chain(s) an opportunity to resize the back buffers,
		/// and/or recreate them to enable full-screen flipping operation. If the application does not perform this sequence, DXGI will
		/// still make the full-screen/windowed transition, but may be forced to use a stretch operation (since the back buffers may not be
		/// the correct size), which may be less efficient. Even if a stretch is not required, presentation may not be optimal because the
		/// back buffers might not be directly interchangeable with the front buffer. Thus, a call to <c>ResizeBuffers</c> on WM_SIZE is
		/// always recommended, since WM_SIZE is always sent during a fullscreen transition.
		/// </para>
		/// <para>
		/// While windowed, the application can, if it chooses, restrict the size of its window's client area to sizes to which it is
		/// comfortable rendering. A fully flexible application would make no such restriction, but UI elements or other design
		/// considerations can, of course, make this flexibility untenable. If the application further chooses to restrict its window's
		/// client area to just those that match supported full-screen resolutions, the application can field WM_SIZING, then check against
		/// IDXGIOutput::FindClosestMatchingMode. If a matching mode is found, allow the resize. (The IDXGIOutput can be retrieved from
		/// IDXGISwapChain::GetContainingOutput. Absent subsequent changes to desktop topology, this will be the same output that will be
		/// chosen when alt-enter is fielded and fullscreen mode is begun for that swap chain.)
		/// </para>
		/// <para>
		/// Applications that want to handle mode changes or Alt+Enter themselves should call <c>MakeWindowAssociation</c> with the
		/// DXGI_MWA_NO_WINDOW_CHANGES flag after swap chain creation. The WindowHandle argument, if non- <c>NULL</c>, specifies that the
		/// application message queues will not be handled by the DXGI runtime for all swap chains of a particular target HWND. Calling
		/// <c>MakeWindowAssociation</c> with the DXGI_MWA_NO_WINDOW_CHANGES flag after swapchain creation ensures that DXGI will not
		/// interfere with application's handling of window mode changes or Alt+Enter.
		/// </para>
		/// <para>Notes for Windows Store apps</para>
		/// <para>If a Windows Store app calls <c>MakeWindowAssociation</c>, it fails with DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.</para>
		/// <para>
		/// A Microsoft Win32 application can use <c>MakeWindowAssociation</c> to control full-screen transitions through the Alt+Enter key
		/// combination and print screen behavior for full screen. For Windows Store apps, because DXGI can't perform full-screen
		/// transitions, a Windows Store app has no way to control full-screen transitions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory-makewindowassociation HRESULT MakeWindowAssociation(
		// HWND WindowHandle, UINT Flags );
		new void MakeWindowAssociation(HWND WindowHandle, DXGI_MWA Flags);

		/// <summary>Get the window through which the user controls the transition to and from full screen.</summary>
		/// <returns>
		/// <para>Type: <c>HWND*</c></para>
		/// <para>A pointer to a window handle.</para>
		/// </returns>
		/// <remarks><c>Note</c> If you call this API in a Session 0 process, it returns DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory-getwindowassociation HRESULT GetWindowAssociation(
		// HWND *pWindowHandle );
		new HWND GetWindowAssociation();

		/// <summary>
		/// <para>
		/// [Starting with Direct3D 11.1, we recommend not to use <c>CreateSwapChain</c> anymore to create a swap chain. Instead, use
		/// CreateSwapChainForHwnd, CreateSwapChainForCoreWindow, or CreateSwapChainForComposition depending on how you want to create the
		/// swap chain.]
		/// </para>
		/// <para>Creates a swap chain.</para>
		/// </summary>
		/// <param name="pDevice">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// For Direct3D 11, and earlier versions of Direct3D, this is a pointer to the Direct3D device for the swap chain. For Direct3D 12
		/// this is a pointer to a direct command queue (refer to ID3D12CommandQueue) . This parameter cannot be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>DXGI_SWAP_CHAIN_DESC*</c></para>
		/// <para>A pointer to a DXGI_SWAP_CHAIN_DESC structure for the swap-chain description. This parameter cannot be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDXGISwapChain**</c></para>
		/// <para>
		/// A pointer to a variable that receives a pointer to the IDXGISwapChain interface for the swap chain that <c>CreateSwapChain</c> creates.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para><c>Note</c> If you call this API in a Session 0 process, it returns DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.</para>
		/// <para>
		/// If you attempt to create a swap chain in full-screen mode, and full-screen mode is unavailable, the swap chain will be created
		/// in windowed mode and DXGI_STATUS_OCCLUDED will be returned.
		/// </para>
		/// <para>
		/// If the buffer width or the buffer height is zero, the sizes will be inferred from the output window size in the swap-chain description.
		/// </para>
		/// <para>
		/// Because the target output can't be chosen explicitly when the swap chain is created, we recommend not to create a full-screen
		/// swap chain. This can reduce presentation performance if the swap chain size and the output window size do not match. Here are
		/// two ways to ensure that the sizes match:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Create a windowed swap chain and then set it full-screen using IDXGISwapChain::SetFullscreenState.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Save a pointer to the swap chain immediately after creation, and use it to get the output window size during a WM_SIZE event.
		/// Then resize the swap chain buffers (with IDXGISwapChain::ResizeBuffers) during the transition from windowed to full-screen.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the swap chain is in full-screen mode, before you release it you must use SetFullscreenState to switch it to windowed mode.
		/// For more information about releasing a swap chain, see the "Destroying a Swap Chain" section of DXGI Overview.
		/// </para>
		/// <para>
		/// After the runtime renders the initial frame in full screen, the runtime might unexpectedly exit full screen during a call to
		/// IDXGISwapChain::Present. To work around this issue, we recommend that you execute the following code right after you call
		/// <c>CreateSwapChain</c> to create a full-screen swap chain ( <c>Windowed</c> member of DXGI_SWAP_CHAIN_DESC set to <c>FALSE</c>).
		/// </para>
		/// <para>
		/// You can specify DXGI_SWAP_EFFECT and DXGI_SWAP_CHAIN_FLAG values in the swap-chain description that pDesc points to. These
		/// values allow you to use features like flip-model presentation and content protection by using pre-Windows 8 APIs.
		/// </para>
		/// <para>
		/// However, to use stereo presentation and to change resize behavior for the flip model, applications must use the
		/// IDXGIFactory2::CreateSwapChainForHwnd method. Otherwise, the back-buffer contents implicitly scale to fit the presentation
		/// target size; that is, you can't turn off scaling.
		/// </para>
		/// <para>Notes for Windows Store apps</para>
		/// <para>If a Windows Store app calls <c>CreateSwapChain</c> with full screen specified, <c>CreateSwapChain</c> fails.</para>
		/// <para>Windows Store apps call the IDXGIFactory2::CreateSwapChainForCoreWindow method to create a swap chain.</para>
		/// <para>For info about how to choose a format for the swap chain's back buffer, see Converting data for the color space.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory-createswapchain HRESULT CreateSwapChain( IUnknown
		// *pDevice, DXGI_SWAP_CHAIN_DESC *pDesc, IDXGISwapChain **ppSwapChain );
		new IDXGISwapChain CreateSwapChain([In, MarshalAs(UnmanagedType.Interface)] object pDevice, in DXGI_SWAP_CHAIN_DESC pDesc);

		/// <summary>Create an adapter interface that represents a software adapter.</summary>
		/// <param name="Module">
		/// <para>Type: <c>HMODULE</c></para>
		/// <para>Handle to the software adapter's dll. HMODULE can be obtained with GetModuleHandle or LoadLibrary.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDXGIAdapter**</c></para>
		/// <para>Address of a pointer to an adapter (see IDXGIAdapter).</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A software adapter is a DLL that implements the entirety of a device driver interface, plus emulation, if necessary, of
		/// kernel-mode graphics components for Windows. Details on implementing a software adapter can be found in the Windows Vista Driver
		/// Development Kit. This is a very complex development task, and is not recommended for general readers.
		/// </para>
		/// <para>
		/// Calling this method will increment the module's reference count by one. The reference count can be decremented by calling FreeLibrary.
		/// </para>
		/// <para>
		/// The typical calling scenario is to call LoadLibrary, pass the handle to <c>CreateSoftwareAdapter</c>, then immediately call
		/// FreeLibrary on the DLL and forget the DLL's HMODULE. Since the software adapter calls <c>FreeLibrary</c> when it is destroyed,
		/// the lifetime of the DLL will now be owned by the adapter, and the application is free of any further consideration of its lifetime.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory-createsoftwareadapter HRESULT CreateSoftwareAdapter(
		// HMODULE Module, IDXGIAdapter **ppAdapter );
		new IDXGIAdapter CreateSoftwareAdapter(HINSTANCE Module);

		/// <summary>Enumerates both adapters (video cards) with or without outputs.</summary>
		/// <param name="Adapter">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The index of the adapter to enumerate.</para>
		/// </param>
		/// <param name="ppAdapter">
		/// <para>Type: <b><c>IDXGIAdapter1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDXGIAdapter1</c> interface at the position specified by the <i>Adapter</i> parameter. This
		/// parameter must not be <b>NULL</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns S_OK if successful; otherwise, returns <c>DXGI_ERROR_NOT_FOUND</c> if the index is greater than or equal to the number
		/// of adapters in the local system, or <c>DXGI_ERROR_INVALID_CALL</c> if <i>ppAdapter</i> parameter is <b>NULL</b>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
		/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) ( <c>KB
		/// 971644</c>) and Windows Server 2008 ( <c>KB 971512</c>).
		/// </para>
		/// <para>
		/// When you create a factory, the factory enumerates the set of adapters that are available in the system. Therefore, if you change
		/// the adapters in a system, you must destroy and recreate the <c>IDXGIFactory1</c> object. The number of adapters in a system
		/// changes when you add or remove a display card, or dock or undock a laptop.
		/// </para>
		/// <para>
		/// When the <b>EnumAdapters1</b> method succeeds and fills the <i>ppAdapter</i> parameter with the address of the pointer to the
		/// adapter interface, <b>EnumAdapters1</b> increments the adapter interface's reference count. When you finish using the adapter
		/// interface, call the <c>Release</c> method to decrement the reference count before you destroy the pointer.
		/// </para>
		/// <para>
		/// <b>EnumAdapters1</b> first returns the adapter with the output on which the desktop primary is displayed. This adapter
		/// corresponds with an index of zero. <b>EnumAdapters1</b> next returns other adapters with outputs. <b>EnumAdapters1</b> finally
		/// returns adapters without outputs.
		/// </para>
		/// <para>Examples</para>
		/// <para>Enumerating Adapters</para>
		/// <para>The following code example demonstrates how to enumerate adapters using the <b>EnumAdapters1</b> method.</para>
		/// <para>
		/// <c>UINT i = 0; IDXGIAdapter1 * pAdapter; std::vector &lt;IDXGIAdapter1*&gt; vAdapters; while(pFactory-&gt;EnumAdapters1(i,
		/// &amp;pAdapter) != DXGI_ERROR_NOT_FOUND) { vAdapters.push_back(pAdapter); ++i; }</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory1-enumadapters1 HRESULT EnumAdapters1( UINT Adapter,
		// [out] IDXGIAdapter1 **ppAdapter );
		[PreserveSig]
		new HRESULT EnumAdapters1(uint Adapter, out IDXGIAdapter1? ppAdapter);

		/// <summary>Informs an application of the possible need to re-enumerate adapters.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>FALSE</c>, if a new adapter is becoming available or the current adapter is going away. <c>TRUE</c>, no adapter changes.</para>
		/// <para><c>IsCurrent</c> returns <c>FALSE</c> to inform the calling application to re-enumerate adapters.</para>
		/// </returns>
		/// <remarks>
		/// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
		/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644)
		/// and Windows Server 2008 (KB 971512).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory1-iscurrent BOOL IsCurrent();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsCurrent();

		/// <summary>Determines whether to use stereo mode.</summary>
		/// <returns>
		/// <para>Indicates whether to use stereo mode. <b>TRUE</b> indicates that you can use stereo mode; otherwise, <b>FALSE</b>.</para>
		/// <para>
		/// <b>Platform Update for Windows 7:  </b> On Windows 7 or Windows Server 2008 R2 with the <c>Platform Update for Windows 7</c>
		/// installed, <b>IsWindowedStereoEnabled</b> always returns FALSE because stereoscopic 3D display behavior isn’t available with the
		/// Platform Update for Windows 7. For more info about the Platform Update for Windows 7, see <c>Platform Update for Windows 7</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// We recommend that windowed applications call <b>IsWindowedStereoEnabled</b> before they attempt to use stereo.
		/// <b>IsWindowedStereoEnabled</b> returns <b>TRUE</b> if both of the following items are true:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// All adapters in the computer have drivers that are capable of stereo. This only means that the driver is implemented to the
		/// Windows Display Driver Model (WDDM) for Windows 8 (WDDM 1.2). However, the adapter does not necessarily have to be able to scan
		/// out stereo.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The current desktop mode (desktop modes are mono) and system policy and hardware are configured so that the Desktop Window
		/// Manager (DWM) performs stereo composition on at least one adapter output.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// The creation of a windowed stereo swap chain succeeds if the first requirement is met. However, if the adapter can't scan out
		/// stereo, the output on that adapter is reduced to mono.
		/// </para>
		/// <para>
		/// The <c>Direct3D 11.1 Simple Stereo 3D Sample</c> shows how to add a stereoscopic 3D effect and how to respond to system stereo changes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-iswindowedstereoenabled BOOL IsWindowedStereoEnabled();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsWindowedStereoEnabled();

		/// <summary>Creates a swap chain that is associated with an <c>HWND</c> handle to the output window for the swap chain.</summary>
		/// <param name="pDevice">
		/// For Direct3D 11, and earlier versions of Direct3D, this is a pointer to the Direct3D device for the swap chain. For Direct3D 12
		/// this is a pointer to a direct command queue (refer to <c>ID3D12CommandQueue</c>). This parameter cannot be <b>NULL</b>.
		/// </param>
		/// <param name="hWnd">
		/// The <c>HWND</c> handle that is associated with the swap chain that <b>CreateSwapChainForHwnd</b> creates. This parameter cannot
		/// be <b>NULL</b>.
		/// </param>
		/// <param name="pDesc">
		/// A pointer to a <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description. This parameter cannot be <b>NULL</b>.
		/// </param>
		/// <param name="pFullscreenDesc">
		/// A pointer to a <c>DXGI_SWAP_CHAIN_FULLSCREEN_DESC</c> structure for the description of a full-screen swap chain. You can
		/// optionally set this parameter to create a full-screen swap chain. Set it to <b>NULL</b> to create a windowed swap chain.
		/// </param>
		/// <param name="pRestrictToOutput">
		/// <para>
		/// A pointer to the <c>IDXGIOutput</c> interface for the output to restrict content to. You must also pass the
		/// <c>DXGI_PRESENT_RESTRICT_TO_OUTPUT</c> flag in a <c>IDXGISwapChain1::Present1</c> call to force the content to appear blacked
		/// out on any other output. If you want to restrict the content to a different output, you must create a new swap chain. However,
		/// you can conditionally restrict content based on the <b>DXGI_PRESENT_RESTRICT_TO_OUTPUT</b> flag.
		/// </para>
		/// <para>Set this parameter to <b>NULL</b> if you don't want to restrict content to an output target.</para>
		/// </param>
		/// <returns>
		/// A pointer to a variable that receives a pointer to the <c>IDXGISwapChain1</c> interface for the swap chain that
		/// <b>CreateSwapChainForHwnd</b> creates.
		/// </returns>
		/// <remarks>
		/// <para><b>Note</b>  Do not use this method in Windows Store apps. Instead, use <c>IDXGIFactory2::CreateSwapChainForCoreWindow</c>.</para>
		/// <para></para>
		/// <para>
		/// If you specify the width, height, or both ( <b>Width</b> and <b>Height</b> members of <c>DXGI_SWAP_CHAIN_DESC1</c> that
		/// <i>pDesc</i> points to) of the swap chain as zero, the runtime obtains the size from the output window that the <i>hWnd</i>
		/// parameter specifies.
		/// </para>
		/// <para>You can subsequently call the <c>IDXGISwapChain1::GetDesc1</c> method to retrieve the assigned width or height value.</para>
		/// <para>
		/// Because you can associate only one flip presentation model swap chain at a time with an <c>HWND</c>, the Microsoft Direct3D 11
		/// policy of deferring the destruction of objects can cause problems if you attempt to destroy a flip presentation model swap chain
		/// and replace it with another swap chain. For more info about this situation, see <c>Deferred Destruction Issues with Flip
		/// Presentation Swap Chains</c>.
		/// </para>
		/// <para>For info about how to choose a format for the swap chain's back buffer, see <c>Converting data for the color space</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforhwnd HRESULT
		// CreateSwapChainForHwnd( [in] IUnknown *pDevice, [in] HWND hWnd, [in] const DXGI_SWAP_CHAIN_DESC1 *pDesc, [in, optional] const
		// DXGI_SWAP_CHAIN_FULLSCREEN_DESC *pFullscreenDesc, [in, optional] IDXGIOutput *pRestrictToOutput, [out] IDXGISwapChain1
		// **ppSwapChain );
		new IDXGISwapChain1 CreateSwapChainForHwnd([In, MarshalAs(UnmanagedType.IUnknown)] object pDevice, HWND hWnd, in DXGI_SWAP_CHAIN_DESC1 pDesc,
			[In, Optional] StructPointer<DXGI_SWAP_CHAIN_FULLSCREEN_DESC> pFullscreenDesc, [In, Optional] IDXGIOutput? pRestrictToOutput);

		/// <summary>Creates a swap chain that is associated with the <c>CoreWindow</c> object for the output window for the swap chain.</summary>
		/// <param name="pDevice">
		/// For Direct3D 11, and earlier versions of Direct3D, this is a pointer to the Direct3D device for the swap chain. For Direct3D 12
		/// this is a pointer to a direct command queue (refer to <c>ID3D12CommandQueue</c>). This parameter cannot be <b>NULL</b>.
		/// </param>
		/// <param name="pWindow">
		/// A pointer to the <c>CoreWindow</c> object that is associated with the swap chain that <b>CreateSwapChainForCoreWindow</b> creates.
		/// </param>
		/// <param name="pDesc">
		/// A pointer to a <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description. This parameter cannot be <b>NULL</b>.
		/// </param>
		/// <param name="pRestrictToOutput">
		/// A pointer to the <c>IDXGIOutput</c> interface that the swap chain is restricted to. If the swap chain is moved to a different
		/// output, the content is black. You can optionally set this parameter to an output target that uses
		/// <c>DXGI_PRESENT_RESTRICT_TO_OUTPUT</c> to restrict the content on this output. If you do not set this parameter to restrict
		/// content on an output target, you can set it to <b>NULL</b>.
		/// </param>
		/// <returns>
		/// A pointer to a variable that receives a pointer to the <c>IDXGISwapChain1</c> interface for the swap chain that
		/// <b>CreateSwapChainForCoreWindow</b> creates.
		/// </returns>
		/// <remarks>
		/// <para><b>Note</b>  Use this method in Windows Store apps rather than <c>IDXGIFactory2::CreateSwapChainForHwnd</c>.</para>
		/// <para></para>
		/// <para>
		/// If you specify the width, height, or both ( <b>Width</b> and <b>Height</b> members of <c>DXGI_SWAP_CHAIN_DESC1</c> that
		/// <i>pDesc</i> points to) of the swap chain as zero, the runtime obtains the size from the output window that the <i>pWindow</i>
		/// parameter specifies.
		/// </para>
		/// <para>You can subsequently call the <c>IDXGISwapChain1::GetDesc1</c> method to retrieve the assigned width or height value.</para>
		/// <para>
		/// Because you can associate only one flip presentation model swap chain (per layer) at a time with a <c>CoreWindow</c>, the
		/// Microsoft Direct3D 11 policy of deferring the destruction of objects can cause problems if you attempt to destroy a flip
		/// presentation model swap chain and replace it with another swap chain. For more info about this situation, see <c>Deferred
		/// Destruction Issues with Flip Presentation Swap Chains</c>.
		/// </para>
		/// <para>For info about how to choose a format for the swap chain's back buffer, see <c>Converting data for the color space</c>.</para>
		/// <para><c></c><c></c><c></c> Overlapping swap chains</para>
		/// <para>
		/// Starting with Windows 8.1, it is possible to create an additional swap chain in the foreground layer. A foreground swap chain
		/// can be used to render UI elements at native resolution while scaling up real-time rendering in the background swap chain (such
		/// as gameplay). This enables scenarios where lower resolution rendering is required for faster fill rates, but without sacrificing
		/// UI quality.
		/// </para>
		/// <para>
		/// Foreground swap chains are created by setting the <b>DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER</b> swap chain flag in the
		/// <c>DXGI_SWAP_CHAIN_DESC1</c> that <i>pDesc</i> points to. Foreground swap chains must also use the
		/// <b>DXGI_ALPHA_MODE_PREMULTIPLIED</b> alpha mode, and must use <b>DXGI_SCALING_NONE</b>. Premultiplied alpha means that each
		/// pixel's color values are expected to be already multiplied by the alpha value before the frame is presented. For example, a 100%
		/// white BGRA pixel at 50% alpha is set to (0.5, 0.5, 0.5, 0.5). The alpha premultiplication step can be done in the output-merger
		/// stage by applying an app blend state (see <c>ID3D11BlendState</c>) with the <c>D3D11_RENDER_TARGET_BLEND_DESC</c> structure's
		/// <b>SrcBlend</b> field set to <b>D3D11_SRC_ALPHA</b>. If the alpha premultiplication step is not done, colors on the foreground
		/// swap chain will be brighter than expected.
		/// </para>
		/// <para>
		/// The foreground swap chain will use multiplane overlays if supported by the hardware. Call <c>IDXGIOutput2::SupportsOverlays</c>
		/// to query the adapter for overlay support.
		/// </para>
		/// <para>The following example creates a foreground swap chain for a CoreWindow:</para>
		/// <para>
		/// <c>DXGI_SWAP_CHAIN_DESC1 swapChainDesc = { 0 }; swapChainDesc.Width = static_cast&lt;UINT&gt;(m_d3dRenderTargetSize.Width);
		/// swapChainDesc.Height = static_cast&lt;UINT&gt;(m_d3dRenderTargetSize.Height); swapChainDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM;
		/// swapChainDesc.Stereo = false; swapChainDesc.SampleDesc.Count = 1; // Don't use multi-sampling. swapChainDesc.SampleDesc.Quality
		/// = 0; swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT; swapChainDesc.BufferCount = 2; swapChainDesc.SwapEffect =
		/// DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL; swapChainDesc.Flags = DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER; swapChainDesc.AlphaMode =
		/// DXGI_ALPHA_MODE_PREMULTIPLIED; swapChainDesc.Scaling = DXGI_SCALING_NONE; ComPtr&lt;IDXGISwapChain1&gt; swapChain; HRESULT hr =
		/// dxgiFactory-&gt;CreateSwapChainForCoreWindow( m_d3dDevice.Get(), reinterpret_cast&lt;IUnknown*&gt;(m_window.Get()),
		/// &amp;swapChainDesc, nullptr, &amp;swapChain );</c>
		/// </para>
		/// <para>Present both swap chains together after rendering is complete.</para>
		/// <para>The following example presents both swap chains:</para>
		/// <para>
		/// <c>HRESULT hr = m_swapChain-&gt;Present(1, 0); if (SUCCEEDED(hr) &amp;&amp; m_foregroundSwapChain) {
		/// m_foregroundSwapChain-&gt;Present(1, 0); }</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcorewindow HRESULT
		// CreateSwapChainForCoreWindow( [in] IUnknown *pDevice, [in] IUnknown *pWindow, [in] const DXGI_SWAP_CHAIN_DESC1 *pDesc, [in,
		// optional] IDXGIOutput *pRestrictToOutput, [out] IDXGISwapChain1 **ppSwapChain );
		new IDXGISwapChain1 CreateSwapChainForCoreWindow([In, MarshalAs(UnmanagedType.IUnknown)] object pDevice, [In, MarshalAs(UnmanagedType.IUnknown)] object pWindow,
			in DXGI_SWAP_CHAIN_DESC1 pDesc, [In, Optional] IDXGIOutput? pRestrictToOutput);

		/// <summary>Identifies the adapter on which a shared resource object was created.</summary>
		/// <param name="hResource">
		/// A handle to a shared resource object. The <c>IDXGIResource1::CreateSharedHandle</c> method returns this handle.
		/// </param>
		/// <returns>
		/// A pointer to a variable that receives a locally unique identifier ( <c>LUID</c>) value that identifies the adapter. <b>LUID</b>
		/// is defined in Dxgi.h. An <b>LUID</b> is a 64-bit value that is guaranteed to be unique only on the operating system on which it
		/// was generated. The uniqueness of an <b>LUID</b> is guaranteed only until the operating system is restarted.
		/// </returns>
		/// <remarks>
		/// <para>
		/// You cannot share resources across adapters. Therefore, you cannot open a shared resource on an adapter other than the adapter on
		/// which the resource was created. Call <b>GetSharedResourceAdapterLuid</b> before you open a shared resource to ensure that the
		/// resource was created on the appropriate adapter. To open a shared resource, call the <c>ID3D11Device1::OpenSharedResource1</c>
		/// or <c>ID3D11Device1::OpenSharedResourceByName</c> method.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// <c>HANDLE handle; IDXGIFactory2* pFactory; LUID luid; pFactory-&gt;GetSharedResourceAdapterLuid (handle, &amp;luid); UINT index
		/// = 0; IDXGIAdapter* pAdapter = NULL; while (SUCCEEDED(pFactory-&gt;EnumAdapters(index, &amp;pAdapter))) { DXGI_ADAPTER_DESC desc;
		/// pAdapter-&gt;GetDesc(&amp;desc); if (desc.AdapterLuid == luid) { // Identified a matching adapter. break; }
		/// pAdapter-&gt;Release(); pAdapter = NULL; index++; } // At this point, if pAdapter is non-null, you identified an adapter that //
		/// can open the shared resource.</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-getsharedresourceadapterluid HRESULT
		// GetSharedResourceAdapterLuid( [in] HANDLE hResource, [out] LUID *pLuid );
		new LUID GetSharedResourceAdapterLuid([In] HANDLE hResource);

		/// <summary>Registers an application window to receive notification messages of changes of stereo status.</summary>
		/// <param name="WindowHandle">The handle of the window to send a notification message to when stereo status change occurs.</param>
		/// <param name="wMsg">Identifies the notification message to send.</param>
		/// <returns>
		/// A pointer to a key value that an application can pass to the <c>IDXGIFactory2::UnregisterStereoStatus</c> method to unregister
		/// the notification message that <i>wMsg</i> specifies.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-registerstereostatuswindow HRESULT
		// RegisterStereoStatusWindow( [in] HWND WindowHandle, [in] UINT wMsg, [out] DWORD *pdwCookie );
		new uint RegisterStereoStatusWindow(HWND WindowHandle, uint wMsg);

		/// <summary>Registers to receive notification of changes in stereo status by using event signaling.</summary>
		/// <param name="hEvent">
		/// A handle to the event object that the operating system sets when notification of stereo status change occurs. The
		/// <c>CreateEvent</c> or <c>OpenEvent</c> function returns this handle.
		/// </param>
		/// <returns>
		/// A pointer to a key value that an application can pass to the <c>IDXGIFactory2::UnregisterStereoStatus</c> method to unregister
		/// the notification event that <i>hEvent</i> specifies.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-registerstereostatusevent HRESULT
		// RegisterStereoStatusEvent( [in] HANDLE hEvent, [out] DWORD *pdwCookie );
		new uint RegisterStereoStatusEvent(HEVENT hEvent);

		/// <summary>Unregisters a window or an event to stop it from receiving notification when stereo status changes.</summary>
		/// <param name="dwCookie">
		/// A key value for the window or event to unregister. The <c>IDXGIFactory2::RegisterStereoStatusWindow</c> or
		/// <c>IDXGIFactory2::RegisterStereoStatusEvent</c> method returns this value.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <b>Platform Update for Windows 7:  </b> On Windows 7 or Windows Server 2008 R2 with the <c>Platform Update for Windows 7</c>
		/// installed, <b>UnregisterStereoStatus</b> has no effect. For more info about the Platform Update for Windows 7, see <c>Platform
		/// Update for Windows 7</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-unregisterstereostatus void
		// UnregisterStereoStatus( [in] DWORD dwCookie );
		[PreserveSig]
		new void UnregisterStereoStatus(uint dwCookie);

		/// <summary>Registers an application window to receive notification messages of changes of occlusion status.</summary>
		/// <param name="WindowHandle">The handle of the window to send a notification message to when occlusion status change occurs.</param>
		/// <param name="wMsg">Identifies the notification message to send.</param>
		/// <returns>
		/// A pointer to a key value that an application can pass to the <c>IDXGIFactory2::UnregisterOcclusionStatus</c> method to
		/// unregister the notification message that <i>wMsg</i> specifies.
		/// </returns>
		/// <remarks>Apps choose the Windows message that Windows sends when occlusion status changes.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-registerocclusionstatuswindow HRESULT
		// RegisterOcclusionStatusWindow( [in] HWND WindowHandle, [in] UINT wMsg, [out] DWORD *pdwCookie );
		new uint RegisterOcclusionStatusWindow([In] HWND WindowHandle, uint wMsg);

		/// <summary>Registers to receive notification of changes in occlusion status by using event signaling.</summary>
		/// <param name="hEvent">
		/// A handle to the event object that the operating system sets when notification of occlusion status change occurs. The
		/// <c>CreateEvent</c> or <c>OpenEvent</c> function returns this handle.
		/// </param>
		/// <returns>
		/// A pointer to a key value that an application can pass to the <c>IDXGIFactory2::UnregisterOcclusionStatus</c> method to
		/// unregister the notification event that <i>hEvent</i> specifies.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call <b>RegisterOcclusionStatusEvent</b> multiple times with the same event handle, <b>RegisterOcclusionStatusEvent</b>
		/// fails with <c>DXGI_ERROR_INVALID_CALL</c>.
		/// </para>
		/// <para>
		/// If you call <b>RegisterOcclusionStatusEvent</b> multiple times with the different event handles,
		/// <b>RegisterOcclusionStatusEvent</b> properly registers the events.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-registerocclusionstatusevent HRESULT
		// RegisterOcclusionStatusEvent( [in] HANDLE hEvent, [out] DWORD *pdwCookie );
		new uint RegisterOcclusionStatusEvent([In] HEVENT hEvent);

		/// <summary>Unregisters a window or an event to stop it from receiving notification when occlusion status changes.</summary>
		/// <param name="dwCookie">
		/// A key value for the window or event to unregister. The <c>IDXGIFactory2::RegisterOcclusionStatusWindow</c> or
		/// <c>IDXGIFactory2::RegisterOcclusionStatusEvent</c> method returns this value.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <b>Platform Update for Windows 7:  </b> On Windows 7 or Windows Server 2008 R2 with the <c>Platform Update for Windows 7</c>
		/// installed, <b>UnregisterOcclusionStatus</b> has no effect. For more info about the Platform Update for Windows 7, see
		/// <c>Platform Update for Windows 7</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-unregisterocclusionstatus void
		// UnregisterOcclusionStatus( [in] DWORD dwCookie );
		[PreserveSig]
		new void UnregisterOcclusionStatus(uint dwCookie);

		/// <summary>
		/// Creates a swap chain that you can use to send Direct3D content into the <c>DirectComposition</c> API, to the
		/// <c>Windows.UI.Xaml</c> framework, or to <c>Windows UI Library (WinUI)</c> XAML, to compose in a window.
		/// </summary>
		/// <param name="pDevice">
		/// For Direct3D 11, and earlier versions of Direct3D, this is a pointer to the Direct3D device for the swap chain. For Direct3D 12
		/// this is a pointer to a direct command queue (refer to <c>ID3D12CommandQueue</c>). This parameter cannot be <b>NULL</b>. Software
		/// drivers, like <c>D3D_DRIVER_TYPE_REFERENCE</c>, are not supported for composition swap chains.
		/// </param>
		/// <param name="pDesc">
		/// <para>A pointer to a <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description. This parameter cannot be <b>NULL</b>.</para>
		/// <para>
		/// You must specify the <c>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</c> value in the <b>SwapEffect</b> member of
		/// <c>DXGI_SWAP_CHAIN_DESC1</c> because <b>CreateSwapChainForComposition</b> supports only <c>flip presentation model</c>.
		/// </para>
		/// <para>You must also specify the <c>DXGI_SCALING_STRETCH</c> value in the <b>Scaling</b> member of <c>DXGI_SWAP_CHAIN_DESC1</c>.</para>
		/// </param>
		/// <param name="pRestrictToOutput">
		/// <para>
		/// A pointer to the <c>IDXGIOutput</c> interface for the output to restrict content to. You must also pass the
		/// <c>DXGI_PRESENT_RESTRICT_TO_OUTPUT</c> flag in a <c>IDXGISwapChain1::Present1</c> call to force the content to appear blacked
		/// out on any other output. If you want to restrict the content to a different output, you must create a new swap chain. However,
		/// you can conditionally restrict content based on the <b>DXGI_PRESENT_RESTRICT_TO_OUTPUT</b> flag.
		/// </para>
		/// <para>Set this parameter to <b>NULL</b> if you don't want to restrict content to an output target.</para>
		/// </param>
		/// <returns>
		/// A pointer to a variable that receives a pointer to the <c>IDXGISwapChain1</c> interface for the swap chain that
		/// <b>CreateSwapChainForComposition</b> creates.
		/// </returns>
		/// <remarks>
		/// <para>You can use composition swap chains with either:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>DirectComposition</c>'s <c>IDCompositionVisual</c> interface,</description>
		/// </item>
		/// <item>
		/// <description>System XAML's <c>SwapChainPanel</c> or <c>SwapChainBackgroundPanel</c> classes.</description>
		/// </item>
		/// <item>
		/// <description><c>Windows UI Library (WinUI) 3</c> XAML's <c>SwapChainPanel</c> or <c>SwapChainBackgroundPanel</c> classes.</description>
		/// </item>
		/// </list>
		/// <para>
		/// For DirectComposition, you can call the <c>IDCompositionVisual::SetContent</c> method to set the swap chain as the content of a
		/// <c>visual object</c>, which then allows you to bind the swap chain to the visual tree. For XAML, the
		/// <b>SwapChainBackgroundPanel</b> class exposes a classic COM interface <b>ISwapChainBackgroundPanelNative</b>. You can use the
		/// <c>ISwapChainBackgroundPanelNative::SetSwapChain</c> method to bind to the XAML UI graph. For info about how to use composition
		/// swap chains with XAML’s <b>SwapChainBackgroundPanel</b> class, see <c>DirectX and XAML interop</c>.
		/// </para>
		/// <para>
		/// The <c>IDXGISwapChain::SetFullscreenState</c>, <c>IDXGISwapChain::ResizeTarget</c>, <c>IDXGISwapChain::GetContainingOutput</c>,
		/// <c>IDXGISwapChain1::GetHwnd</c>, and <c>IDXGISwapChain::GetCoreWindow</c> methods aren't valid on this type of swap chain. If
		/// you call any of these methods on this type of swap chain, they fail.
		/// </para>
		/// <para>For info about how to choose a format for the swap chain's back buffer, see <c>Converting data for the color space</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcomposition HRESULT
		// CreateSwapChainForComposition( [in] IUnknown *pDevice, [in] const DXGI_SWAP_CHAIN_DESC1 *pDesc, [in, optional] IDXGIOutput
		// *pRestrictToOutput, [out] IDXGISwapChain1 **ppSwapChain );
		new IDXGISwapChain1 CreateSwapChainForComposition([MarshalAs(UnmanagedType.IUnknown)] object pDevice, in DXGI_SWAP_CHAIN_DESC1 pDesc,
			[In, Optional] IDXGIOutput? pRestrictToOutput);

		/// <summary>Gets the flags that were used when a Microsoft DirectX Graphics Infrastructure (DXGI) object was created.</summary>
		/// <returns>The creation flags.</returns>
		/// <remarks>
		/// The <b>GetCreationFlags</b> method returns flags that were passed to the <see cref="CreateDXGIFactory2"/> function, or were
		/// implicitly constructed by <c>CreateDXGIFactory</c>, <c>CreateDXGIFactory1</c>, <c>D3D11CreateDevice</c>, or <c>D3D11CreateDeviceAndSwapChain</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgifactory3-getcreationflags UINT GetCreationFlags();
		[PreserveSig]
		new DXGI_CREATE_FACTORY GetCreationFlags();

		/// <summary>Outputs the <c>IDXGIAdapter</c> for the specified LUID.</summary>
		/// <param name="AdapterLuid">
		/// <para>Type: <b><c>LUID</c></b></para>
		/// <para>
		/// A unique value that identifies the adapter. See <c>LUID</c> for a definition of the structure. <b>LUID</b> is defined in dxgi.h.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier (GUID) of the <c>IDXGIAdapter</c> object referenced by the <i>ppvAdapter</i> parameter.</para>
		/// </param>
		/// <param name="ppvAdapter">
		/// <para>Type: <b>void**</b></para>
		/// <para>The address of an <c>IDXGIAdapter</c> interface pointer to the adapter. This parameter must not be NULL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>. See also Direct3D 12
		/// Return Codes.
		/// </para>
		/// </returns>
		/// <remarks>
		/// For Direct3D 12, it's no longer possible to backtrack from a device to the <c>IDXGIAdapter</c> that was used to create it.
		/// <b>IDXGIFactory4::EnumAdapterByLuid</b> enables an app to retrieve information about the adapter where a D3D12 device was
		/// created. <b>IDXGIFactory4::EnumAdapterByLuid</b> is designed to be paired with <c>ID3D12Device::GetAdapterLuid</c>. For more
		/// information, see <c>DXGI 1.4 Improvements</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgifactory4-enumadapterbyluid HRESULT EnumAdapterByLuid(
		// [in] LUID AdapterLuid, [in] REFIID riid, [out] void **ppvAdapter );
		[PreserveSig]
		new HRESULT EnumAdapterByLuid(LUID AdapterLuid, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvAdapter);

		/// <summary>Provides an adapter which can be provided to D3D12CreateDevice to use the WARP renderer.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier (GUID) of the <c>IDXGIAdapter</c> object referenced by the <i>ppvAdapter</i> parameter.</para>
		/// </param>
		/// <param name="ppvAdapter">
		/// <para>Type: <b>void**</b></para>
		/// <para>The address of an <c>IDXGIAdapter</c> interface pointer to the adapter. This parameter must not be NULL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>. See also Direct3D 12
		/// Return Codes.
		/// </para>
		/// </returns>
		/// <remarks>For more information, see <c>DXGI 1.4 Improvements</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgifactory4-enumwarpadapter HRESULT EnumWarpAdapter(
		// [in] REFIID riid, [out] void **ppvAdapter );
		[PreserveSig]
		new HRESULT EnumWarpAdapter(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvAdapter);

		/// <summary>Used to check for hardware feature support.</summary>
		/// <param name="Feature">
		/// <para>Type: <b><c>DXGI_FEATURE</c></b></para>
		/// <para>Specifies one member of <c>DXGI_FEATURE</c> to query support for.</para>
		/// </param>
		/// <param name="pFeatureSupportData">
		/// <para>Type: <b>void*</b></para>
		/// <para>Specifies a pointer to a buffer that will be filled with data that describes the feature support.</para>
		/// </param>
		/// <param name="FeatureSupportDataSize">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The size, in bytes, of <i>pFeatureSupportData</i>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		/// <remarks>Refer to the description of <c>DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_5/nf-dxgi1_5-idxgifactory5-checkfeaturesupport HRESULT
		// CheckFeatureSupport( DXGI_FEATURE Feature, [in, out] void *pFeatureSupportData, UINT FeatureSupportDataSize );
		[PreserveSig]
		new HRESULT CheckFeatureSupport(DXGI_FEATURE Feature, [In, Out] IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		/// <summary>Enumerates graphics adapters based on a given GPU preference.</summary>
		/// <param name="Adapter">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// The index of the adapter to enumerate. The indices are in order of the preference specified in <i>GpuPreference</i>—for example,
		/// if <b>DXGI_GPU_PREFERENCE_HIGH_PERFORMANCE</b> is specified, then the highest-performing adapter is at index 0, the
		/// second-highest is at index 1, and so on.
		/// </para>
		/// </param>
		/// <param name="GpuPreference">
		/// <para>Type: <b><c>DXGI_GPU_PREFERENCE</c></b></para>
		/// <para>The GPU preference for the app.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier (GUID) of the <c>IDXGIAdapter</c> object referenced by the <i>ppvAdapter</i> parameter.</para>
		/// </param>
		/// <param name="ppvAdapter">
		/// <para>Type: <b>void**</b></para>
		/// <para>The address of an <c>IDXGIAdapter</c> interface pointer to the adapter.</para>
		/// <para>This parameter must not be NULL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>Returns <b>S_OK</b> if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method allows developers to select which GPU they think is most appropriate for each device their app creates and utilizes.
		/// </para>
		/// <para>
		/// This method is similar to <c>IDXGIFactory1::EnumAdapters1</c>, but it accepts a GPU preference to reorder the adapter
		/// enumeration. It returns the appropriate <b>IDXGIAdapter</b> for the given GPU preference. It is meant to be used in conjunction
		/// with the <b>D3DCreateDevice</b> functions, which take in an <b>IDXGIAdapter</b>.
		/// </para>
		/// <para>
		/// When <b>DXGI_GPU_PREFERENCE_UNSPECIFIED</b> is specified for the <i>GpuPreference</i> parameter, this method is equivalent to
		/// calling <c>IDXGIFactory1::EnumAdapters1</c>.
		/// </para>
		/// <para>
		/// When <b>DXGI_GPU_PREFERENCE_MINIMUM_POWER</b> is specified for the <i>GpuPreference</i> parameter, the order of preference for
		/// the adapter returned in <i>ppvAdapter</i> will be:
		/// </para>
		/// <list/>
		/// <para>
		/// When <b>DXGI_GPU_PREFERENCE_HIGH_PERFORMANCE</b> is specified for the <i>GpuPreference</i> parameter, the order of preference
		/// for the adapter returned in <i>ppvAdapter</i> will be:
		/// </para>
		/// <list/>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nf-dxgi1_6-idxgifactory6-enumadapterbygpupreference HRESULT
		// EnumAdapterByGpuPreference( [in] UINT Adapter, [in] DXGI_GPU_PREFERENCE GpuPreference, [in] REFIID riid, [out] void **ppvAdapter );
		[PreserveSig]
		HRESULT EnumAdapterByGpuPreference(uint Adapter, DXGI_GPU_PREFERENCE GpuPreference, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppvAdapter);
	}

	/// <summary>This interface enables registration for notifications to detect adapter enumeration state changes.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nn-dxgi1_6-idxgifactory7
	[PInvokeData("dxgi1_6.h", MSDNShortId = "NN:dxgi1_6.IDXGIFactory7")]
	[ComImport, Guid("a4966eed-76db-44da-84c1-ee9a7afb20a8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIFactory7 : IDXGIFactory6
	{
		/// <summary>Sets application-defined data to the object and associates that data with a GUID.</summary>
		/// <param name="Name">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>A GUID that identifies the data. Use this GUID in a call to GetPrivateData to get the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the object's data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to the object's data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the DXGI_ERROR values.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>SetPrivateData</c> makes a copy of the specified data and stores it with the object.</para>
		/// <para>
		/// Private data that <c>SetPrivateData</c> stores in the object occupies the same storage space as private data that is stored by
		/// associated Direct3D objects (for example, by a Microsoft Direct3D 11 device through ID3D11Device::SetPrivateData or by a
		/// Direct3D 11 child device through ID3D11DeviceChild::SetPrivateData).
		/// </para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the well-known private
		/// data GUID ( <c>WKPDID_D3DDebugObjectName</c>) that is in D3Dcommon.h. For example, to give pContext a friendly name of My name,
		/// use the following code:
		/// </para>
		/// <para>
		/// You can use <c>WKPDID_D3DDebugObjectName</c> to track down memory leaks and understand performance characteristics of your
		/// applications. This information is reflected in the output of the debug layer that is related to memory leaks
		/// (ID3D11Debug::ReportLiveDeviceObjects) and with the event tracing for Windows events that we've added to Windows 8.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-setprivatedata HRESULT SetPrivateData( REFGUID Name,
		// UINT DataSize, const void *pData );
		new void SetPrivateData(in Guid Name, uint DataSize, IntPtr pData);

		/// <summary>Set an interface in the object's private data.</summary>
		/// <param name="Name">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>A GUID identifying the interface.</para>
		/// </param>
		/// <param name="pUnknown">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>The interface to set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following DXGI_ERROR.</para>
		/// </returns>
		/// <remarks>
		/// <para>This API associates an interface pointer with the object.</para>
		/// <para>
		/// When the interface is set its reference count is incremented. When the data are overwritten (by calling SPD or SPDI with the
		/// same GUID) or the object is destroyed, ::Release() is called and the interface's reference count is decremented.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( REFGUID Name, const IUnknown *pUnknown );
		new void SetPrivateDataInterface(in Guid Name, [In, Optional, MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] object? pUnknown);

		/// <summary>Get a pointer to the object's data.</summary>
		/// <param name="Name">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>A GUID identifying the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>Pointer to the data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following DXGI_ERROR.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, previously set by
		/// IDXGIObject::SetPrivateDataInterface, you must call ::Release() on the pointer before the pointer is freed to decrement the
		/// reference count.
		/// </para>
		/// <para>
		/// You can pass <c>GUID_DeviceType</c> in the Name parameter of <c>GetPrivateData</c> to retrieve the device type from the display
		/// adapter object (IDXGIAdapter, IDXGIAdapter1, IDXGIAdapter2).
		/// </para>
		/// <para><c>To get the type of device on which the display adapter was created</c></para>
		/// <list type="number">
		/// <item>
		/// <term>Call IUnknown::QueryInterface on the ID3D11Device or ID3D10Device object to retrieve the IDXGIDevice object.</term>
		/// </item>
		/// <item>
		/// <term>Call GetParent on the IDXGIDevice object to retrieve the IDXGIAdapter object.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Call <c>GetPrivateData</c> on the IDXGIAdapter object with <c>GUID_DeviceType</c> to retrieve the type of device on which the
		/// display adapter was created. pData will point to a value from the driver-type enumeration (for example, a value from D3D_DRIVER_TYPE).
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// On Windows 7 or earlier, this type is either a value from D3D10_DRIVER_TYPE or D3D_DRIVER_TYPE depending on which kind of device
		/// was created. On Windows 8, this type is always a value from <c>D3D_DRIVER_TYPE</c>. Don't use IDXGIObject::SetPrivateData with
		/// <c>GUID_DeviceType</c> because the behavior when doing so is undefined.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-getprivatedata HRESULT GetPrivateData( REFGUID Name,
		// UINT *pDataSize, void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid Name, ref uint pDataSize, [Out] IntPtr pData);

		/// <summary>Gets the parent of the object.</summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>The ID of the requested interface.</para>
		/// </param>
		/// <param name="ppParent">
		/// <para>Type: <c>void**</c></para>
		/// <para>The address of a pointer to the parent object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the DXGI_ERROR values.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-getparent HRESULT GetParent( REFIID riid, void
		// **ppParent );
		[PreserveSig]
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object? ppParent);

		/// <summary>Enumerates the adapters (video cards).</summary>
		/// <param name="Adapter">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The index of the adapter to enumerate.</para>
		/// </param>
		/// <param name="ppAdapter">
		/// <para>Type: <b><c>IDXGIAdapter</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDXGIAdapter</c> interface at the position specified by the <i>Adapter</i> parameter. This
		/// parameter must not be <b>NULL</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns S_OK if successful; otherwise, returns <c>DXGI_ERROR_NOT_FOUND</c> if the index is greater than or equal to the number
		/// of adapters in the local system, or <c>DXGI_ERROR_INVALID_CALL</c> if <i>ppAdapter</i> parameter is <b>NULL</b>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When you create a factory, the factory enumerates the set of adapters that are available in the system. Therefore, if you change
		/// the adapters in a system, you must destroy and recreate the <c>IDXGIFactory</c> object. The number of adapters in a system
		/// changes when you add or remove a display card, or dock or undock a laptop.
		/// </para>
		/// <para>
		/// When the <b>EnumAdapters</b> method succeeds and fills the <i>ppAdapter</i> parameter with the address of the pointer to the
		/// adapter interface, <b>EnumAdapters</b> increments the adapter interface's reference count. When you finish using the adapter
		/// interface, call the <c>Release</c> method to decrement the reference count before you destroy the pointer.
		/// </para>
		/// <para>
		/// <b>EnumAdapters</b> first returns the adapter with the output on which the desktop primary is displayed. This adapter
		/// corresponds with an index of zero. <b>EnumAdapters</b> next returns other adapters with outputs. <b>EnumAdapters</b> finally
		/// returns adapters without outputs.
		/// </para>
		/// <para>Examples</para>
		/// <para>Enumerating Adapters</para>
		/// <para>The following code example demonstrates how to enumerate adapters using the <b>EnumAdapters</b> method.</para>
		/// <para>
		/// <code language="cpp">
		///UINT i = 0;
		///IDXGIAdapter * pAdapter;
		///std::vector &lt;IDXGIAdapter*&gt; vAdapters;
		///while(pFactory-&gt;EnumAdapters(i, &amp;pAdapter) != DXGI_ERROR_NOT_FOUND) { vAdapters.push_back(pAdapter); ++i; }
		/// </code>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory-enumadapters HRESULT EnumAdapters( UINT Adapter,
		// [out] IDXGIAdapter **ppAdapter );
		[PreserveSig]
		new HRESULT EnumAdapters(uint Adapter, out IDXGIAdapter? ppAdapter);

		/// <summary>
		/// Allows DXGI to monitor an application's message queue for the alt-enter key sequence (which causes the application to switch
		/// from windowed to full screen or vice versa).
		/// </summary>
		/// <param name="WindowHandle">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the window that is to be monitored. This parameter can be <c>NULL</c>; but only if the flags are also 0.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>One or more of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// DXGI_MWA_NO_WINDOW_CHANGES - Prevent DXGI from monitoring an applications message queue; this makes DXGI unable to respond to
		/// mode changes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DXGI_MWA_NO_ALT_ENTER - Prevent DXGI from responding to an alt-enter sequence.</term>
		/// </item>
		/// <item>
		/// <term>DXGI_MWA_NO_PRINT_SCREEN - Prevent DXGI from responding to a print-screen key.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para><c>Note</c> If you call this API in a Session 0 process, it returns DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.</para>
		/// <para>
		/// The combination of WindowHandle and Flags informs DXGI to stop monitoring window messages for the previously-associated window.
		/// </para>
		/// <para>
		/// If the application switches to full-screen mode, DXGI will choose a full-screen resolution to be the smallest supported
		/// resolution that is larger or the same size as the current back buffer size.
		/// </para>
		/// <para>
		/// Applications can make some changes to make the transition from windowed to full screen more efficient. For example, on a WM_SIZE
		/// message, the application should release any outstanding swap-chain back buffers, call IDXGISwapChain::ResizeBuffers, then
		/// re-acquire the back buffers from the swap chain(s). This gives the swap chain(s) an opportunity to resize the back buffers,
		/// and/or recreate them to enable full-screen flipping operation. If the application does not perform this sequence, DXGI will
		/// still make the full-screen/windowed transition, but may be forced to use a stretch operation (since the back buffers may not be
		/// the correct size), which may be less efficient. Even if a stretch is not required, presentation may not be optimal because the
		/// back buffers might not be directly interchangeable with the front buffer. Thus, a call to <c>ResizeBuffers</c> on WM_SIZE is
		/// always recommended, since WM_SIZE is always sent during a fullscreen transition.
		/// </para>
		/// <para>
		/// While windowed, the application can, if it chooses, restrict the size of its window's client area to sizes to which it is
		/// comfortable rendering. A fully flexible application would make no such restriction, but UI elements or other design
		/// considerations can, of course, make this flexibility untenable. If the application further chooses to restrict its window's
		/// client area to just those that match supported full-screen resolutions, the application can field WM_SIZING, then check against
		/// IDXGIOutput::FindClosestMatchingMode. If a matching mode is found, allow the resize. (The IDXGIOutput can be retrieved from
		/// IDXGISwapChain::GetContainingOutput. Absent subsequent changes to desktop topology, this will be the same output that will be
		/// chosen when alt-enter is fielded and fullscreen mode is begun for that swap chain.)
		/// </para>
		/// <para>
		/// Applications that want to handle mode changes or Alt+Enter themselves should call <c>MakeWindowAssociation</c> with the
		/// DXGI_MWA_NO_WINDOW_CHANGES flag after swap chain creation. The WindowHandle argument, if non- <c>NULL</c>, specifies that the
		/// application message queues will not be handled by the DXGI runtime for all swap chains of a particular target HWND. Calling
		/// <c>MakeWindowAssociation</c> with the DXGI_MWA_NO_WINDOW_CHANGES flag after swapchain creation ensures that DXGI will not
		/// interfere with application's handling of window mode changes or Alt+Enter.
		/// </para>
		/// <para>Notes for Windows Store apps</para>
		/// <para>If a Windows Store app calls <c>MakeWindowAssociation</c>, it fails with DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.</para>
		/// <para>
		/// A Microsoft Win32 application can use <c>MakeWindowAssociation</c> to control full-screen transitions through the Alt+Enter key
		/// combination and print screen behavior for full screen. For Windows Store apps, because DXGI can't perform full-screen
		/// transitions, a Windows Store app has no way to control full-screen transitions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory-makewindowassociation HRESULT MakeWindowAssociation(
		// HWND WindowHandle, UINT Flags );
		new void MakeWindowAssociation(HWND WindowHandle, DXGI_MWA Flags);

		/// <summary>Get the window through which the user controls the transition to and from full screen.</summary>
		/// <returns>
		/// <para>Type: <c>HWND*</c></para>
		/// <para>A pointer to a window handle.</para>
		/// </returns>
		/// <remarks><c>Note</c> If you call this API in a Session 0 process, it returns DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory-getwindowassociation HRESULT GetWindowAssociation(
		// HWND *pWindowHandle );
		new HWND GetWindowAssociation();

		/// <summary>
		/// <para>
		/// [Starting with Direct3D 11.1, we recommend not to use <c>CreateSwapChain</c> anymore to create a swap chain. Instead, use
		/// CreateSwapChainForHwnd, CreateSwapChainForCoreWindow, or CreateSwapChainForComposition depending on how you want to create the
		/// swap chain.]
		/// </para>
		/// <para>Creates a swap chain.</para>
		/// </summary>
		/// <param name="pDevice">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// For Direct3D 11, and earlier versions of Direct3D, this is a pointer to the Direct3D device for the swap chain. For Direct3D 12
		/// this is a pointer to a direct command queue (refer to ID3D12CommandQueue) . This parameter cannot be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>DXGI_SWAP_CHAIN_DESC*</c></para>
		/// <para>A pointer to a DXGI_SWAP_CHAIN_DESC structure for the swap-chain description. This parameter cannot be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDXGISwapChain**</c></para>
		/// <para>
		/// A pointer to a variable that receives a pointer to the IDXGISwapChain interface for the swap chain that <c>CreateSwapChain</c> creates.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para><c>Note</c> If you call this API in a Session 0 process, it returns DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.</para>
		/// <para>
		/// If you attempt to create a swap chain in full-screen mode, and full-screen mode is unavailable, the swap chain will be created
		/// in windowed mode and DXGI_STATUS_OCCLUDED will be returned.
		/// </para>
		/// <para>
		/// If the buffer width or the buffer height is zero, the sizes will be inferred from the output window size in the swap-chain description.
		/// </para>
		/// <para>
		/// Because the target output can't be chosen explicitly when the swap chain is created, we recommend not to create a full-screen
		/// swap chain. This can reduce presentation performance if the swap chain size and the output window size do not match. Here are
		/// two ways to ensure that the sizes match:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Create a windowed swap chain and then set it full-screen using IDXGISwapChain::SetFullscreenState.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Save a pointer to the swap chain immediately after creation, and use it to get the output window size during a WM_SIZE event.
		/// Then resize the swap chain buffers (with IDXGISwapChain::ResizeBuffers) during the transition from windowed to full-screen.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the swap chain is in full-screen mode, before you release it you must use SetFullscreenState to switch it to windowed mode.
		/// For more information about releasing a swap chain, see the "Destroying a Swap Chain" section of DXGI Overview.
		/// </para>
		/// <para>
		/// After the runtime renders the initial frame in full screen, the runtime might unexpectedly exit full screen during a call to
		/// IDXGISwapChain::Present. To work around this issue, we recommend that you execute the following code right after you call
		/// <c>CreateSwapChain</c> to create a full-screen swap chain ( <c>Windowed</c> member of DXGI_SWAP_CHAIN_DESC set to <c>FALSE</c>).
		/// </para>
		/// <para>
		/// You can specify DXGI_SWAP_EFFECT and DXGI_SWAP_CHAIN_FLAG values in the swap-chain description that pDesc points to. These
		/// values allow you to use features like flip-model presentation and content protection by using pre-Windows 8 APIs.
		/// </para>
		/// <para>
		/// However, to use stereo presentation and to change resize behavior for the flip model, applications must use the
		/// IDXGIFactory2::CreateSwapChainForHwnd method. Otherwise, the back-buffer contents implicitly scale to fit the presentation
		/// target size; that is, you can't turn off scaling.
		/// </para>
		/// <para>Notes for Windows Store apps</para>
		/// <para>If a Windows Store app calls <c>CreateSwapChain</c> with full screen specified, <c>CreateSwapChain</c> fails.</para>
		/// <para>Windows Store apps call the IDXGIFactory2::CreateSwapChainForCoreWindow method to create a swap chain.</para>
		/// <para>For info about how to choose a format for the swap chain's back buffer, see Converting data for the color space.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory-createswapchain HRESULT CreateSwapChain( IUnknown
		// *pDevice, DXGI_SWAP_CHAIN_DESC *pDesc, IDXGISwapChain **ppSwapChain );
		new IDXGISwapChain CreateSwapChain([In, MarshalAs(UnmanagedType.Interface)] object pDevice, in DXGI_SWAP_CHAIN_DESC pDesc);

		/// <summary>Create an adapter interface that represents a software adapter.</summary>
		/// <param name="Module">
		/// <para>Type: <c>HMODULE</c></para>
		/// <para>Handle to the software adapter's dll. HMODULE can be obtained with GetModuleHandle or LoadLibrary.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDXGIAdapter**</c></para>
		/// <para>Address of a pointer to an adapter (see IDXGIAdapter).</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A software adapter is a DLL that implements the entirety of a device driver interface, plus emulation, if necessary, of
		/// kernel-mode graphics components for Windows. Details on implementing a software adapter can be found in the Windows Vista Driver
		/// Development Kit. This is a very complex development task, and is not recommended for general readers.
		/// </para>
		/// <para>
		/// Calling this method will increment the module's reference count by one. The reference count can be decremented by calling FreeLibrary.
		/// </para>
		/// <para>
		/// The typical calling scenario is to call LoadLibrary, pass the handle to <c>CreateSoftwareAdapter</c>, then immediately call
		/// FreeLibrary on the DLL and forget the DLL's HMODULE. Since the software adapter calls <c>FreeLibrary</c> when it is destroyed,
		/// the lifetime of the DLL will now be owned by the adapter, and the application is free of any further consideration of its lifetime.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory-createsoftwareadapter HRESULT CreateSoftwareAdapter(
		// HMODULE Module, IDXGIAdapter **ppAdapter );
		new IDXGIAdapter CreateSoftwareAdapter(HINSTANCE Module);

		/// <summary>Enumerates both adapters (video cards) with or without outputs.</summary>
		/// <param name="Adapter">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The index of the adapter to enumerate.</para>
		/// </param>
		/// <param name="ppAdapter">
		/// <para>Type: <b><c>IDXGIAdapter1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDXGIAdapter1</c> interface at the position specified by the <i>Adapter</i> parameter. This
		/// parameter must not be <b>NULL</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns S_OK if successful; otherwise, returns <c>DXGI_ERROR_NOT_FOUND</c> if the index is greater than or equal to the number
		/// of adapters in the local system, or <c>DXGI_ERROR_INVALID_CALL</c> if <i>ppAdapter</i> parameter is <b>NULL</b>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
		/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) ( <c>KB
		/// 971644</c>) and Windows Server 2008 ( <c>KB 971512</c>).
		/// </para>
		/// <para>
		/// When you create a factory, the factory enumerates the set of adapters that are available in the system. Therefore, if you change
		/// the adapters in a system, you must destroy and recreate the <c>IDXGIFactory1</c> object. The number of adapters in a system
		/// changes when you add or remove a display card, or dock or undock a laptop.
		/// </para>
		/// <para>
		/// When the <b>EnumAdapters1</b> method succeeds and fills the <i>ppAdapter</i> parameter with the address of the pointer to the
		/// adapter interface, <b>EnumAdapters1</b> increments the adapter interface's reference count. When you finish using the adapter
		/// interface, call the <c>Release</c> method to decrement the reference count before you destroy the pointer.
		/// </para>
		/// <para>
		/// <b>EnumAdapters1</b> first returns the adapter with the output on which the desktop primary is displayed. This adapter
		/// corresponds with an index of zero. <b>EnumAdapters1</b> next returns other adapters with outputs. <b>EnumAdapters1</b> finally
		/// returns adapters without outputs.
		/// </para>
		/// <para>Examples</para>
		/// <para>Enumerating Adapters</para>
		/// <para>The following code example demonstrates how to enumerate adapters using the <b>EnumAdapters1</b> method.</para>
		/// <para>
		/// <c>UINT i = 0; IDXGIAdapter1 * pAdapter; std::vector &lt;IDXGIAdapter1*&gt; vAdapters; while(pFactory-&gt;EnumAdapters1(i,
		/// &amp;pAdapter) != DXGI_ERROR_NOT_FOUND) { vAdapters.push_back(pAdapter); ++i; }</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory1-enumadapters1 HRESULT EnumAdapters1( UINT Adapter,
		// [out] IDXGIAdapter1 **ppAdapter );
		[PreserveSig]
		new HRESULT EnumAdapters1(uint Adapter, out IDXGIAdapter1? ppAdapter);

		/// <summary>Informs an application of the possible need to re-enumerate adapters.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>FALSE</c>, if a new adapter is becoming available or the current adapter is going away. <c>TRUE</c>, no adapter changes.</para>
		/// <para><c>IsCurrent</c> returns <c>FALSE</c> to inform the calling application to re-enumerate adapters.</para>
		/// </returns>
		/// <remarks>
		/// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
		/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644)
		/// and Windows Server 2008 (KB 971512).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory1-iscurrent BOOL IsCurrent();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsCurrent();

		/// <summary>Determines whether to use stereo mode.</summary>
		/// <returns>
		/// <para>Indicates whether to use stereo mode. <b>TRUE</b> indicates that you can use stereo mode; otherwise, <b>FALSE</b>.</para>
		/// <para>
		/// <b>Platform Update for Windows 7:  </b> On Windows 7 or Windows Server 2008 R2 with the <c>Platform Update for Windows 7</c>
		/// installed, <b>IsWindowedStereoEnabled</b> always returns FALSE because stereoscopic 3D display behavior isn’t available with the
		/// Platform Update for Windows 7. For more info about the Platform Update for Windows 7, see <c>Platform Update for Windows 7</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// We recommend that windowed applications call <b>IsWindowedStereoEnabled</b> before they attempt to use stereo.
		/// <b>IsWindowedStereoEnabled</b> returns <b>TRUE</b> if both of the following items are true:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// All adapters in the computer have drivers that are capable of stereo. This only means that the driver is implemented to the
		/// Windows Display Driver Model (WDDM) for Windows 8 (WDDM 1.2). However, the adapter does not necessarily have to be able to scan
		/// out stereo.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The current desktop mode (desktop modes are mono) and system policy and hardware are configured so that the Desktop Window
		/// Manager (DWM) performs stereo composition on at least one adapter output.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// The creation of a windowed stereo swap chain succeeds if the first requirement is met. However, if the adapter can't scan out
		/// stereo, the output on that adapter is reduced to mono.
		/// </para>
		/// <para>
		/// The <c>Direct3D 11.1 Simple Stereo 3D Sample</c> shows how to add a stereoscopic 3D effect and how to respond to system stereo changes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-iswindowedstereoenabled BOOL IsWindowedStereoEnabled();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsWindowedStereoEnabled();

		/// <summary>Creates a swap chain that is associated with an <c>HWND</c> handle to the output window for the swap chain.</summary>
		/// <param name="pDevice">
		/// For Direct3D 11, and earlier versions of Direct3D, this is a pointer to the Direct3D device for the swap chain. For Direct3D 12
		/// this is a pointer to a direct command queue (refer to <c>ID3D12CommandQueue</c>). This parameter cannot be <b>NULL</b>.
		/// </param>
		/// <param name="hWnd">
		/// The <c>HWND</c> handle that is associated with the swap chain that <b>CreateSwapChainForHwnd</b> creates. This parameter cannot
		/// be <b>NULL</b>.
		/// </param>
		/// <param name="pDesc">
		/// A pointer to a <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description. This parameter cannot be <b>NULL</b>.
		/// </param>
		/// <param name="pFullscreenDesc">
		/// A pointer to a <c>DXGI_SWAP_CHAIN_FULLSCREEN_DESC</c> structure for the description of a full-screen swap chain. You can
		/// optionally set this parameter to create a full-screen swap chain. Set it to <b>NULL</b> to create a windowed swap chain.
		/// </param>
		/// <param name="pRestrictToOutput">
		/// <para>
		/// A pointer to the <c>IDXGIOutput</c> interface for the output to restrict content to. You must also pass the
		/// <c>DXGI_PRESENT_RESTRICT_TO_OUTPUT</c> flag in a <c>IDXGISwapChain1::Present1</c> call to force the content to appear blacked
		/// out on any other output. If you want to restrict the content to a different output, you must create a new swap chain. However,
		/// you can conditionally restrict content based on the <b>DXGI_PRESENT_RESTRICT_TO_OUTPUT</b> flag.
		/// </para>
		/// <para>Set this parameter to <b>NULL</b> if you don't want to restrict content to an output target.</para>
		/// </param>
		/// <returns>
		/// A pointer to a variable that receives a pointer to the <c>IDXGISwapChain1</c> interface for the swap chain that
		/// <b>CreateSwapChainForHwnd</b> creates.
		/// </returns>
		/// <remarks>
		/// <para><b>Note</b>  Do not use this method in Windows Store apps. Instead, use <c>IDXGIFactory2::CreateSwapChainForCoreWindow</c>.</para>
		/// <para></para>
		/// <para>
		/// If you specify the width, height, or both ( <b>Width</b> and <b>Height</b> members of <c>DXGI_SWAP_CHAIN_DESC1</c> that
		/// <i>pDesc</i> points to) of the swap chain as zero, the runtime obtains the size from the output window that the <i>hWnd</i>
		/// parameter specifies.
		/// </para>
		/// <para>You can subsequently call the <c>IDXGISwapChain1::GetDesc1</c> method to retrieve the assigned width or height value.</para>
		/// <para>
		/// Because you can associate only one flip presentation model swap chain at a time with an <c>HWND</c>, the Microsoft Direct3D 11
		/// policy of deferring the destruction of objects can cause problems if you attempt to destroy a flip presentation model swap chain
		/// and replace it with another swap chain. For more info about this situation, see <c>Deferred Destruction Issues with Flip
		/// Presentation Swap Chains</c>.
		/// </para>
		/// <para>For info about how to choose a format for the swap chain's back buffer, see <c>Converting data for the color space</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforhwnd HRESULT
		// CreateSwapChainForHwnd( [in] IUnknown *pDevice, [in] HWND hWnd, [in] const DXGI_SWAP_CHAIN_DESC1 *pDesc, [in, optional] const
		// DXGI_SWAP_CHAIN_FULLSCREEN_DESC *pFullscreenDesc, [in, optional] IDXGIOutput *pRestrictToOutput, [out] IDXGISwapChain1
		// **ppSwapChain );
		new IDXGISwapChain1 CreateSwapChainForHwnd([In, MarshalAs(UnmanagedType.IUnknown)] object pDevice, HWND hWnd, in DXGI_SWAP_CHAIN_DESC1 pDesc,
			[In, Optional] StructPointer<DXGI_SWAP_CHAIN_FULLSCREEN_DESC> pFullscreenDesc, [In, Optional] IDXGIOutput? pRestrictToOutput);

		/// <summary>Creates a swap chain that is associated with the <c>CoreWindow</c> object for the output window for the swap chain.</summary>
		/// <param name="pDevice">
		/// For Direct3D 11, and earlier versions of Direct3D, this is a pointer to the Direct3D device for the swap chain. For Direct3D 12
		/// this is a pointer to a direct command queue (refer to <c>ID3D12CommandQueue</c>). This parameter cannot be <b>NULL</b>.
		/// </param>
		/// <param name="pWindow">
		/// A pointer to the <c>CoreWindow</c> object that is associated with the swap chain that <b>CreateSwapChainForCoreWindow</b> creates.
		/// </param>
		/// <param name="pDesc">
		/// A pointer to a <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description. This parameter cannot be <b>NULL</b>.
		/// </param>
		/// <param name="pRestrictToOutput">
		/// A pointer to the <c>IDXGIOutput</c> interface that the swap chain is restricted to. If the swap chain is moved to a different
		/// output, the content is black. You can optionally set this parameter to an output target that uses
		/// <c>DXGI_PRESENT_RESTRICT_TO_OUTPUT</c> to restrict the content on this output. If you do not set this parameter to restrict
		/// content on an output target, you can set it to <b>NULL</b>.
		/// </param>
		/// <returns>
		/// A pointer to a variable that receives a pointer to the <c>IDXGISwapChain1</c> interface for the swap chain that
		/// <b>CreateSwapChainForCoreWindow</b> creates.
		/// </returns>
		/// <remarks>
		/// <para><b>Note</b>  Use this method in Windows Store apps rather than <c>IDXGIFactory2::CreateSwapChainForHwnd</c>.</para>
		/// <para></para>
		/// <para>
		/// If you specify the width, height, or both ( <b>Width</b> and <b>Height</b> members of <c>DXGI_SWAP_CHAIN_DESC1</c> that
		/// <i>pDesc</i> points to) of the swap chain as zero, the runtime obtains the size from the output window that the <i>pWindow</i>
		/// parameter specifies.
		/// </para>
		/// <para>You can subsequently call the <c>IDXGISwapChain1::GetDesc1</c> method to retrieve the assigned width or height value.</para>
		/// <para>
		/// Because you can associate only one flip presentation model swap chain (per layer) at a time with a <c>CoreWindow</c>, the
		/// Microsoft Direct3D 11 policy of deferring the destruction of objects can cause problems if you attempt to destroy a flip
		/// presentation model swap chain and replace it with another swap chain. For more info about this situation, see <c>Deferred
		/// Destruction Issues with Flip Presentation Swap Chains</c>.
		/// </para>
		/// <para>For info about how to choose a format for the swap chain's back buffer, see <c>Converting data for the color space</c>.</para>
		/// <para><c></c><c></c><c></c> Overlapping swap chains</para>
		/// <para>
		/// Starting with Windows 8.1, it is possible to create an additional swap chain in the foreground layer. A foreground swap chain
		/// can be used to render UI elements at native resolution while scaling up real-time rendering in the background swap chain (such
		/// as gameplay). This enables scenarios where lower resolution rendering is required for faster fill rates, but without sacrificing
		/// UI quality.
		/// </para>
		/// <para>
		/// Foreground swap chains are created by setting the <b>DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER</b> swap chain flag in the
		/// <c>DXGI_SWAP_CHAIN_DESC1</c> that <i>pDesc</i> points to. Foreground swap chains must also use the
		/// <b>DXGI_ALPHA_MODE_PREMULTIPLIED</b> alpha mode, and must use <b>DXGI_SCALING_NONE</b>. Premultiplied alpha means that each
		/// pixel's color values are expected to be already multiplied by the alpha value before the frame is presented. For example, a 100%
		/// white BGRA pixel at 50% alpha is set to (0.5, 0.5, 0.5, 0.5). The alpha premultiplication step can be done in the output-merger
		/// stage by applying an app blend state (see <c>ID3D11BlendState</c>) with the <c>D3D11_RENDER_TARGET_BLEND_DESC</c> structure's
		/// <b>SrcBlend</b> field set to <b>D3D11_SRC_ALPHA</b>. If the alpha premultiplication step is not done, colors on the foreground
		/// swap chain will be brighter than expected.
		/// </para>
		/// <para>
		/// The foreground swap chain will use multiplane overlays if supported by the hardware. Call <c>IDXGIOutput2::SupportsOverlays</c>
		/// to query the adapter for overlay support.
		/// </para>
		/// <para>The following example creates a foreground swap chain for a CoreWindow:</para>
		/// <para>
		/// <c>DXGI_SWAP_CHAIN_DESC1 swapChainDesc = { 0 }; swapChainDesc.Width = static_cast&lt;UINT&gt;(m_d3dRenderTargetSize.Width);
		/// swapChainDesc.Height = static_cast&lt;UINT&gt;(m_d3dRenderTargetSize.Height); swapChainDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM;
		/// swapChainDesc.Stereo = false; swapChainDesc.SampleDesc.Count = 1; // Don't use multi-sampling. swapChainDesc.SampleDesc.Quality
		/// = 0; swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT; swapChainDesc.BufferCount = 2; swapChainDesc.SwapEffect =
		/// DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL; swapChainDesc.Flags = DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER; swapChainDesc.AlphaMode =
		/// DXGI_ALPHA_MODE_PREMULTIPLIED; swapChainDesc.Scaling = DXGI_SCALING_NONE; ComPtr&lt;IDXGISwapChain1&gt; swapChain; HRESULT hr =
		/// dxgiFactory-&gt;CreateSwapChainForCoreWindow( m_d3dDevice.Get(), reinterpret_cast&lt;IUnknown*&gt;(m_window.Get()),
		/// &amp;swapChainDesc, nullptr, &amp;swapChain );</c>
		/// </para>
		/// <para>Present both swap chains together after rendering is complete.</para>
		/// <para>The following example presents both swap chains:</para>
		/// <para>
		/// <c>HRESULT hr = m_swapChain-&gt;Present(1, 0); if (SUCCEEDED(hr) &amp;&amp; m_foregroundSwapChain) {
		/// m_foregroundSwapChain-&gt;Present(1, 0); }</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcorewindow HRESULT
		// CreateSwapChainForCoreWindow( [in] IUnknown *pDevice, [in] IUnknown *pWindow, [in] const DXGI_SWAP_CHAIN_DESC1 *pDesc, [in,
		// optional] IDXGIOutput *pRestrictToOutput, [out] IDXGISwapChain1 **ppSwapChain );
		new IDXGISwapChain1 CreateSwapChainForCoreWindow([In, MarshalAs(UnmanagedType.IUnknown)] object pDevice, [In, MarshalAs(UnmanagedType.IUnknown)] object pWindow,
			in DXGI_SWAP_CHAIN_DESC1 pDesc, [In, Optional] IDXGIOutput? pRestrictToOutput);

		/// <summary>Identifies the adapter on which a shared resource object was created.</summary>
		/// <param name="hResource">
		/// A handle to a shared resource object. The <c>IDXGIResource1::CreateSharedHandle</c> method returns this handle.
		/// </param>
		/// <returns>
		/// A pointer to a variable that receives a locally unique identifier ( <c>LUID</c>) value that identifies the adapter. <b>LUID</b>
		/// is defined in Dxgi.h. An <b>LUID</b> is a 64-bit value that is guaranteed to be unique only on the operating system on which it
		/// was generated. The uniqueness of an <b>LUID</b> is guaranteed only until the operating system is restarted.
		/// </returns>
		/// <remarks>
		/// <para>
		/// You cannot share resources across adapters. Therefore, you cannot open a shared resource on an adapter other than the adapter on
		/// which the resource was created. Call <b>GetSharedResourceAdapterLuid</b> before you open a shared resource to ensure that the
		/// resource was created on the appropriate adapter. To open a shared resource, call the <c>ID3D11Device1::OpenSharedResource1</c>
		/// or <c>ID3D11Device1::OpenSharedResourceByName</c> method.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// <c>HANDLE handle; IDXGIFactory2* pFactory; LUID luid; pFactory-&gt;GetSharedResourceAdapterLuid (handle, &amp;luid); UINT index
		/// = 0; IDXGIAdapter* pAdapter = NULL; while (SUCCEEDED(pFactory-&gt;EnumAdapters(index, &amp;pAdapter))) { DXGI_ADAPTER_DESC desc;
		/// pAdapter-&gt;GetDesc(&amp;desc); if (desc.AdapterLuid == luid) { // Identified a matching adapter. break; }
		/// pAdapter-&gt;Release(); pAdapter = NULL; index++; } // At this point, if pAdapter is non-null, you identified an adapter that //
		/// can open the shared resource.</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-getsharedresourceadapterluid HRESULT
		// GetSharedResourceAdapterLuid( [in] HANDLE hResource, [out] LUID *pLuid );
		new LUID GetSharedResourceAdapterLuid([In] HANDLE hResource);

		/// <summary>Registers an application window to receive notification messages of changes of stereo status.</summary>
		/// <param name="WindowHandle">The handle of the window to send a notification message to when stereo status change occurs.</param>
		/// <param name="wMsg">Identifies the notification message to send.</param>
		/// <returns>
		/// A pointer to a key value that an application can pass to the <c>IDXGIFactory2::UnregisterStereoStatus</c> method to unregister
		/// the notification message that <i>wMsg</i> specifies.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-registerstereostatuswindow HRESULT
		// RegisterStereoStatusWindow( [in] HWND WindowHandle, [in] UINT wMsg, [out] DWORD *pdwCookie );
		new uint RegisterStereoStatusWindow(HWND WindowHandle, uint wMsg);

		/// <summary>Registers to receive notification of changes in stereo status by using event signaling.</summary>
		/// <param name="hEvent">
		/// A handle to the event object that the operating system sets when notification of stereo status change occurs. The
		/// <c>CreateEvent</c> or <c>OpenEvent</c> function returns this handle.
		/// </param>
		/// <returns>
		/// A pointer to a key value that an application can pass to the <c>IDXGIFactory2::UnregisterStereoStatus</c> method to unregister
		/// the notification event that <i>hEvent</i> specifies.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-registerstereostatusevent HRESULT
		// RegisterStereoStatusEvent( [in] HANDLE hEvent, [out] DWORD *pdwCookie );
		new uint RegisterStereoStatusEvent(HEVENT hEvent);

		/// <summary>Unregisters a window or an event to stop it from receiving notification when stereo status changes.</summary>
		/// <param name="dwCookie">
		/// A key value for the window or event to unregister. The <c>IDXGIFactory2::RegisterStereoStatusWindow</c> or
		/// <c>IDXGIFactory2::RegisterStereoStatusEvent</c> method returns this value.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <b>Platform Update for Windows 7:  </b> On Windows 7 or Windows Server 2008 R2 with the <c>Platform Update for Windows 7</c>
		/// installed, <b>UnregisterStereoStatus</b> has no effect. For more info about the Platform Update for Windows 7, see <c>Platform
		/// Update for Windows 7</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-unregisterstereostatus void
		// UnregisterStereoStatus( [in] DWORD dwCookie );
		[PreserveSig]
		new void UnregisterStereoStatus(uint dwCookie);

		/// <summary>Registers an application window to receive notification messages of changes of occlusion status.</summary>
		/// <param name="WindowHandle">The handle of the window to send a notification message to when occlusion status change occurs.</param>
		/// <param name="wMsg">Identifies the notification message to send.</param>
		/// <returns>
		/// A pointer to a key value that an application can pass to the <c>IDXGIFactory2::UnregisterOcclusionStatus</c> method to
		/// unregister the notification message that <i>wMsg</i> specifies.
		/// </returns>
		/// <remarks>Apps choose the Windows message that Windows sends when occlusion status changes.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-registerocclusionstatuswindow HRESULT
		// RegisterOcclusionStatusWindow( [in] HWND WindowHandle, [in] UINT wMsg, [out] DWORD *pdwCookie );
		new uint RegisterOcclusionStatusWindow([In] HWND WindowHandle, uint wMsg);

		/// <summary>Registers to receive notification of changes in occlusion status by using event signaling.</summary>
		/// <param name="hEvent">
		/// A handle to the event object that the operating system sets when notification of occlusion status change occurs. The
		/// <c>CreateEvent</c> or <c>OpenEvent</c> function returns this handle.
		/// </param>
		/// <returns>
		/// A pointer to a key value that an application can pass to the <c>IDXGIFactory2::UnregisterOcclusionStatus</c> method to
		/// unregister the notification event that <i>hEvent</i> specifies.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call <b>RegisterOcclusionStatusEvent</b> multiple times with the same event handle, <b>RegisterOcclusionStatusEvent</b>
		/// fails with <c>DXGI_ERROR_INVALID_CALL</c>.
		/// </para>
		/// <para>
		/// If you call <b>RegisterOcclusionStatusEvent</b> multiple times with the different event handles,
		/// <b>RegisterOcclusionStatusEvent</b> properly registers the events.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-registerocclusionstatusevent HRESULT
		// RegisterOcclusionStatusEvent( [in] HANDLE hEvent, [out] DWORD *pdwCookie );
		new uint RegisterOcclusionStatusEvent([In] HEVENT hEvent);

		/// <summary>Unregisters a window or an event to stop it from receiving notification when occlusion status changes.</summary>
		/// <param name="dwCookie">
		/// A key value for the window or event to unregister. The <c>IDXGIFactory2::RegisterOcclusionStatusWindow</c> or
		/// <c>IDXGIFactory2::RegisterOcclusionStatusEvent</c> method returns this value.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <b>Platform Update for Windows 7:  </b> On Windows 7 or Windows Server 2008 R2 with the <c>Platform Update for Windows 7</c>
		/// installed, <b>UnregisterOcclusionStatus</b> has no effect. For more info about the Platform Update for Windows 7, see
		/// <c>Platform Update for Windows 7</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-unregisterocclusionstatus void
		// UnregisterOcclusionStatus( [in] DWORD dwCookie );
		[PreserveSig]
		new void UnregisterOcclusionStatus(uint dwCookie);

		/// <summary>
		/// Creates a swap chain that you can use to send Direct3D content into the <c>DirectComposition</c> API, to the
		/// <c>Windows.UI.Xaml</c> framework, or to <c>Windows UI Library (WinUI)</c> XAML, to compose in a window.
		/// </summary>
		/// <param name="pDevice">
		/// For Direct3D 11, and earlier versions of Direct3D, this is a pointer to the Direct3D device for the swap chain. For Direct3D 12
		/// this is a pointer to a direct command queue (refer to <c>ID3D12CommandQueue</c>). This parameter cannot be <b>NULL</b>. Software
		/// drivers, like <c>D3D_DRIVER_TYPE_REFERENCE</c>, are not supported for composition swap chains.
		/// </param>
		/// <param name="pDesc">
		/// <para>A pointer to a <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description. This parameter cannot be <b>NULL</b>.</para>
		/// <para>
		/// You must specify the <c>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</c> value in the <b>SwapEffect</b> member of
		/// <c>DXGI_SWAP_CHAIN_DESC1</c> because <b>CreateSwapChainForComposition</b> supports only <c>flip presentation model</c>.
		/// </para>
		/// <para>You must also specify the <c>DXGI_SCALING_STRETCH</c> value in the <b>Scaling</b> member of <c>DXGI_SWAP_CHAIN_DESC1</c>.</para>
		/// </param>
		/// <param name="pRestrictToOutput">
		/// <para>
		/// A pointer to the <c>IDXGIOutput</c> interface for the output to restrict content to. You must also pass the
		/// <c>DXGI_PRESENT_RESTRICT_TO_OUTPUT</c> flag in a <c>IDXGISwapChain1::Present1</c> call to force the content to appear blacked
		/// out on any other output. If you want to restrict the content to a different output, you must create a new swap chain. However,
		/// you can conditionally restrict content based on the <b>DXGI_PRESENT_RESTRICT_TO_OUTPUT</b> flag.
		/// </para>
		/// <para>Set this parameter to <b>NULL</b> if you don't want to restrict content to an output target.</para>
		/// </param>
		/// <returns>
		/// A pointer to a variable that receives a pointer to the <c>IDXGISwapChain1</c> interface for the swap chain that
		/// <b>CreateSwapChainForComposition</b> creates.
		/// </returns>
		/// <remarks>
		/// <para>You can use composition swap chains with either:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>DirectComposition</c>'s <c>IDCompositionVisual</c> interface,</description>
		/// </item>
		/// <item>
		/// <description>System XAML's <c>SwapChainPanel</c> or <c>SwapChainBackgroundPanel</c> classes.</description>
		/// </item>
		/// <item>
		/// <description><c>Windows UI Library (WinUI) 3</c> XAML's <c>SwapChainPanel</c> or <c>SwapChainBackgroundPanel</c> classes.</description>
		/// </item>
		/// </list>
		/// <para>
		/// For DirectComposition, you can call the <c>IDCompositionVisual::SetContent</c> method to set the swap chain as the content of a
		/// <c>visual object</c>, which then allows you to bind the swap chain to the visual tree. For XAML, the
		/// <b>SwapChainBackgroundPanel</b> class exposes a classic COM interface <b>ISwapChainBackgroundPanelNative</b>. You can use the
		/// <c>ISwapChainBackgroundPanelNative::SetSwapChain</c> method to bind to the XAML UI graph. For info about how to use composition
		/// swap chains with XAML’s <b>SwapChainBackgroundPanel</b> class, see <c>DirectX and XAML interop</c>.
		/// </para>
		/// <para>
		/// The <c>IDXGISwapChain::SetFullscreenState</c>, <c>IDXGISwapChain::ResizeTarget</c>, <c>IDXGISwapChain::GetContainingOutput</c>,
		/// <c>IDXGISwapChain1::GetHwnd</c>, and <c>IDXGISwapChain::GetCoreWindow</c> methods aren't valid on this type of swap chain. If
		/// you call any of these methods on this type of swap chain, they fail.
		/// </para>
		/// <para>For info about how to choose a format for the swap chain's back buffer, see <c>Converting data for the color space</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-createswapchainforcomposition HRESULT
		// CreateSwapChainForComposition( [in] IUnknown *pDevice, [in] const DXGI_SWAP_CHAIN_DESC1 *pDesc, [in, optional] IDXGIOutput
		// *pRestrictToOutput, [out] IDXGISwapChain1 **ppSwapChain );
		new IDXGISwapChain1 CreateSwapChainForComposition([MarshalAs(UnmanagedType.IUnknown)] object pDevice, in DXGI_SWAP_CHAIN_DESC1 pDesc,
			[In, Optional] IDXGIOutput? pRestrictToOutput);

		/// <summary>Gets the flags that were used when a Microsoft DirectX Graphics Infrastructure (DXGI) object was created.</summary>
		/// <returns>The creation flags.</returns>
		/// <remarks>
		/// The <b>GetCreationFlags</b> method returns flags that were passed to the <see cref="CreateDXGIFactory2"/> function, or were
		/// implicitly constructed by <c>CreateDXGIFactory</c>, <c>CreateDXGIFactory1</c>, <c>D3D11CreateDevice</c>, or <c>D3D11CreateDeviceAndSwapChain</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgifactory3-getcreationflags UINT GetCreationFlags();
		[PreserveSig]
		new DXGI_CREATE_FACTORY GetCreationFlags();

		/// <summary>Outputs the <c>IDXGIAdapter</c> for the specified LUID.</summary>
		/// <param name="AdapterLuid">
		/// <para>Type: <b><c>LUID</c></b></para>
		/// <para>
		/// A unique value that identifies the adapter. See <c>LUID</c> for a definition of the structure. <b>LUID</b> is defined in dxgi.h.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier (GUID) of the <c>IDXGIAdapter</c> object referenced by the <i>ppvAdapter</i> parameter.</para>
		/// </param>
		/// <param name="ppvAdapter">
		/// <para>Type: <b>void**</b></para>
		/// <para>The address of an <c>IDXGIAdapter</c> interface pointer to the adapter. This parameter must not be NULL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>. See also Direct3D 12
		/// Return Codes.
		/// </para>
		/// </returns>
		/// <remarks>
		/// For Direct3D 12, it's no longer possible to backtrack from a device to the <c>IDXGIAdapter</c> that was used to create it.
		/// <b>IDXGIFactory4::EnumAdapterByLuid</b> enables an app to retrieve information about the adapter where a D3D12 device was
		/// created. <b>IDXGIFactory4::EnumAdapterByLuid</b> is designed to be paired with <c>ID3D12Device::GetAdapterLuid</c>. For more
		/// information, see <c>DXGI 1.4 Improvements</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgifactory4-enumadapterbyluid HRESULT EnumAdapterByLuid(
		// [in] LUID AdapterLuid, [in] REFIID riid, [out] void **ppvAdapter );
		[PreserveSig]
		new HRESULT EnumAdapterByLuid(LUID AdapterLuid, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvAdapter);

		/// <summary>Provides an adapter which can be provided to D3D12CreateDevice to use the WARP renderer.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier (GUID) of the <c>IDXGIAdapter</c> object referenced by the <i>ppvAdapter</i> parameter.</para>
		/// </param>
		/// <param name="ppvAdapter">
		/// <para>Type: <b>void**</b></para>
		/// <para>The address of an <c>IDXGIAdapter</c> interface pointer to the adapter. This parameter must not be NULL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>. See also Direct3D 12
		/// Return Codes.
		/// </para>
		/// </returns>
		/// <remarks>For more information, see <c>DXGI 1.4 Improvements</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgifactory4-enumwarpadapter HRESULT EnumWarpAdapter(
		// [in] REFIID riid, [out] void **ppvAdapter );
		[PreserveSig]
		new HRESULT EnumWarpAdapter(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvAdapter);

		/// <summary>Used to check for hardware feature support.</summary>
		/// <param name="Feature">
		/// <para>Type: <b><c>DXGI_FEATURE</c></b></para>
		/// <para>Specifies one member of <c>DXGI_FEATURE</c> to query support for.</para>
		/// </param>
		/// <param name="pFeatureSupportData">
		/// <para>Type: <b>void*</b></para>
		/// <para>Specifies a pointer to a buffer that will be filled with data that describes the feature support.</para>
		/// </param>
		/// <param name="FeatureSupportDataSize">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The size, in bytes, of <i>pFeatureSupportData</i>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		/// <remarks>Refer to the description of <c>DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_5/nf-dxgi1_5-idxgifactory5-checkfeaturesupport HRESULT
		// CheckFeatureSupport( DXGI_FEATURE Feature, [in, out] void *pFeatureSupportData, UINT FeatureSupportDataSize );
		[PreserveSig]
		new HRESULT CheckFeatureSupport(DXGI_FEATURE Feature, [In, Out] IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		/// <summary>Enumerates graphics adapters based on a given GPU preference.</summary>
		/// <param name="Adapter">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// The index of the adapter to enumerate. The indices are in order of the preference specified in <i>GpuPreference</i>—for example,
		/// if <b>DXGI_GPU_PREFERENCE_HIGH_PERFORMANCE</b> is specified, then the highest-performing adapter is at index 0, the
		/// second-highest is at index 1, and so on.
		/// </para>
		/// </param>
		/// <param name="GpuPreference">
		/// <para>Type: <b><c>DXGI_GPU_PREFERENCE</c></b></para>
		/// <para>The GPU preference for the app.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier (GUID) of the <c>IDXGIAdapter</c> object referenced by the <i>ppvAdapter</i> parameter.</para>
		/// </param>
		/// <param name="ppvAdapter">
		/// <para>Type: <b>void**</b></para>
		/// <para>The address of an <c>IDXGIAdapter</c> interface pointer to the adapter.</para>
		/// <para>This parameter must not be NULL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>Returns <b>S_OK</b> if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method allows developers to select which GPU they think is most appropriate for each device their app creates and utilizes.
		/// </para>
		/// <para>
		/// This method is similar to <c>IDXGIFactory1::EnumAdapters1</c>, but it accepts a GPU preference to reorder the adapter
		/// enumeration. It returns the appropriate <b>IDXGIAdapter</b> for the given GPU preference. It is meant to be used in conjunction
		/// with the <b>D3DCreateDevice</b> functions, which take in an <b>IDXGIAdapter</b>.
		/// </para>
		/// <para>
		/// When <b>DXGI_GPU_PREFERENCE_UNSPECIFIED</b> is specified for the <i>GpuPreference</i> parameter, this method is equivalent to
		/// calling <c>IDXGIFactory1::EnumAdapters1</c>.
		/// </para>
		/// <para>
		/// When <b>DXGI_GPU_PREFERENCE_MINIMUM_POWER</b> is specified for the <i>GpuPreference</i> parameter, the order of preference for
		/// the adapter returned in <i>ppvAdapter</i> will be:
		/// </para>
		/// <list/>
		/// <para>
		/// When <b>DXGI_GPU_PREFERENCE_HIGH_PERFORMANCE</b> is specified for the <i>GpuPreference</i> parameter, the order of preference
		/// for the adapter returned in <i>ppvAdapter</i> will be:
		/// </para>
		/// <list/>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nf-dxgi1_6-idxgifactory6-enumadapterbygpupreference HRESULT
		// EnumAdapterByGpuPreference( [in] UINT Adapter, [in] DXGI_GPU_PREFERENCE GpuPreference, [in] REFIID riid, [out] void **ppvAdapter );
		[PreserveSig]
		new HRESULT EnumAdapterByGpuPreference(uint Adapter, DXGI_GPU_PREFERENCE GpuPreference, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppvAdapter);

		/// <summary>Registers to receive notification of changes whenever the adapter enumeration state changes.</summary>
		/// <param name="hEvent">A handle to the event object.</param>
		/// <returns>A key value for the registered event.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nf-dxgi1_6-idxgifactory7-registeradapterschangedevent HRESULT
		// RegisterAdaptersChangedEvent( [in] HANDLE hEvent, [in, out] DWORD *pdwCookie );
		uint RegisterAdaptersChangedEvent(HEVENT hEvent);

		/// <summary>Unregisters an event to stop receiving notifications when the adapter enumeration state changes.</summary>
		/// <param name="dwCookie">A key value for the event to unregister.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nf-dxgi1_6-idxgifactory7-unregisteradapterschangedevent HRESULT
		// UnregisterAdaptersChangedEvent( [in] DWORD dwCookie );
		void UnregisterAdaptersChangedEvent(uint dwCookie);
	}

	/// <summary>
	/// Represents an adapter output (such as a monitor). The <b>IDXGIOutput6</b> interface exposes methods to provide specific monitor capabilities.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nn-dxgi1_6-idxgioutput6
	[PInvokeData("dxgi1_6.h", MSDNShortId = "NN:dxgi1_6.IDXGIOutput6")]
	[ComImport, Guid("068346e8-aaec-4b84-add7-137f513f77a1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIOutput6 : IDXGIOutput5
	{
		/// <summary>Sets application-defined data to the object and associates that data with a GUID.</summary>
		/// <param name="Name">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>A GUID that identifies the data. Use this GUID in a call to GetPrivateData to get the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the object's data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to the object's data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the DXGI_ERROR values.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>SetPrivateData</c> makes a copy of the specified data and stores it with the object.</para>
		/// <para>
		/// Private data that <c>SetPrivateData</c> stores in the object occupies the same storage space as private data that is stored by
		/// associated Direct3D objects (for example, by a Microsoft Direct3D 11 device through ID3D11Device::SetPrivateData or by a
		/// Direct3D 11 child device through ID3D11DeviceChild::SetPrivateData).
		/// </para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the well-known private
		/// data GUID ( <c>WKPDID_D3DDebugObjectName</c>) that is in D3Dcommon.h. For example, to give pContext a friendly name of My name,
		/// use the following code:
		/// </para>
		/// <para>
		/// You can use <c>WKPDID_D3DDebugObjectName</c> to track down memory leaks and understand performance characteristics of your
		/// applications. This information is reflected in the output of the debug layer that is related to memory leaks
		/// (ID3D11Debug::ReportLiveDeviceObjects) and with the event tracing for Windows events that we've added to Windows 8.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-setprivatedata HRESULT SetPrivateData( REFGUID Name,
		// UINT DataSize, const void *pData );
		new void SetPrivateData(in Guid Name, uint DataSize, IntPtr pData);

		/// <summary>Set an interface in the object's private data.</summary>
		/// <param name="Name">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>A GUID identifying the interface.</para>
		/// </param>
		/// <param name="pUnknown">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>The interface to set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following DXGI_ERROR.</para>
		/// </returns>
		/// <remarks>
		/// <para>This API associates an interface pointer with the object.</para>
		/// <para>
		/// When the interface is set its reference count is incremented. When the data are overwritten (by calling SPD or SPDI with the
		/// same GUID) or the object is destroyed, ::Release() is called and the interface's reference count is decremented.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( REFGUID Name, const IUnknown *pUnknown );
		new void SetPrivateDataInterface(in Guid Name, [In, Optional, MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] object? pUnknown);

		/// <summary>Get a pointer to the object's data.</summary>
		/// <param name="Name">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>A GUID identifying the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>Pointer to the data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following DXGI_ERROR.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, previously set by
		/// IDXGIObject::SetPrivateDataInterface, you must call ::Release() on the pointer before the pointer is freed to decrement the
		/// reference count.
		/// </para>
		/// <para>
		/// You can pass <c>GUID_DeviceType</c> in the Name parameter of <c>GetPrivateData</c> to retrieve the device type from the display
		/// adapter object (IDXGIAdapter, IDXGIAdapter1, IDXGIAdapter2).
		/// </para>
		/// <para><c>To get the type of device on which the display adapter was created</c></para>
		/// <list type="number">
		/// <item>
		/// <term>Call IUnknown::QueryInterface on the ID3D11Device or ID3D10Device object to retrieve the IDXGIDevice object.</term>
		/// </item>
		/// <item>
		/// <term>Call GetParent on the IDXGIDevice object to retrieve the IDXGIAdapter object.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Call <c>GetPrivateData</c> on the IDXGIAdapter object with <c>GUID_DeviceType</c> to retrieve the type of device on which the
		/// display adapter was created. pData will point to a value from the driver-type enumeration (for example, a value from D3D_DRIVER_TYPE).
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// On Windows 7 or earlier, this type is either a value from D3D10_DRIVER_TYPE or D3D_DRIVER_TYPE depending on which kind of device
		/// was created. On Windows 8, this type is always a value from <c>D3D_DRIVER_TYPE</c>. Don't use IDXGIObject::SetPrivateData with
		/// <c>GUID_DeviceType</c> because the behavior when doing so is undefined.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-getprivatedata HRESULT GetPrivateData( REFGUID Name,
		// UINT *pDataSize, void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid Name, ref uint pDataSize, [Out] IntPtr pData);

		/// <summary>Gets the parent of the object.</summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>The ID of the requested interface.</para>
		/// </param>
		/// <param name="ppParent">
		/// <para>Type: <c>void**</c></para>
		/// <para>The address of a pointer to the parent object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the DXGI_ERROR values.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-getparent HRESULT GetParent( REFIID riid, void
		// **ppParent );
		[PreserveSig]
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object? ppParent);

		/// <summary>Get a description of the output.</summary>
		/// <returns>
		/// <para>Type: <c>DXGI_OUTPUT_DESC*</c></para>
		/// <para>A pointer to the output description (see DXGI_OUTPUT_DESC).</para>
		/// </returns>
		/// <remarks>
		/// On a high DPI desktop, <c>GetDesc</c> returns the visualized screen size unless the app is marked high DPI aware. For info about
		/// writing DPI-aware Win32 apps, see High DPI.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getdesc HRESULT GetDesc( DXGI_OUTPUT_DESC *pDesc );
		new DXGI_OUTPUT_DESC GetDesc();

		/// <summary>
		/// <para>
		/// [Starting with Direct3D 11.1, we recommend not to use <c>GetDisplayModeList</c> anymore to retrieve the matching display mode.
		/// Instead, use IDXGIOutput1::GetDisplayModeList1, which supports stereo display mode.]
		/// </para>
		/// <para>Gets the display modes that match the requested format and other input options.</para>
		/// </summary>
		/// <param name="EnumFormat">
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>The color format (see DXGI_FORMAT).</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Options for modes to include (see DXGI_ENUM_MODES). DXGI_ENUM_MODES_SCALING needs to be specified to expose the display modes
		/// that require scaling. Centered modes, requiring no scaling and corresponding directly to the display output, are enumerated by default.
		/// </para>
		/// </param>
		/// <param name="pNumModes">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// Set pDesc to <c>NULL</c> so that pNumModes returns the number of display modes that match the format and the options. Otherwise,
		/// pNumModes returns the number of display modes returned in pDesc.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>DXGI_MODE_DESC*</c></para>
		/// <para>A pointer to a list of display modes (see DXGI_MODE_DESC); set to <c>NULL</c> to get the number of display modes.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// In general, when switching from windowed to full-screen mode, a swap chain automatically chooses a display mode that meets (or
		/// exceeds) the resolution, color depth and refresh rate of the swap chain. To exercise more control over the display mode, use
		/// this API to poll the set of display modes that are validated against monitor capabilities, or all modes that match the desktop
		/// (if the desktop settings are not validated against the monitor).
		/// </para>
		/// <para>
		/// As shown, this API is designed to be called twice. First to get the number of modes available, and second to return a
		/// description of the modes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getdisplaymodelist HRESULT GetDisplayModeList(
		// DXGI_FORMAT EnumFormat, UINT Flags, UINT *pNumModes, DXGI_MODE_DESC *pDesc );
		new void GetDisplayModeList(DXGI_FORMAT EnumFormat, DXGI_ENUM_MODES Flags, ref uint pNumModes, [Out, Optional] DXGI_MODE_DESC[]? pDesc);

		/// <summary>
		/// <para>
		/// [Starting with Direct3D 11.1, we recommend not to use <c>FindClosestMatchingMode</c> anymore to find the display mode that most
		/// closely matches the requested display mode. Instead, use IDXGIOutput1::FindClosestMatchingMode1, which supports stereo display mode.]
		/// </para>
		/// <para>Finds the display mode that most closely matches the requested display mode.</para>
		/// </summary>
		/// <param name="pModeToMatch">
		/// <para>Type: <c>const DXGI_MODE_DESC*</c></para>
		/// <para>
		/// The desired display mode (see DXGI_MODE_DESC). Members of <c>DXGI_MODE_DESC</c> can be unspecified indicating no preference for
		/// that member. A value of 0 for <c>Width</c> or <c>Height</c> indicates the value is unspecified. If either <c>Width</c> or
		/// <c>Height</c> are 0, both must be 0. A numerator and denominator of 0 in <c>RefreshRate</c> indicate it is unspecified. Other
		/// members of <c>DXGI_MODE_DESC</c> have enumeration values indicating the member is unspecified. If pConcernedDevice is
		/// <c>NULL</c>, <c>Format</c> cannot be DXGI_FORMAT_UNKNOWN.
		/// </para>
		/// </param>
		/// <param name="pClosestMatch">
		/// <para>Type: <c>DXGI_MODE_DESC*</c></para>
		/// <para>The mode that most closely matches pModeToMatch.</para>
		/// </param>
		/// <param name="pConcernedDevice">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// A pointer to the Direct3D device interface. If this parameter is <c>NULL</c>, only modes whose format matches that of
		/// pModeToMatch will be returned; otherwise, only those formats that are supported for scan-out by the device are returned. For
		/// info about the formats that are supported for scan-out by the device at each feature level:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>DXGI Format Support for Direct3D Feature Level 12.1 Hardware</term>
		/// </item>
		/// <item>
		/// <term>DXGI Format Support for Direct3D Feature Level 12.0 Hardware</term>
		/// </item>
		/// <item>
		/// <term>DXGI Format Support for Direct3D Feature Level 11.1 Hardware</term>
		/// </item>
		/// <item>
		/// <term>DXGI Format Support for Direct3D Feature Level 11.0 Hardware</term>
		/// </item>
		/// <item>
		/// <term>Hardware Support for Direct3D 10Level9 Formats</term>
		/// </item>
		/// <item>
		/// <term>Hardware Support for Direct3D 10.1 Formats</term>
		/// </item>
		/// <item>
		/// <term>Hardware Support for Direct3D 10 Formats</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>FindClosestMatchingMode</c> behaves similarly to the IDXGIOutput1::FindClosestMatchingMode1 except
		/// <c>FindClosestMatchingMode</c> considers only the mono display modes. <c>IDXGIOutput1::FindClosestMatchingMode1</c> considers
		/// only stereo modes if you set the <c>Stereo</c> member in the DXGI_MODE_DESC1 structure that pModeToMatch points to, and
		/// considers only mono modes if <c>Stereo</c> is not set.
		/// </para>
		/// <para>
		/// IDXGIOutput1::FindClosestMatchingMode1 returns a matched display-mode set with only stereo modes or only mono modes.
		/// <c>FindClosestMatchingMode</c> behaves as though you specified the input mode as mono.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-findclosestmatchingmode HRESULT
		// FindClosestMatchingMode( const DXGI_MODE_DESC *pModeToMatch, DXGI_MODE_DESC *pClosestMatch, IUnknown *pConcernedDevice );
		new void FindClosestMatchingMode(in DXGI_MODE_DESC pModeToMatch, out DXGI_MODE_DESC pClosestMatch, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pConcernedDevice);

		/// <summary>Halt a thread until the next vertical blank occurs.</summary>
		/// <remarks>
		/// A vertical blank occurs when the raster moves from the lower right corner to the upper left corner to begin drawing the next frame.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-waitforvblank HRESULT WaitForVBlank();
		new void WaitForVBlank();

		/// <summary>Takes ownership of an output.</summary>
		/// <param name="pDevice">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>A pointer to the IUnknown interface of a device (such as an ID3D10Device).</para>
		/// </param>
		/// <param name="Exclusive">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Set to <c>TRUE</c> to enable other threads or applications to take ownership of the device; otherwise, set to <c>FALSE</c>.</para>
		/// </param>
		/// <remarks>
		/// <para>When you are finished with the output, call IDXGIOutput::ReleaseOwnership.</para>
		/// <para>
		/// <c>TakeOwnership</c> should not be called directly by applications, since results will be unpredictable. It is called implicitly
		/// by the DXGI swap chain object during full-screen transitions, and should not be used as a substitute for swap-chain methods.
		/// </para>
		/// <para>Notes for Windows Store apps</para>
		/// <para>If a Windows Store app uses <c>TakeOwnership</c>, it fails with DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-takeownership HRESULT TakeOwnership( IUnknown
		// *pDevice, BOOL Exclusive );
		new void TakeOwnership([In, MarshalAs(UnmanagedType.Interface)] object pDevice, [MarshalAs(UnmanagedType.Bool)] bool Exclusive);

		/// <summary>Releases ownership of the output.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// If you are not using a swap chain, get access to an output by calling IDXGIOutput::TakeOwnership and release it when you are
		/// finished by calling <c>IDXGIOutput::ReleaseOwnership</c>. An application that uses a swap chain will typically not call either
		/// of these methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-releaseownership void ReleaseOwnership();
		[PreserveSig]
		new void ReleaseOwnership();

		/// <summary>Gets a description of the gamma-control capabilities.</summary>
		/// <returns>
		/// <para>Type: <c>DXGI_GAMMA_CONTROL_CAPABILITIES*</c></para>
		/// <para>A pointer to a description of the gamma-control capabilities (see DXGI_GAMMA_CONTROL_CAPABILITIES).</para>
		/// </returns>
		/// <remarks>
		/// <para><c>Note</c> Calling this method is only supported while in full-screen mode.</para>
		/// <para>For info about using gamma correction, see Using gamma correction.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getgammacontrolcapabilities HRESULT
		// GetGammaControlCapabilities( DXGI_GAMMA_CONTROL_CAPABILITIES *pGammaCaps );
		new DXGI_GAMMA_CONTROL_CAPABILITIES GetGammaControlCapabilities();

		/// <summary>Sets the gamma controls.</summary>
		/// <param name="pArray">
		/// <para>Type: <c>const DXGI_GAMMA_CONTROL*</c></para>
		/// <para>A pointer to a DXGI_GAMMA_CONTROL structure that describes the gamma curve to set.</para>
		/// </param>
		/// <remarks>
		/// <para><c>Note</c> Calling this method is only supported while in full-screen mode.</para>
		/// <para>For info about using gamma correction, see Using gamma correction.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-setgammacontrol HRESULT SetGammaControl( const
		// DXGI_GAMMA_CONTROL *pArray );
		new void SetGammaControl(in DXGI_GAMMA_CONTROL pArray);

		/// <summary>Gets the gamma control settings.</summary>
		/// <returns>
		/// <para>Type: <c>DXGI_GAMMA_CONTROL*</c></para>
		/// <para>An array of gamma control settings (see DXGI_GAMMA_CONTROL).</para>
		/// </returns>
		/// <remarks>
		/// <para><c>Note</c> Calling this method is only supported while in full-screen mode.</para>
		/// <para>For info about using gamma correction, see Using gamma correction.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getgammacontrol HRESULT GetGammaControl(
		// DXGI_GAMMA_CONTROL *pArray );
		new DXGI_GAMMA_CONTROL GetGammaControl();

		/// <summary>Changes the display mode.</summary>
		/// <param name="pScanoutSurface">
		/// <para>Type: <c>IDXGISurface*</c></para>
		/// <para>
		/// A pointer to a surface (see IDXGISurface) used for rendering an image to the screen. The surface must have been created as a
		/// back buffer (DXGI_USAGE_BACKBUFFER).
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>IDXGIOutput::SetDisplaySurface</c> should not be called directly by applications, since results will be unpredictable. It is
		/// called implicitly by the DXGI swap chain object during full-screen transitions, and should not be used as a substitute for
		/// swap-chain methods.
		/// </para>
		/// <para>This method should only be called between IDXGIOutput::TakeOwnership and IDXGIOutput::ReleaseOwnership calls.</para>
		/// <para>Notes for Windows Store apps</para>
		/// <para>If a Windows Store app uses <c>SetDisplaySurface</c>, it fails with DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-setdisplaysurface HRESULT SetDisplaySurface(
		// IDXGISurface *pScanoutSurface );
		new void SetDisplaySurface([In] IDXGISurface pScanoutSurface);

		/// <summary>
		/// <para>
		/// [Starting with Direct3D 11.1, we recommend not to use <c>GetDisplaySurfaceData</c> anymore to retrieve the current display
		/// surface. Instead, use IDXGIOutput1::GetDisplaySurfaceData1, which supports stereo display mode.]
		/// </para>
		/// <para>Gets a copy of the current display surface.</para>
		/// </summary>
		/// <param name="pDestination">
		/// <para>Type: <c>IDXGISurface*</c></para>
		/// <para>A pointer to a destination surface (see IDXGISurface).</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>IDXGIOutput::GetDisplaySurfaceData</c> can only be called when an output is in full-screen mode. If the method succeeds, DXGI
		/// fills the destination surface.
		/// </para>
		/// <para>
		/// Use IDXGIOutput::GetDesc to determine the size (width and height) of the output when you want to allocate space for the
		/// destination surface. This is true regardless of target monitor rotation. A destination surface created by a graphics component
		/// (such as Direct3D 10) must be created with CPU-write permission (see D3D10_CPU_ACCESS_WRITE). Other surfaces should be created
		/// with CPU read-write permission (see D3D10_CPU_ACCESS_READ_WRITE). This method will modify the surface data to fit the
		/// destination surface (stretch, shrink, convert format, rotate). The stretch and shrink is performed with point-sampling.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getdisplaysurfacedata HRESULT GetDisplaySurfaceData(
		// IDXGISurface *pDestination );
		new void GetDisplaySurfaceData([In] IDXGISurface pDestination);

		/// <summary>Gets statistics about recently rendered frames.</summary>
		/// <returns>
		/// <para>Type: <c>DXGI_FRAME_STATISTICS*</c></para>
		/// <para>A pointer to frame statistics (see DXGI_FRAME_STATISTICS).</para>
		/// </returns>
		/// <remarks>
		/// <para>This API is similar to IDXGISwapChain::GetFrameStatistics.</para>
		/// <para><c>Note</c> Calling this method is only supported while in full-screen mode.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getframestatistics HRESULT GetFrameStatistics(
		// DXGI_FRAME_STATISTICS *pStats );
		new DXGI_FRAME_STATISTICS GetFrameStatistics();

		/// <summary>Gets the display modes that match the requested format and other input options.</summary>
		/// <param name="EnumFormat">A <c>DXGI_FORMAT</c>-typed value for the color format.</param>
		/// <param name="Flags">
		/// A combination of <c>DXGI_ENUM_MODES</c>-typed values that are combined by using a bitwise OR operation. The resulting value
		/// specifies options for display modes to include. You must specify DXGI_ENUM_MODES_SCALING to expose the display modes that
		/// require scaling. Centered modes that require no scaling and correspond directly to the display output are enumerated by default.
		/// </param>
		/// <param name="pNumModes">
		/// A pointer to a variable that receives the number of display modes that <b>GetDisplayModeList1</b> returns in the memory block to
		/// which <i>pDesc</i> points. Set <i>pDesc</i> to <b>NULL</b> so that <i>pNumModes</i> returns the number of display modes that
		/// match the format and the options. Otherwise, <i>pNumModes</i> returns the number of display modes returned in <i>pDesc</i>.
		/// </param>
		/// <param name="pDesc">A pointer to a list of display modes; set to <b>NULL</b> to get the number of display modes.</param>
		/// <returns>
		/// Returns one of the error codes described in the <c>DXGI_ERROR</c> topic. It is rare, but possible, that the display modes
		/// available can change immediately after calling this method, in which case DXGI_ERROR_MORE_DATA is returned (if there is not
		/// enough room for all the display modes).
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>GetDisplayModeList1</b> is updated from <c>GetDisplayModeList</c> to return a list of <c>DXGI_MODE_DESC1</c> structures,
		/// which are updated mode descriptions. <b>GetDisplayModeList</b> behaves as though it calls <b>GetDisplayModeList1</b> because
		/// <b>GetDisplayModeList</b> can return all of the modes that are specified by <c>DXGI_ENUM_MODES</c>, including stereo mode.
		/// However, <b>GetDisplayModeList</b> returns a list of <c>DXGI_MODE_DESC</c> structures, which are the former mode descriptions
		/// and do not indicate stereo mode.
		/// </para>
		/// <para>
		/// The <b>GetDisplayModeList1</b> method does not enumerate stereo modes unless you specify the <c>DXGI_ENUM_MODES_STEREO</c> flag
		/// in the <i>Flags</i> parameter. If you specify DXGI_ENUM_MODES_STEREO, stereo modes are included in the list of returned modes
		/// that the <i>pDesc</i> parameter points to. In other words, the method returns both stereo and mono modes.
		/// </para>
		/// <para>
		/// In general, when you switch from windowed to full-screen mode, a swap chain automatically chooses a display mode that meets (or
		/// exceeds) the resolution, color depth, and refresh rate of the swap chain. To exercise more control over the display mode, use
		///          <b>GetDisplayModeList1</b> to poll the set of display modes that are validated against monitor capabilities, or all
		/// modes that match the desktop (if the desktop settings are not validated against the monitor).
		/// </para>
		/// <para>
		/// The following example code shows that you need to call <b>GetDisplayModeList1</b> twice. First call <b>GetDisplayModeList1</b>
		/// to get the number of modes available, and second call <b>GetDisplayModeList1</b> to return a description of the modes.
		/// </para>
		/// <para>
		/// <c>UINT num = 0; DXGI_FORMAT format = DXGI_FORMAT_R32G32B32A32_FLOAT; UINT flags = DXGI_ENUM_MODES_INTERLACED;
		/// pOutput-&gt;GetDisplayModeList1( format, flags, &amp;num, 0); ... DXGI_MODE_DESC1 * pDescs = new DXGI_MODE_DESC1[num];
		/// pOutput-&gt;GetDisplayModeList1( format, flags, &amp;num, pDescs);</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgioutput1-getdisplaymodelist1 HRESULT
		// GetDisplayModeList1( DXGI_FORMAT EnumFormat, UINT Flags, [in, out] UINT *pNumModes, [out, optional] DXGI_MODE_DESC1 *pDesc );
		[PreserveSig]
		new HRESULT GetDisplayModeList1(DXGI_FORMAT EnumFormat, DXGI_ENUM_MODES Flags, ref int pNumModes,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DXGI_MODE_DESC1[]? pDesc);

		/// <summary>Finds the display mode that most closely matches the requested display mode.</summary>
		/// <param name="pModeToMatch">
		/// A pointer to the <c>DXGI_MODE_DESC1</c> structure that describes the display mode to match. Members of <b>DXGI_MODE_DESC1</b>
		/// can be unspecified, which indicates no preference for that member. A value of 0 for <b>Width</b> or <b>Height</b> indicates that
		/// the value is unspecified. If either <b>Width</b> or <b>Height</b> is 0, both must be 0. A numerator and denominator of 0 in
		/// <b>RefreshRate</b> indicate it is unspecified. Other members of <b>DXGI_MODE_DESC1</b> have enumeration values that indicate
		/// that the member is unspecified. If <i>pConcernedDevice</i> is <b>NULL</b>, the <b>Format</b> member of <b>DXGI_MODE_DESC1</b>
		/// cannot be <b>DXGI_FORMAT_UNKNOWN</b>.
		/// </param>
		/// <param name="pClosestMatch">
		/// A pointer to the <c>DXGI_MODE_DESC1</c> structure that receives a description of the display mode that most closely matches the
		/// display mode described at <i>pModeToMatch</i>.
		/// </param>
		/// <param name="pConcernedDevice">
		/// <para>
		/// A pointer to the Direct3D device interface. If this parameter is <b>NULL</b>, <b>FindClosestMatchingMode1</b> returns only modes
		/// whose format matches that of <i>pModeToMatch</i>; otherwise, <b>FindClosestMatchingMode1</b> returns only those formats that are
		/// supported for scan-out by the device. For info about the formats that are supported for scan-out by the device at each feature level:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>DXGI Format Support for Direct3D Feature Level 12.1 Hardware</c></description>
		/// </item>
		/// <item>
		/// <description><c>DXGI Format Support for Direct3D Feature Level 12.0 Hardware</c></description>
		/// </item>
		/// <item>
		/// <description><c>DXGI Format Support for Direct3D Feature Level 11.1 Hardware</c></description>
		/// </item>
		/// <item>
		/// <description><c>DXGI Format Support for Direct3D Feature Level 11.0 Hardware</c></description>
		/// </item>
		/// <item>
		/// <description><c>Hardware Support for Direct3D 10Level9 Formats</c></description>
		/// </item>
		/// <item>
		/// <description><c>Hardware Support for Direct3D 10.1 Formats</c></description>
		/// </item>
		/// <item>
		/// <description><c>Hardware Support for Direct3D 10 Formats</c></description>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>Direct3D devices require UNORM formats.</para>
		/// <para><b>FindClosestMatchingMode1</b> finds the closest matching available display mode to the mode that you specify in <i>pModeToMatch</i>.</para>
		/// <para>
		/// If you set the <b>Stereo</b> member in the <c>DXGI_MODE_DESC1</c> structure to which <i>pModeToMatch</i> points to specify a
		/// stereo mode as input, <b>FindClosestMatchingMode1</b> considers only stereo modes. <b>FindClosestMatchingMode1</b> considers
		/// only mono modes if <b>Stereo</b> is not set.
		/// </para>
		/// <para>
		/// <b>FindClosestMatchingMode1</b> resolves similarly ranked members of display modes (that is, all specified, or all unspecified,
		/// and so on) in the following order:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <description><b>ScanlineOrdering</b></description>
		/// </item>
		/// <item>
		/// <description><b>Scaling</b></description>
		/// </item>
		/// <item>
		/// <description><b>Format</b></description>
		/// </item>
		/// <item>
		/// <description><b>Resolution</b></description>
		/// </item>
		/// <item>
		/// <description><b>RefreshRate</b></description>
		/// </item>
		/// </list>
		/// <para>
		/// When <b>FindClosestMatchingMode1</b> determines the closest value for a particular member, it uses previously matched members to
		/// filter the display mode list choices, and ignores other members. For example, when <b>FindClosestMatchingMode1</b> matches
		/// <b>Resolution</b>, it already filtered the display mode list by a certain <b>ScanlineOrdering</b>, <b>Scaling</b>, and
		/// <b>Format</b>, while it ignores <b>RefreshRate</b>. This ordering doesn't define the absolute ordering for every usage scenario
		/// of <b>FindClosestMatchingMode1</b>, because the application can choose some values initially, which effectively changes the
		/// order of resolving members.
		/// </para>
		/// <para><b>FindClosestMatchingMode1</b> matches members of the display mode one at a time, generally in a specified order.</para>
		/// <para>
		/// If a member is unspecified, <b>FindClosestMatchingMode1</b> gravitates toward the values for the desktop related to this output.
		/// If this output is not part of the desktop, <b>FindClosestMatchingMode1</b> uses the default desktop output to find values. If an
		/// application uses a fully unspecified display mode, <b>FindClosestMatchingMode1</b> typically returns a display mode that matches
		/// the desktop settings for this output. Because unspecified members are lower priority than specified members,
		/// <b>FindClosestMatchingMode1</b> resolves unspecified members later than specified members.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgioutput1-findclosestmatchingmode1 HRESULT
		// FindClosestMatchingMode1( [in] const DXGI_MODE_DESC1 *pModeToMatch, [out] DXGI_MODE_DESC1 *pClosestMatch, [in, optional] IUnknown
		// *pConcernedDevice );
		new void FindClosestMatchingMode1(in DXGI_MODE_DESC1 pModeToMatch, out DXGI_MODE_DESC1 pClosestMatch,
			[In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pConcernedDevice);

		/// <summary>Copies the display surface (front buffer) to a user-provided resource.</summary>
		/// <param name="pDestination">
		/// A pointer to a resource interface that represents the resource to which <b>GetDisplaySurfaceData1</b> copies the display surface.
		/// </param>
		/// <remarks>
		/// <para>
		/// <b>GetDisplaySurfaceData1</b> is similar to <c>IDXGIOutput::GetDisplaySurfaceData</c> except <b>GetDisplaySurfaceData1</b> takes
		/// an <c>IDXGIResource</c> and <b>IDXGIOutput::GetDisplaySurfaceData</b> takes an <c>IDXGISurface</c>.
		/// </para>
		/// <para>
		/// <b>GetDisplaySurfaceData1</b> returns an error if the input resource is not a 2D texture (represented by the
		/// <c>ID3D11Texture2D</c> interface) with an array size ( <b>ArraySize</b> member of the <c>D3D11_TEXTURE2D_DESC</c> structure)
		/// that is equal to the swap chain buffers.
		/// </para>
		/// <para>
		/// The original <c>IDXGIOutput::GetDisplaySurfaceData</c> and the updated <b>GetDisplaySurfaceData1</b> behave exactly the same.
		/// <b>GetDisplaySurfaceData1</b> was required because textures with an array size equal to 2 ( <b>ArraySize</b> = 2) do not
		/// implement <c>IDXGISurface</c>.
		/// </para>
		/// <para>
		/// You can call <b>GetDisplaySurfaceData1</b> only when an output is in full-screen mode. If <b>GetDisplaySurfaceData1</b>
		/// succeeds, it fills the destination resource.
		/// </para>
		/// <para>
		/// Use <c>IDXGIOutput::GetDesc</c> to determine the size (width and height) of the output when you want to allocate space for the
		/// destination resource. This is true regardless of target monitor rotation. A destination resource created by a graphics component
		/// (such as Direct3D 11) must be created with CPU write permission (see <c>D3D11_CPU_ACCESS_WRITE</c>). Other surfaces can be
		/// created with CPU read-write permission ( <b>D3D11_CPU_ACCESS_READ</b> | <b>D3D11_CPU_ACCESS_WRITE</b>).
		/// <b>GetDisplaySurfaceData1</b> modifies the surface data to fit the destination resource (stretch, shrink, convert format,
		/// rotate). <b>GetDisplaySurfaceData1</b> performs the stretch and shrink with point sampling.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgioutput1-getdisplaysurfacedata1 HRESULT
		// GetDisplaySurfaceData1( [in] IDXGIResource *pDestination );
		new void GetDisplaySurfaceData1([In] IDXGIResource pDestination);

		/// <summary>Creates a desktop duplication interface from the <c>IDXGIOutput1</c> interface that represents an adapter output.</summary>
		/// <param name="pDevice">
		/// A pointer to the Direct3D device interface that you can use to process the desktop image. This device must be created from the
		/// adapter to which the output is connected.
		/// </param>
		/// <param name="ppOutputDuplication">A pointer to a variable that receives the new <c>IDXGIOutputDuplication</c> interface.</param>
		/// <returns>
		/// <para><b>DuplicateOutput</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if <b>DuplicateOutput</b> successfully created the desktop duplication interface.</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG for one of the following reasons:</description>
		/// </item>
		/// <item>
		/// <description>
		/// E_ACCESSDENIED if the application does not have access privilege to the current desktop image. For example, only an application
		/// that runs at LOCAL_SYSTEM can access the secure desktop.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_UNSUPPORTED if the created <c>IDXGIOutputDuplication</c> interface does not support the current desktop mode or
		/// scenario. For example, 8bpp and non-DWM desktop modes are not supported. If <b>DuplicateOutput</b> fails with
		/// DXGI_ERROR_UNSUPPORTED, the application can wait for system notification of desktop switches and mode changes and then call
		/// <b>DuplicateOutput</b> again after such a notification occurs. For more information, refer to <c>EVENT_SYSTEM_DESKTOPSWITCH</c>
		/// and mode change notification ( <c>WM_DISPLAYCHANGE</c>).
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_NOT_CURRENTLY_AVAILABLE if DXGI reached the limit on the maximum number of concurrent duplication applications
		/// (default of four). Therefore, the calling application cannot create any desktop duplication interfaces until the other
		/// applications close.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_SESSION_DISCONNECTED if <b>DuplicateOutput</b> failed because the session is currently disconnected.</description>
		/// </item>
		/// <item>
		/// <description>Other error codes are described in the <c>DXGI_ERROR</c> topic.</description>
		/// </item>
		/// </list>
		/// <para>
		/// <b>Platform Update for Windows 7:  </b> On Windows 7 or Windows Server 2008 R2 with the <c>Platform Update for Windows 7</c>
		/// installed, <b>DuplicateOutput</b> fails with E_NOTIMPL. For more info about the Platform Update for Windows 7, see <c>Platform
		/// Update for Windows 7</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If an application wants to duplicate the entire desktop, it must create a desktop duplication interface on each active output on
		/// the desktop. This interface does not provide an explicit way to synchronize the timing of each output image. Instead, the
		/// application must use the time stamp of each output, and then determine how to combine the images.
		/// </para>
		/// <para>
		/// For <b>DuplicateOutput</b> to succeed, you must create <i>pDevice</i> from <c>IDXGIFactory1</c> or a later version of a DXGI
		/// factory interface that inherits from <b>IDXGIFactory1</b>.
		/// </para>
		/// <para>If the current mode is a stereo mode, the desktop duplication interface provides the image for the left stereo image only.</para>
		/// <para>
		/// By default, only four processes can use a <c>IDXGIOutputDuplication</c> interface at the same time within a single session. A
		/// process can have only one desktop duplication interface on a single desktop output; however, that process can have a desktop
		/// duplication interface for each output that is part of the desktop.
		/// </para>
		/// <para>For improved performance, consider using <c>DuplicateOutput1</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgioutput1-duplicateoutput HRESULT DuplicateOutput( [in]
		// IUnknown *pDevice, [out] IDXGIOutputDuplication **ppOutputDuplication );
		[PreserveSig]
		new HRESULT DuplicateOutput([In, MarshalAs(UnmanagedType.IUnknown)] object pDevice, out IDXGIOutputDuplication ppOutputDuplication);

		/// <summary>
		/// Queries an adapter output for multiplane overlay support. If this API returns ‘TRUE’, multiple swap chain composition takes
		/// place in a performant manner using overlay hardware. If this API returns false, apps should avoid using foreground swap chains
		/// (that is, avoid using swap chains created with the <c>DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER</c> flag).
		/// </summary>
		/// <returns>TRUE if the output adapter is the primary adapter and it supports multiplane overlays, otherwise returns FALSE.</returns>
		/// <remarks>See <c>CreateSwapChainForCoreWindow</c> for info on creating a foreground swap chain.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgioutput2-supportsoverlays BOOL SupportsOverlays();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool SupportsOverlays();

		/// <summary>Checks for overlay support.</summary>
		/// <param name="EnumFormat">
		/// <para>Type: <b><c>DXGI_FORMAT</c></b></para>
		/// <para>A <c>DXGI_FORMAT</c>-typed value for the color format.</para>
		/// </param>
		/// <param name="pConcernedDevice">
		/// <para>Type: <b><c>IUnknown</c>*</b></para>
		/// <para>A pointer to the Direct3D device interface. <b>CheckOverlaySupport</b> returns only support info about this scan-out device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>
		/// A pointer to a variable that receives a combination of <c>DXGI_OVERLAY_SUPPORT_FLAG</c>-typed values that are combined by using
		/// a bitwise OR operation. The resulting value specifies options for overlay support.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgioutput3-checkoverlaysupport HRESULT
		// CheckOverlaySupport( [in] DXGI_FORMAT EnumFormat, [in] IUnknown *pConcernedDevice, [out] UINT *pFlags );
		new DXGI_OVERLAY_SUPPORT_FLAG CheckOverlaySupport(DXGI_FORMAT EnumFormat, [In, MarshalAs(UnmanagedType.IUnknown)] object pConcernedDevice);

		/// <summary>Checks for overlay color space support.</summary>
		/// <param name="Format">
		/// <para>Type: <b><c>DXGI_FORMAT</c></b></para>
		/// <para>A <c>DXGI_FORMAT</c>-typed value for the color format.</para>
		/// </param>
		/// <param name="ColorSpace">
		/// <para>Type: <b><c>DXGI_COLOR_SPACE_TYPE</c></b></para>
		/// <para>A <c>DXGI_COLOR_SPACE_TYPE</c>-typed value that specifies color space type to check overlay support for.</para>
		/// </param>
		/// <param name="pConcernedDevice">
		/// <para>Type: <b><c>IUnknown</c>*</b></para>
		/// <para>
		/// A pointer to the Direct3D device interface. <b>CheckOverlayColorSpaceSupport</b> returns only support info about this scan-out device.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>
		/// A pointer to a variable that receives a combination of <c>DXGI_OVERLAY_COLOR_SPACE_SUPPORT_FLAG</c>-typed values that are
		/// combined by using a bitwise OR operation. The resulting value specifies options for overlay color space support.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgioutput4-checkoverlaycolorspacesupport HRESULT
		// CheckOverlayColorSpaceSupport( [in] DXGI_FORMAT Format, [in] DXGI_COLOR_SPACE_TYPE ColorSpace, [in] IUnknown *pConcernedDevice,
		// [out] UINT *pFlags );
		new DXGI_OVERLAY_COLOR_SPACE_SUPPORT_FLAG CheckOverlayColorSpaceSupport(DXGI_FORMAT Format, DXGI_COLOR_SPACE_TYPE ColorSpace,
			[In, MarshalAs(UnmanagedType.IUnknown)] object pConcernedDevice);

		/// <summary>
		/// Allows specifying a list of supported formats for fullscreen surfaces that can be returned by the <c>IDXGIOutputDuplication</c> object.
		/// </summary>
		/// <param name="pDevice">
		/// <para>Type: <b>IUnknown*</b></para>
		/// <para>
		/// A pointer to the Direct3D device interface that you can use to process the desktop image. This device must be created from the
		/// adapter to which the output is connected.
		/// </para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <b>UINT</b></para>
		/// <para>A bitfield of <b>DXGI_OUTDUPL_FLAG</b> enumeration values describing the kind of capture surface to create.</para>
		/// </param>
		/// <param name="SupportedFormatsCount">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the number of supported formats.</para>
		/// </param>
		/// <param name="pSupportedFormats">
		/// <para>Type: <b>const <c>DXGI_FORMAT</c>*</b></para>
		/// <para>Specifies an array, of length <i>SupportedFormatsCount</i> of <c>DXGI_FORMAT</c> entries.</para>
		/// </param>
		/// <param name="ppOutputDuplication">
		/// <para>Type: <b>IDXGIOutputDuplication**</b></para>
		/// <para>A pointer to a variable that receives the new <c>IDXGIOutputDuplication</c> interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if <b>DuplicateOutput1</b> successfully created the desktop duplication interface.</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG for one of the following reasons:</description>
		/// </item>
		/// <item>
		/// <description>
		/// E_ACCESSDENIED if the application does not have access privilege to the current desktop image. For example, only an application
		/// that runs at LOCAL_SYSTEM can access the secure desktop.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_UNSUPPORTED if the created <c>IDXGIOutputDuplication</c> interface does not support the current desktop mode or
		/// scenario. For example, 8bpp and non-DWM desktop modes are not supported.
		/// <para>
		/// If <b>DuplicateOutput1</b> fails with DXGI_ERROR_UNSUPPORTED, the application can wait for system notification of desktop
		/// switches and mode changes and then call <b>DuplicateOutput1</b> again after such a notification occurs. For more information,
		/// see the desktop switch ( <c>EVENT_SYSTEM_DESKTOPSWITCH</c>) and mode change notification ( <c>WM_DISPLAYCHANGE</c>).
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_NOT_CURRENTLY_AVAILABLE if DXGI reached the limit on the maximum number of concurrent duplication applications
		/// (default of four). Therefore, the calling application cannot create any desktop duplication interfaces until the other
		/// applications close.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_SESSION_DISCONNECTED if <b>DuplicateOutput1</b> failed because the session is currently disconnected.</description>
		/// </item>
		/// <item>
		/// <description>Other error codes are described in the <c>DXGI_ERROR</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method allows directly receiving the original back buffer format used by a running fullscreen application. For comparison,
		/// using the original <c>DuplicateOutput</c> function always converts the fullscreen surface to a 32-bit BGRA format. In cases
		/// where the current fullscreen application is using a different buffer format, a conversion to 32-bit BGRA incurs a performance
		/// penalty. Besides the performance benefit of being able to skip format conversion, using <b>DuplicateOutput1</b> also allows
		/// receiving the full gamut of colors in cases where a high-color format (such as R10G10B10A2) is being presented.
		/// </para>
		/// <para>
		/// The <i>pSupportedFormats</i> array should only contain display scan-out formats. See <c>Format Support for Direct3D Feature
		/// Level 11.0 Hardware</c> for required scan-out formats at each feature level. If the current fullscreen buffer format is not
		/// contained in the <i>pSupportedFormats</i> array, DXGI will pick one of the supplied formats and convert the fullscreen buffer to
		/// that format before returning from <c>IDXGIOutputDuplication::AcquireNextFrame</c>. The list of supported formats should always
		/// contain DXGI_FORMAT_B8G8R8A8_UNORM, as this is the most common format for the desktop.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_5/nf-dxgi1_5-idxgioutput5-duplicateoutput1 HRESULT DuplicateOutput1(
		// [in] IUnknown *pDevice, UINT Flags, [in] UINT SupportedFormatsCount, [in] const DXGI_FORMAT *pSupportedFormats, [out]
		// IDXGIOutputDuplication **ppOutputDuplication );
		[PreserveSig]
		new HRESULT DuplicateOutput1([In, MarshalAs(UnmanagedType.IUnknown)] object pDevice, DXGI_OUTDUPL_FLAG Flags, int SupportedFormatsCount,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DXGI_FORMAT[] pSupportedFormats, out IDXGIOutputDuplication ppOutputDuplication);

		/// <summary>Get an extended description of the output that includes color characteristics and connection type.</summary>
		/// <returns>
		/// <para>Type: <b><c>DXGI_OUTPUT_DESC1</c>*</b></para>
		/// <para>A pointer to the output description (see <c>DXGI_OUTPUT_DESC1</c>).</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Some scenarios do not have well-defined values for all fields in this struct. For example, if this IDXGIOutput represents a
		/// clone/duplicate set, or if the EDID has missing or invalid data. In these cases, the OS will provide some default values that
		/// correspond to a standard SDR display.
		/// </para>
		/// <para>
		/// An output's reported color and luminance characteristics can adjust dynamically while the system is running due to user action
		/// or changing ambient conditions. Therefore, apps should periodically query <b>IDXGIFactory::IsCurrent</b> and re-create their
		/// <b>IDXGIFactory</b> if it returns <b>FALSE</b>. Then re-query <b>GetDesc1</b> from the new factory's equivalent output to
		/// retrieve the newest color information.
		/// </para>
		/// <para>
		/// For more details on how to write apps that react dynamically to monitor capabilities, see <c>Using DirectX with high dynamic
		/// range displays and Advanced Color</c>.
		/// </para>
		/// <para>
		/// On a high DPI desktop, <b>GetDesc1</b> returns the visualized screen size unless the app is marked high DPI aware. For info
		/// about writing DPI-aware Win32 apps, see <c>High DPI</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nf-dxgi1_6-idxgioutput6-getdesc1 HRESULT GetDesc1( [out]
		// DXGI_OUTPUT_DESC1 *pDesc );
		DXGI_OUTPUT_DESC1 GetDesc1();

		/// <summary>Notifies applications that hardware stretching is supported.</summary>
		/// <returns>
		/// <para>Type: <b>UINT*</b></para>
		/// <para>
		/// A bitfield of <c>DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAGS</c> enumeration values describing which types of hardware composition
		/// are supported. The values are bitwise OR'd together.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nf-dxgi1_6-idxgioutput6-checkhardwarecompositionsupport HRESULT
		// CheckHardwareCompositionSupport( [out] UINT *pFlags );
		DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAGS CheckHardwareCompositionSupport();
	}

	/// <summary>Allows a process to indicate that it's resilient to any of its graphics devices being removed.</summary>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// Returns <c>S_OK</c> if successful; an error code otherwise. If this function is called after device creation, it returns
	/// <c>DXGI_ERROR_INVALID_CALL</c>. If this is not the first time that this function is called, it returns
	/// <c>DXGI_ERROR_ALREADY_EXISTS</c>. For a full list of error codes, see DXGI_ERROR.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>This function is graphics API-agonistic, meaning that apps running on other APIs, such as OpenGL and Vulkan, would also apply.</para>
	/// <para>This function should be called once per process and before any device creation.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi1_6/nf-dxgi1_6-dxgideclareadapterremovalsupport HRESULT DXGIDeclareAdapterRemovalSupport();
	[DllImport(Lib.DXGI, SetLastError = false, ExactSpelling = true), PInvokeData("dxgi1_6.h", MSDNShortId = "602EA66C-6D3D-4604-822C-DBD66EB70C3C")]
	public static extern HRESULT DXGIDeclareAdapterRemovalSupport();

	/// <summary>
	/// Disables v-blank virtualization for the process. This virtualization is used by the dynamic refresh rate (DRR) feature by default
	/// for all swap chains to maintain a steady virtualized present rate and v-blank cadence from <c>IDXGIOutput::WaitForVBlank</c>. By
	/// disabling virtualization, these APIs will see the changing refresh rate.
	/// </summary>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>Returns <b>S_OK</b> if successful; an error code otherwise. For a full list of error codes, see <c><b>DXGI_ERROR</b></c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// By default, a DXGI swap chain is unable to observe the changing refresh rate that's caused by the dynamic refresh rate (DRR) feature
	/// (see the blog post <c>Dynamic refresh rate—Get the best of both worlds</c>). Instead, a swap chain is virtualized to always see a
	/// fraction of the refresh rate—60Hz if the DRR mode is 120Hz. <b>DXGIDisableVBlankVirtualization</b> disables that virtualization for
	/// the entire process. Your application will then see v-blank timings change as the system boosts between 60Hz and 120Hz, and frames
	/// will arrive at the corresponding times for each rate, with present statistics reflecting those changes.
	/// </para>
	/// <para>
	/// You should call <b>DXGIDisableVBlankVirtualization</b> once per process, before creating any swap chains or calling
	/// <c>IDXGIOutput::WaitForVBlank</c>. It can't be disabled for the lifetime of the process, so any changes in v-blank timing or
	/// statistics from DRR boosting will remain observable to the process.
	/// </para>
	/// <para>You can find more information on how Dynamic Refresh Rate works in the <c>Compositor clock</c> topic.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nf-dxgi1_6-dxgidisablevblankvirtualization HRESULT DXGIDisableVBlankVirtualization();
	[PInvokeData("dxgi1_6.h", MSDNShortId = "NF:dxgi1_6.DXGIDisableVBlankVirtualization"), DllImport(Lib.DXGI, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT DXGIDisableVBlankVirtualization();

	/// <summary>Enumerates graphics adapters based on a given GPU preference.</summary>
	/// <typeparam name="T">The type of the adapter to enumerate.</typeparam>
	/// <param name="factory">A <see cref="IDXGIFactory6"/> instance.</param>
	/// <param name="GpuPreference">
	/// <para>Type: <b><c>DXGI_GPU_PREFERENCE</c></b></para>
	/// <para>The GPU preference for the app.</para>
	/// </param>
	/// <returns>A sequence of adapters that match the specified GPU preference.</returns>
	/// <remarks>
	/// <para>This method allows developers to select which GPU they think is most appropriate for each device their app creates and utilizes.</para>
	/// <para>
	/// This method is similar to <c>IDXGIFactory1::EnumAdapters1</c>, but it accepts a GPU preference to reorder the adapter enumeration.
	/// It returns the appropriate <b>IDXGIAdapter</b> for the given GPU preference. It is meant to be used in conjunction with the
	/// <b>D3DCreateDevice</b> functions, which take in an <b>IDXGIAdapter</b>.
	/// </para>
	/// <para>
	/// When <b>DXGI_GPU_PREFERENCE_UNSPECIFIED</b> is specified for the <i>GpuPreference</i> parameter, this method is equivalent to
	/// calling <c>IDXGIFactory1::EnumAdapters1</c>.
	/// </para>
	/// <para>
	/// When <b>DXGI_GPU_PREFERENCE_MINIMUM_POWER</b> is specified for the <i>GpuPreference</i> parameter, the order of preference for the
	/// adapter returned in <i>ppvAdapter</i> will be:
	/// </para>
	/// <list type="number">
	/// <item>iGPUs (integrated GPUs)</item>
	/// <item>dGPUs (discrete GPUs)</item>
	/// <item>xGPUs (external GPUs)</item>
	/// </list>
	/// <para>
	/// When <b>DXGI_GPU_PREFERENCE_HIGH_PERFORMANCE</b> is specified for the <i>GpuPreference</i> parameter, the order of preference for
	/// the adapter returned in <i>ppvAdapter</i> will be:
	/// </para>
	/// <list type="number">
	/// <item>xGPUs</item>
	/// <item>dGPUs</item>
	/// <item>iGPUs</item>
	/// </list>
	/// </remarks>
	public static IEnumerable<T> EnumAdapterByGpuPreference<T>(this IDXGIFactory6 factory, DXGI_GPU_PREFERENCE GpuPreference) where T : class
	{
		for (uint i = 0; factory.EnumAdapterByGpuPreference(i, GpuPreference, typeof(T).GUID, out var pAdapter).Succeeded; i++)
			yield return (T)pAdapter!;
	}

	/// <summary>Describes an adapter (or video card) that uses Microsoft DirectX Graphics Infrastructure (DXGI) 1.6.</summary>
	/// <remarks>
	/// The <c>DXGI_ADAPTER_DESC3</c> structure provides a DXGI 1.6 description of an adapter. This structure is initialized by using the
	/// IDXGIAdapter4::GetDesc3 method.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/ns-dxgi1_6-dxgi_adapter_desc3 typedef struct DXGI_ADAPTER_DESC3 { WCHAR
	// Description[128]; UINT VendorId; UINT DeviceId; UINT SubSysId; UINT Revision; SIZE_T DedicatedVideoMemory; SIZE_T
	// DedicatedSystemMemory; SIZE_T SharedSystemMemory; LUID AdapterLuid; DXGI_ADAPTER_FLAG3 Flags; DXGI_GRAPHICS_PREEMPTION_GRANULARITY
	// GraphicsPreemptionGranularity; DXGI_COMPUTE_PREEMPTION_GRANULARITY ComputePreemptionGranularity; } DXGI_ADAPTER_DESC3;
	[PInvokeData("dxgi1_6.h", MSDNShortId = "NS:dxgi1_6.DXGI_ADAPTER_DESC3")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DXGI_ADAPTER_DESC3
	{
		/// <summary>A string that contains the adapter description.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string Description;

		/// <summary>
		/// The PCI ID or ACPI ID of the adapter's hardware vendor. If this value is less than or equal to 0xFFFF, it is a PCI ID;
		/// otherwise, it is an ACPI ID.
		/// </summary>
		public uint VendorId;

		/// <summary>
		/// The PCI ID or ACPI ID of the adapter's hardware device. If <c>VendorId</c> is a PCI ID, it is also a PCI ID; otherwise, it is an
		/// ACPI ID.
		/// </summary>
		public uint DeviceId;

		/// <summary>
		/// The PCI ID or ACPI ID of the adapter's hardware subsystem. If <c>VendorId</c> is a PCI ID, it is also a PCI ID; otherwise, it is
		/// an ACPI ID.
		/// </summary>
		public uint SubSysId;

		/// <summary>
		/// The adapter's PCI or ACPI revision number. If <c>VendorId</c> is a PCI ID, it is a PCI device revision number; otherwise, it is
		/// an ACPI device revision number.
		/// </summary>
		public uint Revision;

		/// <summary>The number of bytes of dedicated video memory that are not shared with the CPU.</summary>
		public SizeT DedicatedVideoMemory;

		/// <summary>
		/// The number of bytes of dedicated system memory that are not shared with the CPU. This memory is allocated from available system
		/// memory at boot time.
		/// </summary>
		public SizeT DedicatedSystemMemory;

		/// <summary>
		/// The number of bytes of shared system memory. This is the maximum value of system memory that may be consumed by the adapter
		/// during operation. Any incidental memory consumed by the driver as it manages and uses video memory is additional.
		/// </summary>
		public SizeT SharedSystemMemory;

		/// <summary>
		/// A unique value that identifies the adapter. See LUID for a definition of the structure. <c>LUID</c> is defined in dxgi.h.
		/// </summary>
		public LUID AdapterLuid;

		/// <summary>
		/// A value of the DXGI_ADAPTER_FLAG3 enumeration that describes the adapter type. The <c>DXGI_ADAPTER_FLAG_REMOTE</c> flag is reserved.
		/// </summary>
		public DXGI_ADAPTER_FLAG3 Flags;

		/// <summary>
		/// A value of the DXGI_GRAPHICS_PREEMPTION_GRANULARITY enumerated type that describes the granularity level at which the GPU can be
		/// preempted from performing its current graphics rendering task.
		/// </summary>
		public DXGI_GRAPHICS_PREEMPTION_GRANULARITY GraphicsPreemptionGranularity;

		/// <summary>
		/// A value of the DXGI_COMPUTE_PREEMPTION_GRANULARITY enumerated type that describes the granularity level at which the GPU can be
		/// preempted from performing its current compute task.
		/// </summary>
		public DXGI_COMPUTE_PREEMPTION_GRANULARITY ComputePreemptionGranularity;
	}

	/// <summary>
	/// Describes an output or physical connection between the adapter (video card) and a device, including additional information about
	/// color capabilities and connection type.
	/// </summary>
	/// <remarks>The <c>DXGI_OUTPUT_DESC1</c> structure is initialized by the IDXGIOutput6::GetDesc1 method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/ns-dxgi1_6-dxgi_output_desc1 typedef struct DXGI_OUTPUT_DESC1 { WCHAR
	// DeviceName[32]; RECT DesktopCoordinates; BOOL AttachedToDesktop; DXGI_MODE_ROTATION Rotation; HMONITOR Monitor; UINT BitsPerColor;
	// DXGI_COLOR_SPACE_TYPE ColorSpace; FLOAT RedPrimary[2]; FLOAT GreenPrimary[2]; FLOAT BluePrimary[2]; FLOAT WhitePoint[2]; FLOAT
	// MinLuminance; FLOAT MaxLuminance; FLOAT MaxFullFrameLuminance; } DXGI_OUTPUT_DESC1;
	[PInvokeData("dxgi1_6.h", MSDNShortId = "NS:dxgi1_6.DXGI_OUTPUT_DESC1"), StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DXGI_OUTPUT_DESC1
	{
		/// <summary>
		/// <para>Type: <c>WCHAR[32]</c></para>
		/// <para>A string that contains the name of the output device.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string DeviceName;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>
		/// A RECT structure containing the bounds of the output in desktop coordinates. Desktop coordinates depend on the dots per inch
		/// (DPI) of the desktop. For info about writing DPI-aware Win32 apps, see High DPI.
		/// </para>
		/// </summary>
		public RECT DesktopCoordinates;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if the output is attached to the desktop; otherwise, false.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool AttachedToDesktop;

		/// <summary>
		/// <para>Type: <c>DXGI_MODE_ROTATION</c></para>
		/// <para>A member of the DXGI_MODE_ROTATION enumerated type describing on how an image is rotated by the output.</para>
		/// </summary>
		public DXGI_MODE_ROTATION Rotation;

		/// <summary>
		/// <para>Type: <c>HMONITOR</c></para>
		/// <para>An HMONITOR handle that represents the display monitor. For more information, see HMONITOR and the Device Context.</para>
		/// </summary>
		public HMONITOR Monitor;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of bits per color channel for the active wire format of the display attached to this output.</para>
		/// </summary>
		public uint BitsPerColor;

		/// <summary>
		/// <para>Type: <c>DXGI_COLOR_SPACE_TYPE</c></para>
		/// <para>
		/// The current advanced color capabilities of the display attached to this output. Specifically, whether its capable of reproducing
		/// color and luminance values outside of the sRGB color space. A value of DXGI_COLOR_SPACE_RGB_FULL_G22_NONE_P709 indicates that
		/// the display is limited to SDR/sRGB; A value of DXGI_COLOR_SPACE_RGB_FULL_G2048_NONE_P2020 indicates that the display supports
		/// advanced color capabilities.
		/// </para>
		/// <para>For detailed luminance and color capabilities, see additional members of this struct.</para>
		/// </summary>
		public DXGI_COLOR_SPACE_TYPE ColorSpace;

		/// <summary>
		/// <para>Type: <c>FLOAT[2]</c></para>
		/// <para>
		/// The red color primary, in xy coordinates, of the display attached to this output. This value will usually come from the EDID of
		/// the corresponding display or sometimes from an override.
		/// </para>
		/// </summary>
		public unsafe fixed float RedPrimary[2];

		/// <summary>
		/// <para>Type: <c>FLOAT[2]</c></para>
		/// <para>
		/// The green color primary, in xy coordinates, of the display attached to this output. This value will usually come from the EDID
		/// of the corresponding display or sometimes from an override.
		/// </para>
		/// </summary>
		public unsafe fixed float GreenPrimary[2];

		/// <summary>
		/// <para>Type: <c>FLOAT[2]</c></para>
		/// <para>
		/// The blue color primary, in xy coordinates, of the display attached to this output. This value will usually come from the EDID of
		/// the corresponding display or sometimes from an override.
		/// </para>
		/// </summary>
		public unsafe fixed float BluePrimary[2];

		/// <summary>
		/// <para>Type: <c>FLOAT[2]</c></para>
		/// <para>
		/// The white point, in xy coordinates, of the display attached to this output. This value will usually come from the EDID of the
		/// corresponding display or sometimes from an override.
		/// </para>
		/// </summary>
		public unsafe fixed float WhitePoint[2];

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The minimum luminance, in nits, that the display attached to this output is capable of rendering. Content should not exceed this
		/// minimum value for optimal rendering. This value will usually come from the EDID of the corresponding display or sometimes from
		/// an override.
		/// </para>
		/// </summary>
		public float MinLuminance;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The maximum luminance, in nits, that the display attached to this output is capable of rendering; this value is likely only
		/// valid for a small area of the panel. Content should not exceed this minimum value for optimal rendering. This value will usually
		/// come from the EDID of the corresponding display or sometimes from an override.
		/// </para>
		/// </summary>
		public float MaxLuminance;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The maximum luminance, in nits, that the display attached to this output is capable of rendering; unlike MaxLuminance, this
		/// value is valid for a color that fills the entire area of the panel. Content should not exceed this value across the entire panel
		/// for optimal rendering. This value will usually come from the EDID of the corresponding display or sometimes from an override.
		/// </para>
		/// </summary>
		public float MaxFullFrameLuminance;
	}
}