namespace Vanara.PInvoke;

public static partial class DXGI
{
	/// <summary>Identifies the alpha value, transparency behavior, of a surface.</summary>
	/// <remarks>For more information about alpha mode, see D2D1_ALPHA_MODE.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ne-dxgi1_2-dxgi_alpha_mode typedef enum DXGI_ALPHA_MODE {
	// DXGI_ALPHA_MODE_UNSPECIFIED = 0, DXGI_ALPHA_MODE_PREMULTIPLIED = 1, DXGI_ALPHA_MODE_STRAIGHT = 2, DXGI_ALPHA_MODE_IGNORE = 3,
	// DXGI_ALPHA_MODE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NE:dxgi1_2.DXGI_ALPHA_MODE")]
	public enum DXGI_ALPHA_MODE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Indicates that the transparency behavior is not specified.</para>
		/// </summary>
		DXGI_ALPHA_MODE_UNSPECIFIED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Indicates that the transparency behavior is premultiplied. Each color is first scaled by the alpha value. The alpha value itself
		/// is the same in both straight and premultiplied alpha. Typically, no color channel value is greater than the alpha channel value.
		/// If a color channel value in a premultiplied format is greater than the alpha channel, the standard source-over blending math
		/// results in an additive blend.
		/// </para>
		/// </summary>
		DXGI_ALPHA_MODE_PREMULTIPLIED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Indicates that the transparency behavior is not premultiplied. The alpha channel indicates the transparency of the color.</para>
		/// </summary>
		DXGI_ALPHA_MODE_STRAIGHT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Indicates to ignore the transparency behavior.</para>
		/// </summary>
		DXGI_ALPHA_MODE_IGNORE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xffffffff</para>
		/// <para>
		/// Forces this enumeration to compile to 32 bits in size. Without this value, some compilers would allow this enumeration to compile
		/// </para>
		/// <para>to a size other than 32 bits. This value is not used.</para>
		/// </summary>
		DXGI_ALPHA_MODE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>
	/// Identifies the granularity at which the graphics processing unit (GPU) can be preempted from performing its current compute task.
	/// </summary>
	/// <remarks>
	/// You call the IDXGIAdapter2::GetDesc2 method to retrieve the granularity level at which the GPU can be preempted from performing its
	/// current compute task. The operating system specifies the compute granularity level in the <c>ComputePreemptionGranularity</c> member
	/// of the DXGI_ADAPTER_DESC2 structure.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ne-dxgi1_2-dxgi_compute_preemption_granularity typedef enum
	// DXGI_COMPUTE_PREEMPTION_GRANULARITY { DXGI_COMPUTE_PREEMPTION_DMA_BUFFER_BOUNDARY = 0, DXGI_COMPUTE_PREEMPTION_DISPATCH_BOUNDARY = 1,
	// DXGI_COMPUTE_PREEMPTION_THREAD_GROUP_BOUNDARY = 2, DXGI_COMPUTE_PREEMPTION_THREAD_BOUNDARY = 3,
	// DXGI_COMPUTE_PREEMPTION_INSTRUCTION_BOUNDARY = 4 } ;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NE:dxgi1_2.DXGI_COMPUTE_PREEMPTION_GRANULARITY")]
	public enum DXGI_COMPUTE_PREEMPTION_GRANULARITY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Indicates the preemption granularity as a compute packet.</para>
		/// </summary>
		DXGI_COMPUTE_PREEMPTION_DMA_BUFFER_BOUNDARY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Indicates the preemption granularity as a dispatch (for example, a call to the</para>
		/// <para>ID3D11DeviceContext::Dispatch</para>
		/// <para>method). A dispatch is a part of a compute packet.</para>
		/// </summary>
		DXGI_COMPUTE_PREEMPTION_DISPATCH_BOUNDARY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Indicates the preemption granularity as a thread group. A thread group is a part of a dispatch.</para>
		/// </summary>
		DXGI_COMPUTE_PREEMPTION_THREAD_GROUP_BOUNDARY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Indicates the preemption granularity as a thread in a thread group. A thread is a part of a thread group.</para>
		/// </summary>
		DXGI_COMPUTE_PREEMPTION_THREAD_BOUNDARY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Indicates the preemption granularity as a compute instruction in a thread.</para>
		/// </summary>
		DXGI_COMPUTE_PREEMPTION_INSTRUCTION_BOUNDARY,
	}

	/// <summary>
	/// Identifies the granularity at which the graphics processing unit (GPU) can be preempted from performing its current graphics
	/// rendering task.
	/// </summary>
	/// <remarks>
	/// <para>
	/// You call the IDXGIAdapter2::GetDesc2 method to retrieve the granularity level at which the GPU can be preempted from performing its
	/// current graphics rendering task. The operating system specifies the graphics granularity level in the
	/// <c>GraphicsPreemptionGranularity</c> member of the DXGI_ADAPTER_DESC2 structure.
	/// </para>
	/// <para>The following figure shows granularity of graphics rendering tasks.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ne-dxgi1_2-dxgi_graphics_preemption_granularity typedef enum
	// DXGI_GRAPHICS_PREEMPTION_GRANULARITY { DXGI_GRAPHICS_PREEMPTION_DMA_BUFFER_BOUNDARY = 0, DXGI_GRAPHICS_PREEMPTION_PRIMITIVE_BOUNDARY
	// = 1, DXGI_GRAPHICS_PREEMPTION_TRIANGLE_BOUNDARY = 2, DXGI_GRAPHICS_PREEMPTION_PIXEL_BOUNDARY = 3,
	// DXGI_GRAPHICS_PREEMPTION_INSTRUCTION_BOUNDARY = 4 } ;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NE:dxgi1_2.DXGI_GRAPHICS_PREEMPTION_GRANULARITY")]
	public enum DXGI_GRAPHICS_PREEMPTION_GRANULARITY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Indicates the preemption granularity as a DMA buffer.</para>
		/// </summary>
		DXGI_GRAPHICS_PREEMPTION_DMA_BUFFER_BOUNDARY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Indicates the preemption granularity as a graphics primitive. A primitive is a section in a DMA buffer and can be a group of triangles.
		/// </para>
		/// </summary>
		DXGI_GRAPHICS_PREEMPTION_PRIMITIVE_BOUNDARY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Indicates the preemption granularity as a triangle. A triangle is a part of a primitive.</para>
		/// </summary>
		DXGI_GRAPHICS_PREEMPTION_TRIANGLE_BOUNDARY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Indicates the preemption granularity as a pixel. A pixel is a part of a triangle.</para>
		/// </summary>
		DXGI_GRAPHICS_PREEMPTION_PIXEL_BOUNDARY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Indicates the preemption granularity as a graphics instruction. A graphics instruction operates on a pixel.</para>
		/// </summary>
		DXGI_GRAPHICS_PREEMPTION_INSTRUCTION_BOUNDARY,
	}

	/// <summary>
	/// Identifies the importance of a resource’s content when you call the IDXGIDevice2::OfferResources method to offer the resource.
	/// </summary>
	/// <remarks>
	/// Priority determines how likely the operating system is to discard an offered resource. Resources offered with lower priority are
	/// discarded first.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ne-dxgi1_2-dxgi_offer_resource_priority typedef enum
	// DXGI_OFFER_RESOURCE_PRIORITY { DXGI_OFFER_RESOURCE_PRIORITY_LOW = 1, DXGI_OFFER_RESOURCE_PRIORITY_NORMAL,
	// DXGI_OFFER_RESOURCE_PRIORITY_HIGH } DXGI_OFFER_RESOURCE_PRIORITY;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NE:dxgi1_2.DXGI_OFFER_RESOURCE_PRIORITY")]
	public enum DXGI_OFFER_RESOURCE_PRIORITY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// The resource is low priority. The operating system discards a low priority resource before other offered resources with higher
		/// priority. It is a good programming practice to mark a resource as low priority if it has no useful content.
		/// </para>
		/// </summary>
		DXGI_OFFER_RESOURCE_PRIORITY_LOW = 1,

		/// <summary>The resource is normal priority. You mark a resource as normal priority if it has content that is easy to regenerate.</summary>
		DXGI_OFFER_RESOURCE_PRIORITY_NORMAL,

		/// <summary>
		/// The resource is high priority. The operating system discards other offered resources with lower priority before it discards a
		/// high priority resource. You mark a resource as high priority if it has useful content that is difficult to regenerate.
		/// </summary>
		DXGI_OFFER_RESOURCE_PRIORITY_HIGH,
	}

	/// <summary>Identifies the type of pointer shape.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ne-dxgi1_2-dxgi_outdupl_pointer_shape_type typedef enum
	// DXGI_OUTDUPL_POINTER_SHAPE_TYPE { DXGI_OUTDUPL_POINTER_SHAPE_TYPE_MONOCHROME = 0x1, DXGI_OUTDUPL_POINTER_SHAPE_TYPE_COLOR = 0x2,
	// DXGI_OUTDUPL_POINTER_SHAPE_TYPE_MASKED_COLOR = 0x4 } ;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NE:dxgi1_2.DXGI_OUTDUPL_POINTER_SHAPE_TYPE"), Flags]
	public enum DXGI_OUTDUPL_POINTER_SHAPE_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>
		/// The pointer type is a monochrome mouse pointer, which is a monochrome bitmap. The bitmap's size is specified by width and height
		/// in a 1 bits per pixel (bpp) device independent bitmap (DIB) format AND mask that is followed by another 1 bpp DIB format XOR
		/// mask of the same size.
		/// </para>
		/// </summary>
		DXGI_OUTDUPL_POINTER_SHAPE_TYPE_MONOCHROME = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>
		/// The pointer type is a color mouse pointer, which is a color bitmap. The bitmap's size is specified by width and height in a 32
		/// bpp ARGB DIB format.
		/// </para>
		/// </summary>
		DXGI_OUTDUPL_POINTER_SHAPE_TYPE_COLOR = 2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>
		/// The pointer type is a masked color mouse pointer. A masked color mouse pointer is a 32 bpp ARGB format bitmap with the mask
		/// value in the alpha bits. The only allowed mask values are 0 and 0xFF. When the mask value is 0, the RGB value should replace the
		/// screen pixel. When the mask value is 0xFF, an XOR operation is performed on the RGB value and the screen pixel; the result
		/// replaces the screen pixel.
		/// </para>
		/// </summary>
		DXGI_OUTDUPL_POINTER_SHAPE_TYPE_MASKED_COLOR = 4,
	}

	/// <summary>Identifies resize behavior when the back-buffer size does not match the size of the target output.</summary>
	/// <remarks>
	/// <para>
	/// The DXGI_SCALING_NONE value is supported only for flip presentation model swap chains that you create with the
	/// DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL or DXGI_SWAP_EFFECT_FLIP_DISCARD value. You pass these values in a call to
	/// IDXGIFactory2::CreateSwapChainForHwnd, IDXGIFactory2::CreateSwapChainForCoreWindow, or IDXGIFactory2::CreateSwapChainForComposition.
	/// </para>
	/// <para>
	/// DXGI_SCALING_ASPECT_RATIO_STRETCH will prefer to use a horizontal fill, otherwise it will use a vertical fill, using the following logic.
	/// </para>
	/// <para>
	/// Note that <c>outputWidth</c> and <c>outputHeight</c> are the pixel sizes of the presentation target size. In the case of
	/// <c>CoreWindow</c>, this requires converting the <c>logicalWidth</c> and <c>logicalHeight</c> values from DIPS to pixels using the
	/// window's DPI property.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ne-dxgi1_2-dxgi_scaling typedef enum DXGI_SCALING { DXGI_SCALING_STRETCH
	// = 0, DXGI_SCALING_NONE = 1, DXGI_SCALING_ASPECT_RATIO_STRETCH = 2 } ;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NE:dxgi1_2.DXGI_SCALING")]
	public enum DXGI_SCALING
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// Directs DXGI to make the back-buffer contents scale to fit the presentation target size. This is the implicit behavior of DXGI
		/// when you call the
		/// </para>
		/// <para>IDXGIFactory::CreateSwapChain</para>
		/// <para>method.</para>
		/// </summary>
		DXGI_SCALING_STRETCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Directs DXGI to make the back-buffer contents appear without any scaling when the presentation target size is not equal to the
		/// back-buffer size. The top edges of the back buffer and presentation target are aligned together. If the WS_EX_LAYOUTRTL style is
		/// associated with the
		/// </para>
		/// <para>HWND</para>
		/// <para>
		/// handle to the target output window, the right edges of the back buffer and presentation target are aligned together; otherwise,
		/// the left edges are aligned together. All target area outside the back buffer is filled with window background color.
		/// </para>
		/// <para>
		/// This value specifies that all target areas outside the back buffer of a swap chain are filled with the background color that you
		/// specify in a call to
		/// </para>
		/// <para>IDXGISwapChain1::SetBackgroundColor</para>
		/// <para>.</para>
		/// </summary>
		DXGI_SCALING_NONE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// Directs DXGI to make the back-buffer contents scale to fit the presentation target size, while preserving the aspect ratio of
		/// the back-buffer. If the scaled back-buffer does not fill the presentation area, it will be centered with black borders.
		/// </para>
		/// <para>This constant is supported on Windows Phone 8 and Windows 10.</para>
		/// <para>Note that with legacy Win32 window swapchains, this works the same as DXGI_SCALING_STRETCH.</para>
		/// </summary>
		DXGI_SCALING_ASPECT_RATIO_STRETCH,
	}

	/// <summary>
	/// The <b>IDXGIAdapter2</b> interface represents a display subsystem, which includes one or more GPUs, DACs, and video memory.
	/// </summary>
	/// <remarks>
	/// <para>
	/// A display subsystem is often referred to as a video card; however, on some computers, the display subsystem is part of the motherboard.
	/// </para>
	/// <para>To enumerate the display subsystems, use <c>IDXGIFactory1::EnumAdapters1</c>.</para>
	/// <para>To get an interface to the adapter for a particular device, use <c>IDXGIDevice::GetAdapter</c>.</para>
	/// <para>To create a software adapter, use <c>IDXGIFactory::CreateSoftwareAdapter</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgiadapter2
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NN:dxgi1_2.IDXGIAdapter2")]
	[ComImport, Guid("0aa1ae0a-fa0e-4b84-8644-e05ff8e5acb5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIAdapter2 : IDXGIAdapter1
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
		DXGI_ADAPTER_DESC2 GetDesc2();
	}

	/// <summary>
	/// The <b>IDXGIDevice2</b> interface implements a derived class for DXGI objects that produce image data. The interface exposes methods
	/// to block CPU processing until the GPU completes processing, and to offer resources to the operating system.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <b>IDXGIDevice2</b> interface is designed for use by DXGI objects that need access to other DXGI objects. This interface is
	/// useful to applications that do not use Direct3D to communicate with DXGI.
	/// </para>
	/// <para>
	/// The Direct3D create device functions return a Direct3D device object. This Direct3D device object implements the <c>IUnknown</c>
	/// interface. You can query this Direct3D device object for the device's corresponding <b>IDXGIDevice2</b> interface. To retrieve the
	/// <b>IDXGIDevice2</b> interface of a Direct3D device, use the following code:
	/// </para>
	/// <para><c>IDXGIDevice2 * pDXGIDevice; hr = g_pd3dDevice-&gt;QueryInterface(__uuidof(IDXGIDevice2), (void **)&amp;pDXGIDevice);</c></para>
	/// <para><b>Windows Phone 8:</b> This API is supported.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgidevice2
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NN:dxgi1_2.IDXGIDevice2")]
	[ComImport, Guid("05008617-fbfd-4051-a790-144884b4f6a9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIDevice2 : IDXGIDevice1
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
		new HRESULT SetMaximumFrameLatency(uint MaxLatency);

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
		new HRESULT GetMaximumFrameLatency(out uint pMaxLatency);

		/// <summary>Allows the operating system to free the video memory of resources by discarding their content.</summary>
		/// <param name="NumResources">The number of resources in the <i>ppResources</i> argument array.</param>
		/// <param name="ppResources">An array of pointers to <c>IDXGIResource</c> interfaces for the resources to offer.</param>
		/// <param name="Priority">A <c>DXGI_OFFER_RESOURCE_PRIORITY</c>-typed value that indicates how valuable data is.</param>
		/// <returns>
		/// <para><b>OfferResources</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if resources were successfully offered</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG if a resource in the array or the priority is invalid</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The priority value that the <i>Priority</i> parameter specifies describes how valuable the caller considers the content to be.
		/// The operating system uses the priority value to discard resources in order of priority. The operating system discards a resource
		/// that is offered with low priority before it discards a resource that is offered with a higher priority.
		/// </para>
		/// <para>
		/// If you call <b>OfferResources</b> to offer a resource while the resource is bound to the pipeline, the resource is unbound. You
		/// cannot call <b>OfferResources</b> on a resource that is mapped. After you offer a resource, the resource cannot be mapped or
		/// bound to the pipeline until you call the <c>IDXGIDevice2::ReclaimResource</c> method to reclaim the resource. You cannot call
		/// <b>OfferResources</b> to offer immutable resources.
		/// </para>
		/// <para>
		/// To offer shared resources, call <b>OfferResources</b> on only one of the sharing devices. To ensure exclusive access to the
		/// resources, you must use an <c>IDXGIKeyedMutex</c> object and then call <b>OfferResources</b> only while you hold the mutex. In
		/// fact, you can't offer shared resources unless you use <b>IDXGIKeyedMutex</b> because offering shared resources without using
		/// <b>IDXGIKeyedMutex</b> isn't supported.
		/// </para>
		/// <para>
		/// <b>Note</b>  The user mode display driver might not immediately offer the resources that you specified in a call to
		/// <b>OfferResources</b>. The driver can postpone offering them until the next call to <c>IDXGISwapChain::Present</c>,
		/// <c>IDXGISwapChain1::Present1</c>, or <c>ID3D11DeviceContext::Flush</c>.
		/// </para>
		/// <para></para>
		/// <para>
		/// <b>Platform Update for Windows 7:  </b> The runtime validates that <b>OfferResources</b> is used correctly on non-shared
		/// resources but doesn't perform the intended functionality. For more info about the Platform Update for Windows 7, see <c>Platform
		/// Update for Windows 7</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgidevice2-offerresources HRESULT OfferResources( [in]
		// UINT NumResources, [in] IDXGIResource * const *ppResources, [in] DXGI_OFFER_RESOURCE_PRIORITY Priority );
		[PreserveSig]
		HRESULT OfferResources(int NumResources, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IDXGIResource[] ppResources,
			DXGI_OFFER_RESOURCE_PRIORITY Priority);

		/// <summary>Restores access to resources that were previously offered by calling <c>IDXGIDevice2::OfferResources</c>.</summary>
		/// <param name="NumResources">The number of resources in the <i>ppResources</i> argument and <i>pDiscarded</i> argument arrays.</param>
		/// <param name="ppResources">An array of pointers to <c>IDXGIResource</c> interfaces for the resources to reclaim.</param>
		/// <param name="pDiscarded">
		/// A pointer to an array that receives Boolean values. Each value in the array corresponds to a resource at the same index that the
		/// <i>ppResources</i> parameter specifies. The runtime sets each Boolean value to TRUE if the corresponding resource’s content was
		/// discarded and is now undefined, or to FALSE if the corresponding resource’s old content is still intact. The caller can pass in
		/// <b>NULL</b>, if the caller intends to fill the resources with new content regardless of whether the old content was discarded.
		/// </param>
		/// <returns>
		/// <para><b>ReclaimResources</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if resources were successfully reclaimed</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG if the resources are invalid</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// After you call <c>IDXGIDevice2::OfferResources</c> to offer one or more resources, you must call <b>ReclaimResources</b> before
		/// you can use those resources again. You must check the values in the array at <i>pDiscarded</i> to determine whether each
		/// resource’s content was discarded. If a resource’s content was discarded while it was offered, its current content is undefined.
		/// Therefore, you must overwrite the resource’s content before you use the resource.
		/// </para>
		/// <para>
		/// To reclaim shared resources, call <b>ReclaimResources</b> only on one of the sharing devices. To ensure exclusive access to the
		/// resources, you must use an <c>IDXGIKeyedMutex</c> object and then call <b>ReclaimResources</b> only while you hold the mutex.
		/// </para>
		/// <para>
		/// <b>Platform Update for Windows 7:  </b> The runtime validates that <b>ReclaimResources</b> is used correctly on non-shared
		/// resources but doesn't perform the intended functionality. For more info about the Platform Update for Windows 7, see <c>Platform
		/// Update for Windows 7</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgidevice2-reclaimresources HRESULT ReclaimResources(
		// [in] UINT NumResources, [in] IDXGIResource * const *ppResources, [out, optional] BOOL *pDiscarded );
		[PreserveSig]
		HRESULT ReclaimResources(int NumResources, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IDXGIResource[] ppResources,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] bool[] pDiscarded);

		/// <summary>
		/// Flushes any outstanding rendering commands and sets the specified event object to the signaled state after all previously
		/// submitted rendering commands complete.
		/// </summary>
		/// <param name="hEvent">
		/// <para>
		/// A handle to the event object. The <c>CreateEvent</c> or <c>OpenEvent</c> function returns this handle. All types of event
		/// objects (manual-reset, auto-reset, and so on) are supported.
		/// </para>
		/// <para>
		/// The handle must have the EVENT_MODIFY_STATE access right. For more information about access rights, see <c>Synchronization
		/// Object Security and Access Rights</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if insufficient memory is available to complete the operation.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if the parameter was validated and determined to be incorrect.</description>
		/// </item>
		/// </list>
		/// <para>
		/// <b>Platform Update for Windows 7:  </b> On Windows 7 or Windows Server 2008 R2 with the <c>Platform Update for Windows 7</c>
		/// installed, <b>EnqueueSetEvent</b> fails with E_NOTIMPL. For more info about the Platform Update for Windows 7, see <c>Platform
		/// Update for Windows 7</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>EnqueueSetEvent</b> calls the <c>SetEvent</c> function on the event object after all previously submitted rendering commands
		/// complete or the device is removed.
		/// </para>
		/// <para>
		/// After an application calls <b>EnqueueSetEvent</b>, it can immediately call the <c>WaitForSingleObject</c> function to put itself
		/// to sleep until rendering commands complete.
		/// </para>
		/// <para>
		/// You cannot use <b>EnqueueSetEvent</b> to determine work completion that is associated with presentation (
		/// <c>IDXGISwapChain::Present</c>); instead, we recommend that you use <c>IDXGISwapChain::GetFrameStatistics</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example code shows how to use <b>EnqueueSetEvent</b>.</para>
		/// <para>
		/// <c>void BlockingFinish( IDXGIDevice2* pDevice ) { // Create a manual-reset event object. hEvent = CreateEvent( NULL, // default
		/// security attributes TRUE, // manual-reset event FALSE, // initial state is nonsignaled FALSE ); if (hEvent == NULL) {
		/// printf("CreateEvent failed (%d)\n", GetLastError()); return; } pDevice-&gt;EnqueueSetEvent(hEvent); DWORD dwWaitResult =
		/// WaitForSingleObject( hEvent, // event handle INFINITE); // indefinite wait switch (dwWaitResult) { // Event object was signaled
		/// case WAIT_OBJECT_0: // Commands completed break; // An error occurred default: printf("Wait error (%d)\n", GetLastError());
		/// return 0; } CloseHandle(hEvent); }</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgidevice2-enqueuesetevent HRESULT EnqueueSetEvent( [in]
		// HANDLE hEvent );
		[PreserveSig]
		HRESULT EnqueueSetEvent(HEVENT hEvent);
	}

	/// <summary>
	/// <para>
	/// The <b>IDXGIDisplayControl</b> interface exposes methods to indicate user preference for the operating system's stereoscopic 3D
	/// display behavior and to set stereoscopic 3D display status to enable or disable.
	/// </para>
	/// <para>
	/// We recommend that you not use <b>IDXGIDisplayControl</b> to query or set system-wide stereoscopic 3D settings in your stereoscopic
	/// 3D apps. Instead, for your windowed apps, call the <c>IDXGIFactory2::IsWindowedStereoEnabled</c> method to determine whether to
	/// render in stereo; for your full-screen apps, call the <c>IDXGIOutput1::GetDisplayModeList1</c> method and then determine whether any
	/// of the returned display modes support rendering in stereo.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  The <b>IDXGIDisplayControl</b> interface is only used by the <b>Display</b> app of the operating system's Control Panel
	/// or by control applets from third party graphics vendors. This interface is not meant for developers of end-user apps.
	/// </para>
	/// <para></para>
	/// <para><b>Note</b>  The <b>IDXGIDisplayControl</b> interface does not exist for Windows Store apps.</para>
	/// <para></para>
	/// <para>
	/// Call <c>QueryInterface</c> from a factory object ( <c>IDXGIFactory</c>, <c>IDXGIFactory1</c> or <c>IDXGIFactory2</c>) to retrieve
	/// the <b>IDXGIDisplayControl</b> interface. The following code shows how.
	/// </para>
	/// <para>
	/// <c>IDXGIDisplayControl * pDXGIDisplayControl; hr = g_pDXGIFactory-&gt;QueryInterface(__uuidof(IDXGIDisplayControl), (void **)&amp;pDXGIDisplayControl);</c>
	/// </para>
	/// <para>
	/// The operating system processes changes to stereo-enabled configuration asynchronously. Therefore, these changes might not be
	/// immediately visible in every process that calls <c>IDXGIDisplayControl::IsStereoEnabled</c> to query for stereo configuration.
	/// Control applets can use the <c>IDXGIFactory2::RegisterStereoStatusEvent</c> or <c>IDXGIFactory2::RegisterStereoStatusWindow</c>
	/// method to register for notifications of all stereo configuration changes.
	/// </para>
	/// <para>
	/// <b>Platform Update for Windows 7:  </b> Stereoscopic 3D display behavior isn’t available with the Platform Update for Windows 7. For
	/// more info about the Platform Update for Windows 7, see <c>Platform Update for Windows 7</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgidisplaycontrol
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NN:dxgi1_2.IDXGIDisplayControl")]
	[ComImport, Guid("ea9dbf1a-c88e-4486-854a-98aa0138f30c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIDisplayControl
	{
		/// <summary>Retrieves a Boolean value that indicates whether the operating system's stereoscopic 3D display behavior is enabled.</summary>
		/// <returns>
		/// <para>
		/// <b>IsStereoEnabled</b> returns TRUE when the operating system's stereoscopic 3D display behavior is enabled and FALSE when this
		/// behavior is disabled.
		/// </para>
		/// <para>
		/// <b>Platform Update for Windows 7:  </b> On Windows 7 or Windows Server 2008 R2 with the <c>Platform Update for Windows 7</c>
		/// installed, <b>IsStereoEnabled</b> always returns FALSE because stereoscopic 3D display behavior isn’t available with the
		/// Platform Update for Windows 7. For more info about the Platform Update for Windows 7, see <c>Platform Update for Windows 7</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// You pass a Boolean value to the <c>IDXGIDisplayControl::SetStereoEnabled</c> method to either enable or disable the operating
		/// system's stereoscopic 3D display behavior. TRUE enables the operating system's stereoscopic 3D display behavior and FALSE
		/// disables it.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgidisplaycontrol-isstereoenabled BOOL IsStereoEnabled();
		[PreserveSig]
		bool IsStereoEnabled();

		/// <summary>Set a Boolean value to either enable or disable the operating system's stereoscopic 3D display behavior.</summary>
		/// <param name="enabled">
		/// A Boolean value that either enables or disables the operating system's stereoscopic 3D display behavior. TRUE enables the
		/// operating system's stereoscopic 3D display behavior and FALSE disables it.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <b>Platform Update for Windows 7:  </b> On Windows 7 or Windows Server 2008 R2 with the <c>Platform Update for Windows 7</c>
		/// installed, <b>SetStereoEnabled</b> doesn't change stereoscopic 3D display behavior because stereoscopic 3D display behavior
		/// isn’t available with the Platform Update for Windows 7. For more info about the Platform Update for Windows 7, see <c>Platform
		/// Update for Windows 7</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgidisplaycontrol-setstereoenabled void
		// SetStereoEnabled( BOOL enabled );
		[PreserveSig]
		void SetStereoEnabled(bool enabled);
	}

	/// <summary>
	/// The <b>IDXGIFactory2</b> interface includes methods to create a newer version swap chain with more features than
	/// <c>IDXGISwapChain</c> and to monitor stereoscopic 3D capabilities.
	/// </summary>
	/// <remarks>
	/// <para>
	/// To create a Microsoft DirectX Graphics Infrastructure (DXGI) 1.2 factory interface, pass <b>IDXGIFactory2</b> into either the
	/// <c>CreateDXGIFactory</c> or <c>CreateDXGIFactory1</c> function or call <c>QueryInterface</c> from a factory object that either
	/// <b>CreateDXGIFactory</b> or <b>CreateDXGIFactory1</b> returns.
	/// </para>
	/// <para>
	/// Because you can create a Direct3D device without creating a swap chain, you might need to retrieve the factory that is used to
	/// create the device in order to create a swap chain. You can request the <c>IDXGIDevice</c>, <c>IDXGIDevice1</c>, or
	/// <c>IDXGIDevice2</c> interface from the Direct3D device and then use the <c>IDXGIObject::GetParent</c> method to locate the factory.
	/// The following code shows how.
	/// </para>
	/// <para>
	/// <c>IDXGIDevice2 * pDXGIDevice; hr = g_pd3dDevice-&gt;QueryInterface(__uuidof(IDXGIDevice2), (void **)&amp;pDXGIDevice); IDXGIAdapter
	/// * pDXGIAdapter; hr = pDXGIDevice-&gt;GetParent(__uuidof(IDXGIAdapter), (void **)&amp;pDXGIAdapter); IDXGIFactory2 * pIDXGIFactory;
	/// pDXGIAdapter-&gt;GetParent(__uuidof(IDXGIFactory2), (void **)&amp;pIDXGIFactory);</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgifactory2
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NN:dxgi1_2.IDXGIFactory2")]
	[ComImport, Guid("50c83a1c-e072-4c48-87b0-3630fa36a6d0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIFactory2 : IDXGIFactory1
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
		bool IsWindowedStereoEnabled();

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
		IDXGISwapChain1 CreateSwapChainForHwnd([In, MarshalAs(UnmanagedType.IUnknown)] object pDevice, HWND hWnd, in DXGI_SWAP_CHAIN_DESC1 pDesc,
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
		IDXGISwapChain1 CreateSwapChainForCoreWindow([In, MarshalAs(UnmanagedType.IUnknown)] object pDevice, [In, MarshalAs(UnmanagedType.IUnknown)] object pWindow,
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
		LUID GetSharedResourceAdapterLuid([In] HANDLE hResource);

		/// <summary>Registers an application window to receive notification messages of changes of stereo status.</summary>
		/// <param name="WindowHandle">The handle of the window to send a notification message to when stereo status change occurs.</param>
		/// <param name="wMsg">Identifies the notification message to send.</param>
		/// <returns>
		/// A pointer to a key value that an application can pass to the <c>IDXGIFactory2::UnregisterStereoStatus</c> method to unregister
		/// the notification message that <i>wMsg</i> specifies.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgifactory2-registerstereostatuswindow HRESULT
		// RegisterStereoStatusWindow( [in] HWND WindowHandle, [in] UINT wMsg, [out] DWORD *pdwCookie );
		uint RegisterStereoStatusWindow(HWND WindowHandle, uint wMsg);

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
		uint RegisterStereoStatusEvent(HEVENT hEvent);

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
		void UnregisterStereoStatus(uint dwCookie);

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
		uint RegisterOcclusionStatusWindow([In] HWND WindowHandle, uint wMsg);

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
		uint RegisterOcclusionStatusEvent([In] HEVENT hEvent);

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
		void UnregisterOcclusionStatus(uint dwCookie);

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
		IDXGISwapChain1 CreateSwapChainForComposition([MarshalAs(UnmanagedType.IUnknown)] object pDevice, in DXGI_SWAP_CHAIN_DESC1 pDesc,
			[In, Optional] IDXGIOutput? pRestrictToOutput);
	}

	/// <summary>An <b>IDXGIOutput1</b> interface represents an adapter output (such as a monitor).</summary>
	/// <remarks>
	/// To determine the outputs that are available from the adapter, use <c>IDXGIAdapter::EnumOutputs</c>. To determine the specific output
	/// that the swap chain will update, use <c>IDXGISwapChain::GetContainingOutput</c>. You can then call <c>QueryInterface</c> from any
	/// <c>IDXGIOutput</c> object to obtain an <b>IDXGIOutput1</b> object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgioutput1
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NN:dxgi1_2.IDXGIOutput1")]
	[ComImport, Guid("00cddea8-939b-4b83-a340-a685226666cc"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIOutput1 : IDXGIOutput
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
		/// <b>GetDisplayModeList1</b> to poll the set of display modes that are validated against monitor capabilities, or all modes that
		/// match the desktop (if the desktop settings are not validated against the monitor).
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
		HRESULT GetDisplayModeList1(DXGI_FORMAT EnumFormat, DXGI_ENUM_MODES Flags, ref int pNumModes,
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
		void FindClosestMatchingMode1(in DXGI_MODE_DESC1 pModeToMatch, out DXGI_MODE_DESC1 pClosestMatch,
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
		void GetDisplaySurfaceData1([In] IDXGIResource pDestination);

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
		HRESULT DuplicateOutput([In, MarshalAs(UnmanagedType.IUnknown)] object pDevice, out IDXGIOutputDuplication ppOutputDuplication);
	}

	/// <summary>The <b>IDXGIOutputDuplication</b> interface accesses and manipulates the duplicated desktop image.</summary>
	/// <remarks>
	/// <para>
	/// A collaboration application can use <b>IDXGIOutputDuplication</b> to access the desktop image. <b>IDXGIOutputDuplication</b> is
	/// supported in Desktop Window Manager (DWM) on non-8bpp DirectX full-screen modes and non-8bpp OpenGL full-screen modes. 16-bit or
	/// 32-bit GDI non-DWM desktop modes are not supported.
	/// </para>
	/// <para>
	/// An application can use <b>IDXGIOutputDuplication</b> on a separate thread to receive the desktop images and to feed them into their
	/// specific image-processing pipeline. The application uses <b>IDXGIOutputDuplication</b> to perform the following operations:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <description>Acquire the next desktop image.</description>
	/// </item>
	/// <item>
	/// <description>Retrieve the information that describes the image.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Perform an operation on the image. This operation can be as simple as copying the image to a staging buffer so that the application
	/// can read the pixel data on the image. The application reads the pixel data after the application calls <c>IDXGISurface::Map</c>.
	/// Alternatively, this operation can be more complex. For example, the application can run some pixel shaders on the updated regions of
	/// the image to encode those regions for transmission to a client.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// After the application finishes processing each desktop image, it releases the image, loops to step 1, and repeats the steps. The
	/// application repeats these steps until it is finished processing desktop images.
	/// </description>
	/// </item>
	/// </list>
	/// <para>The following components of the operating system can generate the desktop image:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>The DWM by composing the desktop image</description>
	/// </item>
	/// <item>
	/// <description>A full-screen DirectX or OpenGL application</description>
	/// </item>
	/// <item>
	/// <description>
	/// An application by switching to a separate desktop, for example, the secure desktop that is used to display the login screen
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// All current <b>IDXGIOutputDuplication</b> interfaces become invalid when the operating system switches to a different component that
	/// produces the desktop image or when a mode change occurs. In these situations, the application must destroy its current
	/// <b>IDXGIOutputDuplication</b> interface and create a new <b>IDXGIOutputDuplication</b> interface.
	/// </para>
	/// <para>Examples of situations in which <b>IDXGIOutputDuplication</b> becomes invalid are:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Desktop switch</description>
	/// </item>
	/// <item>
	/// <description>Mode change</description>
	/// </item>
	/// <item>
	/// <description>Switch from DWM on, DWM off, or other full-screen application</description>
	/// </item>
	/// </list>
	/// <para>
	/// In these situations, the application must release the <b>IDXGIOutputDuplication</b> interface and must create a new
	/// <b>IDXGIOutputDuplication</b> interface for the new content. If the application does not have the appropriate privilege to the new
	/// desktop image, its call to the <c>IDXGIOutput1::DuplicateOutput</c> method fails.
	/// </para>
	/// <para>
	/// While the application processes each desktop image, the operating system accumulates all the desktop image updates into a single
	/// update. For more information about desktop updates, see <c>Updating the desktop image data</c>.
	/// </para>
	/// <para>The desktop image is always in the <c>DXGI_FORMAT_B8G8R8A8_UNORM</c> format.</para>
	/// <para>The <b>IDXGIOutputDuplication</b> interface does not exist for Windows Store apps.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgioutputduplication
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NN:dxgi1_2.IDXGIOutputDuplication")]
	[ComImport, Guid("191cfac3-a341-470d-b26e-a864f428319c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIOutputDuplication : IDXGIObject
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

		/// <summary>
		/// Retrieves a description of a duplicated output. This description specifies the dimensions of the surface that contains the
		/// desktop image.
		/// </summary>
		/// <returns>
		/// A pointer to a <c>DXGI_OUTDUPL_DESC</c> structure that describes the duplicated output. This parameter must not be <b>NULL</b>.
		/// </returns>
		/// <remarks>
		/// After an application creates an <c>IDXGIOutputDuplication</c> interface, it calls <b>GetDesc</b> to retrieve the dimensions of
		/// the surface that contains the desktop image. The format of the desktop image is always <c>DXGI_FORMAT_B8G8R8A8_UNORM</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgioutputduplication-getdesc void GetDesc( [out]
		// DXGI_OUTDUPL_DESC *pDesc );
		DXGI_OUTDUPL_DESC GetDesc();

		/// <summary>Indicates that the application is ready to process the next desktop image.</summary>
		/// <param name="TimeoutInMilliseconds">
		/// <para>
		/// The time-out interval, in milliseconds. This interval specifies the amount of time that this method waits for a new frame before
		/// it returns to the caller. This method returns if the interval elapses, and a new desktop image is not available.
		/// </para>
		/// <para>For more information about the time-out interval, see Remarks.</para>
		/// </param>
		/// <param name="pFrameInfo">
		/// A pointer to a memory location that receives the <c>DXGI_OUTDUPL_FRAME_INFO</c> structure that describes timing and presentation
		/// statistics for a frame.
		/// </param>
		/// <param name="ppDesktopResource">
		/// A pointer to a variable that receives the <c>IDXGIResource</c> interface of the surface that contains the desktop bitmap.
		/// </param>
		/// <returns>
		/// <para><b>AcquireNextFrame</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if it successfully received the next desktop image.</description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_ACCESS_LOST if the desktop duplication interface is invalid. The desktop duplication interface typically becomes
		/// invalid when a different type of image is displayed on the desktop. Examples of this situation are: In this situation, the
		/// application must release the <c>IDXGIOutputDuplication</c> interface and create a new <b>IDXGIOutputDuplication</b> for the new content.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_WAIT_TIMEOUT if the time-out interval elapsed before the next desktop frame was available.</description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_INVALID_CALL if the application called <b>AcquireNextFrame</b> without releasing the previous frame.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// E_INVALIDARG if one of the parameters to <b>AcquireNextFrame</b> is incorrect; for example, if <i>pFrameInfo</i> is NULL.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>DXGI_ERROR</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When <b>AcquireNextFrame</b> returns successfully, the calling application can access the desktop image that
		/// <b>AcquireNextFrame</b> returns in the variable at <i>ppDesktopResource</i>. If the caller specifies a zero time-out interval in
		/// the <i>TimeoutInMilliseconds</i> parameter, <b>AcquireNextFrame</b> verifies whether there is a new desktop image available,
		/// returns immediately, and indicates its outcome with the return value. If the caller specifies an <b>INFINITE</b> time-out
		/// interval in the <i>TimeoutInMilliseconds</i> parameter, the time-out interval never elapses.
		/// </para>
		/// <para>
		/// <b>Note</b>  You cannot cancel the wait that you specified in the <i>TimeoutInMilliseconds</i> parameter. Therefore, if you must
		/// periodically check for other conditions (for example, a terminate signal), you should specify a non- <b>INFINITE</b> time-out
		/// interval. After the time-out interval elapses, you can check for these other conditions and then call <b>AcquireNextFrame</b>
		/// again to wait for the next frame.
		/// </para>
		/// <para></para>
		/// <para>
		/// <b>AcquireNextFrame</b> acquires a new desktop frame when the operating system either updates the desktop bitmap image or
		/// changes the shape or position of a hardware pointer. The new frame that <b>AcquireNextFrame</b> acquires might have only the
		/// desktop image updated, only the pointer shape or position updated, or both.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgioutputduplication-acquirenextframe HRESULT
		// AcquireNextFrame( [in] UINT TimeoutInMilliseconds, [out] DXGI_OUTDUPL_FRAME_INFO *pFrameInfo, [out] IDXGIResource
		// **ppDesktopResource );
		[PreserveSig]
		HRESULT AcquireNextFrame(uint TimeoutInMilliseconds, out DXGI_OUTDUPL_FRAME_INFO pFrameInfo, out IDXGIResource ppDesktopResource);

		/// <summary>Gets information about dirty rectangles for the current desktop frame.</summary>
		/// <param name="DirtyRectsBufferSize">The size in bytes of the buffer that the caller passed to the <i>pDirtyRectsBuffer</i> parameter.</param>
		/// <param name="pDirtyRectsBuffer">
		/// A pointer to an array of <c>RECT</c> structures that identifies the dirty rectangle regions for the desktop frame.
		/// </param>
		/// <param name="pDirtyRectsBufferSizeRequired">
		/// <para>
		/// Pointer to a variable that receives the number of bytes that <b>GetFrameDirtyRects</b> needs to store information about dirty
		/// regions in the buffer at <i>pDirtyRectsBuffer</i>.
		/// </para>
		/// <para>For more information about returning the required buffer size, see Remarks.</para>
		/// </param>
		/// <returns>
		/// <para><b>GetFrameDirtyRects</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if it successfully retrieved information about dirty rectangles.</description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_ACCESS_LOST if the desktop duplication interface is invalid. The desktop duplication interface typically becomes
		/// invalid when a different type of image is displayed on the desktop. Examples of this situation are: In this situation, the
		/// application must release the <c>IDXGIOutputDuplication</c> interface and create a new <b>IDXGIOutputDuplication</b> for the new content.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_MORE_DATA if the buffer that the calling application provided was not big enough.</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL if the application called <b>GetFrameDirtyRects</b> without owning the desktop image.</description>
		/// </item>
		/// <item>
		/// <description>
		/// E_INVALIDARG if one of the parameters to <b>GetFrameDirtyRects</b> is incorrect; for example, if <i>pDirtyRectsBuffer</i> is NULL.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>DXGI_ERROR</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>GetFrameDirtyRects</b> stores a size value in the variable at <i>pDirtyRectsBufferSizeRequired</i>. This value specifies the
		/// number of bytes that <b>GetFrameDirtyRects</b> needs to store information about dirty regions. You can use this value in the
		/// following situations to determine the amount of memory to allocate for future buffers that you pass to <i>pDirtyRectsBuffer</i>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><b>GetFrameDirtyRects</b> fails with DXGI_ERROR_MORE_DATA because the buffer is not big enough.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>GetFrameDirtyRects</b> supplies a buffer that is bigger than necessary. The size value returned at
		/// <i>pDirtyRectsBufferSizeRequired</i> informs the caller how much buffer space was actually used compared to how much buffer
		/// space the caller allocated and specified in the <i>DirtyRectsBufferSize</i> parameter.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// The caller can also use the value returned at <i>pDirtyRectsBufferSizeRequired</i> to determine the number of <c>RECT</c> s
		/// returned in the <i>pDirtyRectsBuffer</i> array.
		/// </para>
		/// <para>The buffer contains the list of dirty <c>RECT</c> s for the current frame.</para>
		/// <para>
		/// <b>Note</b>  To produce a visually accurate copy of the desktop, an application must first process all move <c>RECT</c> s before
		/// it processes dirty <b>RECT</b> s.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgioutputduplication-getframedirtyrects HRESULT
		// GetFrameDirtyRects( [in] UINT DirtyRectsBufferSize, [out] RECT *pDirtyRectsBuffer, [out] UINT *pDirtyRectsBufferSizeRequired );
		[PreserveSig]
		HRESULT GetFrameDirtyRects(uint DirtyRectsBufferSize, [Out, Optional] IntPtr pDirtyRectsBuffer, out uint pDirtyRectsBufferSizeRequired);

		/// <summary>Gets information about the moved rectangles for the current desktop frame.</summary>
		/// <param name="MoveRectsBufferSize">The size in bytes of the buffer that the caller passed to the <i>pMoveRectBuffer</i> parameter.</param>
		/// <param name="pMoveRectBuffer">
		/// A pointer to an array of <c>DXGI_OUTDUPL_MOVE_RECT</c> structures that identifies the moved rectangle regions for the desktop frame.
		/// </param>
		/// <param name="pMoveRectsBufferSizeRequired">
		/// <para>
		/// Pointer to a variable that receives the number of bytes that <b>GetFrameMoveRects</b> needs to store information about moved
		/// regions in the buffer at <i>pMoveRectBuffer</i>.
		/// </para>
		/// <para>For more information about returning the required buffer size, see Remarks.</para>
		/// </param>
		/// <returns>
		/// <para><b>GetFrameMoveRects</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if it successfully retrieved information about moved rectangles.</description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_ACCESS_LOST if the desktop duplication interface is invalid. The desktop duplication interface typically becomes
		/// invalid when a different type of image is displayed on the desktop. Examples of this situation are: In this situation, the
		/// application must release the <c>IDXGIOutputDuplication</c> interface and create a new <b>IDXGIOutputDuplication</b> for the new content.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_MORE_DATA if the buffer that the calling application provided is not big enough.</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL if the application called <b>GetFrameMoveRects</b> without owning the desktop image.</description>
		/// </item>
		/// <item>
		/// <description>
		/// E_INVALIDARG if one of the parameters to <b>GetFrameMoveRects</b> is incorrect; for example, if <i>pMoveRectBuffer</i> is NULL.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>DXGI_ERROR</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>GetFrameMoveRects</b> stores a size value in the variable at <i>pMoveRectsBufferSizeRequired</i>. This value specifies the
		/// number of bytes that <b>GetFrameMoveRects</b> needs to store information about moved regions. You can use this value in the
		/// following situations to determine the amount of memory to allocate for future buffers that you pass to <i>pMoveRectBuffer</i>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><b>GetFrameMoveRects</b> fails with DXGI_ERROR_MORE_DATA because the buffer is not big enough.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>GetFrameMoveRects</b> supplies a buffer that is bigger than necessary. The size value returned at
		/// <i>pMoveRectsBufferSizeRequired</i> informs the caller how much buffer space was actually used compared to how much buffer space
		/// the caller allocated and specified in the <i>MoveRectsBufferSize</i> parameter.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// The caller can also use the value returned at <i>pMoveRectsBufferSizeRequired</i> to determine the number of
		/// <c>DXGI_OUTDUPL_MOVE_RECT</c> structures returned.
		/// </para>
		/// <para>The buffer contains the list of move RECTs for the current frame.</para>
		/// <para>
		/// <b>Note</b>  To produce a visually accurate copy of the desktop, an application must first process all move RECTs before it
		/// processes dirty RECTs.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgioutputduplication-getframemoverects HRESULT
		// GetFrameMoveRects( [in] UINT MoveRectsBufferSize, [out] DXGI_OUTDUPL_MOVE_RECT *pMoveRectBuffer, [out] UINT
		// *pMoveRectsBufferSizeRequired );
		[PreserveSig]
		HRESULT GetFrameMoveRects(uint MoveRectsBufferSize, [Out, Optional] IntPtr pMoveRectBuffer, out uint pMoveRectsBufferSizeRequired);

		/// <summary>Gets information about the new pointer shape for the current desktop frame.</summary>
		/// <param name="PointerShapeBufferSize">
		/// The size in bytes of the buffer that the caller passed to the <i>pPointerShapeBuffer</i> parameter.
		/// </param>
		/// <param name="pPointerShapeBuffer">
		/// A pointer to a buffer to which <b>GetFramePointerShape</b> copies and returns pixel data for the new pointer shape.
		/// </param>
		/// <param name="pPointerShapeBufferSizeRequired">
		/// <para>
		/// Pointer to a variable that receives the number of bytes that <b>GetFramePointerShape</b> needs to store the new pointer shape
		/// pixel data in the buffer at <i>pPointerShapeBuffer</i>.
		/// </para>
		/// <para>For more information about returning the required buffer size, see Remarks.</para>
		/// </param>
		/// <param name="pPointerShapeInfo">
		/// Pointer to a <c>DXGI_OUTDUPL_POINTER_SHAPE_INFO</c> structure that receives the pointer shape information.
		/// </param>
		/// <returns>
		/// <para><b>GetFramePointerShape</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if it successfully retrieved information about the new pointer shape.</description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_ACCESS_LOST if the desktop duplication interface is invalid. The desktop duplication interface typically becomes
		/// invalid when a different type of image is displayed on the desktop. Examples of this situation are: In this situation, the
		/// application must release the <c>IDXGIOutputDuplication</c> interface and create a new <b>IDXGIOutputDuplication</b> for the new content.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_MORE_DATA if the buffer that the calling application provided was not big enough.</description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_INVALID_CALL if the application called <b>GetFramePointerShape</b> without owning the desktop image.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// E_INVALIDARG if one of the parameters to <b>GetFramePointerShape</b> is incorrect; for example, if <i>pPointerShapeInfo</i> is NULL.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>DXGI_ERROR</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>GetFramePointerShape</b> stores a size value in the variable at <i>pPointerShapeBufferSizeRequired</i>. This value specifies
		/// the number of bytes that <i>pPointerShapeBufferSizeRequired</i> needs to store the new pointer shape pixel data. You can use the
		/// value in the following situations to determine the amount of memory to allocate for future buffers that you pass to <i>pPointerShapeBuffer</i>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><b>GetFramePointerShape</b> fails with DXGI_ERROR_MORE_DATA because the buffer is not big enough.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>GetFramePointerShape</b> supplies a bigger than necessary buffer. The size value returned at
		/// <i>pPointerShapeBufferSizeRequired</i> informs the caller how much buffer space was actually used compared to how much buffer
		/// space the caller allocated and specified in the <i>PointerShapeBufferSize</i> parameter.
		/// </description>
		/// </item>
		/// </list>
		/// <para>The <i>pPointerShapeInfo</i> parameter describes the new pointer shape.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgioutputduplication-getframepointershape HRESULT
		// GetFramePointerShape( [in] UINT PointerShapeBufferSize, [out] void *pPointerShapeBuffer, [out] UINT
		// *pPointerShapeBufferSizeRequired, [out] DXGI_OUTDUPL_POINTER_SHAPE_INFO *pPointerShapeInfo );
		[PreserveSig]
		HRESULT GetFramePointerShape(uint PointerShapeBufferSize, [Out, Optional] IntPtr pPointerShapeBuffer, out uint pPointerShapeBufferSizeRequired, out DXGI_OUTDUPL_POINTER_SHAPE_INFO pPointerShapeInfo);

		/// <summary>Provides the CPU with efficient access to a desktop image if that desktop image is already in system memory.</summary>
		/// <param name="pLockedRect">
		/// A pointer to a <c>DXGI_MAPPED_RECT</c> structure that receives the surface data that the CPU needs to directly access the
		/// surface data.
		/// </param>
		/// <returns>
		/// <para><b>MapDesktopSurface</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if it successfully retrieved the surface data.</description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_ACCESS_LOST if the desktop duplication interface is invalid. The desktop duplication interface typically becomes
		/// invalid when a different type of image is displayed on the desktop. Examples of this situation are: In this situation, the
		/// application must release the <c>IDXGIOutputDuplication</c> interface and create a new <b>IDXGIOutputDuplication</b> for the new content.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_INVALID_CALL if the application already has an outstanding map on the desktop image. The application must call
		/// <c>UnMapDesktopSurface</c> before it calls <b>MapDesktopSurface</b> again. DXGI_ERROR_INVALID_CALL is also returned if the
		/// application did not own the desktop image when it called <b>MapDesktopSurface</b>.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_UNSUPPORTED if the desktop image is not in system memory. In this situation, the application must first transfer the
		/// image to a staging surface and then lock the image by calling the <c>IDXGISurface::Map</c> method.
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG if the <i>pLockedRect</i> parameter is incorrect; for example, if <i>pLockedRect</i> is <b>NULL</b>.</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>DXGI_ERROR</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// You can successfully call <b>MapDesktopSurface</b> if the <b>DesktopImageInSystemMemory</b> member of the
		/// <c>DXGI_OUTDUPL_DESC</c> structure is set to <b>TRUE</b>. If <b>DesktopImageInSystemMemory</b> is <b>FALSE</b>,
		/// <b>MapDesktopSurface</b> returns DXGI_ERROR_UNSUPPORTED. Call <c>IDXGIOutputDuplication::GetDesc</c> to retrieve the
		/// <b>DXGI_OUTDUPL_DESC</b> structure.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgioutputduplication-mapdesktopsurface HRESULT
		// MapDesktopSurface( [out] DXGI_MAPPED_RECT *pLockedRect );
		[PreserveSig]
		HRESULT MapDesktopSurface(out DXGI_MAPPED_RECT pLockedRect);

		/// <summary>Invalidates the pointer to the desktop image that was retrieved by using <c>IDXGIOutputDuplication::MapDesktopSurface</c>.</summary>
		/// <returns>
		/// <para><b>UnMapDesktopSurface</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if it successfully completed.</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL if the application did not map the desktop surface by calling <c>IDXGIOutputDuplication::MapDesktopSurface</c>.</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>DXGI_ERROR</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgioutputduplication-unmapdesktopsurface HRESULT UnMapDesktopSurface();
		[PreserveSig]
		HRESULT UnMapDesktopSurface();

		/// <summary>Indicates that the application finished processing the frame.</summary>
		/// <returns>
		/// <para><b>ReleaseFrame</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if it successfully completed.</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL if the application already released the frame.</description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_ACCESS_LOST if the desktop duplication interface is invalid. The desktop duplication interface typically becomes
		/// invalid when a different type of image is displayed on the desktop. Examples of this situation are: In this situation, the
		/// application must release the <c>IDXGIOutputDuplication</c> interface and create a new <b>IDXGIOutputDuplication</b> for the new content.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>DXGI_ERROR</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The application must release the frame before it acquires the next frame. After the frame is released, the surface that contains
		/// the desktop bitmap becomes invalid; you will not be able to use the surface in a DirectX graphics operation.
		/// </para>
		/// <para>
		/// For performance reasons, we recommend that you release the frame just before you call the
		/// <c>IDXGIOutputDuplication::AcquireNextFrame</c> method to acquire the next frame. When the client does not own the frame, the
		/// operating system copies all desktop updates to the surface. This can result in wasted GPU cycles if the operating system updates
		/// the same region for each frame that occurs. When the client acquires the frame, the client is aware of only the final update to
		/// this region; therefore, any overlapping updates during previous frames are wasted. When the client acquires a frame, the client
		/// owns the surface; therefore, the operating system can track only the updated regions and cannot copy desktop updates to the
		/// surface. Because of this behavior, we recommend that you minimize the time between the call to release the current frame and the
		/// call to acquire the next frame.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgioutputduplication-releaseframe HRESULT ReleaseFrame();
		[PreserveSig]
		HRESULT ReleaseFrame();
	}

	/// <summary>
	/// An <b>IDXGIResource1</b> interface extends the <c>IDXGIResource</c> interface by adding support for creating a subresource surface
	/// object and for creating a handle to a shared resource.
	/// </summary>
	/// <remarks>
	/// <para>
	/// To determine the type of memory a resource is currently located in, use <c>IDXGIDevice::QueryResourceResidency</c>. To share
	/// resources between processes, use <c>ID3D11Device1::OpenSharedResource1</c>. For information about how to share resources between
	/// multiple Windows graphics APIs, including Direct3D 11, Direct2D, Direct3D 10, and Direct3D 9Ex, see <c>Surface Sharing Between
	/// Windows Graphics APIs</c>.
	/// </para>
	/// <para>
	/// You can retrieve the <b>IDXGIResource1</b> interface from any video memory resource that you create from a Direct3D 10 and later
	/// function. Any Direct3D object that supports <c>ID3D10Resource</c> or <c>ID3D11Resource</c> also supports <b>IDXGIResource1</b>. For
	/// example, the Direct3D 2D texture object that you create from <c>ID3D11Device::CreateTexture2D</c> supports <b>IDXGIResource1</b>.
	/// You can call <c>QueryInterface</c> on the 2D texture object ( <c>ID3D11Texture2D</c>) to retrieve the <b>IDXGIResource1</b>
	/// interface. For example, to retrieve the <b>IDXGIResource1</b> interface from the 2D texture object, use the following code.
	/// </para>
	/// <para><c>IDXGIResource1 * pDXGIResource; hr = g_pd3dTexture2D-&gt;QueryInterface(__uuidof(IDXGIResource1), (void **)&amp;pDXGIResource);</c></para>
	/// <para><b>Windows Phone 8:</b> This API is supported.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgiresource1
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NN:dxgi1_2.IDXGIResource1")]
	[ComImport, Guid("30961379-4609-4a41-998e-54fe567ee0c1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIResource1 : IDXGIResource
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
		new HRESULT GetSharedHandle(out HANDLE pSharedHandle);

		/// <summary>Get the expected resource usage.</summary>
		/// <returns>
		/// <para>Type: <b><c>DXGI_USAGE</c>*</b></para>
		/// <para>
		/// A pointer to a usage flag (see <c>DXGI_USAGE</c>). For Direct3D 10, a surface can be used as a shader input or a render-target output.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiresource-getusage HRESULT GetUsage( DXGI_USAGE *pUsage );
		new DXGI_USAGE GetUsage();

		/// <summary>Set the priority for evicting the resource from memory.</summary>
		/// <param name="EvictionPriority">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The priority is one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><c></c><b>DXGI_RESOURCE_PRIORITY_MINIMUM (0x28000000)</b></description>
		/// <description>
		/// The resource is unused and can be evicted as soon as another resource requires the memory that the resource occupies.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><c></c><b>DXGI_RESOURCE_PRIORITY_LOW (0x50000000)</b></description>
		/// <description>
		/// The eviction priority of the resource is low. The placement of the resource is not critical, and minimal work is performed to
		/// find a location for the resource. For example, if a GPU can render with a vertex buffer from either local or non-local memory
		/// with little difference in performance, that vertex buffer is low priority. Other more critical resources (for example, a render
		/// target or texture) can then occupy the faster memory.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><c></c><b>DXGI_RESOURCE_PRIORITY_NORMAL (0x78000000)</b></description>
		/// <description>
		/// The eviction priority of the resource is normal. The placement of the resource is important, but not critical, for performance.
		/// The resource is placed in its preferred location instead of a low-priority resource.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><c></c><b>DXGI_RESOURCE_PRIORITY_HIGH (0xa0000000)</b></description>
		/// <description>
		/// The eviction priority of the resource is high. The resource is placed in its preferred location instead of a low-priority or
		/// normal-priority resource.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><c></c><b>DXGI_RESOURCE_PRIORITY_MAXIMUM (0xc8000000)</b></description>
		/// <description>The resource is evicted from memory only if there is no other way of resolving the memory requirement.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// The eviction priority is a memory-management variable that is used by DXGI for determining how to populate overcommitted memory.
		/// </para>
		/// <para>
		/// You can set priority levels other than the defined values when appropriate. For example, you can set a resource with a priority
		/// level of 0x78000001 to indicate that the resource is slightly above normal.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiresource-setevictionpriority HRESULT SetEvictionPriority(
		// UINT EvictionPriority );
		new void SetEvictionPriority(uint EvictionPriority);

		/// <summary>Get the eviction priority.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>A pointer to the eviction priority, which determines when a resource can be evicted from memory.</para>
		/// <para>The following defined values are possible.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><c></c><b>DXGI_RESOURCE_PRIORITY_MINIMUM (0x28000000)</b></description>
		/// <description>
		/// The resource is unused and can be evicted as soon as another resource requires the memory that the resource occupies.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><c></c><b>DXGI_RESOURCE_PRIORITY_LOW (0x50000000)</b></description>
		/// <description>
		/// The eviction priority of the resource is low. The placement of the resource is not critical, and minimal work is performed to
		/// find a location for the resource. For example, if a GPU can render with a vertex buffer from either local or non-local memory
		/// with little difference in performance, that vertex buffer is low priority. Other more critical resources (for example, a render
		/// target or texture) can then occupy the faster memory.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><c></c><b>DXGI_RESOURCE_PRIORITY_NORMAL (0x78000000)</b></description>
		/// <description>
		/// The eviction priority of the resource is normal. The placement of the resource is important, but not critical, for performance.
		/// The resource is placed in its preferred location instead of a low-priority resource.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><c></c><b>DXGI_RESOURCE_PRIORITY_HIGH (0xa0000000)</b></description>
		/// <description>
		/// The eviction priority of the resource is high. The resource is placed in its preferred location instead of a low-priority or
		/// normal-priority resource.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><c></c><b>DXGI_RESOURCE_PRIORITY_MAXIMUM (0xc8000000)</b></description>
		/// <description>The resource is evicted from memory only if there is no other way of resolving the memory requirement.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The eviction priority is a memory-management variable that is used by DXGI to determine how to manage overcommitted memory.</para>
		/// <para>
		/// Priority levels other than the defined values are used when appropriate. For example, a resource with a priority level of
		/// 0x78000001 indicates that the resource is slightly above normal.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgiresource-getevictionpriority HRESULT GetEvictionPriority(
		// [out] UINT *pEvictionPriority );
		new uint GetEvictionPriority();

		/// <summary>Creates a subresource surface object.</summary>
		/// <param name="index">The index of the subresource surface object to enumerate.</param>
		/// <returns>
		/// The address of a pointer to a <c>IDXGISurface2</c> interface that represents the created subresource surface object at the
		/// position specified by the <i>index</i> parameter.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Subresource surface objects implement the <c>IDXGISurface2</c> interface, which inherits from <c>IDXGISurface1</c> and
		/// indirectly <c>IDXGISurface</c>. Therefore, the GDI-interoperable methods of <b>IDXGISurface1</b> work if the original resource
		/// interface object was created with the GDI-interoperable flag ( <c>D3D11_RESOURCE_MISC_GDI_COMPATIBLE</c>).
		/// </para>
		/// <para>
		/// <b>CreateSubresourceSurface</b> creates a subresource surface that is based on the resource interface on which
		/// <b>CreateSubresourceSurface</b> is called. For example, if the original resource interface object is a 2D texture, the created
		/// subresource surface is also a 2D texture.
		/// </para>
		/// <para>
		/// You can use <b>CreateSubresourceSurface</b> to create parts of a stereo resource so you can use Direct2D on either the left or
		/// right part of the stereo resource.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiresource1-createsubresourcesurface HRESULT
		// CreateSubresourceSurface( UINT index, [out] IDXGISurface2 **ppSurface );
		IDXGISurface2 CreateSubresourceSurface(uint index);

		/// <summary>Creates a handle to a shared resource. You can then use the returned handle with multiple Direct3D devices.</summary>
		/// <param name="pAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that contains two separate but related data members: an optional security
		/// descriptor, and a Boolean value that determines whether child processes can inherit the returned handle.
		/// </para>
		/// <para>
		/// Set this parameter to <b>NULL</b> if you want child processes that the application might create to not inherit the handle
		/// returned by <b>CreateSharedHandle</b>, and if you want the resource that is associated with the returned handle to get a default
		/// security descriptor.
		/// </para>
		/// <para>
		/// The <b>lpSecurityDescriptor</b> member of the structure specifies a <c>SECURITY_DESCRIPTOR</c> for the resource. Set this member
		/// to <b>NULL</b> if you want the runtime to assign a default security descriptor to the resource that is associated with the
		/// returned handle. The ACLs in the default security descriptor for the resource come from the primary or impersonation token of
		/// the creator. For more info, see <c>Synchronization Object Security and Access Rights</c>.
		/// </para>
		/// </param>
		/// <param name="dwAccess">
		/// <para>
		/// The requested access rights to the resource. In addition to the <c>generic access rights</c>, DXGI defines the following values:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><b>DXGI_SHARED_RESOURCE_READ</b> ( 0x80000000L ) - specifies read access to the resource.</description>
		/// </item>
		/// <item>
		/// <description><b>DXGI_SHARED_RESOURCE_WRITE</b> ( 1 ) - specifies write access to the resource.</description>
		/// </item>
		/// </list>
		/// <para>You can combine these values by using a bitwise OR operation.</para>
		/// </param>
		/// <param name="lpName">
		/// <para>The name of the resource to share. The name is limited to MAX_PATH characters. Name comparison is case sensitive.</para>
		/// <para>
		/// You will need the resource name if you call the <c>ID3D11Device1::OpenSharedResourceByName</c> method to access the shared
		/// resource by name. If you instead call the <c>ID3D11Device1::OpenSharedResource1</c> method to access the shared resource by
		/// handle, set this parameter to <b>NULL</b>.
		/// </para>
		/// <para>
		/// If <i>lpName</i> matches the name of an existing resource, <b>CreateSharedHandle</b> fails with
		/// <c>DXGI_ERROR_NAME_ALREADY_EXISTS</c>. This occurs because these objects share the same namespace.
		/// </para>
		/// <para>
		/// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace. The remainder
		/// of the name can contain any character except the backslash character (\). For more information, see <c>Kernel Object
		/// Namespaces</c>. Fast user switching is implemented using Terminal Services sessions. Kernel object names must follow the
		/// guidelines outlined for Terminal Services so that applications can support multiple users.
		/// </para>
		/// <para>The object can be created in a private namespace. For more information, see <c>Object Namespaces</c>.</para>
		/// </param>
		/// <param name="pHandle">
		/// A pointer to a variable that receives the NT HANDLE value to the resource to share. You can use this handle in calls to access
		/// the resource.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>DXGI_ERROR_INVALID_CALL</c> if one of the parameters is invalid.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>DXGI_ERROR_NAME_ALREADY_EXISTS</c> if the supplied name of the resource to share is already associated with another resource.
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_ACCESSDENIED if the object is being created in a protected namespace.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY if sufficient memory is not available to create the handle.</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>DXGI_ERROR</c> topic.</description>
		/// </item>
		/// </list>
		/// <para>
		/// <b>Platform Update for Windows 7:  </b> On Windows 7 or Windows Server 2008 R2 with the <c>Platform Update for Windows 7</c>
		/// installed, <b>CreateSharedHandle</b> fails with E_NOTIMPL. For more info about the Platform Update for Windows 7, see
		/// <c>Platform Update for Windows 7</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>CreateSharedHandle</b> only returns the NT handle when you created the resource as shared and specified that it uses NT
		/// handles (that is, you set the <c>D3D11_RESOURCE_MISC_SHARED_NTHANDLE</c> and <c>D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX</c>
		/// flags). If you created the resource as shared and specified that it uses NT handles, you must use <b>CreateSharedHandle</b> to
		/// get a handle for sharing. In this situation, you can't use the <c>IDXGIResource::GetSharedHandle</c> method because it will fail.
		/// </para>
		/// <para>
		/// You can pass the handle that <b>CreateSharedHandle</b> returns in a call to the <c>ID3D11Device1::OpenSharedResource1</c> method
		/// to give a device access to a shared resource that you created on a different device.
		/// </para>
		/// <para>
		/// Because the handle that <b>CreateSharedHandle</b> returns is an NT handle, you can use the handle with <c>CloseHandle</c>,
		/// <c>DuplicateHandle</c>, and so on. You can call <b>CreateSharedHandle</b> only once for a shared resource; later calls fail. If
		/// you need more handles to the same shared resource, call <b>DuplicateHandle</b>. When you no longer need the shared resource
		/// handle, call <b>CloseHandle</b> to close the handle, in order to avoid memory leaks.
		/// </para>
		/// <para>
		/// If you pass a name for the resource to <i>lpName</i> when you call <b>CreateSharedHandle</b> to share the resource, you can
		/// subsequently pass this name in a call to the <c>ID3D11Device1::OpenSharedResourceByName</c> method to give another device access
		/// to the shared resource. If you use a named resource, a malicious user can use this named resource before you do and prevent your
		/// app from starting. To prevent this situation, create a randomly named resource and store the name so that it can only be
		/// obtained by an authorized user. Alternatively, you can use a file for this purpose. To limit your app to one instance per user,
		/// create a locked file in the user's profile directory.
		/// </para>
		/// <para>
		/// If you created the resource as shared and did not specify that it uses NT handles, you cannot use <b>CreateSharedHandle</b> to
		/// get a handle for sharing because <b>CreateSharedHandle</b> will fail.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// <c>ID3D11Texture2D* pTexture2D; ID3D11Device* pDevice; pDevice-&gt;CreateTexture2D(…, &amp;pTexture2D); // Create the texture as
		/// shared with NT HANDLEs. HANDLE handle; IDXGIResource1* pResource; pTexture2D-&gt;QueryInterface(__uuidof(IDXGIResource1),
		/// (void**) &amp;pResource); pResource-&gt;CreateSharedHandle(NULL, DXGI_SHARED_RESOURCE_READ | DXGI_SHARED_RESOURCE_WRITE, NULL,
		/// &amp;handle); // Pass the handle to another process to share the resource.</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiresource1-createsharedhandle HRESULT
		// CreateSharedHandle( [in, optional] const SECURITY_ATTRIBUTES *pAttributes, [in] DWORD dwAccess, [in, optional] LPCWSTR lpName,
		// [out] HANDLE *pHandle );
		[PreserveSig]
		HRESULT CreateSharedHandle([In, Optional] SECURITY_ATTRIBUTES? pAttributes, ACCESS_MASK dwAccess,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string? lpName, out HANDLE pHandle);
	}

	/// <summary>
	/// The <b>IDXGISurface2</b> interface extends the <c>IDXGISurface1</c> interface by adding support for subresource surfaces and getting
	/// a handle to a shared resource.
	/// </summary>
	/// <remarks>
	/// <para>
	/// An image-data object is a 2D section of memory, commonly called a surface. To get the surface from an output, call
	/// <c>IDXGIOutput::GetDisplaySurfaceData</c>. Then, call <c>QueryInterface</c> on the <c>IDXGISurface</c> object that
	/// <b>IDXGIOutput::GetDisplaySurfaceData</b> returns to retrieve the <b>IDXGISurface2</b> interface.
	/// </para>
	/// <para>Any object that supports <c>IDXGISurface</c> also supports <b>IDXGISurface2</b>.</para>
	/// <para>
	/// The runtime automatically creates an <b>IDXGISurface2</b> interface when it creates a Direct3D resource object that represents a
	/// surface. For example, the runtime creates an <b>IDXGISurface2</b> interface when you call <c>ID3D11Device::CreateTexture2D</c> to
	/// create a 2D texture. To retrieve the <b>IDXGISurface2</b> interface that represents the 2D texture surface, call
	/// <c>ID3D11Texture2D::QueryInterface</c>. In this call, you must pass the identifier of <b>IDXGISurface2</b>. If the 2D texture has
	/// only a single MIP-map level and does not consist of an array of textures, <b>QueryInterface</b> succeeds and returns a pointer to
	/// the <b>IDXGISurface2</b> interface pointer. Otherwise, <b>QueryInterface</b> fails and does not return the pointer to <b>IDXGISurface2</b>.
	/// </para>
	/// <para>
	/// You can call the <c>IDXGIResource1::CreateSubresourceSurface</c> method to create an <b>IDXGISurface2</b> interface that refers to
	/// one subresource of a stereo resource.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgisurface2
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NN:dxgi1_2.IDXGISurface2")]
	[ComImport, Guid("aba496dd-b617-4cb8-a866-bc44d7eb1fa2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGISurface2 : IDXGISurface1
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
		new HRESULT GetDC(bool Discard, out HDC phdc);

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
		new HRESULT ReleaseDC(HDC pDirtyRect);

		/// <summary>Gets the parent resource and subresource index that support a subresource surface.</summary>
		/// <param name="riid">The globally unique identifier (GUID) of the requested interface type.</param>
		/// <param name="ppParentResource">
		/// A pointer to a buffer that receives a pointer to the parent resource object for the subresource surface.
		/// </param>
		/// <param name="pSubresourceIndex">A pointer to a variable that receives the index of the subresource surface.</param>
		/// <returns>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>E_NOINTERFACE if the object does not implement the GUID that the <i>riid</i> parameter specifies.</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>DXGI_ERROR</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For subresource surface objects that the <c>IDXGIResource1::CreateSubresourceSurface</c> method creates, <b>GetResource</b>
		/// simply returns the values that were used to create the subresource surface.
		/// </para>
		/// <para>
		/// Current objects that implement <c>IDXGISurface</c> are either resources or views. <b>GetResource</b> for these objects returns
		/// “this” or the resource that supports the view respectively. In this situation, the subresource index is 0.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgisurface2-getresource HRESULT GetResource( [in] REFIID
		// riid, [out] void **ppParentResource, [out] UINT *pSubresourceIndex );
		[PreserveSig]
		HRESULT GetResource(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppParentResource, out uint pSubresourceIndex);
	}

	/// <summary>
	/// Provides presentation capabilities that are enhanced from <c>IDXGISwapChain</c>. These presentation capabilities consist of
	/// specifying dirty rectangles and scroll rectangle to optimize the presentation.
	/// </summary>
	/// <remarks>
	/// <para>
	/// You can create a swap chain by calling <c>IDXGIFactory2::CreateSwapChainForHwnd</c>,
	/// <c>IDXGIFactory2::CreateSwapChainForCoreWindow</c>, or <c>IDXGIFactory2::CreateSwapChainForComposition</c>. You can also create a
	/// swap chain when you call <c>D3D11CreateDeviceAndSwapChain</c>; however, you can then only access the sub-set of swap-chain
	/// functionality that the <c>IDXGISwapChain</c> interface provides.
	/// </para>
	/// <para>
	/// <b>IDXGISwapChain1</b> provides the <c>IsTemporaryMonoSupported</c> method that you can use to determine whether the swap chain
	/// supports "temporary mono” presentation. This type of swap chain is a stereo swap chain that can be used to present mono content.
	/// </para>
	/// <para>
	/// <b>Note</b>  Some stereo features like the advanced presentation flags are not represented by an explicit interface change.
	/// Furthermore, the original ( <c>IDXGISwapChain</c>) and new ( <b>IDXGISwapChain1</b>) swap chain interfaces generally have the same
	/// behavior. For information about how <b>IDXGISwapChain</b> methods are translated into <b>IDXGISwapChain1</b> methods, see the
	/// descriptions of the <b>IDXGISwapChain1</b> methods.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgiswapchain1
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NN:dxgi1_2.IDXGISwapChain1")]
	[ComImport, Guid("790a45f7-0d42-4876-983a-0a55cfe6f4aa"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGISwapChain1 : IDXGISwapChain
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
		DXGI_SWAP_CHAIN_DESC1 GetDesc1();

		/// <summary>Gets a description of a full-screen swap chain.</summary>
		/// <returns>A pointer to a <c>DXGI_SWAP_CHAIN_FULLSCREEN_DESC</c> structure that describes the full-screen swap chain.</returns>
		/// <remarks>
		/// The semantics of <b>GetFullscreenDesc</b> are identical to that of the <c>IDXGISwapchain::GetDesc</c> method for
		/// <c>HWND</c>-based swap chains.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getfullscreendesc HRESULT
		// GetFullscreenDesc( [out] DXGI_SWAP_CHAIN_FULLSCREEN_DESC *pDesc );
		DXGI_SWAP_CHAIN_FULLSCREEN_DESC GetFullscreenDesc();

		/// <summary>Retrieves the underlying <c>HWND</c> for this swap-chain object.</summary>
		/// <returns>A pointer to a variable that receives the <c>HWND</c> for the swap-chain object.</returns>
		/// <remarks>
		/// Applications call the <c>IDXGIFactory2::CreateSwapChainForHwnd</c> method to create a swap chain that is associated with an <c>HWND</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-gethwnd HRESULT GetHwnd( [out] HWND *pHwnd );
		HWND GetHwnd();

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
		HRESULT GetCoreWindow(in Guid refiid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppUnk);

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
		HRESULT Present1(uint SyncInterval, DXGI_PRESENT PresentFlags, in DXGI_PRESENT_PARAMETERS pPresentParameters);

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
		bool IsTemporaryMonoSupported();

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
		IDXGIOutput GetRestrictToOutput();

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
		void SetBackgroundColor(in D3DCOLORVALUE pColor);

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
		D3DCOLORVALUE GetBackgroundColor();

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
		void SetRotation(DXGI_MODE_ROTATION Rotation);

		/// <summary>Gets the rotation of the back buffers for the swap chain.</summary>
		/// <returns>
		/// A pointer to a variable that receives a <c>DXGI_MODE_ROTATION</c>-typed value that specifies the rotation of the back buffers
		/// for the swap chain.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgiswapchain1-getrotation HRESULT GetRotation( [out]
		// DXGI_MODE_ROTATION *pRotation );
		DXGI_MODE_ROTATION GetRotation();
	}

	/// <summary>Describes an adapter (or video card) that uses Microsoft DirectX Graphics Infrastructure (DXGI) 1.2.</summary>
	/// <remarks>
	/// The <c>DXGI_ADAPTER_DESC2</c> structure provides a DXGI 1.2 description of an adapter. This structure is initialized by using the
	/// IDXGIAdapter2::GetDesc2 method.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_adapter_desc2 typedef struct DXGI_ADAPTER_DESC2 { WCHAR
	// Description[128]; UINT VendorId; UINT DeviceId; UINT SubSysId; UINT Revision; SIZE_T DedicatedVideoMemory; SIZE_T
	// DedicatedSystemMemory; SIZE_T SharedSystemMemory; LUID AdapterLuid; UINT Flags; DXGI_GRAPHICS_PREEMPTION_GRANULARITY
	// GraphicsPreemptionGranularity; DXGI_COMPUTE_PREEMPTION_GRANULARITY ComputePreemptionGranularity; } DXGI_ADAPTER_DESC2;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NS:dxgi1_2.DXGI_ADAPTER_DESC2"), StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DXGI_ADAPTER_DESC2
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
		/// A value of the DXGI_ADAPTER_FLAG enumerated type that describes the adapter type. The <c>DXGI_ADAPTER_FLAG_REMOTE</c> flag is reserved.
		/// </summary>
		public DXGI_ADAPTER_FLAG Flags;

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

	/// <summary>Describes a display mode and whether the display mode supports stereo.</summary>
	/// <remarks>
	/// <para><c>DXGI_MODE_DESC1</c> is identical to DXGI_MODE_DESC except that <c>DXGI_MODE_DESC1</c> includes the <c>Stereo</c> member.</para>
	/// <para>This structure is used by the GetDisplayModeList1 and FindClosestMatchingMode1 methods.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_mode_desc1 typedef struct DXGI_MODE_DESC1 { UINT Width;
	// UINT Height; DXGI_RATIONAL RefreshRate; DXGI_FORMAT Format; DXGI_MODE_SCANLINE_ORDER ScanlineOrdering; DXGI_MODE_SCALING Scaling;
	// BOOL Stereo; } DXGI_MODE_DESC1;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NS:dxgi1_2.DXGI_MODE_DESC1"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_MODE_DESC1
	{
		/// <summary>A value that describes the resolution width.</summary>
		public uint Width;

		/// <summary>A value that describes the resolution height.</summary>
		public uint Height;

		/// <summary>A DXGI_RATIONAL structure that describes the refresh rate in hertz.</summary>
		public DXGI_RATIONAL RefreshRate;

		/// <summary>A DXGI_FORMAT-typed value that describes the display format.</summary>
		public DXGI_FORMAT Format;

		/// <summary>A DXGI_MODE_SCANLINE_ORDER-typed value that describes the scan-line drawing mode.</summary>
		public DXGI_MODE_SCANLINE_ORDER ScanlineOrdering;

		/// <summary>A DXGI_MODE_SCALING-typed value that describes the scaling mode.</summary>
		public DXGI_MODE_SCALING Scaling;

		/// <summary>Specifies whether the full-screen display mode is stereo. <c>TRUE</c> if stereo; otherwise, <c>FALSE</c>.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool Stereo;
	}

	/// <summary>
	/// The DXGI_OUTDUPL_DESC structure describes the dimension of the output and the surface that contains the desktop image. The format of
	/// the desktop image is always <c>DXGI_FORMAT_B8G8R8A8_UNORM</c>.
	/// </summary>
	/// <remarks>This structure is used by <c>GetDesc</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_outdupl_desc typedef struct DXGI_OUTDUPL_DESC {
	// DXGI_MODE_DESC ModeDesc; DXGI_MODE_ROTATION Rotation; BOOL DesktopImageInSystemMemory; } DXGI_OUTDUPL_DESC;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NS:dxgi1_2.DXGI_OUTDUPL_DESC"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_OUTDUPL_DESC
	{
		/// <summary>A DXGI_MODE_DESC structure that describes the display mode of the duplicated output.</summary>
		public DXGI_MODE_DESC ModeDesc;

		/// <summary>A member of the DXGI_MODE_ROTATION enumerated type that describes how the duplicated output rotates an image.</summary>
		public DXGI_MODE_ROTATION Rotation;

		/// <summary>
		/// Specifies whether the resource that contains the desktop image is already located in system memory. <c>TRUE</c> if the resource
		/// is in system memory; otherwise, <c>FALSE</c>. If this value is <c>TRUE</c> and the application requires CPU access, it can use
		/// the IDXGIOutputDuplication::MapDesktopSurface and IDXGIOutputDuplication::UnMapDesktopSurface methods to avoid copying the data
		/// into a staging buffer.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool DesktopImageInSystemMemory;
	}

	/// <summary>
	/// The DXGI_OUTDUPL_DESC structure describes the dimension of the output and the surface that contains the desktop image. The format of
	/// the desktop image is always DXGI_FORMAT_B8G8R8A8_UNORM.
	/// </summary>
	/// <remarks>This structure is used by GetDesc.</remarks>
	/// <summary>The <c>DXGI_OUTDUPL_FRAME_INFO</c> structure describes the current desktop image.</summary>
	/// <remarks>
	/// <para>
	/// A non-zero <c>LastMouseUpdateTime</c> indicates an update to either a mouse pointer position or a mouse pointer position and shape.
	/// That is, the mouse pointer position is always valid for a non-zero <c>LastMouseUpdateTime</c>; however, the application must check
	/// the value of the <c>PointerShapeBufferSize</c> member to determine whether the shape was updated too.
	/// </para>
	/// <para>
	/// If only the pointer was updated (that is, the desktop image was not updated), the <c>AccumulatedFrames</c>,
	/// <c>TotalMetadataBufferSize</c>, and <c>LastPresentTime</c> members are set to zero.
	/// </para>
	/// <para>
	/// An <c>AccumulatedFrames</c> value of one indicates that the application completed processing the last frame before a new desktop
	/// image was presented. If the <c>AccumulatedFrames</c> value is greater than one, more desktop image updates have occurred while the
	/// application processed the last desktop update. In this situation, the operating system accumulated the update regions. For more
	/// information about desktop updates, see Desktop Update Data.
	/// </para>
	/// <para>
	/// A non-zero <c>TotalMetadataBufferSize</c> indicates the total size of the buffers that are required to store all the desktop update
	/// metadata. An application cannot determine the size of each type of metadata. The application must call the
	/// IDXGIOutputDuplication::GetFrameDirtyRects, IDXGIOutputDuplication::GetFrameMoveRects, or
	/// IDXGIOutputDuplication::GetFramePointerShape method to obtain information about each type of metadata.
	/// </para>
	/// <para><c>Note</c>  To correct visual effects, an application must process the move region data before it processes the dirty rectangles.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_outdupl_frame_info typedef struct DXGI_OUTDUPL_FRAME_INFO
	// { LARGE_INTEGER LastPresentTime; LARGE_INTEGER LastMouseUpdateTime; UINT AccumulatedFrames; BOOL RectsCoalesced; BOOL
	// ProtectedContentMaskedOut; DXGI_OUTDUPL_POINTER_POSITION PointerPosition; UINT TotalMetadataBufferSize; UINT PointerShapeBufferSize;
	// } DXGI_OUTDUPL_FRAME_INFO;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NS:dxgi1_2.DXGI_OUTDUPL_FRAME_INFO"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_OUTDUPL_FRAME_INFO
	{
		/// <summary>
		/// The time stamp of the last update of the desktop image. The operating system calls the QueryPerformanceCounter function to
		/// obtain the value. A zero value indicates that the desktop image was not updated since an application last called the
		/// IDXGIOutputDuplication::AcquireNextFrame method to acquire the next frame of the desktop image.
		/// </summary>
		public long LastPresentTime;

		/// <summary>
		/// The time stamp of the last update to the mouse. The operating system calls the QueryPerformanceCounter function to obtain the
		/// value. A zero value indicates that the position or shape of the mouse was not updated since an application last called the
		/// IDXGIOutputDuplication::AcquireNextFrame method to acquire the next frame of the desktop image. The mouse position is always
		/// supplied for a mouse update. A new pointer shape is indicated by a non-zero value in the <c>PointerShapeBufferSize</c> member.
		/// </summary>
		public long LastMouseUpdateTime;

		/// <summary>
		/// The number of frames that the operating system accumulated in the desktop image surface since the calling application processed
		/// the last desktop image. For more information about this number, see Remarks.
		/// </summary>
		public uint AccumulatedFrames;

		/// <summary>
		/// Specifies whether the operating system accumulated updates by coalescing dirty regions. Therefore, the dirty regions might
		/// contain unmodified pixels. <c>TRUE</c> if dirty regions were accumulated; otherwise, <c>FALSE</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool RectsCoalesced;

		/// <summary>
		/// Specifies whether the desktop image might contain protected content that was already blacked out in the desktop image.
		/// <c>TRUE</c> if protected content was already blacked; otherwise, <c>FALSE</c>. The application can use this information to
		/// notify the remote user that some of the desktop content might be protected and therefore not visible.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool ProtectedContentMaskedOut;

		/// <summary>
		/// A DXGI_OUTDUPL_POINTER_POSITION structure that describes the most recent mouse position if the <c>LastMouseUpdateTime</c> member
		/// is a non-zero value; otherwise, this value is ignored. This value provides the coordinates of the location where the
		/// top-left-hand corner of the pointer shape is drawn; this value is not the desktop position of the hot spot.
		/// </summary>
		public DXGI_OUTDUPL_POINTER_POSITION PointerPosition;

		/// <summary>
		/// Size in bytes of the buffers to store all the desktop update metadata for this frame. For more information about this size, see Remarks.
		/// </summary>
		public uint TotalMetadataBufferSize;

		/// <summary>
		/// Size in bytes of the buffer to hold the new pixel data for the mouse shape. For more information about this size, see Remarks.
		/// </summary>
		public uint PointerShapeBufferSize;
	}

	/// <summary>The <c>DXGI_OUTDUPL_MOVE_RECT</c> structure describes the movement of a rectangle.</summary>
	/// <remarks>This structure is used by GetFrameMoveRects.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_outdupl_move_rect typedef struct DXGI_OUTDUPL_MOVE_RECT {
	// POINT SourcePoint; RECT DestinationRect; } DXGI_OUTDUPL_MOVE_RECT;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NS:dxgi1_2.DXGI_OUTDUPL_MOVE_RECT"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_OUTDUPL_MOVE_RECT
	{
		/// <summary>The starting position of a rectangle.</summary>
		public POINT SourcePoint;

		/// <summary>The target region to which to move a rectangle.</summary>
		public RECT DestinationRect;
	}

	/// <summary>The <c>DXGI_OUTDUPL_POINTER_POSITION</c> structure describes the position of the hardware cursor.</summary>
	/// <remarks>The <c>Position</c> member is valid only if the <c>Visible</c> member’s value is set to <c>TRUE</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_outdupl_pointer_position typedef struct
	// DXGI_OUTDUPL_POINTER_POSITION { POINT Position; BOOL Visible; } DXGI_OUTDUPL_POINTER_POSITION;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NS:dxgi1_2.DXGI_OUTDUPL_POINTER_POSITION"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_OUTDUPL_POINTER_POSITION
	{
		/// <summary>The position of the hardware cursor relative to the top-left of the adapter output.</summary>
		public POINT Position;

		/// <summary>
		/// Specifies whether the hardware cursor is visible. <c>TRUE</c> if visible; otherwise, <c>FALSE</c>. If the hardware cursor is not
		/// visible, the calling application does not display the cursor in the client.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool Visible;
	}

	/// <summary>The <c>DXGI_OUTDUPL_POINTER_SHAPE_INFO</c> structure describes information about the cursor shape.</summary>
	/// <remarks>
	/// <para>
	/// An application draws the cursor shape with the top-left-hand corner drawn at the position that the <c>Position</c> member of the
	/// DXGI_OUTDUPL_POINTER_POSITION structure specifies; the application does not use the hot spot to draw the cursor shape.
	/// </para>
	/// <para>
	/// An application calls the IDXGIOutputDuplication::GetFramePointerShape method to retrieve cursor shape information in a
	/// <c>DXGI_OUTDUPL_POINTER_SHAPE_INFO</c> structure.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_outdupl_pointer_shape_info typedef struct
	// DXGI_OUTDUPL_POINTER_SHAPE_INFO { UINT Type; UINT Width; UINT Height; UINT Pitch; POINT HotSpot; } DXGI_OUTDUPL_POINTER_SHAPE_INFO;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NS:dxgi1_2.DXGI_OUTDUPL_POINTER_SHAPE_INFO"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_OUTDUPL_POINTER_SHAPE_INFO
	{
		/// <summary>A DXGI_OUTDUPL_POINTER_SHAPE_TYPE-typed value that specifies the type of cursor shape.</summary>
		public DXGI_OUTDUPL_POINTER_SHAPE_TYPE Type;

		/// <summary>The width in pixels of the mouse cursor.</summary>
		public uint Width;

		/// <summary>The height in scan lines of the mouse cursor.</summary>
		public uint Height;

		/// <summary>The width in bytes of the mouse cursor.</summary>
		public uint Pitch;

		/// <summary>
		/// The position of the cursor's hot spot relative to its upper-left pixel. An application does not use the hot spot when it
		/// determines where to draw the cursor shape.
		/// </summary>
		public POINT HotSpot;
	}

	/// <summary>Describes information about present that helps the operating system optimize presentation.</summary>
	/// <remarks>
	/// <para>This structure is used by the Present1 method.</para>
	/// <para>
	/// The scroll rectangle and the list of dirty rectangles could overlap. In this situation, the dirty rectangles take priority.
	/// Applications can then have pieces of dynamic content on top of a scrolled area. For example, an application could scroll a page and
	/// play video at the same time.
	/// </para>
	/// <para>The following diagram and coordinates illustrate this example.</para>
	/// <para>
	/// Parts of the previous frame and content that the application renders are combined to produce the final frame that the operating
	/// system presents on the display screen. Most of the window is scrolled from the previous frame. The application must update the video
	/// frame with the new chunk of content that appears due to scrolling.
	/// </para>
	/// <para>
	/// The dashed rectangle shows the scroll rectangle in the current frame. The scroll rectangle is specified by the <c>pScrollRect</c>
	/// member. The arrow shows the scroll offset. The scroll offset is specified by the <c>pScrollOffset</c> member. Filled rectangles show
	/// dirty rectangles that the application updated with new content. The filled rectangles are specified by the <c>DirtyRectsCount</c>
	/// and <c>pDirtyRects</c> members.
	/// </para>
	/// <para>
	/// The scroll rectangle and offset are not supported for the DXGI_SWAP_EFFECT_DISCARD or DXGI_SWAP_EFFECT_SEQUENTIAL present option.
	/// Dirty rectangles and scroll rectangle are not supported for multisampled swap chains.
	/// </para>
	/// <para>
	/// The actual implementation of composition and necessary bitblts is different for the bitblt model and the flip model. For more info
	/// about these models, see DXGI Flip Model.
	/// </para>
	/// <para>
	/// For more info about the flip-model swap chain and optimizing presentation, see Enhancing presentation with the flip model, dirty
	/// rectangles, and scrolled areas.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_present_parameters typedef struct DXGI_PRESENT_PARAMETERS
	// { UINT DirtyRectsCount; RECT *pDirtyRects; RECT *pScrollRect; POINT *pScrollOffset; } DXGI_PRESENT_PARAMETERS;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NS:dxgi1_2.DXGI_PRESENT_PARAMETERS"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_PRESENT_PARAMETERS
	{
		/// <summary>
		/// The number of updated rectangles that you update in the back buffer for the presented frame. The operating system uses this
		/// information to optimize presentation. You can set this member to 0 to indicate that you update the whole frame.
		/// </summary>
		public uint DirtyRectsCount;

		/// <summary>
		/// A list of updated rectangles that you update in the back buffer for the presented frame. An application must update every single
		/// pixel in each rectangle that it reports to the runtime; the application cannot assume that the pixels are saved from the
		/// previous frame. For more information about updating dirty rectangles, see Remarks. You can set this member to <c>NULL</c> if
		/// <c>DirtyRectsCount</c> is 0. An application must not update any pixel outside of the dirty rectangles.
		/// </summary>
		public ArrayPointer<RECT> pDirtyRects;

		/// <summary>
		/// <para>
		/// A pointer to the scrolled rectangle. The scrolled rectangle is the rectangle of the previous frame from which the runtime
		/// bit-block transfers (bitblts) content. The runtime also uses the scrolled rectangle to optimize presentation in terminal server
		/// and indirect display scenarios.
		/// </para>
		/// <para>
		/// The scrolled rectangle also describes the destination rectangle, that is, the region on the current frame that is filled with
		/// scrolled content. You can set this member to <c>NULL</c> to indicate that no content is scrolled from the previous frame.
		/// </para>
		/// </summary>
		public StructPointer<RECT> pScrollRect;

		/// <summary>
		/// A pointer to the offset of the scrolled area that goes from the source rectangle (of previous frame) to the destination
		/// rectangle (of current frame). You can set this member to <c>NULL</c> to indicate no offset.
		/// </summary>
		public StructPointer<POINT> pScrollOffset;
	}

	/// <summary>Describes a swap chain.</summary>
	/// <remarks>
	/// <para>
	/// This structure is used by the CreateSwapChainForHwnd, CreateSwapChainForCoreWindow, CreateSwapChainForComposition,
	/// CreateSwapChainForCompositionSurfaceHandle, and GetDesc1 methods.
	/// </para>
	/// <para>
	/// <c>Note</c>  You cannot cast a <c>DXGI_SWAP_CHAIN_DESC1</c> to a DXGI_SWAP_CHAIN_DESC and vice versa. An application must explicitly
	/// use the IDXGISwapChain1::GetDesc1 method to retrieve the newer version of the swap-chain description structure.
	/// </para>
	/// <para></para>
	/// <para>In full-screen mode, there is a dedicated front buffer; in windowed mode, the desktop is the front buffer.</para>
	/// <para>
	/// For a flip-model swap chain (that is, a swap chain that has the DXGI_SWAP_EFFECT_FLIP_DISCARD or DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL
	/// value set in the <c>SwapEffect</c> member), you must set the <c>Format</c> member to DXGI_FORMAT_R16G16B16A16_FLOAT,
	/// <c>DXGI_FORMAT_B8G8R8A8_UNORM</c>, <c>DXGI_FORMAT_R8G8B8A8_UNORM</c>, or <c>DXGI_FORMAT_R10G10B10A10_UNORM</c>; you must set the
	/// <c>Count</c> member of the DXGI_SAMPLE_DESC structure that the <c>SampleDesc</c> member specifies to one and the <c>Quality</c>
	/// member of <c>DXGI_SAMPLE_DESC</c> to zero because multiple sample antialiasing (MSAA) is not supported; you must set the
	/// <c>BufferCount</c> member to from two to sixteen. For more info about flip-model swap chain, see DXGI Flip Model.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1 typedef struct DXGI_SWAP_CHAIN_DESC1 {
	// UINT Width; UINT Height; DXGI_FORMAT Format; BOOL Stereo; DXGI_SAMPLE_DESC SampleDesc; DXGI_USAGE BufferUsage; UINT BufferCount;
	// DXGI_SCALING Scaling; DXGI_SWAP_EFFECT SwapEffect; DXGI_ALPHA_MODE AlphaMode; UINT Flags; } DXGI_SWAP_CHAIN_DESC1;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NS:dxgi1_2.DXGI_SWAP_CHAIN_DESC1"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_SWAP_CHAIN_DESC1
	{
		/// <summary>
		/// A value that describes the resolution width. If you specify the width as zero when you call the
		/// IDXGIFactory2::CreateSwapChainForHwnd method to create a swap chain, the runtime obtains the width from the output window and
		/// assigns this width value to the swap-chain description. You can subsequently call the IDXGISwapChain1::GetDesc1 method to
		/// retrieve the assigned width value. You cannot specify the width as zero when you call the
		/// IDXGIFactory2::CreateSwapChainForComposition method.
		/// </summary>
		public uint Width;

		/// <summary>
		/// A value that describes the resolution height. If you specify the height as zero when you call the
		/// IDXGIFactory2::CreateSwapChainForHwnd method to create a swap chain, the runtime obtains the height from the output window and
		/// assigns this height value to the swap-chain description. You can subsequently call the IDXGISwapChain1::GetDesc1 method to
		/// retrieve the assigned height value. You cannot specify the height as zero when you call the
		/// IDXGIFactory2::CreateSwapChainForComposition method.
		/// </summary>
		public uint Height;

		/// <summary>A DXGI_FORMAT structure that describes the display format.</summary>
		public DXGI_FORMAT Format;

		/// <summary>
		/// Specifies whether the full-screen display mode or the swap-chain back buffer is stereo. <c>TRUE</c> if stereo; otherwise,
		/// <c>FALSE</c>. If you specify stereo, you must also specify a flip-model swap chain (that is, a swap chain that has the
		/// DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL value set in the <c>SwapEffect</c> member).
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool Stereo;

		/// <summary>
		/// A DXGI_SAMPLE_DESC structure that describes multi-sampling parameters. This member is valid only with bit-block transfer
		/// (bitblt) model swap chains.
		/// </summary>
		public DXGI_SAMPLE_DESC SampleDesc;

		/// <summary>
		/// A DXGI_USAGE-typed value that describes the surface usage and CPU access options for the back buffer. The back buffer can be
		/// used for shader input or render-target output.
		/// </summary>
		public DXGI_USAGE BufferUsage;

		/// <summary>
		/// A value that describes the number of buffers in the swap chain. When you create a full-screen swap chain, you typically include
		/// the front buffer in this value.
		/// </summary>
		public uint BufferCount;

		/// <summary>
		/// A DXGI_SCALING-typed value that identifies resize behavior if the size of the back buffer is not equal to the target output.
		/// </summary>
		public DXGI_SCALING Scaling;

		/// <summary>
		/// A DXGI_SWAP_EFFECT-typed value that describes the presentation model that is used by the swap chain and options for handling the
		/// contents of the presentation buffer after presenting a surface. You must specify the DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL value when
		/// you call the IDXGIFactory2::CreateSwapChainForComposition method because this method supports only flip presentation model.
		/// </summary>
		public DXGI_SWAP_EFFECT SwapEffect;

		/// <summary>A DXGI_ALPHA_MODE-typed value that identifies the transparency behavior of the swap-chain back buffer.</summary>
		public DXGI_ALPHA_MODE AlphaMode;

		/// <summary>
		/// A combination of DXGI_SWAP_CHAIN_FLAG-typed values that are combined by using a bitwise OR operation. The resulting value
		/// specifies options for swap-chain behavior.
		/// </summary>
		public DXGI_SWAP_CHAIN_FLAG Flags;
	}

	/// <summary>Describes full-screen mode for a swap chain.</summary>
	/// <remarks>This structure is used by the CreateSwapChainForHwnd and GetFullscreenDesc methods.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_fullscreen_desc typedef struct
	// DXGI_SWAP_CHAIN_FULLSCREEN_DESC { DXGI_RATIONAL RefreshRate; DXGI_MODE_SCANLINE_ORDER ScanlineOrdering; DXGI_MODE_SCALING Scaling;
	// BOOL Windowed; } DXGI_SWAP_CHAIN_FULLSCREEN_DESC;
	[PInvokeData("dxgi1_2.h", MSDNShortId = "NS:dxgi1_2.DXGI_SWAP_CHAIN_FULLSCREEN_DESC"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_SWAP_CHAIN_FULLSCREEN_DESC
	{
		/// <summary>A DXGI_RATIONAL structure that describes the refresh rate in hertz.</summary>
		public DXGI_RATIONAL RefreshRate;

		/// <summary>A member of the DXGI_MODE_SCANLINE_ORDER enumerated type that describes the scan-line drawing mode.</summary>
		public DXGI_MODE_SCANLINE_ORDER ScanlineOrdering;

		/// <summary>A member of the DXGI_MODE_SCALING enumerated type that describes the scaling mode.</summary>
		public DXGI_MODE_SCALING Scaling;

		/// <summary>
		/// A Boolean value that specifies whether the swap chain is in windowed mode. <c>TRUE</c> if the swap chain is in windowed mode;
		/// otherwise, <c>FALSE</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool Windowed;
	}
}