using System.Collections.Generic;

namespace Vanara.PInvoke;

public static partial class DXGI
{
	/// <summary>The <c>IDXGIAdapter</c> interface represents a display subsystem (including one or more GPUs, DACs and video memory).</summary>
	/// <remarks>
	/// <para>A display subsystem is often referred to as a video card, however, on some machines the display subsystem is part of the motherboard.</para>
	/// <para>To enumerate the display subsystems, use IDXGIFactory::EnumAdapters.</para>
	/// <para>To get an interface to the adapter for a particular device, use IDXGIDevice::GetAdapter.</para>
	/// <para>To create a software adapter, use IDXGIFactory::CreateSoftwareAdapter.</para>
	/// <para><c>Windows Phone 8:</c> This API is supported.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgiadapter
	[PInvokeData("dxgi.h"), ComImport, Guid("2411e7e1-12ac-4ccf-bd14-9798e8534dc0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIAdapter : IDXGIObject
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
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppParent);

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
		HRESULT EnumOutputs(uint Output, [MarshalAs(UnmanagedType.Interface)] out IDXGIOutput ppOutput);

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
		DXGI_ADAPTER_DESC GetDesc();

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
		HRESULT CheckInterfaceSupport(in Guid InterfaceName, out long pUMDVersion);
	}

	/// <summary>The <c>IDXGIAdapter1</c> interface represents a display sub-system (including one or more GPU's, DACs and video memory).</summary>
	/// <remarks>
	/// <para>
	/// This interface is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
	/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and
	/// Windows Server 2008 (KB 971512).
	/// </para>
	/// <para>
	/// A display sub-system is often referred to as a video card, however, on some machines the display sub-system is part of the mother board.
	/// </para>
	/// <para>
	/// To enumerate the display sub-systems, use IDXGIFactory1::EnumAdapters1. To get an interface to the adapter for a particular device,
	/// use IDXGIDevice::GetAdapter. To create a software adapter, use IDXGIFactory::CreateSoftwareAdapter.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This API is supported.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgiadapter1
	[PInvokeData("dxgi.h", MSDNShortId = "003d5a10-e978-481f-8ca6-9e5ab69bfec0"), ComImport, Guid("29038f61-3839-4626-91fd-086879011a05"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIAdapter1 : IDXGIAdapter
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
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppParent);

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
		DXGI_ADAPTER_DESC1 GetDesc1();
	}

	/// <summary>An <c>IDXGIDevice</c> interface implements a derived class for DXGI objects that produce image data.</summary>
	/// <remarks>
	/// <para>
	/// The <c>IDXGIDevice</c> interface is designed for use by DXGI objects that need access to other DXGI objects. This interface is
	/// useful to applications that do not use Direct3D to communicate with DXGI.
	/// </para>
	/// <para>
	/// The Direct3D create device functions return a Direct3D device object. This Direct3D device object implements the IUnknown interface.
	/// You can query this Direct3D device object for the device's corresponding <c>IDXGIDevice</c> interface. To retrieve the
	/// <c>IDXGIDevice</c> interface of a Direct3D device, use the following code:
	/// </para>
	/// <para><c>Windows Phone 8:</c> This API is supported.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgidevice
	[PInvokeData("dxgi.h"), ComImport, Guid("54ec77fa-1377-44e6-8c32-88fd5f44c84c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIDevice : IDXGIObject
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
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppParent);

		/// <summary>Returns the adapter for the specified device.</summary>
		/// <returns>
		/// <para>Type: <c>IDXGIAdapter**</c></para>
		/// <para>The address of an IDXGIAdapter interface pointer to the adapter. This parameter must not be <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// If the <c>GetAdapter</c> method succeeds, the reference count on the adapter interface will be incremented. To avoid a memory
		/// leak, be sure to release the interface when you are finished using it.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgidevice-getadapter HRESULT GetAdapter( IDXGIAdapter
		// **pAdapter );
		IDXGIAdapter GetAdapter();

		/// <summary>Returns a surface. This method is used internally and you should not call it directly in your application.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>const DXGI_SURFACE_DESC*</c></para>
		/// <para>A pointer to a DXGI_SURFACE_DESC structure that describes the surface.</para>
		/// </param>
		/// <param name="NumSurfaces">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of surfaces to create.</para>
		/// </param>
		/// <param name="Usage">
		/// <para>Type: <c>DXGI_USAGE</c></para>
		/// <para>A DXGI_USAGE flag that specifies how the surface is expected to be used.</para>
		/// </param>
		/// <param name="pSharedResource">
		/// <para>Type: <c>const <see cref="DXGI_SHARED_RESOURCE"/>*</c></para>
		/// <para>
		/// An optional pointer to a DXGI_SHARED_RESOURCE structure that contains shared resource information for opening views of such resources.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDXGISurface**</c></para>
		/// <para>The address of an IDXGISurface interface pointer to the first created surface.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CreateSurface</c> method creates a buffer to exchange data between one or more devices. It is used internally, and you
		/// should not directly call it.
		/// </para>
		/// <para>
		/// The runtime automatically creates an IDXGISurface interface when it creates a Direct3D resource object that represents a
		/// surface. For example, the runtime creates an <c>IDXGISurface</c> interface when it calls ID3D11Device::CreateTexture2D or
		/// ID3D10Device::CreateTexture2D to create a 2D texture. To retrieve the <c>IDXGISurface</c> interface that represents the 2D
		/// texture surface, call ID3D11Texture2D::QueryInterface or <c>ID3D10Texture2D::QueryInterface</c>. In this call, you must pass the
		/// identifier of <c>IDXGISurface</c>. If the 2D texture has only a single MIP-map level and does not consist of an array of
		/// textures, <c>QueryInterface</c> succeeds and returns a pointer to the <c>IDXGISurface</c> interface pointer. Otherwise,
		/// <c>QueryInterface</c> fails and does not return the pointer to <c>IDXGISurface</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgidevice-createsurface HRESULT CreateSurface( const
		// DXGI_SURFACE_DESC *pDesc, UINT NumSurfaces, DXGI_USAGE Usage, const DXGI_SHARED_RESOURCE *pSharedResource, IDXGISurface
		// **ppSurface );
		IDXGISurface CreateSurface(in DXGI_SURFACE_DESC pDesc, uint NumSurfaces, DXGI_USAGE Usage, [In, Optional] StructPointer<DXGI_SHARED_RESOURCE> pSharedResource);

		/// <summary>Gets the residency status of an array of resources.</summary>
		/// <param name="ppResources">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>An array of IDXGIResource interfaces.</para>
		/// </param>
		/// <param name="pResidencyStatus">
		/// <para>Type: <c>DXGI_RESIDENCY*</c></para>
		/// <para>
		/// An array of DXGI_RESIDENCY flags. Each element describes the residency status for corresponding element in the ppResources
		/// argument array.
		/// </para>
		/// </param>
		/// <param name="NumResources">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of resources in the ppResources argument array and pResidencyStatus argument array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK if successful; otherwise, returns DXGI_ERROR_DEVICE_REMOVED, E_INVALIDARG, or E_POINTER (see Common HRESULT Values
		/// and WinError.h for more information).
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The information returned by the pResidencyStatus argument array describes the residency status at the time that the
		/// <c>QueryResourceResidency</c> method was called.
		/// </para>
		/// <para><c>Note</c> The residency status will constantly change.</para>
		/// <para>
		/// If you call the <c>QueryResourceResidency</c> method during a device removed state, the pResidencyStatus argument will return
		/// the DXGI_RESIDENCY_RESIDENT_IN_SHARED_MEMORY flag.
		/// </para>
		/// <para><c>Note</c> This method should not be called every frame as it incurs a non-trivial amount of overhead.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgidevice-queryresourceresidency HRESULT
		// QueryResourceResidency( IUnknown * const *ppResources, DXGI_RESIDENCY *pResidencyStatus, UINT NumResources );
		void QueryResourceResidency([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] IDXGIResource[] ppResources,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DXGI_RESIDENCY[] pResidencyStatus, uint NumResources);

		/// <summary>Sets the GPU thread priority.</summary>
		/// <param name="Priority">
		/// <para>Type: <c>INT</c></para>
		/// <para>
		/// A value that specifies the required GPU thread priority. This value must be between -7 and 7, inclusive, where 0 represents
		/// normal priority.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>The values for the Priority parameter function as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Positive values increase the likelihood that the GPU scheduler will grant GPU execution cycles to the device when rendering.</term>
		/// </item>
		/// <item>
		/// <term>Negative values lessen the likelihood that the device will receive GPU execution cycles when devices compete for them.</term>
		/// </item>
		/// <item>
		/// <term>The device is guaranteed to receive some GPU execution cycles at all settings.</term>
		/// </item>
		/// </list>
		/// <para>
		/// To use the <c>SetGPUThreadPriority</c> method, you should have a comprehensive understanding of GPU scheduling. You should
		/// profile your application to ensure that it behaves as intended. If used inappropriately, the <c>SetGPUThreadPriority</c> method
		/// can impede rendering speed and result in a poor user experience.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgidevice-setgputhreadpriority HRESULT SetGPUThreadPriority(
		// INT Priority );
		void SetGPUThreadPriority(int Priority);

		/// <summary>Gets the GPU thread priority.</summary>
		/// <returns>
		/// <para>Type: <c>INT*</c></para>
		/// <para>
		/// A pointer to a variable that receives a value that indicates the current GPU thread priority. The value will be between -7 and
		/// 7, inclusive, where 0 represents normal priority.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgidevice-getgputhreadpriority HRESULT GetGPUThreadPriority(
		// INT *pPriority );
		int GetGPUThreadPriority();
	}

	/// <summary>An <b>IDXGIDevice1</b> interface implements a derived class for DXGI objects that produce image data.</summary>
	/// <remarks>
	/// <para>
	/// This interface is not supported by Direct3D 12 devices. Direct3D 12 applications have direct control over their swapchain
	/// management, so better latency control should be handled by the application. You can make use of Waitable objects (refer to
	/// <c>DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT</c>) and the <c>IDXGISwapChain2::SetMaximumFrameLatency</c> method if desired.
	/// </para>
	/// <para>
	/// This interface is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
	/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) ( <c>KB
	/// 971644</c>) and Windows Server 2008 ( <c>KB 971512</c>).
	/// </para>
	/// <para>
	/// The <b>IDXGIDevice1</b> interface is designed for use by DXGI objects that need access to other DXGI objects. This interface is
	/// useful to applications that do not use Direct3D to communicate with DXGI.
	/// </para>
	/// <para>
	/// The Direct3D create device functions return a Direct3D device object. This Direct3D device object implements the <c>IUnknown</c>
	/// interface. You can query this Direct3D device object for the device's corresponding <b>IDXGIDevice1</b> interface. To retrieve the
	/// <b>IDXGIDevice1</b> interface of a Direct3D device, use the following code:
	/// </para>
	/// <para><c>IDXGIDevice1 * pDXGIDevice; hr = g_pd3dDevice-&gt;QueryInterface(__uuidof(IDXGIDevice1), (void **)&amp;pDXGIDevice);</c></para>
	/// <para><b>Windows Phone 8:</b> This API is supported.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgidevice1
	[PInvokeData("dxgi.h", MSDNShortId = "NN:dxgi.IDXGIDevice1")]
	[ComImport, Guid("77db970f-6276-48ba-ba28-070143b4392c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIDevice1 : IDXGIDevice
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
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppParent);

		/// <summary>Returns the adapter for the specified device.</summary>
		/// <returns>
		/// <para>Type: <c>IDXGIAdapter**</c></para>
		/// <para>The address of an IDXGIAdapter interface pointer to the adapter. This parameter must not be <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// If the <c>GetAdapter</c> method succeeds, the reference count on the adapter interface will be incremented. To avoid a memory
		/// leak, be sure to release the interface when you are finished using it.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgidevice-getadapter HRESULT GetAdapter( IDXGIAdapter
		// **pAdapter );
		new IDXGIAdapter GetAdapter();

		/// <summary>Returns a surface. This method is used internally and you should not call it directly in your application.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>const DXGI_SURFACE_DESC*</c></para>
		/// <para>A pointer to a DXGI_SURFACE_DESC structure that describes the surface.</para>
		/// </param>
		/// <param name="NumSurfaces">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of surfaces to create.</para>
		/// </param>
		/// <param name="Usage">
		/// <para>Type: <c>DXGI_USAGE</c></para>
		/// <para>A DXGI_USAGE flag that specifies how the surface is expected to be used.</para>
		/// </param>
		/// <param name="pSharedResource">
		/// <para>Type: <c>const <see cref="DXGI_SHARED_RESOURCE"/>*</c></para>
		/// <para>
		/// An optional pointer to a DXGI_SHARED_RESOURCE structure that contains shared resource information for opening views of such resources.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDXGISurface**</c></para>
		/// <para>The address of an IDXGISurface interface pointer to the first created surface.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CreateSurface</c> method creates a buffer to exchange data between one or more devices. It is used internally, and you
		/// should not directly call it.
		/// </para>
		/// <para>
		/// The runtime automatically creates an IDXGISurface interface when it creates a Direct3D resource object that represents a
		/// surface. For example, the runtime creates an <c>IDXGISurface</c> interface when it calls ID3D11Device::CreateTexture2D or
		/// ID3D10Device::CreateTexture2D to create a 2D texture. To retrieve the <c>IDXGISurface</c> interface that represents the 2D
		/// texture surface, call ID3D11Texture2D::QueryInterface or <c>ID3D10Texture2D::QueryInterface</c>. In this call, you must pass the
		/// identifier of <c>IDXGISurface</c>. If the 2D texture has only a single MIP-map level and does not consist of an array of
		/// textures, <c>QueryInterface</c> succeeds and returns a pointer to the <c>IDXGISurface</c> interface pointer. Otherwise,
		/// <c>QueryInterface</c> fails and does not return the pointer to <c>IDXGISurface</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgidevice-createsurface HRESULT CreateSurface( const
		// DXGI_SURFACE_DESC *pDesc, UINT NumSurfaces, DXGI_USAGE Usage, const DXGI_SHARED_RESOURCE *pSharedResource, IDXGISurface
		// **ppSurface );
		new IDXGISurface CreateSurface(in DXGI_SURFACE_DESC pDesc, uint NumSurfaces, DXGI_USAGE Usage, [In, Optional] StructPointer<DXGI_SHARED_RESOURCE> pSharedResource);

		/// <summary>Gets the residency status of an array of resources.</summary>
		/// <param name="ppResources">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>An array of IDXGIResource interfaces.</para>
		/// </param>
		/// <param name="pResidencyStatus">
		/// <para>Type: <c>DXGI_RESIDENCY*</c></para>
		/// <para>
		/// An array of DXGI_RESIDENCY flags. Each element describes the residency status for corresponding element in the ppResources
		/// argument array.
		/// </para>
		/// </param>
		/// <param name="NumResources">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of resources in the ppResources argument array and pResidencyStatus argument array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK if successful; otherwise, returns DXGI_ERROR_DEVICE_REMOVED, E_INVALIDARG, or E_POINTER (see Common HRESULT Values
		/// and WinError.h for more information).
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The information returned by the pResidencyStatus argument array describes the residency status at the time that the
		/// <c>QueryResourceResidency</c> method was called.
		/// </para>
		/// <para><c>Note</c> The residency status will constantly change.</para>
		/// <para>
		/// If you call the <c>QueryResourceResidency</c> method during a device removed state, the pResidencyStatus argument will return
		/// the DXGI_RESIDENCY_RESIDENT_IN_SHARED_MEMORY flag.
		/// </para>
		/// <para><c>Note</c> This method should not be called every frame as it incurs a non-trivial amount of overhead.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgidevice-queryresourceresidency HRESULT
		// QueryResourceResidency( IUnknown * const *ppResources, DXGI_RESIDENCY *pResidencyStatus, UINT NumResources );
		new void QueryResourceResidency([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] IDXGIResource[] ppResources,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DXGI_RESIDENCY[] pResidencyStatus, uint NumResources);

		/// <summary>Sets the GPU thread priority.</summary>
		/// <param name="Priority">
		/// <para>Type: <c>INT</c></para>
		/// <para>
		/// A value that specifies the required GPU thread priority. This value must be between -7 and 7, inclusive, where 0 represents
		/// normal priority.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>The values for the Priority parameter function as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Positive values increase the likelihood that the GPU scheduler will grant GPU execution cycles to the device when rendering.</term>
		/// </item>
		/// <item>
		/// <term>Negative values lessen the likelihood that the device will receive GPU execution cycles when devices compete for them.</term>
		/// </item>
		/// <item>
		/// <term>The device is guaranteed to receive some GPU execution cycles at all settings.</term>
		/// </item>
		/// </list>
		/// <para>
		/// To use the <c>SetGPUThreadPriority</c> method, you should have a comprehensive understanding of GPU scheduling. You should
		/// profile your application to ensure that it behaves as intended. If used inappropriately, the <c>SetGPUThreadPriority</c> method
		/// can impede rendering speed and result in a poor user experience.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgidevice-setgputhreadpriority HRESULT SetGPUThreadPriority(
		// INT Priority );
		new void SetGPUThreadPriority(int Priority);

		/// <summary>Gets the GPU thread priority.</summary>
		/// <returns>
		/// <para>Type: <c>INT*</c></para>
		/// <para>
		/// A pointer to a variable that receives a value that indicates the current GPU thread priority. The value will be between -7 and
		/// 7, inclusive, where 0 represents normal priority.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgidevice-getgputhreadpriority HRESULT GetGPUThreadPriority(
		// INT *pPriority );
		new int GetGPUThreadPriority();

		/// <summary>Sets the number of frames that the system is allowed to queue for rendering.</summary>
		/// <param name="MaxLatency">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// The maximum number of back buffer frames that a driver can queue. The value defaults to 3, but can range from 1 to 16. A value
		/// of 0 will reset latency to the default. For multi-head devices, this value is specified per-head.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns S_OK if successful; otherwise, DXGI_ERROR_DEVICE_REMOVED if the device was removed.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
		/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) ( <c>KB
		/// 971644</c>) and Windows Server 2008 ( <c>KB 971512</c>).
		/// </para>
		/// <para>
		/// Frame latency is the number of frames that are allowed to be stored in a queue before submission for rendering. Latency is often
		/// used to control how the CPU chooses between responding to user input and frames that are in the render queue. It is often
		/// beneficial for applications that have no user input (for example, video playback) to queue more than 3 frames of data.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgidevice1-setmaximumframelatency HRESULT
		// SetMaximumFrameLatency( UINT MaxLatency );
		[PreserveSig]
		HRESULT SetMaximumFrameLatency(uint MaxLatency);

		/// <summary>Gets the number of frames that the system is allowed to queue for rendering.</summary>
		/// <param name="pMaxLatency">
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>
		/// This value is set to the number of frames that can be queued for render. This value defaults to 3, but can range from 1 to 16.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following members of the <c>D3DERR</c> enumerated type:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><b>D3DERR_DEVICELOST</b></description>
		/// </item>
		/// <item>
		/// <description><b>D3DERR_DEVICEREMOVED</b></description>
		/// </item>
		/// <item>
		/// <description><b>D3DERR_DRIVERINTERNALERROR</b></description>
		/// </item>
		/// <item>
		/// <description><b>D3DERR_INVALIDCALL</b></description>
		/// </item>
		/// <item>
		/// <description><b>D3DERR_OUTOFVIDEOMEMORY</b></description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
		/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) ( <c>KB
		/// 971644</c>) and Windows Server 2008 ( <c>KB 971512</c>).
		/// </para>
		/// <para>
		/// Frame latency is the number of frames that are allowed to be stored in a queue before submission for rendering. Latency is often
		/// used to control how the CPU chooses between responding to user input and frames that are in the render queue. It is often
		/// beneficial for applications that have no user input (for example, video playback) to queue more than 3 frames of data.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgidevice1-getmaximumframelatency HRESULT
		// GetMaximumFrameLatency( [out] UINT *pMaxLatency );
		[PreserveSig]
		HRESULT GetMaximumFrameLatency(out uint pMaxLatency);
	}

	/// <summary>Inherited from objects that are tied to the device so that they can retrieve a pointer to it.</summary>
	/// <remarks><c>Windows Phone 8:</c> This API is supported.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgidevicesubobject
	[ComImport, Guid("3d3e0379-f9de-4d58-bb6c-18d62992f1a6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIDeviceSubObject : IDXGIObject
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
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppParent);

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
		HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object? ppDevice);
	}

	/// <summary>An <c>IDXGIFactory</c> interface implements methods for generating DXGI objects (which handle full screen transitions).</summary>
	/// <remarks>
	/// <para>Create a factory by calling CreateDXGIFactory.</para>
	/// <para>
	/// Because you can create a Direct3D device without creating a swap chain, you might need to retrieve the factory that is used to
	/// create the device in order to create a swap chain. You can request the IDXGIDevice interface from the Direct3D device and then use
	/// the IDXGIObject::GetParent method to locate the factory. The following code shows how.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This API is supported.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgifactory
	[PInvokeData("dxgi.h"), ComImport, Guid("7b7166ec-21c7-44ae-b21a-c9ae321ae369"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIFactory : IDXGIObject
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
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppParent);

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
		HRESULT EnumAdapters(uint Adapter, out IDXGIAdapter? ppAdapter);

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
		void MakeWindowAssociation(HWND WindowHandle, DXGI_MWA Flags);

		/// <summary>Get the window through which the user controls the transition to and from full screen.</summary>
		/// <returns>
		/// <para>Type: <c>HWND*</c></para>
		/// <para>A pointer to a window handle.</para>
		/// </returns>
		/// <remarks><c>Note</c> If you call this API in a Session 0 process, it returns DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory-getwindowassociation HRESULT GetWindowAssociation(
		// HWND *pWindowHandle );
		HWND GetWindowAssociation();

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
		IDXGISwapChain CreateSwapChain([In, MarshalAs(UnmanagedType.Interface)] object pDevice, in DXGI_SWAP_CHAIN_DESC pDesc);

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
		IDXGIAdapter CreateSoftwareAdapter(HINSTANCE Module);
	}

	/// <summary>The <c>IDXGIFactory1</c> interface implements methods for generating DXGI objects.</summary>
	/// <remarks>
	/// <para>
	/// This interface is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
	/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and
	/// Windows Server 2008 (KB 971512).
	/// </para>
	/// <para>To create a factory, call the CreateDXGIFactory1 function.</para>
	/// <para>
	/// Because you can create a Direct3D device without creating a swap chain, you might need to retrieve the factory that is used to
	/// create the device in order to create a swap chain. You can request the IDXGIDevice or IDXGIDevice1 interface from the Direct3D
	/// device and then use the IDXGIObject::GetParent method to locate the factory. The following code shows how.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgifactory1
	[ComImport, Guid("770aae78-f26f-4dba-a829-253c83d1b387"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIFactory1 : IDXGIFactory
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
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppParent);

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
		HRESULT EnumAdapters1(uint Adapter, out IDXGIAdapter1? ppAdapter);

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
		bool IsCurrent();
	}

	/// <summary>Represents a keyed mutex, which allows exclusive access to a shared resource that is used by multiple devices.</summary>
	/// <remarks>
	/// <para>The <c>IDXGIFactory1</c> is required to create a resource capable of supporting the <b>IDXGIKeyedMutex</b> interface.</para>
	/// <para>
	/// An <b>IDXGIKeyedMutex</b> should be retrieved for each device sharing a resource. In Direct3D 10.1, such a resource that is shared
	/// between two or more devices is created with the <c>D3D10_RESOURCE_MISC_SHARED_KEYEDMUTEX</c> flag. In Direct3D 11, such a resource that
	/// is shared between two or more devices is created with the <c>D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX</c> flag.
	/// </para>
	/// <para>For information about creating a keyed mutex, see the <c>IDXGIKeyedMutex::AcquireSync</c> method.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgikeyedmutex
	[PInvokeData("dxgi.h", MSDNShortId = "NN:dxgi.IDXGIKeyedMutex")]
	[ComImport, Guid("9d8e1289-d7b3-465f-8126-250e349af85d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIKeyedMutex
	{
		/// <summary>Using a key, acquires exclusive rendering access to a shared resource.</summary>
		/// <param name="Key">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>
		/// A value that indicates which device to give access to. This method will succeed when the device that currently owns the surface
		/// calls the <c>IDXGIKeyedMutex::ReleaseSync</c> method using the same value. This value can be any UINT64 value.
		/// </para>
		/// </param>
		/// <param name="dwMilliseconds">
		/// <para>Type: <b><c>DWORD</c></b></para>
		/// <para>
		/// The time-out interval, in milliseconds. This method will return if the interval elapses, and the keyed mutex has not been released
		/// using the specified <i>Key</i>. If this value is set to zero, the <b>AcquireSync</b> method will test to see if the keyed mutex has
		/// been released and returns immediately. If this value is set to INFINITE, the time-out interval will never elapse.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Return S_OK if successful.</para>
		/// <para>If the owning device attempted to create another keyed mutex on the same shared resource, <b>AcquireSync</b> returns E_FAIL.</para>
		/// <para>
		/// <b>AcquireSync</b> can also return the following <c>DWORD</c> constants. Therefore, you should explicitly check for these constants.
		/// If you only use the <c>SUCCEEDED</c> macro on the return value to determine if <b>AcquireSync</b> succeeded, you will not catch
		/// these constants.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// WAIT_ABANDONED - The shared surface and keyed mutex are no longer in a consistent state. If <b>AcquireSync</b> returns this value,
		/// you should release and recreate both the keyed mutex and the shared surface.
		/// </description>
		/// </item>
		/// <item>
		/// <description>WAIT_TIMEOUT - The time-out interval elapsed before the specified key was released.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <b>AcquireSync</b> method creates a lock to a surface that is shared between multiple devices, allowing only one device to
		/// render to a surface at a time. This method uses a key to determine which device currently has exclusive access to the surface.
		/// </para>
		/// <para>
		/// When a surface is created using the <b>D3D10_RESOURCE_MISC_SHARED_KEYEDMUTEX</b> value of the <c>D3D10_RESOURCE_MISC_FLAG</c>
		/// enumeration, you must call the <b>AcquireSync</b> method before rendering to the surface. You must call the <c>ReleaseSync</c>
		/// method when you are done rendering to a surface.
		/// </para>
		/// <para>
		/// To acquire a reference to the keyed mutex object of a shared resource, call the <c>QueryInterface</c> method of the resource and
		/// pass in the <b>UUID</b> of the <c>IDXGIKeyedMutex</c> interface. For more information about acquiring this reference, see the
		/// following code example.
		/// </para>
		/// <para>The <b>AcquireSync</b> method uses the key as follows, depending on the state of the surface:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// On initial creation, the surface is unowned and any device can call the <b>AcquireSync</b> method to gain access. For an unowned
		/// device, only a key of 0 will succeed. Calling the <b>AcquireSync</b> method for any other key will stall the calling CPU thread.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the surface is owned by a device when you call the <b>AcquireSync</b> method, the CPU thread that called the <b>AcquireSync</b>
		/// method will stall until the owning device calls the <c>ReleaseSync</c> method using the same Key.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the surface is unowned when you call the <b>AcquireSync</b> method (for example, the last owning device has already called the
		/// <c>ReleaseSync</c> method), the <b>AcquireSync</b> method will succeed if you specify the same key that was specified when the
		/// <b>ReleaseSync</b> method was last called. Calling the <b>AcquireSync</b> method using any other key will cause a stall.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// When the owning device calls the <c>ReleaseSync</c> method with a particular key, and more than one device is waiting after calling
		/// the <b>AcquireSync</b> method using the same key, any one of the waiting devices could be woken up first. The order in which devices
		/// are woken up is undefined.
		/// </description>
		/// </item>
		/// <item>
		/// <description>A keyed mutex does not support recursive calls to the <b>AcquireSync</b> method.</description>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para><b>Acquiring a Keyed Mutex</b></para>
		/// <para>The following code example demonstrates how to acquire a lock to a shared resource and how to specify a key upon release.</para>
		/// <para>
		/// <c>// pDesc has already been set up with texture description. pDesc.MiscFlags = D3D10_RESOURCE_MISC_SHARED_KEYEDMUTEX; // Create a
		/// shared texture resource. pD3D10DeviceD-&gt;CreateTexture2D(pDesc, NULL, pD3D10Texture); // Acquire a reference to the keyed mutex.
		/// pD3D10Texture-&gt;QueryInterface(_uuidof(IDXGIKeyedMutex), pDXGIKeyedMutex); // Acquire a lock to the resource.
		/// pDXGIKeyedMutex-&gt;AcquireSync(0, INFINITE); // Release the lock and specify a key. pDXGIKeyedMutex-&gt;ReleaseSync(1);</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgikeyedmutex-acquiresync HRESULT AcquireSync( UINT64 Key, DWORD
		// dwMilliseconds );
		[PreserveSig]
		HRESULT AcquireSync(ulong Key, uint dwMilliseconds);

		/// <summary>Using a key, releases exclusive rendering access to a shared resource.</summary>
		/// <param name="Key">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>
		/// A value that indicates which device to give access to. This method succeeds when the device that currently owns the surface calls
		/// the <b>ReleaseSync</b> method using the same value. This value can be any UINT64 value.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns S_OK if successful.</para>
		/// <para>If the device attempted to release a keyed mutex that is not valid or owned by the device, <b>ReleaseSync</b> returns E_FAIL.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <b>ReleaseSync</b> method releases a lock to a surface that is shared between multiple devices. This method uses a key to
		/// determine which device currently has exclusive access to the surface.
		/// </para>
		/// <para>
		/// When a surface is created using the <b>D3D10_RESOURCE_MISC_SHARED_KEYEDMUTEX</b> value of the <c>D3D10_RESOURCE_MISC_FLAG</c>
		/// enumeration, you must call the <c>IDXGIKeyedMutex::AcquireSync</c> method before rendering to the surface. You must call the
		/// <b>ReleaseSync</b> method when you are done rendering to a surface.
		/// </para>
		/// <para>After you call the <b>ReleaseSync</b> method, the shared resource is unset from the rendering pipeline.</para>
		/// <para>
		/// To acquire a reference to the keyed mutex object of a shared resource, call the <c>QueryInterface</c> method of the resource and
		/// pass in the <b>UUID</b> of the <c>IDXGIKeyedMutex</c> interface. For more information about acquiring this reference, see the
		/// following code example.
		/// </para>
		/// <para>Examples</para>
		/// <para><b>Acquiring a Keyed Mutex</b></para>
		/// <para>The following code example demonstrates how to acquire a lock to a shared resource and how to specify a key upon release.</para>
		/// <para>
		/// <c>// pDesc has already been set up with texture description. pDesc.MiscFlags = D3D10_RESOURCE_MISC_SHARED_KEYEDMUTEX; // Create a
		/// shared texture resource. pD3D10DeviceD-&gt;CreateTexture2D(pDesc, NULL, pD3D10Texture); // Acquire a reference to the keyed mutex.
		/// pD3D10Texture-&gt;QueryInterface(_uuidof(IDXGIKeyedMutex), pDXGIKeyedMutex); // Acquire a lock to the resource.
		/// pDXGIKeyedMutex-&gt;AcquireSync(0, INFINITE); // Release the lock and specify a key. pDXGIKeyedMutex-&gt;ReleaseSync(1);</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgikeyedmutex-releasesync HRESULT ReleaseSync( UINT64 Key );
		[PreserveSig]
		HRESULT ReleaseSync(ulong Key);
	}
	
	/// <summary>
		/// An <c>IDXGIObject</c> interface is a base interface for all DXGI objects; <c>IDXGIObject</c> supports associating caller-defined
		/// (private data) with an object and retrieval of an interface to the parent object.
		/// </summary>
		/// <remarks>
		/// <para><c>IDXGIObject</c> implements base-class functionality for the following interfaces:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IDXGIAdapter</term>
		/// </item>
		/// <item>
		/// <term>IDXGIDevice</term>
		/// </item>
		/// <item>
		/// <term>IDXGIFactory</term>
		/// </item>
		/// <item>
		/// <term>IDXGIOutput</term>
		/// </item>
		/// </list>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgiobject
	[ComImport, Guid("aec22fb8-76f3-4639-9be0-28eb43a67a2e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIObject
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
		void SetPrivateData(in Guid Name, uint DataSize, IntPtr pData);

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
		void SetPrivateDataInterface(in Guid Name, [In, Optional, MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] object? pUnknown);

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
		HRESULT GetPrivateData(in Guid Name, ref uint pDataSize, [Out] IntPtr pData);

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
		HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppParent);
	}

	/// <summary>An <c>IDXGIOutput</c> interface represents an adapter output (such as a monitor).</summary>
	/// <remarks>
	/// To see the outputs available, use IDXGIAdapter::EnumOutputs. To see the specific output that the swap chain will update, use IDXGISwapChain::GetContainingOutput.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgioutput
	[PInvokeData("dxgi.h"), ComImport, Guid("ae02eedb-c735-4690-8d52-5a8dc20213aa"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIOutput : IDXGIObject
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
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppParent);

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
		DXGI_OUTPUT_DESC GetDesc();

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
		void GetDisplayModeList(DXGI_FORMAT EnumFormat, DXGI_ENUM_MODES Flags, ref uint pNumModes, [Out, Optional] DXGI_MODE_DESC[]? pDesc);

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
		void FindClosestMatchingMode(in DXGI_MODE_DESC pModeToMatch, out DXGI_MODE_DESC pClosestMatch, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pConcernedDevice);

		/// <summary>Halt a thread until the next vertical blank occurs.</summary>
		/// <remarks>
		/// A vertical blank occurs when the raster moves from the lower right corner to the upper left corner to begin drawing the next frame.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-waitforvblank HRESULT WaitForVBlank();
		void WaitForVBlank();

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
		void TakeOwnership([In, MarshalAs(UnmanagedType.Interface)] object pDevice, [MarshalAs(UnmanagedType.Bool)] bool Exclusive);

		/// <summary>Releases ownership of the output.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// If you are not using a swap chain, get access to an output by calling IDXGIOutput::TakeOwnership and release it when you are
		/// finished by calling <c>IDXGIOutput::ReleaseOwnership</c>. An application that uses a swap chain will typically not call either
		/// of these methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-releaseownership void ReleaseOwnership();
		[PreserveSig]
		void ReleaseOwnership();

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
		DXGI_GAMMA_CONTROL_CAPABILITIES GetGammaControlCapabilities();

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
		void SetGammaControl(in DXGI_GAMMA_CONTROL pArray);

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
		DXGI_GAMMA_CONTROL GetGammaControl();

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
		void SetDisplaySurface([In] IDXGISurface pScanoutSurface);

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
		void GetDisplaySurfaceData([In] IDXGISurface pDestination);

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
		DXGI_FRAME_STATISTICS GetFrameStatistics();
	}

	/// <summary>An <b>IDXGIResource</b> interface allows resource sharing and identifies the memory that a resource resides in.</summary>
	/// <remarks>
	/// <para>
	/// To find out what type of memory a resource is currently located in, use <c>IDXGIDevice::QueryResourceResidency</c>. To share
	/// resources between processes, use <c>ID3D10Device::OpenSharedResource</c>. For information about how to share resources between
	/// multiple Windows graphics APIs, including Direct3D 11, Direct2D, Direct3D 10, and Direct3D 9Ex, see <c>Surface Sharing Between
	/// Windows Graphics APIs</c>.
	/// </para>
	/// <para>
	/// You can retrieve the <b>IDXGIResource</b> interface from any video memory resource that you create from a Direct3D 10 and later
	/// function. Any Direct3D object that supports <c>ID3D10Resource</c> or <c>ID3D11Resource</c> also supports <b>IDXGIResource</b>. For
	/// example, the Direct3D 2D texture object that you create from <c>ID3D11Device::CreateTexture2D</c> supports <b>IDXGIResource</b>. You
	/// can call <c>QueryInterface</c> on the 2D texture object ( <c>ID3D11Texture2D</c>) to retrieve the <b>IDXGIResource</b> interface.
	/// For example, to retrieve the <b>IDXGIResource</b> interface from the 2D texture object, use the following code.
	/// </para>
	/// <para><c>IDXGIResource * pDXGIResource; hr = g_pd3dTexture2D-&gt;QueryInterface(__uuidof(IDXGIResource), (void **)&amp;pDXGIResource);</c></para>
	/// <para><b>Windows Phone 8:</b> This API is supported.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgiresource
	[PInvokeData("dxgi.h", MSDNShortId = "NN:dxgi.IDXGIResource")]
	[ComImport, Guid("035f3ab4-482e-4e50-b41f-8a7f8bd8960b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIResource : IDXGIDeviceSubObject
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
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppParent);

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

		/// <summary>Gets the handle to a shared resource.</summary>
		/// <param name="pSharedHandle">
		/// <para>Type: <b><c>HANDLE</c>*</b></para>
		/// <para>A pointer to a handle.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>DXGI_ERROR</c> values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>GetSharedHandle</b> returns a handle for the resource that you created as shared (that is, you set the
		/// <c>D3D11_RESOURCE_MISC_SHARED</c> with or without the <c>D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX</c> flag). You can pass this
		/// handle to the <c>ID3D11Device::OpenSharedResource</c> method to give another device access to the shared resource. You can also
		/// marshal this handle to another process to share a resource with a device in another process. However, this handle is not an NT
		/// handle. Therefore, don't use the handle with <c>CloseHandle</c>, <c>DuplicateHandle</c>, and so on.
		/// </para>
		/// <para>
		/// The creator of a shared resource must not destroy the resource until all intended entities have opened the resource. The
		/// validity of the handle is tied to the lifetime of the underlying video memory. If no resource objects exist on any devices that
		/// refer to this resource, the handle is no longer valid. To extend the lifetime of the handle and video memory, you must open the
		/// shared resource on a device.
		/// </para>
		/// <para>
		/// <b>GetSharedHandle</b> can also return handles for resources that were passed into <c>ID3D11Device::OpenSharedResource</c> to
		/// open those resources.
		/// </para>
		/// <para><b>GetSharedHandle</b> fails if the resource to which it wants to get a handle is not shared.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiresource-getsharedhandle HRESULT GetSharedHandle( [out]
		// HANDLE *pSharedHandle );
		[PreserveSig]
		HRESULT GetSharedHandle(out HANDLE pSharedHandle);

		/// <summary>Get the expected resource usage.</summary>
		/// <returns>
		///   <para>Type: <b><c>DXGI_USAGE</c>*</b></para>
		///   <para>
		/// A pointer to a usage flag (see <c>DXGI_USAGE</c>). For Direct3D 10, a surface can be used as a shader input or a render-target output.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiresource-getusage HRESULT GetUsage( DXGI_USAGE *pUsage );
		DXGI_USAGE GetUsage();

		/// <summary>Set the priority for evicting the resource from memory.</summary>
		/// <param name="EvictionPriority">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The priority is one of the following values:</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_RESOURCE_PRIORITY_MINIMUM (0x28000000)</b>
		///       </description>
		///       <description>
		/// The resource is unused and can be evicted as soon as another resource requires the memory that the resource occupies.
		/// </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_RESOURCE_PRIORITY_LOW (0x50000000)</b>
		///       </description>
		///       <description>
		/// The eviction priority of the resource is low. The placement of the resource is not critical, and minimal work is performed to
		/// find a location for the resource. For example, if a GPU can render with a vertex buffer from either local or non-local memory
		/// with little difference in performance, that vertex buffer is low priority. Other more critical resources (for example, a render
		/// target or texture) can then occupy the faster memory.
		/// </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_RESOURCE_PRIORITY_NORMAL (0x78000000)</b>
		///       </description>
		///       <description>
		/// The eviction priority of the resource is normal. The placement of the resource is important, but not critical, for performance.
		/// The resource is placed in its preferred location instead of a low-priority resource.
		/// </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_RESOURCE_PRIORITY_HIGH (0xa0000000)</b>
		///       </description>
		///       <description>
		/// The eviction priority of the resource is high. The resource is placed in its preferred location instead of a low-priority or
		/// normal-priority resource.
		/// </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_RESOURCE_PRIORITY_MAXIMUM (0xc8000000)</b>
		///       </description>
		///       <description>The resource is evicted from memory only if there is no other way of resolving the memory requirement.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <remarks>
		///   <para>
		/// The eviction priority is a memory-management variable that is used by DXGI for determining how to populate overcommitted memory.
		/// </para>
		///   <para>
		/// You can set priority levels other than the defined values when appropriate. For example, you can set a resource with a priority
		/// level of 0x78000001 to indicate that the resource is slightly above normal.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiresource-setevictionpriority HRESULT SetEvictionPriority(
		// UINT EvictionPriority );
		void SetEvictionPriority(uint EvictionPriority);

		/// <summary>Get the eviction priority.</summary>
		/// <returns>
		///   <para>Type: <b><c>UINT</c>*</b></para>
		///   <para>A pointer to the eviction priority, which determines when a resource can be evicted from memory.</para>
		///   <para>The following defined values are possible.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_RESOURCE_PRIORITY_MINIMUM (0x28000000)</b>
		///       </description>
		///       <description>
		/// The resource is unused and can be evicted as soon as another resource requires the memory that the resource occupies.
		/// </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_RESOURCE_PRIORITY_LOW (0x50000000)</b>
		///       </description>
		///       <description>
		/// The eviction priority of the resource is low. The placement of the resource is not critical, and minimal work is performed to
		/// find a location for the resource. For example, if a GPU can render with a vertex buffer from either local or non-local memory
		/// with little difference in performance, that vertex buffer is low priority. Other more critical resources (for example, a render
		/// target or texture) can then occupy the faster memory.
		/// </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_RESOURCE_PRIORITY_NORMAL (0x78000000)</b>
		///       </description>
		///       <description>
		/// The eviction priority of the resource is normal. The placement of the resource is important, but not critical, for performance.
		/// The resource is placed in its preferred location instead of a low-priority resource.
		/// </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_RESOURCE_PRIORITY_HIGH (0xa0000000)</b>
		///       </description>
		///       <description>
		/// The eviction priority of the resource is high. The resource is placed in its preferred location instead of a low-priority or
		/// normal-priority resource.
		/// </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_RESOURCE_PRIORITY_MAXIMUM (0xc8000000)</b>
		///       </description>
		///       <description>The resource is evicted from memory only if there is no other way of resolving the memory requirement.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>
		///   <para>The eviction priority is a memory-management variable that is used by DXGI to determine how to manage overcommitted memory.</para>
		///   <para>
		/// Priority levels other than the defined values are used when appropriate. For example, a resource with a priority level of
		/// 0x78000001 indicates that the resource is slightly above normal.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiresource-getevictionpriority HRESULT GetEvictionPriority(
		// [out] UINT *pEvictionPriority );
		uint GetEvictionPriority();
	}

	/// <summary>The <c>IDXGISurface</c> interface implements methods for image-data objects.</summary>
	/// <remarks>
	/// <para>An image-data object is a 2D section of memory, commonly called a surface. To get the surface from an output, call IDXGIOutput::GetDisplaySurfaceData.</para>
	/// <para>
	/// The runtime automatically creates an <c>IDXGISurface</c> interface when it creates a Direct3D resource object that represents a
	/// surface. For example, the runtime creates an <c>IDXGISurface</c> interface when you call ID3D11Device::CreateTexture2D or
	/// ID3D10Device::CreateTexture2D to create a 2D texture. To retrieve the <c>IDXGISurface</c> interface that represents the 2D texture
	/// surface, call ID3D11Texture2D::QueryInterface or <c>ID3D10Texture2D::QueryInterface</c>. In this call, you must pass the identifier
	/// of <c>IDXGISurface</c>. If the 2D texture has only a single MIP-map level and does not consist of an array of textures,
	/// <c>QueryInterface</c> succeeds and returns a pointer to the <c>IDXGISurface</c> interface pointer. Otherwise, <c>QueryInterface</c>
	/// fails and does not return the pointer to <c>IDXGISurface</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgisurface
	[PInvokeData("dxgi.h"), ComImport, Guid("cafcb56c-6ac3-4889-bf47-9e23bbd260ec"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGISurface : IDXGIDeviceSubObject
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
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppParent);

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

		/// <summary>Get a description of the surface.</summary>
		/// <returns>
		/// <para>Type: <c>DXGI_SURFACE_DESC*</c></para>
		/// <para>A pointer to the surface description (see DXGI_SURFACE_DESC).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgisurface-getdesc HRESULT GetDesc( DXGI_SURFACE_DESC
		// *pDesc );
		DXGI_SURFACE_DESC GetDesc();

		/// <summary>Get a pointer to the data contained in the surface, and deny GPU access to the surface.</summary>
		/// <param name="pLockedRect">
		/// <para>Type: <c>DXGI_MAPPED_RECT*</c></para>
		/// <para>A pointer to the surface data (see DXGI_MAPPED_RECT).</para>
		/// </param>
		/// <param name="MapFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>CPU read-write flags. These flags can be combined with a logical OR.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>DXGI_MAP_READ - Allow CPU read access.</term>
		/// </item>
		/// <item>
		/// <term>DXGI_MAP_WRITE - Allow CPU write access.</term>
		/// </item>
		/// <item>
		/// <term>DXGI_MAP_DISCARD - Discard the previous contents of a resource when it is mapped.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// Use <c>IDXGISurface::Map</c> to access a surface from the CPU. To release a mapped surface (and allow GPU access) call IDXGISurface::Unmap.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgisurface-map HRESULT Map( DXGI_MAPPED_RECT *pLockedRect, UINT
		// MapFlags );
		void Map(out DXGI_MAPPED_RECT pLockedRect, DXGI_MAP MapFlags);

		/// <summary>Invalidate the pointer to the surface retrieved by IDXGISurface::Map and re-enable GPU access to the resource.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgisurface-unmap HRESULT Unmap();
		void Unmap();
	}

	/// <summary>
	/// The <b>IDXGISurface1</b> interface extends the <c>IDXGISurface</c> by adding support for using Windows Graphics Device Interface
	/// (GDI) to render to a Microsoft DirectX Graphics Infrastructure (DXGI) surface.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This interface is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
	/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) ( <c>KB
	/// 971644</c>) and Windows Server 2008 ( <c>KB 971512</c>).
	/// </para>
	/// <para>
	/// An image-data object is a 2D section of memory, commonly called a surface. To get the surface from an output, call
	/// <c>IDXGIOutput::GetDisplaySurfaceData</c>. Then, call <c>QueryInterface</c> on the <c>IDXGISurface</c> object that
	/// <b>IDXGIOutput::GetDisplaySurfaceData</b> returns to retrieve the <b>IDXGISurface1</b> interface.
	/// </para>
	/// <para>Any object that supports <c>IDXGISurface</c> also supports <b>IDXGISurface1</b>.</para>
	/// <para>
	/// The runtime automatically creates an <b>IDXGISurface1</b> interface when it creates a Direct3D resource object that represents a
	/// surface. For example, the runtime creates an <b>IDXGISurface1</b> interface when you call <c>ID3D11Device::CreateTexture2D</c> or
	/// <c>ID3D10Device::CreateTexture2D</c> to create a 2D texture. To retrieve the <b>IDXGISurface1</b> interface that represents the 2D
	/// texture surface, call <c>ID3D11Texture2D::QueryInterface</c> or <b>ID3D10Texture2D::QueryInterface</b>. In this call, you must pass
	/// the identifier of <b>IDXGISurface1</b>. If the 2D texture has only a single MIP-map level and does not consist of an array of
	/// textures, <b>QueryInterface</b> succeeds and returns a pointer to the <b>IDXGISurface1</b> interface pointer. Otherwise,
	/// <b>QueryInterface</b> fails and does not return the pointer to <b>IDXGISurface1</b>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgisurface1
	[PInvokeData("dxgi.h", MSDNShortId = "NN:dxgi.IDXGISurface1")]
	[ComImport, Guid("4ae63092-6327-4c1b-80ae-bfe12ea32b86"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGISurface1 : IDXGISurface
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
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppParent);

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

		/// <summary>Get a description of the surface.</summary>
		/// <returns>
		/// <para>Type: <c>DXGI_SURFACE_DESC*</c></para>
		/// <para>A pointer to the surface description (see DXGI_SURFACE_DESC).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgisurface-getdesc HRESULT GetDesc( DXGI_SURFACE_DESC
		// *pDesc );
		new DXGI_SURFACE_DESC GetDesc();

		/// <summary>Get a pointer to the data contained in the surface, and deny GPU access to the surface.</summary>
		/// <param name="pLockedRect">
		/// <para>Type: <c>DXGI_MAPPED_RECT*</c></para>
		/// <para>A pointer to the surface data (see DXGI_MAPPED_RECT).</para>
		/// </param>
		/// <param name="MapFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>CPU read-write flags. These flags can be combined with a logical OR.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>DXGI_MAP_READ - Allow CPU read access.</term>
		/// </item>
		/// <item>
		/// <term>DXGI_MAP_WRITE - Allow CPU write access.</term>
		/// </item>
		/// <item>
		/// <term>DXGI_MAP_DISCARD - Discard the previous contents of a resource when it is mapped.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// Use <c>IDXGISurface::Map</c> to access a surface from the CPU. To release a mapped surface (and allow GPU access) call IDXGISurface::Unmap.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgisurface-map HRESULT Map( DXGI_MAPPED_RECT *pLockedRect, UINT
		// MapFlags );
		new void Map(out DXGI_MAPPED_RECT pLockedRect, DXGI_MAP MapFlags);

		/// <summary>Invalidate the pointer to the surface retrieved by IDXGISurface::Map and re-enable GPU access to the resource.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgisurface-unmap HRESULT Unmap();
		new void Unmap();

		/// <summary>
		/// Returns a device context (DC) that allows you to render to a Microsoft DirectX Graphics Infrastructure (DXGI) surface using
		/// Windows Graphics Device Interface (GDI).
		/// </summary>
		/// <param name="Discard">
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para>
		/// A Boolean value that specifies whether to preserve Direct3D contents in the GDI DC. <b>TRUE</b> directs the runtime not to
		/// preserve Direct3D contents in the GDI DC; that is, the runtime discards the Direct3D contents. <b>FALSE</b> guarantees that
		/// Direct3D contents are available in the GDI DC.
		/// </para>
		/// </param>
		/// <param name="phdc">
		/// <para>Type: <b><c>HDC</c>*</b></para>
		/// <para>A pointer to an <c>HDC</c> handle that represents the current device context for GDI rendering.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns S_OK if successful; otherwise, an error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
		/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) ( <c>KB
		/// 971644</c>) and Windows Server 2008 ( <c>KB 971512</c>).
		/// </para>
		/// <para>
		/// After you use the <b>GetDC</b> method to retrieve a DC, you can render to the DXGI surface by using GDI. The <b>GetDC</b> method
		/// readies the surface for GDI rendering and allows inter-operation between DXGI and GDI technologies.
		/// </para>
		/// <para>Keep the following in mind when using this method:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// You must create the surface by using the <c>D3D11_RESOURCE_MISC_GDI_COMPATIBLE</c> flag for a surface or by using the
		/// <c>DXGI_SWAP_CHAIN_FLAG_GDI_COMPATIBLE</c> flag for swap chains, otherwise this method fails.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// You must release the device and call the <c>IDXGISurface1::ReleaseDC</c> method before you issue any new Direct3D commands.
		/// </description>
		/// </item>
		/// <item>
		/// <description>This method fails if an outstanding DC has already been created by this method.</description>
		/// </item>
		/// <item>
		/// <description>The format for the surface or swap chain must be <c>DXGI_FORMAT_B8G8R8A8_UNORM_SRGB</c> or <c>DXGI_FORMAT_B8G8R8A8_UNORM</c>.</description>
		/// </item>
		/// <item>
		/// <description>
		/// On <b>GetDC</b>, the render target in the output merger of the Direct3D pipeline is unbound from the surface. You must call the
		/// <c>ID3D11DeviceContext::OMSetRenderTargets</c> method on the device prior to Direct3D rendering after GDI rendering.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Prior to resizing buffers you must release all outstanding DCs.</description>
		/// </item>
		/// </list>
		/// <para>
		/// You can also call <b>GetDC</b> on the back buffer at index 0 of a swap chain by obtaining an <c>IDXGISurface1</c> from the swap
		/// chain. The following code illustrates the process.
		/// </para>
		/// <para>
		/// <c>IDXGISwapChain* g_pSwapChain = NULL; IDXGISurface1* g_pSurface1 = NULL; ... //Setup the device and the swapchain
		/// g_pSwapChain-&gt;GetBuffer(0, __uuidof(IDXGISurface1), (void**) &amp;g_pSurface1); g_pSurface1-&gt;GetDC( FALSE, &amp;g_hDC );
		/// ... //Draw on the DC using GDI ... //When finish drawing release the DC g_pSurface1-&gt;ReleaseDC( NULL );</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgisurface1-getdc HRESULT GetDC( BOOL Discard, [out] HDC *phdc );
		[PreserveSig]
		HRESULT GetDC(bool Discard, out HDC phdc);

		/// <summary>
		/// Releases the GDI device context (DC) that is associated with the current surface and allows you to use Direct3D to render.
		/// </summary>
		/// <param name="pDirtyRect">
		/// <para>Type: <b><c>RECT</c>*</b></para>
		/// <para>
		/// A pointer to a <b>RECT</b> structure that identifies the dirty region of the surface. A dirty region is any part of the surface
		/// that you used for GDI rendering and that you want to preserve. This area is used as a performance hint to graphics subsystem in
		/// certain scenarios. Do not use this parameter to restrict rendering to the specified rectangular region. If you pass in
		/// <b>NULL</b>, <b>ReleaseDC</b> considers the whole surface as dirty. Otherwise, <b>ReleaseDC</b> uses the area specified by the
		/// RECT as a performance hint to indicate what areas have been manipulated by GDI rendering.
		/// </para>
		/// <para>
		/// You can pass a pointer to an empty <b>RECT</b> structure (a rectangle with no position or area) if you didn't change any content.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
		/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) ( <c>KB
		/// 971644</c>) and Windows Server 2008 ( <c>KB 971512</c>).
		/// </para>
		/// <para>
		/// Use the <b>ReleaseDC</b> method to release the DC and indicate that your application finished all GDI rendering to this surface.
		/// You must call the <b>ReleaseDC</b> method before you can use Direct3D to perform additional rendering.
		/// </para>
		/// <para>Prior to resizing buffers you must release all outstanding DCs.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgisurface1-releasedc HRESULT ReleaseDC( [in, optional] RECT
		// *pDirtyRect );
		[PreserveSig]
		HRESULT ReleaseDC(HDC pDirtyRect);
	}

	/// <summary>
	/// An <c>IDXGISwapChain</c> interface implements one or more surfaces for storing rendered data before presenting it to an output.
	/// </summary>
	/// <remarks>
	/// You can create a swap chain by calling IDXGIFactory2::CreateSwapChainForHwnd, IDXGIFactory2::CreateSwapChainForCoreWindow, or
	/// IDXGIFactory2::CreateSwapChainForComposition. You can also create a swap chain when you call D3D11CreateDeviceAndSwapChain; however,
	/// you can then only access the sub-set of swap-chain functionality that the <c>IDXGISwapChain</c> interface provides.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgiswapchain
	[PInvokeData("dxgi.h"), ComImport, Guid("310d36a0-d2e7-4c0a-aa04-6a9d23b8886a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGISwapChain : IDXGIDeviceSubObject
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
		new HRESULT GetParent(in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppParent);

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
		HRESULT Present(uint SyncInterval, DXGI_PRESENT Flags);

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
		HRESULT GetBuffer(uint Buffer, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out object? ppSurface);

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
		void SetFullscreenState([MarshalAs(UnmanagedType.Bool)] bool Fullscreen, [In, Optional] IDXGIOutput? pTarget);

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
		IDXGIOutput? GetFullscreenState([MarshalAs(UnmanagedType.Bool)] out bool pFullscreen);

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
		DXGI_SWAP_CHAIN_DESC GetDesc();

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
		void ResizeBuffers(uint BufferCount, uint Width, uint Height, DXGI_FORMAT NewFormat, DXGI_SWAP_CHAIN_FLAG SwapChainFlags);

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
		void ResizeTarget(in DXGI_MODE_DESC pNewTargetParameters);

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
		IDXGIOutput GetContainingOutput();

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
		DXGI_FRAME_STATISTICS GetFrameStatistics();

		/// <summary>Gets the number of times that IDXGISwapChain::Present or IDXGISwapChain1::Present1 has been called.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer to a variable that receives the number of calls.</para>
		/// </returns>
		/// <remarks>For info about presentation statistics for a frame, see DXGI_FRAME_STATISTICS.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiswapchain-getlastpresentcount HRESULT GetLastPresentCount(
		// UINT *pLastPresentCount );
		uint GetLastPresentCount();
	}

	/// <summary>Enumerates the adapters (video cards).</summary>
	/// <returns>A sequence of pointers to <c>IDXGIAdapter</c> interfaces.</returns>
	/// <remarks>
	/// <para>
	/// When you create a factory, the factory enumerates the set of adapters that are available in the system. Therefore, if you change the
	/// adapters in a system, you must destroy and recreate the <c>IDXGIFactory</c> object. The number of adapters in a system changes when
	/// you add or remove a display card, or dock or undock a laptop.
	/// </para>
	/// <para>
	/// When the <b>EnumAdapters</b> method succeeds and fills the <i>ppAdapter</i> parameter with the address of the pointer to the adapter
	/// interface, <b>EnumAdapters</b> increments the adapter interface's reference count. When you finish using the adapter interface, call
	/// the <c>Release</c> method to decrement the reference count before you destroy the pointer.
	/// </para>
	/// <para>
	/// <b>EnumAdapters</b> first returns the adapter with the output on which the desktop primary is displayed. This adapter corresponds
	/// with an index of zero. <b>EnumAdapters</b> next returns other adapters with outputs. <b>EnumAdapters</b> finally returns adapters
	/// without outputs.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgifactory-enumadapters HRESULT EnumAdapters( UINT Adapter, [out]
	// IDXGIAdapter **ppAdapter );
	public static IEnumerable<IDXGIAdapter> EnumAdapters(this IDXGIFactory factory)
	{
		for (uint i = 0; factory.EnumAdapters(i, out var pAdapter).Succeeded; i++)
			yield return pAdapter!;
	}

	/// <summary>Enumerates both adapters (video cards) with or without outputs.</summary>
	/// <param name="factory">The factory.</param>
	/// <returns>A sequence of pointers to <c>IDXGIAdapter1</c> interfaces.</returns>
	/// <remarks>
	/// <para>
	/// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
	/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) ( <c>KB
	/// 971644</c>) and Windows Server 2008 ( <c>KB 971512</c>).
	/// </para>
	/// <para>
	/// When you create a factory, the factory enumerates the set of adapters that are available in the system. Therefore, if you change the
	/// adapters in a system, you must destroy and recreate the <c>IDXGIFactory1</c> object. The number of adapters in a system changes when
	/// you add or remove a display card, or dock or undock a laptop.
	/// </para>
	/// <para>
	/// When the <b>EnumAdapters1</b> method succeeds and fills the <i>ppAdapter</i> parameter with the address of the pointer to the
	/// adapter interface, <b>EnumAdapters1</b> increments the adapter interface's reference count. When you finish using the adapter
	/// interface, call the <c>Release</c> method to decrement the reference count before you destroy the pointer.
	/// </para>
	/// <para>
	/// <b>EnumAdapters1</b> first returns the adapter with the output on which the desktop primary is displayed. This adapter corresponds
	/// with an index of zero. <b>EnumAdapters1</b> next returns other adapters with outputs. <b>EnumAdapters1</b> finally returns adapters
	/// without outputs.
	/// </para>
	/// </remarks>
	public static IEnumerable<IDXGIAdapter1> EnumAdapters1(this IDXGIFactory1 factory)
	{
		for (uint i = 0; factory.EnumAdapters1(i, out var pAdapter).Succeeded; i++)
			yield return pAdapter!;
	}

	/// <summary>Accesses one of the swap-chain's back buffers.</summary>
	/// <typeparam name="T">The type of interface used to manipulate the buffer.</typeparam>
	/// <param name="swapChain">The <see cref="IDXGISwapChain"/> instance.</param>
	/// <param name="Buffer">
	/// <para>Type: <b><c>UINT</c></b></para>
	/// <para>A zero-based buffer index.</para>
	/// <para>
	/// If the swap chain's swap effect is <c>DXGI_SWAP_EFFECT_DISCARD</c>, this method can only access the first buffer; for this
	/// situation, set the index to zero.
	/// </para>
	/// <para>
	/// If the swap chain's swap effect is either <c>DXGI_SWAP_EFFECT_SEQUENTIAL</c> or <c>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</c>, only the
	/// swap chain's zero-index buffer can be read from and written to. The swap chain's buffers with indexes greater than zero can only be
	/// read from; so if you call the <c>IDXGIResource::GetUsage</c> method for such buffers, they have the <c>DXGI_USAGE_READ_ONLY</c> flag set.
	/// </para>
	/// </param>
	/// <returns>A pointer to a back-buffer interface.</returns>
	public static T GetBuffer<T>(this IDXGISwapChain swapChain, uint Buffer)
	{
		swapChain.GetBuffer(Buffer, typeof(T).GUID, out var p).ThrowIfFailed();
		return (T)p!;
	}

	/// <summary>Gets the parent of the object.</summary>
	/// <typeparam name="T">The type of the requested interface.</typeparam>
	/// <param name="pObj">The <see cref="IDXGIObject"/> instance.</param>
	/// <returns>The pointer to the parent object.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiobject-getparent HRESULT GetParent( REFIID riid, void
	// **ppParent );
	public static T? GetParent<T>(this IDXGIObject pObj) where T : class
	{
		var hr = pObj.GetParent(typeof(T).GUID, out var ppv);
		return hr.Failed ? null : (T)ppv!;
	}

	/// <summary>Gets application-defined data from a device object.</summary>
	/// <typeparam name="T">The data type.</typeparam>
	/// <param name="pObj">The <see cref="IDXGIObject"/> instance.</param>
	/// <param name="guid">The <b>GUID</b> that is associated with the data.</param>
	/// <returns>The data from the device object.</returns>
	/// <remarks>
	/// If the data returned is a pointer to an <c>IUnknown</c>, or one of its derivative classes, which was previously set by
	/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
	/// </remarks>
	public static T? GetPrivateData<T>(this IDXGIObject pObj, in Guid guid)
	{
		uint sz = 0;
		HRESULT hr = pObj.GetPrivateData(guid, ref sz, IntPtr.Zero);
		if (hr.Succeeded)
			return default;
		using SafeCoTaskMemHandle mem = new(sz);
		IntPtr p = mem.DangerousGetHandle();
		pObj.GetPrivateData(guid, ref sz, p).ThrowIfFailed();
		return p.Convert<T>(sz);
	}

	/// <summary>Sets application-defined data to a device object and associates that data with an application-defined <b>GUID</b>.</summary>
	/// <typeparam name="T">The data type.</typeparam>
	/// <param name="pObj">The <see cref="IDXGIObject"/> instance.</param>
	/// <param name="guid">The <b>GUID</b> to associate with the data.</param>
	/// <param name="pData">
	/// A pointer to a memory block that contains the data to be stored with this device object. If <i>pData</i> is <b>NULL</b>, any data
	/// that was previously associated with the <b>GUID</b> specified in <i>guid</i> will be destroyed.
	/// </param>
	public static void SetPrivateData<T>(this IDXGIObject pObj, in Guid guid, T? pData) where T : struct
	{
		using var mem = pData is null ? SafeHGlobalHandle.Null : SafeHGlobalHandle.CreateFromStructure(pData);
		pObj.SetPrivateData(guid, (uint)mem.Size, mem);
	}
}