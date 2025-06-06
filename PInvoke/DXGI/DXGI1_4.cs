﻿namespace Vanara.PInvoke;

public static partial class DXGI
{
	/// <summary>Specifies the memory segment group to use.</summary>
	/// <remarks>
	/// <para>This enum is used by QueryVideoMemoryInfo and SetVideoMemoryReservation.</para>
	/// <para>Refer to the remarks for D3D12_MEMORY_POOL.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/ne-dxgi1_4-dxgi_memory_segment_group typedef enum
	// DXGI_MEMORY_SEGMENT_GROUP { DXGI_MEMORY_SEGMENT_GROUP_LOCAL = 0, DXGI_MEMORY_SEGMENT_GROUP_NON_LOCAL = 1 } ;
	[PInvokeData("dxgi1_4.h", MSDNShortId = "NE:dxgi1_4.DXGI_MEMORY_SEGMENT_GROUP")]
	public enum DXGI_MEMORY_SEGMENT_GROUP
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// The grouping of segments which is considered local to the video adapter, and represents the fastest available memory to the GPU.
		/// Applications should target the local segment group as the target size for their working set.
		/// </para>
		/// </summary>
		DXGI_MEMORY_SEGMENT_GROUP_LOCAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// The grouping of segments which is considered non-local to the video adapter, and may have slower performance than the local
		/// segment group.
		/// </para>
		/// </summary>
		DXGI_MEMORY_SEGMENT_GROUP_NON_LOCAL,
	}

	/// <summary>Specifies support for overlay color space.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/ne-dxgi1_4-dxgi_overlay_color_space_support_flag typedef enum
	// DXGI_OVERLAY_COLOR_SPACE_SUPPORT_FLAG { DXGI_OVERLAY_COLOR_SPACE_SUPPORT_FLAG_PRESENT = 0x1 } ;
	[PInvokeData("dxgi1_4.h", MSDNShortId = "NE:dxgi1_4.DXGI_OVERLAY_COLOR_SPACE_SUPPORT_FLAG"), Flags]
	public enum DXGI_OVERLAY_COLOR_SPACE_SUPPORT_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Overlay color space support is present.</para>
		/// </summary>
		DXGI_OVERLAY_COLOR_SPACE_SUPPORT_FLAG_PRESENT = 1,
	}

	/// <summary>Specifies color space support for the swap chain.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/ne-dxgi1_4-dxgi_swap_chain_color_space_support_flag typedef enum
	// DXGI_SWAP_CHAIN_COLOR_SPACE_SUPPORT_FLAG { DXGI_SWAP_CHAIN_COLOR_SPACE_SUPPORT_FLAG_PRESENT = 0x1,
	// DXGI_SWAP_CHAIN_COLOR_SPACE_SUPPORT_FLAG_OVERLAY_PRESENT = 0x2 } ;
	[PInvokeData("dxgi1_4.h", MSDNShortId = "NE:dxgi1_4.DXGI_SWAP_CHAIN_COLOR_SPACE_SUPPORT_FLAG"), Flags]
	public enum DXGI_SWAP_CHAIN_COLOR_SPACE_SUPPORT_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Color space support is present.</para>
		/// </summary>
		DXGI_SWAP_CHAIN_COLOR_SPACE_SUPPORT_FLAG_PRESENT = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Overlay color space support is present.</para>
		/// </summary>
		DXGI_SWAP_CHAIN_COLOR_SPACE_SUPPORT_FLAG_OVERLAY_PRESENT = 2,
	}

	/// <summary>This interface adds some memory residency methods, for budgeting and reserving physical memory.</summary>
	/// <remarks>For more details, refer to the <c>Residency</c> section of the D3D12 documentation.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nn-dxgi1_4-idxgiadapter3
	[PInvokeData("dxgi1_4.h", MSDNShortId = "NN:dxgi1_4.IDXGIAdapter3")]
	[ComImport, Guid("645967a4-1392-4310-a798-8053ce3e93fd"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIAdapter3 : IDXGIAdapter2
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
		uint RegisterHardwareContentProtectionTeardownStatusEvent(HEVENT hEvent);

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
		void UnregisterHardwareContentProtectionTeardownStatus(uint dwCookie);

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
		void QueryVideoMemoryInfo(uint NodeIndex, DXGI_MEMORY_SEGMENT_GROUP MemorySegmentGroup, out DXGI_QUERY_VIDEO_MEMORY_INFO pVideoMemoryInfo);

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
		void SetVideoMemoryReservation(uint NodeIndex, DXGI_MEMORY_SEGMENT_GROUP MemorySegmentGroup, ulong Reservation);

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
		uint RegisterVideoMemoryBudgetChangeNotificationEvent(HEVENT hEvent);

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
		void UnregisterVideoMemoryBudgetChangeNotification(uint dwCookie);
	}

	/// <summary>Enables creating Microsoft DirectX Graphics Infrastructure (DXGI) objects.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nn-dxgi1_4-idxgifactory4
	[PInvokeData("dxgi1_4.h", MSDNShortId = "NN:dxgi1_4.IDXGIFactory4")]
	[ComImport, Guid("1bc6ea02-ef36-464f-bf0c-21ca39e5168a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIFactory4 : IDXGIFactory3
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
		HRESULT EnumAdapterByLuid(LUID AdapterLuid, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvAdapter);

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
		HRESULT EnumWarpAdapter(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvAdapter);
	}

	/// <summary>
	/// Represents an adapter output (such as a monitor). The <b>IDXGIOutput4</b> interface exposes a method to check for overlay color
	/// space support.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nn-dxgi1_4-idxgioutput4
	[PInvokeData("dxgi1_4.h", MSDNShortId = "NN:dxgi1_4.IDXGIOutput4")]
	[ComImport, Guid("dc7dca35-2196-414d-9f53-617884032a60"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIOutput4 : IDXGIOutput3
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
		DXGI_OVERLAY_COLOR_SPACE_SUPPORT_FLAG CheckOverlayColorSpaceSupport(DXGI_FORMAT Format, DXGI_COLOR_SPACE_TYPE ColorSpace,
			[In, MarshalAs(UnmanagedType.IUnknown)] object pConcernedDevice);
	}

	/// <summary>
	/// Extends <c>IDXGISwapChain2</c> with methods to support getting the index of the swap chain's current back buffer and support for
	/// color space.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nn-dxgi1_4-idxgiswapchain3
	[PInvokeData("dxgi1_4.h", MSDNShortId = "NN:dxgi1_4.IDXGISwapChain3")]
	[ComImport, Guid("94d99bdb-f1f8-4ab0-b236-7da0170edab1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGISwapChain3 : IDXGISwapChain2
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

		/// <summary>Retrieves the device.</summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>The reference id for the device.</para>
		/// </param>
		/// <param name="ppDevice">
		/// <para>Type: <c>void**</c></para>
		/// <para>The address of a pointer to the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>A code that indicates success or failure (see DXGI_ERROR).</para>
		/// </returns>
		/// <remarks>
		/// The type of interface that is returned can be any interface published by the device. For example, it could be an IDXGIDevice
		/// * called pDevice, and therefore the REFIID would be obtained by calling __uuidof(pDevice).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgidevicesubobject-getdevice HRESULT GetDevice( REFIID riid,
		// void **ppDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object? ppDevice);

		/// <summary>Presents a rendered image to the user.</summary>
		/// <param name="SyncInterval">
		/// <para>Type: <c>UINT</c></para>
		/// <para>An integer that specifies how to synchronize presentation of a frame with the vertical blank.</para>
		/// <para>For the bit-block transfer (bitblt) model (DXGI_SWAP_EFFECT_DISCARDor DXGI_SWAP_EFFECT_SEQUENTIAL), values are:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>0 - The presentation occurs immediately, there is no synchronization.</term>
		/// </item>
		/// <item>
		/// <term>1 through 4 - Synchronize presentation after the nth vertical blank.</term>
		/// </item>
		/// </list>
		/// <para>For the flip model (</para>
		/// <para>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</para>
		/// <para>), values are:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>0 - Cancel the remaining time on the previously presented frame and discard this frame if a newer frame is queued.</term>
		/// </item>
		/// <item>
		/// <term>1 through 4 - Synchronize presentation for at least n vertical blanks.</term>
		/// </item>
		/// </list>
		/// <para>For an example that shows how sync-interval values affect a flip presentation queue, see Remarks.</para>
		/// <para>
		/// If the update region straddles more than one output (each represented by IDXGIOutput), <c>Present</c> performs the
		/// synchronization to the output that contains the largest sub-rectangle of the target window's client area.
		/// </para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>An integer value that contains swap-chain presentation options. These options are defined by the DXGI_PRESENT constants.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Possible return values include: S_OK, DXGI_ERROR_DEVICE_RESET or DXGI_ERROR_DEVICE_REMOVED (see DXGI_ERROR),
		/// DXGI_STATUS_OCCLUDED (see DXGI_STATUS), or D3DDDIERR_DEVICEREMOVED.
		/// </para>
		/// <para>
		/// <c>Note</c> The <c>Present</c> method can return either DXGI_ERROR_DEVICE_REMOVED or D3DDDIERR_DEVICEREMOVED if a video card has
		/// been physically removed from the computer, or a driver upgrade for the video card has occurred.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Starting with Direct3D 11.1, consider using IDXGISwapChain1::Present1 because you can then use dirty rectangles and the scroll
		/// rectangle in the swap chain presentation and as such use less memory bandwidth and as a result less system power. For more info
		/// about using dirty rectangles and the scroll rectangle in swap chain presentation, see Using dirty rectangles and the scroll
		/// rectangle in swap chain presentation.
		/// </para>
		/// <para>
		/// For the best performance when flipping swap-chain buffers in a full-screen application, see Full-Screen Application Performance Hints.
		/// </para>
		/// <para>
		/// Because calling <c>Present</c> might cause the render thread to wait on the message-pump thread, be careful when calling this
		/// method in an application that uses multiple threads. For more details, see Multithreading Considerations.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>
		/// Differences between Direct3D 9 and Direct3D 10: Specifying DXGI_PRESENT_TEST in the Flags parameter is analogous to
		/// IDirect3DDevice9::TestCooperativeLevel in Direct3D 9.
		/// </term>
		/// </listheader>
		/// </list>
		/// <para>
		/// For flip presentation model swap chains that you create with the DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL value set, a successful
		/// presentation unbinds back buffer 0 from the graphics pipeline, except for when you pass the DXGI_PRESENT_DO_NOT_SEQUENCE flag in
		/// the Flags parameter.
		/// </para>
		/// <para>For info about how data values change when you present content to the screen, see Converting data for the color space.</para>
		/// <para>Flip presentation model queue</para>
		/// <para>Suppose the following frames with sync-interval values are queued from oldest (A) to newest (E) before you call <c>Present</c>.</para>
		/// <para>A: 3, B: 0, C: 0, D: 1, E: 0</para>
		/// <para>
		/// When you call <c>Present</c>, the runtime shows frame A for only 1 vertical blank interval. The runtime terminates frame A early
		/// because of the sync interval 0 in frame B. Then the runtime shows frame D for 1 vertical blank interval, and then frame E until
		/// you submit a new presentation. The runtime discards frames B and C.
		/// </para>
		/// <para>Variable refresh rate displays</para>
		/// <para>
		/// It is a requirement of variable refresh rate displays that tearing is enabled. The CheckFeatureSupport method can be used to
		/// determine if this feature is available, and to set the required flags refer to the descriptions of DXGI_PRESENT_ALLOW_TEARING
		/// and DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING, and the <c>Variable refresh rate displays/Vsync off</c> section of DXGI 1.5 Improvements.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-present HRESULT Present( UINT SyncInterval, UINT
		// Flags );
		[PreserveSig]
		new HRESULT Present(uint SyncInterval, DXGI_PRESENT Flags);

		/// <summary>Accesses one of the swap-chain's back buffers.</summary>
		/// <param name="Buffer">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>A zero-based buffer index.</para>
		/// <para>
		/// If the swap chain's swap effect is <c>DXGI_SWAP_EFFECT_DISCARD</c>, this method can only access the first buffer; for this
		/// situation, set the index to zero.
		/// </para>
		/// <para>
		/// If the swap chain's swap effect is either <c>DXGI_SWAP_EFFECT_SEQUENTIAL</c> or <c>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</c>, only
		/// the swap chain's zero-index buffer can be read from and written to. The swap chain's buffers with indexes greater than zero can
		/// only be read from; so if you call the <c>IDXGIResource::GetUsage</c> method for such buffers, they have the
		/// <c>DXGI_USAGE_READ_ONLY</c> flag set.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The type of interface used to manipulate the buffer.</para>
		/// </param>
		/// <param name="ppSurface">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a back-buffer interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the following <c>DXGI_ERROR</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getbuffer HRESULT GetBuffer( UINT Buffer, [in]
		// REFIID riid, [out] void **ppSurface );
		[PreserveSig]
		new HRESULT GetBuffer(uint Buffer, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out object? ppSurface);

		/// <summary>Sets the display state to windowed or full screen.</summary>
		/// <param name="Fullscreen">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A Boolean value that specifies whether to set the display state to windowed or full screen. <c>TRUE</c> for full screen, and
		/// <c>FALSE</c> for windowed.
		/// </para>
		/// </param>
		/// <param name="pTarget">
		/// <para>Type: <c>IDXGIOutput*</c></para>
		/// <para>
		/// If you pass <c>TRUE</c> to the Fullscreen parameter to set the display state to full screen, you can optionally set this
		/// parameter to a pointer to an IDXGIOutput interface for the output target that contains the swap chain. If you set this parameter
		/// to <c>NULL</c>, DXGI will choose the output based on the swap-chain's device and the output window's placement. If you pass
		/// <c>FALSE</c> to Fullscreen, you must set this parameter to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>DXGI may change the display state of a swap chain in response to end user or system requests.</para>
		/// <para>
		/// We recommend that you create a windowed swap chain and allow the end user to change the swap chain to full screen through
		/// <c>SetFullscreenState</c>; that is, do not set the <c>Windowed</c> member of DXGI_SWAP_CHAIN_DESC to FALSE to force the swap
		/// chain to be full screen. However, if you create the swap chain as full screen, also provide the end user with a list of
		/// supported display modes because a swap chain that is created with an unsupported display mode might cause the display to go
		/// black and prevent the end user from seeing anything. Also, we recommend that you have a time-out confirmation screen or other
		/// fallback mechanism when you allow the end user to change display modes.
		/// </para>
		/// <para>Notes for Windows Store apps</para>
		/// <para>
		/// If a Windows Store app calls <c>SetFullscreenState</c> to set the display state to full screen, <c>SetFullscreenState</c> fails
		/// with DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.
		/// </para>
		/// <para>You cannot call <c>SetFullscreenState</c> on a swap chain that you created with IDXGIFactory2::CreateSwapChainForComposition.</para>
		/// <para>
		/// For the flip presentation model, after you transition the display state to full screen, you must call ResizeBuffers to ensure
		/// that your call to IDXGISwapChain1::Present1 succeeds.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-setfullscreenstate HRESULT SetFullscreenState(
		// BOOL Fullscreen, IDXGIOutput *pTarget );
		new void SetFullscreenState([MarshalAs(UnmanagedType.Bool)] bool Fullscreen, [In, Optional] IDXGIOutput? pTarget);

		/// <summary>Get the state associated with full-screen mode.</summary>
		/// <param name="pFullscreen">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A pointer to a boolean whose value is either:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>TRUE</c> if the swap chain is in full-screen mode</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c> if the swap chain is in windowed mode</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDXGIOutput**</c></para>
		/// <para>A pointer to the output target (see IDXGIOutput) when the mode is full screen; otherwise <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// When the swap chain is in full-screen mode, a pointer to the target output will be returned and its reference count will be incremented.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getfullscreenstate HRESULT GetFullscreenState(
		// BOOL *pFullscreen, IDXGIOutput **ppTarget );
		new IDXGIOutput? GetFullscreenState([MarshalAs(UnmanagedType.Bool)] out bool pFullscreen);

		/// <summary>
		/// <para>
		/// [Starting with Direct3D 11.1, we recommend not to use <c>GetDesc</c> anymore to get a description of the swap chain. Instead,
		/// use IDXGISwapChain1::GetDesc1.]
		/// </para>
		/// <para>Get a description of the swap chain.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>DXGI_SWAP_CHAIN_DESC*</c></para>
		/// <para>A pointer to the swap-chain description (see DXGI_SWAP_CHAIN_DESC).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getdesc HRESULT GetDesc( DXGI_SWAP_CHAIN_DESC
		// *pDesc );
		new DXGI_SWAP_CHAIN_DESC GetDesc();

		/// <summary>
		/// Changes the swap chain's back buffer size, format, and number of buffers. This should be called when the application window is resized.
		/// </summary>
		/// <param name="BufferCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of buffers in the swap chain (including all back and front buffers). This number can be different from the number of
		/// buffers with which you created the swap chain. This number can't be greater than <c>DXGI_MAX_SWAP_CHAIN_BUFFERS</c>. Set this
		/// number to zero to preserve the existing number of buffers in the swap chain. You can't specify less than two buffers for the
		/// flip presentation model.
		/// </para>
		/// </param>
		/// <param name="Width">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The new width of the back buffer. If you specify zero, DXGI will use the width of the client area of the target window. You
		/// can't specify the width as zero if you called the IDXGIFactory2::CreateSwapChainForComposition method to create the swap chain
		/// for a composition surface.
		/// </para>
		/// </param>
		/// <param name="Height">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The new height of the back buffer. If you specify zero, DXGI will use the height of the client area of the target window. You
		/// can't specify the height as zero if you called the IDXGIFactory2::CreateSwapChainForComposition method to create the swap chain
		/// for a composition surface.
		/// </para>
		/// </param>
		/// <param name="NewFormat">
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>
		/// A DXGI_FORMAT-typed value for the new format of the back buffer. Set this value to DXGI_FORMAT_UNKNOWN to preserve the existing
		/// format of the back buffer. The flip presentation model supports a more restricted set of formats than the bit-block transfer
		/// (bitblt) model.
		/// </para>
		/// </param>
		/// <param name="SwapChainFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A combination of DXGI_SWAP_CHAIN_FLAG-typed values that are combined by using a bitwise OR operation. The resulting value
		/// specifies options for swap-chain behavior.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// You can't resize a swap chain unless you release all outstanding references to its back buffers. You must release all of its
		/// direct and indirect references on the back buffers in order for <c>ResizeBuffers</c> to succeed.
		/// </para>
		/// <para>Direct references are held by the application after it calls AddRef on a resource.</para>
		/// <para>
		/// Indirect references are held by views to a resource, binding a view of the resource to a device context, a command list that
		/// used the resource, a command list that used a view to that resource, a command list that executed another command list that used
		/// the resource, and so on.
		/// </para>
		/// <para>
		/// Before you call <c>ResizeBuffers</c>, ensure that the application releases all references (by calling the appropriate number of
		/// Release invocations) on the resources, any views to the resource, and any command lists that use either the resources or views,
		/// and ensure that neither the resource nor a view is still bound to a device context. You can use ID3D11DeviceContext::ClearState
		/// to ensure that all references are released. If a view is bound to a deferred context, you must discard the partially built
		/// command list as well (by calling <c>ID3D11DeviceContext::ClearState</c>, then ID3D11DeviceContext::FinishCommandList, then
		/// <c>Release</c> on the command list). After you call <c>ResizeBuffers</c>, you can re-query interfaces via IDXGISwapChain::GetBuffer.
		/// </para>
		/// <para>
		/// For swap chains that you created with DXGI_SWAP_CHAIN_FLAG_GDI_COMPATIBLE, before you call <c>ResizeBuffers</c>, also call
		/// IDXGISurface1::ReleaseDC on the swap chain's back-buffer surface to ensure that you have no outstanding GDI device contexts
		/// (DCs) open.
		/// </para>
		/// <para>
		/// We recommend that you call <c>ResizeBuffers</c> when a client window is resized (that is, when an application receives a WM_SIZE message).
		/// </para>
		/// <para>
		/// The only difference between <c>IDXGISwapChain::ResizeBuffers</c> in Windows 8 versus Windows 7 is with flip presentation model
		/// swap chains that you create with the DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL or DXGI_SWAP_EFFECT_FLIP_DISCARD value set. In Windows 8,
		/// you must call <c>ResizeBuffers</c> to realize a transition between full-screen mode and windowed mode; otherwise, your next call
		/// to the IDXGISwapChain::Present method fails.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-resizebuffers HRESULT ResizeBuffers( UINT
		// BufferCount, UINT Width, UINT Height, DXGI_FORMAT NewFormat, UINT SwapChainFlags );
		new void ResizeBuffers(uint BufferCount, uint Width, uint Height, DXGI_FORMAT NewFormat, DXGI_SWAP_CHAIN_FLAG SwapChainFlags);

		/// <summary>Resizes the output target.</summary>
		/// <param name="pNewTargetParameters">
		/// <para>Type: <c>const DXGI_MODE_DESC*</c></para>
		/// <para>
		/// A pointer to a DXGI_MODE_DESC structure that describes the mode, which specifies the new width, height, format, and refresh rate
		/// of the target. If the format is DXGI_FORMAT_UNKNOWN, <c>ResizeTarget</c> uses the existing format. We only recommend that you
		/// use <c>DXGI_FORMAT_UNKNOWN</c> when the swap chain is in full-screen mode as this method is not thread safe.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>ResizeTarget</c> resizes the target window when the swap chain is in windowed mode, and changes the display mode on the
		/// target output when the swap chain is in full-screen mode. Therefore, apps can call <c>ResizeTarget</c> to resize the target
		/// window (rather than a Microsoft Win32API such as SetWindowPos) without knowledge of the swap chain display mode.
		/// </para>
		/// <para>If a Windows Store app calls <c>ResizeTarget</c>, it fails with DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.</para>
		/// <para>You cannot call <c>ResizeTarget</c> on a swap chain that you created with IDXGIFactory2::CreateSwapChainForComposition.</para>
		/// <para>
		/// Apps must still call IDXGISwapChain::ResizeBuffers after they call <c>ResizeTarget</c> because only <c>ResizeBuffers</c> can
		/// change the back buffers. But, if those apps have implemented window resize processing to call <c>ResizeBuffers</c>, they don't
		/// need to explicitly call <c>ResizeBuffers</c> after they call <c>ResizeTarget</c> because the window resize processing will
		/// achieve what the app requires.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-resizetarget HRESULT ResizeTarget( const
		// DXGI_MODE_DESC *pNewTargetParameters );
		new void ResizeTarget(in DXGI_MODE_DESC pNewTargetParameters);

		/// <summary>Get the output (the display monitor) that contains the majority of the client area of the target window.</summary>
		/// <returns>
		/// <para>Type: <c>IDXGIOutput**</c></para>
		/// <para>A pointer to the output interface (see IDXGIOutput).</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the method succeeds, the output interface will be filled and its reference count incremented. When you are finished with it,
		/// be sure to release the interface to avoid a memory leak.
		/// </para>
		/// <para>The output is also owned by the adapter on which the swap chain's device was created.</para>
		/// <para>You cannot call <c>GetContainingOutput</c> on a swap chain that you created with IDXGIFactory2::CreateSwapChainForComposition.</para>
		/// <para>
		/// To determine the output corresponding to such a swap chain, you should call IDXGIFactory::EnumAdapters and then
		/// IDXGIAdapter::EnumOutputs to enumerate over all of the available outputs. You should then intersect the bounds of your
		/// CoreWindow::Bounds with the desktop coordinates of each output, as reported by DXGI_OUTPUT_DESC1::DesktopCoordinates or DXGI_OUTPUT_DESC::DesktopCoordinates.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getcontainingoutput HRESULT GetContainingOutput(
		// IDXGIOutput **ppOutput );
		new IDXGIOutput GetContainingOutput();

		/// <summary>Gets performance statistics about the last render frame.</summary>
		/// <returns>
		/// <para>Type: <c>DXGI_FRAME_STATISTICS*</c></para>
		/// <para>A pointer to a DXGI_FRAME_STATISTICS structure for the frame statistics.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You cannot use <c>GetFrameStatistics</c> for swap chains that both use the bit-block transfer (bitblt) presentation model and
		/// draw in windowed mode.
		/// </para>
		/// <para>
		/// You can only use <c>GetFrameStatistics</c> for swap chains that either use the flip presentation model or draw in full-screen
		/// mode. You set the DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL value in the <c>SwapEffect</c> member of the DXGI_SWAP_CHAIN_DESC1 structure
		/// to specify that the swap chain uses the flip presentation model.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getframestatistics HRESULT GetFrameStatistics(
		// DXGI_FRAME_STATISTICS *pStats );
		new DXGI_FRAME_STATISTICS GetFrameStatistics();

		/// <summary>Gets the number of times that IDXGISwapChain::Present or IDXGISwapChain1::Present1 has been called.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer to a variable that receives the number of calls.</para>
		/// </returns>
		/// <remarks>For info about presentation statistics for a frame, see DXGI_FRAME_STATISTICS.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getlastpresentcount HRESULT GetLastPresentCount(
		// UINT *pLastPresentCount );
		new uint GetLastPresentCount();

		/// <summary>Gets a description of the swap chain.</summary>
		/// <returns>A pointer to a <c>DXGI_SWAP_CHAIN_DESC1</c> structure that describes the swap chain.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getdesc1 HRESULT GetDesc1( [out]
		// DXGI_SWAP_CHAIN_DESC1 *pDesc );
		new DXGI_SWAP_CHAIN_DESC1 GetDesc1();

		/// <summary>Gets a description of a full-screen swap chain.</summary>
		/// <returns>A pointer to a <c>DXGI_SWAP_CHAIN_FULLSCREEN_DESC</c> structure that describes the full-screen swap chain.</returns>
		/// <remarks>
		/// The semantics of <b>GetFullscreenDesc</b> are identical to that of the <c>IDXGISwapchain::GetDesc</c> method for
		/// <c>HWND</c>-based swap chains.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getfullscreendesc HRESULT
		// GetFullscreenDesc( [out] DXGI_SWAP_CHAIN_FULLSCREEN_DESC *pDesc );
		new DXGI_SWAP_CHAIN_FULLSCREEN_DESC GetFullscreenDesc();

		/// <summary>Retrieves the underlying <c>HWND</c> for this swap-chain object.</summary>
		/// <returns>A pointer to a variable that receives the <c>HWND</c> for the swap-chain object.</returns>
		/// <remarks>
		/// Applications call the <c>IDXGIFactory2::CreateSwapChainForHwnd</c> method to create a swap chain that is associated with an <c>HWND</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-gethwnd HRESULT GetHwnd( [out] HWND *pHwnd );
		new HWND GetHwnd();

		/// <summary>Retrieves the underlying <c>CoreWindow</c> object for this swap-chain object.</summary>
		/// <param name="refiid">
		/// A pointer to the globally unique identifier (GUID) of the <c>CoreWindow</c> object that is referenced by the <i>ppUnk</i> parameter.
		/// </param>
		/// <param name="ppUnk">A pointer to a variable that receives a pointer to the <c>CoreWindow</c> object.</param>
		/// <returns>
		/// <para><b>GetCoreWindow</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if it successfully retrieved the underlying <c>CoreWindow</c> object.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>DXGI_ERROR_INVALID_CALL</c> if <i>ppUnk</i> is <b>NULL</b>; that is, the swap chain is not associated with a
		/// <c>CoreWindow</c> object.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Any <c>HRESULT</c> that a call to <c>QueryInterface</c> to query for an <c>CoreWindow</c> object might typically return.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>DXGI_ERROR</c> topic.</description>
		/// </item>
		/// </list>
		/// <para>
		/// <b>Platform Update for Windows 7:  </b> On Windows 7 or Windows Server 2008 R2 with the <c>Platform Update for Windows 7</c>
		/// installed, <b>GetCoreWindow</b> fails with E_NOTIMPL. For more info about the Platform Update for Windows 7, see <c>Platform
		/// Update for Windows 7</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Applications call the <c>IDXGIFactory2::CreateSwapChainForCoreWindow</c> method to create a swap chain that is associated with
		/// an <c>CoreWindow</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getcorewindow HRESULT GetCoreWindow( [in]
		// REFIID refiid, [out] void **ppUnk );
		[PreserveSig]
		new HRESULT GetCoreWindow(in Guid refiid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppUnk);

		/// <summary>Presents a frame on the display screen.</summary>
		/// <param name="SyncInterval">
		/// <para>An integer that specifies how to synchronize presentation of a frame with the vertical blank.</para>
		/// <para>
		/// For the bit-block transfer (bitblt) model ( <c>DXGI_SWAP_EFFECT_DISCARD</c> or <c>DXGI_SWAP_EFFECT_SEQUENTIAL</c>), values are:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>0 - The presentation occurs immediately, there is no synchronization.</description>
		/// </item>
		/// <item>
		/// <description>1 through 4 - Synchronize presentation after the <i>n</i> th vertical blank.</description>
		/// </item>
		/// </list>
		/// <para>For the flip model (</para>
		/// <para>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</para>
		/// <para>), values are:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// 0 - Cancel the remaining time on the previously presented frame and discard this frame if a newer frame is queued.
		/// </description>
		/// </item>
		/// <item>
		/// <description>1 through 4 - Synchronize presentation for at least <i>n</i> vertical blanks.</description>
		/// </item>
		/// </list>
		/// <para>For an example that shows how sync-interval values affect a flip presentation queue, see Remarks.</para>
		/// <para>
		/// If the update region straddles more than one output (each represented by <c>IDXGIOutput1</c>), <b>Present1</b> performs the
		/// synchronization to the output that contains the largest sub-rectangle of the target window's client area.
		/// </para>
		/// </param>
		/// <param name="PresentFlags">
		/// An integer value that contains swap-chain presentation options. These options are defined by the <c>DXGI_PRESENT</c> constants.
		/// </param>
		/// <param name="pPresentParameters">
		/// A pointer to a <c>DXGI_PRESENT_PARAMETERS</c> structure that describes updated rectangles and scroll information of the frame to present.
		/// </param>
		/// <returns>
		/// Possible return values include: S_OK, <c>DXGI_ERROR_DEVICE_REMOVED</c> , <c>DXGI_STATUS_OCCLUDED</c>,
		/// <c>DXGI_ERROR_INVALID_CALL</c>, or E_OUTOFMEMORY.
		/// </returns>
		/// <remarks>
		/// <para>
		/// An app can use <b>Present1</b> to optimize presentation by specifying scroll and dirty rectangles. When the runtime has
		/// information about these rectangles, the runtime can then perform necessary bitblts during presentation more efficiently and pass
		/// this metadata to the Desktop Window Manager (DWM). The DWM can then use the metadata to optimize presentation and pass the
		/// metadata to indirect displays and terminal servers to optimize traffic over the wire. An app must confine its modifications to
		/// only the dirty regions that it passes to <b>Present1</b>, as well as modify the entire dirty region to avoid undefined resource
		/// contents from being exposed.
		/// </para>
		/// <para>
		/// For flip presentation model swap chains that you create with the <c>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</c> value set, a successful
		/// presentation results in an unbind of back buffer 0 from the graphics pipeline, except for when you pass the
		/// <c>DXGI_PRESENT_DO_NOT_SEQUENCE</c> flag in the <i>Flags</i> parameter.
		/// </para>
		/// <para>For info about how data values change when you present content to the screen, see <c>Converting data for the color space</c>.</para>
		/// <para>
		/// For info about calling <b>Present1</b> when your app uses multiple threads, see <c>Multithread Considerations</c> and
		/// <c>Multithreading and DXGI</c>.
		/// </para>
		/// <para><c></c><c></c><c></c> Flip presentation model queue</para>
		/// <para>Suppose the following frames with sync-interval values are queued from oldest (A) to newest (E) before you call <b>Present1</b>.</para>
		/// <para>A: 3, B: 0, C: 0, D: 1, E: 0</para>
		/// <para>
		/// When you call <b>Present1</b>, the runtime shows frame A for only 1 vertical blank interval. The runtime terminates frame A
		/// early because of the sync interval 0 in frame B. Then the runtime shows frame D for 1 vertical blank interval, and then frame E
		/// until you submit a new presentation. The runtime discards frames B and C.
		/// </para>
		/// <para><c></c><c></c><c></c> Variable refresh rate displays</para>
		/// <para>
		/// It is a requirement of variable refresh rate displays that tearing is enabled. The <c>CheckFeatureSupport</c> method can be used
		/// to determine if this feature is available, and to set the required flags refer to the descriptions of
		/// <c>DXGI_PRESENT_ALLOW_TEARING</c> and <c>DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING</c>, and the <b>Variable refresh rate displays/Vsync
		/// off</b> section of <c>DXGI 1.5 Improvements</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-present1 HRESULT Present1( UINT
		// SyncInterval, UINT PresentFlags, [in] const DXGI_PRESENT_PARAMETERS *pPresentParameters );
		[PreserveSig]
		new HRESULT Present1(uint SyncInterval, DXGI_PRESENT PresentFlags, in DXGI_PRESENT_PARAMETERS pPresentParameters);

		/// <summary>Determines whether a swap chain supports “temporary mono.”</summary>
		/// <returns>
		/// <para>
		/// Indicates whether to use the swap chain in temporary mono mode. <b>TRUE</b> indicates that you can use temporary-mono mode;
		/// otherwise, <b>FALSE</b>.
		/// </para>
		/// <para>
		/// <b>Platform Update for Windows 7:  </b> On Windows 7 or Windows Server 2008 R2 with the <c>Platform Update for Windows 7</c>
		/// installed, <b>IsTemporaryMonoSupported</b> always returns FALSE because stereoscopic 3D display behavior isn’t available with
		/// the Platform Update for Windows 7. For more info about the Platform Update for Windows 7, see <c>Platform Update for Windows 7</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Temporary mono is a feature where a stereo swap chain can be presented using only the content in the left buffer. To present
		/// using the left buffer as a mono buffer, an application calls the <c>IDXGISwapChain1::Present1</c> method with the
		/// <c>DXGI_PRESENT_STEREO_TEMPORARY_MONO</c> flag. All windowed swap chains support temporary mono. However, full-screen swap
		/// chains optionally support temporary mono because not all hardware supports temporary mono on full-screen swap chains efficiently.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-istemporarymonosupported BOOL IsTemporaryMonoSupported();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsTemporaryMonoSupported();

		/// <summary>Gets the output (the display monitor) to which you can restrict the contents of a present operation.</summary>
		/// <returns>
		/// A pointer to a buffer that receives a pointer to the <c>IDXGIOutput</c> interface for the restrict-to output. An application
		/// passes this pointer to <b>IDXGIOutput</b> in a call to the <c>IDXGIFactory2::CreateSwapChainForHwnd</c>,
		/// <c>IDXGIFactory2::CreateSwapChainForCoreWindow</c>, or <c>IDXGIFactory2::CreateSwapChainForComposition</c> method to create the
		/// swap chain.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the method succeeds, the runtime fills the buffer at <i>ppRestrictToOutput</i> with a pointer to the restrict-to output
		/// interface. This restrict-to output interface has its reference count incremented. When you are finished with it, be sure to
		/// release the interface to avoid a memory leak.
		/// </para>
		/// <para>The output is also owned by the adapter on which the swap chain's device was created.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getrestricttooutput HRESULT
		// GetRestrictToOutput( [out] IDXGIOutput **ppRestrictToOutput );
		new IDXGIOutput GetRestrictToOutput();

		/// <summary>Changes the background color of the swap chain.</summary>
		/// <param name="pColor">A pointer to a <c>DXGI_RGBA</c> structure that specifies the background color to set.</param>
		/// <returns>
		/// <para><b>SetBackgroundColor</b> returns:</para>
		/// <list type="bullet">
		/// <item>S_OK if it successfully set the background color.</item>
		/// <item>
		/// E_INVALIDARG if the <i>pColor</i> parameter is incorrect, for example, <i>pColor</i> is NULL or any of the floating-point values
		/// of the members of <c>DXGI_RGBA</c> to which <i>pColor</i> points are outside the range from 0.0 through 1.0.
		/// </item>
		/// <item>Possibly other error codes that are described in the <c>DXGI_ERROR</c> topic.</item>
		/// </list>
		/// <para>
		/// <b>Platform Update for Windows 7:</b> On Windows 7 or Windows Server 2008 R2 with the <c>Platform Update for Windows 7</c>
		/// installed, <b>SetBackgroundColor</b> fails with E_NOTIMPL. For more info about the Platform Update for Windows 7, see
		/// <c>Platform Update for Windows 7</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The background color affects only swap chains that you create with <c>DXGI_SCALING_NONE</c> in windowed mode. You pass this
		/// value in a call to <c>IDXGIFactory2::CreateSwapChainForHwnd</c>, <c>IDXGIFactory2::CreateSwapChainForCoreWindow</c>, or
		/// <c>IDXGIFactory2::CreateSwapChainForComposition</c>. Typically, the background color is not visible unless the swap-chain
		/// contents are smaller than the destination window.
		/// </para>
		/// <para>
		/// When you set the background color, it is not immediately realized. It takes effect in conjunction with your next call to the
		/// <c>IDXGISwapChain1::Present1</c> method. The <c>DXGI_PRESENT</c> flags that you pass to <b>IDXGISwapChain1::Present1</b> can
		/// help achieve the effect that you require. For example, if you call <b>SetBackgroundColor</b> and then call
		/// <b>IDXGISwapChain1::Present1</b> with the <i>Flags</i> parameter set to <c>DXGI_PRESENT_DO_NOT_SEQUENCE</c>, you change only the
		/// background color without changing the displayed contents of the swap chain.
		/// </para>
		/// <para>
		/// When you call the <c>IDXGISwapChain1::Present1</c> method to display contents of the swap chain,
		/// <b>IDXGISwapChain1::Present1</b> uses the <c>DXGI_ALPHA_MODE</c> value that is specified in the <b>AlphaMode</b> member of the
		/// <c>DXGI_SWAP_CHAIN_DESC1</c> structure to determine how to handle the <b>a</b> member of the <c>DXGI_RGBA</c> structure, the
		/// alpha value of the background color, that achieves window transparency. For example, if <b>AlphaMode</b> is
		/// <b>DXGI_ALPHA_MODE_IGNORE</b>, <b>IDXGISwapChain1::Present1</b> ignores the a member of <b>DXGI_RGBA</b>.
		/// </para>
		/// <note>Like all presentation data, we recommend that you perform floating point operations in a linear color space. When the
		/// desktop is in a fixed bit color depth mode, the operating system converts linear color data to standard RGB data (sRGB, gamma
		/// 2.2 corrected space) to compose to the screen. For more info, see <c>Converting data for the color space</c>.</note>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-setbackgroundcolor HRESULT
		// SetBackgroundColor( [in] const DXGI_RGBA *pColor );
		new void SetBackgroundColor(in D3DCOLORVALUE pColor);

		/// <summary>Retrieves the background color of the swap chain.</summary>
		/// <returns>A pointer to a <c>DXGI_RGBA</c> structure that receives the background color of the swap chain.</returns>
		/// <remarks>
		/// <para>
		/// <b>Note</b>  The background color that <b>GetBackgroundColor</b> retrieves does not indicate what the screen currently displays.
		/// The background color indicates what the screen will display with your next call to the <c>IDXGISwapChain1::Present1</c> method.
		/// The default value of the background color is black with full opacity: 0,0,0,1.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getbackgroundcolor HRESULT
		// GetBackgroundColor( [out] DXGI_RGBA *pColor );
		new D3DCOLORVALUE GetBackgroundColor();

		/// <summary>Sets the rotation of the back buffers for the swap chain.</summary>
		/// <param name="Rotation">
		/// A <c>DXGI_MODE_ROTATION</c>-typed value that specifies how to set the rotation of the back buffers for the swap chain.
		/// </param>
		/// <remarks>
		/// <para>
		/// You can only use <b>SetRotation</b> to rotate the back buffers for flip-model swap chains that you present in windowed mode.
		/// </para>
		/// <para>
		/// <b>SetRotation</b> isn't supported for rotating the back buffers for flip-model swap chains that you present in full-screen
		/// mode. In this situation, <b>SetRotation</b> doesn't fail, but you must ensure that you specify no rotation (
		/// <c>DXGI_MODE_ROTATION_IDENTITY</c>) for the swap chain. Otherwise, when you call <c>IDXGISwapChain1::Present1</c> or
		/// <c>IDXGISwapChain::Present</c> to present a frame, the presentation fails.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-setrotation HRESULT SetRotation( [in]
		// DXGI_MODE_ROTATION Rotation );
		new void SetRotation(DXGI_MODE_ROTATION Rotation);

		/// <summary>Gets the rotation of the back buffers for the swap chain.</summary>
		/// <returns>
		/// A pointer to a variable that receives a <c>DXGI_MODE_ROTATION</c>-typed value that specifies the rotation of the back buffers
		/// for the swap chain.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getrotation HRESULT GetRotation( [out]
		// DXGI_MODE_ROTATION *pRotation );
		new DXGI_MODE_ROTATION GetRotation();

		/// <summary>
		/// <para>Sets the source region to be used for the swap chain.</para>
		/// <para>
		/// Use <b>SetSourceSize</b> to specify the portion of the swap chain from which the operating system presents. This allows an
		/// effective resize without calling the more-expensive <c>IDXGISwapChain::ResizeBuffers</c> method. Prior to Windows 8.1, calling
		/// <b>IDXGISwapChain::ResizeBuffers</b> was the only way to resize the swap chain. The source rectangle is always defined by the
		/// region [0, 0, Width, Height].
		/// </para>
		/// </summary>
		/// <param name="Width">
		/// Source width to use for the swap chain. This value must be greater than zero, and must be less than or equal to the overall
		/// width of the swap chain.
		/// </param>
		/// <param name="Height">
		/// Source height to use for the swap chain. This value must be greater than zero, and must be less than or equal to the overall
		/// height of the swap chain.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgiswapchain2-setsourcesize HRESULT SetSourceSize( UINT
		// Width, UINT Height );
		new void SetSourceSize(uint Width, uint Height);

		/// <summary>
		/// <para>Gets the source region used for the swap chain.</para>
		/// <para>
		/// Use <b>GetSourceSize</b> to get the portion of the swap chain from which the operating system presents. The source rectangle is
		/// always defined by the region [0, 0, Width, Height]. Use <c>SetSourceSize</c> to set this portion of the swap chain.
		/// </para>
		/// </summary>
		/// <param name="pWidth">
		/// The current width of the source region of the swap chain. This value can range from 1 to the overall width of the swap chain.
		/// </param>
		/// <param name="pHeight">
		/// The current height of the source region of the swap chain. This value can range from 1 to the overall height of the swap chain.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgiswapchain2-getsourcesize HRESULT GetSourceSize( [out]
		// UINT *pWidth, [out] UINT *pHeight );
		new void GetSourceSize(out uint pWidth, out uint pHeight);

		/// <summary>Sets the number of frames that the swap chain is allowed to queue for rendering.</summary>
		/// <param name="MaxLatency">
		/// The maximum number of back buffer frames that will be queued for the swap chain. This value is 1 by default.
		/// </param>
		/// <remarks>
		/// This method is only valid for use on swap chains created with <c>DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT</c>.
		/// Otherwise, the result will be DXGI_ERROR_INVALID_CALL.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgiswapchain2-setmaximumframelatency HRESULT
		// SetMaximumFrameLatency( UINT MaxLatency );
		new void SetMaximumFrameLatency(uint MaxLatency);

		/// <summary>Gets the number of frames that the swap chain is allowed to queue for rendering.</summary>
		/// <returns>
		/// The maximum number of back buffer frames that will be queued for the swap chain. This value is 1 by default, but should be set
		/// to 2 if the scene takes longer than it takes for one vertical refresh (typically about 16ms) to draw.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgiswapchain2-getmaximumframelatency HRESULT
		// GetMaximumFrameLatency( [out] UINT *pMaxLatency );
		new uint GetMaximumFrameLatency();

		/// <summary>
		/// <para>Returns a waitable handle that signals when the DXGI adapter has finished presenting a new frame.</para>
		/// <para>
		/// Windows 8.1 introduces new APIs that allow lower-latency rendering by waiting until the previous frame is presented to the
		/// display before drawing the next frame. To use this method, first create the DXGI swap chain with the
		/// <c>DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT</c> flag set, then call <b>GetFrameLatencyWaitableObject</b> to retrieve
		/// the waitable handle. Use the waitable handle with <c>WaitForSingleObjectEx</c> to synchronize rendering of each new frame with
		/// the end of the previous frame. For every frame it renders, the app should wait on this handle before starting any rendering
		/// operations. Note that this requirement includes the first frame the app renders with the swap chain. See the <c>DirectXLatency
		/// sample</c>. When you are done with the handle, use <c>CloseHandle</c> to close it.
		/// </para>
		/// </summary>
		/// <returns>A handle to the waitable object, or NULL if the swap chain was not created with <c>DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT</c>.</returns>
		/// <remarks>
		/// When an application is finished using the object handle returned by <b>IDXGISwapChain2::GetFrameLatencyWaitableObject</b>, use
		/// the <c>CloseHandle</c> function to close the handle.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgiswapchain2-getframelatencywaitableobject HANDLE GetFrameLatencyWaitableObject();
		[PreserveSig]
		new HANDLE GetFrameLatencyWaitableObject();

		/// <summary>
		/// <para>Sets the transform matrix that will be applied to a composition swap chain upon the next present.</para>
		/// <para>
		/// Starting with Windows 8.1, Windows Store apps are able to place DirectX swap chain visuals in XAML pages using the
		/// <c>SwapChainPanel</c> element, which can be placed and sized arbitrarily. This exposes the DirectX swap chain visuals to touch
		/// scaling and translation scenarios using touch UI. The <c>GetMatrixTransform</c> and <b>SetMatrixTransform</b> methods are used
		/// to synchronize scaling of the DirectX swap chain with its associated <b>SwapChainPanel</b> element. Only simple
		/// scale/translation elements in the matrix are allowed – the call will fail if the matrix contains skew/rotation elements.
		/// </para>
		/// </summary>
		/// <param name="pMatrix">
		/// The transform matrix to use for swap chain scaling and translation. This function can only be used with composition swap chains
		/// created by <c>IDXGIFactory2::CreateSwapChainForComposition</c>. Only scale and translation components are allowed in the matrix.
		/// </param>
		/// <returns>
		/// <para><b>SetMatrixTransform</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if it successfully retrieves the transform matrix.</description>
		/// </item>
		/// <item>
		/// <description>
		/// E_INVALIDARG if the <i>pMatrix</i> parameter is incorrect, for example, <i>pMatrix</i> is NULL or the matrix represented by
		/// <c>DXGI_MATRIX_3X2_F</c> includes components other than scale and translation.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL if the method is called on a swap chain that was not created with <c>CreateSwapChainForComposition</c>.</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>DXGI_ERROR</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgiswapchain2-setmatrixtransform HRESULT
		// SetMatrixTransform( const DXGI_MATRIX_3X2_F *pMatrix );
		[PreserveSig]
		new HRESULT SetMatrixTransform(in DXGI_MATRIX_3X2_F pMatrix);

		/// <summary>
		/// <para>Gets the transform matrix that will be applied to a composition swap chain upon the next present.</para>
		/// <para>
		/// Starting with Windows 8.1, Windows Store apps are able to place DirectX swap chain visuals in XAML pages using the
		/// <c>SwapChainPanel</c> element, which can be placed and sized arbitrarily. This exposes the DirectX swap chain visuals to touch
		/// scaling and translation scenarios using touch UI. The <b>GetMatrixTransform</b> and <c>SetMatrixTransform</c> methods are used
		/// to synchronize scaling of the DirectX swap chain with its associated <b>SwapChainPanel</b> element. Only simple
		/// scale/translation elements in the matrix are allowed – the call will fail if the matrix contains skew/rotation elements.
		/// </para>
		/// </summary>
		/// <param name="pMatrix">
		/// <para>[out]</para>
		/// <para>The transform matrix currently used for swap chain scaling and translation.</para>
		/// </param>
		/// <returns>
		/// <para><b>GetMatrixTransform</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if it successfully retrieves the transform matrix.</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL if the method is called on a swap chain that was not created with <c>CreateSwapChainForComposition</c>.</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>DXGI_ERROR</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-idxgiswapchain2-getmatrixtransform HRESULT
		// GetMatrixTransform( DXGI_MATRIX_3X2_F *pMatrix );
		[PreserveSig]
		new HRESULT GetMatrixTransform(out DXGI_MATRIX_3X2_F pMatrix);

		/// <summary>Gets the index of the swap chain's current back buffer.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Returns the index of the current back buffer.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgiswapchain3-getcurrentbackbufferindex UINT GetCurrentBackBufferIndex();
		[PreserveSig]
		uint GetCurrentBackBufferIndex();

		/// <summary>
		/// <para>
		/// Checks whether the swap chain currently supports the specified color space, based on the current adapter output (for example,
		/// what monitor the swap chain window is being displayed on).
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The swap chain might still be able to set and display color spaces that are not returned as supported. For example the
		/// <b>DXGI_COLOR_SPACE_RGB_FULL_G2084_NONE_P2020</b> and <b>DXGI_COLOR_SPACE_RGB_FULL_G10_NONE_P709</b> color spaces will be
		/// displayed even if <b>DXGI_COLOR_SPACE_RGB_FULL_G22_NONE_P709</b> is in use, although out-of-gamut colors will be clipped.
		/// </para>
		/// </para>
		/// <para>
		/// While a color space has been successfully set to the swap chain (whether or not it was returned as supported before), it will be
		/// returned as supported when queried with this function.
		/// </para>
		/// </summary>
		/// <param name="ColorSpace">
		/// <para>Type: <b><c>DXGI_COLOR_SPACE_TYPE</c></b></para>
		/// <para>A <c>DXGI_COLOR_SPACE_TYPE</c>-typed value that specifies color space type to check support for.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>
		/// A pointer to a variable that receives a combination of <c>DXGI_SWAP_CHAIN_COLOR_SPACE_SUPPORT_FLAG</c>-typed values that are
		/// combined by using a bitwise OR operation. The resulting value specifies options for color space support.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgiswapchain3-checkcolorspacesupport HRESULT
		// CheckColorSpaceSupport( [in] DXGI_COLOR_SPACE_TYPE ColorSpace, [out] UINT *pColorSpaceSupport );
		DXGI_SWAP_CHAIN_COLOR_SPACE_SUPPORT_FLAG CheckColorSpaceSupport(DXGI_COLOR_SPACE_TYPE ColorSpace);

		/// <summary>Sets the color space used by the swap chain.</summary>
		/// <param name="ColorSpace">
		/// <para>Type: <b><c>DXGI_COLOR_SPACE_TYPE</c></b></para>
		/// <para>A <c>DXGI_COLOR_SPACE_TYPE</c>-typed value that specifies the color space to set.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgiswapchain3-setcolorspace1 HRESULT SetColorSpace1(
		// [in] DXGI_COLOR_SPACE_TYPE ColorSpace );
		void SetColorSpace1(DXGI_COLOR_SPACE_TYPE ColorSpace);

		/// <summary>
		/// Changes the swap chain's back buffer size, format, and number of buffers, where the swap chain was created using a D3D12 command
		/// queue as an input device. This should be called when the application window is resized.
		/// </summary>
		/// <param name="BufferCount">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// The number of buffers in the swap chain (including all back and front buffers). This number can be different from the number of
		/// buffers with which you created the swap chain. This number can't be greater than <b>DXGI_MAX_SWAP_CHAIN_BUFFERS</b>. Set this
		/// number to zero to preserve the existing number of buffers in the swap chain. You can't specify less than two buffers for the
		/// flip presentation model.
		/// </para>
		/// </param>
		/// <param name="Width">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// The new width of the back buffer. If you specify zero, DXGI will use the width of the client area of the target window. You
		/// can't specify the width as zero if you called the <c>IDXGIFactory2::CreateSwapChainForComposition</c> method to create the swap
		/// chain for a composition surface.
		/// </para>
		/// </param>
		/// <param name="Height">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// The new height of the back buffer. If you specify zero, DXGI will use the height of the client area of the target window. You
		/// can't specify the height as zero if you called the <c>IDXGIFactory2::CreateSwapChainForComposition</c> method to create the swap
		/// chain for a composition surface.
		/// </para>
		/// </param>
		/// <param name="Format">
		/// <para>Type: <b><c>DXGI_FORMAT</c></b></para>
		/// <para>
		/// A <c>DXGI_FORMAT</c>-typed value for the new format of the back buffer. Set this value to <c>DXGI_FORMAT_UNKNOWN</c> to preserve
		/// the existing format of the back buffer. The flip presentation model supports a more restricted set of formats than the bit-block
		/// transfer (bitblt) model.
		/// </para>
		/// </param>
		/// <param name="SwapChainFlags">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// A combination of <c>DXGI_SWAP_CHAIN_FLAG</c>-typed values that are combined by using a bitwise OR operation. The resulting value
		/// specifies options for swap-chain behavior.
		/// </para>
		/// </param>
		/// <param name="pCreationNodeMask">
		/// <para>Type: <b>const UINT*</b></para>
		/// <para>
		/// An array of UINTs, of total size <i>BufferCount</i>, where the value indicates which node the back buffer should be created on.
		/// Buffers created using <b>ResizeBuffers1</b> with a non-null <i>pCreationNodeMask</i> array are visible to all nodes.
		/// </para>
		/// </param>
		/// <param name="ppPresentQueue">
		/// <para>Type: <b>IUnknown*</b></para>
		/// <para>
		/// An array of command queues ( <c>ID3D12CommandQueue</c> instances), of total size <i>BufferCount</i>. Each queue provided must
		/// match the corresponding creation node mask specified in the <i>pCreationNodeMask</i> array. When <b>Present()</b> is called, in
		/// addition to rotating to the next buffer for the next frame, the swapchain will also rotate through these command queues. This
		/// allows the app to control which queue requires synchronization for a given present operation.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is only valid to call when the swapchain was created using a D3D12 command queue ( <c>ID3D12CommandQueue</c>) as an
		/// input device.
		/// </para>
		/// <para>
		/// When a swapchain is created on a multi-GPU adapter, the backbuffers are all created on node 1 and only a single command queue is
		/// supported. <b>ResizeBuffers1</b> enables applications to create backbuffers on different nodes, allowing a different command
		/// queue to be used with each node. These capabilities enable Alternate Frame Rendering (AFR) techniques to be used with the
		/// swapchain. See <c>Multi-adapter systems</c>.
		/// </para>
		/// <para>Also see the Remarks section in <c>IDXGISwapChain::ResizeBuffers</c>, all of which is relevant to <b>ResizeBuffers1</b>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nf-dxgi1_4-idxgiswapchain3-resizebuffers1 HRESULT ResizeBuffers1(
		// [in] UINT BufferCount, [in] UINT Width, [in] UINT Height, [in] DXGI_FORMAT Format, [in] UINT SwapChainFlags, [in] const UINT
		// *pCreationNodeMask, [in] IUnknown * const *ppPresentQueue );
		[PreserveSig]
		HRESULT ResizeBuffers1(int BufferCount, uint Width, uint Height, DXGI_FORMAT Format, DXGI_SWAP_CHAIN_FLAG SwapChainFlags,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] pCreationNodeMask,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] object[] ppPresentQueue);
	}

	/// <summary>Describes the current video memory budgeting parameters.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/ns-dxgi1_4-dxgi_query_video_memory_info typedef struct
	// DXGI_QUERY_VIDEO_MEMORY_INFO { UINT64 Budget; UINT64 CurrentUsage; UINT64 AvailableForReservation; UINT64 CurrentReservation; } DXGI_QUERY_VIDEO_MEMORY_INFO;
	[PInvokeData("dxgi1_4.h", MSDNShortId = "NS:dxgi1_4.DXGI_QUERY_VIDEO_MEMORY_INFO"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_QUERY_VIDEO_MEMORY_INFO
	{
		/// <summary>
		/// Specifies the OS-provided video memory budget, in bytes, that the application should target. If <c>CurrentUsage</c> is greater
		/// than <c>Budget</c>, the application may incur stuttering or performance penalties due to background activity by the OS to
		/// provide other applications with a fair usage of video memory.
		/// </summary>
		public ulong Budget;

		/// <summary>Specifies the application’s current video memory usage, in bytes.</summary>
		public ulong CurrentUsage;

		/// <summary>
		/// The amount of video memory, in bytes, that the application has available for reservation. To reserve this video memory, the
		/// application should call IDXGIAdapter3::SetVideoMemoryReservation.
		/// </summary>
		public ulong AvailableForReservation;

		/// <summary>
		/// The amount of video memory, in bytes, that is reserved by the application. The OS uses the reservation as a hint to determine
		/// the application’s minimum working set. Applications should attempt to ensure that their video memory usage can be trimmed to
		/// meet this requirement.
		/// </summary>
		public ulong CurrentReservation;
	}
}