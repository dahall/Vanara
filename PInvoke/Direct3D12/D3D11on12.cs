using static Vanara.PInvoke.D3D11;

namespace Vanara.PInvoke;

public static partial class D3D12
{
	/// <summary>Handles the creation, wrapping, and releasing of Direct3D 11 resources for Direct3D11on12.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nn-d3d11on12-id3d11on12device
	[PInvokeData("d3d11on12.h", MSDNShortId = "NN:d3d11on12.ID3D11On12Device")]
	[ComImport, Guid("85611e73-70a9-490e-9614-a9e302777904"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11On12Device
	{
		/// <summary>This method creates D3D11 resources for use with D3D 11on12.</summary>
		/// <param name="pResource12">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>A pointer to an already-created D3D12 resource or heap.</para>
		/// </param>
		/// <param name="pFlags11">
		/// <para>Type: <c>const D3D11_RESOURCE_FLAGS*</c></para>
		/// <para>
		/// A D3D11_RESOURCE_FLAGS structure that enables an application to override flags that would be inferred by the resource/heap
		/// properties. The D3D11_RESOURCE_FLAGS structure contains bind flags, misc flags, and CPU access flags.
		/// </para>
		/// </param>
		/// <param name="InState">
		/// <para>Type: <c>D3D12_RESOURCE_STATES</c></para>
		/// <para>The use of the resource on input, as a bitwise-OR'd combination of D3D12_RESOURCE_STATES enumeration constants.</para>
		/// </param>
		/// <param name="OutState">
		/// <para>Type: <c>D3D12_RESOURCE_STATES</c></para>
		/// <para>The use of the resource on output, as a bitwise-OR'd combination of D3D12_RESOURCE_STATES enumeration constants.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// The globally unique identifier ( <c>GUID</c>) for the wrapped resource interface. The <c>REFIID</c>, or <c>GUID</c>, of the
		/// interface to the wrapped resource can be obtained by using the __uuidof() macro. For example, __uuidof(ID3D11Resource) will get
		/// the <c>GUID</c> of the interface to a wrapped resource.
		/// </para>
		/// </param>
		/// <param name="ppResource11">
		/// <para>Type: <c>void**</c></para>
		/// <para>After the method returns, points to the newly created wrapped D3D11 resource or heap.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 12 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-id3d11on12device-createwrappedresource HRESULT
		// CreateWrappedResource( [in] IUnknown *pResource12, [in] const D3D11_RESOURCE_FLAGS *pFlags11, D3D12_RESOURCE_STATES InState,
		// D3D12_RESOURCE_STATES OutState, REFIID riid, [out, optional] void **ppResource11 );
		[PreserveSig]
		HRESULT CreateWrappedResource([MarshalAs(UnmanagedType.IUnknown)] object pResource12, in D3D11_RESOURCE_FLAGS pFlags11,
			D3D12_RESOURCE_STATES InState, D3D12_RESOURCE_STATES OutState, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppResource11);

		/// <summary>Releases D3D11 resources that were wrapped for D3D 11on12.</summary>
		/// <param name="ppResources">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>Specifies a pointer to a set of D3D11 resources, defined by ID3D11Resource.</para>
		/// </param>
		/// <param name="NumResources">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Count of the number of resources.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Call this method prior to calling Flush, to insert resource barriers to the appropriate "out" state, and to mark that they
		/// should then be expected to be in the "in" state. If no resource list is provided, all wrapped resources are transitioned. These
		/// resources will be marked as “not acquired” in hazard tracking until ID3D11On12Device::AcquireWrappedResources is called.
		/// </para>
		/// <para>Keyed mutex resources cannot be provided to this method; use IDXGIKeyedMutex::ReleaseSync instead.</para>
		/// <para>Examples</para>
		/// <para>Render text over D3D12 using D2D via the 11On12 device.</para>
		/// <para>Refer to the Example Code in the D3D12 Reference.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-id3d11on12device-releasewrappedresources void
		// ReleaseWrappedResources( [in] ID3D11Resource * const *ppResources, UINT NumResources );
		[PreserveSig]
		void ReleaseWrappedResources([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Resource[] ppResources, int NumResources);

		/// <summary>Acquires D3D11 resources for use with D3D 11on12. Indicates that rendering to the wrapped resources can begin again.</summary>
		/// <param name="ppResources">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>Specifies a pointer to a set of D3D11 resources, defined by ID3D11Resource.</para>
		/// </param>
		/// <param name="NumResources">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Count of the number of resources.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This method marks the resources as "acquired" in hazard tracking.</para>
		/// <para>Keyed mutex resources cannot be provided to this method; use IDXGIKeyedMutex::AcquireSync instead.</para>
		/// <para>Examples</para>
		/// <para>Render text over D3D12 using D2D via the 11On12 device.</para>
		/// <para>Refer to the Example Code in the D3D12 Reference.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-id3d11on12device-acquirewrappedresources void
		// AcquireWrappedResources( [in] ID3D11Resource * const *ppResources, UINT NumResources );
		[PreserveSig]
		void AcquireWrappedResources([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Resource[] ppResources, int NumResources);
	}

	/// <summary>
	/// Enables better interoperability with a component that might be handed a Direct3D 11 device, but which wants to leverage Direct3D 12
	/// instead. This interface extends ID3D11On12Device to retrieve the Direct3D 12 device being interoperated with.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nn-d3d11on12-id3d11on12device1
	[PInvokeData("d3d11on12.h", MSDNShortId = "NN:d3d11on12.ID3D11On12Device1")]
	[ComImport, Guid("bdb64df4-ea2f-4c70-b861-aaab1258bb5d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11On12Device1 : ID3D11On12Device
	{
		/// <summary>This method creates D3D11 resources for use with D3D 11on12.</summary>
		/// <param name="pResource12">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>A pointer to an already-created D3D12 resource or heap.</para>
		/// </param>
		/// <param name="pFlags11">
		/// <para>Type: <c>const D3D11_RESOURCE_FLAGS*</c></para>
		/// <para>
		/// A D3D11_RESOURCE_FLAGS structure that enables an application to override flags that would be inferred by the resource/heap
		/// properties. The D3D11_RESOURCE_FLAGS structure contains bind flags, misc flags, and CPU access flags.
		/// </para>
		/// </param>
		/// <param name="InState">
		/// <para>Type: <c>D3D12_RESOURCE_STATES</c></para>
		/// <para>The use of the resource on input, as a bitwise-OR'd combination of D3D12_RESOURCE_STATES enumeration constants.</para>
		/// </param>
		/// <param name="OutState">
		/// <para>Type: <c>D3D12_RESOURCE_STATES</c></para>
		/// <para>The use of the resource on output, as a bitwise-OR'd combination of D3D12_RESOURCE_STATES enumeration constants.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// The globally unique identifier ( <c>GUID</c>) for the wrapped resource interface. The <c>REFIID</c>, or <c>GUID</c>, of the
		/// interface to the wrapped resource can be obtained by using the __uuidof() macro. For example, __uuidof(ID3D11Resource) will get
		/// the <c>GUID</c> of the interface to a wrapped resource.
		/// </para>
		/// </param>
		/// <param name="ppResource11">
		/// <para>Type: <c>void**</c></para>
		/// <para>After the method returns, points to the newly created wrapped D3D11 resource or heap.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 12 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-id3d11on12device-createwrappedresource HRESULT
		// CreateWrappedResource( [in] IUnknown *pResource12, [in] const D3D11_RESOURCE_FLAGS *pFlags11, D3D12_RESOURCE_STATES InState,
		// D3D12_RESOURCE_STATES OutState, REFIID riid, [out, optional] void **ppResource11 );
		[PreserveSig]
		new HRESULT CreateWrappedResource([MarshalAs(UnmanagedType.IUnknown)] object pResource12, in D3D11_RESOURCE_FLAGS pFlags11,
			D3D12_RESOURCE_STATES InState, D3D12_RESOURCE_STATES OutState, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppResource11);

		/// <summary>Releases D3D11 resources that were wrapped for D3D 11on12.</summary>
		/// <param name="ppResources">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>Specifies a pointer to a set of D3D11 resources, defined by ID3D11Resource.</para>
		/// </param>
		/// <param name="NumResources">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Count of the number of resources.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Call this method prior to calling Flush, to insert resource barriers to the appropriate "out" state, and to mark that they
		/// should then be expected to be in the "in" state. If no resource list is provided, all wrapped resources are transitioned. These
		/// resources will be marked as “not acquired” in hazard tracking until ID3D11On12Device::AcquireWrappedResources is called.
		/// </para>
		/// <para>Keyed mutex resources cannot be provided to this method; use IDXGIKeyedMutex::ReleaseSync instead.</para>
		/// <para>Examples</para>
		/// <para>Render text over D3D12 using D2D via the 11On12 device.</para>
		/// <para>Refer to the Example Code in the D3D12 Reference.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-id3d11on12device-releasewrappedresources void
		// ReleaseWrappedResources( [in] ID3D11Resource * const *ppResources, UINT NumResources );
		[PreserveSig]
		new void ReleaseWrappedResources([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Resource[] ppResources, int NumResources);

		/// <summary>Acquires D3D11 resources for use with D3D 11on12. Indicates that rendering to the wrapped resources can begin again.</summary>
		/// <param name="ppResources">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>Specifies a pointer to a set of D3D11 resources, defined by ID3D11Resource.</para>
		/// </param>
		/// <param name="NumResources">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Count of the number of resources.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This method marks the resources as "acquired" in hazard tracking.</para>
		/// <para>Keyed mutex resources cannot be provided to this method; use IDXGIKeyedMutex::AcquireSync instead.</para>
		/// <para>Examples</para>
		/// <para>Render text over D3D12 using D2D via the 11On12 device.</para>
		/// <para>Refer to the Example Code in the D3D12 Reference.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-id3d11on12device-acquirewrappedresources void
		// AcquireWrappedResources( [in] ID3D11Resource * const *ppResources, UINT NumResources );
		[PreserveSig]
		new void AcquireWrappedResources([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Resource[] ppResources, int NumResources);

		/// <summary>
		/// Retrieves the Direct3D 12 device being interoperated with. This enables better interoperability with a component that might be
		/// handed a Direct3D 11 device, but which wants to leverage Direct3D 12 instead.
		/// </summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in . This is expected to be
		/// the GUID of ID3D12Device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the device. This is the address of a pointer to an ID3D12Device,
		/// representing the Direct3D 12 device.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an HRESULT error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-id3d11on12device1-getd3d12device HRESULT
		// GetD3D12Device( REFIID riid, void **ppvDevice );
		[PreserveSig]
		HRESULT GetD3D12Device(in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvDevice);
	}

	/// <summary>
	/// Enables you to take resources created through the Direct3D 11 APIs, and use them in Direct3D 12. This interface extends ID3D11On12Device1.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nn-d3d11on12-id3d11on12device2
	[PInvokeData("d3d11on12.h", MSDNShortId = "NN:d3d11on12.ID3D11On12Device2")]
	[ComImport, Guid("dc90f331-4740-43fa-866e-67f12cb58223"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11On12Device2 : ID3D11On12Device1, ID3D11On12Device
	{
		/// <summary>This method creates D3D11 resources for use with D3D 11on12.</summary>
		/// <param name="pResource12">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>A pointer to an already-created D3D12 resource or heap.</para>
		/// </param>
		/// <param name="pFlags11">
		/// <para>Type: <c>const D3D11_RESOURCE_FLAGS*</c></para>
		/// <para>
		/// A D3D11_RESOURCE_FLAGS structure that enables an application to override flags that would be inferred by the resource/heap
		/// properties. The D3D11_RESOURCE_FLAGS structure contains bind flags, misc flags, and CPU access flags.
		/// </para>
		/// </param>
		/// <param name="InState">
		/// <para>Type: <c>D3D12_RESOURCE_STATES</c></para>
		/// <para>The use of the resource on input, as a bitwise-OR'd combination of D3D12_RESOURCE_STATES enumeration constants.</para>
		/// </param>
		/// <param name="OutState">
		/// <para>Type: <c>D3D12_RESOURCE_STATES</c></para>
		/// <para>The use of the resource on output, as a bitwise-OR'd combination of D3D12_RESOURCE_STATES enumeration constants.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// The globally unique identifier ( <c>GUID</c>) for the wrapped resource interface. The <c>REFIID</c>, or <c>GUID</c>, of the
		/// interface to the wrapped resource can be obtained by using the __uuidof() macro. For example, __uuidof(ID3D11Resource) will get
		/// the <c>GUID</c> of the interface to a wrapped resource.
		/// </para>
		/// </param>
		/// <param name="ppResource11">
		/// <para>Type: <c>void**</c></para>
		/// <para>After the method returns, points to the newly created wrapped D3D11 resource or heap.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 12 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-id3d11on12device-createwrappedresource HRESULT
		// CreateWrappedResource( [in] IUnknown *pResource12, [in] const D3D11_RESOURCE_FLAGS *pFlags11, D3D12_RESOURCE_STATES InState,
		// D3D12_RESOURCE_STATES OutState, REFIID riid, [out, optional] void **ppResource11 );
		[PreserveSig]
		new HRESULT CreateWrappedResource([In, MarshalAs(UnmanagedType.IUnknown)] object pResource12, in D3D11_RESOURCE_FLAGS pFlags11,
			D3D12_RESOURCE_STATES InState, D3D12_RESOURCE_STATES OutState, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppResource11);

		/// <summary>Releases D3D11 resources that were wrapped for D3D 11on12.</summary>
		/// <param name="ppResources">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>Specifies a pointer to a set of D3D11 resources, defined by ID3D11Resource.</para>
		/// </param>
		/// <param name="NumResources">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Count of the number of resources.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Call this method prior to calling Flush, to insert resource barriers to the appropriate "out" state, and to mark that they
		/// should then be expected to be in the "in" state. If no resource list is provided, all wrapped resources are transitioned. These
		/// resources will be marked as “not acquired” in hazard tracking until ID3D11On12Device::AcquireWrappedResources is called.
		/// </para>
		/// <para>Keyed mutex resources cannot be provided to this method; use IDXGIKeyedMutex::ReleaseSync instead.</para>
		/// <para>Examples</para>
		/// <para>Render text over D3D12 using D2D via the 11On12 device.</para>
		/// <para>Refer to the Example Code in the D3D12 Reference.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-id3d11on12device-releasewrappedresources void
		// ReleaseWrappedResources( [in] ID3D11Resource * const *ppResources, UINT NumResources );
		[PreserveSig]
		new void ReleaseWrappedResources([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Resource[] ppResources, int NumResources);

		/// <summary>Acquires D3D11 resources for use with D3D 11on12. Indicates that rendering to the wrapped resources can begin again.</summary>
		/// <param name="ppResources">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>Specifies a pointer to a set of D3D11 resources, defined by ID3D11Resource.</para>
		/// </param>
		/// <param name="NumResources">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Count of the number of resources.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This method marks the resources as "acquired" in hazard tracking.</para>
		/// <para>Keyed mutex resources cannot be provided to this method; use IDXGIKeyedMutex::AcquireSync instead.</para>
		/// <para>Examples</para>
		/// <para>Render text over D3D12 using D2D via the 11On12 device.</para>
		/// <para>Refer to the Example Code in the D3D12 Reference.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-id3d11on12device-acquirewrappedresources void
		// AcquireWrappedResources( [in] ID3D11Resource * const *ppResources, UINT NumResources );
		[PreserveSig]
		new void AcquireWrappedResources([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Resource[] ppResources, int NumResources);

		/// <summary>
		/// Retrieves the Direct3D 12 device being interoperated with. This enables better interoperability with a component that might be
		/// handed a Direct3D 11 device, but which wants to leverage Direct3D 12 instead.
		/// </summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in . This is expected to be
		/// the GUID of ID3D12Device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the device. This is the address of a pointer to an ID3D12Device,
		/// representing the Direct3D 12 device.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an HRESULT error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-id3d11on12device1-getd3d12device HRESULT
		// GetD3D12Device( REFIID riid, void **ppvDevice );
		[PreserveSig]
		new HRESULT GetD3D12Device(in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvDevice);

		/// <summary>Unwraps a Direct3D 11 resource object, and retrieves it as a Direct3D 12 resource object.</summary>
		/// <param name="pResource11">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>The Direct3D 11 resource object to unwrap.</para>
		/// </param>
		/// <param name="pCommandQueue">
		/// <para>Type: <c>ID3D12CommandQueue*</c></para>
		/// <para>
		/// The command queue on which your application plans to use the resource. Any pending work accessing the resource causes fence
		/// waits to be scheduled on this queue. You can then queue further work on this queue, including a signal on a caller-owned fence.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in .</para>
		/// </param>
		/// <param name="ppvResource12">
		/// <para>Type: <c>void**</c></para>
		/// <para>A pointer to a memory block that receives a pointer to the Direct3D 12 resource.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an HRESULT error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The resource is transitioned to <c>D3D12_RESOURCE_STATE_COMMON</c> (if it wasn't already in that state), and appropriate waits
		/// are inserted into the command queue (pCommandQueue).
		/// </para>
		/// <para>
		/// There are some restrictions on what can be unwrapped: no keyed mutex resources, no GDI-compatible resources, and no buffers.
		/// However, you can use <c>UnwrapUnderlyingResource</c> to unwrap resources created through the
		/// <c>ID3D11On12Device::CreateWrappedResource</c> method, as well as resources created through ID3D11Device::CreateTexture2D.
		/// </para>
		/// <para>In general, you must return the object to Direct3D11on12 before using it again in Direct3D 11 (see ID3D11On12Device2::ReturnUnderlyingResource).</para>
		/// <para>
		/// You can also use <c>UnwrapUnderlyingResource</c> to unwrap a swapchain buffer. You must also return the resource to
		/// Direct3D11on12 before calling <c>Present</c> (or otherwise using the resource).
		/// </para>
		/// <para>
		/// Unwrapping a resource checks out the resource from the Direct3D11On12 translation layer. You may not schedule any translation
		/// layer usage (through either version of the API) while the resource is checked out. Check the resource back in (also known as
		/// returning the resource) with ID3D11On12Device2::ReturnUnderlyingResource.
		/// </para>
		/// <para>
		/// <c>UnwrapUnderlyingResource</c> doesn't flush, and it may schedule GPU work. You should flush after calling
		/// <c>UnwrapUnderlyingResource</c> if you externally wait for completion.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-id3d11on12device2-unwrapunderlyingresource HRESULT
		// UnwrapUnderlyingResource( [in] ID3D11Resource *pResource11, [in] ID3D12CommandQueue *pCommandQueue, [in] REFIID riid, [out] void
		// **ppvResource12 );
		[PreserveSig]
		HRESULT UnwrapUnderlyingResource([In] ID3D11Resource pResource11, [In] ID3D12CommandQueue pCommandQueue, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown)] out object ppvResource12);

		/// <summary>
		/// With this method, you can return a Direct3D 11 resource object to Direct3D11On12, and indicate (by way of fences and fence
		/// signal values) when the resource will be ready for Direct3D11On12 to consume. You should call <c>ReturnUnderlyingResource</c>
		/// once Direct3D 12 work has been scheduled.
		/// </summary>
		/// <param name="pResource11">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>The Direct3D 11 resource object that you wish to return.</para>
		/// </param>
		/// <param name="NumSync">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the arrays pointed to by pSignalValues and ppFences.</para>
		/// </param>
		/// <param name="pSignalValues">
		/// <para>Type: <c>UINT64*</c></para>
		/// <para>A pointer to an array of fence signal values.</para>
		/// </param>
		/// <param name="ppFences">
		/// <para>Type: <c>ID3D12Fence**</c></para>
		/// <para>A pointer to an array of fence objects.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an HRESULT error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When you return a resource, you provide a set of fences and fence signal values whose completion indicates that the resource is
		/// back in the <c>D3D12_RESOURCE_STATE_COMMON</c> state, and ready for Direct3D11On12 to consume it.
		/// </para>
		/// <para>
		/// In the parallel arrays pSignalValues and ppFences, include any pending work against the resource. The Direct3D11On12 translation
		/// layer defers the waits for these arguments until work is scheduled against the resource.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-id3d11on12device2-returnunderlyingresource HRESULT
		// ReturnUnderlyingResource( [in] ID3D11Resource *pResource11, [in] UINT NumSync, [in] UINT64 *pSignalValues, [in] ID3D12Fence
		// **ppFences );
		[PreserveSig]
		HRESULT ReturnUnderlyingResource([In] ID3D11Resource pResource11, int NumSync, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ulong[] pSignalValues,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D12Fence[] ppFences);
	}

	/// <summary>
	/// Used with ID3D11On12Device::CreateWrappedResource to override flags that would be inferred by the resource properties or heap
	/// properties, including bind flags, misc flags, and CPU access flags.
	/// </summary>
	/// <remarks>Use this structure with CreateWrappedResource.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/ns-d3d11on12-d3d11_resource_flags typedef struct D3D11_RESOURCE_FLAGS {
	// UINT BindFlags; UINT MiscFlags; UINT CPUAccessFlags; UINT StructureByteStride; } D3D11_RESOURCE_FLAGS;
	[PInvokeData("d3d11on12.h", MSDNShortId = "NS:d3d11on12.D3D11_RESOURCE_FLAGS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_RESOURCE_FLAGS
	{
		/// <summary>
		/// <para>
		/// Bind flags must be either completely inferred, or completely specified, to allow the graphics driver to scope a general D3D12
		/// resource to something that D3D11 can understand.
		/// </para>
		/// <para>If a bind flag is specified which is not supported by the provided resource, an error will be returned.</para>
		/// <para>
		/// The following bind flags (D3D11_BIND_FLAG enumeration constants) will not be assumed, and must be specified in order for a
		/// resource to be used in such a fashion:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D11_BIND_VERTEX_BUFFER</description>
		/// </item>
		/// <item>
		/// <description>D3D11_BIND_INDEX_BUFFER</description>
		/// </item>
		/// <item>
		/// <description>D3D11_BIND_CONSTANT_BUFFER</description>
		/// </item>
		/// <item>
		/// <description>D3D11_BIND_STREAM_OUTPUT</description>
		/// </item>
		/// <item>
		/// <description>D3D11_BIND_DECODER</description>
		/// </item>
		/// <item>
		/// <description>D3D11_BIND_VIDEO_ENCODER</description>
		/// </item>
		/// </list>
		/// <para>
		/// The following bind flags will be assumed based on the presence of the corresponding D3D12 resource flag, and can be removed by
		/// specifying bind flags:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D11_BIND_SHADER_RESOURCE, as long as D3D12_RESOURCE_MISC_DENY_SHADER_RESOURCE is not present</description>
		/// </item>
		/// <item>
		/// <description>D3D11_BIND_RENDER_TARGET, if D3D12_RESOURCE_MISC_ALLOW_RENDER_TARGET is present</description>
		/// </item>
		/// <item>
		/// <description>D3D11_BIND_DEPTH_STENCIL, if D3D12_RESOURCE_MISC_ALLOW_DEPTH_STENCIL is present</description>
		/// </item>
		/// <item>
		/// <description>D3D11_BIND_UNORDERED_ACCESS, if D3D12_RESOURCE_MISC_ALLOW_UNORDERED_ACCESS is present</description>
		/// </item>
		/// </list>
		/// <para>
		/// A render target or UAV buffer can be wrapped without overriding flags; but a VB/IB/CB/SO buffer must have bind flags manually
		/// specified, since these are mutually exclusive in Direct3D 11.
		/// </para>
		/// </summary>
		public D3D11_BIND_FLAG BindFlags;

		/// <summary>
		/// <para>
		/// If misc flags are nonzero, then any specified flags will be OR’d into the final resource desc with inferred flags. Misc flags
		/// can be partially specified in order to add functionality, but misc flags which are implied cannot be masked out.
		/// </para>
		/// <para>The following misc flags (D3D11_RESOURCE_MISC_FLAG enumeration constants) will not be assumed:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_GENERATE_MIPS (conflicts with CLAMP).</description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_TEXTURECUBE (alters default view behavior).</description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS (exclusive with some bind flags).</description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_BUFFER_ALLOW_RAW_VIEWS (exclusive with other types of UAVs).</description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_BUFFER_STRUCTURED (exclusive with other types of UAVs).</description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_RESOURCE_CLAMP (prohibits D3D10 QIs, conflicts with GENERATE_MIPS).</description>
		/// </item>
		/// <item>
		/// <description>
		/// D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX. It is possible to create a D3D11 keyed mutex resource, create a shared handle for it, and
		/// open it via 11on12 or D3D11.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// The following misc flags will be assumed, and cannot be removed from the produced resource desc. If one of these is set, and the
		/// D3D12 resource does not support it, creation will fail:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// D3D11_RESOURCE_MISC_SHARED, D3D11_RESOURCE_MISC_SHARED_NTHANDLE, D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE, if appropriate
		/// heap misc flags are present.
		/// </description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_GDI_COMPATIBLE, if D3D12 resource is GDI-compatible.</description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_TILED, if D3D12 resource was created via CreateReservedResource.</description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_TILE_POOL, if a D3D12 heap was passed in.</description>
		/// </item>
		/// </list>
		/// <para>The following misc flags are invalid to specify for this API:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_RESTRICTED_CONTENT, since D3D12 only supports hardware protection.</description>
		/// </item>
		/// <item>
		/// <description>
		/// D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE_DRIVER does not exist in 12, and cannot be added in after resource creation.
		/// </description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_GUARDED is only meant to be set by an internal creation mechanism.</description>
		/// </item>
		/// </list>
		/// </summary>
		public D3D11_RESOURCE_MISC_FLAG MiscFlags;

		/// <summary>
		/// The <c>CPUAccessFlags</c> are not inferred from the D3D12 resource. This is because all resources are treated as
		/// D3D11_USAGE_DEFAULT, so <c>CPUAccessFlags</c> force validation which assumes Map of default buffers or textures. Wrapped
		/// resources do not support <c>Map(DISCARD)</c>. Wrapped resources do not support <c>Map(NO_OVERWRITE)</c>, but that can be
		/// implemented by mapping the underlying D3D12 resource instead. Issuing a <c>Map</c> call on a wrapped resource will synchronize
		/// with all D3D11 work submitted against that resource, unless the DO_NOT_WAIT flag was used.
		/// </summary>
		public D3D10_CPU_ACCESS_FLAG CPUAccessFlags;

		/// <summary>The size of each element in the buffer structure (in bytes) when the buffer represents a structured buffer.</summary>
		public uint StructureByteStride;
	}

	/// <summary>Specifies the types of CPU access allowed for a resource.</summary>
	/// <remarks>
	/// <para>This enumeration is used in D3D10_BUFFER_DESC, D3D10_TEXTURE1D_DESC, D3D10_TEXTURE2D_DESC, D3D10_TEXTURE3D_DESC, and D3DX10_IMAGE_LOAD_INFO. See Creating Buffer Resources (Direct3D 10) for more details.</para>
	/// <para>Applications can combine one or more of these flags with a bitwise OR. When possible, create resources with no CPU access flags, as this enables better resource optimization.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d10/ne-d3d10-d3d10_cpu_access_flag
	// typedef enum D3D10_CPU_ACCESS_FLAG { D3D10_CPU_ACCESS_WRITE = 0x10000L, D3D10_CPU_ACCESS_READ = 0x20000L } ;
	[PInvokeData("d3d10.h", MSDNShortId = "NE:d3d10.D3D10_CPU_ACCESS_FLAG")]
	[Flags]
	public enum D3D10_CPU_ACCESS_FLAG
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x10000L</para>
		///   <para>The resource is to be</para>
		///   <para>mappable</para>
		///   <para>so that the CPU can change its contents. Resources created with this flag cannot be set as outputs of the pipeline and must be created with either dynamic or staging usage (see</para>
		///   <para>D3D10_USAGE</para>
		///   <para>).</para>
		/// </summary>
		D3D10_CPU_ACCESS_WRITE = 0x10000,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x20000L</para>
		///   <para>The resource is to be</para>
		///   <para>mappable</para>
		///   <para>so that the CPU can read its contents. Resources created with this flag cannot be set as either inputs or outputs to the pipeline and must be created with staging usage (see</para>
		///   <para>D3D10_USAGE</para>
		///   <para>).</para>
		/// </summary>
		D3D10_CPU_ACCESS_READ = 0x20000,
	}
}